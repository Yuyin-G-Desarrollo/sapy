Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Base

Public Class ReporteResumenClienteForm

    Private Sub ReporteResumenClienteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicializar()

        'dtpFechaEntregaDel.MinDate = New DateTime(DateTime.Now.Year, 1, 1)
        'dtpFechaEntregaDel.MaxDate = New DateTime(DateTime.Now.Year, 12, 31)
        'dtpFechaEntregaAl.MinDate = New DateTime(DateTime.Now.Year, 1, 1)
        'dtpFechaEntregaAl.MaxDate = New DateTime(DateTime.Now.Year, 12, 31)
        bgvDatosProyeccion.Bands.Clear()

        Dim dtTiposReportes = OBJBU.ObtenerTiposReportes()
        cmboxTipoReporte.DataSource = dtTiposReportes
        cmboxTipoReporte.DisplayMember = "Reporte"
        cmboxTipoReporte.ValueMember = "ReporteID"

        PRIMERA_CARGA = False
        WindowState = FormWindowState.Maximized
        GrdBandComparativo.Visible = False
        GridControl1.Visible = False
        GrdBandComparativo.Visible = False
        grdDatosProyeccion.Visible = True


    End Sub

    Private Sub ReporteResumenClienteForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' OBJBU.BorrarSession(SESSION)
    End Sub

#Region "Variables Globales"
    Private ReadOnly LST_INICIAL As New List(Of String)
    Private FILTRO_FECHAINICIO As String = String.Empty
    Private FILTRO_FECHAFIN As String = String.Empty
    Private FILTRO_CLIENTE As String = String.Empty
    Private INICIO_SESSION As Boolean = False
    Private SESSION As Integer = 0
    Private PRIMERA_CARGA As Boolean = True
    ReadOnly OBJBU As New Negocios.ReporteResumenClienteBU
#End Region

#Region "Panel Cabecera"

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
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
                    If cmboxTipoReporte.SelectedIndex = 2 Then
                        BandedGridView1.ExportToXlsx(.SelectedPath + "\Datos_ResumenCliente_Comparativo" + fecha_hora + ".xlsx")
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "Datos_ResumenCliente_Comparativo" & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_ResumenCliente_Comparativo" + fecha_hora + ".xlsx")
                    ElseIf cmboxTipoReporte.SelectedIndex = 1 Then
                        bgvDatosProyeccion.ExportToXlsx(.SelectedPath + "\Datos_ResumenCliente_HistoricoVenta" + fecha_hora + ".xlsx")
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "Datos_ResumenCliente_HistoricoVenta" & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_ResumenCliente_HistoricoVenta" + fecha_hora + ".xlsx")
                    Else

                        bgvDatosProyeccion.ExportToXlsx(.SelectedPath + "\Datos_ResumenCliente_Cumplimiento" + fecha_hora + ".xlsx")
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "Datos_ResumenCliente_Cumplimiento" & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_ResumenCliente_Cumplimiento" + fecha_hora + ".xlsx")

                    End If


                End If

            End With
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub BtnAyuda_Click(sender As Object, e As EventArgs)

    End Sub

#End Region

#Region "Panel de Parametros"

#Region "Eventos Flechas"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pnlParametros.Height = 206
    End Sub

#End Region

#Region "Eventos Cliente"

    Private Sub GrdClientes_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        DiseñoFiltro(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim filtroReporte As New FiltrosReportesForm With {
            .TIPO_BUSQUEDA = 2
        }



        Dim lstIDFiltro As New List(Of String)
        For Each row As UltraGridRow In grdClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            lstIDFiltro.Add(parametro)
        Next

        filtroReporte.LST_ID_FILTRO = lstIDFiltro

        filtroReporte.ShowDialog(Me)


        If Not filtroReporte.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If filtroReporte.LST_PARAMETROS.Rows.Count = 0 Then Return

        grdClientes.DataSource = filtroReporte.LST_PARAMETROS
        With grdClientes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
        End With
    End Sub

    Private Sub BtnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdClientes.DataSource = Nothing
    End Sub

    Private Sub GrdClientes_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

#End Region

#Region "Eventos Fechas"

    Private Sub DtpFechaEntregaDel_ValueChanged(sender As Object, e As EventArgs)
        'If dtpFechaEntregaAl.Value < dtpFechaEntregaDel.Value Then
        '    dtpFechaEntregaAl.Value = dtpFechaEntregaDel.Value
        'End If
    End Sub

    Private Sub DtpFechaEntregaAl_ValueChanged(sender As Object, e As EventArgs)
        'If dtpFechaEntregaAl.Value < dtpFechaEntregaDel.Value Then
        '    dtpFechaEntregaDel.Value = dtpFechaEntregaAl.Value
        'End If
    End Sub

#End Region

#End Region

#Region "Panel de Acciones"

    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor

        pgrGenerarDatos.Visible = True
        INICIO_SESSION = False
        If SESSION > 0 Then
            OBJBU.BorrarSession(SESSION)
        End If
        ConsultarReportes()
        pgrGenerarDatos.Visible = False
        'ConsultarDatos.RunWorkerAsync()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

#End Region

#Region "Metodos Privados"

    Private Sub Inicializar()
        cmboxTipoReporte.SelectedIndex = 0
        nmaño.Value = Date.Now.Year
        grdDatosProyeccion.DataSource = Nothing
        bgvDatosProyeccion.Columns.Clear()

        grdClientes.DataSource = LST_INICIAL

        lblFechaUltimaActualizacion.Text = "-"

        pgrGenerarDatos.Visible = False
    End Sub

    Private Sub DiseñoDevGrid()
        bgvDatosProyeccion.IndicatorWidth = 50

        For Each col As Columns.GridColumn In bgvDatosProyeccion.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
            If cmboxTipoReporte.SelectedIndex < 2 Then
                If (col.FieldName <> "Tipo" And col.FieldName <> "Cliente" And col.FieldName <> "Año") Then
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "N0"
                    DiseñoGrid.EstiloColumna(bgvDatosProyeccion, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, False, 85, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                Else
                    DiseñoGrid.EstiloColumna(bgvDatosProyeccion, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
                End If
            Else
                If (col.FieldName <> "ClienteSAYID" And col.FieldName <> "Cliente" And col.FieldName <> "SPID" And col.FieldName <> "ORDEN" And col.FieldName <> "FAMILIA") Then
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "N0"
                    DiseñoGrid.EstiloColumna(bgvDatosProyeccion, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, False, 85, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                Else
                    DiseñoGrid.EstiloColumna(bgvDatosProyeccion, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
                End If
            End If
            'DiseñoGrid.EstiloColumna(bgvDatosProyeccion, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
            If col.FieldName = "Cliente" Then
                'bgvDatosProyeccion.Columns(2).OptionsColumn.AllowMerge = True
            End If
        Next


        'bgvDatosProyeccion.Columns.ColumnByFieldName("ENERO").VisibleIndex = 1


        bgvDatosProyeccion.OptionsView.ColumnAutoWidth = True
        bgvDatosProyeccion.OptionsView.AllowCellMerge = True
        'grdDatosProyeccion.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        'grdDatosProyeccion.LookAndFeel.UseDefaultLookAndFeel = False
        'DiseñoGrid.AlternarColorEnFilas(bgvDatosProyeccion)

        If cmboxTipoReporte.SelectedIndex = 1 Then
            bgvDatosProyeccion.Columns(0).Visible = False
        End If



    End Sub

    Private Sub ObtenerFiltros()
        FILTRO_CLIENTE = String.Empty

        'FILTRO_FECHAINICIO = dtpFechaEntregaDel.Text
        'FILTRO_FECHAFIN = dtpFechaEntregaAl.Text

        For Each Row As UltraGridRow In grdClientes.Rows
            If FILTRO_CLIENTE <> "" Then
                FILTRO_CLIENTE += ","
            End If
            FILTRO_CLIENTE += Row.Cells("Parametro").Value.ToString()
        Next

    End Sub

    Private Sub ConsultarReportes()
        Cursor = Cursors.WaitCursor
        Dim TipoCalendario As Integer = 0
        Dim ColumnaCrecimiento As String = String.Empty

        pgrGenerarDatos.Show()

        ObtenerFiltros()

        If rdoEneDic.Checked = True Then
            TipoCalendario = 0
        Else
            TipoCalendario = 1
        End If

        If Not INICIO_SESSION Then
            Dim dtResultadoSession As DataTable = OBJBU.ConsultaSessionCliente(nmaño.Value,
                                                                               FILTRO_CLIENTE,
                                                                               Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, TipoCalendario)
            SESSION = CInt(dtResultadoSession.Rows(0)(0).ToString())
            INICIO_SESSION = True
        End If

        If SESSION > 0 Then

            Dim dtResultadoReporte As DataTable

            Select Case cmboxTipoReporte.SelectedIndex
                Case 0
                    dtResultadoReporte = OBJBU.ConsultaHistoricoVenta(SESSION, TipoCalendario)
                Case 1
                    dtResultadoReporte = OBJBU.ConsultaProyeccionVenta(SESSION, TipoCalendario)
                Case 2
                    dtResultadoReporte = OBJBU.ConsultaComparativoFamilia(SESSION)
                Case Else
                    dtResultadoReporte = New DataTable
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Tipo de reporte inexistente.")
            End Select

            grdDatosProyeccion.DataSource = Nothing
            bgvDatosProyeccion.Bands.Clear()
            bgvDatosProyeccion.Bands.AddBand(" ")
            bgvDatosProyeccion.Columns.Clear()

            If dtResultadoReporte.Rows.Count > 0 Then
                If cmboxTipoReporte.SelectedIndex = 2 Then
                    GrdBandComparativo.Visible = False
                    GridControl1.Visible = True
                    grdDatosProyeccion.Visible = False
                    GridControl1.DataSource = dtResultadoReporte
                    Dim formato As New DevExpress.Utils.AppearanceDefault
                    formato.HAlignment = HAlign.Right

                    ColumnaCrecimiento = "CREC " + nmaño.Value.ToString + " VS " + (nmaño.Value - 1).ToString
                    BandedGridView1.Columns(11).Caption = ColumnaCrecimiento
                    BandedGridView1.Columns(11).AppearanceCell.Assign(formato)

                    If cmboxTipoReporte.SelectedIndex = 2 Then
                        BandedGridView1.Columns(3).Caption = "Pares"
                        BandedGridView1.Columns(4).Caption = "Articulos"
                        BandedGridView1.Columns(5).Caption = "Pares"
                        BandedGridView1.Columns(6).Caption = "Articulos"
                        BandedGridView1.Columns(7).Caption = "Pares"
                        BandedGridView1.Columns(8).Caption = "Articulos"
                        BandedGridView1.Columns(9).Caption = "Total Pares"
                        BandedGridView1.Columns(10).Caption = "Total Artículos"

                        BandedGridView1.Bands(1).Caption = (nmaño.Value - 2).ToString
                        BandedGridView1.Bands(2).Caption = (nmaño.Value - 1).ToString
                        BandedGridView1.Bands(3).Caption = (nmaño.Value - 0).ToString
                    End If


                    BandedGridView1.OptionsView.ColumnAutoWidth = True
                    BandedGridView1.OptionsView.AllowCellMerge = True

                    For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In BandedGridView1.Columns

                        If Col.FieldName = "Cliente" Then
                            BandedGridView1.Columns.ColumnByFieldName(Col.FieldName).OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True
                        Else
                            BandedGridView1.Columns.ColumnByFieldName(Col.FieldName).OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                        End If

                    Next



                    'If row.Item("ColumnaOrigen").ToString().ToUpper <> "MARCA" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "AGENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "CLIENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "RUTA" Then
                    '    grdcomparativo.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True
                    'End If


                    GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
                    GridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat


                Else
                    GridControl1.Visible = False
                    GrdBandComparativo.Visible = False
                    grdDatosProyeccion.Visible = True
                    grdDatosProyeccion.DataSource = dtResultadoReporte
                    DiseñoGrid.DiseñoBaseGrid(bgvDatosProyeccion)
                    DiseñoDevGrid()

                    If rdoNovDic.Checked = True Then

                    End If

                    grdDatosProyeccion.LookAndFeel.UseDefaultLookAndFeel = False
                    grdDatosProyeccion.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat

                End If

                lblRegistroR.Text = dtResultadoReporte.AsEnumerable().Select(Function(x) x.Item("Cliente")).Distinct().Count.ToString("N0")

                lblFechaUltimaActualizacion.Text = DateTime.Now.ToString()
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos que mostrar.")
            End If

        Else
            grdDatosProyeccion.DataSource = Nothing
            bgvDatosProyeccion.Columns.Clear()
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se ha iniciado una session.")
        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub DiseñoFiltro(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No

        End With



    End Sub

    Private Sub ConsultarDatos_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ConsultarDatos.DoWork
        CheckForIllegalCrossThreadCalls = False
        ConsultarReportes()
    End Sub

    Private Sub ConsultarDatos_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConsultarDatos.RunWorkerCompleted
        pgrGenerarDatos.Visible = False
    End Sub

    Private Sub cmboxTipoReporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboxTipoReporte.SelectedIndexChanged
        If PRIMERA_CARGA = False And SESSION > 0 Then


            ConsultarReportes()
            CheckForIllegalCrossThreadCalls = False
            pgrGenerarDatos.Visible = False
        End If

    End Sub

    Private Sub bgvDatosProyeccion_CellMerge(sender As Object, e As CellMergeEventArgs) Handles bgvDatosProyeccion.CellMerge
        Dim view As GridView = TryCast(sender, GridView)

        If IsNothing(view) = True Then
            Return
        End If
        If e.Column.Caption = "Cliente" Then
            Dim cliente1 As String = view.GetRowCellDisplayText(e.RowHandle1, "Cliente")
            Dim cliente2 As String = view.GetRowCellDisplayText(e.RowHandle2, "Cliente")

            If cliente1 = cliente2 Then
                e.Merge = True
            End If

            e.Handled = True
        Else
            e.Merge = False
            e.Handled = True
        End If


        '    GridView View = sender as GridView;
        'If (View == null) Then Return;
        'If (e.Column == colCreatorID) Then {
        '    String text1 = View.GetRowCellDisplayText(e.RowHandle1, colCreatorID);
        '    String text2 = View.GetRowCellDisplayText(e.RowHandle2, colCreatorID);
        '    e.Merge = (text1 == text2);
        '    e.Handled = True;
        '}
    End Sub

    Private Sub bBanded_CellMerge(sender As Object, e As CellMergeEventArgs) Handles BandedGridView1.CellMerge
        Dim view As GridView = TryCast(sender, GridView)

        If IsNothing(view) = True Then
            Return
        End If
        If e.Column.Caption = "Cliente" Then
            Dim cliente1 As String = view.GetRowCellDisplayText(e.RowHandle1, "Cliente")
            Dim cliente2 As String = view.GetRowCellDisplayText(e.RowHandle2, "Cliente")

            If cliente1 = cliente2 Then
                e.Merge = True
            End If

            e.Handled = True
        Else
            e.Merge = False
            e.Handled = True
        End If


        '    GridView View = sender as GridView;
        'If (View == null) Then Return;
        'If (e.Column == colCreatorID) Then {
        '    String text1 = View.GetRowCellDisplayText(e.RowHandle1, colCreatorID);
        '    String text2 = View.GetRowCellDisplayText(e.RowHandle2, colCreatorID);
        '    e.Merge = (text1 == text2);
        '    e.Handled = True;
        '}
    End Sub

    'Private Sub grdidcomparativo_CellMerge(sender As Object, e As CellMergeEventArgs) Handles grdcomparativo.CellMerge
    '    Dim view As GridView = TryCast(sender, GridView)

    '    If IsNothing(view) = True Then
    '        Return
    '    End If
    '    If e.Column.Caption = "Cliente" Then
    '        Dim cliente1 As String = view.GetRowCellDisplayText(e.RowHandle1, "Cliente")
    '        Dim cliente2 As String = view.GetRowCellDisplayText(e.RowHandle2, "Cliente")

    '        If cliente1 = cliente2 Then
    '            e.Merge = True
    '        End If

    '        e.Handled = True
    '    Else
    '        e.Merge = False
    '        e.Handled = True
    '    End If


    '    '    GridView View = sender as GridView;
    '    'If (View == null) Then Return;
    '    'If (e.Column == colCreatorID) Then {
    '    '    String text1 = View.GetRowCellDisplayText(e.RowHandle1, colCreatorID);
    '    '    String text2 = View.GetRowCellDisplayText(e.RowHandle2, colCreatorID);
    '    '    e.Merge = (text1 == text2);
    '    '    e.Handled = True;
    '    '}
    'End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim ImppresionForm As New ImpresionReporteResumenClienteForm
        ImppresionForm.SessionID = SESSION
        If rdoEneDic.Checked = True Then
            ImppresionForm.TipoCalendario = 0
        Else
            ImppresionForm.TipoCalendario = 1
        End If
        ImppresionForm.Show()
    End Sub

    Private Sub grdcomparativo_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles BandedGridView1.CustomDrawCell

        Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

        If e.Column.FieldName = "crec" Then

            If Replace(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName), "%", "") > 0 Then
                e.Appearance.BackColor = Color.LightGreen
            Else
                e.Appearance.BackColor = Color.Pink
            End If
        End If



    End Sub

    Private Sub grdcomparativo_CustomDrawCell1(sender As Object, e As RowCellCustomDrawEventArgs) Handles bgvDatosProyeccion.CustomDrawCell
        Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

        If e.Column.FieldName <> "Orden" And e.Column.FieldName <> "Cliente" And e.Column.FieldName <> "Tipo" And e.Column.FieldName <> "Año" Then

            If currentView.GetRowCellValue(e.RowHandle, "Tipo") = "DESVIACIÓN" Then
                If Replace(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName), "%", "") >= 0 Then
                    e.Appearance.BackColor = Color.LightGreen
                Else
                    e.Appearance.BackColor = Color.Pink
                End If

            End If


        End If


    End Sub

    Private Sub btnAyuda_Click_1(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "FR.TI.11_Manual de Usuario_Resumen_Cliente.pdf")
            Process.Start("Descargas\Manuales\Ventas\FR.TI.11_Manual de Usuario_Resumen_Cliente.pdf")
        Catch ex As Exception

        End Try
    End Sub



#End Region

End Class