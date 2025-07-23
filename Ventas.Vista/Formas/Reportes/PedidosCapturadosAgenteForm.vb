Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class PedidosCapturadosAgenteForm

#Region "Variables Globales"
    Private filtro_FechaInicio As String = String.Empty
    Private filtro_FechaFin As String = String.Empty
    Private filtro_Agente As String = String.Empty
    Private filtro_Familia As String = String.Empty
    Private filtro_Cliente As String = String.Empty
    Private filtro_AgrupadoFamilia As Boolean = True
    Private filtro_AgrupadoCliente As Boolean = False
    Private filtro_AgrupadoAgente As Boolean = False
    ReadOnly listInicial As New List(Of String)
    ReadOnly objBU As New Negocios.PedidoCapturadoBU

#End Region

    Private Sub PedidosCapturadosAgenteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicializar()
    End Sub

#Region "Panel Cabecera"

    Private Sub BtnExportarExcelApartados_Click(sender As Object, e As EventArgs) Handles btnExportarExcelApartados.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreDocumento = "\ReportePedidosCaputadosAgentes_"

        If vwReportePedidos.RowCount > 0 Then
            Try
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True
                    Dim exportOptions = New XlsxExportOptionsEx()
                    AddHandler exportOptions.CustomizeCell, AddressOf ExportOptions_CustomizeCell

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        If vwReportePedidos.GroupCount > 0 Then
                            grdReportePedidos.ExportToXlsx(.SelectedPath + nombreDocumento + fecha_hora + ".xlsx", exportOptions)
                        Else
                            grdReportePedidos.ExportToXlsx(.SelectedPath + nombreDocumento + fecha_hora + ".xlsx", exportOptions)
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

#Region "Panel de Parametros"

#Region "Eventos Agente"

    Private Sub GrdAgentes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAgentes.InitializeLayout
        DiseñoFiltro(grdAgentes)
        grdAgentes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Agente"
    End Sub

    Private Sub BtnAgente_Click(sender As Object, e As EventArgs) Handles btnAgente.Click
        Dim listado As New ListadoParametrosReportesForm With {
            .tipo_busqueda = 1
        }

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdAgentes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdAgentes.DataSource = listado.listParametros
        With grdAgentes
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Agente de Ventas"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub BtnLimpiarFiltroAgente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroAgente.Click
        grdAgentes.DataSource = listInicial
    End Sub

    Private Sub GrdAgentes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAgentes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

#End Region

#Region "Eventos Cliente"

    Private Sub GrdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        DiseñoFiltro(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosReportesForm With {
            .tipo_busqueda = 2
        }

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdClientes.DataSource = listado.listParametros
        With grdClientes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        End With
    End Sub

    Private Sub BtnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdClientes.DataSource = listInicial
    End Sub

    Private Sub GrdClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

#End Region

#Region "Eventos Familia"

    Private Sub GrdFamilias_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFamilias.InitializeLayout
        DiseñoFiltro(grdFamilias)
        grdFamilias.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Familia"
    End Sub

    Private Sub BtnFamilia_Click(sender As Object, e As EventArgs) Handles btnFamilia.Click
        Dim listado As New ListadoParametrosReportesForm With {
            .tipo_busqueda = 10
        }

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFamilias.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFamilias.DataSource = listado.listParametros
        With grdFamilias
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Familia"
        End With
    End Sub

    Private Sub BtnLimpiarFiltroFamilia_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroFamilia.Click
        grdFamilias.DataSource = listInicial
    End Sub

    Private Sub GrdFamilias_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFamilias.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

#End Region

#Region "Eventos Fechas"

    Private Sub DtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEntregaDel.ValueChanged
        If dtpFechaEntregaAl.Value < dtpFechaEntregaDel.Value Then
            dtpFechaEntregaAl.Value = dtpFechaEntregaDel.Value
        End If
    End Sub

    Private Sub DtpFechaAl_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEntregaAl.ValueChanged
        If dtpFechaEntregaAl.Value < dtpFechaEntregaDel.Value Then
            dtpFechaEntregaDel.Value = dtpFechaEntregaAl.Value
        End If
    End Sub

#End Region

#Region "Eventos Agrupados"

    Private Sub CbxAgrupadoFamilia_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAgrupadoFamilia.CheckedChanged
        If cbxAgrupadoFamilia.Checked Then
            filtro_AgrupadoFamilia = True
            'ElseIf Not cbxAgrupadoAgente.Checked AndAlso Not cbxAgrupadoCliente.Checked Then
            '    cbxAgrupadoFamilia.Checked = True
        Else
            filtro_AgrupadoFamilia = False
        End If
    End Sub

    Private Sub CbxAgrupadoAgente_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAgrupadoAgente.CheckedChanged
        If cbxAgrupadoAgente.Checked Then
            filtro_AgrupadoAgente = True
            'ElseIf Not cbxAgrupadoFamilia.Checked AndAlso Not cbxAgrupadoCliente.Checked Then
            '    cbxAgrupadoAgente.Checked = True
        Else
            filtro_AgrupadoAgente = False
        End If
    End Sub

    Private Sub CbxAgrupadoCliente_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAgrupadoCliente.CheckedChanged
        If cbxAgrupadoCliente.Checked Then
            filtro_AgrupadoCliente = True
            'ElseIf Not cbxAgrupadoFamilia.Checked AndAlso Not cbxAgrupadoAgente.Checked Then
            '    cbxAgrupadoCliente.Checked = True
        Else
            filtro_AgrupadoCliente = False
        End If
    End Sub

#End Region

#Region "Eventos de cierre de parametros"
    Private Sub BtnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub BtnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 148
    End Sub

#End Region

#End Region

#Region "Panel de Acciones"

    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor

        If filtro_AgrupadoAgente Or filtro_AgrupadoCliente Or filtro_AgrupadoFamilia Then
            ObtenerFiltros()
            Dim dtResultadoReporte As DataTable = objBU.ConsultaPedidosCapturadosAgentes(filtro_FechaInicio,
                                                                                         filtro_FechaFin,
                                                                                         filtro_Cliente,
                                                                                         filtro_Agente,
                                                                                         filtro_Familia,
                                                                                         filtro_AgrupadoFamilia,
                                                                                         filtro_AgrupadoCliente,
                                                                                         filtro_AgrupadoAgente)
            If dtResultadoReporte.Rows.Count > 0 Then
                grdReportePedidos.DataSource = Nothing
                vwReportePedidos.Columns.Clear()
                If filtro_AgrupadoFamilia And Not filtro_AgrupadoCliente And filtro_AgrupadoAgente Then
                    If dtResultadoReporte.Rows.Item(0).IsNull("Agente") Then
                        dtResultadoReporte.Rows.RemoveAt(0)
                    End If
                End If
                grdReportePedidos.DataSource = dtResultadoReporte
                DiseñoGrid.DiseñoBaseGrid(vwReportePedidos)
                DiseñoDevGrid()

                lblRegistroR.Text = dtResultadoReporte.Rows.Count
                lblFechaUltimaActualización.Text = DateTime.Now.ToString()
                BtnArriba_Click(sender, e)
            Else
                grdReportePedidos.DataSource = Nothing
                vwReportePedidos.Columns.Clear()
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos para mostrar.")
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Seleccione un tipo de agrupamiento.")
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

    Private Sub Inicializar()

        grdReportePedidos.DataSource = Nothing
        vwReportePedidos.Columns.Clear()

        cbxAgrupadoFamilia.Checked = True
        cbxAgrupadoCliente.Checked = False
        cbxAgrupadoAgente.Checked = False

        grdClientes.DataSource = listInicial
        grdAgentes.DataSource = listInicial
        grdFamilias.DataSource = listInicial

        dtpFechaEntregaDel.Value = Date.Now
        dtpFechaEntregaAl.Value = Date.Now

        lblRegistroR.Text = "-"
        lblFechaUltimaActualización.Text = "-"
    End Sub

    Private Sub DiseñoDevGrid()
        vwReportePedidos.IndicatorWidth = 50
        For Each col As Columns.GridColumn In vwReportePedidos.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
            If (col.FieldName = "Pares Capturados" Or col.FieldName = "Pares Cancelados" Or col.FieldName = "Total") Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "N0"
                DiseñoGrid.EstiloColumna(vwReportePedidos, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, False, 100, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            Else
                DiseñoGrid.EstiloColumna(vwReportePedidos, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
            End If
        Next
        vwReportePedidos.OptionsView.ColumnAutoWidth = True
    End Sub

    Private Sub ObtenerFiltros()
        filtro_Agente = String.Empty
        filtro_Familia = String.Empty
        filtro_Cliente = String.Empty

        filtro_FechaInicio = dtpFechaEntregaDel.Text
        filtro_FechaFin = dtpFechaEntregaAl.Text

        For Each Row As UltraGridRow In grdAgentes.Rows
            If filtro_Agente <> "" Then
                filtro_Agente += ","
            End If
            filtro_Agente += Row.Cells("Parametro").Value.ToString()
        Next
        For Each Row As UltraGridRow In grdFamilias.Rows
            If filtro_Familia <> "" Then
                filtro_Familia += ","
            End If
            filtro_Familia += Row.Cells("Parametro").Value.ToString()
        Next
        For Each Row As UltraGridRow In grdClientes.Rows
            If filtro_Cliente <> "" Then
                filtro_Cliente += ","
            End If
            filtro_Cliente += Row.Cells("Parametro").Value.ToString()
        Next

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

    Private Sub ExportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

    End Sub

    Private Sub VwReportePedidos_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwReportePedidos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

#End Region

End Class