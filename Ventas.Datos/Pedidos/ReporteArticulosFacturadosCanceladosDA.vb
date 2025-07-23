Imports System.Data.SqlClient

Public Class ReporteArticulosFacturadosCanceladosDA
    Private objOperacionesSAY As New Persistencia.OperacionesProcedimientos
    Private objOperacionesSICY As New Persistencia.OperacionesProcedimientosSICY
    Private listaParametros As New List(Of SqlParameter)

    Public Function ConsultarArticulosFacturadosCancelados(
        buscarPorFecha As Boolean,
        fechaInicio As Date,
        fechaFin As Date,
        pedidoSAY As String,
        pedidoSICY As String,
        cliente As String,
        rFC As String,
        nave As String
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
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSICY"
        parametro.Value = pedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cliente"
        parametro.Value = cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@rFC"
        parametro.Value = rFC
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@nave"
        parametro.Value = nave
        listaParametros.Add(parametro)

        Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_ReporteArticulosFacturadosCancelados_Consultar]", listaParametros)

    End Function
End Class
