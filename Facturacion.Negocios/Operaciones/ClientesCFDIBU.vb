Public Class ClientesCFDIBU
    Public Function getClientesCFDI(ByVal idUsuario As Integer, ByVal idSucursal As Integer, ByVal filtro As String, ByVal activo As Boolean) As DataTable
        Dim datos As New Datos.ClientesCFDIDA
        Return datos.getClientesCFDI(idUsuario, idSucursal, filtro, activo)
    End Function

    Public Function obtenerClienteCFDI(ByVal idCliente As Integer) As Entidades.ClientesCFDI
        Dim datos As New Datos.ClientesCFDIDA
        Dim tabla As New DataTable
        Dim clienteCFDI As New Entidades.ClientesCFDI

        tabla = datos.obtenerClienteCFDI(idCliente)
        For Each row As DataRow In tabla.Rows
            clienteCFDI.IdCte = CInt(row("cfac_clienteid"))
            clienteCFDI.CRazonSocial = CStr(row("cfac_razonsocial"))
            clienteCFDI.CNombre = CStr(row("cfac_nombre"))
            clienteCFDI.CPaterno = CStr(row("cfac_paterno"))
            clienteCFDI.CMaterno = CStr(row("cfac_materno"))
            clienteCFDI.CRFC = CStr(row("cfac_rfc"))
            clienteCFDI.CCurp = CStr(row("cfac_curp"))
            clienteCFDI.CCalle = CStr(row("cfac_calle"))
            clienteCFDI.CNumeroInterior = CStr(row("cfac_numerointerior"))
            clienteCFDI.CNumeroExterior = CStr(row("cfac_numeroexterior"))
            clienteCFDI.CColonia = CStr(row("cfac_colonia"))
            clienteCFDI.CCP = CStr(row("cfac_cp"))
            clienteCFDI.CEmail = CStr(row("cfac_email"))
            clienteCFDI.CSucursalID = CInt(row("cfac_sucursalid"))
            clienteCFDI.CTelefono = CStr(row("cfac_telefono"))
            clienteCFDI.CIdCiudad = CInt(row("cfac_idciudad"))
            clienteCFDI.CMetodoPagoId = CInt(row("cfac_metodoPagoId"))
            clienteCFDI.CFormaPago = CStr(row("cfac_formaPago"))
            clienteCFDI.CCondicionesPago = CStr(row("cfac_condicionesPago"))
            clienteCFDI.CActivo = CBool(row("cfac_activo"))
            clienteCFDI.CNombreRemision = CStr(row("cfac_nombreRemision"))
            clienteCFDI.CFacturar = CBool(row("cfac_facturar"))
            clienteCFDI.CRemisionar = CBool(row("cfac_Remisionar"))
            clienteCFDI.CEstadoId = CInt(row("esta_estadoid"))
            clienteCFDI.CPaisId = CInt(row("pais_paisid"))
            clienteCFDI.CCiudad = CStr(row("ciudad"))
            clienteCFDI.CEstado = CStr(row("estado"))
            clienteCFDI.CPais = CStr(row("pais"))
        Next

        Return clienteCFDI
    End Function

    Public Function existeRegistro(ByVal valor As String, ByVal idCliente As Integer, ByVal idSucursal As Integer) As Boolean
        Dim datos As New Datos.ClientesCFDIDA
        Dim tabla As New DataTable

        tabla = datos.existeRegistro(valor, idCliente, idSucursal)
        If tabla.Rows.Count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub guardarCliente(ByVal cliente As Entidades.ClientesCFDI)
        Dim datos As New Datos.ClientesCFDIDA
        datos.guardarCliente(cliente)
    End Sub

    Public Function obtenerClientesSuc(ByVal idSucursal As Integer, ByVal tipoVenta As Int16) As DataTable
        Dim datos As New Datos.ClientesCFDIDA
        Return datos.obtenerClientesSuc(idSucursal, tipoVenta)
    End Function
End Class
