Imports Tools

Public Class DevolucionCliente_CatalogosMotivos_AltaEdicion_Form
    Public altaEdicion As Boolean
    Public estatusid As Int32
    Public tipoMotivo As String
    Public nombreMotivo As String
    Public descripcion As String
    Public activo As Boolean


    Public Function validarVacios() As Boolean
        Dim vacios As Boolean = False
        If cboTipoMotivo.SelectedValue.ToString.Length > 0 And cboTipoMotivo.SelectedValue.ToString <> "" Then
            lblTipoMotivo.ForeColor = Color.Black
        Else
            lblTipoMotivo.ForeColor = Color.Red
            vacios = True
        End If

        If (txtNombreMotivo.Text).Trim() <> "" Then
            lblMotivo.ForeColor = Color.Black
        Else
            lblMotivo.ForeColor = Color.Red
            vacios = True
        End If

        If (txtDescripcion.Text).Trim() <> "" Then
            lblDescripcion.ForeColor = Color.Black
        Else
            lblDescripcion.ForeColor = Color.Red
            vacios = True
        End If
        Return vacios
    End Function

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        'Validamos que los campos marcados con * no estén vacíos
        Dim camposVacios As Boolean = validarVacios()
        If camposVacios = False Then
            tipoMotivo = cboTipoMotivo.SelectedValue.ToString
            nombreMotivo = txtNombreMotivo.Text
            descripcion = txtDescripcion.Text
            If rdoActivo.Checked = True Then
                activo = True
            ElseIf rdoInactivo.Checked = True Then
                activo = False
            End If
            Dim objBU As New Negocios.DevolucionClientesBU

            If altaEdicion = True Then
                objBU.RegistrarMotivo(tipoMotivo, nombreMotivo, descripcion, activo)
                Dim FormularioMensaje As New Tools.ExitoForm
                FormularioMensaje.mensaje = "Registro guardado"
                FormularioMensaje.ShowDialog()
            Else
                objBU.EditarMotivo(estatusid, tipoMotivo, nombreMotivo, descripcion, activo)
                Dim FormularioMensaje As New Tools.ExitoForm
                FormularioMensaje.mensaje = "Registro guardado"
                FormularioMensaje.ShowDialog()
            End If
            Me.Close()
        Else
            Dim FormularioError As New ErroresForm
            FormularioError.mensaje = "Campos vacíos"
            FormularioError.ShowDialog()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    Public Sub InicializarCombo()
        Dim dtMotivos As New DataTable
        Dim columna As New DataColumn
        columna.Caption = "Motivo"
        columna.ColumnName = "Motivo"
        columna.DataType = GetType(String)
        columna.Unique = False
        columna.AllowDBNull = True
        dtMotivos.Columns.Add(columna)

        columna = New DataColumn
        columna.Caption = "Etiqueta"
        columna.ColumnName = "Etiqueta"
        columna.DataType = GetType(String)
        columna.Unique = False
        columna.AllowDBNull = True
        dtMotivos.Columns.Add(columna)

        Dim fila As DataRow = dtMotivos.NewRow
        dtMotivos.Rows.InsertAt(fila, 0)

        fila = dtMotivos.NewRow
        fila(0) = "DEVOLUCION_CLIENTE_MOTIVO_INICIAL_CALIDAD"
        fila(1) = "MOTIVO INICIAL CALIDAD"
        dtMotivos.Rows.Add(fila)

        fila = dtMotivos.NewRow
        fila(0) = "DEVOLUCION_CLIENTE_MOTIVO_INICIAL_MOTIVOSADMINISTRATIVOS"
        fila(1) = "MOTIVO INICIAL (MOTIVOS ADMINISTRATIVOS)"
        dtMotivos.Rows.Add(fila)

        fila = dtMotivos.NewRow
        fila(0) = "DEVOLUCION_CLIENTE_MOTIVO_VENTAS_CALIDAD"
        fila(1) = "MOTIVO VENTAS CALIDAD"
        dtMotivos.Rows.Add(fila)

        fila = dtMotivos.NewRow
        fila(0) = "DEVOLUCION_CLIENTE_MOTIVO_VENTAS_MOTIVOSADMINISTRATIVOS"
        fila(1) = "MOTIVO VENTAS (MOTIVOS ADMINISTRATIVOS)"
        dtMotivos.Rows.Add(fila)

        fila = dtMotivos.NewRow
        fila(0) = "DEVOLUCION_CLIENTE_MOTIVO_CANCELACIÓN"
        fila(1) = "MOTIVO CANCELACIÓN"
        dtMotivos.Rows.Add(fila)

        cboTipoMotivo.DataSource = dtMotivos
        cboTipoMotivo.DisplayMember = "Etiqueta"
        cboTipoMotivo.ValueMember = "Motivo"
    End Sub

    Private Sub DevolucionCliente_CatalogosMotivos_AltaEdicion_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'validamos que sí presiono el boton de editar llene el cuadro de texto y seleccione el radiobutton
        InicializarCombo()
        If altaEdicion = False Then
            cboTipoMotivo.Text = tipoMotivo
            txtNombreMotivo.Text = nombreMotivo
            txtDescripcion.Text = descripcion
            rdoActivo.Checked = activo
        End If
    End Sub
End Class