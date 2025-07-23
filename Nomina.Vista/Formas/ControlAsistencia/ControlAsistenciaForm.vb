Imports Entidades
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports Stimulsoft.Report
Imports Tools

Public Class ControlAsistenciaForm

    Dim IsPeriodoEditable As Boolean = False
    Dim naveID As Integer

    Dim fLunes As String = String.Empty
    Dim fMartes As String = String.Empty
    Dim fMiercoles As String = String.Empty
    Dim fJueves As String = String.Empty
    Dim fViernes As String = String.Empty
    Dim fSabado As String = String.Empty
    Dim fDomingo As String = String.Empty

    Dim listaConfiguracionAsistencia As New List(Of Entidades.ConfiguracionAsistencia)

    Private Sub ControlAsistenciaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        'Tools.FormatoCtrls.formato(Me)

        listado_naves()
        btnCorte.Enabled = False
        lblCorte.Enabled = False
        lblCorte.Text = "Semana Cerrada"
        'clmResumen.Visible = False
        'clmIncentivos.Visible = False
        'clmCantidad.Visible = False
        clmPermisos.Visible = False
        clmRetardoMenor.Visible = False
        clmRetardoMayor.Visible = False
        clmInasistencias.Visible = False
        clmPuntualidadAsistencia.Visible = False
        clmCajaAhorro.Visible = False


        'rbtnOcultarIncidencias.Checked = True
        'rbtnOcultarResumen.Checked = True
        'rbtnOcultarSalidas.Checked = True

        clmLunes.HeaderText = "Lunes"
        clmMartes.HeaderText = "Martes"
        clmMiercoles.HeaderText = "Miércoles"
        clmJueves.HeaderText = "Jueves"
        clmViernes.HeaderText = "Viernes"
        clmSabado.HeaderText = "Sábado"
        clmDomingo.HeaderText = "Domingo"

        Me.Cursor = Cursors.Default
        '        Me.Cursor = Cursors.WaitCursor 

    End Sub

    Private Sub listado_naves()

        Try

            Controles.ComboNavesSegunUsuario(cboxNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))

        Catch ex As Exception

        End Try

        If cboxNave.SelectedIndex > 0 Then

            listado_periodos_asistencia()
            listado_areas()

        End If

    End Sub

    Private Sub listado_areas()
        Try

            Tools.Controles.ComboAreaSegunNave(cmbArea, cboxNave.SelectedValue)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub listado_departamentos()

        Try

            Tools.Controles.ComboDepartamentosSegunArea(cboxDepartamento, cmbArea.SelectedValue)
            'Controles.ComboDepatamentoSegunNave(cboxDepartamento, CInt(cboxNave.SelectedValue.ToString))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub listado_celulas()

        Try

            Tools.Controles.ComboCelulasSegunDepartamento(cboxCelula, cboxDepartamento.SelectedValue)
            'Controles.ComboDepatamentoSegunNave(cboxDepartamento, CInt(cboxNave.SelectedValue.ToString))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub listado_colaboradores()

        Try
            If cboxCelula.Items.Count = 1 Then
                Controles.ComboColaboradoresSegunDepto(cboxColaborador, CInt(cboxDepartamento.SelectedValue.ToString))
            Else
                Controles.ComboColaboradoresSegunCelula(cboxColaborador, CInt(cboxCelula.SelectedValue.ToString))
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub listado_periodos_asistencia()

        Try

            Controles.ComboPeriodoSegunNaveSegunAsistenciaControlAsistencia(cboxPeriodo, CInt(cboxNave.SelectedValue.ToString))
            Dim ControlDelPeriodoBu As New Negocios.ControlDePeriodoBU
            Dim periodoNominaID As Integer = CInt(ControlDelPeriodoBu.periodoSegunNaveSegunAsistenciaActual(CInt(cboxNave.SelectedValue.ToString)).Rows(0).Item(0).ToString)

            cboxPeriodo.SelectedValue = periodoNominaID
            cboxPeriodo.SelectedItem = cboxPeriodo.SelectedValue
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ControlAsistenciaBU As New Negocios.ControlAsistenciaBU
        Dim ControlDePeriodoBU As New Negocios.ControlDePeriodoBU
        Dim listaRegistroCheck As New List(Of Entidades.RegistroCheck)
        Dim areaID, departamentoID, celulaID, colaboradorID, periodoNomID As Integer
        Dim nombreColaborador As String

        If cboxNave.SelectedIndex > 0 Then

            naveID = cboxNave.SelectedValue

        End If




        If naveID <> 43 Then

            clmRetardoMayor.HeaderText = "R"
            clmRetardoMayor.ToolTipText = "Retardo"

        Else
            clmRetardoMayor.HeaderText = "RM"
            clmRetardoMayor.ToolTipText = "Retardo Mayor"
        End If

        If cmbArea.SelectedIndex > 0 Then

            areaID = cmbArea.SelectedValue

        End If

        If cboxDepartamento.SelectedIndex > 0 Then

            departamentoID = cboxDepartamento.SelectedValue

        Else

            departamentoID = 0

        End If

        If cboxCelula.SelectedIndex > 0 Then

            celulaID = cboxCelula.SelectedValue

        Else

            celulaID = 0

        End If


        If cboxColaborador.SelectedIndex > 0 Then

            colaboradorID = cboxColaborador.SelectedValue

        Else
            colaboradorID = 0
        End If

        If txtColaboradorCA.TextLength > 1 Then

            nombreColaborador = txtColaboradorCA.Text
        Else
            nombreColaborador = ""
        End If

        periodoNomID = cboxPeriodo.SelectedValue

        If ControlDePeriodoBU.buscarPeriodoEsActivoAsistencia(periodoNomID) Then
            IsPeriodoEditable = True
        Else
            IsPeriodoEditable = False
        End If


        If (IsDBNull(cboxDepartamento.SelectedValue) Or IsNothing(cboxDepartamento.SelectedValue)) _
            And (IsDBNull(cboxColaborador.SelectedValue) Or IsNothing(cboxColaborador.SelectedValue)) Then
            If IsPeriodoEditable Then

                btnCorte.Enabled = True
                lblCorte.Enabled = True
                lblCorte.Text = "Cerrar Semana"

            Else

                btnCorte.Enabled = False
                lblCorte.Enabled = False
                lblCorte.Text = "Semana Cerrada"


            End If
        Else
            btnCorte.Enabled = False
            lblCorte.Enabled = False
            lblCorte.Text = "Semana Cerrada"
        End If

        If rbtnMostrarIncidencias.Checked Then
            listaRegistroCheck = ControlAsistenciaBU.consultar_RegistroCheck(naveID, areaID, periodoNomID, departamentoID, celulaID, colaboradorID, nombreColaborador, 2)
        Else
            If rbtnOcultarIncidencias.Checked Then
                listaRegistroCheck = ControlAsistenciaBU.consultar_RegistroCheck(naveID, areaID, periodoNomID, departamentoID, celulaID, colaboradorID, nombreColaborador, 1)
            Else
                If Not rbtnOcultarIncidencias.Checked And Not rbtnMostrarIncidencias.Checked Then
                    listaRegistroCheck = ControlAsistenciaBU.consultar_RegistroCheck(naveID, areaID, periodoNomID, departamentoID, celulaID, colaboradorID, nombreColaborador, 1)
                End If
            End If
        End If

        Cursor.Current = Cursors.WaitCursor
        cargar_gridControlAsistencia(listaRegistroCheck)
        Cursor.Current = Cursors.Default
        Dim controlPeriodoBU As New Negocios.ControlDePeriodoBU
        Dim periodoRango As New Entidades.PeriodosNomina

        periodoRango = ControlDePeriodoBU.buscarRangosPeriodoSegunNaveSegunAsistencia(periodoNomID)

        asiganar_fecha_cabeceraGrid(periodoRango)

        If rbtnMostrarSalidas.Checked Then
            For Each row As DataGridViewRow In grdControlAsistencia.Rows
                If grdControlAsistencia.Rows(row.Index).Cells(3).Value = 2 Or grdControlAsistencia.Rows(row.Index).Cells(3).Value = 4 Then
                    grdControlAsistencia.Rows(row.Index).Visible = True
                End If
            Next
        Else
            If rbtnOcultarSalidas.Checked Then
                For Each row As DataGridViewRow In grdControlAsistencia.Rows
                    If grdControlAsistencia.Rows(row.Index).Cells(3).Value = 2 Or grdControlAsistencia.Rows(row.Index).Cells(3).Value = 4 Then
                        grdControlAsistencia.Rows(row.Index).Visible = False
                    End If
                Next
            Else
                If Not rbtnOcultarSalidas.Checked And Not rbtnMostrarSalidas.Checked Then
                    For Each row As DataGridViewRow In grdControlAsistencia.Rows
                        If grdControlAsistencia.Rows(row.Index).Cells(3).Value = 2 Or grdControlAsistencia.Rows(row.Index).Cells(3).Value = 4 Then
                            grdControlAsistencia.Rows(row.Index).Visible = False
                        End If
                    Next
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCorte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorte.Click

        If (IsDBNull(cboxDepartamento.SelectedValue) Or IsNothing(cboxDepartamento.SelectedValue)) _
            And (IsDBNull(cboxColaborador.SelectedValue) Or IsNothing(cboxColaborador.SelectedValue)) Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = "¿ Está seguro de cerrar el periodo de asistencia ? " + vbNewLine + "No podrá hacer modificaciones" + vbNewLine + " después del cierre."

            If mensajeExito.ShowDialog = DialogResult.OK Then
                btnAceptar.PerformClick()
                guardar_CorteChecador()
                ''ENVIO DE CORREO


            End If

        Else

            show_message("Aviso", "Sólo puede realizar el cierre en la nave completa.")

        End If

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click

        If IsNothing(grdControlAsistencia.CurrentCell) Then Return

        If grdControlAsistencia.CurrentCell.IsInEditMode Then
            MessageBox.Show("Esta editando")
        Else
            grdControlAsistencia.Rows.Clear()
        End If

    End Sub

    Public Sub cargar_gridControlAsistencia(ByVal listaRegistroCheck As List(Of Entidades.RegistroCheck))

        grdControlAsistencia.Rows.Clear()

        clmLunes.Visible = True
        clmMartes.Visible = True
        clmMiercoles.Visible = True
        clmJueves.Visible = True
        clmViernes.Visible = True
        clmSabado.Visible = True
        clmDomingo.Visible = True

        Dim listaCuentaColaboradores As List(Of Integer) = listaRegistroCheck.Select(Function(c) c.PCheck_Colaborador.PColaboradorid).Distinct.ToList
        Dim listaCuentaTipoCheck As List(Of Integer) = listaRegistroCheck.Select(Function(c) c.PCheck_Tipo).Distinct.ToList
        Dim corteChecadorBU As New Negocios.CorteChecadorBU

        Dim i, j As Integer
        Dim numerador As Integer = 1

        'agregó Juana
        Dim objBU As New Framework.Negocios.ConfiguracionAsistenciaBU
        listaConfiguracionAsistencia = objBU.listaConfiguracionAsistencia(naveID)
        'hasta aqui


        For Each colaborador As Integer In listaCuentaColaboradores

            Dim resultadoResumenChecador As Integer

            Dim colaboradorID As Integer = colaborador
            Dim objE As Entidades.RegistroCheck = _
                listaRegistroCheck.Find(Function(c) c.PCheck_Colaborador.PColaboradorid = colaboradorID)

            Dim colaboradorNombre As String = objE.PCheck_Colaborador.PNombre.ToString + " " + objE.PCheck_Colaborador.PApaterno.ToString + " " + objE.PCheck_Colaborador.PAmaterno


            'Dim iterador As Integer = 0
            Dim puntualidadAsistencia, cajaAhorro As Boolean

            'For Each tipoRegistro As Integer In listaCuentaTipoCheck
            For iterador As Integer = 0 To 3
                Dim listaResumenColaborador As List(Of Entidades.RegistroCheck) = listaRegistroCheck.FindAll(Function(c) c.PCheck_Colaborador.PColaboradorid = colaboradorID)

                If iterador = 0 Then
                    ''Permisos
                    'resultadoResumenChecador = corteChecadorBU.consultar_ResumenCorteChecador _
                    '                            (cboxPeriodo.SelectedValue, objE.PCheck_Colaborador.PColaboradorid, 0, 1)


                    Dim listaSoloExcepcionesColaborador As List(Of Entidades.RegistroCheck) = listaResumenColaborador.FindAll(Function(c) c.PCheck_Excepcion.Pregexc_id > 0)
                    resultadoResumenChecador = listaSoloExcepcionesColaborador.Count

                    grdControlAsistencia.Rows.Add((numerador), objE.PCheck_Colaborador.PColaboradorid, colaboradorNombre.ToUpper, _
                                                   1, "ENTRADA", Nothing, Nothing, Nothing, Nothing, Nothing, _
                                                   Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, _
                                                   "Permisos", resultadoResumenChecador, "Puntualidad y asistenica")



                End If

                If iterador = 1 Then
                    ''Retardo Menor
                    'resultadoResumenChecador = corteChecadorBU.consultar_ResumenCorteChecador _
                    '                            (cboxPeriodo.SelectedValue, objE.PCheck_Colaborador.PColaboradorid, 2, 2)

                    Dim listaRetardoMenorColaborador As List(Of Entidades.RegistroCheck) = listaResumenColaborador.FindAll(Function(c) c.PCheck_Resultado = 2)
                    resultadoResumenChecador = listaRetardoMenorColaborador.Count

                    If resultadoResumenChecador > 0 Then
                        cajaAhorro = False
                        If validar_puntualidad_asistencia(CInt(cboxNave.SelectedValue.ToString), cboxPeriodo.SelectedValue, objE.PCheck_Colaborador.PColaboradorid) Then
                            puntualidadAsistencia = True
                        Else
                            puntualidadAsistencia = False
                        End If

                    Else
                        puntualidadAsistencia = True
                        cajaAhorro = True
                    End If


                    grdControlAsistencia.Rows.Add((numerador), objE.PCheck_Colaborador.PColaboradorid, colaboradorNombre.ToUpper, _
                                                   2, "COMIDA", Nothing, Nothing, Nothing, Nothing, Nothing, _
                                                   Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, _
                                                   "Retardo menor", resultadoResumenChecador, puntualidadAsistencia)
                End If

                If iterador = 2 Then
                    ''Retardo Mayor
                    'resultadoResumenChecador = corteChecadorBU.consultar_ResumenCorteChecador _
                    '                            (cboxPeriodo.SelectedValue, objE.PCheck_Colaborador.PColaboradorid, 3, 2)

                    Dim listaRetardoMayorColaborador As List(Of Entidades.RegistroCheck) = listaResumenColaborador.FindAll(Function(c) c.PCheck_Resultado = 3)
                    resultadoResumenChecador = listaRetardoMayorColaborador.Count

                    If resultadoResumenChecador > 0 Then

                        cajaAhorro = False
                        puntualidadAsistencia = False
                        grdControlAsistencia.Rows(j - 1).Cells(21).Value = False

                    Else
                        puntualidadAsistencia = True

                    End If


                    grdControlAsistencia.Rows.Add((numerador), objE.PCheck_Colaborador.PColaboradorid, colaboradorNombre, _
                                                   3, "REGRESO", Nothing, Nothing, Nothing, Nothing, Nothing, _
                                                   Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, _
                                                   "Retardo mayor", resultadoResumenChecador, "Caja de ahorro")

                End If

                If iterador = 3 Then
                    ''Inasistencia
                    'resultadoResumenChecador = corteChecadorBU.consultar_ResumenCorteChecador _
                    '                            (cboxPeriodo.SelectedValue, objE.PCheck_Colaborador.PColaboradorid, 6, 2)


                    grdControlAsistencia.Rows.Add((numerador), objE.PCheck_Colaborador.PColaboradorid, colaboradorNombre, _
                                                   4, "SALIDA", Nothing, Nothing, Nothing, Nothing, Nothing, _
                                                   Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, _
                                                   "Inasistencias", (resultadoResumenChecador / 4), cajaAhorro)
                End If



                'iterador += 1

                If i Mod 2 = 0 Then

                    grdControlAsistencia.Rows(grdControlAsistencia.Rows.Count - 1).DefaultCellStyle.BackColor = Color.White

                Else

                    grdControlAsistencia.Rows(grdControlAsistencia.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Thistle

                End If

                j += 1

            Next

            numerador += 1
            i += 1
        Next

        If listaRegistroCheck.Count > 0 Then
            cargar_gridControlAsistencia_Datos(listaRegistroCheck)
        End If

    End Sub

    Public Sub cargar_gridControlAsistencia_Datos(ByVal listaRegistroCheck As List(Of Entidades.RegistroCheck))


        For Each registro As Entidades.RegistroCheck In listaRegistroCheck

            Dim iterador As Integer = 0

            For Each row As DataGridViewRow In grdControlAsistencia.Rows

                If registro.PCheck_normal = Date.MinValue Then

                    If registro.PCheck_automatico.DayOfWeek = 1 Then

                        If CInt(registro.PCheck_Colaborador.PColaboradorid) = CInt(grdControlAsistencia.Rows(iterador).Cells(1).Value.ToString) _
                            And CInt(registro.PCheck_Tipo) = CInt(grdControlAsistencia.Rows(iterador).Cells(3).Value.ToString) Then

                            grdControlAsistencia.Rows(iterador).Cells(5).Value = registro.PId

                            If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                grdControlAsistencia.Rows(iterador).Cells(6).Value = registro.PCheck_manual.ToLongTimeString
                            Else
                                If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(6).Value = registro.PCheck_automatico.ToLongTimeString
                                End If
                            End If

                            If registro.PCheck_Resultado = 1 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(6).Style.ForeColor = Color.DarkGreen
                                    grdControlAsistencia.Rows(iterador).Cells(6).ToolTipText = "Registro correcto" + vbCr + "Nota: " + registro.PCheck_Nota
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(6).Style.ForeColor = Color.Blue
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 2 Then
                                grdControlAsistencia.Rows(iterador).Cells(6).Style.ForeColor = Color.DarkGreen
                                grdControlAsistencia.Rows(iterador).Cells(6).ToolTipText = "Retardo menor" + vbCr + "Nota: " + registro.PCheck_Nota
                            End If
                            If registro.PCheck_Resultado = 3 Then
                                grdControlAsistencia.Rows(iterador).Cells(6).Style.ForeColor = Color.DarkGreen
                                grdControlAsistencia.Rows(iterador).Cells(6).ToolTipText = "Retardo mayor" + vbCr + "Nota: " + registro.PCheck_Nota
                            End If
                            If registro.PCheck_Resultado = 0 Then
                                grdControlAsistencia.Rows(iterador).Cells(6).Style.ForeColor = Color.Maroon
                                grdControlAsistencia.Rows(iterador).Cells(6).Value = "NO REGISTRO"
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(6).ToolTipText = "Registro manual: " + vbCr + "Nota: " + registro.PCheck_Nota
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(6).ToolTipText = "Registro automático: " + registro.PCheck_automatico.ToLongTimeString
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 7 Then
                                grdControlAsistencia.Rows(iterador).Cells(6).ToolTipText = "Sin salida a comida" + vbCr + "Nota: " + registro.PCheck_Nota
                                grdControlAsistencia.Rows(iterador).Cells(6).Style.ForeColor = Color.Indigo
                            End If
                            If Not IsNothing(registro.PCheck_Excepcion.Pregexc_motivo) Then
                                If registro.PCheck_Excepcion.Pregexc_motivo.Pexmot_motivo_laboral = True Then
                                    grdControlAsistencia.Rows(iterador).Cells(6).Style.ForeColor = Color.DeepSkyBlue
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(6).Style.ForeColor = Color.Blue
                                End If
                            End If
                            If True Then

                            End If

                        End If
                    End If

                    If registro.PCheck_automatico.DayOfWeek = 2 Then

                        If CInt(registro.PCheck_Colaborador.PColaboradorid) = CInt(grdControlAsistencia.Rows(iterador).Cells(1).Value.ToString) _
                            And CInt(registro.PCheck_Tipo) = CInt(grdControlAsistencia.Rows(iterador).Cells(3).Value.ToString) Then

                            grdControlAsistencia.Rows(iterador).Cells(7).Value = registro.PId

                            If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                grdControlAsistencia.Rows(iterador).Cells(8).Value = registro.PCheck_manual.ToLongTimeString
                            Else
                                If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(8).Value = registro.PCheck_automatico.ToLongTimeString
                                End If
                            End If

                            If registro.PCheck_Resultado = 1 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(8).Style.ForeColor = Color.DarkGreen
                                    grdControlAsistencia.Rows(iterador).Cells(8).ToolTipText = "Registro correcto" + vbCr + "Nota: " + registro.PCheck_Nota
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(8).Style.ForeColor = Color.Blue
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 2 Then
                                grdControlAsistencia.Rows(iterador).Cells(8).Style.ForeColor = Color.DarkGreen
                                grdControlAsistencia.Rows(iterador).Cells(8).ToolTipText = "Retardo menor" + vbCr + "Nota: " + registro.PCheck_Nota
                            End If
                            If registro.PCheck_Resultado = 3 Then
                                grdControlAsistencia.Rows(iterador).Cells(8).Style.ForeColor = Color.DarkGreen
                                grdControlAsistencia.Rows(iterador).Cells(8).ToolTipText = "Retardo mayor" + vbCr + "Nota: " + registro.PCheck_Nota
                            End If
                            If registro.PCheck_Resultado = 0 Then
                                grdControlAsistencia.Rows(iterador).Cells(8).Style.ForeColor = Color.Maroon
                                grdControlAsistencia.Rows(iterador).Cells(8).Value = "NO REGISTRO"
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(8).ToolTipText = "Registro manual: " + vbCr + "Nota: " + registro.PCheck_Nota
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(8).ToolTipText = "Registro automático: " + registro.PCheck_automatico.ToLongTimeString
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 7 Then
                                grdControlAsistencia.Rows(iterador).Cells(8).ToolTipText = "Sin salida a comida" + vbCr + "Nota: " + registro.PCheck_Nota
                                grdControlAsistencia.Rows(iterador).Cells(8).Style.ForeColor = Color.Indigo
                            End If
                            If Not IsNothing(registro.PCheck_Excepcion.Pregexc_motivo) Then
                                If registro.PCheck_Excepcion.Pregexc_motivo.Pexmot_motivo_laboral = True Then
                                    grdControlAsistencia.Rows(iterador).Cells(8).Style.ForeColor = Color.DeepSkyBlue
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(8).Style.ForeColor = Color.Blue
                                End If
                            End If
                        End If
                    End If

                    If registro.PCheck_automatico.DayOfWeek = 3 Then
                        If CInt(registro.PCheck_Colaborador.PColaboradorid) = CInt(grdControlAsistencia.Rows(iterador).Cells(1).Value.ToString) _
                            And CInt(registro.PCheck_Tipo) = CInt(grdControlAsistencia.Rows(iterador).Cells(3).Value.ToString) Then

                            grdControlAsistencia.Rows(iterador).Cells(9).Value = registro.PId

                            If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                grdControlAsistencia.Rows(iterador).Cells(10).Value = registro.PCheck_manual.ToLongTimeString
                            Else
                                If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(10).Value = registro.PCheck_automatico.ToLongTimeString
                                End If
                            End If

                            If registro.PCheck_Resultado = 1 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(10).Style.ForeColor = Color.DarkGreen
                                    grdControlAsistencia.Rows(iterador).Cells(10).ToolTipText = "Registro correcto" + vbCr + "Nota: " + registro.PCheck_Nota
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(10).Style.ForeColor = Color.Blue
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 2 Then
                                grdControlAsistencia.Rows(iterador).Cells(10).Style.ForeColor = Color.DarkGreen
                                grdControlAsistencia.Rows(iterador).Cells(10).ToolTipText = "Retardo menor" + vbCr + "Nota: " + registro.PCheck_Nota
                            End If
                            If registro.PCheck_Resultado = 3 Then
                                grdControlAsistencia.Rows(iterador).Cells(10).Style.ForeColor = Color.DarkGreen
                                grdControlAsistencia.Rows(iterador).Cells(10).ToolTipText = "Retardo mayor" + vbCr + "Nota: " + registro.PCheck_Nota
                            End If
                            If registro.PCheck_Resultado = 0 Then
                                grdControlAsistencia.Rows(iterador).Cells(10).Style.ForeColor = Color.Maroon
                                grdControlAsistencia.Rows(iterador).Cells(10).Value = "NO REGISTRO"
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(10).ToolTipText = "Registro manual: " + vbCr + "Nota: " + registro.PCheck_Nota
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(10).ToolTipText = "Registro automático: " + registro.PCheck_automatico.ToLongTimeString
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 7 Then
                                grdControlAsistencia.Rows(iterador).Cells(10).ToolTipText = "Sin salida a comida" + vbCr + "Nota: " + registro.PCheck_Nota
                                grdControlAsistencia.Rows(iterador).Cells(10).Style.ForeColor = Color.Indigo
                            End If
                            If Not IsNothing(registro.PCheck_Excepcion.Pregexc_motivo) Then
                                If registro.PCheck_Excepcion.Pregexc_motivo.Pexmot_motivo_laboral = True Then
                                    grdControlAsistencia.Rows(iterador).Cells(10).Style.ForeColor = Color.DeepSkyBlue
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(10).Style.ForeColor = Color.Blue
                                End If
                            End If

                        End If
                    End If

                    If registro.PCheck_automatico.DayOfWeek = 4 Then
                        If CInt(registro.PCheck_Colaborador.PColaboradorid) = CInt(grdControlAsistencia.Rows(iterador).Cells(1).Value.ToString) _
                            And CInt(registro.PCheck_Tipo) = CInt(grdControlAsistencia.Rows(iterador).Cells(3).Value.ToString) Then

                            grdControlAsistencia.Rows(iterador).Cells(11).Value = registro.PId

                            If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                grdControlAsistencia.Rows(iterador).Cells(12).Value = registro.PCheck_manual.ToLongTimeString
                            Else
                                If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(12).Value = registro.PCheck_automatico.ToLongTimeString
                                End If
                            End If

                            If registro.PCheck_Resultado = 1 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(12).Style.ForeColor = Color.DarkGreen
                                    grdControlAsistencia.Rows(iterador).Cells(12).ToolTipText = "Registro correcto" + vbCr + "Nota: " + registro.PCheck_Nota
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(12).Style.ForeColor = Color.Blue
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 2 Then
                                grdControlAsistencia.Rows(iterador).Cells(12).Style.ForeColor = Color.DarkGreen
                                grdControlAsistencia.Rows(iterador).Cells(12).ToolTipText = "Retardo menor" + vbCr + "Nota: " + registro.PCheck_Nota
                            End If
                            If registro.PCheck_Resultado = 3 Then
                                grdControlAsistencia.Rows(iterador).Cells(12).Style.ForeColor = Color.DarkGreen
                                grdControlAsistencia.Rows(iterador).Cells(12).ToolTipText = "Retardo mayor" + vbCr + "Nota: " + registro.PCheck_Nota
                            End If
                            If registro.PCheck_Resultado = 0 Then
                                grdControlAsistencia.Rows(iterador).Cells(12).Style.ForeColor = Color.Maroon
                                grdControlAsistencia.Rows(iterador).Cells(12).Value = "NO REGISTRO"
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(12).ToolTipText = "Registro manual: " + vbCr + "Nota: " + registro.PCheck_Nota
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(12).ToolTipText = "Registro automático: " + registro.PCheck_automatico.ToLongTimeString
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 7 Then
                                grdControlAsistencia.Rows(iterador).Cells(12).ToolTipText = "Sin salida a comida" + vbCr + "Nota: " + registro.PCheck_Nota
                                grdControlAsistencia.Rows(iterador).Cells(12).Style.ForeColor = Color.Indigo
                            End If
                            If Not IsNothing(registro.PCheck_Excepcion.Pregexc_motivo) Then
                                If registro.PCheck_Excepcion.Pregexc_motivo.Pexmot_motivo_laboral = True Then
                                    grdControlAsistencia.Rows(iterador).Cells(12).Style.ForeColor = Color.DeepSkyBlue
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(12).Style.ForeColor = Color.Blue
                                End If
                            End If

                        End If
                    End If

                    If registro.PCheck_automatico.DayOfWeek = 5 Then
                        If CInt(registro.PCheck_Colaborador.PColaboradorid) = CInt(grdControlAsistencia.Rows(iterador).Cells(1).Value.ToString) _
                            And CInt(registro.PCheck_Tipo) = CInt(grdControlAsistencia.Rows(iterador).Cells(3).Value.ToString) Then

                            grdControlAsistencia.Rows(iterador).Cells(13).Value = registro.PId

                            If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                grdControlAsistencia.Rows(iterador).Cells(14).Value = registro.PCheck_manual.ToLongTimeString
                            Else
                                If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(14).Value = registro.PCheck_automatico.ToLongTimeString
                                End If
                            End If

                            If registro.PCheck_Resultado = 1 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(14).Style.ForeColor = Color.DarkGreen
                                    grdControlAsistencia.Rows(iterador).Cells(14).ToolTipText = "Registro correcto" + vbCr + "Nota: " + registro.PCheck_Nota
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(14).Style.ForeColor = Color.Blue
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 2 Then
                                grdControlAsistencia.Rows(iterador).Cells(14).Style.ForeColor = Color.DarkGreen
                                grdControlAsistencia.Rows(iterador).Cells(14).ToolTipText = "Retardo menor" + vbCr + "Nota: " + registro.PCheck_Nota
                            End If
                            If registro.PCheck_Resultado = 3 Then
                                grdControlAsistencia.Rows(iterador).Cells(14).Style.ForeColor = Color.DarkGreen
                                grdControlAsistencia.Rows(iterador).Cells(14).ToolTipText = "Retardo mayor" + vbCr + "Nota: " + registro.PCheck_Nota
                            End If
                            If registro.PCheck_Resultado = 0 Then
                                grdControlAsistencia.Rows(iterador).Cells(14).Style.ForeColor = Color.Maroon
                                grdControlAsistencia.Rows(iterador).Cells(14).Value = "NO REGISTRO"
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(14).ToolTipText = "Registro manual: " + vbCr + "Nota: " + registro.PCheck_Nota
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(14).ToolTipText = "Registro automático: " + registro.PCheck_automatico.ToLongTimeString
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 7 Then
                                grdControlAsistencia.Rows(iterador).Cells(14).ToolTipText = "Sin salida a comida" + vbCr + "Nota: " + registro.PCheck_Nota
                                grdControlAsistencia.Rows(iterador).Cells(14).Style.ForeColor = Color.Indigo
                            End If
                            If Not IsNothing(registro.PCheck_Excepcion.Pregexc_motivo) Then
                                If registro.PCheck_Excepcion.Pregexc_motivo.Pexmot_motivo_laboral = True Then
                                    grdControlAsistencia.Rows(iterador).Cells(14).Style.ForeColor = Color.DeepSkyBlue
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(14).Style.ForeColor = Color.Blue
                                End If
                            End If
                        End If
                    End If

                    If registro.PCheck_automatico.DayOfWeek = 6 Then
                        If CInt(registro.PCheck_Colaborador.PColaboradorid) = CInt(grdControlAsistencia.Rows(iterador).Cells(1).Value.ToString) _
                            And CInt(registro.PCheck_Tipo) = CInt(grdControlAsistencia.Rows(iterador).Cells(3).Value.ToString) Then

                            grdControlAsistencia.Rows(iterador).Cells(15).Value = registro.PId

                            If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                grdControlAsistencia.Rows(iterador).Cells(16).Value = registro.PCheck_manual.ToLongTimeString
                            Else
                                If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(16).Value = registro.PCheck_automatico.ToLongTimeString
                                End If
                            End If

                            If registro.PCheck_Resultado = 1 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(16).Style.ForeColor = Color.DarkGreen
                                    grdControlAsistencia.Rows(iterador).Cells(16).ToolTipText = "Registro correcto" + vbCr + "Nota: " + registro.PCheck_Nota
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(16).Style.ForeColor = Color.Blue
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 2 Then
                                grdControlAsistencia.Rows(iterador).Cells(16).Style.ForeColor = Color.DarkGreen
                                grdControlAsistencia.Rows(iterador).Cells(16).ToolTipText = "Retardo menor" + vbCr + "Nota: " + registro.PCheck_Nota
                            End If
                            If registro.PCheck_Resultado = 3 Then
                                grdControlAsistencia.Rows(iterador).Cells(16).Style.ForeColor = Color.DarkGreen
                                grdControlAsistencia.Rows(iterador).Cells(16).ToolTipText = "Retardo mayor" + vbCr + "Nota: " + registro.PCheck_Nota
                            End If
                            If registro.PCheck_Resultado = 0 Then
                                grdControlAsistencia.Rows(iterador).Cells(16).Style.ForeColor = Color.Maroon
                                grdControlAsistencia.Rows(iterador).Cells(16).Value = "NO REGISTRO"
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(16).ToolTipText = "Registro manual: " + vbCr + "Nota: " + registro.PCheck_Nota
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(16).ToolTipText = "Registro automático: " + registro.PCheck_automatico.ToLongTimeString
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 7 Then
                                grdControlAsistencia.Rows(iterador).Cells(16).ToolTipText = "Sin salida a comida" + vbCr + "Nota: " + registro.PCheck_Nota
                                grdControlAsistencia.Rows(iterador).Cells(16).Style.ForeColor = Color.Indigo
                            End If
                            If Not IsNothing(registro.PCheck_Excepcion.Pregexc_motivo) Then
                                If registro.PCheck_Excepcion.Pregexc_motivo.Pexmot_motivo_laboral = True Then
                                    grdControlAsistencia.Rows(iterador).Cells(16).Style.ForeColor = Color.DeepSkyBlue
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(16).Style.ForeColor = Color.Blue
                                End If
                            End If
                        End If
                    End If

                    If registro.PCheck_automatico.DayOfWeek = 0 Then
                        If CInt(registro.PCheck_Colaborador.PColaboradorid) = CInt(grdControlAsistencia.Rows(iterador).Cells(1).Value.ToString) _
                            And CInt(registro.PCheck_Tipo) = CInt(grdControlAsistencia.Rows(iterador).Cells(3).Value.ToString) Then

                            grdControlAsistencia.Rows(iterador).Cells(17).Value = registro.PId

                            If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                grdControlAsistencia.Rows(iterador).Cells(18).Value = registro.PCheck_manual.ToLongTimeString
                            Else
                                If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(18).Value = registro.PCheck_automatico.ToLongTimeString
                                End If
                            End If

                            If registro.PCheck_Resultado = 1 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(18).Style.ForeColor = Color.DarkGreen
                                    grdControlAsistencia.Rows(iterador).Cells(18).ToolTipText = "Registro correcto" + vbCr + "Nota: " + registro.PCheck_Nota
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(18).Style.ForeColor = Color.Blue
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 2 Then
                                grdControlAsistencia.Rows(iterador).Cells(18).Style.ForeColor = Color.DarkGreen
                                grdControlAsistencia.Rows(iterador).Cells(18).ToolTipText = "Retardo menor" + vbCr + "Nota: " + registro.PCheck_Nota
                            End If
                            If registro.PCheck_Resultado = 3 Then
                                grdControlAsistencia.Rows(iterador).Cells(18).Style.ForeColor = Color.DarkGreen
                                grdControlAsistencia.Rows(iterador).Cells(18).ToolTipText = "Retardo mayor" + vbCr + "Nota: " + registro.PCheck_Nota
                            End If
                            If registro.PCheck_Resultado = 0 Then
                                grdControlAsistencia.Rows(iterador).Cells(18).Style.ForeColor = Color.Maroon
                                grdControlAsistencia.Rows(iterador).Cells(18).Value = "NO REGISTRO"
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(18).ToolTipText = "Registro manual: " + vbCr + "Nota: " + registro.PCheck_Nota
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(18).ToolTipText = "Registro automático: " + registro.PCheck_automatico.ToLongTimeString
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 7 Then
                                grdControlAsistencia.Rows(iterador).Cells(18).ToolTipText = "Sin salida a comida" + vbCr + "Nota: " + registro.PCheck_Nota
                                grdControlAsistencia.Rows(iterador).Cells(18).Style.ForeColor = Color.Indigo
                            End If
                            If Not IsNothing(registro.PCheck_Excepcion.Pregexc_motivo) Then
                                If registro.PCheck_Excepcion.Pregexc_motivo.Pexmot_motivo_laboral = True Then
                                    grdControlAsistencia.Rows(iterador).Cells(18).Style.ForeColor = Color.DeepSkyBlue
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(18).Style.ForeColor = Color.Blue
                                End If
                            End If
                        End If
                    End If

                Else

                    If registro.PCheck_normal.DayOfWeek = 1 Then

                        If CInt(registro.PCheck_Colaborador.PColaboradorid) = CInt(grdControlAsistencia.Rows(iterador).Cells(1).Value.ToString) _
                            And CInt(registro.PCheck_Tipo) = CInt(grdControlAsistencia.Rows(iterador).Cells(3).Value.ToString) Then

                            grdControlAsistencia.Rows(iterador).Cells(5).Value = registro.PId

                            If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                grdControlAsistencia.Rows(iterador).Cells(6).Value = registro.PCheck_manual.ToLongTimeString
                            Else
                                If Not registro.PCheck_normal.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(6).Value = registro.PCheck_normal.ToLongTimeString
                                End If
                            End If

                            If registro.PCheck_Resultado = 1 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(6).ToolTipText = "Registro correcto " + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(6).Style.ForeColor = Color.DarkGreen
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(6).ToolTipText = "Registro correcto " + vbCr + "Registro con permiso: " + registro.PCheck_automatico.ToLongTimeString
                                        grdControlAsistencia.Rows(iterador).Cells(6).Style.ForeColor = Color.Blue
                                    Else
                                        grdControlAsistencia.Rows(iterador).Cells(6).Style.ForeColor = Color.Black
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 2 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(6).ToolTipText = "Retardo menor" + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(6).Style.ForeColor = Color.DarkGreen
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(6).Style.ForeColor = Color.Goldenrod
                                End If

                            End If
                            If registro.PCheck_Resultado = 3 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(6).ToolTipText = "Retardo mayor" + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(6).Style.ForeColor = Color.DarkGreen
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(6).Style.ForeColor = Color.DarkOrange
                                End If
                            End If
                            If registro.PCheck_Resultado = 4 Then
                                grdControlAsistencia.Rows(iterador).Cells(6).Style.ForeColor = Color.DarkCyan
                            End If
                            If Not IsNothing(registro.PCheck_Excepcion.Pregexc_motivo) Then
                                If registro.PCheck_Excepcion.Pregexc_motivo.Pexmot_motivo_laboral = True Then
                                    grdControlAsistencia.Rows(iterador).Cells(6).Style.ForeColor = Color.DeepSkyBlue
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(6).Style.ForeColor = Color.Blue
                                End If
                            End If

                        End If

                    End If

                    If registro.PCheck_normal.DayOfWeek = 2 Then

                        If CInt(registro.PCheck_Colaborador.PColaboradorid) = CInt(grdControlAsistencia.Rows(iterador).Cells(1).Value.ToString) _
                            And CInt(registro.PCheck_Tipo) = CInt(grdControlAsistencia.Rows(iterador).Cells(3).Value.ToString) Then

                            grdControlAsistencia.Rows(iterador).Cells(7).Value = registro.PId

                            If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                grdControlAsistencia.Rows(iterador).Cells(8).Value = registro.PCheck_manual.ToLongTimeString
                            Else
                                If Not registro.PCheck_normal.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(8).Value = registro.PCheck_normal.ToLongTimeString
                                End If
                            End If

                            If registro.PCheck_Resultado = 1 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(8).ToolTipText = "Registro correcto " + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(8).Style.ForeColor = Color.DarkGreen
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(8).ToolTipText = "Registro correcto " + vbCr + "Registro con permiso: " + registro.PCheck_automatico.ToLongTimeString
                                        grdControlAsistencia.Rows(iterador).Cells(8).Style.ForeColor = Color.Blue
                                    Else
                                        grdControlAsistencia.Rows(iterador).Cells(8).Style.ForeColor = Color.Black
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 2 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(8).ToolTipText = "Retardo menor" + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(8).Style.ForeColor = Color.DarkGreen
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(8).Style.ForeColor = Color.Goldenrod
                                End If
                            End If
                            If registro.PCheck_Resultado = 3 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(8).ToolTipText = "Retardo mayor" + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(8).Style.ForeColor = Color.DarkGreen
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(8).Style.ForeColor = Color.DarkOrange
                                End If
                            End If
                            If registro.PCheck_Resultado = 4 Then
                                grdControlAsistencia.Rows(iterador).Cells(8).Style.ForeColor = Color.DarkCyan
                            End If
                            If Not IsNothing(registro.PCheck_Excepcion.Pregexc_motivo) Then
                                If registro.PCheck_Excepcion.Pregexc_motivo.Pexmot_motivo_laboral = True Then
                                    grdControlAsistencia.Rows(iterador).Cells(8).Style.ForeColor = Color.DeepSkyBlue
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(8).Style.ForeColor = Color.Blue
                                End If
                            End If

                        End If
                    End If

                    If registro.PCheck_normal.DayOfWeek = 3 Then
                        If CInt(registro.PCheck_Colaborador.PColaboradorid) = CInt(grdControlAsistencia.Rows(iterador).Cells(1).Value.ToString) _
                            And CInt(registro.PCheck_Tipo) = CInt(grdControlAsistencia.Rows(iterador).Cells(3).Value.ToString) Then

                            grdControlAsistencia.Rows(iterador).Cells(9).Value = registro.PId

                            If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                grdControlAsistencia.Rows(iterador).Cells(10).Value = registro.PCheck_manual.ToLongTimeString
                            Else
                                If Not registro.PCheck_normal.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(10).Value = registro.PCheck_normal.ToLongTimeString
                                End If
                            End If

                            If registro.PCheck_Resultado = 1 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(10).ToolTipText = "Registro correcto " + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(10).Style.ForeColor = Color.DarkGreen
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(10).ToolTipText = "Registro correcto " + vbCr + "Registro con permiso: " + registro.PCheck_automatico.ToLongTimeString
                                        grdControlAsistencia.Rows(iterador).Cells(10).Style.ForeColor = Color.Blue
                                    Else
                                        grdControlAsistencia.Rows(iterador).Cells(10).Style.ForeColor = Color.Black
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 2 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(10).ToolTipText = "Retardo menor" + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(10).Style.ForeColor = Color.DarkGreen
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(10).Style.ForeColor = Color.Goldenrod
                                End If
                            End If
                            If registro.PCheck_Resultado = 3 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(10).ToolTipText = "Retardo mayor" + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(10).Style.ForeColor = Color.DarkGreen
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(10).Style.ForeColor = Color.DarkOrange
                                End If
                            End If
                            If registro.PCheck_Resultado = 4 Then
                                grdControlAsistencia.Rows(iterador).Cells(10).Style.ForeColor = Color.DarkCyan
                            End If
                            If Not IsNothing(registro.PCheck_Excepcion.Pregexc_motivo) Then
                                If registro.PCheck_Excepcion.Pregexc_motivo.Pexmot_motivo_laboral = True Then
                                    grdControlAsistencia.Rows(iterador).Cells(10).Style.ForeColor = Color.DeepSkyBlue
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(10).Style.ForeColor = Color.Blue
                                End If
                            End If

                        End If
                    End If

                    If registro.PCheck_normal.DayOfWeek = 4 Then
                        If CInt(registro.PCheck_Colaborador.PColaboradorid) = CInt(grdControlAsistencia.Rows(iterador).Cells(1).Value.ToString) _
                            And CInt(registro.PCheck_Tipo) = CInt(grdControlAsistencia.Rows(iterador).Cells(3).Value.ToString) Then

                            grdControlAsistencia.Rows(iterador).Cells(11).Value = registro.PId

                            If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                grdControlAsistencia.Rows(iterador).Cells(12).Value = registro.PCheck_manual.ToLongTimeString
                            Else
                                If Not registro.PCheck_normal.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(12).Value = registro.PCheck_normal.ToLongTimeString
                                End If
                            End If

                            If registro.PCheck_Resultado = 1 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(12).ToolTipText = "Registro correcto " + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(12).Style.ForeColor = Color.DarkGreen
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(12).ToolTipText = "Registro correcto " + vbCr + "Registro con permiso: " + registro.PCheck_automatico.ToLongTimeString
                                        grdControlAsistencia.Rows(iterador).Cells(12).Style.ForeColor = Color.Blue
                                    Else
                                        grdControlAsistencia.Rows(iterador).Cells(12).Style.ForeColor = Color.Black
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 2 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(12).ToolTipText = "Retardo menor" + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(12).Style.ForeColor = Color.DarkGreen
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(12).Style.ForeColor = Color.Goldenrod
                                End If
                            End If
                            If registro.PCheck_Resultado = 3 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(12).ToolTipText = "Retardo mayor" + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(12).Style.ForeColor = Color.DarkGreen
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(12).Style.ForeColor = Color.DarkOrange
                                End If
                            End If
                            If registro.PCheck_Resultado = 4 Then
                                grdControlAsistencia.Rows(iterador).Cells(12).Style.ForeColor = Color.DarkCyan
                            End If
                            If Not IsNothing(registro.PCheck_Excepcion.Pregexc_motivo) Then
                                If registro.PCheck_Excepcion.Pregexc_motivo.Pexmot_motivo_laboral = True Then
                                    grdControlAsistencia.Rows(iterador).Cells(12).Style.ForeColor = Color.DeepSkyBlue
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(12).Style.ForeColor = Color.Blue
                                End If
                            End If

                        End If
                    End If

                    If registro.PCheck_normal.DayOfWeek = 5 Then
                        If CInt(registro.PCheck_Colaborador.PColaboradorid) = CInt(grdControlAsistencia.Rows(iterador).Cells(1).Value.ToString) _
                            And CInt(registro.PCheck_Tipo) = CInt(grdControlAsistencia.Rows(iterador).Cells(3).Value.ToString) Then

                            grdControlAsistencia.Rows(iterador).Cells(13).Value = registro.PId

                            If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                grdControlAsistencia.Rows(iterador).Cells(14).Value = registro.PCheck_manual.ToLongTimeString
                            Else
                                If Not registro.PCheck_normal.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(14).Value = registro.PCheck_normal.ToLongTimeString
                                End If
                            End If

                            If registro.PCheck_Resultado = 1 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(14).ToolTipText = "Registro correcto " + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(14).Style.ForeColor = Color.DarkGreen
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(14).ToolTipText = "Registro correcto " + vbCr + "Registro con permiso: " + registro.PCheck_automatico.ToLongTimeString
                                        grdControlAsistencia.Rows(iterador).Cells(14).Style.ForeColor = Color.Blue
                                    Else
                                        grdControlAsistencia.Rows(iterador).Cells(14).Style.ForeColor = Color.Black
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 2 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(14).ToolTipText = "Retardo menor" + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(14).Style.ForeColor = Color.DarkGreen
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(14).Style.ForeColor = Color.Goldenrod
                                End If
                            End If
                            If registro.PCheck_Resultado = 3 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(14).ToolTipText = "Retardo mayor" + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(14).Style.ForeColor = Color.DarkGreen
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(14).Style.ForeColor = Color.DarkOrange
                                End If
                            End If
                            If registro.PCheck_Resultado = 4 Then
                                grdControlAsistencia.Rows(iterador).Cells(14).Style.ForeColor = Color.DarkCyan
                            End If
                            If Not IsNothing(registro.PCheck_Excepcion.Pregexc_motivo) Then
                                If registro.PCheck_Excepcion.Pregexc_motivo.Pexmot_motivo_laboral = True Then
                                    grdControlAsistencia.Rows(iterador).Cells(14).Style.ForeColor = Color.DeepSkyBlue
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(14).Style.ForeColor = Color.Blue
                                End If
                            End If

                        End If
                    End If

                    If registro.PCheck_normal.DayOfWeek = 6 Then
                        If CInt(registro.PCheck_Colaborador.PColaboradorid) = CInt(grdControlAsistencia.Rows(iterador).Cells(1).Value.ToString) _
                            And CInt(registro.PCheck_Tipo) = CInt(grdControlAsistencia.Rows(iterador).Cells(3).Value.ToString) Then

                            grdControlAsistencia.Rows(iterador).Cells(15).Value = registro.PId

                            If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                grdControlAsistencia.Rows(iterador).Cells(16).Value = registro.PCheck_manual.ToLongTimeString
                            Else
                                If Not registro.PCheck_normal.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(16).Value = registro.PCheck_normal.ToLongTimeString
                                End If
                            End If

                            If registro.PCheck_Resultado = 1 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(16).ToolTipText = "Registro correcto " + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(16).Style.ForeColor = Color.DarkGreen
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(16).ToolTipText = "Registro correcto " + vbCr + "Registro con permiso: " + registro.PCheck_automatico.ToLongTimeString
                                        grdControlAsistencia.Rows(iterador).Cells(16).Style.ForeColor = Color.Blue
                                    Else
                                        grdControlAsistencia.Rows(iterador).Cells(16).Style.ForeColor = Color.Black
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 2 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(16).ToolTipText = "Retardo menor" + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(16).Style.ForeColor = Color.DarkGreen
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(16).Style.ForeColor = Color.Goldenrod
                                End If
                            End If
                            If registro.PCheck_Resultado = 3 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(16).ToolTipText = "Retardo mayor" + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(16).Style.ForeColor = Color.DarkGreen
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(16).Style.ForeColor = Color.DarkOrange
                                End If
                            End If
                            If registro.PCheck_Resultado = 4 Then
                                grdControlAsistencia.Rows(iterador).Cells(16).Style.ForeColor = Color.DarkCyan
                            End If
                            If Not IsNothing(registro.PCheck_Excepcion.Pregexc_motivo) Then
                                If registro.PCheck_Excepcion.Pregexc_motivo.Pexmot_motivo_laboral = True Then
                                    grdControlAsistencia.Rows(iterador).Cells(16).Style.ForeColor = Color.DeepSkyBlue
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(16).Style.ForeColor = Color.Blue
                                End If
                            End If

                        End If
                    End If

                    If registro.PCheck_normal.DayOfWeek = 0 Then
                        If CInt(registro.PCheck_Colaborador.PColaboradorid) = CInt(grdControlAsistencia.Rows(iterador).Cells(1).Value.ToString) _
                            And CInt(registro.PCheck_Tipo) = CInt(grdControlAsistencia.Rows(iterador).Cells(3).Value.ToString) Then

                            grdControlAsistencia.Rows(iterador).Cells(17).Value = registro.PId

                            If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                grdControlAsistencia.Rows(iterador).Cells(18).Value = registro.PCheck_manual.ToLongTimeString
                            Else
                                If Not registro.PCheck_normal.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(18).Value = registro.PCheck_normal.ToLongTimeString
                                End If
                            End If

                            If registro.PCheck_Resultado = 1 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(18).ToolTipText = "Registro correcto " + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(18).Style.ForeColor = Color.DarkGreen
                                Else
                                    If Not registro.PCheck_automatico.Equals(Date.MinValue) Then
                                        grdControlAsistencia.Rows(iterador).Cells(18).ToolTipText = "Registro correcto " + vbCr + "Registro con permiso: " + registro.PCheck_automatico.ToLongTimeString
                                        grdControlAsistencia.Rows(iterador).Cells(18).Style.ForeColor = Color.Blue
                                    Else
                                        grdControlAsistencia.Rows(iterador).Cells(18).Style.ForeColor = Color.Black
                                    End If
                                End If
                            End If
                            If registro.PCheck_Resultado = 2 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(18).ToolTipText = "Retardo menor" + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(18).Style.ForeColor = Color.DarkGreen
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(18).Style.ForeColor = Color.Goldenrod
                                End If
                            End If
                            If registro.PCheck_Resultado = 3 Then
                                If Not registro.PCheck_manual.Equals(Date.MinValue) Then
                                    grdControlAsistencia.Rows(iterador).Cells(18).ToolTipText = "Retardo mayor" + vbCr + "Registro normal: " + registro.PCheck_normal.ToLongTimeString + vbCr + "Nota: " + registro.PCheck_Nota
                                    grdControlAsistencia.Rows(iterador).Cells(18).Style.ForeColor = Color.DarkGreen
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(18).Style.ForeColor = Color.DarkOrange
                                End If
                            End If
                            If registro.PCheck_Resultado = 4 Then
                                grdControlAsistencia.Rows(iterador).Cells(18).Style.ForeColor = Color.DarkCyan
                            End If
                            If Not IsNothing(registro.PCheck_Excepcion.Pregexc_motivo) Then
                                If registro.PCheck_Excepcion.Pregexc_motivo.Pexmot_motivo_laboral = True Then
                                    grdControlAsistencia.Rows(iterador).Cells(18).Style.ForeColor = Color.DeepSkyBlue
                                Else
                                    grdControlAsistencia.Rows(iterador).Cells(18).Style.ForeColor = Color.Blue
                                End If
                            End If

                        End If
                    End If

                End If

                iterador += 1

            Next

        Next

        inasistencias()
        redibujar_Resumen()
        incentivos_Registro_Excepcion(cboxPeriodo.SelectedValue)
        ocultar_columnas_vacias()

    End Sub

    Public Sub inasistencias()

        Dim filas As Integer = grdControlAsistencia.Rows.Count
        Dim i As Integer

        Dim noRegistroDia As Double
        Dim registro As Double

        Dim vacio As Double

        Dim faltas As Double
        Dim asistencias As Double

        For i = 0 To filas - 4

            grdControlAsistencia.Rows(i + 3).Cells(20).Value = 0

            For Each col As DataGridViewColumn In grdControlAsistencia.Columns

                If col.Index = 6 Or col.Index = 8 Or col.Index = 10 Or col.Index = 12 Or col.Index = 14 Or col.Index = 16 Or col.Index = 18 Then

                    noRegistroDia = 0
                    registro = 0
                    vacio = 0

                    If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(i).Cells(col.Index).Value) Then
                        vacio += 1
                    ElseIf grdControlAsistencia.Rows(i).Cells(col.Index).Value.Equals("NO REGISTRO") Then
                        noRegistroDia += 1
                        grdControlAsistencia.Rows(i + 3).Cells(21).Value = False
                        grdControlAsistencia.Rows(i + 1).Cells(21).Value = False
                    Else
                        registro += 1
                    End If

                    If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(i + 1).Cells(col.Index).Value) Then
                        vacio += 1
                    ElseIf grdControlAsistencia.Rows(i + 1).Cells(col.Index).Value.Equals("NO REGISTRO") Then
                        noRegistroDia += 1
                        grdControlAsistencia.Rows(i + 3).Cells(21).Value = False
                        grdControlAsistencia.Rows(i + 1).Cells(21).Value = False
                    Else
                        registro += 1
                    End If

                    If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(i + 2).Cells(col.Index).Value) Then
                        vacio += 1
                    ElseIf grdControlAsistencia.Rows(i + 2).Cells(col.Index).Value.Equals("NO REGISTRO") Then
                        noRegistroDia += 1
                        grdControlAsistencia.Rows(i + 3).Cells(21).Value = False
                        grdControlAsistencia.Rows(i + 1).Cells(21).Value = False
                    Else
                        registro += 1
                    End If

                    If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(i + 3).Cells(col.Index).Value) Then
                        vacio += 1
                    ElseIf grdControlAsistencia.Rows(i + 3).Cells(col.Index).Value.Equals("NO REGISTRO") Then
                        noRegistroDia += 1
                        grdControlAsistencia.Rows(i + 3).Cells(21).Value = False
                        grdControlAsistencia.Rows(i + 1).Cells(21).Value = False
                    Else
                        registro += 1
                    End If

                    If vacio <> 4 Then ''VERIFICA QUE EL DIA TENGA ALGUN REGISTRO

                        If noRegistroDia > 0 And noRegistroDia < 5 Then

                            If noRegistroDia = 4 Or noRegistroDia + vacio = 4 Then
                                faltas += 1
                                grdControlAsistencia.Rows(i + 3).Cells(20).Value = faltas
                            Else

                                If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(i).Cells(col.Index).Value) Then
                                ElseIf grdControlAsistencia.Rows(i).Cells(col.Index).Value.Equals("NO REGISTRO") Then
                                    If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(i + 1).Cells(col.Index).Value) Then
                                        faltas += 0.5
                                        grdControlAsistencia.Rows(i + 3).Cells(20).Value = faltas

                                        If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(i + 2).Cells(col.Index).Value) And _
                                            String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(i + 3).Cells(col.Index).Value) Then
                                            faltas += 0.5
                                            grdControlAsistencia.Rows(i + 3).Cells(20).Value = faltas
                                        End If

                                    ElseIf grdControlAsistencia.Rows(i + 1).Cells(col.Index).Value.Equals("NO REGISTRO") Then
                                        faltas += 0.5
                                        grdControlAsistencia.Rows(i + 3).Cells(20).Value = faltas
                                    End If
                                End If

                                If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(i + 2).Cells(col.Index).Value) Then
                                    If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(i + 3).Cells(col.Index).Value) Then
                                    ElseIf grdControlAsistencia.Rows(i + 3).Cells(col.Index).Value.Equals("NO REGISTRO") Then
                                        faltas += 0.5
                                        grdControlAsistencia.Rows(i + 3).Cells(20).Value = faltas
                                    End If
                                ElseIf grdControlAsistencia.Rows(i + 2).Cells(col.Index).Value.Equals("NO REGISTRO") Then
                                    If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(i + 3).Cells(col.Index).Value) Then
                                        faltas += 0.5
                                        grdControlAsistencia.Rows(i + 3).Cells(20).Value = faltas
                                    ElseIf grdControlAsistencia.Rows(i + 3).Cells(col.Index).Value.Equals("NO REGISTRO") Then
                                        faltas += 0.5
                                        grdControlAsistencia.Rows(i + 3).Cells(20).Value = faltas
                                    End If
                                End If

                            End If
                            If registro = 4 Or registro + vacio = 4 Then
                                asistencias += 1
                            Else
                                If (registro > 0 And registro < 4) And (faltas > 0 And faltas < 1) Then
                                    asistencias += 0.5
                                End If
                            End If
                        Else ''NO TIENE "NO REGISTROS"

                            If registro = 4 Or registro + vacio = 4 Then
                                asistencias += 1
                            Else
                                If (registro > 0 And registro < 4) And (faltas > 0 And faltas < 1) Then
                                    asistencias += 0.5
                                End If
                            End If

                        End If

                    End If

                End If

            Next

            grdControlAsistencia.Rows(i).Cells(28).Value = asistencias

            'If grdControlAsistencia.Rows(i).Cells(28).Value = 6 Then
            '    grdControlAsistencia.Rows(i).Cells(28).Value += 1
            'End If

            If grdControlAsistencia.Rows(i + 3).Cells(20).Value > 0 Then

                grdControlAsistencia.Rows(i + 3).Cells(21).Value = False
                grdControlAsistencia.Rows(i + 1).Cells(21).Value = False

            End If

            asistencias = 0
            faltas = 0
            vacio = 0

            i += 3

        Next

    End Sub

    Public Sub redibujar_Resumen()

        For Each row As DataGridViewRow In grdControlAsistencia.Rows

            If grdControlAsistencia.Rows(row.Index).Cells(19).Value.Equals("Permisos") Then
                grdControlAsistencia.Rows(row.Index).Cells(22).Value = grdControlAsistencia.Rows(row.Index).Cells(20).Value
            End If

            If grdControlAsistencia.Rows(row.Index).Cells(19).Value.Equals("Retardo menor") Then
                grdControlAsistencia.Rows(row.Index - 1).Cells(23).Value = grdControlAsistencia.Rows(row.Index).Cells(20).Value
            End If

            If grdControlAsistencia.Rows(row.Index).Cells(19).Value.Equals("Retardo mayor") Then
                grdControlAsistencia.Rows(row.Index - 2).Cells(24).Value = grdControlAsistencia.Rows(row.Index).Cells(20).Value
            End If

            If grdControlAsistencia.Rows(row.Index).Cells(19).Value.Equals("Inasistencias") Then
                grdControlAsistencia.Rows(row.Index - 3).Cells(25).Value = grdControlAsistencia.Rows(row.Index).Cells(20).Value
            End If


            If grdControlAsistencia.Rows(row.Index).Cells(21).Value.Equals("Puntualidad y asistenica") Then
                grdControlAsistencia.Rows(row.Index).Cells(26).Value = grdControlAsistencia.Rows(row.Index + 1).Cells(21).Value

                If grdControlAsistencia.Rows(row.Index + 1).Cells(21).Value Then

                    grdControlAsistencia.Rows(row.Index).Cells(26).Style.BackColor = Color.Green
                    grdControlAsistencia.Rows(row.Index).Cells(26).Style.ForeColor = Color.Green

                Else

                    grdControlAsistencia.Rows(row.Index).Cells(26).Style.BackColor = Color.Maroon
                    grdControlAsistencia.Rows(row.Index).Cells(26).Style.ForeColor = Color.Maroon
                End If

            End If


            If grdControlAsistencia.Rows(row.Index).Cells(21).Value.Equals("Caja de ahorro") Then
                Try
                    grdControlAsistencia.Rows(row.Index - 2).Cells(27).Value = grdControlAsistencia.Rows(row.Index + 1).Cells(21).Value

                    If grdControlAsistencia.Rows(row.Index + 1).Cells(21).Value Then

                        grdControlAsistencia.Rows(row.Index - 2).Cells(27).Style.BackColor = Color.Green
                        grdControlAsistencia.Rows(row.Index - 2).Cells(27).Style.ForeColor = Color.Green

                    Else
                        grdControlAsistencia.Rows(row.Index - 2).Cells(27).Style.BackColor = Color.Maroon
                        grdControlAsistencia.Rows(row.Index - 2).Cells(27).Style.ForeColor = Color.Maroon

                    End If
                Catch ex As Exception

                End Try


            End If

        Next

    End Sub

    Public Sub incentivos_Registro_Excepcion(ByVal PeriodoNomID As Integer)

        Dim filas As Integer = grdControlAsistencia.Rows.Count
        Dim i As Integer

        For i = 0 To filas - 4


            Dim corteChecadorBU As New Negocios.CorteChecadorBU
            Dim incentivos As New List(Of Boolean)

            incentivos = corteChecadorBU.Consultar_Incentivos_Registro_Excepcion(PeriodoNomID, CInt(grdControlAsistencia.Rows(i).Cells(1).Value))


            If incentivos.Item(0) Then

                'grdControlAsistencia.Rows(i).Cells(26).Value = True

                'grdControlAsistencia.Rows(i).Cells(26).Style.BackColor = Color.Green
                'grdControlAsistencia.Rows(i).Cells(26).Style.ForeColor = Color.Green
            Else
                grdControlAsistencia.Rows(i).Cells(26).Value = False

                grdControlAsistencia.Rows(i).Cells(26).Style.BackColor = Color.Maroon
                grdControlAsistencia.Rows(i).Cells(26).Style.ForeColor = Color.Maroon
            End If

            If incentivos.Item(1) Then

                'grdControlAsistencia.Rows(i).Cells(27).Value = True

                'grdControlAsistencia.Rows(i).Cells(27).Style.BackColor = Color.Green
                'grdControlAsistencia.Rows(i).Cells(27).Style.ForeColor = Color.Green

            Else
                grdControlAsistencia.Rows(i).Cells(27).Value = False

                grdControlAsistencia.Rows(i).Cells(27).Style.BackColor = Color.Maroon
                grdControlAsistencia.Rows(i).Cells(27).Style.ForeColor = Color.Maroon
            End If

            i += 3

        Next

    End Sub

    Public Sub ocultar_columnas_vacias()

        Dim isEmpty As Boolean
        For Each col As DataGridViewColumn In grdControlAsistencia.Columns

            For Each row As DataGridViewRow In grdControlAsistencia.Rows

                If IsNothing(grdControlAsistencia.Rows(row.Index).Cells(col.Index).Value) Then

                    isEmpty = True

                Else
                    isEmpty = False
                    Exit For
                End If

            Next
            If isEmpty Then
                grdControlAsistencia.Columns(col.Index).Visible = False
            Else
                'gridControlAsistencia.Columns(col.Index).Visible = True
            End If
        Next

    End Sub

    Public Sub asiganar_fecha_cabeceraGrid(periodoRango As Entidades.PeriodosNomina)

        Dim dia As Integer = periodoRango.FechaInicio.DayOfWeek

        If dia = 1 Then
            Try
                clmLunes.HeaderText = "Lunes" + vbCr + periodoRango.FechaInicio.ToShortDateString
                clmMartes.HeaderText = "Martes" + vbCr + periodoRango.FechaInicio.AddDays(1).ToShortDateString
                clmMiercoles.HeaderText = "Miércoles" + vbCr + periodoRango.FechaInicio.AddDays(2).ToShortDateString
                clmJueves.HeaderText = "Jueves" + vbCr + periodoRango.FechaInicio.AddDays(3).ToShortDateString
                clmViernes.HeaderText = "Viernes" + vbCr + periodoRango.FechaInicio.AddDays(4).ToShortDateString
                clmSabado.HeaderText = "Sábado" + vbCr + periodoRango.FechaInicio.AddDays(5).ToShortDateString
                clmDomingo.HeaderText = "Domingo" + vbCr + periodoRango.FechaFin.ToShortDateString

                fLunes = periodoRango.FechaInicio.ToShortDateString
                fMartes = periodoRango.FechaInicio.AddDays(1).ToShortDateString
                fMiercoles = periodoRango.FechaInicio.AddDays(2).ToShortDateString
                fJueves = periodoRango.FechaInicio.AddDays(3).ToShortDateString
                fViernes = periodoRango.FechaInicio.AddDays(4).ToShortDateString
                fSabado = periodoRango.FechaInicio.AddDays(5).ToShortDateString
                fDomingo = periodoRango.FechaFin.ToShortDateString

            Catch ex As Exception
            End Try
        End If

        If dia = 2 Then
            Try
                clmLunes.HeaderText = "Lunes" + vbCr + periodoRango.FechaFin.ToShortDateString
                clmMartes.HeaderText = "Martes" + vbCr + periodoRango.FechaInicio.ToShortDateString
                clmMiercoles.HeaderText = "Miércoles" + vbCr + periodoRango.FechaInicio.AddDays(1).ToShortDateString
                clmJueves.HeaderText = "Jueves" + vbCr + periodoRango.FechaInicio.AddDays(2).ToShortDateString
                clmViernes.HeaderText = "Viernes" + vbCr + periodoRango.FechaInicio.AddDays(3).ToShortDateString
                clmSabado.HeaderText = "Sábado" + vbCr + periodoRango.FechaInicio.AddDays(4).ToShortDateString
                clmDomingo.HeaderText = "Domingo" + vbCr + periodoRango.FechaInicio.AddDays(5).ToShortDateString

                fLunes = periodoRango.FechaFin.ToShortDateString
                fMartes = periodoRango.FechaInicio.ToShortDateString
                fMiercoles = periodoRango.FechaInicio.AddDays(1).ToShortDateString
                fJueves = periodoRango.FechaInicio.AddDays(2).ToShortDateString
                fViernes = periodoRango.FechaInicio.AddDays(3).ToShortDateString
                fSabado = periodoRango.FechaInicio.AddDays(4).ToShortDateString()
                fDomingo = periodoRango.FechaInicio.AddDays(5).ToShortDateString
            Catch ex As Exception
            End Try
        End If

        If dia = 3 Then
            Try
                clmLunes.HeaderText = "Lunes" + vbCr + periodoRango.FechaFin.AddDays(-1).ToShortDateString
                clmMartes.HeaderText = "Martes" + vbCr + periodoRango.FechaFin.ToShortDateString
                clmMiercoles.HeaderText = "Miércoles" + vbCr + periodoRango.FechaInicio.ToShortDateString
                clmJueves.HeaderText = "Jueves" + vbCr + periodoRango.FechaInicio.AddDays(1).ToShortDateString
                clmViernes.HeaderText = "Viernes" + vbCr + periodoRango.FechaInicio.AddDays(2).ToShortDateString
                clmSabado.HeaderText = "Sábado" + vbCr + periodoRango.FechaInicio.AddDays(3).ToShortDateString
                clmDomingo.HeaderText = "Domingo" + vbCr + periodoRango.FechaInicio.AddDays(4).ToShortDateString

                fLunes = periodoRango.FechaFin.AddDays(-1).ToShortDateString
                fMartes = periodoRango.FechaFin.ToShortDateString
                fMiercoles = periodoRango.FechaInicio.ToShortDateString
                fJueves = periodoRango.FechaInicio.AddDays(1).ToShortDateString
                fViernes = periodoRango.FechaInicio.AddDays(2).ToShortDateString
                fSabado = periodoRango.FechaInicio.AddDays(3).ToShortDateString
                fDomingo = periodoRango.FechaInicio.AddDays(4).ToShortDateString
            Catch ex As Exception
            End Try
        End If

        If dia = 4 Then
            Try
                clmLunes.HeaderText = "Lunes" + vbCr + periodoRango.FechaFin.AddDays(-2).ToShortDateString
                clmMartes.HeaderText = "Martes" + vbCr + periodoRango.FechaFin.AddDays(-1).ToShortDateString
                clmMiercoles.HeaderText = "Miércoles" + vbCr + periodoRango.FechaFin.ToShortDateString
                clmJueves.HeaderText = "Jueves" + vbCr + periodoRango.FechaInicio.ToShortDateString
                clmViernes.HeaderText = "Viernes" + vbCr + periodoRango.FechaInicio.AddDays(1).ToShortDateString
                clmSabado.HeaderText = "Sábado" + vbCr + periodoRango.FechaInicio.AddDays(2).ToShortDateString
                clmDomingo.HeaderText = "Domingo" + vbCr + periodoRango.FechaInicio.AddDays(3).ToShortDateString

                fLunes = periodoRango.FechaFin.AddDays(-2).ToShortDateString
                fMartes = periodoRango.FechaFin.AddDays(-1).ToShortDateString
                fMiercoles = periodoRango.FechaFin.ToShortDateString
                fJueves = periodoRango.FechaInicio.ToShortDateString
                fViernes = periodoRango.FechaInicio.AddDays(1).ToShortDateString
                fSabado = periodoRango.FechaInicio.AddDays(2).ToShortDateString
                fDomingo = periodoRango.FechaInicio.AddDays(3).ToShortDateString
            Catch ex As Exception
            End Try
        End If

        If dia = 5 Then
            Try
                clmLunes.HeaderText = "Lunes" + vbCr + periodoRango.FechaFin.AddDays(-3).ToShortDateString
                clmMartes.HeaderText = "Martes" + vbCr + periodoRango.FechaFin.AddDays(-2).ToShortDateString
                clmMiercoles.HeaderText = "Miércoles" + vbCr + periodoRango.FechaFin.AddDays(-1).ToShortDateString
                clmJueves.HeaderText = "Jueves" + vbCr + periodoRango.FechaFin.ToShortDateString
                clmViernes.HeaderText = "Viernes" + vbCr + periodoRango.FechaInicio.ToShortDateString
                clmSabado.HeaderText = "Sábado" + vbCr + periodoRango.FechaInicio.AddDays(1).ToShortDateString
                clmDomingo.HeaderText = "Domingo" + vbCr + periodoRango.FechaInicio.AddDays(2).ToShortDateString

                fLunes = periodoRango.FechaFin.AddDays(-3).ToShortDateString
                fMartes = periodoRango.FechaFin.AddDays(-2).ToShortDateString
                fMiercoles = periodoRango.FechaFin.AddDays(-1).ToShortDateString
                fJueves = periodoRango.FechaFin.ToShortDateString
                fViernes = periodoRango.FechaInicio.ToShortDateString
                fSabado = periodoRango.FechaInicio.AddDays(1).ToShortDateString
                fDomingo = periodoRango.FechaInicio.AddDays(2).ToShortDateString
            Catch ex As Exception
            End Try
        End If

        If dia = 6 Then
            Try
                clmLunes.HeaderText = "Lunes" + vbCr + periodoRango.FechaFin.AddDays(-4).ToShortDateString
                clmMartes.HeaderText = "Martes" + vbCr + periodoRango.FechaFin.AddDays(-3).ToShortDateString
                clmMiercoles.HeaderText = "Miércoles" + vbCr + periodoRango.FechaFin.AddDays(-2).ToShortDateString
                clmJueves.HeaderText = "Jueves" + vbCr + periodoRango.FechaFin.AddDays(-1).ToShortDateString
                clmViernes.HeaderText = "Viernes" + vbCr + periodoRango.FechaFin.ToShortDateString
                clmSabado.HeaderText = "Sábado" + vbCr + periodoRango.FechaInicio.ToShortDateString
                clmDomingo.HeaderText = "Domingo" + vbCr + periodoRango.FechaInicio.AddDays(1).ToShortDateString

                fLunes = periodoRango.FechaFin.AddDays(-4).ToShortDateString
                fMartes = periodoRango.FechaFin.AddDays(-3).ToShortDateString
                fMiercoles = periodoRango.FechaFin.AddDays(-2).ToShortDateString
                fJueves = periodoRango.FechaFin.AddDays(-1).ToShortDateString
                fViernes = periodoRango.FechaFin.ToShortDateString
                fSabado = periodoRango.FechaInicio.ToShortDateString
                fDomingo = periodoRango.FechaInicio.AddDays(1).ToShortDateString
            Catch ex As Exception
            End Try
        End If

        If dia = 0 Then
            Try
                clmLunes.HeaderText = "Lunes" + vbCr + periodoRango.FechaFin.AddDays(-5).ToShortDateString
                clmMartes.HeaderText = "Martes" + vbCr + periodoRango.FechaFin.AddDays(-4).ToShortDateString
                clmMiercoles.HeaderText = "Miércoles" + vbCr + periodoRango.FechaFin.AddDays(-3).ToShortDateString
                clmJueves.HeaderText = "Jueves" + vbCr + periodoRango.FechaFin.AddDays(-2).ToShortDateString
                clmViernes.HeaderText = "Viernes" + vbCr + periodoRango.FechaFin.AddDays(-1).ToShortDateString
                clmSabado.HeaderText = "Sábado" + vbCr + periodoRango.FechaFin.ToShortDateString
                clmDomingo.HeaderText = "Domingo" + vbCr + periodoRango.FechaInicio.ToShortDateString

                fLunes = periodoRango.FechaFin.AddDays(-5).ToShortDateString
                fMartes = periodoRango.FechaFin.AddDays(-4).ToShortDateString
                fMiercoles = periodoRango.FechaFin.AddDays(-3).ToShortDateString
                fJueves = periodoRango.FechaFin.AddDays(-2).ToShortDateString
                fViernes = periodoRango.FechaFin.AddDays(-1).ToShortDateString
                fSabado = periodoRango.FechaFin.ToShortDateString
                fDomingo = periodoRango.FechaInicio.ToShortDateString
            Catch ex As Exception
            End Try
        End If

    End Sub

    Public Function validar_puntualidad_asistencia(ByVal naveid As Integer, ByVal periodoID As Integer, ByVal colaboradorID As Integer) As Boolean

        'Dim objBU As New Framework.Negocios.ConfiguracionAsistenciaBU
        '      Dim listaConfiguracionAsistencia As New List(Of Entidades.ConfiguracionAsistencia)
        Dim corteChecadorBU As New Negocios.CorteChecadorBU
        Dim resultadoResumenChecador As Integer

        '        listaConfiguracionAsistencia = objBU.listaConfiguracionAsistencia(naveid)

        resultadoResumenChecador = corteChecadorBU.consultar_ResumenCorteChecador _
                                               (periodoID, colaboradorID, 0, 3)

        Dim objE As Entidades.ConfiguracionAsistencia = _
               listaConfiguracionAsistencia.Find(Function(c) c.PResultadoCheck = 2)


        If resultadoResumenChecador <= objE.PRango Then
            Return True
        Else
            Return False
        End If


    End Function

    Public Sub guardar_CorteChecador()

        Dim corteChecadorE As New Entidades.CorteChecador
        Dim colaborador As New Entidades.Colaborador
        Dim periodoNomina As New Entidades.PeriodosNomina
        Dim objBU As New Negocios.CorteChecadorBU

        periodoNomina.PeriodoId = cboxPeriodo.SelectedValue
        corteChecadorE.PPeriodo = periodoNomina
        Try

            For Each row As DataGridViewRow In grdControlAsistencia.Rows

                If CInt(row.Cells(3).Value) = 1 Then

                    colaborador.PColaboradorid = CInt(row.Cells(1).Value)
                    corteChecadorE.PColaborador = colaborador

                    corteChecadorE.PRetardo_menor = CInt(row.Cells(23).Value)
                    corteChecadorE.PRetardo_mayor = CInt(row.Cells(24).Value)
                    corteChecadorE.PInasistencia = CDbl(row.Cells(25).Value)
                    corteChecadorE.PPpuntualidad_asistencia = CBool(row.Cells(26).Value)
                    corteChecadorE.PCaja_Ahorro = CBool(row.Cells(27).Value)
                    corteChecadorE.PAsistencia = CDbl(row.Cells(28).Value)

                    objBU.guardarCorteChecador(corteChecadorE, 0)

                End If

            Next

            show_message("Exito", "Periodo de asistencia cerrado con éxito")

            enviar_correo(cboxNave.SelectedValue, "ENVIO_CORTE_CHECADOR")

            'cboxNave.DataSource = Nothing
            'cboxNave.SelectedItem = 0
            cboxDepartamento.DataSource = Nothing
            cboxDepartamento.SelectedItem = 0
            cboxColaborador.DataSource = Nothing
            cboxColaborador.SelectedItem = 0
            cboxPeriodo.DataSource = Nothing
            cboxPeriodo.SelectedItem = 0

            grdControlAsistencia.Rows.Clear()

        Catch ex As Exception

            show_message("Aviso", "Algo surgio mal durante la operación")

        End Try

    End Sub

    Private Sub enviar_correo(ByVal naveID As Integer, ByVal clave As String)

        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String
        Dim correo As New Tools.Correo
        destinatarios = enviosCorreoBU.consulta_destinatarios_email(naveID, clave)


        Dim Email As String = "<html>" +
                                    "<head>" +
                                        "<style type ='" + "text/css" + "'> body {display: block; margin: 8px; background: #FFFFFF;color: #003366;	font-family: Arial, Helvetica, sans-serif;	font-size: 18px;	font-weight: bold;}#header{	position: fixed;	height: 62px;	top: 0;	left: 0;	right: 0;	color: #003366;	font-family: Arial, Helvetica, sans-serif;	font-size: 18px;	font-weight: bold;}#leftcolumn{	float: left;	position: fixed;	width: 2%;	margin: 1%;	padding-top: 3%;	top: 0;	left: 0;	right: 0;}#content{	width: 90%;	position: fixed;	margin: 1% 5%;		padding-top: 3%;	padding-bottom: 1%;}#rightcolumn{	float: right;	width: 5%;	margin: 1%;			padding-top: 3%;}#footer{	position: fixed;	width: 100%;	heigt: 5%;	bottom: 0;	margin: 0;	padding: 0;	color: #003366;	font-family: Arial, Helvetica, sans-serif;	font-size: 12px;	font-weight: bold;}table.tableizer-table { 	font-family: Arial, Helvetica, sans-serif;	font-size: 9px;} .tableizer-table td {	padding: 4px;	margin: 0px;	border: 1px solid #FFFFFF;	border-color: #FFFFFF;	border: 1px solid #CCCCCC;	width: 200px;} .tableizer-table tr {	padding: 4px;	margin: 0;	color: #003366;	font-weight: bold;	background-color: #transparent; 	opacity: 1;}.tableizer-table th {	background-color: #003366; 	color: #FFFFFF;	font-weight: bold;	height: 30px;	font-size: 10px;}A:link {	text-decoration:none;color:#FFFFFF;} A:visited {	text-decoration:none;color:#FFFFFF;} A:active {	text-decoration:none;color:#FFFFFF;} A:hover {	text-decoration:none;color:#006699;} </style>" +
                                    "</head>" +
                                    "<body>" +
                                        "<div id='" + "wrapper" + "'>" +
                                            "<div id='" + "header" + "'>" +
                                                "<img src='" + "http://grupoyuyin.com.mx/images/SAY170.jpg" + "'style='" + "vertical-align:middle" + "' height='" + "57" + "' widht='" + "125" + "'> Periodo de asistencia " + cboxPeriodo.SelectedText +
                                            "</div>" +
                                            "<div id='" + "leftcolumn" + "'>" +
                                            "</div>" +
                                            "<div id='" + "rightcolumn" + "'>" +
                                            "</div>" +
                                            "<div id='" + "content" + "'>" +
                                                "<p>Se ha realizado el cierre del periodo por: " + Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString + "</p>" +
                                            "<div id='" + "footer" + "'>" +
                                                "<p>Realizado: " + Now.ToLongDateString + " " + Now.ToLongTimeString + "</p>" +
                                            "</div>" +
                                        "</div>" +
                                    "</body>" +
                                "</html>"

        correo.EnviarCorreoHtml(destinatarios, "checador@grupoyuyin.com.mx", "Corte de checador", Email)

    End Sub

    Private Sub cboxNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxNave.DropDownClosed

        cboxDepartamento.DataSource = Nothing
        cboxColaborador.DataSource = Nothing
        listado_areas()
        listado_periodos_asistencia()

    End Sub

    Private Sub cmbArea_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.DropDownClosed

        cboxDepartamento.DataSource = Nothing
        cboxColaborador.DataSource = Nothing
        listado_departamentos()

    End Sub

    Private Sub cboxDepartamento_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxDepartamento.DropDownClosed

        cboxColaborador.DataSource = Nothing
        listado_celulas()
        If cboxCelula.Items.Count = 1 Then
            listado_colaboradores()
        End If

    End Sub

    Private Sub cboxCelula_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxCelula.DropDownClosed

        cboxColaborador.DataSource = Nothing
        listado_colaboradores()

    End Sub

    Public Sub gridControlAsistencia_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdControlAsistencia.CellMouseClick

        If grdControlAsistencia.CurrentCell.IsInEditMode Then Return

        If e.Button <> Windows.Forms.MouseButtons.Right Then Return

        Dim cms = New ContextMenuStrip

        If IsPeriodoEditable Then

            If e.RowIndex >= 0 And (e.ColumnIndex >= 4 And e.ColumnIndex <= 18) Then

                If grdControlAsistencia.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected Then

                    If IsNothing(grdControlAsistencia.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Or IsDBNull(grdControlAsistencia.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then

                    Else

                        Dim item1 = cms.Items.Add("Insertar registro manual")
                        item1.Tag = 1
                        AddHandler item1.Click, AddressOf menuChoice

                        Dim objRegistroExcepciones As New RegistroExcepcionesAltaForm
                        objRegistroExcepciones.registroCheckID = CInt(grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells((grdControlAsistencia.CurrentCell.ColumnIndex) - 1).Value)
                        objRegistroExcepciones.naveID = naveID

                        Dim objBU As New Negocios.RegistroCheckBU
                        Dim listaRegistroCheck As New List(Of Entidades.RegistroCheck)
                        listaRegistroCheck = objBU.buscar_DetalleRegistroCheck(objRegistroExcepciones.registroCheckID, naveID)

                        Dim objE As Entidades.RegistroCheck = _
                            listaRegistroCheck.Find(Function(c) c.PId = objRegistroExcepciones.registroCheckID And c.Pregcheck_nave.PNaveId = naveID)

                        If IsNothing(objE.PCheck_Excepcion.Pregexc_id) Or objE.PCheck_Excepcion.Pregexc_id = 0 Then
                            Dim item2 = cms.Items.Add("Insertar permiso")
                            item2.Tag = 2
                            AddHandler item2.Click, AddressOf menuChoice

                        Else
                            Dim item3 = cms.Items.Add("Revisar permiso")
                            item3.Tag = 3
                            AddHandler item3.Click, AddressOf menuChoice
                        End If

                        cms.Show(Control.MousePosition)

                    End If

                End If

            End If
        Else
            If e.RowIndex >= 0 And (e.ColumnIndex >= 4 And e.ColumnIndex <= 18) Then

                If grdControlAsistencia.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected Then

                    If IsNothing(grdControlAsistencia.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Or IsDBNull(grdControlAsistencia.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then

                    Else

                        Dim objRegistroExcepciones As New RegistroExcepcionesAltaForm
                        objRegistroExcepciones.registroCheckID = CInt(grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells((grdControlAsistencia.CurrentCell.ColumnIndex) - 1).Value)
                        objRegistroExcepciones.naveID = naveID

                        Dim objBU As New Negocios.RegistroCheckBU
                        Dim listaRegistroCheck As New List(Of Entidades.RegistroCheck)
                        listaRegistroCheck = objBU.buscar_DetalleRegistroCheck(objRegistroExcepciones.registroCheckID, naveID)

                        Dim objE As Entidades.RegistroCheck = _
                            listaRegistroCheck.Find(Function(c) c.PId = objRegistroExcepciones.registroCheckID And c.Pregcheck_nave.PNaveId = naveID)

                        If IsNothing(objE.PCheck_Excepcion.Pregexc_id) Or objE.PCheck_Excepcion.Pregexc_id = 0 Then

                        Else
                            Dim item3 = cms.Items.Add("Revisar permiso")
                            item3.Tag = 3
                            AddHandler item3.Click, AddressOf menuChoice
                        End If

                        cms.Show(Control.MousePosition)

                    End If

                End If

            End If
        End If

    End Sub

    Private Sub menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        Dim regcheckID As Integer
        If selection = 1 Then

            If IsPeriodoEditable Then

                If grdControlAsistencia.CurrentCell.RowIndex >= 0 And (grdControlAsistencia.CurrentCell.ColumnIndex >= 4 And grdControlAsistencia.CurrentCell.ColumnIndex <= 18) Then

                    If grdControlAsistencia.CurrentCell.Selected Then

                        Dim row, col As Integer

                        If IsNothing(grdControlAsistencia.CurrentCell.Value) Or IsDBNull(grdControlAsistencia.CurrentCell.Value) Then

                        Else

                            Dim objRegistroManual As New RegistroManualForm
                            objRegistroManual.naveID = naveID
                            objRegistroManual.colaboradorID = CInt(grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells(1).Value)
                            If grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells(grdControlAsistencia.CurrentCell.ColumnIndex).Style.ForeColor = Color.Black _
                                Or grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells(grdControlAsistencia.CurrentCell.ColumnIndex).Style.ForeColor = Color.Goldenrod _
                                Or grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells(grdControlAsistencia.CurrentCell.ColumnIndex).Style.ForeColor = Color.DarkOrange _
                                Or grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells(grdControlAsistencia.CurrentCell.ColumnIndex).Style.ForeColor = Color.DarkCyan _
                                Or grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells(grdControlAsistencia.CurrentCell.ColumnIndex).Style.ForeColor = Color.DeepSkyBlue _
                                Or grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells(grdControlAsistencia.CurrentCell.ColumnIndex).Style.ForeColor = Color.Maroon Then

                                objRegistroManual.registroCheckNormal = True
                                regcheckID = CInt(grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells((grdControlAsistencia.CurrentCell.ColumnIndex) - 1).Value)
                                objRegistroManual.registroCheckID.Add(regcheckID)
                            End If

                            If grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells(grdControlAsistencia.CurrentCell.ColumnIndex).Style.ForeColor = Color.Blue Then
                                If CInt(grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells(3).Value) = 1 _
                                Or CInt(grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells(3).Value) = 3 Then

                                    regcheckID = CInt(grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells((grdControlAsistencia.CurrentCell.ColumnIndex) - 1).Value)
                                    objRegistroManual.registroCheckID.Add(regcheckID)
                                    regcheckID = CInt(grdControlAsistencia.Rows((grdControlAsistencia.CurrentCell.RowIndex + 1)).Cells((grdControlAsistencia.CurrentCell.ColumnIndex) - 1).Value)
                                    objRegistroManual.registroCheckID.Add(regcheckID)

                                End If

                                If CInt(grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells(3).Value) = 2 _
                                    Or CInt(grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells(3).Value) = 4 Then

                                    objRegistroManual.registroCheckID.Add(CInt(grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells((grdControlAsistencia.CurrentCell.ColumnIndex) - 1).Value))
                                    objRegistroManual.registroCheckID.Add(CInt(grdControlAsistencia.Rows((grdControlAsistencia.CurrentCell.RowIndex - 1)).Cells((grdControlAsistencia.CurrentCell.ColumnIndex) - 1).Value))

                                End If
                            End If

                            If grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells(grdControlAsistencia.CurrentCell.ColumnIndex).Style.ForeColor = Color.DarkGreen Then
                                Try
                                    objRegistroManual.registroCheckNormal = True
                                    regcheckID = CInt(grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells((grdControlAsistencia.CurrentCell.ColumnIndex) - 1).Value)
                                    objRegistroManual.registroCheckID.Add(regcheckID)

                                Catch ex As Exception

                                End Try

                            End If

                            Dim rowResumen As Integer

                            row = CInt(grdControlAsistencia.CurrentCell.RowIndex)
                            If CInt(grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells(3).Value) = 1 Then
                                rowResumen = CInt(grdControlAsistencia.CurrentCell.RowIndex)
                            End If
                            If CInt(grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells(3).Value) = 2 Then
                                rowResumen = CInt(grdControlAsistencia.CurrentCell.RowIndex - 1)
                            End If
                            If CInt(grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells(3).Value) = 3 Then
                                rowResumen = CInt(grdControlAsistencia.CurrentCell.RowIndex - 2)
                            End If
                            If CInt(grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells(3).Value) = 4 Then
                                rowResumen = CInt(grdControlAsistencia.CurrentCell.RowIndex - 3)
                            End If

                            col = CInt(grdControlAsistencia.CurrentCell.ColumnIndex)
                            objRegistroManual.ShowDialog()

                            If objRegistroManual.DialogResult = Windows.Forms.DialogResult.OK Then

                                If objRegistroManual.rbtnNoRegistro.Checked Then
                                    grdControlAsistencia.Rows(row).Cells(col).Value = "NO REGISTRO"
                                    grdControlAsistencia.Rows(row).Cells(col).ToolTipText = "Registro manual: " + vbCr + "Nota: " + objRegistroManual.txtNota.Text
                                    grdControlAsistencia.Rows(row).Cells(col).Style.ForeColor = Color.Maroon
                                Else
                                    grdControlAsistencia.Rows(row).Cells(col).Value = objRegistroManual.dtpRegistroManual.Value.ToLongTimeString
                                End If

                                If objRegistroManual.rbtnRetardoMayor.Checked Then
                                    grdControlAsistencia.Rows(rowResumen).Cells(24).Value = grdControlAsistencia.Rows(rowResumen).Cells(24).Value + 1
                                    grdControlAsistencia.Rows(row).Cells(col).Style.ForeColor = Color.DarkGreen
                                    grdControlAsistencia.Rows(row).Cells(col).ToolTipText = "Retardo mayor" + vbCr + "Nota: " + objRegistroManual.txtNota.Text
                                End If
                                If objRegistroManual.rbtnRetardoMenor.Checked Then
                                    grdControlAsistencia.Rows(rowResumen).Cells(23).Value = grdControlAsistencia.Rows(rowResumen).Cells(23).Value + 1
                                    grdControlAsistencia.Rows(row).Cells(col).Style.ForeColor = Color.DarkGreen
                                    grdControlAsistencia.Rows(row).Cells(col).ToolTipText = "Retardo menor" + vbCr + "Nota: " + objRegistroManual.txtNota.Text
                                End If

                                grdControlAsistencia.Rows(row).Cells(col).Style.BackColor = Color.PaleGreen

                            End If

                        End If

                    End If

                End If

            End If

        End If

        If selection = 2 Then

            If IsPeriodoEditable Then

                If grdControlAsistencia.CurrentCell.RowIndex >= 0 And grdControlAsistencia.CurrentCell.ColumnIndex >= 4 Then

                    If grdControlAsistencia.CurrentCell.Selected Then

                        Dim row, col As Integer

                        If IsNothing(grdControlAsistencia.CurrentCell.Value) Or IsDBNull(grdControlAsistencia.CurrentCell.Value) Then

                        Else

                            Dim objRegistroExcepciones As New RegistroExcepcionesAltaForm
                            objRegistroExcepciones.registroCheckID = CInt(grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells((grdControlAsistencia.CurrentCell.ColumnIndex) - 1).Value)
                            objRegistroExcepciones.naveID = naveID

                            Dim objBU As New Negocios.RegistroCheckBU
                            Dim listaRegistroCheck As New List(Of Entidades.RegistroCheck)
                            listaRegistroCheck = objBU.buscar_DetalleRegistroCheck(objRegistroExcepciones.registroCheckID, naveID)

                            Dim objE As Entidades.RegistroCheck = _
                                listaRegistroCheck.Find(Function(c) c.PId = objRegistroExcepciones.registroCheckID And c.Pregcheck_nave.PNaveId = naveID)



                            If IsNothing(objE.PCheck_Excepcion.Pregexc_id) Or objE.PCheck_Excepcion.Pregexc_id = 0 Then

                                objRegistroExcepciones.RegistroExcepcionesPost = True
                                objRegistroExcepciones.regCheck = objE

                                objRegistroExcepciones.ShowDialog()

                                row = CInt(grdControlAsistencia.CurrentCell.RowIndex)
                                col = CInt(grdControlAsistencia.CurrentCell.ColumnIndex)

                                btnAceptar.PerformClick()


                                grdControlAsistencia.Rows(row).Cells(col).Style.BackColor = Color.LightGreen
                            Else
                                MessageBox.Show("Este registro ya cuenta con un permiso")
                            End If

                        End If

                    End If

                End If

            End If

        End If
        If selection = 3 Then

            If grdControlAsistencia.CurrentCell.RowIndex >= 0 And grdControlAsistencia.CurrentCell.ColumnIndex >= 4 Then

                If grdControlAsistencia.CurrentCell.Selected Then

                    If IsNothing(grdControlAsistencia.CurrentCell.Value) Or IsDBNull(grdControlAsistencia.CurrentCell.Value) Then

                    Else

                        Dim objRegistroExcepciones As New RegistroExcepcionesAltaForm
                        objRegistroExcepciones.registroCheckID = CInt(grdControlAsistencia.Rows(grdControlAsistencia.CurrentCell.RowIndex).Cells((grdControlAsistencia.CurrentCell.ColumnIndex) - 1).Value)
                        objRegistroExcepciones.naveID = naveID

                        Dim objBU As New Negocios.RegistroCheckBU
                        Dim listaRegistroCheck As New List(Of Entidades.RegistroCheck)
                        listaRegistroCheck = objBU.buscar_DetalleRegistroCheck(objRegistroExcepciones.registroCheckID, naveID)

                        Dim registroCheck As Entidades.RegistroCheck = _
                            listaRegistroCheck.Find(Function(c) c.PId = objRegistroExcepciones.registroCheckID And c.Pregcheck_nave.PNaveId = naveID)

                        If IsNothing(registroCheck.PCheck_Excepcion.Pregexc_id) Or registroCheck.PCheck_Excepcion.Pregexc_id = 0 Then

                        Else

                            objRegistroExcepciones.RevisionRegistroExcepciones = True
                            objRegistroExcepciones.regCheck = registroCheck

                            objRegistroExcepciones.ShowDialog()

                        End If

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click

        'gboxParametros.Visible = False
        grbParametros.Height = 45


    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click

        'gboxParametros.Visible = True
        grbParametros.Height = 182

    End Sub

    Private Sub chboxMostrarResumen_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'clmBloque.Visible = False
        'clmLunes.Visible = False
        'clmMartes.Visible = False
        'clmMiercoles.Visible = False
        'clmJueves.Visible = False
        'clmViernes.Visible = False
        'clmSabado.Visible = False
        'clmDomingo.Visible = False

        clmPermisos.Visible = True
        clmRetardoMenor.Visible = True
        clmRetardoMayor.Visible = True
        clmInasistencias.Visible = True
        clmPuntualidadAsistencia.Visible = True
        clmCajaAhorro.Visible = True
        'chboxOcultarResumen.CheckState = CheckState.Unchecked

    End Sub

    Private Sub chboxOcultarResumen_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)


        'clmBloque.Visible = True
        'clmLunes.Visible = True
        'clmMartes.Visible = True
        'clmMiercoles.Visible = True
        'clmJueves.Visible = True
        'clmViernes.Visible = True
        'clmSabado.Visible = True
        'clmDomingo.Visible = True

        clmPermisos.Visible = False
        clmRetardoMenor.Visible = False
        clmRetardoMayor.Visible = False
        clmInasistencias.Visible = False
        clmPuntualidadAsistencia.Visible = False
        clmCajaAhorro.Visible = False
        'chboxMostrarResumen.CheckState = CheckState.Unchecked

        ocultar_columnas_vacias()

    End Sub

    Private Sub chboxMostrarSalidas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        For Each row As DataGridViewRow In grdControlAsistencia.Rows


            If grdControlAsistencia.Rows(row.Index).Cells(3).Value = 2 Or grdControlAsistencia.Rows(row.Index).Cells(3).Value = 4 Then

                grdControlAsistencia.Rows(row.Index).Visible = True

            End If


        Next

    End Sub

    Private Sub chboxOcultarSalidas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        For Each row As DataGridViewRow In grdControlAsistencia.Rows


            If grdControlAsistencia.Rows(row.Index).Cells(3).Value = 2 Or grdControlAsistencia.Rows(row.Index).Cells(3).Value = 4 Then

                grdControlAsistencia.Rows(row.Index).Visible = False

            End If


        Next

    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.MdiParent = Me.MdiParent
            mensajeAviso.mensaje = mensaje
            mensajeAviso.Show()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.MdiParent = Me.MdiParent
            mensajeError.mensaje = mensaje
            mensajeError.Show()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = mensaje
            mensajeExito.Show()

        End If
    End Sub

    Private Sub grdControlAsistencia_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles grdControlAsistencia.CellPainting
        'el e.columnindex son las columnas que checara para ver si se pueden combinar las celdas iguales
        ' en este caso checara la 2

        If e.ColumnIndex = 0 Or e.ColumnIndex = 1 Or e.ColumnIndex = 2 AndAlso e.RowIndex <> -1 Then

            Using gridBrush As Brush = New SolidBrush(Me.grdControlAsistencia.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

                Using gridLinePen As Pen = New Pen(gridBrush)


                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds)
                    'e.Graphics.FillRectangle(Brushes.LightSkyBlue, e.CellBounds)
                    If e.RowIndex < grdControlAsistencia.Rows.Count - 2 AndAlso grdControlAsistencia.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value.ToString() <> e.Value.ToString() Then

                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)

                    End If

                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                    If Not e.Value Is Nothing Then

                        If e.RowIndex > 0 AndAlso grdControlAsistencia.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value.ToString() = e.Value.ToString() Then

                        Else

                            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)

                        End If

                    End If

                    e.Handled = True

                End Using

            End Using

        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub rbtnMostrarSalidas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnMostrarSalidas.CheckedChanged

        For Each row As DataGridViewRow In grdControlAsistencia.Rows


            If grdControlAsistencia.Rows(row.Index).Cells(3).Value = 2 Or grdControlAsistencia.Rows(row.Index).Cells(3).Value = 4 Then

                grdControlAsistencia.Rows(row.Index).Visible = True

            End If


        Next

    End Sub

    Private Sub rbtnOcultarSalidas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnOcultarSalidas.CheckedChanged

        For Each row As DataGridViewRow In grdControlAsistencia.Rows


            If grdControlAsistencia.Rows(row.Index).Cells(3).Value = 2 Or grdControlAsistencia.Rows(row.Index).Cells(3).Value = 4 Then

                grdControlAsistencia.Rows(row.Index).Visible = False

            End If


        Next

    End Sub

    Private Sub rbtnMostrarResumen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnMostrarResumen.CheckedChanged

        If rbtnOcultarResumen.Checked Then Return

        If naveID <> 43 Then

            clmRetardoMayor.HeaderText = "R"
            clmRetardoMayor.ToolTipText = "Retardo"
            clmPermisos.Visible = True
            clmRetardoMenor.Visible = False
            clmRetardoMayor.Visible = True
            clmInasistencias.Visible = True
            clmPuntualidadAsistencia.Visible = True
            clmCajaAhorro.Visible = True
        Else
            clmRetardoMayor.HeaderText = "RM"
            clmRetardoMayor.ToolTipText = "Retardo Mayor"
            clmPermisos.Visible = True
            clmRetardoMenor.Visible = True
            clmRetardoMayor.Visible = True
            clmInasistencias.Visible = True
            clmPuntualidadAsistencia.Visible = True
            clmCajaAhorro.Visible = True
        End If

        ocultar_columnas_vacias()
    End Sub

    Private Sub rbtnOcultarResumen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnOcultarResumen.CheckedChanged


        If rbtnMostrarResumen.Checked Then Return

        If naveID <> 43 Then

            clmRetardoMayor.HeaderText = "R"
            clmRetardoMayor.ToolTipText = "Retardo"
            clmPermisos.Visible = True
            clmRetardoMenor.Visible = False
            clmRetardoMayor.Visible = False
            clmInasistencias.Visible = False
            clmPuntualidadAsistencia.Visible = False
            clmCajaAhorro.Visible = False
        Else
            clmRetardoMayor.HeaderText = "RM"
            clmRetardoMayor.ToolTipText = "Retardo Mayor"
            clmPermisos.Visible = False
            clmRetardoMenor.Visible = False
            clmRetardoMayor.Visible = False
            clmInasistencias.Visible = False
            clmPuntualidadAsistencia.Visible = False
            clmCajaAhorro.Visible = False
        End If


    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        Dim tabla As New DataTable
        'Dim clmRegistroNum, clmColaborador, clmRetardoMenor, clmRetardoMayor, clmInasistencias, clmPuntualidadAsistencia, clmCajaAhorro As New System.Data.DataColumn

        tabla.Columns.Add("clmRegistroNum")
        tabla.Columns.Add("clmColaborador")
        tabla.Columns.Add("clmPermisos")
        tabla.Columns.Add("clmRetardoMenor")
        tabla.Columns.Add("clmRetardoMayor")
        tabla.Columns.Add("clmInasistencias")
        tabla.Columns.Add("clmPuntualidadAsistencia")
        tabla.Columns.Add("clmCajaAhorro")

        'Dim filas As Integer = CInt(Me.grdControlAsistencia.Rows.Count)
        Dim iterador As Integer

        For iterador = 0 To CInt(Me.grdControlAsistencia.Rows.Count) - 4

            tabla.Rows.Add(grdControlAsistencia.Rows(iterador).Cells("clmRegistroNum").Value.ToString, _
                           grdControlAsistencia.Rows(iterador).Cells("clmColaborador").Value.ToString, _
                           grdControlAsistencia.Rows(iterador).Cells("clmPermisos").Value.ToString, _
                           grdControlAsistencia.Rows(iterador).Cells("clmRetardoMenor").Value.ToString, _
                           grdControlAsistencia.Rows(iterador).Cells("clmRetardoMayor").Value.ToString, _
                           grdControlAsistencia.Rows(iterador).Cells("clmInasistencias").Value.ToString, _
                           grdControlAsistencia.Rows(iterador).Cells("clmPuntualidadAsistencia").Value.ToString, _
                           grdControlAsistencia.Rows(iterador).Cells("clmCajaAhorro").Value.ToString _
                           )

            iterador += 3

        Next


        Dim ds As New ControlAsistenciaDS
        Dim ObjDS As New ControlAsistenciaDS
        ds.Tables.Add("tabla")


        ''Se agregan las columnas
        Dim col As System.Data.DataColumn
        For Each dgvCol As DataColumn In tabla.Columns
            col = New System.Data.DataColumn(dgvCol.Caption)
            ds.Tables("tabla").Columns.Add(col)
        Next

        ''SE agregan las filas
        Dim row As System.Data.DataRow
        Dim colcount As Integer = tabla.Columns.Count - 1

        For Each fila As DataRow In tabla.Rows 'As 'Integer = 0 To tabla.Rows.Count - 1
            row = ds.Tables("tabla").Rows.Add

            Dim j As Integer
            j = 0
            For Each column As DataColumn In tabla.Columns
                row.Item(j) = fila.Item(j)
                j += 1
            Next
        Next

        ''Esta variable indica el nombre del parametro que se encuentra en el procedimiento almacenado
        Dim Parametros As New ParameterFields()

        Dim UserName As New ParameterField()
        Dim NombreArchivo As New ParameterField()
        Dim RangoPeriodo As New ParameterField()
        Dim RutaPaloma As New ParameterField()
        Dim RutaTacha As New ParameterField()


        ''Esta variable toma el valor dle parametro
        Dim myDiscreteValueUserName As New ParameterDiscreteValue()
        Dim myDiscreteValueNombreArchivo As New ParameterDiscreteValue()
        Dim myDiscreteValueRangoPeriodo As New ParameterDiscreteValue()
        Dim myDiscreteValueRutaPaloma As New ParameterDiscreteValue()
        Dim myDiscreteValueRutaTacha As New ParameterDiscreteValue()

        UserName.ParameterValueType = ParameterValueKind.StringParameter
        NombreArchivo.ParameterValueType = ParameterValueKind.StringParameter
        RangoPeriodo.ParameterValueType = ParameterValueKind.StringParameter
        RutaPaloma.ParameterValueType = ParameterValueKind.StringParameter
        RutaTacha.ParameterValueType = ParameterValueKind.StringParameter

        UserName.ParameterFieldName = "UserName"
        NombreArchivo.ParameterFieldName = "NombreArchivo"
        RangoPeriodo.ParameterFieldName = "RangoPeriodo"
        RutaPaloma.ParameterFieldName = "RutaPaloma"
        RutaTacha.ParameterFieldName = "RutaTacha"

        myDiscreteValueUserName.Value = Convert.ToString(Entidades.SesionUsuario.UsuarioSesion.PUserUsername)
        myDiscreteValueNombreArchivo.Value = Convert.ToString("ReporteControlAsistencia.rpt")
        myDiscreteValueRangoPeriodo.Value = Convert.ToString(cboxPeriodo.Text)

        ''
        myDiscreteValueRutaTacha.Value = (rutaPublica & "recursos/tachita_512x512.jpg")
        myDiscreteValueRutaPaloma.Value = (rutaPublica & "recursos/palomita_512x512.jpg")

        UserName.CurrentValues.Add(myDiscreteValueUserName)
        NombreArchivo.CurrentValues.Add(myDiscreteValueNombreArchivo)
        RangoPeriodo.CurrentValues.Add(myDiscreteValueRangoPeriodo)
        RutaPaloma.CurrentValues.Add(myDiscreteValueRutaPaloma)
        RutaTacha.CurrentValues.Add(myDiscreteValueRutaTacha)

        Parametros.Add(UserName)
        Parametros.Add(NombreArchivo)
        Parametros.Add(RangoPeriodo)
        Parametros.Add(RutaPaloma)
        Parametros.Add(RutaTacha)


        Dim Report As New ReporteControlAsistencia
        Dim VisorReporte As New VisorReportesEnTablas

        Report.SetDataSource(ds.Tables("tabla"))


        VisorReporte.ReporteViewer.ReportSource = Report
        VisorReporte.ReporteViewer.ParameterFieldInfo = Parametros
        VisorReporte.Show()

    End Sub

    Private Sub btnImprimir2_Click(sender As Object, e As EventArgs) Handles btnImprimir2.Click

        Dim tabla As New DataTable

        tabla.Columns.Add("clmRegistroNum")
        tabla.Columns.Add("clmColaborador")
        tabla.Columns.Add("clmBloque")
        tabla.Columns.Add("clmLunes")
        tabla.Columns.Add("clmMartes")
        tabla.Columns.Add("clmMiercoles")
        tabla.Columns.Add("clmJueves")
        tabla.Columns.Add("clmViernes")
        tabla.Columns.Add("clmSabado")
        tabla.Columns.Add("clmDomingo")
        tabla.Columns.Add("clmPermisos")
        tabla.Columns.Add("clmRetardoMenor")
        tabla.Columns.Add("clmRetardoMayor")
        tabla.Columns.Add("clmInasistencias")
        tabla.Columns.Add("clmPuntualidadAsistencia")
        tabla.Columns.Add("clmCajaAhorro")

        Dim RegistroNum, Colaborador, Bloque _
               , Lunes, Martes, Miercoles, Jueves _
               , Viernes, Sabado, Domingo, Permisos _
               , RetardoMenor, RetardoMayor, Inasistencias _
               , PuntualidadAsistencia, CajaAhorro As String

        Bloque = String.Empty

        Dim iterador As Integer

        For iterador = 0 To CInt(Me.grdControlAsistencia.Rows.Count) - 1


            If grdControlAsistencia.Rows(iterador).Visible Then


                If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(iterador).Cells("clmregistronum").Value) Then
                    RegistroNum = String.Empty
                Else
                    RegistroNum = grdControlAsistencia.Rows(iterador).Cells("clmregistronum").Value.ToString
                End If


                If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(iterador).Cells("clmcolaborador").Value) Then
                    Colaborador = String.Empty
                Else
                    Colaborador = grdControlAsistencia.Rows(iterador).Cells("clmcolaborador").Value.ToString
                End If


                If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(iterador).Cells("clmbloque").Value) Then
                    Bloque = String.Empty
                Else
                    If grdControlAsistencia.Rows(iterador).Cells("clmbloque").Value.ToString.Equals("ENTRADA") Then
                        Bloque = "MATUTINO"
                    Else
                        If grdControlAsistencia.Rows(iterador).Cells("clmbloque").Value.ToString.Equals("REGRESO") Then
                            Bloque = "VESPERTINO"
                        Else
                            If grdControlAsistencia.Rows(iterador).Cells("clmbloque").Value.ToString.Equals("COMIDA") Then
                                Bloque = "MATUTINO 2"
                            Else
                                If grdControlAsistencia.Rows(iterador).Cells("clmbloque").Value.ToString.Equals("SALIDA") Then
                                    Bloque = "VESPERTINO 2"
                                End If
                            End If
                        End If
                    End If

                End If

                Dim fecha As Date
                If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(iterador).Cells("clmlunes").Value) Then
                    Lunes = String.Empty
                Else
                    If Date.TryParse(grdControlAsistencia.Rows(iterador).Cells("clmlunes").Value, fecha) Then
                        Lunes = CDate(grdControlAsistencia.Rows(iterador).Cells("clmlunes").Value).ToShortTimeString
                    Else
                        Lunes = CStr(grdControlAsistencia.Rows(iterador).Cells("clmlunes").Value)
                    End If
                End If


                If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(iterador).Cells("clmmartes").Value) Then
                    Martes = String.Empty
                Else
                    If Date.TryParse(grdControlAsistencia.Rows(iterador).Cells("clmmartes").Value, fecha) Then
                        Martes = CDate(grdControlAsistencia.Rows(iterador).Cells("clmmartes").Value).ToShortTimeString
                    Else
                        Martes = CStr(grdControlAsistencia.Rows(iterador).Cells("clmmartes").Value)
                    End If
                End If


                If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(iterador).Cells("clmmiercoles").Value) Then
                    Miercoles = String.Empty
                Else
                    If Date.TryParse(grdControlAsistencia.Rows(iterador).Cells("clmmiercoles").Value, fecha) Then
                        Miercoles = CDate(grdControlAsistencia.Rows(iterador).Cells("clmmiercoles").Value).ToShortTimeString
                    Else
                        Miercoles = CStr(grdControlAsistencia.Rows(iterador).Cells("clmmiercoles").Value)
                    End If
                End If


                If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(iterador).Cells("clmjueves").Value) Then
                    Jueves = String.Empty
                Else
                    If Date.TryParse(grdControlAsistencia.Rows(iterador).Cells("clmjueves").Value, fecha) Then
                        Jueves = CDate(grdControlAsistencia.Rows(iterador).Cells("clmjueves").Value).ToShortTimeString
                    Else
                        Jueves = CStr(grdControlAsistencia.Rows(iterador).Cells("clmjueves").Value)
                    End If
                End If


                If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(iterador).Cells("clmviernes").Value) Then
                    Viernes = String.Empty
                Else
                    If Date.TryParse(grdControlAsistencia.Rows(iterador).Cells("clmviernes").Value, fecha) Then
                        Viernes = CDate(grdControlAsistencia.Rows(iterador).Cells("clmviernes").Value).ToShortTimeString
                    Else
                        Viernes = CStr(grdControlAsistencia.Rows(iterador).Cells("clmviernes").Value)
                    End If
                End If


                If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(iterador).Cells("clmsabado").Value) Then
                    Sabado = String.Empty
                Else
                    If Date.TryParse(grdControlAsistencia.Rows(iterador).Cells("clmsabado").Value, fecha) Then
                        Sabado = CDate(grdControlAsistencia.Rows(iterador).Cells("clmsabado").Value).ToShortTimeString
                    Else
                        Sabado = CStr(grdControlAsistencia.Rows(iterador).Cells("clmsabado").Value)
                    End If
                End If


                If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(iterador).Cells("clmdomingo").Value) Then
                    Domingo = String.Empty
                Else
                    If Date.TryParse(grdControlAsistencia.Rows(iterador).Cells("clmdomingo").Value, fecha) Then
                        Domingo = CDate(grdControlAsistencia.Rows(iterador).Cells("clmdomingo").Value).ToShortTimeString
                    Else
                        Domingo = CStr(grdControlAsistencia.Rows(iterador).Cells("clmdomingo").Value)
                    End If
                End If


                If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(iterador).Cells("clmpermisos").Value) Then
                    Permisos = String.Empty
                Else
                    Permisos = grdControlAsistencia.Rows(iterador).Cells("clmpermisos").Value.ToString
                End If


                If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(iterador).Cells("clmretardomenor").Value) Then
                    RetardoMenor = String.Empty
                Else
                    RetardoMenor = grdControlAsistencia.Rows(iterador).Cells("clmretardomenor").Value.ToString
                End If


                If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(iterador).Cells("clmretardomayor").Value) Then
                    RetardoMayor = String.Empty
                Else
                    RetardoMayor = grdControlAsistencia.Rows(iterador).Cells("clmretardomayor").Value.ToString
                End If


                If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(iterador).Cells("clminasistencias").Value) Then
                    Inasistencias = String.Empty
                Else
                    Inasistencias = grdControlAsistencia.Rows(iterador).Cells("clminasistencias").Value.ToString
                End If

                If iterador = 0 Or iterador Mod 4 = 0 Then
                    If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(iterador).Cells("clmPuntualidadAsistencia").Value) Then
                        PuntualidadAsistencia = String.Empty
                    Else
                        PuntualidadAsistencia = grdControlAsistencia.Rows(iterador).Cells("clmpuntualidadasistencia").Value.ToString
                    End If


                    If String.IsNullOrWhiteSpace(grdControlAsistencia.Rows(iterador).Cells("clmcajaahorro").Value) Then
                        CajaAhorro = String.Empty
                    Else
                        CajaAhorro = grdControlAsistencia.Rows(iterador).Cells("clmcajaahorro").Value.ToString
                    End If
                Else
                    PuntualidadAsistencia = String.Empty
                    CajaAhorro = String.Empty
                End If

                tabla.Rows.Add(RegistroNum, Colaborador, Bloque _
                                , Lunes, Martes, Miercoles, Jueves _
                                , Viernes, Sabado, Domingo, Permisos _
                                , RetardoMenor, RetardoMayor, Inasistencias _
                                , PuntualidadAsistencia, CajaAhorro _
                               )
            End If
        Next


        Dim ds As New ControlAsistenciaDS
        Dim ObjDS As New ControlAsistenciaDS
        ds.Tables.Add("tabla")


        ''Se agregan las columnas
        Dim col As System.Data.DataColumn
        For Each dgvCol As DataColumn In tabla.Columns
            col = New System.Data.DataColumn(dgvCol.Caption)
            ds.Tables("tabla").Columns.Add(col)
        Next

        ''SE agregan las filas
        Dim row As System.Data.DataRow
        Dim colcount As Integer = tabla.Columns.Count - 1

        For Each fila As DataRow In tabla.Rows 'As 'Integer = 0 To tabla.Rows.Count - 1
            row = ds.Tables("tabla").Rows.Add

            Dim j As Integer
            j = 0
            For Each column As DataColumn In tabla.Columns
                row.Item(j) = fila.Item(j)
                j += 1
            Next
        Next

        ''Esta variable indica el nombre del parametro que se encuentra en el procedimiento almacenado
        Dim Parametros As New ParameterFields()

        Dim UserName As New ParameterField()
        Dim NombreArchivo As New ParameterField()
        Dim RangoPeriodo As New ParameterField()
        Dim RutaPaloma As New ParameterField()
        Dim RutaTacha As New ParameterField()
        Dim NaveID As New ParameterField()
        Dim date_Lunes As New ParameterField()
        Dim date_Martes As New ParameterField()
        Dim date_Miercoles As New ParameterField()
        Dim date_Jueves As New ParameterField()
        Dim date_Viernes As New ParameterField()
        Dim date_Sabado As New ParameterField()
        Dim date_Domingo As New ParameterField()


        ''Esta variable toma el valor dle parametro
        Dim myDiscreteValueUserName As New ParameterDiscreteValue()
        Dim myDiscreteValueNombreArchivo As New ParameterDiscreteValue()
        Dim myDiscreteValueRangoPeriodo As New ParameterDiscreteValue()
        Dim myDiscreteValueRutaPaloma As New ParameterDiscreteValue()
        Dim myDiscreteValueRutaTacha As New ParameterDiscreteValue()
        Dim myDiscreteValueNaveID As New ParameterDiscreteValue()
        Dim myDiscreteValuedate_Lunes As New ParameterDiscreteValue()
        Dim myDiscreteValuedate_Martes As New ParameterDiscreteValue()
        Dim myDiscreteValuedate_Miercoles As New ParameterDiscreteValue()
        Dim myDiscreteValuedate_Jueves As New ParameterDiscreteValue()
        Dim myDiscreteValuedate_Viernes As New ParameterDiscreteValue()
        Dim myDiscreteValuedate_Sabado As New ParameterDiscreteValue()
        Dim myDiscreteValuedate_Domingo As New ParameterDiscreteValue()

        UserName.ParameterValueType = ParameterValueKind.StringParameter
        NombreArchivo.ParameterValueType = ParameterValueKind.StringParameter
        RangoPeriodo.ParameterValueType = ParameterValueKind.StringParameter
        RutaPaloma.ParameterValueType = ParameterValueKind.StringParameter
        RutaTacha.ParameterValueType = ParameterValueKind.StringParameter
        NaveID.ParameterValueType = ParameterValueKind.StringParameter
        date_Lunes.ParameterValueType = ParameterValueKind.StringParameter
        date_Martes.ParameterValueType = ParameterValueKind.StringParameter
        date_Miercoles.ParameterValueType = ParameterValueKind.StringParameter
        date_Jueves.ParameterValueType = ParameterValueKind.StringParameter
        date_Viernes.ParameterValueType = ParameterValueKind.StringParameter
        date_Sabado.ParameterValueType = ParameterValueKind.StringParameter
        date_Domingo.ParameterValueType = ParameterValueKind.StringParameter

        UserName.ParameterFieldName = "UserName"
        NombreArchivo.ParameterFieldName = "NombreArchivo"
        RangoPeriodo.ParameterFieldName = "RangoPeriodo"
        RutaPaloma.ParameterFieldName = "RutaPaloma"
        RutaTacha.ParameterFieldName = "RutaTacha"
        NaveID.ParameterFieldName = "NaveID"
        date_Lunes.ParameterFieldName = "date_Lunes"
        date_Martes.ParameterFieldName = "date_Martes"
        date_Miercoles.ParameterFieldName = "date_Miercoles"
        date_Jueves.ParameterFieldName = "date_Jueves"
        date_Viernes.ParameterFieldName = "date_Viernes"
        date_Sabado.ParameterFieldName = "date_Sabado"
        date_Domingo.ParameterFieldName = "date_Domingo"

        myDiscreteValueUserName.Value = Convert.ToString(Entidades.SesionUsuario.UsuarioSesion.PUserUsername)
        myDiscreteValueNombreArchivo.Value = Convert.ToString("ReporteControlAsistencia.rpt")
        myDiscreteValueRangoPeriodo.Value = Convert.ToString(cboxPeriodo.Text)
        myDiscreteValueNaveID.Value = Convert.ToString(cboxNave.SelectedValue)
        myDiscreteValuedate_Lunes.Value = Convert.ToString(fLunes)
        myDiscreteValuedate_Martes.Value = Convert.ToString(fMartes)
        myDiscreteValuedate_Miercoles.Value = Convert.ToString(fMiercoles)
        myDiscreteValuedate_Jueves.Value = Convert.ToString(fJueves)
        myDiscreteValuedate_Viernes.Value = Convert.ToString(fViernes)
        myDiscreteValuedate_Sabado.Value = Convert.ToString(fSabado)
        myDiscreteValuedate_Domingo.Value = Convert.ToString(fDomingo)
        ''
        If cboxNave.SelectedValue = 1 Then
            myDiscreteValueNaveID.Value = String.Empty
        Else
            If cboxNave.SelectedValue = 2 Then
                myDiscreteValueNaveID.Value = String.Empty
            Else
                If cboxNave.SelectedValue = 3 Then
                    myDiscreteValueNaveID.Value = (rutaPublica & "logotipos/jeans.jpg")
                Else
                    If cboxNave.SelectedValue = 4 Then
                        myDiscreteValueNaveID.Value = String.Empty
                    Else
                        If cboxNave.SelectedValue = 5 Then
                            myDiscreteValueNaveID.Value = String.Empty
                        Else
                            If cboxNave.SelectedValue = 6 Then
                                myDiscreteValueNaveID.Value = String.Empty
                            Else
                                If cboxNave.SelectedValue = 7 Then
                                    myDiscreteValueNaveID.Value = String.Empty
                                Else
                                    If cboxNave.SelectedValue = 43 Then
                                        myDiscreteValueNaveID.Value = String.Empty
                                    Else
                                        If cboxNave.SelectedValue = 45 Then
                                            myDiscreteValueNaveID.Value = String.Empty
                                        Else
                                            If cboxNave.SelectedValue = 46 Then
                                                myDiscreteValueNaveID.Value = String.Empty
                                            Else
                                                If cboxNave.SelectedValue = 47 Then
                                                    myDiscreteValueNaveID.Value = String.Empty
                                                Else
                                                    If cboxNave.SelectedValue = 48 Then
                                                        myDiscreteValueNaveID.Value = String.Empty
                                                    Else
                                                        If cboxNave.SelectedValue = 49 Then
                                                            myDiscreteValueNaveID.Value = String.Empty
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        myDiscreteValueRutaTacha.Value = (rutaPublica & "recursos/tachita_512x512.jpg")
        myDiscreteValueRutaPaloma.Value = (rutaPublica & "recursos/palomita_512x512.jpg")

        UserName.CurrentValues.Add(myDiscreteValueUserName)
        NombreArchivo.CurrentValues.Add(myDiscreteValueNombreArchivo)
        RangoPeriodo.CurrentValues.Add(myDiscreteValueRangoPeriodo)
        RutaPaloma.CurrentValues.Add(myDiscreteValueRutaPaloma)
        RutaTacha.CurrentValues.Add(myDiscreteValueRutaTacha)
        NaveID.CurrentValues.Add(myDiscreteValueNaveID)
        date_Lunes.CurrentValues.Add(myDiscreteValuedate_Lunes)
        date_Martes.CurrentValues.Add(myDiscreteValuedate_Martes)
        date_Miercoles.CurrentValues.Add(myDiscreteValuedate_Miercoles)
        date_Jueves.CurrentValues.Add(myDiscreteValuedate_Jueves)
        date_Viernes.CurrentValues.Add(myDiscreteValuedate_Viernes)
        date_Sabado.CurrentValues.Add(myDiscreteValuedate_Sabado)
        date_Domingo.CurrentValues.Add(myDiscreteValuedate_Domingo)

        Parametros.Add(UserName)
        Parametros.Add(NombreArchivo)
        Parametros.Add(RangoPeriodo)
        Parametros.Add(RutaPaloma)
        Parametros.Add(RutaTacha)
        Parametros.Add(NaveID)
        Parametros.Add(date_Lunes)
        Parametros.Add(date_Martes)
        Parametros.Add(date_Miercoles)
        Parametros.Add(date_Jueves)
        Parametros.Add(date_Viernes)
        Parametros.Add(date_Sabado)
        Parametros.Add(date_Domingo)



        Dim Report As New ReporteControlAsistencia2
        Dim VisorReporte As New VisorReportesEnTablas

        Report.SetDataSource(ds.Tables("tabla"))


        VisorReporte.ReporteViewer.ReportSource = Report
        VisorReporte.ReporteViewer.ParameterFieldInfo = Parametros
        VisorReporte.Show()



    End Sub

    Private Sub rbtnMostrarIncidencias_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnMostrarIncidencias.CheckedChanged

        Dim ControlAsistenciaBU As New Negocios.ControlAsistenciaBU
        Dim ControlDePeriodoBU As New Negocios.ControlDePeriodoBU
        Dim listaRegistroCheck As New List(Of Entidades.RegistroCheck)
        Dim areaID, departamentoID, celulaID, colaboradorID, periodoNomID As Integer
        Dim nombreColaborador As String
        nombreColaborador = txtColaboradorCA.Text

        If cboxNave.SelectedIndex > 0 Then

            naveID = cboxNave.SelectedValue

        End If

        If cmbArea.SelectedIndex > 0 Then

            areaID = cmbArea.SelectedValue

        End If

        If cboxDepartamento.SelectedIndex > 0 Then

            departamentoID = cboxDepartamento.SelectedValue

        Else

            departamentoID = 0

        End If

        If cboxCelula.SelectedIndex > 0 Then

            celulaID = cboxCelula.SelectedValue

        Else

            celulaID = 0

        End If

        If cboxColaborador.SelectedIndex > 0 Then

            colaboradorID = cboxColaborador.SelectedValue

        Else

            colaboradorID = 0

        End If

        periodoNomID = cboxPeriodo.SelectedValue

        If ControlDePeriodoBU.buscarPeriodoEsActivoAsistencia(periodoNomID) Then
            IsPeriodoEditable = True
        Else
            IsPeriodoEditable = False
        End If


        If (IsDBNull(cboxDepartamento.SelectedValue) Or IsNothing(cboxDepartamento.SelectedValue)) _
            And (IsDBNull(cboxColaborador.SelectedValue) Or IsNothing(cboxColaborador.SelectedValue)) Then
            If IsPeriodoEditable Then

                btnCorte.Enabled = True
                lblCorte.Enabled = True
                lblCorte.Text = "Cerrar Semana"

            Else

                btnCorte.Enabled = False
                lblCorte.Enabled = False
                lblCorte.Text = "Semana Cerrada"

            End If
        Else
            btnCorte.Enabled = False
            lblCorte.Enabled = False
            lblCorte.Text = "Semana Cerrada"
        End If

        listaRegistroCheck = ControlAsistenciaBU.consultar_RegistroCheck(naveID, areaID, periodoNomID, departamentoID, celulaID, colaboradorID, nombreColaborador, 2)

        cargar_gridControlAsistencia(listaRegistroCheck)

        For Each row As DataGridViewRow In grdControlAsistencia.Rows


            If grdControlAsistencia.Rows(row.Index).Cells(3).Value = 2 Or grdControlAsistencia.Rows(row.Index).Cells(3).Value = 4 Then

                grdControlAsistencia.Rows(row.Index).Visible = rbtnMostrarSalidas.Checked

            End If


        Next



    End Sub

    Private Sub rbtnOcultarIncidencias_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnOcultarIncidencias.CheckedChanged

        btnAceptar.PerformClick()

    End Sub

    Private Sub btnImprimir3_Click(sender As Object, e As EventArgs) Handles btnImprimir3.Click

        'If grdControlAsistencia.Rows.Count = 0 Then Return

        If IsNothing(cboxDepartamento.SelectedValue) Or cboxDepartamento.SelectedValue = 0 Then Return
        'Dim grid As DataTable = grdControlAsistencia.DataSource
        'grid.Columns.Add("colaborador")
        'grid.Columns.Add("ocupacion")
        'Dim listParametros As DataTable '= grid.Clone
        Dim lista_colaborador As String = String.Empty
        Dim listParametros As New DataTable
        listParametros.Columns.Add("id_colaborador")
        listParametros.Columns.Add("colaborador")

        For iterador = 0 To CInt(Me.grdControlAsistencia.Rows.Count) - 4

            If String.IsNullOrEmpty(lista_colaborador) Then
                lista_colaborador = grdControlAsistencia.Rows(iterador).Cells("clmColaboradorID").Value.ToString
            Else
                lista_colaborador = lista_colaborador + ", " + grdControlAsistencia.Rows(iterador).Cells("clmColaboradorID").Value.ToString
            End If

            listParametros.Rows.Add(grdControlAsistencia.Rows(iterador).Cells("clmColaboradorID").Value.ToString, _
                           grdControlAsistencia.Rows(iterador).Cells("clmColaborador").Value.ToString
                           )

            iterador += 3

        Next

        'For Each row As DataGrid In grdControlAsistencia.Rows

        '    Dim fila As DataRow = listParametros.NewRow

        '    For index = 0 To row.ItemArray.Count - 1 Step 1
        '        fila(index) = row.Item(index).Value
        '    Next
        '    listParametros.Rows.Add(fila)

        'Next

        Me.Cursor = Cursors.WaitCursor
        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        EntidadReporte = OBJBU.LeerReporteporClave("NOM_CA_LISTA_ASISTENCIA")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            EntidadReporte.Pnombre + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()

        Dim periodo As Object = reporte("periodo")
        reporte("periodo") = cboxPeriodo.Text

        Dim departamento As Object = reporte("departamento")
        reporte("departamento") = cboxDepartamento.Text

        Dim departamentoID As Object = reporte("departamentoID")
        reporte("departamentoID") = CStr(cboxDepartamento.SelectedValue)

        Dim celula As Object = reporte("celula")
        reporte("celula") = cboxCelula.Text

        Dim celulaID As Object = reporte("celulaID")
        If IsNothing(cboxCelula.SelectedValue) Or IsDBNull(cboxCelula.SelectedValue) Then
            reporte("celulaID") = "0"
        Else
            reporte("celulaID") = CStr(cboxCelula.SelectedValue)
        End If

        Dim colaboradorID As Object = reporte("colaboradorID")
        reporte("colaboradorID") = lista_colaborador

        reporte.RegData(listParametros)
        reporte.Show()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub grdControlAsistencia_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grdControlAsistencia.CellValueChanged
        If e.ColumnIndex = 18 Then
            Dim valor As String = ""
            valor = grdControlAsistencia.Rows(0).Cells(18).Value
        End If
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub
End Class



