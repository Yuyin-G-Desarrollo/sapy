
Imports System.Data.SqlClient
Public Class TarjetaProduccionDA

    Public Function LotesPrograma(ByVal nave As Integer, ByVal fecha As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@IdNaveSay"
        parametro.Value = nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fecha"
        parametro.Value = fecha
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaTarjetaProduccionGrid]", listaParametros)


        '           <cadena>
        '              /*SELECT DISTINCT 0 ' ' ,
        '               l.lote_lote 'Lote',pe.pres_productoestiloid 'Pe',p.prod_descripcion 'Colección',p.prod_modelo 'Modelo',
        '               piel.piel_descripcion+' '+col.color_descripcion 'Corte',h.horma_descripcion 'Horma',m.mate_descripcion'Suela',
        '               l.lote_pares 'Pares',t.talla_descripcion 'Corrida',lap.lota_nomcortocortadorPielSay 'Cortador Piel',lap.lota_nomcortocortadorForroSay 'Cortador Forro',isnull(cp2.ConsumoDCM,0)'DCM x Par',
        '               isnull(f2.Costo,0) 'Costo Total',isnull(f.tiempo,0) 'Tiempo',l.lote_textocliente 'Cliente'
        '               FROM Produccion.LoteProduccionSicy as l
        '               inner join Produccion.LoteAProduccionSicy  as lap on lap.lota_lote=l.lote_lote and lap.lota_naveid=<%= nave %> and  lap.lota_fechaprogramacion='<%= fecha %>' 
        '               inner join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=l.lote_productoestiloid
        '               inner join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
        '               inner join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
        '               inner join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '               inner join Programacion.Colores as col on col.color_colorid=ep.espr_colorid
        '               inner join Programacion.Pieles as piel on piel.piel_pielid=ep.espr_pielid
        '               inner join Programacion.Tallas as t on t.talla_tallaid=l.lote_corridasayid
        '               inner join Programacion.Hormas as h on h.horma_hormaid=pe.pres_horma
        '               LEFT JOIN Produccion.ConsumosProduccion AS cp ON cp.copr_productoestiloid=l.lote_productoestiloid
        '               LEFT join (SELECT copr_productoestiloid,sum(copr_consumo) as 'ConsumoDCM' FROM Produccion.ConsumosProduccion INNER JOIN Produccion.ProductoNaveProduccion ON copr_productonaveid=pena_productonaveid AND pena_estatus='AP' AND pena_naveid=<%= nave %> 
        '               INNER JOIN Produccion.Componentes ON copr_componenteid=comp_componenteid
        '               INNER JOIN Materiales.Clasificaciones ON copr_clasificacionid=clas_idclasificacion WHERE comp_descripción='PIEL' AND clas_nombreclas='PIEL' GROUP BY copr_productoestiloid) as cp2 on cp2.copr_productoestiloid=pe.pres_productoestiloid
        '               INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %> 
        '               left join (SELECT fd_productoestiloid, sum( (fd_tiempohoras*60) + fd_tiempominutos + (CONVERT(decimal(10,2), convert(decimal(10,2),fd_tiemposegundos)/60))) AS 'tiempo' FROM Produccion.FraccionesDesarrollo where fd_naveid=<%= nave %> AND fd_sumartiempo=1 GROUP BY fd_productoestiloid) as f on f.fd_productoestiloid=l.lote_productoestiloid
        '			left JOIN (SELECT fd_productoestiloid, sum(fd_costo) AS 'costo' FROM Produccion.FraccionesDesarrollo where fd_naveid=<%= nave %> AND fd_sumarcosto=1 GROUP BY fd_productoestiloid) as f2 on f2.fd_productoestiloid=l.lote_productoestiloid
        '               inner join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
        '               inner join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid 
        '               and cp.copr_componenteid=(select comp_componenteid from Produccion.Componentes where comp_descripción='SUELA')*/


        '                select DISTINCT 0 ' ',
        ' l.lote_lote 'Lote',pe.pres_productoestiloid 'Pe', pe.coleccion 'Colección', pe.prod_codigo 'Modelo', pe.pielColor 'Corte',pe.Horma 'Horma',
        ' l.lote_pares 'Pares', pe.talla 'Corrida',lap.lota_nomcortocortadorPielSay 'Cortador Piel',lap.lota_nomcortocortadorForroSay 'Cortador Forro',
        ' l.lote_textocliente 'Cliente'
        'FROM Produccion.LoteProduccionSicy as l
        'inner join Produccion.LoteAProduccionSicy  as lap on lap.lota_lote=l.lote_lote and lap.lota_naveSicy=l.lote_navesicyid and  l.lote_año=lap.lota_anio
        'inner join vProductoEstilos as pe on pe.pres_productoestiloid=l.lote_productoestiloid

        '               WHERE l.lote_navesayid=<%= nave %> AND l.lote_fechaprograma='<%= fecha %>'
        '           </cadena>
        '        Dim consulta As String = <cadena>
        '        select DISTINCT 0 ' ',l.lote_lote 'Lote',pe.pres_productoestiloid 'Pe', pe.coleccion 'Colección', pe.prod_codigo 'Modelo', 
        '        pe.pielColor 'Corte',pe.Horma 'Horma',m.mate_descripcion 'Suela',l.lote_pares 'Pares', pe.talla 'Corrida',
        '        lap.lota_nomcortocortadorPielSay 'Cortador Piel',lap.lota_nomcortocortadorForroSay 'Cortador Forro',
        '        isnull(cp2.ConsumoDCM, 0) 'DCM x Par',isnull(f.Costo,0) 'Costo Total',isnull(f.tiempo,0) 'Tiempo',
        '        l.lote_textocliente 'Cliente'
        'FROM Produccion.LoteProduccionSicy as l
        'inner join Produccion.LoteAProduccionSicy  as lap on lap.lota_lote=l.lote_lote and lap.lota_naveSicy=l.lote_navesicyid and  l.lote_año=lap.lota_anio
        'inner join vProductoEstilos as pe on pe.pres_productoestiloid=l.lote_productoestiloid
        'LEFT JOIN Produccion.ConsumosProduccion AS cp ON cp.copr_productoestiloid=l.lote_productoestiloid and cp.copr_activo=1 and cp.copr_componenteid=9
        'inner join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
        'inner join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid 
        'left join (SELECT fd_productoestiloid, sum( (fd_tiempohoras*60) + fd_tiempominutos + (CONVERT(decimal(10,2), convert(decimal(10,2),fd_tiemposegundos)/60))) AS 'tiempo',sum(fd_costo) AS 'costo'  FROM Produccion.FraccionesDesarrollo where fd_naveid=<%= nave %> AND fd_sumartiempo=1 GROUP BY fd_productoestiloid) as f on f.fd_productoestiloid=l.lote_productoestiloid
        'LEFT join (SELECT copr_productoestiloid,sum(copr_consumo) as 'ConsumoDCM' FROM Produccion.ConsumosProduccion cpp GROUP BY copr_productoestiloid) as cp2 on cp2.copr_productoestiloid=pe.pres_productoestiloid
        'WHERE l.lote_navesayid=<%= nave %> AND l.lote_fechaprograma='<%= fecha %>'
        '        </cadena>
        '        Return operacion.EjecutaConsulta(consulta)
    End Function

End Class
