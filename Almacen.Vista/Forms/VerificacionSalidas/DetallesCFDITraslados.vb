Imports DevExpress.Export
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Tools

Public Class DetallesCFDITraslados

    Public folioEmbarque As String
    Public emisorEmbarque As String
    Private ReadOnly objBU As New Negocios.AdminCFDITrasladoBU

    Private Sub DetallesCFDITraslados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        Inicializar()
        InicializarEncabezado()
        InicializarDetalles()
    End Sub

#Region "Panel de Acciones"

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub BtnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreDocumento = "\ReporteDetallesTraslados_"

        If bgvDetallesDocumento.RowCount > 0 Then
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
                        grdDetallesDocumento.ExportToXlsx(.SelectedPath + nombreDocumento + fecha_hora + ".xlsx", exportOptions)
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

#Region "Panel Contenido"

    Private Sub BgvDetallesDocumento_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles bgvDetallesDocumento.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

#End Region

#Region "Metodos Privados"

    Private Sub Inicializar()

        grdDetallesDocumento.DataSource = Nothing
        bgvDetallesDocumento.Columns.Clear()

        lblCartaPorte.Text = "-"
        lblEmisor.Text = "-"
        lblEmbarque.Text = "-"
        lblUnidad.Text = "-"
        lblOperador.Text = "-"

        lblRegistroR.Text = "-"

        Dim folios = folioEmbarque.Split(",")

        If folios.Length > 1 Then
            GroupBox1.Visible = False
        End If

    End Sub

    Private Sub DiseñoDevGrid()

        bgvDetallesDocumento.IndicatorWidth = 50
        For Each col As Columns.GridColumn In bgvDetallesDocumento.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
            If (col.FieldName = "Pares Embarcados") Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "N0"
                DiseñoGrid.EstiloColumna(bgvDetallesDocumento, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, False, 100, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            Else
                If col.FieldName = "Fecha Creación" Or col.FieldName = "Fecha Timbrado" Then
                    DiseñoGrid.EstiloColumna(bgvDetallesDocumento, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "dd/MM/yyyy HH:mm:ss")
                Else
                    DiseñoGrid.EstiloColumna(bgvDetallesDocumento, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
                End If
            End If
        Next

        'vwAdminTraslado.OptionsView.ColumnAutoWidth = True
    End Sub

    Private Sub InicializarDetalles()
        Try
            Dim dtInfoDetlles As DataTable = objBU.ConsultaDetallesTraslado(folioEmbarque)
            If dtInfoDetlles.Rows.Count > 0 Then
                grdDetallesDocumento.DataSource = dtInfoDetlles
                DiseñoGrid.DiseñoBaseGrid(bgvDetallesDocumento)
                DiseñoDevGrid()

                lblRegistroR.Text = dtInfoDetlles.Rows.Count
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos para mostrar.")
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Error al consultar detalles.")
        End Try
    End Sub

    Private Sub InicializarEncabezado()
        Try
            Dim dtInfoEncabezado As DataTable = objBU.ConsultaEncabezadoTraslado(folioEmbarque)

            If dtInfoEncabezado.Rows.Count > 0 Then
                lblCartaPorte.Text = dtInfoEncabezado.Rows(0)(0).ToString
                lblEmbarque.Text = dtInfoEncabezado.Rows(0)(1).ToString
                lblEmisor.Text = dtInfoEncabezado.Rows(0)(2).ToString
                lblUnidad.Text = dtInfoEncabezado.Rows(0)(3).ToString
                lblOperador.Text = dtInfoEncabezado.Rows(0)(4).ToString
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos de encabezado.")
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Error al consultar detalles.")
        End Try
    End Sub

    Private Sub ExportOptions_CustomizeCell(e As CustomizeCellEventArgs)

    End Sub

#End Region

End Class