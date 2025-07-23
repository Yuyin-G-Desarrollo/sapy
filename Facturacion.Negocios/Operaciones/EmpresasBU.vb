Imports Facturacion.Datos

Public Class EmpresasBU
    Public Function getEmpresas() As DataTable
        Dim datos As New Datos.EmpresasDA
        Return datos.getEmpresas()
    End Function

    Public Function getEmpresasActivas() As DataTable
        Dim datos As New Datos.EmpresasDA
        Return datos.getEmpresasActivas()
    End Function

    Public Function getReportes() As DataTable
        Dim datos As New Datos.EmpresasDA
        Return datos.getReportes()
    End Function

    Public Function getReportesRemision() As DataTable
        Dim datos As New Datos.EmpresasDA
        Return datos.getReportesRemision()
    End Function

    Public Function getDatosEmpresa(ByVal empresaId As Int32) As Entidades.EmpresasFacturacion
        Dim objDA As New Datos.EmpresasDA
        Dim tabla As New DataTable
        Dim empresa As New Entidades.EmpresasFacturacion

        tabla = objDA.getDatosEmpresa(empresaId)
        For Each row As DataRow In tabla.Rows
            empresa.EId = CInt(row("empr_empresaid"))
            empresa.ENombre = CStr(row("empr_nombre"))
            empresa.ERfc = CStr(row("empr_rfc"))
            empresa.EActivo = CBool(row("empr_activo"))
            empresa.EArrendamiento = CBool(row("empr_arrendamiento"))
            empresa.ERazonsocial = CStr(row("empr_razonsocial"))
            empresa.ECalle = CStr(row("empr_calle"))
            empresa.EColonia = CStr(row("empr_colonia"))
            empresa.ECp = CStr(row("empr_cp"))
            empresa.ERegimen = CStr(row("empr_regimen"))
            empresa.EClaveRegimen = CStr(row("empr_claveRegimen"))
            empresa.ENumero = CStr(row("empr_numero"))
            empresa.ECiudadid = CInt(row("empr_ciudadid"))
            empresa.ECurp = CStr(row("empr_curp"))
            empresa.ERutacertificado = CStr(row("empr_rutacertificado"))
            empresa.ERutakey = CStr(row("empr_rutakey"))
            empresa.ENumerocertificado = CStr(row("empr_numerocertificado"))
            empresa.EWebservice = CStr(row("empr_webservice"))
            empresa.EUsuariows = CStr(row("empr_usuariows"))
            empresa.EContrasenaws = CStr(row("empr_contrasenaws"))
            empresa.EIdentificadorPax = CStr(row("empr_identificadorPax"))
            empresa.EContrasenacertificado = CStr(row("empr_contrasenacertificado"))
            empresa.ECertificadovigenciainicio = CDate(row("empr_certificadovigenciainicio"))
            empresa.ECertificadovigenciafin = CDate(row("empr_certificadovigenciafin"))
            empresa.EFoliosinicio = CInt(row("empr_foliosinicio"))
            empresa.EFoliosFin = CInt(row("empr_foliosfin"))
            empresa.EFolioactual = CInt(row("empr_folioactual"))
            empresa.ERutapdfcalzado = CStr(row("empr_rutapdfcalzado"))
            empresa.ERutaxmlcalzado = CStr(row("empr_rutaxmlcalzado"))
            empresa.ESerie = CStr(row("empr_serie"))
            empresa.EFolioactualcalzado = CInt(row("empr_folioactualcalzado"))
            empresa.ERenglones = CInt(row("empr_renglones"))
            empresa.EReportecalzadoid = CInt(row("empr_reportecalzadoid"))
            empresa.ERutapdfproductos = CStr(row("empr_rutapdfproductos"))
            empresa.ERutaxmlproductos = CStr(row("empr_rutaxmlproductos"))
            empresa.EReporteproductosid = CInt(row("empr_reporteproductosid"))
            empresa.ERutalogo = CStr(row("empr_rutalogo"))
            empresa.EEstadoid = CStr(row("esta_estadoid"))
            empresa.EReportecanccalzadoid = CInt(row("empr_reportecanccalzadoid"))
            empresa.EReportecancproductosid = CInt(row("empr_reportecancproductosid"))
        Next

        Return empresa
    End Function

    Public Function obtenerFechaActual() As Date
        Dim objDA As New Datos.EmpresasDA
        Dim tabla As New DataTable
        Dim fechaAct As Date

        tabla = objDA.obtenerFechaActual()
        If tabla.Rows.Count <> 0 Then
            fechaAct = CDate(tabla.Rows(0)("FechaActual"))
        Else
            fechaAct = Nothing
        End If

        Return fechaAct
    End Function

    Public Sub guardarConfiguracionEmpresa(ByVal empresa As Entidades.EmpresasFacturacion)
        Dim objDA As New Datos.EmpresasDA
        objDA.guardarConfiguracionEmpresa(empresa)
    End Sub

    Public Function ExisteRegistro(ByVal campo As Int32, ByVal valor As String, ByVal empresaId As Int32) As Boolean
        Dim objDA As New Datos.EmpresasDA
        Dim tabla As New DataTable
        Dim existe As Boolean

        tabla = objDA.ExisteRegistro(campo, valor, empresaId)
        If tabla.Rows.Count = 0 Then
            existe = False
        Else
            existe = True
        End If

        Return existe
    End Function

    Public Function validarFacturacionEmpresa(ByVal empresaId As Int32) As Boolean
        Dim objDA As New Datos.EmpresasDA
        Dim tabla As New DataTable
        Dim valida As Boolean = True

        tabla = objDA.validarFacturacionEmpresa(empresaId)
        If tabla.Rows.Count = 0 Then
            valida = False
        Else
            valida = True
        End If

        Return valida
    End Function
End Class
