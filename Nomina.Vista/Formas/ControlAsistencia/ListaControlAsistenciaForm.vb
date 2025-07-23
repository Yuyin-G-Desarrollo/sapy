Imports Infragistics.Win.UltraWinGrid
Imports Stimulsoft.Report
Imports Framework.Negocios
Imports Tools

Public Class ListaControlAsistenciaForm
    Dim dias() As String
    Dim fechaDias() As String
    Dim condiciones As String = ""
    Dim idNave As Int32 = 0
    Dim banderaCierre As Boolean = False

    Private Sub cargarNaves()
        Controles.ComboNavesSegunUsuario(cmbNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))

        If cmbNave.SelectedIndex > 0 Then
            idNave = cmbNave.SelectedValue
            listarPeriodosAsistencia()

        End If
    End Sub

    Private Sub cargarAreas()
        Try

            Tools.Controles.ComboAreaSegunNave(cmbArea, cmbNave.SelectedValue)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarDepartamentos()
        Try

            Tools.Controles.ComboDepartamentosSegunArea(cmbDepartamento, cmbArea.SelectedValue)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarCelulas()

        Try
            Tools.Controles.ComboCelulasSegunDepartamento(cmbCelula, cmbDepartamento.SelectedValue)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub listarPeriodosAsistencia()

        Try

            Controles.ComboPeriodoSegunNaveSegunAsistenciaControlAsistencia(cmbPeriodo, CInt(cmbNave.SelectedValue.ToString))
            Dim ControlDelPeriodoBu As New Negocios.ControlDePeriodoBU
            Dim periodoNominaID As Integer = CInt(ControlDelPeriodoBu.periodoSegunNaveSegunAsistenciaActual(CInt(cmbNave.SelectedValue.ToString)).Rows(0).Item(0).ToString)

            cmbPeriodo.SelectedValue = periodoNominaID
            cmbPeriodo.SelectedItem = cmbPeriodo.SelectedValue
        Catch ex As Exception

        End Try

    End Sub

    Private Sub crearCondicionesConsulta()
        condiciones = ""
        If cmbArea.SelectedIndex > 0 Then
            condiciones += " AND vc.labo_areaid= " + cmbArea.SelectedValue.ToString
        End If

        If cmbDepartamento.SelectedIndex > 0 Then
            condiciones += " and vc.labo_departamentoid= " + cmbDepartamento.SelectedValue.ToString
        End If

        If cmbCelula.SelectedIndex > 0 Then
            condiciones += " and ce.celu_celulaid= " + cmbCelula.SelectedValue.ToString
        End If

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        mostrarConsultaRegistros()
        validarPeriodoNomina()
        If rbtnMostrarResumen.Checked = True Then
            mostrarResumen()
        End If
        If rbtnMostrarIncidencias.Checked = True Then
            mostrarIncidencias()
        End If
        '  ConcultarPermisos()

    End Sub

    Public Sub mostrarConsultaRegistros()
        Dim periodoRango As New Entidades.PeriodosNomina
        Dim ControlDePeriodoBU As New Negocios.ControlDePeriodoBU
        Dim controlAsistenciaBU As New Negocios.ControlAsistenciaBU
        Dim dtConsultaRegistros As New DataTable
        Dim periodoNomina As String = ""
        Dim fechaInicio As Date
        Dim fechaFin As Date
        Dim advertencia As New AdvertenciaForm
        If cmbPeriodo.SelectedValue > 0 Then
            Cursor = Cursors.WaitCursor
            grdAsistencia.DataSource = Nothing
            crearCondicionesConsulta()
            periodoNomina = cmbPeriodo.SelectedValue
            periodoRango = ControlDePeriodoBU.buscarRangosPeriodoSegunNaveSegunAsistencia(periodoNomina)
            fechaInicio = periodoRango.FechaInicio
            fechaFin = periodoRango.FechaFin
            dtConsultaRegistros = controlAsistenciaBU.cargarConsultaRegistros(CInt(cmbNave.SelectedValue.ToString), fechaInicio, fechaFin, condiciones)
            If dtConsultaRegistros.Rows.Count > 0 Then
                AsignarNombresColumnas(dtConsultaRegistros)
                grdAsistencia.DataSource = dtConsultaRegistros
                formatoGrid()
                agregarNotasColores()
                pintarcoloresFilasGrid()

            End If
        Else
            advertencia.mensaje = "Seleccione un periodo"
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub AsignarNombresColumnas(ByVal dtRegistros As DataTable)
        Dim contI As Int32 = 16
        Dim contF As Int32 = 16
        Dim cont As Int32 = 0
        Dim pos As Int32 = 0
        Dim conId As Int32 = 0

        For con = 16 To dtRegistros.Columns.Count - 1
            If dtRegistros.Columns(con).ColumnName.ToString = "codr_colaboradorid1" Then
                Exit For
            End If
            contF = contF + 1
        Next

        For con = 0 To dtRegistros.Columns.Count - 1
            cont = cont + 1
            If dtRegistros.Columns(con).ColumnName.ToString = "regcheck_tipo_check" Then
                Exit For
            End If

        Next

        ReDim dias((contF - contI) - 1)
        ReDim fechaDias((contF - contI) - 1)
        Dim fecha As DateTime
        Dim nuevoNombre As String = String.Empty

        For i = contI To contF - 1
            fecha = dtRegistros.Columns(i).ColumnName.ToString
            fechaDias(pos) = fecha.ToShortDateString

            nuevoNombre = String.Empty
            nuevoNombre = WeekdayName(Weekday(dtRegistros.Columns(i).ColumnName.ToString).ToString).ToUpper & vbCrLf & fechaDias(pos)
            dtRegistros.Columns(i).ColumnName = nuevoNombre.ToString

            dias(pos) = dtRegistros.Columns(i).ColumnName
            pos = pos + 1
        Next

        'Reinicia posición para asignar nombre a TIPO
        pos = 0
        Dim nombretipo As String = String.Empty

        For x = cont To (cont + dias.Length) - 1

            nombretipo = String.Empty
            nombretipo = WeekdayName(Weekday(dtRegistros.Columns(x).ColumnName.ToString.Substring(0, 10)).ToString).ToUpper & vbCrLf & fechaDias(pos) & "TIPO"

            dtRegistros.Columns(x).ColumnName = nombretipo.ToString
            pos = pos + 1
        Next

        For j = 0 To dtRegistros.Columns.Count - 1
            conId = conId + 1
            If dtRegistros.Columns(j).ColumnName.ToString = "regcheck_tipo_check1" Then
                Exit For
            End If
        Next

        'Reinicia posición para asignar nombre a ID
        pos = 0
        Dim nombreId As String = String.Empty

        For x = conId To dtRegistros.Columns.Count - 1

            nombreId = WeekdayName(Weekday(dtRegistros.Columns(x).ColumnName.ToString.Substring(0, 10)).ToString).ToUpper & vbCrLf & fechaDias(pos) + "ID"
            dtRegistros.Columns(x).ColumnName = nombreId

            pos = pos + 1
        Next

    End Sub

    Public Sub agregarNotasColores()
        Dim nota As String = ""
        Dim hora As String = ""
        Dim tipo As String = ""
        Dim resultado As String = ""
        Dim datos(3) As String
        Dim HoraRecuperada As DateTime
        Dim checaBloque As Int32 = 0
        Dim fechaColumna As DateTime
        Dim numeroDia As Int32
        Dim bloque As String = ""
        Dim registroNota As String = ""
        'Dim horaActual As DateTime = Now.ToLongTimeString
        'Dim horaTerminoBloque As DateTime
        Dim resul As Int32 = 0

        'Yazmin Rocha (21/04/2016) No colocar "No registro", segun el horario establecido al colaborador
        Dim controlAsistenciaBU As New Negocios.ControlAsistenciaBU

        For cont = 0 To dias.Length - 1
            For i = 0 To grdAsistencia.Rows.Count - 1
                hora = ""
                nota = ""
                Dim col2 As Int32 = grdAsistencia.Rows(i).Cells("codr_colaboradorid").Value

                If Not grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value.ToString = "" Then
                    HoraRecuperada = grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value.Substring(0, 14)
                    hora = HoraRecuperada.ToLongTimeString
                    tipo = grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value.Substring(16, 1)
                    resultado = grdAsistencia.Rows(i).Cells(dias(cont).ToString + "TIPO").Value.ToString
                    nota = Mid(grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value.ToString, 18)

                    If grdAsistencia.Rows(i).Cells("bloque").Value.ToString.Equals("1") Then
                        grdAsistencia.Rows(i).Cells("bloque").Value = "ENTRADA"
                    ElseIf grdAsistencia.Rows(i).Cells("bloque").Value.ToString.Equals("3") Then
                        grdAsistencia.Rows(i).Cells("bloque").Value = "REGRESO"
                    End If

                Else

                    If grdAsistencia.Rows(i).Cells("bloque").Value.ToString.Equals("1") Then
                        grdAsistencia.Rows(i).Cells("bloque").Value = "ENTRADA"
                    ElseIf grdAsistencia.Rows(i).Cells("bloque").Value.ToString.Equals("3") Then
                        grdAsistencia.Rows(i).Cells("bloque").Value = "REGRESO"
                    End If

                End If
                checaBloque = grdAsistencia.Rows(i).Cells("checabloque").Value.ToString
                'checaBloque = 3


                grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value = hora
                If tipo.Equals("M") Then
                    grdAsistencia.Rows(i).Cells(dias(cont).ToString).Appearance.ForeColor = Color.DarkGreen

                    If resultado.Equals("T") Then ''Tiempo
                        registroNota = "Registro Correcto"
                    ElseIf resultado.Equals("ME") Then ''Menor
                        registroNota = "Retardo Menor"
                    ElseIf resultado.Equals("MA") Then ''Mayor
                        registroNota = "Retardo Mayor"
                    ElseIf resultado.Equals("SC") Then ''Comida
                        registroNota = "Sin Salida a Comida"
                        grdAsistencia.Rows(i).Cells(dias(cont).ToString).Appearance.ForeColor = Color.Indigo
                    End If

                ElseIf tipo.Equals("N") Then ''normal
                    If resultado.Equals("T") Then ''Tiempo
                        grdAsistencia.Rows(i).Cells(dias(cont).ToString).Appearance.ForeColor = Color.Black
                    ElseIf resultado.Equals("ME") Then ''Menor
                        grdAsistencia.Rows(i).Cells(dias(cont).ToString).Appearance.ForeColor = Color.Goldenrod
                    ElseIf resultado.Equals("MA") Then ''Mayor
                        grdAsistencia.Rows(i).Cells(dias(cont).ToString).Appearance.ForeColor = Color.DarkOrange
                    ElseIf resultado.Equals("AN") Then 'anticipado
                        grdAsistencia.Rows(i).Cells(dias(cont).ToString).Appearance.ForeColor = Color.DarkCyan
                    ElseIf resultado.Equals("P") Then ''Permiso
                        registroNota = "Permiso"
                        grdAsistencia.Rows(i).Cells(dias(cont).ToString).Appearance.ForeColor = Color.Blue
                    ElseIf resultado.Equals("E") Then ''Excepcion
                        registroNota = "Excepcion"
                        grdAsistencia.Rows(i).Cells(dias(cont).ToString).Appearance.ForeColor = Color.DeepSkyBlue
                    ElseIf resultado.Equals("SC") Then ''Comida
                        grdAsistencia.Rows(i).Cells(dias(cont).ToString).Appearance.ForeColor = Color.Indigo
                    End If
                End If



                If nota <> "" Then
                    grdAsistencia.Rows(i).Cells(dias(cont).ToString).ToolTipText = registroNota + vbCr + " Nota: " + nota
                End If



                ''crea no registros
                fechaColumna = fechaDias(cont).ToString
                numeroDia = fechaColumna.DayOfWeek
                'horaTerminoBloque = grdAsistencia.Rows(i).Cells("terminobloque").Value.ToString 'comentar
                ''horaTerminoBloque = "11:00:00"
                'resul = DateTime.Compare(Now.ToShortDateString, fechaColumna.ToShortDateString)
                'If resul >= 0 Then
                If numeroDia <> 0 Then
                    'If horaActual >= horaTerminoBloque.ToLongTimeString Then ' comentar

                    ''checa solo regresos y falta en sabado
                    If i >= 2 And numeroDia = 6 Then

                        If checaBloque = 1 And hora = "" And numeroDia = 6 And (grdAsistencia.Rows(i).Cells("bloque").Value.ToString.Equals("REGRESO") Or grdAsistencia.Rows(i).Cells("bloque").Value.ToString.Equals("3")) And (grdAsistencia.Rows(i - 1).Cells("bloque").Value.ToString.Equals("REGRESO") Or grdAsistencia.Rows(i - 1).Cells("bloque").Value.ToString.Equals("3")) Then
                            grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value = "NO REGISTRO"
                        End If

                    End If
                    ''
                    Dim col As Int32 = grdAsistencia.Rows(i).Cells("codr_colaboradorid").Value
                    'Yazmin Rocha (21/04/2016) No colocar "No registro", segun el horario establecido al colaborador
                    Dim tabla As DataTable
                    Dim horaS As DateTime
                    If numeroDia = 6 Then
                        tabla = controlAsistenciaBU.buscarHorarioSabado(col, numeroDia)
                        horaS = tabla.Rows.Item(0).Item("dh_hora_check").ToString
                    End If

                    If hora = "" And numeroDia = 6 And (grdAsistencia.Rows(i).Cells("bloque").Value.ToString.Equals("1") Or grdAsistencia.Rows(i).Cells("bloque").Value.ToString.Equals("ENTRADA")) Then
                        If horaS.Hour > 0 Then
                            grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value = "NO REGISTRO"
                        Else
                            grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value = " "
                        End If

                        'grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value = "NO REGISTRO"
                    End If

                    If checaBloque = 1 And hora = "" Then
                        If numeroDia = 6 And (grdAsistencia.Rows(i).Cells("bloque").Value.ToString.Equals("3") Or grdAsistencia.Rows(i).Cells("bloque").Value.ToString.Equals("REGRESO")) Then
                        Else
                            If numeroDia = 6 And horaS.Hour = 0 Then
                                grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value = " "
                            Else
                                grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value = "NO REGISTRO"
                            End If
                            'grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value = "NO REGISTRO"
                        End If
                    End If
                    'Yazmin Rocha (21/04/2016) Fin


                    If grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value.Equals("NO REGISTRO") Then
                        grdAsistencia.Rows(i).Cells(dias(cont).ToString).Appearance.ForeColor = Color.Maroon
                    End If
                    'ElseIf horaActual >= horaTerminoBloque.ToLongTimeString Or resul > 0 Then ''inicia comentar
                    '    Dim tabla As DataTable
                    '    Dim horaS As DateTime
                    '    If numeroDia = 6 Then
                    '        tabla = controlAsistenciaBU.buscarHorarioSabado(col2, numeroDia)
                    '        horaS = tabla.Rows.Item(0).Item("dh_hora_check").ToString
                    '    End If

                    '    If hora = "" And numeroDia = 6 And (grdAsistencia.Rows(i).Cells("bloque").Value.ToString.Equals("1") Or grdAsistencia.Rows(i).Cells("bloque").Value.ToString.Equals("ENTRADA")) Then
                    '        If horaS.Hour > 0 Then
                    '            grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value = "NO REGISTRO"
                    '        Else
                    '            grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value = " "
                    '        End If
                    '        'grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value = "NO REGISTRO"
                    '    End If

                    '    If checaBloque = 1 And hora = "" Then
                    '        If numeroDia = 6 And (grdAsistencia.Rows(i).Cells("bloque").Value.ToString.Equals("3") Or grdAsistencia.Rows(i).Cells("bloque").Value.ToString.Equals("REGRESO")) Then
                    '        Else
                    '            If numeroDia = 6 And horaS.Hour = 0 Then
                    '                grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value = " "
                    '            Else
                    '                grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value = "NO REGISTRO"
                    '            End If
                    '            'grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value = "NO REGISTRO"
                    '        End If

                    '    End If

                    '    ''checa solo regresos y falta en sabado
                    '    If i >= 2 And numeroDia = 6 Then

                    '        If checaBloque = 1 And hora = "" And numeroDia = 6 And (grdAsistencia.Rows(i).Cells("bloque").Value.ToString.Equals("REGRESO") Or grdAsistencia.Rows(i).Cells("bloque").Value.ToString.Equals("3")) And (grdAsistencia.Rows(i - 1).Cells("bloque").Value.ToString.Equals("REGRESO") Or grdAsistencia.Rows(i - 1).Cells("bloque").Value.ToString.Equals("3")) Then
                    '            grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value = "NO REGISTRO"
                    '        End If

                    '    End If
                    '    ''

                    '    If grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value.Equals("NO REGISTRO") Then
                    '        grdAsistencia.Rows(i).Cells(dias(cont).ToString).Appearance.ForeColor = Color.Maroon
                    '    End If

                    'End If 'fin comentar
                End If ''if termino de dia de domingo
                'End If 'comentar
            Next
        Next
        calcularResumen()
    End Sub

    Private Sub calcularResumen()
        Dim faltas As Double = 0.0
        Dim permisos As Int32 = 0
        Dim retardoMayor As Int32 = 0
        Dim idPermiso As Int32
        Dim objBU As New Negocios.ControlAsistenciaBU
        Dim dtIncentivos As New DataTable
        Dim ganaCaja, ganaPuntualidad As Boolean
        Dim retardoMenor As Int32 = 0
        Dim idcolaborador As Int32 = 0
        Dim asistencias As Double = 0.0


        For cont = 0 To dias.Length - 1
            For i As Int32 = 0 To grdAsistencia.Rows.Count - 1

                ''no registros
                If LTrim(RTrim(grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value)).Equals("NO REGISTRO") Then
                    faltas = 0
                    If CDate(fechaDias(cont).ToString).DayOfWeek = 6 Then

                        If i < grdAsistencia.Rows.Count - 1 Then
                            'checa regresos en sabado
                            If grdAsistencia.Rows(i + 1).Cells("Bloque").Value = "REGRESO" And grdAsistencia.Rows(i + 1).Cells(dias(cont).ToString).Value <> "" Then
                                faltas = CDbl(grdAsistencia.Rows(i).Cells("faltas").Value.ToString) + 0.5
                                grdAsistencia.Rows(i).Cells("faltas").Value = CDbl(faltas.ToString)
                            Else
                                faltas = CDbl(grdAsistencia.Rows(i).Cells("faltas").Value.ToString) + 1
                                grdAsistencia.Rows(i).Cells("faltas").Value = CDbl(faltas.ToString)
                            End If
                        End If

                    Else
                        Dim colaborador As Int32 = grdAsistencia.Rows(i).Cells("codr_colaboradorid").Value

                        If i <= grdAsistencia.Rows.Count - 1 Then
                            If grdAsistencia.Rows(i).Cells("BLOQUE").Value = "ENTRADA" Then
                                If grdAsistencia.Rows(i).Cells("checaBloque").Value = 0 Or grdAsistencia.Rows(i + 1).Cells("checaBloque").Value = 0 Then
                                    faltas = CDbl(grdAsistencia.Rows(i).Cells("faltas").Value.ToString) + 1
                                Else
                                    faltas = CDbl(grdAsistencia.Rows(i).Cells("faltas").Value.ToString) + 0.5
                                End If
                            ElseIf grdAsistencia.Rows(i).Cells("BLOQUE").Value = "REGRESO" Then
                                If i >= 1 Then
                                    If grdAsistencia.Rows(i).Cells("checaBloque").Value = 0 Or grdAsistencia.Rows(i - 1).Cells("checaBloque").Value = 0 Then
                                        faltas = CDbl(grdAsistencia.Rows(i).Cells("faltas").Value.ToString) + 1
                                    Else
                                        faltas = CDbl(grdAsistencia.Rows(i).Cells("faltas").Value.ToString) + 0.5
                                    End If
                                End If
                            End If
                        End If

                        'If i < grdAsistencia.Rows.Count - 1 Then
                        '    If grdAsistencia.Rows(i).Cells("checaBloque").Value = 0 Or grdAsistencia.Rows(i + 1).Cells("checaBloque").Value = 0 Then
                        '        faltas = CDbl(grdAsistencia.Rows(i).Cells("faltas").Value.ToString) + 1
                        '    Else

                        '        ''checa solo regresos 
                        '        If i > 1 Then
                        '            If grdAsistencia.Rows(i).Cells("BLOQUE").Value = "REGRESO" And grdAsistencia.Rows(i - 1).Cells("BLOQUE").Value = "REGRESO" Then
                        '                faltas = CDbl(grdAsistencia.Rows(i).Cells("faltas").Value.ToString) + 1
                        '            ElseIf grdAsistencia.Rows(i).Cells("BLOQUE").Value = "ENTRADA" And grdAsistencia.Rows(i + 1).Cells("BLOQUE").Value = "ENTRADA" Then
                        '                faltas = CDbl(grdAsistencia.Rows(i).Cells("faltas").Value.ToString) + 1
                        '            Else
                        '                faltas = CDbl(grdAsistencia.Rows(i).Cells("faltas").Value.ToString) + 0.5
                        '            End If
                        '        ElseIf i = 0 Then
                        '            faltas = CDbl(grdAsistencia.Rows(i).Cells("faltas").Value.ToString) + 0.5
                        '        End If


                        '    End If
                        'Else

                        '    If i > 1 Then
                        '        If grdAsistencia.Rows(i).Cells("BLOQUE").Value = "REGRESO" And grdAsistencia.Rows(i - 1).Cells("BLOQUE").Value = "REGRESO" Then
                        '            faltas = CDbl(grdAsistencia.Rows(i).Cells("faltas").Value.ToString) + 1
                        '        Else
                        '            faltas = CDbl(grdAsistencia.Rows(i).Cells("faltas").Value.ToString) + 0.5
                        '        End If
                        '    End If
                        'End If


                        grdAsistencia.Rows(i).Cells("faltas").Value = faltas
                    End If
                    ''permiso
                Else

                    ''asistencias
                    asistencias = 0
                    If grdAsistencia.Rows(i).Cells(dias(cont).ToString).Value <> "" Then
                        If CDate(fechaDias(cont).ToString).DayOfWeek = 6 Then
                            asistencias = CDbl(grdAsistencia.Rows(i).Cells("asistencia").Value.ToString) + 1
                        Else
                            If i < grdAsistencia.Rows.Count - 1 Then
                                If grdAsistencia.Rows(i).Cells("BLOQUE").Value = "ENTRADA" Then
                                    If grdAsistencia.Rows(i).Cells("checaBloque").Value = 0 Or grdAsistencia.Rows(i + 1).Cells("checaBloque").Value = 0 Then
                                        asistencias = CDbl(grdAsistencia.Rows(i).Cells("asistencia").Value.ToString) + 1
                                    Else
                                        asistencias = CDbl(grdAsistencia.Rows(i).Cells("asistencia").Value.ToString) + 0.5
                                    End If
                                ElseIf grdAsistencia.Rows(i).Cells("BLOQUE").Value = "REGRESO" Then
                                    If i > 1 Then
                                        If grdAsistencia.Rows(i).Cells("checaBloque").Value = 0 Or grdAsistencia.Rows(i - 1).Cells("checaBloque").Value = 0 Then
                                            asistencias = CDbl(grdAsistencia.Rows(i).Cells("asistencia").Value.ToString) + 1
                                        Else
                                            asistencias = CDbl(grdAsistencia.Rows(i).Cells("asistencia").Value.ToString) + 0.5
                                        End If
                                    Else
                                        asistencias = CDbl(grdAsistencia.Rows(i).Cells("asistencia").Value.ToString) + 0.5
                                    End If
                                End If
                            Else
                                asistencias = CDbl(grdAsistencia.Rows(i).Cells("asistencia").Value.ToString) + 0.5
                            End If
                        End If

                        grdAsistencia.Rows(i).Cells("asistencia").Value = asistencias
                    End If






                    'If i < grdAsistencia.Rows.Count - 1 Then
                    '    If grdAsistencia.Rows(i).Cells("BLOQUE").Value = "ENTRADA" And grdAsistencia.Rows(i + 1).Cells("BLOQUE").Value = "REGRESO" Then
                    '        If CDate(fechaDias(cont).ToString).DayOfWeek = 6 Then
                    '            asistencias = CDbl(grdAsistencia.Rows(i).Cells("asistencia").Value.ToString) + 1

                    '        Else
                    '            asistencias = CDbl(grdAsistencia.Rows(i).Cells("asistencia").Value.ToString) + 0.5
                    '        End If

                    '        grdAsistencia.Rows(i).Cells("asistencia").Value = asistencias


                    '    Else
                    '        If grdAsistencia.Rows(i).Cells("BLOQUE").Value = "REGRESO" Then
                    '            If CDate(fechaDias(cont).ToString).DayOfWeek <> 6 Then
                    '                grdAsistencia.Rows(i).Cells("asistencia").Value = CDbl(grdAsistencia.Rows(i).Cells("asistencia").Value.ToString) + 0.5
                    '            End If
                    '        Else
                    '            grdAsistencia.Rows(i).Cells("asistencia").Value = CDbl(grdAsistencia.Rows(i).Cells("asistencia").Value.ToString) + 1
                    '        End If

                    '    End If
                    'Else
                    '    If grdAsistencia.Rows(i).Cells("BLOQUE").Value = "REGRESO" Then
                    '        If CDate(fechaDias(cont).ToString).DayOfWeek <> 6 Then
                    '            grdAsistencia.Rows(i).Cells("asistencia").Value = CDbl(grdAsistencia.Rows(i).Cells("asistencia").Value.ToString) + 0.5
                    '        End If
                    '    Else
                    '        grdAsistencia.Rows(i).Cells("asistencia").Value = CDbl(grdAsistencia.Rows(i).Cells("asistencia").Value.ToString) + 1
                    '    End If

                    'End If
                    ''permisos
                    Dim colaborador As Int32 = grdAsistencia.Rows(i).Cells("codr_colaboradorid").Value
                    If grdAsistencia.Rows(i).Cells(dias(cont).ToString + "TIPO").Value.Equals("P") Or grdAsistencia.Rows(i).Cells(dias(cont).ToString + "TIPO").Value.Equals("E") Then
                        permisos = CInt(grdAsistencia.Rows(i).Cells("permisos").Value.ToString) + 1
                        'idPermiso = grdAsistencia.Rows(i).Cells(dias(cont).ToString + "ID").Value.ToString
                        grdAsistencia.Rows(i).Cells("permisos").Value = permisos.ToString

                        ''retardo mayor
                        If grdAsistencia.Rows(i).Cells(dias(cont).ToString + "TIPO").Value.Equals("MA") Then
                            retardoMayor = CInt(grdAsistencia.Rows(i).Cells("retardoMayor").Value.ToString) + 1
                            grdAsistencia.Rows(i).Cells("retardoMayor").Value = retardoMayor.ToString
                        End If

                        ''retardos menores
                        If grdAsistencia.Rows(i).Cells(dias(cont).ToString + "TIPO").Value.Equals("ME") Then

                            retardoMenor = CInt(grdAsistencia.Rows(i).Cells("retardoMenor").Value.ToString) + 1
                            grdAsistencia.Rows(i).Cells("retardoMenor").Value = retardoMenor.ToString
                        End If
                    Else
                        ''retardos mayores
                        If grdAsistencia.Rows(i).Cells(dias(cont).ToString + "TIPO").Value.Equals("MA") Then

                            'se comenta por solicitud de juanita
                            ' si tiene retardo al regreso de comida pierde los incentivos
                            'If cmbNave.SelectedValue = 43 Or cmbNave.SelectedValue = 73 Then
                            retardoMayor = CInt(grdAsistencia.Rows(i).Cells("retardoMayor").Value.ToString) + 1
                                grdAsistencia.Rows(i).Cells("retardoMayor").Value = retardoMayor.ToString
                            'Else
                            '    Dim Entra As String = ""
                            '    If grdAsistencia.Rows(i).Cells("BLOQUE").Value = "ENTRADA" Then
                            '        retardoMayor = CInt(grdAsistencia.Rows(i).Cells("retardoMayor").Value.ToString) + 1
                            '        grdAsistencia.Rows(i).Cells("retardoMayor").Value = retardoMayor.ToString
                            '    Else
                            '        retardoMayor = 0
                            '    End If
                            'End If

                        Else
                            ''retardos menores
                            If grdAsistencia.Rows(i).Cells(dias(cont).ToString + "TIPO").Value.Equals("ME") Then

                                retardoMenor = CInt(grdAsistencia.Rows(i).Cells("retardoMenor").Value.ToString) + 1
                                grdAsistencia.Rows(i).Cells("retardoMenor").Value = retardoMenor.ToString
                            End If

                        End If
                    End If
                End If
            Next
        Next

        Dim cantidadD As Double = 0.0
        For i As Int32 = grdAsistencia.Rows.Count - 1 To 0 Step -1
            If grdAsistencia.Rows(i).Cells("BLOQUE").Value = "REGRESO" Then
                cantidadD = CDbl(grdAsistencia.Rows(i).Cells("FALTAS").Value)
                If i > 0 Then
                    If grdAsistencia.Rows(i - 1).Cells("BLOQUE").Value = "ENTRADA" Then


                        'faltas
                        grdAsistencia.Rows(i - 1).Cells("FALTAS").Value = CDbl(grdAsistencia.Rows(i - 1).Cells("FALTAS").Value) + cantidadD
                        grdAsistencia.Rows(i).Cells("FALTAS").Appearance.ForeColor = Color.White

                        cantidadD = 0
                        'asistencia
                        grdAsistencia.Rows(i - 1).Cells("asistencia").Value = grdAsistencia.Rows(i - 1).Cells("asistencia").Value + grdAsistencia.Rows(i).Cells("asistencia").Value
                        grdAsistencia.Rows(i).Cells("asistencia").Appearance.ForeColor = Color.White

                        'retardo menor
                        grdAsistencia.Rows(i - 1).Cells("RetardoMenor").Value = grdAsistencia.Rows(i - 1).Cells("RetardoMenor").Value + grdAsistencia.Rows(i).Cells("RetardoMenor").Value
                        grdAsistencia.Rows(i).Cells("RetardoMenor").Appearance.ForeColor = Color.White

                        'retardo mayor
                        grdAsistencia.Rows(i - 1).Cells("RetardoMayor").Value = grdAsistencia.Rows(i - 1).Cells("RetardoMayor").Value + grdAsistencia.Rows(i).Cells("RetardoMayor").Value
                        grdAsistencia.Rows(i).Cells("RetardoMayor").Appearance.ForeColor = Color.White

                        'permisos
                        grdAsistencia.Rows(i - 1).Cells("permisos").Value = grdAsistencia.Rows(i - 1).Cells("permisos").Value + grdAsistencia.Rows(i).Cells("permisos").Value
                        grdAsistencia.Rows(i).Cells("permisos").Appearance.ForeColor = Color.White
                    End If
                End If
            End If
        Next

        For i As Int32 = 0 To grdAsistencia.Rows.Count - 1
            If grdAsistencia.Rows(i).Cells("BLOQUE").Value = "ENTRADA" Then
                ''faltas
                If grdAsistencia.Rows(i).Cells("FALTAS").Value > 0 Then
                    grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                    grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                Else
                    ''permisos
                    Dim colaborador As Int32 = grdAsistencia.Rows(i).Cells("codr_colaboradorid").Value
                    Dim banderaCaja As Boolean = True
                    Dim banderaAsis As Boolean = True
                    If grdAsistencia.Rows(i).Cells("permisos").Value > 0 Then
                        For cont = 0 To dias.Length - 1
                            For x As Int32 = 0 To grdAsistencia.Rows.Count - 1
                                If grdAsistencia.Rows(x).Cells("codr_colaboradorid").Value = colaborador And (grdAsistencia.Rows(x).Cells(dias(cont).ToString + "TIPO").Value.Equals("P") Or grdAsistencia.Rows(x).Cells(dias(cont).ToString + "TIPO").Value.Equals("E")) Then
                                    idPermiso = grdAsistencia.Rows(x).Cells(dias(cont).ToString + "ID").Value.ToString



                                    dtIncentivos = objBU.BuscarIncentivosPermisos(idPermiso)

                                    If dtIncentivos.Rows.Count > 0 Then
                                        ganaPuntualidad = CBool(dtIncentivos.Rows(0).Item("puntualidad").ToString)
                                        ganaCaja = CBool(dtIncentivos.Rows(0).Item("caja").ToString)
                                    End If

                                    If ganaCaja = False And ganaPuntualidad = False Then
                                        grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                                        grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                                    ElseIf ganaCaja = True And ganaPuntualidad = False And (banderaAsis = True Or banderaCaja = True) Then
                                        grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                                        grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.DarkGreen
                                    ElseIf ganaPuntualidad = True And ganaCaja = False And (banderaAsis = True Or banderaCaja = True) Then
                                        grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.DarkGreen
                                        grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                                    ElseIf ganaCaja = True And ganaPuntualidad = True And (banderaAsis = True Or banderaCaja = True) Then
                                        grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.DarkGreen
                                        grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.DarkGreen
                                    End If

                                    If grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon Then
                                        banderaAsis = False
                                    ElseIf grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.DarkGreen Then
                                        banderaAsis = True
                                    End If
                                    If grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon Then
                                        banderaCaja = False
                                    ElseIf grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.DarkGreen Then
                                        banderaCaja = True

                                    End If

                                End If
                            Next

                        Next
                        'dtIncentivos = objBU.BuscarIncentivosPermisos(idPermiso)
                        'If dtIncentivos.Rows.Count > 0 Then
                        '    ganaPuntualidad = CBool(dtIncentivos.Rows(0).Item("puntualidad").ToString)
                        '    ganaCaja = CBool(dtIncentivos.Rows(0).Item("caja").ToString)
                        'End If
                        'If ganaCaja = False And ganaPuntualidad = False Then
                        '    grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                        '    grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                        'ElseIf ganaCaja = True And ganaPuntualidad = False Then
                        '    grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                        '    grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.DarkGreen
                        'ElseIf ganaPuntualidad = True And ganaCaja = False Then
                        '    grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.DarkGreen
                        '    grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                        'ElseIf ganaCaja = True And ganaPuntualidad = True Then
                        '    grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.DarkGreen
                        '    grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.DarkGreen
                        'End If
                        ''retardo mayor
                        If grdAsistencia.Rows(i).Cells("retardoMayor").Value > 0 Then
                            grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                            grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                        Else

                            ''retardo menor
                            If grdAsistencia.Rows(i).Cells("retardoMenor").Value = 1 Then
                                'comentado comercializadora ya pierde incentivos
                                'If cmbNave.SelectedValue = 43 Then
                                '    grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.DarkGreen
                                '    grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                                'Else
                                '    grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                                '    grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                                'End If
                                grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                                grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                            ElseIf grdAsistencia.Rows(i).Cells("retardoMenor").Value > 1 Then
                                grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                                grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                            ElseIf grdAsistencia.Rows(i).Cells("retardoMenor").Value = 0 And grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.DarkGreen And grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.DarkGreen Then
                                grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.DarkGreen
                                grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.DarkGreen
                            End If
                        End If

                    Else
                        ''retardo Mayor
                        If grdAsistencia.Rows(i).Cells("retardoMayor").Value > 0 Then
                            grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                            grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                        Else
                            If grdAsistencia.Rows(i).Cells("retardoMenor").Value = 1 Then
                                'comentado comercializadora ya pierde incentivos
                                'If cmbNave.SelectedValue = 43 Then
                                '    grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.DarkGreen
                                '    grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                                'Else
                                '    grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                                '    grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                                'End If
                                grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                                grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                            ElseIf grdAsistencia.Rows(i).Cells("retardoMenor").Value > 1 Then
                                grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                                grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                            ElseIf grdAsistencia.Rows(i).Cells("retardoMenor").Value = 0 Then
                                grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.DarkGreen
                                grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.DarkGreen
                            End If
                        End If
                    End If
                End If
            End If
            If i > 1 Then
                'mismas instrucciones pero es para quien solo checa regresos
                If grdAsistencia.Rows(i).Cells("BLOQUE").Value = "REGRESO" And grdAsistencia.Rows(i - 1).Cells("BLOQUE").Value = "REGRESO" Then
                    ''faltas
                    If grdAsistencia.Rows(i).Cells("FALTAS").Value > 0 Then
                        grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                        grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                    Else
                        ''permisos
                        If grdAsistencia.Rows(i).Cells("permisos").Value > 0 Then
                            dtIncentivos = objBU.BuscarIncentivosPermisos(idPermiso)
                            If dtIncentivos.Rows.Count > 0 Then
                                ganaPuntualidad = CBool(dtIncentivos.Rows(0).Item("puntualidad").ToString)
                                ganaCaja = CBool(dtIncentivos.Rows(0).Item("caja").ToString)
                            End If
                            If ganaCaja = False And ganaPuntualidad = False Then
                                grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                                grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                            ElseIf ganaCaja = True And ganaPuntualidad = False Then
                                grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                                grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.DarkGreen
                            ElseIf ganaPuntualidad = True And ganaCaja = False Then
                                grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.DarkGreen
                                grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                            ElseIf ganaCaja = True And ganaPuntualidad = True Then
                                grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.DarkGreen
                                grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.DarkGreen
                            End If
                            ''retardo mayor
                            If grdAsistencia.Rows(i).Cells("retardoMayor").Value > 0 Then
                                grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                                grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon

                            End If
                        Else
                            ''retardo Mayor
                            If grdAsistencia.Rows(i).Cells("retardoMayor").Value > 0 Then
                                grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                                grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                            Else
                                If grdAsistencia.Rows(i).Cells("retardoMenor").Value = 1 Then
                                    'comentado comercializadora ya pierde incentivos
                                    'If cmbNave.SelectedValue = 43 Then
                                    '    grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.DarkGreen
                                    '    grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                                    'Else
                                    '    grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                                    '    grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                                    'End If
                                    grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                                    grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                                ElseIf grdAsistencia.Rows(i).Cells("retardoMenor").Value > 1 Then
                                    grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.Maroon
                                    grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.Maroon
                                ElseIf grdAsistencia.Rows(i).Cells("retardoMenor").Value = 0 Then
                                    grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.DarkGreen
                                    grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.DarkGreen
                                End If
                            End If
                        End If
                    End If
                    'terminan condiciones de pintado
                End If
            End If
        Next
    End Sub

    Private Sub crearRegistroManual()
        Dim registro As New RegistroManualForm
        Dim idRegistro As Int32 = 0
        Dim idColaborador As Int32 = 0
        Dim nombreColaborador As String = ""
        Dim pos1, pos2 As Int32
        Dim usuarioSesion = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
        Dim advertencia As New AdvertenciaForm

        registro.naveID = idNave
        For cont = 0 To dias.Length - 1
            For fila = 0 To grdAsistencia.Rows.Count - 1
                If (grdAsistencia.Rows(fila).Cells(dias(cont).ToString).Selected = True) Then
                    If grdAsistencia.Rows(fila).Cells(dias(cont).ToString).Value.Equals("NO REGISTRO") Then
                        idRegistro = 0
                        registro.noRegistro = True
                        If grdAsistencia.Rows(fila).Cells("bloque").Value.Equals("ENTRADA") Then
                            registro.tipo = 1
                        Else
                            registro.tipo = 3
                        End If
                    Else
                        idRegistro = grdAsistencia.Rows(fila).Cells(dias(cont).ToString + "ID").Value
                        registro.noRegistro = False
                    End If
                    registro.fecha = fechaDias(cont).ToString
                    idColaborador = grdAsistencia.Rows(fila).Cells("codr_colaboradorid").Value
                    nombreColaborador = grdAsistencia.Rows(fila).Cells("colaborador").Value
                    pos1 = fila
                    pos2 = cont
                    Exit For
                End If
            Next
        Next
        registro.registroCheckID.Add(idRegistro)
        registro.colaboradorID = idColaborador
        registro.colaboradorNombre = nombreColaborador
        registro.registroCheckNormal = True

        If idNave <> 43 And idNave <> 73 Then
            If idColaborador = usuarioSesion Then
                advertencia.mensaje = "No tiene permiso para realizar esta acción en su propio registro."
                advertencia.ShowDialog()
                grdAsistencia.Rows(pos1).Cells(dias(pos2).ToString).Appearance.ForeColor = Color.Black
            Else
                registro.ShowDialog()
                grdAsistencia.Rows(pos1).Cells(dias(pos2).ToString).Appearance.ForeColor = Color.DarkGreen
            End If
        Else
            registro.ShowDialog()
            grdAsistencia.Rows(pos1).Cells(dias(pos2).ToString).Appearance.ForeColor = Color.DarkGreen
        End If



    End Sub

    Private Sub agregarFalta()
        Dim celdaActiva As UltraGridCell = grdAsistencia.ActiveCell
        Dim columna As String = celdaActiva.Column.Header.Caption
        Dim caracter As Integer = InStr(1, columna, Chr(13).ToString)
        Dim confirmar As New ConfirmarForm
        Dim exito As New ExitoForm
        Dim errormensaje As New ErroresForm
        Dim advertencia As New AdvertenciaForm

        If caracter <> 0 Then
            If Not IsDBNull(celdaActiva.Value) Then
                If celdaActiva.Value <> "NO REGISTRO" And celdaActiva.Value <> "" Then
                    confirmar.mensaje = "¿Está seguro de agregar una falta al registro seleccionado? Esta acción no se podrá revertir."
                    If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Try
                            Dim objBU As New Negocios.ControlAsistenciaBU
                            Dim resultado As String = String.Empty
                            Dim registroId As Integer = 0
                            Dim colaboradorId As Integer = 0
                            Dim colnombre As String = String.Empty
                            Dim periodoId As Integer = 0


                            periodoId = cmbPeriodo.SelectedValue
                            colnombre = columna & "ID" 'columna.Replace(vbCrLf, "").Substring(0, caracter).ToString.Trim & "ID"
                            'colnombre = columna.Replace(vbCrLf, "")

                            If IsNumeric(grdAsistencia.Rows(celdaActiva.Row.Index).Cells(colnombre).Value) Then
                                registroId = CInt(grdAsistencia.Rows(celdaActiva.Row.Index).Cells(colnombre).Value)
                                colaboradorId = CInt(grdAsistencia.Rows(celdaActiva.Row.Index).Cells("codr_colaboradorid").Value)
                                resultado = objBU.generaFaltaAsistencia(registroId, periodoId, colaboradorId)

                                If resultado = "EXITO" Then
                                    exito.mensaje = "La falta se ha agregado correctamente, los registros se actualizarán"
                                    exito.ShowDialog()
                                    mostrarConsultaRegistros()
                                Else
                                    errormensaje.mensaje = "No se pudo agregar la falta al registro seleccionado"
                                    errormensaje.ShowDialog()
                                End If
                            Else
                                errormensaje.mensaje = "El ID del registro no es númerico."
                                errormensaje.ShowDialog()
                            End If


                        Catch ex As Exception
                            errormensaje.mensaje = "Error al agregar falta"
                            errormensaje.ShowDialog()
                        End Try
                    Else
                        advertencia.mensaje = "No se puede agregar falta a la celda seleccionada."
                        advertencia.ShowDialog()
                    End If
                End If
            End If
        Else
            advertencia.mensaje = "No se puede agregar falta a la celda seleccionada."
            advertencia.ShowDialog()
        End If


    End Sub



    Private Sub crearPermiso()
        Dim permiso As New RegistroExcepcionesAltaForm
        Dim regcheck As New Entidades.RegistroCheck
        Dim colaborador As New Entidades.Colaborador
        Dim usuarioSesion As Integer = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
        Dim depto As New Entidades.Departamentos
        Dim nave As New Entidades.Naves
        Dim advertencia As New AdvertenciaForm
        Dim pos1, pos2 As Int32

        If Not IsNothing(dias) Then
            For cont = 0 To dias.Length - 1
                For fila = 0 To grdAsistencia.Rows.Count - 1
                    If (grdAsistencia.Rows(fila).Cells(dias(cont).ToString).Selected = True) Then
                        'If grdAsistencia.Rows(fila).Cells(dias(cont).ToString).Value.Equals("P") Or grdAsistencia.Rows(fila).Cells(dias(cont).ToString).Value.Equals("E") Then
                        '    btnRevisarPermiso.Enabled = True
                        '    lblRevisarPermiso.Enabled = True
                        'Else
                        '    btnRevisarPermiso.Enabled = False
                        '    lblRevisarPermiso.Enabled = False
                        'End If

                        If grdAsistencia.Rows(fila).Cells("bloque").Value.Equals("ENTRADA") Then
                            regcheck.PCheck_Tipo = 1
                        Else
                            regcheck.PCheck_Tipo = 3
                        End If

                        If grdAsistencia.Rows(fila).Cells(dias(cont).ToString).Value.Equals("NO REGISTRO") Then
                            regcheck.PCheck_normal = CDate(fechaDias(cont).ToString).ToShortDateString + " " + CDate(Now).ToShortTimeString
                            regcheck.PId = 0
                        Else
                            regcheck.PId = grdAsistencia.Rows(fila).Cells(dias(cont).ToString + "ID").Value
                            regcheck.PCheck_normal = CDate(fechaDias(cont).ToString).ToShortDateString + " " + CDate(grdAsistencia.Rows(fila).Cells(dias(cont).ToString).Value).ToShortTimeString
                        End If

                        If grdAsistencia.Rows(fila).Cells("bloque").Value.Equals("ENTRADA") Then
                            regcheck.PCheck_Tipo = 1
                        Else
                            regcheck.PCheck_Tipo = 3
                        End If
                        permiso.RevisionRegistroExcepciones = False
                        permiso.RegistroExcepcionesPost = True
                        permiso.naveID = idNave
                        colaborador.PColaboradorid = grdAsistencia.Rows(fila).Cells("codr_colaboradorid").Value

                        regcheck.PCheck_Colaborador = colaborador
                        depto.Ddepartamentoid = grdAsistencia.Rows(fila).Cells("depto").Value
                        nave.PNaveId = idNave
                        regcheck.Pregcheck_departamento = depto
                        regcheck.Pregcheck_nave = nave

                        permiso.regCheck = regcheck
                        pos1 = fila
                        pos2 = cont
                        Exit For
                    End If
                Next
            Next

            If idNave <> 73 Then
                If colaborador.PColaboradorid = usuarioSesion Then
                    advertencia.mensaje = "No tiene permiso para realizar esta acción en su propio registro."
                    advertencia.ShowDialog()
                    grdAsistencia.Rows(pos1).Cells(dias(pos2).ToString).Appearance.ForeColor = Color.Black
                Else
                    permiso.ShowDialog()
                    grdAsistencia.Rows(pos1).Cells(dias(pos2).ToString).Appearance.ForeColor = Color.Blue
                End If

            Else

                permiso.ShowDialog()
                grdAsistencia.Rows(pos1).Cells(dias(pos2).ToString).Appearance.ForeColor = Color.Blue
            End If
        End If
    End Sub

    Private Sub revisarPermiso()
        Dim permiso As New RegistroExcepcionesAltaForm
        Dim regcheck As New Entidades.RegistroCheck
        Dim colaborador As New Entidades.Colaborador
        Dim depto As New Entidades.Departamentos
        Dim advertencia As New AdvertenciaForm
        Dim nave As New Entidades.Naves
        Dim dtDetalleRegistro As New DataTable
        Dim objRegBU As New Negocios.RegistroCheckBU
        Dim detalle As New Entidades.RegistroExcepciones

        If Not IsNothing(dias) Then
            For cont = 0 To dias.Length - 1
                For fila = 0 To grdAsistencia.Rows.Count - 1
                    If (grdAsistencia.Rows(fila).Cells(dias(cont).ToString).Selected = True) Then
                        If grdAsistencia.Rows(fila).Cells(dias(cont).ToString + "TIPO").Value.Equals("P") Or grdAsistencia.Rows(fila).Cells(dias(cont).ToString + "TIPO").Value.Equals("E") Then
                            ''metodo para ver el permiso
                            If grdAsistencia.Rows(fila).Cells("bloque").Value.Equals("ENTRADA") Then
                                regcheck.PCheck_Tipo = 1
                            Else
                                regcheck.PCheck_Tipo = 3
                            End If

                            regcheck.PId = grdAsistencia.Rows(fila).Cells(dias(cont).ToString + "ID").Value
                            regcheck.PCheck_normal = CDate(fechaDias(cont).ToString).ToShortDateString + " " + CDate(grdAsistencia.Rows(fila).Cells(dias(cont).ToString).Value).ToShortTimeString


                            If grdAsistencia.Rows(fila).Cells("bloque").Value.Equals("ENTRADA") Then
                                regcheck.PCheck_Tipo = 1
                            Else
                                regcheck.PCheck_Tipo = 3
                            End If
                            permiso.RevisionRegistroExcepciones = True
                            permiso.RegistroExcepcionesPost = False
                            permiso.naveID = idNave
                            colaborador.PColaboradorid = grdAsistencia.Rows(fila).Cells("codr_colaboradorid").Value
                            regcheck.PCheck_Colaborador = colaborador
                            depto.Ddepartamentoid = grdAsistencia.Rows(fila).Cells("depto").Value
                            nave.PNaveId = idNave
                            regcheck.Pregcheck_departamento = depto
                            regcheck.Pregcheck_nave = nave

                            dtDetalleRegistro = objRegBU.DetallesRegistro(grdAsistencia.Rows(fila).Cells(dias(cont).ToString + "ID").Value, idNave)
                            detalle.Pregexc_id = dtDetalleRegistro.Rows(0).Item("regcheck_excepcion_id").ToString
                            regcheck.PCheck_Excepcion = detalle
                            permiso.regCheck = regcheck

                            permiso.ShowDialog()
                            Exit For

                        Else
                            advertencia.mensaje = "El registro no es un permiso, no puede revisarlo"
                            advertencia.ShowDialog()
                        End If
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub validarPeriodoNomina()
        Dim periodo As Int32 = 0
        Dim objBu As New Negocios.ControlDePeriodoBU
        Dim PeriodoEditable As Boolean = False
        periodo = cmbPeriodo.SelectedValue

        If objBu.buscarPeriodoEsActivoAsistencia(periodo) Then
            PeriodoEditable = True
            btnCorte.Enabled = banderaCierre
            lblCorte.Enabled = banderaCierre
            btnAgregarFalta.Enabled = True
            lblCorte.Text = "Cerrar Semana"
            '   btnRegistroManual.Enabled = True
            '   btnPermiso.Enabled = True
        Else
            btnCorte.Enabled = False
            lblCorte.Enabled = False
            PeriodoEditable = False
            btnAgregarFalta.Enabled = False
            btnRegistroManual.Enabled = False
            btnPermiso.Enabled = False
            lblCorte.Text = "Semana Cerrada"
        End If
    End Sub

    Private Sub cierreSemanal()
        Dim advertencia As New AdvertenciaForm
        If (IsDBNull(cmbDepartamento.SelectedValue) Or IsNothing(cmbDepartamento.SelectedValue)) _
        And (IsDBNull(cmbArea.SelectedValue) Or IsNothing(cmbArea.SelectedValue)) _
        And (IsDBNull(cmbCelula.SelectedValue) Or IsNothing(cmbCelula.SelectedValue)) Then



            If validarCierreSemana() Then
                Dim mensajeExito As New ConfirmarForm

                mensajeExito.mensaje = "¿ Está seguro que no tiene incapacidades pendientes de capturar ?"
                If mensajeExito.ShowDialog = DialogResult.OK Then
                    mensajeExito.mensaje = "¿ Está seguro de cerrar el periodo de asistencia ? " + vbNewLine + "No podrá hacer modificaciones" + vbNewLine + " después del cierre."
                    If mensajeExito.ShowDialog = DialogResult.OK Then
                        btnAceptar.PerformClick()
                        guardarCorteChecador()
                    End If
                End If
            End If
        Else

            advertencia.mensaje = "Sólo puede realizar el cierre en la nave completa."
            advertencia.ShowDialog()

        End If
    End Sub

    Private Function validarCierreSemana() As Boolean
        Dim valido = False
        Try
            Dim objMensajeAdv As New Tools.AdvertenciaForm
            Dim objMsjAdv As New Tools.AdvertenciaForm
            Dim objBU As New Contabilidad.Negocios.ControlAsistenciaBU
            Dim resultado As String = String.Empty
            Dim periodoRealId As Integer = cmbPeriodo.SelectedValue
            Dim periodoFiscalId As Integer = 0
            Dim dtPatrones As New DataTable
            Dim dtMovtosPendientes As New DataTable
            Dim mensajeMovto As String = String.Empty



            dtPatrones = objBU.consultaPatronNave(idNave)
            If Not dtPatrones Is Nothing Then
                If dtPatrones.Rows.Count > 0 Then
                    For Each row As DataRow In dtPatrones.Rows
                        If objBU.consultaTieneChecador(row("PATRONID").ToString) Then
                            periodoFiscalId = objBU.obtenerPeriodoNominaFiscalPeriodo(periodoRealId)
                            If periodoFiscalId <> 0 Then
                                dtMovtosPendientes = objBU.consultaMovimientosPendientes(row("PATRONID").ToString, periodoFiscalId, idNave)
                                If dtMovtosPendientes.Rows.Count = 0 Then
                                    resultado = objBU.validaCierreChecador(periodoFiscalId)
                                    If resultado <> "Correcto" Then
                                        objMensajeAdv.mensaje = resultado
                                        objMensajeAdv.ShowDialog()
                                    Else
                                        valido = True
                                    End If
                                Else
                                    mensajeMovto = "No fue posible realizar el cierre debido a que existen movtos pendientes en: "
                                    For Each rowMovto As DataRow In dtMovtosPendientes.Rows
                                        mensajeMovto += rowMovto.Item("movimiento") + ","
                                    Next
                                    objMensajeAdv.mensaje = mensajeMovto.Substring(0, mensajeMovto.Length - 1)
                                    objMensajeAdv.ShowDialog()
                                    Me.Dispose()
                                End If
                            Else
                                objMsjAdv.mensaje = "No se encontró periodo de nómina fiscal para la nave seleccionada."
                                objMsjAdv.ShowDialog()
                                valido = False
                            End If
                            valido = True
                        End If
                    Next

                    'Agregar validaciones de nómina real
                    Dim objCA_BU As New Negocios.ControlAsistenciaBU
                    resultado = String.Empty
                    resultado = objCA_BU.validaCierreAsistenciaNR(periodoRealId)

                    If resultado <> "Correcto" Then
                        objMensajeAdv.mensaje = resultado
                        objMensajeAdv.ShowDialog()
                        valido = False
                    Else
                        valido = True
                    End If
                Else
                    objMsjAdv.mensaje = "No se encontró relación de la nave con ningún patron."
                    objMsjAdv.ShowDialog()
                    valido = False
                End If
            Else
                objMsjAdv.mensaje = "No se encontró relación de la nave con ningún patron."
                objMsjAdv.ShowDialog()
                valido = False
            End If
        Catch ex As Exception
            valido = False
        End Try
        Return valido
    End Function

    Private Sub guardarCorteChecador()
        Dim corteChecadorE As New Entidades.CorteChecador
        Dim colaborador As New Entidades.Colaborador
        Dim periodoNomina As New Entidades.PeriodosNomina
        Dim objBU As New Negocios.CorteChecadorBU
        Dim exito As New ExitoForm
        Dim advetencia As New AdvertenciaForm

        Dim faltasNuevoIngreso As Double = 0
        Dim ganaCaja As Boolean = False
        Dim ganaPuntualidad As Boolean = False

        Try

            For i = 0 To grdAsistencia.Rows.Count - 1

                If grdAsistencia.Rows(i).Cells("bloque").Value.Equals("ENTRADA") Then

                    periodoNomina.PeriodoId = cmbPeriodo.SelectedValue
                    corteChecadorE.PPeriodo = periodoNomina

                    colaborador.PColaboradorid = grdAsistencia.Rows(i).Cells("codr_colaboradorid").Value
                    corteChecadorE.PColaborador = colaborador

                    corteChecadorE.PRetardo_mayor = CInt(grdAsistencia.Rows(i).Cells("retardoMayor").Value)
                    corteChecadorE.PRetardo_menor = CInt(grdAsistencia.Rows(i).Cells("retardoMenor").Value)
                    corteChecadorE.PInasistencia = CDbl(grdAsistencia.Rows(i).Cells("faltas").Value)
                    '  corteChecadorE.PAsistencia = 6 - CDbl(row.Cells("faltas").Value)
                    corteChecadorE.PAsistencia = CDbl(grdAsistencia.Rows(i).Cells("asistencia").Value)
                    If grdAsistencia.Rows(i).Cells("nuevoIngreso").Value = 1 Then
                        faltasNuevoIngreso = CDbl(grdAsistencia.Rows(i).Cells("faltas").Value)
                    End If

                    If grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.DarkGreen Then
                        ganaCaja = True
                    Else
                        ganaCaja = False
                    End If

                    If grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.DarkGreen Then
                        ganaPuntualidad = True
                    Else
                        ganaPuntualidad = False
                    End If

                    corteChecadorE.PPpuntualidad_asistencia = ganaPuntualidad
                    corteChecadorE.PCaja_Ahorro = ganaCaja

                    objBU.guardarCorteChecador(corteChecadorE, faltasNuevoIngreso)
                End If

                If i > 1 Then
                    If grdAsistencia.Rows(i).Cells("bloque").Value.Equals("REGRESO") And grdAsistencia.Rows(i - 1).Cells("bloque").Value.Equals("REGRESO") Then

                        periodoNomina.PeriodoId = cmbPeriodo.SelectedValue
                        corteChecadorE.PPeriodo = periodoNomina

                        colaborador.PColaboradorid = grdAsistencia.Rows(i).Cells("codr_colaboradorid").Value
                        corteChecadorE.PColaborador = colaborador

                        corteChecadorE.PRetardo_mayor = CInt(grdAsistencia.Rows(i).Cells("retardoMayor").Value)
                        corteChecadorE.PRetardo_menor = CInt(grdAsistencia.Rows(i).Cells("retardoMenor").Value)
                        corteChecadorE.PInasistencia = CDbl(grdAsistencia.Rows(i).Cells("faltas").Value)
                        '  corteChecadorE.PAsistencia = 6 - CDbl(row.Cells("faltas").Value)
                        corteChecadorE.PAsistencia = CDbl(grdAsistencia.Rows(i).Cells("asistencia").Value)
                        If grdAsistencia.Rows(i).Cells("nuevoIngreso").Value = 1 Then
                            faltasNuevoIngreso = CDbl(grdAsistencia.Rows(i).Cells("faltas").Value)
                        End If

                        If grdAsistencia.Rows(i).Cells("caja").Appearance.BackColor = Color.DarkGreen Then
                            ganaCaja = True
                        Else
                            ganaCaja = False
                        End If

                        If grdAsistencia.Rows(i).Cells("punyAsis").Appearance.BackColor = Color.DarkGreen Then
                            ganaPuntualidad = True
                        Else
                            ganaPuntualidad = False
                        End If

                        corteChecadorE.PPpuntualidad_asistencia = ganaPuntualidad
                        corteChecadorE.PCaja_Ahorro = ganaCaja

                        objBU.guardarCorteChecador(corteChecadorE, faltasNuevoIngreso)
                    End If

                End If


            Next

            If PermisosUsuarioBU.ConsultarPermiso("NOM_NVO_CONTROL_ASISTENCIA", "NOM_COLOCARINCENTIVOS") Then
                Dim edicionIncentivos As New ListaControlAsistencia_RecalculaIncentivos
                edicionIncentivos.PeriodoID = cmbPeriodo.SelectedValue
                edicionIncentivos.NaveID = cmbNave.SelectedValue
                edicionIncentivos.ShowDialog()
            End If


            exito.mensaje = "Periodo de asistencia cerrado con éxito"
            exito.ShowDialog()

            enviar_correo(cmbNave.SelectedValue, "ENVIO_CORTE_CHECADOR")

            cmbDepartamento.DataSource = Nothing
            cmbDepartamento.SelectedItem = 0
            cmbPeriodo.DataSource = Nothing
            cmbPeriodo.SelectedItem = 0

            grdAsistencia.DataSource = Nothing

        Catch ex As Exception
            advetencia.mensaje = "Algo surgio mal durante la operación"
            advetencia.ShowDialog()

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
                                            "<img src='" + "http://grupoyuyin.com.mx/images/SAY170.jpg" + "'style='" + "vertical-align:middle" + "' height='" + "57" + "' widht='" + "125" + "'> Periodo de asistencia " + cmbPeriodo.SelectedText +
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

    Private Sub pintarcoloresFilasGrid()
        Dim var As Int32 = 0
        Dim numeracion As Int32 = 1
        Dim vcolor As New Color
        vcolor = New Color
        vcolor = Color.White
        For i As Int32 = 0 To grdAsistencia.Rows.Count - 1
            If grdAsistencia.Rows(i).Cells("bloque").Value.Equals("ENTRADA") Then
                If i < grdAsistencia.Rows.Count - 1 Then
                    If grdAsistencia.Rows(i + 1).Cells("bloque").Value.Equals("REGRESO") Then
                        grdAsistencia.Rows(i).Cells("numeracion").Value = numeracion
                        grdAsistencia.Rows(i + 1).Cells("numeracion").Value = numeracion
                        numeracion = numeracion + 1
                    Else
                        grdAsistencia.Rows(i).Cells("numeracion").Value = numeracion
                        numeracion = numeracion + 1
                    End If
                Else
                    grdAsistencia.Rows(i).Cells("numeracion").Value = numeracion
                    numeracion = numeracion + 1
                End If


            End If
        Next

        For j As Int32 = grdAsistencia.Rows.Count - 1 To 0 Step -1


            If grdAsistencia.Rows(j).Cells("bloque").Value = "REGRESO" And vcolor = Drawing.Color.White Then
                grdAsistencia.Rows(j).Appearance.BackColor = Color.Thistle
                If j > 0 Then
                    grdAsistencia.Rows(j - 1).Appearance.BackColor = Color.Thistle
                End If
                grdAsistencia.Rows(j).Cells("FALTAS").Appearance.ForeColor = Color.Thistle
                grdAsistencia.Rows(j).Cells("retardoMenor").Appearance.ForeColor = Color.Thistle
                grdAsistencia.Rows(j).Cells("retardoMayor").Appearance.ForeColor = Color.Thistle
                grdAsistencia.Rows(j).Cells("permisos").Appearance.ForeColor = Color.Thistle
                grdAsistencia.Rows(j).Cells("asistencia").Appearance.ForeColor = Color.Thistle

                If grdAsistencia.Rows(j - 1).Cells("bloque").Value = "REGRESO" Then
                    grdAsistencia.Rows(j).Cells("FALTAS").Appearance.ForeColor = Color.Black
                    grdAsistencia.Rows(j).Cells("retardoMenor").Appearance.ForeColor = Color.Black
                    grdAsistencia.Rows(j).Cells("retardoMayor").Appearance.ForeColor = Color.Black
                    grdAsistencia.Rows(j).Cells("permisos").Appearance.ForeColor = Color.Black
                    grdAsistencia.Rows(j).Cells("asistencia").Appearance.ForeColor = Color.Black
                End If

                vcolor = Color.Thistle
            ElseIf grdAsistencia.Rows(j).Cells("bloque").Value = "REGRESO" And vcolor = Drawing.Color.Thistle Then
                grdAsistencia.Rows(j).Appearance.BackColor = Color.White
                grdAsistencia.Rows(j - 1).Appearance.BackColor = Color.White
                vcolor = Color.White
            ElseIf grdAsistencia.Rows(j).Cells("bloque").Value = "ENTRADA" And vcolor = Drawing.Color.White Then
                If (j + 1) <= grdAsistencia.Rows.Count - 1 Then
                    If grdAsistencia.Rows(j + 1).Cells("bloque").Value <> "REGRESO" Then
                        grdAsistencia.Rows(j).Appearance.BackColor = Color.Thistle
                        If j > 0 Then
                            grdAsistencia.Rows(j - 1).Appearance.BackColor = Color.Thistle
                        End If

                        grdAsistencia.Rows(j).Cells("FALTAS").Appearance.ForeColor = Color.Black
                        grdAsistencia.Rows(j).Cells("retardoMenor").Appearance.ForeColor = Color.Black
                        grdAsistencia.Rows(j).Cells("retardoMayor").Appearance.ForeColor = Color.Black
                        grdAsistencia.Rows(j).Cells("permisos").Appearance.ForeColor = Color.Black
                        grdAsistencia.Rows(j).Cells("asistencia").Appearance.ForeColor = Color.Black
                        vcolor = Color.Thistle
                    End If
                End If
            ElseIf grdAsistencia.Rows(j).Cells("bloque").Value = "ENTRADA" And vcolor = Drawing.Color.Thistle Then
                If (j + 1) <= grdAsistencia.Rows.Count - 1 Then
                    If grdAsistencia.Rows(j + 1).Cells("bloque").Value <> "REGRESO" Then
                        grdAsistencia.Rows(j).Appearance.BackColor = Color.White
                        If j > 0 Then
                            grdAsistencia.Rows(j - 1).Appearance.BackColor = Color.White
                        End If
                        vcolor = Color.White

                        grdAsistencia.Rows(j).Cells("FALTAS").Appearance.ForeColor = Color.Black
                        grdAsistencia.Rows(j).Cells("retardoMenor").Appearance.ForeColor = Color.Black
                        grdAsistencia.Rows(j).Cells("retardoMayor").Appearance.ForeColor = Color.Black
                        grdAsistencia.Rows(j).Cells("permisos").Appearance.ForeColor = Color.Black
                        grdAsistencia.Rows(j).Cells("asistencia").Appearance.ForeColor = Color.Black
                    End If
                End If
            End If
        Next

    End Sub

    Private Sub mostrarIncidencias()
        If grdAsistencia.Rows.Count > 0 Then
            For cont = 0 To dias.Length - 1
                For Each row As UltraGridRow In grdAsistencia.Rows
                    If row.Cells(dias(cont).ToString + "TIPO").Value.Equals("T") Then
                        row.Cells(dias(cont).ToString).Value = ""
                    End If
                Next
            Next
        End If


    End Sub

    Private Sub imprimirReporteListaAsistencia()
        If IsNothing(cmbDepartamento.SelectedValue) Or cmbDepartamento.SelectedValue = 0 Then Return

        Dim dtLista As New DataTable
        Dim idColaborador As Int32 = 0
        Dim colaborador As String = ""
        Dim objBUCA As New Negocios.ControlAsistenciaBU
        Dim dtPuesto As New DataTable
        Dim puesto As String = ""
        'dtLista.Columns.Add("colaborador")
        'dtLista.Columns.Add("Puesto")

        'If grdAsistencia.Rows.Count < 1 Then
        '    mostrarConsultaRegistros()
        'End If

        'For Each row As UltraGridRow In grdAsistencia.Rows
        '    If row.Cells("Bloque").Value = "ENTRADA" Then
        '        idColaborador = row.Cells("codr_colaboradorid").Value.ToString
        '        dtPuesto = objBUCA.obtenerPuestoColaborador(idColaborador)
        '        puesto = dtPuesto.Rows(0).Item("pues_nombre").ToString
        '        colaborador = row.Cells("colaborador").Value.ToString
        '        dtLista.Rows.Add(colaborador, puesto)
        '    End If

        'Next
        crearCondicionesConsulta()
        dtLista = objBUCA.colaboradorListaAsistencia(condiciones)

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

        reporte("periodo") = cmbPeriodo.Text

        Dim departamento As Object = reporte("departamento")
        reporte("departamento") = cmbDepartamento.Text

        Dim departamentoID As Object = reporte("departamentoID")
        reporte("departamentoID") = CStr(cmbDepartamento.SelectedValue)

        Dim celula As Object = reporte("celula")
        reporte("celula") = cmbCelula.Text

        Dim celulaID As Object = reporte("celulaID")
        If IsNothing(cmbCelula.SelectedValue) Or IsDBNull(cmbCelula.SelectedValue) Then
            reporte("celulaID") = "0"
        Else
            reporte("celulaID") = CStr(cmbCelula.SelectedValue)
        End If


        reporte.RegData(dtLista)
        reporte.Show()
        Me.Cursor = Cursors.Default



    End Sub

    Public Sub imprimirReporteCompleto()
        Dim dtCompleto As New DataTable
        Dim numeracion As String = ""
        Dim colaborador As String = ""
        Dim permisos As String = ""
        Dim retardoMenor As String = ""
        Dim retardoMayor As String = ""
        Dim inasistencias As String = ""
        Dim puntualidad As Boolean = False
        Dim caja As Boolean = False
        Dim punt As String = ""
        Dim cda As String = ""
        dtCompleto.Columns.Add("numeracion")
        dtCompleto.Columns.Add("colaborador")
        dtCompleto.Columns.Add("Horadia1")
        dtCompleto.Columns.Add("Horadia2")
        dtCompleto.Columns.Add("Horadia3")
        dtCompleto.Columns.Add("Horadia4")
        dtCompleto.Columns.Add("Horadia5")
        dtCompleto.Columns.Add("Horadia6")
        dtCompleto.Columns.Add("permisos")
        dtCompleto.Columns.Add("retardoMenor")
        dtCompleto.Columns.Add("retardoMayor")
        dtCompleto.Columns.Add("inasistencias")
        dtCompleto.Columns.Add("puntualidadAsistencia")
        dtCompleto.Columns.Add("cajaAhorro")
        Dim Cruz As String = "r"
        Dim diasHoras(dias.Length - 1) As String
        Dim Paloma As String = "a"
        Dim dia As String ', dia1, dia2, dia3, dia4, dia5, dia6 As String
        Dim Horadia1, Horadia2, Horadia3, Horadia4, Horadia5, Horadia6 As String
        Me.Cursor = Cursors.WaitCursor
        'dia1 = "LUNES"
        'dia2 = "MARTES"
        'dia3 = "MIÉRCOLES"
        'dia4 = "JUEVES"
        'dia5 = "VIERNES"
        'dia6 = "SÁBADO"

        If grdAsistencia.Rows.Count < 1 Then
            mostrarConsultaRegistros()
        End If

        For i As Int32 = 0 To dias.Length - 1
            diasHoras(i) = dias(i).ToString
        Next
        For Each row As UltraGridRow In grdAsistencia.Rows
            Horadia1 = String.Empty
            Horadia2 = String.Empty
            Horadia3 = String.Empty
            Horadia4 = String.Empty
            Horadia5 = String.Empty
            Horadia6 = String.Empty
            For con As Int32 = 0 To dias.Length - 1
                dia = dias(con).ToString

                'If dia = dia1 Then
                If dia = diasHoras(0) Then
                    If row.Cells(dias(con).ToString).Value.Equals("NO REGISTRO") Then
                        Horadia1 = "NR"
                    ElseIf row.Cells(dias(con).ToString).Value = " " Then
                        Horadia1 = ""
                    ElseIf row.Cells(dias(con).ToString).Value <> "" Then
                        Horadia1 = CDate(row.Cells(dias(con).ToString).Value).ToShortTimeString
                    End If

                ElseIf dia = diasHoras(1) Then
                    If row.Cells(dias(con).ToString).Value.Equals("NO REGISTRO") Then
                        Horadia2 = "NR"
                    ElseIf row.Cells(dias(con).ToString).Value = " " Then
                        Horadia2 = ""
                    ElseIf row.Cells(dias(con).ToString).Value <> "" Then
                        Horadia2 = CDate(row.Cells(dias(con).ToString).Value).ToShortTimeString
                    End If
                ElseIf dia = diasHoras(2) Then
                    If row.Cells(dias(con).ToString).Value.Equals("NO REGISTRO") Then
                        Horadia3 = "NR"
                    ElseIf row.Cells(dias(con).ToString).Value = " " Then
                        Horadia3 = ""
                    ElseIf row.Cells(dias(con).ToString).Value <> "" Then
                        Horadia3 = CDate(row.Cells(dias(con).ToString).Value).ToShortTimeString
                    End If

                ElseIf dia = diasHoras(3) Then
                    If row.Cells(dias(con).ToString).Value.Equals("NO REGISTRO") Then
                        Horadia4 = "NR"
                    ElseIf row.Cells(dias(con).ToString).Value = " " Then
                        Horadia4 = ""
                    ElseIf row.Cells(dias(con).ToString).Value <> "" Then
                        Horadia4 = CDate(row.Cells(dias(con).ToString).Value).ToShortTimeString
                    End If

                ElseIf dia = diasHoras(4) Then
                    If row.Cells(dias(con).ToString).Value.Equals("NO REGISTRO") Then
                        Horadia5 = "NR"
                    ElseIf row.Cells(dias(con).ToString).Value = " " Then
                        Horadia5 = ""
                    ElseIf row.Cells(dias(con).ToString).Value <> "" Then
                        Horadia5 = CDate(row.Cells(dias(con).ToString).Value).ToShortTimeString
                    End If

                ElseIf dia = diasHoras(5) Then
                    If row.Cells(dias(con).ToString).Value.Equals("NO REGISTRO") Then
                        Horadia6 = "NR"
                    ElseIf row.Cells(dias(con).ToString).Value = " " Then
                        Horadia6 = ""
                    ElseIf row.Cells(dias(con).ToString).Value <> "" Then
                        Horadia6 = CDate(row.Cells(dias(con).ToString).Value).ToShortTimeString
                    End If

                End If

                If row.Cells("Bloque").Value = "ENTRADA" Then
                    numeracion = row.Cells("numeracion").Value.ToString
                    colaborador = row.Cells("colaborador").Value.ToString
                    permisos = row.Cells("permisos").Value.ToString
                    retardoMenor = row.Cells("retardoMenor").Value.ToString
                    retardoMayor = row.Cells("retardoMayor").Value.ToString
                    inasistencias = row.Cells("faltas").Value.ToString
                    If row.Cells("punyAsis").Appearance.BackColor = Color.Maroon Then
                        puntualidad = False
                        punt = Cruz
                    ElseIf row.Cells("punyAsis").Appearance.BackColor = Color.DarkGreen Then
                        puntualidad = True
                        punt = Paloma
                    End If

                    If row.Cells("caja").Appearance.BackColor = Color.Maroon Then
                        caja = False
                        cda = Cruz
                    ElseIf row.Cells("caja").Appearance.BackColor = Color.DarkGreen Then
                        caja = True
                        cda = Paloma
                    End If

                ElseIf row.Cells("Bloque").Value = "REGRESO" Then
                    permisos = "NO"
                    retardoMenor = "NO"
                    retardoMayor = "NO"
                    inasistencias = "NO"
                    punt = "NO"
                    cda = "NO"
                End If

            Next
            dtCompleto.Rows.Add(numeracion, colaborador, Horadia1, Horadia2, Horadia3, Horadia4, Horadia5, Horadia6, permisos, retardoMenor, retardoMayor, inasistencias, punt, cda)
        Next



        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        EntidadReporte = OBJBU.LeerReporteporClave("NOM_CA_REPORTE_COMPLETO")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
        EntidadReporte.Pnombre + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()

        reporte("periodo") = cmbPeriodo.Text
        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
        reporte("NombreReporte") = "REPORTE_COMPLETO_ASISTENCIA_.mrt"

        Dim a As Int32 = dias.Length
        Dim var As String = ""
        For x As Int32 = 1 To dias.Length
            If x <= a Then
                var = "dia" & x
                reporte(var) = dias(x - 1).ToString
                reporte("fecha" & x) = fechaDias(x - 1).ToString
            End If
        Next

        'reporte("dia1") = dias(0).ToString
        'reporte("dia2") = dias(1).ToString
        'reporte("dia3") = dias(2).ToString
        'reporte("dia4") = dias(3).ToString
        'reporte("dia5") = dias(4).ToString
        'reporte("dia6") = diasHoras(5).ToString
        'reporte("fecha1") = fechaDias(0).ToString
        'reporte("fecha2") = fechaDias(1).ToString
        'reporte("fecha3") = fechaDias(2).ToString
        'reporte("fecha4") = fechaDias(3).ToString
        'reporte("fecha5") = fechaDias(4).ToString
        'reporte("fecha6") = fechaDias(5).ToString

        reporte.RegData(dtCompleto)
        reporte.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub imprimirReporteResumen()
        Dim dtResumen As New DataTable
        Dim numeracion As Int32 = 0
        Dim colaborador As String = ""
        Dim permisos As Int32 = 0
        Dim retardoMenor As Int32 = 0
        Dim retardoMayor As Int32 = 0
        Dim inasistencias As Double = 0.0
        Dim puntualidad As Boolean = False
        Dim caja As Boolean = False
        Dim punt As String = ""
        Dim cda As String = ""
        dtResumen.Columns.Add("numeracion")
        dtResumen.Columns.Add("colaborador")
        dtResumen.Columns.Add("permisos")
        dtResumen.Columns.Add("retardoMenor")
        dtResumen.Columns.Add("retardoMayor")
        dtResumen.Columns.Add("inasistencias")
        dtResumen.Columns.Add("puntualidadAsistencia")
        dtResumen.Columns.Add("cajaAhorro")
        Dim Cruz As String = "r"
        Dim Paloma As String = "a"

        If grdAsistencia.Rows.Count < 1 Then
            mostrarConsultaRegistros()
        End If

        Me.Cursor = Cursors.WaitCursor
        For Each row As UltraGridRow In grdAsistencia.Rows
            If row.Cells("Bloque").Value = "ENTRADA" Then
                numeracion = row.Cells("numeracion").Value.ToString
                colaborador = row.Cells("colaborador").Value.ToString
                permisos = row.Cells("permisos").Value.ToString
                retardoMenor = row.Cells("retardoMenor").Value.ToString
                retardoMayor = row.Cells("retardoMayor").Value.ToString
                inasistencias = row.Cells("faltas").Value.ToString
                If row.Cells("punyAsis").Appearance.BackColor = Color.Maroon Then
                    puntualidad = False
                    punt = Cruz
                ElseIf row.Cells("punyAsis").Appearance.BackColor = Color.DarkGreen Then
                    puntualidad = True
                    punt = Paloma
                End If

                If row.Cells("caja").Appearance.BackColor = Color.Maroon Then
                    caja = False
                    cda = Cruz
                ElseIf row.Cells("caja").Appearance.BackColor = Color.DarkGreen Then
                    caja = True
                    cda = Paloma
                End If

                dtResumen.Rows.Add(numeracion, colaborador, permisos, retardoMenor, retardoMayor, inasistencias, punt, cda)
            End If
        Next

        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        EntidadReporte = OBJBU.LeerReporteporClave("NOM_CA_REPORTE_RESUMEN")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
        EntidadReporte.Pnombre + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()

        Dim periodo As Object = reporte("periodo")
        reporte("periodo") = cmbPeriodo.Text

        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
        reporte("NombreReporte") = "REPORTE_RESUMEN_ASISTENCIA.mrt"

        reporte.RegData(dtResumen)
        reporte.Show()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub formatoGrid()
        With grdAsistencia.DisplayLayout.Bands(0)
            .Columns("numeracion").Header.Caption = "#"
            .Columns("codr_colaboradorid").Hidden = True
            .Columns("real_fecha").Hidden = True
            .Columns("nuevoIngreso").Hidden = True
            .Columns("regcheck_tipo_check").Hidden = True
            .Columns("codr_colaboradorid1").Hidden = True
            .Columns("checaBloque").Hidden = True
            .Columns("codr_colaboradorid2").Hidden = True
            .Columns("regcheck_tipo_check1").Hidden = True
            .Columns("terminoBloque").Hidden = True
            .Columns("depto").Hidden = True
            .Columns("retardoMenor").Hidden = True

            .Columns("asistencia").Hidden = True
            '.Columns("asistencia").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("colaborador").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("bloque").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Colaborador").Header.Caption = "Colaborador"
            .Columns("bloque").Header.Caption = "Bloque"

            .Columns("retardoMenor").Header.Caption = "rm"
            .Columns("retardoMayor").Header.Caption = "RM"
            .Columns("permisos").Header.Caption = "P"
            .Columns("faltas").Header.Caption = "F"
            .Columns("punyAsis").Header.Caption = "PyA"
            .Columns("caja").Header.Caption = "CdA"

            .Columns("retardoMenor").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("retardoMayor").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("permisos").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("faltas").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("punyAsis").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("caja").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("retardoMenor").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("retardoMayor").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("permisos").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("faltas").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("punyAsis").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("caja").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("bloque").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left

            Dim numDias As Integer = 0
            numDias = dias.Length

            .Columns("permisos").Header.VisiblePosition = 16 + numDias
            .Columns("retardoMenor").Header.VisiblePosition = 17 + numDias
            .Columns("retardoMayor").Header.VisiblePosition = 18 + numDias
            .Columns("faltas").Header.VisiblePosition = 19 + numDias
            .Columns("punyAsis").Header.VisiblePosition = 20 + numDias
            .Columns("caja").Header.VisiblePosition = 21 + numDias

            .ColHeaderLines = 2

            For cont = 0 To dias.Length - 1
                If dias(cont).ToString <> Nothing Then
                    .Columns(dias(cont).ToString).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    .Columns(dias(cont).ToString + "TIPO").Hidden = True
                    .Columns(dias(cont).ToString + "ID").Hidden = True
                    .Columns(dias(cont).ToString).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                    .Columns(dias(cont).ToString).AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
                    .Columns(dias(cont).ToString).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                End If
            Next


            .Columns("colaborador").MergedCellStyle = MergedCellContentArea.VisibleRect
            .Columns("colaborador").MergedCellStyle = MergedCellStyle.Always
            .Columns("colaborador").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameText
            .Columns("numeracion").MergedCellStyle = MergedCellStyle.Always
            .Columns("numeracion").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameText


            .Columns("retardoMenor").CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
            .Columns("retardoMayor").CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
            .Columns("permisos").CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
            .Columns("faltas").CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
            .Columns("punyAsis").CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
            .Columns("caja").CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle



            .Columns("retardoMenor").Hidden = True
            .Columns("retardoMayor").Hidden = True
            .Columns("permisos").Hidden = True
            .Columns("faltas").Hidden = True
            .Columns("punyAsis").Hidden = True
            .Columns("caja").Hidden = True

            .Columns("retardoMenor").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("retardoMayor").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("permisos").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("faltas").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("punyAsis").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("caja").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("faltas").Format = "###,###,##0.0"
            .Columns("asistencia").Format = "###,###,##0.0"

            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)


        End With



        'grdAsistencia.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdAsistencia.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        grdAsistencia.DisplayLayout.Override.RowSelectorWidth = 35
        grdAsistencia.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdAsistencia.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        grdAsistencia.DisplayLayout.Appearance.BorderColor = Color.SteelBlue

        'grdAsistencia.DisplayLayout.Override.DefaultRowHeight = 30

        grdAsistencia.Rows(0).Selected = True

        grdAsistencia.DisplayLayout.Bands(0).Columns("bloque").Width = 100
        grdAsistencia.DisplayLayout.Bands(0).Columns("colaborador").Width = 300

        grdAsistencia.DisplayLayout.Bands(0).Columns("retardoMenor").Width = 30
        grdAsistencia.DisplayLayout.Bands(0).Columns("retardoMayor").Width = 30
        grdAsistencia.DisplayLayout.Bands(0).Columns("punyAsis").Width = 30
        grdAsistencia.DisplayLayout.Bands(0).Columns("caja").Width = 30
        grdAsistencia.DisplayLayout.Bands(0).Columns("permisos").Width = 30
        grdAsistencia.DisplayLayout.Bands(0).Columns("punyAsis").Width = 30
        grdAsistencia.DisplayLayout.Bands(0).Columns("caja").Width = 30
        grdAsistencia.DisplayLayout.Bands(0).Columns("faltas").Width = 40
        grdAsistencia.DisplayLayout.Bands(0).Columns("numeracion").Width = 30


        grdAsistencia.DisplayLayout.UseFixedHeaders = True
        grdAsistencia.DisplayLayout.Bands(0).Columns("numeracion").Header.Fixed = True
        grdAsistencia.DisplayLayout.Bands(0).Columns("colaborador").Header.Fixed = True
        grdAsistencia.DisplayLayout.Bands(0).Columns("bloque").Header.Fixed = True

        grdAsistencia.DisplayLayout.Bands(0).Override.FixedHeaderIndicator = FixedHeaderIndicator.None

        'grdAsistencia.DisplayLayout.Override.DefaultRowHeight = 24
    End Sub

    Private Sub ListaControlAsistenciaForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        WindowState = FormWindowState.Maximized
        GroupBox3.Visible = False
        cargarNaves()
        btnCorte.Enabled = False
        lblCorte.Enabled = False
        ConcultarPermisos()
    End Sub

    Private Sub ConcultarPermisos()
        If PermisosUsuarioBU.ConsultarPermiso("NOM_NVO_CONTROL_ASISTENCIA", "NOM_REG_MANUAL") Then
            btnRegistroManual.Enabled = True
            lblRegistroManual.Enabled = True
        Else
            btnRegistroManual.Enabled = False
            lblRegistroManual.Enabled = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("NOM_NVO_CONTROL_ASISTENCIA", "NOM_IMPORTARREGISTROS") Then
            btnImportarExcel.Visible = True
            lblImportarExcel.Visible = True
        Else
            btnImportarExcel.Visible = False
            lblImportarExcel.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("NOM_NVO_CONTROL_ASISTENCIA", "NOM_AGREGARFALTAS") Then
            pnlAgregarFalta.Visible = True
            btnAgregarFalta.Enabled = True
            lblAgregarFalta.Enabled = True
        Else
            pnlAgregarFalta.Visible = False
            btnAgregarFalta.Enabled = False
            lblAgregarFalta.Enabled = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("NOM_NVO_CONTROL_ASISTENCIA", "NOM_PERMISOS") Then
            btnPermiso.Enabled = True
            lblPermiso.Enabled = True
        Else
            btnPermiso.Enabled = False
            lblPermiso.Enabled = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("NOM_NVO_CONTROL_ASISTENCIA", "NOM_CONSULTA_PERMISOS") Then
            btnRevisarPermiso.Enabled = True
            lblRevisarPermiso.Enabled = True
        Else
            btnRevisarPermiso.Enabled = False
            lblRevisarPermiso.Enabled = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("NOM_NVO_CONTROL_ASISTENCIA", "NOM_IMPRIMIR") Then
            btnImprimir.Enabled = True
            lblImprimir.Enabled = True
            btnImprimir2.Enabled = True
            Label18.Enabled = True
        Else
            btnImprimir.Enabled = False
            lblImprimir.Enabled = False
            btnImprimir2.Enabled = False
            Label18.Enabled = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("NOM_NVO_CONTROL_ASISTENCIA", "NOM_LISTA_ASISTENCIA") Then
            btnImprimir3.Enabled = True
            Label23.Enabled = True
        Else
            btnImprimir3.Enabled = False
            Label23.Enabled = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("NOM_NVO_CONTROL_ASISTENCIA", "NOM_CIERRE_ASISTENCIA") Then
            btnCorte.Enabled = True
            lblCorte.Enabled = True
            banderaCierre = True
        Else
            btnCorte.Enabled = False
            lblCorte.Enabled = False
            banderaCierre = False
        End If
        'PERMISO PARA VER BOTON DE REPLICA
        If PermisosUsuarioBU.ConsultarPermiso("NOM_NVO_CONTROL_ASISTENCIA", "NOM_REPLICA_COLABORADOR") Then
            pnlReplica.Visible = True
            btnReplica.Enabled = True
            lblReplica.Enabled = True
        Else
            pnlReplica.Visible = False
            btnReplica.Enabled = False
            lblReplica.Enabled = False
        End If

        'PERMISOS PARA VER BOTON DE ACTUALIZAR REGISTROS DESDE BD
        If PermisosUsuarioBU.ConsultarPermiso("NOM_NVO_CONTROL_ASISTENCIA", "NOM_ACT_REGISTROS") Then
            btnActRegistros.Visible = True
            lblActRegistros.Visible = True
            btnImportarExcel.Visible = False
            lblImportarExcel.Visible = False
        Else
            btnActRegistros.Visible = False
            lblActRegistros.Visible = False
            btnImportarExcel.Visible = True
            lblImportarExcel.Visible = True
        End If


    End Sub

    Private Sub cmbNave_DropDownClosed(sender As Object, e As EventArgs) Handles cmbNave.DropDownClosed
        cmbArea.DataSource = Nothing
        cmbDepartamento.DataSource = Nothing
        cmbCelula.DataSource = Nothing
        cargarAreas()
        idNave = cmbNave.SelectedValue
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        listarPeriodosAsistencia()
        cargarAreas()
        validaGeneraRegistroNoCheca()
    End Sub

    Private Sub validaGeneraRegistroNoCheca()
        Dim objBU As New Negocios.ControlAsistenciaBU
        Dim resultado As Boolean = False

        If cmbNave.Items.Count = 1 Or cmbNave.SelectedIndex > 0 Then
            resultado = objBU.validaGeneraRegistroNoCheca(cmbNave.SelectedValue)
        End If

        'pnlAgregarFalta.Visible = resultado

        If PermisosUsuarioBU.ConsultarPermiso("NOM_NVO_CONTROL_ASISTENCIA", "NOM_AGREGARFALTAS") OrElse resultado = True Then
            pnlAgregarFalta.Visible = True
            btnAgregarFalta.Enabled = True
            lblAgregarFalta.Enabled = True
        Else
            pnlAgregarFalta.Visible = False
            btnAgregarFalta.Enabled = False
            lblAgregarFalta.Enabled = False
        End If

    End Sub
    Private Sub cmbArea_DropDownClosed(sender As Object, e As EventArgs) Handles cmbArea.DropDownClosed
        cmbDepartamento.DataSource = Nothing
        cargarDepartamentos()
    End Sub

    Private Sub cmbDepartamento_DropDownClosed(sender As Object, e As EventArgs) Handles cmbDepartamento.DropDownClosed
        cmbCelula.DataSource = Nothing
        cargarCelulas()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdAsistencia.DataSource = Nothing
        cmbArea.DataSource = Nothing
        cmbCelula.DataSource = Nothing
        cmbDepartamento.DataSource = Nothing
    End Sub

    Private Sub btnRegistroManual_Click(sender As Object, e As EventArgs) Handles btnRegistroManual.Click
        With grdAsistencia
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With
        crearRegistroManual()
    End Sub

    Private Sub btnPermiso_Click(sender As Object, e As EventArgs) Handles btnPermiso.Click
        crearPermiso()
    End Sub
    Private Sub btnAgregarFalta_Click(sender As Object, e As EventArgs) Handles btnAgregarFalta.Click
        With grdAsistencia
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With
        agregarFalta()
    End Sub

    Private Sub btnCorte_Click(sender As Object, e As EventArgs) Handles btnCorte.Click
        cierreSemanal()
    End Sub

    Private Sub mostrarResumen()
        If grdAsistencia.Rows.Count > 0 Then
            With grdAsistencia.DisplayLayout.Bands(0)
                '.Columns("retardoMenor").Hidden = False
                .Columns("retardoMayor").Hidden = False
                .Columns("permisos").Hidden = False
                .Columns("faltas").Hidden = False
                .Columns("punyAsis").Hidden = False
                .Columns("caja").Hidden = False
            End With

        End If
    End Sub

    Private Sub ocultarResumen()
        If rbtnMostrarResumen.Checked Then Return
        If grdAsistencia.Rows.Count > 0 Then
            With grdAsistencia.DisplayLayout.Bands(0)

                .Columns("retardoMenor").Hidden = True
                .Columns("retardoMayor").Hidden = True
                .Columns("permisos").Hidden = True
                .Columns("faltas").Hidden = True
                .Columns("punyAsis").Hidden = True
                .Columns("caja").Hidden = True
            End With
        End If
    End Sub

    Private Sub rbtnMostrarResumen_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnMostrarResumen.CheckedChanged
        mostrarResumen()

    End Sub

    Private Sub rbtnOcultarResumen_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOcultarResumen.CheckedChanged
        ocultarResumen()

    End Sub

    Private Sub rbtnMostrarIncidencias_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnMostrarIncidencias.CheckedChanged
        mostrarIncidencias()
    End Sub

    Private Sub rbtnOcultarIncidencias_Click(sender As Object, e As EventArgs) Handles rbtnOcultarIncidencias.Click
        mostrarConsultaRegistros()
    End Sub

    Private Sub btnRevisarPermiso_Click(sender As Object, e As EventArgs) Handles btnRevisarPermiso.Click
        revisarPermiso()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpParametros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpParametros.Height = 141
    End Sub

    Private Sub btnImprimir3_Click(sender As Object, e As EventArgs) Handles btnImprimir3.Click
        imprimirReporteListaAsistencia()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        imprimirReporteResumen()
    End Sub

    Private Sub btnImprimir2_Click(sender As Object, e As EventArgs) Handles btnImprimir2.Click
        imprimirReporteCompleto()
    End Sub

    Private Sub btnImportarExcel_Click(sender As Object, e As EventArgs) Handles btnImportarExcel.Click
        Cursor = Cursors.WaitCursor
        If cmbNave.SelectedValue = 73 Then
            InsertarExcelImportado()
        ElseIf cmbNave.SelectedValue <> 73 Then
            InsertarExcelImportadoNuevoDiseno()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub InsertarExcelImportadoNuevoDiseno()
        Dim dtDatosMostrarImportados As New DataTable
        Dim advertencia As New AdvertenciaForm
        Dim exito As New ExitoForm
        Dim objBU As New Negocios.ControlAsistenciaBU
        Dim naveID As Integer = 0
        Dim NumeroFilas As Integer = 0

        dtDatosMostrarImportados = ImportarExcelNuevoDiseno()

        Try
            Cursor = Cursors.WaitCursor

            Dim vxmlRegistros As XElement = New XElement("Registros")
            If dtDatosMostrarImportados.Rows.Count > 0 Then
                dtDatosMostrarImportados.Rows.Remove(dtDatosMostrarImportados.Rows(0))

                NumeroFilas = dtDatosMostrarImportados.Rows.Count

                For index As Integer = 0 To NumeroFilas Step 1
                    If dtDatosMostrarImportados.Rows(0).Item("No. de Usuario") = "No. de Usuario" Then
                        dtDatosMostrarImportados.Rows.Remove(dtDatosMostrarImportados.Rows(0))
                    End If
                Next
                For Each row As DataRow In dtDatosMostrarImportados.Rows
                    Dim vNodo As XElement = New XElement("Registro")
                    For Each item As DataColumn In dtDatosMostrarImportados.Columns
                        If item.ColumnName = "Fecha" Then
                            Dim fecha As DateTime
                            fecha = row(item).ToString()
                            vNodo.Add(New XAttribute("Fecha", fecha.ToString("dd/MM/yyyy HH:mm:ss")))
                        End If
                        If item.ColumnName = "Hora" Then
                            Dim hora As DateTime
                            hora = row(item).ToString()
                            vNodo.Add(New XAttribute("Hora", hora.ToString("HH:mm:ss")))
                        End If
                        If item.ColumnName = "No. de Usuario" Then
                            vNodo.Add(New XAttribute("Usuario", row(item).ToString()))
                        End If
                    Next
                    vxmlRegistros.Add(vNodo)
                Next

                naveID = cmbNave.SelectedValue

                objBU.InsertarDatosImportadosXmlFormatoNuevo(vxmlRegistros.ToString(), naveID)
                exito.mensaje = "Datos importados correctamente."
                exito.ShowDialog()
                mostrarConsultaRegistros()
            Else
                advertencia.mensaje = "No hay información para importar."
                advertencia.ShowDialog()
            End If

        Catch ex As Exception
            MostrarMensaje(Mensajes.Fault, ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub



    Private Sub InsertarExcelImportado()

        Dim dtDatosMostarImportados As New DataTable
        Dim advertencia As New AdvertenciaForm
        Dim exito As New ExitoForm
        Dim objBU As New Negocios.ControlAsistenciaBU
        Dim naveID As Integer = 0

        dtDatosMostarImportados = ImportarExcel()

        Try
            Cursor = Cursors.WaitCursor

            Dim vXmlRegistros As XElement = New XElement("Registros")
            If dtDatosMostarImportados.Rows.Count > 0 Then
                For Each row As DataRow In dtDatosMostarImportados.Rows
                    Dim vNodo As XElement = New XElement("Registro")
                    For Each item As DataColumn In dtDatosMostarImportados.Columns
                        If item.ColumnName = "Fecha" Or item.ColumnName = "Fecha/Hora" Then
                            Dim fecha As DateTime
                            fecha = row(item).ToString()
                            vNodo.Add(New XAttribute("Fecha", fecha.ToString("dd/MM/yyyy HH:mm:ss")))
                        End If
                        If item.ColumnName = "Usuario" Or item.ColumnName = "ID de Usuario" Then
                            vNodo.Add(New XAttribute("Usuario", row(item).ToString()))
                        End If
                    Next
                    vXmlRegistros.Add(vNodo)
                Next

                naveID = cmbNave.SelectedValue

                objBU.InsertarDatosImportadosXml(vXmlRegistros.ToString(), naveID)
                exito.mensaje = "Datos importados correctamente"
                exito.ShowDialog()
            Else
                advertencia.mensaje = "No hay información para guardar."
                advertencia.ShowDialog()
            End If
        Catch ex As Exception
            MostrarMensaje(Mensajes.Fault, ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub


    Public Function ImportarExcelNuevoDiseno() As DataTable
        Dim advertencia As New AdvertenciaForm
        Dim datosExcel As New DataTable
        Dim NombreArchivo As String = ""
        Dim NumRenglon As Integer = 0
        Dim NumRenglonDataTable As Integer = 0
        Dim NumColumna As Integer = 0
        Dim dtDatosMostrarImportados As New DataTable
        Dim NombreColumna As String = ""
        Dim listColumnasEnteros As New List(Of String)
        Dim controlAsistenciaBU As New Negocios.ControlAsistenciaBU

        Try
            Dim hoja As String = "Informe Programado$"
            datosExcel = Tools.Excel.LlenarTablaExcelListaTablasSinSeleccionarHojaControlAsistenciaFormatoNuevo(hoja, "", NombreArchivo)
            Cursor = Cursors.WaitCursor

            If IsNothing(datosExcel) = False Then
                If datosExcel.Rows.Count > 0 Then
                    For Each row As DataRow In datosExcel.Rows
                        If NumRenglon = 0 Then
                            For Each col As DataColumn In datosExcel.Columns
                                Select Case NumColumna
                                    Case 0
                                        NombreColumna = "No. de Usuario"
                                    Case 1
                                        NombreColumna = "Nombre"
                                    Case 2
                                        NombreColumna = "Apellido"
                                    Case 3
                                        NombreColumna = "Alias"
                                    Case 4
                                        NombreColumna = "Género"
                                    Case 5
                                        NombreColumna = "No de Posicion"
                                    Case 6
                                        NombreColumna = "Posicion"
                                    Case 7
                                        NombreColumna = "No. de Departamento"
                                    Case 8
                                        NombreColumna = "Departamento"
                                    Case 9
                                        NombreColumna = "Fecha"
                                    Case 10
                                        NombreColumna = "Hora"
                                    Case 11
                                        NombreColumna = "Estado de Asistencia"
                                    Case 12
                                        NombreColumna = "Codigo de trabajo"
                                    Case 13
                                        NombreColumna = "Corrección de Estado"
                                    Case Else
                                        NombreColumna = row(col).ToString()
                                        If (IsNumeric(NombreColumna)) Then
                                            listColumnasEnteros.Add(NombreColumna)
                                        End If
                                End Select
                                If NumColumna >= 0 Then
                                    dtDatosMostrarImportados.Columns.Add(NombreColumna)
                                    If listColumnasEnteros.Contains(NombreColumna) Then
                                        dtDatosMostrarImportados.Columns(NombreColumna).DataType = System.Type.GetType("System.int32")
                                    End If
                                End If
                                NumColumna += 1
                            Next
                        ElseIf NumRenglon > 0 Then
                            Dim id As String = LTrim(RTrim(row.Item(0).ToString()))
                            If id <> "" Then
                                dtDatosMostrarImportados.Rows.Add()
                                For columna As Integer = 0 To dtDatosMostrarImportados.Columns.Count - 1 Step 1
                                    If row(columna).ToString() <> "" Then
                                        dtDatosMostrarImportados.Rows(NumRenglonDataTable - 1)(columna) = row(columna)
                                    End If
                                Next
                            Else
                                NumRenglonDataTable -= 1
                            End If
                        End If
                        NumRenglon += 1
                        NumRenglonDataTable += 1
                    Next
                End If
                grdAsistencia.DataSource = Nothing
            Else
                advertencia.mensaje = "El nombre del archivo a importar debe iniciar con: Informe"
                advertencia.ShowDialog()
            End If

        Catch ex As Exception
            MostrarMensaje(Mensajes.Fault, ex.Message)
        End Try
        Cursor = Cursors.WaitCursor
        Return dtDatosMostrarImportados
    End Function

    Public Function ImportarExcel() As DataTable
        Dim advertencia As New AdvertenciaForm
        Dim datosExcel As New DataTable
        Dim NombreArchivo As String = ""
        Dim NumRenglon As Integer = 0
        Dim NumRenglonDataTable As Integer = 1
        Dim NumColumna As Integer = 0
        Dim dtDatosMostarImportados As New DataTable
        Dim NombreColumna As String = ""
        Dim listColumnasEnteros As New List(Of String)
        Dim controlAsistenciaBU As New Negocios.ControlAsistenciaBU


        Try
            Dim hoja As String = "DATOS$"
            datosExcel = Tools.Excel.LlenarTablaExcelListaTablasSinSeleccionarHojaControlAsistencia(hoja, "", NombreArchivo)
            Cursor = Cursors.WaitCursor

            If IsNothing(datosExcel) = False Then
                If datosExcel.Rows.Count > 0 Then
                    For Each row As DataRow In datosExcel.Rows
                        If NumRenglon = 0 Then
                            For Each col As DataColumn In datosExcel.Columns
                                Select Case NumColumna
                                    Case 0
                                        NombreColumna = "Fecha"
                                    Case 1
                                        NombreColumna = "Puerta"
                                    Case 2
                                        NombreColumna = "ID Dispositivo"
                                    Case 3
                                        NombreColumna = "Dispositivo"
                                    Case 4
                                        NombreColumna = "Grupo Usuario"
                                    Case 5
                                        NombreColumna = "Usuario"
                                    Case 6
                                        NombreColumna = "Evento"
                                    Case Else
                                        NombreColumna = row(col).ToString()
                                        If (IsNumeric(NombreColumna)) Then
                                            listColumnasEnteros.Add(NombreColumna)
                                        End If
                                End Select
                                If NumColumna >= 0 Then
                                    dtDatosMostarImportados.Columns.Add(NombreColumna)
                                    If listColumnasEnteros.Contains(NombreColumna) Then
                                        dtDatosMostarImportados.Columns(NombreColumna).DataType = System.Type.GetType("System.Int32")
                                    End If
                                End If
                                NumColumna += 1
                            Next
                        End If
                        Dim id As String = LTrim(RTrim(row.Item(5).ToString()))
                        If id <> "" Then
                            dtDatosMostarImportados.Rows.Add()
                            For columna As Integer = 0 To dtDatosMostarImportados.Columns.Count - 1 Step 1
                                If row(columna).ToString() <> "" Then
                                    dtDatosMostarImportados.Rows(NumRenglonDataTable - 1)(columna) = row(columna)
                                End If
                            Next
                        Else
                            NumRenglonDataTable -= 1
                        End If
                        NumRenglon += 1
                        NumRenglonDataTable += 1
                    Next
                End If
                grdAsistencia.DataSource = Nothing
            Else
                advertencia.mensaje = "El nombre del archivo a importar debe iniciar con: Asistencia"
                advertencia.ShowDialog()
            End If

        Catch ex As Exception
            MostrarMensaje(Mensajes.Fault, ex.Message)
        End Try
        Cursor = Cursors.WaitCursor
        Return dtDatosMostarImportados
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnReplica.Click
        Dim dtResult As DataTable
        Dim advertencia As New AdvertenciaForm
        Dim exito As New ExitoForm
        Try
            Cursor = Cursors.WaitCursor
            Dim controlAsistenciaBU As New Negocios.ControlAsistenciaBU
            dtResult = controlAsistenciaBU.ReplicaRegistros()

            If dtResult.Rows.Count > 0 Then
                If (dtResult.Rows(0)("RESULTADO") = 1) Then
                    exito.mensaje = "Datos replicados correctamente."
                    exito.ShowDialog()
                Else
                    advertencia.mensaje = "Ocurrio un error al replicar los registros." & dtResult.Rows(0)("MENSAJE")
                    advertencia.ShowDialog()
                End If
            End If
        Catch ex As Exception
            advertencia.mensaje = "Ocurrio un error al replicar los registros." & ex.Message()
            advertencia.ShowDialog()
        End Try
        Cursor = Cursors.Default

    End Sub

    Private Sub btnActRegistros_Click(sender As Object, e As EventArgs) Handles btnActRegistros.Click
        Dim periodoRangoActualizar As New Entidades.PeriodosNomina
        Dim ControlDePeriodoBUAct As New Negocios.ControlDePeriodoBU
        Dim controlAsistenciaBUAct As New Negocios.ControlAsistenciaBU
        Dim periodoNomina As String = ""
        Dim advertencia As New AdvertenciaForm

        If cmbPeriodo.SelectedValue > 0 Then
            mostrarConsultaRegistros()
            GroupBox3.Visible = True
            periodoNomina = cmbPeriodo.SelectedValue
            periodoRangoActualizar = ControlDePeriodoBUAct.buscarRangosPeriodoSegunNaveSegunAsistencia(periodoNomina)
            dtpFechaInicio.Value = periodoRangoActualizar.FechaInicio
            dtpFechaFin.Value = periodoRangoActualizar.FechaFin

        End If

        'Dim controlAsistenciaBU As New Negocios.ControlAsistenciaBU
        'Dim advertencia As New AdvertenciaForm
        'Dim exito As New ExitoForm
        'Dim NaveId As Integer
        'Try
        '    Cursor = Cursors.WaitCursor
        '    If cmbNave.SelectedValue > 0 Then
        '        NaveId = cmbNave.SelectedValue()
        '        controlAsistenciaBU.ActualizarRegistros(NaveId)
        '        exito.mensaje = "Registros actualizados con exito."
        '        exito.ShowDialog()
        '        mostrarConsultaRegistros()
        '    Else
        '        advertencia.mensaje = "Selecciona la nave."
        '    End If
        'Catch ex As Exception
        '    advertencia.mensaje = "Ocurrio un error al actualizar los registros." & ex.Message()
        '    advertencia.ShowDialog()
        'End Try
        'Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim controlAsistenciaBU As New Negocios.ControlAsistenciaBU
        Dim advertencia As New AdvertenciaForm
        Dim exito As New ExitoForm
        Dim NaveId As Integer
        Try
            Cursor = Cursors.WaitCursor
            If cmbNave.SelectedValue > 0 Then
                NaveId = cmbNave.SelectedValue()
                controlAsistenciaBU.ActualizarRegistros(NaveId, dtpFechaInicio.Value, dtpFechaFin.Value)
                exito.mensaje = "Registros actualizados con exito."
                exito.ShowDialog()
                mostrarConsultaRegistros()
                GroupBox3.Visible = False
            Else
                advertencia.mensaje = "Selecciona la nave."
            End If
        Catch ex As Exception
            advertencia.mensaje = "Ocurrio un error al actualizar los registros." & ex.Message()
            advertencia.ShowDialog()
        End Try
        Cursor = Cursors.Default
    End Sub
End Class