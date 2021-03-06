﻿Imports System.Runtime.InteropServices
Module Globales
    Public Structure LASTINPUTINFO
        Public cbSize As UInteger
        Public dwTime As UInteger
    End Structure

    <DllImport("User32.dll")> _
    Private Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    End Function

    Public Function GetInactiveTime() As Nullable(Of TimeSpan)
        Dim info As LASTINPUTINFO = New LASTINPUTINFO
        info.cbSize = CUInt(Marshal.SizeOf(info))
        If (GetLastInputInfo(info)) Then
            Return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime)
        Else
            Return Nothing
        End If
    End Function

    Public Sub ActualizaPass(id_empleado As String, PassHash As String, DiasCaduca As Integer, User As String)
        Dim cn As New System.Data.SqlClient.SqlConnection(My.Settings.CadConex)
        Dim fecha As Date = Date.Now.AddDays(DiasCaduca)
        Dim cm As New System.Data.SqlClient.SqlCommand("update usuario set password = '" & PassHash & "', fechaCaducidad = '" & fecha.ToString("MM/dd/yyyy") & "' where cve_empleado = '" & id_empleado & "'", cn)
        'Dim cm1 As New System.Data.SqlClient.SqlCommand("ALTER LOGIN " & User & " WITH PASSWORD = '" & PassHash & "';", cn)
        cn.Open()
        cm.ExecuteNonQuery()
        'cm1.ExecuteNonQuery()
        cn.Close()
    End Sub

    Public Sub ObtenerDATOSEmpleado(usuario As String, ByRef datos_emlpeado() As String)
        Dim cn As New System.Data.SqlClient.SqlConnection(My.Settings.CadConex)
        Dim cm As New System.Data.SqlClient.SqlCommand("Select cve_empleado, password from USUARIO where id_usuario = '" & usuario & "'", cn)
        cn.Open()
        Dim dt As SqlClient.SqlDataReader
        dt = cm.ExecuteReader()
        While (dt.Read())
            datos_emlpeado(0) = dt(0)
            datos_emlpeado(1) = dt(1)
        End While
        cn.Close()
    End Sub

End Module
