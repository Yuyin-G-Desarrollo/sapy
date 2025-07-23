Imports System.Data.SqlClient

Public Class CargaProyeccionDA

    Public Function obtenerAñosGuardados() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        dtResultadoConsulta = objPersistencia.EjecutaConsulta("exec Ventas.SP_Ventas_ReportesSay_EstadisticoPedidos_SeleccionarAñosCargaProyeccion")

        Return dtResultadoConsulta

    End Function

    Public Function obtenerSemanasPorAño(ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "año"
        parametro.Value = Año
        listaParametros.Add(parametro)


        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadisticoPedidos_SeleccionarSemanasCargaProyeccionPorAño", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function consultaDatosProyeccion(ByVal Año As Integer, ByVal SemanaDe As Integer, ByVal SemanaA As Integer, ByVal AgenteId As Integer, ByVal MarcaIdSAY As Integer, ByVal NombreAgente As String, ByVal NombreMarca As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Año"
        parametro.Value = Año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SemanaDe"
        parametro.Value = SemanaDe
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SemanaA"
        parametro.Value = SemanaA
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgenteColaboradorId"
        parametro.Value = AgenteId.ToString()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MarcaIdSAY"
        parametro.Value = MarcaIdSAY.ToString()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgenteColaboradorNombre"
        parametro.Value = NombreAgente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MarcaNombre"
        parametro.Value = NombreMarca
        listaParametros.Add(parametro)


        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadisticoPedidos_ConsultaCargaProyeccion", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function guardarEditarDatosProyeccion(ByVal DatosGuardarEditar As Entidades.DatosCargarProyeccion) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoGuardado As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Semana"
        parametro.Value = DatosGuardarEditar.semana
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Año"
        parametro.Value = DatosGuardarEditar.año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdMarcaSAY"
        parametro.Value = DatosGuardarEditar.marcaSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdColaboradorAgente"
        parametro.Value = DatosGuardarEditar.colaboradorAgenteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdClienteSAY"
        parametro.Value = DatosGuardarEditar.idClienteSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdClienteSICY"
        parametro.Value = DatosGuardarEditar.idClienteSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdRuta"
        parametro.Value = DatosGuardarEditar.idRutaSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesProyectados"
        parametro.Value = DatosGuardarEditar.paresProyectar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioGuardandoId"
        parametro.Value = DatosGuardarEditar.usuarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MarcaSICY"
        parametro.Value = DatosGuardarEditar.marcaSICY
        listaParametros.Add(parametro)


        dtResultadoGuardado = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadisticoPedidos_GuardarEditarProyeccion", listaParametros)

        Return dtResultadoGuardado

    End Function

    Public Function consultarMarcasPorAgente(ByVal IdAgente As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoGuardado As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdColaboradorAgente"
        parametro.Value = IdAgente
        listaParametros.Add(parametro)


        dtResultadoGuardado = objPersistencia.EjecutarConsultaSP("Ventas.SP_CargaProyeccion_ConsultasFiltros_MarcaPorAgente", listaParametros)

        Return dtResultadoGuardado

    End Function


    'INICIA CODIGO DE REPORTE Ventas_Reportes_CargaProyeccionForm_Marca_Familia

    Public Function consultaDatosProyeccionMarcaFamilia(ByVal Año As Integer, ByVal SemanaDe As Integer, ByVal SemanaA As Integer, ByVal AgenteId As String, ByVal MarcaIdSAY As String, ByVal FamiliaId As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Año"
        parametro.Value = Año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SemanaDe"
        parametro.Value = SemanaDe
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SemanaA"
        parametro.Value = SemanaA
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgenteColaboradorId"
        parametro.Value = AgenteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MarcaIdSAY"
        parametro.Value = MarcaIdSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FamiliaProyeccionId"
        parametro.Value = FamiliaId
        listaParametros.Add(parametro)


        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_ReporteGeneralVentas_ConsultaCargaProyeccion", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function guardarEditarDatosProyeccionFamiliaAgente(ByVal DatosGuardarEditar As Entidades.DatosCargarProyeccion) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoGuardado As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Semana"
        parametro.Value = DatosGuardarEditar.semana
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Año"
        parametro.Value = DatosGuardarEditar.año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdMarcaSAY"
        parametro.Value = DatosGuardarEditar.marcaSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdColaboradorAgente"
        parametro.Value = DatosGuardarEditar.colaboradorAgenteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdClienteSAY"
        parametro.Value = DatosGuardarEditar.idClienteSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdClienteSICY"
        parametro.Value = DatosGuardarEditar.idClienteSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdRuta"
        parametro.Value = DatosGuardarEditar.idRutaSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ParesProyectados"
        parametro.Value = DatosGuardarEditar.paresProyectar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioGuardandoId"
        parametro.Value = DatosGuardarEditar.usuarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MarcaSICY"
        parametro.Value = DatosGuardarEditar.marcaSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdFamiliaProyeccion"
        parametro.Value = DatosGuardarEditar.familiaProyeccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClasificacionId"
        parametro.Value = DatosGuardarEditar.clasificacionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClasificacionTexto"
        parametro.Value = DatosGuardarEditar.clasificacionTexto
        listaParametros.Add(parametro)


        dtResultadoGuardado = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_ReporteGeneralVentas_GuardarEditarProyeccion_Familia_Agente", listaParametros)

        Return dtResultadoGuardado

    End Function

    Public Function guardarEditarDatosProyeccionFamiliaAgenteXml(ByVal pXmlCeldas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoGuardado As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "XMLCeldas"
        parametro.Value = pXmlCeldas
        listaParametros.Add(parametro)

        dtResultadoGuardado = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_ReporteGeneralVentas_GuardarEditarProyeccionFamiliaAgente", listaParametros)

        Return dtResultadoGuardado

    End Function

    Public Sub EliminarProyeccionVenta(ByVal Año As Integer, ByVal SemanaInicio As Integer, ByVal SemanaFin As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@año"
        parametro.Value = Año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@semanaInicio"
        parametro.Value = SemanaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@semanaFin"
        parametro.Value = SemanaFin
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ProyecciónVenta_EliminarProyeccionVenta]", listaParametros)

    End Sub

    Public Sub ReplicarProyeccionVenta()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_ReportesSay_Proyeccion_ReplicarProyeccionVentas]", listaParametros)

    End Sub

    Public Function ConsultaProyeccionAnual(ByVal anio As Integer)
        Dim persistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter("@Año", anio)
        listaParametros.Add(parametro)
        Return persistencia.EjecutarConsultaSP("[Ventas].[SP_ProyeccionVentas_ConsultaInformacionProyeccion]", listaParametros)
    End Function

End Class
