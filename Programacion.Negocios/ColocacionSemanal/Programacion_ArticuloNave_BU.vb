Imports Programacion.Datos
Public Class Programacion_ArticuloNave_BU
    Public Function ObtenerArticulosNoAsignadasPorNave(ByVal IdNaveSay As Integer) As DataTable
        Dim obj As New Programacion_ArticuloNave_DA
        Return obj.ObtenerArticulosNoAsignadasPorNave(IdNaveSay)
    End Function
    Public Sub InsertarArticulosNave(ByVal UsuarioId As Integer, ByVal IdNaveSay As Integer, ByVal IdArticulos As String, ByVal Fecha As Date, ByVal SiguienteFechaAsignar As Date, ByVal GuardarFechaAsignar As Boolean)
        Dim obj As New Programacion_ArticuloNave_DA
        obj.InsertarArticulosNave(UsuarioId, IdNaveSay, IdArticulos, Fecha, SiguienteFechaAsignar, GuardarFechaAsignar)
    End Sub
    Public Function ConsultarArticulosAsignadasPorNave(ByVal IdNaveSay As Integer, ByVal Activo As Integer) As DataTable
        Dim obj As New Programacion_ArticuloNave_DA
        Return obj.ConsultarArticulosAsignadasPorNave(IdNaveSay, Activo)
    End Function
    Public Sub EditarPrioridadArticulos(ByVal pXmlCeldas As String, ByVal activo As Integer)
        Dim obj As New Programacion_ArticuloNave_DA
        obj.EditarPrioridadArticulos(pXmlCeldas, activo)
    End Sub
    Public Sub DesasignarArticulosNave(ByVal pXmlCeldas As String, ByVal Fecha As Date)
        Dim obj As New Programacion_ArticuloNave_DA
        obj.DesasignarArticulosNave(pXmlCeldas, Fecha)
    End Sub
    Public Sub TransferirArticulosNave(ByVal IdNuevaNave As Integer, ByVal pXmlCeldas As String, ByVal FechaHasta As Date, ByVal FechaDesde As Date)
        Dim obj As New Programacion_ArticuloNave_DA
        obj.TransferirArticulosNave(IdNuevaNave, pXmlCeldas, FechaHasta, FechaDesde)
    End Sub
    Public Sub EditarArticulosNave(ByVal pXmlCeldas As String, ByVal Fecha As Date)
        Dim obj As New Programacion_ArticuloNave_DA
        obj.EditarArticulosNave(pXmlCeldas, Fecha)
    End Sub
    Public Function ValidarFecha(ByVal pXmlCeldas As String, ByVal Fecha As Date, ByVal tipoFecha As Integer) As DataTable
        Dim obj As New Programacion_ArticuloNave_DA
        Return obj.ValidarFecha(pXmlCeldas, Fecha, tipoFecha)
    End Function
End Class
