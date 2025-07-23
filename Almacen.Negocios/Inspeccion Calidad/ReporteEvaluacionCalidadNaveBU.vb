

Public Class ReporteEvaluacionCalidadNaveBU

    Public Function ConsultaReporteSemanaNave(ByVal NaveSICYID As Integer, ByVal NumeroSemana As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New Datos.ReporteEvaluacionCalidadNaveDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultaReporteSemanaNave(NaveSICYID, NumeroSemana, Año)
            Return tabla

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaNaves() As DataTable
        Dim objDA As New Datos.ReporteEvaluacionCalidadNaveDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultaNaves()
            Return tabla

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteInsertarInformacionSemanalNave(ByVal NaveSicyId As Integer, ByVal Año As Integer, ByVal NumeroSemana As Integer, ByVal AlmacenID As Integer) As DataTable
        Dim objDA As New Datos.ReporteEvaluacionCalidadNaveDA
        Dim tabla As New DataTable
        Try
            If AlmacenID = 1 Then
                tabla = objDA.ReporteInsertarInformacionSemanalNave(NaveSicyId, Año, NumeroSemana)
            ElseIf AlmacenID = 2 Then
                tabla = objDA.ReporteInsertarInformacionSemanalNave_AlmacenZ(NaveSicyId, Año, NumeroSemana)
            End If

            Return tabla

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteConsultaEvaluacionSemanal(ByVal NaveSicyId As Integer, ByVal Año As Integer, ByVal NumeroSemanaInicial As Integer, ByVal NumeroSemanaFinal As Integer, ByVal AlmacenID As Integer, ByVal ConsultarTop5PorRango As Boolean) As DataTable
        Dim objDA As New Datos.ReporteEvaluacionCalidadNaveDA
        Dim tabla As New DataTable
        Try
            If AlmacenID = 1 Then
                tabla = objDA.ReporteConsultaEvaluacionSemanal(NaveSicyId, Año, NumeroSemanaInicial, NumeroSemanaFinal, ConsultarTop5PorRango)
            ElseIf AlmacenID = 2 Then
                tabla = objDA.ReporteConsultaEvaluacionSemanal_AlmacenZ(NaveSicyId, Año, NumeroSemanaInicial, NumeroSemanaFinal)
            End If

            Return tabla

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteValidarExisteSemanaNave(ByVal NaveSicyId As Integer, ByVal Año As Integer, ByVal NumeroSemana As Integer, ByVal AlmacenID As Integer) As Boolean
        Dim objDA As New Datos.ReporteEvaluacionCalidadNaveDA
        Dim tabla As New DataTable
        Dim Resultado As Boolean = False
        Try
            If AlmacenID = 1 Then
                tabla = objDA.ReporteValidarExisteSemanaNave(NaveSicyId, Año, NumeroSemana)
            ElseIf AlmacenID = 2 Then
                tabla = objDA.ReporteValidarExisteSemanaNave_AlmacenZ(NaveSicyId, Año, NumeroSemana)
            End If

            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    If tabla.Rows(0).Item(0) > 0 Then
                        Resultado = True
                    Else
                        Resultado = False
                    End If
                Else
                    Resultado = False
                End If
            Else
                Resultado = False
            End If

            Return Resultado

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteActualizarEvaluacionSemanaNave(ByVal NaveSicyId As Integer, ByVal Año As Integer, ByVal NumeroSemana As Integer, ByVal AlmacenID As Integer) As DataTable
        Dim objDA As New Datos.ReporteEvaluacionCalidadNaveDA
        Dim tabla As New DataTable
        Try
            If AlmacenID = 1 Then
                tabla = objDA.ReporteActualizarEvaluacionSemanaNave(NaveSicyId, Año, NumeroSemana)
            ElseIf AlmacenID = 2 Then
                tabla = objDA.ReporteActualizarEvaluacionSemanaNave_AlmacenZ(NaveSicyId, Año, NumeroSemana)
            End If

            Return tabla

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteActualizarNumeroQuejas(ByVal NaveSicyId As Integer, ByVal Año As Integer, ByVal NumeroSemana As Integer, ByVal NumeroQuejas As Integer, ByVal AlmacenID As Integer) As DataTable
        Dim objDA As New Datos.ReporteEvaluacionCalidadNaveDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ReporteActualizarNumeroQuejas(NaveSicyId, Año, NumeroSemana, NumeroQuejas, AlmacenID)
            Return tabla

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteEvaluacionTop5(ByVal Año As Integer, ByVal SemanaInicial As Integer, ByVal SemanaFinal As Integer, ByVal ConsultarTop5PorRango As Boolean, ByVal NaveID As Integer) As DataTable
        Dim objDA As New Datos.ReporteEvaluacionCalidadNaveDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ReporteEvaluacionTop5(Año, SemanaInicial, SemanaFinal, ConsultarTop5PorRango, NaveID)

            'If AlmacenId = 1 Then
            '    tabla = objDA.ReporteEvaluacionTop5(Año, SemanaInicial, SemanaFinal, ConsultarTop5PorRango)
            'ElseIf AlmacenId = 2 Then
            '    tabla = objDA.ReporteEvaluacionTop5_AlmacenZ(Año)
            'End If

            Return tabla

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaDetallesEvaluacionCalidad(ByVal NaveSicyId As Integer, ByVal Año As Integer, ByVal NumeroSemana As Integer) As DataTable
        Dim objDA As New Datos.ReporteEvaluacionCalidadNaveDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultaDetallesEvaluacionCalidad(NaveSicyId, Año, NumeroSemana)

            Return tabla

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteConsultaEvaluacionSemanal_2018(ByVal NaveSicyId As Integer, ByVal Año As Integer, ByVal NumeroSemanaInicial As Integer, ByVal NumeroSemanaFinal As Integer, ByVal ConsultarTop5PorRango As Boolean) As DataTable
        Dim objDA As New Datos.ReporteEvaluacionCalidadNaveDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ReporteConsultaEvaluacionSemanal_2018(NaveSicyId, Año, NumeroSemanaInicial, NumeroSemanaFinal, ConsultarTop5PorRango)
            Return tabla

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GenerarInformaciónAlertarCalidadSemana(ByVal Año As Integer, ByVal Semana As Integer, ByVal Fecha As Date) As DataTable
        Dim objDA As New Datos.ReporteEvaluacionCalidadNaveDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.GenerarInformaciónAlertarCalidadSemana(Año, Semana, Fecha)
            Return tabla

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaInformaciónAlertasCalidadSemana(ByVal Año As Integer, ByVal Semana As Integer, ByVal Grupo As String) As DataTable
        Dim objDA As New Datos.ReporteEvaluacionCalidadNaveDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultaInformaciónAlertasCalidadSemana(Año, Semana, Grupo)
            Return tabla

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaCriteriosEvaluacion(ByVal Nave As Integer, ByVal criterios As String) As DataTable
        Dim datos As New Datos.ReporteEvaluacionCalidadNaveDA
        ConsultaCriteriosEvaluacion = datos.ConsultaCriteriosEvaluacion(Nave, criterios)
        Return ConsultaCriteriosEvaluacion
    End Function

    Public Function RegistrarCriterioEvaluacion(ByVal NaveID As Int16, ByVal Criterio As String, ByVal ValorInicial As Int32, ByVal ValorFinal As Int32, ByVal Puntos As Int32, ByVal Usuario As Int32)
        Dim datos As New Datos.ReporteEvaluacionCalidadNaveDA
        Return datos.RegistrarCriterioEvaluacion(NaveID, Criterio, ValorInicial, ValorFinal, Puntos, Usuario)
    End Function

    Public Sub EliminarCriterioEvaluacion(ByVal CriterioID As String)
        Dim datos As New Datos.ReporteEvaluacionCalidadNaveDA
        datos.EliminarCriterioEvaluacion(CriterioID)
    End Sub

    Public Sub ModificarPuntajeCriterios(ByVal criterios As String)
        Dim datos As New Datos.ReporteEvaluacionCalidadNaveDA
        Try
            datos.ModificarPuntajeCriterios(criterios)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function ConsultarDiasLaboralesSemana(ByVal Año As Integer, ByVal Semana As Integer) As DataTable
        Dim objDA As New Datos.ReporteEvaluacionCalidadNaveDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.ConsultarDiasLaboralesSemana(Año, Semana)
            Return tabla

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerNumeroSemana(ByVal Año As Integer, ByVal Fecha As Date) As Integer
        Dim objDA As New Datos.ReporteEvaluacionCalidadNaveDA
        Dim tabla As New DataTable
        Dim Semana As Integer = 0
        Try
            tabla = objDA.ObtenerNumeroSemana(Año, Fecha)

            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    Semana = tabla.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return Semana
    End Function

End Class
