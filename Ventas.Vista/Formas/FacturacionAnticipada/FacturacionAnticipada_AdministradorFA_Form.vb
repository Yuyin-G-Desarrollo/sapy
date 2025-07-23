Imports System.Data.OleDb
Imports System.IO
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class FacturacionAnticipada_AdministradorFA_Form
    Dim objFactAnticipadaBU As Negocios.FacturacionAnticipadaBU
    Dim entCliente As Entidades.Cliente
    Dim emptyEditor As RepositoryItem
    Dim checkedRowIndex As Integer = -1

    Private Sub FacturacionAnticipada_AdministradorFA_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarComboCliente()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CargarComboCliente()
        objFactAnticipadaBU = New Negocios.FacturacionAnticipadaBU
        Dim listClientes As List(Of Entidades.Cliente)
        Try
            listClientes = objFactAnticipadaBU.ConsultarClientesDistribuciones
            cmbCliente.DataSource = listClientes
            cmbCliente.DisplayMember = "nombregenerico"
            cmbCliente.ValueMember = "clienteid"

            'cmbCliente.SelectedIndex = 0
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub btnImportarDistribucion_Click(sender As Object, e As EventArgs) Handles btnImportarDistribucion.Click

        If checkedRowIndex > -1 Then
            Me.Cursor = Cursors.WaitCursor
            Dim estatusDistribucionID As Integer

            estatusDistribucionID = grdVDistribuciones.GetRowCellValue(grdVDistribuciones.GetVisibleRowHandle(checkedRowIndex), "StatusID")

            If estatusDistribucionID = 0 Then
                Dim viewImportarDistribuciones As New FacturacionAnticipada_ImportarDistribucionTiendas_Form
                Dim entDistribucion = New Entidades.DistribucionPedido
                grdVDistribuciones.ClearColumnsFilter()
                viewImportarDistribuciones.tipoArchivoImportado = entCliente.TipoArchivoDistribucionTiendas
                entDistribucion.Cliente = entCliente
                entDistribucion.PedidoSAY = grdVDistribuciones.GetRowCellValue(grdVDistribuciones.GetVisibleRowHandle(checkedRowIndex), "PedidoSAY")
                entDistribucion.PedidoSICY = CInt(grdVDistribuciones.GetRowCellValue(grdVDistribuciones.GetVisibleRowHandle(checkedRowIndex), "PedidoSICY"))
                entDistribucion.ParesPedido = grdVDistribuciones.GetRowCellValue(grdVDistribuciones.GetVisibleRowHandle(checkedRowIndex), "ParesPedido")
                entDistribucion.OrdenCliente = grdVDistribuciones.GetRowCellValue(grdVDistribuciones.GetVisibleRowHandle(checkedRowIndex), "OrdenCliente")
                viewImportarDistribuciones.entDistribucion = entDistribucion

                ''VALIDA QUE NO TENGA YA GENERARDA OT EL PEDIDO PARA PODER GUARDAR LA DISTRIBUCIÓN
                Dim dtPedidoOT As DataTable
                dtPedidoOT = objFactAnticipadaBU.validarPedidoSinOT(entDistribucion.PedidoSAY)

                If dtPedidoOT.Rows.Count > 0 Then
                    show_message("Advertencia", "EL pedido " + dtPedidoOT.Rows(0).Item(0).ToString + " ya tiene una orden de trabajo en estatus " + dtPedidoOT.Rows(0).Item(1).ToString)
                Else
                    viewImportarDistribuciones.ShowDialog()
                End If
                btnMostrar_Click(Nothing, Nothing)
                checkedRowIndex = -1
                lblPedidoSeleccionado.Text = "0"
            Else
                show_message("Advertencia", "Ya tiene cargada una distribución del pedido seleccionado, si quiere cargar una nueva, es necesario cancelar esta distribución (Solo puede hacerlo si se encuentra en estatus POR FACTURAS).")
            End If
            Me.Cursor = Cursors.Default
        Else
            show_message("Advertencia", "Debe seleccionar un pedido para cargar su distribución.")
        End If

    End Sub

    Private Sub btnCancelarDistribucion_Click(sender As Object, e As EventArgs) Handles btnCancelarDistribucion.Click
        Me.Cursor = Cursors.WaitCursor
        If checkedRowIndex > -1 Then
            Dim estatusDistribucionID As Integer
            Dim estatusDistribucion As String
            Dim usuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            Dim entDistribucion = New Entidades.DistribucionPedido

            estatusDistribucionID = grdVDistribuciones.GetRowCellValue(checkedRowIndex, "StatusID")
            estatusDistribucion = grdVDistribuciones.GetRowCellValue(checkedRowIndex, "Status")

            If estatusDistribucionID = 325 Then
                Dim msg_Conf As New Tools.ConfirmarForm
                objFactAnticipadaBU = New Negocios.FacturacionAnticipadaBU
                entDistribucion.Cliente = entCliente
                entDistribucion.PedidoSAY = grdVDistribuciones.GetRowCellValue(checkedRowIndex, "PedidoSAY")
                entDistribucion.PedidoSICY = CInt(grdVDistribuciones.GetRowCellValue(checkedRowIndex, "PedidoSICY"))
                entDistribucion.ParesPedido = grdVDistribuciones.GetRowCellValue(checkedRowIndex, "ParesPedido")
                entDistribucion.OrdenCliente = grdVDistribuciones.GetRowCellValue(checkedRowIndex, "OrdenCliente")
                entDistribucion.OrdenTrabajoID = grdVDistribuciones.GetRowCellValue(checkedRowIndex, "OTSay")
                entDistribucion.DistribucionPedidoID = grdVDistribuciones.GetRowCellValue(checkedRowIndex, "distribucionPedidoID")
                msg_Conf.mensaje = "Al cancelar la distribución " + entDistribucion.DistribucionPedidoID.ToString + " se cancelará también la OT " + entDistribucion.OrdenTrabajoID.ToString + " por " + entDistribucion.ParesPedido.ToString + " pares, ¿ Desea continuar ?"
                If msg_Conf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Try
                        objFactAnticipadaBU.CancelarDistribucionPedido(entDistribucion, usuarioID)
                        show_message("Exito", "Se canceló correctamente la Distribución y la Orden de trabajo.")
                    Catch ex As Exception
                        show_message("Error", ex.Message)
                    End Try
                    btnMostrar_Click(Nothing, Nothing)
                    checkedRowIndex = -1
                    lblPedidoSeleccionado.Text = "0"
                End If
            Else
                show_message("Advertencia", "No se puede cancelar la distribución " + entDistribucion.DistribucionPedidoID.ToString + " " + estatusDistribucion + ", únicamente puede cancelarlas estando en status POR FACTURAR.")
            End If
        Else
            show_message("Advertencia", "Debe seleccionar un pedido para cargar la distribución.")
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Try
            ExportarAExcel(grdVDistribuciones, "PedidosDistribuciones")
        Catch ex As Exception
            show_message("Error", "Ocurrió un error al exportar la información. " + ex.Message)
        End Try
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim sinDistribucion As Boolean
        Dim conDistribucion As Boolean
        Dim dtDistribucionesPedidos As DataTable

        sinDistribucion = chkSinDistribuciones.Checked
        conDistribucion = chkConDistribuciones.Checked

        lblUltimaActualizacion.Text = Date.Now

        entCliente = TryCast(cmbCliente.SelectedItem, Entidades.Cliente)

        conDistribucion = chkConDistribuciones.Checked
        sinDistribucion = chkSinDistribuciones.Checked

        If Not conDistribucion And Not sinDistribucion Then
            show_message("Advertencia", "Debe seleccionar un filtro valido.")
            Return
        End If

        Try
            objFactAnticipadaBU = New Negocios.FacturacionAnticipadaBU
            dtDistribucionesPedidos = objFactAnticipadaBU.ConsultarPedidosDistribucionesPorCliente(entCliente.clienteid, conDistribucion, sinDistribucion)

            grdDistribuciones.DataSource = dtDistribucionesPedidos
            DiseñarGrid(grdVDistribuciones)
            'AplicarReglasFormatoGrid(grdVDistribuciones)
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DiseñarGrid(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        'Grid.OptionsView.BestFitMaxRowCount = -1
        Grid.OptionsView.ColumnAutoWidth = True
        Grid.BestFitColumns()

        Grid.IndicatorWidth = 40

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsColumn.AllowEdit = False
            col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Next

        Grid.Columns.ColumnByFieldName(" ").OptionsColumn.AllowEdit = True
        Grid.Columns.ColumnByFieldName("StatusID").Visible = False

        Grid.Columns.ColumnByFieldName("distribucionPedidoID").Caption = "IdDist"

        Grid.Columns.ColumnByFieldName("ParesPedido").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Grid.Columns.ColumnByFieldName("ParesArchivo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Grid.Columns.ColumnByFieldName("ParesPedido").SummaryItem.DisplayFormat = "{0:N0}"
        Grid.Columns.ColumnByFieldName("ParesArchivo").SummaryItem.DisplayFormat = "{0:N0}"
        Grid.Columns.ColumnByFieldName("FImportación").DisplayFormat.FormatType = FormatType.DateTime
        Grid.Columns.ColumnByFieldName("FImportación").DisplayFormat.FormatString = "dd/MM/yyyy h:mm:ss tt"
        Grid.Columns.ColumnByFieldName("FCancelación").DisplayFormat.FormatType = FormatType.DateTime
        Grid.Columns.ColumnByFieldName("FCancelación").DisplayFormat.FormatString = "dd/MM/yyyy h:mm:ss tt"
        Grid.Columns.ColumnByFieldName("ParesPedido").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("ParesPedido").DisplayFormat.FormatString = "N0"
        Grid.Columns.ColumnByFieldName("ParesArchivo").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("ParesArchivo").DisplayFormat.FormatString = "N0"


    End Sub

    Public Sub ExportarAExcel(Grid As DevExpress.XtraGrid.Views.Grid.GridView, NombreArchivo As String)
        'PREGUNTA AL USUARIO DONDE GUARDAR EL ARCHIVO
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
        SaveFileDialog.FilterIndex = 2
        SaveFileDialog.RestoreDirectory = True

        'ASIGNAMOS UN NOMBRE AL ARCHIVO
        SaveFileDialog.FileName = NombreArchivo + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString + ".xlsx"
        If Grid.RowCount > 0 Then
            If SaveFileDialog.ShowDialog = DialogResult.OK Then

                'ESTO ES NECESARIO PARA QUE EL EXCEL NO HAGA QUE TODAS LAS CUADRICULAS SEAN MUY PEQUEÑAS.
                'ESTO EXPORTARÁ TODAS LAS CUADRICULAS ESPACIADAS UNIFORMENTE.
                Grid.OptionsPrint.AutoWidth = False
                Grid.OptionsPrint.UsePrintStyles = False
                'Grid.OptionsPrint.EnableAppearanceEvenRow = True
                'Grid.OptionsPrint.EnableAppearanceOddRow = True
                'Grid.OptionsPrint.PrintHorzLines = False
                'Grid.OptionsPrint.PrintVertLines = False

                'Grid.OptionsPrint.PrintPreview = True

                Dim FileName As String = SaveFileDialog.FileName

                'Dim exportOptions = New DevExpress.XtraPrinting.XlsxExportOptionsEx
                'exportOptions.AllowConditionalFormatting = True
                'exportOptions.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True
                'exportOptions.ExportType = DevExpress.Export.ExportType.DataAware
                DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG
                Grid.ExportToXlsx(FileName)

                show_message("Exito", "Los datos se exportaron correctamente.")

                System.Diagnostics.Process.Start(FileName)
            End If
        Else
            show_message("Exito", "No hay registros para exportar.")
        End If
    End Sub

    Private Sub AplicarReglasFormatoGrid(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim gridFormatRule As DevExpress.XtraGrid.GridFormatRule
        Dim formatConditionRuleExpression As DevExpress.XtraEditors.FormatConditionRuleExpression

        '======================================================================================================
        '======================================================================================================
        gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        gridFormatRule.Column = Grid.Columns.ColumnByFieldName("Status")
        gridFormatRule.ApplyToRow = True

        formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        formatConditionRuleExpression.PredefinedName = "Light Text"
        formatConditionRuleExpression.Expression = "[Status] = 'SIN DISTRIBUCIÓN ACTIVA'"
        formatConditionRuleExpression.Appearance.BackColor = Color.FromArgb(255, 204, 204)

        gridFormatRule.Rule = formatConditionRuleExpression
        Grid.FormatRules.Add(gridFormatRule)
        '======================================================================================================
        '======================================================================================================
        gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        gridFormatRule.Column = Grid.Columns.ColumnByFieldName("Status")
        gridFormatRule.ApplyToRow = False

        formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        formatConditionRuleExpression.PredefinedName = "Bold Text"
        formatConditionRuleExpression.Expression = "[Status] = 'POR FACTURAR'"
        formatConditionRuleExpression.Appearance.ForeColor = Color.FromArgb(242, 102, 0)

        gridFormatRule.Rule = formatConditionRuleExpression
        Grid.FormatRules.Add(gridFormatRule)
        '======================================================================================================
        '======================================================================================================
        gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        gridFormatRule.Column = Grid.Columns.ColumnByFieldName("Status")
        gridFormatRule.ApplyToRow = False

        formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        formatConditionRuleExpression.PredefinedName = "Bold Text"
        formatConditionRuleExpression.Expression = "[Status] = 'PARCIALMENTE CONFIRMADA'"
        formatConditionRuleExpression.Appearance.ForeColor = Color.FromArgb(162, 48, 160)

        gridFormatRule.Rule = formatConditionRuleExpression
        Grid.FormatRules.Add(gridFormatRule)
        '======================================================================================================
        '======================================================================================================
        gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        gridFormatRule.Column = Grid.Columns.ColumnByFieldName("Status")
        gridFormatRule.ApplyToRow = False

        formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        formatConditionRuleExpression.PredefinedName = "Bold Text"
        formatConditionRuleExpression.Expression = "[Status] = 'PARCIALMENTE CONFIRMADA'"
        formatConditionRuleExpression.Appearance.ForeColor = Color.FromArgb(162, 48, 160)

        gridFormatRule.Rule = formatConditionRuleExpression
        Grid.FormatRules.Add(gridFormatRule)
        '======================================================================================================
        '======================================================================================================
        gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        gridFormatRule.Column = Grid.Columns.ColumnByFieldName("Status")
        gridFormatRule.ApplyToRow = False

        formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        formatConditionRuleExpression.PredefinedName = "Bold Text"
        formatConditionRuleExpression.Expression = "[Status] = 'CANCELADA'"
        formatConditionRuleExpression.Appearance.ForeColor = Color.FromArgb(255, 0, 0)

        gridFormatRule.Rule = formatConditionRuleExpression
        Grid.FormatRules.Add(gridFormatRule)
        '======================================================================================================
        '======================================================================================================
        gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        gridFormatRule.Column = Grid.Columns.ColumnByFieldName("Status")
        gridFormatRule.ApplyToRow = False

        formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        formatConditionRuleExpression.PredefinedName = "Bold Text"
        formatConditionRuleExpression.Expression = "[Status] = 'POR FACTURAR'"
        formatConditionRuleExpression.Appearance.ForeColor = Color.FromArgb(255, 102, 0)

        gridFormatRule.Rule = formatConditionRuleExpression
        Grid.FormatRules.Add(gridFormatRule)
        '======================================================================================================
        '======================================================================================================
        gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        gridFormatRule.Column = Grid.Columns.ColumnByFieldName("Status")
        gridFormatRule.ApplyToRow = False

        formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        formatConditionRuleExpression.PredefinedName = "Bold Text"
        formatConditionRuleExpression.Expression = "[Status] = 'FACTURADA'"
        formatConditionRuleExpression.Appearance.ForeColor = Color.FromArgb(49, 112, 192)

        gridFormatRule.Rule = formatConditionRuleExpression
        Grid.FormatRules.Add(gridFormatRule)
        '======================================================================================================
        '======================================================================================================
        gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        gridFormatRule.Column = Grid.Columns.ColumnByFieldName("Status")
        gridFormatRule.ApplyToRow = False

        formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        formatConditionRuleExpression.PredefinedName = "Bold Text"
        formatConditionRuleExpression.Expression = "[Status] = 'ENTREGADA'"
        formatConditionRuleExpression.Appearance.ForeColor = Color.FromArgb(0, 176, 80)

        gridFormatRule.Rule = formatConditionRuleExpression
        Grid.FormatRules.Add(gridFormatRule)

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cmbCliente.DataSource = Nothing
        grdDistribuciones.DataSource = Nothing
        CargarComboCliente()
        chkConDistribuciones.Checked = True
        chkSinDistribuciones.Checked = True
        checkedRowIndex = -1
        lblPedidoSeleccionado.Text = "0"
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub grdVDistribuciones_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVDistribuciones.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    'Private Sub grdVDistribuciones_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles grdVDistribuciones.CustomRowCellEdit
    '    If e.Column.FieldName = " " And (grdVDistribuciones.GetRowCellValue(e.RowHandle, "Status") <> "SIN DISTRIBUCIÓN ACTIVA") And (grdVDistribuciones.GetRowCellValue(e.RowHandle, "Status") <> "CANCELADA") And (grdVDistribuciones.GetRowCellValue(e.RowHandle, "Status") <> "POR FACTURAR") Then
    '        emptyEditor = New RepositoryItem
    '        e.RepositoryItem = emptyEditor
    '    End If
    'End Sub

    Private Sub grdVDistribuciones_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles grdVDistribuciones.CellValueChanging
        Dim Grid = TryCast(sender, GridView)
        If e.Column.FieldName = " " Then
            If CBool(e.Value) Then
                Dim rowHandle = Grid.GetRowHandle(checkedRowIndex)
                Grid.SetRowCellValue(rowHandle, " ", False)
                checkedRowIndex = Grid.GetDataSourceRowIndex(e.RowHandle)
                lblPedidoSeleccionado.Text = Grid.GetRowCellValue(e.RowHandle, "PedidoSAY")
            Else
                checkedRowIndex = -1
                lblPedidoSeleccionado.Text = "0"
            End If
        End If
    End Sub

    Private Sub grdVDistribuciones_RowStyle(sender As Object, e As RowStyleEventArgs) Handles grdVDistribuciones.RowStyle
        Dim grid = TryCast(sender, GridView)
        If e.RowHandle > 0 Then
            Dim estatus As String = grid.GetRowCellDisplayText(e.RowHandle, "Status")
            If estatus = "SIN DISTRIBUCIÓN ACTIVA" Then
                e.Appearance.BackColor = Color.FromArgb(255, 204, 204)
            End If
        End If
    End Sub

    Private Sub grdVDistribuciones_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles grdVDistribuciones.RowCellStyle
        Dim grid = TryCast(sender, GridView)
        If e.RowHandle > 0 Then
            Dim estatus As String = grid.GetRowCellDisplayText(e.RowHandle, "Status")
            If e.Column.FieldName = "Status" Then
                If estatus = "POR FACTURAR" Then
                    e.Appearance.ForeColor = Color.FromArgb(242, 102, 0)
                    e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                End If
                If estatus = "PARCIALMENTE CONFIRMADA" Then
                    e.Appearance.ForeColor = Color.FromArgb(162, 48, 160)
                    e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                End If
                If estatus = "CANCELADA" Then
                    e.Appearance.ForeColor = Color.FromArgb(255, 0, 0)
                    e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                End If
                If estatus = "FACTURADA" Then
                    e.Appearance.ForeColor = Color.FromArgb(49, 112, 192)
                    e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                End If
                If estatus = "ENTREGADA" Then
                    e.Appearance.ForeColor = Color.FromArgb(0, 176, 80)
                    e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                End If
            End If
        End If
    End Sub

End Class