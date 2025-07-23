Imports Nomina.Negocios
Imports Tools

Public Class AutorizacionHorasExtrasForm
    Dim PeriodoNomina As New Int32
    Private Sub AutorizacionHorasExtrasForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        'Dim HorasExtras As Double
        Me.Top = 0
        Me.Left = 0

    End Sub


    Public Function CargarInformacionLaboral(ByVal Colaboradorid) As Int32
        Dim objBULaboral As New Negocios.ColaboradorLaboralBU
        Dim EntidadLaboral As New Entidades.ColaboradorLaboral
        Dim SemanaActiva As New HorasExtrasBU

        EntidadLaboral = objBULaboral.buscarInformacionLaboral(Colaboradorid)
        Try
            Dim Seman As New Entidades.PeriodosNomina
            Seman = SemanaActiva.SemanaActiva(EntidadLaboral.PNaveId.PNaveId)
            CargarInformacionLaboral = Seman.PeriodoId

        Catch ex As Exception

        End Try
    End Function

    Public Sub LlenarCamposVacios()
        Dim sentinela As New Int32
        sentinela = 0
        Dim objBU As New Negocios.HorasExtrasBU



        For Each row As DataGridViewRow In gridConfiguracionAsistencia.Rows
            Dim pruebas As New Entidades.PeriodosNomina



            Dim diaInicio As Date
            diaInicio = pruebas.FechaInicio
            Dim diaFin As Date
            diaFin = pruebas.PFechaFin


            Dim objBULaboral As New Negocios.ColaboradorLaboralBU
            Dim EntidadLaboral As New Entidades.ColaboradorLaboral
            Dim objBUNomina As New Negocios.ColaboradorNominaBU
            Dim EntidadNomina As New Entidades.ColaboradorNomina
            Dim SemanaActiva As New HorasExtrasBU
            Dim SemanaActivaID As Int32
            EntidadNomina = objBUNomina.buscarColaborarNomina(gridConfiguracionAsistencia.Rows(sentinela).Cells("IDColaborador").Value)
            EntidadLaboral = objBULaboral.buscarInformacionLaboral(gridConfiguracionAsistencia.Rows(sentinela).Cells("IDColaborador").Value)
            pruebas = objBU.SemanaActiva(EntidadLaboral.PNaveId.PNaveId)

            Try
                Dim Seman As New Entidades.PeriodosNomina

                Seman = SemanaActiva.SemanaActiva(EntidadLaboral.PNaveId.PNaveId)
                SemanaActivaID = Seman.PeriodoId
                PeriodoNomina = Seman.PeriodoId
            Catch ex As Exception

            End Try


            gridConfiguracionAsistencia.Rows(sentinela).Cells("HorasExtras").Value = HorasExtrasCal(gridConfiguracionAsistencia.Rows(sentinela).Cells("IDColaborador").Value, gridConfiguracionAsistencia.Rows(sentinela).Cells("HorarioID").Value, EntidadLaboral.PNaveId.PNaveId)
            gridConfiguracionAsistencia.Rows(sentinela).Cells("Cantidad").Value = gridConfiguracionAsistencia.Rows(sentinela).Cells("HorasExtras").Value * (EntidadNomina.PSalarioDiario / 8.5)
            Dim FaltasRetardos As Entidades.HorasExtras
            FaltasRetardos = objBU.Retardos(SemanaActivaID, gridConfiguracionAsistencia.Rows(sentinela).Cells("IDColaborador").Value)
            Try
                gridConfiguracionAsistencia.Rows(sentinela).Cells("RetardoMenor").Value = FaltasRetardos.PRetardosMenores
                gridConfiguracionAsistencia.Rows(sentinela).Cells("Inasistencias").Value = FaltasRetardos.PFaltas
                gridConfiguracionAsistencia.Rows(sentinela).Cells("RetardoMayor").Value = FaltasRetardos.PRetardosMayores
            Catch ex As Exception

            End Try



            sentinela += 1

        Next


    End Sub

    Public Function HorasExtrasCal(ByVal idColaborador As Int32, ByVal idHorario As Int32, ByVal semanaActiva As Int32) As Double
        Dim objBU As New Negocios.HorasExtrasBU
        Dim pruebas As New Entidades.PeriodosNomina
        pruebas = objBU.SemanaActiva(semanaActiva)
        Dim SumaMinutosSemanales, SumaMinutosExtras As New Int32
        Dim diaInicio As Date
        diaInicio = pruebas.FechaInicio
        Dim diaFin As Date
        diaFin = pruebas.PFechaFin
        Dim diaActual As Date
        diaActual = diaInicio


        While Not (diaActual = diaFin.AddDays(1))
            ' MessageBox.Show(diaActual.ToShortDateString)
            SumaMinutosExtras += objBU.CalculoHorasExtras(diaActual, diaActual.AddDays(1), idColaborador, idHorario, diaActual.DayOfWeek)
            diaActual = diaActual.AddDays(1)
        End While
        Dim HorasExtras As New Double
        ' HorasExtras = SumaMinutosExtras / 60
        ' MsgBox(HorasExtras.ToString)

        Return HorasExtras

    End Function



    Public Sub LlenarTabla()
        gridConfiguracionAsistencia.Rows.Clear()
        Dim objColaboradorBU As New ColaboradoresBU
        Dim listaColaboradores As New List(Of Entidades.Colaborador)
        Dim idNave = 0
        Dim idDepartamento = 0
        Dim idPuesto = 0
        If cmbNave.SelectedIndex > 0 Then
            idNave = cmbNave.SelectedValue
        End If

        listaColaboradores = objColaboradorBU.ListaColaboradoresFiltroCompletoGeneranHorasExtras _
            ("", "", "", True, idNave, 0, 0)
        For Each colaborador As Entidades.Colaborador In listaColaboradores
            AgregarFila(colaborador)
        Next
    End Sub


    Public Sub AgregarFila(ByVal colaborador As Entidades.Colaborador)
        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow
        Dim laboral As New Entidades.ColaboradorLaboral
        Dim objLaboralBU As New Negocios.ColaboradorLaboralBU


        laboral = objLaboralBU.buscarInformacionLaboral(colaborador.PColaboradorid)


        celda = New DataGridViewCheckBoxCell
        celda.Value = False
        fila.Cells.Add(celda)



        celda = New DataGridViewTextBoxCell
        celda.Value = colaborador.PNombre.ToUpper + " " + colaborador.PApaterno.ToUpper + " " + colaborador.PAmaterno.ToUpper
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = laboral.PPuestoId.PNombre
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = 0
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = 0
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = 0
        fila.Cells.Add(celda)


        If Not IsNothing(laboral) Then
            celda = New DataGridViewTextBoxCell
            If Not IsNothing(laboral.PHorarioId) Then
                celda.Value = laboral.PHorarioId.DHorariosid
            End If
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            If Not IsNothing(laboral.PDepartamentoId) Then
                celda.Value = 0
            End If
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            If Not IsNothing(laboral.PDepartamentoId) Then
                celda.Value = 0
            End If
            fila.Cells.Add(celda)
        End If
        celda = New DataGridViewTextBoxCell
        celda.Value = colaborador.PColaboradorid
        fila.Cells.Add(celda)


        gridConfiguracionAsistencia.Rows.Add(fila)



    End Sub

    Private Sub cmbNave_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
        If cmbNave.SelectedIndex > 0 Then
            Me.Cursor = Cursors.WaitCursor
            LlenarTabla()
            LlenarCamposVacios()
            Me.Cursor = Cursors.Default
        End If
    End Sub



    Public Sub AutorizarSolicitudes()

        Dim objHorasExtrasBU As New HorasExtrasBU




        Dim CountAcept As Int32 = 0
        Dim valorCheck As Integer
        Dim sentinela As Integer = 0
        Dim Validacion As Boolean = False
        For Each row As DataGridViewRow In gridConfiguracionAsistencia.Rows 'Recorro todo el grid fila por fila
            valorCheck = CInt(row.Cells(0).Value)

            If valorCheck <> 0 Then
                Dim entidad As New Entidades.HorasExtras
                entidad.PPeriodo = PeriodoNomina
                entidad.PColaboradorid = gridConfiguracionAsistencia.Rows(sentinela).Cells("IDColaborador").Value
                entidad.PHorasExtrasPeriodo = gridConfiguracionAsistencia.Rows(sentinela).Cells("HorasExtras").Value
                entidad.PMonto = gridConfiguracionAsistencia.Rows(sentinela).Cells("Cantidad").Value
                Validacion = objHorasExtrasBU.ValidacionHorasExtras(entidad.PColaboradorid, entidad.PPeriodo)
                If Validacion = False Then
                    objHorasExtrasBU.AutorizarHorasExtras(entidad)
                End If



                CountAcept += 1

            End If
            sentinela += 1
        Next


        Dim FormaExito As New ExitoForm
        FormaExito.mensaje = "Solicitudes Realizadas"
        FormaExito.Show()



    End Sub

    Private Sub btnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutorizar.Click
        If MessageBox.Show("¿Esta seguro que quiere aprobar las Solicitudes?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            AutorizarSolicitudes()


        End If

    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub


    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 94
    End Sub
End Class