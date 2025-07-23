Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section

Public Class HistorialPrecioArticulo

    Public hsIdCodigosListaBase As New HashSet(Of String)
    Public hsProductos As New HashSet(Of String)
    Public Historial_Precio_Articulo As Boolean ''TRUE PARA ARTICULO, FALSA PARA PRECIO
    Public hsEstiloProductoId As New HashSet(Of String)
    Public IdCliente As Integer
    Public NombreCliente As String



    Private Sub HistorialPrecioArticulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = 2

        If Historial_Precio_Articulo = True Then
            Me.Cursor = Cursors.WaitCursor
            RecuperarHistoricoArticulo()
            Me.Cursor = Cursors.Default
        Else
            Me.Cursor = Cursors.WaitCursor
            RecuperarHistorialCliente()
            Me.Cursor = Cursors.Default
        End If

    End Sub


    Private Sub RecuperarHistorialCliente()
        Dim dtCliente As New DataTable
        Dim objBU As New Negocios.ListaBaseBU

        dtCliente = objBU.RecuperarHistorialCliente(IdCliente)

        gridListadoParametros.DataSource = dtCliente

    End Sub

    Private Sub RecuperarHistoricoArticulo()
        Dim objBU As New Negocios.ListaBaseBU

        Dim dtGrid As New DataTable
        dtGrid = objBU.RecuperarHistorialDeProductos(hsProductos, hsIdCodigosListaBase, hsEstiloProductoId)

        gridListadoParametros.DataSource = dtGrid

    End Sub



    Private Sub gridListadoParametros_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridListadoParametros.InitializeLayout
        If gridListadoParametros.Rows.Count = 0 Then Return

        Me.gridListadoParametros.DisplayLayout.GroupByBox.Prompt = "Arrastra columnas para agruparlas."
        Dim valueList As ValueList = e.Layout.FilterOperatorsValueList
        Dim item As ValueListItem
        For Each item In valueList.ValueListItems
            Dim filterOperator As FilterComparisionOperator = DirectCast(item.DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Contains = filterOperator Then
                item.DisplayText = "CONTIENE"
            ElseIf FilterComparisionOperator.DoesNotEndWith = filterOperator Then
                item.DisplayText = "NO TERMINA CON"
            ElseIf FilterComparisionOperator.DoesNotStartWith = filterOperator Then
                item.DisplayText = "NO COMIENZA CON"
            ElseIf FilterComparisionOperator.EndsWith = filterOperator Then
                item.DisplayText = "TERMINA CON"
            ElseIf FilterComparisionOperator.Equals = filterOperator Then
                item.DisplayText = "IGUAL"
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                item.DisplayText = "MAYOR QUE"
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                item.DisplayText = "MAYOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                item.DisplayText = "MENOR QUE"
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                item.DisplayText = "MENOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.NotEquals = filterOperator Then
                item.DisplayText = "DIFERENTE A"
            ElseIf FilterComparisionOperator.StartsWith = filterOperator Then
                item.DisplayText = "COMIENZA CON"
            End If
        Next

        Dim cont As Integer
        For cont = valueList.ValueListItems.Count - 1 To 0 Step -1
            Dim filterOperator As FilterComparisionOperator = DirectCast(valueList.ValueListItems.Item(cont).DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Custom = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotContain = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotMatch = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Like = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Match = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.NotLike = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            End If
        Next


        With gridListadoParametros

            .DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 45
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
            .DisplayLayout.GroupByBox.Hidden = False
            .DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
            If Historial_Precio_Articulo Then
                .DisplayLayout.Bands(0).Columns("Inicio Precio Anterior (Hr)").Style = ColumnStyle.DateTime
                .DisplayLayout.Bands(0).Columns("Fin Precio Anterior (Hr)").Style = ColumnStyle.DateTime
                .DisplayLayout.Bands(0).Columns("Inicio Precio Anterior").Style = ColumnStyle.Date
                .DisplayLayout.Bands(0).Columns("Fin Precio Anterior").Style = ColumnStyle.Date

                .DisplayLayout.Bands(0).Columns("Lista Base").CellAppearance.TextHAlign = HAlign.Right
                .DisplayLayout.Bands(0).Columns("Precio Anterior").CellAppearance.TextHAlign = HAlign.Right
                .DisplayLayout.Bands(0).Columns("Precio Actualizado").CellAppearance.TextHAlign = HAlign.Right
                .DisplayLayout.Bands(0).Columns("Diferencia").CellAppearance.TextHAlign = HAlign.Right

                .DisplayLayout.Bands(0).Columns("Precio Anterior").Format = "N0"
                .DisplayLayout.Bands(0).Columns("Precio Actualizado").Format = "N0"
                .DisplayLayout.Bands(0).Columns("Diferencia").Format = "N0"
            Else
                .DisplayLayout.Bands(0).Columns("Inicio Precio Ant (Hr)").Style = ColumnStyle.DateTime
                .DisplayLayout.Bands(0).Columns("Fin Precio Ant (Hr)").Style = ColumnStyle.DateTime
                .DisplayLayout.Bands(0).Columns("Inicio Precio Ant").Style = ColumnStyle.Date
                .DisplayLayout.Bands(0).Columns("Fin Precio Ant").Style = ColumnStyle.Date

                .DisplayLayout.Bands(0).Columns("Precio Act").CellAppearance.TextHAlign = HAlign.Right
                .DisplayLayout.Bands(0).Columns("Precio Ant").CellAppearance.TextHAlign = HAlign.Right
                .DisplayLayout.Bands(0).Columns("Precio Extr Act").CellAppearance.TextHAlign = HAlign.Right
                .DisplayLayout.Bands(0).Columns("Precio Extr Ant").CellAppearance.TextHAlign = HAlign.Right
                .DisplayLayout.Bands(0).Columns("Diferencia").CellAppearance.TextHAlign = HAlign.Right

                .DisplayLayout.Bands(0).Columns("Precio Act").Format = "N0"
                .DisplayLayout.Bands(0).Columns("Precio Ant").Format = "N0"
                .DisplayLayout.Bands(0).Columns("Precio Extr Act").Format = "N2"
                .DisplayLayout.Bands(0).Columns("Precio Extr Ant").Format = "N2"
                .DisplayLayout.Bands(0).Columns("Diferencia").Format = "N0"

            End If

        End With



    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If gridListadoParametros.Rows.Count > 0 Then
            exportarExcel()
        Else
            Dim objAdvertencia As New Tools.AdvertenciaForm
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.mensaje = "No hay registros que exportar"
            objAdvertencia.ShowDialog()
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
                ExportExcelHistorial.Export(gridListadoParametros, fileName)
                Process.Start(fileName)
                Me.Cursor = Cursors.Default

                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()

            Catch ex As Exception
                Me.Cursor = Cursors.Default

                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.Text = "El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre."
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try

        End If
    End Sub


    Private Sub btnGenerarReportePDF_Click(sender As Object, e As EventArgs) Handles btnGenerarReportePDF.Click
        If gridListadoParametros.Rows.Count > 0 Then
            exportarPDF()
        Else
            Dim objAdvertencia As New Tools.AdvertenciaForm
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.mensaje = "No hay registros que exportar"
            objAdvertencia.ShowDialog()
        End If
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

            If Historial_Precio_Articulo = True Then
                Dim sectionHeaderText As Infragistics.Documents.Reports.Report.Text.IText = sectionHeader.AddText(350, 20)
                sectionHeaderText.Paddings.Top = 10
                sectionHeaderText.Alignment = New TextAlignment(Alignment.Left)
                sectionHeaderText.Style.Font.Bold = True
                sectionHeaderText.AddContent("                          Listas de Precios Base")

                Dim sectionHeaderDate As Infragistics.Documents.Reports.Report.Text.IText = sectionHeader.AddText(350, 5)
                sectionHeaderDate.Paddings.Top = 50
                sectionHeaderDate.Alignment = New TextAlignment(Alignment.Left)
                sectionHeaderDate.AddContent("                      Historial de Precios por Artículo                                                                   ")
                sectionHeaderDate.AddContent("Impresión: " + DateTime.Now.ToString("G"))
            Else
                Dim sectionHeaderText As Infragistics.Documents.Reports.Report.Text.IText = sectionHeader.AddText(600, 20)
                sectionHeaderText.Paddings.Top = 10
                sectionHeaderText.Alignment = New TextAlignment(Alignment.Left)
                sectionHeaderText.Style.Font.Bold = True
                sectionHeaderText.AddContent("              Historial de Listas de Precios de Cliente")

                Dim sectionHeaderDate As Infragistics.Documents.Reports.Report.Text.IText = sectionHeader.AddText(600, 0)
                sectionHeaderDate.Paddings.Top = 50
                sectionHeaderDate.Alignment = New TextAlignment(Alignment.Left)
                sectionHeaderDate.AddContent("              Cliente :" + NombreCliente + "                                                                           ")
                sectionHeaderDate.AddContent("                                    Impresión: " + DateTime.Now.ToString("G"))
            End If


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
            sectionFooter2Text.Alignment = New TextAlignment(Alignment.Center)
            sectionFooter2Text.AddContent("Página: ")
            sectionFooter2Text.AddPageNumber(PageNumberFormat.Decimal)

            Dim sectionFooter3Text As Infragistics.Documents.Reports.Report.Text.IText = sectionFooter.AddText(0, 0)
            sectionFooter3Text.Alignment = New TextAlignment(Alignment.Right)
            sectionFooter3Text.AddContent(Entidades.SesionUsuario.UsuarioSesion.PUserUsername)

            ugde.Export(gridListadoParametros, sec)

            Try
                r.Publish(fileName, FileFormat.PDF)
                Dim objExito As New Tools.ExitoForm
                objExito.mensaje = "El archivo se exportó correctamente en la ubicación: " + sfd.FileName
                objExito.StartPosition = FormStartPosition.CenterScreen
                Me.Cursor = Cursors.Default
                objExito.ShowDialog()
                Process.Start(fileName)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Dim objError As New Tools.ErroresForm
                objError.mensaje = "El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento PDF " + vbLf + "abierto con el mismo nombre."
                objError.StartPosition = FormStartPosition.CenterScreen
                objError.ShowDialog()
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


End Class