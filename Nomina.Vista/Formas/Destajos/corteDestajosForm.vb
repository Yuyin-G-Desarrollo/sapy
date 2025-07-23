Imports Tools

Public Class corteDestajosForm
    Dim FechaInicio As DateTime
    Dim FechaFin As DateTime
    Dim stPeriodoNomina As String
    Dim stPeriodoDestajos As String
    Dim stPeriodoAsistencia As String
    Private Sub cierreDestajosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        Try
            Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            btnCerrarDestajos.Visible = False
            lblGuardar.Visible = False
        Catch ex As Exception

        End Try
        lblTotalAcumuladoMostar.Text = ""
        lblTotalAjusteMostrar.Text = ""
        lblTotalPagarMostar.Text = ""
    End Sub

    Private Sub cmbNave_DropDownClosed(sender As Object, e As EventArgs) Handles cmbNave.DropDownClosed
        Try
            btnCerrarDestajos.Visible = False
            lblGuardar.Visible = False
            'grdDestajos.Rows.Clear()
            grdDestajos.DataSource = Nothing

            'Controles.ComboPeriodoSegunNaveSegunAsistencia(cmbPeriodoNomina, cmbNave.SelectedValue)

            ' Controles.ComboPeriodoSegunNaveSegunAsistenciaControlAsistencia(cmbPeriodoNomina, CInt(cmbNave.SelectedValue.ToString))
            llenarComboPeriodos()
            FechasSemanaNomina()
            'CambiarHeaders(FechaInicio, FechaFin)
            Dim Todo As Boolean = False
            Dim Montado As Boolean = False
            Dim Adorno As Boolean = False
            Dim Pespunte As Boolean = False
            Dim corte As Boolean = False
            Dim plantilla As Boolean = False
            If cmbNave.SelectedIndex > 0 Then

                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("DEST_CIE_SEM", "DEST_CIE_TODO") Then
                    Todo = True
                Else
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("DEST_CIE_SEM", "DEST_CIE_MONTADO") Then
                        Montado = True
                    End If

                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("DEST_CIE_SEM", "DEST_CIE_ADORNO") Then
                        Adorno = True
                    End If

                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("DEST_CIE_SEM", "DEST_CIE_PESP") Then
                        Pespunte = True
                    End If

                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("DEST_CIE_SEM", "DEST_CIE_CORT") Then
                        corte = True
                    End If

                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("DEST_CIE_SEM", "DEST_CIE_PLANT") Then
                        plantilla = True
                    End If
                End If

                If Todo = True Or Montado = True Or Adorno = True Or Pespunte = True Or corte = True Or plantilla = True Then
                    DepartamentosSegunColaboradorNave(cmbDepartamento, cmbNave.SelectedValue, Montado, Adorno, Pespunte, corte, plantilla, Todo)
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub FechasSemanaNomina()
        Dim SemanaNominaActiva As New List(Of Entidades.CobranzaPrestamos)
        Dim SenamaActivaBu As New Nomina.Negocios.CobranzaPrestamosBU
        SemanaNominaActiva = SenamaActivaBu.FechasSemanaNomina(cmbPeriodoNomina.SelectedValue)

        For Each objeto As Entidades.CobranzaPrestamos In SemanaNominaActiva
            FechaInicio = objeto.PfechaInicioNomina
            FechaFin = objeto.PfechaFinNomina
            stPeriodoNomina = objeto.PPeriodoNominaNomina
            stPeriodoDestajos = objeto.PPeriodoNominaDestajos
            stPeriodoAsistencia = objeto.PPeriodoNominaAsistencia
        Next



    End Sub

    Public Function DepartamentosSegunColaboradorNave(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal NaveID As Integer, ByVal Montado As Boolean, ByVal Adorno As Boolean, ByVal Pespunte As Boolean, ByVal corte As Boolean, ByVal plantilla As Boolean, ByVal Todo As Boolean) As System.Windows.Forms.ComboBox

        Dim comboDepartamentos As New ComboBox
        comboDepartamentos = comboEntrada

        Dim tablaDepartamentosSegunColaborador As New DataTable
        Dim objDepartamentosSegunColaborador As New Nomina.Negocios.CorteDestajosBU
        tablaDepartamentosSegunColaborador.Rows.Add()
        tablaDepartamentosSegunColaborador = objDepartamentosSegunColaborador.DepartamentosSegunPermiso(NaveID, Montado, Adorno, Pespunte, corte, plantilla, Todo)

        tablaDepartamentosSegunColaborador.Rows.InsertAt(tablaDepartamentosSegunColaborador.NewRow, 0)

        comboDepartamentos.DataSource = tablaDepartamentosSegunColaborador
        comboDepartamentos.DisplayMember = "grup_name"
        comboDepartamentos.ValueMember = "grup_grupoid"
        Return comboDepartamentos

    End Function

    Private Sub cmbDepartamento_DropDownClosed(sender As Object, e As EventArgs) Handles cmbDepartamento.DropDownClosed
        btnCerrarDestajos.Visible = False
        lblGuardar.Visible = False
        'grdDestajos.Rows.Clear()
        grdDestajos.DataSource = Nothing
        If cmbDepartamento.SelectedIndex > 0 Then
            Controles.ComboCelulasSegunDepartamento(cmbCelula, cmbDepartamento.SelectedValue)
        End If
        lblTotalAcumuladoMostar.Text = ""
        lblTotalAjusteMostrar.Text = ""
        lblTotalPagarMostar.Text = ""

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.Cursor = Cursors.WaitCursor
        'grdDestajos.Rows.Clear()
        Dim NaveID As Integer = 0
        Dim DepartamentoID As Integer = 0
        Dim CelulaId As Integer = 0
        Dim validaciones As Integer = 0
        Dim periodoNomina As Integer = cmbPeriodoNomina.SelectedValue
        Dim ObjBu As New Nomina.Negocios.CorteDestajosBU
        'Dim ListaColaboradoresDestajos As New List(Of Entidades.CorteDestajos)
        Dim dtListaColaboradoresDestajos As New DataTable
        Dim advertencia As New AdvertenciaForm
        Dim totalAcumulado As Double = 0
        Dim totalAjuste As Double = 0
        Dim totalPagar As Double = 0


        If cmbNave.SelectedIndex > 0 Then
            NaveID = cmbNave.SelectedValue


            If stPeriodoNomina = "A" And stPeriodoDestajos = "A" And stPeriodoAsistencia = "C" Then

            Else
                validaciones += 1
            End If


            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("DEST_CIE_SEM", "DEST_CIE_DEST") Then
            Else
                validaciones += 1
            End If
        End If

        If cmbDepartamento.SelectedIndex > 0 Then
            DepartamentoID = cmbDepartamento.SelectedValue
            validaciones += 1
        End If

        If cmbCelula.SelectedIndex > 0 Then
            CelulaId = cmbCelula.SelectedValue
            validaciones += 1
        End If

        If NaveID > 0 Then
            lblNave.ForeColor = Color.Black
            lblDepartamento.ForeColor = Color.Black

            If stPeriodoDestajos = "C" Then
                'ListaColaboradoresDestajos = ObjBu.consultarCierre(periodoNomina, cmbNave.SelectedValue, DepartamentoID, CelulaId)
                dtListaColaboradoresDestajos = ObjBu.consultarCierreDestajo(periodoNomina, cmbNave.SelectedValue, DepartamentoID, CelulaId)
                'llenarCierre(ListaColaboradoresDestajos)
            ElseIf stPeriodoDestajos = "A" Or stPeriodoDestajos = "B" Then
                'ListaColaboradoresDestajos = ObjBu.ListaColaboradoresDestajos(periodoNomina, cmbNave.SelectedValue, DepartamentoID, CelulaId)
                dtListaColaboradoresDestajos = ObjBu.consultarDestajoAbierto(periodoNomina, cmbNave.SelectedValue, DepartamentoID, CelulaId)
                'LlenarGrid(ListaColaboradoresDestajos)
            End If
        Else
            If NaveID = 0 Then
                lblNave.ForeColor = Color.Red
            Else
                lblNave.ForeColor = Color.Black
            End If

        End If

        If dtListaColaboradoresDestajos.Rows.Count > 0 Then
            grdDestajos.DataSource = dtListaColaboradoresDestajos
            If IsDBNull(totalAcumulado) Then
                totalAcumulado = 0
            Else
                totalAcumulado = (From a In dtListaColaboradoresDestajos.AsEnumerable() Select a.Field(Of Decimal)("Acumulado")).Sum()
            End If

            lblTotalAcumuladoMostar.Text = totalAcumulado.ToString("N2")
            lblTotalAcumulado.Text = "Total Acumulado"
            totalAjuste = (From a In dtListaColaboradoresDestajos.AsEnumerable() Select a.Field(Of Decimal)("Ajuste")).Sum()
            lblTotalAjuste.Text = "Total Ajuste"
            lblTotalAjusteMostrar.Text = totalAjuste.ToString("N2")
            totalPagar = (From a In dtListaColaboradoresDestajos.AsEnumerable() Select a.Field(Of Decimal)("TotalPagar")).Sum()
            lblTotalPagar.Text = "Total Pagar"
            lblTotalPagarMostar.Text = totalPagar.ToString("N0")
            disenoGrid()
        Else
            advertencia.mensaje = "No hay información con las fechas seleccionadas."
            advertencia.ShowDialog()
        End If

        If validaciones > 0 Then
            btnCerrarDestajos.Visible = False
            lblGuardar.Visible = False
            For Each row As DataGridViewRow In grdDestajos.Rows
                row.Cells("Ajuste").ReadOnly = True
            Next
        Else
            btnCerrarDestajos.Visible = True
            lblGuardar.Visible = True
            For Each row As DataGridViewRow In grdDestajos.Rows
                row.Cells("Ajuste").ReadOnly = False
                row.Cells("Faltas").ReadOnly = True
                row.Cells("SueldoBase").ReadOnly = True
                row.Cells("Acumulado").ReadOnly = True
                row.Cells("TotalPagar").ReadOnly = True
            Next
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub disenoGrid()

        grdDestajos.Columns.Item("#").Width = 40
        grdDestajos.Columns.Item("#").DisplayIndex = 0
        grdDestajos.Columns.Item("IdColaborador").Visible = False
        grdDestajos.Columns.Item("Colaborador").Width = 250
        grdDestajos.Columns.Item("Faltas").Width = 50
        grdDestajos.Columns.Item("SueldoBase").Width = 70
        grdDestajos.Columns.Item("Acumulado").Width = 70
        grdDestajos.Columns.Item("Ajuste").Width = 70
        grdDestajos.Columns.Item("TotalPagar").Width = 70


        grdDestajos.Columns.Item("SueldoBase").HeaderText = "Sueldo Base"
        grdDestajos.Columns.Item("TotalPagar").HeaderText = "Total a Pagar"

        grdDestajos.Columns("SueldoBase").DefaultCellStyle.Format = "N2"
        grdDestajos.Columns("Acumulado").DefaultCellStyle.Format = "N2"
        grdDestajos.Columns("Ajuste").DefaultCellStyle.Format = "N2"
        grdDestajos.Columns("TotalPagar").DefaultCellStyle.Format = "N0"

        For Each col As DataGridViewColumn In grdDestajos.Columns
            If col.Name <> "#" And col.Name <> "SueldoBase" And col.Name <> "Acumulado" And col.Name <> "Ajuste" And col.Name <> "TotalPagar" And col.Name <> "Faltas" Then
                grdDestajos.Columns(col.Name).DefaultCellStyle.Format = "N2"
            End If
        Next





    End Sub

    'Public Sub llenarCierre(ByVal ColaboradoresDestajos As List(Of Entidades.CorteDestajos))
    '    grdDestajos.Rows.Clear()
    '    Dim IdColaborador As Integer = 0
    '    Dim objBU As New Negocios.CorteDestajosBU
    '    Dim tablaDestajos As New DataTable
    '    Dim diaCaptura As String = ""
    '    Dim acumulado As Double = 0
    '    Dim sueldoBase As Double = 0
    '    Dim SumaDestajo As Double = 0
    '    Dim acumuladoAPagar As Double = 0
    '    Dim acumuladoAcumulado As Double = 0
    '    Dim acumuladoAjuste As Double = 0
    '    Dim contador As Integer = 0
    '    Dim inasistencias As Double = 0

    'For Each row As Entidades.CorteDestajos In ColaboradoresDestajos
    '    IdColaborador = row.PColaborador.PColaboradorid
    '    grdDestajos.Rows.Add(IdColaborador, grdDestajos.Rows.Count + 1, row.PColaborador.PNombreCompleto.ToString, row.pFaltas.ToString, row.PRealCantidad.ToString("N2"), row.PTotalDestajos, row.PajusteDestajo, Math.Round(row.PTotalPagar, 0))
    'Next

    'For Each fila As DataGridViewRow In grdDestajos.Rows
    '    IdColaborador = fila.Cells("clmIDcolaborador").Value
    '    tablaDestajos = objBU.totalDestajosPorColaborador(IdColaborador, cmbPeriodoNomina.SelectedValue)
    '    inasistencias = objBU.Inasistencias(IdColaborador, cmbPeriodoNomina.SelectedValue)
    '    fila.Cells("clmNumFaltas").Value = inasistencias.ToString
    '    For Each tblFila As DataRow In tablaDestajos.Rows

    '        If tblFila.Item("Dia") = 1 Then
    '            fila.Cells("clmLunes").Value += tblFila.Item("montoAcumulado")
    '        ElseIf tblFila.Item("Dia") = 2 Then
    '            fila.Cells("clmMartes").Value += tblFila.Item("montoAcumulado")
    '        ElseIf tblFila.Item("Dia") = 3 Then
    '            fila.Cells("clmMiercoles").Value += tblFila.Item("montoAcumulado")
    '        ElseIf tblFila.Item("Dia") = 4 Then
    '            fila.Cells("clmJueves").Value += tblFila.Item("montoAcumulado")
    '        ElseIf tblFila.Item("Dia") = 5 Then
    '            fila.Cells("clmViernes").Value += tblFila.Item("montoAcumulado")
    '        ElseIf tblFila.Item("Dia") = 6 Then
    '            fila.Cells("clmSabado").Value += tblFila.Item("montoAcumulado")
    '        ElseIf tblFila.Item("Dia") = 7 Or tblFila.Item("montoAcumulado") = 0 Then
    '            fila.Cells("clmDomingo").Value += tblFila.Item("montoAcumulado")
    '        End If
    '    Next

    '    acumuladoAPagar += fila.Cells("clmTotalPagar").Value
    '    acumuladoAcumulado += fila.Cells("clmAcumulado").Value
    '    acumuladoAjuste += fila.Cells("clmAjuste").Value
    '    contador += 1
    'Next
    ''If grdDestajos.Rows.Count > 0 Then
    ''    grdDestajos.Rows.Add("", "", "", "", acumuladoAcumulado, acumuladoAjuste, acumuladoAPagar)
    ''    grdDestajos.Rows(contador).DefaultCellStyle.BackColor = Color.GreenYellow
    ''End If
    'lblTotalAcumuladoMostar.Text = acumuladoAcumulado.ToString("N2")
    'lblTotalPagarMostar.Text = acumuladoAPagar.ToString("N2")
    'lblTotalAjusteMostrar.Text = acumuladoAjuste.ToString("N2")
    'End Sub

    'Public Sub LlenarGrid(ByVal ColaboradoresDestajos As List(Of Entidades.CorteDestajos))
    '    grdDestajos.Rows.Clear()
    '    Dim objBU As New Negocios.CorteDestajosBU
    '    Dim tablaDestajos As New DataTable
    '    Dim IdColaborador As Integer = 0
    '    Dim diaCaptura As String = ""
    '    Dim acumulado As Double = 0
    '    Dim sueldoBase As Double = 0
    '    Dim SumaDestajo As Double = 0
    '    Dim acumuladoAPagar As Double = 0
    '    Dim acumuladoAcumulado As Double = 0
    '    Dim acumuladoAjuste As Double = 0
    '    Dim contador As Integer = 0
    '    Dim inasistencias As Double = 0

    '    For Each row As Entidades.CorteDestajos In ColaboradoresDestajos
    '        IdColaborador = row.PColaborador.PColaboradorid
    '        grdDestajos.Rows.Add(IdColaborador, grdDestajos.Rows.Count + 1, row.PColaborador.PNombreCompleto.ToString, "", row.PRealCantidad.ToString("N2"), 0.0, 0.0, 0.0)
    '    Next

    '    For Each fila As DataGridViewRow In grdDestajos.Rows
    '        IdColaborador = fila.Cells("clmIDcolaborador").Value
    '        tablaDestajos = objBU.totalDestajosPorColaborador(IdColaborador, cmbPeriodoNomina.SelectedValue)
    '        inasistencias = objBU.Inasistencias(IdColaborador, cmbPeriodoNomina.SelectedValue)
    '        fila.Cells("clmNumFaltas").Value = inasistencias.ToString
    '        For Each tblFila As DataRow In tablaDestajos.Rows

    '            If tblFila.Item("Dia") = 1 Then
    '                fila.Cells("clmLunes").Value += tblFila.Item("montoAcumulado")
    '            ElseIf tblFila.Item("Dia") = 2 Then
    '                fila.Cells("clmMartes").Value += tblFila.Item("montoAcumulado")
    '            ElseIf tblFila.Item("Dia") = 3 Then
    '                fila.Cells("clmMiercoles").Value += tblFila.Item("montoAcumulado")
    '            ElseIf tblFila.Item("Dia") = 4 Then
    '                fila.Cells("clmJueves").Value += tblFila.Item("montoAcumulado")
    '            ElseIf tblFila.Item("Dia") = 5 Then
    '                fila.Cells("clmViernes").Value += tblFila.Item("montoAcumulado")
    '            ElseIf tblFila.Item("Dia") = 6 Then
    '                fila.Cells("clmSabado").Value += tblFila.Item("montoAcumulado")
    '            ElseIf tblFila.Item("Dia") = 7 Or tblFila.Item("montoAcumulado") = 0 Then
    '                fila.Cells("clmDomingo").Value += tblFila.Item("montoAcumulado")
    '            End If

    '            fila.Cells("clmAcumulado").Value += tblFila.Item("montoAcumulado")
    '            If fila.Cells("clmAcumulado").Value.ToString <> "" Then
    '                acumulado = fila.Cells("clmAcumulado").Value
    '            End If

    '            If fila.Cells("clmSueldoBase").Value.ToString <> "" Then
    '                sueldoBase = fila.Cells("clmSueldoBase").Value
    '            End If

    '            If acumulado < sueldoBase Then
    '                fila.Cells("clmAjuste").Value = sueldoBase - acumulado
    '                fila.Cells("clmTotalPagar").Value = sueldoBase
    '            Else
    '                fila.Cells("clmAjuste").Value = "0.0"
    '                fila.Cells("clmTotalPagar").Value = acumulado
    '            End If
    '        Next
    '        acumuladoAPagar += fila.Cells("clmTotalPagar").Value
    '        acumuladoAcumulado += fila.Cells("clmAcumulado").Value
    '        acumuladoAjuste += fila.Cells("clmAjuste").Value
    '        contador += 1
    '    Next
    '    'If grdDestajos.Rows.Count > 0 Then
    '    '    grdDestajos.Rows.Add("", "", "", "", "", acumuladoAcumulado, acumuladoAjuste, acumuladoAPagar)
    '    '    grdDestajos.Rows(contador).DefaultCellStyle.BackColor = Color.GreenYellow
    '    'End If
    '    lblTotalAcumuladoMostar.Text = acumuladoAcumulado.ToString("N2")
    '    lblTotalPagarMostar.Text = acumuladoAPagar.ToString("N2")
    '    lblTotalAjusteMostrar.Text = acumuladoAjuste.ToString("N2")
    'End Sub

    'Public Sub CambiarHeaders(fechainicio As DateTime, fechafin As DateTime)
    '    Dim dia As Integer = fechainicio.DayOfWeek

    '    If dia = 1 Then
    '        Try
    '            clmLunes.HeaderText = "Lunes" + vbCr + fechainicio.ToShortDateString
    '            clmMartes.HeaderText = "Martes" + vbCr + fechainicio.AddDays(1).ToShortDateString
    '            clmMiercoles.HeaderText = "Miércoles" + vbCr + fechainicio.AddDays(2).ToShortDateString
    '            clmJueves.HeaderText = "Jueves" + vbCr + fechainicio.AddDays(3).ToShortDateString
    '            clmViernes.HeaderText = "Viernes" + vbCr + fechainicio.AddDays(4).ToShortDateString
    '            clmSabado.HeaderText = "Sábado" + vbCr + fechainicio.AddDays(5).ToShortDateString
    '            clmDomingo.HeaderText = "Domingo" + vbCr + fechafin.ToShortDateString
    '        Catch ex As Exception
    '        End Try
    '    End If

    '    If dia = 2 Then
    '        Try
    '            clmLunes.HeaderText = "Lunes" + vbCr + fechafin.ToShortDateString
    '            clmMartes.HeaderText = "Martes" + vbCr + fechainicio.ToShortDateString
    '            clmMiercoles.HeaderText = "Miércoles" + vbCr + fechainicio.AddDays(1).ToShortDateString
    '            clmJueves.HeaderText = "Jueves" + vbCr + fechainicio.AddDays(2).ToShortDateString
    '            clmViernes.HeaderText = "Viernes" + vbCr + fechainicio.AddDays(3).ToShortDateString
    '            clmSabado.HeaderText = "Sábado" + vbCr + fechainicio.AddDays(4).ToShortDateString
    '            clmDomingo.HeaderText = "Domingo" + vbCr + fechainicio.AddDays(5).ToShortDateString
    '        Catch ex As Exception
    '        End Try
    '    End If

    '    If dia = 3 Then
    '        Try
    '            clmLunes.HeaderText = "Lunes" + vbCr + fechafin.AddDays(-1).ToShortDateString
    '            clmMartes.HeaderText = "Martes" + vbCr + fechafin.ToShortDateString
    '            clmMiercoles.HeaderText = "Miércoles" + vbCr + fechainicio.ToShortDateString
    '            clmJueves.HeaderText = "Jueves" + vbCr + fechainicio.AddDays(1).ToShortDateString
    '            clmViernes.HeaderText = "Viernes" + vbCr + fechainicio.AddDays(2).ToShortDateString
    '            clmSabado.HeaderText = "Sábado" + vbCr + fechainicio.AddDays(3).ToShortDateString
    '            clmDomingo.HeaderText = "Domingo" + vbCr + fechainicio.AddDays(4).ToShortDateString
    '        Catch ex As Exception
    '        End Try
    '    End If

    '    If dia = 4 Then
    '        Try
    '            clmLunes.HeaderText = "Lunes" + vbCr + fechafin.AddDays(-2).ToShortDateString
    '            clmMartes.HeaderText = "Martes" + vbCr + fechafin.AddDays(-1).ToShortDateString
    '            clmMiercoles.HeaderText = "Miércoles" + vbCr + fechafin.ToShortDateString
    '            clmJueves.HeaderText = "Jueves" + vbCr + fechainicio.ToShortDateString
    '            clmViernes.HeaderText = "Viernes" + vbCr + fechainicio.AddDays(1).ToShortDateString
    '            clmSabado.HeaderText = "Sábado" + vbCr + fechainicio.AddDays(2).ToShortDateString
    '            clmDomingo.HeaderText = "Domingo" + vbCr + fechainicio.AddDays(3).ToShortDateString
    '        Catch ex As Exception
    '        End Try
    '    End If

    '    If dia = 5 Then
    '        Try
    '            clmLunes.HeaderText = "Lunes" + vbCr + fechafin.AddDays(-3).ToShortDateString
    '            clmMartes.HeaderText = "Martes" + vbCr + fechafin.AddDays(-2).ToShortDateString
    '            clmMiercoles.HeaderText = "Miércoles" + vbCr + fechafin.AddDays(-1).ToShortDateString
    '            clmJueves.HeaderText = "Jueves" + vbCr + fechafin.ToShortDateString
    '            clmViernes.HeaderText = "Viernes" + vbCr + fechainicio.ToShortDateString
    '            clmSabado.HeaderText = "Sábado" + vbCr + fechainicio.AddDays(1).ToShortDateString
    '            clmDomingo.HeaderText = "Domingo" + vbCr + fechainicio.AddDays(2).ToShortDateString
    '        Catch ex As Exception
    '        End Try
    '    End If

    '    If dia = 6 Then
    '        Try
    '            clmLunes.HeaderText = "Lunes" + vbCr + fechafin.AddDays(-4).ToShortDateString
    '            clmMartes.HeaderText = "Martes" + vbCr + fechafin.AddDays(-3).ToShortDateString
    '            clmMiercoles.HeaderText = "Miércoles" + vbCr + fechafin.AddDays(-2).ToShortDateString
    '            clmJueves.HeaderText = "Jueves" + vbCr + fechafin.AddDays(-1).ToShortDateString
    '            clmViernes.HeaderText = "Viernes" + vbCr + fechafin.ToShortDateString
    '            clmSabado.HeaderText = "Sábado" + vbCr + fechainicio.ToShortDateString
    '            clmDomingo.HeaderText = "Domingo" + vbCr + fechainicio.AddDays(1).ToShortDateString
    '        Catch ex As Exception
    '        End Try
    '    End If

    '    If dia = 0 Then
    '        Try
    '            clmLunes.HeaderText = "Lunes" + vbCr + fechafin.AddDays(-5).ToShortDateString
    '            clmMartes.HeaderText = "Martes" + vbCr + fechafin.AddDays(-4).ToShortDateString
    '            clmMiercoles.HeaderText = "Miércoles" + vbCr + fechafin.AddDays(-3).ToShortDateString
    '            clmJueves.HeaderText = "Jueves" + vbCr + fechafin.AddDays(-2).ToShortDateString
    '            clmViernes.HeaderText = "Viernes" + vbCr + fechafin.AddDays(-1).ToShortDateString
    '            clmSabado.HeaderText = "Sábado" + vbCr + fechafin.ToShortDateString
    '            clmDomingo.HeaderText = "Domingo" + vbCr + fechainicio.ToShortDateString
    '        Catch ex As Exception
    '        End Try
    '    End If

    'End Sub

    Private Sub cmbPeriodoNomina_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPeriodoNomina.DropDownClosed
        btnCerrarDestajos.Visible = False
        lblGuardar.Visible = False
        'grdDestajos.Rows.Clear()
        FechasSemanaNomina()
        'CambiarHeaders(FechaInicio, FechaFin)
        lblTotalAcumuladoMostar.Text = ""
        lblTotalAjusteMostrar.Text = ""
        lblTotalPagarMostar.Text = ""
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnCerrarDestajos.Click
        Dim colaboradorID As Integer = 0
        Dim sueldoBase As Double = 0
        Dim ajuste As Double = 0
        Dim totalPagar As Double = 0

        Dim mensajeExito As New ConfirmarForm
        mensajeExito.mensaje = "¿ Está seguro de querer guardar los destajos ? " + vbNewLine + "No podrá hacer modificaciones" + vbNewLine + " después del guardado."

        If mensajeExito.ShowDialog = DialogResult.OK Then
            For Each row As DataGridViewRow In grdDestajos.Rows
                Dim objBU As New Negocios.CorteDestajosBU
                Dim objEnt As New Entidades.CorteDestajos
                Dim objColaborador As New Entidades.Colaborador

                sueldoBase = 0
                ajuste = 0
                totalPagar = 0

                If row.Cells("IdColaborador").Value.ToString <> "" Then
                    colaboradorID = row.Cells("IdColaborador").Value
                    sueldoBase = row.Cells("SueldoBase").Value
                    If IsDBNull(row.Cells("Ajuste").Value) = False Then
                        'If row.Cells("Ajuste").Value <> "" Then
                        ajuste = CDbl(row.Cells("Ajuste").Value)
                        'End If
                    End If
                        totalPagar = row.Cells("TotalPagar").Value

                    objColaborador.PColaboradorid = colaboradorID
                    objEnt.PPeriodoNominaID = cmbPeriodoNomina.SelectedValue
                    objEnt.PRealCantidad = sueldoBase
                    objEnt.PajusteDestajo = ajuste
                    objEnt.PTotalDestajos = totalPagar
                    objEnt.PusuarioCreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    objEnt.PfechaCreacion = FechaFin
                    objEnt.PColaborador = objColaborador

                    objBU.cierreDestajos(objEnt)
                End If
            Next

            Dim mensajeExitoG As New ExitoForm
            mensajeExitoG.MdiParent = Me.MdiParent
            mensajeExitoG.mensaje = "Cierre de destajos guardada."
            mensajeExitoG.Show()
            'grdDestajos.Rows.Clear()
            grdDestajos.DataSource = Nothing
            stPeriodoDestajos = "C"
            btnCerrarDestajos.Visible = False
            lblGuardar.Visible = False
        End If

    End Sub

    Private Sub grdDestajos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grdDestajos.CellValueChanged
        Dim acumulado As Double = 0
        Dim acumuladoAjuste As Double = 0
        Dim totalDestajo As Double = 0
        Dim ajuste As Double = 0
        If e.ColumnIndex = "6" Then
            For Each row As DataGridViewRow In grdDestajos.Rows

                If row.Cells("IdColaborador").Value.ToString <> "" Then
                    totalDestajo = row.Cells("Acumulado").Value
                    ajuste = row.Cells("Ajuste").Value
                    row.Cells("Ajuste").Value = CDec(Math.Round(ajuste, 2).ToString("N2"))
                    row.Cells("TotalPagar").Value = CDec(Math.Round((totalDestajo + ajuste), 2).ToString("N2"))
                    acumulado += row.Cells("TotalPagar").Value
                        acumuladoAjuste += row.Cells("Ajuste").Value

                    Else
                        ' row.Cells("clmTotalPagar").Value = acumulado
                        ' row.Cells("clmAjuste").Value = acumuladoAjuste
                        lblTotalPagarMostar.Text = acumulado
                    lblTotalAjusteMostrar.Text = acumuladoAjuste

                End If


            Next
            lblTotalPagarMostar.Text = acumulado
            lblTotalAjusteMostrar.Text = acumuladoAjuste
        End If


    End Sub


    Private Sub cmbCelula_DropDownClosed(sender As Object, e As EventArgs) Handles cmbCelula.DropDownClosed
        btnCerrarDestajos.Visible = False
        lblGuardar.Visible = False
        'grdDestajos.Rows.Clear()
        grdDestajos.DataSource = Nothing
        lblTotalAcumuladoMostar.Text = ""
        lblTotalAjusteMostrar.Text = ""
        lblTotalPagarMostar.Text = ""
    End Sub


    Private Sub grdDestajos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles grdDestajos.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)

        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim columna As Integer = grdDestajos.CurrentCell.ColumnIndex

        If columna = 5 Then

            Dim caracter As Char = e.KeyChar
            Dim txt As TextBox = CType(sender, TextBox)
            If (Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ".") And (txt.Text.Contains(".") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        'grdDestajos.Rows.Clear()
        grdDestajos.DataSource = Nothing
        btnCerrarDestajos.Visible = False
        lblGuardar.Visible = False
        lblTotalAcumuladoMostar.Text = ""
        lblTotalAjusteMostrar.Text = ""
        lblTotalPagarMostar.Text = ""
        cmbCelula.Text = ""
        cmbDepartamento.Text = ""
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 122
    End Sub

    Public Sub llenarComboPeriodos()
        Dim objPeriBU As New Negocios.ControlDePeriodoBU
        Dim dtPeriodos As New DataTable
        dtPeriodos = objPeriBU.buscarPeriodoSegunNavesSegunAsistenciaAnio(cmbNave.SelectedValue)
        cmbPeriodoNomina.DataSource = dtPeriodos
        dtPeriodos.Rows.InsertAt(dtPeriodos.NewRow, 0)
        cmbPeriodoNomina.DisplayMember = "pnom_Concepto"
        cmbPeriodoNomina.ValueMember = "pnom_PeriodoNomId"
    End Sub

End Class