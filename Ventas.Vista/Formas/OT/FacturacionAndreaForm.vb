Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Data
Imports System.Data.DataTable
Imports System.Data.DataSet


Public Class FacturacionAndreaForm

    Public OrdenTrabajoID As Integer = 0
    Dim objBU As New Ventas.Negocios.OrdenTrabajoBU

    Private Sub FacturacionAndreaForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarPartidasOT(OrdenTrabajoID)
        lblNumFiltrados.Text = grdPartidas.Rows.Count.ToString()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


    Private Sub CargarPartidasOT(ByVal OTSAYID As Integer)
        Dim DTInformacion As DataTable
        Try

            DTInformacion = objBU.ConsultaPartidaPorFacturarAndrea(OTSAYID)
            grdPartidas.DataSource = Nothing
            DiseñoGridPartidas(grdPartidas)
            grdPartidas.DataSource = DTInformacion
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try

    End Sub

    Private Sub DiseñoGridPartidas(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim Ocultar As Boolean = False
        Dim OcultarSeleccion As Boolean = True
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Empty
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        '        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard


        AgregarColumna(grid, "OrdenTrabajoDetalleID", "OrdenTrabajoDetalleID", True, True, Nothing, 240, , False, HAlign.Left)
        Ocultar = True

        AgregarColumna(grid, "Seleccionar", "", False, False, Nothing, 25, , True, HAlign.Default)
        AgregarColumna(grid, "OrdenTrabajoSAYID", "OT " & vbCrLf & " SAY", Ocultar, True, Nothing, 60, , False, HAlign.Right)
        AgregarColumna(grid, "OrdenTrabajoSICYID", "OT " & vbCrLf & " SICY", True, True, Nothing, 60, , False, HAlign.Right)
        AgregarColumna(grid, "PedidoSAYID", "Pedido " & vbCrLf & " SAY", Ocultar, True, Nothing, 50, , False, HAlign.Right)
        AgregarColumna(grid, "PedidoSICYID", "Pedido " & vbCrLf & "SICY", Ocultar, True, Nothing, 50, , False, HAlign.Right)
        AgregarColumna(grid, "Partida", "Partida", False, False, Nothing, 40, False, False, HAlign.Right)
        AgregarColumna(grid, "FechaCaptura", "FCaptura ", True, True, Nothing, 100, , False, HAlign.Left)
        AgregarColumna(grid, "FechaPreparacion", "FPreparación", True, True, Nothing, 90, , False, HAlign.Left)
        AgregarColumna(grid, "Cliente", "Cliente", True, True, Nothing, 150, , False, HAlign.Left)
        AgregarColumna(grid, "OrdenCliente", "Orden " & vbCrLf & " Cliente", True, True, Nothing, 100, , False, HAlign.Left)
        AgregarColumna(grid, "Tienda", "Tienda", False, False, Nothing, 120, False, False, HAlign.Left)
        AgregarColumna(grid, "Articulo", "Articulo", False, False, Nothing, 140, False, False, HAlign.Left)
        AgregarColumna(grid, "StatusID", "StatusID", True, True, Nothing, 60, , False, HAlign.Right)
        AgregarColumna(grid, "Status", "Status", True, True, Nothing, 60, , False, HAlign.Left)
        AgregarColumna(grid, "TotalPares", "Total", False, False, Nothing, 70, True, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "ParesConfirmados", "Confirmados", False, True, Nothing, 70, True, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "ParesPorConfirmar", "Por" & vbCrLf & " Confirmar", False, True, Nothing, 70, True, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "Facturado", "Facturado", False, True, Nothing, 70, True, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "PorFacturar", "Por" & vbCrLf & " Facturar", False, True, Nothing, 70, True, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "ParesCancelados", "Cancelados", True, True, Nothing, 70, True, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "ParesIncidencias", "Incidencias", True, True, Nothing, 70, True, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "UsuarioCancelo", "Canceló", True, True, Nothing, 70, False, False, HAlign.Left)
        AgregarColumna(grid, "FechaCancelo", "FCanceló", True, True, Nothing, 70, False, False, HAlign.Left)
        AgregarColumna(grid, "ClienteSAYID", "ClienteSAYID", True, True, Nothing, 70, False, False, HAlign.Left)

        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        If Ocultar = True Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

    End Sub


    Private Sub AgregarColumna(ByRef grid As UltraGrid, ByVal Key As String, ByVal NombreColumna As String, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, ByVal ColorColumna As Color, Optional ByVal Width As Integer = -1, Optional ByVal SumarizarColumna As Boolean = False, Optional ByVal Edicion As Boolean = False, Optional ByVal Alineacion As HAlign = Nothing, Optional ByVal NEgrita As Boolean = False, Optional ByVal EsPorcentaje As Boolean = False, Optional ByVal Tooltip As String = "", Optional ByVal Operacion As SummaryType = SummaryType.Sum, Optional ByVal EsFecha As Boolean = False)
        With grid
            .DisplayLayout.Bands(0).Columns.Add(Key, NombreColumna)
            FormatoColumna(.DisplayLayout.Bands(0).Columns(Key), Ocultar, EsCadena, Width, EsPorcentaje, EsFecha)
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

    Private Sub FormatoColumna(ByRef columna As UltraGridColumn, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, Optional ByVal Width As Integer = -1, Optional ByVal EsPorcentaje As Boolean = False, Optional ByVal EsFechas As Boolean = False)
        Dim FormatoNumero As String = "###,###,##0"
        Dim FormatoPorcentaje As String = "##0%"
        Dim FormatoFecha As String = "dd/mm/yyyy HH:mm:ss"


        columna.Hidden = Ocultar
        If EsCadena = True Then
            If EsFechas = True Then
                columna.Format = FormatoFecha

            End If
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


    Private Sub grdPartidas_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdPartidas.InitializeRow
        Dim statusID As Integer = 0
        Dim PorFacturar As Integer = 0
        Dim Confirmado As Integer = 0
        Dim Facturado As Integer = 0

        If IsNothing(grdPartidas.DataSource) = False Then
            If e.Row.Index >= 0 Then
                e.Row.Appearance.BackColor = AsignarColorPartida(e.Row.Cells("StatusID").Value)
                statusID = e.Row.Cells("StatusID").Value
                PorFacturar = e.Row.Cells("PorFacturar").Value
                Confirmado = e.Row.Cells("ParesConfirmados").Value
                Facturado = e.Row.Cells("Facturado").Value

                If (Confirmado - Facturado) > 0 Then
                    e.Row.Cells("Seleccionar").Activation = Activation.AllowEdit
                Else
                    e.Row.Cells("Seleccionar").Hidden = True
                End If

            End If
        End If
    End Sub

    Private Function AsignarColorPartida(ByVal EstatusId As Integer) As Color

        Dim TipoColor As New Color

        If EstatusId = "122" Then
            TipoColor = lblColorEjecucion.BackColor
        ElseIf EstatusId = "123" Then
            TipoColor = lblColorParcialmenteConfirmada.BackColor
        ElseIf EstatusId = "124" Then
            TipoColor = lblColorConfirmada.BackColor
        ElseIf EstatusId = "125" Then
            TipoColor = lblColorPorFacturar.BackColor
        ElseIf EstatusId = "126" Then
            TipoColor = lblColorFacturada.BackColor
        ElseIf EstatusId = "127" Then
            TipoColor = lblColorEnRuta.BackColor
        ElseIf EstatusId = "128" Then
            TipoColor = lblColorEntregada.BackColor
        ElseIf EstatusId = "129" Then
            TipoColor = lblColorCancelada.BackColor
        ElseIf EstatusId = "130" Then
            TipoColor = lblColorRechazada.BackColor
        Else
            TipoColor = lblColorIncompleta.BackColor
        End If

        Return TipoColor

    End Function

    Private Sub btnFacturar_Click(sender As Object, e As EventArgs) Handles btnFacturar.Click

        Dim PartidasFacturar = grdPartidas.Rows.Where(Function(x) CBool(x.Cells("Seleccionar").Value) = True And x.Cells("StatusID").Value = "124")
        Dim PartidasSeleccionadas = grdPartidas.Rows.Where(Function(x) CBool(x.Cells("Seleccionar").Value) = True)

        Dim TotalPares As Integer = 0
        Dim Usuario As String = String.Empty
        Dim Partidas As String = String.Empty
        Dim DTNombreUsuario As DataTable
        Dim confirmar As New Tools.ConfirmarForm


        Try
            Cursor = Cursors.WaitCursor

            For Each Fila As UltraGridRow In PartidasFacturar
                TotalPares += CInt(Fila.Cells("ParesConfirmados").Value) - CInt(Fila.Cells("Facturado").Value)
                If Partidas = String.Empty Then
                    Partidas = Fila.Cells("Partida").Value
                Else
                    Partidas &= "," & Fila.Cells("Partida").Value
                End If
            Next

            DTNombreUsuario = objBU.ObtenerNombreCortoColaborador(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)

            If DTNombreUsuario.Rows.Count > 0 Then
                Usuario = DTNombreUsuario.Rows(0).Item(0)
            End If

            If PartidasSeleccionadas.Count > 0 Then

                If PartidasFacturar.Count > 0 Then
                    confirmar.mensaje = "¿Esta seguro de enviar a facturar " + TotalPares.ToString() + " pares de " + PartidasFacturar.Count.ToString() + " partidas?"
                    If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        If PartidasFacturar.Count = PartidasSeleccionadas.Count Then
                            objBU.GenerarFacturasAndrea(OrdenTrabajoID, TotalPares, Usuario, Partidas)
                            objBU.EnviarFacturarPartidas(OrdenTrabajoID, Partidas, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                            show_message("Exito", "Se han enviado a facturar " + PartidasFacturar.Count.ToString())
                            CargarPartidasOT(OrdenTrabajoID)
                        Else
                            show_message("Advertencia", "Seleccionar solo las partidas con estatus por facturar")
                        End If
                    End If
                Else
                    show_message("Advertencia", "Las partidas tienen que estar en status de confirmado.")
                End If
            Else
                show_message("Advertencia", "No se han seleccionado las partidas.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
      

    End Sub

    Private Sub chkSeleccionarTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodos.CheckedChanged

        For Each Fila As UltraGridRow In grdPartidas.Rows.GetFilteredInNonGroupByRows
            If Fila.Cells("Seleccionar").Hidden = False Then
                Fila.Cells("Seleccionar").Value = chkSeleccionarTodos.Checked
            End If
        Next

    End Sub
End Class