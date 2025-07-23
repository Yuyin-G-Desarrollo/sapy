Imports System.Data.SqlClient

Public Class ProductosDA
    'Clase con todos los metodos relacionados al producto para pedidos web

    ''función que recupera la lista de las colecciones dependiendo de la lista de precios, la marca y la descripción
    Public Function recuperarColeccionesPorMarcaDescripcion(ByVal idListaPrecio As Int32, ByVal idmarca As Int32, ByVal descripcion As String, ByVal idAgente As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametros.ParameterName = "idListaPrecio"
        parametros.Value = idListaPrecio.ToString
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "idMarca"
        parametros.Value = idmarca.ToString
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "descripcion"
        parametros.Value = descripcion
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "idAgente"
        parametros.Value = idAgente
        listaParametros.Add(parametros)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Recuperar_ColeccionesPor_LP_Marca", listaParametros)
    End Function

    'funcion para recuperar la lista de productos por modelo dependiento del tipo de busqueda
    Public Function recuperarProductosConsultaPorLPPorModelo(ByVal tipoConsulta As Int32, ByVal idListaPrecio As Int32, ByVal idcliente As Int32, ByVal idModeloSay As String, ByVal idModeloSicy As String, ByVal idAgente As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "tipoConsulta"
        parametro.Value = tipoConsulta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idlistaPrecio"
        parametro.Value = idListaPrecio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ModeloSicy"
        parametro.Value = idModeloSicy
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "ModeloSay"
        parametro.Value = idModeloSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCliente"
        parametro.Value = idcliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idAgente"
        parametro.Value = idAgente
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consulta_Productos_PorLP_PorModelo", listaParametros)
    End Function

    ''funcion para recuperar las listas de precio de un cliente
    Public Function recuperarListasPreciosCliente(ByVal idCliente As Int32) As DataTable
        Dim consulta As String = String.Empty
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        consulta = <consulta>
                     SELECT idListaVentas, idListaVentasClientePrecio, idListaBase, ListaBase, (ListaPrecioCliente +' - ' +ListaBase) as ListaPrecioCliente, 'Vigente del '+convert(varchar(10), InicioVigencia , 103)+' al ' +convert(varchar(10), FinVigencia , 103) as vigencia
                        ,convert(varchar(10), InicioVigencia , 103) inicioVigencia, convert(varchar(10), FinVigencia , 103) finVigencia 
						 FROM Ventas.vListaPrecioCliente WHERE IdSAY= <%= idCliente.ToString %> ORDER BY ListaBase
                   </consulta>.Value
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    '' funcion para recuperar el modelo original en la consulta de productos.
    Public Function recuperarModeloOriginalProductos(ByVal idListaPrecio As Int32, ByVal modeloSay As String, ByVal modeloSicy As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idListaPrecio"
        parametro.Value = idListaPrecio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modeloSay"
        parametro.Value = modeloSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modeloSicy"
        parametro.Value = modeloSicy
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consultar_ModeloOriginal", listaParametros)
    End Function

    ' funcion para recuperar la consulta de modelos con el filtro de coleccioin completa pedidos web
    Public Function recuperarConsultaProductosColeccionCompleta(ByVal tipoConsulta As Int32, ByVal idListaPrecio As Int32, ByVal idMarcas As String, ByVal modeloSay As String, ByVal modeloSicy As String, ByVal idAgente As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "tipoConsulta"
        parametro.Value = tipoConsulta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idListaPrecio"
        parametro.Value = idListaPrecio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idMarcas"
        parametro.Value = idMarcas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modeloSay"
        parametro.Value = modeloSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modeloSicy"
        parametro.Value = modeloSicy
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idAgente"
        parametro.Value = idAgente
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consulta_ModelosPorColeccion", listaParametros)
    End Function

    'funcion para recuperar la lista de productos consultados por modelo sustituto
    Public Function recuperarConsultaProductosModeloSustituto(ByVal tipoConsulta As Int32, ByVal idListaPrecio As Int32, ByVal modeloSay As String, ByVal modeloSicy As String, ByVal idCliente As Int32, ByVal idAgente As Int32) As DataTable
        Dim objPeristencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametro As New List(Of SqlParameter)

        parametro.ParameterName = "tipoConsulta"
        parametro.Value = tipoConsulta
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idListaPrecio"
        parametro.Value = idListaPrecio
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modeloSay"
        parametro.Value = modeloSay
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modeloSicy"
        parametro.Value = modeloSicy
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCliente"
        parametro.Value = idcliente
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idAgente"
        parametro.Value = idAgente
        listaParametro.Add(parametro)

        Return objPeristencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consulta_Modelos_Sustitutos", listaParametro)
    End Function

    ''funcion que recupera la consulta de los productos por marca o coleccion
    Public Function recuperarConsultaProductosMarcaColeccion(ByVal idLista As Int32, ByVal idMarcas As String, ByVal idColeccion As String, ByVal coleccion As String, ByVal idAgente As Int32) As DataTable
        Dim objPeristencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametro As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "idListaPrecio"
        parametro.Value = idLista
        listaParametro.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "idmarcas"
        parametro.Value = idMarcas
        listaParametro.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "idColeccion"
        parametro.Value = idColeccion
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coleccion"
        parametro.Value = coleccion
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idAgente"
        parametro.Value = idAgente
        listaParametro.Add(parametro)

        Return objPeristencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consulta_Productos_PorMarcaColeccion", listaParametro)
    End Function

    ''funcion para recuperar tecs del rfc seleccionado en el pedido 
    Public Function recuperarTECRfcPedido(ByVal idClienteRfc As Int32) As DataTable
        Dim consulta As String = String.Empty
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        'consulta = <consulta>
        '              select distinct  tec.tiec_tiendaembarquecedisid,rt.rtec_clienterfc_id,tec.tiec_clienteid,p.pers_nombre as NombreTEC
        '                from Cliente.TiendaEmbarqueCEDIS tec
        '                inner join Cliente.RFC_TiendaEmbarqueCEDIS rt on tec.tiec_clienterfcid=rt.rtec_clienterfc_id
        '                inner join Framework.Persona p on p.pers_personaid=tec.tiec_personaid
        '                where rt.rtec_clienterfc_id= <%= idClienteRfc.ToString %> and rt.rtec_activo=1 and tec.tiec_activo=1
        '                order by p.pers_nombre asc
        '          </consulta>.Value

        Dim parametro As New SqlParameter
        Dim listaParametro As New List(Of SqlParameter)

        parametro.ParameterName = "idClienteRfc"
        parametro.Value = idClienteRfc
        listaParametro.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_RecuperarTEC_RFC", listaParametro)
    End Function

    'funcion para recuperar tallas de EU, USA de una talla Mx
    Public Function recuperarTallasRelacionadasMx(ByVal idTalla As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idTalla"
        parametro.Value = idTalla
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consulta_TallasRelacionadasMx", listaParametros)

    End Function

    'funcion para calcular la cantidad de docenas normales
    Public Function calcularDocenasNormalesTalla(ByVal cantidad As Int32, ByVal idTalla As Int32, ByVal pedidoDetalleId As Int32,
                                                 ByVal usuarioCreo As Int32, ByVal ClienteId As Int32, ByVal ProductoEstiloId As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "cantidadTotal"
        parametro.Value = cantidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idTalla"
        parametro.Value = idTalla
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidoDetalleId"
        parametro.Value = pedidoDetalleId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioCreo"
        parametro.Value = usuarioCreo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClienteId"
        parametro.Value = ClienteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProductoEstiloId"
        parametro.Value = ProductoEstiloId
        listaParametros.Add(parametro)


        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Calculo_Docena_Normal", listaParametros)
    End Function

    'funcion para recuperar la ruta del pdf de etiquetas especiales del cliente
    Public Function recuperarRutaPdfEtiquetaEspecial(ByVal idCliente As Int32) As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        consulta = <consulta>
                        select ISNULL( ivcl_rutafichatecnicaetiquetado ,'') as ruta from Ventas.InfoCliente WHERE ivcl_infoclienteid=<%= idCliente.ToString %>
                   </consulta>.Value
        Return persistencia.EjecutaConsulta(consulta)
    End Function

    'funcion para validar nuemero de tiendas de un rfc
    Public Function validarNumeroTiendasRfc(ByVal idClienteRfc As Int32) As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        'consulta = <consulta>
        '             select COUNT ( DISTINCT rt.rtec_tiendaembarquecedisid) as totalTiendas
        '                from Cliente.ClienteRFC cf 
        '               inner join Cliente.RFC_TiendaEmbarqueCEDIS rt on rt.rtec_clienterfc_id=cf.crfc_clienterfcid
        '                INNER JOIN Cliente.TiendaEmbarqueCEDIS tec on tec.tiec_clienterfcid=rt.rtec_clienterfc_id
        'where rt.rtec_clienterfc_id=<%= idClienteRfc.ToString %>  and rt.rtec_activo=1 and cf.crfc_activo=1
        '         </consulta>
        consulta = <consulta>
                     select COUNT ( DISTINCT rt.rtec_tiendaembarquecedisid) as totalTiendas
						from Cliente.TiendaEmbarqueCEDIS tec 
						INNER JOIN Cliente.ClienteRFC crfc ON crfc.crfc_clienteid=tec.tiec_clienteid 
                        INNER join Cliente.RFC_TiendaEmbarqueCEDIS rt on crfc.crfc_clienterfcid=rt.rtec_clienterfc_id and rt.rtec_tiendaembarquecedisid=tec.tiec_tiendaembarquecedisid
                        inner join Framework.Persona p on p.pers_personaid=tec.tiec_personaid
						INNER JOIN Embarque.TiendaEmbCEDISMensajeria tecm on tec.tiec_tiendaembarquecedisid=tecm.tecm_tiendaembarquecedisid
						inner JOIN Embarque.CostoDestinoMensajeria cdm on cdm.codm_costodestinomensajeriaid=tecm_costodestinomensajeriaid
						inner join embarque.DestinoMensajeria dm on dm.deme_destinomensajeriaid=cdm.codm_destinomensajeriaid
						inner join Proveedor.Proveedor pr on dm.deme_proveedorid=pr.prov_proveedorid
						LEFT JOIN Framework.Domicilio d on d.domi_personaid=p.pers_personaid
						LEFT JOIN Framework.Poblaciones pob ON pob.pobl_poblacionid= dm.deme_poblacionid
						LEFT JOIN Framework.Ciudades ciu on ciu.city_ciudadid=dm.deme_ciudadid
                        where rt.rtec_clienterfc_id= <%= idClienteRfc.ToString %> and rt.rtec_activo=1 and tec.tiec_activo=1
						AND tecm_prioridad in (	SELECT TOP 1 tec2.tecm_prioridad FROM Embarque.TiendaEmbCEDISMensajeria tec2
						INNER JOIN Embarque.CostoDestinoMensajeria cd2 on tec2.tecm_costodestinomensajeriaid= cd2.codm_costodestinomensajeriaid
						WHERE tec2.tecm_tiendaembarquecedisid =tec.tiec_tiendaembarquecedisid  AND cd2.codm_activo= 1 AND tec2.tecm_activo=1 ORDER BY tec2.tecm_prioridad)
						  

                        and cdm.codm_activo=1 and dm.deme_activo=1 and pr.prov_activo=1
                 </consulta>
        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''funcion para recuperar tecs del rfc seleccionado nombre simple
    Public Function recuperarTECRfcPedidoTecs(ByVal idClienteRfc As Int32) As DataTable
        Dim consulta As String = String.Empty
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim parametro As New SqlParameter
        Dim listaParametro As New List(Of SqlParameter)

        parametro.ParameterName = "idClienteRfc"
        parametro.Value = idClienteRfc
        listaParametro.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_RecuperarTEC_RFC_Tecs", listaParametro)
    End Function
End Class
