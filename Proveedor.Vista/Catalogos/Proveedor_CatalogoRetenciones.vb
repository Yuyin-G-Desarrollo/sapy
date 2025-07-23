Imports DevExpress.XtraGrid
Imports Proveedores.BU

Public Class Proveedor_CatalogoRetenciones
    Dim Accion As Integer = 0
    Dim objBU As New CatalogoRetencionesBU

    Private Sub Proveedor_CatalogoRetenciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnMostrar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim altaEdicion As New Proveedor_AltaEdicion_CatalogoRetenciones
        altaEdicion.chSI = 1
        altaEdicion.ShowDialog()
        btnMostrar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim altaEdicion As New Proveedor_AltaEdicion_CatalogoRetenciones
        Dim Contador As Integer = 0

        For index As Integer = 0 To vwRetencion.DataRowCount
            If vwRetencion.GetRowCellValue(index, " ") Then
                Contador += 1
                altaEdicion.RetencionID = vwRetencion.GetRowCellValue(index, "RetencionID")
            End If
        Next

        If Contador <> 1 Then
            Tools.MostrarMensaje(Tools.modMensajes.Mensajes.Warning, "Seleccione un registro para editar.")
            Exit Sub
        End If

        altaEdicion.ShowDialog()
        btnMostrar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim dtRetenciones As New DataTable

        dtRetenciones = objBU.ObtenerRetenciones(0)
        If dtRetenciones.Rows.Count > 0 Then
            grdRetencion.DataSource = Nothing
            vwRetencion.Columns.Clear()

            grdRetencion.DataSource = dtRetenciones
            lblUltimaActualizacion.Text = Date.Now
            DiseñoGrid()
        Else
            Tools.MostrarMensaje(Tools.modMensajes.Mensajes.Warning, "No hay información para mostrar.")
        End If
    End Sub

    Private Sub DiseñoGrid()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwRetencion.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName <> " " Then
                col.OptionsColumn.AllowEdit = False
            Else
                col.OptionsColumn.AllowEdit = True
            End If
        Next

        vwRetencion.Columns.ColumnByFieldName("RetencionID").Visible = False

        Tools.DiseñoGrid.AjustarAltoEncabezados(vwRetencion)
        Tools.DiseñoGrid.AjustarAnchoColumnas(vwRetencion)
        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(vwRetencion)
        Tools.DiseñoGrid.AlternarColorEnFilas(vwRetencion)
    End Sub

    Private Sub bntCerrar_Click(sender As Object, e As EventArgs) Handles bntCerrar.Click
        Me.Close()
    End Sub
End Class