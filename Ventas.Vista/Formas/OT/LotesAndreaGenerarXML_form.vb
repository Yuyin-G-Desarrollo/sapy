Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class LotesAndreaGenerarXML_form

    Public ordenTrabajo As Integer = 0

    Private Sub LotesAndreaGenerarXML_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtmFechaInicio.Value = Date.Now.ToShortDateString
        MostrarLotes()
    End Sub

    Private Sub MostrarLotes()
        Try
            Cursor = Cursors.WaitCursor
            Dim ObjBU As New Negocios.OrdenTrabajoBU
            grdLotesAndrea.DataSource = Nothing
            grdLotesAndrea.DataSource = ObjBU.ConsultaLotesAndreaPorOT(dtmFechaInicio.Value.ToShortDateString())
            lblNumFiltrados.Text = grdLotesAndrea.Rows.Count().ToString("n0")
            DiseñoGrid(grdLotesAndrea)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al mostrar la información, intente de nuevo.")
        End Try
        
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub DiseñoGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        ' grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard
        grid.DisplayLayout.Bands(0).Columns("Seleccionar").Header.Caption = ""
        grid.DisplayLayout.Bands(0).Columns("loteAndrea").Header.Caption = "Lote " & vbCrLf & " Andrea"
        grid.DisplayLayout.Bands(0).Columns("Confirmados").Header.Caption = "Conf"
        grid.DisplayLayout.Bands(0).Columns("Confirmados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Confirmados").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Cantidad").Header.Caption = "Pares"
        grid.DisplayLayout.Bands(0).Columns("Cantidad").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Cantidad").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("XMLGenerado").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Fechaconfirmo").Style = ColumnStyle.DateTime
        grid.DisplayLayout.Bands(0).Columns("Fechaconfirmo").CellActivation = Activation.NoEdit
        'grid.DisplayLayout.Bands(0).Columns("Fechaconfirmo").Format = "dd/MM/yyyy HH:mm:ss"
        grid.DisplayLayout.Bands(0).Columns("Fechaconfirmo").Width = 140
        grid.DisplayLayout.Bands(0).Columns("Fechaconfirmo").Header.Caption = "Fecha " & vbCrLf & "Confirmo"

        Dim summary1, summary2 As SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Cantidad"))
        summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Confirmados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Confirmados"))

        'summary5 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Cantidad"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right
        summary2.DisplayFormat = "{0:#,##0}"
        summary2.Appearance.TextHAlign = HAlign.Right


        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns


        grid.DisplayLayout.Bands(0).Columns("Seleccionar").Header.Caption = ""
        grid.DisplayLayout.Bands(0).Columns("loteAndrea").Header.Caption = "Lote " & vbCrLf & " Andrea"
        grid.DisplayLayout.Bands(0).Columns("Confirmados").Header.Caption = "Conf"
        grid.DisplayLayout.Bands(0).Columns("Confirmados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Confirmados").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Cantidad").Header.Caption = "Pares"
        grid.DisplayLayout.Bands(0).Columns("Cantidad").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Cantidad").Format = "n0"


        For Each renglon As UltraGridRow In grid.Rows
            renglon.Cells("loteAndrea").Activation = Activation.NoEdit
            renglon.Cells("Confirmados").Activation = Activation.NoEdit
            renglon.Cells("Cantidad").Activation = Activation.NoEdit
            If CBool(renglon.Cells("XMLGenerado").Value) = True Then
                renglon.Appearance.BackColor = pnlArchivosGeneradosAntes.BackColor
            End If
            If renglon.Cells("Confirmados").Value <> renglon.Cells("Cantidad").Value Then
                renglon.Cells("Seleccionar").Hidden = True
            End If
        Next

    End Sub

    Private Sub btnGenerarArchivos_Click(sender As Object, e As EventArgs) Handles btnGenerarArchivos.Click
        Dim punto As Point
        punto.X = btnGenerarArchivos.Location.X + btnGenerarArchivos.Width + Me.Location.X + pnlPie.Width - pnlDatosBotones.Width
        punto.Y = btnGenerarArchivos.Location.Y + btnGenerarArchivos.Height + Me.Location.Y + Panel1.Height + grdLotesAndrea.Height
        cmsTipoArchivoGenerar.Show(punto)
    End Sub

    Private Sub PorLoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorLoteToolStripMenuItem.Click
        Dim listLotesSeleccionados As New List(Of String)
        Dim mensaje As String = "Error al generar los archivos. Intente de nuevo."
        Dim objBU As New Negocios.OrdenTrabajoBU
        Dim mensajeExito As New Tools.ExitoForm
        Dim mensajeError As New Tools.ErroresForm
        Dim lotesSeleccionados As String = ""

        Try
            Cursor = Cursors.WaitCursor

            For Each row As UltraGridRow In grdLotesAndrea.Rows
                If CBool(row.Cells("Seleccionar").Value) = True Then
                    listLotesSeleccionados.Add(row.Cells("loteAndrea").Value.ToString())
                    If CBool(row.Cells("XMLGenerado").Value) = False Then
                        If lotesSeleccionados <> "" Then
                            lotesSeleccionados += ","
                        End If
                        lotesSeleccionados += "'" + row.Cells("loteAndrea").Value.ToString() + "'"
                    End If
                End If

            Next

            If listLotesSeleccionados.Count > 0 Then
                For Each lote As String In listLotesSeleccionados
                    mensaje = objBU.ConstruyeXmlAndrea(lote, "C:\Arc_Sync\", ordenTrabajo, 0, 1, Integer.Parse(lote), dtmFechaInicio.Value.ToShortDateString)
                    ' mensaje = objBU.ConstruyeXmlAndrea(lote, "C:\Arc_Sync\", ordenTrabajo, 1, 1, Integer.Parse(lote), dtmFechaInicio.Value.ToShortDateString)
                Next
            End If

            If mensaje.Contains("Error") Then
                mensajeError.mensaje = mensaje
                mensajeError.ShowDialog()
            Else
                mensajeExito.mensaje = mensaje
                'objBU.ActualizaParesConArchivoGeneradoEnOT(ordenTrabajo.ToString(), lotesSeleccionados)
                mensajeExito.ShowDialog()
                Process.Start("explorer.exe", "C:\Arc_Sync\")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al generar los archivos, intente de nuevo.")
        End Try

    End Sub

    Private Sub CompletoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompletoToolStripMenuItem.Click
        Dim lotesSeleccionados As String = ""
        Dim lotesSeleccionadosActualizar As String = ""
        Dim totalLotesSeleccionados As Integer = 0
        Dim objBU As New Negocios.OrdenTrabajoBU
        Dim mensaje As String = "Error al generar el archivo. Intente de nuevo"
        Dim mensajeExito As New Tools.ExitoForm
        Dim mensajeError As New Tools.ErroresForm

        Try
            Cursor = Cursors.WaitCursor

            For Each row As UltraGridRow In grdLotesAndrea.Rows
                If CBool(row.Cells("Seleccionar").Value) = True Then
                    If lotesSeleccionados <> "" Then
                        lotesSeleccionados += ","
                    End If
                    lotesSeleccionados += row.Cells("loteAndrea").Value.ToString()
                    totalLotesSeleccionados += 1
                    If CBool(row.Cells("XMLGenerado").Value) = False Then
                        If lotesSeleccionadosActualizar <> "" Then
                            lotesSeleccionadosActualizar += ","
                        End If
                        lotesSeleccionadosActualizar += "'" + row.Cells("loteAndrea").Value.ToString() + "'"
                    End If
                End If
            Next

            If totalLotesSeleccionados > 0 Then
                mensaje = objBU.ConstruyeXmlAndrea(lotesSeleccionados, "C:\Arc_Sync\", ordenTrabajo, 0, 2, 0, dtmFechaInicio.Value.ToShortDateString)
            End If

            If mensaje.Contains("Error") Then
                mensajeError.mensaje = mensaje
                mensajeError.ShowDialog()
            Else
                mensajeExito.mensaje = mensaje
                'objBU.ActualizaParesConArchivoGeneradoEnOT(ordenTrabajo.ToString(), lotesSeleccionadosActualizar)
                mensajeExito.ShowDialog()
                Process.Start("explorer.exe", "C:\Arc_Sync\")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al generar los archivos, intente de nuevo.")
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Cursor = Cursors.WaitCursor
            MostrarLotes()
            chkSeleccionar.Checked = False
            Cursor = Cursors.Default
        Catch ex As Exception
            show_message("Error", "Ocurrio un error al mostrar la información, intente de nuevo.")
            Cursor = Cursors.Default
        End Try

        
    End Sub

    Private Sub chkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged
        For Each Filas As UltraGridRow In grdLotesAndrea.Rows.GetFilteredInNonGroupByRows
            If Filas.Cells("Seleccionar").Hidden = False Then
                Filas.Cells("Seleccionar").Value = chkSeleccionar.Checked
            End If

        Next
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

End Class