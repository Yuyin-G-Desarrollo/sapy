Imports Nomina.Negocios
Imports Tools

Public Class AltasPeriodosNominaForm
    Public fechaseleccionada As Boolean = False
    Public idPeriodo As Int32
    Dim fecha As Date
    Public semana As Integer
    Public inicio As Date
    Public fin As Date
    Public Concepto As String
    Public naveid As Integer
    Public navess As Int32
    Public Status As String


    Public Property Pnave As Int32
        Get
            Return navess
        End Get
        Set(value As Int32)
            navess = value
        End Set
    End Property
    'Dim fechaSeleccionada As Boolean

    Public Property PidPeriodo As Int32
        Get
            Return idPeriodo

        End Get
        Set(value As Int32)
            idPeriodo = value
        End Set
    End Property

    Property nave As Int32

    Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click
        lblGuardar.Visible = True
        btnGuardar.Visible = True

        CgrdPeriodos.Rows.Count = 1
        'Dim fila As String = ""
        'fila = "" + ControlChars.Tab + txtSemana.ToString + ControlChars.Tab
        'Dim PERIODO As Entidades.PeriodosNomina
        Dim semana As Integer = txtSemana.Text
        Dim index As Date = dtpInicio.Value
        Dim var As Date = dtpInicio.Value
        Dim fin As Date = dtpFinal.Value
        Dim status As String = cmbEstado.Text
        Dim contador As Integer = 1
        Dim anio As Integer = fin.Year
        Dim PeriodoNomina As Entidades.PeriodosNomina
        Dim NAVE As New Entidades.Naves
        Dim PERIODO As New Entidades.PeriodosNomina
        semana = semana



        If cmbNaves.SelectedIndex > 0 Then
            NAVE.PNaveId = CInt(cmbNaves.SelectedValue)
            PERIODO.PNave = NAVE

        End If



        While index.Year = anio


            'Dim NAVE As New Entidades.Naves
            'Dim PERIODO As New Entidades.PeriodosNomina
            'semana = semana



            'If cmbNaves.SelectedIndex > 0 Then
            '	NAVE.PNaveId = CInt(cmbNaves.SelectedValue)
            '	PERIODO.PNave = NAVE

            'End If
            ''
            'If index = fin Then


            var = var.AddDays(6)

            If contador = 1 Then
                var = dtpFinal.Value
            ElseIf contador = 2 Then
                index = dtpFinal.Value.AddDays(1)
                var = index.AddDays(6)
            Else
                var = index.AddDays(6)
            End If


            contador = contador + 1

            Dim concepto As String
            concepto = "SEMANA DE NÓMINA DEL " + index.ToString("dd/MM/yyyy") + " AL " + var.ToString("dd/MM/yyyy")

            Dim estado As String
            estado = "" + status.ToString

            CgrdPeriodos.AddItem(ControlChars.Tab + semana.ToString + ControlChars.Tab + index.ToString + ControlChars.Tab + var.ToString + ControlChars.Tab + concepto.ToString + ControlChars.Tab + NAVE.PNaveId.ToString + ControlChars.Tab + status.ToString + ControlChars.Tab)

            index = fin.AddDays(1)
            fin = index.AddDays(6)

            var = index
            semana = semana + 1
            'Else

            'End If
        End While
        PeriodoNomina = New Entidades.PeriodosNomina
        PeriodoNomina.PFechaInicio = dtpInicio.Value
        PeriodoNomina.FechaFin = fin
        'PeriodoNomina.PNave = cmbNaves.SelectedValue
        'PeriodoNomina.PNave = NAVE
        If cmbNaves.SelectedIndex > 0 Then
            NAVE.PNaveId = CInt(cmbNaves.SelectedValue)
            PeriodoNomina.PNave = NAVE

        End If


        Dim objBU As New Nomina.Negocios.ControlDePeriodoBU
        objBU.VerificaPeriodo(PeriodoNomina)

        If objBU.Resultado.Length > 0 Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = objBU.Resultado.ToString
            mensajeAdvertencia.ShowDialog()
            CgrdPeriodos.Rows.Count = 1

        End If
        '

        Debug.WriteLine(" ")

        'btnGuardar.Visible = True
        'lblGuardar.Visible = True


    End Sub

    Private Sub AltasPeriodosNominaForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'lblAltasPeriodosNomina.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblGenerar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblGuardar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)

        'lblCancelar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        ''CgrdPeriodos.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.grid)

        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)




        'Dim filaSeleccionada As Integer
        'filaSeleccionada = CgrdPeriodos.RowSel

        'Dim Concepto As Integer
        'Concepto = CgrdPeriodos.GetData(filaSeleccionada, 0)

        InitCombos()

        Dim objexeBU As New Negocios.ControlDePeriodoBU
        Dim periodo As New Entidades.PeriodosNomina
        Dim naves As New Entidades.Naves


        'periodo = objexeBU.BuscarPeridosSeleccionados(idPeriodo)
        txtSemana.Text = semana.ToString
        dtpInicio.Value = inicio.ToString
        cmbNaves.SelectedValue = navess


        periodo.PNave = periodo.PNave

        cmbEstado.Text = Status
        periodo.PEstadoPeriodoDeNomina = periodo.PEstadoPeriodoDeNomina

        'txtConcepto.Text = periodo.PConcepto
        dtpFinal.Value = fin.ToString
        txtConcepto.Text = Concepto
        'dtpInicio.Value = periodo.PFechaInicio

        btnGuardar.Visible = False
        lblGuardar.Visible = False


        'llenarTabla()
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

    Private Sub cmbNaves_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNaves.SelectedIndexChanged
        Dim nave As Int32 = 0
        If cmbNaves.SelectedIndex > 0 Then
            nave = CInt(cmbNaves.SelectedValue)
            lblGenerar.Visible = True
            btnGenerar.Visible = True
        Else
            lblGenerar.Visible = False
            btnGenerar.Visible = False

        End If

    End Sub

    Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim falla As Boolean = False

        If txtSemana.Text <> "" Then

            lblSemana.ForeColor = Color.Black
        Else
            lblSemana.ForeColor = Color.Red
            falla = True

        End If

        If cmbNaves.Text <> "" Then

            lblNaves.ForeColor = Color.Black
        Else
            lblNaves.ForeColor = Color.Red
            falla = True

        End If



        If falla Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.MdiParent = Me.MdiParent

            mensajeAdvertencia.mensaje = "Faltan campos por completar"
            mensajeAdvertencia.Show()

        Else

        End If

        Dim i As Int32
        For i = 1 To CgrdPeriodos.Rows.Count - 1
            Dim periodo As New Entidades.PeriodosNomina

            Dim nave As New Entidades.Naves

            'periodo.PConcepto = txtConcepto.Text
            periodo.PsemanaNomina = CInt(CgrdPeriodos.GetData(i, 1))
            periodo.FechaInicio = CgrdPeriodos.GetData(i, 2)
            periodo.PFechaFin = CgrdPeriodos.GetData(i, 3)
            periodo.PConcepto = CgrdPeriodos.GetData(i, 4)

            periodo.pStCajaAhorro = CgrdPeriodos.GetData(i, "ColCajaA").ToString
            'periodo.pAsistencia = CgrdPeriodos.GetData(i, "ColAsistencia").ToString
            Dim estado As String = ""
            Dim textoEstatus = CgrdPeriodos.GetData(i, "ColStatus").ToString
            If textoEstatus = "ACTIVO" Then
                estado = "A"
            ElseIf textoEstatus = "BLOQUEADO" Then
                estado = "B"
            ElseIf textoEstatus = "CERRADO" Then
                estado = "C"
            End If

            periodo.PEstadoPeriodoDeNomina = estado

            If cmbNaves.SelectedIndex > 0 Then
                nave.PNaveId = CInt(cmbNaves.SelectedValue)
                periodo.PNave = nave

            End If

            If cmbEstado.SelectedIndex > 0 Then
                periodo.PEstadoPeriodoDeNomina = CInt(cmbNaves.SelectedValue)
                periodo.PEstadoPeriodoDeNomina = periodo.PEstadoPeriodoDeNomina

            End If

            Dim objperiodoBU As New Nomina.Negocios.ControlDePeriodoBU

            objperiodoBU.Alta(periodo)




        Next i

        Dim mensajeExito As New ExitoForm
        mensajeExito.mensaje = "Transaccion exitosa"
        mensajeExito.ShowDialog()
        Me.Close()




        ' ''Me.Close()
        ' ''Dim mensajeExito As New ExitoForm
        ' ''mensajeExito.MdiParent = Me.MdiParent
        ' ''mensajeExito.mensaje = "Transaccion exitosa"
        ' ''mensajeExito.Show()
        '' ''MsgBox("Transaccion exitosa")
        ' ''Me.Close()
        ' ''End If

    End Sub
    Public Sub InitCombos()

        cmbNaves = Tools.Controles.ComboNavesSegunUsuario(cmbNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

    End Sub

    Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs)
        CgrdPeriodos.Height = 365
        grbPeriodoAltas.Height = 43
        CgrdPeriodos.Top = 130
    End Sub

    Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs)
        CgrdPeriodos.Height = 240
        grbPeriodoAltas.Height = 170
        CgrdPeriodos.Top = 250
    End Sub

    Private Sub lblCancelar_Click(sender As Object, e As EventArgs) Handles lblCancelar.Click

    End Sub

    Private Sub lblGuardar_Click(sender As Object, e As EventArgs) Handles lblGuardar.Click

    End Sub

    Private Sub lblFechaInicio_Click(sender As Object, e As EventArgs) Handles lblFechaInicio.Click

    End Sub

    Private Sub grbPeriodoAltas_Enter(sender As Object, e As EventArgs) Handles grbPeriodoAltas.Enter

    End Sub

    Private Sub lblFEchaFinal_Click(sender As Object, e As EventArgs) Handles lblFEchaFinal.Click

    End Sub

    Private Sub lblSemana_Click(sender As Object, e As EventArgs) Handles lblSemana.Click

    End Sub

    Private Sub lblNaves_Click(sender As Object, e As EventArgs) Handles lblNaves.Click

    End Sub

    Private Sub CgrdPeriodos_Click(sender As Object, e As EventArgs) Handles CgrdPeriodos.Click

    End Sub
End Class