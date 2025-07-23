Public Class LugarEntregaBU

    Public Function ListadoLugarEntrega() As DataTable
        Dim LugarEntregaDA As New Datos.LugarEntregaDA
        Return LugarEntregaDA.ListadoLugarEntrega()
    End Function


    Public Function ListaDestinos_Sin_MensajeriaRelacionada()
        Dim objDA As New Datos.LugarEntregaDA
        Return objDA.ListaDestinos_Sin_MensajeriaRelacionada()
    End Function


End Class
