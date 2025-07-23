Imports DevExpress
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class AdministradorFoliosCancelacionDetalle_Form

#Region "Variables"
    Private folioCancelacionId As String = String.Empty
    Private objBu As New Negocios.FolioCancelacionBU
#End Region

    Private Sub AdministradorFoliosCancelacionDetalle_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObtenerDetalleFolios()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

#Region "Metodos"
    Public Sub AsignarFolioCancelacionId(folioCancelacionId As String)
        Me.folioCancelacionId = folioCancelacionId
    End Sub

    Private Sub ObtenerDetalleFolios()
        Dim dtResultado As New DataTable
        Try
            Cursor = Cursors.WaitCursor
            dtResultado = objBu.ConsultarFoliosDetalle(folioCancelacionId)

            If dtResultado.Rows.Count > 0 Then
                'dtResultado.DefaultView.Sort = "pedidoSAY DESC"
                grdFoliosDetalle.DataSource = dtResultado
                DisenioGrid()
            Else
                Tools.MostrarMensaje(Tools.Mensajes.Notice, "No se encontraron resultados.")
            End If

            ActualizarConteoyFechaConsulta()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Tools.Mensajes.Notice, "No se encontraron resultados.")
        End Try


    End Sub

    Private Sub ActualizarConteoyFechaConsulta()
        lblRegistros.Text = grdDatosFoliosDetalle.RowCount.ToString("n0")
        lblUltimaActualizacion.Text = Now()
    End Sub
#End Region

#Region "Disenio"
    Private Sub DisenioGrid()
        Tools.DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatosFoliosDetalle)

        grdDatosFoliosDetalle.Columns("folioCancelacion").Caption = "Folio" + vbCrLf + "Cancelación"
        grdDatosFoliosDetalle.Columns("partidaPedido").Caption = "Partida"
        grdDatosFoliosDetalle.Columns("articulo").Caption = "Artículo"
        grdDatosFoliosDetalle.Columns("paresPedido").Caption = "P Pedido"
        grdDatosFoliosDetalle.Columns("paresOrdenTrabajo").Caption = "P Orden" + vbCrLf + "Trabajo"
        grdDatosFoliosDetalle.Columns("ordenTrabajo").Caption = "Orden" + vbCrLf + "Trabajo"

        grdDatosFoliosDetalle.Columns("paresPedido").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosFoliosDetalle.Columns("paresPedido").DisplayFormat.FormatString = "n0"
        grdDatosFoliosDetalle.Columns("paresOrdenTrabajo").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosFoliosDetalle.Columns("paresOrdenTrabajo").DisplayFormat.FormatString = "n0"

        CrearSummarAlPiePantalla()

        grdDatosFoliosDetalle.BestFitColumns()
    End Sub

    Private Sub CrearSummarAlPiePantalla()
        Dim item As GridGroupSummaryItem
        Dim str As String = String.Empty

        grdDatosFoliosDetalle.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        grdDatosFoliosDetalle.GroupSummary.Clear()

        For index = 0 To grdDatosFoliosDetalle.Columns.Count - 1
            If grdDatosFoliosDetalle.Columns(index).DisplayFormat.FormatType = Utils.FormatType.Numeric Then
                item = New GridGroupSummaryItem

                str = grdDatosFoliosDetalle.Columns(index).Name.Replace("col", "")

                grdDatosFoliosDetalle.Columns(index).Summary.Clear()
                grdDatosFoliosDetalle.Columns(index).Summary.Add(Data.SummaryItemType.Sum, str, "{0:" + grdDatosFoliosDetalle.Columns(index).DisplayFormat.FormatString + "}")

                item.FieldName = str
                item.ShowInGroupColumnFooter = grdDatosFoliosDetalle.Columns("c")
                item.SummaryType = Data.SummaryItemType.Sum
                item.DisplayFormat = "Total {0:N}"
                grdDatosFoliosDetalle.GroupSummary.Add(item)
            End If
        Next

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarExcel()
    End Sub

    Private Sub ExportarExcel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            If grdDatosFoliosDetalle.RowCount > 0 Then
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If grdDatosFoliosDetalle.RowCount > 0 Then

                            'ESTO ES NECESARIO PARA QUE EL EXCEL NO HAGA QUE TODAS LAS CUADRICULAS SEAN MUY PEQUEÑAS.
                            'ESTO EXPORTARÁ TODAS LAS CUADRICULAS ESPACIADAS UNIFORMENTE.
                            grdDatosFoliosDetalle.OptionsPrint.AutoWidth = False
                            grdDatosFoliosDetalle.OptionsPrint.UsePrintStyles = False

                            Dim FileName As String = .SelectedPath + "\Datos_FoliosCancelacionDetalle_" + fecha_hora + ".xlsx"

                            Export.ExportSettings.DefaultExportType = Export.ExportType.WYSIWYG
                            grdDatosFoliosDetalle.ExportToXlsx(FileName)

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

    Private Sub grdDatosFoliosDetalle_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdDatosFoliosDetalle.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
#End Region
End Class