Imports Nomina.Datos
Imports Entidades
Public Class ConsultarPrestamosBU
    Public Function ListaPagosPRestamo(ByVal IdColaborador As Int32, ByVal idPrestamo As Int32) As List(Of PagosPrestamo)
        Dim ObjDa As New ConsultaPrestamosDA
        Dim Tablas As New DataTable
        ListaPagosPRestamo = New List(Of PagosPrestamo)
        Tablas = ObjDa.ListaPagosPrestamo(IdColaborador, idPrestamo)
        For Each row As DataRow In Tablas.Rows
            Dim Pagos As New PagosPrestamo

            Pagos.PAbonoCapital = CDbl(row("pagop_abonocapital"))
            Pagos.PInteres = CDbl(row("pagop_interes"))
            Pagos.PSaldoAnterior = CDbl(row("pagop_saldoanterior"))
            Pagos.PSaldoNuevo = CDbl(row("pagop_saldonuevo"))
            Pagos.pFechaPago = CDate(row("pnom_FechaFinal"))
            Pagos.PTipoAbono = CStr(row("pagop_dentronomina"))
            Pagos.PIntAbonoExtra = CDbl(row("pagop_interesextra"))
            ListaPagosPRestamo.Add(Pagos)

        Next
        Return ListaPagosPRestamo
    End Function
    Public Function obtenerInteresSobrePrestamo(ByVal idColaborador As Integer, ByVal idPrestamo As Integer) As Double
        Dim ObjDa As New ConsultaPrestamosDA
        Dim Tablas As New DataTable
        Dim Interes As Double
        Tablas = ObjDa.obtenerInteresSobrePrestamos(idColaborador, idPrestamo)
        For Each row As DataRow In Tablas.Rows
            Interes = CDbl(row("pres_interes"))
            Exit For
        Next
        Return Interes
    End Function
    Public Function obtenerTipoInteresSobrePrestamo(ByVal idColaborador As Integer, ByVal idPrestamo As Integer) As String
        Dim ObjDa As New ConsultaPrestamosDA
        Dim Tablas As New DataTable
        Dim Interes As String = "S"
        Tablas = ObjDa.obtenerInteresSobrePrestamos(idColaborador, idPrestamo)
        For Each row As DataRow In Tablas.Rows
            Interes = CStr(row("pres_tipointeresautorizado"))
            Exit For
        Next
        Return Interes
    End Function
    Public Function obtenerPagoSemanaQuincenal(ByVal idColaborador As Integer, ByVal idPrestamo As Integer) As Int32
        Dim ObjDa As New ConsultaPrestamosDA
        Dim Tablas As New DataTable
        Dim pagoSemanaQuincenal As Int32 = 0
        Tablas = ObjDa.obtenerInteresSobrePrestamos(idColaborador, idPrestamo)
        For Each row As DataRow In Tablas.Rows
            pagoSemanaQuincenal = CStr(row("pres_pagosSemanaQuincenal"))
            Exit For
        Next
        Return pagoSemanaQuincenal
    End Function
    Public Function UltimoAbonoMayorCero(ByVal IdColaborador As Int32) As Double
        Dim ObjDa As New ConsultaPrestamosDA
        Dim Tablas As New DataTable
        Dim Abono As Double
        Tablas = ObjDa.ListaPagos(IdColaborador)
        For Each row As DataRow In Tablas.Rows

            Dim AbonoTemporal As Double
            AbonoTemporal = CDbl(row("pagop_abonocapital")) + CDbl(row("pagop_interes"))
            If AbonoTemporal > 0 Then
                Abono = CDbl(row("pagop_abonocapital")) + CDbl(row("pagop_interes"))
            End If
            


        Next
        Return Abono
    End Function

    Public Function Intereses(ByVal IdColaborador As Int32) As InteresesPrestamos
        Dim ObjDa As New ConsultaPrestamosDA
        Dim Tablas As New DataTable

        Dim Pagos As New InteresesPrestamos
        Tablas = ObjDa.CalculoIntereses(IdColaborador)
        For Each row As DataRow In Tablas.Rows

            Pagos.PInteres = CDbl(row("pres_interesautorizado"))
            Pagos.PEstatus = CStr(row("pres_estatus"))
            Pagos.PSemanas = CDbl(row("pres_semanas"))
            Pagos.PtipoInteres = CStr(row("pres_tipointeresautorizado"))
            Pagos.PTotalInteres = CDbl(row("pres_totalintereses"))

        Next
        Return Pagos
    End Function

    Public Function SemanaActiva(ByVal Naveid As Int32) As Int32
        Dim ObjDa As New ConsultaPrestamosDA
        Dim Tablaresultados As New DataTable
        Dim Semana As New Int32
        Tablaresultados = ObjDa.SemenaNominaActiva(Naveid)
        For Each row As DataRow In Tablaresultados.Rows
            Semana = CInt(row("pnom_PeriodoNomId"))
        Next
        Return Semana

    End Function

    Public Function ActualizarInteresPrestamo(ByVal IDColaborador As Int32, ByVal idPrestamo As Integer, ByVal Interes As Double) As DataTable
        Dim objDA As New ConsultaPrestamosDA

        Return objDA.ActualizarInteresPrestamo(IDColaborador, idPrestamo, Interes)

    End Function

    Public Function ImprimirConcentradoAbonosExtraordinarios(ByVal FechaInicio As Date, ByVal FechaFin As Date, NaveID As Integer) As DataTable
        Dim objDa As New ConsultaPrestamosDA
        Return objDa.ImprimirConcentradoAbonosExtraordinarios(FechaInicio, FechaFin, NaveID)
    End Function

    Public Function ImprimirReporteConcentradoPrestamoseIntereses(ByVal NaveID As Integer)
        Dim objDA As New ConsultaPrestamosDA
        Return objDA.ImprimirReporteConcentradoPrestamoseIntereses(NaveID)
    End Function

    Public Function ImprimirReportePrestamosIntereses(ByVal NaveID As Integer, ByVal CajaId As Integer)
        Dim objDA As New ConsultaPrestamosDA
        Return objDA.ImprimirReportePrestamosIntereses(NaveID, CajaId)
    End Function

    Public Function ObtenerNaves() As DataTable
        Dim objDA As New ConsultaPrestamosDA
        Return objDA.ObtenerNaves()
    End Function

    Public Function InsertarConfPrestamosEspeciales(ByVal Concepto As String, ByVal NaveID As Integer, ByVal UsuarioID As Integer, ByVal Accion As Integer, ByVal ConceptoID As Integer, ByVal Activo As Integer, ByVal PorcentajeCC As Integer, ByVal Semanas As Integer)
        Dim objDA As New ConsultaPrestamosDA
        Return objDA.InsertarConfPrestamosEspeciales(Concepto, NaveID, UsuarioID, Accion, ConceptoID, Activo, PorcentajeCC, Semanas)
    End Function

    Public Function MostrarConfiguracionPorNave(ByVal NaveID As Integer, ByVal Activo As Integer) As DataTable
        Dim objDA As New ConsultaPrestamosDA
        Return objDA.MostrarConfiguracionPorNave(NaveID, Activo)
    End Function

    Public Function CargarConfConcepto(ByVal NaveID As Integer) As DataTable
        Dim objDa As New ConsultaPrestamosDA
        Return objDa.CargarConfConcepto(NaveID)
    End Function

    Public Function obtenerSaldosPrestamosExtraordinariosCaja(ByVal idCajaAhorro As Int32, ByVal idNave As Int32) As DataTable
        Dim objDa As New Datos.ConsultaPrestamosDA
        Return objDa.obtenerSaldosPrestamosExtraordinariosCaja(idCajaAhorro, idNave)
    End Function

    Public Function ConsultarAbonosExtraordinarios(ByVal naveId As Int32, ByVal idCajaAhorro As Int32) As DataTable
        Dim objDa As New Datos.ConsultaPrestamosDA
        Return objDa.ConsultarAbonosExtraordinarios(naveId, idCajaAhorro)
    End Function

    Public Function obtenerSaldosCierreCaja(ByVal idCajaAhorro As Int32, ByVal idNave As Int32) As DataTable
        Dim objDa As New Datos.ConsultaPrestamosDA
        Return objDa.obtenerSaldosCierreCaja(idCajaAhorro, idNave)
    End Function


End Class
