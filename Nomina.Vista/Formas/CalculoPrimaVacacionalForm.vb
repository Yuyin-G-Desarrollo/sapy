Imports CrystalDecisions.Shared
Imports Stimulsoft.Report
Imports Tools

Public Class CalculoPrimaVacacionalForm

    Dim SalariosNov(,) As Double
    Dim limiteMatriz As Integer

    Dim fecha1 As String
    Dim fecha2 As String
    Dim fecha3 As String
    Dim fecha4 As String
    ''Esta varaiable asigna el parametro al reporte
    Dim Parametros As New ParameterFields()

    ''Esta variable indica el nombre del parametro que se encuentra en el procedimiento almacenado

    Dim anio As New ParameterField()
    Dim ruta As New ParameterField()
    Dim UserName As New ParameterField()
    Dim NombreArchivo As New ParameterField()
    Dim Nave As New ParameterField()
    Dim TotalVacaciones As New ParameterField()
    Dim FechaFinalPeriodo As Date


    ''Esta variable toma el valor dle parametro

    Dim myDiscreteValueanio As New ParameterDiscreteValue()
    Dim myDiscreteValueRuta As New ParameterDiscreteValue()
    Dim myDiscreteValueUserName As New ParameterDiscreteValue()
    Dim myDiscreteValueNombreArchivo As New ParameterDiscreteValue()
    Dim myDiscreteValueNave As New ParameterDiscreteValue()
    Dim myDiscreteValueTotalVacaciones As New ParameterDiscreteValue()

    Private Sub CalculoPrimaVacacionalForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Tools.FormatoCtrls.formato(Me)
        WindowState = FormWindowState.Maximized
        grdCalculoPrimaVacacional.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoPrimaVacacional.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoPrimaVacacional.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoPrimaVacacional.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoPrimaVacacional.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoPrimaVacacional.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoPrimaVacacional.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoPrimaVacacional.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoPrimaVacacional.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoPrimaVacacional.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCalculoPrimaVacacional.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        grdCalculoPrimaVacacional.Columns(5).DefaultCellStyle.Format = "##0.00"
        grdCalculoPrimaVacacional.Columns(7).DefaultCellStyle.Format = "##0.0"
        grdCalculoPrimaVacacional.Columns(13).DefaultCellStyle.Format = "###,##0"
        grdCalculoPrimaVacacional.Columns(14).DefaultCellStyle.Format = "###,##0"
        grdCalculoPrimaVacacional.Columns(15).DefaultCellStyle.Format = "###,##0"
        grdCalculoPrimaVacacional.Columns(16).DefaultCellStyle.Format = "###,##0"
        grdCalculoPrimaVacacional.Columns(17).DefaultCellStyle.Format = "###,##0"
        grdCalculoPrimaVacacional.Columns(18).DefaultCellStyle.Format = "###,##0"
        grdCalculoPrimaVacacional.Columns(19).DefaultCellStyle.Format = "###,##0"

        grdCalculoPrimaVacacional.Columns(8).ValueType = System.Type.GetType("System.String")
        grdCalculoPrimaVacacional.Columns(9).ValueType = System.Type.GetType("System.String")
        grdCalculoPrimaVacacional.Columns(10).ValueType = System.Type.GetType("System.String")
        grdCalculoPrimaVacacional.Columns(11).ValueType = System.Type.GetType("System.String")
        grdCalculoPrimaVacacional.Columns(12).ValueType = System.Type.GetType("System.String")
        grdCalculoPrimaVacacional.Columns(13).ValueType = System.Type.GetType("System.String")
        grdCalculoPrimaVacacional.Columns(14).ValueType = System.Type.GetType("System.String")
        grdCalculoPrimaVacacional.Columns(15).ValueType = System.Type.GetType("System.String")



        Try
            Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            If cmbNave.SelectedValue > 0 Then
                cmbNaveDrop()
            End If

            btnReporte.Enabled = False
            btnGuardar.Enabled = False
            lblAnioActual.Visible = False
            lblRespaldoAnioActual.Visible = False

            lblTotalVacaciones2.Visible = False
            lblTotalVacaciones.Visible = False

            lblcolaborador.Visible = False
            txtColaborador.Visible = False

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.DropDownClosed
        cmbNaveDrop()
    End Sub

    Public Sub AgregarAnios(ByVal PrimaVacacional As List(Of Entidades.CalcularPrimaVacacional))

        Dim anios As List(Of Integer) = PrimaVacacional.Select(Function(c) c.PPrimaVacacionalAnio).Distinct.ToList
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
            grdCalculoPrimaVacacional.Rows.Clear()

            Dim ObjBU As New Nomina.Negocios.CalcularPrimaVacacionalBU
            Dim listaPrima As List(Of Entidades.CalcularPrimaVacacional)
            btnReporte.Enabled = True

            grdCalculoPrimaVacacional.Columns(8).ValueType = System.Type.GetType("System.String")
            grdCalculoPrimaVacacional.Columns(9).ValueType = System.Type.GetType("System.String")
            grdCalculoPrimaVacacional.Columns(10).ValueType = System.Type.GetType("System.String")
            grdCalculoPrimaVacacional.Columns(11).ValueType = System.Type.GetType("System.String")
            grdCalculoPrimaVacacional.Columns(12).ValueType = System.Type.GetType("System.String")
            grdCalculoPrimaVacacional.Columns(13).ValueType = System.Type.GetType("System.String")
            grdCalculoPrimaVacacional.Columns(14).ValueType = System.Type.GetType("System.String")
            grdCalculoPrimaVacacional.Columns(15).ValueType = System.Type.GetType("System.String")

            If ObjBU.ExistePrimaVacacionalNave(cmbNave.SelectedValue, cmbAnio.SelectedItem) = True Then
                ConsultarInformacionGuardada()
                lblcolaborador.Visible = True
                txtColaborador.Visible = True

                btnGuardar.Enabled = False
                ImprimirCartasToolStripMenuItem.Visible = True
            Else
                btnGuardar.Enabled = True
                btnReporte.Enabled = True

                listaPrima = ObjBU.ListaColaboradoresPrimaVacacional(cmbNave.SelectedValue)
                AgregarFilaPRIMA(listaPrima)

                lblcolaborador.Visible = False
                txtColaborador.Visible = False
                ImprimirCartasToolStripMenuItem.Visible = False
            End If

            grdCalculoPrimaVacacional.Columns(8).ValueType = System.Type.GetType("System.String")
            grdCalculoPrimaVacacional.Columns(9).ValueType = System.Type.GetType("System.String")
            grdCalculoPrimaVacacional.Columns(10).ValueType = System.Type.GetType("System.String")
            grdCalculoPrimaVacacional.Columns(11).ValueType = System.Type.GetType("System.String")
            grdCalculoPrimaVacacional.Columns(12).ValueType = System.Type.GetType("System.String")
            grdCalculoPrimaVacacional.Columns(13).ValueType = System.Type.GetType("System.String")
            grdCalculoPrimaVacacional.Columns(14).ValueType = System.Type.GetType("System.String")
            grdCalculoPrimaVacacional.Columns(15).ValueType = System.Type.GetType("System.String")


            'If cmbAnio.SelectedItem < DateTime.Now.Year Or lblRespaldoAnioActual.Text = "True" Then

            '    ConsultarInformacionGuardada()

            '    'listaPrima = ObjBU.ListaPrimaGUARDADOS(cmbNave.SelectedValue, cmbAnio.SelectedItem, txtColaborador.Text)
            '    'AgregarFilaPrimaVacacionalGuardados(listaPrima)

            '    'lblcolaborador.Visible = True
            '    'txtColaborador.Visible = True

            '    'btnGuardar.Enabled = False
            'Else
            '    btnGuardar.Enabled = True

            '    listaPrima = ObjBU.ListaColaboradoresPrimaVacacional(cmbNave.SelectedValue)
            '    AgregarFilaPRIMA(listaPrima)

            '    lblcolaborador.Visible = False
            '    txtColaborador.Visible = False

            'End If
            If cmbNave.SelectedValue = 61 Then
                lblsueldos.Text = "Sueldos brutos considerados de las semanas 7,8,9 y 10"
            Else
                lblsueldos.Text = "Sueldos brutos considerados de las semanas 46,47,48 y 49"
            End If
            Me.Cursor = Cursors.Default
        Else
            Dim mensajeExito2 As New AdvertenciaForm
            'mensajeExito2.MdiParent = Me.MdiParent
            mensajeExito2.mensaje = "Se debe seleccionar la nave y el año."
            mensajeExito2.Show()
            btnGuardar.Enabled = False
        End If

    End Sub


    Public Sub ConsultarInformacionGuardada()
        Dim ObjBU As New Nomina.Negocios.CalcularPrimaVacacionalBU
        Dim DtInformacionVacaciones As DataTable
        Dim objAguiBU As New Negocios.CalcularAguinaldoBU
        Dim listaSalarios As List(Of Entidades.CalcularAguinaldos)
        Dim SalariosNov2(,) As Double
        Dim limiteMatriz2 As Integer = 0
        Dim faltas As Double = 0
        Dim AñosTrabajando As Integer = 0
        Dim DiasTrabajados As Integer
        Dim NombreCompleto As String = String.Empty
        Dim anio_actual As Integer = Now.Year + 1
        Dim fechaFinalAnio As Date
        Dim FechaIngreso As Date
        Dim Total As Double = 0
        Dim NumeroFilas As Integer = 0
        Dim meses As Int32 = 0
        Dim diasme As Int32 = 0
        Dim mesesTotales As Double = 0
        Dim añoslaborando As Integer = 0
        Dim tablaFechaSemanaSanta As DataTable
        Dim fechaSemanaSanta As Date

        ReDim SalariosNov2(6, 2)
        limiteMatriz2 = 0

        'ticket 15367
        If cmbNave.SelectedValue = 61 Then
            fechaFinalAnio = (cmbAnio.SelectedItem).ToString + "-03-31"
        Else
            fechaFinalAnio = cmbAnio.SelectedItem.ToString + "-12-31"
        End If


        'fechaFinalAnio = cmbAnio.SelectedItem.ToString + "-12-31"

        DtInformacionVacaciones = ObjBU.ListaPrimaGUARDADOS2(cmbNave.SelectedValue, cmbAnio.SelectedItem, txtColaborador.Text)

        lblcolaborador.Visible = True
        txtColaborador.Visible = True
        btnGuardar.Enabled = False
        btnReporte.Enabled = True




        For Each Fila As DataRow In DtInformacionVacaciones.Rows
            limiteMatriz2 = 0
            NombreCompleto = String.Empty
            Total += Fila("prim_totalentregar")

            If IsDBNull(Fila("codr_nombre")) = False Or IsNothing(Fila("codr_nombre")) = False Then
                NombreCompleto = Fila("codr_nombre")
            End If

            If IsDBNull(Fila("codr_apellidopaterno")) = False Or IsNothing(Fila("codr_apellidopaterno")) = False Then
                NombreCompleto = NombreCompleto + " " + Fila("codr_apellidopaterno")
            End If

            If IsDBNull(Fila("codr_apellidomaterno")) = False Or IsNothing(Fila("codr_apellidomaterno")) = False Then
                NombreCompleto = NombreCompleto + " " + Fila("codr_apellidomaterno")
            End If



            meses = 0
            diasme = 0

            If cmbPeriodo.Text = "SEMANA SANTA" And CInt(cmbAnio.Text) >= 2023 Then
                tablaFechaSemanaSanta = ObjBU.obtenerFechaInicioSemanaSanta(cmbNave.SelectedValue, cmbAnio.Text)

                If tablaFechaSemanaSanta.Rows.Count > 0 Then
                    fechaSemanaSanta = tablaFechaSemanaSanta(0)("fechaInicioSemSanta")
                End If
            End If
            If cmbPeriodo.Text = "SEMANA SANTA" And CInt(cmbAnio.Text) >= 2023 Then
                DiasTrabajados = (fechaSemanaSanta - FechaIngreso).TotalDays
            Else
                DiasTrabajados = (fechaFinalAnio - FechaIngreso).TotalDays
            End If



            FechaIngreso = CDate(Fila("real_fecha"))
            If cmbPeriodo.Text = "SEMANA SANTA" Then
                DiasTrabajados = (fechaSemanaSanta - FechaIngreso).TotalDays
            Else
                DiasTrabajados = (fechaFinalAnio - FechaIngreso).TotalDays
            End If
            AñosTrabajando = DiasTrabajados \ 365

            meses = (DiasTrabajados - (365 * Fix(DiasTrabajados / 365)))
            meses = Fix(meses / 30.4)
            diasme = (DiasTrabajados Mod 365) Mod 30.4


            mesesTotales = Math.Round(meses + (diasme / 30.4), 2)

            If cmbPeriodo.Text = "SEMANA SANTA" And CInt(cmbAnio.Text) >= 2023 Then
                listaSalarios = objAguiBU.ListacolaboradoresSalariosVacaciones(Fila("prim_colaboradorid"), CInt(cmbAnio.SelectedItem), CInt(cmbNave.SelectedValue))
            Else
                listaSalarios = objAguiBU.ListacolaboradoresSalarios(Fila("prim_colaboradorid"), CInt(cmbAnio.SelectedItem), CInt(cmbNave.SelectedValue))
            End If


            For Each salario As Entidades.CalcularAguinaldos In listaSalarios
                SalariosNov2(limiteMatriz2, 1) = 0
                SalariosNov2(limiteMatriz2, 1) = salario.PSalarioXmes
                limiteMatriz2 += 1
            Next

            If cmbPeriodo.Text = "SEMANA SANTA" And CInt(cmbAnio.Text) >= 2023 Then
                faltas = objAguiBU.FaltasPeriodosVacaciones(Fila("prim_colaboradorid"), CInt(cmbAnio.SelectedItem), CInt(cmbNave.SelectedValue))
            Else
                faltas = objAguiBU.FaltasPeriodosAguinaldo2(Fila("prim_colaboradorid"), CInt(cmbAnio.SelectedItem), CInt(cmbNave.SelectedValue))
            End If

            Dim ISR As Double = 0.0
            Dim pagoNeto As Double = 0.0

            ISR = ObjBU.obtenerInfoFiscalVacaciones(CInt(cmbAnio.Text), Fila("prim_colaboradorid"))
            pagoNeto = Math.Round((CDbl(Fila("prim_totalentregar")) - ISR), 0)
            grdCalculoPrimaVacacional.Rows.Add(Fila("prim_colaboradorid"), grdCalculoPrimaVacacional.Rows.Count + 1, NombreCompleto, CDate(Fila("real_fecha")).ToShortDateString, AñosTrabajando, mesesTotales, Fila("prim_diasxpagar"), faltas, SalariosNov2(0, 1).ToString("N0"), SalariosNov2(1, 1).ToString("N0"), SalariosNov2(2, 1).ToString("N0"), SalariosNov2(3, 1).ToString("N0"), Math.Round(CDbl(Fila("prim_sueldodiario")), 0).ToString("N0"), CDbl(Fila("prim_subtotal")).ToString("N0"), CDbl(Fila("prim_primavacacional")).ToString("N0"), CDbl(Fila("prim_totalentregar")).ToString("N0"), Fila("prim_meses").ToString, "0", ISR.ToString("N0"), pagoNeto.ToString("N0"))

        Next

        NumeroFilas = grdCalculoPrimaVacacional.Rows.Count

        grdCalculoPrimaVacacional.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", Total, "", "")
        grdCalculoPrimaVacacional.Rows(NumeroFilas).DefaultCellStyle.BackColor = Color.GreenYellow
        lblTotalVacaciones2.Text = Total.ToString("N0")

        'grdCalculoPrimaVacacional.Rows.Add(Dato.PColaborador.PColaboradorid, grdCalculoPrimaVacacional.Rows.Count + 1, ColaboradorNombre, Dato.PColaboradorReal.PFecha.ToShortDateString,
        '                                                anios, Math.Round(mesesTotal, 1), diasVacaciones, faltas, SalariosNov(0, 1).ToString("N0"), SalariosNov(1, 1).ToString("N0"),
        '                                                SalariosNov(2, 1).ToString("N0"), SalariosNov(3, 1).ToString("N0"), salarioDiario2.ToString("N0"), subtotal.ToString("N0"),
        '                                                PrimaVacacional.ToString("N0"), totalPagar.ToString("N0"), mesesTotal)







    End Sub

    Public Sub AgregarFilaPrimaVacacionalGuardados(ByVal Prima As List(Of Entidades.CalcularPrimaVacacional))

        For Each Dato As Entidades.CalcularPrimaVacacional In Prima
            Dim ColaboradorNombre As String = Dato.PColaborador.PNombre.ToUpper + " " + Dato.PColaborador.PApaterno.ToUpper + " " + Dato.PColaborador.PAmaterno.ToUpper

            Dim anios As Int32 = 0
            Dim meses As Int32 = 0
            Dim dias As Int32 = 0
            Dim diasme As Int32 = 0
            Dim DiasTrabajados As Integer

            Dim anio_actual As Integer = Now.Year + 1
            Dim fechaInicioAnio, fechaFinalAnio As Date

            fechaInicioAnio = anio_actual.ToString + "-01-01"

            fechaFinalAnio = DateAdd(DateInterval.Day, -1, fechaInicioAnio)

            anios = 0
            meses = 0
            diasme = 0
            Dim FechaIngreso As Date = Dato.PAntiguedad
            DiasTrabajados = (fechaFinalAnio - FechaIngreso).TotalDays

            anios = DiasTrabajados \ 365
            meses = (DiasTrabajados Mod 365) \ 30.4
            meses = Fix(meses / 30.4)
            diasme = (DiasTrabajados Mod 365) Mod 30.4


            Dim objAguiBU As New Negocios.CalcularAguinaldoBU
            Dim listaSalarios As List(Of Entidades.CalcularAguinaldos)
            listaSalarios = objAguiBU.ListacolaboradoresSalarios(Dato.PColaborador.PColaboradorid, CInt(cmbAnio.SelectedItem), CInt(cmbNave.SelectedValue))
            Dim faltas As Double = 0
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

            Dim Antiguedad As String = anios.ToString + " años " + meses.ToString + " meses " + diasme.ToString + " dias "
            '            Dim mesesTotal As Double = Math.Round(meses + (diasme / 30.4), 2)
            Dim mesesTotal As Double = Dato.PPrimaVacacionalMeses
            Dim fechaI As Date = Dato.PAntiguedad.ToShortDateString

            grdCalculoPrimaVacacional.Rows.Add(Dato.PColaborador.PColaboradorid, grdCalculoPrimaVacacional.Rows.Count + 1, ColaboradorNombre, FechaIngreso.ToShortDateString, anios, mesesTotal, Dato.PDiasxPagar, faltas, SalariosNov(0, 1).ToString("N0"), SalariosNov(1, 1).ToString("N0"), SalariosNov(2, 1).ToString("N0"), SalariosNov(3, 1).ToString("N0"), Dato.PSueldoDiario.ToString("N0"), Dato.PPrimaSubtotal.ToString("N0"), Dato.PPrimaPrimaVacacional.ToString("N0"), Dato.PPrimaTotalEntregar.ToString("N0"), Dato.PPrimaVacacionalMeses)
        Next

        Dim totalVacaciones As Double = 0
        Dim contadorFilas As Integer = 0
        For Each row As DataGridViewRow In grdCalculoPrimaVacacional.Rows
            totalVacaciones += row.Cells("clmTotalEntregar").Value
            contadorFilas += 1
        Next
        grdCalculoPrimaVacacional.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", totalVacaciones)
        grdCalculoPrimaVacacional.Rows(contadorFilas).DefaultCellStyle.BackColor = Color.GreenYellow
        lblTotalVacaciones2.Text = totalVacaciones.ToString("N0")

    End Sub

    Public Sub AgregarFilaPRIMA(ByVal Prima As List(Of Entidades.CalcularPrimaVacacional))
        Dim dtConfiguracionPorcentajeVacaciones As New DataTable
        Dim objAguiBU As New Negocios.CalcularAguinaldoBU
        Dim objVacaBU As New Negocios.CalcularPrimaVacacionalBU
        Dim PorcentajeVacaciones As Double
        Dim tablaFechaSemanaSanta As DataTable
        Dim fechaSemanaSanta As Date


        dtConfiguracionPorcentajeVacaciones = objAguiBU.RevisarConfiguracion(cmbNave.SelectedValue)
        If dtConfiguracionPorcentajeVacaciones.Rows.Count > 0 Then
            PorcentajeVacaciones = dtConfiguracionPorcentajeVacaciones.Rows(0).Item("PorcentajeVacaciones")
        End If

        If cmbPeriodo.Text = "SEMANA SANTA" Then
            tablaFechaSemanaSanta = objVacaBU.obtenerFechaInicioSemanaSanta(cmbNave.SelectedValue, cmbAnio.Text)

            If tablaFechaSemanaSanta.Rows.Count > 0 Then
                fechaSemanaSanta = tablaFechaSemanaSanta(0)("fechaInicioSemSanta")
            End If
        End If


        For Each Dato As Entidades.CalcularPrimaVacacional In Prima
            Dim ColaboradorNombre As String = Dato.PColaborador.PNombre.ToUpper + " " + Dato.PColaborador.PApaterno.ToUpper + " " + Dato.PColaborador.PAmaterno.ToUpper
            Dim salarioDiario As Double = Dato.PColaboradorReal.PCantidad / 7

            Dim totalDias As Double = 0
            Dim anios As Int32 = 0
            Dim meses As Int32 = 0
            Dim mesesSEMANASanta As Double = 0
            Dim dias As Int32 = 0
            Dim diasme As Int32 = 0
            Dim DiasTrabajados As Integer = 0
            Dim faltas As Double = 0
            Dim anio_actual As Integer = Now.Year + 1
            Dim fechaInicioAnio, fechaFinalAnio As Date


            'If cmbNave.SelectedValue = 61 Then
            '    If Dato.PColaboradorReal.PFecha <= "01-04-" + (anio_actual - 2).ToString Then  '2020" Then
            '        fechaInicioAnio = (anio_actual - 2).ToString + "-04-01"
            '        fechaFinalAnio = (anio_actual - 1).ToString + "-03-31" 'DateAdd(DateInterval.Day, -1,  fechaInicioAnio)
            '    Else
            '        fechaInicioAnio = Dato.PColaboradorReal.PFecha 'anio_actual.ToString + "-01-01"
            '        fechaFinalAnio = (anio_actual - 1).ToString + "-03-31" 'DateAdd(DateInterval.Day, -1, fechaInicioAnio)
            '    End If

            'Else
            fechaInicioAnio = anio_actual.ToString + "-01-01"

            fechaFinalAnio = DateAdd(DateInterval.Day, -1, fechaInicioAnio)

            'End If

            If Dato.PColaboradorReal.PFecha > FechaFinalPeriodo Then
                Continue For
            End If

            anios = 0
            meses = 0
            diasme = 0
            Dim FechaIngreso As Date = Dato.PColaboradorReal.PFecha
            If cmbPeriodo.Text = "SEMANA SANTA" Then
                DiasTrabajados = (fechaSemanaSanta - FechaIngreso).TotalDays
            Else
                DiasTrabajados = (fechaFinalAnio - FechaIngreso).TotalDays
            End If



            anios = DiasTrabajados \ 365
            meses = (DiasTrabajados - (365 * Fix(DiasTrabajados / 365)))
            mesesSEMANASanta = Math.Round((meses / 30.4), 1)
            meses = Fix(meses / 30.4)
            diasme = (DiasTrabajados Mod 365) Mod 30.4

            Dim diasVacaciones As Double = 0
            Dim listaDiasVacaciones As List(Of Entidades.CalcularPrimaVacacional)
            Dim objPrimaBU As New Negocios.CalcularPrimaVacacionalBU

            ''OBTENER LOS DIAS DE VACACIONES POR AÑOS
            Dim mesesTotal As Double = Math.Round(meses + (diasme / 30.4), 2)
            Dim mesesround = Math.Round(mesesTotal)
            Dim mesesFloor = Math.Floor(mesesTotal)
            listaDiasVacaciones = objPrimaBU.ListaDiasvacacionesAniosMeses(anios, Math.Floor(mesesTotal))
            Dim ObjDias As List(Of Double) = listaDiasVacaciones.Select(Function(c) c.PPrimaVacacionalDiasXAños).Distinct.ToList
            For Each diasVac As Double In ObjDias
                If cmbPeriodo.Text = "SEMANA SANTA" And cmbNave.SelectedValue <> 61 Then
                    If (mesesFloor >= 6 Or anios > 0) Then
                        diasVacaciones = 6
                    Else
                        diasVacaciones = mesesFloor
                    End If
                Else
                    diasVacaciones = diasVac
                End If

            Next
            ''OBTENER LOS DIAS DE VACACIONES POR AÑOS TERMINA

            Dim subtotal As Double = 0
            Dim PrimaVacacional As Double = 0
            Dim totalPagar As Double = 0
            Dim diasPorMes As Double = 0
            Dim Antiguedad As String = anios.ToString + " años " + meses.ToString + " meses " + diasme.ToString + " dias "



            Dim listaSalarios As List(Of Entidades.CalcularAguinaldos)
            listaSalarios = objAguiBU.ListacolaboradoresSalariosVacaciones(Dato.PColaborador.PColaboradorid, CInt(cmbAnio.SelectedItem), CInt(cmbNave.SelectedValue)) 'Ticket 15367
            If cmbPeriodo.Text = "SEMANA SANTA" Then
                faltas = objAguiBU.FaltasPeriodosVacaciones(Dato.PColaborador.PColaboradorid, CInt(cmbAnio.SelectedItem), CInt(cmbNave.SelectedValue))
            Else
                faltas = objAguiBU.FaltasPeriodosAguinaldo2(Dato.PColaborador.PColaboradorid, CInt(cmbAnio.SelectedItem), CInt(cmbNave.SelectedValue))
            End If


            ReDim SalariosNov(6, 2)
            limiteMatriz = 0
            Dim salarioDiario2 As Double = 0
            Dim diasDividir As Double = 0
            Dim primersalario As Integer = 0
            Dim vueltas As Integer = 0
            For Each salario As Entidades.CalcularAguinaldos In listaSalarios

                SalariosNov(limiteMatriz, 1) = salario.PSalarioXmes
                limiteMatriz += 1
                salarioDiario2 += salario.PSalarioXmes
                If salario.PSalarioXmes > 0 Then
                    diasDividir += 7
                End If

                vueltas += 1
                If (vueltas = 1) Then
                    primersalario = 1
                End If
            Next

            If diasDividir = 0 Then
                diasDividir = 1
            End If

            If Dato.PTipoSueldo = "DESTAJO" Then
                diasDividir = diasDividir - faltas
                If primersalario = 1 Then
                    diasDividir = 28 - faltas
                Else
                    diasDividir = diasDividir - faltas
                End If
            End If

            If diasDividir = 0 Then
                salarioDiario2 = 0
            Else
                salarioDiario2 = salarioDiario2 / diasDividir
            End If

            Dim ISR As Double = 0.0
            Dim pagoNeto As Double = 0.0

            ISR = objPrimaBU.obtenerInfoFiscalVacaciones(CInt(cmbAnio.Text), Dato.PColaborador.PColaboradorid)


            If anios >= 1 Then

                If PorcentajeVacaciones > 0 Then
                    subtotal = (diasVacaciones * salarioDiario2) * PorcentajeVacaciones
                Else
                    subtotal = diasVacaciones * salarioDiario2
                End If


                PrimaVacacional = subtotal * 0.25
                totalPagar = subtotal + PrimaVacacional
                mesesTotal = Math.Round(meses + (diasme / 30.4), 2)
                pagoNeto = Math.Round(totalPagar - ISR, 0)
                Dim fechaI As Date = Dato.PColaboradorReal.PFecha.ToShortDateString
                If anios >= 14 Then
                    grdCalculoPrimaVacacional.Rows.Add(Dato.PColaborador.PColaboradorid, grdCalculoPrimaVacacional.Rows.Count + 1, ColaboradorNombre, Dato.PColaboradorReal.PFecha.ToShortDateString,
                                                   anios, Math.Round(mesesTotal, 1), diasVacaciones, faltas, SalariosNov(0, 1).ToString("N0"), SalariosNov(1, 1).ToString("N0"),
                                                   SalariosNov(2, 1).ToString("N0"), SalariosNov(3, 1).ToString("N0"), Math.Round(CDbl(salarioDiario2), 0), subtotal.ToString("N0"),
                                                   PrimaVacacional.ToString("N0"), totalPagar.ToString("N0"), "12", salarioDiario2.ToString("F2"), ISR.ToString("N0"), pagoNeto.ToString("N0"))
                Else
                    grdCalculoPrimaVacacional.Rows.Add(Dato.PColaborador.PColaboradorid, grdCalculoPrimaVacacional.Rows.Count + 1, ColaboradorNombre, Dato.PColaboradorReal.PFecha.ToShortDateString,
                                                   anios, mesesTotal, diasVacaciones, faltas, SalariosNov(0, 1).ToString("N0"), SalariosNov(1, 1).ToString("N0"),
                                                   SalariosNov(2, 1).ToString("N0"), SalariosNov(3, 1).ToString("N0"), Math.Round(CDbl(salarioDiario2), 0), subtotal.ToString("N0"),
                                                   PrimaVacacional.ToString("N0"), totalPagar.ToString("N0"), "12", salarioDiario2.ToString("F2"), ISR.ToString("N0"), pagoNeto.ToString("N0"))
                End If

                'If totalPagar > 0 Then
                '    If anios >= 14 Then
                '        grdCalculoPrimaVacacional.Rows.Add(Dato.PColaborador.PColaboradorid, grdCalculoPrimaVacacional.Rows.Count + 1, ColaboradorNombre, Dato.PColaboradorReal.PFecha.ToShortDateString,
                '                                           anios, Math.Round(mesesTotal, 1), diasVacaciones, faltas, SalariosNov(0, 1).ToString("N0"), SalariosNov(1, 1).ToString("N0"),
                '                                           SalariosNov(2, 1).ToString("N0"), SalariosNov(3, 1).ToString("N0"), Math.Round(CDbl(salarioDiario2), 0), subtotal.ToString("N0"),
                '                                           PrimaVacacional.ToString("N0"), totalPagar.ToString("N0"), "12", salarioDiario2.ToString("F2"))
                '    Else
                '        grdCalculoPrimaVacacional.Rows.Add(Dato.PColaborador.PColaboradorid, grdCalculoPrimaVacacional.Rows.Count + 1, ColaboradorNombre, Dato.PColaboradorReal.PFecha.ToShortDateString,
                '                                           anios, Math.Round(mesesTotal, 1), diasVacaciones, faltas, SalariosNov(0, 1).ToString("N0"), SalariosNov(1, 1).ToString("N0"),
                '                                           SalariosNov(2, 1).ToString("N0"), SalariosNov(3, 1).ToString("N0"), Math.Round(CDbl(salarioDiario2), 0), subtotal.ToString("N0"),
                '                                           PrimaVacacional.ToString("N0"), totalPagar.ToString("N0"), "12", salarioDiario2.ToString("F2"))
                '    End If
                'End If

            Else
                If anios < 1 Then
                    'mesesTotal = Math.Round(meses + (diasme / 30.4), 2)
                    Dim fechaI As Date = Dato.PColaboradorReal.PFecha.ToShortDateString

                    If Month(fechaI) < 4 And PorcentajeVacaciones > 0 Then
                        subtotal = (diasVacaciones * salarioDiario2) * PorcentajeVacaciones
                    Else
                        subtotal = diasVacaciones * salarioDiario2
                    End If

                    Dim totalDiasVac As Double = 0
                    diasPorMes = 6 / 12
                    'totalDiasVac = diasPorMes * Math.Floor(mesesTotal)
                    'diasVacaciones += totalDiasVac

                    PrimaVacacional = subtotal * 0.25
                    totalPagar = subtotal + PrimaVacacional
                    pagoNeto = Math.Round(totalPagar - ISR, 0)
                    grdCalculoPrimaVacacional.Rows.Add(Dato.PColaborador.PColaboradorid, grdCalculoPrimaVacacional.Rows.Count + 1, ColaboradorNombre, Dato.PColaboradorReal.PFecha.ToShortDateString, anios, mesesTotal, diasVacaciones, faltas, SalariosNov(0, 1).ToString("N0"), SalariosNov(1, 1).ToString("N0"), SalariosNov(2, 1).ToString("N0"), SalariosNov(3, 1).ToString("N0"), salarioDiario2.ToString("N0"), subtotal.ToString("N0"), PrimaVacacional.ToString("N0"), totalPagar.ToString("N0"), mesesTotal, salarioDiario2.ToString("F2"), ISR.ToString("N0"), pagoNeto.ToString("N0"))

                    'If diasDividir > 1 Then
                    '    grdCalculoPrimaVacacional.Rows.Add(Dato.PColaborador.PColaboradorid, grdCalculoPrimaVacacional.Rows.Count + 1, ColaboradorNombre, Dato.PColaboradorReal.PFecha.ToShortDateString, anios, Math.Round(mesesTotal, 1), diasVacaciones, faltas, SalariosNov(0, 1).ToString("N0"), SalariosNov(1, 1).ToString("N0"), SalariosNov(2, 1).ToString("N0"), SalariosNov(3, 1).ToString("N0"), salarioDiario2.ToString("N0"), subtotal.ToString("N0"), PrimaVacacional.ToString("N0"), totalPagar.ToString("N0"), Math.Round(mesesTotal, 1), salarioDiario2.ToString("F2"))
                    'End If
                End If
            End If

        Next
        Dim totalVacaciones As Double = 0
        Dim contadorFilas As Integer = 0
        For Each row As DataGridViewRow In grdCalculoPrimaVacacional.Rows
            totalVacaciones += row.Cells("clmTotalEntregar").Value
            contadorFilas += 1
        Next
        grdCalculoPrimaVacacional.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", totalVacaciones)
        grdCalculoPrimaVacacional.Rows(contadorFilas).DefaultCellStyle.BackColor = Color.GreenYellow
        lblTotalVacaciones2.Text = totalVacaciones.ToString("N0")


    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 122

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim contadorFilas As Integer = 0
        For Each row As DataGridViewRow In grdCalculoPrimaVacacional.Rows
            contadorFilas += 1
        Next

        If contadorFilas > 0 Then
            ''Estas seguro??
            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = "¿Estas seguro que quiere guardar los registros ahora?"

            If mensajeExito.ShowDialog = DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                btnReporte.Enabled = True
                guardar()
                Me.Cursor = Cursors.Default
            End If

        End If

    End Sub

    Public Sub guardar()
        Dim objPrimaVacacional As New Entidades.CalcularPrimaVacacional
        Dim objColaborador As New Entidades.Colaborador
        Dim objBU As New Negocios.CalcularPrimaVacacionalBU
        Dim contadorTrue As Integer = 0

        For Each row As DataGridViewRow In grdCalculoPrimaVacacional.Rows
            If row.Cells("clmColaboradorID").Value.ToString <> "" Then
                objColaborador.PColaboradorid = row.Cells("clmColaboradorID").Value

                objPrimaVacacional.PPrimaVacacionalAnio = cmbAnio.SelectedItem
                objPrimaVacacional.PPrimaVacacionalMeses = row.Cells("clmMesesTotal").Value
                'objPrimaVacacional.PSueldoDiario = row.Cells("clmSueldoDiario").Value
                objPrimaVacacional.PSueldoDiario = row.Cells("clmSalarioDiarioSinRedondeo").Value
                objPrimaVacacional.PDiasxPagar = row.Cells("clmDiasAPagar").Value
                objPrimaVacacional.PPrimaSubtotal = row.Cells("clmSubTotal").Value
                objPrimaVacacional.PPrimaPrimaVacacional = row.Cells("clmPrimaVacacional").Value
                objPrimaVacacional.PPrimaTotalEntregar = row.Cells("clmTotalEntregar").Value
                objPrimaVacacional.PPrimaUsuarioCreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                objPrimaVacacional.PColaborador = objColaborador
                objPrimaVacacional.PPeriodoVacaciones = cmbPeriodo.Text
                objBU.guardarPrimaVacacional(objPrimaVacacional, cmbNave.SelectedValue)
                contadorTrue += 1
            End If
        Next
        If contadorTrue >= 0 Then
            Dim mensajeExito2 As New ExitoForm
            'mensajeExito2.MdiParent = Me.MdiParent
            mensajeExito2.mensaje = "Los registros fueron guardados correctamente."
            mensajeExito2.Show()
            grdCalculoPrimaVacacional.Rows.Clear()
            txtColaborador.Text = ""
            cmbNave.SelectedIndex = 0
            cmbAnio.SelectedIndex = 0
        Else

        End If
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click

        menuImprimir.Show(btnReporte, 0, btnReporte.Height)
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
        grdCalculoPrimaVacacional.Rows.Clear()
        txtColaborador.Text = ""
        cmbNave.SelectedIndex = 0

    End Sub


    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Public Sub cmbNaveDrop()
        Dim ObjBU As New Nomina.Negocios.CalcularPrimaVacacionalBU
        Dim listaPrimaVacacional As List(Of Entidades.CalcularPrimaVacacional)
        grdCalculoPrimaVacacional.Rows.Clear()
        lblAnioActual.Text = "False"
        lblRespaldoAnioActual.Text = "False"
        btnGuardar.Enabled = False
        cmbAnio.Items.Clear()


        listaPrimaVacacional = ObjBU.ListaPrimaVacacional(cmbNave.SelectedValue)
        AgregarAnios(listaPrimaVacacional)
    End Sub



    Private Sub cmbAnio_DropDownClosed(sender As Object, e As EventArgs) Handles cmbAnio.DropDownClosed
        Dim objBu As New Negocios.CalcularPrimaVacacionalBU

        If cmbAnio.SelectedIndex > 0 Then
            If objBu.ExistePrimaVacacionalNave(cmbNave.SelectedValue, cmbAnio.Text) = True Then
                ImprimirCartasToolStripMenuItem.Visible = True
            Else
                ImprimirCartasToolStripMenuItem.Visible = False
            End If
        End If
        'Try

        '    Dim objBu As New Negocios.CalcularPrimaVacacionalBU
        '    Dim tabla As New DataTable
        '    tabla = objBu.fechasSueldosVacaciones(cmbNave.SelectedValue, cmbAnio.Text) ' Ticket 15367

        '    If tabla.Rows.Count = 4 Then
        '        fecha4 = " Del:" + CDate(tabla.Rows(0).Item("FechaInicial")).ToShortDateString + " Al:" + CDate(tabla.Rows(0).Item("FechaFinal")).ToShortDateString
        '        fecha3 = " Del:" + CDate(tabla.Rows(1).Item("FechaInicial")).ToShortDateString + " Al:" + CDate(tabla.Rows(1).Item("FechaFinal").ToString).ToShortDateString
        '        fecha2 = " Del:" + CDate(tabla.Rows(2).Item("FechaInicial")).ToShortDateString + " Al:" + CDate(tabla.Rows(2).Item("FechaFinal").ToString).ToShortDateString
        '        fecha1 = " Del:" + CDate(tabla.Rows(3).Item("FechaInicial")).ToShortDateString + " Al:" + CDate(tabla.Rows(3).Item("FechaFinal").ToString).ToShortDateString

        '        clmSemana1.HeaderText = fecha1.ToString
        '        clmSemana2.HeaderText = fecha2.ToString
        '        clmSemana3.HeaderText = fecha3.ToString
        '        clmSemana4.HeaderText = fecha4.ToString

        '        FechaFinalPeriodo = CDate(tabla.Rows(0).Item("FechaFinal")).ToShortDateString

        '    End If
        'Catch ex As Exception

        'End Try

    End Sub



    Private Sub pnlAcciones_Paint(sender As Object, e As PaintEventArgs) Handles pnlAcciones.Paint

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles lblsueldos.Click

    End Sub

    Private Sub cmbPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPeriodo.SelectedIndexChanged
        Dim objBu As New Negocios.CalcularPrimaVacacionalBU
        Dim tabla As New DataTable
        If cmbPeriodo.Text = "SEMANA SANTA" Then
            tabla = objBu.obtenerSemanasSueldoVacaciones(cmbNave.SelectedValue, cmbAnio.Text)

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
        Else

            Try

                tabla = objBu.fechasSueldosVacaciones(cmbNave.SelectedValue, cmbAnio.Text) ' Ticket 15367

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

        End If


    End Sub

    Private Sub imprimirCartasSemanaSanta()
        Dim Colaborador As String = ""
        If cmbNave.SelectedIndex > 0 Then
            Try
                Dim dateForm As New DateForm()
                Dim fecha As New Date
                dateForm.mensaje = "Seleccione la fecha deseada."
                dateForm.ShowDialog()
                fecha = dateForm.dtpFecha.Value
                Dim dsColaboradores As New DataSet
                Dim dtColaboradoresRelacion As New DataTable
                Dim dtColaboradoresDatos As New DataTable
                Dim obj As New Nomina.Negocios.CalcularPrimaVacacionalBU
                Dim tool As New Tools.Controles

                dtColaboradoresDatos = New DataTable("dtColaboradoresDatos")
                With dtColaboradoresDatos
                    .Columns.Add("nombreColaborador")
                    .Columns.Add("primVac")
                    .Columns.Add("vacaciones")
                    .Columns.Add("totalVacLetra")
                    .Columns.Add("totalVac")
                    .Columns.Add("diasVacaciones")
                    .Columns.Add("retencionISR")
                End With
                Dim datos As DataTable
                datos = obj.obtenerInfoReporteVacacionesCartaFinal(cmbNave.SelectedValue, cmbAnio.Text)
                For Each r As DataRow In datos.Rows
                    dtColaboradoresDatos.Rows.Add("" & r("Nombre").ToString & " " & r("Apellido Paterno").ToString & " " & r("Apellido Materno").ToString,
                                                 CDbl(r("prim_subTotal")),
                                                 CDbl(r("prim_primavacacional")),
                                                 " (" + tool.EnLetras((r("Vacaciones") - r("vac_ISRRetenido")).ToString.Replace(".0000", "")).ToUpper + " PESOS 00/100 M.N.) ",
                                                 CDbl(r("Vacaciones")) - CDbl(r("vac_ISRRetenido")), CInt(r("prim_diasxpagar")), CDbl(r("vac_ISRRetenido"))
                                                 )
                Next

                dsColaboradores.Tables.Add(dtColaboradoresDatos)
                Me.Cursor = Cursors.WaitCursor
                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("CARTAS_FINALES_VACA")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport

                reporte.Load(archivo)
                reporte.Compile()
                reporte.RegData(dsColaboradores)
                reporte("rutaImagen") = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
                reporte("fechadeldia") = fecha.ToLongDateString
                reporte("año") = "" & Year(Now)
                reporte.Show()
                Me.Cursor = Cursors.Default
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ImprimirCartasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirCartasToolStripMenuItem.Click
        If cmbPeriodo.Text = "SEMANA SANTA" Then
            imprimirCartasSemanaSanta()
        Else
            imprimirCartas()
        End If
    End Sub

    Private Sub ReporteVacacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteVacacionesToolStripMenuItem.Click
        imprimirReporteVacaciones()
    End Sub

    Private Sub imprimirReporteVacaciones()
        Try

            If grdCalculoPrimaVacacional.Rows.Count > 0 Then
                Me.Cursor = Cursors.WaitCursor



                Dim Colaborador = New DataTable("Colaboradores")

                'Dim Efectivo = New DataTable("Efectivo")
                Dim totalEntregar As Double = 0
                Dim totalVacaciones As Double = 0
                Dim totalPrimaVacacional As Double = 0
                Dim totalISR As Double = 0
                Dim pagoNeto As Double = 0
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
                    .Columns.Add("clmVacaciones")
                    .Columns.Add("clmPrimaVacacional")
                    .Columns.Add("clmTotalEntregar")
                    .Columns.Add("clmisrRetenido")
                    .Columns.Add("clmPagoNeto")


                End With

                totalEntregar = 0
                totalPrimaVacacional = 0
                totalVacaciones = 0
                totalISR = 0
                pagoNeto = 0
                For Each fila As DataGridViewRow In grdCalculoPrimaVacacional.Rows

                    If fila.Cells("clmColaborador").Value <> "" Then
                        Colaborador.Rows.Add(
                            fila.Cells("clmColaborador").Value,
                            fila.Cells("clmIngreso").Value.ToString.Replace(",", ""),
                            fila.Cells("clmAnios").Value,
                            Math.Round(fila.Cells("clmMeses").Value, 2),
                            fila.Cells("clmDiasAPagar").Value.ToString,
                            fila.Cells("clmFaltas").Value,
                            fila.Cells("clmSemana1").Value,
                            fila.Cells("clmSemana2").Value,
                            fila.Cells("clmSemana3").Value,
                            fila.Cells("clmSemana4").Value,
                            fila.Cells("clmSueldoDiario").Value,
                            fila.Cells("clmSubTotal").Value,
                            fila.Cells("clmPrimaVacacional").Value,
                            fila.Cells("clmTotalEntregar").Value,
                            fila.Cells("clmisrRetenido").Value,
                            fila.Cells("clmPagoNeto").Value
                            )
                        totalVacaciones += fila.Cells("clmSubTotal").Value
                        totalPrimaVacacional += fila.Cells("clmPrimaVacacional").Value
                        totalEntregar += fila.Cells("clmTotalEntregar").Value
                        totalISR += fila.Cells("clmisrRetenido").Value
                        pagoNeto += fila.Cells("clmPagoNeto").Value
                    End If
                Next



                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("REPORTE_VACA_NUEVO")
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


                ''Se indica el valor que va a tomar el parametro   
                'If cmbNave.SelectedValue = 2 Then
                '    rutaLogo = rutaPublica & "LOGOTIPOS/YUYIN.JPG"

                'ElseIf cmbNave.SelectedValue = 3 Then
                '    rutaLogo = rutaPublica & "LOGOTIPOS/JEANS.JPG"

                'ElseIf cmbNave.SelectedValue = 4 Then
                '    rutaLogo = rutaPublica & "LOGOTIPOS/MERANO.JPG"

                'ElseIf cmbNave.SelectedValue = 5 Then
                '    rutaLogo = rutaPublica & "LOGOTIPOS/JEANS2.JPG"

                'ElseIf cmbNave.SelectedValue = 43 Then
                'rutaLogo = rutaPublica & "LOGOTIPOS/GRUPOYUYIN.JPG"

                'End If


                reporte.Load(archivo)
                reporte.Compile()
                reporte("rutaImagen") = rutaLogo
                reporte("UserName") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
                reporte("NombreUsuario") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString.ToUpper
                reporte("titulo") = "REPORTE DE VACACIONES " + cmbAnio.Text.ToString
                reporte("tituloDias") = "DIAS VAC."
                reporte("totalVacaciones") = totalVacaciones.ToString("N0")
                reporte("totalPrimaVacacional") = totalPrimaVacacional.ToString("N0")
                reporte("totalEntregar") = totalEntregar.ToString("N0")
                reporte("totalISR") = totalISR.ToString("N0")
                reporte("pagoNeto") = pagoNeto.ToString("N0")
                reporte("NombreArchivo") = "ReporteListaVacaciones.mrt"
                reporte("NaveNombre") = cmbNave.Text
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
    End Sub

    Private Sub imprimirCartas()
        Dim Colaborador As String = ""
        Dim soloVacaciones As Int32 = 0
        If cmbNave.SelectedIndex > 0 Then

            Try
                Dim dateForm As New DateForm()
                Dim fecha As New Date
                dateForm.mensaje = "Seleccione la fecha deseada."
                dateForm.ShowDialog()
                fecha = dateForm.dtpFecha.Value
                Dim dsColaboradores As New DataSet
                Dim dtColaboradoresRelacion As New DataTable
                Dim dtColaboradoresDatos As New DataTable
                Dim obj As New Nomina.Negocios.RealesFiscalesBU
                Dim tool As New Tools.Controles
                dtColaboradoresRelacion = New DataTable("dtColaboradoresRelacion")
                With dtColaboradoresRelacion
                    .Columns.Add("nombre")
                    .Columns.Add("aguinaldo")
                    .Columns.Add("aguinaldoLetra")

                End With
                dtColaboradoresDatos = New DataTable("dtColaboradoresDatos")
                With dtColaboradoresDatos
                    .Columns.Add("nombreColaborador")
                    .Columns.Add("primVac")
                    .Columns.Add("vacaciones")
                    .Columns.Add("totalVacLetra")
                    .Columns.Add("totalVac")
                End With
                Dim datos As DataTable
                datos = obj.getDatos(cmbNave.SelectedValue, cmbAnio.Text, Colaborador, soloVacaciones)
                For Each r As DataRow In datos.Rows
                    dtColaboradoresDatos.Rows.Add("" & r("Nombre").ToString & " " & r("Apellido Paterno").ToString & " " & r("Apellido Materno").ToString,
                                                 CDbl(r("prim_subTotal")),
                                                 CDbl(r("prim_primavacacional")),
                                                 " (" + tool.EnLetras(r("Vacaciones").ToString.Replace(".0000", "")).ToUpper + " PESOS 00/100 M.N.) ",
                                                 CDbl(r("Vacaciones"))
                                                 )


                    dtColaboradoresRelacion.Rows.Add(
                        r("Nombre").ToString & " " & r("Apellido Paterno").ToString & " " & r("Apellido Materno").ToString,
                        CDbl(r("Aguinaldo")),
                        " (" + tool.EnLetras(r("Aguinaldo").ToString.Replace(".0000", "")).ToUpper + " PESOS 00/100 M.N.) "
                        )
                Next

                dsColaboradores.Tables.Add(dtColaboradoresRelacion)
                dsColaboradores.Tables.Add(dtColaboradoresDatos)
                Me.Cursor = Cursors.WaitCursor
                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("CARTAS_FINALES")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport

                reporte.Load(archivo)
                reporte.Compile()
                reporte.RegData(dsColaboradores)
                reporte("rutaImagen") = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
                reporte("fechadeldia") = fecha.ToLongDateString
                reporte("año") = "" & Year(Now)
                reporte.Show()
                Me.Cursor = Cursors.Default
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class