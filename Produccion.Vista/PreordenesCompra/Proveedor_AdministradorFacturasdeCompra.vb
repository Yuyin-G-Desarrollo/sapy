Imports DevExpress.Export
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Produccion.Negocios
Imports Programacion.Vista
Imports Tools

Public Class Proveedor_AdministradorFacturasdeCompra
    Dim objBU As New AdministradorFacturasBU
    Dim listaInicial As New List(Of String)
    Dim eventoActivo As Boolean = False
    Dim confirmar As New ConfirmarForm
    Private Sub Proveedor_AdministradorFacturasdeCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        nudSemanaInicio.Value = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        nudSemanaInicio.TextAlign = HorizontalAlignment.Center
        nudAño.Value = DatePart(DateInterval.Year, Now)
        nudAño.TextAlign = HorizontalAlignment.Center
        lblUltimaActualizacion.Text = ""
        lblSemanaActual.Text = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now
        CargarDatos()

    End Sub

    Private Sub CargarDatos()
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim dtFacturas As New DataTable
        Dim NaveID As Integer = 0
        Dim FProveedor As String = String.Empty
        Dim SemanaPago As Integer = 0
        Dim AñoPago As Integer = 0
        Dim FechaInicio As String = String.Empty
        Dim FechaFin As String = String.Empty

        Cursor = Cursors.WaitCursor

        Try
            grdFacturas.DataSource = Nothing
            vwFacturas.Columns.Clear()

            FProveedor = ObtenerFiltrosGrid(grdProveedor)

            If cmbNave.SelectedIndex <> 0 Then
                NaveID = cmbNave.SelectedValue
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "Seleccione una nave.")
                Exit Sub
            End If

            If chReporteSemanal.Checked Then
                SemanaPago = nudSemanaInicio.Value
                AñoPago = nudAño.Value
            End If

            If chFechaPrograma.Checked Then
                If dtpFechaInicio.Value > dtpFechaFin.Value And chReporteSemanal.Checked = False Then
                    Tools.MostrarMensaje(Mensajes.Warning, "La fecha fin no puede ser menor a la fecha inicio.")
                    dtpFechaFin.Value = dtpFechaInicio.Value
                    Exit Sub
                Else
                    FechaInicio = dtpFechaInicio.Value.ToShortDateString()
                    FechaFin = dtpFechaFin.Value.ToShortDateString()
                End If
            End If

            dtFacturas = objBU.ObtenerFacturas(NaveID, FProveedor, SemanaPago, AñoPago, FechaInicio, FechaFin)

            If dtFacturas.Rows.Count > 0 Then
                grdFacturas.DataSource = dtFacturas
                lblUltimaActualizacion.Text = Date.Now
                lblRegistros.Text = CDbl(vwFacturas.RowCount.ToString()).ToString("n0")
                Diseño()
            Else
                Tools.MostrarMensaje(Tools.modMensajes.Mensajes.Warning, "No existe información para mostrar.")
                Exit Sub
            End If
        Catch ex As Exception

        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Diseño()

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwFacturas.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName <> " " Then
                col.OptionsColumn.AllowEdit = False
            Else
                col.OptionsColumn.AllowEdit = True
            End If
        Next

        vwFacturas.Columns.ColumnByFieldName("ProveedorID").Visible = False

        vwFacturas.Columns.ColumnByFieldName("Subtotal").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwFacturas.Columns.ColumnByFieldName("IVA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwFacturas.Columns.ColumnByFieldName("Importe").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwFacturas.Columns.ColumnByFieldName("Saldo").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        vwFacturas.Columns.ColumnByFieldName("Subtotal").DisplayFormat.FormatString = "N2"
        vwFacturas.Columns.ColumnByFieldName("IVA").DisplayFormat.FormatString = "N2"
        vwFacturas.Columns.ColumnByFieldName("Importe").DisplayFormat.FormatString = "N2"
        vwFacturas.Columns.ColumnByFieldName("Saldo").DisplayFormat.FormatString = "N2"

        vwFacturas.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(vwFacturas.Columns("Saldo").Summary.FirstOrDefault(Function(x) x.FieldName = "Saldo")) = True Then
            vwFacturas.Columns("Saldo").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Saldo", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Saldo"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwFacturas.GroupSummary.Add(item)
        End If

        DiseñoGrid.AlternarColorEnFilas(vwFacturas)
        DiseñoGrid.AjustarAnchoColumnas(vwFacturas)
        DiseñoGrid.AlinearTextoEncabezadoColumnas(vwFacturas)
        DiseñoGrid.AjustarAltoEncabezados(vwFacturas)

    End Sub

    Private Sub btnEnviaFacturas_Click(sender As Object, e As EventArgs) Handles btnEnviaFacturas.Click
        Dim NumeroFilas As Integer = vwFacturas.DataRowCount
        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
        Try
            If NumeroFilas <> 0 Then
                Cursor = Cursors.WaitCursor
                With vwFacturas
                    For index = 0 To NumeroFilas
                        If .GetRowCellValue(index, " ") And .GetRowCellValue(index, "Usuario Envía") = "" Then
                            Dim nodo As XElement = New XElement("Celda")
                            nodo.Add(New XAttribute("Factura", RTrim(LTrim(.GetRowCellValue(index, "Factura")))))
                            nodo.Add(New XAttribute("ProveedorID", .GetRowCellValue(index, "ProveedorID")))
                            nodo.Add(New XAttribute("NaveID", cmbNave.SelectedValue))
                            nodo.Add(New XAttribute("UsuarioID", Entidades.SesionUsuario.UsuarioSesion.PUserUsername))
                            vXmlCeldasModificadas.Add(nodo)
                        End If
                    Next
                End With
                If vXmlCeldasModificadas.HasElements Then
                    confirmar.mensaje = "¿Se enviarán las facturas selecciondas, desea continuar?"
                    If confirmar.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        objBU.EnviarFacturas(vXmlCeldasModificadas.ToString())
                        Tools.MostrarMensaje(Mensajes.Success, "Facturas enviadas correctamente.")
                        btnMostrar_Click(Nothing, Nothing)
                    End If
                End If
                Tools.MostrarMensaje(Mensajes.Warning, "Seleccione una factura para realizar la acción.")
            End If

        Catch ex As Exception

        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCancelarFacturas_Click(sender As Object, e As EventArgs) Handles btnCancelarFacturas.Click
        Dim NumeroFilas As Integer = vwFacturas.DataRowCount
        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
        Try
            If NumeroFilas <> 0 Then
                Cursor = Cursors.WaitCursor
                With vwFacturas
                    For index = 0 To NumeroFilas
                        If .GetRowCellValue(index, " ") And .GetRowCellValue(index, "Usuario Envía") = "" Then
                            Dim nodo As XElement = New XElement("Celda")
                            nodo.Add(New XAttribute("Factura", RTrim(LTrim(.GetRowCellValue(index, "Factura")))))
                            nodo.Add(New XAttribute("ProveedorID", .GetRowCellValue(index, "ProveedorID")))
                            nodo.Add(New XAttribute("NaveID", cmbNave.SelectedValue))
                            nodo.Add(New XAttribute("UsuarioID", Entidades.SesionUsuario.UsuarioSesion.PUserUsername))
                            vXmlCeldasModificadas.Add(nodo)
                        End If
                    Next
                End With
                If vXmlCeldasModificadas.HasElements Then
                    confirmar.mensaje = "¿Se cancelarán las facturas selecciondas, desea continuar esta acción no se podrá revertir?"
                    If confirmar.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        objBU.CancelarFacturas(vXmlCeldasModificadas.ToString())
                        Tools.MostrarMensaje(Mensajes.Success, "Facturas canceladas correctamente.")
                        btnMostrar_Click(Nothing, Nothing)
                    End If
                End If
                Tools.MostrarMensaje(Mensajes.Warning, "Seleccione una factura para realizar la acción.")
            End If

        Catch ex As Exception

        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnReportes_Click(sender As Object, e As EventArgs) Handles btnReportes.Click
        cmsReportes.Show(MousePosition)
    End Sub

    Private Sub ComprasPorDíaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprasPorDíaToolStripMenuItem.Click
        cmsReportes.Show(MousePosition)
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim filename As String
        Try
            If vwFacturas.RowCount > 0 Then
                Dim SaveFileDialog As New SaveFileDialog()
                SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
                SaveFileDialog.FilterIndex = 2
                SaveFileDialog.RestoreDirectory = True

                If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                    vwFacturas.OptionsPrint.AutoWidth = True
                    vwFacturas.OptionsPrint.EnableAppearanceEvenRow = True
                    vwFacturas.OptionsPrint.PrintPreview = True
                    filename = SaveFileDialog.FileName

                    Dim exportOptions = New XlsxExportOptionsEx()
                    AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                    DevExpress.Export.ExportSettings.DefaultExportType = ExportType.Default
                    vwFacturas.ExportToXlsx(filename, exportOptions)

                    If System.IO.File.Exists(filename) Then
                        Dim DialogResult As DialogResult = MessageBox.Show("El archivo ha sido exportado a " & filename & vbNewLine & "¿Quieres abrirlo ahora?", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If DialogResult = Windows.Forms.DialogResult.Yes Then
                            System.Diagnostics.Process.Start(filename)
                        End If
                    End If
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No existen registros para exportar")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdFacturas.DataSource = Nothing
        grdProveedor.DataSource = listaInicial
        lblRegistros.Text = ""
    End Sub
    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = True
    End Sub

    Private Sub chReporteSemanal_CheckedChanged(sender As Object, e As EventArgs) Handles chReporteSemanal.CheckedChanged
        If chReporteSemanal.Checked Then
            grpReporte.Enabled = True
        Else
            grpReporte.Enabled = False
        End If
    End Sub

    Private Sub chFechaPrograma_CheckedChanged(sender As Object, e As EventArgs) Handles chFechaPrograma.CheckedChanged
        If chFechaPrograma.Checked Then
            gbFecha.Enabled = True
        Else
            gbFecha.Enabled = False
        End If
    End Sub

    Private Sub chSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chSeleccionarTodo.CheckedChanged
        Dim activar = False
        If (chSeleccionarTodo.Checked) Then
            activar = True
        End If
        If (eventoActivo = False) Then
            eventoActivo = True
            For i As Integer = 0 To (vwFacturas.RowCount) Step 1
                vwFacturas.SetRowCellValue(i, " ", activar)
            Next
            eventoActivo = False
        End If
    End Sub

    Private Sub btnAgregarProveedor_Click(sender As Object, e As EventArgs) Handles btnAgregarProveedor.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 17

        For Each row As UltraGridRow In grdProveedor.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdProveedor.DataSource = listado.listParametros
        With grdProveedor
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Proveedores"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimpiarProveedor_Click(sender As Object, e As EventArgs) Handles btnLimpiarProveedor.Click
        grdProveedor.DataSource = listaInicial
    End Sub

    Private Sub grdProveedor_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdProveedor.InitializeLayout
        grid_diseño(grdProveedor)
        grdProveedor.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Proveedor"
    End Sub

    Private Sub grdProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles grdProveedor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdProveedor.DeleteSelectedRows(False)
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
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

        asignaFormato_Columna(grid)
    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                col.CellAppearance.TextHAlign = HAlign.Left
            End If
        Next
    End Sub


    Private Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty
        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next
        Return Resultado
    End Function

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        If (e.RowHandle Mod 2 > 0) Then
            e.Formatting.BackColor = Color.LightSteelBlue
        End If
        e.Handled = True
    End Sub

    Private Sub vwFacturas_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwFacturas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
End Class