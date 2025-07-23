Public Class ReportesDA

    Public Sub AltaReportes(ByVal Reportes As Entidades.Reportes)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Sentencia As String = ""

        Sentencia = "INSERT INTO Framework.Reportes (repo_esquema, repo_nombrereporte, repo_xml, repo_clavereporte, repo_activo, repo_usuariocreo, repo_fechacreacion,repo_usuariosolicito,repo_fechasolicitud) " +
            " values ('" + Reportes.Pesquema.ToString + "','" + Reportes.Pnombre + "','" + Reportes.Pxml + "','" + Reportes.PClavereporte.ToString + "'," + CInt(Reportes.Pactivo).ToString + "," +
            Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ",(select GETDATE()),'" + Reportes.PSolicito + "', (select GETDATE()))"

        operaciones.EjecutaConsulta(Sentencia)
    End Sub


    Public Sub ActualizarReporte(ByVal Reporte As Entidades.Reportes)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim strsql = String.Empty
        Dim print As String

        If Reporte.Pxml.Length > 0 Then
            strsql = "update Framework.Reportes  set repo_esquema='" + Reporte.Pesquema + "',repo_nombrereporte = '" + Reporte.Pnombre + "',repo_xml = '" + Reporte.Pxml _
                    + "',repo_Activo= " + CInt(Reporte.Pactivo).ToString + ", repo_clavereporte ='" + Reporte.PClavereporte +
                    "' , repo_usuariomodifico = '" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
                    "', repo_usuariosolicitocambio='" + Reporte.PSolicito + "' ,repo_fechasolicitocambio=getdate() " +
                    ", repo_fechamodificacion = (select GETDATE()) where repo_reporteid= " + Reporte.Preporteid.ToString
        Else
            strsql = "update Framework.Reportes  set repo_esquema='" + Reporte.Pesquema + "',repo_nombrereporte = '" + Reporte.Pnombre + "'" _
                    + ",repo_Activo= " + CInt(Reporte.Pactivo).ToString + ", repo_clavereporte ='" + Reporte.PClavereporte +
                    "', repo_usuariomodifico = '" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
                    "', repo_usuariosolicitocambio='" + Reporte.PSolicito + "' ,repo_fechasolicitocambio=getdate() " +
                    ", repo_fechamodificacion = (select GETDATE()) where repo_reporteid= " + Reporte.Preporteid.ToString

        End If

        operaciones.EjecutaConsulta(strsql)
    End Sub


    Public Function ListaReportes(ByVal Esquema As String, ByVal Nombre As String, ByVal clave As String, ByVal activo As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim strsql = String.Empty
        strsql = "select repo_reporteid as Id, UPPER(repo_esquema) as Esquema" +
            ", UPPER(repo_nombrereporte) as Nombre,  UPPER(repo_clavereporte) AS Clave" +
            ", repo_activo as Activo from Framework.Reportes" +
            " where repo_esquema like '%" + Esquema + "%'" +
            " and repo_nombrereporte like '%" + Nombre + "%'" +
            " and repo_clavereporte like '%" + clave + "%' and repo_activo = '" + activo.ToString + "' order by Esquema, Nombre"
        Return operaciones.EjecutaConsulta(strsql)
    End Function

    Public Function LeerReporte(ByVal IDReporte As Int32) As Entidades.Reportes
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim EntidadReporte As New Entidades.Reportes
        Dim tabla As DataTable
        tabla = operaciones.EjecutaConsulta("select * from Framework.Reportes where repo_reporteid=" + IDReporte.ToString)
        For Each row As DataRow In tabla.Rows
            EntidadReporte.Pactivo = CBool(row("repo_activo"))
            EntidadReporte.Pesquema = CStr(row("repo_esquema"))
            EntidadReporte.Pnombre = CStr(row("repo_nombrereporte"))
            EntidadReporte.Preporteid = CInt(row("repo_reporteid"))
            EntidadReporte.Pxml = CStr(row("repo_xml"))
        Next
        Return EntidadReporte
    End Function

    Public Function LeerReporteClave(ByVal ClaveReporte As String) As Entidades.Reportes
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim EntidadReporte As New Entidades.Reportes
        Dim tabla As DataTable
        tabla = operaciones.EjecutaConsulta("select repo_reporteid,repo_esquema,RTRIM(repo_nombrereporte) as 'repo_nombrereporte',repo_xml,repo_activo,repo_clavereporte from Framework.Reportes where repo_clavereporte='" + ClaveReporte + "' and repo_activo=1")
        For Each row As DataRow In tabla.Rows

            EntidadReporte.Pactivo = CBool(row("repo_activo"))
            EntidadReporte.Pesquema = CStr(row("repo_esquema"))
            EntidadReporte.Pnombre = CStr(row("repo_nombrereporte"))
            EntidadReporte.Preporteid = CInt(row("repo_reporteid"))
            EntidadReporte.Pxml = CStr(row("repo_xml"))
        Next
        Return EntidadReporte
    End Function



End Class
