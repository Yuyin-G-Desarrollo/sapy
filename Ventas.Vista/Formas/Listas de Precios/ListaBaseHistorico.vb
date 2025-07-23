Imports Infragistics.Win.UltraWinGrid
Imports Infragistics
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
Imports Infragistics.Win


Public Class ListaBaseHistorico
    Dim dtTitulosListas As DataTable


    Public Sub llenarTablaHistoricos()

        Dim objLB As New Ventas.Negocios.ListaBaseBU
        Dim dtDatosHistoricoLB As New DataTable
        Dim cadenaCodigos As String = ""
        Dim nombre() As String

        For Each item As Object In cmbListas.CheckedItems
            'nombre = item.ToString.Split("(")
            nombre = item.datavalue.ToString.Split("(")
            cadenaCodigos += "[" + nombre(0) + "],"
        Next
        If cadenaCodigos.Length > 0 Then
            Try
                cadenaCodigos = cadenaCodigos.Substring(0, cadenaCodigos.Length - 1)
                Me.Cursor = Cursors.WaitCursor
                dtDatosHistoricoLB = objLB.verHistorico(cadenaCodigos)

                ' Use a DataTable object's DataColumnCollection.
                Dim columns As DataColumnCollection = dtDatosHistoricoLB.Columns
                Dim columna0 As New DataColumn
                columna0.DataType = Type.GetType("System.Boolean")
                columna0.DefaultValue = False
                columna0.ColumnName = " "
                columns.Add(columna0)
                For Each row As DataRow In dtDatosHistoricoLB.Rows
                    row.Item(" ") = 0
                Next

                grdHistoricoPreciosBase.DataSource = dtDatosHistoricoLB
                formatosGrid()
                formatoListas()
                Me.Cursor = Cursors.Default
            Catch ex As Exception
                Me.Cursor = Cursors.Default
            End Try
        Else
            MsgBox("Seleccione al menos una Lista Base")
        End If

    End Sub

    Public Sub llenarComboCodigos()
        Dim objLB As New Ventas.Negocios.ListaBaseBU
        Dim dtListas As New DataTable
        dtListas = objLB.listaListasBaseCombo
        dtTitulosListas = objLB.listaListasBase
        cmbListas.DataSource = dtListas
        'cmbTallas.ValueMember = "lpba_listapreciosbaseid"
        cmbListas.ValueMember = "lpba_codigolistabase"
        cmbListas.DisplayMember = "NombreLista"

        dtTitulosListas = dtListas

    End Sub

    Public Sub formatosGrid()
        With grdHistoricoPreciosBase.DisplayLayout.Bands(0)

            .Columns("pres_productoestiloid").Hidden = True
            .Columns("marc_marcaid").Hidden = True
            .Columns("cole_coleccionid").Hidden = True
            .Columns("fami_familiaid").Hidden = True
            .Columns("linea_lineaid").Hidden = True
            .Columns("piel_pielid").Hidden = True
            .Columns("color_colorid").Hidden = True
            .Columns("talla_tallaid").Hidden = True
            .Columns("pres_activo").Hidden = True
            .Columns("stpr_productoStatusId").Hidden = True
            .Columns("prod_descripcion").Hidden = True
            .Columns("pres_codSicy").Hidden = True


            .Columns("prod_codigo").Header.Caption = "Modelo SAY"
            .Columns("prod_modelo").Header.Caption = "Modelo SICY"
            .Columns("prod_codigo").Width = 60
            .Columns("prod_descripcion").Header.Caption = "Modelo"
            .Columns("marc_descripcion").Header.Caption = "Marca"
            .Columns("cole_descripcion").Header.Caption = "Colección"
            .Columns("piel_descripcion").Header.Caption = "Piel"
            .Columns("color_descripcion").Header.Caption = "Color"
            .Columns("fami_descripcion").Header.Caption = "Familia"
            .Columns("linea_descripcion").Header.Caption = "Linea"
            .Columns("piel_descripcion").Header.Caption = "Piel"
            .Columns("color_descripcion").Header.Caption = "Color"
            .Columns("talla_descripcion").Header.Caption = "Talla"
            .Columns("pres_codSicy").Header.Caption = "SICY"
            .Columns("stpr_descripcion").Header.Caption = "Estatus"
            .Columns("talla_descripcion").Header.Caption = "Corrida"

            '.Columns("pres_codSicy").Header.Caption = "SICY"

            .Columns("prod_codigo").CellActivation = Activation.NoEdit
            .Columns("prod_descripcion").CellActivation = Activation.NoEdit
            .Columns("marc_descripcion").CellActivation = Activation.NoEdit
            .Columns("cole_descripcion").CellActivation = Activation.NoEdit
            .Columns("piel_descripcion").CellActivation = Activation.NoEdit
            .Columns("color_descripcion").CellActivation = Activation.NoEdit
            .Columns("fami_descripcion").CellActivation = Activation.NoEdit
            .Columns("linea_descripcion").CellActivation = Activation.NoEdit
            .Columns("piel_descripcion").CellActivation = Activation.NoEdit
            .Columns("color_descripcion").CellActivation = Activation.NoEdit
            .Columns("talla_descripcion").CellActivation = Activation.NoEdit
            .Columns("pres_codSicy").CellActivation = Activation.NoEdit
            .Columns("stpr_descripcion").CellActivation = Activation.NoEdit
            .Columns("prod_modelo").CellActivation = Activation.NoEdit
            '.Columns("pres_codSicy").CellActivation = Activation.NoEdit

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdHistoricoPreciosBase.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdHistoricoPreciosBase.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.VisibleIndex
        grdHistoricoPreciosBase.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

        For Each item In cmbListas.Items
            Dim Nombre() As String
            'Nombre = item.DisplayText.Split("(")
            Nombre = item.DataValue.Split("(")
            If grdHistoricoPreciosBase.DisplayLayout.Bands(0).Columns.Exists(Nombre(0)) Then
                grdHistoricoPreciosBase.DisplayLayout.Bands(0).Columns(Nombre(0)).CellAppearance.TextHAlign = HAlign.Right
                grdHistoricoPreciosBase.DisplayLayout.Bands(0).Columns(Nombre(0)).Width = 65
            End If
        Next
    End Sub

    Public Sub formatoListas()
        For Each rowDT As DataRow In dtTitulosListas.Rows
            grdHistoricoPreciosBase.DisplayLayout.Bands(0).Columns(rowDT.Item("lpba_codigolistabase").ToString).CellActivation = Activation.NoEdit
            grdHistoricoPreciosBase.DisplayLayout.Bands(0).Columns(rowDT.Item("lpba_codigolistabase").ToString).Width = 65
            grdHistoricoPreciosBase.DisplayLayout.Bands(0).Columns(rowDT.Item("lpba_codigolistabase").ToString).Width = 65
        Next
    End Sub

    Public Sub exportarPDF()
        Dim sfd As New SaveFileDialog
        Dim ugde As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter()
        sfd.DefaultExt = "pdf"
        sfd.Filter = "PDF files (*.pdf)|*.pdf"
        Dim result As DialogResult = sfd.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            Dim fileName As String = sfd.FileName
            ugde.AutoSize = Infragistics.Win.UltraWinGrid.DocumentExport.AutoSize.SizeColumnsToContent
            ugde.TargetPaperOrientation = PageOrientation.Portrait
            ugde.TargetPaperSize = PageSizes.A4
            Dim r As Report = New Report()

            Dim sec As ISection = r.AddSection()
            Dim img As Infragistics.Documents.Reports.Graphics.Image = New Infragistics.Documents.Reports.Graphics.Image(Global.Ventas.Vista.My.Resources.Resources.GRUPOYUYIN)

            Dim sectionHeader As Infragistics.Documents.Reports.Report.Section.ISectionHeader = sec.AddHeader()
            sectionHeader.Repeat = True
            sectionHeader.Height = 100

            Dim sectionHeaderImg As Infragistics.Documents.Reports.Report.IImage = sectionHeader.AddImage(img, 0, 0)
            sectionHeaderImg.Paddings.All = 10


            Dim sectionHeaderText As Infragistics.Documents.Reports.Report.Text.IText = sectionHeader.AddText(350, 20)
            sectionHeaderText.Paddings.Top = 10
            sectionHeaderText.Alignment = New TextAlignment(Alignment.Left)
            sectionHeaderText.Style.Font.Bold = True
            sectionHeaderText.AddContent("             Listas de Precios Base")

            Dim sectionHeaderDate As Infragistics.Documents.Reports.Report.Text.IText = sectionHeader.AddText(350, 5)
            sectionHeaderDate.Paddings.Top = 50
            sectionHeaderDate.Alignment = New TextAlignment(Alignment.Left)
            sectionHeaderDate.AddContent("       Historial de Listas de Precios Base                                                             ")
            sectionHeaderDate.AddContent("Impresión: " + DateTime.Now.ToString("G"))

            Dim sectionFooter As Infragistics.Documents.Reports.Report.Section.ISectionFooter = sec.AddFooter()
            sectionFooter.Repeat = True
            sectionFooter.Height = 60

            Dim NombreArchivo() As String
            Dim archivo As String
            NombreArchivo = sfd.FileName.Split("\")

            For Each item In NombreArchivo
                If item.Contains(".pd") Then
                    archivo = item
                End If
            Next

            Dim sectionFooterText As Infragistics.Documents.Reports.Report.Text.IText = sectionFooter.AddText(0, 0)
            sectionFooterText.Alignment = New TextAlignment(Alignment.Left)
            sectionFooterText.AddContent(archivo)
                                         
            Dim sectionFooter2Text As Infragistics.Documents.Reports.Report.Text.IText = sectionFooter.AddText(0, 0)
            sectionFooter2Text.Alignment = New TextAlignment(Alignment.center)
            sectionFooter2Text.AddContent("Página: ")
            sectionFooter2Text.AddPageNumber(PageNumberFormat.Decimal)

            Dim sectionFooter3Text As Infragistics.Documents.Reports.Report.Text.IText = sectionFooter.AddText(0, 0)
            sectionFooter3Text.Alignment = New TextAlignment(Alignment.Right)
            sectionFooter3Text.AddContent(Entidades.SesionUsuario.UsuarioSesion.PUserUsername)

            ugde.Export(grdHistoricoPreciosBase, sec)

            Me.Cursor = Cursors.Default
            Try
                Dim objExito As New Tools.ExitoForm
                objExito.mensaje = "El archivo se exportó correctamente en la ubicación: " + sfd.FileName
                objExito.StartPosition = FormStartPosition.CenterScreen
                r.Publish(fileName, FileFormat.PDF)
                Process.Start(fileName)
                objExito.ShowDialog()
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Dim objError As New Tools.ErroresForm
                objError.mensaje = "El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento PDF " + vbLf + "abierto con el mismo nombre."
                objError.StartPosition = FormStartPosition.CenterScreen
                objError.ShowDialog()
            End Try
        End If
    End Sub

    Public Sub exportarExcel()
        Dim sfd As New SaveFileDialog
        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"

        'sfd.Filter = "XLS files (*.xls)|*.xls"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                exportExcelListasP.Export(grdHistoricoPreciosBase, fileName)
                Process.Start(fileName)
                Me.Cursor = Cursors.Default
                Dim objExito As New Tools.ExitoForm
                objExito.StartPosition = FormStartPosition.CenterScreen
                objExito.mensaje = "Archivo Exportado Correctamente en la ubicacion: " + fileName
                objExito.ShowDialog()
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Dim objErrores As New Tools.ErroresForm
                objErrores.StartPosition = FormStartPosition.CenterScreen
                objErrores.mensaje = "El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre."
                objErrores.ShowDialog()
            End Try

        End If
    End Sub
    Private Sub ListaBaseHistorico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized
        llenarComboCodigos()
    End Sub

    

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If grdHistoricoPreciosBase.Rows.Count > 0 Then
            exportarExcel()
        Else
            Dim objAdvertencia As New Tools.AdvertenciaForm
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.mensaje = "No hay registros que exportar"
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Private Sub btnGenerarReportePDF_Click(sender As Object, e As EventArgs) Handles btnGenerarReportePDF.Click
        If grdHistoricoPreciosBase.Rows.Count > 0 Then
            exportarPDF()
        Else
            MsgBox("No hay registros que exportar", MsgBoxStyle.Information, "")
        End If
    End Sub

    Private Sub exportExcelListasP_ExportStarted(sender As Object, e As ExcelExport.ExportStartedEventArgs) Handles exportExcelListasP.ExportStarted

    End Sub

    Private Sub grdHistoricoPreciosBase_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdHistoricoPreciosBase.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdHistoricoPreciosBase_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdHistoricoPreciosBase.InitializeLayout
        grdHistoricoPreciosBase.DisplayLayout.Bands(0).Columns(" ").Header.VisiblePosition = 1
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        llenarTablaHistoricos()
        chkSelccionarTodo.Checked = False
        lblContados.Text = "0"
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        llenarComboCodigos()
        grdHistoricoPreciosBase.DataSource = Nothing
    End Sub

    Private Sub grdHistoricoPreciosBase_CellChange(sender As Object, e As CellEventArgs) Handles grdHistoricoPreciosBase.CellChange
        If e.Cell.Column.Key = " " And e.Cell.Row.Index <> grdHistoricoPreciosBase.Rows.FilterRow.Index Then
            Dim contadorSeleccion As Int32 = 0
            For Each rowGR As UltraGridRow In grdHistoricoPreciosBase.Rows
                If CBool(rowGR.Cells(" ").Text) = True Then
                    contadorSeleccion += 1
                End If
            Next
            lblContados.Text = contadorSeleccion.ToString("N0")
        End If
    End Sub

    Private Sub btnHistorico_Click(sender As Object, e As EventArgs) Handles btnHistorico.Click
        If lblContados.Text = "0" Then
            Dim objAdvertencia As New Tools.AdvertenciaForm
            objAdvertencia.Tamaño_Letra = 16
            objAdvertencia.mensaje = "Debes seleccionar un artículo para consultar su histórico."
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
            Return
        End If


        Dim hsProductos As New HashSet(Of String)
        Dim hsCodigosListasBase As New HashSet(Of String)
        Dim hsEstiloProductoId As New HashSet(Of String)


        Dim objHistoricoPorProducto As New HistorialPrecioArticulo
        objHistoricoPorProducto.Text = "Historial de precios por artículo - Lista Base"
        objHistoricoPorProducto.lblTitulo.Text = "Historial de precios por artículo - Lista Base"
        objHistoricoPorProducto.StartPosition = FormStartPosition.CenterScreen


        For Each row As UltraGridRow In grdHistoricoPreciosBase.Rows
            If row.Cells(" ").Value = True Then
                hsProductos.Add((row.Cells(1).Text))
                hsEstiloProductoId.Add(row.Cells(0).Text)
            End If
        Next

        For Each item In cmbListas.Items
            If item.CheckState = CheckState.Checked Then
                hsCodigosListasBase.Add(item.DataValue)
            End If
        Next

        objHistoricoPorProducto.hsIdCodigosListaBase = hsCodigosListasBase
        objHistoricoPorProducto.hsProductos = hsProductos
        objHistoricoPorProducto.hsEstiloProductoId = hsEstiloProductoId
        objHistoricoPorProducto.Historial_Precio_Articulo = True

        objHistoricoPorProducto.ShowDialog()

    End Sub

    Private Sub chkSelccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelccionarTodo.CheckedChanged
        'For Each row As UltraGridRow In grdHistoricoPreciosBase.Rows
        '    row.Cells(" ").Value = chkSelccionarTodo.Checked
        'Next

        'If chkSelccionarTodo.Checked Then
        '    lblContados.Text = grdHistoricoPreciosBase.Rows.Count.ToString("N0")
        'Else
        '    lblContados.Text = "0"
        'End If

        'For Each rowGr As UltraGridRow In grdHistoricoPreciosBase.Rows.GetFilteredInNonGroupByRows
        '    rowGr.Cells("Seleccion").Value = CBool(chkSelccionarTodo.Checked)
        'Next
        For Each rowGr As UltraGridRow In grdHistoricoPreciosBase.Rows.GetFilteredInNonGroupByRows
            rowGr.Cells(" ").Value = CBool(chkSelccionarTodo.Checked)
        Next

        Dim contadorSeleccion As Int32 = 0
        For Each rowGR As UltraGridRow In grdHistoricoPreciosBase.Rows
            If CBool(rowGR.Cells(" ").Text) = True Then
                contadorSeleccion += 1
            End If
        Next
        lblContados.Text = contadorSeleccion.ToString("N0")
    End Sub

    Private Sub lblHistorico_Click(sender As Object, e As EventArgs) Handles lblHistorico.Click

    End Sub

    Private Sub lblArticulos_Click(sender As Object, e As EventArgs) Handles lblArticulos.Click

    End Sub

End Class