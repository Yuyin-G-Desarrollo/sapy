Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Globalization
Imports Tools

Public Class ResumenApartadosClientes_Form

    Public filtrosGeneracion As New Entidades.FiltrosGeneracionApartadosPPCP
    Public pantallaFiltrosApartados As GeneracionApartados_FiltrosForm
    Public listClientes As New DataTable

    Private Sub ResumenApartadosClientes_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ObjBu As New Negocios.ApartadosBU
        Dim dtApartadosPorGenerar As New DataTable
        Me.Top = 0
        Me.Left = 0

        Cursor = Cursors.WaitCursor

        'Se agrego para que el inventario no dier negativos
        ObjBu.Replicacion_TmpdocenasPares()

        ObjBu.consultaGenerarVistaFiltrar(filtrosGeneracion)
        ObjBu.InsertarDatosLotesProgramas(filtrosGeneracion)
        'ObjBu.InsertarInventarioDisponibleInicial()
        ObjBu.consultaGenerarApartadosResumenClientes(filtrosGeneracion)
        grdListadoClientes.DataSource = ObjBu.resumenDisponibilidadClientes()

        griResumenDiseño(grdListadoClientes)

        lblFechaUltimaActualizacion.Text = DateTime.Now.ToShortDateString + " " + DateTime.Now.ToShortTimeString

        Cursor = Cursors.Default
    End Sub

    Private Sub griResumenDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns("Parametro").Hidden = True

        grid.DisplayLayout.Bands(0).Columns("Seleccionar").Style = ColumnStyle.CheckBox
        grid.DisplayLayout.Bands(0).Columns("Seleccionar").Header.Caption = ""

        grid.DisplayLayout.Bands(0).Columns("Seleccionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("Cliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("ParesPrograma").Header.Caption = "PrsXApartar"
        grid.DisplayLayout.Bands(0).Columns("ParesPrograma").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("ParesPrograma").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("ParesDisponibles").Header.Caption = "PrsDisponibles"
        grid.DisplayLayout.Bands(0).Columns("ParesDisponibles").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("ParesDisponibles").Format = "n0"

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

    End Sub

    'Asigna formato a columnas de ultragrid
    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then

                If col.Header.Caption.Equals("TELÉFONO") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("EXTENSIÓN") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If

        Next

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub grdListadoClientes_Click(sender As Object, e As EventArgs) Handles grdListadoClientes.Click
        If Not Me.grdListadoClientes.ActiveRow.IsDataRow Then Return

        If IsNothing(grdListadoClientes.ActiveRow) Then Return

        If grdListadoClientes.ActiveRow.Cells("Seleccionar").Value Then

            grdListadoClientes.ActiveRow.Cells("Seleccionar").Value = False
        Else
            grdListadoClientes.ActiveRow.Cells("Seleccionar").Value = True
        End If
        Dim marcados As Integer
        For Each row As UltraGridRow In grdListadoClientes.Rows
            If CBool(row.Cells("Seleccionar").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If grdListadoClientes.Rows.Count = 0 Then Return

        Dim grid As DataTable = grdListadoClientes.DataSource
        listClientes = grid.Clone
        For Each row As UltraGridRow In grdListadoClientes.Rows
            If CBool(row.Cells("Seleccionar").Value) Then
                Dim fila As DataRow = listClientes.NewRow

                For index = 0 To row.Cells.Count - 1 Step 1
                    fila(index) = row.Cells(index).Value
                Next
                listClientes.Rows.Add(fila)
            End If
        Next
        pantallaFiltrosApartados.grdCliente.DataSource = Nothing
        pantallaFiltrosApartados.grdCliente.DataSource = listClientes
        pantallaFiltrosApartados.grdCliente.DisplayLayout.Bands(0).Columns("Parametro").Hidden = True
        pantallaFiltrosApartados.grdCliente.DisplayLayout.Bands(0).Columns("ParesPrograma").Hidden = True
        pantallaFiltrosApartados.grdCliente.DisplayLayout.Bands(0).Columns("ParesDisponibles").Hidden = True
        pantallaFiltrosApartados.grdCliente.DisplayLayout.Bands(0).Columns("Seleccionar").Hidden = True
        Me.Close()
        pantallaFiltrosApartados.WindowState = FormWindowState.Normal
    End Sub



    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Cursor = Cursors.WaitCursor
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New AdvertenciaForm
        grid = grdListadoClientes
        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
            With grid.DisplayLayout.Bands(0)
                .Columns("seleccionar").Hidden = True
            End With
            nombreDocumento = "\DisponibilidadClientesApartar"


            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog

                If ret = Windows.Forms.DialogResult.OK Then

                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                    gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                    With grid.DisplayLayout.Bands(0)
                        .Columns("seleccionar").Hidden = False
                    End With
                    Dim mensajeExito As New ExitoForm
                    Cursor = Cursors.Default
                    mensajeExito.mensaje = "Los datos se exportaron correctamente"
                    mensajeExito.ShowDialog()

                End If
                .Dispose()
            End With
        Else
            Cursor = Cursors.Default
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub chboxMarcarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxMarcarTodo.CheckedChanged
        If chboxMarcarTodo.Checked Then
            For Each row In grdListadoClientes.Rows.GetFilteredInNonGroupByRows
                row.Cells(1).Value = True
            Next
        Else
            For Each row As UltraGridRow In grdListadoClientes.Rows.GetFilteredInNonGroupByRows
                row.Cells(1).Value = False
            Next
        End If
        Dim marcados As Integer
        For Each row As UltraGridRow In grdListadoClientes.Rows
            If CBool(row.Cells(1).Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub
End Class