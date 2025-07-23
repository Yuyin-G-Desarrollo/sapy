Public Class CalculoIMSS
    Public msjError As String = String.Empty
    Dim salarioMinimoDF As Double
    Dim PorcentajeIMSSExcedenteSM As Double = 0.0

    Sub New()
        salarioMinimoDF = obtenerSalarioMinimoDF()
    End Sub

    Public Function obtenerSalarioMinimoDF() As Double
        Try
            Dim objBU As New Negocios.UtileriasBU
            Return objBU.consultaSalarioMinimoDF()
        Catch ex As Exception
            Return 0.0
        End Try
    End Function

    Public Function obtenerFactorImss() As Double
        Try
            Dim objBU As New Negocios.UtileriasBU
            Dim dtFactorImss As New DataTable
            Dim factorImss As Double = 0.0

            dtFactorImss = objBU.consultaFactorIMSS()
            If Not dtFactorImss Is Nothing Then
                If dtFactorImss.Rows.Count > 0 Then
                    factorImss = CDbl(dtFactorImss.Rows(0)("FactorImss").ToString)
                    PorcentajeIMSSExcedenteSM = CDbl(dtFactorImss.Rows(0)("PorcentajeIMSSExcedenteSM").ToString)
                End If
            End If

            Return factorImss
        Catch ex As Exception
            Return 0.0
        End Try
    End Function

    Public Function calcularRetecionImssIntegrado(ByVal SalarioDiarioIntegrado As Double, ByVal diasTrabajados As Double) As Entidades.RetencionImss
        Dim retencionImss As New Entidades.RetencionImss

        Try
            If salarioMinimoDF > 0 Then
                If SalarioDiarioIntegrado > 0 And diasTrabajados > 0 Then
                    retencionImss.RISalarioDiarioIntegrado = SalarioDiarioIntegrado
                    retencionImss.RIFactorImss = obtenerFactorImss()
                    retencionImss.RIRetencionDiaria = retencionImss.RISalarioDiarioIntegrado * (retencionImss.RIFactorImss / 100)
                    retencionImss.RIDiasPagados = diasTrabajados
                    retencionImss.RITotalRetencion = retencionImss.RIRetencionDiaria * retencionImss.RIDiasPagados
                    retencionImss.RIRetencionImss = retencionImss.RITotalRetencion

                    If retencionImss.RISalarioDiarioIntegrado > (3 * salarioMinimoDF) Then
                        retencionImss.RIExcedeSalarioMinimo = True
                        retencionImss.RIRetencionExcedenteSMDF = PorcentajeIMSSExcedenteSM
                        retencionImss.RICantidadExcedenteSMDF = retencionImss.RISalarioDiarioIntegrado - (3 * salarioMinimoDF)
                        ''retencionImss.RITotalExcedenteSMDF = retencionImss.RITotalRetencion * retencionImss.RIRetencionExcedenteSMDF
                        retencionImss.RITotalExcedenteSMDF = (retencionImss.RICantidadExcedenteSMDF * (retencionImss.RIRetencionExcedenteSMDF / 100)) * retencionImss.RIDiasPagados

                        retencionImss.RIRetencionImss = retencionImss.RITotalRetencion + retencionImss.RITotalExcedenteSMDF
                        retencionImss.RIRetencionDiaria = retencionImss.RIRetencionImss / retencionImss.RIDiasPagados
                    Else
                        retencionImss.RIExcedeSalarioMinimo = False
                        retencionImss.RIRetencionExcedenteSMDF = 0
                        retencionImss.RITotalExcedenteSMDF = 0
                    End If
                    
                Else
                    msjError = "Los datos son insuficientes para realizar el cálculo."
                End If
            Else
                msjError = "No esta cargado el salario mínimo del DF."
            End If
        Catch ex As Exception
            msjError = "Error al obtener la retención IMSS"
        End Try

        Return retencionImss
    End Function
End Class
