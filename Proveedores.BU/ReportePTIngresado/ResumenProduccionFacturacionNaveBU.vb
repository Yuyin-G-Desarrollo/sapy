Imports Proveedores.DA

Public Class ResumenProduccionFacturacionNaveBU

    Public Function MostrarReporte(ByVal semanaInicio As Integer, ByVal anioInicio As Integer, ByVal semanaFin As Integer, anioFin As Integer, ByVal idNaveSay As String) As DataTable
        Dim objDA As New ResumenProduccionFacturacionNaveDA

        Return objDA.MostrarReporte(semanaInicio, anioInicio, semanaFin, anioFin, idNaveSay)

    End Function

End Class
