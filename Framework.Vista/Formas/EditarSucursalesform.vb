Imports Framework.Negocios

Public Class EditarSucursalesform
    Public IdSucursal As Integer
    Public idbanco As Integer
    Public idciudad As Integer
    Public Numero As String
    Public Nombre As String
    Public Activo As Boolean
    Public ciudad As String
    Public banco As String
    Public IdEstado As Integer

    Public Property Pidsucursal As Integer
        Get
            Return IdSucursal
        End Get
        Set(value As Integer)
            IdSucursal = value
        End Set
    End Property
    Private Sub EditarSucursalesform_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        initCombos()
        cmbCiudad = Controles.ComboCiudades(cmbCiudad, 0)

        Dim objsucursalBU As New SucursalesBU
        Dim sucursal As New Entidades.Sucursales
        'sucursal = objsucursalBU.buscarsucuirsal(bancos)
        sucursal = objsucursalBU.buscarsucuirsal(IdSucursal)

        txtNumero.Text = sucursal.Pnumero
        txtSucursal.Text = sucursal.Pnombre

        cmbBanco.SelectedValue = sucursal.Pbanco
        cmbCiudad.SelectedValue = sucursal.Pciudad
        cmbEstados.SelectedValue = idEstado

        If (sucursal.Pactivo) Then
            rdoSi.Checked = True
        Else
            rdoNo.Checked = True
        End If

    End Sub


    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim falla As Boolean = False
        If txtNumero.Text <> "" Then
            lblNumero.ForeColor = Color.Black
        Else
            lblNumero.ForeColor = Color.Red
            falla = True
        End If
        If txtSucursal.Text <> "" Then
            lblNombreSucursal.ForeColor = Color.Black
        Else
            lblNombreSucursal.ForeColor = Color.Red
            falla = True
        End If
        If cmbBanco.Text <> "" Then
            lblBanco.ForeColor = Color.Black
        Else
            lblBanco.ForeColor = Color.Red
            falla = True
        End If
        If cmbCiudad.Text <> "" Then
            lblCiudad.ForeColor = Color.Black
        Else
            lblCiudad.ForeColor = Color.Red
            falla = True
        End If

        If falla Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Faltan campos por completar"
            mensajeAdvertencia.Show()
        Else
            Dim sucursal As New Entidades.Sucursales
            sucursal.Pidsucursales = IdSucursal
            sucursal.Pnumero = txtNumero.Text
            sucursal.Pnombre = txtSucursal.Text
            If cmbBanco.SelectedIndex > 0 Then
                sucursal.Pbanco = CInt(cmbBanco.SelectedValue)
            End If
            If cmbCiudad.SelectedIndex > 0 Then
                sucursal.Pciudad = CInt(cmbCiudad.SelectedValue)
            End If
            sucursal.Pactivo = rdoSi.Checked
            Me.Close()
            Dim objSucursalBU As New SucursalesBU
            objSucursalBU.editarsucursales(sucursal)
            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "!Los datos de la sucursal bancaria se actualizaron correctamente¡"
            mensajeExito.ShowDialog()
        End If
    End Sub

    Public Sub initCombos()
        cmbEstados = Tools.Controles.ComboEstados(cmbEstados, 0)

        Dim objBancosBU As New BancosBU
        Dim tablaBancos As New DataTable
        tablaBancos = objBancosBU.listaBancosActivos()
        tablaBancos.Rows.InsertAt(tablaBancos.NewRow, 0)
        With cmbBanco
            .DataSource = tablaBancos
            .DisplayMember = "banc_nombre"
            .ValueMember = "banc_bancoid"
        End With
    End Sub

    Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub txtNumero_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtSucursal_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSucursal.KeyPress
        e.Handled = True
        If Char.IsLetter(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If
    End Sub

    Private Sub cmbBanco_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbBanco.KeyPress
        e.Handled = True
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If
    End Sub

    Private Sub cmbCiudad_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCiudad.KeyPress
        e.Handled = True
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If
    End Sub

    Private Sub cmbEstados_DropDownClosed(sender As Object, e As EventArgs) Handles cmbEstados.DropDownClosed
        cmbCiudad = Controles.ComboCiudades(cmbCiudad, CInt(cmbEstados.SelectedValue))
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class