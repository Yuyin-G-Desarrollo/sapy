Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class Programacion_Reportes_EvaluacionNaves_DA
    Public Function obtenerDatosEvaluacionNave(ByVal Nave As String, ByVal Año As Integer, ByVal SemanaInicio As Integer,
                                  ByVal SemanaFin As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NavesSeleccionadas"
        parametro.Value = Nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = Año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@SemanaInicio"
        parametro.Value = SemanaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@SemanaFin"
        parametro.Value = SemanaFin
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ReporteEvaluacionNaves_ConsultaReporte]", listaParametros)
    End Function
    Public Function ActualizarReporte(ByVal Nave As Integer, ByVal Año As Integer, ByVal NumSemana As Integer,
                                  ByVal CapacidadPares As Integer, ByVal DiasProcesoIdeal As Double, ByVal ParesCancelados As Integer,
                                  ByVal CalificacionEntregas As Integer, ByVal UsuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@idNave"
        parametro.Value = Nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@año"
        parametro.Value = Año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NumSemana"
        parametro.Value = NumSemana
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CapacidadPares"
        parametro.Value = CapacidadPares
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DiasProcesoIdeal"
        parametro.Value = DiasProcesoIdeal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ParesCancelados"
        parametro.Value = ParesCancelados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CalificacionEntregas"
        parametro.Value = CalificacionEntregas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioModifica"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ReporteEvaluacionNaves_ActualizarDatosSemanaActualYPosteriores]", listaParametros)
    End Function

    Public Function ConsultaDatosNaves() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY

        Return objPersistencia.EjecutaConsulta("exec [Programacion].[SP_ReporteEvaluacionNaves_ConsultaDatosNaves]")

    End Function

    Public Function obtenerDatosEvaluacionNaveImpresionPDF(ByVal Nave As Integer, ByVal Año As Integer, ByVal SemanaInicio As Integer,
                                     ByVal SemanaFin As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Nave"
        parametro.Value = Nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = Año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@SemanaInicio"
        parametro.Value = SemanaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@SemanaFin"
        parametro.Value = SemanaFin
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ReporteEvaluacionNaves_ConsultaReporte_ImpresionPDF]", listaParametros)
    End Function

    Public Function obtenerPromediosEvaluacionNave(ByVal Nave As String, ByVal Año As Integer, ByVal SemanaInicio As Integer,
                                     ByVal SemanaFin As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Nave"
        parametro.Value = Nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = Año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@SemanaInicio"
        parametro.Value = SemanaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@SemanaFin"
        parametro.Value = SemanaFin
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ReporteEvaluacionNaves_ConsultaPromediosReporte]", listaParametros)
    End Function


    Public Function consultarSemanasInhabilesCompletas(ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Año"
        parametro.Value = Año
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ReporteEvaluacionNaves_ConsultaSemanasInhabiles]", listaParametros)
    End Function

    Public Function actualizaTodaslasNaves() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY

        Return objPersistencia.EjecutaConsulta("exec [Programacion].[SP_ReporteEvaluacionNaves_GeneraDatosTodasNavesPantalla]")
    End Function

End Class
