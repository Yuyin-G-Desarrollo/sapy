Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports System.Globalization
Imports Almacen.Vista
Imports Stimulsoft.Report

Public Class OrdenesEnProcesoForm
    Dim lstPedidos As New List(Of String)
    Dim lstLote As New List(Of String)
    Dim lstModelo As New List(Of String)
    Dim lstModeloSICY As New List(Of String)
    Dim lstPedidosSay As New List(Of String)
    Dim usuarioId As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

#Region "inicio"
    'hola
    Private Sub OrdenesEnProcesoForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        WindowState = FormWindowState.Maximized
        Me.Left = 0
        Me.Top = 0

        dtpFechaDel.Value = Now.ToShortDateString
        dtpFechaAl.Value = Now.ToShortDateString
        rbtFechaPrograma.Checked = True
        cmbReporte.SelectedIndex = 0

        cargaDatosInicio()
        disenioPedidosSICY()
        disenioPedidosSay()
        disenioLote()
        disenioModelo()
        disenioModeloSICY()
        disenioHormas()
        disenioTemporadas()
        disenioCorridas()
        disenioColecciones()
        disenioClientes()
        disenioColores()
        disenioMarca()
        disenioFamilia()
        disenioNavesDesarrollo()
        disenioSuelas()



    End Sub



    Private Sub cargaDatosInicio()
        Dim obj As New OrdenesEnProcesoBU

        cboxNaves = Tools.Controles.ComboNavesSegunUsuarioConIdSIcy(cboxNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        grdNaveDesarrollo.DataSource = obj.ObtieneNaveDesarrollo(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        grdAlmacen.DataSource = obj.ObtieneHormas
        grdVendedores.DataSource = obj.ObtieneTemporadas
        grdCorridas.DataSource = obj.ObtieneCorridas
        grdSuelas.DataSource = obj.ObtieneSuelasProveedor

    End Sub

#End Region

#Region "diseño de grids"

    Private Sub disenioPedidosSICY()
        grdPedidoSICY.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdPedidoSICY.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdPedidoSICY.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grdPedidoSICY.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdPedidoSICY.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdPedidoSICY.DisplayLayout.Override.RowSelectorWidth = 35
        grdPedidoSICY.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        For Each row In grdPedidoSICY.Rows
            row.Activation = Activation.NoEdit
        Next

        grdPedidoSICY.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grdPedidoSICY.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        Me.grdPedidoSICY.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        Me.grdPedidoSICY.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdPedidoSICY.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdPedidoSICY.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPedidoSICY.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

        grdPedidoSICY.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
    End Sub

    Private Sub disenioPedidosSay()
        grdPedidoSay.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdPedidoSay.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdPedidoSay.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grdPedidoSay.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdPedidoSay.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdPedidoSay.DisplayLayout.Override.RowSelectorWidth = 35
        grdPedidoSay.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        For Each row In grdPedidoSay.Rows
            row.Activation = Activation.NoEdit
        Next

        grdPedidoSay.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grdPedidoSay.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        Me.grdPedidoSay.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        Me.grdPedidoSay.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdPedidoSay.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdPedidoSay.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPedidoSay.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

        grdPedidoSay.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
    End Sub
    Private Sub disenioLote()
        grdLote.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdLote.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdLote.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grdLote.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdLote.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdLote.DisplayLayout.Override.RowSelectorWidth = 35
        grdLote.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        For Each row In grdLote.Rows
            row.Activation = Activation.NoEdit
        Next

        grdLote.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grdLote.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        Me.grdLote.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        Me.grdLote.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdLote.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdLote.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdLote.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

        grdLote.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
    End Sub

    Private Sub disenioModelo()
        grdModelo.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdModelo.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdModelo.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grdModelo.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdModelo.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdModelo.DisplayLayout.Override.RowSelectorWidth = 35
        grdModelo.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        For Each row In grdModelo.Rows
            row.Activation = Activation.NoEdit
        Next

        grdModelo.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grdModelo.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        Me.grdModelo.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        Me.grdModelo.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdModelo.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdModelo.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdModelo.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

        grdModelo.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
    End Sub

    Private Sub disenioModeloSICY()
        grdModeloSICY.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdModeloSICY.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdModeloSICY.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grdModeloSICY.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdModeloSICY.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdModeloSICY.DisplayLayout.Override.RowSelectorWidth = 35
        grdModeloSICY.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        For Each row In grdModelo.Rows
            row.Activation = Activation.NoEdit
        Next

        grdModeloSICY.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grdModeloSICY.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        Me.grdModeloSICY.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        Me.grdModeloSICY.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdModeloSICY.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdModeloSICY.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdModeloSICY.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

        grdModeloSICY.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
    End Sub

    Private Sub disenioHormas()

        With grdAlmacen.DisplayLayout.Bands(0)

            .Columns("Id Horma").Hidden = True

            .Columns("seleccion").Header.Caption = ""
            .Columns("seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Horma").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("seleccion").Style = ColumnStyle.CheckBox

            .Columns("seleccion").AllowRowFiltering = DefaultableBoolean.False

            Dim colSeleccion As UltraGridColumn = grdAlmacen.DisplayLayout.Bands(0).Columns("seleccion")
            colSeleccion.DefaultCellValue = False
            colSeleccion.Header.Caption = ""
            colSeleccion.Header.VisiblePosition = 0
            colSeleccion.Style = ColumnStyle.CheckBox
            colSeleccion.Width = 50

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)


        End With

        grdAlmacen.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdAlmacen.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdAlmacen.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grdAlmacen.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdAlmacen.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdAlmacen.DisplayLayout.Override.RowSelectorWidth = 35
        grdAlmacen.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        'For Each row In grdAlmacen.Rows
        '    row.Activation = Activation.NoEdit
        'Next

        'grdAlmacen.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grdAlmacen.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        Me.grdAlmacen.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        Me.grdAlmacen.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdAlmacen.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdAlmacen.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdAlmacen.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

        'grdAlmacen.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
        grdAlmacen.DisplayLayout.Bands(0).Columns("seleccion").Width = 18
    End Sub

    Private Sub disenioTemporadas()

        With grdVendedores.DisplayLayout.Bands(0)

            .Columns("Id Temporada").Hidden = True
            '     Id Almacen
            .Columns("seleccion").Header.Caption = ""
            .Columns("seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("seleccion").Style = ColumnStyle.CheckBox

            .Columns("seleccion").AllowRowFiltering = DefaultableBoolean.False

            Dim colSeleccion As UltraGridColumn = grdVendedores.DisplayLayout.Bands(0).Columns("seleccion")
            colSeleccion.DefaultCellValue = False
            colSeleccion.Header.Caption = ""
            colSeleccion.Header.VisiblePosition = 0
            colSeleccion.Style = ColumnStyle.CheckBox
            colSeleccion.Width = 50

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With

        grdVendedores.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        grdVendedores.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdVendedores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdVendedores.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grdVendedores.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdVendedores.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdVendedores.DisplayLayout.Override.RowSelectorWidth = 35
        grdVendedores.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        Me.grdVendedores.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        Me.grdVendedores.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdVendedores.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdVendedores.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdVendedores.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

        grdVendedores.DisplayLayout.Bands(0).Columns("seleccion").Width = 18
    End Sub

    Private Sub disenioCorridas()
        With grdCorridas.DisplayLayout.Bands(0)

            .Columns("IdTalla").Hidden = True

            .Columns("seleccion").Header.Caption = ""

            .Columns("seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("TallaI").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("TallaF").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("seleccion").Style = ColumnStyle.CheckBox

            .Columns("seleccion").AllowRowFiltering = DefaultableBoolean.False

            Dim colSeleccion As UltraGridColumn = grdCorridas.DisplayLayout.Bands(0).Columns("seleccion")
            colSeleccion.DefaultCellValue = False
            colSeleccion.Header.Caption = ""
            colSeleccion.Header.VisiblePosition = 0
            colSeleccion.Style = ColumnStyle.CheckBox
            colSeleccion.Width = 50

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)


        End With

        grdCorridas.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdCorridas.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True

        grdCorridas.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdCorridas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdCorridas.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grdCorridas.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdCorridas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdCorridas.DisplayLayout.Override.RowSelectorWidth = 30
        grdCorridas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        Me.grdCorridas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        Me.grdCorridas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdCorridas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCorridas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCorridas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        grdCorridas.DisplayLayout.Bands(0).Columns("seleccion").Width = 15
    End Sub

    Private Sub disenioColecciones()
        grdColecciones.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdColecciones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdColecciones.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grdColecciones.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdColecciones.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdColecciones.DisplayLayout.Override.RowSelectorWidth = 35
        grdColecciones.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        For Each row In grdColecciones.Rows
            row.Activation = Activation.NoEdit
        Next

        grdColecciones.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grdColecciones.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        Me.grdColecciones.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        Me.grdColecciones.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdColecciones.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdColecciones.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdColecciones.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

        grdColecciones.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
    End Sub

    Private Sub disenioClientes()
        grdCliente.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdCliente.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdCliente.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grdCliente.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdCliente.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdCliente.DisplayLayout.Override.RowSelectorWidth = 35
        grdCliente.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        For Each row In grdCliente.Rows
            row.Activation = Activation.NoEdit
        Next

        grdCliente.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grdCliente.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        Me.grdCliente.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        Me.grdCliente.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdCliente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCliente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCliente.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

        grdCliente.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
    End Sub
    Private Sub disenioColores()
        grdColores.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdColores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdColores.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grdColores.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdColores.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdColores.DisplayLayout.Override.RowSelectorWidth = 35
        grdColores.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        For Each row In grdColores.Rows
            row.Activation = Activation.NoEdit
        Next

        grdColores.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grdColores.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        Me.grdColores.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        Me.grdColores.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdColores.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdColores.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdColores.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

        grdColores.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
    End Sub

    Private Sub disenioMarca()
        grdMarca.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdMarca.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdMarca.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grdMarca.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdMarca.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdMarca.DisplayLayout.Override.RowSelectorWidth = 35
        grdMarca.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        For Each row In grdColores.Rows
            row.Activation = Activation.NoEdit
        Next

        grdMarca.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grdMarca.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        Me.grdMarca.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        Me.grdMarca.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdMarca.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdMarca.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdMarca.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

        grdMarca.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
    End Sub

    Private Sub disenioFamilia()
        grdFamilia.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdFamilia.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdFamilia.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grdFamilia.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdFamilia.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdFamilia.DisplayLayout.Override.RowSelectorWidth = 35
        grdFamilia.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        For Each row In grdColores.Rows
            row.Activation = Activation.NoEdit
        Next

        grdFamilia.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grdFamilia.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        Me.grdFamilia.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        Me.grdFamilia.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFamilia.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFamilia.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFamilia.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

        grdFamilia.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
    End Sub
    Private Sub disenioNavesDesarrollo()
        With grdNaveDesarrollo.DisplayLayout.Bands(0)
            .Columns("nave_naveid").Hidden = True
            .Columns("nave_navesicyid").Hidden = True

            .Columns("seleccion").Header.Caption = ""
            .Columns("Nave_nombre").Header.Caption = "Nave"
            .Columns("seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("nave_nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("seleccion").Style = ColumnStyle.CheckBox

            .Columns("seleccion").AllowRowFiltering = DefaultableBoolean.False

            Dim colseleccion As UltraGridColumn = grdNaveDesarrollo.DisplayLayout.Bands(0).Columns("seleccion")
            colseleccion.DefaultCellValue = False
            colseleccion.Header.Caption = ""
            colseleccion.Header.VisiblePosition = 0
            colseleccion.Style = ColumnStyle.CheckBox
            colseleccion.Width = 50

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        grdNaveDesarrollo.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdNaveDesarrollo.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdNaveDesarrollo.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grdNaveDesarrollo.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdNaveDesarrollo.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdNaveDesarrollo.DisplayLayout.Override.RowSelectorWidth = 35
        grdNaveDesarrollo.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grdNaveDesarrollo.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        Me.grdNaveDesarrollo.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        Me.grdNaveDesarrollo.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdNaveDesarrollo.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdNaveDesarrollo.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdNaveDesarrollo.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        grdNaveDesarrollo.DisplayLayout.Bands(0).Columns("seleccion").Width = 18
    End Sub

    Private Sub disenioSuelas()

        With grdSuelas.DisplayLayout.Bands(0)

            .Columns("IdProveedor").Hidden = True
            .Columns("seleccion").Header.Caption = ""
            .Columns("seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Nombre proveedor").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("seleccion").Style = ColumnStyle.CheckBox

            .Columns("seleccion").AllowRowFiltering = DefaultableBoolean.False

            Dim colSeleccion As UltraGridColumn = grdSuelas.DisplayLayout.Bands(0).Columns("seleccion")
            colSeleccion.DefaultCellValue = False
            colSeleccion.Header.Caption = ""
            colSeleccion.Header.VisiblePosition = 0
            colSeleccion.Style = ColumnStyle.CheckBox
            colSeleccion.Width = 50

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With

        grdSuelas.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdSuelas.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True

        grdSuelas.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdSuelas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdSuelas.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grdSuelas.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdSuelas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdSuelas.DisplayLayout.Override.RowSelectorWidth = 35
        grdSuelas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        Me.grdSuelas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        Me.grdSuelas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdSuelas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdSuelas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdSuelas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

        grdSuelas.DisplayLayout.Bands(0).Columns("seleccion").Width = 18
    End Sub
#End Region

#Region "txtAgregar a grid"
    Private Sub txtPedido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSICY.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSICY.Text) Then Return

            lstPedidos.Add(txtPedidoSICY.Text)
            grdPedidoSICY.DataSource = Nothing
            grdPedidoSICY.DataSource = lstPedidos

            txtPedidoSICY.Text = String.Empty

        End If

    End Sub

    Private Sub txtLote_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLote.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtLote.Text) Then Return

            lstLote.Add(txtLote.Text)
            grdLote.DataSource = Nothing
            grdLote.DataSource = lstLote

            txtLote.Text = String.Empty

        End If

    End Sub

    Private Sub txtModelo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtModelo.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then

            If String.IsNullOrEmpty(txtModelo.Text) Then Return

            lstModelo.Add(txtModelo.Text.ToUpper())
            grdModelo.DataSource = Nothing
            grdModelo.DataSource = lstModelo

            txtModelo.Text = String.Empty

        End If

    End Sub

    Private Sub txtModeloSICY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtModeloSICY.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then

            If String.IsNullOrEmpty(txtModeloSICY.Text) Then Return

            lstModeloSICY.Add(txtModeloSICY.Text.ToUpper())
            grdModeloSICY.DataSource = Nothing
            grdModeloSICY.DataSource = lstModeloSICY

            txtModeloSICY.Text = String.Empty

        End If

    End Sub

    Private Sub txtPedidoSay_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSay.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSay.Text) Then Return

            lstPedidosSay.Add(txtPedidoSay.Text)
            grdPedidoSay.DataSource = Nothing
            grdPedidoSay.DataSource = lstPedidosSay

            txtPedidoSay.Text = String.Empty

        End If
    End Sub
#End Region

#Region "eliminar filas de grid"
    Private Sub grdPedidoSICY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSICY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSICY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdLote_KeyDown(sender As Object, e As KeyEventArgs) Handles grdLote.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdLote.DeleteSelectedRows(False)
    End Sub

    Private Sub grdModelo_KeyDown(sender As Object, e As KeyEventArgs) Handles grdModelo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdModelo.DeleteSelectedRows(False)
    End Sub

    Private Sub grdModeloSICY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdModeloSICY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdModeloSICY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdColecciones_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColecciones.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColecciones.DeleteSelectedRows(False)
    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub grdColores_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColores.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColores.DeleteSelectedRows(False)
    End Sub

    Private Sub grdMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMarca.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdMarca.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFamilia_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFamilia.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFamilia.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPedidoSay_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSay.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSay.DeleteSelectedRows(False)
    End Sub

#End Region

#Region "botones añadir filas a grids"

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametroUbicacionForm

        listado.tipo_busqueda = 2
        Dim listaParametroID As New List(Of String)
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
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True

            .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Clientes"
        End With
    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click
        Dim listado As New ListadoParametroUbicacionForm

        listado.tipo_busqueda = 14
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdMarca.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdMarca.DataSource = listado.listParametros
        With grdMarca
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Marcas"

        End With

    End Sub

    Private Sub btnColecciones_Click(sender As Object, e As EventArgs) Handles btnColecciones.Click
        Dim listado As New ListadoParametroUbicacionForm
        'hola
        listado.tipo_busqueda = 12
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdColecciones.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColecciones.DataSource = listado.listParametros
        With grdColecciones
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colecciones"
        End With
    End Sub
    Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
        Dim listado As New ListadoParametroUbicacionForm

        listado.tipo_busqueda = 13
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdColores.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColores.DataSource = listado.listParametros
        With grdColores
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colores"

        End With
    End Sub
    'Private Sub btnColor_Click(sender As Object, e As EventArgs)
    '    Dim listado As New ListadoParametroUbicacionForm

    '    listado.tipo_busqueda = 13
    '    Dim listaParametroID As New List(Of String)
    '    For Each row As UltraGridRow In grdColores.Rows
    '        Dim parametro As String = row.Cells(0).Text
    '        listaParametroID.Add(parametro)
    '    Next
    '    listado.listaParametroID = listaParametroID
    '    listado.ShowDialog(Me)
    '    If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
    '    If listado.listParametros.Rows.Count = 0 Then Return
    '    grdColores.DataSource = listado.listParametros
    '    With grdColores
    '        .DisplayLayout.Bands(0).Columns(0).Hidden = True
    '        .DisplayLayout.Bands(0).Columns(1).Hidden = True
    '        .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colores"

    '    End With
    'End Sub

    'Private Sub btnColor_Click(sender As Object, e As EventArgs)
    '    Dim listado As New ListadoParametroUbicacionForm

    '    listado.tipo_busqueda = 13
    '    Dim listaParametroID As New List(Of String)
    '    For Each row As UltraGridRow In grdColores.Rows
    '        Dim parametro As String = row.Cells(0).Text
    '        listaParametroID.Add(parametro)
    '    Next
    '    listado.listaParametroID = listaParametroID
    '    listado.ShowDialog(Me)
    '    If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
    '    If listado.listParametros.Rows.Count = 0 Then Return
    '    grdColores.DataSource = listado.listParametros
    '    With grdColores
    '        .DisplayLayout.Bands(0).Columns(0).Hidden = True
    '        .DisplayLayout.Bands(0).Columns(1).Hidden = True
    '        .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colores"

    '    End With
    'End Sub


#End Region

#Region "botones principales"

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim reporte As New DataTable
        Dim obj As New OrdenesEnProcesoBU
        Dim rowsGrdPedidosSICY As String = String.Empty
        Dim rowsGrdLote As String = String.Empty
        Dim rowsGrdModelo As String = String.Empty
        Dim rowsGrdAlmacen As String = String.Empty
        Dim rowsGrdVendedores As String = String.Empty
        Dim rowsGrdCorridas As String = String.Empty
        Dim rowsGrdColecciones As String = String.Empty
        Dim rowsGrdClientes As String = String.Empty
        Dim rowsGrdColores As String = String.Empty
        Dim rowsGrdMarcas As String = String.Empty
        Dim rowsGrdFamilias As String = String.Empty
        Dim rowsGrdNaveDesarrollo As String = String.Empty
        Dim gruposNave As String = String.Empty
        Dim conVigencia As Integer = 0
        Dim pantalla As New ReporteOrdenesEnProcesoForm
        Dim pantallaporMes As New ReporteOrdenesEnProcesoPorMesForm
        Dim rangofechas As New DataTable
        Dim rangomeses As String = String.Empty
        Dim rowsGrdPedidosSay As String = String.Empty
        Dim rowsGrdSuelas As String = String.Empty
        Dim rowsGrdModeloSICY As String = String.Empty

        'Dim FechaInicio As String = String.Empty
        'Dim FechaFin As String = String.Empty
        'Dim FechaEInicio As String = String.Empty
        'Dim FechaEFin As String = String.Empty


        'If cboxNaves.SelectedIndex > 0 Then
        Me.Cursor = Cursors.WaitCursor


        'grid pedido SICY'
        For Each row As UltraGridRow In grdPedidoSICY.Rows
            If row.Index = 0 Then
                rowsGrdPedidosSICY += "'" + row.Cells(0).Text.Trim + "'"
            Else
                rowsGrdPedidosSICY += ", '" + row.Cells(0).Text.Trim + "'"
            End If
        Next

        'grid lote'
        For Each row As UltraGridRow In grdLote.Rows
            If row.Index = 0 Then
                rowsGrdLote += "'" + row.Cells(0).Text.Trim + "'"
            Else
                rowsGrdLote += ", '" + row.Cells(0).Text.Trim + "'"
            End If
        Next

        'grid modelo SICY'
        For Each row As UltraGridRow In grdModelo.Rows
            If row.Index = 0 Then
                rowsGrdModelo += "'" + row.Cells(0).Text.Trim + "'"
            Else
                rowsGrdModelo += ", '" + row.Cells(0).Text.Trim + "'"
            End If
        Next

        'grid almacen'
        For Each row As UltraGridRow In grdAlmacen.Rows
            If row.Cells(0).Value = True Then
                rowsGrdAlmacen += "'" + row.Cells(1).Text.Trim + "',"
            End If
        Next
        If rowsGrdAlmacen <> String.Empty Then
            rowsGrdAlmacen = rowsGrdAlmacen.TrimEnd(",")
        End If

        'grid vendedores'
        For Each row As UltraGridRow In grdVendedores.Rows
            If row.Cells(0).Value = True Then
                rowsGrdVendedores += "'" + row.Cells(1).Text.Trim + "',"
            End If
        Next
        If rowsGrdVendedores <> String.Empty Then
            rowsGrdVendedores = rowsGrdVendedores.TrimEnd(",")
        End If

        'grid corridas'
        For Each row As UltraGridRow In grdCorridas.Rows
            If row.Cells(0).Value = True Then
                rowsGrdCorridas += "'" + row.Cells(1).Text.Trim + "',"
            End If
        Next
        If rowsGrdCorridas <> String.Empty Then
            rowsGrdCorridas = rowsGrdCorridas.TrimEnd(",")
        End If

        'grid colecciones'
        For Each row As UltraGridRow In grdColecciones.Rows
            If row.Index = 0 Then
                rowsGrdColecciones += "'" + row.Cells(0).Text.Trim + "'"
            Else
                rowsGrdColecciones += ", '" + row.Cells(0).Text.Trim + "'"
            End If
        Next

        'grid cliente'
        For Each row As UltraGridRow In grdCliente.Rows
            If row.Index = 0 Then
                rowsGrdClientes += row.Cells(0).Text.Trim
            Else
                rowsGrdClientes += ", " + row.Cells(0).Text.Trim
            End If
        Next

        'grid colores'
        For Each row As UltraGridRow In grdColores.Rows
            If row.Index = 0 Then
                rowsGrdColores += "'" + row.Cells(0).Text.Trim + "'"
            Else
                rowsGrdColores += ", " + "'" + row.Cells(0).Text.Trim + "'"
            End If
        Next

        For Each row As UltraGridRow In grdMarca.Rows
            If row.Index = 0 Then
                rowsGrdMarcas += "'" + row.Cells(0).Text.Trim + "'"
            Else
                rowsGrdMarcas += ", " + "'" + row.Cells(0).Text.Trim + "'"
            End If
        Next

        For Each row As UltraGridRow In grdFamilia.Rows
            If row.Index = 0 Then
                rowsGrdFamilias += "'" + row.Cells(0).Text.Trim + "'"
            Else
                rowsGrdFamilias += ", " + "'" + row.Cells(0).Text.Trim + "'"
            End If
        Next

        'grid nave desarrollo'
        For Each row As UltraGridRow In grdNaveDesarrollo.Rows
            If row.Cells(0).Value = True Then
                rowsGrdNaveDesarrollo += "'" + row.Cells(1).Text.Trim + "',"
            End If
        Next
        If rowsGrdNaveDesarrollo <> String.Empty Then
            rowsGrdNaveDesarrollo = rowsGrdNaveDesarrollo.TrimEnd(",")
        End If

        'grid pedidos Say'
        For Each row As UltraGridRow In grdPedidoSay.Rows
            If row.Index = 0 Then
                rowsGrdPedidosSay += "'" + row.Cells(0).Text.Trim + "'"
            Else
                rowsGrdPedidosSay += ", '" + row.Cells(0).Text.Trim + "'"
            End If
        Next

        'grid Suelas'
        For Each row As UltraGridRow In grdSuelas.Rows
            If row.Cells(0).Value = True Then
                rowsGrdSuelas += "'" + row.Cells(1).Text.Trim + "',"
            End If
        Next
        If rowsGrdSuelas <> String.Empty Then
            rowsGrdSuelas = rowsGrdSuelas.TrimEnd(",")
        End If

        'grid modelo'
        For Each row As UltraGridRow In grdModeloSICY.Rows
            If row.Index = 0 Then
                rowsGrdModeloSICY += "'" + row.Cells(0).Text.Trim + "'"
            Else
                rowsGrdModeloSICY += ", '" + row.Cells(0).Text.Trim + "'"
            End If
        Next

        gruposNave = If(cmbGrupoNaves.Text = "Todos", "", cmbGrupoNaves.Text)

        If (rdoConVigencia.Checked = True) Then
            conVigencia = 1
        Else
            conVigencia = 0
        End If

        If cmbReporte.Text = "Por Mes" Then
            rangofechas = obj.meses(dtpFechaDel.Value.ToShortDateString, dtpFechaAl.Value.ToShortDateString)
            rangomeses = rangofechas.Rows(0).Item(0) + ",Total"

            reporte = obj.imprimirReporteporMes(cboxNaves.SelectedValue, dtpFechaDel.Value.ToShortDateString, dtpFechaAl.Value.ToShortDateString, rowsGrdPedidosSICY, rowsGrdLote, rowsGrdModelo, rowsGrdAlmacen, rowsGrdVendedores, rowsGrdCorridas, rowsGrdColecciones, rowsGrdClientes, rowsGrdColores, gruposNave, rowsGrdMarcas, rowsGrdFamilias, chActivaFecha.Checked, rowsGrdNaveDesarrollo, rangomeses, rowsGrdPedidosSay)
            If reporte.Rows.Count > 0 Then
                pantallaporMes.dtReporte = reporte
                Me.Cursor = Cursors.Default
                pantallaporMes.ShowDialog()
            Else
                Me.Cursor = Cursors.Default
                Dim objMensajeGuardar As New Tools.AdvertenciaForm
                objMensajeGuardar.mensaje = "No hay datos por mostrar."
                objMensajeGuardar.ShowDialog()
            End If
        ElseIf rdoOrdenesPendientes.Checked = True Then
            reporte = obj.imprimirReporte(cboxNaves.SelectedValue, dtpFechaDel.Value.ToShortDateString, dtpFechaAl.Value.ToShortDateString, True, rowsGrdPedidosSICY, rowsGrdLote, rowsGrdModelo, rowsGrdModeloSICY, rowsGrdAlmacen, rowsGrdVendedores, rowsGrdCorridas, rowsGrdColecciones, rowsGrdClientes, rowsGrdColores, If(rbtFechaEntrega.Checked, 1, If(rbtFechaPrograma.Checked, 0, 2)), gruposNave, rowsGrdMarcas, rowsGrdFamilias, chActivaFecha.Checked, rowsGrdNaveDesarrollo, rowsGrdPedidosSay, usuarioId, conVigencia, rowsGrdSuelas) 'rowsGrdSuelas
            If reporte.Rows.Count > 0 Then
                pantalla.dtReporte = reporte
                Me.Cursor = Cursors.Default
                pantalla.ShowDialog()
            Else
                Me.Cursor = Cursors.Default
                Dim objMensajeGuardar As New Tools.AdvertenciaForm
                objMensajeGuardar.mensaje = "No hay datos por mostrar."
                objMensajeGuardar.ShowDialog()
            End If
        ElseIf rdoConVigencia.Checked = True Then
            reporte = obj.imprimirReporte(cboxNaves.SelectedValue, dtpFechaDel.Value.ToShortDateString, dtpFechaAl.Value.ToShortDateString, False, rowsGrdPedidosSICY, rowsGrdLote, rowsGrdModelo, rowsGrdModeloSICY, rowsGrdAlmacen, rowsGrdVendedores, rowsGrdCorridas, rowsGrdColecciones, rowsGrdClientes, rowsGrdColores, If(rbtFechaEntrega.Checked, 1, If(rbtFechaPrograma.Checked, 0, 2)), gruposNave, rowsGrdMarcas, rowsGrdFamilias, chActivaFecha.Checked, rowsGrdNaveDesarrollo, rowsGrdPedidosSay, usuarioId, conVigencia, rowsGrdSuelas) 'rowsGrdSuelas
            If reporte.Rows.Count > 0 Then
                pantalla.dtReporte = reporte
                Me.Cursor = Cursors.Default
                pantalla.ShowDialog()
            Else
                Me.Cursor = Cursors.Default
                Dim objMensajeGuardar As New Tools.AdvertenciaForm
                objMensajeGuardar.mensaje = "No hay datos por mostrar."
                objMensajeGuardar.ShowDialog()
            End If
        Else
            reporte = obj.imprimirReporte(cboxNaves.SelectedValue, dtpFechaDel.Value.ToShortDateString, dtpFechaAl.Value.ToShortDateString, False, rowsGrdPedidosSICY, rowsGrdLote, rowsGrdModelo, rowsGrdModeloSICY, rowsGrdAlmacen, rowsGrdVendedores, rowsGrdCorridas, rowsGrdColecciones, rowsGrdClientes, rowsGrdColores, If(rbtFechaEntrega.Checked, 1, If(rbtFechaPrograma.Checked, 0, 2)), gruposNave, rowsGrdMarcas, rowsGrdFamilias, chActivaFecha.Checked, rowsGrdNaveDesarrollo, rowsGrdPedidosSay, usuarioId, conVigencia, rowsGrdSuelas) 'rowsGrdSuelas
            If reporte.Rows.Count > 0 Then
                    pantalla.dtReporte = reporte
                    Me.Cursor = Cursors.Default
                    pantalla.ShowDialog()
                Else
                    Me.Cursor = Cursors.Default
                    Dim objMensajeGuardar As New Tools.AdvertenciaForm
                    objMensajeGuardar.mensaje = "No hay datos por mostrar."
                objMensajeGuardar.ShowDialog()
            End If
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()

    End Sub
#End Region

    Private Sub dtpFechaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDel.ValueChanged
        dtpFechaAl.MinDate = dtpFechaDel.Value
    End Sub


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cboxNaves.SelectedValue = 0
        dtpFechaDel.Value = Now.ToShortDateString
        dtpFechaAl.Value = Today.ToShortDateString
        rdoTodos.Checked = True
        rdoConVigencia.Checked = False
        txtPedidoSICY.Text = String.Empty
        txtLote.Text = String.Empty

        grdPedidoSICY.DataSource = Nothing
        grdLote.DataSource = Nothing

        txtModelo.Text = String.Empty
        txtModeloSICY.Text = String.Empty
        grdModelo.DataSource = Nothing
        grdModeloSICY.DataSource = Nothing

        cargaDatosInicio()
        grdColecciones.DataSource = Nothing
        grdCliente.DataSource = Nothing
        grdColores.DataSource = Nothing
        grdMarca.DataSource = Nothing
        grdFamilia.DataSource = Nothing
        rbtFechaPrograma.Checked = True
        txtPedidoSay.Text = String.Empty
        grdPedidoSay.DataSource = Nothing

        lstModelo.Clear()
        lstModeloSICY.Clear()
        lstPedidos.Clear()
        lstLote.Clear()
        lstPedidosSay.Clear()
    End Sub





    Private Sub chActivaFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chActivaFecha.CheckedChanged

        Dim vch As New CheckBox
        vch = sender

        If vch.Checked = True Then
            chActivaFecha.Text = "Activar Fechas"
            dtpFechaAl.Enabled = False
            dtpFechaDel.Enabled = False
            rbtFechaEntradaAlmacen.Checked = False
        Else
            chActivaFecha.Text = "Desactivar Fechas"
            dtpFechaAl.Enabled = True
            dtpFechaDel.Enabled = True
        End If


    End Sub

    Private Sub rbtFechaEntradaAlmacen_CheckedChanged(sender As Object, e As EventArgs) Handles rbtFechaEntradaAlmacen.CheckedChanged
        If rbtFechaEntradaAlmacen.Checked Then
            GroupBox4.Visible = True
            dtpFechaDel.Focus()
        Else
            cmbReporte.SelectedIndex = 0
            GroupBox4.Visible = False
        End If
    End Sub

    Private Sub btnFamilia_Click(sender As Object, e As EventArgs) Handles btnFamilia.Click
        Dim listado As New ListadoParametroUbicacionForm

        listado.tipo_busqueda = 15
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFamilia.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFamilia.DataSource = listado.listParametros
        With grdFamilia
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Familias"
        End With
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim tablaDatosOP As DataTable
        Dim objBU As New OrdenesEnProcesoBU
        Dim rowsGrdPedidosSICY As String = String.Empty
        Dim rowsGrdLote As String = String.Empty
        Dim rowsGrdModelo As String = String.Empty
        Dim rowsGrdAlmacen As String = String.Empty
        Dim rowsGrdVendedores As String = String.Empty
        Dim rowsGrdCorridas As String = String.Empty
        Dim rowsGrdColecciones As String = String.Empty
        Dim rowsGrdClientes As String = String.Empty
        Dim rowsGrdColores As String = String.Empty
        Dim rowsGrdMarcas As String = String.Empty
        Dim rowsGrdFamilias As String = String.Empty
        Dim rowsGrdNaveDesarrollo As String = String.Empty
        Dim gruposNave As String = String.Empty
        Dim pantalla As New ReporteOrdenesEnProcesoForm
        Dim pantallaporMes As New ReporteOrdenesEnProcesoPorMesForm
        Dim rangofechas As New DataTable
        Dim rangomeses As String = String.Empty
        Dim rowsGrdPedidosSay As String = String.Empty
        Dim OrdenesProceso As Boolean = False

        If rdoOrdenesPendientes.Checked = True Then
            OrdenesProceso = True
        Else
            OrdenesProceso = False
        End If

        For Each row As UltraGridRow In grdPedidoSICY.Rows
            If row.Index = 0 Then
                rowsGrdPedidosSICY += "'" + row.Cells(0).Text.Trim + "'"
            Else
                rowsGrdPedidosSICY += ", '" + row.Cells(0).Text.Trim + "'"
            End If
        Next

        'grid lote'
        For Each row As UltraGridRow In grdLote.Rows
            If row.Index = 0 Then
                rowsGrdLote += "'" + row.Cells(0).Text.Trim + "'"
            Else
                rowsGrdLote += ", '" + row.Cells(0).Text.Trim + "'"
            End If
        Next

        'grid modelo'
        For Each row As UltraGridRow In grdModelo.Rows
            If row.Index = 0 Then
                rowsGrdModelo += "'" + row.Cells(0).Text.Trim + "'"
            Else
                rowsGrdModelo += ", '" + row.Cells(0).Text.Trim + "'"
            End If
        Next

        'grid almacen'
        For Each row As UltraGridRow In grdAlmacen.Rows
            If row.Cells(0).Value = True Then
                rowsGrdAlmacen += "'" + row.Cells(1).Text.Trim + "',"
            End If
        Next
        If rowsGrdAlmacen <> String.Empty Then
            rowsGrdAlmacen = rowsGrdAlmacen.TrimEnd(",")
        End If

        'grid vendedores'
        For Each row As UltraGridRow In grdVendedores.Rows
            If row.Cells(0).Value = True Then
                rowsGrdVendedores += "'" + row.Cells(1).Text.Trim + "',"
            End If
        Next
        If rowsGrdVendedores <> String.Empty Then
            rowsGrdVendedores = rowsGrdVendedores.TrimEnd(",")
        End If

        'grid corridas'
        For Each row As UltraGridRow In grdCorridas.Rows
            If row.Cells(0).Value = True Then
                rowsGrdCorridas += "'" + row.Cells(1).Text.Trim + "',"
            End If
        Next
        If rowsGrdCorridas <> String.Empty Then
            rowsGrdCorridas = rowsGrdCorridas.TrimEnd(",")
        End If

        'grid colecciones'
        For Each row As UltraGridRow In grdColecciones.Rows
            If row.Index = 0 Then
                rowsGrdColecciones += "'" + row.Cells(0).Text.Trim + "'"
            Else
                rowsGrdColecciones += ", '" + row.Cells(0).Text.Trim + "'"
            End If
        Next

        'grid cliente'
        For Each row As UltraGridRow In grdCliente.Rows
            If row.Index = 0 Then
                rowsGrdClientes += row.Cells(0).Text.Trim
            Else
                rowsGrdClientes += ", " + row.Cells(0).Text.Trim
            End If
        Next

        'grid colores'
        For Each row As UltraGridRow In grdColores.Rows
            If row.Index = 0 Then
                rowsGrdColores += "'" + row.Cells(0).Text.Trim + "'"
            Else
                rowsGrdColores += ", " + "'" + row.Cells(0).Text.Trim + "'"
            End If
        Next

        For Each row As UltraGridRow In grdMarca.Rows
            If row.Index = 0 Then
                rowsGrdMarcas += "'" + row.Cells(0).Text.Trim + "'"
            Else
                rowsGrdMarcas += ", " + "'" + row.Cells(0).Text.Trim + "'"
            End If
        Next

        For Each row As UltraGridRow In grdFamilia.Rows
            If row.Index = 0 Then
                rowsGrdFamilias += "'" + row.Cells(0).Text.Trim + "'"
            Else
                rowsGrdFamilias += ", " + "'" + row.Cells(0).Text.Trim + "'"
            End If
        Next

        'grid nave desarrollo'
        For Each row As UltraGridRow In grdNaveDesarrollo.Rows
            If row.Cells(0).Value = True Then
                rowsGrdNaveDesarrollo += "'" + row.Cells(1).Text.Trim + "',"
            End If
        Next
        If rowsGrdNaveDesarrollo <> String.Empty Then
            rowsGrdNaveDesarrollo = rowsGrdNaveDesarrollo.TrimEnd(",")
        End If

        'grid pedidos Say'
        For Each row As UltraGridRow In grdPedidoSay.Rows
            If row.Index = 0 Then
                rowsGrdPedidosSay += "'" + row.Cells(0).Text.Trim + "'"
            Else
                rowsGrdPedidosSay += ", '" + row.Cells(0).Text.Trim + "'"
            End If
        Next

        Me.Cursor = Cursors.WaitCursor

        tablaDatosOP = objBU.imprimirReporteNavesProduccion(cboxNaves.SelectedValue, dtpFechaDel.Value.ToShortDateString, dtpFechaAl.Value.ToShortDateString, OrdenesProceso, rowsGrdPedidosSICY, rowsGrdLote, rowsGrdModelo, rowsGrdAlmacen, rowsGrdVendedores, rowsGrdCorridas, rowsGrdColecciones, rowsGrdClientes, rowsGrdColores, If(rbtFechaEntrega.Checked, 1, If(rbtFechaPrograma.Checked, 0, 2)), gruposNave, rowsGrdMarcas, rowsGrdFamilias, chActivaFecha.Checked, rowsGrdNaveDesarrollo, rowsGrdPedidosSay, usuarioId)
        tablaDatosOP.TableName = "dtOrdenesEnProcesoNave"


        If tablaDatosOP.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
        Else
            Try
                Dim OBJReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_ORDENES_EN_PROCESO")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport

                reporte.Load(archivo)
                reporte.Compile()
                reporte("urlImagenNave") = GetRutaLogoPorNave(tablaDatosOP)
                reporte("FechaDel") = "DEL: " + dtpFechaDel.Value.ToLongDateString
                reporte("FechaAl") = " AL: " + dtpFechaAl.Value.ToLongDateString
                reporte("Titulo") = "ORDENES EN PROCESO"
                reporte.RegData(tablaDatosOP)
                reporte.Show()
            Catch ex As Exception
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function GetRutaLogoPorNave(ByVal img As DataTable)
        Dim imagenNave As String = String.Empty
        For i As Integer = 0 To img.Rows.Count - 1
            If img.Rows(i).Item("LogoNave").ToString() <> "" Then
                imagenNave = img.Rows(i).Item("LogoNave").ToString()
            End If
        Next
        Return imagenNave
    End Function
End Class