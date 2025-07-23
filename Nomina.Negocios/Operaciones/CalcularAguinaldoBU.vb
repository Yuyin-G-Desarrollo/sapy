Public Class CalcularAguinaldoBU


    Public Function ExisteAguinaldoNave(ByVal idNave As Integer, ByVal Año As Integer) As Boolean
        Dim objDA As New Nomina.Datos.CalcularAguinaldoDA
        Return objDA.ExisteAguinaldoNave(idNave, Año)
    End Function

    Public Function ListaColaboradoresAguinaldo(ByVal idNave As Integer) As List(Of Entidades.CalcularAguinaldos)
        Dim objDA As New Nomina.Datos.CalcularAguinaldoDA
        Dim tabla As New DataTable

        ListaColaboradoresAguinaldo = New List(Of Entidades.CalcularAguinaldos)
        tabla = objDA.ListaColaboradoresAguinaldo(idNave)

        For Each fila As DataRow In tabla.Rows
            Dim ColaboradorEnt As New Entidades.Colaborador
            Dim ColaboradorReal As New Entidades.ColaboradorReal
            Dim nominaReal As New Entidades.CalcularNominaReal
            Dim Aguinaldos As New Entidades.CalcularAguinaldos

            ColaboradorEnt.PColaboradorid = CInt(fila("codr_colaboradorid"))
            ColaboradorEnt.PNombre = CStr(fila("codr_nombre"))
            ColaboradorEnt.PApaterno = CStr(fila("codr_apellidopaterno"))
            ColaboradorEnt.PAmaterno = CStr(fila("codr_apellidomaterno"))

            ColaboradorReal.PCantidad = CDbl(fila("real_cantidad"))
            ColaboradorReal.PFecha = CDate(fila("real_fecha"))

            Aguinaldos.PColaborador = ColaboradorEnt
            Aguinaldos.PColaboradorReal = ColaboradorReal
            Aguinaldos.PtipoSueldo = CStr(fila("real_tipo"))

            ListaColaboradoresAguinaldo.Add(Aguinaldos)
        Next

    End Function

    Public Function ListacolaboradoresSalarios(ByVal idColaborador As Integer, ByVal anio As Integer, ByVal naveid As Integer) As List(Of Entidades.CalcularAguinaldos)
        Dim objDA As New Nomina.Datos.CalcularAguinaldoDA
        Dim tabla As New DataTable

        ListacolaboradoresSalarios = New List(Of Entidades.CalcularAguinaldos)
        tabla = objDA.ListaSalariosColaborador(idColaborador, anio, naveid)

        For Each columna As DataColumn In tabla.Columns
            Dim Aguinaldos As New Entidades.CalcularAguinaldos
            Dim salario As String = String.Empty
            salario = tabla.Rows(0)(columna.ColumnName).ToString()
            If salario = "" Then
                salario = "0"
            End If
            Aguinaldos.PSalarioXmes = CDbl(salario)
            ListacolaboradoresSalarios.Add(Aguinaldos)
        Next


        'For Each fila As DataRow In tabla.Rows
        '    Dim Aguinaldos As New Entidades.CalcularAguinaldos


        '    Aguinaldos.PSalarioXmes = CDbl(fila("conr_salariosemanal"))


        '    ListacolaboradoresSalarios.Add(Aguinaldos)
        'Next

    End Function

    Public Function ListacolaboradoresSalariosVacaciones(ByVal idColaborador As Integer, ByVal anio As Integer, ByVal naveid As Integer) As List(Of Entidades.CalcularAguinaldos)
        Dim objDA As New Nomina.Datos.CalcularAguinaldoDA
        Dim tabla As New DataTable

        ListacolaboradoresSalariosVacaciones = New List(Of Entidades.CalcularAguinaldos)
        tabla = objDA.ListaSalariosColaboradorVacaciones(idColaborador, anio, naveid) 'Ticket 15367

        For Each columna As DataColumn In tabla.Columns
            Dim Aguinaldos As New Entidades.CalcularAguinaldos
            Dim salario As String = String.Empty
            salario = tabla.Rows(0)(columna.ColumnName).ToString()
            If salario = "" Then
                salario = "0"
            End If
            Aguinaldos.PSalarioXmes = CDbl(salario)
            ListacolaboradoresSalariosVacaciones.Add(Aguinaldos)
        Next


    End Function


    Public Function FaltasPeriodosAguinaldo(ByVal idColaborador As Integer, ByVal anio As Integer, ByVal naveid As Integer) As Double
        Dim objDA As New Nomina.Datos.CalcularAguinaldoDA
        Dim tabla As New DataTable
        Dim Faltas As Double = 0

        FaltasPeriodosAguinaldo = 0

        tabla = objDA.FaltasPeriodosAguinaldo(idColaborador, anio, naveid)

        For Each fila As DataRow In tabla.Rows

            If Not IsDBNull(fila("inasistencias")) Then
                Faltas = CDbl(fila("inasistencias"))
            End If

        Next
        Return Faltas
    End Function

    Public Function FaltasPeriodosAguinaldo2(ByVal idColaborador As Integer, ByVal anio As Integer, ByVal naveid As Integer) As Double
        Dim objDA As New Nomina.Datos.CalcularAguinaldoDA
        Dim tabla As New DataTable
        Dim Faltas As Double = 0

        Faltas = 0

        tabla = objDA.FaltasPeriodosAguinaldo(idColaborador, anio, naveid)

        For Each fila As DataRow In tabla.Rows

            If Not IsDBNull(fila("inasistencias")) Then
                Faltas = CDbl(fila("inasistencias"))
            End If

        Next
        Return Faltas
    End Function


    Public Function ListaAguinaldos(ByVal idNave As Integer) As List(Of Entidades.CalcularAguinaldos)
        Dim objDA As New Nomina.Datos.CalcularAguinaldoDA
        Dim tabla As New DataTable

        ListaAguinaldos = New List(Of Entidades.CalcularAguinaldos)
        tabla = objDA.ListaAguinaldos(idNave)

        For Each fila As DataRow In tabla.Rows

            Dim Aguinaldos As New Entidades.CalcularAguinaldos

            Aguinaldos.PAguinaldoAnio = CInt(fila("agui_anio"))

            ListaAguinaldos.Add(Aguinaldos)

        Next
    End Function

    Public Function ListaAguinaldosGUARDADOS(ByVal idNave As Integer, ByVal anio As Integer, ByVal colaborador2 As String) As List(Of Entidades.CalcularAguinaldos)
        Dim objDA As New Nomina.Datos.CalcularAguinaldoDA
        Dim tabla As New DataTable

        ListaAguinaldosGUARDADOS = New List(Of Entidades.CalcularAguinaldos)
        tabla = objDA.ListaAguinaldosGUARDADOS(idNave, anio, colaborador2)

        For Each fila As DataRow In tabla.Rows

            Dim Aguinaldos As New Entidades.CalcularAguinaldos
            Dim colaborador As New Entidades.Colaborador
            Dim nominaReal As New Entidades.CalcularNominaReal
            Dim colaboradorReal As New Entidades.ColaboradorReal

            colaborador.PColaboradorid = CInt(fila("agui_colaboradorid"))

            colaboradorReal.PFecha = CDate(fila("real_fecha"))

            colaborador.PNombre = CStr(fila("codr_nombre"))
            colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))

            Aguinaldos.PAguinaldoAnio = CInt(fila("agui_anio"))
            Aguinaldos.PAguinaldoMeses = CDbl(fila("agui_meses"))
            Aguinaldos.PDiasxPagar = CDbl(fila("agui_diasxpagar"))

            nominaReal.PSalarioDiario = CDbl(fila("agui_sueldodiario"))
            nominaReal.PTotalEntregar = CDbl(fila("agui_totalentregar"))


            Aguinaldos.PColaborador = colaborador
            Aguinaldos.PnominaReal = nominaReal
            Aguinaldos.PColaboradorReal = colaboradorReal

            ListaAguinaldosGUARDADOS.Add(Aguinaldos)

        Next
    End Function

    Public Function ListaAguinaldosGUARDADOS2(ByVal idNave As Integer, ByVal anio As Integer, ByVal colaborador2 As String) As DataTable
        Dim objDA As New Nomina.Datos.CalcularAguinaldoDA
        Dim tabla As New DataTable

        tabla = objDA.ListaAguinaldosGUARDADOS(idNave, anio, colaborador2)
        Return tabla

    End Function


    Public Sub guardarAguinaldo(ByVal aguinaldos As Entidades.CalcularAguinaldos, ByVal naveid As Integer, ByVal UsuarioCreoID As Integer)
        Dim objAguinaldos As New Datos.CalcularAguinaldoDA
        objAguinaldos.guardarAguinaldos(aguinaldos, naveid, UsuarioCreoID)
    End Sub

    Public Function RevisarConfiguracion(ByVal NaveID As Integer) As DataTable
        Dim objDA As New Datos.CalcularAguinaldoDA
        Dim TablaResultado As New DataTable
        TablaResultado = objDA.RevisarConfiguracion(NaveID)
        Return TablaResultado
    End Function

    Public Function FaltasPeriodosVacaciones(ByVal idColaborador As Integer, ByVal anio As Integer, ByVal naveid As Integer) As Double
        Dim objDA As New Nomina.Datos.CalcularAguinaldoDA
        Dim tabla As New DataTable
        Dim Faltas As Double = 0

        FaltasPeriodosVacaciones = 0

        tabla = objDA.FaltasPeriodosVacaciones(idColaborador, anio, naveid)

        For Each fila As DataRow In tabla.Rows

            If Not IsDBNull(fila("inasistencias")) Then
                Faltas = CDbl(fila("inasistencias"))
            End If

        Next
        Return Faltas
    End Function

End Class
