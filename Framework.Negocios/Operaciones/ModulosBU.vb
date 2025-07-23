Imports Entidades
Imports Framework.Datos

Public Class ModulosBU

    Public Function menu(ByVal plataforma As String) As List(Of Modulos)
        Try
            Dim ObjModulosDA As New ModulosDA

            Dim DTMain As New DataTable
            Dim modulo As New Modulos
            menu = New List(Of Modulos)
            DTMain = ObjModulosDA.MainModules()
            For Each row As DataRow In DTMain.Rows
                modulo = New Modulos
                modulo.PModuloid = CInt(row(0))
                If (PermisosUsuarioBU.ConsultarPermisoLectura(modulo.PModuloid)) Then
                    modulo.PNombre = CStr(row(1))
                    If Not (IsDBNull(row(2))) Then
                        modulo.PIcono = CStr(row(2))
                    End If
                    If Not (IsDBNull(row(3))) Then
                        modulo.PComponente = CStr(row(3))
                    End If
                    If Not (IsDBNull(row(4))) Then
                        modulo.PArchivoReporte = CStr(row(4))
                    End If

                    If Not (IsDBNull(row("modu_componenteweb"))) Then
                        modulo.PComponenteWeb = CStr(row("modu_componenteweb"))
                    End If

                    If Not (IsDBNull(row("modu_imagenweb"))) Then
                        modulo.PImagenWeb = CStr(row("modu_imagenweb"))
                    End If

                    If Not (IsDBNull(row("modu_moduloweb"))) Then
                        modulo.PModuloWeb = CBool(row("modu_moduloweb"))
                    End If

                    If Not (IsDBNull(row("modu_moduloescritorio"))) Then
                        modulo.PModuloEscritorio = CBool(row("modu_moduloescritorio"))
                    End If

                    modulo.PClave = CStr(row(5))

                    If plataforma.Equals("WEB") And modulo.PModuloWeb Then
                        menu.Add(modulo)
                    ElseIf plataforma.Equals("ESCRITORIO") And modulo.PModuloEscritorio Then
                        menu.Add(modulo)
                    End If

                End If

            Next
            Return menu
        Catch ex As Exception
            Throw New Exception(HistorialBU.GuardaError(Errores.MensajeInterno(ex)))
        End Try

    End Function

    Public Function menu(ByVal usuarioid As Int32) As List(Of Modulos)
        Try
            Dim ObjModulosDA As New ModulosDA

            Dim DTMain As New DataTable
            Dim modulo As New Modulos
            menu = New List(Of Modulos)
            DTMain = ObjModulosDA.MainModules()
            For Each row As DataRow In DTMain.Rows
                modulo = New Modulos
                modulo.PModuloid = CInt(row(0))
                If (PermisosUsuarioBU.ConsultarPermisoLectura(usuarioid,modulo.PModuloid)) Then
                    modulo.PNombre = CStr(row(1))
                    If Not (IsDBNull(row(2))) Then
                        modulo.PIcono = CStr(row(2))
                    End If
                    If Not (IsDBNull(row(3))) Then
                        modulo.PComponente = CStr(row(3))
                    End If
                    If Not (IsDBNull(row(4))) Then
                        modulo.PArchivoReporte = CStr(row(4))
                    End If
                    If Not (IsDBNull(row("modu_componenteweb"))) Then
                        modulo.PComponenteWeb = CStr(row("modu_componenteweb"))
                    End If

                    If Not (IsDBNull(row("modu_imagenweb"))) Then
                        modulo.PImagenWeb = CStr(row("modu_imagenweb"))
                    End If

                    If Not (IsDBNull(row("modu_moduloweb"))) Then
                        modulo.PModuloWeb = CBool(row("modu_moduloweb"))
                    End If

                    If Not (IsDBNull(row("modu_moduloescritorio"))) Then
                        modulo.PModuloEscritorio = CBool(row("modu_moduloescritorio"))
                    End If

                    modulo.PClave = CStr(row(5))
                    menu.Add(modulo)
                End If

            Next
            Return menu
        Catch ex As Exception
            Throw New Exception(HistorialBU.GuardaError(Errores.MensajeInterno(ex)))
        End Try

    End Function

    Public Function ChildModules(ByVal ParentId As Int32, ByVal plataforma As String) As List(Of Modulos)
        Try
            Dim ObjModulosDA As New ModulosDA

            Dim DTSub As New DataTable
            Dim modulo As New Modulos
            ChildModules = New List(Of Modulos)
            DTSub = ObjModulosDA.ChildModules(ParentId)
            For Each row As DataRow In DTSub.Rows
                modulo = New Modulos
                modulo.PModuloid = CInt(row(0))
                If (PermisosUsuarioBU.ConsultarPermisoLectura(modulo.PModuloid)) Then
                    modulo.PNombre = CStr(row(1))
                    If Not (IsDBNull(row(2))) Then
                        modulo.PIcono = CStr(row(2))
                    End If
                    If Not (IsDBNull(row(3))) Then
                        modulo.PComponente = CStr(row(3))
                    End If
                    If Not (IsDBNull(row(4))) Then
                        modulo.PArchivoReporte = CStr(row(4))
                    End If
                    If Not (IsDBNull(row("modu_componenteweb"))) Then
                        modulo.PComponenteWeb = CStr(row("modu_componenteweb"))
                    End If

                    If Not (IsDBNull(row("modu_imagenweb"))) Then
                        modulo.PImagenWeb = CStr(row("modu_imagenweb"))
                    End If

                    If Not (IsDBNull(row("modu_moduloweb"))) Then
                        modulo.PModuloWeb = CBool(row("modu_moduloweb"))
                    End If

                    If Not (IsDBNull(row("modu_moduloescritorio"))) Then
                        modulo.PModuloEscritorio = CBool(row("modu_moduloescritorio"))
                    End If

                    modulo.PClave = CStr(row(5))
                    If plataforma.Equals("WEB") And modulo.PModuloWeb Then
                        ChildModules.Add(modulo)
                    ElseIf plataforma.Equals("ESCRITORIO") And modulo.PModuloEscritorio Then
                        ChildModules.Add(modulo)
                    End If

                End If
            Next
            Return ChildModules
        Catch ex As Exception
            'Throw New Exception(HistorialBU.GuardaError(Errores.MensajeInterno(ex)))
            Return Nothing
        End Try

    End Function

    Public Function ChildModules(ByVal ParentId As Int32, ByVal usuarioid As Int32) As List(Of Modulos)
        Try
            Dim ObjModulosDA As New ModulosDA

            Dim DTSub As New DataTable
            Dim modulo As New Modulos
            ChildModules = New List(Of Modulos)
            DTSub = ObjModulosDA.ChildModules(ParentId)
            For Each row As DataRow In DTSub.Rows
                modulo = New Modulos
                modulo.PModuloid = CInt(row(0))
                If (PermisosUsuarioBU.ConsultarPermisoLectura(usuarioid, modulo.PModuloid)) Then
                    modulo.PNombre = CStr(row(1))
                    If Not (IsDBNull(row(2))) Then
                        modulo.PIcono = CStr(row(2))
                    End If
                    If Not (IsDBNull(row(3))) Then
                        modulo.PComponente = CStr(row(3))
                    End If
                    If Not (IsDBNull(row(4))) Then
                        modulo.PArchivoReporte = CStr(row(4))
                    End If
                    If Not (IsDBNull(row("modu_componenteweb"))) Then
                        modulo.PComponenteWeb = CStr(row("modu_componenteweb"))
                    End If

                    If Not (IsDBNull(row("modu_imagenweb"))) Then
                        modulo.PImagenWeb = CStr(row("modu_imagenweb"))
                    End If

                    If Not (IsDBNull(row("modu_moduloweb"))) Then
                        modulo.PModuloWeb = CBool(row("modu_moduloweb"))
                    End If

                    If Not (IsDBNull(row("modu_moduloescritorio"))) Then
                        modulo.PModuloEscritorio = CBool(row("modu_moduloescritorio"))
                    End If

                    modulo.PClave = CStr(row(5))
                    ChildModules.Add(modulo)
                End If
            Next
            Return ChildModules
        Catch ex As Exception
            'Throw New Exception(HistorialBU.GuardaError(Errores.MensajeInterno(ex)))
            Return Nothing
        End Try

    End Function

	Public Function BuscarComponente(ByVal ModuloNombre As String) As String
		Dim ObjModulosDA As New ModulosDA
        Dim DTModulo As New DataTable
		DTModulo = ObjModulosDA.BuscarModulo(ModuloNombre)
		BuscarComponente = ""
		For Each row As DataRow In DTModulo.Rows
			BuscarComponente = CStr(row(0))
		Next
		Return BuscarComponente
	End Function

    Public Function ListaModulosTodos() As DataTable
        Dim objDA As New ModulosDA
        Return objDA.ListaTodosModulos
    End Function

    Public Function ListaModulos(ByVal nombre As String, ByVal clave As String, ByVal componente As String, ByVal menu As Boolean, ByVal activo As Boolean, ByVal guardarhistorial As Boolean, ByVal archivoreporte As String, ByVal superior As Int32) As List(Of Modulos)
        Dim objDA As New ModulosDA
        ListaModulos = New List(Of Modulos)
        Dim tabla As New DataTable
        tabla = objDA.ListaModulos(nombre, clave, componente, menu, activo, guardarhistorial, archivoreporte, superior)
        For Each row As DataRow In tabla.Rows
            Dim modulo As New Modulos
            modulo.PModuloid = CInt(row("modu_moduloid"))
            modulo.PNombre = CStr(row("modu_nombre"))

            If Not (IsDBNull(row("modu_icono"))) Then
                modulo.PIcono = CStr(row("modu_icono"))
            End If
            If Not (IsDBNull(row("modu_componente"))) Then
                modulo.PComponente = CStr(row("modu_componente"))
            End If
            If Not (IsDBNull(row("modu_archivoreporte"))) Then
                modulo.PArchivoReporte = CStr(row("modu_archivoreporte"))
            End If
            If Not (IsDBNull(row("modu_guardarhistorial"))) Then
                modulo.PGuardarHistorial = CBool(CStr(row("modu_guardarhistorial")))
            End If
            If Not (IsDBNull(row("modu_menu"))) Then
                modulo.PMenu = CBool(CStr(row("modu_menu")))
            End If

            If Not (IsDBNull(row("modu_activo"))) Then
                modulo.PActivo = CBool(CStr(row("modu_activo")))
            End If

            If Not (IsDBNull(row("modu_superiorid"))) Then
                modulo.PSuperiorid = BuscarModulo(CInt(row("modu_superiorid")))
            End If

            modulo.PClave = CStr(row("modu_clave"))

            ListaModulos.Add(modulo)
        Next
    End Function

    Public Function BuscarModulo(ByVal moduloid As Int32) As Modulos
        BuscarModulo = New Modulos
        Dim objModulosDA As New ModulosDA
        Dim tablaModulo As New DataTable
        tablaModulo = objModulosDA.BuscarModulo(moduloid)
        For Each row As DataRow In tablaModulo.Rows
            BuscarModulo.PModuloid = CInt(row("modu_moduloid"))
            BuscarModulo.PNombre = CStr(row("modu_nombre"))

            If Not (IsDBNull(row("modu_superiorid"))) Then
                BuscarModulo.PSuperiorid = BuscarModulo(CInt(row("modu_superiorid")))
            End If

            If Not (IsDBNull(row("modu_icono"))) Then
                BuscarModulo.PIcono = CStr(row("modu_icono"))
            End If
            If Not (IsDBNull(row("modu_componente"))) Then
                BuscarModulo.PComponente = CStr(row("modu_componente"))
            End If
            If Not (IsDBNull(row("modu_archivoreporte"))) Then
                BuscarModulo.PArchivoReporte = CStr(row("modu_archivoreporte"))
            End If
            If Not (IsDBNull(row("modu_guardarhistorial"))) Then
                BuscarModulo.PGuardarHistorial = CBool(CStr(row("modu_guardarhistorial")))
            End If
            If Not (IsDBNull(row("modu_menu"))) Then
                BuscarModulo.PMenu = CBool(CStr(row("modu_menu")))
            End If
            If Not (IsDBNull(row("modu_activo"))) Then
                BuscarModulo.PActivo = CBool(CStr(row("modu_activo")))
            End If

            BuscarModulo.PClave = CStr(row("modu_clave"))
        Next
        Return BuscarModulo
    End Function

    Public Sub AgregarModulo(ByVal modulo As Modulos)
        Dim objDA As New ModulosDA
        objDA.GuardarModulo(modulo)
    End Sub

    Public Sub EditarModulo(ByVal modulo As Modulos)
        Dim objDA As New ModulosDA
        objDA.EditarModulo(modulo)
    End Sub

    Public Function VerModulosPadres() As DataTable
        Dim objDA As New ModulosDA
        Return objDA.VerModulasPadres()
    End Function

    Public Function VerModulosHijos(ByVal idModuloPardre As String) As DataTable
        Dim objDA As New ModulosDA
        Return objDA.VerModulosHijos(idModuloPardre)
    End Function

    Public Function VerPerfilesActivos() As DataTable
        Dim objDA As New ModulosDA
        Return objDA.VerPerfilesActivos()
    End Function

    Public Function VerUsuariosHijosPerfil(ByVal idPerfil As String) As DataTable
        Dim objDA As New ModulosDA
        Return objDA.VerUsuariosHijosPerfil(idPerfil)
    End Function

    Public Function VerModulosPerfil(ByVal descripcion As String) As DataTable
        Dim objDA As New ModulosDA
        Return objDA.VerDetallePerfil(descripcion)
    End Function


    Public Function VerDetallesModulosHijos(ByVal descripcion As String, ByVal moduloSuperior As String) As DataTable
        Dim objDA As New ModulosDA
        Return objDA.VerDetallesModulosHijos(descripcion, moduloSuperior)
    End Function

    Public Function VerDetalleHijoPrevioAccion(ByVal DescriopcionPuesto As String, ByVal moduloSuperior As String, ByVal moduloSuperiorPadre As String, ByVal nombreModuloBusqueda As String) As DataTable
        Dim objDA As New ModulosDA
        Return objDA.VerDetalleHijoPrevioAccion(DescriopcionPuesto, moduloSuperior, moduloSuperiorPadre, nombreModuloBusqueda)
    End Function

    Public Function VerAccionMooduloSeleccionado(ByVal DescriopcionPuesto As String, ByVal moduloSuperior As String, ByVal moduloSuperiorPadre As String, ByVal nombreModuloBusqueda As String, ByVal Accion As String) As DataTable
        Dim objDA As New ModulosDA
        Return objDA.VerDetallesAccionModulo(DescriopcionPuesto, moduloSuperior, moduloSuperiorPadre, nombreModuloBusqueda, Accion)
    End Function

    Public Function verAccionesModulos(ByVal moduloNombreHijoDos As String, ByVal moduloHijoUno As String, ByVal moduloPadre As String) As DataTable
        Dim objDA As New ModulosDA
        Return objDA.verAccionesModulos(moduloNombreHijoDos, moduloHijoUno, moduloPadre)
    End Function


    Public Sub RegistrarPerfilPermisoPadre(ByVal perfil As String, ByVal moduloPadre As String, ByVal moduloHijo As String, ByVal accion As String, ByVal usuario As String)
        Dim objDA As New ModulosDA
        objDA.RegistrarPerfilPermisoPadre(perfil, moduloPadre, moduloHijo, accion, usuario)
    End Sub


    Public Sub RegistrarPerfilPermisoHijoDos(ByVal perfil As String, ByVal modulo As String, ByVal moduloHijo As String, ByVal moduloPadre As String, ByVal accion As String, ByVal usuario As String)
        Dim objDA As New ModulosDA
        objDA.RegistrarPerfilPermisoHijoDos(perfil, modulo, moduloHijo, moduloPadre, accion, usuario)
    End Sub

    Public Function VeridPerfil(ByVal nombrePerfil As String) As DataTable
        Dim objDA As New ModulosDA
        Return objDA.VeridPerfil(nombrePerfil)
    End Function

    Public Function VerModulosAccionPorPerfil(ByVal idPerfil As String) As DataTable
        Dim objDA As New ModulosDA
        Return objDA.VerModulosAccionPorPerfil(idPerfil)
    End Function


    Public Sub eliminarAccionPerfil(ByVal idaccion As String)
        Dim objDA As New ModulosDA
        objDA.eliminarAccionPerfil(idaccion)
    End Sub

    Public Sub eliminarPermisoPerfil(ByVal idAccionModulo As String)
        Dim objDA As New ModulosDA
        objDA.eliminarPermisoPerfil(idAccionModulo)
    End Sub

    Public Function verPermisoPorUsuarioPadre(ByVal idUsuario As String, ByVal nombreModuloPadre As String) As DataTable
        Dim objDA As New ModulosDA
        Return objDA.verPermisoPorUsuarioPadre(idUsuario, nombreModuloPadre)
    End Function

    Public Function verPermisoPorUsuarioHijoUno(ByVal idUsuario As String, ByVal nombreModuloPadre As String, ByVal nombreModuloHijoUno As String) As DataTable
        Dim objDA As New ModulosDA
        Return objDA.verPermisoPorUsuarioHijoUno(idUsuario, nombreModuloPadre, nombreModuloHijoUno)
    End Function

    Public Function verPermisoPorUsuarioHijoDos(ByVal idUsuario As String, ByVal nombreModuloPadre As String, ByVal nombreModuloHijoUno As String, ByVal nombreModuloHijoDos As String, ByVal tipoPermiso As String) As DataTable
        Dim objDA As New ModulosDA
        Return objDA.verPermisoPorUsuarioHijoDos(idUsuario, nombreModuloPadre, nombreModuloHijoUno, nombreModuloHijoDos, tipoPermiso)
    End Function

    Public Function verPermisoPorUsuarioHijoDosDetalle(ByVal idUsuario As String, ByVal nombreModuloPadre As String, ByVal nombreModuloHijoUno As String, ByVal nombreModuloHijoDos As String, ByVal tipoPermiso As String) As DataTable
        Dim objDA As New ModulosDA
        Return objDA.verPermisoPorUsuarioHijoDosDetalle(idUsuario, nombreModuloPadre, nombreModuloHijoUno, nombreModuloHijoDos, tipoPermiso)
    End Function


    Public Function VerModulosAccionPorUsuario(ByVal idUsuario As String) As DataTable
        Dim objDA As New ModulosDA
        Return objDA.VerModulosAccionPorUsuario(idUsuario)
    End Function

    Public Sub EliminarPermisosPorUsuario(ByVal IdUsuario As String, ByVal tipoPermiso As String)
        Dim objDA As New ModulosDA
        objDA.EliminarPermisosPorUsuario(IdUsuario, tipoPermiso)
    End Sub

    Public Sub eliminarAccionUario(ByVal idaccion As String)
        Dim objDA As New ModulosDA
        objDA.eliminarAccionusUario(idaccion)
    End Sub

    '-------------------------------

    Public Sub RegistrarUsuarioPermisoPadre(ByVal idUsuario As String, ByVal moduloPadre As String, ByVal moduloHijo As String, ByVal accion As String, ByVal usuarioCreo As String, ByVal tipoPermiso As String)
        Dim objDA As New ModulosDA
        objDA.RegistrarUsuarioPermisoPadre(idUsuario, moduloPadre, moduloHijo, accion, usuarioCreo, tipoPermiso)
    End Sub

    Public Sub RegistrarUsuarioPermisoHijoDos(ByVal idUsuario As String, ByVal moduloPadre As String, ByVal moduloHijoUno As String, ByVal moduloHijoDos As String, ByVal accion As String, ByVal usuarioCreo As String, ByVal tipoPermiso As String)
        Dim objDA As New ModulosDA
        objDA.RegistrarUsuarioPermisoHijoDos(idUsuario, moduloPadre, moduloHijoUno, moduloHijoDos, accion, usuarioCreo, tipoPermiso)
    End Sub

    Public Function consultarIdsModulos(ByVal nodoPadre As String, ByVal nodoHijo As String, ByVal nodoNieto As String) As DataTable
        Dim objDA As New ModulosDA
        Return objDA.consultarIdsModulos(nodoPadre, nodoHijo, nodoNieto)
    End Function

    Public Function verIdMaximoModelos() As DataTable
        Dim objMo As New ModulosDA
        Return objMo.verIdMaximomodulo()
    End Function
    '----------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------
    '----------------------------------------------------------------------------------
    Public Function AgregarModuloArbol(ByVal modulo As Entidades.Modulos) As DataTable
        Dim objDA As New ModulosDA
        Return objDA.GuardarModuloArbol(modulo)
    End Function

    Public Function validarExistenciaModulos(ByVal modulo As String, ByVal moduloSuperior As String, ByVal moduloSuperiorPadre As String, ByVal accionModulo As String) As DataTable
        Dim objMo As New ModulosDA
        Return objMo.validarExistenciaModulos(modulo, moduloSuperior, moduloSuperiorPadre, accionModulo)
    End Function

    Public Function verDatosModulo(ByVal idModulo As String) As DataTable
        Dim objMo As New ModulosDA
        Return objMo.verDatosModulo(idModulo)
    End Function

    Public Function valoidarRepetidos(ByVal modulo As String, ByVal modSuperior As String) As DataTable
        Dim objMo As New ModulosDA
        Return objMo.valoidarRepetidos(modulo, modSuperior)
    End Function


    Public Function contarRegistrosCambio(ByVal modulo As String, ByVal idModulo As String, ByVal idSuperior As String) As DataTable
        Dim objMo As New ModulosDA
        Return objMo.contarRegistrosRepetidoCambio(modulo, idModulo, idSuperior)
    End Function

    Public Function contarRegistros(ByVal modulo As String, ByVal idModulo As String, ByVal idSuperior As String) As DataTable
        Dim objMo As New ModulosDA
        Return objMo.contarRegistrosRepetidos(modulo, idModulo, idSuperior)
    End Function

    ''::::::::::::::: colaborador
    Public Function verColaboradoresCombo() As DataTable
        Dim objMo As New ModulosDA
        Return objMo.verColaboradoresCombo()
    End Function

    Public Function verColaboradorUnico(ByVal colaborador As String) As DataTable
        Dim objMo As New ModulosDA
        Return objMo.verColaboradorUnico(colaborador)
    End Function
    '::::::::::::::::::

    ' ''::::::::::: operaciones para editar ordenamiento de modulos
    Public Function verSubModulos(ByVal moduloSuperios As String) As DataTable
        Dim objMo As New ModulosDA
        Return objMo.verSubModulos(moduloSuperios)
    End Function

    Public Sub editarOrdenModulos(ByVal entidadModulo As Entidades.Modulos, ByVal orden As String)
        Dim objMo As New ModulosDA
        objMo.editarOrdenModulos(entidadModulo, orden)
    End Sub
    ' '':::::::::::::

    Public Sub registroBitacoraLogin(ByVal usuarioid As Integer, ByVal ip As String, ByVal ubicacion As String, ByVal dispositivo As String)
        Dim objMo As New ModulosDA
        objMo.registroBitacoraLogin(usuarioid, ip, ubicacion, dispositivo)
    End Sub

    Public Sub pruebaRegistroBitacora(ByVal usuarioid As Integer, ByVal claveAccion As String, ByVal claveModulo As String, ByVal ubicacion As String)
        Dim objMo As New ModulosDA
        Dim objAccionesBu As New AccionesBU
        objMo.pruebaBitacoraAcciones(usuarioid, objAccionesBu.BuscarAccion(claveAccion, claveModulo), ubicacion)
    End Sub
End Class
