Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports Persistencia

Public Class ClientesAlmacenDA

    Public Function GenerarUbicacion() As Boolean
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim resultadoOK As Boolean = 0

        Try
            operaciones.EjecutarSentenciaSP("Almacen.SP_GeneraUbicacionesFaltantes", listaParametros)
            resultadoOK = 1
        Catch ex As Exception
            resultadoOK = 0
        End Try
        Return resultadoOK

    End Function

    Public Function ConvertirParesAtado() As Boolean
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim resultadoOK As Boolean = 0
        Try
            Return operaciones.EjecutarSentenciaSP("Almacen.SP_Convertir_Pares_En_Atado", listaParametros)
            resultadoOK = 1
        Catch ex As Exception
            resultadoOK = 0
        End Try
        Return resultadoOK
    End Function

    Public Function LimpiarPlataforma() As Boolean
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim resultadoOK As Boolean = 0
        Try
            Return operaciones.EjecutarSentenciaSP("Almacen.SP_limpiaPlataforma", listaParametros)
            resultadoOK = 1
        Catch ex As Exception
            resultadoOK = 0
        End Try
        Return resultadoOK
    End Function

    Public Function CargarClientes() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "select b.Nombre as Agente,a.IdCadena, a.nombre from Cadenas as a left JOIN Agentes as b on (a.IdAgente = b.IdAgente) where a.Activo= 'S' ORDER BY a.nombre "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function LocalizarProducto(Filtros As Entidades.LocalizacionProducto)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@NaveID",
            .Value = Filtros.NaveID
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Almacen",
            .Value = Filtros.Almacen
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FiltroFecha",
            .Value = Filtros.FiltroFecha
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FechaInicio",
            .Value = Filtros.FechaInicio
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FechaFin",
            .Value = Filtros.FechaFin
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@CodigosPar",
            .Value = Filtros.CodigosPar.ToString.Replace("'","")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@CodigosAtado",
            .Value = Filtros.CodigosAtado.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Lotes",
            .Value = Filtros.Lotes.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@AnioLotes",
            .Value = Filtros.AnioLotes.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@LotesCliente",
            .Value = Filtros.LotesCliente.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Naves",
            .Value = Filtros.Naves.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@PedidoOrigen",
            .Value = Filtros.PedidosOrigen.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@PedidoCliente",
            .Value = Filtros.PedidosCliente.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Clientes",
            .Value = Filtros.Clientes.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Tiendas",
            .Value = Filtros.Tiendas.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@AgentesVtas",
            .Value = Filtros.AgenteVtas.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@OrdenesCliente",
            .Value = Filtros.OrdenesCliente.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Apartados",
            .Value = Filtros.Apartados.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@DevolucionesSAY",
            .Value = Filtros.DevolucionesSAY.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Productos",
            .Value = Filtros.Productos.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Corridas",
            .Value = Filtros.Corridas.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Tallas",
            .Value = Filtros.Tallas.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Bahias",
            .Value = Filtros.Bahias.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@DescripiconBahia",
            .Value = Filtros.DescripcionBahia.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Operador",
            .Value = Filtros.Operador.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Estatus",
            .Value = Filtros.Estatus.ToString.Replace("'", "")
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FiltroFechaEntPedidos",
            .Value = Filtros.FiltroFechaEntPedidos
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FechaInicioPedido",
            .Value = Filtros.FechaInicioPedidos
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@FechaFinPedido",
            .Value = Filtros.FechaFinPedidos
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Ubicacion",
            .Value = Filtros.Ubicacion
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Condicion",
            .Value = Filtros.Condicion
        })

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_Logistica_LocalizarProductoEnAlmacen_v3]", listaParametros)
    End Function

    Public Function ListadoParametroUbicacion(tipo_busqueda As Integer, id_parametros As String) As DataTable

        Dim operaciones_sicy As New Persistencia.OperacionesProcedimientosSICY
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        If tipo_busqueda = 1 Then
            consulta += " SELECT IdCodigo AS 'Parámetro',  CAST(0 AS BIT) AS ' ', IdModelo AS 'Modelo',Descripcion AS 'Descripción', Color AS 'Color', Coleccion AS 'Colección', Marca AS 'Marca' FROM vEstilos ORDER BY Descripcion, IdModelo, Color "
        Else
            If tipo_busqueda = 2 Then
                consulta += " SELECT IdCadena AS 'Parámetro', CAST(0 AS BIT) AS ' ', IdCadena AS 'Cadena', nombre AS 'Nombre' FROM vCadenas  WHERE Activo = 'S' ORDER BY nombre "
            Else
                If tipo_busqueda = 3 Then
                    consulta += " SELECT IdTalla AS 'Parámetro', CAST(0 AS BIT) AS ' ' , IdTalla AS 'Talla ID', Talla AS 'Talla' FROM tallas ORDER BY Talla "
                Else
                    If tipo_busqueda = 4 Then
                        Dim id_parametros_split As String() = id_parametros.ToString.Split(",")
                        consulta += " SELECT " +
                            "   bahi_bahiaid  AS 'Parámetro' " +
                            " , CAST(0 AS bit) AS ' ' " +
                            " , LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía' " +
                            " , bahi_bloque AS 'Bloque' " +
                            " , bahi_nivel 'Nivel' " +
                            " , bahi_fila AS 'Fila' " +
                            " , bahi_segmento AS 'Segmento' " +
                            " , bahi_bahiaid AS 'Clave' " +
                            " FROM Almacen.Bahia" +
                            " WHERE bahi_activo = 1 AND bahi_nave IN (" + id_parametros_split(0) + ") AND bahi_almacen IN (" + id_parametros_split(1) + ")" +
                            " ORDER BY bahi_bloque, bahi_nivel, bahi_segmento, bahi_bahiaid "
                    Else
                        If tipo_busqueda = 5 Then
                            consulta += " SELECT IdNave AS 'Parámetro', CAST(0 AS BIT) AS ' ', Nave AS 'Nave' FROM Naves WHERE Activo = 1 ORDER BY Nave"
                        Else
                            If tipo_busqueda = 6 Then
                                consulta += " SELECT " +
                                    "   A.codr_colaboradorid AS 'Parámetro' " +
                                    " , CAST (0 AS bit) AS ' ' " +
                                    " , CAST(A.codr_nombre + ' ' + A.codr_apellidopaterno + ' ' + A.codr_apellidomaterno AS varchar(200)) AS 'Operador' " +
                                    " FROM [Nomina].[Colaborador] AS A " +
                                    " JOIN [Nomina].[ColaboradorLaboral] AS B ON B.labo_colaboradorid = A.codr_colaboradorid " +
                                    " JOIN [Framework].[Grupos] AS C ON C.grup_grupoid = B.labo_departamentoid " +
                                    " WHERE A.codr_activo = 1 AND C.grup_grupoid = 97 ORDER BY A.codr_nombre "
                            Else
                                If tipo_busqueda = 7 Then
                                    consulta += " SELECT IdAgente AS 'Parámetro', CAST(0 AS BIT) AS ' ', Nombre AS 'Nombre',Iniciales AS 'Iniciales' FROM Agentes WHERE Activo = 1 ORDER BY Nombre "
                                Else
                                    If tipo_busqueda = 8 Then
                                        Dim id_parametros_split As String() = id_parametros.ToString.Split(",")
                                        consulta += " SELECT DISTINCT CAST(0 AS integer) AS 'Parámetro', CAST(0 AS bit) AS ' ', bahi_descripcion AS 'Descripción de Bahía' " +
                                            " FROM Almacen.Bahia WHERE bahi_activo = 1 AND bahi_nave IN (" + id_parametros_split(0) + ") AND bahi_almacen IN (" + id_parametros_split(1) + ")" +
                                            " ORDER BY bahi_descripcion"
                                    Else
                                        If tipo_busqueda = 9 Then
                                            consulta += " SELECT IdDistribucion AS 'Parámetro', CAST(0 AS BIT) AS ' ', IdDistribucion AS 'ID', cadena AS 'Cliente', distribucion AS 'Tienda', ciudad AS 'Ciudad' " +
                                                    " FROM vCadenasDistribucion" +
                                                    " ORDER BY cliente, distribucion, Ciudad"
                                        Else
                                            If tipo_busqueda = 10 Then
                                                consulta += " SELECT calc_calce AS 'Parámetro', CAST(0 AS BIT) AS ' ', calc_calce AS 'Talla'" +
                                                     " FROM Programacion.Calce" +
                                                     " WHERE calc_activo = 1" +
                                                     " ORDER BY calc_calce"
                                            Else
                                                If tipo_busqueda = 11 Then
                                                    consulta += " select clie_clienteid as 'Parametro', CAST(0 AS BIT) as ' ',clie_nombregenerico as Nombre,clie_clasificacionclienteid as Clasificación,"
                                                    consulta += " clie_ranking as Ranking, CASE WHEN B.bloq_captura+B.bloq_programacion+B.bloq_entrega+b.bloq_contado > 0 THEN 'SI' ELSE 'NO' END AS Bloqueado"
                                                    consulta += "  from Cliente.Cliente C"
                                                    consulta += " LEFT JOIN Programacion.bloqueos B ON b.bloq_clienteid = c.clie_clienteid and B.bloq_semana = DATEPART(wk,GETDATE()) AND B.bloq_año = DATEPART(YEAR,GETDATE()) "
                                                    consulta += " where clie_activo=1 and clie_clienteid <> 1071 and clie_clienteid <> 1072  order by clie_nombregenerico "
                                                Else
                                                    If tipo_busqueda = 12 Then
                                                        '09/09/2017
                                                        consulta = "SELECT IdLinea,CAST(0 AS BIT) as ' ', Coleccion FROM vLineas WHERE Activo='S'"
                                                    Else
                                                        If tipo_busqueda = 13 Then
                                                            consulta = "SELECT IdCombinacion,CAST(0 AS BIT) as ' ', Piel + ' ' + Nombre Color FROM Pieles p, Colores c, ColoresPiel cp where p.idpiel=cp.idpiel and c.idcolor=cp.idcolor order by piel + ' ' + Nombre"
                                                        Else
                                                            If tipo_busqueda = 14 Then
                                                                consulta = "SELECT marc_codigosicy 'Parámetro', CAST(0 AS BIT) as ' ', marc_descripcion Marcas  FROM Programacion.Marcas WHERE marc_activo = 1 order by marc_descripcion"
                                                            Else
                                                                If tipo_busqueda = 15 Then
                                                                    consulta = "SELECT fapr_familiaproyeccionid 'Parámetro', CAST(0 AS BIT) as ' ', fapr_descripcion  as Familias  FROM Programacion.Familias_Proyeccion where fapr_activo = 1 and fapr_familiaproyeccionid <> 17 order by fapr_descripcion"
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

        If tipo_busqueda = 6 Or tipo_busqueda = 11 Or tipo_busqueda = 14 Or tipo_busqueda = 15 Then
            Return operaciones.EjecutaConsulta(consulta)
        Else
            Return operaciones_sicy.EjecutaConsulta(consulta)
        End If


    End Function

    Public Function ListadoUbicacionAtado(mostrar_todo As Boolean, consultaPar As String, consultaErrores As String, consultaAtado As String, _
                                          consultaContenidoAtado As String, buscarContenidoAtado As Boolean) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty

        If mostrar_todo Then
            If mostrar_todo And buscarContenidoAtado Then
                consulta += consultaPar + " UNION " + consultaErrores + " UNION " + consultaContenidoAtado
            Else
                consulta += consultaPar + " UNION " + consultaErrores + " UNION " + consultaAtado
            End If
        Else
            If Not String.IsNullOrEmpty(consultaContenidoAtado) Then
                If Not String.IsNullOrEmpty(consultaPar) And Not String.IsNullOrEmpty(consultaContenidoAtado) Then
                    consulta += consultaPar + " UNION " + consultaErrores + " UNION " + consultaContenidoAtado
                Else
                    If Not String.IsNullOrEmpty(consultaPar) And String.IsNullOrEmpty(consultaContenidoAtado) Then
                        consulta += consultaPar + " UNION " + consultaErrores
                    Else
                        If String.IsNullOrEmpty(consultaPar) And Not String.IsNullOrEmpty(consultaContenidoAtado) Then
                            consulta += consultaContenidoAtado
                        End If
                    End If
                End If
            Else
                If Not String.IsNullOrEmpty(consultaPar) And Not String.IsNullOrEmpty(consultaAtado) Then
                    consulta += consultaPar + " UNION " + consultaErrores + " UNION " + consultaAtado
                Else
                    If Not String.IsNullOrEmpty(consultaPar) And String.IsNullOrEmpty(consultaAtado) Then
                        consulta += consultaPar + " UNION " + consultaErrores
                    Else
                        If String.IsNullOrEmpty(consultaPar) And Not String.IsNullOrEmpty(consultaAtado) Then
                            consulta += consultaAtado
                        End If
                    End If
                End If
            End If

        End If

        consulta += " ORDER BY 'Fecha Ubicación(hr)' DESC"
        Dim dtDatosRetornados As New DataTable
        Try
            dtDatosRetornados = operaciones.EjecutaConsultaSinThrow(consulta)
        Catch ex As Exception
            If ex.Message.ToUpper.Contains("INTERBLOQUEO") Or ex.Message.ToUpper.Contains("DEADLOCK") Then
                dtDatosRetornados.Columns.Add("Mensaje")
                Dim rowDtRetornado As DataRow
                rowDtRetornado = dtDatosRetornados.NewRow
                rowDtRetornado.Item(0) = "Error de interbloqueo, vuelva a intentar mas tarde."
                dtDatosRetornados.Rows.Add(rowDtRetornado)
            Else
                Throw ex
            End If
        End Try
        Return dtDatosRetornados
    End Function

    Public Sub AltaBahiaCliente(ByVal bahiacliente As Entidades.Bahia)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaValores As New List(Of SqlParameter)


        Dim valores As New SqlParameter
        valores.ParameterName = "bacl_bahiaid"
        valores.Value = bahiacliente.bahiaid
        listaValores.Add(valores)

        Try
            valores = New SqlParameter
            valores.ParameterName = "bacl_idcadena"
            valores.Value = bahiacliente.Cliente.Cadena
            listaValores.Add(valores)
        Catch ex As Exception

        End Try

        valores = New SqlParameter
        valores.ParameterName = "bacl_usuariocreoid"
        valores.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "bacl_fechacreacion"
        valores.Value = Today.Date.ToShortDateString
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "bacl_activo"
        valores.Value = bahiacliente.Cliente.PActivo
        listaValores.Add(valores)

        operaciones.EjecutarSentenciaSP("Almacen.SP_AltaClienteAlmacen", listaValores)

    End Sub


    Public Function CargarClientesBahia(ByVal Bahiaid As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta = "select * from Almacen.BahiaClientes as a join Almacen.Bahia as b " +
            "on a.bacl_bahiaid like '%'+b.bahi_bahiaid+'%' where a.bacl_bahiaid like '" + Bahiaid + "%'"

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListadoCarritos(estatus As Integer, naveID As Integer, almacenID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty

        consulta += " SELECT CAST(0 AS BIT) AS ' ' ,carr_carritoid AS 'Párametro', carr_descripcion AS 'Plataforma', tica_tipocarritoid, tica_descripcion AS 'Tipo Plataforma' FROM Almacen.Carrito " +
            " JOIN Almacen.TipoCarrito ON carr_tipocarritoid = tica_tipocarritoid" +
            " WHERE carr_nave = " + naveID.ToString + "AND carr_almacen = " + almacenID.ToString + "AND carr_activo = " + estatus.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListaTiposCarritos() As DataTable
        Dim opereciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT tica_tipocarritoid, tica_descripcion FROM Almacen.TipoCarrito WHERE tica_activo = 1 ORDER BY tica_descripcion"

        Return opereciones.EjecutaConsulta(consulta)
    End Function

    Public Sub Alta_Editar_Carrito(ByVal carrito As Entidades.Carrito)

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        ',@carritoid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "carritoid"
        parametro.Value = carrito.carritoid
        listaParametros.Add(parametro)

        ',@descripcion AS VARCHAR(30)
        parametro = New SqlParameter
        parametro.ParameterName = "descripcion"
        parametro.Value = carrito.descripcion
        listaParametros.Add(parametro)

        ',@naveid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "naveid"
        parametro.Value = carrito.nave.PNaveId
        listaParametros.Add(parametro)

        ',@almacenid	AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "almacenid"
        parametro.Value = carrito.almacen.almacenid
        listaParametros.Add(parametro)

        ',@tipocarritoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "tipocarritoid"
        parametro.Value = carrito.tipocarrito.tipocarritoid
        listaParametros.Add(parametro)

        ',@estatus AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "estatus"
        parametro.Value = carrito.activo
        listaParametros.Add(parametro)

        ',@usuarioid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)
        operaciones.EjecutarSentenciaSP("Almacen.SP_Alta_Edicion_Carritos", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    Public Function Almacen_ReporteProductividadPlataforma(fecha_inicio As Date, fecha_termino As Date, list_colaboradorID As String, ByVal CEDISID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY

        Dim listaParametros As New List(Of SqlParameter)

        ',@fecha_inicio AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@fecha_inicio"
        parametro.Value = fecha_inicio.ToShortDateString
        listaParametros.Add(parametro)

        ',@fecha_termino AS VARCHAR(30)
        parametro = New SqlParameter
        parametro.ParameterName = "@fecha_termino"
        parametro.Value = fecha_termino.ToShortDateString
        listaParametros.Add(parametro)

        ',@list_colaboradorID AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@list_colaboradorID"
        parametro.Value = list_colaboradorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ComercializadoraID"
        parametro.Value = CEDISID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Almacen.SP_Reportes_ConsultaUbicacionPorPlataformav3", listaParametros)

        'Dim consulta As String = sentencia
        'Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function Almacen_ReporteHistoricoUbicaciones(ByVal TipoBusquedaPar As Boolean, ListaCodigos As String, CEDISID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "@TipoBusquedaPar"
        parametro.Value = TipoBusquedaPar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ListaCodigos"
        parametro.Value = ListaCodigos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CEDISID"
        parametro.Value = CEDISID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_Reportes_HistoricoUbicaciones]", listaParametros)

    End Function

    Public Function Almacen_ReporteInventarioInicial(sentencia As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = sentencia
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function Obtener_Datetime_Servidor() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT GETDATE()"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function Pares_en_SICY(nave As String, almacen As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveId"
            parametro.Value = nave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AlmacenId"
            parametro.Value = almacen
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_LocalizacionProducto_ObtenerParesSICY]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try


        'Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        'Dim consulta As String = "SELECT COUNT(*) FROM tmpDocenasPares WHERE Status = 1 AND (embarque=0 or embarque IS NULL) AND (salida=0 or salida is NULL)"
        'Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function Pares_en_SAY(nave As String, almacen As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveId"
            parametro.Value = nave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AlmacenId"
            parametro.Value = almacen
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_LocalizacionProducto_ObtenerParesSAY]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try


        'Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        ''Dim consulta As String = " " +
        ''                        " SELECT " +
        ''                        " 	(" +
        ''                        " 		SELECT COUNT(*) FROM Almacen.UbicacionPares " +
        ''                        "       WHERE ubpa_activo = 1" +
        ''                        " 	)" +
        ''                        " 	+" +
        ''                        " 	(" +
        ''                        " 		SELECT SUM(ubat_pares) FROM Almacen.UbicacionAtados" +
        ''                        "       WHERE ubat_activo = 1" +
        ''                        " 	)"

        'Return operaciones.EjecutaConsulta(consulta)


    End Function

    Public Function ValidarPlataformas()
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Return operaciones.EjecutarSentenciaSP("Almacen.SP_ValidarPlataformas", listaParametros)
    End Function
    Public Sub actualizarContenidoAtadosUbicacionPares()
        Dim operaciones As New OperacionesProcedimientosSICY
        operaciones.EjecutaConsulta("EXEC Almacen.validarUbicacionParesContenidoAtados")
        operaciones.EjecutaConsulta("EXEC Almacen.actualizarIdOTCoppelUbicacionParesContenidoAtados")
    End Sub

    Public Function Almacen_ReporteOTCoppelAvancePedido(fecha_inicio As DateTime, fecha_termino As DateTime, list_colaboradorID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta += "SELECT ot.otco_idpedido,min(otco_fechaentrega) as FechaEntrega, count(ot.otco_idotcoppel) as OTs, sum(otco_totalpares) as Pares, count(otc.otco_idotcoppel) as OTs_Confirmadas, sum(ot.otco_paresconfirmados) as Pares_Confirmados, 0.00 AS Porcentaje_pedido, 0.00 AS Porcentaje_global from Almacen.OTCoppel ot left join (select otco_idpedido, otco_idotcoppel from Almacen.OTCoppel where (otco_estatus = 'C' or otco_estatus = 'E')"
        consulta += ") otc on ot.otco_idpedido = otc.otco_idpedido and ot.otco_idotcoppel = otc.otco_idotcoppel WHERE convert(date,ot.otco_fechaentrega) "
        consulta += " >= '" + fecha_inicio + "' AND convert(date,ot.otco_fechaentrega) <= '" + fecha_termino + "'"


        'PARA AGREGAR FILTRO DE COLABORADOR AGREGAR: LEFT JOIN [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].Framework.Usuarios c on c.user_usuarioid = ot.otco_colaboradorconfirmoid 
        'If Not String.IsNullOrEmpty(list_colaboradorID) Then
        '    consulta += " AND c.user_colaboradorid in (" + list_colaboradorID + ")"
        'End If

        consulta += "  group by ot.otco_idpedido "

        consulta += " union " + Replace(consulta, "Almacen.OTCoppel ", "Almacen.OTCoppel_Hist ")

        consulta += " order by MIN(otco_fechaentrega) asc"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Almacen_ReporteOTCoppelIncidenciasPedido(fecha_inicio As DateTime, fecha_termino As DateTime) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        Dim consultaHistorico As String = String.Empty
        'consulta += "select ot.otco_idpedido,min(ot.otco_fechaentrega) as FechaEntrega,count(ot.otco_idotcoppel) as OTs,sum(ot.otco_totalpares) as Pares,(sum(isnull(i.Pares_leidos,0)) + SUM(otd.paresConfirmados)) as paresLeidos, SUM(otd.paresConfirmados) as Confirmados, SUM(isnull(i.incidencias,0)) as Incidencias, sum(isnull(i.Pares_equivocados,0)) As paresEquivocados, 0.00 AS porc_vsParesLeidos, 0.00 AS porc_vsParesConfirmados, 0.00 AS Porcentaje_globalLeidos, 0.00 AS Porcentaje_globalConfirmados"
        consulta += "select ot.otco_idpedido,min(ot.otco_fechaentrega) as FechaEntrega,count(ot.otco_idotcoppel) as OTs,sum(ot.otco_totalpares) as Pares,(sum(isnull(i.Pares_leidos,0)) + SUM(otd.paresConfirmados)) as paresLeidos, SUM(otd.paresConfirmados) as Confirmados, sum(isnull(i.Pares_equivocados,0)) As paresEquivocados, 0.00 AS porc_vsParesLeidos, 0.00 AS porc_vsParesConfirmados, 0.00 AS Porcentaje_globalLeidos, 0.00 AS Porcentaje_globalConfirmados"
        consulta += " from Almacen.OTCoppel ot INNER JOIN (SELECT otcod_idotCoppel, sum(otcod_paresConfirmados) as paresConfirmados from Almacen.OtCoppelDetalles group by otcod_idotCoppel) as otd on ot.otco_idotcoppel = otd.otcod_idotCoppel"
        consulta += " LEFT JOIN (SELECT ocin_idotcoppel, count(isnull(ocin_otcoppelincidenciaid,0)) AS incidencias, SUM(isnull(ocin_paresleidos,0)) as Pares_leidos, SUM(isnull(ocin_paresincorrectos,0)) as Pares_equivocados FROM Almacen.OTCoppel_Incidencias group by ocin_idotcoppel) as i on ot.otco_idotcoppel = i.ocin_idotcoppel where convert(date,ot.otco_fechaentrega)"
        consulta += " >= '" + fecha_inicio + "' AND convert(date,ot.otco_fechaentrega) <= '" + fecha_termino + "'"
        consulta += "  group by ot.otco_idpedido "

        consultaHistorico += Replace(consulta, "Almacen.OTCoppel ", "Almacen.OTCoppel_Hist ")
        consultaHistorico += Replace(consultaHistorico, "Almacen.OtCoppelDetalles ", "Almacen.OtCoppelDetalles_Hist ")

        consulta += " union " + consultaHistorico
        consulta += " order by MIN(otco_fechaentrega) asc"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Almacen_ReporteOTCoppelIncidenciasUsuario(fecha_inicio As DateTime, fecha_termino As DateTime, list_colaboradorID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += "SELECT pares_confirmados.user_nombrereal, pares_confirmados.Total_ots, (pares_confirmados.confirmados + isnull(pares_incidencias.pares_leidos,0)) as leidos, pares_confirmados.confirmados AS Confirmados, isnull(pares_incidencias.pares_incorrectos,0) AS incorrectos, 0.00 AS porcentajeVsLeidos, 0.00 AS porcentajeVsConfirmados, 0.00 AS porcentajeGlobalVsLeidos, 0.00 AS porcentajeGlobalVsConfirmados FROM (SELECT c.user_nombrereal, count(distinct(ot.otco_idotcoppel)) as Total_ots, sum(ot.otco_paresconfirmados) as confirmados FROM Almacen.OTCoppel ot INNER JOIN [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].Framework.Usuarios c on c.user_usuarioid = ot.otco_colaboradorconfirmoid where convert(date,ot.otco_fechaConfirmacion) "
        consulta += " >= '" + fecha_inicio + "' AND convert(date,ot.otco_fechaConfirmacion) <= '" + fecha_termino + "'"

        If Not String.IsNullOrEmpty(list_colaboradorID) Then
            consulta += " AND c.user_colaboradorid in (" + list_colaboradorID + ")"
        End If
        consulta += " group by c.user_nombrereal) as pares_confirmados INNER JOIN "
        consulta += " (SELECT c.user_nombrereal, Sum(isnull(oti.ocin_paresleidos,0)) as pares_leidos, sum(isnull(oti.ocin_paresincorrectos,0)) as pares_incorrectos FROM Almacen.OTCoppel_Incidencias oti LEFT JOIN [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].Framework.Usuarios c on c.user_usuarioid = oti.ocin_colaboradorid where convert(date,oti.ocin_fechaincidencia)  >= '" + fecha_inicio + "' "
        consulta += "AND convert(date,oti.ocin_fechaincidencia)  <= '" + fecha_termino + "' group by c.user_nombrereal) as pares_incidencias ON pares_confirmados.user_nombrereal = pares_incidencias.user_nombrereal"

        consulta += " union " + Replace(consulta, "Almacen.OTCoppel ", "Almacen.OTCoppel_Hist ")

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Almacen_ReporteOTCoppelIncidenciasUsuarioFecha(fecha_inicio As DateTime, fecha_termino As DateTime, list_colaboradorID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " DECLARE @usuarios as varchar(max)"
        consulta += " DECLARE @cadenaPivote  as varchar(max)"
        consulta += " SELECT	"
        consulta += "	@usuarios = COALESCE(@usuarios + '], [', '[') + usuarios.usuario"
        consulta += " FROM (SELECT DISTINCT"
        consulta += " (c.user_username) usuario"
        consulta += " FROM Almacen.OTCoppel ot"
        consulta += " LEFT JOIN [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].Framework.Usuarios c"
        consulta += " ON c.user_usuarioid = ot.otco_colaboradorconfirmoid where convert(date,ot.otco_fechaconfirmacion)"
        consulta += " >= '" + fecha_inicio + "' AND convert(date,ot.otco_fechaconfirmacion) <= '" + fecha_termino + "'"

        If Not String.IsNullOrEmpty(list_colaboradorID) Then
            consulta += " AND c.user_colaboradorid in (" + list_colaboradorID + ")"
        End If
        consulta += " ) usuarios"
        consulta += "  WHERE usuarios.usuario Is Not NULL"
        consulta += " ORDER BY usuario"

        consulta += " SET @usuarios = @usuarios + ']'"

        consulta += " SET @cadenaPivote = 'select *, 0 AS Total from (select c.user_username usuario,  convert(date,oti.ocin_fechaincidencia) fecha ,"
        consulta += " sum(isnull(oti.ocin_paresincorrectos,0)) pares_incorrectos from Almacen.OTCoppel_Incidencias oti LEFT JOIN"
        consulta += " [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].Framework.Usuarios c on c.user_usuarioid = oti.ocin_colaboradorid where 	"
        consulta += " c.user_username is not null "
        If Not String.IsNullOrEmpty(list_colaboradorID) Then
            consulta += " AND c.user_colaboradorid in (" + list_colaboradorID + ")"
        End If
        consulta += " AND convert(date,oti.ocin_fechaincidencia) "
        consulta += " >= ''" + fecha_inicio + "'' AND convert(date,oti.ocin_fechaincidencia) <= ''" + fecha_termino + "''"
        consulta += " group by c.user_username, convert(date,oti.ocin_fechaincidencia))	"
        consulta += "  AS CONS PIVOT (SUM(pares_incorrectos) FOR usuario IN (' + @usuarios + ')) AS pvotCLISUM'	"

        consulta += " EXEC (@cadenaPivote)	"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Almacen_ReporteOTCoppelOTConfirmadasUsuarioFecha(fecha_inicio As DateTime, fecha_termino As DateTime, list_colaboradorID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " DECLARE @usuarios as varchar(max)"
        consulta += " DECLARE @cadenaPivote  as varchar(max)"
        consulta += " SELECT	"
        consulta += "	@usuarios = COALESCE(@usuarios + '], [', '[') + usuarios.usuario"
        consulta += " FROM (SELECT DISTINCT"
        consulta += " (c.user_username) usuario"
        consulta += " FROM Almacen.OTCoppel ot"
        consulta += " LEFT JOIN [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].Framework.Usuarios c"
        consulta += " ON c.user_usuarioid = ot.otco_colaboradorconfirmoid where convert(date,ot.otco_fechaconfirmacion) "
        consulta += " >= '" + fecha_inicio + "' AND convert(date,ot.otco_fechaconfirmacion) <= '" + fecha_termino + "' "

        If Not String.IsNullOrEmpty(list_colaboradorID) Then
            consulta += " AND c.user_colaboradorid in (" + list_colaboradorID + ")"
        End If
        consulta += " ) usuarios"
        consulta += "  WHERE usuarios.usuario Is Not NULL"
        consulta += " ORDER BY usuario"

        consulta += " SET @usuarios = @usuarios + ']'"

        consulta += "SET @cadenaPivote = 'select *, 0 AS Total from (select c.user_username usuario,  convert(date,ot.otco_fechaconfirmacion) fecha, 	"
        consulta += " count(ot.otco_idotcoppel) ot_confirmadas from Almacen.OTCoppel ot LEFT JOIN 	"
        consulta += " [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].Framework.Usuarios c on c.user_usuarioid = ot.otco_colaboradorconfirmoid where 	"
        consulta += " c.user_username is not null"
        If Not String.IsNullOrEmpty(list_colaboradorID) Then
            consulta += " AND c.user_colaboradorid in (" + list_colaboradorID + ")"
        End If
        consulta += " AND convert(date,ot.otco_fechaconfirmacion)"
        consulta += " >= ''" + fecha_inicio + "'' AND convert(date,ot.otco_fechaconfirmacion) <= ''" + fecha_termino + "'' "
        consulta += " group by c.user_username, convert(date,ot.otco_fechaconfirmacion))	"
        consulta += " AS CONS PIVOT (SUM(ot_confirmadas) FOR usuario IN (' + @usuarios + ')) AS pvotCLISUM'"

        consulta += "  set @cadenaPivote += ' union ' + REPLACE(@cadenaPivote,'Almacen.OTCoppel ','Almacen.OTCoppel_Hist ') "

        consulta += " EXEC (@cadenaPivote)	"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Almacen_ReporteOTCoppelParesUsuarioFecha(fecha_inicio As DateTime, fecha_termino As DateTime, list_colaboradorID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " DECLARE @usuarios as varchar(max)"
        consulta += " DECLARE @cadenaPivote  as varchar(max)"
        consulta += " SELECT	"
        consulta += "	@usuarios = COALESCE(@usuarios + '], [', '[') + usuarios.usuario"
        consulta += " FROM (SELECT DISTINCT"
        consulta += " (c.user_username) usuario"
        consulta += " FROM Almacen.OTCoppel ot"
        consulta += " LEFT JOIN [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].Framework.Usuarios c"
        consulta += " ON c.user_usuarioid = ot.otco_colaboradorconfirmoid where convert(date,ot.otco_fechaconfirmacion) "
        consulta += " >= '" + fecha_inicio + "' AND convert(date,ot.otco_fechaconfirmacion) <= '" + fecha_termino + "'"

        If Not String.IsNullOrEmpty(list_colaboradorID) Then
            consulta += " AND c.user_colaboradorid in (" + list_colaboradorID + ")"
        End If
        consulta += " ) usuarios"
        consulta += "  WHERE usuarios.usuario Is Not NULL"
        consulta += " ORDER BY usuario"

        consulta += " SET @usuarios = @usuarios + ']'"

        consulta += "SET @cadenaPivote = 'select *, 0 AS Total from (select c.user_username usuario,  convert(date,ot.otco_fechaconfirmacion) fecha, 	"
        consulta += " SUM(ot.otco_paresconfirmados) pares_confirmados from Almacen.OTCoppel ot LEFT JOIN 	"
        consulta += " [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].Framework.Usuarios c on c.user_usuarioid = ot.otco_colaboradorconfirmoid where 	"
        consulta += " c.user_username is not null"
        If Not String.IsNullOrEmpty(list_colaboradorID) Then
            consulta += " AND c.user_colaboradorid in (" + list_colaboradorID + ")"
        End If
        consulta += " AND convert(date,ot.otco_fechaconfirmacion) "
        consulta += " >= ''" + fecha_inicio + "'' AND convert(date,ot.otco_fechaconfirmacion) <= ''" + fecha_termino + "'' "

        consulta += " group by c.user_username, convert(date,ot.otco_fechaconfirmacion))	"
        consulta += " AS CONS PIVOT (SUM(pares_confirmados) FOR usuario IN (' + @usuarios + ')) AS pvotCLISUM'"

        consulta += " set @cadenaPivote += ' UNION ' + REPLACE(@cadenaPivote,'Almacen.OTCoppel ','Almacen.OTCoppel_Hist ') "

        consulta += " EXEC (@cadenaPivote)	"

        Return operaciones.EjecutaConsulta(consulta)

    End Function



    Public Function Almacen_ActualizaStock() As Boolean
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        Dim resultado As Boolean = False

        consulta = "exec Almacen.SP_IdentificarAtadosCompletos_Stock"
        Try
            operaciones.EjecutaConsulta(consulta)
            resultado = True
        Catch ex As Exception
            resultado = False
        End Try
        Return resultado
    End Function

    Public Function localizarProductoEnAlmacenPorAgrupamiento(ByVal nave As String, ByVal almacen As String, ByVal Con_Sin_Ubicacion As Int16, ByVal tipo_Agrupacion As Int16, ByVal bY_O As String, _
                                                              ByVal cadPares As String, ByVal cadLotes As String, ByVal cadAtados As String, ByVal cadAniosLotes As String, ByVal cadLotesCliente As String, ByVal cadNaves As String, ByVal cadPedidosOrigen As String, ByVal cadPedidos As String, _
                                                              ByVal cadClientes As String, ByVal cadTiendas As String, ByVal cadAgentes As String, ByVal cadOrdenesCliente As String, ByVal cadApartados As String, _
                                                              ByVal cadProductos As String, ByVal cadCorridas As String, ByVal cadTallas As String, ByVal cadBahias As String, ByVal cadDescripcionesBahia As String, ByVal cadColaboradores As String, _
                                                              ByVal cadEstatus As String, ByVal filtroFechas As Boolean, ByVal fechaInicio As String, ByVal fechaTermino As String, _
                                                              ByVal filtroFechasEntregaP As Boolean, ByVal fechaInicioEntregaP As String, ByVal fechaTerminoEntregaP As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultado As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "nave"
            parametro.Value = nave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "almacen"
            parametro.Value = almacen
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "Con_Sin_Ubicacion"
            parametro.Value = Con_Sin_Ubicacion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "Tipo_Agrupacion"
            parametro.Value = tipo_Agrupacion
            listaParametros.Add(parametro)

            If bY_O.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "bY_O"
                parametro.Value = bY_O
                listaParametros.Add(parametro)
            End If

            If cadPares.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadPares"
                parametro.Value = cadPares
                listaParametros.Add(parametro)
            End If

            If cadAtados.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadAtados"
                parametro.Value = cadAtados
                listaParametros.Add(parametro)
            End If

            If cadLotes.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadLotes"
                parametro.Value = cadLotes
                listaParametros.Add(parametro)
            End If

            If cadAniosLotes.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadAniosLotes"
                parametro.Value = cadAniosLotes
                listaParametros.Add(parametro)
            End If

            If cadLotesCliente.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadLotesCliente"
                parametro.Value = cadLotesCliente
                listaParametros.Add(parametro)
            End If

            If cadNaves.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadNaves"
                parametro.Value = cadNaves
                listaParametros.Add(parametro)
            End If

            If cadPedidosOrigen.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadPedidosOrigen"
                parametro.Value = cadPedidosOrigen
                listaParametros.Add(parametro)
            End If

            If cadPedidos.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadPedidos"
                parametro.Value = cadPedidos
                listaParametros.Add(parametro)
            End If

            If cadClientes.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadClientes"
                parametro.Value = cadClientes
                listaParametros.Add(parametro)
            End If

            If cadTiendas.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadTiendas"
                parametro.Value = cadTiendas
                listaParametros.Add(parametro)
            End If

            If cadAgentes.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadAgentes"
                parametro.Value = cadAgentes
                listaParametros.Add(parametro)
            End If

            If cadOrdenesCliente.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadOrdenesCliente"
                parametro.Value = cadOrdenesCliente
                listaParametros.Add(parametro)
            End If

            If cadApartados.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadApartados"
                parametro.Value = cadApartados
                listaParametros.Add(parametro)
            End If

            If cadProductos.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadProductos"
                parametro.Value = cadProductos
                listaParametros.Add(parametro)
            End If

            If cadCorridas.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadCorridas"
                parametro.Value = cadCorridas
                listaParametros.Add(parametro)
            End If

            If cadTallas.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadTallas"
                parametro.Value = cadTallas
                listaParametros.Add(parametro)
            End If

            If cadBahias.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadBahias"
                parametro.Value = cadBahias
                listaParametros.Add(parametro)
            End If

            If cadDescripcionesBahia.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadDescripcionesBahia"
                parametro.Value = cadDescripcionesBahia
                listaParametros.Add(parametro)
            End If

            If cadColaboradores.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadColaboradores"
                parametro.Value = cadColaboradores
                listaParametros.Add(parametro)
            End If

            If cadEstatus.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "cadEstatus"
                parametro.Value = cadEstatus
                listaParametros.Add(parametro)
            End If

            parametro = New SqlParameter
            parametro.ParameterName = "filtroFechas"
            parametro.Value = filtroFechas
            listaParametros.Add(parametro)

            If fechaInicio.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "fechaInicio"
                parametro.Value = fechaInicio
                listaParametros.Add(parametro)
            End If

            If fechaTermino.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "fechaTermino"
                parametro.Value = fechaTermino
                listaParametros.Add(parametro)
            End If

            parametro = New SqlParameter
            parametro.ParameterName = "filtroFechasEntregaP"
            parametro.Value = filtroFechasEntregaP
            listaParametros.Add(parametro)

            If fechaInicioEntregaP.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "fechaInicioEntregaP"
                parametro.Value = fechaInicioEntregaP
                listaParametros.Add(parametro)
            End If

            If fechaTerminoEntregaP.Trim <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "fechaTerminoEntregaP"
                parametro.Value = fechaTerminoEntregaP
                listaParametros.Add(parametro)
            End If

            dtResultado = operaciones.EjecutarConsultaSP("Almacen.SP_LocalizarProductoEnAlmacenPorAgrupamiento_v2", listaParametros)
        Catch ex As Exception
            If ex.Message.ToUpper.Contains("INTERBLOQUEO") Or ex.Message.ToUpper.Contains("DEADLOCK") Then
                dtResultado.Columns.Add("Mensaje")
                Dim rowDtRetornado As DataRow
                rowDtRetornado = dtResultado.NewRow
                rowDtRetornado.Item(0) = "Error de interbloqueo, vuelva a intentar mas tarde."
                dtResultado.Rows.Add(rowDtRetornado)
            Else
                Throw ex
            End If
        End Try

        Return dtResultado
    End Function

#Region "Reportes Apartados"
    Public Function comboReporteApartadosSegunUsuario(ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_RepApartados_ReportesSegunUsuario", listaParametros)
    End Function

    Public Function reporteAvancePorFechaPreparacion(ByVal filtroClientes As String, filtroPedidos As String, ByVal filtroApartados As String,
                                                   ByVal fechaInicio As String, ByVal fechaFin As String, ByVal CEDISId As Integer) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "filtroClientes"
        parametro.Value = filtroClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "filtroPedidos"
        parametro.Value = filtroPedidos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "filtroApartados"
        parametro.Value = filtroApartados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CEDISId"
        parametro.Value = CEDISId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_RepApartados_ReporteAvance_FechaPreparacion_v2", listaParametros)
    End Function

    Public Function reporteApartadoPorEstatus(ByVal filtroClientes As String, ByVal filtroPedidos As String, ByVal filtroApartados As String,
                                              ByVal fechaInicio As String, ByVal fechaFin As String, ByVal CEDISID As Integer) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "filtroClientes"
        parametro.Value = filtroClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "filtroPedidos"
        parametro.Value = filtroPedidos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "filtroApartados"
        parametro.Value = filtroApartados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CEDISId"
        parametro.Value = CEDISID
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_RepApartados_ReporteApartados_PorEstatus_v2", listaParametros)
    End Function

    Public Function reportePares_ConfirmadoPorFechaUsuario(ByVal filtroClientes As String, ByVal filtroPedidos As String, ByVal filtroApartados As String,
                                                               ByVal filtroOperador As String, ByVal fechaInicio As String, ByVal fechaFin As String, ByVal CEDISID As Integer) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "filtroClientes"
        parametro.Value = filtroClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "filtroPedidos"
        parametro.Value = filtroPedidos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "filtroApartados"
        parametro.Value = filtroApartados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "filtroOperador"
        parametro.Value = filtroOperador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CEDISID"
        parametro.Value = CEDISID
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_RepApartados_ReporteParesConfirmados_UsuarioFecha_v2", listaParametros)
    End Function

    Public Function reporteApartados_ConfirmadoPorFechaUsuario(ByVal filtroClientes As String, ByVal filtroPedidos As String, ByVal filtroApartados As String,
                                                              ByVal filtroOperador As String, ByVal fechaInicio As String, ByVal fechaFin As String, ByVal CEDISID As Integer) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "filtroClientes"
        parametro.Value = filtroClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "filtroPedidos"
        parametro.Value = filtroPedidos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "filtroApartados"
        parametro.Value = filtroApartados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "filtroOperador"
        parametro.Value = filtroOperador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CEDISID"
        parametro.Value = CEDISID
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_RepApartados_ReporteApartadosConfirmados_UsuarioFecha_v2", listaParametros)
    End Function
#End Region

    Public Function ReporteInventario(ByVal fechaDesde As String, ByVal fechaHasta As String, ByVal ComercializadoraId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultado As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@fechaHastaP"
            parametro.Value = Convert.ToDateTime(fechaHasta)
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaDesdeP"
            parametro.Value = Convert.ToDateTime(fechaDesde)
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ComercializadoraId"
            parametro.Value = ComercializadoraId
            listaParametros.Add(parametro)

            dtResultado = operaciones.EjecutarConsultaSP("Almacen.SP_Reporte_Inventario_v2", listaParametros)
        Catch ex As Exception
            If ex.Message.ToUpper.Contains("INTERBLOQUEO") Or ex.Message.ToUpper.Contains("DEADLOCK") Then
                dtResultado.Columns.Add("Mensaje")
                Dim rowDtRetornado As DataRow
                rowDtRetornado = dtResultado.NewRow
                rowDtRetornado.Item(0) = "Error de interbloqueo, vuelva a intentar mas tarde."
                dtResultado.Rows.Add(rowDtRetornado)
            Else
                Throw ex
            End If
        End Try
        Return dtResultado
    End Function
End Class
