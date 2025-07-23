Imports Entidades
Imports Proveedores.DA
Public Class ComplementosComprasPT_BU
    Public Function InsertarDocumentoFactura(ByVal strXML As String, ByVal entXML As Entidades.FacturaComplementoXML, ByVal rutaXML As String, ByVal rutaPDF As String) As DataTable
        Dim objDA As New ComplementosComprasPT_DA
        Return objDA.InsertarDocumentoFactura(strXML, entXML, rutaXML, rutaPDF)
    End Function

    Public Function obtenerRutasSICY_Emisor(ByVal rfcEmisor As String) As DataTable
        Dim objDA As New ComplementosComprasPT_DA
        Return objDA.obtenerRutasSICY_Emisor(rfcEmisor)
    End Function

    Public Function ObtenerInfoCXPSaldo(ByVal idDocumento As Integer) As DataTable
        Dim objDA As New ComplementosComprasPT_DA
        Return objDA.ObtenerInfoCXPSaldo(idDocumento)
    End Function

    Public Function validarExisteFacturaComplemento(ByVal rfcEmisor As String, ByVal serieDocumento As String, ByVal folioDocumento As Integer) As Boolean
        Dim objDA As New ComplementosComprasPT_DA
        Dim dtResultado As New DataTable
        Dim blnResult As Boolean = False
        dtResultado = objDA.validarExisteFacturaComplemento(rfcEmisor, serieDocumento, folioDocumento)

        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            blnResult = True
        End If

        Return blnResult
    End Function

    Public Function insertarRegistroComplemento(ByVal documentoId As Integer) As DataTable
        Dim objDA As New ComplementosComprasPT_DA
        Return objDA.insertarRegistroComplemento(documentoId)
    End Function

End Class
