Imports System.Data.SqlClient

Public Class ReporteResumenClienteDA

    Public Function ObtenerTiposReportes() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY

        Return objPersistencia.EjecutaConsulta("[Ventas].[SP_ReportesVentas_ResumenCliente_ObtenerTiposReportes]")

    End Function

    Public Function ConsultaSessionCliente(ByVal Año As String,
                                           ByVal Cliente As String,
                                           ByVal Usuario As Integer,
                                           ByVal TipoCalendario As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter With {
            .ParameterName = "Año",
            .Value = Año
        }
        listaParametros.Add(parametro)

        'parametro = New SqlParameter With {
        '    .ParameterName = "FechaFin",
        '    .Value = FechaFin
        '}
        'listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "ClienteSAYID",
            .Value = Cliente
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "UsuarioId",
            .Value = Usuario
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "TipoCalendario",
            .Value = TipoCalendario
        }
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ReportesVentas_ResumenCliente_GenerarInformacion_4]", listaParametros)

    End Function

    Public Function ConsultaHistoricoVenta(ByVal SessionID As Integer, ByVal TipoCalendario As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro = New SqlParameter With {
            .ParameterName = "SessionId",
            .Value = SessionID
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "TipoCalendario",
            .Value = TipoCalendario
        }
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ReportesVentas_ResumenCliente_ConsultaHistoricoVenta_2]", listaParametros)

    End Function

    Public Function ConsultaProyeccionVenta(ByVal SessionID As Integer, ByVal TipoCalendrio As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro = New SqlParameter With {
            .ParameterName = "SessionId",
            .Value = SessionID
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "TipoCalendario",
            .Value = TipoCalendrio
        }
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ReportesVentas_ResumenCliente_ProyeccionVenta_2]", listaParametros)

    End Function

    Public Function ConsultaComparativoFamilia(ByVal SessionID As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro = New SqlParameter With {
            .ParameterName = "SessionId",
            .Value = SessionID
        }
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ReportesVentas_ResumenCliente_ComparativoFamilia]", listaParametros)

    End Function

    Public Sub BorrarSession(ByVal SessionID As Integer)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro = New SqlParameter With {
            .ParameterName = "SessionId",
            .Value = SessionID
        }
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ReportesVentas_ResumenCliente_BorrarSession]", listaParametros)

    End Sub

    Public Function ConsultaHistoricoVentaCliente(ByVal SessionID As Integer, ByVal ClienteID As Integer) As DataTable
        Dim objPeristenciaSICY As New Persistencia.OperacionesProcedimientosSICY

        Dim dt As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@SessionId"
            parametro.Value = SessionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            dt = objPeristenciaSICY.EjecutarConsultaSP("[Ventas].[SP_ReportesVentas_ResumenCliente_ConsultaHistoricoVenta_Cliente_2]", listaParametros)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CumplimientoVentaCliente(ByVal SessionID As Integer, ByVal ClienteID As Integer) As DataTable
        Dim objPeristenciaSICY As New Persistencia.OperacionesProcedimientosSICY
        Dim dt As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@SessionId"
            parametro.Value = SessionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            dt = objPeristenciaSICY.EjecutarConsultaSP("[Ventas].[SP_ReportesVentas_ResumenCliente_ProyeccionVenta_Cliente_2]", listaParametros)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ComparativoFamiliaCliente(ByVal SessionID As Integer, ByVal ClienteID As Integer) As DataTable
        Dim objPeristenciaSICY As New Persistencia.OperacionesProcedimientosSICY
        Dim dt As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@SessionId"
            parametro.Value = SessionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            dt = objPeristenciaSICY.EjecutarConsultaSP("[Ventas].[SP_ReportesVentas_ResumenCliente_ComparativoFamilia_Cliente]", listaParametros)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EncabezadoReporte(ByVal SessionID As Integer, ByVal ClienteID As Integer) As DataTable
        Dim objPeristenciaSICY As New Persistencia.OperacionesProcedimientosSICY
        Dim dt As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@SessionId"
            parametro.Value = SessionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            dt = objPeristenciaSICY.EjecutarConsultaSP("[Ventas].[SP_ReportesVentas_ResumenCliente_EncabezadoReporte]", listaParametros)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarClientesImpresionReporte(ByVal SessionID As Integer) As DataTable
        Dim objPeristenciaSICY As New Persistencia.OperacionesProcedimientosSICY
        Dim dt As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@SessionId"
            parametro.Value = SessionID
            listaParametros.Add(parametro)


            dt = objPeristenciaSICY.EjecutarConsultaSP("[Ventas].[SP_ReportesVentas_ResumenCliente_Impresion_ConsultaClientes]", listaParametros)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarTiendasMarcaje(ByVal clienteid As String) As DataTable
        Dim objPeristenciaSICY As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@ClienteId"
            parametro.Value = clienteid
            listaParametros.Add(parametro)


            dt = objPeristenciaSICY.EjecutarConsultaSP("[Ventas].[SP_ReportesVentas_ResumenCliente_Impresion_ConsultarTiendasMarcaje]", listaParametros)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
