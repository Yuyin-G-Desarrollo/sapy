Imports System.Globalization
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class AsignarOperadorOTForm

    Dim objBU As New Ventas.Negocios.OrdenTrabajoBU
    Public OrdenTrabajoID As String = String.Empty

    Private Sub AsignarOperadorOTForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim FilasSinGuardar = grdPartidasOT.Rows.Where(Function(x) x.Cells("ColumnaModificada").Value = "1")
        Dim confirmar As New Tools.ConfirmarForm

        If FilasSinGuardar.Count > 0 Then

            confirmar.mensaje = "Hay cambios sin guardar ¿Esta seguro de salir sin guardar?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If

    End Sub


    Private Sub AsignarOperadorOTForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Cursor = Cursors.WaitCursor
            CargarPartidas()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub CargarPartidas()
        grdPartidasOT.DataSource = Nothing
        DiseñoGrid(grdPartidasOT)
        grdPartidasOT.DataSource = objBU.ConsultarPartidasAsignacionOperador(OrdenTrabajoID)

        lblTotalSeleccionados.Text = grdPartidasOT.Rows.Count().ToString()
        lblFechaUltimaActualizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub DiseñoGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard

        AgregarColumna(grid, "OrdenTrabajoDetalleID", "OrdenTrabajoDetalleID", True, True, Nothing, 240, , False, HAlign.Left)
        AgregarColumna(grid, "Partida", "Partida", False, True, Nothing, 35, False, False, HAlign.Right)
        AgregarColumna(grid, "OrdenTrabajoSAYID", "OT" & vbCrLf & " SAY", False, True, Nothing, 50, , False, HAlign.Right)
        AgregarColumna(grid, "OrdenTrabajoSICYID", "OT " & vbCrLf & " SICY", False, True, Nothing, 50, , False, HAlign.Right)
        AgregarColumna(grid, "PedidoSAYID", "Pedido " & vbCrLf & "SAY", False, True, Nothing, 60, False, False, HAlign.Right)
        AgregarColumna(grid, "PedidoSICYID", "Pedido" & vbCrLf & "SICY", False, True, Nothing, 60, False, False, HAlign.Right)
        AgregarColumna(grid, "OperadorAsignado", "Operador" & vbCrLf & " Asignado", False, True, Nothing, 100, False, False, HAlign.Left)
        AgregarColumna(grid, "Cliente", "Cliente", False, True, Nothing, 180, , , HAlign.Left)
        AgregarColumna(grid, "Tienda", "Tienda", False, True, Nothing, 100, False, False, HAlign.Left)
        AgregarColumna(grid, "Articulo", "Articulo", False, True, Nothing, 120, , , HAlign.Left)
        AgregarColumna(grid, "FechaCaptura", "Fecha" & vbCrLf & "Captura", True, True, Nothing, 80, , , HAlign.Left)
        AgregarColumna(grid, "FechaPreparacion", "Fecha" & vbCrLf & "Preparación", False, True, Nothing, 80, , , HAlign.Left)
        AgregarColumna(grid, "OrdenCliente", "Orden Cliente", True, True, Nothing, 10)
        AgregarColumna(grid, "StatusPartidaID", "StatusPartidaID", True, True, Nothing, 10)
        AgregarColumna(grid, "Status", "Status Partida", False, True, Nothing, 100, , , HAlign.Left)
        AgregarColumna(grid, "StatusOT", "StatusOT", True, True, Nothing, 100, , , HAlign.Left)
        AgregarColumna(grid, "TotalPares", "Total" & vbCrLf & "Pares", False, False, Nothing, 45, True, , HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "ParesConfirmados", "Pares" & vbCrLf & "Confirmados", False, False, Nothing, 50, True, , HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "ParesPorConfirmar", "Pares Por " & vbCrLf & "Confirmar", False, False, Nothing, 50, True, , HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "ParesCancelados", "Pares" & vbCrLf & "Cancelados", False, False, Nothing, 50, True, , HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "ParesIncidencias", "Pares" & vbCrLf & "Incidencias", False, True, Nothing, 50, True, , HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "UsuarioCancelo", "Usuario" & vbCrLf & "Cancelo", True, True, Nothing, 10)
        AgregarColumna(grid, "FechaCancelo", "Fecha" & vbCrLf & "Cancelo", True, True, Nothing, 10)
        AgregarColumna(grid, "OperadorAsignadoID", "OperadorAsignadoID", True, True, Nothing, 10)
        AgregarColumna(grid, "ColumnaModificada", "ColumnaModificada", True, True, Nothing, 10)
        AgregarColumna(grid, "StatusOTID", "StatusOTID", True, True, Nothing, 10)
        
        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub





    Private Sub AgregarColumna(ByRef grid As UltraGrid, ByVal Key As String, ByVal NombreColumna As String, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, ByVal ColorColumna As Color, Optional ByVal Width As Integer = -1, Optional ByVal SumarizarColumna As Boolean = False, Optional ByVal Edicion As Boolean = False, Optional ByVal Alineacion As HAlign = Nothing, Optional ByVal NEgrita As Boolean = False, Optional ByVal EsPorcentaje As Boolean = False, Optional ByVal Tooltip As String = "", Optional ByVal Operacion As SummaryType = SummaryType.Sum)
        With grid
            .DisplayLayout.Bands(0).Columns.Add(Key, NombreColumna)
            FormatoColumna(.DisplayLayout.Bands(0).Columns(Key), Ocultar, EsCadena, Width, EsPorcentaje)
            If IsNothing(ColorColumna) Then
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = Color.Black
            Else
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = ColorColumna
            End If
            If SumarizarColumna = True Then
                SumarizarColumnaGrid(grid, Key, "Sumarizar " + Key, Operacion)
            End If
            If Tooltip <> "" Then
                grid.DisplayLayout.Bands(0).Columns(Key).Header.ToolTipText = Tooltip
            End If

            'If Alineacion <> HAlign.Default Then
            '    .DisplayLayout.Bands(0).Columns(Key).CellAppearance.TextHAlign = Alineacion
            'End If

            If IsNothing(Alineacion) = False Then
                .DisplayLayout.Bands(0).Columns(Key).CellAppearance.TextHAlign = Alineacion
            End If
            If NEgrita = True Then
                .DisplayLayout.Bands(0).Columns(Key).CellAppearance.FontData.Bold = DefaultableBoolean.True
            End If


            If Edicion = True Then
                .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.AllowEdit
            Else
                .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.NoEdit
            End If

        End With
    End Sub

    Private Sub FormatoColumna(ByRef columna As UltraGridColumn, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, Optional ByVal Width As Integer = -1, Optional ByVal EsPorcentaje As Boolean = False)
        Dim FormatoNumero As String = "###,###,##0"
        Dim FormatoPorcentaje As String = "##0%"
        columna.Hidden = Ocultar
        If EsCadena = True Then
            columna.CellAppearance.TextHAlign = HAlign.Left
        Else

            If EsPorcentaje = True Then
                columna.Format = FormatoPorcentaje
                columna.CellAppearance.TextHAlign = HAlign.Right
            Else
                columna.Format = FormatoNumero
                columna.CellAppearance.TextHAlign = HAlign.Right
            End If

        End If

        If Width <> -1 Then
            columna.Width = Width
        End If
    End Sub

    Private Sub SumarizarColumnaGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal NombreColumna As String, ByVal Key As String, ByVal Operacion As SummaryType)
        Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns(NombreColumna)
        Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add(Key, Operacion, columnToSummarize)
        summary.DisplayFormat = "{0:###,###,##0}"
        summary.Appearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
    End Sub



   
    Private Sub grdPartidasOT_MouseClick(sender As Object, e As MouseEventArgs) Handles grdPartidasOT.MouseClick

        Dim FilasSeleccionadas = grdPartidasOT.Rows.Where(Function(x) x.Selected = True And (x.Cells("StatusPartidaID").Value = "121" Or x.Cells("StatusPartidaID").Value = "123"))

        If FilasSeleccionadas.Count() > 0 Then
            If e.Button = Windows.Forms.MouseButtons.Right Then

                Dim FilasSinAsignar = FilasSeleccionadas.Where(Function(x) IsDBNull(x.Cells("OperadorAsignadoID").Value) = True)

                If FilasSeleccionadas.Count = FilasSinAsignar.Count Then
                    cmsSeleccionMultiple.Items(1).Visible = False
                Else
                    cmsSeleccionMultiple.Items(1).Visible = True
                End If
                cmsSeleccionMultiple.Show(Control.MousePosition)
            End If
        End If
        

    End Sub

    Private Function ObtenerOperadorAAsignar() As String
        Dim listado As New ListadoParametrosApartadosForm
        Dim listaParametroID As New List(Of String)
        Dim OperadorSeleccionadoID As String = String.Empty
        listado.tipo_busqueda = 10
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)

        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return String.Empty
        If listado.listParametros.Rows.Count = 0 Then
            Return String.Empty
        End If

        If listado.listParametros.Rows.Count > 1 Then
            show_message("Advertencia", "Seleccione solo a un operador.")
            Return String.Empty
        Else
            OperadorSeleccionadoID = listado.listParametros.Rows(0).Item(0).ToString() + "-" + listado.listParametros.Rows(0).Item(2).ToString()
        End If

        Return OperadorSeleccionadoID

    End Function

    Private Sub tmsiAsignarOperador_Click(sender As Object, e As EventArgs) Handles tmsiAsignarOperador.Click
        Dim FilasSeleccionadas = grdPartidasOT.Rows.Where(Function(x) x.Selected = True).OrderBy(Function(y) y.Cells("OrdenTrabajoSAYID").Value)
        Dim OperadorAAsignar As String = String.Empty
        Dim Operador As String()
        Dim FilasValidas As Integer = 0
        Dim FilasInvalidas As Integer = 0

        Try
            OperadorAAsignar = ObtenerOperadorAAsignar()

            If OperadorAAsignar <> String.Empty Then
                Cursor = Cursors.WaitCursor

                Operador = Split(OperadorAAsignar, "-")

                For Each Fila As UltraGridRow In FilasSeleccionadas
                    If Fila.Cells("StatusPartidaID").Value = "121" Or Fila.Cells("StatusPartidaID").Value = "123" Then
                        Fila.Cells("OperadorAsignadoID").Value = Operador(0)
                        Fila.Cells("OperadorAsignado").Value = Operador(1)
                        Fila.Cells("ColumnaModificada").Value = "1"
                        FilasValidas += 1
                    Else
                        FilasInvalidas += 1
                    End If
                Next
            End If

            If FilasInvalidas > 0 Then
                show_message("Advertencia", "Solo las partidas que esten en estatus de Aceptada o Parcialmente confirmada  se puede asignar operador.")
            End If

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
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





    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim OrdenTrabajo As Integer = 0
        Dim Partida As String = String.Empty
        Dim Operador As Integer = 0
        Dim FilasGuardadas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            Dim FilasSeleccionadas = grdPartidasOT.Rows.Where(Function(x) x.Cells("ColumnaModificada").Value = "1").OrderBy(Function(y) y.Cells("OrdenTrabajoSAYID").Value)
            FilasGuardadas = FilasSeleccionadas.Count()            
            For Each Fila As UltraGridRow In FilasSeleccionadas
                objBU.AsignarOperadorPartidaOT(Fila.Cells("OrdenTrabajoSAYID").Value, Fila.Cells("Partida").Value, Fila.Cells("OperadorAsignadoID").Value)
                Fila.Cells("ColumnaModificada").Value = "0"
                

                'If OrdenTrabajo = 0 Then
                '    Partida = String.Empty
                '    OrdenTrabajo = Fila.Cells("OrdenTrabajoSAYID").Value
                '    Partida = Fila.Cells("Partida").Value.ToString()

                'Else
                '    If Fila.Cells("OrdenTrabajoSAYID").Value <> OrdenTrabajo Then
                '        'Guardar
                '        objBU.AsignarOperadorOT(OrdenTrabajo, Partida, Fila.Cells("OperadorAsignadoID").Value)
                '        OrdenTrabajo = Fila.Cells("OrdenTrabajoSAYID").Value
                '        Partida = Fila.Cells("Partida").Value.ToString()
                '    Else
                '        Partida += "," + Fila.Cells("Partida").Value.ToString()
                '    End If
                'End If

            Next

            objBU.EnviarDatosParaConfirmacion(OrdenTrabajoID)
            objBU.ActualizarOTUbicaciones(OrdenTrabajoID)


            If FilasGuardadas > 0 Then
                show_message("Exito", "Se ha asignado el operador.")
            End If

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try


    End Sub

    Private Sub tmsiDesasignarOperador_Click(sender As Object, e As EventArgs) Handles tmsiDesasignarOperador.Click
        Dim FilasSeleccionadas = grdPartidasOT.Rows.Where(Function(x) x.Selected = True).OrderBy(Function(y) y.Cells("OrdenTrabajoSAYID").Value)
        Dim FilasValidas As Integer = 0
        Dim FilasInvalidas As Integer = 0

        Try

            Cursor = Cursors.WaitCursor

            For Each Fila As UltraGridRow In FilasSeleccionadas
                If Fila.Cells("StatusPartidaID").Value = "121" Or Fila.Cells("StatusPartidaID").Value = "123" Then
                    FilasValidas += 1
                    Fila.Cells("OperadorAsignadoID").Value = "0"
                    Fila.Cells("OperadorAsignado").Value = ""
                    Fila.Cells("ColumnaModificada").Value = "1"

                Else
                    FilasInvalidas += 1
                End If
            Next

            If FilasInvalidas > 0 Then
                show_message("Advertencia", "Solo las partidas aceptadas o parcialmente confirmadas se pueden desasignar el operaddor.")
            End If


            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel(grdPartidasOT)
    End Sub


    Public Sub exportarExcel(ByVal grd As UltraGrid)
        Dim sfd As New SaveFileDialog

        If IsNothing(grd) = False Then
            If grd.Rows.Count = 0 Then
                show_message("Advertencia", "No hay informacion para exportar a excel.")
                Return
            End If
        End If


        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                UltraGridExcelExporter1.Export(grd, fileName)
                show_message("Exito", "El archivo se ha exportado correctamente en la ruta " + fileName)
                Process.Start(fileName)
                Me.Cursor = Cursors.Default


            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atencion")
            End Try
        End If
    End Sub




End Class