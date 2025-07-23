Public Class RestriccionesBU

    Public Function ListadoRestriccionesFacturacion() As DataTable
        Dim RestriccionesDA As New Datos.RestriccionesDA
        Return RestriccionesDA.ListadoRestriccionesFacturacion()
    End Function


    Public Sub editarRestriccionCliente(ByVal restriccion As Entidades.RestriccionCliente, bandera As Integer)

        Dim restricciones As New Datos.RestriccionesDA

        restricciones.editarRestriccionCliente(restriccion, bandera)

    End Sub

    Public Function Datos_TablaRestriccionesCliente(clienteID As Integer) As DataTable

        Dim RestriccionesDA As New Datos.RestriccionesDA
        Return RestriccionesDA.Datos_TablaRestriccionesCliente(clienteID)

    End Function

End Class
