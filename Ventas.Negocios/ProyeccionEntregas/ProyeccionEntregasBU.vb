
Public Class ProyeccionEntregasBU



    Public Function ListadoParametroProyeccionEntregas(tipo_busqueda As Integer, ColaboradorID As Integer, TipoPerfil As Integer, tipoCliente As String) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.ListadoParametroProyeccionEntregas(tipo_busqueda, ColaboradorID, TipoPerfil, tipoCliente)
        Return tabla
    End Function

    Public Function ConsultaSesionActivaPorUsuario(idUsuario As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaSesionActivaPorUsuario(idUsuario)
        Return tabla
    End Function
    Public Function CompararPedidOrigen(ByVal pedidoSay As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.CompararPedidOrigen(pedidoSay)
        Return tabla
    End Function

    Public Function ConsultaSesionActivaPorUsuario_SoloConsulta(idUsuario As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaSesionActivaPorUsuario_SoloConsulta(idUsuario)
        Return tabla
    End Function

    Public Sub GeneracionDatosProyeccionEntregas(colaborador As Integer, usuarioId As Integer, usuarioNombre As String, sesionAnterior As Integer, filtros As Entidades.ProyeccionEntregas)
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        objDA.GeneracionDatosProyeccionEntregas(colaborador, usuarioId, usuarioNombre, sesionAnterior, filtros)
    End Sub

    Public Sub GeneracionDatosProyeccionEntregas_SoloConsulta(colaborador As Integer, usuarioId As Integer, usuarioNombre As String, sesionAnterior As Integer, filtros As Entidades.ProyeccionEntregas)
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        objDA.GeneracionDatosProyeccionEntregas_SoloConsulta(colaborador, usuarioId, usuarioNombre, sesionAnterior, filtros)
    End Sub

    Public Function ConsultaProyeccionPorNivel(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaProyeccionPorNivel(consultaNivel)
        Return tabla
    End Function

    Public Function LimpiarSesionUsuarioCerrarPantalla(ByVal SesionID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.LimpiarSesionUsuarioCerrarPantalla(SesionID)
        Return tabla
    End Function

    Public Function LimpiarSesionUsuarioCerrarPantalla_SoloConsulta(ByVal SesionID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.LimpiarSesionUsuarioCerrarPantalla_SoloConsulta(SesionID)
        Return tabla
    End Function

    Public Function GuardarProyeccion(ByVal NivelSeleccion As Integer, ByVal PedidoSICY As String, ByVal CodigoPartida As String, ByVal Lote As Integer, ByVal AñoLote As Integer, ByVal NaveLote As Integer, ByVal CodigoAtado As String, ByVal CodigoPar As String, ByVal TomarInventario As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.GuardarProyeccion(NivelSeleccion, PedidoSICY, CodigoPartida, Lote, AñoLote, NaveLote, CodigoAtado, CodigoPar, TomarInventario)
        Return tabla
    End Function

    Public Function GenerarOrdenesTrabajo(ByVal SesionUsuarioID As Integer, ByVal UsuarioId As Integer)
        Dim tabla As New DataTable
        ''''COMENTADO EL 10/01/2019 LMEP CON EL OBJETIVO DE OPTIMIZAR EL PROCESO DE PROYECCIÓN.
        ''Genera los encabezados de las OTS
        'tabla = GenerarEncabezadosOT(SesionUsuarioID)
        ''Genera los detalles de las OTS
        'GenerarDetallesOrdenesTrabajo(UsuarioId)

        'RelacionarOTPares(UsuarioId)

        tabla = GenerarOrdenesTrabajoCompletas(SesionUsuarioID)

        Return tabla

    End Function

#Region "Generación de OTs"

    Private Function GenerarEncabezadosOT(ByVal SesionUsuarioID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim dtResultadoGeneracion As New DataTable
        Try
            dtResultadoGeneracion = objDA.GenerarEncabezadoOrdenesTrabajo(SesionUsuarioID)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                dtResultadoGeneracion = GenerarEncabezadosOT(SesionUsuarioID)
            End If
        End Try
        Return dtResultadoGeneracion
    End Function

    Private Function GenerarOrdenesTrabajoCompletas(ByVal SesionUsuarioID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim dtResultadoGeneracion As New DataTable
        Try
            dtResultadoGeneracion = objDA.GenerarOrdenesTrabajoCompletas(SesionUsuarioID)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                dtResultadoGeneracion = GenerarOrdenesTrabajoCompletas(SesionUsuarioID)
            End If
        End Try
        Return dtResultadoGeneracion
    End Function

    Private Sub GenerarDetallesOrdenesTrabajo(ByVal UsuarioId As Integer)
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Try
            objDA.GenerarDetallesOrdenesTrabajo(UsuarioId)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                GenerarDetallesOrdenesTrabajo(UsuarioId)
            End If
        End Try
    End Sub

    Private Sub RelacionarOTPares(ByVal UsuarioId As Integer)
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Try
            objDA.RelacionarOTPares(UsuarioId)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                RelacionarOTPares(UsuarioId)
            End If
        End Try
    End Sub

#End Region

    Public Function EliminarSesionUsuario(ByVal SesionUsuario As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.EliminarSesionUsuario(SesionUsuario)
        Return tabla
    End Function


    Public Function ComprobarDatosOcupados(ByVal SesionID As Integer, ByVal Filtros As Entidades.ProyeccionEntregas) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.ComprobarDatosOcupados(SesionID, Filtros)
        Return tabla
    End Function

    Public Function ComprobarDatosOcupados_SoloConsulta(ByVal SesionID As Integer, ByVal Filtros As Entidades.ProyeccionEntregas) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.ComprobarDatosOcupados_SoloConsulta(SesionID, Filtros)
        Return tabla
    End Function

    Public Function ConsultaParesApartadosPorConfirmar(ByVal SesionID As Integer, ByVal ModoConsulta As Boolean) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Return objDA.ConsultaParesApartadosPorConfirmar(SesionID, ModoConsulta)
    End Function

    Public Function ConsultaParesProgramacionProgramado(ByVal SesionID As Integer, ByVal ModoConsulta As Boolean) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Return objDA.ConsultaParesProgramacionProgramado(SesionID, ModoConsulta)
    End Function

    Public Function ConsultaParesEnReproceso(ByVal SesionID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Return objDA.ConsultaParesEnReproceso(SesionID)
    End Function

    Public Function ConsultaParesEnReproceso_SoloConsulta(ByVal SesionID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Return objDA.ConsultaParesEnReproceso_SoloConsulta(SesionID)
    End Function

    Public Function ConsultaParesBloquedos(ByVal SesionID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Return objDA.ConsultaParesBloquedos(SesionID)
    End Function

    Public Function ConsultaParesBloquedos_SoloConsulta(ByVal SesionID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Return objDA.ConsultaParesBloquedos_SoloConsulta(SesionID)
    End Function

    Public Function ConsultaParesEnProceso(ByVal SesionID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Return objDA.ConsultaParesEnProceso(SesionID)
    End Function

    Public Function ConsultaParesEnProceso_SoloConsulta(ByVal SesionID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Return objDA.ConsultaParesEnProceso_SoloConsulta(SesionID)
    End Function

    Public Function ProyectarLotesCompletos(ByVal PedidoSICY As Integer, ByVal TomarInventario As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Return objDA.ProyectarLotesCompletos(PedidoSICY, TomarInventario)
    End Function

    Public Function ConsultaClientesBloqueados(ByVal SesionID As Integer, ByVal ModoConsulta As Boolean) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Return objDA.ConsultaClientesBloqueados(SesionID, ModoConsulta)
    End Function

    Public Sub GeneracionDatosProyeccionEntregasCargarSesionAnterior(usuarioId As Integer, usuarioNombre As String, sesionAnterior As Integer)
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        objDA.GeneracionDatosProyeccionEntregasCargarSesionAnterior(usuarioId, usuarioNombre, sesionAnterior)
    End Sub

    Public Sub GeneracionDatosProyeccionEntregasCargarSesionAnterior_SoloConsulta(usuarioId As Integer, usuarioNombre As String, sesionAnterior As Integer)
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        objDA.GeneracionDatosProyeccionEntregasCargarSesionAnterior_SoloConsulta(usuarioId, usuarioNombre, sesionAnterior)
    End Sub

    Public Function ConsultaProyeccionPorNivel_Pedido(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaProyeccionPorNivel_Pedido(consultaNivel)
        Return tabla
    End Function

    Public Function ConsultaProyeccionPorNivel_Pedido_SoloConsulta(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaProyeccionPorNivel_Pedido_SoloConsulta(consultaNivel)
        Return tabla
    End Function

    Public Function ConsultaProyeccionPorNivel_Partida(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaProyeccionPorNivel_Partida(consultaNivel)
        Return tabla
    End Function
    Public Function ConsultaProyeccionPorNivel_Partida_SoloConsulta(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaProyeccionPorNivel_Partida_SoloConsulta(consultaNivel)
        Return tabla
    End Function

    Public Function ConsultaProyeccionPorNivel_PartidaPedido(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaProyeccionPorNivel_PartidaPedido(consultaNivel)
        Return tabla
    End Function

    Public Function ConsultaProyeccionPorNivel_PartidaPedido_SoloConsulta(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaProyeccionPorNivel_PartidaPedido_SoloConsulta(consultaNivel)
        Return tabla
    End Function

    Public Function ConsultaProyeccionPorNivel_Lote(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaProyeccionPorNivel_Lote(consultaNivel)
        Return tabla
    End Function

    Public Function ConsultaProyeccionPorNivel_Lote_SoloConsulta(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaProyeccionPorNivel_Lote_SoloConsulta(consultaNivel)
        Return tabla
    End Function

    Public Function ConsultaProyeccionPorNivel_Atado(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaProyeccionPorNivel_Atado(consultaNivel)
        Return tabla
    End Function

    Public Function ConsultaProyeccionPorNivel_Atado_SoloConsulta(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaProyeccionPorNivel_Atado_SoloConsulta(consultaNivel)
        Return tabla
    End Function

    Public Function ConsultaProyeccionPorNivel_Pares(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaProyeccionPorNivel_Pares(consultaNivel)
        Return tabla
    End Function

    Public Sub GeneracionDatosProyeccionEntregasSinFiltros(colaborador As Integer, usuarioId As Integer, usuarioNombre As String, sesionAnterior As Integer)
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        objDA.GeneracionDatosProyeccionEntregasSinFiltros(colaborador, usuarioId, usuarioNombre, sesionAnterior)
    End Sub

    Public Function consultarSumatoriaAtados(ByVal codigoAtado As String) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Return objDA.consultarSumatoriaAtados(codigoAtado)
    End Function

    Public Function consultarSumatoriaLotes(ByVal Lote As Integer, ByVal Nave As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Return objDA.consultarSumatoriaLotes(Lote, Nave, Año)
    End Function

End Class
