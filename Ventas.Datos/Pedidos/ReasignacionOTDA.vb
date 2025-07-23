Imports System.Data.SqlClient

Public Class ReasignacionOTDA
    Private objOperacionesSAY As New Persistencia.OperacionesProcedimientos
    Private objOperacionesSICY As New Persistencia.OperacionesProcedimientosSICY
    Private listaParametros As New List(Of SqlParameter)

    Public Function ValidarReasignacionPedido(ordenTrabajo As Integer) As DataTable

        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@ordenTrabajo"
        parametro.Value = ordenTrabajo
        listaParametros.Add(parametro)


        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Cancelacion_ValidarReasignacionPedido]", listaParametros)

    End Function

    Public Function ActualizarReasignacionPedido(ordenTrabajo As Integer, pedidoSAY As Integer) As DataTable

        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@ordenTrabajo"
        parametro.Value = ordenTrabajo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoSAY
        listaParametros.Add(parametro)


        Return objOperacionesSICY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Cancelacion_ActualizarReasignacionPedido]", listaParametros)

    End Function

    Public Function ValidarEstatusCancelacionOTDesasignacion(ordenTrabajo As String) As DataTable

        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@ordenTrabajo"
        parametro.Value = ordenTrabajo
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_ReversaOTDesasignacion_ValidarOT]", listaParametros)

    End Function

    Public Function CancelarOrdenTrabajoDesasignacion(ordenTrabajo As Integer, partidas As String) As DataTable

        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@ordenTrabajoId"
        parametro.Value = ordenTrabajo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@partidas"
        parametro.Value = partidas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Cancelacion_OrdenTrabajo_Cancelar]", listaParametros)

    End Function


    Public Function CancelacionOTDesasignacionActualizarPedidos(ordenTrabajo As Integer, partidas As String) As DataTable

        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@ordenTrabajo"
        parametro.Value = ordenTrabajo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@partidas"
        parametro.Value = partidas
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_ReversaOTDesasignacion_ActualizarInformacionPedidos]", listaParametros)

    End Function

    Public Function CancelarOrdenTrabajoDesasignacionSICY(ordenTrabajo As Integer, partidas As String) As DataTable

        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@OTID"
        parametro.Value = ordenTrabajo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Partidas"
        parametro.Value = partidas
        listaParametros.Add(parametro)



        Return objOperacionesSICY.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_DesasignarPares]", listaParametros)

    End Function
End Class
