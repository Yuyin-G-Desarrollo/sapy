Imports Framework.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaSucursalesForm
    Public IdSucursal As Integer
    Public idbanco As Integer
    Public idciudad As Integer
    Public Numero As String
    Public Nombre As String
    Public Activo As Boolean
    Public ciudad As String
    Public idEstado As Integer
    Public banco As String




    Public Property pidbancos As Integer
        Get
            Return idbanco
        End Get
        Set(value As Integer)
            idbanco = value

        End Set
    End Property


    Private Sub ListaSucursalesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitCombos()
        If idbanco > 0 Then
            cmbBanco.SelectedValue = idbanco
        End If
        If idEstado > 0 Then
            cmbEstados.SelectedValue = idEstado
        End If
        If idciudad > 0 Then
            cmbCiudad.SelectedValue = idciudad
        End If
        LlenarTablaSucursales()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbBancos.Height = 39
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbBancos.Height = 195
    End Sub

    Public Sub InitCombos()
        cmbEstados = Tools.Controles.ComboEstados(cmbEstados, 0)

        Dim objBancosBU As New Negocios.BancosBU
        Dim tablabancos As New DataTable
        tablabancos = objBancosBU.listaBancosActivos
        tablabancos.Rows.InsertAt(tablabancos.NewRow, 0)
        With cmbBanco
            .DisplayMember = "banc_nombre"
            .ValueMember = "banc_bancoid"
            .DataSource = tablabancos
        End With

    End Sub

    Private Sub cmbEstados_DropDownClosed(sender As Object, e As EventArgs) Handles cmbEstados.DropDownClosed
        cmbCiudad = Controles.ComboCiudades(cmbCiudad, CInt(cmbEstados.SelectedValue))
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

    Private Sub cmbEstados_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbEstados.KeyPress
        e.Handled = True
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If
    End Sub

    Public Sub LlenarTablaSucursales()
        IdSucursal = 0
        idbanco = 0
        Numero = ""
        idciudad = 0
        Activo = True
        grdSucursales.DataSource = Nothing


        If cmbBanco.SelectedIndex > 0 Then
            idbanco = CInt(cmbBanco.SelectedValue)
        End If
        If cmbCiudad.SelectedIndex > 0 Then
            idciudad = CInt(cmbCiudad.SelectedValue)
        End If


        If rdoSi.Checked = False Then
            Activo = False
        Else
            Activo = True
        End If

        Numero = txtNumero.Text
        Nombre = txtSucursal.Text

        Dim objBU As New Negocios.SucursalesBU
        Dim dtListaSucursales As DataTable

        dtListaSucursales = objBU.listaSucursales(Numero, Nombre, idbanco, idciudad, Activo)
        grdSucursales.DataSource = dtListaSucursales



    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        grdSucursales.DataSource = Nothing
        LlenarTablaSucursales()
    End Sub

    Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltas.Click
        AltasSucursalesForm.ShowDialog()
        txtNumero.Text = ""
        txtSucursal.Text = ""
        cmbBanco.SelectedIndex = 0
        cmbEstados.SelectedIndex = 0
        rdoSi.Checked = True
        grdSucursales.DataSource = Nothing
        LlenarTablaSucursales()
    End Sub


    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        If IdSucursal = 0 Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "selecciona una opcion de la lista antes de dar click en 'Editar'"
            mensajeAdvertencia.Show()
        Else
            Dim formaEditarSucursal As New EditarSucursalesform
            With formaEditarSucursal
                .IdSucursal = IdSucursal
                .idbanco = idbanco
                .idciudad = idciudad
                .Numero = Numero
                .Nombre = Nombre
                .Activo = Activo
                .ciudad = ciudad
                .banco = banco
                .IdEstado = idEstado
            End With
            formaEditarSucursal.ShowDialog()
            LlenarTablaSucursales()
        End If

    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
        txtNumero.Text = ""
        txtSucursal.Text = ""
        cmbBanco.SelectedIndex = 0
        cmbEstados.SelectedIndex = 0
        rdoSi.Checked = True
        grdSucursales.DataSource = Nothing
        LlenarTablaSucursales()
    End Sub

    Private Sub grdSucursales_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdSucursales.InitializeLayout
        With grdSucursales
            .DisplayLayout.Bands(0).Columns("Id").Hidden = True
            .DisplayLayout.Bands(0).Columns("IdBanco").Hidden = True
            .DisplayLayout.Bands(0).Columns("IdCiudad").Hidden = True
            .DisplayLayout.Bands(0).Columns("IdEstado").Hidden = True
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Bands(0).Columns("Sucursal").Width = 150 'Ajusta la columna indicada a un tamaño manualmente asignado.
            .DisplayLayout.Bands(0).Columns("Número").Width = 50
            .DisplayLayout.Bands(0).Columns("Banco").Width = 100
            .DisplayLayout.Bands(0).Columns("Ciudad").Width = 100
            .DisplayLayout.Bands(0).Columns("Activo").Width = 43
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        End With

    End Sub

    Private Sub grdSucursales_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles grdSucursales.ClickCell
        Dim row As UltraGridRow = grdSucursales.ActiveRow
        If row.IsFilterRow Then Return
        IdSucursal = CInt(row.Cells("Id").Text)
        Nombre = CStr(row.Cells("Sucursal").Text)
        Numero = CStr(row.Cells("Número").Text)
        Activo = CBool(row.Cells("Activo").Value)
        idbanco = CInt(row.Cells("IdBanco").Value)
        idciudad = CInt(row.Cells("IdCiudad").Value)
        ciudad = CStr(row.Cells("Ciudad").Value)
        banco = CStr(row.Cells("Banco").Value)
        idEstado = CInt(row.Cells("IdEstado").Value)
    End Sub

    Private Sub grdSucursales_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdSucursales.BeforeRowsDeleted
        e.Cancel = True
    End Sub



End Class