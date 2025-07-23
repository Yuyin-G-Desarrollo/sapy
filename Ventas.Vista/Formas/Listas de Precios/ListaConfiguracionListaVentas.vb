Imports Infragistics.Win.UltraWinGrid

Public Class ListaConfiguracionListaVentas
    Public idClienteSAY As Int32
    Public idClienteSICY As String
    Public idListaVentas As Int32

    Public Sub llenarDatosCliente()
        lblIdSay.Text = idClienteSAY.ToString
        lblIdSIcy.Text = idClienteSICY
    End Sub

    Public Sub llenarDatosConfiguracion()
        Dim objLVBU As New Negocios.ListaVentasBU
        Dim dtDescuentos As New DataTable
        Dim dtConfiguracion As New DataTable
        dtConfiguracion = objLVBU.verDatosConfiguradosListaClienteActiva(idClienteSAY, idListaVentas)
        dtDescuentos = objLVBU.consultaDescuentosConfiguracionCliente(idClienteSAY, idListaVentas)
        If dtConfiguracion.Rows.Count > 0 Then
            txtNombreCLiente.Text = dtConfiguracion.Rows(0).Item("clie_nombregenerico").ToString
            txtTipoIva.Text = dtConfiguracion.Rows(0).Item("tiva_nombre").ToString
            txtFlete.Text = dtConfiguracion.Rows(0).Item("tifl_nombre").ToString
            txtFacturacion.Text = dtConfiguracion.Rows(0).Item("ccla_facturar").ToString
        End If
        If dtDescuentos.Rows.Count > 0 Then
            grdDescuentos.DataSource = dtDescuentos
           
            With grdDescuentos.DisplayLayout.Bands(0)
                .Columns("cdlv_clienteid").Hidden = True
                .Columns("cdlv_lugardescuentoid").Hidden = True
                .Columns("mode_motivodescuentoid").Hidden = True
                .Columns("lude_nombre").Header.Caption = "Lugar"
                .Columns("mode_nombre").Header.Caption = "Motivo"
                .Columns("cdlv_encadenado").Header.Caption = "Encadenado"
                .Columns("cdlv_cantidad").Header.Caption = "Cantidad"
                .Columns("cdlv_porcentaje").Header.Caption = "%"
                .Columns("cdlv_diasvigencia").Header.Caption = "Días"
                .Columns("lude_nombre").CellActivation = Activation.NoEdit
                .Columns("mode_nombre").CellActivation = Activation.NoEdit
                .Columns("cdlv_encadenado").CellActivation = Activation.NoEdit
                .Columns("cdlv_cantidad").CellActivation = Activation.NoEdit
                .Columns("cdlv_porcentaje").CellActivation = Activation.NoEdit
                .Columns("cdlv_diasvigencia").CellActivation = Activation.NoEdit
                .Columns("cdlv_cantidad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("cdlv_diasvigencia").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            End With
            grdDescuentos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdDescuentos.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.VisibleIndex
        Else
            grdDescuentos.Visible = False
            Me.Height = 285
        End If
    End Sub
    Private Sub ListaConfiguracionListaVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarDatosCliente()
        llenarDatosConfiguracion()
    End Sub

    Private Sub lblCancelar_Click(sender As Object, e As EventArgs) Handles lblCancelar.Click

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class