Imports Nomina.Datos

Public Class CajaColaboradorBU
	Public Function listaCajaColaborador(ByVal Nombre As String, ByVal Asignado As Boolean, ByVal IdCaja As Int32) As List(Of Entidades.CajaColaborador)
		Dim objDA As New Datos.CajaColaboradorDA
		Dim tabla As New DataTable

		listaCajaColaborador = New List(Of Entidades.CajaColaborador)


		tabla = objDA.ListaCajaColaborador(Nombre, IdCaja)
        For Each fila As DataRow In tabla.Rows
            Dim caja As New Entidades.CajaColaborador

            'caja.PIdColaborador = CInt(fila("cajc_CajaAhorroId"))
            caja.PEstatus = CStr(fila("cajc_Estatus"))
            caja.PMontoAcumulado = CDbl(fila("cajc_MontoAhorroAcumulado"))
            caja.PMontoAhorro = CDbl(fila("cajc_MontoAhorro"))

            caja.PMontoMaximoAhorrar = CInt(fila("maximoAhorrar"))

            Dim colaborador As New Entidades.Colaborador
            colaborador.PColaboradorid = CInt(fila("codr_colaboradorid"))
            colaborador.PNombre = CStr(fila("codr_nombre"))
            colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            colaborador.PActivo = CBool(fila("codr_activo"))

            caja.PColaborador = colaborador

            Dim ColReal As New Entidades.ColaboradorReal


            Try
                ColReal.PCantidad = CDbl(fila("real_cantidad"))
            Catch ex As Exception

            End Try


            caja.PSalario = ColReal

            Dim Departamento As New Entidades.Departamentos

            Departamento.Ddepartamentoid = CInt(fila("grup_grupoid"))
            Departamento.DNombre = CStr(fila("grup_name"))
            Dim Area As New Entidades.Areas
            Area.PNombre = CStr(fila("area_nombre"))
            caja.PAreas = Area
            caja.PDepartamento = Departamento

            listaCajaColaborador.Add(caja)
        Next
    End Function

    Public Function listaCajaColaboradoresNoAsignados(ByVal Nombre As String, ByVal cajaid As Integer, ByVal naveid As Integer) As List(Of Entidades.Colaborador)
        Dim objDA As New Datos.CajaColaboradorDA
        Dim tabla As New DataTable
        listaCajaColaboradoresNoAsignados = New List(Of Entidades.Colaborador)
        tabla = objDA.ListaCajaColaboradoresNoAsignados(Nombre, cajaid, naveid)

        For Each fila As DataRow In tabla.Rows

            Dim colaborador As New Entidades.Colaborador

            colaborador.PColaboradorid = CStr(fila("codr_colaboradorid"))

            colaborador.PNombre = CStr(fila("codr_nombre"))
            colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))


            Dim caja As New Entidades.CajaColaborador
            'caja.PEstatus = CStr(fila("cajc_Estatus"))
            colaborador.PEstatus = caja


            Dim Departamento As New Entidades.Departamentos

            Departamento.Ddepartamentoid = CInt(fila("grup_grupoid"))
            Departamento.DNombre = CStr(fila("grup_name"))

            colaborador.PIDepartamento = Departamento

            Dim Real As New Entidades.ColaboradorReal
            If IsDBNull(fila("real_cantidad")) Then
                Real.PCantidad = 0
            Else

                Real.PCantidad = CDbl(fila("real_cantidad"))
            End If





            colaborador.Psalario = Real
            Dim Area As New Entidades.Areas
            Area.PNombre = CStr(fila("area_nombre"))
            caja.PAreas = Area
            caja.PDepartamento = Departamento

            caja.PMontoMaximoAhorrar = CInt(fila("maximoAhorrar"))
            listaCajaColaboradoresNoAsignados.Add(colaborador)

        Next
        Return listaCajaColaboradoresNoAsignados
    End Function

	Public Sub GuardarCajas(ByVal caja As Entidades.CajaColaborador)
		Dim objCajas As New CajaColaboradorDA
		objCajas.AltasCajaAhorro(caja)
	End Sub
	Public Sub EditarCajas(ByVal cajaUp As Entidades.CajaColaborador)
		Dim objCajas As New CajaColaboradorDA
		objCajas.EditarCajaAhorro(cajaUp)
	End Sub
	Public Sub Insert(ByVal IdColaborador As Int32, ByVal MontoAcumulado As Double, ByVal MontoAhorro As Double, ByVal Status As String)
		Dim objDA As New CajaColaboradorDA
		objDA.InsertCajaC(IdColaborador, MontoAcumulado, MontoAhorro, Status)
    End Sub

    Public Function ConsultarCajaDeAhorroSaldo(ByVal Colaboradorid As Int32, ByVal NaveID As Int32) As Int32
        Dim objDA As New CajaColaboradorDA
        Dim tablas As New DataTable
        Dim cantidad As New Int32
        tablas = objDA.ConsultarCajaDeAhorroSaldo(Colaboradorid, NaveID)
        For Each row As DataRow In tablas.Rows
            Try
                cantidad += CInt(row("ccpc_montoahorro"))

            Catch ex As Exception

            End Try

        Next
        Return cantidad
    End Function

    Public Function ConsultarCajaDeAhorroSaldoPrestamo(ByVal Colaboradorid As Int32, ByVal NaveID As Int32) As List(Of Entidades.CajaColaborador)
        Dim objDA As New CajaColaboradorDA
        Dim tablas As New DataTable
        Dim cantidad As New Int32
        ConsultarCajaDeAhorroSaldoPrestamo = New List(Of Entidades.CajaColaborador)
        tablas = objDA.ConsultarCajaDeAhorroSaldo(Colaboradorid, NaveID)
        For Each row As DataRow In tablas.Rows
            Try
                Dim ObjEnt As New Entidades.CajaColaborador
                ObjEnt.PMontoAcumulado = CDbl(row("ccpc_montoahorro"))
                ObjEnt.PMontoAhorro = CDbl(row("ccpc_montoahorro"))
                ConsultarCajaDeAhorroSaldoPrestamo.Add(ObjEnt)
            Catch ex As Exception
            End Try
        Next
    End Function

    Public Function listaAcumuladoCajaAhorro(ByVal cajaId As Int32, ByVal colaboradorID As Int32) As List(Of Entidades.CajaColaborador)
        Dim objDA As New CajaColaboradorDA
        Dim tablas As New DataTable

        listaAcumuladoCajaAhorro = New List(Of Entidades.CajaColaborador)
        tablas = objDA.LiscaAcumuladoCajaAhorro(cajaId, colaboradorID)
        Try
            For Each row As DataRow In tablas.Rows
                Dim CajaAhorro As New Entidades.CajaColaborador
                CajaAhorro.MontoAcumulado += CDbl(row("ccpc_montoahorro"))
                listaAcumuladoCajaAhorro.Add(CajaAhorro)
            Next
        Catch
            Dim CajaAhorro As New Entidades.CajaColaborador
            CajaAhorro.MontoAcumulado = 0
            listaAcumuladoCajaAhorro.Add(CajaAhorro)
        End Try

    End Function


End Class
