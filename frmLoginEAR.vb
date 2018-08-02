﻿Imports GrFingerXLib
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Globalization
Imports System.Resources
Imports System.Threading
Imports System.Data.SqlClient

Public Class frmLoginEAR

#Region "Variables"
    Dim cn As SqlConnection
    Dim myUtil As Util
    Dim cm As SqlCommand
    Dim dr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim cont As Integer
    Dim exito As Boolean = False
#End Region

#Region "Funciones"

    Private Sub AxGrFingerXCtrl1_ImageAcquired(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_ImageAcquiredEvent) Handles AxGrFingerXCtrl1.ImageAcquired
        myUtil.raw.height = e.height
        myUtil.raw.width = e.width
        myUtil.raw.res = e.res
        myUtil.raw.img = e.rawImage
        myUtil.WriteLog("Lector: " & e.idSensor & ". Evento: Imagen capturada.")
        myUtil.PrintBiometricDisplay(False, GRConstants.GR_DEFAULT_CONTEXT)
        ExtractButton_Click()
    End Sub

    Private Sub ExtractButton_Click()
        Dim ret As Integer
        ret = myUtil.ExtractTemplate()
        If ret = GRConstants.GR_BAD_QUALITY Then
            myUtil.WriteLog("Patron extraido correctamente. Baja Calidad.")
        ElseIf ret = GRConstants.GR_MEDIUM_QUALITY Then
            myUtil.WriteLog("Patron extraido correctamente. Calidad Media.")
        ElseIf ret = GRConstants.GR_HIGH_QUALITY Then
            myUtil.WriteLog("Patron extraido correctamente. Alta Calidad.")
        End If
        If ret >= 0 Then
            myUtil.PrintBiometricDisplay(True, GRConstants.GR_NO_CONTEXT)
        Else
            myUtil.WriteError(ret)
        End If
    End Sub

    Private Sub AxGrFingerXCtrl1_SensorPlug(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorPlugEvent) Handles AxGrFingerXCtrl1.SensorPlug
        myUtil.WriteLog("Lector: " & e.idSensor & ". Evento: Conectado.")
        AxGrFingerXCtrl1.CapStartCapture(e.idSensor)
    End Sub

    Private Sub AxGrFingerXCtrl1_SensorUnplug(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorUnplugEvent) Handles AxGrFingerXCtrl1.SensorUnplug
        myUtil.WriteLog("Lector: " & e.idSensor & ". Evento: Desconectado.")
        AxGrFingerXCtrl1.CapStopCapture(e.idSensor)
    End Sub

    Private Sub AxGrFingerXCtrl1_FingerDown(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerDownEvent) Handles AxGrFingerXCtrl1.FingerDown
        myUtil.WriteLog("Lector: " & e.idSensor & ". Evento: Dedo Colocado.")
    End Sub

    Private Sub AxGrFingerXCtrl1_FingerUp(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerUpEvent) Handles AxGrFingerXCtrl1.FingerUp
        myUtil.WriteLog("Sensor: " & e.idSensor & ". Evento: Dedo Retirado.")
        validar()
        Me.Visible = True
    End Sub

    Private Sub validar()
        Dim da As New SqlDataAdapter("select cve_Empleado,Id_Usuario, Nombre + ' ' + ape_pat + ' ' + ape_mat as Nombre, password, HUELLA1, huella2, huella3, " & _
            "estado, Bloqueo, FechaCaducidad, Autorizar from Usuario WHERE (Huella1 IS NOT NULL) AND (Huella2 IS NOT NULL) AND (Huella3 IS NOT NULL)", cn)
        Dim ret As Integer = Nothing
        Dim tptref As System.Array = Nothing
        Dim ds As New DataSet
        Dim tpt As New TTemplate
        Dim xx As Byte = Nothing
        Dim xx1 As System.Array
        Dim xx2 As System.Array
        Dim xx3 As System.Array
        exito = False
        Dim Bloqueo As Boolean
        Dim EstadoCuenta As String = Nothing
        Dim FechaCaducidad As String = Nothing
        Try
            cn = New SqlConnection(my.Settings.CadConex)
            da.SelectCommand.Connection = cn
            cn.Open()
            da.Fill(ds)
            For cont = 0 To ds.Tables(0).Rows.Count - 1
                xx1 = ds.Tables(0).Rows(cont).Item("huella1")
                xx2 = ds.Tables(0).Rows(cont).Item("huella2")
                xx3 = ds.Tables(0).Rows(cont).Item("huella3")
                Dim i As Integer
                For i = 1 To 3
                    Select Case i
                        Case 1
                            tptref = xx1
                        Case 2
                            tptref = xx2
                        Case 3
                            tptref = xx3
                    End Select

                    If Not tptref Is Nothing Then
                        Dim tempTpt As Array = Array.CreateInstance(GetType(Byte), myUtil.template.Size)
                        Array.Copy(myUtil.template.tpt, tempTpt, myUtil.template.Size)

                        ret = myUtil.Verifica(tempTpt, tptref)

                        If ret < 0 Then
                            myUtil.WriteError(ret)
                        ElseIf ret = GRConstants.GR_NOT_MATCH Then
                            myUtil.WriteLog("Did not match with score = " & myUtil.SCORE)
                        Else
                            exito = True
                            Bloqueo = ds.Tables(0).Rows(cont).Item("Bloqueo").ToString
                            EstadoCuenta = ds.Tables(0).Rows(cont).Item("estado").ToString
                            FechaCaducidad = ds.Tables(0).Rows(cont).Item("FechaCaducidad").ToString
                            User_Id = ds.Tables(0).Rows(cont).Item("cve_Empleado").ToString
                            Usuario = ds.Tables(0).Rows(cont).Item("Id_Usuario").ToString
                            Pasword = ds.Tables(0).Rows(cont).Item("password").ToString
                            Nombre = ds.Tables(0).Rows(cont).Item("Nombre").ToString
                            Autorizar = ds.Tables(0).Rows(cont).Item("Autorizar").ToString
                            CveEmpresa = cmbEmpresas.SelectedValue
                            NombreEmpresa = cmbEmpresas.Text
                            cn.Close()
                            da.Dispose()
                            myUtil.WriteLog("Matched with score = " & myUtil.SCORE)
                            myUtil.PrintBiometricDisplay(True, GRConstants.GR_DEFAULT_CONTEXT)
                            Exit For
                        End If
                    End If
                Next
            Next
            cn.Close()
            da.Dispose()
        Catch err As Exception
            MessageBox.Show("Error al buscar al usuario")
            PictureBox2.Image = Nothing
            Me.txtUsuario.Text = ""
            Me.txtcontraseña.Text = ""
            btncancelar.Enabled = False
        End Try
        If exito Then
            If Date.Today <= (CDate(FechaCaducidad)) Then
                If Not Bloqueo Then
                    If EstadoCuenta = "Activo" Then
                        FrmSistema.Text = cmbEmpresas.Text
                        FrmSplash.Close()
                        Me.Hide()
                        myUtil.FinalizeGrFinger()
                        FrmSistema.ShowDialog()
                        Exit Sub
                    Else
                        MsgBox("Comunicate con tu administrador tu cuenta se encuentra inactiva", MsgBoxStyle.Exclamation)
                    End If
                Else
                    MsgBox("Comunicate con tu administrador, tu cuenta a sido bloqueda", MsgBoxStyle.Exclamation)
                End If
            Else
                MsgBox("Comunicate con tu administrador, tu contraseña a expirado", MsgBoxStyle.Exclamation)
            End If
            PictureBox2.Image = Nothing
            Me.txtUsuario.Text = ""
            Me.txtcontraseña.Text = ""
            btncancelar.Enabled = False
        Else
            MessageBox.Show("La huella no corresponde al usuario " & txtUsuario.Text)
        End If
    End Sub

    Private Sub BloqueaUsuarios()
        Dim cn As New SqlConnection(my.Settings.CadConex)
        Dim cm As New SqlCommand("update usuario set Bloqueo=1 where id_usuario='" & txtUsuario.Text & "'", cn)
        cn.Open()
        cm.ExecuteNonQuery()
        cm.Dispose()
        cn.Close()
        cn.Dispose()
    End Sub

    Public Sub CargaEmpresas()
        Dim cnEmpresas As New SqlConnection(My.Settings.CadConex)
        Dim cmEmpresas As New SqlCommand
        Dim daEmpresas As New SqlDataAdapter(cmEmpresas)
        Dim dsEmpresas As New DataSet
        '
        Try
            cnEmpresas.Open()
            cmEmpresas.Connection = cnEmpresas
            cmEmpresas.CommandType = CommandType.StoredProcedure
            cmEmpresas.CommandText = "spCargaEmpresas"
            daEmpresas.Fill(dsEmpresas, "Empresas")
            '
            cmbEmpresas.DataSource = dsEmpresas.Tables("Empresas").DefaultView
            cmbEmpresas.ValueMember = dsEmpresas.Tables("Empresas").Columns("CveEmpresa").ToString
            cmbEmpresas.DisplayMember = dsEmpresas.Tables("Empresas").Columns("NombreEmpresa").ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

    Private Sub txtnomusuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtcontraseña.Focus()
        End If
    End Sub

    Private Sub txtcontraseña_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcontraseña.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnIngresar_Click(sender, e)
        End If
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        myUtil.FinalizeGrFinger()
        End
    End Sub

    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        Try
            Dim cn As New SqlConnection(my.Settings.CadConex)
            Dim cm As New SqlCommand("select cve_Empleado, Nombre + ' ' + ape_pat + ' ' + ape_mat as Nombre, Id_Usuario, password, " & _
                "estado, Bloqueo, FechaCaducidad, Autorizar from usuario where id_usuario='" & txtUsuario.Text & "'", cn)
            Dim dr As SqlDataReader
            Dim Hash As New ClaseHash
            Dim FecCaduc As Date

            If Trim(txtUsuario.Text) <> "" Then
                If Trim(txtcontraseña.Text) <> "" Then
                    If Not IsNothing(cmbEmpresas.SelectedItem) Then
                        cn.Open()
                        dr = cm.ExecuteReader
                        If dr.Read Then
                            FecCaduc = dr("FechaCaducidad").ToString
                            If Date.Today <= FecCaduc Then
                                If CBool(dr("Bloqueo").ToString) = False Then
                                    If dr("estado").ToString.Trim = "Activo" Then
                                        If (txtUsuario.Text = dr("id_usuario").ToString) And Hash.verifyMd5Hash(txtcontraseña.Text, dr("password").ToString) Then
                                            User_Id = dr("cve_Empleado").ToString
                                            Usuario = dr("Id_Usuario").ToString
                                            Pasword = dr("password").ToString
                                            Nombre = dr("Nombre").ToString
                                            Autorizar = dr("Autorizar").ToString
                                            FrmSistema.Text = cmbEmpresas.Text
                                            CveEmpresa = cmbEmpresas.SelectedValue
                                            NombreEmpresa = cmbEmpresas.Text
                                            'FrmSplash.Close()
                                            myUtil.FinalizeGrFinger()
                                            Me.Hide()
                                            FrmSistema.ShowDialog()
                                            'Me.Close()
                                        Else
                                            Intento = Intento + 1
                                            MessageBox.Show("Password o Login Incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            MsgBox("Llevas: " & Intento & " intento(s) para accesar correctamente al sistema. Nota: Al tener 3 intentos se bloqueara el Usuario", MsgBoxStyle.Exclamation)
                                            If Intento = 3 Then
                                                MsgBox("Ultimo intento para acceder al sistema. Se ha Bloqueado el Usuario", MsgBoxStyle.Critical)
                                                BloqueaUsuarios()
                                                Me.Close()
                                            End If
                                        End If
                                    Else
                                        MsgBox("Comunicate con tu administrador, tu cuenta se encuentra inactiva", MsgBoxStyle.Exclamation)
                                    End If
                                Else
                                    MsgBox("Comunicate con tu administrador, tu cuenta a sido bloqueda", MsgBoxStyle.Exclamation)
                                End If
                            Else
                                MsgBox("Comunicate con tu administrador, la fecha de tu contraseña a caducado", MsgBoxStyle.Exclamation)
                            End If
                        Else
                            MessageBox.Show("¡Usuario incorrecto!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        dr.Close()
                        cm.Dispose()
                        cn.Close()
                        cn.Dispose()
                    Else
                        MsgBox("Indique Empresa", MsgBoxStyle.Exclamation, "Info100")
                    End If
                Else
                    MsgBox("Ingrese Contraseña", MsgBoxStyle.Exclamation, "Info100")
                End If
            Else
                MsgBox("Ingrese el Ususario", MsgBoxStyle.Exclamation, "Info100")
            End If
        Catch err As Exception
            MessageBox.Show("Ocurrio un error: " & err.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


    Private Sub frmLogin_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        myUtil.FinalizeGrFinger()
        End
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '*************APLICACION**********
        Try
            ''FrmSplash.Show()
            Intento = 0
            'arc = MsgBox("Formulario en Ingles?", MsgBoxStyle.YesNo)
            CargaEmpresas()

            'Activa lector de huella digital
            Dim err As Integer
            myUtil = New Util(ListBox1, PictureBox2, AxGrFingerXCtrl1)
            err = myUtil.InitializeGrFinger()

            If err < 0 Then
                myUtil.WriteError(err)
                Exit Sub
            Else
                myUtil.WriteLog("**Biométrica inicializadas**")
            End If

            Dim arc As Integer
            arc = 5
            If arc = 6 Then
                rm = ResourceManager.CreateFileBasedResourceManager("RecursosIngles", My.Application.Info.DirectoryPath, Nothing)
                cult = New CultureInfo("en-US")
                rm.GetStream("RecursosIngles")
            Else
                rm = ResourceManager.CreateFileBasedResourceManager("recursosspanish", My.Application.Info.DirectoryPath, Nothing)
                cult = New CultureInfo("es-ES")
                rm.GetStream("RecursosEspañol")
            End If
            'cult = New CultureInfo("en-US")
            lblusuario.Text = rm.GetString("lblnomusuario").ToString
            lblcontraseña.Text = rm.GetString("lblcontra").ToString
            lblEmpresa.Text = rm.GetString("lblempresa").ToString
            btnIngresar.Text = rm.GetString("Enter").ToString
            btncancelar.Text = rm.GetString("Cancel").ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class