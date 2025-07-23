Imports System.Data.SqlClient

Public Class AdministradorOTFacturacionDA

    Public Function consultaStatusCombo() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        dtResultadoConsulta = objPersistencia.EjecutaConsulta("exec Ventas.SP_FacturacionCalzado_ConsultarStatusOTsFacturacion")

        Return dtResultadoConsulta

    End Function

    Public Function cambiarTipoDocumento(ByVal tipoDocumento As Integer, ByVal ordennTrabajoID As Integer) As DataTable
        Try

            Dim objPersistencia As New Persistencia.OperacionesProcedimientos
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@TipoDocumento"
            parametro.Value = tipoDocumento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@OrdenTrabajoId"
            parametro.Value = ordennTrabajoID
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Ventas].[SP_CambioTipoContrarioDocumento]", listaParametros)
        Catch ex As SqlClient.SqlException
            Throw ex
        End Try
    End Function

    Public Function consultaAdministrador(ByVal TipoFecha As Integer, ByVal FechaInicio As String, ByVal FechaFin As String, ByVal PedidoSAY As String, ByVal PedidoSICY As String, ByVal FolioOT As String, ByVal Cliente As String, ByVal Tienda As String, ByVal StatusOT As Integer, ByVal MostrarAndrea As Integer, ByVal CEDIS As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "TipoFecha"
        parametro.Value = TipoFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSAY"
        parametro.Value = PedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSICY"
        parametro.Value = PedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioOT"
        parametro.Value = FolioOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tienda"
        parametro.Value = Tienda
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "StatusOt"
        parametro.Value = StatusOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MostrarAndrea"
        parametro.Value = MostrarAndrea
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioID"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CEDIS"
        parametro.Value = CEDIS
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ConsultarOTsFacturacion_ConUsuario_v2]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function rechazarOT(ByVal OrdenTrabajo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "OrdenTrabajoId"
        parametro.Value = OrdenTrabajo
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_RechazarOTFacturacion", listaParametros)

        Return dtResultadoConsulta

    End Function


    Public Function guardarSesionUsuarioFacturando(ByVal UsuarioId As Integer, ByVal ColaboradorId As Integer, ByVal UsuarioaNombre As String, ByVal TipoFacturacion As Integer, ByVal OTSeleccionadas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ColaboradorId"
        parametro.Value = ColaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NombreUsuario"
        parametro.Value = UsuarioaNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoFacturacion"
        parametro.Value = TipoFacturacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OrdenesTrabajo"
        parametro.Value = OTSeleccionadas
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_GenerarSesionUsuarioFacturando", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function recuperarSesionUsuarioFacturando(ByVal UsuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_RecuperarSesionGenerada", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function consultarPartidasRechazarAndrea(ByVal OrdenTrabajoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "OrdenTrabajoId"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_RechazoAndrea_ConsultaPartidasOT", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function consultarParesPartidasRechazarAndrea(ByVal OrdenTrabajoId As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "OrdenTrabajoId"
        parametro.Value = OrdenTrabajoId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_RechazoAndrea_ConsultaParesPartidasOT", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function rechazarPartidasAndrea(ByVal OrdenTrabajoDetalleId As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "OrdenTrabajoDetalleId"
        parametro.Value = OrdenTrabajoDetalleId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_RechazoAndrea_RechazarPartidasFacturacion", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function rechazarParesAndrea(ByVal OrdenTrabajoDetalleId As String, ByVal CodigoPar As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "OrdenTrabajoDetalleId"
        parametro.Value = OrdenTrabajoDetalleId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CodigoPar"
        parametro.Value = CodigoPar
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_RechazoAndrea_RechazarParesFacturacion", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ParesRechazadosOTs(ByVal OrdenTrabajoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "OTs"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ParesRechazadosOT]", listaParametros)

    End Function

    Public Function ValidacionClientesContado(ByVal ClienteID As Integer, ByVal OrdenTrabajoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ClienteId"
        parametro.Value = ClienteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OT"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ConsultarPagosOT]", listaParametros)

    End Function

    Public Function ObtenerInfomracionCliente(ClienteID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Cliente_ConsultarInformacionCliente]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ValidaFacturasPendientesCancelar(ByVal OTID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@OTID"
            parametro.Value = OTID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Cancelacion_ValidaFacturaCancelada]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TieneSolocitudCancelacionActiva(ByVal tipoDocumento As Integer) As DataTable
        Try

            Dim objPersistencia As New Persistencia.OperacionesProcedimientos
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@DocumentoID"
            parametro.Value = tipoDocumento
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_TieneSolocitudCancelacionActiva]", listaParametros)
        Catch ex As SqlClient.SqlException
            Throw ex
        End Try
    End Function


End Class
