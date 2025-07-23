Imports DevExpress.Export
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Negocios
Imports Tools

Public Class Programacion_ColocacionSemanal_ParesColocadosPorTalla
    Dim listaInicial As New List(Of String)
    Dim listPedidoSAY As New List(Of String)

    Private Sub Programacion_ColocacionSemanal_ParesColocadosPorTalla_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdNave.DataSource = listaInicial
        grdPielColor.DataSource = listaInicial
        grdModelo.DataSource = listaInicial
        grdCorrida.DataSource = listaInicial
        grdCliente.DataSource = listaInicial
        grdColeccion.DataSource = listaInicial
        grdPedidoSAY.DataSource = listaInicial

        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now
    End Sub

    Private Sub btnMostrar_Click_1(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New Programacion_MapaOcupacionBU
        Dim dtObtieneParesPorTalla As New DataTable
        Dim FNave As String = String.Empty
        Dim FColeccion As String = String.Empty
        Dim FModelo As String = String.Empty
        Dim FPielColor As String = String.Empty
        Dim FCorrida As String = String.Empty
        Dim FCliente As String = String.Empty
        Dim FPedidoSAY As String = String.Empty
        Dim FechaInicio As Date = dtpFechaInicio.Value.ToShortDateString()
        Dim FechaFin As Date = dtpFechaFin.Value.ToShortDateString()
        Dim FiltroFecha As Integer = 0

        Try

            Me.Cursor = Cursors.WaitCursor

            grdParesColocados.DataSource = Nothing
            vwParesColocados.Columns.Clear()

            FNave = ObtenerFiltrosGrid(grdNave)
            FColeccion = ObtenerFiltrosGrid(grdColeccion)
            FModelo = ObtenerFiltrosGrid(grdModelo)
            FPielColor = ObtenerFiltrosGrid(grdPielColor)
            FCorrida = ObtenerFiltrosGrid(grdCorrida)
            FCliente = ObtenerFiltrosGrid(grdCliente)
            FPedidoSAY = ObtenerFiltrosGrid(grdPedidoSAY)

            If chFecha.Checked = True Then
                If FechaInicio > FechaFin Then
                    show_message("Advertencia", "La fecha inicio no puede ser mayor a la fecha fin.")
                    Exit Sub
                End If
                If rdoProgramacion.Checked = True Then
                    FiltroFecha = 1 'FechaProgramación 
                ElseIf rdoSolicitaCliente.Checked = True Then
                    FiltroFecha = 2 'FechaSolicitaCliente
                End If
            End If

            dtObtieneParesPorTalla = objBU.ObtenerParesColocadosPorTalla(FNave, FColeccion, FModelo, FPielColor, FCorrida, FCliente, FPedidoSAY, FiltroFecha,
                                                                         FechaInicio, FechaFin)

            If dtObtieneParesPorTalla.Rows.Count > 0 Then

                pnlBotonesExpander.AutoSize = True
                pnlParametros.Visible = False

                grdParesColocados.DataSource = dtObtieneParesPorTalla
                lblUltimaActualizacion.Text = Date.Now
                lblRegistros.Text = CDbl(vwParesColocados.RowCount.ToString()).ToString("n0")
                DisenioGrid()
                ParesTotales()

            Else
                show_message("Advertencia", "No se encontraron datos por mostrar.")
            End If
        Catch ex As Exception
            show_message("Error", ex.Message)
        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub DisenioGrid()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwParesColocados.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False

            If IsNumeric(col.FieldName) Or col.FieldName.Contains("½") Then
                col.DisplayFormat.FormatString = "N0"
                col.Width = 45
                col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            Else
                col.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            End If

        Next

        vwParesColocados.Columns.ColumnByFieldName("Nave").Width = 70
        vwParesColocados.Columns.ColumnByFieldName("Semana").Width = 60
        vwParesColocados.Columns.ColumnByFieldName("Marca").Width = 60
        vwParesColocados.Columns.ColumnByFieldName("Colección").Width = 120
        vwParesColocados.Columns.ColumnByFieldName("Modelo").Width = 60
        vwParesColocados.Columns.ColumnByFieldName("Piel Color").Width = 100
        vwParesColocados.Columns.ColumnByFieldName("Cliente").Width = 100
        vwParesColocados.Columns.ColumnByFieldName("Corrida").Width = 60
        vwParesColocados.Columns.ColumnByFieldName("Pedido SAY").Width = 60
        vwParesColocados.Columns.ColumnByFieldName("Partida").Width = 60
        vwParesColocados.Columns.ColumnByFieldName("Pares Totales").Width = 60
        vwParesColocados.Columns.ColumnByFieldName("Pares Colocados").Width = 70
        vwParesColocados.IndicatorWidth = 45

        Tools.DiseñoGrid.AlternarColorEnFilas(vwParesColocados)

    End Sub

    Private Sub ParesTotales()
        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem

        For Each vColumna As DevExpress.XtraGrid.Columns.GridColumn In vwParesColocados.Columns
            If vColumna.FieldName.Contains("Pares Totales") Or vColumna.FieldName.Contains("Pares Colocados") Or IsNumeric(vColumna.FieldName) Or vColumna.FieldName.Contains("½") Then
                vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                item = New DevExpress.XtraGrid.GridGroupSummaryItem
                item.FieldName = vColumna.FieldName
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0}"
                vwParesColocados.GroupSummary.Add(item)
                vColumna.OptionsFilter.AllowFilter = False
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

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New Tools.AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New Tools.AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New Tools.ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim filename As String
        Try
            If vwParesColocados.RowCount > 0 Then
                Dim SaveFileDialog As New SaveFileDialog()
                SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
                SaveFileDialog.FilterIndex = 2
                SaveFileDialog.RestoreDirectory = True

                If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                    vwParesColocados.OptionsPrint.AutoWidth = True
                    vwParesColocados.OptionsPrint.EnableAppearanceEvenRow = True
                    vwParesColocados.OptionsPrint.PrintPreview = True
                    filename = SaveFileDialog.FileName

                    Dim exportOptions = New XlsxExportOptionsEx()
                    AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                    DevExpress.Export.ExportSettings.DefaultExportType = ExportType.Default
                    vwParesColocados.ExportToXlsx(filename, exportOptions)

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

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        If (e.RowHandle Mod 2 > 0) Then
            e.Formatting.BackColor = Color.LightSteelBlue
        End If
        e.Handled = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAgregarNave_Click_1(sender As Object, e As EventArgs) Handles btnAgregarNave.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 1

        For Each row As UltraGridRow In grdNave.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdNave.DataSource = listado.listParametros
        With grdNave
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
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

    Private Sub btnLimpiarNave_Click_1(sender As Object, e As EventArgs) Handles btnLimpiarNave.Click
        grdNave.DataSource = listaInicial
    End Sub

    Private Sub grdNave_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles grdNave.InitializeLayout
        grid_diseño(grdNave)
        grdNave.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Naves"
    End Sub

    Private Sub grdNave_KeyDown(sender As Object, e As KeyEventArgs)
        If Not e.KeyCode = Keys.Delete Then Return
        grdNave.DeleteSelectedRows(False)
    End Sub

    Private Sub btnAgregarColeccion_Click_1(sender As Object, e As EventArgs) Handles btnAgregarColeccion.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 9

        For Each row As UltraGridRow In grdColeccion.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColeccion.DataSource = listado.listParametros
        With grdColeccion
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colección"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimpiarColeccion_Click_1(sender As Object, e As EventArgs) Handles btnLimpiarColeccion.Click
        grdColeccion.DataSource = listaInicial
    End Sub

    Private Sub grdColeccion_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        grid_diseño(grdColeccion)
        grdColeccion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colección"
    End Sub

    Private Sub grdColeccion_KeyDown_1(sender As Object, e As KeyEventArgs) Handles grdColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub btnAgregarModelo_Click_1(sender As Object, e As EventArgs) Handles btnAgregarModelo.Click
        LlenarGridFiltro(grdModelo, "Modelo", 3)
    End Sub

    Private Sub btnLimpiarModelo_Click_1(sender As Object, e As EventArgs) Handles btnLimpiarModelo.Click
        grdModelo.DataSource = listaInicial
    End Sub

    Private Sub grdModelo_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles grdModelo.InitializeLayout
        grid_diseño(grdModelo)
        grdModelo.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Modelo"
    End Sub

    Private Sub grdModelo_KeyDown_1(sender As Object, e As KeyEventArgs) Handles grdModelo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdModelo.DeleteSelectedRows(False)
    End Sub

    Private Sub LlenarGridFiltro(pGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal pHeader As String, ByVal pTipoBusqueda As Integer)
        Dim listado As New ListadoParametrosFiltradoForm
        listado.tipo_busqueda = pTipoBusqueda


        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In pGrid.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        pGrid.DataSource = listado.listParametros

        With pGrid
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = pHeader
        End With
    End Sub

    Private Sub btnAgregarPielColor_Click_1(sender As Object, e As EventArgs) Handles btnAgregarPielColor.Click
        LlenarGridFiltro(grdPielColor, "Piel / Color", 7)
    End Sub

    Private Sub btnLimpiarPielColor_Click_1(sender As Object, e As EventArgs) Handles btnLimpiarPielColor.Click
        grdPielColor.DataSource = listaInicial
    End Sub

    Private Sub grdPielColor_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles grdPielColor.InitializeLayout
        grid_diseño(grdPielColor)
        grdPielColor.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Piel Color"
    End Sub

    Private Sub grdPielColor_KeyDown_1(sender As Object, e As KeyEventArgs) Handles grdPielColor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPielColor.DeleteSelectedRows(False)
    End Sub

    Private Sub btnAgregarCorrida_Click_1(sender As Object, e As EventArgs) Handles btnAgregarCorrida.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 12

        For Each row As UltraGridRow In grdCorrida.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdCorrida.DataSource = listado.listParametros
        With grdCorrida
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Corrida"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimpiarCorrida_Click_1(sender As Object, e As EventArgs) Handles btnLimpiarCorrida.Click
        grdCorrida.DataSource = listaInicial
    End Sub

    Private Sub grdCorrida_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles grdCorrida.InitializeLayout
        grid_diseño(grdCorrida)
        grdCorrida.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Corrida"
    End Sub

    Private Sub grdCorrida_KeyDown(sender As Object, e As KeyEventArgs)
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPedidoSAY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSAY.InitializeLayout
        grid_diseño(grdPedidoSAY)
        grdPedidoSAY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdPedidoSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSAY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSAY.DeleteSelectedRows(False)
    End Sub

    Private Sub txtPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSAY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSAY.Text) Then Return

            listPedidoSAY.Add(txtPedidoSAY.Text)
            grdPedidoSAY.DataSource = Nothing
            grdPedidoSAY.DataSource = listPedidoSAY

            txtPedidoSAY.Text = String.Empty
        End If
    End Sub

    Private Sub btnLimpiarFiltroPedidoSAY_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroPedidoSAY.Click
        grdPedidoSAY.DataSource = Nothing
        listPedidoSAY.Clear()
        grdPedidoSAY.DataSource = listaInicial
    End Sub

    Private Sub btnArriba_Click_1(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlBotonesExpander.AutoSize = True
        pnlParametros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlBotonesExpander.AutoSize = True
        pnlParametros.Visible = True
    End Sub

    Private Sub btnAgregarCliente_Click_1(sender As Object, e As EventArgs) Handles btnAgregarCliente.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 5

        For Each row As UltraGridRow In grdCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdCliente.DataSource = listado.listParametros
        With grdCliente
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Clientes"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimpiarCliente_Click_1(sender As Object, e As EventArgs) Handles btnLimpiarCliente.Click
        grdCliente.DataSource = listaInicial
    End Sub

    Private Sub grdCliente_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_diseño(grdCliente)
        grdCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Clientes"
    End Sub

    Private Sub grdCliente_KeyDown_1(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub btnLimpiar_Click_1(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdNave.DataSource = listaInicial
        grdColeccion.DataSource = listaInicial
        grdPielColor.DataSource = listaInicial
        grdModelo.DataSource = listaInicial
        grdCorrida.DataSource = listaInicial
        grdCliente.DataSource = listaInicial
        grdPedidoSAY.DataSource = listaInicial
    End Sub

    Private Sub vwParesColocados_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwParesColocados.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub chFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chFecha.CheckedChanged
        If chFecha.Checked = False Then
            grpFecha.Enabled = False
        Else
            grpFecha.Enabled = True
        End If
    End Sub
End Class