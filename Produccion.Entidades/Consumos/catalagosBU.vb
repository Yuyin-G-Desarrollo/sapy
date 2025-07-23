Imports Produccion.Datos
Imports Entidades

Public Class catalagosBU

    Public Function GETEstatusProductoEstilo(ByVal ProductoEstilo As Integer) As String
        Dim obj As New catalagosDA
        Return obj.GETEstatusProductoEstilo(ProductoEstilo)
    End Function

    Public Function getidMaquinaria(ByVal descripcion As String) As Integer
        Dim obj As New catalagosDA
        Return obj.getidMaquinaria(descripcion)
    End Function
    Public Function getTiposCortadores() As DataTable
        Dim obj As New catalagosDA
        Return obj.getTiposCortadores()
    End Function
    Public Function validarPrecioActivoMaterialNave(ByVal idMaterialNave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.validarPrecioActivoMaterialNave(idMaterialNave)
    End Function

    Public Function listaProveedores(ByVal naveid As Integer, ByVal materialnaveid As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaProveedores(naveid, materialnaveid)
    End Function

    Public Function listaNaves() As DataTable
        Dim obj As New catalagosDA
        Return obj.listaNaves()
    End Function

    Public Function listaNavesNoSeleccioandas(ByVal lista As List(Of Integer)) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaNavesNoSeleccioandas(lista)
    End Function

    Public Function listaFracciones() As DataTable
        Dim obj As New catalagosDA
        Return obj.listaFracciones()
    End Function

    Public Function listaFraccionesCatalogo(ByVal pActivo As Boolean, ByVal pTodos As Boolean) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaFraccionesCatalogo(pActivo, pTodos)
    End Function

    Public Function listaClasificacionesComponentes(ByVal componente As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaClasificacionesComponentes(componente)
    End Function

    Public Function listaMaquinaria() As DataTable
        Dim obj As New catalagosDA
        Return obj.listaMaquinaria()
    End Function

    Public Function listaDepartamentosGenerales() As DataTable
        Dim obj As New catalagosDA
        Return obj.listaDepartamentosGenerales()
    End Function

    Public Function listaDepartamentos(ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaDepartamentos(nave)
    End Function

    Public Function listaMaterialesParaDesarrollo(ByVal naveid As Integer, ByVal clasificacion As Integer, ByVal lista As List(Of Integer), ByVal EstatusEstilo As String) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaMaterialesParaDesarrollo(naveid, clasificacion, lista, EstatusEstilo)
    End Function

    Public Function listaMateriales(ByVal naveid As Integer, ByVal clasificacion As Integer, ByVal material As Integer, ByVal EstatusEstilo As String) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaMateriales(naveid, clasificacion, material, EstatusEstilo)
    End Function

    Public Function listaMaterialesCompleta(ByVal naveid As Integer, ByVal componente As Integer, ByVal material As Integer, Optional ByVal MaterialIDReemplazar As Integer = 0, Optional ByVal proveedorMaterial As Integer = 0) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaMaterialesCompleta(naveid, componente, material, MaterialIDReemplazar, proveedorMaterial)
    End Function

    Public Function listaMaterialesEnConsumos(ByVal naveid As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaMaterialesEnConsumos(naveid)
    End Function

    Public Function AutorizarDesarrollo(ByVal estilo As Integer, ByVal naveId As Integer, ByVal usuarioId As Integer)
        Dim obj As New catalagosDA
        Return obj.AutorizarDesarrollo(estilo, naveId, usuarioId)
    End Function

    Public Function AutorizarProduccion(ByVal estilo As Integer, ByVal naveId As Integer)
        Dim obj As New catalagosDA
        Return obj.AutorizarProduccion(estilo, naveId)
    End Function

    Public Function AutorizarProduccionNaveProduccion(ByVal estilo As Integer, ByVal nave As Integer)
        Dim obj As New catalagosDA
        Return obj.AutorizarProduccionNaveProduccion(estilo, nave)
    End Function

    Public Function EstatusAnterior(ByVal estilo As Integer, ByVal estatus As String, ByVal naveId As Integer)
        Dim obj As New catalagosDA
        Return obj.EstatusAnterior(estilo, estatus, naveId)
    End Function

    Public Function descontinuadoAInactivoEnNave(ByVal estilo As Integer, ByVal naveId As Integer)
        Dim obj As New catalagosDA
        Return obj.descontinuadoAInactivoEnNave(estilo, naveId)
    End Function

    Public Function Descontinuar(ByVal estilo As Integer, ByVal naveId As Integer)
        Dim obj As New catalagosDA
        Return obj.Descontinuar(estilo, naveId)
    End Function

    Public Function DescontinuarEnNAves(ByVal estilo As Integer, ByVal naveId As Integer)
        Dim obj As New catalagosDA
        Return obj.DescontinuarEnNAves(estilo, naveId)
    End Function

    Public Function Inactivar(ByVal estilo As Integer, ByVal nave As Integer)
        Dim obj As New catalagosDA
        Return obj.Inactivar(estilo, nave)
    End Function

    Public Function InactivarEnNave(ByVal estilo As Integer, ByVal nave As Integer, ByVal tiponave As Integer)
        Dim obj As New catalagosDA
        Return obj.InactivarEnNaveConsumos(estilo, nave, tiponave)
    End Function

    Public Function ActualizaEstatusProuctoEstilo(ByVal poductoEstiloid As Integer, ByVal idNaveSay As Integer) As DataTable
        Dim objDa As New catalagosDA
        Return objDa.ActualizaEstatusProuctoEstilo(poductoEstiloid, idNaveSay)
    End Function

    Public Function TodasNavesInactivaEstilo(ByVal ProductoEstilo As Integer) As Boolean
        Dim obj As New catalagosDA
        Dim NavesSinInactivar As Integer = 0
        Dim Existe As Boolean = False
        NavesSinInactivar = obj.TodasNavesInactivaEstilo(ProductoEstilo)

        If NavesSinInactivar = 0 Then
            Existe = True
        Else
            Existe = False
        End If

        Return Existe

    End Function

    Public Function InactivarEnNave(ByVal estilo As Integer, ByVal nave As Integer)
        Dim obj As New catalagosDA
        Return obj.InactivarEnNave(estilo, nave)
    End Function

    Public Function InactivarEnNavePrincipal(ByVal estilo As Integer, ByVal nave As Integer)
        Dim obj As New catalagosDA
        Return obj.InactivarEnNavePrincipal(estilo, nave)
    End Function

    Public Function AsignarProductoNaveProduccion(ByVal componente As Consumos) As DataTable
        Dim obj As New catalagosDA
        Return obj.AsignarProductoNaveProduccion(componente)
    End Function

    Public Function ActualizarHistorialProductoEstilo(ByVal componente As Consumos) As DataTable
        Dim obj As New catalagosDA
        Return obj.ActualizarHistorialProductoEstilo(componente)
    End Function

    Public Function ActualizarHistorialProductoEstiloConNave(ByVal componente As Consumos) As DataTable
        Dim obj As New catalagosDA
        Return obj.ActualizarHistorialProductoEstiloConNave(componente)
    End Function

    Public Function HistorialEstilo(ByVal estilo As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.HistorialEstilo(estilo)
    End Function

    Public Function GuardarFracciones(ByVal fraccion As Fracciones) As DataTable
        Dim obj As New catalagosDA
        Return obj.GuardarFracciones(fraccion)
    End Function

    Public Function ActualizarFracciones(ByVal fraccion As Fracciones) As DataTable
        Dim obj As New catalagosDA
        Return obj.ActualizarFracciones(fraccion)
    End Function

    Public Function GuardarMaquinaria(ByVal maquinaria As Maquinaria) As DataTable
        Dim obj As New catalagosDA
        Return obj.GuardarMaquinaria(maquinaria)
    End Function

    Public Function ActualizarMaquinaria(ByVal maquinaria As Maquinaria) As DataTable
        Dim obj As New catalagosDA
        Return obj.ActualizarMaquinaria(maquinaria)
    End Function

    Public Function listaFraccioness(Optional FraccionesRepetidas As String = "") As DataTable
        Dim obj As New catalagosDA
        Return obj.listaFraccioness(FraccionesRepetidas)
    End Function

    Public Function listaFraccionesNave(ByVal NaveID As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaFraccionesNave(NaveID)
    End Function

    Public Function filtradoCambiosGlobales(ByVal nave As Integer, ByVal marca As Integer, ByVal coleccion As Integer,
                                            ByVal componentes As List(Of Integer), ByVal prodEstilo As List(Of Integer), ByVal accion As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.filtradoCambiosGlobales(nave, marca, coleccion, componentes, prodEstilo, accion)
    End Function

    Public Function filtradoFracciones(ByVal nave As Integer, ByVal marca As Integer, ByVal coleccion As Integer, ByVal fraccion As Integer, ByVal nuevo As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.filtradoFracciones(nave, marca, coleccion, fraccion, nuevo)
    End Function

    Public Function filtradoCambiosGlobales2(ByVal nave As Integer, ByVal marca As Integer, ByVal coleccion As Integer,
                                            ByVal componentes As List(Of Integer), ByVal prodEstilo As List(Of Integer), ByVal accion As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.filtradoCambiosGlobales2(nave, marca, coleccion, componentes, prodEstilo, accion)
    End Function

    Public Function filtradoCambiosGlobales3(ByVal idnave As Integer, ByVal material As Integer, ByVal clas As Integer,
                                             ByVal marca As Integer, ByVal coleccion As Integer, ByVal pProveedor As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.filtradoCambiosGlobales3(idnave, material, clas, marca, coleccion, pProveedor)
    End Function

    Public Function filtradoCambiosGlobales4(ByVal nave As Integer, ByVal clasificacionid As Integer, ByVal materialnaveid As Integer,
                                             ByVal proveedorid As Integer, ByVal marca As Integer, ByVal coleccion As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.filtradoCambiosGlobales4(nave, clasificacionid, materialnaveid, proveedorid, marca, coleccion)
    End Function

    Public Function listaDeMarcasPNP(ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaDeMarcasPNP(nave)
    End Function

    Public Function listaDeMarcasEnMaterialSeleccionado(ByVal pNave As Integer, ByVal pMaterialNave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaDeMarcasEnMaterialSeleccionado(pNave, pMaterialNave)
    End Function

    Public Function listaDeMarcasEnMaterialSeleccionadoNave(ByVal pNave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaDeMarcasEnMaterialSeleccionadoNave(pNave)
    End Function

    Public Function listaDeColeccionesPNP(ByVal nave As Integer, ByVal marca As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaDeColeccionesPNP(nave, marca)
    End Function

    Public Function listaDeColeccionesMaterialesSeleccionados(ByVal nave As Integer, ByVal materialNave As Integer,
                                                              ByVal marca As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaDeColeccionesMaterialesSeleccionados(nave, materialNave, marca)
    End Function
    Public Function ObtenerColeccionesNaveMaterialesSeleccionados(ByVal pNaveId As Integer, ByVal pMarcaId As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.ObtieneColeccionesNaveMaterialesSeleccionados(pNaveId, pMarcaId)
    End Function

    Public Function listaDeMaquinaria(ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaDeMaquinaria(nave)
    End Function

    Public Function actualizarProductos(ByVal proveedorid As Integer, ByVal precioP As Double, ByVal umpid As Integer,
                                        ByVal factor As Double, ByVal materialid As Integer, ByVal productoestiloid As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.actualizarProveedor(proveedorid, precioP, umpid, factor, materialid, productoestiloid)
    End Function

    Public Function HistorialProductoEstilo(ByVal idproductoestilo As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.HistorialProductoEstilo(idproductoestilo)
    End Function

    Public Function listaClasificaciones() As DataTable
        Dim obj As New catalagosDA
        Return obj.listaClasificaciones()
    End Function

    Public Function listaClasificacionesSeleccionadas(ByVal componente As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaClasificacionesSeleccionadas(componente)
    End Function

    Public Function GuardarComponenteClasificacion(ByVal cocl As ComponenteClasificacion) As DataTable
        Dim obj As New catalagosDA
        Return obj.GuardarComponenteClasificacion(cocl)
    End Function

    Public Function ModificarComponenteClasificacion(ByVal cocl As ComponenteClasificacion) As DataTable
        Dim obj As New catalagosDA
        Return obj.ModificarComponenteClasificacion(cocl)
    End Function

    Public Function listaDeMarcas(ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaMarcas(nave)
    End Function

    Public Function ListadoMarcasFraccionesNave(ByVal NaveId As Integer, ByVal FraccionId As Integer, ByVal Observaciones As String) As DataTable
        Dim obj As New catalagosDA
        Return obj.ListadoMarcasFraccionesNave(NaveId, FraccionId, Observaciones)
    End Function

    Public Function listaMarcasImportarConsumos(ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaMarcasImportarConsumos(nave)
    End Function

    Public Function listaMarcasProduccion(ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaMarcasProduccion(nave)
    End Function

    Public Function listaMarcasPorAsignar() As DataTable
        Dim obj As New catalagosDA
        Return obj.listaMarcasPorAsignar()
    End Function

    Public Function listaMarcasPorAsignar(ByVal NaveID As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaMarcasPorAsignar(NaveID)
    End Function

    Public Function listaColecciones(ByVal nave As Integer, ByVal marca As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaColecciones(nave, marca)
    End Function

    Public Function listaColeccionesSinAsignar(ByVal marca As Integer, ByVal Nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaColeccionesSinAsignar(marca, Nave)
    End Function

    Public Function listaColeccionesNaveDesarrolla(ByVal nave As Integer, ByVal marca As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaColeccionesNaveDesarrolla(nave, marca)
    End Function

    Public Function ListadoColeccionFraccionesNaveMarca(ByVal NaveId As Integer, ByVal FraccionId As Integer, ByVal Observaciones As String, ByVal MarcaID As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.ListadoColeccionFraccionesNaveMarca(NaveId, FraccionId, Observaciones, MarcaID)
    End Function

    Public Function VerListaProductosImportarConsumos(ByVal naveid As Integer, ByVal marca As Integer,
                                                      ByVal coleccion As Integer, ByVal articulo As Integer)
        Dim obj As New catalagosDA
        Return obj.VerListaProductosImportarConsumos(naveid, marca, coleccion, articulo)
    End Function


    Public Function VerListaProductosImportarConsumos2(ByVal naveid As Integer, ByVal marca As Integer,
                                                      ByVal coleccion As Integer, ByVal articulo As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.VerListaProductosImportarConsumos2(naveid, marca, coleccion, articulo)
    End Function


    Public Function getconsumosCopiar(ByVal productoEstiloId As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.getconsumosCopiar(productoEstiloId)
    End Function

    Public Function getfraccionesCopiar(ByVal productoEstiloId As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.getfraccionesCopiar(productoEstiloId)
    End Function

    Public Function ConsumosSeleccionados(ByVal listaConsumos As List(Of Integer)) As DataTable
        Dim obj As New catalagosDA
        Return obj.ConsumosSeleccionados(listaConsumos)
    End Function

    Public Function ConsumoSeleccionadId(ByVal ConsumoId As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.ConsumoSeleccionadId(ConsumoId)
    End Function

    Public Function FraccionesSeleccionadss(ByVal listaFracciones As List(Of Integer)) As DataTable
        Dim obj As New catalagosDA
        Return obj.FraccionesSeleccionadss(listaFracciones)
    End Function

    Public Function ListaMaterialesConsumosProductoEstilo(ByVal idproductoestilo As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.ListaMaterialesConsumosProductoEstilo(idproductoestilo)
    End Function
    Public Function ConSuelaProductoEstilo(ByVal idproductoestilo As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.ConsuelaProductoEstilo(idproductoestilo)
    End Function

    Public Function EstatusProduccionMateriales(ByVal listaMateriales As List(Of Integer)) As DataTable
        Dim obj As New catalagosDA
        Return obj.EstatusProduccionMateriales(listaMateriales)
    End Function

    Public Function reemplazarMaterialConsumos(ByVal c As Consumo, ByVal material As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.reemplazarMaterialConsumos(c, material)
    End Function

    Public Sub ReemplazarMaterialConsumos2(ByVal MaterialConsumoNuevo As Consumo, ByVal MaterialIDAnterior As Integer, ByVal UsuarioModificaID As Integer)
        Dim obj As New catalagosDA
        obj.ReemplazarMaterialConsumos2(MaterialConsumoNuevo, MaterialIDAnterior, UsuarioModificaID)
    End Sub

    Public Function ActualizarPrecioFraccion(ByVal productoEstiloid As Integer, ByVal fraccionid As Integer, ByVal precio As Double) As DataTable
        Dim obj As New catalagosDA
        Return obj.ActualizarPrecioFraccion(productoEstiloid, fraccionid, precio)
    End Function

    Public Function ActualizarPrecioFraccion2(ByVal productoEstiloid As Integer, ByVal fraccionid As Integer, ByVal precio As Double, ByVal NaveID As Integer, ByVal Observaciones As String, ByVal UsuarioID As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.ActualizarPrecioFraccion2(productoEstiloid, fraccionid, precio, NaveID, Observaciones, UsuarioID)
    End Function

    Public Function listaNavesAsignadasEstilo(ByVal estilo As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaNavesAsignadasEstilo(estilo)
    End Function

    Public Function listaProveedoresNave(ByVal nave As Integer, ByVal proveedor As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaProveedoresNave(nave, proveedor)
    End Function

    Public Function listaMaterialesNave(ByVal nave As Integer, ByVal material As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaMaterialesNave(nave, material)
    End Function

    Public Function BuscarFraccionesRepetidas(ByVal ProductoEstilo As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.BuscarFraccionesRepetidas(ProductoEstilo)
    End Function

    Public Function ObtenerFraccionesProductoEstiloNave(ByVal ProductoEstilo As Integer, ByVal NaveID As Integer, ByVal FraccionID As Integer, ByVal Observaciones As String) As DataTable
        Dim obj As New catalagosDA
        Return obj.ObtenerFraccionesProductoEstiloNave(ProductoEstilo, NaveID, FraccionID, Observaciones)
    End Function

    Public Function ObtenerFraccionesProductoEstiloNave(ByVal ProductoEstilo As Integer, ByVal NaveID As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.ObtenerFraccionesProductoEstiloNave(ProductoEstilo, NaveID)
    End Function

    Public Function ObtenerFraccionesProductoEstiloNavePorOrden(ByVal ProductoEstilo As Integer, ByVal NaveID As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.ObtenerFraccionesProductoEstiloNavePorOrden(ProductoEstilo, NaveID)
    End Function


    Public Function InsertarMaterialesNave(ByVal nave As Integer, ByVal material As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.InsertarMaterialesNave(nave, material)
    End Function

    Public Function InsertarProveedoresNave(ByVal nave As Integer, ByVal proveedor As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.InsertarProveedoresNave(nave, proveedor)
    End Function

    Public Function TipoNave(ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.TipoNave(nave)
    End Function

    Public Function naveMaquila(ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.naveMaquila(nave)
    End Function

    Public Function listaNavesAsiganadasaProduccionEstilo(ByVal productoEstiloId As Integer, ByVal naveid As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaNavesAsiganadasaProduccionEstilo(productoEstiloId, naveid)
    End Function

    Public Function VerListaProductosImagenProduccion(ByVal naveid As Integer, ByVal estatus As String, ByVal marca As Integer, ByVal coleccion As Integer, ByVal tipoNave As Integer)
        Dim obj As New catalagosDA
        Return obj.VerListaProductosImagenProduccion(naveid, estatus, marca, coleccion, tipoNave)
    End Function

    Public Function listaNavesYaAsginadas(ByVal estilosId As String, ByVal accionConsulta As String) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaNavesYaAsginadas(estilosId, accionConsulta)
    End Function

    Public Function listaNavesSicy(ByVal nave As String) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaNavesSicy(nave)
    End Function

    Public Function idLoteProduccion(ByVal fechade As String, ByVal fechaal As String, ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.idLoteProduccion(fechade, fechaal, nave)
    End Function

    Public Function consultaLoteProduccion(ByVal listaID As List(Of Integer), ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.consultaLoteProduccion(listaID, nave)
    End Function

    'Public Function consultaLoteProduccion(ByVal listaID As Integer, ByVal nave As Integer) As DataTable
    '    Dim obj As New catalagosDA
    '    Return obj.consultaLoteProduccion(listaID, nave)
    'End Function

    Public Function consultaLoteProduccionReporte(ByVal listaID As List(Of Integer), ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.consultaLoteProduccionReporte(listaID, nave)
    End Function

    Public Function ConsultaCortadores(ByVal nave As Integer, ByVal tipo As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.ConsultaCortadores(nave, tipo)
    End Function

    Public Function listaColaboradoresSicy(ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaColaboradoresSicy(nave)
    End Function

    Public Function listaDepartamentossicy(ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaDepartamentossicy(nave)
    End Function

    Public Function listaEmpledosLotesProduccion(ByVal Estatus As String, ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.listaEmpledosLotesProduccion(Estatus, nave)
    End Function

    'Public Function listaEmpledosLotesProduccion(ByVal Estatus As Integer, ByVal nave As Integer) As DataTable
    '    Dim obj As New catalagosDA
    '    Return obj.listaEmpledosLotesProduccion(Estatus, nave)
    'End Function

    Public Function ListaMAterialesNaveObtenerMaterialID(ByVal listaMateriales As List(Of Integer)) As DataTable
        Dim obj As New catalagosDA
        Return obj.ListaMAterialesNaveObtenerMaterialID(listaMateriales)
    End Function

    Public Function buscarFraccion(ByVal fraccion As String) As DataTable
        Dim obj As New catalagosDA
        Return obj.buscarFraccion(fraccion)
    End Function

    Public Function buscarMaquinaria(ByVal maquinaria As String) As DataTable
        Dim obj As New catalagosDA
        Return obj.buscarMaquinaria(maquinaria)
    End Function

    Public Function ConsultarEstatusProductoEstilo(ByVal articulo As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.ConsultarEstatusProductoEstilo(articulo)
    End Function

    Public Function ConsultarEstatusProductoEstiloConNave(ByVal articulo As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.ConsultarEstatusProductoEstiloConNave(articulo)
    End Function

    Public Function ConsultarEstatusProductoEstiloConId(ByVal articulo As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.ConsultarEstatusProductoEstiloConId(articulo)
    End Function

    Public Function ListaColeccionesArticulosConConsumos(ByVal marca As Integer, ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.ListaColeccionesArticulosConConsumos(marca, nave)
    End Function

    Public Function ListaMArcasArticulosConConsumos() As DataTable
        Dim obj As New catalagosDA
        Return obj.ListaMArcasArticulosConConsumos()
    End Function

    '''*******
    Public Function reportePrueba() As DataTable
        Dim obj As New catalagosDA
        Return obj.reportePrueba()
    End Function

    Public Function reportePruebaNoPares() As DataTable
        Dim obj As New catalagosDA
        Return obj.reportePruebaNoPares()
    End Function

    Public Function pedidoEspecialEnProceso() As DataTable
        Dim obj As New catalagosDA
        Return obj.pedidoEspecialEnProceso()
    End Function

    Public Function ConcentradoCasco1() As DataTable
        Dim obj As New catalagosDA
        Return obj.ConcentradoCasco1()
    End Function

    Public Function ConcentradoCascoSumado() As DataTable
        Dim obj As New catalagosDA
        Return obj.ConcentradoCascoSumado()
    End Function

    Public Function ConcentradoCasco2() As DataTable
        Dim obj As New catalagosDA
        Return obj.ConcentradoCasco2()
    End Function

    Public Function ConcentradoContrafuerte1() As DataTable
        Dim obj As New catalagosDA
        Return obj.ConcentradoContrafuerte1()
    End Function

    Public Function ConcentradoContrafuerte2() As DataTable
        Dim obj As New catalagosDA
        Return obj.ConcentradoContrafuerte2()
    End Function

    Public Function PedidoDeSuelaEspecial() As DataTable
        Dim obj As New catalagosDA
        Return obj.PedidoDeSuelaEspecial()
    End Function

    Public Function X() As DataTable
        Dim obj As New catalagosDA
        Return obj.X()
    End Function

    Public Function ConsultaCortadoresReporte(ByVal fechaPrograma As String, ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.ConsultaCortadoresReporte(fechaPrograma, nave)
    End Function

    Public Function ConsultaMaterialesCortadoresPiel(ByVal fechaPrograma As String, ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.ConsultaMaterialesCortadoresPiel(fechaPrograma, nave)
    End Function

    Public Function ConsultaCortadoresPiel(ByVal fechaPrograma As String, ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.ConsultaCortadoresPiel(fechaPrograma, nave)
    End Function

    Public Function ConsultaReporteHerrajes(ByVal fechaPrograma As String, ByVal nave As Integer) As DataTable
        Dim obj As New catalagosDA
        Return obj.ConsultaReporteHerrajes(fechaPrograma, nave)
    End Function

    Public Function Y() As DataTable
        Dim obj As New catalagosDA
        Return obj.Y()
    End Function

    ' ''' ******
    Public Sub ReemplazarMaterialConsumosXml(ByVal MaterialConsumo As String, ByVal UsuarioModificaID As Integer, SoloNaveDesarrollo As Boolean, idNave As Integer)
        Dim obj As New catalagosDA
        obj.ReemplazarMaterialConsumosXml(MaterialConsumo, UsuarioModificaID, SoloNaveDesarrollo, idNave)
    End Sub

    Public Function ObtenerArticulosMarcaColeccion(ByVal pMarcaId As Integer, ByVal pColeccionId As Integer, ByVal pNaveId As Integer, ByVal pMaterialIds As String) As DataTable
        Dim obj As New catalagosDA
        Return obj.ObtineArticulosMarcaColeccion(pMarcaId, pColeccionId, pNaveId, pMaterialIds)
    End Function

    Public Sub GuardarMaterialesCambiosGlobales(ByVal pXmlMateriales As String, ByVal pArticulos As String, ByVal UsuarioModificaID As Integer)
        Dim obj As New catalagosDA
        obj.GuardaMaterialesCambiosGlobales(pXmlMateriales, pArticulos, UsuarioModificaID)
    End Sub

    Public Sub ActualizaProduccionNaveProduccion(ByVal pXmlArticulos As String, ByVal pNaveId As Integer, ByVal pUsuarioId As Integer)
        Dim obj As New catalagosDA
        obj.ActualizarProduccionNaveProduccion(pXmlArticulos, pNaveId, pUsuarioId)
    End Sub

    Public Sub InsertarActualizarComponenteClasificacion(ByVal pXmlClasificacion As String, ByVal pUsuarioId As Integer)
        Dim obj As New catalagosDA
        obj.InsertaActualizaComponenteClasificacion(pXmlClasificacion, pUsuarioId)
    End Sub

    Public Sub EliminarFraccionesGlobales(ByVal pXmlFraccionesProductos As String, ByVal pIdFraccion As Integer, ByVal pIdNave As Integer)
        Dim obj As New catalagosDA
        obj.EliminaFraccionesGlobales(pXmlFraccionesProductos, pIdFraccion, pIdNave)
    End Sub
    Public Function ObtenerNavesMaquilas() As DataTable
        Dim obj As New catalagosDA
        Return obj.ObtieneNavesMaquilas()
    End Function

    Public Sub EliminaMaterialConsumosXml(ByVal MaterialConsumo As String, ByVal UsuarioModificaID As Integer)
        Dim obj As New catalagosDA
        obj.EliminarMaterialConsumosXml(MaterialConsumo, UsuarioModificaID)
    End Sub

    Public Function InactivarMaterialConsumoProduccionNave(ByVal productoEstiloID As Integer, ByVal idNave As Integer)
        Dim obj As New catalagosDA
        Return obj.InactivarMaterialConsumoProduccionNave(productoEstiloID, idNave)
    End Function

End Class

