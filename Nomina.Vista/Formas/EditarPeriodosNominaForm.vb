Imports Nomina.Negocios
Imports Tools

Public Class EditarPeriodosNominaForm

    Public fechaseleccionada As Boolean = False
    Public idPeriodo As Int32
    Dim fecha As Date
    Public semana As Integer
    Public inicio As Date
    Public fin As Date
    Public Concepto As String
    'Public Naves As Entidades.Naves
    Public naveid As Integer
    Public Status As String

    'Dim fechaSeleccionada As Boolean

    Public Property PidPeriodo As Int32
        Get
            Return idPeriodo

        End Get
        Set(value As Int32)
            idPeriodo = value
        End Set
    End Property
    'Public Property PNaves As Entidades.Naves
    '	Get
    '		Return Naves

    '	End Get
    '	Set(value As Entidades.Naves)
    '		Naves = value


    '	End Set
    'End Property

    Private Sub EditarPeriodosNominaForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        Dim objexeBU As New Negocios.ControlDePeriodoBU
        Dim periodo As New Entidades.PeriodosNomina
        'Dim naves As New Entidades.Naves


        'periodo = objexeBU.BuscarPeridosSeleccionados(idPeriodo)
        txtNoSemana.Text = semana.ToString
        txtNoSemana.Enabled = False
        dtpIni.Value = inicio.ToString
        dtpIni.Enabled = False
        'MessageBox.Show(naveid)
        cmbNave.SelectedValue = naveid
        cmbNave.Enabled = False
        'cmbNave.SelectedValue = naveid
        'periodo.PNave = naves

        'txtConcepto.Text = periodo.PConcepto
        dtpFin.Value = fin.ToString
        txtConcepto.Text = Concepto
        'dtpInicio.Value = periodo.PFechaInicio


        cmbEstado.Text = Status
        periodo.PEstadoPeriodoDeNomina = periodo.PEstadoPeriodoDeNomina


        'lblEditarPeriodosNomina.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblGenerar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblGuardar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)

        'lblCancelar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        ''grdPeriodos.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.grid)

        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)

    End Sub

    Public Sub InitCombos()

        cmbNaves = Tools.Controles.ComboNavesSegunUsuario(cmbNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
        'Dim nave As Int32 = 0
        'If cmbNave.SelectedIndex > 0 Then
        '	nave = CInt(cmbNave.SelectedValue)
        'End If
    End Sub

    Public Sub llenarTabla()
        CgrdPeriodos.Rows.Count = 1
        Dim Naves As Int32 = 0


        If cmbNave.SelectedIndex > 0 Then
            Naves = CInt(cmbNave.SelectedValue)
        End If


        Dim listaPeriodos As New List(Of Entidades.PeriodosNomina)
        Dim objBU As New Negocios.ControlDePeriodoBU
        listaPeriodos = objBU.ListaPeriodosDeNomina(Naves, dtpInicio.Value, dtpFinal.Value, fechaseleccionada)
        For Each exe As Entidades.PeriodosNomina In listaPeriodos
            AgregarFila(exe)
        Next

    End Sub

    Public Sub AgregarFila(ByVal exe As Entidades.PeriodosNomina)

        'Dim fila As String = ""
        'fila = "" + ControlChars.Tab + exe.SemanaNomina.ToString + ControlChars.Tab

        'Dim index As Date = exe.PFechaInicio.ToString
        'Dim var As Date = exe.PFechaInicio.ToString

        'While index.Year <= exe.PFechaFin.Year

        '	var = var.AddDays(6)


        '	CgrdPeriodos.AddItem(fila + index.ToString + ControlChars.Tab + var.ToString + ControlChars.Tab)
        '	index = index.AddDays(7)
        '	var = index


        'End While


        'Debug.WriteLine(" ")

        Dim fila As String = ""
        fila = "" + ControlChars.Tab + exe.SemanaNomina.ToString + ControlChars.Tab

        Dim index As Date = dtpInicio.Value
        Dim var As Date = dtpInicio.Value
        Dim fin As Date = dtpFinal.Value


        While index.Year <= fin.Year

            var = var.AddDays(6)


            CgrdPeriodos.AddItem(fila + index.ToString + ControlChars.Tab + var.ToString + ControlChars.Tab)
            index = index.AddDays(7)
            var = index


        End While


        Debug.WriteLine(" ")



    End Sub

    Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltas.Click
        grdPeriodos.Rows.Count = 1
        'Dim fila As String = ""
        'fila = "" + ControlChars.Tab + txtSemana.ToString + ControlChars.Tab

        Dim semana As Integer = txtNoSemana.Text
        Dim index As Date = dtpIni.Value
        Dim var As Date = dtpIni.Value
        Dim fin As Date = dtpFin.Value
        Dim status As String = cmbEstado.Text
        Dim contador As Integer = 1
        While index.Year <= fin.Year
            semana = semana

            Dim NAVE As New Entidades.Naves
            Dim PERIODO As New Entidades.PeriodosNomina

            If cmbNave.SelectedIndex > 0 Then
                NAVE.PNaveId = CInt(cmbNave.SelectedValue)
                PERIODO.PNave = NAVE

            End If




            If contador = 1 Then
                var = dtpFin.Value
            ElseIf contador = 2 Then
                index = dtpFin.Value.AddDays(1)
                var = index.AddDays(6)
            Else
                var = index.AddDays(6)
            End If


            contador = contador + 1

            Dim concepto As String
            concepto = "SEMANA DE NÓMINA DEL " + index.ToString("dd/MM/yyyy") + " AL " + var.ToString("dd/MM/yyyy")


            grdPeriodos.AddItem(ControlChars.Tab + ControlChars.Tab + semana.ToString + ControlChars.Tab + index.ToString + ControlChars.Tab + var.ToString + ControlChars.Tab + NAVE.PNaveId.ToString + ControlChars.Tab + status.ToString + ControlChars.Tab + concepto.ToString)

            index = index.AddDays(7)

            var = index
            semana = semana + 1

        End While


        Debug.WriteLine(" ")

        Button1.Visible = True
        Label2.Visible = True

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim falla As Boolean = False
        Dim objperiodoBU As New ControlDePeriodoBU

        ''

        'If txtConcepto.Text <> "" Then

        '	lblConcepto.ForeColor = Color.Black
        'Else


        '	lblConcepto.ForeColor = Color.Red
        '	falla = True

        'End If
        'If txtSemana.Text <> "" Then

        '	lblSemana.ForeColor = Color.Black
        'Else


        '	lblSemana.ForeColor = Color.Red
        '	falla = True

        'End If

        'If cmbNaves.Text <> "" Then

        '	lblNaves.ForeColor = Color.Black
        'Else


        '	lblNaves.ForeColor = Color.Red
        '	falla = True

        'End If



        If falla Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.MdiParent = Me.MdiParent

            mensajeAdvertencia.mensaje = "Faltan campos por completar"
            mensajeAdvertencia.Show()
            'MsgBox("Falta completar campos")
        Else


            objperiodoBU.eliminarPer(CInt(txtNoSemana.Text), cmbNave.SelectedValue) ' ESTE SI

            Dim i As Int32
            For i = 1 To grdPeriodos.Rows.Count - 1
                Dim periodo As New Entidades.PeriodosNomina
                Dim nave As New Entidades.Naves

                'periodo.PConcepto = txtConcepto.Text
                periodo.PsemanaNomina = grdPeriodos.GetData(i, 2)
                periodo.FechaInicio = grdPeriodos.GetData(i, 3)
                periodo.PFechaFin = grdPeriodos.GetData(i, 4)
                periodo.PConcepto = grdPeriodos.GetData(i, 7)

                Dim estado As String = ""
                Dim textoEstatus = grdPeriodos.GetData(i, "ColEstado").ToString
                If textoEstatus = "ACTIVO" Then
                    estado = "A"
                ElseIf textoEstatus = "BLOQUEADO" Then
                    estado = "B"
                ElseIf textoEstatus = "CERRADO" Then
                    estado = "C"
                End If

                periodo.PEstadoPeriodoDeNomina = estado


                If cmbNave.SelectedIndex > 0 Then
                    nave.PNaveId = CInt(cmbNave.SelectedValue)
                    periodo.PNave = nave
                    'Accion.PModulo.PModuloid = CInt(cmbModulo.SelectedValue)

                End If
                periodo.PPeriodoId = idPeriodo

                objperiodoBU.Alta(periodo)  ' ESTO NO
                'altas ' ESTE SI
            Next i


            Me.Close()
            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "Registro Guardado"
            mensajeExito.Show()
            'MsgBox("Transaccion exitosa")
            'Me.Close()



        End If
    End Sub

    Private Sub abajo_Click(sender As System.Object, e As System.EventArgs)
        grdPeriodos.Height = 240
        periodos.Height = 170
        grdPeriodos.Top = 250
    End Sub

    Private Sub arriba_Click(sender As System.Object, e As System.EventArgs)
        grdPeriodos.Height = 360
        periodos.Height = 43
        grdPeriodos.Top = 130
    End Sub

    Private Sub grdPeriodos_Click(sender As System.Object, e As System.EventArgs)

    End Sub
End Class