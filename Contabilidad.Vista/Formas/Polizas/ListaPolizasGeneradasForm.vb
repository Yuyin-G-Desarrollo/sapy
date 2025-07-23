Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports Infragistics.Win
Imports System.Windows.Forms
Imports System.IO
Imports System.Xml
Imports Tools

Public Class ListaPolizasGeneradasForm

    Private Sub ListaPolizasGeneradasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lista_Empresas()
        lista_tipo()
        dateInicio.Value = Now.Date
        dateInicio.MaxDate = Now.Date
        dateTermino.Value = Now.Date
        dateTermino.MaxDate = Now.Date

    End Sub

    Private Sub lista_Empresas()

        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_Empresas_Say_Sicy_Contpaq
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cboxRazonSocial.DataSource = tabla
        cboxRazonSocial.DisplayMember = "essc_razonsocial"
        cboxRazonSocial.ValueMember = "essc_empresaid"
    End Sub

    Private Sub lista_tipo()

        Dim objBU As New Negocios.AltaPolizaBU
        Dim tabla As New DataTable

        tabla = objBU.CargaTiposPoliza()
        tabla.Rows.InsertAt(tabla.NewRow(), 0)
        cboxTipo.DisplayMember = "poti_nombre"
        cboxTipo.ValueMember = "poti_polizaTipoId"
        cboxTipo.DataSource = tabla

    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        If IsNothing(cboxRazonSocial.SelectedValue) Or IsDBNull(cboxRazonSocial.SelectedValue) Then Return
        If IsNothing(cboxTipo.SelectedValue) Or IsDBNull(cboxTipo.SelectedValue) Then Return

        poblar_gridListaPolizasGeneradas(gridListaPolizasGeneradas)

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cboxRazonSocial.SelectedValue = 0
        cboxRazonSocial.SelectedValue = 0
        dateInicio.Value = Now.Date
        dateTermino.Value = Now.Date
        gridListaPolizasGeneradas.DataSource = Nothing
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim objBU As New Negocios.PolizaBU
        Try

            If gridListaPolizasGeneradas.Selected.Rows.Count > 0 Then
                Dim confirmacion As New Tools.ConfirmarForm
                confirmacion.mensaje = "¿Esta seguro de eliminar las " + gridListaPolizasGeneradas.Selected.Rows.Count.ToString + " polizas seleccionadas?"
                If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    For Each rowSelected In gridListaPolizasGeneradas.Selected.Rows
                        'Dim row As UltraGridRow = rowSelected
                        If Not rowSelected Is Nothing Then
                            objBU.Eliminar_Poliza_Solo_SAY(CInt(rowSelected.Cells(0).Value))
                        End If
                    Next
                    poblar_gridListaPolizasGeneradas(gridListaPolizasGeneradas)
                Else
                    Return
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    ''  ACCIONES GRID LISTA POLIZAS GENERADAS
    Public Sub poblar_gridListaPolizasGeneradas(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New Negocios.PolizaBU
        Dim lista_polizas_generadas As DataTable
        Dim empresaID, tipoPolizaID As Integer
        Dim fechaInicio, fechaTermino As DateTime

        empresaID = CInt(cboxRazonSocial.SelectedValue)
        tipoPolizaID = CInt(cboxTipo.SelectedValue)
        fechaInicio = dateInicio.Value
        fechaTermino = dateTermino.Value

        lista_polizas_generadas = objBU.lista_polizas_generadas(empresaID, tipoPolizaID, fechaInicio, fechaTermino)

        grid.DataSource = lista_polizas_generadas

        gridListaPolizasGeneradasDiseno(grid)

    End Sub

    Private Sub gridListaPolizasGeneradasDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        With grid.DisplayLayout
            .Bands(0).Columns(0).Hidden = True
            .Bands(0).Columns("# Póliza").Style = UltraWinGrid.ColumnStyle.Integer
            .Bands(0).Columns("# Póliza").CellAppearance.TextHAlign = HAlign.Right
            .Bands(0).Columns("Ejercicio").Hidden = True
            .Bands(0).Columns("Periodo").Hidden = True
            .Bands(0).Columns("Total Cargos").Format = Format("N2")
            .Bands(0).Columns("Total Cargos").CellAppearance.TextHAlign = HAlign.Right
            .Bands(0).Columns("Total Abonos").Format = Format("N2")
            .Bands(0).Columns("Total Abonos").CellAppearance.TextHAlign = HAlign.Right
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
            .Override.AllowDelete = DefaultableBoolean.False
            .Override.HeaderClickAction = HeaderClickAction.SortMulti
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

    Private Sub gridListaPolizasGeneradas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridListaPolizasGeneradas.KeyPress

        If e.KeyChar = ChrW(Keys.Escape) Then
            poblar_gridListaPolizasGeneradas(gridListaPolizasGeneradas)
            gridListaPolizasGeneradas.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        End If

    End Sub

    Private Sub gridListaPolizasGeneradas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gridListaPolizasGeneradas.MouseDoubleClick

        If gridListaPolizasGeneradas.ActiveRow Is Nothing Then Return

        Dim row As UltraGridRow = gridListaPolizasGeneradas.ActiveRow

        If row Is Nothing Then Return

        Dim form As New MovimientosPolizaForm
        form.polizaID = CInt(row.Cells(0).Value)
        
        form.Show(Me)

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

End Class