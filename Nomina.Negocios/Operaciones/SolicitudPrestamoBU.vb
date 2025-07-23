Public Class SolicitudPrestamoBU

    Public Function ListaConfiguracionPrestamos(ByVal IdNave As Int32) As List(Of Entidades.ConfiguracionPrestamos)
        Dim objDA As New Datos.SolicitudPrestamoDA
        Dim tabla As New DataTable
        ListaConfiguracionPrestamos = New List(Of Entidades.ConfiguracionPrestamos)

        tabla = objDA.DatosConfiguracion(IdNave)

        For Each fila As DataRow In tabla.Rows
            Dim configuracionPrestamo As New Entidades.ConfiguracionPrestamos

            configuracionPrestamo.PSemanasMaximo = CInt(fila("cpre_semanasmaximo"))
            configuracionPrestamo.PMontoMaximoPorNave = CDbl(fila("cpre_montomaximonave"))
            configuracionPrestamo.PMontoMaximoPorColaborador = CDbl(fila("cpre_montomaximocolaborador"))
            configuracionPrestamo.PInteres = CDbl(fila("cpre_interes"))
            configuracionPrestamo.PInteresSobreSaldo = CBool(fila("cpre_interessobresaldo"))
            configuracionPrestamo.PInteresFijo = CBool(fila("cpre_interesfijo"))
            configuracionPrestamo.PSinInteres = CBool(fila("cpre_sininteres"))
            configuracionPrestamo.PAutorizacionGerente = CBool(fila("cpre_autorizaciongerente"))
            configuracionPrestamo.PAutorizacionDirector = CBool(fila("cpre_autorizaciondirector"))
            Dim nave As New Entidades.Naves
            nave.PNaveId = CInt(fila("cpre_naveid"))

            configuracionPrestamo.PNaves = nave
            ListaConfiguracionPrestamos.Add(configuracionPrestamo)
        Next
    End Function

    Public Function ValidacionPrestamo(ByVal IdColaborador As Int32) As List(Of Entidades.SolicitudPrestamo)

        Dim objDA As New Datos.SolicitudPrestamoDA
        Dim tabla As New DataTable
        ValidacionPrestamo = New List(Of Entidades.SolicitudPrestamo)

        tabla = objDA.ValidacionPrestamos(IdColaborador)

        For Each fila As DataRow In tabla.Rows
            Dim Prestamo As New Entidades.SolicitudPrestamo

            Prestamo.Pprestamoid = CInt(fila("pres_prestamoid"))
            Dim colaborador As New Entidades.Colaborador
            colaborador.PColaboradorid = CInt(fila("pres_colaboradorid"))
            Prestamo.Pcolaborador = colaborador
            ValidacionPrestamo.Add(Prestamo)
        Next

    End Function

    Public Sub guardarPrestamos(ByVal prestamo As Entidades.SolicitudPrestamo)
        Dim objPrestamo As New Datos.SolicitudPrestamoDA
        objPrestamo.PrestamoGuardar(prestamo)
    End Sub

    Public Sub guardarPrestamosEspeciales(ByVal prestamo As Entidades.SolicitudPrestamo, ByVal PrestamoEspecial As Integer, ByVal pagoSemanaQuincenal As Integer)
        Dim objPrestamo As New Datos.SolicitudPrestamoDA
        objPrestamo.PrestamoGuardarPrestamoEspecial(prestamo, PrestamoEspecial, pagoSemanaQuincenal)
    End Sub

    Public Sub ActualizarPrestamo(ByVal prestamo As Entidades.SolicitudPrestamo)
        Dim objPrestamo As New Datos.SolicitudPrestamoDA
        objPrestamo.PrestamoActualizar(prestamo)
    End Sub

    Public Sub guardarIdSolicitudPrestamos(ByVal prestamo As Entidades.SolicitudPrestamo)
        Dim objPrestamo As New Datos.SolicitudPrestamoDA
        objPrestamo.guardarSolicitudPrestamoID(prestamo)
    End Sub

    ''INICIA AUTORIZACION PRESTAMOS BU
    Public Function NavesColaborador(ByRef idColaborador As Integer) As DataTable
        Dim objDA As New Datos.SolicitudPrestamoDA
        Return objDA.NavesColaborador(idColaborador)
    End Function

    Public Function NavesColaboradores(ByRef idColaborador As Integer) As DataTable
        Dim objDA As New Datos.SolicitudPrestamoDA
        Return objDA.NavesColaboradores(idColaborador)
    End Function


    Public Function ListaPrestamos(ByVal IdNave As Int32) As List(Of Entidades.SolicitudPrestamo)
        Dim objDA As New Datos.SolicitudPrestamoDA
        Dim tabla As New DataTable
        ListaPrestamos = New List(Of Entidades.SolicitudPrestamo)
        tabla = objDA.ListaPrestamos(IdNave)

        For Each fila As DataRow In tabla.Rows

            Dim colaborador As New Entidades.Colaborador
            Dim objSolicitud As New Entidades.SolicitudPrestamo


            If IsDBNull(fila("pres_solicitudfinanzasid")) Then
                objSolicitud.Pprestamoid = CInt(fila("pres_prestamoid"))
                objSolicitud.Psaldo = CDbl(fila("pres_montoautorizado"))
                objSolicitud.Psemanas = CInt(fila("pres_semanasautorizadas"))
                objSolicitud.Ptipointeres = CStr(fila("pres_tipointeresautorizado"))
                objSolicitud.Pinteres = CStr(fila("pres_interesautorizado"))
                objSolicitud.Pabono = CDbl(fila("pres_abonoautorizado"))
                objSolicitud.Pestatus = CStr(fila("pres_estatus"))
                objSolicitud.Pjustificacion = CStr(fila("pres_justificacion"))

                If IsDBNull(fila("pres_fechaaprobaciondirector")) Then
                Else
                    objSolicitud.PfechaDirector = CDate(fila("pres_fechaaprobaciondirector"))

                End If

                If IsDBNull(fila("pres_fechaaprobaciongerente")) Then
                Else
                    objSolicitud.PfechaGerente = CDate(fila("pres_fechaaprobaciongerente"))

                End If

                If IsDBNull(fila("pres_fechamodificacion")) Then
                Else
                    objSolicitud.Pfechamodificacion = CDate(fila("pres_fechamodificacion"))

                End If


                colaborador.PNombre = CStr(fila("codr_nombre"))
                colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
                colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
                colaborador.PColaboradorid = CInt(fila("pres_colaboradorid"))
                objSolicitud.Pcolaborador = colaborador
                ListaPrestamos.Add(objSolicitud)
            Else
                objSolicitud.Psolicitudid = CInt(fila("pres_solicitudfinanzasid"))
                objSolicitud.Pprestamoid = CInt(fila("pres_prestamoid"))
                objSolicitud.Psaldo = CDbl(fila("pres_saldo"))
                objSolicitud.Pmontoprestamo = CDbl(fila("pres_montoautorizado"))
                objSolicitud.Psemanas = CInt(fila("pres_semanasautorizadas"))
                objSolicitud.Ptipointeres = CStr(fila("pres_tipointeresautorizado"))
                objSolicitud.Pinteres = CStr(fila("pres_interesautorizado"))
                objSolicitud.Pabono = CDbl(fila("pres_abonoautorizado"))
                objSolicitud.Pestatus = CStr(fila("pres_estatus"))
                objSolicitud.Pjustificacion = CStr(fila("pres_justificacion"))


                If IsDBNull(fila("pres_fechaaprobaciondirector")) Then
                Else
                    objSolicitud.PfechaDirector = CDate(fila("pres_fechaaprobaciondirector"))

                End If

                If IsDBNull(fila("pres_fechaaprobaciongerente")) Then
                Else
                    objSolicitud.PfechaGerente = CDate(fila("pres_fechaaprobaciongerente"))

                End If

                If IsDBNull(fila("pres_fechamodificacion")) Then
                Else
                    objSolicitud.Pfechamodificacion = CDate(fila("pres_fechamodificacion"))

                End If


                colaborador.PNombre = CStr(fila("codr_nombre"))
                colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
                colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
                colaborador.PColaboradorid = CInt(fila("pres_colaboradorid"))
                objSolicitud.Pcolaborador = colaborador

                ListaPrestamos.Add(objSolicitud)
            End If
        Next
    End Function

    Public Sub guardarAutorizacionPrestamosGerente(ByVal prestamo As Entidades.SolicitudPrestamo)
        Dim objPrestamo As New Datos.SolicitudPrestamoDA
        objPrestamo.AutorizacionGerenteGuardar(prestamo)
    End Sub
    Public Sub guardarEntregaDePrestamo(ByVal prestamo As Entidades.SolicitudPrestamo, ByVal fechas As Date)
        Dim objPrestamo As New Datos.SolicitudPrestamoDA
        objPrestamo.guardarEntregaDePrestamo(prestamo, fechas)
    End Sub

    Public Sub guardarAutorizacionPrestamosDirector(ByVal prestamo As Entidades.SolicitudPrestamo)
        Dim objPrestamo As New Datos.SolicitudPrestamoDA
        objPrestamo.AutorizacionDirectorGuardar(prestamo)
    End Sub

    ''TERMINA AUTORIZACION PRESTAMOS BU

    ''INICIA CANCELAR PRESTAMOS BU

    Public Function ListaPrestamosCancelar(ByVal idNave As Int32) As List(Of Entidades.SolicitudPrestamo)
        Dim objDA As New Datos.SolicitudPrestamoDA
        Dim tabla As New DataTable
        ListaPrestamosCancelar = New List(Of Entidades.SolicitudPrestamo)

        tabla = objDA.ListaPrestamosCancelar(idNave)

        For Each fila As DataRow In tabla.Rows


            Dim SolicitudPrestamo As New Entidades.SolicitudPrestamo
            Dim Colaborador As New Entidades.Colaborador

            SolicitudPrestamo.Pprestamoid = CInt(fila("pres_prestamoid"))
            SolicitudPrestamo.Psaldo = CDbl(fila("pres_montoautorizado"))
            SolicitudPrestamo.Ptipointeres = CStr(fila("pres_tipointeresautorizado"))
            SolicitudPrestamo.Pinteres = CStr(fila("pres_interesautorizado"))
            SolicitudPrestamo.Pabono = CDbl(fila("pres_abonoautorizado"))
            SolicitudPrestamo.Pestatus = CStr(fila("pres_estatus"))
            SolicitudPrestamo.Psemanas = CStr(fila("pres_semanasautorizadas"))

            Colaborador.PNombre = CStr(fila("codr_nombre"))
            Colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            Colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))

            SolicitudPrestamo.Pcolaborador = Colaborador


            ListaPrestamosCancelar.Add(SolicitudPrestamo)


        Next
    End Function



    Public Sub guardarCancelarPrestamos(ByVal prestamo As Entidades.SolicitudPrestamo)

        Dim objPrestamo As New Datos.SolicitudPrestamoDA
        objPrestamo.PrestamoCancelarGuardar(prestamo)
    End Sub



    ''TERMINA CANCELAR PRESTAMOS BU

    ''inicia prestamo dinero confirmacion recibido en la nave
    Public Sub confirmacionPrestamoEnNave(ByVal prestamo As Entidades.SolicitudPrestamo)

        Dim objPrestamo As New Datos.SolicitudPrestamoDA
        objPrestamo.confirmacionPrestamoRecibidoNave(prestamo)
    End Sub
    ''termina prestamo dinero confirmacion recibido en la nave


    ''INICIA FILTRO DE PRESTAMOS
    Public Function ListaPrestamosfiltro(ByVal IdNave As Int32, ByVal estatus As String, ByVal FechaInicio As String, ByVal FechaFin As String, ByVal tipo As Integer) As List(Of Entidades.SolicitudPrestamo)


        Dim objDA As New Datos.SolicitudPrestamoDA
        Dim tabla As New DataTable
        ListaPrestamosfiltro = New List(Of Entidades.SolicitudPrestamo)
        tabla = objDA.ListaPrestamosFiltro(IdNave, estatus, FechaInicio, FechaFin, tipo)

        For Each fila As DataRow In tabla.Rows
            Dim estatusC As String = CStr(fila("pres_estatus"))
            Dim colaborador As New Entidades.Colaborador
            Dim objSolicitud As New Entidades.SolicitudPrestamo


            objSolicitud.Pprestamoid = CInt(fila("pres_prestamoid"))

            '  If estatusC.Equals("A") Or estatusC.Equals("I") Or estatusC.Equals("J") Or estatusC.Equals("K") Then
            If estatusC.Equals("I") Or estatusC.Equals("J") Or estatusC.Equals("K") Then
                objSolicitud.Pmontoprestamo = CDbl(fila("pres_montoprestamo"))
            Else
                objSolicitud.Pmontoprestamo = CDbl(fila("pres_montoautorizado"))
            End If

            objSolicitud.Psemanas = CInt(fila("pres_semanasautorizadas"))
            objSolicitud.Ptipointeres = CStr(fila("pres_tipointeresautorizado"))
            objSolicitud.Pinteres = CStr(fila("pres_interesautorizado"))
            objSolicitud.Pabono = CDbl(fila("pres_abonoautorizado"))
            objSolicitud.Pestatus = CStr(fila("pres_estatus"))
            objSolicitud.Psaldo = CDbl(fila("pres_saldo"))
            objSolicitud.PfechaCreacion = CDate(fila("pres_fechaSolicitud"))
            If IsDBNull(fila("pres_fechaentrega")) Then
                objSolicitud.PfechaEntrega = Nothing
            Else
                '  objSolicitud.PfechaEntrega = CDate(fila("pres_fechaentrega"))
                objSolicitud.PfechaEntrega = fila("fechaEntrega")
            End If

            If IsDBNull(fila("pres_fechaaprobaciondirector")) Then

            Else
                objSolicitud.PfechaDirector = CDate(fila("pres_fechaaprobaciondirector"))

            End If

            If IsDBNull(fila("pres_fechaaprobaciongerente")) Then

            Else
                objSolicitud.PfechaGerente = CDate(fila("pres_fechaaprobaciongerente"))

            End If

            If IsDBNull(fila("pres_fechamodificacion")) Then

            Else
                objSolicitud.Pfechamodificacion = CDate(fila("pres_fechamodificacion"))

            End If

            colaborador.PNombre = CStr(fila("codr_nombre"))
            colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            colaborador.PColaboradorid = CInt(fila("pres_colaboradorid"))
            objSolicitud.Pcolaborador = colaborador
            ListaPrestamosfiltro.Add(objSolicitud)

        Next
    End Function

    ''TERMINA FILTRO DE PRESTAMOS

    ''INICIA PRESTAMOS COBRAR
    Public Function ListaPrestamosCobrar(ByVal idNave As Int32) As List(Of Entidades.SolicitudPrestamo)
        Dim objDA As New Datos.SolicitudPrestamoDA
        Dim tabla As New DataTable
        ListaPrestamosCobrar = New List(Of Entidades.SolicitudPrestamo)

        tabla = objDA.ListaPrestamosCobrar(idNave)

        For Each fila As DataRow In tabla.Rows


            Dim SolicitudPrestamo As New Entidades.SolicitudPrestamo
            Dim Colaborador As New Entidades.Colaborador
            Dim PagoPrestamos As New Entidades.CobranzaPrestamos

            SolicitudPrestamo.Pprestamoid = CInt(fila("pres_prestamoid"))
            SolicitudPrestamo.Psemanas = CInt(fila("pres_semanasautorizadas"))
            SolicitudPrestamo.Psaldo = CDbl(fila("pres_saldo"))

            PagoPrestamos.PnumPago = CInt(fila("numPago"))
            '' PagoPrestamos.PsaldoAnterior = CDbl(fila("pagop_saldoanterior"))

            Colaborador.PNombre = CStr(fila("codr_nombre"))
            Colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            Colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            Colaborador.PColaboradorid = CInt(fila("codr_colaboradorid"))
            Colaborador.PNaveID = CInt(fila("labo_naveid"))

            SolicitudPrestamo.Ptotalinteres = CDbl(fila("pres_totalintereses"))
            SolicitudPrestamo.Pmontoprestamo = CDbl(fila("pres_montoautorizado"))
            SolicitudPrestamo.Pabono = CDbl(fila("pres_abonoautorizado"))
            SolicitudPrestamo.Ptipointeres = CStr(fila("pres_tipointeresautorizado"))
            SolicitudPrestamo.Pinteres = CDbl(fila("pres_interesautorizado"))
            SolicitudPrestamo.Pfechamodificacion = CDate(fila("pres_fechamodificacion"))
            SolicitudPrestamo.PfechaCreacion = CDate(fila("pres_fechasolicitud"))
            SolicitudPrestamo.Pestatus = CStr(fila("pres_estatus"))
            SolicitudPrestamo.Pcolaborador = Colaborador
            SolicitudPrestamo.PcobranzaPrestamos = PagoPrestamos

            ListaPrestamosCobrar.Add(SolicitudPrestamo)


        Next
    End Function
    ''TERMINA PRESTAMOS COBRAR
    Public Function FechasPeriodoNomina(ByVal idPeriodo As Integer) As List(Of Entidades.SolicitudPrestamo)

        Dim objDA As New Datos.SolicitudPrestamoDA

        Dim tabla As New DataTable
        FechasPeriodoNomina = New List(Of Entidades.SolicitudPrestamo)

        tabla = objDA.FechasPeriodoNomina(idPeriodo)

        For Each fila As DataRow In tabla.Rows
            Dim periodoNomina As New Entidades.PeriodosNomina
            Dim solicitudPrestamos As New Entidades.SolicitudPrestamo
            periodoNomina.PFechaInicio = CDate(fila("pnom_FechaInicial"))
            periodoNomina.PFechaFin = CDate(fila("pnom_FechaFinal"))
            solicitudPrestamos.PPeriodoNomina = periodoNomina

            FechasPeriodoNomina.Add(solicitudPrestamos)
        Next

    End Function
    Public Function CajaDeAhorro(ByVal idNave As Integer) As List(Of Entidades.SolicitudPrestamo)
        Dim objDA As New Datos.SolicitudPrestamoDA
        Dim tabla As New DataTable
        CajaDeAhorro = New List(Of Entidades.SolicitudPrestamo)
        tabla = objDA.CajaDeAhorro(idNave)

        For Each fila As DataRow In tabla.Rows
            Dim objCaja As New Entidades.CajaAhorro
            Dim prestamos As New Entidades.SolicitudPrestamo

            objCaja.pCajaAhorroId = (fila("caja_CajaAhorroId"))
            prestamos.PCajaAhorro = objCaja
            CajaDeAhorro.Add(prestamos)
        Next

    End Function


    Public Function CajaDeAhorroMonto(ByVal idColaborador As Integer, ByVal idCaja As Integer) As List(Of Entidades.SolicitudPrestamo)
        Dim objDA As New Datos.SolicitudPrestamoDA
        Dim tabla As New DataTable
        CajaDeAhorroMonto = New List(Of Entidades.SolicitudPrestamo)
        tabla = objDA.CajaDeAhorroMonto(idColaborador, idCaja)

        For Each fila As DataRow In tabla.Rows
            Dim objCaja As New Entidades.CajaAhorro
            Dim prestamos As New Entidades.SolicitudPrestamo

            objCaja.pMontoAhorro = (fila("ccpc_MontoAhorro"))
            prestamos.PCajaAhorro = objCaja
            CajaDeAhorroMonto.Add(prestamos)
        Next

    End Function

    Public Function ConcentradoPrestamos(ByVal idNave As Integer, ByVal fechaInicial As DateTime, ByVal fechaFinal As DateTime) As List(Of Entidades.SolicitudPrestamo)
        Dim objDA As New Datos.SolicitudPrestamoDA
        Dim tabla As New DataTable
        ConcentradoPrestamos = New List(Of Entidades.SolicitudPrestamo)
        tabla = objDA.ConcentradoPrestamos(idNave, fechaInicial, fechaFinal)


        For Each fila As DataRow In tabla.Rows
            Dim estatusC As String = CStr(fila("pres_estatus"))
            Dim colaborador As New Entidades.Colaborador
            Dim objSolicitud As New Entidades.SolicitudPrestamo


            objSolicitud.Pprestamoid = CInt(fila("pres_prestamoid"))

            If estatusC.Equals("A") Or estatusC.Equals("I") Or estatusC.Equals("J") Or estatusC.Equals("K") Then
                objSolicitud.Pmontoprestamo = CDbl(fila("pres_montoprestamo"))
            Else
                objSolicitud.Pmontoprestamo = CDbl(fila("pres_montoautorizado"))
            End If

            objSolicitud.Psemanas = CInt(fila("pres_semanasautorizadas"))
            objSolicitud.Ptipointeres = CStr(fila("pres_tipointeresautorizado"))
            objSolicitud.Pinteres = CStr(fila("pres_interesautorizado"))
            objSolicitud.Pabono = CDbl(fila("pres_abonoautorizado"))
            objSolicitud.Pestatus = CStr(fila("pres_estatus"))
            objSolicitud.Psaldo = CDbl(fila("pres_saldo"))
            objSolicitud.PfechaCreacion = CDate(fila("pres_fechaSolicitud"))


            If IsDBNull(fila("pres_fechaaprobaciondirector")) Then

            Else
                objSolicitud.PfechaDirector = CDate(fila("pres_fechaaprobaciondirector"))

            End If

            If IsDBNull(fila("pres_fechaaprobaciongerente")) Then

            Else
                objSolicitud.PfechaGerente = CDate(fila("pres_fechaaprobaciongerente"))

            End If

            If IsDBNull(fila("pres_fechamodificacion")) Then

            Else
                objSolicitud.Pfechamodificacion = CDate(fila("pres_fechamodificacion"))

            End If

            colaborador.PNombre = CStr(fila("codr_nombre"))
            colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            colaborador.PColaboradorid = CInt(fila("pres_colaboradorid"))
            objSolicitud.Pcolaborador = colaborador

            ConcentradoPrestamos.Add(objSolicitud)
        Next

    End Function


    Public Function TotalFaltasMes(ByVal Colaboradorid As Int32) As Int32
        Dim objDA As New Datos.SolicitudPrestamoDA
        Dim tabla As New DataTable
        tabla = objDA.ListaFaltasMes(Colaboradorid)
        Dim Faltas As New Int32
        For Each row As DataRow In tabla.Rows
            Try
                Faltas += (row("ccheck_inasistencia"))
            Catch ex As Exception

            End Try

        Next
        Return Faltas
    End Function
    Public Function ListaPreSolicitudesPrestamos(ByVal idNave As Int32, ByVal Estatus As String) As List(Of Entidades.SolicitudPrestamo)
        Dim objDA As New Datos.SolicitudPrestamoDA
        Dim tabla As New DataTable
        ListaPreSolicitudesPrestamos = New List(Of Entidades.SolicitudPrestamo)

        tabla = objDA.ListaPreSolicitudesPrestamos(idNave, Estatus)

        For Each fila As DataRow In tabla.Rows


            Dim SolicitudPrestamo As New Entidades.SolicitudPrestamo
            Dim Colaborador As New Entidades.Colaborador

            SolicitudPrestamo.Pprestamoid = CInt(fila("pres_prestamoid"))
            SolicitudPrestamo.Psaldo = CDbl(fila("pres_montoautorizado"))
            SolicitudPrestamo.Ptipointeres = CStr(fila("pres_tipointeresautorizado"))
            SolicitudPrestamo.Pinteres = CStr(fila("pres_interesautorizado"))
            SolicitudPrestamo.Pabono = CDbl(fila("pres_abonoautorizado"))
            SolicitudPrestamo.Pestatus = CStr(fila("pres_estatus"))
            SolicitudPrestamo.Psemanas = CStr(fila("pres_semanasautorizadas"))
            SolicitudPrestamo.Pjustificacion = fila("pres_justificacion")
            Colaborador.PNombre = CStr(fila("codr_nombre")) + " " + CStr(fila("codr_apellidopaterno")) + " " + CStr(fila("codr_apellidomaterno"))
            Colaborador.PColaboradorid = fila("codr_colaboradorid")
            SolicitudPrestamo.Pcolaborador = Colaborador
            ListaPreSolicitudesPrestamos.Add(SolicitudPrestamo)
        Next
    End Function

    Public Function FechasCajaAhorro(ByVal NaveID As Integer) As List(Of Entidades.SolicitudPrestamo)
        Dim ObjDA As New Datos.SolicitudPrestamoDA
        Dim Tabla As New DataTable
        FechasCajaAhorro = New List(Of Entidades.SolicitudPrestamo)
        Tabla = ObjDA.FechasCajaAhorro(NaveID)
        For Each fila As DataRow In Tabla.Rows
            Dim Entidades As New Entidades.SolicitudPrestamo
            Entidades.PFechaFinCaja = fila("caja_FechaFinal")
            FechasCajaAhorro.Add(Entidades)
        Next


    End Function

    Public Function editarPrestamo(ByVal prestamoID As Integer, ByVal colaboradorID As Integer) As DataTable
        Dim objDA As New Datos.SolicitudPrestamoDA
        Dim tabla As New DataTable
        tabla = objDA.editarPrestamo(prestamoID, colaboradorID)
        Return tabla
    End Function
    Public Function obtenerPeriodoCaja(ByVal fecha As String, ByVal naveid As String) As String
        Dim ObjDA As New Datos.SolicitudPrestamoDA
        Dim Tabla As New DataTable
        Dim periodo As String = ""
        Tabla = ObjDA.obtnerPeriodoCaja(fecha, naveid)
        For Each fila As DataRow In Tabla.Rows
            periodo = CStr(fila("pnom_NoSemanaCajaAhorro"))
            Exit For
        Next
        Return periodo
    End Function

    Public Function obtenerMontoAhorro(ByVal idColaborador As Int32, idCajaAhorro As Int32) As DataTable
        Dim tabla As New DataTable
        Dim objDa As New Datos.SolicitudPrestamoDA
        tabla = objDa.obtenerMontoAhorro(idColaborador, idCajaAhorro)
        Return tabla
    End Function

    Public Function mostraDatosPrestamo(ByVal idNave As Integer, ByVal estatus As String, ByVal fechaI As String, ByVal fechaf As String, ByVal tipo As Integer) As DataTable
        Dim objDa As New Datos.SolicitudPrestamoDA
        Dim tabla As New DataTable
        tabla = objDa.mostraDatosPrestamo(idNave, estatus, fechaI, fechaf, tipo)
        Return tabla
    End Function

    Public Sub CambiarEstatusDineroDevuelto(ByVal idPrestamo As Int32, ByVal estatus As String, ByVal usuario As String)
        Dim objDa As New Datos.SolicitudPrestamoDA
        objDa.CambiarEstatusDineroDevuelto(idPrestamo, estatus, usuario)
    End Sub

    Public Function ValidarPerfilUsuarioFinazas(ByVal UsuarioId As Integer)
        Dim objDa As New Datos.SolicitudPrestamoDA
        Dim tabla As New DataTable

        tabla = objDa.ValidarPerfilUsuarioFinazas(UsuarioId)
        Return tabla
    End Function

    Public Function llenarTablaPrestaciones(ByVal idNave As Integer, ByVal idArea As Integer, ByVal idDepartamento As Integer, ByVal Colaborador As String) As DataTable
        Dim objDA As New Datos.SolicitudPrestamoDA
        Return objDA.llenarTablaPrestaciones(idNave, idArea, idDepartamento, Colaborador)

    End Function

    Public Function ObtenerConceptosPrestaciones(ByVal NaveID As Integer, ByVal Accion As Integer, ByVal Concepto As Integer) As DataTable
        Dim objDA As New Datos.SolicitudPrestamoDA
        Return objDA.ObtenerConceptosPrestaciones(NaveID, Accion, Concepto)
    End Function

    Public Function GuardarPrestacionesSAY(ByVal pmXlCeldas As String) As DataTable
        Dim objDa As New Datos.SolicitudPrestamoDA
        Return objDa.GuardarPrestacionesSAY(pmXlCeldas)
    End Function

    Public Function ObtieneInformacionPrestacionesCajaChica(ByVal pmXlCeldas As String) As DataTable
        Dim objDa As New Datos.SolicitudPrestamoDA
        Return objDa.ObtieneInformacionPrestacionesCajaChica(pmXlCeldas)
    End Function

    Public Function EnviarSolicitudesPrestacionesCaja(ByVal IdCaja As Int32, ByVal FormaPago As String, ByVal Cantidad As Double, ByVal Beneficiacio As String,
                                 ByVal Observaciones As String, ByVal ReposicionCajaChica As Integer) As DataTable
        Dim objDa As New Datos.SolicitudPrestamoDA
        Return objDa.EnviarSolicitudesPrestacionesCaja(IdCaja, FormaPago, Cantidad, Beneficiacio, Observaciones, ReposicionCajaChica)
    End Function

    Public Function guardarSolicitudPrestacionID(ByVal pmXlCeldas As String) As DataTable
        Dim objDa As New Datos.SolicitudPrestamoDA
        Return objDa.guardarSolicitudPrestacionID(pmXlCeldas)
    End Function

End Class
