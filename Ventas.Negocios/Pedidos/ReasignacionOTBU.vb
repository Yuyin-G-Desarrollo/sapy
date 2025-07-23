Public Class ReasignacionOTBU
    Private objDA As Datos.ReasignacionOTDA

    Public Function ValidarReasignacionPedido(ordenTrabajo As Integer) As DataTable
        Dim dt As DataTable
        objDA = New Datos.ReasignacionOTDA

        dt = objDA.ValidarReasignacionPedido(ordenTrabajo)
        Return dt
    End Function

    Public Function ActualizarReasignacionPedido(ordenTrabajo As Integer, pedidoSAY As Integer) As DataTable
        Dim dt As DataTable
        objDA = New Datos.ReasignacionOTDA

        dt = objDA.ActualizarReasignacionPedido(ordenTrabajo, pedidoSAY)
        Return dt
    End Function

    Public Function ValidarEstatusCancelacionOTDesasignacion(ordenTrabajo As String) As Boolean
        Dim dt As DataTable
        Dim resultado As Boolean = False

        objDA = New Datos.ReasignacionOTDA

        dt = objDA.ValidarEstatusCancelacionOTDesasignacion(ordenTrabajo)

        If dt.Rows.Count > 0 Then
            resultado = CBool(dt.Rows(0).Item(0).ToString)
        End If

        Return resultado
    End Function

    Public Function CancelarOrdenTrabajoDesasignacion(ordenTrabajo As Integer, partidas As String) As Boolean
        Dim dt As New DataTable
        Dim resultado As Boolean = False

        objDA = New Datos.ReasignacionOTDA

        dt = objDA.CancelarOrdenTrabajoDesasignacion(ordenTrabajo, partidas)

        If dt.Rows.Count > 0 Then
            resultado = CBool(dt.Rows(0).Item(0).ToString)
        End If

        Return resultado
    End Function

    Public Function CancelacionOTDesasignacionActualizarPedidos(ordenTrabajo As Integer, partidas As String) As DataTable
        Dim dt As DataTable
        objDA = New Datos.ReasignacionOTDA

        dt = objDA.CancelacionOTDesasignacionActualizarPedidos(ordenTrabajo, partidas)
        Return dt
    End Function

    Public Sub CancelarOrdenTrabajoDesasignacionSICY(ordenTrabajo As Integer, partidas As String)
        Dim dt As DataTable
        objDA = New Datos.ReasignacionOTDA

        objDA.CancelarOrdenTrabajoDesasignacionSICY(ordenTrabajo, partidas)

    End Sub
End Class
