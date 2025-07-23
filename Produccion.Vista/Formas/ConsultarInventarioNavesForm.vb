Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Framework.Negocios
Imports Tools
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.ReportGeneration


Public Class ConsultarInventarioNavesForm


    Private Sub ConsultarInventarioNavesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim obj As New InventarioBU

        Try
            Me.Cursor = Cursors.WaitCursor
            btnMostar_Click(Nothing, Nothing)
            'grdInventarioNaves.DataSource = Nothing
            ' DiseñoGrid(grdInventarioNaves)
            '            grdInventarioNaves.DataSource = obj.ConsultaInventarioNaves()
            lblFechaUltimaActualizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub btnMostar_Click(sender As Object, e As EventArgs) Handles btnMostar.Click
        Dim obj As New InventarioBU

        Try
            Me.Cursor = Cursors.WaitCursor
            grdInventarioNaves.DataSource = Nothing
            'DiseñoGrid(grdInventarioNaves)
            'grdInventarioNaves.DataSource = obj.ConsultaInventarioNaves()

            grdInventarioNave.DataSource = obj.ConsultaInventarioNaves()
            DiseñoGridInventario()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
            Me.Cursor = Cursors.Default
        End Try        

    End Sub

    Private Sub DiseñoGridInventario()
        vwInventarioNave.OptionsView.ColumnAutoWidth = False
        'grdVentas.OptionsView.BestFitMaxRowCount = -1

        vwInventarioNave.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True
        'If IsNothing(grdVentas.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
        '    grdVentas.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        '    AddHandler grdVentas.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
        '    grdVentas.Columns.Item("#").VisibleIndex = 0
        'End If


        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwInventarioNave.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        'vwInventarioNave.Columns.ColumnByFieldName("Programas Abiertos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwInventarioNave.Columns.ColumnByFieldName("Pares Programados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwInventarioNave.Columns.ColumnByFieldName("Pares terminados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwInventarioNave.Columns.ColumnByFieldName("Pares Pendientes").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwInventarioNave.Columns.ColumnByFieldName("Inventario").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwInventarioNave.Columns.ColumnByFieldName("Programas + Atrasado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwInventarioNave.Columns.ColumnByFieldName("Pares Atrasados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwInventarioNave.Columns.ColumnByFieldName("Prom de Entrega x día").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwInventarioNave.Columns.ColumnByFieldName("Pares +6 Días").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwInventarioNave.Columns.ColumnByFieldName("Pares +8 Días").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwInventarioNave.Columns.ColumnByFieldName("Programado Semana actual").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwInventarioNave.Columns.ColumnByFieldName("Producción").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwInventarioNave.Columns.ColumnByFieldName("Programado Sig Semana").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwInventarioNave.Columns.ColumnByFieldName("Total x Fabricar").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwInventarioNave.Columns.ColumnByFieldName("CapacidadNave").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric


        vwInventarioNave.Columns.ColumnByFieldName("Programas Abiertos").DisplayFormat.FormatString = "###,##0.00"
        vwInventarioNave.Columns.ColumnByFieldName("Pares Programados").DisplayFormat.FormatString = "N0"
        vwInventarioNave.Columns.ColumnByFieldName("Pares terminados").DisplayFormat.FormatString = "N0"
        vwInventarioNave.Columns.ColumnByFieldName("Pares Pendientes").DisplayFormat.FormatString = "N0"
        vwInventarioNave.Columns.ColumnByFieldName("Inventario").DisplayFormat.FormatString = "N2"
        'vwInventarioNave.Columns.ColumnByFieldName("Programas + Atrasado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwInventarioNave.Columns.ColumnByFieldName("Pares Atrasados").DisplayFormat.FormatString = "N0"
        vwInventarioNave.Columns.ColumnByFieldName("Prom de Entrega x día").DisplayFormat.FormatString = "N0"
        vwInventarioNave.Columns.ColumnByFieldName("Pares +6 Días").DisplayFormat.FormatString = "N0"
        vwInventarioNave.Columns.ColumnByFieldName("Pares +8 Días").DisplayFormat.FormatString = "N0"
        vwInventarioNave.Columns.ColumnByFieldName("Programado Semana actual").DisplayFormat.FormatString = "N0"
        vwInventarioNave.Columns.ColumnByFieldName("Producción").DisplayFormat.FormatString = "N0"
        vwInventarioNave.Columns.ColumnByFieldName("Programado Sig Semana").DisplayFormat.FormatString = "N0"
        vwInventarioNave.Columns.ColumnByFieldName("Total x Fabricar").DisplayFormat.FormatString = "N0"
        vwInventarioNave.Columns.ColumnByFieldName("CapacidadNave").DisplayFormat.FormatString = "N0"


        'vwInventarioNave.Columns.ColumnByFieldName("Observaciones").Width = 200
        vwInventarioNave.Columns.ColumnByFieldName("Pares Programados").Width = 85
        vwInventarioNave.Columns.ColumnByFieldName("Inventario").Width = 70
        vwInventarioNave.Columns.ColumnByFieldName("Programado Sig Semana").Width = 85
        vwInventarioNave.Columns.ColumnByFieldName("Programas Abiertos").Width = 75

        vwInventarioNave.Columns.ColumnByFieldName("Nave").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwInventarioNave.Columns.ColumnByFieldName("Programas Abiertos").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwInventarioNave.Columns.ColumnByFieldName("Pares Programados").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwInventarioNave.Columns.ColumnByFieldName("Pares terminados").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwInventarioNave.Columns.ColumnByFieldName("Pares Pendientes").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwInventarioNave.Columns.ColumnByFieldName("Inventario").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'vwInventarioNave.Columns.ColumnByFieldName("Programas + Atrasado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwInventarioNave.Columns.ColumnByFieldName("Pares Atrasados").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwInventarioNave.Columns.ColumnByFieldName("Prom de Entrega x día").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwInventarioNave.Columns.ColumnByFieldName("Pares +6 Días").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwInventarioNave.Columns.ColumnByFieldName("Pares +8 Días").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwInventarioNave.Columns.ColumnByFieldName("Programado Semana actual").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwInventarioNave.Columns.ColumnByFieldName("Producción").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwInventarioNave.Columns.ColumnByFieldName("Programado Sig Semana").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwInventarioNave.Columns.ColumnByFieldName("Total x Fabricar").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwInventarioNave.Columns.ColumnByFieldName("CapacidadNave").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        '" & vbCrLf & "
        vwInventarioNave.Columns.ColumnByFieldName("Nave").Caption = "Nave"
        vwInventarioNave.Columns.ColumnByFieldName("Programas Abiertos").Caption = "Programas " & vbCrLf & "Abiertos"
        vwInventarioNave.Columns.ColumnByFieldName("Pares Programados").Caption = "Pares" & vbCrLf & "Programados"
        vwInventarioNave.Columns.ColumnByFieldName("Pares terminados").Caption = "Pares" & vbCrLf & " terminados"
        vwInventarioNave.Columns.ColumnByFieldName("Pares Pendientes").Caption = "Pares " & vbCrLf & "Pendientes"
        vwInventarioNave.Columns.ColumnByFieldName("Inventario").Caption = "Inventario"
        vwInventarioNave.Columns.ColumnByFieldName("Programas + Atrasado").Caption = "Programas " & vbCrLf & "+ Atrasado"
        vwInventarioNave.Columns.ColumnByFieldName("Pares Atrasados").Caption = "Pares " & vbCrLf & "Atrasados"
        vwInventarioNave.Columns.ColumnByFieldName("Prom de Entrega x día").Caption = "Prom de " & vbCrLf & "Entrega x día"
        vwInventarioNave.Columns.ColumnByFieldName("Pares +6 Días").Caption = "Pares" & vbCrLf & " +6 Días"
        vwInventarioNave.Columns.ColumnByFieldName("Pares +8 Días").Caption = "Pares " & vbCrLf & "+8 DíasY"
        vwInventarioNave.Columns.ColumnByFieldName("Programado Semana actual").Caption = "Programado " & vbCrLf & "Semana actual"
        vwInventarioNave.Columns.ColumnByFieldName("Producción").Caption = "Producción"
        vwInventarioNave.Columns.ColumnByFieldName("Programado Sig Semana").Caption = "Programado " & vbCrLf & "Sig Semana"
        vwInventarioNave.Columns.ColumnByFieldName("Total x Fabricar").Caption = "Total" & vbCrLf & " x Fabricar"



        vwInventarioNave.Columns.ColumnByFieldName("Nave").OptionsColumn.AllowSize = True
        vwInventarioNave.Columns.ColumnByFieldName("Programas Abiertos").OptionsColumn.AllowSize = True
        vwInventarioNave.Columns.ColumnByFieldName("Pares Programados").OptionsColumn.AllowSize = True
        vwInventarioNave.Columns.ColumnByFieldName("Pares terminados").OptionsColumn.AllowSize = True
        vwInventarioNave.Columns.ColumnByFieldName("Pares Pendientes").OptionsColumn.AllowSize = True
        vwInventarioNave.Columns.ColumnByFieldName("Inventario").OptionsColumn.AllowSize = True
        vwInventarioNave.Columns.ColumnByFieldName("Programas + Atrasado").OptionsColumn.AllowSize = True
        vwInventarioNave.Columns.ColumnByFieldName("Pares Atrasados").OptionsColumn.AllowSize = True
        vwInventarioNave.Columns.ColumnByFieldName("Prom de Entrega x día").OptionsColumn.AllowSize = True
        vwInventarioNave.Columns.ColumnByFieldName("Pares +6 Días").OptionsColumn.AllowSize = True
        vwInventarioNave.Columns.ColumnByFieldName("Pares +8 Días").OptionsColumn.AllowSize = True
        vwInventarioNave.Columns.ColumnByFieldName("Programado Semana actual").OptionsColumn.AllowSize = True
        vwInventarioNave.Columns.ColumnByFieldName("Producción").OptionsColumn.AllowSize = True
        vwInventarioNave.Columns.ColumnByFieldName("Programado Sig Semana").OptionsColumn.AllowSize = True
        vwInventarioNave.Columns.ColumnByFieldName("Total x Fabricar").OptionsColumn.AllowSize = True
        vwInventarioNave.Columns.ColumnByFieldName("CapacidadNave").OptionsColumn.AllowSize = True


        vwInventarioNave.Columns.ColumnByFieldName("Nave").OptionsColumn.AllowEdit = False
        vwInventarioNave.Columns.ColumnByFieldName("Programas Abiertos").OptionsColumn.AllowEdit = False
        vwInventarioNave.Columns.ColumnByFieldName("Pares Programados").OptionsColumn.AllowEdit = False
        vwInventarioNave.Columns.ColumnByFieldName("Pares terminados").OptionsColumn.AllowEdit = False
        vwInventarioNave.Columns.ColumnByFieldName("Pares Pendientes").OptionsColumn.AllowEdit = False
        vwInventarioNave.Columns.ColumnByFieldName("Inventario").OptionsColumn.AllowEdit = False
        vwInventarioNave.Columns.ColumnByFieldName("Programas + Atrasado").OptionsColumn.AllowEdit = False
        vwInventarioNave.Columns.ColumnByFieldName("Pares Atrasados").OptionsColumn.AllowEdit = False
        vwInventarioNave.Columns.ColumnByFieldName("Prom de Entrega x día").OptionsColumn.AllowEdit = False
        vwInventarioNave.Columns.ColumnByFieldName("Pares +6 Días").OptionsColumn.AllowEdit = False
        vwInventarioNave.Columns.ColumnByFieldName("Pares +8 Días").OptionsColumn.AllowEdit = False
        vwInventarioNave.Columns.ColumnByFieldName("Programado Semana actual").OptionsColumn.AllowEdit = False
        vwInventarioNave.Columns.ColumnByFieldName("Producción").OptionsColumn.AllowEdit = False
        vwInventarioNave.Columns.ColumnByFieldName("Programado Sig Semana").OptionsColumn.AllowEdit = False
        vwInventarioNave.Columns.ColumnByFieldName("Total x Fabricar").OptionsColumn.AllowEdit = False
        vwInventarioNave.Columns.ColumnByFieldName("CapacidadNave").OptionsColumn.AllowEdit = False

        vwInventarioNave.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        If IsNothing(vwInventarioNave.Columns("Programas Abiertos").Summary.FirstOrDefault(Function(x) x.FieldName = "Programas Abiertos")) = True Then
            vwInventarioNave.Columns("Programas Abiertos").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Programas Abiertos", "{0:N2}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Programas Abiertos"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwInventarioNave.GroupSummary.Add(item)
        End If

        If IsNothing(vwInventarioNave.Columns("Pares Programados").Summary.FirstOrDefault(Function(x) x.FieldName = "Pares Programados")) = True Then
            vwInventarioNave.Columns("Pares Programados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares Programados", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pares Programados"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwInventarioNave.GroupSummary.Add(item)
        End If


        If IsNothing(vwInventarioNave.Columns("Pares terminados").Summary.FirstOrDefault(Function(x) x.FieldName = "Pares terminados")) = True Then
            vwInventarioNave.Columns("Pares terminados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares terminados", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pares terminados"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwInventarioNave.GroupSummary.Add(item)
        End If

        If IsNothing(vwInventarioNave.Columns("Pares Pendientes").Summary.FirstOrDefault(Function(x) x.FieldName = "Pares Pendientes")) = True Then
            vwInventarioNave.Columns("Pares Pendientes").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares Pendientes", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pares Pendientes"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwInventarioNave.GroupSummary.Add(item)
        End If

        If IsNothing(vwInventarioNave.Columns("Inventario").Summary.FirstOrDefault(Function(x) x.FieldName = "Inventario")) = True Then
            vwInventarioNave.Columns("Inventario").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Inventario", "{0:N2}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Inventario"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwInventarioNave.GroupSummary.Add(item)
        End If

        If IsNothing(vwInventarioNave.Columns("Pares Atrasados").Summary.FirstOrDefault(Function(x) x.FieldName = "Pares Atrasados")) = True Then
            vwInventarioNave.Columns("Pares Atrasados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares Atrasados", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pares Atrasados"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwInventarioNave.GroupSummary.Add(item)
        End If

        If IsNothing(vwInventarioNave.Columns("Prom de Entrega x día").Summary.FirstOrDefault(Function(x) x.FieldName = "Prom de Entrega x día")) = True Then
            vwInventarioNave.Columns("Prom de Entrega x día").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Prom de Entrega x día", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Prom de Entrega x día"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwInventarioNave.GroupSummary.Add(item)
        End If

        If IsNothing(vwInventarioNave.Columns("Pares +6 Días").Summary.FirstOrDefault(Function(x) x.FieldName = "Pares +6 Días")) = True Then
            vwInventarioNave.Columns("Pares +6 Días").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares +6 Días", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pares +6 Días"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwInventarioNave.GroupSummary.Add(item)
        End If

        If IsNothing(vwInventarioNave.Columns("Pares +8 Días").Summary.FirstOrDefault(Function(x) x.FieldName = "Pares +8 Días")) = True Then
            vwInventarioNave.Columns("Pares +8 Días").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares +8 Días", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pares +8 Días"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwInventarioNave.GroupSummary.Add(item)
        End If

        If IsNothing(vwInventarioNave.Columns("Programado Semana actual").Summary.FirstOrDefault(Function(x) x.FieldName = "Programado Semana actual")) = True Then
            vwInventarioNave.Columns("Programado Semana actual").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Programado Semana actual", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Programado Semana actual"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwInventarioNave.GroupSummary.Add(item)
        End If

        If IsNothing(vwInventarioNave.Columns("Producción").Summary.FirstOrDefault(Function(x) x.FieldName = "Producción")) = True Then
            vwInventarioNave.Columns("Producción").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Producción", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Producción"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwInventarioNave.GroupSummary.Add(item)
        End If

        If IsNothing(vwInventarioNave.Columns("Programado Sig Semana").Summary.FirstOrDefault(Function(x) x.FieldName = "Programado Sig Semana")) = True Then
            vwInventarioNave.Columns("Programado Sig Semana").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Programado Sig Semana", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Programado Sig Semana"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwInventarioNave.GroupSummary.Add(item)
        End If

        If IsNothing(vwInventarioNave.Columns("Total x Fabricar").Summary.FirstOrDefault(Function(x) x.FieldName = "Total x Fabricar")) = True Then
            vwInventarioNave.Columns("Total x Fabricar").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Total x Fabricar", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Total x Fabricar"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwInventarioNave.GroupSummary.Add(item)
        End If

        If IsNothing(vwInventarioNave.Columns("CapacidadNave").Summary.FirstOrDefault(Function(x) x.FieldName = "CapacidadNave")) = True Then
            vwInventarioNave.Columns("CapacidadNave").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "CapacidadNave", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "CapacidadNave"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwInventarioNave.GroupSummary.Add(item)
        End If


    End Sub


    Private Sub DiseñoGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        '        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard

        'grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns


        AgregarColumna(grid, "Nave", "Nave", False, True, Nothing, 120, False, False, HAlign.Left)
        AgregarColumna(grid, "Programas Abiertos", "Programas" & vbCrLf & " Abiertos", False, False, Nothing, 120, True, , HAlign.Right, , , , , True)
        AgregarColumna(grid, "Pares Programados", "Pares " & vbCrLf & "Programados", False, False, Nothing, 120, True, False, HAlign.Right)
        AgregarColumna(grid, "Pares terminados", "Pares " & vbCrLf & "Terminados", False, False, Nothing, 120, True, False, HAlign.Right)
        AgregarColumna(grid, "Pares Pendientes", "Pares " & vbCrLf & "Pendientes", False, False, Nothing, 120, True, False, HAlign.Right)
        AgregarColumna(grid, "Inventario", "Inventario", False, False, Nothing, 120, True, , HAlign.Right, , , , , True)
        AgregarColumna(grid, "Programas + Atrasado", "Programas " & vbCrLf & "+ Atrasado", False, True, Nothing, 120, False, False, HAlign.Left)
        AgregarColumna(grid, "Pares Atrasados", "Pares " & vbCrLf & "Atrasados", False, False, Nothing, 120, True, , HAlign.Right, , , , , True)
        AgregarColumna(grid, "Prom de Entrega x día", "Prom de Entrega " & vbCrLf & " x día", False, False, Nothing, 120, True, , HAlign.Right, , , , , True)
        AgregarColumna(grid, "Pares +6 Días", "Pares " & vbCrLf & "+ 6 Días", False, False, Nothing, 120, True, , HAlign.Right, , , , , True)
        AgregarColumna(grid, "Pares +8 Días", "Pares " & vbCrLf & " + 8 Día", False, False, Nothing, 120, True, , HAlign.Right, , , , , True)
        AgregarColumna(grid, "Programado Semana actual", "Programado " & vbCrLf & "Semana actual", False, False, Nothing, 120, True, , HAlign.Right, , , , , True)
        AgregarColumna(grid, "Producción", "Producción", False, False, Nothing, 120, True, , HAlign.Right, , , , , True)
        AgregarColumna(grid, "Programado Sig Semana", "Programado " & vbCrLf & "Sig Semana", False, False, Nothing, 120, True, , HAlign.Right, , , , , True)
        AgregarColumna(grid, "Total x Fabricar", "Total " & vbCrLf & "x Fabricar", False, False, Nothing, 120, True, , HAlign.Right, , , , , True)



        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

    End Sub


    Private Sub AgregarColumna(ByRef grid As UltraGrid, ByVal Key As String, ByVal NombreColumna As String, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, ByVal ColorColumna As Color, Optional ByVal Width As Integer = -1, Optional ByVal SumarizarColumna As Boolean = False, Optional ByVal Edicion As Boolean = False, Optional ByVal Alineacion As HAlign = Nothing, Optional ByVal NEgrita As Boolean = False, Optional ByVal EsPorcentaje As Boolean = False, Optional ByVal Tooltip As String = "", Optional ByVal Operacion As SummaryType = SummaryType.Sum, Optional ByVal MostrarDecimales As Boolean = False)
        With grid
            .DisplayLayout.Bands(0).Columns.Add(Key, NombreColumna)
            FormatoColumna(.DisplayLayout.Bands(0).Columns(Key), Ocultar, EsCadena, Width, EsPorcentaje, MostrarDecimales)
            If IsNothing(ColorColumna) Then
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = Color.Black
            Else
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = ColorColumna
            End If
            If SumarizarColumna = True Then
                SumarizarColumnaGrid(grid, Key, "Sumarizar " + Key, Operacion, MostrarDecimales)
            End If
            If Tooltip <> "" Then
                grid.DisplayLayout.Bands(0).Columns(Key).Header.ToolTipText = Tooltip
            End If

            'If Alineacion <> HAlign.Default Then
            '    .DisplayLayout.Bands(0).Columns(Key).CellAppearance.TextHAlign = Alineacion
            'End If

            If IsNothing(Alineacion) = False Then
                .DisplayLayout.Bands(0).Columns(Key).CellAppearance.TextHAlign = Alineacion
            End If
            If NEgrita = True Then
                .DisplayLayout.Bands(0).Columns(Key).CellAppearance.FontData.Bold = DefaultableBoolean.True
            End If


            If Edicion = True Then
                .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.AllowEdit
            Else
                .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.NoEdit
            End If

        End With
    End Sub

    Private Sub FormatoColumna(ByRef columna As UltraGridColumn, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, Optional ByVal Width As Integer = -1, Optional ByVal EsPorcentaje As Boolean = False, Optional ByVal MostrarDecimales As Boolean = False)
        Dim FormatoNumero As String = String.Empty
        Dim FormatoPorcentaje As String = "##0%"
        If MostrarDecimales = True Then
            FormatoNumero = "###,###,##0.00"
        Else
            FormatoNumero = "###,###,##0.##"
        End If

        columna.Hidden = Ocultar
        If EsCadena = True Then
            columna.CellAppearance.TextHAlign = HAlign.Left
        Else

            If EsPorcentaje = True Then
                columna.Format = FormatoPorcentaje
                columna.CellAppearance.TextHAlign = HAlign.Right
            Else
                columna.Format = FormatoNumero
                columna.CellAppearance.TextHAlign = HAlign.Right
            End If

        End If

        If Width <> -1 Then
            columna.Width = Width
        End If
    End Sub

    Private Sub SumarizarColumnaGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal NombreColumna As String, ByVal Key As String, ByVal Operacion As SummaryType, ByVal MostrarDecimales As Boolean)
        Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns(NombreColumna)
        Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add(Key, Operacion, columnToSummarize)
        If MostrarDecimales = True Then
            summary.DisplayFormat = "{0:###,###,##0.00}"
        Else
            summary.DisplayFormat = "{0:###,###,##0}"
        End If

        summary.Appearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
    End Sub


    Public Sub exportarExcel(ByVal grd As UltraGrid)
        Dim sfd As New SaveFileDialog

        If IsNothing(grd) = False Then
            If grd.Rows.Count = 0 Then
                show_message("Advertencia", "No hay información para exportar a excel.")
                Return
            End If
        End If

        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                UltraGridExcelExporter1.Export(grd, fileName)
                show_message("Exito", "El archivo se ha exportado correctamente en la ruta " + fileName)
                Process.Start(fileName)
                Me.Cursor = Cursors.Default


            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
    End Sub

    Public Function show_message(ByVal tipo As String, ByVal mensaje As String) As DialogResult
        Dim ResultadoDialogo As DialogResult

        If tipo.ToString.Equals("Advertencia") Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then
            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            ResultadoDialogo = mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            ResultadoDialogo = mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        Return ResultadoDialogo
    End Function


    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'exportarExcel(grdInventarioNaves)
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then

                    If GridView1.GroupCount > 0 Then
                        grdInventarioNave.ExportToXlsx(.SelectedPath + "\InventarioNave_" + fecha_hora + ".xlsx")
                    Else
                        Dim exportOptions = New XlsxExportOptionsEx()                                              
                        grdInventarioNave.ExportToXlsx(.SelectedPath + "\InventarioNave_" + fecha_hora + ".xlsx", exportOptions)
                    End If
                    show_message("Exito", "Los datos se exportaron correctamente: " & "InventarioNave_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()

                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\InventarioNave_" + fecha_hora + ".xlsx")
                End If

            End With
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

End Class