Imports Persistencia
Imports System.Data.SqlClient


Public Class PrecioDA

    ''' <summary>
    ''' CONSULTA EL ID DE LA LISTA DE PRECIOS DE VENTA, EL INCREMENTO POR PAR, TIPO DE INCREMENTO(PORCENTAJE O MONEDA), INICIO DEL RANGO DE FACTURACION,
    ''' FIN DEL RANGO DE FACTURACION, INICIO DEL RANGO DE DESCUENTOS, FIN DEL RANGO DE DESCUENTOS DE LA TABLA VENTAS.LISTAPRECIOSVENTA
    ''' </summary>
    ''' <param name="Id_Lista_De_Precio">ID DE LA LISTA DE PRECIO DE LA CUAL SE RECUPERARA INFORMACION</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UNA TABLA DE DATOS</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Valores_De_Lista_De_Precios(ByVal Id_Lista_De_Precio As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select lpvt_listaprecioventaid as  'Id Lista de ventas', lpvt_incrementoporpar as 'Incremento', lpvt_porcentaje as 'Porcentaje o moneda', " +
                                " lpvt_facturacioninicio as 'Facturación Inicio', lpvt_facturacionfin as 'Facturación Fin', lpvt_descuentoinicio as 'Descuento Inicio'," +
                                " lpvt_descuentofin as 'Descuento Fin'  from Ventas.ListaPreciosVenta " +
                                " where lpvt_listaprecioventaid = " + Id_Lista_De_Precio.ToString

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' CONSULTA LA LISTA DE TIPOS DE IVA ASIGNADOS PARA ESA LISTA DE PRECIOS
    ''' </summary>
    ''' <param name="Id_Lista_De_Precio">ID DE LISTA DE PRECIOS</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UNA TABLA DE DATOS</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Lista_Tipos_Iva(ByVal Id_Lista_De_Precio As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select t.lvti_listaventastipoivaid, i.tiva_nombre from Ventas.ListaVentasTipoIva t" +
                                " inner join Cobranza.TipoIVA i on t.lvti_tipoivaid=i.tiva_tipoivaid " +
                                " where i.tiva_activo = 1 And t.lvti_activo = 1 And t.lvti_listaventaid = " + Id_Lista_De_Precio.ToString

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' CONSULTA LA LISTA DE TIPOS DE FLETES ASIGNADO PARA UNA LISTA DE PRECIOS
    ''' </summary>
    ''' <param name="Id_Lista_De_Precio">ID DE LA LISTA DE PRECIOS DE LA CUAL SE RECUPERARA INFORMACION</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UNA TABLA DE DATOS</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Lista_Tipos_Flete(ByVal Id_Lista_De_Precio As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select t.lvtf_listaventasfleteid, f.tifl_nombre from Ventas.ListaVentasTipoFlete t" +
                                " inner join ventas.TipoFlete f on f.tifl_tipofleteid=t.lvtf_tipofleteid" +
                                " where f.tifl_activo = 1 And t.lvtf_activo = 1 And t.lvtf_listaventasid = " + Id_Lista_De_Precio.ToString

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUEPRA EL ID DE LA CONF. DE LISTA DE CLIENTE, EL ID DE LA LISTA DE VENTAS EN LA QUE EL CLIENTE ESTA ASIGNADO, EL DESCUENTO, LA FACTURACION, EL ID DEL TIPO DE FLETE,
    ''' EL ID DEL TIPO DE IVA, EL ID DEL TIPO DE MONEDA DE UN CLIENTE EN ESPECIFICO
    ''' </summary>
    ''' <param name="Id_Lista_Precios">ID DE LA LSITA DE PRECIOS EN LA QUE ESTA ASIGNADO EL CLIENTE</param>
    ''' <param name="IdCliente">ID DEL CLIENTE DEL CUAL SE RECUPERARA LA INFORMACION</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UNA TABLA DE DATOS</returns>
    ''' <remarks></remarks>
    Public Function recuperar_Informacion_Cliente_Para_Configurar_Lista_Precios(ByVal Id_Lista_Precios As Integer, ByVal IdCliente As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT lvcl_listaventasclienteid AS 'Id lista de cliente', lvcl_listaprecioventasid AS 'Lista de ventas'," +
        " lvcl_descuento AS 'Descuento', lvcl_facturacion AS 'Facturación', lvcl_fleteid AS 'Id Flete'," +
        " case when lvcl_fleteid = 0 then 'NO ASIGNADO' ELSE tifl_nombre END AS 'Flete', lvcl_ivaid AS 'Id IVA'," +
        " CASE WHEN lvcl_ivaid = 0 THEN 'NO ASIGNADO' ELSE tiva_nombre END as 'IVA', lvcl_monedaid AS 'Id Moneda'," +
        " CASE WHEN iccl_incotermid IS NULL THEN 0 ELSE iccl_incotermid END AS 'IDINCOTERM'," +
        " CASE WHEN iccl_incotermid IS NULL THEN 'NO ASIGNADO'  ELSE inco_claveincoterm END AS 'INCOTERM'," +
        " mone_abreviatura AS 'MONEDA AV', ticl_tipoclienteid AS 'ID_TIPOCLIENTE', ticl_nombre AS 'TIPOCLIENTE',	iccl_calcularpreciocondescuento as 'PRECIOCONDESCUENTO'" +
        " FROM Ventas.ListaVentasCliente" +
        " JOIN Cobranza.InfoCliente ON lvcl_clienteid = iccl_clienteid" +
        " left join Cobranza.TipoIVA on tiva_tipoivaid = lvcl_ivaid" +
        " left join Ventas.TipoFlete on tifl_tipofleteid = lvcl_fleteid" +
        " LEFT JOIN Embarque.INCOTERMS on inco_incotermsid = iccl_incotermid" +
        " LEFT JOIN Cobranza.Moneda ON mone_monedaid = iccl_monedaid" +
        " JOIN CLIENTE.Cliente ON clie_clienteid = iccl_clienteid" +
        " JOIN Ventas.TipoCliente ON ticl_tipoclienteid = clie_tipoclienteid" +
        " where lvcl_clienteid = " + IdCliente.ToString + " And lvcl_listaprecioventasid = " + Id_Lista_Precios.ToString

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function Recuperar_Paridad_Moneda(ByVal IdMoneda As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT paca_monedaid, mone_nombre, mone_simbolo, paca_paridadpesos, 	case when paca_fechamodificacion is NULL THEN" +
        " paca_fechacreacion else paca_fechamodificacion end as  Fecha" +
        " FROM FRAMEWORK.ParidadCambiaria" +
        " INNER JOIN Framework.Moneda ON mone_monedaid = ParidadCambiaria.paca_monedaid" +
        " INNER JOIN Framework.Modulos ON modu_moduloid = paca_moduloid" +
        " WHERE paca_activo=1 and modu_nombre like '%Listas de Precios%' and mone_monedaid = " + IdMoneda.ToString

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function Guardar_Valores_de_Lista_de_Precios(ByVal IdCliente As Integer, ByVal IdListaPrecioVentas As Integer, ByVal Descuentos As Double, ByVal Facturacion As _
                                                        Integer, ByVal IdFlete As Integer, ByVal IdIVA As Integer, ByVal IdMoneda As Integer, ByVal incoterm As Integer,
                                                        ByVal DescuentoPorArticulo As Boolean) As DataTable

        Dim operaciones As New OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ClienteId"
        parametro.Value = IdCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ListaPrecioVentaId"
        parametro.Value = IdListaPrecioVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Descuento"
        parametro.Value = Descuentos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Facturacion"
        parametro.Value = Facturacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FleteId"
        parametro.Value = IdFlete
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IVAId"
        parametro.Value = IdIVA
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MonedaId"
        parametro.Value = IdMoneda
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@incoterm"
        parametro.Value = incoterm
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DescuentoPorArticulo"
        parametro.Value = DescuentoPorArticulo
        listaParametros.Add(parametro)



        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Ventas.SP_Guardar_Configuracion_De_Lista_De_Precios_De_Cliente", listaParametros)

    End Function


    Public Function recuperar_Id_Lista_Base(ByVal IdListaVentas As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT lpvt_listapreciosbaseid FROM Ventas.ListaPreciosVenta WHERE lpvt_listaprecioventaid = " + IdListaVentas.ToString

        Return operaciones.EjecutaConsulta(consulta)
    End Function



    Public Function Asignar_Nueva_Lista_De_Precios_A_Cliente(ByVal IdListaPrecioVentaActual As Integer, ByVal IdListaPrecioVentaPorAsignar As Integer, _
        ByVal IdMoneda As Integer, ByVal IdClienteSay As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdListaPrecioVentaActual"
        parametro.Value = IdListaPrecioVentaActual
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdListaPrecioVentaPorAsignar"
        parametro.Value = IdListaPrecioVentaPorAsignar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdMoneda"
        parametro.Value = IdMoneda
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdClienteSay"
        parametro.Value = IdClienteSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Ventas.[SP_Cambiar_Lista_De_Precios_De_Cliente]", listaParametros)

    End Function

    ''RECUPERAR
    Public Function recuperar_Informacion_Cliente_Para_NotaListaPrecios(ByVal Id_Lista_Precios As Integer, ByVal IdCliente As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT lvcl_listaventasclienteid AS 'Id lista de cliente', lvcl_listaprecioventasid AS 'Lista de ventas'," +
            " lvcl_descuento AS 'Descuento', lvcl_facturacion AS 'Facturación', lvcl_fleteid AS 'Id Flete'," +
            " CASE WHEN lvcl_fleteid = 0 THEN 'NO ASIGNADO' ELSE tifl_nombre END AS 'FLETE', lvcl_ivaid AS 'Id IVA'," +
            " CASE WHEN lvcl_ivaid = 0 THEN 'NO ASIGNADO' ELSE tiva_nombre END as 'IVA', lvcl_monedaid AS 'Id Moneda'," +
            " CASE WHEN iccl_incotermid IS NULL THEN 0 ELSE iccl_incotermid END AS 'IDINCOTERM'" +
            " FROM Ventas.ListaVentasCliente" +
            " JOIN Cobranza.InfoCliente ON lvcl_clienteid = iccl_clienteid" +
            " LEFT join Ventas.TipoFlete on tifl_tipofleteid = lvcl_fleteid" +
            " LEFT join Cobranza.TipoIVA on lvcl_ivaid = tiva_tipoivaid " +
            " where lvcl_clienteid = " + IdCliente.ToString + " And lvcl_listaprecioventasid = " + Id_Lista_Precios.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function ValidarPermitirCambioLP_y_Moneda(ByVal IdListaPrecioVenta As Integer, ByVal IdClienteSAY As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select d.lvcp_estatusid AS 'ID_ESTATUS', e.esta_nombre as 'ESTATUS' from Ventas.ListaPreciosBase as a " +
                " join Ventas.ListaPreciosVenta as b on a.lpba_listapreciosbaseid = b.lpvt_listapreciosbaseid" +
                " join Ventas.ListaVentasCliente as c on b.lpvt_listaprecioventaid = c.lvcl_listaprecioventasid" +
                " join Ventas.ListaVentasClientePrecio as d on d.lvcp_listaventasclienteid = c.lvcl_listaventasclienteid" +
                " left join Framework.Estatus as e on e.esta_estatusid = d.lvcp_estatusid " +
                " where c.lvcl_clienteid = " + IdClienteSAY.ToString + " And a.lpba_estatus = 2 And b.lpvt_listaprecioventaid = " + IdListaPrecioVenta.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function RecuperarInformacionListaVentaClientePrecio(ByVal IdClienteSay As Integer, ByVal IdListaVentas As Integer, ByVal NombreListaVentaClientePrecio As String) As DataTable
        Dim objDA As New Datos.PrecioDA
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT cl.clie_clienteid AS 'idsay', cl.clie_idsicy AS 'idsicy', cl.clie_tipoclienteid as 'tipoCliente', " +
            " cl.clie_nombregenerico AS 'Cliente', lv.lpvt_listaprecioventaid AS idListaVentas,lb.lpba_listapreciosbaseid AS 'idListaBase', " +
            " (lb.lpba_codigolistabase + ' - ' + lb.lpba_nombrelista) AS 'listabase', " +
            " (lb.lpba_codigolistabase + ' - ' + lv.lpvt_codigolistaventa + ' ' + lv.lpvt_descripcion) AS 'listaVentas'," +
            " lv.lpvt_vigenciainicio, lv.lpvt_vigenciafin,lv.lpvt_incrementoporpar AS 'inxpar', " +
            " lc.lvcl_listaventasclienteid as 'idListaVentasCliente',lcp.lvcp_listaventasclienteprecioid AS 'idListaVentasClientePrecio', " +
            " lcp.lvcp_vigenciainicio,lcp.lvcp_monedaid,lcp.lvcp_paridad,lcp.lvcp_descripcion,lcp.lvcp_estatusid,lcp.lvcp_vigenciainicio, " +
            " lcp.lvcp_vigenciafin,lb.lpba_estatus, lb.lpba_codigolistabase, lv.lpvt_codigolistaventa" +
            " FROM Ventas.ListaPreciosBase lb" +
            " JOIN Ventas.ListaPreciosVenta lv ON lb.lpba_listapreciosbaseid = lv.lpvt_listapreciosbaseid" +
            " JOIN Ventas.ListaVentasCliente lc ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" +
            " JOIN Ventas.ListaVentasClientePrecio lcp ON lc.lvcl_listaventasclienteid = lcp.lvcp_listaventasclienteid" +
            " JOIN Cliente.Cliente cl	ON lc.lvcl_clienteid = cl.clie_clienteid" +
            " WHERE lcp.lvcp_descripcion = '" + NombreListaVentaClientePrecio + "' " +
            " and lv.lpvt_activo = 1  And lcp.lvcp_activo = 1 AND cl.clie_activo= 1 " +
            " AND lv.lpvt_listaprecioventaid =  " + IdListaVentas.ToString +
            " AND lc.lvcl_clienteid =  " + IdClienteSay.ToString +
            " ORDER BY cl.clie_nombregenerico, lcp.lvcp_vigenciainicio DESC "
        Return operaciones.EjecutaConsulta(consulta)
    End Function


End Class
