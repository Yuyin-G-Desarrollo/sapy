Public Class DetalleHorarioBU

    Public Function listaDetalleHorarioTabla(ByVal idHorario As Integer) As DataTable

        Dim objDA As New Datos.DetalleHorarioDA

        Return objDA.listaDetalleHorario(idHorario)

    End Function

    Public Function listaDetalleHorario(ByVal idHorario As Integer) As List(Of Entidades.DetalleHorario)

        Dim objDA As New Datos.DetalleHorarioDA
        Dim tabla As New DataTable
        listaDetalleHorario = New List(Of Entidades.DetalleHorario)
        'tabla = objDA.listaHorarios(nombre, Nave, activo)
        tabla = objDA.listaDetalleHorario(idHorario)

        For Each fila As DataRow In tabla.Rows

            Dim detalleHorario As New Entidades.DetalleHorario
            Dim horario As New Entidades.Horarios

            horario.DHorariosid = CInt(fila("dh_horarioid"))
            horario.DNombre = CStr(fila("hora_nombre").ToString)
            detalleHorario.DH_horario = horario

            detalleHorario.DH_ID = CInt(fila("dh_id"))
            detalleHorario.DH_HoraCheck = CDate(fila("dh_hora_check").ToString).ToShortTimeString
            detalleHorario.DH_InicioBloque = CDate(fila("dh_inicio_bloque").ToString).ToShortTimeString
            detalleHorario.DH_FinBloque = CDate(fila("dh_termino_bloque").ToString).ToShortTimeString
            detalleHorario.DH_Dia = CInt(fila("dh_dia"))
            detalleHorario.DH_TipoCheck = CInt(fila("dh_check"))

            listaDetalleHorario.Add(detalleHorario)

        Next

    End Function


    Public Function buscar_InicioFinBloque(ByVal dh_horarioid As Integer, ByVal dh_check As Integer, ByVal dh_dia As Integer) As List(Of Entidades.DetalleHorario)

        Dim objDA As New Datos.DetalleHorarioDA
        Dim tabla As New DataTable
        buscar_InicioFinBloque = New List(Of Entidades.DetalleHorario)
        'tabla = objDA.listaHorarios(nombre, Nave, activo)
        tabla = objDA.buscar_InicioFinBloque(dh_horarioid, dh_check, dh_dia)

        For Each fila As DataRow In tabla.Rows

            Dim detalleHorario As New Entidades.DetalleHorario
            Dim horario As New Entidades.Horarios

            horario.DHorariosid = CInt(fila("dh_horarioid"))
            'horario.DNombre = CStr(fila("hora_nombre").ToString)
            detalleHorario.DH_horario = horario

            detalleHorario.DH_ID = CInt(fila("dh_id"))
            detalleHorario.DH_HoraCheck = CDate(fila("dh_hora_check").ToString).ToShortTimeString
            detalleHorario.DH_InicioBloque = CDate(fila("dh_inicio_bloque").ToString).ToShortTimeString
            detalleHorario.DH_FinBloque = CDate(fila("dh_termino_bloque").ToString).ToShortTimeString
            detalleHorario.DH_Dia = CInt(fila("dh_dia"))
            detalleHorario.DH_TipoCheck = CInt(fila("dh_check"))

            buscar_InicioFinBloque.Add(detalleHorario)

        Next

    End Function

    Public Sub guardarDetalleHorario(ByVal detalleHorario As Entidades.DetalleHorario)

        Dim objDetalleHorario As New Datos.DetalleHorarioDA

        objDetalleHorario.guardarDetalleHorario(detalleHorario)

    End Sub

End Class
