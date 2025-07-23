Imports System.Data.SqlClient

Public Class ModificacionPrecioFacturacionDA

    Public Function datosInicio() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Return operacion.EjecutarConsultaSP("[Almacen].[SP_ConsultaOpcionFacturacionCalzado]", ListaParametros)
    End Function

    Public Function guardarCambios(otorgarDenegar As Boolean, usuarioModificaId As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@otorgarDenegar"
        parametro.Value = otorgarDenegar
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        parametro.ParameterName = "@usuarioModificaId"
        parametro.Value = usuarioModificaId
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_ActualizaOpcionFacturacionCalzado]", listaparametros)
    End Function

End Class
