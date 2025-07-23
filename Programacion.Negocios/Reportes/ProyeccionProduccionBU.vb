Public Class ProyeccionProduccionBU


    Public Function obtenerProyeccionProduccionEncabezados(ByVal pClaveGrupo As String)
        Dim objVentasDA As New Programacion.Datos.ProyeccionProduccionDA
        Dim vTable As New DataTable
        Try
            vTable = objVentasDA.ObtieneProyeccionProduccionEncabezados(pClaveGrupo)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                vTable = obtenerProyeccionProduccionEncabezados(pClaveGrupo)
            End If
        End Try
        Return vTable
    End Function

    Public Function obtenerProyeccionProduccionFVO(ByVal pSemanaInicio As Integer, ByVal pSemanaFin As Integer, ByVal pAño As Integer)
        Dim objVentasDA As New Programacion.Datos.ProyeccionProduccionDA
        Dim vTable As New DataTable
        Try
            vTable = objVentasDA.ObtieneProyeccionProduccionFVO(pSemanaInicio, pSemanaFin, pAño)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                vTable = obtenerProyeccionProduccionFVO(pSemanaInicio, pSemanaFin, pAño)
            End If
        End Try
        Return vTable
    End Function

    Public Function obtenerProyeccionProduccionRVO(ByVal pSemanaInicio As Integer, ByVal pSemanaFin As Integer, ByVal pAño As Integer)
        Dim objVentasDA As New Programacion.Datos.ProyeccionProduccionDA
        Dim vTable As New DataTable
        Try
            vTable = objVentasDA.ObtieneProyeccionProduccionRVO(pSemanaInicio, pSemanaFin, pAño)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                vTable = obtenerProyeccionProduccionRVO(pSemanaInicio, pSemanaFin, pAño)
            End If
        End Try
        Return vTable
    End Function

End Class
