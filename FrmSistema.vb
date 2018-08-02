Option Explicit On
Imports Microsoft.SqlServer
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Windows.Forms.Form
Imports System.IO

Public Class FrmSistema
    Inherits System.Windows.Forms.Form

    Private Sub FrmSistema_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        FrmSplash.Close()
        Me.Close()
    End Sub

    Private Sub FrmSistema_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MostrarSeguridad As Boolean = False
        Dim MostrarCredito As Boolean = False
        Dim MostrarTesoreria As Boolean = False
        Dim MostrarFactor As Boolean = False
        Dim MostrarArrenda As Boolean = False
        Dim MostrarCatalogos As Boolean = False
        Dim MostrarPromocion As Boolean = False
        Dim MostrarRiesgo As Boolean = False

        Try
            Dim cn As New SqlConnection(My.Settings.CadConex)
            Dim cm As New SqlCommand("SELECT USUARIOS_PERFILES.cve_empleado, USUARIOS_PERFILES.cve_perfil, USUARIOS_PERFILES.id_sistema, SISTEMA.nom_sistema FROM USUARIOS_PERFILES INNER JOIN SISTEMA ON USUARIOS_PERFILES.id_sistema = SISTEMA.id_sistema WHERE (cve_empleado = '" & User_Id & "') AND (CveEmpresa = '" & CveEmpresa & "')", cn)
            Dim dr As SqlDataReader
            cn.Open()
            dr = cm.ExecuteReader

            While dr.Read
                'MessageBox.Show(dr("nom_sistema").ToString.ToUpper)
                If dr("nom_sistema").ToString.ToUpper = "SEGURIDAD" Then
                    MostrarSeguridad = True
                End If

                'If dr("nom_sistema").ToString.ToUpper = "TESORERIA" Then
                '    MostrarTesoreria = True
                'End If

                'If dr("nom_sistema").ToString.ToUpper = "PROMOCION" Then
                '    MostrarPromocion = True
                'End If

                'If dr("nom_sistema").ToString.ToUpper = "RIESGO" Then
                '    MostrarRiesgo = True
                'End If

                If dr("nom_sistema").ToString.ToUpper = "CREDITO" Or dr("nom_sistema").ToString.ToUpper = "FINANCIERA" Then
                    MostrarCredito = True
                End If

                If dr("nom_sistema").ToString.ToUpper = "FACTORAJE" Or dr("nom_sistema").ToString.ToUpper = "FACTOR" Then
                    MostrarFactor = True
                End If

                If dr("nom_sistema").ToString.ToUpper = "ARRENDA" Then
                    MostrarArrenda = True
                End If

                'If dr("nom_sistema").ToString.ToUpper = "CATALOGOS" Then
                '    MostrarCatalogos = True
                'End If

            End While

            LblSeguridad.Visible = MostrarSeguridad
            LblCredito.Visible = MostrarCredito
            lblTesoreria.Visible = MostrarTesoreria
            lblFactor.Visible = MostrarFactor
            lblArrendamiento.Visible = MostrarArrenda
            LblCatalogos.Visible = MostrarCatalogos
            LblPromocion.Visible = MostrarPromocion
            LblRiesgo.Visible = MostrarRiesgo

            dr.Close()
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        Catch err As Exception
            MessageBox.Show("Ocurrio un error: " & err.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Salida_imagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
    End Sub

    Private Sub LblSeguridad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblSeguridad.Click
        Try
            CargaCadenasConexion("SEGURIDAD")
            Dim Modulo As New frmModulos
            Modulo.Text = Me.Text + "\SEGURIDAD"
            Modulo.Sistema = "SEGURIDAD"
            Modulo.ShowDialog()
        Catch ex As Exception
            MsgBox("Módulo no Disponible: " & ex.Message, MsgBoxStyle.Critical, "SEGURIDAD")
        End Try
    End Sub

    Private Sub LblSeguridad_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblSeguridad.MouseHover
        LblSeguridad.ForeColor = Color.SkyBlue
    End Sub

    Private Sub LblSeguridad_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblSeguridad.MouseLeave
        LblSeguridad.ForeColor = Color.Black
    End Sub

    Private Sub lblFactor_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblFactor.MouseHover
        lblFactor.ForeColor = Color.SkyBlue
    End Sub

    Private Sub lblFactor_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblFactor.MouseLeave
        lblFactor.ForeColor = Color.Black
    End Sub

    Private Sub lblFactor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFactor.Click
        Try
            CargaCadenasConexion("FACTORAJE")
            Dim Modulo As New frmModulos
            Modulo.Text = Me.Text + "\FACTORAJE"
            Modulo.Sistema = "FACTORAJE"
            Modulo.Sistema = "FACTOR"
            Modulo.ShowDialog()
        Catch ex As Exception
            MsgBox("Módulo no Disponible: " & ex.Message, MsgBoxStyle.Critical, "FACTOR")
        End Try
    End Sub

    Private Sub lblFinanciera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblArrendamiento.Click
        Try
            CargaCadenasConexion("FINANCIERA")
            Dim Modulo As New frmModulos
            Modulo.Text = Me.Text + "\FINANCIERA"
            Modulo.Sistema = "FINANCIERA"
            Modulo.ShowDialog()
        Catch ex As Exception
            MsgBox("Módulo no Disponible: " & ex.Message, MsgBoxStyle.Critical, "FINANCIERA")
        End Try
    End Sub

    Private Sub lblTesoreria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTesoreria.Click
        Try
            CargaCadenasConexion("TESORERIA")
            Dim Modulo As New frmModulos
            Modulo.Text = Me.Text + "\TESORERIA"
            Modulo.Sistema = "TESORERIA"
            Modulo.ShowDialog()
        Catch ex As Exception
            MsgBox("Módulo no Disponible: " & ex.Message, MsgBoxStyle.Critical, "TESORERIA")
        End Try
    End Sub

    Private Sub lblTesoreria_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTesoreria.MouseHover
        lblTesoreria.ForeColor = Color.SkyBlue
    End Sub

    Private Sub lblTesoreria_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTesoreria.MouseLeave
        lblTesoreria.ForeColor = Color.Black
    End Sub

    Private Sub LblCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblCredito.Click
        Try
            CargaCadenasConexion("FINANCIERA")
            Dim Modulo As New frmModulos
            Modulo.Text = Me.Text + "\FINANCIERA"
            Modulo.Sistema = "FINANCIERA"
            Modulo.ShowDialog()
        Catch ex As Exception
            MsgBox("Módulo no Disponible: " & ex.Message, MsgBoxStyle.Critical, "FINANCIERA")
        End Try
    End Sub

    Private Sub LblCatalogos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblCatalogos.Click

    End Sub

    Private Sub LblCatalogos_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblCatalogos.MouseHover
        LblCatalogos.ForeColor = Color.SkyBlue
    End Sub

    Private Sub LblCredito_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblCredito.MouseHover
        LblCredito.ForeColor = Color.SkyBlue
    End Sub

    Private Sub LblCatalogos_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblCatalogos.MouseLeave
        LblCatalogos.ForeColor = Color.Black
    End Sub

    Private Sub LblCredito_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblCredito.MouseLeave
        LblCredito.ForeColor = Color.Black
    End Sub

    Private Sub lblFinanciera_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblArrendamiento.MouseHover
        lblArrendamiento.ForeColor = Color.SkyBlue
    End Sub

    Private Sub lblFinanciera_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblArrendamiento.MouseLeave
        lblArrendamiento.ForeColor = Color.Black
    End Sub

    Private Sub LblPromocion_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblPromocion.MouseHover
        LblPromocion.ForeColor = Color.SkyBlue
    End Sub

    Private Sub LblRiesgo_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblRiesgo.MouseHover
        LblRiesgo.ForeColor = Color.SkyBlue
    End Sub

    Private Sub LblRiesgo_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblRiesgo.MouseLeave
        LblRiesgo.ForeColor = Color.Black
    End Sub

    Private Sub LblPromocion_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblPromocion.MouseLeave
        LblPromocion.ForeColor = Color.Black
    End Sub

    Private Sub LblPromocion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblPromocion.Click
        Try
            CargaCadenasConexion("SEGURIDAD")
            Dim Modulo As New frmModulos
            Modulo.Text = Me.Text + "\PROMOCION"
            Modulo.Sistema = "PROMOCION"
            Modulo.ShowDialog()
        Catch ex As Exception
            MsgBox("Módulo no Disponible: " & ex.Message, MsgBoxStyle.Critical, "PROMOCION")
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Dim inactiveTime = GetInactiveTime()
        'If (inactiveTime Is Nothing) Then
        '    Me.Text = "Desconocido"
        '    Me.BackColor = Color.Yellow
        'ElseIf (inactiveTime.Totalminutes > 5) Then
        '    'Me.Text = String.Format("Inactivo por {0}segundos", inactiveTime.TotalSeconds)
        '    'Me.BackColor = Color.Red
        Application.Exit()
        'Else
        '    'Me.Text = "Aplicacion Activa"
        '    'Me.BackColor = Color.Green
        '    Label1.Text = String.Format("Inactivo por {0}segundos", inactiveTime.TotalSeconds)
        'End If
    End Sub
End Class