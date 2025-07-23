Imports System.Data.SqlClient
Imports Persistencia

Public Class PeriodosNominaFiscalDA
    Public Function verificarPeriodo(ByVal patronId As Integer, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal periodoId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "PatronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicial"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFinal"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PeriodoId"
        parametro.Value = periodoId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFPeriodos_VerificarExiste", listaParametros)
    End Function

    Public Function consultarPeriodos(ByVal patronId As Integer, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal estatus As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "PatronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicial"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFinal"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Estatus"
        parametro.Value = estatus
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFPeriodos_ConsultarPeriodos", listaParametros)
    End Function

    Public Function obtenerListaEstatus() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "exec Contabilidad.SP_NFPeriodos_ObtenerListaEstatus"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function calcularPeriodos(ByVal patronId As Integer, ByVal semana As Integer, ByVal fechaIni As Date, ByVal fechaFin As Date, ByVal fechaPago As Date, ByVal todos As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "PatronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SemanaInicial"
        parametro.Value = semana
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicial"
        parametro.Value = fechaIni
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFinal"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaPago"
        parametro.Value = fechaPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Todos"
        parametro.Value = todos
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFPeriodos_CalcularPeriodos", listaParametros)
    End Function

    Public Function AltaEdicionPeriodo(ByVal periodo As Entidades.PeriodoNominaFiscal) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "periodoId"
        parametro.Value = periodo.PIdPeriodo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = periodo.PIdPatron
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaIni"
        parametro.Value = periodo.PFechaIni
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaFin"
        parametro.Value = periodo.PFechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "semana"
        parametro.Value = periodo.PNumSemana
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaPago"
        parametro.Value = periodo.PFechaPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "bimestre"
        parametro.Value = periodo.PBimestre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "retardos"
        parametro.Value = periodo.PRetardos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "faltas"
        parametro.Value = periodo.PFaltas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "faltasSemana"
        parametro.Value = periodo.PFAltasSem
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DiasNomina"
        parametro.Value = periodo.PDiasNomina
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_NFPeriodos_AltaEdicionPeriodo]", listaParametros)

    End Function

    Public Function EliminarPeriodo(ByVal periodoId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "periodoId"
        parametro.Value = periodoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFPeriodos_EliminarPeriodo", listaParametros)
    End Function

    Public Function consultarPeriodoEditar(ByVal periodoId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "periodoId"
        parametro.Value = periodoId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFPeriodos_ConsultarPeriodoEditar", listaParametros)
    End Function

    Public Function validaEstatusPeriodo(ByVal periodoId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "PeriodoId"
        parametro.Value = periodoId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFPeriodos_ValidaEstatusEditar", listaParametros)
    End Function

End Class
