Public Class DevolucionCliente_CancelarDevolucion_Form

    Public ObjDev As New Entidades.DevolucionCliente

    Public Sub InicializarComboMotivos()
        Dim objNegocio As New Negocios.DevolucionClientesBU
        Dim lista As New DataTable

        lista = objNegocio.ListadoMotivos("DEVOLUCION_CLIENTE_MOTIVO_CANCELACION")

        ' Si la consulta devuelve uno o más registros se hace la asignación de los valores al combo
        If lista.Rows.Count > 0 Then
            ' Se asigna como dataSource del combo el resultado de la consulta
            Dim newRow As DataRow = lista.NewRow
            lista.Rows.InsertAt(newRow, 0)

            cmbMotivoCancelacion.DataSource = lista
            cmbMotivoCancelacion.DisplayMember = "Motivo"
            cmbMotivoCancelacion.ValueMember = "esta_estatusid"
            cmbMotivoCancelacion.SelectedIndex = 0
        End If
    End Sub

    Public Sub CancelarDevolucion()
        If cmbMotivoCancelacion.SelectedValue IsNot Nothing Then
            If cmbMotivoCancelacion.SelectedIndex = 0 Then
                Dim ventanaAdvertencia As New Tools.AdvertenciaForm
                ventanaAdvertencia.mensaje = "Seleccione un motivo de cancelación"
                ventanaAdvertencia.ShowDialog()
                lblMotivoCancelacion.ForeColor = Color.Red
                Return
            Else
                lblMotivoCancelacion.ForeColor = Color.Black
            End If
        Else
            Dim ventanaAdvertencia As New Tools.AdvertenciaForm
            ventanaAdvertencia.mensaje = "Seleccione un motivo de cancelación"
            ventanaAdvertencia.ShowDialog()
            lblMotivoCancelacion.ForeColor = Color.Red
            Return
        End If

        If txtObservaciones.Text.Trim.Length = 0 Then
            txtObservaciones.Text = ""
            lblObservaciones.ForeColor = Color.Red
            Dim ventanaAdvertencia As New Tools.AdvertenciaForm
            ventanaAdvertencia.mensaje = "Los campos marcados con * son obligatorios"
            ventanaAdvertencia.ShowDialog()
            Return
        Else
            lblObservaciones.ForeColor = Color.Black
        End If

        Dim ventanaConfirmacion As New Tools.ConfirmarForm
        ventanaConfirmacion.mensaje = "¿Está seguro de cancelar la devolución?"
        ventanaConfirmacion.ShowDialog()
        If ventanaConfirmacion.DialogResult = DialogResult.OK Then
            Dim negocios As New Negocios.DevolucionClientesBU
            Dim dtResultado As New DataTable
            dtResultado = negocios.CancelarDevolucion(ObjDev.Devolucionclienteid, cmbMotivoCancelacion.SelectedValue, nudCantidadPares.Value, txtObservaciones.Text, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            If dtResultado.Columns.Count > 1 Then
                Dim ventanaError As New Tools.ErroresForm
                ventanaError.mensaje = "Ocurrió un error inténtelo de nuevo"
                ventanaError.ShowDialog()
            Else
                Dim ventanaExtio As New Tools.ExitoForm
                ventanaExtio.mensaje = "Se ha cancelado la devolución con Folio " + ObjDev.Devolucionclienteid.ToString + " del cliente " + ObjDev.NombreCliente.ToString
                ventanaExtio.ShowDialog()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub DevolucionCliente_CancelarDevolucion_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ObjDev IsNot Nothing Then
            InicializarComboMotivos()

            lblCliente.Text = ObjDev.NombreCliente
            lblFolioDev.Text = ObjDev.Devolucionclienteid
            nudCantidadPares.Maximum = ObjDev.Cantidadtotal
            nudCantidadPares.Value = ObjDev.Cantidadtotal
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        CancelarDevolucion()
    End Sub
End Class