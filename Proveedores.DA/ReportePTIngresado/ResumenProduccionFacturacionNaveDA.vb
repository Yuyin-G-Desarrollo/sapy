Imports System.Data.SqlClient
Public Class ResumenProduccionFacturacionNaveDA

    Public Function MostrarReporte(ByVal semanaInicio As Integer, ByVal anioInicio As Integer, ByVal semanaFin As Integer, anioFin As Integer, ByVal idNaveSay As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@semanaInicio"
        parametro.Value = semanaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@añoInicio"
        parametro.Value = anioInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@semanaFin"
        parametro.Value = semanaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@añoFin"
        parametro.Value = anioFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveIdSay"
        parametro.Value = idNaveSay
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_Consulta_ReporteIngresosFacturables]", listaParametros)

    End Function

End Class
