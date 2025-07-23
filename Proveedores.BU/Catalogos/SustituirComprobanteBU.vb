Imports Proveedores.DA

Public Class SustituirComprobanteBU
    Public Function getComprobante(ByVal id As Integer) As DataTable
        Dim obj As New SustituirComprobanteDA
        Return obj.getComprobante(id)
    End Function
    Public Function updateComprobanteMaquila(ByVal idComprobante As Integer,
                                             ByVal idReceptor As Integer,
                                             ByVal motivo As String, ByVal fechadocumento As Date,
                                             ByVal uuid As String, ByVal xml As String, ByVal pdf As String, ByVal estatus As String) As DataTable
        Dim obj As New SustituirComprobanteDA
        Return obj.updateComprobanteMaquila(idComprobante, idReceptor, motivo, fechadocumento, uuid, xml, pdf, estatus)
    End Function
    Public Function updateComprobanteMaquilaRemision(ByVal idComprobante As Integer, ByVal pdf As String, ByVal motivo As String, ByVal estatus As String, ByVal folio As String) As DataTable
        Dim obj As New SustituirComprobanteDA
        Return obj.updateComprobanteMaquilaRemision(idComprobante, pdf, motivo, estatus, folio)
    End Function
End Class
