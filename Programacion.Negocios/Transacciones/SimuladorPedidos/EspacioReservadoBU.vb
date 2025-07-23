Imports Programacion.Datos

Public Class EspacioReservadoBU
    Public Function TablaFechas(inicio As Date, final As Date, activos As Boolean, cancelados As Boolean, simulados As Boolean, asignado As Boolean, fechas As Boolean, especiales As Boolean) As DataTable
        Dim vEspacioReservadoDa As New EspacioReservadoDA
        Return vEspacioReservadoDa.TablaFechas(inicio, final, activos, cancelados, simulados, asignado, fechas, especiales)
    End Function

    Public Function obtenerClientes(ByVal especiales As Boolean) As DataTable
        Dim vEspacioReservadoDa As New EspacioReservadoDA
        Return vEspacioReservadoDa.obtenerClientes(especiales)
    End Function

    Public Sub Agregar(clieID As Int32, fecha As Date, pares As Int32, linpID As Int32)
        Dim vEspacioReservadoDa As New EspacioReservadoDA
        vEspacioReservadoDa.Agregar(clieID, fecha, pares, linpID)
    End Sub
    Public Sub CambiarFecha(espaID As Int32, Fecha As Date)
        Dim vEspacioReservadoDa As New EspacioReservadoDA
        vEspacioReservadoDa.CambiarFecha(espaID, Fecha)
    End Sub
    Public Sub CambiarEstatus(espaID As Int32, Estatus As String)
        Dim vEspacioReservadoDa As New EspacioReservadoDA
        vEspacioReservadoDa.CambiarEstatus(espaID, Estatus)
    End Sub
End Class
