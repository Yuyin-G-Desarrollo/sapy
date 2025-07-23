Imports System.Data.SqlClient

Public Class ListaVentasDA

    Public Function tipoIva(ByVal accion As String, ByVal idlistaventas As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""

        If accion = "ALTA" Then
            cadena = "SELECT" +
                               " tiva_tipoivaid," +
                               " tiva_nombre" +
                               " FROM Cobranza.TipoIVA" +
                               " WHERE tiva_activo = 1"
        ElseIf accion = "EDITAR" Then
            cadena = "SELECT" +
                    " ti.tiva_tipoivaid," +
                    " ti.tiva_nombre," +
                    " 1 AS SeleccionIva" +
                " FROM Ventas.ListaVentasTipoIva lt" +
                " JOIN Cobranza.TipoIVA ti" +
                    " ON lt.lvti_tipoivaid = ti.tiva_tipoivaid" +
                            " WHERE lvti_listaventaid = " + idlistaventas.ToString +
                " AND lt.lvti_activo = 1" +
                " AND ti.tiva_activo = 1 UNION SELECT" +
                    " tiva_tipoivaid," +
                    " tiva_nombre," +
                    " 0 AS SeleccionIva" +
                            " FROM Cobranza.TipoIVA" +
                " WHERE tiva_tipoivaid NOT IN (SELECT" +
                            " lvti_tipoivaid" +
                            " FROM Ventas.ListaVentasTipoIva" +
                            " WHERE lvti_listaventaid = " + idlistaventas.ToString +
                " AND lvti_activo = 1)" +
                " AND tiva_activo = 1"
        End If

        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Function tipoFlete(ByVal idListaVentas As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " tf.tifl_tipofleteid," +
                                " tf.tifl_nombre," +
                                " 1 AS SeleccionFlete" +
                            " FROM Ventas.ListaVentasTipoFlete lt" +
                            " JOIN Ventas.TipoFlete tf" +
                                " ON lt.lvtf_tipofleteid = tf.tifl_tipofleteid" +
                                    " WHERE lt.lvtf_listaventasid = " + idListaVentas.ToString +
                            " AND lt.lvtf_activo = 1" +
                            " AND tf.tifl_activo = 1 UNION SELECT" +
                                " tifl_tipofleteid," +
                                " tifl_nombre," +
                                " 0 AS SeleccionFlete" +
                                    " FROM Ventas.tipoflete" +
                            " WHERE tifl_tipofleteid NOT IN (SELECT" +
                                    " lvtf_tipofleteid" +
                                    " FROM Ventas.ListaVentasTipoFlete" +
                                    " WHERE lvtf_listaventasid = " + idListaVentas.ToString +
                            " AND lvtf_activo = 1)" +
                            " AND tifl_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function tipoFlete(ByVal accion As String, ByVal idlistaventas As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        If accion = "ALTA" Then
            cadena = "SELECT" +
                                " tifl_tipofleteid," +
                                " tifl_nombre" +
                                " FROM Ventas.TipoFlete" +
                                " WHERE tifl_activo = 1"
        ElseIf accion = "EDITAR" Then
            cadena = "SELECT" +
                    " f.tifl_tipofleteid," +
                    " f.tifl_nombre," +
                    " 1 AS SeleccionFlete" +
                " FROM Ventas.ListaVentasTipoFlete lf" +
                " JOIN Ventas.TipoFlete f" +
                    " ON lf.lvtf_tipofleteid = f.tifl_tipofleteid" +
                            " WHERE lf.lvtf_listaventasid = " + idlistaventas.ToString +
                " AND f.tifl_activo = 1" +
                " AND lvtf_activo = 1" +
                " UNION SELECT" +
                    " tifl_tipofleteid," +
                    " tifl_nombre," +
                    " 0 AS SeleccionFlete" +
                            " FROM Ventas.TipoFlete" +
                " WHERE tifl_tipofleteid NOT IN (SELECT" +
                            " lvtf_tipofleteid" +
                            " FROM Ventas.ListaVentasTipoFlete" +
                            " WHERE lvtf_listaventasid = " + idlistaventas.ToString +
                " AND lvtf_activo = 1 AND tifl_activo = 1)" +
                " AND tifl_activo = 1"
        End If

        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Function listaClienteVentasSelect(ByVal descuentoInicio As String, ByVal descuentoFin As String,
                                            ByVal facturacionInicio As String, ByVal facturacionFin As String,
                                            ByVal tipoIva As String, ByVal tipoFlete As String,
                                            ByVal idlistabase As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""

        cadena = "SELECT 0 AS Seleccion, clie_clienteid, clie_idsicy,	clie_nombregenerico,"

        ''" (SELECT ISNULL(lpvt_codigolistaventa, '') FROM Ventas.ListaPreciosVenta WHERE lpvt_listaprecioventaid = (" +
        ''" SELECT MAX(lv.lpvt_listaprecioventaid) FROM Ventas.ListaPreciosVenta lv " +
        ''" JOIN Ventas.ListaVentasCliente lc ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" +
        ''" WHERE lc.lvcl_activo = 0 AND lv.lpvt_listapreciosbaseid = " + idlistabase.ToString +
        ''" AND lvcl_clienteid = clientes.clie_clienteid)) AS lvAnterior,"

        cadena += " (SELECT ISNULL(lpvt_codigolistaventa, '') FROM Ventas.ListaPreciosVenta" +
         " WHERE lpvt_listaprecioventaid = (SELECT TOP 1 lv.lpvt_listaprecioventaid" +
         " FROM Ventas.ListaPreciosVenta lv" +
         " JOIN Ventas.ListaVentasCliente lc ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" +
         " WHERE lv.lpvt_listapreciosbaseid = " + idlistabase.ToString +
         " AND lvcl_clienteid = clientes.clie_clienteid" +
         " AND lc.lvcl_activo= 0" +
         " ORDER BY lc.lvcl_fechacreacion DESC))" +
         " AS lvAnterior,"

        cadena += " iccl_monedaid, mone_nombre,	iccl_tipoivaid AS idIvaAntes, iccl_tipoivaid, tiva_nombre," +
        " iccl_tipofleteid, tifl_nombre, iccl_facturar AS FacturarAntes, iccl_facturar," +
        " SUM(decl_cantidaddescuento) AS Descuento, 0 AS registroAnt" +
        " FROM (SELECT c.clie_clienteid, c.clie_idsicy, c.clie_nombregenerico, i.iccl_tipoivaid, v.tiva_nombre, i.iccl_facturar," +
                " i.iccl_tipofleteid, f.tifl_nombre, i.iccl_monedaid, m.mone_nombre, d.decl_descuentosclienteid, " +
            " CASE" +
                " WHEN d.decl_cantidaddescuento IS NULL THEN 0" +
                " ELSE d.decl_cantidaddescuento" +
            " END AS decl_cantidaddescuento" +
        " FROM Cliente.Cliente c" +
        " LEFT JOIN Cobranza.InfoCliente i ON c.clie_clienteid = i.iccl_clienteid" +
        " LEFT JOIN Cobranza.DescuentosCliente d ON c.clie_clienteid = d.decl_clienteid AND d.decl_activo = 1" +
        " JOIN Cobranza.TipoIVA v ON i.iccl_tipoivaid = v.tiva_tipoivaid" +
        " JOIN Ventas.TipoFlete AS f ON f.tifl_tipofleteid = i.iccl_tipofleteid" +
        " JOIN Framework.Moneda m ON m.mone_monedaid = i.iccl_monedaid" +
                " WHERE c.clie_activo = 1 AND c.clie_statuscliente = 'C'" +
        " AND i.iccl_activo = 1" +
        " AND c.clie_clienteid NOT IN (SELECT lcd.lvcl_clienteid FROM Ventas.ListaPreciosVenta lpv" +
        " JOIN Ventas.ListaVentasCliente lcd	ON lpv.lpvt_listaprecioventaid = lcd.lvcl_listaprecioventasid" +
                " WHERE lpv.lpvt_listapreciosbaseid = " + idlistabase.ToString + " AND lcd.lvcl_activo = 1  AND lpv.lpvt_estemporal = 0 )" +
                                     " AND i.iccl_tipofleteid IN (" + tipoFlete + ")" +
                                    " AND i.iccl_tipoivaid IN (" + tipoIva + ")" +
                                    " AND i.iccl_facturar BETWEEN " + facturacionInicio + " AND " + facturacionFin +
        " GROUP BY	c.clie_clienteid, c.clie_idsicy, c.clie_nombregenerico," +
                    " i.iccl_tipoivaid, v.tiva_nombre," +
                    " i.iccl_facturar, i.iccl_tipofleteid," +
                    " f.tifl_nombre, i.iccl_monedaid," +
                    " m.mone_nombre, d.decl_descuentosclienteid," +
                    " decl_cantidaddescuento) AS clientes" +
        " GROUP BY	clie_clienteid, clie_idsicy," +
                " clie_nombregenerico, iccl_tipoivaid," +
                " tiva_nombre, iccl_facturar," +
                " iccl_tipofleteid, tifl_nombre," +
                " iccl_monedaid, mone_nombre" +
         " HAVING SUM(decl_cantidaddescuento) BETWEEN " + descuentoInicio + " AND " + descuentoFin + " ORDER BY clie_nombregenerico"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function comprobarDigitoListaVenta(ByVal idListaBase As Int32, ByVal codigoLista As String, ByVal idListaVentas As Int32, ByVal accion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " COUNT(lpvt_listaprecioventaid) AS Disponible" +
                                    " FROM Ventas.ListaPreciosVenta" +
                                    " WHERE lpvt_listapreciosbaseid = " + idListaBase.ToString
        If accion = "EDITAR" Then
            cadena += " AND lpvt_listaprecioventaid <> " + idListaVentas.ToString
        End If
        cadena += " AND lpvt_codigolistaventa = '" + codigoLista + "'"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function registrarDatosListaVentas(ByVal listapreciosbaseid As Int32, ByVal codigolistaventa As String, ByVal descripcion As String,
        ByVal incrementoporpar As String, ByVal porcentaje As Boolean, ByVal vigenciainicio As String,
        ByVal vigenciafin As String, ByVal facturacioninicio As String, ByVal facturacionfin As String,
        ByVal descuentoinicio As String, ByVal descuentofin As String, ByVal evento As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@listapreciosbaseid"
        parametro.Value = listapreciosbaseid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@codigolistaventa"
        parametro.Value = codigolistaventa
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@incrementoporpar"
        parametro.Value = incrementoporpar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@descripcion"
        parametro.Value = descripcion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@porcentaje"
        parametro.Value = porcentaje
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
        parametro.ParameterName = "@facturacioninicio"
        parametro.Value = facturacioninicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@facturacionfin"
        parametro.Value = facturacionfin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@descuentofin"
        parametro.Value = descuentofin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@descuentoinicio"
        parametro.Value = descuentoinicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@evento"
        If evento = 0 Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = evento
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuariocreo"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_AltaListaVentas", listaParametros)

    End Function

    Public Function consultaListaVentas(ByVal idListaBase As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT lpvt_listaprecioventaid, lpvt_listapreciosbaseid, lpvt_codigolistaventa," +
    " lpvt_descripcion, lpvt_incrementoporpar, lpvt_porcentaje,	lpvt_vigenciainicio, lpvt_vigenciafin," +
    " lpvt_facturacioninicio,	lpvt_facturacionfin, lpvt_descuentoinicio,lpvt_descuentofin," +
    " lpvt_fechacreacion,	lpvt_usuariocreo, lpvt_fechamodificacion,	lpvt_usuariomodifico," +
    " lpvt_activo," +
    " (SELECT	STUFF((SELECT ', ' + LTRIM(RTRIM(tifl_nombre)) FROM Ventas.TipoFlete WHERE tifl_tipofleteid IN" +
    " (SELECT lvtf_tipofleteid FROM Ventas.ListaVentasTipoFlete WHERE lvtf_listaventasid = lv.lpvt_listaprecioventaid AND lvtf_activo = 1)" +
    " FOR xml PATH ('')), 1, 2, '')) FLETE,	(SELECT	STUFF((SELECT ', ' + LTRIM(RTRIM(tiva_nombre)) FROM Cobranza.TipoIVA" +
    " WHERE tiva_tipoivaid IN (SELECT lvti_tipoivaid  FROM Ventas.ListaVentasTipoIva  WHERE lvti_listaventaid = lv.lpvt_listaprecioventaid AND lvti_activo = 1)	FOR xml PATH ('')), 1, 2, ''))" +
    " IVA, lv.lpvt_estemporal," +
    " CASE WHEN lv.lpvt_estemporal = 1 AND lp.lpba_estatus <> 2 THEN" +
    " (SELECT COUNT(clie_clienteid) AS TOTAL FROM Cliente.Cliente WHERE clie_clienteid NOT IN" +
    "(SELECT  lcd.lvcl_clienteid FROM Ventas.ListaPreciosVenta lpv" +
    " JOIN Ventas.ListaVentasCliente lcd ON lpv.lpvt_listaprecioventaid = lcd.lvcl_listaprecioventasid  WHERE lpv.lpvt_listapreciosbaseid = " + idListaBase.ToString +
    " AND lcd.lvcl_activo = 1 AND lvcl_activo = 1) AND clie_activo = 1)" +
    " WHEN lv.lpvt_estemporal = 1 AND lp.lpba_estatus = 2 " +
    " THEN (SELECT COUNT(clie_clienteid) AS TOTAL FROM Cliente.Cliente WHERE clie_clienteid IN (SELECT lcd.lvcl_clienteid" +
    " FROM Ventas.ListaPreciosVenta lpv JOIN Ventas.ListaVentasCliente lcd ON lpv.lpvt_listaprecioventaid = lcd.lvcl_listaprecioventasid WHERE lpv.lpvt_listapreciosbaseid = " + idListaBase.ToString +
    " AND lcd.lvcl_activo = 1" +
    " AND lpv.lpvt_estemporal = 1)" +
    " AND clie_activo = 1)" +
    " WHEN lv.lpvt_estemporal = 0 THEN COUNT(lc.lvcl_clienteid)" +
    " END AS CLIENTES, e.even_eventoid, e.even_nombre" +
    " FROM Ventas.ListaPreciosVenta lv" +
    " JOIN Ventas.ListaPreciosBase lp" +
    " ON lv.lpvt_listapreciosbaseid = lp.lpba_listapreciosbaseid" +
    " LEFT JOIN Ventas.ListaVentasCliente lc" +
    " ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" +
    " AND lc.lvcl_activo = 1  AND lc.lvcl_clienteid NOT IN (SELECT cvl.clie_clienteid FROM Cliente.Cliente cvl  WHERE cvl.clie_activo=0)" +
    " LEFT JOIN Ventas.Eventos e" +
    " ON lv.lpvt_eventoid = e.even_eventoid" +
    " WHERE lv.lpvt_listapreciosbaseid = " + idListaBase.ToString +
    " GROUP BY	lpba_estatus, lpvt_listaprecioventaid, lpvt_listapreciosbaseid, lpvt_codigolistaventa," +
            " lpvt_descripcion, lpvt_incrementoporpar, lpvt_porcentaje, lpvt_vigenciainicio," +
            " lpvt_vigenciafin, lpvt_facturacioninicio, lpvt_facturacionfin, lpvt_descuentoinicio, lpvt_descuentofin," +
            " lpvt_fechacreacion, lpvt_usuariocreo, lpvt_fechamodificacion, lpvt_usuariomodifico," +
            " lpvt_activo, lpvt_estemporal, e.even_eventoid, e.even_nombre "
        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Function consutaListaVentasDetalle(ByVal idListaVentas As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT lb.lpba_listapreciosbaseid, lb.lpba_codigolistabase," +
            " lb.lpba_nombrelista, lb.lpba_estatus, lv.lpvt_listaprecioventaid," +
            " lv.lpvt_listapreciosbaseid, lv.lpvt_codigolistaventa, lv.lpvt_descripcion," +
            " lv.lpvt_incrementoporpar, lv.lpvt_porcentaje, lv.lpvt_vigenciainicio," +
            " lv.lpvt_vigenciafin, lv.lpvt_facturacioninicio, lv.lpvt_facturacionfin," +
            " lv.lpvt_descuentoinicio, lv.lpvt_descuentofin, lv.lpvt_activo," +
            " lv.lpvt_estemporal, lv.lpvt_eventoid" +
" FROM Ventas.ListaPreciosBase lb" +
" JOIN Ventas.ListaPreciosVenta lv ON lb.lpba_listapreciosbaseid = lv.lpvt_listapreciosbaseid" +
        " WHERE lv.lpvt_listaprecioventaid = " + idListaVentas.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaListaVentaClientes(ByVal idlistaVentas As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT 1 AS Seleccion, clie_clienteid," +
                " clie_idsicy, clie_nombregenerico, iccl_tipoivaid AS idIvaAntes," +
                " iccl_tipoivaid, tiva_nombre, iccl_facturar AS FacturarAntes," +
                " iccl_facturar, iccl_tipofleteid, tifl_nombre," +
                " iccl_monedaid, mone_nombre," +
                " SUM(decl_cantidaddescuento) AS Descuento," +
                " 1 AS registroAnt," +
                " (SELECT COUNT(cflv_conficlientefletelistaventa) AS contFlete FROM Ventas.ClienteFleteListaVentas WHERE cflv_clienteid = clientes.clie_clienteid AND cflv_activo = 1)" +
                " + (SELECT COUNT(cfav_clientefacturacionid) AS contFact FROM Ventas.ClienteFacturacionListaVentas WHERE cfav_clienteid = clientes.clie_clienteid AND cfav_activo = 1)" +
                " + (SELECT COUNT(cdlv_clientedescuentoid) AS contDesc FROM Ventas.ClienteDescuentosListaVentas WHERE cdlv_clienteid = clientes.clie_clienteid AND cdlv_activo = 1)" +
                " + (SELECT COUNT(cilv_tipoivaclienteid) AS contIva FROM Ventas.ClienteIVAListaVentas WHERE cilv_clienteid = clientes.clie_clienteid AND cilv_activo = 1)" +
                " AS Configuracion" +
            " FROM (SELECT" +
                " c.clie_clienteid, c.clie_idsicy, c.clie_nombregenerico, i.iccl_tipoivaid," +
                " v.tiva_nombre, i.iccl_facturar, i.iccl_tipofleteid, f.tifl_nombre," +
                " i.iccl_monedaid, m.mone_nombre, d.decl_descuentosclienteid," +
                " CASE" +
                    " WHEN d.decl_cantidaddescuento IS NULL THEN 0" +
                    " ELSE d.decl_cantidaddescuento" +
                " END AS decl_cantidaddescuento" +
            " FROM Ventas.ListaVentasCliente lv" +
            " JOIN Cliente.Cliente c" +
                " ON lv.lvcl_clienteid = c.clie_clienteid" +
            " LEFT JOIN Cobranza.InfoCliente i" +
                " ON c.clie_clienteid = i.iccl_clienteid" +
            " LEFT JOIN Cobranza.DescuentosCliente d" +
                " ON c.clie_clienteid = d.decl_clienteid" +
                " AND d.decl_activo = 1" +
            " JOIN Cobranza.TipoIVA v" +
                " ON i.iccl_tipoivaid = v.tiva_tipoivaid" +
            " JOIN Ventas.TipoFlete AS f" +
                " ON f.tifl_tipofleteid = i.iccl_tipofleteid" +
            " JOIN Framework.Moneda m" +
                " ON m.mone_monedaid = i.iccl_monedaid" +
                    " WHERE c.clie_activo = 1 AND c.clie_statuscliente = 'C'" +
            " AND i.iccl_activo = 1" +
            " AND lv.lvcl_activo = 1" +
            " AND v.tiva_activo = 1" +
            " AND lv.lvcl_listaprecioventasid = " + idlistaVentas.ToString +
            " GROUP BY	c.clie_clienteid," +
                        " c.clie_idsicy," +
                        " c.clie_nombregenerico," +
                        " i.iccl_tipoivaid," +
                        " v.tiva_nombre," +
                        " i.iccl_facturar," +
                        " i.iccl_tipofleteid," +
                        " f.tifl_nombre," +
                        " i.iccl_monedaid," +
                        " m.mone_nombre," +
                        " d.decl_descuentosclienteid," +
                        " decl_cantidaddescuento) AS clientes" +
            " GROUP BY	clie_clienteid," +
                        " clie_idsicy," +
                        " clie_nombregenerico," +
                        " iccl_tipoivaid," +
                        " tiva_nombre," +
                        " iccl_facturar," +
                        " iccl_tipofleteid," +
                        " tifl_nombre," +
                        " iccl_monedaid," +
                    " mone_nombre "
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaListaVentaTemporal(ByVal idListaBase As Int32, ByVal idEstatus As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = " SELECT	0 AS Seleccion,	clie_clienteid,	clie_idsicy, clie_nombregenerico,"
        ''" (SELECT ISNULL(lpvt_codigolistaventa, '') FROM Ventas.ListaPreciosVenta WHERE lpvt_listaprecioventaid = (" +
        ''" SELECT MAX(lv.lpvt_listaprecioventaid) FROM Ventas.ListaPreciosVenta lv " +
        ''" JOIN Ventas.ListaVentasCliente lc ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" +
        ''" WHERE lc.lvcl_activo = 0 AND lv.lpvt_listapreciosbaseid = " + idListaBase.ToString + " AND lvcl_clienteid = clientes.clie_clienteid)) AS lvAnterior," 
        cadena += " (SELECT ISNULL(lpvt_codigolistaventa, '') FROM Ventas.ListaPreciosVenta" +
   " WHERE lpvt_listaprecioventaid = (SELECT TOP 1 lv.lpvt_listaprecioventaid" +
   " FROM Ventas.ListaPreciosVenta lv" +
   " JOIN Ventas.ListaVentasCliente lc ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" +
   " WHERE lv.lpvt_listapreciosbaseid = " + idListaBase.ToString +
   " AND lvcl_clienteid = clientes.clie_clienteid" +
   " AND lc.lvcl_activo= 0" +
   " ORDER BY lc.lvcl_fechacreacion DESC))" +
   " AS lvAnterior,"
        cadena += " iccl_monedaid,	mone_nombre, iccl_tipoivaid AS idIvaAntes, iccl_tipoivaid, tiva_nombre,	iccl_tipofleteid," +
    " tifl_nombre, iccl_facturar AS FacturarAntes, iccl_facturar," +
                            " SUM(decl_cantidaddescuento) AS Descuento," +
                            " 0 AS registroAnt, 0 AS Configuracion" +
                        " FROM (SELECT" +
                            " c.clie_clienteid, c.clie_idsicy, c.clie_nombregenerico," +
                            " i.iccl_tipoivaid, v.tiva_nombre, i.iccl_facturar," +
                            " i.iccl_tipofleteid,	tifl_nombre, i.iccl_monedaid," +
                            " mone_nombre, d.decl_descuentosclienteid," +
                            " CASE" +
                                " WHEN d.decl_cantidaddescuento IS NULL THEN 0" +
                                " ELSE d.decl_cantidaddescuento" +
                            " END AS decl_cantidaddescuento" +
                        " FROM Cliente.Cliente c" +
                        " LEFT JOIN Cobranza.InfoCliente i" +
                            " ON c.clie_clienteid = i.iccl_clienteid" +
                        " LEFT JOIN Cobranza.DescuentosCliente d" +
                            " ON c.clie_clienteid = d.decl_clienteid" +
                            " AND d.decl_activo = 1" +
                        " LEFT JOIN Cobranza.TipoIVA v" +
                            " ON i.iccl_tipoivaid = v.tiva_tipoivaid" +
                            " AND i.iccl_activo = 1" +
                        " LEFT JOIN Ventas.TipoFlete AS f" +
                            " ON f.tifl_tipofleteid = i.iccl_tipofleteid" +
                        " LEFT JOIN Framework.Moneda m" +
                            " ON m.mone_monedaid = i.iccl_monedaid" +
                                " WHERE c.clie_activo = 1 AND c.clie_statuscliente = 'C'"
        If idEstatus <> 2 Then
            cadena += " AND c.clie_clienteid NOT IN (SELECT lcd.lvcl_clienteid FROM Ventas.ListaPreciosVenta lpv JOIN Ventas.ListaVentasCliente lcd" +
                            " ON lpv.lpvt_listaprecioventaid = lcd.lvcl_listaprecioventasid" +
                            " WHERE lpv.lpvt_listapreciosbaseid = " + idListaBase.ToString +
                            " AND lcd.lvcl_activo = 1 )"
        Else
            cadena += "AND c.clie_clienteid  IN (SELECT lcd.lvcl_clienteid FROM Ventas.ListaPreciosVenta lpv JOIN Ventas.ListaVentasCliente lcd" +
                          " ON lpv.lpvt_listaprecioventaid = lcd.lvcl_listaprecioventasid" +
                          " WHERE lpv.lpvt_listapreciosbaseid = " + idListaBase.ToString +
                          " AND lpv.lpvt_estemporal = 1 AND lcd.lvcl_activo = 1)"
        End If

        cadena += " GROUP BY	c.clie_clienteid, c.clie_idsicy, c.clie_nombregenerico," +
                                    " i.iccl_tipoivaid, v.tiva_nombre, i.iccl_facturar," +
                                    " iccl_tipofleteid, tifl_nombre, iccl_monedaid, " +
                                    " mone_nombre,	d.decl_descuentosclienteid," +
                                    " decl_cantidaddescuento) AS clientes" +
                        " GROUP BY	clie_clienteid, clie_idsicy, clie_nombregenerico," +
                                    " iccl_tipoivaid, tiva_nombre, iccl_facturar," +
                                " iccl_tipofleteid, tifl_nombre, iccl_monedaid," +
                                " mone_nombre" +
                        " ORDER BY Seleccion DESC, clie_nombregenerico"



        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaListaVentaMasClientes(ByVal idlistaVentas As Int32,
                                                  ByVal descuentoInicio As String, ByVal descuentoFin As String,
                                             ByVal facturacionInicio As String, ByVal facturacionFin As String,
                                             ByVal tipoIva As String, ByVal tipoFlete As String, ByVal idListaBaseid As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim cadena As String = ""
        cadena = "SELECT 1 AS Seleccion, LISTAVENTACLIENTE,	LISTAVENTA,	clie_clienteid,	clie_idsicy, clie_nombregenerico,"

        cadena += " (SELECT ISNULL(lpvt_codigolistaventa, '') FROM Ventas.ListaPreciosVenta" +
    " WHERE lpvt_listaprecioventaid = (SELECT TOP 1 lv.lpvt_listaprecioventaid" +
    " FROM Ventas.ListaPreciosVenta lv" +
    " JOIN Ventas.ListaVentasCliente lc ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" +
    " WHERE lv.lpvt_listapreciosbaseid = " + idListaBaseid.ToString +
    " AND lvcl_clienteid = clientes.clie_clienteid" +
    " AND lc.lvcl_activo= 0" +
    " ORDER BY lc.lvcl_fechacreacion DESC)  AND lpvt_estemporal = 0)" +
    " AS lvAnterior,"

        cadena += " iccl_monedaid, mone_nombre, iccl_tipoivaid AS idIvaAntes,	iccl_tipoivaid," +
                " tiva_nombre, iccl_tipofleteid, tifl_nombre, iccl_facturar AS FacturarAntes,	iccl_facturar," +
                " SUM(decl_cantidaddescuento) AS Descuento," +
                " 1 AS registroAnt," +
                " (SELECT COUNT(ccla_clienteconfiguracionlistaactivaid) AS contFlete FROM Ventas.ClienteConfiguracionListaActiva WHERE ccla_clienteid = clientes.clie_clienteid AND ccla_activo = 1 AND ccla_listaventasid = " + idlistaVentas.ToString + ")" +
                " + (SELECT COUNT(cdlv_clientedescuentoid) AS contDesc FROM Ventas.ClienteDescuentosListaVentas WHERE cdlv_clienteid = clientes.clie_clienteid AND cdlv_activo = 1 AND cdvl_listaventasid = " + idlistaVentas.ToString + ")" +
                " AS Configuracion," +
                " (SELECT COUNT(lvcp_listaventasclienteprecioid) AS totalListas FROM Ventas.ListaVentasClientePrecio WHERE lvcp_listaventasclienteid = LISTAVENTACLIENTE AND lvcp_activo = 1 AND lvcp_estatusid IN (25, 26)) AS LPVCS " +
                " FROM (SELECT lv.lvcl_listaventasclienteid AS LISTAVENTACLIENTE,	lv.lvcl_listaprecioventasid AS LISTAVENTA," +
                " c.clie_clienteid, c.clie_idsicy,	c.clie_nombregenerico,	i.iccl_monedaid, m.mone_nombre,	" +
                " i.iccl_tipoivaid, v.tiva_nombre, i.iccl_tipofleteid, " +
                " f.tifl_nombre,	i.iccl_facturar, d.decl_descuentosclienteid," +
                " CASE" +
                " WHEN d.decl_cantidaddescuento IS NULL THEN 0" +
                " ELSE d.decl_cantidaddescuento" +
                " END AS decl_cantidaddescuento" +
                " FROM Ventas.ListaVentasCliente lv" +
                " JOIN Cliente.Cliente c ON lv.lvcl_clienteid = c.clie_clienteid" +
                " LEFT JOIN Cobranza.InfoCliente i ON c.clie_clienteid = i.iccl_clienteid" +
                " LEFT JOIN Cobranza.DescuentosCliente d ON c.clie_clienteid = d.decl_clienteid AND d.decl_activo = 1" +
                " JOIN Cobranza.TipoIVA v	ON i.iccl_tipoivaid = v.tiva_tipoivaid" +
                " JOIN Ventas.TipoFlete AS f	ON f.tifl_tipofleteid = i.iccl_tipofleteid" +
                " JOIN Framework.Moneda m	ON m.mone_monedaid = i.iccl_monedaid" +
                " WHERE c.clie_activo = 1 AND c.clie_statuscliente = 'C'" +
                " AND i.iccl_activo = 1 AND  lv.lvcl_activo = 1" +
                " AND v.tiva_activo = 1 AND lv.lvcl_listaprecioventasid = " + idlistaVentas.ToString +
                " GROUP BY	lv.lvcl_listaventasclienteid, lv.lvcl_listaprecioventasid, c.clie_clienteid," +
                " c.clie_idsicy, c.clie_nombregenerico, i.iccl_monedaid,	m.mone_nombre, lv.lvcl_descripcion, " +
                " i.iccl_tipoivaid, v.tiva_nombre, i.iccl_tipofleteid, f.tifl_nombre, i.iccl_facturar," +
                " d.decl_descuentosclienteid,	decl_cantidaddescuento) AS clientes" +
                " GROUP BY	LISTAVENTACLIENTE, LISTAVENTA, clie_clienteid," +
                " clie_idsicy, clie_nombregenerico, iccl_monedaid," +
                " mone_nombre, iccl_tipoivaid," +
                " tiva_nombre, iccl_tipofleteid, tifl_nombre, iccl_facturar" +
                " UNION" +
                " SELECT 0 AS Seleccion,	LISTAVENTACLIENTE, LISTAVENTA," +
                " clie_clienteid,	clie_idsicy, clie_nombregenerico,"
        '" (SELECT ISNULL(lpvt_codigolistaventa, '') FROM Ventas.ListaPreciosVenta WHERE lpvt_listaprecioventaid = (" +
        '" SELECT MAX(lv.lpvt_listaprecioventaid) FROM Ventas.ListaPreciosVenta lv" +
        '" JOIN Ventas.ListaVentasCliente lc ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" +
        '" WHERE lc.lvcl_activo = 0 AND lv.lpvt_listapreciosbaseid = " + idListaBaseid.ToString + " AND lvcl_clienteid = clientes.clie_clienteid)) AS lvAnterior," +

        cadena += " (SELECT ISNULL(lpvt_codigolistaventa, '') FROM Ventas.ListaPreciosVenta" +
    " WHERE lpvt_listaprecioventaid = (SELECT TOP 1 lv.lpvt_listaprecioventaid" +
    " FROM Ventas.ListaPreciosVenta lv" +
    " JOIN Ventas.ListaVentasCliente lc ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" +
    " WHERE lv.lpvt_listapreciosbaseid = " + idListaBaseid.ToString +
    " AND lvcl_clienteid = clientes.clie_clienteid" +
    " AND lc.lvcl_activo= 0" +
    " ORDER BY lc.lvcl_fechacreacion DESC))" +
    " AS lvAnterior,"


        cadena += " iccl_monedaid, mone_nombre," +
        " iccl_tipoivaid AS idIvaAntes, iccl_tipoivaid," +
        " tiva_nombre, iccl_tipofleteid, tifl_nombre," +
        " iccl_facturar AS FacturarAntes,	iccl_facturar," +
        " SUM(decl_cantidaddescuento) AS Descuento," +
        " 0 AS registroAnt, 0 AS Configuracion," +
        " 0 AS LPVCS" +
        " FROM (SELECT" +
        " 0 AS LISTAVENTACLIENTE,	0 AS LISTAVENTA," +
        " c.clie_clienteid, c.clie_idsicy, c.clie_nombregenerico," +
        " iccl_monedaid, mone_nombre," +
        " i.iccl_tipoivaid, v.tiva_nombre, iccl_tipofleteid," +
        " tifl_nombre, i.iccl_facturar, d.decl_descuentosclienteid," +
        " CASE" +
        " WHEN d.decl_cantidaddescuento IS NULL THEN 0" +
        " ELSE d.decl_cantidaddescuento" +
        " END AS decl_cantidaddescuento" +
        " FROM Cliente.Cliente c" +
        " LEFT JOIN Cobranza.InfoCliente i ON c.clie_clienteid = i.iccl_clienteid" +
        " LEFT JOIN Cobranza.DescuentosCliente d ON c.clie_clienteid = d.decl_clienteid AND d.decl_activo = 1" +
        " JOIN Cobranza.TipoIVA v	ON i.iccl_tipoivaid = v.tiva_tipoivaid" +
        " JOIN Ventas.TipoFlete AS f ON f.tifl_tipofleteid = i.iccl_tipofleteid" +
        " JOIN Framework.Moneda m	ON m.mone_monedaid = i.iccl_monedaid" +
        " WHERE c.clie_activo = 1 AND c.clie_statuscliente = 'C' And i.iccl_activo = 1" +
        " AND c.clie_clienteid NOT IN (SELECT	lcd.lvcl_clienteid FROM Ventas.ListaPreciosVenta lvp" +
        " JOIN Ventas.ListaVentasCliente lcd ON lvp.lpvt_listaprecioventaid = lcd.lvcl_listaprecioventasid" +
        " WHERE lcd.lvcl_activo = 1" +
        " AND lvp.lpvt_listapreciosbaseid =  " + idListaBaseid.ToString +
        " AND lvp.lpvt_estemporal = 0)" +
        " AND i.iccl_tipofleteid IN (" + tipoFlete + ")" +
        " AND i.iccl_tipoivaid IN (" + tipoIva + ")" +
        " AND i.iccl_facturar BETWEEN " + facturacionInicio.ToString + " AND " + facturacionFin.ToString +
        " GROUP BY	c.clie_clienteid, c.clie_idsicy, c.clie_nombregenerico," +
        " i.iccl_monedaid, m.mone_nombre,	i.iccl_tipoivaid, v.tiva_nombre, i.iccl_tipofleteid, f.tifl_nombre," +
        " i.iccl_facturar, d.decl_descuentosclienteid, decl_cantidaddescuento) AS clientes" +
        " GROUP BY	LISTAVENTACLIENTE, LISTAVENTA,	clie_clienteid, clie_idsicy, clie_nombregenerico," +
        " iccl_monedaid, mone_nombre, iccl_tipoivaid, tiva_nombre," +
        " iccl_tipofleteid, tifl_nombre, iccl_facturar" +
        " HAVING SUM(decl_cantidaddescuento) BETWEEN " + descuentoInicio.ToString + " AND " + descuentoFin.ToString +
        " ORDER BY Seleccion DESC, clie_nombregenerico"

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaFletes(ByVal fletes As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " tifl_tipofleteid," +
                                " tifl_nombre" +
                                " FROM Ventas.TipoFlete" +
                        " WHERE tifl_activo = 1 AND tifl_tipofleteid IN (" + fletes + ")"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaDescuentos() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " md.mode_motivodescuentoid," +
                                " md.mode_nombre," +
                                " ld.lude_lugardescuentoid," +
                                " ld.lude_nombre" +
                        " FROM Cobranza.MotivoDescuento md" +
                        " CROSS JOIN Cobranza.LugarDescuento ld" +
                                " WHERE mode_activo = 1" +
                        " AND lude_activo = 1" +
                        " ORDER BY md.mode_nombre, lude_nombre"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaClienteFleteCambioConf(ByVal fleteQuitar As String, ByVal fletes As String, ByVal idListaCliente As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""

        cadena = "SELECT iccl_clienteid FROM Cobranza.InfoCliente WHERE iccl_tipofleteid IN (" + fleteQuitar + ")" +
        " AND iccl_clienteid NOT IN (SELECT iccl_clienteid FROM Cobranza.InfoCliente WHERE iccl_tipofleteid IN (" + fletes + ") GROUP BY iccl_clienteid)" +
        " AND iccl_clienteid IN (SELECT lvcl_clienteid FROM Ventas.ListaVentasCliente WHERE lvcl_listaprecioventasid = " + idListaCliente.ToString + " AND lvcl_activo = 1)" +
        " GROUP BY iccl_clienteid ORDER BY iccl_clienteid"

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verDatosConfiguradosListaClienteActiva(ByVal idCliente As Int32, ByVal idListaVentas As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String
        cadena = "SELECT cc.ccla_clienteconfiguracionlistaactivaid," +
                " cc.ccla_clienteid, cl.clie_nombregenerico, ti.tiva_tipoivaid," +
                " ti.tiva_nombre, tf.tifl_tipofleteid, tf.tifl_nombre, cc.ccla_facturar" +
                " FROM Ventas.ClienteConfiguracionListaActiva cc" +
                " JOIN Cliente.Cliente cl	ON cc.ccla_clienteid = cl.clie_clienteid" +
                " LEFT JOIN Cobranza.TipoIVA ti ON cc.ccla_tipoivaid = ti.tiva_tipoivaid" +
                " LEFT JOIN Ventas.TipoFlete tf ON cc.ccla_tipofleteid = tf.tifl_tipofleteid" +
                " WHERE cl.clie_clienteid = " + idCliente.ToString +
                " AND cc.ccla_listaventasid = " + idListaVentas.ToString +
                " AND cc.ccla_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaListasVentaLB(ByVal idListaBase As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT lpvt_listaprecioventaid, lpvt_listapreciosbaseid, lpvt_codigolistaventa, lpvt_descripcion," +
        " lpvt_incrementoporpar, lpvt_porcentaje, lpvt_vigenciainicio, lpvt_vigenciafin, lpvt_facturacioninicio," +
        " lpvt_facturacionfin, lpvt_descuentoinicio, lpvt_descuentofin, lpvt_estemporal, lpvt_eventoid, lpvt_activo" +
        " FROM Ventas.ListaPreciosVenta WHERE lpvt_listapreciosbaseid = " + idListaBase.ToString + " AND lpvt_estemporal = 0 ORDER BY lpvt_descripcion, lpvt_vigenciainicio DESC"
        Return operacion.EjecutaConsulta(cadena)
    End Function


    ''Public Function verListaVentasConsultaSimple(ByVal idListaBase As Int32) As DataTable
    ''    Dim operacion As New Persistencia.OperacionesProcedimientos
    ''    Dim cadena As String = "SELECT" +
    ''                            " lpvt_listaprecioventaid," +
    ''                            " lpvt_codigolistaventa + ' - ' + lpvt_descripcion AS LISTAVENTAS" +
    ''                                " FROM Ventas.ListaPreciosVenta" +
    ''                                " WHERE lpvt_listapreciosbaseid = " + idListaBase.ToString +
    ''                        " AND lpvt_activo = 1 AND lpvt_estemporal = 0"
    ''    Return operacion.EjecutaConsulta(cadena)
    ''End Function

    ''Public Function consultaIVAConfiguradoCliente(ByVal idCliente As Int32) As String
    ''    Dim operacion As New Persistencia.OperacionesProcedimientos
    ''    Dim dtDatos As New DataTable
    ''    Dim cadena As String = "SELECT" +
    ''                            " it.tiva_tipoivaid," +
    ''                            " it.tiva_nombre" +
    ''                    " FROM Ventas.ClienteIVAListaVentas ci" +
    ''                    " JOIN Cobranza.TipoIVA it" +
    ''                        " ON ci.cilv_tipoivaid = it.tiva_tipoivaid" +
    ''                            " WHERE cilv_clienteid = " + idCliente.ToString +
    ''                    " AND cilv_activo = 1"
    ''    Dim dato As String = ""
    ''    dtDatos = operacion.EjecutaConsulta(cadena)
    ''    If dtDatos.Rows.Count > 0 Then
    ''        dato = dtDatos.Rows(0).Item("tiva_nombre").ToString.Trim
    ''    End If
    ''    Return dato
    ''End Function

    ''Public Function consultaFacturacionConfiguracionCliente(ByVal idCliente As Int32) As DataTable
    ''    Dim operacion As New Persistencia.OperacionesProcedimientos
    ''    Dim cadena As String = "SELECT" +
    ''                            " cfav_clienteid," +
    ''                            " cfav_facturar," +
    ''                            " cfav_porcentajeFacturar" +
    ''                            " FROM Ventas.ClienteFacturacionListaVentas" +
    ''                            " WHERE cfav_clienteid = " + idCliente.ToString +
    ''                    " AND cfav_activo = 1"
    ''    Return operacion.EjecutaConsulta(cadena)
    ''End Function

    ''Public Function consultaFletesConfiguracionCliente(ByVal idCliente As Int32) As DataTable
    ''    Dim operacion As New Persistencia.OperacionesProcedimientos
    ''    Dim cadena As String = "SELECT" +
    ''                            " fl.cflv_tipofleteid," +
    ''                            " tf.tifl_nombre" +
    ''                    " FROM Ventas.ClienteFleteListaVentas fl" +
    ''                    " JOIN Ventas.TipoFlete tf" +
    ''                        " ON fl.cflv_tipofleteid = tf.tifl_tipofleteid" +
    ''                            " WHERE cflv_clienteid = " + idCliente.ToString +
    ''                    " AND cflv_activo = 1"
    ''    Return operacion.EjecutaConsulta(cadena)
    ''End Function

    Public Function consultaDescuentosConfiguracionCliente(ByVal idCliente As Int32, ByVal idListaVentas As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " cd.cdlv_clienteid," +
                                " cd.cdlv_lugardescuentoid," +
                                " md.mode_motivodescuentoid," +
                                " md.mode_nombre," +
                                " ld.lude_nombre," +
                                " cd.cdlv_cantidad," +
                                " cd.cdlv_encadenado," +
                                " cd.cdlv_porcentaje," +
                                " cd.cdlv_diasvigencia" +
                        " FROM Ventas.ClienteDescuentosListaVentas cd" +
                        " JOIN Cobranza.MotivoDescuento md" +
                            " ON cd.cdlv_tipodescuentoid = md.mode_motivodescuentoid" +
                        " JOIN Cobranza.LugarDescuento ld" +
                            " ON cd.cdlv_lugardescuentoid = ld.lude_lugardescuentoid" +
                        " WHERE cd.cdlv_clienteid = " + idCliente.ToString +
                        " AND cd.cdvl_listaventasid = " + idListaVentas.ToString +
                        " AND cd.cdlv_activo= 1" +
                        " AND ld.lude_activo = 1" +
                        " AND md.mode_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaListaVentasClienteSimple() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""

        'cadena = "SELECT lvcl_listaprecioventasid, lvcl_listaventasclienteid," +
        '                " lvcl_clienteid, cc.clie_idsicy, cc.clie_nombregenerico" +
        '                " FROM Ventas.ListaVentasCliente lc" +
        '                " JOIN Cliente.Cliente cc ON lc.lvcl_clienteid = cc.clie_clienteid" +
        '                " WHERE lvcl_listaprecioventasid = " + idListaVentas.ToString +
        '                " AND lvcl_activo = 1" +
        '                " AND cc.clie_activo = 1" +
        '                " ORDER BY clie_nombregenerico"
        cadena = "SELECT cc.clie_clienteid, cc.clie_idsicy, cc.clie_nombregenerico " +
                " FROM Cliente.Cliente cc WHERE cc.clie_activo = 1 and AND cc.clie_statuscliente = 'C'" +
                " ORDER BY clie_nombregenerico"

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaEventos() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT even_eventoid, 	even_nombre + ' (Del ' + CONVERT(VARCHAR(20), even_fechainicioevento, 5) + ' Al ' + CONVERT(VARCHAR(20), even_fechafinevento, 5)+' En '+even_lugar + ')' AS EVENTO," +
                " even_fechainicioevento, even_fechafinevento, even_activo FROM Ventas.Eventos WHERE even_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function validarListaVentasEvento(ByVal idListaBase As Int32, ByVal idEvento As Int32) As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtContarTotal As New DataTable
        Dim contTotal As Int32 = 0
        Dim cadena As String = ""
        cadena = "SELECT COUNT(lpvt_listaprecioventaid) FROM Ventas.ListaPreciosVenta" +
            " WHERE lpvt_listapreciosbaseid = " + idListaBase.ToString +
            " AND lpvt_eventoid = " + idEvento.ToString
        dtContarTotal = operacion.EjecutaConsulta(cadena)
        If dtContarTotal.Rows.Count > 0 Then
            contTotal = dtContarTotal.Rows(0).Item(0)
        Else
            contTotal = 0
        End If
        Return contTotal
    End Function

    '{---------------------------------------- Consultas --------------------------------------}'
    '{-----------------------------------------------------------------------------------------}'
    '{----------------------------------------- Acciones --------------------------------------}'

    Public Sub registrarIvaFlete(ByVal idListaVentasid As Int32, ByVal idCatalogo As Int32, ByVal catalogo As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idListaVentasid"
        parametro.Value = idListaVentasid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idCatalogo"
        parametro.Value = idCatalogo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@catalogo"
        parametro.Value = catalogo
        listaParametros.Add(parametro)

        operacion.EjecutarConsultaSP("Ventas.SP_AltaCatalogosSimplesListaVentas", listaParametros)

    End Sub

    Public Sub registrarClienteListaVentas(ByVal listaVentasid As Int32, ByVal clienteid As Int32, ByVal listabase As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@listaVentasid"
        parametro.Value = listaVentasid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clienteid"
        parametro.Value = clienteid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@listabase"
        parametro.Value = listabase
        listaParametros.Add(parametro)

        operacion.EjecutarConsultaSP("Ventas.SP_AltaClientesListaVentas", listaParametros)
    End Sub

    '' ''Public Sub guardarDescripcionListaCliente(ByVal idlistaventascliente As Int32, ByVal descripcion As String)
    '' ''    Dim operacion As New Persistencia.OperacionesProcedimientos
    '' ''    Dim listaParametros As New List(Of SqlParameter)
    '' ''    Dim parametro As New SqlParameter
    '' ''    parametro.ParameterName = "@idlistaventascliente"
    '' ''    parametro.Value = idlistaventascliente
    '' ''    listaParametros.Add(parametro)

    '' ''    parametro = New SqlParameter
    '' ''    parametro.ParameterName = "@descripcion"
    '' ''    parametro.Value = descripcion
    '' ''    listaParametros.Add(parametro)

    '' ''    parametro = New SqlParameter
    '' ''    parametro.ParameterName = "@usuario"
    '' ''    parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    '' ''    listaParametros.Add(parametro)

    '' ''    operacion.EjecutarSentenciaSP("Ventas.SP_CambiarDescripcionListaCliente", listaParametros)
    '' ''End Sub

    Public Sub guardarClienteConfiguraionListaActiva(ByVal idListaVentas As Int32, ByVal idCliente As Int32,
                                                     ByVal idCat As Int32, ByVal cantidad As Double,
                                                     ByVal accion As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idListaVentas"
        parametro.Value = idListaVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idCat"
        parametro.Value = idCat
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cantidad"
        parametro.Value = cantidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@accion"
        parametro.Value = accion
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Ventas.SP_AltaConfiguracionClienteListaVentasActiva", listaParametros)
    End Sub

    ''Public Sub inactivarConfClienteFlete(ByVal idListaVentas As Int32, ByVal idCliente As Int32)
    ''    Dim operacion As New Persistencia.OperacionesProcedimientos
    ''    Dim cadena As String = " UPDATE Ventas.ClienteFleteListaVentas" +
    ''                            " SET cflv_activo = 0, cflv_usuariomodifico = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + "," +
    ''                            " cflv_fechamodifico = GETDATE()" +
    ''                            " WHERE cflv_listaventasid = " + idListaVentas.ToString +
    ''                            " AND cflv_clienteid = " + idCliente.ToString
    ''    operacion.EjecutaSentencia(cadena)
    ''End Sub

    ''Public Sub guardarClienteFletesConfiguraion(ByVal idListaVentas As Int32, ByVal idCliente As Int32, ByVal idFlete As Int32)
    ''    Dim operacion As New Persistencia.OperacionesProcedimientos
    ''    Dim listaParametros As New List(Of SqlParameter)

    ''    Dim parametro As New SqlParameter
    ''    parametro.ParameterName = "@idListaVentas"
    ''    parametro.Value = idListaVentas
    ''    listaParametros.Add(parametro)

    ''    parametro = New SqlParameter
    ''    parametro.ParameterName = "@idCliente"
    ''    parametro.Value = idCliente
    ''    listaParametros.Add(parametro)

    ''    parametro = New SqlParameter
    ''    parametro.ParameterName = "@idCat"
    ''    parametro.Value = idFlete
    ''    listaParametros.Add(parametro)

    ''    parametro = New SqlParameter
    ''    parametro.ParameterName = "@usuario"
    ''    parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    ''    listaParametros.Add(parametro)

    ''    parametro = New SqlParameter
    ''    parametro.ParameterName = "@accion"
    ''    parametro.Value = "FLETE"
    ''    listaParametros.Add(parametro)

    ''    operacion.EjecutarSentenciaSP("Ventas.SP_AltaConfiguracionClienteFleteIVA", listaParametros)
    ''End Sub

    ''Public Sub guardarClienteIVAConfiguraion(ByVal idListaVentas As Int32, ByVal idCliente As Int32, ByVal idIVA As Int32)
    ''    Dim operacion As New Persistencia.OperacionesProcedimientos
    ''    Dim listaParametros As New List(Of SqlParameter)

    ''    Dim parametro As New SqlParameter
    ''    parametro.ParameterName = "@idListaVentas"
    ''    parametro.Value = idListaVentas
    ''    listaParametros.Add(parametro)

    ''    parametro = New SqlParameter
    ''    parametro.ParameterName = "@idCliente"
    ''    parametro.Value = idCliente
    ''    listaParametros.Add(parametro)

    ''    parametro = New SqlParameter
    ''    parametro.ParameterName = "@idCat"
    ''    parametro.Value = idIVA
    ''    listaParametros.Add(parametro)

    ''    parametro = New SqlParameter
    ''    parametro.ParameterName = "@usuario"
    ''    parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    ''    listaParametros.Add(parametro)

    ''    parametro = New SqlParameter
    ''    parametro.ParameterName = "@accion"
    ''    parametro.Value = "IVA"
    ''    listaParametros.Add(parametro)

    ''    operacion.EjecutarSentenciaSP("Ventas.SP_AltaConfiguracionClienteFleteIVA", listaParametros)
    ''End Sub

    ''Public Sub inactivarConfClienteIVA(ByVal idListaVentas As Int32, ByVal idCliente As Int32)
    ''    Dim operacion As New Persistencia.OperacionesProcedimientos
    ''    Dim cadena As String = "UPDATE Ventas.ClienteIVAListaVentas" +
    ''                            " SET	cilv_activo = 0," +
    ''                                " cilv_usuariomodifico =" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + " ," +
    ''                                    " cilv_fechamodifico = GETDATE()" +
    ''                                    " WHERE cilv_listaventasid = " + idListaVentas.ToString +
    ''                            " AND cilv_clienteid = " + idCliente.ToString
    ''    operacion.EjecutaSentencia(cadena)
    ''End Sub

    ''Public Sub inactivarConfClienteFacturacion(ByVal idListaVentas As Int32, ByVal idCliente As Int32)
    ''    Dim operacion As New Persistencia.OperacionesProcedimientos
    ''    Dim cadena As String = "UPDATE Ventas.ClienteFacturacionListaVentas" +
    ''                            " SET cfav_activo = 0," +
    ''                                " cfav_usuariomodifico = 1," +
    ''                                    " cfav_fechamodifico = GETDATE()" +
    ''                                    " WHERE cfav_listaventasid = " + idListaVentas.ToString +
    ''                            " AND cfav_clienteid = " + idCliente.ToString
    ''    operacion.EjecutaSentencia(cadena)
    ''End Sub

    ''Public Sub guardarClienteFacturacion(ByVal idListaVentas As Int32, ByVal idCliente As Int32, ByVal porciento As Boolean, ByVal cantidad As String)
    ''    Dim operacion As New Persistencia.OperacionesProcedimientos
    ''    Dim listaParametros As New List(Of SqlParameter)

    ''    Dim parametro As New SqlParameter
    ''    parametro.ParameterName = "@idListaVentas"
    ''    parametro.Value = idListaVentas
    ''    listaParametros.Add(parametro)

    ''    parametro = New SqlParameter
    ''    parametro.ParameterName = "@idCliente"
    ''    parametro.Value = idCliente
    ''    listaParametros.Add(parametro)

    ''    parametro = New SqlParameter
    ''    parametro.ParameterName = "@porciento"
    ''    parametro.Value = porciento
    ''    listaParametros.Add(parametro)

    ''    parametro = New SqlParameter
    ''    parametro.ParameterName = "@cantidad"
    ''    parametro.Value = cantidad
    ''    listaParametros.Add(parametro)

    ''    parametro = New SqlParameter
    ''    parametro.ParameterName = "@usuario"
    ''    parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    ''    listaParametros.Add(parametro)

    ''    operacion.EjecutarSentenciaSP("Ventas.SP_AltaConfiguracionClienteFacturacion", listaParametros)
    ''End Sub

    Public Sub editarConfiguracionListaVentas(ByVal listaprecioventaid As Int32, ByVal facturacioninicio As String,
                                              ByVal facturacionfin As String, ByVal descuentoinicio As String,
                                              ByVal descuentofin As String)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@listaprecioventaid"
        parametro.Value = listaprecioventaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@facturacioninicio"
        parametro.Value = facturacioninicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@facturacionfin"
        parametro.Value = facturacionfin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@descuentoinicio"
        parametro.Value = descuentoinicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@descuentofin"
        parametro.Value = descuentofin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Ventas.SP_EditarListaVentas", listaParametros)

    End Sub

    Public Sub inactivarRelacionClienteListaVenta(ByVal idListaBase As Int32,
                                                  ByVal listaVentas As Int32,
                                                  ByVal listaVentasCliente As Int32,
                                                          ByVal idCliente As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@listabaseid"
        parametro.Value = idListaBase
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@listaVentasCliente"
        parametro.Value = listaVentasCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@listaVentas"
        parametro.Value = listaVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clienteid"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Ventas.SP_EditarRelacionListaVentasCliente", listaParametros)
    End Sub

    Public Sub inactivarCatalogosSimples(ByVal catalogo As String, ByVal listaprecioventaid As Int32, ByVal idCatalogo As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@listaprecioventaid"
        parametro.Value = listaprecioventaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idCatalogo"
        parametro.Value = idCatalogo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@catalogo"
        parametro.Value = catalogo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Ventas.SP_EditarRelacionCatalogoSimpleListaVentas", listaParametros)
    End Sub

    ''Public Sub inactivaRelacionFleteCliente(ByVal idListaVentasid As Int32, ByVal idCliente As Int32)
    ''    Dim operacion As New Persistencia.OperacionesProcedimientos
    ''    Dim listaParametros As New List(Of SqlParameter)

    ''    Dim parametro As New SqlParameter
    ''    parametro.ParameterName = "@idListaVentasid"
    ''    parametro.Value = idListaVentasid
    ''    listaParametros.Add(parametro)

    ''    parametro = New SqlParameter
    ''    parametro.ParameterName = "@idCliente"
    ''    parametro.Value = idCliente
    ''    listaParametros.Add(parametro)

    ''    parametro = New SqlParameter
    ''    parametro.ParameterName = "@usuario"
    ''    parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    ''    listaParametros.Add(parametro)

    ''    operacion.EjecutarSentenciaSP("Ventas.SP_EditarRelacionFleteListaVentas_Clientes", listaParametros)
    ''End Sub

    Public Sub inactivarConfClienteDescuento(ByVal idListaVentas As Int32, ByVal idCliente As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "UPDATE Ventas.ClienteDescuentosListaVentas" +
                                " SET	cdlv_activo = 0," +
                                    " cdlv_usuariomodifico = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + " ," +
                                        " cdlv_fechamodifico = GETDATE()" +
                                        " WHERE cdlv_clienteid = " + idCliente.ToString +
                                " AND cdvl_listaventasid = " + idListaVentas.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub guardarClienteDescuentoConfiguraion(ByVal idListaVentas As Int32, ByVal idCliente As Int32,
                                                   ByVal idDescuento As Int32, ByVal idlugar As Int32,
                                                   ByVal encadenado As Boolean, ByVal porcentaje As Boolean,
                                                   ByVal cantidad As String, ByVal dias As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idListaVentas"
        parametro.Value = idListaVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idDescuento"
        parametro.Value = idDescuento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idLugar"
        parametro.Value = idlugar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@encadenado"
        parametro.Value = encadenado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@porcentaje"
        parametro.Value = porcentaje
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@dias"
        parametro.Value = dias
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cantidad"
        parametro.Value = cantidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Ventas.SP_AltaConfiguracionClienteDescuento", listaParametros)
    End Sub

    Public Sub editarEncabezadoListaVentas(ByVal codListaVenta As String,
        ByVal descripcion As String, ByVal vigenciainicio As String,
        ByVal vigenciafin As String, ByVal listaventasid As Int32,
        ByVal porcentaje As Boolean, ByVal incrementoporpar As Double,
        ByVal editarInfocliente As Boolean, ByVal realizarEditar As Boolean)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@codListaVenta"
        parametro.Value = codListaVenta
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
        parametro.ParameterName = "@listaventasid"
        parametro.Value = listaventasid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@porcentaje"
        parametro.Value = porcentaje
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@incrementoporpar"
        parametro.Value = incrementoporpar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@editarInfocliente"
        parametro.Value = editarInfocliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@realizarEditar"
        parametro.Value = realizarEditar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Ventas.SP_EditarListaVentasEncabezado", listaParametros)
    End Sub

    Public Sub guardarPrestiloPrecio(ByVal idListaVentasid As Int32, ByVal productoestiloid As Int32,
                                     ByVal preciobase As Double, ByVal precio As Double)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idListaVentasid"
        parametro.Value = idListaVentasid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@productoestiloid"
        parametro.Value = productoestiloid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@preciobase"
        parametro.Value = preciobase
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@precio"
        parametro.Value = precio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Ventas.SP_GuardarListaVentasPrecio", listaParametros)
    End Sub

    Public Sub guardarCambiosVigenciaAlerta(ByVal vigenciaFin As String, ByVal idLista As Int32, ByVal tipoLista As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@vigenciaFin"
        parametro.Value = vigenciaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idLista"
        parametro.Value = idLista
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoLista"
        parametro.Value = tipoLista
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Ventas.SP_CambiarVigenciaFinListas", listaParametros)
    End Sub

    Public Sub guardarCambiosEstatusLVCPAlerta(ByVal estatus As String, ByVal idLista As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@estatus"
        parametro.Value = estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idLista"
        parametro.Value = idLista
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Ventas.SP_CambiarEstatusLVCP", listaParametros)
    End Sub

    Public Function consultaConfiguracionClienteLV(ByVal idListaPrecioVentas As Int32, ByVal idCliente As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT cc.ccla_clienteconfiguracionlistaactivaid, cc.ccla_clienteid, cc.ccla_listaventasid," +
        " cc.ccla_tipoivaid, ti.tiva_nombre, cc.ccla_tipofleteid, tf.tifl_nombre, cc.ccla_facturar" +
        " FROM Ventas.ClienteConfiguracionListaActiva cc" +
        " LEFT JOIN Cobranza.TipoIVA ti ON cc.ccla_tipoivaid = ti.tiva_tipoivaid" +
        " LEFT JOIN Ventas.TipoFlete tf ON cc.ccla_tipofleteid = tf.tifl_tipofleteid" +
        " WHERE cc.ccla_listaventasid = " + idListaPrecioVentas.ToString + " And cc.ccla_clienteid = " + idCliente.ToString +
        " AND cc.ccla_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaConfiguracionDescuentoClienteLV(ByVal idListaPrecioVentas As Int32, ByVal idCliente As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT cd.cdlv_clientedescuentoid, cd.cdvl_listaventasid, cd.cdlv_clienteid, cd.cdlv_tipodescuentoid," +
        " cd.cdlv_lugardescuentoid, cd.cdlv_diasvigencia, cd.cdlv_encadenado, cd.cdlv_porcentaje, cd.cdlv_cantidad" +
        " FROM Ventas.ClienteDescuentosListaVentas cd WHERE cd.cdvl_listaventasid = " + idListaPrecioVentas.ToString +
        " AND cd.cdlv_activo = 1 AND cd.cdlv_clienteid = " + idCliente.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaminVigencias(ByVal idListaVentas As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT MIN(lcp.lvcp_vigenciainicio) AS 'VIGENCIAINICIOFIN'" +
        " FROM Ventas.ListaVentasCliente lc" +
        " JOIN Ventas.ListaVentasClientePrecio lcp ON lc.lvcl_listaventasclienteid = lcp.lvcp_listaventasclienteid" +
        " WHERE lc.lvcl_activo = 1 And lcP.lvcp_activo = 1 And lc.lvcl_listaprecioventasid = " + idListaVentas.ToString +
        " UNION ALL" +
        " SELECT MAX(lcp.lvcp_vigenciafin) AS 'VIGENCIAINICIOFIN'" +
        " FROM Ventas.ListaVentasCliente lc" +
        " JOIN Ventas.ListaVentasClientePrecio lcp ON lc.lvcl_listaventasclienteid = lcp.lvcp_listaventasclienteid" +
        " WHERE lc.lvcl_activo = 1 AND lcP.lvcp_activo = 1 AND lc.lvcl_listaprecioventasid = " + idListaVentas.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

End Class
