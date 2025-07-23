Imports System.Windows.Forms
Imports Framework.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports Stimulsoft.Report
Imports Tools

Public Class ControlAsistenciaFiscalForm
    Dim tieneChecador As Boolean = True
    Dim errorChecadas As Boolean = False
    Dim colOcultar() As String
    Dim colMover() As String
    Dim retardosPermitidos As Integer = 2
    Dim faltasRetPermitidos As Integer = 2
    Dim faltasPermitidas As Integer = 0
    Dim incapacidadesPermitidas As Integer = 0

    Private Sub ControlAsistenciaFiscalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized

        configuracionPermisosBotones()
        llenarComboEmpresa()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Height = 43
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Height = 114
    End Sub

    Private Sub configuracionPermisosBotones()
        consultaTieneChecador()

        If PermisosUsuarioBU.ConsultarPermiso("FRMCTRL_ASISTENCIAFISCAL", "AGREGARFALTA_CTRLASIS") And tieneChecador = False Then
            pnlAgregarFalta.Visible = True
        Else
            pnlAgregarFalta.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("FRMCTRL_ASISTENCIAFISCAL", "AGREGARRETARDO_CTRLASIS") And tieneChecador = False Then
            pnlAgregarRetardo.Visible = True
        Else
            pnlAgregarRetardo.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("FRMCTRL_ASISTENCIAFISCAL", "IMPRIMIRLISTA_CTRLASIS") Then
            pnlListaAsistencia.Visible = True
        Else
            pnlListaAsistencia.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("FRMCTRL_ASISTENCIAFISCAL", "EXPORTAREXCEL_CTRLASIS") Then
            pnlExportar.Visible = True
        Else
            pnlExportar.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("FRMCTRL_ASISTENCIAFISCAL", "CERRARSEMANA_CTRLASIS") And tieneChecador = False Then
            btnCerrarSemana.Visible = True
            lblCerrarSemana.Visible = True
            pnlRegenerar.Visible = PermisosUsuarioBU.ConsultarPermiso("FRMCTRL_ASISTENCIAFISCAL", "REGENERAR_CTRLASIS")
        Else
            btnCerrarSemana.Visible = False
            lblCerrarSemana.Visible = False
            pnlRegenerar.Visible = False
        End If

    End Sub

    Private Sub consultaTieneChecador()
        Dim objMensajeError As New Tools.ErroresForm
        Try
            If Not cmbEmpresa.DataSource Is Nothing Then
                If cmbEmpresa.SelectedIndex > 0 Or cmbEmpresa.Items.Count = 1 And IsNumeric(cmbEmpresa.SelectedValue.ToString) Then
                    Dim objBU As New Negocios.ControlAsistenciaBU
                    tieneChecador = objBU.consultaTieneChecador(CInt(cmbEmpresa.SelectedValue.ToString))
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al consultar si la empresa tiene checador"
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub llenarComboEmpresa()
        Dim objBU As New Negocios.UtileriasBU
        Dim dtEmpresas As New DataTable

        dtEmpresas = objBU.consultarPatronEmpresa()
        If Not dtEmpresas Is Nothing Then
            If dtEmpresas.Rows.Count > 0 Then
                cmbEmpresa.DataSource = dtEmpresas
                cmbEmpresa.ValueMember = "ID"
                cmbEmpresa.DisplayMember = "PATRON"
            Else
                cmbEmpresa.DataSource = Nothing
            End If
        Else
            cmbEmpresa.DataSource = Nothing
        End If
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        grdAsistencia.DataSource = Nothing
        llenarComboPeriodo()
        configuracionPermisosBotones()
        habilitaSemanaAbierta()
    End Sub

    Private Sub llenarComboPeriodo()
        Dim objMensajeError As New Tools.ErroresForm
        Try
            cmbPeriodo.DataSource = Nothing
            If cmbEmpresa.SelectedIndex > 0 Or cmbEmpresa.Items.Count = 1 And IsNumeric(cmbEmpresa.SelectedValue.ToString) Then
                Dim objBU As New Negocios.ControlAsistenciaBU
                Dim dtListado As New DataTable

                dtListado = objBU.consultarPeriodoNomina(CInt(cmbEmpresa.SelectedValue.ToString))
                If Not dtListado Is Nothing Then
                    If dtListado.Rows.Count > 0 Then
                        cmbPeriodo.DataSource = dtListado
                        cmbPeriodo.ValueMember = "ID"
                        cmbPeriodo.DisplayMember = "DESCRIPCION"
                        cmbPeriodo.SelectedValue = objBU.obtenerPeriodoNominaActual(CInt(cmbEmpresa.SelectedValue.ToString))
                    Else
                        objMensajeError.mensaje = "No hay periodos de nómina para la empresa seleccionada."
                        objMensajeError.ShowDialog()
                    End If
                Else
                    objMensajeError.mensaje = "No hay periodos de nómina para la empresa seleccionada."
                    objMensajeError.ShowDialog()
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al consultar los periodos de nómina"
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click, lblMostrar.Click
        cargarListado()

        If grdAsistencia.Rows.Count = 0 Then
            Dim objMensajeConf As New Tools.ConfirmarForm
            Dim objMensajeAdv As New Tools.AdvertenciaForm
            Dim objBU As New Negocios.ControlAsistenciaBU
            Dim patronId As Integer = cmbEmpresa.SelectedValue
            Dim periodoId As Integer = cmbPeriodo.SelectedValue

            If Not tieneChecador And objBU.validaPeriodoGenerarChecadas(periodoId) And Not errorChecadas Then
                objMensajeConf.mensaje = "No hay registros de checadas para el periodo de nómina seleccionado. ¿Desea generarlos?"
                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim objMensajeError As New Tools.ErroresForm
                    Dim objMensajeExito As New Tools.ExitoForm
                    Try
                        Me.Cursor = Cursors.WaitCursor
                        If objBU.generaRegistrosChecadas(patronId, 0) = "EXITO" Then
                            objMensajeExito.mensaje = "Registros de checadas generados correctamente."
                            objMensajeExito.ShowDialog()
                            cargarListado()
                        Else
                            objMensajeError.mensaje = "No se pudieron generar registros de checadas para el periodo de nómina seleccinado."
                            objMensajeError.ShowDialog()
                        End If
                    Catch ex As Exception
                        objMensajeError.mensaje = "Error al generar registros de checadas para el periodo de nómina seleccinado."
                        objMensajeError.ShowDialog()
                    Finally
                        Me.Cursor = Cursors.Default
                    End Try
                End If
            Else
                If Not errorChecadas Then
                    objMensajeAdv.mensaje = "La consulta no devolvió resultados."
                    objMensajeAdv.ShowDialog()
                End If
            End If
        End If
    End Sub

    Private Sub cargarListado()
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeError As New Tools.ErroresForm
        grdAsistencia.DataSource = Nothing

        Try
            errorChecadas = False
            If validarFiltros() Then
                Dim objBU As New Negocios.ControlAsistenciaBU
                Dim dtListado As New DataTable
                Dim patronId As Integer = cmbEmpresa.SelectedValue
                Dim periodoId As Integer = cmbPeriodo.SelectedValue
                Dim registros As Integer = 0

                obtenerPoliticasPremios(periodoId)
                registros = objBU.validadExistenChecadas(patronId, periodoId)
                If registros > 0 Then
                    dtListado = objBU.consultaChecadasPeriodoNomina(patronId, periodoId)
                    If Not dtListado Is Nothing Then
                        If dtListado.Rows.Count > 0 Then
                            dtListado = ProcesarDataTable(dtListado)
                            grdAsistencia.DataSource = dtListado
                            disenioGrid()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar listado de Control de Asistencia."
            objMensajeError.ShowDialog()
            errorChecadas = True
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub obtenerPoliticasPremios(ByVal periodoId As Integer)
        Dim objMensajeError As New Tools.ErroresForm
        Try
            Dim objBU As New Negocios.ControlAsistenciaBU
            Dim dtResultado As New DataTable

            dtResultado = objBU.obtenerPoliticasPremios(periodoId)
            If Not dtResultado Is Nothing Then
                If dtResultado.Rows.Count > 0 Then
                    retardosPermitidos = CInt(dtResultado.Rows(0)("RetardosPermitidos").ToString)
                    faltasRetPermitidos = CInt(dtResultado.Rows(0)("FaltasRetPermitidos").ToString)
                    faltasPermitidas = CInt(dtResultado.Rows(0)("FaltasPermitidas").ToString)
                    incapacidadesPermitidas = CInt(dtResultado.Rows(0)("IncapacidadesPermitidas").ToString)
                Else
                    objMensajeError.mensaje = "No se obtuvieron políticas de premios."
                    objMensajeError.ShowDialog()
                End If
            Else
                objMensajeError.mensaje = "No se obtuvieron políticas de premios."
                objMensajeError.ShowDialog()
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al políticas de premios."
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Function validarFiltros() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbEmpresa.Items.Count > 1 And cmbEmpresa.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar una Empresa."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        End If

        'If cmbPeriodo.Items.Count > 1 And cmbPeriodo.SelectedIndex = 0 Then
        '    objMensajeAdv.mensaje = "Favor de seleccionar un Periodo de Nómina."
        '    objMensajeAdv.ShowDialog()
        '    Return False
        '    Exit Function
        'End If

        Return True
    End Function

    Public Function ProcesarDataTable(ByVal dtRegistros As DataTable) As DataTable
        Dim objBU As New Negocios.ControlAsistenciaBU
        Dim numFila As Integer = 1
        Dim colInicio As Integer = 0
        Dim colFinal As Integer = 0
        Dim cont As Integer = 0

        colInicio = dtRegistros.Columns.IndexOf("idIncapacidad") + 1
        colFinal = dtRegistros.Columns.IndexOf("rtColaboradorId") - 1
        ReDim colMover(colFinal - colInicio)
        For i As Integer = colInicio To colFinal
            dtRegistros.Columns(i).ColumnName = WeekdayName(Weekday(dtRegistros.Columns(i).ColumnName.ToString).ToString).ToUpper & vbCrLf & CDate(dtRegistros.Columns(i).ColumnName.ToString).ToString("dd/MM/yyyy")
            colMover(cont) = dtRegistros.Columns(i).ColumnName
            cont += 1
        Next

        colInicio = dtRegistros.Columns.IndexOf("rtTipocheck") + 1
        colFinal = dtRegistros.Columns.IndexOf("IDColaboradorId") - 1
        ReDim colOcultar(colFinal - colInicio)
        cont = 0

        Dim retardos(colFinal - colInicio) As Double
        Dim faltas(colFinal - colInicio) As Double
        Dim incapacidades(colFinal - colInicio) As Double
        Dim checaBloque(colFinal - colInicio) As Integer
        Dim periodoId As Integer = cmbPeriodo.SelectedValue
        Dim patronId As Integer = cmbEmpresa.SelectedValue
        Dim dtDiasVacaciones As DataTable

        dtDiasVacaciones = objBU.consultaFechasVacaciones(patronId, periodoId)

        For i As Integer = 0 To dtRegistros.Rows.Count - 1
            Dim sumRetardos As Double = 0
            Dim sumFaltas As Double = 0
            Dim sumFaltasRet As Double = 0
            Dim sumIncapacidades As Double = 0

            If (i + 1) Mod 2 <> 0 Then
                ReDim retardos(colFinal - colInicio)
                ReDim faltas(colFinal - colInicio)
                ReDim incapacidades(colFinal - colInicio)
                ReDim checaBloque(colFinal - colInicio)
            End If

            If Not dtDiasVacaciones Is Nothing AndAlso dtDiasVacaciones.Rows.Count > 0 Then
                If Not IsDBNull(dtDiasVacaciones.Rows(0)("FechaInicio")) AndAlso Not IsDBNull(dtDiasVacaciones.Rows(0)("FechaFin")) Then
                    Dim fechaInicio As Date = CDate(dtDiasVacaciones.Rows(0)("FechaInicio").ToString)
                    Dim fechaFin As Date = CDate(dtDiasVacaciones.Rows(0)("FechaFin").ToString)
                    For j As Integer = colInicio To colFinal
                        Dim encFecha As Date = CDate(dtRegistros.Columns(j).ColumnName.ToString.Substring(0, Len(dtRegistros.Columns(j).ColumnName.ToString) - 1))
                        If CInt(encFecha.ToString("yyyyMMdd")) >= CInt(fechaInicio.ToString("yyyyMMdd")) And CInt(encFecha.ToString("yyyyMMdd")) <= CInt(fechaFin.ToString("yyyyMMdd")) And CBool(dtRegistros.Rows(i)("" & Weekday(encFecha, FirstDayOfWeek.Monday).ToString)) Then
                            If IsDBNull(dtRegistros.Rows(i)(j)) OrElse dtRegistros.Rows(i)(j) = "" Then
                                dtRegistros.Rows(i)(j) = "VAC"
                            End If
                        End If
                    Next
                End If
            End If

            If CInt(dtRegistros.Rows(i)("idIncapacidad").ToString) <> 0 Then
                Dim dtIncapacidad As New DataTable
                'dtIncapacidad = objBU.consultaIncapacidadColaborador(CInt(dtRegistros.Rows(i)("idIncapacidad").ToString))
                dtIncapacidad = objBU.consultaIncapacidadColaborador(CInt(dtRegistros.Rows(i)("codr_colaboradorid").ToString), periodoId)
                If Not dtIncapacidad Is Nothing AndAlso dtIncapacidad.Rows.Count > 0 Then
                    Dim fechaInicio As Date = CDate(dtIncapacidad.Rows(0)("FechaInicio").ToString)
                    Dim fechaFin As Date = CDate(dtIncapacidad.Rows(0)("FechaFin").ToString)
                    For j As Integer = colInicio To colFinal
                        Dim encFecha As Date = CDate(dtRegistros.Columns(j).ColumnName.ToString.Substring(0, Len(dtRegistros.Columns(j).ColumnName.ToString) - 1))
                        If CInt(encFecha.ToString("yyyyMMdd")) >= CInt(fechaInicio.ToString("yyyyMMdd")) And CInt(encFecha.ToString("yyyyMMdd")) <= CInt(fechaFin.ToString("yyyyMMdd")) And CBool(dtRegistros.Rows(i)("" & Weekday(encFecha, FirstDayOfWeek.Monday).ToString)) Then
                            dtRegistros.Rows(i)(j) = "I"
                        End If
                    Next
                End If
            End If

            If CInt(dtRegistros.Rows(i)("baim_bajaimssid").ToString) <> 0 Then
                Dim fechaBaja As Date = CDate(dtRegistros.Rows(i)("baim_fechabajaimss").ToString)
                For j As Integer = colInicio To colFinal
                    Dim encFecha As Date = CDate(dtRegistros.Columns(j).ColumnName.ToString.Substring(0, Len(dtRegistros.Columns(j).ColumnName.ToString) - 1))
                    If CInt(encFecha.ToString("yyyyMMdd")) >= CInt(fechaBaja.ToString("yyyyMMdd")) Then
                        dtRegistros.Rows(i)(j) = "BI"
                    End If
                Next
            End If

            Dim index As Integer = 0
            For j As Integer = colInicio To colFinal
                If CBool(dtRegistros.Rows(i)("" & Weekday(dtRegistros.Columns(j).ColumnName.ToString.Substring(0, Len(dtRegistros.Columns(j).ColumnName.ToString) - 1), FirstDayOfWeek.Monday).ToString)) Then
                    checaBloque(index) += 1
                Else
                    checaBloque(index) += 0
                End If


                If dtRegistros.Rows(i)(j).ToString = "R" Then
                    retardos(index) += 1
                End If

                Dim valor As Integer = 0
                If Not dtRegistros.Rows(i)(dtRegistros.Columns(j).ColumnName.ToString.Substring(0, dtRegistros.Columns(j).ColumnName.ToString.Length - 1) & "2") Is DBNull.Value Then
                    valor = dtRegistros.Rows(i)(dtRegistros.Columns(j).ColumnName.ToString.Substring(0, dtRegistros.Columns(j).ColumnName.ToString.Length - 1) & "2")
                ElseIf Not dtRegistros.Rows(i)(j) Is DBNull.Value Then
                    If dtRegistros.Rows(i)(j) = "I" And CBool(dtRegistros.Rows(i)("" & Weekday(dtRegistros.Columns(j).ColumnName.ToString.Substring(0, Len(dtRegistros.Columns(j).ColumnName.ToString) - 1), FirstDayOfWeek.Monday).ToString)) Then
                        valor = 1
                    ElseIf dtRegistros.Rows(i)(j) = "BI" And CBool(dtRegistros.Rows(i)("" & Weekday(dtRegistros.Columns(j).ColumnName.ToString.Substring(0, Len(dtRegistros.Columns(j).ColumnName.ToString) - 1), FirstDayOfWeek.Monday).ToString)) Then
                        valor = 1
                    ElseIf dtRegistros.Rows(i)(j) = "VAC" And CBool(dtRegistros.Rows(i)("" & Weekday(dtRegistros.Columns(j).ColumnName.ToString.Substring(0, Len(dtRegistros.Columns(j).ColumnName.ToString) - 1), FirstDayOfWeek.Monday).ToString)) Then
                        valor = 1
                    End If
                End If

                If valor = 0 And CBool(dtRegistros.Rows(i)("" & Weekday(dtRegistros.Columns(j).ColumnName.ToString.Substring(0, Len(dtRegistros.Columns(j).ColumnName.ToString) - 1), FirstDayOfWeek.Monday).ToString)) Then
                    faltas(index) += 1
                End If

                If Not dtRegistros.Rows(i)(j) Is DBNull.Value Then
                    If dtRegistros.Rows(i)(j) = "I" And CBool(dtRegistros.Rows(i)("" & Weekday(dtRegistros.Columns(j).ColumnName.ToString.Substring(0, Len(dtRegistros.Columns(j).ColumnName.ToString) - 1), FirstDayOfWeek.Monday).ToString)) Then
                        incapacidades(index) += 1
                    End If
                End If
                index += 1
            Next

            For j As Integer = 0 To (colFinal - colInicio)
                If checaBloque(j) > 0 Then
                    'sumRetardos += retardos(j) / checaBloque(j)
                    sumRetardos += retardos(j)
                    sumFaltas += faltas(j) / checaBloque(j)
                    sumFaltasRet += faltas(j)
                    sumIncapacidades += incapacidades(j) / checaBloque(j)
                Else
                    sumRetardos += retardos(j)
                    sumFaltas += faltas(j)
                    sumFaltasRet += faltas(j)
                    sumIncapacidades += incapacidades(j)
                End If
            Next
            sumIncapacidades = dtRegistros.Rows(i)("Incapacidades")


            If (i + 1) Mod 2 <> 0 Then
                dtRegistros.Rows(i)("R") = sumRetardos
                dtRegistros.Rows(i)("INA") = sumFaltas
                dtRegistros.Rows(i)("INC") = sumIncapacidades

                'If dtRegistros.Rows(i)("R") < retardosPermitidos And dtRegistros.Rows(i)("INA") < faltasRetPermitidos And dtRegistros.Rows(i)("INC") < faltasRetPermitidos Then
                If (dtRegistros.Rows(i)("R") + sumFaltasRet) < retardosPermitidos And sumFaltasRet < faltasRetPermitidos And dtRegistros.Rows(i)("INC") < faltasRetPermitidos Then
                    dtRegistros.Rows(i)("Puntualidad") = True
                Else
                    dtRegistros.Rows(i)("Puntualidad") = False
                End If

                If sumFaltas <= faltasPermitidas And sumIncapacidades <= incapacidadesPermitidas Then
                    dtRegistros.Rows(i)("Asistencia") = True
                Else
                    dtRegistros.Rows(i)("Asistencia") = False
                End If

                ''SI ES BAJA NO GANA PUNTUALIDAD Y ASISTENCIA               
                If CInt(dtRegistros.Rows(i)("baim_bajaimssid").ToString) <> 0 Then
                    dtRegistros.Rows(i)("Asistencia") = False
                    dtRegistros.Rows(i)("Puntualidad") = False
                End If

            Else
                'dtRegistros.Rows(i)("R") = sumRetardos
                'dtRegistros.Rows(i)("INA") = sumFaltas
                'dtRegistros.Rows(i)("INC") = sumIncapacidades

                dtRegistros.Rows(i - 1)("R") = sumRetardos
                dtRegistros.Rows(i - 1)("INA") = sumFaltas
                dtRegistros.Rows(i - 1)("INC") = sumIncapacidades

                'If dtRegistros.Rows(i - 1)("R") < retardosPermitidos And dtRegistros.Rows(i - 1)("INA") < faltasRetPermitidos And dtRegistros.Rows(i - 1)("INC") < faltasRetPermitidos Then
                If (dtRegistros.Rows(i - 1)("R") + sumFaltasRet) < retardosPermitidos And sumFaltasRet < faltasRetPermitidos And dtRegistros.Rows(i - 1)("INC") < faltasRetPermitidos Then
                    dtRegistros.Rows(i)("Puntualidad") = True
                    dtRegistros.Rows(i - 1)("Puntualidad") = True
                Else
                    dtRegistros.Rows(i)("Puntualidad") = False
                    dtRegistros.Rows(i - 1)("Puntualidad") = False
                End If

                If sumFaltas <= faltasPermitidas And sumIncapacidades <= incapacidadesPermitidas Then
                    dtRegistros.Rows(i)("Asistencia") = True
                    dtRegistros.Rows(i - 1)("Asistencia") = True
                Else
                    dtRegistros.Rows(i)("Asistencia") = False
                    dtRegistros.Rows(i - 1)("Asistencia") = False
                End If

                If CInt(dtRegistros.Rows(i - 1)("baim_bajaimssid").ToString) <> 0 Then
                    dtRegistros.Rows(i)("Asistencia") = False
                    dtRegistros.Rows(i - 1)("Asistencia") = False
                    dtRegistros.Rows(i)("Puntualidad") = False
                    dtRegistros.Rows(i - 1)("Puntualidad") = False
                End If

            End If
        Next

        For i As Integer = colInicio To colFinal
            dtRegistros.Columns(i).ColumnName = WeekdayName(Weekday(dtRegistros.Columns(i).ColumnName.ToString.Substring(0, Len(dtRegistros.Columns(i).ColumnName.ToString) - 1)).ToString).ToUpper & CDate(dtRegistros.Columns(i).ColumnName.ToString.Substring(0, Len(dtRegistros.Columns(i).ColumnName.ToString) - 1)).ToString("dd/MM/yyyy") & "RT"
            colOcultar(cont) = dtRegistros.Columns(i).ColumnName
            cont += 1
        Next

        colInicio = dtRegistros.Columns.IndexOf("IDTipocheck") + 1
        colFinal = dtRegistros.Columns.IndexOf("ChkColaboradorId") - 1
        ReDim Preserve colOcultar(colOcultar.Length + (colFinal - colInicio))
        For i As Integer = colInicio To colFinal
            dtRegistros.Columns(i).ColumnName = WeekdayName(Weekday(dtRegistros.Columns(i).ColumnName.ToString.Substring(0, Len(dtRegistros.Columns(i).ColumnName.ToString) - 1)).ToString).ToUpper & CDate(dtRegistros.Columns(i).ColumnName.ToString.Substring(0, Len(dtRegistros.Columns(i).ColumnName.ToString) - 1)).ToString("dd/MM/yyyy") & "ID"
            colOcultar(cont) = dtRegistros.Columns(i).ColumnName
            cont += 1
        Next

        Dim col As DataColumn = dtRegistros.Columns.Add("#", System.Type.GetType("System.String"))
        col.SetOrdinal(0)

        For Each rowDt As DataRow In dtRegistros.Rows
            Dim filaNueva As DataRow = dtRegistros.NewRow
            rowDt.Item("#") = numFila

            If (dtRegistros.Rows.IndexOf(rowDt) Mod 2 <> 0) Then
                numFila += 1
            End If
        Next

        Return dtRegistros
    End Function

    Private Sub disenioGrid()
        With grdAsistencia.DisplayLayout.Bands(0)
            .Columns("codr_colaboradorid").Hidden = True
            .Columns("dh_check").Hidden = True
            '.Columns("ChecaBloque").Hidden = True
            .Columns("Puntualidad").Hidden = True
            .Columns("Asistencia").Hidden = True
            .Columns("idIncapacidad").Hidden = True
            .Columns("rtColaboradorId").Hidden = True
            .Columns("rtTipocheck").Hidden = True
            .Columns("IDColaboradorId").Hidden = True
            .Columns("IDTipocheck").Hidden = True
            .Columns("ChkColaboradorId").Hidden = True
            .Columns("ChkTipocheck").Hidden = True
            .Columns("INCColaboradorId").Hidden = True
            .Columns("Incapacidades").Hidden = True
            .Columns("1").Hidden = True
            .Columns("2").Hidden = True
            .Columns("3").Hidden = True
            .Columns("4").Hidden = True
            .Columns("5").Hidden = True
            .Columns("6").Hidden = True
            .Columns("7").Hidden = True
            .Columns("BIColaboradorId").Hidden = True
            .Columns("baim_bajaimssid").Hidden = True
            .Columns("baim_fechabajaimss").Hidden = True

            For i As Integer = 0 To colOcultar.Length - 1
                .Columns(colOcultar(i)).Hidden = True
            Next

            For i As Integer = 0 To colMover.Length - 1
                .Columns(colMover(i)).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns(colMover(i)).AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
                .Columns(colMover(i)).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
            Next

            Dim posicion As Integer = .Columns.IndexOf(colMover(colMover.Length - 1)) + 1
            .Columns("INA").Header.VisiblePosition = posicion
            .Columns("R").Header.VisiblePosition = posicion + 1
            .Columns("INC").Header.VisiblePosition = posicion + 2
            .Columns("F").Header.VisiblePosition = posicion + 3
            .Columns("P").Header.VisiblePosition = posicion + 4
            .Columns("A").Header.VisiblePosition = posicion + 5

            For Each col As UltraGridColumn In .Columns
                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Next

            .Columns("Colaborador").MergedCellStyle = MergedCellContentArea.VisibleRect
            .Columns("Colaborador").MergedCellStyle = MergedCellStyle.Always
            .Columns("Colaborador").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameText
            .Columns("#").MergedCellStyle = MergedCellStyle.Always
            .Columns("#").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameText

            .Columns("INA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("R").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("INC").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("F").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("INA").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("R").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("INC").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("F").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("P").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("A").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("INA").Format = "###,###,##0.0"
            .Columns("R").Format = "###,###,##0.0"
            .Columns("INC").Format = "###,###,##0.0"
            .Columns("F").Format = "###,###,##0"

            .Columns("#").Width = 30
            .Columns("Bloque").Width = 100
            .Columns("Colaborador").Width = 300
            .Columns("INA").Width = 30
            .Columns("R").Width = 30
            .Columns("INC").Width = 30
            .Columns("F").Width = 30
            .Columns("P").Width = 30
            .Columns("A").Width = 30


            .Columns("F").Nullable = Nullable.Null
            .Columns("F").NullText = String.Empty

            .ColHeaderLines = 2
        End With

        grdAsistencia.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdAsistencia.DisplayLayout.Override.DefaultRowHeight = 21
        grdAsistencia.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        grdAsistencia.DisplayLayout.Appearance.BorderColor = Color.SteelBlue
        disenioFilaGrid()
    End Sub

    Private Sub disenioFilaGrid()
        For Each row As UltraGridRow In grdAsistencia.Rows
            If row.Cells("Puntualidad").Value And row.Index Mod 2 = 0 Then
                row.Cells("P").Appearance.BackColor = Color.DarkGreen
            ElseIf row.Cells("Puntualidad").Value = False And row.Index Mod 2 = 0 Then
                row.Cells("P").Appearance.BackColor = Color.DarkRed
            End If

            If row.Cells("Asistencia").Value And row.Index Mod 2 = 0 Then
                row.Cells("A").Appearance.BackColor = Color.DarkGreen
            ElseIf row.Cells("Asistencia").Value = False And row.Index Mod 2 = 0 Then
                row.Cells("A").Appearance.BackColor = Color.DarkRed
            End If

            If row.Index Mod 2 <> 0 Then
                row.Cells("INA").Appearance.ForeColor = Color.Transparent
                row.Cells("R").Appearance.ForeColor = Color.Transparent
                row.Cells("INC").Appearance.ForeColor = Color.Transparent
                row.Cells("F").Value = DBNull.Value

                'row.Cells("F").Appearance.ForeColor = Color.Transparent
            End If

            If CInt(row.Cells("#").Value.ToString) Mod 2 <> 0 Then
                row.Appearance.BackColor = Color.Thistle
            End If


            For i As Integer = 0 To colMover.Length - 1
                Dim pos As Integer = InStr(1, colMover(i), Chr(13).ToString)
                Dim nombreCol As String = colMover(i).Substring(0, pos - 1)
                Dim diaCol As Date = colMover(i).Substring(colMover(i).Length - 10, 10)

                If row.Cells(colMover(i)).Value.ToString = "" Then
                    If CBool(row.Cells(Weekday(diaCol, FirstDayOfWeek.Monday).ToString).Value) Then
                        row.Cells(colMover(i)).Value = "NO REGISTRO"
                        row.Cells(colMover(i)).Appearance.ForeColor = Color.DarkRed
                    End If
                End If

                nombreCol = colMover(i).Replace(vbCrLf, "") & "RT"

                If row.Cells(nombreCol).Value.ToString = "R" Then
                    row.Cells(colMover(i)).Appearance.ForeColor = Color.DarkOrange
                ElseIf row.Cells(nombreCol).Value.ToString = "I" Then
                    If row.Cells(Weekday(nombreCol.Substring(0, Len(nombreCol) - 2), FirstDayOfWeek.Monday).ToString).Value.ToString = "1" Then
                        row.Cells(colMover(i)).Value = "INCAPACIDAD"
                        row.Cells(colMover(i)).Appearance.ForeColor = Color.Blue
                    Else
                        row.Cells(colMover(i)).Value = ""
                    End If
                ElseIf row.Cells(nombreCol).Value.ToString = "F" Then
                    If row.Cells(Weekday(nombreCol.Substring(0, Len(nombreCol) - 2), FirstDayOfWeek.Monday).ToString).Value.ToString = "1" Then
                        row.Cells(colMover(i)).Value = "DÍA FESTIVO"
                        row.Cells(colMover(i)).Appearance.ForeColor = Color.Purple
                    Else
                        row.Cells(colMover(i)).Value = ""
                    End If
                ElseIf row.Cells(nombreCol).Value.ToString = "BI" Then
                    If row.Cells(Weekday(nombreCol.Substring(0, Len(nombreCol) - 2), FirstDayOfWeek.Monday).ToString).Value.ToString = "1" Then
                        row.Cells(colMover(i)).Value = "BAJA"
                        row.Cells(colMover(i)).Appearance.ForeColor = Color.DarkRed
                    Else
                        row.Cells(colMover(i)).Value = ""
                    End If
                ElseIf row.Cells(nombreCol).Value.ToString = "VAC" Then
                    If row.Cells(Weekday(nombreCol.Substring(0, Len(nombreCol) - 2), FirstDayOfWeek.Monday).ToString).Value.ToString = "1" Then
                        row.Cells(colMover(i)).Value = "VACACIONES"
                        row.Cells(colMover(i)).Appearance.ForeColor = Color.DarkRed
                    Else
                        row.Cells(colMover(i)).Value = ""
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click, lblLimpiar.Click
        limpiarFiltros()
    End Sub

    Private Sub limpiarFiltros()
        cmbEmpresa.SelectedIndex = 0
        grdAsistencia.DataSource = Nothing
    End Sub

    Private Sub btnAgregarFalta_Click(sender As Object, e As EventArgs) Handles btnAgregarFalta.Click, lblAgregarFalta.Click
        With grdAsistencia
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        agregarFalta()
    End Sub

    Private Sub agregarFalta()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeConf As New Tools.ConfirmarForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim celdaActiva As UltraGridCell = grdAsistencia.ActiveCell
        Dim columna As String = celdaActiva.Column.Header.Caption
        Dim caracter As Integer = InStr(1, columna, Chr(13).ToString)

        If caracter <> 0 Then
            If Not IsDBNull(celdaActiva.Value) Then
                If celdaActiva.Value <> "NO REGISTRO" And celdaActiva.Value <> "INCAPACIDAD" And celdaActiva.Value <> "" Then
                    objMensajeConf.mensaje = "¿Esta seguro de agregar una falta al registro seleccionado? Esta acción no se podrá revertir."
                    If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Try
                            Dim objBU As New Negocios.ControlAsistenciaBU
                            Dim resultado As String = String.Empty
                            Dim colNombre As String = String.Empty
                            Dim registroId As Integer = 0
                            Dim colaboradorId As Integer = 0

                            colNombre = columna.Replace(vbCrLf, "") & "ID"
                            If IsNumeric(grdAsistencia.Rows(celdaActiva.Row.Index).Cells(colNombre).Value) Then
                                registroId = CInt(grdAsistencia.Rows(celdaActiva.Row.Index).Cells(colNombre).Value)
                                colaboradorId = CInt(grdAsistencia.Rows(celdaActiva.Row.Index).Cells("codr_colaboradorid").Value)
                                resultado = objBU.generaFaltaRegistro(registroId, colaboradorId)
                                If resultado = "EXITO" Then
                                    objMensajeExito.mensaje = "La falta se ha agregado correctamente, los registros se actualizarán."
                                    objMensajeExito.ShowDialog()
                                    cargarListado()
                                Else
                                    objMensajeError.mensaje = "No se pudo agregar la falta al registro seleccionado."
                                    objMensajeError.ShowDialog()
                                End If
                            Else
                                objMensajeError.mensaje = "El ID del registro no es numérico."
                                objMensajeError.ShowDialog()
                            End If
                        Catch ex As Exception
                            objMensajeError.mensaje = "Error al agregar falta."
                            objMensajeError.ShowDialog()
                        End Try
                    End If
                Else
                    objMensajeAdv.mensaje = "No se puede agregar falta a la celda seleccionada."
                    objMensajeAdv.ShowDialog()
                End If
            Else
                objMensajeAdv.mensaje = "No se puede agregar falta a la celda seleccionada."
                objMensajeAdv.ShowDialog()
            End If
        Else
            objMensajeAdv.mensaje = "No se puede agregar falta a la celda seleccionada."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Sub btnAgregarRetardo_Click(sender As Object, e As EventArgs) Handles btnAgregarRetardo.Click, lblAgregarRetardo.Click
        With grdAsistencia
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        agregarRetardo()
    End Sub

    Private Sub agregarRetardo()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeConf As New Tools.ConfirmarForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim celdaActiva As UltraGridCell = grdAsistencia.ActiveCell
        Dim columna As String = celdaActiva.Column.Header.Caption
        Dim caracter As Integer = InStr(1, columna, Chr(13).ToString)

        If caracter <> 0 Then
            If Not IsDBNull(celdaActiva.Value) Then
                If celdaActiva.Value <> "NO REGISTRO" And celdaActiva.Value <> "INCAPACIDAD" And celdaActiva.Value <> "" And celdaActiva.Appearance.ForeColor <> Color.DarkOrange Then
                    objMensajeConf.mensaje = "¿Esta seguro de agregar un retardo al registro seleccionado? Esta acción no se podrá revertir."
                    If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Try
                            Dim objBU As New Negocios.ControlAsistenciaBU
                            Dim resultado As String = String.Empty
                            Dim colNombre As String = String.Empty
                            Dim registroId As Integer = 0
                            Dim colaboradorId As Integer = 0

                            colNombre = columna.Replace(vbCrLf, "") & "ID"
                            If IsNumeric(grdAsistencia.Rows(celdaActiva.Row.Index).Cells(colNombre).Value) Then
                                registroId = CInt(grdAsistencia.Rows(celdaActiva.Row.Index).Cells(colNombre).Value)
                                colaboradorId = CInt(grdAsistencia.Rows(celdaActiva.Row.Index).Cells("codr_colaboradorid").Value)
                                resultado = objBU.generaRetardoRegistro(registroId, colaboradorId)
                                If resultado = "EXITO" Then
                                    objMensajeExito.mensaje = "El retardo se ha agregado correctamente, los registros se actualizarán."
                                    objMensajeExito.ShowDialog()
                                    cargarListado()
                                Else
                                    objMensajeError.mensaje = "No se pudo agregar la retardo al registro seleccionado."
                                    objMensajeError.ShowDialog()
                                End If
                            Else
                                objMensajeError.mensaje = "El ID del registro no es numérico."
                                objMensajeError.ShowDialog()
                            End If
                        Catch ex As Exception
                            objMensajeError.mensaje = "Error al agregar retardo."
                            objMensajeError.ShowDialog()
                        End Try
                    End If
                Else
                    objMensajeAdv.mensaje = "No se puede agregar retardo a la celda seleccionada."
                    objMensajeAdv.ShowDialog()
                End If
            Else
                objMensajeAdv.mensaje = "No se puede agregar retardo a la celda seleccionada."
                objMensajeAdv.ShowDialog()
            End If
        Else
            objMensajeAdv.mensaje = "No se puede agregar retardo a la celda seleccionada."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Sub btnListaAsistencia_Click(sender As Object, e As EventArgs) Handles btnListaAsistencia.Click, lblListaAsistencia.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm

        If grdAsistencia.Rows.Count > 0 Then
            Try
                Dim objReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                Dim reporte As New StiReport
                If colMover.Length <= 6 Then
                    EntidadReporte = objReporte.LeerReporteporClave("REPORTE_CTRLASISTENCIA_FISCAL")
                Else
                    EntidadReporte = objReporte.LeerReporteporClave("REPORTE_CTRLASISTENCIA_FISCALCE")
                End If
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & EntidadReporte.Pnombre.Trim & ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                reporte.Load(archivo)
                reporte.Compile()

                Dim dtListado = New DataTable("dtChecadas")
                'dtListado = grdAsistencia.DataSource
                With dtListado
                    .Columns.Add("Num")
                    .Columns.Add("Colaborador")
                    .Columns.Add("Bloque1")
                    .Columns.Add("ValorDiaE1")
                    .Columns.Add("ValorDiaE2")
                    .Columns.Add("ValorDiaE3")
                    .Columns.Add("ValorDiaE4")
                    .Columns.Add("ValorDiaE5")
                    .Columns.Add("ValorDiaE6")
                    .Columns.Add("ValorDiaE7")
                    .Columns.Add("ValorDiaE8")
                    .Columns.Add("ValorDiaE9")
                    .Columns.Add("ValorDiaE10")
                    .Columns.Add("ValorDiaE11")
                    .Columns.Add("ValorDiaE12")
                    .Columns.Add("Inasistencias")
                    .Columns.Add("Retardos")
                    .Columns.Add("Incapacidades")
                    .Columns.Add("Puntualidad")
                    .Columns.Add("Asistencia")
                    .Columns.Add("ValorDiaR1")
                    .Columns.Add("ValorDiaR2")
                    .Columns.Add("ValorDiaR3")
                    .Columns.Add("ValorDiaR4")
                    .Columns.Add("ValorDiaR5")
                    .Columns.Add("ValorDiaR6")
                    .Columns.Add("ValorDiaR7")
                    .Columns.Add("ValorDiaR8")
                    .Columns.Add("ValorDiaR9")
                    .Columns.Add("ValorDiaR10")
                    .Columns.Add("ValorDiaR11")
                    .Columns.Add("ValorDiaR12")
                    .Columns.Add("Bloque2")
                End With

                Dim dtRow As DataRow = Nothing
                For Each item As UltraGridRow In grdAsistencia.Rows
                    If item.Index Mod 2 = 0 Then
                        dtRow = dtListado.NewRow

                        dtRow.Item("Num") = item.Cells("#").Value.ToString()
                        dtRow.Item("Colaborador") = item.Cells("Colaborador").Value.ToString()
                        dtRow.Item("Bloque1") = item.Cells("Bloque").Value.ToString()
                        dtRow.Item("Inasistencias") = item.Cells("INA").Value.ToString()
                        dtRow.Item("Retardos") = item.Cells("R").Value.ToString()
                        dtRow.Item("Incapacidades") = item.Cells("INC").Value.ToString()
                        dtRow.Item("Puntualidad") = item.Cells("Puntualidad").Value.ToString()
                        dtRow.Item("Asistencia") = item.Cells("Asistencia").Value.ToString()

                        If colMover.Length <= 12 Then
                            For i As Integer = 0 To colMover.Length - 1
                                dtRow.Item("ValorDiaE" & (i + 1)) = item.Cells(colMover(i)).Value.ToString()
                            Next
                        Else
                            For i As Integer = 0 To 12
                                dtRow.Item("ValorDiaE" & (i + 1)) = item.Cells(colMover(i)).Value.ToString()
                            Next
                        End If
                    Else
                        dtRow.Item("Bloque2") = item.Cells("Bloque").Value.ToString()
                        If colMover.Length <= 12 Then
                            For i As Integer = 0 To colMover.Length - 1
                                dtRow.Item("ValorDiaR" & (i + 1)) = item.Cells(colMover(i)).Value.ToString()
                            Next
                        Else
                            For i As Integer = 0 To 12
                                dtRow.Item("ValorDiaR" & (i + 1)) = item.Cells(colMover(i)).Value.ToString()
                            Next
                        End If

                        dtListado.Rows.Add(dtRow)
                    End If
                Next

                For i As Integer = 0 To colMover.Length - 1
                    reporte("Dia" & (i + 1)) = colMover(i).ToString
                Next

                reporte("Empresa") = cmbEmpresa.Text.Trim
                reporte("Periodo") = cmbPeriodo.Text.Trim
                reporte("Reporte") = EntidadReporte.Pnombre.Trim & ".mrt"
                reporte("UserName") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

                reporte.RegData(dtListado)
                reporte.Show()
                'reporte.Render()
            Catch ex As Exception
                objMensajeError.mensaje = "Error al imprimir."
                objMensajeError.ShowDialog()
            End Try
        Else
            objMensajeAdv.mensaje = "No hay información para imprimir."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm

        If grdAsistencia.Rows.Count > 0 Then
            Try
                Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
                Dim fbdUbicacionArchivo As New FolderBrowserDialog
                Dim archivo As String = String.Empty

                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    If ret = Windows.Forms.DialogResult.OK Then
                        Dim fecha_hora As String = Date.Now.ToString("yyyyMMdd_Hmmss")
                        archivo = "Reporte_ControlAsistenciaFiscal" & fecha_hora & ".xlsx"
                        gridExcelExporter.Export(Me.grdAsistencia, .SelectedPath & "\" & archivo)
                    End If
                    objMensajeExito.mensaje = "Los datos se exportaron correctamente al archivo " & archivo
                    objMensajeExito.ShowDialog()
                    .Dispose()
                End With
            Catch ex As Exception
                objMensajeError.mensaje = "Error al exportar."
                objMensajeError.ShowDialog()
            End Try
        Else
            objMensajeAdv.mensaje = "No hay información para exportar."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Sub cmbPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPeriodo.SelectedIndexChanged
        grdAsistencia.DataSource = Nothing
        habilitaSemanaAbierta()
    End Sub

    Private Sub habilitaSemanaAbierta()
        Try
            Dim objMensajeConf As New Tools.ConfirmarForm
            Dim objMensajeAdv As New Tools.AdvertenciaForm
            Dim objBU As New Negocios.ControlAsistenciaBU
            Dim patronId As Integer = cmbEmpresa.SelectedValue
            Dim periodoId As Integer = cmbPeriodo.SelectedValue

            If Not tieneChecador And objBU.validaPeriodoGenerarChecadas(periodoId) Then
                pnlAgregarFalta.Enabled = True
                pnlAgregarRetardo.Enabled = True
                btnCerrarSemana.Enabled = True
                lblCerrarSemana.Enabled = True
                pnlRegenerar.Enabled = True
            Else
                pnlAgregarFalta.Enabled = False
                pnlAgregarRetardo.Enabled = False
                btnCerrarSemana.Enabled = False
                lblCerrarSemana.Enabled = False
                pnlRegenerar.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCerrarSemana_Click(sender As Object, e As EventArgs) Handles btnCerrarSemana.Click, lblCerrarSemana.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeError As New Tools.ErroresForm

        Try
            If validarCierreSemana() Then
                Dim objMensajeConf As New Tools.ConfirmarForm
                Dim objMensajeExito As New Tools.ExitoForm
                Dim objBU As New Negocios.ControlAsistenciaBU
                Dim periodoId As Integer = cmbPeriodo.SelectedValue

                objMensajeConf.mensaje = "¿Esta seguro de cerrar la semana de asistencia? Esta acción no se podrá revertir."
                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    If objBU.generaCorteChecadorFiscal(periodoId) = "EXITO" Then
                        btnCerrarSemana.Enabled = False
                        pnlRegenerar.Enabled = False
                        lblCerrarSemana.Enabled = False
                        objMensajeExito.mensaje = "Cierre de asistencia se generó correctamente."
                        objMensajeExito.ShowDialog()
                    Else
                        objMensajeError.mensaje = "No se pudo realizar el cierre de asistencia."
                        objMensajeError.ShowDialog()
                    End If
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cerrar asistencia."
            objMensajeError.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Function validarCierreSemana() As Boolean
        Dim valido = False
        Try
            Dim objMensajeAdv As New Tools.AdvertenciaFormGrande
            Dim objBU As New Negocios.ControlAsistenciaBU
            Dim resultado As String = String.Empty
            Dim periodoId As Integer = cmbPeriodo.SelectedValue

            If grdAsistencia.Rows.Count = 0 Then
                objMensajeAdv.mensaje = "No hay información para realizar el cierre de asistencia"
                objMensajeAdv.ShowDialog()
            Else
                resultado = objBU.validaCierreChecador(periodoId)
                If resultado <> "Correcto" Then
                    objMensajeAdv.mensaje = resultado
                    objMensajeAdv.ShowDialog()
                Else
                    valido = True
                End If
            End If
        Catch ex As Exception

        End Try
        Return valido
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub bntRegenerar_Click(sender As Object, e As EventArgs) Handles bntRegenerar.Click
        Dim objMensajeConf As New Tools.ConfirmarForm
        Dim objBU As New Negocios.ControlAsistenciaBU
        Dim patronId As Integer = cmbEmpresa.SelectedValue

        If Not tieneChecador Then
            objMensajeConf.mensaje = "Este proceso generará nuevos registros de asistencia y eliminará los existentes. ¿Desea continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    Me.Cursor = Cursors.WaitCursor
                    If objBU.generaRegistrosChecadas(patronId, 1) = "EXITO" Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Registros de checadas generados correctamente.")
                        cargarListado()
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Errores, "No se pudieron generar registros de checadas para el periodo de nómina seleccinado.")
                    End If
                Catch ex As Exception
                    Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Error al generar registros de checadas para el periodo de nómina seleccinado.")
                Finally
                    Me.Cursor = Cursors.Default
                End Try
            End If
        Else
            If Not errorChecadas Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La consulta no devolvió resultados.")
            End If
        End If
    End Sub
End Class