Imports Programacion.Negocios
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraPrinting

Imports Infragistics.Win.UltraWinGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Layout.Events
Imports DevExpress.XtraGrid.Views.Layout
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Export
Imports DevExpress.XtraEditors
Imports DevExpress.Data.Filtering
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports Tools
Imports Entidades

Public Class FechaEntregaPrefGen
    Private Listo As Boolean = False
    Dim rowsClientesPreferentesSinFechaEspecial As New ArrayList()
    Dim rowsClientesPreferentesConFechaEspecial As New ArrayList()
    Dim rowsClientesGeneralConFechaEspecial As New ArrayList()
    Dim rowsClientesGeneralSinFechaEspecial As New ArrayList()
    Dim registrosRojo As Int16 = 0
    Dim registrosRojoInsertadoActualizados As Boolean = False

    Public banderaPreferentesADerecha As Integer
    Public banderaPreferentesAIzquierda As Integer
    Public banderaGeneralesADerecha As Integer
    Public banderaGeneralesAIzquierda As Integer

    Private filasModificadasPreferenteConFecha As New List(Of GridCell)()
    Private filasModificadasGeneralesConFecha As New List(Of GridCell)()

    Private numFilasGridPreferenteConFecha As Int32
    Private numFilasGridPreferenteSinFecha As Int32
    Private numFilasGridGeneralesConFecha As Int32
    Private numFilasGridGeneralesSinFecha As Int32

    Private Sub FechaEntregaPrefGen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Top = 0
        Me.Left = 0
        CargarOpcion()

        MaximizeBox = True
        MinimizeBox = False

        Me.WindowState = FormWindowState.Maximized

        nudAño.Minimum = Now.Year
        nudAño.Maximum = nudAño.Minimum + 1
        Listo = True

        Semana()

        dtPickerPreferente.MinDate = Today.ToShortDateString
        dtePickerGenerales.MinDate = Today.ToShortDateString
        dtpEditarFechaEntregaPreferente.MinDate = Today.ToShortDateString
        dtpEditarFechaEntregaGeneral.MinDate = Today.ToShortDateString

        cargarDatosGrids()
        mensaje()

    End Sub

    Private Sub mensaje()
        'valido si existen registros en rojo
        If registrosRojo > 0 Then
            Dim objMensajeGuardar As New Tools.AdvertenciaForm
            objMensajeGuardar.mensaje = "Existen fechas de entrega de colecciones nuevas anteriores a la fecha de entrega general, en el listado de colecciones están identificadas con color rojo."
            objMensajeGuardar.ShowDialog()
            registrosRojo = 0
        ElseIf registrosRojoInsertadoActualizados = True Then
            Dim objMensajeGuardar As New Tools.AdvertenciaForm
            objMensajeGuardar.mensaje = "Existen fechas de entrega de colecciones nuevas anteriores a la fecha de entrega general, en el listado de colecciones están identificadas con color rojo."
            objMensajeGuardar.ShowDialog()
        End If
    End Sub


    Private Sub cargarDatosGrids()
        Dim objBU As New Negocios.ClientesPrefGenBU
        Dim listaColeccionesPreferentesSinFechaEntregaEspecial As New DataTable
        Dim listaColeccionesPreferentesConFechaEntregaEspecial As New DataTable
        Dim listaColeccionesGeneralesSinFechaEntregaEspecial As New DataTable
        Dim listaColeccionesGeneralesConFechaEntregaEspecial As New DataTable

        listaColeccionesPreferentesSinFechaEntregaEspecial = objBU.verColeccionesPreferentesSinFechaEntregaEspecial()
        grdPreferentesSinFe.DataSource = listaColeccionesPreferentesSinFechaEntregaEspecial
        estiloGrdClientePreferenteSinFechaEspecial()

        listaColeccionesPreferentesConFechaEntregaEspecial = objBU.verColeccionesPreferentesConFechaEntregaEspecial
        grdPreferenteConFe.DataSource = listaColeccionesPreferentesConFechaEntregaEspecial
        estiloGrdClientePreferenteConFechaEspecial()

        listaColeccionesGeneralesSinFechaEntregaEspecial = objBU.verColeccionesGeneralesSinFechaEntregaEspecial()
        grdGeneralSinFe.DataSource = listaColeccionesGeneralesSinFechaEntregaEspecial
        estiloGrdClienteGeneralSinFechaEspecial()

        listaColeccionesGeneralesConFechaEntregaEspecial = objBU.verColeccionesGeneralesConFechaEntregaEspecial
        grdGeneralConFe.DataSource = listaColeccionesGeneralesConFechaEntregaEspecial
        estiloGrdClienteGeneralConFechaEspecial()

        numFilasGridPreferenteConFecha = listaColeccionesPreferentesConFechaEntregaEspecial.Rows.Count
        numFilasGridPreferenteSinFecha = listaColeccionesPreferentesSinFechaEntregaEspecial.Rows.Count

        numFilasGridGeneralesConFecha = listaColeccionesGeneralesConFechaEntregaEspecial.Rows.Count
        numFilasGridGeneralesSinFecha = listaColeccionesGeneralesSinFechaEntregaEspecial.Rows.Count


    End Sub


    Private Sub estiloGrdClientePreferenteSinFechaEspecial()

        'Adecuar ancho del indicador de renglón en el grid
        grdPreferentesSinFechaEspecial.IndicatorWidth = 40
        'muestra la columna de checkbox
        grdPreferentesSinFechaEspecial.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        AddHandler grdPreferentesSinFechaEspecial.SelectionChanged, AddressOf grdPreferentesSinFechaEspecial_SelectionChanged
        grdPreferentesSinFechaEspecial.OptionsSelection.MultiSelect = True
        'tamaño de la columna 
        grdPreferentesSinFechaEspecial.OptionsSelection.CheckBoxSelectorColumnWidth = 25

        'Para que haga la busqueda por lo que contiene
        grdPreferentesSinFechaEspecial.Columns("Marca").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdPreferentesSinFechaEspecial.Columns("Colección").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdPreferentesSinFechaEspecial.Columns("Temporada").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        'sirve para estilo de auto acomodo de tamaño de columnas

        'Doy ancho definido a las columnas
        grdPreferentesSinFechaEspecial.Columns("Marca").Width = 50
        grdPreferentesSinFechaEspecial.Columns("Colección").Width = 140
        grdPreferentesSinFechaEspecial.Columns("Temporada").Width = 80

        '¿acomoda el nombre de la columna centrado
        grdPreferentesSinFechaEspecial.Columns("Marca").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdPreferentesSinFechaEspecial.Columns("Colección").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdPreferentesSinFechaEspecial.Columns("Temporada").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center

        'habilita si se van a editar o no los valores de la columna con el nombre que tiene        
        grdPreferentesSinFechaEspecial.Columns("Marca").OptionsColumn.AllowEdit = False
        grdPreferentesSinFechaEspecial.Columns("Colección").OptionsColumn.AllowEdit = False
        grdPreferentesSinFechaEspecial.Columns("Temporada").OptionsColumn.AllowEdit = False

        'Esconde idColumnas
        grdPreferentesSinFechaEspecial.Columns("idMarca").Visible = False
        grdPreferentesSinFechaEspecial.Columns("idColeccion").Visible = False
        grdPreferentesSinFechaEspecial.Columns("idTemporada").Visible = False
        grdPreferentesSinFechaEspecial.Columns("idColeccionMarca").Visible = False

        'Pone el color de fondo salteado de color blacno y azul
        For i As Integer = 1 To grdPreferentesSinFechaEspecial.RowCount - 1
            If i Mod 2 = 0 Then
                'GridView1.OptionsView.EnableAppearanceOddRow = Color.LightSteelBlue
                grdPreferentesSinFechaEspecial.Appearance.EvenRow.BackColor = Color.LightSteelBlue
                grdPreferentesSinFechaEspecial.OptionsView.EnableAppearanceEvenRow = True
                grdPreferentesSinFechaEspecial.Invalidate()
            End If
        Next

    End Sub



    Private Sub grdPreferentesSinFechaEspecial_SelectionChanged(ByVal sender As Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        'sirve para tomar el número de clientes seleccionados
        For I = 0 To grdPreferentesSinFechaEspecial.SelectedRowsCount() - 1
            If (grdPreferentesSinFechaEspecial.GetSelectedRows()(I) >= 0) Then
                rowsClientesPreferentesSinFechaEspecial.Add(grdPreferentesSinFechaEspecial.GetDataRow(grdPreferentesSinFechaEspecial.GetSelectedRows()(I)))
                ' MsgBox("Agente " + grdPr.GetSelectedRows()(I).ToString)
            End If
        Next
        'estalbezco en el label el número de clientes que se han seleccionado
        lblTotalSeleccionados.Text = rowsClientesPreferentesSinFechaEspecial.Count.ToString
        'limpio el arreglo ya que se ejecuta cada vez que se presiona y si no se limpia genera mas registros,
        'se tiene que estar limpiando cada que se selecciona un cliente. al final hace un conteo de los que están
        'seleccionados no importa que se esté limpiando cada vez que se selecciona/deselecciona un cliente
        rowsClientesPreferentesSinFechaEspecial.Clear()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub grdPreferentesSinFechaEspecial_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdPreferentesSinFechaEspecial.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub estiloGrdClientePreferenteConFechaEspecial()

        'Adecuar ancho del indicador de renglón en el grid
        grdPreferenteConFeEspecial.IndicatorWidth = 40
        'muestra la columna de checkbox
        grdPreferenteConFeEspecial.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        AddHandler grdPreferenteConFeEspecial.SelectionChanged, AddressOf grdPreferenteConFeEspecial_SelectionChanged
        grdPreferenteConFeEspecial.OptionsSelection.MultiSelect = True
        'tamaño de la columna 
        grdPreferenteConFeEspecial.OptionsSelection.CheckBoxSelectorColumnWidth = 25

        'AddHandler grdPreferenteConFeEspecial.CustomUnboundColumnData, AddressOf grdPreferenteConFeEspecial_CustomUnboundColumnData

        'Para que haga la busqueda por lo que contiene
        grdPreferenteConFeEspecial.Columns("Marca").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdPreferenteConFeEspecial.Columns("Colección").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdPreferenteConFeEspecial.Columns("Temporada").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdPreferenteConFeEspecial.Columns("*FEntrega").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

        'Doy ancho definido a las columnas
        grdPreferenteConFeEspecial.Columns("Marca").Width = 50
        grdPreferenteConFeEspecial.Columns("Colección").Width = 140
        grdPreferenteConFeEspecial.Columns("Temporada").Width = 80

        '¿acomoda el nombre de la columna centrado
        grdPreferenteConFeEspecial.Columns("Marca").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdPreferenteConFeEspecial.Columns("Colección").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdPreferenteConFeEspecial.Columns("Temporada").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdPreferenteConFeEspecial.Columns("*FEntrega").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center


        'habilita si se van a editar o no los valores de la columna con el nombre que tiene        
        grdPreferenteConFeEspecial.Columns("Marca").OptionsColumn.AllowEdit = False
        grdPreferenteConFeEspecial.Columns("Colección").OptionsColumn.AllowEdit = False
        grdPreferenteConFeEspecial.Columns("Temporada").OptionsColumn.AllowEdit = False

        'Esconde idColumnas
        grdPreferenteConFeEspecial.Columns("idMarca").Visible = False
        grdPreferenteConFeEspecial.Columns("idColeccion").Visible = False
        grdPreferenteConFeEspecial.Columns("idTemporada").Visible = False
        grdPreferenteConFeEspecial.Columns("idColeccionMarca").Visible = False

        'acomdo el texto en la parte derecha
        grdPreferenteConFeEspecial.Columns("*FEntrega").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far

        Dim edit As New RepositoryItemDateEdit
        edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
        edit.Mask.EditMask = "dd/MM/yyyy"
        edit.MinValue = Date.Now.ToShortDateString

        ' GridView1.Columns("P. Final Nuevo").ColumnEdit = edit.Mask.EditMask = "n2"
        'doy el nombre de columna que quiero que tenga dicha configuración
        grdPreferenteConFeEspecial.Columns("*FEntrega").ColumnEdit = edit


        For i As Integer = 1 To grdPreferenteConFeEspecial.RowCount - 1
            If i Mod 2 = 0 Then
                'GridView1.OptionsView.EnableAppearanceOddRow = Color.LightSteelBlue
                grdPreferenteConFeEspecial.Appearance.EvenRow.BackColor = Color.LightSteelBlue
                grdPreferenteConFeEspecial.OptionsView.EnableAppearanceEvenRow = True
                grdPreferenteConFeEspecial.Invalidate()
            End If
        Next

        ''hago un conteo de registros en rojo para mostrar alerta
        For i As Integer = 0 To grdPreferenteConFeEspecial.DataRowCount - 1
            If grdPreferenteConFeEspecial.GetRowCellValue(i, "*FEntrega") < dtpFechaEntrega.Value.ToShortDateString Then
                ' grdPreferenteConFeEspecial.Appearance.Row.ForeColor = Color.Red
                registrosRojo += 1

            End If
        Next

    End Sub


    Private Sub grdPreferenteConFeEspecial_SelectionChanged(ByVal sender As Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        'sirve para tomar el número de clientes seleccionados
        For I = 0 To grdPreferenteConFeEspecial.SelectedRowsCount() - 1
            If (grdPreferenteConFeEspecial.GetSelectedRows()(I) >= 0) Then
                rowsClientesPreferentesConFechaEspecial.Add(grdPreferenteConFeEspecial.GetDataRow(grdPreferenteConFeEspecial.GetSelectedRows()(I)))
                ' MsgBox("Agente " + grdPr.GetSelectedRows()(I).ToString)
            End If
        Next
        lblTotalSeleccionados.Text = rowsClientesPreferentesConFechaEspecial.Count.ToString
        rowsClientesPreferentesConFechaEspecial.Clear()
        Me.Cursor = Cursors.Default
    End Sub


    Private Function grdPreferenteConFecha_CellExists(ByVal sourceRowIndex As Integer) As Boolean
        Dim existingCell As GridCell = filasModificadasPreferenteConFecha.Where(Function(c) c.RowHandle = sourceRowIndex).FirstOrDefault()
        Return existingCell IsNot Nothing
    End Function


    Private Function grdGeneralesConFecha_CellExists(ByVal sourceRowIndex As Integer) As Boolean
        Dim existingCell As GridCell = filasModificadasGeneralesConFecha.Where(Function(c) c.RowHandle = sourceRowIndex).FirstOrDefault()
        Return existingCell IsNot Nothing
    End Function


    Private Sub grdPreferenteConFeEspecial_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdPreferenteConFeEspecial.CellValueChanged

        If e.RowHandle > -1 Then

            Dim View As GridView = sender

            Dim inSt As Date = CDate(View.GetRowCellValue(e.RowHandle, "*FEntrega"))

            If inSt < dtpFechaEntrega.Value.ToShortDateString Then
                registrosRojoInsertadoActualizados = True
            End If

            If (Not grdPreferenteConFecha_CellExists(grdPreferenteConFeEspecial.GetDataSourceRowIndex(e.RowHandle))) Then
                filasModificadasPreferenteConFecha.Add(New GridCell(grdPreferenteConFeEspecial.GetDataSourceRowIndex(e.RowHandle), e.Column))
                rowsClientesPreferentesConFechaEspecial.Add(grdPreferenteConFeEspecial.GetDataRow(e.RowHandle))
            End If

        Else
        End If

    End Sub

    Private Sub grdGeneralConFeEspecial_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdGeneralConFeEspecial.CellValueChanged

        If e.RowHandle > -1 Then

            Dim View As GridView = sender

            Dim inSt As Date = CDate(View.GetRowCellValue(e.RowHandle, "*FEntrega"))

            If inSt < dtpFechaEntrega.Value.ToShortDateString Then
                registrosRojoInsertadoActualizados = True
            End If

            If (Not grdGeneralesConFecha_CellExists(grdGeneralConFeEspecial.GetDataSourceRowIndex(e.RowHandle))) Then
                filasModificadasGeneralesConFecha.Add(New GridCell(grdGeneralConFeEspecial.GetDataSourceRowIndex(e.RowHandle), e.Column))

                rowsClientesGeneralConFechaEspecial.Add(grdGeneralConFeEspecial.GetDataRow(e.RowHandle))
            End If

        Else

        End If

    End Sub

    Private Sub grdPreferenteSinFeEspecial_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles grdPreferentesSinFechaEspecial.RowCellStyle

        If e.RowHandle >= numFilasGridPreferenteSinFecha Then
            e.Appearance.ForeColor = Color.Purple
        End If

    End Sub


    Private Sub grdPreferenteConFeEspecial_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles grdPreferenteConFeEspecial.RowCellStyle
        Try
            Dim View As GridView = sender

            Dim inSt As Date = CDate(View.GetRowCellValue(e.RowHandle, "*FEntrega"))



            If inSt < dtpFechaEntrega.Value.ToShortDateString And grdPreferenteConFecha_CellExists(grdPreferenteConFeEspecial.GetDataSourceRowIndex(e.RowHandle)) = False And e.RowHandle < numFilasGridPreferenteConFecha Then
                e.Appearance.ForeColor = Color.Red
            ElseIf grdPreferenteConFecha_CellExists(grdPreferenteConFeEspecial.GetDataSourceRowIndex(e.RowHandle)) = True Then
                e.Appearance.ForeColor = Color.Purple
            ElseIf e.RowHandle >= numFilasGridPreferenteConFecha Then
                e.Appearance.ForeColor = Color.Purple
            End If

        Catch ex As Exception

        End Try

    End Sub


    Private Sub grdGeneralSinFeEspecial_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles grdGeneralSinFeEspecial.RowCellStyle

        If e.RowHandle >= numFilasGridGeneralesSinFecha Then
            e.Appearance.ForeColor = Color.Purple
        End If

    End Sub


    Private Sub grdGeneralConFeEspecial_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles grdGeneralConFeEspecial.RowCellStyle

        Try
            Dim View As GridView = sender
            'defaultDraw

            Dim inSt As Date = CDate(View.GetRowCellValue(e.RowHandle, "*FEntrega"))

            If inSt < dtpFechaEntrega.Value.ToShortDateString And grdGeneralesConFecha_CellExists(grdGeneralConFeEspecial.GetDataSourceRowIndex(e.RowHandle)) = False And e.RowHandle < numFilasGridGeneralesConFecha Then
                e.Appearance.ForeColor = Color.Red
            ElseIf grdGeneralesConFecha_CellExists(grdGeneralConFeEspecial.GetDataSourceRowIndex(e.RowHandle)) = True Then
                e.Appearance.ForeColor = Color.Purple
            ElseIf e.RowHandle >= numFilasGridGeneralesConFecha Then
                'If inSt < dtpFechaEntrega.Value.ToShortDateString Or inSt > dtpFechaEntrega.Value.ToShortDateString Then
                '    e.Appearance.ForeColor = Color.Purple
                'End If
                e.Appearance.ForeColor = Color.Purple
            End If

            'If e.RowHandle = lastUpdatedRowHandle Then

            '    e.Appearance.ForeColor = Color.Purple


            '    ' grdPreferenteConFeEspecial.Appearance.HideSelectionRow.ForeColor = Color.Purple
            '    'ElseIf inSt < dtpFechaEntrega.Value.ToShortDateString And e.RowHandle <> lastUpdatedRowHandle Then
            '    '    e.Appearance.ForeColor = Color.Red
            'End If


            'If e.RowHandle = valorCambiado Then
            '    e.Appearance.ForeColor = Color.Purple
            'ElseIf inSt < dtpFechaEntrega.Value.ToShortDateString And e.RowHandle <> valorCambiado And nuevaFilaRowHandle <> grdPreferenteConFeEspecial.FocusedRowHandle Then
            '    e.Appearance.ForeColor = Color.Red
            'ElseIf nuevaFilaRowHandle = grdPreferenteConFeEspecial.FocusedRowHandle Then
            '    e.Appearance.ForeColor = Color.Yellow
            'End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub grdGeneralConFeEspecial_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grdGeneralConFeEspecial.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Try

            Dim inSt As Date = CDate(View.GetRowCellValue(e.RowHandle, "*FEntrega"))

            Dim fechaHoy As Date = Date.Now.ToShortDateString

        Catch ex As Exception
            Dim objMensajeGuardar As New Tools.AdvertenciaForm
            objMensajeGuardar.mensaje = "Valor invalido en la fecha."
            ' objMensajeGuardar.ShowDialog()
            e.Valid = False
        End Try

    End Sub


    Private Sub grdPreferenteConFeEspecial_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles grdPreferenteConFeEspecial.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Try

            Dim inSt As Date = CDate(View.GetRowCellValue(e.RowHandle, "*FEntrega"))

            Dim fechaHoy As Date = Date.Now.ToShortDateString

        Catch ex As Exception
            Dim objMensajeGuardar As New Tools.AdvertenciaForm
            objMensajeGuardar.mensaje = "Valor invalido en la fecha."
            ' objMensajeGuardar.ShowDialog()
            e.Valid = False
        End Try

    End Sub

    Private Sub grdPreferenteConFeEspecial_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles grdPreferenteConFeEspecial.RowUpdated

        ' valorCambiado = e.RowHandle
        'lastUpdatedRowHandle = e.RowHandle

        ' modifiedCells.Add(New GridCell(grdPreferenteConFeEspecial.GetDataSourceRowIndex(e.RowHandle), e.Column))
    End Sub

    Private Sub grdPreferenteConFeEspecial_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdPreferenteConFeEspecial.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub




    Private Sub estiloGrdClienteGeneralSinFechaEspecial()
        'Adecuar ancho del indicador de renglón en el grid
        grdGeneralSinFeEspecial.IndicatorWidth = 40
        'muestra la columna de checkbox
        grdGeneralSinFeEspecial.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        AddHandler grdGeneralSinFeEspecial.SelectionChanged, AddressOf grdGeneralSinFechaEspecial_SelectionChanged
        grdGeneralSinFeEspecial.OptionsSelection.MultiSelect = True
        'tamaño de la columna 
        grdGeneralSinFeEspecial.OptionsSelection.CheckBoxSelectorColumnWidth = 25

        'acomoda el nombre de la columna centrado
        grdGeneralSinFeEspecial.Columns("Marca").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdGeneralSinFeEspecial.Columns("Colección").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdGeneralSinFeEspecial.Columns("Temporada").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center

        'Para que haga la busqueda por lo que contiene
        grdGeneralSinFeEspecial.Columns("Marca").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdGeneralSinFeEspecial.Columns("Colección").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdGeneralSinFeEspecial.Columns("Temporada").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

        'Doy ancho definido a las columnas
        grdGeneralSinFeEspecial.Columns("Marca").Width = 50
        grdGeneralSinFeEspecial.Columns("Colección").Width = 140
        grdGeneralSinFeEspecial.Columns("Temporada").Width = 80

        'habilita si se van a editar o no los valores de la columna con el nombre que tiene        
        grdGeneralSinFeEspecial.Columns("Marca").OptionsColumn.AllowEdit = False
        grdGeneralSinFeEspecial.Columns("Colección").OptionsColumn.AllowEdit = False
        grdGeneralSinFeEspecial.Columns("Temporada").OptionsColumn.AllowEdit = False

        'Esconde idColumnas
        grdGeneralSinFeEspecial.Columns("idMarca").Visible = False
        grdGeneralSinFeEspecial.Columns("idColeccion").Visible = False
        grdGeneralSinFeEspecial.Columns("idTemporada").Visible = False
        grdGeneralSinFeEspecial.Columns("idColeccionMarca").Visible = False

        'Pone el color de fondo salteado de color blacno y azul
        For i As Integer = 1 To grdGeneralSinFeEspecial.RowCount - 1
            If i Mod 2 = 0 Then
                'GridView1.OptionsView.EnableAppearanceOddRow = Color.LightSteelBlue
                grdGeneralSinFeEspecial.Appearance.EvenRow.BackColor = Color.LightSteelBlue
                grdGeneralSinFeEspecial.OptionsView.EnableAppearanceEvenRow = True
                grdGeneralSinFeEspecial.Invalidate()
            End If
        Next
    End Sub

    Private Sub grdGeneralSinFechaEspecial_SelectionChanged(ByVal sender As Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        'sirve para tomar el número de clientes seleccionados
        For I = 0 To grdGeneralSinFeEspecial.SelectedRowsCount() - 1
            If (grdGeneralSinFeEspecial.GetSelectedRows()(I) >= 0) Then
                rowsClientesGeneralSinFechaEspecial.Add(grdGeneralSinFeEspecial.GetDataRow(grdGeneralSinFeEspecial.GetSelectedRows()(I)))
                ' MsgBox("Agente " + grdPr.GetSelectedRows()(I).ToString)
            End If
        Next
        'estalbezco en el label el número de clientes que se han seleccionado
        lblTotalSeleccionados.Text = rowsClientesGeneralSinFechaEspecial.Count.ToString
        'limpio el arreglo ya que se ejecuta cada vez que se presiona y si no se limpia genera mas registros,
        'se tiene que estar limpiando cada que se selecciona un cliente. al final hace un conteo de los que están
        'seleccionados no importa que se esté limpiando cada vez que se selecciona/deselecciona un cliente
        rowsClientesGeneralSinFechaEspecial.Clear()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub grdGeneralSinFeEspecial_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdGeneralSinFeEspecial.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub estiloGrdClienteGeneralConFechaEspecial()
        'Adecuar ancho del indicador de renglón en el grid
        grdGeneralConFeEspecial.IndicatorWidth = 40
        'muestra la columna de checkbox
        grdGeneralConFeEspecial.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        AddHandler grdGeneralConFeEspecial.SelectionChanged, AddressOf grdGeneralConFechaEspecial_SelectionChanged
        grdGeneralConFeEspecial.OptionsSelection.MultiSelect = True
        'tamaño de la columna 
        grdGeneralConFeEspecial.OptionsSelection.CheckBoxSelectorColumnWidth = 25

        'Para que haga la busqueda por lo que contiene
        grdGeneralConFeEspecial.Columns("Marca").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdGeneralConFeEspecial.Columns("Colección").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdGeneralConFeEspecial.Columns("Temporada").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdGeneralConFeEspecial.Columns("*FEntrega").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

        'Doy ancho definido a las columnas
        grdGeneralConFeEspecial.Columns("Marca").Width = 60
        grdGeneralConFeEspecial.Columns("Colección").Width = 190
        grdGeneralConFeEspecial.Columns("Temporada").Width = 110

        '¿acomoda el nombre de la columna centrado
        grdGeneralConFeEspecial.Columns("Marca").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdGeneralConFeEspecial.Columns("Colección").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdGeneralConFeEspecial.Columns("Temporada").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdGeneralConFeEspecial.Columns("*FEntrega").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center


        'habilita si se van a editar o no los valores de la columna con el nombre que tiene        
        grdGeneralConFeEspecial.Columns("Marca").OptionsColumn.AllowEdit = False
        grdGeneralConFeEspecial.Columns("Colección").OptionsColumn.AllowEdit = False
        grdGeneralConFeEspecial.Columns("Temporada").OptionsColumn.AllowEdit = False

        'Esconde idColumnas
        grdGeneralConFeEspecial.Columns("idMarca").Visible = False
        grdGeneralConFeEspecial.Columns("idColeccion").Visible = False
        grdGeneralConFeEspecial.Columns("idTemporada").Visible = False
        grdGeneralConFeEspecial.Columns("idColeccionMarca").Visible = False

        Dim edit As New RepositoryItemDateEdit
        edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
        edit.Mask.EditMask = "dd/MM/yyyy"
        edit.MinValue = Date.Now.ToShortDateString

        ' GridView1.Columns("P. Final Nuevo").ColumnEdit = edit.Mask.EditMask = "n2"
        'doy el nombre de columna que quiero que tenga dicha configuración
        grdGeneralConFeEspecial.Columns("*FEntrega").ColumnEdit = edit

        'acomdo el texto en la parte derecha
        grdGeneralConFeEspecial.Columns("*FEntrega").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far

        For i As Integer = 0 To grdGeneralConFeEspecial.DataRowCount - 1
            If grdGeneralConFeEspecial.GetRowCellValue(i, "*FEntrega") < dtpFechaEntrega.Value.ToShortDateString Then
                ' grdPreferenteConFeEspecial.Appearance.Row.ForeColor = Color.Red
                registrosRojo += 1

            End If
        Next


        For i As Integer = 1 To grdGeneralConFeEspecial.RowCount - 1
            If i Mod 2 = 0 Then
                'GridView1.OptionsView.EnableAppearanceOddRow = Color.LightSteelBlue
                grdGeneralConFeEspecial.Appearance.EvenRow.BackColor = Color.LightSteelBlue
                grdGeneralConFeEspecial.OptionsView.EnableAppearanceEvenRow = True
                grdGeneralConFeEspecial.Invalidate()
            End If
        Next

    End Sub

    Private Sub grdGeneralConFechaEspecial_SelectionChanged(ByVal sender As Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        'sirve para tomar el número de clientes seleccionados
        For I = 0 To grdGeneralConFeEspecial.SelectedRowsCount() - 1
            If (grdGeneralConFeEspecial.GetSelectedRows()(I) >= 0) Then
                rowsClientesGeneralConFechaEspecial.Add(grdGeneralConFeEspecial.GetDataRow(grdGeneralConFeEspecial.GetSelectedRows()(I)))
                ' MsgBox("Agente " + grdPr.GetSelectedRows()(I).ToString)
            End If
        Next
        'estalbezco en el label el número de clientes que se han seleccionado
        lblTotalSeleccionados.Text = rowsClientesGeneralConFechaEspecial.Count.ToString
        'limpio el arreglo ya que se ejecuta cada vez que se presiona y si no se limpia genera mas registros,
        'se tiene que estar limpiando cada que se selecciona un cliente. al final hace un conteo de los que están
        'seleccionados no importa que se esté limpiando cada vez que se selecciona/deselecciona un cliente
        rowsClientesGeneralConFechaEspecial.Clear()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub grdGeneralConFeEspecial_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdGeneralConFeEspecial.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub


    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click

        If tabFechaEntrega.SelectedTab Is tabPreferentes Then
            exportarDatos(grdPreferenteConFeEspecial, grdPreferentesSinFe)
        ElseIf tabFechaEntrega.SelectedTab Is tabGenerales Then
            exportarDatos(grdGeneralConFeEspecial, grdGeneralSinFe)
        End If

    End Sub

#Region "cambia datos pestaña preferentes"

    Private Sub btnPreferentesADerecha_Click(sender As Object, e As EventArgs) Handles btnPreferentesADerecha.Click
        If grdPreferentesSinFechaEspecial.SelectedRowsCount > 0 Then

            If dtPickerPreferente.Value.ToShortDateString >= Date.Today Then
                Me.Cursor = Cursors.WaitCursor
                For I = 0 To grdPreferentesSinFechaEspecial.SelectedRowsCount() - 1
                    If (grdPreferentesSinFechaEspecial.GetSelectedRows()(I) >= 0) Then
                        banderaPreferentesADerecha = I


                        grdPreferenteConFeEspecial.AddNewRow()

                        grdPreferenteConFe.RefreshDataSource()
                    End If
                Next

                grdPreferentesSinFechaEspecial.DeleteSelectedRows()

                btnPreferentesAIzquierda.Enabled = False

                Me.Cursor = Cursors.Default
            Else
                Dim objMensajeGuardar As New Tools.AdvertenciaForm
                objMensajeGuardar.mensaje = "La fecha de Entrega Clientes Preferentes debe ser mayor o igual a la de Fecha de " + Date.Today.ToShortDateString + "."
                objMensajeGuardar.ShowDialog()
            End If
        Else
            Dim objMensajeGuardar As New Tools.AdvertenciaForm
            objMensajeGuardar.mensaje = "No hay registros seleccionados."
            objMensajeGuardar.ShowDialog()
        End If
    End Sub

    Private Sub grdPreferenteConFeEspecialADerecha_InitNewRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles grdPreferenteConFeEspecial.InitNewRow
        Dim View As GridView
        View = sender


        Dim rowSelected As New ArrayList()

        For I = banderaPreferentesADerecha To grdPreferentesSinFechaEspecial.SelectedRowsCount() - 1
            If (grdPreferentesSinFechaEspecial.GetSelectedRows()(I) >= 0) Then

                rowSelected.Add(grdPreferentesSinFechaEspecial.GetDataRow(grdPreferentesSinFechaEspecial.GetSelectedRows()(banderaPreferentesADerecha)))
                'hier
            End If
        Next

        'clientesPreferentesConFechaEspecial
        For x = 0 To rowSelected.Count - 1

            Dim Row As DataRow = CType(rowSelected(x), DataRow)

            grdPreferenteConFeEspecial.SetRowCellValue(e.RowHandle, "idMarca", Row("idMarca"))
            grdPreferenteConFeEspecial.SetRowCellValue(e.RowHandle, "Marca", Row("Marca"))

            grdPreferenteConFeEspecial.SetRowCellValue(e.RowHandle, "idColeccion", Row("idColeccion"))
            grdPreferenteConFeEspecial.SetRowCellValue(e.RowHandle, "Colección", Row("Colección"))

            grdPreferenteConFeEspecial.SetRowCellValue(e.RowHandle, "idTemporada", Row("idTemporada"))
            grdPreferenteConFeEspecial.SetRowCellValue(e.RowHandle, "Temporada", Row("Temporada"))

            grdPreferenteConFeEspecial.SetRowCellValue(e.RowHandle, "idColeccionMarca", Row("idColeccionMarca"))

            grdPreferenteConFeEspecial.SetRowCellValue(e.RowHandle, "*FEntrega", dtPickerPreferente.Value.ToShortDateString)

            Dim inSt As Date = CDate(View.GetRowCellValue(e.RowHandle, "*FEntrega"))
            If inSt < dtpFechaEntrega.Value.ToShortDateString Then
                registrosRojoInsertadoActualizados = True
            End If

        Next
        'MsgBox(grdPreferentesSinFe.InvalidRowHandle.ToString)

        rowSelected.Clear()

    End Sub

    Private Sub btnPreferentesAIzquierda_Click(sender As Object, e As EventArgs) Handles btnPreferentesAIzquierda.Click

        If grdPreferenteConFeEspecial.SelectedRowsCount > 0 Then

            If dtPickerPreferente.Value.ToShortDateString >= Date.Today Then
                Me.Cursor = Cursors.WaitCursor
                For I = 0 To grdPreferenteConFeEspecial.SelectedRowsCount() - 1
                    If (grdPreferenteConFeEspecial.GetSelectedRows()(I) >= 0) Then
                        banderaPreferentesAIzquierda = I
                        grdPreferentesSinFechaEspecial.AddNewRow()
                        'estiloGrdClientePreferenteConFechaEspecial()  
                        grdPreferentesSinFe.RefreshDataSource()

                    End If
                Next

                grdPreferenteConFeEspecial.DeleteSelectedRows()

                btnPreferentesADerecha.Enabled = False

                Me.Cursor = Cursors.Default
            Else
                Dim objMensajeGuardar As New Tools.AdvertenciaForm
                objMensajeGuardar.mensaje = "La fecha de Entrega Clientes Preferentes debe ser mayor o igual a la de Fecha de " + Date.Today.ToShortDateString + "."
                objMensajeGuardar.ShowDialog()
            End If
        Else
            Dim objMensajeGuardar As New Tools.AdvertenciaForm
            objMensajeGuardar.mensaje = "No hay registros seleccionados."
            objMensajeGuardar.ShowDialog()
        End If


    End Sub

    Private Sub grdPreferentesSinFechaEspecialAIzquierda_InitNewRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles grdPreferentesSinFechaEspecial.InitNewRow

        Dim rowSelected As New ArrayList()

        For I = banderaPreferentesAIzquierda To grdPreferenteConFeEspecial.SelectedRowsCount() - 1
            If (grdPreferenteConFeEspecial.GetSelectedRows()(I) >= 0) Then
                rowSelected.Add(grdPreferenteConFeEspecial.GetDataRow(grdPreferenteConFeEspecial.GetSelectedRows()(banderaPreferentesAIzquierda)))
            End If
        Next

        For x = 0 To rowSelected.Count - 1

            Dim Row As DataRow = CType(rowSelected(x), DataRow)
            'as
            grdPreferentesSinFechaEspecial.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle

            grdPreferentesSinFechaEspecial.Focus()
            grdPreferentesSinFechaEspecial.SetRowCellValue(e.RowHandle, "idMarca", Row("idMarca"))
            grdPreferentesSinFechaEspecial.SetRowCellValue(e.RowHandle, "Marca", Row("Marca"))

            grdPreferentesSinFechaEspecial.SetRowCellValue(e.RowHandle, "idColeccion", Row("idColeccion"))
            grdPreferentesSinFechaEspecial.SetRowCellValue(e.RowHandle, "Colección", Row("Colección"))

            grdPreferentesSinFechaEspecial.SetRowCellValue(e.RowHandle, "idTemporada", Row("idTemporada"))
            grdPreferentesSinFechaEspecial.SetRowCellValue(e.RowHandle, "Temporada", Row("Temporada"))

            grdPreferentesSinFechaEspecial.SetRowCellValue(e.RowHandle, "idColeccionMarca", Row("idColeccionMarca"))
            'grdPreferenteConFeEspecial.SetRowCellValue(e.RowHandle, "*FEntrega", dtPickerPreferente.Value.ToShortDateString)
        Next

        rowSelected.Clear()
    End Sub

#End Region


#Region "cambia datos pestaña generales"




    Private Sub btnGeneralesADerecha_Click(sender As Object, e As EventArgs) Handles btnGeneralesADerecha.Click
        If grdGeneralSinFeEspecial.SelectedRowsCount > 0 Then

            If dtePickerGenerales.Value.ToShortDateString >= Date.Today Then
                Me.Cursor = Cursors.WaitCursor
                For I = 0 To grdGeneralSinFeEspecial.SelectedRowsCount() - 1
                    If (grdGeneralSinFeEspecial.GetSelectedRows()(I) >= 0) Then
                        banderaGeneralesADerecha = I
                        grdGeneralConFeEspecial.AddNewRow()
                        grdGeneralConFe.RefreshDataSource()

                    End If
                Next

                grdGeneralSinFeEspecial.DeleteSelectedRows()

                btnGeneralesAIzquierda.Enabled = False

                Me.Cursor = Cursors.Default
            Else
                Dim objMensajeGuardar As New Tools.AdvertenciaForm
                objMensajeGuardar.mensaje = "La fecha de Entrega Clientes Generales debe ser mayor o igual a la de Fecha de " + Date.Today.ToShortDateString + "."
                objMensajeGuardar.ShowDialog()
            End If
        Else
            Dim objMensajeGuardar As New Tools.AdvertenciaForm
            objMensajeGuardar.mensaje = "No hay registros seleccionados."
            objMensajeGuardar.ShowDialog()
        End If
    End Sub

    Private Sub grdGeneralSinFeEspecialADerecha_InitNewRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles grdGeneralConFeEspecial.InitNewRow
        Dim View As GridView
        View = sender
        Dim rowSelected As New ArrayList()

        For I = banderaGeneralesADerecha To grdGeneralSinFeEspecial.SelectedRowsCount() - 1
            If (grdGeneralSinFeEspecial.GetSelectedRows()(I) >= 0) Then
                rowSelected.Add(grdGeneralSinFeEspecial.GetDataRow(grdGeneralSinFeEspecial.GetSelectedRows()(banderaGeneralesADerecha)))
            End If
        Next

        For x = 0 To rowSelected.Count - 1

            Dim Row As DataRow = CType(rowSelected(x), DataRow)

            grdGeneralConFeEspecial.Focus()

            grdGeneralConFeEspecial.SetRowCellValue(e.RowHandle, "idMarca", Row("idMarca"))
            grdGeneralConFeEspecial.SetRowCellValue(e.RowHandle, "Marca", Row("Marca"))

            grdGeneralConFeEspecial.SetRowCellValue(e.RowHandle, "idColeccion", Row("idColeccion"))
            grdGeneralConFeEspecial.SetRowCellValue(e.RowHandle, "Colección", Row("Colección"))

            grdGeneralConFeEspecial.SetRowCellValue(e.RowHandle, "idTemporada", Row("idTemporada"))
            grdGeneralConFeEspecial.SetRowCellValue(e.RowHandle, "Temporada", Row("Temporada"))

            grdGeneralConFeEspecial.SetRowCellValue(e.RowHandle, "idColeccionMarca", Row("idColeccionMarca"))

            grdGeneralConFeEspecial.SetRowCellValue(e.RowHandle, "*FEntrega", dtePickerGenerales.Value.ToShortDateString)

            Dim inSt As Date = CDate(View.GetRowCellValue(e.RowHandle, "*FEntrega"))
            If inSt < dtpFechaEntrega.Value.ToShortDateString Then
                registrosRojoInsertadoActualizados = True
            End If

        Next
        rowSelected.Clear()
    End Sub

    Private Sub btnGeneralesAIzquierda_Click(sender As Object, e As EventArgs) Handles btnGeneralesAIzquierda.Click
        If grdGeneralConFeEspecial.SelectedRowsCount > 0 Then

            Me.Cursor = Cursors.WaitCursor

            For I = 0 To grdGeneralConFeEspecial.SelectedRowsCount() - 1
                If (grdGeneralConFeEspecial.GetSelectedRows()(I) >= 0) Then
                    banderaGeneralesAIzquierda = I
                    grdGeneralSinFeEspecial.AddNewRow()
                    grdGeneralSinFe.RefreshDataSource()

                End If
            Next
            grdGeneralConFeEspecial.DeleteSelectedRows()

            btnGeneralesADerecha.Enabled = False

            Me.Cursor = Cursors.Default
        Else
            Dim objMensajeGuardar As New Tools.AdvertenciaForm
            objMensajeGuardar.mensaje = "No hay registros seleccionados."
            objMensajeGuardar.ShowDialog()
        End If

    End Sub



    Private Sub grdGeneralConFeEspecialAIzquierda_InitNewRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles grdGeneralSinFeEspecial.InitNewRow

        Dim rowSelected As New ArrayList()

        For I = banderaGeneralesAIzquierda To grdGeneralConFeEspecial.SelectedRowsCount() - 1
            If (grdGeneralConFeEspecial.GetSelectedRows()(I) >= 0) Then
                rowSelected.Add(grdGeneralConFeEspecial.GetDataRow(grdGeneralConFeEspecial.GetSelectedRows()(banderaGeneralesAIzquierda)))
            End If
        Next


        For x = 0 To rowSelected.Count - 1

            Dim Row As DataRow = CType(rowSelected(x), DataRow)

            grdGeneralSinFeEspecial.Focus()

            grdGeneralSinFeEspecial.SetRowCellValue(e.RowHandle, "idMarca", Row("idMarca"))
            grdGeneralSinFeEspecial.SetRowCellValue(e.RowHandle, "Marca", Row("Marca"))

            grdGeneralSinFeEspecial.SetRowCellValue(e.RowHandle, "idColeccion", Row("idColeccion"))
            grdGeneralSinFeEspecial.SetRowCellValue(e.RowHandle, "Colección", Row("Colección"))

            grdGeneralSinFeEspecial.SetRowCellValue(e.RowHandle, "idTemporada", Row("idTemporada"))
            grdGeneralSinFeEspecial.SetRowCellValue(e.RowHandle, "Temporada", Row("Temporada"))

            grdGeneralSinFeEspecial.SetRowCellValue(e.RowHandle, "idColeccionMarca", Row("idColeccionMarca"))
            grdGeneralSinFeEspecial.SetRowCellValue(e.RowHandle, "*FEntrega", dtePickerGenerales.Value.ToShortDateString)
        Next
        rowSelected.Clear()
    End Sub

#End Region


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub exportarDatos(gridExportar As DevExpress.XtraGrid.Views.Grid.GridView, controlGrid As DevExpress.XtraGrid.GridControl)

        Dim filename As String
        Dim DataGrid As DevExpress.XtraGrid.GridControl = controlGrid

        'Ask the user where to save the file to
        Dim SaveFileDialog As New SaveFileDialog()
        SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
        SaveFileDialog.FilterIndex = 2
        SaveFileDialog.RestoreDirectory = True
        If SaveFileDialog.ShowDialog() = DialogResult.OK Then

            'This is required so that excel doesn't make all the grids very small. This will export all grids space out evenly
            gridExportar.OptionsPrint.AutoWidth = True
            gridExportar.OptionsPrint.EnableAppearanceEvenRow = True
            gridExportar.OptionsPrint.PrintPreview = True
            'Set the selected file as the filename
            filename = SaveFileDialog.FileName

            Dim exportOptions = New XlsxExportOptionsEx()
            'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

            'Export the file via inbuild function
            DevExpress.Export.ExportSettings.DefaultExportType = ExportType.WYSIWYG
            gridExportar.ExportToXlsx(filename, exportOptions)
            'DataGrid.ExportToXlsx(filename, exportOptions)

            'If the file exists (i.e. export worked), then open it
            If System.IO.File.Exists(filename) Then
                Dim DialogResult As DialogResult = MessageBox.Show("El archivo ha sido exportado a " & filename & vbNewLine & "¿Quieres abrirlo ahora?", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If DialogResult = Windows.Forms.DialogResult.Yes Then
                    System.Diagnostics.Process.Start(filename)
                End If
            End If
        End If


    End Sub

    Private Sub btnGuardarFechaEntregaColecciones_Click(sender As Object, e As EventArgs) Handles btnGuardarFechaEntregaColecciones.Click
        Dim objBU As New Negocios.ClientesPrefGenBU
        'rowsClientesPreferentesConFechaEspecial.Clear()
        'rowsClientesPreferentesConFechaEspecial.Clear()
        'rowsClientesPreferentesSinFechaEspecial.Clear()


        grdGeneralConFeEspecial.ClearColumnsFilter()
        grdGeneralSinFeEspecial.ClearColumnsFilter()
        grdPreferenteConFeEspecial.ClearColumnsFilter()
        grdPreferentesSinFechaEspecial.ClearColumnsFilter()


        'mensaje de confirmación para guardar valores cambiados
        Dim objMsjConfirmar As New Tools.ConfirmarForm
        Dim cadenaMensaje As String = "¿ Está seguro que desea guardar en la base de datos los cambios realizados ? (Una vez realizada esta acción no se podrá revertir)"
        objMsjConfirmar.mensaje = cadenaMensaje
        If objMsjConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then

            Me.Cursor = Cursors.WaitCursor

            'meter los valores de grid preferente sin fecha especial
            For I = 0 To grdPreferentesSinFechaEspecial.RowCount() - 1
                If I >= numFilasGridPreferenteSinFecha Then
                    rowsClientesPreferentesSinFechaEspecial.Add(grdPreferentesSinFechaEspecial.GetDataRow(I))
                End If
            Next

            'clientesPreferentesSinFechaEspecial
            For x = 0 To rowsClientesPreferentesSinFechaEspecial.Count - 1
                Dim Row As DataRow = CType(rowsClientesPreferentesSinFechaEspecial(x), DataRow)

                'coleccionMarcaId As Int16, idUsuario As Int16, generalPreferente As String
                objBU.quitarColeccionMarcaFechaEntregaEspecialPreferenteGeneral(Row("idColeccionMarca"), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "preferente")
            Next


            'meto los valores de grid preferente con fecha especial  
            For I = 0 To grdPreferenteConFeEspecial.RowCount() - 1
                If I >= numFilasGridPreferenteConFecha Then
                    rowsClientesPreferentesConFechaEspecial.Add(grdPreferenteConFeEspecial.GetDataRow(I))
                End If

            Next

            'clientesPreferentesConFechaEspecial
            For x = 0 To rowsClientesPreferentesConFechaEspecial.Count - 1
                Dim Row As DataRow = CType(rowsClientesPreferentesConFechaEspecial(x), DataRow)
                'coleccionMarcaId As Int16, fechaEntregaGeneralPreferente As String, idUsuario As Int16, generalPreferente As String
                'idColeccionMarca()               
                Dim fecha As Date = Row("*FEntrega")
                objBU.insertarActualizarColeccionMarcaFechaentregaEspecial(Row("idColeccionMarca"), fecha.ToShortDateString, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "preferente")
            Next

            'meto los valores de grid general sin fecha especial  
            For I = 0 To grdGeneralSinFeEspecial.RowCount() - 1
                If I >= numFilasGridGeneralesSinFecha Then
                    rowsClientesGeneralSinFechaEspecial.Add(grdGeneralSinFeEspecial.GetDataRow(I))
                End If

            Next

            'ClientesGenerales sin fecha Especial
            For x = 0 To rowsClientesGeneralSinFechaEspecial.Count - 1
                Dim Row As DataRow = CType(rowsClientesGeneralSinFechaEspecial(x), DataRow)
                'coleccionMarcaId As Int16, idUsuario As Int16, generalPreferente As String
                objBU.quitarColeccionMarcaFechaEntregaEspecialPreferenteGeneral(Row("idColeccionMarca"), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "general")
            Next

            'meto los valores de generales con fecha especial
            For I = 0 To grdGeneralConFeEspecial.RowCount() - 1
                If I >= numFilasGridGeneralesConFecha Then
                    rowsClientesGeneralConFechaEspecial.Add(grdGeneralConFeEspecial.GetDataRow(I))
                End If
            Next

            'ClientesGenerales con fecha Especial
            For x = 0 To rowsClientesGeneralConFechaEspecial.Count - 1
                Dim Row As DataRow = CType(rowsClientesGeneralConFechaEspecial(x), DataRow)
                'coleccionMarcaId As Int16, fechaEntregaGeneralPreferente As String, idUsuario As Int16, generalPreferente As String
                'idColeccionMarca()
                Dim fecha As Date = Row("*FEntrega")
                objBU.insertarActualizarColeccionMarcaFechaentregaEspecial(Row("idColeccionMarca"), fecha.ToShortDateString, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "general")
            Next

            cargarDatosGrids()
            filasModificadasPreferenteConFecha.Clear()
            filasModificadasGeneralesConFecha.Clear()

            btnPreferentesADerecha.Enabled = True
            btnPreferentesAIzquierda.Enabled = True
            btnGeneralesADerecha.Enabled = True
            btnGeneralesAIzquierda.Enabled = True

            rowsClientesPreferentesConFechaEspecial.Clear()
            rowsClientesPreferentesSinFechaEspecial.Clear()
            rowsClientesGeneralConFechaEspecial.Clear()
            rowsClientesGeneralSinFechaEspecial.Clear()

            Me.Cursor = Cursors.Default
            Dim objMensajeGuardar As New Tools.ExitoForm
            objMensajeGuardar.mensaje = "Se actualizaron los datos exitosamente."
            objMensajeGuardar.ShowDialog()
            mensaje()

            registrosRojo = 0
            registrosRojoInsertadoActualizados = False
        Else

        End If


    End Sub




#Region "Fecha de entrega top"
    Private Sub btnGuardarFechaEntregaGen_Click(sender As Object, e As EventArgs) Handles btnGuardarFechaEntregaGen.Click
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vExitoForm As New ExitoForm
        Dim vErrorForm As New ErroresForm
        Dim vConfirmarForm As New ConfirmarForm
        Dim vFechaEntregaBU As New FechaEntregaBU
        Dim vFecha As Date
        Dim objBU As New Negocios.ClientesPrefGenBU
        Dim listaColeccionesPreferentesConFechaEntregaEspecial As New DataTable
        Dim listaColeccionesGeneralesConFechaEntregaEspecial As New DataTable

        If Listo Then
            vConfirmarForm.Text = "Fecha de entrega"
            vConfirmarForm.mensaje = "¿Desea actualizar la fecha de entrega?"
            Dim vDialogResult As New DialogResult
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                Try
                    vFecha = dtpFechaEntrega.Value
                    If vFecha > Now Then
                        vFechaEntregaBU.GuardarFechaEntrega(vFecha)
                        vExitoForm.Text = "Fecha de entrega"
                        vExitoForm.mensaje = "Registro guardado"
                        vExitoForm.ShowDialog()

                        cargarDatosGrids()
                        mensaje()
                    Else
                        vAdvertenciaForm.Text = "Fecha de entrega"
                        vAdvertenciaForm.mensaje = "No puede seleccionar una fecha inferior a la fecha actual"
                        vAdvertenciaForm.ShowDialog()
                    End If
                    'Me.Close()
                Catch ex As Exception
                    vErrorForm.Text = "Fecha de entrega"
                    vErrorForm.mensaje = ex.Message
                    vErrorForm.ShowDialog()
                End Try
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Semana()
        If Not Listo Then Exit Sub
        ' lblSemanaValor.Text = DatePart(DateInterval.WeekOfYear, dtpFechaEntrega.Value)
        Listo = False
        Try
            nudAño.Value = DatePart(DateInterval.Year, dtpFechaEntrega.Value)
            If nudAño.Value = 2021 Then
                nudSemana.Value = DatePart(DateInterval.WeekOfYear, dtpFechaEntrega.Value) - 1
            Else
                nudSemana.Value = DatePart(DateInterval.WeekOfYear, dtpFechaEntrega.Value) - 1
            End If
        Catch ex As Exception
            Listo = True
        End Try
        Listo = True
    End Sub

    Private Sub CalcularSemana()
        Dim vErrorForm As New ErroresForm
        Dim vFechaEntregaBU As New FechaEntregaBU
        If Not Listo Then Exit Sub
        Try
            dtpFechaEntrega.Value = vFechaEntregaBU.PrimerDiaSemana(nudAño.Value, nudSemana.Value)
        Catch ex As Exception
            vErrorForm.Text = ex.Message
            vErrorForm.ShowDialog()
        End Try
    End Sub

    Private Sub CargarOpcion()
        Dim vFechaEntregaBU As New FechaEntregaBU
        dtpFechaEntrega.Value = vFechaEntregaBU.ObtenerOpcionDate("FechaEntrega")
    End Sub

    Private Sub nudSemana_ValueChanged(sender As Object, e As EventArgs) Handles nudSemana.ValueChanged
        CalcularSemana()
    End Sub

    Private Sub nudAño_ValueChanged(sender As Object, e As EventArgs) Handles nudAño.ValueChanged
        CalcularSemana()
    End Sub

    Private Sub dtpFechaEntrega_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEntrega.ValueChanged
        Semana()
    End Sub
#End Region






    Private Sub dtpEditarFechaEntrega_ValueChanged(sender As Object, e As EventArgs) Handles dtpEditarFechaEntregaPreferente.ValueChanged
        grdPreferenteConFeEspecial.ClearColumnsFilter()
        Dim NumeroFilas = grdPreferenteConFeEspecial.RowCount - 1
        For index As Integer = 1 To NumeroFilas Step 1
            If (grdPreferenteConFeEspecial.IsRowSelected(grdPreferenteConFeEspecial.GetVisibleRowHandle(index)) = True) Then
                grdPreferenteConFeEspecial.SetRowCellValue(grdPreferenteConFeEspecial.GetVisibleRowHandle(index), "*FEntrega", dtpEditarFechaEntregaPreferente.Value)
            End If
        Next
    End Sub

    Private Sub dtpEditarFechaEntregaGeneral_ValueChanged(sender As Object, e As EventArgs) Handles dtpEditarFechaEntregaGeneral.ValueChanged
        'Dim NumeroFilas = grdGeneralConFeEspecial.SelectedRowsCount - 1
        'For index As Integer = 0 To NumeroFilas Step 1
        '    If (grdGeneralConFeEspecial.GetSelectedRows()(index) >= 0) Then
        '        grdGeneralConFeEspecial.SetRowCellValue(grdGeneralConFeEspecial.GetVisibleRowHandle(index), "*FEntrega", dtpEditarFechaEntregaGeneral.Value)
        '    End If
        'Next
        grdGeneralConFeEspecial.ClearColumnsFilter()
        Dim NumeroFilas = grdGeneralConFeEspecial.RowCount - 1
        For index As Integer = 1 To NumeroFilas Step 1
            If (grdGeneralConFeEspecial.IsRowSelected(grdGeneralConFeEspecial.GetVisibleRowHandle(index)) = True) Then
                grdGeneralConFeEspecial.SetRowCellValue(grdGeneralConFeEspecial.GetVisibleRowHandle(index), "*FEntrega", dtpEditarFechaEntregaGeneral.Value)
            End If
        Next

    End Sub

    Private Sub btnPorcentajeSemanal_Click(sender As Object, e As EventArgs) Handles btnPorcentajeSemanal.Click
        Dim ventana As New Programacion_ColocacionSemanal_ConfiguracionPorcentajePromedioSemana_CalcularFechaEntrega
        ventana.StartPosition = FormStartPosition.CenterScreen
        ventana.ShowDialog()
    End Sub


    Private Sub btnPropuestaFechaEntrega_Click(sender As Object, e As EventArgs) Handles btnPropuestaFechaEntrega.Click
        Dim objBU As New ClientesPrefGenBU
        Dim fechaPropuesta As Date
        fechaPropuesta = Date.Parse(objBU.ObtenerPropuestaFechaEntregaGeneral(SesionUsuario.UsuarioSesion.PIDColaboradorUser).Rows(0)("FechaEntrega").ToString)
        dtpFechaEntrega.Value = fechaPropuesta
    End Sub

End Class