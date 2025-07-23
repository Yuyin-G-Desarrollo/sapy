Imports System.Data.SqlClient

Public Class EnfoqueVentasDA
    ''consulta del listado de enfoques
    Public Function listadoEnfoqueVentas(ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_ListadoEnfoqueVentas", listaParametros)

    End Function

    ''consulta de permisos para el enfoque de ventas
    Public Function permisosEnfoqueVentas(ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_PermisosEnfoqueVentas", listaParametros)
    End Function

    ''consulta del enfoque de colecciones a exportar a excel
    Public Function consultaExportarEnfoqueColecciones(ByVal idEvento As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idEvento"
        parametro.Value = idEvento
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_ExportarEnfoqueColeccion", listaParametros)
    End Function

    ''consulta para inserta el encabezado del enfoque
    Public Function insertaEncabezadoEnfoque(ByVal clave As String, ByVal descripcion As String, ByVal version As String,
                                             ByVal fechaInicio As String, ByVal fechaFin As String, ByVal idUsuario As Int32) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "clave"
        parametro.Value = clave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descripcion"
        parametro.Value = descripcion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "version"
        parametro.Value = version
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_InsertaEncabezadoEnfoque", listaParametros)

    End Function

    ''consulta para insertar la prioridad por coleccion
    Public Function insertaPrioridadPorColeccion(ByVal idEnfoque As Int32, ByVal prioridad As String, ByVal idMarca As Int32,
                                                 ByVal idColeccion As Int32, ByVal potencial As String, ByVal imagenxArticulo As Int32,
                                                 ByVal idUsuario As Int32, ByVal idPrioridadColeccion As Int32) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idEnfoque"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prioridad"
        parametro.Value = prioridad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idMarca"
        parametro.Value = idMarca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idColeccion"
        parametro.Value = idColeccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "potencial"
        parametro.Value = potencial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "imagenxArticulo"
        parametro.Value = imagenxArticulo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPrioridadColeccion"
        parametro.Value = idPrioridadColeccion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_InsertaPrioridadColeccion", listaParametros)
    End Function

    ''consulta con los permisos para exportar prioridad por modelo
    Public Function permisoExportarPrioridadPorModelo(ByVal idEnfoque As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idEnfoque"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_ConsultaPermisoExportarModelos", listaParametros)
    End Function

    ''consulta para exportar archivo de modelos piel color
    Public Function exportarEnfoqueModeloPielColor(ByVal idEvento As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idEvento"
        parametro.Value = idEvento
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_ExportarEnfoqueModeloPielColor", listaParametros)
    End Function

    ''consulta para insertar prioridad por modelo
    Public Function insertaPrioridadModelo(ByVal idProducto As Int32, ByVal prioridadModelo As String, ByVal correspondeEV As Int32,
                                           ByVal idPrioridadModelo As Int32, ByVal idEnfoque As Int32, ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idProducto"
        parametro.Value = idProducto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prioridadModelo"
        parametro.Value = prioridadModelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "correspondeEV"
        parametro.Value = correspondeEV
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPrioridadModelo"
        parametro.Value = idPrioridadModelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idEnfoque"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)
        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_InsertaPrioridadModelo", listaParametros)
    End Function

    ''consulta para insertar prioridad por modelo piel color
    Public Function insertaPrioridadModeloPielColor(ByVal idProducto As Int32, ByVal colorid As Int32, ByVal pielId As Int32,
                                                    ByVal prioridadPielColor As String, ByVal idPrioridadModeloPielColor As Int32,
                                                    ByVal idEnfoque As Int32, ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idProducto"
        parametro.Value = idProducto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colorid"
        parametro.Value = colorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pielId"
        parametro.Value = pielId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prioridadPielColor"
        parametro.Value = prioridadPielColor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPrioridadModeloPielColor"
        parametro.Value = idPrioridadModeloPielColor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idEnfoque"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_InsertaPrioridadModeloPielColor", listaParametros)
    End Function

    ''consulta de quien importo el archivo modelos piel color
    Public Function consultaQuienImportoModelos(ByVal idEnfoque As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idEnfoque"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_ConsultaQuienImportoModelos", listaParametros)
    End Function

    ''consulta de impresion enfoque de ventas
    Public Function consultaImpresionEnfoqueVentas(ByVal EnfoqueVentasID As Int32, ByVal ColeccionesNuevas As Int32, ByVal ColeccionesVigentes As Int32,
                                                   ByVal ModelosEV_SI As Int32, ByVal ModelosEV_NO As Int32, ByVal ModelosColeccionesPielColorNoAutorizados_SI As Int32,
                                                   ByVal ModelosColeccionesPielColorNoAutorizados_NO As Int32, ByVal idMarca As Int32) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "EnfoqueVentasID"
        parametro.Value = EnfoqueVentasID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ColeccionesNuevas"
        parametro.Value = ColeccionesNuevas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ColeccionesVigentes"
        parametro.Value = ColeccionesVigentes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ModelosEV_SI"
        parametro.Value = ModelosEV_SI
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ModelosEV_NO"
        parametro.Value = ModelosEV_NO
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ModelosColeccionesPielColorNoAutorizados_SI"
        parametro.Value = ModelosColeccionesPielColorNoAutorizados_SI
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ModelosColeccionesPielColorNoAutorizados_NO"
        parametro.Value = ModelosColeccionesPielColorNoAutorizados_NO
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idMarca"
        parametro.Value = idMarca
        listaParametros.Add(parametro)
        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_Consultar_EV", listaParametros)
    End Function

    ''consulta encabezado enfoque pdf
    Public Function consultaEncabezadoEnfoquePDF(ByVal idEnfoque As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idEnfoque"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_ConsultaEncabezadoPDFEnfoque", listaParametros)
    End Function

    ''consulta del listado de rutas
    Public Function consultaListadoRutas() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "EXEC [SAPICA].[SP_EnfoqueVentas_ListadoRutas]"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta con el listado de enfoques para combo estadistico
    Public Function comboListadoEnfoques() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "EXEC [SAPICA].[SP_EnfoqueVentas_ComboListadoEnfoques]"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta del enfoque activo
    Public Function consultaEnfoqueActivo() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "EXEC [SAPICA].[SP_EnfoqueVentas_ConsultaEnfoqueActivo]"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta del evento relacionado al enfoque
    Public Function consultaEventoRelacionadoEnfoque(ByVal idEnfoque As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idEnfoque"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_ConsultaEventoEnfoque", listaParametros)
    End Function

    ''consulta medicion general por coleccion
    Public Function consultaMedicionGeneralColeccion(ByVal EnfoqueVentasID As Int32, ByVal EventoID As Int32, ByVal coleccionesNuevas As Int32,
                                                     ByVal coleccionesVigentes As Int32, ByVal vendedor As String, ByVal ruta As String,
                                                     ByVal marca As String, ByVal fechaCaptura As Int32, ByVal fechaCapturaInicio As String,
                                                     ByVal FechaCapturaFin As String, ByVal fechaProgramacion As Int32, ByVal fechaProgramacionInicio As String,
                                                     ByVal fechaProgramacionFin As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "EnfoqueVentasID"
        parametro.Value = EnfoqueVentasID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EventoID"
        parametro.Value = EventoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coleccionesNuevas"
        parametro.Value = coleccionesNuevas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coleccionesVigentes"
        parametro.Value = coleccionesVigentes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "vendedor"
        parametro.Value = vendedor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ruta"
        parametro.Value = ruta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "marca"
        parametro.Value = marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCaptura"
        parametro.Value = fechaCaptura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaInicio"
        parametro.Value = fechaCapturaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaCapturaFin"
        parametro.Value = FechaCapturaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacion"
        parametro.Value = fechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionInicio"
        parametro.Value = fechaProgramacionInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionFin"
        parametro.Value = fechaProgramacionFin
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_MedicionEV_GeneralColeccion", listaParametros)
    End Function

    ''consulta medicion general por corresponde
    Public Function consultaMedicionGeneralCorresponde(ByVal EnfoqueVentasID As Int32, ByVal EventoID As Int32, ByVal coleccionesNuevas As Int32,
                                                     ByVal coleccionesVigentes As Int32, ByVal vendedor As String, ByVal ruta As String,
                                                     ByVal marca As String, ByVal fechaCaptura As Int32, ByVal fechaCapturaInicio As String,
                                                     ByVal FechaCapturaFin As String, ByVal fechaProgramacion As Int32, ByVal fechaProgramacionInicio As String,
                                                     ByVal fechaProgramacionFin As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "EnfoqueVentasID"
        parametro.Value = EnfoqueVentasID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EventoID"
        parametro.Value = EventoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coleccionesNuevas"
        parametro.Value = coleccionesNuevas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coleccionesVigentes"
        parametro.Value = coleccionesVigentes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "vendedor"
        parametro.Value = vendedor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ruta"
        parametro.Value = ruta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "marca"
        parametro.Value = marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCaptura"
        parametro.Value = fechaCaptura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaInicio"
        parametro.Value = fechaCapturaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaCapturaFin"
        parametro.Value = FechaCapturaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacion"
        parametro.Value = fechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionInicio"
        parametro.Value = fechaProgramacionInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionFin"
        parametro.Value = fechaProgramacionFin
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_MedicionEV_GeneralCorresponde", listaParametros)
    End Function


    ''consulta medicion por marca
    Public Function consultaMedicionPorMarca(ByVal EnfoqueVentasID As Int32, ByVal EventoID As Int32, ByVal coleccionesNuevas As Int32,
                                             ByVal coleccionesVigentes As Int32, ByVal vendedor As String, ByVal ruta As String,
                                             ByVal marca As String, ByVal fechaCaptura As Int32, ByVal fechaCapturaInicio As String,
                                             ByVal FechaCapturaFin As String, ByVal fechaProgramacion As Int32, ByVal fechaProgramacionInicio As String,
                                             ByVal fechaProgramacionFin As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "EnfoqueVentasID"
        parametro.Value = EnfoqueVentasID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EventoID"
        parametro.Value = EventoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coleccionesNuevas"
        parametro.Value = coleccionesNuevas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coleccionesVigentes"
        parametro.Value = coleccionesVigentes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "vendedor"
        parametro.Value = vendedor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ruta"
        parametro.Value = ruta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "marca"
        parametro.Value = marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCaptura"
        parametro.Value = fechaCaptura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCapturaInicio"
        parametro.Value = fechaCapturaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaCapturaFin"
        parametro.Value = FechaCapturaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacion"
        parametro.Value = fechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionInicio"
        parametro.Value = fechaProgramacionInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacionFin"
        parametro.Value = fechaProgramacionFin
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_MedicionEV_CorrespondePorMarca", listaParametros)
    End Function

    ''consulta del enfoque de ventas seleccionado
    Public Function consultaDatosEnfoqueVentas(ByVal idEnfoque As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "EnfoqueVentasID"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_ConsultarDatosEV", listaParametros)
    End Function

    'consulta de las corridas de un producto
    Public Function consultaCorridasProducto(ByVal idProducto As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idProducto"
        parametro.Value = idProducto
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_CosultaCorridasProducto", listaParametros)
    End Function

    ''consulta del permiso estadistica de ventas
    Public Function permisoEstadisticaEnfoqueVentas(ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_PermisoEstadistica_EnfoqueVentas", listaParametros)
    End Function

    ''consulta del permiso activar enfoque de ventas
    Public Function permisoActivarEnfoqueVentas(ByVal idUsuario As Int32, ByVal idEnfoque As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idEnfoque"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)


        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_PermisoActivar_EnfoqueVentas", listaParametros)
    End Function

    ''consulta del permiso editar enfoque de ventas
    Public Function permisoEditarEnfoqueVentas(ByVal idUsuario As Int32, ByVal idEnfoque As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idEnfoque"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_PermisoEditar_EnfoqueVentas", listaParametros)
    End Function

    ''consulta del permiso guardar enfoque de ventas
    Public Function permisoGuardarEnfoqueVentas(ByVal idUsuario As Int32, ByVal idEnfoque As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idEnfoque"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_PermisoGuardar_EnfoqueVentas", listaParametros)
    End Function

    ''editar encabezado del enfoque de ventas
    Public Function editarEncabezadoEnfoqueVentas(ByVal clave As String, ByVal descripcion As String, ByVal version As String,
                                                  ByVal inicio As String, ByVal fin As String, ByVal idUsuario As Int32,
                                                  ByVal idEnfoque As Int32) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "clave"
        parametro.Value = clave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descripcion"
        parametro.Value = descripcion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "version"
        parametro.Value = version
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inicio"
        parametro.Value = inicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fin"
        parametro.Value = fin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idEnfoque"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_EditarEncabezadoEV", listaParametros)
    End Function

    ''conuslta del mensaje de confirmacion al activar un enfoque
    Public Function consultaMensajeConfirmacionAlActivarEV(ByVal idEnfoque As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idEnfoque"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_ConsultaMensaje_ActivarEV", listaParametros)
    End Function

    ''consulta para activar enfoque de ventas
    Public Function activarEnfoqueVentas(ByVal idEnfoque As Int32, ByVal idUsuario As Int32, ByVal claveNueva As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idEnfoque"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "claveNueva"
        parametro.Value = claveNueva
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_ActivarEV", listaParametros)
    End Function

    ''consulta para generar copia de la nueva version del enfoque
    Public Function generarCopiaEVNuevaVersion(ByVal idEnfoque As Int32, ByVal versionNueva As String, ByVal claveNueva As String,
                                               ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idEnfoque"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "versionNueva"
        parametro.Value = versionNueva
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "claveNueva"
        parametro.Value = claveNueva
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_GenerarCopia_VersionEV", listaParametros)
    End Function

    ''consulta para validar si cambio la prioridad marca coleccion
    Public Function ActualizaValidaCambioPrioridadMarcaColeccion(ByVal idEnfoque As Int32, ByVal prioridad As String,
                                                                 ByVal idMarca As Int32, ByVal idColeccion As Int32,
                                                                 ByVal potencial As String, ByVal imagenPorArticulo As Int32,
                                                                 ByVal idUsuario As Int32) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idEnfoque"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prioridad"
        parametro.Value = prioridad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idMarca"
        parametro.Value = idMarca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idColeccion"
        parametro.Value = idColeccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "potencial"
        parametro.Value = potencial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "imagenPorArticulo"
        parametro.Value = imagenPorArticulo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_ActualizarMarcaColeccion", listaParametros)
    End Function

    ''consulta para eliminar el enfoque por modelo cuando cambia la prioridad por coleccion
    Public Function eliminarPrioridadPorModelo(ByVal idEnfoque As Int32, ByVal idEnfoqueAnterior As Int32, ByVal cambio As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idEnfoque"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idEnfoqueAnterior"
        parametro.Value = idEnfoqueAnterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cambio"
        parametro.Value = cambio
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_QuitarModeloPielColor", listaParametros)

    End Function

    ''consulta del permiso para inactivar el enfoque de ventas
    Public Function permisoInactivarEnfoqueVentas(ByVal idUsuario As Int32, ByVal idEnfoque As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idEnfoque"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_PermisoInactivar_EnfoqueVentas", listaParametros)
    End Function

    ''consulta para inactivar enfoque de ventas
    Public Function inactivarEnfoqueVentas(ByVal idUsuario As Int32, ByVal idEnfoque As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idEnfoque"
        parametro.Value = idEnfoque
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_EnfoqueVentas_Inactivar_EnfoqueVentas", listaParametros)
    End Function
#Region "consulta marcas"
    Public Function verListaMarcasSicy() As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos 'Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT marc_marcaid, marc_descripcion FROM Programacion.Marcas WHERE marc_activo = 1 AND marc_activo=1 ORDER BY marc_descripcion" '"SELECT IdMarca, Marca FROM Marcas WHERE Activo='S' ORDER BY Marca"
        Return Operaciones.EjecutaConsulta(consulta)
    End Function
#End Region
End Class
