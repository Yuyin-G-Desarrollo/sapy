Imports System.Data.SqlClient

Public Class SeguimientoVentasDA

    Public Function ReporteSeguimientoVentasPorAgente(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Marca As String, ByVal Cliente As String, ByVal IdUsuario As Integer, familia As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClientesIDSay"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgentesIDSay"
        parametro.Value = Agente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MarcasIDSay"
        parametro.Value = Marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IDUsuarioSAY"
        parametro.Value = IdUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FamiliaIDSAY"
        parametro.Value = familia
        listaParametros.Add(parametro)


        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_SeguimientoVentas_PorAgente_v2", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function SeguimientoVentasObtenerEncabezadosTabla(ByVal Spid As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "spid"
        parametro.Value = Spid
        listaParametros.Add(parametro)


        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_ReportesSay_SeguimientoVentas_SeleccionarEncabezadosReporte]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Sub SeguimientoVentasLimpiarEncabezadosTabla(ByVal Spid As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "spid"
        parametro.Value = Spid
        listaParametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_ReportesSay_SeguimientoVentas_EliminarEncabezadosReporte]", listaParametros)

    End Sub

    Public Function ReporteSeguimientoVentasFrecuenciaCompra(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Marca As String, ByVal Cliente As String, ByVal IdUsuario As Integer, ByVal FactorFrecuenciaCompra As Integer, familia As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClientesIDSay"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgentesIDSay"
        parametro.Value = Agente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MarcasIDSay"
        parametro.Value = Marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IDUsuarioSAY"
        parametro.Value = IdUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FactorFrecuenciaCompra"
        parametro.Value = FactorFrecuenciaCompra
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FamiliaIDSAY"
        parametro.Value = familia
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_SeguimientoVentas_FrecuenciaCompra_v2", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ReporteSeguimientoVentasPorAgenteResumen(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Marca As String, ByVal Cliente As String, ByVal IdUsuario As Integer, familia As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClientesIDSay"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgentesIDSay"
        parametro.Value = Agente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MarcasIDSay"
        parametro.Value = Marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IDUsuarioSAY"
        parametro.Value = IdUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FamiliaIDSAY"
        parametro.Value = familia
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_SeguimientoVentas_PorAgente_Resumen_v2", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ReporteSeguimientoFrecuenciaPedidosPorCliente(FechaInicio As Date,
                                                       FechaFin As Date,
                                                       Cliente As String,
                                                       Agente As String,
                                                       Marca As String,
                                                       FactorFrecuenciaCompra As Integer,
                                                       Familia As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClientesIDSay"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgentesIDSay"
        parametro.Value = Agente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MarcasIDSay"
        parametro.Value = Marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IDUsuarioSAY"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FactorFrecuenciaCompra"
        parametro.Value = FactorFrecuenciaCompra
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FamiliaIDSAY"
        parametro.Value = Familia
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_ReportesSay_SeguimientoVentas_FrecuenciaPedidosCliente]", listaParametros)

        Return dtResultadoConsulta
    End Function

End Class
