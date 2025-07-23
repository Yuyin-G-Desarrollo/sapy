Public Class IncapacidadesContabilidadBU

    Public Function listadoSolicitudesIncapacidades(ByVal idPatron As Int32, ByVal estatusId As Int32, ByVal nombre As String,
                                                    ByVal porfecha As Boolean, ByVal fechaInicio As String, ByVal fechaFin As String,
                                                    ByVal tipoIncapacidadId As Int32) As DataTable
        Dim objDa As New Datos.IncapacidadesContabilidadDA
        Dim dtListado As New DataTable

        dtListado = objDa.listadoSolicitudesIncapacidades(idPatron, estatusId, nombre, porfecha, fechaInicio, fechaFin, tipoIncapacidadId)

        Return dtListado
    End Function

    Public Function cambiarEstatusIncapacidades(ByVal incapacidadesIds As String, ByVal opcion As Int32) As String
        Dim objDa As New Datos.IncapacidadesContabilidadDA
        Dim dtEstatus As New DataTable
        Dim resul As String = String.Empty

        dtEstatus = objDa.cambiarEstatusIncapacidades(incapacidadesIds, opcion)

        If dtEstatus.Rows.Count > 0 Then
            resul = dtEstatus.Rows(0).Item("mensaje")
        End If

        Return resul
    End Function

    Public Function consultarInformacionSUA(ByVal idIncapcidades As String) As DataTable
        Dim objDa As New Datos.IncapacidadesContabilidadDA
        Dim dtSua As New DataTable

        dtSua = objDa.consultarInformacionSUA(idIncapcidades)

        Return dtSua
    End Function

    Public Function validarEstatus(ByVal idIncapacidad As Int32, ByVal opcion As Int32) As DataTable
        Dim objDa As New Datos.IncapacidadesContabilidadDA
        Dim dtValida As New DataTable
        Dim resul As String = String.Empty

        dtValida = objDa.validarEstatus(idIncapacidad, opcion)
        'If dtValida.Rows.Count > 0 Then
        '    resul = dtValida.Rows(0).Item("mensaje")
        'End If

        Return dtValida
    End Function
End Class
