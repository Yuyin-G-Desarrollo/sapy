Public Class DeduccionesBU

    Public Function ListaColaboradoresDeduccion(ByVal IdNave As Integer, ByVal idArea As Integer, ByVal idDepartamento As Integer, ByVal ColaboradorN As String) As List(Of Entidades.Deducciones)


        Dim objDA As New Datos.DeduccionesDA
        Dim tabla As New DataTable
        ListaColaboradoresDeduccion = New List(Of Entidades.Deducciones)
        tabla = objDA.ListaColaboradoresDeducciones(IdNave, idArea, idDepartamento, ColaboradorN)

        For Each fila As DataRow In tabla.Rows

            Dim colaborador As New Entidades.Colaborador
            Dim Deducciones As New Entidades.Deducciones

            colaborador.PNombre = CStr(fila("codr_nombre"))
            colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            colaborador.PColaboradorid = CInt(fila("codr_colaboradorid"))

            Deducciones.PDepartamento = CStr(fila("grup_name"))
            Deducciones.PPuesto = CStr(fila("pues_nombre"))

            Deducciones.PColaborador = colaborador

            ListaColaboradoresDeduccion.Add(Deducciones)

        Next
    End Function


    Public Function ListaDeduccion(ByVal IdNave As Integer, ByVal idArea As Integer, ByVal idDepartamento As Integer, ByVal ColaboradorN As String) As List(Of Entidades.Deducciones)


        Dim objDA As New Datos.DeduccionesDA
        Dim tabla As New DataTable
        ListaDeduccion = New List(Of Entidades.Deducciones)
        tabla = objDA.ListaDeducciones(IdNave, idArea, idDepartamento, ColaboradorN)

        For Each fila As DataRow In tabla.Rows

            Dim colaborador As New Entidades.Colaborador
            Dim Deducciones As New Entidades.Deducciones

            colaborador.PNombre = CStr(fila("codr_nombre"))
            colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            colaborador.PColaboradorid = CInt(fila("codr_colaboradorid"))

            Deducciones.PDepartamento = CStr(fila("grup_name"))
            Deducciones.PPuesto = CStr(fila("pues_nombre"))
            Deducciones.PidDeduccion = CInt(fila("decx_deduccionid"))
            Deducciones.PConceptoDeduccion = CStr(fila("decx_concepto"))
            Deducciones.PMontoDeduccion = CStr(fila("decx_monto"))
            Deducciones.PnumeroSemanas = CInt(fila("decx_numerosemanas"))
            Deducciones.Pabono = CDbl(fila("decx_abono"))
            Deducciones.PFechaCreacion = CDate(fila("decx_fechacreacion"))

            Try
                Deducciones.PNumeroPago = CInt(fila("numPago"))
            Catch ex As Exception
                Deducciones.PNumeroPago = 0
            End Try


            Deducciones.PColaborador = colaborador

            ListaDeduccion.Add(Deducciones)

        Next
    End Function

    Public Sub guardarDeduccionesExtraordinaria(ByVal deducciones As Entidades.Deducciones)
        Dim objDeducciones As New Datos.DeduccionesDA
        objDeducciones.GuardarDeduccionesExtraordinarias(deducciones)
    End Sub

    Public Sub guardarDeducciones(ByVal deducciones As Entidades.Deducciones)
        Dim objDeducciones As New Datos.DeduccionesDA
        objDeducciones.GuardarDeducciones(deducciones)
    End Sub

    Public Sub EliminarDeducciones(ByVal deducciones As Entidades.Deducciones)
        Dim objDeducciones As New Datos.DeduccionesDA
        objDeducciones.GuardarEliminarDeducciones(deducciones)
    End Sub

    Public Sub GuardarPagoDeduccionesExtraordinarias(ByVal deducciones As Entidades.Deducciones)
        Dim objDeducciones As New Datos.DeduccionesDA
        objDeducciones.GuardarPagoDeduccionesExtraordinarias(deducciones)
    End Sub


    Public Sub GuardaEdicionDeduccion(ByVal deducciones As Entidades.Deducciones)
        Dim objDeducciones As New Datos.DeduccionesDA
        objDeducciones.GuardarEdicionDeduccion(deducciones)
    End Sub
    Public Function lstDeduccionesPorCobrar(idNave As Integer) As DataTable
        Dim objDA As New Datos.DeduccionesDA
        Return objDA.lstDeduccionesPorCobrar(idNave)
    End Function

    'Public Function ListaDeduccionPorCobrar(ByVal IdNave As Integer) As List(Of Entidades.Deducciones)


    '    Dim objDA As New Datos.DeduccionesDA
    '    Dim tabla As New DataTable
    '    ListaDeduccionPorCobrar = New List(Of Entidades.Deducciones)
    '    tabla = objDA.ListaDeduccionesPorCobrar(IdNave)

    '    For Each fila As DataRow In tabla.Rows

    '        Dim colaborador As New Entidades.Colaborador
    '        Dim Deducciones As New Entidades.Deducciones

    '        colaborador.PNombre = CStr(fila("codr_nombre"))
    '        colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
    '        colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
    '        colaborador.PColaboradorid = CInt(fila("codr_colaboradorid"))

    '        Deducciones.PDepartamento = CStr(fila("grup_name"))
    '        Deducciones.PPuesto = CStr(fila("pues_nombre"))
    '        Deducciones.PidDeduccion = CInt(fila("decx_deduccionid"))
    '        Deducciones.PConceptoDeduccion = CStr(fila("decx_concepto"))
    '        Deducciones.PMontoDeduccion = CStr(fila("decx_monto"))
    '        Deducciones.PnumeroSemanas = CInt(fila("decx_numerosemanas"))
    '        Deducciones.Pabono = CDbl(fila("decx_abono"))
    '        Deducciones.PSaldo = CDbl(fila("decx_saldo"))
    '        Deducciones.PNumeroPago = CInt(fila("NumPago"))


    '        Deducciones.PColaborador = colaborador

    '        ListaDeduccionPorCobrar.Add(Deducciones)

    '    Next
    'End Function

    Public Function ListaDeduccionPorCobrar(ByVal IdNave As Integer) As DataTable
        Dim objDA As New Datos.DeduccionesDA
        Return objDA.ListaDeduccionesPorCobrar(IdNave)
    End Function

    Public Function NumSemanasGanadas(ByVal idColaborador As Integer) As List(Of Entidades.Deducciones)

        Dim objDA As New Datos.DeduccionesDA
        Dim tabla As New DataTable
        NumSemanasGanadas = New List(Of Entidades.Deducciones)
        tabla = objDA.NumSemanasGanadas(idColaborador)

        For Each fila As DataRow In tabla.Rows
            Dim Deducciones As New Entidades.Deducciones
            Deducciones.PSemGanadas = fila("ccheck_puntualidad_asistencia")
            NumSemanasGanadas.Add(Deducciones)
        Next
    End Function

    Public Function NumCondonaciones(ByVal idColaborador As Integer) As List(Of Entidades.Deducciones)

        Dim objDA As New Datos.DeduccionesDA
        Dim tabla As New DataTable
        NumCondonaciones = New List(Of Entidades.Deducciones)
        tabla = objDA.NumCondonaciones(idColaborador)

        For Each fila As DataRow In tabla.Rows
            Dim Deducciones As New Entidades.Deducciones

            Deducciones.PCondonacion = fila("pagodecx_condonacion")
            NumCondonaciones.Add(Deducciones)
        Next
    End Function



    Public Function ListaDeduccionCobrados(ByVal IdNave As Integer, ByVal idSemanaNomina As Integer) As List(Of Entidades.Deducciones)

        Dim objDA As New Datos.DeduccionesDA
        Dim tabla As New DataTable
        ListaDeduccionCobrados = New List(Of Entidades.Deducciones)
        tabla = objDA.ListaDeduccionesCobradas(IdNave, idSemanaNomina)

        For Each fila As DataRow In tabla.Rows

            Dim colaborador As New Entidades.Colaborador
            Dim Deducciones As New Entidades.Deducciones

            colaborador.PNombre = CStr(fila("codr_nombre"))
            colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            colaborador.PColaboradorid = CInt(fila("codr_colaboradorid"))

            Deducciones.PDepartamento = CStr(fila("grup_name"))
            Deducciones.PPuesto = CStr(fila("pues_nombre"))

            Deducciones.PidDeduccion = CInt(fila("decx_deduccionid"))
            Deducciones.PPagoID = CInt(fila("pagodecx_pagoid"))
            Deducciones.PConceptoDeduccion = CStr(fila("decx_concepto"))
            Deducciones.PMontoDeduccion = CStr(fila("decx_monto"))
            Deducciones.PnumeroSemanas = CInt(fila("decx_numerosemanas"))

            Deducciones.Pabono = CDbl(fila("pagodecx_abono"))
            Deducciones.PSaldo = CDbl(fila("pagodecx_saldonuevo"))
            Deducciones.PSaldoAnterior = CDbl(fila("pagodecx_saldoanterior"))
            Deducciones.PNumeroPago = CDbl(fila("pagodecx_numeropago"))


            Deducciones.PColaborador = colaborador

            ListaDeduccionCobrados.Add(Deducciones)

        Next
    End Function

    Public Function ListaDeduccionCobradosNEgativos(ByVal IdNave As Integer, ByVal idSemanaNomina As Integer, ByVal idColaborador As Integer) As List(Of Entidades.Deducciones)

        Dim objDA As New Datos.DeduccionesDA
        Dim tabla As New DataTable
        ListaDeduccionCobradosNEgativos = New List(Of Entidades.Deducciones)
        tabla = objDA.ListaDeduccionesCobradasNegativos(IdNave, idSemanaNomina, idColaborador)

        For Each fila As DataRow In tabla.Rows

            Dim colaborador As New Entidades.Colaborador
            Dim Deducciones As New Entidades.Deducciones

            colaborador.PNombre = CStr(fila("codr_nombre"))
            colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            colaborador.PColaboradorid = CInt(fila("codr_colaboradorid"))

            Deducciones.PDepartamento = CStr(fila("grup_name"))
            Deducciones.PPuesto = CStr(fila("pues_nombre"))

            Deducciones.PidDeduccion = CInt(fila("decx_deduccionid"))
            Deducciones.PPagoID = CInt(fila("pagodecx_pagoid"))
            Deducciones.PConceptoDeduccion = CStr(fila("decx_concepto"))
            Deducciones.PMontoDeduccion = CStr(fila("decx_monto"))
            Deducciones.PnumeroSemanas = CInt(fila("decx_numerosemanas"))

            Deducciones.Pabono = CDbl(fila("pagodecx_abono"))
            Deducciones.PSaldo = CDbl(fila("pagodecx_saldonuevo"))
            Deducciones.PSaldoAnterior = CDbl(fila("pagodecx_saldoanterior"))
            Deducciones.PNumeroPago = CDbl(fila("pagodecx_numeropago"))


            Deducciones.PColaborador = colaborador

            ListaDeduccionCobradosNEgativos.Add(Deducciones)

        Next
    End Function

    Public Function lstDeduccionesFiltro(ByVal IdNave As Integer, ByVal idSemanaNomina As Integer, ByVal colaborador As String, semanaDel As String, semanaAl As String, conFechas As Boolean) As DataTable
        Dim objDA As New Datos.DeduccionesDA
        Dim tabla As New DataTable
        Return objDA.lstDeduccionesFiltro(IdNave, idSemanaNomina, colaborador, semanaDel, semanaAl, conFechas)
    End Function

    Public Function ListaDeduccionFiltro(ByVal IdNave As Integer, ByVal idSemanaNomina As Integer, ByVal colaboradorF As String) As List(Of Entidades.Deducciones)

        Dim objDA As New Datos.DeduccionesDA
        Dim tabla As New DataTable
        ListaDeduccionFiltro = New List(Of Entidades.Deducciones)
        tabla = objDA.ListaDeduccionesFiltro(IdNave, idSemanaNomina, colaboradorF)

        For Each fila As DataRow In tabla.Rows

            Dim colaborador As New Entidades.Colaborador
            Dim Deducciones As New Entidades.Deducciones

            colaborador.PNombre = CStr(fila("codr_nombre"))
            colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            colaborador.PColaboradorid = CInt(fila("codr_colaboradorid"))

            Deducciones.PDepartamento = CStr(fila("grup_name"))
            Deducciones.PPuesto = CStr(fila("pues_nombre"))

            Deducciones.PidDeduccion = CInt(fila("decx_deduccionid"))
            Deducciones.PPagoID = CInt(fila("pagodecx_pagoid"))
            Deducciones.PConceptoDeduccion = CStr(fila("decx_concepto"))
            Deducciones.PMontoDeduccion = CStr(fila("decx_monto"))
            Deducciones.PnumeroSemanas = CInt(fila("decx_numerosemanas"))

            Deducciones.Pabono = CDbl(fila("pagodecx_abono"))
            Deducciones.PSaldo = CDbl(fila("pagodecx_saldonuevo"))
            Deducciones.PSaldoAnterior = CDbl(fila("pagodecx_saldoanterior"))
            Deducciones.PNumeroPago = CDbl(fila("pagodecx_numeropago"))


            Deducciones.PColaborador = colaborador

            ListaDeduccionFiltro.Add(Deducciones)

        Next
    End Function

    Public Function DeduccionesExtraordinariasActivas(ByVal IdNave As Integer, ByVal idSemanaNomina As Integer, ByVal colaboradorF As String) As List(Of Entidades.Deducciones)

        Dim objDA As New Datos.DeduccionesDA
        Dim tabla As New DataTable
        DeduccionesExtraordinariasActivas = New List(Of Entidades.Deducciones)
        tabla = objDA.DeduccionesExtraActivas(IdNave, idSemanaNomina, colaboradorF)

        For Each fila As DataRow In tabla.Rows

            Dim colaborador As New Entidades.Colaborador
            Dim Deducciones As New Entidades.Deducciones

            colaborador.PNombre = CStr(fila("codr_nombre"))
            colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            colaborador.PColaboradorid = CInt(fila("codr_colaboradorid"))

            Deducciones.PDepartamento = CStr(fila("grup_name"))
            Deducciones.PPuesto = CStr(fila("pues_nombre"))

            Deducciones.PidDeduccion = CInt(fila("decx_deduccionid"))
            Deducciones.PPagoID = CInt(fila("pagodecx_pagoid"))
            Deducciones.PConceptoDeduccion = CStr(fila("decx_concepto"))
            Deducciones.PMontoDeduccion = CStr(fila("decx_monto"))
            Deducciones.PnumeroSemanas = CInt(fila("decx_numerosemanas"))

            Deducciones.Pabono = CDbl(fila("pagodecx_abono"))
            Deducciones.PSaldo = CDbl(fila("pagodecx_saldonuevo"))
            Deducciones.PSaldoAnterior = CDbl(fila("pagodecx_saldoanterior"))
            Deducciones.PNumeroPago = CDbl(fila("pagodecx_numeropago"))


            Deducciones.PColaborador = colaborador

            DeduccionesExtraordinariasActivas.Add(Deducciones)

        Next
    End Function

    Public Function ListaDeduccionFiltroCorte(ByVal IdNave As Integer, ByVal idSemanaNomina As Integer, ByVal colaboradorF As String, ByVal colaboradorId As Integer) As List(Of Entidades.Deducciones)

        Dim objDA As New Datos.DeduccionesDA
        Dim tabla As New DataTable
        ListaDeduccionFiltroCorte = New List(Of Entidades.Deducciones)
        tabla = objDA.ListaDeduccionesFiltroCorte(IdNave, idSemanaNomina, colaboradorF, colaboradorId)

        For Each fila As DataRow In tabla.Rows

            Dim colaborador As New Entidades.Colaborador
            Dim Deducciones As New Entidades.Deducciones

            colaborador.PNombre = CStr(fila("codr_nombre"))
            colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            colaborador.PColaboradorid = CInt(fila("codr_colaboradorid"))

            Deducciones.PDepartamento = CStr(fila("grup_name"))
            Deducciones.PPuesto = CStr(fila("pues_nombre"))

            Deducciones.PidDeduccion = CInt(fila("decx_deduccionid"))
            Deducciones.PPagoID = CInt(fila("pagodecx_pagoid"))
            Deducciones.PConceptoDeduccion = CStr(fila("decx_concepto"))
            Deducciones.PMontoDeduccion = CStr(fila("decx_monto"))
            Deducciones.PnumeroSemanas = CInt(fila("decx_numerosemanas"))

            Deducciones.Pabono = CDbl(fila("pagodecx_abono"))
            Deducciones.PSaldo = CDbl(fila("pagodecx_saldonuevo"))
            Deducciones.PSaldoAnterior = CDbl(fila("pagodecx_saldoanterior"))
            Deducciones.PNumeroPago = CDbl(fila("pagodecx_numeropago"))


            Deducciones.PColaborador = colaborador

            ListaDeduccionFiltroCorte.Add(Deducciones)

        Next
    End Function


    Public Function ConsultaDeduccionesparaLiquidacion(ByVal Colaboradorid As Int32)
        Dim objDA As New Datos.DeduccionesDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaDeDeduccionesExtLiquidacion(Colaboradorid)
        Dim cantidad As New Int32
        For Each row As DataRow In tabla.Rows
            Try
                cantidad = CInt(row("Deducciones"))
            Catch ex As Exception

            End Try
        Next
        Return cantidad
    End Function

    Public Function consultaReporteDeducciones(ByVal idnave As Int32, ByVal inicioPeriodo As String,
                                              ByVal finPeriodo As String, ByVal idCaja As Int32, ByVal anioCaja As Int32) As DataTable
        Dim objDA As New Datos.DeduccionesDA
        Return objDA.consultaReporteDeducciones(idnave, inicioPeriodo, finPeriodo, idCaja, anioCaja)
    End Function

    Public Function consultaReporteDeduccionesAnterior(ByVal idnave As Int32, ByVal inicioPeriodo As String,
                                              ByVal finPeriodo As String, ByVal idCaja As Int32, ByVal anioCaja As Int32) As DataTable
        Dim objDA As New Datos.DeduccionesDA
        Return objDA.consultaReporteDeduccionesAnterior(idnave, inicioPeriodo, finPeriodo, idCaja, anioCaja)
    End Function

    Public Function consultaMesesPeriodoCaja(ByVal idnave As Int32, ByVal inicioPeriodo As String,
                                               ByVal finPeriodo As String) As DataTable
        Dim objDA As New Datos.DeduccionesDA
        Return objDA.consultaMesesPeriodoCaja(idnave, inicioPeriodo, finPeriodo)
    End Function

    Public Function CambiaDeduccionesNegativos(ByVal colaboradorid As Integer, ByVal modificacaja As Boolean, ByVal modificaprestamo As Boolean, ByVal modificadeducciones As Boolean, ByVal periodoid As Integer) As String
        Dim objDeducciones As New Datos.DeduccionesDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDeducciones.CambiaDeduccionesNegativos(colaboradorid, modificacaja, modificaprestamo, modificadeducciones, periodoid)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0).Item("mensaje")
            End If
        End If
        Return resultado
    End Function
End Class
