Public Class Programacion_ColeccionNave_BU
    'Metodos para lagestion general de colecciones asignadas por nave
    Public Function ObtenerColeccionesNoAsignadasPorNave(ByVal IdNaveSay As Integer) As DataTable
        Dim obj As New Programacion_FamiliaNave_DA
        Return obj.ObtenerColeccionesNoAsignadasPorNave(IdNaveSay)
    End Function
    Public Sub InsertarColeccionesNave(ByVal UsuarioId As Integer, ByVal IdNaveSay As Integer, ByVal IdColecciones As String)
        Dim obj As New Programacion_FamiliaNave_DA
        obj.InsertarColeccionesNave(UsuarioId, IdNaveSay, IdColecciones)
    End Sub
    Public Function ConsultarColeccionesAsignadasPorNave(ByVal IdNaveSay As Integer, ByVal Activo As Integer) As DataTable
        Dim obj As New Programacion_FamiliaNave_DA
        Return obj.ConsultarColeccionesAsignadasPorNave(IdNaveSay, Activo)
    End Function
    Public Sub EditarColeccionesAsignadasPorNave(ByVal pXmlCeldas As String, ByVal activo As Integer)
        Dim obj As New Programacion_FamiliaNave_DA
        obj.EditarColeccionesAsignadasPorNave(pXmlCeldas, activo)
    End Sub
End Class
