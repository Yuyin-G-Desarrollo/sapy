Imports Programacion.Datos

Public Class CatalogoJustificacionesBU
    Public Function JustificacionesTabla() As DataTable
        Dim vCatJus As New CatalogoJustificacionesDA
        Return vCatJus.JustificacionesTabla
    End Function

    Public Sub Agregar(mensaje As String)
        Dim vCatJus As New CatalogoJustificacionesDA
        vCatJus.Agregar(mensaje.ToUpper)
    End Sub

    Public Sub Eliminar(id As Int32)
        Dim vCatJus As New CatalogoJustificacionesDA
        vCatJus.Eliminar(id)
    End Sub

    Public Sub Modificar(obj As Entidades.ProgramacionCatalogoJustificaciones)
        Dim vCatJus As New CatalogoJustificacionesDA
        vCatJus.Modificar(obj)
    End Sub

End Class
