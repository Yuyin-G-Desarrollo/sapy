Public Class ConfigProveedorMaquilaDA
    Public Function getProveedoresNave(ByVal idNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>            
            select 0 seleccionar,mapo_maquilaproveedorid,IdProveedor,RazonSocial 'Razón Social',NomComercial 'Nombre Comercial',DiasCredito 'Plazo' from Proveedores 
            inner join Proveedores.MaquilaProveedores on mapo_proveedorid=IdProveedor 
            </cadena>
        If idNave > 0 Then
            consulta += " where mapo_naveid=" & getNaveSIcy(idNave) & " order by RazonSocial"
        End If
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getProveedoresNaveConfigurados(ByVal idNaveSICY As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>            
            select 0 seleccionar,mapo_maquilaproveedorid,IdProveedor,RazonSocial 'Razón Social',NomComercial 'Nombre Comercial',DiasCredito 'Plazo' from Proveedores 
            inner join Proveedores.MaquilaProveedores on mapo_proveedorid=IdProveedor 
            </cadena>
        If idNaveSICY > 0 Then
            consulta += " where mapo_naveid=" & idNaveSICY & " order by RazonSocial"
        End If
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getProveedores() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
                select IdProveedor,RazonSocial from Proveedores where Estatus='Activo' order by RazonSocial
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function insertProveedorConfig(ByVal idNave As Integer, ByVal idProvee As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
                Insert into Proveedores.MaquilaProveedores(mapo_naveid,mapo_proveedorid,mapo_usuariocreo,mapo_fechacreacion)
            </cadena>
        consulta += " values(" & getNaveSIcy(idNave) & "," & idProvee & ",'" & Entidades.SesionUsuario.UsuarioSesion.PUserUsername & "',GETDATE())"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getNaveSIcy(ByVal idNave As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
           select nave_navesicyid from Framework.Naves where nave_naveid=
            </cadena>
        consulta += " " & idNave & " "
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return Convert.ToInt32(datos.Rows(0).Item(0).ToString)
        End If
        Return 0
    End Function
    Public Function eliminarProveedorConfig(ByVal id As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
                delete from Proveedores.MaquilaProveedores where mapo_maquilaproveedorid=
            </cadena>
        consulta += " " & id
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function verificarProveedorConfig(ByVal idProv As Integer, ByVal idNave As Integer) As Boolean
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
                select  mapo_proveedorid from Proveedores.MaquilaProveedores where 
            </cadena>
        consulta += "mapo_proveedorid=" & idProv & " and mapo_naveid=" & getNaveSIcy(idNave) & " "
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
End Class
