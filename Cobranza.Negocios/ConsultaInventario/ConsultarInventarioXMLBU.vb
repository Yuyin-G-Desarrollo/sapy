Imports Cobranza.Datos

Public Class ConsultarInventarioXMLBU

    Public Sub GuardarInformacionXMLFacturas(pXMlDocumentos As String, ByVal Serie As String, Folio As String, ByVal FechaTimbrado As String, ByVal Rfc As String)
        Dim objDA As New ConsultarInventarioXMLDA
        objDA.GuardarInformacionXMLFacturas(pXMlDocumentos, Serie, Folio, FechaTimbrado, Rfc)

    End Sub

End Class
