Public Class AdministradorPedidosSapicaBu
    ''consulta de las fechas de colecciones
    Public Function consultaFechasColeccionesNV(ByVal idEvento As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosSapicaDA
        Dim dtFechas As New DataTable

        dtFechas = objDa.consultaFechasColeccionesNV(idEvento)

        Return dtFechas
    End Function

    ''consulta administrador de pedidos
    Public Function consultaAdministradorPedidos(ByVal idEvento As Int32, ByVal idEstatus As String, ByVal idVisitante As String,
                                                 ByVal idAtiende As String, ByVal idTipoVisitante As String, ByVal fechaCaptura As Int32,
                                                 ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String, ByVal fechaSolicitada As Int32,
                                                 ByVal fechaSolicitadaInicio As String, ByVal fechaSolicitadaFin As String, ByVal tipoCondicion As String,
                                                 ByVal idPedido As Int32) As DataTable

        Dim objDa As New Datos.AdministradorPedidosSapicaDA
        Dim dtAdmon As New DataTable

        dtAdmon = objDa.consultaAdministradorPedidos(idEvento, idEstatus, idVisitante, idAtiende, idTipoVisitante, fechaCaptura,
                                                     fechaCapturaInicio, fechaCapturaFin, fechaSolicitada, fechaSolicitadaInicio,
                                                     fechaSolicitadaFin, tipoCondicion, idPedido)

        Return dtAdmon
    End Function

    ''consulta datos del pedido seleccionado
    Public Function consultaDatosPedidoSeleccionado(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosSapicaDA
        Dim dtPedSel As New DataTable

        dtPedSel = objDa.consultaDatosPedidoSeleccionado(idPedido)

        Return dtPedSel
    End Function

    ''consulta de los detalles de partidas del pedido seleccionado
    Public Function consultaDetallesPedidoSeleccionado(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosSapicaDA
        Dim dtDetallesPedSel As New DataTable

        dtDetallesPedSel = objDa.consultaDetallesPedidoSeleccionado(idPedido)

        Return dtDetallesPedSel
    End Function

    ''consulta listado de estatus del pedido
    Public Function consultaListadoEstatusPedido() As DataTable
        Dim objDa As New Datos.AdministradorPedidosSapicaDA
        Dim dtEstatus As New DataTable

        dtEstatus = objDa.consultaListadoEstatusPedido()

        Return dtEstatus
    End Function

    ''consulta permiso editar pedido
    Public Function consultaPermisoBotonEditarPedido(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosSapicaDA
        Dim dtPermiso As New DataTable

        dtPermiso = objDa.consultaPermisoBotonEditarPedido(idPedido)

        Return dtPermiso
    End Function



End Class
