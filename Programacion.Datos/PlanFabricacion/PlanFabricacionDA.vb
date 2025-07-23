Imports System.Data.SqlClient
Imports Persistencia
Public Class PlanFabricacionDA

    Public Function ObtenerNavesPorUsuario(ByVal UsuarioID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlParameter)
        Dim Parametro As New SqlParameter

        Parametro = New SqlParameter("@UsuarioID", UsuarioID)
        ListaParametros.Add(Parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_PlanFabricacion_ObtieneNavesPorUsuario]", ListaParametros)

    End Function

    Public Function ObtienePlanFabricacionReporte(ByVal NaveId As String, ByVal Semana As String, ByVal Año As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlParameter)
        Dim Parametro As New SqlParameter

        Parametro = New SqlParameter("@NaveID", NaveId)
        ListaParametros.Add(Parametro)

        Parametro = New SqlParameter("@SemanaCerrada", Semana)
        ListaParametros.Add(Parametro)

        Parametro = New SqlParameter("@AñoSemana", Año)
        ListaParametros.Add(Parametro)


        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_PlanFabricacion_ObtienePlanFabricacion_Reporte]", ListaParametros)
    End Function

    Public Function ObtenerCorreosDestinatario(ByVal pmxlCeldas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@xmlCeldas", pmxlCeldas)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_PlanFabricacion_ObtieneDestinatariosCorreo]", listaParametros)

    End Function

    Public Function consultaCorreosEnvioFactura(ByVal ClaveEnvio As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("ClaveEnvio", ClaveEnvio)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ConsultaDatosCorreosFacturacion", listaParametros)

    End Function

    Public Function ObtieneEstatusPlan() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_PlanFabricacion_ObtieneEstatusPlan]", listaParametros)
    End Function

    Public Function ObtienePlanFabricacion(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer, ByVal Grupo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Semana", Semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", Año)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Grupo", Grupo)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_PlanFabricacion_ObtienePlanFabricacion]", listaParametros)

    End Function

    Public Function ObtieneMotivosSolicitudCambio() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_PlanFabricacion_ObtieneMotivosSolicitudCambio]", listaParametros)
    End Function

    Public Function InsertaSolicitudCambios_PlanFabricacion(ByVal pmxlModificadas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@XMLCeldas", pmxlModificadas)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_PlanFabricacion_InsertaSolicitudCambios]", listaParametros)
    End Function

    Public Function ObtieneBitacoraCambios(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer, ByVal SemanaFin As Integer, ByVal AñoFin As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Semana", Semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", Año)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@SemanaFin", SemanaFin)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@AñoFin", AñoFin)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_PlanFabricacion_ObtieneBitacoraCambiosSolicitados]", listaParametros)
    End Function

    Public Sub AutorizarPlanFabricacion(ByVal vXmlCeldasModificadas As String, ByVal accion As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@vXmlCeldasModificadas", vXmlCeldasModificadas)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Accion", accion)
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Programacion].[SP_PlanFabricacion_AutorizaPlan]", listaParametros)
    End Sub

    Public Function GenerarAlertaDesdeMDIParent(ByVal UsuarioID As Integer, ByVal SemanaActual As Integer, ByVal AñoActual As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@UsuarioID", UsuarioID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@SemanaActual", SemanaActual)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@AñoActual", AñoActual)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_PlanFabricacion_ObtieneAlertaMDI]", listaParametros)

    End Function

    Public Function LaNaveTieneSAY(ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_PlanFabricacion_LaNaveTieneSAY]", listaParametros)
    End Function

    Public Function ObtienePlaneadorPorNave() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_PlanFabricacion_ObtienePlaneadorPorGrupo]", listaParametros)
    End Function

    Public Function ObtienePlaneadoresPorGrupo(ByVal Accion As Integer, ByVal PlaneadorID As Integer, ByVal Grupo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Accion", Accion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@PlaneadorID", PlaneadorID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Grupo", Grupo)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_PlanFabricacion_Edicion_ObtienePlaneadorPorGrupo]", listaParametros)
    End Function

    Public Function ObtieneTablaTemporal_CambioFechaProgramacion(ByVal FCliente As String, ByVal FPedidoSAY As String, ByVal FEstatus As String, ByVal MostrarClientesNOViables As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FCliente", FCliente)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FPedidoSAY", FPedidoSAY)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FEstatus", FEstatus)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@MostrarClientesNOViables", MostrarClientesNOViables)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_PlanFabricacion_Temporal_ObtieneInfoCambioFecha]", listaParametros)

    End Function

    Public Function ObtienePendientesPorAutorizar_FechaProgramacion(ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_PlanFabricacion_ObtienePendientes_CambiosFechaProgramacion]", listaParametros)

    End Function

    Public Function CambiaEstatus_FechaProgramacion_PPCP(ByVal VxmlCeldas As String, ByVal Accion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@MovimientosID", VxmlCeldas)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Accion", Accion)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_PlanFabricacion_AutorizaRechaza_FechaProgramacion]", listaParametros)
    End Function

    Public Function ObtenerSemanaMovimientoPares(ByVal TmpID As Integer, ByVal FechaEntregaBuscar As Date, ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@TmpID", TmpID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaEntregaBuscar", FechaEntregaBuscar)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_PlanFabricacion_ObtenerOcupacionSemanal_MovimientoPares]", listaParametros)

    End Function

    Public Function MovimientoPares_FechaEntregaProgramacion(ByVal vXmlCeldasFechaProgramacion As String, ByVal vXmlCeldasDetalles As String, ByVal UsuarioID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@vXmlCeldasFechaProgramacion", vXmlCeldasFechaProgramacion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@vXmlCeldasDetalles", vXmlCeldasDetalles)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioID", UsuarioID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_PlanFabricacion_MovimientoParesTmpFechaProgramacion]", listaParametros)
    End Function

    Public Function ObtieneInformacionDetallesMapaOcupacion(ByVal FNave As String, ByVal FCliente As String, ByVal FPedidoSAY As String,
                                                            ByVal FPedidoSICY As String, ByVal FMarca As String, ByVal FColeccion As String,
                                                            ByVal FPiel As String, ByVal FColor As String, ByVal FCorrida As String,
                                                            ByVal FFamiliaV As String, ByVal FTemporada As String,
                                                             ByVal FiltroFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FNave", FNave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FCliente", FCliente)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FPedidoSAY", FPedidoSAY)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FPedidoSICY", FPedidoSICY)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FMarca", FMarca)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FColeccion", FColeccion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FPiel", FPiel)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FColor", FColor)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FCorrida", FCorrida)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FFamiliaV", FFamiliaV)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FTemporada", FTemporada)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FiltroFecha", FiltroFecha)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaInicio", FechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", FechaFin)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MapaOcupacion_ObtieneDetallesOcupacion_Filtros]", listaParametros)
    End Function


End Class
