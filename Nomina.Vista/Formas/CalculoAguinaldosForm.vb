Imports CrystalDecisions.Shared
Imports Stimulsoft.Report
Imports Tools

Public Class CalculoAguinaldosForm
    Dim totalAguinaldos2 As Double = 0
    Dim SalariosNov(,) As Double
    Dim limiteMatriz As Integer

    ''Esta varaiable asigna el parametro al reporte
    Dim Parametros As New ParameterFields()

    Dim fecha1 As String
    Dim fecha2 As String
    Dim fecha3 As String
    Dim fecha4 As String

    ''Esta variable indica el nombre del parametro que se encuentra en el procedimiento almacenado

    Dim anio As New ParameterField()
    Dim ruta As New ParameterField()
    Dim UserName As New ParameterField()
    Dim NombreArchivo As New ParameterField()
    Dim Nave As New ParameterField()
    Dim TotalAguinaldos As New ParameterField()
    Dim FechaFinalPeriodo As Date

    ''Esta variable toma el valor dle parametro

    Dim myDiscreteValueanio As New ParameterDiscreteValue()
    Dim myDiscreteValueRuta As New ParameterDiscreteValue()
    Dim myDiscreteValueUserName As New ParameterDiscreteValue()
    Dim myDiscreteValueNombreArchivo As New ParameterDiscreteValue()
    Dim myDiscreteValueNave As New ParameterDiscreteValue()
    Dim myDiscreteValueTotalAguinaldos As New ParameterDiscreteValue()




    Private Sub CalculoAguinaldosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Tools.FormatoCtrls.formato(Me)
        WindowState = FormWindowState.Maximized

        grdCalculoAguinaldo.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoAguinaldo.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoAguinaldo.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoAguinaldo.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoAguinaldo.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoAguinaldo.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoAguinaldo.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoAguinaldo.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoAguinaldo.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoAguinaldo.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoAguinaldo.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoAguinaldo.Columns(12).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoAguinaldo.Columns(13).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter


        grdCalculoAguinaldo.Columns(7).DefaultCellStyle.Format = "##0.0"


        'columna.Format = FormatoNumero
        'Dim FormatoNumero As String = "###,###,##0.00"

        Try
            Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            If cmbNave.SelectedValue > 0 Then
                cmbNaveDrop()

            End If
            btnGuardar.Enabled = False
            btnReporte.Enabled = False
            lblAnioActual.Visible = False
            lblRespaldoAnioActual.Visible = False

            lblcolaborador.Visible = False
            txtColaborador.Visible = False

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.DropDownClosed
        cmbNaveDrop()
    End Sub

    Public Sub AgregarAnios(ByVal Aguinaldo As List(Of Entidades.CalcularAguinaldos))

        Dim anios As List(Of Integer) = Aguinaldo.Select(Function(c) c.PAguinaldoAnio).Distinct.ToList
        Dim aniosTotales As Integer = anios.Count
        Dim contadorAnioActual As Integer = 0

        If aniosTotales = 0 Then
            cmbAnio.Items.Add(DateTime.Now.Year)
        Else
            For Each dato As Integer In anios
                If dato = DateTime.Now.Year Then
                    lblRespaldoAnioActual.Text = "True"
                    cmbAnio.Items.Add(dato)
                    contadorAnioActual = 1
                Else
                    cmbAnio.Items.Add(dato)
                End If
            Next
            If contadorAnioActual = 0 Then
                cmbAnio.Items.Add(DateTime.Now.Year)
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        If cmbNave.SelectedIndex > 0 And cmbAnio.SelectedIndex <> -1 Then

            Me.Cursor = Cursors.WaitCursor
            grdCalculoAguinaldo.Rows.Clear()

            Dim ObjBU As New Nomina.Negocios.CalcularAguinaldoBU
            Dim listaAguinaldos As List(Of Entidades.CalcularAguinaldos)
            Dim objAguiBU As New Negocios.CalcularAguinaldoBU

            btnReporte.Enabled = False

            If objAguiBU.ExisteAguinaldoNave(cmbNave.SelectedValue, cmbAnio.SelectedItem) = True Then
                ObtenerFiniquitoGuardado()

            Else
                btnGuardar.Enabled = True
                listaAguinaldos = ObjBU.ListaColaboradoresAguinaldo(cmbNave.SelectedValue)
                AgregarFilaAguinaldos(listaAguinaldos)
                lblcolaborador.Visible = False
                txtColaborador.Visible = False
            End If


            'If cmbAnio.SelectedItem < DateTime.Now.Year Or lblRespaldoAnioActual.Text = "True" Then
            '    ObtenerFiniquitoGuardado()
            'Else
            '    btnGuardar.Enabled = True

            '    listaAguinaldos = ObjBU.ListaColaboradoresAguinaldo(cmbNave.SelectedValue)
            '    AgregarFilaAguinaldos(listaAguinaldos)

            '    lblcolaborador.Visible = False
            '    txtColaborador.Visible = False
            'End If
            Me.Cursor = Cursors.Default

        Else

            Dim mensajeExito2 As New AdvertenciaForm
            'mensajeExito2.MdiParent = Me.MdiParent
            mensajeExito2.mensaje = "Se debe seleccionar la nave y el año."
            mensajeExito2.Show()
            btnGuardar.Enabled = False
        End If


    End Sub


    Private Sub ObtenerFiniquitoGuardado()
        Dim ObjBU As New Nomina.Negocios.CalcularAguinaldoBU
        Dim DTAguinaldos As DataTable
        Dim NombreColaborador As String = String.Empty
        Dim SalariosNov2(,) As Double
        Dim listaSalarios As List(Of Entidades.CalcularAguinaldos)
        Dim faltas As Double = 0
        Dim objAguiBU As New Negocios.CalcularAguinaldoBU
        Dim LimiteMatriz2 As Integer = 0
        Dim SumaAguinaldo As Double = 0
        Dim DiasTrabajados As Integer = 0
        Dim fechaFinalAnio As Date
        Dim FechaIngreso As Date
        Dim AñosTrabajados As Integer = 0
        Dim Meses As Int32 = 0
        Dim mesesTotal As Double = 0

        Dim diasme As Int32 = 0
        fechaFinalAnio = cmbAnio.SelectedItem.ToString + "-12-31"


        ReDim SalariosNov2(6, 2)

        DTAguinaldos = ObjBU.ListaAguinaldosGUARDADOS2(cmbNave.SelectedValue, cmbAnio.SelectedItem, txtColaborador.Text)

        For Each Fila As DataRow In DTAguinaldos.Rows
            diasme = 0
            Meses = 0
            LimiteMatriz2 = 0
            AñosTrabajados = 0
            NombreColaborador = String.Empty

            mesesTotal = 0


            If IsDBNull(Fila("codr_nombre")) = False Or IsNothing(Fila("codr_nombre")) = False Then
                NombreColaborador = Fila("codr_nombre")
            End If

            If IsDBNull(Fila("codr_apellidopaterno")) = False Or IsNothing(Fila("codr_apellidopaterno")) = False Then
                NombreColaborador = NombreColaborador + " " + Fila("codr_apellidopaterno")
            End If

            If IsDBNull(Fila("codr_apellidomaterno")) = False Or IsNothing(Fila("codr_apellidomaterno")) = False Then
                NombreColaborador = NombreColaborador + " " + Fila("codr_apellidomaterno")
            End If




            listaSalarios = objAguiBU.ListacolaboradoresSalarios(Fila("agui_colaboradorid"), CInt(cmbAnio.SelectedItem), CInt(cmbNave.SelectedValue))
            faltas = objAguiBU.FaltasPeriodosAguinaldo(Fila("agui_colaboradorid"), CInt(cmbAnio.SelectedItem), CInt(cmbNave.SelectedValue))

            FechaIngreso = CDate(Fila("real_fecha"))
            DiasTrabajados = (fechaFinalAnio - FechaIngreso).TotalDays
            AñosTrabajados = DiasTrabajados \ 365


            Meses = (DiasTrabajados - (365 * Fix(DiasTrabajados / 365)))
            Meses = Fix(Meses / 30.4)
            diasme = (DiasTrabajados Mod 365) Mod 30.4
            mesesTotal = Math.Round(Meses + (diasme / 30.4), 1)



            For Each salario As Entidades.CalcularAguinaldos In listaSalarios
                SalariosNov2(LimiteMatriz2, 1) = 0
                SalariosNov2(LimiteMatriz2, 1) = salario.PSalarioXmes
                LimiteMatriz2 += 1
            Next

            grdCalculoAguinaldo.Rows.Add(Fila("agui_colaboradorid"), grdCalculoAguinaldo.Rows.Count + 1, NombreColaborador.Trim(), CDate(Fila("real_fecha")).ToShortDateString(), AñosTrabajados, mesesTotal, Fila("agui_diasxpagar"), faltas, SalariosNov2(0, 1).ToString("N0"), SalariosNov2(1, 1).ToString("N0"), SalariosNov2(2, 1).ToString("N0"), SalariosNov2(3, 1).ToString("N0"), Math.Round(CDbl(Fila("agui_sueldodiario")), 0).ToString("N0"), CDbl(Fila("agui_totalentregar")).ToString("N0"), Fila("agui_meses"), Fila("agui_sueldodiario"))



            SumaAguinaldo += Fila("agui_totalentregar")

        Next

        Dim CountFilas As Integer = 0
        CountFilas = grdCalculoAguinaldo.Rows.Count

        grdCalculoAguinaldo.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", SumaAguinaldo, "")
        grdCalculoAguinaldo.Rows(CountFilas).DefaultCellStyle.BackColor = Color.YellowGreen
        grdCalculoAguinaldo.Rows(CountFilas).DefaultCellStyle.ForeColor = Color.Black


        lblcolaborador.Visible = True
        txtColaborador.Visible = True
        btnGuardar.Enabled = False
        btnReporte.Enabled = True



    End Sub


    Public Sub AgregarFilaAguinaldosGuardados(ByVal Aguinaldo As List(Of Entidades.CalcularAguinaldos))
        Dim anios As Int32 = 0
        Dim meses As Int32 = 0
        Dim dias As Int32 = 0
        Dim diasme As Int32 = 0
        Dim DiasTrabajados As Integer
        Dim faltas As Double = 0

        Dim anio_actual As Integer = Now.Year + 1
        Dim fechaInicioAnio, fechaFinalAnio As Date


        For Each Dato As Entidades.CalcularAguinaldos In Aguinaldo
            fechaInicioAnio = anio_actual.ToString + "-01-01"

            fechaFinalAnio = DateAdd(DateInterval.Day, -1, fechaInicioAnio)

            anios = 0
            meses = 0
            diasme = 0
            Dim FechaIngreso As Date = Dato.PColaboradorReal.PFecha
            DiasTrabajados = (fechaFinalAnio - FechaIngreso).TotalDays

            anios = DiasTrabajados \ 365
            'meses = (DiasTrabajados Mod 365) \ 30.4
            meses = (DiasTrabajados - (365 * Fix(DiasTrabajados / 365)))
            meses = Fix(meses / 30.4)
            diasme = (DiasTrabajados Mod 365) Mod 30.4
            Dim antiguedad As String = anios.ToString + " años " + meses.ToString + " meses "

            Dim objAguiBU As New Negocios.CalcularAguinaldoBU
            Dim listaSalarios As List(Of Entidades.CalcularAguinaldos)
            listaSalarios = objAguiBU.ListacolaboradoresSalarios(Dato.PColaborador.PColaboradorid, CInt(cmbAnio.SelectedItem), CInt(cmbNave.SelectedValue))
            faltas = objAguiBU.FaltasPeriodosAguinaldo(Dato.PColaborador.PColaboradorid, CInt(cmbAnio.SelectedItem), CInt(cmbNave.SelectedValue))
            ReDim SalariosNov(6, 2)
            limiteMatriz = 0
            Dim salarioDiario2 As Double = 0
            Dim diasDividir As Integer = 0
            For Each salario As Entidades.CalcularAguinaldos In listaSalarios

                SalariosNov(limiteMatriz, 1) = salario.PSalarioXmes
                limiteMatriz += 1
                salarioDiario2 += salario.PSalarioXmes
                diasDividir += 7


            Next

            Dim ColaboradorNombre As String = Dato.PColaborador.PNombre.ToUpper + " " + Dato.PColaborador.PApaterno.ToUpper + " " + Dato.PColaborador.PAmaterno.ToUpper
            Dim salarioDiario As Double = Dato.PnominaReal.PSalarioDiario
            Dim totalPagar As Double = Dato.PnominaReal.PTotalEntregar
            Dim totalDias As Double = Dato.PDiasxPagar
            Dim totalMeses As Double = Dato.PAguinaldoMeses
            totalMeses = Math.Round(totalMeses, 1)

            Dim mesesTotal As Double = Math.Round(meses + (diasme / 30.4), 1)
            'Dim mesesTotal As Double = Dato.PAguinaldoMeses

            grdCalculoAguinaldo.Rows.Add(Dato.PColaborador.PColaboradorid, grdCalculoAguinaldo.Rows.Count + 1, ColaboradorNombre, Dato.PColaboradorReal.PFecha.ToShortDateString, anios, mesesTotal, totalDias, faltas, SalariosNov(0, 1).ToString("N0"), SalariosNov(1, 1).ToString("N0"), SalariosNov(2, 1).ToString("N0"), SalariosNov(3, 1).ToString("N0"), salarioDiario.ToString("N0"), totalPagar.ToString("N0"), totalMeses)
        Next
        totalAguinaldos2 = 0
        Dim contadorfilas As Integer = 0
        For Each row As DataGridViewRow In grdCalculoAguinaldo.Rows
            totalAguinaldos2 += row.Cells("clmTotalEntregar").Value
            contadorfilas += 1
        Next
        grdCalculoAguinaldo.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", totalAguinaldos2)
        grdCalculoAguinaldo.Rows(contadorfilas).DefaultCellStyle.BackColor = Color.YellowGreen
        grdCalculoAguinaldo.Rows(contadorfilas).DefaultCellStyle.ForeColor = Color.Black

    End Sub

    Public Sub AgregarFilaAguinaldos(ByVal Aguinaldo As List(Of Entidades.CalcularAguinaldos))

        For Each Dato As Entidades.CalcularAguinaldos In Aguinaldo
            Dim ColaboradorNombre As String = Dato.PColaborador.PNombre.ToUpper + " " + Dato.PColaborador.PApaterno.ToUpper + " " + Dato.PColaborador.PAmaterno.ToUpper
            Dim salarioDiario As Double = Dato.PColaboradorReal.PCantidad / 7
            Dim FechaActual As Date = DateTime.Now().ToShortDateString()
            Dim totalPagar As Double = 0
            Dim totalDias As Double = 0
            Dim anios As Int32 = 0
            Dim meses As Int32 = 0
            Dim dias As Int32 = 0
            Dim diasme As Int32 = 0
            Dim DiasTrabajados As Integer
            Dim anio_actual As Integer = Now.Year + 1
            Dim fechaInicioAnio, fechaFinalAnio As Date
            Dim tipoSueldo As String
            tipoSueldo = Dato.PtipoSueldo

            fechaInicioAnio = Now.Year.ToString + "-01-01"

            fechaFinalAnio = Now.Year.ToString + "-12-31"

            'si el colaborador entro despues de la ultima semana del periodo  para el calculo del aguinaldo no se considera para el calculo
            If Dato.PColaboradorReal.PFecha > FechaFinalPeriodo Then
                Continue For
            End If


            anios = 0
            meses = 0
            diasme = 0
            Dim FechaIngreso As Date = Dato.PColaboradorReal.PFecha
            DiasTrabajados = (fechaFinalAnio - FechaIngreso).TotalDays

            anios = DiasTrabajados \ 365
            meses = (DiasTrabajados - (365 * Fix(DiasTrabajados / 365)))
            meses = Fix(meses / 30.4)
            diasme = (DiasTrabajados Mod 365) Mod 30.4
            Dim antiguedad As String = anios.ToString + " años " + meses.ToString + " meses "


            Dim objAguiBU As New Negocios.CalcularAguinaldoBU
            Dim listaSalarios As List(Of Entidades.CalcularAguinaldos)
            Dim faltas As Double = 0
            listaSalarios = objAguiBU.ListacolaboradoresSalarios(Dato.PColaborador.PColaboradorid, CInt(cmbAnio.SelectedItem), CInt(cmbNave.SelectedValue))
            faltas = objAguiBU.FaltasPeriodosAguinaldo(Dato.PColaborador.PColaboradorid, CInt(cmbAnio.SelectedItem), CInt(cmbNave.SelectedValue))
            ReDim SalariosNov(6, 2)
            limiteMatriz = 0
            Dim salarioDiario2 As Double = 0
            Dim diasDividir As Double = 0

            For Each salario As Entidades.CalcularAguinaldos In listaSalarios
                SalariosNov(limiteMatriz, 1) = salario.PSalarioXmes
                limiteMatriz += 1
                salarioDiario2 += salario.PSalarioXmes
                If salario.PSalarioXmes > 0 Then
                    diasDividir += 7
                End If
            Next

            If tipoSueldo = "DESTAJO" Then
                diasDividir = diasDividir - faltas
            End If


            If salarioDiario2 = 0 Then
                salarioDiario2 = 0
            Else
                salarioDiario2 = salarioDiario2 / diasDividir
            End If


            ' If totalPagar > 0 Then
            If anios >= 1 Then
                totalPagar = Math.Round(salarioDiario2 * 15, 2)
                Dim mesesTotal As Double = Math.Round(meses + (diasme / 30.4), 1)

                grdCalculoAguinaldo.Rows.Add(Dato.PColaborador.PColaboradorid, grdCalculoAguinaldo.Rows.Count + 1, ColaboradorNombre.ToUpper, Dato.PColaboradorReal.PFecha.ToShortDateString, anios, mesesTotal, CInt("15"), faltas, SalariosNov(0, 1).ToString("N0"), SalariosNov(1, 1).ToString("N0"), SalariosNov(2, 1).ToString("N0"), SalariosNov(3, 1).ToString("N0"), Math.Round(salarioDiario2, 0), totalPagar.ToString("N0"), "12", salarioDiario2.ToString("F2"))

                'If totalPagar > 0 Then
                '    grdCalculoAguinaldo.Rows.Add(Dato.PColaborador.PColaboradorid, grdCalculoAguinaldo.Rows.Count + 1, ColaboradorNombre.ToUpper, Dato.PColaboradorReal.PFecha.ToShortDateString, anios, mesesTotal, CInt("15"), faltas, SalariosNov(0, 1).ToString("N0"), SalariosNov(1, 1).ToString("N0"), SalariosNov(2, 1).ToString("N0"), SalariosNov(3, 1).ToString("N0"), Math.Round(salarioDiario2, 0), totalPagar.ToString("N0"), "12", salarioDiario2.ToString("F2"))
                'End If
            Else
                If anios < 1 Then
                    Dim mesesTotal As Double = Math.Round(meses + (diasme / 30.4), 1)
                    totalDias = Math.Round(1.25 * mesesTotal, 2)
                    totalPagar = Math.Round(salarioDiario2 * totalDias, 2)
                    grdCalculoAguinaldo.Rows.Add(Dato.PColaborador.PColaboradorid, grdCalculoAguinaldo.Rows.Count + 1, ColaboradorNombre.ToUpper, Dato.PColaboradorReal.PFecha.ToShortDateString, anios, mesesTotal, totalDias, faltas, SalariosNov(0, 1).ToString("N0"), SalariosNov(1, 1).ToString("N0"), SalariosNov(2, 1).ToString("N0"), SalariosNov(3, 1).ToString("N0"), Math.Round(salarioDiario2, 0), totalPagar.ToString("N0"), mesesTotal, salarioDiario2.ToString("F2"))

                    'If diasDividir > 1 Then
                    '    grdCalculoAguinaldo.Rows.Add(Dato.PColaborador.PColaboradorid, grdCalculoAguinaldo.Rows.Count + 1, ColaboradorNombre.ToUpper, Dato.PColaboradorReal.PFecha.ToShortDateString, anios, mesesTotal, totalDias, faltas, SalariosNov(0, 1).ToString("N0"), SalariosNov(1, 1).ToString("N0"), SalariosNov(2, 1).ToString("N0"), SalariosNov(3, 1).ToString("N0"), Math.Round(salarioDiario2, 0), totalPagar.ToString("N0"), mesesTotal, salarioDiario2.ToString("F2"))
                    'End If
                End If
            End If
        Next

        Dim contadorFilas As Integer = 0
        totalAguinaldos2 = 0
        For Each row As DataGridViewRow In grdCalculoAguinaldo.Rows
            totalAguinaldos2 += row.Cells("clmTotalEntregar").Value
            contadorFilas += 1
        Next
        grdCalculoAguinaldo.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", totalAguinaldos2, "")
        grdCalculoAguinaldo.Rows(contadorFilas).DefaultCellStyle.BackColor = Color.GreenYellow



    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        ''que el grid tenga algo
        Dim contadorFilas As Integer = 0
        For Each dato As DataGridViewRow In grdCalculoAguinaldo.Rows
            contadorFilas += 1
        Next

        If contadorFilas > 0 Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = "¿Estas seguro de querer guardar los aguinaldos? "

            If mensajeExito.ShowDialog = DialogResult.OK Then
                ' btnGuardar.Enabled = False
                btnBuscar.Enabled = False
                btnGuardar.Enabled = False
                btnReporte.Enabled = True
                guardar()
                grdCalculoAguinaldo.Rows.Clear()
            End If
        End If
    End Sub

    Public Sub guardar()
        Me.Cursor = Cursors.WaitCursor
        Dim objAguinaldoBU As New Negocios.CalcularAguinaldoBU
        Dim ObjColaborador As New Entidades.Colaborador
        Dim objNomina As New Entidades.CalcularNominaReal
        Dim objAguinaldo As New Entidades.CalcularAguinaldos
        Dim contadorTrue As Integer = 0

        For Each row As DataGridViewRow In grdCalculoAguinaldo.Rows
            If row.Cells("clmColaborador").Value <> "" Then

                ObjColaborador.PColaboradorid = row.Cells("clmColaboradorID").Value
                objNomina.PSalarioDiario = row.Cells("clmSalarioDiarioSinRedondeo").Value
                objNomina.PTotalEntregar = row.Cells("clmTotalEntregar").Value
                objAguinaldo.PDiasxPagar = row.Cells("clmDiasAPagar").Value
                objAguinaldo.PAguinaldoMeses = row.Cells("clmMesesLaborados").Value
                objAguinaldo.PAguinaldoAnio = cmbAnio.SelectedItem

                objAguinaldo.PColaborador = ObjColaborador
                objAguinaldo.PnominaReal = objNomina

                objAguinaldoBU.guardarAguinaldo(objAguinaldo, cmbNave.SelectedValue, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                contadorTrue = 1
            End If
        Next
        If contadorTrue = 1 Then
            Dim mensajeExito2 As New ExitoForm
            'mensajeExito2.MdiParent = Me.MdiParent
            mensajeExito2.mensaje = "Se han guardado los aguinaldos correctamente."
            mensajeExito2.Show()
            grdCalculoAguinaldo.Rows.Clear()

            txtColaborador.Text = ""
            cmbNave.SelectedIndex = 0
            cmbAnio.SelectedIndex = 0
        Else

        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 122
    End Sub

    Private Sub cmbAnio_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAnio.DropDownClosed
        btnGuardar.Enabled = False
        grdCalculoAguinaldo.Rows.Clear()
        Try


            Dim objBu As New Negocios.CalcularPrimaVacacionalBU
            Dim tabla As New DataTable
            tabla = objBu.fechasSueldos(cmbNave.SelectedValue, cmbAnio.Text)

            If tabla.Rows.Count = 4 Then
                fecha4 = " Del:" + CDate(tabla.Rows(0).Item("FechaInicial")).ToShortDateString + " Al:" + CDate(tabla.Rows(0).Item("FechaFinal")).ToShortDateString
                fecha3 = " Del:" + CDate(tabla.Rows(1).Item("FechaInicial")).ToShortDateString + " Al:" + CDate(tabla.Rows(1).Item("FechaFinal").ToString).ToShortDateString
                fecha2 = " Del:" + CDate(tabla.Rows(2).Item("FechaInicial")).ToShortDateString + " Al:" + CDate(tabla.Rows(2).Item("FechaFinal").ToString).ToShortDateString
                fecha1 = " Del:" + CDate(tabla.Rows(3).Item("FechaInicial")).ToShortDateString + " Al:" + CDate(tabla.Rows(3).Item("FechaFinal").ToString).ToShortDateString

                clmSemana1.HeaderText = fecha1.ToString
                clmSemana2.HeaderText = fecha2.ToString
                clmSemana3.HeaderText = fecha3.ToString
                clmSemana4.HeaderText = fecha4.ToString

                FechaFinalPeriodo = CDate(tabla.Rows(0).Item("FechaFinal")).ToShortDateString

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Try

            If grdCalculoAguinaldo.Rows.Count > 0 Then
                Me.Cursor = Cursors.WaitCursor
                Dim Colaborador = New DataTable("Colaboradores")

                'Dim Efectivo = New DataTable("Efectivo")
                Dim totalEntregar As Double

                With Colaborador
                    .Columns.Add("clmColaborador")
                    .Columns.Add("clmFechaIngreso")
                    .Columns.Add("clmAnios")
                    .Columns.Add("clmMeses")
                    .Columns.Add("clmDiasAPagar")
                    .Columns.Add("clmFaltas", System.Type.GetType("System.Double"))
                    .Columns.Add("clmSemana1")
                    .Columns.Add("clmSemana2")
                    .Columns.Add("clmSemana3")
                    .Columns.Add("clmSemana4")
                    .Columns.Add("clmSueldoDiario")
                    '.Columns.Add("clmVacaciones")
                    '.Columns.Add("clmPrimaVacacional")
                    .Columns.Add("clmTotalEntregar")


                End With


                totalEntregar = 0
                For Each fila As DataGridViewRow In grdCalculoAguinaldo.Rows

                    If fila.Cells("clmColaborador").Value <> "" Then
                        Colaborador.Rows.Add(
                            fila.Cells("clmColaborador").Value,
                            fila.Cells("clmFechaIngreso").Value,
                            fila.Cells("clmAntiguedad").Value,
                            Math.Round(fila.Cells("clmMeses").Value, 1),
                            fila.Cells("clmDiasAPagar").Value.ToString,
                            fila.Cells("clmFaltas").Value,
                            fila.Cells("clmSemana1").Value,
                            fila.Cells("clmSemana2").Value,
                            fila.Cells("clmSemana3").Value,
                            fila.Cells("clmSemana4").Value,
                            fila.Cells("clmSueldoDiario").Value,
                            fila.Cells("clmTotalEntregar").Value
                            )
                        totalEntregar += fila.Cells("clmTotalEntregar").Value
                    End If


                Next


                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("NOM_RPT_AGUI")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                Dim reporte As New StiReport
                Dim rutaLogo As String = ""

                Dim objNave As New Negocios.CalcularPrimaVacacionalBU
                Dim tablaLogo As New DataTable
                tablaLogo = objNave.logoNave(cmbNave.SelectedValue)
                If tablaLogo.Rows.Count > 0 Then
                    rutaLogo = tablaLogo.Rows(0).Item("RUTA")
                End If


                reporte.Load(archivo)
                reporte.Compile()
                reporte("rutaImagen") = rutaLogo
                reporte("UserName") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
                reporte("NombreUsuario") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString.ToUpper
                reporte("titulo") = "REPORTE DE AGUINALDOS " + cmbAnio.Text.ToString
                reporte("tituloDias") = "DIAS AGUI."
                reporte("NombreArchivo") = "ReporteListaAguinaldos.mrt"
                reporte("NaveNombre") = cmbNave.Text
                reporte("totalEntregar") = totalEntregar.ToString("N0")
                reporte("semana1") = fecha1
                reporte("semana2") = fecha2
                reporte("semana3") = fecha3
                reporte("semana4") = fecha4
                reporte.RegData(Colaborador)
                reporte.Show()
                Me.Cursor = Cursors.Default
            Else
                show_message("Advertencia", "No hay información para generar el reporte.")
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
        Me.Cursor = Cursors.Default


        ' ''que el grid tenga algo
        'Dim contadorFilas As Integer = 0
        'For Each dato As DataGridViewRow In grdCalculoAguinaldo.Rows
        '    contadorFilas += 1
        'Next

        'If contadorFilas > 0 Then



        '    Try

        '        If cmbNave.SelectedIndex > 0 Then

        '            Dim ds As New CalculoAguinaldosDS
        '            Dim ObjDS As New CalculoAguinaldosDS
        '            ds.Tables.Add("grdCalculoAguinaldo")


        '            ''Se agregan las columnas
        '            Dim col As System.Data.DataColumn
        '            For Each dgvCol As DataGridViewColumn In Me.grdCalculoAguinaldo.Columns
        '                col = New System.Data.DataColumn(dgvCol.Name)
        '                ds.Tables("grdCalculoAguinaldo").Columns.Add(col)
        '            Next

        '            ''SE agregan las filas
        '            Dim row As System.Data.DataRow
        '            Dim colcount As Integer = Me.grdCalculoAguinaldo.Columns.Count - 1

        '            For i As Integer = 0 To Me.grdCalculoAguinaldo.Rows.Count - 1
        '                row = ds.Tables("grdCalculoAguinaldo").Rows.Add
        '                For Each column As DataGridViewColumn In Me.grdCalculoAguinaldo.Columns
        '                    row.Item(column.Index) = Me.grdCalculoAguinaldo.Rows.Item(i).Cells(column.Index).Value
        '                Next
        '            Next



        '            ''Se indica el tipo de parametro
        '            ''En este caso de tipo numerico
        '            anio.ParameterValueType = ParameterValueKind.StringParameter
        '            ruta.ParameterValueType = ParameterValueKind.StringParameter
        '            UserName.ParameterValueType = ParameterValueKind.StringParameter
        '            NombreArchivo.ParameterValueType = ParameterValueKind.StringParameter
        '            Nave.ParameterValueType = ParameterValueKind.StringParameter
        '            TotalAguinaldos.ParameterValueType = ParameterValueKind.StringParameter

        '            ''Se indica el nombre del parametro
        '            anio.ParameterFieldName = "anio"
        '            ruta.ParameterFieldName = "ruta"
        '            UserName.ParameterFieldName = "UserName"
        '            NombreArchivo.ParameterFieldName = "NombreArchivo"
        '            Nave.ParameterFieldName = "Nave"
        '            TotalAguinaldos.ParameterFieldName = "TotalAguinaldos"


        '            ''Se indica el valor que va a tomar el parametro   
        '            myDiscreteValueanio.Value = cmbAnio.SelectedItem.ToString
        '            myDiscreteValueUserName.Value = Convert.ToString(Entidades.SesionUsuario.UsuarioSesion.PUserUsername)
        '            myDiscreteValueNombreArchivo.Value = Convert.ToString("ReporteAguinaldos.rpt")
        '            myDiscreteValueTotalAguinaldos.Value = Convert.ToString(totalAguinaldos2)


        '            ''Se indica el valor que va a tomar el parametro   
        '            If cmbNave.SelectedValue = 2 Then
        '                myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/YUYIN.JPG")
        '                myDiscreteValueNave.Value = Convert.ToString("YUYIN")

        '            ElseIf cmbNave.SelectedValue = 3 Then
        '                myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/JEANS.JPG")
        '                myDiscreteValueNave.Value = Convert.ToString("JEANS")

        '            ElseIf cmbNave.SelectedValue = 4 Then
        '                myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/MERANO.JPG")
        '                myDiscreteValueNave.Value = Convert.ToString("MERANO")

        '            ElseIf cmbNave.SelectedValue = 5 Then
        '                myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/JEANS2.JPG")
        '                myDiscreteValueNave.Value = Convert.ToString("JEANS2")

        '            ElseIf cmbNave.SelectedValue = 43 Then
        '                myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/GRUPOYUYIN.JPG")
        '                myDiscreteValueNave.Value = Convert.ToString("COMERCIALIZADORA")
        '            End If


        '            ''Se asigna el valor del parametro '@Colaborador  '@NaveID   '@PeriodoNominaID 

        '            anio.CurrentValues.Add(myDiscreteValueanio)
        '            UserName.CurrentValues.Add(myDiscreteValueUserName)
        '            NombreArchivo.CurrentValues.Add(myDiscreteValueNombreArchivo)
        '            Nave.CurrentValues.Add(myDiscreteValueNave)
        '            ruta.CurrentValues.Add(myDiscreteValueRuta)
        '            TotalAguinaldos.CurrentValues.Add(myDiscreteValueTotalAguinaldos)

        '            ''Se asigna el valor a la variable que se enlazsa al reporte


        '            Parametros.Add(anio)
        '            Parametros.Add(ruta)
        '            Parametros.Add(UserName)
        '            Parametros.Add(NombreArchivo)
        '            Parametros.Add(Nave)
        '            Parametros.Add(TotalAguinaldos)

        '            Dim Report As New ReporteListaAguinaldos
        '            Dim VisorReporte As New VisorReportesEnTablas

        '            Report.SetDataSource(ds.Tables("grdCalculoAguinaldo"))
        '            VisorReporte.ReporteViewer.ReportSource = Report
        '            VisorReporte.ReporteViewer.ParameterFieldInfo = Parametros
        '            VisorReporte.Show()






        '        End If
        '    Catch ex As Exception
        '    End Try

        'End If

        '' ''Se indica el tipo de parametro
        '' ''En este caso de tipo numerico
        ''IdNave.ParameterValueType = ParameterValueKind.NumberParameter
        ''AnioAguinaldo.ParameterValueType = ParameterValueKind.NumberParameter
        ''Colaborador.ParameterValueType = ParameterValueKind.StringParameter
        ''ruta.ParameterValueType = ParameterValueKind.StringParameter

        ''UserName.ParameterValueType = ParameterValueKind.StringParameter
        ''NombreArchivo.ParameterValueType = ParameterValueKind.StringParameter
        ''Nave.ParameterValueType = ParameterValueKind.StringParameter

        '' ''Se indica el nombre del parametro
        '' ''del procedimiento almacenado
        ''IdNave.ParameterFieldName = "@NaveID"
        ''AnioAguinaldo.ParameterFieldName = "@AnioAguinaldo"
        ''Colaborador.ParameterFieldName = "@Colaborador"
        ''ruta.ParameterFieldName = "@ruta"

        ''UserName.ParameterFieldName = "@UserName"
        ''NombreArchivo.ParameterFieldName = "@NombreArchivo"
        ''Nave.ParameterFieldName = "@Nave"

        '' ''Se indica el valor que va a tomar el parametro   
        ''myDiscreteValueIdNave.Value = Convert.ToInt32(cmbNave.SelectedValue)
        ''myDiscreteValueAnioAguinaldo.Value = Convert.ToInt32(cmbAnio.SelectedItem)
        ''myDiscreteValueColaborador.Value = Convert.ToString(txtColaborador.Text)


        ''myDiscreteValueUserName.Value = Convert.ToString(Entidades.SesionUsuario.UsuarioSesion.PUserUsername)
        ''myDiscreteValueNombreArchivo.Value = Convert.ToString("ReporteAguinaldos.rpt")


        ''If cmbNave.SelectedValue = 2 Then
        ''    myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/YUYIN.JPG")
        ''    myDiscreteValueNave.Value = Convert.ToString("YUYIN")

        ''ElseIf cmbNave.SelectedValue = 3 Then
        ''    myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/JEANS.JPG")
        ''    myDiscreteValueNave.Value = Convert.ToString("JEANS")

        ''ElseIf cmbNave.SelectedValue = 4 Then
        ''    myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/MERANO.JPG")
        ''    myDiscreteValueNave.Value = Convert.ToString("MERANO")

        ''ElseIf cmbNave.SelectedValue = 5 Then
        ''    myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/JEANS2.JPG")
        ''    myDiscreteValueNave.Value = Convert.ToString("JEANS2")

        ''ElseIf cmbNave.SelectedValue = 43 Then
        ''    myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/GRUPOYUYIN.JPG")
        ''    myDiscreteValueNave.Value = Convert.ToString("Comercializadora")

        ''End If

        '' ''Se asigna el valor del parametro '@Colaborador  '@NaveID   '@PeriodoNominaID 
        ''IdNave.CurrentValues.Add(myDiscreteValueIdNave)
        ''AnioAguinaldo.CurrentValues.Add(myDiscreteValueAnioAguinaldo)
        ''Colaborador.CurrentValues.Add(myDiscreteValueColaborador)
        ''ruta.CurrentValues.Add(myDiscreteValueRuta)

        ''UserName.CurrentValues.Add(myDiscreteValueUserName)
        ''NombreArchivo.CurrentValues.Add(myDiscreteValueNombreArchivo)
        ''Nave.CurrentValues.Add(myDiscreteValueNave)

        '' ''Se asigna el valor a la variable que se enlazsa al reporte
        ''Parametros.Add(IdNave)
        ''Parametros.Add(AnioAguinaldo)
        ''Parametros.Add(Colaborador)
        ''Parametros.Add(ruta)

        ''Parametros.Add(UserName)
        ''Parametros.Add(NombreArchivo)
        ''Parametros.Add(Nave)

        '' ''Se llama al reportView y se indica el valor del parametro
        ''Dim CrystalVisor As New VisorReportesEnTablas
        ''CrystalVisor.ReporteViewer.ParameterFieldInfo = Parametros

        '' ''Se declara un objeto de tipo rpt
        ''Dim reporte As New ReporteAguinaldos
        ''reporte.SetDatabaseLogon("sa", "poder335")

        '' ''Se asigna el reporte al crystal report viewer
        ''CrystalVisor.ReporteViewer.ReportSource = reporte
        ''CrystalVisor.ShowDialog()

    End Sub

    Public Function show_message(ByVal tipo As String, ByVal mensaje As String) As DialogResult
        Dim ResultadoDialogo As DialogResult

        If tipo.ToString.Equals("Advertencia") Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If



        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            ResultadoDialogo = mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            ResultadoDialogo = mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        Return ResultadoDialogo
    End Function

    Private Sub txtColaborador_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColaborador.KeyPress
        ''SOLO LETRAS
        Dim caracter As Char = e.KeyChar
        If (Char.IsLetter(caracter)) Or (caracter = ChrW(Keys.Back)) Or (Char.IsSeparator(caracter)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub



    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        grdCalculoAguinaldo.Rows.Clear()
        txtColaborador.Text = ""
        btnBuscar.Enabled = True
        cmbNave.SelectedIndex = 0
    End Sub

    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub


    Public Sub cmbNaveDrop()
        Dim ObjBU As New Nomina.Negocios.CalcularAguinaldoBU
        Dim listaAguinaldos As List(Of Entidades.CalcularAguinaldos)
        grdCalculoAguinaldo.Rows.Clear()
        lblAnioActual.Text = "False"
        lblRespaldoAnioActual.Text = "False"
        btnGuardar.Enabled = False
        cmbAnio.Items.Clear()

        listaAguinaldos = ObjBU.ListaAguinaldos(cmbNave.SelectedValue)
        AgregarAnios(listaAguinaldos)
    End Sub
End Class