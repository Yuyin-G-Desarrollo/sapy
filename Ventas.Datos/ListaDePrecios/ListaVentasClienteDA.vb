Public Class ListaVentasClienteDA

    Public Function consultaListaVentasClienteLV(ByVal idListaBase As Int32,
                                                 ByVal idListaPreciosVenta As Int32,
                                                 ByVal filtrarActivo As Boolean,
                                                 ByVal clienteActivo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        ''cadena = "SELECT lvcl_listaventasclienteid," +
        ''" lvcl_listaprecioventasid, lvcl_clienteid," +
        ''" cl.clie_nombregenerico, cl.clie_tipoclienteid" +
        ''" FROM Ventas.ListaVentasCliente lc" +
        ''" JOIN Cliente.Cliente cl ON lc.lvcl_clienteid = cl.clie_clienteid" +
        ''" WHERE lvcl_listaprecioventasid = " + idListaPreciosVenta.ToString +
        ''" AND lvcl_activo = 1 ORDER BY cl.clie_nombregenerico"

        cadena = "SELECT lvcl_listaventasclienteid, lvcl_listaprecioventasid, lvcl_clienteid," +
        " cl.clie_nombregenerico, cl.clie_tipoclienteid" +
        " FROM Ventas.ListaVentasCliente lc JOIN Cliente.Cliente cl ON lc.lvcl_clienteid = cl.clie_clienteid" +
        " JOIN Ventas.ListaPreciosVenta lv ON lc.lvcl_listaprecioventasid = lv.lpvt_listaprecioventaid"
        If idListaPreciosVenta > 0 Then
            cadena += " WHERE lc.lvcl_listaprecioventasid = " + idListaPreciosVenta.ToString
        End If

        If idListaBase > 0 Then
            cadena += " WHERE lv.lpvt_listapreciosbaseid = " + idListaBase.ToString
        End If

        cadena += " AND lc.lvcl_activo = 1" +
        " AND lv.lpvt_activo = 1" +
        " AND lv.lpvt_estemporal = 0"

        If filtrarActivo = True Then
            cadena += " AND cl.clie_activo = '" + clienteActivo.ToString + "'"
        End If

        cadena += " ORDER BY cl.clie_nombregenerico"

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaListasVentasClientePrecios(ByVal idListaBase As Int32, ByVal idListaVentas As Int32,
                                                       ByVal idCliente As Int32, ByVal idEstatus As Int32,
                                                       ByVal siLigar As Boolean, ByVal noLigar As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String
        cadena = "SELECT CAST(0 AS BIT) AS Seleccion, cl.clie_clienteid AS 'idsay', cl.clie_idsicy AS 'idsicy', cl.clie_tipoclienteid as 'tipoCliente'," +
                " cl.clie_nombregenerico AS 'Cliente', lv.lpvt_listaprecioventaid AS idListaVentas," +
                " lb.lpba_listapreciosbaseid AS 'idListaBase', (lb.lpba_codigolistabase + ' - ' + lb.lpba_nombrelista) AS 'listabase', " +
                " (lb.lpba_codigolistabase + ' - ' + lv.lpvt_codigolistaventa + ' ' + lv.lpvt_descripcion) AS 'listaVentas'," +
                " lv.lpvt_vigenciainicio, lv.lpvt_vigenciafin," +
                " lv.lpvt_incrementoporpar AS 'inxpar', lc.lvcl_listaventasclienteid as 'idListaVentasCliente'," +
                " lcp.lvcp_listaventasclienteprecioid AS 'idListaVentasClientePrecio', " +
                " lcp.lvcp_descripcion, lcp.lvcp_estatusid," +
                " (SELECT COUNT(lpcp_listaprecioclienteproductoid) FROM Ventas.ListaPrecioClienteProducto lp " +
                " JOIN vProductoEstilos cp on lp.lpcp_productoestiloid = cp.pstilo" +
                " WHERE lp.lpcp_listaventasclienteid = lcp.lvcp_listaventasclienteprecioid And lp.lpcp_activo = 1" +
                " AND pres_activo = 1 AND psEstatus NOT IN (1, 6)) AS 'NArt'," +
                " es.esta_nombre, lcp.lvcp_vigenciainicio," +
                " lcp.lvcp_vigenciafin, lcp.lvcp_fechamodifico, us.user_username, lcp.lvcp_monedaid, mo.mone_nombre, lcp.lvcp_paridad," +
                " lcp.lvcp_fechaparidad, lcp.lvcp_incotermsid, RTRIM(LTRIM(ict.inco_claveincoterm))+' - '+ ict.inco_nombre as incoterm, lcp.lvcp_descuento, lcp.lvcp_facturacion, " +
                " lcp.lvcp_fleteid, fl.tifl_nombre, lcp.lvcp_ivaid,	ti.tiva_nombre," +
                " lcp.lvcp_ligarlistaoriginal," +
                " lcp.lvcp_listaventasclienteprecioid_original," +
                " (SELECT cS.clie_nombregenerico + ' - ' + lcpS.lvcp_descripcion" +
                " FROM Cliente.Cliente cS" +
                " JOIN Ventas.ListaVentasCliente lcS ON cS.clie_clienteid = lcS.lvcl_clienteid" +
                " JOIN Ventas.ListaVentasClientePrecio lcpS ON lcS.lvcl_listaventasclienteid = lcpS.lvcp_listaventasclienteid" +
                " WHERE lcpS.lvcp_listaventasclienteprecioid = lcp.lvcp_listaventasclienteprecioid_original) AS 'LORIGINAL'," +
                " lcp.lvcp_fechacreacion AS 'fchr'," +
                " lcp.lvcp_fechacreacion AS 'fc'" +
                " FROM Ventas.ListaPreciosBase lb" +
                " JOIN Ventas.ListaPreciosVenta lv ON lb.lpba_listapreciosbaseid = lv.lpvt_listapreciosbaseid" +
                " JOIN Ventas.ListaVentasCliente lc ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" +
                " JOIN Ventas.ListaVentasClientePrecio lcp ON lc.lvcl_listaventasclienteid = lcp.lvcp_listaventasclienteid" +
                " JOIN Cliente.Cliente cl	ON lc.lvcl_clienteid = cl.clie_clienteid" +
                " JOIN Framework.Estatus es ON lcp.lvcp_estatusid = es.esta_estatusid" +
                " LEFT JOIN Framework.Usuarios us ON lcp.lvcp_usuariomodifico = us.user_usuarioid" +
                " JOIN Framework.Moneda mo ON lcp.lvcp_monedaid = mo.mone_monedaid" +
                " LEFT JOIN Embarque.INCOTERMS ict ON lcp.lvcp_incotermsid = ict.inco_incotermsid AND ict.inco_activo = 1" +
                " JOIN Ventas.TipoFlete fl on lcp.lvcp_fleteid= fl.tifl_tipofleteid" +
                " JOIN Cobranza.TipoIVA ti ON lcp.lvcp_ivaid= ti.tiva_tipoivaid" +
                " WHERE lv.lpvt_activo = 1 And lcp.lvcp_activo = 1" +
                " AND cl.clie_activo=1 AND mo.mone_activo=1 AND ti.tiva_activo = 1" +
                " AND lb.lpba_listapreciosbaseid = " + idListaBase.ToString

        If siLigar = True And noLigar = True Then
            cadena += " AND lcp.lvcp_ligarlistaoriginal IN (1, 0)"
        ElseIf siLigar = True And noLigar = True Then
            cadena += " AND lcp.lvcp_ligarlistaoriginal IN (1, 0)"
        ElseIf siLigar = True And noLigar = False Then
            cadena += " AND lcp.lvcp_ligarlistaoriginal = 1"
        ElseIf siLigar = False And noLigar = True Then
            cadena += " AND lcp.lvcp_ligarlistaoriginal = 0"
        End If

        If idListaVentas > 0 Then
            cadena += " AND lv.lpvt_listaprecioventaid = " + idListaVentas.ToString
        End If

        If idCliente > 0 Then
            cadena += " AND lc.lvcl_clienteid= " + idCliente.ToString
        End If
        If idEstatus > 0 Then
            cadena += " AND lcp.lvcp_estatusid= " + idEstatus.ToString
        End If

        cadena += "ORDER BY cl.clie_nombregenerico, es.esta_nombre , lcp.lvcp_vigenciainicio DESC "

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaIVAconf(ByVal idListaVentas As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String
        cadena = "SELECT lti.lvti_tipoivaid, ti.tiva_nombre FROM Ventas.ListaVentasTipoIva lti" +
        " JOIN Cobranza.TipoIVA ti ON lti.lvti_tipoivaid = ti.tiva_tipoivaid" +
        " WHERE lti.lvti_listaventaid = " + idListaVentas.ToString + " And lti.lvti_activo = 1 AND ti.tiva_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaFleteconf(ByVal idListaVentas As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String
        cadena = "SELECT ltf.lvtf_tipofleteid, tf.tifl_nombre FROM Ventas.ListaVentasTipoFlete ltf" +
                " JOIN Ventas.TipoFlete tf ON ltf.lvtf_tipofleteid = tf.tifl_tipofleteid" +
                " WHERE ltf.lvtf_listaventasid = " + idListaVentas.ToString + " AND ltf.lvtf_activo = 1 AND tf.tifl_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function


End Class
