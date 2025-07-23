Public Class CredencialesBU

    Public Function ObtenerURLCredencial(naveID As Integer, ByVal Departamento As String) As String
        ObtenerURLCredencial = ""

        'If naveID = 43 Then

        '    If Departamento.Contains("CONTABILIDAD") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Comercializadora/Administrativa/CREDENCIAL_CONTABILIDAD.PNG"
        '    ElseIf Departamento.Contains("FINANZAS") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Comercializadora/Administrativa/CREDENCIAL_FINANZAS.PNG"
        '    ElseIf Departamento.Contains("PROVEEDORES") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Comercializadora/Administrativa/CREDENCIAL_PROVEEDORES.PNG"
        '    ElseIf Departamento.Contains("ADMINISTRA") Or Departamento.Contains("CREDITO") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Comercializadora/Administrativa/CREDENCIAL_ADMINISTRACION.PNG"
        '    ElseIf Departamento.Contains("VENTAS") Or Departamento.Contains("ATENCION A CLIENTES") _
        '        Or Departamento.Contains("PROMOTORIA") Or Departamento.Contains("COMERCIAL") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Comercializadora/Comercial/CREDENCIAL_VENTAS.PNG"
        '    ElseIf Departamento.Contains("PROGRAMACION") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Comercializadora/Comercial/CREDENCIAL_PPCP.PNG"
        '    ElseIf Departamento.Contains("DIRECCION") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Comercializadora/DireccionGerencia/CREDENCIAL_DIRECCION.PNG"
        '    ElseIf Departamento.Contains("GERENTE GENERAL") Or Departamento.Contains("GERENCIA DE PORYECTOS") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Comercializadora/DireccionGerencia/CREDENCIAL_GERENCIA.PNG"
        '    ElseIf Departamento.Contains("PUBLICIDAD") Or Departamento.Contains("MERCADOTECNIA") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Comercializadora/Mercadotecnia/CREDENCIAL_DISEÑO.PNG"
        '    ElseIf Departamento.Contains("ALMACEN") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Comercializadora/Operaciones/CREDENCIAL_ALMACEN.PNG"
        '    ElseIf Departamento.Contains("CALIDAD") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Comercializadora/Operaciones/CREDENCIAL_CALIDAD.PNG"
        '    ElseIf Departamento.Contains("DEVOLUCIONES") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Comercializadora/Operaciones/CREDENCIAL_DEVOLICIONES.PNG"
        '    ElseIf Departamento.Contains("OPERACIONES") Or Departamento.Contains("LOGISTICA") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Comercializadora/Operaciones/CREDENCIAL_OPERADORES.PNG"
        '    ElseIf Departamento.Contains("HUMANO") Or Departamento.Contains("INTENDENCIA") _
        '        Or Departamento.Contains("VIGILANCIA") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Comercializadora/RH/CREDENCIAL_RH.PNG"
        '    ElseIf Departamento.Contains("TECNOLOGIAS") Or Departamento.Contains("DESARROLLO") Or Departamento.Contains("T.I.") _
        '        Or Departamento.Contains("SOPORTE") Or Departamento.Contains("GERENTE DE PROYECTOS") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Comercializadora/TI/CREDENCIAL_SISTEMAS.PNG"
        '    ElseIf Departamento.Contains("CONCEPTUAL") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Comercializadora/Comercial/CREDENCIAL_DISCONCEPTUAL.PNG"
        '    ElseIf Departamento.Contains("PROYECTOS") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Comercializadora/Proyectos/CREDENCIAL_PROYECTOS.PNG"
        '    End If
        'End If

        'If naveID = 73 Then
        '    If Departamento.Contains("CONTABILIDAD") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Villagonti/Contabilidad/VILLAGONTI_CONTABILIDAD.PNG"
        '    ElseIf Departamento.Contains("CAPITAL HUMANO") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Villagonti/Capital Humano/VILLAGONTI_CAPITAL HUMANO.PNG"
        '    ElseIf Departamento.Contains("FINANZAS") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Villagonti/Finanzas/VILLAGONTI_FINANZAS.PNG"
        '    ElseIf Departamento.Contains("CUENTAS POR COBRAR") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Villagonti/Cuentas por Cobrar/VILLAGONTI_CUENTAS POR COBRAR.png"
        '    ElseIf Departamento.Contains("CUENTAS POR PAGAR") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Villagonti/Cuentas por Pagar/VILLAGONTI_CUENTAS POR PAGAR.PNG"
        '    ElseIf Departamento.Contains("PLANEACION TACTICA PATRIMONIAL") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Villagonti/Planeación Táctica Patrimonial/VILLAGONTI_PTP.PNG"
        '    ElseIf Departamento.Contains("GERENCIA") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Villagonti/Gerencia/VILLAGONTI_GERENCIA.PNG"
        '    ElseIf Departamento.Contains("DIRECCION") Then
        '        ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Villagonti/Dirección/VILLAGONTI_DIRECCIÓN.PNG"

        '    End If

        'End If

        'If naveID = 61 Then
        '    ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Naves/INDUSTAR.jpg"
        'End If

        'If naveID = 5 Then
        '    ObtenerURLCredencial = rutaPublica & "Nomina/Credenciales/Naves/GREENLOVE.jpg"
        'End If
        Dim objDA As New Datos.CredencialesDA
        Dim dtDatos As New DataTable
        dtDatos = objDA.obtenerURLCredencial(naveID, Departamento)

        If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then
            ObtenerURLCredencial = rutaPublica & dtDatos.Rows(0).Item(0).ToString
        End If

        Return ObtenerURLCredencial
    End Function

    Public Function obtenerFotoCredencial(ByVal idNave As Int32) As String
        Dim objDA As New Datos.CredencialesDA
        Return objDA.obtenerFotoCredencial(idNave)
    End Function


End Class
