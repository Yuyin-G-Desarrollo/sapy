Imports Proveedores.DA

Public Class CambioSemanaProveedorBU

    Public Function obtenerProveedor(tipo_busqueda) As DataTable
        Dim objDa As New CambioSemanaProveedorDA
        Return objDa.obtenerProveedor(tipo_busqueda)
    End Function

    Public Function ObtenerDocumentosProveedor(ByVal ProveedorId As String) As DataTable
        Dim objDa As New CambioSemanaProveedorDA
        Return objDa.ObtenerDocumentosProveedor(ProveedorId)
    End Function

    Public Function llenarComboSemanaPago(ByVal año As Integer) As DataTable
        Dim objDa As New CambioSemanaProveedorDA
        Return objDa.llenarComboSemanaPago(año)
    End Function

    Public Function llenarComboAnioPago() As DataTable
        Dim objDa As New CambioSemanaProveedorDA
        Return objDa.llenarComboAnioPago()
    End Function

    Public Sub ActualizarSemanaPagoProveedor(ByVal pXmlDocumentos As String)
        Dim objDa As New CambioSemanaProveedorDA
        objDa.ActualizarSemanaPagoProveedor(pXmlDocumentos)
    End Sub



End Class
