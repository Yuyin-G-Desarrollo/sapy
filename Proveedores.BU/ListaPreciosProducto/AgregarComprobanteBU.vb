Imports Proveedores.DA
Imports Entidades

Public Class AgregarComprobanteBU
    Public Function getDiasCredito(ByVal idProveedor As Integer) As Integer
        Dim obj As New AgregarComprobanteDA
        Return obj.getDiasCredito(idProveedor)
    End Function
    Public Function validarSiExistenDiasInhabiles(ByVal inicio As Date, ByVal fin As Date) As DataTable
        Dim obj As New AgregarComprobanteDA
        Return obj.validarSiExistenDiasInhabiles(inicio, fin)
    End Function
    Public Function validarSiesDiaHabil(ByVal fecha As Date) As Boolean
        Dim obj As New AgregarComprobanteDA
        Return obj.validarSiesDiaHabil(fecha)
    End Function
    Public Function getSemana(ByVal fecha As Date) As DataTable
        Dim obj As New AgregarComprobanteDA
        Return obj.getSemana(fecha)
    End Function
    Public Function getNaveSIcy(ByVal idNave As Integer) As Integer
        Dim obj As New AgregarComprobanteDA
        Return obj.getNaveSIcy(idNave)
    End Function
    Public Function getFacturacionRemision(ByVal idNave As Integer) As DataTable
        Dim obj As New AgregarComprobanteDA
        Return obj.getFacturacionRemision(idNave)
    End Function
    Public Function verificarRazonSocialParaNave(ByVal idNave As Integer, ByVal RFC As String) As DataTable
        Dim obj As New AgregarComprobanteDA
        Return obj.verificarRazonSocialParaNave(idNave, RFC)
    End Function
    Public Function verificarEmisor(ByVal idNave As Integer, ByVal RFC As String) As Boolean
        Dim obj As New AgregarComprobanteDA
        Return obj.verificarEmisor(idNave, RFC)
    End Function
    Public Function verificarUUID(ByVal uuid As String) As Boolean
        Dim obj As New AgregarComprobanteDA
        Dim dtMaquilaComprobantes As New DataTable

        dtMaquilaComprobantes = obj.verificarUUID(uuid)

        If dtMaquilaComprobantes.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function getIdProveedorPorRFC(ByVal idNave As Integer, ByVal RFC As String) As Integer
        Dim obj As New AgregarComprobanteDA
        Return obj.getIdProveedorPorRFC(idNave, RFC)
    End Function
    Public Function insertComprobanteMaquila(ByVal comprobante As MaquilaComprobante) As DataTable
        Dim obj As New AgregarComprobanteDA
        Return obj.insertComprobanteMaquila(comprobante)
    End Function
    Public Function updateComprobanteMaquila(ByVal comprobante As MaquilaComprobante) As DataTable
        Dim obj As New AgregarComprobanteDA
        Return obj.updateComprobanteMaquila(comprobante)
    End Function
    Public Function verificarFecha(ByVal fecha As Date, ByVal idNave As Integer) As Boolean
        Dim obj As New AgregarComprobanteDA
        Return obj.verificarFecha(fecha, idNave)
    End Function
    Public Function getComprobantes(ByVal idNave As Integer, ByVal estatus As String, ByVal tipoFecha As String,
                                    ByVal fechaFin As Date, ByVal fechaInicio As Date) As DataTable
        Dim obj As New AgregarComprobanteDA
        Return obj.getComprobantes(idNave, estatus, tipoFecha, fechaFin, fechaInicio)
    End Function
    Public Function updateEstatusComprobanteMaquila(ByVal comprobante As MaquilaComprobante) As DataTable
        Dim obj As New AgregarComprobanteDA
        Return obj.updateEstatusComprobanteMaquila(comprobante)
    End Function
    Public Function InsertcxpSaldoscxpMovimientos(ByVal comprobante As MaquilaComprobante) As DataTable
        Dim obj As New AgregarComprobanteDA
        Return obj.InsertcxpSaldoscxpMovimientos(comprobante)
    End Function
    Public Function getEmailProveedor(ByVal idProveedor As Integer) As DataTable
        Dim obj As New AgregarComprobanteDA
        Return obj.getEmailProveedor(idProveedor)
    End Function
    Public Function getInfoIdCompProveedor(ByVal idProveedor As String, ByVal idComprobantes As String) As DataTable
        Dim obj As New AgregarComprobanteDA
        Return obj.getInfoIdCompProveedor(idProveedor, idComprobantes)
    End Function
    Public Function verificarFolioCxpagar(ByVal comprobante As MaquilaComprobante)
        Dim obj As New AgregarComprobanteDA
        Return obj.verificarFolioCxpagar(comprobante)
    End Function

    Public Function consecutivoFolio(ByVal razonSocial As String, ByVal rfcEmisorXML As String) As DataTable
        Dim obj As New AgregarComprobanteDA
        Return obj.consecutivoFolio(razonSocial, rfcEmisorXML)
    End Function

    Public Function ActualizaConsecutivoRemisionCompMaquila(idProveedor As Int16, idConsecutivoRemsionMaquila As Int16) As DataTable
        Dim obj As New AgregarComprobanteDA
        Return obj.ActualizaConsecutivoRemisionCompMaquila(idProveedor, idConsecutivoRemsionMaquila)
    End Function

    Public Function maquilaProveedores(ByVal idNave As Integer) As DataTable
        Dim obj As New AgregarComprobanteDA
        Return obj.maquilaProveedores(idNave)
    End Function

    Public Function proveedores(ByVal maquilaProveedores As DataTable) As DataTable
        Dim obj As New AgregarComprobanteDA
        Return obj.proveedores(maquilaProveedores)
    End Function

    Public Function consecutivo(ByVal idProveedor As Integer) As Integer
        Dim obj As New AgregarComprobanteDA
        Return obj.consecutivo(idProveedor)
    End Function

    Public Function InsertaComprobanteDetalle(ByVal comprobante As MaquilaComprobante) As DataTable
        Dim obj As New AgregarComprobanteDA
        Return obj.InsertaComprobanteDetalle(comprobante)
    End Function

    Public Function ObtenerComprobanteDetalle(ByVal idComprobante As Integer) As DataTable
        Dim obj As New AgregarComprobanteDA
        Return obj.ObtenerComprobanteDetalle(idComprobante)
    End Function

End Class
