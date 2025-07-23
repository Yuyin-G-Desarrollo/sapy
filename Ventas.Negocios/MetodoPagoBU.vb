Public Class MetodoPagoBU

    Public Function ListadoMetodoPago() As DataTable
        Dim MetodoPago As New Datos.MetodoPagoDA
        Return MetodoPago.ListadoMetodoPago()
    End Function

    Public Function ListaMetodoPago_NotaCredito() As DataTable
        Dim metodoPagoDA As New Datos.MetodoPagoDA
        Return metodoPagoDA.ListaMetodoPago_NotaCredito()
    End Function

    Public Function ListaMetodoFormaPago_NotaCredito(ByVal clienteID As Integer)
        Dim metodoPagoDA As New Datos.MetodoPagoDA
        Return metodoPagoDA.ListaMetodoFormaPago_NotaCredito(clienteID)
    End Function

    Public Function Datos_TablaMetodoPago(clienteID As Integer) As DataTable
        Dim MetodoPago As New Datos.MetodoPagoDA
        Return MetodoPago.Datos_TablaMetodoPago(clienteID)
    End Function

    Public Sub altaMetodoPagoCliente(metodopagoid As Integer, clienteid As Integer)

        Dim MetodoPagoDA As New Datos.MetodoPagoDA

        MetodoPagoDA.altaMetodoPagoCliente(metodopagoid, clienteid)

    End Sub

    Public Sub editarMetodoPagoCliente(metodopagoclienteid As Integer, metodopagoid As Integer, activo As Boolean)

        Dim MetodoPagoDA As New Datos.MetodoPagoDA

        MetodoPagoDA.editarMetodoPagoCliente(metodopagoclienteid, metodopagoid, activo)
    End Sub

End Class
