Public Class CalculoInfonavit
    Public msjError As String = String.Empty
    Private Const diasTrabajados As Int16 = 7
    Dim salarioMinimoDF As Double
    Dim diasNoLaborables As Integer = 0
    Dim numsemanasDescontar As Integer = 0
    Dim diasPorTranscurrir As Integer = 0

    Sub New()
        salarioMinimoDF = obtenerSalarioMinimoDF()
    End Sub

    Public Function obtenerSalarioMinimoDF() As Double
        Try
            Dim objBU As New Negocios.UtileriasBU
            Return objBU.consultaSalarioMinimoUMI()
        Catch ex As Exception
            Return 0.0
        End Try
    End Function

    Public Function calcularDescuentoPorcentaje(ByVal SalarioDiario As Double, ByVal porcentajeRetencion As Double, ByVal patronId As Integer, ByVal fechaMovimiento As String) As Entidades.CreditoInfonavit
        Dim credInfonavit As New Entidades.CreditoInfonavit

        Try
            If SalarioDiario > 0 And porcentajeRetencion > 0 And diasTrabajados > 0 Then
                If existeConfiguracionVacaciones(patronId, fechaMovimiento) Then
                    If obtenerDiasSemanaPorTranscurrir(patronId, fechaMovimiento) Then
                        credInfonavit.CISalarioBase = SalarioDiario
                        credInfonavit.CISalarioBimestral = SalarioDiario * diasBimestre
                        credInfonavit.CIValordescuento = porcentajeRetencion
                        credInfonavit.CIImporteretencionmensual = credInfonavit.CISalarioBimestral * (porcentajeRetencion / 100)
                        credInfonavit.CISeguroVivienda = seguroVivienda
                        credInfonavit.CIImporteretenerbimestral = credInfonavit.CIImporteretencionmensual + seguroVivienda
                        credInfonavit.CIRetenciondiaria = credInfonavit.CIImporteretenerbimestral / diasBimestre
                        credInfonavit.CIRetencionsemanalfiscal = credInfonavit.CIRetenciondiaria * diasTrabajados
                        credInfonavit.CIDiasSemana = diasTrabajados
                        credInfonavit.CISemanasdescontaranual = credInfonavit.CIRetenciondiaria * diasNoLaborables
                        credInfonavit.CINumSemDescontar = numsemanasDescontar
                        credInfonavit.CIDiasAnio = diasNoLaborables + diasPorTranscurrir
                        If numsemanasDescontar > 0 Then
                            credInfonavit.CIDescuentosemanal = (credInfonavit.CISemanasdescontaranual / numsemanasDescontar) + credInfonavit.CIRetencionsemanalfiscal
                        Else
                            credInfonavit.CIDescuentosemanal = credInfonavit.CISemanasdescontaranual + credInfonavit.CIRetencionsemanalfiscal
                        End If
                    Else
                        msjError = "No se pudo obtener la configuración de vacaciones de la empresa."
                    End If
                Else
                    msjError = "No hay configuración de vacaciones cargada para la empresa del colaborador."
                End If
            Else
                msjError = "Los datos son insuficientes para realizar el cálculo."
            End If
        Catch ex As Exception
            msjError = "Error al obtener el descuento del Crédito Infoanvit"
        End Try

        Return credInfonavit
    End Function

    Public Function calcularDescuentoVecesSM(ByVal factorDescuento As Double, ByVal patronId As Integer, ByVal fechaMovimiento As String) As Entidades.CreditoInfonavit
        Dim credInfonavit As New Entidades.CreditoInfonavit

        Try
            If salarioMinimoDF > 0 Then
                If factorDescuento > 0 And diasTrabajados > 0 Then
                    If existeConfiguracionVacaciones(patronId, fechaMovimiento) Then
                        If obtenerDiasSemanaPorTranscurrir(patronId, fechaMovimiento) Then
                            credInfonavit.CISalarioMinimoDF = salarioMinimoDF
                            credInfonavit.CIValordescuento = factorDescuento
                            credInfonavit.CIRetencionMensual = salarioMinimoDF * factorDescuento
                            credInfonavit.CIImporteretencionbimestral = credInfonavit.CIRetencionMensual * mesesPeriodo
                            credInfonavit.CISeguroVivienda = seguroVivienda
                            credInfonavit.CIImporteretenerbimestral = credInfonavit.CIImporteretencionbimestral + seguroVivienda
                            credInfonavit.CIRetenciondiaria = credInfonavit.CIImporteretenerbimestral / diasBimestre
                            credInfonavit.CIDiasSemana = diasTrabajados
                            credInfonavit.CIRetencionsemanalfiscal = credInfonavit.CIRetenciondiaria * diasTrabajados
                            credInfonavit.CINumSemDescontar = numsemanasDescontar
                            credInfonavit.CISemanasdescontaranual = credInfonavit.CIRetenciondiaria * diasNoLaborables
                            credInfonavit.CIDiasAnio = diasPorTranscurrir
                            credInfonavit.CIdiasNoLaborables = diasNoLaborables

                            If numsemanasDescontar > 0 Then
                                credInfonavit.CIDescuentosemanal = (credInfonavit.CISemanasdescontaranual / numsemanasDescontar) + credInfonavit.CIRetencionsemanalfiscal
                            Else
                                credInfonavit.CIDescuentosemanal = credInfonavit.CISemanasdescontaranual + credInfonavit.CIRetencionsemanalfiscal
                            End If
                        Else
                            msjError = "No se pudo obtener la configuración de vacaciones de la empresa."
                        End If
                    Else
                        msjError = "No hay configuración de vacaciones cargada para la empresa del colaborador."
                    End If
                Else
                    msjError = "Los datos son insuficientes para realizar el cálculo."
                End If
            Else
                msjError = "No esta cargado el salario mínimo del DF."
            End If
        Catch ex As Exception
            msjError = "Error al obtener el descuento del Crédito Infoanvit"
        End Try

        Return credInfonavit
    End Function

    Public Function calcularDescuentoCoutaFija(ByVal valordescuento As Double, ByVal patronId As Integer, ByVal fechaMovimiento As String) As Entidades.CreditoInfonavit
        Dim credInfonavit As New Entidades.CreditoInfonavit

        Try
            If valordescuento > 0 And diasTrabajados > 0 Then
                If existeConfiguracionVacaciones(patronId, fechaMovimiento) Then
                    If obtenerDiasSemanaPorTranscurrir(patronId, fechaMovimiento) Then
                        credInfonavit.CIValordescuento = valordescuento
                        credInfonavit.CIRetenciondiaria = valordescuento / diasMes
                        credInfonavit.CIDiasSemana = diasTrabajados
                        credInfonavit.CIRetencionsemanalfiscal = credInfonavit.CIRetenciondiaria * diasTrabajados
                        credInfonavit.CINumSemDescontar = numsemanasDescontar
                        credInfonavit.CISemanasdescontaranual = credInfonavit.CIRetenciondiaria * diasNoLaborables
                        If numsemanasDescontar > 0 Then
                            credInfonavit.CIDescuentosemanal = (credInfonavit.CISemanasdescontaranual / numsemanasDescontar) + credInfonavit.CIRetencionsemanalfiscal
                        Else
                            credInfonavit.CIDescuentosemanal = credInfonavit.CISemanasdescontaranual + credInfonavit.CIRetencionsemanalfiscal
                        End If
                    Else
                        msjError = "No se pudo obtener la configuración de vacaciones de la empresa."
                    End If
                Else
                    msjError = "No hay configuración de vacaciones cargada para la empresa del colaborador."
                End If
            Else
                msjError = "Los datos son insuficientes para realizar el cálculo."
            End If
        Catch ex As Exception
            msjError = "Error al obtener el descuento del Crédito Infoanvit"
        End Try

        Return credInfonavit
    End Function


    Public Function existeConfiguracionVacaciones(ByVal patronId As Integer, ByVal fechaMovimiento As String) As Boolean
        Try
            Dim objBU As New Negocios.UtileriasBU
            Return objBU.existeConfiguracionVacaciones(patronId, CDate(fechaMovimiento))
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function obtenerDiasSemanaPorTranscurrir(ByVal patronId As Integer, ByVal fechaMovimiento As String) As Boolean
        Try
            Dim objBU As New Negocios.CreditoInfonavitBU
            Dim dtInformacion As New DataTable
            dtInformacion = objBU.obtenerDiasSemanaPorTranscurrir(patronId, CDate(fechaMovimiento))
            If Not dtInformacion Is Nothing Then
                If dtInformacion.Rows.Count > 0 Then
                    diasNoLaborables = CInt(dtInformacion.Rows(0)("diasNoLaborables").ToString)
                    numsemanasDescontar = CInt(dtInformacion.Rows(0)("semanasPorTranscurrir").ToString)
                    diasPorTranscurrir = CInt(dtInformacion.Rows(0)("diasPorTranscurrir").ToString)
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
