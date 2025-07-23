Public Class CalculoNominaFiscalForm


    Private Sub CalculoNominaFiscalForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        listado_naves()

        ''DETALLE SUBSIDIO
        clmLimiteInferior.Visible = False
        clmExdenteSobreLimiteInferior.Visible = False
        clmTasaDeImpuesto.Visible = False
        clmImpuestoMarginal.Visible = False
        clmCuotaFija.Visible = False
        clmISRDeterminado.Visible = False
        clmSubsidioParaElEmpleo.Visible = False
        ''FIN DETALLE SUBSIDIO

        ''DETALLE IMSS
        clmAniosServicio.Visible = False
        clmFactorIntegracion.Visible = False
        clmSalarioBaseCotizacion.Visible = False
        clmExcedente3SalariosMinimos.Visible = False
        clmCuotaPorExcedente.Visible = False
        clmTotalPorExcedente.Visible = False
        clmPrestacionesEnDinero.Visible = False
        clmGastosMedicosPensionados.Visible = False
        clmInvalidezYVida.Visible = False
        clmCesantiaEnEdadAvanzadaYVejez.Visible = False
        clmFactor.Visible = False
        clmDiasTrabajadosIncapacidad.Visible = False
        ''FIN DETALLE IMSS

        ''DETALLE INFONAVIT
        clmTipoCredito.Visible = False
        clmDiasBimestre.Visible = False
        clmMesesPeriodo.Visible = False
        clmSalarioBimestral.Visible = False
        clmPorcentajeRetencion.Visible = False
        clmFactorDescuento.Visible = False
        clmCuotaFijaINFONAVIT.Visible = False
        clmRetencionMensual.Visible = False
        clmImporteBimestral.Visible = False
        clmSeguroVivienda.Visible = False
        clmImporteRetenerBimestral.Visible = False
        clmRetencionDiaria.Visible = False
        clmDiasTrabajadosIncapacidad2.Visible = False
        ''FIN DETALLE INFONAVIT

    End Sub

    Private Sub listado_naves()

        Try

            Controles.ComboNavesSegunUsuario(cboxNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cboxNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxNave.DropDownClosed

        listado_periodos_asistencia()

    End Sub

    Private Sub listado_periodos_asistencia()

        Try

            Controles.ComboPeriodoSegunNaveSegunAsistencia(cboxPeriodo, CInt(cboxNave.SelectedValue.ToString))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        gridCalculoNominaFiscal.Rows.Clear()

        llenar_gridCalculoNominaFiscal()

    End Sub

    Public Sub llenar_gridCalculoNominaFiscal()

        Dim CalculoNominaFiscalBU As New Negocios.CalculoNominaFiscalBU
        Dim listaCalculoNominaFiscal As New List(Of Entidades.CalculoNominaFiscal)

        listaCalculoNominaFiscal = CalculoNominaFiscalBU.consultar_DatosBasicosColaboradores(cboxNave.SelectedValue, cboxPeriodo.SelectedValue)

        For Each elemento As Entidades.CalculoNominaFiscal In listaCalculoNominaFiscal

            gridCalculoNominaFiscal.Rows.Add(elemento.PColaborador.PColaboradorid,
                                             elemento.PColaborador.PNombre + " " + elemento.PColaborador.PApaterno + " " + elemento.PColaborador.PAmaterno,
                                             elemento.PSalarioDiario,
                                             elemento.PDiasTrabajados,
                                             elemento.PSalarioSemanal,
                                             elemento.PSalarioMensual,
                                             elemento.PPremioPuntualidad,
                                             elemento.PDespensa,
                                             elemento.PTotalGravado,
                                             elemento.PLimiteInfeior,
                                             elemento.PExcedente,
                                             elemento.PTasaDeImpuesto,
                                             elemento.PImpuestoMarginal,
                                             elemento.PCuotaFija,
                                             elemento.PISRDeterminado,
                                             elemento.PSubsidioEmpleo,
                                             elemento.PCantidadARetener,
                                             elemento.PSubsidioPorPagar,
                                             elemento.PAniosServicio,
                                             elemento.PFactorIntegracion,
                                             elemento.PSalarioBaseCotizacion,
                                             elemento.PExcedentesSalariosMinimos,
                                             elemento.PCuotaPorExcedente,
                                             elemento.PTotalPorExcedente,
                                             elemento.PPrestacionesEnDinero,
                                             elemento.PGastosMedicosPensionados,
                                             elemento.PInvalidezYVida,
                                             elemento.PCesantiaEdadAvanzadaVejez,
                                             elemento.PFactor,
                                             elemento.PDiasTrabajadosMasAusentismosMenosIncapacidad,
                                             elemento.PTotalARetener,
                                             elemento.PTipoCredito,
                                             elemento.PDiasBimestre,
                                             2,
                                             elemento.PSalarioBimestral,
                                             elemento.PPorcentajeRetencion,
                                             elemento.PFactorDescuento,
                                             elemento.PCuotaFijaINFONAVIT,
                                             elemento.PRetencionMensual,
                                             elemento.PImporteBimestral,
                                             elemento.PSeguroVivienda,
                                             elemento.PImporteBimestralRetener,
                                             elemento.PRetencionDiario,
                                             elemento.PDiasTrabajadosMasAusentismosMenosIncapacidad,
                                             elemento.PRetencionSemanal)

        Next

    End Sub

    Private Sub btnArriba_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click

        pnlFiltro.Visible = False

    End Sub

    Private Sub btnAbajo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click

        pnlFiltro.Visible = True

    End Sub

    Private Sub chboxDetalleSubsidio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chboxDetalleSubsidio.CheckedChanged

        If chboxDetalleSubsidio.CheckState Then

            clmLimiteInferior.Visible = True
            clmLimiteInferior.DefaultCellStyle.BackColor = Color.Salmon
            clmExdenteSobreLimiteInferior.Visible = True
            clmExdenteSobreLimiteInferior.DefaultCellStyle.BackColor = Color.Salmon
            clmTasaDeImpuesto.Visible = True
            clmTasaDeImpuesto.DefaultCellStyle.BackColor = Color.Salmon
            clmImpuestoMarginal.Visible = True
            clmImpuestoMarginal.DefaultCellStyle.BackColor = Color.Salmon
            clmCuotaFija.Visible = True
            clmCuotaFija.DefaultCellStyle.BackColor = Color.Salmon
            clmISRDeterminado.Visible = True
            clmISRDeterminado.DefaultCellStyle.BackColor = Color.Salmon
            clmSubsidioParaElEmpleo.Visible = True
            clmSubsidioParaElEmpleo.DefaultCellStyle.BackColor = Color.Salmon

        Else

            clmLimiteInferior.Visible = False
            clmExdenteSobreLimiteInferior.Visible = False
            clmTasaDeImpuesto.Visible = False
            clmImpuestoMarginal.Visible = False
            clmCuotaFija.Visible = False
            clmISRDeterminado.Visible = False
            clmSubsidioParaElEmpleo.Visible = False

        End If

    End Sub

    Private Sub chboxDetalleIMSS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chboxDetalleIMSS.CheckedChanged

        If chboxDetalleIMSS.CheckState Then

            clmAniosServicio.Visible = True
            clmAniosServicio.DefaultCellStyle.BackColor = Color.BurlyWood
            clmFactorIntegracion.Visible = True
            clmFactorIntegracion.DefaultCellStyle.BackColor = Color.BurlyWood
            clmSalarioBaseCotizacion.Visible = True
            clmSalarioBaseCotizacion.DefaultCellStyle.BackColor = Color.BurlyWood
            clmExcedente3SalariosMinimos.Visible = True
            clmExcedente3SalariosMinimos.DefaultCellStyle.BackColor = Color.BurlyWood
            clmCuotaPorExcedente.Visible = True
            clmCuotaPorExcedente.DefaultCellStyle.BackColor = Color.BurlyWood
            clmTotalPorExcedente.Visible = True
            clmTotalPorExcedente.DefaultCellStyle.BackColor = Color.BurlyWood
            clmPrestacionesEnDinero.Visible = True
            clmPrestacionesEnDinero.DefaultCellStyle.BackColor = Color.BurlyWood
            clmGastosMedicosPensionados.Visible = True
            clmGastosMedicosPensionados.DefaultCellStyle.BackColor = Color.BurlyWood
            clmInvalidezYVida.Visible = True
            clmInvalidezYVida.DefaultCellStyle.BackColor = Color.BurlyWood
            clmCesantiaEnEdadAvanzadaYVejez.Visible = True
            clmCesantiaEnEdadAvanzadaYVejez.DefaultCellStyle.BackColor = Color.BurlyWood
            clmFactor.Visible = True
            clmFactor.DefaultCellStyle.BackColor = Color.BurlyWood
            clmDiasTrabajadosIncapacidad.Visible = True
            clmDiasTrabajadosIncapacidad.DefaultCellStyle.BackColor = Color.BurlyWood

        Else

            clmAniosServicio.Visible = False
            clmFactorIntegracion.Visible = False
            clmSalarioBaseCotizacion.Visible = False
            clmExcedente3SalariosMinimos.Visible = False
            clmCuotaPorExcedente.Visible = False
            clmTotalPorExcedente.Visible = False
            clmPrestacionesEnDinero.Visible = False
            clmGastosMedicosPensionados.Visible = False
            clmInvalidezYVida.Visible = False
            clmCesantiaEnEdadAvanzadaYVejez.Visible = False
            clmFactor.Visible = False
            clmDiasTrabajadosIncapacidad.Visible = False

        End If

    End Sub

    Private Sub chboxDetalleINFONAVIT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chboxDetalleINFONAVIT.CheckedChanged

        If chboxDetalleINFONAVIT.CheckState Then

            clmTipoCredito.Visible = True
            clmTipoCredito.DefaultCellStyle.BackColor = Color.BlanchedAlmond
            clmDiasBimestre.Visible = True
            clmDiasBimestre.DefaultCellStyle.BackColor = Color.BlanchedAlmond
            clmMesesPeriodo.Visible = True
            clmMesesPeriodo.DefaultCellStyle.BackColor = Color.BlanchedAlmond
            clmSalarioBimestral.Visible = True
            clmSalarioBimestral.DefaultCellStyle.BackColor = Color.BlanchedAlmond
            clmPorcentajeRetencion.Visible = True
            clmPorcentajeRetencion.DefaultCellStyle.BackColor = Color.BlanchedAlmond
            clmFactorDescuento.Visible = True
            clmFactorDescuento.DefaultCellStyle.BackColor = Color.BlanchedAlmond
            clmCuotaFijaINFONAVIT.Visible = True
            clmCuotaFijaINFONAVIT.DefaultCellStyle.BackColor = Color.BlanchedAlmond
            clmRetencionMensual.Visible = True
            clmRetencionMensual.DefaultCellStyle.BackColor = Color.BlanchedAlmond
            clmImporteBimestral.Visible = True
            clmImporteBimestral.DefaultCellStyle.BackColor = Color.BlanchedAlmond
            clmSeguroVivienda.Visible = True
            clmSeguroVivienda.DefaultCellStyle.BackColor = Color.BlanchedAlmond
            clmImporteRetenerBimestral.Visible = True
            clmImporteRetenerBimestral.DefaultCellStyle.BackColor = Color.BlanchedAlmond
            clmRetencionDiaria.Visible = True
            clmRetencionDiaria.DefaultCellStyle.BackColor = Color.BlanchedAlmond
            clmDiasTrabajadosIncapacidad2.Visible = True
            clmDiasTrabajadosIncapacidad2.DefaultCellStyle.BackColor = Color.BlanchedAlmond

        Else

            clmTipoCredito.Visible = False
            clmDiasBimestre.Visible = False
            clmMesesPeriodo.Visible = False
            clmSalarioBimestral.Visible = False
            clmPorcentajeRetencion.Visible = False
            clmFactorDescuento.Visible = False
            clmCuotaFijaINFONAVIT.Visible = False
            clmRetencionMensual.Visible = False
            clmImporteBimestral.Visible = False
            clmSeguroVivienda.Visible = False
            clmImporteRetenerBimestral.Visible = False
            clmRetencionDiaria.Visible = False
            clmDiasTrabajadosIncapacidad2.Visible = False

        End If

    End Sub
End Class