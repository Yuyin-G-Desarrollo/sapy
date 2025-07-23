Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Linq
Imports System.Data
Imports System.Data.DataTable
Imports System.Data.DataSet
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms


Public Class GenerarXMLEtiquetasAndreaForm

    Public OrdenTrabajo As Integer = 0

    Private Sub LotesAndreaGenerarXML_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtmFechaInicio.Value = Date.Now
        CargarLotes()
    End Sub

    Private Sub CargarLotes()
        Dim ObjBU As New Negocios.OrdenTrabajoBU

        Dim dtdatos As DataTable
        Dim fecha As Date = CDate(dtmFechaInicio.Value)
        dtdatos = ObjBU.ConsultaLotesAndreaPorLOTEtiquetasPorFecha(fecha.ToShortDateString)
        grdEtiquetasAndrea.DataSource = Nothing
        grdEtiquetasAndrea.DataSource = dtdatos
        lblNumFiltrados.Text = grdEtiquetasAndrea.Rows.Count().ToString("n0")
        DiseñoGrid(grdEtiquetasAndrea)
        'grdEtiquetasAndrea.DataSource = ObjBU.ConsultaLotesAndreaPorLOTEtiquetasPorFecha(dtmFechaInicio.Value)
        'lblNumFiltrados.Text = grdEtiquetasAndrea.Rows.Count().ToString("n0")
        'DiseñoGrid(grdEtiquetasAndrea)
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
        grid.DisplayLayout.Bands(0).Columns("loteAndrea").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("OT").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Confirmados").Header.Caption = "Conf"
        grid.DisplayLayout.Bands(0).Columns("Confirmados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Confirmados").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Cantidad").Header.Caption = "Pares"
        grid.DisplayLayout.Bands(0).Columns("Cantidad").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Cantidad").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Fechaconfirmo").Format = "dd/mm/yyyy HH:mm:ss"
        grid.DisplayLayout.Bands(0).Columns("Fechaconfirmo").Header.Caption = "Fecha " & vbCrLf & "Confirmo"
        'grid.DisplayLayout.Bands(0).Columns("Fechaconfirmo").Width = 140
        grid.DisplayLayout.Bands(0).Columns("otpp_xmletiquetasgenerado").Hidden = True
        '  grid.DisplayLayout.Bands(0).Columns("XMLGenerado").Hidden = True

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


        For Each renglon As UltraGridRow In grid.Rows
            renglon.Cells("loteAndrea").Activation = Activation.NoEdit
            renglon.Cells("Confirmados").Activation = Activation.NoEdit
            renglon.Cells("Cantidad").Activation = Activation.NoEdit
            'If CBool(renglon.Cells("XMLGenerado").Value) = True Then
            '    renglon.Appearance.BackColor = pnlArchivosGeneradosAntes.BackColor
            'End If
            If renglon.Cells("Confirmados").Value <> renglon.Cells("Cantidad").Value Then
                renglon.Cells("Seleccionar").Hidden = True
            End If


            If CBool(renglon.Cells("otpp_xmletiquetasgenerado").Value) = True Then
                renglon.Appearance.BackColor = pnlArchivosGeneradosAntes.BackColor
            End If

        Next


    End Sub

    Private Sub btnGenerarArchivos_Click(sender As Object, e As EventArgs) Handles btnGenerarArchivos.Click
        Dim listLotesSeleccionados As New List(Of String)
        Dim mensaje As String = "Error al generar los archivos. Intente de nuevo."
        Dim objBU As New Negocios.OrdenTrabajoBU
        Dim mensajeExito As New Tools.ExitoForm
        Dim mensajeError As New Tools.ErroresForm
        Dim lotesSeleccionados As String = String.Empty        
        Dim NumeroLotes As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            For Each row As UltraGridRow In grdEtiquetasAndrea.Rows

                If CBool(row.Cells("Seleccionar").Value) = True Then
                    NumeroLotes += 1

                    If lotesSeleccionados = String.Empty Then
                        lotesSeleccionados = row.Cells("loteAndrea").Value.ToString()
                    Else
                        lotesSeleccionados &= "," & row.Cells("loteAndrea").Value.ToString()
                    End If
                End If
            Next
            If NumeroLotes > 0 Then
                mensaje = objBU.GenerarEtiquetasAndreavariosLotes(lotesSeleccionados, "C:\Arc_Sync\", OrdenTrabajo, 0, 2, 0, dtmFechaInicio.Value.ToShortDateString)
                show_message("Exito", "El archivo se genero correctamente en C:\Arc_Sync\")
                objBU.ActualizarEstatusGenerarXMLEtiquetas(lotesSeleccionados, dtmFechaInicio.Value.ToShortDateString)
            Else
                show_message("Advertencia", "No se ha seleccionado un Lote.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            show_message("Advertencia", "Ocurrio un error al generar el archivo, intente de nuevo.")
            Cursor = Cursors.Default
        End Try

        'Dim punto As Point
        'punto.X = btnGenerarArchivos.Location.X + btnGenerarArchivos.Width + Me.Location.X + pnlPie.Width - pnlDatosBotones.Width
        'punto.Y = btnGenerarArchivos.Location.Y + btnGenerarArchivos.Height + Me.Location.Y + Panel1.Height + grdEtiquetasAndrea.Height
        'cmsTipoArchivoGenerar.Show(punto)
    End Sub

    Private Sub PorLoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorLoteToolStripMenuItem.Click
        Dim listLotesSeleccionados As New List(Of String)
        Dim mensaje As String = "Error al generar los archivos. Intente de nuevo."
        Dim objBU As New Negocios.OrdenTrabajoBU
        Dim mensajeExito As New Tools.ExitoForm
        Dim mensajeError As New Tools.ErroresForm
        Dim lotesSeleccionados As String = ""
        Dim DTEtiquetasAndrea As DataTable
        Dim numeroLotes As Integer = 0

        Cursor = Cursors.WaitCursor

        Try
            For Each row As UltraGridRow In grdEtiquetasAndrea.Rows

                If CBool(row.Cells("Seleccionar").Value) = True Then
                    numeroLotes += 1
                    mensaje = objBU.ConstruyeXmlEtiquetasAndrea(row.Cells("loteAndrea").Value.ToString(), "C:\Arc_Sync\", OrdenTrabajo, 0, 1, Integer.Parse(row.Cells("loteAndrea").Value.ToString()), dtmFechaInicio.Value.ToShortDateString)
                End If
            Next
            If numeroLotes > 0 Then
                show_message("Exito", "El archivo se genero correctamente en C:\Arc_Sync\")



            Else
                show_message("Advertencia", "No se ha seleccionado un lote.")
            End If


        Catch ex As Exception
            show_message("Advertencia", "Ocurrio un error al generar el archivo, intente de nuevo.")
            Cursor = Cursors.Default
        End Try
        
        Cursor = Cursors.Default

    End Sub

    Private Sub CompletoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompletoToolStripMenuItem.Click
        'Dim listLotesSeleccionados As New List(Of String)
        'Dim mensaje As String = "Error al generar los archivos. Intente de nuevo."
        'Dim objBU As New Negocios.OrdenTrabajoBU
        'Dim mensajeExito As New Tools.ExitoForm
        'Dim mensajeError As New Tools.ErroresForm
        'Dim lotesSeleccionados As String = String.Empty
        'Dim DTEtiquetasAndrea As DataTable
        'Dim NumeroLotes As Integer = 0



        'Try
        '    Cursor = Cursors.WaitCursor
        '    For Each row As UltraGridRow In grdEtiquetasAndrea.Rows

        '        If CBool(row.Cells("Seleccionar").Value) = True Then
        '            NumeroLotes += 1

        '            If lotesSeleccionados = String.Empty Then
        '                lotesSeleccionados = row.Cells("loteAndrea").Value.ToString()
        '            Else
        '                lotesSeleccionados &= "," & row.Cells("loteAndrea").Value.ToString()
        '            End If
        '        End If
        '    Next
        '    If NumeroLotes > 0 Then
        '        mensaje = objBU.GenerarEtiquetasAndreavariosLotes(lotesSeleccionados, "C:\Arc_Sync\", OrdenTrabajo, 0, 2, 0)                
        '        show_message("Exito", "El archivo se genero correctamente en C:\Arc_Sync\")
        '    Else
        '        show_message("Advertencia", "No se ha seleccionado un Lote.")
        '    End If


        '    Cursor = Cursors.Default
        'Catch ex As Exception
        '    show_message("Advertencia", "Ocurrio un error al generar el archivo, intente de nuevo.")
        '    Cursor = Cursors.Default
        'End Try
     

    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub



    'Imports Tools
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


    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Try
            Cursor = Cursors.WaitCursor
            CargarLotes()
            chkSeleccionar.Checked = False
            Cursor = Cursors.Default
        Catch ex As Exception
            show_message("Error", "Ocurrio un error al mostrar la información, intente de nuevo.")
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub chkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged
        For Each Filas As UltraGridRow In grdEtiquetasAndrea.Rows.GetFilteredInNonGroupByRows
            If Filas.Cells("Seleccionar").Hidden = False Then
                Filas.Cells("Seleccionar").Value = chkSeleccionar.Checked
            End If

        Next
    End Sub
End Class