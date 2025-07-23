Public Class FiltroParametrosCobranzaBU

    Public Function ListadoParametroProyeccionEntregas(tipo_busqueda As Integer, ColaboradorID As Integer, TipoPerfil As Integer) As DataTable
        Dim objDA As New Datos.FiltroParametrosCobranzaDA
        Dim tabla As New DataTable
        tabla = objDA.ListadoParametroProyeccionEntregas(tipo_busqueda, ColaboradorID, TipoPerfil)
        Return tabla
    End Function
    Public Function listadoParametrosReceptorNotasCredito(ByVal clienteId As String, ByVal tipoNC As String) As DataTable
        Dim objDA As New Datos.FiltroParametrosCobranzaDA
        Dim tabla As New DataTable
        tabla = objDA.listadoParametrosNotasCredito(clienteId, tipoNC)
        Return tabla
    End Function
End Class
