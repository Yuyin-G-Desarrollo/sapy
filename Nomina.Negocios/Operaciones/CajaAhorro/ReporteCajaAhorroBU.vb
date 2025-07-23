Public Class ReporteCajaAhorroBU

    Private pResultado As String = String.Empty

    Public Property Resultado As String
        Get
            Return pResultado
        End Get
        Set(ByVal value As String)
            pResultado = value
        End Set
    End Property


    Public Function Listar(ByVal IdCajaAhorro As Int32) As List(Of Entidades.ReporteCajaAhorro)
        Listar = New List(Of Entidades.ReporteCajaAhorro)

        Dim objReporteCajaAhorroDA As New Nomina.Datos.ReporteCajaAhorroDA
        Dim tabla As New DataTable
        tabla = objReporteCajaAhorroDA.Listar(IdCajaAhorro)
        For Each renglon As DataRow In tabla.Rows
            Dim objReporteCajaAhorro As New Entidades.ReporteCajaAhorro

            objReporteCajaAhorro.pAhorrado = renglon("ahorrado")
            objReporteCajaAhorro.pAhorroMasInteres = renglon("TotalAhorroMasInteres")
            objReporteCajaAhorro.pGanadas = renglon("ganadas")
            objReporteCajaAhorro.pIdCajaAhorro = renglon("caja_cajaahorroid")
            objReporteCajaAhorro.pInteres = renglon("cocn_interes")
            objReporteCajaAhorro.pMontoAhorro = renglon("cajc_montoahorro")
            objReporteCajaAhorro.pNombre = renglon("Nombre")
            objReporteCajaAhorro.pPerdidas = renglon("Perdidas")
            objReporteCajaAhorro.pPeriodos = renglon("periodos")
            objReporteCajaAhorro.pTotalInteres = renglon("TotalInteres")
            objReporteCajaAhorro.pIdColaborador = renglon("codr_colaboradorid")
            objReporteCajaAhorro.pEstatus = renglon("cajc_estatus")

            Listar.Add(objReporteCajaAhorro)

        Next

        Return Listar
    End Function


    Public Sub VerificaExistenciaCierre(ByVal IdCajaAhorro)

        Dim objReporteCajaAhorroDA As New Nomina.Datos.ReporteCajaAhorroDA
        Resultado = ""

        If objReporteCajaAhorroDA.VerificaExistenciaCierre(IdCajaAhorro) <= 0 Then
            Resultado = "Ya se hizo el cierre anual de esta caja de ahorro."
            Exit Sub
        End If

    End Sub


    Public Sub VerificaExistenciaSemanasSinCerrar(ByVal IdCajaAhorro)

        Dim objReporteCajaAhorroDA As New Nomina.Datos.ReporteCajaAhorroDA
        Resultado = ""

        If objReporteCajaAhorroDA.VerificaExistenciaSemanasSinCerrar(IdCajaAhorro) > 0 Then
            Resultado = "Se encontraron semanas de caja de ahorro sin cerrar. Cierrelas para continuar."
            Exit Sub
        End If

    End Sub

    Public Sub VerificaExistenciaSemanaNomina(ByVal IdCajaAhorro)

        Dim objReporteCajaAhorroDA As New Nomina.Datos.ReporteCajaAhorroDA
        Resultado = ""

        If objReporteCajaAhorroDA.VerificaExistenciaSemanaNomina(IdCajaAhorro) <= 0 Then
            Resultado = "No se encontro la ultima semana de nomina para la caja de ahorro."
            Exit Sub
        End If

    End Sub

    Public Sub CierreAnualCajaAhorro(ByVal IdCajaAhorro As Int32)

        Dim objReporteCajaAhorroDA As New Nomina.Datos.ReporteCajaAhorroDA
        objReporteCajaAhorroDA.CierreAnualCajaAhorro(IdCajaAhorro)

    End Sub


    Public Function ConsultaSemanasCaja(ByVal idCajaAhorro As Int32) As List(Of Entidades.PeriodosNomina)
        Dim semanasCadaDA As New Datos.ReporteCajaAhorroDA
        ConsultaSemanasCaja = New List(Of Entidades.PeriodosNomina)

        Dim tabla As New DataTable
        tabla = semanasCadaDA.consultaSemanasCaJa(idCajaAhorro)
        For Each row As DataRow In tabla.Rows
            Dim semana As New Entidades.PeriodosNomina
            semana.PeriodoId = row("pnom_PeriodoNomId")
            semana.PFechaInicio = row("pnom_FechaInicial")
            semana.PFechaFin = row("pnom_FechaFinal")

            ConsultaSemanasCaja.Add(semana)
        Next
    End Function

    Public Function ConsultaColaboradoresCajaCierre(ByVal idCajaAhorro As Int32) As List(Of Entidades.ColaboradorLaboral)
        Dim objDA As New Datos.ReporteCajaAhorroDA
        ConsultaColaboradoresCajaCierre = New List(Of Entidades.ColaboradorLaboral)

        Dim tabla As New DataTable
        tabla = objDA.colaboradoresCajaCierre(idCajaAhorro)
        For Each row As DataRow In tabla.Rows
            Dim colaborador As New Entidades.Colaborador
            colaborador.PColaboradorid = row("codr_colaboradorid")
            colaborador.PApaterno = row("codr_apellidopaterno")
            colaborador.PAmaterno = row("codr_apellidomaterno")
            colaborador.PNombre = row("codr_nombre")
            colaborador.PFechaCreacion = row("codr_fechacreacion")
            Dim laboralBU As New ColaboradorLaboralBU
            Dim labo As New Entidades.ColaboradorLaboral
            labo = laboralBU.buscarInformacionLaboral(colaborador.PColaboradorid)
            labo.PColaboradorId = colaborador
            ConsultaColaboradoresCajaCierre.Add(labo)
        Next
    End Function

    Public Function ConsultaColaboradoresCajaCierre2(ByVal idCajaAhorro As Int32) As DataTable
        Dim objDA As New Datos.ReporteCajaAhorroDA
        Return objDA.colaboradoresCajaCierre2(idCajaAhorro)
    End Function

    Public Function ConsultaSemanasGanadas(ByVal idColaborador As Int32, ByVal idSemana As Int32) As Boolean
        Dim objDA As New Datos.ReporteCajaAhorroDA
        Return objDA.ConsultaSemanasGanadas(idColaborador, idSemana)
    End Function

    Public Function consultaSemanasGanadasCol(ByVal idColaborador As Int32, ByVal idCajaAhorro As Int32) As DataTable
        Dim objDA As New Datos.ReporteCajaAhorroDA
        Return objDA.consultaSemanasGanadasCol(idColaborador, idCajaAhorro)
    End Function

    Public Function consultaSemanaIngreso(ByVal idColaborador As Int32, ByVal idCajaAhorro As Int32) As Int32
        Dim objDA As New Datos.ReporteCajaAhorroDA
        Return objDA.ConsultaSemanaIngreso(idColaborador, idCajaAhorro)
    End Function

    Public Function consultaSemanasGanadasNoCheCa(ByVal idCajaAhorro As Int32, ByVal nave As Int32) As Int32
        Dim objDA As New Datos.ReporteCajaAhorroDA
        Return objDA.ConsultaSemanasGanadasNoCheca(idCajaAhorro, nave)
    End Function

    Public Function CountSemanasAhorradas(ByVal idColaborador As Int32, ByVal idCajaAhorro As Int32) As Int32
        Dim objDA As New Datos.ReporteCajaAhorroDA
        Return objDA.CountSemanasAhorradas(idColaborador, idCajaAhorro)
    End Function

    Public Function CountSemanasGanadas(ByVal idColaborador As Int32, ByVal idCajaAhorro As Int32, ByVal accion As Int32) As Int32
        Dim objDA As New Datos.ReporteCajaAhorroDA
        Return objDA.CountSemanasGanadas(idColaborador, idCajaAhorro, accion)
    End Function

    Public Function CalcularInteresTotal(ByVal idCajaAhorro As Int32, ByVal idColaborador As Int32, ByVal interes As Int32) As Int32
        Dim objDA As New Datos.ReporteCajaAhorroDA
        Return objDA.CalcularInteresTotal(idCajaAhorro, idColaborador, interes)
        'ByVal semanasAhorradas As Int32, ByVal totalSemanas As Int32, ByVal otorgarMaximo As Boolean
    End Function

    Public Function BuscaInteresGanado(ByVal idCajaAhorro As Int32, ByVal semanasPerdidas As Int32) As Int32
        Dim objDA As New Datos.ReporteCajaAhorroDA
        Return objDA.BuscaInteresGanado(idCajaAhorro, semanasPerdidas)
        'ByVal semanasAhorradas As Int32, ByVal totalSemanas As Int32, ByVal otorgarMaximo As Boolean
    End Function

    Public Function BuscaMontoAcumulado(ByVal idCajaAhorro As Int32, ByVal idcolaborador As Int32) As Double
        Dim objDA As New Datos.ReporteCajaAhorroDA
        Return objDA.BuscaMontoAcumulado(idCajaAhorro, idcolaborador)
    End Function

    Public Function BuscaMontoAhorroColaborador(ByVal idCajaAhorro As Int32, ByVal idcolaborador As Int32) As Double
        Dim objDA As New Datos.ReporteCajaAhorroDA
        Return objDA.BuscaMontoAhorroColaborador(idCajaAhorro, idcolaborador)
    End Function


    Public Sub cierreAnualCajaAhorro(ByVal CierreAnual As Entidades.ReporteCajaAhorro)
        Dim objCierreAnual As New Datos.ReporteCajaAhorroDA
        objCierreAnual.CierreAnualCajaAhorro(CierreAnual)

    End Sub

    Public Sub guardarAbonosTemporal(ByVal idprestamo As Integer, ByVal abono As Double)
        Dim objCierreAnual As New Datos.ReporteCajaAhorroDA
        objCierreAnual.guardarAbonosTemporal(idprestamo, abono)
    End Sub

    Public Sub guardarAbonosCierreCaja(ByVal idcolaborador As Integer, ByVal idcajaAhorro As Integer, ByVal abono As Double, ByVal operacion As Integer, ByVal usuario As Integer)
        Dim objCierreAnual As New Datos.ReporteCajaAhorroDA
        objCierreAnual.guardarAbonosCierreCaja(idcolaborador, idcajaAhorro, abono, operacion, usuario)
    End Sub

    Public Function BuscaMontoAbonoTemporal(ByVal idColaborador As Integer, ByVal idCajaAhorro As Integer) As Double
        Dim objCierreAnual As New Datos.ReporteCajaAhorroDA
        Return objCierreAnual.BuscaMontoAbonoTemporal(idColaborador, idCajaAhorro)
    End Function

    Public Function ConsultaCierreAnual(ByVal idCajaAhorro, ByVal idColaborador) As Entidades.ReporteCajaAhorro
        ConsultaCierreAnual = New Entidades.ReporteCajaAhorro
        Dim objCierreAnual As New Datos.ReporteCajaAhorroDA
        Dim tabla As New DataTable
        tabla = objCierreAnual.ConsultaCierreAnual(idCajaAhorro, idColaborador)

        For Each row As DataRow In tabla.Rows
            ConsultaCierreAnual.pMontoAhorro = CDbl("cca_montoahorro")
            ConsultaCierreAnual.PSemanasAhorradas = CInt("cca_semanasahorradas")
            ConsultaCierreAnual.pGanadas = CInt("cca_semanasganadas")
            ConsultaCierreAnual.pPerdidas = CInt("cca_semanasperdidas")
            ConsultaCierreAnual.pInteres = CDbl("cca_interesganado")
            ConsultaCierreAnual.PMontoAcumuladoCajaAnual = CDbl("cca_montoacumulado")
            ConsultaCierreAnual.pTotalInteres = CDbl("cca_totalintereses")
            ConsultaCierreAnual.PMontoAcumuladoCajaMASInteres = CDbl("cca_totalcaja")

            Dim prestamo As New Entidades.SolicitudPrestamo

        Next
    End Function

    Public Function consultaCajaAhorroRecorridas(ByVal idCaja As Int32) As Int32
        Dim opjDA As New Datos.ReporteCajaAhorroDA
        Return opjDA.consultaCajaAhorroRecorridas(idCaja)
    End Function

    Public Function consultaDeduccionesPrestamosSemanas(ByVal anio As Int32) As DataTable
        Dim objBU As New Datos.ReporteCajaAhorroDA
        Dim dtDed As New DataTable
        Dim dtPres As New DataTable
        Dim dtLiqds As New DataTable

        Dim dt As New DataTable

        dt.Columns.Add("semanaNomina")
        dt.Columns.Add("semanaAhorro")
        dt.Columns.Add("consecutivo")
        dt.Columns.Add("YUYIND", Type.GetType("System.Int32"))
        dt.Columns.Add("JEANSD", Type.GetType("System.Int32"))
        dt.Columns.Add("MERANOD", Type.GetType("System.Int32"))
        dt.Columns.Add("VAGABUNDOD", Type.GetType("System.Int32"))
        dt.Columns.Add("JEANS2D", Type.GetType("System.Int32"))
        dt.Columns.Add("ORENSED", Type.GetType("System.Int32"))
        dt.Columns.Add("COMERCIALIZADORAD", Type.GetType("System.Int32"))
        dt.Columns.Add("RANCHITOD", Type.GetType("System.Int32"))
        dt.Columns.Add("COMERCIALIZADORADESUELASD", Type.GetType("System.Int32"))
        dt.Columns.Add("INYEVAD", Type.GetType("System.Int32"))
        dt.Columns.Add("VILLAGONTID", Type.GetType("System.Int32"))
        dt.Columns.Add("CASTORD", Type.GetType("System.Int32"))
        dt.Columns.Add("CITYD", Type.GetType("System.Int32"))
        dt.Columns.Add("TOTALD", Type.GetType("System.Int32"))
        dt.Columns.Add("consecutivoP")
        dt.Columns.Add("YUYINP", Type.GetType("System.Int32"))
        dt.Columns.Add("JEANSP", Type.GetType("System.Int32"))
        dt.Columns.Add("MERANOP", Type.GetType("System.Int32"))
        dt.Columns.Add("VAGABUNDOP", Type.GetType("System.Int32"))
        dt.Columns.Add("JEANS2P", Type.GetType("System.Int32"))
        dt.Columns.Add("ORENSEP", Type.GetType("System.Int32"))
        dt.Columns.Add("COMERCIALIZADORAP", Type.GetType("System.Int32"))
        dt.Columns.Add("RANCHITOP", Type.GetType("System.Int32"))
        dt.Columns.Add("COMERCIALIZADORADESUELASP", Type.GetType("System.Int32"))
        dt.Columns.Add("INYEVAP", Type.GetType("System.Int32"))
        dt.Columns.Add("VILLAGONTIP", Type.GetType("System.Int32"))
        dt.Columns.Add("CASTORP", Type.GetType("System.Int32"))
        dt.Columns.Add("CITYP", Type.GetType("System.Int32"))
        dt.Columns.Add("TOTALP", Type.GetType("System.Int32"))
        dt.Columns.Add("consecutivoL")
        dt.Columns.Add("YUYINL", Type.GetType("System.Int32"))
        dt.Columns.Add("JEANSL", Type.GetType("System.Int32"))
        dt.Columns.Add("MERANOL", Type.GetType("System.Int32"))
        dt.Columns.Add("VAGABUNDOL", Type.GetType("System.Int32"))
        dt.Columns.Add("JEANS2L", Type.GetType("System.Int32"))
        dt.Columns.Add("ORENSEL", Type.GetType("System.Int32"))
        dt.Columns.Add("COMERCIALIZADORAL", Type.GetType("System.Int32"))
        dt.Columns.Add("RANCHITOL", Type.GetType("System.Int32"))
        dt.Columns.Add("COMERCIALIZADORADESUELASL", Type.GetType("System.Int32"))
        dt.Columns.Add("INYEVAL", Type.GetType("System.Int32"))
        dt.Columns.Add("VILLAGONTIL", Type.GetType("System.Int32"))
        dt.Columns.Add("CASTORL", Type.GetType("System.Int32"))
        dt.Columns.Add("CITYL", Type.GetType("System.Int32"))
        dt.Columns.Add("TOTALL", Type.GetType("System.Int32"))


        'dtDed = objBU.consultaDeduccionesSemanas(anio)
        'dtPres = objBU.consultaPrestamoSemanas(anio)
        'dtLiqds = objBU.consultaLisquidacionSemana(anio)

        dt = objBU.consultaDeduccionesSemanas(anio)

        ' If dtDed.Rows.Count > 0 And dtPres.Rows.Count > 0 Then
        'Dim SUMADED As Int32 = 0
        'For Each rowDed As DataRow In dtDed.Rows
        '    SUMADED = 0
        '    Dim dtRowDP As DataRow
        '    dtRowDP = dt.NewRow
        '    dtRowDP.Item(0) = regresarCero(rowDed.Item(0).ToString)
        '    dtRowDP.Item(1) = regresarCero(rowDed.Item(1).ToString)
        '    dtRowDP.Item(2) = regresarCero(rowDed.Item(2).ToString)
        '    'SUMADED = SUMADED + regresarCero(rowDed.Item(2).ToString)
        '    dtRowDP.Item(3) = regresarCero(rowDed.Item(3).ToString)
        '    SUMADED = SUMADED + regresarCero(rowDed.Item(3).ToString)
        '    dtRowDP.Item(4) = regresarCero(rowDed.Item(4).ToString)
        '    SUMADED = SUMADED + regresarCero(rowDed.Item(4).ToString)        
        '    dtRowDP.Item(5) = regresarCero(rowDed.Item(5).ToString)
        '    SUMADED = SUMADED + regresarCero(rowDed.Item(5).ToString)
        '    dtRowDP.Item(6) = regresarCero(rowDed.Item(6).ToString)
        '    SUMADED = SUMADED + regresarCero(rowDed.Item(6).ToString)
        '    dtRowDP.Item(7) = regresarCero(rowDed.Item(7).ToString)
        '    SUMADED = SUMADED + regresarCero(rowDed.Item(7).ToString)
        '    dtRowDP.Item(8) = regresarCero(rowDed.Item(8).ToString)
        '    SUMADED = SUMADED + regresarCero(rowDed.Item(8).ToString)
        '    dtRowDP.Item(9) = regresarCero(rowDed.Item(9).ToString)
        '    SUMADED = SUMADED + regresarCero(rowDed.Item(9).ToString)
        '    dtRowDP.Item(10) = regresarCero(rowDed.Item(10).ToString)
        '    SUMADED = SUMADED + regresarCero(rowDed.Item(10).ToString)
        '    dtRowDP.Item(11) = regresarCero(rowDed.Item(11).ToString)
        '    SUMADED = SUMADED + regresarCero(rowDed.Item(11).ToString)
        '    dtRowDP.Item(12) = regresarCero(rowDed.Item(12).ToString)
        '    SUMADED = SUMADED + regresarCero(rowDed.Item(12).ToString)
        '    dtRowDP.Item("TOTALD") = SUMADED
        '    dt.Rows.Add(dtRowDP)
        'Next

        'Dim contRowPRES As Int32 = 0
        'Dim contTotFilasPRES As Int32 = 0
        'contTotFilasPRES = dt.Rows.Count
        'Dim SUMERES As Int32 = 0
        'For Each rowPres As DataRow In dtPres.Rows
        '    SUMERES = 0
        '    If contRowPRES < contTotFilasPRES Then
        '        If dt.Rows(contRowPRES).Item(0) = rowPres.Item(0) And dt.Rows(contRowPRES).Item(1) = rowPres.Item(1) Then
        '            dt.Rows(contRowPRES).Item(14) = regresarCero(rowPres.Item(2).ToString)
        '            'SUMERES = SUMERES + regresarCero(rowPres.Item(2).ToString)
        '            dt.Rows(contRowPRES).Item(15) = regresarCero(rowPres.Item(3).ToString)
        '            SUMERES = SUMERES + regresarCero(rowPres.Item(3).ToString)
        '            dt.Rows(contRowPRES).Item(16) = regresarCero(rowPres.Item(4).ToString)
        '            SUMERES = SUMERES + regresarCero(rowPres.Item(4).ToString)
        '            dt.Rows(contRowPRES).Item(17) = regresarCero(rowPres.Item(5).ToString)
        '            SUMERES = SUMERES + regresarCero(rowPres.Item(5).ToString)
        '            dt.Rows(contRowPRES).Item(18) = regresarCero(rowPres.Item(6).ToString)
        '            SUMERES = SUMERES + regresarCero(rowPres.Item(6).ToString)
        '            dt.Rows(contRowPRES).Item(19) = regresarCero(rowPres.Item(7).ToString)
        '            SUMERES = SUMERES + regresarCero(rowPres.Item(7).ToString)
        '            dt.Rows(contRowPRES).Item(20) = regresarCero(rowPres.Item(8).ToString)
        '            SUMERES = SUMERES + regresarCero(rowPres.Item(8).ToString)
        '            dt.Rows(contRowPRES).Item(21) = regresarCero(rowPres.Item(9).ToString)
        '            SUMERES = SUMERES + regresarCero(rowPres.Item(9).ToString)
        '            dt.Rows(contRowPRES).Item(22) = regresarCero(rowPres.Item(10).ToString)
        '            SUMERES = SUMERES + regresarCero(rowPres.Item(10).ToString)
        '            dt.Rows(contRowPRES).Item(23) = regresarCero(rowPres.Item(11).ToString)
        '            SUMERES = SUMERES + regresarCero(rowPres.Item(11).ToString)
        '            dt.Rows(contRowPRES).Item(24) = regresarCero(rowPres.Item(12).ToString)
        '            SUMERES = SUMERES + regresarCero(rowPres.Item(12).ToString)
        '            dt.Rows(contRowPRES).Item("TOTALP") = SUMERES
        '        End If
        '    End If
        '    contRowPRES += 1
        'Next

        'Dim contRowLiqds As Int32 = 0
        'Dim contTotFilasLiqds As Int32 = 0
        'contTotFilasLiqds = dt.Rows.Count
        'Dim SUMLQDS As Int32 = 0
        'For Each rowLiqds As DataRow In dtLiqds.Rows
        '    SUMLQDS = 0
        '    If contRowLiqds < contTotFilasLiqds Then
        '        If dt.Rows(contRowLiqds).Item(0) = rowLiqds.Item(0) And dt.Rows(contRowLiqds).Item(1) = rowLiqds.Item(1) Then
        '            'dt.Rows(contRowLiqds).Item(22) = regresarCero(rowLiqds.Item(2).ToString)
        '            'SUMLQDS = SUMLQDS + regresarCero(rowLiqds.Item(2).ToString)
        '            dt.Rows(contRowLiqds).Item(27) = regresarCero(rowLiqds.Item(3).ToString)
        '            SUMLQDS = SUMLQDS + regresarCero(rowLiqds.Item(3).ToString)
        '            dt.Rows(contRowLiqds).Item(28) = regresarCero(rowLiqds.Item(4).ToString)
        '            SUMLQDS = SUMLQDS + regresarCero(rowLiqds.Item(4).ToString)
        '            dt.Rows(contRowLiqds).Item(29) = regresarCero(rowLiqds.Item(5).ToString)
        '            SUMLQDS = SUMLQDS + regresarCero(rowLiqds.Item(5).ToString)
        '            dt.Rows(contRowLiqds).Item(30) = regresarCero(rowLiqds.Item(6).ToString)
        '            SUMLQDS = SUMLQDS + regresarCero(rowLiqds.Item(6).ToString)
        '            dt.Rows(contRowLiqds).Item(31) = regresarCero(rowLiqds.Item(7).ToString)
        '            SUMLQDS = SUMLQDS + regresarCero(rowLiqds.Item(7).ToString)
        '            dt.Rows(contRowLiqds).Item(32) = regresarCero(rowLiqds.Item(8).ToString)
        '            SUMLQDS = SUMLQDS + regresarCero(rowLiqds.Item(8).ToString)
        '            dt.Rows(contRowLiqds).Item(33) = regresarCero(rowLiqds.Item(9).ToString)
        '            SUMLQDS = SUMLQDS + regresarCero(rowLiqds.Item(9).ToString)
        '            dt.Rows(contRowLiqds).Item(34) = regresarCero(rowLiqds.Item(10).ToString)
        '            SUMLQDS = SUMLQDS + regresarCero(rowLiqds.Item(10).ToString)
        '            dt.Rows(contRowLiqds).Item(35) = regresarCero(rowLiqds.Item(11).ToString)
        '            SUMLQDS = SUMLQDS + regresarCero(rowLiqds.Item(11).ToString)
        '            dt.Rows(contRowLiqds).Item(36) = regresarCero(rowLiqds.Item(12).ToString)
        '            SUMLQDS = SUMLQDS + regresarCero(rowLiqds.Item(12).ToString)
        '            dt.Rows(contRowLiqds).Item("TOTALL") = SUMLQDS
        '        End If
        '    End If
        '    contRowLiqds += 1
        'Next
        'End If

        Return dt
    End Function

    Public Function regresarCero(ByVal numero As String) As Int32
        If numero = "" Then
            Return 0
        End If
        Return CInt(numero)
    End Function

    Public Function consultaDeduccionesPrestamosSemanas_V2(ByVal anio As Int32) As DataTable
        Dim objBU As New Datos.ReporteCajaAhorroDA
        Dim dtDed As New DataTable
        Dim dtPres As New DataTable
        Dim dtLiqds As New DataTable

        Dim dt As New DataTable

        dt.Columns.Add("semanaNomina")
        dt.Columns.Add("semanaAhorro")
        dt.Columns.Add("consecutivo")
        dt.Columns.Add("YUYIND", Type.GetType("System.Int32"))
        dt.Columns.Add("JEANSD", Type.GetType("System.Int32"))
        dt.Columns.Add("MERANOD", Type.GetType("System.Int32"))
        dt.Columns.Add("VAGABUNDOD", Type.GetType("System.Int32"))
        dt.Columns.Add("JEANS2D", Type.GetType("System.Int32"))
        dt.Columns.Add("ORENSED", Type.GetType("System.Int32"))
        dt.Columns.Add("COMERCIALIZADORAD", Type.GetType("System.Int32"))
        dt.Columns.Add("RANCHITOD", Type.GetType("System.Int32"))
        dt.Columns.Add("COMERCIALIZADORADESUELASD", Type.GetType("System.Int32"))
        dt.Columns.Add("INYEVAD", Type.GetType("System.Int32"))
        dt.Columns.Add("VILLAGONTID", Type.GetType("System.Int32"))
        dt.Columns.Add("CASTORD", Type.GetType("System.Int32"))
        dt.Columns.Add("CITYD", Type.GetType("System.Int32"))
        dt.Columns.Add("TOTALD", Type.GetType("System.Int32"))
        dt.Columns.Add("consecutivoP")
        dt.Columns.Add("YUYINP", Type.GetType("System.Int32"))
        dt.Columns.Add("JEANSP", Type.GetType("System.Int32"))
        dt.Columns.Add("MERANOP", Type.GetType("System.Int32"))
        dt.Columns.Add("VAGABUNDOP", Type.GetType("System.Int32"))
        dt.Columns.Add("JEANS2P", Type.GetType("System.Int32"))
        dt.Columns.Add("ORENSEP", Type.GetType("System.Int32"))
        dt.Columns.Add("COMERCIALIZADORAP", Type.GetType("System.Int32"))
        dt.Columns.Add("RANCHITOP", Type.GetType("System.Int32"))
        dt.Columns.Add("COMERCIALIZADORADESUELASP", Type.GetType("System.Int32"))
        dt.Columns.Add("INYEVAP", Type.GetType("System.Int32"))
        dt.Columns.Add("VILLAGONTIP", Type.GetType("System.Int32"))
        dt.Columns.Add("CASTORP", Type.GetType("System.Int32"))
        dt.Columns.Add("CITYP", Type.GetType("System.Int32"))
        dt.Columns.Add("TOTALP", Type.GetType("System.Int32"))
        dt.Columns.Add("consecutivoL")
        dt.Columns.Add("YUYINL", Type.GetType("System.Int32"))
        dt.Columns.Add("JEANSL", Type.GetType("System.Int32"))
        dt.Columns.Add("MERANOL", Type.GetType("System.Int32"))
        dt.Columns.Add("VAGABUNDOL", Type.GetType("System.Int32"))
        dt.Columns.Add("JEANS2L", Type.GetType("System.Int32"))
        dt.Columns.Add("ORENSEL", Type.GetType("System.Int32"))
        dt.Columns.Add("COMERCIALIZADORAL", Type.GetType("System.Int32"))
        dt.Columns.Add("RANCHITOL", Type.GetType("System.Int32"))
        dt.Columns.Add("COMERCIALIZADORADESUELASL", Type.GetType("System.Int32"))
        dt.Columns.Add("INYEVAL", Type.GetType("System.Int32"))
        dt.Columns.Add("VILLAGONTIL", Type.GetType("System.Int32"))
        dt.Columns.Add("CASTORL", Type.GetType("System.Int32"))
        dt.Columns.Add("CITYL", Type.GetType("System.Int32"))
        dt.Columns.Add("TOTALL", Type.GetType("System.Int32"))
        dt.Columns.Add("consecutivoN")
        dt.Columns.Add("YUYIN_N", Type.GetType("System.Int32"))
        dt.Columns.Add("JEANS_N", Type.GetType("System.Int32"))
        dt.Columns.Add("MERANO_N", Type.GetType("System.Int32"))
        dt.Columns.Add("VAGABUNDO_N", Type.GetType("System.Int32"))
        dt.Columns.Add("JEANS2_N", Type.GetType("System.Int32"))
        dt.Columns.Add("ORENSE_N", Type.GetType("System.Int32"))
        dt.Columns.Add("COMERCIALIZADORA_N", Type.GetType("System.Int32"))
        dt.Columns.Add("RANCHITO_N", Type.GetType("System.Int32"))
        dt.Columns.Add("COMERCIALIZADORADESUELAS_N", Type.GetType("System.Int32"))
        dt.Columns.Add("INYEVA_N", Type.GetType("System.Int32"))
        dt.Columns.Add("VILLAGONTI_N", Type.GetType("System.Int32"))
        dt.Columns.Add("CASTOR_N", Type.GetType("System.Int32"))
        dt.Columns.Add("CITY_N", Type.GetType("System.Int32"))
        dt.Columns.Add("TOTAL_N", Type.GetType("System.Int32"))

        'dtDed = objBU.consultaDeduccionesSemanas(anio)
        'dtPres = objBU.consultaPrestamoSemanas(anio)
        'dtLiqds = objBU.consultaLisquidacionSemana(anio)

        dt = objBU.consultaDeduccionesSemanasNaves(anio)
        Return dt
    End Function


End Class
