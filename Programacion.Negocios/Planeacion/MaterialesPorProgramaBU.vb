Imports Programacion.Datos

Public Class MaterialesPorProgramaBU
    Public Function ObtenerMaterialesPorPrograma(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String) As DataTable
        Dim obj As New MaterialesPorProgramaDA

        Return obj.ObtieneMaterialesPorPrograma(pIdNave, pFechaInicio, pFechaFin, pIdColeccion, pIdModelo, pPielColor, pIdCorrida, pIdProveedor, pIdClasificacion)
    End Function
End Class
