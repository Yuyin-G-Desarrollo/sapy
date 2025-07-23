Imports Programacion.Datos

Public Class Programacion_ModeloNave_BU
    Public Function ObtenerModelosNoAsignadosPorNave(ByVal IdNaveSay As Integer) As DataTable
        Dim obj As New Programacion_ModeloNave_DA
        Return obj.ObtenerModelosNoAsignadosPorNave(IdNaveSay)
    End Function
    Public Sub InsertarModelosNave(ByVal UsuarioId As Integer, ByVal IdNaveSay As Integer, ByVal IdModelos As String)
        Dim obj As New Programacion_ModeloNave_DA
        obj.InsertarModelosNave(UsuarioId, IdNaveSay, IdModelos)
    End Sub
    Public Function ConsultarModelosAsignadosPorNave(ByVal IdNaveSay As Integer, ByVal Activo As Integer) As DataTable
        Dim obj As New Programacion_ModeloNave_DA
        Return obj.ConsultarModelosAsignadosPorNave(IdNaveSay, Activo)
    End Function
    Public Sub EditarModelosAsignadosPorNave(ByVal pXmlCeldas As String)
        Dim obj As New Programacion_ModeloNave_DA
        obj.EditarModelosAsignadosPorNave(pXmlCeldas)
    End Sub
End Class
