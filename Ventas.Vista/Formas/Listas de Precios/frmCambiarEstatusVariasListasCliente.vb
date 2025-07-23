Public Class frmCambiarEstatusVariasListasCliente
    Public idEstatusOriginal As Int32 = 0
    Public EstatusOriginalCad As String = ""
    Public contCambios As Int32 = 0
    Public nuevoEstatus As Int32 = 0
    Public listasSeleccionadas As Int32 = 0

    Public Sub llenarComboEstatusNuevo()
        If idEstatusOriginal = "25" Then
            llenarComboEstatus("26, 27")
        ElseIf idEstatusOriginal = "26" Then
            llenarComboEstatus("28")
        ElseIf idEstatusOriginal = "27" Or idEstatusOriginal = "28" Then
            llenarComboEstatus("")
        End If
    End Sub

    Public Sub llenarComboEstatus(ByVal estatus As String)
        Dim objLVC As New Negocios.ListaPreciosVentaClienteBU
        Dim dtEstatus As New DataTable
        dtEstatus = objLVC.consultaEstatusListaVentasClientePrecios(estatus)
        dtEstatus.Rows.InsertAt(dtEstatus.NewRow, 0)
        cmbNuevoEstatus.DataSource = dtEstatus
        cmbNuevoEstatus.DisplayMember = "esta_nombre"
        cmbNuevoEstatus.ValueMember = "esta_estatusid"
    End Sub


    Private Sub frmCambiarEstatusVariasListasCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblContador.Text = contCambios.ToString
        txtEstatusAnterior.Text = EstatusOriginalCad
        llenarComboEstatusNuevo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objMensajeExito As New Tools.ConfirmarForm
        objMensajeExito.mensaje = "¿Está seguro de cambiar el estatus de las listas de precios seleccionadas?"
        If cmbNuevoEstatus.SelectedIndex > 0 Then
            If objMensajeExito.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim objCaptcha As New Tools.frmCaptcha
                objCaptcha.mensaje = "Listas Seleccionadas: " + listasSeleccionadas.ToString
                If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    Me.DialogResult = Windows.Forms.DialogResult.None
                End If
            Else
                Me.DialogResult = Windows.Forms.DialogResult.None
            End If
        Else
            Dim objMensaje As New Tools.AvisoForm
            objMensaje.mensaje = "Debe seleccionar un estatus."
            objMensaje.ShowDialog()
            Me.DialogResult = Windows.Forms.DialogResult.None
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      
    End Sub

    Private Sub cmbNuevoEstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNuevoEstatus.SelectedIndexChanged
        If cmbNuevoEstatus.SelectedIndex > 0 Then
            nuevoEstatus = cmbNuevoEstatus.SelectedValue
        Else
            nuevoEstatus = 0
        End If
    End Sub
End Class