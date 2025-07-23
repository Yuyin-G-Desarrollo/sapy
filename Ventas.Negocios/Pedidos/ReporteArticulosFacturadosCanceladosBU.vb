Public Class ReporteArticulosFacturadosCanceladosBU
    Dim objDA As New Datos.ReporteArticulosFacturadosCanceladosDA

    Public Function ConsultarArticulosFacturadosCancelados(
        buscarPorFecha As Boolean,
        fechaInicio As Date,
        fechaFin As Date,
        pedidoSAY As String,
        pedidoSICY As String,
        cliente As String,
        rFC As String,
        nave As String) As DataTable

        Dim dt As DataTable
        objDA = New Datos.ReporteArticulosFacturadosCanceladosDA

        dt = objDA.ConsultarArticulosFacturadosCancelados(buscarPorFecha, fechaInicio, fechaFin, pedidoSAY, pedidoSICY, cliente, rFC, nave)

        Return dt
    End Function

End Class
