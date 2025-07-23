Public Class CalcularPrimaVacacionalBU



    Public Function ExistePrimaVacacionalNave(ByVal idNave As Integer, ByVal Año As Integer) As Boolean
        Dim objDA As New Nomina.Datos.CalcularPrimaVacacionalDA
        Return objDA.ExistePrimaVacacionalNave(idNave, Año)
    End Function

    Public Function ListaPrimaVacacional(ByVal idNave As Integer) As List(Of Entidades.CalcularPrimaVacacional)
        Dim objDA As New Nomina.Datos.CalcularPrimaVacacionalDA
        Dim tabla As New DataTable

        ListaPrimaVacacional = New List(Of Entidades.CalcularPrimaVacacional)
        tabla = objDA.ListaPrimaVacacional(idNave)

        For Each fila As DataRow In tabla.Rows

            Dim primaVacacional As New Entidades.CalcularPrimaVacacional

            primaVacacional.PPrimaVacacionalAnio = CInt(fila("prim_anio"))

            ListaPrimaVacacional.Add(primaVacacional)

        Next
    End Function

    Public Function ListaColaboradoresPrimaVacacional(ByVal idNave As Integer) As List(Of Entidades.CalcularPrimaVacacional)
        Dim objDA As New Nomina.Datos.CalcularPrimaVacacionalDA
        Dim tabla As New DataTable

        ListaColaboradoresPrimaVacacional = New List(Of Entidades.CalcularPrimaVacacional)
        tabla = objDA.ListaColaboradoresPrimaVacacional(idNave)

        For Each fila As DataRow In tabla.Rows
            Dim ColaboradorEnt As New Entidades.Colaborador
            Dim ColaboradorReal As New Entidades.ColaboradorReal
            Dim nominaReal As New Entidades.CalcularNominaReal
            Dim Prima As New Entidades.CalcularPrimaVacacional

            ColaboradorEnt.PColaboradorid = CInt(fila("codr_colaboradorid"))
            ColaboradorEnt.PNombre = CStr(fila("codr_nombre"))
            ColaboradorEnt.PApaterno = CStr(fila("codr_apellidopaterno"))
            ColaboradorEnt.PAmaterno = CStr(fila("codr_apellidomaterno"))

            ColaboradorReal.PCantidad = CDbl(fila("real_cantidad"))
            ColaboradorReal.PFecha = CDate(fila("real_fecha"))

            Prima.PColaborador = ColaboradorEnt
            Prima.PColaboradorReal = ColaboradorReal
            Prima.PTipoSueldo = fila("real_tipo")

            ListaColaboradoresPrimaVacacional.Add(Prima)
        Next

    End Function

    Public Function ListaPrimaGUARDADOS(ByVal idNave As Integer, ByVal anio As Integer, ByVal colaborador2 As String) As List(Of Entidades.CalcularPrimaVacacional)
        Dim objDA As New Nomina.Datos.CalcularPrimaVacacionalDA
        Dim tabla As New DataTable

        ListaPrimaGUARDADOS = New List(Of Entidades.CalcularPrimaVacacional)
        tabla = objDA.ListaPrimaGUARDADOS(idNave, anio, colaborador2)

        For Each fila As DataRow In tabla.Rows

            Dim Prima As New Entidades.CalcularPrimaVacacional
            Dim colaborador As New Entidades.Colaborador
            Dim nominaReal As New Entidades.CalcularNominaReal

            colaborador.PColaboradorid = CInt(fila("prim_colaboradorid"))

            colaborador.PNombre = CStr(fila("codr_nombre"))
            colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))


            Prima.PPrimaVacacionalAnio = CInt(fila("prim_anio"))
            Prima.PPrimaVacacionalMeses = CDbl(fila("prim_meses"))
            Prima.PSueldoDiario = CDbl(fila("prim_sueldodiario"))
            Prima.PDiasxPagar = CDbl(fila("prim_diasxpagar"))
            Prima.PPrimaSubtotal = CDbl(fila("prim_subtotal"))
            Prima.PPrimaPrimaVacacional = CDbl(fila("prim_primavacacional"))
            Prima.PPrimaTotalEntregar = CDbl(fila("prim_totalentregar"))

            Prima.PAntiguedad = CDate(fila("real_fecha"))

            ' [prim_primavacionalid]
            ',[prim_colaboradorid]
            ',[prim_anio]
            ',[prim_meses]
            ',[prim_sueldodiario]
            ',[prim_diasxpagar]
            ',[prim_subtotal]
            ',[prim_primavacacional]
            ',[prim_totalentregar]
            ',[prim_fechacreacion]
            ',[prim_usuariocreoid]

            Prima.PColaborador = colaborador
            Prima.PnominaReal = nominaReal

            ListaPrimaGUARDADOS.Add(Prima)

        Next
    End Function

    Public Function ListaPrimaGUARDADOS2(ByVal idNave As Integer, ByVal anio As Integer, ByVal colaborador2 As String) As DataTable
        Dim objDA As New Nomina.Datos.CalcularPrimaVacacionalDA
        Dim tabla As New DataTable

        tabla = objDA.ListaPrimaGUARDADOS(idNave, anio, colaborador2)

        Return tabla
    End Function

    Public Function ListaDiasvacaciones(ByVal anios As Integer) As List(Of Entidades.CalcularPrimaVacacional)
        Dim objDA As New Nomina.Datos.CalcularPrimaVacacionalDA
        Dim tabla As New DataTable

        ListaDiasvacaciones = New List(Of Entidades.CalcularPrimaVacacional)
        tabla = objDA.ListaDiasVacacionesXAnios(anios)

        For Each fila As DataRow In tabla.Rows

            Dim primaVacacional As New Entidades.CalcularPrimaVacacional

            primaVacacional.PPrimaVacacionalDiasXAños = CInt(fila("fact_diasvacaciones"))

            ListaDiasvacaciones.Add(primaVacacional)

        Next
    End Function

    Public Function ListaDiasvacacionesAniosMeses(ByVal anios As Integer, ByVal meses As Integer) As List(Of Entidades.CalcularPrimaVacacional)
        Dim objDA As New Nomina.Datos.CalcularPrimaVacacionalDA
        Dim tabla As New DataTable

        ListaDiasvacacionesAniosMeses = New List(Of Entidades.CalcularPrimaVacacional)
        tabla = objDA.ListaDiasVacacionesXAniosMeses(anios, meses)

        For Each fila As DataRow In tabla.Rows

            Dim primaVacacional As New Entidades.CalcularPrimaVacacional

            primaVacacional.PPrimaVacacionalDiasXAños = CDbl(fila("diva_diasvacaciones"))

            ListaDiasvacacionesAniosMeses.Add(primaVacacional)

        Next
    End Function

    Public Sub guardarPrimaVacacional(ByVal PrimaVacacional As Entidades.CalcularPrimaVacacional, ByVal naveid As Integer)
        Dim objPrima As New Datos.CalcularPrimaVacacionalDA
        objPrima.guardarPrima(PrimaVacacional, naveid)
    End Sub

    Public Function fechasSueldos(ByVal naveID As Integer, ByVal anio As Integer) As DataTable
        Dim objAguinaldos As New Datos.CalcularPrimaVacacionalDA
        Return objAguinaldos.fechasSueldos(naveID, anio)
    End Function
    Public Function fechasSueldosVacaciones(ByVal naveID As Integer, ByVal anio As Integer) As DataTable
        Dim objAguinaldos As New Datos.CalcularPrimaVacacionalDA
        Return objAguinaldos.fechasSueldosVacaciones(naveID, anio)
    End Function

    Public Function logoNave(ByVal naveID As String) As DataTable
        Dim objBu As New Datos.CalcularPrimaVacacionalDA
        Return objBu.logoNave(naveID)
    End Function

    Public Function obtenerFechaInicioSemanaSanta(ByVal naveID As String, ByVal anio As Integer) As DataTable
        Dim objBu As New Datos.CalcularPrimaVacacionalDA
        Return objBu.obtenerFechaInicioSemanaSanta(naveID, anio)
    End Function

    Public Function obtenerSemanasSueldoVacaciones(ByVal naveID As String, ByVal anio As Integer) As DataTable
        Dim objBu As New Datos.CalcularPrimaVacacionalDA
        Return objBu.obtenerSemanasSueldoVacaciones(naveID, anio)
    End Function

    Public Function obtenerInfoReporteVacaciones(ByVal naveID As String, ByVal anio As Integer) As DataTable
        Dim objBu As New Datos.CalcularPrimaVacacionalDA
        Return objBu.obtenerInfoReporteVacaciones(naveID, anio)
    End Function

    Public Function ListaSalariosColaboradorVacacionesGuardadas(ByVal idColaborador As Integer, ByVal anio As Integer, ByVal naveid As Integer) As List(Of Entidades.CalcularAguinaldos)
        Dim objBu As New Datos.CalcularPrimaVacacionalDA
        Dim tabla As New DataTable

        ListaSalariosColaboradorVacacionesGuardadas = New List(Of Entidades.CalcularAguinaldos)

        tabla = objBu.ListaSalariosColaboradorVacacionesGuardadas(idColaborador, naveid, anio)

        For Each columna As DataColumn In tabla.Columns
            Dim Aguinaldos As New Entidades.CalcularAguinaldos
            Dim salario As String = String.Empty
            salario = tabla.Rows(0)(columna.ColumnName).ToString()
            If salario = "" Then
                salario = "0"
            End If
            Aguinaldos.PSalarioXmes = CDbl(salario)
            ListaSalariosColaboradorVacacionesGuardadas.Add(Aguinaldos)
        Next
        Return ListaSalariosColaboradorVacacionesGuardadas
    End Function

    Public Function obtenerInfoReporteVacacionesCartaFinal(ByVal naveID As String, ByVal anio As Integer) As DataTable
        Dim objBu As New Datos.CalcularPrimaVacacionalDA
        Return objBu.obtenerInfoReporteVacacionesCartaFinal(naveID, anio)
    End Function

    Public Function obtenerInfoFiscalVacaciones(ByVal anio As String, ByVal colaborador As Integer) As Double
        Dim objBu As New Datos.CalcularPrimaVacacionalDA
        Dim tabla As New DataTable()
        Dim ISR As Double = 0.0

        tabla = objBu.obtenerInfoFiscalVacaciones(anio, colaborador)

        If tabla.Rows.Count > 0 Then
            ISR = tabla(0)("vac_ISRRetenido")
        Else
            ISR = 0.0
        End If

        Return ISR
    End Function

End Class
