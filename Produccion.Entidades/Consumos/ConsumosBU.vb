Imports Produccion.Datos
Imports Entidades

Public Class ConsumosBU
    Public Function getObservacionesFracciones(ByVal cadena As String) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getObservacionesFracciones(cadena)
    End Function
    Public Function getMaterialesAutorizadosProduccionArticulo(ByVal ProductoEstilo As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getMaterialesAutorizadosProduccionArticulo(ProductoEstilo)
    End Function
    Public Function getMaterialPrecioProveedorNave(ByVal MAterialID As Integer, ByVal NAveID As Integer, ByVal ProveedorID As Integer, ByVal Precio As Double) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getMaterialPrecioProveedorNave(MAterialID, NAveID, ProveedorID, Precio)
    End Function
    Public Function getMaterialPrecio(ByVal MAterialNaveID As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getMaterialPrecio(MAterialNaveID)
    End Function
    Public Function getMaterialNaveID(ByVal MAterialID As Integer, ByVal NAveID As Integer) As Integer
        Dim obj As New ConsumosDA
        Return obj.getMaterialNaveID(MAterialID, NAveID)
    End Function
    Public Function getExistePrecioMaterialNaveProveedor(ByVal MAterialNAveID As Integer, ByVal ProveedorID As Integer, ByVal Precio As Double) As Boolean
        Dim obj As New ConsumosDA
        Dim Existe As Boolean = False
        Dim Count As Integer = 0
        Count = obj.getExistePrecioMaterialNaveProveedor(MAterialNAveID, ProveedorID, Precio)

        If Count > 0 Then
            Existe = True
        Else
            Existe = False
        End If

        Return Existe
    End Function
    Public Function EsNaveDesarrolla(ByVal NaveID As Integer) As Boolean
        Dim obj As New ConsumosDA
        Return obj.EsNaveDesarrolla(NaveID)
    End Function
    Public Function getMaquinaria() As DataTable
        Dim obj As New ConsumosDA
        Return obj.getMaquinaria()
    End Function
    Public Function getNaveDesarrolla(ByVal productoEstiloId As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getNaveDesarrolla(productoEstiloId)
    End Function
    Public Function getNaveDesarrollaID(ByVal productoEstiloId As Integer) As String
        Dim obj As New ConsumosDA
        Return obj.getNaveDesarrollaID(productoEstiloId)
    End Function
    Public Function getconsumosDesExcel(ByVal productoEstiloId As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getconsumosDesExcel(productoEstiloId)
    End Function
    Public Function getconsumosProdExcel(ByVal productoEstiloId As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getconsumosDesExcel(productoEstiloId)
    End Function

    Public Function getNavesProduccion(ByVal productoEstiloId As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getNavesProduccion(productoEstiloId)
    End Function
    Public Function insertFraccionProd(ByVal f As Fracciones) As DataTable
        Dim obj As New ConsumosDA
        Return obj.insertFraccionProd(f)
    End Function
    Public Function getfraccionesProd(ByVal productoEstiloId As Integer, ByVal idNave As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getfraccionesProd(productoEstiloId, idNave)
    End Function
    Public Function getconsumosProd(ByVal productoEstiloId As Integer, ByVal idNave As Integer, Optional ByVal MostrarConsumoInactivo As Integer = False) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getconsumosProd(productoEstiloId, idNave)
    End Function
    Public Function getconsumosProd2(ByVal productoEstiloId As Integer, ByVal idNave As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getconsumosProd2(productoEstiloId, idNave)
    End Function
    Public Function getconsumosDes2(ByVal productoEstiloId As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getconsumosDes2(productoEstiloId)
    End Function
    Public Function getNavesAfectadas(ByVal productoEstiloId As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getNavesAfectadas(productoEstiloId)
    End Function
    Public Function validarNave(ByVal productoEstiloId As Integer, ByVal idNave As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.validarNave(productoEstiloId, idNave)
    End Function
    Public Function getFraccion(ByVal idFraccion As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getFraccion(idFraccion)
    End Function
    Public Function getfraccionesDes(ByVal productoEstiloId As Integer, ByVal idNave As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getfraccionesDes(productoEstiloId, idNave)
    End Function
    Public Function getfraccionesDes2(ByVal productoEstiloId As Integer, ByVal idNave As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getfraccionesDes2(productoEstiloId, idNave)
    End Function
    Public Function insertFraccionDes(ByVal f As Fracciones) As DataTable
        Dim obj As New ConsumosDA
        Return obj.insertFraccionDes(f)
    End Function
    Public Function insertFraccionDesNueva(ByVal f As Fracciones, ByVal factual As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.insertFraccionDesNueva(f, factual)
    End Function
    Public Function insertConsumo(ByVal c As Consumo, Optional idNaveConsulta As Integer = 0) As DataTable
        Dim obj As New ConsumosDA
        Return obj.insertConsumo(c, idNaveConsulta)
    End Function

    Public Function reemplazarConsumo(ByVal c As Consumo) As DataTable
        Dim obj As New ConsumosDA
        Return obj.reemplazarConsumo(c)
    End Function
    Public Function reemplazarConsumos(ByVal c As Consumo) As DataTable
        Dim obj As New ConsumosDA
        Return obj.reemplazarConsumos(c)
    End Function
    Public Function eliminarConsumos(ByVal productoEstiloId) As DataTable
        Dim obj As New ConsumosDA
        Return obj.eliminarConsumos(productoEstiloId)
    End Function
    Public Function getconsumosDes(ByVal productoEstiloId As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getconsumosDes(productoEstiloId)
    End Function
    Public Function getDatosProducto(ByVal productoEstiloId As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getDatosProducto(productoEstiloId)
    End Function

    Public Function ObtenerTotalConsumoDesarrollo(ByVal productoEstiloId As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.ObtenerTotalConsumoDesarrollo(productoEstiloId)
    End Function
    Public Function ObtenerTotalConsumoProduccion(ByVal productoEstiloId As Integer, ByVal idNave As Integer, ByVal MostrarConsumoInactivo As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.ObtenerTotalConsumoProduccion(productoEstiloId, idNave, MostrarConsumoInactivo)
    End Function
    Public Function getMarcas(ByVal idNave As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getMarcas(idNave)
    End Function
    Public Function getColecciones(ByVal idMarca As Integer, ByVal idNave As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getColecciones(idMarca, idNave)
    End Function
    Public Function listadoProductosSinNave(ByVal idColecc As Integer, ByVal idNave As Integer, ByVal idmarca As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.listadoProductosSinNave(idColecc, idNave, idmarca)
    End Function
    Public Function VerListaProductos(ByVal naveid As Integer)
        Dim obj As New ConsumosDA
        Return obj.VerListaProductos(naveid)
    End Function
    Public Function listaComponente() As DataTable
        Dim obj As New ConsumosDA
        Return obj.listaComponente()
    End Function

    Public Function VerListaProductosPorNaveyEstatus(ByVal naveid As Integer, ByVal estatus As String)
        Dim obj As New ConsumosDA
        Return obj.VerListaProductosPorNaveyEstatus(naveid, estatus)
    End Function
    Public Function VerListaProductosImagen(ByVal naveid As Integer, ByVal estatus As String, ByVal marca As Integer, ByVal coleccion As Integer, ByVal tipoNave As Integer)
        Dim obj As New ConsumosDA
        Return obj.VerListaProductosImagen(naveid, estatus, marca, coleccion, tipoNave)
    End Function
    Public Function VerListaProductosImagenFracciones(ByVal naveid As Integer, ByVal estatus As String, ByVal marca As Integer, ByVal coleccion As Integer, ByVal tipoNave As Integer)
        Dim obj As New ConsumosDA
        Return obj.VerListaProductosImagenFracciones(naveid, estatus, marca, coleccion, tipoNave)
    End Function

    Public Function ListadoProductosFraccionesNave(ByVal naveid As Integer, ByVal estatus As String,
                                            ByVal marca As Integer, ByVal coleccion As Integer, ByVal tipoNave As Integer, ByVal FraccionID As Integer, ByVal Observaciones As String) As DataTable
        Dim obj As New ConsumosDA
        Return obj.ListadoProductosFraccionesNave(naveid, estatus, marca, coleccion, tipoNave, FraccionID, Observaciones)
    End Function

    Public Function VerListaProductosImagen2(ByVal naveid As Integer, ByVal estatus As String, ByVal marca As Integer, ByVal coleccion As Integer, ByVal tipoNave As Integer)
        Dim obj As New ConsumosDA
        Return obj.VerListaProductosImagen2(naveid, estatus, marca, coleccion, tipoNave)
    End Function
    Public Function VerListaProductosImagen3(ByVal naveid As Integer, ByVal estatus As String, ByVal marca As Integer, ByVal coleccion As Integer, ByVal tipoNave As Integer)
        Dim obj As New ConsumosDA
        Return obj.VerListaProductosImagen3(naveid, estatus, marca, coleccion, tipoNave)
    End Function

    Public Function ObtenerMarcasEstilosConsumos(ByVal naveid As Integer, ByVal estatus As String) As DataTable
        Dim obj As New ConsumosDA
        Return obj.ObtenerMarcasEstilosConsumos(naveid, estatus)
    End Function

    Public Function ObtenerEstatusProductoEstiloConsumos(ByVal NaveID As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.ObtenerEstatusProductoEstiloConsumos(NaveID)
    End Function
    Public Function ObtenerEstatusProductoEstiloConsumos_Estatus(ByVal NaveID As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.ObtenerEstatusProductoEstiloConsumos_Estatus(NaveID)
    End Function

    Public Function ObtenerColeccionesProductoEstiloConsumos(ByVal NaveID As Integer, ByVal Estatus As String, ByVal MarcaID As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.ObtenerColeccionesProductoEstiloConsumos(NaveID, Estatus, MarcaID)
    End Function

    Public Function actualizarProductos(ByVal idNave As Integer, ByVal idProducto As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.actualizarProductos(idNave, idProducto)
    End Function
    Public Function listaDepartamentos() As DataTable
        Dim obj As New ConsumosDA
        Return obj.listaDepartamentos()
    End Function
    Public Function listaComponentes() As DataTable
        Dim obj As New ConsumosDA
        Return obj.listaComponente()
    End Function
    Public Function GuardarComponente(ByVal componente As Consumos) As DataTable
        Dim obj As New ConsumosDA
        Return obj.GuardarComponente(componente)
    End Function
    Public Function ModificarComponente(ByVal componente As Consumos) As DataTable
        Dim obj As New ConsumosDA
        Return obj.ModificarComponente(componente)
    End Function
    Public Function ComponenteRepetido(ByVal componente As String) As DataTable
        Dim obj As New ConsumosDA
        Return obj.ComponenteRepetido(componente)
    End Function
    Public Function listaClasificaciones() As DataTable
        Dim obj As New ConsumosDA
        Return obj.listaClasificaciones()
    End Function
    Public Function listaProveedores() As DataTable
        Dim obj As New ConsumosDA
        Return obj.listaClasificaciones()
    End Function
    Public Function ActualizarImagenes(ByVal suela As String, ByVal caja As String, ByVal marca As String, ByVal productoEstiloId As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.ActualizarImagenes(suela, caja, marca, productoEstiloId)
    End Function

    Public Function listaClasificacionesComponente() As DataTable
        Dim obj As New ConsumosDA
        Return obj.listaComponente()
    End Function
    Public Function getComponente(ByVal idComponente As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getComponente(idComponente)
    End Function
    Public Function getMaterialporSKU(ByVal sku As String) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getMaterialporSKU(sku)
    End Function
    Public Function getProveedor(ByVal idProveedor As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getProveedor(idProveedor)
    End Function
    Public Function validarMaterialComponente(ByVal sku As String, ByVal idComponente As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.validarMaterialComponente(sku, idComponente)
    End Function
    Public Function validarAsignacionMaterial(ByVal sku As String, ByVal idNave As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.validarAsignacionMaterial(sku, idNave)
    End Function
    Public Function validarMaterialProveedor(ByVal idProveedor As Integer, ByVal idMaterialNave As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.validarMaterialProveedor(idProveedor, idMaterialNave)
    End Function

    Public Function buscarComponenteRepetido(ByVal Componente As String) As DataTable
        Dim obj As New ConsumosDA
        Return obj.buscarComponenteRepetido(Componente)
    End Function
    Public Function SaberTipoNave(ByVal nave As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.SaberTipoNave(nave)
    End Function
    Public Function articuloAsignadoANaveEstatusAP(ByVal ESTILO As Integer, ByVal idNave As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.articuloAsignadoANaveEstatusAP(ESTILO, idNave)
    End Function
    Public Function inserOrdenamientoConsumo(ByVal c As Consumo) As DataTable
        Dim obj As New ConsumosDA
        Return obj.inserOrdenamientoConsumo(c)
    End Function
    Public Function inserOrdenamientoFracion(ByVal f As Fracciones) As DataTable
        Dim obj As New ConsumosDA
        Return obj.inserOrdenamientoFracion(f)
    End Function

    Public Function EliminarFraccionOri(ByVal FO As Integer, ByVal FracNueva As Integer, ByVal accion As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.EliminarFraccionOri(FO, FracNueva, accion)
    End Function

    Public Function ActualizarConsumosNaveProduccion(ByVal pXmlMateriales As String, ByVal pIdProductoEstilo As Integer, ByVal pIdUsuario As Integer, ByVal pNaveId As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.ActualizaConsumosNaveProduccion(pXmlMateriales, pIdProductoEstilo, pIdUsuario, pNaveId)
    End Function

    Public Function ConsultarConsumosProduccion(ByVal pNaveId As Integer, ByVal pMarca As Integer, ByVal pColeccion As Integer, ByVal pEstatus As String) As DataTable
        Dim obj As New ConsumosDA
        Return obj.ConsultaConsumosProduccion(pNaveId, pMarca, pColeccion, pEstatus)
    End Function

    Public Function ConsultarConsumosNoDesarrollo(ByVal pNaveId As Integer, ByVal pEstatus As String, ByVal pMarca As Integer, ByVal pColeccion As Integer, ByVal pTipoNave As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.ConsultaConsumosNoDesarrollo(pNaveId, pEstatus, pMarca, pColeccion, pTipoNave)
    End Function

    Public Function ConsultarConsumosAsignados(ByVal pNaveId As Integer, ByVal pEstatus As String, ByVal pMarca As Integer, ByVal pColeccion As Integer, ByVal pTipoNave As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.ConsultaConsumosAsignados(pNaveId, pEstatus, pMarca, pColeccion, pTipoNave)
    End Function

    Public Function listadoProductosNave(ByVal UsuarioID As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.listadoProductosNave(UsuarioID)
    End Function

    Public Function listadoPermisosPorUsuario(ByVal var_ClaveAccion As String, ByVal var_ClaveModulo As String, ByVal var_Nave As Integer, ByVal var_Usuario As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.listadoPermisosPorUsuarioNave(var_ClaveAccion, var_ClaveModulo, var_Nave, var_Usuario)
    End Function

    Public Function ConsultaFraccionesDEsarrolloProductoEstilo(ByVal productoEstilo As Integer, ByVal idNaveDesarrolla As Integer) As Integer
        Dim obj As New ConsumosDA
        Dim tbl As New DataTable
        Dim TotalFracciones As Integer = 0
        tbl = obj.ConsultaFraccionesDEsarrolloProductoEstilo(productoEstilo, idNaveDesarrolla)
        If tbl.Rows.Count > 0 Then
            TotalFracciones = tbl.Rows(0).Item("TotalFracciones")
        End If
        Return TotalFracciones
    End Function

    Public Function ConsultaModeloproductoEstiloId(ByVal productoEstilo As Integer)
        Dim obj As New ConsumosDA
        Return obj.ConsultaModeloproductoEstiloId(productoEstilo)
    End Function

    Public Function BaseDatosConsumos(idNave As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.BaseDatosConsumos(idNave)
    End Function

    Public Function BaseDatosConsumosDesarrollo(idNave As Integer, estatus As String, marca As Integer, coleccion As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.BaseDatosConsumosDesarrollo(idNave, estatus, marca, coleccion)
    End Function
End Class


