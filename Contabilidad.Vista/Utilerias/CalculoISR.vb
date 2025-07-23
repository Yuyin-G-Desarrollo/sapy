Public Class CalculoISR
    Public Const SPE_ISR_SEMANAL As Short = 0
    Public Const SPE_ISR_MENSUAL As Short = 1
    Public Const SPE_ISR_CATORCENAL As Short = 2
    Public Const SPE_ISR_QUINCENAL As Short = 3
    Public Const SPE_ISR_ANUAL As Short = 4

    Public msjError As String = String.Empty
    Dim tarifaSemanal As New Entidades.TarifaMensualSemanal
    Dim subsidioEmpleo As New Entidades.SubsidioEmpleo
    Dim premioAsistencia As Double
    Dim premioPuntualidad As Double
    Dim comisiones As Double

    Public Function calcularISR_SPE(ByVal sueldoSemanal As Double, ByVal colaboradorId As Integer, ByVal ganaPremioPunt As Boolean, ByVal ganaPremioAsis As Boolean, ByVal comisiones As Double) As Entidades.RetencionISR_SPE
        Dim RetencionISRSPE As New Entidades.RetencionISR_SPE

        If consultaPorcentajePremios(colaboradorId) Then
            If ganaPremioAsis Then
                premioAsistencia = premioAsistencia * sueldoSemanal
            Else
                premioAsistencia = 0
            End If

            If ganaPremioPunt Then
                premioPuntualidad = premioPuntualidad * sueldoSemanal
            Else
                premioPuntualidad = 0
            End If

            RetencionISRSPE.RISSalariosemanalgravado = sueldoSemanal + premioAsistencia + premioPuntualidad + comisiones
            If consultaTarifaSemanal(RetencionISRSPE.RISSalariosemanalgravado, SPE_ISR_SEMANAL) Then
                If consultaSubsidioEmpleo(RetencionISRSPE.RISSalariosemanalgravado, SPE_ISR_SEMANAL) Then
                    RetencionISRSPE.RISExcedentelimiteinferior = RetencionISRSPE.RISSalariosemanalgravado - tarifaSemanal.TMSLimiteinferior
                    RetencionISRSPE.RISTasa = tarifaSemanal.TMSPorcentajeexcedente
                    RetencionISRSPE.RISImpuestomarginal = RetencionISRSPE.RISExcedentelimiteinferior * RetencionISRSPE.RISTasa
                    RetencionISRSPE.RISCuotafija = tarifaSemanal.TMSCuotafija
                    RetencionISRSPE.RISISRdeterminado = RetencionISRSPE.RISImpuestomarginal + RetencionISRSPE.RISCuotafija
                    RetencionISRSPE.RISSPEcalculado = RetencionISRSPE.RISISRdeterminado - subsidioEmpleo.SEValorspe
                    RetencionISRSPE.PSPECausado = subsidioEmpleo.SEValorspe

                    If RetencionISRSPE.RISSPEcalculado > 0 Then
                        RetencionISRSPE.RISISRretenido = RetencionISRSPE.RISSPEcalculado
                    Else
                        RetencionISRSPE.RISSPEpagado = RetencionISRSPE.RISSPEcalculado * (-1)
                    End If
                End If
            End If
        End If

        Return RetencionISRSPE
    End Function

    Public Function calcularISR_SPEConDias(ByVal sueldoSemanal As Double, ByVal colaboradorId As Integer, ByVal ganaPremioPunt As Boolean, ByVal ganaPremioAsis As Boolean, ByVal diasTrabajados As Double, ByVal comisiones As Double, ByVal tipoPeriodo As Short) As Entidades.RetencionISR_SPE
        Dim RetencionISRSPE As New Entidades.RetencionISR_SPE
        Dim diasdividir As Short = 7

        If tipoPeriodo = SPE_ISR_CATORCENAL Then
            diasdividir = 14
        ElseIf tipoPeriodo = SPE_ISR_SEMANAL Then
            diasdividir = 7
        End If

        If consultaPorcentajePremios(colaboradorId) Then
            If ganaPremioAsis Then
                premioAsistencia = premioAsistencia * sueldoSemanal
            Else
                premioAsistencia = 0
            End If

            If ganaPremioPunt Then
                premioPuntualidad = premioPuntualidad * sueldoSemanal
            Else
                premioPuntualidad = 0
            End If

            RetencionISRSPE.RISSalariosemanalgravado = sueldoSemanal + premioAsistencia + premioPuntualidad + comisiones
            If consultaTarifaSemanal(RetencionISRSPE.RISSalariosemanalgravado, tipoPeriodo) Then
                If consultaSubsidioEmpleo(RetencionISRSPE.RISSalariosemanalgravado, tipoPeriodo) Then
                    RetencionISRSPE.RISExcedentelimiteinferior = RetencionISRSPE.RISSalariosemanalgravado - tarifaSemanal.TMSLimiteinferior
                    RetencionISRSPE.RISTasa = tarifaSemanal.TMSPorcentajeexcedente
                    RetencionISRSPE.RISImpuestomarginal = RetencionISRSPE.RISExcedentelimiteinferior * RetencionISRSPE.RISTasa
                    RetencionISRSPE.RISCuotafija = tarifaSemanal.TMSCuotafija
                    RetencionISRSPE.RISISRdeterminado = RetencionISRSPE.RISImpuestomarginal + RetencionISRSPE.RISCuotafija
                    subsidioEmpleo.SEValorspe = (subsidioEmpleo.SEValorspe / diasdividir) * diasTrabajados
                    RetencionISRSPE.RISSPEcalculado = RetencionISRSPE.RISISRdeterminado - subsidioEmpleo.SEValorspe
                    RetencionISRSPE.PSPECausado = subsidioEmpleo.SEValorspe

                    If RetencionISRSPE.RISSPEcalculado > 0 Then
                        RetencionISRSPE.RISISRretenido = RetencionISRSPE.RISSPEcalculado
                    Else
                        RetencionISRSPE.RISSPEpagado = RetencionISRSPE.RISSPEcalculado * (-1)
                    End If
                End If
            End If
        End If

        Return RetencionISRSPE
    End Function

    Public Function consultaPorcentajePremios(ByVal colaboradorId As Integer) As Boolean
        Try
            Dim objBU As New Negocios.UtileriasBU
            Dim dtPremios As New DataTable

            dtPremios = objBU.consultaPorcentajePremios(colaboradorId)
            If Not dtPremios Is Nothing Then
                If dtPremios.Rows.Count > 0 Then
                    premioAsistencia = CDbl(dtPremios.Rows(0)("premioAsistencia").ToString)
                    premioPuntualidad = CDbl(dtPremios.Rows(0)("premioPuntualidad").ToString)
                    Return True
                Else
                    msjError = "No hay configuración de premios guardada para la Empresa del colaborador"
                    Return False
                End If
            Else
                msjError = "No hay configuración de premios guardada para la Empresa del colaborador"
                Return False
            End If
        Catch ex As Exception
            msjError = "Error al consultar porcentaje de permios de asistencia y puntualidad"
            Return False
        End Try
    End Function

    Public Function consultaTarifaSemanal(ByVal sueldo As Double, ByVal opcTipo As Short) As Boolean
        Try
            Dim objBU As New Negocios.UtileriasBU

            tarifaSemanal = objBU.consultaTarifa(sueldo, opcTipo)
            If Not tarifaSemanal Is Nothing Then
                Return True
            Else
                msjError = "No hay configuración de tarifa semanal guardada"
                Return False
            End If
        Catch ex As Exception
            msjError = "Error al consultar la tarifa semanal"
            Return False
        End Try
    End Function

    Public Function consultaSubsidioEmpleo(ByVal sueldo As Double, ByVal opcTipo As Short) As Boolean
        Try
            Dim objBU As New Negocios.UtileriasBU

            subsidioEmpleo = objBU.consultaSubsidioEmpleo(sueldo, opcTipo)
            If Not subsidioEmpleo Is Nothing Then
                Return True
            Else
                msjError = "No hay configuración de subsidio guardada"
                Return False
            End If
        Catch ex As Exception
            msjError = "Error al consultar el subsidio"
            Return False
        End Try
    End Function
End Class
