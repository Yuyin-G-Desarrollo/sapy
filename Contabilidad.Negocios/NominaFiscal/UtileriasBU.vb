Public Class UtileriasBU
    Public Function consultarPatronEmpresa() As DataTable
        Dim objDatos As New Datos.UtileriasDA
        Dim dtListado As New DataTable

        dtListado = objDatos.consultarPatronEmpresa()
        If Not dtListado Is Nothing Then
            If dtListado.Rows.Count > 1 Then
                Dim dtRow As DataRow = dtListado.NewRow
                dtRow("ID") = 0
                dtRow("PATRON") = ""
                dtListado.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtListado
    End Function

    Public Function consultarPatronEmpresaPorAnio(ByVal anio As Int32) As DataTable
        Dim objDatos As New Datos.UtileriasDA
        Dim dtListado As New DataTable

        dtListado = objDatos.consultarPatronEmpresaPorAnio(anio)
        If Not dtListado Is Nothing Then
            If dtListado.Rows.Count > 1 Then
                Dim dtRow As DataRow = dtListado.NewRow
                dtRow("ID") = 0
                dtRow("PATRON") = ""
                dtListado.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtListado
    End Function
    Public Function consultarPatronEmpresaComisiones() As DataTable
        Dim objDatos As New Datos.UtileriasDA
        Dim dtListado As New DataTable

        dtListado = objDatos.consultarPatronEmpresaComisiones()
        If Not dtListado Is Nothing Then
            If dtListado.Rows.Count > 0 Then
                Dim dtRow As DataRow = dtListado.NewRow
                dtRow("ID") = 0
                dtRow("PATRON") = ""
                dtListado.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtListado
    End Function


    Public Function validarPerfilContabilidad() As Boolean
        Dim objDatos As New Datos.UtileriasDA
        Dim dtResultado As New DataTable
        Dim resultado As Boolean = False

        dtResultado = objDatos.validarPerfilContabilidad()
        If Not dtResultado Is Nothing Then
            resultado = CBool(dtResultado.Rows(0)("RESULTADO").ToString)
        End If

        Return resultado
    End Function

    Public Function consultarColaboradoresAsegurados(ByVal patronId As Integer, ByVal naveId As Integer, ByVal nombre As String, ByVal externo As Boolean, ByVal filtrarActivos As Boolean) As DataTable
        Dim objDatos As New Datos.UtileriasDA
        Return objDatos.consultarColaboradoresAsegurados(patronId, naveId, nombre, externo, filtrarActivos)
    End Function

    Public Function consultaPuestosFiscales(ByVal idPatron As Int32) As DataTable
        Dim dtPuestos As New DataTable
        Dim objDa As New Datos.UtileriasDA

        dtPuestos = objDa.consultaPuestosFiscales(idPatron)

        If Not dtPuestos Is Nothing Then
            If dtPuestos.Rows.Count > 0 Then
                Dim dtRow As DataRow = dtPuestos.NewRow
                dtRow("IdPuesto") = 0
                dtRow("Puesto") = ""
                dtPuestos.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtPuestos
    End Function

    Public Function consultaTipoTrabajador(ByVal idPatron As Int32) As DataTable
        Dim dtTipoCol As New DataTable
        Dim objDa As New Datos.UtileriasDA

        dtTipoCol = objDa.consultaTipoTrabajador(idPatron)

        If Not dtTipoCol Is Nothing Then
            If dtTipoCol.Rows.Count > 1 Then
                Dim dtRow As DataRow = dtTipoCol.NewRow
                dtRow("idTipoColaborador") = 0
                dtRow("tipoColaborador") = ""
                dtTipoCol.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtTipoCol
    End Function

    Public Function consultaTipoSalario() As DataTable
        Dim dtTipoSal As New DataTable
        Dim objDa As New Datos.UtileriasDA

        dtTipoSal = objDa.consultaTipoSalario

        If Not dtTipoSal Is Nothing Then
            If dtTipoSal.Rows.Count > 1 Then
                Dim dtRow As DataRow = dtTipoSal.NewRow
                dtRow("idTipoSalario") = 0
                dtRow("TipoSalario") = ""
                dtTipoSal.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtTipoSal
    End Function

    Public Function consultaTipoJornada() As DataTable
        Dim dtTipoJornada As New DataTable
        Dim objDa As New Datos.UtileriasDA

        dtTipoJornada = objDa.consultaTipoJornada

        If Not dtTipoJornada Is Nothing Then
            If dtTipoJornada.Rows.Count > 1 Then
                Dim dtRow As DataRow = dtTipoJornada.NewRow
                dtRow("idTipoJornada") = 0
                dtRow("TipoJornada") = ""
                dtTipoJornada.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtTipoJornada
    End Function

    Public Function consultaTipoDescuento() As DataTable
        Dim dtTipoDescuento As New DataTable
        Dim objDa As New Datos.UtileriasDA

        dtTipoDescuento = objDa.consultaTipoDescuento

        If Not dtTipoDescuento Is Nothing Then
            If dtTipoDescuento.Rows.Count > 1 Then
                Dim dtRow As DataRow = dtTipoDescuento.NewRow
                dtRow("idDescuento") = 0
                dtRow("Descuento") = ""
                dtTipoDescuento.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtTipoDescuento
    End Function

    Public Function consultaSalarioMinimoDF() As Double
        Dim objDatos As New Datos.UtileriasDA
        Dim dtSalarioMinimoDF As New DataTable
        Dim salarioMinimoDF As Double = 0.0

        dtSalarioMinimoDF = objDatos.consultaSalarioMinimoDF()
        If Not dtSalarioMinimoDF Is Nothing Then
            If dtSalarioMinimoDF.Rows.Count > 0 Then
                salarioMinimoDF = CDbl(dtSalarioMinimoDF.Rows(0)("salarioMinimoDF").ToString)
            End If
        End If

        Return salarioMinimoDF
    End Function

    Public Function consultaSalarioMinimoUMI() As Double
        Dim objDatos As New Datos.UtileriasDA
        Dim dtSalarioMinimoUMI As New DataTable
        Dim salarioMinimoUMI As Double = 0.0

        dtSalarioMinimoUMI = objDatos.consultaSalarioMinimoUMI()
        If Not dtSalarioMinimoUMI Is Nothing Then
            If dtSalarioMinimoUMI.Rows.Count > 0 Then
                salarioMinimoUMI = CDbl(dtSalarioMinimoUMI.Rows(0)("salarioMinimoUMI").ToString)
            End If
        End If

        Return salarioMinimoUMI
    End Function

    Public Function consultaSalarioMinimo() As Double
        Dim objDatos As New Datos.UtileriasDA
        Dim dtSalarioMinimoDF As New DataTable
        Dim salarioMinimoDF As Double = 0.0

        dtSalarioMinimoDF = objDatos.consultaSalarioMinimo()
        If Not dtSalarioMinimoDF Is Nothing Then
            If dtSalarioMinimoDF.Rows.Count > 0 Then
                salarioMinimoDF = CDbl(dtSalarioMinimoDF.Rows(0)("salarioMinimo").ToString)
            End If
        End If

        Return salarioMinimoDF
    End Function

    Public Function consultaUMA() As Double
        Dim objDatos As New Datos.UtileriasDA
        Dim umaDT As New DataTable
        Dim uma As Double = 0.0

        umaDT = objDatos.consultaUMA()
        If Not umaDT Is Nothing Then
            If umaDT.Rows.Count > 0 Then
                uma = CDbl(umaDT.Rows(0)("UMA").ToString)
            End If
        End If

        Return uma
    End Function

    Public Function consultaFactorIMSS() As DataTable
        Dim objDatos As New Datos.UtileriasDA
        Return objDatos.consultaFactorIMSS()
    End Function

    Public Function consultaPorcentajePremios(ByVal colaboradorId As Integer) As DataTable
        Dim objDatos As New Datos.UtileriasDA
        Return objDatos.consultaPorcentajePremios(colaboradorId)
    End Function

    Public Function consultaTarifa(ByVal sueldo As Double, ByVal opcTipo As Int16) As Entidades.TarifaMensualSemanal
        Dim objDatos As New Datos.UtileriasDA
        Dim dtTarifa As New DataTable
        Dim tarifa As New Entidades.TarifaMensualSemanal

        dtTarifa = objDatos.consultaTarifa(sueldo, opcTipo)
        If Not dtTarifa Is Nothing Then
            If dtTarifa.Rows.Count > 0 Then
                tarifa.TMSLimiteinferior = CDbl(dtTarifa.Rows(0)("limiteInferior").ToString)
                tarifa.TMSLimitesuperior = CDbl(dtTarifa.Rows(0)("limiteSuperior").ToString)
                tarifa.TMSCuotafija = CDbl(dtTarifa.Rows(0)("coutaFija").ToString)
                tarifa.TMSPorcentajeexcedente = CDbl(dtTarifa.Rows(0)("porcentajeExcedente").ToString)
                tarifa.TMSTarifaId = CInt(dtTarifa.Rows(0)("tam_tarifamensualsemanalid").ToString)
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

        Return tarifa
    End Function

    Public Function consultaSubsidioEmpleo(ByVal sueldo As Double, ByVal opcTipo As Int16) As Entidades.SubsidioEmpleo
        Dim objDatos As New Datos.UtileriasDA
        Dim dtSubsidio As New DataTable
        Dim subsidio As New Entidades.SubsidioEmpleo

        dtSubsidio = objDatos.consultaSubsidioEmpleo(sueldo, opcTipo)
        If Not dtSubsidio Is Nothing Then
            If dtSubsidio.Rows.Count > 0 Then
                subsidio.SELimiteinferior = CDbl(dtSubsidio.Rows(0)("limiteInferior").ToString)
                subsidio.SELimitesuperior = CDbl(dtSubsidio.Rows(0)("limiteSuperior").ToString)
                subsidio.SEValorspe = CDbl(dtSubsidio.Rows(0)("subsidio").ToString)
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

        Return subsidio
    End Function

    Public Function consultaPuestosReales(ByVal idPuestoFiscal As Int32) As DataTable
        Dim dtPuestosR As New DataTable
        Dim objDa As New Datos.UtileriasDA

        dtPuestosR = objDa.consultaPuestosReales(idPuestoFiscal)

        If Not dtPuestosR Is Nothing Then
            If dtPuestosR.Rows.Count > 0 Then
                Dim dtRow As DataRow = dtPuestosR.NewRow
                dtRow("IdPuestoR") = 0
                dtRow("PuestoR") = ""
                dtPuestosR.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtPuestosR
    End Function

    Public Function consultaSalarioDiarioPorPuesto(ByVal idPuestoReal As Int32) As DataTable
        Dim dtSDI As New DataTable
        Dim objDa As New Datos.UtileriasDA

        dtSDI = objDa.consultaSalarioDiarioPorPuesto(idPuestoReal)

        Return dtSDI
    End Function

    Public Function existePeriodoNomina(ByVal patronId As Integer, ByVal opcOperacion As Int16, ByVal fecha As String) As Boolean
        Dim objDatos As New Datos.UtileriasDA
        Dim dtExiste As New DataTable
        Dim existe As Boolean = False

        dtExiste = objDatos.existePeriodoNomina(patronId, opcOperacion, fecha)
        If Not dtExiste Is Nothing Then
            If dtExiste.Rows.Count > 0 Then
                existe = CBool(dtExiste.Rows(0)("Existe").ToString)
            End If
        End If

        Return existe
    End Function

    Public Function existeConfiguracionVacaciones(ByVal patronId As Integer, ByVal fechaMovimiento As Date) As Boolean
        Dim objDatos As New Datos.UtileriasDA
        Dim dtExiste As New DataTable
        Dim existe As Boolean = False

        dtExiste = objDatos.existeConfiguracionVacaciones(patronId, fechaMovimiento)
        If Not dtExiste Is Nothing Then
            If dtExiste.Rows.Count > 0 Then
                existe = CBool(dtExiste.Rows(0)("Existe").ToString)
            End If
        End If

        Return existe
    End Function

    Public Function consultaPatronPorNave(ByVal idUsuario As Int32, ByVal idNave As Int32) As DataTable
        Dim objDatos As New Datos.UtileriasDA
        Dim dtListado As New DataTable

        dtListado = objDatos.consultaPatronPorNave(idUsuario, idNave)
        If Not dtListado Is Nothing Then
            If dtListado.Rows.Count > 0 Then
                Dim dtRow As DataRow = dtListado.NewRow
                dtRow("ID") = 0
                dtRow("PATRON") = ""
                dtListado.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtListado
    End Function

    Public Function consultaListadoEstatus(ByVal tipoMovimiento As String) As DataTable
        Dim objDatos As New Datos.UtileriasDA
        Dim dtListado As New DataTable

        dtListado = objDatos.consultaListadoEstatus(tipoMovimiento)
        If Not dtListado Is Nothing Then
            If dtListado.Rows.Count > 1 Then
                Dim dtRow As DataRow = dtListado.NewRow
                dtRow("ID") = 0
                dtRow("estatus") = ""
                dtListado.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtListado
    End Function

    ''' <summary>
    ''' Consulta los dias que le corresponden de vacaciones, años laborando, y los dias transcurridos del año con respecto a la fecha de ingreso y la fecha de baja
    ''' </summary>
    ''' <param name="FechaIngreso"></param>
    ''' <param name="FechaBaja"></param>
    ''' <returns>DataTable diva_diasvacaciones => DiasVacaciones Corresponden, diva_anios => Numero de años laborando, 
    ''' DiasTranscurridosDelAño => dias que han pasado de inicio de año hasta la Fecha de baja</returns>
    ''' <remarks></remarks>
    Public Function ConsultaDiasCorrespondenVacaciones(ByVal FechaIngreso As Date, ByVal FechaBaja As Date) As DataTable
        Dim objDatos As New Datos.UtileriasDA
        Dim dtListado As New DataTable
        Dim Vacaciones As Double = 0

        dtListado = objDatos.ConsultaDiasCorrespondenVacaciones(FechaIngreso, FechaBaja)


        Return dtListado
    End Function

    Public Function ObtenerPeriodoNominaID(ByVal PatronID As Integer, ByVal Fecha As Date) As Integer
        Dim objDatos As New Datos.UtileriasDA
        Dim PeriodoNominaID As Integer = 0
        PeriodoNominaID = objDatos.ObtenerPeriodoNominaID(PatronID, Fecha)
        Return PeriodoNominaID
    End Function

    Public Function ConsultarPeriodosNomina(ByVal NaveID As Integer) As DataTable
        Dim objDatos As New Datos.UtileriasDA

        Return objDatos.ConsultarPeriodosNomina(NaveID)
    End Function

    Public Function ConsultaDiasAguinaldo() As Integer
        Dim objDatos As New Datos.UtileriasDA

        Return objDatos.ConsultaDiasAguinaldo()
    End Function

    Public Function consultaDepartamentosFiscales(ByVal idPatron As Int32) As DataTable
        Dim objDatos As New Datos.UtileriasDA
        Dim dtListado As New DataTable

        dtListado = objDatos.consultaDepartamentosFiscales(idPatron)
        If Not dtListado Is Nothing Then
            If dtListado.Rows.Count > 0 Then
                Dim dtRow As DataRow = dtListado.NewRow
                dtRow("idDeptoFiscal") = 0
                dtRow("deptoFiscal") = ""
                dtListado.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtListado
    End Function

    Public Function consultaDepartamentosREales(ByVal idDeptoFiscal As Int32) As DataTable
        Dim objDatos As New Datos.UtileriasDA
        Dim dtListado As New DataTable

        dtListado = objDatos.consultaDepartamentosREales(idDeptoFiscal)
        If Not dtListado Is Nothing Then
            If dtListado.Rows.Count > 0 Then
                Dim dtRow As DataRow = dtListado.NewRow
                dtRow("id") = 0
                dtRow("depto") = ""
                dtListado.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtListado
    End Function

    Public Function consultaUnidadMedicaFamiliar() As DataTable
        Dim objDatos As New Datos.UtileriasDA
        Dim dtListado As New DataTable

        dtListado = objDatos.consultaUnidadMedicaFamiliar()
        If Not dtListado Is Nothing Then
            If dtListado.Rows.Count > 0 Then
                Dim dtRow As DataRow = dtListado.NewRow
                dtRow("id") = 0
                dtRow("umf") = ""
                dtListado.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtListado
    End Function

    Public Function validaCurpColaborador(ByVal idColaborador As Int32) As DataTable
        Dim objDatos As New Datos.UtileriasDA
        Dim dtDatos As New DataTable

        dtDatos = objDatos.validaCurpColaborador(idColaborador)

        Return dtDatos
    End Function

    Public Function validaCurpRFCAlta(ByVal aPaterno As String, ByVal aMaterno As String, ByVal nombre As String,
                                      ByVal fechaNacimiento As String, ByVal curpCapturada As String, ByVal rfcCapturado As String) As DataTable
        Dim objDatos As New Datos.UtileriasDA
        Dim dtDatos As New DataTable

        dtDatos = objDatos.validaCurpRFCAlta(aPaterno, aMaterno, nombre, fechaNacimiento, curpCapturada, rfcCapturado)

        Return dtDatos
    End Function

    Public Function consultarTipoMovimientos() As DataTable
        Dim objDatos As New Datos.UtileriasDA
        Return objDatos.consultarTipoMovimientos()

    End Function

    Public Function consultarPeriodosNominaxAnioBU(ByVal patronId As Int32, ByVal anio As Int32) As DataTable
        Dim objDatos As New Datos.UtileriasDA
        Dim dtDatos As New DataTable

        dtDatos = objDatos.consultarPeriodosNominaxAnioDA(patronId, anio)
        Return dtDatos
    End Function

    Public Function consultarPeriodosNominaxAnioAlBU(ByVal patronId As Int32, ByVal anio As Int32) As DataTable
        Dim objDatos As New Datos.UtileriasDA
        Dim dtDatos As New DataTable

        dtDatos = objDatos.consultarPeriodosNominaxAnioAlDA(patronId, anio)
        Return dtDatos
    End Function

    Public Function consultaPatronPorNaveIMSS(ByVal idUsuario As Int32, ByVal idNave As Int32) As DataTable
        Dim objDatos As New Datos.UtileriasDA
        Dim dtListado As New DataTable

        dtListado = objDatos.consultaPatronPorNaveIMSS(idUsuario, idNave)
        If Not dtListado Is Nothing Then
            If dtListado.Rows.Count > 0 Then
                Dim dtRow As DataRow = dtListado.NewRow
                dtRow("ID") = 0
                dtRow("PATRON") = ""
                dtListado.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtListado
    End Function

End Class
