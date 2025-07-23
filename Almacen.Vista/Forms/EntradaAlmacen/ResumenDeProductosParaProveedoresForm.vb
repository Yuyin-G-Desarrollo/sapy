Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports Tools

Public Class ResumenDeProductosParaProveedoresForm
    Public lLotes As String
    Public lAtados As String
    Public lPedidos As String

    Public lProductos As String
    Public lClientes As String
    Public lCorridas As String
    Public lTiendas As String
    Public lTallas As String
    Public ComercializadoraID As Integer
    Public lNave As String

    Public fechaInicioEntradas As String
    Public fechaTerminoEntradas As String

    Public fechaInicioProgramas As String
    Public fechaTerminoProgramas As String

    Public bY_O As Boolean
    Public filtroFechaPrograma As Boolean
    Public Ubicacion As Boolean

    Public resumenNaves As Boolean
    Public resumenNaveconImportes As Boolean

    Dim marca As Boolean
    Dim Coleccion As Boolean
    Dim Talla As Boolean
    Dim Modelo As Boolean
    Dim ColorCorto As Boolean

    Private Sub ResumenDeProductosParaProveedoresForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.StartPosition = FormStartPosition.CenterScreen

        If resumenNaves = True And resumenNaveconImportes = False Then
            pnlFiltrosImportes.Visible = False
        End If
    End Sub


    Private Sub PoblarGridEntradas()

        GridView1.Columns.Clear()

        Dim Mensaje As New AvisoForm
        Mensaje.mensaje = "Este proceso puede tardar dependiendo de la cantidad de pares a verificar."
        Mensaje.ShowDialog()

        Me.Cursor = Cursors.WaitCursor

        Dim objEntradasBU As New Negocios.EntradaProductoBU
        Dim dtTablaEntradas As New DataTable

        gridListaEntradas.DataSource = Nothing
        GridControl1.DataSource = Nothing
        Try
            If resumenNaves = True Then
                dtTablaEntradas = objEntradasBU.RecuperarListaDetallesProductos(Ubicacion, lTallas, lLotes, lAtados, lPedidos, lProductos, lClientes, lCorridas, lTiendas, lNave,
                                                                fechaInicioEntradas, fechaTerminoEntradas, fechaInicioProgramas,
                                                                fechaTerminoProgramas, bY_O, filtroFechaPrograma, ComercializadoraID)
            ElseIf resumenNaveconImportes = True Then
                dtTablaEntradas = objEntradasBU.RecuperarListaDetallesProductosConImporte(lNave, fechaInicioEntradas, fechaTerminoEntradas, bY_O, chkColeccion.Checked,
                                                                                          chkModelo.Checked, chkCorrida.Checked, chkColor.Checked, ComercializadoraID)
            End If

            If dtTablaEntradas.Rows.Count > 0 And resumenNaveconImportes = True Then

                Dim pares As Int32 = 0
                Dim promedio As Double = 0.0
                Dim total As Double = 0.0


                For Each dtRow As DataRow In dtTablaEntradas.Rows
                    pares += dtRow.Item("Pares")
                    total += dtRow.Item("Total")
                Next


                promedio = total / pares

                lblPares.Text = pares.ToString("N0")
                lblPromedio.Text = promedio.ToString("N2")
                lblTotal.Text = total.ToString("N2")

            Else

                Dim pares As Int32 = 0
                Dim promedio As Double = 0.0
                Dim total As Double = 0.0

                lblPares.Text = "0"
                lblPromedio.Visible = False
                lblTotal.Visible = False
                Label3.Visible = False
                Label4.Visible = False

                For Each dtRow As DataRow In dtTablaEntradas.Rows
                    pares += dtRow.Item("Pares")
                Next
                lblPares.Text = pares.ToString("N0")
            End If


        Catch ex As Exception
            Me.Cursor = Cursors.Default
            Dim MensajeError As New ErroresForm
            MensajeError.mensaje = ex.Message
            MensajeError.ShowDialog()
            Me.Close()
        End Try

        If dtTablaEntradas.Rows.Count = 0 Then
            Dim formaInformacion As New AvisoForm
            formaInformacion.StartPosition = FormStartPosition.CenterScreen
            formaInformacion.mensaje = "No se encontraron registros."
            formaInformacion.ShowDialog()
            Me.Close()
            Return
        Else
            GridControl1.DataSource = Nothing
            GridControl1.DataSource = dtTablaEntradas

            diseno_grdidev()
            'GridView1.BestFitColumns()

            'gridListaEntradas.DataSource = Nothing
            'gridListaEntradas.DataSource = dtTablaEntradas
        End If

    End Sub
    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = GridView1.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub
    Private Sub diseno_grdidev()
        GridView1.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        AddHandler GridView1.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
        GridView1.Columns.Item("#").VisibleIndex = 0
        GridView1.OptionsView.ColumnAutoWidth = True
        GridView1.BestFitMaxRowCount = -1
        GridView1.Columns.ColumnByFieldName("#").Width = 50



        For i As Integer = 1 To GridView1.RowCount - 1
            If i Mod 2 = 0 Then
                'GridView1.OptionsView.EnableAppearanceOddRow = Color.LightSteelBlue
                GridView1.Appearance.EvenRow.BackColor = Color.LightSteelBlue
                GridView1.OptionsView.EnableAppearanceEvenRow = True
                GridView1.Invalidate()
            End If
        Next

        GridView1.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways
        'MsgBox(GridView1.Columns.Count)
        If GridView1.Columns.Count >= 6 Then
            GridView1.Columns("Pares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares", "{0:n0}")
            GridView1.Columns("Pares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GridView1.Columns("Pares").DisplayFormat.FormatString = "n0"

        Else
            GridView1.Columns("Pares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GridView1.Columns("Pares").DisplayFormat.FormatString = "n0"
            GridView1.Columns("Precio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GridView1.Columns("Precio").DisplayFormat.FormatString = "c2"
            GridView1.Columns("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GridView1.Columns("Total").DisplayFormat.FormatString = "c2"

            GridView1.Columns("Pares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares", "{0:n0}")



            GridView1.Columns("Total").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:c2}")



        End If






        Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        item.FieldName = "Prs"
        item.SummaryType = DevExpress.Data.SummaryItemType.Count
        item.DisplayFormat = "Total: {0}"
        GridView1.GroupSummary.Add(item)
    End Sub

    '    Private Sub GridView1_RowStyle(ByVal sender As Object, _
    'ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
    '        Dim View As GridView = sender
    '        If (e.RowHandle >= 0) Then
    '            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("#"))
    '            If category Mod 2 > 0 Then
    '                e.Appearance.BackColor = Color.LightSteelBlue
    '                'e.Appearance.BackColor2 = Color.SeaShell
    '            End If
    '        End If
    '    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Dim objAdvertencia As New Tools.AdvertenciaForm
        objAdvertencia.StartPosition = FormStartPosition.CenterScreen

        If Not IsNothing(GridControl1.DataSource) Then
            If GridControl1.MainView.DataRowCount = 0 Then
                objAdvertencia.mensaje = "No se encontraron datos para exportar"
                objAdvertencia.ShowDialog()
            Else

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog

                    If ret = Windows.Forms.DialogResult.OK Then

                        Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                        ' gridExcelExporter.Export(Me.gridListaEntradas, .SelectedPath + "\Datos_ListaUbicaciones_" + fecha_hora + ".xlsx")
                        GridControl1.ExportToXlsx(.SelectedPath + "\Datos_ListaUbicaciones_" + fecha_hora + ".xlsx")
                    End If
                    Dim FORMA As New ExitoForm
                    FORMA.StartPosition = FormStartPosition.CenterScreen
                    FORMA.mensaje = "Los datos se exportaron correctamente"
                    FORMA.ShowDialog()

                    .Dispose()

                End With

            End If


            Me.Close()

        Else

            objAdvertencia.mensaje = "Consulta la informacion para poder exportar el documento."

            objAdvertencia.ShowDialog()

            Return

        End If
    End Sub

    Private Sub gridListaEntradas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridListaEntradas.InitializeLayout
        If gridListaEntradas.Rows.Count = 0 Then Return

        With gridListaEntradas
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 45
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        End With

        If resumenNaveconImportes = True Then
            With gridListaEntradas
                .DisplayLayout.Bands(0).Columns("Pares").CellAppearance.TextHAlign = HAlign.Right
                .DisplayLayout.Bands(0).Columns("Precio").CellAppearance.TextHAlign = HAlign.Right
                .DisplayLayout.Bands(0).Columns("Total").CellAppearance.TextHAlign = HAlign.Right

                .DisplayLayout.Bands(0).Columns("Pares").Format = "N0"
                .DisplayLayout.Bands(0).Columns("Precio").Format = "N"
                .DisplayLayout.Bands(0).Columns("Total").Format = "N"

            End With

            Dim ColumnaSumarPares As UltraGridColumn = gridListaEntradas.DisplayLayout.Bands(0).Columns("Pares")
            Dim sumaPares As SummarySettings = gridListaEntradas.DisplayLayout.Bands(0).Summaries.Add("TOTAL PARES", SummaryType.Sum, ColumnaSumarPares)
            gridListaEntradas.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
            sumaPares.DisplayFormat = "Total (Pares): {0:###,###,###,###}"
            sumaPares.Appearance.TextHAlign = HAlign.Right


            Dim ColumnaSumarTotal As UltraGridColumn = gridListaEntradas.DisplayLayout.Bands(0).Columns("Total")
            Dim SumarTotal As SummarySettings = gridListaEntradas.DisplayLayout.Bands(0).Summaries.Add("$ TOTAL", SummaryType.Sum, ColumnaSumarTotal)
            SumarTotal.DisplayFormat = "Total ($): {0:###,###,###,###0.00}"
            SumarTotal.Appearance.TextHAlign = HAlign.Right

            'Dim promedio As Double = 0
            'promedio = 12

            'Dim ColumnaPrecioPromedio As UltraGridColumn = gridListaEntradas.DisplayLayout.Bands(0).Columns("Precio")
            'Dim PromedioPrecio As SummarySettings = gridListaEntradas.DisplayLayout.Bands(0).Summaries.Add("Precio promedio", SummaryType.Average, ColumnaPrecioPromedio)
            'PromedioPrecio.DisplayFormat = "Precio promedio: {0:###,###,###,###0.00}"
            'PromedioPrecio.Appearance.TextHAlign = HAlign.Right

        Else

            With gridListaEntradas
                .DisplayLayout.Bands(0).Columns("Corrida").Width = 50
                .DisplayLayout.Bands(0).Columns("Modelo").Width = 50
                .DisplayLayout.Bands(0).Columns("Pares").Width = 50
            End With

        End If


    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Me.Cursor = Cursors.WaitCursor

        Try
            PoblarGridEntradas()

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            Dim MensajeError As New ErroresForm
            MensajeError.mensaje = ex.Message
            MensajeError.ShowDialog()
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub gridListaEntradas_SummaryValueChanged(sender As Object, e As SummaryValueChangedEventArgs) Handles gridListaEntradas.SummaryValueChanged
        'Dim cosa As String = e.SummaryValue.Value.ToString
        'Dim summarieColumn As String = e.SummaryValue.Key.ToArray
        'e.SummaryValue.SetExternalSummaryValue = 3

    End Sub


End Class