Imports System.Data.SqlClient
Public Class CatalogosDA
    Public Function consultaDiasNoLaborablesDA(ByVal anio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NF_Catalogos_DiasNoLaborables_Consulta]", listaParametros)
    End Function

    Public Function insertarDiasNoLaborablesFechaDA(ByVal fechaAnterior As Date, ByVal fechaEditada As Date, ByVal descripcion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaAnterior"
        parametro.Value = fechaAnterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaEditada"
        parametro.Value = fechaEditada
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@descripcion"
        parametro.Value = descripcion
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NF_Catalogos_DiasNoLaborables_Guardar]", listaParametros)
    End Function

    Public Function consultaContadordetimbresDA() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("[Contabilidad].[SP_ContadordeTimbres]")


    End Function
End Class
