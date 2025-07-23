Imports System.Data.SqlClient

Public Class MaterialesPorArticuloDA

    Public Function ObtieneMaterialesPorArticulo(ByVal NavesDesarrollo As String, NavesProduccion As String, ByVal Proveedor As String, ByVal TipoMaterial As String, ByVal Marca As String, ByVal Coleccion As String, ByVal Modelo As String, ByVal PielColor As String, ByVal Corrida As String, ByVal Estatus As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NaveDesarrollo"
        parametro.Value = NavesDesarrollo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@NaveProduccion"
        parametro.Value = NavesProduccion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = Proveedor
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@TipoMaterial"
        parametro.Value = TipoMaterial
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Marca"
        parametro.Value = Marca
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = Coleccion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = Modelo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = PielColor
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = Corrida
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Estatus"
        parametro.Value = Estatus
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Materiales].[SP_ObtieneMaterialesPorArticulo_V1]", listaparametros)

    End Function

End Class
