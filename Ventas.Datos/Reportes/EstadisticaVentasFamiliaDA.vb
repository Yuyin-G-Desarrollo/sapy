Imports System.Data.SqlClient

Public Class EstadisticaVentasFamiliaDA

    Public Function reporteEstadisticaVentasPorFamilia(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Cliente As String, ByVal Agente As String, ByVal UsuarioId As Integer) As DataTable
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
        parametro.ParameterName = "IDClienteSAY"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IDAgentesSAY"
        parametro.Value = Agente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IDUsuarioSAY"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadisticaVentasPorFamilia_PorSemestre", listaParametros)

        Return dtResultadoConsulta

    End Function

#Region "Encabezados"

    Public Function reporteEstadisticaFamiliasObtenerEncabezadosTabla(ByVal Spid As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "spid"
        parametro.Value = Spid
        listaParametros.Add(parametro)


        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadisticaVentasPorFamilia_SeleccionarEncabezadosReporte", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Sub reporteEstadisticaFamiliasLimpiarEncabezadosTabla(ByVal Spid As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "spid"
        parametro.Value = Spid
        listaParametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadisticaVentasPorFamilia_EliminarEncabezadosReporte", listaParametros)

    End Sub

#End Region

    Public Function reporteEstadisticaConsultaAnual(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Cliente As String, ByVal Agente As String, ByVal UsuarioId As Integer) As DataTable
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
        parametro.ParameterName = "IDClienteSAY"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IDAgentesSAY"
        parametro.Value = Agente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IDUsuarioSAY"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadisticaVentasPorFamilia_Anual", listaParametros)

        Return dtResultadoConsulta

    End Function


    Public Function reporteEstadisticaConsultaMarca(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Cliente As String, ByVal Agente As String, ByVal UsuarioId As Integer) As DataTable
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
        parametro.ParameterName = "IDClienteSAY"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IDAgentesSAY"
        parametro.Value = Agente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IDUsuarioSAY"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadisticaVentasPorFamilia_PorMarca", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function reporteEstadisticaPreventasPorFamilia(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Cliente As String, ByVal Agente As String, ByVal UsuarioId As Integer) As DataTable
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
        parametro.ParameterName = "IDClienteSAY"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IDAgentesSAY"
        parametro.Value = Agente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IDUsuarioSAY"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadisticaVentasPorFamilia_PorFamilia", listaParametros)

        Return dtResultadoConsulta

    End Function

#Region "Encabezados Preventas"

    Public Function reporteEstadisticaPreventasFamiliasObtenerEncabezadosTabla(ByVal Spid As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "spid"
        parametro.Value = Spid
        listaParametros.Add(parametro)


        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadisticaPreentasPorFamilia_SeleccionarEncabezadosReporte", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Sub reporteEstadisticaPreventasFamiliasLimpiarEncabezadosTabla(ByVal Spid As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "spid"
        parametro.Value = Spid
        listaParametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadisticaPreventasPorFamilia_EliminarEncabezadosReporte", listaParametros)

    End Sub

#End Region

    Public Function reporteEstadisticaFamliasObtenerPerfilUsuario(ByVal UsuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IDUsuarioSAY"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)


        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadisticaVentasPorFamilia_VerificarPerfilUsurario", listaParametros)

        Return dtResultadoConsulta

    End Function

End Class
