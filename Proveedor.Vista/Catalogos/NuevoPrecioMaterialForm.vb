Imports Tools
Imports System.Windows.Forms
Imports System.Drawing
Imports Proveedores.BU
Imports Entidades

Public Class NuevoPrecioMaterialForm

    Public precioMaterial As New PrecioMaterial
    Public idNave As Integer = 0
    Public cerrado As Boolean
    Dim sep As Char
    Public umc As String = ""
    Public idMaterial As String = ""
    Public umcEqui As String
    Dim advertencia As New AdvertenciaForm
    Public umpro As String = ""
    Public umprod As String = ""
    Public opmat As String = ""
    Public activo = 0
    Public nuevo = 0
    Public listaProveedores = 0
    Public lista As New List(Of Integer)
    Public naveDesarrolla As Boolean = False
    Public NombreNaveDesarrolla As String
    Public exclusivo As Boolean = False

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Private Sub NuevoMaterialForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarControles()
        If opmat <> "" Then
            If opmat = "N" Then
                cmbOrigen.Text = "NACIONAL"
            Else
                cmbOrigen.Text = "IMPORTADO"
            End If
        End If
        If umpro <> "" Then
            cmbProveedorUM.Text = umpro
        End If
        If umprod <> "" Then
            cmbProduccionUM.Text = umprod
        End If
        If naveDesarrolla = False Then
            btnGuardar.Enabled = False
            txtTiempoEntrega.Enabled = False
            txtPrecioUnitario.Enabled = False
            cmbMoneda.Enabled = False
            cmbProveedorUM.Enabled = False
            cmbProduccionUM.Enabled = False
            txtEquivUMProv.Enabled = False
            txtDesProv.Enabled = False
            txtClaveProv.Enabled = False
            cmbProveedor.Enabled = False
            'btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = True
            txtTiempoEntrega.Enabled = True
            txtPrecioUnitario.Enabled = True
            cmbMoneda.Enabled = True
            cmbProveedorUM.Enabled = True
            cmbProduccionUM.Enabled = True
            txtEquivUMProv.Enabled = True
            txtDesProv.Enabled = True
            txtClaveProv.Enabled = True
            cmbProveedor.Enabled = True
            cmbProveedor.Enabled = True
            btnGuardar.Enabled = True
        End If
        If nuevo = 1 Then
            btnGuardar.Enabled = True
            txtTiempoEntrega.Enabled = True
            txtPrecioUnitario.Enabled = True
            cmbMoneda.Enabled = True
            cmbProveedorUM.Enabled = True
            cmbProduccionUM.Enabled = True
            txtEquivUMProv.Enabled = True
            txtDesProv.Enabled = True
            txtClaveProv.Enabled = True
            cmbProveedor.Enabled = True
        End If
        If exclusivo = True Then
            cmbProveedor.Enabled = False
        Else
            cmbProveedor.Enabled = True
        End If
        validarLoad()
    End Sub
    Private Sub inicializarControles()
        sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy")

        txtIdMaterial.Text = idMaterial

        If lista.Count = 0 Then
            llenarComboProveedores()
        Else
            llenarComboProveedoresNoEnPrecios()
        End If

        llenarComponentes()
        aplicarPermisos()
        llenarComboMoneda()
        llenarComboUM1()
        llenarComboUM2()
        llenarComboOrigen()
    End Sub
    Public Sub llenarComponentes()
        cmbProveedor.SelectedValue = precioMaterial.proveedorId
        If nuevo = 1 Then
            txtPrecioUnitario.Text = ""
            txtTiempoEntrega.Text = ""
        Else
            txtTiempoEntrega.Text = precioMaterial.tiempodeEntrega
            txtPrecioUnitario.Text = precioMaterial.precioUnitario
        End If

        If precioMaterial.descripcionProv = "" Then
            txtDesProv.Text = precioMaterial.descripcion
        Else
            txtDesProv.Text = precioMaterial.descripcionProv
        End If
        txtClaveProv.Text = precioMaterial.claveProveedor
        cmbProduccionUM.SelectedItem = precioMaterial.umc
        cmbProveedorUM.SelectedItem = precioMaterial.ump
        txtEquivUMProv.Text = precioMaterial.equivalenciaUMP
    End Sub
    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Dim objMensaje As New Tools.ConfirmarForm
        objConfirmacion.mensaje = "Los cambios realizados no se guardaran ¿Estás seguro de salir de la ventana?"
        If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
            cerrado = True
            Me.Close()
        End If

    End Sub
    Private Sub txtPrecioUnitario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioUnitario.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtPrecioUnitario.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        Dim tb As TextBox = DirectCast(sender, TextBox)
        Dim separadorDecimal As String =
         Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim index As Integer = tb.Text.IndexOf(separadorDecimal)

        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c) OrElse (e.KeyChar = ControlChars.Back)) Then
            ' Si en el control hay ya escrito un separador decimal, 
            ' deshechamos insertar otro separador más. 
            '
            If Char.IsControl(e.KeyChar) Then
                e.Handled = False
                Return
            End If
            If (tb.Text.IndexOf(separadorDecimal) >= 0) And Not (tb.SelectionLength <> 0) Then
                e.Handled = True
                Return

            Else
                If ((tb.TextLength = 0) OrElse (tb.SelectionLength > 0) OrElse
                  ((tb.TextLength = 1) And (tb.Text.Chars(0) = "-"c))) Then
                    ' Si no hay ningún número, insertamos un cero
                    ' antes del separador decimal.
                    tb.SelectedText = "0"
                End If

                ' Insertamos el separador decimal. 
                '
                e.KeyChar = CChar(separadorDecimal)
                Return
            End If
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If

        If (index >= 0) Then
            Dim decimales As String = tb.Text.Substring(index + 1)
            e.Handled = (decimales.Length = 2)
        End If
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If validarCamposVacios() Then
                Dim objMensaje As New Tools.ConfirmarForm
                objMensaje.mensaje = "¿Esta seguro que desea Agregar/Editar este precio de material?" & vbCrLf & "(Los precios editados quedarán como inactivos y se insertará uno nuevo)"
                If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                    guardarPrecioMaterial()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub guardarPrecioMaterial()
        Dim tabla As New DataTable
        Try

            Dim obj As New MaterialesBU
            tabla = obj.getProveedrorDatosGeneralesID(cmbProveedor.SelectedValue)

            precioMaterial.proveedordgId = tabla.Rows(0).Item(0).ToString
            precioMaterial.idumc = cmbProveedorUM.SelectedValue
            precioMaterial.idump = cmbProduccionUM.SelectedValue
            precioMaterial.proveedorId = cmbProveedor.SelectedValue
            precioMaterial.tiempodeEntrega = txtTiempoEntrega.Text
            precioMaterial.precioUnitario = txtPrecioUnitario.Text
            precioMaterial.monedaId = cmbMoneda.SelectedValue
            precioMaterial.moneda = cmbMoneda.Text
            precioMaterial.monedaId = cmbMoneda.SelectedValue
            precioMaterial.proveedor = cmbProveedor.Text
            precioMaterial.umc = cmbProveedorUM.Text
            precioMaterial.ump = cmbProduccionUM.Text
            precioMaterial.equivalenciaUMP = txtEquivUMProv.Text
            precioMaterial.descripcionProv = txtDesProv.Text.Trim
            precioMaterial.claveProveedor = txtClaveProv.Text.Trim
            precioMaterial.fechaRegistro = DateTime.Now.ToString("dd/MM/yyyy hh:mm")
            precioMaterial.fechaModificacion = DateTime.Now.ToString("dd/MM/yyyy hh:mm")
            precioMaterial.usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            precioMaterial.navedesarrollaid = idNave
            precioMaterial.naveDesarrolla = NombreNaveDesarrolla
            precioMaterial.origenpreciomaterial = cmbOrigen.SelectedValue
            If precioMaterial.preciosmaterialid = 0 Then
                precioMaterial.existe = 0 'El registro no existe en la base de datos
            Else
                precioMaterial.existe = 2 'El registro existe y fue modificado
            End If
            Me.Close()

            cerrado = False
        Catch ex As Exception
            'Me.Cursor = Cursors.Default
            'advertencia.mensaje = "Surgió un error al guardar el precio del material. Error: " + ex.Message
            'advertencia.ShowDialog()
        End Try

    End Sub
    Function validarCamposVacios() As Boolean
        If cmbProveedor.SelectedValue > 0 Then
            lblProv.ForeColor = Color.Black
            Pic4.Visible = True
        Else
            Pic4.Visible = False
            lblProv.ForeColor = Color.Red
            advertencia.mensaje = "El proveedor es obligatorio."
            advertencia.ShowDialog()
            cmbProveedor.Focus()
            Return False
        End If
        'If txtTiempoEntrega.Text.Length > 0 And txtTiempoEntrega.Text <> "0" Then
        If lblTiempoEntrega.ForeColor = Color.Black Then
            Try
                Convert.ToInt32(txtTiempoEntrega.Text)
                lblTiempoEntrega.ForeColor = Color.Black
                Pic6.Visible = True
            Catch ex As Exception
                Pic6.Visible = False
                lblTiempoEntrega.ForeColor = Color.Red
                advertencia.mensaje = "Los días de entrega son obligatorios."
                advertencia.ShowDialog()
                txtTiempoEntrega.Focus()
                Return False
            End Try

        Else
            Pic6.Visible = False
            lblTiempoEntrega.ForeColor = Color.Red
            advertencia.mensaje = "Los días de entrega son obligatorios."
            advertencia.ShowDialog()
            txtTiempoEntrega.Focus()
            Return False
        End If
        If lblPrecioUnitario.ForeColor = Color.Black Then
            'If txtPrecioUnitario.Text.Length > 0 And txtPrecioUnitario.Text <> "0" Then
            Try
                Convert.ToDouble(txtPrecioUnitario.Text)
                lblPrecioUnitario.ForeColor = Color.Black
                Pic7.Visible = True
            Catch ex As Exception
                Pic7.Visible = False
                lblPrecioUnitario.ForeColor = Color.Red
                advertencia.mensaje = "El precio unitario es obligatorio y debe ser mayor a 0."
                advertencia.ShowDialog()
                Return False
            End Try
        Else
            Pic7.Visible = False
            lblPrecioUnitario.ForeColor = Color.Red
            advertencia.mensaje = "El precio unitario es obligatorio  y debe ser mayor a 0."
            advertencia.ShowDialog()
            txtPrecioUnitario.Focus()
            Return False
        End If
        If cmbProveedorUM.SelectedIndex > 0 Then
            picumc.Visible = True
            lblUM.ForeColor = Color.Black
        Else
            picumc.Visible = False
            lblUM.ForeColor = Color.Red
            advertencia.mensaje = "La unidad de medida del proveedor es obligatoria."
            advertencia.ShowDialog()
            cmbProveedorUM.Focus()
            Return False
        End If
        If cmbProduccionUM.SelectedIndex > 0 Then
            picump.Visible = True
            lblUMP.ForeColor = Color.Black
        Else
            picump.Visible = False
            lblUMP.ForeColor = Color.Red
            advertencia.mensaje = "La unidad de medida de consumo es obligatoria."
            advertencia.ShowDialog()
            cmbProduccionUM.Focus()
            Return False
        End If
        'If txtEquivUMProv.Text.Length > 0 And txtEquivUMProv.Text <> "0" Then
        If lblR.ForeColor = Color.Black Then
            Try
                Convert.ToDouble(txtEquivUMProv.Text)
                lblR.ForeColor = Color.Black
                PicRend.Visible = True
            Catch ex As Exception
                PicRend.Visible = False
                lblR.ForeColor = Color.Red
                advertencia.mensaje = "El factor de conversión es obligatorio  y debe ser mayor a 0."
                advertencia.ShowDialog()
                txtEquivUMProv.Focus()
                Return False
            End Try
        Else
            lblR.ForeColor = Color.Red
            advertencia.mensaje = "La equivalencia de unidad de medida del proveedor es obligatoria y debe ser mayor a 0."
            advertencia.ShowDialog()
            txtEquivUMProv.Focus()
            Return False
        End If
        Return True
    End Function

    Public Sub validarLoad()
        If txtPrecioUnitario.TextLength > 0 Then
            lblPrecioUnitario.ForeColor = Color.Black
        Else
            lblPrecioUnitario.ForeColor = Color.Red
        End If
        If txtTiempoEntrega.TextLength > 0 Then
            lblTiempoEntrega.ForeColor = Color.Black
        Else
            lblTiempoEntrega.ForeColor = Color.Red
        End If
    End Sub


    Private Sub cmbProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProveedor.SelectedIndexChanged
        Try
            If cmbProveedor.SelectedIndex > 0 Then
                lblProv.ForeColor = Color.Black
                Pic4.Visible = True
            Else
                Pic4.Visible = False
                lblProv.ForeColor = Color.Red
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTiempoEntrega_TextChanged(sender As Object, e As EventArgs) Handles txtTiempoEntrega.TextChanged
        If txtTiempoEntrega.Text.Length > 0 Then

            Dim numero = txtTiempoEntrega.Text
            If numero > 0 Then
                Try
                    Convert.ToInt32(txtTiempoEntrega.Text)
                    lblTiempoEntrega.ForeColor = Color.Black
                    Pic6.Visible = True
                Catch ex As Exception
                    Pic6.Visible = False
                    lblTiempoEntrega.ForeColor = Color.Red
                End Try
            Else
                Pic6.Visible = False
                lblTiempoEntrega.ForeColor = Color.Red
            End If
        End If
    End Sub
    Private Sub txtPrecioUnitario_TextChanged(sender As Object, e As EventArgs) Handles txtPrecioUnitario.TextChanged
        If txtPrecioUnitario.Text.Length >= 0 Then
            Dim numero = txtPrecioUnitario.Text
            Try
                If numero > 0 Then
                    Try
                        Convert.ToDouble(txtPrecioUnitario.Text)
                        lblPrecioUnitario.ForeColor = Color.Black
                        Pic7.Visible = True
                    Catch ex As Exception
                        Pic7.Visible = False
                        lblPrecioUnitario.ForeColor = Color.Red
                    End Try
                Else
                    Pic7.Visible = False
                    lblPrecioUnitario.ForeColor = Color.Red
                End If
            Catch ex As Exception
            End Try
            Try
                If numero = "" Then
                    Try
                        Convert.ToDouble(txtPrecioUnitario.Text)
                        lblPrecioUnitario.ForeColor = Color.Black
                        Pic7.Visible = True
                    Catch ex As Exception
                        Pic7.Visible = False
                        lblPrecioUnitario.ForeColor = Color.Red
                    End Try
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
    Public Sub llenarComboUM1()
        Dim obj As New MaterialesBU
        Dim lst As DataTable
        lst = obj.getIdUnidadesDeMedidas()
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbProduccionUM.DataSource = lst
            cmbProduccionUM.DisplayMember = "descripcion"
            cmbProduccionUM.ValueMember = "idUnidad"
        End If

    End Sub
    Public Sub llenarComboUM2()
        Dim obj As New MaterialesBU
        Dim lst As DataTable
        lst = obj.getIdUnidadesDeMedidas()
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbProveedorUM.DataSource = lst
            cmbProveedorUM.DisplayMember = "descripcion"
            cmbProveedorUM.ValueMember = "idUnidad"
        End If

    End Sub
    Public Sub llenarComboProveedores()
        Dim obj As New MaterialesBU
        Dim lstPreciosCli As DataTable
        lstPreciosCli = obj.getProveedores(idNave)
        If Not lstPreciosCli.Rows.Count = 0 Then
            lstPreciosCli.Rows.InsertAt(lstPreciosCli.NewRow, 0)
            cmbProveedor.DataSource = lstPreciosCli
            cmbProveedor.DisplayMember = "Proveedor"
            cmbProveedor.ValueMember = "IDP"
        End If
    End Sub

    Public Sub llenarComboProveedoresNoEnPrecios()
        Dim obj As New MaterialesBU
        Dim lstPreciosCli As DataTable
        lstPreciosCli = obj.getProveedoresNoEnPrecios(idNave, lista)
        If Not lstPreciosCli.Rows.Count = 0 Then
            lstPreciosCli.Rows.InsertAt(lstPreciosCli.NewRow, 0)
            cmbProveedor.DataSource = lstPreciosCli
            cmbProveedor.DisplayMember = "Proveedor"
            cmbProveedor.ValueMember = "IDP"
        End If

    End Sub

    Public Sub llenarComboMoneda()
        Dim obj As New MaterialesBU
        Dim lstPreciosCli As DataTable
        lstPreciosCli = obj.getMoneda()
        If Not lstPreciosCli.Rows.Count = 0 Then
            lstPreciosCli.Rows.InsertAt(lstPreciosCli.NewRow, 0)
            cmbMoneda.DataSource = lstPreciosCli
            cmbMoneda.DisplayMember = "MONEDA"
            cmbMoneda.ValueMember = "ID"
        End If
        cmbMoneda.SelectedValue = 1
    End Sub

    Private Sub txtTiempoEntrega_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTiempoEntrega.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtEquivUMProv.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub aplicarPermisos()
        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "ALTACLIENTE") Then
        '    If CInt(lblClientePersonaID_Int.Text) = 0 Then
        '        btnAgregarCliente.Enabled = True
        '    Else
        '        btnAgregarCliente.Enabled = False
        '    End If
        'Else
        '    btnAgregarCliente.Enabled = False
        'End If
    End Sub

    Private Sub txtEquivUMProv_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEquivUMProv.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtEquivUMProv.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        Dim tb As TextBox = DirectCast(sender, TextBox)
        Dim separadorDecimal As String =
         Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim index As Integer = tb.Text.IndexOf(separadorDecimal)

        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c) OrElse (e.KeyChar = ControlChars.Back)) Then
            ' Si en el control hay ya escrito un separador decimal, 
            ' deshechamos insertar otro separador más. 
            '
            If Char.IsControl(e.KeyChar) Then
                e.Handled = False
                Return
            End If
            If (tb.Text.IndexOf(separadorDecimal) >= 0) And Not (tb.SelectionLength <> 0) Then
                e.Handled = True
                Return

            Else
                If ((tb.TextLength = 0) OrElse (tb.SelectionLength > 0) OrElse
                  ((tb.TextLength = 1) And (tb.Text.Chars(0) = "-"c))) Then
                    ' Si no hay ningún número, insertamos un cero
                    ' antes del separador decimal.
                    tb.SelectedText = "0"
                End If

                ' Insertamos el separador decimal. 
                '
                e.KeyChar = CChar(separadorDecimal)
                Return
            End If
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If

        If (index >= 0) Then
            Dim decimales As String = tb.Text.Substring(index + 1)
            e.Handled = (decimales.Length = 2)
        End If
    End Sub

    Private Sub NuevoPrecioMaterialForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        cerrado = True
    End Sub

    Private Sub cmbProveedorUM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProveedorUM.SelectedIndexChanged
        Try
            If cmbProveedorUM.SelectedIndex > 0 Then
                picump.Visible = True
                lblUMP.ForeColor = Color.Black
            Else
                picump.Visible = False
                lblUMP.ForeColor = Color.Red
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbProduccionUM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProduccionUM.SelectedIndexChanged
        Try
            If cmbProduccionUM.SelectedIndex > 0 Then
                picumc.Visible = True
                lblUM.ForeColor = Color.Black
            Else
                picumc.Visible = False
                lblUM.ForeColor = Color.Red
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtEquivUMProv_TextChanged(sender As Object, e As EventArgs) Handles txtEquivUMProv.TextChanged
        If txtEquivUMProv.Text.Length > 0 Then
            If txtEquivUMProv.Text > 0 Then
                Try
                    Convert.ToDouble(txtEquivUMProv.Text)
                    lblR.ForeColor = Color.Black
                    PicRend.Visible = True
                Catch ex As Exception
                    PicRend.Visible = False
                    lblR.ForeColor = Color.Red
                    txtEquivUMProv.Focus()
                End Try
            Else
                lblR.ForeColor = Color.Red
                PicRend.Visible = False
            End If
        End If
    End Sub

    Public Sub similitudesDescripcionProveedor()
        Dim obj As New MaterialesBU
        Dim datos As New DataTable

        datos = obj.getDecripcionProveedorConcidencias(txtDesProv.Text, idMaterial)

        Dim form As New PosibleMaterialesForm
        form.datos = datos
        form.lbltitulo1.Text = "Se encontraton descripciónes de proveedor con similitudes."
        form.lblTitulo2.Text = "Verifique que la descripción de l proveedor que intenta dar de alta no este dentro de la lista"
        form.lblPie.Text = "Si la descripción ya existe de clic a la fila y luego al botón SELECCIONAR MATERIAL"
        form.descripcion = 1
        If datos.Rows.Count > 0 Then
            form.ShowDialog()
            txtClaveProv.Text = form.claveProveedor
            'txtClaveProv.ReadOnly = True
            ' txtDesProv.Text = form.descripcionProveedor
            'txtDesProv.ReadOnly = True
        End If

    End Sub

    Private Sub txtDesProv_Leave(sender As Object, e As EventArgs) Handles txtDesProv.Leave
        'Try
        '    similitudesDescripcionProveedor()
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub txtPrecioUnitario_Leave(sender As Object, e As EventArgs) Handles txtPrecioUnitario.Leave
        If txtPrecioUnitario.Text.Length >= 0 Then
            Dim numero = txtPrecioUnitario.Text
            Try
                If numero > 0 Then
                    Try
                        Convert.ToDouble(txtPrecioUnitario.Text)
                        lblPrecioUnitario.ForeColor = Color.Black
                        Pic7.Visible = True
                    Catch ex As Exception
                        Pic7.Visible = False
                        lblPrecioUnitario.ForeColor = Color.Red
                    End Try
                Else
                    Pic7.Visible = False
                    lblPrecioUnitario.ForeColor = Color.Red
                End If
            Catch ex As Exception
            End Try
            Try
                If numero = "" Then
                    Try
                        Convert.ToDouble(txtPrecioUnitario.Text)
                        lblPrecioUnitario.ForeColor = Color.Black
                        Pic7.Visible = True
                    Catch ex As Exception
                        Pic7.Visible = False
                        lblPrecioUnitario.ForeColor = Color.Red
                    End Try
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub cmbProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbProveedor.KeyDown
        'cmbProveedor.AutoCompleteMode = AutoCompleteMode.None
        'cmbProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        'cmbProveedor.AutoCompleteSource = AutoCompleteSource.ListItems
        'cmbProveedor.AutoCompleteMode = AutoCompleteMode.Append
        'cmbProveedor.AutoCompleteMode = AutoCompleteMode.Suggest
        'Me.cmbProveedor.AutoCompleteMode = AutoCompleteMode.Suggest
    End Sub

    Public Sub llenarComboOrigen()
        Dim obj As New MaterialesBU
        Dim dtOrigenPrecio As New DataTable
        dtOrigenPrecio.Columns.Add("ID")
        dtOrigenPrecio.Columns.Add("Origen")
        dtOrigenPrecio.Rows.Add("N", "NACIONAL")
        dtOrigenPrecio.Rows.Add("I", "IMPORTADO")
        If Not dtOrigenPrecio.Rows.Count = 0 Then
            cmbOrigen.DataSource = dtOrigenPrecio
            cmbOrigen.DisplayMember = "Origen"
            cmbOrigen.ValueMember = "ID"
        End If
        cmbOrigen.SelectedIndex = 0
    End Sub

End Class