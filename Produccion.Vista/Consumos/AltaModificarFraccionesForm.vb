Imports Produccion.Negocios
Imports Tools

Public Class AltaModificarFraccionesForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Public nave As Integer = 0
    Public actualizar As Integer = 0
    Public id As Integer = 0
    Public idfraccion As Integer
    Public fraccion As String = ""
    Public tiempo As Double = 0
    Public precio As Double = 0
    Public idmaquinaria As Integer = 0
    Public maquinaria As String = ""
    Public paga As Integer = 0
    Public activo As Integer = 0
    Public departamento As Integer = 0

    Private Sub AltaModificarFraccionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFracciones.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        rdoActivoSi.Checked = True
        txtFracciones.Focus()
        rdoPagaSi.Checked = True
        llenarcomboDepartamento()
        'llenarcomboMaquinaria()
        txtPrecio.Text = 0
        CargaInicial()
    End Sub

    Public Sub CargaInicial()
        If actualizar = 0 Then
            txtIDFraccion.Text = ""
            txtFracciones.Text = ""
            txtTiempo.Text = ""
            txtPrecio.Text = ""
            rdoPagaSi.Checked = True
            rdoActivoSi.Checked = True
            rdoActivoNo.Enabled = False
        Else
            txtIDFraccion.Text = idfraccion
            txtFracciones.Text = fraccion
            txtTiempo.Text = tiempo
            txtPrecio.Text = precio
            cmbDepartamento.SelectedValue = departamento
            If paga = 1 Then
                rdoPagaSi.Checked = True
            Else
                rdoPagaNo.Checked = True
            End If
            If activo = 1 Then
                rdoActivoSi.Checked = True
            Else
                rdoActivoNo.Checked = True
            End If
            If activo = 0 Then
                txtIDFraccion.Enabled = False
                txtFracciones.Enabled = False
                txtTiempo.Enabled = False
                txtPrecio.Enabled = False
                cmbDepartamento.Enabled = False
                gbxPaga.Enabled = False
            Else
                'txtFracciones.Enabled = False
                txtFracciones.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Public Sub llenarcomboDepartamento()
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.listaDepartamentosGenerales
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbDepartamento.DataSource = lista
            cmbDepartamento.DisplayMember = "Departamento"
            cmbDepartamento.ValueMember = "ID"
        End If
    End Sub

    Public Sub llenarcomboMaquinaria()
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.listaMaquinaria()
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbMaquinaria.DataSource = lista
            cmbMaquinaria.DisplayMember = "Maquinaria"
            cmbMaquinaria.ValueMember = "ID"
        End If
    End Sub

    Public Sub guardarFraccion()
        Dim entidad As New Entidades.Fracciones
        Dim obj As New catalagosBU

        entidad.frap_descripcion = txtFracciones.Text
        If rdoPagaSi.Checked = True Then
            entidad.frap_paga = 1
        Else
            entidad.frap_paga = 0
        End If
        If txtPrecio.Text <> "" Then
            entidad.frap_precio = txtPrecio.Text
        Else
            entidad.frap_precio = 0
        End If
        If txtTiempo.Text <> "" Then
            entidad.frap_tiempo = txtTiempo.Text
        Else
            entidad.frap_tiempo = 0
        End If
        entidad.departamentogeneralid = 0
        entidad.frap_usuariocreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        If rdoActivoSi.Checked = True Then
            entidad.frap_activo = 1
        Else
            entidad.frap_activo = 0
        End If

        obj.GuardarFracciones(entidad)
        objExito.mensaje = "Se guardo con éxito la fracción"
        objAdvertencia.StartPosition = FormStartPosition.CenterScreen
        objExito.ShowDialog()
        Me.Close()
    End Sub

    Public Sub ActualizarFraccion()
        Dim entidad As New Entidades.Fracciones
        Dim obj As New catalagosBU

        entidad.frap_descripcion = txtFracciones.Text
        If rdoPagaSi.Checked = True Then
            entidad.frap_paga = 1
        Else
            entidad.frap_paga = 0
        End If
        entidad.frap_tiempo = txtTiempo.Text
        entidad.frap_precio = txtPrecio.Text
        If cmbDepartamento.SelectedValue > 0 Then
            entidad.departamentogeneralid = cmbDepartamento.SelectedValue
        Else
            entidad.departamentogeneralid = 0
        End If
        entidad.frap_usuariomodifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        If rdoActivoSi.Checked = True Then
            entidad.frap_activo = 1
        Else
            entidad.frap_activo = 0
        End If
        entidad.frap_fraccionid = txtIDFraccion.Text

        obj.ActualizarFracciones(entidad)
        objExito.mensaje = "Se modificó con éxito la fracción"
        objAdvertencia.StartPosition = FormStartPosition.CenterScreen
        objExito.ShowDialog()
        Me.Close()
    End Sub

    Public Function buscarFraccionesRepetidas()
        Dim obj As New catalagosBU
        Dim tabla As New DataTable
        tabla = obj.buscarFraccion(txtFracciones.Text)
        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim precioCaptura As Double = 0
        If txtFracciones.Text <> "" Then
            If txtPrecio.Text <> "" Then
                precioCaptura = txtPrecio.Text
            Else
                precioCaptura = 0
            End If
            If actualizar = 0 Then
                If buscarFraccionesRepetidas() = False Then
                    guardarFraccion()
                Else
                    objAdvertencia.mensaje = "Ya hay una fracción registrada que es igual a la que desea capturar"
                    objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                    objAdvertencia.ShowDialog()
                End If
            Else
                ActualizarFraccion()
            End If
        Else
            If txtFracciones.Text = "" Then
                objAdvertencia.mensaje = "Ingrese una Fracción"
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
                lblFracciones.ForeColor = Drawing.Color.Red
            End If
        End If
    End Sub

    Private Sub rdoPagaNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPagaNo.CheckedChanged
        If rdoPagaSi.Checked = True Then
            txtPrecio.Enabled = True
            ' txtPrecio.Text = 0
            lblPrecio.Text = "*Precio"
        Else
            txtPrecio.Enabled = False
            ' txtPrecio.Text = 0
            lblPrecio.Text = "Precio"
        End If
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtPrecio.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        Dim tb As TextBox = DirectCast(sender, TextBox)
        Dim separadorDecimal As String = _
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
                If ((tb.TextLength = 0) OrElse (tb.SelectionLength > 0) OrElse _
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
            e.Handled = (decimales.Length = 3)
        End If
    End Sub

    Private Sub txtTiempo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTiempo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtTiempo.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        Dim tb As TextBox = DirectCast(sender, TextBox)
        Dim separadorDecimal As String = _
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
                If ((tb.TextLength = 0) OrElse (tb.SelectionLength > 0) OrElse _
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

    Private Sub txtFracciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFracciones.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "#" Then
            e.Handled = False
        ElseIf e.KeyChar = ControlChars.Back Then
            e.Handled = False
        ElseIf e.KeyChar = " " Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub rdoPagaSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPagaSi.CheckedChanged
        If rdoPagaSi.Checked = True Then
            txtPrecio.Enabled = True
            lblPrecio.Text = "*Precio"
        Else
            txtPrecio.Enabled = False
            lblPrecio.Text = "Precio"
        End If
    End Sub
End Class