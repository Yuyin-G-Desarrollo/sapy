
Public Class ConfiguracionPermisosBU

    Public Function listaConfiguracionPermisos(ByVal IDNave As Integer) As List(Of Entidades.ConfiguracionPermisos)
        Dim objDA As New Datos.ConfiguracionPermisosDA
        Dim tabla As New DataTable
        listaConfiguracionPermisos = New List(Of Entidades.ConfiguracionPermisos)
        tabla = objDA.listaConfiguracionPermisos(IDNave)

        For Each fila As DataRow In tabla.Rows

            Dim configuracionpermisos As New Entidades.ConfiguracionPermisos

            configuracionpermisos.PConfiguracionPermisos_id = CInt(fila("exmot_id"))
            configuracionpermisos.PConfiguracionPermisos_nombre = CStr(fila("exmot_nombre"))
            configuracionpermisos.PConfiguracionPermisos_puntualidad_asistencia = CByte(fila("exmot_puntualidad_asistencia"))
            configuracionpermisos.PConfiguracionPermisos_caja_ahorro = CByte(fila("exmot_caja_ahorro"))
            configuracionpermisos.PConfiguracionPermisos_naveid = CInt(fila("exmot_naveid"))
            configuracionpermisos.PConfiguracionPermisos_usuariocreo = CStr(fila("exmot_usuariocreo"))
            configuracionpermisos.PConfiguracionPermisos_usuariomodifico = CStr(fila("exmot_usuariomodifico"))

            listaConfiguracionPermisos.Add(configuracionpermisos)

        Next
    End Function

    Public Function listaMotivosPermisosNave(ByVal IDNave As Integer) As DataTable
        Dim objMotivosPermisosDA As New Datos.ConfiguracionPermisosDA
        Dim tblMotivos As New DataTable
        tblMotivos = objMotivosPermisosDA.listaMotivosPermisosNave(IDNave)
        Return tblMotivos
    End Function

    Public Function listaTiposPermisos() As DataTable
        Dim objMotivosPermisosDA As New Datos.ConfiguracionPermisosDA
        Dim tblMotivos As New DataTable
        tblMotivos = objMotivosPermisosDA.listaTiposPermisos
        Return tblMotivos
    End Function

    Public Sub guardarConfiguracionPermisos(ByVal configuracionPermisos As Entidades.ConfiguracionPermisos)

        Dim objConfiguracionAsistencia As New Datos.ConfiguracionPermisosDA

        objConfiguracionAsistencia.guardarConfiguracionPermisos(configuracionPermisos)

    End Sub

    Public Function BuscarConfiguracionPermisos(ByVal IdConfigPermisos As Integer) As Entidades.ConfiguracionPermisos

        Dim objConfiguracionAsistencia As New Datos.ConfiguracionPermisosDA

        BuscarConfiguracionPermisos = objConfiguracionAsistencia.BuscarConfiguracionPermisos(IdConfigPermisos)

    End Function

    Public Function BuscarMotivoPermisoNave(ByVal IdConfPer As Integer, ByVal IdNave As Integer, ByVal Motivo As String) As Boolean

        Dim objConfiguracionAsistencia As New Datos.ConfiguracionPermisosDA

        BuscarMotivoPermisoNave = objConfiguracionAsistencia.BuscarMotivoPermisoNave(IdConfPer, IdNave, Motivo)

    End Function

End Class
