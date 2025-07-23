Imports Infragistics.Win.UltraWinGrid

Public Class frmConsultaSimuladosDetalle
    Public folio As Int32
    Public semana As Int32
    Public anio As Int32
    Public idSimulacion As Int32
    Public simulacion As Boolean
    Public linea As String
    Public idNave As Int32
    Public idLinea As Int32

    Public Sub exportarExcel()
        Dim sfd As New SaveFileDialog
        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                exportExcelDetalle.Export(grdPedidos, fileName)
                Process.Start(fileName)
                Me.Cursor = Cursors.Default

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
    End Sub

    Public Sub llenarDatos()
        Dim dt As New DataTable
        lblSemana.Text = semana.ToString
        lblanio.Text = anio.ToString
        lblLineaProduccion.Text = linea
        If simulacion = True Then
            Dim objBU As New Negocios.SimulacionBU
            dt = objBU.consultaSimulacionPorSemana(semana, semana, anio, anio, idNave, idLinea, folio, idSimulacion, True)
        Else
            Dim objBU As New Negocios.ProgramasBU
            dt = objBU.consultaProgramaRenglonPorSemana(semana, semana, anio, anio, idNave, idLinea, True)
        End If
        If dt.Rows.Count > 0 Then
            grdPedidos.DataSource = dt

            grdPedidos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            With grdPedidos.DisplayLayout.Bands(0)
                .Columns("clie_clienteid").Hidden = True
                .Columns("prog_idCadena").Hidden = True
                .Columns("prog_naveID").Hidden = True
                .Columns("prog_linpID").Hidden = True
                .Columns("prog_productoID").Hidden = True
                .Columns("prog_productoEstiloID").Hidden = True
                .Columns("prog_tallaID").Hidden = True
                .Columns("prog_hormaId").Hidden = True
                .Columns("Nave").Hidden = True
                .Columns("Linea").Hidden = True
                .Columns("prog_año").Hidden = True
                .Columns("prog_semana").Hidden = True

                .Columns("clie_nombregenerico").Header.Caption = "Cliente"
                .Columns("prog_IdPedido").Header.Caption = "Pedido"
                .Columns("Producto").Header.Caption = "Artículo"
                .Columns("Horma").Header.Caption = "Horma"
                .Columns("prog_fechaEntregaPedido").Header.Caption = "Fecha Entrega"
                .Columns("prog_fechaCliente").Header.Caption = "Fecha Cliente"
                .Columns("prog_IdPedido").Header.Caption = "Pedido"
                .Columns("prog_idLote").Header.Caption = "Lote"

                .Columns("clie_nombregenerico").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Nave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Linea").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("prog_semana").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Producto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Horma").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("prog_fechaEntregaPedido").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("prog_fechaCliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("prog_año").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

                .Columns("prog_IdPedido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("prog_semana").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("prog_año").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("prog_idLote").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

                .Columns("prog_año").Width = 40
                .Columns("prog_semana").Width = 40
                .Columns("prog_fechaEntregaPedido").Width = 80
                .Columns("prog_fechaCliente").Width = 80
                .Columns("prog_idLote").Width = 50
                .Columns("prog_" + semana.ToString).Width = 50

                .Columns("prog_" + semana.ToString).Header.Caption = semana.ToString
                .Columns("prog_" + semana.ToString).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("prog_" + semana.ToString).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            End With
            grdPedidos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdPedidos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdPedidos.DisplayLayout.Override.RowSelectorWidth = 35
            grdPedidos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            grdPedidos.Rows(0).Selected = True
        End If
    End Sub

    Private Sub frmConsultaSimuladosDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarDatos()
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub btnGenerarReporte_Click(sender As Object, e As EventArgs) Handles btnGenerarReporte.Click
        If grdPedidos.Rows.Count > 0 Then
            exportarExcel()
        Else
            MsgBox("No hay registros que exportar", MsgBoxStyle.Information, "")
        End If
    End Sub

    Private Sub grdPedidos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdPedidos.InitializeLayout

    End Sub

    Private Sub lblExportarPDF_Click(sender As Object, e As EventArgs) Handles lblExportarPDF.Click

    End Sub
End Class