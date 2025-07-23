Imports Entidades
Imports Produccion.Datos

Public Class OrdenesEnProcesoBU
    Private objOrdenesEnProcesoDA As New OrdenesEnProcesoDA
    Public Function ObtieneHormas() As DataTable
        Dim obj As New OrdenesEnProcesoDA
        Return obj.ObtieneHormas
    End Function

    Public Function ObtieneTemporadas() As DataTable
        Dim obj As New OrdenesEnProcesoDA
        Return obj.ObtieneTemporadas
    End Function

    Public Function ObtieneCorridas() As DataTable
        Dim obj As New OrdenesEnProcesoDA
        Return obj.ObtieneCorridas
    End Function

    Public Function ObtieneSuelasProveedor() As DataTable
        Dim obj As New OrdenesEnProcesoDA
        Return obj.ObtieneSuelasProveedor
    End Function

    Public Function imprimirReporte(cboxNaves As Integer, dtpFechaDel As String, dtpFechaAl As String, rdo As Boolean, rowsGrdPedidosSICY As String, rowsGrdLote As String, rosGrdModelo As String, rosGrdModeloSICY As String, rowsGrdAlmacen As String, rowsGrdVendedores As String, rowsGrdCorridas As String, rowsGrdColecciones As String, rowsGrdClientes As String, rowsGrdColores As String, rbtFecha As Int16, ByVal gruposNave As String, ByVal marcasId As String, ByVal familiasId As String, ByVal desactivaFechas As Boolean, ByVal rowsgrdnavesdesarrollo As String, ByVal rowsGrdPedidosSay As String, ByVal usuarioId As Integer, ByVal conVigencia As Integer, ByVal rowsGrdSuelas As String) ', ByVal rowsGrdSuelas As String
        Dim obj As New OrdenesEnProcesoDA
        Return obj.imprimirReporte(cboxNaves, dtpFechaDel, dtpFechaAl, rdo, rowsGrdPedidosSICY, rowsGrdLote, rosGrdModelo, rosGrdModeloSICY, rowsGrdAlmacen, rowsGrdVendedores, rowsGrdCorridas, rowsGrdColecciones, rowsGrdClientes, rowsGrdColores, rbtFecha, gruposNave, marcasId, familiasId, desactivaFechas, rowsgrdnavesdesarrollo, rowsGrdPedidosSay, usuarioId, conVigencia, rowsGrdSuelas) 'dtpFechaEDel, dtpFechaEAl,, rowsGrdSuelas
    End Function

    Public Function ObtieneNaveDesarrollo(ByVal IDUsuario As Integer) As DataTable
        Dim obj As New OrdenesEnProcesoDA
        Return obj.ObtieneNaveDesarrollo(IDUsuario)
    End Function

    Public Function imprimirReporteporMes(cboxNaves As Integer, dtpFechaDel As String, dtpFechaAl As String, rowsGrdPedidosSICY As String, rowsGrdLote As String, rosGrdModelo As String, rowsGrdAlmacen As String, rowsGrdVendedores As String, rowsGrdCorridas As String, rowsGrdColecciones As String, rowsGrdClientes As String, rowsGrdColores As String, ByVal gruposNave As String, ByVal marcasId As String, ByVal familiasId As String, ByVal desactivaFechas As Boolean, ByVal rowsgrdnavesdesarrollo As String, rangomeses As String, ByVal rowsGrdPedidosSay As String)
        Dim obj As New OrdenesEnProcesoDA
        Return obj.imprimirReporteporMes(cboxNaves, dtpFechaDel, dtpFechaAl, rowsGrdPedidosSICY, rowsGrdLote, rosGrdModelo, rowsGrdAlmacen, rowsGrdVendedores, rowsGrdCorridas, rowsGrdColecciones, rowsGrdClientes, rowsGrdColores, gruposNave, marcasId, familiasId, desactivaFechas, rowsgrdnavesdesarrollo, rangomeses, rowsGrdPedidosSay)
    End Function

    Public Function meses(dtpFechaDel As String, dtpFechaAl As String)
        Dim obj As New OrdenesEnProcesoDA
        Return obj.Meses(dtpFechaDel, dtpFechaAl)

    End Function

    Public Function imprimirReporteNavesProduccion(cboxNaves As Integer, dtpFechaDel As String, dtpFechaAl As String, rdo As Boolean, rowsGrdPedidosSICY As String, rowsGrdLote As String, rosGrdModelo As String, rowsGrdAlmacen As String, rowsGrdVendedores As String, rowsGrdCorridas As String, rowsGrdColecciones As String, rowsGrdClientes As String, rowsGrdColores As String, rbtFecha As Int16, ByVal gruposNave As String, ByVal marcasId As String, ByVal familiasId As String, ByVal desactivaFechas As Boolean, ByVal rowsgrdnavesdesarrollo As String, ByVal rowsGrdPedidosSay As String, ByVal usuarioId As Integer)
        Dim objDA As New OrdenesEnProcesoDA
        Return objDA.imprimirReporteNavesProduccion(cboxNaves, dtpFechaDel, dtpFechaAl, rdo, rowsGrdPedidosSICY, rowsGrdLote, rosGrdModelo, rowsGrdAlmacen, rowsGrdVendedores, rowsGrdCorridas, rowsGrdColecciones, rowsGrdClientes, rowsGrdColores, rbtFecha, gruposNave, marcasId, familiasId, desactivaFechas, rowsgrdnavesdesarrollo, rowsGrdPedidosSay, usuarioId)
    End Function

    Public Function imprimirReporteNavesProduccionInventario(cboxNaves As Integer, dtpFechaDel As String, dtpFechaAl As String, rdo As Boolean, rowsGrdPedidosSICY As String, rowsGrdLote As String, rosGrdModelo As String, rowsGrdAlmacen As String, rowsGrdVendedores As String, rowsGrdCorridas As String, rowsGrdColecciones As String, rowsGrdClientes As String, rowsGrdColores As String, rbtFecha As Int16, ByVal gruposNave As String, ByVal marcasId As String, ByVal familiasId As String, ByVal desactivaFechas As Boolean, ByVal rowsgrdnavesdesarrollo As String, ByVal rowsGrdPedidosSay As String, ByVal usuarioId As Integer)
        Dim objDA As New OrdenesEnProcesoDA
        Return objDA.imprimirReporteNavesProduccionInventario(cboxNaves, dtpFechaDel, dtpFechaAl, rdo, rowsGrdPedidosSICY, rowsGrdLote, rosGrdModelo, rowsGrdAlmacen, rowsGrdVendedores, rowsGrdCorridas, rowsGrdColecciones, rowsGrdClientes, rowsGrdColores, rbtFecha, gruposNave, marcasId, familiasId, desactivaFechas, rowsgrdnavesdesarrollo, rowsGrdPedidosSay, usuarioId)
    End Function

    Public Function ConsultarParametrosFiltros(ByVal TipoBusquedaID As Integer, ByVal ParametroFiltroID As Integer)
        Return objOrdenesEnProcesoDA.ConsultarParametrosFiltros(TipoBusquedaID, ParametroFiltroID)
    End Function
    Public Function ConsultarOrdenesEnProcesoFiltros(ByVal objFiltrosOrdenesEnProceso As FiltroOrdenesEnProceso)
        Return objOrdenesEnProcesoDA.ConsultarOrdenesEnProcesoFiltros(objFiltrosOrdenesEnProceso)
    End Function
    Public Function ConsultarLotesEntregadosPorMesFiltros(ByVal objFiltrosOrdenesEnProceso As FiltroOrdenesEnProceso)
        Return objOrdenesEnProcesoDA.ConsultarLotesEntregadosPorMesFiltros(objFiltrosOrdenesEnProceso)
    End Function

    Public Function ConsultarNavesPorUsuario(ByVal UsuarioID As Integer)
        Return objOrdenesEnProcesoDA.ConsultarNavesPorUsuario(UsuarioID)
    End Function
End Class

