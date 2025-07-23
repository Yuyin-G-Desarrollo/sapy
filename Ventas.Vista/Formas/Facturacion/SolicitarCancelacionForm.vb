Imports Tools
Public Class SolicitudCancelacion
    Public entCliente As Entidades.Cliente
    Public DocumentoID As Integer = 0
    Public Folio As String = ""
    Public MetodoPago As String = ""
    Public RfcEmisor As String = ""
    Public RfcReceptor As String = ""
    Public RfcEmisorID As Integer = 0
    Public RfcReceptorID As Integer = 0
    Public Cliente As String = ""

    Public PrimerLoad As Boolean = False

    Dim objBU As New Negocios.SolicitarCancelacionBU
    Dim mensajeError As New AdvertenciaForm
    Dim confirmar As New ConfirmarForm
    Private Sub SolicitarCancelacionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDocumentoid.Text = Folio
        txtMetodoPago.Text = MetodoPago
        txtRfcEmisor.Text = RfcEmisor
        txtRfcReceptor.Text = RfcReceptor
        txtSolicita.Text = entCliente.nombregenerico
        inicializarComponentes()
        PrimerLoad = True
    End Sub

    Public Sub inicializarComponentes()
        txtMetodoPago.Enabled = False
        txtRfcEmisor.Enabled = False
        txtRfcReceptor.Enabled = False
        txtSolicita.Enabled = False
        cmbInterno.Visible = False
        rbtnSustitucionSI.Enabled = False
        rbtnSustitucionNO.Enabled = False
        rbtnMismoEmisorReceptorSI.Enabled = False
        rbtnMismoEmisorReceptorNO.Enabled = False
        llenarComboMotivos()
    End Sub

    Private Sub llenarComboMotivos()

        'Dim cancelacionConRelacion As Boolean = 0

        'If rbtnSustitucionSI.Checked = True And rbtnMismoEmisorReceptorSI.Checked = True Then
        '    cancelacionConRelacion = 1
        'Else
        '    cancelacionConRelacion = 0
        'End If
        Dim dtMotivos As New DataTable

        dtMotivos = objBU.ConsultarMotivosInternos()

        If dtMotivos.Rows.Count > 0 Then
            cmbMotivoInterno.DataSource = dtMotivos
            cmbMotivoInterno.DisplayMember = "descripcion"
            cmbMotivoInterno.ValueMember = "idMotivo"
        End If
    End Sub

    Private Sub llenarComboSolicitaInterno()
        Dim dtColaboradores As New DataTable


        dtColaboradores = objBU.ConsultarColaboradores()

        If dtColaboradores.Rows.Count > 0 Then
            'cmbSolicitaInterno.DataSource = dtColaboradores
            'cmbSolicitaInterno.DisplayMember = "nombreCompleto"
            'cmbSolicitaInterno.ValueMember = "idColaborador"

            cmbInterno.DataFilter = New MyDataFilter()
            cmbInterno.DataSource = dtColaboradores
            cmbInterno.DisplayMember = "nombreCompleto"
            cmbInterno.ValueMember = "idColaborador"

        End If

    End Sub
    Public Class MyDataFilter
        Implements Infragistics.Win.IEditorDataFilter

        Public Function Convert(ByVal convertArgs As Infragistics.Win.EditorDataFilterConvertArgs) As Object Implements Infragistics.Win.IEditorDataFilter.Convert
            ' Shouldn't affect anything?
            convertArgs.Handled = False
            Return Nothing
        End Function
    End Class

    Private Sub rbtnCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnCliente.CheckedChanged
        txtSolicita.Enabled = False
        txtSolicita.Visible = True

        cmbInterno.Visible = False
    End Sub

    Private Sub rbtnInterna_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnInterna.CheckedChanged
        'txtSolicita.Enabled = False
        'txtSolicita.Text = ""
        txtSolicita.Visible = False
        cmbInterno.Visible = True
        llenarComboSolicitaInterno()

    End Sub

    Private Sub rbtnSustitucionSI_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSustitucionSI.CheckedChanged
        'rbtnMismoEmisorReceptorSI.Checked = True
        'llenarComboMotivos()
    End Sub

    Private Sub rbtnSustitucionNO_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSustitucionNO.CheckedChanged
        'rbtnMismoEmisorReceptorNO.Checked = True
        'llenarComboMotivos()
    End Sub

    Private Sub rbtnMismoEmisorReceptorNO_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnMismoEmisorReceptorNO.CheckedChanged
        'rbtnSustitucionNO.Checked = True
        'llenarComboMotivos()
    End Sub

    Private Sub rbtnMismoEmisorReceptorSI_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnMismoEmisorReceptorSI.CheckedChanged
        'rbtnSustitucionSI.Checked = True
        'llenarComboMotivos()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim dtResultadoInsertCancelacion As New DataTable


        Dim validacionesCampos As Boolean = 1

        ''validar todos los campos a enviar 
        ''validar si el documento ya cuenta con una solicitud pendiente 
        Dim dtCancelacionesPendiente As New DataTable
        dtCancelacionesPendiente = objBU.ConsultarSolicitudesPendientes(DocumentoID)
        If (dtCancelacionesPendiente.Rows(0).Item("TOTAL")) > 0 Then
            mensajeError.MdiParent = Me.MdiParent
            mensajeError.mensaje = "El documento tiene una solicitud pendiente."
            mensajeError.Show()
            validacionesCampos = 0
        End If
        If rbtnInterna.Checked Then
            If cmbInterno.Value Is Nothing Then
                validacionesCampos = 0
                lblSolicita.ForeColor = Color.Red
            End If
        End If


        If validacionesCampos Then
            Dim metodoPago As String = txtMetodoPago.Text
            Dim razonsocialemisorid As Integer = RfcEmisorID
            Dim razonsocialreceptorid As Integer = RfcReceptorID
            Dim nombreSolicita As String = ""
            Dim solicitaColaboradorId As Integer
            Dim quienSolicita As Boolean = 0
            If rbtnCliente.Checked Then
                quienSolicita = 1 'Cliente
                nombreSolicita = txtSolicita.Text
            Else
                solicitaColaboradorId = cmbInterno.Value
            End If


            Dim facturaRequiereSustitucion As Boolean = 0

            If rbtnSustitucionSI.Checked Then
                facturaRequiereSustitucion = 1
            End If

            Dim facturaMismoEmisorReceptor As Boolean = 0

            If rbtnMismoEmisorReceptorSI.Checked Then
                facturaMismoEmisorReceptor = 1
            End If
            Dim motivoInternoid As Integer = cmbMotivoInterno.SelectedValue
            Dim seRelaciona As Boolean = 0

            If rbtnSustitucionSI.Checked And rbtnMismoEmisorReceptorSI.Checked Then
                seRelaciona = 1
            End If
            Dim observacion As String = txtObservaciones.Text

            dtResultadoInsertCancelacion = objBU.InsertarSolicitudCancelacionFactura(DocumentoID, metodoPago, razonsocialemisorid, razonsocialreceptorid, quienSolicita, facturaRequiereSustitucion, facturaMismoEmisorReceptor, motivoInternoid, seRelaciona, observacion, nombreSolicita, solicitaColaboradorId)

            If dtResultadoInsertCancelacion.Rows(0).Item("respuesta").ToString() = "Error" Then
                Dim mensajeError As New AdvertenciaForm
                mensajeError.MdiParent = Me.MdiParent
                mensajeError.mensaje = "Ocurrió un error al guardar, intente de nuevo."
                mensajeError.Show()
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Exito, dtResultadoInsertCancelacion.Rows(0).Item("respuesta").ToString())
                Me.Close()
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El campo de colaborador no puede esta vacío")
        End If


    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub txtObservaciones_TextChanged(sender As Object, e As EventArgs) Handles txtObservaciones.TextChanged
        txtObservaciones.Text = txtObservaciones.Text.ToUpper
        txtObservaciones.SelectionStart = txtObservaciones.Text.Length
    End Sub





    'Private Sub cmbSolicitaInterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbSolicitaInterno.KeyPress ''cuando se preciona una tecla de espacio y retroceso


    'End Sub

    'Protected Overrides Function ProcessCmdKey(
    'ByRef msg As System.Windows.Forms.Message,
    'ByVal keyData As System.Windows.Forms.Keys) As Boolean

    '    ' ¿Tiene el foco el control ComboBox?
    '    '
    '    If cmbSolicitaInterno.Focused Then
    '        If keyData = Keys.Enter Then
    '            MessageBox.Show("Se ha pulsado la tecla Enter.")
    '        End If
    '    End If

    '    Return MyBase.ProcessCmdKey(msg, keyData)

    'End Function

    Private Sub cmbSolicitaInterno_DragEnter(sender As Object, e As DragEventArgs)
        Console.WriteLine("DragEnter")
    End Sub

    Private Sub cmbInterno_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbInterno.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim FrmColaboradores As New Colaboradores_Form
            FrmColaboradores.ShowDialog()
            cmbInterno.Value = FrmColaboradores.idColaborador
            'cmbInterno.Set = FrmColaboradores.nombreColaborador
        End If
    End Sub

    Private Sub SolicitudCancelacion_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyData = Keys.Escape Then
            confirmar.mensaje = "¿Está seguro de cerrar la ventana?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If
        End If

    End Sub

    Private Sub cmbMotivoInterno_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMotivoInterno.SelectedValueChanged
        If PrimerLoad Then
            cargarValoresRadio(cmbMotivoInterno.SelectedValue)
        End If

    End Sub

    Private Sub cargarValoresRadio(motivoid As Integer)
        Dim dtMotivos As New DataTable
        Dim seRelaciona As Boolean
        Dim mismoEmisorReceptor As Boolean

        dtMotivos = objBU.ConsultarMotivosInternos(motivoid)
        If dtMotivos.Rows.Count > 0 Then
            seRelaciona = dtMotivos.Rows(0).Item("seRelaciona")
            mismoEmisorReceptor = dtMotivos.Rows(0).Item("mismoemisorreceptor")

            If seRelaciona Then
                rbtnSustitucionSI.Checked = True
                rbtnSustitucionNO.Checked = False
            Else
                rbtnSustitucionSI.Checked = False
                rbtnSustitucionNO.Checked = True
            End If

            If mismoEmisorReceptor Then
                rbtnMismoEmisorReceptorSI.Checked = True
                rbtnMismoEmisorReceptorNO.Checked = False
            Else
                rbtnMismoEmisorReceptorSI.Checked = False
                rbtnMismoEmisorReceptorNO.Checked = True
            End If
        End If

    End Sub
End Class