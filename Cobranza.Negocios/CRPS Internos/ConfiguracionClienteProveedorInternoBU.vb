Imports Cobranza.Datos
Imports Entidades.Produccion

Public Class ConfiguracionClienteProveedorInternoBU
    Public Function ObtenerProveedoresInternos()
        Dim ObjObtener As New ConfiguracionClienteProveedorInternoDA
        Dim tblConfiguracion As New DataTable
        tblConfiguracion = ObjObtener.obtenerProveedoresInternos
        Return tblConfiguracion
    End Function
    Public Function mostrarClientesInternosProveedor(ByVal objConfiguracion As Entidades.ConfiguracionClienteProveedorInterno)
        Dim ObjObtener As New ConfiguracionClienteProveedorInternoDA
        Dim tblConfiguracion As New DataTable
        tblConfiguracion = ObjObtener.MostrarClientesInternosProveedor(objConfiguracion)
        Return tblConfiguracion
    End Function
    Public Function ConsultaCuentarRFCProveedorInterno(ByVal idCuenta As Entidades.ConfiguracionClienteProveedorInterno)
        Dim ObjCuenta As New ConfiguracionClienteProveedorInternoDA
        Dim tblCuenta As New DataTable
        tblCuenta = ObjCuenta.ConsultarBancoRfcProveedorInterno(idCuenta)
        Return tblCuenta
    End Function
End Class
