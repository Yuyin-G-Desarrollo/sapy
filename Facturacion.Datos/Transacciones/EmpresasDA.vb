Imports System.Data.SqlClient

Public Class EmpresasDA
    Public Function getEmpresas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String
        'consulta = "select empr_empresaid, empr_nombre as [Razon Social], empr_rfc as RFC, empr_numerocertificado as [No. Certificado], empr_certificadovigenciainicio as [Vigencia Inicio], " & _
        '            "empr_certificadovigenciafin as [Vigencia Fin], empr_folioactual as [Folio Actual], empr_rutapdfcalzado as [Ruta PDF], empr_rutaxmlcalzado as [Ruta XML] " & _
        '            "from Framework.Empresas order by [Razon Social]"
        'Return operacion.EjecutaConsulta(consulta)
        Return operacion.EjecutaConsulta("EXEC [Facturacion].[Sp_ObtenerEmpresas]")

    End Function

    Public Function getEmpresasActivas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select empr_empresaid, empr_nombre " & _
                    "from Framework.Empresas where empr_activo = 1 order by empr_nombre"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function getReportes() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select repo_reporteid, repo_nombrereporte from Framework.Reportes where repo_esquema = 'FACTURACION'"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function getReportesRemision() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select repo_reporteid, repo_nombrereporte from Framework.Reportes where repo_esquema = 'FACTURACION' and repo_clavereporte like 'REMISION%'"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function getDatosEmpresa(ByVal empresaId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT empr_empresaid, " & _
            "ISNULL(empr_nombre, '') empr_nombre, " & _
            "ISNULL(empr_rfc, '') empr_rfc, " & _
            "ISNULL(empr_activo, 0) empr_activo, " & _
            "ISNULL(empr_arrendamiento, 0) empr_arrendamiento, " & _
            "ISNULL(empr_razonsocial, '') empr_razonsocial, " & _
            "ISNULL(empr_calle, '') empr_calle, " & _
            "ISNULL(empr_colonia, '') empr_colonia, " & _
            "ISNULL(empr_cp, '') empr_cp, " & _
            "ISNULL(empr_regimen, '') empr_regimen, " & _
            "ISNULL(empr_claveRegimen, '') empr_claveRegimen, " & _
            "ISNULL(empr_numero, '') empr_numero, " & _
            "ISNULL(empr_ciudadid, 0) empr_ciudadid, " & _
            "ISNULL(empr_curp, '') empr_curp, " & _
            "ISNULL(empr_rutacertificado, '') empr_rutacertificado, " & _
            "ISNULL(empr_rutakey, '') empr_rutakey, " & _
            "ISNULL(empr_numerocertificado, '') empr_numerocertificado, " & _
            "ISNULL(empr_webservice, '') empr_webservice, " & _
            "ISNULL(empr_usuariows, '') empr_usuariows, " & _
            "ISNULL(empr_contrasenaws, '') empr_contrasenaws, " & _
            "ISNULL(empr_identificadorPax, '') empr_identificadorPax, " & _
            "ISNULL(empr_contrasenacertificado, '') empr_contrasenacertificado, " & _
            "ISNULL(empr_certificadovigenciainicio, GETDATE()) empr_certificadovigenciainicio, " & _
            "ISNULL(empr_certificadovigenciafin, GETDATE()) empr_certificadovigenciafin, " & _
            "ISNULL(empr_foliosinicio, 0) empr_foliosinicio, " & _
            "ISNULL(empr_foliosfin, 0) empr_foliosfin, " & _
            "ISNULL(empr_folioactual, 0) empr_folioactual, " & _
            "ISNULL(empr_rutapdfcalzado, '') empr_rutapdfcalzado, " & _
            "ISNULL(empr_rutaxmlcalzado, '') empr_rutaxmlcalzado, " & _
            "ISNULL(empr_serie, '') empr_serie, " & _
            "ISNULL(empr_folioactualcalzado, 0) empr_folioactualcalzado, " & _
            "ISNULL(empr_renglones, 0) empr_renglones, " & _
            "ISNULL(empr_reportecalzadoid, 0) empr_reportecalzadoid, " & _
            "ISNULL(empr_reportecanccalzadoid, 0) empr_reportecanccalzadoid, " & _
            "ISNULL(empr_rutapdfproductos, '') empr_rutapdfproductos, " & _
            "ISNULL(empr_rutaxmlproductos, '') empr_rutaxmlproductos, " & _
            "ISNULL(empr_reporteproductosid, 0) empr_reporteproductosid, " & _
            "ISNULL(empr_reportecancproductosid, 0) empr_reportecancproductosid, " & _
            "ISNULL(empr_rutalogo, '') empr_rutalogo, " & _
            "ISNULL(empr_cadenacertificado, '') empr_cadenacertificado, " & _
            "ISNULL(es.esta_estadoid, 0) esta_estadoid, " & _
            "ISNULL(c.city_nombre, '') ciudad, " & _
            "ISNULL(es.esta_nombre, '') estado, " & _
            "ISNULL(p.pais_nombre , '') pais " & _
            "FROM Framework.Empresas e " & _
            "LEFT JOIN Framework.Ciudades c ON e.empr_ciudadid = c.city_ciudadid " & _
            "LEFT JOIN Framework.Estados es ON es.esta_estadoid = c.city_estadoid " & _
            "LEFT JOIN Framework.Paises p ON p.pais_paisid = es.esta_paisid " & _
            "WHERE empr_empresaid = " & empresaId
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerFechaActual() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select getdate() as FechaActual"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Sub guardarConfiguracionEmpresa(ByVal emp As Entidades.EmpresasFacturacion)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "empresaid"
        parametro.Value = emp.EId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = emp.ENombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rfc"
        parametro.Value = emp.ERfc
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = emp.EActivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "arrendamiento"
        parametro.Value = emp.EArrendamiento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "razonsocial"
        parametro.Value = emp.ERazonsocial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "calle"
        parametro.Value = emp.ECalle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colonia"
        parametro.Value = emp.EColonia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cp"
        parametro.Value = emp.ECp
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "regimen"
        parametro.Value = emp.ERegimen
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "claveRegimen"
        parametro.Value = emp.EClaveRegimen
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "numero"
        parametro.Value = emp.ENumero
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ciudadid"
        parametro.Value = emp.ECiudadid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "curp"
        parametro.Value = emp.ECurp
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rutacertificado"
        parametro.Value = emp.ERutacertificado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rutakey"
        parametro.Value = emp.ERutakey
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "numerocertificado"
        parametro.Value = emp.Enumerocertificado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "webservice"
        parametro.Value = emp.Ewebservice
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariows"
        parametro.Value = emp.Eusuariows
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "contrasenaws"
        parametro.Value = emp.Econtrasenaws
        listaParametros.Add(parametro)

        If emp.EIdentificadorPax <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "identificadorpax"
            parametro.Value = emp.EIdentificadorPax
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "contrasenacertificado"
        parametro.Value = emp.EContrasenacertificado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "certificadovigenciainicio"
        parametro.Value = emp.ECertificadovigenciainicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "certificadovigenciafin"
        parametro.Value = emp.ECertificadovigenciafin
        listaParametros.Add(parametro)

        If emp.EFoliosinicio <> 0 Then
            parametro = New SqlParameter
            parametro.ParameterName = "foliosinicio"
            parametro.Value = emp.EFoliosinicio
            listaParametros.Add(parametro)
        End If

        If emp.EFoliosFin <> 0 Then
            parametro = New SqlParameter
            parametro.ParameterName = "foliosfin"
            parametro.Value = emp.EFoliosFin
            listaParametros.Add(parametro)
        End If

        If emp.ERutapdfcalzado <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "rutapdfcalzado"
            parametro.Value = emp.ERutapdfcalzado
            listaParametros.Add(parametro)
        End If

        If emp.ERutaxmlcalzado <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "rutaxmlcalzado"
            parametro.Value = emp.ERutaxmlcalzado
            listaParametros.Add(parametro)
        End If

        If emp.ESerie <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "serie"
            parametro.Value = emp.ESerie
            listaParametros.Add(parametro)
        End If

        If emp.EFolioactualcalzado <> 0 Then
            parametro = New SqlParameter
            parametro.ParameterName = "folioactualcalzado"
            parametro.Value = emp.EFolioactualcalzado
            listaParametros.Add(parametro)
        End If

        If emp.ERenglones <> 0 Then
            parametro = New SqlParameter
            parametro.ParameterName = "renglones"
            parametro.Value = emp.ERenglones
            listaParametros.Add(parametro)
        End If

        If emp.EReportecalzadoid <> 0 And emp.EReportecalzadoid <> -1 Then
            parametro = New SqlParameter
            parametro.ParameterName = "reportecalzadoid"
            parametro.Value = emp.EReportecalzadoid
            listaParametros.Add(parametro)
        End If

        If emp.EReportecanccalzadoid <> 0 And emp.EReportecanccalzadoid <> -1 Then
            parametro = New SqlParameter
            parametro.ParameterName = "reportecanccalzadoid"
            parametro.Value = emp.EReportecanccalzadoid
            listaParametros.Add(parametro)
        End If

        If emp.ERutapdfproductos <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "rutapdfproductos"
            parametro.Value = emp.ERutapdfproductos
            listaParametros.Add(parametro)
        End If

        If emp.ERutaxmlproductos <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "rutaxmlproductos"
            parametro.Value = emp.ERutaxmlproductos
            listaParametros.Add(parametro)
        End If

        If emp.EReporteproductosid <> 0 And emp.EReporteproductosid <> -1 Then
            parametro = New SqlParameter
            parametro.ParameterName = "reporteproductosid"
            parametro.Value = emp.EReporteproductosid
            listaParametros.Add(parametro)
        End If

        If emp.EReportecancproductosid <> 0 And emp.EReportecancproductosid <> -1 Then
            parametro = New SqlParameter
            parametro.ParameterName = "reportecancproductosid"
            parametro.Value = emp.EReportecancproductosid
            listaParametros.Add(parametro)
        End If

        If emp.ERutalogo <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "rutalogo"
            parametro.Value = emp.ERutalogo
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "cadenacertificado"
        parametro.Value = emp.ECadenacertificado
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Facturacion.SP_ConfiguracionEmpresa", listaParametros)
    End Sub

    Public Function ExisteRegistro(ByVal campo As Int32, ByVal valor As String, ByVal empresaId As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String
        'Dim strCampo As String = ""
        'Dim strCondicion As String = ""

        'Select Case campo
        '    Case 1
        '        strCampo = "empr_razonsocial"
        '    Case 2
        '        strCampo = "empr_rfc"
        '    Case Else
        '        strCampo = ""
        'End Select

        'If empresaId = 0 Then
        '    strCondicion = ""
        'Else
        '    strCondicion = " and empr_empresaid <> " & empresaId
        'End If

        'consulta = "select * from Framework.Empresas where " & strCampo & " = '" & valor & "'" & strCondicion
        'Return operacion.EjecutaConsulta(consulta)
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@Campo"
        parametro.Value = campo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Valor"
        parametro.Value = valor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EmpresaId"
        parametro.Value = empresaId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Facturacion].[Sp_ValidarExisteEmpresa]", listaParametros)
    End Function

    Public Function validarFacturacionEmpresa(ByVal empresaId As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT * " & _
                    "FROM Framework.Empresas " & _
                    "WHERE empr_rutacertificado is not null  " & _
                    "and empr_rutakey is not null  " & _
                    "and empr_webservice is not null  " & _
                    "and empr_contrasenaws is not null  " & _
                    "and empr_numerocertificado is not null  " & _
                    "and empr_certificadovigenciainicio is not null  " & _
                    "and empr_certificadovigenciafin is not null  " & _
                    "and empr_contrasenacertificado is not null  " & _
                    "and empr_usuariows is not null  " & _
                    "and empr_foliosinicio is not null  " & _
                    "and empr_foliosfin is not null  " & _
                    "and empr_rutapdfproductos is not null  " & _
                    "and empr_rutaxmlproductos is not null  " & _
                    "and empr_reporteproductosid  is not null  " & _
                    "and empr_empresaid =  " & empresaId

        Return operacion.EjecutaConsulta(consulta)
    End Function
End Class
