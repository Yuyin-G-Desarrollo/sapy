Imports Programacion.Datos

Public Class BitacoraImportacionBU
    Public Function Agregar(tipo As String, nota As String) As Int32
        Dim vBitacoras As New BitacoraImportacionDA
        Return vBitacoras.Agregar(tipo, nota)
    End Function
    Public Function Tabla() As DataTable
        Dim vBitacoras As New BitacoraImportacionDA
        Return vBitacoras.Tabla()
    End Function
End Class
