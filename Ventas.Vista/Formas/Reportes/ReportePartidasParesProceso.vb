Imports Infragistics.Win.UltraWinGrid
Imports DevExpress.Export
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Tools.modMensajes
Imports Infragistics.Win

Public Class ReportePartidasParesProceso
    Private Sub btnFiltroStatusPedidos_Click(sender As Object, e As EventArgs) Handles btnFiltroStatusPedidos.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 11

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdStatusPedido.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdStatusPedido.DataSource = listado.listParametros
        With grdStatusPedido
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Status"
        End With
    End Sub

    Private Sub btnExportarExcelProyeccion_Click(sender As Object, e As EventArgs) Handles btnExportarExcelProyeccion.Click

        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If bgvDatos.DataRowCount > 0 Then
                nombreReporte = "Datos_Partidas_Proceso_"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If bgvDatos.GroupCount > 0 Then
                            bgvDatos.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            exportOptions.TextExportMode = TextExportMode.Text
                            exportOptions.ExportType = ExportType.WYSIWYG
                            exportOptions.ApplyFormattingToEntireColumn = DevExpress.Utils.DefaultBoolean.True
                            exportOptions.AllowConditionalFormatting = DevExpress.Utils.DefaultBoolean.True
                            exportOptions.AllowCellMerge = DevExpress.Utils.DefaultBoolean.False

                            bgvDatos.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx", exportOptions)

                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo")
        End Try

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New Ventas.Negocios.ReportePartidasParesProcesoBU
        Dim tabla As New DataTable

        Cursor = Cursors.WaitCursor

        Dim statusPedido As String = String.Empty
        Dim mostrarSoloProceso As Integer = 0

        For Each row As UltraGridRow In grdStatusPedido.Rows
            If row.Index = 0 Then
                statusPedido += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                statusPedido += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next

        If (chboxMostrarCompletas.Checked = True) Then
            mostrarSoloProceso = 1
        Else
            mostrarSoloProceso = 0
        End If

        grdDatos.DataSource = Nothing
        bgvDatos.Columns.Clear()

        tabla = objBU.consultaDatosPartidas(statusPedido, mostrarSoloProceso)

        If tabla.Rows.Count() > 0 Then
            DiseñoGrid(tabla)
            grdDatos.DataSource = tabla
            btnArriba_Click(Nothing, Nothing)
        Else
            Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para mostrar")
        End If


        Cursor = Cursors.Default


    End Sub

    Private Sub DiseñoGrid(ByVal dtReporte As DataTable)
        'bgvDatos.OptionsView.ColumnAutoWidth = True
        bgvDatos.BestFitColumns()

        For Each col As DataColumn In dtReporte.Columns
            bgvDatos.Columns.AddField(col.Caption.ToUpper)
            bgvDatos.Columns.ColumnByFieldName(col.Caption.ToUpper).Name = col.Caption.ToUpper
            bgvDatos.Columns.ColumnByFieldName(col.Caption.ToUpper).Visible = True
            bgvDatos.Columns.ColumnByFieldName(col.Caption.ToUpper).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            bgvDatos.Columns.ColumnByFieldName(col.Caption.ToUpper).OptionsColumn.AllowEdit = False


        Next

        bgvDatos.Columns.ColumnByFieldName("#").Width = 50
        bgvDatos.Columns.ColumnByFieldName("DESCRIPCIÓN").Width = 500
        bgvDatos.Columns.ColumnByFieldName("CLIENTE").Width = 350

        bgvDatos.Columns.ColumnByFieldName("% F").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvDatos.Columns.ColumnByFieldName("% F").DisplayFormat.FormatString = "N0"


        bgvDatos.Columns.ColumnByFieldName("% R").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvDatos.Columns.ColumnByFieldName("% R").DisplayFormat.FormatString = "N0"

        bgvDatos.Columns.ColumnByFieldName("PARES PARTIDA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvDatos.Columns.ColumnByFieldName("PARES PARTIDA").DisplayFormat.FormatString = "N0"
        bgvDatos.Columns.ColumnByFieldName("PARES ALMACÉN").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvDatos.Columns.ColumnByFieldName("PARES ALMACÉN").DisplayFormat.FormatString = "N0"
        bgvDatos.Columns.ColumnByFieldName("PARES PROCESO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvDatos.Columns.ColumnByFieldName("PARES PROCESO").DisplayFormat.FormatString = "N0"
        bgvDatos.Columns.ColumnByFieldName("PARES F").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvDatos.Columns.ColumnByFieldName("PARES F").DisplayFormat.FormatString = "N0"
        bgvDatos.Columns.ColumnByFieldName("PARES R").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvDatos.Columns.ColumnByFieldName("PARES R").DisplayFormat.FormatString = "N0"

        For Each Col As DevExpress.XtraGrid.Columns.GridColumn In bgvDatos.Columns
            If Col.FieldName = "PARES PARTIDA" Or Col.FieldName = "PARES ALMACÉN" Or Col.FieldName = "PARES PROCESO" Or Col.FieldName = "PARES F" Or Col.FieldName = "PARES R" Then
                Col.Summary.Clear()
                Col.Width = 150
                Col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                Col.DisplayFormat.FormatString = "N0"
                Col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, Col.FieldName, "{0:N0}")
            End If
        Next

    End Sub

    Private Sub grdStatusPedido_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdStatusPedido.InitializeLayout
        grid_diseño(grdStatusPedido)
        grdStatusPedido.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Estatus"
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With


        asignaFormato_Columna(grid)

    End Sub
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

                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If
        Next
    End Sub

    Private Sub grdAgentes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdStatusPedido.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 29
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 163
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub ReportePartidasParesProceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

End Class