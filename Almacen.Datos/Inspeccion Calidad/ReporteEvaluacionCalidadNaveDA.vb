Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports Entidades
Public Class ReporteEvaluacionCalidadNaveDA

    Public Function ConsultaReporteSemanaNave(ByVal NaveSICYID As Integer, ByVal NumeroSemana As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveActualizar"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoActualizar"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SemanaActualizar"
            parametro.Value = NumeroSemana
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_InspeccionCalidad_ReporteEvaluacionNave]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaNaves() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_InspeccionCalidad_ReporteEvaluacionNave_ConsultaNaves]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ReporteInsertarInformacionSemanalNave(ByVal NaveSicyId As Integer, ByVal Año As Integer, ByVal NumeroSemana As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveActualizar"
            parametro.Value = NaveSicyId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoActualizar"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SemanaActualizar"
            parametro.Value = NumeroSemana
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_InspeccionCalidad_Reporte_InsertarInformacionSemanaActual_v2]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ReporteConsultaEvaluacionSemanal(ByVal NaveSicyId As Integer, ByVal Año As Integer, ByVal NumeroSemanaInicial As Integer, ByVal NumeroSemanaFinal As Integer, ByVal ConsultarTop5PorRango As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveActualizar"
            parametro.Value = NaveSicyId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoActualizar"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SemanaInicial"
            parametro.Value = NumeroSemanaInicial
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SemanaFinal"
            parametro.Value = NumeroSemanaFinal
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ConsultarPorRangoTop"
            parametro.Value = ConsultarTop5PorRango
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_InspeccionCalidad_Reporte_ConsultarEvaluacionSemanal]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ReporteValidarExisteSemanaNave(ByVal NaveSicyId As Integer, ByVal Año As Integer, ByVal NumeroSemana As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveActualizar"
            parametro.Value = NaveSicyId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoActualizar"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SemanaActual"
            parametro.Value = NumeroSemana
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_InspeccionCalidad_Reporte_ValidarExisteEvaluacionSemanaNave]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ReporteActualizarEvaluacionSemanaNave(ByVal NaveSicyId As Integer, ByVal Año As Integer, ByVal NumeroSemana As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveActualizar"
            parametro.Value = NaveSicyId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoActualizar"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SemanaActualizar"
            parametro.Value = NumeroSemana
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_InspeccionCalidad_Reporte_ActualizarInformacionSemanaActual]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function ReporteActualizarNumeroQuejas(ByVal NaveSicyId As Integer, ByVal Año As Integer, ByVal NumeroSemana As Integer, ByVal NumeroQuejas As Integer, ByVal AlmacenID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveActualizar"
            parametro.Value = NaveSicyId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoActualizar"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SemanaActualizar"
            parametro.Value = NumeroSemana
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NumeroQuejas"
            parametro.Value = NumeroQuejas
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Almacenid"
            parametro.Value = AlmacenID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_InspeccionCalidad_ReporteEvaluacionNave_ActualizarQuejas]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function ReporteEvaluacionTop5(ByVal Año As Integer, ByVal SemanaInicial As Integer, ByVal SemanaFinal As Integer, ByVal ConsultarTop5PorRango As Boolean, ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@AñoActualizar"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SemanaInicial"
            parametro.Value = SemanaInicial
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SemanaFinal"
            parametro.Value = SemanaFinal
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ConsultarPorRangoTop"
            parametro.Value = ConsultarTop5PorRango
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_InspeccionCalidad_Reporte_ObtenerTop5Incidencias]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function ReporteInsertarInformacionSemanalNave_AlmacenZ(ByVal NaveSicyId As Integer, ByVal Año As Integer, ByVal NumeroSemana As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveActualizar"
            parametro.Value = NaveSicyId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoActualizar"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SemanaActualizar"
            parametro.Value = NumeroSemana
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_InspeccionCalidad_Reporte_InsertarInformacionSemanaActual]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ReporteConsultaEvaluacionSemanal_AlmacenZ(ByVal NaveSicyId As Integer, ByVal Año As Integer, ByVal NumeroSemanaInicial As Integer, ByVal NumeroSemanaFinal As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveActualizar"
            parametro.Value = NaveSicyId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoActualizar"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SemanaInicial"
            parametro.Value = NumeroSemanaInicial
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SemanaFinal"
            parametro.Value = NumeroSemanaFinal
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_InspeccionCalidad_Reporte_ConsultarEvaluacionSemanal_Almacen_z]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ReporteValidarExisteSemanaNave_AlmacenZ(ByVal NaveSicyId As Integer, ByVal Año As Integer, ByVal NumeroSemana As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveActualizar"
            parametro.Value = NaveSicyId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoActualizar"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SemanaActual"
            parametro.Value = NumeroSemana
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_InspeccionCalidad_Reporte_ValidarExisteEvaluacionSemanaNave_AlmacenZ]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ReporteActualizarEvaluacionSemanaNave_AlmacenZ(ByVal NaveSicyId As Integer, ByVal Año As Integer, ByVal NumeroSemana As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveActualizar"
            parametro.Value = NaveSicyId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoActualizar"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SemanaActualizar"
            parametro.Value = NumeroSemana
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_InspeccionCalidad_Reporte_ActualizarInformacionSemanaActual_Almacen_Z]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try


    End Function


    Public Function ReporteEvaluacionTop5_AlmacenZ(ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@AñoActualizar"
            parametro.Value = Año
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_InspeccionCalidad_Reporte_ObtenerTop5Incidencias_Almacen_z]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function ConsultaDetallesEvaluacionCalidad(ByVal NaveSicyId As Integer, ByVal Año As Integer, ByVal NumeroSemana As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveActualizar"
            parametro.Value = NaveSicyId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoActualizar"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SemanaActualizar"
            parametro.Value = NumeroSemana
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_InspeccionCalidad_Reporte_DetallesCalificacion]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try


    End Function


    Public Function ReporteConsultaEvaluacionSemanal_2018(ByVal NaveSicyId As Integer, ByVal Año As Integer, ByVal NumeroSemanaInicial As Integer, ByVal NumeroSemanaFinal As Integer, ByVal ConsultarTop5PorRango As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveActualizar"
            parametro.Value = NaveSicyId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoActualizar"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SemanaInicial"
            parametro.Value = NumeroSemanaInicial
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SemanaFinal"
            parametro.Value = NumeroSemanaFinal
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ConsultarPorRangoTop"
            parametro.Value = ConsultarTop5PorRango
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_InspeccionCalidad_Reporte_ConsultarEvaluacionSemanal_2018]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GenerarInformaciónAlertarCalidadSemana(ByVal Año As Integer, ByVal Semana As Integer, ByVal Fecha As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@Semana"
            parametro.Value = Semana
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Año"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Fecha"
            parametro.Value = Fecha
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ReporteEvaluacionCalidad_InsertarAlertasCalidad]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ConsultaInformaciónAlertasCalidadSemana(ByVal Año As Integer, ByVal Semana As Integer, ByVal Grupo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@Semana"
            parametro.Value = Semana
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Año"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Grupo"
            parametro.Value = Grupo
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ReporteEvaluacionCalidad_ConsultaAlertasCalidad]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaCriteriosEvaluacion(ByVal Nave As Integer, ByVal criterios As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@NaveID",
            .Value = Nave
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Criterios",
            .Value = criterios
        })

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ReporteEvaluacionCalidad_ConsultaCriteriosEvaluacion]", listaParametros)
    End Function

    Public Function RegistrarCriterioEvaluacion(ByVal NaveID As Int16, ByVal Criterio As String, ByVal ValorInicial As Int32, ByVal ValorFinal As Int32, ByVal Puntos As Int32, ByVal Usuario As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@NaveID",
            .Value = NaveID
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Criterio",
            .Value = Criterio
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@ValorInicial",
            .Value = ValorInicial
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@ValorFinal",
            .Value = ValorFinal
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Puntos",
            .Value = Puntos
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Usuario",
            .Value = Usuario
        })

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ReporteEvaluacionCalidad_RegistrarCriteriosEvaluacion]", listaParametros)
    End Function

    Public Sub EliminarCriterioEvaluacion(ByVal CriterioID As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@CriterioID",
            .Value = CriterioID
        })

        operaciones.EjecutarSentenciaSP("[Programacion].[SP_ReporteEvaluacionCalidad_EliminarCriteriosEvaluacion]", listaParametros)
    End Sub

    Public Sub ModificarPuntajeCriterios(ByVal criterios As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Criterios",
            .Value = criterios
        })

        operaciones.EjecutarSentenciaSP("[Programacion].[SP_ReporteEvaluacionCalidad_AdministrarCriteriosEvaluacion]", listaParametros)
    End Sub

    Public Function ConsultarDiasLaboralesSemana(ByVal Año As Integer, ByVal Semana As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@Semana"
            parametro.Value = Semana
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Año"
            parametro.Value = Año
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_SemanasLaborales_DiasSemana]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerNumeroSemana(ByVal Año As Integer, ByVal Fecha As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@Año"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Fecha"
            parametro.Value = Fecha
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ReporteEvaluacionCalidad_ObtenerNumeroSemana]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try

    End Function



End Class
