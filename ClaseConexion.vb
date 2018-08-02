Imports System
Imports Microsoft.Win32
Imports Microsoft.VisualBasic
Imports Microsoft.SqlServer
Imports System.Data.SqlClient
Imports System.IO
Imports System.Globalization
Imports System.Resources
Imports System.Threading
Imports System.Xml

Module ClaseConexion

#Region "Variables Publicas"
    Public cult As CultureInfo
    Public rm As ResourceManager
    Public ConexionPrincipal As String
    Public Intento As Integer
    Public cnAgil As SqlConnection
    Public cm As New SqlCommand
    Public ii As Integer
    Public i As Integer
    Public Ruta As String
    Public Archivo As String
    Public User_Id, Usuario, Pasword, Nombre As String
    Public Autorizar As Boolean
    Public CadenaConexion As String
    Public CveEmpresa As String
    Public NombreEmpresa As String
    Public ConexionSistema As String

    Dim vServer As String
    Dim vBd As String
    Dim vUser As String
    Dim vPasword As String
#End Region

    Public Sub CargaCadenasConexion(ByVal IdSistema As String)
        Dim cnCargaDatosSistema As New SqlConnection(My.Settings.CadConex)
        Dim cmCargaDatosSistema As New SqlCommand
        Dim prCargaDatosSistema As SqlParameter = Nothing
        Dim drCargaDatosSistema As SqlDataReader
        Try

            ' graba(pasadatos)

            cnCargaDatosSistema.Open()
            cmCargaDatosSistema.Connection = cnCargaDatosSistema
            cmCargaDatosSistema.CommandType = CommandType.StoredProcedure
            cmCargaDatosSistema.CommandText = "spCargaCadenasSistema"
            '
            prCargaDatosSistema = New SqlParameter("@Sistema", SqlDbType.VarChar, 10)
            prCargaDatosSistema.Value = IdSistema
            cmCargaDatosSistema.Parameters.Add(prCargaDatosSistema)
            prCargaDatosSistema = New SqlParameter("@Empresa", SqlDbType.VarChar, 10)
            prCargaDatosSistema.Value = CveEmpresa
            cmCargaDatosSistema.Parameters.Add(prCargaDatosSistema)
            '
            Registry.CurrentUser.DeleteSubKey("Software\INFO100\" & IdSistema, False)
            Dim rk As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\INFO100\" & IdSistema)
            rk.SetValue("cveUsuario", User_Id)
            rk.SetValue("Nombre", Nombre)
            rk.SetValue("Usuario", Usuario)
            rk.SetValue("Contrasena", Pasword)



            drCargaDatosSistema = cmCargaDatosSistema.ExecuteReader
            While drCargaDatosSistema.Read
                If drCargaDatosSistema("nom_sistema").ToString.ToUpper = IdSistema Then
                    'Ruta = drCargaDatosSistema("RutaAplicacion").ToString
                    rk.SetValue("CveEmpresa", CveEmpresa)
                    rk.SetValue("NombreEmpresa", NombreEmpresa)
                    rk.SetValue("Autorizar", Autorizar)
                    rk.SetValue("CveSistema", drCargaDatosSistema("idSistema").ToString)
                End If
                If drCargaDatosSistema("CadenaGlobal").ToString = "" Then
                    CadenaConexion = "Data Source=" & drCargaDatosSistema("Servidor").ToString & _
                        ";Initial Catalog=" & drCargaDatosSistema("BaseDatos").ToString & _
                        ";Persist Security Info=True;User ID=" & Usuario & _
                        ";Password=" & Pasword
                    rk.SetValue(drCargaDatosSistema("NombreCadena").ToString, CadenaConexion)
                Else
                    rk.SetValue(drCargaDatosSistema("NombreCadena").ToString, drCargaDatosSistema("CadenaGlobal").ToString)
                End If
            End While
            drCargaDatosSistema.Close()
            cmCargaDatosSistema.Dispose()
            cnCargaDatosSistema.Close()
            cnCargaDatosSistema.Dispose()
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error: " & ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Function CargaModulos(ByVal IdSistema As String, ByVal Modulo As String) As String
        Dim cnCargaModulos As New SqlConnection(My.Settings.CadConex)
        Dim cmCargaModulos As New SqlCommand
        Dim prCargaModulos As SqlParameter = Nothing
        Dim drCargaModulos As SqlDataReader


        Try
            cnCargaModulos.Open()
            cmCargaModulos.Connection = cnCargaModulos
            cmCargaModulos.CommandType = CommandType.StoredProcedure
            cmCargaModulos.CommandText = "spCargaModulos"
            '
            prCargaModulos = New SqlParameter("@Sistema", SqlDbType.VarChar, 50)
            prCargaModulos.Value = IdSistema
            cmCargaModulos.Parameters.Add(prCargaModulos)
            prCargaModulos = New SqlParameter("@Modulo", SqlDbType.VarChar, 50)
            prCargaModulos.Value = Modulo
            cmCargaModulos.Parameters.Add(prCargaModulos)
            '
            drCargaModulos = cmCargaModulos.ExecuteReader
            If drCargaModulos.Read Then
                CargaModulos = drCargaModulos("RutaAplicacion").ToString.Trim
            Else
                CargaModulos = Nothing
            End If
            drCargaModulos.Close()
            cmCargaModulos.Dispose()
            cnCargaModulos.Close()
            cnCargaModulos.Dispose()
            'If IdSistema = UCase("FACTOR") Then
            '    If Modulo = "CATALOGOS" Or IdSistema = "Val2" Or IdSistema = "Val2" Then
            '        CargaModulos = "\\server-raid\Factor100\CATALOGOS.lnk"
            '    End If
            'End If
            Return CargaModulos
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error: " & ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return Nothing
        End Try

    End Function

End Module
