Public Class PoliticaEmbarqueBU

    Public Sub editarPoliticaEmbarque(ByVal PoliticaEmbarque As Entidades.PoliticaEmbarque, bandera As Integer)

        Dim PoliticaEmbarqueDA As New Datos.PoliticaEmbarqueDA

        PoliticaEmbarqueDA.editarPoliticaEmbarque(PoliticaEmbarque, bandera)

    End Sub

    Public Function Datos_TablaPoliticaEmbarque(clienteID As Integer) As DataTable

        Dim VentasPoliticasDA As New Datos.PoliticaEmbarqueDA
        Return VentasPoliticasDA.Datos_TablaPoliticaEmbarque(clienteID)

    End Function

End Class
