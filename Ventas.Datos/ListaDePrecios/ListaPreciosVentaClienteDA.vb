Imports System.Data.SqlClient

Public Class ListaPreciosVentaClienteDA
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

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro.ParameterName = "@ClienteID"
            parametro.Value = clienteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ListaPrecioClienteID"
            parametro.Value = ListaPrecioClienteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoFiltro"
            parametro.Value = TipoFiltro
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaInicioPedido"
            parametro.Value = FechaInicioPedido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFinPedido"
            parametro.Value = FechaFinPedido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MarcasAgenteID"
            parametro.Value = MarcasAgenteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionMarcaID"
            parametro.Value = ColeccionMarcaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FamiliasProyeccionID"
            parametro.Value = FamiliasProyeccionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ProductoEstiloID"
            parametro.Value = ProductoEstiloID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_ListaPrecioFoto", listaParametros)
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
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ListaPrecioClienteID"
            parametro.Value = ListaPrecioClienteID
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@MarcasAgenteID"
            parametro.Value = MarcasAgenteID
            listaParametros.Add(parametro)


            Select Case tipo_busqueda
                Case 1
                    dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_ListaPrecioFoto_FiltroFamilias", listaParametros)
                Case 2
                    dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_ListaPrecioFoto_FiltroColecciones", listaParametros)
                Case 3
                    dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_ListaPrecioFoto_FiltroArticulos", listaParametros)
            End Select
            Return dtResultadoConsulta
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Public Function consultaIncrementoFacturarIVAFleteCliente(ByVal idCliente As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT iccl_incrementopar_porcent, iccl_incrementopar_monto," +
        " ic.iccl_facturar, ic.iccl_tipoivaid, iv.tiva_nombre, ic.iccl_tipofleteid, tf.tifl_nombre," +
        " ic.iccl_calcularpreciocondescuento" +
        " FROM Cobranza.InfoCliente ic" +
        " JOIN Cobranza.TipoIVA iv ON ic.iccl_tipoivaid = iv.tiva_tipoivaid" +
        " JOIN Ventas.TipoFlete tf ON ic.iccl_tipofleteid = tf.tifl_tipofleteid" +
        " WHERE iccl_clienteid = " + idCliente.ToString +
        " AND iccl_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaDescuentoCliente(ByVal idCliente As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " SUM(decl_cantidaddescuento) AS DESCUENTO" +
                                    " FROM Cobranza.DescuentosCliente" +
                                    " WHERE decl_clienteid = " + idCliente.ToString +
                            " AND decl_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    ''Public Function consultaIVACliente(ByVal idCliente As Int32) As DataTable
    ''    Dim operacion As New Persistencia.OperacionesProcedimientos
    ''    Dim cadena As String = "SELECT" +
    ''                            " ic.iccl_tipoivaid," +
    ''                            " iv.tiva_nombre" +
    ''                                " FROM Cobranza.InfoCliente ic" +
    ''                                " JOIN Cobranza.TipoIVA iv" +
    ''                                    " ON ic.iccl_tipoivaid = iv.tiva_tipoivaid" +
    ''                            " WHERE ic.iccl_clienteid = " + idCliente.ToString +
    ''                                " AND ic.iccl_activo = 1"
    ''    Return operacion.EjecutaConsulta(cadena)
    ''End Function

    ''Public Function consultaFleteCliente(ByVal idCliente As Int32) As DataTable
    ''    Dim operacion As New Persistencia.OperacionesProcedimientos
    ''    Dim cadena As String = "SELECT" +
    ''                            " ic.iccl_tipofleteid," +
    ''                            " tf.tifl_nombre" +
    ''                    " FROM Cobranza.InfoCliente ic" +
    ''                    " JOIN Ventas.TipoFlete tf" +
    ''                        " ON ic.iccl_tipofleteid = tf.tifl_tipofleteid" +
    ''                            " WHERE ic.iccl_clienteid =" + idCliente.ToString +
    ''                    " AND tf.tifl_activo = 1"
    ''    Return operacion.EjecutaConsulta(cadena)
    ''End Function


    '' Importante validar cuando se migre la bd al 7.16
    Public Function consultaMonedaCliente(ByVal idCliente As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim cadena As String = "SELECT ic.iccl_clienteid, mo.mone_monedaid, mo.mone_nombre," +
                        " mo.mone_simbolo, pc.paca_fechacreacion, pc.paca_paridadpesos " +
                        " FROM Cobranza.InfoCliente ic" +
                        " JOIN Framework.Moneda mo ON ic.iccl_monedaid = mo.mone_monedaid" +
                        " JOIN Framework.ParidadCambiaria pc ON pc.paca_monedaid = mo.mone_monedaid" +
                        " WHERE ic.iccl_clienteid =" + idCliente.ToString +
                        " AND ic.iccl_activo = 1" +
                        " AND mo.mone_activo = 1" +
                        " AND pc.paca_activo = 1" +
                        " AND mo.mone_monedaid <> 1" +
                        " AND pc.paca_moduloid = 238"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaListaPreciosClienteExiste(ByVal idListaVentasCliente As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " lvcl_listaventasclienteid," +
                                " lvcl_listaprecioventasid," +
                                " lvcl_clienteid," +
                                " lvcl_descuento," +
                                " lvcl_facturacion," +
                                " lvcl_fleteid," +
                                " lvcl_ivaid," +
                                " lvcl_monedaid," +
                                " lvcl_listaoriginal," +
                                " lvcl_activo" +
                        " FROM Ventas.ListaVentasCliente" +
                        " WHERE lvcl_listaventasclienteid = " + idListaVentasCliente.ToString +
                        " AND lvcl_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaTotalRegistroListaClienteProducto(ByVal idListaVentasClienteid As Int32) As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtContarTotal As New DataTable
        Dim contTotal As Int32 = 0
        Dim cadena As String = "SELECT" +
                            " COUNT(lpp.lpcp_listaprecioclienteproductoid) AS Total" +
                            " FROM Ventas.ListaVentasCliente lvc" +
                            " JOIN Ventas.ListaPrecioClienteProducto lpp" +
                            " ON lvc.lvcl_listaventasclienteid = lpp.lpcp_listaventasclienteid" +
                            " WHERE lpp.lpcp_listaventasclienteid = " + idListaVentasClienteid.ToString +
                            " AND lvc.lvcl_listaoriginal = 0" +
                            " AND lpp.lpcp_activo = 1"
        dtContarTotal = operacion.EjecutaConsulta(cadena)
        If dtContarTotal.Rows.Count > 0 Then
            contTotal = dtContarTotal.Rows(0).Item(0)
        Else
            contTotal = 0
        End If
        Return contTotal
    End Function

    Public Function verClientesProspectoCopia(ByVal idListaVentas As Int32, ByVal idCliente As Int32, ByVal idlistaOriginal As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
        " 1 AS Seleccion," +
        " lv.lpvt_listaprecioventaid," +
        " lc.lvcl_listaventasclienteid," +
        " lc.lvcl_clienteid," +
        " cl.clie_idsicy," +
        " cl.clie_nombregenerico," +
        " ic.iccl_monedaid," +
        " 1 AS Existia" +
        " FROM Ventas.ListaPreciosVenta lv" +
        " JOIN Ventas.ListaVentasCliente lc" +
        " ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" +
        " JOIN Cliente.Cliente cl" +
        " ON lc.lvcl_clienteid = cl.clie_clienteid" +
        " JOIN Cobranza.InfoCliente ic" +
        " ON cl.clie_clienteid = ic.iccl_clienteid" +
        " WHERE lc.lvcl_activo = 1" +
        " AND lv.lpvt_listaprecioventaid = " + idListaVentas.ToString +
        " AND cl.clie_clienteid IN (SELECT DISTINCT" +
        " lvc.lvcl_clienteid" +
        " FROM Ventas.ListaVentasCliente lvc" +
        " WHERE lvc.lvcl_listaoriginal = " + idlistaOriginal.ToString + ")"

        cadena += " UNION "

        cadena += "SELECT" +
        " 0 AS Seleccion," +
        " lv.lpvt_listaprecioventaid," +
        " lc.lvcl_listaventasclienteid," +
        " lc.lvcl_clienteid," +
        " cl.clie_idsicy," +
        " cl.clie_nombregenerico," +
        " ic.iccl_monedaid," +
        " 0 AS Existia" +
        " FROM Ventas.ListaPreciosVenta lv" +
        " JOIN Ventas.ListaVentasCliente lc" +
        " ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" +
        " JOIN Cliente.Cliente cl" +
        " ON lc.lvcl_clienteid = cl.clie_clienteid" +
        " JOIN Cobranza.InfoCliente ic" +
        " ON cl.clie_clienteid = ic.iccl_clienteid" +
        " WHERE lc.lvcl_activo = 1" +
        " AND lv.lpvt_listaprecioventaid= " + idListaVentas.ToString +
        " AND cl.clie_clienteid <> " + idCliente.ToString +
        " AND lc.lvcl_listaoriginal = 0" +
        " AND cl.clie_clienteid NOT IN (SELECT DISTINCT" +
        " lvc.lvcl_clienteid" +
        " FROM Ventas.ListaPrecioClienteProducto lcl" +
        " JOIN Ventas.ListaVentasCliente lvc" +
        " ON lcl.lpcp_listaventasclienteid = lvc.lvcl_listaventasclienteid" +
        " WHERE lvc.lvcl_listaprecioventasid = " + idListaVentas.ToString + ")" +
        " ORDER BY clie_nombregenerico"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verModelosPreciosListaCliente(ByVal idListaCliente As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " lpcp_listaprecioclienteproductoid," +
                                " lpcp_listaventasclienteid," +
                                " lpcp_productoestiloid," +
                                " lpcp_preciobase," +
                                " lpcp_preciocalculado," +
                                " lpcp_precio," +
                                " lpcp_preciocalculadoextranjero," +
                                " lpcp_precioextranjero," +
                                " lpcp_activo" +
                        " FROM Ventas.ListaVentasCliente lv" +
                        " JOIN Ventas.ListaPrecioClienteProducto lc" +
                            " ON lv.lvcl_listaventasclienteid = lc.lpcp_listaventasclienteid" +
                                " WHERE lv.lvcl_listaventasclienteid = " + idListaCliente.ToString +
                        " AND lc.lpcp_activo = 1"
        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Function consultarListaClienteVentas(ByVal idListaCliente As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
        " lc.lvcl_listaventasclienteid," +
        " c.clie_clienteid," +
        " c.clie_nombregenerico" +
" FROM Ventas.ListaVentasCliente lc" +
" JOIN Cliente.Cliente c" +
    " ON lc.lvcl_clienteid = c.clie_clienteid" +
        " WHERE lc.lvcl_activo = 1" +
        " AND lc.lvcl_listaventasclienteid = " + idListaCliente.ToString +
    " ORDER BY c.clie_clienteid"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    'Public Function consultarContadorRelacionListaCliente(ByVal idListaCliente As Int32) As Int32
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim dtContarTotal As New DataTable
    '    Dim contTotal As Int32 = 0
    '    Dim cadena As String = "SELECT COUNT(lvcl_listaventasclienteid) AS TOTAL" +
    '                           " FROM Ventas.ListaVentasCliente WHERE lvcl_listaoriginal = " + idListaCliente.ToString
    '    dtContarTotal = operacion.EjecutaConsulta(cadena)
    '    If dtContarTotal.Rows.Count > 0 Then
    '        contTotal = dtContarTotal.Rows(0).Item(0)
    '    Else
    '        contTotal = 0
    '    End If
    '    Return contTotal
    'End Function

    Public Function consultarListaClienteVentasCopia(ByVal idListaClienteOrigen As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
        " lc.lvcl_listaventasclienteid," +
        " c.clie_clienteid," +
        " c.clie_nombregenerico" +
" FROM Ventas.ListaVentasCliente lc" +
" JOIN Cliente.Cliente c" +
    " ON lc.lvcl_clienteid = c.clie_clienteid" +
        " WHERE lc.lvcl_activo = 1" +
        " AND lc.lvcl_listaoriginal = " + idListaClienteOrigen.ToString +
    " ORDER BY c.clie_clienteid"
        Return operacion.EjecutaConsulta(cadena)
    End Function


    Public Function consultaListaCliente(ByVal idListaCliente As Int32,
                                     ByVal idCLiente As Int32,
                                     ByVal agentes As String,
                                     ByVal familias As Boolean,
                                     ByVal colecciones As Boolean,
                                     ByVal ArticulosPedidos As Boolean,
                                     ByVal fechaInicio As String,
                                     ByVal fechafIN As String,
                                     ByVal Marcas As String,
                                     ByVal IdMoneda As Integer,
                                     ByVal Paridad As Double,
                                     ByVal MostrarModeloSAY As Boolean,
                                     ByVal idsMarcas As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idListaCliente"
        parametro.Value = idListaCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idCliente"
        parametro.Value = idCLiente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idAgente"
        parametro.Value = agentes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@familias"
        parametro.Value = False
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colecciones"
        parametro.Value = False
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ArticulosPedidos"
        parametro.Value = ArticulosPedidos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechafIN"
        parametro.Value = fechafIN
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Marcas"
        parametro.Value = Marcas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdMoneda"
        parametro.Value = IdMoneda
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MostrarModeloSAY"
        parametro.Value = MostrarModeloSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Paridad"
        parametro.Value = Paridad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idsMarcas"
        parametro.Value = idsMarcas
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("Ventas.SP_ConsultaPreciosCliente_Reporte", listaParametros)
    End Function

    Public Function consultaListaPreciosSimulador(ByVal idListaClienteCons As Int32,
                                 ByVal idCLiente As Int32,
                                 ByVal agentes As String,
                                 ByVal familias As Boolean,
                                 ByVal colecciones As Boolean,
                                 ByVal ArticulosPedidos As Boolean,
                                 ByVal fechaInicio As String,
                                 ByVal fechafIN As String,
                                 ByVal Marcas As String,
                                 ByVal IdMoneda As Integer,
                                 ByVal Paridad As Double,
                                 ByVal MostrarModeloSAY As Boolean,
                                  ByVal idListaBase As Int32,
                                  ByVal idsMarcas As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@idListaClienteCons varchar(10),
        '@idCliente varchar(10),
        '@idAgente varchar(150),
        '@familias bit,
        '@colecciones bit,
        '@ArticulosPedidos BIT,
        '@fechaInicio VARCHAR(25),
        '@fechafIN VARCHAR(25),
        '@Marcas as varchar(Max),
        '@Paridad as float,
        '@MostrarModeloSAY bit,
        '@idListaBase INT

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idListaClienteCons"
        parametro.Value = idListaClienteCons
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idCliente"
        parametro.Value = idCLiente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idAgente"
        parametro.Value = agentes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@familias"
        parametro.Value = False
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colecciones"
        parametro.Value = False
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ArticulosPedidos"
        parametro.Value = ArticulosPedidos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechafIN"
        parametro.Value = fechafIN
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Marcas"
        parametro.Value = Marcas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Paridad"
        parametro.Value = Paridad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MostrarModeloSAY"
        parametro.Value = MostrarModeloSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idListaBase"
        parametro.Value = idListaBase
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idsMarcas"
        parametro.Value = idsMarcas
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_ConsultaPreciosCliente_Reporte_Simulador", listaParametros)
    End Function

    'Public Function verListaVentasClienteActual(ByVal idCliente As Int32) As Int32
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim dtContarTotal As New DataTable
    '    Dim contTotal As Int32 = 0

    '    Dim cadena As String = "SELECT lc.lvcl_listaventasclienteid, lv.lpvt_listaprecioventaid,	lv.lpvt_listapreciosbaseid" +
    '        " FROM Ventas.ListaPreciosBase lb JOIN Ventas.ListaPreciosVenta lv ON lb.lpba_listapreciosbaseid = lv.lpvt_listapreciosbaseid" +
    '        " JOIN Ventas.ListaVentasCliente lc ON lc.lvcl_listaprecioventasid = lv.lpvt_listaprecioventaid" +
    '        " WHERE lb.lpba_estatus = 2 AND lc.lvcl_clienteid = " + idCliente.ToString + " AND lv.lpvt_activo= 1 AND lc.lvcl_activo = 1"
    '    dtContarTotal = operacion.EjecutaConsulta(cadena)
    '    If dtContarTotal.Rows.Count > 0 Then
    '        contTotal = dtContarTotal.Rows(0).Item(0)
    '    Else
    '        contTotal = 0
    '    End If
    '    Return contTotal
    'End Function

    Public Function consultaListaVentasCliente(ByVal idListaBase As Int32, ByVal idCliente As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
        " lvcl_listaventasclienteid," +
        " case when lc.lvcl_descripcion is NULL THEN lpvt_codigolistaventa + ' - ' + lpvt_descripcion + '- ( )'" +
        " else	lpvt_codigolistaventa + ' - ' + lpvt_descripcion + '- (' + lvcl_descripcion + ')'  end AS LISTAVENTAS " +
        " FROM Ventas.ListaPreciosBase lp" +
        " JOIN Ventas.ListaPreciosVenta lv" +
        " ON lp.lpba_listapreciosbaseid = lv.lpvt_listapreciosbaseid" +
        " JOIN Ventas.ListaVentasCliente lc" +
        " ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" +
        " WHERE lc.lvcl_clienteid = " + idCliente.ToString +
        " AND lp.lpba_listapreciosbaseid = " + idListaBase.ToString +
        " AND lv.lpvt_estemporal = 0" +
        " AND lv.lpvt_activo = 1" +
        " AND lc.lvcl_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaDatosClienteListaVentas(ByVal idCliente As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT clie_clienteid,clie_idsicy,clie_nombregenerico,lpba_listapreciosbaseid, lpba_nombrelista,lpba_codigolistabase," +
                " lpba_vigenciainicio,lpba_vigenciafin, lpvt_listaprecioventaid,lpvt_codigolistaventa,lpvt_descripcion," +
                " lpvt_incrementoporpar, lpvt_porcentaje,lpvt_vigenciainicio,lpvt_vigenciafin,lvcl_listaventasclienteid, " +
                " lvcl_descripcion,iccl_tipoivaid,tiva_nombre,tifl_nombre,iccl_monedaid,mone_nombre, " +
                " SUM(decl_cantidaddescuento) AS Descuento, iccl_calcularpreciocondescuento " +
                " FROM (SELECT c.clie_clienteid,c.clie_idsicy,c.clie_nombregenerico,lp.lpba_listapreciosbaseid, " +
                " lp.lpba_nombrelista,lp.lpba_codigolistabase,lp.lpba_vigenciainicio,lp.lpba_vigenciafin, 	" +
                " lv.lpvt_listaprecioventaid,lv.lpvt_codigolistaventa,lv.lpvt_descripcion, lv.lpvt_incrementoporpar," +
                " lv.lpvt_porcentaje,lv.lpvt_vigenciainicio,lv.lpvt_vigenciafin, lc.lvcl_listaventasclienteid," +
                " lc.lvcl_descripcion,i.iccl_tipoivaid,v.tiva_nombre, f.tifl_nombre,i.iccl_monedaid,m.mone_nombre," +
                " d.decl_descuentosclienteid, CASE WHEN d.decl_cantidaddescuento IS NULL THEN 0 " +
                " ELSE d.decl_cantidaddescuento END AS decl_cantidaddescuento, i.iccl_calcularpreciocondescuento " +
                " FROM Ventas.ListaPreciosBase lp 	" +
                " JOIN Ventas.ListaPreciosVenta lv ON lp.lpba_listapreciosbaseid = lv.lpvt_listapreciosbaseid 	" +
                " JOIN Ventas.ListaVentasCliente lc ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid 	" +
                " JOIN Cliente.Cliente c ON lc.lvcl_clienteid = c.clie_clienteid 	" +
                " LEFT JOIN Cobranza.InfoCliente i ON c.clie_clienteid = i.iccl_clienteid 	" +
                " LEFT JOIN Cobranza.DescuentosCliente d ON c.clie_clienteid = d.decl_clienteid AND d.decl_activo = 1 	" +
                " JOIN Cobranza.TipoIVA v ON i.iccl_tipoivaid = v.tiva_tipoivaid 	" +
                " JOIN Ventas.TipoFlete AS f ON f.tifl_tipofleteid = i.iccl_tipofleteid 	" +
                " JOIN Framework.Moneda m ON m.mone_monedaid = i.iccl_monedaid " +
                " WHERE c.clie_activo = 1 And i.iccl_activo = 1 And lp.lpba_estatus = 2" +
                " And lv.lpvt_activo = 1 AND lc.lvcl_activo = 1 AND c.clie_clienteid =" + idCliente.ToString +
                " GROUP BY c.clie_clienteid,c.clie_idsicy,c.clie_nombregenerico,lp.lpba_listapreciosbaseid, " +
                " lp.lpba_nombrelista,lp.lpba_codigolistabase,lp.lpba_vigenciainicio,lp.lpba_vigenciafin, " +
                " lv.lpvt_listaprecioventaid,lv.lpvt_codigolistaventa,lv.lpvt_descripcion,lv.lpvt_incrementoporpar, " +
                " lv.lpvt_porcentaje, lv.lpvt_vigenciainicio,lv.lpvt_vigenciafin, lc.lvcl_listaventasclienteid,  " +
                " lc.lvcl_descripcion, i.iccl_tipoivaid, v.tiva_nombre, i.iccl_facturar, i.iccl_tipofleteid, f.tifl_nombre,  " +
                " i.iccl_monedaid, m.mone_nombre, d.decl_descuentosclienteid, decl_cantidaddescuento,iccl_calcularpreciocondescuento) AS clientes " +
                " GROUP BY clie_clienteid,clie_idsicy,clie_nombregenerico,lpba_listapreciosbaseid,lpba_nombrelista, lpba_codigolistabase," +
                " lpba_vigenciainicio,lpba_vigenciafin,lpvt_listaprecioventaid,lpvt_codigolistaventa, lpvt_descripcion,lpvt_incrementoporpar," +
                " lpvt_porcentaje,lpvt_vigenciainicio,lpvt_vigenciafin,lvcl_listaventasclienteid, lvcl_descripcion,iccl_tipoivaid,tiva_nombre," +
                " tifl_nombre,iccl_monedaid,mone_nombre,iccl_calcularpreciocondescuento"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaValidarListasCapturadas(ByVal listaventasclienteid As Int32) As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtContarTotal As New DataTable
        Dim contTotal As Int32 = 0
        Dim cadena As String = "SELECT lvcp_listaventasclienteprecioid, lvcp_listaventasclienteid," +
        " lvcp_descripcion, lvcp_vigenciainicio, lvcp_vigenciafin," +
        " lvcp_incotermsid, lvcp_paridad, lvcp_fechaparidad," +
        " lvcp_estatusid, lvcp_descuento, lvcp_facturacion," +
        " lvcp_fleteid, lvcp_ivaid, lvcp_monedaid," +
        " lvcp_listaventasclienteprecioid_original, lvcp_activo" +
        " FROM Ventas.ListaVentasClientePrecio WHERE lvcp_estatusid IN (25, 26) " +
        " AND lvcp_activo = 1 AND lvcp_listaventasclienteid = " + listaventasclienteid.ToString
        dtContarTotal = operacion.EjecutaConsulta(cadena)
        If dtContarTotal.Rows.Count > 0 Then
            contTotal = dtContarTotal.Rows.Count
        Else
            contTotal = 0
        End If
        Return contTotal
    End Function

    Public Function consultaEstatusListaVentasClientePrecios(ByVal estatus As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String
        cadena = "SELECT esta_estatusid, esta_nombre, esta_activo" +
        " FROM Framework.Estatus WHERE esta_areaoperacion = 'VENTAS' " +
        " AND esta_tipostatus = 'LISTAPRECIOCLIENTE' AND esta_activo = 1"
        If estatus <> "" Then
            cadena += " AND esta_estatusid IN (" + estatus + ")"
        End If
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function datosListaVentasPrecioClienteEncabezado(ByVal idListaVentasClientePrecio As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String
        cadena = "SELECT lcp.lvcp_listaventasclienteprecioid, lcp.lvcp_listaventasclienteid, lcp.lvcp_descripcion," +
        " lcp.lvcp_vigenciainicio, lcp.lvcp_vigenciafin, lcp.lvcp_incotermsid, lcp.lvcp_paridad," +
        " lcp.lvcp_fechaparidad, lcp.lvcp_estatusid, lcp.lvcp_descuento, lcp.lvcp_facturacion," +
        " lcp.lvcp_fleteid, fl.tifl_nombre, lcp.lvcp_ivaid, ti.tiva_nombre, lcp.lvcp_monedaid," +
        " mn.mone_nombre, lcp.lvcp_listaventasclienteprecioid_original, us.user_username, lcp.lvcp_activo," +
        " CASE" +
        " WHEN lcp.lvcp_fechamodifico IS NULL THEN GETDATE()" +
        " WHEN lcp.lvcp_fechamodifico IS NOT NULL THEN lcp.lvcp_fechamodifico" +
        " END AS fechamodifico," +
        " lcp.lvcp_listaventasclienteprecioid_original," +
        " lcp.lvcp_ligarlistaoriginal" +
        " FROM Ventas.ListaVentasClientePrecio lcp" +
        " JOIN Ventas.TipoFlete fl ON lcp.lvcp_fleteid = fl.tifl_tipofleteid" +
        " JOIN Cobranza.TipoIVA ti ON lcp.lvcp_ivaid = ti.tiva_tipoivaid" +
        " JOIN Framework.Moneda mn ON lcp.lvcp_monedaid = mn.mone_monedaid" +
        " LEFT JOIN Framework.Usuarios us ON lcp.lvcp_usuariomodifico = us.user_usuarioid" +
        " WHERE lvcp_listaventasclienteprecioid = " + idListaVentasClientePrecio.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaValidaLVCPAceptadas(ByVal idListaVentaCliente As Int32) As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim contTotal As Int32 = 0
        Dim dtContarTotal As New DataTable
        Dim cadena As String = ""
        cadena = "SELECT COUNT(lvcp_listaventasclienteprecioid) AS Total" +
        " FROM Ventas.ListaVentasClientePrecio  WHERE lvcp_estatusid = 26" +
        " AND lvcp_listaventasclienteid = " + idListaVentaCliente.ToString

        dtContarTotal = operacion.EjecutaConsulta(cadena)
        If dtContarTotal.Rows.Count > 0 Then
            contTotal = dtContarTotal.Rows(0).Item(0)
        Else
            contTotal = 0
        End If
        Return contTotal
    End Function

    '---------------------------------------------------------------------------------
    '---------------------------------------------------------------------------------
    '---------------------------------------------------------------------------------

    Public Function guardarListaVentasClientePrecio(ByVal listaventasclienteprecioid As Int32, ByVal listaventasclienteid As Int32, ByVal descripcion As String, ByVal vigenciainicio As String, ByVal vigenciafin As String,
                                                    ByVal incotermsid As Int32, ByVal paridad As Double, ByVal fechaparidad As String, ByVal descuento As Double, ByVal facturacion As Double,
                                                    ByVal fleteid As Int32, ByVal ivaid As Int32, ByVal monedaid As Int32, ByVal listaoriginal As Int32, ByVal alta As Boolean, ByVal estatuslv As Int32,
                                                    ByVal incremento As Double, ByVal porcentaje As Boolean, ByVal ligarListaOriginal As Boolean)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "@listaventasclienteprecioid"
        parametro.Value = listaventasclienteprecioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@listaventasclienteid"
        parametro.Value = listaventasclienteid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@descripcion"
        parametro.Value = descripcion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@vigenciainicio"
        parametro.Value = vigenciainicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@vigenciafin"
        parametro.Value = vigenciafin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@incotermsid"
        If incotermsid > 0 Then
            parametro.Value = incotermsid
        Else
            parametro.Value = DBNull.Value
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@paridad"
        parametro.Value = paridad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaparidad"
        If fechaparidad <> "" Then
            parametro.Value = fechaparidad
        Else
            parametro.Value = DBNull.Value
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@descuento"
        parametro.Value = descuento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@facturacion"
        parametro.Value = facturacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fleteid"
        parametro.Value = fleteid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ivaid"
        parametro.Value = ivaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@monedaid"
        parametro.Value = monedaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@listaoriginal"
        parametro.Value = listaoriginal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@alta"
        parametro.Value = alta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatuslv"
        parametro.Value = estatuslv
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@incremento"
        parametro.Value = incremento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@porcentaje"
        parametro.Value = porcentaje
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ligarListaOriginal"
        parametro.Value = ligarListaOriginal
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_AltaListaVentasClientePrecio", listaParametros)

    End Function

    Public Sub guardarDatosListaPreciosClienteProductos(ByVal listaventasclienteid As Int32,
                                                        ByVal productoestiloid As Int32, ByVal preciobase As Double, ByVal preciocalculado As Double,
                                                        ByVal precio As Double, ByVal precioextranjero As Double, ByVal precioextranjerocalculado As Double,
                                                        ByVal listaventasid As Int32, ByVal moneda As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        '@listaventasid INT,
        '@moneda INT,

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@listaventasclienteid"
        parametro.Value = listaventasclienteid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@productoestiloid"
        parametro.Value = productoestiloid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@preciobase"
        'se modificó para la forma auditoría precio base  se quitó el redondeo      
        'parametro.Value = Math.Round(preciobase)
        parametro.Value = preciobase
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@preciocalculado"
        parametro.Value = Math.Round(preciocalculado)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@precio"
        parametro.Value = precio
        'parametro.Value = Math.Round(precio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@listaventasid"
        parametro.Value = Math.Round(listaventasid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@moneda"
        parametro.Value = Math.Round(moneda)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@precioextranjero"
        If precioextranjero > 0 Then
            parametro.Value = precioextranjero
        Else
            parametro.Value = 0
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@precioextranjerocalculado"
        If precioextranjerocalculado > 0 Then
            parametro.Value = precioextranjerocalculado
        Else
            parametro.Value = 0
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuariocreo"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Ventas.SP_AltaListaPrecioClienteProducto", listaParametros)

    End Sub

    Public Sub inactivarArticuloListaCliente(ByVal idListaVentasClientePrecio As Int32, ByVal productoestiloid As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idListaCliente"
        parametro.Value = idListaVentasClientePrecio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idProductoEstilo"
        parametro.Value = productoestiloid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarConsultaSP("Ventas.SP_InactivarRelcionClienteProducto", listaParametros)
    End Sub

    Public Sub relacionarCopiaListaVentasClienteProducto(ByVal idListaVentasClienteOriginal As Int32, ByVal idListaCLienteCopia As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "UPDATE Ventas.ListaVentasCliente set lvcl_listaoriginal=" + idListaVentasClienteOriginal.ToString + " WHERE lvcl_listaventasclienteid =" + idListaCLienteCopia.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

    ' ''Public Sub inactivarCopiaListaVentasClienteProducto(ByVal idListaCLienteCopia As Int32)
    ' ''    Dim operacion As New Persistencia.OperacionesProcedimientos
    ' ''    Dim cadena As String = "UPDATE Ventas.ListaVentasCliente set lvcl_listaoriginal=0 WHERE lvcl_listaventasclienteid =" + idListaCLienteCopia.ToString
    ' ''    operacion.EjecutaSentencia(cadena)
    ' ''End Sub

    Public Sub inactivarCopiasdeListaVentas(ByVal idListaCLienteOriginal As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "UPDATE Ventas.ListaVentasCliente set lvcl_listaoriginal=0 WHERE lvcl_listaoriginal =" + idListaCLienteOriginal.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

    ''' <summary>
    ''' RECUPERA LOS DESCUENTOS ACTIVOS DE UN CLIENTE EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdCliente">ID DEL CLIENTE DEL CUAL SE RECUPERARAN LOS DESCUENTOS</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarDescuentosDelCliente(ByVal IdCliente As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = " select mode_nombre as 'Descuento', convert(varchar(10), decl_cantidaddescuento)" +
            " + ' %' as '%', decl_diasplazo as 'Plazo' from cobranza.DescuentosCliente" +
            " JOIN cobranza.MotivoDescuento on mode_motivodescuentoid = decl_motivodescuentoid" +
            " WHERE decl_clienteid = " + IdCliente.ToString + " and decl_activo = 1 order by mode_nombre"
        Return operacion.EjecutaConsulta(cadena)
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

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdCliente"
        parametro.Value = IdCliente.ToString
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdListaPrecioBase"
        parametro.Value = IdListaPrecioBase.ToString
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdListaVentasCliente"
        parametro.Value = IdListaVentasCliente.ToString
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Marcas"
        parametro.Value = Marcas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdMoneda"
        parametro.Value = IdMoneda.ToString
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@IdPaisMoneda"
        'parametro.Value = IdPaisMoneda.ToString
        'listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ListaCompleta_O_Pedidos"
        parametro.Value = ListaCompleta_O_Pedidos.ToString
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicioPedido"
        parametro.Value = FechaInicioPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFinPedido"
        parametro.Value = FechaFinPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Paridad"
        parametro.Value = Paridad.ToString
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Agentes"
        parametro.Value = agentes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idsMarcas"
        parametro.Value = idsMarcas.ToString
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("Ventas.SP_ConfirmacionDeModelaje", listaParametros)

    End Function

    ''' <summary>
    ''' RECUPERA EL NOMBRE DE LA LISTA DE PRECIOS DE CLIENTE Y LA VIGENCIA DE LA LISTA DE VENTAS DE UN CLIENTE EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdCliente">ID DEL CLIENTE DEL CUAL SE RECUPERARA LA INFORMACION</param>
    ''' <returns>DATATABLE CON EL RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarInformacion_ListaDeCliente(ByVal IdCliente As Integer, ByVal IdListaVentasClientePrecio As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = " SELECT lvcp_descripcion AS 'Temporada', 'Del ' + CONVERT(varchar(30), lpv.lpvt_vigenciainicio, 106) + ' al ' +" +
            " CONVERT(varchar(30), lpv.lpvt_vigenciafin, 106)" +
            " FROM Ventas.ListaPreciosBase AS lpb" +
            " JOIN Ventas.ListaPreciosVenta AS lpv ON lpb.lpba_listapreciosbaseid = lpv.lpvt_listapreciosbaseid" +
            " JOIN Ventas.ListaVentasCliente AS lvc ON lpv.lpvt_listaprecioventaid = lvc.lvcl_listaprecioventasid " +
            " join Ventas.ListaVentasClientePrecio on lvc.lvcl_listaventasclienteid = lvcp_listaventasclienteid" +
                    " WHERE lvc.lvcl_clienteid = " + IdCliente.ToString +
            " and lvcp_listaventasclienteprecioid = " + IdListaVentasClientePrecio.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaLimiteFechaListasVentasClienteLB(ByVal idCliente As Int32, ByVal idListaBase As Int32, ByVal listaventasclienteprecioid As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        Dim fecha As String = ""
        Dim dt As New DataTable
        ' cadena = "SELECT MAX(lcp.lvcp_vigenciafin + 1) AS LIMITE" +
        '" FROM Ventas.ListaVentasClientePrecio lcp" +
        '" JOIN Ventas.ListaVentasCliente lc ON lcp.lvcp_listaventasclienteid = lc.lvcl_listaventasclienteid" +
        '" JOIN Ventas.ListaPreciosVenta lpv ON lc.lvcl_listaprecioventasid = lpv.lpvt_listaprecioventaid" +
        '" JOIN Ventas.ListaPreciosBase lpb ON lpv.lpvt_listapreciosbaseid = lpb.lpba_listapreciosbaseid WHERE lc.lvcl_clienteid = " + idCliente.ToString +
        '" AND lpv.lpvt_listapreciosbaseid = " + idListaBase.ToString +
        '" AND lvcp_estatusid IN (25, 26) AND lvcp_activo = 1" +
        '" AND lvcp_listaventasclienteprecioid <> " + listaventasclienteprecioid.ToString +
        '        " UNION ALL" +
        '" SELECT MIN(lcp.lvcp_vigenciainicio -1) AS LIMITE" +
        '" FROM Ventas.ListaVentasClientePrecio lcp" +
        '" JOIN Ventas.ListaVentasCliente lc ON lcp.lvcp_listaventasclienteid = lc.lvcl_listaventasclienteid" +
        '" JOIN Ventas.ListaPreciosVenta lpv ON lc.lvcl_listaprecioventasid = lpv.lpvt_listaprecioventaid" +
        '" JOIN Ventas.ListaPreciosBase lpb ON lpv.lpvt_listapreciosbaseid = lpb.lpba_listapreciosbaseid WHERE lc.lvcl_clienteid = " + idCliente.ToString +
        '" AND lpv.lpvt_listapreciosbaseid = " + idListaBase.ToString +
        '" AND lvcp_estatusid IN (25, 26) And lvcp_activo = 1 " +
        '" And lvcp_listaventasclienteprecioid <> " + listaventasclienteprecioid.ToString + ""
        cadena = "SELECT Top 1 lcp.lvcp_vigenciafin + 1 AS LIMITE" +
               " FROM Ventas.ListaVentasClientePrecio lcp" +
               " JOIN Ventas.ListaVentasCliente lc ON lcp.lvcp_listaventasclienteid = lc.lvcl_listaventasclienteid" +
               " JOIN Ventas.ListaPreciosVenta lpv ON lc.lvcl_listaprecioventasid = lpv.lpvt_listaprecioventaid" +
               " JOIN Ventas.ListaPreciosBase lpb ON lpv.lpvt_listapreciosbaseid = lpb.lpba_listapreciosbaseid WHERE lc.lvcl_clienteid = " + idCliente.ToString +
               " AND lpv.lpvt_listapreciosbaseid  in (select lpba_listapreciosbaseid from Ventas.ListaPreciosBase where lpba_estatus in (1,2))" +
               " AND lvcp_estatusid IN (25, 26) AND lvcp_activo = 1" +
               " AND lvcp_listaventasclienteprecioid <> " + listaventasclienteprecioid.ToString +
                       " UNION ALL" +
               " SELECT Top 1 lcp.lvcp_vigenciainicio -1 AS LIMITE" +
               " FROM Ventas.ListaVentasClientePrecio lcp" +
               " JOIN Ventas.ListaVentasCliente lc ON lcp.lvcp_listaventasclienteid = lc.lvcl_listaventasclienteid" +
               " JOIN Ventas.ListaPreciosVenta lpv ON lc.lvcl_listaprecioventasid = lpv.lpvt_listaprecioventaid" +
               " JOIN Ventas.ListaPreciosBase lpb ON lpv.lpvt_listapreciosbaseid = lpb.lpba_listapreciosbaseid WHERE lc.lvcl_clienteid = " + idCliente.ToString +
               " AND lpv.lpvt_listapreciosbaseid  in (select lpba_listapreciosbaseid from Ventas.ListaPreciosBase where lpba_estatus in (1,2))" +
               " AND lvcp_estatusid IN (25, 26) And lvcp_activo = 1 " +
               " And lvcp_listaventasclienteprecioid <> " + listaventasclienteprecioid.ToString + ""
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function RecuperarModelajeUSA_EURO(ByVal Corrida As String, IdPais As Integer)
        Dim objPeristenia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = ""
        Consulta = "select * from Programacion.Tallas where talla_paisid = " + IdPais.ToString + " and  " +
            " talla_tallaprincipalid = (select top 1 talla_tallaid from Programacion.Tallas where talla_descripcion = '" + Corrida + "' and talla_paisid = 1 and talla_activo = 1)"
        Return objPeristenia.EjecutaConsulta(Consulta)
    End Function

    Public Function consultaListaVentasClientePrecio(ByVal IdListaVentas As Int32, ByVal idCliente As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = " SELECT lvcp_listaventasclienteprecioid AS 'ID_LVClientePrecio', lvcp_descripcion + '(' + esta_nombre + ')' AS 'NOMBRE'" +
            " FROM Ventas.ListaPreciosVenta" +
            " join Ventas.ListaVentasCliente AS a on a.lvcl_listaprecioventasid = lpvt_listaprecioventaid" +
            " JOIN ventas.listaventasclientePrecio AS B ON b.lvcp_listaventasclienteid = a.lvcl_listaventasclienteid" +
            " AND a.lvcl_activo = 1 AND B.lvcp_activo = 1" +
            " JOIN Framework.Estatus ON esta_estatusid = B.lvcp_estatusid" +
            " WHERE lpvt_listaprecioventaid = " + IdListaVentas.ToString + " And a.lvcl_clienteid = " + idCliente.ToString + " order by esta_nombre"

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function recuperarValoresDeListaVentaClientePrecio(ByVal IdListaPrecioVentaCliente As Integer)
        Dim objPeristenia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = ""
        Consulta = "SELECT lvcp_incrementoporpar,lvpc_porcentaje,lvcp_descuento,lvcp_facturacion,tiva_nombre,lvcp_ivaid," +
                " tifl_nombre,lvcp_fleteid,lvcp_vigenciainicio,lvcp_vigenciafin, lvcl_descripcion," +
                " CASE WHEN lvcp_incotermsid IS NULL THEN 'N/A' ELSE LTRIM(RTRIM(inco_claveincoterm)) + ' - ' + inco_nombre" +
                " END AS 'INCOTERM',mone_nombre,lvcp_paridad AS 'PARIDAD'," +
                " 	CASE WHEN lvcp_monedaid >1 THEN lpba_codigolistabase + '-' + lpvt_codigolistaventa + '-' + CAST(lvcp_paridad AS varchar(10)) + 'TC' " +
                " ELSE lpba_codigolistabase + '-' + lpvt_codigolistaventa END AS NT_LISTAPRECIO" +
                " FROM Ventas.ListaVentasClientePrecio" +
                " LEFT JOIN Embarque.INCOTERMS ON inco_incotermsid = lvcp_incotermsid" +
                " JOIN Framework.Moneda ON lvcp_monedaid = mone_monedaid" +
                " LEFT JOIN Cobranza.TipoIVA ON lvcp_ivaid = tiva_tipoivaid" +
                " LEFT JOIN Ventas.TipoFlete ON lvcp_fleteid = tifl_tipofleteid" +
                " join Ventas.ListaVentasCliente on lvcl_listaventasclienteid = lvcp_listaventasclienteid" +
                " join Ventas.ListaPreciosVenta on lvcl_listaprecioventasid = lpvt_listaprecioventaid" +
                " join Ventas.ListaPreciosBase on lpvt_listapreciosbaseid = lpba_listapreciosbaseid" +
                " WHERE lvcp_listaventasclienteprecioid  = " + IdListaPrecioVentaCliente.ToString
        Return objPeristenia.EjecutaConsulta(Consulta)
    End Function

    Public Function consultaListaVentas(ByVal idListaBase As Int32, ByVal idCliente As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT lpvt_listaprecioventaid, lpvt_codigolistaventa + ' - ' + lpvt_descripcion as LISTAVENTAS" +
                            " FROM Ventas.ListaPreciosBase lp" +
                            " JOIN Ventas.ListaPreciosVenta lv" +
                            " 	ON lp.lpba_listapreciosbaseid = lv.lpvt_listapreciosbaseid" +
                            " JOIN Ventas.ListaVentasCliente lc" +
                            " 	ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" +
                            "  WHERE lc.lvcl_clienteid = " + idCliente.ToString +
                            " AND lp.lpba_listapreciosbaseid = " + idListaBase.ToString +
                            " AND lv.lpvt_estemporal = 0 
                                  And lc.lvcl_activo =1 "

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function RecuperarSimboloMoneda(ByVal IdMoneda As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select ltrim(rtrim(mone_simbolo)) from Framework.Moneda where mone_monedaid = " + IdMoneda.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verListaVentasClienteActual(ByVal idLB As Int32, ByVal idCliente As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT lv.lpvt_listaprecioventaid, lc.lvcl_listaventasclienteid" +
        " FROM Ventas.ListaPreciosVenta lv" +
        " JOIN Ventas.ListaVentasCliente lc ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" +
        " WHERE lc.lvcl_activo = 1 AND lv.lpvt_listapreciosbaseid = " + idLB.ToString +
        " AND lc.lvcl_clienteid = " + idCliente.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultasDatosListasBaseCliente(ByVal idCliente As Int32, ByVal idListaBase As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT lpba_listapreciosbaseid, lpba_nombrelista+' ('+ lpba_codigolistabase+ ')' AS LISTABASE, lpba_consecutivo, lpba_vigenciainicio," +
        " lpba_vigenciafin, lpba_estatus, lpba_usuariocreo, lpba_fechacreacion, lpba_usuariomodifico, lpba_fechamodifico," +
        " lpvt_listaprecioventaid, lpvt_listapreciosbaseid, lpvt_codigolistaventa, lpvt_descripcion, lpvt_incrementoporpar," +
        " lpvt_porcentaje, lpvt_vigenciainicio, lpvt_vigenciafin, lpvt_facturacioninicio, lpvt_facturacionfin, lpvt_descuentoinicio," +
        " lpvt_descuentofin, lpvt_estemporal, lpvt_eventoid, lpvt_fechacreacion, lpvt_usuariocreo, lpvt_fechamodificacion," +
        " lpvt_usuariomodifico, lpvt_activo, lvcl_listaventasclienteid, lvcl_listaprecioventasid, lvcl_clienteid," +
        " lvcl_descripcion, lvcl_descuento, lvcl_facturacion, lvcl_fleteid, lvcl_ivaid, lvcl_monedaid, lvcl_listaoriginal," +
        " lvcl_usuariocreoid, lvcl_fechacreacion, lvcl_usuariomodifico, lvcl_fechamodifico, lvcl_activo" +
        " FROM Ventas.ListaPreciosBase lb" +
        " JOIN Ventas.ListaPreciosVenta lv ON lb.lpba_listapreciosbaseid = lv.lpvt_listapreciosbaseid" +
        " JOIN Ventas.ListaVentasCliente lc ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" +
        " WHERE lc.lvcl_clienteid = " + idCliente.ToString
        If idListaBase > 0 Then
            cadena += " AND lb.lpba_listapreciosbaseid = " + idListaBase.ToString
        End If
        cadena += " AND lc.lvcl_activo = 1 AND lv.lpvt_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub cambiarEstatusListaPreciosCLiente(ByVal idListaVentasCliente As Int32, ByVal idEstatus As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "UPDATE Ventas.ListaVentasClientePrecio SET	lvcp_estatusid = " + idEstatus.ToString +
            ", lvcp_usuariomodifico = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
            ", lvcp_fechamodifico = GETDATE()" +
            " WHERE lvcp_listaventasclienteprecioid = " + idListaVentasCliente.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Function consultaClientesPosibleCopia(ByVal idListaPrecioBase As Int32, ByVal idCliente As Int32, ByVal idListaOriginal As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT CAST(0 AS BIT) AS Seleccion, c.clie_clienteid, c.clie_idsicy, c.clie_statuscliente, c.clie_nombregenerico," +
        " c.clie_razonsocial, c.clie_ranking, c.clie_personaidcliente, lb.lpba_codigolistabase +'-'+lv.lpvt_codigolistaventa as LV, " +
        " c.clie_clasificacionpersonaid, c.clie_comentarios, c.clie_empresaid, c.clie_tipoclienteid," +
        " c.clie_precioespecial, c.clie_condicionespecial, lv.lpvt_listaprecioventaid, lc.lvcl_listaventasclienteid," +
        " lv.lpvt_incrementoporpar AS incremento, lv.lpvt_porcentaje AS porcent, ic.iccl_monedaid, ic.iccl_facturar," +
        " cla.ccla_facturar, ic.iccl_tipofleteid, cla.ccla_tipofleteid, ic.iccl_tipoivaid, cla.ccla_tipoivaid," +
        " ISNULL((SELECT SUM(decl_cantidaddescuento) FROM Cobranza.DescuentosCliente WHERE decl_clienteid = c.clie_clienteid AND decl_activo = 1), 0) AS descuento," +
        " ISNULL((SELECT SUM(cdlv_cantidad) FROM Ventas.ClienteDescuentosListaVentas WHERE cdlv_clienteid = c.clie_clienteid AND cdlv_activo = 1), 0) AS descConf," +
        " ic.iccl_calcularpreciocondescuento AS calculaDesc," +
        " (SELECT COUNT(lvcp_listaventasclienteprecioid) FROM Ventas.ListaVentasClientePrecio WHERE lvcp_estatusid IN (25, 26) AND lvcp_listaventasclienteid = lvcl_listaventasclienteid) AS Listas," +
        " NULL AS Copia, NULL AS nuevaListaID, '' AS ESTATUS" +
        " FROM Cliente.Cliente c" +
        " JOIN Ventas.ListaVentasCliente lc ON c.clie_clienteid = lc.lvcl_clienteid" +
        " JOIN Ventas.ListaPreciosVenta lv ON lc.lvcl_listaprecioventasid = lv.lpvt_listaprecioventaid" +
        " JOIN Ventas.ListaPreciosBase lb ON lv.lpvt_listapreciosbaseid = lb.lpba_listapreciosbaseid" +
        " JOIN Cobranza.InfoCliente ic ON c.clie_clienteid = ic.iccl_clienteid" +
        " LEFT JOIN Ventas.ClienteConfiguracionListaActiva cla ON c.clie_clienteid = cla.ccla_clienteid AND cla.ccla_activo = 1" +
        " WHERE lc.lvcl_activo = 1" +
        " AND c.clie_activo = 1" +
        " AND lv.lpvt_activo = 1" +
        " AND lb.lpba_listapreciosbaseid = " + idListaPrecioBase.ToString +
        " AND c.clie_statuscliente = 'C'" +
        " AND c.clie_clienteid <> " + idCliente.ToString +
        " AND ic.iccl_monedaid = 1" +
        " AND c.clie_clienteid NOT IN (SELECT clme_clienteid FROM Programacion.ClienteMarcaEspecial WHERE clme_activo = 1)" +
        " AND c.clie_clienteid NOT IN (SELECT DISTINCT (coma_clienteid) FROM Programacion.ColeccionMarca WHERE coma_activo = 1 AND coma_clienteid IS NOT NULL) " +
        " AND c.clie_tipoclienteid = 1 " +
        " AND lv.lpvt_estemporal = 0" +
        " AND (SELECT COUNT(lvcp_listaventasclienteprecioid) FROM Ventas.ListaVentasClientePrecio WHERE lvcp_estatusid IN (25, 26) AND lvcp_listaventasclienteid = lc.lvcl_listaventasclienteid) < 2" +
        " AND (SELECT COUNT(lvcp_listaventasclienteprecioid) FROM Ventas.ListaVentasClientePrecio WHERE lvcp_listaventasclienteid = lc.lvcl_listaventasclienteid AND lvcp_listaventasclienteprecioid_original = " + idListaOriginal.ToString +
        " AND lvcp_estatusid IN (25, 26)) < 1" +
        " GROUP BY c.clie_clienteid, c.clie_idsicy, c.clie_statuscliente, c.clie_nombregenerico, lb.lpba_codigolistabase," +
        " lv.lpvt_codigolistaventa, c.clie_razonsocial, c.clie_ranking, c.clie_personaidcliente," +
        " c.clie_clasificacionpersonaid, c.clie_comentarios, c.clie_empresaid, c.clie_tipoclienteid," +
        " c.clie_precioespecial, c.clie_condicionespecial, lv.lpvt_listaprecioventaid, lc.lvcl_listaventasclienteid," +
        " lv.lpvt_incrementoporpar, lv.lpvt_porcentaje, ic.iccl_calcularpreciocondescuento , ic.iccl_monedaid, ic.iccl_facturar," +
        " cla.ccla_facturar, ic.iccl_tipofleteid, cla.ccla_tipofleteid, ic.iccl_tipoivaid, cla.ccla_tipoivaid" +
        " ORDER BY clie_nombregenerico"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaClientesNoCopia(ByVal idListaBase As Int32, ByVal idCliente As Int32, ByVal idListaOriginal As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT clie_clienteid," +
            " clie_idsicy," +
" clie_nombregenerico," +
" (marcasEsp + coleccionesEsp + Tipo+Moneda + ListasVentasCL + ListasPrecCopia + listabase) AS RAZON" +
 " FROM (SELECT" +
    " c.clie_clienteid," +
    " c.clie_idsicy," +
    " c.clie_nombregenerico," +
    " CASE" +
    " WHEN (SELECT COUNT(LCMX.clme_clientemarcaid) FROM Programacion.ClienteMarcaEspecial LCMX WHERE LCMX.clme_activo = 1 AND LCMX.clme_clienteid = c.clie_clienteid) > 0" +
    " THEN '• MARCAS ESPECIALES '" +
    " ELSE " +
        " '' END AS marcasEsp," +
    " CASE" +
    " WHEN (SELECT COUNT(CLMX.coma_coleccionmarcaid) FROM Programacion.ColeccionMarca CLMX WHERE CLMX.coma_activo = 1 AND CLMX.coma_clienteid = c.clie_clienteid) > 0" +
    " THEN '• COLECCIONES ESPECIALES '" +
    " ELSE " +
        " '' END AS coleccionesEsp," +
    " CASE" +
    " WHEN c.clie_tipoclienteid <> 1 THEN" +
        " '• EXTRANJERO ' ELSE '' END AS Tipo, " +
    " CASE" +
    " WHEN ic.iccl_monedaid <> 1 THEN" +
        " '• MONEDA EXTRANJERA ' ELSE '' END AS Moneda," +
    " CASE" +
    " WHEN (SELECT	COUNT(lvcp.lvcp_listaventasclienteprecioid) FROM Ventas.ListaVentasClientePrecio lvcp " +
    " JOIN Ventas.ListaVentasCliente lvc on lvc.lvcl_listaventasclienteid=lvcp.lvcp_listaventasclienteid" +
    " JOIN Ventas.ListaPreciosVenta lv on lv.lpvt_listaprecioventaid= lvc.lvcl_listaprecioventasid" +
        " WHERE lv.lpvt_listapreciosbaseid = " + idListaBase.ToString + " And lvc.lvcl_clienteid = c.clie_clienteid" +
    " AND lvcp.lvcp_estatusid IN (25, 26) AND lvc.lvcl_activo = 1) >= 2 THEN" +
        " '• 2 LISTAS DE PRECIOS DE CLIENTE '" +
    " ELSE" +
        " ''" +
    " END AS ListasVentasCL," +
    " CASE" +
    " WHEN (SELECT COUNT(lvcp.lvcp_listaventasclienteprecioid)FROM Ventas.ListaVentasClientePrecio lvcp " +
    " JOIN Ventas.ListaVentasCliente lvc ON lvc.lvcl_listaventasclienteid = lvcp.lvcp_listaventasclienteid" +
    " JOIN Ventas.ListaPreciosVenta lv ON lv.lpvt_listaprecioventaid = lvc.lvcl_listaprecioventasid" +
        " WHERE lvc.lvcl_clienteid = c.clie_clienteid And lv.lpvt_listapreciosbaseid = " + idListaBase.ToString +
        " And lvcp.lvcp_listaventasclienteprecioid_original = " + idListaOriginal.ToString +
    " AND lvcp.lvcp_estatusid IN (25, 26) AND lvc.lvcl_activo = 1) >= 1 THEN" +
        " '• LISTA COPIADA ACEPTADA/CAPTURADA'" +
    " ELSE" +
        " '' END AS ListasPrecCopia," +
    " CASE" +
    " WHEN (SELECT DISTINCT lv.lpvt_listapreciosbaseid" +
                " FROM Ventas.ListaVentasCliente lvc" +
                " JOIN Ventas.ListaPreciosVenta lv ON lv.lpvt_listaprecioventaid = lvc.lvcl_listaprecioventasid" +
                " WHERE lvc.lvcl_clienteid = c.clie_clienteid AND lvc.lvcl_activo = 1 AND lv.lpvt_estemporal = 0 AND lv.lpvt_listapreciosbaseid = " + idListaBase.ToString + ") IS NULL THEN" +
        " '• SIN LISTA DE VENTAS'" +
    " ELSE" +
        " ''" +
    " END AS listabase" +
    " FROM Cliente.Cliente c" +
    " JOIN Cobranza.InfoCliente ic ON c.clie_clienteid = ic.iccl_clienteid" +
        " WHERE" +
    " c.clie_activo = 1 AND c.clie_statuscliente = 'C' AND c.clie_clienteid <> " + idCliente.ToString +
    " ) AS CONS" +
    " WHERE marcasEsp <> '' OR coleccionesEsp <> '' OR Tipo <> '' OR Moneda <> '' OR ListasVentasCL <> '' OR ListasPrecCopia <> '' OR listabase <> ''" +
 " ORDER BY clie_nombregenerico"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function copiarListaClienteProductos(ByVal listaPrecioVentas As Int32, ByVal listaventasclienteidOriginal As Int32,
                                           ByVal listaventasclienteidAfectado As Int32, ByVal descuento As String,
                                           ByVal facturacion As String, ByVal fleteid As Int32, ByVal ivaid As Int32,
                                           ByVal incremento As String, ByVal porcentaje As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@listaPrecioVentas"
        parametro.Value = listaPrecioVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@listaventasclienteidOriginal"
        parametro.Value = listaventasclienteidOriginal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@listaventasclienteidAfectado"
        parametro.Value = listaventasclienteidAfectado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@descuento"
        parametro.Value = descuento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@facturacion"
        parametro.Value = facturacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fleteid"
        parametro.Value = fleteid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ivaid"
        parametro.Value = ivaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@incremento"
        parametro.Value = incremento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@porcentaje"
        parametro.Value = porcentaje
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_AltaListaVentasClientePrecioCopia", listaParametros)
    End Function

    Public Function consultaArticulosListaPrecioCliente(ByVal idListaPreciosVentaCliente As Int32, ByVal idListaBase As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT lp.lpcp_listaprecioclienteproductoid, lp.lpcp_listaventasclienteid, " +
        " lp.lpcp_productoestiloid, lb.lpbp_preciobase" +
        " FROM Ventas.ListaPrecioClienteProducto lp" +
        " JOIN Ventas.ListaPrecioBaseProducto lb on lp.lpcp_productoestiloid = lb.lpbp_productoestiloid" +
        " WHERE lp.lpcp_activo = 1" +
        " AND lb.lpbp_activo =1" +
        " AND lpcp_listaventasclienteid = " + idListaPreciosVentaCliente.ToString +
        " AND lb.lpbp_listapreciosbaseid = " + idListaBase.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function validarClienteListaOriginal(ByVal idCliente As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT c.clie_tipoclienteid, i.iccl_monedaid," +
        " ISNULL((SELECT COUNT(clme_clientemarcaid) FROM Programacion.ClienteMarcaEspecial WHERE clme_activo = 1 AND clme_clienteid = c.clie_clienteid), 0) as marcas," +
        " ISNULL((SELECT COUNT(coma_coleccionmarcaid) FROM Programacion.ColeccionMarca WHERE coma_activo= 1 AND coma_clienteid = c.clie_clienteid), 0) as colecciones" +
        " FROM Cliente.Cliente c" +
        " JOIN Cobranza.InfoCliente i ON c.clie_clienteid = i.iccl_clienteid" +
        " WHERE clie_clienteid = " + idCliente.ToString +
        " AND i.iccl_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaNombreListaCopia(ByVal idListaCliente As Int32) As String
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        Dim dt As New DataTable
        Dim resultado As String = ""
        'NOMBRE DE LISTA BASE (Código de la Lista base - Status) – NOMBRE DE LA LISTA DE VENTAS (Código de la lista de ventas) – DESCRIPCIÓN DE LA LISTA DE PRECIOS DE CLIENTE ORIGINAL
        cadena = "SELECT" +
        " CASE" +
        " WHEN lb.lpba_estatus = 1 THEN lb.lpba_nombrelista + ' (' + lb.lpba_codigolistabase + ' - ACTIVA) - ' + LV.lpvt_descripcion + ' (' + lv.lpvt_codigolistaventa + ') - ' + lcp.lvcp_descripcion" +
        " WHEN lb.lpba_estatus = 2 THEN lb.lpba_nombrelista + ' (' + lb.lpba_codigolistabase + ' - AUTORIZADA) - ' + LV.lpvt_descripcion + ' (' + lv.lpvt_codigolistaventa + ') - ' + lcp.lvcp_descripcion" +
        " ELSE 'INACTIVA'" +
        " END AS DESCRIPCION" +
        " FROM Ventas.ListaPreciosBase lb" +
        " JOIN Ventas.ListaPreciosVenta lv" +
        " ON lb.lpba_listapreciosbaseid = lv.lpvt_listapreciosbaseid" +
        " JOIN Ventas.ListaVentasCliente lc" +
        " ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" +
        " JOIN Ventas.ListaVentasClientePrecio lcp" +
        " ON lc.lvcl_listaventasclienteid = lcp.lvcp_listaventasclienteid" +
        " WHERE lcp.lvcp_listaventasclienteprecioid = " + idListaCliente.ToString
        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            resultado = dt.Rows(0).Item(0).ToString
        Else
            resultado = "SIN DESCRIPCION"
        End If
        Return resultado
    End Function

    Public Function consultaValidarVigenciaPorListaCliente(ByVal listaventasclienteid As Int32, ByVal listaventasclienteprecioid As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT lvcp_vigenciainicio, lvcp_vigenciafin" +
        " FROM Ventas.ListaVentasClientePrecio" +
        " WHERE lvcp_listaventasclienteid = " + listaventasclienteid.ToString +
        " AND lvcp_listaventasclienteprecioid <> " + listaventasclienteprecioid.ToString +
        " AND lvcp_estatusid IN (25, 26)" +
        " AND lvcp_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaNombreCortoListaCopia(ByVal idListaCliente As Int32) As String
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        Dim dt As New DataTable
        Dim resultado As String = ""
        'NOMBRE DE LISTA BASE (Código de la Lista base - Status) – NOMBRE DE LA LISTA DE VENTAS (Código de la lista de ventas) – DESCRIPCIÓN DE LA LISTA DE PRECIOS DE CLIENTE ORIGINAL
        cadena = "SELECT" &
            " c.clie_nombregenerico+' - '+ lcp.lvcp_descripcion" &
            " AS DESCRIPCION" &
            " FROM Ventas.ListaPreciosBase lb" &
            " JOIN Ventas.ListaPreciosVenta lv ON lb.lpba_listapreciosbaseid = lv.lpvt_listapreciosbaseid" &
            " JOIN Ventas.ListaVentasCliente lc ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" &
            " JOIN Ventas.ListaVentasClientePrecio lcp ON lc.lvcl_listaventasclienteid = lcp.lvcp_listaventasclienteid" &
            " JOIN Cliente.Cliente c on c.clie_clienteid = lc.lvcl_clienteid" &
            " WHERE lcp.lvcp_listaventasclienteprecioid = " + idListaCliente.ToString
        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            resultado = dt.Rows(0).Item(0).ToString
        Else
            resultado = "SIN DESCRIPCION"
        End If
        Return resultado
    End Function

    Public Sub cambiarEstatusLigaListaOriginal(ByVal idListaVentasCliente As Int32, ByVal ligar As Boolean)
        Dim cadena As String = "UPDATE Ventas.ListaVentasClientePrecio SET lvcp_ligarlistaoriginal = '" + ligar.ToString + "'" +
            " WHERE lvcp_listaventasclienteprecioid = " + idListaVentasCliente.ToString
        Dim operacion As New Persistencia.OperacionesProcedimientos
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Function consultaListaPreciosCopia(ByVal idListaPreciosClienteOriginal As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" &
        " lvcp.lvcp_listaventasclienteprecioid, lv.lpvt_incrementoporpar," &
        " ic.iccl_calcularpreciocondescuento, lv.lpvt_porcentaje," &
        " lv.lpvt_listaprecioventaid, cl.clie_clienteid" &
        " FROM Ventas.ListaVentasClientePrecio lvcp JOIN" &
        " Ventas.ListaVentasCliente lvc ON lvcp.lvcp_listaventasclienteid = lvc.lvcl_listaventasclienteid" &
        " JOIN Ventas.ListaPreciosVenta lv ON lvc.lvcl_listaprecioventasid = lv.lpvt_listaprecioventaid" &
        " JOIN Cliente.Cliente cl ON lvc.lvcl_clienteid = cl.clie_clienteid" &
        " JOIN Cobranza.InfoCliente ic ON cl.clie_clienteid = ic.iccl_clienteid" &
        " WHERE lvcp_ligarlistaoriginal = 1" &
        " AND lvcp_estatusid IN (25)" &
        " AND lvcp_listaventasclienteprecioid_original = " + idListaPreciosClienteOriginal.ToString

        Return operacion.EjecutaConsulta(cadena)
    End Function


    Public Function consultaListasPreciosClienteTodas(ByVal idCliente As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT" &
                " lb.lpba_listapreciosbaseid," &
                " lv.lpvt_listaprecioventaid," &
                " lvc.lvcl_listaventasclienteid," &
                " lvc.lvcl_clienteid," &
                " lvp.lvcp_listaventasclienteprecioid id," &
                " lb.lpba_nombrelista + ' - ' + lvp.lvcp_descripcion as lista," &
                    " lvp.lvcp_vigenciainicio," &
                    " lvcp_vigenciafin," &
                    " lvcp_estatusid," &
                    " lvcp_incrementoporpar," &
                    " lvpc_porcentaje," &
                    " lvcp_listaventasclienteprecioid_original," &
                    " lvcp_ligarlistaoriginal" &
            " FROM Ventas.ListaPreciosBase lb" &
            " JOIN Ventas.ListaPreciosVenta lv ON lb.lpba_listapreciosbaseid = lv.lpvt_listapreciosbaseid" &
            " JOIN Ventas.ListaVentasCliente lvc ON lv.lpvt_listaprecioventaid = lvc.lvcl_listaprecioventasid" &
            " JOIN Ventas.ListaVentasClientePrecio lvp ON lvc.lvcl_listaventasclienteid = lvp.lvcp_listaventasclienteid" &
                    " WHERE lv.lpvt_activo = 1" &
            " AND lvc.lvcl_activo = 1" &
            " AND lvp.lvcp_activo = 1" &
            " AND lvc.lvcl_clienteid = " + idCliente.ToString
        Return operacion.EjecutaConsulta(cadena)

    End Function

    Public Function consultaArticulosPreciosDemoWEB(ByVal idListaPreciosCliente As Int32, ByVal marcas As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT" &
    " lcp.lpcp_listaventasclienteid idLstVtaCliente," &
    " lcp.lpcp_listaprecioclienteproductoid idListaProd," &
    " ve.prod_productoid," &
    " ve.pstilo," &
    " ve.idTalla," &
    " ve.prod_codigo," &
    " ve.modeloSICY," &
    " ve.prod_descripcion + ' ' + ve.pielColor + ' ' + ve.talla AS descripcion," &
    " ve.temporada," &
    " Sicy," &
    " tallaSicy," &
    " ve.psEstatus," &
    " CASE WHEN psEstatus = 1 THEN '58FAF4'" &
     " WHEN psEstatus = 3 THEN 'F781BE'" &
     " WHEN psEstatus = 4 THEN 'FACC2E'" &
     " WHEN psEstatus = 6 THEN '58FA58' END as colorEstatus," &
    " CASE" &
        " WHEN ve.pres_imagen IS NULL THEN ve.prod_foto" &
        " ELSE ve.pres_imagen" &
    " END AS imagen," &
    " lcp.lpcp_monedaid," &
    " CASE" &
        " WHEN lcp.lpcp_monedaid > 1 THEN lcp.lpcp_precioextranjero" &
        " ELSE lcp.lpcp_precio" &
    " END AS PRECIO" &
" FROM Ventas.vProductoEstilos_WEB ve" &
" JOIN Ventas.ListaPrecioClienteProducto lcp ON ve.pstilo = lcp.lpcp_productoestiloid" &
        " WHERE lcp.lpcp_activo = 1" &
" AND ve.pres_activo = 1" &
" AND lcp.lpcp_listaventasclienteid = " + idListaPreciosCliente.ToString &
" AND ve.idMarca IN (" + marcas + ")"

        Return operacion.EjecutaConsulta(cadena)
    End Function

#Region "Reporte Clave SAT"
    Public Function consultaClaveSATCliente(ByVal idCliente As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "clienteid"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_FTC_ConsultaClaveSAT", listaParametros)
    End Function

    Public Function consultaReporteClaveSAT(ByVal listaPreciosid As Int32, ByVal marcasid As String, ByVal claveSat As Boolean) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@listaPrecios"
        parametro.Value = listaPreciosid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@marcasid"
        parametro.Value = marcasid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@claveSatGeneral"
        parametro.Value = claveSat
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_FTC_ConsultaReporteClaveSAT", listaParametros)

    End Function
#End Region

    Public Function RegresarListaA_Capturada(ListaPrecioClienteID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@ListaPreciosClienteID"
            parametro.Value = ListaPrecioClienteID
            listaParametros.Add(parametro)

            Return operaciones.EjecutarConsultaSP("[Cliente].[SP_ListaPrecios_RegresarListaCapturada]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
