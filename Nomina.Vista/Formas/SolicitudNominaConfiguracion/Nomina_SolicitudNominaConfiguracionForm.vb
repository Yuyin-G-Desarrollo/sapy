Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Nomina.Negocios
Imports Tools

Public Class Nomina_SolicitudNominaConfiguracionForm
    Dim objAdvertencia As New AdvertenciaForm
    Dim objExito As New ExitoForm
    Dim objConfirmar As New ConfirmarForm
    Public enter As Boolean = False

    Private Sub Nomina_SolicitudNominaConfiguracionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarConfiguracionNomina()
    End Sub

    Public Sub CargarConfiguracionNomina()
        Dim objBU As New Nomina_SolicitudNominaConfiguracionBU
        Dim dtConfiguracion As New DataTable

        grdConfiguracionNomina.DataSource = Nothing
        MVConfiguracionNomina.Columns.Clear()

        Try
            Cursor = Cursors.WaitCursor
            dtConfiguracion = objBU.ObtenerConfiguracionNomina()
            grdConfiguracionNomina.DataSource = dtConfiguracion
            MVConfiguracionNomina.OptionsSelection.MultiSelect = True
            DisenoGrid()
            lblFechaUltimaActualización.Text = Date.Now
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub DisenoGrid()
        MVConfiguracionNomina.OptionsView.ColumnAutoWidth = False

        If IsNothing(MVConfiguracionNomina.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            MVConfiguracionNomina.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.Integer
            AddHandler MVConfiguracionNomina.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            MVConfiguracionNomina.Columns.Item("#").VisibleIndex = 0
        End If

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVConfiguracionNomina.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
        Next

        MVConfiguracionNomina.Columns.ColumnByFieldName("Nave").Caption = "Nave"
        MVConfiguracionNomina.Columns.ColumnByFieldName("Beneficiario").Caption = "Beneficiario"
        MVConfiguracionNomina.Columns.ColumnByFieldName("Periodo").Caption = "Concepto"
        MVConfiguracionNomina.Columns.ColumnByFieldName("Solicitud").Caption = "Solicitud"
        MVConfiguracionNomina.Columns.ColumnByFieldName("FechaConfiguración").Caption = "Fecha Actualización"

        MVConfiguracionNomina.Columns.ColumnByFieldName("PeriodoNominaID").Visible = False
        MVConfiguracionNomina.Columns.ColumnByFieldName("NaveID").Visible = False

        MVConfiguracionNomina.Columns.ColumnByFieldName("Nave").OptionsColumn.AllowEdit = False
        MVConfiguracionNomina.Columns.ColumnByFieldName("Periodo").OptionsColumn.AllowEdit = False
        MVConfiguracionNomina.Columns.ColumnByFieldName("FechaConfiguración").OptionsColumn.AllowEdit = False
        MVConfiguracionNomina.Columns.ColumnByFieldName("Solicitud").OptionsColumn.AllowEdit = False
        MVConfiguracionNomina.Columns.ColumnByFieldName("Beneficiario").OptionsColumn.AllowEdit = False

        MVConfiguracionNomina.Columns.ColumnByFieldName("#").Width = 20
        MVConfiguracionNomina.Columns.ColumnByFieldName("Nave").Width = 180
        MVConfiguracionNomina.Columns.ColumnByFieldName("Beneficiario").Width = 210
        MVConfiguracionNomina.Columns.ColumnByFieldName("Periodo").Width = 300
        MVConfiguracionNomina.Columns.ColumnByFieldName("Solicitud").Width = 130
        MVConfiguracionNomina.Columns.ColumnByFieldName("FechaConfiguración").Width = 110


        MVConfiguracionNomina.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways
    End Sub

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = MVConfiguracionNomina.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click_1(sender As Object, e As EventArgs) Handles btnMostrar.Click
        CargarConfiguracionNomina()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim editarConfiguracion As New EditarConfiguracionSolicituFinanzasForm
        Dim NumeroFilas = MVConfiguracionNomina.DataRowCount

        For index As Integer = 0 To NumeroFilas Step 1
            If CBool(MVConfiguracionNomina.GetRowCellValue(MVConfiguracionNomina.GetVisibleRowHandle(index), " ")) = True Or CBool(MVConfiguracionNomina.IsRowSelected(MVConfiguracionNomina.GetVisibleRowHandle(index))) = True Then
                editarConfiguracion.Beneficiario = MVConfiguracionNomina.GetRowCellValue(MVConfiguracionNomina.GetVisibleRowHandle(index), "Beneficiario")
                editarConfiguracion.TipoSolicitud = MVConfiguracionNomina.GetRowCellValue(MVConfiguracionNomina.GetVisibleRowHandle(index), "Solicitud")

                If editarConfiguracion.TipoSolicitud.ToString = "SOLO EFECTIVO" Then
                    editarConfiguracion.TipoSolicitud = "1"
                ElseIf editarConfiguracion.TipoSolicitud.ToString = "DEPÓSITO EFECTIVO Y CHEQUE" Then
                    editarConfiguracion.TipoSolicitud = "2"
                ElseIf editarConfiguracion.TipoSolicitud.ToString = "SOLO CHEQUES" Then
                    editarConfiguracion.TipoSolicitud = "3"
                ElseIf editarConfiguracion.TipoSolicitud.ToString = "DEPÓSITO CHEQUE Y EFECTIVO" Then
                    editarConfiguracion.TipoSolicitud = "4"
                End If

                editarConfiguracion.PeriodoNominaID = MVConfiguracionNomina.GetRowCellValue(MVConfiguracionNomina.GetVisibleRowHandle(index), "PeriodoNominaID")
                editarConfiguracion.NaveID = MVConfiguracionNomina.GetRowCellValue(MVConfiguracionNomina.GetVisibleRowHandle(index), "NaveID")
            End If
        Next
        editarConfiguracion.ShowDialog()
        btnMostrar_Click_1(Nothing, Nothing)
    End Sub

    Private Sub bntSalir_Click_1(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub
End Class