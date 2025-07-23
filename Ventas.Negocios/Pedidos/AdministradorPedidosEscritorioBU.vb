Public Class AdministradorPedidosEscritorioBU

    Private objDA As Datos.AdministradorPedidosEscritorioDA

    Public Function ConsultarPedidos(objFiltros As Entidades.FiltroAdministradorPedido, leerAsignados As Boolean) As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA

        dt = objDA.ConsultarPedidos(objFiltros, leerAsignados)
        Return dt
    End Function

    Public Function ConsultarPedidoDetalle(pedidoid As Integer) As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA

        dt = objDA.ConsultarPedidoDetalle(pedidoid)

        Return dt
    End Function

    Public Function ConsultarPedidoEncabezado(pedidoId As Integer) As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA

        dt = objDA.ConsultarPedidoEncabezado(pedidoId)

        Return dt
    End Function

    Public Function ConsultarInformacionTallas(pedidoid As Integer, partidas As String) As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA

        dt = objDA.ConsultarInformacionTallas(pedidoid, partidas)

        If dt.Rows.Count = 0 Then
            dt.Columns.Add(" ")
            Dim row = dt.NewRow
            row(" ") = "No hay datos para mostrar"
            dt.Rows.Add(row)
        End If

        Return dt
    End Function

    Public Function Administrador_DatosInicialesPermisos() As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA

        dt = objDA.Administrador_DatosInicialesPermisos()
        Return dt
    End Function

    Public Function Consultar_InformacionLotes(pedidoSICY As Integer, partidas As String) As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA

        dt = objDA.Consultar_InformacionLotes(pedidoSICY, partidas)
        Return dt
    End Function

    Public Function Consultar_InformacionOT(pedidoSAY As Integer, partida As String) As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA

        dt = objDA.Consultar_InformacionOT(pedidoSAY, partida)
        Return dt
    End Function

    Public Function Consultar_InformacionFactura(pedidoSAY As Integer, partida As String) As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA

        dt = objDA.Consultar_InformacionFactura(pedidoSAY, partida)
        Return dt
    End Function

    Public Function ConsultarMotivosCancelacion() As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA

        dt = objDA.ConsultarMotivosCancelacion()

        Return dt
    End Function

    Public Function ConsultarSumatoriaParesACancelar(pedidoSAY As Integer, partidas As String) As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA

        dt = objDA.ConsultarSumatoriaParesACancelar(pedidoSAY, partidas)

        Return dt
    End Function

    Public Function ValidarPartidas(pedidoSAY As Integer, partidas As String) As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA

        dt = objDA.ValidarPartidas(pedidoSAY, partidas)

        If Not Boolean.Parse(dt.Rows(0).Item("validado").ToString) Then
            Throw New Exception(dt.Rows(0).Item("mensaje").ToString)
        End If

        Return dt
    End Function

    Public Function ValidarPartidasEnApartadosDesdePedidos(listPedidos As List(Of Integer)) As DataTable
        Dim dt As DataTable
        Dim pedidos As String = String.Empty

        objDA = New Datos.AdministradorPedidosEscritorioDA

        For index = 0 To listPedidos.Count - 1
            If index = 0 Then
                pedidos += " " + Replace(listPedidos(index).ToString, ",", "")
            Else
                pedidos += ", " + Replace(listPedidos(index).ToString, ",", "")
            End If
        Next

        dt = objDA.ValidarPartidasEnApartadosDesdePedidos(pedidos)

        If Not Boolean.Parse(dt.Rows(0).Item("validado").ToString) Then
            Throw New Exception(dt.Rows(0).Item("mensaje").ToString)
        End If

        Return dt
    End Function

    Public Sub EliminarPartidasAbiertas(pedidoSAY As Integer, partidas As String)
        objDA = New Datos.AdministradorPedidosEscritorioDA
        objDA.EliminarPartidasAbiertas(pedidoSAY, partidas)

    End Sub

    Public Function CancelarPartidas(pedidoSAY As Integer, partidas As String, solicita As String, motivoCancelacionId As Integer, observacionesCancelacion As String) As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA

        objDA.CancelarPartidas(pedidoSAY, partidas, solicita, motivoCancelacionId, observacionesCancelacion)
        objDA.ActualizarEstatusPedidoSICY(pedidoSAY)
        objDA.CancelarApartadosSICY(pedidoSAY)
        ' objDA.ActualizarParesOTs()
        objDA.ACtualizaParesOTSICY(pedidoSAY)
        dt = objDA.CancelarLotesNoProgramadosPartidas(pedidoSAY, partidas, observacionesCancelacion)

        Return dt
    End Function

    Public Function ObtenerPartidasDelPedido(pedidoSAY As Integer) As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA

        dt = objDA.ObtenerPartidasDelPedido(pedidoSAY)

        Return dt
    End Function

    Public Function ConsultarArticulosLotesCancelados(pedidoSAY As Integer, partidas As String) As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA

        dt = objDA.ConsultarArticulosLotesCancelados(pedidoSAY, partidas)

        If dt.Rows.Count = 0 Then
            Throw New Exception("No se recupero información de artículos cancelados.")
        End If

        Return dt
    End Function

    Public Function DescartarPedido(pedidoSAY As Integer) As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA

        dt = objDA.DescartarPedido(pedidoSAY)

        Return dt
    End Function

    Public Sub ACtualizaParesOTSICY(pedidoSAYId As Integer)
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA

        objDA.ACtualizaParesOTSICY(pedidoSAYId)


    End Sub

    Public Function ObtenerResultadoCancelacion(pedidoSAYId As String) As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA
        Return objDA.ObtenerResultadoCancelacion(pedidoSAYId)

    End Function

    Public Function LimpiarSessionPedido(pedidoSAYId As String) As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA
        Return objDA.LimpiarSessionPedido(pedidoSAYId)
    End Function

    Public Function ActualizarEstatusPedidoSICY(pedidoSAYId As Integer) As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA
        Return objDA.ActualizarEstatusPedidoSICY(pedidoSAYId)
    End Function

    Public Function CancelarPedidos(pedidoSAY As Integer, solicita As String, motivoCancelacionId As Integer, observacionesCancelacion As String) As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA
        objDA.CancelarPedidos(pedidoSAY, solicita, motivoCancelacionId, observacionesCancelacion)
        objDA.ActualizarEstatusPedidoSICY(pedidoSAY)
        objDA.CancelarApartadosSICY(pedidoSAY)

        ' objDA.ActualizarParesOTs()
        objDA.ACtualizaParesOTSICY(pedidoSAY)

        dt = objDA.CancelarLotesNoProgramadosPedidos(pedidoSAY, observacionesCancelacion)

        Return dt
    End Function

    Public Function ValidarPedidoEnPlanFabricacion_EstatusEnviadoPPCP(ByVal pedidos As String) As DataTable
        Dim dt As DataTable
        objDA = New Datos.AdministradorPedidosEscritorioDA

        dt = objDA.ValidarPedidoEnPlanFabricacion_EstatusEnviadoPPCP(pedidos)

        Return dt
    End Function
End Class
