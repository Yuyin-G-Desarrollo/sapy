Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization

Public Class DetallePlataformaForm

    Public ocupacion_carritoid As Integer

    Private Sub DetallePlataformaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objBU As New Negocios.AlmacenBU
        Dim tabla As New DataTable

        ''ENCABEZADO 
        tabla = objBU.encabezado_Plataforma_Detalle_Plataforma(ocupacion_carritoid)
        If Not IsDBNull(tabla.Rows(0).Item("STATUS ID")) Then


            If Not IsDBNull(tabla.Rows(0).Item("DESCRIPCIÓN")) Then
                lblDescripcionPlataforma.Text = CStr(tabla.Rows(0).Item("DESCRIPCIÓN"))
            End If

            If Not IsDBNull(tabla.Rows(0).Item("VALIDÓ")) Then
                lblValidadorNombre.Text = CStr(tabla.Rows(0).Item("VALIDÓ"))
            Else
                lblValidadorNombre.Text = "--"
            End If

            If Not IsDBNull(tabla.Rows(0).Item("VALIDACIÓN")) Then
                lblFechaValidacion.Text = CStr(tabla.Rows(0).Item("VALIDACIÓN"))
            Else
                lblFechaValidacion.Text = "--"
            End If

            If Not IsDBNull(tabla.Rows(0).Item("OPERADOR")) Then
                lblOperadorNombre.Text = CStr(tabla.Rows(0).Item("OPERADOR"))
            Else
                lblOperadorNombre.Text = "--"
            End If

            If Not IsDBNull(tabla.Rows(0).Item("CARGA DE PLATAFORMA")) Then
                lblFechaCargaPlataforma.Text = CStr(tabla.Rows(0).Item("CARGA DE PLATAFORMA"))
            Else
                lblFechaCargaPlataforma.Text = "--"
            End If

            If Not IsDBNull(tabla.Rows(0).Item("INICIO DESCARGA")) Then
                lblInicioDescargaPlataforma.Text = CStr(tabla.Rows(0).Item("INICIO DESCARGA"))
            Else
                lblInicioDescargaPlataforma.Text = "--"
            End If

            If Not IsDBNull(tabla.Rows(0).Item("FIN DESCARGA")) Then
                lblFinDescargaPlataforma.Text = CStr(tabla.Rows(0).Item("FIN DESCARGA"))
            Else
                lblFinDescargaPlataforma.Text = "--"
            End If

            If Not IsDBNull(tabla.Rows(0).Item("MIN. DESCARGANDO")) Then
                lblMinutosDescargandoPlataforma.Text = CStr(tabla.Rows(0).Item("MIN. DESCARGANDO"))
            Else
                lblMinutosDescargandoPlataforma.Text = "--"
            End If

            Dim status As Integer = CInt(tabla.Rows(0).Item("STATUS ID"))

            If status = 23 Then
                pnlStatusPlataforma.BackColor = Color.Green
                lblStatus.Text = "Completado"
            ElseIf status = 21 Then
                pnlStatusPlataforma.BackColor = Color.Yellow
                lblStatus.Text = "Por Validar"
                ''AQUI SI MUESTRA EL PANEL DE RESUMEN
                pnlAtadoParPlataformaOcupacion.Visible = True
                tabla = objBU.Resumen_Plataforma_Atados_Cargados(ocupacion_carritoid)
                If tabla.Rows.Count > 0 Then
                    If Not IsDBNull(tabla.Rows(0).Item("ATADOS CARGADOS")) Then
                        lblAtadosPlataformaOcupacion.Text = CStr(tabla.Rows(0).Item("ATADOS CARGADOS"))
                    Else
                        lblAtadosPlataformaOcupacion.Text = "--"
                    End If
                    If Not IsDBNull(tabla.Rows(0).Item("PARES CARGADOS")) Then
                        lblParesPlataformaOcupacion.Text = CStr(tabla.Rows(0).Item("PARES CARGADOS"))
                    Else
                        lblParesPlataformaOcupacion.Text = "--"
                    End If
                End If

                tabla = objBU.Resumen_Plataforma_Atados_Ubicados(ocupacion_carritoid)
                If tabla.Rows.Count > 0 Then
                    If Not IsDBNull(tabla.Rows(0).Item("ATADOS DESCARGADOS")) Then
                        lblAtadosPlataformaDescargados.Text = CStr(tabla.Rows(0).Item("ATADOS DESCARGADOS"))
                    Else
                        lblAtadosPlataformaDescargados.Text = "--"
                    End If
                    If Not IsDBNull(tabla.Rows(0).Item("PARES DESCARGADOS")) Then
                        lblParesPlataformaDescargados.Text = CStr(tabla.Rows(0).Item("PARES DESCARGADOS"))
                    Else
                        lblParesPlataformaDescargados.Text = "--"
                    End If
                End If

                tabla = objBU.Resumen_Plataforma_Atados_Pendientes(ocupacion_carritoid)
                If tabla.Rows.Count > 0 Then
                    If Not IsDBNull(tabla.Rows(0).Item("ATADOS PENDIENTES")) Then
                        lblAtadoPendientePlataforma.Text = CStr(tabla.Rows(0).Item("ATADOS PENDIENTES"))
                    Else
                        lblAtadoPendientePlataforma.Text = "--"
                    End If
                    If Not IsDBNull(tabla.Rows(0).Item("PARES PENDIENTES")) Then
                        lblParesPendientePlataforma.Text = CStr(tabla.Rows(0).Item("PARES PENDIENTES"))
                    Else
                        lblParesPendientePlataforma.Text = "--"
                    End If
                End If

                tabla = objBU.Resumen_Plataforma_Atados_Ubicados_Sin_Plataforma(ocupacion_carritoid)
                If tabla.Rows.Count > 0 Then
                    If Not IsDBNull(tabla.Rows(0).Item("ATADOS SIN ESTIBA EN OCUPACION")) Then
                        lblAtadoUbicacionExternoPlataforma.Text = CStr(tabla.Rows(0).Item("ATADOS SIN ESTIBA EN OCUPACION"))
                    Else
                        lblAtadoUbicacionExternoPlataforma.Text = "--"
                    End If
                    If Not IsDBNull(tabla.Rows(0).Item("PARES SIN ESTIBA EN OCUPACION")) Then
                        lblParesUbicacionExternoPlataforma.Text = CStr(tabla.Rows(0).Item("PARES SIN ESTIBA EN OCUPACION"))
                    Else
                        lblParesUbicacionExternoPlataforma.Text = "--"
                    End If
                End If

                tabla = objBU.Resumen_Plataforma_Atados_Con_Status_Diferente_A_1(ocupacion_carritoid)
                If tabla.Rows.Count > 0 Then
                    If Not IsDBNull(tabla.Rows(0).Item("ATADOS EN ERROR")) Then
                        lblAtadoConUbicacionPlataforma.Text = CStr(tabla.Rows(0).Item("ATADOS EN ERROR"))
                    Else
                        lblAtadoConUbicacionPlataforma.Text = "--"
                    End If
                    If Not IsDBNull(tabla.Rows(0).Item("PARES EN ERROR")) Then
                        lblParesConUbicacionPlataforma.Text = CStr(tabla.Rows(0).Item("PARES EN ERROR"))
                    Else
                        lblParesConUbicacionPlataforma.Text = "--"
                    End If
                End If
            ElseIf status = 22 Then
                pnlStatusPlataforma.BackColor = Color.Blue
                lblStatus.Text = "Validado"
            ElseIf status = 20 Then
                pnlStatusPlataforma.BackColor = Color.Red
                lblStatus.Text = "Pendiente"
            ElseIf status = 19 Then
                pnlStatusPlataforma.BackColor = Color.Purple
                lblStatus.Text = "Sin operador"
            ElseIf status = 24 Then
                pnlStatusPlataforma.BackColor = Color.Gray
                lblStatus.Text = "Inconcluso"
            End If


        End If

        poblar_gridDetalleAtadoPlataforma(gridDetalleAtadoPlataforma)

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click



        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        With fbdUbicacionArchivo

            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True

            Dim ret As DialogResult = .ShowDialog

            If ret = Windows.Forms.DialogResult.OK Then

                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                gridExcelExporter.Export(Me.gridDetalleAtadoPlataforma, .SelectedPath + "\DetallePlataforma_" + ocupacion_carritoid.ToString + "_" + fecha_hora + ".xlsx")

            End If
            show_message("Exito", "Los datos se exportaron correctamente")
            .Dispose()

        End With

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Try

            gridDetalleAtadoPlataforma.PrintPreview()

            gridDetalleAtadoPlataforma.Print()
        Catch exc As Exception

            MessageBox.Show("Error occured while printing." & vbCrLf & exc.Message, "Error printing", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub poblar_gridDetalleAtadoPlataforma(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        Me.Cursor = Cursors.WaitCursor

        grid.DataSource = Nothing

        Dim objBU As New Negocios.AlmacenBU
        Dim Tabla_DetalleAtadoPlataforma As New DataTable

        Tabla_DetalleAtadoPlataforma = objBU.Detalle_Plataforma(ocupacion_carritoid)

        If Tabla_DetalleAtadoPlataforma.Rows.Count > 0 Then
            grid.DataSource = Tabla_DetalleAtadoPlataforma
            gridDetalleAtadoPlataformaDiseno(grid)
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub gridDetalleAtadoPlataformaDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        'asignaFormato_Columna(grid)

        'grid.DisplayLayout.Bands(0).Columns("Estiba ID").Hidden = True

        grid.DisplayLayout.Bands(0).Columns("UBICACIÓN (hr)").Style = ColumnStyle.DateTime
        grid.DisplayLayout.Bands(0).Columns("UBICACIÓN (hr)").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("UBICACIÓN (hr)").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("CÓDIGO PAR").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("CÓDIGO ATADO").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("MODELO").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("CORRIDA").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("TALLA").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("PEDIDO").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("PEDIDO ORIGEN").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("PEDIDO CLIENTE").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("LOTE").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("SALIDA NAVE (hr)").Style = ColumnStyle.DateTime
        grid.DisplayLayout.Bands(0).Columns("SALIDA NAVE (hr)").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("SALIDA NAVE (hr)").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("UBICACIÓN").Style = ColumnStyle.Date
        grid.DisplayLayout.Bands(0).Columns("UBICACIÓN").GroupByMode = GroupByMode.Date
        grid.DisplayLayout.Bands(0).Columns("UBICACIÓN").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("UBICACIÓN").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("SALIDA NAVE").Style = ColumnStyle.Date
        grid.DisplayLayout.Bands(0).Columns("SALIDA NAVE").GroupByMode = GroupByMode.Date
        grid.DisplayLayout.Bands(0).Columns("SALIDA NAVE").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("SALIDA NAVE").AllowRowFiltering = DefaultableBoolean.False

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        'grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        'grid.DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.AliceBlue
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        'grid.DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grid.DisplayLayout.GroupByBox.Hidden = False
        grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"


        'Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns("Prs")
        'Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add("TOTAL PARES", SummaryType.Sum, columnToSummarize)
        'grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        'summary.DisplayFormat = "{0}"
        'summary.Appearance.TextHAlign = HAlign.Right


        For Each row As UltraGridRow In grid.Rows

            If row.Cells("PLAT").Text.Equals("SI") Then
                row.Cells("PLAT").Appearance.BackColor = Color.Green
                row.Cells("PLAT").Appearance.ForeColor = Color.Green
            Else
                If row.Cells("PLAT").Text.Equals("NO") Then
                    row.Cells("PLAT").Appearance.BackColor = Color.Orange
                    row.Cells("PLAT").Appearance.ForeColor = Color.Orange
                Else
                    If row.Cells("PLAT").Text.Equals("--") Then
                        row.Cells("PLAT").Appearance.BackColor = Color.Yellow
                        row.Cells("PLAT").Appearance.ForeColor = Color.Yellow
                    Else
                        If row.Cells("PLAT").Text.Equals(" ") Then
                            row.Cells("PLAT").Appearance.BackColor = Color.Red
                            row.Cells("PLAT").Appearance.ForeColor = Color.Red
                        End If
                    End If
                End If
            End If

        Next

        'Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns("Prs")
        'Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add("TOTAL PARES", SummaryType.Sum, columnToSummarize)
        'grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        'summary.DisplayFormat = "{0}"
        'summary.Appearance.TextHAlign = HAlign.Right

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

    Private Sub gridListaUbicacion_BeforePrint(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs) Handles gridDetalleAtadoPlataforma.BeforePrint

        ' Following code shows a message box giving the user a last chance to cancel printing the 
        ' UltraGrid.
        Dim result As DialogResult = MessageBox.Show("¿Seguro que desea imprimir?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If DialogResult.Cancel = result Then e.Cancel = True

    End Sub

    Private Sub gridListaUbicacion_InitializePrintPreview(sender As Object, e As CancelablePrintPreviewEventArgs) Handles gridDetalleAtadoPlataforma.InitializePrintPreview

        e.PrintDocument.DefaultPageSettings.Landscape = True
        e.PrintLayout.Appearance.BackColor = Color.White
        'e.PrintLayout.Grid.DisplayLayout.Appearance.BackColor = Color.White
        'e.PrintLayout.Grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.White
        ''e.PrintPreviewSettings.Zoom = 100
        e.PrintLayout.Override.RowAlternateAppearance.BackColor = Color.White
        e.PrintDocument.DefaultPageSettings.Margins.Left = 0
        e.PrintDocument.DefaultPageSettings.Margins.Right = 0

        With e.PrintLayout

            .Bands(0).Columns(1).Hidden = True
            .Bands(0).Columns(2).Header.Caption = "PAR"
            .Bands(0).Columns(3).Header.Caption = "ATADO"

        End With

    End Sub

    'Muestra el form de mensaje
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