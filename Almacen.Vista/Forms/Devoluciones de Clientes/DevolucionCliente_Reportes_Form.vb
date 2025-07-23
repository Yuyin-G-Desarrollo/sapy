Imports DevExpress.Export
Imports DevExpress.Utils
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Stimulsoft.Report
Imports Tools

Public Class DevolucionCliente_Reportes_Form

    Public Negocios As New Negocios.DevolucionClientesBU
    Public TipoReporte As String = ""
    Public Naves As String = ""
    Public Corridas As String = ""
    Public ReporteAnterior As String = ""
    Public ClaveReporte As String = ""
    Public dias() As String = {"Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"}

    Private Sub DevolucionCliente_Reportes_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarInfoCombos()
        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now


        Me.WindowState = FormWindowState.Maximized

        rdbRepEnviosNave.Visible = False
    End Sub

    Public Sub DiseñoGridPrincipal()
        Try
            bgvDevolucionesClientes.OptionsView.ColumnAutoWidth = True

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvDevolucionesClientes.Columns
                col.OptionsColumn.AllowEdit = False
                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
                Dim partesNombre As List(Of String) = col.FieldName.ToString.Split("-").ToList

                If partesNombre.Count > 1 Then
                    col.Caption = partesNombre(0)
                    SumarColumnas(col.FieldName, partesNombre.Last)
                End If

                If col.ColumnType.ToString.Equals("Int32") Or col.ColumnType.ToString.Equals("Int16") Or col.ColumnType.ToString.Equals("Integer") Then
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "N0"
                    col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
                ElseIf col.ColumnType.ToString.Equals("Decimal") Then
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "N2"
                    col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
                Else
                    col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
                End If
            Next

            'bgvDevolucionesClientes.Columns.ColumnByFieldName("Parámetro").Visible = False

            bgvDevolucionesClientes.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

            If rdbRepCliente.Checked Then
                bgvDevolucionesClientes.GroupSummary.Clear()
                bgvDevolucionesClientes.Columns("Cantidad").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:N0}")

                Dim item As New GridGroupSummaryItem
                item.FieldName = "Cantidad"
                item.ShowInGroupColumnFooter = bgvDevolucionesClientes.Columns("Cantidad")
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "Total {0:N}"
                bgvDevolucionesClientes.GroupSummary.Add(item)
            End If



            bgvDevolucionesClientes.IndicatorWidth = 40
            bgvDevolucionesClientes.BestFitColumns()
        Catch ex As Exception
            Tools.Controles.Mensajes_Y_Alertas("ERROR", "Error " + ex.Message)
        End Try
    End Sub

    Public Sub SumarColumnas(columna As String, formato As String)
        If IsNothing(bgvDevolucionesClientes.Columns(columna).Summary.FirstOrDefault(Function(x) x.FieldName = columna)) = True Then
            bgvDevolucionesClientes.Columns(columna).Summary.Add(DevExpress.Data.SummaryItemType.Sum, columna, formato)

            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = columna
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = formato
            bgvDevolucionesClientes.GroupSummary.Add(item)
        End If
    End Sub

    Public Function GenerarFiltrosGrid(grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim filtro As String = ""
        For index As Int64 = 0 To grid.DataRowCount Step 1
            If filtro = "" Then
                filtro += CStr(grid.GetRowCellValue(grid.GetVisibleRowHandle(index), "Parámetro"))
            Else
                filtro = filtro + "," + CStr(grid.GetRowCellValue(grid.GetVisibleRowHandle(index), "Parámetro"))
            End If
        Next
        Return filtro
    End Function

    Public Function GenerarXMLFiltros()
        Dim xmlFiltros As XElement = New XElement("Parametros")

        Dim vNodo As XElement = New XElement("Parametro")
        vNodo.Add(New XAttribute("tipodevolucion", IIf(rdbMayoreo.Checked = True, "MAYOREO", "MENUDEO")))
        vNodo.Add(New XAttribute("fechainicio", dtpFechaInicio.Value))
        vNodo.Add(New XAttribute("fechafin", dtpFechaFin.Value))
        vNodo.Add(New XAttribute("naves", Naves))
        vNodo.Add(New XAttribute("corridas", Corridas))
        vNodo.Add(New XAttribute("clientes", GenerarFiltrosGrid(bgvCliente)))
        vNodo.Add(New XAttribute("colecciones", GenerarFiltrosGrid(bgvColeccion)))
        vNodo.Add(New XAttribute("modelos", GenerarFiltrosGrid(bgvModelo)))
        vNodo.Add(New XAttribute("piel", GenerarFiltrosGrid(bgvPiel)))
        vNodo.Add(New XAttribute("color", GenerarFiltrosGrid(bgvColor)))
        vNodo.Add(New XAttribute("defecto", GenerarFiltrosGrid(bgvDefecto)))
        vNodo.Add(New XAttribute("lote", IIf(txtLote.Text.Length > 0, txtLote.Text, 0)))
        xmlFiltros.Add(vNodo)

        Return xmlFiltros.ToString
    End Function

    Public Function GenerarXMLFiltros(ByVal naveSeleccionada As String)
        Dim xmlFiltros As XElement = New XElement("Parametros")

        Dim vNodo As XElement = New XElement("Parametro")
        vNodo.Add(New XAttribute("tipodevolucion", IIf(rdbMayoreo.Checked = True, "MAYOREO", "MENUDEO")))
        vNodo.Add(New XAttribute("fechainicio", dtpFechaInicio.Value))
        vNodo.Add(New XAttribute("fechafin", dtpFechaFin.Value))
        vNodo.Add(New XAttribute("naves", naveSeleccionada))
        vNodo.Add(New XAttribute("corridas", Corridas))
        vNodo.Add(New XAttribute("clientes", GenerarFiltrosGrid(bgvCliente)))
        vNodo.Add(New XAttribute("colecciones", GenerarFiltrosGrid(bgvColeccion)))
        vNodo.Add(New XAttribute("modelos", GenerarFiltrosGrid(bgvModelo)))
        vNodo.Add(New XAttribute("piel", GenerarFiltrosGrid(bgvPiel)))
        vNodo.Add(New XAttribute("color", GenerarFiltrosGrid(bgvColor)))
        vNodo.Add(New XAttribute("defecto", GenerarFiltrosGrid(bgvDefecto)))
        vNodo.Add(New XAttribute("lote", IIf(txtLote.Text.Length > 0, txtLote.Text, 0)))
        xmlFiltros.Add(vNodo)

        Return xmlFiltros.ToString
    End Function

    Public Sub MostrarDatos()
        Try
            Dim obj As New Negocios.DevolucionClientesBU
            Cursor = Cursors.WaitCursor

            Dim dtReporte As New DataTable
            If ReporteAnterior <> TipoReporte Then
                bgvDevolucionesClientes.Columns.Clear()
                ReporteAnterior = TipoReporte
            End If

            dtReporte = obj.Consulta_Reportes_Devoluciones(GenerarXMLFiltros(), TipoReporte)
            grdDevolucionesClientes.DataSource = dtReporte
            lblTotalRegistros.Text = bgvDevolucionesClientes.DataRowCount.ToString("N0")
            DiseñoGridPrincipal()
            lblUltimaActualizacion.Text = DateTime.Now

            If RadioButton1.Checked = True Then
                bgvDevolucionesClientes.OptionsView.ColumnAutoWidth = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("ClienteID").Visible = False
                bgvDevolucionesClientes.OptionsView.ColumnAutoWidth = False
            ElseIf rdbRepGeneral.Checked Then
                bgvDevolucionesClientes.OptionsView.ColumnAutoWidth = False
            ElseIf rdbRepDefecto.Checked = True Then
                bgvDevolucionesClientes.Columns.ColumnByFieldName("IdMotivo").Visible = False
            ElseIf rdbRepNaveDetallado.Checked = True Then
                bgvDevolucionesClientes.OptionsView.ColumnAutoWidth = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("ClienteID").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("MotivoID").Visible = False
            End If

            If bgvDevolucionesClientes.DataRowCount = 0 Then
                bgvDevolucionesClientes.OptionsView.ColumnAutoWidth = True
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            'pgrsPnlCargando.Hide()
            Tools.Controles.Mensajes_Y_Alertas("ERROR", "Error" + ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Public Function GenerarListaSeleccionados(grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim listaParametroID As New List(Of String)
        For index As Int32 = 0 To grid.DataRowCount - 1 Step 1
            listaParametroID.Add(grid.GetRowCellValue(index, "Parámetro").ToString)
        Next

        Return listaParametroID
    End Function

    Public Sub CargarInfoCombos()
        Dim dtInfo As New DataTable
        dtInfo = (New Negocios.DevolucionCliente_EntradaSalida_Nave_BU).ConsultaNaves()
        cmbUCNave.DataSource = dtInfo
        cmbUCNave.DisplayMember = "Nave"
        cmbUCNave.ValueMember = "IdNave"

        dtInfo = Negocios.ConsultaDatosFiltros("CORRIDA", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "")
        cmbUCCorrida.DataSource = dtInfo
        cmbUCCorrida.DisplayMember = "Corrida"
        cmbUCCorrida.ValueMember = "Parámetro"
    End Sub

    Public Sub DisenoGridFiltros(vista As DevExpress.XtraGrid.Views.Grid.GridView, titulo As String)
        Try
            vista.OptionsView.ColumnAutoWidth = True

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In vista.Columns
                col.OptionsColumn.AllowEdit = False
                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
                If col.ColumnType.ToString.Equals("Int32") Or col.ColumnType.ToString.Equals("Int16") Or col.ColumnType.ToString.Equals("Integer") Then
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "N0"
                ElseIf col.ColumnType.ToString.Equals("Decimal") Then
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "N2"
                End If
            Next

            vista.Columns.ColumnByFieldName("Parámetro").Visible = False

            vista.IndicatorWidth = 40
            vista.BestFitColumns()
        Catch ex As Exception
            Tools.Controles.Mensajes_Y_Alertas("ERROR", "Error " + ex.Message)
        End Try
        'With grid.DisplayLayout.Bands(0)
        '    If .Columns.Count = 1 Then
        '        .Columns(0).Header.Caption = titulo
        '    End If
        'End With

        'With grid.DisplayLayout
        '    .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        '    .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        '    .Override.RowSelectorWidth = 35
        '    .Override.CellClickAction = CellClickAction.RowSelect
        '    .Override.AllowRowFiltering = DefaultableBoolean.False
        '    .Override.AllowAddNew = AllowAddNew.No
        '    .Override.AllowUpdate = DefaultableBoolean.False
        '    .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
        '    .Override.SelectTypeRow = SelectType.Single
        '    .AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'End With

        'If grid.DisplayLayout.Bands(0).Columns.Exists(" ") Then
        '    grid.DisplayLayout.Bands(0).Columns(" ").Hidden = True
        'End If

        'If grid.DisplayLayout.Bands(0).Columns.Exists("Parámetro") Then
        '    grid.DisplayLayout.Bands(0).Columns("Parámetro").Hidden = True
        'End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New DevolucionCliente_AdministradorDC_Parametros_Form
        listado.filtro = "CLIENTES"

        listado.listaParametroID = GenerarListaSeleccionados(bgvCliente)
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdCliente.DataSource = listado.listParametros
        DisenoGridFiltros(bgvCliente, "Cliente")
        With bgvCliente.Columns
            .ColumnByFieldName("Nombre").Caption = "Cliente"
            .ColumnByFieldName("Clasificación").Visible = False
            .ColumnByFieldName("Ranking").Visible = False
            .ColumnByFieldName("Bloqueado").Visible = False
        End With
    End Sub

    Private Sub bgvCliente_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvCliente.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub bgvColeccion_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvColeccion.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub bgvModelo_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvModelo.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub bgvPiel_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvPiel.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub bgvColor_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvColor.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub bgvDefecto_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvDefecto.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub bgvCliente_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles bgvCliente.RowStyle
        If e.RowHandle Mod 2 <> 0 Then
            e.Appearance.BackColor = Color.LightSteelBlue
        End If
    End Sub

    Private Sub bgvColeccion_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles bgvColeccion.RowStyle
        If e.RowHandle Mod 2 <> 0 Then
            e.Appearance.BackColor = Color.LightSteelBlue
        End If
    End Sub

    Private Sub bgvModelo_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles bgvModelo.RowStyle
        If e.RowHandle Mod 2 <> 0 Then
            e.Appearance.BackColor = Color.LightSteelBlue
        End If
    End Sub

    Private Sub bgvPiel_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles bgvPiel.RowStyle
        If e.RowHandle Mod 2 <> 0 Then
            e.Appearance.BackColor = Color.LightSteelBlue
        End If
    End Sub

    Private Sub bgvColor_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles bgvColor.RowStyle
        If e.RowHandle Mod 2 <> 0 Then
            e.Appearance.BackColor = Color.LightSteelBlue
        End If
    End Sub

    Private Sub bgvDefecto_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles bgvDefecto.RowStyle
        If e.RowHandle Mod 2 <> 0 Then
            e.Appearance.BackColor = Color.LightSteelBlue
        End If
    End Sub

    Private Sub bgvDevolucionesClientes_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles bgvDevolucionesClientes.RowStyle
        If e.RowHandle Mod 2 <> 0 Then
            e.Appearance.BackColor = Color.LightSteelBlue
        End If
    End Sub

    Private Sub bgvDevolucionesClientes_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvDevolucionesClientes.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnColeccion_Click(sender As Object, e As EventArgs) Handles btnColeccion.Click
        Dim listado As New DevolucionCliente_AdministradorDC_Parametros_Form
        listado.filtro = "COLECCIONES"

        listado.listaParametroID = GenerarListaSeleccionados(bgvColeccion)
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColeccion.DataSource = listado.listParametros
        DisenoGridFiltros(bgvColeccion, "Colección")
        With bgvColeccion.Columns
            .ColumnByFieldName("Temporada").Visible = False
            .ColumnByFieldName("Año").Visible = False
        End With
    End Sub

    Private Sub btnModelo_Click(sender As Object, e As EventArgs) Handles btnModelo.Click
        Dim listado As New DevolucionCliente_AdministradorDC_Parametros_Form
        listado.filtro = "MODELOS"

        listado.listaParametroID = GenerarListaSeleccionados(bgvModelo)
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdModelo.DataSource = listado.listParametros
        DisenoGridFiltros(bgvModelo, "Modelos")
        With bgvModelo.Columns
            .ColumnByFieldName("Marca").Visible = False
            .ColumnByFieldName("Colección").Visible = False
            .ColumnByFieldName("Modelo SICY").Visible = False
        End With
    End Sub

    Private Sub btnPiel_Click(sender As Object, e As EventArgs) Handles btnPiel.Click
        Dim listado As New DevolucionCliente_AdministradorDC_Parametros_Form
        listado.filtro = "PIEL"

        listado.listaParametroID = GenerarListaSeleccionados(bgvPiel)
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdPiel.DataSource = listado.listParametros
        DisenoGridFiltros(bgvPiel, "Piel")
    End Sub

    Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
        Dim listado As New DevolucionCliente_AdministradorDC_Parametros_Form
        listado.filtro = "COLOR"

        listado.listaParametroID = GenerarListaSeleccionados(bgvColor)
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColor.DataSource = listado.listParametros
        DisenoGridFiltros(bgvColor, "Color")
    End Sub

    Private Sub btnDefectos_Click(sender As Object, e As EventArgs) Handles btnDefectos.Click
        Dim listado As New DevolucionCliente_AdministradorDC_Parametros_Form
        listado.filtro = "DEFECTO"

        listado.listaParametroID = GenerarListaSeleccionados(bgvDefecto)
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdDefecto.DataSource = listado.listParametros
        DisenoGridFiltros(bgvDefecto, "Defecto")
        With bgvDefecto.Columns
            .ColumnByFieldName(" ").Visible = False
            .ColumnByFieldName("Activo").Visible = False
            .ColumnByFieldName("Departamento").Visible = False
        End With
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        MostrarDatos()
    End Sub

    Private Sub rdbRepGeneral_CheckedChanged(sender As Object, e As EventArgs) Handles rdbRepGeneral.CheckedChanged
        Dim radio As RadioButton = CType(sender, RadioButton)
        If radio.Checked = True Then
            'TipoReporte = "General"
            TipoReporte = "Detallado"
            ClaveReporte = "REPORTE_DEVOLUCION_GENERAL"
        End If
    End Sub

    Private Sub rdbRepCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rdbRepCliente.CheckedChanged
        Dim radio As RadioButton = CType(sender, RadioButton)
        If radio.Checked = True Then
            TipoReporte = "Cliente"
            ClaveReporte = "REPORTE_DEVOLUCION_PORCLIENTE"
        End If
    End Sub

    Private Sub rdbRepDefecto_CheckedChanged(sender As Object, e As EventArgs) Handles rdbRepDefecto.CheckedChanged
        Dim radio As RadioButton = CType(sender, RadioButton)
        If radio.Checked = True Then
            TipoReporte = "Defecto"
            ClaveReporte = "REPORTE_DEVOLUCION_PORDEFECTO"
        End If
    End Sub

    Private Sub rdbRepNaveDetallado_CheckedChanged(sender As Object, e As EventArgs) Handles rdbRepNaveDetallado.CheckedChanged
        Dim radio As RadioButton = CType(sender, RadioButton)
        If radio.Checked = True Then
            TipoReporte = "NaveDetallado"
            ClaveReporte = "REPORTE_DEVOLUCION_NAVEDETALLADO"
        End If
    End Sub

    Private Sub rdbRepNaveResumen_CheckedChanged(sender As Object, e As EventArgs) Handles rdbRepNaveResumen.CheckedChanged
        Dim radio As RadioButton = CType(sender, RadioButton)
        If radio.Checked = True Then
            TipoReporte = "NaveResumen"
            ClaveReporte = "REPORTE_DEVOLUCION_PORNAVERESUMEN"
        End If
    End Sub

    Private Sub rdbRepEnviosNave_CheckedChanged(sender As Object, e As EventArgs) Handles rdbRepEnviosNave.CheckedChanged
        Dim radio As RadioButton = CType(sender, RadioButton)
        If radio.Checked = True Then
            TipoReporte = "EnviosNave"
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Dim radio As RadioButton = CType(sender, RadioButton)
        If radio.Checked = True Then
            TipoReporte = "Detallado"
            'ClaveReporte = "REPORTE_DEVOLUCION_DETALLETALLAS"
        End If
    End Sub

    Private Sub cmbUCNave_ValueChanged(sender As Object, e As EventArgs) Handles cmbUCNave.ValueChanged
        Dim dtDatosFiltrados As New DataTable
        Dim datosCombo As System.Collections.IList = Nothing
        Dim dtsCmbFiltro As IValueList = Nothing

        datosCombo = Me.cmbUCNave.Value
        dtsCmbFiltro = Me.cmbUCNave.Items.ValueList

        If Not datosCombo Is Nothing Then
            Dim index As Int32 = -1
            Naves = ""
            For Each value As Object In datosCombo
                If Naves = "" Then
                    Naves += value.ToString
                Else
                    Naves += "," + value.ToString
                End If
            Next
        Else
            Naves = String.Empty
        End If
    End Sub

    Private Sub cmbUCCorrida_ValueChanged(sender As Object, e As EventArgs) Handles cmbUCCorrida.ValueChanged
        Dim dtDatosFiltrados As New DataTable
        Dim datosCombo As System.Collections.IList = Nothing
        Dim dtsCmbFiltro As IValueList = Nothing

        datosCombo = Me.cmbUCCorrida.Value
        dtsCmbFiltro = Me.cmbUCCorrida.Items.ValueList

        If Not datosCombo Is Nothing Then
            Dim index As Int32 = -1
            Corridas = ""
            For Each value As Object In datosCombo
                If Corridas = "" Then
                    Corridas += value.ToString
                Else
                    Corridas += "," + value.ToString
                End If
            Next
        Else
            Corridas = String.Empty
        End If
    End Sub

    Public Sub BorraFilaSeleccionada(sender As Object, e As KeyEventArgs)
        Dim grid = TryCast(sender, GridControl)
        Dim view = TryCast(grid.FocusedView, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.KeyData = Keys.Delete Then
            view.DeleteSelectedRows()
            e.Handled = True
        End If
    End Sub

    Private Sub grdDevolucionesClientes_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles grdDevolucionesClientes.ProcessGridKey
        BorraFilaSeleccionada(sender, e)
    End Sub

    Private Sub grdCliente_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles grdCliente.ProcessGridKey
        BorraFilaSeleccionada(sender, e)
    End Sub

    Private Sub grdColeccion_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles grdColeccion.ProcessGridKey
        BorraFilaSeleccionada(sender, e)
    End Sub

    Private Sub grdModelo_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles grdModelo.ProcessGridKey
        BorraFilaSeleccionada(sender, e)
    End Sub

    Private Sub grdPiel_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles grdPiel.ProcessGridKey
        BorraFilaSeleccionada(sender, e)
    End Sub

    Private Sub grdColor_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles grdColor.ProcessGridKey
        BorraFilaSeleccionada(sender, e)
    End Sub

    Private Sub grdDefecto_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles grdDefecto.ProcessGridKey
        BorraFilaSeleccionada(sender, e)
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If bgvDevolucionesClientes.DataRowCount > 0 Then
            Dim fbdUbicacion As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty

            Try
                nombreReporte = "\Devoluciones_Clientes_Reportes"
                With fbdUbicacion
                    .Reset()
                    .Description = "Selecciona una carpeta"
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        Dim exportOptions As New XlsxExportOptionsEx()
                        'exportOptions.ExportType = ExportType.DataAware
                        DevExpress.Export.ExportSettings.DefaultExportType = ExportType.WYSIWYG
                        AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                        grdDevolucionesClientes.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        Tools.Controles.Mensajes_Y_Alertas("EXITO", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        Process.Start(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If

                End With
            Catch ex As Exception
                Tools.Controles.Mensajes_Y_Alertas("ERROR", "Error: " + ex.Message.ToString)
            End Try
        Else
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "No hay datos para exportar")
        End If
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As CustomizeCellEventArgs)
        Try
            If e.RowHandle Mod 2 = 0 Then
                bgvDevolucionesClientes.GetRow(e.RowHandle)
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            'MsgBox("Error" + ex.Message.ToString())
        End Try
        e.Handled = True
    End Sub

    Private Sub bgvDevolucionesClientes_ColumnFilterChanged(sender As Object, e As EventArgs) Handles bgvDevolucionesClientes.ColumnFilterChanged
        lblTotalRegistros.Text = bgvDevolucionesClientes.DataRowCount.ToString("N0")
    End Sub

    Public Function FormatoFecha(Fecha As Date)
        Dim fechaFormateada As String = ""
        fechaFormateada = dias(CInt(Fecha.DayOfWeek)).ToString + " " + Format(Fecha, "dd").ToString + " de " + Format(Fecha, "MMMM").ToString + " del " + Format(Fecha, "yyyy").ToString
        Return fechaFormateada
    End Function

    Private Sub ImprimirReporte()
        Me.Cursor = Cursors.WaitCursor

        Dim dsInfoDevolucion As New DataSet("Devoluciones")
        Dim dtInfoDevolucion As New DataTable("Devolucion")
        'Dim dtInfoCliente As New DataTable("Cliente")

        If RadioButton1.Checked = True Then
            bgvDevolucionesClientes.OptionsView.ColumnAutoWidth = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("ClienteID").Visible = False
            bgvDevolucionesClientes.OptionsView.ColumnAutoWidth = True
            Cursor = Cursors.Default
            Exit Sub
        End If

        dtInfoDevolucion = Negocios.Consulta_Reportes_Devoluciones(GenerarXMLFiltros(), TipoReporte)

        'dtInfoDevolucion = tblInfoDev.Clone

        If dtInfoDevolucion.Rows.Count = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontró información.")
            Me.Cursor = Cursors.Default
            Return
        End If
        dsInfoDevolucion.Tables.Add(dtInfoDevolucion)

        Dim reportesBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        EntidadReporte = reportesBU.LeerReporteporClave(ClaveReporte)

        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()
        reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(43)
        'reporte("nombreNave") = Tools.Controles.RecuperarNombreNave(43)
        reporte("NombreReporte") = "SAY: " + ClaveReporte + ".mrt"
        reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString

        If rdbRepCliente.Checked = True Then
            Dim TotalPares As Integer = 0
            For Each row As DataRow In dtInfoDevolucion.Rows
                TotalPares = TotalPares + row.Item("Cantidad")
            Next

            reporte("FechaInicio") = FormatoFecha(dtpFechaInicio.Value)
            reporte("FechaFin") = FormatoFecha(dtpFechaFin.Value)
            reporte("TotalPares") = TotalPares
            reporte("TipoDevolucion") = IIf(rdbMayoreo.Checked = True, "MAYOREO", "MENUDEO")
        ElseIf rdbRepNaveResumen.Checked = True Then
            Dim TotalPares As Integer = 0
            For Each row As DataRow In dtInfoDevolucion.Rows
                TotalPares = TotalPares + row.Item("Cantidad-SUM-{0:N0}")
            Next

            reporte("FechaInicio") = FormatoFecha(dtpFechaInicio.Value)
            reporte("FechaFin") = FormatoFecha(dtpFechaFin.Value)
            reporte("TotalPares") = TotalPares
            reporte("TipoDevolucion") = IIf(rdbMayoreo.Checked = True, "MAYOREO", "MENUDEO")
        ElseIf rdbRepDefecto.Checked = True Then
            Dim TotalPares As Integer = 0
            For Each row As DataRow In dtInfoDevolucion.Rows
                TotalPares = TotalPares + row.Item("Cantidad-SUM-{0:N0}")
            Next

            reporte("FechaInicio") = FormatoFecha(dtpFechaInicio.Value)
            reporte("FechaFin") = FormatoFecha(dtpFechaFin.Value)
            reporte("TotalPares") = TotalPares
            reporte("TipoDevolucion") = IIf(rdbMayoreo.Checked = True, "MAYOREO", "MENUDEO")
        End If

        reporte.Dictionary.Clear()
        reporte.RegData(dsInfoDevolucion)
        reporte.Dictionary.Synchronize()

        reporte.Show()

        Me.Cursor = Cursors.Default

    End Sub

    Public Sub ImprimirReporteGeneral()
        Dim TotalPares As Integer = 0
        Me.Cursor = Cursors.WaitCursor
        If bgvDevolucionesClientes.DataRowCount > 0 Then

            Dim Resumen = New DataSet("Colaboradores")
            Dim Colaborador = New DataTable("Colaborador")
            Dim Celulas = New DataTable("Celulas")

            With Colaborador
                .Columns.Add("Folio")
                .Columns.Add("Tipo")
                .Columns.Add("ClienteID")
                .Columns.Add("Cliente")
                .Columns.Add("ModeloSAY")
                .Columns.Add("ModeloSICY")
                .Columns.Add("Descripcion")
                .Columns.Add("Fecha")
                .Columns.Add("Defecto")
                .Columns.Add("Nave")
                .Columns.Add("NombreNave")
                .Columns.Add("Lote")
                .Columns.Add("Cantidad-SUM-{0:N0}")
            End With

            With Celulas
                .Columns.Add("ClienteID")
                .Columns.Add("Cliente")
                .Columns.Add("Folio")
            End With

            For index As Integer = 0 To bgvDevolucionesClientes.DataRowCount Step 1
                Colaborador.Rows.Add(
                    bgvDevolucionesClientes.GetRowCellValue(index, "Folio"),
                    bgvDevolucionesClientes.GetRowCellValue(index, "Tipo"),
                    bgvDevolucionesClientes.GetRowCellValue(index, "ClienteID"),
                    bgvDevolucionesClientes.GetRowCellValue(index, "Cliente"),
                    bgvDevolucionesClientes.GetRowCellValue(index, "ModeloSAY"),
                    bgvDevolucionesClientes.GetRowCellValue(index, "ModeloSICY"),
                    bgvDevolucionesClientes.GetRowCellValue(index, "Descripcion"),
                    bgvDevolucionesClientes.GetRowCellValue(index, "FechaDevolución"),
                    bgvDevolucionesClientes.GetRowCellValue(index, "Defecto"),
                    bgvDevolucionesClientes.GetRowCellValue(index, "Nave"),
                    bgvDevolucionesClientes.GetRowCellValue(index, "NombreNave"),
                    bgvDevolucionesClientes.GetRowCellValue(index, "Lote"),
                    bgvDevolucionesClientes.GetRowCellValue(index, "Cantidad-SUM-{0:N0}")
                )
                TotalPares = TotalPares + CInt(bgvDevolucionesClientes.GetRowCellValue(index, "Cantidad-SUM-{0:N0}"))

                Dim existe As Boolean = False
                For Each filaClientes As DataRow In Celulas.Rows
                    If filaClientes.Item("ClienteID") = bgvDevolucionesClientes.GetRowCellValue(index, "ClienteID") And filaClientes.Item("Folio") = bgvDevolucionesClientes.GetRowCellValue(index, "Folio") Then
                        existe = True
                        Exit For
                    End If
                Next

                If existe = False Then
                    Celulas.Rows.Add(bgvDevolucionesClientes.GetRowCellValue(index, "ClienteID"), bgvDevolucionesClientes.GetRowCellValue(index, "Cliente"), bgvDevolucionesClientes.GetRowCellValue(index, "Folio"))
                End If
            Next

            Resumen.Tables.Add(Colaborador)
            Resumen.Tables.Add(Celulas)

            Dim OBJBU As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            EntidadReporte = OBJBU.LeerReporteporClave("REPORTE_DEVOLUCION_GENERAL")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport


            reporte.Load(archivo)
            reporte.Compile()
            reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(43)
            'reporte("nombreNave") = Tools.Controles.RecuperarNombreNave(43)
            reporte("NombreReporte") = "SAY: " + ClaveReporte + ".mrt"
            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
            reporte("FechaInicio") = FormatoFecha(dtpFechaInicio.Value)
            reporte("FechaFin") = FormatoFecha(dtpFechaFin.Value)
            reporte("TotalPares") = TotalPares
            reporte("TipoDevolucion") = IIf(rdbMayoreo.Checked = True, "MAYOREO", "MENUDEO")
            reporte.RegData(Resumen)
            reporte.Show()

        Else
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "No se encontraron registros que coincidan con los criterios de búsqueda")
            Exit Sub
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub ImprimirReporteNaveDetallado()
        Dim listaNaves As New List(Of String)
        listaNaves = Naves.Split(",").ToList
        listaNaves.Remove("")
        For Each elemento In listaNaves
            Dim objNegocios_Dev As New Negocios.DevolucionClientesBU
            Cursor = Cursors.WaitCursor

            Dim dtReporte As New DataTable
            If ReporteAnterior <> TipoReporte Then
                bgvDevolucionesClientes.Columns.Clear()
                ReporteAnterior = TipoReporte
            End If


            dtReporte = objNegocios_Dev.Consulta_Reportes_Devoluciones(GenerarXMLFiltros(elemento), TipoReporte)
            grdDevolucionesClientes.DataSource = dtReporte
            lblTotalRegistros.Text = bgvDevolucionesClientes.DataRowCount.ToString("N0")
            DiseñoGridPrincipal()

            bgvDevolucionesClientes.OptionsView.ColumnAutoWidth = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("ClienteID").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("MotivoID").Visible = False

            Dim TotalPares As Integer = 0
            Me.Cursor = Cursors.WaitCursor
            If bgvDevolucionesClientes.DataRowCount > 0 Then

                Dim Resumen = New DataSet("Colaboradores")
                Dim Colaborador = New DataTable("Colaborador")
                Dim Celulas = New DataTable("Celulas")

                With Colaborador
                    .Columns.Add("Folio")
                    .Columns.Add("Fecha")
                    .Columns.Add("ClienteID")
                    .Columns.Add("Cliente")
                    .Columns.Add("ModeloSAY")
                    .Columns.Add("ModeloSICY")
                    .Columns.Add("Descripción")
                    .Columns.Add("Clasificación")
                    .Columns.Add("MotivoID")
                    .Columns.Add("Motivo")
                    .Columns.Add("NombreNave")
                    .Columns.Add("Lote")
                    .Columns.Add("Cantidad-SUM-{0:N0}")
                End With

                With Celulas
                    .Columns.Add("MotivoID")
                    .Columns.Add("Motivo")
                    .Columns.Add("Folio")
                End With

                For index As Integer = 0 To bgvDevolucionesClientes.DataRowCount Step 1
                    Colaborador.Rows.Add(
                        bgvDevolucionesClientes.GetRowCellValue(index, "Folio"),
                        bgvDevolucionesClientes.GetRowCellValue(index, "Fecha"),
                        bgvDevolucionesClientes.GetRowCellValue(index, "ClienteID"),
                        bgvDevolucionesClientes.GetRowCellValue(index, "Cliente"),
                        bgvDevolucionesClientes.GetRowCellValue(index, "ModeloSAY"),
                        bgvDevolucionesClientes.GetRowCellValue(index, "ModeloSICY"),
                        bgvDevolucionesClientes.GetRowCellValue(index, "Descripción"),
                        bgvDevolucionesClientes.GetRowCellValue(index, "Clasificación"),
                        bgvDevolucionesClientes.GetRowCellValue(index, "MotivoID"),
                        bgvDevolucionesClientes.GetRowCellValue(index, "Motivo"),
                        bgvDevolucionesClientes.GetRowCellValue(index, "NombreNave"),
                        bgvDevolucionesClientes.GetRowCellValue(index, "Lote"),
                        bgvDevolucionesClientes.GetRowCellValue(index, "Cantidad-SUM-{0:N0}")
                    )
                    TotalPares = TotalPares + CInt(bgvDevolucionesClientes.GetRowCellValue(index, "Cantidad-SUM-{0:N0}"))

                    Dim existe As Boolean = False
                    For Each filaClientes As DataRow In Celulas.Rows
                        If filaClientes.Item("MotivoID") = bgvDevolucionesClientes.GetRowCellValue(index, "MotivoID") Then
                            existe = True
                            Exit For
                        End If
                    Next

                    If existe = False Then
                        Celulas.Rows.Add(bgvDevolucionesClientes.GetRowCellValue(index, "MotivoID"), bgvDevolucionesClientes.GetRowCellValue(index, "Motivo"), bgvDevolucionesClientes.GetRowCellValue(index, "Folio"))
                    End If
                Next

                Resumen.Tables.Add(Colaborador)
                Resumen.Tables.Add(Celulas)

                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("REPORTE_DEVOLUCION_NAVEDETALLADO")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport


                reporte.Load(archivo)
                reporte.Compile()
                reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(elemento)
                'reporte("nombreNave") = Tools.Controles.RecuperarNombreNave(43)
                reporte("NombreReporte") = "SAY: " + ClaveReporte + ".mrt"
                reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
                reporte("FechaInicio") = FormatoFecha(dtpFechaInicio.Value)
                reporte("FechaFin") = FormatoFecha(dtpFechaFin.Value)
                reporte("Nave") = dtReporte.Rows(0).Item("NombreNave")
                reporte("TotalPares") = TotalPares
                reporte("TipoDevolucion") = IIf(rdbMayoreo.Checked = True, "MAYOREO", "MENUDEO")
                reporte.RegData(Resumen)
                reporte.Show()
                Me.Cursor = Cursors.Default
            Else
                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "No se encontraron registros para esa nave")
            End If
        Next
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        'prueba()
        Try
            MostrarDatos()

            If rdbRepGeneral.Checked = True Then
                ImprimirReporteGeneral()
            ElseIf rdbRepNaveDetallado.Checked = True Then
                ImprimirReporteNaveDetallado()
            Else
                ImprimirReporte()
            End If
        Catch ex As Exception
            Tools.Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdCliente.DataSource = New List(Of String)
    End Sub

    Private Sub btnLimpiarColeccion_Click(sender As Object, e As EventArgs) Handles btnLimpiarColeccion.Click
        grdColeccion.DataSource = New List(Of String)
    End Sub

    Private Sub btnLimpiarModelo_Click(sender As Object, e As EventArgs) Handles btnLimpiarModelo.Click
        grdModelo.DataSource = New List(Of String)
    End Sub

    Private Sub btnLimpiarPiel_Click(sender As Object, e As EventArgs) Handles btnLimpiarPiel.Click
        grdPiel.DataSource = New List(Of String)
    End Sub

    Private Sub btnLimpiarColor_Click(sender As Object, e As EventArgs) Handles btnLimpiarColor.Click
        grdColor.DataSource = New List(Of String)
    End Sub

    Private Sub btbLimpiarFiltroDefecto_Click(sender As Object, e As EventArgs) Handles btbLimpiarFiltroDefecto.Click
        grdDefecto.DataSource = New List(Of String)
    End Sub
End Class