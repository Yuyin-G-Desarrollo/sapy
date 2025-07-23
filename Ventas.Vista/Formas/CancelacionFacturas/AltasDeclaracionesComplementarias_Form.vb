Public Class AltasDeclaracionesComplementarias_Form

    Dim objMensajeValido As New Tools.AvisoForm
    Dim objMensajeError As New Tools.ErroresForm
    Dim objMensajeExito As New Tools.ExitoForm
    Private Sub AltasDeclaracionesComplementarias_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LLenarComboMeses()
        LLenarComboEmpresas()
    End Sub
    Public Sub LLenarComboMeses()
        cmbMes.Items.Add(" ")
        cmbMes.Items.Add("ENERO")
        cmbMes.Items.Add("FEBRERO")
        cmbMes.Items.Add("MARZO")
        cmbMes.Items.Add("ABRIL")
        cmbMes.Items.Add("MAYO")
        cmbMes.Items.Add("JUNIO")
        cmbMes.Items.Add("JULIO")
        cmbMes.Items.Add("AGOSTO")
        cmbMes.Items.Add("SEPTIEMBRE")
        cmbMes.Items.Add("OCTUBRE")
        cmbMes.Items.Add("NOVIEMBRE")
        cmbMes.Items.Add("DICIEMBRE")
    End Sub

    Public Sub LLenarComboEmpresas()
        Try
            Dim objBU As New Ventas.Negocios.SolicitarCancelacionBU
            Dim dtEmpresas As New DataTable

            dtEmpresas = objBU.ConsultarEmpresas()
            dtEmpresas.Rows.InsertAt(dtEmpresas.NewRow(), 0)

            If dtEmpresas.Rows.Count > 0 Then
                cmbEmpresa2.DataFilter = New MyDataFilter()
                cmbEmpresa2.DataSource = dtEmpresas
                cmbEmpresa2.DisplayMember = "RazonSocial"
                cmbEmpresa2.ValueMember = "empresaID"


            End If
            DtpFechaDeclaracion.Value = Now.Date()
        Catch ex As Exception
            objMensajeValido.Text = "Error"
            objMensajeValido.mensaje = "ERROR:" + ex.Message.ToString
            objMensajeValido.ShowDialog()
        End Try
    End Sub

    Public Class MyDataFilter
        Implements Infragistics.Win.IEditorDataFilter

        Public Function Convert(ByVal convertArgs As Infragistics.Win.EditorDataFilterConvertArgs) As Object Implements Infragistics.Win.IEditorDataFilter.Convert
            ' Shouldn't affect anything?
            convertArgs.Handled = False
            Return Nothing
        End Function
    End Class

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Guardar()
    End Sub
    Public Sub Guardar()
        If ValidarCampos() Then


            Dim dtResultado As New DataTable
            Dim objBU As New Ventas.Negocios.SolicitarCancelacionBU

            Dim empresa As Integer = 0
            Dim mesEjercicio As String = ""
            Dim fechaDeclaracion As DateTime
            Dim FechaD As String = ""

            empresa = cmbEmpresa2.Value
            mesEjercicio = cmbMes.SelectedItem.ToString


            fechaDeclaracion = DtpFechaDeclaracion.Value.ToShortDateString
            FechaD = fechaDeclaracion.ToString("dd/MM/yyyy")

            dtResultado = objBU.InsertarDeclaracionComplementaria(empresa, mesEjercicio, FechaD)

            If dtResultado.Rows(0).Item("respuesta").ToString = "Error" Then
                objMensajeError.Text = "Error"
                objMensajeError.mensaje = "Ocurrio un error al guardar, intente de nuevo."
                objMensajeError.ShowDialog()
            Else
                objMensajeExito.Text = "Exito"
                objMensajeExito.mensaje = dtResultado.Rows(0).Item("respuesta").ToString()
                objMensajeExito.ShowDialog()
                Me.Close()
            End If
        End If
    End Sub


    Private Function ValidarCampos() As Boolean
        Dim camposOK As Boolean = 0
        If cmbEmpresa2.Value > 0 Then
            If cmbMes.SelectedIndex > 0 Then
                camposOK = 1
            Else
                objMensajeValido.Text = "Error"
                objMensajeValido.mensaje = "Seleccione un mes"
                cmbMes.SelectedIndex = 0
                lblMes.ForeColor = Color.Red
                objMensajeValido.ShowDialog()
            End If

        Else
            objMensajeValido.Text = "Error"
            objMensajeValido.mensaje = "Seleccione una empresa"
            cmbEmpresa2.SelectedIndex = 0
            lblEmpresa.ForeColor = Color.Red
            objMensajeValido.ShowDialog()
        End If

        If camposOK Then
            ''validar si ya hay 3 declaraciones del mes  error 
            Dim objBU As New Ventas.Negocios.SolicitarCancelacionBU
            Dim dtTotalDeclaraciones As New DataTable

            dtTotalDeclaraciones = objBU.ConsultarDeclaracionesPorMes(cmbMes.SelectedItem, cmbEmpresa2.Value)

            If dtTotalDeclaraciones.Rows(0).Item("total") >= 3 Then
                objMensajeValido.Text = "Error"
                objMensajeValido.mensaje = "No es posible registrar una cuarta declaración complementaria por mes."
                objMensajeValido.ShowDialog()
                LimpiarCampos()
                camposOK = 0
            End If

        End If
        Return camposOK

    End Function

    Public Sub LimpiarCampos()

        cmbEmpresa2.SelectedIndex = 0
        cmbMes.SelectedIndex = 0
        DtpFechaDeclaracion.Value = Date.Now
    End Sub

    Private Sub btnCncelar_Click(sender As Object, e As EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub AltasDeclaracionesComplementarias_Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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