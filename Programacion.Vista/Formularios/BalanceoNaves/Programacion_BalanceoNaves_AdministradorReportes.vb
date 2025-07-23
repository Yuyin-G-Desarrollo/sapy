Imports System.IO
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks
Imports Framework.Negocios
Imports Programacion.Negocios
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Export
Imports Tools

Public Class Programacion_BalanceoNaves_AdministradorReportes
    Dim NaveID As Integer
    Dim Semana As Integer
    Dim Año As Integer

    Private Sub Programacion_BalanceoNaves_AdministradorReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        nudSemanaInicio.Value = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        nudSemanaInicio.TextAlign = HorizontalAlignment.Center
        nudAño.Value = DatePart(DateInterval.Year, Now)
        nudAño.TextAlign = HorizontalAlignment.Center
        lblUltimaActualizacion.Text = ""


        XtraTabPage1.Appearance.Header.BackColor = Color.DarkSalmon
        XtraTabPage1.Appearance.HeaderActive.BackColor = Color.DarkSalmon

        XtraTabPage2.Appearance.Header.BackColor = Color.LightSkyBlue
        XtraTabPage2.Appearance.HeaderActive.BackColor = Color.LightSkyBlue

        XtraTabPage3.Appearance.Header.BackColor = Color.DarkSeaGreen
        XtraTabPage3.Appearance.HeaderActive.BackColor = Color.DarkSeaGreen

        XtraTabPage4.Appearance.Header.BackColor = Color.LightBlue
        XtraTabPage4.Appearance.HeaderActive.BackColor = Color.LightBlue


    End Sub

    Private Sub CargarNaveSegunUsuario(ByVal Grupo As String)
        Dim UsuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim objBU As New BalanceoNavesBU
        Dim objBUP As New PlanFabricacionBU
        Dim dtNaves As New DataTable

        dtNaves = objBUP.ObtenerNavesPorUsuario(UsuarioID)

        If dtNaves.Rows.Count > 0 Then

            If dtNaves.Rows.Count = 1 Then
                cmbNave.Enabled = False
                cmbGrupo.Visible = False
                lblGrupo.Visible = False


                cmbNave.DataSource = dtNaves
                cmbNave.ValueMember = "NaveID"
                cmbNave.DisplayMember = "Nave"
            Else
                cmbNave.Enabled = True
                cmbGrupo.Visible = True
                lblGrupo.Visible = True


                If cmbGrupo.Text <> "" Then
                    dtNaves = objBU.ConsultarNavesAux(Grupo)

                    If dtNaves.Rows.Count > 0 Then
                        dtNaves.Rows.InsertAt(dtNaves.NewRow, 0)
                        cmbNave.DataSource = dtNaves
                        cmbNave.ValueMember = "NaveSAYId"
                        cmbNave.DisplayMember = "Nave"

                    Else
                        show_message("Advertencia", "No existe información de naves.")
                    End If
                End If
            End If

        Else
            show_message("Advertencia", "El usuario no cuenta con una nave asignada.")
        End If
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New Tools.AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New Tools.AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If
    End Sub

    Private Sub cmbGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrupo.SelectedIndexChanged
        If cmbGrupo.Text <> "" Then
            CargarNaveSegunUsuario(cmbGrupo.Text)
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New BalanceoNavesBU
        Dim dtNecesidadParesSemanal As New DataTable
        Dim dtDesgloseProyeccion As New DataTable
        Dim dtDistribucionEquivalencias As New DataTable
        Dim dtConversionEquivalencias As New DataTable

        Try

            If cmbNave.Text <> "" Then
                NaveID = cmbNave.SelectedValue
            Else
                show_message("Advertencia", "Seleccione una Nave.")
                Exit Sub
            End If


            Semana = nudSemanaInicio.Value
            Año = nudAño.Value

            Cursor = Cursors.WaitCursor

            'Reporte Necesidad Semanal
            grdNecesidadSemanal.DataSource = Nothing
            vwNecesidadSemanal.Columns.Clear()

            'Reporte Desglose Proyeccion
            grdDesgloseProyeccion.DataSource = Nothing
            vwDesgloseProyeccion.Columns.Clear()

            'Reporte Distribución de Equivalencias
            grdDistribucionEquivalencias.DataSource = Nothing
            vwDistribucionEquivalencias.Columns.Clear()

            'Reporte Conversión de Equivalencias
            grdConversionEquivalencias.DataSource = Nothing
            vwConversionEquivalencias.Columns.Clear()


            dtNecesidadParesSemanal = objBU.ReporteNecesidadParesSemanal(NaveID, Semana, Año)
            dtDesgloseProyeccion = objBU.ReporteDesgloseProyeccion(NaveID, Semana, Año)
            dtDistribucionEquivalencias = objBU.ReporteDistribucionEquivalencias(NaveID, Semana, Año)
            dtConversionEquivalencias = objBU.ReporteConversionEquivalencias(NaveID, Semana, Año)

            'Reporte Necesidad Semanal
            If dtNecesidadParesSemanal.Rows.Count > 0 Then
                grdNecesidadSemanal.DataSource = dtNecesidadParesSemanal
                DisenioGrid("NecesidadSemanal")

            Else
                show_message("Advertencia", "No hay información para reporte necesidad semanal.")
            End If


            'Reporte Desglose Proyección
            If dtDesgloseProyeccion.Rows.Count > 0 Then

                dtDesgloseProyeccion.Columns(2).ColumnName = "Lunes"
                dtDesgloseProyeccion.Columns(3).ColumnName = "Martes"
                dtDesgloseProyeccion.Columns(4).ColumnName = "Miércoles"
                dtDesgloseProyeccion.Columns(5).ColumnName = "Jueves"
                dtDesgloseProyeccion.Columns(6).ColumnName = "Viernes"
                dtDesgloseProyeccion.Columns(7).ColumnName = "Sábado"

                grdDesgloseProyeccion.DataSource = dtDesgloseProyeccion
                DisenioGrid("DesgloseProyeccion")

            Else
                show_message("Advertencia", "No hay información para reporte necesidad semanal.")
            End If


            'Reporte Distribución de Equivalencias
            If dtDistribucionEquivalencias.Rows.Count > 0 Then
                grdDistribucionEquivalencias.DataSource = dtDistribucionEquivalencias
                DisenioGrid("DistribucionEquivalencias")
            Else
                show_message("Advertencia", "No hay información para reporte distribución equivalencias.")
            End If

            'Reporte Conversión de Equivalencias
            If dtConversionEquivalencias.Rows.Count > 0 Then
                grdConversionEquivalencias.DataSource = dtConversionEquivalencias
                DisenioGrid("ConversionEquivalencias")
            Else
                show_message("Advertencia", "No hay información para reporte conversión de equivalencias.")
            End If


            lblUltimaActualizacion.Text = Date.Now


        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub DisenioGrid(ByVal TipoReporte As String)

        Select Case TipoReporte
            Case "NecesidadSemanal"
                For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwNecesidadSemanal.Columns
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
                    col.OptionsColumn.AllowEdit = False
                Next

                vwNecesidadSemanal.Columns.ColumnByFieldName("Pares Propuestos").Width = 100
                vwNecesidadSemanal.Columns.ColumnByFieldName("Pares Propuestos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwNecesidadSemanal.Columns.ColumnByFieldName("Pares Propuestos").DisplayFormat.FormatString = "N0"

                vwNecesidadSemanal.Columns.ColumnByFieldName("Días Laborables").Width = 100

                vwNecesidadSemanal.Columns.ColumnByFieldName("Pares Requeridos por Día").Width = 100
                vwNecesidadSemanal.Columns.ColumnByFieldName("Pares Requeridos por Día").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwNecesidadSemanal.Columns.ColumnByFieldName("Pares Requeridos por Día").DisplayFormat.FormatString = "N0"

                vwNecesidadSemanal.Columns.ColumnByFieldName("Pares Requeridos Medio Día").Width = 100
                vwNecesidadSemanal.Columns.ColumnByFieldName("Pares Requeridos Medio Día").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwNecesidadSemanal.Columns.ColumnByFieldName("Pares Requeridos Medio Día").DisplayFormat.FormatString = "N0"

                vwNecesidadSemanal.Columns.ColumnByFieldName("Equivalencias Requeridas por Día").Width = 100
                vwNecesidadSemanal.IndicatorWidth = 40

                DiseñoGrid.AlternarColorEnFilas(vwNecesidadSemanal)

            Case "DesgloseProyeccion"

                For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwDesgloseProyeccion.Columns
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
                    col.OptionsColumn.AllowEdit = False
                Next

                vwDesgloseProyeccion.Columns.ColumnByFieldName("Orden").Visible = False
                vwDesgloseProyeccion.Columns.ColumnByFieldName("Concepto").Width = 100
                vwDesgloseProyeccion.IndicatorWidth = 40


            Case "DistribucionEquivalencias"

                Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand

                vwDistribucionEquivalencias.Columns.Clear()
                vwDistribucionEquivalencias.Bands.Clear()
                vwDistribucionEquivalencias.Appearance.HeaderPanel.Options.UseBackColor = True
                vwDistribucionEquivalencias.OptionsView.AllowCellMerge = True
                vwDistribucionEquivalencias.OptionsBehavior.Editable = True

                band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                band.Caption = ""

                vwDistribucionEquivalencias.Columns.AddField("Equivalencia")
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("Equivalencia").OwnerBand = band
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("Equivalencia").Visible = True
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("Equivalencia").OptionsColumn.AllowEdit = False

                vwDistribucionEquivalencias.Columns.AddField("Total Pares")
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("Total Pares").OwnerBand = band
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("Total Pares").Visible = True
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("Total Pares").OptionsColumn.AllowEdit = False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("Total Pares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("Total Pares").DisplayFormat.FormatString = "N0"

                vwDistribucionEquivalencias.Bands.Add(band)

                band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                band.Caption = "Lunes"

                vwDistribucionEquivalencias.Columns.AddField("P1")
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P1").OwnerBand = band
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P1").Visible = True
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P1").OptionsColumn.AllowEdit = False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P1").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P1").Caption = "Pares"
                'vwDistribucionEquivalencias.Columns.ColumnByFieldName("P1").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P1").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P1").DisplayFormat.FormatString = "N0"

                vwDistribucionEquivalencias.Columns.AddField("E1")
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E1").OwnerBand = band
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E1").Visible = True
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E1").OptionsColumn.AllowEdit = False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E1").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E1").Caption = "Equivalencia"
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E1").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

                vwDistribucionEquivalencias.Bands.Add(band)

                band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                band.Caption = "Martes"

                vwDistribucionEquivalencias.Columns.AddField("P2")
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P2").OwnerBand = band
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P2").Visible = True
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P2").OptionsColumn.AllowEdit = False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P2").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P2").Caption = "Pares"
                'vwDistribucionEquivalencias.Columns.ColumnByFieldName("P2").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P2").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P2").DisplayFormat.FormatString = "N0"

                vwDistribucionEquivalencias.Columns.AddField("E2")
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E2").OwnerBand = band
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E2").Visible = True
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E2").OptionsColumn.AllowEdit = False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E2").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E2").Caption = "Equivalencia"
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E2").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

                vwDistribucionEquivalencias.Bands.Add(band)

                band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                band.Caption = "Miércoles"

                vwDistribucionEquivalencias.Columns.AddField("P3")
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P3").OwnerBand = band
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P3").Visible = True
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P3").OptionsColumn.AllowEdit = False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P3").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P3").Caption = "Pares"
                'vwDistribucionEquivalencias.Columns.ColumnByFieldName("P3").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P3").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P3").DisplayFormat.FormatString = "N0"

                vwDistribucionEquivalencias.Columns.AddField("E3")
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E3").OwnerBand = band
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E3").Visible = True
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E3").OptionsColumn.AllowEdit = False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E3").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E3").Caption = "Equivalencia"
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E3").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

                vwDistribucionEquivalencias.Bands.Add(band)

                band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                band.Caption = "Jueves"

                vwDistribucionEquivalencias.Columns.AddField("P4")
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P4").OwnerBand = band
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P4").Visible = True
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P4").OptionsColumn.AllowEdit = False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P4").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P4").Caption = "Pares"
                'vwDistribucionEquivalencias.Columns.ColumnByFieldName("P4").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P4").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P4").DisplayFormat.FormatString = "N0"

                vwDistribucionEquivalencias.Columns.AddField("E4")
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E4").OwnerBand = band
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E4").Visible = True
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E4").OptionsColumn.AllowEdit = False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E4").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E4").Caption = "Equivalencia"
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E4").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

                vwDistribucionEquivalencias.Bands.Add(band)

                band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                band.Caption = "Viernes"

                vwDistribucionEquivalencias.Columns.AddField("P5")
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P5").OwnerBand = band
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P5").Visible = True
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P5").OptionsColumn.AllowEdit = False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P5").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P5").Caption = "Equivalencia"
                'vwDistribucionEquivalencias.Columns.ColumnByFieldName("P5").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P5").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P5").DisplayFormat.FormatString = "N0"

                vwDistribucionEquivalencias.Columns.AddField("E5")
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E5").OwnerBand = band
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E5").Visible = True
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E5").OptionsColumn.AllowEdit = False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E5").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E5").Caption = "Equiv"
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E5").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

                vwDistribucionEquivalencias.Bands.Add(band)

                band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                band.Caption = "Sábado"

                vwDistribucionEquivalencias.Columns.AddField("P6")
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P6").OwnerBand = band
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P6").Visible = True
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P6").OptionsColumn.AllowEdit = False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P6").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P6").Caption = "Pares"
                'vwDistribucionEquivalencias.Columns.ColumnByFieldName("P6").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P6").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("P6").DisplayFormat.FormatString = "N0"

                vwDistribucionEquivalencias.Columns.AddField("E6")
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E6").OwnerBand = band
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E6").Visible = True
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E6").OptionsColumn.AllowEdit = False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E6").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E6").Caption = "Equivalencia"
                vwDistribucionEquivalencias.Columns.ColumnByFieldName("E6").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

                vwDistribucionEquivalencias.Bands.Add(band)

                Dim blnSum As Boolean = False
                Dim strFormat As String = String.Empty

                For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In vwDistribucionEquivalencias.Bands
                    gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    For Each childrenBand In gridband.Children
                        childrenBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    Next
                Next

                For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In vwDistribucionEquivalencias.Columns
                    blnSum = False
                    strFormat = String.Empty

                    Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    Col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

                    Select Case Col.FieldName
                        Case "Equivalencia"
                            Col.Width = 115
                        Case "Total Pares"
                            blnSum = True
                            strFormat = "{0:N0}"
                            Col.Width = 115
                        Case "P1"
                            blnSum = True
                            strFormat = "{0:N0}"
                            Col.Width = 90
                        Case "E1"
                            blnSum = True
                            strFormat = "{0:N0}"
                            Col.Width = 90
                        Case "P2"
                            blnSum = True
                            strFormat = "{0:N0}"
                            Col.Width = 90
                        Case "E2"
                            blnSum = True
                            strFormat = "{0:N0}"
                            Col.Width = 90
                        Case "P3"
                            blnSum = True
                            strFormat = "{0:N0}"
                            Col.Width = 90
                        Case "E3"
                            blnSum = True
                            strFormat = "{0:N0}"
                            Col.Width = 90
                        Case "P4"
                            blnSum = True
                            strFormat = "{0:N0}"
                            Col.Width = 90
                        Case "E4"
                            blnSum = True
                            strFormat = "{0:N0}"
                            Col.Width = 90
                        Case "P5"
                            blnSum = True
                            strFormat = "{0:N0}"
                            Col.Width = 90
                        Case "E5"
                            blnSum = True
                            strFormat = "{0:N0}"
                            Col.Width = 90
                        Case "P6"
                            blnSum = True
                            strFormat = "{0:N0}"
                            Col.Width = 90
                        Case "E6"
                            blnSum = True
                            strFormat = "{0:N0}"
                            Col.Width = 90
                    End Select

                    If blnSum = True AndAlso IsNothing(vwDistribucionEquivalencias.Columns(Col.FieldName).Summary.FirstOrDefault(Function(x) x.FieldName = Col.FieldName)) = True Then
                        vwDistribucionEquivalencias.Columns(Col.FieldName).Summary.Add(DevExpress.Data.SummaryItemType.Sum, Col.FieldName, strFormat) '"{0:N2}")
                        Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                        item.FieldName = Col.FieldName
                        item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        item.DisplayFormat = strFormat ' "{0:N2}"
                        vwDistribucionEquivalencias.GroupSummary.Add(item)


                    End If
                    Col.DisplayFormat.FormatString = strFormat
                Next
                vwDistribucionEquivalencias.IndicatorWidth = 40
                DiseñoGrid.AlternarColorEnFilas(vwDistribucionEquivalencias)

            Case "ConversionEquivalencias"

                For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwConversionEquivalencias.Columns
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
                    col.OptionsColumn.AllowEdit = False
                Next

                vwConversionEquivalencias.IndicatorWidth = 40
                vwConversionEquivalencias.Columns.ColumnByFieldName("Equivalencia").Width = 100

                vwConversionEquivalencias.Columns.ColumnByFieldName("Pares").Width = 100
                vwConversionEquivalencias.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwConversionEquivalencias.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatString = "N0"

                vwConversionEquivalencias.Columns.ColumnByFieldName("Equivalencia por Día").Width = 100
                vwConversionEquivalencias.Columns.ColumnByFieldName("Equivalencia por Día").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwConversionEquivalencias.Columns.ColumnByFieldName("Equivalencia por Día").DisplayFormat.FormatString = "N0"

                vwConversionEquivalencias.Columns.ColumnByFieldName("Equivalencia Medio Día").Width = 100
                vwConversionEquivalencias.Columns.ColumnByFieldName("Equivalencia Medio Día").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwConversionEquivalencias.Columns.ColumnByFieldName("Equivalencia Medio Día").DisplayFormat.FormatString = "N0"
                vwConversionEquivalencias.Columns.ColumnByFieldName("Equivalencia Medio Día")

        End Select

    End Sub

    Private Sub vwNecesidadSemanal_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwNecesidadSemanal.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub vwDesgloseProyeccion_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwDesgloseProyeccion.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub vwDistribucionEquivalencias_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwDistribucionEquivalencias.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub vwConversionEquivalencias_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwConversionEquivalencias.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim MasterBalanceoNaves As New DataSet("MasterReportesBalanceo")
        Dim dtNecesidadSemanal1 As New DataTable("dtNecesidadSemanal")
        Dim dtDesgloseProyeccion1 As New DataTable("dtDesgloseProyeccion")
        Dim dtDistribucionEquivalencia1 As New DataTable("dtDistribucionEquiv")
        Dim dtConversionEquivalencia1 As New DataTable("dtConversionEquiv")
        Dim formatoExcel As StiExcelExportSettings = New StiExcelExportSettings()
        Dim Ruta = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\BalanceoNavesReportes"
        Dim objBUReporte As New ReportesBU
        Dim EntidadReporte As New Entidades.Reportes
        Dim NaveNombre As String
        Dim Semana As Integer
        Dim Año As Integer

        Try
            If Not System.IO.Directory.Exists(Ruta) Then
                Directory.CreateDirectory(Ruta)
            End If

            Cursor = Cursors.WaitCursor
            If cmbNave.SelectedIndex <> 0 Then
                NaveNombre = cmbNave.Text
            Else
                NaveNombre = ""
            End If

            Semana = nudSemanaInicio.Value
            Año = nudAño.Value

            dtNecesidadSemanal1 = grdNecesidadSemanal.DataSource
            dtDesgloseProyeccion1 = grdDesgloseProyeccion.DataSource
            dtDistribucionEquivalencia1 = grdDistribucionEquivalencias.DataSource
            dtConversionEquivalencia1 = grdConversionEquivalencias.DataSource

            dtNecesidadSemanal1.TableName = "dtNecesidadSemanal"
            dtDesgloseProyeccion1.TableName = "dtDesgloseProyeccion"
            dtDistribucionEquivalencia1.TableName = "dtDistribucionEquiv"
            dtConversionEquivalencia1.TableName = "dtConversionEquiv"

            MasterBalanceoNaves.Tables.Add(dtNecesidadSemanal1.Copy())
            MasterBalanceoNaves.Tables.Add(dtDesgloseProyeccion1.Copy())
            MasterBalanceoNaves.Tables.Add(dtDistribucionEquivalencia1.Copy())
            MasterBalanceoNaves.Tables.Add(dtConversionEquivalencia1.Copy())

            EntidadReporte = objBUReporte.LeerReporteporClave("RPT_BALANCEONAVESREPORTESTODOS")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                                    EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport()

            reporte.Load(archivo)
            reporte.Compile()
            reporte("Usuario") = "ARODRIGUEZ"
            reporte("Semana") = Semana
            reporte("Nave") = NaveNombre
            reporte("Fecha") = "07/10/2021"
            reporte.Dictionary.Clear()
            reporte.RegData(MasterBalanceoNaves)
            reporte.Dictionary.Synchronize()
            reporte.Render()
            formatoExcel.ExportObjectFormatting = True
            StiOptions.Export.Excel.ShowGridLines = False
            reporte.ExportDocument(StiExportFormat.Excel, Ruta + "\Reporte Balanceo Naves Semana " + Semana.ToString + " Nave " + cmbNave.Text + ".xls")
            'reporte.Show()
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub



End Class