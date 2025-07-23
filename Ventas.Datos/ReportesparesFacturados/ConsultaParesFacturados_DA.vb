Imports System.Data.SqlClient
Public Class ConsultaParesFacturados_DA
    Public Function obtenerParesApartadosFacturados(fechaInicio As String, fechaFin As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaDeParametros As New List(Of SqlParameter)

        Dim parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = fechaInicio
        listaDeParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = fechaFin
        listaDeParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_ReporteParesApartadosFacturados]", listaDeParametros)

    End Function
End Class
