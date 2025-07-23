Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils
Imports DevExpress.XtraPrinting
Imports DevExpress.Export

Public Class ActualizacionMasiva_Agentes
    Dim objAgentesVentas As New Negocios.ActualizacionMasivaAgentesBU
    Dim objRutas As New Negocios.ActualizacionMasivaAgentesBU
    Dim objMarcas As New Negocios.ActualizacionMasivaAgentesBU
    Dim objFamVentas As New Negocios.ActualizacionMasivaAgentesBU
    Dim objAgenteAsignado As New Negocios.ActualizacionMasivaAgentesBU
    Dim objPrincipal As New Negocios.ActualizacionMasivaAgentesBU
    Dim objActualizaAgenteComision As New Negocios.ActualizacionMasivaAgentesBU
    Dim objActualizaAgenteVentas As New Negocios.ActualizacionMasivaAgentesBU
    Dim objReplicacionesCMFPA_CLMAE_SAY_SICY As New Negocios.ActualizacionMasivaAgentesBU
    Dim objActualizaProspecta As New Negocios.ActualizacionMasivaAgentesBU
    Dim objreplicacionesClienteMarcaFamiliaProyeccionAgente_ClienteMarcaAgenteEmpresa_SAY_SICY As New Negocios.ActualizacionMasivaAgentesBU

    Dim dtGrdRutas As New DataTable
    Dim dtGrdMarcas As New DataTable
    Dim dtGrdFamVentas As New DataTable
    Dim dtGrdAgenteAsignado As New DataTable
    Dim dtGrdPrincipal As New DataTable
    Dim dtCbxCoordinador As DataTable

    'arreglo que sirve para guardar los registros seleccionados de la tabla Rutas
    Dim rowsRutas As New ArrayList()
    Dim rowsMarcas As New ArrayList()
    Dim rowsFamVentas As New ArrayList()
    Dim rowsAgenteAsignado As New ArrayList()
    Dim rowsPrincipal As New ArrayList()

    Dim tipoAgenteTabla As String = ""

    Private Sub pnlParametros_Paint(sender As Object, e As PaintEventArgs)

    End Sub
    Private Sub ActualizacionMasiva_Agentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized
        'cargo el combo desde que se carga la pantalla
        llenarDatosInicio()
        estiloGrdRutas()
        estiloGrdMarcas()
        estiloGrdFamiliaVentas()
        estiloGrdAgenteAsignado()
        tipoAgenteTabla = "ventas"
    End Sub

    Public Sub llenarDatosInicio()

        Dim ComboObtenerCoordinador As ComboBox = cbxCoordinador
        dtCbxCoordinador = objAgentesVentas.verCoordinadores()
        ComboObtenerCoordinador.DataSource = dtCbxCoordinador
        ComboObtenerCoordinador.DisplayMember = "NOMBRE_COLABORADOR"
        ComboObtenerCoordinador.ValueMember = "ID_COORD"

        'lleno a los datos en todos los filtros
        dtGrdRutas = objRutas.verRutas()
        grdRutas.DataSource = dtGrdRutas

        dtGrdMarcas = objMarcas.verMarcas()
        grdMarcas.DataSource = dtGrdMarcas

        dtGrdFamVentas = objMarcas.verFamiliaVentas()
        grdFamiliasVenta.DataSource = dtGrdFamVentas

        dtGrdAgenteAsignado = objMarcas.verAgentesAsignados()
        grdAgenteAsignado.DataSource = dtGrdAgenteAsignado

        Dim dtAgentesVentas As New DataTable
        dtAgentesVentas = objAgentesVentas.verAgentesVentaComision
        Dim dtAgentesComision As New DataTable
        dtAgentesComision = objAgentesVentas.verAgentesVentaComision
        'llenado de combos
        If dtAgentesVentas.Rows.Count > 0 Then
            Dim newRowAgenteVentas As DataRow = dtAgentesVentas.NewRow


            dtAgentesVentas.Rows.InsertAt(newRowAgenteVentas, 0)
            cboxAgenteVentas.DataSource = dtAgentesVentas
            cboxAgenteVentas.DisplayMember = "Agente"
            cboxAgenteVentas.ValueMember = "codr_colaboradorid"
            cboxAgenteVentas.SelectedIndex = 0


        End If
        If dtAgentesComision.Rows.Count > 0 Then
            Dim newRowAgenteComision As DataRow = dtAgentesComision.NewRow
            dtAgentesComision.Rows.InsertAt(newRowAgenteComision, 0)
            cboxAgenteComision.DataSource = dtAgentesComision
            cboxAgenteComision.DisplayMember = "Agente"
            cboxAgenteComision.ValueMember = "codr_colaboradorid"
            cboxAgenteComision.SelectedIndex = 0
        End If

    End Sub


    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        'da formato al momento de exportar los datos al acrchivo xlsx
        If e.ColumnFieldName = "FModificación" Then
            Dim displayFormatlstPrBAct = grdPr.Columns("FModificación").DisplayFormat
            'displayFormatlstPrBAct.FormatType = FormatType.DateTime
            'displayFormatlstPrBAct.FormatString = "dd/MM/yyyy hh:mm:ss tt"
            e.Formatting.FormatType = FormatType.DateTime
            e.Formatting.FormatString = "dd/MM/yyyy hh:mm:ss tt"
        End If
        e.Handled = True
    End Sub

    Private Sub recargaDatosMostrarGuardar()
        Me.Cursor = Cursors.WaitCursor
        ' limpio el grid por los nombres
        grdPr.Columns.Clear()
        lblNumeroRegistros.Text = 0
        rowsRutas.Clear()
        rowsMarcas.Clear()
        rowsFamVentas.Clear()
        rowsAgenteAsignado.Clear()

        'FALTA AÑADIR LAS RUTAS A SU ARREGLO
        For I = 0 To grdRut.SelectedRowsCount() - 1
            If (grdRut.GetSelectedRows()(I) >= 0) Then
                rowsRutas.Add(grdRut.GetDataRow(grdRut.GetSelectedRows()(I)))
            End If
        Next


        'añade los seleccionados de marcas a su arreglo
        For I = 0 To grdMarc.SelectedRowsCount() - 1
            If (grdMarc.GetSelectedRows()(I) >= 0) Then
                rowsMarcas.Add(grdMarc.GetDataRow(grdMarc.GetSelectedRows()(I)))
            End If
        Next

        'añade los seleccionados de familia de ventas a su arreglo
        For I = 0 To grdFamVe.SelectedRowsCount() - 1
            If (grdFamVe.GetSelectedRows()(I) >= 0) Then
                rowsFamVentas.Add(grdFamVe.GetDataRow(grdFamVe.GetSelectedRows()(I)))
            End If
        Next

        'FALTA AÑADIR LOS AGENTES ASIGNADOS A SU ARREGLO
        For I = 0 To grdAgenAsign.SelectedRowsCount() - 1
            If (grdAgenAsign.GetSelectedRows()(I) >= 0) Then
                rowsAgenteAsignado.Add(grdAgenAsign.GetDataRow(grdAgenAsign.GetSelectedRows()(I)))
            End If
        Next

        'se valida cual es la lista a mostrar según radio seleccionado
        ' orden de valores idRuta As Integer, idMarca As Integer, idFamiliaProyeccion As Integer, idAgenteAsignado As Integer, agente As String
        If rdoAgenteVentas.Checked = True Then
            dtGrdPrincipal = objPrincipal.verListaPrincipal(rowsRutas, rowsMarcas, rowsFamVentas, rowsAgenteAsignado, "ventas")
            grdLista.DataSource = dtGrdPrincipal
            estiloGrdPrincipal()
            tipoAgenteTabla = "ventas"
        ElseIf rdoAgenteComision.Checked = True Then
            dtGrdPrincipal = objPrincipal.verListaPrincipal(rowsRutas, rowsMarcas, rowsFamVentas, rowsAgenteAsignado, "comision")
            grdLista.DataSource = dtGrdPrincipal
            estiloGrdPrincipal()
            tipoAgenteTabla = "comision"
        Else
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "No se ha seleccionado ningún tipo de Agente."
            objMensaje.ShowDialog()

        End If

        Me.Cursor = Cursors.Default
    End Sub


    Public Sub estiloGrdRutas()
        'Adecuar ancho del indicador de renglón en el grid
        grdRut.IndicatorWidth = 40
        'muestra la columna de checkbox
        grdRut.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        AddHandler grdRut.SelectionChanged, AddressOf gridRut_SelectionChanged
        grdRut.OptionsSelection.MultiSelect = True
        'tamaño de la columna 
        grdRut.OptionsSelection.CheckBoxSelectorColumnWidth = 25

        'sirve para estilo de auto acomodo de tamaño de columnas
        grdRut.OptionsView.ColumnAutoWidth = False
        grdRut.OptionsView.BestFitMaxRowCount = -1
        grdRut.BestFitColumns()
        grdRut.Columns("Ruta").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdRut.Columns("Clientes").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

        ' acomodo los header de las columnas de forma centrada
        grdRut.Columns("Ruta").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdRut.Columns("Clientes").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center

        'habilita si se van a editar o no los valores de la columna con el nombre que tiene        
        grdRut.Columns("Ruta").OptionsColumn.AllowEdit = False
        grdRut.Columns("Clientes").OptionsColumn.AllowEdit = False

        grdRut.Columns("idRuta").Visible = False

        grdRut.Columns("Ruta").Width = 150
        grdRut.Columns("Clientes").Width = 70
        For i As Integer = 1 To grdRut.RowCount - 1
            If i Mod 2 = 0 Then
                'GridView1.OptionsView.EnableAppearanceOddRow = Color.LightSteelBlue
                grdRut.Appearance.EvenRow.BackColor = Color.LightSteelBlue
                grdRut.OptionsView.EnableAppearanceEvenRow = True
                grdRutas.Invalidate()
            End If
        Next
    End Sub
    Private Sub gridRut_SelectionChanged(ByVal sender As Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs)
        'sirve para tomar el número de clientes seleccionados
        For I = 0 To grdRut.SelectedRowsCount() - 1
            If (grdRut.GetSelectedRows()(I) >= 0) Then
                rowsRutas.Add(grdRut.GetDataRow(grdRut.GetSelectedRows()(I)))
            End If
        Next
        'estalbezco en el label el número de clientes que se han seleccionado
        'lblRegistros.Text = Rows.Count.ToString
        'limpio el arreglo ya que se ejecuta cada vez que se presiona y si no se limpia genera mas registros,
        'se tiene que estar limpiando cada que se selecciona un cliente. al final hace un conteo de los que están
        'seleccionados no importa que se esté limpiando cada vez que se selecciona/deselecciona un cliente
        rowsRutas.Clear()
    End Sub

    Private Sub grdRut_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdRut.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub grdRut_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        'realiza un contador de filas arrojadas
        If e.Column.FieldName = "#" AndAlso e.IsGetData Then
            e.Value = grdRut.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Public Sub estiloGrdMarcas()
        'Adecuar ancho del indicador de renglón en el grid
        grdMarc.IndicatorWidth = 40
        'muestra la columna de checkbox
        grdMarc.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        AddHandler grdMarc.SelectionChanged, AddressOf gridMarc_SelectionChanged
        grdMarc.OptionsSelection.MultiSelect = True
        'tamaño de la columna 
        grdMarc.OptionsSelection.CheckBoxSelectorColumnWidth = 25

        'sirve para estilo de auto acomodo de tamaño de columnas
        grdMarc.OptionsView.ColumnAutoWidth = False
        grdMarc.OptionsView.BestFitMaxRowCount = -1
        grdMarc.BestFitColumns()

        ' acomodo los header de las columnas de forma centrada
        grdMarc.Columns("Marca").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center

        grdMarc.Columns("Marca").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdMarc.Columns("idMarca").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

        'habilita si se van a editar o no los valores de la columna con el nombre que tiene        
        grdMarc.Columns("Marca").OptionsColumn.AllowEdit = False
        'grdMarc.Columns("idMarca").OptionsColumn.AllowEdit = False

        'establezco tamaño a columna Marca
        grdMarc.Columns("Marca").Width = 180
        'coulto la columna de idMarca
        grdMarc.Columns("idMarca").Visible = False
        For i As Integer = 1 To grdRut.RowCount - 1
            If i Mod 2 = 0 Then
                'GridView1.OptionsView.EnableAppearanceOddRow = Color.LightSteelBlue
                grdMarc.Appearance.EvenRow.BackColor = Color.LightSteelBlue
                grdMarc.OptionsView.EnableAppearanceEvenRow = True
                grdMarc.Invalidate()
            End If
        Next
    End Sub
    Private Sub gridMarc_SelectionChanged(ByVal sender As Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs)
        'sirve para tomar el número de clientes seleccionados
        For I = 0 To grdMarc.SelectedRowsCount() - 1
            If (grdMarc.GetSelectedRows()(I) >= 0) Then
                rowsMarcas.Add(grdMarc.GetDataRow(grdMarc.GetSelectedRows()(I)))
                ' MsgBox("Marca " + grdMarc.GetSelectedRows()(I).ToString)
            End If
        Next
        'estalbezco en el label el número de clientes que se han seleccionado
        'lblRegistros.Text = Rows.Count.ToString
        'limpio el arreglo ya que se ejecuta cada vez que se presiona y si no se limpia genera mas registros,
        'se tiene que estar limpiando cada que se selecciona un cliente. al final hace un conteo de los que están
        'seleccionados no importa que se esté limpiando cada vez que se selecciona/deselecciona un cliente
        rowsMarcas.Clear()
    End Sub

    Private Sub grdMarc_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdMarc.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub grdMarc_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        'realiza un contador de filas arrojadas
        If e.Column.FieldName = "#" AndAlso e.IsGetData Then
            e.Value = grdMarc.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub


    Public Sub estiloGrdFamiliaVentas()
        'Adecuar ancho del indicador de renglón en el grid
        grdFamVe.IndicatorWidth = 40
        'muestra la columna de checkbox
        grdFamVe.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        AddHandler grdFamVe.SelectionChanged, AddressOf gridFamVen_SelectionChanged
        grdFamVe.OptionsSelection.MultiSelect = True
        'tamaño de la columna 
        grdFamVe.OptionsSelection.CheckBoxSelectorColumnWidth = 25

        'sirve para estilo de auto acomodo de tamaño de columnas
        grdFamVe.OptionsView.ColumnAutoWidth = False
        grdFamVe.OptionsView.BestFitMaxRowCount = -1
        grdFamVe.BestFitColumns()

        'habilita si se van a editar o no los valores de la columna con el nombre que tiene        
        grdFamVe.Columns("Familia de Ventas").OptionsColumn.AllowEdit = False

        grdFamVe.Columns("Familia de Ventas").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdFamVe.Columns("idFamilia").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains


        ' acomodo los header de las columnas de forma centrada
        grdFamVe.Columns("Familia de Ventas").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdFamVe.Columns("idFamilia").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        'grdMarc.Columns("Clientes").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

        'oculto el idFamilia
        grdFamVe.Columns("idFamilia").Visible = False

        grdFamVe.Columns("Familia de Ventas").Width = 160
        For i As Integer = 1 To grdRut.RowCount - 1
            If i Mod 2 = 0 Then
                'GridView1.OptionsView.EnableAppearanceOddRow = Color.LightSteelBlue
                grdFamVe.Appearance.EvenRow.BackColor = Color.LightSteelBlue
                grdFamVe.OptionsView.EnableAppearanceEvenRow = True
                grdFamVe.Invalidate()
            End If
        Next
    End Sub
    Private Sub gridFamVen_SelectionChanged(ByVal sender As Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs)
        'sirve para tomar el número de clientes seleccionados
        For I = 0 To grdFamVe.SelectedRowsCount() - 1
            If (grdFamVe.GetSelectedRows()(I) >= 0) Then
                rowsFamVentas.Add(grdFamVe.GetDataRow(grdFamVe.GetSelectedRows()(I)))
                'MsgBox("Familia " + grdFamVe.GetSelectedRows()(I).ToString)
            End If
        Next
        'estalbezco en el label el número de clientes que se han seleccionado
        'lblRegistros.Text = Rows.Count.ToString
        'limpio el arreglo ya que se ejecuta cada vez que se presiona y si no se limpia genera mas registros,
        'se tiene que estar limpiando cada que se selecciona un cliente. al final hace un conteo de los que están
        'seleccionados no importa que se esté limpiando cada vez que se selecciona/deselecciona un cliente
        rowsFamVentas.Clear()
    End Sub

    Private Sub grdFamVen_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdFamVe.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub grdFamVen_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        'realiza un contador de filas arrojadas
        If e.Column.FieldName = "#" AndAlso e.IsGetData Then
            e.Value = grdFamVe.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Public Sub estiloGrdAgenteAsignado()
        'Adecuar ancho del indicador de renglón en el grid
        grdAgenAsign.IndicatorWidth = 40
        'muestra la columna de checkbox
        grdAgenAsign.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        AddHandler grdAgenAsign.SelectionChanged, AddressOf gridAgenAsig_SelectionChanged
        grdAgenAsign.OptionsSelection.MultiSelect = True
        'tamaño de la columna 
        grdAgenAsign.OptionsSelection.CheckBoxSelectorColumnWidth = 25

        'sirve para estilo de auto acomodo de tamaño de columnas
        'grdAgenAsign.OptionsView.ColumnAutoWidth = False
        'grdAgenAsign.OptionsView.BestFitMaxRowCount = -1
        'grdAgenAsign.BestFitColumns()

        grdAgenAsign.Columns("AgenteActual").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdAgenAsign.Columns("Clientes").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

        'habilita si se van a editar o no los valores de la columna con el nombre que tiene        
        grdAgenAsign.Columns("AgenteActual").OptionsColumn.AllowEdit = False
        grdAgenAsign.Columns("Clientes").OptionsColumn.AllowEdit = False

        ' acomodo los header de las columnas de forma centrada
        grdAgenAsign.Columns("AgenteActual").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdAgenAsign.Columns("Clientes").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center

        'oculto la columna idAgente
        grdAgenAsign.Columns("idAgente").Visible = False

        'establezco valor de tamaño acolumna clientes
        grdAgenAsign.Columns("AgenteActual").Width = 320
        grdAgenAsign.Columns("Clientes").Width = 130

        'para el color de fondo alternado
        For i As Integer = 1 To grdAgenAsign.RowCount - 1
            If i Mod 2 = 0 Then
                'GridView1.OptionsView.EnableAppearanceOddRow = Color.LightSteelBlue
                grdAgenAsign.Appearance.EvenRow.BackColor = Color.LightSteelBlue
                grdAgenAsign.OptionsView.EnableAppearanceEvenRow = True
                grdAgenAsign.Invalidate()
            End If
        Next
    End Sub
    Private Sub gridAgenAsig_SelectionChanged(ByVal sender As Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs)
        'sirve para tomar el número de clientes seleccionados
        For I = 0 To grdAgenAsign.SelectedRowsCount() - 1
            If (grdAgenAsign.GetSelectedRows()(I) >= 0) Then
                rowsAgenteAsignado.Add(grdAgenAsign.GetDataRow(grdAgenAsign.GetSelectedRows()(I)))
            End If
        Next
        'estalbezco en el label el número de clientes que se han seleccionado
        'lblRegistros.Text = Rows.Count.ToString
        'limpio el arreglo ya que se ejecuta cada vez que se presiona y si no se limpia genera mas registros,
        'se tiene que estar limpiando cada que se selecciona un cliente. al final hace un conteo de los que están
        'seleccionados no importa que se esté limpiando cada vez que se selecciona/deselecciona un cliente
        rowsAgenteAsignado.Clear()
    End Sub

    Private Sub gridAgenAsig_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdAgenAsign.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub gridAgenAsig_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        'realiza un contador de filas arrojadas
        If e.Column.FieldName = "#" AndAlso e.IsGetData Then
            e.Value = grdAgenAsign.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub


    Public Sub estiloGrdPrincipal()
        'Adecuar ancho del indicador de renglón en el grid
        grdPr.IndicatorWidth = 40
        'muestra la columna de checkbox
        grdPr.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        AddHandler grdPr.SelectionChanged, AddressOf gridPrincipal_SelectionChanged
        grdPr.OptionsSelection.MultiSelect = True
        'tamaño de la columna 
        grdPr.OptionsSelection.CheckBoxSelectorColumnWidth = 25

        ''sirve para estilo de auto acomodo de tamaño de columnas
        'grdPr.OptionsView.ColumnAutoWidth = False
        'grdPr.OptionsView.BestFitMaxRowCount = -1
        'grdPr.BestFitColumns()

        'grdPr.Columns("AgenteActual").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        'grdPr.Columns("Clientes").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

        'habilita si se van a editar o no los valores de la columna con el nombre que tiene        
        grdPr.Columns("IDSAY").OptionsColumn.AllowEdit = False
        grdPr.Columns("IDSICY").OptionsColumn.AllowEdit = False
        grdPr.Columns("Cliente").OptionsColumn.AllowEdit = False

        grdPr.Columns("Ruta").OptionsColumn.AllowEdit = False
        grdPr.Columns("Marca").OptionsColumn.AllowEdit = False
        grdPr.Columns("Tipo").OptionsColumn.AllowEdit = False
        grdPr.Columns("Modificó").OptionsColumn.AllowEdit = False
        grdPr.Columns("FModificación").OptionsColumn.AllowEdit = False

        'anchos definidos de las columnas  
        grdPr.Columns.ColumnByFieldName("IDSAY").Width = 28
        grdPr.Columns.ColumnByFieldName("IDSICY").Width = 29
        grdPr.Columns.ColumnByFieldName("Cliente").Width = 203

        grdPr.Columns.ColumnByFieldName("Tipo").Width = 35
        grdPr.Columns.ColumnByFieldName("Ruta").Width = 80
        grdPr.Columns.ColumnByFieldName("Marca").Width = 55
        grdPr.Columns.ColumnByFieldName("Modificó").Width = 50
        grdPr.Columns.ColumnByFieldName("FModificación").Width = 80

        If rdoAgenteVentas.Checked = True Then
            ' grdPr.Columns("idMarca").Visible = False
            ' grdPr.Columns("idFamilia").Visible = False
            grdPr.Columns.ColumnByFieldName("Coordinador").Visible = True
            grdPr.Columns("Coordinador").OptionsColumn.AllowEdit = False
            grdPr.Columns.ColumnByFieldName("Coordinador").Width = 203
            grdPr.Columns("Coordinador").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
            grdPr.Columns("Coordinador").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center

            grdPr.Columns("Familia de Ventas").OptionsColumn.AllowEdit = False
            grdPr.Columns("Agente de Ventas").OptionsColumn.AllowEdit = False

            grdPr.Columns.ColumnByFieldName("Familia de Ventas").Width = 120
            grdPr.Columns.ColumnByFieldName("Agente de Ventas").Width = 190

            'oculto los idMarca e idFamilia
            grdPr.Columns.ColumnByFieldName("idFamilia").Visible = False
            grdPr.Columns.ColumnByFieldName("idMarca").Visible = False

            'se da el formato para que muestre fecha con hora en la columna
            grdPr.Columns.ColumnByFieldName("FModificación").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt"

            'es para que haga las busquedas en la columna por todo lo que contiene
            grdPr.Columns("Familia de Ventas").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

            grdPr.Columns("Familia de Ventas").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        End If
        If rdoAgenteComision.Checked = True Then
            'grdPr.Columns.ColumnByFieldName("Coordinador").Visible = False

            grdPr.Columns("Agente de Comisión").OptionsColumn.AllowEdit = False
            grdPr.Columns("Agente de Ventas").OptionsColumn.AllowEdit = False
            grdPr.Columns.ColumnByFieldName("Agente de Comisión").Width = 170
            grdPr.Columns.ColumnByFieldName("Agente de Ventas").Width = 170
            grdPr.Columns.ColumnByFieldName("Modificó").Width = 50
            grdPr.Columns.ColumnByFieldName("FModificación").Width = 105

            'oculto los idRuta, idMarca, agenteVentas y AgenteComision
            grdPr.Columns.ColumnByFieldName("idRuta").Visible = False
            grdPr.Columns.ColumnByFieldName("idMarca").Visible = False
            grdPr.Columns.ColumnByFieldName("idAgenteVentas").Visible = False
            grdPr.Columns.ColumnByFieldName("idAgenteComision").Visible = False
            'se da el formato para que muestre fecha con hora en la columna
            grdPr.Columns.ColumnByFieldName("FModificación").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt"

            'es para que haga las busquedas en la columna por todo lo que contiene
            grdPr.Columns("Agente de Comisión").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

            grdPr.Columns("Agente de Comisión").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center

        End If


        'es para que haga las busquedas en la columna por todo lo que contiene
        grdPr.Columns("IDSAY").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdPr.Columns("IDSICY").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdPr.Columns("Cliente").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

        grdPr.Columns("Tipo").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdPr.Columns("Ruta").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdPr.Columns("Marca").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdPr.Columns("Agente de Ventas").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdPr.Columns("FModificación").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdPr.Columns("Modificó").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

        ' acomodo los header de las columnas de forma centrada
        grdPr.Columns("IDSAY").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdPr.Columns("IDSICY").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdPr.Columns("Cliente").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center

        grdPr.Columns("Tipo").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdPr.Columns("Ruta").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdPr.Columns("Marca").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdPr.Columns("Agente de Ventas").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdPr.Columns("FModificación").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdPr.Columns("Modificó").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center

        'alineo al centro el contenido de las filas
        grdPr.Columns("Tipo").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
        For i As Integer = 1 To grdRut.RowCount - 1
            If i Mod 2 = 0 Then
                'GridView1.OptionsView.EnableAppearanceOddRow = Color.LightSteelBlue
                grdPr.Appearance.EvenRow.BackColor = Color.LightSteelBlue
                grdPr.OptionsView.EnableAppearanceEvenRow = True
                grdLista.Invalidate()
            End If
        Next
    End Sub

    Private Sub gridPrincipal_SelectionChanged(ByVal sender As Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        'sirve para tomar el número de clientes seleccionados
        For I = 0 To grdPr.SelectedRowsCount() - 1
            If (grdPr.GetSelectedRows()(I) >= 0) Then
                rowsPrincipal.Add(grdPr.GetDataRow(grdPr.GetSelectedRows()(I)))
                ' MsgBox("Agente " + grdPr.GetSelectedRows()(I).ToString)
            End If
        Next
        'estalbezco en el label el número de clientes que se han seleccionado
        lblNumeroRegistros.Text = rowsPrincipal.Count.ToString
        'limpio el arreglo ya que se ejecuta cada vez que se presiona y si no se limpia genera mas registros,
        'se tiene que estar limpiando cada que se selecciona un cliente. al final hace un conteo de los que están
        'seleccionados no importa que se esté limpiando cada vez que se selecciona/deselecciona un cliente
        rowsPrincipal.Clear()
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub gridPrincipal_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdPr.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub gridPrincipal_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        'realiza un contador de filas arrojadas
        If e.Column.FieldName = "#" AndAlso e.IsGetData Then
            e.Value = grdPr.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        recargaDatosMostrarGuardar()

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        Me.Cursor = Cursors.WaitCursor
        llenarDatosInicio()
        estiloGrdRutas()
        estiloGrdMarcas()
        estiloGrdFamiliaVentas()
        estiloGrdAgenteAsignado()

        rdoAgenteComision.Checked = False
        rdoAgenteVentas.Checked = True
        grdLista.DataSource = DBNull.Value

        grdPr.Columns.Clear()
        lblNumeroRegistros.Text = 0
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim strCadenasIds As String = String.Empty
        'asd
        'valido que esté un radio seleccionado
        'radio de agente ventas
        If rdoAgenteVentas.Checked = True Then
            'valido que los datos que selecciona sean de mostrar agente ventas
            If tipoAgenteTabla = "ventas" Then
                If cboxAgenteVentas.SelectedIndex > 0 Then
                    'valida que haya datos mostrados en el grid principal
                    If grdPr.RowCount > 0 Then
                        'valida que se hayan seleccionado registros de la tabla principal
                        If grdPr.SelectedRowsCount > 0 Then
                            'limpio el arreglo ya que va generando un contador 
                            rowsPrincipal.Clear()
                            'añado los valores al arreglo para poder leerlos de 1 por 1
                            Me.Cursor = Cursors.WaitCursor
                            For I = 0 To grdPr.SelectedRowsCount() - 1
                                If (grdPr.GetSelectedRows()(I) >= 0) Then
                                    rowsPrincipal.Add(grdPr.GetDataRow(grdPr.GetSelectedRows()(I)))
                                End If
                            Next

                            'mensaje de confirmación para guardar valores cambiados
                            Dim objMsjConfirmar As New Tools.confirmarFormGrande
                            Dim cadenaMensaje As String = "¿Está seguro de asignar el Agente de Ventas " + cboxAgenteVentas.Text.ToString + "  a los " + rowsPrincipal.Count.ToString + " registros seleccionados? (Esta actualización se realizará tanto en SAY como en SICY, una vez realizada esta acción, no se podrá revertir)."
                            objMsjConfirmar.mensaje = cadenaMensaje

                            'valido que el mensaje de confirmación sea SI
                            If objMsjConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                                Me.Cursor = Cursors.WaitCursor

                                For x = 0 To rowsPrincipal.Count - 1
                                    Dim Row As DataRow = CType(rowsPrincipal(x), DataRow)
                                    objActualizaAgenteVentas.actualizaAgenteVentas(cboxAgenteVentas.SelectedValue, Row("IDSAY"), Row("IDSICY"), Row("idMarca"), Row("idFamilia"), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, cbxCoordinador.SelectedValue)

                                    objActualizaAgenteComision.quitaAgenteComision(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Row("IDSAY"), Row("idMarca"), cboxAgenteVentas.SelectedValue)
                                    strCadenasIds &= "(" & Row("IDSICY").ToString & "),"
                                Next
                                strCadenasIds = strCadenasIds.TrimEnd(",")
                                'se ejecuta al final de actualizar todo para no ejecutarlo cada que se modifica un registro
                                objreplicacionesClienteMarcaFamiliaProyeccionAgente_ClienteMarcaAgenteEmpresa_SAY_SICY.replicacionesClienteMarcaFamiliaProyeccionAgente_ClienteMarcaAgenteEmpresa_SAY_SICY(Entidades.SesionUsuario.UsuarioSesion.PUserUsername)
                                objreplicacionesClienteMarcaFamiliaProyeccionAgente_ClienteMarcaAgenteEmpresa_SAY_SICY.ActualizaColeccionMarcaFamiliaCadenaAgente(strCadenasIds)
                                'objreplicacionesClienteMarcaFamiliaProyeccionAgente_ClienteMarcaAgenteEmpresa_SAY_SICY.ActualizarAgentesProyeccionMarcaFamiliaCliente()
                                objActualizaProspecta.actualizaProspecta()
                                objPrincipal.ActualizarAgentesProyeccionMarcaFamiliaCliente()
                                Me.Cursor = Cursors.Default

                                Dim objMensajeGuardar As New Tools.ExitoForm
                                objMensajeGuardar.mensaje = "Se actualizaron los datos exitosamente."
                                objMensajeGuardar.ShowDialog()
                                lblNumeroRegistros.Text = 0

                                'recargo los datos una vez que se hicieron los cambios
                                recargaDatosMostrarGuardar()
                            End If


                        Else
                            Dim objMensaje As New Tools.AdvertenciaForm
                            objMensaje.mensaje = "No se han seleccionado clientes."
                            objMensaje.ShowDialog()
                        End If
                    Else
                        Dim objMensaje As New Tools.AdvertenciaForm
                        objMensaje.mensaje = "No hay clientes en la tabla para seleccionar."
                        objMensaje.ShowDialog()
                    End If

                Else
                    Dim objMensaje As New Tools.AdvertenciaForm
                    objMensaje.mensaje = "No se ha seleccionado ningún agente de ventas."
                    objMensaje.ShowDialog()
                End If

            Else
                Dim objMensaje As New Tools.AdvertenciaForm
                objMensaje.mensaje = "Debes mostrar y seleccionar la información referente a agentes de ventas."
                objMensaje.ShowDialog()
            End If

            'radio de agente comisión
        ElseIf rdoAgenteComision.Checked = True Then
            If tipoAgenteTabla = "comision" Then
                'se valida que haya algún agente de comisión seleccionado
                If cboxAgenteComision.SelectedIndex > 0 Then
                    'valida que haya datos mostrados en el grid principal
                    If grdPr.RowCount > 0 Then
                        'valida que se hayan seleccionado registros de la tabla principal
                        If grdPr.SelectedRowsCount > 0 Then
                            'limpio el arreglo ya que va generando un contador 
                            rowsPrincipal.Clear()
                            'añado los valores al arreglo para poder leerlos de 1 por 1


                            For I = 0 To grdPr.SelectedRowsCount() - 1
                                If (grdPr.GetSelectedRows()(I) >= 0) Then
                                    rowsPrincipal.Add(grdPr.GetDataRow(grdPr.GetSelectedRows()(I)))
                                End If
                            Next

                            'mensaje de confirmación para guardar valores cambiados
                            Dim objMsjConfirmar As New Tools.confirmarFormGrande
                            Dim cadenaMensaje As String = "¿Está seguro de asignar el Agente de Comisión " + cboxAgenteComision.Text.ToString + "  a los " + rowsPrincipal.Count.ToString + " registros seleccionados? (Esta actualización se realizará tanto en SAY como en SICY, una vez realizada esta acción, no se podrá revertir)."
                            objMsjConfirmar.mensaje = cadenaMensaje

                            'valido que el mensaje de confirmación sea SI
                            If objMsjConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                                Me.Cursor = Cursors.WaitCursor

                                'AQUÍ VA EL PROCESO 
                                For x = 0 To rowsPrincipal.Count - 1
                                    Dim Row As DataRow = CType(rowsPrincipal(x), DataRow)

                                    'idMarcaSAY, idClienteSAY, idAgenteComisionSAY, usuarioModifica
                                    'MsgBox("idMarca " + Row("idMarca").ToString + " IDSAY " + Row("IDSAY").ToString + " agenteComision " + cboxAgenteComision.SelectedValue.ToString + " usuario " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString)                              
                                    objActualizaAgenteComision.actualizaAgenteComision(Row("idMarca"), Row("IDSAY"), Row("IDSICY"), cboxAgenteComision.SelectedValue, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Row("idAgenteVentas"))
                                Next

                                Me.Cursor = Cursors.Default

                                Dim objMensajeGuardar As New Tools.ExitoForm
                                objMensajeGuardar.mensaje = "Se actualizaron los datos exitosamente."
                                objMensajeGuardar.ShowDialog()
                                lblNumeroRegistros.Text = 0

                                'recargo los datos una vez que se hicieron los cambios
                                recargaDatosMostrarGuardar()

                            End If

                        Else
                            Dim objMensaje As New Tools.AdvertenciaForm
                            objMensaje.mensaje = "No se han seleccionado clientes."
                            objMensaje.ShowDialog()
                        End If
                    Else
                        Dim objMensaje As New Tools.AdvertenciaForm
                        objMensaje.mensaje = "No hay clientes en la tabla para seleccionar."
                        objMensaje.ShowDialog()
                    End If
                Else
                    'Dim objMensaje As New Tools.AdvertenciaForm
                    'objMensaje.mensaje = "No se ha seleccionado ningún agente de comisión."
                    'objMensaje.ShowDialog()
                    For I = 0 To grdPr.SelectedRowsCount() - 1
                        If (grdPr.GetSelectedRows()(I) >= 0) Then
                            rowsPrincipal.Add(grdPr.GetDataRow(grdPr.GetSelectedRows()(I)))
                        End If
                    Next

                    'mensaje de confirmación para guardar valores cambiados
                    Dim objMsjConfirmar As New Tools.confirmarFormGrande
                    Dim cadenaMensaje As String = "¿Está seguro de No asignar a Ningún Agente de Comisión a los " + rowsPrincipal.Count.ToString + " registros seleccionados? (Esta actualización se realizará tanto en SAY como en SICY, una vez realizada esta acción, no se podrá revertir)."
                    objMsjConfirmar.mensaje = cadenaMensaje
                    cboxAgenteComision.SelectedValue = 0
                    'valido que el mensaje de confirmación sea SI
                    If objMsjConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor

                        'AQUÍ VA EL PROCESO 
                        For x = 0 To rowsPrincipal.Count - 1
                            Dim Row As DataRow = CType(rowsPrincipal(x), DataRow)

                            'idMarcaSAY, idClienteSAY, idAgenteComisionSAY, usuarioModifica
                            'MsgBox("idMarca " + Row("idMarca").ToString + " IDSAY " + Row("IDSAY").ToString + " agenteComision " + cboxAgenteComision.SelectedValue.ToString + " usuario " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString)                              
                            objActualizaAgenteComision.actualizaAgenteComision(Row("idMarca"), Row("IDSAY"), Row("IDSICY"), cboxAgenteComision.SelectedValue, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Row("idAgenteVentas"))
                        Next

                        Me.Cursor = Cursors.Default

                        Dim objMensajeGuardar As New Tools.ExitoForm
                        objMensajeGuardar.mensaje = "Se actualizaron los datos exitosamente."
                        objMensajeGuardar.ShowDialog()
                        lblNumeroRegistros.Text = 0

                        'recargo los datos una vez que se hicieron los cambios
                        recargaDatosMostrarGuardar()

                    End If

                End If
            Else
                Dim objMensaje As New Tools.AdvertenciaForm
                objMensaje.mensaje = "Debes mostrar y seleccionar la información referente a agentes de comisión."
                objMensaje.ShowDialog()
            End If
        Else
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "No se ha seleccionado ningún agente."
            objMensaje.ShowDialog()
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()

    End Sub


    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If grdPr.DataRowCount - 1 > 0 Then
            Dim filename As String
            Dim DataGrid As DevExpress.XtraGrid.GridControl = grdLista

            'Ask the user where to save the file to
            Dim SaveFileDialog As New SaveFileDialog()
            SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
            SaveFileDialog.FilterIndex = 2
            SaveFileDialog.RestoreDirectory = True
            If SaveFileDialog.ShowDialog() = DialogResult.OK Then

                'This is required so that excel doesn't make all the grids very small. This will export all grids space out evenly
                grdPr.OptionsPrint.AutoWidth = True
                grdPr.OptionsPrint.EnableAppearanceEvenRow = True
                grdPr.OptionsPrint.PrintPreview = True
                'Set the selected file as the filename
                filename = SaveFileDialog.FileName

                Dim exportOptions = New XlsxExportOptionsEx()
                AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                'Export the file via inbuild function
                DevExpress.Export.ExportSettings.DefaultExportType = ExportType.WYSIWYG
                grdPr.ExportToXlsx(filename, exportOptions)
                'DataGrid.ExportToXlsx(filename, exportOptions)

                'If the file exists (i.e. export worked), then open it
                If System.IO.File.Exists(filename) Then
                    Dim DialogResult As DialogResult = MessageBox.Show("El archivo ha sido exportado a " & filename & vbNewLine & "¿Quieres abrirlo ahora?", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If DialogResult = Windows.Forms.DialogResult.Yes Then
                        System.Diagnostics.Process.Start(filename)
                    End If
                End If
            End If
        Else
            Dim objMensaje As New Tools.AvisoForm
            objMensaje.mensaje = "Para exportar información, es necesario mostrar datos en la tabla."
            objMensaje.ShowDialog()
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros.Visible = False
        grdLista.Dock = DockStyle.Fill
        'grdLista.Width = 1357
        'grdLista.Height = 542
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros.Visible = True
        grdLista.Dock = DockStyle.None
        grdLista.Width = 1346
        grdLista.Height = 297

    End Sub

    Private Sub rdoAgenteVentas_CheckedChanged(sender As Object, e As EventArgs) Handles rdoAgenteVentas.CheckedChanged
        If rdoAgenteVentas.Checked = True Then
            grdRutas.Enabled = True
            grdMarcas.Enabled = True
            grdFamiliasVenta.Enabled = True
            grdAgenteAsignado.Enabled = True

        End If
    End Sub

    Private Sub rdoAgenteComision_CheckedChanged(sender As Object, e As EventArgs) Handles rdoAgenteComision.CheckedChanged
        If rdoAgenteComision.Checked = True Then
            dtGrdFamVentas = objMarcas.verFamiliaVentas()
            grdFamiliasVenta.DataSource = dtGrdFamVentas
            grdFamiliasVenta.Enabled = False
            grdRutas.Enabled = True
            grdMarcas.Enabled = True
            grdAgenteAsignado.Enabled = True

        End If
    End Sub
End Class