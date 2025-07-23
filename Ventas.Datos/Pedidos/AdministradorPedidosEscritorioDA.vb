Imports System.Data.SqlClient

Public Class AdministradorPedidosEscritorioDA
    Private objOperacionesSAY As New Persistencia.OperacionesProcedimientos
    Private objOperacionesSICY As New Persistencia.OperacionesProcedimientosSICY
    Private listaParametros As New List(Of SqlParameter)

    Public Function ConsultarPedidos(obj As Entidades.FiltroAdministradorPedido, leerAsignados As Boolean) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@mostrarPartidas"
        parametro.Value = obj.MostrarPartidas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoFecha"
        parametro.Value = obj.TipoFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = obj.FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFin"
        parametro.Value = obj.FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatusPedido"
        parametro.Value = obj.EstatusPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = obj.PedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@familiaVentas"
        parametro.Value = obj.PedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cliente"
        parametro.Value = obj.Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@atnClientes"
        parametro.Value = obj.AtnCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@agenteVentas"
        parametro.Value = obj.AgenteVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@modelo"
        parametro.Value = obj.Modelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@color"
        parametro.Value = obj.Color
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@corrida"
        parametro.Value = obj.Corrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@piel"
        parametro.Value = obj.Piel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@marca"
        parametro.Value = obj.Marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@coleccion"
        parametro.Value = obj.Coleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@SoloAsignados"
        parametro.Value = leerAsignados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@comercializadoraId"
        parametro.Value = obj.CEDIS
        listaParametros.Add(parametro)


        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Consultar_2]", listaParametros)

    End Function

    Public Function ConsultarPedidoDetalle(pedidoid As Integer) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoid
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Consultar_PedidoDetalle]", listaParametros)

    End Function

    Public Function ConsultarPedidoEncabezado(pedidoid As Integer) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoId"
        parametro.Value = pedidoid
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Consultar_InformacionEncabezado]", listaParametros)

    End Function


    Public Function ConsultarInformacionTallas(pedidoid As Integer, partidas As String) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@partidas"
        parametro.Value = partidas
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Consultar_InformacionTallas]", listaParametros)

    End Function

    Public Function Administrador_DatosInicialesPermisos() As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Administrador_DatosInicialesPermisos]", listaParametros)

    End Function

    Public Function Consultar_InformacionLotes(pedidoSICY As Integer, partidas As String) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSICY"
        parametro.Value = pedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@partidas"
        parametro.Value = partidas
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Consultar_InformacionLotes]", listaParametros)

    End Function

    Public Function Consultar_InformacionOT(pedidoSAY As Integer, partida As Integer) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@partida"
        parametro.Value = partida
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Consultar_InformacionOT]", listaParametros)

    End Function

    Public Function Consultar_InformacionFactura(pedidoSAY As Integer, partida As Integer) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@partida"
        parametro.Value = partida
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Consultar_InformacionDocumento]", listaParametros)

    End Function

    Public Function ConsultarMotivosCancelacion() As DataTable
        listaParametros.Clear()

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Cancelacion_ConsultarMotivos]", listaParametros)

    End Function

    Public Function ConsultarSumatoriaParesACancelar(pedidoSAY As Integer, partidas As String) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@partidasACancelar"
        parametro.Value = partidas
        listaParametros.Add(parametro)


        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Cancelacion_ConsultarSumatoriaParesACancelar]", listaParametros)

    End Function

    Public Function ValidarPartidas(pedidoSAY As Integer, partidas As String) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@partidas"
        parametro.Value = partidas
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Cancelacion_ValidarPartidas]", listaParametros)
    End Function

    Public Function ValidarPartidasEnApartadosDesdePedidos(pedidosSAY As String) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidosSAY"
        parametro.Value = pedidosSAY
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Cancelacion_ValidarPartidasApartadosDesdePedidos]", listaParametros)
    End Function

    Public Sub EliminarPartidasAbiertas(pedidoSAY As Integer, partidas As String)
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@partidas"
        parametro.Value = partidas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Cancelacion_EliminarPartidasAbiertas]", listaParametros)
    End Sub


    Public Function CancelarPartidas(pedidoSAY As Integer, partidas As String, solicita As String, motivoCancelacionId As Integer, observacionesCancelacion As String) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@partidas"
        parametro.Value = partidas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@solicita"
        parametro.Value = solicita
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MotivoCancelacionID"
        parametro.Value = motivoCancelacionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ObservacionesCancelacion"
        parametro.Value = observacionesCancelacion
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Cancelacion_CancelarPartidas_Omar]", listaParametros)
    End Function

    Public Function ObtenerPartidasDelPedido(pedidoSAY As Integer) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoSAY
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Cancelacion_ConsultarPartidasPedido]", listaParametros)
    End Function

    Public Function ConsultarArticulosLotesCancelados(pedidoSAY As Integer, partidas As String) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@partidas"
        parametro.Value = partidas
        listaParametros.Add(parametro)

        Return objOperacionesSICY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Cancelacion_ConsultarArticulosLotesCancelados]", listaParametros)
    End Function

    Public Function DescartarPedido(pedidoId As Integer) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoIDSAY"
        parametro.Value = pedidoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioModificaID"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Cancelacion_DescartarPedido]", listaParametros)
    End Function


    Public Sub ActualizarParesOTs()
        listaParametros.Clear()

        objOperacionesSICY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Cancelacion_ActualizarParesOT_Pendientes]", listaParametros)
    End Sub


    Public Function ACtualizaParesOTSICY(pedidoSAYId As Integer) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoSAYId
        listaParametros.Add(parametro)


        Return objOperacionesSICY.EjecutarConsultaSP("[Ventas].[SP_CancelacionPedidos_ActualizarPares_Desasignacion]", listaParametros)
    End Function

    Public Function CancelarApartadosSICY(pedidoSAYId As Integer) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAYID"
        parametro.Value = pedidoSAYId
        listaParametros.Add(parametro)

        Return objOperacionesSICY.EjecutarConsultaSP("[Ventas].[SP_AdministradorPedidos_Apartados_CancelarPartidaApartados]", listaParametros)
    End Function

    Public Function ObtenerResultadoCancelacion(pedidoSAYId As String) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoSAYId
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_AministradorPedidos_ObtieneReusltadoCancelacion]", listaParametros)
    End Function

    Public Function LimpiarSessionPedido(pedidoSAYId As String) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoSAYId
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_AdministradorPedidos_Cancelacion_BorrarSessionPedidos]", listaParametros)


    End Function


    Public Function ActualizarEstatusPedidoSICY(pedidoSAYId As Integer) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoSAYId
        listaParametros.Add(parametro)

        Return objOperacionesSICY.EjecutarConsultaSP("[Ventas].[SP_AdministradorPedidos_Cancelacion_ActualizarEstatusPedidoSICY]", listaParametros)


    End Function

    Public Function CancelarPedidos(pedidoSAY As Integer, solicita As String, motivoCancelacionId As Integer, observacionesCancelacion As String) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoSAY
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@solicita"
        parametro.Value = solicita
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MotivoCancelacionID"
        parametro.Value = motivoCancelacionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ObservacionesCancelacion"
        parametro.Value = observacionesCancelacion
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Cancelacion_CancelarPedidos_Omar]", listaParametros)
    End Function


    Public Function CancelarLotesNoProgramadosPedidos(pedidoSAY As Integer, observacionesCancelacion As String) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@motivoCancelacion"
        parametro.Value = observacionesCancelacion
        listaParametros.Add(parametro)

        Return objOperacionesSICY.EjecutarConsultaSP("[Ventas].[SP_AdmnistradorPedidos_Cancelacion_CancelarLotesNoProgramadosPedidos]", listaParametros)
    End Function

    Public Function CancelarLotesNoProgramadosPartidas(pedidoSAY As Integer, ByVal Partidas As String, observacionesCancelacion As String) As DataTable
        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@partidas"
        parametro.Value = Partidas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@motivoCancelacion"
        parametro.Value = observacionesCancelacion
        listaParametros.Add(parametro)

        Return objOperacionesSICY.EjecutarConsultaSP("[Ventas].[SP_AdmnistradorPedidos_Cancelacion_CancelarLotesNoProgramados]", listaParametros)
    End Function

    Public Function ValidarPedidoEnPlanFabricacion_EstatusEnviadoPPCP(ByVal pedidos As String) As DataTable
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@pedidos", pedidos)
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Programacion].[SP_Pedidos_Cancelacion_ValidaPedidoEnPlanFabricacion]", listaParametros)
    End Function

End Class
