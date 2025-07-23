Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraPrinting
Imports Tools
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Public Class PedidosMuestras_consultasMovimientosMuestras

    Public EntFiltros As Entidades.FiltrosEnvioRecepcionMuestras


    Dim fecha1 As Date
    Dim fecha2 As Date

    Private _DataConsulta As DataTable
    Public Property DataConsulta() As DataTable
        Get
            Return _DataConsulta
        End Get
        Set(ByVal value As DataTable)
            _DataConsulta = value
        End Set
    End Property

    Private Sub ResumenProductosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Cursor = Cursors.WaitCursor
        grdConsulta.DataSource = _DataConsulta
        DiseñoGrid(grdVConsulta)
        lblUltimaActualizacion.Text = Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub DiseñoGrid(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        If IsNothing(Grid.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            Grid.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler Grid.CustomUnboundColumnData, AddressOf grdVResumenP_CustomUnboundColumnData
            Grid.Columns.Item("#").VisibleIndex = 0
        End If
        Grid.OptionsView.ColumnAutoWidth = False
        Grid.BestFitColumns()


        Tools.DiseñoGrid.AjustarAltoEncabezados(Grid)
        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(Grid)
        Tools.DiseñoGrid.AlternarColorEnFilas(Grid)
        Tools.DiseñoGrid.DeshabilitarEdicion(Grid)
        Tools.DiseñoGrid.FiltroContiene(Grid)
        Grid.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        Grid.Columns.ColumnByFieldName("FMovimiento").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

        Grid.Columns.ColumnByFieldName("FMovimiento").Width = Grid.Columns.ColumnByFieldName("FMovimiento").GetBestWidth



        If IsNothing(Grid.Columns("Pieza").Summary.FirstOrDefault(Function(x) x.FieldName = "Pieza")) = True Then
            Grid.Columns("Pieza").Summary.Add(DevExpress.Data.SummaryItemType.Count, "Pieza", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pieza"
            item.SummaryType = DevExpress.Data.SummaryItemType.Count
            item.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item)
        End If


    End Sub

    Private Sub grdVResumenP_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = grdVConsulta.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreArchivo As String = String.Empty


        Try



            nombreArchivo = "Movimientos_Muestras"

            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then

                    If grdVConsulta.GroupCount > 0 Then
                        grdVConsulta.ExportToXlsx(.SelectedPath + "\Datos_" + nombreArchivo + "_" + fecha_hora + ".xlsx")
                        'grdPedidosMuestras.ExportToXlsx(.SelectedPath + "\" + fecha_hora + ".xlsx")
                    Else
                        Dim exportOptions = New XlsxExportOptionsEx()
                        'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                        grdVConsulta.ExportToXlsx(.SelectedPath + "\Datos_" + nombreArchivo + "_" + fecha_hora + ".xlsx", exportOptions)

                    End If
                    Controles.Mensajes_Y_Alertas("EXITO", "Los datos se exportaron correctamente.")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_" + nombreArchivo + "_" + fecha_hora + ".xlsx")
                End If

            End With
        Catch ex As Exception
            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = ex.Message
            mensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New Negocios.EnvioRecepcionMuestrasBU
        Dim dtConsulta As DataTable = Nothing
        Try
            dtConsulta = objBU.ConsultaMovimientosMuestras(EntFiltros)
            If Not IsNothing(dtConsulta) Then
                If dtConsulta.Rows.Count > 0 Then
                    grdConsulta.DataSource = Nothing
                    grdVConsulta.Columns.Clear()
                    grdConsulta.DataSource = dtConsulta
                    DiseñoGrid(grdVConsulta)
                    lblUltimaActualizacion.Text = Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString
                End If
            End If
        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)

    End Sub
End Class