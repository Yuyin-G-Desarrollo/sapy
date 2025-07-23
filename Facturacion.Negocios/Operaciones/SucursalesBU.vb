Public Class SucursalesBU
    Public Function getSucursales(ByVal condicion As Boolean) As DataTable
        Dim datos As New Datos.SucursalesDA
        Return datos.getSucursales(condicion)
    End Function

    Public Function getUsuariosNA(ByVal sucursalId As Integer) As DataTable
        Dim datos As New Datos.SucursalesDA
        Return datos.getUsuariosNA(sucursalId)
    End Function

    Public Function getDatosSucursal(ByVal sucursalId As Int32) As Entidades.SucursalesFacturacion
        Dim objDA As New Datos.SucursalesDA
        Dim tabla As New DataTable
        Dim sucursal As New Entidades.SucursalesFacturacion

        tabla = objDA.getDatosSucursal(sucursalId)
        For Each row As DataRow In tabla.Rows
            sucursal.SID = CInt(row("suc_sucursalid"))
            sucursal.SNombre = CStr(row("suc_nombre"))
            sucursal.SCalle = CStr(row("suc_calle"))
            sucursal.SNumero = CStr(row("suc_numero"))
            sucursal.SColonia = CStr(row("suc_colonia"))
            sucursal.SCp = CStr(row("suc_cp"))
            sucursal.SCiudadid = CInt(row("suc_ciudadid"))
            sucursal.SLogo = CStr(row("suc_logo"))
            sucursal.SFacturaproductos = CBool(row("suc_facturaproductos"))
            sucursal.SActivo = CBool(row("suc_activo"))
            sucursal.SRemisiona = CBool(row("suc_remision"))
            sucursal.SReporteRemision = CInt(row("suc_reporteRemision"))
            sucursal.SEstadoid = CInt(row("esta_estadoid"))

        Next

        Return sucursal
    End Function

    Public Function getSucEmpresas(ByVal sucursalId As Integer) As DataTable
        Dim datos As New Datos.SucursalesDA
        Return datos.getSucEmpresas(sucursalId)
    End Function

    Public Function getUsuariosA(ByVal sucursalId As Integer) As DataTable
        Dim datos As New Datos.SucursalesDA
        Return datos.getUsuariosA(sucursalId)
    End Function

    Public Function ExisteSucursal(ByVal strSucursal As String, ByVal sucursalId As Int32) As Boolean
        Dim objDA As New Datos.SucursalesDA
        Dim tabla As New DataTable
        Dim existe As Boolean

        tabla = objDA.ExisteSucursal(strSucursal, sucursalId)
        If tabla.Rows.Count = 0 Then
            existe = False
        Else
            existe = True
        End If

        Return existe
    End Function

    Public Function guardarConfiguracionSucursal(ByVal sucursal As Entidades.SucursalesFacturacion) As Integer
        Dim objDA As New Datos.SucursalesDA
        Dim tabla As New DataTable

        tabla = objDA.guardarConfiguracionSucursal(sucursal)
        Return CInt(tabla.Rows(0)("SUCUID"))
    End Function

    Public Sub guardarSucursalEmpresa(ByVal sucursalemp As Entidades.SucursalEmpresa)
        Dim objDA As New Datos.SucursalesDA
        objDA.guardarSucursalEmpresa(sucursalemp)
    End Sub

    Public Sub guardarSucursalUsuario(ByVal sucursalusu As Entidades.SucursalUsuario)
        Dim objDA As New Datos.SucursalesDA
        objDA.guardarSucursalUsuario(sucursalusu)
    End Sub

    Public Sub eliminaSucursalUsuario(ByVal sucursalusu As Entidades.SucursalUsuario)
        Dim objDA As New Datos.SucursalesDA
        objDA.eliminaSucursalUsuario(sucursalusu)
    End Sub

    Public Function ExisteRegistro(ByVal sucursalusu As Entidades.SucursalUsuario) As Boolean
        Dim objDA As New Datos.SucursalesDA
        Dim tabla As New DataTable
        Dim existe As Boolean

        tabla = objDA.ExisteRegistro(sucursalusu)
        If tabla.Rows.Count = 0 Then
            existe = False
        Else
            existe = True
        End If

        Return existe
    End Function

    Public Function getSucursalesActivas() As DataTable
        Dim datos As New Datos.SucursalesDA
        Return datos.getSucursalesActivas()
    End Function

    Public Function getSucursalesUsuarios(ByVal idUsuario As Integer, ByVal filtroRemision As Boolean) As DataTable
        Dim datos As New Datos.SucursalesDA
        Return datos.getSucursalesUsuarios(idUsuario, filtroRemision)
    End Function

    Public Function obtenerEmpresasSuc(ByVal sucursalId As Integer) As DataTable
        Dim objDA As New Datos.SucursalesDA
        Return objDA.obtenerEmpresasSuc(sucursalId)
    End Function

    Public Function obtenerFolioSerieSucursal(ByVal sucursalId As Integer, ByVal empresaId As Integer) As DataTable
        Dim objDA As New Datos.SucursalesDA
        Return objDA.obtenerFolioSerieSucursal(sucursalId, empresaId)
    End Function
End Class
