Public Class ConfigPagoMaquilasDA
    Public Function getNavesConfig() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
            select 0 naveConfigStatus,0 razSocConfigStatus,isnull(cpm_id,0) idConfig,IdNave,Nave,cpm_factura '% Factura',cpm_remision '% Remisión',cpm_tolerancia '$ Tolerancia' from Naves
            left join Proveedores.ConfigPagoMaquilas on cpm_idNave=IdNave
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getContribuyentes() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
            select IDRazSoc,alias from Contribuyentes where estatus='A' order by alias
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getConfigContribuyentes() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
             select * from Proveedores.ConfigPagoMaquilasDetalles
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function existeConfiguracionDetalles(ByVal idConfig As Integer, ByVal idRazSoc As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
            select * from Proveedores.ConfigPagoMaquilasDetalles where
            </cadena>
        consulta += " cpm_id=" & idConfig & " and cpmd_idRazSoc=" & idRazSoc & ""
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function insertConfiguracionDetalles(ByVal idConfig As Integer, ByVal idRazSoc As Integer, ByVal value As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
           insert into Proveedores.ConfigPagoMaquilasDetalles(cpm_id,cpmd_idRazSoc,cpm_estatus)
            </cadena>
        consulta += " values(" & idConfig & "," & idRazSoc & "," & value & ")"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function updateConfiguracionDetalles(ByVal idConfig As Integer, ByVal idRazSoc As Integer, ByVal value As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
           update Proveedores.ConfigPagoMaquilasDetalles set 
            </cadena>
        consulta += " cpm_estatus=" & value & " where cpmd_idRazSoc=" & idRazSoc & " and cpm_id=" & idConfig & ""
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function insertConfiguracion(ByVal idNave As Integer, ByVal factura As Double, ByVal remision As Double, ByVal tolerancia As Double) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
            insert into Proveedores.ConfigPagoMaquilas(cpm_idNave,cpm_factura,cpm_remision,cpm_tolerancia,cpm_fechacreacion,cpmd_usuariocreoid)
            </cadena>
        consulta += " values(" & idNave & ",'" & factura & "','" & remision & "'," & tolerancia & ",getdate(),'" & Entidades.SesionUsuario.UsuarioSesion.PUserUsername & "')"
        consulta += " select @@identity"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function updateConfiguracion(ByVal idConfig As Integer, ByVal factura As Double, ByVal remision As Double, ByVal tolerancia As Double) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
            update  Proveedores.ConfigPagoMaquilas set 
            </cadena>
        consulta += " cpm_factura='" & factura & "', cpm_remision='" & remision & "',cpm_tolerancia=" & tolerancia & ", cpm_fechamodificacion=GETDATE(),cpm_usuariomodificoid='" & Entidades.SesionUsuario.UsuarioSesion.PUserUsername & "' "
        consulta += " where cpm_id=" & idConfig & ""
        Return operaciones.EjecutaConsulta(consulta)
    End Function
End Class
