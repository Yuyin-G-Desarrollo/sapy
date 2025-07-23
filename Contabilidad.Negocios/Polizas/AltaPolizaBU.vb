Public Class AltaPolizaBU

#Region "CARGAR CATALOGOS"

    Public Function datosServidorEmpresa(ByVal empresaID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.datosServidorEmpresa(empresaID)
    End Function

    Public Function CargaEmpresaCONTPAQ(ByVal usuarioID As Integer) As DataTable
        Dim EmpresaContpaq As New Contabilidad.Datos.AltaPolizaDA
        Return EmpresaContpaq.CargaEmpresaCONTPAQ(usuarioID)
    End Function

    Public Function BuscaEmpresaSAY(ByVal empresaID As Integer) As DataTable
        Dim EmpresaContpaq As New Contabilidad.Datos.AltaPolizaDA
        Return EmpresaContpaq.buscaEmpresaSAY(empresaID)
    End Function

    Public Function CargaTiposPoliza() As DataTable
        Dim altapoliDA As New Contabilidad.Datos.AltaPolizaDA
        Return altapoliDA.CargaTiposPoliza
    End Function

    Public Function cuentasGenerales(ByVal empresaID As Integer, ByVal clave As String, ByVal cuentaBancaria As String, ByVal tipoPoliza As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.cuentasGenerales(empresaID, clave, cuentaBancaria, tipoPoliza)
    End Function

    Public Function cuentasGeneralesBancos(ByVal empresaID As Integer, ByVal clave As String, ByVal tipoPoliza As String) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.cuentasGeneralesBancos(empresaID, clave, tipoPoliza)
    End Function

#End Region

#Region "CARGAR GRID COMPRAS"

    Public Function CargaGridPolizaCompras(ByVal estatus As String, ByVal RazSoc As String, ByVal FechaDe As String, ByVal FechaA As String, ByVal empresaID As Integer) As DataTable
        Dim PoliDA As New Contabilidad.Datos.AltaPolizaDA
        Return PoliDA.CargaGridPolizaCompras(estatus, RazSoc, FechaDe, FechaA, empresaID)
    End Function

    Public Function CargaComprasSinComprobante(ByVal FechaDe As Date, ByVal FechaA As Date, ByVal empresaID As Integer) As DataTable
        Dim PoliDA As New Contabilidad.Datos.AltaPolizaDA
        Return PoliDA.cargarComprasSinComprobante(FechaDe, FechaA, empresaID)
    End Function

    Public Function cargarCuentaProveedor(ByVal servidor As String, ByVal BD As String, ByVal proveedor As String) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.cargarCuentaProveedor(servidor, BD, proveedor)
    End Function

    Public Function cargarCuentaProveedorSAY(ByVal proveedorSicyID As Integer, ByVal empresaID As String) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.cargarCuentaProveedorSAY(proveedorSicyID, empresaID)
    End Function

    Public Function cargarCuentaProveedorSICY(ByVal proveedor As String, ByVal empresaID As String) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.cargarCuentaProveedorSICY(proveedor, empresaID)
    End Function

#End Region

#Region "CARGAR GRID DEPOSITOS POR IDENTIFICAR"
    Public Function cargarGridDepositosPorIdentificar(ByVal empresa As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal estatus As String)
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.cargarGridDepositosPorIdentificar(empresa, FechaInicio, FechaFin, estatus)
    End Function
#End Region

#Region "CARGAR GRID DEPOSITOS IDENTIFICADOS"
    Public Function cargarGridDepositosIdentificados(ByVal empresa As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal estatus As String, ByVal tipoPoliza As Integer)
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.cargarGridDepositosIdentificados(empresa, FechaInicio, FechaFin, estatus, tipoPoliza)
    End Function

#End Region

#Region "CARGAR GRID TRANSFERENCIAS"
    Public Function cargarGridTransferencias(ByVal fechaInicio As DateTime, ByVal fechaFin As DateTime, ByVal empresaID As String, ByVal estatus As String)
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.cargarGridTransferencias(fechaInicio, fechaFin, empresaID, estatus)
    End Function

    Public Function buscaDocumentosSinXML_Transferencias(ByVal fechaInicio As DateTime, ByVal fechaFin As DateTime, ByVal empresaID As String)
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.buscaDocumentosSinXML_Transferencias(fechaInicio, fechaFin, empresaID)
    End Function
#End Region

#Region "Cargar Grid ventas"
    Public Function CargaGridPolizaVentas(ByVal estatus As String, ByVal RazSoc As String, ByVal FechaDe As String, ByVal FechaA As String, ByVal empresaID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.CargaGridPolizaVentas(estatus, RazSoc, FechaDe, FechaA, empresaID)
    End Function
#End Region

#Region "Cargar Grid VENTAS CANCELADAS"
    Public Function CargaGridPolizaVentasCanceladas(ByVal estatus As String, ByVal RazSoc As String, ByVal FechaDe As String, ByVal FechaA As String, ByVal empresaID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.CargaGridPolizaVentasCanceladas(estatus, RazSoc, FechaDe, FechaA, empresaID)
    End Function

#End Region

#Region "Cargar grid Gastos"
    Public Function cargarGridComprasGastos(ByVal contribuyentesID As Integer, ByVal doctoVentasID As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal estatus As String, ByVal tipoPoliza As String) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.cargarGridComprasGastos(contribuyentesID, doctoVentasID, FechaInicio, FechaFin, estatus, tipoPoliza)
    End Function

    Public Function cargarGridProductoTerminado(ByVal contribuyentesID As Integer, ByVal doctoVentasID As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal estatus As String, ByVal tipoPoliza As String) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.cargarGridProductoTerminado(contribuyentesID, doctoVentasID, FechaInicio, FechaFin, estatus, tipoPoliza)
    End Function
#End Region

#Region "Cargar Grid Activo Fijo"
    Public Function cargarGridActivoFijo(ByVal contribuyentesID As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal IdDoctosVentas As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.CargaGridActivoFijo(contribuyentesID, FechaInicio, FechaFin, IdDoctosVentas)
    End Function

#End Region

#Region "Cargar Grid Notas de Credito"
    Public Function CargaGridPolizaNotasDeCredito(ByVal RazSoc As String, ByVal FechaDe As String, ByVal FechaA As String, ByVal empresaID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.CargaGridPolizaNoteasDeCredito(RazSoc, FechaDe, FechaA, empresaID)
    End Function
#End Region

#Region "Cargar Grid Notas de Credito Canceladas"
    Public Function CargaGridPolizaNotasDeCredito_Canceladas(ByVal RazSoc As String, ByVal FechaDe As String, ByVal FechaA As String, ByVal empresaID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.CargaGridPolizaNoteasDeCredito_Canceladas(RazSoc, FechaDe, FechaA, empresaID)
    End Function
#End Region

#Region "Cargar Grid Notas de Cargo"
    Public Function CargaGridPolizaNotasDeCargo(ByVal RazSoc As String, ByVal FechaDe As String, ByVal FechaA As String, ByVal empresaID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.CargaGridPolizaNotasDeCargo(RazSoc, FechaDe, FechaA, empresaID)
    End Function
#End Region

#Region "Cargar Grid Cheques Posfechados"
    Public Function CargaGridChequesPosfechados(ByVal estatus As String, ByVal RazSoc As String, ByVal FechaDe As String, ByVal FechaA As String, ByVal empresaID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.CargaGridChequesPosfechados(estatus, RazSoc, FechaDe, FechaA, empresaID)
    End Function
#End Region

#Region "Cargar Grid Depositos Internos"
    Public Function CargaGridDepositosInternos(ByVal estatus As String, ByVal RazSoc As String, ByVal FechaDe As String, ByVal FechaA As String, ByVal empresaID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.CargaGridDepositosInternos(estatus, RazSoc, FechaDe, FechaA, empresaID)
    End Function
#End Region

#Region "ALTA CUENTAS CONTABLES CONTPAQ/SAY"

    Public Function AltaCuentasContablesSAY(ByVal altaCuentaContable As Entidades.Polizas, ByVal servidor As String, ByVal BD As String, ByVal cuentacontable As String) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.AltaCuentasContablesSAY(altaCuentaContable, servidor, BD, cuentacontable)
    End Function

    Public Function AltaCuentasContablesCONTPAQ(ByVal proveedor As String, ByVal cuenta As String, ByVal servidor As String, ByVal BD As String) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.AltaCuentasContablesCONTPAQ(proveedor, cuenta, servidor, BD)
    End Function
#End Region

#Region "ALTA POLIZA CONTPAQ/SAY"

    Public Function AltaPolizaCompaq(ByVal PolizaCompaq As Entidades.Polizas) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.AltaPolizaCompaq(PolizaCompaq)

    End Function

    Public Function AltaPolizaMovimientoCompaq(ByVal PolizaCompaq As Entidades.Polizas) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.AltaPolizaMovimientoCompaq(PolizaCompaq)
    End Function

    Public Sub AltaPolizaCFDICompaq(ByVal PolizaCompaq As Entidades.Polizas)
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        objDA.AltaPolizaCFDICompaq(PolizaCompaq)
    End Sub

    Public Sub AltaPolizaCFDIMovimiento(ByVal PolizaContpaq As Entidades.Polizas)
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        objDA.AltaPolizaCFDIMovimiento(PolizaContpaq)
    End Sub

    Public Function AltaPolizaSAY(ByVal PolizaSAY As Entidades.Polizas) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.AltaPolizaSAY(PolizaSAY)
    End Function

    Public Sub ActualizaTipoPoliza(ByVal polizaID As Integer, ByVal tipoPolizaID As Integer, ByVal servidorBD As String, ByVal empresaBD As String)
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        objDA.ActualizaTipoPoliza(polizaID, tipoPolizaID, servidorBD, empresaBD)
    End Sub

    Public Sub ActualizaCargosAbonosPoliza(ByVal polizaId As Integer)
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        objDA.ActualizaCargosAbonosPoliza(polizaId)
    End Sub

    Public Sub AltaPolizaMovimientoSAY(ByVal polizaSAY As Entidades.Polizas)
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        objDA.AltaPolizaMovimientoSAY(polizaSAY)
    End Sub

    Public Sub AltaMovimientoEgresos(ByVal poliza As Entidades.Polizas, ByVal servidorID As String, servidorBD As String)
        Dim objDA As New Datos.AltaPolizaDA
        objDA.AltaMovimientoEgresos(poliza, servidorID, servidorBD)
    End Sub
#End Region

#Region "ALTA PERSONAS Y PROVEEDORES"

    Public Function ValidarPersonaProveedorExisteContpaq(ByVal proveedorRFC As String, ByVal servidorBD As String, empresaBD As String) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.ValidarPersonaProveedorExisteContpaq(proveedorRFC, servidorBD, empresaBD)
    End Function

    Public Function AltaPersonasContpaq(ByVal PolizaSAY As Entidades.Polizas) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.AltaPersonasContpaq(PolizaSAY)
    End Function

    Public Function AltaProveedoresContpaq(ByVal ProveedoresContpaq As Entidades.Polizas) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.AltaProveedoresContpaq(ProveedoresContpaq)
    End Function

#End Region

#Region "Lo nuevo"

    Public Function obtenerIdDescripcionCuentaGeneral(ByVal cuenta As String, ByVal empresaID As String) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.obtenerIdDescripcionCuentaGeneral(cuenta, empresaID)
    End Function

    Public Function obtenerIdDescripcionCuentaGeneral2(ByVal empresaID As String, ByVal tipoPoliza As String) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.obtenerIdDescripcionCuentaGeneral2(empresaID, tipoPoliza)
    End Function

    Public Function obtenerNombreProveedorContpaq(ByVal RFC As String, ByVal servidorBD As String, ByVal empresaBD As String) As DataTable
        Dim objDA As New Datos.AltaPolizaDA
        Return objDA.obtenerNombreProveedorContpaq(RFC, servidorBD, empresaBD)
    End Function

    Public Function obtenerNombreCuentaContpaq(ByVal Cuenta As String, ByVal servidorBD As String, ByVal empresaBD As String) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.obtenerNombreCuentaContpaq(Cuenta, servidorBD, empresaBD)
    End Function

    Public Function cargarCuentaContableSayProveedorNueva(ByVal empresaID As Integer, ByVal proveedorIDSicy As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.cargarCuentaContableSayProveedorNueva(empresaID, proveedorIDSicy)
    End Function

    Public Function cargarCuentaContableSayProveedorNueva2(ByVal empresaID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.cargarCuentaContableSayProveedorNueva2(empresaID)
    End Function

    Public Function cargarCuentaContableSayClienteNueva(ByVal empresaID As Integer, ByVal proveedorIDSicy As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.cargarCuentaContableSayClienteNueva(empresaID, proveedorIDSicy)
    End Function

    Public Function cargarCuentaContableSayClienteNueva2(ByVal empresaID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.cargarCuentasContablesSayClientes(empresaID)
    End Function

    Public Function cargarCuentasContablesContpaqRelacion(ByVal empresaID As Integer, ByVal tipoCuentaID As Integer, ByVal nomenclatura As String, ByVal nomenclatura2 As String, ByVal servidor As String, ByVal BD As String) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.cargarCuentasContablesContpaqRelacion(empresaID, tipoCuentaID, nomenclatura, nomenclatura2, servidor, BD)
    End Function

    Public Function obtenerConsecutivo(ByVal servidor As String, ByVal empresaBD As String, ByVal nomenclatura As String) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.obtenerConsecutivo(servidor, empresaBD, nomenclatura)
    End Function

    Public Function validarclienteExisteSay(ByVal clienteID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.validarclienteExisteSay(clienteID)
    End Function

    Public Function validarclienteExisteSay2(ByVal IdEmpresa As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.validarclienteExisteSay2(IdEmpresa)
    End Function

    Public Function validarProveedorExisteSAY(ByVal proveedor As String) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.validarProveedorExisteSAY(proveedor)
    End Function

    Public Function insertarPersonaSAY(ByVal listaEntidades As Entidades.Polizas) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.insertarPersonaSAY(listaEntidades)
    End Function

    Public Function insertarProveedorSAY(ByVal listaEntidades As Entidades.Polizas) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.insertarProveedorSAY(listaEntidades)
    End Function


    Public Sub actualizarTotales(ByVal servidor As String, ByVal empresaBD As String, ByVal polizaContpaqID As String)
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        objDA.actualizarTotales(servidor, empresaBD, polizaContpaqID)
    End Sub

    Public Function obtieneProveedores(ByVal servidorBD As String, empresaBD As String) As DataTable
        Dim objDA As New Contabilidad.Datos.AltaPolizaDA
        Return objDA.obtenerProveedores(servidorBD, empresaBD)
    End Function

#End Region


    Public Function RecuperarCodigoTipoPolizaContpaq(ByVal Nombre As String, ByVal ServidorDB As String, ByVal BaseDeDatosDB As String) As Integer
        Dim objDA As New Datos.AltaPolizaDA
        Dim dtCodigoPoliza As New DataTable

        dtCodigoPoliza = objDA.RecuperarCodigoTipoPolizaContpaq(Nombre, ServidorDB, BaseDeDatosDB)

        If dtCodigoPoliza.Rows.Count = 0 Then
            RecuperarCodigoTipoPolizaContpaq = 0
        Else
            RecuperarCodigoTipoPolizaContpaq = dtCodigoPoliza.Rows(0).Item(0)
        End If

        Return RecuperarCodigoTipoPolizaContpaq
    End Function

    Public Function CuentasContables_ActivoFijo(ByVal IdEmpresa As Integer) As DataTable
        Dim objdaDA As New Datos.AltaPolizaDA
        CuentasContables_ActivoFijo = objdaDA.CuentasContables_ActivoFijo(IdEmpresa)
        Return CuentasContables_ActivoFijo
    End Function

    Public Function RecuperarIdDiarioContpaq(ByVal Nombre As String, ByVal servidorBD As String, ByVal empresaBD As String) As Integer
        Dim objdaDA As New Datos.AltaPolizaDA
        Dim dtDiario As New DataTable

        dtDiario = objdaDA.RecuperarIdDiarioContpaq(Nombre, servidorBD, empresaBD)

        If dtDiario.Rows.Count > 0 Then
            Return dtDiario.Rows(0).Item(0)
        Else
            Return 0
        End If
    End Function

    'Public Function RecuperarDescripcionDeFactura(ByVal Factura As String, )

    'End Function

End Class
