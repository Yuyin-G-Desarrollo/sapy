Public Class DevolucionClientesBU
    Public datos As New Datos.DevolucionClientes

    Public Function ListaMotivosDevolucion(ByVal activo As Boolean, ByVal tipoMotivo As String, ByVal nombreMotivo As String, ByVal descripcion As String) As DataTable
        Dim objListaDevolucionesDA As New Datos.DevolucionClientes
        Dim tablas As New DataTable
        ListaMotivosDevolucion = objListaDevolucionesDA.ListaMotivosDevolucion(activo, tipoMotivo, nombreMotivo, descripcion)
        Return ListaMotivosDevolucion
    End Function

    Public Function ListadoMotivos(ByVal tipoMotivo As String) As DataTable
        Dim objListaDevolucionesDA As New Datos.DevolucionClientes
        ListadoMotivos = objListaDevolucionesDA.ListarMotivosDevolucion(tipoMotivo)
        Return ListadoMotivos
    End Function

    Public Function ListadoEstatus() As DataTable
        Dim objListaDevolucionesDA As New Datos.DevolucionClientes
        ListadoEstatus = objListaDevolucionesDA.ConsultarEstatus()
        Return ListadoEstatus
    End Function

    Public Function ListadoUnidadesMedida() As DataTable
        Dim objListaUnidadesDA As New Datos.DevolucionClientes
        Dim tablas As New DataTable
        ListadoUnidadesMedida = objListaUnidadesDA.ConsultarListaUnidadesMedida()
        Return ListadoUnidadesMedida
    End Function

    Public Function ListaGenerica(nombre As String, Optional ByVal CEDIS As Integer = 0) As DataTable
        Dim objListaDevolucionesDA As New Datos.DevolucionClientes
        ListaGenerica = objListaDevolucionesDA.ConsultarLista(nombre, CEDIS)
        Return ListaGenerica
    End Function

    Public Function GetAtnClientes(idCliente As Int32) As String
        Dim objDevolucionesDA As New Datos.DevolucionClientes
        Dim tabla As New DataTable
        tabla = objDevolucionesDA.ConsultarAtnClientes(idCliente)
        GetAtnClientes = (tabla.Rows(0))(0)
        Return GetAtnClientes
    End Function
    Public Function ObtenerAgente(idCliente As Int32) As String
        Dim objDevolucionesDA As New Datos.DevolucionClientes
        Dim tabla As New DataTable
        tabla = objDevolucionesDA.ConsultarAgentes(idCliente)
        ObtenerAgente = (tabla.Rows(0))(0)
        Return ObtenerAgente
    End Function

    Public Function ListaPedidosCliente(ByVal idCliente As Int32,
                                          ByVal fechaInicio As Date,
                                          ByVal fechaFin As Date) As DataTable
        Dim objDevolucionesDA As New Datos.DevolucionClientes
        ListaPedidosCliente = objDevolucionesDA.ConsultarPedidosCliente(idCliente, fechaInicio, fechaFin)
        Return ListaPedidosCliente
    End Function

    Public Function ListaDocumentos(ByVal IdDocumento As String, ByVal Anio As Int16, ByVal FacturaRemision As String, ByVal idCliente As Int32, ByVal fechaInicio As Date, ByVal fechaFin As Date,
                                    ByVal Modelo As String, ByVal Articulo As String, ByVal pedidos As String) As DataTable
        Dim objDevolcuiones As New Datos.DevolucionClientes
        ListaDocumentos = objDevolcuiones.ConsultarDocumentosCliente(IdDocumento, Anio, FacturaRemision, idCliente, fechaInicio, fechaFin, Modelo, Articulo, pedidos)
        Return ListaDocumentos
    End Function
    Public Sub RegistrarMotivo(ByVal tipoMotivo As String, ByVal nombreMotivo As String, ByVal descripcion As String, ByVal activo As Boolean)
        Dim objDevolucionesDA As New Datos.DevolucionClientes
        objDevolucionesDA.RegistrarMotivo(tipoMotivo, nombreMotivo, descripcion, activo)
    End Sub

    Public Sub EditarMotivo(ByVal idMotivo As Int32, ByVal tipoMotivo As String, ByVal nombreMotivo As String, ByVal descripcion As String, ByVal activo As Boolean)
        Dim objDevolucionesDA As New Datos.DevolucionClientes
        objDevolucionesDA.EditarMotivo(idMotivo, tipoMotivo, nombreMotivo, descripcion, activo)
    End Sub

    Public Function ListaPedidosFacturados(ByVal filtro As String) As DataTable
        Dim objDevolcuiones As New Datos.DevolucionClientes
        ListaPedidosFacturados = objDevolcuiones.ListaPedidosFacturados(filtro)
        Return ListaPedidosFacturados
    End Function
    Public Function ListaDocumentosFacturas(ByVal filtro As String) As DataTable
        Dim objDevolcuiones As New Datos.DevolucionClientes
        ListaDocumentosFacturas = objDevolcuiones.ListaDocumentos(filtro)
        Return ListaDocumentosFacturas
    End Function
    Public Function ListaArticulos(ByVal filtro As String, ByVal numConsulta As Int16, ByVal marca As String, ByVal coleccion As String) As DataTable
        Dim objDevoluciones As New Datos.DevolucionClientes
        ListaArticulos = objDevoluciones.ConsultarArticulos(filtro, numConsulta, marca, coleccion)
        Return ListaArticulos
    End Function

    Public Function ListaArtiulos_ModeloSAY(ByVal TipoModelo As String, ByVal modelo As String, ByVal idCliente As Int16, ByVal TipoDevolucion As String)
        Dim objDA As New Datos.DevolucionClientes
        ListaArtiulos_ModeloSAY = objDA.ConsultarArtiulos_ModeloSAY(TipoModelo, modelo, idCliente, TipoDevolucion)
        Return ListaArtiulos_ModeloSAY
    End Function

    Public Function ConsultaArticuloSeleccionado(ByVal productoEstiloID As Integer, ByVal idCliente As Integer)
        Dim objDA As New Datos.DevolucionClientes
        ConsultaArticuloSeleccionado = objDA.ConsultaArticuloSeleccionado(productoEstiloID, idCliente)
        Return ConsultaArticuloSeleccionado
    End Function

    Public Function ListaTipoCodigos(ByVal idCliente As Integer) As DataTable
        Dim objDevoluciones As New Datos.DevolucionClientes
        ListaTipoCodigos = objDevoluciones.ConsultarTipoCodigos(idCliente)
        Return ListaTipoCodigos
    End Function

    Public Function ConsultaEtiquetasParYuyin(ByVal etiquetaPar As String, ByVal idClienteSay As Integer, ByVal pedidos As String) As DataTable
        Dim objDevolucionesDA As New Datos.DevolucionClientes
        ConsultaEtiquetasParYuyin = objDevolucionesDA.ConsultarEtiquetaParYuyin(etiquetaPar, idClienteSay, pedidos)
        Return ConsultaEtiquetasParYuyin
    End Function

    Public Function ConsultarEtiquetaCodEspeciales(ByVal par As String, ByVal tipoCodigo As String, ByVal codClienteSay As Integer, ByVal incrementoPorPar As Double)
        Dim objDevolucionesDA As New Datos.DevolucionClientes
        ConsultarEtiquetaCodEspeciales = objDevolucionesDA.ConsultarEtiquetaCodEspeciales(par, tipoCodigo, codClienteSay, incrementoPorPar)
        Return ConsultarEtiquetaCodEspeciales
    End Function

    Public Function ConsultarEtiquetaParFacturacion(ByVal par As String, ByVal clienteDevolucion_SAY As Integer, ByVal documentoSAY As String)
        Dim objDevolucionesDA As New Datos.DevolucionClientes
        ConsultarEtiquetaParFacturacion = objDevolucionesDA.ConsultarEtiquetaParFacturacion(par, clienteDevolucion_SAY, documentoSAY)
        Return ConsultarEtiquetaParFacturacion
    End Function

    Public Function RegistrarDevolucionCliente(ByVal objDevolucion As Entidades.DevolucionCliente) As DataTable
        RegistrarDevolucionCliente = datos.RegistrarDevolucionCliente(objDevolucion)
        Return RegistrarDevolucionCliente
    End Function

    Public Sub ModificarDevolucionCliente(ByVal objDevolucion As Entidades.DevolucionCliente, ByVal area As String)
        datos.ModificarDevolucionCliente(objDevolucion, area)
    End Sub

    Public Sub GuardarCodigos(ByVal xmlCodigos As String)
        datos.GuardarCodigos(xmlCodigos)
    End Sub
    Public Sub guardarFacturacionTodosCodigos(ByVal folio As Integer)
        datos.guardarFacturacionTodosCodigos(folio)
    End Sub
    Public Sub actualizaDetallesCodigosDevoluciones(ByVal folio As Integer)
        datos.actualizaDetallesCodigosDevoluciones(folio)
    End Sub
    Public Sub GuardarDetalles(ByVal detalles As String)
        datos.GuardarDetalles(detalles)
    End Sub

    Public Function ConsultarDevoluciones(ByVal filtros As Entidades.FiltroAdministradorDevoluciones) As DataTable
        ConsultarDevoluciones = datos.ConsultaDevoluciones(filtros)
        Return ConsultarDevoluciones
    End Function

    Public Sub EliminarCodigoDev(ByVal codigos As String, ByVal folioDev As Integer, ByVal usuario As Integer, ByVal motivoDev As Integer)

        datos.EliminarCodigoDev(codigos, folioDev, usuario, motivoDev)
    End Sub

    Public Sub EliminarDetallesDev(ByVal detalles As String)

        datos.EliminarDetallesDev(detalles)
    End Sub

    Public Function ConsultaCodigos_Devolucion(ByVal folioDev As Integer, ByVal TipoCodigo As String)

        Return datos.ConsultaCodigos_Devolucion(folioDev, TipoCodigo)
    End Function
    Public Function ConsultaDetalles_Devolucion(ByVal folioDev As Integer, ByVal FoliosDev As String) As DataTable

        Return datos.ConsultaDetalles_Devolucion(folioDev, FoliosDev)
    End Function

    Public Function ConsultaDetalles_PrecioCero(ByVal folioDev As Integer) As DataTable

        Return datos.ConsultaDetalles_PrecioCero(folioDev)
    End Function

    Public Function ConsultarParesPorTalla(ByVal DetalleID As Integer, ByVal productoEstiloID As Integer, ByVal opcion As Int16)

        Return datos.ConsultaParesPorTallas(DetalleID, productoEstiloID, opcion)
    End Function

    Public Function ActualizarTallas(ByVal FolioDev As Integer, ByVal detalleId As Integer, ByVal detallesTallas As String)

        Return datos.ActualizarTallas(FolioDev, detalleId, detallesTallas)
    End Function

    Public Sub ActualizarRutaAutorizacion(ByVal folioDev As Integer, ByVal ruta As String)

        datos.ActualizarRutaAutorizacion(folioDev, ruta)
    End Sub

    Public Sub ActualizarPrecio(ByVal Detalle As Integer, ByVal precio As Double, ByVal Usuario As Integer)

        datos.ActualizarPrecio(Detalle, precio, Usuario)
    End Sub

    Public Function ConsultaDatosFiltros(ByVal filtro As String, ByVal usuario As Integer, ByVal area As String) As DataTable

        ConsultaDatosFiltros = datos.ConsultaDatosFiltros(filtro, usuario, area)
        Return ConsultaDatosFiltros
    End Function

    Public Sub CambiarEstatusDevolucion(ByVal FolioDev As Integer, ByVal estatus As Int16, Usuario As Integer, Area As String)

        datos.CambiarEstatusDevolucion(FolioDev, estatus, Usuario, Area)
    End Sub

    Public Function ConsultaClasificacion_Detalles() As DataTable

        ConsultaClasificacion_Detalles = datos.ConsultaClasificacion_Detalles()
        Return ConsultaClasificacion_Detalles
    End Function

    Public Function ConsultaMotivos_Calidad() As DataTable

        ConsultaMotivos_Calidad = datos.ConsultaMotivos_Calidad()
        Return ConsultaMotivos_Calidad
    End Function

    Public Sub ModificarClasificacion_Detalles(ByVal clasificacion As String)

        datos.ModificarClasificacion_Detalles(clasificacion)
    End Sub

    Public Function ConsultarDocumentosSeleccionados_CG(ByVal IdDocumentos)

        Dim dtDocumentos As New DataTable
        Dim documentos As String = ""
        dtDocumentos = datos.ConsultarDocumentosSeleccionados_CG(IdDocumentos)

        For Each fila As DataRow In dtDocumentos.Rows
            If documentos.Length > 0 Then
                documentos += ","
            End If
            documentos += fila(0)
        Next
        Return documentos
    End Function

    Public Function ExistenciaPermiso(dtPermisos As DataTable, permiso As String)
        For Each row As DataRow In dtPermisos.Rows
            If row.Item("Accion") = permiso Then
                Return row.Item("TipoPermiso")
            End If
        Next
        Return False
    End Function

    Public Function ValidaPermisosPantallas(ByVal folioDev As Integer, ByVal pantalla As String, ByVal usuario As Integer)

        Dim dtPermisos As New DataTable
        Dim objPermisos As New Entidades.DevolucionCliente_PermisosPantallas
        dtPermisos = datos.ValidaPermisosPantallas(folioDev, pantalla, usuario)

        objPermisos.BtnAgregar = dtPermisos.Rows(0).Item(0)
        objPermisos.BtnEditar_formAdmin = dtPermisos.Rows(0).Item(1)
        objPermisos.BtnEditar_TodosLosClientes = dtPermisos.Rows(0).Item(2)
        objPermisos.BtnVerDetalles_formAdmin = dtPermisos.Rows(0).Item(3)
        objPermisos.BtnIntegrarProducto = dtPermisos.Rows(0).Item(4)
        objPermisos.BtnEntregaEmbarques = dtPermisos.Rows(0).Item(5)
        objPermisos.BtnRecibirEnEmbarques = dtPermisos.Rows(0).Item(7)
        objPermisos.BtnEnviosNave = dtPermisos.Rows(0).Item(6)
        objPermisos.BtnVerBitacora = dtPermisos.Rows(0).Item(8)
        objPermisos.BtnCancelarDev = dtPermisos.Rows(0).Item(9)
        objPermisos.BtnReportes = dtPermisos.Rows(0).Item(10)

        ' Componentes pantallaAgregarEditarDevolución (Sección de cabecera)
        objPermisos.BtnEditar_formAltaEdicion = dtPermisos.Rows(0).Item(11)
        objPermisos.BtnVerDetalles_formAltaEdicion = dtPermisos.Rows(0).Item(12)
        objPermisos.BtnSolicitarDocumentos = dtPermisos.Rows(0).Item(13)
        objPermisos.BtnSolicitarRevision = dtPermisos.Rows(0).Item(14)
        objPermisos.BtnSolicitarProcesamientoAlmacen = dtPermisos.Rows(0).Item(15)
        objPermisos.BtnSolictarNotaCredito = dtPermisos.Rows(0).Item(16)
        objPermisos.CmbTipoDev = dtPermisos.Rows(0).Item(17)
        objPermisos.ControlCliente = dtPermisos.Rows(0).Item(18)

        ' Componentes pantallaAgregarEditarDevolución (Panel de almacén)
        objPermisos.PnlAlmacen = dtPermisos.Rows(0).Item(19)
        objPermisos.CmbUnidad = dtPermisos.Rows(0).Item(20)
        objPermisos.CmbUbicacion = dtPermisos.Rows(0).Item(21)
        objPermisos.ControlPedidos = dtPermisos.Rows(0).Item(22)
        objPermisos.CmbMotivo_Almacen = dtPermisos.Rows(0).Item(23)
        objPermisos.BtnGuardar_pnlAlmacen = dtPermisos.Rows(0).Item(24)
        objPermisos.GrpbResolucion_pnlAlmacen = dtPermisos.Rows(0).Item(25)

        ' Componentes pantallaAgregarEditarDevolución (Panel ventas)
        objPermisos.PnlVentas = dtPermisos.Rows(0).Item(26)
        objPermisos.ControlDocumentos = dtPermisos.Rows(0).Item(27)
        objPermisos.RdbAplicaNotaCredito = dtPermisos.Rows(0).Item(28)
        objPermisos.BtnGuardar_Ventas = dtPermisos.Rows(0).Item(29)
        objPermisos.GrpbResolucion_pnlVentas = dtPermisos.Rows(0).Item(30)

        ' Componentes pantallaDetalles
        objPermisos.EdicionPrecio = dtPermisos.Rows(0).Item(31)
        objPermisos.VerMontos = dtPermisos.Rows(0).Item(32)
        objPermisos.BtnArticulosDocumentos = dtPermisos.Rows(0).Item(33)
        objPermisos.BtnEliminarDetalle = dtPermisos.Rows(0).Item(34)
        objPermisos.EdicionTallas = dtPermisos.Rows(0).Item(35)

        ' Componentes pantallaLecturaCodigos
        objPermisos.BtnIniciar = dtPermisos.Rows(0).Item(36)
        objPermisos.BtnEliminarCorrectos = dtPermisos.Rows(0).Item(37)
        objPermisos.BtnEliminarErroneos = dtPermisos.Rows(0).Item(38)
        objPermisos.BtnGuardar_codigos = dtPermisos.Rows(0).Item(39)
        objPermisos.PnlCobranza = dtPermisos.Rows(0).Item(40)

        ' Área a la que pertenece el usuario
        objPermisos.Area = dtPermisos.Rows(0).Item(41)

        Return objPermisos
    End Function

    Public Function ConsultaMonto_Cantidad(ByVal folioDev As Integer)

        Return datos.ConsultaMonto_Cantidad(folioDev)
    End Function

    Public Function SolicitarNotaCredito(ByVal folioDev As Integer, ByVal usuario As Integer)

        Return datos.SolicitarNotaCredito(folioDev, usuario)
    End Function

    Public Function ConsultaBitacora(ByVal FolioDev As Integer)

        Return datos.ConsultaBitacora(FolioDev)
    End Function

    Public Function CancelarDevolucion(ByVal FolioDev As Integer, ByVal MotivoCancelacion As Integer, ByVal Pares As Integer, ByVal observaciones As String, ByVal usuario As Integer)

        Return datos.CancelarDevolucion(FolioDev, MotivoCancelacion, Pares, observaciones, usuario)
    End Function

    Public Function ConsultaNC(ByVal FolioDevSYCI As Integer)

        Return datos.ConsultaNC(FolioDevSYCI)
    End Function

    Public Function ConsultarTotalesNotas(ByVal FolioDevSYCI As Integer)

        Return datos.ConsultarTotalesNotas(FolioDevSYCI)
    End Function

    Public Sub MoficiarMotivoDevolucionCalidad(ByVal idDetalle As Integer, ByVal idMotivo As Integer)

        Datos.MoficiarMotivoDevolucionCalidad(idDetalle, idMotivo)
    End Sub

    Public Function Consulta_Reportes_Devoluciones(ByVal xmlParametros As String, ByVal nombreSP As String)
        Return datos.Consulta_Reportes_Devoluciones(xmlParametros, nombreSP)
    End Function

    Public Function Consulta_DocumentosDetalles(ByVal FolioDev As Integer)
        Return datos.Consulta_DocumentosDetalles(FolioDev)
    End Function

    Public Function ConsultaDetallesDevolucion_Etiquetas(ByVal FolioDev As String)
        Return datos.ConsultaDetallesDevolucion_Etiquetas(FolioDev)
    End Function

    Public Sub ActualizarLote(ByVal Detalle As Integer, ByVal lote As Integer, ByVal Usuario As Integer)
        datos.ActualizarLote(Detalle, lote, Usuario)
    End Sub

    Public Function ConsultaDescuentosCliente(ByVal IdCliente As String)
        Return datos.ConsultaDescuentosCliente(IdCliente)
    End Function

    Public Function ConsultaTipoIvaCliente(ByVal IdCliente As String)
        Return datos.ConsultaTipoIvaCliente(IdCliente)
    End Function

    Public Function ConsultaUltimaPosicionCodigo(ByVal Foliodev As Integer) As DataTable
        Return datos.ConsultaUltimaPosicionCodigo(Foliodev)
    End Function

    Public Function VerificarCodigoCliente_Andrea(ByVal ClienteID As Integer, ByVal CodigoCliente As String) As DataTable
        Return datos.VerificarCodigoCliente_Andrea(ClienteID, CodigoCliente)
    End Function
End Class
