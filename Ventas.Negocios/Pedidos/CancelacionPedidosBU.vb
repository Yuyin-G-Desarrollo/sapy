Public Class CancelacionPedidosBU

    Public Function ConsultaPedidosACancelar(ByVal PedidoSAY As String, ByVal PedidoSICY As String, ByVal ClienteId As String, ByVal TiendaID As String, ByVal AtnClientesID As String, ByVal AgenteID As String, ByVal StatusID As String, ByVal FechaCapturaInicio As Date, ByVal FechaCapturaFin As Date, ByVal FiltroFEchaActivo As Boolean, ByVal TipoFecha As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionPedidosDA
        Return objDA.ConsultaPedidosACancelar(PedidoSAY, PedidoSICY, ClienteId, TiendaID, AtnClientesID, AgenteID, StatusID, FechaCapturaInicio, FechaCapturaFin, FiltroFEchaActivo, TipoFecha)
    End Function

    Public Function ConsultaInformacionPedido(ByVal PedidoSAY As Integer) As Entidades.CancelacionPedidos
        Dim objDA As New Ventas.Datos.CancelacionPedidosDA
        Dim DTInformacionPedido As DataTable
        Dim objEnt As New Entidades.CancelacionPedidos

        DTInformacionPedido = objDA.ConsultaInformacionPedido(PedidoSAY)

        If DTInformacionPedido.Rows.Count > 0 Then
            objEnt.PedidoSAY = DTInformacionPedido.Rows(0).Item("PedidoSAY").ToString()
            objEnt.Cliente = DTInformacionPedido.Rows(0).Item("Cliente").ToString()
            objEnt.Estatus = DTInformacionPedido.Rows(0).Item("Estatus").ToString()

            If IsDBNull(DTInformacionPedido.Rows(0).Item("FechaProgramacion")) = False Then
                objEnt.FechaProgramacion = DTInformacionPedido.Rows(0).Item("FechaProgramacion").ToString()
            Else
                objEnt.FechaProgramacion = Nothing
            End If

            If IsDBNull(DTInformacionPedido.Rows(0).Item("Moneda")) = False Then
                objEnt.Moneda = DTInformacionPedido.Rows(0).Item("Moneda").ToString()
            Else
                objEnt.Moneda = ""
            End If

            If IsDBNull(DTInformacionPedido.Rows(0).Item("PedidoSICY")) = False Then
                objEnt.PedidoSICY = DTInformacionPedido.Rows(0).Item("PedidoSICY").ToString()
            Else
                objEnt.PedidoSICY = ""
            End If

            If IsDBNull(DTInformacionPedido.Rows(0).Item("Agente")) = False Then
                objEnt.Agente = DTInformacionPedido.Rows(0).Item("Agente").ToString()
            Else
                objEnt.Agente = ""
            End If



            If IsDBNull(DTInformacionPedido.Rows(0).Item("ListaPrecioCliente")) = False Then
                objEnt.ListraPrecioCliente = DTInformacionPedido.Rows(0).Item("ListaPrecioCliente").ToString()
            Else
                objEnt.ListraPrecioCliente = ""
            End If

            If IsDBNull(DTInformacionPedido.Rows(0).Item("InicioVigencia")) = False Then
                objEnt.InicioVigencia = DTInformacionPedido.Rows(0).Item("InicioVigencia").ToString()
            Else
                objEnt.InicioVigencia = Nothing
            End If


            If IsDBNull(DTInformacionPedido.Rows(0).Item("FechaCliente")) = False Then
                objEnt.FechaCliente = DTInformacionPedido.Rows(0).Item("FechaCliente").ToString()
            Else
                objEnt.FechaCliente = Nothing
            End If

            If IsDBNull(DTInformacionPedido.Rows(0).Item("OrdenCliente")) = False Then
                objEnt.OrdenCliente = DTInformacionPedido.Rows(0).Item("OrdenCliente").ToString()
            Else
                objEnt.OrdenCliente = ""
            End If

            If IsDBNull(DTInformacionPedido.Rows(0).Item("RFC")) = False Then
                objEnt.RFC = DTInformacionPedido.Rows(0).Item("RFC").ToString()
            Else
                objEnt.RFC = ""
            End If

            If IsDBNull(DTInformacionPedido.Rows(0).Item("RazonSocial")) = False Then
                objEnt.RazonSocial = DTInformacionPedido.Rows(0).Item("RazonSocial").ToString()
            Else
                objEnt.RazonSocial = ""
            End If

            If IsDBNull(DTInformacionPedido.Rows(0).Item("Capturo")) = False Then
                objEnt.Capturo = DTInformacionPedido.Rows(0).Item("Capturo").ToString()
            Else
                objEnt.Capturo = ""
            End If


            If IsDBNull(DTInformacionPedido.Rows(0).Item("Marcas")) = False Then
                objEnt.Marca = DTInformacionPedido.Rows(0).Item("Marcas").ToString()
            Else
                objEnt.Marca = ""
            End If

            If IsDBNull(DTInformacionPedido.Rows(0).Item("NotasApartado")) = False Then
                objEnt.NotasApartado = DTInformacionPedido.Rows(0).Item("NotasApartado").ToString()
            Else
                objEnt.NotasApartado = ""
            End If

            If IsDBNull(DTInformacionPedido.Rows(0).Item("NotasPedido")) = False Then
                objEnt.NotasPedido = DTInformacionPedido.Rows(0).Item("NotasPedido").ToString()
            Else
                objEnt.NotasPedido = ""
            End If

            If IsDBNull(DTInformacionPedido.Rows(0).Item("Observaciones")) = False Then
                objEnt.Observaciones = DTInformacionPedido.Rows(0).Item("Observaciones").ToString()
            Else
                objEnt.Observaciones = ""
            End If

            If IsDBNull(DTInformacionPedido.Rows(0).Item("FechaCaptura")) = False Then
                objEnt.FechaCaptura = DTInformacionPedido.Rows(0).Item("FechaCaptura").ToString()
            Else
                objEnt.FechaCaptura = Nothing
            End If

            If IsDBNull(DTInformacionPedido.Rows(0).Item("Inicial")) = False Then
                objEnt.Inicial = DTInformacionPedido.Rows(0).Item("Inicial").ToString()
            Else
                objEnt.Inicial = ""
            End If

            If IsDBNull(DTInformacionPedido.Rows(0).Item("Ramo")) = False Then
                objEnt.Ramo = DTInformacionPedido.Rows(0).Item("Ramo").ToString()
            Else
                objEnt.Ramo = ""
            End If

            If IsDBNull(DTInformacionPedido.Rows(0).Item("Vigencia")) = False Then
                objEnt.Vigencia = DTInformacionPedido.Rows(0).Item("Vigencia").ToString()
            Else
                objEnt.Vigencia = Nothing
            End If

            If IsDBNull(DTInformacionPedido.Rows(0).Item("RestriccionFacturacion")) = False Then
                objEnt.RestriccionFacturacion = DTInformacionPedido.Rows(0).Item("RestriccionFacturacion").ToString()
            Else
                objEnt.RestriccionFacturacion = ""
            End If

            If IsDBNull(DTInformacionPedido.Rows(0).Item("TipoApartado")) = False Then
                objEnt.TipoApartado = DTInformacionPedido.Rows(0).Item("TipoApartado").ToString()
            Else
                objEnt.TipoApartado = ""
            End If

        End If

        Return objEnt

    End Function

    Public Function ConsultarPartidasPedido(ByVal PedidoSAY As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionPedidosDA
        Return objDA.ConsultarPartidasPedido(PedidoSAY)
    End Function

    Public Function CancelarPartidas(ByVal PedidoSAY As Integer, ByVal Partida As String, ByVal UsuarioCapturo As Integer, ByVal ObservacionesCancelacion As String, ByVal MotivoCancelacionID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionPedidosDA
        Return objDA.CancelarPartidas(PedidoSAY, Partida, UsuarioCapturo, ObservacionesCancelacion, MotivoCancelacionID)
    End Function

    Public Function CancelarPedido(ByVal PedidoSAY As Integer, ByVal UsuarioCapturo As Integer, ByVal ObservacionesCancelacion As String, ByVal MotivoCancelacionID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionPedidosDA
        Return objDA.CancelarPedido(PedidoSAY, UsuarioCapturo, ObservacionesCancelacion, MotivoCancelacionID)
    End Function

    Public Function CatalogoMotivosCancelacion() As DataTable
        Dim objDA As New Ventas.Datos.CancelacionPedidosDA
        Return objDA.CatalogoMotivosCancelacion()
    End Function

    Public Function ActualizarEstatusEncabezado(ByVal PedidoSAYID As Integer, ByVal UsuarioId As Integer, ByVal ObservacionesCancelacion As String, ByVal MotivoCancelacionID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionPedidosDA
        Return objDA.ActualizarEstatusEncabezado(PedidoSAYID, UsuarioId, ObservacionesCancelacion, MotivoCancelacionID)
    End Function

    Public Function ReversaCancelacionPedidos(ByVal OTSAY As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionPedidosDA
        Return objDA.ReversaCancelacionPedidos(OTSAY)
    End Function

End Class
