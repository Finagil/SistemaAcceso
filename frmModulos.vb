Option Explicit On
Imports Microsoft.SqlServer
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Windows.Forms.Form
Imports System.IO
Imports SistemaAcceso.Utilidades

Public Class frmModulos
    Dim MostrarSeguridad As Boolean = False
    Dim MostrarCP As Boolean = False
    Private lblModulo As ArrayControles(Of Label)
    Public Sistema As String

#Region "Funciones"

    Private Sub asignarEventos()
        For Each lbl As Label In lblModulo
            ' Para el evento general de recibir foco
            AddHandler lbl.MouseHover, AddressOf lblModulo_MouseHover
            AddHandler lbl.MouseLeave, AddressOf lblModulo_MouseLeave
            AddHandler lbl.Click, AddressOf lblModulo_Click
        Next
    End Sub

#End Region

    Private Sub FrmSistema_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.Close()
    End Sub

    Private Sub frmModulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblModulo = New ArrayControles(Of Label)("lblModulo", Me)
        asignarEventos()
        Try
            Dim index As Integer = 0
            Dim cn As New SqlConnection(My.Settings.CadConex)
            Dim cm As New SqlCommand
            Dim pr As SqlParameter
            Dim dr As SqlDataReader
            cn.Open()
            cm.Connection = cn
            cm.CommandText = "spCargaModulosAccesos"
            cm.CommandType = CommandType.StoredProcedure
            pr = New SqlParameter("@Sistema", SqlDbType.VarChar, 50)
            ' Sistema = "FACTOR"
            pr.Value = Sistema.ToUpper
            cm.Parameters.Add(pr)
            pr = New SqlParameter("@CveUsuario", SqlDbType.VarChar, 15)
            pr.Value = User_Id
            cm.Parameters.Add(pr)
            'pr = New SqlParameter("@CveEmpresa", SqlDbType.VarChar, 10)
            'pr.Value = Trim(CveEmpresa)
            'cm.Parameters.Add(pr)

            dr = cm.ExecuteReader
            While dr.Read
                lblModulo(index).Text = dr("modulo").ToString.Trim
                index += 1
            End While
            Dim v As Integer = 16
            While Not v = index
                lblModulo(v - 1).Visible = False
                v = v - 1
            End While
            dr.Close()
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        Catch err As Exception
            MessageBox.Show("Ocurrio un error: " & err.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Salida_imagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Salida_imagen.Click
        Me.Dispose()
    End Sub

    Private Sub Salida_imagen_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Salida_imagen.MouseHover
        Salida_imagen.Image = Salida_imagen2.Image
    End Sub

    Private Sub lblModulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim index As Integer = lblModulo.Index(sender)
            Dim x As String
            Dim s As String
            Dim Modulo As String()

            s = lblModulo(index).Text
            Modulo = s.Split(" ")
            x = CargaModulos(Sistema, Modulo(0))

            If Sistema = UCase("FACTOR") Then

                Select Case Modulo(0)
                    Case Is = "CATALOGOS", "ADQUISICION", "COBRANZA", "TESORERIA.", "TESORERIA", "CREDITO", "REPORTES", "CONTABILIDAD", "FONDEO"
                        Process.Start(x, "FACTOR.TXT ; 15 ")
                    Case Else
                        Dim pwd As New Security.SecureString()
                        pwd.AppendChar("s")
                        pwd.AppendChar("i")
                        pwd.AppendChar("s")
                        pwd.AppendChar("t")
                        pwd.AppendChar("e")
                        pwd.AppendChar("m")
                        pwd.AppendChar("a")
                        pwd.AppendChar("s")
                        Process.Start(x, "sistemas", pwd, "AGIL")
                End Select
            Else
                Process.Start(x, "Finagil")
            End If

            Me.Close()
        Catch ex As Exception
            MsgBox("Módulo no Disponible: " & ex.Message, MsgBoxStyle.Critical, "Seguridad")
        End Try
    End Sub

    Private Sub lblModulo_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim index As Integer = lblModulo.Index(sender)
        lblModulo(index).ForeColor = Color.SkyBlue
    End Sub

    Private Sub lblModulo_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim index As Integer = lblModulo.Index(sender)
        lblModulo(index).ForeColor = Color.SteelBlue
    End Sub

    Private Sub Salida_imagen_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Salida_imagen.MouseLeave
        Salida_imagen.Image = Salida_imagen3.Image
    End Sub

    Private Sub LbAgil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub lblModulos_15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblModulos_15.Click

    End Sub

    Private Sub lblModulo_0_Click(sender As Object, e As EventArgs) Handles lblModulo_0.Click

    End Sub
End Class