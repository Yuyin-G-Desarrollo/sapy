Public Class CatalogoPatronesBU

    Public Function ConsultarPatrones(ByVal nombre As String, ByVal rfc As String, ByVal nopatronal As String, ByVal activo As Boolean) As DataTable
        Dim objDa As New Datos.CatalogoPatronesDA
        Return objDa.ConsultarPatrones(nombre, rfc, nopatronal, activo)
    End Function

    Public Function ConsultaEmpresas(ByVal activo As Boolean) As DataTable
        Dim objDa As New Datos.CatalogoPatronesDA
        Return objDa.ConsultarEmpresas(activo)
    End Function

    Public Function ConsultarCajas(ByVal activo As Boolean) As DataTable
        Dim objDa As New Datos.CatalogoPatronesDA
        Return objDa.ConsultarCajas(activo)
    End Function

    Public Function ConsultarTipoColaborador(ByVal activo As Boolean) As DataTable
        Dim objDa As New Datos.CatalogoPatronesDA
        Return objDa.ConsultarTipoColaborador(activo)
    End Function

    Public Function ConsultarTipoContrato(ByVal activo As Boolean) As DataTable
        Dim objDa As New Datos.CatalogoPatronesDA
        Return objDa.ConsultarTipoContrato(activo)
    End Function

    Public Function ConsultarRiesgoPuesto(ByVal activo As Boolean) As DataTable
        Dim objDa As New Datos.CatalogoPatronesDA
        Return objDa.ConsultarRiesgoPuesto(activo)
    End Function

    Public Function ConsultarNaves(ByVal activo As Boolean) As DataTable
        Dim objDa As New Datos.CatalogoPatronesDA
        Return objDa.ConsultarNaves(activo)
    End Function

    Public Function ConsultarPatronesGrupo(ByVal activo As Boolean) As DataTable
        Dim objDa As New Datos.CatalogoPatronesDA
        Return objDa.ConsultarPatronesGrupo(activo)
    End Function

    Public Function AltaEdicionPatron(ByVal objPatron As Entidades.Patron) As String
        Dim objDa As New Datos.CatalogoPatronesDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDa.AltaEdicionPatron(objPatron)
        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado

    End Function

    Public Function ConsultarPatronEditar(ByVal idPatron As Integer) As Entidades.Patron
        Dim objDa As New Datos.CatalogoPatronesDA
        Dim objPatron As New Entidades.Patron
        Dim dtResultado As New DataTable

        dtResultado = objDa.ConsultarPatronEditar(idPatron)

        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            With objPatron
                .PPatronId = dtResultado.Rows(0)("patr_patronid").ToString
                .PNombre = dtResultado.Rows(0)("patr_nombre").ToString
                .PRFC = dtResultado.Rows(0)("patr_rfc").ToString
                .PNoPatronal = dtResultado.Rows(0)("patr_nopatronal").ToString
                .PCalle = dtResultado.Rows(0)("patr_domiciliocalle").ToString
                .PNumero = dtResultado.Rows(0)("patr_domicilionumero").ToString
                .PColonia = dtResultado.Rows(0)("patr_domiciliocolonia").ToString
                .PCiudadId = CInt(dtResultado.Rows(0)("patr_ciudadid").ToString)
                .PEstadoId = CInt(dtResultado.Rows(0)("esta_estadoid").ToString) ''ESTADO!!!
                .PCP = dtResultado.Rows(0)("patr_cp").ToString
                .PActivo = CBool(dtResultado.Rows(0)("patr_activo").ToString)
                If Not IsDBNull(dtResultado.Rows(0)("patr_empresaid").ToString) Then
                    .PEmpresaId = CInt(dtResultado.Rows(0)("patr_empresaid").ToString)
                End If
                If Not IsDBNull(dtResultado.Rows(0)("naveId").ToString) Then
                    .PNaveId = CInt(dtResultado.Rows(0)("naveId").ToString)
                End If

                .PChecador = CBool(dtResultado.Rows(0)("patr_tieneChecador").ToString)
                .PTipoColaborador = CInt(dtResultado.Rows(0)("patr_tipoColaboradorid").ToString)

                If Not IsDBNull(dtResultado.Rows(0)("patr_tipoContrato").ToString) Then
                    .PTipoContrato = dtResultado.Rows(0)("patr_tipoContrato").ToString
                End If
                If Not IsDBNull(dtResultado.Rows(0)("patr_riesgoTrabajo").ToString) Then
                    .PRiesgoPuesto = dtResultado.Rows(0)("patr_riesgoTrabajo").ToString
                End If
                If Not IsDBNull(dtResultado.Rows(0)("patr_cajaChicaId").ToString) Then
                    .PCajaChica = CInt(dtResultado.Rows(0)("patr_cajaChicaId").ToString)
                End If

                .PComisiones = CBool(dtResultado.Rows(0)("patr_manejaComisiones").ToString)
                .PDescuentoInfonavit = CDbl(dtResultado.Rows(0)("descuentoinfonavit").ToString)
                .PPorcentajeAsistencia = CDbl(dtResultado.Rows(0)("porcentajeasistencia").ToString)
                .PPorcentajePuntualidad = CDbl(dtResultado.Rows(0)("porcentajepuntualidad").ToString)
                .PClaveSeguridadSocial = dtResultado.Rows(0)("patr_claveSeguridadSocial").ToString
                .PClaveRetiroCesantia = dtResultado.Rows(0)("patr_claveRetiroCesantia").ToString
                .PClaveISR = dtResultado.Rows(0)("patr_claveISR").ToString
                .PClaveInfonavit = dtResultado.Rows(0)("patr_claveInfonavit").ToString
                .PClaveSPE = dtResultado.Rows(0)("patr_claveSPE").ToString
                .PClaveISRAguinaldoVacaciones = dtResultado.Rows(0)("patr_claveISRAguinaldoVacaciones").ToString
                .PClaveISRAnual = dtResultado.Rows(0)("patr_claveIsrAnual").ToString
                .PClaveSPEAnual = dtResultado.Rows(0)("patr_claveSpeAnual").ToString
                .PClavePercepcionACargoAnual = dtResultado.Rows(0)("patr_clavePercepcionACargoAnual").ToString
                .PClaveComisiones = dtResultado.Rows(0)("patr_claveComisiones").ToString
                .PAgrupado = dtResultado.Rows(0)("agrupado").ToString
                .PPatronGrupo = dtResultado.Rows(0)("patrongrupo").ToString
            End With
        Else
            objPatron = Nothing
        End If

        Return objPatron

    End Function

    Public Function ExistePatron(ByVal RFC As String, ByVal nopatronal As String) As String
        Dim objDa As New Datos.CatalogoPatronesDA
        Dim dtResultado As New DataTable
        Dim resultado As Boolean = False

        dtResultado = objDa.ExistePatron(RFC, nopatronal)
        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            resultado = True
        End If

        Return resultado

    End Function

    Public Function AltaRutasFacturacion(ByVal EmpresaId As Integer, ByVal TipoComprobante As Integer, ByVal TipoDocumento As String) As String
        Dim objDa As New Datos.CatalogoPatronesDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDa.AltaRutasFacturacion(EmpresaId, TipoComprobante, TipoDocumento)
        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado

    End Function
End Class
