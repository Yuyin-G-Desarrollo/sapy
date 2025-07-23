Imports System.Data.SqlClient
Public Class ClientesCFDIDA
    Public Function getClientesCFDI(ByVal idUsuario As Integer, ByVal idSucursal As Integer, ByVal filtro As String, ByVal activo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim strSucursal As String = String.Empty
        Dim strFiltro As String = String.Empty

        If idSucursal <> 0 Then
            strSucursal = "and su.sucu_sucursaldid = " & idSucursal & " "
        End If

        If filtro <> "" Then
            strFiltro = "and (cc.cfac_razonsocial like '%" & filtro & "%' or cc.cfac_rfc like '%" & filtro & "%' or cc.cfac_email like '%" & filtro & "%') "
        End If

        consulta = "select row_number() OVER(ORDER BY cfac_razonsocial) as NUM, " & _
                    "cc.cfac_clienteid as ID, " & _
                    "ISNULL(cfac_razonsocial, '') as RAZONSOCIAL, " & _
                    "ISNULL(cfac_rfc, '') as RFC, " & _
                    "ISNULL(cfac_email, '') as EMAIL, " & _
                    "(ISNULL(cfac_calle, '') + ' ' + " & _
                    "ISNULL(cfac_numerointerior, '') + ' ' + " & _
                    "ISNULL(cfac_numeroexterior, '') + ' ' + " & _
                    "ISNULL(cfac_colonia, '') + ' ' + " & _
                    "ISNULL(cfac_cp, '') + ' ' + " & _
                    "ISNULL(c.city_nombre, '')) as DOMICILIO, " & _
                    "ISNULL(cc.cfac_telefono, '') as TELEFONO " & _
                    "from Facturacion.ClientesCFDI cc " & _
                    "inner join Facturacion.SucursalUsuarios su on cc.cfac_sucursalid = sucu_sucursaldid " & _
                    "left join Framework.Ciudades c on cc.cfac_idciudad = c.city_ciudadid " & _
                    "where susu_usuarioid = " & idUsuario & " and cfac_activo = '" & activo & "' " & strSucursal & strFiltro & _
                    "order by cfac_razonsocial"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerClienteCFDI(ByVal idCliente As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "select cc.cfac_clienteid, " & _
            "ISNULL(cfac_razonsocial,'') cfac_razonsocial, " & _
            "ISNULL(cfac_nombre, '') cfac_nombre, " & _
            "ISNULL(cfac_paterno, '') cfac_paterno, " & _
            "ISNULL(cfac_materno, '') cfac_materno, " & _
            "ISNULL(cfac_rfc, '') cfac_rfc, " & _
            "ISNULL(cfac_curp, '') cfac_curp, " & _
            "ISNULL(cfac_calle, '') cfac_calle, " & _
            "ISNULL(cfac_numerointerior, '') cfac_numerointerior, " & _
            "ISNULL(cfac_numeroexterior, '') cfac_numeroexterior, " & _
            "ISNULL(cfac_colonia, '') cfac_colonia, " & _
            "ISNULL(cfac_cp, '') cfac_cp, " & _
            "ISNULL(cfac_email, '') cfac_email, " & _
            "ISNULL(cfac_sucursalid, 0) cfac_sucursalid, " & _
            "ISNULL(cfac_telefono, '') cfac_telefono, " & _
            "ISNULL(cfac_idciudad, 0) cfac_idciudad, " & _
            "ISNULL(cfac_metodoPagoId, 0) cfac_metodoPagoId, " & _
            "ISNULL(cfac_formaPago, '') cfac_formaPago, " & _
            "ISNULL(cfac_condicionesPago, '') cfac_condicionesPago, " & _
            "ISNULL(cfac_activo, 0) cfac_activo, " & _
            "ISNULL(cfac_nombreRemision, '') cfac_nombreRemision, " & _
            "ISNULL(cfac_facturar, 0) cfac_facturar, " & _
            "ISNULL(cfac_Remisionar, 0) cfac_Remisionar, " & _
            "ISNULL(mp.mepa_nombre, '') metodoPago, " & _
            "ISNULL(e.esta_estadoid, 0) esta_estadoid, " & _
            "ISNULL(p.pais_paisid, 0) pais_paisid, " & _
            "ISNULL(c.city_nombre, '') ciudad, " & _
            "ISNULL(e.esta_nombre, '') estado, " & _
            "ISNULL(p.pais_nombre , '') pais " & _
            "from Facturacion.ClientesCFDI cc " & _
            "left join Framework.Ciudades c on c.city_ciudadid = cc.cfac_idciudad " & _
            "left join Framework.Estados e on e.esta_estadoid = c.city_estadoid " & _
            "left join Framework.Paises p on p.pais_paisid = e.esta_paisid " & _
            "left join Cobranza.MetodoPago mp on mp.mepa_metodopagoid = cc.cfac_metodoPagoId " & _
            "where cfac_clienteid = " & idCliente
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function existeRegistro(ByVal valor As String, ByVal idCliente As Integer, ByVal idSucursal As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim condicion As String = String.Empty

        If idCliente <> 0 Then
            condicion = " and cfac_clienteid <> " & idCliente
        End If

        consulta = "select * from Facturacion.ClientesCFDI where cfac_sucursalid = " & idSucursal & "and cfac_rfc = '" & valor & "' " & condicion
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Sub guardarCliente(ByVal cte As Entidades.ClientesCFDI)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = cte.IdCte
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "razonsocial"
        parametro.Value = cte.CRazonSocial
        listaParametros.Add(parametro)

        If cte.CNombre <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "nombre"
            parametro.Value = cte.CNombre
            listaParametros.Add(parametro)
        End If

        If cte.CPaterno <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "paterno"
            parametro.Value = cte.CPaterno
            listaParametros.Add(parametro)
        End If

        If cte.CMaterno <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "materno"
            parametro.Value = cte.CMaterno
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "rfc"
        parametro.Value = cte.CRFC
        listaParametros.Add(parametro)

        If cte.CCurp <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "curp"
            parametro.Value = cte.CCurp
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "calle"
        parametro.Value = cte.CCalle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "numeroexterior"
        parametro.Value = cte.CNumeroExterior
        listaParametros.Add(parametro)

        If cte.CNumeroInterior <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "numerointerior"
            parametro.Value = cte.CNumeroInterior
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "colonia"
        parametro.Value = cte.CColonia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cp"
        parametro.Value = cte.CCP
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idciudad"
        parametro.Value = cte.CIdCiudad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "email"
        parametro.Value = cte.CEmail
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuario"
        parametro.Value = cte.CIdUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "sucursalid"
        parametro.Value = cte.CSucursalID
        listaParametros.Add(parametro)

        If cte.CTelefono <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "telefono"
            parametro.Value = cte.CTelefono
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "metodoPagoId"
        parametro.Value = cte.CMetodoPagoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "formaPago"
        parametro.Value = cte.CFormaPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "condicionesPago"
        parametro.Value = cte.CCondicionesPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = cte.CActivo
        listaParametros.Add(parametro)

        If cte.CNombreRemision <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "nombreRemision"
            parametro.Value = cte.CNombreRemision
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "facturar"
        parametro.Value = cte.CFacturar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "remisionar"
        parametro.Value = cte.CRemisionar
        listaParametros.Add(parametro)

        operacion.EjecutarConsultaSP("Facturacion.SP_GuardarClienteCFDI", listaParametros)
    End Sub

    Public Function obtenerClientesSuc(ByVal idSucursal As Integer, ByVal tipoVenta As Int16) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        
        consulta = "select cfac_clienteid ID, cfac_razonsocial CLIENTE " & _
                    "from Facturacion.ClientesCFDI where cfac_activo = 1 and cfac_sucursalid = " & idSucursal & " "

        Select Case tipoVenta
            Case 0
                consulta &= "and cfac_facturar = 1 "
            Case 1
                consulta &= "and cfac_Remisionar = 1 "
        End Select


        consulta &= "order by cfac_razonsocial"
        Return operacion.EjecutaConsulta(consulta)
    End Function
End Class
