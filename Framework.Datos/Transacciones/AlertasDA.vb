Imports System.Data.SqlClient

Public Class AlertasDA

    ''' <summary>
    ''' Consulta para la alerta de clientes en lista de ventas temporal de la lista base.
    ''' </summary>
    ''' <returns>Datatable</returns>
    ''' <remarks></remarks>
    Public Function consultaClientesTemporal() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT clie_clienteid, clie_idsicy, clie_nombregenerico," +
                " iccl_tipoivaid,	tiva_nombre, iccl_facturar, iccl_tipofleteid, tifl_nombre," +
                " iccl_monedaid, mone_nombre,	SUM(decl_cantidaddescuento) AS Descuento" +
                " FROM (SELECT c.clie_clienteid, c.clie_idsicy, c.clie_nombregenerico," +
                " i.iccl_tipoivaid, v.tiva_nombre, i.iccl_facturar, i.iccl_tipofleteid," +
                " tifl_nombre, i.iccl_monedaid, mone_nombre, d.decl_descuentosclienteid," +
                " CASE WHEN d.decl_cantidaddescuento IS NULL THEN 0 ELSE d.decl_cantidaddescuento" +
                " END AS decl_cantidaddescuento FROM Ventas.ListaPreciosBase lb " +
                " JOIN Ventas.ListaPreciosVenta lv ON lb.lpba_listapreciosbaseid = lv.lpvt_listapreciosbaseid" +
                " JOIN Ventas.ListaVentasCliente lc ON lv.lpvt_listaprecioventaid = lc.lvcl_listaprecioventasid" +
                " JOIN Cliente.Cliente c ON lc.lvcl_clienteid = c.clie_clienteid" +
                " JOIN Cobranza.InfoCliente i	ON c.clie_clienteid = i.iccl_clienteid" +
                " LEFT JOIN Cobranza.DescuentosCliente d ON c.clie_clienteid = d.decl_clienteid AND d.decl_activo = 1" +
                " LEFT JOIN Cobranza.TipoIVA v ON i.iccl_tipoivaid = v.tiva_tipoivaid	AND i.iccl_activo = 1" +
                " LEFT JOIN Ventas.TipoFlete AS f	ON f.tifl_tipofleteid = i.iccl_tipofleteid" +
                " LEFT JOIN Framework.Moneda m ON m.mone_monedaid = i.iccl_monedaid" +
                " WHERE lb.lpba_estatus = 2 And lv.lpvt_estemporal = 1 And lc.lvcl_activo = 1 And c.clie_activo = 1" +
                " GROUP BY	c.clie_clienteid, c.clie_idsicy, c.clie_nombregenerico, i.iccl_tipoivaid, v.tiva_nombre," +
                " i.iccl_facturar, iccl_tipofleteid, tifl_nombre, iccl_monedaid, mone_nombre," +
                " d.decl_descuentosclienteid,	decl_cantidaddescuento) AS clientes" +
                " GROUP BY clie_clienteid,	clie_idsicy, clie_nombregenerico, iccl_tipoivaid," +
                " tiva_nombre, iccl_facturar,	iccl_tipofleteid,tifl_nombre,iccl_monedaid," +
                " mone_nombre ORDER BY clie_nombregenerico"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    ''' <summary>
    ''' Consulta para alertar de las listas base o de ventas que se encuentran proximas a vencer
    ''' </summary>
    ''' <returns>Datatable</returns>
    ''' <remarks></remarks>
    Public Function consultaVigenciasProximasLVS() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Return operacion.EjecutarConsultaSP("Ventas.SP_ConsultaListasVigenciaProxima", listaParametros)
    End Function

    Public Function consultaSolicitudesRechazadas() As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[Contabilidad].[SP_ConsultaMovimientosRechazados]", listaParametros)
    End Function

    Public Function envioCorreoRechazadas(ByVal patronId As Integer) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_EnvioCorreoMovimientosRechazados", listaParametros)
    End Function

    Public Function consultaListadoMovimientosPendientes() As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFMovimientosPendiente_ConsultarListado", listaParametros)
    End Function

    Public Function consultarPermisoPantallaNomina(ByVal movimiento As String) As DataTable
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "movimiento"
        parametro.Value = movimiento
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFMovimientosPendiente_ConsultarPermisoPantalla", listaParametros)
    End Function

    Public Function alertaParesSinProgramar() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_AlertaApartados_ParesSinProgramar]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaArticulosIngresados() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FechaInicio", Date.Now.ToShortDateString)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", Date.Now.ToShortDateString)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_ECOMMERCE_ConsultaArticulosIngresadosCEDIS]", listaParametros)
    End Function
End Class
