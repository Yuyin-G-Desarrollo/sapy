Imports Entidades

Public Class CajaAhorroBU
    Private pResultado As String = String.Empty

    Public Property Resultado As String
        Get
            Return pResultado
        End Get
        Set(ByVal value As String)
            pResultado = value
        End Set
    End Property

    Public Sub AltaCajaAhorro(ByVal objCajaAhorro As Entidades.CajaAhorro)

        Resultado = VerificaPeriodo(objCajaAhorro)

        If Resultado.Length = 0 Then
            Dim objCajaAhorroDA As New Nomina.Datos.CajaAhorroDA
            objCajaAhorroDA.Altas(objCajaAhorro)
        End If


    End Sub

    Public Sub EditarCajaAhorro(ByVal objCajaAhorro As Entidades.CajaAhorro)

        Resultado = VerificaPeriodo(objCajaAhorro, True)

        If Resultado.Length = 0 Then
            Dim objCajaAhorroDA As New Nomina.Datos.CajaAhorroDA
            objCajaAhorroDA.Editar(objCajaAhorro)
        End If

    End Sub

    Public Function VerificaPeriodo(ByVal objCajaAhorro As Entidades.CajaAhorro) As String

        Dim objCajaAhorroDA As New Nomina.Datos.CajaAhorroDA

        VerificaPeriodo = ""

        If objCajaAhorroDA.Periodos(objCajaAhorro) > 0 Then
            VerificaPeriodo += "El rango introducido coincide con algun rango previo, verifique la informacion."
        End If
    End Function

    Public Function VerificaPeriodo(ByVal objCajaAhorro As Entidades.CajaAhorro, ByVal Editar As Boolean) As String

        Dim objCajaAhorroDA As New Nomina.Datos.CajaAhorroDA

        VerificaPeriodo = ""

        If objCajaAhorroDA.Periodos(objCajaAhorro, Editar) > 0 Then
            VerificaPeriodo += "El rango introducido coincide con algun rango previo, verifique la informacion."
        End If
    End Function

    Public Function ObtenerCajaAhorro(ByVal IdCajaAhorro As Int32) As Entidades.CajaAhorro

        Dim objCajaAhorroDA As New Nomina.Datos.CajaAhorroDA
        Dim objCajaAhorro As New Entidades.CajaAhorro

        Dim tblCajaAhorro As DataTable
        tblCajaAhorro = objCajaAhorroDA.ObtenerCajaAhorro(IdCajaAhorro)


        If tblCajaAhorro.Rows.Count > 0 Then

            Dim objNave As New Entidades.Naves
            Dim objNavesbu As New Framework.Negocios.NavesBU
            objNave = objNavesbu.buscarNaves(tblCajaAhorro.Rows(0)("caja_NaveId"))

            objCajaAhorro.pNave = objNave

            objCajaAhorro.pCajaAhorroId = tblCajaAhorro.Rows(0)("caja_CajaAhorroId")
            objCajaAhorro.pConcepto = tblCajaAhorro.Rows(0)("caja_Concepto")
            objCajaAhorro.pFechaInicial = tblCajaAhorro.Rows(0)("caja_FechaInicial")
            objCajaAhorro.pFechaFinal = tblCajaAhorro.Rows(0)("caja_FechaFinal")
            objCajaAhorro.pEstado = tblCajaAhorro.Rows(0)("caja_estado")
            objCajaAhorro.pMontoAhorro = tblCajaAhorro.Rows(0)("caja_MontoAhorro")
            objCajaAhorro.pMontoInteres = tblCajaAhorro.Rows(0)("caja_MontoInteres")
            objCajaAhorro.pMontoAhorroTotal = tblCajaAhorro.Rows(0)("caja_MontoAhorroTotal")

            If Not IsDBNull(tblCajaAhorro.Rows(0)("caja_fechainicialrptDeducciones")) Then
                objCajaAhorro.pFechaInicialDeducciones = tblCajaAhorro.Rows(0)("caja_fechainicialrptDeducciones")
            Else
                objCajaAhorro.pFechaInicialDeducciones = Now
            End If

            If Not IsDBNull(tblCajaAhorro.Rows(0)("caja_fechaFinalrptDeducciones")) Then
                objCajaAhorro.PFechaFinalDeducciones = tblCajaAhorro.Rows(0)("caja_fechaFinalrptDeducciones")
            Else
                objCajaAhorro.PFechaFinalDeducciones = Now
            End If

        End If
        Return objCajaAhorro

    End Function

    Public Function ObtenerCajaAhorroAnterior(ByVal IdCajaAhorro As Int32) As Entidades.CajaAhorro

        Dim objCajaAhorroDA As New Nomina.Datos.CajaAhorroDA
        Dim objCajaAhorro As New Entidades.CajaAhorro

        Dim tblCajaAhorro As DataTable
        tblCajaAhorro = objCajaAhorroDA.ObtenerCajaAhorroAnterior(IdCajaAhorro)


        If tblCajaAhorro.Rows.Count > 0 Then

            Dim objNave As New Entidades.Naves
            Dim objNavesbu As New Framework.Negocios.NavesBU
            objNave = objNavesbu.buscarNaves(tblCajaAhorro.Rows(0)("caja_NaveId"))

            objCajaAhorro.pNave = objNave

            objCajaAhorro.pCajaAhorroId = tblCajaAhorro.Rows(0)("caja_CajaAhorroId")
            objCajaAhorro.pConcepto = tblCajaAhorro.Rows(0)("caja_Concepto")
            objCajaAhorro.pFechaInicial = tblCajaAhorro.Rows(0)("caja_FechaInicial")
            objCajaAhorro.pFechaFinal = tblCajaAhorro.Rows(0)("caja_FechaFinal")
            objCajaAhorro.pEstado = tblCajaAhorro.Rows(0)("caja_estado")
            objCajaAhorro.pMontoAhorro = tblCajaAhorro.Rows(0)("caja_MontoAhorro")
            objCajaAhorro.pMontoInteres = tblCajaAhorro.Rows(0)("caja_MontoInteres")
            objCajaAhorro.pMontoAhorroTotal = tblCajaAhorro.Rows(0)("caja_MontoAhorroTotal")

            If Not IsDBNull(tblCajaAhorro.Rows(0)("caja_fechainicialrptDeducciones")) Then
                objCajaAhorro.pFechaInicialDeducciones = tblCajaAhorro.Rows(0)("caja_fechainicialrptDeducciones")
            Else
                objCajaAhorro.pFechaInicialDeducciones = Now
            End If

            If Not IsDBNull(tblCajaAhorro.Rows(0)("caja_fechaFinalrptDeducciones")) Then
                objCajaAhorro.PFechaFinalDeducciones = tblCajaAhorro.Rows(0)("caja_fechaFinalrptDeducciones")
            Else
                objCajaAhorro.PFechaFinalDeducciones = Now
            End If

        End If
        Return objCajaAhorro

    End Function

    Public Shared Function getEstatusCaja(ByVal estatus As String) As String
        getEstatusCaja = ""
        If estatus = "A" Then
            getEstatusCaja = Entidades.CajaAhorro.ACTIVA
        ElseIf estatus = "B" Then
            getEstatusCaja = Entidades.CajaAhorro.BLOQUEADA
        ElseIf estatus = "C" Then
            getEstatusCaja = Entidades.CajaAhorro.CERRADA
        End If
    End Function

    Public Function Listar(idNave As Int32, Estatus As String) As List(Of Entidades.CajaAhorro)

        Listar = New List(Of Entidades.CajaAhorro)

        Dim objCajaAhorroDA As New Nomina.Datos.CajaAhorroDA

        Dim tablaCajaAhorro As New DataTable

        tablaCajaAhorro = objCajaAhorroDA.Listar(idNave, Estatus)


        For Each renglon As DataRow In tablaCajaAhorro.Rows
            Dim cajaahorro As New Entidades.CajaAhorro
            Dim objnave As New Entidades.Naves
            Dim objnavesBU As New Framework.Negocios.NavesBU

            objnave = objnavesBU.buscarNaves(renglon("caja_naveiD"))


            cajaahorro.pCajaAhorroId = renglon("caja_CajaAhorroId")
            cajaahorro.pNave = objnave
            cajaahorro.pConcepto = renglon("caja_Concepto")
            cajaahorro.pFechaInicial = renglon("caja_FechaInicial")
            cajaahorro.pFechaFinal = renglon("caja_FechaFinal")
            cajaahorro.pEstado = renglon("caja_estado")
            cajaahorro.pMontoAhorro = renglon("caja_MontoAhorro")
            cajaahorro.pMontoInteres = renglon("caja_MontoInteres")
            cajaahorro.pMontoAhorroTotal = renglon("caja_MontoAhorroTotal")
            cajaahorro.pDescripcionEstado = renglon("estatus")

            'cajaahorro.pFechaCierre = renglon("caja_FechaCierre")

            Listar.Add(cajaahorro)
        Next

        Return Listar


    End Function

    Public Function ListarEstatusCajaAhorro() As DataTable
        ListarEstatusCajaAhorro = New DataTable

        Dim objCajaAhorroDA = New Nomina.Datos.CajaAhorroDA

        ListarEstatusCajaAhorro = objCajaAhorroDA.ListarEstatusCajaAhorro

    End Function

    Public Function periodosCajaAhorroSinCierre(ByVal naveID As Integer) As DataTable
        Dim objDA As New Datos.CajaAhorroDA
        Return objDA.periodosCajaAhorroSinCierre(naveID)
    End Function

    Public Function consultaCierreAnualCajaAhorroCerrada(ByVal idCajaAhorro As Int32) As DataTable
        Dim objDA As New Datos.CajaAhorroDA
        Return objDA.consultaCierreAnualCajaAhorroCerrada(idCajaAhorro)
    End Function

    Public Function consultaCajaAhorroActual(ByVal idNave As Int32) As DataTable
        Dim objDA As New Datos.CajaAhorroDA
        Return objDA.consultaCajaAhorroActual(idNave)
    End Function

    Public Function consultaResumenCajaCerrada(ByVal idCajaAhorro As Int32) As DataTable
        Dim objDA As New Datos.CajaAhorroDA
        Return objDA.consultaResumenCajaCerrada(idCajaAhorro)
    End Function

    Public Function consultaGanaInteresPeriodo(ByVal idCaja As Int32, ByVal idNave As Int32) As DataTable
        Dim objDA As New Datos.CajaAhorroDA
        Return objDA.consultaGanaInteresPeriodo(idCaja, idNave)
    End Function

    Public Function NavesAsignadasAsistenteCaja() As DataTable
        Dim objDa As New Datos.CajaAhorroDA
        Return objDa.NavesAsignadasAsistenteCaja()
    End Function

    Public Function obtenerSaldosPrestamosCaja(ByVal idCajaAhorro As Int32) As DataTable
        Dim objDa As New Datos.CajaAhorroDA
        Return objDa.obtenerSaldosPrestamosCaja(idCajaAhorro)
    End Function

End Class
