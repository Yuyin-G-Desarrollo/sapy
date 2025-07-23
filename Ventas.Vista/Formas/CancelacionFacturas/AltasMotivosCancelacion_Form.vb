Public Class AltasMotivosCancelacion_Form
    Dim objMensajeValido As New Tools.AvisoForm
    Dim objMensajeError As New Tools.ErroresForm
    Dim objMensajeExito As New Tools.ExitoForm

    Public motivoID As Integer = 0
    Public accion As Integer = 0


    Private Sub AltasMotivosCancelacion_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If accion = 2 Then 'EDITAR
            Dim objBU As New Ventas.Negocios.SolicitarCancelacionBU
            Dim dtResultado As New DataTable

            dtResultado = objBU.ConsultarMotivosInternoEditar(motivoID)
            If dtResultado.Rows.Count > 0 Then

                txtMotivo.Text = dtResultado.Rows(0).Item("motivo").ToString
                If (dtResultado.Rows(0).Item("seRelaciona")) Then
                    rbnSi.Checked = True
                Else
                    rbnNo.Checked = True
                End If

                LLenarComboCancelacionesSAT() '' poner el idice que ya tiene
                cmbCancelacionSat.SelectedValue = dtResultado.Rows(0).Item("idMotivoSat").ToString

                If (dtResultado.Rows(0).Item("activo")) Then
                    rbtActivoSi.Checked = True
                Else
                    rbtActivoNo.Checked = True
                End If

            End If
        Else
            LimpiarCampos()
            LLenarComboCancelacionesSAT()
        End If

    End Sub

    Public Sub LLenarComboCancelacionesSAT()
        Try
            Dim objBU As New Ventas.Negocios.SolicitarCancelacionBU
            Dim dtResultado As New DataTable
            dtResultado = objBU.ConsultarMotivosSAT
            If dtResultado.Rows.Count > 0 Then
                cmbCancelacionSat.DataSource = dtResultado
                cmbCancelacionSat.DisplayMember = "motivoSat"
                cmbCancelacionSat.ValueMember = "idMotivoSat"
            End If
        Catch ex As Exception
            objMensajeValido.Text = "Error"
            objMensajeValido.mensaje = "ERROR:" + ex.Message.ToString
            objMensajeValido.ShowDialog()
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Guardar()

    End Sub

    Private Sub Guardar()
        If ValidarCampos() Then
            Try
                Dim dtResultado As New DataTable
                Dim objBU As New Ventas.Negocios.SolicitarCancelacionBU

                Dim motivo As String = String.Empty
                Dim seRelaciona As Boolean = False
                Dim motivoSat As Integer = 0
                Dim activo As Boolean = False

                motivo = txtMotivo.Text
                seRelaciona = If(rbnSi.Checked, 1, 0)
                motivoSat = cmbCancelacionSat.SelectedValue
                activo = If(rbtActivoSi.Checked, 1, 0)

                If motivoID > 0 Then
                    dtResultado = objBU.EditarMotivoCancelacion(motivo, seRelaciona, motivoSat, activo, motivoID)
                Else
                    dtResultado = objBU.InsertarMotivoCancelacion(motivo, seRelaciona, motivoSat, activo)
                End If

                If dtResultado.Rows(0).Item("respuesta").ToString = "Error" Then
                    objMensajeError.Text = "Error"
                    objMensajeError.mensaje = "Ocurrio un error al guardar, intente de nuevo."
                    objMensajeError.ShowDialog()
                Else
                    objMensajeExito.Text = "Exito"
                    objMensajeExito.mensaje = dtResultado.Rows(0).Item("respuesta").ToString()
                    objMensajeExito.ShowDialog()
                    LimpiarCampos()
                    Me.Close()
                    'Dim FormularioMotivosCancelacion As New AdministradorMotivosCancelacion_Form
                    'FormularioMotivosCancelacion.btnAceptar_Click(Nothing, Nothing)
                    'FormularioMotivosCancelacion.Show()

                End If

            Catch ex As Exception
                objMensajeError.Text = "Error"
                objMensajeValido.mensaje = "Ocurrio un error al guardar, intente de nuevo."
                objMensajeValido.ShowDialog()
            End Try


        Else
            objMensajeValido.Text = "Aviso"
            objMensajeValido.mensaje = "Los campos de Motivo y Motivo Sat no deben estar vacíos."
            objMensajeValido.ShowDialog()
        End If
    End Sub

    Private Function ValidarCampos() As Boolean
        Dim camposCorrectos As Boolean = 0
        If txtMotivo.TextLength > 0 Then
            camposCorrectos = 1
            If cmbCancelacionSat.SelectedValue > 0 Then
                camposCorrectos = 1
            Else
                lblNave.ForeColor = Color.Red
                camposCorrectos = 0
            End If
        Else
            camposCorrectos = 0
            lblMotivo.ForeColor = Color.Red

        End If



        Return camposCorrectos

    End Function

    Public Sub LimpiarCampos()
        txtMotivo.Text = ""
        cmbCancelacionSat.SelectedItem = 0
        cmbCancelacionSat.Text = ""
    End Sub

    Private Sub btnCncelar_Click(sender As Object, e As EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub txtMotivo_TextChanged(sender As Object, e As EventArgs) Handles txtMotivo.TextChanged
        txtMotivo.Text = txtMotivo.Text.ToUpper
        txtMotivo.SelectionStart = txtMotivo.Text.Length
    End Sub

    Private Sub AltasMotivosCancelacion_Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.F5 Then
            Guardar()
        End If
        If e.KeyData = Keys.Escape Then
            Dim confirmar As New ConfirmarForm
            confirmar.mensaje = "¿Está seguro de cerrar la ventana?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If
        End If


    End Sub
End Class