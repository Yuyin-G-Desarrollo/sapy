Public Class EstadisticasVentasBU
    Public Function reporteGeneralConcentradoTotal(ByVal Reporte As Int16,
                                                   ByVal UsuarioId As Integer,
                                                    ByVal FechaInicio As String,
                                                    ByVal FechaFin As String,
                                                    ByVal Cliente As String,
                                                    ByVal Agente As String,
                                                    ByVal Marca As String,
                                                    ByVal Familia As String,
                                                    ByVal Coleccion As String,
                                                    ByVal Estatus As String,
                                                    ByVal ReporteConVenta As Int16
                                                    ) As DataTable
        Dim objDA As New Datos.EstadisticasVentasDA
        Try
            Return objDA.reporteGeneralConcentradoTotal(Reporte, UsuarioId, FechaInicio, FechaFin, Cliente, Agente, Marca, Familia, Coleccion, Estatus, ReporteConVenta)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function reporteGeneralConcentradoTotal_Vista(ByVal Reporte As Int16,
                                                  ByVal UsuarioId As Integer,
                                                   ByVal FechaInicio As String,
                                                   ByVal FechaFin As String,
                                                   ByVal Cliente As String,
                                                   ByVal Agente As String,
                                                   ByVal Marca As String,
                                                   ByVal Familia As String,
                                                   ByVal Coleccion As String) As DataTable
        Dim objDA As New Datos.EstadisticasVentasDA
        Try
            Return objDA.reporteGeneralConcentradoTotal_Vista(Reporte, UsuarioId, FechaInicio, FechaFin, Cliente, Agente, Marca, Familia, Coleccion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
