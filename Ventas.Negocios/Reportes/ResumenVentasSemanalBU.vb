Public Class ResumenVentasSemanalBU
    Dim objResumenVentasDA As Datos.ResumenVentasSemanalDA


    Public Function ReporteGeneralVentasClasificacionCliente(ByVal Reporte As Int16, ByVal UsuarioId As Integer, ByVal FechaInicio As String,
                                                    ByVal FechaFin As String, ByVal Cliente As String, ByVal Agente As String, ByVal Marca As String,
                                                    ByVal Familia As String, ByVal Coleccion As String,
                                                    ByVal AñoComparacion1 As Integer, ByVal AñoComparacion2 As Integer) As DataTable
        objResumenVentasDA = New Datos.ResumenVentasSemanalDA
        Dim dt As New DataTable
        Try

            Select Case Reporte
                Case 1 ''Reporte General de Ventas Semanal - Por Clasificación
                    dt = objResumenVentasDA.ReporteGeneralVentasClasificacion(Reporte, UsuarioId, FechaInicio, FechaFin, Cliente, Agente, Marca,
                                                     Familia, Coleccion, AñoComparacion1, AñoComparacion2)
                Case 2 ''Reporte General de Ventas Semanal - Por Clasificación Cliente
                    dt = objResumenVentasDA.ReporteGeneralVentasClasificacionCliente(Reporte, UsuarioId, FechaInicio, FechaFin, Cliente, Agente, Marca,
                                                     Familia, Coleccion, AñoComparacion1, AñoComparacion2)
                Case 3 '' Por Agente
                    dt = objResumenVentasDA.ReporteGeneralVentasAgente(Reporte, UsuarioId, FechaInicio, FechaFin, Cliente, Agente, Marca,
                                                     Familia, Coleccion, AñoComparacion1, AñoComparacion2)
                Case 4 ''Frecuencia de pedidos Agente
                    dt = objResumenVentasDA.ReporteGeneralVentasFrecuenciaPedidosAgente(Reporte, UsuarioId, FechaInicio, FechaFin, Cliente, Agente, Marca,
                                                     Familia, Coleccion, AñoComparacion1, AñoComparacion2)
                Case 5 ''Frecuencia de pedidos Agente - Grupo por marcas
                    dt = objResumenVentasDA.ReporteGeneralVentasFrecuenciaPedidosAgente_GrupoMarcas(Reporte, UsuarioId, FechaInicio, FechaFin, Cliente, Agente, Marca,
                                                     Familia, Coleccion, AñoComparacion1, AñoComparacion2)
            End Select

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteGeneralVentas_Encabezados(spid As Integer)
        objResumenVentasDA = New Datos.ResumenVentasSemanalDA
        Dim dt As DataTable

        Try
            dt = objResumenVentasDA.ReporteGeneralVentas_Encabezados(spid)
            objResumenVentasDA.ReporteGeneralVentas_LimpiarEncabezados(spid)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub bitacoraExportacionExcel(ByVal UsuarioId As Integer, ByVal Exportado_A As String, ByVal Aplicacion As String, ByVal TipoReporte As String, ByVal FechaInicio As String, ByVal FechaFin As String)

        Try
            objResumenVentasDA.bitacoraExportacionExcel(UsuarioId, Exportado_A, Aplicacion, TipoReporte, FechaInicio, FechaFin)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function consultaPerfilUsuario(ByVal usuarioId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.TableroGeneralVentasDA
        Dim tabla As New DataTable
        Try
            tabla = objDA.consultaPerfilUsuario(usuarioId)

            Return tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarFechaFinEstadVentas_Semanal() As DateTime
        Dim objDA As New Ventas.Datos.ResumenVentasSemanalDA
        Dim fechaFin As DateTime
        Dim dtResultadoConsulta As DataTable = objDA.ConsultarFechaFinEstadVentas_Semanal()
        If dtResultadoConsulta.Rows.Count > 0 Then
            fechaFin = dtResultadoConsulta.Rows(0).Item(0)
        Else
            fechaFin = Date.Parse("31/12/" + Date.Now.Year.ToString())
        End If
        Return fechaFin
    End Function

    Public Function ConsultarFechaInicioEstadVentas_Semanal() As DateTime
        Dim objDA As New Ventas.Datos.ResumenVentasSemanalDA
        Dim fechaincio As DateTime
        Dim dtResultadoConsulta As DataTable = objDA.ConsultarFechaInicioEstadVentas_Semanal()
        If dtResultadoConsulta.Rows.Count > 0 Then
            fechaincio = dtResultadoConsulta.Rows(0).Item(0)
        Else
            fechaincio = Date.Parse("1/1/" + Date.Now.Year.ToString())
        End If
        Return fechaincio
    End Function

End Class
