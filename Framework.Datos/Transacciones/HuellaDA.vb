Imports Persistencia
Imports System.Data.SqlClient

Public Class HuellaDA

    Public Function insertarHuella(ByVal colaborador As Int32, ByVal mano As Int32, ByVal dedo As Int32, ByVal usuario As Int32, ByVal huella As String, ByVal dedoLibreria As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@colaboradorID"
        parametro.Value = colaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@dedo"
        parametro.Value = dedo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@mano"
        parametro.Value = mano
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@user"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@huella"
        parametro.Value = huella
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@dedoLibreria"
        parametro.Value = dedoLibreria
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_insertar_Huellas]", listaParametros)
    End Function

    Public Function buscarHuella(ByVal colaborador As Int32, ByVal mano As String, ByVal dedo As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@colaboradorID"
        parametro.Value = colaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@dedo"
        parametro.Value = dedo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@mano"
        parametro.Value = mano
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_buscar_Huella]", listaParametros)
    End Function

    Public Function BitacoraHuella(ByVal colaborador As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@colaboradorID"
        parametro.Value = colaborador
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_bitacora_Registros_Huellas]", listaParametros)
    End Function

    Public Function listaEmpleados() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Return operaciones.EjecutarConsultaSP("[Nomina].[huellas_nave]", listaParametros)
    End Function

End Class
