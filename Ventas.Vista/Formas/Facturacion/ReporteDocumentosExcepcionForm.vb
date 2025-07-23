Imports DevExpress.Export
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class ReporteDocumentosExcepcionForm

#Region "Variables Globales"
    Private filtro_Emisor As String = String.Empty
    Private filtro_Cliente As String = String.Empty
    Private filtro_FechaAl As String = String.Empty
    Private filtro_FechaDel As String = String.Empty

    Private ReadOnly listInicial As New List(Of String)
#End Region

    Private Sub ReporteDocumentosExcepcionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicializar()
        lblTextoUltimaActualizacion.Location = New Point(1030, 13)
        lblFechaUltimaActualización.Location = New Point(1030, 32)
    End Sub

#Region "Panel Cabecera"

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreDocumento = "\ReporteDocumentosExcepcion"

        If vwDocumentos.RowCount > 0 Then
            Try
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True
                    'Dim exportOptions = New XlsxExportOptionsEx()
                    'AddHandler exportOptions.CustomizeCell, AddressOf ExportOptions_CustomizeCell

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        If vwDocumentos.GroupCount > 0 Then
                            grdDocumentos.ExportToXlsx(.SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                        Else
                            grdDocumentos.ExportToXlsx(.SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                        End If

                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & nombreDocumento & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                    End If
                End With

            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            End Try
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos para exportar.")
        End If
    End Sub

#End Region

#Region "Panel Parametros"

#Region "Eventos Cliente"

    Private Sub GrdFiltroCliente_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdFiltroCliente.InitializeLayout
        DiseñoFiltro(grdFiltroCliente, "Cliente")
    End Sub

    Private Sub BtnFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnFiltroCliente.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 1
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFiltroCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroCliente.DataSource = listado.listParametros
        With grdFiltroCliente
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        End With
    End Sub

    Private Sub BtnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdFiltroCliente.DataSource = listInicial
    End Sub

    Private Sub GrdFiltroCliente_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdFiltroCliente.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

#End Region

#Region "Eventos Emisor"

    Private Sub GrdFiltroEmisor_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdFiltroEmisor.InitializeLayout
        DiseñoFiltro(grdFiltroEmisor, "Emisor")
    End Sub

    Private Sub BtnFiltroEmisor_Click(sender As Object, e As EventArgs) Handles btnFiltroEmisor.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 14
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFiltroEmisor.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroEmisor.DataSource = listado.listParametros
        With grdFiltroEmisor
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Emisor"
        End With
    End Sub

    Private Sub BtnLimpiarFiltroEmisor_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroEmisor.Click
        grdFiltroEmisor.DataSource = listInicial
    End Sub

    Private Sub GrdFiltroEmisor_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdFiltroEmisor.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

#End Region

#Region "Eventos Flechas"

    Private Sub BtnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub BtnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 149
    End Sub

#End Region

#Region "Eventos Fechas"

    Private Sub DtpFechaDel_EditValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDel.EditValueChanged
        If dtpFechaAl.EditValue < dtpFechaDel.EditValue Then
            dtpFechaAl.EditValue = dtpFechaDel.EditValue
        End If
    End Sub

    Private Sub DtpFechaAl_EditValueChanged(sender As Object, e As EventArgs) Handles dtpFechaAl.EditValueChanged
        If dtpFechaAl.EditValue < dtpFechaDel.EditValue Then
            dtpFechaDel.EditValue = dtpFechaAl.EditValue
        End If
    End Sub

#End Region

#End Region

#Region "Panel Pie"

    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New Negocios.ReporteDocumentosExcepcionBU

        Cursor = Cursors.WaitCursor

        ObtenerFiltros()
        Dim dtResultado As DataTable = objBU.ConsultarReportesExcepcion(filtro_FechaDel,
                                                                        filtro_FechaAl,
                                                                        filtro_Cliente,
                                                                        filtro_Emisor)
        If dtResultado.Rows.Count > 0 Then
            grdDocumentos.DataSource = Nothing
            vwDocumentos.Columns.Clear()
            grdDocumentos.DataSource = dtResultado
            DiseñoGrid.DiseñoBaseGrid(vwDocumentos)
            DiseñoCuerpoGrid()

            lblRegistroR.Text = dtResultado.Rows.Count
            lblFechaUltimaActualización.Text = DateTime.Now.ToString()
            BtnArriba_Click(sender, e)
        Else
            grdDocumentos.DataSource = Nothing
            vwDocumentos.Columns.Clear()
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos para mostrar.")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Inicializar()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

#End Region

#Region "Metodos Privados"

    Private Sub VwDocumentos_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwDocumentos.CustomDrawRowIndicator
        If (e.RowHandle >= 0) Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub

    Private Sub ExportOptions_CustomizeCell(e As CustomizeCellEventArgs)
        Throw New NotImplementedException()
    End Sub

    Private Sub DiseñoFiltro(grid As UltraGrid, titulo As String)
        With grid.DisplayLayout
            .Override.RowSelectorWidth = 20
            .Override.AllowAddNew = AllowAddNew.No
            .Bands(0).Columns(0).Header.Caption = titulo
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        End With

    End Sub

    Private Sub ObtenerFiltros()
        filtro_Emisor = String.Empty
        filtro_Cliente = String.Empty

        filtro_FechaDel = dtpFechaDel.Text
        filtro_FechaAl = dtpFechaAl.Text

        For Each Row As UltraGridRow In grdFiltroEmisor.Rows
            If filtro_Emisor <> "" Then
                filtro_Emisor += ","
            End If
            filtro_Emisor += Row.Cells("RFC").Value.ToString()
        Next
        For Each Row As UltraGridRow In grdFiltroCliente.Rows
            If filtro_Cliente <> "" Then
                filtro_Cliente += ","
            End If
            filtro_Cliente += Row.Cells("Parametro").Value.ToString()
        Next

    End Sub

    Private Sub DiseñoCuerpoGrid()
        vwDocumentos.IndicatorWidth = 50
        For Each col As Columns.GridColumn In vwDocumentos.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
            If (col.FieldName = "Pares F" Or col.FieldName = "Pares R") Then
                DiseñoGrid.EstiloColumna(vwDocumentos, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, False, 100, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            Else
                DiseñoGrid.EstiloColumna(vwDocumentos, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
            End If
        Next
        vwDocumentos.OptionsView.ColumnAutoWidth = True

    End Sub

    Private Sub Inicializar()
        Me.WindowState = FormWindowState.Maximized

        grdDocumentos.DataSource = Nothing
        vwDocumentos.Columns.Clear()

        grdFiltroCliente.DataSource = listInicial
        grdFiltroEmisor.DataSource = listInicial

        dtpFechaDel.EditValue = Date.Now
        dtpFechaAl.EditValue = Date.Now

        lblRegistroR.Text = "-"
        lblFechaUltimaActualización.Text = "-"
    End Sub

#End Region

End Class