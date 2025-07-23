Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Proveedores.BU
Imports Stimulsoft.Report
Imports Tools

Public Class Mercadotecnia_OrdenCompra_MaterialesForm
    Dim advertencia As New AdvertenciaForm
    Dim exito As New ExitoForm
    Dim confirmar As New ConfirmarForm
    Private Sub Mercadotecnia_OrdenCompra_MaterialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        obtenerOrdenesCompra()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        obtenerOrdenesCompra()
    End Sub

    Public Sub obtenerOrdenesCompra()
        grdSolicitudesPOP.DataSource = Nothing

        Dim objBU As New MercadotecniaBU
        Dim dtObtieneOrdenesCompra As New DataTable

        Cursor = Cursors.WaitCursor
        'dtObtieneOrdenesCompra = objBU.ObtieneOrdenesCompra()

        dtObtieneOrdenesCompra = objBU.ObtieneOrdenesCompraEncabezado()

        If dtObtieneOrdenesCompra.Rows.Count > 0 Then
            grdSolicitudesPOP.DataSource = dtObtieneOrdenesCompra
            DiseñoGrid()
            lblFechaUltimaActualización.Text = Date.Now
            lblTotalSeleccionados.Text = CDbl(grdSolicitudesPOP.Rows.Count.ToString()).ToString("n0")


        Else
            lblTotalSeleccionados.Text = CDbl(grdSolicitudesPOP.Rows.Count.ToString()).ToString("n0")
            advertencia.mensaje = "No hay información para mostrar."
            advertencia.ShowDialog()
            grdSolicitudesPOP.DataSource = Nothing
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub DiseñoGrid()
        With grdSolicitudesPOP.DisplayLayout.Bands(0)
            .Columns("SolicitudID").CellActivation = Activation.NoEdit
            .Columns("Cliente").CellActivation = Activation.NoEdit
            .Columns("UsuarioSolicita").CellActivation = Activation.NoEdit
            .Columns("MotivoSolicitud").CellActivation = Activation.NoEdit
            .Columns("Fecha").CellActivation = Activation.NoEdit
            .Columns("Estatus").CellActivation = Activation.NoEdit
            .Columns("Observaciones").CellActivation = Activation.NoEdit
            .Columns("Total").CellActivation = Activation.NoEdit

            .Columns("Total").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total").FilterOperatorDefaultValue = FilterOperatorDefaultValue.Equals
            .Columns("Total").Format = "###,###,##0"

            Dim sumTotalImportes As SummarySettings = grdSolicitudesPOP.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudesPOP.DisplayLayout.Bands(0).Columns("Total"))
            sumTotalImportes.DisplayFormat = "{0:#,##0}"
            sumTotalImportes.Appearance.TextHAlign = HAlign.Right
            sumTotalImportes.Appearance.BackColor = Color.DarkSeaGreen
            grdSolicitudesPOP.DisplayLayout.Bands(0).SummaryFooterCaption = "Total"
        End With


        grdSolicitudesPOP.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdSolicitudesPOP.DisplayLayout.Override.RowSelectorWidth = 20
        grdSolicitudesPOP.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdSolicitudesPOP.Rows(0).Selected = True
        grdSolicitudesPOP.DisplayLayout.Bands(0).Columns(" ").Width = 40
        grdSolicitudesPOP.DisplayLayout.Bands(0).Columns("Cliente").Width = 250
        grdSolicitudesPOP.DisplayLayout.Bands(0).Columns("UsuarioSolicita").Width = 100
        grdSolicitudesPOP.DisplayLayout.Bands(0).Columns("MotivoSolicitud").Width = 200
        grdSolicitudesPOP.DisplayLayout.Bands(0).Columns("Fecha").Width = 100
        grdSolicitudesPOP.DisplayLayout.Bands(0).Columns("Estatus").Width = 100
        grdSolicitudesPOP.DisplayLayout.Bands(0).Columns("Observaciones").Width = 250
        grdSolicitudesPOP.DisplayLayout.Bands(0).Columns("Total").Width = 100

        grdSolicitudesPOP.DisplayLayout.Bands(0).Columns("MotivoSolicitud").Header.Caption = "Motivo Solicitud"
        grdSolicitudesPOP.DisplayLayout.Bands(0).Columns("UsuarioSolicita").Header.Caption = "Usuario Solicita"
        grdSolicitudesPOP.DisplayLayout.Bands(0).Columns("SolicitudID").Header.Caption = "Solicitud ID"



    End Sub


    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub btnSolicitudPOP_Click(sender As Object, e As EventArgs) Handles btnSolicitudPOP.Click
        Dim AltaSolicitudPOP As New Mercadotecnia_AltaOrdenCompraPOP

        AltaSolicitudPOP.ShowDialog()
        btnMostrar_Click(Nothing, Nothing)
    End Sub

    Private Sub grdSolicitudesPOP_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdSolicitudesPOP.DoubleClickCell
        With grdSolicitudesPOP
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        Dim consultarOrdenCompra As New Mercadotecnia_AltaOrdenCompraPOP
        consultarOrdenCompra.SolicitudOrdenCompra = grdSolicitudesPOP.ActiveRow.Cells("SolicitudID").Value
        consultarOrdenCompra.Cliente = grdSolicitudesPOP.ActiveRow.Cells("Cliente").Value
        consultarOrdenCompra.MotivoSolicitud = grdSolicitudesPOP.ActiveRow.Cells("MotivoSolicitud").Value
        consultarOrdenCompra.Estatus = grdSolicitudesPOP.ActiveRow.Cells("Estatus").Value
        consultarOrdenCompra.Observaciones = grdSolicitudesPOP.ActiveRow.Cells("Observaciones").Value
        consultarOrdenCompra.Consultar = 1

        consultarOrdenCompra.ShowDialog()

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        With grdSolicitudesPOP
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        Dim consultarOrdenCompra As New Mercadotecnia_AltaOrdenCompraPOP
        consultarOrdenCompra.SolicitudOrdenCompra = grdSolicitudesPOP.ActiveRow.Cells("SolicitudID").Value
        consultarOrdenCompra.Cliente = grdSolicitudesPOP.ActiveRow.Cells("Cliente").Value
        consultarOrdenCompra.MotivoSolicitud = grdSolicitudesPOP.ActiveRow.Cells("MotivoSolicitud").Value
        consultarOrdenCompra.Estatus = grdSolicitudesPOP.ActiveRow.Cells("Estatus").Value
        consultarOrdenCompra.Observaciones = grdSolicitudesPOP.ActiveRow.Cells("Observaciones").Value
        consultarOrdenCompra.Consultar = 2

        consultarOrdenCompra.ShowDialog()
        btnMostrar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try
            Dim objBU As New MercadotecniaBU
            Dim dtDetalleRecibo As New DataTable
            Dim SolicitudOrdenCompra As Integer = 0

            Dim dtEncabezadoReporte As New DataTable

            For Each rowGR As UltraGridRow In grdSolicitudesPOP.Rows
                If CBool(rowGR.Cells(" ").Text) = True Then
                    SolicitudOrdenCompra = rowGR.Cells("SolicitudID").Value
                End If
            Next

            dtEncabezadoReporte = objBU.ObtieneEncabezadoReporte(SolicitudOrdenCompra, 1)
            dtDetalleRecibo = objBU.ObtieneEncabezadoReporte(SolicitudOrdenCompra, 2)

            If dtEncabezadoReporte.Rows.Count > 0 And dtDetalleRecibo.Rows.Count > 0 Then


                Dim objReporte As New Framework.Negocios.ReportesBU
                Dim entReporte As New Entidades.Reportes
                Dim dsReciboSalida As New DataSet("dsReciboSalidaEncabezado")

                dtEncabezadoReporte.TableName = "dtDetalleReciboEncabezado"
                dtDetalleRecibo.TableName = "dtDetallesPOP"

                dsReciboSalida.Tables.Add(dtEncabezadoReporte)
                dsReciboSalida.Tables.Add(dtDetalleRecibo)

                entReporte = objReporte.LeerReporteporClave("REC_POP_MERCA")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)
                Dim reporte As New StiReport



                reporte.Load(archivo)
                reporte.Compile()
                reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString.ToUpper
                reporte("Cliente") = dtEncabezadoReporte.Rows(0).Item("Cliente").ToString
                reporte("MotivoSolicitud") = dtEncabezadoReporte.Rows(0).Item("MotivoSolicitud").ToString
                reporte("Observaciones") = dtEncabezadoReporte.Rows(0).Item("Observaciones").ToString
                reporte("FechaCreacion") = dtEncabezadoReporte.Rows(0).Item("FechaCreacion").ToString
                reporte("SolicitudID") = dtEncabezadoReporte.Rows(0).Item("SolicitudID")


                reporte.Dictionary.Clear()
                reporte.RegData(dsReciboSalida)
                reporte.Dictionary.Synchronize()
                reporte.Show()
            Else
                advertencia.mensaje = "No hay datos para mostrar."
                advertencia.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class