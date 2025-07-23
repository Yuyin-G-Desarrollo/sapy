Imports Tools

Public Class ControlPeriodosNominaForm
    Public fechaseleccionada As Boolean = False
    Public RegistroGuardado As Boolean = False
    '
    Private Sub ControlPeriodosNominaForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        'lblControlPeriodos.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblAltas.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblBúscar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'Editar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblLimpiar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'CgrdPeriodos.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.grid)

        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)

        InitCombos()
        'llenarTabla()

        'CgrdPeriodos.Rows.Count = 1
    End Sub
    Public Sub llenarTabla()
        CgrdPeriodos.Rows.Count = 1
        Dim Naves As Int32 = 0


        If cmbNaves.SelectedIndex > 0 Then
            Naves = CInt(cmbNaves.SelectedValue)
        End If


        Dim listaPeriodos As New List(Of Entidades.PeriodosNomina)
        Dim objBU As New Negocios.ControlDePeriodoBU
        listaPeriodos = objBU.ListaPeriodosDeNomina(Naves, dtpInicio.Value, dtpFinal.Value, fechaseleccionada)
        For Each exe As Entidades.PeriodosNomina In listaPeriodos
            AgregarFila(exe)
        Next

    End Sub


    Public Sub AgregarFila(ByVal exe As Entidades.PeriodosNomina)

        Dim fila As String = ""
        Dim estado As String = ""
        If exe.EstadoPeriodoNomina.Equals("B") Then
            estado = "Bloqueada"
        End If
        If exe.EstadoPeriodoNomina.Equals("C") Then
            estado = "Cerrada"
        End If
        If exe.EstadoPeriodoNomina.Equals("A") Then
            estado = "Activa"
        End If

        fila = "" + ControlChars.Tab + exe.PPeriodoId.ToString + ControlChars.Tab + exe.SemanaNomina.ToString + ControlChars.Tab + exe.PFechaInicio.ToString("dd/MM/yyyy") + ControlChars.Tab
        fila = fila & exe.PFechaFin.ToString("dd/MM/yyyy") & ControlChars.Tab + exe.PNave.PNaveId.ToString + ControlChars.Tab + estado.ToString + ControlChars.Tab + exe.PConcepto.ToString + ControlChars.Tab + exe.pStCajaAhorro.ToString + ControlChars.Tab + exe.pAsistencia.ToString


        CgrdPeriodos.AddItem(fila)
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click

        CgrdPeriodos.Rows.Count = 1
        If (cmbNaves.SelectedIndex > 0) Then
            llenarTabla()
        End If
    End Sub

    Private Sub dtpFinal_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFinal.ValueChanged
        CgrdPeriodos.Rows.Count = 1
        fechaseleccionada = True
        llenarTabla()
    End Sub

    Private Sub pnlEncabezado_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlEncabezado.Paint

    End Sub

    Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltas.Click
        Dim altasForm As New AltasPeriodosNominaForm

        Dim concepto As String

        Dim estado As String


        Dim semana As Integer


        Dim fechaInicio As Date


        Dim fechaFin As Date


        Dim Nave As String


        If CgrdPeriodos.Rows.Count < 2 Then


            concepto = "" 'CgrdPeriodos.GetData(filaSeleccionada, 6)


            estado = "" ' CgrdPeriodos.GetData(filaSeleccionada, 5)


            semana = "1" 'CgrdPeriodos.GetData(filaSeleccionada, 2)


            fechaInicio = Now 'CDate(CgrdPeriodos.GetData(filaSeleccionada, 3))


            fechaFin = Now 'CDate(CgrdPeriodos.GetData(filaSeleccionada, 4))


            Nave = cmbNaves.SelectedValue '(CgrdPeriodos.GetData(filaSeleccionada, 7))

            altasForm.MdiParent = Me.MdiParent
            altasForm.semana = semana
            altasForm.inicio = fechaInicio
            altasForm.fin = fechaFin
            altasForm.Pnave = Nave
            'altasForm.PidPeriodo = IdPeriodo
            altasForm.Concepto = concepto

            altasForm.Show()
            Exit Sub
        End If

        Dim filaSeleccionada As Integer
        filaSeleccionada = CgrdPeriodos.RowSel

        'Dim concepto As String

        concepto = CgrdPeriodos.GetData(filaSeleccionada, 7)

        'Dim estado As String
        estado = CgrdPeriodos.GetData(filaSeleccionada, 6)

        'Dim semana As Integer
        semana = CgrdPeriodos.GetData(filaSeleccionada, 2)

        'Dim fechaInicio As Date
        fechaInicio = CDate(CgrdPeriodos.GetData(filaSeleccionada, 3))

        'Dim fechaFin As Date
        fechaFin = CDate(CgrdPeriodos.GetData(filaSeleccionada, 4))

        'Dim Nave As String
        Nave = (CgrdPeriodos.GetData(filaSeleccionada, 5))


        altasForm.MdiParent = Me.MdiParent
        altasForm.semana = semana
        altasForm.inicio = fechaInicio
        altasForm.fin = fechaFin
        altasForm.Pnave = Nave
        altasForm.Status = estado
        'altasForm.PidPeriodo = IdPeriodo
        altasForm.Concepto = concepto
        altasForm.Show()


    End Sub

    Public Sub InitCombos()

        cmbNaves = Tools.Controles.ComboNavesSegunUsuario(cmbNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

    End Sub

    Private Sub cmbNaves_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNaves.SelectedIndexChanged
        Dim nave As Int32 = 0
        If cmbNaves.SelectedIndex > 0 Then
            nave = CInt(cmbNaves.SelectedValue)
        End If
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click


        If CgrdPeriodos.Rows.Count <= 1 Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.MdiParent = Me.MdiParent

            mensajeAdvertencia.mensaje = "No hay periodos de nomina por editar , seleccione alguna Nave"
            mensajeAdvertencia.Show()
            'MessageBox.Show("Debe no hay periodos de nomina por editar")
        Else



            Dim EditarForm As New EditarPeriodosNominaForm

            Dim concepto As String

            Dim estado As String


            Dim semana As Integer


            Dim fechaInicio As Date


            Dim fechaFin As Date


            Dim Nave As String
            Dim naveid As Int32

            If CgrdPeriodos.Rows.Count < 2 Then


                concepto = ""


                estado = ""

                semana = "1"


                fechaInicio = Now


                fechaFin = Now


                Nave = cmbNaves.SelectedValue

                EditarForm.MdiParent = Me.MdiParent
                EditarForm.semana = semana
                EditarForm.inicio = fechaInicio
                EditarForm.fin = fechaFin
                EditarForm.naveid = naveid
                EditarForm.Concepto = concepto
                EditarForm.Status = estado
                RegistroGuardado = False
                EditarForm.Show()

                Exit Sub
            End If


            Dim filaSeleccionada As Integer
            filaSeleccionada = CgrdPeriodos.RowSel

            concepto = CgrdPeriodos.GetData(filaSeleccionada, 7)


            semana = CgrdPeriodos.GetData(filaSeleccionada, 2)


            fechaInicio = CDate(CgrdPeriodos.GetData(filaSeleccionada, 3))


            fechaFin = CDate(CgrdPeriodos.GetData(filaSeleccionada, 4))


            estado = CgrdPeriodos.GetData(filaSeleccionada, 6)

            naveid = CInt(CgrdPeriodos.GetData(filaSeleccionada, 5))




            EditarForm.MdiParent = Me.MdiParent
            EditarForm.semana = semana
            EditarForm.inicio = fechaInicio
            EditarForm.fin = fechaFin
            EditarForm.naveid = naveid
            EditarForm.Concepto = concepto
            EditarForm.Status = estado
            RegistroGuardado = False
            EditarForm.Show()



        End If


    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
        cmbNaves.SelectedIndex = -1
        CgrdPeriodos.Rows.Count = 1

    End Sub

    Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
        CgrdPeriodos.Height = 413 '355
        grbPeriodos.Height = 44
        CgrdPeriodos.Top = 125
    End Sub

    Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
        CgrdPeriodos.Height = 316 '240
        grbPeriodos.Height = 141 '170
        CgrdPeriodos.Top = 217 '250
    End Sub


    Private Sub dtpInicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpInicio.ValueChanged
        fechaseleccionada = True
        CgrdPeriodos.Rows.Count = 1
        llenarTabla()
    End Sub

    Private Sub CgrdPeriodos_Click(sender As System.Object, e As System.EventArgs) Handles CgrdPeriodos.Click

    End Sub

    Private Sub pcbTitulo_Click(sender As Object, e As EventArgs) Handles pcbTitulo.Click

    End Sub
End Class