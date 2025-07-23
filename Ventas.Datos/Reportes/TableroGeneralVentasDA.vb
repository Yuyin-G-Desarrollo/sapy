Imports System.Data.SqlClient

Public Class TableroGeneralVentasDA

#Region "Encabezados"

    Public Function tableroGeneralVentasObtenerEncabezadosTabla(ByVal Spid As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "spid"
        parametro.Value = Spid
        listaParametros.Add(parametro)


        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadisticoPedidos_SeleccionarEncabezadosReporte", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Sub tableroGeneralVentasLimpiarEncabezadosTabla(ByVal Spid As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "spid"
        parametro.Value = Spid
        listaParametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadisticoPedidos_EliminarEncabezadosReporte", listaParametros)

    End Sub

#End Region

#Region "Indicador Ventas"

    Public Function reporteIndicadorVentas(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Marca As String, ByVal Cliente As String) As DataTable
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
        parametro.ParameterName = "AgentesIDSay"
        parametro.Value = Agente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MarcasIDSay"
        parametro.Value = Marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClientesIDSay"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_TableroGralPeds_IndicadorVentas", listaParametros)

        Return dtResultadoConsulta

    End Function

#End Region

#Region "ClasificacionCliente"

    Public Function reporteClasificacionCliente(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Marca As String, ByVal Cliente As String) As DataTable
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
        parametro.ParameterName = "AgentesIDSay"
        parametro.Value = Agente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MarcasIDSay"
        parametro.Value = Marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClientesIDSay"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_ReportesSay_TableroGralPeds_ClasificacionCliente]", listaParametros)

        Return dtResultadoConsulta

    End Function

#End Region

#Region "Agente Aparador"

    Public Function reporteAgenteAparador(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Marca As String, ByVal Cliente As String) As DataTable
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
        parametro.ParameterName = "AgentesIDSay"
        parametro.Value = Agente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MarcasIDSay"
        parametro.Value = Marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClientesIDSay"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_ReportesSay_TableroGralPeds_AgenteAparador]", listaParametros)

        Return dtResultadoConsulta

    End Function

#End Region

#Region "Indicador por Marca"

    Public Function reporteIndicadorMarca(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Marca As String, ByVal Cliente As String) As DataTable
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

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_ReportesSay_TableroGralPeds_IndicadorMarcas]", listaParametros)

        Return dtResultadoConsulta

    End Function

#End Region

#Region "Resumen por Marca"

    Public Function reporteResumenMarca(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Marca As String, ByVal Cliente As String) As DataTable
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

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_ReportesSay_TableroGralPeds_ResumenMarca]", listaParametros)

        Return dtResultadoConsulta

    End Function

#End Region

#Region "Indicador Agente-Marca"

    Public Function reporteIndicadorAgenteMarca(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Marca As String, ByVal Cliente As String) As DataTable
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

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_ReportesSay_TableroGralPeds_IndicadorAgentesMarcas]", listaParametros)

        Return dtResultadoConsulta

    End Function

#End Region


#Region "cosulta perfil Usuario"

    Public Function consultaPerfilUsuario(ByVal usuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@usuarioId"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Perfil_Usuario_Tablero", listaParametros)

        Return dtResultadoConsulta

    End Function

#End Region
End Class
