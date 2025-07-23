Imports System.Data.SqlClient

Public Class ResumenVentasSemanalDA
    Dim objPeristenciaSICY As Persistencia.OperacionesProcedimientosSICY
    Dim objPeristenciaSAY As Persistencia.OperacionesProcedimientos

    Public Function ReporteGeneralVentasClasificacionCliente(ByVal Reporte As Int16, ByVal UsuarioId As Integer, ByVal FechaInicio As String,
                                                    ByVal FechaFin As String, ByVal Cliente As String, ByVal Agente As String,
                                                    ByVal Marca As String, ByVal Familia As String, ByVal Coleccion As String,
                                                    ByVal AñoComparacion1 As Integer, ByVal AñoComparacion2 As Integer) As DataTable
        objPeristenciaSICY = New Persistencia.OperacionesProcedimientosSICY
        Dim dt As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@UsuarioIdSay"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFin"
            parametro.Value = FechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClientesIDSay"
            parametro.Value = Cliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AgentesIDSay"
            parametro.Value = Agente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MarcasIDSay"
            parametro.Value = Marca
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FamiliasProyeccionIDSay"
            parametro.Value = Familia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionMarcaIDSay"
            parametro.Value = Coleccion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoComparacion1"
            parametro.Value = AñoComparacion1
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoComparacion2"
            parametro.Value = AñoComparacion2
            listaParametros.Add(parametro)

            dt = objPeristenciaSICY.EjecutarConsultaSP("[Ventas].[SP_ReporteVentas_ReporteGeneralVentasSemanal_ClasificacionCliente]", listaParametros)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteGeneralVentasClasificacion(ByVal Reporte As Int16, ByVal UsuarioId As Integer, ByVal FechaInicio As String,
                                                    ByVal FechaFin As String, ByVal Cliente As String, ByVal Agente As String,
                                                    ByVal Marca As String, ByVal Familia As String, ByVal Coleccion As String,
                                                    ByVal AñoComparacion1 As Integer, ByVal AñoComparacion2 As Integer) As DataTable
        objPeristenciaSICY = New Persistencia.OperacionesProcedimientosSICY
        Dim dt As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@UsuarioIdSay"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFin"
            parametro.Value = FechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClientesIDSay"
            parametro.Value = Cliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AgentesIDSay"
            parametro.Value = Agente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MarcasIDSay"
            parametro.Value = Marca
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FamiliasProyeccionIDSay"
            parametro.Value = Familia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionMarcaIDSay"
            parametro.Value = Coleccion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoComparacion1"
            parametro.Value = AñoComparacion1
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoComparacion2"
            parametro.Value = AñoComparacion2
            listaParametros.Add(parametro)

            dt = objPeristenciaSICY.EjecutarConsultaSP("[Ventas].[SP_ReporteVentas_ReporteGeneralVentasSemanal_Clasificacion]", listaParametros)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteGeneralVentasAgente(ByVal Reporte As Int16, ByVal UsuarioId As Integer, ByVal FechaInicio As String,
                                                    ByVal FechaFin As String, ByVal Cliente As String, ByVal Agente As String,
                                                    ByVal Marca As String, ByVal Familia As String, ByVal Coleccion As String,
                                                    ByVal AñoComparacion1 As Integer, ByVal AñoComparacion2 As Integer) As DataTable
        objPeristenciaSICY = New Persistencia.OperacionesProcedimientosSICY
        Dim dt As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@UsuarioIdSay"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFin"
            parametro.Value = FechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClientesIDSay"
            parametro.Value = Cliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AgentesIDSay"
            parametro.Value = Agente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MarcasIDSay"
            parametro.Value = Marca
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FamiliasProyeccionIDSay"
            parametro.Value = Familia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionMarcaIDSay"
            parametro.Value = Coleccion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoComparacion1"
            parametro.Value = AñoComparacion1
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoComparacion2"
            parametro.Value = AñoComparacion2
            listaParametros.Add(parametro)

            dt = objPeristenciaSICY.EjecutarConsultaSP("[Ventas].[SP_ReporteVentas_ReporteGeneralVentasSemanal_Agente]", listaParametros)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteGeneralVentasFrecuenciaPedidosAgente(ByVal Reporte As Int16, ByVal UsuarioId As Integer, ByVal FechaInicio As String,
                                                    ByVal FechaFin As String, ByVal Cliente As String, ByVal Agente As String,
                                                    ByVal Marca As String, ByVal Familia As String, ByVal Coleccion As String,
                                                    ByVal AñoComparacion1 As Integer, ByVal AñoComparacion2 As Integer) As DataTable
        objPeristenciaSICY = New Persistencia.OperacionesProcedimientosSICY
        Dim dt As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@UsuarioIdSay"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFin"
            parametro.Value = FechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClientesIDSay"
            parametro.Value = Cliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AgentesIDSay"
            parametro.Value = Agente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MarcasIDSay"
            parametro.Value = Marca
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FamiliasProyeccionIDSay"
            parametro.Value = Familia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionMarcaIDSay"
            parametro.Value = Coleccion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoComparacion1"
            parametro.Value = AñoComparacion1
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoComparacion2"
            parametro.Value = AñoComparacion2
            listaParametros.Add(parametro)

            dt = objPeristenciaSICY.EjecutarConsultaSP("[Ventas].[SP_ReporteVentas_ReporteGeneralVentasSemanal_FrecuenciaPedidosPorAgente]", listaParametros)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ReporteGeneralVentasFrecuenciaPedidosAgente_GrupoMarcas(ByVal Reporte As Int16, ByVal UsuarioId As Integer, ByVal FechaInicio As String,
                                                    ByVal FechaFin As String, ByVal Cliente As String, ByVal Agente As String,
                                                    ByVal Marca As String, ByVal Familia As String, ByVal Coleccion As String,
                                                    ByVal AñoComparacion1 As Integer, ByVal AñoComparacion2 As Integer) As DataTable
        objPeristenciaSICY = New Persistencia.OperacionesProcedimientosSICY
        Dim dt As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@UsuarioIdSay"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFin"
            parametro.Value = FechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClientesIDSay"
            parametro.Value = Cliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AgentesIDSay"
            parametro.Value = Agente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MarcasIDSay"
            parametro.Value = Marca
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FamiliasProyeccionIDSay"
            parametro.Value = Familia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColeccionMarcaIDSay"
            parametro.Value = Coleccion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoComparacion1"
            parametro.Value = AñoComparacion1
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoComparacion2"
            parametro.Value = AñoComparacion2
            listaParametros.Add(parametro)

            dt = objPeristenciaSICY.EjecutarConsultaSP("[Ventas].[SP_ReporteVentas_ReporteGeneralVentasSemanal_FrecuenciaPedidosPorAgente_GrupoMarcas]", listaParametros)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteGeneralVentas_Encabezados(spid As Integer)
        Dim dt As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        objPeristenciaSICY = New Persistencia.OperacionesProcedimientosSICY
        Dim parametro As SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@spid"
            parametro.Value = spid
            listaParametros.Add(parametro)

            dt = objPeristenciaSICY.EjecutarConsultaSP("[Ventas].[SP_ReporteVentas_ReporteGeneralVentasSemanal_Encabezado]", listaParametros)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub ReporteGeneralVentas_LimpiarEncabezados(ByVal spid As Integer)
        Dim listaParametros As New List(Of SqlParameter)
        objPeristenciaSICY = New Persistencia.OperacionesProcedimientosSICY
        Dim parametro As SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@spid"
            parametro.Value = spid
            listaParametros.Add(parametro)

            objPeristenciaSICY.EjecutarConsultaSP("[Ventas].[SP_ReporteVentas_ReporteGeneralVentasSemanal_EliminarEncabezado]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub bitacoraExportacionExcel(ByVal UsuarioId As Integer, ByVal Exportado_A As String, ByVal Aplicacion As String, ByVal TipoReporte As String, ByVal FechaInicio As String, ByVal FechaFin As String)
        objPeristenciaSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "usuarioid"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "exportado_a"
            parametro.Value = Exportado_A
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "aplicacion"
            parametro.Value = Aplicacion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "tiporeporte"
            parametro.Value = TipoReporte
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "fechainicio"
            parametro.Value = FechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "fechafin"
            parametro.Value = FechaFin
            listaParametros.Add(parametro)

            objPeristenciaSAY.EjecutarConsultaSP("Framework.SP_framework_CreacionBitacoraExportacionArchivo", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function consultaPerfilUsuario(ByVal usuarioId As Integer) As DataTable
        objPeristenciaSAY = New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@usuarioId"
            parametro.Value = usuarioId
            listaParametros.Add(parametro)

            dtResultadoConsulta = objPeristenciaSAY.EjecutarConsultaSP("Ventas.SP_Perfil_Usuario_Tablero", listaParametros)

            Return dtResultadoConsulta
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultarFechaFinEstadVentas_Semanal() As DataTable
        objPeristenciaSICY = New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim dtResultado As New DataTable

        Try
            dtResultado = objPeristenciaSICY.EjecutarConsultaSP("Ventas.ConsultarFechaFinEstadVentas_Semanal", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

        Return dtResultado
    End Function

    Public Function ConsultarFechaInicioEstadVentas_Semanal() As DataTable
        objPeristenciaSICY = New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim dtResultado As New DataTable

        Try
            dtResultado = objPeristenciaSICY.EjecutarConsultaSP("Ventas.ConsultarFechaInicioEstadVentas_Semanal", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

        Return dtResultado
    End Function

End Class
