Imports System.Data.SqlClient

Public Class MaterialesPorProgramaDA
    Public Function ObtieneMaterialesPorPrograma(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ObtieneMaterialesPorPrograma]", listaparametros)

    End Function
End Class
