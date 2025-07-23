Imports System.Data.SqlClient

Public Class CancelacionPedidosDA

    Public Function ConsultaPedidosACancelar(ByVal PedidoSAY As String, ByVal PedidoSICY As String, ByVal ClienteId As String, ByVal TiendaID As String, ByVal AtnClientesID As String, ByVal AgenteID As String, ByVal StatusID As String, ByVal FechaCapturaInicio As Date, ByVal FechaCapturaFin As Date, ByVal FiltroFechaActivo As Boolean, ByVal TipoFecha As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "PedidoSAY"
        parametro.Value = PedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSICY"
        parametro.Value = PedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClienteID"
        parametro.Value = ClienteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AtnClientes"
        parametro.Value = AtnClientesID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Agente"
        parametro.Value = AgenteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Status"
        parametro.Value = StatusID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaCapturaInicio"
        parametro.Value = FechaCapturaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaCapturaFin"
        parametro.Value = FechaCapturaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FiltroFechaActivo"
        parametro.Value = FiltroFechaActivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoFecha"
        parametro.Value = TipoFecha
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Pedidos_ConsultaPedidosACancelar]", listaParametros)

    End Function


    Public Function ConsultaInformacionPedido(ByVal PedidoSAY As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "PedidoSAYID"
        parametro.Value = PedidoSAY
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_CancelacionPedido_ConsultaInformacion]", listaParametros)

    End Function


    Public Function ConsultarPartidasPedido(ByVal PedidoSAY As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "PedidoSAYID"
        parametro.Value = PedidoSAY
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_CancelacionPedidos_ConsultarPartidasPedido]", listaParametros)

    End Function

    Public Function CancelarPartidas(ByVal PedidoSAY As Integer, ByVal Partida As String, ByVal UsuarioCapturo As Integer, ByVal ObservacionesCancelacion As String, ByVal MotivoCancelacionID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "PedidoSAYID"
        parametro.Value = PedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Partida"
        parametro.Value = Partida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCapturo"
        parametro.Value = UsuarioCapturo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ObservacionesCancelacion"
        parametro.Value = ObservacionesCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MotivoCancelacionID"
        parametro.Value = MotivoCancelacionID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_CancelacionPedidos_CancelarPartidas]", listaParametros)

    End Function


    Public Function CancelarPedido(ByVal PedidoSAY As Integer, ByVal UsuarioCapturo As Integer, ByVal ObservacionesCancelacion As String, ByVal MotivoCancelacionID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "PedidoSAYID"
        parametro.Value = PedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCapturo"
        parametro.Value = UsuarioCapturo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ObservacionesCancelacion"
        parametro.Value = ObservacionesCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MotivoCancelacionID"
        parametro.Value = MotivoCancelacionID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_CancelacionPedidos_CancelarPedido]", listaParametros)

    End Function

    Public Function CatalogoMotivosCancelacion() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
    
        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_CancelacionPedidos_CatalogoMotivosCancelacion]", listaParametros)

    End Function

    Public Function ActualizarEstatusEncabezado(ByVal PedidoSAYID As Integer, ByVal UsuarioId As Integer, ByVal ObservacionesCancelacion As String, ByVal MotivoCancelacionID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "PedidoSAYID"
        parametro.Value = PedidoSAYID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCanceloID"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ObservacionesCancelacion"
        parametro.Value = ObservacionesCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MotivoCancelacionID"
        parametro.Value = MotivoCancelacionID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_CancelacionPedidos_ActualizarStatus]", listaParametros)

    End Function



    Public Function ReversaCancelacionPedidos(ByVal OTSAY As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "OTSAY"
        parametro.Value = OTSAY
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_CancelacionPedidos_ReversaCancelacion]", listaParametros)

    End Function
    

    
End Class
