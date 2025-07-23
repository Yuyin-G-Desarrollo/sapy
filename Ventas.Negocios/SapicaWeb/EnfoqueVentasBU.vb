Public Class EnfoqueVentasBU
    ''consulta del listado de enfoques
    Public Function listadoEnfoqueVentas(ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.EnfoqueVentasDA
        Dim dtEnfoques As New DataTable

        dtEnfoques = objDa.listadoEnfoqueVentas(idUsuario)

        Return dtEnfoques
    End Function

    ''consulta de permisos para el enfoque de ventas
    Public Function permisosEnfoqueVentas(ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.EnfoqueVentasDA
        Dim dtPermiso As New DataTable

        dtPermiso = objDa.permisosEnfoqueVentas(idUsuario)

        Return dtPermiso
    End Function

    ''consulta del enfoque de colecciones a exportar a excel
    Public Function consultaExportarEnfoqueColecciones(ByVal idEvento As Int32) As DataTable
        Dim dtColecciones As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtColecciones = objDa.consultaExportarEnfoqueColecciones(idEvento)
        Return dtColecciones
    End Function

    ''consulta para inserta el encabezado del enfoque
    Public Function insertaEncabezadoEnfoque(ByVal clave As String, ByVal descripcion As String, ByVal version As String,
                                             ByVal fechaInicio As String, ByVal fechaFin As String, ByVal idUsuario As Int32) As DataTable
        Dim dtEnfoque As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtEnfoque = objDa.insertaEncabezadoEnfoque(clave, descripcion, version, fechaInicio, fechaFin, idUsuario)
        Return dtEnfoque
    End Function

    ''consulta para insertar la prioridad por coleccion
    Public Function insertaPrioridadPorColeccion(ByVal idEnfoque As Int32, ByVal prioridad As String, ByVal idMarca As Int32,
                                                 ByVal idColeccion As Int32, ByVal potencial As String, ByVal imagenxArticulo As Int32,
                                                 ByVal idUsuario As Int32, ByVal idPrioridadColeccion As Int32) As DataTable

        Dim dtPrioridadCol As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtPrioridadCol = objDa.insertaPrioridadPorColeccion(idEnfoque, prioridad, idMarca, idColeccion, potencial, imagenxArticulo, idUsuario, idPrioridadColeccion)
        Return dtPrioridadCol
    End Function

    ''consulta con los permisos para exportar prioridad por modelo
    Public Function permisoExportarPrioridadPorModelo(ByVal idEnfoque As Int32) As DataTable
        Dim dtPermiso As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtPermiso = objDa.permisoExportarPrioridadPorModelo(idEnfoque)
        Return dtPermiso
    End Function

    ''consulta para exportar archivo de modelos piel color
    Public Function exportarEnfoqueModeloPielColor(ByVal idEvento As Int32) As DataTable
        Dim dtModeloPielColor As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtModeloPielColor = objDa.exportarEnfoqueModeloPielColor(idEvento)
        Return dtModeloPielColor
    End Function

    ''consulta para insertar prioridad por modelo
    Public Function insertaPrioridadModelo(ByVal idProducto As Int32, ByVal prioridadModelo As String, ByVal correspondeEV As Int32,
                                          ByVal idPrioridadModelo As Int32, ByVal idEnfoque As Int32, ByVal idUsuario As Int32) As DataTable

        Dim dtMensaje As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtMensaje = objDa.insertaPrioridadModelo(idProducto, prioridadModelo, correspondeEV, idPrioridadModelo, idEnfoque, idUsuario)
        Return dtMensaje
    End Function

    ''consulta para insertar prioridad por modelo piel color
    Public Function insertaPrioridadModeloPielColor(ByVal idProducto As Int32, ByVal colorid As Int32, ByVal pielId As Int32,
                                                ByVal prioridadPielColor As String, ByVal idPrioridadModeloPielColor As Int32,
                                                ByVal idEnfoque As Int32, ByVal idUsuario As Int32) As DataTable

        Dim dtMensaje As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtMensaje = objDa.insertaPrioridadModeloPielColor(idProducto, colorid, pielId, prioridadPielColor, idPrioridadModeloPielColor, idEnfoque, idUsuario)
        Return dtMensaje
    End Function

    ''consulta de quien importo el archivo modelos piel color
    Public Function consultaQuienImportoModelos(ByVal idEnfoque As Int32) As DataTable
        Dim dtImporto As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtImporto = objDa.consultaQuienImportoModelos(idEnfoque)
        Return dtImporto
    End Function

    ''consulta de impresion enfoque de ventas
    Public Function consultaImpresionEnfoqueVentas(ByVal EnfoqueVentasID As Int32, ByVal ColeccionesNuevas As Int32, ByVal ColeccionesVigentes As Int32,
                                                   ByVal ModelosEV_SI As Int32, ByVal ModelosEV_NO As Int32, ByVal ModelosColeccionesPielColorNoAutorizados_SI As Int32,
                                                   ByVal ModelosColeccionesPielColorNoAutorizados_NO As Int32, ByVal idMarca As Int32) As DataTable
        Dim dtEnfoqueVentas As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtEnfoqueVentas = objDa.consultaImpresionEnfoqueVentas(EnfoqueVentasID, ColeccionesNuevas, ColeccionesVigentes, ModelosEV_SI, ModelosEV_NO,
                                                               ModelosColeccionesPielColorNoAutorizados_SI, ModelosColeccionesPielColorNoAutorizados_NO,
                                                               idMarca)
        Return dtEnfoqueVentas
    End Function

    ''consulta encabezado enfoque pdf
    Public Function consultaEncabezadoEnfoquePDF(ByVal idEnfoque As Int32) As DataTable
        Dim dtEncabezadoPDF As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtEncabezadoPDF = objDa.consultaEncabezadoEnfoquePDF(idEnfoque)

        Return dtEncabezadoPDF
    End Function

    ''consulta del listado de rutas
    Public Function consultaListadoRutas() As DataTable
        Dim dtRutas As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtRutas = objDa.consultaListadoRutas()

        Return dtRutas
    End Function


    ''consulta con el listado de enfoques para combo estadistico
    Public Function comboListadoEnfoques() As DataTable
        Dim dtEnfoques As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtEnfoques = objDa.comboListadoEnfoques()

        Return dtEnfoques
    End Function

    ''consulta del enfoque activo
    Public Function consultaEnfoqueActivo() As DataTable
        Dim dtEnfoquesActivo As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtEnfoquesActivo = objDa.consultaEnfoqueActivo()

        Return dtEnfoquesActivo
    End Function

    ''consulta del evento relacionado al enfoque
    Public Function consultaEventoRelacionadoEnfoque(ByVal idEnfoque As Int32) As DataTable
        Dim dtEventoEnfoque As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtEventoEnfoque = objDa.consultaEventoRelacionadoEnfoque(idEnfoque)

        Return dtEventoEnfoque
    End Function

    ''consulta medicion general por coleccion
    Public Function consultaMedicionGeneralColeccion(ByVal EnfoqueVentasID As Int32, ByVal EventoID As Int32, ByVal coleccionesNuevas As Int32,
                                                     ByVal coleccionesVigentes As Int32, ByVal vendedor As String, ByVal ruta As String,
                                                     ByVal marca As String, ByVal fechaCaptura As Int32, ByVal fechaCapturaInicio As String,
                                                     ByVal FechaCapturaFin As String, ByVal fechaProgramacion As Int32, ByVal fechaProgramacionInicio As String,
                                                     ByVal fechaProgramacionFin As String) As DataTable

        Dim dtMGColeccion As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtMGColeccion = objDa.consultaMedicionGeneralColeccion(EnfoqueVentasID, EventoID, coleccionesNuevas, coleccionesVigentes, vendedor,
                                                               ruta, marca, fechaCaptura, fechaCapturaInicio, FechaCapturaFin, fechaProgramacion,
                                                               fechaProgramacionInicio, fechaProgramacionFin)

        Return dtMGColeccion
    End Function

    ''consulta medicion general por corresponde
    Public Function consultaMedicionGeneralCorresponde(ByVal EnfoqueVentasID As Int32, ByVal EventoID As Int32, ByVal coleccionesNuevas As Int32,
                                                 ByVal coleccionesVigentes As Int32, ByVal vendedor As String, ByVal ruta As String,
                                                 ByVal marca As String, ByVal fechaCaptura As Int32, ByVal fechaCapturaInicio As String,
                                                 ByVal FechaCapturaFin As String, ByVal fechaProgramacion As Int32, ByVal fechaProgramacionInicio As String,
                                                 ByVal fechaProgramacionFin As String) As DataTable

        Dim dtMGCorresponde As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtMGCorresponde = objDa.consultaMedicionGeneralCorresponde(EnfoqueVentasID, EventoID, coleccionesNuevas, coleccionesVigentes, vendedor,
                                                               ruta, marca, fechaCaptura, fechaCapturaInicio, FechaCapturaFin, fechaProgramacion,
                                                               fechaProgramacionInicio, fechaProgramacionFin)

        Return dtMGCorresponde
    End Function

    ''consulta medicion por marca
    Public Function consultaMedicionPorMarca(ByVal EnfoqueVentasID As Int32, ByVal EventoID As Int32, ByVal coleccionesNuevas As Int32,
                                             ByVal coleccionesVigentes As Int32, ByVal vendedor As String, ByVal ruta As String,
                                             ByVal marca As String, ByVal fechaCaptura As Int32, ByVal fechaCapturaInicio As String,
                                             ByVal FechaCapturaFin As String, ByVal fechaProgramacion As Int32, ByVal fechaProgramacionInicio As String,
                                             ByVal fechaProgramacionFin As String) As DataTable

        Dim dtMGPorMarca As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtMGPorMarca = objDa.consultaMedicionPorMarca(EnfoqueVentasID, EventoID, coleccionesNuevas, coleccionesVigentes, vendedor,
                                                               ruta, marca, fechaCaptura, fechaCapturaInicio, FechaCapturaFin, fechaProgramacion,
                                                               fechaProgramacionInicio, fechaProgramacionFin)

        Return dtMGPorMarca
    End Function

    ''consulta del enfoque de ventas seleccionado
    Public Function consultaDatosEnfoqueVentas(ByVal idEnfoque As Int32) As DataTable
        Dim dtEnfoque As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtEnfoque = objDa.consultaDatosEnfoqueVentas(idEnfoque)

        Return dtEnfoque
    End Function

    'consulta de las corridas de un producto
    Public Function consultaCorridasProducto(ByVal idProducto As Int32) As DataTable
        Dim dtCorridas As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtCorridas = objDa.consultaCorridasProducto(idProducto)

        Return dtCorridas
    End Function

    ''consulta del permiso estadistica de ventas
    Public Function permisoEstadisticaEnfoqueVentas(ByVal idUsuario As Int32) As DataTable
        Dim dtPermiso As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtPermiso = objDa.permisoEstadisticaEnfoqueVentas(idUsuario)

        Return dtPermiso
    End Function

    ''consulta del permiso activar enfoque de ventas
    Public Function permisoActivarEnfoqueVentas(ByVal idUsuario As Int32, ByVal idEnfoque As Int32) As DataTable
        Dim dtActivar As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtActivar = objDa.permisoActivarEnfoqueVentas(idUsuario, idEnfoque)

        Return dtActivar
    End Function

    ''consulta del permiso editar enfoque de ventas
    Public Function permisoEditarEnfoqueVentas(ByVal idUsuario As Int32, ByVal idEnfoque As Int32) As DataTable
        Dim dtEditar As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtEditar = objDa.permisoEditarEnfoqueVentas(idUsuario, idEnfoque)

        Return dtEditar
    End Function

    ''consulta del permiso guardar enfoque de ventas
    Public Function permisoGuardarEnfoqueVentas(ByVal idUsuario As Int32, ByVal idEnfoque As Int32) As DataTable
        Dim dtGuardar As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtGuardar = objDa.permisoGuardarEnfoqueVentas(idUsuario, idEnfoque)

        Return dtGuardar
    End Function

    ''editar encabezado del enfoque de ventas
    Public Function editarEncabezadoEnfoqueVentas(ByVal clave As String, ByVal descripcion As String, ByVal version As String,
                                                  ByVal inicio As String, ByVal fin As String, ByVal idUsuario As Int32,
                                                  ByVal idEnfoque As Int32) As DataTable
        Dim dtEditar As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtEditar = objDa.editarEncabezadoEnfoqueVentas(clave, descripcion, version, inicio, fin, idUsuario, idEnfoque)

        Return dtEditar
    End Function

    ''conuslta del mensaje de confirmacion al activar un enfoque
    Public Function consultaMensajeConfirmacionAlActivarEV(ByVal idEnfoque As Int32) As DataTable
        Dim dtMensaje As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtMensaje = objDa.consultaMensajeConfirmacionAlActivarEV(idEnfoque)

        Return dtMensaje
    End Function

    ''consulta para activar enfoque de ventas
    Public Function activarEnfoqueVentas(ByVal idEnfoque As Int32, ByVal idUsuario As Int32, ByVal claveNueva As String) As DataTable
        Dim dtActivar As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtActivar = objDa.activarEnfoqueVentas(idEnfoque, idUsuario, claveNueva)

        Return dtActivar
    End Function

    ''consulta para generar copia de la nueva version del enfoque
    Public Function generarCopiaEVNuevaVersion(ByVal idEnfoque As Int32, ByVal versionNueva As String, ByVal claveNueva As String,
                                               ByVal idUsuario As Int32) As DataTable
        Dim dtCopia As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtCopia = objDa.generarCopiaEVNuevaVersion(idEnfoque, versionNueva, claveNueva, idUsuario)

        Return dtCopia
    End Function

    ''consulta para validar si cambio la prioridad marca coleccion
    Public Function ActualizaValidaCambioPrioridadMarcaColeccion(ByVal idEnfoque As Int32, ByVal prioridad As String,
                                                                 ByVal idMarca As Int32, ByVal idColeccion As Int32,
                                                                 ByVal potencial As String, ByVal imagenPorArticulo As Int32,
                                                                 ByVal idUsuario As Int32) As DataTable
        Dim dtValida As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtValida = objDa.ActualizaValidaCambioPrioridadMarcaColeccion(idEnfoque, prioridad, idMarca, idColeccion, potencial,
                                                                      imagenPorArticulo, idUsuario)

        Return dtValida

    End Function

    ''consulta para eliminar el enfoque por modelo cuando cambia la prioridad por coleccion
    Public Function eliminarPrioridadPorModelo(ByVal idEnfoque As Int32, ByVal idEnfoqueAnterior As Int32, ByVal cambio As Int32) As DataTable
        Dim dtValida As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtValida = objDa.eliminarPrioridadPorModelo(idEnfoque, idEnfoqueAnterior, cambio)

        Return dtValida
    End Function

    ''consulta del permiso para inactivar el enfoque de ventas
    Public Function permisoInactivarEnfoqueVentas(ByVal idUsuario As Int32, ByVal idEnfoque As Int32) As DataTable
        Dim dtPermiso As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtPermiso = objDa.permisoInactivarEnfoqueVentas(idUsuario, idEnfoque)

        Return dtPermiso
    End Function

    ''consulta para inactivar enfoque de ventas
    Public Function inactivarEnfoqueVentas(ByVal idUsuario As Int32, ByVal idEnfoque As Int32) As DataTable
        Dim dtInactivar As New DataTable
        Dim objDa As New Datos.EnfoqueVentasDA

        dtInactivar = objDa.inactivarEnfoqueVentas(idUsuario, idEnfoque)

        Return dtInactivar
    End Function
#Region "cargar marcas"
    Public Function verListaMarcasSicy() As DataTable
        Dim objVentSicyDA As New Datos.EnfoqueVentasDA
        Return objVentSicyDA.verListaMarcasSicy
    End Function
#End Region
End Class
