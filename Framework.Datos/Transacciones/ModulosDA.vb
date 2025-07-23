Imports Persistencia
Imports System.Data.SqlClient
Imports Entidades

Public Class ModulosDA

    Public Function MainModules() As DataTable
        Try
            Dim consulta As String
            Dim ObjPersistencia As New OperacionesProcedimientos
            consulta = "SELECT modu_moduloid, modu_nombre, modu_iconosapy as modu_icono, modu_componente, modu_archivoreporte, modu_clave, modu_componenteweb, modu_imagenweb, modu_moduloweb,modu_moduloescritorio"
            consulta += " from Framework.Modulos where modu_superiorid is null AND modu_activo='True' and modu_menu='True'"
            MainModules = New DataTable
            MainModules = ObjPersistencia.EjecutaConsulta(consulta)
            Return MainModules
        Catch ex As SqlClient.SqlException
            Throw ex
        End Try
    End Function

    Public Function ChildModules(ByVal Superiorid As Int32) As DataTable
        Try
            Dim consulta As String
            Dim ObjPersistencia As New OperacionesProcedimientos
            consulta = "SELECT modu_moduloid, modu_nombre, modu_icono, modu_componente,modu_archivoreporte, modu_clave, modu_componenteweb, modu_imagenweb, modu_moduloweb,modu_moduloescritorio from Framework.Modulos where modu_activo='True' and modu_menu='True' and modu_superiorid=" + Superiorid.ToString + " order by modu_orden asc"
            ChildModules = New DataTable
            ChildModules = ObjPersistencia.EjecutaConsulta(consulta)
            Return ChildModules
        Catch ex As SqlClient.SqlException
            Throw ex
        End Try
    End Function

    Public Function BuscarModulo(ByVal NombreModulo As String) As DataTable
        Try
            Dim consulta As String
            Dim ObjPersistencia As New OperacionesProcedimientos
            consulta = "SELECT modu_componente from Framework.Modulos where modu_activo='True' and modu_menu='True' and modu_nombre like '" + NombreModulo + "'"
            BuscarModulo = New DataTable
            BuscarModulo = ObjPersistencia.EjecutaConsulta(consulta)
            Return BuscarModulo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListaTodosModulos() As DataTable
        Dim ObjPersistencia As New OperacionesProcedimientos
        Dim consulta As String = " SELECT * from Framework.Modulos where modu_activo='True' order by modu_nombre, modu_superiorid"
        Return ObjPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function ListaModulos(ByVal nombre As String, ByVal clave As String, ByVal componente As String, ByVal menu As Boolean, ByVal activo As Boolean, ByVal guardarhistorial As Boolean, ByVal archivoreporte As String, ByVal superior As Int32) As DataTable
        Dim ObjPersistencia As New OperacionesProcedimientos
        Dim consulta As String = " SELECT * from Framework.Modulos "
        consulta += " WHERE modu_nombre Like '%" + nombre + "%'" +
        " AND modu_clave LIKE '%" + clave + "%'" +
        " AND modu_menu='" + menu.ToString + "'" +
        " AND modu_activo='" + activo.ToString + "'" +
        " AND modu_guardarhistorial='" + guardarhistorial.ToString + "'"

        If archivoreporte.Length > 0 Then
            consulta += " AND modu_archivoreporte LIKE '%" + archivoreporte + "%'"
        End If
        If componente.Length > 0 Then
            consulta += " AND modu_componente LIKE '%" + componente + "%'"
        End If
        If superior > 0 Then
            consulta += " AND modu_superiorid=" + superior.ToString
        End If

        Return ObjPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function BuscarModulo(ByVal moduloid As Int32) As DataTable
        Dim ObjPersistencia As New OperacionesProcedimientos
        Dim consulta As String = " SELECT * from Framework.Modulos where modu_moduloid=" + moduloid.ToString
        Return ObjPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Sub GuardarModulo(ByVal modulo As Modulos)
        Dim operaciones As New OperacionesProcedimientos
        Dim ParametrosList As New List(Of SqlParameter)

        Dim Param As New SqlParameter
        Param.ParameterName = "nombre"
        Param.Value = modulo.PNombre
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "activo"
        Param.Value = modulo.PActivo
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "usuariocreo"
        Param.Value = SesionUsuario.UsuarioSesion.PUserUsuarioid
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "clave"
        Param.Value = modulo.PClave
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "menu"
        Param.Value = modulo.PMenu
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "guardarhistorial"
        Param.Value = modulo.PGuardarHistorial
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "componente"
        Param.Value = modulo.PComponente
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "icono"
        Param.Value = modulo.PIcono
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "archivoreporte"
        Param.Value = modulo.PArchivoReporte
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "superior"
        If IsNothing(modulo.PSuperiorid) Then
            Param.Value = "NULL"
        Else
            Param.Value = modulo.PSuperiorid.PModuloid
        End If
        ParametrosList.Add(Param)

        operaciones.EjecutarSentenciaSP("Framework.SP_altas_modulos", ParametrosList)
    End Sub


    Public Sub EditarModulo(ByVal modulo As Modulos)
        Dim operaciones As New OperacionesProcedimientos
        Dim ParametrosList As New List(Of SqlParameter)

        Dim Param As New SqlParameter
        Param.ParameterName = "@nombre"
        Param.Value = modulo.PNombre
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@activo"
        Param.Value = modulo.PActivo
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@usuariomodifico"
        Param.Value = SesionUsuario.UsuarioSesion.PUserUsuarioid
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@clave"
        Param.Value = modulo.PClave
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@menu"
        Param.Value = modulo.PMenu
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@guardarhistorial"
        Param.Value = modulo.PGuardarHistorial
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@componente"
        Param.Value = modulo.PComponente
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@icono"
        Param.Value = modulo.PIcono
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@archivoreporte"
        Param.Value = modulo.PArchivoReporte
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@moduloid"
        Param.Value = modulo.PModuloid
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@superior"
        If IsNothing(modulo.PSuperiorid) Then
            Param.Value = "NULL"
        Else
            Param.Value = modulo.PSuperiorid.PModuloid
        End If
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@componenteweb"
        Param.Value = modulo.PComponenteWeb
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@imagenweb"
        Param.Value = modulo.PImagenWeb
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@moduloescritorio"
        Param.Value = modulo.PModuloEscritorio
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@moduloweb"
        Param.Value = modulo.PModuloWeb
        ParametrosList.Add(Param)

        operaciones.EjecutarSentenciaSP("Framework.SP_editar_modulo", ParametrosList)
    End Sub

    Public Function VerModulasPadres() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        'Return operacion.EjecutaConsulta("SELECT modu_moduloid, modu_nombre, modu_icono, modu_componente, modu_archivoreporte, modu_clave  from Framework.Modulos where modu_superiorid is null AND modu_activo='True' and modu_menu='True' order by modu_nombre")
        Return operacion.EjecutaConsulta("SELECT modu_moduloid, modu_nombre, modu_icono, modu_componente, modu_archivoreporte, modu_clave  from Framework.Modulos where modu_superiorid is null AND modu_activo='True' order by modu_nombre")
    End Function

    Public Function VerModulosHijos(ByVal idModuloPadre As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        'Return operacion.EjecutaConsulta("SELECT modu_moduloid,  modu_nombre, modu_icono, modu_componente,modu_archivoreporte, modu_clave from Framework.Modulos where modu_activo='True' and modu_menu='True' and modu_superiorid=" + idModuloPadre + " order by modu_nombre")
        Return operacion.EjecutaConsulta("SELECT modu_moduloid, modu_nombre, modu_icono, modu_componente,modu_archivoreporte, modu_clave from Framework.Modulos where modu_activo='True' and modu_superiorid=" + idModuloPadre + " order by modu_nombre")
    End Function

    'Public Function VerModulosHijosDirectos(ByVal moduloPadre As String, ByVal modulo As String) As DataTable
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Return operacion.EjecutaConsulta("SELECT modu_moduloid, modu_nombre, modu_icono, modu_componente,modu_archivoreporte, modu_clave from Framework.Modulos where modu_activo='True' and modu_menu='True' and modu_nombre='" + modulo + "'" +
    '                                     " and modu_superiorid=(select mom.modu_moduloid from Framework.Modulos as mom where mom.modu_nombre='"+moduloPadre +"' and mom.modu_superiorid is null)")
    'End Function

    Public Function VerPerfilesActivos() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadenas As String = "select perf_perfilid,perf_nombre from Framework .Perfiles where perf_activo='true' order by perf_nombre"
        Return operacion.EjecutaConsulta(cadenas)
    End Function

    Public Function VerUsuariosHijosPerfil(ByVal idPerfil As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadenas As String = "select us.user_usuarioid,us.user_nombrereal,us.user_username,pf.perf_perfilid , pf.perf_nombre from Framework.Usuarios as us" +
  " inner join Framework.PerfilesUsuario as pu  on us.user_usuarioid =pu.peus_usuarioid" +
  " inner join Framework.Perfiles as pf on pu.peus_perfilid =pf.perf_perfilid " +
  " where pu.peus_perfilid =" + idPerfil + " and us.user_activo ='True' order by us.user_nombrereal"
        Return operacion.EjecutaConsulta(cadenas)
    End Function

    Public Function VerDetallePerfil(ByVal DescripcionPuesto As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select mo.modu_moduloid ,mo.modu_nombre,  pf.perf_perfilid, pf.perf_nombre  from Framework.Perfiles as pf " +
                                         " inner join Framework.PermisosPerfil  as pp on pf.perf_perfilid=pp.pepe_perfilid " +
                                         " inner join Framework.AccionesModulo as am on pp.pepe_accionid =am.acmo_accionmoduloid " +
                                         " inner join Framework.Modulos as mo on am.acmo_moduloid =mo.modu_moduloid " +
                                         " where pf.perf_activo ='true' and  pf.perf_perfilid ='" + DescripcionPuesto + "' and mo.modu_superiorid is NULL;"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function VerDetallesModulosHijos(ByVal DescriopcionPuesto As String, ByVal moduloSuperior As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("select mo.modu_moduloid ,mo.modu_nombre,  pf.perf_perfilid, pf.perf_nombre, mo.modu_superiorid   from Framework.Perfiles as pf " +
                                         " inner join Framework.PermisosPerfil  as pp on pf.perf_perfilid=pp.pepe_perfilid " +
                                         " inner join Framework.AccionesModulo as am on pp.pepe_accionid =am.acmo_accionmoduloid " +
                                         " inner join  Framework.Modulos as mo on am.acmo_moduloid =mo.modu_moduloid " +
                                         " where pf.perf_activo ='true' and  pf.perf_perfilid='" + DescriopcionPuesto + "' " +
                                         " and mo.modu_superiorid ='" + moduloSuperior + "'")
    End Function


    Public Function VerDetalleHijoPrevioAccion(ByVal DescriopcionPuesto As String, ByVal moduloSuperior As String, ByVal moduloSuperiorPadre As String, ByVal nombreModuloBusqueda As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select mo.modu_moduloid from Framework.Perfiles as pf inner join Framework.PermisosPerfil  as pp on pf.perf_perfilid=pp.pepe_perfilid" +
                                         " inner join Framework.AccionesModulo as am on pp.pepe_accionid =am.acmo_accionmoduloid" +
                                         " inner join  Framework.Modulos as mo on am.acmo_moduloid =mo.modu_moduloid" +
                                         " where pf.perf_activo ='true' and pf.perf_perfilid='" + DescriopcionPuesto + "'  and mo.modu_moduloid ='" + nombreModuloBusqueda + "'" +
                                         " and mo.modu_superiorid ='" + moduloSuperior + "' group by mo.modu_moduloid"
        Return operacion.EjecutaConsulta(cadena)
    End Function



    Public Function verAccionesModulos(ByVal moduloNombreHijoDos As String, ByVal moduloHijoUno As String, ByVal moduloPadre As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select am.acmo_accionmoduloid, am.acmo_nombre from Framework.Modulos as mo " +
" inner join  Framework.AccionesModulo as am on mo.modu_moduloid=am.acmo_moduloid where mo.modu_moduloid ='" + moduloNombreHijoDos + "' " +
" and mo.modu_superiorid='" + moduloHijoUno + "' and am.acmo_activo='True' "
        Return operacion.EjecutaConsulta(cadena)
    End Function


    Public Function VerDetallesAccionModulo(ByVal DescriopcionPuesto As String, ByVal moduloSuperior As String, ByVal moduloSuperiorPadre As String, ByVal nombreModuloBusqueda As String, ByVal Accion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim cadena As String = "select am.acmo_accionmoduloid, am.acmo_nombre from Framework.Modulos as mo" +
        '                                   " inner join  Framework.AccionesModulo as am on mo.modu_moduloid=am.acmo_moduloid" +
        '                                   " inner join Framework.PermisosPerfil as pu on am.acmo_accionmoduloid=pu.pepe_accionid" +
        '                                   " where mo.modu_moduloid ='" + nombreModuloBusqueda + "'" +
        '                                   " and mo.modu_superiorid=(select mom.modu_moduloid from Framework.Modulos as mom where mom.modu_moduloid ='" + moduloSuperior + "'" +
        '                                   " and mom.modu_superiorid=(select modu.modu_moduloid  from Framework.Modulos as modu where modu.modu_moduloid='" + moduloSuperiorPadre + "' and modu.modu_superiorid is null))" +
        '                                   " and pu.pepe_perfilid =(select pp.perf_perfilid from Framework.Perfiles as pp where pp.perf_perfilid='" + DescriopcionPuesto + "' ) and am.acmo_accionmoduloid ='" + Accion + "'"

        Dim cadena As String = "select am.acmo_accionmoduloid, am.acmo_nombre, am.acmo_moduloid from Framework.AccionesModulo as am " +
            " inner join Framework.PermisosPerfil as pu on am.acmo_accionmoduloid=pu.pepe_accionid" +
            " where am.acmo_accionmoduloid =" + Accion + " and am.acmo_moduloid =" + nombreModuloBusqueda + " and pu.pepe_perfilid =" + DescriopcionPuesto + ""
        Return operacion.EjecutaConsulta(cadena)

    End Function




    Public Sub RegistrarPerfilPermisoPadre(ByVal perfil As String, ByVal moduloPadre As String, ByVal moduloHijo As String, ByVal accion As String, ByVal usuario As String)
        Dim operaciones As New OperacionesProcedimientos
        Dim ParametrosList As New List(Of SqlParameter)


        Dim Param As New SqlParameter
        Param.ParameterName = "perfil"
        Param.Value = perfil
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "moduloPadre"
        Param.Value = moduloPadre
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "moduloHijo"
        Param.Value = moduloHijo
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "accion"
        Param.Value = accion
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "usuario"
        Param.Value = usuario
        ParametrosList.Add(Param)


        operaciones.EjecutarSentenciaSP("Framework.SP_Alta_Permiso_Perfil_Modulo_Padre", ParametrosList)
    End Sub



    Public Sub RegistrarPerfilPermisoHijoDos(ByVal perfil As String, ByVal modulo As String, ByVal moduloHijo As String, ByVal moduloPadre As String, ByVal accion As String, ByVal usuario As String)
        Dim operaciones As New OperacionesProcedimientos
        Dim ParametrosList As New List(Of SqlParameter)

        Dim Param As New SqlParameter
        Param.ParameterName = "perfil"
        Param.Value = perfil
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "modulo"
        Param.Value = modulo
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "moduloHijo"
        Param.Value = moduloHijo
        ParametrosList.Add(Param)


        Param = New SqlParameter
        Param.ParameterName = "moduloPapa"
        Param.Value = moduloPadre
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "accion"
        Param.Value = accion
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "usuario"
        Param.Value = usuario
        ParametrosList.Add(Param)


        operaciones.EjecutarSentenciaSP("Framework.SP_Alta_Permiso_Perfil_Modulo", ParametrosList)
    End Sub

    Public Function VeridPerfil(ByVal nombrePerfil As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("SELECT perf_perfilid FROM Framework.Perfiles where perf_nombre='" + nombrePerfil + "' ")
    End Function

    Public Function VerModulosAccionPorPerfil(ByVal idPerfil As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("SELECT pepe_perfilid,pepe_accionid,pepe_usuariocreoid,pepe_fechacreacion  FROM Framework.PermisosPerfil where pepe_perfilid=" + idPerfil + " ")
    End Function

    Public Sub eliminarAccionPerfil(ByVal idaccion As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        operacion.EjecutaSentencia("delete Framework.AccionesModulo where acmo_accionmoduloid =" + idaccion + "")
    End Sub

    Public Sub eliminarPermisoPerfil(ByVal idAccionModulo As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        operacion.EjecutaSentencia("delete Framework.PermisosPerfil where pepe_perfilid =" + idAccionModulo + "")
    End Sub

    Public Function verPermisoPorUsuarioPadre(ByVal idUsuario As String, ByVal nombreModuloPadre As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("select am.acmo_accionmoduloid , mo.modu_nombre, am.acmo_nombre, us.user_nombrereal from Framework.Usuarios as us" +
                                         " inner join Framework.PermisosUsuario as pu on us.user_usuarioid=pu.peru_usuarioid inner join  Framework .AccionesModulo as am on pu.peru_accionid=am.acmo_accionmoduloid" +
                                         " inner join Framework.Modulos as mo on am.acmo_moduloid=mo.modu_moduloid where us.user_usuarioid=" + idUsuario + " and mo.modu_nombre='" + nombreModuloPadre + "' " +
                                         " and mo.modu_superiorid is null")
    End Function

    Public Function verPermisoPorUsuarioHijoUno(ByVal idUsuario As String, ByVal nombreModuloPadre As String, ByVal nombreModuloHijoUno As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("select am.acmo_accionmoduloid , mo.modu_nombre, am.acmo_nombre, us.user_nombrereal from Framework.Usuarios as us" +
                                         " inner join Framework.PermisosUsuario as pu on us.user_usuarioid=pu.peru_usuarioid" +
                                         " inner join  Framework .AccionesModulo as am on pu.peru_accionid=am.acmo_accionmoduloid" +
                                         " inner join Framework.Modulos as mo on am.acmo_moduloid=mo.modu_moduloid where us.user_usuarioid=" + idUsuario + "" +
                                         " and mo.modu_moduloid=" + nombreModuloHijoUno + " and mo.modu_superiorid=" + nombreModuloPadre + "")
    End Function


    Public Function verPermisoPorUsuarioHijoDos(ByVal idUsuario As String, ByVal nombreModuloPadre As String, ByVal nombreModuloHijoUno As String, ByVal nombreModuloHijoDos As String, ByVal tipoPermiso As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select mo.modu_moduloid from Framework.Usuarios as us" +
                                         " inner join Framework.PermisosUsuario as pu on us.user_usuarioid=pu.peru_usuarioid" +
                                         " inner join  Framework .AccionesModulo as am on pu.peru_accionid=am.acmo_accionmoduloid" +
                                         " inner join Framework.Modulos as mo on am.acmo_moduloid=mo.modu_moduloid where us.user_usuarioid=" + idUsuario + "" +
                                         " and mo.modu_moduloid='" + nombreModuloHijoDos + "' and mo.modu_superiorid=" + nombreModuloHijoUno + " and pu.peru_tipopermiso=" + tipoPermiso + " group by mo.modu_moduloid"
        Return operacion.EjecutaConsulta(cadena)
    End Function


    Public Function verPermisoPorUsuarioHijoDosDetalle(ByVal idUsuario As String, ByVal nombreModuloPadre As String, ByVal nombreModuloHijoUno As String, ByVal nombreModuloHijoDos As String, ByVal tipoPermiso As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select am.acmo_accionmoduloid , mo.modu_moduloid, am.acmo_nombre, us.user_nombrereal from Framework.Usuarios as us" +
                                         " inner join Framework.PermisosUsuario as pu on us.user_usuarioid=pu.peru_usuarioid" +
                                         " inner join  Framework .AccionesModulo as am on pu.peru_accionid=am.acmo_accionmoduloid" +
                                         " inner join Framework.Modulos as mo on am.acmo_moduloid=mo.modu_moduloid where pu.peru_usuarioid=" + idUsuario + " and pu.peru_tipopermiso=" + tipoPermiso + ""
        '" and mo.modu_moduloid=" + nombreModuloHijoDos + " and mo.modu_superiorid=" + nombreModuloHijoUno + ""
        Return operacion.EjecutaConsulta(cadena)
    End Function


    Public Function VerModulosAccionPorUsuario(ByVal idUsuario As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("select peru_usuarioid , peru_accionid  from Framework.PermisosUsuario   where peru_usuarioid =" + idUsuario + "")
    End Function

    Public Sub EliminarPermisosPorUsuario(ByVal IdUsuario As String, ByVal tipoPermiso As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        operacion.EjecutaSentencia("delete Framework.PermisosUsuario where peru_usuarioid=" + IdUsuario + " and peru_tipopermiso=" + tipoPermiso + "")
    End Sub

    Public Sub eliminarAccionusUario(ByVal idaccion As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        operacion.EjecutaSentencia("delete Framework.AccionesModulo where acmo_accionmoduloid =" + idaccion + "")
    End Sub

    ' ''-------------------------------------------------------------------------

    Public Sub RegistrarUsuarioPermisoPadre(ByVal idUsuario As String, ByVal moduloPadre As String, ByVal moduloHijo As String, ByVal accion As String, ByVal usuarioCreo As String, ByVal tipoPermiso As String)
        Dim operaciones As New OperacionesProcedimientos
        Dim ParametrosList As New List(Of SqlParameter)


        Dim Param As New SqlParameter
        Param.ParameterName = "idUsuario"
        Param.Value = idUsuario
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "moduloPadre"
        Param.Value = moduloPadre
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "moduloHijo"
        Param.Value = moduloHijo
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "accion"
        Param.Value = accion
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "usuarioCreo"
        Param.Value = usuarioCreo
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "tipoPermiso"
        Param.Value = tipoPermiso
        ParametrosList.Add(Param)

        operaciones.EjecutarSentenciaSP("Framework.SP_Alta_Permiso_Usuario_Modulo_Padre", ParametrosList)
    End Sub



    Public Sub RegistrarUsuarioPermisoHijoDos(ByVal idUsuario As String, ByVal moduloPadre As String, ByVal moduloHijoUno As String, ByVal moduloHijoDos As String, ByVal accion As String, ByVal usuarioCreo As String, ByVal tipoPermiso As String)
        Dim operaciones As New OperacionesProcedimientos
        Dim ParametrosList As New List(Of SqlParameter)

        Dim Param As New SqlParameter
        Param.ParameterName = "idUsuario"
        Param.Value = idUsuario
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "moduloPapa"
        Param.Value = moduloPadre
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "moduloHijo"
        Param.Value = moduloHijoUno
        ParametrosList.Add(Param)


        Param = New SqlParameter
        Param.ParameterName = "modulo"
        Param.Value = moduloHijoDos
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "accion"
        Param.Value = accion
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "usuarioCreo"
        Param.Value = usuarioCreo
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "tipoPermiso"
        Param.Value = tipoPermiso
        ParametrosList.Add(Param)

        operaciones.EjecutarSentenciaSP("Framework.SP_Alta_Permiso_Usuario_Modulo_UltimoHijo", ParametrosList)
    End Sub

    Public Function consultarIdsModulos(ByVal nodoPadre As String, ByVal nodoHijo As String, ByVal nodoNieto As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim ParametrosList As New List(Of SqlParameter)

        Dim Param As New SqlParameter
        Param.ParameterName = "nodoPadre"
        Param.Value = nodoPadre
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "nodoHijo"
        Param.Value = nodoHijo
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "nodoNieto"
        Param.Value = nodoNieto
        ParametrosList.Add(Param)

        Return operaciones.EjecutarConsultaSP("Framework.SP_consulta_modulo", ParametrosList)
    End Function

    '----------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------

    Public Function verIdMaximomodulo() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("select MAX(modu_moduloid) as 'Max' from Framework.Modulos ")
    End Function

    Public Function GuardarModuloArbol(ByVal modulo As Modulos) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim ParametrosList As New List(Of SqlParameter)

        Dim Param As New SqlParameter
        Param.ParameterName = "@nombre"
        Param.Value = modulo.PNombre
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@activo"
        Param.Value = modulo.PActivo
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@usuariocreo"
        Param.Value = SesionUsuario.UsuarioSesion.PUserUsuarioid
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@clave"
        Param.Value = modulo.PClave
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@menu"
        Param.Value = modulo.PMenu
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@guardarhistorial"
        Param.Value = modulo.PGuardarHistorial
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@componente"
        Param.Value = modulo.PComponente
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@icono"
        Param.Value = modulo.PIcono
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@archivoreporte"
        Param.Value = modulo.PArchivoReporte
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@superior"
        If (modulo.PSuperiorid.PModuloid = 0) Then
            Param.Value = DBNull.Value
        Else
            Param.Value = modulo.PSuperiorid.PModuloid
        End If
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@url"
        Param.Value = modulo.PComponenteWeb
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@iconoWEB"
        Param.Value = modulo.PImagenWeb
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@escritotio"
        Param.Value = modulo.PModuloEscritorio
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@esWeb"
        Param.Value = modulo.PModuloWeb
        ParametrosList.Add(Param)

        operaciones.EjecutarSentenciaSP("Framework.SP_altas_modulos_arbol", ParametrosList)

        Return operaciones.EjecutaConsulta("SELECT MAX(modu_moduloid) FROM Framework.Modulos")

    End Function

    Public Function validarExistenciaModulos(ByVal modulo As String, ByVal moduloSuperior As String, ByVal moduloSuperiorPadre As String, ByVal accionModulo As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim ParametrosList As New List(Of SqlParameter)

        Dim Param As New SqlParameter
        Param.ParameterName = "nombreModulo"
        Param.Value = modulo
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "nombreModuloSuperior"
        Param.Value = moduloSuperior
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "nombreModuloSuperiorPadre"
        Param.Value = moduloSuperiorPadre
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "accionModulo"
        Param.Value = accionModulo
        ParametrosList.Add(Param)


        Return operaciones.EjecutarConsultaSP("Framework.SP_Consulta_Modulos_Existentes", ParametrosList)
    End Function

    Public Function verDatosModulo(ByVal idModulo As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT " +
        "modu_moduloid, " +
        "modu_nombre, " +
        "modu_superiorid, " +
        "modu_menu, " +
        "modu_icono, " +
        "modu_componente, " +
        "modu_clave, " +
        "modu_activo, " +
        "modu_menu, " +
        "modu_componenteweb, " +
        "modu_imagenweb, " +
        "modu_moduloescritorio, " +
        "modu_moduloweb " +
        "FROM Framework.Modulos " +
        "WHERE modu_moduloid = " + idModulo
        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Function valoidarRepetidos(ByVal modulo As String, ByVal modSuperior As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        If (modSuperior <> "") Then
            cadena = "select COUNT(*) from Framework.Modulos where modu_nombre ='" + modulo + "' and modu_superiorid =" + modSuperior + " and modu_activo ='True'"
        Else
            cadena = "select COUNT(*) from Framework.Modulos where modu_nombre ='" + modulo + "' and modu_superiorid is NULL and modu_activo ='True'"
        End If
        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Function contarRegistrosRepetidoCambio(ByVal modulo As String, ByVal moduloId As String, ByVal idSuperior As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select COUNT(*) from Framework .Modulos  where modu_nombre ='" + modulo + "' and modu_moduloid =" + moduloId + ""
        If (idSuperior <> "") Then
            cadena += " and modu_superiorid =" + idSuperior + ""
        Else
            cadena += " and modu_superiorid is null"
        End If
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function contarRegistrosRepetidos(ByVal modulo As String, ByVal moduloId As String, ByVal idSuperior As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select COUNT(*) from Framework .Modulos  where modu_nombre ='" + modulo + "' and modu_moduloid not in" +
        " (select modu_moduloid from Framework .Modulos where modu_moduloid =" + moduloId + ""
        If (idSuperior <> "") Then
            cadena += " and modu_superiorid =" + idSuperior + ") and modu_superiorid =" + idSuperior + ""
        Else
            cadena += " and modu_superiorid is null)"
        End If
        Return operacion.EjecutaConsulta(cadena)
    End Function

    '''':::::::::::: ver colaboradores
    Public Function verColaboradoresCombo() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "Select codr_colaboradorid, (codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno) as 'nombre' from Nomina.Colaborador  where codr_activo ='True' order by codr_nombre,codr_apellidopaterno, codr_apellidomaterno"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verColaboradorUnico(ByVal colaborador As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select codr_colaboradorid, (codr_nombre+' '+codr_apellidopaterno +' '+codr_apellidomaterno ) as 'Nombre' from Nomina .Colaborador where codr_colaboradorid =" + colaborador + ""
        Return operacion.EjecutaConsulta(cadena)
    End Function
    '''':::::::::::

    ' ''::::::::::: operaciones para editar ordenamiento de modulos
    Public Function verSubModulos(ByVal moduloSuperios As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT modu_moduloid, modu_nombre, modu_clave FROM Framework.Modulos WHERE modu_superiorid=" + moduloSuperios + " AND modu_activo = 1 ORDER BY modu_orden"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub editarOrdenModulos(ByVal entidadModulo As Entidades.Modulos, ByVal orden As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ParametrosList As New List(Of SqlParameter)

        Dim Param As New SqlParameter
        Param.ParameterName = "@nombre"
        Param.Value = entidadModulo.PNombre
        ParametrosList.Add(Param)


        Param = New SqlParameter
        Param.ParameterName = "@clave"
        Param.Value = entidadModulo.PClave
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@orden"
        Param.Value = orden
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@idModulo"
        Param.Value = entidadModulo.PModuloid
        ParametrosList.Add(Param)

        operacion.EjecutarSentenciaSP("Framework.SP_EditarOrdenModulo", ParametrosList)
    End Sub

    ' '':::::::::::

    Public Sub registroBitacoraLogin(ByVal usuarioid As Integer, ByVal ip As String, ByVal ubicacion As String, ByVal dispositivo As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim ParametrosList As New List(Of SqlParameter)



        Dim Param As New SqlParameter
        Param.ParameterName = "@usuarioid"
        Param.Value = usuarioid
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@ip"
        Param.Value = ip
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@ubicacion"
        Param.Value = ubicacion
        ParametrosList.Add(Param)

        Param = New SqlParameter
        Param.ParameterName = "@dispositivo"
        Param.Value = dispositivo
        ParametrosList.Add(Param)

        operacion.EjecutarSentenciaSP("Framework.sp_login_bitacora", ParametrosList)
    End Sub

    Public Function pruebaBitacoraAcciones(ByVal usuarioid As Integer, ByVal accionid As Integer, ByVal ubicacion As String) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""

        cadena = "select * from Framework.Modulos"

        Return operaciones.EjecutaConsultaConBitacora(cadena, accionid, usuarioid, ubicacion)
    End Function

End Class
