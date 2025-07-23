Imports Proveedores.DA
Imports Entidades

Public Class DevolucionBU
    Public Function getDevoluciones(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal nave As Integer, ByVal todosModelos As Boolean) As DataTable
        Dim obj As New DevolucionDA
        Return obj.getDevoluciones(fechaInicio, fechaFin, nave, todosModelos)
    End Function
    Public Function getDatosComprobante(ByVal idcomprobante As Integer) As DataTable
        Dim obj As New DevolucionDA
        Return obj.getDatosComprobante(idcomprobante)
    End Function
    Public Function aplicarDevolucion(ByVal devolucion As DevolucionMaquila) As DataTable
        Dim obj As New DevolucionDA
        Return obj.aplicarDevolucion(devolucion)
    End Function
    Public Function getDetalleDevolucionPares(ByVal idDetalleDevolucion As Integer) As DataTable
        Dim obj As New DevolucionDA
        Return obj.getDetalleDevolucionPares(idDetalleDevolucion)
    End Function
    Public Function getPrecioPorTalla(ByVal idNave As Integer, ByVal talla As String) As DataTable
        Dim obj As New DevolucionDA
        Return obj.getPrecioPorTalla(idNave, talla)
    End Function
    Public Function getPrecioFamiliaTalla(ByVal idFamilia As Integer, ByVal talla As String) As DataTable
        Dim obj As New DevolucionDA
        Return obj.getPrecioFamiliaTalla(idFamilia, talla)
    End Function
    Public Function getFamiliaModelo(ByVal modeloSicy As String, ByVal idTallaSicy As String) As DataTable
        Dim obj As New DevolucionDA
        Return obj.getFamiliaModelo(modeloSicy, idTallaSicy)
    End Function
End Class
