Public Class OrdenNaveAuxBU

    Public Function consultaOrdenNavesSImulacion(ByVal idSimulacion As Int32) As DataTable
        Dim objDA As New Datos.OrdenNaveAuxDA
        Return objDA.consultaOrdenNavesSImulacion(idSimulacion)
    End Function

    Public Sub editarOrdenSimulacion(ByVal idOrdenNaveAux As Int32, ByVal orden As Int32)
        Dim objDA As New Datos.OrdenNaveAuxDA
        objDA.editarOrdenSimulacion(idOrdenNaveAux, orden)
    End Sub

End Class
