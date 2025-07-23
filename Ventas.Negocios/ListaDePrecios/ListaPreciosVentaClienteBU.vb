Public Class ListaPreciosVentaClienteBU



    ''' <summary>
    ''' Genera la lista de precios mostrada en el formulario ListaPrecioFoto
    ''' </summary>
    ''' <param name="clienteID"></param>
    ''' <param name="ListaPrecioClienteID"></param>
    ''' <param name="TipoFiltro"></param>
    ''' <param name="FechaInicioPedido"></param>
    ''' <param name="FechaFinPedido"></param>
    ''' <param name="MarcasAgenteID"></param>
    ''' <param name="ColeccionMarcaID"></param>
    ''' <param name="FamiliasProyeccionID"></param>
    ''' <param name="ProductoEstiloID"></param>
    ''' <returns></returns>
    Public Function ListaPrecioFoto(ByVal clienteID As Integer,
                                    ByVal ListaPrecioClienteID As Integer,
                                    ByVal TipoFiltro As Integer,
                                    ByVal FechaInicioPedido As Date,
                                    ByVal FechaFinPedido As Date,
                                    ByVal MarcasAgenteID As String,
                                    ByVal ColeccionMarcaID As String,
                                    ByVal FamiliasProyeccionID As String,
                                    ByVal ProductoEstiloID As String) As DataTable
        Dim objDA As New Ventas.Datos.ListaPreciosVentaClienteDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ListaPrecioFoto(clienteID,
                                          ListaPrecioClienteID,
                                          TipoFiltro,
                                          FechaInicioPedido,
                                          FechaFinPedido,
                                          MarcasAgenteID,
                                          ColeccionMarcaID,
                                          FamiliasProyeccionID,
                                          ProductoEstiloID)
            Return tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' Genera los procedimientos para el reporte de listado de fotos con los parametros indicados
    ''' </summary>
    ''' <param name="tipo_busqueda"></param>
    ''' <param name="ClienteID"></param>
    ''' <param name="ListaPrecioClienteID"></param>
    ''' <param name="MarcasAgenteID"></param>
    ''' <returns>Datatable</returns>
    Public Function ListadoParametrosReportes(ByVal tipo_busqueda As Integer,
                                                      ByVal ClienteID As Integer,
                                                      ByVal ListaPrecioClienteID As Integer,
                                                      ByVal MarcasAgenteID As String) As DataTable
        Dim objDA As New Ventas.Datos.ListaPreciosVentaClienteDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ListadoParametrosReportes(tipo_busqueda, ClienteID, ListaPrecioClienteID, MarcasAgenteID)
            Return tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function consultaIncrementoFacturarIVAFleteCliente(ByVal idCliente As Int32) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaIncrementoFacturarIVAFleteCliente(idCliente)
    End Function

    Public Function consultaDescuentoCliente(ByVal idCliente As Int32) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaDescuentoCliente(idCliente)
    End Function

    'Public Function consultaFleteCliente(ByVal idCliente As Int32) As DataTable
    '    Dim objDA As New Datos.ListaPreciosVentaClienteDA
    '    Return objDA.consultaFleteCliente(idCliente)
    'End Function

    'Public Function consultaIVACliente(ByVal idCliente As Int32) As DataTable
    '    Dim objDA As New Datos.ListaPreciosVentaClienteDA
    '    Return objDA.consultaIVACliente(idCliente)
    'End Function

    Public Function consultaMonedaCliente(ByVal idCliente As Int32) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaMonedaCliente(idCliente)
    End Function

    Public Function consultaEstatusListaVentasClientePrecios(ByVal estatus As String) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaEstatusListaVentasClientePrecios(estatus)
    End Function

    '' ''Public Function guardarDatosListaPreciosCliente(ByVal listaventasid As Int32, ByVal clienteid As Int32,
    '' ''       ByVal incrementopar As Double, ByVal incrementoporcentaje As Boolean, ByVal descuento As Double,
    '' ''       ByVal facturacion As Double, ByVal tipofleteid As Int32, ByVal tipoivaid As Int32,
    '' ''       ByVal moneda As Int32, ByVal listaoriginalid As Int32) As DataTable
    '' ''    Dim objDA As New Datos.ListaPreciosVentaClienteDA
    '' ''    Return objDA.guardarDatosListaPreciosCliente(listaventasid, clienteid, incrementopar,
    '' ''                                                 incrementoporcentaje, descuento, facturacion, tipofleteid, tipoivaid,
    '' ''                                                 moneda, listaoriginalid)
    '' ''End Function

    Public Function consultaListaPreciosClienteExiste(ByVal idListaVentasCliente As Int32) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaListaPreciosClienteExiste(idListaVentasCliente)
    End Function

    Public Function consultaTotalRegistroListaClienteProducto(ByVal idListaVentasClienteid As Int32) As Int32
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaTotalRegistroListaClienteProducto(idListaVentasClienteid)
    End Function

    Public Function verClientesProspectoCopia(ByVal idListaVentas As Int32, ByVal idCliente As Int32, ByVal idlistaOriginal As Int32) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.verClientesProspectoCopia(idListaVentas, idCliente, idlistaOriginal)
    End Function

    Public Function verModelosPreciosListaCliente(ByVal idListaCliente As Int32) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.verModelosPreciosListaCliente(idListaCliente)
    End Function

    Public Function consultarListaClienteVentas(ByVal idListaCliente As Int32) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultarListaClienteVentas(idListaCliente)
    End Function

    ''Public Function consultarContadorRelacionListaCliente(ByVal idListaCliente As Int32) As Int32
    ''    Dim objDA As New Datos.ListaPreciosVentaClienteDA
    ''    Return objDA.consultarContadorRelacionListaCliente(idListaCliente)
    ''End Function

    Public Function consultarListaClienteVentasCopia(ByVal idListaClienteOrigen As Int32) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultarListaClienteVentasCopia(idListaClienteOrigen)
    End Function


    Public Function consultaListaCliente(ByVal idListaCliente As Int32, ByVal idCLiente As Int32, ByVal agentes As String,
                                         ByVal familias As Boolean, ByVal colecciones As Boolean,
                                         ByVal ArticulosPedidos As Boolean,
                                         ByVal fechaInicio As String, ByVal fechafIN As String,
                                         ByVal Marcas As String,
                                         ByVal IdMoneda As Integer,
                                         ByVal paridad As Double,
                                         ByVal MostrarModeloSAY As Boolean,
                                         ByVal idsMarcas As String) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaListaCliente(idListaCliente, idCLiente, agentes, familias, colecciones, ArticulosPedidos, fechaInicio, fechafIN, Marcas, IdMoneda, paridad, MostrarModeloSAY, idsMarcas)
    End Function

    Public Function consultaListaPreciosSimulador(ByVal idListaClienteCons As Int32, ByVal idCLiente As Int32, ByVal agentes As String,
                                      ByVal familias As Boolean, ByVal colecciones As Boolean,
                                      ByVal ArticulosPedidos As Boolean,
                                      ByVal fechaInicio As String, ByVal fechafIN As String,
                                      ByVal Marcas As String,
                                      ByVal IdMoneda As Integer,
                                      ByVal paridad As Double,
                                      ByVal MostrarModeloSAY As Boolean,
                                  ByVal idListaBase As Int32,
                                  ByVal idsMarcas As String) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaListaPreciosSimulador(idListaClienteCons, idCLiente, agentes, familias, colecciones, ArticulosPedidos, fechaInicio, fechafIN, Marcas, IdMoneda, paridad, MostrarModeloSAY, idListaBase, idsMarcas)
    End Function

    'Public Function verListaVentasClienteActual(ByVal idCliente As Int32) As Int32
    '    Dim objDA As New Datos.ListaPreciosVentaClienteDA
    '    Return objDA.verListaVentasClienteActual(idCliente)
    'End Function

    Public Function consultaListaVentasCliente(ByVal idListaBase As Int32, ByVal idCliente As Int32)
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaListaVentasCliente(idListaBase, idCliente)
    End Function

    Public Function consultaDatosClienteListaVentas(ByVal idCliente As Int32)
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaDatosClienteListaVentas(idCliente)
    End Function

    Public Function consultaValidarListasCapturadas(ByVal listaventasclienteid As Int32) As Int32
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaValidarListasCapturadas(listaventasclienteid)
    End Function

    Public Function datosListaVentasPrecioClienteEncabezado(ByVal idListaVentasClientePrecio As Int32)
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.datosListaVentasPrecioClienteEncabezado(idListaVentasClientePrecio)
    End Function

    Public Function consultaValidaLVCPAceptadas(ByVal idListaVentaCliente As Int32) As Int32
        Dim objLVCPDA As New Datos.ListaPreciosVentaClienteDA
        Return objLVCPDA.consultaValidaLVCPAceptadas(idListaVentaCliente)
    End Function
    '---------------------------------------------------------------------------------
    '---------------------------------------------------------------------------------
    '---------------------------------------------------------------------------------

    Public Function guardarListaVentasClientePrecio(ByVal listaventasclienteprecioid As Int32, ByVal listaventasclienteid As Int32, ByVal descripcion As String, ByVal vigenciainicio As String, ByVal vigenciafin As String,
                                                   ByVal incotermsid As Int32, ByVal paridad As Double, ByVal fechaparidad As String, ByVal descuento As Double, ByVal facturacion As Double,
                                                   ByVal fleteid As Int32, ByVal ivaid As Int32, ByVal monedaid As Int32, ByVal listaoriginal As Int32, ByVal alta As Boolean, ByVal estatuslv As Int32,
                                                   ByVal incremento As Double, ByVal porcentaje As Boolean, ByVal ligarListaOriginal As Boolean)
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.guardarListaVentasClientePrecio(listaventasclienteprecioid, listaventasclienteid, descripcion, vigenciainicio, vigenciafin,
                                                    incotermsid, paridad, fechaparidad, descuento, facturacion,
                                                    fleteid, ivaid, monedaid, listaoriginal, alta, estatuslv, incremento, porcentaje, ligarListaOriginal)
    End Function

    Public Sub guardarDatosListaPreciosClienteProductos(ByVal listaventasclienteid As Int32,
                                                        ByVal productoestiloid As Int32, ByVal preciobase As Double, ByVal preciocalculado As Double,
                                                        ByVal precio As Double, ByVal precioextranjero As Double, ByVal precioextranjerocalculado As Double,
                                                        ByVal listaventasid As Int32, ByVal moneda As Int32)
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        objDA.guardarDatosListaPreciosClienteProductos(listaventasclienteid, productoestiloid,
                                                       preciobase, preciocalculado, precio, precioextranjero,
                                                       precioextranjerocalculado, listaventasid, moneda)
    End Sub

    Public Sub inactivarArticuloListaCliente(ByVal idListaVentasClientePrecio As Int32, ByVal productoestiloid As Int32)
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        objDA.inactivarArticuloListaCliente(idListaVentasClientePrecio, productoestiloid)
    End Sub

    Public Sub relacionarCopiaListaVentasClienteProducto(ByVal idListaVentasClienteOriginal As Int32, ByVal idListaCLienteCopia As Int32)
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        objDA.relacionarCopiaListaVentasClienteProducto(idListaVentasClienteOriginal, idListaCLienteCopia)
    End Sub

    ''Public Sub inactivarCopiaListaVentasClienteProducto(ByVal idListaCLienteCopia As Int32)
    ''    Dim objDA As New Datos.ListaPreciosVentaClienteDA
    ''    objDA.inactivarCopiaListaVentasClienteProducto(idListaCLienteCopia)
    ''End Sub

    Public Sub inactivarCopiasdeListaVentas(ByVal idListaCLienteOriginal As Int32)
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        objDA.inactivarCopiasdeListaVentas(idListaCLienteOriginal)
    End Sub

    ''' <summary>
    ''' RECUPERA LOS DESCUENTOS ACTIVOS DE UN CLIENTE 
    ''' </summary>
    ''' <param name="IdCliente">ID DEL CLIENTE DEL CUAL SE RECUPERARAN LOS DESCUENTOS</param>
    ''' <returns>DATATABLE CON LA INFORMACIÓN RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarDescuentosDelCliente(ByVal IdCliente As Integer) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA

        RecuperarDescuentosDelCliente = objDA.RecuperarDescuentosDelCliente(IdCliente)

        Return RecuperarDescuentosDelCliente
    End Function

    ''' <summary>
    ''' RECUPERA LA DESCRIPCION DE LA LISTA DE VENTAS DEL CLIENTE Y EL PLAZO DE UN CLIENTE EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdCliente">ID DEL CLIENTE DEL CUAL SE RECUPERARA LA INFORMACION</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarInformacion_ListaDeCliente(ByVal IdCliente As Integer, ByVal IdListaVentasClientePrecio As Integer) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA

        RecuperarInformacion_ListaDeCliente = objDA.RecuperarInformacion_ListaDeCliente(IdCliente, IdListaVentasClientePrecio)

        Return RecuperarInformacion_ListaDeCliente
    End Function

    Public Function RecuperarCatalogo_De_Productos(ByVal IdCliente As Integer,
                                                    ByVal IdListaPrecioBase As Integer,
                                                    ByVal IdListaVentasCliente As Integer,
                                                    ByVal Marcas As String,
                                                    ByVal IdMoneda As Integer,
                                                    ByVal ListaCompleta_O_Pedidos As Boolean,
                                                    ByVal FechaInicioPedido As String,
                                                    ByVal FechaFinPedido As String,
                                                    ByVal Paridad As Double,
                                                    ByVal agentes As String,
                                                    ByVal idsMarcas As String) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA

        RecuperarCatalogo_De_Productos = objDA.RecuperarCatalogo_De_Productos(IdCliente,
                                                                              IdListaPrecioBase,
                                                                              IdListaVentasCliente,
                                                                              Marcas,
                                                                              IdMoneda,
                                                                              ListaCompleta_O_Pedidos,
                                                                              FechaInicioPedido,
                                                                              FechaFinPedido,
                                                                              Paridad,
                                                                              agentes,
                                                                              idsMarcas)

        Return RecuperarCatalogo_De_Productos
    End Function

    ' ''Public Sub copiarListaVentasPrecioCliente(ByVal idListaVentasClientePrecio As Int32)
    ' ''    Dim objDA As New Datos.ListaPreciosVentaClienteDA
    ' ''    objDA.copiarListaVentasPrecioCliente(idListaVentasClientePrecio)
    ' ''End Sub

    Public Function RecuperarModelajeUSA_EURO(ByVal Corrida_Principal As String, IdPais As Integer)
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Dim dtCorrida As New DataTable
        Dim Corrida As String = String.Empty

        dtCorrida = objDA.RecuperarModelajeUSA_EURO(Corrida_Principal, IdPais)

        If dtCorrida.Rows.Count = 0 Then
            Corrida = "No Ex_" + IdPais.ToString + "_" + Corrida_Principal
        Else
            Corrida = dtCorrida.Rows(0).Item(0).ToString() + "_" + dtCorrida.Rows(0).Item(1)
        End If

        Return Corrida
    End Function

    Public Function consultaListaVentasClientePrecio(ByVal IdListaVentasCliente As Int32, ByVal idCliente As Int32)
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaListaVentasClientePrecio(IdListaVentasCliente, idCliente)
    End Function

    Public Function recuperarValoresDeListaVentaClientePrecio(ByVal IdListaPrecioVentaCliente As Integer) As DataTable
        Dim objListaDA As New Datos.ListaPreciosVentaClienteDA
        Return objListaDA.recuperarValoresDeListaVentaClientePrecio(IdListaPrecioVentaCliente)
    End Function

    Public Function consultaListaVentas(ByVal idListaBase As Int32, ByVal idCliente As Int32)
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaListaVentas(idListaBase, idCliente)
    End Function

    Public Function RecuperarSimboloMoneda(ByVal IdMoneda As Integer) As String
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Dim dtSimbolo As New DataTable
        RecuperarSimboloMoneda = String.Empty

        dtSimbolo = objDA.RecuperarSimboloMoneda(IdMoneda)

        RecuperarSimboloMoneda = dtSimbolo.Rows(0).Item(0)

        Return RecuperarSimboloMoneda
    End Function

    Public Function consultaLimiteFechaListasVentasClienteLB(ByVal idCliente As Int32, ByVal idListaBase As Int32, ByVal listaventasclienteprecioid As Int32) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaLimiteFechaListasVentasClienteLB(idCliente, idListaBase, listaventasclienteprecioid)
    End Function

    Public Function verListaVentasClienteActual(ByVal idLB As Int32, ByVal idCliente As Int32) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.verListaVentasClienteActual(idLB, idCliente)
    End Function

    Public Function consultasDatosListasBaseCliente(ByVal idCliente As Int32, ByVal idListaBase As Int32) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultasDatosListasBaseCliente(idCliente, idListaBase)
    End Function

    Public Sub cambiarEstatusListaPreciosCLiente(ByVal idListaVentasCliente As Int32, ByVal idEstatus As Int32)
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        objDA.cambiarEstatusListaPreciosCLiente(idListaVentasCliente, idEstatus)
    End Sub

    Public Function consultaClientesPosibleCopia(ByVal idListaBase As Int32, ByVal idCliente As Int32, ByVal idListaOriginal As Int32) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaClientesPosibleCopia(idListaBase, idCliente, idListaOriginal)
    End Function

    Public Function consultaClientesNoCopia(ByVal idListaBase As Int32, ByVal idCliente As Int32, ByVal idListaOriginal As Int32) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaClientesNoCopia(idListaBase, idCliente, idListaOriginal)
    End Function

    Public Function copiarListaClienteProductos(ByVal listaPrecioVentas As Int32, ByVal listaventasclienteidOriginal As Int32,
                                           ByVal listaventasclienteidAfectado As Int32, ByVal descuento As String,
                                          ByVal facturacion As String, ByVal fleteid As Int32, ByVal ivaid As Int32,
                                          ByVal incremento As String, ByVal porcentaje As Boolean) As Int32

        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Dim dt As New DataTable
        Dim idReg As Int32 = 0

        dt = objDA.copiarListaClienteProductos(listaPrecioVentas, listaventasclienteidOriginal, listaventasclienteidAfectado, descuento,
                                            facturacion, fleteid, ivaid, incremento, porcentaje)
        If dt.Rows.Count > 0 Then
            idReg = CInt(dt.Rows(0).Item(0).ToString)
        End If
        Return idReg
    End Function

    Public Function consultaArticulosListaPrecioCliente(ByVal idListaPreciosVentaCliente As Int32, ByVal idListaBase As Int32) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaArticulosListaPrecioCliente(idListaPreciosVentaCliente, idListaBase)
    End Function

    Public Function validarClienteListaOriginal(ByVal idCliente As Int32) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.validarClienteListaOriginal(idCliente)
    End Function

    Public Function consultaNombreListaCopia(ByVal idListaCliente As Int32) As String
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaNombreListaCopia(idListaCliente)
    End Function

    Public Function consultaValidarVigenciaPorListaCliente(ByVal listaventasclienteid As Int32, ByVal listaventasclienteprecioid As Int32) As DataTable
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaValidarVigenciaPorListaCliente(listaventasclienteid, listaventasclienteprecioid)
    End Function

    Public Function consultaNombreCortoListaCopia(ByVal idListaCliente As Int32) As String
        Dim objDA As New Datos.ListaPreciosVentaClienteDA
        Return objDA.consultaNombreCortoListaCopia(idListaCliente)
    End Function

    Public Sub cambiarEstatusLigaListaOriginal(ByVal idListaVentasCliente As Int32, ByVal ligar As Boolean)
        Dim objLVCDA As New Datos.ListaPreciosVentaClienteDA
        objLVCDA.cambiarEstatusLigaListaOriginal(idListaVentasCliente, ligar)
    End Sub

    Public Function consultaListaPreciosCopia(ByVal idListaPreciosClienteOriginal As Int32) As DataTable
        Dim objLVCDA As New Datos.ListaPreciosVentaClienteDA
        Return objLVCDA.consultaListaPreciosCopia(idListaPreciosClienteOriginal)
    End Function

    Public Function consultaListasPreciosClienteTodas(ByVal idCliente As Int32) As DataTable
        Dim objLVCDA As New Datos.ListaPreciosVentaClienteDA
        Return objLVCDA.consultaListasPreciosClienteTodas(idCliente)
    End Function

    Public Function consultaArticulosPreciosDemoWEB(ByVal idListaPreciosCliente As Int32, ByVal marcas As String) As DataTable
        Dim objLVCDA As New Datos.ListaPreciosVentaClienteDA
        Return objLVCDA.consultaArticulosPreciosDemoWEB(idListaPreciosCliente, marcas)
    End Function

#Region "Reporte Clave SAT"
    Public Function consultaClaveSATCliente(ByVal idCliente As Int32) As String
        Dim objDaL As New Datos.ListaPreciosVentaClienteDA
        Dim dtClave As New DataTable
        Dim clave As String = String.Empty

        dtClave = objDaL.consultaClaveSATCliente(idCliente)

        If dtClave.Rows.Count > 0 Then
            If dtClave.Rows(0).Item("general") = 0 Then
                clave = "DETALLADA"
            Else
                clave = "GENERAL"
            End If

        End If

        Return clave
    End Function

    Public Function consultaReporteClaveSAT(ByVal listaPreciosid As Int32, ByVal marcasid As String, ByVal claveSat As Boolean) As DataTable
        Dim dtReporte As New DataTable
        Dim objDaL As New Datos.ListaPreciosVentaClienteDA

        dtReporte = objDaL.consultaReporteClaveSAT(listaPreciosid, marcasid, claveSat)

        Return dtReporte
    End Function
#End Region


    Public Function RegresarListaA_Capturada(ListaPrecioClienteID As Integer) As DataTable
        Try
            Dim objLVCDA As New Datos.ListaPreciosVentaClienteDA
            Return objLVCDA.RegresarListaA_Capturada(ListaPrecioClienteID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
