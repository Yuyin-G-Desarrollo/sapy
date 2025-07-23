Public Class RegistroExcepcionesBU


    Public Function consultar_RegistroExcepcionesPeriodo(ByVal naveID As Integer, ByVal PeriodoNomID As Integer, ByVal departamentoID As Integer, ByVal colaboradorID As Integer) As List(Of Entidades.RegistroExcepciones)

        Dim RegistroExcepcionesDA As New Nomina.Datos.RegistroExcepcionesDA
        Dim tabla As New DataTable

        consultar_RegistroExcepcionesPeriodo = New List(Of Entidades.RegistroExcepciones)
        tabla = RegistroExcepcionesDA.buscarRegistrosExcepcionesPeriodo(naveID, PeriodoNomID, departamentoID, colaboradorID)

        Dim filas As Integer = CInt(tabla.Rows.Count)

        For Each fila As DataRow In tabla.Rows

            Dim registroExcepcion As New Entidades.RegistroExcepciones
            Dim usuario_solcita As New Entidades.Usuarios
            Dim usuario_revisa As New Entidades.Usuarios
            Dim motivo As New Entidades.ExcepcionMotivo
            Dim colaborador As New Entidades.Colaborador
            Dim departamento As New Entidades.Departamentos
            Dim nave As New Entidades.Naves


            registroExcepcion.Pregexc_id = Integer.Parse(fila("regexc_id"))

            registroExcepcion.Pregexc_fecha_inicio = Date.Parse(fila("regexc_fecha_inicio"))
            registroExcepcion.Pregexc_fecha_termino = Date.Parse(fila("regexc_fecha_termino"))
            registroExcepcion.Pregexc_hora_inicio = Date.Parse(fila("regexc_hora_inicio").ToString).ToLongTimeString
            registroExcepcion.Pregexc_hora_termino = Date.Parse(fila("regexc_hora_termino").ToString).ToLongTimeString

            usuario_solcita.PUserUsuarioid = Integer.Parse(fila("regexc_usuario_sol"))
            Try
                usuario_solcita.PUserUsername = CStr(fila("sol_username")) 'user_username
                usuario_solcita.PUserNombreReal = CStr(fila("sol_nombrereal")) 'user_nombrereal
                usuario_solcita.PUserEmail = CStr(fila("sol_email")) 'user_email
                registroExcepcion.Pregexc_usuario_sol = usuario_solcita
            Catch ex As Exception

            End Try

            If Not IsDBNull(fila("regexc_usuario_rev")) Then
                usuario_revisa.PUserUsuarioid = Integer.Parse(fila("regexc_usuario_rev"))
                Try
                    usuario_revisa.PUserUsername = CStr(fila("rev_username")) 'user_username
                    usuario_revisa.PUserNombreReal = CStr(fila("rev_nombrereal")) 'user_nombrereal
                    usuario_solcita.PUserEmail = CStr(fila("rev_email")) 'user_email
                    registroExcepcion.Pregexc_usuario_rev = usuario_revisa
                Catch ex As Exception

                End Try

            Else

                usuario_revisa.PUserUsuarioid = Nothing
                usuario_revisa.PUserUsername = Nothing
                usuario_revisa.PUserNombreReal = Nothing
                registroExcepcion.Pregexc_usuario_rev = Nothing

            End If

            registroExcepcion.Pregexc_solicitud_fecha = Date.Parse(fila("regexc_solicitud_fecha"))

            If Not IsDBNull(fila("regexc_revision_fecha")) Then
                registroExcepcion.Pregexc_revision_fecha = Date.Parse(fila("regexc_revision_fecha"))
            Else
                registroExcepcion.Pregexc_revision_fecha = Nothing
            End If

            If Not IsDBNull(fila("regexc_motivo_nota")) Then
                registroExcepcion.Pregexc_motivo_nota = CStr(fila("regexc_motivo_nota")) 'POSIBLE NULL
                registroExcepcion.Pregexc_puntualidad_asistencia = Boolean.Parse(fila("regexc_puntualidad_asistencia"))
                registroExcepcion.Pregexc_caja_ahorro = Boolean.Parse(fila("regexc_caja_ahorro"))
                registroExcepcion.Pregexc_tipo_excepcion = Integer.Parse(fila("regexc_tipo_excepcion"))
            Else
                registroExcepcion.Pregexc_motivo_nota = Nothing
                registroExcepcion.Pregexc_puntualidad_asistencia = Nothing
                registroExcepcion.Pregexc_caja_ahorro = Nothing
                registroExcepcion.Pregexc_tipo_excepcion = Nothing
            End If

            motivo.Pexmot_id = Integer.Parse(fila("exmot_id"))
            motivo.Pexmot_nombre = CStr(fila("exmot_nombre"))
            motivo.Pexmot_puntualidad_asistencia = Boolean.Parse(fila("exmot_puntualidad_asistencia"))
            motivo.Pexmot_caja_ahorro = Boolean.Parse(fila("exmot_caja_ahorro"))

            nave.PNaveId = naveID

            motivo.Pexmot_nave = nave
            registroExcepcion.Pregexc_motivo = motivo

            registroExcepcion.Pregexc_estado_excepcion = Integer.Parse(fila("regexc_estado_excepcion"))

            colaborador.PColaboradorid = Integer.Parse(fila("regexc_colaborador_id"))
            colaborador.PNombre = CStr(fila("codr_nombre"))
            colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            registroExcepcion.Pregexc_colaborador = colaborador

            departamento.Ddepartamentoid = Integer.Parse(fila("grup_grupoid"))
            departamento.DNombre = CStr(fila("grup_name"))
            registroExcepcion.Pregexc_departamento = departamento

            consultar_RegistroExcepcionesPeriodo.Add(registroExcepcion)

        Next

    End Function

    Public Function consultar_RegistroExcepcion(ByVal regCheck As Entidades.RegistroCheck, ByVal permisoDepartamental As Boolean) As List(Of Entidades.RegistroExcepciones)

        Dim RegistroExcepcionesDA As New Nomina.Datos.RegistroExcepcionesDA
        Dim tabla As New DataTable

        consultar_RegistroExcepcion = New List(Of Entidades.RegistroExcepciones)
        tabla = RegistroExcepcionesDA.buscarRegistroExcepcion(regCheck.Pregcheck_nave.PNaveId, regCheck.Pregcheck_departamento.Ddepartamentoid, _
                                                              regCheck.PCheck_Colaborador.PColaboradorid, regCheck.PCheck_Excepcion.Pregexc_id, permisoDepartamental)

        Dim filas As Integer = CInt(tabla.Rows.Count)

        For Each fila As DataRow In tabla.Rows

            Dim registroExcepcion As New Entidades.RegistroExcepciones
            Dim usuario_solcita As New Entidades.Usuarios
            Dim usuario_revisa As New Entidades.Usuarios
            Dim motivo As New Entidades.ExcepcionMotivo
            Dim colaborador As New Entidades.Colaborador
            Dim departamento As New Entidades.Departamentos
            Dim nave As New Entidades.Naves


            registroExcepcion.Pregexc_id = Integer.Parse(fila("regexc_id"))

            registroExcepcion.Pregexc_fecha_inicio = Date.Parse(fila("regexc_fecha_inicio"))
            registroExcepcion.Pregexc_fecha_termino = Date.Parse(fila("regexc_fecha_termino"))
            registroExcepcion.Pregexc_hora_inicio = Date.Parse(fila("regexc_hora_inicio").ToString).ToLongTimeString
            registroExcepcion.Pregexc_hora_termino = Date.Parse(fila("regexc_hora_termino").ToString).ToLongTimeString

            usuario_solcita.PUserUsuarioid = Integer.Parse(fila("regexc_usuario_sol"))
            Try
                usuario_solcita.PUserUsername = CStr(fila("sol_username")) 'user_username
                usuario_solcita.PUserNombreReal = CStr(fila("sol_nombrereal")) 'user_nombrereal
                usuario_solcita.PUserEmail = CStr(fila("sol_email")) 'user_email
                registroExcepcion.Pregexc_usuario_sol = usuario_solcita
            Catch ex As Exception

            End Try

            If Not IsDBNull(fila("regexc_usuario_rev")) Then
                usuario_revisa.PUserUsuarioid = Integer.Parse(fila("regexc_usuario_rev"))
                Try
                    usuario_revisa.PUserUsername = CStr(fila("rev_username")) 'user_username
                    usuario_revisa.PUserNombreReal = CStr(fila("rev_nombrereal")) 'user_nombrereal
                    usuario_solcita.PUserEmail = CStr(fila("rev_email")) 'user_email
                    registroExcepcion.Pregexc_usuario_rev = usuario_revisa
                Catch ex As Exception

                End Try

            Else

                usuario_revisa.PUserUsuarioid = Nothing
                usuario_revisa.PUserUsername = Nothing
                usuario_revisa.PUserNombreReal = Nothing
                registroExcepcion.Pregexc_usuario_rev = Nothing

            End If

            registroExcepcion.Pregexc_solicitud_fecha = Date.Parse(fila("regexc_solicitud_fecha"))

            If Not IsDBNull(fila("regexc_revision_fecha")) Then
                registroExcepcion.Pregexc_revision_fecha = Date.Parse(fila("regexc_revision_fecha"))
            Else
                registroExcepcion.Pregexc_revision_fecha = Nothing
            End If

            If Not IsDBNull(fila("regexc_motivo_nota")) Then
                registroExcepcion.Pregexc_motivo_nota = CStr(fila("regexc_motivo_nota")) 'POSIBLE NULL
                registroExcepcion.Pregexc_puntualidad_asistencia = Boolean.Parse(fila("regexc_puntualidad_asistencia"))
                registroExcepcion.Pregexc_caja_ahorro = Boolean.Parse(fila("regexc_caja_ahorro"))
                registroExcepcion.Pregexc_tipo_excepcion = Integer.Parse(fila("regexc_tipo_excepcion"))
            Else
                registroExcepcion.Pregexc_motivo_nota = Nothing
                registroExcepcion.Pregexc_puntualidad_asistencia = Nothing
                registroExcepcion.Pregexc_caja_ahorro = Nothing
                registroExcepcion.Pregexc_tipo_excepcion = Nothing
            End If

            motivo.Pexmot_id = Integer.Parse(fila("exmot_id"))
            motivo.Pexmot_nombre = CStr(fila("exmot_nombre"))
            motivo.Pexmot_puntualidad_asistencia = Boolean.Parse(fila("exmot_puntualidad_asistencia"))
            motivo.Pexmot_caja_ahorro = Boolean.Parse(fila("exmot_caja_ahorro"))

            nave.PNaveId = regCheck.Pregcheck_nave.PNaveId

            motivo.Pexmot_nave = nave
            registroExcepcion.Pregexc_motivo = motivo

            registroExcepcion.Pregexc_estado_excepcion = Integer.Parse(fila("regexc_estado_excepcion"))

            If Not IsDBNull(fila("regexc_colaborador_id")) Then

                colaborador.PColaboradorid = Integer.Parse(fila("regexc_colaborador_id"))
                colaborador.PNombre = CStr(fila("codr_nombre"))
                colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
                colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            Else

                colaborador.PColaboradorid = 0
                colaborador.PNombre = Nothing
                colaborador.PApaterno = Nothing
                colaborador.PAmaterno = Nothing
            End If

            registroExcepcion.Pregexc_colaborador = colaborador

            departamento.Ddepartamentoid = Integer.Parse(fila("grup_grupoid"))
            departamento.DNombre = CStr(fila("grup_name"))
            registroExcepcion.Pregexc_departamento = departamento

            consultar_RegistroExcepcion.Add(registroExcepcion)

        Next

    End Function

    Public Sub guardar_RegistroExcepcion(ByVal registroExcepcion As Entidades.RegistroExcepciones, _
                                         ByVal regCheck As Entidades.RegistroCheck, ByVal checkAutomatico As DateTime, ByVal bandera As Integer, ByVal velador As Boolean)

        Dim RegistroExcepcionDA As New Datos.RegistroExcepcionesDA

        RegistroExcepcionDA.guardar_RegistroExcepcion(registroExcepcion, regCheck, checkAutomatico, bandera, velador)

    End Sub

    Public Sub aprobar_RegistroExcepcion(ByVal regexc_id As Integer, ByVal colaboradorID As Integer, ByVal horario_id As Integer, ByVal naveID As Integer, _
                                         ByVal bandera As Integer, ByVal PyA As Boolean, ByVal CdA As Boolean)

        '@regexc_id as INTEGER,      	        
        '@colaboradorID AS INTEGER,
        '@horario_id AS INTEGER,
        '@regexc_usuario_rev AS INTEGER,
        '@naveID AS INTEGER,
        '@bandera AS INTEGER
        '@velador AS BOOLEAN

        Dim RegistroExcepcionDA As New Datos.RegistroExcepcionesDA

        RegistroExcepcionDA.aprobar_RegistroExcepcion(regexc_id, colaboradorID, horario_id, naveID, bandera, PyA, CdA)



    End Sub

    Public Function buscar_horarioID(ByVal colaboradorID As Integer) As Integer

        Dim objDA As New Nomina.Datos.RegistroExcepcionesDA
        Dim tabla As New DataTable
        tabla = objDA.buscar_horarioID(colaboradorID)

        buscar_horarioID = 0
        For Each row As DataRow In tabla.Rows
            buscar_horarioID = CInt(row("labo_horarioid"))
        Next

    End Function


    Public Function permiso_Departamental(ByVal regexc_id As Integer) As Boolean

        Dim objDA As New Nomina.Datos.RegistroExcepcionesDA
        Dim tabla As New DataTable
        tabla = objDA.detalleRegistro_Excepcion(regexc_id)

        permiso_Departamental = False
        For Each row As DataRow In tabla.Rows

            If IsDBNull(row("regexc_colaborador_id")) Or IsNothing(row("regexc_colaborador_id")) Then
                Return True
            Else
                Return False
            End If
            'permiso_Departamental = CInt(row("labo_horarioid"))
        Next

    End Function

End Class
