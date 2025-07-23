Imports System.Data.SqlClient

Public Class AdministradorPedidosSapicaDA
    ''consulta de las fechas de colecciones
    Public Function consultaFechasColeccionesNV(ByVal idEvento As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter()
        parametro.ParameterName = "idEvento"
        parametro.Value = idEvento
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_Admon_ConsultaFechas", listaParametros)
    End Function

    ''consulta administrador de pedidos
    Public Function consultaAdministradorPedidos(ByVal idEvento As Int32, ByVal idEstatus As String, ByVal idVisitante As String,
                                                 ByVal idAtiende As String, ByVal idTipoVisitante As String, ByVal fechaCaptura As Int32,
                                                 ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String, ByVal fechaSolicitada As Int32,
                                                 ByVal fechaSolicitadaInicio As String, ByVal fechaSolicitadaFin As String, ByVal tipoCondicion As String,
                                                 ByVal idPedido As Int32) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter()
        parametro.ParameterName = "idEvento"
        parametro.Value = idEvento
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "idEstatus"
        parametro.Value = idEstatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "idVisitante"
        parametro.Value = idVisitante
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "idAtiende"
        parametro.Value = idAtiende
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "idTipoVisitante"
        parametro.Value = idTipoVisitante
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "fechaCaptura"
        parametro.Value = fechaCaptura
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "fechaCapturaInicio"
        parametro.Value = fechaCapturaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "fechaCapturaFin"
        parametro.Value = fechaCapturaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "fechaSolicitada"
        parametro.Value = fechaSolicitada
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "fechaSolicitadaInicio"
        parametro.Value = fechaSolicitadaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "fechaSolicitadaFin"
        parametro.Value = fechaSolicitadaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "tipoCondicion"
        parametro.Value = tipoCondicion
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_Admon_ConsultaAdministradorPedidos", listaParametros)
    End Function


    ''consulta datos del pedido seleccionado
    Public Function consultaDatosPedidoSeleccionado(ByVal idPedido As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter()
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_ConsultaDatosPedidoSeleccionado", listaParametros)
    End Function

    ''consulta de los detalles de partidas del pedido seleccionado
    Public Function consultaDetallesPedidoSeleccionado(ByVal idPedido As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter()
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_ConsultaDetallesPedidoSeleccionado", listaParametros)

    End Function

    ''consulta listado de estatus del pedido
    Public Function consultaListadoEstatusPedido() As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = " exec SAPICA.SP_PedidosWeb_ListadoEstatusPedido"

        Return persistencia.EjecutaConsulta(consulta)
    End Function


    ''consulta permiso editar pedido
    Public Function consultaPermisoBotonEditarPedido(ByVal idPedido As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter()
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_PermisoBotonEditarPedido", listaParametros)

    End Function




End Class
