Imports Framework.Negocios

Public Class AltasSucursalesForm

	Private Sub AltasSucursalesForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        initCombos()
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

    Private Sub cmbBanco_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If
    End Sub

    Private Sub cmbCiudad_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
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
            Dim objsucursalesBU As New SucursalesBU
            objsucursalesBU.guardarSucursal(sucursal)
            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "!El registro de la sucursal se realizo con exito¡."
            mensajeExito.ShowDialog()
        End If
    End Sub

    Private Sub cmbEstados_DropDownClosed(sender As Object, e As EventArgs) Handles cmbEstados.DropDownClosed
        cmbCiudad = Controles.ComboCiudades(cmbCiudad, CInt(cmbEstados.SelectedValue))
    End Sub


End Class