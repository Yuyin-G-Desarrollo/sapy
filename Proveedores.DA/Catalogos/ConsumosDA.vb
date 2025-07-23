Imports System.Data.SqlClient
Imports Entidades

Public Class ConsumosDA

    Public Function VerListaProductos() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim consulta As String =
            <cadena>
                  SELECT top 7
               pe.pres_codSicy 'Código',
               pr.prod_descripcion 'Descripción',
               pr.prod_codigo 'Modelo', 
               pl.piel_descripcion 'Piel',
               cc.color_descripcion 'Color',
               tt.talla_descripcion 'Corrida',
               fa.fami_descripcion 'Familia',
               ln.linea_descripcion 'Linea',
               55.69 'Total Consumos',
               15.25 'Total Fracciones',
               'AUTORIZADO PRODUCCIÓN' 'Estatus',
                       Cliente= case pr.prod_codigo when '14011' then 'ANDREA' else '' end
                    FROM Programacion.Productos AS pr
            INNER JOIN Programacion.ProductoEstilo AS pe oN pr.prod_productoid = pe.pres_productoid
            LEFT JOIN Programacion.Hormas AS hh ON pe.pres_horma = hh.horma_hormaid
            INNER JOIN Programacion.EstilosProducto AS ep    ON pe.pres_estiloid = ep.espr_estiloproductoid
            INNER JOIN Programacion.Pieles AS pl      ON ep.espr_pielid = pl.piel_pielid
            LEFT JOIN Programacion.Familias AS fa     ON pe.pres_familiaid = fa.fami_familiaid
            INNER JOIN Programacion.Tallas AS tt      ON ep.espr_tallaid = tt.talla_tallaid
            INNER JOIN Programacion.Colores AS cc     ON ep.espr_colorid = cc.color_colorid
            INNER JOIN Programacion.PielMuestras AS pm       ON ep.espr_pielmuestraid = pm.plmu_pielmuestraid
            INNER JOIN Programacion.Forros AS ff      ON ep.espr_forroid = ff.forr_forroid
            INNER JOIN Programacion.Suelas AS ss      ON ep.espr_suelaid = ss.suel_suelaid
            left join Programacion.Colecciones as c on c.cole_coleccionid=pr.prod_coleccionid
            left join Programacion.Marcas as m on m.marc_marcaid=pr.prod_marcaid
            LEFT JOIN Programacion.Lineas ln   ON pe.pres_lineaid = ln.linea_lineaid
            left join Programacion.Grupos as gg on gg.grpo_grupoid=pr.prod_grupo
            left join Programacion.Familias as f on f.fami_familiaid=pr.prod_familiaid
            left join Programacion.Colecciones as cl on cl.cole_coleccionid=pr.prod_coleccionid
            INNER JOIN Programacion.EstatusProducto st       ON pe.pres_estatus = st.stpr_productoStatusId
            AND pl.piel_activo = 1 AND tt.talla_activo = 1 AND cc.color_activo = 1 AND pm.plmu_activo = 1 AND ff.forr_activo = 1
            AND ss.suel_activo = 1 AND pe.pres_activo = 1 AND hh.horma_activo = 1
            </cadena>
        '''consulta recortada luis
        '         <cadena>
        '       SELECT
        '       0 ' ',pe.pres_codSicy 'Código',pr.prod_descripcion 'Descripción', pr.prod_codigo 'Modelo', 
        '      pl.piel_descripcion 'Piel', cc.color_descripcion 'Color',tt.talla_descripcion 'Corrida', 
        'fa.fami_descripcion 'Familia', ln.linea_descripcion 'Linea',isnull (cli.clie_nombregenerico, '') 'Cliente',
        '   0.0 'Total Consumos',
        '      0.0 'Total Fracciones',
        '      'AUTORIZADO PRODUCCIÓN' 'Estatus'
        '                 FROM Programacion.Productos AS pr
        '         INNER JOIN Programacion.ProductoEstilo AS pe oN pr.prod_productoid = pe.pres_productoid
        '         LEFT JOIN Programacion.Hormas AS hh	ON pe.pres_horma = hh.horma_hormaid
        '         INNER JOIN Programacion.EstilosProducto AS ep	ON pe.pres_estiloid = ep.espr_estiloproductoid
        '         INNER JOIN Programacion.Pieles AS pl	ON ep.espr_pielid = pl.piel_pielid
        '         LEFT JOIN Programacion.Familias AS fa	ON pe.pres_familiaid = fa.fami_familiaid
        '         INNER JOIN Programacion.Tallas AS tt	ON ep.espr_tallaid = tt.talla_tallaid
        '         INNER JOIN Programacion.Colores AS cc	ON ep.espr_colorid = cc.color_colorid
        '         INNER JOIN Programacion.PielMuestras AS pm	ON ep.espr_pielmuestraid = pm.plmu_pielmuestraid
        '         INNER JOIN Programacion.Forros AS ff	ON ep.espr_forroid = ff.forr_forroid
        '         INNER JOIN Programacion.Suelas AS ss	ON ep.espr_suelaid = ss.suel_suelaid
        '         left join Programacion.Colecciones as c on c.cole_coleccionid=pr.prod_coleccionid
        '         left join Programacion.Marcas as m on m.marc_marcaid=pr.prod_marcaid
        '         LEFT JOIN Programacion.Lineas ln	ON pe.pres_lineaid = ln.linea_lineaid
        '         left join Programacion.Grupos as gg on gg.grpo_grupoid=pr.prod_grupo
        '         left join Programacion.Familias as f on f.fami_familiaid=pr.prod_familiaid
        '         left join Programacion.Colecciones as cl on cl.cole_coleccionid=pr.prod_coleccionid
        'left join Cliente.Cliente as cli on cli.clie_clienteid=pr.prod_clienteid
        '         INNER JOIN Programacion.EstatusProducto st	ON pe.pres_estatus = st.stpr_productoStatusId
        '         AND pl.piel_activo = 1 AND tt.talla_activo = 1 AND cc.color_activo = 1 AND pm.plmu_activo = 1 AND ff.forr_activo = 1
        '         AND ss.suel_activo = 1 AND pe.pres_activo = 1 AND hh.horma_activo = 1
        '         </cadena>
        ''''''''Consulta pantalla productos
        ' <cadena>
        'SELECT 0 ' ',pp.prod_productoid, pp.prod_codigo, pp.prod_modelo, mm.marc_descripcion, cc.cole_descripcion, 
        'pp.prod_descripcion, 
        '(SELECT Programacion.FN_ConcatenarSubfamilias(pp.prod_productoid)) AS Subfamilias, gg.grpo_descripcion, tc.tica_tipocategoriaid , 
        'tc.tica_descripcion, pp.prod_activo, pp.prod_foto, tt.temp_nombre , tt.temp_año, 
        'pp.prod_dibujo, gg.grpo_grupoid 
        'FROM Programacion.Productos AS pp JOIN Programacion.Marcas AS mm ON pp.prod_marcaid = mm.marc_marcaid 
        'JOIN Programacion.Colecciones AS cc ON pp.prod_coleccionid = cc.cole_coleccionid 
        'JOIN Programacion.Temporadas AS tt ON pp.prod_temporadaid = tt.temp_temporadaid 
        'JOIN Programacion.Grupos AS gg ON pp.prod_grupo = gg.grpo_grupoid 
        'JOIN Programacion.TipoCategoria tc ON pp.prod_categoria = tc.tica_tipocategoriaid 
        'WHERE pp.prod_activo = 'True' AND mm.marc_activo = 1 AND cc.cole_activo = 1 AND tt.temp_activo = 1 
        'AND gg.grpo_activo = 1 GROUP BY	pp.prod_productoid, pp.prod_codigo, pp.prod_modelo, pp.prod_descripcion, 
        'mm.marc_descripcion, cc.cole_descripcion,tt.temp_nombre,tt.temp_año, pp.prod_activo,pp.prod_foto,pp.prod_dibujo,
        'gg.grpo_grupoid,gg.grpo_descripcion, tc.tica_tipocategoriaid,tc.tica_descripcion ORDER BY pp.prod_codigo
        '</cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaMaterialesConConsumos() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                SELECT top 100
               pe.pres_codSicy 'Código',m.marc_descripcion 'Marca',c.cole_descripcion 'Colección',
               pr.prod_codigo 'Modelo', pl.piel_descripcion 'Piel', cc.color_descripcion 'Color',
               tt.talla_descripcion 'Corrida',fa.fami_descripcion 'Familia',ln.linea_descripcion 'Linea',
               '' Cliente
               FROM Programacion.Productos AS pr
            INNER JOIN Programacion.ProductoEstilo AS pe oN pr.prod_productoid = pe.pres_productoid
            INNER JOIN Programacion.EstilosProducto AS ep ON pe.pres_estiloid = ep.espr_estiloproductoid
            INNER JOIN Programacion.Pieles AS pl ON ep.espr_pielid = pl.piel_pielid
            LEFT JOIN Programacion.Familias AS fa ON pe.pres_familiaid = fa.fami_familiaid
            INNER JOIN Programacion.Tallas AS tt ON ep.espr_tallaid = tt.talla_tallaid
            INNER JOIN Programacion.Colores AS cc ON ep.espr_colorid = cc.color_colorid
            INNER JOIN Programacion.PielMuestras AS pm ON ep.espr_pielmuestraid = pm.plmu_pielmuestraid
            INNER JOIN Programacion.Forros AS ff ON ep.espr_forroid = ff.forr_forroid
            left join Programacion.Colecciones as c on c.cole_coleccionid=pr.prod_coleccionid
            left join Programacion.Marcas as m on m.marc_marcaid=pr.prod_marcaid
            LEFT JOIN Programacion.Lineas ln ON pe.pres_lineaid = ln.linea_lineaid
            left join Programacion.Familias as f on f.fami_familiaid=pr.prod_familiaid
            left join Programacion.Colecciones as cl on cl.cole_coleccionid=pr.prod_coleccionid
            INNER JOIN Programacion.EstatusProducto st ON pe.pres_estatus = st.stpr_productoStatusId
            AND pl.piel_activo = 1 AND tt.talla_activo = 1 AND cc.color_activo = 1 AND pm.plmu_activo = 1 AND ff.forr_activo = 1
            where m.marc_marcaid=3
            order by Colección, Modelo, Corrida
            </cadena>
        consulta += " "
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaMateriales() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
               select dage_sku 'SKU', dage_descripcion 'Material' from Materiales.Materiales where dage_idClasificacion=6
            </cadena>
        consulta += " "
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaProveedoress() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select  top 1 dg.dage_nombrecomercial 'Proveedor' ,mp.prma_preciounitario 'Precio', mp.prma_umproveedor 'UMP', mp.prma_umproduccion 'UMC', 
                mp.prma_equivalencia 'Factor Conversión'
                from Proveedor.DatosGenerales as dg join Materiales.MaterialesPrecio as mp
                on mp.prma_provedorid=dg.dage_proveedorid
                where dg.dage_proveedorid= 6
            </cadena>
        consulta += " "
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultaProductosEspecifico(ByVal productoid As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
              SELECT P.piel_descripcion 'PIEL',C.color_descripcion 'COLOR', T.talla_descripcion 'CORRIDA',PM.plmu_descripcion 'CORTE',
                F.forr_descripcion 'FORRO',S.suel_descripcion 'SUELA',H.horma_descripcion 'HORMA',FAM.fami_descripcion 'FAMILIA',
                L.linea_descripcion 'LINEA',PROD.prod_clienteid 'ID CLIENTE', PROD.prod_codcliente 'CODIGO CLIENTE',PE.pres_imagen 'IMAGEN'
                FROM Programacion.EstilosProducto AS EP JOIN Programacion.ProductoEstilo AS PE ON PE.pres_estiloid= EP.espr_estiloproductoid 
                JOIN Programacion.Pieles AS P ON P.piel_pielid=EP.espr_pielid
                JOIN Programacion.Tallas AS T ON T.talla_tallaid=EP.espr_tallaid
                JOIN Programacion.Colores AS C ON C.color_colorid=EP.espr_colorid
                JOIN Programacion.Forros AS F ON F.forr_forroid=EP.espr_forroid
                JOIN Programacion.Suelas AS S ON S.suel_suelaid=EP.espr_suelaid
                JOIN Programacion.Hormas AS H ON H.horma_hormaid=PE.pres_horma
                JOIN Programacion.Familias AS FAM ON FAM.fami_familiaid=PE.pres_familiaid
                JOIN Programacion.Lineas AS L ON L.linea_lineaid=PE.pres_lineaid
				JOIN Programacion.PielMuestras AS PM ON PM.plmu_pielmuestraid=EP.espr_pielmuestraid
                JOIN Programacion.Productos AS PROD ON PROD.prod_productoid=PE.pres_productoid where PROD.prod_productoid =
            </cadena>
        consulta += " " + productoid.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function tablaConsumos() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
                SELECT 0 'Bloq',CFConsumo.Explosionar,0 Lotear,isnull((Select nomcat From Catalogos Where Tipcat=27 and Idcat=CFConsumo.IdComponente),'') as Componente, 
                catalogos.nomcat Clasificación, CONCAT(CFConsumo.IdMaterial,'0001') SKU, ma.Nombre as Material, CFConsumo.Consumo,CFConsumo.UMConsumo 'UM Consumo',

                Proveedores.RazonSocial Proveedor, 
                CFConsumo.PrecioC PrecioCompra, CFConsumo.UMPrecio 'UM Proveedor',140 'Factor', CFConsumo.PrecioUM 'Precio UM' , 
                 CFConsumo.CostoxPar 'Costo Par'
                FROM CFConsumo INNER JOIN catalogos ON CFConsumo.IdClasificacion = catalogos.Idcat 
                INNER JOIN Materiales ON CFConsumo.IdMaterial = Materiales.IdMaterial 
                INNER JOIN MaterialesAlm ma ON Materiales.IdMaterial=ma.IdMaterial and ma.Status='A' 
                INNER JOIN NavesAlmacen na ON na.IdAlmacen=ma.IdAlmacen INNER JOIN CatProductos c ON c.IdProducto=CFConsumo.IdProducto 
                INNER JOIN Proveedores ON CFConsumo.IdProveedor = Proveedores.IdProveedor 
                WHERE (na.Idnave=c.Idnave) AND (catalogos.tipcat = 1) AND (Materiales.Estatus = 'Activo') AND (CFConsumo.IdProducto = 12304) ORDER BY CFConsumo.Renglon 
            </cadena>
        consulta += " "
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function tablaFracciones() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
                SELECT 1 'Bloq', Fracciones.Fraccion, CFFraccion.Costo, CFFraccion.Pagar, 0 Doble
                FROM CFFraccion INNER JOIN Fracciones ON CFFraccion.IdFraccion = Fracciones.IdFraccion 
                Where (CFFraccion.IdProducto = 12304) ORDER BY Fraccion 
            </cadena>
        consulta += " "
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function getDatosProducto(ByVal productoEstiloId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            SELECT pe.pres_productoid,ep.espr_estiloproductoid ,pr.prod_codigo 'Código',pr.prod_descripcion 'Descripción',
            m.marc_descripcion 'Marca', c.cole_descripcion 'Colección','' 'Grupo','' 'Tipo','' 'Aplicación',temp_nombre 'Temporada',
'' 'MarcaYuyin',pr.prod_modelo 'ModeloSicy',pr.prod_codcliente 'CodigoCliente',fa.fami_descripcion 'Familia',ln.linea_descripcion 'Linea',
            horma_descripcion 'Horma',ff.forr_descripcion 'Forro','' 'Suela',pl.piel_descripcion+' '+cc.color_descripcion 'PielColor',
            isnull(isnull(cliDos.clie_nombregenerico,clUno.clie_nombregenerico),'') Cliente,isnull(cliDos.clie_clienteid,clUno.clie_clienteid) idCliente,
			tt.talla_descripcion 'Corrida','' 'Corte',isnull(pe.pres_imagen,'') 'Imagen'
			FROM Programacion.Productos AS pr 
			INNER JOIN Programacion.ProductoEstilo AS pe oN pr.prod_productoid = pe.pres_productoid
            INNER JOIN Programacion.EstilosProducto AS ep ON pe.pres_estiloid = ep.espr_estiloproductoid
            INNER JOIN Programacion.Pieles AS pl ON ep.espr_pielid = pl.piel_pielid
            LEFT JOIN Programacion.Familias AS fa ON pe.pres_familiaid = fa.fami_familiaid
            INNER JOIN Programacion.Tallas AS tt ON ep.espr_tallaid = tt.talla_tallaid
            INNER JOIN Programacion.Colores AS cc ON ep.espr_colorid = cc.color_colorid
            INNER JOIN Programacion.PielMuestras AS pm ON ep.espr_pielmuestraid = pm.plmu_pielmuestraid
            INNER JOIN Programacion.Forros AS ff ON ep.espr_forroid = ff.forr_forroid
            left join Programacion.Colecciones as c on c.cole_coleccionid=pr.prod_coleccionid
            left join Programacion.Marcas as m on m.marc_marcaid=pr.prod_marcaid
            LEFT JOIN Programacion.Lineas ln ON pe.pres_lineaid = ln.linea_lineaid
            left join Programacion.Familias as f on f.fami_familiaid=pr.prod_familiaid
            left join Programacion.Colecciones as cl on cl.cole_coleccionid=pr.prod_coleccionid
            INNER JOIN Programacion.EstatusProducto st ON pe.pres_estatus = st.stpr_productoStatusId
			left join Programacion.ColeccionMarca cm on cm.coma_coleccionid=c.cole_coleccionid and  cm.coma_marcaid=m.marc_marcaid
			left join Cliente.Cliente clUno on clUno.clie_clienteid=pr.prod_clienteid  
			left join Cliente.Cliente cliDos on cliDos.clie_clienteid=pr.prod_clienteid             
			left join Programacion.Hormas on pe.pres_horma=horma_hormaid
			left join Programacion.Temporadas on temp_temporadaid=pr.prod_temporadaid          
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
        Dim consulta As String = "update Programacion.ProductoEstilo set pres_navedesarrollaid=" & idNave & ",pres_estatusdesarrollo='D' where pres_productoid=" & idProducto & ""

        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getMarcas() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                 select marc_descripcion Marca,marc_marcaid IdMarca from Programacion.Marcas
                order by marc_descripcion
            </cadena>

        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getColecciones(ByVal idMarca As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                 select cole_descripcion,cole_coleccionid from Programacion.Colecciones
                 left join Programacion.ColeccionMarca on cole_coleccionid=coma_coleccionid
            </cadena>
        If idMarca > 0 Then
            consulta += " where coma_marcaid=" & idMarca & " order by cole_descripcion"
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
    Public Function listadoProductosSinNave(ByVal idMarca As Integer, ByVal idColecc As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = <cadena>
            SELECT  pe.pres_productoestiloid productoEstiloId,pe.pres_productoid,ep.espr_estiloproductoid ,'' Imagen,pe.pres_imagen 'Ruta',pe.pres_codSicy 'Código',
            m.marc_marcaid idMarca,m.marc_descripcion 'Marca',c.cole_coleccionid idColeccion,c.cole_descripcion 'Colección',
            pr.prod_codigo 'Modelo',pl.piel_pielid idPiel ,pl.piel_descripcion 'Piel',cc.color_colorid idColor, cc.color_descripcion 'Color',
            tt.talla_tallaid idTalla,tt.talla_descripcion 'Corrida',fa.fami_familiaid idFamilia,fa.fami_descripcion 'Familia',
			ln.linea_lineaid idLinea,ln.linea_descripcion 'Linea',
            isnull(cliDos.clie_nombregenerico,clUno.clie_nombregenerico) Cliente,isnull(cliDos.clie_clienteid,clUno.clie_clienteid) idCliente FROM Programacion.Productos AS pr 
			INNER JOIN Programacion.ProductoEstilo AS pe oN pr.prod_productoid = pe.pres_productoid
            INNER JOIN Programacion.EstilosProducto AS ep ON pe.pres_estiloid = ep.espr_estiloproductoid
            INNER JOIN Programacion.Pieles AS pl ON ep.espr_pielid = pl.piel_pielid
            LEFT JOIN Programacion.Familias AS fa ON pe.pres_familiaid = fa.fami_familiaid
            INNER JOIN Programacion.Tallas AS tt ON ep.espr_tallaid = tt.talla_tallaid
            INNER JOIN Programacion.Colores AS cc ON ep.espr_colorid = cc.color_colorid
            INNER JOIN Programacion.PielMuestras AS pm ON ep.espr_pielmuestraid = pm.plmu_pielmuestraid
            INNER JOIN Programacion.Forros AS ff ON ep.espr_forroid = ff.forr_forroid
            left join Programacion.Colecciones as c on c.cole_coleccionid=pr.prod_coleccionid
            left join Programacion.Marcas as m on m.marc_marcaid=pr.prod_marcaid
            LEFT JOIN Programacion.Lineas ln ON pe.pres_lineaid = ln.linea_lineaid
            left join Programacion.Familias as f on f.fami_familiaid=pr.prod_familiaid
            left join Programacion.Colecciones as cl on cl.cole_coleccionid=pr.prod_coleccionid
            INNER JOIN Programacion.EstatusProducto st ON pe.pres_estatus = st.stpr_productoStatusId
			left join Programacion.ColeccionMarca cm on cm.coma_coleccionid=c.cole_coleccionid and  cm.coma_marcaid=m.marc_marcaid
			left join Cliente.Cliente clUno on clUno.clie_clienteid=pr.prod_clienteid  
			left join Cliente.Cliente cliDos on cliDos.clie_clienteid=pr.prod_clienteid             
			where pe.pres_navedesarrollaid is null          
        </cadena>
        If idMarca > 0 Then
            consulta += " and m.marc_marcaid=" & idMarca & " "
        End If
        If idColecc > 0 Then
            consulta += " and c.cole_coleccionid=" & idColecc & " "
        End If
        consulta += " AND pl.piel_activo = 1 AND tt.talla_activo = 1 AND cc.color_activo = 1 AND pm.plmu_activo = 1 AND ff.forr_activo = 1 and pe.pres_activo=1"
        consulta += " order by Colección, Modelo, Corrida"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function VerListaProductos(ByVal naveid As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                 select 
                0 ' ',
                prod.prod_codigo 'Código',pe.pres_productoestiloid 'EstiloID',prod.prod_descripcion 'Colección',prod.prod_modelo 'Modelo',
                p.piel_descripcion 'Piel',c.color_descripcion 'Color',t.talla_descripcion 'Corrida',
                pe.pres_totalconsumos 'Total Materiales',pe.pres_totalfracciones 'Total Fracciones',
                pnp.pena_fechaasignacion 'Asignación Producción',
				Estatus= case pe.pres_estatusdesarrollo  when 'D' then 'DESARROLLO'  when 'AD' then 'AUTORIZADO DESARROLLO'
				 when 'AP' then 'AUTORIZADO PRODUCCIÓN'  when 'I' then 'INACTIVO NAVE'  when 'DP' then 'DESCONTINUADO' end, 
				cl.clie_razonsocial 'Cliente'
                from Programacion.ProductoEstilo as pe
                left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid
                left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
                left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
                left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
                left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
                left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
                left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
            </cadena>
        consulta += "where pena_naveid=" + naveid.ToString + "or pe.pres_navedesarrollaid=" + naveid.ToString + " and pe.pres_activo=1"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function VerListaProductosPorNaveyEstatus(ByVal naveid As Integer, ByVal estatus As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select 
                0 ' ',
                prod.prod_codigo 'Código',prod.prod_descripcion 'Colección',prod.prod_modelo 'Modelo',
                p.piel_descripcion 'Piel',c.color_descripcion 'Color',t.talla_descripcion 'Corrida',
                pe.pres_totalconsumos 'Total Materiales',pe.pres_totalfracciones 'Total Fracciones',
                pnp.pena_fechaasignacion 'Asignación Producción',
				Estatus= case pe.pres_estatusdesarrollo  when 'D' then 'DESARROLLO'  when 'AD' then 'AUTORIZADO DESARROLLO'
				 when 'AP' then 'AUTORIZADO PRODUCCIÓN'  when 'I' then 'INACTIVO NAVE'  when 'DP' then 'DESCONTINUADO' end, 
				cl.clie_razonsocial 'Cliente'
                from Programacion.ProductoEstilo as pe
                left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid
                left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
                left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
                left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
                left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
                left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
                left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
            </cadena>
        consulta += " where pena_naveid=" + naveid.ToString + "or pe.pres_navedesarrollaid=" + naveid.ToString + " and pe.pres_estatusdesarrollo='" + estatus + "'  and pe.pres_activo=1"
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function listaDepartamentos() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select IdDepto 'ID', Departamento 'Departamento' from Materiales.departamentos where nave=7"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function listaComponente() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select comp_componenteid 'ID', comp_descripción 'Componente' , comp_activo 'Activo' from Produccion.Componentes"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function listaClasificaciones() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select idClas 'ID', nombreClas 'Clasificación' from Materiales.Clasificaciones"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function listaProveedores() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select idClas 'ID', nombreClas 'Clasificación' from Materiales.Clasificaciones"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function ComponenteRepetido(ByVal componente As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select comp_componenteid from Produccion.Componentes where comp_descripción like '%" & componente & "%'"
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

    Public Function getconsumos(ByVal productoEstiloId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select cd.code_bloqueado 'Bloqueado',cd.code_explosionar 'Explosionar',cd.code_lotear 'Lotear',
            c.comp_componenteid 'idComponente',c.comp_descripción 'Componente',cl.idClas 'idClasificacion', cl.nombreClas 'Clasificación',
            m.dage_materialid 'IdMaterial',m.dage_sku 'SKU',
            m.dage_descripcion 'Material',cd.code_consumodesarrolloid 'idConsumo', cd.code_consumo 'Consumo',um2.idUnidad 'idUMConsumo',um2.descripcion 'UM Consumo',
            p.prov_proveedorid 'idProveedor', p.prov_nombregenerico 'Proveedor',cd.code_preciocompra 'Precio Compra',um1.idUnidad 'idUMProv',um1.descripcion 'UM Proveedor',
            cd.code_factorconversion 'Factor',cd.code_precioumproduccion 'PrecioUM',
            (cd.code_precioumproduccion *cd.code_consumo) 'Costo X Par',pe.pres_productoestiloid 'productoEstiloId'
            from Materiales.Materiales m inner join Produccion.ConsumosDesarrollo cd ON
            cd.code_materialid=m.dage_materialid inner join Produccion.Componentes c on 
            cd.code_componenteid=c.comp_componenteid inner join Materiales.Clasificaciones cl ON
            cl.idClas=cd.code_clasificacionid inner join Materiales.UnidadDeMedida um1 ON
            um1.idUnidad=cd.code_umproveedorid left join Materiales.UnidadDeMedida um2 ON
            um2.idUnidad=cd.code_umproduccionid left join Proveedor.Proveedor p ON
            p.prov_proveedorid=cd.code_proveedorid inner join Programacion.ProductoEstilo pe ON
            pe.pres_productoestiloid=cd.code_productoestiloid
            </cadena>
        consulta += " where pe.pres_productoestiloid=" & productoEstiloId & ""
        Dim c As String = ""
        c = <cadena2>
                      Union select 0 'Bloqueado',0 'Explosionar',0 'Lotear',
            0 'idComponente','' 'Componente',0 'idClasificacion', '' 'Clasificación',
            0 'IdMaterial','' 'SKU',
            '' 'Material',0 'idConsumo', '' 'Consumo',0 'idUMConsumo','' 'UM Consumo',
            0 'idProveedor', '' 'Proveedor',0.00 'Precio Compra',0 'idUMProv','' 'UM Proveedor',
           0.0 'Factor',0.0 'PrecioUM',
            0.0 'Costo X Par',0 'productoEstiloId'
                  </cadena2>
        consulta += " " & c
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function eliminarConsumos(ByVal productoEstiloId) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = " delete Produccion.ConsumosDesarrollo where code_productoestiloid=" & productoEstiloId & ""
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function insertConsumo(ByVal c As Consumo) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@totalConsumos"
        parametro.Value = c.totalConsumo
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
        Return objPersistencia.EjecutarConsultaSP("[Materiales].[SP_InsertConsumo]", listaparametros)
    End Function

    Public Function listaMarcas() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select marc_marcaid 'ID', marc_descripcion 'Marca' from Programacion.Marcas"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function listaColeccion(ByVal idMarca As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select c.cole_coleccionid 'ID', c.cole_descripcion 'Coleccion' 
            from Programacion.ColeccionMarca as cm
            join Programacion.Colecciones as c on c.cole_coleccionid=cm.coma_coleccionid
            where cm.coma_marcaid=
        </cadena>
        consulta += idMarca.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function tablaConsumosss() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select 
                0 ' ',
                prod.prod_codigo 'Código',pe.pres_productoestiloid 'EstiloID',prod.prod_descripcion 'Colección',prod.prod_modelo 'Modelo',
                p.piel_descripcion 'Piel',c.color_descripcion 'Color',t.talla_descripcion 'Corrida',
                pe.pres_totalconsumos 'Total Materiales',pe.pres_totalfracciones 'Total Fracciones',
                pnp.pena_fechaasignacion 'Asignación Producción',
				Estatus= case pe.pres_estatusdesarrollo  when 'D' then 'DESARROLLO'  when 'AD' then 'AUTORIZADO DESARROLLO'
				 when 'AP' then 'AUTORIZADO PRODUCCIÓN'  when 'I' then 'INACTIVO NAVE'  when 'DP' then 'DESCONTINUADO' end, 
				cl.clie_razonsocial 'Cliente'
                from Programacion.ProductoEstilo as pe
                left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid
                left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
                left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
                left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
                left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
                left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
                left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
            </cadena>
        consulta += " "
        Return operacion.EjecutaConsulta(consulta)
    End Function
End Class
