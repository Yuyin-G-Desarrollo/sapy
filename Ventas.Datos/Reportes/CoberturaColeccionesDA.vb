Imports System.Data.SqlClient

Public Class CoberturaColeccionesDA


    Public Function ReporteCoberturaColecciones(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Marca As String, ByVal Cliente As String, ByVal MarcasColeccionSay As String, ByVal IdUsuario As Integer) As DataTable
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
        parametro.ParameterName = "MarcasColeccionIDSay"
        parametro.Value = MarcasColeccionSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IDUsuarioSAY"
        parametro.Value = IdUsuario
        listaParametros.Add(parametro)


        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_ReportesSay_CoberturaColecciones]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function CoberturaColeccionesObtenerEncabezadosTabla(ByVal Spid As Integer) As DataTable
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

    Public Sub CoberturaColeccionesLimpiarEncabezadosTabla(ByVal Spid As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "spid"
        parametro.Value = Spid
        listaParametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_ReportesSay_SeguimientoVentas_EliminarEncabezadosReporte]", listaParametros)

    End Sub

End Class
