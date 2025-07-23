Public Class TicketsBU
    Public Function BuscarTickets(ByVal NoTicket As String) As Entidades.Ticket
        Dim objDA As New Datos.TicketsDA
        Dim TablaResultados As DataTable
        Dim ticket As New Entidades.Ticket

        If NoTicket.ToUpper.StartsWith("N") Then
            TablaResultados = objDA.BuscarTicketSAY(NoTicket)
        Else
            TablaResultados = objDA.BuscarTicket(NoTicket)
        End If

        For Each row As DataRow In TablaResultados.Rows
            ticket.PCantidadPares = CInt(row("Pares"))
            ticket.PCostoPartida = CDbl(row("Costo"))
            ticket.PDescripcion = CStr(row("Descripcion_Fraccion"))
            ticket.PTotal = CDbl(row("Pago"))
            If NoTicket.ToUpper.StartsWith("N") = False Then
                If Not IsDBNull(row("FMovimiento")) Then
                    ticket.PFecha = CDate(row("FMovimiento"))
                End If
            End If
            ticket.pAnio = CInt(row("Año"))
            ticket.pLote = CInt(row("Lote"))
            ticket.pNave = CInt(row("Nave"))
            ticket.PNoTicket = row("Barcode")
        Next
        Return ticket
    End Function

    Public Function SemanaActiva(ByVal Naveid As Int32) As Int32
        Dim ObjDa As New Datos.TicketsDA
        Dim Tablaresultados As New DataTable
        Dim Semana As New Int32
        Tablaresultados = ObjDa.SemenaNominaActiva(Naveid)
        For Each row As DataRow In Tablaresultados.Rows
            Semana = CInt(row("pnom_PeriodoNomId"))
        Next
        Return Semana

    End Function

    Public Sub RegistrarTickets(ByVal registro As Entidades.Ticket, ByVal ColaboradorID As Int32)
        Dim objDA As New Datos.TicketsDA
        Dim TablaExistencia As New DataTable

        objDA.InsertarTickets(registro, ColaboradorID)
    End Sub

    Public Function ExisteRegistro(ByVal NoTicket As String) As Boolean
        Dim ObjDA As New Datos.TicketsDA
        Dim TablaExitencia As New DataTable
        TablaExitencia = ObjDA.VerificarRegistro(NoTicket)
        If TablaExitencia.Rows.Count > 0 Then
            ExisteRegistro = True
        Else
            ExisteRegistro = False
        End If

    End Function
    Public Function obtenerDiasHabilesNave(ByVal nave As Integer) As Integer
        Dim ObjDA As New Datos.TicketsDA
        Dim TablaDiasHabiles As New DataTable
        TablaDiasHabiles = ObjDA.obtenerDiasHabilesNave(nave)
        For Each row As DataRow In TablaDiasHabiles.Rows
            Return CInt(row("conf_diasHabilesTicket"))
        Next
        Return 1
    End Function
    Public Function bDiasHabiles(ByVal lote As Integer, ByVal nave As Integer, ByVal anio As Integer, ByVal top As Integer) As Boolean
        Dim ObjDA As New Datos.TicketsDA
        Dim TablaDiasHabiles As New DataTable
        TablaDiasHabiles = ObjDA.bDiasHabiles(lote, nave, anio, top)
        'TablaDiasHabiles = ObjDA.obtenerDiasHabilesNave(nave)

        If TablaDiasHabiles.Rows.Count > 0 Then
            For Each row As DataRow In TablaDiasHabiles.Rows
                Return CBool(row("resultado"))
            Next
        Else
            bDiasHabiles = False
        End If
      
        Return 0
    End Function
    Public Function bDepartamento(ByVal idDepartamento As Integer, ByVal fraccion As String) As Boolean
        Dim ObjDA As New Datos.TicketsDA
        Dim TablaExitencia As New DataTable
        TablaExitencia = ObjDA.bDepartamento(idDepartamento, fraccion)
        If TablaExitencia.Rows.Count > 0 Then
            bDepartamento = True
        Else
            bDepartamento = False
        End If
    End Function
    Public Function beliminarTicketColaborador(ByVal idTicket As String) As Integer
        Dim ObjDA As New Datos.TicketsDA
        Dim TablaEliminarTicket As New DataTable
        TablaEliminarTicket = ObjDA.eliminarTicketColaborador(idTicket)
        If TablaEliminarTicket.Rows.Count > 0 Then
            For Each row As DataRow In TablaEliminarTicket.Rows
                Return CInt(row("resultado"))
            Next
        Else
            beliminarTicketColaborador = False
        End If

        Return 0
    End Function
    Public Function DevolverNombreRegistro(ByVal NoTicket As String) As Entidades.Colaborador
        Dim ObjDA As New Datos.TicketsDA
        Dim TablaExitencia As New DataTable
        Dim Colaborador As New Entidades.Colaborador
        TablaExitencia = ObjDA.VerificarRegistro(NoTicket)
        For Each row As DataRow In TablaExitencia.Rows

            Colaborador.PAmaterno = CStr(row("codr_apellidomaterno"))
            Colaborador.PApaterno = CStr(row("codr_apellidopaterno"))
            Colaborador.PNombre = CStr(row("codr_nombre"))
            Colaborador.PCalle = CStr(row("pnom_stPeriodoNomina"))
            Colaborador.Pcolonia = CStr(row("dest_fecha"))
            Colaborador.pCurp = CStr(row("pnom_Concepto"))
        Next
        Return Colaborador
    End Function

    Public Function DatosTicket(ByVal NoTicket As String) As Entidades.Ticket
        Dim ObjDA As New Datos.TicketsDA
        Dim TablaExitencia As New DataTable
        Dim Ticket As New Entidades.Ticket
        TablaExitencia = ObjDA.VerificarRegistro(NoTicket)
        For Each row As DataRow In TablaExitencia.Rows

            Ticket.PDescripcion = CStr(row("dest_descripcion"))
            Ticket.PCantidadPares = CStr(row("dest_pares"))
            Ticket.PCostoPartida = CStr(row("dest_costopar"))
            Ticket.PMontoTotal = CStr(row("dest_montoticket"))

        Next
        Return Ticket
    End Function

    Public Function obtenerEstatusPeriodo(ByVal idPeriodo As Integer) As String
        Dim ObjDA As New Datos.TicketsDA
        Dim TablaExitencia As New DataTable
        Dim estatus As String = "C"
        TablaExitencia = ObjDA.obtenerEstatusPeriodo(idPeriodo)
        For Each row As DataRow In TablaExitencia.Rows
            estatus = CStr(row("pnom_stPeriodoNomina"))
        Next
        Return estatus
    End Function



    Public Function ListaTickets(ByVal ColaboradorID As Int32, ByVal PeriodoNomina As Int32) As List(Of Entidades.Ticket)
        Dim objDA As New Datos.TicketsDA
        Dim tblTickets As New DataTable
        ListaTickets = New List(Of Entidades.Ticket)
        tblTickets = objDA.ListaRegistrados(ColaboradorID, PeriodoNomina)
        For Each row As DataRow In tblTickets.Rows
            Dim Ticket As New Entidades.Ticket
            Ticket.PCantidadPares = CInt(row("dest_pares"))
            Ticket.PCostoPartida = CDbl(row("dest_costopar"))
            Ticket.PDescripcion = CStr(row("dest_descripcion"))
            Ticket.PFecha = CDate(row("dest_fecha"))
            Ticket.PNoTicket = CStr(row("dest_codigo"))
            Ticket.PPeriodoNomina = CInt(row("dest_periodonominaid"))
            Ticket.PTotal = CDbl(row("dest_montoticket"))

            Ticket.PIDRegistro = CInt(row("dest_detajoid"))
            ListaTickets.Add(Ticket)

        Next

        Return ListaTickets
    End Function


    Public Function ListaTicketsGeneral(ByVal ColaboradorID As Int32, ByVal PeriodoNomina As Int32, ByVal naveid As Int32) As List(Of Entidades.Ticket)
        Dim objDA As New Datos.TicketsDA
        Dim tblTickets As New DataTable
        ListaTicketsGeneral = New List(Of Entidades.Ticket)
        tblTickets = objDA.ListaRegistradosGeneral(ColaboradorID, PeriodoNomina, naveid)
        For Each row As DataRow In tblTickets.Rows
            Dim Ticket As New Entidades.Ticket
            Ticket.PCantidadPares = CInt(row("dest_pares"))
            Ticket.PCostoPartida = CDbl(row("dest_costopar"))
            Ticket.PDescripcion = CStr(row("dest_descripcion"))
            Ticket.PFecha = CDate(row("dest_fecha"))
            Ticket.PNoTicket = CStr(row("dest_codigo"))
            Ticket.PPeriodoNomina = CInt(row("dest_periodonominaid"))
            Ticket.PTotal = CDbl(row("dest_montoticket"))

            Ticket.PIDRegistro = CInt(row("dest_detajoid"))
            ListaTicketsGeneral.Add(Ticket)

        Next

        Return ListaTicketsGeneral
    End Function


    Public Function ListaTicketsColaborador(ByVal ColaboradorID As Int32, ByVal PeriodoNomina As Int32) As List(Of Entidades.Ticket)
        Dim objDA As New Datos.TicketsDA
        Dim tblTickets As New DataTable
        ListaTicketsColaborador = New List(Of Entidades.Ticket)
        tblTickets = objDA.ListaTicketsDeColaborador(ColaboradorID, PeriodoNomina)
        For Each row As DataRow In tblTickets.Rows
            Dim Ticket As New Entidades.Ticket
            'Ticket.PCantidadPares = CInt(row("dest_pares"))
            'Ticket.PCostoPartida = CDbl(row("dest_costopar"))
            'Ticket.PDescripcion = CStr(row("dest_descripcion"))
            'Ticket.PFecha = CDate(row("dest_fecha"))
            'Ticket.PNoTicket = CStr(row("dest_codigo"))
            'Ticket.PPeriodoNomina = CInt(row("dest_periodonominaid"))
            'Ticket.PTotal = CDbl(row("dest_montoticket"))

            'Ticket.PIDRegistro = CInt(row("dest_detajoid"))
            Ticket.PCantidadPares = CInt(row("dest_pares"))
            Ticket.PCostoPartida = CDbl(row("dest_costopar"))
            Ticket.PDescripcion = CStr(row("dest_descripcion"))
            Ticket.PFecha = CDate(row("dest_fecha"))
            Ticket.PNoTicket = CStr(row("dest_codigo"))
            Ticket.PPeriodoNomina = CInt(row("dest_periodonominaid"))
            Ticket.PTotal = CDbl(row("dest_montoticket"))
            Ticket.PNombreColaborador = CStr(row("Nombre"))
            Ticket.PIDRegistro = CInt(row("dest_detajoid"))
            ListaTicketsColaborador.Add(Ticket)

        Next

        Return ListaTicketsColaborador
    End Function


    Public Sub TranferirTickets(ByVal Colaboradorid As Int32, ByVal NoTicket As String)
        Dim objDa As New Datos.TicketsDA
        objDa.TransferirTicket(Colaboradorid, NoTicket)
    End Sub


    Public Function ListaTotalesColaboradoresTickets(ByVal PeriodoNomina As Int32, ByVal Nombre As String) As List(Of Entidades.Ticket)
        Dim objDA As New Datos.TicketsDA
        Dim tblTickets As New DataTable
        ListaTotalesColaboradoresTickets = New List(Of Entidades.Ticket)
        tblTickets = objDA.ListaTotalesColaboradoresTickets(PeriodoNomina, Nombre)
        For Each row As DataRow In tblTickets.Rows
            Dim Ticket As New Entidades.Ticket
            Dim Colaboradorid As New Entidades.Colaborador
            Colaboradorid.PColaboradorid = CInt(row("codr_colaboradorid"))
            Ticket.PIDColaborador = Colaboradorid
            Ticket.PMontoTotal = CDbl(row("monto"))
            Ticket.PTotalTickets = CInt(row("totalTickets"))
            Ticket.PNombreColaborador = CStr(row("nombre"))
            Try
                Dim Area As New Entidades.Areas
                Area.PNombre = CStr(row("area_nombre"))
                Ticket.PArea = Area
            Catch ex As Exception

            End Try

            Try
                Dim Celula As New Entidades.Celulas
                Celula.PNombre = CStr(row("celu_nombre"))
                Ticket.PCelula = Celula
            Catch ex As Exception

            End Try

            Try
                Dim Departamento As New Entidades.Departamentos
                Departamento.DNombre = CStr(row("grup_name"))
                Ticket.PDepartamento = Departamento
            Catch ex As Exception

            End Try

            ListaTotalesColaboradoresTickets.Add(Ticket)

        Next

        Return ListaTotalesColaboradoresTickets
    End Function

    ''' <summary>
    ''' Consulta tickets agrupados por fracción
    ''' </summary>
    ''' <param name="colaboradorid"></param>
    ''' <param name="periodoid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaTicketsAgrupados(ByVal colaboradorid As Integer, ByVal periodoid As Integer) As DataTable
        Dim ObjDA As New Datos.TicketsDA
        Dim tabla As New DataTable
        tabla = ObjDA.ListaTicketsDeColaboradorAgrupados(colaboradorid, periodoid)
        Return tabla
    End Function

    Public Function ListaTicketsAgrupadosSupervisor(ByVal colaboradorid As Integer, ByVal periodoid As Integer) As DataTable
        Dim objDA As New Datos.TicketsDA
        Dim tabla As New DataTable
        tabla = objDA.ListaTicketsAgrupadosSupervisor(colaboradorid, periodoid)
        Return tabla
    End Function

    Public Function obtenerTicketsColaborador(ByVal ColaboradorId As Integer, ByVal periodoNominal As Integer) As DataTable
        Dim objTktDA As New Datos.TicketsDA
        Return objTktDA.obtenerTicketsColaborador(ColaboradorId, periodoNominal)
    End Function

    Public Function ConsultarTicketsPorNavePeriodo(ByVal PeriodoId As Integer) As DataTable
        Dim objDA As New Datos.TicketsDA
        Return objDA.ConsultarTicketsPorNave(PeriodoId)
    End Function

    Public Function ConsultarTicketsPorColaboradorPeriodo(ByVal Colaborador As Integer, ByVal PeriodoId As Integer) As DataTable
        Dim objDA As New Datos.TicketsDA
        Return objDA.ConsultarTicketsPorColaborador(Colaborador, PeriodoId)
    End Function

End Class
