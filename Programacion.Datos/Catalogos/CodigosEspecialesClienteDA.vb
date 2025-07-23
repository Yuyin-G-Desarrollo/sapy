Imports System.Data.SqlClient

Public Class CodigosEspecialesClienteDA

    Public Function BuscarClientesCodsEspeciales(ByVal idCliente As Integer) As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String

        consulta = "select c.clie_clienteid,c.clie_razonsocial from ventas.InfoCliente ic inner join" +
        " cliente.Cliente c on ic.ivcl_infoclienteid=clie_clienteid" +
        " where c.clie_activo=1 and ic.ivcl_codigoespecialcliente=1 and c.clie_clienteid=" & idCliente & ";"
        If operacion.EjecutaConsulta(consulta).Rows.Count > 0 Then
            'El Cliente existe cumplió la condición mostrará el formulario para clientes códigos especiales'
            Return True
        Else
            Return False
        End If
    End Function
    Public Function getTallasIdsSAY(ByVal idTalla As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select tade_tallaespecial,tade_talla from Programacion.TallasDetalle where tade_tallaid=" & idTalla & ";"
        Return operacion.EjecutaConsulta(consulta)
    End Function
    ''' <summary>
    ''' Concatena el codigo verificador con la clave ECO
    ''' </summary>
    ''' <param name="digitos"></param>
    ''' <returns>Concatena el codigo verificador con la clave ECO</returns>
    ''' <remarks></remarks>
    Public Function getDigitoVerificador(ByVal digitos As String) As String
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        Dim mensaje As String
        Dim dt As New DataTable
        mensaje = "Error"
        consulta = "select Programacion.FN_AMECE_DigitoVerificador_EAN13('" & digitos & "');"
        dt = operacion.EjecutaConsulta(consulta)
        If dt.Rows.Count > 0 Then
            mensaje = digitos & "" & dt.Rows(0).Item(0).ToString
        End If
        Return mensaje
    End Function
    Public Function ListasPreciosCliente(ByVal idCliente As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select (ListaPrecioCliente+' ('+Estatus+')') Lista,*from Ventas.vListaPrecioCliente where IdSAY=" & idCliente & " order by ListaPrecioCliente;"
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function ListasPreciosClienteFechas(ByVal idLista As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select *from Ventas.vListaPrecioCliente where IdListaVentasClientePrecio=" & idLista & ";"
        Return operacion.EjecutaConsulta(consulta)
    End Function
    ''' <summary>
    '''Ver productos
    '''1.-PedidosConfirmanos por ventas
    '''2.-Lista de precios
    '''3.-Todos
    '''Con código
    '''1.-Si
    '''2.-No
    '''3.-Todos
    '''Activos
    '''1.-Si
    '''2.-No
    ''' </summary>
    ''' <param name="verProductos"></param>
    ''' <param name="conCodigo"></param>
    ''' <param name="activos"></param>
    ''' <param name="idLista"></param>
    ''' <param name="idCliente"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LlenarTabla1(ByVal verProductos As Integer, ByVal conCodigo As Integer, ByVal activos As Integer,
                                 ByVal idLista As Integer, ByVal idCliente As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "verProductos"
        parametro.Value = verProductos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "conCodigo"
        parametro.Value = conCodigo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activos"
        parametro.Value = activos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idLista"
        parametro.Value = idLista
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_Contabilidad_LlenarTabla1]", listaParametros)
        'Dim consulta As String
        'consulta = "select distinct 0 seleccion," +
        '" ISNULL (cpe.cope_codigoproductoestiloid,0) codigoproductoestiloid,marca +' '+ Coleccion +' ('+ ModeloSAY+') ' + Piel + ' ' +Color  as ModeloYuyin," +
        '" lp.Corrida, CodigoCliente as ModeloCliente, corrida as Linea," +
        '" stuff((select ',[' +  CAST(pc.pcli_codigopielcliente as varchar(10)) +'] '+ CAST(pc.ccil_nombrepielcliente as varchar(10))" +
        '"  from Programacion.PielesClientes pc where pc.pcli_pielid=IdPielSAY and pc.pcli_clienteid=" + CStr(idCliente) +
        '"    for xml path('')),1,1,'') Material," +
        '" stuff((select ',['  +  CAST(cc.ccli_codigocolorcliente as varchar(10)) +'] '+ CAST(cc.ccil_nombrecolorcliente as varchar(10))" +
        '" from Programacion.ColoresClientes cc where cc.ccli_colorid=lp.IdColorSAY and cc.ccli_clienteid=" + CStr(idCliente) +
        '" for xml path('')),1,1,'') Color,lp.Piel as MaterialYuyin, lp.Color as ColorYuyin," +
        '" cpe.cope_codigosecundario Code,cpe.cope_codigoprincipal ClaveECO," +
        '" isnull(cpe.cope_fechamodificacion,cpe.cope_fechacreacion) Modificación, " +
        '" ISNULL ((SELECT user_username FROM Framework.Usuarios WHERE user_usuarioid=CPE.cope_usuariomodificaid )," +
        '" (SELECT user_username FROM Framework.Usuarios WHERE user_usuarioid=CPE.cope_usuariocreoid)) AS Usuario," +
        '"             cpe.cope_motivoeliminacion MotivoEliminación, lp.ProductoEstiloID, lp.Marca, lp.Coleccion, lp.IdColorSAY, lp.IdTallaSAY," +
        '"               lp.ProductoID, t.talla_inicio, t.talla_fin " +
        '" from Ventas.vListaPrecioClienteProductos lp" +
        '" left join Programacion.CodigosProductoEstilo cpe on cpe.cope_productoestiloid=lp.ProductoEstiloID" +
        '" left join Framework.Usuarios u on u.user_usuarioid=cpe.cope_usuariomodificaid" +
        '" inner join Programacion.Tallas t on t.talla_tallaid=lp.IdTallaSAY"

        ''If idLista > 0 Then
        ''   consulta += " AND lp.idListaVentasClientePrecio=" & idLista & ""
        ''End If
        'If verProductos = 1 Then 'Pedidos confirmados por ventas
        '    consulta += " AND lp.ProductoEstiloID in " +
        '                " (select v.ProductoEstiloId from [192.168.2.2].Yuyin_Respaldo.ventas.vPedidosDetallesConfirmadoVtas p" +
        '                "	inner JOIN Programacion.vProductoEstilos_Todos v on p.IdCodigo=v.CodigoSicy" +
        '                "	where p.IdCadena in (select clie_idsicy from Cliente.Cliente where clie_clienteid" +
        '                "	in(select pove_clienteid from Ventas.PoliticaVenta where clie_clienteid=" + CStr(idCliente) + "))) "
        'ElseIf verProductos = 2 Then 'Lista de precios
        '    consulta += " and lp.ProductoEstiloID in " +
        '   " (select ProductoEstiloID from Ventas.vListaPrecioClienteProductos where idListaVentasClientePrecio = " + CStr(idLista) + ")"
        'Else 'Todos
        '    consulta += " and lp.ProductoEstiloID in " +
        '    " (select ProductoEstiloID from Ventas.vListaPrecioClienteProductos where idListaVentasClientePrecio in " +
        '    " (select idListaVentasClientePrecio from Ventas.vListaPrecioCliente where IdSAY=" + CStr(idCliente) + ")) "
        'End If
        'If conCodigo = 1 Then 'Si
        '    consulta += " AND  cpe.cope_codigoprincipal is not null "
        'ElseIf conCodigo = 2 Then 'No
        '    consulta += " AND cpe.cope_codigoprincipal is null"
        'Else 'Todos
        '    'No va ninguna condición :D'
        'End If
        'If activos = 1 And conCodigo = 3 Then ' activos todos

        'ElseIf activos = 1 And conCodigo = 1 Then 'Activos con codigo
        '    consulta += "  AND  cpe.cope_activo=1 "
        'Else 'Inactivos
        '    consulta += " AND (cpe.cope_activo IS  NULL OR cpe.cope_activo=0) "
        'End If


        'Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function LlenarTabla2(ByVal verProductos As Integer, ByVal conCodigo As Integer, ByVal activos As Integer,
                                 ByVal idLista As Integer, ByVal idCliente As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "verProductos"
        parametro.Value = verProductos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "conCodigo"
        parametro.Value = conCodigo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activos"
        parametro.Value = activos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idLista"
        parametro.Value = idLista
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_Contabilidad_LlenarTabla2]", listaParametros)
        'Dim consulta As String
        'consulta = "select DISTINCT ' ' FabricanteProducción,' ' CodigoDeMuestra," +
        '" p.prod_codcliente Modelo,cc.ccli_codigocolorcliente Color,pc.pcli_codigopielcliente Material,'' Acuerdo,t.talla_inicio TallaInicio,t.talla_fin TallaFin,ISNULL(cpe.cope_codigosecundario,' ') Code," +
        '" ISNULL(cpe.cope_codigoprincipal,' ') ClaveECO" +
        '" from Ventas.vListaPrecioClienteProductos lp inner join Programacion.Productos p on prod_productoid=lp.ProductoID left JOIN" +
        '" programacion.CodigosProductoEstilo cpe on cpe.cope_productoestiloid=lp.ProductoEstiloID left join Framework.Usuarios u" +
        '" on cpe.cope_usuariomodificaid=u.user_usuarioid" +
        '" left join Programacion.ColoresClientes cc on lp.IdColorSAY=cc.ccli_colorid" +
        '" left join Programacion.PielesClientes pc on lp.IdPielSAY=pc.pcli_pielid" +
        '" LEFT JOIN Programacion.Tallas t ON t.talla_tallaid=lp.IdTallaSAY" +
        '" where idListaVentasClientePrecio in(select idListaVentasClientePrecio from Ventas.vListaPrecioCliente where IdSAY=" & idCliente & ")" +
        '" AND pc.pcli_codigopielcliente IS NOT NULL AND cc.ccli_codigocolorcliente IS NOT NULL and p.prod_codcliente<>''"

        'If verProductos = 1 Then 'Pedidos confirmados por ventas
        '    consulta += " AND lp.ProductoEstiloID in " +
        '                " (select v.ProductoEstiloId from [192.168.2.2].Yuyin_Respaldo.ventas.vPedidosDetallesConfirmadoVtas p" +
        '                "	inner JOIN Programacion.vProductoEstilos_Todos v on p.IdCodigo=v.CodigoSicy" +
        '                "	where p.IdCadena in (select clie_idsicy from Cliente.Cliente where clie_clienteid" +
        '                "	in(select pove_clienteid from Ventas.PoliticaVenta where clie_clienteid=" + CStr(idCliente) + "))) "
        'ElseIf verProductos = 2 Then 'Lista de precios
        '    consulta += " and lp.ProductoEstiloID in " +
        '   " (select ProductoEstiloID from Ventas.vListaPrecioClienteProductos where idListaVentasClientePrecio = " + CStr(idLista) + ")"
        'Else 'Todos
        '    consulta += " and lp.ProductoEstiloID in " +
        '    " (select ProductoEstiloID from Ventas.vListaPrecioClienteProductos where idListaVentasClientePrecio in " +
        '    " (select idListaVentasClientePrecio from Ventas.vListaPrecioCliente where IdSAY=" + CStr(idCliente) + ")) "
        'End If
        'If conCodigo = 1 Then 'Si
        '    consulta += " AND  cpe.cope_codigoprincipal is not null "
        'ElseIf conCodigo = 2 Then 'No
        '    consulta += " AND cpe.cope_codigoprincipal is null"
        'Else 'Todos
        '    'No va ninguna condición :D'
        'End If
        'If activos = 1 And conCodigo <> 2 Then 'Activos
        '    consulta += "  AND  cpe.cope_activo=1 "
        'Else 'Inactivos
        '    consulta += " AND (cpe.cope_activo IS  NULL OR cpe.cope_activo=0) "
        'End If
        'consulta += " order by Modelo,Material,Color,TallaInicio"
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function CambiarEstatusInactivoCodsProdsEstilo(ByVal ids As String, ByVal motivo As String) As String
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim mensaje As String = String.Empty
        Dim listaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@ids"
        parametro.Value = ids
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@motivo"
        parametro.Value = motivo
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@idUsuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)
        dt = operacion.EjecutarConsultaSP("Programacion.SP_CambiarEstatusInactivoCodsProdsEstilo", listaParametros)
        If dt.Rows.Count > 0 Then
            mensaje = dt.Rows(0).Item(0).ToString
        End If
        Return mensaje
    End Function
    Public Function InsertUpdateCodigosProductoEstilo(ByVal codigoproductoestiloid As Integer, ByVal productoestiloid As Integer,
                                                ByVal codigoprincipal As String, ByVal codigosecundario As String, ByVal clienteid As Integer) As String
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim mensaje As String = String.Empty
        Dim listaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@productoestiloid"
        parametro.Value = productoestiloid
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@codigoprincipal"
        parametro.Value = codigoprincipal
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@codigosecundario"
        parametro.Value = codigosecundario
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@clienteid"
        parametro.Value = clienteid
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@codigoproductoestiloid"
        parametro.Value = codigoproductoestiloid
        listaParametros.Add(parametro)
        dt = operacion.EjecutarConsultaSP("Programacion.SP_Codigoscliente_InsertCodigosProductoEstilo", listaParametros)
        If dt.Rows.Count > 0 Then
            mensaje = dt.Rows(0).Item(0).ToString
        End If
        Return mensaje
    End Function
    Public Sub InsertCodigosClientes(ByVal idCliente As Integer, ByVal productoestiloid As Integer, ByVal codigocliente As String,
                                          ByVal estilocliente As String, ByVal marcacliente As String, ByVal coleccioncliente As String,
                                          ByVal lineacliente As String, ByVal materialcliente As String, ByVal colorcliente As String,
                                          ByVal tallacliente As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim mensaje As String = String.Empty
        Dim listaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_clienteid"
        parametro.Value = idCliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_productoestiloid"
        parametro.Value = productoestiloid
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_codigocliente"
        parametro.Value = codigocliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_codigorapidocliente"
        parametro.Value = " "
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_estilocliente"
        parametro.Value = estilocliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_marcacliente"
        parametro.Value = marcacliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_coleccioncliente"
        parametro.Value = coleccioncliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_lineacliente"
        parametro.Value = lineacliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_materialcliente"
        parametro.Value = materialcliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_familiacliente"
        parametro.Value = " "
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_colorcliente"
        parametro.Value = colorcliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_tallacliente"
        parametro.Value = tallacliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_descripcioncliente"
        parametro.Value = " "
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_cantidadempacado"
        parametro.Value = 0
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)
        dt = operacion.EjecutarConsultaSP("Programacion.SP_CodigosCliente_AltaNuevoCodigo", listaParametros)
    End Sub
    Public Function getCodigosClientes(ByVal productoid As Integer, ByVal clienteid As Integer, ByVal productoestiloid As Integer, ByVal codigoECO As String, ByVal idTalla As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT" +
        " cc.cocl_codigosclientesid," +
        " ((select prod_descripcion + ' ' + prod_codigo + ' (' + prod_modelo + ') '  " +
        " from Programacion.Productos where prod_productoid = " & productoid & ")" +
        " + cc.cocl_materialcliente + ' ' + cc.cocl_colorcliente) ModeloYuyin," +
        " cc.cocl_lineacliente Corrida," +
        " cp.cope_codigoprincipal ClaveECO," +
        " cp.cope_codigosecundario CodRápido," +
        " cc.cocl_materialcliente Material," +
        " cc.cocl_colorcliente Color," +
        " td.tade_talla Talla," +
        " td.tade_tallaespecial TallaEspecial," +
        " cc.cocl_codigocliente Código," +
        " ISNULL(cc.cocl_fechamodificacion, cc.cocl_fechacreacion) Modificación," +
        " ISNULL((SELECT 		user_username	FROM Framework.Usuarios	WHERE user_usuarioid =cc.cocl_usuariomodificaid), (SELECT" +
        " user_username	FROM Framework.Usuarios	WHERE user_usuarioid = cc.cocl_usuariocreoid)	) AS Usuario" +
        " FROM Programacion.CodigosProductoEstilo cp" +
        " INNER JOIN Programacion.CodigosClientes cc" +
        " ON cp.cope_productoestiloid = cc.cocl_productoestiloid" +
        " AND cc.cocl_clienteid = cp.cope_clienteid" +
        " INNER JOIN Programacion.TallasDetalle td" +
        " ON td.tade_talla = cc.cocl_tallacliente" +
        " INNER JOIN Programacion.Productos p" +
        " ON p.prod_productoid = " & productoid & "" +
        " WHERE cocl_clienteid = " & clienteid & "" +
        " AND cocl_productoestiloid = " & productoestiloid & "" +
        " AND cp.cope_codigoprincipal = '" & codigoECO & "'" +
        " AND td.tade_tallaid= " & idTalla & ""
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Sub InactivarCodigosClientes(ByVal codigosclientesid As Integer, ByVal motivoeliminacion As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim mensaje As String = String.Empty
        Dim listaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_codigosclientesid"
        parametro.Value = codigosclientesid
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_motivoeliminacion"
        parametro.Value = motivoeliminacion
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)
        dt = operacion.EjecutarConsultaSP("Programacion.SP_CodigosCliente_InactivarCodigo", listaParametros)
        If dt.Rows.Count > 0 Then
            mensaje = dt.Rows(0).Item(0).ToString
        End If
    End Sub
    Public Function getListaIdCodigosClientes(ByVal productoEstiloID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select * from Programacion.CodigosClientes where cocl_productoestiloid=" & productoEstiloID & ";"
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Sub UpdateCodigosClientes(ByVal codigosclientesid As Integer, ByVal productoestiloid As Integer, ByVal codigocliente As String,
                                          ByVal estilocliente As String, ByVal marcacliente As String, ByVal coleccioncliente As String,
                                          ByVal lineacliente As String, ByVal materialcliente As String, ByVal colorcliente As String,
                                          ByVal tallacliente As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim mensaje As String = String.Empty
        Dim listaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_codigosclientesid"
        parametro.Value = codigosclientesid
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_codigocliente"
        parametro.Value = codigocliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_codigorapidocliente"
        parametro.Value = " "
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_estilocliente"
        parametro.Value = estilocliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_marcacliente"
        parametro.Value = marcacliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_coleccioncliente"
        parametro.Value = coleccioncliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_lineacliente"
        parametro.Value = lineacliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_materialcliente"
        parametro.Value = materialcliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_familiacliente"
        parametro.Value = " "
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_colorcliente"
        parametro.Value = colorcliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_tallacliente"
        parametro.Value = tallacliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_descripcioncliente"
        parametro.Value = " "
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cocl_cantidadempacado"
        parametro.Value = 0
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)
        dt = operacion.EjecutarConsultaSP("Programacion.SP_CodigosCliente_EditarCodigo", listaParametros)
    End Sub
    ''' <summary>
    ''' Regresa DataTable de los ids de las tablas CodigosProductoEstilo y CodigosClientes(SI EXISTEN)
    ''' </summary>
    ''' <param name="productoEstiloID"></param>
    ''' <param name="idCliente"></param>
    ''' <param name="nivel"></param>
    ''' <param name="claveECO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getIdsCodigos(ByVal productoEstiloID As String, ByVal idCliente As Integer, ByVal claveECO As String, ByVal nivel As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select *from Programacion.CodigosProductoEstilo cpe inner JOIN" +
        " Programacion.CodigosClientes cc on cc.cocl_productoestiloid=cpe.cope_productoestiloid" +
        " Where cc.cocl_productoestiloid=" & productoEstiloID & " AND cc.cocl_clienteid=" & idCliente & " "
        If nivel = 2 Then
            consulta += " and cpe.cope_codigoprincipal like '" & claveECO & "'"
        End If
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function actualizarCodigoECOySecundario(ByVal codigoECO As String, ByVal CodigoSec As String, ByVal idCliente As Integer, ByVal id As Integer,
                                                   ByVal nivel As Integer) As String
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim mensaje As String = String.Empty
        Dim listaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@codigoprincipal"
        parametro.Value = codigoECO
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@codigosecundario"
        parametro.Value = CodigoSec
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@clienteid"
        parametro.Value = idCliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@id"
        parametro.Value = id
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@nivel"
        parametro.Value = nivel
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)
        dt = operacion.EjecutarConsultaSP("Programacion.SP_UpdateCodigosClientesEstilo", listaParametros)
        If dt.Rows.Count > 0 Then
            mensaje = dt.Rows(0).Item(0).ToString
        End If
        Return mensaje
    End Function
    ''' <summary>
    ''' Regresa un DateTable si tiene registros es posible hacer la insercion del codigo
    ''' </summary>
    ''' <param name="modeloCliente"></param>
    ''' <param name="color"></param>
    ''' <param name="piel"></param>
    ''' <param name="tallaInicio"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function validarInsercionCodigos(ByVal modeloCliente As String, ByVal color As String, ByVal piel As String, ByVal tallaInicio As String, ByVal idCliente As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT" +
        " *FROM Ventas.vListaPrecioClienteProductos V" +
        " INNER JOIN Programacion.tallas T" +
        " ON T.talla_tallaid = V.IdTallaSAY" +
        " WHERE CodigoCliente = '" & modeloCliente & "'" +
        " AND T.talla_inicio=REPLACE('" & tallaInicio & "','.5', '½')" +
        " AND IdPielSAY IN (SELECT DISTINCT" +
        " pcli_pielid" +
        " FROM Programacion.PielesClientes" +
        " WHERE pcli_codigopielcliente = '" & piel & "'" +
        " AND pcli_pielid = V.IdPielSAY" +
        " AND pcli_clienteid = " & idCliente & ")" +
        " AND IdColorSAY IN (SELECT DISTINCT" +
        " ccli_colorid" +
        " FROM Programacion.ColoresClientes" +
        " WHERE ccli_codigocolorcliente = '" & color & "'" +
        " AND V.IdColorSAY = ccli_colorid" +
        " AND ccli_clienteid = " & idCliente & ")" +
        " AND V.idListaVentasClientePrecio IN (SELECT" +
        " idListaVentasClientePrecio" +
        " FROM Ventas.vListaPrecioCliente" +
        " WHERE IdSAY = " & idCliente & ")"
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function getAllCodigosClientes(ByVal clienteid As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT" +
        " cc.cocl_codigosclientesid," +
        " ((p.prod_descripcion + ' ' + p.prod_codigo + ' (' + p.prod_modelo + ') ')" +
        " + cc.cocl_materialcliente + ' ' + cc.cocl_colorcliente) ModeloYuyin," +
        " cc.cocl_lineacliente Corrida," +
        " cp.cope_codigoprincipal ClaveECO," +
        " cp.cope_codigosecundario CodRápido," +
        " cc.cocl_materialcliente Material," +
        " cc.cocl_colorcliente Color," +
        " td.tade_talla Talla," +
        " case when( SUBSTRING(td.tade_talla,3,3)='½') THEN SUBSTRING(td.tade_talla,1,2)+'5' " +
        " ELSE SUBSTRING(td.tade_talla,1,2)+'0' END TallaEspecial," +
        " cc.cocl_codigocliente Código," +
        " cc.cocl_fechamodificacion Modificación," +
        " ISNULL(u.user_username, ' ') Usuario" +
        " FROM Programacion.CodigosProductoEstilo cp" +
        " INNER JOIN Programacion.CodigosClientes cc" +
        " ON cp.cope_productoestiloid = cc.cocl_productoestiloid" +
        " AND cc.cocl_clienteid = cp.cope_clienteid" +
        " INNER JOIN Programacion.TallasDetalle td" +
        " ON td.tade_talla = cc.cocl_tallacliente" +
        " INNER JOIN Ventas.vListaPrecioClienteProductos vlpp" +
        " ON vlpp.ProductoEstiloID=cc.cocl_productoestiloid" +
        " INNER JOIN Programacion.Productos p" +
        " ON p.prod_productoid =vlpp.ProductoID" +
        " LEFT JOIN Framework.Usuarios u" +
        " ON cc.cocl_usuariomodificaid = u.user_usuarioid" +
        " WHERE cocl_clienteid = " & clienteid & " AND cc.cocl_activo=1" +
        " GROUP BY cc.cocl_codigocliente , cocl_colorcliente,cocl_materialcliente,cocl_codigosclientesid,ProductoID," +
        " cocl_lineacliente,cope_codigoprincipal,cope_codigosecundario,tade_talla,tade_tallaespecial,cocl_fechamodificacion," +
        " user_username,prod_descripcion,prod_codigo,prod_modelo"
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function getDatosProductoEstilo(ByVal productoEstiloId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = " select * from Ventas.vListaPrecioClienteProductos lp" +
        " left join Programacion.CodigosProductoEstilo cpe on cpe.cope_productoestiloid=lp.ProductoEstiloID" +
        " where cpe.cope_productoestiloid=" & productoEstiloId & ""
        Return operacion.EjecutaConsulta(consulta)
    End Function
End Class
