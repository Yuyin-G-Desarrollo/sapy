Imports Entidades
Imports Nomina.Negocios

Public Class RegistroCheckBU

    Public Function buscarBloqueDetalleHorario(ByVal horaCheck As DateTime, ByVal diaCheck As Integer, ByVal horarioID As Integer) As List(Of Entidades.DetalleHorario)
        Dim objDA As New Datos.RegistroCheckDA
        Dim tabla As New DataTable
        buscarBloqueDetalleHorario = New List(Of Entidades.DetalleHorario)
        tabla = objDA.buscar_BloqueDetalleHorario(horaCheck, diaCheck, horarioID)

        For Each fila As DataRow In tabla.Rows

            Dim registroCheckBloque As New Entidades.DetalleHorario
            Dim horario As New Entidades.Horarios
            registroCheckBloque.DH_ID = Integer.Parse(fila("dh_id"))
            registroCheckBloque.DH_HoraCheck = DateTime.Parse(fila("dh_hora_check").ToString).ToLongTimeString
            registroCheckBloque.DH_InicioBloque = DateTime.Parse(fila("dh_inicio_bloque").ToString).ToLongTimeString
            registroCheckBloque.DH_FinBloque = DateTime.Parse(fila("dh_termino_bloque").ToString).ToLongTimeString
            horario.DHorariosid = Integer.Parse(fila("dh_horarioid"))

            registroCheckBloque.DH_horario = horario
            registroCheckBloque.DH_Dia = Integer.Parse(fila("dh_dia"))
            registroCheckBloque.DH_TipoCheck = Integer.Parse(fila("dh_check"))

            buscarBloqueDetalleHorario.Add(registroCheckBloque)

        Next

    End Function


    Public Function buscar_DetalleRegistroCheck(ByVal regcheck_id As Integer, ByVal regcheck_naveid As Integer) As List(Of Entidades.RegistroCheck)
        Dim objDA As New Datos.RegistroCheckDA
        Dim tabla As New DataTable
        buscar_DetalleRegistroCheck = New List(Of Entidades.RegistroCheck)
        tabla = objDA.buscar_DetalleRegistroCheck(regcheck_id, regcheck_naveid)

        For Each fila As DataRow In tabla.Rows

            Dim registroCheck As New Entidades.RegistroCheck
            Dim colaborador As New Entidades.Colaborador
            Dim departamento As New Entidades.Departamentos
            Dim registroExcepcion As New Entidades.RegistroExcepciones
            Dim nave As New Entidades.Naves

            registroCheck.PId = Integer.Parse(fila("regcheck_id"))
            nave.PNaveId = Integer.Parse(fila("regcheck_naveid"))
            registroCheck.Pregcheck_nave = nave
            If Not IsDBNull(fila("regcheck_normal")) Then
                registroCheck.PCheck_normal = Date.Parse(fila("regcheck_normal"))
            Else
                registroCheck.PCheck_normal = Nothing
            End If

            If Not IsDBNull(fila("regcheck_automatico")) Then
                registroCheck.PCheck_automatico = Date.Parse(fila("regcheck_automatico"))
            Else
                registroCheck.PCheck_automatico = Nothing
            End If


            If Not IsDBNull(fila("regcheck_manual")) Then
                registroCheck.PCheck_manual = Date.Parse(fila("regcheck_manual"))
            Else
                registroCheck.PCheck_manual = Nothing
            End If

            colaborador.PColaboradorid = Integer.Parse(fila("regcheck_colaborador"))
            registroCheck.PCheck_Colaborador = colaborador
            registroCheck.PCheck_Resultado = Integer.Parse(fila("regcheck_resultado"))
            registroCheck.PCheck_Tipo = Integer.Parse(fila("regcheck_tipo_check"))

            departamento.Ddepartamentoid = Integer.Parse(fila("grup_grupoid"))
            registroCheck.Pregcheck_departamento = departamento

            If Not IsDBNull(fila("regcheck_excepcion_id")) Then
                registroExcepcion.Pregexc_id = Integer.Parse(fila("regcheck_excepcion_id"))
                registroCheck.PCheck_Excepcion = registroExcepcion
            Else
                registroExcepcion.Pregexc_id = Nothing
                registroCheck.PCheck_Excepcion = registroExcepcion
            End If

            buscar_DetalleRegistroCheck.Add(registroCheck)

        Next

    End Function


    Public Sub guardar_RegistroCheck(ByVal check_flag As Integer, ByVal registroCheck As Entidades.RegistroCheck)

        Dim objGuardarRegistroCheck As New Datos.RegistroCheckDA

        objGuardarRegistroCheck.guardar_RegistroCheck(check_flag, registroCheck)

    End Sub

    Public Function buscarRegistroPrevioCheck(ByVal tipoCheck As Integer, ByVal colaboradorID As Integer) As List(Of Entidades.RegistroCheck)

        Dim objDA As New Datos.RegistroCheckDA
        Dim tabla As New DataTable
        buscarRegistroPrevioCheck = New List(Of Entidades.RegistroCheck)
        tabla = objDA.buscar_RegistroPrevioCheck(tipoCheck, colaboradorID)

        For Each fila As DataRow In tabla.Rows

            Dim registroCheck As New Entidades.RegistroCheck
            Dim colaborador As New Entidades.Colaborador
            Dim registroExcepcion As New Entidades.RegistroExcepciones
            Dim nave As New Entidades.Naves

            registroCheck.PId = Integer.Parse(fila("regcheck_id"))
            nave.PNaveId = Integer.Parse(fila("regcheck_naveid"))
            registroCheck.Pregcheck_nave = nave
            If Not IsDBNull(fila("regcheck_normal")) Then
                registroCheck.PCheck_normal = Date.Parse(fila("regcheck_normal"))
            Else
                registroCheck.PCheck_normal = Nothing
            End If

            If Not IsDBNull(fila("regcheck_automatico")) Then
                registroCheck.PCheck_automatico = Date.Parse(fila("regcheck_automatico"))
            Else
                registroCheck.PCheck_automatico = Nothing
            End If


            If Not IsDBNull(fila("regcheck_manual")) Then
                registroCheck.PCheck_manual = Date.Parse(fila("regcheck_manual"))
            Else
                registroCheck.PCheck_manual = Nothing
            End If

            colaborador.PColaboradorid = Integer.Parse(fila("regcheck_colaborador"))
            registroCheck.PCheck_Colaborador = colaborador
            registroCheck.PCheck_Resultado = Integer.Parse(fila("regcheck_resultado"))
            registroCheck.PCheck_Tipo = Integer.Parse(fila("regcheck_tipo_check"))


            If Not IsDBNull(fila("regcheck_excepcion_id")) Then
                registroExcepcion.Pregexc_id = Integer.Parse(fila("regcheck_excepcion_id"))
                registroCheck.PCheck_Excepcion = registroExcepcion
            Else
                registroExcepcion.Pregexc_id = Nothing
                registroCheck.PCheck_Excepcion = registroExcepcion
            End If

            buscarRegistroPrevioCheck.Add(registroCheck)

        Next

    End Function


    Public Function buscarRegistroPrevioCheckUlterior(ByVal tipoCheck As Integer, ByVal colaboradorID As Integer) As List(Of Entidades.RegistroCheck)
        Dim objDA As New Datos.RegistroCheckDA
        Dim tabla As New DataTable
        buscarRegistroPrevioCheckUlterior = New List(Of Entidades.RegistroCheck)
        tabla = objDA.buscar_RegistroPrevioCheckUlterior(tipoCheck, colaboradorID)

        For Each fila As DataRow In tabla.Rows

            Dim registroCheck As New Entidades.RegistroCheck
            Dim colaborador As New Entidades.Colaborador
            Dim registroExcepcion As New Entidades.RegistroExcepciones
            Dim nave As New Entidades.Naves

            registroCheck.PId = Integer.Parse(fila("regcheck_id"))
            nave.PNaveId = Integer.Parse(fila("regcheck_naveid"))
            registroCheck.Pregcheck_nave = nave
            If Not IsDBNull(fila("regcheck_normal")) Then
                registroCheck.PCheck_normal = Date.Parse(fila("regcheck_normal"))
            Else
                registroCheck.PCheck_normal = Nothing
            End If

            If Not IsDBNull(fila("regcheck_automatico")) Then
                registroCheck.PCheck_automatico = Date.Parse(fila("regcheck_automatico"))
            Else
                registroCheck.PCheck_automatico = Nothing
            End If


            If Not IsDBNull(fila("regcheck_manual")) Then
                registroCheck.PCheck_manual = Date.Parse(fila("regcheck_manual"))
            Else
                registroCheck.PCheck_manual = Nothing
            End If

            colaborador.PColaboradorid = Integer.Parse(fila("regcheck_colaborador"))
            registroCheck.PCheck_Colaborador = colaborador
            registroCheck.PCheck_Resultado = Integer.Parse(fila("regcheck_resultado"))
            registroCheck.PCheck_Tipo = Integer.Parse(fila("regcheck_tipo_check"))


            If Not IsDBNull(fila("regcheck_excepcion_id")) Then
                registroExcepcion.Pregexc_id = Integer.Parse(fila("regcheck_excepcion_id"))
                registroCheck.PCheck_Excepcion = registroExcepcion
            Else
                registroExcepcion.Pregexc_id = Nothing
                registroCheck.PCheck_Excepcion = registroExcepcion
            End If

            buscarRegistroPrevioCheckUlterior.Add(registroCheck)

        Next

    End Function

    Public Function buscar_Excepcion(ByVal tipoCheck As Integer, ByVal colaboradorID As Integer) As List(Of Entidades.RegistroCheck)
        Dim objDA As New Datos.RegistroCheckDA
        Dim tabla As New DataTable
        buscar_Excepcion = New List(Of Entidades.RegistroCheck)
        tabla = objDA.buscar_Excepcion(tipoCheck, colaboradorID)

        For Each fila As DataRow In tabla.Rows

            Dim registroCheck As New Entidades.RegistroCheck
            Dim colaborador As New Entidades.Colaborador
            Dim registroExcepcion As New Entidades.RegistroExcepciones
            Dim nave As New Entidades.Naves

            registroCheck.PId = Integer.Parse(fila("regcheck_id"))
            nave.PNaveId = Integer.Parse(fila("regcheck_naveid"))
            registroCheck.Pregcheck_nave = nave

            If Not IsDBNull(fila("regcheck_normal")) Then
                registroCheck.PCheck_normal = Date.Parse(fila("regcheck_normal"))
            Else
                registroCheck.PCheck_normal = Nothing
            End If

            If Not IsDBNull(fila("regcheck_automatico")) Then
                registroCheck.PCheck_automatico = Date.Parse(fila("regcheck_automatico"))
            Else
                registroCheck.PCheck_automatico = Nothing
            End If


            If Not IsDBNull(fila("regcheck_manual")) Then
                registroCheck.PCheck_manual = Date.Parse(fila("regcheck_manual"))
            Else
                registroCheck.PCheck_manual = Nothing
            End If

            colaborador.PColaboradorid = Integer.Parse(fila("regcheck_colaborador"))
            registroCheck.PCheck_Colaborador = colaborador
            registroCheck.PCheck_Resultado = Integer.Parse(fila("regcheck_resultado"))
            registroCheck.PCheck_Tipo = Integer.Parse(fila("regcheck_tipo_check"))


            If Not IsDBNull(fila("regcheck_excepcion_id")) Then
                registroExcepcion.Pregexc_id = Integer.Parse(fila("regcheck_excepcion_id"))
                registroExcepcion.Pregexc_fecha_inicio = DateTime.Parse(fila("regexc_fecha_inicio").ToString)
                registroExcepcion.Pregexc_fecha_termino = DateTime.Parse(fila("regexc_fecha_termino").ToString)
                registroExcepcion.Pregexc_hora_inicio = DateTime.Parse(fila("regexc_hora_inicio").ToString)
                registroExcepcion.Pregexc_hora_termino = DateTime.Parse(fila("regexc_hora_termino").ToString)
                registroExcepcion.Pregexc_tipo_excepcion = Integer.Parse(fila("regexc_tipo_excepcion"))
                registroCheck.PCheck_Excepcion = registroExcepcion
            Else
                registroExcepcion.Pregexc_id = Nothing
                registroCheck.PCheck_Excepcion = registroExcepcion
            End If

            buscar_Excepcion.Add(registroCheck)

        Next

    End Function

    Public Function buscar_ExcepcionUlterior(ByVal tipoCheck As Integer, ByVal colaboradorID As Integer) As List(Of Entidades.RegistroCheck)
        Dim objDA As New Datos.RegistroCheckDA
        Dim tabla As New DataTable
        buscar_ExcepcionUlterior = New List(Of Entidades.RegistroCheck)
        tabla = objDA.buscar_ExcepcionUlterior(tipoCheck, colaboradorID)

        For Each fila As DataRow In tabla.Rows

            Dim registroCheck As New Entidades.RegistroCheck
            Dim colaborador As New Entidades.Colaborador
            Dim registroExcepcion As New Entidades.RegistroExcepciones
            Dim nave As New Entidades.Naves

            registroCheck.PId = Integer.Parse(fila("regcheck_id"))
            nave.PNaveId = Integer.Parse(fila("regcheck_naveid"))
            registroCheck.Pregcheck_nave = nave
            If Not IsDBNull(fila("regcheck_normal")) Then
                registroCheck.PCheck_normal = Date.Parse(fila("regcheck_normal"))
            Else
                registroCheck.PCheck_normal = Nothing
            End If

            If Not IsDBNull(fila("regcheck_automatico")) Then
                registroCheck.PCheck_automatico = Date.Parse(fila("regcheck_automatico"))
            Else
                registroCheck.PCheck_automatico = Nothing
            End If


            If Not IsDBNull(fila("regcheck_manual")) Then
                registroCheck.PCheck_manual = Date.Parse(fila("regcheck_manual"))
            Else
                registroCheck.PCheck_manual = Nothing
            End If

            colaborador.PColaboradorid = Integer.Parse(fila("regcheck_colaborador"))
            registroCheck.PCheck_Colaborador = colaborador
            registroCheck.PCheck_Resultado = Integer.Parse(fila("regcheck_resultado"))
            registroCheck.PCheck_Tipo = Integer.Parse(fila("regcheck_tipo_check"))

            If Not IsDBNull(fila("regcheck_excepcion_id")) Then
                registroExcepcion.Pregexc_id = Integer.Parse(fila("regcheck_excepcion_id"))
                registroExcepcion.Pregexc_fecha_inicio = DateTime.Parse(fila("regexc_fecha_inicio").ToString)
                registroExcepcion.Pregexc_fecha_termino = DateTime.Parse(fila("regexc_fecha_termino").ToString)
                registroExcepcion.Pregexc_hora_inicio = DateTime.Parse(fila("regexc_hora_inicio").ToString)
                registroExcepcion.Pregexc_hora_termino = DateTime.Parse(fila("regexc_hora_termino").ToString)
                registroExcepcion.Pregexc_tipo_excepcion = Integer.Parse(fila("regexc_tipo_excepcion"))
                registroCheck.PCheck_Excepcion = registroExcepcion
            Else
                registroExcepcion.Pregexc_id = Nothing
                registroCheck.PCheck_Excepcion = registroExcepcion
            End If

            buscar_ExcepcionUlterior.Add(registroCheck)

        Next

    End Function


    ' Funcion agregada nuevo control de asistencia
    Public Function DetallesRegistro(ByVal regcheck_id As Integer, ByVal nave As Integer) As DataTable
        Dim objDA As New Datos.RegistroCheckDA
        Dim tabla As New DataTable
        tabla = objDA.buscar_DetalleRegistroCheck(regcheck_id, nave)
        Return tabla
    End Function
End Class
