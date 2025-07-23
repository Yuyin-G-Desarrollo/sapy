Imports DevExpress
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class FacturacionAnticipada_ReporteParesTiendaCoppel_Form
#Region "Variables"
    Dim datos As DataTable
    Dim objBu As New Negocios.FacturacionAnticipadaCoppelBU
    Private repositorioChkSeleccionar As New RepositoryItemCheckEdit
#End Region

    Private Sub Mostrar()
        grdReportePares.DataSource = datos
        DisenioGrid()
        LlenarPanelesPares()
        CrearSummarAlPiePantalla()
        lblUltimaActualizacion.Text = DateTime.Now.ToString
    End Sub

    Public Sub PasarDatos(d As DataTable)
        datos = d
        Mostrar()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

#Region "Diseño Grid"
    Private Sub DisenioGrid()
        Tools.DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatosReportePares)

        For i = 0 To grdDatosReportePares.Columns.Count - 1
            grdDatosReportePares.Columns(i).OptionsColumn.AllowEdit = False
        Next

        grdDatosReportePares.Columns("TotalPares").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosReportePares.Columns("TotalPares").DisplayFormat.FormatString = "n0"

        grdDatosReportePares.BestFitColumns()

        grdDatosReportePares.Columns("OrdenTrabajoID").Width = 150
        'grdDatosReportePares.Columns("EstatusPedido").Caption = "Estatus Pedido"
        'grdDatosReportePares.Columns("PedidoSAY").Caption = "Pedido SAY"
        'grdDatosReportePares.Columns("PedidoSICY").Caption = "Pedido SICY"
        'grdDatosReportePares.Columns("OrdenCliente").Caption = "Orden Cliente"
        'grdDatosReportePares.Columns("DiasEntrega").Caption = "Días Entrega"
        'grdDatosReportePares.Columns("EstatusDistribucion").Caption = "Estatus Distribución"
        'grdDatosReportePares.Columns("ParesPedido").Caption = "Pares Pedido"
        'grdDatosReportePares.Columns("ParesCanceladosPedido").Caption = "Pares Cancelados Pedido"
        'grdDatosReportePares.Columns("ParesArchivo").Caption = "Pares Archivo"
        'grdDatosReportePares.Columns("ParesConfirmados").Caption = "Pares Confirmados"
        'grdDatosReportePares.Columns("ParesConfirmados").Visible = False
        'grdDatosReportePares.Columns("ParesPendientes").Caption = "Pares Pendientes"
        'grdDatosReportePares.Columns("ParesCancelados").Caption = "Pares Cancelados"
        'grdDatosReportePares.Columns("CantidadOT").Caption = "Cantidad OT"
        'grdDatosReportePares.Columns("FechaImportacion").Caption = "Fecha Importación"
        'grdDatosReportePares.Columns("UsuarioImporto").Caption = "Usuario Importó"
        ''grdDatosDistribuciones.Columns("CodigoRapidoCliente").Caption = "Código"
        ''grdDatosDistribuciones.Columns("CantidadPedida").Caption = "Cant. Pedida"
        ''grdDatosDistribuciones.Columns("CantidadSurtida").Caption = "Cant. Surtida"
        ''grdDatosDistribuciones.Columns("OrdenCliente").Caption = "OC"
        ''grdDatosDistribuciones.Columns("OrdenTrabajoID").Caption = "Orden Trabajo"

        'grdDatosReportePares.Columns("ParesPedido").DisplayFormat.FormatType = Utils.FormatType.Numeric
        'grdDatosReportePares.Columns("ParesPedido").DisplayFormat.FormatString = "n0"
        'grdDatosReportePares.Columns("ParesCanceladosPedido").DisplayFormat.FormatType = Utils.FormatType.Numeric
        'grdDatosReportePares.Columns("ParesCanceladosPedido").DisplayFormat.FormatString = "n0"
        'grdDatosReportePares.Columns("ParesArchivo").DisplayFormat.FormatType = Utils.FormatType.Numeric
        'grdDatosReportePares.Columns("ParesArchivo").DisplayFormat.FormatString = "n0"
        'grdDatosReportePares.Columns("ParesPendientes").DisplayFormat.FormatType = Utils.FormatType.Numeric
        'grdDatosReportePares.Columns("ParesPendientes").DisplayFormat.FormatString = "n0"


        'grdDatosReportePares.Columns("Seleccionar").ColumnEdit = repositorioChkSeleccionar


    End Sub
#End Region

    Private Sub LlenarPanelesPares()
        Dim resultado As DataTable
        Dim pedidoSAY As Integer = 0

        pedidoSAY = CInt(datos.Rows(0)("PedidoSAY").ToString)
        resultado = objBu.ConsultarDetallePares(pedidoSAY)

        If resultado.Rows.Count > 0 Then
            lblParesPedido.Text = String.Format("{0:N0}", resultado.Rows(0)("ParesPedido"))
            lblParesDistribuidos.Text = String.Format("{0:N0}", resultado.Rows(0)("ParesDistribuidos"))
            lblParesPendientes.Text = String.Format("{0:N0}", resultado.Rows(0)("ParesPendientes"))
            lblParesBodegaLeon.Text = String.Format("{0:N0}", resultado.Rows(0)("BODEGA LEÓN"))
            lblParesBodegaTecamac.Text = String.Format("{0:N0}", resultado.Rows(0)("BODEGA TECAMAC"))
            lblParesBodegaPuebla.Text = String.Format("{0:N0}", resultado.Rows(0)("BODEGA PUEBLA"))
            Disenio_Grid()
        End If

    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        ExportarExcel()
    End Sub

    Private Sub ExportarExcel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            If grdDatosReportePares.RowCount > 0 Then
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        'If grdDatosDistribuciones.GroupCount > 0 Then
                        '    grdDatosDistribuciones.ExportToXlsx(.SelectedPath + "\Datos_DistribucionesCoppel_" + fecha_hora + ".xlsx")
                        'Else
                        '    Dim exportOptions = New XlsxExportOptionsEx()
                        '    grdDatosDistribuciones.ExportToXlsx(.SelectedPath + "\Datos_DistribucionesCoppel_" + fecha_hora + ".xlsx", exportOptions)

                        'End If

                        'show_message("Exito", "Los datos se exportaron correctamente: " & "Datos_DistribucionesCoppel_" & fecha_hora.ToString() & ".xlsx")

                        '.Dispose()

                        'Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_DistribucionesCoppel_" + fecha_hora + ".xlsx")

                        If grdDatosReportePares.RowCount > 0 Then

                            'ESTO ES NECESARIO PARA QUE EL EXCEL NO HAGA QUE TODAS LAS CUADRICULAS SEAN MUY PEQUEÑAS.
                            'ESTO EXPORTARÁ TODAS LAS CUADRICULAS ESPACIADAS UNIFORMENTE.
                            grdDatosReportePares.OptionsPrint.AutoWidth = False
                            grdDatosReportePares.OptionsPrint.UsePrintStyles = False
                            'Grid.OptionsPrint.EnableAppearanceEvenRow = True
                            'Grid.OptionsPrint.EnableAppearanceOddRow = True
                            'Grid.OptionsPrint.PrintHorzLines = False
                            'Grid.OptionsPrint.PrintVertLines = False

                            'Grid.OptionsPrint.PrintPreview = True

                            Dim FileName As String = .SelectedPath + "\Datos_DistribucionesCoppel_ReporteParesBodega" + fecha_hora + ".xlsx"

                            'Dim exportOptions = New DevExpress.XtraPrinting.XlsxExportOptionsEx
                            'exportOptions.AllowConditionalFormatting = True
                            'exportOptions.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True
                            'exportOptions.ExportType = DevExpress.Export.ExportType.DataAware
                            DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG
                            grdDatosReportePares.ExportToXlsx(FileName)

                            show_message("Exito", "Los datos se exportaron correctamente.")

                            Process.Start(FileName)

                        Else
                            show_message("Exito", "No hay registros para exportar.")
                        End If
                    End If
                End With
            Else
                show_message("Advertencia", "No hay datos para exportar")
            End If
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

#Region "Mensajes"
    Public Function show_message(ByVal tipo As String, ByVal mensaje As String) As DialogResult
        Dim result As DialogResult

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then

            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then
            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje

            result = mensajeExito.ShowDialog()
        End If

        Return result
    End Function
#End Region

    Private Sub CrearSummarAlPiePantalla()
        grdDatosReportePares.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        grdDatosReportePares.GroupSummary.Clear()
        grdDatosReportePares.Columns("TotalPares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalPares", "{0:N0}")

        Dim item As New GridGroupSummaryItem
        item.FieldName = "TotalPares"
        item.ShowInGroupColumnFooter = grdDatosReportePares.Columns("TotalPares")
        item.SummaryType = Data.SummaryItemType.Sum
        item.DisplayFormat = "Total {0:N}"
        grdDatosReportePares.GroupSummary.Add(item)
    End Sub

    Private Sub grdDatosReportePares_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdDatosReportePares.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub Disenio_Grid()

        For i = 1 To grdDatosReportePares.Columns.Count - 1
            grdDatosReportePares.Columns(i).OptionsColumn.AllowEdit = False
        Next

        grdDatosReportePares.Columns("PedidoSAY").Caption = "Pedido SAY"
        grdDatosReportePares.Columns("PedidoSICY").Caption = "Pedido SICY"
        grdDatosReportePares.Columns("OrdenCliente").Caption = "Orden Cliente"
        grdDatosReportePares.Columns("FechaCapturaOT").Caption = "Fecha Captura"
        grdDatosReportePares.Columns("FechaEntrega").Caption = "Fecha Entrega"
        grdDatosReportePares.Columns("OrdenTrabajoID").Caption = "Orden(es) Trabajo"
        grdDatosReportePares.Columns("NombreTiendaCoppel").Caption = "Nombre Tienda Coppel"
        grdDatosReportePares.Columns("TotalPares").Caption = "Total Pares"
    End Sub
End Class