Option Explicit On
Imports Microsoft.SqlServer
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Windows.Forms.Form
Public Class FrmSplash

    Private Sub FrmSplash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' cADENA DE CONEXION PARA LEER SEGURIDAD MAESTRA CON LAS OPCIONES DE MENU
        '' Declarar variables de conexion ADO.net
        'Dim command2 As New SqlCommand()
        'Dim DaNombreEmpresa As SqlDataAdapter
        'Dim DatoSet As New DataSet
        'Dim ds1 As SqlDataReader
        ''Dim conect As New SqlConnection(my.Settings.CadConex)
        ''With command2
        ''.CommandType = CommandType.StoredProcedure
        '' .CommandText = "CargaDatosEmpresa"
        ''.Connection = conect
        ''End With
        '' leer datos de un registro especifico
        ''DaNombreEmpresa = New SqlDataAdapter(command2)
        ''DaNombreEmpresa.Fill(DatoSet, "EP_NOMBRE1")
        ''conect.Open()
        ''ds1 = command2.ExecuteReader
        ''While ds1.Read
        ''    Label2.Text = ds1(0) ' Lee el dato del nombre de la empesa
        ''End While

        'Dim imagen As Image
        '    Label2.Text = ds1(0) ' Lee el dato del nombre de la empesa
        'imagen = Image.FromFile(My.Application.Info.DirectoryPath + "\fondo_empresa.jpg")
        'Me.BackgroundImage = imagen
        Label1.Text = "Autorizado a:"
        Label2.Text = "Finagil S.A. de C.V. E.N.R."
        Label3.Text = ""
        Label4.Text = "Finagil"
        Label5.Text = "Derechos Reservados"
        Label6.Text = "CopyRight 2016"

    End Sub

    Private Sub FrmSplash_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        FrmLogin.ShowDialog()

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    
End Class