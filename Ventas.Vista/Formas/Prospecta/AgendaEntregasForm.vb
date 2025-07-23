Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Ventas.Negocios
Imports Framework.Negocios
Imports Tools


Public Class AgendaEntregasForm

    Dim dtApartadosProspecta As New DataTable()
    Public ProspectaID As Integer = -1
    Public TipoAgenda As Integer = 0 '1 => Agenda Entregas, 2=> Agenda de Proyecciones
    Public FechaInicioProspecta As Date

    Private Sub AgendaEntregasForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        lblTitulo.Text = String.Empty

        If TipoAgenda = 1 Then
            CargarGridAgendaEntrega()
            lblTitulo.Text = "Agenda de Entregas"
            Me.Text = "Agenda de Entregas"
        ElseIf TipoAgenda = 2 Then
            CargarGridAgendaProyeccion()
            lblTitulo.Text = "Agenda de Proyección"
            Me.Text = "Agenda de Proyección"
        End If

        lblNumFiltrados.Text = grdAgendaEntregas.Rows.Count.ToString()
        lblFechaUltimaActualizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()

    End Sub

    Public Sub CargarGridAgendaProyeccion()

        Dim obj As New ProspectaBU
        grdAgendaEntregas.DataSource = Nothing

        AgregarColumna(grdAgendaEntregas, "ClienteSicyID", "ClienteSicyID", True, True, Nothing, 100, False, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "ClienteID", "ClienteID", True, True, Nothing, 100, , False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "Cliente", "CLIENTE", False, True, Nothing, 100, , False, HAlign.Left)
        AgregarColumna(grdAgendaEntregas, "ProyectarJ", "PROSPECTA", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "ProyectadoJ", "PROYECTADO", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "ProyectarV", "PROSPECTA", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "ProyectadoV", "PROYECTADO", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "ProyectarS", "PROSPECTA", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "ProyectadoS", "PROYECTADO", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "ProyectarL", "PROSPECTA", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "ProyectadoL", "PROYECTADO", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "ProyectarM", "PROSPECTA", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "ProyectadoM", "PROYECTADO", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "ProyectarMI", "PROSPECTA", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "ProyectadoMI", "PROYECTADO", False, False, Nothing, 100, True, False, HAlign.Right)


        grdAgendaEntregas.DataSource = obj.ConsultaAgendaProyeccion(ProspectaID)


        grdAgendaEntregas.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grdAgendaEntregas.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grdAgendaEntregas.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard
        grdAgendaEntregas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdAgendaEntregas.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdAgendaEntregas.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdAgendaEntregas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdAgendaEntregas.DisplayLayout.Override.RowSelectorWidth = 35
        grdAgendaEntregas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grdAgendaEntregas.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText
        grdAgendaEntregas.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grdAgendaEntregas.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grdAgendaEntregas.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdAgendaEntregas.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grdAgendaEntregas.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grdAgendaEntregas.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard

        EncabezadoGridAgendaProyeccion(grdAgendaEntregas)
    End Sub


    Public Sub CargarGridAgendaEntrega()

        Dim obj As New ProspectaBU
        grdAgendaEntregas.DataSource = Nothing

        AgregarColumna(grdAgendaEntregas, "ClienteSicyID", "ClienteSicyID", True, False, Nothing, 100, , False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "ClienteSayID", "ClienteSayID", True, True, Nothing, 100, , False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "Cliente", "CLIENTE", False, True, Nothing, 220, , False, HAlign.Left)
        AgregarColumna(grdAgendaEntregas, "EntregarL", "PROSPECTA", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "EntregadoL", "ENTREGADO", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "EntregarM", "PROSPECTA", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "EntregadoM", "ENTREGADO", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "EntregarMi", "PROSPECTA", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "EntregadoMi", "ENTREGADO", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "EntregarJ", "PROSPECTA", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "EntregadoJ", "ENTREGADO", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "EntregarV", "PROSPECTA", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "EntregadoV", "ENTREGADO", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "EntregarS", "PROSPECTA", False, False, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "EntregadoS", "ENTREGADO", False, False, Nothing, 100, True, False, HAlign.Right)


        grdAgendaEntregas.DataSource = obj.ConsultaAgendaEntrega(ProspectaID)

        grdAgendaEntregas.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grdAgendaEntregas.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grdAgendaEntregas.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard
        grdAgendaEntregas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdAgendaEntregas.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdAgendaEntregas.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdAgendaEntregas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdAgendaEntregas.DisplayLayout.Override.RowSelectorWidth = 35
        grdAgendaEntregas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True        
        grdAgendaEntregas.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText
        grdAgendaEntregas.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grdAgendaEntregas.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grdAgendaEntregas.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdAgendaEntregas.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grdAgendaEntregas.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grdAgendaEntregas.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard

        EncabezadoGridEntregas(grdAgendaEntregas)

    End Sub


    Public Function ColorPares(ByVal Programado As Integer, ByVal Real As Integer) As Color
        Dim Diferencia As Integer = 0
        Dim ColorIndicador As Color

        Diferencia = Programado - Real

        If Diferencia = 0 Then
            ColorIndicador = Color.YellowGreen
        ElseIf Diferencia < 0 Then
            'ColorIndicador = Color.Yellow
            ColorIndicador = Color.Tomato
        ElseIf Diferencia > 0 Then
            ColorIndicador = Color.Tomato
        End If

        Return ColorIndicador
    End Function

    Public Sub CargarGrid()

        dtApartadosProspecta.Columns.Add("Cliente")
        dtApartadosProspecta.Columns.Add("Proyectar1")
        dtApartadosProspecta.Columns.Add("Proyectado1")
        dtApartadosProspecta.Columns.Add("Proyectar2")
        dtApartadosProspecta.Columns.Add("Proyectado2")
        dtApartadosProspecta.Columns.Add("Proyectar3")
        dtApartadosProspecta.Columns.Add("Proyectado3")
        dtApartadosProspecta.Columns.Add("Proyectar4")
        dtApartadosProspecta.Columns.Add("Proyectado4")
        dtApartadosProspecta.Columns.Add("Proyectar5")
        dtApartadosProspecta.Columns.Add("Proyectado5")
        dtApartadosProspecta.Columns.Add("Proyectar6")
        dtApartadosProspecta.Columns.Add("Proyectado6")

        dtApartadosProspecta.Rows.Add("1538", "160246", "3216", "116454", "GERARDO CHEVAILE RAMOS", "14", "", "", "", "", "", "", "")
        dtApartadosProspecta.Rows.Add("1375", "159858", "8875", "121927", "ECOON ZAPATERIAS (ARELLANO)", "4", "", "", "", "", "", "", "")

        AgregarColumna(grdAgendaEntregas, "Cliente", "Cliente", False, True, Nothing, 100, False, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "Proyectar1", "Proyectar", False, True, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "Proyectado1", "Proyectado", False, True, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "Proyectar2", "Proyectar", False, True, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "Proyectado2", "Proyectado", False, True, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "Proyectar3", "Proyectar", False, True, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "Proyectado3", "Proyectado", False, True, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "Proyectar4", "Proyectar", False, True, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "Proyectado4", "Proyectado", False, True, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "Proyectar5", "Proyectar", False, True, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "Proyectado5", "Proyectado", False, True, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "Proyectar6", "Proyectar", False, True, Nothing, 100, True, False, HAlign.Right)
        AgregarColumna(grdAgendaEntregas, "Proyectado6", "Proyectado", False, True, Nothing, 100, True, False, HAlign.Right)


        grdAgendaEntregas.DataSource = dtApartadosProspecta

        EncabezadoGridEntregas(grdAgendaEntregas)

        grdAgendaEntregas.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grdAgendaEntregas.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grdAgendaEntregas.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard
        grdAgendaEntregas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
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

    Public Sub exportarExcel()
        Dim sfd As New SaveFileDialog
        Dim grd As UltraGrid

        If IsNothing(grd) = False Then
            If grd.Rows.Count = 0 Then
                show_message("Advertencia", "No hay información para exportar a excel.")
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
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
    End Sub

    Public Function show_message(ByVal tipo As String, ByVal mensaje As String) As DialogResult
        Dim ResultadoDialogo As DialogResult

        If tipo.ToString.Equals("Advertencia") Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then
            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            ResultadoDialogo = mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            ResultadoDialogo = mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        Return ResultadoDialogo
    End Function

    Private Sub EncabezadoGridEntregas(ByVal grid As UltraGrid)
        'GUARDAMOS EL DISEÑO Y LA BANDA EN VARIABLES PARA HACER REFERENCIA A ELLOS MAS FACIL 
        Dim Layout As UltraGridLayout = grid.DisplayLayout
        Dim rootBand As UltraGridBand = Layout.Bands(0)
        Dim FechaInicio As Date = FechaInicioProspecta
        rootBand.RowLayoutStyle = RowLayoutStyle.GroupLayout

        'FOR PARA AGREGAR LOS RESPECTIVOS GRUPOS 
        For n = 0 To rootBand.Columns.Count - 1 Step 1

            If (n < 3 Or n > 4) And (n < 5 Or n > 6) And (n < 7 Or n > 8) And (n < 9 Or n > 10) And (n < 11 Or n > 12) And (n < 13 Or n > 14) Then
                Dim grupo As UltraGridGroup = rootBand.Groups.Add(rootBand.Columns(n).Header.Caption + n.ToString, " ")
                rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = grupo

                If n = 0 Or n = 1 Then
                    grupo.Hidden = True
                End If
            Else
                If n >= 3 And n <= 4 Then
                    If n = 3 Then
                        Dim NombreColumna As String
                        NombreColumna = ObtenerFecha(FechaInicio)
                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups(ObtenerFecha(FechaInicio))
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                End If

                If n >= 5 And n <= 6 Then
                    If n = 5 Then
                        FechaInicio = FechaInicio.AddDays(1)
                        Dim NombreColumna As String
                        NombreColumna = ObtenerFecha(FechaInicio)
                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups(ObtenerFecha(FechaInicio))
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                End If

                If n >= 7 And n <= 8 Then
                    If n = 7 Then
                        FechaInicio = FechaInicio.AddDays(1)
                        Dim NombreColumna As String
                        NombreColumna = ObtenerFecha(FechaInicio)
                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups(ObtenerFecha(FechaInicio))
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                End If

                If n >= 9 And n <= 10 Then
                    If n = 9 Then
                        FechaInicio = FechaInicio.AddDays(1)
                        Dim NombreColumna As String
                        NombreColumna = ObtenerFecha(FechaInicio)
                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups(ObtenerFecha(FechaInicio))
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                End If

                If n >= 11 And n <= 12 Then
                    If n = 11 Then
                        FechaInicio = FechaInicio.AddDays(1)
                        Dim NombreColumna As String
                        NombreColumna = ObtenerFecha(FechaInicio)
                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups(ObtenerFecha(FechaInicio))
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                End If

                If n >= 13 And n <= 14 Then
                    If n = 13 Then
                        FechaInicio = FechaInicio.AddDays(1)
                        Dim NombreColumna As String
                        NombreColumna = ObtenerFecha(FechaInicio)
                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups(ObtenerFecha(FechaInicio))
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                End If

            End If
        Next

    End Sub

    Private Function ObtenerFecha(ByVal Fecha As Date) As String
        Dim FormatoTitulo As String = String.Empty
        Dim day As New DayOfWeek
        'Fecha.DayOfWeek.Thursday
        If Fecha.DayOfWeek.ToString = "Monday" Then
            FormatoTitulo = "L"
        ElseIf Fecha.DayOfWeek.ToString = "Tuesday" Then
            FormatoTitulo = "M"
        ElseIf Fecha.DayOfWeek.ToString = "Wednesday" Then
            FormatoTitulo = "MI"
        ElseIf Fecha.DayOfWeek.ToString = "Thursday" Then
            FormatoTitulo = "J"
        ElseIf Fecha.DayOfWeek.ToString = "Friday" Then
            FormatoTitulo = "V"
        ElseIf Fecha.DayOfWeek.ToString = "Saturday" Then
            FormatoTitulo = "S"
        ElseIf Fecha.DayOfWeek.ToString = "Sunday" Then
            FormatoTitulo = "D"
        End If

        If Fecha.Month > 9 Then
            FormatoTitulo = FormatoTitulo + " " + Fecha.Day.ToString + "/" + Fecha.Month.ToString()
        Else
            FormatoTitulo = FormatoTitulo + " " + Fecha.Day.ToString + "/0" + Fecha.Month.ToString()
        End If

        Return FormatoTitulo
    End Function

    Private Sub EncabezadoGridAgendaProyeccion(ByVal grid As UltraGrid)
        'GUARDAMOS EL DISEÑO Y LA BANDA EN VARIABLES PARA HACER REFERENCIA A ELLOS MAS FACIL 
        Dim Layout As UltraGridLayout = grid.DisplayLayout
        Dim rootBand As UltraGridBand = Layout.Bands(0)
        Dim FechaInicio As Date = FechaInicioProspecta
        Dim FormatoTitulo As String = String.Empty

        FechaInicio = FechaInicio.AddDays(-4) 'La proyeccion comienza desde el jueves
        rootBand.RowLayoutStyle = RowLayoutStyle.GroupLayout

        'FOR PARA AGREGAR LOS RESPECTIVOS GRUPOS 
        For n = 0 To rootBand.Columns.Count - 1 Step 1

            If (n < 3 Or n > 4) And (n < 5 Or n > 6) And (n < 7 Or n > 8) And (n < 9 Or n > 10) And (n < 11 Or n > 12) And (n < 13 Or n > 14) Then
                Dim grupo As UltraGridGroup = rootBand.Groups.Add(rootBand.Columns(n).Header.Caption + n.ToString, " ")
                rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = grupo

                If n = 0 Or n = 1 Then
                    grupo.Hidden = True
                End If


            Else
                If n >= 3 And n <= 4 Then
                    If n = 3 Then
                        Dim NombreColumna As String
                        NombreColumna = ObtenerFecha(FechaInicio)
                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups(ObtenerFecha(FechaInicio))
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                End If

                If n >= 5 And n <= 6 Then
                    If n = 5 Then
                        FechaInicio = FechaInicio.AddDays(1)
                        Dim NombreColumna As String
                        NombreColumna = ObtenerFecha(FechaInicio)
                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups(ObtenerFecha(FechaInicio))
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                End If

                If n >= 7 And n <= 8 Then
                    If n = 7 Then
                        FechaInicio = FechaInicio.AddDays(1)
                        Dim NombreColumna As String
                        NombreColumna = ObtenerFecha(FechaInicio)
                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo

                        Grupo.Hidden = True
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups(ObtenerFecha(FechaInicio))
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                End If

                If n >= 9 And n <= 10 Then
                    If n = 9 Then
                        FechaInicio = FechaInicio.AddDays(2)
                        Dim NombreColumna As String
                        NombreColumna = ObtenerFecha(FechaInicio)
                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups(ObtenerFecha(FechaInicio))
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                End If

                If n >= 11 And n <= 12 Then
                    If n = 11 Then
                        FechaInicio = FechaInicio.AddDays(1)
                        Dim NombreColumna As String
                        NombreColumna = ObtenerFecha(FechaInicio)
                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups(ObtenerFecha(FechaInicio))
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                End If

                If n >= 13 And n <= 14 Then
                    If n = 13 Then
                        FechaInicio = FechaInicio.AddDays(1)
                        Dim NombreColumna As String
                        NombreColumna = ObtenerFecha(FechaInicio)
                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups(ObtenerFecha(FechaInicio))
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                End If
            End If
        Next

    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel(grdAgendaEntregas)
    End Sub

    Public Sub exportarExcel(ByVal grd As UltraGrid)
        Dim sfd As New SaveFileDialog

        If IsNothing(grd) = False Then
            If grd.Rows.Count = 0 Then
                show_message("Advertencia", "No hay información para exportar a excel.")
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
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
    End Sub

    Public Sub SetColorIndicador(ByVal Programado As UltraGridCell, ByVal Real As UltraGridCell)
        Dim LProgramado As Integer = 0
        Dim LReal As Integer = 0
        Dim ColorIndicador As Color

        If IsDBNull(Programado.Value) = True Then
            LProgramado = -1
        Else
            LProgramado = Programado.Value
        End If

        If IsDBNull(Real.Value) = True Then
            LReal = 0
        Else
            LReal = Real.Value
        End If


        If LReal > 0 Or LProgramado > 0 Then
            ColorIndicador = ColorPares(LProgramado, LReal)
            Programado.Appearance.BackColor = ColorIndicador
            Real.Appearance.BackColor = ColorIndicador
        End If

        


    End Sub

    Private Sub grdAgendaEntregas_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdAgendaEntregas.InitializeRow        
        

        If IsNothing(grdAgendaEntregas.DataSource) = False Then
            If e.Row.Index >= 0 Then
                If TipoAgenda = 1 Then ' Agenda Entregas
                    SetColorIndicador(e.Row.Cells("EntregarL"), e.Row.Cells("EntregadoL"))
                    SetColorIndicador(e.Row.Cells("EntregarM"), e.Row.Cells("EntregadoM"))
                    SetColorIndicador(e.Row.Cells("EntregarMi"), e.Row.Cells("EntregadoMi"))
                    SetColorIndicador(e.Row.Cells("EntregarJ"), e.Row.Cells("EntregadoJ"))
                    SetColorIndicador(e.Row.Cells("EntregarV"), e.Row.Cells("EntregadoV"))
                    SetColorIndicador(e.Row.Cells("EntregarS"), e.Row.Cells("EntregadoS"))

                ElseIf TipoAgenda = 2 Then 'Agenda de Proyecciones

                    SetColorIndicador(e.Row.Cells("ProyectarJ"), e.Row.Cells("ProyectadoJ"))
                    SetColorIndicador(e.Row.Cells("ProyectarV"), e.Row.Cells("ProyectadoV"))
                    SetColorIndicador(e.Row.Cells("ProyectarS"), e.Row.Cells("ProyectadoS"))
                    SetColorIndicador(e.Row.Cells("ProyectarL"), e.Row.Cells("ProyectadoL"))
                    SetColorIndicador(e.Row.Cells("ProyectarM"), e.Row.Cells("ProyectadoM"))
                    SetColorIndicador(e.Row.Cells("ProyectarMI"), e.Row.Cells("ProyectadoMI"))

                End If
            End If
        End If
    End Sub

End Class