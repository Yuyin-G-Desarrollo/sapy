Public Class ExcepcionMotivoBU

    Public Function listaMotivoExcepcion(ByVal naveID As Integer) As List(Of Entidades.ExcepcionMotivo)
        Dim objDA As New Datos.ExcepcionMotivoDA
        Dim tabla As New DataTable
        listaMotivoExcepcion = New List(Of Entidades.ExcepcionMotivo)
        tabla = objDA.listaMotivoExcepcion(naveID)
        For Each fila As DataRow In tabla.Rows
            Dim motivoExcepcion As New Entidades.ExcepcionMotivo
            Dim nave As New Entidades.Naves
            motivoExcepcion.Pexmot_id = Integer.Parse(fila("exmot_id"))
            motivoExcepcion.Pexmot_nombre = CStr(fila("exmot_nombre"))

            nave.PNaveId = Integer.Parse(fila("exmot_naveid"))

            motivoExcepcion.Pexmot_nave = nave
            motivoExcepcion.Pexmot_puntualidad_asistencia = Boolean.Parse(fila("exmot_puntualidad_asistencia"))
            motivoExcepcion.Pexmot_caja_ahorro = Boolean.Parse(fila("exmot_caja_ahorro"))
            listaMotivoExcepcion.Add(motivoExcepcion)

        Next

    End Function


    Public Function listaIncentivosSegunMotivo(ByVal motivoID As Integer) As List(Of Entidades.ExcepcionMotivo)
        Dim objDA As New Datos.ExcepcionMotivoDA
        Dim tabla As New DataTable
        listaIncentivosSegunMotivo = New List(Of Entidades.ExcepcionMotivo)
        tabla = objDA.listaIncentivosSegunMotivo(motivoID)
        For Each fila As DataRow In tabla.Rows
            Dim motivoExcepcion As New Entidades.ExcepcionMotivo
            Dim nave As New Entidades.Naves
            motivoExcepcion.Pexmot_id = Integer.Parse(fila("exmot_id"))
            motivoExcepcion.Pexmot_nombre = CStr(fila("exmot_nombre"))

            nave.PNaveId = Integer.Parse(fila("exmot_naveid"))

            motivoExcepcion.Pexmot_nave = nave
            motivoExcepcion.Pexmot_puntualidad_asistencia = Boolean.Parse(fila("exmot_puntualidad_asistencia"))
            motivoExcepcion.Pexmot_caja_ahorro = Boolean.Parse(fila("exmot_caja_ahorro"))
            listaIncentivosSegunMotivo.Add(motivoExcepcion)

        Next

    End Function

End Class
