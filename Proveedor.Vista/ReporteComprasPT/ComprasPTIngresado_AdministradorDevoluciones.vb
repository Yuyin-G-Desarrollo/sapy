Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Framework.Negocios
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class ComprasPTIngresado_AdministradorDevoluciones
    Dim objBU As New Proveedores.BU.DevolucionesPreliminares_BU
    Dim listaInicial As New List(Of String)

    Private Sub ComprasPTIngresado_AdministradorDevoluciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now
        ConfiguracionPermisosBotones()
        InicializaFiltros()
    End Sub

    Private Sub ConfiguracionPermisosBotones()
        pnlAplicar.Visible = PermisosUsuarioBU.ConsultarPermiso("ADMIN_DEV_COMPRAS", "ADMDEV_APLICAR")
        pnlDescargar.Visible = PermisosUsuarioBU.ConsultarPermiso("ADMIN_DEV_COMPRAS", "ADMDEV_DESCARGAR")
    End Sub

    Private Sub InicializaFiltros()
        grdStatus.DataSource = listaInicial
        grdEmisor.DataSource = listaInicial
        grdReceptor.DataSource = listaInicial
    End Sub

    Private Sub grdFiltros_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdEmisor.InitializeLayout, grdStatus.InitializeLayout, grdReceptor.InitializeLayout
        Grid_diseño(sender)
        Select Case sender.Name
            Case "grdEmisor"
                grdEmisor.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Emisor"
            Case "grdReceptor"
                grdReceptor.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Receptor"
            Case "grdStatus"
                grdStatus.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Status"
        End Select
    End Sub

    Private Sub grdStatus_KeyDown(sender As Object, e As KeyEventArgs) Handles grdEmisor.KeyDown, grdStatus.KeyDown, grdReceptor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        sender.DeleteSelectedRows(False)
    End Sub

    Private Sub GvwListado_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles gvwListado.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            grdListado.DataSource = Nothing
            gvwListado.Columns.Clear()
            Dim estatusIds As String = Filtros(grdStatus)
            Dim emisorIds As String = Filtros(grdEmisor)
            Dim receptorIds As String = Filtros(grdReceptor)
            Dim fechaInicio As Date = dtpFechaInicio.Value
            Dim fechaFin As Date = dtpFechaFin.Value
            Dim dtResultado As New DataTable
            dtResultado = objBU.consultarDevolucionesPT(rdoFechaDevolucion.Checked, rdoFechaFacturacion.Checked, fechaInicio, fechaFin, emisorIds, receptorIds, estatusIds)

            If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
                grdListado.DataSource = dtResultado

                DisenioGrid()
                lblFechaUltimaActualización.Text = Date.Now.ToString
                lblNumRegistros.Text = dtResultado.Rows.Count.ToString("N0", CultureInfo.InvariantCulture)
                pnlParametros.Visible = False
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontró información con los filtros seleccionados.")
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al consultar las devoluciones: " & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DisenioGrid()
        gvwListado.OptionsView.EnableAppearanceEvenRow = True
        gvwListado.IndicatorWidth = 30
        gvwListado.OptionsView.ShowAutoFilterRow = True
        gvwListado.OptionsView.RowAutoHeight = True

        gvwListado.Columns.ColumnByFieldName("ST").Width = 20
        gvwListado.Columns.ColumnByFieldName("ESTATUS").Visible = False
        gvwListado.Columns.ColumnByFieldName("EMISORID").Visible = False
        gvwListado.Columns.ColumnByFieldName("RECEPTORID").Visible = False
        gvwListado.Columns.ColumnByFieldName("RUTA_XML").Visible = False
        gvwListado.Columns.ColumnByFieldName("RUTA_PDF").Visible = False
        gvwListado.Columns.ColumnByFieldName("NC").Visible = False

        gvwListado.Columns.ColumnByFieldName(" ").OptionsColumn.Printable = False

        gvwListado.Columns.ColumnByFieldName("PARES DEVUELTOS").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("PARES DEVUELTOS").DisplayFormat.FormatString = "N0"
        gvwListado.Columns.ColumnByFieldName("SUBTOTAL").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("SUBTOTAL").DisplayFormat.FormatString = "N2"
        gvwListado.Columns.ColumnByFieldName("IVA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("IVA").DisplayFormat.FormatString = "N2"
        gvwListado.Columns.ColumnByFieldName("TOTAL").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("TOTAL").DisplayFormat.FormatString = "N2"

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvwListado.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName.Contains("PARES DEVUELTOS") Or col.FieldName.Contains("SUBTOTAL") Or col.FieldName.Contains("IVA") Or col.FieldName.Contains("TOTAL") Then
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "PARES DEVUELTOS")) = True And col.FieldName = "PARES DEVUELTOS" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "SUBTOTAL")) = True And col.FieldName = "SUBTOTAL" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "IVA")) = True And col.FieldName = "IVA" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "TOTAL")) = True And col.FieldName = "TOTAL" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
            End If

            If col.FieldName = " " Then
                col.OptionsColumn.AllowEdit = True
            Else
                col.OptionsColumn.AllowEdit = False
            End If
        Next

        gvwListado.OptionsView.ColumnAutoWidth = True

    End Sub

    Private Function Filtros(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid) As String
        Dim lista As New List(Of Integer)
        For Each Row As UltraGridRow In grid.Rows
            If Row.Cells(0).Value Then lista.Add(Row.Cells(0).Value)
        Next
        Return String.Join(",", lista).ToString
    End Function

    Private Sub btnAgregarFiltros_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroEmisor.Click, btnAgregarFiltroReceptor.Click, btnAgregarFiltroStatus.Click
        Select Case sender.Name
            Case "btnAgregarFiltroEmisor"
                AbrirListaParametros(4, 0, grdEmisor, "Emisor")
            Case "btnAgregarFiltroReceptor"
                AbrirListaParametros(3, 0, grdReceptor, "Receptor")
            Case "btnAgregarFiltroStatus"
                AbrirListaParametros(6, 0, grdStatus, "Status")
        End Select

        grdListado.DataSource = Nothing
    End Sub

    Private Sub AbrirListaParametros(ByVal tipoBusqueda As Integer, ByVal tipoNave As Integer, ByVal grid As UltraGrid, ByVal encabezado As String)
        Dim listado As New ListaParametrosForm With {
            .tipo_busqueda = tipoBusqueda,
            .tipo_Nave = tipoNave
        }

        Dim listaParametroId As New List(Of String)

        For Each row As UltraGridRow In grid.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroId.Add(parametro)
        Next
        listado.listaPatametroID = listaParametroId
        listado.ShowDialog(Me)

        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdListado.DataSource = Nothing
        grid.DataSource = listado.listaParametros
        Grid_diseño(grid)

        With grid
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = encabezado
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With

    End Sub
    Private Sub Grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With
        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next
        AsignaFormato_Columna(grid)
    End Sub

    Public Sub AsignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                col.CellAppearance.TextHAlign = HAlign.Left
            End If
        Next
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Visible = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        Try
            If gvwListado.RowCount > 0 Then
                Dim documentoIds As List(Of Integer)
                documentoIds = ListDocuments()

                If documentoIds.Count = 0 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Debe seleccionar al menos un registro.")
                ElseIf documentoIds.Count > 1 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Solamente puede seleccionar un documento para aplicar la devolución.")
                Else
                    For i As Integer = 0 To gvwListado.RowCount - 1
                        If gvwListado.GetRowCellValue(i, " ") And gvwListado.GetRowCellValue(i, "ESTATUS") <> "PRELIMINAR" Then
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Solamente se pueden aplicar las devoluciones en estatus PRELIMINAR")
                        ElseIf gvwListado.GetRowCellValue(i, " ") And gvwListado.GetRowCellValue(i, "ESTATUS") = "PRELIMINAR" Then
                            Dim objForm As New ComprasPTIngresado_AplicarDevoluciones
                            If Not CheckForm(objForm) Then
                                objForm.devolucionId = gvwListado.GetRowCellValue(i, "ID SAY NC")
                                objForm.emisorId = gvwListado.GetRowCellValue(i, "EMISORID")
                                objForm.emisorRazSoc = gvwListado.GetRowCellValue(i, "EMISOR")
                                objForm.emisorRFC = gvwListado.GetRowCellValue(i, "RFCEMISOR")
                                objForm.receptorId = gvwListado.GetRowCellValue(i, "RECEPTORID")
                                objForm.receptorRazSoc = gvwListado.GetRowCellValue(i, "RECEPTOR")
                                objForm.receptorRFC = gvwListado.GetRowCellValue(i, "RFCRECEPTOR")
                                objForm.paresDevolucion = gvwListado.GetRowCellValue(i, "PARES DEVUELTOS")
                                objForm.totalDevolucion = gvwListado.GetRowCellValue(i, "TOTAL")
                                objForm.esAplicacion = True
                                objForm.ShowDialog()
                            End If
                        End If
                    Next
                    btnMostrar_Click(Nothing, Nothing)

                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay información cargada.")
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error: " & ex.Message)
        End Try
    End Sub

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function ListDocuments() As List(Of Integer)
        Dim lista As New List(Of Integer)
        For i As Integer = 0 To gvwListado.RowCount - 1
            If gvwListado.GetRowCellValue(i, " ") Then
                lista.Add(gvwListado.GetRowCellValue(i, "ID SAY NC"))
            End If
        Next
        Return lista
    End Function

    Private Sub gvwListado_RowCellStyle(sender As Object, e As Views.Grid.RowCellStyleEventArgs) Handles gvwListado.RowCellStyle
        Try
            Dim currentView As GridView
            currentView = sender

            If e.Column.FieldName = "ST" Then
                Dim value As String
                value = currentView.GetRowCellValue(e.RowHandle, "ESTATUS").ToString

                Select Case value
                    Case "PRELIMINAR"
                        e.Appearance.BackColor = Color.Orange
                    Case "APLICADA"
                        e.Appearance.BackColor = Color.Green
                End Select
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnLimpiarFiltroReceptor_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroReceptor.Click, btnLimpiarFiltroEmisor.Click, btnLimpiarFiltroStatus.Click
        Select Case sender.Name
            Case "btnLimpiarFiltroStatus"
                grdStatus.DataSource = listaInicial
            Case "btnLimpiarFiltroEmisor"
                grdEmisor.DataSource = listaInicial
            Case "btnLimpiarFiltroReceptor"
                grdReceptor.DataSource = listaInicial
        End Select

        grdListado.DataSource = Nothing
    End Sub

    Private Sub rdoFechaDevolucion_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFechaDevolucion.CheckedChanged
        grdListado.DataSource = Nothing
    End Sub

    Private Sub btnVerDetalles_Click(sender As Object, e As EventArgs) Handles btnVerDetalles.Click
        Try
            If gvwListado.RowCount > 0 Then
                Dim documentoIds As List(Of Integer)
                documentoIds = ListDocuments()

                If documentoIds.Count = 0 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Debe seleccionar al menos un registro.")
                ElseIf documentoIds.Count > 1 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Sólo se puede visualizar el detalle de una NC.")
                Else
                    For i As Integer = 0 To gvwListado.RowCount - 1
                        If gvwListado.GetRowCellValue(i, " ") Then
                            Dim objForm As New ComprasPTIngresado_AplicarDevoluciones
                            If Not CheckForm(objForm) Then
                                objForm.devolucionId = gvwListado.GetRowCellValue(i, "ID SAY NC")
                                objForm.emisorRazSoc = gvwListado.GetRowCellValue(i, "EMISOR")
                                objForm.emisorRFC = gvwListado.GetRowCellValue(i, "RFCEMISOR")
                                objForm.receptorRazSoc = gvwListado.GetRowCellValue(i, "RECEPTOR")
                                objForm.receptorRFC = gvwListado.GetRowCellValue(i, "RFCRECEPTOR")
                                objForm.folioNC = gvwListado.GetRowCellValue(i, "NC")
                                objForm.ShowDialog()
                            End If
                        End If
                    Next
                    'btnMostrar_Click(Nothing, Nothing)

                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay información cargada.")
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDescargar_Click(sender As Object, e As EventArgs) Handles btnDescargar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim documentoIds As List(Of Integer)

        Try
            If gvwListado.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                documentoIds = ListDocuments()
                If documentoIds.Count = 0 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Debe seleccionar al menos un registro.")
                Else
                    Cursor = Cursors.WaitCursor
                    With fbdUbicacionArchivo
                        .Reset()
                        .Description = "Seleccione una carpeta "
                        .ShowNewFolderButton = True

                        Dim ret As DialogResult = .ShowDialog
                        If ret = Windows.Forms.DialogResult.OK Then
                            For i As Integer = 0 To gvwListado.RowCount - 1
                                If gvwListado.GetRowCellValue(i, " ") Then
                                    If My.Computer.FileSystem.FileExists(gvwListado.GetRowCellValue(i, "RUTA_XML")) Then
                                        My.Computer.FileSystem.CopyFile(gvwListado.GetRowCellValue(i, "RUTA_XML"), .SelectedPath & "\" & Path.GetFileName(gvwListado.GetRowCellValue(i, "RUTA_XML")), True)
                                    End If
                                    If My.Computer.FileSystem.FileExists(gvwListado.GetRowCellValue(i, "RUTA_PDF")) Then
                                        My.Computer.FileSystem.CopyFile(gvwListado.GetRowCellValue(i, "RUTA_PDF"), .SelectedPath & "\" & Path.GetFileName(gvwListado.GetRowCellValue(i, "RUTA_PDF")), True)
                                    End If
                                End If
                            Next
                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Archivo(s) descargado(s) correctamente.")
                        End If
                    End With
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay información.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, ex.Message)
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ContextMenuStrip1.Show(btnExportar, 0, btnExportar.Height)
    End Sub

    Private Sub ListadoDevolucionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDevolucionesToolStripMenuItem.Click
        exportarExcel()
    End Sub

    Private Sub exportarExcel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty
        Try
            Cursor = Cursors.WaitCursor
            If gvwListado.DataRowCount > 0 Then

                nombreReporte = "DevolucionesComprasPTIngresado"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = "Seleccione una carpeta "
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.ToString("yyyyMMdd_Hmmss")

                    If ret = Windows.Forms.DialogResult.OK Then
                        If gvwListado.GroupCount > 0 Then
                            gvwListado.ExportToXlsx(.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            gvwListado.ExportToXlsx(.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With

            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo.")
        End Try
    End Sub

    Private Sub LayoutNCFacturamaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LayoutNCFacturamaToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim emisorIds As String = Filtros(grdEmisor)

            If grdEmisor.Rows.Count > 1 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Solamente se puede exportar las devoluciones de un Emisor.")
            ElseIf grdEmisor.Rows.Count = 1 Then
                grdListado.DataSource = Nothing
                gvwListado.Columns.Clear()
                Dim estatusIds As String = Filtros(grdStatus)
                Dim receptorIds As String = Filtros(grdReceptor)
                Dim fechaInicio As Date = dtpFechaInicio.Value
                Dim fechaFin As Date = dtpFechaFin.Value
                Dim dtResultado As New DataTable
                dtResultado = objBU.obtenerLauyoutDevolucionesPT(rdoFechaDevolucion.Checked, rdoFechaFacturacion.Checked, fechaInicio, fechaFin, emisorIds, receptorIds)

                If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
                    grdListado.DataSource = dtResultado
                    lblFechaUltimaActualización.Text = ""
                    lblNumRegistros.Text = "0"
                    exportarExcelCSV()
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontró información con los filtros seleccionados.")
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Es necesario elegir un Emisor.")
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error: " & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub exportarExcelCSV()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty
        Try
            Cursor = Cursors.WaitCursor
            If gvwListado.DataRowCount > 0 Then

                nombreReporte = "LayoutNC_ComprasPTIngresado"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = "Seleccione una carpeta "
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.ToString("yyyyMMdd_Hmmss")

                    If ret = Windows.Forms.DialogResult.OK Then

                        gvwListado.ExportToCsv(.SelectedPath + "\" + nombreReporte + fecha_hora + ".csv")

                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString & ".csv")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "\" + nombreReporte + fecha_hora + ".csv")
                    End If
                End With

                btnMostrar_Click(Nothing, Nothing)

            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo.")
        End Try
    End Sub

End Class