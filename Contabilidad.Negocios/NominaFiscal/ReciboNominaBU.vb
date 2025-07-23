Public Class ReciboNominaBU
    Public Function obtenerEstatusRecibosNomina() As DataTable
        Dim objDatos As New Datos.ReciboNominaDA
        Return objDatos.obtenerEstatusRecibosNomina
    End Function

    Public Function consultarListaRecibosNomina(ByVal patronId As Integer, ByVal estatusId As Integer, ByVal filtroTimbrado As Boolean,
                                                ByVal timbrado As Boolean, ByVal periodoId As Integer, ByVal rango As Boolean,
                                                ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal tipo As String,
                                                ByVal colaboradorIds As String) As DataTable
        Dim objDatos As New Datos.ReciboNominaDA
        Return objDatos.consultarListaRecibosNomina(patronId, estatusId, filtroTimbrado, timbrado, periodoId, rango, fechaInicio, fechaFin, tipo, colaboradorIds)
    End Function

    Public Function consultarRecibosTimbrados(ByVal patronId As Integer, ByVal estatusId As Integer, ByVal filtroTimbrado As Boolean,
                                              ByVal timbrado As Boolean, ByVal periodoId As Integer, ByVal rango As Boolean,
                                              ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal tipo As String,
                                              ByVal colaboradorIds As String) As DataTable
        Dim objDatos As New Datos.ReciboNominaDA
        Return objDatos.consultarRecibosTimbrados(patronId, estatusId, filtroTimbrado, timbrado, periodoId, rango, fechaInicio, fechaFin, tipo, colaboradorIds)
    End Function

    Public Function validarEstatus(ByVal timNominaId As Integer, ByVal opcAccion As Integer) As String
        Dim objDatos As New Datos.ReciboNominaDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.validarEstatus(timNominaId, opcAccion)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function consultarDatosEmpresa(ByVal patronId As Int32) As DataTable
        Dim objDA As New Datos.ReciboNominaDA
        Return objDA.consultarDatosEmpresa(patronId)
    End Function

    Public Function consultarInformacionRecibo(ByVal timNominaId As Int32) As Entidades.TimbreNominaFiscal
        Dim objDA As New Datos.ReciboNominaDA
        Dim tmbNominaFiscal As New Entidades.TimbreNominaFiscal
        Dim dtInformacion As New DataTable

        dtInformacion = objDA.consultarInformacionRecibo(timNominaId)
        If Not dtInformacion Is Nothing Then
            If dtInformacion.Rows.Count > 0 Then
                'Otros
                tmbNominaFiscal.TNFTimbreNominaFiscalId = CInt(dtInformacion.Rows(0)("tinf_timbreNominaFiscalId").ToString)
                tmbNominaFiscal.TNFPatronId = CInt(dtInformacion.Rows(0)("tinf_patronId").ToString)
                tmbNominaFiscal.TNFNominaFiscalId = CInt(dtInformacion.Rows(0)("tinf_nominaFiscalId").ToString)
                tmbNominaFiscal.TNFBajaImssId = CInt(dtInformacion.Rows(0)("tinf_bajaImssId").ToString)
                tmbNominaFiscal.TNFPeriodoNominaFiscalId = CInt(dtInformacion.Rows(0)("tinf_periodoNominaFiscalId").ToString)
                tmbNominaFiscal.TNFXml = dtInformacion.Rows(0)("tinf_xml").ToString
                tmbNominaFiscal.TNFPdf = dtInformacion.Rows(0)("tinf_pdf").ToString
                tmbNominaFiscal.TNFEstatusId = CInt(dtInformacion.Rows(0)("tinf_estatusId").ToString)
                tmbNominaFiscal.TNFTipo = dtInformacion.Rows(0)("tinf_tipo").ToString
                tmbNominaFiscal.TNFTimbrado = CBool(dtInformacion.Rows(0)("tinf_timbrado").ToString)
                tmbNominaFiscal.TNFUsuarioCreoId = CInt(dtInformacion.Rows(0)("tinf_usuarioCreoId").ToString)
                tmbNominaFiscal.TNFFechaCreacion = CDate(dtInformacion.Rows(0)("tinf_fechaCreacion").ToString)
                tmbNominaFiscal.TNFEmisorRegimenDescripcion = dtInformacion.Rows(0)("empr_regimen").ToString
                tmbNominaFiscal.TNFTipoJornadaPdf = dtInformacion.Rows(0)("tipoJornadaPdf").ToString
                tmbNominaFiscal.TNFSalario = dtInformacion.Rows(0)("Salario").ToString
                tmbNominaFiscal.TNFTipoNominaPdf = dtInformacion.Rows(0)("tipoNominaPdf").ToString
                tmbNominaFiscal.TNFTipoContratoPdf = dtInformacion.Rows(0)("tipoContratoPdf").ToString
                tmbNominaFiscal.TNFTipoRegimenPdf = dtInformacion.Rows(0)("tipoRegimenPdf").ToString
                tmbNominaFiscal.TNFPeriodicidadPagoPdf = dtInformacion.Rows(0)("periodicidadPagoPdf").ToString
                tmbNominaFiscal.TNFUsoCfdiPdf = dtInformacion.Rows(0)("usoCfdiPdf").ToString
                tmbNominaFiscal.TNFClaveEntFedPdf = dtInformacion.Rows(0)("claveEntFedPdf").ToString
                tmbNominaFiscal.TNFFormaPagoPdf = dtInformacion.Rows(0)("formaPagoPdf").ToString
                tmbNominaFiscal.TNFMetodoPagoPdf = dtInformacion.Rows(0)("metodoPagoPdf").ToString
                tmbNominaFiscal.TNFTipoComprobantePdf = dtInformacion.Rows(0)("tipoComprobantePdf").ToString
                'Comprobante
                tmbNominaFiscal.TNFVersion = dtInformacion.Rows(0)("tinf_version").ToString
                tmbNominaFiscal.TNFSerie = dtInformacion.Rows(0)("tinf_serie").ToString
                tmbNominaFiscal.TNFFolio = CInt(dtInformacion.Rows(0)("tinf_folio").ToString)
                tmbNominaFiscal.TNFFecha = CDate(dtInformacion.Rows(0)("tinf_fecha").ToString)
                tmbNominaFiscal.TNFFormaPago = dtInformacion.Rows(0)("tinf_formaPago").ToString
                tmbNominaFiscal.TNFNoCertificado = dtInformacion.Rows(0)("tinf_noCertificado").ToString
                tmbNominaFiscal.TNFCertificado = dtInformacion.Rows(0)("tinf_certificado").ToString
                tmbNominaFiscal.TNFSubTotal = CDbl(dtInformacion.Rows(0)("tinf_subTotal").ToString)
                tmbNominaFiscal.TNFDescuento = CDbl(dtInformacion.Rows(0)("tinf_descuento").ToString)
                tmbNominaFiscal.TNFMoneda = dtInformacion.Rows(0)("tinf_moneda").ToString
                tmbNominaFiscal.TNFTotal = CDbl(dtInformacion.Rows(0)("tinf_total").ToString)
                tmbNominaFiscal.TNFTipoDeComprobante = dtInformacion.Rows(0)("tinf_tipoDeComprobante").ToString
                tmbNominaFiscal.TNFMetodoDePago = dtInformacion.Rows(0)("tinf_metodoDePago").ToString
                tmbNominaFiscal.TNFLugarExpedicion = dtInformacion.Rows(0)("tinf_lugarExpedicion").ToString
                'Emisor
                tmbNominaFiscal.TNFEmisorRfc = dtInformacion.Rows(0)("tinf_emisorRfc").ToString
                tmbNominaFiscal.TNFEmisorRazonSocial = dtInformacion.Rows(0)("tinf_emisorRazonSocial").ToString
                tmbNominaFiscal.TNFEmisorRegimen = dtInformacion.Rows(0)("tinf_emisorRegimen").ToString
                'Receptor
                tmbNominaFiscal.TNFReceptorRfc = dtInformacion.Rows(0)("tinf_receptorRfc").ToString
                tmbNominaFiscal.TNFReceptorNombre = dtInformacion.Rows(0)("tinf_receptorNombre").ToString
                tmbNominaFiscal.TNFUsoCfdi = dtInformacion.Rows(0)("tinf_usoCfdi").ToString
                'Concepto
                tmbNominaFiscal.TNFClaveProdServ = dtInformacion.Rows(0)("tinf_claveProdServ").ToString
                tmbNominaFiscal.TNFCantidad = CInt(dtInformacion.Rows(0)("tinf_cantidad").ToString)
                tmbNominaFiscal.TNFUnidad = dtInformacion.Rows(0)("tinf_unidad").ToString
                tmbNominaFiscal.TNFDescripcion = dtInformacion.Rows(0)("tinf_descripcion").ToString
                tmbNominaFiscal.TNFValorUnitario = CDbl(dtInformacion.Rows(0)("tinf_valorUnitario").ToString)
                tmbNominaFiscal.TNFImporte = CDbl(dtInformacion.Rows(0)("tinf_importe").ToString)
                tmbNominaFiscal.TNFConceptoDescuento = CDbl(dtInformacion.Rows(0)("tinf_conceptoDescuento").ToString)
                'ComplementoNomina
                tmbNominaFiscal.TNFVersionNom = dtInformacion.Rows(0)("tinf_versionNom").ToString
                tmbNominaFiscal.TNFTipoNomina = dtInformacion.Rows(0)("tinf_tipoNomina").ToString
                tmbNominaFiscal.TNFFechaPago = CDate(dtInformacion.Rows(0)("tinf_fechaPago").ToString)
                tmbNominaFiscal.TNFFechaInicialPago = CDate(dtInformacion.Rows(0)("tinf_fechaInicialPago").ToString)
                tmbNominaFiscal.TNFFechaFinalPago = CDate(dtInformacion.Rows(0)("tinf_fechaFinalPago").ToString)
                tmbNominaFiscal.TNFNumDiasPagados = CDbl(dtInformacion.Rows(0)("tinf_numDiasPagados").ToString)
                tmbNominaFiscal.TNFTotalPercepciones = CDbl(dtInformacion.Rows(0)("tinf_totalPercepciones").ToString)
                tmbNominaFiscal.TNFTotalDeducciones = CDbl(dtInformacion.Rows(0)("tinf_totalDeducciones").ToString)
                tmbNominaFiscal.TNFTotalOtrosPagos = CDbl(dtInformacion.Rows(0)("tinf_totalOtrosPagos").ToString)
                'ComplementoNomina/Emisor
                tmbNominaFiscal.TNFEmisorCurp = dtInformacion.Rows(0)("tinf_emisorCurp").ToString
                tmbNominaFiscal.TNFRegistroPatronal = dtInformacion.Rows(0)("tinf_registroPatronal").ToString
                'ComplementoNomina/Receptor
                tmbNominaFiscal.TNFReceptorCurp = dtInformacion.Rows(0)("tinf_receptorCurp").ToString
                tmbNominaFiscal.TNFReceptorNumSeguridadSocial = dtInformacion.Rows(0)("tinf_receptorNumSeguridadSocial").ToString
                tmbNominaFiscal.TNFReceptorFechaInicioRelLaboral = CDate(dtInformacion.Rows(0)("tinf_receptorFechaInicioRelLaboral").ToString)
                tmbNominaFiscal.TNFReceptorAntiguedad = dtInformacion.Rows(0)("tinf_receptorAntiguedad").ToString
                tmbNominaFiscal.TNFReceptorTipoContrato = dtInformacion.Rows(0)("tinf_receptorTipoContrato").ToString
                tmbNominaFiscal.TNFReceptorTipoJornada = dtInformacion.Rows(0)("tinf_receptorTipoJornada").ToString
                tmbNominaFiscal.TNFReceptorTipoRegimen = dtInformacion.Rows(0)("tinf_receptorTipoRegimen").ToString
                tmbNominaFiscal.TNFReceptorNumEmpleado = dtInformacion.Rows(0)("tinf_receptorNumEmpleado").ToString
                tmbNominaFiscal.TNFReceptorRiesgoPuesto = dtInformacion.Rows(0)("tinf_receptorRiesgoPuesto").ToString
                tmbNominaFiscal.TNFReceptorPeriodicidadPago = dtInformacion.Rows(0)("tinf_receptorPeriodicidadPago").ToString
                tmbNominaFiscal.TNFReceptorSalarioBaseCotApor = CDbl(dtInformacion.Rows(0)("tinf_receptorSalarioBaseCotApor").ToString)
                tmbNominaFiscal.TNFReceptorSalarioDiarioIntegrado = CDbl(dtInformacion.Rows(0)("tinf_receptorSalarioDiarioIntegrado").ToString)
                tmbNominaFiscal.TNFReceptorClaveEntFed = dtInformacion.Rows(0)("tinf_receptorClaveEntFed").ToString
                'ComplementoNomina/Percepciones
                tmbNominaFiscal.TNFTotalSueldos = CDbl(dtInformacion.Rows(0)("tinf_totalSueldos").ToString)
                tmbNominaFiscal.TNFPercepcionesTotalGravado = CDbl(dtInformacion.Rows(0)("tinf_percepcionesTotalGravado").ToString)
                tmbNominaFiscal.TNFPercepcionesTotalExento = CDbl(dtInformacion.Rows(0)("tinf_percepcionesTotalExento").ToString)
                'ComplementoNomina/Deducciones
                tmbNominaFiscal.TNFDeduccionesTotalOtras = CDbl(dtInformacion.Rows(0)("tinf_deduccionesTotalOtras").ToString)
                tmbNominaFiscal.TNFDeduccionesTotalImpuestosRet = CDbl(dtInformacion.Rows(0)("tinf_deduccionesTotalImpuestosRet").ToString)
                'ComplementoTimbrado
                tmbNominaFiscal.TNFUuid = dtInformacion.Rows(0)("tinf_uuid").ToString
                tmbNominaFiscal.TNFFechaTimbrado = CDate(dtInformacion.Rows(0)("tinf_fechaTimbrado").ToString)
                tmbNominaFiscal.TNFNoCertificadoSAT = dtInformacion.Rows(0)("tinf_noCertificadoSAT").ToString
                tmbNominaFiscal.TNFSello = dtInformacion.Rows(0)("tinf_sello").ToString
                tmbNominaFiscal.TNFSelloSAT = dtInformacion.Rows(0)("tinf_selloSAT").ToString
                tmbNominaFiscal.TNFCadenaOriginalComplemento = dtInformacion.Rows(0)("tinf_cadenaOriginalComplemento").ToString
                tmbNominaFiscal.TNFUuidCancelacion = dtInformacion.Rows(0)("tinf_uuidCancelacion").ToString
                tmbNominaFiscal.TNFFechaCancelacion = CDate(dtInformacion.Rows(0)("tinf_fechaCancelacion").ToString)
                tmbNominaFiscal.TNFUsuarioCancelo = CInt(dtInformacion.Rows(0)("tinf_usuarioCancelo").ToString)
                tmbNominaFiscal.TNFMotivoCancelacion = dtInformacion.Rows(0)("tinf_motivoCancelacion").ToString
                tmbNominaFiscal.TNFXmlCancelacion = dtInformacion.Rows(0)("tinf_xmlCancelacion").ToString
                tmbNominaFiscal.TNFPdfCancelacion = dtInformacion.Rows(0)("tinf_pdfCancelacion").ToString
                tmbNominaFiscal.TNFCancelado = CBool(dtInformacion.Rows(0)("cancelado").ToString)
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

        Return tmbNominaFiscal
    End Function

    Public Function consultarInformacionTimbrarPercepciones(ByVal timNominaId As Int32) As List(Of Entidades.TimbrePercepcion)
        Dim objDA As New Datos.ReciboNominaDA
        Dim tmbPercepcion As Entidades.TimbrePercepcion
        Dim lstPercepciones As New List(Of Entidades.TimbrePercepcion)
        Dim dtInformacion As New DataTable

        dtInformacion = objDA.consultarInformacionTimbrarPercepciones(timNominaId)
        If Not dtInformacion Is Nothing Then
            If dtInformacion.Rows.Count > 0 Then
                For Each row As DataRow In dtInformacion.Rows
                    tmbPercepcion = New Entidades.TimbrePercepcion
                    tmbPercepcion.TPTimbrePercepcionId = CInt(row.Item("tiper_timbrePercepcionId").ToString)
                    tmbPercepcion.TPTimbreNominaFiscalId = CInt(row.Item("tiper_timbreNominaFiscalId").ToString)
                    tmbPercepcion.TPTipoPercepcion = row.Item("tiper_tipoPercepcion").ToString
                    tmbPercepcion.TPClavePercepcion = row.Item("tiper_clavePercepcion").ToString
                    tmbPercepcion.TPConceptoPercepcion = row.Item("tiper_conceptoPercepcion").ToString
                    tmbPercepcion.TPImporteGravadoPercepcion = CDbl(row.Item("tiper_importeGravadoPercepcion").ToString)
                    tmbPercepcion.TPImporteExentoPercepcion = CDbl(row.Item("tiper_importeExentoPercepcion").ToString)

                    lstPercepciones.Add(tmbPercepcion)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

        Return lstPercepciones
    End Function

    Public Function consultarInformacionTimbrarDeducciones(ByVal timNominaId As Int32) As List(Of Entidades.TimbreDeduccion)
        Dim objDA As New Datos.ReciboNominaDA
        Dim tmbDeduccion As Entidades.TimbreDeduccion
        Dim lstDeducciones As New List(Of Entidades.TimbreDeduccion)
        Dim dtInformacion As New DataTable

        dtInformacion = objDA.consultarInformacionTimbrarDeducciones(timNominaId)
        If Not dtInformacion Is Nothing Then
            If dtInformacion.Rows.Count > 0 Then
                For Each row As DataRow In dtInformacion.Rows
                    tmbDeduccion = New Entidades.TimbreDeduccion
                    tmbDeduccion.TDTimbreDeduccionId = CInt(row.Item("tided_timbreDeduccionId").ToString)
                    tmbDeduccion.TDTimbreNominaFiscalId = CInt(row.Item("tided_timbreNominaFiscalId").ToString)
                    tmbDeduccion.TDTipoDeduccion = row.Item("tided_tipoDeduccion").ToString
                    tmbDeduccion.TDClaveDeduccion = row.Item("tided_claveDeduccion").ToString
                    tmbDeduccion.TDConceptoDeduccion = row.Item("tided_conceptoDeduccion").ToString
                    tmbDeduccion.TFImporteDeduccion = CDbl(row.Item("tided_importeDeduccion").ToString)

                    lstDeducciones.Add(tmbDeduccion)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

        Return lstDeducciones
    End Function

    Public Function consultarInformacionTimbrarOtrosPagos(ByVal timNominaId As Int32) As List(Of Entidades.TimbreOtrosPagos)
        Dim objDA As New Datos.ReciboNominaDA
        Dim tmbOtroPago As Entidades.TimbreOtrosPagos
        Dim lstOtrosPagos As New List(Of Entidades.TimbreOtrosPagos)
        Dim dtInformacion As New DataTable

        dtInformacion = objDA.consultarInformacionTimbrarOtrosPagos(timNominaId)
        If Not dtInformacion Is Nothing Then
            If dtInformacion.Rows.Count > 0 Then
                For Each row As DataRow In dtInformacion.Rows
                    tmbOtroPago = New Entidades.TimbreOtrosPagos
                    tmbOtroPago.TOPTimbreOtrosPagosId = CInt(row.Item("tiotp_timbreOtrosPagosId").ToString)
                    tmbOtroPago.TOPTimbreNominaFiscalId = CInt(row.Item("tiotp_timbreNominaFiscalId").ToString)
                    tmbOtroPago.TOPTipoOtrosPagos = row.Item("tiotp_tipoOtrosPagos").ToString
                    tmbOtroPago.TOPClaveOtrosPagos = row.Item("tiotp_claveOtrosPagos").ToString
                    tmbOtroPago.TOPConceptoOtrosPagos = row.Item("tiotp_conceptoOtrosPagos").ToString
                    tmbOtroPago.TOPImporteOtrosPagos = CDbl(row.Item("tiotp_importeOtrosPagos").ToString)
                    tmbOtroPago.TOPSubsidioCausado = CDbl(row.Item("tiotp_subsidioCausado").ToString)
                    tmbOtroPago.TOPSaldoAFavor = CDbl(row.Item("tiotp_saldoAFavor").ToString)
                    tmbOtroPago.TOPAnio = CInt(row.Item("tiotp_anio").ToString)
                    tmbOtroPago.TOPRemanenteSalFav = CDbl(row.Item("tiotp_remanenteSalFav").ToString)

                    lstOtrosPagos.Add(tmbOtroPago)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

        Return lstOtrosPagos
    End Function

    Public Function consultarInformacionTimbrarIncapacidades(ByVal timNominaId As Int32) As List(Of Entidades.TimbreIncapacidad)
        Dim objDA As New Datos.ReciboNominaDA
        Dim tmbIncapacidad As Entidades.TimbreIncapacidad
        Dim lstIncapacidades As New List(Of Entidades.TimbreIncapacidad)
        Dim dtInformacion As New DataTable

        dtInformacion = objDA.consultarInformacionTimbrarIncapacidades(timNominaId)
        If Not dtInformacion Is Nothing Then
            If dtInformacion.Rows.Count > 0 Then
                For Each row As DataRow In dtInformacion.Rows
                    tmbIncapacidad = New Entidades.TimbreIncapacidad
                    tmbIncapacidad.TITimbreIncapaidadId = CInt(row.Item("tiinc_timbreIncapaidadId").ToString)
                    tmbIncapacidad.TITimbreNominaFiscalId = CInt(row.Item("tiinc_timbreNominaFiscalId").ToString)
                    tmbIncapacidad.TIDiasIncapacidad = CDbl(row.Item("tiinc_diasIncapacidad").ToString)
                    tmbIncapacidad.TITipoIncapacidad = row.Item("tiinc_tipoIncapacidad").ToString
                    tmbIncapacidad.TIImportemonetario = CDbl(row.Item("tiinc_importemonetario").ToString)
                    tmbIncapacidad.TIDescuento = CDbl(row.Item("tiinc_descuento").ToString)
                    tmbIncapacidad.TITipoDescripcion = row.Item("tiinc_tipoDescripcion").ToString

                    lstIncapacidades.Add(tmbIncapacidad)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

        Return lstIncapacidades
    End Function

    Public Function consultarInformacionTimbrarHorasExtra(ByVal timNominaId As Int32) As List(Of Entidades.TimbreHorasExtra)
        Dim objDA As New Datos.ReciboNominaDA
        Dim tmbHoraExtra As Entidades.TimbreHorasExtra
        Dim lstHorasExtra As New List(Of Entidades.TimbreHorasExtra)
        Dim dtInformacion As New DataTable

        dtInformacion = objDA.consultarInformacionTimbrarHorasExtra(timNominaId)
        If Not dtInformacion Is Nothing Then
            If dtInformacion.Rows.Count > 0 Then
                For Each row As DataRow In dtInformacion.Rows
                    tmbHoraExtra = New Entidades.TimbreHorasExtra
                    tmbHoraExtra.THETimbreHorasExtraId = CInt(row.Item("tihex_timbreHorasExtraId").ToString)
                    tmbHoraExtra.THETimbreNominaFiscalId = CInt(row.Item("tihex_timbreNominaFiscalId").ToString)
                    tmbHoraExtra.THEDias = CInt(row.Item("tihex_dias").ToString)
                    tmbHoraExtra.THETipoHoras = row.Item("tihex_tipoHoras").ToString
                    tmbHoraExtra.THEHorasExtra = CInt(row.Item("tihex_horasExtra").ToString)
                    tmbHoraExtra.THEImportePagado = CDbl(row.Item("tihex_importePagado").ToString)

                    lstHorasExtra.Add(tmbHoraExtra)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

        Return lstHorasExtra
    End Function

    Public Function actualizarInformacionTimbrado(ByVal tmbNominafiscal As Entidades.TimbreNominaFiscal) As String
        Dim objDA As New Datos.ReciboNominaDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDA.actualizarInformacionTimbrado(tmbNominafiscal)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0)("mensaje").ToString
            End If
        End If

        Return resultado
    End Function

    Public Function actualizarCancelacionTimbrado(ByVal tmbNominafiscal As Entidades.TimbreNominaFiscal) As String
        Dim objDA As New Datos.ReciboNominaDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDA.actualizarCancelacionTimbrado(tmbNominafiscal)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0)("mensaje").ToString
            End If
        End If

        Return resultado
    End Function

    Public Function actualizarMotivoSinTimbrar(ByVal timNominaId As Integer, ByVal motivoSinTimbrar As String) As String
        Dim objDA As New Datos.ReciboNominaDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDA.actualizarMotivoSinTimbrar(timNominaId, motivoSinTimbrar)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0)("mensaje").ToString
            End If
        End If

        Return resultado
    End Function

    Public Function consultarInformacionTimbrarCfdiRelacionados(ByVal timNominaId As Int32) As List(Of Entidades.TimbreCfdiRelacionados)
        Dim objDA As New Datos.ReciboNominaDA
        Dim tmbCfdiRelacionado As Entidades.TimbreCfdiRelacionados
        Dim lstCfdiRelacionados As New List(Of Entidades.TimbreCfdiRelacionados)
        Dim dtInformacion As New DataTable

        dtInformacion = objDA.consultarInformacionTimbrarCfdiRelacionados(timNominaId)
        If Not dtInformacion Is Nothing Then
            If dtInformacion.Rows.Count > 0 Then
                For Each row As DataRow In dtInformacion.Rows
                    tmbCfdiRelacionado = New Entidades.TimbreCfdiRelacionados
                    tmbCfdiRelacionado.TCRCfdiRelacionadosId = CInt(row.Item("ticfr_cfdiRelacionadosId").ToString)
                    tmbCfdiRelacionado.TCRTimbreNominaFiscalId = CInt(row.Item("ticfr_timbreNominaFiscalId").ToString)
                    tmbCfdiRelacionado.TCRTimbreNominaFiscalOriginalId = row.Item("ticfr_timbreNominaFiscalOriginalId").ToString
                    tmbCfdiRelacionado.TCRPeriodoNominaFiscalId = row.Item("ticfr_periodoNominaFiscalId").ToString
                    tmbCfdiRelacionado.TCRNominaFiscalId = row.Item("ticfr_nominaFiscalId").ToString
                    tmbCfdiRelacionado.TCRTipoRelacion = row.Item("ticfr_tipoRelacion").ToString
                    tmbCfdiRelacionado.TCRUuid = row.Item("ticfr_uuid").ToString

                    lstCfdiRelacionados.Add(tmbCfdiRelacionado)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

        Return lstCfdiRelacionados
    End Function

    Public Function actualizarRutaPdfCancelacion(ByVal timNominaId As Integer, ByVal rutaPdf As String) As String
        Dim objDA As New Datos.ReciboNominaDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDA.actualizarRutaPdfCancelacion(timNominaId, rutaPdf)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0)("mensaje").ToString
            End If
        End If

        Return resultado
    End Function

    Public Function validaDiferenciasTimbradoNomina(ByVal patronId As Integer, ByVal periodoId As Integer,
                                                    ByVal rango As Boolean, ByVal fechaInicio As Date,
                                                    ByVal fechaFin As Date, ByVal tipo As String) As Boolean
        Dim objDa As New Datos.ReciboNominaDA
        Dim dtResultado As New DataTable
        Dim resultado As Boolean = False

        dtResultado = objDa.validaDiferenciasTimbradoNomina(patronId, periodoId, rango, fechaInicio, fechaFin, tipo)
        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            If CDbl(dtResultado.Rows(0)("Diferencia")) > 1 Then
                resultado = True
            End If
        End If

        Return resultado
    End Function
End Class