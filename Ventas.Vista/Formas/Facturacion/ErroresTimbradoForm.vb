Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
'Imports XtraReportSerialization
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.ReportGeneration
Imports Tools

Public Class ErroresTimbradoForm

    Dim objBU As New Facturacion.Negocios.TimbradoFacturasBU
    Public DocumentoID As String = String.Empty
    Public TipoComprobante As String = String.Empty

    Private Sub ErroresTimbradoForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        MostarErroresTimbradoDocumento()
    End Sub

    Private Sub MostarErroresTimbradoDocumento()
        Dim dtInformacion As DataTable
        Try
            dtInformacion = objBU.ConsultarErroresTimbrado(DocumentoID, TipoComprobante)
            grdErroresTimbrado.DataSource = dtInformacion
            DiseñoGrid()
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
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
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub DiseñoGrid()
        vwMotivosError.OptionsView.ColumnAutoWidth = True

        If IsNothing(vwMotivosError.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            vwMotivosError.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler vwMotivosError.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            vwMotivosError.Columns.Item("#").VisibleIndex = 0
            vwMotivosError.Columns.Item("#").Width = 20
        End If

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwMotivosError.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next



        vwMotivosError.Columns.ColumnByFieldName("DocumentoSAY").Width = 80
        vwMotivosError.Columns.ColumnByFieldName("TotalPares").Width = 60
        vwMotivosError.Columns.ColumnByFieldName("Total").Width = 80
        vwMotivosError.Columns.ColumnByFieldName("MotivoError").Width = 300

        vwMotivosError.Columns.ColumnByFieldName("DocumentoSAY").Caption = "Documento SAY"
        vwMotivosError.Columns.ColumnByFieldName("TotalPares").Caption = "Total Pares"
        vwMotivosError.Columns.ColumnByFieldName("Total").Caption = "Total"
        vwMotivosError.Columns.ColumnByFieldName("MotivoError").Caption = "Motivo Error"

        vwMotivosError.Columns.ColumnByFieldName("DocumentoSAY").OptionsColumn.AllowSize = True
        vwMotivosError.Columns.ColumnByFieldName("TotalPares").OptionsColumn.AllowSize = True
        vwMotivosError.Columns.ColumnByFieldName("Total").OptionsColumn.AllowSize = True
        vwMotivosError.Columns.ColumnByFieldName("MotivoError").OptionsColumn.AllowSize = True


        If IsNothing(vwMotivosError.Columns("TotalPares").Summary.FirstOrDefault(Function(x) x.FieldName = "TotalPares")) = True Then
            vwMotivosError.Columns("TotalPares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalPares", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "TotalPares"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwMotivosError.GroupSummary.Add(item)
        End If


        vwMotivosError.Columns.ColumnByFieldName("DocumentoSAY").OptionsColumn.AllowEdit = False
        vwMotivosError.Columns.ColumnByFieldName("TotalPares").OptionsColumn.AllowEdit = False
        vwMotivosError.Columns.ColumnByFieldName("Total").OptionsColumn.AllowEdit = False
        vwMotivosError.Columns.ColumnByFieldName("MotivoError").OptionsColumn.AllowEdit = False

    End Sub

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = vwMotivosError.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub


End Class