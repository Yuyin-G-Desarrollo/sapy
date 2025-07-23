Public Class AuditoriaPrecioBaseBU

    Public Function verListaPreciosBase() As DataTable
        Dim objListaBaseDA As New Datos.AuditoriaPrecioBaseDA
        Return objListaBaseDA.verListaPreciosBase
    End Function

    Public Function verProductosPrecioBase(idLstPrecioBase As Integer) As DataTable
        Dim objListaBaseDA As New Datos.AuditoriaPrecioBaseDA
        Return objListaBaseDA.verProductosPrecioBase(idLstPrecioBase)
    End Function

    Public Function verProductosPrecioFinal(idLstPrecioBase As Integer) As DataTable
        Dim objListaBaseDA As New Datos.AuditoriaPrecioBaseDA
        Return objListaBaseDA.verProductosPrecioFinal(idLstPrecioBase)
    End Function
    Public Sub actualizarPrecioCliente(precioBaseActual As Double, precioFinalNuevo As Double, paridadPrecioBase As Double, precioCalculadoNuevo As Double, paridadPrecioBase1 As Double, usuarioId As Integer, idListaPrecioCliente As Integer)
        Dim objActualizaPrecioDA As New Datos.AuditoriaPrecioBaseDA
        objActualizaPrecioDA.actualizarPrecioCliente(precioBaseActual, precioFinalNuevo, paridadPrecioBase, precioCalculadoNuevo, paridadPrecioBase1, usuarioId, idListaPrecioCliente)
    End Sub

End Class
