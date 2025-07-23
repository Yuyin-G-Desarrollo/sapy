Imports System.Data.SqlClient

Public Class FolioCancelacionDA
    Private objOperacionesSAY As New Persistencia.OperacionesProcedimientos
    Private objOperacionesSICY As New Persistencia.OperacionesProcedimientosSICY
    Private listaParametros As New List(Of SqlParameter)

    Public Function ConsultarFoliosCancelacion(
        buscarPorFecha As Boolean,
        fechaInicio As DateTime,
        fechaFin As DateTime,
        estatusPedido As String,
        pedidosSay As String,
        pedidosSicy As String,
        clientes As String
    ) As DataTable

        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@buscarPorFecha"
        parametro.Value = buscarPorFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatusPedido"
        parametro.Value = estatusPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidosSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSICY"
        parametro.Value = pedidosSicy
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cliente"
        parametro.Value = clientes
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_FolioCancelacion_Adiministrador_Consultar]", listaParametros)

    End Function

    Public Function ConsultarFoliosDetalle(foliosCancelacion As String) As DataTable

        listaParametros.Clear()
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@foliosCancelacion"
        parametro.Value = foliosCancelacion
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_FolioCancelacion_Adiministrador_ConsultarDetalle]", listaParametros)

    End Function
End Class
