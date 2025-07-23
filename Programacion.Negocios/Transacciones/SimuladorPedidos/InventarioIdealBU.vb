Imports System.Data.OleDb
Imports Programacion.Datos

Public Class InventarioIdealBU
    Public Function obtenerHojasExcel(ByVal rutaExcel As String) As List(Of String)
        Dim vInventarioIdeal As New InventarioIdealDA
        Dim tablas As New DataTable
        Dim listSheet As New List(Of String)
        Dim drSheet As DataRow
        tablas = vInventarioIdeal.obtenerHojasExcel(rutaExcel)
        For Each drSheet In tablas.Rows
            If drSheet("TABLE_NAME").ToString().Contains("$") Then
                listSheet.Add(drSheet("TABLE_NAME").ToString())
            End If
        Next
        Return listSheet
    End Function
    Public Sub InicializarTablaExcel()
        Dim vInventarioIdeal As New InventarioIdealDA
        vInventarioIdeal.InicializarTablaExcel()
    End Sub

    Public Function obtenerDatosHojaExcel(ByVal rutaExcel As String, ByVal hoja As String) As DataTable
        Dim vInventarioIdeal As New InventarioIdealDA
        Dim tabla As New DataTable
        tabla = vInventarioIdeal.obtenerDatosHojaExcel(rutaExcel, hoja)
        Return tabla
    End Function

    Public Sub InsertarExcel(obj As Entidades.InventarioIdeal)
        Dim vInventarioIdeal As New InventarioIdealDA
        vInventarioIdeal.InsertarExcel(obj)
    End Sub
    Public Function obtenerDatosInventarioIdeal() As DataTable
        Dim vInventarioIdeal As New InventarioIdealDA
        Return vInventarioIdeal.obtenerDatosInventarioIdeal
    End Function
End Class
