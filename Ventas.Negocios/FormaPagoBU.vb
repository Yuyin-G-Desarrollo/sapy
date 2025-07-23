Public Class FormaPagoBU

    Public Function ListadoFormaPago() As DataTable
        Dim FormaPago As New Datos.FormaPagoDA
        Return FormaPago.ListadoFormaPago()
    End Function

    Public Function ListadoFormaPago_NotaCredito() As DataTable
        Dim formaPagoDA As New Datos.FormaPagoDA
        Return formaPagoDA.ListadoFormaPago_NotaCredito()
    End Function

End Class
