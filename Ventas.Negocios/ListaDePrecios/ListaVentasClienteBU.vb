Public Class ListaVentasClienteBU

    Public Function consultaListaVentasClienteLV(ByVal idListaBase As Int32,
                                                 ByVal idListaPreciosVenta As Int32,
                                                 ByVal filtrarActivo As Boolean,
                                                 ByVal clienteActivo As Boolean) As DataTable
        Dim objLVCDA As New Datos.ListaVentasClienteDA
        Return objLVCDA.consultaListaVentasClienteLV(idListaBase, idListaPreciosVenta, filtrarActivo, clienteActivo)
    End Function

    Public Function consultaListasVentasClientePrecios(ByVal idListaBase As Int32, ByVal idListaVentas As Int32,
                                                       ByVal idCliente As Int32, ByVal idEstatus As Int32,
                                                       ByVal siLigar As Boolean, ByVal noLigar As Boolean) As DataTable
        Dim objLVCDA As New Datos.ListaVentasClienteDA
        Return objLVCDA.consultaListasVentasClientePrecios(idListaBase, idListaVentas, idCliente, idEstatus, siLigar, noLigar)
    End Function

    Public Function consultaIVAconf(ByVal idListaVentas As Int32) As DataTable
        Dim objLVCDA As New Datos.ListaVentasClienteDA
        Return objLVCDA.consultaIVAconf(idListaVentas)
    End Function

    Public Function consultaFleteconf(ByVal idListaVentas As Int32) As DataTable
        Dim objLVCDA As New Datos.ListaVentasClienteDA
        Return objLVCDA.consultaFleteconf(idListaVentas)
    End Function


End Class

