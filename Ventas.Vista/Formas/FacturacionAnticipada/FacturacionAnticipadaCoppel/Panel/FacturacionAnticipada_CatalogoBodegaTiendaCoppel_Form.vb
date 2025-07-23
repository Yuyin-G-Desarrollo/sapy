Imports Entidades

Public Class FacturacionAnticipada_CatalogoBodegaTiendaCoppel_Form

#Region "Variable"
    Dim objBU As New Negocios.FacturacionAnticipadaCoppelBU
    Dim auxTiendas As List(Of TiendaCoppel)
#End Region

    Private Sub FacturacionAnticipada_CatalogoBodegaTiendaCoppel_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Mostrar()
    End Sub

    Private Sub Mostrar()
        Dim bodegas As DataTable
        Dim tiendas As DataTable

        Cursor = Cursors.WaitCursor
        grdBodegas.DataSource = Nothing
        grdTiendas.DataSource = Nothing

        bodegas = objBU.ConsultarBodegas
        tiendas = objBU.ConsultarTiendas


        ConvertirEntidadBodega(bodegas, tiendas)

        If bodegas.Rows.Count > 0 Then
            Dim v As DataView = bodegas.DefaultView
            'v.Sort = "FechaDocumento"
            grdBodegas.DataSource = bodegas
            Disenio_Grid()
            'OcultarFiltros()
        Else
            grdDatosTiendas.Columns.Clear()
            grdTiendas.DataSource = auxTiendas
        End If

        Cursor = Cursors.Default


    End Sub

    Private Sub Disenio_Grid()
        Tools.DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatosBodegas)

        grdDatosBodegas.Columns(0).OptionsColumn.AllowEdit = True

        grdDatosBodegas.BestFitColumns()
    End Sub

    Private Sub Disenio_GridTiendas()
        Tools.DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatosTiendas)

        grdDatosTiendas.BestFitColumns()
    End Sub

    Private Sub ConvertirEntidadBodega(dtBodegas As DataTable, dtTiendas As DataTable)
        Dim listTienda As New List(Of TiendaCoppel)


        For Each row In dtTiendas.Rows
            Dim tienda As New TiendaCoppel
            tienda.BodegaId = CInt(row("BodegaID").ToString)
            tienda.Id = CInt(row("TiendaID").ToString)
            tienda.Cliente = row("Cliente").ToString
            tienda.Nombre = row("NombreTienda").ToString
            tienda.Tipo = row("Tipo").ToString
            tienda.Activo = CBool(row("Activo").ToString)
            tienda.Vinculado = CBool(row("Vinculado").ToString)
            tienda.Bodega = row("Bodega").ToString
            listTienda.Add(tienda)
        Next

        auxTiendas = listTienda

    End Sub

    Private Function ConvertirTiendaPorBodega(idBodega As Integer, tiendas As List(Of TiendaCoppel)) As List(Of TiendaCoppel)
        Dim list As List(Of TiendaCoppel)

        Dim Query = (From d In tiendas
                     Where d.BodegaId = idBodega)

        list = Query.ToList

        Return list
    End Function

    Private Sub grdDatosBodegas_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles grdDatosBodegas.RowClick
        Dim idBodega As Integer = grdDatosBodegas.GetRowCellValue(e.RowHandle, "BodegaID")
        grdTiendas.DataSource = ConvertirTiendaPorBodega(idBodega, auxTiendas)
        Disenio_GridTiendas()
    End Sub

    Private Sub btnAltaBodega_Click(sender As Object, e As EventArgs) Handles btnAltaBodega.Click
        AbrirDetalleGuardar()
        Mostrar()
    End Sub

    Private Sub AbrirDetalleGuardar()
        Dim detalle As New FacturacionAnticipada_DetalleBodegaTiendaCoppel_Form
        detalle.ShowDialog()
    End Sub

    Private Sub AbrirDetalleEditar()
        Dim detalle As New FacturacionAnticipada_DetalleBodegaTiendaCoppel_Form
        Dim bodega As New BodegaCoppel
        Dim renglon As Integer

        If grdDatosBodegas.GetSelectedRows.Count > 0 Then
            renglon = grdDatosBodegas.GetSelectedRows(0)
            bodega.Id = grdDatosBodegas.GetRowCellValue(renglon, "BodegaID")
            bodega.Nombre = grdDatosBodegas.GetRowCellValue(renglon, "NombreBodega")
        Else
            Return
        End If

        detalle.PasarBodega(bodega)
        detalle.ShowDialog()
    End Sub

    Private Sub btnVincularTienda_Click(sender As Object, e As EventArgs) Handles btnVincularTienda.Click
        AbrirDetalleEditar()
    End Sub

    Private Sub grdDatosBodegas_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdDatosBodegas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub grdDatosTiendas_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdDatosTiendas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class