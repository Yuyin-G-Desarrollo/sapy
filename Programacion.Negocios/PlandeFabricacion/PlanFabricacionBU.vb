Imports Programacion.Datos

Public Class PlanFabricacionBU

    Public Function ObtenerNavesPorUsuario(ByVal UsuarioID As Integer) As DataTable
        Dim objDA As New PlanFabricacionDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.ObtenerNavesPorUsuario(UsuarioID)
        Return dtResultado
    End Function

    Public Function ObtienePlanFabricacionReporte(ByVal NaveID As String, ByVal Semana As String, ByVal Año As String) As DataTable
        Dim objDA As New PlanFabricacionDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.ObtienePlanFabricacionReporte(NaveID, Semana, Año)
        Return dtResultado
    End Function

    Public Function ObtenerCorreosDestinatario(ByVal pmxlCeldas As String) As DataTable
        Dim objDA As New PlanFabricacionDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.ObtenerCorreosDestinatario(pmxlCeldas)
        Return dtResultado
    End Function

    Public Function consultaCorreosEnvioFactura(ByVal ClaveEnvio As String) As DataTable
        Dim objDA As New PlanFabricacionDA
        Return objDA.consultaCorreosEnvioFactura(ClaveEnvio)
    End Function

    Public Function ObtieneEstatusPlan() As DataTable
        Dim objDA As New PlanFabricacionDA
        Return objDA.ObtieneEstatusPlan()
    End Function

    Public Function ObtienePlanFabricacion(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer, ByVal Grupo As String) As DataTable
        Dim objDA As New PlanFabricacionDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtienePlanFabricacion(NaveID, Semana, Año, Grupo)
        Return Tabla
    End Function

    Public Function ObtieneMotivosSolicitudCambio() As DataTable
        Dim objDA As New PlanFabricacionDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtieneMotivosSolicitudCambio()
        Return Tabla
    End Function

    Public Function InsertaSolicitudCambios_PlanFabricacion(ByVal pmxlModificadas As String) As DataTable
        Dim objDA As New PlanFabricacionDA
        Dim Tabla As New DataTable
        Tabla = objDA.InsertaSolicitudCambios_PlanFabricacion(pmxlModificadas)
        Return Tabla
    End Function

    Public Function ObtieneBitacoraCambios(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer, ByVal SemanaFin As Integer, AñoFin As Integer) As DataTable
        Dim objDA As New PlanFabricacionDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtieneBitacoraCambios(NaveID, Semana, Año, SemanaFin, AñoFin)
        Return Tabla
    End Function

    Public Sub AutorizarPlanFabricacion(ByVal vXmlCeldasModificadas As String, ByVal accion As Integer)
        Dim objDA As New PlanFabricacionDA
        objDA.AutorizarPlanFabricacion(vXmlCeldasModificadas, accion)
    End Sub

    Public Function GenerarAlertaDesdeMDIParent(ByVal UsuarioID As Integer, ByVal SemanaActual As Integer, ByVal AñoActual As Integer) As DataTable
        Dim objDA As New PlanFabricacionDA
        Dim Tabla As New DataTable
        Tabla = objDA.GenerarAlertaDesdeMDIParent(20, SemanaActual, AñoActual)
        Return Tabla
    End Function

    Public Function LaNaveTieneSAY(ByVal NaveID As Integer) As Boolean
        Dim objDA As New PlanFabricacionDA
        Dim tabla As New DataTable
        Dim Resultado As Integer = 0

        tabla = objDA.LaNaveTieneSAY(NaveID)

        If IsNothing(tabla) = False Then
            If tabla.Rows.Count > 0 Then
                Resultado = tabla.Rows(0).Item(0)
            End If
        End If

        If Resultado = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Function ObtienePlaneadorPorNave() As DataTable
        Dim objDA As New PlanFabricacionDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtienePlaneadorPorNave()
        Return Tabla
    End Function

    Public Function ObtienePlaneadoresPorGrupo(ByVal Accion As Integer, ByVal PlaneadorID As Integer, ByVal Grupo As String) As DataTable
        Dim objDA As New PlanFabricacionDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtienePlaneadoresPorGrupo(Accion, PlaneadorID, Grupo)
        Return Tabla
    End Function

    Public Function ObtieneTablaTemporal_CambioFechaProgramacion(ByVal FCliente As String, ByVal FPedidoSAY As String, ByVal FEstatus As String, ByVal MostrarClientesNOViables As Boolean) As DataTable
        Dim objDA As New PlanFabricacionDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtieneTablaTemporal_CambioFechaProgramacion(FCliente, FPedidoSAY, FEstatus, MostrarClientesNOViables)
        Return Tabla
    End Function

    Public Function ObtienePendientesPorAutorizar_FechaProgramacion(ByVal NaveID As Integer) As DataTable
        Dim objDA As New PlanFabricacionDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtienePendientesPorAutorizar_FechaProgramacion(NaveID)
        Return Tabla
    End Function

    Public Function CambiaEstatus_FechaProgramacion_PPCP(ByVal VxmlCeldas As String, ByVal Accion As Integer) As DataTable
        Dim objDA As New PlanFabricacionDA
        Dim Tabla As New DataTable
        Tabla = objDA.CambiaEstatus_FechaProgramacion_PPCP(VxmlCeldas, Accion)
        Return Tabla
    End Function

    Public Function ObtenerSemanaMovimientoPares(ByVal TmpID As Integer, ByVal FechaEntregaBuscar As Date, ByVal NaveID As Integer) As DataTable
        Dim objDA As New PlanFabricacionDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtenerSemanaMovimientoPares(TmpID, FechaEntregaBuscar, NaveID)
        Return Tabla
    End Function

    Public Function MovimientoPares_FechaEntregaProgramacion(ByVal vXmlCeldasFechaProgramacion As String, ByVal vXmlCeldasDetalles As String, ByVal UsuarioID As Integer) As DataTable
        Dim objDA As New PlanFabricacionDA
        Dim Tabla As New DataTable
        Tabla = objDA.MovimientoPares_FechaEntregaProgramacion(vXmlCeldasFechaProgramacion, vXmlCeldasDetalles, UsuarioID)
        Return Tabla
    End Function

    Public Function ObtieneInformacionDetallesMapaOcupacion(ByVal FNave As String, ByVal FCliente As String, ByVal FPedidoSAY As String,
                                                                                               ByVal FPedidoSICY As String, ByVal FMarca As String, ByVal FColeccion As String, ByVal FPiel As String,
                                                                                               ByVal FColor As String, ByVal FCorrida As String, ByVal FFamiliaV As String, ByVal FTemporada As String,
                                                                                               ByVal FiltroFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date)
        Dim objDA As New PlanFabricacionDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtieneInformacionDetallesMapaOcupacion(FNave, FCliente, FPedidoSAY,
                                                              FPedidoSICY, FMarca, FColeccion, FPiel, FColor, FCorrida, FFamiliaV, FTemporada,
                                                              FiltroFecha, FechaInicio, FechaFin)
        Return Tabla
    End Function

End Class
