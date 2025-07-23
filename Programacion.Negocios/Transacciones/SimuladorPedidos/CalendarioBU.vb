Imports Programacion.Datos

Public Class CalendarioBU
    Public Function TablaAños() As DataTable
        Dim vCalendarioDa As New CalendarioDA
        Return vCalendarioDa.TablaAños
    End Function

    Public Function TablaSemanas() As DataTable
        Dim vCalendarioDa As New CalendarioDA
        Return vCalendarioDa.TablaSemanas
    End Function

    Public Function TablaNaveAño(naveID As Int32, Año As Int32) As DataTable
        Dim vCalendarioDa As New CalendarioDA
        Return vCalendarioDa.TablaNaveAño(naveID, Año)
    End Function
    Public Function verificarAniosNave(naveID As Int32, Año As Int32) As Boolean
        Dim vCalendarioDa As New CalendarioDA
        Dim tabla As DataTable
        tabla = vCalendarioDa.TablaNaveAño(naveID, Año)
        If tabla.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function
    Public Sub agregarAnioCalendario(ByVal nave As Integer, ByVal fechaInicio As Date, ByVal fechaFin As Date)
        Dim vCalendarioDa As New CalendarioDA
        vCalendarioDa.agregarAnioCalendario(nave, fechaInicio, fechaFin)
    End Sub
    Public Sub actualizarDia(ByVal dia As String, ByVal fecha As Date, ByVal nave As Integer)
        Dim vCalendarioDa As New CalendarioDA
        vCalendarioDa.actualizarDia(dia, fecha, nave)
    End Sub
    Public Sub actualizarDiaNaves(ByVal dia As String, ByVal fecha As Date)
        Dim vCalendarioDa As New CAlendarioDA
        vCalendarioDa.actualizarDiaNaves(dia, fecha)
    End Sub
End Class
