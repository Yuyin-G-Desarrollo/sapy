Imports Produccion.Datos

Public Class ListaFraccionesporNaveBU
    Public Function ObtenerInformacionFracciones(ByVal Naveid As String, ByVal marcaId As String, ByVal coleccionId As String, ByVal Estatus As String, ByVal naves As String) As DataTable
        Dim obj As New listaFraccionesDA
        Return obj.ListaFraccionesporNave(Naveid, marcaId, coleccionId, Estatus, naves)
    End Function
End Class
