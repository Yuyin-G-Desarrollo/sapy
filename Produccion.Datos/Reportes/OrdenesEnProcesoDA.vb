Imports System.Data.SqlClient
Imports Entidades

Public Class OrdenesEnProcesoDA
    'hola
    Public Function ObtieneHormas() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = "SELECT CAST(0 AS BIT) as 'seleccion',IdAlmacen 'Id Almacen', Almacen FROM aptAlmacenes order by Almacen"
        Dim consulta As String = "SELECT CAST(0 AS BIT) as 'seleccion',horma_hormaid 'Id Horma', horma_descripcion Horma FROM Programacion.Hormas order by horma_descripcion"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ObtieneTemporadas() As DataTable
        'Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        'Dim consulta As String = " SELECT CAST(0 AS BIT) as 'seleccion',IdAgente 'Id Agente', Nombre FROM Agentes where Activo = 1 and ActivoCobranza = 1 order by Nombre"
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT CAST(0 AS BIT) as 'seleccion',temp_temporadaid 'Id Temporada',temp_nombre Nombre FROM Programacion.Temporadas  where temp_activo = 1  order by temp_nombre"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ObtieneCorridas() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT distinct CAST(0 AS BIT) as 'seleccion',t.IdTalla as IdTalla, TallaI, TallaF FROM Tallas t order by t.TallaI"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ObtieneSuelasProveedor() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT CAST(0 AS BIT) AS 'seleccion', p.prov_proveedorid AS 'IdProveedor', p.prov_razonsocial AS 'Nombre proveedor' FROM Materiales.Materiales m"
        consulta += " INNER JOIN Produccion.ConsumosDesarrollo cd ON m.mate_materialid = cd.code_materialid"
        consulta += " INNER JOIN Proveedor.Proveedor p ON cd.code_proveedorid = p.prov_proveedorid"
        consulta += " WHERE cd.code_componenteid = 9  AND p.prov_activo = 1"
        consulta += " GROUP BY p.prov_proveedorid, p.prov_razonsocial"

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ObtieneNaveDesarrollo(ByVal IDUsuario As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Dim consulta As String = "SELECT  CAST(0 AS BIT) as 'seleccion', nave_naveid, UPPER(nave_nombre) as nave_nombre, upper(nave_navesicyid) as nave_navesicyid FROM Framework.Naves AS b JOIN Framework.NavesUsuario as c on (b.nave_naveid=naus_naveid)"
        If IDUsuario > 0 Then
            consulta += " where naus_usuarioid=" + IDUsuario.ToString
            consulta += " and nave_desarrolla = 1 "
            consulta += " and nave_naveid not in (43,56) "
        End If
        consulta += " ORDER BY nave_nombre"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function imprimirReporte(cboxNaves As Integer,
                                    dtpFechaDel As String,
                                    dtpFechaAl As String,
                                    rdo As Boolean,
                                    rowsGrdPedidosSICY As String,
                                    rowsGrdLote As String,
                                    rowsGrdModelo As String,
                                    rowsGrdModeloSICY As String,
                                    rowsGrdAlmacen As String,
                                    rowsGrdVendedores As String,
                                    rowsGrdCorridas As String,
                                    rowsGrdColecciones As String,
                                    rowsGrdClientes As String,
                                    rowsGrdColores As String,
                                    rbtFecha As Int16,
                                    ByVal gruposNave As String,
                                    ByVal marcasId As String,
                                    ByVal familiasId As String,
                                    ByVal desactivaFechas As Boolean,
                                    rowGrdNaveDesarrollo As String,
                                    ByVal rowsGrdPedidosSay As String,
                                    ByRef usuarioId As Integer,
                                    ByRef conVigencia As Integer,
                                    rowsGrdSuelas As String
                                    ) As DataTable 'dtpFechaEDel As String, dtpFechaEAl As String,  rowsGrdSuelas As String

        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim operaciones As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "@naveId"
        parametro.Value = cboxNaves
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = dtpFechaDel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFin"
        parametro.Value = dtpFechaAl
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@verPendientes"
        parametro.Value = rdo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoIds"
        parametro.Value = rowsGrdPedidosSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@lotesIds"
        parametro.Value = rowsGrdLote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@modeloIds"
        parametro.Value = rowsGrdModelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@modeloIdsSICY"
        parametro.Value = rowsGrdModeloSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@almacenIds"
        parametro.Value = rowsGrdAlmacen
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@agenteIds"
        parametro.Value = rowsGrdVendedores
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@numeracionIds"
        parametro.Value = rowsGrdCorridas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@lineaIds"
        parametro.Value = rowsGrdColecciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clienteIds"
        parametro.Value = rowsGrdClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colorIds"
        parametro.Value = rowsGrdColores
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@auxiliarfecha"
        parametro.Value = rbtFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@gruposNave"
        parametro.Value = gruposNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@marcasIds"
        parametro.Value = marcasId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@familiasIds"
        parametro.Value = familiasId
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@desactivaFechas"
        parametro.Value = desactivaFechas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveDesarrolloIds"
        parametro.Value = rowGrdNaveDesarrollo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoIdsSay"
        parametro.Value = rowsGrdPedidosSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioId"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@conVigencia"
        parametro.Value = conVigencia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@proveedorSuela"
        parametro.Value = rowsGrdSuelas
        listaParametros.Add(parametro)

        'Return operaciones.EjecutarConsultaSP("[dbo].[SP_ReporteOrdenesProcesoConPedido_v7_15102021]", listaParametros)
        Return operaciones.EjecutarConsultaSP("[dbo].[SP_ReporteOrdenesProcesoConPedido_v9]", listaParametros)
        'Return operaciones.EjecutarConsultaSP("[dbo].[SP_ReporteOrdenesProcesoConPedido_v9_Daniel]", listaParametros)
    End Function

    Public Function Meses(dtpFechaDel As String, dtpFechaAl As String)

        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = dtpFechaDel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFin"
        parametro.Value = dtpFechaAl
        listaParametros.Add(parametro)


        Return operaciones.EjecutarConsultaSP("dbo.[SP_ReporteOrdenesProcesoTraeMeses]", listaParametros)

    End Function


    Public Function imprimirReporteporMes(cboxNaves As Integer, dtpFechaDel As String, dtpFechaAl As String, rowsGrdPedidosSICY As String, rowsGrdLote As String, rowsGrdModelo As String, rowsGrdAlmacen As String, rowsGrdVendedores As String, rowsGrdCorridas As String, rowsGrdColecciones As String, rowsGrdClientes As String, rowsGrdColores As String, ByVal gruposNave As String, ByVal marcasId As String, ByVal familiasId As String, ByVal desactivaFechas As Boolean, rowGrdNaveDesarrollo As String, rangomeses As String, ByVal rowsGrdPedidosSay As String) As DataTable

        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY

        parametro.ParameterName = "@naveId"
        parametro.Value = cboxNaves
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = dtpFechaDel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFin"
        parametro.Value = dtpFechaAl
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@desactivaFechas"
        parametro.Value = desactivaFechas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveDesarrolloIds"
        parametro.Value = rowGrdNaveDesarrollo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@rangomeses"
        parametro.Value = rangomeses
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoIds"
        parametro.Value = rowsGrdPedidosSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@lotesIds"
        parametro.Value = rowsGrdLote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@modeloIds"
        parametro.Value = rowsGrdModelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@almacenIds"
        parametro.Value = rowsGrdAlmacen
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@agenteIds"
        parametro.Value = rowsGrdVendedores
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@numeracionIds"
        parametro.Value = rowsGrdCorridas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@lineaIds"
        parametro.Value = rowsGrdColecciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clienteIds"
        parametro.Value = rowsGrdClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colorIds"
        parametro.Value = rowsGrdColores
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@gruposNave"
        parametro.Value = gruposNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@marcasIds"
        parametro.Value = marcasId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@familiasIds"
        parametro.Value = familiasId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoIdsay"
        parametro.Value = rowsGrdPedidosSay
        listaParametros.Add(parametro)




        Return operaciones.EjecutarConsultaSP("dbo.[SP_ReporteOrdenesProcesoConPedidoPorMes_2]", listaParametros)

    End Function

    Public Function imprimirReporteNavesProduccion(cboxNaves As Integer,
                                    dtpFechaDel As String,
                                    dtpFechaAl As String,
                                    rdo As Boolean,
                                    rowsGrdPedidosSICY As String,
                                    rowsGrdLote As String,
                                    rowsGrdModelo As String,
                                    rowsGrdAlmacen As String,
                                    rowsGrdVendedores As String,
                                    rowsGrdCorridas As String,
                                    rowsGrdColecciones As String,
                                    rowsGrdClientes As String,
                                    rowsGrdColores As String,
                                    rbtFecha As Int16,
                                    ByVal gruposNave As String,
                                    ByVal marcasId As String,
                                    ByVal familiasId As String,
                                    ByVal desactivaFechas As Boolean,
                                    rowGrdNaveDesarrollo As String,
                                    ByVal rowsGrdPedidosSay As String,
                                    ByRef usuarioId As Integer) As DataTable

        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY

        parametro.ParameterName = "@naveId"
        parametro.Value = cboxNaves
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = dtpFechaDel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFin"
        parametro.Value = dtpFechaAl
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@verPendientes"
        parametro.Value = rdo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoIds"
        parametro.Value = rowsGrdPedidosSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@lotesIds"
        parametro.Value = rowsGrdLote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@modeloIds"
        parametro.Value = rowsGrdModelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@almacenIds"
        parametro.Value = rowsGrdAlmacen
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@agenteIds"
        parametro.Value = rowsGrdVendedores
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@numeracionIds"
        parametro.Value = rowsGrdCorridas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@lineaIds"
        parametro.Value = rowsGrdColecciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clienteIds"
        parametro.Value = rowsGrdClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colorIds"
        parametro.Value = rowsGrdColores
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@auxiliarfecha"
        parametro.Value = rbtFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@gruposNave"
        parametro.Value = gruposNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@marcasIds"
        parametro.Value = marcasId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@familiasIds"
        parametro.Value = familiasId
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@desactivaFechas"
        parametro.Value = desactivaFechas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveDesarrolloIds"
        parametro.Value = rowGrdNaveDesarrollo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoIdsSay"
        parametro.Value = rowsGrdPedidosSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioId"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_ReporteOrdenesProceso_NavesProduccion]", listaParametros)
    End Function

    Public Function imprimirReporteNavesProduccionInventario(cboxNaves As Integer,
                                   dtpFechaDel As String,
                                   dtpFechaAl As String,
                                   rdo As Boolean,
                                   rowsGrdPedidosSICY As String,
                                   rowsGrdLote As String,
                                   rowsGrdModelo As String,
                                   rowsGrdAlmacen As String,
                                   rowsGrdVendedores As String,
                                   rowsGrdCorridas As String,
                                   rowsGrdColecciones As String,
                                   rowsGrdClientes As String,
                                   rowsGrdColores As String,
                                   rbtFecha As Int16,
                                   ByVal gruposNave As String,
                                   ByVal marcasId As String,
                                   ByVal familiasId As String,
                                   ByVal desactivaFechas As Boolean,
                                   rowGrdNaveDesarrollo As String,
                                   ByVal rowsGrdPedidosSay As String,
                                   ByRef usuarioId As Integer) As DataTable

        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY

        parametro.ParameterName = "@naveId"
        parametro.Value = cboxNaves
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = dtpFechaDel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFin"
        parametro.Value = dtpFechaAl
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@verPendientes"
        parametro.Value = rdo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoIds"
        parametro.Value = rowsGrdPedidosSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@lotesIds"
        parametro.Value = rowsGrdLote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@modeloIds"
        parametro.Value = rowsGrdModelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@almacenIds"
        parametro.Value = rowsGrdAlmacen
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@agenteIds"
        parametro.Value = rowsGrdVendedores
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@numeracionIds"
        parametro.Value = rowsGrdCorridas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@lineaIds"
        parametro.Value = rowsGrdColecciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clienteIds"
        parametro.Value = rowsGrdClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colorIds"
        parametro.Value = rowsGrdColores
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@auxiliarfecha"
        parametro.Value = rbtFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@gruposNave"
        parametro.Value = gruposNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@marcasIds"
        parametro.Value = marcasId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@familiasIds"
        parametro.Value = familiasId
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@desactivaFechas"
        parametro.Value = desactivaFechas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveDesarrolloIds"
        parametro.Value = rowGrdNaveDesarrollo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoIdsSay"
        parametro.Value = rowsGrdPedidosSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioId"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_ReporteOrdenesProceso_NavesProduccionInventario]", listaParametros)
    End Function

    Public Function ConsultarParametrosFiltros(ByVal TipoBusquedaID As Integer, ByVal ParametroFiltroID As Integer)
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter("@TipoBusquedaID", TipoBusquedaID))

        listaParametros.Add(New SqlParameter("@ParametroFiltroID", ParametroFiltroID))

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_OrdenesEnProceso_ConsultarParametrosFiltros]", listaParametros)
    End Function

    Public Function ConsultarOrdenesEnProcesoFiltros(ByVal objFiltrosOrdenesEnProceso As FiltroOrdenesEnProceso)
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter("@NaveID", objFiltrosOrdenesEnProceso.PNaveID))
        listaParametros.Add(New SqlParameter("@FechaInicio", objFiltrosOrdenesEnProceso.PFechaInicio))
        listaParametros.Add(New SqlParameter("@FechaFin", objFiltrosOrdenesEnProceso.PFechaFin))
        listaParametros.Add(New SqlParameter("@PedidosSAYID", objFiltrosOrdenesEnProceso.PPedidosSAYID))
        listaParametros.Add(New SqlParameter("@PedidosSICYID", objFiltrosOrdenesEnProceso.PPedidosSICYID))
        listaParametros.Add(New SqlParameter("@Lotes", objFiltrosOrdenesEnProceso.PLotes))
        listaParametros.Add(New SqlParameter("@GrupoNave", objFiltrosOrdenesEnProceso.PGrupoNave))
        listaParametros.Add(New SqlParameter("@ModelosSAY", objFiltrosOrdenesEnProceso.PModelosSAY))
        listaParametros.Add(New SqlParameter("@ModelosSICY", objFiltrosOrdenesEnProceso.PModelosSICY))
        listaParametros.Add(New SqlParameter("@NavesDesarrolloID", objFiltrosOrdenesEnProceso.PNavesDesarrolloID))
        listaParametros.Add(New SqlParameter("@HormasID", objFiltrosOrdenesEnProceso.PHormasID))
        listaParametros.Add(New SqlParameter("@ProveedoresSuelaID", objFiltrosOrdenesEnProceso.PProveedoresSuelaID))
        listaParametros.Add(New SqlParameter("@TemporadasID", objFiltrosOrdenesEnProceso.PTemporadasID))
        listaParametros.Add(New SqlParameter("@Corridas", objFiltrosOrdenesEnProceso.PCorridas))
        listaParametros.Add(New SqlParameter("@ClientesID", objFiltrosOrdenesEnProceso.PClientesID))
        listaParametros.Add(New SqlParameter("@SuelasID", objFiltrosOrdenesEnProceso.PSuelasID))
        listaParametros.Add(New SqlParameter("@MarcasID", objFiltrosOrdenesEnProceso.PMarcasID))
        listaParametros.Add(New SqlParameter("@ColeccionesID", objFiltrosOrdenesEnProceso.PColeccionesID))
        listaParametros.Add(New SqlParameter("@PielesColoresID", objFiltrosOrdenesEnProceso.PPielesColoresID))
        listaParametros.Add(New SqlParameter("@FamiliasVentaID", objFiltrosOrdenesEnProceso.PFamiliasVentaID))
        listaParametros.Add(New SqlParameter("@FamiliasID", objFiltrosOrdenesEnProceso.PFamiliasID))
        listaParametros.Add(New SqlParameter("@TipoConsulta", objFiltrosOrdenesEnProceso.PTipoConsulta))
        listaParametros.Add(New SqlParameter("@TipoBusqueda", objFiltrosOrdenesEnProceso.PTipoBusqueda))

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_OrdenesEnProceso_ConsultarOrdenesEnProcesoFiltros]", listaParametros)
    End Function

    Public Function ConsultarLotesEntregadosPorMesFiltros(ByVal objFiltrosOrdenesEnProceso As FiltroOrdenesEnProceso)
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter("@NaveID", objFiltrosOrdenesEnProceso.PNaveID))
        listaParametros.Add(New SqlParameter("@FechaInicio", objFiltrosOrdenesEnProceso.PFechaInicio))
        listaParametros.Add(New SqlParameter("@FechaFin", objFiltrosOrdenesEnProceso.PFechaFin))
        listaParametros.Add(New SqlParameter("@PedidosSAYID", objFiltrosOrdenesEnProceso.PPedidosSAYID))
        listaParametros.Add(New SqlParameter("@PedidosSICYID", objFiltrosOrdenesEnProceso.PPedidosSICYID))
        listaParametros.Add(New SqlParameter("@Lotes", objFiltrosOrdenesEnProceso.PLotes))
        listaParametros.Add(New SqlParameter("@GrupoNave", objFiltrosOrdenesEnProceso.PGrupoNave))
        listaParametros.Add(New SqlParameter("@ModelosSAY", objFiltrosOrdenesEnProceso.PModelosSAY))
        listaParametros.Add(New SqlParameter("@ModelosSICY", objFiltrosOrdenesEnProceso.PModelosSICY))
        listaParametros.Add(New SqlParameter("@NavesDesarrolloID", objFiltrosOrdenesEnProceso.PNavesDesarrolloID))
        listaParametros.Add(New SqlParameter("@HormasID", objFiltrosOrdenesEnProceso.PHormasID))
        listaParametros.Add(New SqlParameter("@TemporadasID", objFiltrosOrdenesEnProceso.PTemporadasID))
        listaParametros.Add(New SqlParameter("@Corridas", objFiltrosOrdenesEnProceso.PCorridas))
        listaParametros.Add(New SqlParameter("@ClientesID", objFiltrosOrdenesEnProceso.PClientesID))
        listaParametros.Add(New SqlParameter("@SuelasID", objFiltrosOrdenesEnProceso.PSuelasID))
        listaParametros.Add(New SqlParameter("@MarcasID", objFiltrosOrdenesEnProceso.PMarcasID))
        listaParametros.Add(New SqlParameter("@ColeccionesID", objFiltrosOrdenesEnProceso.PColeccionesID))
        listaParametros.Add(New SqlParameter("@PielesColoresID", objFiltrosOrdenesEnProceso.PPielesColoresID))
        listaParametros.Add(New SqlParameter("@FamiliasVentaID", objFiltrosOrdenesEnProceso.PFamiliasVentaID))

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_OrdenesEnProceso_ConsultarLotesEntregadosPorMesFiltros]", listaParametros)
    End Function

    Public Function ConsultarNavesPorUsuario(ByVal UsuarioID As Integer)
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@UsuarioID", UsuarioID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_OrdenesEnProceso_ConsultarNaves]", listaParametros)
    End Function

End Class
