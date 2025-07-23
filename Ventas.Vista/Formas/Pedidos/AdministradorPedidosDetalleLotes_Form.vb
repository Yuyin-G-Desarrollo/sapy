Imports DevExpress
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class AdministradorPedidosDetalleLotes_Form
    Private objBu As New Negocios.AdministradorPedidosEscritorioBU
    Private pedidoSICY As Integer = 0
    Private partidas As String = String.Empty

    Private Sub AdministradorPedidosDetalleLotes_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RecuperarInformacionLotes()
    End Sub

    Private Sub RecuperarInformacionLotes()
        Dim dtInformacionLotes As New DataTable
        Cursor = Cursors.WaitCursor
        dtInformacionLotes = objBu.Consultar_InformacionLotes(pedidoSICY, partidas)

        If dtInformacionLotes.Rows.Count > 0 Then
            grdLotes.DataSource = dtInformacionLotes
            DisenioGrid()
        End If

        ActualizarConteoyFechaConsulta()
        Cursor = Cursors.Default
    End Sub

    Public Sub AsignarPedidoSICY(pedidoSICY As Integer)
        Me.pedidoSICY = pedidoSICY
    End Sub

    Public Sub AsignarPartidas(partidas As String)
        Me.partidas = partidas
    End Sub

    Private Sub DisenioGrid()
        Tools.DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatosLotes)

        grdDatosLotes.Columns("partida").Caption = "Partida"
        grdDatosLotes.Columns("lote").Caption = "Lote"
        grdDatosLotes.Columns("fechaCorte").Caption = "F Corte"
        grdDatosLotes.Columns("fechaSalida").Caption = "F Entrada" + vbCrLf + "Almacén"
        grdDatosLotes.Columns("articulo").Caption = "Artículo"
        grdDatosLotes.Columns("cantidad").Caption = "Pares"
        grdDatosLotes.Columns("estatus").Caption = "Estatus"
        grdDatosLotes.Columns("nave").Caption = "Nave"

        grdDatosLotes.Columns("cantidad").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosLotes.Columns("cantidad").DisplayFormat.FormatString = "n0"

        grdDatosLotes.Columns("articulo").BestFit()

        CrearSummarAlPiePantalla(grdDatosLotes)

        grdDatosLotes.BestFitColumns()
    End Sub

    Private Sub CrearSummarAlPiePantalla(grid As GridView)
        Dim item As GridGroupSummaryItem
        Dim str As String = String.Empty

        grid.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        grid.GroupSummary.Clear()

        For index = 0 To grid.Columns.Count - 1
            If grid.Columns(index).DisplayFormat.FormatType = Utils.FormatType.Numeric Then
                item = New GridGroupSummaryItem

                str = grid.Columns(index).Name.Replace("col", "")

                grid.Columns(index).Summary.Clear()
                grid.Columns(index).Summary.Add(Data.SummaryItemType.Sum, str, "{0:" + grid.Columns(index).DisplayFormat.FormatString + "}")

                item.FieldName = str
                item.ShowInGroupColumnFooter = grid.Columns("c")
                item.SummaryType = Data.SummaryItemType.Sum
                item.DisplayFormat = "Total {0:N}"
                grid.GroupSummary.Add(item)
            End If
        Next

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub ActualizarConteoyFechaConsulta()
        lblRegistros.Text = grdDatosLotes.RowCount.ToString("n0")
        lblUltimaActualizacion.Text = Now()
    End Sub

    Private Sub ExportarExcel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            If grdDatosLotes.RowCount > 0 Then
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If grdDatosLotes.RowCount > 0 Then

                            'ESTO ES NECESARIO PARA QUE EL EXCEL NO HAGA QUE TODAS LAS CUADRICULAS SEAN MUY PEQUEÑAS.
                            'ESTO EXPORTARÁ TODAS LAS CUADRICULAS ESPACIADAS UNIFORMENTE.
                            grdDatosLotes.OptionsPrint.AutoWidth = False
                            grdDatosLotes.OptionsPrint.UsePrintStyles = False

                            Dim FileName As String = .SelectedPath + "\Datos_Pedidos_Detalle" + fecha_hora + ".xlsx"

                            Export.ExportSettings.DefaultExportType = Export.ExportType.WYSIWYG
                            grdDatosLotes.ExportToXlsx(FileName)

                            Tools.MostrarMensaje(Tools.Mensajes.Success, "Los datos se exportaron correctamente.")

                            Process.Start(FileName)

                        Else
                            Tools.MostrarMensaje(Tools.Mensajes.Notice, "No hay registros para exportar.")
                        End If
                    End If
                End With
            Else
                Tools.MostrarMensaje(Tools.Mensajes.Notice, "No hay datos para exportar")
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Tools.Mensajes.Fault, "No se pudo exportar los datos: " + ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarExcel()
    End Sub

    Private Sub grdDatosLotes_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdDatosLotes.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
End Class