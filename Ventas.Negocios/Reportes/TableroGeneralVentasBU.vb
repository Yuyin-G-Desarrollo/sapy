Public Class TableroGeneralVentasBU

#Region "Encabezados"

    Public Function tableroGeneralVentasObtenerEncabezadosTabla(ByVal Spid As Integer) As DataTable
        Dim objDA As New Ventas.Datos.TableroGeneralVentasDA
        Dim tabla As New DataTable
        tabla = objDA.tableroGeneralVentasObtenerEncabezadosTabla(Spid)

        tableroGeneralVentasLimpiarEncabezadosTabla(Spid)

        Return tabla

    End Function

    Public Sub tableroGeneralVentasLimpiarEncabezadosTabla(ByVal Spid As Integer)
        Dim objDA As New Ventas.Datos.TableroGeneralVentasDA
        Dim tabla As New DataTable
        objDA.tableroGeneralVentasLimpiarEncabezadosTabla(Spid)
    End Sub

#End Region

#Region "Tipos Reporte"

    Public Function reportesTableroGeneral(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Marca As String, ByVal Cliente As String, ByVal TipoReporte As Integer) As DataTable
        Dim objDA As New Ventas.Datos.TableroGeneralVentasDA
        Dim tabla As New DataTable

        Select Case TipoReporte
            Case 1
                tabla = objDA.reporteIndicadorVentas(FechaInicio, FechaFin, Agente, Marca, Cliente)
            Case 2
                tabla = objDA.reporteClasificacionCliente(FechaInicio, FechaFin, Agente, Marca, Cliente)
            Case 3
                tabla = objDA.reporteAgenteAparador(FechaInicio, FechaFin, Agente, Marca, Cliente)
            Case 4
                tabla = objDA.reporteIndicadorMarca(FechaInicio, FechaFin, Agente, Marca, Cliente)
            Case 5
                tabla = objDA.reporteResumenMarca(FechaInicio, FechaFin, Agente, Marca, Cliente)
            Case 6
                tabla = objDA.reporteIndicadorAgenteMarca(FechaInicio, FechaFin, Agente, Marca, Cliente)
        End Select

        Return tabla

    End Function

#End Region


#Region "consultas agente"

    Public Function consultaPerfilUsuario(ByVal usuarioId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.TableroGeneralVentasDA
        Dim tabla As New DataTable
        tabla = objDA.consultaPerfilUsuario(usuarioId)

        Return tabla

    End Function
#End Region
End Class
