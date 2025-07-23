Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization

Public Class HistorialProspectaForm

    Dim ProspectaID As Integer = -1

    Private Sub HistorialProspectaForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim numeroSemana As Integer
        Me.Location = New Point(0, 0)
        Me.WindowState = FormWindowState.Maximized
        dtmFechaInicio.Value = Date.Now.AddMonths(-1).AddDays(-Date.Now.Day + 1)
        dtmFechaFin.Value = Date.Now.AddMonths(1).AddDays(-Date.Now.Day + 14)
        lblFechaUltimaActualizacion.Visible = False
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_JEFATURA") Then
            pnlAltas.Visible = True
            'btnAltas.Enabled = True
            'lblAltas.Enabled = True
        Else
            pnlAltas.Visible = False
            'btnAltas.Enabled = False
            'lblAltas.Enabled = False
        End If

        Dim Fecha As Date = Date.Now
        Fecha = Fecha.AddDays(7)

        numeroSemana = If(Fecha.Year = 2021 Or Fecha.Year = 2022, DatePart(DateInterval.WeekOfYear, Fecha) - 1, DatePart(DateInterval.WeekOfYear, Fecha))
        nudNumSemana.Value = numeroSemana
        nudAño.Value = Fecha.Year

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_CONS_PROS_ALMACEN") Then
            pnlConsultarProspectado.Visible = True
            'btnConsultarProspecta.Visible = True
            'lblConsultaProspecta.Visible = True
        Else
            pnlConsultarProspectado.Visible = False
            'btnConsultarProspecta.Visible = False
            'lblConsultaProspecta.Visible = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_CONS_PORMARCA") Then
            pnlConsultarPorMarca.Visible = True
            'btnConsultarProspecta.Visible = True
            'lblConsultaProspecta.Visible = True
        Else
            pnlConsultarPorMarca.Visible = False
            'btnConsultarProspecta.Visible = False
            'lblConsultaProspecta.Visible = False
        End If
    End Sub


    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim objProspecta As New Ventas.Negocios.ProspectaBU
        Dim dtInformacionUsuarioActivo As DataTable
        'Dim FechaInicio As Date = "16/01/2017"
        'Dim FechaFin As Date = "21/01/2017"
        'objProspecta.AltaProspecta(4, 2017, FechaInicio, FechaFin, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        'Dim Form As New ProspectaForm
        'Form.ShowDialog()


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_JEFATURA") Then
            If objProspecta.ValidarExisteProspectaProxima() = False Then
                dtInformacionUsuarioActivo = objProspecta.ObtenerInformacionUsuarioAltaProspecta()
                'Si ya esta un usuario creando la prospecta no se puede entrar a la prospecta
                If dtInformacionUsuarioActivo.Rows.Count > 0 Then
                    show_message("Aviso", "El usuario " + dtInformacionUsuarioActivo.Rows(0).Item("UserName").ToString() + " está generando una prospecta (" + dtInformacionUsuarioActivo.Rows(0).Item("FActividad").ToString() + "). Intente más tarde")
                Else
                    objProspecta.RegistrarActivadadUsuarioProspecta(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, -1, False)
                    Dim Form As New ProspectaForm
                    Form.MdiParent = Me.MdiParent
                    Form.Show()
                End If

                'objProspecta.RegistrarActivadadUsuarioProspecta(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, -1, False)
                'Dim Form As New ProspectaForm
                'Form.ShowDialog()

            Else
                show_message("Aviso", "Ya existe una prospecta en status Próxima o en Revisión.")
            End If
        End If


        'Dim FrmAltaProspecta As New AltaProspectaForm
        'Dim objProspecta As New Ventas.Negocios.ProspectaBU
        'Dim dtInformacionUsuarioActivo As DataTable

        ' ''Solo se pertimite tener una prospecta en estado de proxima
        ''If objProspecta.ValidarExisteProspectaProxima() = False Then
        ''    dtInformacionUsuarioActivo = objProspecta.ObtenerInformacionUsuarioAltaProspecta()
        ''    'Si ya esta un usuario creando la prospecta no se puede entrar a la prospecta
        ''    If dtInformacionUsuarioActivo.Rows.Count > 0 Then
        ''        show_message("Aviso", "El usuario " + dtInformacionUsuarioActivo.Rows(0).Item("UserName").ToString() + " está generando una prospecta (" + dtInformacionUsuarioActivo.Rows(0).Item("FActividad").ToString() + "). Intente más tarde")
        ''    Else
        ''        objProspecta.RegistrarActivadadUsuarioProspecta(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, -1)
        ''        FrmAltaProspecta.MdiParent = Me.MdiParent
        ''        FrmAltaProspecta.Show()
        ''    End If
        ''Else
        ''    show_message("Aviso", "Existe una prospecta en status Próxima, debe editar esta prospecta o cancelarla para generar una nueva.")
        ''End If


        'FrmAltaProspecta.MdiParent = Me.MdiParent
        'FrmAltaProspecta.Show()


        ''If ObjPRospecta.ConsultarNumeroDeUsuariosConsulta(-1, -1) = 0 Then
        ''    objProspecta.LimpiarTemporalPares()
        ''End If


        '' objProspecta.RegistrarActivadadUsuarioProspecta(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, -1)

        ''Dim objProspecta As New Ventas.Negocios.ProspectaBU
        ''Dim dtInformacionUsuarioActivo As DataTable
        ''If objProspecta.ConsultaActividadUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, -1) = False Then
        ''    If objProspecta.ValidarExisteProspectaProxima() = False Then
        ''        objProspecta.RegistrarActivadadUsuarioProspecta(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, -1)
        ''        Dim FrmAltaProspecta As New AltaProspectaForm
        ''        FrmAltaProspecta.MdiParent = Me.MdiParent
        ''        FrmAltaProspecta.Show()
        ''    Else
        ''        show_message("Aviso", "Existe una prospecta en status Próxima, debe editar esta prospecta o cancelarla para generar una nueva.")
        ''    End If
        ''Else
        ''    dtInformacionUsuarioActivo = objProspecta.ObtenerInformacionUsuarioActivo()
        ''    show_message("Aviso", "El usuario " + dtInformacionUsuarioActivo.Rows(0).Item("UserName").ToString() + " está generando una prospecta (" + dtInformacionUsuarioActivo.Rows(0).Item("FechaInicioActividad").ToString() + "). Intente más tarde")
        ''End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub CargarListadoProspectas(ByVal FechaInicio As Date, ByVal FechaFin As Date)
        Try
            Cursor = Cursors.WaitCursor
            Dim objProspecta As New Ventas.Negocios.ProspectaBU
            Dim NumeroSemana As Integer = -1

            gridListaHistorialProspecta.DataSource = Nothing
            DibujarGrid(gridListaHistorialProspecta)

            If rdoSemana.Checked = True Then
                NumeroSemana = nudNumSemana.Value
            Else
                NumeroSemana = -1
            End If


            gridListaHistorialProspecta.DataSource = objProspecta.ConsultaHistorialProspecta(FechaInicio, FechaFin, NumeroSemana)
            lblNumFiltrados.Text = gridListaHistorialProspecta.Rows.Count.ToString()
            lblFechaUltimaActualizacion.Visible = True
            lblFechaUltimaActualizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()

            Dim listaProspectas = gridListaHistorialProspecta.Rows.Where(Function(x) x.Cells("EstatusID").Value = 87 Or x.Cells("EstatusID").Value = 88 Or x.Cells("EstatusID").Value = 90)

            For Each Fila As UltraGridRow In listaProspectas
                objProspecta.ActualizarEncabezadoProspecta(Fila.Cells("ProspectaID").Value)
            Next



            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If dtmFechaInicio.Value > dtmFechaFin.Value Then
            show_message("Advertencia", "La fecha de inicio no puede ser mayor que la fecha final")
        Else
            CargarListadoProspectas(dtmFechaInicio.Value, dtmFechaFin.Value)
        End If
        ProspectaID = -1
        'btnRevision.Enabled = False
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

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel(gridListaHistorialProspecta)
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

    Private Sub gridListaHistorialProspecta_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridListaHistorialProspecta.ClickCell
        Dim row As UltraGridRow = gridListaHistorialProspecta.ActiveRow
        If row.IsFilterRow = True Then
            ProspectaID = -1
            'btnRevision.Enabled = False
            Return
        End If

        'btnRevision.Enabled = True
        ProspectaID = CInt(row.Cells("ProspectaID").Value())

    End Sub





    Private Sub gridListaHistorialProspecta_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles gridListaHistorialProspecta.DoubleClickCell
        'Dim row As UltraGridRow = gridListaHistorialProspecta.ActiveRow
        'Dim FormConsultaProspecta As New AltaProspectaForm
        'If row.IsFilterRow Then Return
        'ProspectaID = CInt(row.Cells("ProspectaID").Value())
        'FormConsultaProspecta.ProspectaID = ProspectaID
        'FormConsultaProspecta.MdiParent = Me.MdiParent
        'FormConsultaProspecta.Show()
        'Dim Form As New ProspectaPrueba

        'Form.ShowDialog()

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_ALMACEN") Then

        Else

            Dim row As UltraGridRow = gridListaHistorialProspecta.ActiveRow
            Dim FormConsultaProspecta As New ProspectaForm
            If row.IsFilterRow Then Return
            ProspectaID = CInt(row.Cells("ProspectaID").Value())
            FormConsultaProspecta.ProspectaID = ProspectaID
            FormConsultaProspecta.MdiParent = Me.MdiParent
            FormConsultaProspecta.Show()
        End If

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

    Public Sub DibujarGrid(ByVal grid As UltraGrid)


        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        '        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Default
        'grid.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard



        'grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns


        AgregarColumna(grid, "ProspectaID", "ProspectaID", True, True, Nothing, 220, False, False, HAlign.Left)
        AgregarColumna(grid, "StatusSemaforo", " ", False, True, Nothing, 20, False, False, HAlign.Left)
        AgregarColumna(grid, "NumeroSemana", "Número Semana", False, True, Nothing, 60, , , HAlign.Right)
        AgregarColumna(grid, "Año", "Año", False, True, Nothing, 60, , False, HAlign.Right)
        AgregarColumna(grid, "FInicio", "FInicio", False, True, Nothing, 70, , False, HAlign.Left)
        AgregarColumna(grid, "FFin", "FFin", False, True, Nothing, 70, , False, HAlign.Left, , , , )
        AgregarColumna(grid, "UsuarioCreoID", "UsuarioCreoID", True, True, Nothing, 200, , , HAlign.Left)
        AgregarColumna(grid, "Creo", "Creó", False, True, Nothing, 100, , False, HAlign.Left)
        AgregarColumna(grid, "FCreacion", "FCreacion", False, True, Nothing, 90, , False, HAlign.Left)
        AgregarColumna(grid, "UsuarioModificoID", "UsuarioModificoID", True, True, Nothing, 100, , False, HAlign.Right)
        AgregarColumna(grid, "Modificó", "Modificó", False, True, Nothing, 100, , False, HAlign.Left)
        AgregarColumna(grid, "FModificación", "FModificación", False, True, Nothing, 100, , False, HAlign.Left)
        AgregarColumna(grid, "PrsProspecta", "Prs Prospecta", False, False, Nothing, 70, True, False, HAlign.Right)
        'AgregarColumna(grid, "PrsProyectados", "Prs a Proyectar", False, False, Nothing, 70, True, False, HAlign.Right)
        AgregarColumna(grid, "PrsEntregados", "Prs Entregados", False, False, Nothing, 70, True, False, HAlign.Right)
        AgregarColumna(grid, "PrsActualProyectados", "Prs Proyectados", False, False, Nothing, 70, True, False, HAlign.Right)
        AgregarColumna(grid, "STATUS", "STATUS", False, True, Nothing, 80, , False, HAlign.Left)
        AgregarColumna(grid, "EstatusID", "EstatusID", True, True, Nothing, 80, , False, HAlign.Right)
        '

        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns


    End Sub


    Private Sub btnRevision_Click(sender As Object, e As EventArgs)
        Dim Form As New ProspectaNotasRevisionForm
        If ProspectaID = -1 Then
            show_message("Advertencia", "Debe seleccionar una prospecta.")
        Else
            Form.ProspectaID = ProspectaID
            Form.ShowDialog()
        End If

    End Sub


    Private Sub rdoSemana_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSemana.CheckedChanged
        If rdoSemana.Checked = True Then
            nudNumSemana.Enabled = True
            nudAño.Enabled = True
            dtmFechaInicio.Enabled = False
            dtmFechaFin.Enabled = False
            CargarFechas()
        Else
            nudNumSemana.Enabled = False
            nudAño.Enabled = False
            dtmFechaInicio.Enabled = True
            dtmFechaFin.Enabled = True
        End If
    End Sub

    Private Sub rdoFecha_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFecha.CheckedChanged

        If rdoFecha.Checked = True Then
            nudNumSemana.Enabled = False
            nudAño.Enabled = False
            dtmFechaInicio.Enabled = True
            dtmFechaFin.Enabled = True
        Else
            nudNumSemana.Enabled = False
            nudAño.Enabled = False
            dtmFechaInicio.Enabled = True
            dtmFechaFin.Enabled = True
        End If
    End Sub

    Private Sub nudNumSemana_ValueChanged(sender As Object, e As EventArgs) Handles nudNumSemana.ValueChanged
        CargarFechas()
    End Sub

    Private Sub nudAño_ValueChanged(sender As Object, e As EventArgs) Handles nudAño.ValueChanged
        CargarFechas()
    End Sub

    Public Sub CargarFechas()
        Dim objProspecta As New Ventas.Negocios.ProspectaBU
        Dim FechaInicio As Date = "01/01/" + nudAño.Value.ToString()
        Dim fecha As Date = DateAdd("ww", nudNumSemana.Value - 1, FechaInicio)
        Dim cal As Calendar = DateTimeFormatInfo.CurrentInfo.Calendar
        If cal.GetDayOfWeek(fecha) = 0 Then
            fecha = DateAdd("d", 1, fecha)
        ElseIf cal.GetDayOfWeek(fecha) > 0 Then
            fecha = DateAdd("d", (cal.GetDayOfWeek(fecha) - 1) * -1, fecha)
        End If
        fecha = If(nudAño.Value = 2022 Or nudAño.Value = 2021, DateAdd("d", 7, fecha), fecha)
        dtmFechaInicio.Value = fecha
        dtmFechaFin.Value = DateAdd("d", 5, fecha)
    End Sub

    Private Sub gridListaHistorialProspecta_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles gridListaHistorialProspecta.InitializeRow
        If e.Row.Index >= 0 Then
            Select Case e.Row.Cells("STATUS").Value
                Case "REVISIÓN"
                    e.Row.Cells("StatusSemaforo").Appearance.BackColor = pnlRevision.BackColor
                Case "VIGENTE"
                    e.Row.Cells("StatusSemaforo").Appearance.BackColor = pnlVigente.BackColor
                Case "CERRADA"
                    e.Row.Cells("StatusSemaforo").Appearance.BackColor = pnlCerrada.BackColor
            End Select
        End If
    End Sub

    Private Sub btnConsultarProspecta_Click(sender As Object, e As EventArgs) Handles btnConsultarProspecta.Click
        Dim Form As New ConsultaProspectaAlmacenForm
        If ProspectaID > 0 Then
            Form.ProspectaID = ProspectaID
            Form.MdiParent = Me.MdiParent            
            Form.Show()
        Else
            show_message("Advertencia", "Debe seleccionar una prospecta.")
        End If
        
    End Sub

    Private Sub btnConsultaPorMarca_Click(sender As Object, e As EventArgs) Handles btnConsultaPorMarca.Click
        If ProspectaID > 0 Then
            Dim formConsultaPorMarca As New ConsultaProspectaPorMarca
            formConsultaPorMarca.ProspectaID = ProspectaID
            formConsultaPorMarca.MdiParent = Me.MdiParent
            formConsultaPorMarca.Show()
        Else
            show_message("Advertencia", "Debe seleccionar una prospecta.")
        End If
    End Sub
End Class