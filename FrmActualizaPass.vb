Imports System.Data.SqlClient
Imports Microsoft.VisualBasic


Public Class FrmActualizaPass

    Public datosConfContraseña(0 To 5) As String
    Public passwordActual_ As String
    Public cve_empleado_ As String
    Public User_ As String
    Dim DiasRenova As Integer
    Dim Hash As New ClaseHash

    Public Property passworActual1_() As String
        Get
            Return passwordActual_
        End Get
        Set(ByVal value As String)
            passwordActual_ = value
        End Set
    End Property

    Public Property cve_empleado1_() As String
        Get
            Return cve_empleado_
        End Get
        Set(ByVal value As String)
            cve_empleado_ = value
        End Set
    End Property

    Public Property UserX_() As String
        Get
            Return User_
        End Get
        Set(ByVal value As String)
            User_ = value
        End Set
    End Property


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Hash.verifyMd5Hash(TextBox1.Text.ToString, passwordActual_) Then 'validamos que el pasword actual sea el correcto
            If TextBox3.Text.ToString.Equals(TextBox2.Text.ToString) Then 'validamos que el nuevo pasword sean iguales
                If ValidaComplejidadContrasena() Then 'si son iguales validamos la complpejidad
                    Dim newpass As String = ""
                    newpass = Hash.getMd5Hash(TextBox3.Text)
                    'If negocio.Validar_pass_historial(newpass, cve_empleado_, My.Settings.CadConex) Then 'verificamos que no se encuentre en el historial
                    '    MessageBox.Show("No se puede completar el cambio de Pasword, utilize una Pasword diferente")
                    'Else
                    '    MessageBox.Show("El cambio de Pasword ha sido completado, use su nuevo Pasword para entrar al Sistema")
                    '    Close()
                    '    FrmLogin.Enabled = True
                    'End If
                    Globales.ActualizaPass(cve_empleado_, newpass, DiasRenova, User_)
                    MessageBox.Show("El cambio de Pasword ha sido completado, use su nuevo Pasword para entrar al Sistema", "Cambio de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Close()
                    FrmLogin.Enabled = True
                End If
            Else
                MessageBox.Show("El Pasword nuevo no coincide", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("El password actual no coincide", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Function ValidaComplejidadContrasena() As Boolean
        Dim I, X, NumMayus, NumMinus, Num, Esp, AsciiX As Integer
        Dim Correcto As Boolean = False
        Dim Caracter As String = ""
        ' Estos datos deben ponerse en la Seguridad para definir la pol�tica de seguridad
        ' Se utilizar� un ALgoritmo de Encriptaci�n MD5 , el cual se utilizar� igualmente para otras labores
        ' MD5 es de un solo sentido. EL campo deber�pa guardarse como byte.
        ObtieneValoresComplejidadContrase()
        Dim longitudMinima As Integer = CInt(datosConfContraseña(0))
        Dim mayusculas As Integer = CInt(datosConfContraseña(2))
        Dim minusculas As Integer = CInt(datosConfContraseña(1))
        Dim numeros As Integer = CInt(datosConfContraseña(3))
        Dim especiales As Integer = CInt(datosConfContraseña(5))
        diasRenova = CInt(datosConfContraseña(4))

        If Len(TextBox3.Text) < longitudMinima Then
            MessageBox.Show("Error! La nueva contraseña no tiene la longitud minima.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            NumMayus = 0
            NumMinus = 0
            Num = 0
            Esp = 0
            X = 0
            For X = 0 To TextBox3.Text.Length - 1
                Caracter = TextBox3.Text.Substring(X, 1)
                AsciiX = Asc(Caracter)
                If mayusculas > 0 And (AsciiX >= 65 And AsciiX <= 90) Then
                    NumMayus += 1
                End If
                If minusculas > 0 And (AsciiX >= 97 And AsciiX <= 122) Then
                    NumMinus += 1
                End If
                If numeros > 0 And (AsciiX >= 48 And AsciiX <= 57) Then
                    Num += 1
                End If
                If especiales > 0 And (AsciiX >= 33 And AsciiX <= 47) Then
                    Esp += 1
                End If
                If especiales > 0 And (AsciiX >= 58 And AsciiX <= 64) Then
                    Esp += 1
                End If
            Next

            If ((NumMayus >= mayusculas) And (NumMinus >= minusculas) And (Num >= numeros) And (Esp >= especiales)) Then

                Return True
            Else
                MessageBox.Show("Error! La contraseña no cumple con los parametros de seguridad Establesidos." & vbCrLf & "(Como mínimo: 6, caracteres, 1 mayuscula, 1 minúscula, 1 número)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End If
    End Function

    Public Sub ObtieneValoresComplejidadContrase()
        Try
            Dim Cn As New SqlConnection(My.Settings.CadConex)
            Dim Cm As New SqlCommand("SELECT * FROM CONF_CONTRA", Cn)
            Dim Dr As SqlDataReader
            Cn.Open()
            Dr = Cm.ExecuteReader
            If Dr.Read Then
                datosConfContraseña(0) = Dr("LongMin").ToString
                datosConfContraseña(1) = Dr("Minusculas").ToString
                datosConfContraseña(2) = Dr("Mayusculas").ToString
                datosConfContraseña(3) = Dr("Numeros").ToString
                datosConfContraseña(4) = Dr("diasrenovacion").ToString
                'datosConfContraseña(5) = Dr("historial").ToString
                datosConfContraseña(5) = Dr("Especiales").ToString
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al cargar los valores", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    
End Class