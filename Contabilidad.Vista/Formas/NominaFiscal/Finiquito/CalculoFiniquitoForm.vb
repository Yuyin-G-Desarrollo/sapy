Imports Tools
Imports System.Windows.Forms

Public Class CalculoFiniquitoForm

    Public ColaboradorID As Integer = -1
    Public FechaBaja As Date
    Public SolicitudBajaID As Integer = -1
    Public FinquitoFiscalID As Integer = -1
    Public EstatusSolicitud As Integer = -1

    Dim TotalAntesImpuestos As Double = 0
    Dim NetoREcibir As Double = 0


    Private FiniquitoFiscal As New Entidades.FiniquitoFiscal

    Private Sub CalculoFiniquitoForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        If FinquitoFiscalID <> -1 Then
            ConsultarFiniquitoFiscal()
        Else
            CalcularFiniquitoFiscal()
        End If
     
        CargarInterfaz()
        dtmFechaBaja.Enabled = False
        

        If FinquitoFiscalID <> -1 Then
            txtResumenIndemizacionFiniquito.Enabled = False
            btnGuardar.Enabled = False
        Else
            txtResumenIndemizacionFiniquito.Enabled = True
        End If

        If EstatusSolicitud = 106 Or EstatusSolicitud = 109 Then
            btnEditarFiniquito.Enabled = True
        Else
            btnEditarFiniquito.Enabled = False
        End If

    End Sub


    Private Sub CalcularFiniquitoFiscal()
        Dim ObjFiniquitoFiscalBU As New Contabilidad.Negocios.FiniquitoFiscalBU
        FiniquitoFiscal = ObjFiniquitoFiscalBU.CalcularFinquitoFiscal(ColaboradorID, FechaBaja, 0.0)
    End Sub

    Private Sub ConsultarFiniquitoFiscal()
        Dim ObjFiniquitoFiscalBU As New Contabilidad.Negocios.FiniquitoFiscalBU
        FiniquitoFiscal = ObjFiniquitoFiscalBU.ObtenerFiniquitoFiscal(FinquitoFiscalID)
    End Sub


    Private Sub CargarInterfaz()


        txtColaborador.Text = FiniquitoFiscal.InformacionColoaborador.IINombre + " " + FiniquitoFiscal.InformacionColoaborador.IIAPaterno + " " + FiniquitoFiscal.InformacionColoaborador.IIAMaterno
        txtNSS.Text = FiniquitoFiscal.InformacionColoaborador.IINumeroSeguroSocial
        txtRFC.Text = FiniquitoFiscal.InformacionColoaborador.IIRFC
        txtCURP.Text = FiniquitoFiscal.InformacionColoaborador.IICurp
        txtSueldoDiario.Text = CDbl(FiniquitoFiscal.InformacionColoaborador.IISalarioDiario).ToString("C2")
        txtFechaIngreso.Text = FiniquitoFiscal.InformacionColoaborador.IIFechaMovimiento
        txtAntiguedad.Text = FiniquitoFiscal.Antiguedad
        txtDiasCurso.Text = FiniquitoFiscal.DiasEnCurso
        txtSMAG.Text = FiniquitoFiscal.SMAG
        txtInicioCurso.Text = FiniquitoFiscal.FechaInicioCurso.ToShortDateString()
        txtCodigoEmpleado.Text = FiniquitoFiscal.InformacionColoaborador.IIClaveTrabajador.ToString()
        'Vacaciones
        txtUltimoPagoVacaciones.Text = FiniquitoFiscal.FechaUltimoPagoVacaciones.ToShortDateString()
        'txtVacacionesAños.Text = FiniquitoFiscal.AñosLaborando
        txtVacacionesAños.Text = FiniquitoFiscal.PAniosVacaciones
        txtVacacionesDias.Text = FiniquitoFiscal.DiasVacacionesAño
        txtVacacionesDiasCurso.Text = FiniquitoFiscal.DiasEnCurso
        txtVacacionesDiasDias.Text = FiniquitoFiscal.DiasVacacionesCorresponden
        txtVacacionesMontoDias.Text = FiniquitoFiscal.TotalVacaciones.ToString("C2")
        txtVacacionesMontoTotal.Text = FiniquitoFiscal.TotalVacaciones.ToString("C2")

        'Aguinaldo
        txtAguinaldoFactor.Text = Math.Round(FiniquitoFiscal.FactorAguinaldo, 3).ToString()
        txtAguinaldoMeses.Text = FiniquitoFiscal.MesesLaborandoDelAño
        txtAguinaldoDias.Text = Math.Round(FiniquitoFiscal.DiasAguinaldoCorresponden, 2).ToString()
        txtAguinaldoMonto.Text = Math.Round(FiniquitoFiscal.TotalAguinaldo, 2).ToString("C")


        'ISR
        txtISRTotalGravado.Text = Math.Round(FiniquitoFiscal.TotalGravado, 2).ToString("C")
        txtUltimoSueldoMensual.Text = Math.Round(FiniquitoFiscal.ISR.UltimoSueldoMensualOrdinario, 2).ToString("C")
        txtISRBaseImpuesto.Text = Math.Round(FiniquitoFiscal.ISR.BaseImpuesto, 2).ToString("C")
        txtISRLimiteInferior.Text = Math.Round(FiniquitoFiscal.ISR.LimiteInferior, 2).ToString("C")
        txtISRExcedenteLimiteInf.Text = Math.Round(FiniquitoFiscal.ISR.ExcedenteLimiteInferior, 2).ToString("C")
        txtISRPorcenyajeLimiteInf.Text = Math.Round(FiniquitoFiscal.ISR.PorcentajeLimiteInferior, 4).ToString()
        txtISRImpuestoMarginal.Text = Math.Round(FiniquitoFiscal.ISR.ImpuestoMarginal, 2).ToString("C")
        txtISRCuotaFija.Text = Math.Round(FiniquitoFiscal.ISR.CuotaFija, 2).ToString("C")
        txtISRImpuestoDeterminado.Text = Math.Round(FiniquitoFiscal.ISR.ImpuestoDeterminado, 2).ToString("C")
        txtISRSubsidioEmpleo.Text = Math.Round(FiniquitoFiscal.ISR.SubsidioEmpleo, 2).ToString("C")
        txtISRRetencionUSMO.Text = Math.Round(FiniquitoFiscal.ISR.RentencionUSMO, 2).ToString("C")
        txtISRImpuestoRetener.Text = Math.Round(FiniquitoFiscal.ISR.ImpuestoRetenido, 2).ToString("C")


        'Totales
        txtResumenVacacionesTotal.Text = Math.Round(FiniquitoFiscal.TotalVacaciones, 2).ToString("C")
        txtResumenPrimaVacacional.Text = Math.Round(FiniquitoFiscal.PrimaVacacional, 2).ToString("C")
        txtResumenTotalAguinaldo.Text = Math.Round(FiniquitoFiscal.TotalAguinaldo, 2).ToString("C")
        txtResumenIndemizacionFiniquito.Text = Math.Round(FiniquitoFiscal.IndemizacionFiniquito, 2).ToString("C")
        txtResumenTotalAntesImpuesto.Text = Math.Round(FiniquitoFiscal.TotalAntesImpuestos, 2).ToString("C")
        txtResumenISRRetenido.Text = Math.Round(FiniquitoFiscal.ISRRetenido, 2).ToString("C")
        txtResumenNetoRecibir.Text = Math.Round(FiniquitoFiscal.NetoRecibir, 2).ToString("C")

        dtmFechaBaja.Value = FiniquitoFiscal.FechaBaja

    End Sub





    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim mensajeConfirmacion As New ConfirmarForm
        Dim objFiniquito As New Contabilidad.Negocios.FiniquitoFiscalBU()

        Try
            mensajeConfirmacion.mensaje = "¿Está seguro de guardar el Finquito? Posteriormente no podrá realizar cambios."
            FiniquitoFiscal.SolicitudBajaID = SolicitudBajaID
            FiniquitoFiscal.ColaboradorID = ColaboradorID
            FiniquitoFiscal.UsuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            FiniquitoFiscal.FechaCreacion = Date.Now
            FiniquitoFiscal.DiasAguinaldo = 15
            FiniquitoFiscal.TotalAntesImpuestos = TotalAntesImpuestos
            FiniquitoFiscal.NetoRecibir = NetoREcibir
            FiniquitoFiscal.FinquitoFiscalID = FinquitoFiscalID
            FiniquitoFiscal.IndemizacionFiniquito = txtResumenIndemizacionFiniquito.Text
            If mensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                If FinquitoFiscalID = -1 Then
                    objFiniquito.GuardarFiniquitoFiscal(FiniquitoFiscal)
                Else
                    objFiniquito.EditarFiniquitoFiscal(FiniquitoFiscal)
                End If
                Dim exito As New ExitoForm
                exito.mensaje = "Se ha guardado el Finiquito Exitosamente"
                exito.ShowDialog()

                Me.Close()
            End If

          
        Catch ex As Exception
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "Algo surgió mal durante el proceso, favor de intentar nuevamente"
            advertencia.ShowDialog()
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtResumenIndemizacionFiniquito_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtResumenIndemizacionFiniquito.KeyPress
        Dim EsDoblePunto As Boolean = False
        Dim EsNumero As Boolean = False

        If e.KeyChar = "." Then
            If txtResumenIndemizacionFiniquito.Text.Contains(".") = True Then
                EsDoblePunto = True
            End If
        End If
        
        If Not (IsNumeric(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = ChrW(Keys.Back)) Then            
            e.Handled = True
            EsNumero = False
        Else
            EsNumero = True
        End If
        If EsNumero = True Then
            If EsDoblePunto = True Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub txtResumenIndemizacionFiniquito_TextChanged(sender As Object, e As EventArgs) Handles txtResumenIndemizacionFiniquito.TextChanged
        TotalAntesImpuestos = FiniquitoFiscal.TotalAntesImpuestos
        NetoREcibir = FiniquitoFiscal.NetoRecibir
        ' txtResumenIndemizacionFiniquito.Text = "cdena"
        '•	Neto a Recibir: Total antes de impuestos – ISR retenido
        Dim total As String = ""
        If IsNumeric(txtResumenIndemizacionFiniquito.Text) = True Then
            TotalAntesImpuestos = TotalAntesImpuestos + CDbl(txtResumenIndemizacionFiniquito.Text)
            txtResumenTotalAntesImpuesto.Text = TotalAntesImpuestos.ToString("C2")
            NetoREcibir = NetoREcibir + CDbl(txtResumenIndemizacionFiniquito.Text).ToString("C2")
            txtResumenNetoRecibir.Text = NetoREcibir.ToString("C2")
        Else
            txtResumenTotalAntesImpuesto.Text = TotalAntesImpuestos.ToString("C2")
            txtResumenNetoRecibir.Text = NetoREcibir.ToString("C2")
        End If


        'Dim Indemizacion As Double = 0
        'If IsNumeric(txtResumenIndemizacionFiniquito.Text) = True Then
        '    Indemizacion = CDbl(txtResumenIndemizacionFiniquito.Text)
        '    txtResumenIndemizacionFiniquito.Text = Indemizacion.ToString("C2")
        'End If

    End Sub

    Private Sub btnEditarFiniquito_Click(sender As Object, e As EventArgs) Handles btnEditarFiniquito.Click
        txtResumenIndemizacionFiniquito.Enabled = True
        btnGuardar.Enabled = True
    End Sub
End Class