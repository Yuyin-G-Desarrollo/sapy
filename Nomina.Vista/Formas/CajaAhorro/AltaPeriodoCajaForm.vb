Imports Tools

Public Class AltaPeriodoCajaForm
    Private Nave As New Entidades.Naves
    Public IdNave As Int32 = 7


    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click

        Dim resultado As String = String.Empty

        resultado = Validar()
        If resultado.Length = 0 Then
            'If MessageBox.Show("Desea guardar la informacion", "Confirmar Operacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            '    Guardar()
            'End If
            Dim MensajeConfirmacion As New ConfirmarForm
            MensajeConfirmacion.mensaje = "¿ Desea guarda la información ?"
            MensajeConfirmacion.Text = "Confirmar Operación"
            MensajeConfirmacion.StartPosition = FormStartPosition.CenterScreen
            If MensajeConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Guardar()
            End If
        Else
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = resultado.ToString
            mensajeAdvertencia.ShowDialog()
        End If



    End Sub

    Private Sub Guardar()

        Dim objCajaAhorro As New Entidades.CajaAhorro

        objCajaAhorro.pConcepto = txtConcepto.Text
        objCajaAhorro.pFechaFinal = dtpFechaFinal.Value
        objCajaAhorro.pFechaInicial = dtpFechaInicial.Value
        objCajaAhorro.pNave = Nave
        objCajaAhorro.pFechaInicialDeducciones = dtpInicialReporte.Value
        objCajaAhorro.PFechaFinalDeducciones = dtpFinalReporte.Value

        Dim objCajaahorroBU As New Nomina.Negocios.CajaAhorroBU

        objCajaahorroBU.AltaCajaAhorro(objCajaAhorro)


        If objCajaahorroBU.Resultado.Length > 0 Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = objCajaahorroBU.Resultado.ToString
            mensajeAdvertencia.ShowDialog()

        Else
            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "Transaccion exitosa"
            mensajeExito.ShowDialog()
            Me.Close()
        End If
    End Sub


    Private Sub PeriodoCajaForm_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp


        If e.KeyCode = Keys.Enter And Not (e.Alt Or e.Control) Then

            If Me.ActiveControl.GetType Is GetType(TextBox) Or Me.ActiveControl.GetType Is GetType(CheckBox) Or Me.ActiveControl.GetType Is GetType(DateTimePicker) Then
                If e.Shift Then
                    Me.ProcessTabKey(False)
                Else
                    Me.ProcessTabKey(True)
                End If
            End If
        End If


    End Sub

    Private Sub PeriodoCajaForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Inicializa()
        'Tools.FormatoCtrls.formato(Me)
    End Sub

    Private Sub btnRegresar_Click(sender As System.Object, e As System.EventArgs) Handles btnRegresar.Click
        Dim mensajeExito As New ConfirmarForm
        mensajeExito.mensaje = "¿Está seguro que quiere salir sin guardar cambios?"

        If mensajeExito.ShowDialog = DialogResult.OK Then
            Me.Close()
        End If
    End Sub


    Private Sub dtpFechaInicial_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaInicial.ValueChanged
        txtConcepto.Text = "CAJA DE AHORRO CORRESPONDIENTE AL PERIODO " + Format(dtpFechaInicial.Value, "dd/MMM/yyyy").ToUpper + " - " + Format(dtpFechaFinal.Value, "dd/MMM/yyyy").ToUpper
    End Sub

    Private Sub dtpFechaFinal_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaFinal.ValueChanged
        txtConcepto.Text = "CAJA DE AHORRO CORRESPONDIENTE AL PERIODO " + Format(dtpFechaInicial.Value, "dd/MMM/yyyy").ToUpper + " - " + Format(dtpFechaFinal.Value, "dd/MMM/yyyy").ToUpper
    End Sub

    Private Sub Inicializa()
        Dim objNave As New Framework.Negocios.NavesBU

        Nave = objNave.buscarNaves(IdNave)


        dtpFechaInicial.Value = Now
        dtpFechaFinal.Value = Now

        txtConcepto.Text = "CAJA DE AHORRO CORRESPONDIENTE AL PERIODO " + Format(dtpFechaInicial.Value, "dd/MMM/yyyy").ToUpper + " - " + Format(dtpFechaFinal.Value, "dd/MMM/yyyy").ToUpper
        lblNombreNave.Text = Nave.PNombre.ToUpper


    End Sub


    Private Function Validar() As String
        Validar = String.Empty


        If CDate(Format(dtpFechaInicial.Value, "dd/MM/yyyy").ToString) > CDate(Format(dtpFechaFinal.Value, "dd/MM/yyyy").ToString) Then
            Validar = "La fecha Inicial no puede ser mayor a la final"
        End If



    End Function

End Class