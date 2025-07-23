Imports System.Data.SqlClient
Imports Persistencia

Public Class DatosSPEMensualDA
    Public Function consultaListaMeses() As DataTable
        Dim operacion As New OperacionesProcedimientos
        Return operacion.EjecutaConsulta("EXEC [Framework].[SP_ListaMesesAnio]")
    End Function

    Public Function consultarDatos(ByVal patronId As Integer, ByVal anio As Integer, ByVal mes As Integer, ByVal nombre As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@patron"
        parametro.Value = patronId
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@mes"
        parametro.Value = mes
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@nombre"
        parametro.Value = nombre
        ListaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_NFDatosSPEMensual_Consultar]", ListaParametros)
    End Function

    Public Function importarDatos(ByVal datos As Entidades.DatosSPEMensual) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@PatronId"
        parametro.Value = datos.PPatronId
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@Anio"
        parametro.Value = datos.PAnio
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@Mes"
        parametro.Value = datos.PMes
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@RFC"
        parametro.Value = datos.PRFC
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@ExentoCargado"
        parametro.Value = datos.PExentoCargado
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@GravadoCargado"
        parametro.Value = datos.PGravadoCargado
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@ISRCargado"
        parametro.Value = datos.PISRCargado
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_NFDatosSPEMensual_ImportarActualizar]", ListaParametros)
    End Function

    Public Function validarEstatusAutorizado(ByVal patronId As Integer, ByVal anio As Integer, ByVal mes As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@PatronId"
        parametro.Value = patronId
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@Anio"
        parametro.Value = anio
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@Mes"
        parametro.Value = mes
        ListaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_NFDatosSPEMensual_ObtieneRegistrosAutorizados]", ListaParametros)
    End Function

    Public Function autorizarDatos(ByVal patronId As Integer, ByVal anio As Integer, ByVal mes As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@PatronId"
        parametro.Value = patronId
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@Anio"
        parametro.Value = anio
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@Mes"
        parametro.Value = mes
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_NFDatosSPEMensual_Autorizar]", ListaParametros)
    End Function

    Public Function obtieneEncabezadoReporte(ByVal patronId As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@PatronId"
        parametro.Value = patronId
        ListaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_NFDatosSPEMensual_EncabezadoReporte]", ListaParametros)
    End Function

End Class
