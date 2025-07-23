Imports System.Data.SqlClient

Public Class ConsultaComprasMaquila_DA
    Public Function ObtenieneComprasPorMaquila(anio As Integer, semanaInicio As Integer, semanaFin As Integer, naves As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro = New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = anio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@semanaInicio"
        parametro.Value = semanaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@semanaFin"
        parametro.Value = semanaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naves"
        parametro.Value = naves
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Proveedor].[SP_CostosMaquilas_ConsultaReporteCostos]", listaparametros)

    End Function

    Public Function ConsultasNavesFiltro(naves As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSAYPruebas
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro = New SqlParameter
        parametro.ParameterName = 1
        parametro.Value = naves
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Proveedor].[SP_Proveedores_ConsultaNavesFiltro]", listaparametros)

    End Function

End Class
