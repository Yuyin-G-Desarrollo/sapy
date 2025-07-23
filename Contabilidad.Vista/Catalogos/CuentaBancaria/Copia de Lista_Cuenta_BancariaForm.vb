Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Windows.Forms
Imports System.Drawing
Imports Contabilidad.Negocios
Imports Tools

Public Class Lista_Cuenta_BancariaForm

    Private Sub lista_cuenta_bancariaform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        lista_Empresas()
        lista_Bancos()

        poblar_gridListaCuentaBancaria(gridListaCuentaBancaria)

    End Sub

    Private Sub lista_Empresas()

        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_Empresas_Say_Sicy_Contpaq
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cboxRazonSocial.DataSource = tabla
        cboxRazonSocial.DisplayMember = "essc_razonsocial"
        cboxRazonSocial.ValueMember = "essc_empresaid"
        cboxRazonSocial.SelectedValue = 0
    End Sub

    Private Sub lista_Bancos()

        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_Bancos
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cboxBanco.DataSource = tabla
        cboxBanco.DisplayMember = "banc_nombre"
        cboxBanco.ValueMember = "banc_bancoid"
        cboxBanco.SelectedValue = 0
    End Sub

    Public Sub poblar_gridListaCuentaBancaria(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim CuentasBancariasBU As New CuentasBancariasBU
        Dim PolizaBU As New PolizaBU
        Dim cuenta_bancaria As DataTable

        Dim empresaID As Integer
        Dim bancoID As Integer
        If Not IsDBNull(cboxRazonSocial.SelectedValue) Then
            empresaID = cboxRazonSocial.SelectedValue
        End If
        If Not IsDBNull(cboxBanco.SelectedValue) Then
            bancoID = cboxBanco.SelectedValue
        End If

        cuenta_bancaria = CuentasBancariasBU.Consulta_lista_Cuentas_Bancarias(empresaID, bancoID)

        grid.DataSource = cuenta_bancaria

        gridListaCuentaBancariaDiseno(grid)


    End Sub

    Private Sub gridListaCuentaBancariaDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        With grid.DisplayLayout
            .Bands(0).Columns("ID").Hidden = True
            .Bands(0).Columns("Empresa ID").Hidden = True
            .Bands(0).Columns("Cuenta SICY ID").Hidden = True
            .Bands(0).Columns("Banco ID").Hidden = True
            .Bands(0).Columns("Id Cuenta Contpaq").Hidden = True
            .Bands(0).Columns("Id Banco Contpaq").Hidden = True

            .Bands(0).Columns("Numero de Cuenta").Header.Caption = "Número de Cuenta"
            .Bands(0).Columns("Numero de Cuenta SICY").Header.Caption = "Número de Cuenta SICY"

            .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectors = DefaultableBoolean.True
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.FilterUIType = FilterUIType.FilterRow
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

    End Sub

    Private Sub asignar_grid_gridListaCuentaBancaria(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        gridListaCuentaBancaria = grid

    End Sub

    Private Sub gridListaCuentaBancaria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridListaCuentaBancaria.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNothing(gridListaCuentaBancaria.ActiveRow) Then Return

            Dim NextRowIndex As Integer = gridListaCuentaBancaria.ActiveRow.Index + 1
            Try

                If NextRowIndex <= gridListaCuentaBancaria.Rows.Count Then
                    gridListaCuentaBancaria.DisplayLayout.Rows(NextRowIndex).Activated = True
                    gridListaCuentaBancaria.DisplayLayout.Rows(NextRowIndex).Selected = True
                Else
                    gridListaCuentaBancaria.DisplayLayout.Rows(0).Activated = True
                    gridListaCuentaBancaria.DisplayLayout.Rows(0).Selected = True
                End If

            Catch ex As Exception
                gridListaCuentaBancaria.ActiveRow.Activated = False
            End Try


        End If

        If e.KeyChar = ChrW(Keys.Escape) Then
            poblar_gridListaCuentaBancaria(gridListaCuentaBancaria)
            gridListaCuentaBancaria.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        End If

    End Sub

    Private Sub gridListaCuentaBancaria_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)

        If selection = 1 Then

            For Each row In gridListaCuentaBancaria.Selected.Rows
                Dim i As Integer = gridListaCuentaBancaria.Rows.Count

                gridListaCuentaBancaria.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
                gridListaCuentaBancaria.DisplayLayout.Override.CellClickAction = CellClickAction.Edit

            Next

        End If

    End Sub

    Private Sub gridListaCuentaBancaria_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridListaCuentaBancaria.BeforeExitEditMode
        Try
            Dim cellIndex As Integer = gridListaCuentaBancaria.ActiveCell.Column.Index

            If gridListaCuentaBancaria.ActiveRow.DataChanged Then

            Else
                If gridListaCuentaBancaria.ActiveCell.DataChanged Then
                Else
                    If String.IsNullOrWhiteSpace(gridListaCuentaBancaria.ActiveCell.Value) Then
                        poblar_gridListaCuentaBancaria(gridListaCuentaBancaria)
                        gridListaCuentaBancaria.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                    End If
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gridListaCuentaBancaria_AfterRowActivate(sender As Object, e As EventArgs) Handles gridListaCuentaBancaria.AfterRowActivate
        gridListaCuentaBancaria.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        For Each row In gridListaCuentaBancaria.Rows
            row.Activation = Activation.NoEdit
        Next
    End Sub

    Private Sub gridListaCuentaBancaria_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridListaCuentaBancaria.BeforeRowDeactivate

        gridListaCuentaBancaria.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

    End Sub


    Private Sub btnMostrar_Click(sender As Object, e As EventArgs)
        poblar_gridListaCuentaBancaria(gridListaCuentaBancaria)
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim form As New AltaCuenta_BancariaForm
        form.StartPosition = FormStartPosition.CenterScreen
        form.Text = "Alta Cuenta Bancaria"
        form.lblTitulo.Text = "Alta Cuenta Bancaria"
        form.ShowDialog(Me)

        btnMostrar.PerformClick()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        If gridListaCuentaBancaria.Selected.Rows.Count > 1 Then
            show_message("Advertencia", "Seleccione solo una cuenta bancaria para poder editar su información.")
        ElseIf gridListaCuentaBancaria.Selected.Rows.Count = 0 Then
            show_message("Advertencia", "Seleccione una cuenta bancaria para editar su información.")
        Else
            Dim form As New AltaCuenta_BancariaForm

            form.Editar_Alta = True
            form.NumeroCuentaBancaria = CStr(gridListaCuentaBancaria.ActiveRow.Cells("ID").Value)
            form.numeroDeCuenta = CStr(gridListaCuentaBancaria.ActiveRow.Cells("Numero de Cuenta").Value)
            form.cuentaHabiente = CStr(gridListaCuentaBancaria.ActiveRow.Cells("Cuentahabiente").Value)
            form.idRazonSocial = CStr(gridListaCuentaBancaria.ActiveRow.Cells("Empresa ID").Value)
            form.numeroCuentaSicy = CStr(gridListaCuentaBancaria.ActiveRow.Cells("Cuenta SICY ID").Value)
            form.idCuentaContpaq = CStr(gridListaCuentaBancaria.ActiveRow.Cells("Id Cuenta Contpaq").Value)
            form.idBancoContpaq = CStr(gridListaCuentaBancaria.ActiveRow.Cells("Id Banco Contpaq").Value)
            form.idBanco = CStr(gridListaCuentaBancaria.ActiveRow.Cells("Banco ID").Value)
            form.Text = "Editar Cuenta Bancaria"
            form.lblTitulo.Text = "Editar Cuenta Bancaria"

            form.StartPosition = FormStartPosition.CenterScreen
            form.ShowDialog()
            btnMostrar.PerformClick()
        End If

    End Sub


    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub


    Private Sub btnMostrar_Click_1(sender As Object, e As EventArgs) Handles btnMostrar.Click
        poblar_gridListaCuentaBancaria(gridListaCuentaBancaria)
    End Sub


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        gridListaCuentaBancaria.DataSource = Nothing
        cboxBanco.SelectedIndex = 0
        cboxRazonSocial.SelectedIndex = 0
    End Sub
End Class