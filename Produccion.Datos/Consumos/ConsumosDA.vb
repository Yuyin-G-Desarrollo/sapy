
Imports System.Data.SqlClient
Imports Entidades

Public Class ConsumosDA
    Public Function getObservacionesFracciones(ByVal cadena As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>                        
           select UPPER(observacionFraccion) 'observacionFraccion' from Produccion.ObservacionesFracciones
            where observacionFraccion LIKE '%<%= cadena %>%'
            order by observacionFraccion
            </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function getMaterialesAutorizadosProduccionArticulo(ByVal ProductoEstilo As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>                        
                SELECT cd.code_productoestiloid, mnv.mn_materialNaveid, cd.code_proveedorid, cd.code_umproveedorid, cd.code_umproduccionid, cd. code_preciocompra, cd.code_precioumproduccion, mnv.mn_materialid
                from Produccion.ConsumosDesarrollo cd inner join Materiales.MaterialesNave mnv
                on cd.code_materialid=mnv.mn_materialNaveid
                inner join Materiales.Materiales m on m.mate_materialid= mnv.mn_materialid
                where cd.code_productoestiloid =<%= ProductoEstilo.ToString %>
                and cd.code_activo =1
                and m.mate_tipodematerial =1
                and m.mate_autorizado = 'P'
            </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function getMaterialPrecioProveedorNave(ByVal MAterialID As Integer, ByVal NAveID As Integer, ByVal ProveedorID As Integer, ByVal Precio As Double) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>                        
               
                SELECT mnv.mn_materialNaveid, mnv.mn_materialid , mp.prma_provedorid, mp.prma_dageproveedorid, mp.prma_preciounitario, mp.prma_equivalencia, mp.prma_monedaid, mp.prma_idumproveedor, mp.prma_idumproduccion
                from Materiales.MaterialesNave mnv left join Materiales.MaterialesPrecio mp
                on mnv.mn_materialNaveid = mp.prma_idMaterialNave
                where mnv.mn_materialid='<%= MAterialID.ToString %>'
                and mnv.mn_idNave ='<%= NAveID.ToString %>'
                and mp.prma_provedorid='<%= ProveedorID.ToString %>'
                and mp.prma_preciounitario ='<%= Precio.ToString %>'
                and mp.prma_activo =1
            </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function getMaterialPrecio(ByVal MAterialNaveID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>                        
                 SELECT prma_idMaterialNave, prma_preciounitario, prma_idnave, prma_dageproveedorid, prma_provedorid, prma_equivalencia, prma_monedaid, prma_idumproveedor, prma_idumproduccion, prma_navedesarrollaid
                from Materiales.MaterialesPrecio
                where prma_idMaterialNave ='<%= MAterialNaveID.ToString %>'
                and prma_activo =1
                
            </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function getMaterialNaveID(ByVal MAterialID As Integer, ByVal NAveID As Integer) As Integer
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>                        
               
               SELECT mn_materialNaveid
                from Materiales.MaterialesNave
                where mn_materialid ='<%= MAterialID.ToString %>'
                and mn_idNave ='<%= NAveID.ToString %>'
            </cadena>
        Return operacion.EjecutaConsultaEscalar(consulta)
    End Function

    Public Function getExistePrecioMaterialNaveProveedor(ByVal MAterialNAveID As Integer, ByVal ProveedorID As Integer, ByVal Precio As Double) As Integer
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>                                       
                    SELECT COUNT(*)
                    from Materiales.MaterialesPrecio
                    where prma_idMaterialNave='<%= MAterialNAveID.ToString %>'
                    and prma_provedorid ='<%= ProveedorID.ToString %>'
                    and prma_preciounitario ='<%= Precio.ToString %>'
                    and prma_activo =1
            </cadena>
        Return operacion.EjecutaConsultaEscalar(consulta)
    End Function

    Public Function getNaveDesarrolla(ByVal productoEstiloId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>                        
           select nave_nombre 'nave' from Programacion.ProductoEstilo join Framework.Naves on nave_naveid=pres_navedesarrollaid 
            </cadena>
        consulta += " where pres_productoestiloid=" & productoEstiloId & " "
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function EsNaveDesarrolla(ByVal NaveID As Integer) As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>                        
                SELECT nave_desarrolla
                from Framework.Naves
                where nave_naveid =
            </cadena>
        consulta += " " + NaveID.ToString
        Return operacion.EjecutaConsultaEscalar(consulta)
    End Function

    Public Function getNaveDesarrollaID(ByVal productoEstiloId As Integer) As String
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "select isnull(pres_navedesarrollaid,-1) "
        consulta += "from Programacion.ProductoEstilo "
        consulta += "where pres_productoestiloid ='" + productoEstiloId.ToString + "' "

        Return operacion.EjecutaConsultaEscalar(consulta)
    End Function

    Public Function getconsumosProdExcel(ByVal productoEstiloId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>                        
            select 
            ---CASE cd.code_bloqueado WHEN 'true' THEN 1 else 0 end 'Bloqueado',
            CASE cd.copr_explosionar  WHEN 'true' THEN 1 else 0 end 'Explosionar',
            CASE cd.copr_lotear  WHEN 'true' THEN 1 else 0 end 'Lotear',
            c.comp_componenteid 'Componente',m.mate_sku 'SKU',cd.copr_consumo 'Consumo',  p.prov_proveedorid 'Proveedor'
            from Materiales.Materiales m inner join Materiales.MaterialesNave mn on 
			mn.mn_materialid=m.mate_materialid inner join Produccion.ConsumosProduccion cd ON	
            cd.copr_materialid=mn.mn_materialNaveid inner join Produccion.Componentes c on 
            cd.copr_componenteid=c.comp_componenteid inner join Materiales.Clasificaciones cl ON
            cl.clas_idclasificacion=cd.copr_clasificacionid inner join Materiales.UnidadDeMedida um1 ON
            um1.unme_idunidad=cd.copr_umproveedorid left join Materiales.UnidadDeMedida um2 ON
            um2.unme_idunidad=cd.copr_umproduccionid left join Proveedor.Proveedor p ON
            p.prov_proveedorid=cd.copr_proveedorid inner join Programacion.ProductoEstilo pe ON
            pe.pres_productoestiloid=cd.copr_productoestiloid
            </cadena>
        consulta += " where pe.pres_productoestiloid=" & productoEstiloId & " and cd.code_activo=1"
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function getconsumosDesExcel(ByVal productoEstiloId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>                        
            select 
            ---CASE cd.code_bloqueado WHEN 'true' THEN 1 else 0 end 'Bloqueado',
            CASE cd.code_explosionar  WHEN 'true' THEN 1 else 0 end 'Explosionar',
            CASE cd.code_lotear  WHEN 'true' THEN 1 else 0 end 'Lotear',
            c.comp_componenteid 'Componente',m.mate_sku 'SKU', cd.code_consumo 'Consumo',p.prov_proveedorid 'Proveedor'
            from Materiales.Materiales m inner join Materiales.MaterialesNave mn on 
			mn.mn_materialid=m.mate_materialid inner join Produccion.ConsumosDesarrollo cd ON	
            cd.code_materialid=mn.mn_materialNaveid inner join Produccion.Componentes c on 
            cd.code_componenteid=c.comp_componenteid inner join Materiales.Clasificaciones cl ON
            cl.clas_idclasificacion=cd.code_clasificacionid inner join Materiales.UnidadDeMedida um1 ON
            um1.unme_idunidad=cd.code_umproveedorid left join Materiales.UnidadDeMedida um2 ON
            um2.unme_idunidad=cd.code_umproduccionid left join Proveedor.Proveedor p ON
            p.prov_proveedorid=cd.code_proveedorid inner join Programacion.ProductoEstilo pe ON
            pe.pres_productoestiloid=cd.code_productoestiloid
            </cadena>
        consulta += " where pe.pres_productoestiloid=" & productoEstiloId & " and cd.code_activo=1"
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function getNavesProduccion(ByVal productoEstiloId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select pena_naveid from Produccion.ProductoNaveProduccion where pena_productoestiloid=353
        </cadena>
        consulta += " where pena_productoestiloid=" & productoEstiloId
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getNavesAfectadas(ByVal productoEstiloId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " select STUFF(" +
        " (SELECT CAST(',' AS varchar(MAX)) + nave_nombre" +
        " FROM Produccion.ProductoNaveProduccion join Framework.Naves on nave_naveid=pena_naveid" +
        " where pena_productoestiloid = " & productoEstiloId & "" +
        " ORDER BY nave_nombre" +
        " FOR XML PATH('')" +
        " ), 1, 1, '') as Naves"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ObtenerTotalConsumoDesarrollo(ByVal productoEstiloId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@ProductoEstiloId"
        parametro.Value = productoEstiloId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_ObtieneConsumosDesarrolloTotal]", listaParametros)

    End Function
    Public Function ObtenerTotalConsumoProduccion(ByVal productoEstiloId As Integer, ByVal idNave As Integer, ByVal MostrarConsumoInactivo As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@ProductoEstiloId"
        parametro.Value = productoEstiloId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MostrarConsumoInactivo"
        parametro.Value = MostrarConsumoInactivo
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_ObtieneTotalConsumosProduccion]", listaParametros)

    End Function

    Public Function validarNave(ByVal productoEstiloId As Integer, ByVal idNave As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@ProductoEstiloId"
        parametro.Value = productoEstiloId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        'Dim consulta As String =
        '<cadena>
        '    select pres_navedesarrollaid from Programacion.ProductoEstilo 
        '</cadena>
        'consulta += " where pres_productoestiloid=" & productoEstiloId

        'Return operaciones.EjecutaConsulta(consulta)
        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_ValidarNaveCostoConsumo]", listaParametros)
    End Function
    Public Function getDatosProducto(ByVal productoEstiloId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            SELECT pe.pres_productoid,ep.espr_estiloproductoid ,pr.prod_codigo 'Código',
            m.marc_descripcion 'Marca', c.cole_descripcion 'Colección',temp_nombre 'Temporada',
            pr.prod_codcliente 'CodigoCliente',
            horma_descripcion 'Horma','' 'Suela',pl.piel_descripcion+' '+cc.color_descripcion 'PielColor',
            isnull(isnull(cliDos.clie_nombregenerico,clUno.clie_nombregenerico),'') Cliente,isnull(cliDos.clie_clienteid,clUno.clie_clienteid) idCliente,
			tt.talla_descripcion 'Corrida',isnull(pe.pres_imagen,'') 'Imagen',isnull(pe.pres_navedesarrollaid,0) 'idNave',pe.pres_productoid 'idProducto',
			pe.pres_estiloid 'idEstiloProd',u.user_nombrereal 'usuario',pe.pres_fechacreacion 'FechaCreacion',ISNULL(pe.pres_suela,'') 'suela',ISNULL(pe.pres_caja,'') 'caja',ISNULL(pe.pres_marcaNorma,'') 'Norma',isnull(vig.viar_FechaVigenciaNueva,'')FechaVigencia
			FROM Programacion.Productos AS pr 
			INNER JOIN Programacion.ProductoEstilo AS pe oN pr.prod_productoid = pe.pres_productoid
            LEFT JOIN Programacion.TBL_Programacion_VigenciaArticulos vig ON vig.viar_ProductoEstiloID=pe.pres_productoestiloid
            INNER JOIN Programacion.EstilosProducto AS ep ON pe.pres_estiloid = ep.espr_estiloproductoid
            INNER JOIN Programacion.Pieles AS pl ON ep.espr_pielid = pl.piel_pielid
            INNER JOIN Programacion.Tallas AS tt ON ep.espr_tallaid = tt.talla_tallaid
            INNER JOIN Programacion.Colores AS cc ON ep.espr_colorid = cc.color_colorid
            INNER JOIN Programacion.PielMuestras AS pm ON ep.espr_pielmuestraid = pm.plmu_pielmuestraid
            INNER JOIN Programacion.Forros AS ff ON ep.espr_forroid = ff.forr_forroid
            left join Programacion.Colecciones as c on c.cole_coleccionid=pr.prod_coleccionid
            left join Programacion.Marcas as m on m.marc_marcaid=pr.prod_marcaid
            INNER JOIN Programacion.EstatusProducto st ON pe.pres_estatus = st.stpr_productoStatusId
			left join Programacion.ColeccionMarca cm on cm.coma_coleccionid=c.cole_coleccionid and  cm.coma_marcaid=m.marc_marcaid
			left join Cliente.Cliente clUno on clUno.clie_clienteid=pr.prod_clienteid  
			left join Cliente.Cliente cliDos on cliDos.clie_clienteid=cm.coma_clienteid              
			left join Programacion.Hormas on pe.pres_horma=horma_hormaid
			left join Programacion.Temporadas on temp_temporadaid=pr.prod_temporadaid   
            left join Framework.Usuarios u on pe.pres_usuariocreoid=u.user_usuarioid             
			where  pl.piel_activo = 1 AND tt.talla_activo = 1 AND cc.color_activo = 1 AND pm.plmu_activo = 1 AND ff.forr_activo = 1 and pe.pres_activo=1
            </cadena>
        consulta += " and pe.pres_productoestiloid=" & productoEstiloId & ""
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getNaveSIcy(ByVal idNave As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
           select nave_navesicyid from Framework.Naves where nave_naveid=
            </cadena>
        consulta += " " & idNave & " "
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return Convert.ToInt32(datos.Rows(0).Item(0).ToString)
        End If
        Return 0
    End Function
    Public Function actualizarProductos(ByVal idNave As Integer, ByVal idProducto As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "update Programacion.ProductoEstilo set pres_navedesarrollaid=" & idNave & ",pres_estatusdesarrollo='D' where pres_productoestiloid=" & idProducto & ""

        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getMarcas(ByVal idNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                 select DISTINCT (marc_descripcion) Marca,marc_marcaid IdMarca from Programacion.Marcas
            join Programacion.Productos on marc_marcaid=prod_marcaid
            join Programacion.ProductoEstilo on pres_productoid=prod_productoid
            </cadena>
        consulta += " where pres_navedesarrollaid=" & idNave & " order by marc_descripcion"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getColecciones(ByVal idMarca As Integer, ByVal idNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                 select DISTINCT cole_descripcion,cole_coleccionid from Programacion.Colecciones
                 left join Programacion.ColeccionMarca on cole_coleccionid=coma_coleccionid
				 join Programacion.Productos on cole_coleccionid=prod_coleccionid
                join Programacion.ProductoEstilo on pres_productoid=prod_productoid
            </cadena>
        If idMarca > 0 Then
            consulta += " where coma_marcaid=" & idMarca & " and pres_navedesarrollaid=" & idNave & " order by cole_descripcion"
        End If
        Return operaciones.EjecutaConsulta(consulta)
    End Function



    Public Function listaComponentes() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                 select * from Produccion.Componentes
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function listadoProductosSinNave(ByVal idColecc As Integer, ByVal idNave As Integer, ByVal idmarca As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = 
        '    '<cadena>
        '         SELECT  pe.pres_productoestiloid productoEstiloId,pe.pres_productoid,ep.espr_estiloproductoid ,'' Imagen,pe.pres_imagen 'Ruta',pe.pres_codSicy 'Código',
        '         m.marc_marcaid idMarca,m.marc_descripcion 'Marca',c.cole_coleccionid idColeccion,c.cole_descripcion 'Colección',
        '         pr.prod_codigo 'Modelo',pl.piel_pielid idPiel ,pl.piel_descripcion+' '+cc.color_descripcion 'Piel Color',cc.color_colorid idColor, 
        '         tt.talla_tallaid idTalla,tt.talla_descripcion 'Corrida',
        'h.horma_descripcion 'Horma',t.temp_nombre 'Temporada',
        '         isnull(cliDos.clie_nombregenerico,clUno.clie_nombregenerico) Cliente,isnull(cliDos.clie_clienteid,clUno.clie_clienteid) idCliente FROM Programacion.Productos AS pr 
        'INNER JOIN Programacion.ProductoEstilo AS pe oN pr.prod_productoid = pe.pres_productoid
        '         INNER JOIN Programacion.EstilosProducto AS ep ON pe.pres_estiloid = ep.espr_estiloproductoid
        '         INNER JOIN Programacion.Pieles AS pl ON ep.espr_pielid = pl.piel_pielid
        '         LEFT JOIN Programacion.Familias AS fa ON pe.pres_familiaid = fa.fami_familiaid
        '         INNER JOIN Programacion.Tallas AS tt ON ep.espr_tallaid = tt.talla_tallaid
        '         INNER JOIN Programacion.Colores AS cc ON ep.espr_colorid = cc.color_colorid
        '         INNER JOIN Programacion.PielMuestras AS pm ON ep.espr_pielmuestraid = pm.plmu_pielmuestraid
        '         INNER JOIN Programacion.Forros AS ff ON ep.espr_forroid = ff.forr_forroid
        'left join Programacion.Hormas h on h.horma_hormaid=pe.pres_horma
        '         left join Programacion.Colecciones as c on c.cole_coleccionid=pr.prod_coleccionid
        '         left join Programacion.Marcas as m on m.marc_marcaid=pr.prod_marcaid
        '         left join Programacion.Colecciones as cl on cl.cole_coleccionid=pr.prod_coleccionid
        'left join Programacion.Temporadas t on t.temp_temporadaid=pr.prod_temporadaid
        '         INNER JOIN Programacion.EstatusProducto st ON pe.pres_estatus = st.stpr_productoStatusId
        'left join Programacion.ColeccionMarca cm on cm.coma_coleccionid=c.cole_coleccionid and  cm.coma_marcaid=m.marc_marcaid
        'left join Cliente.Cliente clUno on clUno.clie_clienteid=pr.prod_clienteid  
        'left join Cliente.Cliente cliDos on cliDos.clie_clienteid=pr.prod_clienteid             
        'where            
        '     </cadena>
        '     consulta += " pe.pres_navedesarrollaid=" & idNave
        '     If idMarca > 0 Then
        '         consulta += " and m.marc_marcaid=" & idMarca & " "
        '     End If
        '     If idColecc > 0 Then
        '         consulta += " and c.cole_coleccionid=" & idColecc & " "
        '     End If
        '     consulta += " AND pl.piel_activo = 1 AND tt.talla_activo = 1 AND cc.color_activo = 1 AND pm.plmu_activo = 1 AND ff.forr_activo = 1 and pe.pres_activo=1 and pe.pres_totalconsumos is null "
        '     consulta += " order by Colección, Modelo, Corrida"
        '    Dim consulta As String =
        '    <cadena>
        '         select DISTINCT 0 " ",
        '            ' ' 'Estatus',pe.pres_imagen 'Ruta',' ' 'Imagen',m.marc_descripcion 'Marca',
        '            status= case pe.pres_estatusdesarrollo  when 'D' then 'DESARROLLO'  when 'AD' then 'AUTORIZADO DESARROLLO'
        'when 'AP' then 'AUTORIZADO PRODUCCIÓN'  when 'I' then 'INACTIVO NAVE'  when 'DP' then 'DESCONTINUADO' end,
        '            pe.pres_codSicy 'Código',pe.pres_productoestiloid 'EstiloID',prod.prod_descripcion 'Colección',
        'prod.prod_codigo 'Modelo',p.piel_descripcion 'Piel',c.color_descripcion 'Color','' 'Piel Color',
        't.talla_descripcion 'Corrida',pe.pres_totalconsumos 'Total Materiales',pe.pres_totalfracciones 'Total Fracciones',

        '            ISNULL( STUFF((SELECT CAST(',' AS varchar(MAX)) + nave_nombre
        '         from Produccion.ProductoNaveProduccion 
        '   left join Framework.Naves on nave_naveid=pena_naveid
        '   where pena_productoestiloid = pe.pres_productoestiloid and pena_estatus='AD' or pena_estatus='AP'
        '         FOR XML PATH('')), 1, 1, ''),'') as 'Asignado a Producción',

        'cl.clie_razonsocial 'Cliente'
        '            from Programacion.ProductoEstilo as pe
        '            left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid
        '            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '            left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
        '            left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
        '            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        '            left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
        '            left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
        'left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
        '            left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
        '   </cadena>


        'Dim consulta As String =
        '    <consulta>
        '        select
        '        pe.pres_productoestiloid productoEstiloId,pe.pres_productoid,ep.espr_estiloproductoid ,
        '        '' Imagen,pe.pres_imagen 'Ruta',pe.pres_codSicy 'Código',m.marc_marcaid idMarca,m.marc_descripcion 'Marca',
        '        col.cole_coleccionid idColeccion,col.cole_descripcion 'Colección',prod.prod_codigo 'Modelo',prod.prod_modelo 'Modelo SICY',p.piel_pielid idPiel ,
        '        p.piel_descripcion+' '+c.color_descripcion 'Piel Color',c.color_colorid idColor, t.talla_tallaid idTalla,
        '        t.talla_descripcion 'Corrida',h.horma_descripcion 'Horma',temp.temp_nombre 'Temporada',
        '        isnull(cliDos.clie_nombregenerico,clUno.clie_nombregenerico) Cliente,
        '        isnull(cliDos.clie_clienteid,clUno.clie_clienteid) idCliente 
        '        from Programacion.ProductoEstilo as pe
        '        left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid
        '        left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '        left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
        '        left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
        '        left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        '        left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
        '        left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
        '        left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
        '        left join Programacion.Temporadas temp on temp.temp_temporadaid=prod.prod_temporadaid
        '        left join Programacion.Colecciones as col on col.cole_coleccionid=prod.prod_coleccionid
        '        left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
        '        left join Programacion.Hormas h on h.horma_hormaid=pe.pres_horma
        '        left join Cliente.Cliente clUno on clUno.clie_clienteid=prod.prod_clienteid  
        '        left join Cliente.Cliente cliDos on cliDos.clie_clienteid=prod.prod_clienteid 
        '    </consulta>
        'consulta += " where (pe.pres_estatus in (3,4) and pe.pres_activo=1)"
        'If idmarca <> 0 Then
        '    consulta += " AND prod.prod_marcaid=" + idmarca.ToString
        'End If
        'If idColecc <> 0 Then
        '    consulta += " AND prod.prod_coleccionid=" + idColecc.ToString
        'End If
        'consulta += " and (pe.pres_totalconsumos is null or pe.pres_totalconsumos=0)"
        'Return operacion.EjecutaConsulta(consulta)


        '    Dim consulta As String =
        '       <consulta>
        '             select
        '            pe.pres_productoestiloid productoEstiloId,pe.pres_productoid,ep.espr_estiloproductoid ,
        '            '' Imagen,pe.pres_imagen 'Ruta',pe.pres_codSicy 'Código',m.marc_marcaid idMarca,m.marc_descripcion 'Marca',
        '            col.cole_coleccionid idColeccion,col.cole_descripcion 'Colección',prod.prod_codigo 'Modelo',prod.prod_modelo 'Modelo SICY',p.piel_pielid idPiel ,
        '            p.piel_descripcion+' '+c.color_descripcion 'Piel Color',c.color_colorid idColor, t.talla_tallaid idTalla,
        '            t.talla_descripcion 'Corrida',h.horma_descripcion 'Horma',temp.temp_nombre 'Temporada',
        '            isnull(cliDos.clie_nombregenerico,clUno.clie_nombregenerico) Cliente,
        '            isnull(cliDos.clie_clienteid,clUno.clie_clienteid) idCliente 
        '            from Programacion.ProductoEstilo as pe
        '            left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid
        '            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '            left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
        '            left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
        '            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        '            left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
        '            left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
        '            left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
        '            left join Programacion.Temporadas temp on temp.temp_temporadaid=prod.prod_temporadaid
        '            left join Programacion.Colecciones as col on col.cole_coleccionid=prod.prod_coleccionid
        '            left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
        '            left join Programacion.Hormas h on h.horma_hormaid=pe.pres_horma
        '            left join Cliente.Cliente clUno on clUno.clie_clienteid=prod.prod_clienteid  
        '            left join Cliente.Cliente cliDos on cliDos.clie_clienteid=prod.prod_clienteid 
        'left join Produccion.HistorialProductoEstilo hpe    on hpe.hipe_productoestiloid = pe.pres_productoestiloid   
        '        </consulta>
        '    consulta += " where (pe.pres_estatus in (3,4) and pe.pres_activo=1) and prod.prod_activo =1 "
        '    'consulta += " where (pe.pres_activo=1) and prod.prod_activo =1 " 'T20208
        '    If idmarca <> 0 Then
        '        consulta += " AND prod.prod_marcaid=" + idmarca.ToString
        '    End If
        '    If idColecc <> 0 Then
        '        consulta += " AND prod.prod_coleccionid=" + idColecc.ToString
        '    End If
        '    consulta += " and hpe.hipe_estatusa is NULL and pe.pres_navedesarrollaid = " + idNave.ToString + " "
        '    Return operacion.EjecutaConsulta(consulta)


        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveSAYID"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@marca"
        parametro.Value = idmarca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ColeccionId"
        parametro.Value = idColecc
        listaParametros.Add(parametro)




        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_ConsumosNave_ListadoProductosSinNave]", listaParametros)




    End Function

    Public Function VerListaProductos(ByVal naveid As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select DISTINCT
                 0 ' ',' ' 'Estatus',	m.marc_descripcion 'Marca',
                status= case pe.pres_estatusdesarrollo  when 'D' then 'DESARROLLO'  when 'AD' then 'AUTORIZADO DESARROLLO'
				when 'AP' then 'AUTORIZADO PRODUCCIÓN'  when 'I' then 'INACTIVO NAVE'  when 'DP' then 'DESCONTINUADO' end,
                prod.prod_codigo 'Código',pe.pres_productoestiloid 'EstiloID',prod.prod_descripcion 'Colección',
				prod.prod_modelo 'Modelo',p.piel_descripcion 'Piel',c.color_descripcion 'Color','' 'Piel Color',
				t.talla_descripcion 'Corrida',pe.pres_totalconsumos 'Total Materiales',pe.pres_totalfracciones 'Total Fracciones',

                ISNULL( STUFF((SELECT CAST(',' AS varchar(MAX)) + nave_nombre
	            from Produccion.ProductoNaveProduccion 
			    left join Framework.Naves on nave_naveid=pena_naveid
			    where pena_productoestiloid = pe.pres_productoestiloid
	            FOR XML PATH('')), 1, 1, ''),'') as 'Asignado a Producción',

				cl.clie_razonsocial 'Cliente'
                from Programacion.ProductoEstilo as pe
                left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid
                left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
                left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
                left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
                left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
                left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
                left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
				left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
                left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
            </cadena>
        consulta += "where pena_naveid=" + naveid.ToString + "or pe.pres_navedesarrollaid=" + naveid.ToString + " and pe.pres_activo=1 and pe.pres_estatusdesarrollo is not null"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function VerListaProductosPorNaveyEstatus(ByVal naveid As Integer, ByVal estatus As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select DISTINCT
                 0 ' ',' ' 'Estatus',	m.marc_descripcion 'Marca',
                status= case pe.pres_estatusdesarrollo  when 'D' then 'DESARROLLO'  when 'AD' then 'AUTORIZADO DESARROLLO'
				when 'AP' then 'AUTORIZADO PRODUCCIÓN'  when 'I' then 'INACTIVO NAVE'  when 'DP' then 'DESCONTINUADO' end,
                prod.prod_codigo 'Código',pe.pres_productoestiloid 'EstiloID',prod.prod_descripcion 'Colección',
				prod.prod_modelo 'Modelo',p.piel_descripcion 'Piel',c.color_descripcion 'Color','' 'Piel Color',
				t.talla_descripcion 'Corrida',pe.pres_totalconsumos 'Total Materiales',pe.pres_totalfracciones 'Total Fracciones',

                ISNULL( STUFF((SELECT CAST(',' AS varchar(MAX)) + nave_nombre
	            from Produccion.ProductoNaveProduccion 
			    left join Framework.Naves on nave_naveid=pena_naveid
			    where pena_productoestiloid = pe.pres_productoestiloid
	            FOR XML PATH('')), 1, 1, ''),'') as 'Asignado a Producción',

				cl.clie_razonsocial 'Cliente'
                from Programacion.ProductoEstilo as pe
                left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid
                left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
                left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
                left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
                left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
                left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
                left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
				left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
                left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
            </cadena>
        consulta += " where pena_naveid=" + naveid.ToString + "or pe.pres_navedesarrollaid=" + naveid.ToString + " and pe.pres_estatusdesarrollo='" + estatus + "'  and pe.pres_activo=1"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function VerListaProductosImagenFracciones(ByVal naveid As Integer, ByVal estatus As String,
                                            ByVal marca As Integer, ByVal coleccion As Integer, ByVal tipoNave As Integer) As DataTable
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '    <cadena>
        '            select distinct 0 ' ',pe.pres_estatusdesarrollo 'Estatus',         
        '         m.marc_descripcion 'Marca', prod.prod_codigo 'Codigo', c2.cole_descripcion 'Colección' ,prod.prod_modelo 'Modelo',
        '         CONCAT(piel.piel_descripcion,' ',color.color_descripcion) 'Piel Color',
        '         t.talla_descripcion 'Corrida', pe.pres_totalconsumos 'Total Materiales', 
        '         ISNULL( STUFF((SELECT CAST(',' AS varchar(MAX)) + nave_nombre
        '      from Produccion.ProductoNaveProduccion 
        'left join Framework.Naves on nave_naveid=pena_naveid
        'where pena_productoestiloid = pe.pres_productoestiloid
        '      FOR XML PATH('')), 1, 1, ''),'') as 'Asignado a Producción', 
        '         cliente.clie_nombregenerico 'Cliente',pe.pres_productoestiloid 'idEstilo'
        '             from Programacion.ProductoEstilo as pe
        '             left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid
        '	            and pnp.pena_naveid=<%= naveid %>
        '             left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '             left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
        '             left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
        '             left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        '          left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
        '             left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
        '	left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
        '             left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
        '	left join Programacion.Colores as color on color.color_colorid=ep.espr_colorid
        '	left join Programacion.Colecciones as c2 on c2.cole_coleccionid=prod.prod_coleccionid
        '	left join Cliente.Cliente as cliente on cliente.clie_clienteid=prod.prod_clienteid
        '	left join Programacion.Pieles as piel on piel.piel_pielid=ep.espr_pielid
        '         </cadena>
        'consulta += " where (pena_naveid=" + naveid.ToString + " or pe.pres_navedesarrollaid=" + naveid.ToString + ")"
        'If estatus <> "" Then
        '    consulta += " and pe.pres_estatusdesarrollo='" + estatus.ToString + "'"
        'End If
        'If marca <> 0 Then
        '    consulta += " and prod.prod_marcaid='" + marca.ToString + "'"
        'End If
        'If coleccion <> 0 Then
        '    consulta += " and prod.prod_coleccionid='" + coleccion.ToString + "'"
        'End If
        'consulta += "  and pe.pres_activo=1 and pe.pres_estatus in (3,4)"
        'If tipoNave = 0 Then
        '    consulta += "and pnp.pena_naveid is not null and pnp.pena_estatus <> 'DP'"
        'End If
        'consulta += " AND pe.pres_estatusdesarrollo <> 'DP'  AND pe.pres_estatusdesarrollo <> 'I'"
        'Return operacion.EjecutaConsulta(consulta)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
               <cadena>
                   select DISTINCT 0 " ",
                    pe.pres_estatusdesarrollo 'Estatus',m.marc_descripcion 'Marca',
                    status= case (case (select count(pnp1.pena_productonaveid) 
        from Produccion.ProductoNaveProduccion pnp1 where pnp1.pena_naveid=<%= naveid %>
        and pnp1.pena_productoestiloid=pnp.pena_productoestiloid ) when 0 then pe.pres_estatusdesarrollo else pnp.pena_estatus end)  when 'D' then 'DESARROLLO'  when 'AD' then 'AUTORIZADO DESARROLLO'
        when 'AP' then 'AUTORIZADO PRODUCCIÓN'  when 'I' then 'INACTIVO NAVE'  when 'DP' then 'DESCONTINUADO' end,
                 pe.pres_codSicy 'SICY',     prod.prod_modelo 'Modelo',pe.pres_productoestiloid 'idEstilo',prod.prod_descripcion 'Colección',
        prod.prod_codigo 'Codigo',p.piel_descripcion 'Piel',c.color_descripcion 'Color',p.piel_descripcion +' ' + c.color_descripcion 'Piel Color',
        t.talla_descripcion 'Corrida',pe.pres_totalconsumos 'Total Materiales',
                    case isnull(pnp.pena_naveid,-1) when -1 then pe.pres_totalfracciones else pnp.pena_totalFracciones end 'Total Fracciones',
                          ISNULL( STUFF((SELECT DISTINCT CAST(',' AS varchar(MAX)) + nave_nombre
                 from Produccion.ProductoNaveProduccion as pnp2
           left join Framework.Naves n2 on n2.nave_naveid in 
        (select pnp3.pena_naveid from Produccion.ProductoNaveProduccion pnp3 
                    where pnp3.pena_productoestiloid=pe.pres_productoestiloid  and not pnp3.pena_estatus='I')
           where  pnp2.pena_productoestiloid =pe.pres_productoestiloid
        and pnp2.pena_estatus='AD' or  pnp2.pena_estatus='AP' 
                 FOR XML PATH('')), 1, 1, ''),'') as 'Asignado a Producción',

        cl.clie_razonsocial 'Cliente',pe.pres_navedesarrollaid
                    from Programacion.ProductoEstilo as pe
                    left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid and pnp.pena_naveid=<%= naveid %>
                    left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
                    left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
                    left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
                    left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
                    left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
                    left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
        left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
                    left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
                </cadena>
        consulta += " where (pena_naveid=" + naveid.ToString + " or pe.pres_navedesarrollaid=" + naveid.ToString + ")"
        If estatus <> "" Then
            consulta += " and pe.pres_estatusdesarrollo='" + estatus.ToString + "'"
        End If
        If marca <> 0 Then
            consulta += " and prod.prod_marcaid='" + marca.ToString + "'"
        End If
        If coleccion <> 0 Then
            consulta += " and prod.prod_coleccionid='" + coleccion.ToString + "'"
        End If
        consulta += "  and pe.pres_activo=1 and pe.pres_estatus in (3,4)"
        If tipoNave = 0 Then
            consulta += "and pnp.pena_naveid is not null and pnp.pena_estatus <> 'DP'"
        End If
        'consulta += " and pe.pres_estatusdesarrollo <> 'D' order by prod.prod_descripcion"
        consulta += " order by prod.prod_descripcion"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ListadoProductosFraccionesNave(ByVal naveid As Integer, ByVal estatus As String,
                                            ByVal marca As Integer, ByVal coleccion As Integer, ByVal tipoNave As Integer, ByVal FraccionID As Integer, ByVal Observaciones As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NavesId"
        parametro.Value = naveid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatus"
        parametro.Value = estatus
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@marcaid"
        parametro.Value = marca
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@coleccionid"
        parametro.Value = coleccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoNave"
        parametro.Value = tipoNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FraccionID"
        parametro.Value = FraccionID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@observaciones"
        parametro.Value = Observaciones
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ProductosFraccionesNave]", listaparametros)



    End Function


    Public Function VerListaProductosImagen(ByVal naveid As Integer, ByVal estatus As String,
                                            ByVal marca As Integer, ByVal coleccion As Integer, ByVal tipoNave As Integer) As DataTable

        Dim EstatusArticulo As String = String.Empty
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select *
                from (

             select DISTINCT 0 " ",
                ' ' 'Estatus',pe.pres_imagen 'Ruta',' ' 'Imagen',--m.marc_descripcion 'Marca',
                status= case (case (
                                    select COUNT(*)
							        from Programacion.ProductoEstilo pe1
							        where pe1. pres_navedesarrollaid = <%= naveid.ToString %>
							        and pe1.pres_productoestiloid =pe.pres_productoestiloid                               
                        ) when 1 then      
							
							 case (	
								isnull(pnp.pena_estatus,'')
							 )
							 when 'I' then
									CASE PE.pres_estatusdesarrollo WHEN 'DP' then pe.pres_estatusdesarrollo
									ELSE pnp.pena_estatus end
								ELSE
									 pe.pres_estatusdesarrollo 
							END
						 else 
							pnp.pena_estatus 						 
						 end
						 )  
				when 'D' then 'DESARROLLO'  
				when 'AD' then 'AUTORIZADO DESARROLLO'
				when 'AP' then 'AUTORIZADO PRODUCCIÓN'  
				when 'I' then 'INACTIVO NAVE'  
				when 'DP' then 'DESCONTINUADO' end,
                pe.pres_codSicy 'Código', m.marc_descripcion 'Marca', col.cole_descripcion 'Colección', prod.prod_modelo 'Modelo SICY',pe.pres_productoestiloid 'EstiloID',--prod.prod_descripcion 'Colección',
                --col.cole_descripcion 'Colección',
				prod.prod_codigo 'Modelo',p.piel_descripcion 'Piel',c.color_descripcion 'Color','' 'Piel Color',
				t.talla_descripcion 'Corrida',pe.pres_totalconsumos 'Total Materiales',
                case isnull(pnp.pena_naveid,-1) when -1 then pe.pres_totalfracciones else pnp.pena_totalFracciones end 'Total Fracciones',
                      ISNULL( STUFF((SELECT DISTINCT CAST(',' AS varchar(MAX)) + nave_nombre
	            from Produccion.ProductoNaveProduccion as pnp2
			    left join Framework.Naves n2 on n2.nave_naveid in 
				(select pnp3.pena_naveid from Produccion.ProductoNaveProduccion pnp3 
                where pnp3.pena_productoestiloid=pe.pres_productoestiloid  and not pnp3.pena_estatus='I')
			    where  pnp2.pena_productoestiloid =pe.pres_productoestiloid
				and pnp2.pena_estatus='AD' or  pnp2.pena_estatus='AP' 
	            FOR XML PATH('')), 1, 1, ''),'') as 'Asignado a Producción',
				cl.clie_razonsocial 'Cliente',pe.pres_navedesarrollaid,
                 (SELECT COUNT(ma.moar_idarchivo) FROM 
		          Produccion.ModelosArchivos  ma 
			    join Produccion.ArchivosTecnicos_OtrosArchivos on ma.moar_idarchivo = atoa_idarchivo
				where   pe.pres_productoestiloid  = ma.moar_productoestiloid and <%= naveid %> = atoa_pertenecenaveid) AS 'Archivos Cargados'
                from Programacion.ProductoEstilo as pe
                left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid and pnp.pena_naveid=<%= naveid.ToString %>
                left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
                left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
                left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
                left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
                left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
                left join Programacion.Colecciones as col on col.cole_coleccionid=prod.prod_coleccionid
                left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
				left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
                left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
                left join Produccion.HistorialProductoEstilo hpe    on hpe.hipe_productoestiloid = pe.pres_productoestiloid   
            </cadena>
        'consulta += " where (pena_naveid=" + naveid.ToString + " or pe.pres_navedesarrollaid=" + naveid.ToString + ")  and hpe.hipe_estatusa ='D' " 'T20208
        consulta += " where (pena_naveid=" + naveid.ToString + " or pe.pres_navedesarrollaid=" + naveid.ToString + ")   "
        If marca <> 0 Then
            consulta += " and prod.prod_marcaid='" + marca.ToString + "'"
        End If
        If coleccion <> 0 Then
            consulta += " and prod.prod_coleccionid='" + coleccion.ToString + "'"
        End If
        consulta += "  and pe.pres_activo=1 and pe.pres_estatus in (3,4)" 'T20208
        If tipoNave = 0 Then
            consulta += "and pnp.pena_naveid is not null and pnp.pena_estatus <> 'DP' "
        End If

        consulta += " ) as t "

        If estatus <> "" Then

            Select Case estatus
                Case "D"
                    EstatusArticulo = "DESARROLLO"
                Case "AD"
                    EstatusArticulo = "AUTORIZADO DESARROLLO"
                Case "AP"
                    EstatusArticulo = "AUTORIZADO PRODUCCIÓN"
                Case "I"
                    EstatusArticulo = "INACTIVO NAVE"
                Case "DP"
                    EstatusArticulo = "DESCONTINUADO"
                Case Else
            End Select

            consulta += "  where t.status ='" + EstatusArticulo.Trim + "'  "
        End If

        consulta += " order by t.Colección "

        'If estatus <> "" Then
        '    consulta += " and pe.pres_estatusdesarrollo='" + estatus.ToString + "'"
        'End If

        '  consulta += "and (pe.pres_totalconsumos is not NULL or pe.pres_totalconsumos>0) order by prod.prod_descripcion"
        'consulta += " order by prod.prod_descripcion "

        Return operacion.EjecutaConsulta(consulta)











        '=======================================

        '    Dim operacion As New Persistencia.OperacionesProcedimientos
        '    Dim consulta As String =
        '        <cadena>
        '           select DISTINCT 0 " ",
        '            ' ' 'Estatus',pe.pres_imagen 'Ruta',' ' 'Imagen',m.marc_descripcion 'Marca',
        '            status= case (case (
        '                            select COUNT(*)
        '			    from Programacion.ProductoEstilo pe1
        '			    where pe1. pres_navedesarrollaid = <%= naveid %>
        '			    and pe1.pres_productoestiloid =pe.pres_productoestiloid                         
        '            ) when 1 then pe.pres_estatusdesarrollo else pnp.pena_estatus end)  when 'D' then 'DESARROLLO'  when 'AD' then 'AUTORIZADO DESARROLLO'
        'when 'AP' then 'AUTORIZADO PRODUCCIÓN'  when 'I' then 'INACTIVO NAVE'  when 'DP' then 'DESCONTINUADO' end,
        '            pe.pres_codSicy 'Código',prod.prod_modelo 'Modelo SICY',pe.pres_productoestiloid 'EstiloID',prod.prod_descripcion 'Colección',
        'prod.prod_codigo 'Modelo',p.piel_descripcion 'Piel',c.color_descripcion 'Color','' 'Piel Color',
        't.talla_descripcion 'Corrida',pe.pres_totalconsumos 'Total Materiales',
        '             case isnull(pnp.pena_naveid,-1) when -1 then pe.pres_totalfracciones else pnp.pena_totalFracciones end 'Total Fracciones', 
        '            ISNULL( STUFF((SELECT DISTINCT CAST(',' AS varchar(MAX)) + nave_nombre
        '         from Produccion.ProductoNaveProduccion as pnp2
        '   left join Framework.Naves n2 on n2.nave_naveid in 
        '(select pnp3.pena_naveid from Produccion.ProductoNaveProduccion pnp3 
        '            where pnp3.pena_productoestiloid=pe.pres_productoestiloid  and not pnp3.pena_estatus='I')
        '   where  pnp2.pena_productoestiloid =pe.pres_productoestiloid
        'and pnp2.pena_estatus='AD' or  pnp2.pena_estatus='AP' 
        '         FOR XML PATH('')), 1, 1, ''),'') as 'Asignado a Producción',

        'cl.clie_razonsocial 'Cliente', pe.pres_navedesarrollaid
        '            from Programacion.ProductoEstilo as pe
        '            left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid and pnp.pena_naveid=<%= naveid %>
        '            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '            left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
        '            left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
        '            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        '            left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
        '            left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
        'left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
        '            left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
        '            left join Produccion.HistorialProductoEstilo hpe    on hpe.hipe_productoestiloid = pe.pres_productoestiloid   
        '        </cadena>
        '    consulta += " where (pena_naveid=" + naveid.ToString + " or pe.pres_navedesarrollaid=" + naveid.ToString + ")  and hpe.hipe_estatusa ='D' "
        '    If estatus <> "" Then
        '        consulta += " and pe.pres_estatusdesarrollo='" + estatus.ToString + "'"
        '    End If
        '    If marca <> 0 Then
        '        consulta += " and prod.prod_marcaid='" + marca.ToString + "'"
        '    End If
        '    If coleccion <> 0 Then
        '        consulta += " and prod.prod_coleccionid='" + coleccion.ToString + "'"
        '    End If
        '    consulta += "  and pe.pres_activo=1 and pe.pres_estatus in (3,4)"
        '    If tipoNave = 0 Then
        '        consulta += "and pnp.pena_naveid is not null and pnp.pena_estatus <> 'DP' "
        '    End If
        '    '  consulta += "and (pe.pres_totalconsumos is not NULL or pe.pres_totalconsumos>0) order by prod.prod_descripcion"
        '    consulta += " order by prod.prod_descripcion "
        '    Return operacion.EjecutaConsulta(consulta)

        '    Dim operacion As New Persistencia.OperacionesProcedimientos
        '    Dim consulta As String =
        '        <cadena>
        '           select DISTINCT 0 " ",
        '            ' ' 'Estatus',pe.pres_imagen 'Ruta',' ' 'Imagen',m.marc_descripcion 'Marca',
        '            status= case (case (
        '                    select count(pnp1.pena_productonaveid) 
        '        from Produccion.ProductoNaveProduccion pnp1 where pnp1.pena_naveid=<%= naveid %>
        '        and pnp1.pena_productoestiloid=pnp.pena_productoestiloid 
        '            ) when 0 then pe.pres_estatusdesarrollo else pnp.pena_estatus end)  when 'D' then 'DESARROLLO'  when 'AD' then 'AUTORIZADO DESARROLLO'
        'when 'AP' then 'AUTORIZADO PRODUCCIÓN'  when 'I' then 'INACTIVO NAVE'  when 'DP' then 'DESCONTINUADO' end,
        '            pe.pres_codSicy 'Código',prod.prod_modelo 'Modelo SICY',pe.pres_productoestiloid 'EstiloID',prod.prod_descripcion 'Colección',
        'prod.prod_codigo 'Modelo',p.piel_descripcion 'Piel',c.color_descripcion 'Color','' 'Piel Color',
        't.talla_descripcion 'Corrida',pe.pres_totalconsumos 'Total Materiales',
        '             case isnull(pnp.pena_naveid,-1) when -1 then pe.pres_totalfracciones else pnp.pena_totalFracciones end 'Total Fracciones', 
        '            ISNULL( STUFF((SELECT DISTINCT CAST(',' AS varchar(MAX)) + nave_nombre
        '         from Produccion.ProductoNaveProduccion as pnp2
        '   left join Framework.Naves n2 on n2.nave_naveid in 
        '(select pnp3.pena_naveid from Produccion.ProductoNaveProduccion pnp3 
        '            where pnp3.pena_productoestiloid=pe.pres_productoestiloid  and not pnp3.pena_estatus='I')
        '   where  pnp2.pena_productoestiloid =pe.pres_productoestiloid
        'and pnp2.pena_estatus='AD' or  pnp2.pena_estatus='AP' 
        '         FOR XML PATH('')), 1, 1, ''),'') as 'Asignado a Producción',

        'cl.clie_razonsocial 'Cliente', pe.pres_navedesarrollaid
        '            from Programacion.ProductoEstilo as pe
        '            left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid and pnp.pena_naveid=<%= naveid %>
        '            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '            left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
        '            left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
        '            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        '            left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
        '            left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
        'left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
        '            left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
        '            left join Produccion.HistorialProductoEstilo hpe    on hpe.hipe_productoestiloid = pe.pres_productoestiloid   
        '        </cadena>
        '    consulta += " where (pena_naveid=" + naveid.ToString + " or pe.pres_navedesarrollaid=" + naveid.ToString + ")  and hpe.hipe_estatusa ='D' "
        '    If estatus <> "" Then
        '        consulta += " and pe.pres_estatusdesarrollo='" + estatus.ToString + "'"
        '    End If
        '    If marca <> 0 Then
        '        consulta += " and prod.prod_marcaid='" + marca.ToString + "'"
        '    End If
        '    If coleccion <> 0 Then
        '        consulta += " and prod.prod_coleccionid='" + coleccion.ToString + "'"
        '    End If
        '    consulta += "  and pe.pres_activo=1 and pe.pres_estatus in (3,4)"
        '    If tipoNave = 0 Then
        '        consulta += "and pnp.pena_naveid is not null and pnp.pena_estatus <> 'DP' "
        '    End If
        '    '  consulta += "and (pe.pres_totalconsumos is not NULL or pe.pres_totalconsumos>0) order by prod.prod_descripcion"
        '    consulta += " order by prod.prod_descripcion "
        '    Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function VerListaProductosImagen2(ByVal naveid As Integer, ByVal estatus As String,
                                            ByVal marca As Integer, ByVal coleccion As Integer, ByVal tipoNave As Integer) As DataTable


        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
               select DISTINCT 0 " ",
                ' ' 'Estatus',pe.pres_imagen 'Ruta',' ' 'Imagen',m.marc_descripcion 'Marca',
                status= case (case (
                                select COUNT(*)
							    from Programacion.ProductoEstilo pe1
							    where pe1. pres_navedesarrollaid = <%= naveid %>
							    and pe1.pres_productoestiloid =pe.pres_productoestiloid                           
                ) when 1 then pe.pres_estatusdesarrollo else pnp.pena_estatus end)  when 'D' then 'DESARROLLO'  when 'AD' then 'AUTORIZADO DESARROLLO'
				when 'AP' then 'AUTORIZADO PRODUCCIÓN'  when 'I' then 'INACTIVO NAVE'  when 'DP' then 'DESCONTINUADO' end,
                pe.pres_codSicy 'Código',prod.prod_modelo 'Modelo SICY', pe.pres_productoestiloid 'EstiloID',prod.prod_descripcion 'Colección',
				prod.prod_codigo 'Modelo',p.piel_descripcion 'Piel',c.color_descripcion 'Color','' 'Piel Color',
				t.talla_descripcion 'Corrida',pe.pres_totalconsumos 'Total Materiales',                 
                case isnull(pnp.pena_naveid,-1) when -1 then pe.pres_totalfracciones else pnp.pena_totalFracciones end 'Total Fracciones',
				n2.nave_nombre'Asignado a Producción',cl.clie_razonsocial 'Cliente', pe.pres_navedesarrollaid,  count(ma.moar_idarchivo) 'Archivos Cargados'
                from Programacion.ProductoEstilo as pe
                left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid and pnp.pena_naveid=<%= naveid %>
                left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
                left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
                left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
                left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
                left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
                left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
				left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
                left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
				left join Framework.Naves as n2 on n2.nave_naveid=pnp.pena_naveid
                LEFT JOIN Produccion.ModelosArchivos  ma on  pres_productoestiloid = ma.moar_productoestiloid
				left join Produccion.ArchivosTecnicos_OtrosArchivos on ma.moar_idarchivo = atoa_idarchivo and <%= naveid %> = atoa_pertenecenaveid
            </cadena>
        consulta += " where (pena_naveid=" + naveid.ToString + " or pe.pres_navedesarrollaid=" + naveid.ToString + ")"
        If estatus <> "" Then
            consulta += " and pe.pres_estatusdesarrollo='" + estatus.ToString + "'"
        End If
        If marca <> 0 Then
            consulta += " and prod.prod_marcaid='" + marca.ToString + "'"
        End If
        If coleccion <> 0 Then
            consulta += " and prod.prod_coleccionid='" + coleccion.ToString + "'"
        End If
        consulta += "  and pe.pres_activo=1 and pe.pres_estatus in (3,4)"
        If tipoNave = 0 Then
            consulta += "and pnp.pena_naveid is not null and pnp.pena_estatus <> 'DP'"
        End If
        consulta += "  AND  pnp.pena_naveid=" + naveid.ToString + " and pnp.pena_estatus<>'I'" +
       " Group by pe.pres_imagen, m.marc_descripcion, " +
        "pe.pres_codSicy,prod.prod_modelo, pe.pres_productoestiloid,prod.prod_descripcion, " +
        "prod.prod_codigo,p.piel_descripcion,c.color_descripcion, " +
        "t.talla_descripcion,pe.pres_totalconsumos, " +
        "pnp.pena_naveid, pe.pres_totalfracciones , pnp.pena_totalFracciones, " +
        "n2.nave_nombre,cl.clie_razonsocial, pe.pres_navedesarrollaid,pe.pres_estatusdesarrollo, pnp.pena_estatus " +
        "order by prod.prod_descripcion "

        Return operacion.EjecutaConsulta(consulta)


        '    Dim operacion As New Persistencia.OperacionesProcedimientos
        '    Dim consulta As String =
        '        <cadena>
        '           select DISTINCT 0 " ",
        '            ' ' 'Estatus',pe.pres_imagen 'Ruta',' ' 'Imagen',m.marc_descripcion 'Marca',
        '            status= case (case (select count(pnp1.pena_productonaveid) 
        'from Produccion.ProductoNaveProduccion pnp1 where pnp1.pena_naveid=<%= naveid %>
        'and pnp1.pena_productoestiloid=pnp.pena_productoestiloid ) when 0 then pe.pres_estatusdesarrollo else pnp.pena_estatus end)  when 'D' then 'DESARROLLO'  when 'AD' then 'AUTORIZADO DESARROLLO'
        'when 'AP' then 'AUTORIZADO PRODUCCIÓN'  when 'I' then 'INACTIVO NAVE'  when 'DP' then 'DESCONTINUADO' end,
        '            pe.pres_codSicy 'Código',prod.prod_modelo 'Modelo SICY', pe.pres_productoestiloid 'EstiloID',prod.prod_descripcion 'Colección',
        'prod.prod_codigo 'Modelo',p.piel_descripcion 'Piel',c.color_descripcion 'Color','' 'Piel Color',
        't.talla_descripcion 'Corrida',pe.pres_totalconsumos 'Total Materiales',                 
        '            case isnull(pnp.pena_naveid,-1) when -1 then pe.pres_totalfracciones else pnp.pena_totalFracciones end 'Total Fracciones',
        'n2.nave_nombre'Asignado a Producción',cl.clie_razonsocial 'Cliente', pe.pres_navedesarrollaid

        '            from Programacion.ProductoEstilo as pe
        '            left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid and pnp.pena_naveid=<%= naveid %>
        '            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '            left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
        '            left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
        '            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        '            left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
        '            left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
        'left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
        '            left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
        'left join Framework.Naves as n2 on n2.nave_naveid=pnp.pena_naveid
        '        </cadena>
        '    consulta += " where (pena_naveid=" + naveid.ToString + " or pe.pres_navedesarrollaid=" + naveid.ToString + ")"
        '    If estatus <> "" Then
        '        consulta += " and pe.pres_estatusdesarrollo='" + estatus.ToString + "'"
        '    End If
        '    If marca <> 0 Then
        '        consulta += " and prod.prod_marcaid='" + marca.ToString + "'"
        '    End If
        '    If coleccion <> 0 Then
        '        consulta += " and prod.prod_coleccionid='" + coleccion.ToString + "'"
        '    End If
        '    consulta += "  and pe.pres_activo=1 and pe.pres_estatus in (3,4)"
        '    If tipoNave = 0 Then
        '        consulta += "and pnp.pena_naveid is not null and pnp.pena_estatus <> 'DP'"
        '    End If
        '    consulta += "  AND  pnp.pena_naveid=" + naveid.ToString + " and pnp.pena_estatus<>'I' order by prod.prod_descripcion"
        '    Return operacion.EjecutaConsulta(consulta)
    End Function


    Public Function ObtenerEstatusProductoEstiloConsumos(ByVal NaveID As Integer) As DataTable
        Dim EstatusArticulo As String = String.Empty
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
         <cadena>
                  select DISTINCT t.status,
			case t.status
			when '' then 0
			when 'DESARROLLO' then 1
			when 'AUTORIZADO DESARROLLO' then 2
			when 'AUTORIZADO PRODUCCIÓN' then 3
			when 'INACTIVO NAVE' then 4
			when 'DESCONTINUADO' then 5


			end as ID

                from (
                select 
                status= case (case (
                                    select COUNT(*)
							        from Programacion.ProductoEstilo pe1
							        where pe1. pres_navedesarrollaid =  <%= NaveID.ToString() %>
							        and pe1.pres_productoestiloid =pe.pres_productoestiloid                               
                        ) when 1 then      

							 case (	
								isnull(pnp.pena_estatus,'')
							 )
							 when 'I' then
									CASE PE.pres_estatusdesarrollo WHEN 'DP' then pe.pres_estatusdesarrollo
									ELSE pnp.pena_estatus end
								ELSE
									 pe.pres_estatusdesarrollo 
							END
						 else 
							pnp.pena_estatus 						 
						 end
						 )  
				when 'D' then 'DESARROLLO'  
				when 'AD' then 'AUTORIZADO DESARROLLO'
				when 'AP' then 'AUTORIZADO PRODUCCIÓN'  
				when 'I' then 'INACTIVO NAVE'  
				when 'DP' then 'DESCONTINUADO' end,


				pe.pres_navedesarrollaid,pnp.pena_estatus 'OtroStatus'
                from Programacion.ProductoEstilo as pe
                left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid and pnp.pena_naveid= <%= NaveID.ToString() %>                                                                                              
				left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid                
                left join Produccion.HistorialProductoEstilo hpe    on hpe.hipe_productoestiloid = pe.pres_productoestiloid   
             where (pena_naveid= <%= NaveID.ToString() %> or pe.pres_navedesarrollaid= <%= NaveID.ToString() %>) 
			--and hpe.hipe_estatusa ='D'  
			 and pe.pres_activo=1
			-- and pe.pres_estatus in (3,4) 
			  ) as t  
         </cadena>




        Return operacion.EjecutaConsulta(consulta)

    End Function
    Public Function ObtenerEstatusProductoEstiloConsumos_Estatus(ByVal NaveID As Integer) As DataTable
        Dim EstatusArticulo As String = String.Empty
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
         <cadena>
                  select DISTINCT t.status,
			case t.status
			when 'DESARROLLO' then 1
			when 'AUTORIZADO DESARROLLO' then 2
			when 'AUTORIZADO PRODUCCIÓN' then 3
			when 'INACTIVO NAVE' then 4
			when 'DESCONTINUADO' then 5


			end as ID

                from (
                select 
                status= case (case (
                                    select COUNT(*)
							        from Programacion.ProductoEstilo pe1
							        where pe1. pres_navedesarrollaid =  <%= NaveID.ToString() %>
							        and pe1.pres_productoestiloid =pe.pres_productoestiloid                               
                        ) when 1 then      

							 case (	
								isnull(pnp.pena_estatus,'')
							 )
							 when 'I' then
									CASE PE.pres_estatusdesarrollo WHEN 'DP' then pe.pres_estatusdesarrollo
									ELSE pnp.pena_estatus end
								ELSE
									 pe.pres_estatusdesarrollo 
							END
						 else 
							pnp.pena_estatus 						 
						 end
						 )  
				when 'D' then 'DESARROLLO'  
				when 'AD' then 'AUTORIZADO DESARROLLO'
				when 'AP' then 'AUTORIZADO PRODUCCIÓN'  
				when 'I' then 'INACTIVO NAVE'  
				when 'DP' then 'DESCONTINUADO' end,


				pe.pres_navedesarrollaid,pnp.pena_estatus 'OtroStatus'
                from Programacion.ProductoEstilo as pe
                left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid and pnp.pena_naveid= <%= NaveID.ToString() %>                                                                                              
				left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid                
                left join Produccion.HistorialProductoEstilo hpe    on hpe.hipe_productoestiloid = pe.pres_productoestiloid   
             where (pena_naveid= <%= NaveID.ToString() %> or pe.pres_navedesarrollaid= <%= NaveID.ToString() %>) 
			--and hpe.hipe_estatusa ='D'  
			 and pe.pres_activo=1
			-- and pe.pres_estatus in (3,4) 
			  ) as t  
         </cadena>




        Return operacion.EjecutaConsulta(consulta)

    End Function
    Public Function ObtenerMarcasEstilosConsumos(ByVal naveid As Integer, ByVal estatus As String) As DataTable

        '    Dim EstatusArticulo As String = String.Empty
        '    Dim operacion As New Persistencia.OperacionesProcedimientos
        '    Dim consulta As String =
        '     <cadena>             
        '	SELECT  DISTINCT marc_marcaid, t.Marca 
        '                from (
        '                SELECT  DISTINCT m.marc_descripcion 'Marca', m.marc_marcaid ,
        '	 status= case (case (
        '                                select COUNT(*)
        '			        from Programacion.ProductoEstilo pe1
        '			        where pe1. pres_navedesarrollaid = <%= naveid.ToString() %>
        '			        and pe1.pres_productoestiloid =pe.pres_productoestiloid                               
        '                    ) when 1 then      

        '			 case (	
        '				isnull(pnp.pena_estatus,'')
        '			 )
        '			 when 'I' then
        '					CASE PE.pres_estatusdesarrollo WHEN 'DP' then pe.pres_estatusdesarrollo
        '					ELSE pnp.pena_estatus end
        '				ELSE
        '					 pe.pres_estatusdesarrollo 
        '			END
        '		 else 
        '			pnp.pena_estatus 						 
        '		 end
        '		 )  
        'when 'D' then 'DESARROLLO'  
        'when 'AD' then 'AUTORIZADO DESARROLLO'
        'when 'AP' then 'AUTORIZADO PRODUCCIÓN'  
        'when 'I' then 'INACTIVO NAVE'  
        'when 'DP' then 'DESCONTINUADO' end                   
        '                from Programacion.ProductoEstilo as pe
        '                left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid 
        '	and pnp.pena_naveid=<%= naveid.ToString() %>                                                                               
        '                left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid                    
        '	left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
        '                left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
        '                left join Produccion.HistorialProductoEstilo hpe    on hpe.hipe_productoestiloid = pe.pres_productoestiloid   
        '             where (pena_naveid=<%= naveid.ToString() %> or pe.pres_navedesarrollaid=<%= naveid.ToString() %>) 
        '-- and hpe.hipe_estatusa ='D'   
        ' and pe.pres_activo=1 
        '--and pe.pres_estatus in (3,4) 
        '             ) as t 				
        '     </cadena>

        '    If estatus <> "" Then
        '        consulta += " where t.status ='" + estatus.Trim().ToString() + "' "
        '    End If

        '    consulta += " order by t.Marca"

        '    Return operacion.EjecutaConsulta(consulta)

        Dim obj As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim tblres As New DataTable

        Dim parametro As New SqlParameter("@NavesId", naveid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@estatus", estatus)
        listaParametros.Add(parametro)

        tblres = obj.EjecutarConsultaSP("[Produccion].[SP_ListaMarcasConsumos]", listaParametros)

        Return tblres

    End Function

    Public Function ObtenerColeccionesProductoEstiloConsumos(ByVal NaveID As Integer, ByVal Estatus As String, ByVal MarcaID As Integer) As DataTable

        '     Dim EstatusArticulo As String = String.Empty
        '     Dim operacion As New Persistencia.OperacionesProcedimientos
        '     Dim consulta As String =
        '       <cadena>

        '           	select DISTINCT t.cole_coleccionid, t.cole_descripcion
        '             from (
        '             select  c.cole_coleccionid, c.cole_descripcion,
        '	 status= case (case (
        '                                 select COUNT(*)
        '				        from Programacion.ProductoEstilo pe1
        '				        where pe1. pres_navedesarrollaid = <%= NaveID.ToString() %>
        '				        and pe1.pres_productoestiloid =pe.pres_productoestiloid                               
        '                     ) when 1 then      

        '				 case (	
        '					isnull(pnp.pena_estatus,'')
        '				 )
        '				 when 'I' then
        '						CASE PE.pres_estatusdesarrollo WHEN 'DP' then pe.pres_estatusdesarrollo
        '						ELSE pnp.pena_estatus end
        '					ELSE
        '						 pe.pres_estatusdesarrollo 
        '				END
        '			 else 
        '				pnp.pena_estatus 						 
        '			 end
        '			 )  
        '	when 'D' then 'DESARROLLO'  
        '	when 'AD' then 'AUTORIZADO DESARROLLO'
        '	when 'AP' then 'AUTORIZADO PRODUCCIÓN'  
        '	when 'I' then 'INACTIVO NAVE'  
        '	when 'DP' then 'DESCONTINUADO' end
        '             from Programacion.ProductoEstilo as pe
        '             left join Produccion.ProductoNaveProduccion as pnp  
        '	on pe.pres_productoestiloid=pnp.pena_productoestiloid and pnp.pena_naveid=<%= NaveID.ToString() %>                                                
        '             left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid                
        '	left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
        '             left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
        '	left join Programacion.Colecciones c on c.cole_coleccionid = prod.prod_coleccionid
        '             left join Produccion.HistorialProductoEstilo hpe    on hpe.hipe_productoestiloid = pe.pres_productoestiloid   
        '          where (pena_naveid=<%= NaveID.ToString() %> or pe.pres_navedesarrollaid=<%= NaveID.ToString() %>) 
        '-- and hpe.hipe_estatusa ='D'  
        ' and pe.pres_activo=1 
        '           --  and pe.pres_estatus in (3,4)
        '             and m.marc_marcaid ='<%= MarcaID.ToString() %>'
        '         ) as t  

        '       </cadena>

        '     If Estatus <> "" Then
        '         consulta += " where t.status ='" + Estatus.Trim().ToString() + "' "
        '     End If

        '     consulta += "  order by t.cole_descripcion asc"
        '     Return operacion.EjecutaConsulta(consulta)


        Dim obj As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim tblres As New DataTable

        Dim parametro As New SqlParameter("@NavesId", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@estatus", Estatus)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Marcad", MarcaID)
        listaParametros.Add(parametro)

        tblres = obj.EjecutarConsultaSP("[Produccion].[SP_ObtenerColeccionesProductoEstiloConsumos]", listaParametros)

        Return tblres

    End Function

    Public Function VerListaProductosImagen3(ByVal naveid As Integer, ByVal estatus As String,
                                            ByVal marca As Integer, ByVal coleccion As Integer, ByVal tipoNave As Integer) As DataTable


        Dim EstatusArticulo As String = String.Empty
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
               <cadena>
                   SELECT *
                    from (
                    select DISTINCT 0 " ",
                    ' ' 'Estatus',pe.pres_imagen 'Ruta',' ' 'Imagen',--m.marc_descripcion 'Marca',
                    status= case (case (
                                        select COUNT(*)
        			        from Programacion.ProductoEstilo pe1
        			        where pe1. pres_navedesarrollaid = <%= naveid.ToString() %>
        			        and pe1.pres_productoestiloid =pe.pres_productoestiloid                               
                            ) when 1 then      

        			 case (	
        				isnull(pnp.pena_estatus,'')
        			 )
        			 when 'I' then
                                CASE PE.pres_estatusdesarrollo WHEN 'DP' then pe.pres_estatusdesarrollo
									ELSE pnp.pena_estatus end        					
        				ELSE
        					 pe.pres_estatusdesarrollo 
        			END
        		 else 
        			pnp.pena_estatus 						 
        		 end
        		 )  
        when 'D' then 'DESARROLLO'  
        when 'AD' then 'AUTORIZADO DESARROLLO'
        when 'AP' then 'AUTORIZADO PRODUCCIÓN'  
        when 'I' then 'INACTIVO NAVE'  
        when 'DP' then 'DESCONTINUADO' end,
                    pe.pres_codSicy 'Código', m.marc_descripcion 'Marca', col.cole_descripcion 'Colección', prod.prod_modelo 'Modelo SICY', pe.pres_productoestiloid 'EstiloID',--prod.prod_descripcion 'Colección',
                    --col.cole_descripcion 'Colección',
        prod.prod_codigo 'Modelo',p.piel_descripcion 'Piel',c.color_descripcion 'Color','' 'Piel Color',
        t.talla_descripcion 'Corrida',pe.pres_totalconsumos 'Total Materiales',
                    case isnull(pnp.pena_naveid,-1) when -1 then pe.pres_totalfracciones else pnp.pena_totalFracciones end 'Total Fracciones',
                          ISNULL( STUFF((SELECT DISTINCT CAST(',' AS varchar(MAX)) + nave_nombre
                 from Produccion.ProductoNaveProduccion as pnp2
           left join Framework.Naves n2 on n2.nave_naveid in 
        (select pnp3.pena_naveid from Produccion.ProductoNaveProduccion pnp3 
                    where pnp3.pena_productoestiloid=pe.pres_productoestiloid  and not pnp3.pena_estatus='I')
           where  pnp2.pena_productoestiloid =pe.pres_productoestiloid
        and pnp2.pena_estatus='AD' or  pnp2.pena_estatus='AP' 
                 FOR XML PATH('')), 1, 1, ''),'') as 'Asignado a Producción',

        cl.clie_razonsocial 'Cliente',pe.pres_navedesarrollaid,
                            (SELECT COUNT(ma.moar_idarchivo) FROM 
		Produccion.ModelosArchivos  ma 
			    join Produccion.ArchivosTecnicos_OtrosArchivos on ma.moar_idarchivo = atoa_idarchivo
				where   pe.pres_productoestiloid  = ma.moar_productoestiloid and <%= naveid %> = atoa_pertenecenaveid) AS 'Archivos Cargados'
                    from Programacion.ProductoEstilo as pe
                    left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid and pnp.pena_naveid=<%= naveid.ToString() %>
                    left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
                    left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
                    left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
                    left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
                    left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
                    left join Programacion.Colecciones as col on col.cole_coleccionid=prod.prod_coleccionid
                    left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
        left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
                    left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
                    left join Produccion.HistorialProductoEstilo hpe    on hpe.hipe_productoestiloid = pe.pres_productoestiloid   
                </cadena>
        consulta += " where (pena_naveid=" + naveid.ToString + " or pe.pres_navedesarrollaid=" + naveid.ToString + ") and hpe.hipe_estatusa ='D' "

        If marca <> 0 Then
            consulta += " and prod.prod_marcaid='" + marca.ToString + "'"
        End If
        If coleccion <> 0 Then
            consulta += " and prod.prod_coleccionid='" + coleccion.ToString + "'"
        End If
        consulta += "  and pe.pres_activo=1 and pe.pres_estatus in (3,4)"
        If tipoNave = 0 Then
            consulta += "and pnp.pena_naveid is not null and pnp.pena_estatus <> 'DP'  "
        End If

        'consulta += " and pe.pres_estatusdesarrollo <> 'D' order by prod.prod_descripcion"
        'consulta += " order by prod.prod_descripcion"

        consulta += " ) as t "

        If estatus <> "" Then

            Select Case estatus
                Case "D"
                    EstatusArticulo = "DESARROLLO"
                Case "AD"
                    EstatusArticulo = "AUTORIZADO DESARROLLO"
                Case "AP"
                    EstatusArticulo = "AUTORIZADO PRODUCCIÓN"
                Case "I"
                    EstatusArticulo = "INACTIVO NAVE"
                Case "DP"
                    EstatusArticulo = "DESCONTINUADO"
                Case Else
            End Select

            consulta += "  where t.status ='" + EstatusArticulo.Trim + "'  "
        End If


        consulta += " order by t.Colección "
        Return operacion.EjecutaConsulta(consulta)

        '==============================================================

        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '       <cadena>
        '           select DISTINCT 0 " ",
        '            ' ' 'Estatus',pe.pres_imagen 'Ruta',' ' 'Imagen',m.marc_descripcion 'Marca',
        '            status= case (case (
        '                                select COUNT(*)
        '			        from Programacion.ProductoEstilo pe1
        '			        where pe1. pres_navedesarrollaid = <%= naveid %>
        '			        and pe1.pres_productoestiloid =pe.pres_productoestiloid                               
        '                    ) when 1 then pe.pres_estatusdesarrollo else pnp.pena_estatus end)  when 'D' then 'DESARROLLO'  when 'AD' then 'AUTORIZADO DESARROLLO'
        'when 'AP' then 'AUTORIZADO PRODUCCIÓN'  when 'I' then 'INACTIVO NAVE'  when 'DP' then 'DESCONTINUADO' end,
        '            pe.pres_codSicy 'Código', prod.prod_modelo 'Modelo SICY',pe.pres_productoestiloid 'EstiloID',prod.prod_descripcion 'Colección',
        'prod.prod_codigo 'Modelo',p.piel_descripcion 'Piel',c.color_descripcion 'Color','' 'Piel Color',
        't.talla_descripcion 'Corrida',pe.pres_totalconsumos 'Total Materiales',
        '            case isnull(pnp.pena_naveid,-1) when -1 then pe.pres_totalfracciones else pnp.pena_totalFracciones end 'Total Fracciones',
        '                  ISNULL( STUFF((SELECT DISTINCT CAST(',' AS varchar(MAX)) + nave_nombre
        '         from Produccion.ProductoNaveProduccion as pnp2
        '   left join Framework.Naves n2 on n2.nave_naveid in 
        '(select pnp3.pena_naveid from Produccion.ProductoNaveProduccion pnp3 
        '            where pnp3.pena_productoestiloid=pe.pres_productoestiloid  and not pnp3.pena_estatus='I')
        '   where  pnp2.pena_productoestiloid =pe.pres_productoestiloid
        'and pnp2.pena_estatus='AD' or  pnp2.pena_estatus='AP' 
        '         FOR XML PATH('')), 1, 1, ''),'') as 'Asignado a Producción',

        'cl.clie_razonsocial 'Cliente',pe.pres_navedesarrollaid
        '            from Programacion.ProductoEstilo as pe
        '            left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid and pnp.pena_naveid=<%= naveid %>
        '            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '            left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
        '            left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
        '            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        '            left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
        '            left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
        'left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
        '            left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
        '            left join Produccion.HistorialProductoEstilo hpe    on hpe.hipe_productoestiloid = pe.pres_productoestiloid   
        '        </cadena>
        'consulta += " where (pena_naveid=" + naveid.ToString + " or pe.pres_navedesarrollaid=" + naveid.ToString + ") and hpe.hipe_estatusa ='D' "
        'If estatus <> "" Then
        '    consulta += " and pe.pres_estatusdesarrollo='" + estatus.ToString + "'"
        'End If
        'If marca <> 0 Then
        '    consulta += " and prod.prod_marcaid='" + marca.ToString + "'"
        'End If
        'If coleccion <> 0 Then
        '    consulta += " and prod.prod_coleccionid='" + coleccion.ToString + "'"
        'End If
        'consulta += "  and pe.pres_activo=1 and pe.pres_estatus in (3,4)"
        'If tipoNave = 0 Then
        '    consulta += "and pnp.pena_naveid is not null and pnp.pena_estatus <> 'DP'  "
        'End If
        ''consulta += " and pe.pres_estatusdesarrollo <> 'D' order by prod.prod_descripcion"
        'consulta += " order by prod.prod_descripcion"
        'Return operacion.EjecutaConsulta(consulta)

        '    Dim operacion As New Persistencia.OperacionesProcedimientos
        '    Dim consulta As String =
        '           <cadena>
        '           select DISTINCT 0 " ",
        '            ' ' 'Estatus',pe.pres_imagen 'Ruta',' ' 'Imagen',m.marc_descripcion 'Marca',
        '            status= case (case (select count(pnp1.pena_productonaveid) 
        'from Produccion.ProductoNaveProduccion pnp1 where pnp1.pena_naveid=<%= naveid %>
        'and pnp1.pena_productoestiloid=pnp.pena_productoestiloid ) when 0 then pe.pres_estatusdesarrollo else pnp.pena_estatus end)  when 'D' then 'DESARROLLO'  when 'AD' then 'AUTORIZADO DESARROLLO'
        'when 'AP' then 'AUTORIZADO PRODUCCIÓN'  when 'I' then 'INACTIVO NAVE'  when 'DP' then 'DESCONTINUADO' end,
        '            pe.pres_codSicy 'Código', prod.prod_modelo 'Modelo SICY',pe.pres_productoestiloid 'EstiloID',prod.prod_descripcion 'Colección',
        'prod.prod_codigo 'Modelo',p.piel_descripcion 'Piel',c.color_descripcion 'Color','' 'Piel Color',
        't.talla_descripcion 'Corrida',pe.pres_totalconsumos 'Total Materiales',
        '            case isnull(pnp.pena_naveid,-1) when -1 then pe.pres_totalfracciones else pnp.pena_totalFracciones end 'Total Fracciones',
        '                  ISNULL( STUFF((SELECT DISTINCT CAST(',' AS varchar(MAX)) + nave_nombre
        '         from Produccion.ProductoNaveProduccion as pnp2
        '   left join Framework.Naves n2 on n2.nave_naveid in 
        '(select pnp3.pena_naveid from Produccion.ProductoNaveProduccion pnp3 
        '            where pnp3.pena_productoestiloid=pe.pres_productoestiloid  and not pnp3.pena_estatus='I')
        '   where  pnp2.pena_productoestiloid =pe.pres_productoestiloid
        'and pnp2.pena_estatus='AD' or  pnp2.pena_estatus='AP' 
        '         FOR XML PATH('')), 1, 1, ''),'') as 'Asignado a Producción',

        'cl.clie_razonsocial 'Cliente',pe.pres_navedesarrollaid
        '            from Programacion.ProductoEstilo as pe
        '            left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid and pnp.pena_naveid=<%= naveid %>
        '            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '            left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
        '            left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
        '            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        '            left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
        '            left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
        'left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
        '            left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
        '            left join Produccion.HistorialProductoEstilo hpe    on hpe.hipe_productoestiloid = pe.pres_productoestiloid   
        '        </cadena>
        '    consulta += " where (pena_naveid=" + naveid.ToString + " or pe.pres_navedesarrollaid=" + naveid.ToString + ") and hpe.hipe_estatusa ='D' "
        '    If estatus <> "" Then
        '        consulta += " and pe.pres_estatusdesarrollo='" + estatus.ToString + "'"
        '    End If
        '    If marca <> 0 Then
        '        consulta += " and prod.prod_marcaid='" + marca.ToString + "'"
        '    End If
        '    If coleccion <> 0 Then
        '        consulta += " and prod.prod_coleccionid='" + coleccion.ToString + "'"
        '    End If
        '    consulta += "  and pe.pres_activo=1 and pe.pres_estatus in (3,4)"
        '    If tipoNave = 0 Then
        '        consulta += "and pnp.pena_naveid is not null and pnp.pena_estatus <> 'DP'  "
        '    End If
        '    'consulta += " and pe.pres_estatusdesarrollo <> 'D' order by prod.prod_descripcion"
        '    consulta += " order by prod.prod_descripcion"
        '    Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function listaDepartamentos() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select dept_iddepto 'ID', dept_departamento 'Departamento' from Materiales.departamentos where dept_nave=7 order by dept_departamento"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function listaComponente() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select comp_componenteid 'ID', comp_descripción 'Componente' , comp_activo 'Activo' from Produccion.Componentes order by comp_componenteid"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaClasificaciones() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select clas_idClasificacion 'ID', clas_nombreclas 'Clasificación' from Materiales.Clasificaciones order by clas_nombreclas"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function listaProveedores() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select clas_idClasificacion 'ID', clas_nombreclas 'Clasificación' from Materiales.Clasificaciones order by clas_nombreclas"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function ComponenteRepetido(ByVal componente As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select comp_componenteid from Produccion.Componentes where comp_descripción = '" & componente & "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function GuardarComponente(ByVal componente As Consumos) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@descripcion"
        parametro.Value = componente.comp_descripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuariocreo"
        parametro.Value = componente.comp_usuariocreo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = componente.comp_activo
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_InsertarComponente]", listaparametros)
    End Function

    Public Function ModificarComponente(ByVal componente As Consumos) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@descripcion"
        parametro.Value = componente.comp_descripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuariomodifico"
        parametro.Value = componente.comp_usuariomodificoid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = componente.comp_activo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idComponente"
        parametro.Value = componente.comp_idcomponente
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ModificarComponente]", listaparametros)
    End Function

    Public Function getconsumosDes(ByVal productoEstiloId As Integer) As DataTable
        '     Dim operacion As New Persistencia.OperacionesProcedimientos
        '     Dim consulta As String =
        '         <cadena>
        '             select cd.code_activo 'Activo',0 'Editado',cd.code_bloqueado 'Bloqueado',cd.code_explosionar 'Explosionar',
        '         cd.code_lotear 'Lotear',isnull(co.coor_numero,1) Orden,c.comp_componenteid 'idComponente',c.comp_descripción 'Componente',
        '         cl.clas_idClasificacion 'idClasificacion', cl.clas_nombreclas 'Clasificación',
        '         mn.mn_materialNaveid 'IdMaterial',m.mate_sku 'SKU',
        '         m.mate_descripcion 'Material',cd.code_consumodesarrolloid 'idConsumo', cd.code_consumo 'Consumo', 
        '         um1.unme_idunidad 'idUMC',um1.unme_descripcion'UMC',
        '         p.prov_proveedorid 'idProveedor', p.prov_razonsocial 'Proveedor',
        '         cd.code_preciocompra 'Precio Compra',um2.unme_idunidad 'idUMProd', um2.unme_descripcion 'UMP',
        '         cd.code_factorconversion 'Factor',cd.code_precioumproduccion 'PrecioUM',
        '         case isnull(cd.code_costopar,-1) when -1 then  (cd.code_precioumproduccion *cd.code_consumo) else cd.code_costopar end 'Costo X Par',pe.pres_productoestiloid 'productoEstiloId'
        '         from Materiales.Materiales m left join Materiales.MaterialesNave mn on 
        'mn.mn_materialid=m.mate_materialid left join Produccion.ConsumosDesarrollo cd ON	
        '         cd.code_materialid=mn.mn_materialNaveid left join Produccion.Componentes c on 
        '         cd.code_componenteid=c.comp_componenteid left join Materiales.Clasificaciones cl ON
        '         cl.clas_idClasificacion=cd.code_clasificacionid left join Materiales.UnidadDeMedida um1 ON
        '         um1.unme_idunidad=cd.code_umproveedorid left join Materiales.UnidadDeMedida um2 ON
        '         um2.unme_idunidad=cd.code_umproduccionid left join Proveedor.Proveedor p ON
        '         p.prov_proveedorid=cd.code_proveedorid left join Programacion.ProductoEstilo pe ON
        '         pe.pres_productoestiloid=cd.code_productoestiloid
        '         left join Produccion.ConsumoOrdenamiento co on cd.code_consumodesarrolloid=co.coor_idconsumoid
        '         </cadena>
        '     consulta += " where pe.pres_productoestiloid=" & productoEstiloId & " and cd.code_activo=1 and m.mate_tipodematerial = 1 and m.mate_activo =1 "
        '     Dim d As New DataTable
        '     Dim c As String = ""
        '     c = <cadena2>
        '                   Union select 1 'Activo',0 'Editado',0 'Bloqueado',0 'Explosionar',0 'Lotear',1 'Orden',
        '         0 'idComponente','' 'Componente',0 'idClasificacion', '' 'Clasificación',
        '         0 'IdMaterial','' 'SKU',
        '         '' 'Material',0 'idConsumo', '' 'Consumo',0 'idUMC','' 'UMC',
        '         0 'idProveedor', '' 'Proveedor',0.00 'Precio Compra',0 'idUMProd','' 'UMP',
        '        0.0 'Factor',0.0 'PrecioUM',
        '         0.0 'Costo X Par',0 'productoEstiloId'

        '               </cadena2>
        '     d = operacion.EjecutaConsulta(consulta)
        '     If d.Rows.Count = 0 Then
        '         consulta += " " & c
        '     End If
        '     consulta += " 	order by Orden ASC"  'Orden  comp_componenteid
        '     Return operacion.EjecutaConsulta(consulta)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ProductoEstiloId"
        parametro.Value = productoEstiloId
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ObtieneConsumosDesarrollo]", listaparametros)


    End Function

    Public Function getconsumosDes2(ByVal productoEstiloId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select cast('0' as bit) as ' ', cd.code_activo 'Activo',0 'Editado',cd.code_bloqueado 'Bloqueado',cd.code_explosionar 'Explosionar',
            cd.code_lotear 'Lotear',isnull(co.coor_numero,1) Orden,c.comp_componenteid 'idComponente',c.comp_descripción 'Componente',
            cl.clas_idClasificacion 'idClasificacion', cl.clas_nombreclas 'Clasificación',
            mn.mn_materialNaveid 'IdMaterial',m.mate_sku 'SKU',
            m.mate_descripcion 'Material',cd.code_consumodesarrolloid 'idConsumo', cd.code_consumo 'Consumo', 
            um1.unme_idunidad 'idUMC',um1.unme_descripcion'UMC',
            p.prov_proveedorid 'idProveedor', p.prov_razonsocial 'Proveedor',
            cd.code_preciocompra 'Precio UMP',um2.unme_idunidad 'idUMProd', um2.unme_descripcion 'UMP',
            cd.code_factorconversion 'Factor',cd.code_precioumproduccion 'Precio UMC',
            case isnull(cd.code_costopar,-1) when -1 then  (cd.code_precioumproduccion *cd.code_consumo) else cd.code_costopar end 'Costo X Par',pe.pres_productoestiloid 'productoEstiloId'
            from Materiales.Materiales m left join Materiales.MaterialesNave mn on 
			mn.mn_materialid=m.mate_materialid left join Produccion.ConsumosDesarrollo cd ON	
            cd.code_materialid=mn.mn_materialNaveid left join Produccion.Componentes c on 
            cd.code_componenteid=c.comp_componenteid left join Materiales.Clasificaciones cl ON
            cl.clas_idClasificacion=cd.code_clasificacionid left join Materiales.UnidadDeMedida um1 ON
            um1.unme_idunidad=cd.code_umproveedorid left join Materiales.UnidadDeMedida um2 ON
            um2.unme_idunidad=cd.code_umproduccionid left join Proveedor.Proveedor p ON
            p.prov_proveedorid=cd.code_proveedorid left join Programacion.ProductoEstilo pe ON
            pe.pres_productoestiloid=cd.code_productoestiloid
            left join Produccion.ConsumoOrdenamiento co on cd.code_consumodesarrolloid=co.coor_idconsumoid
            </cadena>
        consulta += " where pe.pres_productoestiloid=" & productoEstiloId & " and cd.code_activo=1 and m.mate_tipodematerial = 1 and m.mate_activo =1 "
        Dim d As New DataTable
        Dim c As String = ""
        c = <cadena2>
                      Union select cast('0' as bit) as ' ', 1 'Activo',0 'Editado',0 'Bloqueado',0 'Explosionar',0 'Lotear',1 'Orden',
            0 'idComponente','' 'Componente',0 'idClasificacion', '' 'Clasificación',
            0 'IdMaterial','' 'SKU',
            '' 'Material',0 'idConsumo', '' 'Consumo',0 'idUMC','' 'UMC',
            0 'idProveedor', '' 'Proveedor',0.00 'Precio Compra',0 'idUMProd','' 'UMP',
           0.0 'Factor',0.0 'PrecioUM',
            0.0 'Costo X Par',0 'productoEstiloId'

                  </cadena2>
        d = operacion.EjecutaConsulta(consulta)
        If d.Rows.Count = 0 Then
            consulta += " " & c
        End If
        consulta += " 	order by Orden ASC"
        Return operacion.EjecutaConsulta(consulta)
    End Function


    Public Function getconsumosProd(ByVal productoEstiloId As Integer, ByVal idNave As Integer, Optional ByVal MostrarConsumoInactivo As Boolean = False) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = idNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ProductoEstiloId"
        parametro.Value = productoEstiloId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MostrarConsumoInactivo"
        parametro.Value = MostrarConsumoInactivo
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Produccion.[SP_ObtieneConsumosProduccion]", listaparametros)

        'Dim consulta As String =
        '         <cadena>                        
        '         select cd.copr_activo 'Activo',0 'Editado',cd.copr_bloqueado 'Bloqueado',cd.copr_explosionar 'Explosionar',cd.copr_lotear 'Lotear',isnull(co.coor_numero,1) Orden,
        '         c.comp_componenteid 'idComponente',c.comp_descripción 'Componente',cl.clas_idclasificacion 'idClasificacion', cl.clas_nombreclas 'Clasificación',
        '         mn.mn_materialNaveid 'IdMaterial',m.mate_sku 'SKU',
        '         m.mate_descripcion 'Material',cd.copr_consumoproduccionid 'idConsumo', cd.copr_consumo 'Consumo',um1.unme_idunidad 'idUMC',um1.unme_descripcion 'UMC',
        '         p.prov_proveedorid 'idProveedor', p.prov_razonsocial 'Proveedor',cd.copr_preciocompra 'Precio Compra',um2.unme_idunidad 'idUMProd',um2.unme_descripcion 'UMP',
        '         cd.copr_factorconversion 'Factor',cd.copr_precioumproduccion 'PrecioUM',
        '         (cd.copr_precioumproduccion *cd.copr_consumo) 'Costo X Par',pe.pres_productoestiloid 'productoEstiloId'
        '         from Materiales.Materiales m inner join Materiales.MaterialesNave mn on 
        'mn.mn_materialid=m.mate_materialid inner join Produccion.ConsumosProduccion cd ON	
        '         cd.copr_materialid=mn.mn_materialNaveid inner join Produccion.Componentes c on 
        '         cd.copr_componenteid=c.comp_componenteid inner join Materiales.Clasificaciones cl ON
        '         cl.clas_idclasificacion=cd.copr_clasificacionid inner join Materiales.UnidadDeMedida um1 ON
        '         um1.unme_idunidad=cd.copr_umproveedorid left join Materiales.UnidadDeMedida um2 ON
        '         um2.unme_idunidad=cd.copr_umproduccionid left join Proveedor.Proveedor p ON
        '         p.prov_proveedorid=cd.copr_proveedorid inner join Programacion.ProductoEstilo pe ON
        '         pe.pres_productoestiloid=cd.copr_productoestiloid
        '         left join Produccion.ProductoNaveProduccion on cd.copr_productonaveid=pena_productonaveid
        '         left join Produccion.ConsumoOrdenamiento co on cd.copr_consumodesarrolloid=co.coor_idconsumoid
        '         </cadena>
        'consulta += " where pe.pres_productoestiloid=" & productoEstiloId & " and cd.copr_activo=1 and pena_naveid=" & idNave & "  "

        'If MostrarConsumoInactivo = True Then
        '    consulta += "AND pena_estatus <> 'I' "
        'End If
        'consulta += "and m.mate_tipodematerial =1 and m.mate_activo =1 "

        'Dim d As New DataTable
        'Dim c As String = ""
        'c = <cadena2>
        '              Union select 1 'Activo',0 'Editado',0 'Bloqueado',0 'Explosionar',0 'Lotear',1 Orden,
        '    0 'idComponente','' 'Componente',0 'idClasificacion', '' 'Clasificación',
        '    0 'IdMaterial','' 'SKU',
        '    '' 'Material',0 'idConsumo', '' 'Consumo',0 'idUMC','' 'UMC',
        '    0 'idProveedor', '' 'Proveedor',0.00 'Precio Compra',0 'idUMProd','' 'UMP',
        '   0.0 'Factor',0.0 'PrecioUM',
        '    0.0 'Costo X Par',0 'productoEstiloId'

        '          </cadena2>
        'd = operacion.EjecutaConsulta(consulta)
        'If d.Rows.Count = 0 Then
        '    consulta += " " & c
        'End If
        'consulta += " 	order by Orden  ASC"   'Orden  comp_componenteid
        'Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function getconsumosProd2(ByVal productoEstiloId As Integer, ByVal idNave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>                        
            select cast('0' as bit) as ' ', cd.copr_activo 'Activo',0 'Editado',cd.copr_bloqueado 'Bloqueado',cd.copr_explosionar 'Explosionar',cd.copr_lotear 'Lotear',isnull(co.coor_numero,1) Orden,
            c.comp_componenteid 'idComponente',c.comp_descripción 'Componente',cl.clas_idclasificacion 'idClasificacion', cl.clas_nombreclas 'Clasificación',
            mn.mn_materialNaveid 'IdMaterial',m.mate_sku 'SKU',
            m.mate_descripcion 'Material',cd.copr_consumoproduccionid 'idConsumo', cd.copr_consumo 'Consumo',um1.unme_idunidad 'idUMC',um1.unme_descripcion 'UMC',
            p.prov_proveedorid 'idProveedor', p.prov_razonsocial 'Proveedor',cd.copr_preciocompra 'Precio UMC',um2.unme_idunidad 'idUMProd',um2.unme_descripcion 'UMP',
            cd.copr_factorconversion 'Factor',cd.copr_precioumproduccion 'Precio UMP',
            (cd.copr_precioumproduccion *cd.copr_consumo) 'Costo X Par',pe.pres_productoestiloid 'productoEstiloId'
            from Materiales.Materiales m inner join Materiales.MaterialesNave mn on 
			mn.mn_materialid=m.mate_materialid inner join Produccion.ConsumosProduccion cd ON	
            cd.copr_materialid=mn.mn_materialNaveid inner join Produccion.Componentes c on 
            cd.copr_componenteid=c.comp_componenteid inner join Materiales.Clasificaciones cl ON
            cl.clas_idclasificacion=cd.copr_clasificacionid inner join Materiales.UnidadDeMedida um1 ON
            um1.unme_idunidad=cd.copr_umproveedorid left join Materiales.UnidadDeMedida um2 ON
            um2.unme_idunidad=cd.copr_umproduccionid left join Proveedor.Proveedor p ON
            p.prov_proveedorid=cd.copr_proveedorid inner join Programacion.ProductoEstilo pe ON
            pe.pres_productoestiloid=cd.copr_productoestiloid
            left join Produccion.ProductoNaveProduccion on cd.copr_productonaveid=pena_productonaveid
            left join Produccion.ConsumoOrdenamiento co on cd.copr_consumodesarrolloid=co.coor_idconsumoid
            </cadena>
        consulta += " where pe.pres_productoestiloid=" & productoEstiloId & " and cd.copr_activo=1 and pena_naveid=" & idNave & " AND pena_estatus <> 'I' and m.mate_tipodematerial =1 and m.mate_activo =1 "
        Dim d As New DataTable
        Dim c As String = ""
        c = <cadena2>
                      Union select cast( '0' as bit) as ' ', 1 'Activo',0 'Editado',0 'Bloqueado',0 'Explosionar',0 'Lotear',1 Orden,
            0 'idComponente','' 'Componente',0 'idClasificacion', '' 'Clasificación',
            0 'IdMaterial','' 'SKU',
            '' 'Material',0 'idConsumo', '' 'Consumo',0 'idUMC','' 'UMC',
            0 'idProveedor', '' 'Proveedor',0.00 'Precio Compra',0 'idUMProd','' 'UMP',
           0.0 'Factor',0.0 'PrecioUM',
            0.0 'Costo X Par',0 'productoEstiloId'

                  </cadena2>
        d = operacion.EjecutaConsulta(consulta)
        If d.Rows.Count = 0 Then
            consulta += " " & c
        End If
        consulta += " 	order by Orden ASC"
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function eliminarConsumos(ByVal productoEstiloId) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = " delete Produccion.ConsumosDesarrollo where code_productoestiloid=" & productoEstiloId & "; update Programacion.ProductoEstilo  set pres_totalconsumos=0 where pres_productoestiloid=" & productoEstiloId & ""
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function insertConsumo(c As Object, Optional idNaveConsulta As Integer = 0) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter("@totalConsumos", c.costopar)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@productoEstiloId", c.productoEstiloId)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@componenteid", c.componenteid)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@clasificacionid", c.clasificacionid)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@materialid", c.materialId)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@consumo", c.consumo)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@proveedorid", c.proveedorId)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@umproveedorid", c.umProveedorId)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@umproduccionid", c.umproduccionid)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@factorconversion", c.factorconversion)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@preciocompra", Math.Round(c.preciocompra, 2))
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@precioumproduccion", Math.Round(c.precioumproduccion, 2))
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@costopar", Math.Round(c.costopar, 2))
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@bloqueado", c.bloqueado)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@explosionar", c.explosionar)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@lotear", c.lotear)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@idConsumo", c.idconsumo)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@accion", c.accion)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@usuario", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@activo", c.activo)
        listaparametros.Add(parametro)

        If idNaveConsulta = 0 Then
            Return objPersistencia.EjecutarConsultaSP("[Materiales].[SP_InsertUpdateConsumo]", listaparametros)
        Else
            parametro = New SqlParameter("@naveId", idNaveConsulta)
            listaparametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Materiales].[SP_InsertUpdateConsumo_ConservaProveedor]", listaparametros)
        End If
    End Function

    Public Function reemplazarConsumo(ByVal c As Consumo) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@totalConsumos"
        parametro.Value = c.costopar
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = c.productoEstiloId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@componenteid"
        parametro.Value = c.componenteid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@clasificacionid"
        parametro.Value = c.clasificacionid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@materialid"
        parametro.Value = c.materialId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@consumo"
        parametro.Value = c.consumo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@proveedorid"
        parametro.Value = c.proveedorId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@umproveedorid"
        parametro.Value = c.umProveedorId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@umproduccionid"
        parametro.Value = c.umproduccionid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@factorconversion"
        parametro.Value = c.factorconversion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@preciocompra"
        parametro.Value = c.preciocompra
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@precioumproduccion"
        parametro.Value = c.precioumproduccion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@costopar"
        parametro.Value = c.costopar
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@bloqueado"
        parametro.Value = c.bloqueado
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@explosionar"
        parametro.Value = c.explosionar
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@lotear"
        parametro.Value = c.lotear
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idConsumo"
        parametro.Value = c.idconsumo
        listaparametros.Add(parametro)
        'parametro = New SqlParameter
        'parametro.ParameterName = "@accion"
        'parametro.Value = c.accion
        'listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = c.activo
        listaparametros.Add(parametro)

        Dim datos As New DataTable
        datos = objPersistencia.EjecutarConsultaSP("[Materiales].[SP_ReemplazarConsumo]", listaparametros)
        Return datos
    End Function

    Public Function reemplazarConsumos(ByVal c As Consumo) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " UPDATE Produccion.ConsumosDesarrollo"
        consulta += " set "
        consulta += "[code_clasificacionid]=" + c.clasificacionid.ToString + ","
        consulta += "[code_materialid]=" + c.materialId.ToString + ","
        consulta += "[code_consumo]=" + c.consumo.ToString + ","
        consulta += "[code_proveedorid]=" + c.proveedorId.ToString + ","
        consulta += "[code_umproveedorid]=" + c.umProveedorId.ToString + ","
        consulta += "[code_umproduccionid]=" + c.umproduccionid.ToString + ","
        consulta += "[code_factorconversion]=" + c.factorconversion.ToString + ","
        consulta += "[code_preciocompra]=" + c.preciocompra.ToString + ","
        consulta += "[code_precioumproduccion]=" + c.precioumproduccion.ToString + ","
        consulta += "[code_costopar]=" + c.costopar.ToString + ","
        If c.bloqueado = True Then
            consulta += "[code_bloqueado]=1,"
        Else
            consulta += "[code_bloqueado]=0,"
        End If
        If c.explosionar = True Then
            consulta += "[code_explosionar]=1,"
        Else
            consulta += "[code_explosionar]=0,"
        End If
        If c.lotear = True Then
            consulta += "[code_lotear]=1,"
        Else
            consulta += "[code_lotear]=0,"
        End If
        consulta += "[code_modificousuarioid]=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ","
        consulta += "[code_fechamodifico]='" + DateTime.Now.ToString("dd/MM/yyyy") + "',"
        If c.activo = True Then
            consulta += "[code_activo]= 1"
        Else
            consulta += "[code_activo]= 0"
        End If

        consulta += " where code_componenteid=" + c.componenteid.ToString + " and code_productoestiloid=" + c.productoEstiloId.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function insertFraccionProd(ByVal f As Fracciones) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = f.productoEstiloId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@fraccionid"
        parametro.Value = f.frap_fraccionid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idFraccionProduccion"
        parametro.Value = f.fraccionidProd
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@accion"
        parametro.Value = f.accion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = f.frap_activo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@costo"
        parametro.Value = f.frap_precio
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@pagar"
        parametro.Value = f.frap_paga
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@sumarcosto"
        parametro.Value = f.sumar_Costo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@sumartiempo"
        parametro.Value = f.sumar_Tiempo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@horas"
        parametro.Value = f.horas_
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@minutos"
        parametro.Value = f.minutos_
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@segundos"
        parametro.Value = f.segundos_
        listaparametros.Add(parametro)

        Dim datos As New DataTable
        datos = objPersistencia.EjecutarConsultaSP("[Materiales].[SP_InsertUpdateFraccionProd]", listaparametros)
        Return datos
    End Function
    Public Function insertFraccionDes(ByVal f As Fracciones) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = f.productoEstiloId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@fraccionid"
        parametro.Value = f.frap_fraccionid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idFraccionDesarrollo"
        parametro.Value = f.fraccionidProd
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@accion"
        parametro.Value = f.accion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = f.frap_activo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@costo"
        parametro.Value = Math.Round(f.frap_precio, 3)
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@pagar"
        parametro.Value = Math.Round(f.frap_paga, 2)
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@sumarcosto"
        parametro.Value = Math.Round(f.sumar_Costo, 2)
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@sumartiempo"
        parametro.Value = f.sumar_Tiempo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@horas"
        parametro.Value = f.horas_
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@minutos"
        parametro.Value = f.minutos_
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@segundos"
        parametro.Value = f.segundos_
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = f.idNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@observaciones"
        parametro.Value = f.observaciones
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@maquinaid"
        parametro.Value = f.maquinariaid
        listaparametros.Add(parametro)

        Dim datos As New DataTable
        datos = objPersistencia.EjecutarConsultaSP("[Materiales].[SP_InsertUpdateFraccionDes]", listaparametros)
        Return datos
    End Function

    Public Function insertFraccionDesNueva(ByVal f As Fracciones, ByVal factual As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = f.productoEstiloId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@fraccionid"
        parametro.Value = f.frap_fraccionid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idFraccionDesarrollo"
        parametro.Value = f.fraccionidProd
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@accion"
        parametro.Value = f.accion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = f.frap_activo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@costo"
        parametro.Value = Math.Round(f.frap_precio, 3)
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@pagar"
        parametro.Value = Math.Round(f.frap_paga, 2)
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@sumarcosto"
        parametro.Value = Math.Round(f.sumar_Costo, 2)
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@sumartiempo"
        parametro.Value = f.sumar_Tiempo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@horas"
        parametro.Value = f.horas_
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@minutos"
        parametro.Value = f.minutos_
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@segundos"
        parametro.Value = f.segundos_
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = f.idNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@observaciones"
        parametro.Value = f.observaciones
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@maquinaid"
        parametro.Value = f.maquinariaid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idfraccDesActual"
        parametro.Value = factual
        listaparametros.Add(parametro)

        Dim datos As New DataTable
        datos = objPersistencia.EjecutarConsultaSP("[Materiales].[SP_InsertUpdateFraccionDes_V1]", listaparametros)
        Return datos
    End Function

    Public Function EliminarFraccionOri(ByVal FO As Integer, ByVal FracNueva As Integer, ByVal accion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@FraccOrig"
        parametro.Value = FO
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FraccioNueva"
        parametro.Value = FracNueva
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@accion"
        parametro.Value = accion
        listaparametros.Add(parametro)


        Dim dato As New DataTable
        dato = objPersistencia.EjecutarConsultaSP("[Materiales].[SP_EliminaFraccionOriginal]", listaparametros)
        Return dato

    End Function

    Public Function ActualizarImagenes(ByVal suela As String, ByVal caja As String, ByVal marca As String, ByVal productoEstiloId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        If suela.Length > 0 Then
            consulta = " update Programacion.ProductoEstilo set pres_suela='" & suela & "'  where pres_productoestiloid=" & productoEstiloId
            operacion.EjecutaConsulta(consulta)
        End If
        If caja.Length Then
            consulta = " update Programacion.ProductoEstilo set pres_caja='" & caja & "' where pres_productoestiloid=" & productoEstiloId
            operacion.EjecutaConsulta(consulta)
        End If
        If marca.Length Then
            consulta = " update Programacion.ProductoEstilo set  pres_marcaNorma='" & marca & "' where pres_productoestiloid=" & productoEstiloId
            operacion.EjecutaConsulta(consulta)
        End If
        Dim d As New DataTable
        Return d
    End Function

    Public Function getfraccionesDes(ByVal productoEstiloId As Integer, ByVal idNave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select DISTINCT fd_activo 'Activo',isnull(fo.fror_numero,1) Orden,frap_fraccionid 'idFraccion',fd_fracciondesarrolloid 'idFraccDes',
                frap_descripcion 'Fracción',
                --isnull(fd.fd_costo,frap_precio) 'Costo',
            	isnull(Cast(fd.fd_costo as DECIMAL(18,2)),CAST(frap_precio as decimal(18,2))) 'Costo',
                isnull(Convert(Bit,fd.fd_pagar),Convert(Bit,frap_paga)) 'Pagar',fd.fd_sumarcosto'Sumar Costo',
                fd.fd_tiempohoras'Horas',fd.fd_tiempominutos'Minutos',fd.fd_tiemposegundos'Segundos',fd.fd_sumartiempo 'Sumar Tiempo',
                mapr_descripcion 'Maquinaria',mp.mapr_maquinaid 'maquinaid',UPPER(fd.fd_observaciones) Observaciones,fd_fracciondesarrolloid 'idFraccDesActual'  from Produccion.CatalagoFracciones inner join 
                Produccion.FraccionesDesarrollo  fd ON frap_fraccionid=fd_fraccionid left join Produccion.MaquinariaProduccion mp
                on mapr_maquinaid=fd.fd_maquinaid
                left join Produccion.FraccionOrdenamiento fo on fo.fror_fraccionid=fd.fd_fracciondesarrolloid
            </cadena>
        consulta += " where fd_productoestiloid=" & productoEstiloId & " and fd_activo=1 and fd.fd_naveid=" & idNave
        Dim d As New DataTable
        Dim c As String = ""
        c = <cadena2>
                union
                    select 1 'Activo',1 Orden,0 'idFraccion',0 'idFraccDes','' 'Fracción',0 'Costo',
                    Convert(bit,0) 'Pagar',Convert(bit,0) 'Sumar Costo','' 'Horas','' 'Minutos',
                    '' 'Segundos',Convert(bit,0) 'Sumar Tiempo','' 'Maquinaria',0 maquinaid,'' Observaciones,'' idFraccActual
        </cadena2>
        d = operacion.EjecutaConsulta(consulta)
        If d.Rows.Count = 0 Then
            consulta += " " & c
        End If
        consulta += " order by Orden ASC"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function getfraccionesDes2(ByVal productoEstiloId As Integer, ByVal idNave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select cast('0' as bit) ' ', fd_activo 'Activo',isnull(fo.fror_numero,1) Orden,frap_fraccionid 'idFraccion',fd_fracciondesarrolloid 'idFraccDes',
                frap_descripcion 'Fracción',isnull(fd.fd_costo,frap_precio) 'Costo',
                isnull(Convert(Bit,fd.fd_pagar),Convert(Bit,frap_paga)) 'Pagar',fd.fd_sumarcosto'Sumar Costo',
                fd.fd_tiempohoras'Horas',fd.fd_tiempominutos'Minutos',fd.fd_tiemposegundos'Segundos',fd.fd_sumartiempo 'Sumar Tiempo',
                mapr_descripcion 'Maquinaria',mp.mapr_maquinaid 'maquinaid',UPPER(fd.fd_observaciones) Observaciones  from Produccion.CatalagoFracciones inner join 
                Produccion.FraccionesDesarrollo  fd ON frap_fraccionid=fd_fraccionid left join Produccion.MaquinariaProduccion mp
                on mapr_maquinaid=fd.fd_maquinaid
                left join Produccion.FraccionOrdenamiento fo on fo.fror_fraccionid=fd.fd_fracciondesarrolloid
            </cadena>
        consulta += " where fd_productoestiloid=" & productoEstiloId & " and fd_activo=1 and fd.fd_naveid=" & idNave
        Dim d As New DataTable
        Dim c As String = ""
        c = <cadena2>
                union
                    select cast('0' as bit) ' ' ,1 'Activo',1 Orden,0 'idFraccion',0 'idFraccDes','' 'Fracción',0 'Costo',
                    Convert(bit,0) 'Pagar',Convert(bit,0) 'Sumar Costo','' 'Horas','' 'Minutos',
                    '' 'Segundos',Convert(bit,0) 'Sumar Tiempo','' 'Maquinaria',0 maquinaid,'' Observaciones
        </cadena2>
        d = operacion.EjecutaConsulta(consulta)
        If d.Rows.Count = 0 Then
            consulta += " " & c
        End If
        consulta += " order by Orden ASC"
        Return operacion.EjecutaConsulta(consulta)
    End Function


    Public Function getfraccionesProd(ByVal productoEstiloId As Integer, ByVal idNave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>

            select fd_activo 'Activo',frap_fraccionid 'idFraccion',fd_fracciondesarrolloid 'idFraccDes',
                frap_descripcion 'Fracción',isnull(fd.fd_costo,frap_precio) 'Costo',
                isnull(Convert(Bit,fd.fd_pagar),Convert(Bit,frap_paga)) 'Pagar',fd.fd_sumarcosto'Sumar Costo',
                fd.fd_tiempohoras'Horas',fd.fd_tiempominutos'Minutos',fd.fd_tiemposegundos'Segundos',fd.fd_sumartiempo 'Sumar Tiempo',
                mapr_descripcion 'Maquinaria' from Produccion.CatalagoFracciones inner join 
                Produccion.FraccionesDesarrollo  fd ON frap_fraccionid=fd_fraccionid left join Produccion.MaquinariaProduccion
                on frap_maquinariaid=mapr_maquinaid
            </cadena>
        consulta += " where fd.fd_productoestiloid=" & productoEstiloId & " and fd.fd_activo=1 " '--and pena_naveid=" & idNave & ""
        Dim d As New DataTable
        Dim c As String = ""
        c = <cadena2>
                    UNION
                    select 1 'Activo',0 'idFraccion',0 'idFraccDes','' 'Fracción',0 'Costo',Convert(bit,0) 'Pagar', Convert(bit,0) 'Sumar Costo',
                    '' 'Horas','' 'Minutos', '' 'Segundos',Convert(bit,0) 'Sumar Tiempo','' 'Maquinaria'
        </cadena2>
        d = operacion.EjecutaConsulta(consulta)
        If d.Rows.Count = 0 Then
            consulta += " " & c
        End If
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function getFraccion(ByVal idFraccion As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                 select * from Produccion.CatalagoFracciones
            </cadena>
        If idFraccion > 0 Then
            consulta += " where frap_fraccionid=" & idFraccion & " "
        End If
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaClasificacionesComponente() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>

            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getComponente(ByVal idComponente As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                SELECT * FROM Produccion.Componentes WHERE  comp_activo=1 
            </cadena>
        consulta += " AND comp_componenteid=" & idComponente
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getMaterialporSKU(ByVal sku As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
              SELECT [mate_materialid]
              ,[mate_sku]
              ,[mate_descripcion]
              ,[mate_idCategoria]
              ,[mate_idClasificacion]
              ,[mate_tipodematerial]
              ,[mate_idmaterialremplazo]
              ,[mate_critico]
              ,[mate_activo]
              ,[mate_autorizado]
              ,[mate_usuariocreoid]
              ,[mate_usuariomodificoid]
              ,[mate_fechaderegistro]
              ,[mate_fechademodificacion]
              ,[mate_idMaterialSicy]
              ,[mate_idColor]
              ,[mate_idTamaño]
              ,[mate_nombreMaterial]
              ,[mate_navedesarrollaid]
              ,[mate_exclusivo] FROM Materiales.Materiales where mate_activo=1
            </cadena>
        consulta += " and mate_sku='" & sku & "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getProveedor(ByVal idProveedor As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                SELECT * FROM Proveedor.Proveedor where prov_activo=1 
            </cadena>
        consulta += " and prov_proveedorid=" & idProveedor
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function validarMaterialComponente(ByVal sku As String, ByVal idComponente As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                SELECT        m.mate_materialid, m.mate_sku, m.mate_descripcion, m.mate_idCategoria, m.mate_idClasificacion, m.mate_tipodematerial, m.mate_idmaterialremplazo, m.mate_critico, m.mate_activo, m.mate_autorizado, 
                         m.mate_usuariocreoid, m.mate_usuariomodificoid, m.mate_fechaderegistro, m.mate_fechademodificacion, m.mate_idMaterialSicy, m.mate_idColor, m.mate_idTamaño, m.mate_nombreMaterial, 
                         m.mate_navedesarrollaid, m.mate_exclusivo, cc.cocl_idcomponenteclasificacion, cc.cocl_idcomponente, cc.cocl_idclasificacion, cc.cocl_usuariocreo, cc.cocl_fechacreacion, cc.cocl_usuariomodifico, 
                         cc.cocl_fechamodificacion, cc.cocl_activo, c.comp_componenteid, c.comp_descripción, c.comp_fechacreacion, c.comp_usuariocreoid, c.comp_fechamodificacion, c.comp_usuariomodificoid, c.comp_activo, 
                         cl.clas_idclasificacion, cl.clas_nombreclas, cl.clas_status, cl.clas_idSicy, cl.clas_sku, cl.clas_directo, cl.clas_usuariocreoid, cl.clas_fechacreacion, cl.clas_usuariomodificoid, cl.clas_fechamodificacion
FROM            Materiales.Materiales AS m INNER JOIN
                         Produccion.componenteClasificacion AS cc ON m.mate_idClasificacion = cc.cocl_idclasificacion INNER JOIN
                         Produccion.Componentes AS c ON c.comp_componenteid = cc.cocl_idcomponente INNER JOIN
                         Materiales.Clasificaciones AS cl ON cl.clas_idclasificacion = cc.cocl_idclasificacion
            </cadena>
        consulta += " where cc.cocl_activo=1 and cc.cocl_idcomponente=" & idComponente & " and m.mate_sku='" & sku & "' "
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function validarAsignacionMaterial(ByVal sku As String, ByVal idNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
               SELECT        m.mate_materialid, m.mate_sku, m.mate_descripcion, m.mate_idCategoria, m.mate_idClasificacion, m.mate_tipodematerial, m.mate_idmaterialremplazo, m.mate_critico, m.mate_activo, m.mate_autorizado, 
                         m.mate_usuariocreoid, m.mate_usuariomodificoid, m.mate_fechaderegistro, m.mate_fechademodificacion, m.mate_idMaterialSicy, m.mate_idColor, m.mate_idTamaño, m.mate_nombreMaterial, 
                         m.mate_navedesarrollaid, m.mate_exclusivo, mn.mn_materialNaveid, mn.mn_materialid, mn.mn_idNave, mn.mn_idDepartamento, mn.mn_usuarioCreo, mn.mn_fechaCreacion, mn.mn_critico, 
                         mn.mn_idMaterialRemplazo, mn.mn_activo, mn.mn_fechacopia, mn.mn_usuariocopiaid, mn.mn_materialNaveidOriginal, mn.mn_bloqueado
FROM            Materiales.Materiales AS m INNER JOIN
                         Materiales.MaterialesNave AS mn ON m.mate_materialid = mn.mn_materialid
            </cadena>
        consulta += " where m.mate_sku='" & sku & "' and mn.mn_idNave=" & idNave & " and m.mate_activo=1 and mn.mn_activo=1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function validarMaterialProveedor(ByVal idProveedor As Integer, ByVal idMaterialNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                SELECT mn.mn_materialNaveid,mp.prma_umproveedor,mp.prma_umproduccion,mp.prma_idumproveedor,mp.prma_idumproduccion,
                mp.prma_preciounitario,mp.prma_equivalencia
                FROM Materiales.MaterialesNave mn join Materiales.MaterialesPrecio mp on mp.prma_idMaterialNave=mn.mn_materialNaveid
            </cadena>
        consulta += " where mn.mn_materialNaveid=" & idMaterialNave & " and mn.mn_activo=1 and mp.prma_provedorid=" & idProveedor & " and mp.prma_activo=1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function buscarComponenteRepetido(ByVal Componente As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select comp_descripción from Produccion.Componentes
            </cadena>
        consulta += "where comp_descripción = '" + Componente + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function SaberTipoNave(ByVal nave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select nave_desarrolla from Framework.Naves where nave_naveid
            </cadena>
        consulta += "=" & nave
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function articuloAsignadoANaveEstatusAP(ByVal ESTILO As Integer, ByVal idNave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
           select pena_naveid from Produccion.ProductoNaveProduccion WHERE pena_productoestiloid=
        </cadena>
        consulta += ESTILO.ToString + " AND pena_estatus ='AP' and pena_naveid = " & idNave
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function inserOrdenamientoConsumo(ByVal c As Consumo) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@consumoid"
        parametro.Value = c.idconsumo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@numeroOrden"
        parametro.Value = c.noOrden
        listaparametros.Add(parametro)

        Dim datos As New DataTable
        datos = objPersistencia.EjecutarConsultaSP("[Produccion].[insertUpdateConsumoOrden]", listaparametros)
        Return datos
    End Function

    Public Function getMaquinaria() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
           select mapr_maquinaid 'ID',mapr_descripcion 'Máquina' from Produccion.MaquinariaProduccion
            where mapr_activo=1
        </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function inserOrdenamientoFracion(ByVal c As Fracciones) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@fraccionid"
        parametro.Value = c.fraccionidProd
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@numeroOrden"
        parametro.Value = c.noOrden
        listaparametros.Add(parametro)

        Dim datos As New DataTable
        datos = objPersistencia.EjecutarConsultaSP("[Produccion].[insertUpdateFraccionOrden]", listaparametros)
        Return datos
    End Function

    Public Function ActualizaConsumosNaveProduccion(ByVal pXmlMateriales As String, ByVal pIdProductoEstilo As Integer, ByVal pIdUsuario As Integer, ByVal pNaveId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@XML_MATERIALES"
        parametro.Value = pXmlMateriales
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ProductoEstiloId"
        parametro.Value = pIdProductoEstilo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = pIdUsuario
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = pNaveId
        listaparametros.Add(parametro)


        Dim dato As New DataTable
        dato = objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ActualizarConsumosNaveProduccion]", listaparametros)
        Return dato

    End Function

    Public Function ConsultaConsumosProduccion(ByVal pNaveId As Integer, ByVal pMarca As Integer, ByVal pColeccion As Integer, ByVal pEstatus As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim vEstatusArticulo As String = String.Empty

        If pEstatus <> "" Then
            Select Case pEstatus
                Case "D"
                    vEstatusArticulo = "DESARROLLO"
                Case "AD"
                    vEstatusArticulo = "AUTORIZADO DESARROLLO"
                Case "AP"
                    vEstatusArticulo = "AUTORIZADO PRODUCCIÓN"
                Case "I"
                    vEstatusArticulo = "INACTIVO NAVE"
                Case "DP"
                    vEstatusArticulo = "DESCONTINUADO"
                Case Else
            End Select
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = pNaveId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Marca"
        parametro.Value = IIf(pMarca = 0, Nothing, pMarca)
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = IIf(pColeccion = 0, Nothing, pColeccion)
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Estatus"
        parametro.Value = IIf(pEstatus = "", Nothing, vEstatusArticulo)
        listaparametros.Add(parametro)

        Dim dato As New DataTable
        dato = objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaConsumosProduccion_2]", listaparametros)
        Return dato

    End Function

    Public Function ConsultaConsumosNoDesarrollo(ByVal pNaveId As Integer, ByVal pEstatus As String, ByVal pMarca As Integer, ByVal pColeccion As Integer, ByVal pTipoNave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim vEstatusArticulo As String = String.Empty

        If pEstatus <> "" Then
            Select Case pEstatus
                Case "D"
                    vEstatusArticulo = "DESARROLLO"
                Case "AD"
                    vEstatusArticulo = "AUTORIZADO DESARROLLO"
                Case "AP"
                    vEstatusArticulo = "AUTORIZADO PRODUCCIÓN"
                Case "I"
                    vEstatusArticulo = "INACTIVO NAVE"
                Case "DP"
                    vEstatusArticulo = "DESCONTINUADO"
                Case Else
            End Select
        End If


        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = pNaveId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Estatus"
        parametro.Value = IIf(pEstatus = "", Nothing, vEstatusArticulo)
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Marca"
        parametro.Value = IIf(pMarca = 0, Nothing, pMarca)
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = IIf(pColeccion = 0, Nothing, pColeccion)
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoNave"
        parametro.Value = pTipoNave
        listaparametros.Add(parametro)

        Dim dato As New DataTable
        dato = objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaConsumosDesarrollo_NoDesarrollo_2]", listaparametros)
        Return dato

    End Function

    Public Function ConsultaConsumosAsignados(ByVal pNaveId As Integer, ByVal pEstatus As String, ByVal pMarca As Integer, ByVal pColeccion As Integer, ByVal pTipoNave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim vEstatusArticulo As String = String.Empty

        If pEstatus <> "" Then
            Select Case pEstatus
                Case "D"
                    vEstatusArticulo = "DESARROLLO"
                Case "AD"
                    vEstatusArticulo = "AUTORIZADO DESARROLLO"
                Case "AP"
                    vEstatusArticulo = "AUTORIZADO PRODUCCIÓN"
                Case "I"
                    vEstatusArticulo = "INACTIVO NAVE"
                Case "DP"
                    vEstatusArticulo = "DESCONTINUADO"
                Case Else
            End Select
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = pNaveId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Estatus"
        parametro.Value = IIf(pEstatus = "", Nothing, vEstatusArticulo)
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Marca"
        parametro.Value = IIf(pMarca = 0, Nothing, pMarca)
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = IIf(pColeccion = 0, Nothing, pColeccion)
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoNave"
        parametro.Value = pTipoNave
        listaparametros.Add(parametro)

        Dim dato As New DataTable
        dato = objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaConsumosDesarrollo_Asignados_2]", listaparametros)
        Return dato

    End Function

    Public Function listadoProductosNave(ByVal UsuarioID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = UsuarioID
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_InicioSession_ListadoProductosPorNave_Desarrolla]", listaparametros)
    End Function

    Public Function listadoPermisosPorUsuarioNave(ByVal var_ClaveAccion As String, ByVal var_ClaveModulo As String, ByVal var_Nave As Integer, ByVal var_Usuario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@ClaveAccionXML"
        parametro.Value = var_ClaveAccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClaveModulo"
        parametro.Value = var_ClaveModulo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = var_Nave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = var_Usuario
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_VerificaPerfiles_AccionesEnPantalla]", listaparametros)
    End Function

    Public Function ConsultaFraccionesDEsarrolloProductoEstilo(ByVal productoEstilo As Integer, ByVal idNaveDesarrolla As Integer) As DataTable
        Dim obj As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim tblres As New DataTable

        Dim parametro As New SqlParameter("@productoEstiloId", productoEstilo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@idNaveDesarrolla", idNaveDesarrolla)
        listaParametros.Add(parametro)

        tblres = obj.EjecutarConsultaSP("[Programacion].[SP_ValidaExistenFraccionesActivosProductoEstilo]", listaParametros)

        Return tblres

    End Function

    Public Function ConsultaModeloproductoEstiloId(ByVal productoEstilo As Integer)
        Dim obj As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@productoEstiloId", productoEstilo)
        listaParametros.Add(parametro)

        Return obj.EjecutarConsultaSP("[Programacion].[SP_ConsultaModeloSAYDeProductoEstilo]", listaParametros)

    End Function

    Public Function BaseDatosConsumos(IdNave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim listaparametros As New List(Of SqlParameter) From {
            New SqlParameter With {
                .ParameterName = "@IdNave",
                .Value = IdNave
            }
        }

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Consumos_ListadoConsumos]", listaparametros)
    End Function

    Public Function BaseDatosConsumosDesarrollo(ByVal pNaveId As Integer, ByVal pEstatus As String, ByVal pMarca As Integer, ByVal pColeccion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim vEstatusArticulo As String = String.Empty

        'Dim listaparametros As New List(Of SqlParameter) From {
        '    New SqlParameter With {
        '        .ParameterName = "@IdNave",
        '        .Value = IdNave
        '    }
        '}

        'parametro = New SqlParameter
        'parametro.ParameterName = "@NaveId"
        'parametro.Value = pNaveId
        'listaparametros.Add(parametro)


        If pEstatus <> "" Then
            Select Case pEstatus
                Case "D"
                    vEstatusArticulo = "DESARROLLO"
                Case "AD"
                    vEstatusArticulo = "AUTORIZADO DESARROLLO"
                Case "AP"
                    vEstatusArticulo = "AUTORIZADO PRODUCCIÓN"
                Case "I"
                    vEstatusArticulo = "INACTIVO NAVE"
                Case "DP"
                    vEstatusArticulo = "DESCONTINUADO"
                Case Else
            End Select
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = pNaveId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Estatus"
        parametro.Value = IIf(pEstatus = "", Nothing, vEstatusArticulo)
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Marca"
        parametro.Value = IIf(pColeccion = 0, Nothing, pMarca)
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = IIf(pColeccion = 0, Nothing, pColeccion)
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Consumos_ListadoConsumos_Desarrollo]", listaparametros)
    End Function

End Class
