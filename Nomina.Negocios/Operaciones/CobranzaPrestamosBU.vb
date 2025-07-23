Public Class CobranzaPrestamosBU

    ''INICIA    SEMANA NOMINA ACTIVA
    Public Function SemanaNominaActiva(ByVal idNave As Int32) As List(Of Entidades.CobranzaPrestamos)
        Dim objDA As New Datos.CobranzaPrestamosDA
        Dim tabla As New DataTable
        SemanaNominaActiva = New List(Of Entidades.CobranzaPrestamos)

        tabla = objDA.SemanaNominaActiva(idNave)

        For Each fila As DataRow In tabla.Rows


            Dim CobranzaPrestamos As New Entidades.CobranzaPrestamos

            CobranzaPrestamos.PsemanaNominaId = CInt(fila("pnom_periodoNomId"))
            CobranzaPrestamos.PsemanaNomina = CInt(fila("pnom_NoSemanaNomina"))
            CobranzaPrestamos.PfechaInicioNomina = CDate(fila("pnom_fechainicial"))
            CobranzaPrestamos.PfechaFinNomina = CDate(fila("pnom_fechafinal"))
            CobranzaPrestamos.PPeriodoNominaAsistencia = CStr(fila("pnom_stPeriodoAsistencia"))
            CobranzaPrestamos.PPeriodoNominaCajaAhorro = CStr(fila("pnom_stPeriodoCajaAhorro"))
            CobranzaPrestamos.PPeriodoNominaNomina = CStr(fila("pnom_stPeriodoNomina"))
            CobranzaPrestamos.PPeriodoNominaPrestamos = CStr(fila("pnom_stPrestamos"))
            CobranzaPrestamos.PPeriodoNominaFiscal = CStr(fila("pnom_stPeriodoFiscal"))
            CobranzaPrestamos.PPeriodoNominaDestajos = CStr(fila("pnom_stPeriodoDestajos"))
            CobranzaPrestamos.PConceptoSemana = CStr(fila("pnom_concepto"))
            CobranzaPrestamos.PPeriodoNominaDeducciones = CStr(fila("pnom_stPeriodoDeducciones"))
            CobranzaPrestamos.PNaveIDSICY = CInt(fila("nave_navesicyid"))

            SemanaNominaActiva.Add(CobranzaPrestamos)


        Next
    End Function
    ''TERMINA SEMANA NOMINA ACTIVA
    Public Function FechasSemanaNomina(ByVal IdSemanaNomina As Integer) As List(Of Entidades.CobranzaPrestamos)
        Dim ObjDA As New Datos.CobranzaPrestamosDA
        Dim tabla As New DataTable
        FechasSemanaNomina = New List(Of Entidades.CobranzaPrestamos)
        tabla = ObjDA.FechasSemanaNomina(IdSemanaNomina)

        For Each fila As DataRow In tabla.Rows
            Dim ObjCobranzaPrestamos As New Entidades.CobranzaPrestamos
            ObjCobranzaPrestamos.PfechaInicioNomina = CDate(fila("pnom_fechainicial"))
            ObjCobranzaPrestamos.PfechaFinNomina = CDate(fila("pnom_fechafinal"))
            ObjCobranzaPrestamos.PPeriodoNominaNomina = fila("pnom_stPeriodoNomina")
            ObjCobranzaPrestamos.PPeriodoNominaDestajos = fila("pnom_stPeriodoDestajos")
            ObjCobranzaPrestamos.PPeriodoNominaAsistencia = fila("pnom_stPeriodoAsistencia")
            FechasSemanaNomina.Add(ObjCobranzaPrestamos)
        Next
    End Function


    ''INICIA PRESTAMOS cobrados
    Public Function ListaPrestamosCobrados(ByVal semanaNominaID As Int32) As List(Of Entidades.SolicitudPrestamo)
        Dim objDA As New Datos.CobranzaPrestamosDA
        Dim tabla As New DataTable
        ListaPrestamosCobrados = New List(Of Entidades.SolicitudPrestamo)

        tabla = objDA.ListaPrestamosCobrados(semanaNominaID)

        For Each fila As DataRow In tabla.Rows


            Dim SolicitudPrestamo As New Entidades.SolicitudPrestamo
            Dim Colaborador As New Entidades.Colaborador
            Dim PagoPrestamos As New Entidades.CobranzaPrestamos

            SolicitudPrestamo.Pprestamoid = CInt(fila("pres_prestamoid"))
            SolicitudPrestamo.Psemanas = CInt(fila("pres_semanasautorizadas"))
            SolicitudPrestamo.Psaldo = CDbl(fila("pagop_saldonuevo"))

            PagoPrestamos.PnumPago = CInt(fila("pagop_numeropago"))
            PagoPrestamos.PsaldoAnterior = CDbl(fila("pagop_saldoanterior"))

            Colaborador.PNombre = CStr(fila("codr_nombre"))
            Colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            Colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            Colaborador.PNaveID = CInt(fila("labo_naveid"))

            SolicitudPrestamo.Ptotalinteres = CDbl(fila("pres_totalintereses"))
            SolicitudPrestamo.Pmontoprestamo = CDbl(fila("pres_montoautorizado"))
            SolicitudPrestamo.Pabono = CDbl(fila("pagop_abonocapital"))
            SolicitudPrestamo.Ptipointeres = CStr(fila("pres_tipointeresautorizado"))
            SolicitudPrestamo.Pinteres = CDbl(fila("pagop_interes"))
            SolicitudPrestamo.Pfechamodificacion = CDate(fila("pres_fechamodificacion"))
            SolicitudPrestamo.Pcolaborador = Colaborador
            SolicitudPrestamo.PcobranzaPrestamos = PagoPrestamos

            ListaPrestamosCobrados.Add(SolicitudPrestamo)


        Next
    End Function

    Public Function PrestamosActivos(ByVal idNave As Int32) As List(Of Entidades.SolicitudPrestamo)
        Dim objDA As New Datos.CobranzaPrestamosDA
        Dim tabla As New DataTable
        PrestamosActivos = New List(Of Entidades.SolicitudPrestamo)

        tabla = objDA.PrestamosActivos(idNave)

        For Each fila As DataRow In tabla.Rows


            Dim SolicitudPrestamo As New Entidades.SolicitudPrestamo
            Dim Colaborador As New Entidades.Colaborador
            Dim PagoPrestamos As New Entidades.CobranzaPrestamos

            SolicitudPrestamo.Pprestamoid = CInt(fila("pres_prestamoid"))
            SolicitudPrestamo.Psemanas = CInt(fila("pres_semanasautorizadas"))
            SolicitudPrestamo.Psaldo = CDbl(fila("pagop_saldonuevo"))

            PagoPrestamos.PnumPago = CInt(fila("pagop_numeropago"))
            PagoPrestamos.PsaldoAnterior = CDbl(fila("pagop_saldoanterior"))

            Colaborador.PNombre = CStr(fila("codr_nombre"))
            Colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            Colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))

            SolicitudPrestamo.Ptotalinteres = CDbl(fila("pres_totalintereses"))
            SolicitudPrestamo.Pmontoprestamo = CDbl(fila("pres_montoautorizado"))
            SolicitudPrestamo.Pabono = CDbl(fila("pagop_abonocapital"))
            SolicitudPrestamo.Ptipointeres = CStr(fila("pres_tipointeresautorizado"))
            SolicitudPrestamo.Pinteres = CDbl(fila("pagop_interes"))
            SolicitudPrestamo.Pfechamodificacion = CDate(fila("pres_fechamodificacion"))
            SolicitudPrestamo.Pcolaborador = Colaborador
            SolicitudPrestamo.PcobranzaPrestamos = PagoPrestamos

            PrestamosActivos.Add(SolicitudPrestamo)


        Next
    End Function

    ''TERMINA PRESTAMOS cobrados


    Public Function ListaCobranzaEditar(ByVal semanaNominaID As Int32, ByVal naveId As Integer, ByVal ColaboradorE As String) As List(Of Entidades.SolicitudPrestamo)
        Dim objDA As New Datos.CobranzaPrestamosDA
        Dim tabla As New DataTable
        ListaCobranzaEditar = New List(Of Entidades.SolicitudPrestamo)

        tabla = objDA.ListaCobranzaEditar(semanaNominaID, naveId, ColaboradorE)

        For Each fila As DataRow In tabla.Rows


            Dim SolicitudPrestamo As New Entidades.SolicitudPrestamo
            Dim Colaborador As New Entidades.Colaborador
            Dim PagoPrestamos As New Entidades.CobranzaPrestamos

            SolicitudPrestamo.Pprestamoid = CInt(fila("pres_prestamoid"))
            SolicitudPrestamo.Psemanas = CInt(fila("pres_semanasautorizadas"))
            SolicitudPrestamo.Psaldo = CDbl(fila("pagop_saldonuevo"))

            PagoPrestamos.PnumPago = CInt(fila("pagop_numeropago"))
            PagoPrestamos.PsaldoAnterior = CDbl(fila("pagop_saldoanterior"))
            PagoPrestamos.PPagoId = CInt(fila("pagop_pagoid"))

            Colaborador.PNombre = CStr(fila("codr_nombre"))
            Colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            Colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))


            SolicitudPrestamo.Pmontoprestamo = CDbl(fila("pres_montoautorizado"))
            SolicitudPrestamo.Pabono = CDbl(fila("pagop_abonocapital"))
            SolicitudPrestamo.Ptipointeres = CStr(fila("pres_tipointeresautorizado"))
            SolicitudPrestamo.Pinteres = CDbl(fila("pagop_interes"))


            SolicitudPrestamo.Pcolaborador = Colaborador
            SolicitudPrestamo.PcobranzaPrestamos = PagoPrestamos

            ListaCobranzaEditar.Add(SolicitudPrestamo)


        Next
    End Function


    Public Function ListaCobranzaEditarNegativos(ByVal semanaNominaID As Int32, ByVal naveId As Integer, ByVal colaboradorID As Integer) As List(Of Entidades.SolicitudPrestamo)
        Dim objDA As New Datos.CobranzaPrestamosDA
        Dim tabla As New DataTable
        ListaCobranzaEditarNegativos = New List(Of Entidades.SolicitudPrestamo)

        tabla = objDA.ListaCobranzaEditarNegativos(semanaNominaID, naveId, colaboradorID)

        For Each fila As DataRow In tabla.Rows


            Dim SolicitudPrestamo As New Entidades.SolicitudPrestamo
            Dim Colaborador As New Entidades.Colaborador
            Dim PagoPrestamos As New Entidades.CobranzaPrestamos

            SolicitudPrestamo.Pprestamoid = CInt(fila("pres_prestamoid"))
            SolicitudPrestamo.Psemanas = CInt(fila("pres_semanasautorizadas"))
            SolicitudPrestamo.Psaldo = CDbl(fila("pagop_saldonuevo"))

            PagoPrestamos.PnumPago = CInt(fila("pagop_numeropago"))
            PagoPrestamos.PsaldoAnterior = CDbl(fila("pagop_saldoanterior"))
            PagoPrestamos.PPagoId = CInt(fila("pagop_pagoid"))

            Colaborador.PNombre = CStr(fila("codr_nombre"))
            Colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            Colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))


            SolicitudPrestamo.Pmontoprestamo = CDbl(fila("pres_montoautorizado"))
            SolicitudPrestamo.Pabono = CDbl(fila("pagop_abonocapital"))
            SolicitudPrestamo.Ptipointeres = CStr(fila("pres_tipointeresautorizado"))
            SolicitudPrestamo.Pinteres = CDbl(fila("pagop_interes"))


            SolicitudPrestamo.Pcolaborador = Colaborador
            SolicitudPrestamo.PcobranzaPrestamos = PagoPrestamos

            ListaCobranzaEditarNegativos.Add(SolicitudPrestamo)


        Next
    End Function

    Public Function ListaCobranzaEditarNegativos(ByVal semanaNominaID As Int32, ByVal naveId As Integer, ByVal ColaboradorE As String) As List(Of Entidades.SolicitudPrestamo)
        Dim objDA As New Datos.CobranzaPrestamosDA
        Dim tabla As New DataTable
        ListaCobranzaEditarNegativos = New List(Of Entidades.SolicitudPrestamo)

        tabla = objDA.ListaCobranzaEditar(semanaNominaID, naveId, ColaboradorE)

        For Each fila As DataRow In tabla.Rows


            Dim SolicitudPrestamo As New Entidades.SolicitudPrestamo
            Dim Colaborador As New Entidades.Colaborador
            Dim PagoPrestamos As New Entidades.CobranzaPrestamos

            SolicitudPrestamo.Pprestamoid = CInt(fila("pres_prestamoid"))
            SolicitudPrestamo.Psemanas = CInt(fila("pres_semanasautorizadas"))
            SolicitudPrestamo.Psaldo = CDbl(fila("pagop_saldonuevo"))

            PagoPrestamos.PnumPago = CInt(fila("pagop_numeropago"))
            PagoPrestamos.PsaldoAnterior = CDbl(fila("pagop_saldoanterior"))
            PagoPrestamos.PPagoId = CInt(fila("pagop_pagoid"))

            Colaborador.PNombre = CStr(fila("codr_nombre"))
            Colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            Colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))


            SolicitudPrestamo.Pmontoprestamo = CDbl(fila("pres_montoautorizado"))
            SolicitudPrestamo.Pabono = CDbl(fila("pagop_abonocapital"))
            SolicitudPrestamo.Ptipointeres = CStr(fila("pres_tipointeresautorizado"))
            SolicitudPrestamo.Pinteres = CDbl(fila("pagop_interes"))


            SolicitudPrestamo.Pcolaborador = Colaborador
            SolicitudPrestamo.PcobranzaPrestamos = PagoPrestamos

            ListaCobranzaEditarNegativos.Add(SolicitudPrestamo)


        Next
    End Function

    ''INICIA editar COBRANZA
    Public Sub editarCobranza(ByVal cobranza As Entidades.CobranzaPrestamos)
        Dim objCobranza As New Datos.CobranzaPrestamosDA
        objCobranza.cobranzaEditar(cobranza)
    End Sub
    ''TERMINA editar COBRANZA


    ''INICIA GUARDAR COBRANZA
    Public Sub guardarCobranza(ByVal cobranza As Entidades.CobranzaPrestamos)
        Dim objCobranza As New Datos.CobranzaPrestamosDA
        objCobranza.cobranzaGuardar(cobranza)
    End Sub
    ''TERMINA GUARDAR COBRANZA
    ''abonos extraordinarios
    Public Sub AbonosExtraordinarios(ByVal cobranza As Entidades.CobranzaPrestamos)
        Dim objCobranza As New Datos.CobranzaPrestamosDA
        objCobranza.AbonosExtraordinarios(cobranza)
    End Sub
    Public Sub agregarAbonoExtraoridinario(ByVal idPrestamo As Integer, ByVal idNave As Integer, ByVal abono As Integer, ByVal interes As Integer, ByVal saldo_anterior As Integer, ByVal saldonuevo As Integer)
        Dim objCobranza As New Datos.CobranzaPrestamosDA
        objCobranza.agregarAbonoExtraoridinario(idPrestamo, idNave, abono, interes, saldo_anterior, saldonuevo)
    End Sub
    ''EDITAR ABONO EXTRAORDINARIO TIPO B
    Public Sub EditarAbonosExtraordinarios(ByVal cobranza As Entidades.CobranzaPrestamos)
        Dim objCobranza As New Datos.CobranzaPrestamosDA
        objCobranza.EditarAbonosExtraordinarios(cobranza)
    End Sub

    Public Sub EditarAbonosExtraordinariosFueraNomina(ByVal cobranza As Entidades.CobranzaPrestamos)
        Dim objCobranza As New Datos.CobranzaPrestamosDA
        objCobranza.EditarAbonosExtraordinariosFueraNomina(cobranza)
    End Sub

    Public Function ListaAbonosExtraordinarios(ByVal semanaNominaID As Int32, ByVal naveId As Integer, ByVal Estatus As String, ByVal ColaboradorE As String) As List(Of Entidades.SolicitudPrestamo)
        Dim objDA As New Datos.CobranzaPrestamosDA
        Dim tabla As New DataTable
        ListaAbonosExtraordinarios = New List(Of Entidades.SolicitudPrestamo)

        tabla = objDA.ListaAbonosExtraordinarios(semanaNominaID, naveId, Estatus, ColaboradorE)

        For Each fila As DataRow In tabla.Rows


            Dim SolicitudPrestamo As New Entidades.SolicitudPrestamo
            Dim Colaborador As New Entidades.Colaborador
            Dim PagoPrestamos As New Entidades.CobranzaPrestamos

            SolicitudPrestamo.Pprestamoid = CInt(fila("pres_prestamoid"))
            SolicitudPrestamo.Psemanas = CInt(fila("pres_semanasautorizadas"))
            SolicitudPrestamo.Psaldo = CDbl(fila("pagop_saldonuevo"))

            PagoPrestamos.PnumPago = CInt(fila("pagop_numeropago"))
            PagoPrestamos.PsaldoAnterior = CDbl(fila("pagop_saldoanterior"))
            PagoPrestamos.PPagoId = CInt(fila("pagop_pagoid"))

            Colaborador.PNombre = CStr(fila("codr_nombre"))
            Colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            Colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))


            SolicitudPrestamo.Pmontoprestamo = CDbl(fila("pres_montoautorizado"))
            SolicitudPrestamo.Pabono = CDbl(fila("pagop_abonocapital"))
            SolicitudPrestamo.Ptipointeres = CStr(fila("pres_tipointeresautorizado"))
            SolicitudPrestamo.Pinteres = CDbl(fila("pagop_interes"))


            SolicitudPrestamo.Pcolaborador = Colaborador
            SolicitudPrestamo.PcobranzaPrestamos = PagoPrestamos

            ListaAbonosExtraordinarios.Add(SolicitudPrestamo)
        Next
    End Function


    Public Function ValidarAbonosExtraordinarios(ByVal SemanaNomimaID As Int32, ByVal prestamoID As Int32, ByVal Estatus As String) As List(Of Entidades.CobranzaPrestamos)
        Dim objDA As New Datos.CobranzaPrestamosDA
        Dim tabla As New DataTable
        ValidarAbonosExtraordinarios = New List(Of Entidades.CobranzaPrestamos)

        tabla = objDA.ValidarAbonosExtraordinarios(SemanaNomimaID, prestamoID, Estatus)

        For Each fila As DataRow In tabla.Rows
            Dim PagoPrestamos As New Entidades.CobranzaPrestamos
            PagoPrestamos.PPagoId = CInt(fila("pagop_pagoid"))
            PagoPrestamos.PAbonoCobranza = CDbl(fila("pagop_abonocapital"))
            PagoPrestamos.PInteresCobranza = CDbl(fila("pagop_interes"))
            ValidarAbonosExtraordinarios.Add(PagoPrestamos)
        Next
    End Function

    Public Function validarCierreSemanalEstatusEntregado(ByVal idnave As Int32) As DataTable
        Dim tabla As New DataTable
        Dim objDa As New Datos.CobranzaPrestamosDA
        tabla = objDa.validarCierreSemanalEstatusEntregado(idnave)
        Return tabla
    End Function

    Public Function guardarDatosReporteConcentradoPrestamos(ByVal pmXlCeldas As String) As DataTable
        Dim objDa As New Datos.CobranzaPrestamosDA
        Dim tabla As New DataTable
        tabla = objDa.guardarDatosReporteConcentradoPrestamos(pmXlCeldas)
        Return tabla
    End Function

    Public Function validaPeriodoAnterior(ByVal periodoid As Integer, ByVal naveid As Integer) As Boolean
        Dim objDa As New Datos.CobranzaPrestamosDA
        Dim tabla As New DataTable
        Dim blnResult As Boolean = True
        tabla = objDa.validaPeriodoAnterior(periodoid, naveid)

        If Not tabla Is Nothing Then
            If tabla.Rows.Count > 0 Then
                blnResult = False
            End If
        End If

        Return blnResult 'Si existe el periodo anterior en estatus 'A' regresa false
    End Function

End Class