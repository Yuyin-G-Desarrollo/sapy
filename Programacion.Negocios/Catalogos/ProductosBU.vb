Public Class ProductosBU
    Public Function actualizarEstatus(ByVal idProducto As Integer, ByVal estilo As Integer, ByVal productoestilo As Integer, ByVal estatus As Integer) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.actualizarEstatus(idProducto, estilo, productoestilo, estatus)
    End Function
    Public Function validarConsumos(ByVal idProducto As Integer) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.validarConsumos(idProducto)
    End Function

    Public Function getNaveDesarrolla(ByVal idproducto As Integer) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.getNaveDesarrolla(idproducto)
    End Function
    Public Function VerListaProductos(ByVal activo As Boolean, ByVal idcedis As Integer) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.VerListaProductos(activo, idcedis)
    End Function

    Public Function verDetallesProducto(ByVal idProducto As String) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.verDetallesProducto(idProducto)
    End Function

    Public Function validarExistenciaMarca(ByVal CodigoMarc As String) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.validarExistenciaMarca(CodigoMarc)
    End Function

    Public Function validarExistenciaFamilia(ByVal codFamilia As String) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.validarExistenciaFamilia(codFamilia)
    End Function

    Public Function validarExistenciaSubfamilia(ByVal idSubfamilia As String) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.validarExistenciaSubfamilia(idSubfamilia)
    End Function

    Public Function validarExistenciaTemporada(ByVal codTemporada As String) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.validarExistenciaTemporada(codTemporada)
    End Function

    Public Sub RegistrarProducto(ByVal EnProducto As Entidades.Productos, ByVal modelo As String, ByVal idcedis As Integer, ByVal esLicencia As Boolean, cola As String)
        Dim objPDA As New Programacion.Datos.ProductosDA
        objPDA.RegistrarProducto(EnProducto, modelo, idcedis, esLicencia, cola)
    End Sub

    Public Sub RegistrarDetalleProducto(ByVal idPiel As Int32, ByVal idFamilia As Int32, ByVal idTalla As Int32,
                                        ByVal idColor As Int32, ByVal idCorte As Int32, ByVal idForro As Int32,
                                        ByVal idSuela As Int32, ByVal codSicyP As String, ByVal activo As Boolean,
                                        ByVal idHorma As Int32, ByVal sicyMarca As String, ByVal idProducto As Int32,
                                        ByVal estatusProd As Int32, ByVal idLinea As Int32, ByVal idFamiliaVentas As Int32, idClaveSAT As String, ByVal SuelaProgramacionID As Integer, ByVal ColorSuelaID As Integer, ByVal modeloreferencia As String)

        Dim objPDA As New Programacion.Datos.ProductosDA
        objPDA.RegistrarDetallesProducto(idPiel, idFamilia, idTalla, idColor, idCorte, idForro, idSuela, codSicyP, activo, idHorma, sicyMarca, idProducto, estatusProd, idLinea, idFamiliaVentas, idClaveSAT, SuelaProgramacionID, ColorSuelaID, modeloreferencia)
    End Sub

    Public Function validarExistenciaProducto(ByVal codigoProducto As String) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.validarExistenciaProducto(codigoProducto)
    End Function

    Public Function verTallasSeleccionadasProducto(ByVal idProducto As String) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.verTallasSeleccionadasProducto(idProducto)
    End Function

    Public Function verPielesSeleccionadasProducto(ByVal idProducto As String)
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.verPielesSeleccionadasProducto(idProducto)
    End Function

    Public Function verForrosSeleccionadosProducto(ByVal idProducto As String)
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.verForrosSeleccionadosProducto(idProducto)
    End Function


    Public Function verSuelasSeleccionadasProducto(ByVal idProducto As String)
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.verSuelasSeleccionadasProducto(idProducto)
    End Function


    Public Function verCortesSeleccionadasProducto(ByVal idProducto As String)
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.verCortesSeleccionadasProducto(idProducto)
    End Function
    Public Function verDetallesProductoEditar(ByVal idProducto As String) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.verDetallesProductoEditar(idProducto)
    End Function

    Public Function buscarClaveArticuloAgregado(categoriaId As String, familiaId As String, tallaId As String, colorId As String) As String
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.buscarClaveArticuloAgregado(categoriaId, familiaId, tallaId, colorId)
    End Function
    Public Function buscarFraccionArancelariaArticuloAgregado(tallaId As String, familiaId As String, corteId As String, forroId As String, suelaId As String, categoriaId As String) As String
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.buscarFraccionArancelariaArticuloAgregado(tallaId, familiaId, corteId, forroId, suelaId, categoriaId)

    End Function
    Public Function verDatosPrincipalesProdcucto(ByVal idProducto As String, ByVal activo As String) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.verDatosPrincipalesProdcucto(idProducto, activo)
    End Function



    Public Sub EditarProducto(ByVal EnProducto As Entidades.Productos, ByVal modelo As String)
        Dim objPDA As New Programacion.Datos.ProductosDA
        ', idcedis, esLicencia
        objPDA.EditarProducto(EnProducto, modelo)

    End Sub

    Public Sub EditarDetalleProducto(ByVal idProducto As String, ByVal idPiel As String, ByVal idTalla As String, ByVal idColor As String,
                                     ByVal idCorte As String, ByVal idForro As String, ByVal idSuela As String, ByVal activo As String,
                                     ByVal codigoSicy As String, ByVal horma As String, ByVal sicyMarca As String, ByVal idFamilia As Int32,
                                      ByVal idLinea As Int32, ByVal idPrEstilo As String, ByVal estatusPres As Int32, ByVal idFamiliaVentas As Int32,
                                     idClaveSAT As String, ByVal SuelaProgramacionId As Integer, ByVal ColorSuelaID As Integer, ByVal Modeloreferencia As String)
        Dim objPDA As New Programacion.Datos.ProductosDA
        objPDA.EditarDetallesProducto(idProducto, idPiel, idTalla, idColor, idCorte, idForro, idSuela, activo, codigoSicy, horma, sicyMarca, idFamilia, idLinea, idPrEstilo, estatusPres, idFamiliaVentas, idClaveSAT, SuelaProgramacionId, ColorSuelaID, Modeloreferencia)
    End Sub

    Public Sub EditarProductoEstilo(ByVal idProducto As String)
        Dim objPDA As New Programacion.Datos.ProductosDA
        objPDA.EditarProductoEstilo(idProducto)
    End Sub

    Public Function ValidarRepetidos(ByVal Codigo As String) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        'Return objPDA.ValidarRepetidos(Codigo)
        Return objPDA.validarExistenciaProducto(Codigo)
    End Function

    Public Function verCodigoProductoRegistrado(ByVal marcaId As String, ByVal coleId As String) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.verCodigoProductoRegistrado(marcaId, coleId)
    End Function

    Public Function validaSicyEnProducto(ByVal sicy As String, ByVal idProducto As String, ByVal marca As String, ByVal coleccion As String)
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.validaSicyEnProducto(sicy, idProducto, marca, coleccion)
    End Function

    Public Function validaExistenciaModeloSicy(ByVal sicy As String)
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.validaExistenciaModeloSicy(sicy)
    End Function

    Public Function validaExisteSicyMarcaColeccion(ByVal sicy As String, ByVal marca As String,
                                                   ByVal coleccion As String) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.validaExisteSicyMarcaColeccion(sicy, marca, coleccion)
    End Function

    'Public Function cargacadena() As DataTable
    '    Dim objPDA As New Programacion.Datos.ProductosDA
    '    Return objPDA.cargacadena
    'End Function

    Public Function estatusProductos() As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.estatusProductos
    End Function
    Public Function estatusProductos2() As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.estatusProductos2
    End Function

    Public Sub guardarProductoSubfamilia(ByVal idProducto As String, ByVal idSubfamilia As String)
        Dim objPDA As New Programacion.Datos.ProductosDA
        objPDA.guardarProductoSubfamilia(idProducto, idSubfamilia)
    End Sub

    Public Function verFamiliaSeleccionadasProducto(ByVal idproducto As String)
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.verFamiliaSeleccionadasProducto(idproducto)
    End Function

    Public Function verLineasSeleccionadasProducto(ByVal idproducto As String)
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.verLineasSeleccionadasProducto(idproducto)
    End Function

    Public Function consultaProductoSubfamilias(ByVal idProducto As Int32) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.consultaProductoSubfamilias(idProducto)
    End Function

    Public Sub desactivarSubfamilias(ByVal idProducto As String)
        Dim objPDA As New Programacion.Datos.ProductosDA
        objPDA.desactivarSubfamilias(idProducto)
    End Sub

    Public Sub editarProductoSubfamilia(ByVal idProducto As Int32, ByVal idSubfamilia As Int32)
        Dim objPDA As New Programacion.Datos.ProductosDA
        objPDA.editarProductoSubfamilia(idProducto, idSubfamilia)
    End Sub
    Public Function verModelosRegistrador()
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.verModelosRegistrador()
    End Function
    Public Function verModelosRegistrador(ByVal activo As Boolean)
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.verModelosRegistrador(activo)
    End Function

    Public Function VerListaProductosWEB(ByVal marca As String, ByVal Coleccion As String, ByVal activo As Boolean, ByVal Cliente As Boolean) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.VerListaProductosWEB(marca, Coleccion, activo, Cliente)
    End Function

    Public Function VerListaProductosWEB(ByVal marca As String, ByVal Coleccion As String,
                                         ByVal activo As Boolean, ByVal Cliente As Boolean,
                                         ByVal idCliente As Int32) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.VerListaProductosWEB(marca, Coleccion, activo, Cliente, idCliente)
    End Function

    Public Function verDetallesProductoWEB(ByVal idProducto As String, ByVal idTalla As String) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.verDetallesProductoWEB(idProducto, idTalla)
    End Function

    Public Sub editarImagenesEstilos(ByVal idsEstilos As String, ByVal rutaImagen As String, ImagenModificar As Integer, Renglon As Integer)
        Dim objPDA As New Programacion.Datos.ProductosDA
        objPDA.editarImagenesEstilos(idsEstilos, rutaImagen, ImagenModificar, Renglon)
    End Sub

    Public Function verClientePropietarioModelo(ByVal idproducto As Int32) As String
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.verClientePropietarioModelo(idproducto)
    End Function

    Public Function consultarExisteEstilo(ByVal productoid As Int32, ByVal pielid As Int32, ByVal colorid As Int32, ByVal tallaid As Int32, ByVal familiaid As Int32, ByVal lineaid As Int32,
                                                      ByVal pielmuestraid As Int32, ByVal forroid As Int32,
                                         ByVal suelaid As Int32, ByVal hormaid As Int32, ByVal productoestiloid As String, ByVal importaACtivo As Boolean) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.consultarExisteEstilo(productoid, pielid, colorid, tallaid, familiaid, lineaid,
                                            pielmuestraid, forroid,
                                            suelaid, hormaid, productoestiloid, importaACtivo)
    End Function


    Public Function consultarExisteEstiloConsumos(ByVal idestilo As Int32, ByVal idtalla As Int32) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.consultarExisteEstiloConsumos(idestilo, idtalla)
    End Function
    Public Function Recuperar_Fracciones_Arancelarias_De_Prodcto(ByVal Fraccion_Detalle As Entidades.Fracciones_Arancelarias_Detalles, ByVal IdCorrida As Integer) As DataTable
        Dim objDA As New Datos.ProductosDA
        Recuperar_Fracciones_Arancelarias_De_Prodcto = objDA.Recuperar_Fracciones_Arancelarias_De_Prodcto(Fraccion_Detalle, IdCorrida)
        Return Recuperar_Fracciones_Arancelarias_De_Prodcto
    End Function
    Public Function validarModeloSICY(ByVal prod_codigo As String) As Boolean
        Dim objDA As New Datos.ProductosDA

        If objDA.validarModeloSICY(prod_codigo) Then
            Return True
        End If

        Return False
    End Function

    Public Function claveSAT() As DataTable
        Dim objDA As New Datos.ProductosDA
        Return objDA.claveSAT()
    End Function

    Public Function ObtenerFamiliasProyeccion() As DataTable
        Dim objDA As New Datos.ProductosDA
        Return objDA.ObtenerFamiliasProyeccion()
    End Function

    Public Function ObtenerSuelasProgramacion() As DataTable
        Dim objDA As New Datos.ProductosDA
        Return objDA.ObtenerSuelasProgramacion()
    End Function

    Public Function ObtenerHormas() As DataTable
        Dim objDA As New Datos.ProductosDA
        Return objDA.ObtenerHormas()
    End Function

    Public Function ValidarPielColorSICY(PielColor As String) As DataTable
        Dim objDA As New Datos.ProductosDA
        Return objDA.ValidarPielColorSICY(PielColor)
    End Function
    Public Function buscarHormaId(ByVal hormanuevo As String) As DataTable

        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.buscarHormaId(hormanuevo)
    End Function
    Public Function buscarClaveFamiliaProyeccion(familiaVentas As String) As Integer
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.buscarClaveFamiliaProyeccion(familiaVentas)
    End Function

    Public Function ValidarArticuloEnPedidoActivo(ProductoEstiloID As String) As Boolean
        Dim objPDA As New Programacion.Datos.ProductosDA
        Dim Resultado As Boolean = False
        Dim DtResultado As DataTable

        DtResultado = objPDA.ValidarArticuloEnPedidoActivo(ProductoEstiloID)

        If IsNothing(DtResultado) = False Then
            If DtResultado.Rows.Count > 0 Then

                If DtResultado.Rows(0).Item(0) > 0 Then 'Articulos No Autorizados en Pedidos Activos
                    Return False
                Else
                    Return True
                End If
            End If
        End If

        Return False
    End Function


    Public Sub CambiarStatusAProductos(ByVal UsuarioID As Integer)
        Dim objDA As New Datos.ProductosDA
        objDA.CambiarStatusAProductosDescontinuados(UsuarioID)
    End Sub

    Public Function validaSicy(ByVal codSicy As String) As DataTable
        Dim objDA As New Datos.ProductosDA

        Return objDA.validaCodSicy(codSicy)

    End Function

    Public Function verProductoActivoInactivo(idProducto As String) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA


        Return objPDA.ValidarProductoenPedidos(idProducto)


    End Function


    Public Function consultarExisteEstiloModelo(ByVal productoid As Int32, ByVal pielid As String, ByVal colorid As String, ByVal tallaid As String, ByVal importaACtivo As Boolean, ByVal modelosay As String) As DataTable
        Dim objPDA As New Programacion.Datos.ProductosDA
        Return objPDA.consultarExisteEstiloModelo(productoid, pielid, colorid, tallaid, importaACtivo, modelosay)
    End Function

    Public Function validaCodigo(codCliente As String) As DataTable
        Dim objPDA As New Datos.ProductosDA
        Return objPDA.validaCodigo(codCliente)
    End Function

End Class
