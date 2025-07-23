Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class DevolucionInformativaSalidaAlmacenForm

    Private var_idEmbarque As Integer
    Private var_cliente As String
    Private var_fechaEmbarque As String
    Private var_pares As Integer
    Private var_paresEmbarque As Integer
    Private var_paresEntregados As Integer
    Private var_tipoConsulta As Integer

    Sub New(idEmbarque As Integer, cliente As String, fechaEmbarque As String, pares As Integer, paresEmbarque As Integer, paresEntregados As Integer, tipoConsulta As Integer)
        InitializeComponent()
        var_idEmbarque = idEmbarque
        var_cliente = cliente
        var_fechaEmbarque = fechaEmbarque
        var_pares = pares
        var_paresEmbarque = paresEmbarque
        var_paresEntregados = paresEntregados
        var_tipoConsulta = tipoConsulta
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New AdvertenciaForm
        grid = grdParesDevueltos
        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
            nombreDocumento = "\ParesNoRecibidos_Embarque" + lblIdEmbarque.Text + "_"

            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog

                If ret = Windows.Forms.DialogResult.OK Then

                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                    gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                    Dim mensajeExito As New ExitoForm
                    mensajeExito.mensaje = "Los datos se exportaron correctamente"
                    mensajeExito.ShowDialog()

                End If
                .Dispose()
            End With
        Else
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
    End Sub

    Private Sub DevolucionInformativaSalidaAlmacenForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objBU As New Negocios.SalidasAlmacenBU
        Dim tblParesDevueltos As New DataTable
        Dim tblDatosEmbarque As New DataTable

        lblIdEmbarque.Text = ""
        lblCliente.Text = ""
        lblFechaEmbarque.Text = ""
        lblParesEmbarque.Text = ""
        lblTotalParesEmbarque.Text = ""
        lblParesEntregadosEmbarque.Text = ""
        lblParesNoRecibidos.Text = "0"

        tblDatosEmbarque = objBU.seleccionarDatosEmbarque(var_idEmbarque, var_cliente)

        lblIdEmbarque.Text = var_idEmbarque
        lblCliente.Text = var_cliente
        lblFechaEmbarque.Text = tblDatosEmbarque.Rows(0)("sade_fechaembarque").ToString()
        lblParesEmbarque.Text = tblDatosEmbarque.Rows(0)("sade_totalParesEmbarcados").ToString()
        lblTotalParesEmbarque.Text = tblDatosEmbarque.Rows(0)("sade_totalParesEmbarcados").ToString()
        lblParesEntregadosEmbarque.Text = tblDatosEmbarque.Rows(0)("sade_totalParesEntregados").ToString()
        'lblParesFaltantesEmbarque.Text = Integer.Parse(lblTotalParesEmbarque.Text) - Integer.Parse(lblParesEntregadosEmbarque.Text)
        lblParesNoRecibidos.Text = tblDatosEmbarque.Rows(0)("sade_totalParesNoRecibidos").ToString()


        tblParesDevueltos = objBU.seleccionarParesDevueltos(var_idEmbarque, var_cliente)
        grdParesDevueltos.DataSource = tblParesDevueltos
        gridParesDiseño(grdParesDevueltos)

        If var_tipoConsulta = 2 Then
            btnAceptar.Enabled = False
            lblAceptar.Enabled = False
            lblMensajeEditarPrsNoRecibidos.Visible = False
            chkSeleccionarTodo.Visible = False
        Else
            btnCancelar.Enabled = False
            lblCancelar.Enabled = False
            lblMensajeEditarPrsNoRecibidos.Visible = True
            chkSeleccionarTodo.Visible = True
        End If

    End Sub

    Private Sub gridParesDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns("sade_salidadetalleid").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("paresDevueltosAnteriormente").Hidden = True

        'grid.DisplayLayout.Bands(0).Columns("seleccionar").Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
        'grid.DisplayLayout.Bands(0).Columns("seleccionar").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
        'grid.DisplayLayout.Bands(0).Columns("seleccionar").Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection
        grid.DisplayLayout.Bands(0).Columns("seleccionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("seleccionar").Style = ColumnStyle.CheckBox
        grid.DisplayLayout.Bands(0).Columns("seleccionar").DefaultCellValue = False
        grid.DisplayLayout.Bands(0).Columns("seleccionar").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("seleccionar").Header.Caption = ""

        grid.DisplayLayout.Bands(0).Columns("sade_idfactura").Header.Caption = "Factura"
        grid.DisplayLayout.Bands(0).Columns("sade_idfactura").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_idfactura").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("sade_añodocumento").Header.Caption = "Año"
        grid.DisplayLayout.Bands(0).Columns("sade_añodocumento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_añodocumento").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("sade_iddocumento").Header.Caption = "Docto"
        grid.DisplayLayout.Bands(0).Columns("sade_iddocumento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_iddocumento").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("sade_idpedido").Header.Caption = "Pedido"
        grid.DisplayLayout.Bands(0).Columns("sade_idpedido").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_idpedido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("sade_nombredistribucion_tienda").Header.Caption = "Tienda"
        grid.DisplayLayout.Bands(0).Columns("sade_nombredistribucion_tienda").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("sade_statusembarque").Header.Caption = "Status"
        grid.DisplayLayout.Bands(0).Columns("sade_statusembarque").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("sade_descripcionmodelo").Header.Caption = "Descripción"
        grid.DisplayLayout.Bands(0).Columns("sade_descripcionmodelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("sade_descripcioncorrida").Header.Caption = "Corrida"
        grid.DisplayLayout.Bands(0).Columns("sade_descripcioncorrida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_descripcioncorrida").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("sade_calce").Header.Caption = "Talla"
        grid.DisplayLayout.Bands(0).Columns("sade_calce").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_calce").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("pares").Header.Caption = "PrsEmbarque"
        grid.DisplayLayout.Bands(0).Columns("pares").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("pares").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("pares").Format = "n0"

        grid.DisplayLayout.Bands(0).Columns("paresDevueltos").Header.Caption = "PrsNoRecibidos"
        If var_tipoConsulta = 2 Then
            grid.DisplayLayout.Bands(0).Columns("paresDevueltos").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        End If
        grid.DisplayLayout.Bands(0).Columns("paresDevueltos").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("paresDevueltos").Format = "n0"

        grid.DisplayLayout.Bands(0).Columns("sade_fechaembarque").Header.Caption = "Fecha Embarque"
        grid.DisplayLayout.Bands(0).Columns("sade_fechaembarque").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_fechaembarque").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("sade_fechaembarque").Format = "dd/MM/yyyy HH:mm:ss"

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grid.DisplayLayout.GroupByBox.Hidden = False
        grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"

        grid.DisplayLayout.Bands(0).Columns("seleccionar").Width = 20

        Dim summary1, summary2 As SummarySettings

        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("pares"))
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right
        summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Devueltos", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("paresDevueltos"))
        summary2.DisplayFormat = "{0:#,##0}"
        summary2.Appearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"


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

        For Each row As UltraGridRow In grid.Rows
            If row.Cells("paresDevueltos").Value = row.Cells("pares").Value Then
                row.Cells("seleccionar").Hidden = True
                row.Cells("paresDevueltos").Activation = Activation.NoEdit
            End If
        Next

        If var_tipoConsulta = 2 Then
            grid.DisplayLayout.Bands(0).Columns("seleccionar").Hidden = True
        End If

    End Sub


    Private Sub grdParesDevueltos_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdParesDevueltos.AfterCellUpdate
        Dim totalParesDevueltos As Integer = 0
        'If e.Cell.Column.ToString = "seleccionar" Then
        '    If CBool(e.Cell.Value) Then
        '        grdParesDevueltos.ActiveRow.Cells("seleccionar").Value = False
        '    Else
        '        grdParesDevueltos.ActiveRow.Cells("seleccionar").Value = True
        '    End If
        If e.Cell.Column.ToString <> "paresDevueltos" Then
            For Each row As UltraGridRow In grdParesDevueltos.Rows
                If CBool(row.Cells("seleccionar").Value) = True And row.Cells("seleccionar").Hidden = False Then
                    row.Cells("paresDevueltos").Value = row.Cells("pares").Value
                Else
                    row.Cells("paresDevueltos").Value = row.Cells("paresDevueltosAnteriormente").Value
                End If
            Next
        End If
        'Else
        For Each row As UltraGridRow In grdParesDevueltos.Rows
            If row.Cells("paresDevueltos").Value > row.Cells("pares").Value Then
                row.Cells("paresDevueltos").Value = row.Cells("pares").Value
            End If
            totalParesDevueltos += row.Cells("paresDevueltos").Value
        Next
        'End If
        lblParesNoRecibidos.Text = totalParesDevueltos.ToString("#,##0")
    End Sub

    Private Sub grdParesDevueltos_CellChange(sender As Object, e As CellEventArgs) Handles grdParesDevueltos.CellChange
        Try
            Dim Seleccionados As Integer = 0
            If e.Cell.Column.ToString = "seleccionar" And e.Cell.Hidden = False Then
                If CBool(e.Cell.Value) Then
                    grdParesDevueltos.ActiveRow.Cells("seleccionar").Value = False
                Else
                    grdParesDevueltos.ActiveRow.Cells("seleccionar").Value = True
                End If

                If CBool(grdParesDevueltos.ActiveRow.Cells("seleccionar").Value) = True Then
                    grdParesDevueltos.ActiveRow.Cells("paresDevueltos").Value = grdParesDevueltos.ActiveRow.Cells("pares").Value
                Else
                    grdParesDevueltos.ActiveRow.Cells("paresDevueltos").Value = grdParesDevueltos.ActiveRow.Cells("paresDevueltosAnteriormente").Value
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim objBU As New Negocios.SalidasAlmacenBU
        Dim IdSalidasAEmbarcar As String = String.Empty
        Dim confirmacion As New confirmarFormGrande
        confirmacion.mensaje = "¿Está seguro de guardar el registro de " + lblParesNoRecibidos.Text + " pares no recibidos ? Este proceso también realizará la salida de todos los pares del inventario (ID Embarque: " + lblIdEmbarque.Text + " Cliente: " + lblCliente.Text + "), no olvide solicitar al área de Calidad la captura de la devolución en SICY."
        If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            Try
                For Each row As UltraGridRow In grdParesDevueltos.Rows
                    If row.Cells("seleccionar").Hidden = False Then
                        objBU.actualizarParesDevueltos(row.Cells("sade_salidadetalleid").Value, row.Cells("paresDevueltos").Value)
                    End If
                    If IdSalidasAEmbarcar <> "" Then
                        IdSalidasAEmbarcar += ", "
                    End If
                    IdSalidasAEmbarcar += row.Cells("sade_salidadetalleid").Value.ToString
                Next
                show_message("Exito", "Datos guardados correctamente")
                grdParesDevueltos.DataSource = Nothing
                DevolucionInformativaSalidaAlmacenForm_Load(sender, e)

                Dim objGeneracionSalida As New Entidades.GeneracionSalida
                objGeneracionSalida.PIdDetalleEntrega = IdSalidasAEmbarcar
                objGeneracionSalida.PUsuarioSalida = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                objGeneracionSalida.PCantidadParesSalida = lblParesEmbarque.Text
                objGeneracionSalida.PCantidadParesNoRecibidos = lblParesNoRecibidos.Text

                Dim resultadoGeneracionSalida As New DataTable
                resultadoGeneracionSalida = objBU.generarSalida(objGeneracionSalida)
                show_message(resultadoGeneracionSalida.Rows(0).Item("tipoResultado"), resultadoGeneracionSalida.Rows(0).Item("resultado"))
                Cursor = Cursors.Default
                Me.Close()
            Catch ex As Exception
                show_message("Error", "Error: " + ex.Message)
            End Try
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

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        If grdParesDevueltos.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor
            If chkSeleccionarTodo.Checked Then
                For Each row As UltraGridRow In grdParesDevueltos.Rows.GetFilteredInNonGroupByRows
                    row.Cells("Seleccionar").Value = True
                Next
            Else
                For Each row As UltraGridRow In grdParesDevueltos.Rows.GetFilteredInNonGroupByRows
                    row.Cells("Seleccionar").Value = False
                Next
            End If
            Cursor = Cursors.Default
        Else
            chkSeleccionarTodo.Checked = False
        End If
    End Sub
End Class