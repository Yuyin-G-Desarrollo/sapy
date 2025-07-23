Public Class CreditoInfonavitBU
    Public Function obtenerEstatusCreditoInfonavit() As DataTable
        Dim objDatos As New Datos.CreditoInfonavitDA
        Return objDatos.obtenerEstatusCreditoInfonavit
    End Function

    Public Function consultarListaMovimientosCreditoInfonavit(ByVal patronId As Integer, ByVal estatusId As Integer, ByVal naveId As Integer, ByVal nombre As String,
                                                                 ByVal periodo As Boolean, ByVal fechaInicio As String, ByVal fechaFin As String) As DataTable
        Dim objDatos As New Datos.CreditoInfonavitDA
        Return objDatos.consultarListaMovimientosCreditoInfonavit(patronId, estatusId, naveId, nombre, periodo, fechaInicio, fechaFin)
    End Function

    Public Function obtenerListaTipoMovimientos() As DataTable
        Dim objDatos As New Datos.CreditoInfonavitDA
        Return objDatos.obtenerListaTipoMovimientos
    End Function

    Public Function obtenerListaTipoDescuentos() As DataTable
        Dim objDatos As New Datos.CreditoInfonavitDA
        Return objDatos.obtenerListaTipoDescuentos
    End Function

    Public Function obtenerColaboradorCreditoInfonavit(ByVal colaboradorId As Integer) As Entidades.CreditoInfonavit
        Dim objDatos As New Datos.CreditoInfonavitDA
        Dim dtResultado As New DataTable
        Dim credinfonavit As New Entidades.CreditoInfonavit

        dtResultado = objDatos.obtenerColaboradorCreditoInfonavit(colaboradorId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                credinfonavit.CIColaboradorid = CInt(dtResultado.Rows(0)("ColaboradorId").ToString)
                credinfonavit.CIPatronId = CInt(dtResultado.Rows(0)("PatronId").ToString)
                credinfonavit.CIColaborador = dtResultado.Rows(0)("Colaborador").ToString
                credinfonavit.CIEmpresa = dtResultado.Rows(0)("empr_nombre").ToString
                credinfonavit.CINss = dtResultado.Rows(0)("cono_nss").ToString
                credinfonavit.CIRfc = dtResultado.Rows(0)("codr_rfc").ToString
                credinfonavit.CISalarioBase = CDbl(dtResultado.Rows(0)("cono_salariodiario").ToString)
                credinfonavit.CINumerocredito = dtResultado.Rows(0)("cono_numeroCreditoInfonavit").ToString
                credinfonavit.CITipodescuentoid = CInt(dtResultado.Rows(0)("cono_tipodescuentoinfonavitid").ToString)
                credinfonavit.CIValordescuento = CDbl(dtResultado.Rows(0)("cono_valordescuentoinfonavit").ToString)
                credinfonavit.CIAplicatabladisminucion = CBool(dtResultado.Rows(0)("cono_aplicatabladisminucion").ToString)
            End If
        End If

        Return credinfonavit
    End Function

    Public Function obtenerFechaBimestre() As Date
        Dim objDatos As New Datos.CreditoInfonavitDA
        Dim dtResultado As New DataTable
        Dim fecha As New Date

        dtResultado = objDatos.obtenerFechaBimestre()
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                fecha = CDate(dtResultado.Rows(0)("FechaBimestre").ToString)
            End If
        End If

        Return fecha
    End Function

    Public Function obtenerFechaBimestreFecha(ByVal fechaMov As Date) As Date
        Dim objDatos As New Datos.CreditoInfonavitDA
        Dim dtResultado As New DataTable
        Dim fecha As New Date

        dtResultado = objDatos.obtenerFechaBimestreFecha(fechaMov)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                fecha = CDate(dtResultado.Rows(0)("FechaBimestre").ToString)
            End If
        End If

        Return fecha
    End Function

    Public Function obtenerBimestreActual() As Date
        Dim objDatos As New Datos.CreditoInfonavitDA
        Dim dtResultado As New DataTable
        Dim fecha As New Date

        dtResultado = objDatos.obtenerFechaBimestre()
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                fecha = CDate(dtResultado.Rows(0)("InicioBimestreActual").ToString)
            End If
        End If

        Return fecha
    End Function

    Public Function obtenerDiasSemanaPorTranscurrir(ByVal patronId As Integer, ByVal fechaMovimiento As Date) As DataTable
        Dim objDatos As New Datos.CreditoInfonavitDA
        Return objDatos.obtenerDiasSemanaPorTranscurrir(patronId, fechaMovimiento)
    End Function

    Public Function validarColaboradorMovimiento(ByVal colaboradorId As Integer, ByVal descuentoSemanal As Double, ByVal creditoId As Integer) As String
        Dim objDatos As New Datos.CreditoInfonavitDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.validarColaboradorMovimiento(colaboradorId, descuentoSemanal, creditoId)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function altaMovimientoCreditoInfonavit(ByVal credInfonavit As Entidades.CreditoInfonavit, ByVal carpeta As String, ByVal archivo As String) As String
        Dim objDatos As New Datos.CreditoInfonavitDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.altaMovimientoCreditoInfonavit(credInfonavit, carpeta, archivo)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function consultarMovimientoCreditoInfonavit(ByVal creditoId As Integer) As Entidades.CreditoInfonavit
        Dim objDatos As New Datos.CreditoInfonavitDA
        Dim dtResultado As New DataTable
        Dim credinfonavit As New Entidades.CreditoInfonavit

        dtResultado = objDatos.consultarMovimientoCreditoInfonavit(creditoId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                credinfonavit.CICreditoInfonavitId = CInt(dtResultado.Rows(0)("crInf_creditoinfonavitid").ToString)
                credinfonavit.CIColaboradorid = CInt(dtResultado.Rows(0)("crInf_colaboradorid").ToString)
                credinfonavit.CIPatronId = CInt(dtResultado.Rows(0)("crInf_patronId").ToString)
                credinfonavit.CIAPaterno = dtResultado.Rows(0)("apaterno").ToString
                credinfonavit.CIAMaterno = dtResultado.Rows(0)("amaterno").ToString
                credinfonavit.CINombre = dtResultado.Rows(0)("nombre").ToString
                credinfonavit.CIColaborador = dtResultado.Rows(0)("Colaborador").ToString
                credinfonavit.CIEmpresa = dtResultado.Rows(0)("empr_nombre").ToString
                credinfonavit.CINss = dtResultado.Rows(0)("cono_nss").ToString
                credinfonavit.CIRfc = dtResultado.Rows(0)("codr_rfc").ToString
                credinfonavit.CIMovimientoinfonavitid = CInt(dtResultado.Rows(0)("crInf_movimientoinfonavitid").ToString)
                credinfonavit.CIFecharecepcion = dtResultado.Rows(0)("crInf_fecharecepcion").ToString
                credinfonavit.CIFechamovimiento = dtResultado.Rows(0)("crInf_fechamovimiento").ToString
                credinfonavit.CINumerocredito = dtResultado.Rows(0)("crInf_numerocredito").ToString
                credinfonavit.CITipodescuentoid = CInt(dtResultado.Rows(0)("crInf_tipodescuentoid").ToString)
                credinfonavit.CIValordescuento = CDbl(dtResultado.Rows(0)("crInf_valordescuento").ToString)
                credinfonavit.CIAplicatabladisminucion = CBool(dtResultado.Rows(0)("crInf_aplicatabladisminucion").ToString)
                credinfonavit.CIRutaarchivoretencion = dtResultado.Rows(0)("crInf_rutaarchivoretencion").ToString
                credinfonavit.CISalarioBase = CDbl(dtResultado.Rows(0)("salarioBase").ToString)
                credinfonavit.CISalarioBimestral = CDbl(dtResultado.Rows(0)("crInf_salarioBimestral").ToString)
                credinfonavit.CIImporteretencionmensual = CDbl(dtResultado.Rows(0)("crInf_importeretencionmensual").ToString)
                credinfonavit.CISeguroVivienda = CDbl(dtResultado.Rows(0)("crInf_seguroVivienda").ToString)
                credinfonavit.CIImporteretenerbimestral = CDbl(dtResultado.Rows(0)("crInf_importeretenerbimestral").ToString)
                credinfonavit.CIRetenciondiaria = CDbl(dtResultado.Rows(0)("crInf_retenciondiaria").ToString)
                credinfonavit.CIRetencionsemanalfiscal = CDbl(dtResultado.Rows(0)("crInf_retencionsemanalfiscal").ToString)
                credinfonavit.CISemanasdescontaranual = CDbl(dtResultado.Rows(0)("crInf_semanasdescontaranual").ToString)
                credinfonavit.CINumSemDescontar = CDbl(dtResultado.Rows(0)("crInf_numSemanaDescontar").ToString)
                credinfonavit.CIDescuentosemanal = CDbl(dtResultado.Rows(0)("crInf_descuentosemanal").ToString)
                credinfonavit.CISalarioMinimoDF = CDbl(dtResultado.Rows(0)("crInf_salarioMinimoDF").ToString)
                credinfonavit.CIRetencionMensual = CDbl(dtResultado.Rows(0)("crInf_retencionMensual").ToString)
                credinfonavit.CIImporteretencionbimestral = CDbl(dtResultado.Rows(0)("crInf_importeretencionbimestral").ToString)
                credinfonavit.CIDescuentoanterior = CDbl(dtResultado.Rows(0)("crInf_descuentoanterior").ToString)
                credinfonavit.CIDiferencia = CDbl(dtResultado.Rows(0)("crInf_diferencia").ToString)
                credinfonavit.CIDiasSemana = CInt(dtResultado.Rows(0)("diasSemana").ToString)
                credinfonavit.CIRutaarchivoretencion = dtResultado.Rows(0)("crInf_rutaarchivoretencion").ToString
                credinfonavit.CILogoNave = dtResultado.Rows(0)("nave_logotipourl").ToString
                credinfonavit.CITipoDescuentoStr = dtResultado.Rows(0)("catDes_descripcion").ToString
                credinfonavit.CIMovimientoinfonavitStr = dtResultado.Rows(0)("catMov_descripcion").ToString
                credinfonavit.CIFechaInicioBimestre = CDate(dtResultado.Rows(0)("inicioBimestre").ToString)
                credinfonavit.CIFechaFinBimestre = CDate(dtResultado.Rows(0)("finBimestre").ToString)
                credinfonavit.CIDiasAnio = CInt(dtResultado.Rows(0)("diasanio").ToString)
                credinfonavit.CIdiasNoLaborables = CInt(dtResultado.Rows(0)("diasnolaborables").ToString)
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

        Return credinfonavit
    End Function

    Public Function validarEstatus(ByVal creditoId As Integer, ByVal opcEstatus As Integer) As String
        Dim objDatos As New Datos.CreditoInfonavitDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.validarEstatus(creditoId, opcEstatus)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function editarMovimientoCreditoInfonavit(ByVal credInfonavit As Entidades.CreditoInfonavit, ByVal carpeta As String, ByVal archivo As String) As String
        Dim objDatos As New Datos.CreditoInfonavitDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.editarMovimientoCreditoInfonavit(credInfonavit, carpeta, archivo)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function consultarInformacionSUA(ByVal creditoIds As String) As DataTable
        Dim objDatos As New Datos.CreditoInfonavitDA
        Return objDatos.consultarInformacionSUA(creditoIds)
    End Function

    Public Function cambiarEstatus(ByVal creditoIds As String, ByVal opcEstatus As Integer) As String
        Dim objDatos As New Datos.CreditoInfonavitDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.cambiarEstatus(creditoIds, opcEstatus)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function aplicarMovimientoCreditoInfonavit(ByVal creditoId As Integer, ByVal carpeta As String, ByVal archivo As String) As String
        Dim objDatos As New Datos.CreditoInfonavitDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.aplicarMovimientoCreditoInfonavit(creditoId, carpeta, archivo)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function consultaDatosCorreo(ByVal creditoId As Integer) As DataTable
        Dim objDatos As New Datos.CreditoInfonavitDA
        Return objDatos.consultaDatosCorreo(creditoId)
    End Function

    Public Function consultarCreditoColaborador(ByVal colaboradorId As Integer) As DataTable
        Dim objDatos As New Datos.CreditoInfonavitDA
        Return objDatos.consultarCreditoColaborador(colaboradorId)
    End Function

    Public Function consultarValidacionesCredito(ByVal colaboradorId As Integer, ByVal patronId As Integer, ByVal numeroCredito As String, ByVal tipoMovimiento As Integer, ByVal valorDescuento As Double, ByVal tipoDescuento As Integer) As DataTable
        Dim objDatos As New Datos.CreditoInfonavitDA
        Return objDatos.consultarValidacionesCredito(colaboradorId, patronId, numeroCredito, tipoMovimiento, valorDescuento, tipoDescuento)
    End Function

    Public Function consultarListaMovimientosNoDescontados(ByVal patronId As Integer, ByVal nombre As String, ByVal periodo As Boolean, ByVal fechaInicio As String, ByVal fechaFin As String) As DataTable
        Dim objDatos As New Datos.CreditoInfonavitDA
        Return objDatos.consultarListaMovimientosNoDescontados(patronId, nombre, periodo, fechaInicio, fechaFin)
    End Function

    Public Function obtenerMontoMinimo(ByVal patronId As Integer) As Double
        Dim objDatos As New Datos.CreditoInfonavitDA
        Dim dtResultado As New DataTable
        Dim resultado As Double = 0.0

        dtResultado = objDatos.obtenerMontoMinimo(patronId)
        If Not dtResultado Is Nothing Then
            resultado = CDbl(dtResultado.Rows(0)("minds_montoMinimoDescuento").ToString)
        End If

        Return resultado
    End Function

    Public Function consultarListaModificacionDescuento(ByVal naveId As Integer) As DataTable
        Dim objDatos As New Datos.CreditoInfonavitDA
        Return objDatos.consultarListaModificacionDescuento(naveId)
    End Function

    Public Function obtenerTiposMovimiento() As DataTable
        Dim objDatos As New Datos.CreditoInfonavitDA
        Return objDatos.obtenerTiposMovimiento()
    End Function

    Public Function obtenerAcumuladoMovtosInfonavit(ByVal patronId As Integer, ByVal periododel As Integer, ByVal periodoal As Integer, ByVal anio As Integer, ByVal colaboradorIds As String, ByVal tipomovimiento As Integer) As DataTable
        Dim objDatos As New Datos.CreditoInfonavitDA
        Return objDatos.obtenerAcumuladoMovtosInfonavit(patronId, periododel, periodoal, anio, colaboradorIds, tipomovimiento)
    End Function

    Public Function obtenerSemanasReporteDetalle(ByVal patronId As Integer, ByVal periododel As Integer, ByVal periodoal As Integer, ByVal anio As Integer) As DataTable
        Dim objDatos As New Datos.CreditoInfonavitDA
        Return objDatos.obtenerSemanasReporteDetalle(patronId, periododel, periodoal, anio)
    End Function

    Public Function obtenerDetalleMovtosInfonavit(ByVal patronId As Integer, ByVal periododel As Integer, ByVal periodoal As Integer, ByVal anio As Integer, ByVal colaboradorIds As String) As DataTable
        Dim objDatos As New Datos.CreditoInfonavitDA
        Return objDatos.obtenerDetalleMovtosInfonavit(patronId, periododel, periodoal, anio, colaboradorIds)
    End Function

    Public Function obtenerEncabezadoRepAcumulado(ByVal patronId As Integer, ByVal periododel As Integer, ByVal periodoal As Integer) As DataTable
        Dim objDatos As New Datos.CreditoInfonavitDA
        Return objDatos.obtenerEncabezadoRepAcumulado(patronId, periododel, periodoal)
    End Function

    Public Function obtenerMontoDiferencia(ByVal patronId As Integer) As Double
        Dim objDatos As New Datos.CreditoInfonavitDA
        Dim dtResultado As New DataTable
        Dim resultado As Double = 0.0

        dtResultado = objDatos.obtenerMontoDiferencia(patronId)
        If Not dtResultado Is Nothing Then
            resultado = CDbl(dtResultado.Rows(0)("montoDiferencia").ToString)
        End If

        Return resultado
    End Function

End Class
