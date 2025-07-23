Imports System.Data.SqlClient

Public Class ApartadosDA

    Public Function ListadoParametroApartados(tipo_busqueda As Integer) As DataTable

        'Dim operaciones_sicy As New Persistencia.OperacionesProcedimientosSICY
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        If tipo_busqueda = 1 Then 'Marcas
            consulta += " select marc_marcaid AS 'Parametro',CAST(0 AS BIT) AS ' ', marc_descripcion AS 'Marca' from Programacion.Marcas where marc_activo = 1 "
        Else
            If tipo_busqueda = 2 Then 'Clientes
                ''consulta += " select clie_clienteid as 'Parametro', CAST(0 AS BIT) as ' ',clie_idsicy,clie_nombregenerico as Nombre,clie_clasificacionclienteid as Clasificacion,"
                ''consulta += " clie_ranking as Ranking, CASE WHEN B.Captura+B.Programacion+B.Entrega+B.Contado > 0 THEN 'Si' ELSE 'No' END AS Bloqueado, B.Captura+B.Programacion+B.Entrega+B.Contado as bloqueadoNumero"
                'consulta += " select clie_clienteid as 'Parametro', CAST(0 AS BIT) as ' ',clie_nombregenerico as Nombre,clie_clasificacionclienteid as Clasificación,"
                'consulta += " clie_ranking as Ranking, CASE WHEN B.bloq_captura+B.bloq_programacion+B.bloq_entrega > 0 THEN 'SI' ELSE 'NO' END AS Bloqueado"
                'consulta += "  from Cliente.Cliente C"
                'consulta += " LEFT JOIN Programacion.bloqueos B ON b.bloq_clienteid = c.clie_clienteid and B.bloq_semana = DATEPART(wk,GETDATE()) AND B.bloq_año = DATEPART(YEAR,GETDATE()) "
                'consulta += " where clie_activo=1 and clie_clienteid <> 1071 and clie_clienteid <> 1072  order by clie_nombregenerico "
                parametro = New SqlParameter
                parametro.ParameterName = "@ColaboradorID"
                parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
                listaParametros.Add(parametro)

                Return operaciones.EjecutarConsultaSP("[Almacen].[SP_Apartados_ConsultarClientes]", listaParametros)
            Else
                If tipo_busqueda = 3 Then 'Colección
                    consulta += " select cole_coleccionid as 'Parámetro', CAST(0 as bit) as ' ',cole_descripcion as 'Colección', t.temp_nombre as Temporada, cole_anio as Año"
                    consulta += " from Programacion.Colecciones c inner join Programacion.Temporadas t on c.cole_temporadaid = t.temp_temporadaid where cole_activo= 1 order by cole_descripcion asc, c.cole_Anio asc, t.temp_nombre ASC "
                Else
                    If tipo_busqueda = 4 Then 'Naves
                        consulta += " select nave_naveid as Parámetro,CAST(0 as bit) as ' ',nave_nombre as Nave from Framework.Naves where nave_activo = 1 and nave_navesicyid > 0 order by nave_nombre asc"
                    Else
                        If tipo_busqueda = 5 Then 'Tiendas
                            'consulta += " SELECT tiec.tiec_tiendaembarquecedisid as 'Parámetro',CAST(0 AS BIT) AS ' ',tiec.tiec_tiendaembarquecedisid as ID, c.clie_nombregenerico as Cliente, per.pers_nombre as 'Tiendas / Embarques / CEDIS' from Cliente.TiendaEmbarqueCEDIS tiec inner join Framework.Persona per on tiec.tiec_personaid = per.pers_personaid inner join Cliente.Cliente c on tiec.tiec_clienteid = c.clie_clienteid ORDER BY  c.clie_nombregenerico, per.pers_nombre"
                            parametro = New SqlParameter
                            parametro.ParameterName = "@ColaboradorID"
                            parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
                            listaParametros.Add(parametro)

                            Return operaciones.EjecutarConsultaSP("[Almacen].[SP_Apartados_ConsultarTiendas]", listaParametros)
                        Else
                            If tipo_busqueda = 6 Then 'Modelo por apartar
                                consulta += " SELECT DISTINCT(ModeloSAY) as 'Parámetro', CAST(0 as bit) as ' ', ModeloSAY as Modelo FROM Ventas.vApartados_PedidosPorApartar order by Modelo "
                            Else
                                If tipo_busqueda = 7 Then 'Corridas
                                    'consulta += " select talla_tallaid as 'Parámetro', CAST(0 as bit) as ' ', talla_descripcion as Corrida, talla_sicy from Programacion.Tallas where talla_activo=1 "
                                    consulta += " select talla_tallaid as 'Parámetro', CAST(0 as bit) as ' ', talla_descripcion as Corrida from Programacion.Tallas where talla_activo=1 and talla_paisid = 1 order by talla_descripcion asc"
                                Else
                                    If tipo_busqueda = 8 Then 'Ranking
                                        consulta += " SELECT distinct(invi_ranking) as 'Parámetro', cast(0 as bit) as ' ', invi_ranking as Ranking FROM Programacion.InventarioIdealExcel order by Ranking asc "
                                    Else
                                        If tipo_busqueda = 9 Then 'Temporada
                                            consulta += " select temp_temporadaid as 'Parámetro', cast(0 as bit) as ' ', temp_nombre as Temporada from Programacion.Temporadas where temp_activo = 1 "
                                        Else
                                            If tipo_busqueda = 10 Then 'Operador
                                                consulta += " SELECT " +
                                                    "   A.codr_colaboradorid AS 'Parámetro' " +
                                                    " , CAST (0 AS bit) AS ' ' " +
                                                    " , CAST(A.codr_nombre + ' ' + A.codr_apellidopaterno + ' ' + A.codr_apellidomaterno AS varchar(200)) AS 'Operador' " +
                                                    " FROM [Nomina].[Colaborador] AS A " +
                                                    " JOIN [Nomina].[ColaboradorLaboral] AS B ON B.labo_colaboradorid = A.codr_colaboradorid " +
                                                    " JOIN [Framework].[Grupos] AS C ON C.grup_grupoid = B.labo_departamentoid " +
                                                    " WHERE A.codr_activo = 1 AND C.grup_grupoid in(97,327) ORDER BY A.codr_nombre "
                                            Else
                                                If tipo_busqueda = 11 Then 'Modelo
                                                    'consulta += " select DISTINCT(ModeloSAY) as 'Parámetro', CAST(0 as bit) as ' ', ModeloSAY as Modelo from Programacion.vProductoEstilos_Completo order by ModeloSAY"
                                                    consulta += " select DISTINCT(ModeloSAY) as 'Parámetro', CAST(0 as bit) as ' ', ModeloSAY as 'Modelo SAY', ModeloSICY as 'Modelo SICY', MarcaSAY as 'Marca', ColeccionSAY as 'Colección' from Programacion.vProductoEstilos_Completo order by ModeloSAY "
                                                Else
                                                    If tipo_busqueda = 12 Then 'Piel
                                                        consulta += " select piel_pielid as 'Parámetro', CAST(0 as bit) as ' ', piel_descripcion as Piel from Programacion.Pieles where piel_activo = 1 ORDER by piel_descripcion"
                                                    Else
                                                        If tipo_busqueda = 13 Then 'Color
                                                            consulta += " select color_colorid as 'Parámetro', CAST(0 as bit) as ' ', color_descripcion as Color from Programacion.Colores where color_activo = 1 ORDER by color_descripcion"
                                                        Else
                                                            If tipo_busqueda = 14 Then 'ESTATUS DE APARTADO
                                                                consulta += "select esta_estatusid as ID, esta_nombre as Status from Framework.Estatus where esta_tipostatus = 'APARTADO' order by esta_nombre ASC"
                                                            Else
                                                                If tipo_busqueda = 15 Then 'CLIENTES PPCP
                                                                    consulta += " select clie_clienteid as 'Parametro', CAST(0 AS BIT) as ' ',clie_nombregenerico as Nombre,clie_clasificacionclienteid as Clasificación,"
                                                                    consulta += " clie_ranking as Ranking, CASE WHEN B.bloq_captura+B.bloq_programacion+B.bloq_entrega > 0 THEN 'SI' ELSE 'NO' END AS Bloqueado"
                                                                    consulta += "  from Cliente.Cliente C"
                                                                    consulta += " LEFT JOIN Programacion.bloqueos B ON b.bloq_clienteid = c.clie_clienteid and B.bloq_semana = DATEPART(wk,GETDATE()) AND B.bloq_año = DATEPART(YEAR,GETDATE())"
                                                                    consulta += " where clie_activo=1 and  clie_puedeapartarPPCP=1 order by clie_nombregenerico "
                                                                Else
                                                                    If tipo_busqueda = 16 Then 'Estatus Pedido
                                                                        consulta += "SELECT esta_estatusid as 'Parametro',CAST(0 as bit) as ' ' ,UPPER( esta_nombre) AS NombreEstatus "
                                                                        consulta += "FROM Framework.Estatus "
                                                                        consulta += "WHERE esta_tipostatus='PEDIDO' "
                                                                        consulta += "ORDER BY esta_nombre ASC "
                                                                    Else
                                                                        If tipo_busqueda = 17 Then ' Atencion a clientes
                                                                            consulta += "SELECT  IdColaborador,   CAST(0 as bit) as ' ', (Nombre + ' ' + ApellidoPaterno + ' ' + ApellidoMaterno ) as Nombre "
                                                                            consulta += "FROM vColaboradores "
                                                                            consulta += "WHERE IdPuesto in (274) "
                                                                            consulta += "ORDER BY  Nombre ASC "
                                                                        Else
                                                                            If tipo_busqueda = 18 Then 'Agente de ventas
                                                                                'consulta += "SELECT  IdColaborador,CAST(0 as bit) as ' ', (Nombre + ' ' + ApellidoPaterno + ' ' + ApellidoMaterno ) as Nombre   "
                                                                                'consulta += "FROM vColaboradores "
                                                                                'consulta += "WHERE IdPuesto in (255,895) "
                                                                                'consulta += "ORDER BY  Nombre ASC "

                                                                                consulta = "
                                                                                                SELECT clb.IdColaborador,CAST(0 as bit) as ' ',( clb.Nombre+ ' '+ clb.ApellidoPaterno+ ' ' + clb.ApellidoMaterno) AS Nombre 
		                                                                                                FROM vColaboradores clb
		                                                                                                WHERE IdPuesto =255
		                                                                                                UNION
		                                                                                                SELECT clb.IdColaborador,CAST(0 as bit) as ' ',( clb.Nombre+ ' '+ clb.ApellidoPaterno+ ' ' + clb.ApellidoMaterno +' VICENTE') AS Nombre 
		                                                                                                FROM vColaboradores_Todos clb
		                                                                                                WHERE clb.IdColaborador in (
		                                                                                                136,
		                                                                                                840,
		                                                                                                885
		                                                                                                )		
		                                                                                                ORDER by  clb.Nombre+ ' '+ clb.ApellidoPaterno+ ' ' + clb.ApellidoMaterno ASC 

                                                                                                "
                                                                            Else
                                                                                If tipo_busqueda = 19 Then 'Marcas Reporte Pedidos
                                                                                    'consulta += " select marc_codigosicy AS 'Parametro',CAST(0 AS BIT) AS ' ', marc_descripcion AS 'Marca' from Programacion.Marcas where marc_activo = 1 "
                                                                                    consulta += " select marc_codigosicy AS 'Parametro',CAST(0 AS BIT) AS ' ', marc_descripcion AS 'Marca' from Programacion.Marcas where marc_activo = 1 and marc_marcaid not in(7,8) "
                                                                                Else
                                                                                    If tipo_busqueda = 20 Then 'Clientes Reporte Pedidos y prospecta

                                                                                        parametro = New SqlParameter
                                                                                        parametro.ParameterName = "@usuarioId"
                                                                                        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                                                                                        listaParametros.Add(parametro)

                                                                                        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_Apartados_ConsultarProspecta]", listaParametros)
                                                                                        'consulta += " select clie_idsicy as 'Parametro', CAST(0 AS BIT) as ' ',clie_nombregenerico as Cliente  from Cliente.Cliente where clie_activo = 1 and clie_comercializadoraid = (SELECT cl.labo_naveid FROM Nomina.ColaboradorLaboral cl WHERE cl.labo_colaboradorid = (SELECT u.user_colaboradorid FROM Framework.Usuarios u WHERE u.user_usuarioid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + "))"
                                                                                    Else
                                                                                        If tipo_busqueda = 21 Then 'Familias Reporte Pedidos
                                                                                            consulta += " select fapr_familiaproyeccionid as 'Parametro', CAST(0 as BIT) as ' ', fapr_descripcion as Familia from Programacion.Familias_Proyeccion where fapr_activo = 1 "
                                                                                        Else
                                                                                            If tipo_busqueda = 22 Then ' Atnc a Clinetes Prospecta
                                                                                                consulta += "SELECT  DISTINCT  cb.codr_colaboradorid, CAST(0 as bit) as ' ',( cb.codr_nombre + ' '+ CB.codr_apellidopaterno + ' ' + CB.codr_apellidomaterno) AS Nombre "
                                                                                                consulta += "FROM Cliente.Cliente cl  "
                                                                                                consulta += "INNER JOIN Nomina.Colaborador cb "
                                                                                                consulta += "on cl.clie_colaboradorid_atnc= cb.codr_colaboradorid "
                                                                                                consulta += "WHERE CL.clie_activo = 1 "
                                                                                                consulta += "ORDER by Nombre ASC "
                                                                                            ElseIf tipo_busqueda = 23 Then
                                                                                                Return operaciones.EjecutarConsultaSP("[Ventas].[SP_EstadisticoPedidos_ConsultasFiltros_Coleccion]", New List(Of SqlParameter))
                                                                                            ElseIf tipo_busqueda = 24 Then
                                                                                                consulta += " select clie_idsicy as 'Parametro', CAST(0 AS BIT) as ' ',clie_nombregenerico as Cliente  from Cliente.Cliente where clie_activo = 1 "
                                                                                            End If
                                                                                        End If
                                                                                    End If
                                                                                End If
                                                                            End If
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        'If tipo_busqueda = 1 Or tipo_busqueda = 2 Or tipo_busqueda = 4 Then
        Return operaciones.EjecutaConsulta(consulta)
        'Else
        ' Return operaciones_sicy.EjecutaConsulta(consulta)
        ' End If


    End Function


    Public Function consultaGenerarApartados(ByVal FiltrosApartados As Entidades.FiltrosGeneracionApartadosPPCP) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Marca"
        parametro.Value = FiltrosApartados.PMarca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSAY"
        parametro.Value = FiltrosApartados.PPedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSICY"
        parametro.Value = FiltrosApartados.PPedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = FiltrosApartados.PCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tienda"
        parametro.Value = FiltrosApartados.PTienda
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Coleccion"
        parametro.Value = FiltrosApartados.PColeccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Modelo"
        parametro.Value = FiltrosApartados.PModelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Corrida"
        parametro.Value = FiltrosApartados.PCorrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Ranking"
        parametro.Value = FiltrosApartados.PRanking
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Nave"
        parametro.Value = FiltrosApartados.PNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Temporada"
        parametro.Value = ""
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaEntregaDel"
        parametro.Value = FiltrosApartados.PFechaEntregaDel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaEntregaAl"
        parametro.Value = FiltrosApartados.PFechaEntregaAl
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaProgramaDel"
        parametro.Value = FiltrosApartados.PFechaProgramaDel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaProgramaAl"
        parametro.Value = FiltrosApartados.PFechaProgramaAl
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Excluir_final"
        parametro.Value = FiltrosApartados.PFinal_o_Descartar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CantidadTallasExcluir_Final"
        parametro.Value = FiltrosApartados.PCantidadTallas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CantidadParesTallasExcluir_Final"
        parametro.Value = FiltrosApartados.PCantidadPares
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ConsultaGenerarApartadosPPCP", listaParametros)

    End Function



    'Public Function consultaParesTallasPartidasSinProcedimiento(detallePedidoID As String) As DataTable

    '    Dim operaciones As New Persistencia.OperacionesProcedimientos

    '    Dim consulta As String = String.Empty
    '    'consulta += " select pdta_talla AS Talla, pdta_pares_solicitados as Pares from Ventas.PedidosDetallesPorTalla where pdta_pedidodetalleid = " + detallePedidoID
    '    consulta += " DECLARE @Talla as varchar(max)"
    '    consulta += " DECLARE @cadenaPivote  as varchar(max)"
    '    consulta += " SELECT"
    '    consulta += " 	@Talla = COALESCE(@Talla + '], [', '[') + tallas.Talla"
    '    consulta += " FROM (select distinct(pdta_talla) AS Talla from Ventas.PedidosDetallesPorTalla where pdta_pedidodetalleid = " + detallePedidoID + ") tallas ORDER by tallas.Talla"

    '    consulta += " SET @Talla = @Talla + ']'"


    '    ' consulta += " SET @cadenaPivote = 'select * from (select pdta_talla AS Talla, pdta_pares_solicitados as Pares from Ventas.PedidosDetallesPorTalla where pdta_pedidodetalleid = " + detallePedidoID + " )"
    '    'consulta += "  AS CONS PIVOT (sum(Pares) FOR Talla IN (' + @Talla + ')) AS pvotCLISUM'"

    '    consulta += " SET @cadenaPivote = 'select * from (select pdta_talla AS Talla, pdta_pares_solicitados as Pares, ''1 Pedido'' as Numeración from Ventas.PedidosDetallesPorTalla where pdta_pedidodetalleid = " + detallePedidoID + " )"
    '    consulta += " AS CONS PIVOT (sum(Pares) FOR Talla IN (' + @Talla + ')) AS pvotCLISUM"
    '    consulta += " union"
    '    consulta += " select * from (select pdta_talla AS Talla, 0 as Apartado, ''2 Apartado'' as Numeración from Ventas.PedidosDetallesPorTalla where pdta_pedidodetalleid = " + detallePedidoID + " )"
    '    consulta += " AS CONS PIVOT (sum(Apartado) FOR Talla IN (' + @Talla + ')) AS pvotCLISUM"
    '    consulta += " union"
    '    consulta += " select * from (select pdta_talla AS Talla, 0 as PorApartar, ''3 PorApartar'' as Numeración from Ventas.PedidosDetallesPorTalla where pdta_pedidodetalleid = " + detallePedidoID + " )"
    '    consulta += " AS CONS PIVOT (sum(PorApartar) FOR Talla IN (' + @Talla + ')) AS pvotCLISUM"
    '    consulta += " union"
    '    consulta += " select * from (select pdta_talla AS Talla, 0 as Programado, ''4 Programado'' as Numeración from Ventas.PedidosDetallesPorTalla where pdta_pedidodetalleid = " + detallePedidoID + " )"
    '    consulta += " AS CONS PIVOT (sum(Programado) FOR Talla IN (' + @Talla + ')) AS pvotCLISUM"
    '    consulta += " union"
    '    consulta += " select * from (select pdta_talla AS Talla, 0 as Prepack, ''5 Prepack'' as Numeración from Ventas.PedidosDetallesPorTalla where pdta_pedidodetalleid = " + detallePedidoID + " )"
    '    consulta += " AS CONS PIVOT (sum(Prepack) FOR Talla IN (' + @Talla + ')) AS pvotCLISUM"
    '    consulta += "  union"
    '    consulta += " select * from (select pdta_talla AS Talla, 0 as Destallado, ''6 Destallado'' as Numeración from Ventas.PedidosDetallesPorTalla where pdta_pedidodetalleid = " + detallePedidoID + " )"
    '    consulta += "  AS CONS PIVOT (sum(Destallado) FOR Talla IN (' + @Talla + ')) AS pvotCLISUM"
    '    consulta += " union"
    '    consulta += " select * from (select pdta_talla AS Talla, 0 as Pares, ''7 Pares'' as Numeración from Ventas.PedidosDetallesPorTalla where pdta_pedidodetalleid = " + detallePedidoID + " )"
    '    consulta += " AS CONS PIVOT (sum(Pares) FOR Talla IN (' + @Talla + ')) AS pvotCLISUM'"


    '    consulta += " EXEC (@cadenaPivote) "

    '    Return operaciones.EjecutaConsulta(consulta)

    'End Function


    Public Function consultaParesTallasPartidas(ByVal detallePedidoID As String, ByVal programa As String, ByVal nave As String, ByVal tipoConsulta As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "DetallePedidoId"
        parametro.Value = detallePedidoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProgramaId"
        parametro.Value = programa
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NaveId"
        parametro.Value = nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoConsulta"
        parametro.Value = tipoConsulta
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ConsultaParesTallasPedidosApartar_PPCP", listaParametros)

    End Function



    Public Function guardarApartados(ByVal idPedido As Int32, ByVal idPedidoDetalle As String, ByVal fechaPreparacionPedido As String, ByVal idCliente As Integer, ByVal usuarioCaptura As Int32, ByVal observacionApartado As String, ByVal origenApartado As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "PedidoSAY"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdDetallePedidoSAY"
        parametro.Value = idPedidoDetalle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaPreparacionPedido"
        parametro.Value = fechaPreparacionPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioCapturaId"
        parametro.Value = usuarioCaptura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ObservacionApartado"
        parametro.Value = observacionApartado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OrigenApartado"
        parametro.Value = origenApartado
        listaParametros.Add(parametro)

        'Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_InsertarApartadoDetalle", listaParametros)
        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_InsertarApartadoDetalle_PRUEBACAMBIOGENERACION", listaParametros)

    End Function

    Public Function guardarApartadosSICY() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY

        Return objPersistencia.EjecutaConsulta("EXEC Ventas.SP_Apartados_SAY_InsertarApartadosSICY")

    End Function

    Public Function consultaAdministradorApartados(ByVal FiltrosAdministradorApartados As Entidades.FiltrosAdministradorApartados) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Detallado"
        parametro.Value = FiltrosAdministradorApartados.PDetallado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PorTallas"
        parametro.Value = FiltrosAdministradorApartados.PPorTallas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoFecha"
        parametro.Value = FiltrosAdministradorApartados.PTipoFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaDel"
        parametro.Value = FiltrosAdministradorApartados.PFechaDel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaAl"
        parametro.Value = FiltrosAdministradorApartados.PFechaAl
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstatusApartado"
        parametro.Value = FiltrosAdministradorApartados.PEstatusApartado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OrigenApartado"
        parametro.Value = FiltrosAdministradorApartados.POrigenApartado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Impreso"
        parametro.Value = FiltrosAdministradorApartados.PImpreso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Urgente"
        parametro.Value = FiltrosAdministradorApartados.PUrgente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSay"
        parametro.Value = FiltrosAdministradorApartados.PPedidoSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSICY"
        parametro.Value = FiltrosAdministradorApartados.PPedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioApartado"
        parametro.Value = FiltrosAdministradorApartados.PFolioApartado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = FiltrosAdministradorApartados.PCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TiendaEmbarqueCEDIS"
        parametro.Value = FiltrosAdministradorApartados.PTiendaEmbarqueCEDIS
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Marca"
        parametro.Value = FiltrosAdministradorApartados.PMarca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Operador"
        parametro.Value = FiltrosAdministradorApartados.POperador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Coleccion"
        parametro.Value = FiltrosAdministradorApartados.PColeccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Modelo"
        parametro.Value = FiltrosAdministradorApartados.PModelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Piel"
        parametro.Value = FiltrosAdministradorApartados.PPiel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Color"
        parametro.Value = FiltrosAdministradorApartados.PColor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Corrida"
        parametro.Value = FiltrosAdministradorApartados.PCorrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ConUbicacion"
        parametro.Value = FiltrosAdministradorApartados.PVerUbicaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cedis"
        parametro.Value = FiltrosAdministradorApartados.PCedis
        listaParametros.Add(parametro)

        'Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ConsultaAdministradorApartados_Empaque", listaParametros)
        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_ConsultaAdministradorApartados_Empaque_V3]", listaParametros)

    End Function


    Public Function consultaAdministradorApatadosConTallas(ByVal FiltrosAdministradorApartados As Entidades.FiltrosAdministradorApartados) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Detallado"
        parametro.Value = FiltrosAdministradorApartados.PDetallado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PorTallas"
        parametro.Value = FiltrosAdministradorApartados.PPorTallas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoFecha"
        parametro.Value = FiltrosAdministradorApartados.PTipoFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaDel"
        parametro.Value = FiltrosAdministradorApartados.PFechaDel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaAl"
        parametro.Value = FiltrosAdministradorApartados.PFechaAl
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstatusApartado"
        parametro.Value = FiltrosAdministradorApartados.PEstatusApartado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OrigenApartado"
        parametro.Value = FiltrosAdministradorApartados.POrigenApartado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Impreso"
        parametro.Value = FiltrosAdministradorApartados.PImpreso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Urgente"
        parametro.Value = FiltrosAdministradorApartados.PUrgente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSay"
        parametro.Value = FiltrosAdministradorApartados.PPedidoSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSICY"
        parametro.Value = FiltrosAdministradorApartados.PPedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioApartado"
        parametro.Value = FiltrosAdministradorApartados.PFolioApartado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = FiltrosAdministradorApartados.PCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TiendaEmbarqueCEDIS"
        parametro.Value = FiltrosAdministradorApartados.PTiendaEmbarqueCEDIS
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Marca"
        parametro.Value = FiltrosAdministradorApartados.PMarca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Operador"
        parametro.Value = FiltrosAdministradorApartados.POperador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Coleccion"
        parametro.Value = FiltrosAdministradorApartados.PColeccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Modelo"
        parametro.Value = FiltrosAdministradorApartados.PModelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Piel"
        parametro.Value = FiltrosAdministradorApartados.PPiel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Color"
        parametro.Value = FiltrosAdministradorApartados.PColor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Corrida"
        parametro.Value = FiltrosAdministradorApartados.PCorrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ConUbicacion"
        parametro.Value = FiltrosAdministradorApartados.PVerUbicaciones
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ConsultaAdministradorApartadosConTallas", listaParametros)

    End Function

    Public Function priorizarApartadosPrimeraVez(ByVal ApartadosIds As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ApartadoId"
        parametro.Value = ApartadosIds
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ModificaPrioridadesApartadosPrimeraVez", listaParametros)

    End Function

    Public Function priorizarApartadosUrgencias(ByVal ApartadosIds As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ApartadoId"
        parametro.Value = ApartadosIds
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ModificaPrioridadesApartadosUrgencias", listaParametros)

    End Function

    Public Function priorizarNuevamenteApartados(ByVal ApartadosIds As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ApartadoId"
        parametro.Value = ApartadosIds
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SolicitaRespuesta"
        parametro.Value = 1
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ModificaPrioridadesTodosApartados", listaParametros)

    End Function

    Public Function editarDatosApartado(ByVal apartadoId As String, ByVal tipoModificacion As Integer, ByVal fechaPreparacion As String, ByVal operadorAsignado As Integer, ByVal observacionesApartado As String, ByVal UsuarioModifico As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ApartadoId"
        parametro.Value = apartadoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoModificacion"
        parametro.Value = tipoModificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaPreparacion"
        parametro.Value = fechaPreparacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idOperador"
        parametro.Value = operadorAsignado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "observacionesApartado"
        parametro.Value = observacionesApartado
        listaParametros.Add(parametro)

        'este es el parametro del id de usuario que modifica el apartado
        parametro = New SqlParameter
        parametro.ParameterName = "usuarioModifico"
        parametro.Value = UsuarioModifico
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_EditarDatosDeApartado", listaParametros)

    End Function

    Public Function consultarDetallesPartidasApartados(ByVal apartadosIds As String, ByVal totalApartados As Integer, ByVal consolidacion As Integer, ByVal conExistencia As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ApartadoId"
        parametro.Value = apartadosIds
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalApartados"
        parametro.Value = totalApartados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Consolidacion"
        parametro.Value = consolidacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ConExistencia"
        parametro.Value = conExistencia
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_SeleccionarDetallesDeApartados", listaParametros)

    End Function

    Public Function consultarDetallesParesApartados(ByVal apartadosIds As String, ByVal consolidacion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ApartadoId"
        parametro.Value = apartadosIds
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Consolidacion"
        parametro.Value = consolidacion
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_SeleccionarDetallesParesDeApartados", listaParametros)

    End Function

    Public Function consultaMotivosCancelacion() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ConsultaMotivosCancelacion", Nothing)

    End Function

    Public Function cancelarApartados(ByVal apartadosCancelar As String, ByVal motivosCancelacion As String, ByVal observacionesCancelacion As String, ByVal usuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdApartadosCancelar"
        parametro.Value = apartadosCancelar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdMotivosCancelacion"
        parametro.Value = motivosCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ObservacionesCancelaciones"
        parametro.Value = observacionesCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCancelo"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_CancelarApartadosCompletos", listaParametros)

    End Function

    Public Function cancelarPartidas(ByVal partidasCancelar As String, ByVal motivosCancelacion As String, ByVal observacionesCancelacion As String, ByVal usuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdApartadoDetalleCancelar"
        parametro.Value = partidasCancelar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdMotivosCancelacion"
        parametro.Value = motivosCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ObservacionesCancelaciones"
        parametro.Value = observacionesCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCancelo"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_CancelarApartadosPartida_Parcial]", listaParametros)

    End Function

    Public Function consultaApartadosCanceladosDia(ByVal tipoConsulta As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "TipoConsulta"
        parametro.Value = tipoConsulta
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ConsultasApartadosCancelados", listaParametros)

    End Function

    Public Function consultaCorreosEnvioCancelacion(ByVal ClaveEnvio As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ClaveEnvio"
        parametro.Value = ClaveEnvio
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ConsultaDatosCorreosCancelacionApartados", listaParametros)

    End Function

    Public Function busquedaPartidasApartadosParaCorreoCancelacion(ByVal idApartadoOPartida As Integer, ByVal TipoBusqueda As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdBuscar"
        parametro.Value = idApartadoOPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoConsulta"
        parametro.Value = TipoBusqueda
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_Correo_ConsultasPartidasApartadosCancelados", listaParametros)

    End Function

    Public Function imprimirOrdenApartado(ByVal idApartados As String, ByVal TipoBusqueda As Integer, ByVal Consolidado As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdBuscar"
        parametro.Value = idApartados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoConsulta"
        parametro.Value = TipoBusqueda
        listaParametros.Add(parametro)

        If Consolidado Then
            Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ConsultaApartadosImpresion_Consolidado", listaParametros)
        Else
            Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ConsultaApartadosImpresion", listaParametros)
        End If

    End Function

    Public Function imprimirOrdenApartadoTotalUbicacionTallas(ByVal idApartados As String, ByVal tallas As String, ByVal Consolidado As Boolean, ByVal Corridas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdBuscar"
        parametro.Value = idApartados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tallas"
        parametro.Value = tallas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Consolidado"
        If Consolidado Then
            parametro.Value = 1
        Else
            parametro.Value = 0
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Corridas"
        parametro.Value = Corridas
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ConsultaApartadosImpresion_TotalUbicacionTallas", listaParametros)

    End Function


#Region "CONFIRMACIÓN APARTADOS"

    Public Function validaAtadoLeidoConfirmacion(ByVal NumeroAtado As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "codigo"
        parametro.Value = NumeroAtado
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_Confirmacion_ValidaAtadoLeido", listaParametros)
    End Function

    Public Function ValidarParLeidoConfirmacion(ByVal codigo As String, ByVal atado As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "codigo"
        parametro.Value = codigo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EsAtado"
        parametro.Value = atado
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_Confirmacion_ValidaParLeido", listaParametros)
    End Function

    Public Function consultarDatosApartadoAConfirmar(ByVal apartadoId As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ApartadoId"
        parametro.Value = apartadoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Confirmacion_Consulta"
        parametro.Value = 0
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Automatico"
        parametro.Value = 0
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OperadorConsultaId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        'Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_SeleccionarDatosDeApartadoAConfirmar", listaParametros)
        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_SeleccionarDatosDeApartadoAConfirmar_CambioDatosGenerales", listaParametros)

    End Function

    Public Function InsertarParConfirmado(ByVal Par As Entidades.ParesConfirmarApartado, ByVal apartadoDetallePorTallaId As Integer, ByVal colaboradorConfirmoId As Integer, ByVal apartadoSICY As Integer, ByVal pedidoSICY As Integer, ByVal IdCadena As Integer) As Integer
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "apartadoDetallePorTallaId"
        parametro.Value = apartadoDetallePorTallaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CodigoPar"
        parametro.Value = Par.PPar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CodigoAtado"
        parametro.Value = Par.PAtado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idNave"
        parametro.Value = Par.PIdNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idLote"
        parametro.Value = Par.PLote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "añoLote"
        parametro.Value = Par.PAño
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorConfirmoId"
        parametro.Value = colaboradorConfirmoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "origenConfirmacion"
        parametro.Value = "A"
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstibaId"
        parametro.Value = ""
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaEntradaAlmacen"
        Par.PFechaEntradaAlmacen = Format(DateTime.Parse(Par.PFechaEntradaAlmacen), "dd/MM/yyyy HH:mm:ss")
        parametro.Value = Par.PFechaEntradaAlmacen
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ApartadoIdSICY"
        parametro.Value = apartadoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPedidoSICY"
        parametro.Value = pedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdCadena"
        parametro.Value = IdCadena
        listaParametros.Add(parametro)

        ' Return objPersistencia.EjecutarSentenciaSP("Ventas.SP_Apartados_Confirmacion_ConfirmarPares", listaParametros)
        Return objPersistencia.EjecutarSentenciaSP("Ventas.SP_Apartados_Confirmacion_ConfirmarPares_CambiosDatosGenerales", listaParametros)
    End Function

    Public Function ActualizaPartidasYApartadosDespuesDeConfirmacion(ByVal idApartado As Integer, ByVal colaboradorConfirmoId As Integer) As Integer
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "apartadoId"
        parametro.Value = idApartado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorConfirmoId"
        parametro.Value = colaboradorConfirmoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "origenConfirmacion"
        parametro.Value = "E"
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarSentenciaSP("Ventas.SP_Apartados_Confirmacion_ActualizarDatosPartidasYApartado", listaParametros)

    End Function

    Public Function consultarParesDisponiblesApartado(ByVal ApartadoId As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ApartadoId"
        parametro.Value = ApartadoId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_SeleccionarParesDisponiblesEnInventarioParaApartar", listaParametros)

    End Function


    Public Function ConfirmacionIncompleta(ByVal ApartadoId As Integer, ByVal UsuarioId As Integer, ByVal Observacion As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdApartado"
        parametro.Value = ApartadoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ObservacionIncompleta"
        parametro.Value = Observacion
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ConfirmacionIncompletaApartado", listaParametros)

    End Function

#End Region


    Public Function verificaDisponibilidadApartar(ByVal EstatusGenerandoApartado As Integer, ByVal Usuario As String, ByVal Origen As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "usuarioRealizaApartado"
        parametro.Value = Usuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "origenIntentaApartar"
        parametro.Value = Origen
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatusGenerandoApartado"
        parametro.Value = EstatusGenerandoApartado
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_verificaDisponibilidadGenerarapartado", listaParametros)

    End Function

    Public Function consultaCorreosEnvioConfirmacionIncompleta(ByVal ClaveEnvio As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ClaveEnvio"
        parametro.Value = ClaveEnvio
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ConsultaDatosCorreosConfirmacionIncompletaApartados", listaParametros)

    End Function

    Public Function validarParesPorConfirmarArchivoCargado(ByVal CodigosEscaneados As String, ByVal ApartadosEscaneados As String, ByVal TiposCodigosEscaneados As String, ByVal TipoConsulta As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "CodigosPares"
        parametro.Value = CodigosEscaneados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idsApartados"
        parametro.Value = ApartadosEscaneados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TiposCodigos"
        parametro.Value = TiposCodigosEscaneados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoConsulta"
        parametro.Value = TipoConsulta
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_Confirmar_VerificarDisponibilidadParesEnArchivo", listaParametros)

    End Function

    Public Function ConsultaCorreoUsuarioCaptura(ByVal IdApartado As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdApartado"
        parametro.Value = IdApartado
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ConsultaDatosCorreosCancelacionApartadosEjecutivas", listaParametros)

    End Function

    Public Function consultaInventarioDisponible(cedis As Integer) As DataTable
        Dim objPersistenciaSICY As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@cedis"
        parametro.Value = cedis
        listaParametros.Add(parametro)

        Return objPersistenciaSICY.EjecutarConsultaSP("[Ventas].[SP_Apartados_SAY_ConsultaInventarioDisponible]", listaParametros)
        'Return objPersistenciaSICY.EjecutaConsulta("EXEC Ventas.SP_Apartados_SAY_ConsultaInventarioDisponible")

    End Function

    Public Function consultaPrioridadClientesApartar() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Return objPersistencia.EjecutaConsulta("EXEC Ventas.SP_Apartados_ConsultaPrioridadClientesApartar")

    End Function

    Public Function modificarPrioridadesClientesApartar(ByVal Cliente As String, ByVal Prioridad As String, ByVal SolicitaRespuesta As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Clientes"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Prioridades"
        parametro.Value = Prioridad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SolicitaRespuesta"
        parametro.Value = SolicitaRespuesta
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ModificarPrioridadesClientesApartar", listaParametros)

    End Function

    Public Sub verDisponibilidadGenerarApartado(ByVal PedidosDetalles As String, ByVal Naves As String, ByVal Programas As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "PedidoDetalleID"
        parametro.Value = PedidosDetalles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NaveSeleccionadaId"
        parametro.Value = Naves
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProgramaSeleccionadoId"
        parametro.Value = Programas
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_PPCP_Paso1_PedidosDetalles_PorApartar", listaParametros)
    End Sub

    Public Sub generarInventarioDisponible()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        objPersistencia.EjecutaConsulta("exec Ventas.SP_Apartados_PPCP_Paso2_ApartadosPendientesPorConfirmar_Inventario")
    End Sub

    Public Sub generarDistribucionApartados()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        objPersistencia.EjecutaConsulta("exec Ventas.SP_Apartados_PPCP_Paso3_AsignarPares_ApartadoPorConfirmar")
    End Sub

    Public Function seleccionarPartidasConDistribucion(ByVal tipoConsulta As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "tipoConsulta"
        parametro.Value = tipoConsulta
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_PPCP_SeleccionarDatosPartidasDistribucion", listaParametros)
    End Function

    Public Sub actualizarApartadosPorGenerar(ByVal filtrosGenerarApartados As Entidades.FiltrosGeneracionApartadosPPCP)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "atadosNones"
        parametro.Value = filtrosGenerarApartados.PAtadoNON
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "atadosPares"
        parametro.Value = filtrosGenerarApartados.PAtadoPAR
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "atadosPunto"
        parametro.Value = filtrosGenerarApartados.PAtadoPUNTO
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "paresDestallados"
        parametro.Value = filtrosGenerarApartados.PParesDestallados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "destallarNormales"
        parametro.Value = filtrosGenerarApartados.PDestallarNormales
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "destallarPunto"
        parametro.Value = filtrosGenerarApartados.PDestallarPuntos
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_PPCP_Paso4_ApartadosPendientesPorGenerar_Inventario]", listaParametros)
    End Sub

    Public Sub actualizarTotalesDistribucionPartidasPorGenerar()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        objPersistencia.EjecutaConsulta("exec [Ventas].[SP_Apartados_PPCP_ActualizarTotalesDistribucionEnPartida] ")
    End Sub

    Public Sub RegenerarDistribucionPartidasModificadas(ByVal filtrosGenerarApartados As Entidades.FiltrosGeneracionApartadosPPCP)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FiltroAtadosNones"
        parametro.Value = filtrosGenerarApartados.PAtadoNON
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FiltroAtadosPares"
        parametro.Value = filtrosGenerarApartados.PAtadoPAR
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FiltroAtadosPunto"
        parametro.Value = filtrosGenerarApartados.PAtadoPUNTO
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FiltroParesDestallados"
        parametro.Value = filtrosGenerarApartados.PParesDestallados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FiltroDestallarNormales"
        parametro.Value = filtrosGenerarApartados.PDestallarNormales
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FiltroDestallarPunto"
        parametro.Value = filtrosGenerarApartados.PDestallarPuntos
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_PPCP_Regenerar_Distribucion_ApartadoPorGenerar_PartidasModificadas]", listaParametros)
    End Sub

    Public Sub ModificacionesPartidas(ByVal pedidoDetallesId As String, ByVal NaveId As String, ByVal ProgramaId As String, ByVal tipoActualizacion As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "PartidaIdModificarOrden"
        parametro.Value = pedidoDetallesId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NaveId"
        parametro.Value = NaveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProgramaId"
        parametro.Value = ProgramaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoActualizacion"
        parametro.Value = tipoActualizacion
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_PPCP_ActualizarCamposModificacionPartidasApartadosPorGenerar]", listaParametros)
    End Sub

    Public Function consultaParesDistribucionPartida(ByVal detallePedidoID As String, ByVal NaveIdSAY As Integer, ByVal ProgramaId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "DetallePedidoId"
        parametro.Value = detallePedidoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NaveIdSay"
        parametro.Value = NaveIdSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProgramaId"
        parametro.Value = ProgramaId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ConsultaDistribucionPedidosApartar_PPCP", listaParametros)

    End Function

    Public Sub modificarTotalesTallasPartidas(ByVal detallePedidoID As Integer, ByVal Tallas As String, ByVal TotalesTallas As String, ByVal NaveId As Integer, ByVal ProgramaId As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "PedidoDetalleId"
        parametro.Value = detallePedidoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NaveIdSAY"
        parametro.Value = NaveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProgramaId"
        parametro.Value = ProgramaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tallas"
        parametro.Value = Tallas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalesPorTalla"
        parametro.Value = TotalesTallas
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_PPCP_ModificarTotalesPortalla_PartidasPorApartar]", listaParametros)

    End Sub

    Public Function guardarApartadosPPCP(ByVal apartadoInsertar As Entidades.ApartadoPorGenerar_PPCP) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "PedidoSAY"
        parametro.Value = apartadoInsertar.PPedidoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdDetallePedidoSAY"
        parametro.Value = apartadoInsertar.PIdDetallePedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaPreparacionPedido"
        parametro.Value = apartadoInsertar.PFechaPreparacionPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCliente"
        parametro.Value = apartadoInsertar.PIdCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioCapturaId"
        parametro.Value = apartadoInsertar.PUsuarioCapturaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ObservacionApartado"
        ' parametro.Value = Replace(apartadoInsertar.PObservacionApartado, "_", "")
        parametro.Value = ""
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OrigenApartado"
        parametro.Value = apartadoInsertar.POrigenApartado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NavesIdSAY"
        parametro.Value = apartadoInsertar.PNaveSAYId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProgramasId"
        parametro.Value = apartadoInsertar.PProgramaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ConDisponibilidad"
        parametro.Value = apartadoInsertar.PConDisponibilidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ConDistribucion"
        parametro.Value = apartadoInsertar.PConDistribucion
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_InsertarApartadoDetalle_PPCP]", listaParametros)
    End Function

    Public Sub RegenerarDistribucionPartidasModificadasM3(ByVal filtrosGenerarApartados As Entidades.FiltrosGeneracionApartadosPPCP, ByVal PedidoDetalleID As Integer, ByVal NaveId As Integer, ByVal ProgramaId As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FiltroAtadosNones"
        parametro.Value = filtrosGenerarApartados.PAtadoNON
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FiltroAtadosPares"
        parametro.Value = filtrosGenerarApartados.PAtadoPAR
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FiltroAtadosPunto"
        parametro.Value = filtrosGenerarApartados.PAtadoPUNTO
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FiltroParesDestallados"
        parametro.Value = filtrosGenerarApartados.PParesDestallados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FiltroDestallarNormales"
        parametro.Value = filtrosGenerarApartados.PDestallarNormales
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FiltroDestallarPunto"
        parametro.Value = filtrosGenerarApartados.PDestallarPuntos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoDetalleId"
        parametro.Value = PedidoDetalleID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NaveSAYId"
        parametro.Value = NaveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProgramaID"
        parametro.Value = ProgramaId
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_PPCP_Regenerar_Distribucion_ApartadoPorGenerar_PartidasModificadasPorDistribucion]", listaParametros)
    End Sub

    Public Function consultaResumenApartadosGenerados(ByVal tipoConsulta As Integer, ByVal apartadosGenerados As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "tipoConsulta"
        parametro.Value = tipoConsulta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "apartadosGenerados"
        parametro.Value = apartadosGenerados
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_PPCP_SeleccionarResumenApartados]", listaParametros)

    End Function

    Public Function descontarParesDeLotesA() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Return objPersistencia.EjecutaConsulta("EXEC [Ventas].[SP_Apartados_PPCP_QuitarParesDeProgamas]")

    End Function

    Public Function crearInventarioInicialTemporal() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY

        Return objPersistencia.EjecutaConsulta("EXEC [Ventas].[SP_Apartados_SAY_InsertarInventarioTemporalInicial]")

    End Function

    Public Function crearRespaldoLotesProgramasEnSAY() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY

        Return objPersistencia.EjecutaConsulta("EXEC [Ventas].[SP_Apartados_SAY_InsertarDatosLotesProgramas]")

    End Function

    Public Function actualizarTallasDesdeLotesA(ByVal idPedidosPartidasId As Integer, ByVal idPedido As Integer, ByVal idPartida As Integer, ByVal idPrograma As Integer, ByVal idNave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdPedidosPartidasId"
        parametro.Value = idPedidosPartidasId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPartida"
        parametro.Value = idPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPrograma"
        parametro.Value = idPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idNave"
        parametro.Value = idNave
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_SAY_ConsultarTallasPorPedidoPartidaNavePrograma]", listaParametros)

    End Function

    Public Function ListadoParametroApartadosPPCP(tipo_busqueda As Integer) As DataTable

        'Dim operaciones_sicy As New Persistencia.OperacionesProcedimientosSICY
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        If tipo_busqueda = 1 Then 'Marcas
            consulta += " select marc_marcaid AS 'Parametro',CAST(0 AS BIT) AS ' ', marc_descripcion AS 'Marca' from Programacion.Marcas where marc_activo = 1 order by marc_descripcion "
        Else
            If tipo_busqueda = 2 Then 'Clientes
                'consulta += " select clie_clienteid as 'Parametro', CAST(0 AS BIT) as ' ',clie_idsicy,clie_nombregenerico as Nombre,clie_clasificacionclienteid as Clasificacion,"
                'consulta += " clie_ranking as Ranking, CASE WHEN B.Captura+B.Programacion+B.Entrega+B.Contado > 0 THEN 'Si' ELSE 'No' END AS Bloqueado, B.Captura+B.Programacion+B.Entrega+B.Contado as bloqueadoNumero"
                consulta += " select clie_clienteid as 'Parametro', CAST(0 AS BIT) as ' ',clie_nombregenerico as Nombre,clie_clasificacionclienteid as Clasificación,"
                consulta += " clie_ranking as Ranking, CASE WHEN B.bloq_captura+B.bloq_programacion+B.bloq_entrega > 0 THEN 'SI' ELSE 'NO' END AS Bloqueado"
                consulta += "  from Cliente.Cliente C"
                consulta += " LEFT JOIN Programacion.bloqueos B ON b.bloq_clienteid = c.clie_clienteid and B.bloq_semana = DATEPART(wk,GETDATE()) AND B.bloq_año = DATEPART(YEAR,GETDATE()) "
                consulta += " where clie_activo=1 and clie_clienteid <> 1071 and clie_clienteid <> 1072  order by clie_nombregenerico "
            Else
                If tipo_busqueda = 3 Then 'Colección
                    'consulta += " select cole_coleccionid as 'Parámetro', CAST(0 as bit) as ' ',cole_descripcion as 'Colección', t.temp_nombre as Temporada, cole_anio as Año"
                    'consulta += " from Programacion.Colecciones c inner join Programacion.Temporadas t on c.cole_temporadaid = t.temp_temporadaid where cole_activo= 1 order by cole_descripcion asc, c.cole_Anio asc, t.temp_nombre ASC "
                    consulta += " select cole_coleccionid as 'Parámetro', CAST(0 as bit) as ' ',m.marc_descripcion as 'Marca',cole_descripcion as 'Colección', t.temp_nombre as Temporada, cole_anio as Año"
                    consulta += " from Programacion.Colecciones c inner join Programacion.Temporadas t on c.cole_temporadaid = t.temp_temporadaid "
                    consulta += " LEFT join Programacion.ColeccionMarca cm on c.cole_coleccionid = cm.coma_coleccionid left join Programacion.Marcas m on cm.coma_marcaid = m.marc_marcaid"
                    consulta += " where cole_activo= 1 order by  m.marc_descripcion asc,cole_descripcion asc, t.temp_nombre ASC "
                Else
                    If tipo_busqueda = 4 Then 'Naves
                        consulta += " select nave_naveid as Parámetro,CAST(0 as bit) as ' ',nave_nombre as Nave,nave_idSicy as NaveSICY from Programacion.NavesAux where nave_activo = 1 order by nave_nombre asc"
                    Else
                        If tipo_busqueda = 5 Then 'Tiendas
                            consulta += " SELECT tiec.tiec_tiendaembarquecedisid as 'Parámetro',CAST(0 AS BIT) AS ' ',tiec.tiec_tiendaembarquecedisid as ID, c.clie_nombregenerico as Cliente, per.pers_nombre as 'Tiendas / Embarques / CEDIS' from Cliente.TiendaEmbarqueCEDIS tiec inner join Framework.Persona per on tiec.tiec_personaid = per.pers_personaid inner join Cliente.Cliente c on tiec.tiec_clienteid = c.clie_clienteid ORDER BY  c.clie_nombregenerico, per.pers_nombre"
                        Else
                            If tipo_busqueda = 6 Then 'Modelo por apartar
                                consulta += " SELECT DISTINCT(ModeloSAY) as 'Parámetro', CAST(0 as bit) as ' ', ModeloSAY as Modelo FROM Ventas.vApartados_PedidosPorApartar order by Modelo "
                            Else
                                If tipo_busqueda = 7 Then 'Corridas
                                    'consulta += " select talla_tallaid as 'Parámetro', CAST(0 as bit) as ' ', talla_descripcion as Corrida, talla_sicy from Programacion.Tallas where talla_activo=1 "
                                    consulta += " select talla_tallaid as 'Parámetro', CAST(0 as bit) as ' ', talla_descripcion as Corrida from Programacion.Tallas where talla_activo=1 and talla_paisid = 1 order by talla_descripcion asc"
                                Else
                                    If tipo_busqueda = 8 Then 'Ranking
                                        consulta += " SELECT distinct(invi_ranking) as 'Parámetro', cast(0 as bit) as ' ', invi_ranking as Ranking FROM Programacion.InventarioIdealExcel order by Ranking asc "
                                    Else
                                        If tipo_busqueda = 9 Then 'Temporada
                                            consulta += " select temp_temporadaid as 'Parámetro', cast(0 as bit) as ' ', temp_nombre as Temporada from Programacion.Temporadas where temp_activo = 1 "
                                        Else
                                            If tipo_busqueda = 10 Then 'Operador
                                                consulta += " SELECT " +
                                                    "   A.codr_colaboradorid AS 'Parámetro' " +
                                                    " , CAST (0 AS bit) AS ' ' " +
                                                    " , CAST(A.codr_nombre + ' ' + A.codr_apellidopaterno + ' ' + A.codr_apellidomaterno AS varchar(200)) AS 'Operador' " +
                                                    " FROM [Nomina].[Colaborador] AS A " +
                                                    " JOIN [Nomina].[ColaboradorLaboral] AS B ON B.labo_colaboradorid = A.codr_colaboradorid " +
                                                    " JOIN [Framework].[Grupos] AS C ON C.grup_grupoid = B.labo_departamentoid " +
                                                    " WHERE A.codr_activo = 1 AND C.grup_grupoid in( 97,327) ORDER BY A.codr_nombre "
                                            Else
                                                If tipo_busqueda = 11 Then 'Modelo
                                                    'consulta += " select DISTINCT(ModeloSAY) as 'Parámetro', CAST(0 as bit) as ' ', ModeloSAY as Modelo from Programacion.vProductoEstilos_Completo order by ModeloSAY"
                                                    ' consulta += " select DISTINCT(ModeloSAY) as 'Parámetro', CAST(0 as bit) as ' ', ModeloSAY as 'Modelo SAY', ModeloSICY as 'Modelo SICY', MarcaSAY as 'Marca', ColeccionSAY as 'Colección' from Programacion.vProductoEstilos_Completo order by ModeloSAY "
                                                    consulta += " select DISTINCT(ProductoEstiloId) as 'Parámetro', CAST(0 as bit) as ' ',MarcaSAY as 'Marca', ColeccionSAY as 'Colección',  ModeloSAY as 'Modelo SAY', ModeloSICY as 'Modelo SICY', Piel, Color, Talla as Corrida from Programacion.vProductoEstilos_Completo order by MarcaSAY asc, ColeccionSAY asc, ModeloSAY asc, ModeloSICY asc,Piel ASC, Color ASC, Talla ASC"
                                                Else
                                                    If tipo_busqueda = 12 Then 'Piel
                                                        consulta += " select piel_pielid as 'Parámetro', CAST(0 as bit) as ' ', piel_descripcion as Piel from Programacion.Pieles where piel_activo = 1 ORDER by piel_descripcion"
                                                    Else
                                                        If tipo_busqueda = 13 Then 'Color
                                                            consulta += " select color_colorid as 'Parámetro', CAST(0 as bit) as ' ', color_descripcion as Color from Programacion.Colores where color_activo = 1 ORDER by color_descripcion"
                                                        Else
                                                            If tipo_busqueda = 14 Then 'ESTATUS DE APARTADO
                                                                consulta += "select esta_estatusid as ID, esta_nombre as Status from Framework.Estatus where esta_tipostatus = 'APARTADO' order by esta_nombre ASC"
                                                            Else
                                                                If tipo_busqueda = 15 Then 'CLIENTES PPCP
                                                                    consulta += " select clie_clienteid as 'Parametro', CAST(0 AS BIT) as ' ',clie_nombregenerico as Nombre,clie_clasificacionclienteid as Clasificación,"
                                                                    consulta += " clie_ranking as Ranking, CASE WHEN B.bloq_captura+B.bloq_programacion+B.bloq_entrega > 0 THEN 'SI' ELSE 'NO' END AS Bloqueado"
                                                                    consulta += "  from Cliente.Cliente C"
                                                                    consulta += " LEFT JOIN Programacion.bloqueos B ON b.bloq_clienteid = c.clie_clienteid and B.bloq_semana = DATEPART(wk,GETDATE()) AND B.bloq_año = DATEPART(YEAR,GETDATE())"
                                                                    consulta += " where clie_activo=1 and  clie_puedeapartarPPCP=1 order by clie_nombregenerico "
                                                                ElseIf tipo_busqueda = 23 Then
                                                                    Return operaciones.EjecutarConsultaSP("[Ventas].[SP_EstadisticoPedidos_ConsultasFiltros_Coleccion]", New List(Of SqlParameter))
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        'If tipo_busqueda = 1 Or tipo_busqueda = 2 Or tipo_busqueda = 4 Then
        Return operaciones.EjecutaConsulta(consulta)
        'Else
        ' Return operaciones_sicy.EjecutaConsulta(consulta)
        ' End If


    End Function

    Public Function seleccionarInventarioDisponibleInicial() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY

        Return objPersistencia.EjecutaConsulta("[Ventas].[SP_Apartados_SAY_SeleccionarInventarioTemporalInicial]")

    End Function

    Public Sub InsertarInventarioDisponibleInicial_Original(ByVal CodigoSICY As String, ByVal IdCorridaSICY As String, ByVal Corrida As String, ByVal Talla As String, ByVal IdTallaSAY As Integer, ByVal Pares As Integer, ByVal ProductoEstilo As Integer, ByVal Descripcion As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "CodigoSICY"
        parametro.Value = CodigoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdCorridaSICY"
        parametro.Value = IdCorridaSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Corrida"
        parametro.Value = Corrida
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "Talla"
        parametro.Value = Talla
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "IdTallaSAY"
        parametro.Value = IdTallaSAY
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "Pares"
        parametro.Value = Pares
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "ProductoEstilo"
        parametro.Value = ProductoEstilo
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "Descripcion"
        parametro.Value = Descripcion
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_InsertarInventarioInicial_Temporal_PPCP]", listaParametros)

    End Sub

    Public Sub InsertarInventarioDisponibleInicial_V2(ByVal CodigoSICY As String, ByVal IdCorridaSICY As String, ByVal Corrida As String, ByVal Talla As String, ByVal IdTallaSAY As String, ByVal Pares As String, ByVal ProductoEstilo As String, ByVal Descripcion As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "CodigoSICY"
        parametro.Value = CodigoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdCorridaSICY"
        parametro.Value = IdCorridaSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Corrida"
        parametro.Value = Corrida
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "Talla"
        parametro.Value = Talla
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "IdTallaSAY"
        parametro.Value = IdTallaSAY
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "Pares"
        parametro.Value = Pares
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "ProductoEstilo"
        parametro.Value = ProductoEstilo
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "Descripcion"
        parametro.Value = Descripcion
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_InsertarInventarioInicial_Temporal_PPCP]", listaParametros)

    End Sub

    Public Sub InsertarInventarioDisponibleInicial()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        objPersistencia.EjecutaConsulta("[Ventas].[SP_Apartados_InsertarInventarioInicial_Temporal_PPCP]")
    End Sub

    Public Function SeleccionarDatosLotesProgramas(ByVal FiltrosApartados As Entidades.FiltrosGeneracionApartadosPPCP) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "NaveId"
        parametro.Value = FiltrosApartados.PNaveSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaProgramaInicio"
        parametro.Value = FiltrosApartados.PFechaProgramaDel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaProgramaFin"
        parametro.Value = FiltrosApartados.PFechaProgramaAl
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_SAY_SeleccionarDatosLotesProgramas]", listaParametros)

    End Function

    Public Sub InsertarDatosLotesProgramas_original(ByVal IdPedido As Integer, ByVal IdPartida As Integer, ByVal IdNave As Integer, ByVal programalote As Integer, ByVal estatusLote As String, ByVal CantLotesA As Integer, ByVal FechaPrograma As String,
     ByVal EstatusPrograma As String, ByVal LT01 As Integer, ByVal LT02 As Integer, ByVal LT03 As Integer, ByVal LT04 As Integer, ByVal LT05 As Integer, ByVal LT06 As Integer, ByVal LT07 As Integer, ByVal LT08 As Integer, ByVal LT09 As Integer,
     ByVal LT10 As Integer, ByVal LT11 As Integer, ByVal LT12 As Integer, ByVal LT13 As Integer, ByVal LT14 As Integer, ByVal LT15 As Integer, ByVal LT16 As Integer, ByVal LT17 As Integer, ByVal LT18 As Integer, ByVal LT19 As Integer,
     ByVal LT20 As Integer, ByVal TallaId As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdPedido"
        parametro.Value = IdPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPartida"
        parametro.Value = IdPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdNave"
        parametro.Value = IdNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "programalote"
        parametro.Value = programalote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatusLote"
        parametro.Value = estatusLote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CantLotesA"
        parametro.Value = CantLotesA
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaPrograma"
        parametro.Value = FechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstatusPrograma"
        parametro.Value = EstatusPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT01"
        parametro.Value = LT01
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT02"
        parametro.Value = LT02
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT03"
        parametro.Value = LT03
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT04"
        parametro.Value = LT04
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT05"
        parametro.Value = LT05
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT06"
        parametro.Value = LT06
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT07"
        parametro.Value = LT07
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT08"
        parametro.Value = LT08
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT09"
        parametro.Value = LT09
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT10"
        parametro.Value = LT10
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT11"
        parametro.Value = LT11
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT12"
        parametro.Value = LT12
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT13"
        parametro.Value = LT13
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT14"
        parametro.Value = LT14
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT15"
        parametro.Value = LT15
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT16"
        parametro.Value = LT16
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT17"
        parametro.Value = LT17
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT18"
        parametro.Value = LT18
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT19"
        parametro.Value = LT19
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT20"
        parametro.Value = LT20
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TallaId"
        parametro.Value = TallaId
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_InsertarDatosLotesProgramas_Temporal_PPCP]", listaParametros)

    End Sub

    Public Sub InsertarDatosLotesProgramas_v2(ByVal IdPedido As String, ByVal IdPartida As String, ByVal IdNave As String, ByVal programalote As String, ByVal estatusLote As String, ByVal CantLotesA As String, ByVal FechaPrograma As String,
     ByVal EstatusPrograma As String, ByVal LT01 As String, ByVal LT02 As String, ByVal LT03 As String, ByVal LT04 As String, ByVal LT05 As String, ByVal LT06 As String, ByVal LT07 As String, ByVal LT08 As String, ByVal LT09 As String,
     ByVal LT10 As String, ByVal LT11 As String, ByVal LT12 As String, ByVal LT13 As String, ByVal LT14 As String, ByVal LT15 As String, ByVal LT16 As String, ByVal LT17 As String, ByVal LT18 As String, ByVal LT19 As String,
     ByVal LT20 As String, ByVal TallaId As String, ByVal CodigoSICY As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdPedido"
        parametro.Value = IdPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPartida"
        parametro.Value = IdPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdNave"
        parametro.Value = IdNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "programalote"
        parametro.Value = programalote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatusLote"
        parametro.Value = estatusLote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CantLotesA"
        parametro.Value = CantLotesA
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaPrograma"
        parametro.Value = FechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstatusPrograma"
        parametro.Value = EstatusPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT01"
        parametro.Value = LT01
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT02"
        parametro.Value = LT02
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT03"
        parametro.Value = LT03
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT04"
        parametro.Value = LT04
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT05"
        parametro.Value = LT05
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT06"
        parametro.Value = LT06
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT07"
        parametro.Value = LT07
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT08"
        parametro.Value = LT08
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT09"
        parametro.Value = LT09
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT10"
        parametro.Value = LT10
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT11"
        parametro.Value = LT11
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT12"
        parametro.Value = LT12
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT13"
        parametro.Value = LT13
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT14"
        parametro.Value = LT14
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT15"
        parametro.Value = LT15
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT16"
        parametro.Value = LT16
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT17"
        parametro.Value = LT17
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT18"
        parametro.Value = LT18
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT19"
        parametro.Value = LT19
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LT20"
        parametro.Value = LT20
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TallaId"
        parametro.Value = TallaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CodigoSICY"
        parametro.Value = CodigoSICY
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_InsertarDatosLotesProgramas_Temporal_PPCP_Original]", listaParametros)

    End Sub

    Public Sub InsertarDatosLotesProgramas(ByVal FiltrosApartados As Entidades.FiltrosGeneracionApartadosPPCP)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "NaveId"
        parametro.Value = FiltrosApartados.PNaveSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaProgramaInicio"
        parametro.Value = FiltrosApartados.PFechaProgramaDel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaProgramaFin"
        parametro.Value = FiltrosApartados.PFechaProgramaAl
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_InsertarDatosLotesProgramas_Temporal_PPCP]", listaParametros)

    End Sub

    Public Sub consultaGenerarVistaFiltrar(ByVal FiltrosApartados As Entidades.FiltrosGeneracionApartadosPPCP)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Marca"
        parametro.Value = FiltrosApartados.PMarca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSAY"
        parametro.Value = FiltrosApartados.PPedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSICY"
        parametro.Value = FiltrosApartados.PPedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = FiltrosApartados.PCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tienda"
        parametro.Value = FiltrosApartados.PTienda
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Coleccion"
        parametro.Value = FiltrosApartados.PColeccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Modelo"
        parametro.Value = FiltrosApartados.PModelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Corrida"
        parametro.Value = FiltrosApartados.PCorrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Ranking"
        parametro.Value = FiltrosApartados.PRanking
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Temporada"
        parametro.Value = ""
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaEntregaDel"
        parametro.Value = FiltrosApartados.PFechaEntregaDel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaEntregaAl"
        parametro.Value = FiltrosApartados.PFechaEntregaAl
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_GenerarVistaParaFiltrar_PPCP", listaParametros)

    End Sub

    Public Function obtenerUltimoApartadoGenerado() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Return objPersistencia.EjecutaConsulta("EXEC [Ventas].[SP_Apartados_PPCP_SeleccionarUltimoApartadoGenerado] ")

    End Function

    Public Sub separarPartidasApartadas(ByVal pedidos As String, ByVal pedidosDetalles As String, ByVal naves As String, ByVal programas As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "PedidosId"
        parametro.Value = pedidos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidosDetallesId"
        parametro.Value = pedidosDetalles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NavesId"
        parametro.Value = naves
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProgramasId"
        parametro.Value = programas
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_PPCP_SepararPartidasApartadas]", listaParametros)

    End Sub

    Public Sub limpiarModificacionAnteriorRegenerarDistribucion()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        objPersistencia.EjecutaConsulta("EXEC [Ventas].[SP_Apartados_PPCP_Regenerar_Distribucion_ApartadoPorGenerar_LimpiarModificacionAnterior]")

    End Sub

    Public Sub distribucionApartadosPorGenerar(ByVal filtrosGenerarApartados As Entidades.FiltrosGeneracionApartadosPPCP)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "atadosNones"
        parametro.Value = filtrosGenerarApartados.PAtadoNON
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "atadosPares"
        parametro.Value = filtrosGenerarApartados.PAtadoPAR
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "atadosPunto"
        parametro.Value = filtrosGenerarApartados.PAtadoPUNTO
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "paresDestallados"
        parametro.Value = filtrosGenerarApartados.PParesDestallados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "destallarNormales"
        parametro.Value = filtrosGenerarApartados.PDestallarNormales
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "destallarPunto"
        parametro.Value = filtrosGenerarApartados.PDestallarPuntos
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_PPCP_Paso5_AsignarPares_ApartadoPorGenerar]", listaParametros)
    End Sub

    Public Function obtenerTotalApartadosPorConfirmar(ByVal tipoConsulta As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "tipoConsulta"
        parametro.Value = tipoConsulta
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_PPCP_SeleccionarTotalApartadosPendientesPorConfirmar]", listaParametros)

    End Function

    Public Function obtenerTotalParesPorConfirmar(ByVal tipoConsulta As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "tipoConsulta"
        parametro.Value = tipoConsulta
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_PPCP_SeleccionarTotalParesPendientesPorConfirmar]", listaParametros)

    End Function

    Public Function resumenDisponibilidadClientes() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Return objPersistencia.EjecutaConsulta("EXEC [Ventas].[SP_Apartados_ConsultaResumenClientesDisponibilidad_PPCP]")

    End Function

    Public Function actualizarInventarioTotalesDisponibles() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Return objPersistencia.EjecutaConsulta("EXEC [Ventas].[SP_Apartados_InsertarInventarioTotalesDisponibles_Temporal_PPCP]")

    End Function

    Public Function asignarDisponibilidadSinDistribucionApartados() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Return objPersistencia.EjecutaConsulta("EXEC [Ventas].[SP_Apartados_PPCP_AsignarDistribucionTotalesPartidasPorApartar] ")

    End Function

    Public Sub actualizarTotalesDistribucionPartidasPorGenerarSinDistribucion()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        objPersistencia.EjecutaConsulta("exec [Ventas].[SP_Apartados_PPCP_ActualizarTotalesDisponibilidadEnPartidaSinDistribucion] ")
    End Sub

    Public Function reasignarDisponibilidadSinDistribucionApartados() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Return objPersistencia.EjecutaConsulta("EXEC [Ventas].[SP_Apartados_PPCP_ReAsignarDistribucionTotalesPartidasPorApartar]")

    End Function

    Public Function descartarPartidasDeDistribucion(ByVal partidasDescartarDeApartados As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "PartidasDescartarDeApartados"
        parametro.Value = partidasDescartarDeApartados
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_PPCP_DescartarPartidasDeDistribucion]", listaParametros)

    End Function

    Public Sub consultaGenerarApartadosResumenClientes(ByVal FiltrosApartados As Entidades.FiltrosGeneracionApartadosPPCP)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Excluir_final"
        parametro.Value = FiltrosApartados.PFinal_o_Descartar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CantidadTallasExcluir_Final"
        parametro.Value = FiltrosApartados.PCantidadTallas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CantidadParesTallasExcluir_Final"
        parametro.Value = FiltrosApartados.PCantidadPares
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ConsultaGenerarDatosResumenCliente_PPCP", listaParametros)

    End Sub

    Public Function ActualizaPartidasYApartadosAntesDeConfirmacion(ByVal idApartado As Integer) As Integer
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "apartadoId"
        parametro.Value = idApartado
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarSentenciaSP("Ventas.SP_Apartados_Confirmacion_ActualizarDatosPartidasYApartadoEjecucion", listaParametros)

    End Function

    Public Function priorizarApartadosProspecta(ByVal ApartadosIds As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ApartadoId"
        parametro.Value = ApartadosIds
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ModificaPrioridadesApartadosProspecta", listaParametros)

    End Function

    Public Function verificarDistribucionApartadosPorConfirmar() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Return objPersistencia.EjecutaConsulta("EXEC Ventas.SP_Apartados_PPCP_VerificarDistribucionApartadosPorConfirmar")

    End Function

    Public Function validaApartadosPorCancelarEnOT(ByVal apartadosIds As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ApartadosPorCancelar"
        parametro.Value = apartadosIds
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ValidacionCancelarApartadosEnOT", listaParametros)

    End Function

    Public Function obtenerParesEntregadosPorApartado(ByVal apartadosIds As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Apartado"
        parametro.Value = apartadosIds
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ConsultarParesSalidaApartado", listaParametros)

    End Function

    Public Function obtenerParesEntregadosPorPartida(ByVal apartadosIds As String, ByVal partidasIds As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Apartado"
        parametro.Value = apartadosIds
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PartidaApartadoID"
        parametro.Value = partidasIds
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ConsultarParesSalidaPartida", listaParametros)

    End Function

    Public Function obtenerPartidaApartadoEnOrdenTrabajo(ByVal apartadosIds As String, ByVal partidasIds As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Apartado"
        parametro.Value = apartadosIds
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PartidaApartadoID"
        parametro.Value = partidasIds
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_ValidacionCancelarPartidasApartadosEnOT", listaParametros)

    End Function

    Public Function consultaPerfilUsuario(ByVal usuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@usuarioId"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Perfil_Usuario_Tablero", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function Replicacion_TmpdocenasPares() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Almacen.SP_Replicacion_TmpdocenasPares_A_UbicacionAtados", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function cancelarPartidasSICY(ByVal partidasCancelar As String, ByVal motivosCancelacion As String, ByVal observacionesCancelacion As String, ByVal usuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdApartadoDetalleCancelar"
        parametro.Value = partidasCancelar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdMotivosCancelacion"
        parametro.Value = motivosCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ObservacionesCancelaciones"
        parametro.Value = observacionesCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCancelo"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Apartados_CancelarPartida]", listaParametros)

    End Function

    Public Function cancelarApartado(ByVal ApartadoID As Integer, ByVal motivosCancelacion As Integer, ByVal observacionesCancelacion As String, ByVal usuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdApartado"
        parametro.Value = ApartadoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdMotivosCancelacion"
        parametro.Value = motivosCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ObservacionesCancelaciones"
        parametro.Value = observacionesCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCancelo"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_CancelarApartadosCompletos_v2", listaParametros)

    End Function

    Public Function cancelarApartadoSICY(ByVal ApartadoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdApartado"
        parametro.Value = ApartadoID
        listaParametros.Add(parametro)



        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_CancelarApartadosCompletos_v2]", listaParametros)

    End Function


    Public Function EnviarParesCanceladosApartadoAProgramar(ByVal ApartadoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdApartado"
        parametro.Value = ApartadoID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_Cancelacion_MandarProgramacionParesCanceladosCompletos]", listaParametros)

    End Function


    Public Function CancelarPartidaApartado(ByVal ApartadoID As Integer, ByVal Apartadodetalle As Integer, ByVal motivosCancelacion As Integer, ByVal observacionesCancelacion As String, ByVal usuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdApartado"
        parametro.Value = ApartadoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Apartadodetalleid"
        parametro.Value = Apartadodetalle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdMotivosCancelacion"
        parametro.Value = motivosCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ObservacionesCancelaciones"
        parametro.Value = observacionesCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCancelo"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Apartados_CancelarPartidasApartados_v2", listaParametros)

    End Function

    Public Function cancelarPartidaApartadoSICY(ByVal ApartadoID As Integer, ByVal ApartadoDetalleid As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdApartado"
        parametro.Value = ApartadoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdApartadoDetalle"
        parametro.Value = ApartadoDetalleid
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_CancelarPartidaApartados]", listaParametros)

    End Function

    Public Function EnviarParesCanceladosPartidaApartadoAProgramar(ByVal ApartadoID As Integer, ByVal ApartadoDetalleid As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdApartado"
        parametro.Value = ApartadoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdDetalleApartado"
        parametro.Value = ApartadoDetalleid
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_Cancelacion_MandarProgramacionParesCanceladosPartidas]", listaParametros)

    End Function

    Public Sub CalculoApartados(entidadApartado As Entidades.ApartadoPorGenerar_PPCP, Optional apartado As String = "")
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter) From
        {
            New SqlParameter With {
                .ParameterName = "@PEDIDO",
                .Value = entidadApartado.PPedidoId
            },
            New SqlParameter With {
                .ParameterName = "@DETALLE_PEDIDO",
                .Value = entidadApartado.PIdDetallePedidoSAY
            },
            New SqlParameter With {
                .ParameterName = "@PARES_APARTADOS",
                .Value = entidadApartado.PNapartados
            },
            New SqlParameter With {
                .ParameterName = "@APARTADO_ID",
                .Value = apartado
            }
        }
        objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ColocacionSemanal_CalculoApartados]", listaParametros)
    End Sub

End Class
