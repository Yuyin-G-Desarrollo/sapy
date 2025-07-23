Imports Ventas.Datos

Public Class ListaVentasBU
    Public Function tipoIva(ByVal accion As String, ByVal idlistaventas As Int32) As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.tipoIva(accion, idlistaventas)
    End Function

    Public Function tipoFlete(ByVal idListaVentas As Int32) As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.tipoFlete(idListaVentas)
    End Function

    Public Function tipoFlete(ByVal accion As String, ByVal idlistaventas As Int32) As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.tipoFlete(accion, idlistaventas)
    End Function

    Public Function listaClienteVentasSelect(ByVal descuentoInicio As String, ByVal descuentoFin As String,
                                         ByVal facturacionInicio As String, ByVal facturacionFin As String,
                                         ByVal tipoIva As String, ByVal tipoFlete As String, ByVal idlistabase As Int32) As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.listaClienteVentasSelect(descuentoInicio, descuentoFin,
                                                 facturacionInicio, facturacionFin,
                                                 tipoIva, tipoFlete, idlistabase)
    End Function

    Public Function comprobarDigitoListaVenta(ByVal idListaBase As Int32, ByVal codigoLista As String, ByVal idListaVentas As Int32, ByVal accion As String) As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.comprobarDigitoListaVenta(idListaBase, codigoLista, idListaVentas, accion)
    End Function

    Public Function registrarDatosListaVentas(ByVal listapreciosbaseid As Int32, ByVal codigolistaventa As String, ByVal descripcion As String,
       ByVal incrementoporpar As String, ByVal porcentaje As Boolean, ByVal vigenciainicio As String,
       ByVal vigenciafin As String, ByVal facturacioninicio As String, ByVal facturacionfin As String,
       ByVal descuentoinicio As String, ByVal descuentofin As String, ByVal evento As Int32) As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.registrarDatosListaVentas(listapreciosbaseid, codigolistaventa, descripcion,
        incrementoporpar, porcentaje, vigenciainicio,
        vigenciafin, facturacioninicio, facturacionfin,
        descuentoinicio, descuentofin, evento)
    End Function

    Public Function consultaListaVentas(ByVal idListaBase As Int32) As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.consultaListaVentas(idListaBase)
    End Function

    Public Function consutaListaVentasDetalle(ByVal idListaVentas As Int32) As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.consutaListaVentasDetalle(idListaVentas)
    End Function

    Public Function consultaListaVentaClientes(ByVal idlistaVentas As Int32) As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.consultaListaVentaClientes(idlistaVentas)
    End Function

    Public Function consultaListaVentaMasClientes(ByVal idlistaVentas As Int32,
                                                 ByVal descuentoInicio As String, ByVal descuentoFin As String,
                                            ByVal facturacionInicio As String, ByVal facturacionFin As String,
                                            ByVal tipoIva As String, ByVal tipoFlete As String,
                                            ByVal idListaBaseid As Int32)
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.consultaListaVentaMasClientes(idlistaVentas, descuentoInicio, descuentoFin,
                                                 facturacionInicio, facturacionFin,
                                                 tipoIva, tipoFlete, idListaBaseid)
    End Function

    Public Function consultaListaVentaTemporal(ByVal idListaBase As Int32, ByVal idEstatus As Int32) As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.consultaListaVentaTemporal(idListaBase, idEstatus)
    End Function

    Public Function consultaFletes(ByVal fletes As String) As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.consultaFletes(fletes)
    End Function

    Public Function consultaDescuentos() As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.consultaDescuentos()
    End Function

    Public Function consultaClienteFleteCambioConf(ByVal fleteQuitar As String, ByVal fletes As String, ByVal idListaCliente As Int32)
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.consultaClienteFleteCambioConf(fleteQuitar, fletes, idListaCliente)
    End Function

    Public Function verDatosConfiguradosListaClienteActiva(ByVal idCliente As Int32, ByVal idListaVentas As Int32) As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.verDatosConfiguradosListaClienteActiva(idCliente, idListaVentas)
    End Function

    Public Function consultaListasVentaLB(ByVal idListaBase As Int32) As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.consultaListasVentaLB(idListaBase)
    End Function

    'Public Function verListaVentasConsultaSimple(ByVal idListaBase As Int32) As DataTable
    '    Dim objLVDA As New ListaVentasDA
    '    Return objLVDA.verListaVentasConsultaSimple(idListaBase)
    'End Function

    'Public Function consultaIVAConfiguradoCliente(ByVal idCliente As Int32) As String
    '    Dim objLVDA As New ListaVentasDA
    '    Return objLVDA.consultaIVAConfiguradoCliente(idCliente)
    'End Function

    'Public Function consultaFacturacionConfiguracionCliente(ByVal idCliente As Int32) As DataTable
    '    Dim objLVDA As New ListaVentasDA
    '    Return objLVDA.consultaFacturacionConfiguracionCliente(idCliente)
    'End Function

    Public Function consultaListaVentasClienteSimple() As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.consultaListaVentasClienteSimple()
    End Function

    'Public Function consultaFletesConfiguracionCliente(ByVal idCliente As Int32) As DataTable
    '    Dim objLVDA As New ListaVentasDA
    '    Return objLVDA.consultaFletesConfiguracionCliente(idCliente)
    'End Function

    Public Function consultaDescuentosConfiguracionCliente(ByVal idCliente As Int32, ByVal idListaVentas As Int32) As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.consultaDescuentosConfiguracionCliente(idCliente, idListaVentas)
    End Function

    Public Function consultaEventos() As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.consultaEventos
    End Function

    Public Function validarListaVentasEvento(ByVal idListaBase As Int32, ByVal idEvento As Int32) As Int32
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.validarListaVentasEvento(idListaBase, idEvento)
    End Function

    '{---------------------------------------- Consultas --------------------------------------}'
    '{-----------------------------------------------------------------------------------------}'
    '{----------------------------------------- Acciones --------------------------------------}'

    Public Sub registrarIvaFlete(ByVal idListaVentasid As Int32, ByVal idCatalogo As Int32, ByVal catalogo As String)
        Dim objLVDA As New ListaVentasDA
        objLVDA.registrarIvaFlete(idListaVentasid, idCatalogo, catalogo)
    End Sub

    Public Sub registrarClienteListaVentas(ByVal listaVentasid As Int32, ByVal clienteid As Int32, ByVal listabase As Int32)
        Dim objLVDA As New ListaVentasDA
        objLVDA.registrarClienteListaVentas(listaVentasid, clienteid, listabase)
    End Sub

    ' ''Public Sub guardarDescripcionListaCliente(ByVal idlistaventascliente As Int32, ByVal descripcion As String)
    ' ''    Dim objLVDA As New ListaVentasDA
    ' ''    objLVDA.guardarDescripcionListaCliente(idlistaventascliente, descripcion)
    ' ''End Sub

    Public Sub guardarClienteConfiguraionListaActiva(ByVal idListaVentas As Int32, ByVal idCliente As Int32,
                                                     ByVal idCat As Int32, ByVal cantidad As Double,
                                                     ByVal accion As String)
        Dim objLVDA As New ListaVentasDA
        objLVDA.guardarClienteConfiguraionListaActiva(idListaVentas, idCliente, idCat, cantidad, accion)
    End Sub

    'Public Sub guardarClienteFletesConfiguraion(ByVal idListaVentas As Int32, ByVal idCliente As Int32, ByVal idFlete As Int32)
    '    Dim objLVDA As New ListaVentasDA
    '    objLVDA.guardarClienteFletesConfiguraion(idListaVentas, idCliente, idFlete)
    'End Sub

    'Public Sub inactivarConfClienteFlete(ByVal idListaVentas As Int32, ByVal idCliente As Int32)
    '    Dim objLVDA As New ListaVentasDA
    '    objLVDA.inactivarConfClienteFlete(idListaVentas, idCliente)
    'End Sub

    'Public Sub guardarClienteIVAConfiguraion(ByVal idListaVentas As Int32, ByVal idCliente As Int32, ByVal idIVA As Int32)
    '    Dim objLVDA As New ListaVentasDA
    '    objLVDA.guardarClienteIVAConfiguraion(idListaVentas, idCliente, idIVA)
    'End Sub

    'Public Sub inactivarConfClienteIVA(ByVal idListaVentas As Int32, ByVal idCliente As Int32)
    '    Dim objLVDA As New ListaVentasDA
    '    objLVDA.inactivarConfClienteIVA(idListaVentas, idCliente)
    'End Sub

    'Public Sub inactivarConfClienteFacturacion(ByVal idListaVentas As Int32, ByVal idCliente As Int32)
    '    Dim objLVDA As New ListaVentasDA
    '    objLVDA.inactivarConfClienteFacturacion(idListaVentas, idCliente)
    'End Sub

    'Public Sub guardarClienteFacturacion(ByVal idListaVentas As Int32, ByVal idCliente As Int32, ByVal porciento As Boolean, ByVal cantidad As String)
    '    Dim objLVDA As New ListaVentasDA
    '    objLVDA.guardarClienteFacturacion(idListaVentas, idCliente, porciento, cantidad)
    'End Sub

    Public Sub editarConfiguracionListaVentas(ByVal listaprecioventaid As Int32, ByVal facturacioninicio As String,
                                             ByVal facturacionfin As String, ByVal descuentoinicio As String,
                                             ByVal descuentofin As String)

        Dim objLVDA As New ListaVentasDA
        objLVDA.editarConfiguracionListaVentas(listaprecioventaid, facturacioninicio, facturacionfin, descuentoinicio, descuentofin)
    End Sub

    Public Sub inactivarRelacionClienteListaVenta(ByVal idListaBase As Int32,
                                                          ByVal listaVentas As Int32,
                                                        ByVal listaVentasCliente As Int32,
                                                  ByVal idCliente As Int32)
        Dim objLVDA As New ListaVentasDA
        objLVDA.inactivarRelacionClienteListaVenta(idListaBase, listaVentas, listaVentasCliente, idCliente)
    End Sub

    Public Sub inactivarCatalogosSimples(ByVal catalogo As String, ByVal listaprecioventaid As Int32, ByVal idCatalogo As Int32)
        Dim objLVDA As New ListaVentasDA
        objLVDA.inactivarCatalogosSimples(catalogo, listaprecioventaid, idCatalogo)
    End Sub

    ''Public Sub inactivaRelacionFleteCliente(ByVal idListaVentasid As Int32, ByVal idCliente As Int32)
    ''    Dim objLVDA As New ListaVentasDA
    ''    objLVDA.inactivaRelacionFleteCliente(idListaVentasid, idCliente)
    ''End Sub

    Public Sub inactivarConfClienteDescuento(ByVal idListaVentas As Int32, ByVal idCliente As Int32)
        Dim objLVDA As New ListaVentasDA
        objLVDA.inactivarConfClienteDescuento(idListaVentas, idCliente)
    End Sub

    Public Sub guardarClienteDescuentoConfiguraion(ByVal idListaVentas As Int32, ByVal idCliente As Int32,
                                                 ByVal idDescuento As Int32, ByVal idlugar As Int32,
                                                 ByVal encadenado As Boolean, ByVal porcentaje As Boolean,
                                                 ByVal cantidad As String, ByVal dias As Int32)
        Dim objLVDA As New ListaVentasDA
        objLVDA.guardarClienteDescuentoConfiguraion(idListaVentas, idCliente, idDescuento, idlugar, encadenado, porcentaje, cantidad, dias)
    End Sub

    Public Sub editarEncabezadoListaVentas(ByVal codListaVenta As String,
       ByVal descripcion As String, ByVal vigenciainicio As String,
       ByVal vigenciafin As String, ByVal listaventasid As Int32,
        ByVal porcentaje As Boolean, ByVal incrementoporpar As Double,
        ByVal editarInfocliente As Boolean, ByVal realizarEditar As Boolean)
        Dim objLVDA As New ListaVentasDA
        objLVDA.editarEncabezadoListaVentas(codListaVenta, descripcion, vigenciainicio, vigenciafin, listaventasid, porcentaje, incrementoporpar, editarInfocliente, realizarEditar)
    End Sub

    Public Sub guardarPrestiloPrecio(ByVal idListaVentasid As Int32, ByVal productoestiloid As Int32,
                                  ByVal preciobase As Double, ByVal precio As Double)
        Dim objLVDA As New ListaVentasDA
        objLVDA.guardarPrestiloPrecio(idListaVentasid, productoestiloid, preciobase, precio)
    End Sub

    Public Sub guardarCambiosVigenciaAlerta(ByVal vigenciaFin As String, ByVal idLista As Int32, ByVal tipoLista As String)
        Dim objLVDA As New ListaVentasDA
        objLVDA.guardarCambiosVigenciaAlerta(vigenciaFin, idLista, tipoLista)
    End Sub

    Public Sub guardarCambiosEstatusLVCPAlerta(ByVal estatus As String, ByVal idLista As Int32)
        Dim objLVDA As New ListaVentasDA
        objLVDA.guardarCambiosEstatusLVCPAlerta(estatus, idLista)
    End Sub

    Public Function consultaConfiguracionClienteLV(ByVal idListaPrecioVentas As Int32, ByVal idCliente As Int32) As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.consultaConfiguracionClienteLV(idListaPrecioVentas, idCliente)
    End Function

    Public Function consultaConfiguracionDescuentoClienteLV(ByVal idListaPrecioVentas As Int32, ByVal idCliente As Int32) As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.consultaConfiguracionDescuentoClienteLV(idListaPrecioVentas, idCliente)
    End Function

    Public Function consultaminVigencias(ByVal idListaVentas As Int32) As DataTable
        Dim objLVDA As New ListaVentasDA
        Return objLVDA.consultaminVigencias(idListaVentas)
    End Function
End Class
