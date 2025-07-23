Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class CancelacionPedidos_ResultadoForm
    Public dtTemporalResultado As New DataTable
    Dim advertencia As New AdvertenciaForm
    Public PedidoSYAYID As String = String.Empty



    Private Sub CancelacionPedidos_ResultadoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objbu As New Ventas.Negocios.AdministradorPedidosEscritorioBU

        dtTemporalResultado = objbu.ObtenerResultadoCancelacion(PedidoSYAYID)
        PoblarResultadoCancelacion()
    End Sub

    Public Sub PoblarResultadoCancelacion()

        If dtTemporalResultado.Rows.Count > 0 Then
            grdResultadoCancelacion.DataSource = dtTemporalResultado
            Tools.DiseñoGrid.DiseñoBaseGrid(vwResultadoCancelacion)
            ' DiseñoGrid()
            lblRegistros.Text = vwResultadoCancelacion.RowCount.ToString("n0")
        Else
            advertencia.mensaje = "No hay información para mostrar."
            advertencia.ShowDialog()
        End If
    End Sub


    Private Sub DiseñoGrid_2()
        vwResultadoCancelacion.OptionsView.ColumnAutoWidth = False

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwResultadoCancelacion.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
        Next

        vwResultadoCancelacion.Columns.ColumnByFieldName("validado").Visible = False
        vwResultadoCancelacion.Columns.ColumnByFieldName("ordenesDeDesasignacion").Visible = False

        vwResultadoCancelacion.Columns.ColumnByFieldName("mensaje").Width = 600
        vwResultadoCancelacion.Columns.ColumnByFieldName("mensaje").Caption = "Observación"
        vwResultadoCancelacion.Columns.ColumnByFieldName("facturas").Width = 100
        vwResultadoCancelacion.Columns.ColumnByFieldName("facturas").Caption = "Facturas"
        vwResultadoCancelacion.Columns.ColumnByFieldName("otActivas").Width = 100
        vwResultadoCancelacion.Columns.ColumnByFieldName("otActivas").Caption = "OT Activas"
        vwResultadoCancelacion.Columns.ColumnByFieldName("partidasSinLotes").Width = 100
        vwResultadoCancelacion.Columns.ColumnByFieldName("partidasSinLotes").Caption = "Partidas sin Lotes"

        'vwResultadoCancelacion.OptionsView.ShowAutoFilterRow = False
        vwResultadoCancelacion.IndicatorWidth = 35

        vwResultadoCancelacion.OptionsView.ShowFooter = GroupFooterShowMode.Hidden

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub vwResultadoCancelacion_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwResultadoCancelacion.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub CancelacionPedidos_ResultadoForm_closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        Dim objbu As New Ventas.Negocios.AdministradorPedidosEscritorioBU
        objbu.LimpiarSessionPedido(PedidoSYAYID)
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarExcel()
    End Sub

    Private Sub ExportarExcel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            If vwResultadoCancelacion.RowCount > 0 Then
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If vwResultadoCancelacion.RowCount > 0 Then

                            'ESTO ES NECESARIO PARA QUE EL EXCEL NO HAGA QUE TODAS LAS CUADRICULAS SEAN MUY PEQUEÑAS.
                            'ESTO EXPORTARÁ TODAS LAS CUADRICULAS ESPACIADAS UNIFORMENTE.
                            vwResultadoCancelacion.OptionsPrint.AutoWidth = False
                            vwResultadoCancelacion.OptionsPrint.UsePrintStyles = False
                            vwResultadoCancelacion.ExportToXlsx(.SelectedPath + "\Datos_ResultadoCancelacionPedidos_" + fecha_hora + ".xlsx")
                            Tools.MostrarMensaje(Tools.Mensajes.Success, "Los datos se exportaron correctamente.")
                            Process.Start(.SelectedPath + "\Datos_ResultadoCancelacionPedidos_" + fecha_hora + ".xlsx")
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

End Class