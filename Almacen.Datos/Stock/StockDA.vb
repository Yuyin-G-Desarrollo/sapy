Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class StockDA
    Public Function Stock_DocenaNormal(ByVal ProductoId As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaValores As New List(Of SqlParameter)

        Dim valores As New SqlParameter
        valores.ParameterName = "@Producto"
        valores.Value = ProductoId
        listaValores.Add(valores)

        Return operaciones.EjecutarConsultaSP("Almacen.Stock_DocenaNormal", listaValores)
    End Function

   
    Public Function ConsultaStock(ByVal productosID As String, ByVal validarStock As Boolean) As System.Data.DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaValores As New List(Of SqlParameter)

        Dim valores As New SqlParameter
        valores.ParameterName = "@productos"
        valores.Value = productosID
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@validarStock"
        valores.Value = validarStock
        listaValores.Add(valores)



        Return operaciones.EjecutarConsultaSP("Almacen.Stock_Consulta", listaValores)
    End Function


    Public Function ConsultaModelosStock(ByVal marcas As String, ByVal colecciones As String, ByVal modelos As String, ByVal modeloFiltro As String, ByVal aplicaciones As String, ByVal colores As String, ByVal pieles As String, ByVal corridas As String, ByVal familias As String, ByVal categorias As String, ByVal lineas As String, ByVal horma As String) As System.Data.DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Dim consulta As String = ""

        consulta += " SELECT"
        consulta += " DISTINCT(pe.pres_codSicy) as idProductos,"
        consulta += " prod_codigo"
        consulta += " FROM Programacion.Productos AS pr"
        consulta += " INNER JOIN Programacion.ProductoEstilo AS pe"
        consulta += " ON pr.prod_productoid = pe.pres_productoid"
        consulta += " LEFT JOIN Programacion.Hormas AS hh"
        consulta += " ON pe.pres_horma = hh.horma_hormaid"
        consulta += " INNER JOIN Programacion.EstilosProducto AS ep"
        consulta += " ON pe.pres_estiloid = ep.espr_estiloproductoid"
        consulta += " INNER JOIN Programacion.Pieles AS pl"
        consulta += " ON ep.espr_pielid = pl.piel_pielid"
        consulta += " LEFT JOIN Programacion.Familias AS fa"
        consulta += " ON pe.pres_familiaid = fa.fami_familiaid"
        consulta += " INNER JOIN Programacion.Tallas AS tt"
        consulta += " ON ep.espr_tallaid = tt.talla_tallaid"
        consulta += " INNER JOIN Programacion.Colores AS cc"
        consulta += " ON ep.espr_colorid = cc.color_colorid"
        consulta += " INNER JOIN Programacion.PielMuestras AS pm"
        consulta += " ON ep.espr_pielmuestraid = pm.plmu_pielmuestraid"
        consulta += " INNER JOIN Programacion.Forros AS ff"
        consulta += " ON ep.espr_forroid = ff.forr_forroid"
        consulta += " INNER JOIN Programacion.Suelas AS ss"
        consulta += " ON ep.espr_suelaid = ss.suel_suelaid"
        consulta += " LEFT JOIN Programacion.Lineas ln"
        consulta += " ON pe.pres_lineaid = ln.linea_lineaid"
        consulta += " INNER JOIN Programacion.EstatusProducto st"
        consulta += " ON pe.pres_estatus = st.stpr_productoStatusId"
        consulta += " INNER JOIN Programacion.ProductoSubfamilias AS po"
        consulta += " ON po.prsu_productoid = pe.pres_productoid"
        consulta += " INNER JOIN programacion.Subfamilia AS progSF"
        consulta += " ON progSF.subf_subfamiliaid = po.prsu_subfamiliaid"
        consulta += " INNER JOIN Programacion.ProductoEstilo AS prodE"
        consulta += " ON prodE.pres_productoid = po.prsu_productoid"
        consulta += " INNER JOIN Programacion.Marcas AS mm"
        consulta += " ON mm.marc_marcaid = pr.prod_marcaid"
        consulta += " WHERE"
        consulta += " mm.marc_esCliente = 0"
        consulta += " AND pe.pres_codSicy<>''"
        consulta += " AND pe.pres_activo=1"

        If marcas.Length > 0 Then
            consulta += " AND mm.marc_marcaid in ('" + marcas.ToString + "')"
        End If

        If horma.length > 0 Then
            consulta += " AND hh.horma_hormaid in('" + horma.ToString + "')"
        End If


        If colecciones.Length > 0 Then
            consulta += " AND pr.prod_coleccionid in('" + colecciones.ToString + "')"
        End If


        If modelos.Length > 0 Then
            consulta += " AND pr.prod_productoid in('" + modelos.ToString + "')"
        End If

        If modeloFiltro.Length > 0 Then
            consulta += " AND pr.prod_codigo in('" + modeloFiltro.ToString + "')"
        End If

        If aplicaciones.Length > 0 Then
            consulta += " AND progSF.subf_subfamiliaid in ('" + aplicaciones.ToString + "')"
        End If

        If colores.Length > 0 Then
            consulta += " and cc.color_colorid in('" + colores.ToString + "')"
        End If

        If pieles.Length > 0 Then
            consulta += " AND pl.piel_pielid in ('" + pieles.ToString + "')"
        End If

        If corridas.Length > 0 Then
            consulta += " and tt.talla_tallaid in('" + corridas.ToString + "')"
        End If

        If familias.Length > 0 Then
            consulta += " and fa.fami_familiaid in ('" + familias.ToString + "')"
        End If

        If categorias.Length > 0 Then
            consulta += " and pr.prod_categoria in('" + categorias.ToString + "')"
        End If

        If lineas.Length > 0 Then
            consulta += " and ln.linea_lineaid in ('" + lineas.ToString + "')"
        End If

        consulta += " AND pl.piel_activo = 1"
        consulta += " AND tt.talla_activo = 1"
        consulta += " AND cc.color_activo = 1"
        consulta += " AND pm.plmu_activo = 1"
        consulta += " AND ff.forr_activo = 1"
        consulta += " AND ss.suel_activo = 1"
        consulta += " AND pe.pres_activo = 1"
        consulta += " AND hh.horma_activo = 1"
        consulta += " AND po.prsu_activo = 1"
        consulta += " AND progSF.subf_activo = 1"
        consulta += " AND mm.marc_activo = 1"

        consulta += " ORDER BY prod_codigo,idProductos"
        Return operaciones.EjecutaConsulta(consulta)

    End Function


    Public Sub InsertarPedidoAbierto(ByVal ListaPedidoAbierto As Entidades.Stock)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ped_agenteid"
        parametro.Value = ListaPedidoAbierto.PagenteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ped_clienteid"
        parametro.Value = ListaPedidoAbierto.PclienteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ped_usuariocreoid"
        parametro.Value = ListaPedidoAbierto.PusuarioCreoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ped_estadoPedidoStock"
        parametro.Value = ListaPedidoAbierto.Pestatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pdet_corrida"
        parametro.Value = ListaPedidoAbierto.Pcorrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pdet_talla"
        parametro.Value = ListaPedidoAbierto.Ptalla
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pdet_pares"
        parametro.Value = CInt(ListaPedidoAbierto.Ppares)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ProductoCodigo"
        parametro.Value = ListaPedidoAbierto.Pcodigo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@corridaTipo"
        parametro.Value = ListaPedidoAbierto.PtipoCorrida.ToString
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Almacen.Stock_Alta_Pedido", listaParametros)
    End Sub


    Public Function Stock_VerificarPedidoAbierto(ByVal AgenteId As Integer, ByVal Estatus As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT * from ventas.pedidos"
        consulta += " where ped_agenteid =" + AgenteId.ToString
        consulta += " and ped_estadoPedidoStock='" + Estatus.ToString + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function Stock_ResumenPedido(ByVal AgenteId As Integer, ByVal Estatus As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += "   SELECT A.ped_pedidoid, B.pdet_corridaid , B.pdet_codigoSICY,A.ped_clienteid,B.pdet_tipoCorrida, sum(B.pdet_pares) as totalPares FROM ventas.Pedidos as A"
        consulta += " JOIN Ventas.PedidosDetalles as B  on B.pdet_pedidoid=A.ped_pedidoid"
        consulta += " WHERE A.ped_agenteid =" + AgenteId.ToString
        consulta += " and A.ped_estadoPedidoStock='" + Estatus.ToString + "'"
        consulta += " GROUP BY A.ped_pedidoid, B.pdet_corridaid , B.pdet_codigoSICY,A.ped_clienteid,B.pdet_tipoCorrida "
        consulta += " order by pdet_codigoSICY"
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function EliminarCorrida(ByVal codigoSICY As String, ByVal TallaID As String, ByVal agenteID As String, ByVal pedidoID As String) As Boolean
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        Dim Tabla As New DataTable
        Dim Vacio As Boolean = False

        consulta += " DELETE FROM ventas.PedidosDetalles"
        consulta += " WHERE pdet_pedidoid=" + pedidoID.ToString

        If codigoSICY <> "" And TallaID <> "" And agenteID <> "" And pedidoID <> "" Then
            consulta += " AND  pdet_corridaid=" + TallaID.ToString
            '' consulta += " AND pdet_usuariocreoid=" + agenteID.ToString
            consulta += " AND  pdet_codigoSICY='" + codigoSICY.ToString + "'"
        End If
        operaciones.EjecutaConsulta(consulta)

        consulta = ""
        consulta = " SELECT * FROM ventas.PedidosDetalles"
        consulta += " where pdet_pedidoid=" + pedidoID.ToString
        Tabla = operaciones.EjecutaConsulta(consulta)
        If Tabla.Rows.Count = 0 Then
            consulta = ""
            consulta = " DELETE FROM ventas.Pedidos"
            consulta += " where ped_pedidoid=" + pedidoID.ToString
            operaciones.EjecutaConsulta(consulta)
            Vacio = True
        End If
        Return Vacio
    End Function

    Public Function ListaClientes_SegunAgente(ByVal AgenteID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta += " SELECT B.clie_idsicy,b.clie_nombregenerico,A.cmae_clienteid FROM Cliente.ClienteMarcaAgenteEmpresa as A"
        consulta += " join Cliente.Cliente as B on B.clie_clienteid=A.cmae_clienteid"
        consulta += " where cmae_activo=1"
        If AgenteID > 0 Then
            consulta += " and  cmae_colaboradorid_agente = " + AgenteID.ToString
        End If
        consulta += " group by clie_idsicy, b.clie_nombregenerico, A.cmae_clienteid"
        consulta += " order by B.clie_nombregenerico ASC"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub CerrarPedido(ByVal AgenteID As Integer, ByVal ClienteID As Integer, ByVal pedidoID As Integer, ByVal tienda As Integer, ByVal corridaid As String, ByVal codigo As String, ByVal rfcCliente As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " UPDATE ventas.Pedidos"
        consulta += " SET ped_estadoPedidoStock='B',"
        consulta += " ped_clienteid = " + ClienteID.ToString + ","
        consulta += " ped_clienteRFC= " + rfcCliente.ToString
        consulta += " where ped_pedidoid = " + pedidoID.ToString
        consulta += " and ped_agenteid=" + AgenteID.ToString


        consulta += " UPDATE ventas.PedidosDetalles"
        consulta += " SET pdet_tiendaid=" + tienda.ToString
        consulta += " WHERE pdet_pedidoid=" + pedidoID.ToString
        consulta += " and pdet_corridaid=" + corridaid.ToString
        consulta += " and pdet_codigoSICY='" + codigo.ToString + "'"


        operaciones.EjecutaConsulta(consulta)
    End Sub

    Public Function TiendasSegunCliente(ByVal clienteID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta += " select tec.tiec_tiendaembarquecedisid,tec.tiec_clienteid,cl.clpe_nombre,p.pers_nombre from Cliente.TiendaEmbarqueCEDIS  tec"
        consulta += " inner join Framework.Persona p on p.pers_personaid=tec.tiec_personaid"
        consulta += " inner join Framework.ClasificacionPersona cl on cl.clpe_clasificacionpersonaid=tec.tiec_clasificacionpersonaid"
        consulta += " where tiec_clienteid = " + clienteID.ToString
        consulta += " and cl.clpe_activo=1"
        consulta += " and p.pers_activo=1"
        consulta += " and tec.tiec_activo=1"




        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function marcasSegunAgente(ByVal agenteID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT A.cmae_marcaid,B.marc_descripcion FROM  Cliente.ClienteMarcaAgenteEmpresa as A"
        consulta += " join Programacion.Marcas as B on B.marc_marcaid=A.cmae_marcaid"
        consulta += " where cmae_colaboradorid_agente = " + agenteID.ToString
        consulta += " and cmae_activo=1"
        consulta += " GROUP BY A.cmae_marcaid, B.marc_descripcion"
        consulta += " ORDER BY B.marc_descripcion ASC"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function agentesSegunCliente(ByVal clienteID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT B.codr_colaboradorid,B.codr_nombre+' '+B.codr_apellidopaterno+' '+B.codr_apellidomaterno as nombreAgente FROM Cliente.ClienteMarcaAgenteEmpresa AS A"
        consulta += " JOIN Nomina.Colaborador AS B on B.codr_colaboradorid=A.cmae_colaboradorid_agente"
        consulta += " Join Cliente.Cliente as C on C.clie_clienteid=A.cmae_clienteid"
        consulta += " where cmae_activo = 1"
        consulta += " And clie_idsicy=" + clienteID.ToString
        consulta += " GROUP BY b.codr_colaboradorid,B.codr_nombre + ' ' + B.codr_apellidopaterno + ' ' + B.codr_apellidomaterno"
        consulta += " 	order by B.codr_nombre + ' ' + B.codr_apellidopaterno + ' ' + B.codr_apellidomaterno"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function descripcionAgente(ByVal agenteID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT codr_nombre+' '+ codr_apellidopaterno+ ' '+ codr_apellidomaterno  as agenteDescripcion FROM Nomina.Colaborador "
        consulta += " where codr_colaboradorid=" + agenteID.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function descripcionCliente(ByVal clienteID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT clie_nombregenerico FROM Cliente.Cliente"
        consulta += " where clie_idsicy=" + clienteID.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function historialPedidos(ByVal agenteID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT * FROM "

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function RFCClientes(ByVal clienteID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT rfc.crfc_clienterfcid,rfc.crfc_clienteid,cl.clpe_nombre,rfc.crfc_RFC,p.pers_nombre,"
        consulta += " p.pers_razonsocial, p.pers_personafisica"
        consulta += " FROM Cliente.ClienteRFC rfc "
        consulta += " inner join Framework.Persona p on rfc.crfc_personaid=p.pers_personaid"
        consulta += " inner join Framework.ClasificacionPersona cl on cl.clpe_clasificacionpersonaid=rfc.crfc_clasificacionpersonaid"
        consulta += " where rfc.crfc_clienteid = " + clienteID.ToArray
        consulta += " and cl.clpe_activo=1"
        consulta += " and p.pers_activo=1"
        consulta += " and rfc.crfc_activo=1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

End Class