Public Class ColaboradorPeriodoCajaBU

    Private pResultado As String = String.Empty

    Public Property Resultado As String
        Get
            Return pResultado
        End Get
        Set(ByVal value As String)
            pResultado = value
        End Set
    End Property

    Public Function Listar(idCajaAhorro As Int32) As List(Of Entidades.ColaboradorPeriodoCaja)

        Listar = New List(Of Entidades.ColaboradorPeriodoCaja)


        Dim objColaboradorPeriodoCajaDA As New Nomina.Datos.ColaboradorPeriodoCajaDA
        Dim tablaColaboradorPeriodoCaja As New DataTable

        tablaColaboradorPeriodoCaja = objColaboradorPeriodoCajaDA.Listar(idCajaAhorro)


        For Each renglon As DataRow In tablaColaboradorPeriodoCaja.Rows
            Dim objColaboradorPeriodoCaja As New Entidades.ColaboradorPeriodoCaja

            Dim objCajaAhorro As New Entidades.CajaAhorro
            Dim objCajaAhorroBU As New Nomina.Negocios.CajaAhorroBU
            objCajaAhorro = objCajaAhorroBU.ObtenerCajaAhorro(renglon("cajc_cajaahorroid"))


            Dim objColaborador As New Entidades.Colaborador
            Dim objColaboradorBU As New Nomina.Negocios.ColaboradoresBU
            objColaborador = objColaboradorBU.BuscarColaboradorGeneral(renglon("cajc_colaboradorid"))

            Dim objPeriodosNomina As New Entidades.PeriodosNomina
            Dim objPeriodosNominaBU As New Nomina.Negocios.ControlDePeriodoBU
            objPeriodosNomina = objPeriodosNominaBU.BuscarPeridosSeleccionados(renglon("pnom_periodonomid"))


            objColaboradorPeriodoCaja.pCajaAhorro = objCajaAhorro
            objColaboradorPeriodoCaja.pPeriodo = objPeriodosNomina
            objColaboradorPeriodoCaja.pColaborador = objColaborador
            objColaboradorPeriodoCaja.pMontoAhorrado = renglon("cajc_montoahorro")
            Listar.Add(objColaboradorPeriodoCaja)
        Next

        Return Listar


    End Function


    Public Sub CerrarCajaAhorro(ByVal Listado As List(Of Entidades.ColaboradorPeriodoCaja), ByVal IdCajaAhorro As Int32)

        Dim objColaboradorPeriodoCajaDA As New Nomina.Datos.ColaboradorPeriodoCajaDA
        objColaboradorPeriodoCajaDA.CerrarCajaAhorro(Listado)

    End Sub


    Public Sub VerificaExistenciaCierre(ByVal IdCajaAhorro)

        Dim objColaboradorPeriodoCajaDA As New Nomina.Datos.ColaboradorPeriodoCajaDA
        Resultado = ""

        If objColaboradorPeriodoCajaDA.VerificaExistenciaPeriodoNomina(IdCajaAhorro) <= 0 Then
            Resultado = "No se encuentra un periodo de nomina válido."
            Exit Sub
        End If

        'If objColaboradorPeriodoCajaDA.VerificaExistenciaCierre(IdCajaAhorro) <= 0 Then
        '    Resultado = "El cierre de la caja de ahorro ya se realizo."
        '    Exit Sub
        'End If

    End Sub


    Public Sub VerificaExistenciaColaboradores(ByVal IdCajaAhorro)

        Dim objColaboradorPeriodoCajaDA As New Nomina.Datos.ColaboradorPeriodoCajaDA
        Resultado = ""

        If objColaboradorPeriodoCajaDA.VerificaExistenciaColaboradores(IdCajaAhorro) <= 0 Then
            Resultado = "No se ha asignado colaboradores a esta caja de ahorro."
            Exit Sub
        End If

    End Sub



    Public Function Listar(idCajaAhorro As Int32, idperiodonomina As Int32) As List(Of Entidades.ColaboradorPeriodoCaja)

        Listar = New List(Of Entidades.ColaboradorPeriodoCaja)


        Dim objColaboradorPeriodoCajaDA As New Nomina.Datos.ColaboradorPeriodoCajaDA
        Dim tablaColaboradorPeriodoCaja As New DataTable

        tablaColaboradorPeriodoCaja = objColaboradorPeriodoCajaDA.Listar(idCajaAhorro, idperiodonomina)


        For Each renglon As DataRow In tablaColaboradorPeriodoCaja.Rows
            Dim objColaboradorPeriodoCaja As New Entidades.ColaboradorPeriodoCaja

            Dim objCajaAhorro As New Entidades.CajaAhorro
            Dim objCajaAhorroBU As New Nomina.Negocios.CajaAhorroBU
            objCajaAhorro = objCajaAhorroBU.ObtenerCajaAhorro(renglon("ccpc_cajaahorroid"))


            Dim objColaborador As New Entidades.Colaborador
            Dim objColaboradorBU As New Nomina.Negocios.ColaboradoresBU
            objColaborador = objColaboradorBU.BuscarColaboradorGeneral(renglon("ccpc_colaboradorid"))

            Dim objPeriodosNomina As New Entidades.PeriodosNomina
            Dim objPeriodosNominaBU As New Nomina.Negocios.ControlDePeriodoBU
            objPeriodosNomina = objPeriodosNominaBU.BuscarPeridosSeleccionados(renglon("ccpc_periodoid"))


            objColaboradorPeriodoCaja.pCajaAhorro = objCajaAhorro
            objColaboradorPeriodoCaja.pPeriodo = objPeriodosNomina
            objColaboradorPeriodoCaja.pColaborador = objColaborador
            objColaboradorPeriodoCaja.pMontoAhorrado = renglon("ccpc_montoahorro")
            Listar.Add(objColaboradorPeriodoCaja)
        Next

        Return Listar


    End Function

    Public Function ObtieneIdCajaAhorro(ByVal IdPeriodoNomina As Int32) As Int32
        Dim objColaboradorPeriodoCajaDA As New Nomina.Datos.ColaboradorPeriodoCajaDA
        ObtieneIdCajaAhorro = objColaboradorPeriodoCajaDA.ObtieneIdCajaAhorro(IdPeriodoNomina)

    End Function

    Public Function ObtieneIdCajaAhorro_Nave(ByVal IdNave As Int32) As Int32
        Dim objColaboradorPeriodoCajaDA As New Nomina.Datos.ColaboradorPeriodoCajaDA
        ObtieneIdCajaAhorro_Nave = objColaboradorPeriodoCajaDA.ObtieneIdCajaAhorro_nave(IdNave)

    End Function


    Public Function VerificaIdCajaAhorro_Nave(ByVal IdNave As Int32) As Boolean
        VerificaIdCajaAhorro_Nave = False

        Dim objColaboradorPeriodoCajaDA As New Nomina.Datos.ColaboradorPeriodoCajaDA

        If objColaboradorPeriodoCajaDA.VerificaIdCajaAhorro_nave(IdNave) > 0 Then
            VerificaIdCajaAhorro_Nave = True
        Else
            VerificaIdCajaAhorro_Nave = False
        End If

    End Function


End Class
