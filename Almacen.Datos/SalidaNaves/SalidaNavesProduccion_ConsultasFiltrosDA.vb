
Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class SalidaNavesProduccion_ConsultasFiltrosDA

    Private objPersistencia As New Persistencia.OperacionesProcedimientos
    Private objPersistenciaSICY As New Persistencia.OperacionesProcedimientosSICY
    Public Function ConsultarEstatusSalidasNaves() As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNaves_ConsultaEstatus]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarNavesCEDIS() As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNaves_ConsultarNavesCEDIS]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarNavesCEDIS(ByVal IdNave As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@NaveId"
            parametro.Value = IdNave
            ListaParametros.Add(parametro)

            Return objPersistenciaSICY.EjecutarConsultaSP("[Almacen].[SP_SalidaNaves_ConsultarCEDISNave]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ListaNaves(ByVal IDUsuario As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = IDUsuario
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNaves_ConsultarNavesUsuario]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ListaClientes()
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNaves_FiltroClientes]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListaTiendas()
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNaves_FiltroTiendas]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListaArticulos()
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNaves_FiltroArticulos]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListaCorridas()
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNaves_FiltroCorridas]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListaTallas()
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNaves_FiltroTallas]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarSalidasNavesProduccion(ByVal EntidadFiltro As Entidades.FiltrosSalidaNavesProduccion)
        Dim dt As New DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = EntidadFiltro.Usuario.PUserUsuarioid
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaSalidaNave"
            parametro.Value = EntidadFiltro.FechaSalidaNave
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaInicioSalidaNave"
            parametro.Value = EntidadFiltro.FechaInicioSalidaNave
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFinSalidaNave"
            parametro.Value = EntidadFiltro.FechaFinSalidaNave
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaEntradaCEDIS"
            parametro.Value = EntidadFiltro.FechaEntradaCEDIS
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaInicioEntradaCEDIS"
            parametro.Value = EntidadFiltro.FechaInicioEntradaCEDIS
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFinEntradaCEDIS"
            parametro.Value = EntidadFiltro.FechaFinEntradaCEDIS
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaPrograma"
            parametro.Value = EntidadFiltro.FechaPrograma
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaInicioPrograma"
            parametro.Value = EntidadFiltro.FechaInicioPrograma
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFinPrograma"
            parametro.Value = EntidadFiltro.FechaFinPrograma
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@StatusID"
            parametro.Value = EntidadFiltro.StatusID
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ConUbicacion_SI"
            parametro.Value = EntidadFiltro.ConUbicacion_SI
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ConUbicacion_NO"
            parametro.Value = EntidadFiltro.ConUbicacion_NO
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CEDIS_id"
            parametro.Value = EntidadFiltro.CEDIS_id
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SinCEDIS"
            parametro.Value = EntidadFiltro.SinCEDIS
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EntregaMismoDia_SI"
            parametro.Value = EntidadFiltro.EntregaMismoDia_SI
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EntregaMismoDia_NO"
            parametro.Value = EntidadFiltro.EntregaMismoDia_NO
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NavesID"
            parametro.Value = EntidadFiltro.NavesID
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = EntidadFiltro.FolioSalidaID
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteAño"
            parametro.Value = EntidadFiltro.LoteAño
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Atado"
            parametro.Value = EntidadFiltro.Atado
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoPedido"
            parametro.Value = EntidadFiltro.TipoPedido
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoCliente"
            parametro.Value = EntidadFiltro.TipoCliente
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoTienda"
            parametro.Value = EntidadFiltro.TipoTienda
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoID"
            parametro.Value = EntidadFiltro.PedidoID
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = EntidadFiltro.ClienteID
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TiendaID"
            parametro.Value = EntidadFiltro.TiendaID
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ProductoEstiloID"
            parametro.Value = EntidadFiltro.ProductoEstiloID
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CorridaID"
            parametro.Value = EntidadFiltro.CorridaID
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Talla"
            parametro.Value = EntidadFiltro.Talla
            ListaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Condicion"
            parametro.Value = EntidadFiltro.Condicion
            ListaParametros.Add(parametro)

            Select Case EntidadFiltro.TipoConsulta
                Case "Detallada (Por Par)"
                    dt = objPersistenciaSICY.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Auditoria_Detallado]", ListaParametros)
                Case "Auditoría de Entradas"
                    dt = objPersistenciaSICY.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Auditoria_General]", ListaParametros)
                Case "Auditoría de Entradas (Por CEDIS)"
                    dt = objPersistenciaSICY.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Auditoria_PorCEDIS]", ListaParametros)
            End Select

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerTotalParesRecibidos(ByVal NaveSICYID As Integer, ByVal FechaSalidaInicio As Date, ByVal FechaSalidaFin As Date, ByVal CedisID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdNaveSICY"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaSalidaInicio"
            parametro.Value = FechaSalidaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaSalidaFin"
            parametro.Value = FechaSalidaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NumeroAlmacen"
            parametro.Value = CedisID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AuditoriaSalidaNaves_ReporteTotalParesRecibidos]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerTotalParesNoEmbarcados(ByVal NaveSICYID As Integer, ByVal FechaSalidaInicio As Date, ByVal FechaSalidaFin As Date, ByVal CedisID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdNaveSICY"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaSalidaInicio"
            parametro.Value = FechaSalidaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaSalidaFin"
            parametro.Value = FechaSalidaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NumeroAlmacen"
            parametro.Value = CedisID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AuditoriaSalidaNaves_ReporteTotalParesNoEmbarcados]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerTotalParesFaltantes(ByVal NaveSICYID As Integer, ByVal FechaSalidaInicio As Date, ByVal FechaSalidaFin As Date, ByVal CedisID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdNaveSICY"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaSalidaInicio"
            parametro.Value = FechaSalidaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaSalidaFin"
            parametro.Value = FechaSalidaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NumeroAlmacen"
            parametro.Value = CedisID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_AuditoriaSalidaNaves_ReporteTotalParesFaltantes]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
