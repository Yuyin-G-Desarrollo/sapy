Imports Persistencia
Imports System.Data.SqlClient

Public Class ConfiguracionPermisosDA

    Public Function listaConfiguracionPermisos(ByVal IDNave As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT e.exmot_id, e.exmot_nombre, e.exmot_puntualidad_asistencia, e.exmot_caja_ahorro, " &
                                        "e.exmot_naveid, e.exmot_usuariocreo, e.exmot_usuariomodifico " &
                                 "FROM ControlAsistencia.ExcepcionMotivo e " &
                                 "WHERE e.exmot_naveid= " + IDNave.ToString + " ORDER BY e.exmot_nombre"

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaMotivosPermisosNave(ByVal NaveId As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT exmot_id as MotivoId, exmot_nombre as MotivoDescripcion FROM ControlAsistencia.ExcepcionMotivo WHERE exmot_naveid = " + NaveId.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaTiposPermisos() As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT 1 AS TipoPermisoId, 'LLEGAR TARDE' AS TipoPermisoDescripcion UNION " &
                                 "SELECT 2  AS TipoPermisoId, 'SALIR TEMPRANO' AS TipoPermisoDescripcion UNION " &
                                 "SELECT 3  AS TipoPermisoId, 'INASISTENCIA' AS TipoPermisoDescripcion"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub guardarConfiguracionPermisos(ByVal configuracionpermisos As Entidades.ConfiguracionPermisos)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@gexmot_id"
        parametro.Value = configuracionpermisos.PConfiguracionPermisos_id
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@gexmot_nombre"
        parametro.Value = configuracionpermisos.PConfiguracionPermisos_nombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@gexmot_puntualidad_asistencia"
        parametro.Value = configuracionpermisos.PConfiguracionPermisos_puntualidad_asistencia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@gexmot_caja_ahorro"
        parametro.Value = configuracionpermisos.PConfiguracionPermisos_caja_ahorro
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@gexmot_naveid"
        parametro.Value = configuracionpermisos.PConfiguracionPermisos_naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@gexmot_usuariocreo"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@gexmot_usuariomodifico"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("ControlAsistencia.SP_altas_configuracion_permisos", listaParametros)

    End Sub

    Public Function BuscarConfiguracionPermisos(ByVal IdConfPermisos As Integer) As Entidades.ConfiguracionPermisos

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim MyTable As New DataTable
        BuscarConfiguracionPermisos = New Entidades.ConfiguracionPermisos

        Dim consulta As String = "SELECT e.exmot_id, e.exmot_nombre, e.exmot_puntualidad_asistencia, e.exmot_caja_ahorro, " &
                                        "e.exmot_naveid, e.exmot_usuariocreo, e.exmot_usuariomodifico " &
                                 "FROM ControlAsistencia.ExcepcionMotivo e " &
                                 "WHERE e.exmot_id= " + IdConfPermisos.ToString

        MyTable = operaciones.EjecutaConsulta(consulta)

        If MyTable.Rows.Count > 0 Then
            BuscarConfiguracionPermisos.PConfiguracionPermisos_id = MyTable(0)("exmot_id")
            BuscarConfiguracionPermisos.PConfiguracionPermisos_nombre = MyTable(0)("exmot_nombre")
            BuscarConfiguracionPermisos.PConfiguracionPermisos_puntualidad_asistencia = MyTable(0)("exmot_puntualidad_asistencia")
            BuscarConfiguracionPermisos.PConfiguracionPermisos_caja_ahorro = MyTable(0)("exmot_caja_ahorro")
            BuscarConfiguracionPermisos.PConfiguracionPermisos_naveid = MyTable(0)("exmot_naveid")
            BuscarConfiguracionPermisos.PConfiguracionPermisos_usuariocreo = MyTable(0)("exmot_usuariocreo")
            BuscarConfiguracionPermisos.PConfiguracionPermisos_usuariomodifico = MyTable(0)("exmot_usuariomodifico")
        End If

    End Function

    Public Function BuscarMotivoPermisoNave(ByVal IdConfPer As Integer, ByVal IdNave As Integer, ByVal Motivo As String) As Boolean
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim MyTable As New DataTable

        BuscarMotivoPermisoNave = False

        Dim consulta As String = "SELECT e.exmot_id, e.exmot_nombre, e.exmot_puntualidad_asistencia, e.exmot_caja_ahorro, " &
                                        "e.exmot_naveid, e.exmot_usuariocreo, e.exmot_usuariomodifico " &
                                 "FROM ControlAsistencia.ExcepcionMotivo e " &
                                 "WHERE e.exmot_nombre = '" + Motivo.ToString + "' AND e.exmot_naveid = " + IdNave.ToString + " AND e.exmot_id <> " + IdConfPer.ToString

        MyTable = operaciones.EjecutaConsulta(consulta)

        If MyTable.Rows.Count > 0 Then
            BuscarMotivoPermisoNave = True
        End If

    End Function

End Class

