

Public Class ClasificacionGiroBU

    Public Function ConsultaInformacionGiro(ByVal GiroID As Integer) As DataTable
        Dim objDA As New Proveedores.DA.ClasificacionGiroDA
        Return objDA.ConsultaInformacionGiro(GiroID)
    End Function

    Public Function BuscarGiro(ByVal Giro As String, ByVal GiroID As Integer) As DataTable
        Dim objDA As New Proveedores.DA.ClasificacionGiroDA
        Return objDA.BuscarGiro(Giro, GiroID)
    End Function

    Public Function InsertarClasificacion(ByVal Clasificacion As String, ByVal Activo As Boolean, ByVal UsuarioCreoID As Integer) As DataTable
        Dim objDA As New Proveedores.DA.ClasificacionGiroDA
        Return objDA.InsertarClasificacion(Clasificacion, Activo, UsuarioCreoID)
    End Function

    Public Function EditarClasificacion(ByVal ClasificacionID As Integer, ByVal Clasificacion As String, ByVal Activo As Boolean, ByVal UsuarioModificoID As Integer) As DataTable
        Dim objDA As New Proveedores.DA.ClasificacionGiroDA
        Return objDA.EditarClasificacion(ClasificacionID, Clasificacion, Activo, UsuarioModificoID)
    End Function

    Public Function InsertarGiro(ByVal Giro As String, ByVal Activo As Boolean, ByVal UsuarioCreoID As Integer) As DataTable
        Dim objDA As New Proveedores.DA.ClasificacionGiroDA
        Return objDA.InsertarGiro(Giro, Activo, UsuarioCreoID)
    End Function

    Public Function EditarGiro(ByVal GiroID As Integer, ByVal Giro As String, ByVal Activo As Boolean, ByVal UsuarioCreoID As Integer) As DataTable
        Dim objDA As New Proveedores.DA.ClasificacionGiroDA
        Return objDA.EditarGiro(GiroID, Giro, Activo, UsuarioCreoID)
    End Function

    Public Function ConsultaClasificaciones(ByVal Activo As Boolean) As DataTable
        Dim objDA As New Proveedores.DA.ClasificacionGiroDA
        Return objDA.ConsultaClasificaciones(Activo)
    End Function

    Public Function ConsultaGiros(ByVal Activo As Boolean) As DataTable
        Dim objDA As New Proveedores.DA.ClasificacionGiroDA
        Return objDA.ConsultaGiros(Activo)
    End Function

    Public Function ConsultaGiroClasificacion(ByVal ClasificacionId As Integer) As DataTable
        Dim objDA As New Proveedores.DA.ClasificacionGiroDA
        Return objDA.ConsultaGiroClasificacion(ClasificacionId)
    End Function

    Public Function ConsultaInformacionClasificacion(ByVal ClasificacionId As Integer) As DataTable
        Dim objDA As New Proveedores.DA.ClasificacionGiroDA
        Return objDA.ConsultaInformacionClasificacion(ClasificacionId)
    End Function

    Public Function BuscarClasificacion(ByVal Clasificacion As String, ByVal ClasificacionID As Integer) As DataTable
        Dim objDA As New Proveedores.DA.ClasificacionGiroDA
        Return objDA.BuscarClasificacion(Clasificacion, ClasificacionID)
    End Function

    Public Function InsertarClasificacionGiro(ByVal ClasificacionID As Integer, ByVal GiroID As Integer, ByVal UsuarioCreoId As Integer) As DataTable
        Dim objDA As New Proveedores.DA.ClasificacionGiroDA
        Return objDA.InsertarClasificacionGiro(ClasificacionID, GiroID, UsuarioCreoId)
    End Function

    Public Function DesactivarClasificacionGiro(ByVal ClasificacionID As Integer, ByVal GiroID As Integer, ByVal UsuarioCreoId As Integer) As DataTable
        Dim objDA As New Proveedores.DA.ClasificacionGiroDA
        Return objDA.DesactivarClasificacionGiro(ClasificacionID, GiroID, UsuarioCreoId)
    End Function
End Class
