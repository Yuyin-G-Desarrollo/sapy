Public Class FolioCancelacionBU

    Private objDA As Datos.FolioCancelacionDA

    Public Function ConsultarFoliosCancelacion(
        buscarPorFecha As Boolean,
        fechaInicio As DateTime,
        fechaFin As DateTime,
        estatusPedido As String,
        pedidosSay As String,
        pedidosSicy As String,
        clientes As String
    ) As DataTable

        Dim dt As DataTable
        objDA = New Datos.FolioCancelacionDA

        dt = objDA.ConsultarFoliosCancelacion(buscarPorFecha, fechaInicio, fechaFin, estatusPedido, pedidosSay, pedidosSicy, clientes)
        Return dt
    End Function

    Public Function ConsultarFoliosDetalle(foliosCancelacion As String) As DataTable

        Dim dt As DataTable
        objDA = New Datos.FolioCancelacionDA

        dt = objDA.ConsultarFoliosDetalle(foliosCancelacion)
        Return dt
    End Function

End Class
