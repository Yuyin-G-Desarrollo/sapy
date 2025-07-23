

Public Class EstadisticaVentasFamiliaBU

    Public Function reporteEstadisticaVentasPorFamilia(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Cliente As String, ByVal Agente As String, ByVal UsuarioId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.EstadisticaVentasFamiliaDA
        Dim tabla As New DataTable
        tabla = objDA.reporteEstadisticaVentasPorFamilia(FechaInicio, FechaFin, Cliente, Agente, UsuarioId)

        Return tabla

    End Function

    Public Function reporteEstadisticaFamliasObtenerEncabezadosTabla(ByVal Spid As Integer) As DataTable
        Dim objDA As New Ventas.Datos.EstadisticaVentasFamiliaDA
        Dim tabla As New DataTable
        tabla = objDA.reporteEstadisticaFamiliasObtenerEncabezadosTabla(Spid)

        reporteEstadisticaFamiliasLimpiarEncabezadosTabla(Spid)

        Return tabla

    End Function

    Public Sub reporteEstadisticaFamiliasLimpiarEncabezadosTabla(ByVal Spid As Integer)
        Dim objDA As New Ventas.Datos.EstadisticaVentasFamiliaDA
        Dim tabla As New DataTable
        objDA.reporteEstadisticaFamiliasLimpiarEncabezadosTabla(Spid)
    End Sub

    Public Function reporteEstadisticaVentasPorFamiliaConsultaAnualYMarca(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Cliente As String, ByVal Agente As String, ByVal TipoReporte As Integer, ByVal UsuarioId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.EstadisticaVentasFamiliaDA
        Dim tabla As New DataTable
        If TipoReporte = 1 Then
            tabla = objDA.reporteEstadisticaConsultaAnual(FechaInicio, FechaFin, Cliente, Agente, UsuarioId)
        ElseIf TipoReporte = 2 Then
            tabla = objDA.reporteEstadisticaConsultaMarca(FechaInicio, FechaFin, Cliente, Agente, UsuarioId)
        End If

        Return tabla

    End Function

    Public Function reporteEstadisticaPreventasPorFamilia(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Cliente As String, ByVal Agente As String, ByVal UsuarioId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.EstadisticaVentasFamiliaDA
        Dim tabla As New DataTable
        tabla = objDA.reporteEstadisticaPreventasPorFamilia(FechaInicio, FechaFin, Cliente, Agente, UsuarioId)

        Return tabla

    End Function

    Public Function reporteEstadisticaPreventasFamliasObtenerEncabezadosTabla(ByVal Spid As Integer) As DataTable
        Dim objDA As New Ventas.Datos.EstadisticaVentasFamiliaDA
        Dim tabla As New DataTable
        tabla = objDA.reporteEstadisticaPreventasFamiliasObtenerEncabezadosTabla(Spid)

        reporteEstadisticaPreventasFamiliasLimpiarEncabezadosTabla(Spid)

        Return tabla

    End Function

    Public Sub reporteEstadisticaPreventasFamiliasLimpiarEncabezadosTabla(ByVal Spid As Integer)
        Dim objDA As New Ventas.Datos.EstadisticaVentasFamiliaDA
        Dim tabla As New DataTable
        objDA.reporteEstadisticaPreventasFamiliasLimpiarEncabezadosTabla(Spid)
    End Sub

    Public Function reporteEstadisticaFamliasObtenerPerfilUsuario(ByVal usuarioId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.EstadisticaVentasFamiliaDA
        Dim tabla As New DataTable
        tabla = objDA.reporteEstadisticaFamliasObtenerPerfilUsuario(usuarioId)

        Return tabla

    End Function

End Class
