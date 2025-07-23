Imports Programacion.Datos
Public Class Programacion_FamiliaNave_BU
    Public Function ObtenerFamiliasNoAsignadasPorNave(ByVal IdNaveSay As Integer) As DataTable
        Dim obj As New Programacion_FamiliaNave_DA
        Return obj.ObtenerFamiliasNoAsignadasPorNave(IdNaveSay)
    End Function
    Public Sub InsertarFamiliasNave(ByVal UsuarioId As Integer, ByVal IdNaveSay As Integer, ByVal IdFamilias As String)
        Dim obj As New Programacion_FamiliaNave_DA
        obj.InsertarFamiliasNave(UsuarioId, IdNaveSay, IdFamilias)
    End Sub
    Public Function ConsultarFamiliasAsignadasPorNave(ByVal IdNaveSay As Integer, ByVal Activo As Integer) As DataTable
        Dim obj As New Programacion_FamiliaNave_DA
        Return obj.ConsultarFamiliasAsignadasPorNave(IdNaveSay, Activo)
    End Function
    Public Sub EditarFamiliasAsignadasPorNave(ByVal pXmlCeldas As String)
        Dim obj As New Programacion_FamiliaNave_DA
        obj.EditarFamiliasAsignadasPorNave(pXmlCeldas)
    End Sub
End Class
