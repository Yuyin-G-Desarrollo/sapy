Imports System.Data.SqlClient
Imports Entidades

Public Class ReportesDA

    'Variables XML
    '<%=VARIABLE%>

    ''' <summary>
    ''' Obtener id nave de sicy con id de la nave say
    ''' </summary>
    ''' <param name="naveSay"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConsultarNaveSicy(ByVal naveSay As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select nave_navesicyid from Framework.Naves where nave_naveid=<%= naveSay %>
            </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Consulta para obtener el id de la clasificación seleccionada
    ''' </summary>
    ''' <param name="clasificacion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ObtenerClasificacion(ByVal clasificacion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select clas_idclasificacion 
                from Materiales.Clasificaciones where clas_nombreclas like '<%= clasificacion %>' and clas_status=1
            </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Consulta para obtener los id de clasificaciones similares ejemplo Herraje1, Herraje2, Herraje3, etc
    ''' </summary>
    ''' <param name="componente"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ObtenerIdComponentes(ByVal componente As String, ByVal componente2 As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select clas_idclasificacion from Materiales.Clasificaciones 
                where clas_nombreclas like '<%= componente %>' and clas_status=1
                          </cadena>
        If componente2 <> "" Then
            consulta += " and clas_nombreclas not like '%" + componente2 + "%' "
        End If
        Return operacion.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' obtener el id de los componentes
    ''' </summary>
    ''' <param name="componente"></param>
    ''' <param name="componente2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ObtenerComponentes(ByVal componente As String, ByVal componente2 As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select comp_componenteid from Produccion.Componentes
                where comp_descripción like '<%= componente %>' and comp_activo=1 
                          </cadena>
        If componente2 <> "" Then
            consulta += " and comp_descripción not like '%" + componente2 + "%' "
        End If
        Return operacion.EjecutaConsulta(consulta)
    End Function

    ' ''' <summary>
    ' ''' Consulta para obtener el concentrado de planta, suela por proveedor
    ' ''' </summary>
    ' ''' <param name="fechaPrograma"></param>
    ' ''' <param name="nave"></param>
    ' ''' <param name="clasificacion"></param>
    ' ''' <param name="proveedor"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function ConcentradoFormato5(ByVal fechaPrograma As String, ByVal nave As Integer,
    '                                    ByVal clasificacion As Integer) As DataTable
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String =
    '        <cadena>
    '            select '' 'No',
    '   sum(lap.lota_cantidad) 'Pares',count(lp.lote_lote) 'Lotes', 
    'm.mate_descripcion 'Material','' 'Coleccion',
    '            t.talla_descripcion'Corrida',pro.prov_razonsocial 'Proveedor',
    '            t.talla_t1 'tl1',t.talla_t2 'tl2',t.talla_t3 'tl3',t.talla_t4 'tl4',t.talla_t5 'tl5',t.talla_t6 'tl6',
    '            t.talla_t7 'tl7',t.talla_t8 'tl8',t.talla_t9 'tl9',t.talla_t10 'tl10',t.talla_t11 'tl11',t.talla_t12 'tl12',
    '            t.talla_t13 'tl13',t.talla_t14 'tl14',t.talla_t15 'tl15',t.talla_t16 'tl16',t.talla_t17 'tl17',t.talla_t18 'tl18',
    '            t.talla_t19 'tl19',t.talla_t20 'tl20'
    '            ,sum(lap.lota_lt1) 't1',sum(lap.lota_lt2) 't2',sum(lap.lota_lt3) 't3',sum(lap.lota_lt4)'t4',sum(lap.lota_lt5)'t5',
    '            sum(lap.lota_lt6)'t6',sum(lap.lota_lt7)'t7',sum(lap.lota_lt8)'t8',sum(lap.lota_lt9)'t9',sum(lap.lota_lt10)'t10',
    '            sum(lap.lota_lt11)'t11',sum(lap.lota_lt12)'t12',sum(lap.lota_lt13)'t13',sum(lap.lota_lt14)'t14',sum(lap.lota_lt15)'t15',
    '            sum(lap.lota_lt16)'t16',sum(lap.lota_lt17)'t17',sum(lap.lota_lt18)'t18',sum(lap.lota_lt19)'t19',sum(lap.lota_lt20)'t20'
    '            from Produccion.LoteProduccionSicy as lp
    '            left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid
    '            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
    '   left join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=lp.lote_productoestiloid
    '            INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
    '   left join Programacion.Colecciones as col on col.cole_coleccionid=p.prod_coleccionid
    '            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
    '            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
    '   left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
    '   left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
    '            left join Produccion.CortadorPielForro as cpf on cpf.copf_cortadorpielforroid=lp.lote_cortadorpielid
    '            left join Nomina.Colaborador as c on c.codr_colaboradorid=cpf.copf_colaboradorid
    '            left join Produccion.LoteAProduccionSicy  as lap on lap.lota_lote=lp.lote_lote and lap.lota_naveid=<%= nave %> and lap.lota_fechaprogramacion='<%= fechaPrograma %>'  
    '            left join Proveedor.Proveedor as pro on pro.prov_proveedorid=cp.copr_proveedorid 
    '            where lp.lote_fechaprograma = '<%= fechaPrograma %>' and lp.lote_navesayid=<%= nave %> and cp.copr_clasificacionid=<%= clasificacion %> and cp.copr_activo=1
    '            GROUP BY m.mate_descripcion,t.talla_descripcion,pro.prov_razonsocial,t.talla_t1 ,t.talla_t2 ,t.talla_t3,t.talla_t4 ,t.talla_t5 ,t.talla_t6 ,t.talla_t7 ,t.talla_t8 ,t.talla_t9 ,t.talla_t10 ,t.talla_t11 ,t.talla_t12 ,
    '            pro.prov_razonsocial,t.talla_t13 ,t.talla_t14 ,t.talla_t15 ,t.talla_t16 ,t.talla_t17 ,t.talla_t18,t.talla_t19 ,t.talla_t20,t.talla_descripcion 
    '            order by m.mate_descripcion
    '        </cadena>
    '    Return operacion.EjecutaConsulta(consulta)
    'End Function

    Public Function ConcentradoFormato5(ByVal fechaPrograma As String, ByVal idNave As Integer,
                                    ByVal idClasificacion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pFechaPrograma"
        parametro.Value = fechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdNave"
        parametro.Value = idNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdClasificacion"
        parametro.Value = idClasificacion
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Produccion.SP_Produccion_ReporteConcentradoFormato5", listaparametros)
    End Function

    ''' <summary>
    ''' Consulta para Materiales CAJA,PLANTA,SUELAS (FORMATO 2)
    ''' </summary>
    ''' <param name="fechaPrograma"></param>
    ''' <param name="nave"></param>
    ''' <param name="clasificacion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReporteMaterialesFormato2(ByVal fechaPrograma As String, ByVal nave As Integer,
                                              ByVal clasificacion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select ROW_NUMBER () OVER (ORDER BY lote_lote) 'No',
                lp.lote_pares 'Pares',lote_lote 'Lote',m.mate_descripcion 'Material',
                t.talla_descripcion'Corrida',c.cole_descripcion 'Colección',pro.dage_nombrecomercial 'Proveedor'
                from Produccion.LoteProduccionSicy as lp
                left join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=lp.lote_productoestiloid
                INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
                left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
                left join Materiales.MaterialesPrecio as mp on mp.prma_idMaterialNave=mn.mn_materialNaveid
                left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
                left join Programacion.Tallas as t on t.talla_tallaid=lp.lote_corridasayid
                left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid
                left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
                left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
				left join Proveedor.Proveedor pro dg on pro.prov_proveedorid=cp.copr_proveedorid
            </cadena>
        consulta += " where lp.lote_fechaprograma = '" + fechaPrograma + "' and lp.lote_navesicyid=" + nave.ToString + " and cp.copr_clasificacionid=" + clasificacion.ToString
        consulta += " and cp.copr_activo=1"
        consulta += " order by c.cole_descripcion"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    '' <summary>
    '' Consulta para Materiales CAJA,PLANTA,SUELAS (FORMATO 2)
    '' </summary>
    '' <param name="fechaPrograma"></param>
    '' <param name="nave"></param>
    '' <param name="clasificacion"></param>
    ''
    '' <returns></returns>
    '' <remarks></remarks>
    Public Function ReporteMaterialesFormatoPlanta(ByVal fechaPrograma As String, ByVal nave As Integer,
                                              ByVal clasificacion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@FechaPrograma"
        parametro.Value = fechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = nave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClasificacionId"
        parametro.Value = clasificacion
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Obtiene_ReportePlanta]", listaparametros)
    End Function
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String =
    '        <cadena>
    '            select sum(lap.lota_cantidad) 'Pares',lp.lote_lote 'Lote', 
    'm.mate_descripcion 'Material',t.talla_descripcion'Corrida',h.horma_descripcion'Coleccion',
    'pro.prov_razonsocial 'Proveedor' 
    '            from Produccion.LoteProduccionSicy as lp 
    '            left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid 
    '            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid 
    '            left join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=lp.lote_productoestiloid and cp.copr_clasificacionid=<%= clasificacion %> 
    '            INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %> 
    '            left join Programacion.Colecciones as col on col.cole_coleccionid=p.prod_coleccionid 
    '            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid 
    '            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid 
    '            left join Programacion.Hormas as h on h.horma_hormaid=pe.pres_horma 
    '            left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid 
    '            left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid 
    '            left join Produccion.LoteAProduccionSicy as lap on lap.lota_lote=lp.lote_lote and lap.lota_naveid=<%= nave %> and lap.lota_fechaprogramacion='<%= fechaPrograma %>'  
    '            left join  Proveedor.Proveedor as pro on pro.prov_proveedorid=cp.copr_proveedorid
    '            where lp.lote_fechaprograma = '<%= fechaPrograma %>' and lp.lote_navesayid=<%= nave %> and cp.copr_activo=1 and cp.copr_clasificacionid=<%= clasificacion %>
    '            GROUP BY m.mate_descripcion,h.horma_descripcion,t.talla_descripcion,pro.prov_razonsocial,t.talla_descripcion,lp.lote_lote order by lp.lote_lote
    '        </cadena>
    '    Return operacion.EjecutaConsulta(consulta)
    'End Function

    Public Function ReporteMaterialesFormato2Planta(ByVal FechaPrograma As String, ByVal Nave As Integer, ByVal Clasificacion As Integer)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@FechaPrograma"
        parametro.Value = FechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = Nave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClasificacionId"
        parametro.Value = Clasificacion
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Produccion_MaterialesFormato2]", listaparametros)
    End Function


    Public Function DesglosadoCaja(ByVal FechaPrograma As String, ByVal Nave As Integer, ByVal Clasificacion As Integer)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@FechaPrograma"
        parametro.Value = FechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = Nave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClasificacionId"
        parametro.Value = Clasificacion
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ReporteDesglosadoCaja]", listaparametros)
    End Function

    ''' <summary>
    ''' Consulta para Materiales CAJA,PLANTA,SUELAS (FORMATO 2)
    ''' </summary>
    ''' <param name="fechaPrograma"></param>
    ''' <param name="nave"></param>
    ''' <param name="clasificacion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReporteMaterialesFormato2Caja(ByVal fechaPrograma As String, ByVal nave As Integer,
                                              ByVal clasificacion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select sum(lap.lota_cantidad) 'Pares',lp.lote_lote 'Lotes', 
				m.mate_descripcion 'Material',t.talla_descripcion'Corrida',col.cole_descripcion'Coleccion',
				pro.prov_nombregenerico  'Proveedor'
                from Produccion.LoteProduccionSicy as lp
                left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid
                left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
			    left join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=lp.lote_productoestiloid
                INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
			    left join Programacion.Colecciones as col on col.cole_coleccionid=p.prod_coleccionid
                left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
                left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
				left join Programacion.Hormas as h on h.horma_hormaid=pe.pres_horma
			    left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
			    left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
                left join Produccion.CortadorPielForro as cpf on cpf.copf_cortadorpielforroid=lp.lote_cortadorpielid
                left join Nomina.Colaborador as c on c.codr_colaboradorid=cpf.copf_colaboradorid
                left join Produccion.LoteAProduccionSicy  as lap on lap.lota_lote=lp.lote_lote 
                left join Proveedor.Proveedor as pro on pro.prov_proveedorid=cp.copr_proveedorid 
                where lp.lote_fechaprograma = '<%= fechaPrograma %>' and lp.lote_navesicyid=<%= nave %> and cp.copr_clasificacionid=<%= clasificacion %>
                GROUP BY m.mate_descripcion,h.horma_descripcion,t.talla_descripcion,pro.prov_nombregenerico,t.talla_descripcion,lp.lote_lote,col.cole_descripcion
            </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Consulta para Orden de producción
    ''' </summary>
    ''' <param name="fechaPrograma"></param>
    ''' <param name="nave"></param>
    ''' <param name="clasificacion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReporteOrdenesDeProduccion(ByVal fechaPrograma As String, ByVal nave As Integer,
                                              ByVal clasificacion As Integer) As DataTable
        '    Dim operacion As New Persistencia.OperacionesProcedimientos
        '    Dim consulta As String =
        '        <cadena>
        '            select
        '            lote_pares 'Pares',lote_lote 'Lote',m.marc_descripcion+' '+c.cole_descripcion'Colección',p.prod_codigo 'Modelo',
        't.talla_descripcion 'Corrida',piel.piel_descripcion+' '+color.color_descripcion 'Color',mat.mate_descripcion 'Suela', 
        'cort.NombreCorto 'Cortador P',cort.NombreCorto 'Cortador F',
        'lp.lote_textocliente 'Cliente'
        '            from Produccion.LoteProduccionSicy as lp
        '            left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid
        '            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
        '            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        '            left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
        '            left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
        '            left join Programacion.Pieles as piel on piel.piel_pielid=ep.espr_pielid
        '            left join Programacion.Colores as color on color.color_colorid=ep.espr_colorid
        '            left join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=lp.lote_productoestiloid
        '            INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
        '            left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
        '            left join Materiales.Materiales as mat on mat.mate_materialid=mn.mn_materialid
        'left join Produccion.CortadorPielForro as cort on cort.IdCortador=lp.lote_cortadorpielid
        'inner join [192.168.2.2].[Yuyin_Respaldo].dbo.pdCortadores as cort2 on cort2.IdCortador=lp.lote_cortadorforroid 
        '            where lote_fechaprograma='<%= fechaPrograma %>' and lote_navesicyid=<%= nave %> and mat.mate_idClasificacion=<%= clasificacion %>
        '        </cadena>
        '    Return operacion.EjecutaConsulta(consulta)
    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''Consultas para armar reporte de concentrado de casco y contrafuerte ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    ' ''' <summary>
    ' ''' Consulta para traer la numeracion contenida en la corrida del Casco
    ' ''' </summary>
    ' ''' <param name="fechaPrograma"></param>
    ' ''' <param name="nave"></param>
    ' ''' <param name="clasificacion"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function ConsultaCasco1(ByVal fechaPrograma As String, ByVal nave As Integer,
    '                                          ByVal clasificacion As Integer) As DataTable
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String =
    '        <cadena>
    '            select count(l.lote_productoestiloid) 'Lotes',m.mate_descripcion 'Material',sum(la.lota_cantidad) 'Pares',dg.prov_razonsocial'Proveedor',
    '            t.talla_descripcion 'Corrida',talla_t1,talla_t2,talla_t3,talla_t4,talla_t5,talla_t6,talla_t7,talla_t8,
    '            talla_t9,talla_t10,talla_t11,talla_t12,talla_t13,talla_t14,talla_t15,talla_t16
    '            from Produccion.LoteProduccionSicy as l
    '            left join Produccion.LoteAProduccionSicy as la on la.lota_lote=l.lote_lote and la.lota_naveid=<%= nave %> and la.lota_fechaprogramacion='<%= fechaPrograma %>'  
    '            inner join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=l.lote_productoestiloid
    '            INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
    '            inner join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
    '            inner join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
    '            inner join Programacion.Tallas as t on t.talla_tallaid=l.lote_corridasayid
    '            left join Proveedor.Proveedor as dg on dg.prov_proveedorid=cp.copr_proveedorid
    '            where l.lote_fechaprograma='<%= fechaPrograma %>' and lote_navesayid=<%= nave %> and mate_idClasificacion=<%= clasificacion %> and cp.copr_activo=1
    '            GROUP by m.mate_descripcion,dg.prov_razonsocial,t.talla_descripcion,talla_t1,talla_t2,talla_t3,talla_t4,talla_t5,talla_t6,talla_t7,talla_t8,
    '            talla_t9,talla_t10,talla_t11,talla_t12,talla_t13,talla_t14,talla_t15,talla_t16 order by m.mate_descripcion
    '        </cadena>
    '    Return operacion.EjecutaConsulta(consulta)
    'End Function

    ''' <summary>
    ''' Consulta para traer la numeracion contenida en la corrida del Casco
    ''' </summary>
    ''' <param name="fechaPrograma"></param>
    ''' <param name="idNave"></param>
    ''' <param name="idClasificacion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConsultaCasco1(ByVal fechaPrograma As String, ByVal idNave As Integer,
                                              ByVal idClasificacion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pFechaPrograma"
        parametro.Value = fechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdNave"
        parametro.Value = idNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdClasificacion"
        parametro.Value = idClasificacion
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Produccion.SP_Produccion_ReporteConcentradoCasco1", listaparametros)
    End Function

    ' ''' <summary>
    ' ''' Consulta para traer el total de pares por talla del casco
    ' ''' </summary>
    ' ''' <param name="fechaPrograma"></param>
    ' ''' <param name="nave"></param>
    ' ''' <param name="clasificacion"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function ConsultaCasco2(ByVal fechaPrograma As String, ByVal nave As Integer,
    '                                          ByVal clasificacion As Integer) As DataTable
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String =
    '        <cadena>
    '            select  DISTINCT count(l.lote_productoestiloid),m.mate_descripcion,t.talla_descripcion 'Corrida', sum(la.lota_cantidad),
    '            sum(la.lota_lt1),sum(la.lota_lt2),sum(la.lota_lt3),sum(la.lota_lt4),sum(la.lota_lt5),sum(la.lota_lt6),
    '            sum(la.lota_lt7),sum(la.lota_lt8),sum(la.lota_lt9),sum(la.lota_lt10),sum(la.lota_lt11),sum(la.lota_lt12),
    '            sum(la.lota_lt13),sum(la.lota_lt14),sum(la.lota_lt15),sum(la.lota_lt16),sum(la.lota_lt17)
    '            from Produccion.LoteProduccionSicy as l
    '            left join Produccion.LoteAProduccionSicy as la on la.lota_lote=l.lote_lote and la.lota_naveid=<%= nave %> and la.lota_fechaprogramacion='<%= fechaPrograma %>'  
    '            left join Programacion.Tallas as t on t.talla_tallaid=l.lote_corridasayid
    '            left join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=l.lote_productoestiloid
    '            INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
    '            left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
    '            left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
    '            where  l.lote_fechaprograma='<%= fechaPrograma %>' and l.lote_navesayid=<%= nave %> and m.mate_idClasificacion=<%= clasificacion %> and cp.copr_activo=1
    '            group by m.mate_descripcion,t.talla_descripcion order by m.mate_descripcion
    '        </cadena>
    '    Return operacion.EjecutaConsulta(consulta)
    'End Function

    Public Function ConsultaCasco2(ByVal fechaPrograma As String, ByVal IdNave As Integer,
                                              ByVal idClasificacion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pFechaPrograma"
        parametro.Value = fechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdNave"
        parametro.Value = IdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdClasificacion"
        parametro.Value = idClasificacion
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Produccion.SP_Produccion_ReporteConcentradoCasco2", listaparametros)
    End Function

    ''' <summary>
    ''' Consulta para traer la numeracion contenida en la corrida del contrafuerte
    ''' </summary>
    ''' <param name="fechaPrograma"></param>
    ''' <param name="nave"></param>
    ''' <param name="clasificacion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConsultaContrafuerte1(ByVal fechaPrograma As String, ByVal nave As Integer,
                                              ByVal clasificacion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select count(l.lote_productoestiloid) 'Producto estilo',m.mate_descripcion 'Material',sum(la.lota_cantidad) 'Pares',
                t.talla_descripcion 'Corrida',talla_t1,talla_t2,talla_t3,talla_t4,talla_t5,talla_t6,talla_t7,talla_t8,
                talla_t9,talla_t10,talla_t11,talla_t12,talla_t13,talla_t14,talla_t15,talla_t16
                from Produccion.LoteProduccionSicy as l
                inner join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=l.lote_productoestiloid
                INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
                inner join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
                inner join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
                inner join Programacion.Tallas as t on t.talla_tallaid=l.lote_corridasayid
                left join Produccion.LoteAProduccionSicy  as la on la.lota_lote=l.lote_lote and la.lota_naveSicy=<%= nave %>
                WHERE lote_fechaprograma ='<%= fechaPrograma %>' and lote_navesayid=<%= nave %> and mate_idClasificacion=<%= clasificacion %>
                GROUP by m.mate_descripcion,t.talla_descripcion,talla_t1,talla_t2,talla_t3,talla_t4,talla_t5,talla_t6,talla_t7,talla_t8,
                talla_t9,talla_t10,talla_t11,talla_t12,talla_t13,talla_t14,talla_t15,talla_t16
            </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Consulta para traer el total de pares por talla del contrafuerte
    ''' </summary>
    ''' <param name="fechaPrograma"></param>
    ''' <param name="nave"></param>
    ''' <param name="clasificacion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConsultaContrafuerte2(ByVal fechaPrograma As String, ByVal nave As Integer,
                                              ByVal clasificacion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select  DISTINCT count(l.lote_productoestiloid),m.mate_descripcion,sum(la.lota_cantidad),t.talla_descripcion 'Corrida', 
                sum(la.lota_lt1),sum(la.lota_lt2),sum(la.lota_lt3),sum(la.lota_lt4),sum(la.lota_lt5),sum(la.lota_lt6),
                sum(la.lota_lt7),sum(la.lota_lt8),sum(la.lota_lt9),sum(la.lota_lt10),sum(la.lota_lt11),sum(la.lota_lt12),
                sum(la.lota_lt13),sum(la.lota_lt14),sum(la.lota_lt15),sum(la.lota_lt16)
                from Produccion.LoteProduccionSicy as l
                left join Produccion.LoteAProduccionSicy as la on la.lota_lote=l.lote_lote and la.lota_navesayid=<%= nave %>
                left join Programacion.Tallas as t on t.talla_tallaid=l.lote_corridasayid
                left join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=l.lote_productoestiloid
                INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
                left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
                left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
                where  la.lota_fechaprogramacion='<%= fechaPrograma %>' and la.lota_navesayid=<%= nave %> and m.mate_idClasificacion=<%= clasificacion %>
                group by m.mate_descripcion,t.talla_descripcion
            </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    ''' <summary>
    '''  Consulta para obtener la relacion concentrada de suelas
    ''' </summary>
    ''' <param name="fechaPrograma"></param>
    ''' <param name="nave"></param>
    ''' <param name="clasificacion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReporteRelacionDesglosadaDeSuela(ByVal fechaPrograma As String, ByVal nave As Integer,
                                              ByVal clasificacion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select ROW_NUMBER () OVER (ORDER BY lote_lote) 'No',
			    sum(lap.lota_cantidad) 'Pares',lp.lote_lote 'Lote' ,m.mate_descripcion 'Material',col.cole_descripcion'C5',t.talla_descripcion'Corrida',
                dg.prov_razonsocial 'Proveedor',
                t.talla_t1 'tl1',t.talla_t2 'tl2',t.talla_t3 'tl3',t.talla_t4 'tl4',t.talla_t5 'tl5',t.talla_t6 'tl6',
                t.talla_t7 'tl7',t.talla_t8 'tl8',t.talla_t9 'tl9',t.talla_t10 'tl10',t.talla_t11 'tl11',t.talla_t12 'tl12',
                t.talla_t13 'tl13',t.talla_t14 'tl14',t.talla_t15 'tl15',t.talla_t16 'tl16',t.talla_t17 'tl17',t.talla_t18 'tl18',
                t.talla_t19 'tl19',t.talla_t20 'tl20'
                ,sum(lap.lota_lt1) 't1',sum(lap.lota_lt2) 't2',sum(lap.lota_lt3) 't3',sum(lap.lota_lt4)'t4',sum(lap.lota_lt5)'t5',
                sum(lap.lota_lt6)'t6',sum(lap.lota_lt7)'t7',sum(lap.lota_lt8)'t8',sum(lap.lota_lt9)'t9',sum(lap.lota_lt10)'t10',
                sum(lap.lota_lt11)'t11',sum(lap.lota_lt12)'t12',sum(lap.lota_lt13)'t13',sum(lap.lota_lt14)'t14',sum(lap.lota_lt15)'t15',
                sum(lap.lota_lt16)'t16',sum(lap.lota_lt17)'t17',sum(lap.lota_lt18)'t18',sum(lap.lota_lt19)'t19',sum(lap.lota_lt20)'t20'
                from Produccion.LoteProduccionSicy as lp
                left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid
                left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
			    left join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=lp.lote_productoestiloid
                INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
			    left join Programacion.Colecciones as col on col.cole_coleccionid=p.prod_coleccionid
                left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
                left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
			    left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
			    left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
                left join Produccion.LoteAProduccionSicy  as lap on lap.lota_lote=lp.lote_lote and lap.lota_naveid=<%= nave %> and lap.lota_fechaprogramacion='<%= fechaPrograma %>'  
                left join Proveedor.Proveedor as dg on dg.prov_proveedorid=cp.copr_proveedorid
                where lp.lote_fechaprograma ='<%= fechaPrograma %>' and lp.lote_navesayid=<%= nave %> and cp.copr_clasificacionid=<%= clasificacion %> and cp.copr_activo=1
                GROUP BY lp.lote_lote ,p.prod_descripcion+' '+p.prod_modelo+' '+t.talla_descripcion,lp.lote_textocliente,m.mate_descripcion ,col.cole_descripcion,
                t.talla_t1 ,t.talla_t2 ,t.talla_t3,t.talla_t4 ,t.talla_t5 ,t.talla_t6 ,t.talla_t7 ,t.talla_t8 ,t.talla_t9 ,t.talla_t10 ,t.talla_t11 ,t.talla_t12 ,
                t.talla_t13 ,t.talla_t14 ,t.talla_t15 ,t.talla_t16 ,t.talla_t17 ,t.talla_t18 ,t.talla_t19 ,t.talla_t20,t.talla_descripcion,dg.prov_razonsocial
                order by lp.lote_lote, m.mate_descripcion 
            </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ReporteRelacionDesglosada(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal Clasificacion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaPrograma"
        parametro.Value = fechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = nave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdClasificacion"
        parametro.Value = Clasificacion
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Produccion_ReporteRelacion_Desglosado]", listaparametros)

    End Function

    Public Function ReporteRelacionDesglosadaPlantilla(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal Clasificacion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaPrograma"
        parametro.Value = fechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = nave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdClasificacion"
        parametro.Value = Clasificacion
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Produccion_ReporteRelacion_DesglosadoPlantilla]", listaparametros)

    End Function


    '''' <summary>
    '''' Consulta para obtener la relacion concentrada de planta
    '''' </summary>
    '''' <param name="fechaPrograma"></param>
    '''' <param name="nave"></param>
    '''' <param name="clasificacion"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    Public Function ReporteRelacionDesglosadaDePlanta(ByVal fechaPrograma As String, ByVal nave As Integer,
                                             ByVal clasificacion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaPrograma"
        parametro.Value = fechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = nave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdClasificacion"
        parametro.Value = clasificacion
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Obtiene_Reporte_RelacionDesglosada_Planta]", listaparametros)

    End Function

    '    Dim consulta As String =
    '        <cadena>
    '            select ROW_NUMBER () OVER (ORDER BY lote_lote) 'No',
    '   sum(lap.lota_cantidad) 'Pares',lp.lote_lote 'Lote' ,m.mate_descripcion 'Material',h.horma_descripcion'C5',t.talla_descripcion'Corrida',
    '            dg.prov_razonsocial 'Proveedor',
    '            t.talla_t1 'tl1',t.talla_t2 'tl2',t.talla_t3 'tl3',t.talla_t4 'tl4',t.talla_t5 'tl5',t.talla_t6 'tl6',
    '            t.talla_t7 'tl7',t.talla_t8 'tl8',t.talla_t9 'tl9',t.talla_t10 'tl10',t.talla_t11 'tl11',t.talla_t12 'tl12',
    '            t.talla_t13 'tl13',t.talla_t14 'tl14',t.talla_t15 'tl15',t.talla_t16 'tl16',t.talla_t17 'tl17',t.talla_t18 'tl18',
    '            t.talla_t19 'tl19',t.talla_t20 'tl20'
    '            ,sum(lap.lota_lt1) 't1',sum(lap.lota_lt2) 't2',sum(lap.lota_lt3) 't3',sum(lap.lota_lt4)'t4',sum(lap.lota_lt5)'t5',
    '            sum(lap.lota_lt6)'t6',sum(lap.lota_lt7)'t7',sum(lap.lota_lt8)'t8',sum(lap.lota_lt9)'t9',sum(lap.lota_lt10)'t10',
    '            sum(lap.lota_lt11)'t11',sum(lap.lota_lt12)'t12',sum(lap.lota_lt13)'t13',sum(lap.lota_lt14)'t14',sum(lap.lota_lt15)'t15',
    '            sum(lap.lota_lt16)'t16',sum(lap.lota_lt17)'t17',sum(lap.lota_lt18)'t18',sum(lap.lota_lt19)'t19',sum(lap.lota_lt20)'t20'
    '            from Produccion.LoteProduccionSicy as lp
    '            left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid
    '            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
    '   left join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=lp.lote_productoestiloid
    '            INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
    '   left join Programacion.Hormas as h on h.horma_hormaid=pe.pres_horma
    '            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
    '            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
    '   left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
    '   left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid  
    '            left join Produccion.LoteAProduccionSicy  as lap on lap.lota_lote=lp.lote_lote and lap.lota_naveid=<%= nave %> and lap.lota_fechaprogramacion='<%= fechaPrograma %>'  
    '            left join Proveedor.Proveedor as dg on dg.prov_proveedorid=cp.copr_proveedorid 
    '            where lp.lote_fechaprograma = '<%= fechaPrograma %>' and lp.lote_navesayid=<%= nave %> and cp.copr_clasificacionid=<%= clasificacion %> and cp.copr_activo=1 
    '            GROUP BY lp.lote_lote ,p.prod_descripcion+' '+p.prod_modelo+' '+t.talla_descripcion,lp.lote_textocliente,m.mate_descripcion ,h.horma_descripcion,
    '            t.talla_t1 ,t.talla_t2 ,t.talla_t3,t.talla_t4 ,t.talla_t5 ,t.talla_t6 ,t.talla_t7 ,t.talla_t8 ,t.talla_t9 ,t.talla_t10 ,t.talla_t11 ,t.talla_t12 ,
    '            t.talla_t13 ,t.talla_t14 ,t.talla_t15 ,t.talla_t16 ,t.talla_t17 ,t.talla_t18 ,t.talla_t19 ,t.talla_t20,t.talla_descripcion,dg.prov_razonsocial
    '            order by lp.lote_lote
    '        </cadena>
    '    Return operacion.EjecutaConsulta(consulta)
    'End Function

    Public Function ReporteRelacionDesglosadaDeCascoYContrafuerte(ByVal fechaPrograma As String, ByVal nave As Integer,
                                             ByVal clasificacion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        ' Dim consulta As String =
        '     <cadena>                
        '   select '' 'No',
        'lp.lote_pares 'Pares',lp.lote_lote 'Lote' ,m.mate_descripcion 'Material',m2.mate_descripcion 'C5',
        '         t.talla_descripcion'Corrida',dg.prov_razonsocial 'Proveedor',
        '         t.talla_t1 'tl1',t.talla_t2 'tl2',t.talla_t3 'tl3',t.talla_t4 'tl4',t.talla_t5 'tl5',t.talla_t6 'tl6',
        '         t.talla_t7 'tl7',t.talla_t8 'tl8',t.talla_t9 'tl9',t.talla_t10 'tl10',t.talla_t11 'tl11',t.talla_t12 'tl12',
        '         t.talla_t13 'tl13',t.talla_t14 'tl14',t.talla_t15 'tl15',t.talla_t16 'tl16',t.talla_t17 'tl17',t.talla_t18 'tl18',
        '         t.talla_t19 'tl19',t.talla_t20 'tl20'
        '         ,sum(lap.lota_lt1) 't1',sum(lap.lota_lt2) 't2',sum(lap.lota_lt3) 't3',sum(lap.lota_lt4)'t4',sum(lap.lota_lt5)'t5',
        '         sum(lap.lota_lt6)'t6',sum(lap.lota_lt7)'t7',sum(lap.lota_lt8)'t8',sum(lap.lota_lt9)'t9',sum(lap.lota_lt10)'t10',
        '         sum(lap.lota_lt11)'t11',sum(lap.lota_lt12)'t12',sum(lap.lota_lt13)'t13',sum(lap.lota_lt14)'t14',sum(lap.lota_lt15)'t15',
        '         sum(lap.lota_lt16)'t16',sum(lap.lota_lt17)'t17',sum(lap.lota_lt18)'t18',sum(lap.lota_lt19)'t19',sum(lap.lota_lt20)'t20'
        '         from Produccion.LoteProduccionSicy as lp
        '         left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid
        '         left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
        'left join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=lp.lote_productoestiloid
        '         INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
        'left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '         left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        'left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
        'left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
        'left join Produccion.ConsumosProduccion as cp2 on cp2.copr_productoestiloid=lp.lote_productoestiloid
        'left join Materiales.MaterialesNave as mn2 on mn2.mn_materialNaveid=cp2.copr_materialid
        'left join Materiales.Materiales as m2 on m2.mate_materialid=mn2.mn_materialid
        '         left join Proveedor.Proveedor as dg on dg.prov_proveedorid=cp.copr_proveedorid
        '         left join Produccion.LoteAProduccionSicy  as lap on lap.lota_lote=lp.lote_lote and lap.lota_naveid=<%= nave %> and lap.lota_fechaprogramacion='<%= fechaPrograma %>'  
        '         where lp.lote_fechaprograma = '<%= fechaPrograma %>' and lp.lote_navesayid=<%= nave %> and cp.copr_clasificacionid=<%= clasificacion %> and cp.copr_activo=1 and cp2.copr_clasificacionid=<%= clasificacion2 %> and cp2.copr_activo=1 
        '         GROUP BY lp.lote_lote ,p.prod_descripcion+' '+p.prod_modelo+' '+t.talla_descripcion,lp.lote_pares ,lp.lote_textocliente,m.mate_descripcion ,m2.mate_descripcion,
        '         dg.prov_razonsocial,t.talla_t1 ,t.talla_t2 ,t.talla_t3,t.talla_t4 ,t.talla_t5 ,t.talla_t6,t.talla_t7 ,t.talla_t8 ,t.talla_t9 ,t.talla_t10 ,t.talla_t11 ,t.talla_t12,
        '         t.talla_t13 ,t.talla_t14 ,t.talla_t15 ,t.talla_t16 ,t.talla_t17 ,t.talla_t18,t.talla_t19 ,t.talla_t20,t.talla_descripcion    
        '         order by lp.lote_lote, m.mate_descripcion
        '     </cadena>
        ' Return operacion.EjecutaConsulta(consulta)


        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@pFechaPrograma"
        parametro.Value = fechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdNave"
        parametro.Value = nave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdClasificacion"
        parametro.Value = clasificacion
        listaparametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@pIdClasificacion2"
        'parametro.Value = clasificacion2
        'listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Produccion_ReporteDesglosadoCasco]", listaparametros)




    End Function

    'Public Function ConsultaReporteParaCascoYContrafuerte(ByVal fechaPrograma As String, ByVal nave As Integer,
    '                                       ByVal clasificacion As Integer, ByVal clasificacion2 As Integer) As DataTable
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String =
    '        <cadena>                
    '     select '' 'No',
    '   lp.lote_pares 'Pares',lp.lote_lote 'Lote' ,m.mate_descripcion 'Casco',m2.mate_descripcion 'Contrafuerte',
    '            t.talla_descripcion'Corrida',c.cole_descripcion 'Coleccion',dg.prov_razonsocial 'Proveedor'              
    '            from Produccion.LoteProduccionSicy as lp
    '            left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid
    '            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
    '   left join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=lp.lote_productoestiloid
    '            INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
    '   left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
    '            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
    '   left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
    '   left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
    '   left join Produccion.ConsumosProduccion as cp2 on cp2.copr_productoestiloid=lp.lote_productoestiloid
    '   left join Materiales.MaterialesNave as mn2 on mn2.mn_materialNaveid=cp2.copr_materialid
    '   left join Materiales.Materiales as m2 on m2.mate_materialid=mn2.mn_materialid
    '            left join Proveedor.Proveedor as dg on dg.prov_proveedorid=cp.copr_proveedorid
    'left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
    '            left join Produccion.LoteAProduccionSicy  as lap on lap.lota_lote=lp.lote_lote and lap.lota_naveid=<%= nave %> and lap.lota_fechaprogramacion='<%= fechaPrograma %>'  
    '            where lp.lote_fechaprograma = '<%= fechaPrograma %>' and lp.lote_navesayid=<%= nave %> and cp.copr_clasificacionid=<%= clasificacion %> and cp2.copr_clasificacionid=<%= clasificacion2 %> and cp.copr_activo=1 and cp2.copr_activo=1
    '            GROUP BY lp.lote_lote ,p.prod_descripcion+' '+p.prod_modelo+' '+t.talla_descripcion,lp.lote_pares ,lp.lote_textocliente,m.mate_descripcion ,m2.mate_descripcion,
    '            dg.prov_razonsocial,t.talla_descripcion ,c.cole_descripcion order by lp.lote_lote
    '        </cadena>
    '    Return operacion.EjecutaConsulta(consulta)
    'End Function

    Public Function ConsultaReporteDesglosado(ByVal fechaProgramacion As String, ByVal nave As Integer, ByVal clasificacion As Integer, ByVal clasificacion2 As Integer)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaProgramacion"
        parametro.Value = fechaProgramacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = nave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClasificacionId"
        parametro.Value = clasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClasificacionId2"
        parametro.Value = clasificacion2
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Produccion_Reporte_Desglosado]", listaparametros)


    End Function



    '' Consulta para obtener el reporte de agujeta, plastisol


    Public Function ReporteDeFormato3(ByVal FechaProgramacion As String, ByVal Nave As Integer, ByVal Clasificacion As Integer)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaPrograma"
        parametro.Value = FechaProgramacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = Nave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClasificacionId"
        parametro.Value = Clasificacion
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ReporteDeFormato3]", listaparametros)


    End Function
    '                                         ByVal clasificacion As Integer) As DataTable
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String =
    '        <cadena>
    '            select distinct ROW_NUMBER () OVER (ORDER BY lote_lote) 'No',
    '            lp.lote_pares 'Pares',lote_lote 'Lote',c.cole_descripcion 'Coleccion', 
    'p.prod_codigo 'Modelo', VP.ModeloSICY 'ModeloSICY',piel.piel_descripcion+' '+col.color_descripcion'Color',
    't.talla_descripcion'Corrida',m.mate_descripcion 'Material',dg.prov_razonsocial 'Proveedor'
    'from Produccion.LoteProduccionSicy as lp
    '            left join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=lp.lote_productoestiloid
    '            INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
    '            left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
    '            left join Materiales.MaterialesPrecio as mp on mp.prma_idMaterialNave=mn.mn_materialNaveid
    '            left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
    '            left join Programacion.Tallas as t on t.talla_tallaid=lp.lote_corridasayid
    '            left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid
    '            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
    '            INNER JOIN Programacion.vProductoEstilos_Completo AS VP ON P.prod_productoid = VP.ProductoId
    '            left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
    'left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
    'left join Programacion.Pieles as piel on piel.piel_pielid=ep.espr_pielid
    'left join Programacion.Colores as col on col.color_colorid=ep.espr_colorid
    '            left join Proveedor.Proveedor as dg on dg.prov_proveedorid=cp.copr_proveedorid
    '            where lp.lote_fechaprograma = '<%= fechaPrograma %>' and lp.lote_navesayid=<%= nave %> and cp.copr_clasificacionid=<%= clasificacion %> and cp.copr_activo=1 
    '            GROUP BY lp.lote_pares,lote_lote,c.cole_descripcion, p.prod_codigo, VP.ModeloSICY, 
    '            piel.piel_descripcion+' '+col.color_descripcion, t.talla_descripcion,m.mate_descripcion,dg.prov_razonsocial
    '            order by lp.lote_lote
    '        </cadena>
    '    Return operacion.EjecutaConsulta(consulta)


    ''' <summary>
    ''' Consulta para generar el reporte de herrajes, contemplando herraje1, herraje2, herraje3, etc
    ''' </summary>
    ''' <param name="fechaPrograma"></param>
    ''' <param name="nave"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConsultaReporteHerrajes1N(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal lista As IList(Of Integer)) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim componenteId As String = String.Empty
        Dim parametro As New SqlParameter

        For Each id In lista
            If (componenteId <> "") Then
                componenteId += ","
            End If
            componenteId += id.ToString
        Next

        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = fechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveId"
        parametro.Value = nave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@descripcionMaterial"
        parametro.Value = "Herraje"
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@componenteId"
        parametro.Value = componenteId
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Produccion_ReporteHerrajes_Pantalla]", listaparametros)


        'Dim consulta As String =
        '    <cadena>
        '        select
        '        '' 'No.',
        '        lp.lote_pares 'Pares',lote_lote 'Lote',p.prod_modelo 'Modelo', vpe.ModeloSAY 'ModeloSAY',
        '        m.mate_descripcion 'Material',t.talla_descripcion 'Corrida',p.prod_descripcion 'Coleccion',
        '       dg.prov_razonsocial'Proveedor',cp.copr_consumoproduccionid 'Id Consumo'
        '        from Produccion.LoteProduccionSicy as lp
        '        left join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=lp.lote_productoestiloid
        '        INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
        '        left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
        '        left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
        '        left join Programacion.Tallas as t on t.talla_tallaid=lp.lote_corridasayid
        '        left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid
        '        left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
        '        INNER JOIN Programacion.vProductoEstilos_Completo vpe on p.prod_productoid = vpe.ProductoId
        '        left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
        '        left join Produccion.Componentes as comp on comp.comp_componenteid=cp.copr_componenteid
        '        left join Proveedor.Proveedor as dg on dg.prov_proveedorid=cp.copr_proveedorid
        '        where lp.lote_fechaprograma = '<%= fechaPrograma %>' and lp.lote_navesayid=<%= nave %> and comp.comp_descripción like '%herraje%' and cp.copr_activo=1 and cp.copr_componenteid in (
        '    </cadena>
        'For Each id In lista
        '    consulta += id.ToString + ","
        'Next
        'consulta += " 0)  "
        'consulta += " GROUP BY lp.lote_pares, lote_lote, p.prod_modelo, vpe.ModeloSAY, m.mate_descripcion, t.talla_descripcion, p.prod_descripcion, dg.prov_razonsocial, cp.copr_consumoproduccionid "
        'consulta += "  Order by lote_lote "
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Consulta para generar el reporte de herrajes, contemplando herraje1, herraje2, herraje3, etc Para impresion
    ''' </summary>
    ''' <param name="fechaPrograma"></param>
    ''' <param name="nave"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConsultaReporteHerrajesImpresion(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal lista As IList(Of Integer)) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim componenteId As String = String.Empty
        Dim parametro As New SqlParameter

        For Each id In lista
            If (componenteId <> "") Then
                componenteId += ","
            End If
            componenteId += id.ToString
        Next

        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = fechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveId"
        parametro.Value = nave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@descripcionMaterial"
        parametro.Value = "Herraje"
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@componenteId"
        parametro.Value = componenteId
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Produccion_ReporteHerrajes_Impresion]", listaparametros)

    End Function


    ' Consulta para generar el reporte de suelas, contemplando suela1, suela2

    Public Function ConsultaReporteSuelas1N(ByVal fechaPrograma As String, ByVal nave As Integer)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaPrograma"
        parametro.Value = fechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = nave
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Consulta_ReporteSuelas1N]", listaparametros)
        'Dim consulta As String =
        '    <cadena>
        '        select
        '        ROW_NUMBER () OVER (ORDER BY lote_lote) 'No.',lp.lote_pares 'Pares' ,lote_lote 'Lote',
        '        c.cole_descripcion 'Coleccion',t.talla_descripcion 'Corrida',p.prod_modelo 'Modelo',
        '        m.mate_descripcion 'Material',comp.comp_descripción'Herraje',dg.prov_razonsocial 'Proveedor'
        '        from Produccion.LoteProduccionSicy as lp
        '        left join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=lp.lote_productoestiloid
        '        INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
        '        left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
        '        left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
        '        left join Programacion.Tallas as t on t.talla_tallaid=lp.lote_corridasayid
        '        left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid
        '        left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
        '        left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
        '        left join Produccion.Componentes as comp on comp.comp_componenteid=cp.copr_componenteid
        '        left join Proveedor.Proveedor as dg on dg.prov_proveedorid=cp.copr_proveedorid 
        '        where lp.lote_fechaprograma = '<%= fechaPrograma %>' and lp.lote_navesayid=<%= nave %> and cp.copr_activo=1 and cp.copr_componenteid in (
        '    </cadena>
        'For Each id In lista
        '    consulta += id.ToString + ","
        'Next
        'consulta += " 0) order by cp.copr_componenteid ASC"
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultaReporteTacon(ByVal fechaprograma As String, ByVal Idnave As Integer, ByVal IdClasificacion As Integer)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaPrograma"
        parametro.Value = fechaprograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = Idnave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdClasificacion"
        parametro.Value = IdClasificacion
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Produccion_ReporteTacon]", listaparametros)
    End Function

    ''Cambiar a tabla de cortadores de SAY
    ''' <summary>
    ''' Consulta para obtener el programa de corte parte superior
    ''' </summary>
    ''' <param name="fecha"></param>
    ''' <param name="nave"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConsultaProgramaCorteSuperior(ByVal fecha As String, ByVal nave As Integer,
                                                  ByVal lista As List(Of Integer)) As DataTable
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '    <cadena>
        '       select DISTINCT ROW_NUMBER() OVER(ORDER BY c.NombreCorto,t.talla_descripcion,p.prod_codigo DESC) AS No,
        '        l.lote_productoestiloid'Pe',l.lote_pares 'Pares',l.lote_lote 'Lote',col.cole_descripcion 'Colección',
        '        p.prod_codigo 'Modelo',t.talla_descripcion 'Corrida',l.lote_color 'Color',m.mate_descripcion 'Material',
        '        c.NombreCorto 'Cortador',sum(cd.code_consumo)'Cantidad',um.unme_descripcion'Unidad'--,cd.code_componenteid 
        '        from Produccion.LoteProduccionSicy as l
        '        left join Produccion.LoteAProduccionSicy as la on la.lota_lote=l.lote_lote
        '        left join  Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=l.lote_productoestiloid
        '        left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
        '        left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '        left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        '        left join Programacion.Colecciones as col on col.cole_coleccionid=p.prod_coleccionid
        '        inner join [192.168.2.2].[Yuyin_Respaldo].dbo.pdCortadores as c on c.IdCortador=la.lota_cortadorpielid
        '        left join Produccion.vCambioConsDesarrolloAConsProduccion as cd on cd.code_productoestiloid=l.lote_productoestiloid
        '        INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
        '        left join Materiales.UnidadDeMedida as um on um.unme_idunidad=cd.code_umproduccionid
        '        left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cd.code_materialid
        '        left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
        '    </cadena>
        'consulta += "where l.lote_fechaprograma = '" + fecha + "' and l.lote_navesicyid=" + nave.ToString
        'consulta += " and cd.code_componenteid in ("
        'For Each id As Integer In lista
        '    consulta += id.ToString & ","
        'Next
        'consulta += "0)"
        'consulta += " group by l.lote_productoestiloid,l.lote_lote ,col.cole_descripcion ,m.mate_descripcion,"
        'consulta += " p.prod_codigo ,t.talla_descripcion ,l.lote_color,c.NombreCorto,l.lote_pares,um.unme_descripcion,cd.code_componenteid "
        'consulta += " order by c.NombreCorto,t.talla_descripcion,p.prod_codigo,l.lote_lote"
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    ''Cambiar a tabla de cortadores de SAY
    ''' <summary>
    ''' Consulta para obtener el programa de corte parte inferior
    ''' </summary>
    ''' <param name="fecha"></param>
    ''' <param name="nave"></param>
    ''' <param name="lista"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConsultaProgramaCorteInferior(ByVal fecha As String, ByVal nave As Integer,
                                                  ByVal lista As List(Of Integer)) As DataTable
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '    <cadena>
        '        select  DISTINCT
        '        p.dage_nombrecomercial'Proveedor',m.mate_descripcion 'Material',sum(cd.code_consumo)'Concentrado DCM',c.NombreCorto 'Cortador'
        '        from Produccion.LoteProduccionSicy as l
        '        left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=l.lote_productoestiloid
        '        left join Produccion.vCambioConsDesarrolloAConsProduccion as cd on cd.code_productoestiloid=l.lote_productoestiloid
        '        INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
        '        left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cd.code_materialid
        '        left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
        '        left join Proveedor.Proveedor as dg on dg.prov_proveedorid=cd.code_proveedorid
        '        left join Produccion.LoteAProduccionSicy as la on la.lota_lote=l.lote_lote
        '        inner join [192.168.2.2].[Yuyin_Respaldo].dbo.pdCortadores as c on c.IdCortador=la.lota_cortadorpielid
        '    </cadena>
        'consulta += " where  l.lote_fechaprograma = '" + fecha + "' and l.lote_navesicyid=" + nave.ToString
        'consulta += " and cd.code_componenteid in ("
        'For Each id As Integer In lista
        '    consulta += id.ToString & ","
        'Next
        'consulta += "0)"
        'consulta += " group by p.dage_nombrecomercial,m.mate_descripcion,c.NombreCorto"
        'consulta += " order by c.NombreCorto"
        'Return operacion.EjecutaConsulta(consulta)
    End Function


    'Public Function ReporteDeglosadoPlantilla(ByVal fecha As String, ByVal nave As Integer, ByVal clas As Integer) As DataTable
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String =
    '        <cadena>
    '            select DISTINCT ROW_NUMBER() OVER(ORDER BY l.lote_lote DESC) AS No,
    '            l.lote_productoestiloid'Pe',sum(la.lota_cantidad)'Pares',
    '            l.lote_lote 'Lote',m.mate_descripcion'Material',
    '            p.prod_codigo 'Modelo',l.lote_color 'Color',t.talla_descripcion 'Corrida',pro.prov_razonsocial'Proveedor',
    '            t.talla_t1,t.talla_t2,t.talla_t3,t.talla_t4,t.talla_t5,t.talla_t6,t.talla_t7,t.talla_t8,t.talla_t9,t.talla_t10,
    '            t.talla_t11,t.talla_t12,t.talla_t13,t.talla_t14,
    '            sum(la.lota_lt1),sum(la.lota_lt2),sum(la.lota_lt3),sum(la.lota_lt4),sum(la.lota_lt5),
    '            sum(la.lota_lt6),sum(la.lota_lt7),sum(la.lota_lt8),sum(la.lota_lt9),sum(la.lota_lt10),
    '            sum(la.lota_lt11),sum(la.lota_lt12),sum(la.lota_lt13),sum(la.lota_lt14)
    '            from Produccion.LoteProduccionSicy as l
    '            left join Produccion.LoteAProduccionSicy as la on la.lota_lote=l.lote_lote and la.lota_naveid=<%= nave %> and la.lota_fechaprogramacion='<%= fecha %>'  
    '            left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=l.lote_productoestiloid
    '            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
    '            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
    '            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
    '            inner join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=l.lote_productoestiloid
    '            inner join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
    '            inner join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
    '            left join Proveedor.Proveedor as pro on pro.prov_proveedorid=cp.copr_proveedorid
    '            where lote_fechaprograma = '<%= fecha %>' and lote_navesayid=<%= nave %> and cp.copr_clasificacionid in (<%= clas %>,0) and cp.copr_activo=1 
    '            group by l.lote_productoestiloid,l.lote_lote ,p.prod_descripcion,p.prod_codigo ,t.talla_descripcion ,l.lote_color,m.mate_descripcion,
    '            t.talla_t1,t.talla_t2,t.talla_t3,t.talla_t4,t.talla_t5,t.talla_t6,t.talla_t7,t.talla_t8,t.talla_t9,t.talla_t10,
    '            t.talla_t11,t.talla_t12,t.talla_t13,t.talla_t14,pro.prov_razonsocial order by t.talla_descripcion,p.prod_codigo
    '        </cadena>
    '    Return operacion.EjecutaConsulta(consulta)
    'End Function

    ''Cambiar a tabla de cortadores de SAY
    '''' <summary>
    '''' Consulta para obtener la orden de pedido desglosado para corte parte1
    '''' </summary>

    Public Function ConsultaOrdenDePedidoDesglosadoParaCorte1(ByVal fecha As String, nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@fecha"
        parametro.Value = fecha
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = nave
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Consulta_OrdenPedido_DesglosadoParaCorte1]", listaparametros)

    End Function



    '''' <param name="fecha"></param>
    '''' <param name="nave"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function ConsultaOrdenDePedidoDesglosadoPAraCorte1(ByVal fecha As String, ByVal nave As Integer) As DataTable
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String =
    '        <cadena>
    '            select DISTINCT  
    '            lote_pares 'Pares',lote_lote 'Lote',m.marc_descripcion+' '+c.cole_descripcion'Coleccion',p.prod_codigo 'Modelo', vp.ModeloSICY 'ModeloSICY',
    't.talla_descripcion 'Corrida',piel.piel_descripcion+' '+color.color_descripcion 'Color',isnull(lap.lota_nomcortocortadorpielsay,'') 'Cortador',isnull(lap.lota_nomcortocortadorpielsintsay,'') 'Cortador2',
    't.talla_t1 'tl1',t.talla_t2 'tl2',t.talla_t3 'tl3',t.talla_t4 'tl4',t.talla_t5 'tl5',t.talla_t6 'tl6',
    't.talla_t7 'tl7',t.talla_t8 'tl8',t.talla_t9 'tl9',t.talla_t10 'tl10',t.talla_t11 'tl11',t.talla_t12 'tl12',
    't.talla_t13 'tl13',t.talla_t14 'tl14',t.talla_t15 'tl15',t.talla_t16 'tl16',t.talla_t17 'tl17',t.talla_t18 'tl18',
    't.talla_t19 'tl19',t.talla_t20 'tl20',
    '' 't1',''  't2',''  't3','' 't4','' 't5',''  't6','' 't7','' 't8','' 't9','' 't10',
    '' 't11','' 't12','' 't13','' 't14','' 't15','' 't16','' 't17','' 't18','' 't19','' 't20'
    'from Produccion.LoteProduccionSicy as lp
    '            inner join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid
    '            inner join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
    '            INNER JOIN Programacion.vProductoEstilos_Completo as VP on p.prod_productoid = vp.ProductoId
    '            inner join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
    '            inner join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
    '            inner join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
    '            inner join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
    '            inner join Programacion.Pieles as piel on piel.piel_pielid=ep.espr_pielid
    '            inner join Programacion.Colores as color on color.color_colorid=ep.espr_colorid
    '--inner join Produccion.CortadorPielForro as cort on cort.copf_cortadorpielforroid=lap.lota_idcortadorpielsay 
    '            --inner join Produccion.CortadorPielForro as cort2 on cort2.copf_cortadorpielforroid=lap.lota_idcortadorpielsintsay
    'inner join Produccion.LoteAProduccionSicy  as lap on lap.lota_lote=lp.lote_lote and lap.lota_naveid=<%= nave %> and  lap.lota_fechaprogramacion='<%= fecha %>' 
    '            left join Produccion.ConsumosProduccion as cp on lp.lote_productoestiloid=cp.copr_productoestiloid
    '            INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
    '            where lp.lote_fechaprograma='<%= fecha %>' And lp.lote_navesayid =<%= nave %>  and cp.copr_activo=1 
    '            group by lote_pares,lote_lote,m.marc_descripcion+' '+c.cole_descripcion,p.prod_codigo,vp.ModeloSICY,t.talla_descripcion,piel.piel_descripcion+' '+color.color_descripcion,
    '            lap.lota_nomcortocortadorpielsay,t.talla_t1,t.talla_t2,t.talla_t3,t.talla_t4,t.talla_t5,t.talla_t6,t.talla_t7,t.talla_t8,t.talla_t9,t.talla_t10,t.talla_t11,t.talla_t12,
    '            t.talla_t13,t.talla_t14,t.talla_t15,t.talla_t16,t.talla_t17,t.talla_t18,t.talla_t19,t.talla_t20,lap.lota_lt1,lap.lota_lt2 ,lap.lota_lt3,lap.lota_lt4,lap.lota_lt5,
    '            lap.lota_lt6,lap.lota_lt7,lap.lota_lt8,lap.lota_lt9,lap.lota_lt10,lap.lota_lt11,lap.lota_lt12,lap.lota_lt13,lap.lota_lt14,lap.lota_lt15,lap.lota_nomcortocortadorpielsintsay,
    '            lap.lota_lt16,lap.lota_lt17,lap.lota_lt18,lap.lota_lt19,lap.lota_lt20 order by lote_lote
    '        </cadena>
    '    Return operacion.EjecutaConsulta(consulta)
    'End Function

    ''Cambiar a tabla de cortadores de SAY
    '''' <summary>
    '''' Consulta para obtener la orden de pedido desglosado para corte parte2
    '''' </summary>

    Public Function ConsultaOrdenDePedidoDesglosadoParaCorte2(ByVal fecha As String, ByVal nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@fecha"
        parametro.Value = fecha
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = nave
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Consulta_OrdenPedido_DesglosadoParaCorte2]", listaparametros)
    End Function


    '''' <param name="fecha"></param>
    '''' <param name="nave"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function ConsultaOrdenDePedidoDesglosadoPAraCorte2(ByVal fecha As String, ByVal nave As Integer) As DataTable
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String =
    '        <cadena>
    '            select DISTINCT lap.lota_lote,sum(lap.lota_lt1) 't1',sum(lap.lota_lt2) 't2',sum(lap.lota_lt3) 't3',sum(lap.lota_lt4)'t4',sum(lap.lota_lt5)'t5',
    'sum(lap.lota_lt6) 't6',sum(lap.lota_lt7)'t7',sum(lap.lota_lt8)'t8',sum(lap.lota_lt9)'t9',sum(lap.lota_lt10)'t10',
    'sum(lap.lota_lt11)'t11',sum(lap.lota_lt12)'t12',sum(lap.lota_lt13)'t13',sum(lap.lota_lt14)'t14',sum(lap.lota_lt15)'t15',
    'sum(lap.lota_lt16)'t16',sum(lap.lota_lt17)'t17',sum(lap.lota_lt18)'t18',sum(lap.lota_lt19)'t19',sum(lap.lota_lt20)'t20'
    'from Produccion.LoteAProduccionSicy  as lap 
    '            where lap.lota_fechaprogramacion='<%= fecha %>' and lap.lota_naveid=<%= nave %> and lap.lota_fechaprogramacion='<%= fecha %>'  
    '            and lap.lota_lote in( select DISTINCT lote_lote 'Lote' from Produccion.LoteProduccionSicy as lp 
    '            inner join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid 
    '            inner join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid 
    '            inner join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid 
    '            inner join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid 
    '            inner join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid 
    '            inner join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid 
    '            inner join Programacion.Pieles as piel on piel.piel_pielid=ep.espr_pielid 
    '            inner join Programacion.Colores as color on color.color_colorid=ep.espr_colorid 
    '            inner join Produccion.LoteAProduccionSicy  as lap on lap.lota_lote=lp.lote_lote and lap.lota_naveid=<%= nave %> and lap.lota_fechaprogramacion='<%= fecha %>'
    '            where lp.lote_fechaprograma='<%= fecha %>' And lp.lote_navesayid =<%= nave %>) 
    '            group by lap.lota_lote
    '        </cadena>
    '    Return operacion.EjecutaConsulta(consulta)
    'End Function

    ''Cambiar a tabla de cortadores de SAY
    ''' <summary>
    ''' Consultas CortadoresPiel
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConsultaCortadoresPiel(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal lista As List(Of Integer), ByVal Tipo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim componenteid As String = "0"

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@nave"
        parametro.Value = nave
        listaParametros.Add(parametro)


        For Each id In lista
            componenteid = componenteid & "," & id.ToString
        Next

        parametro = New SqlParameter
        parametro.ParameterName = "@lista"
        parametro.Value = componenteid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Tipo"
        parametro.Value = Tipo
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaCortadoresPiel]", listaParametros)

        'Dim consulta As String =
        '    <cadena>
        '        select 0 'No',
        '         l.lote_productoestiloid'Pe',l.lote_pares 'Pares',l.lote_lote 'Lote',col.cole_descripcion 'Colección',p.prod_codigo 'Modelo',
        '         vp.ModeloSICY 'ModeloSICY',
        '         t.talla_descripcion 'Corrida',l.lote_color 'Color',m.mate_descripcion 'Material',
        '         CASE WHEN '<%= Tipo %>'='FORRO' then lap.lota_nomcortocortadorforrosay ELSE (CASE WHEN '<%= Tipo %>'='FORROSINT' THEN lap.lota_nomcortocortadorforrosintsay ELSE 
        '(CASE WHEN '<%= Tipo %>'='PIEL' THEN lap.lota_nomcortocortadorpielsay ELSE lap.lota_nomcortocortadorpielsintsay END)END)END 'Cortador',
        '         CONVERT(DECIMAL(10,2),cp.copr_consumo) 'Consumo',
        '         cp.copr_consumo,l.lote_pares,CONVERT(varchar(20),CONVERT(money,cp.copr_consumo*l.lote_pares),1)'Cantidad',um.unme_descripcion'Unidad'
        '         from Produccion.LoteProduccionSicy as l
        '         inner join Produccion.LoteAProduccionSicy  as lap on lap.lota_lote=l.lote_lote and lap.lota_naveid=<%= nave %> and  lap.lota_fechaprogramacion='<%= fechaPrograma %>'  
        '         inner join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=l.lote_productoestiloid
        '         inner join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
        '         INNER JOIN Programacion.vProductoEstilos_Completo as VP  on p.prod_productoid = vp.ProductoId
        '         inner join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '         inner join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        '         inner join Programacion.Colecciones as col on col.cole_coleccionid=p.prod_coleccionid
        '         inner join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=l.lote_productoestiloid
        '         INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
        '         inner join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
        '         inner join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
        '         left join Materiales.UnidadDeMedida as um on um.unme_idunidad=cp.copr_umproduccionid 
        '         where l.lote_fechaprograma = '<%= fechaPrograma %>' and l.lote_navesayid=<%= nave %> and cp.copr_activo=1 and cp.copr_componenteid in (
        '     </cadena>
        'For Each id In lista
        '    consulta += id.ToString + ","
        'Next
        'consulta += "0) "
        'consulta += "group by l.lote_productoestiloid,l.lote_pares,l.lote_lote,col.cole_descripcion ,p.prod_codigo,vp.ModeloSICY ,"
        'consulta += "t.talla_descripcion ,l.lote_color ,m.mate_descripcion ,lap.lota_nomcortocortadorforrosay ,lap.lota_nomcortocortadorforrosintsay,cp.copr_consumo ,"
        'consulta += "cp.copr_consumo,l.lote_pares,cp.copr_consumo*l.lote_pares,um.unme_descripcion,lap.lota_nomcortocortadorpielsay,lap.lota_nomcortocortadorpielsintsay"
        'If Tipo = "FORRO" Then
        '    consulta += " order by lap.lota_nomcortocortadorforrosay"
        'ElseIf Tipo = "FORROSINT" Then
        '    consulta += " order by lap.lota_nomcortocortadorforrosintsay"
        'ElseIf Tipo = "PIEL" Then
        '    consulta += " order by lap.lota_nomcortocortadorpielsay"
        'ElseIf Tipo = "PIELSINT" Then
        '    consulta += " order by lap.lota_nomcortocortadorpielsintsay"
        'End If
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultaMaterialesCortadoresPiel(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal lista As List(Of Integer), ByVal Tipo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim componenteid As String = "0"

        'If Tipo <> "FORRO" Then

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@nave"
        parametro.Value = nave
        listaParametros.Add(parametro)


        For Each id In lista
            componenteid = componenteid & "," & id.ToString
        Next

        parametro = New SqlParameter
        parametro.ParameterName = "@lista"
        parametro.Value = componenteid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Tipo"
        parametro.Value = Tipo
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaMaterialesCortadoresPiel]", listaParametros)
        'Else
        '    Dim consulta As String =
        '        <cadena>
        '           select  
        '                p.prov_razonsocial 'proveedor',m.mate_descripcion'material',  sum(Concentrado) 'Concentrado',
        '                CASE WHEN '<%= Tipo %>'='FORRO' then lc.CortadorForro ELSE (CASE WHEN '<%= Tipo %>'='FORROSINT' THEN lc.CortadorForroSint ELSE 
        '                (CASE WHEN '<%= Tipo %>'='PIEL' THEN lc.CortadorPiel ELSE lc.CortadorPielSint END)END)END 'Corta',lc.copr_componenteid,lc.copr_clasificacionid
        '                from
        '                (SELECT l.lote_productoestiloid, l.lote_fechaprograma, l.lote_navesayid, CONVERT(DECIMAL(10,2),cp.copr_consumo*l.lote_pares) 'Concentrado',
        '                lap.lota_nomcortocortadorforrosay 'CortadorForro', lap.lota_nomcortocortadorforrosintsay 'CortadorForroSint', lap.lota_nomcortocortadorpielsay 'CortadorPiel', lap.lota_nomcortocortadorpielsintsay 'CortadorPielSint',
        '                cp.copr_componenteid, cp.copr_clasificacionid, cp.copr_materialid, cp.copr_proveedorid
        '                 FROM Produccion.LoteProduccionSicy as l
        '                left join Produccion.LoteAProduccionSicy  as lap on lap.lota_lote=l.lote_lote and lap.lota_naveid=<%= nave %> and  lap.lota_fechaprogramacion='<%= fechaPrograma %>' 
        '                inner join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=l.lote_productoestiloid 
        '                WHERE  l.lote_fechaprograma = '<%= fechaPrograma %>' and l.lote_navesayid=<%= nave %> and cp.copr_componenteid in(
        '    </cadena>
        '    For Each id In lista
        '        consulta += id.ToString + ","
        '    Next
        '    consulta += "0)  AND cp.copr_activo=1"
        '    consulta += " GROUP BY  l.lote_productoestiloid, l.lote_fechaprograma, l.lote_navesayid,cp.copr_consumo, l.lote_pares,"
        '    consulta += "lap.lota_nomcortocortadorforrosay,lap.lota_nomcortocortadorforrosintsay,lap.lota_nomcortocortadorpielsay,lap.lota_nomcortocortadorpielsintsay, cp.copr_componenteid, cp.copr_clasificacionid, cp.copr_materialid, cp.copr_proveedorid) AS lc"
        '    consulta += " inner join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=lc.copr_materialid"
        '    consulta += " inner join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid"
        '    consulta += " inner join Materiales.MaterialesPrecio as mp on mp.prma_idMaterialNave=lc.copr_materialid AND mp.prma_provedorid=lc.copr_proveedorid and mp.prma_activo=1"
        '    consulta += " inner join Proveedor.Proveedor as p on p.prov_proveedorid=lc.copr_proveedorid"
        '    ''consulta += " inner join [192.168.2.2].[Yuyin_Respaldo].dbo.pdCortadores as c on c.IdCortador=lc.lote_cortadorpielid"
        '    consulta += " group by p.prov_razonsocial ,m.mate_descripcion,lc.CortadorForro, lc.CortadorForroSint, lc.CortadorPiel, lc.CortadorPielSint,lc.copr_componenteid,lc.copr_clasificacionid "
        '    If Tipo = "FORRO" Then
        '        consulta += " order by lc.cortadorforro"
        '    ElseIf Tipo = "FORROSINT" Then
        '        consulta += " order by lc.cortadorforrosint"
        '    ElseIf Tipo = "PIEL" Then
        '        consulta += " order by lc.cortadorpiel"
        '    ElseIf Tipo = "PIELSINT" Then
        '        consulta += " order by lc.cortadorpielsint"
        '    End If
        '    Return operacion.EjecutaConsulta(consulta)
        'End If
    End Function

    Public Function ConsultaCortadoresReporte(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal lista As List(Of Integer), ByVal Tipo As String) As DataTable
        '  Dim operacion As New Persistencia.OperacionesProcedimientos
        '  Dim consulta As String =
        '      <cadena>
        '         select DISTINCT CASE WHEN '<%= Tipo %>'='FORRO' then lap.lota_nomcortocortadorforrosay ELSE (CASE WHEN '<%= Tipo %>'='FORROSINT' THEN lap.lota_nomcortocortadorforrosintsay ELSE 
        '(CASE WHEN '<%= Tipo %>'='PIEL' THEN lap.lota_nomcortocortadorpielsay ELSE lap.lota_nomcortocortadorpielsintsay END)END)END 'Cortadoress'                
        '          from Produccion.LoteProduccionSicy as l
        '          inner join Produccion.LoteAProduccionSicy  as lap on lap.lota_lote=l.lote_lote and lap.lota_naveid=<%= nave %> and  lap.lota_fechaprogramacion='<%= fechaPrograma %>' 
        '          inner join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=l.lote_productoestiloid
        '          INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
        '          inner join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
        '          inner join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
        '          inner join Materiales.MaterialesPrecio as mp on mp.prma_idMaterialNave=mn.mn_materialNaveid
        '          inner join Proveedor.Proveedor as p on p.prov_proveedorid=mp.prma_provedorid
        '          where l.lote_fechaprograma = '<%= fechaPrograma %>' and l.lote_navesayid=<%= nave %> and cp.copr_activo=1 and cp.copr_componenteid in (
        '      </cadena>
        '  For Each id In lista
        '      consulta += id.ToString + ","
        '  Next
        '  consulta += "0) group by p.prov_razonsocial ,m.mate_descripcion,l.lote_pares,lap.lota_nomcortocortadorforrosay,lap.lota_nomcortocortadorforrosintsay,lap.lota_nomcortocortadorpielsay,lap.lota_nomcortocortadorpielsintsay,cp.copr_componenteid,cp.copr_clasificacionid"
        '  If Tipo = "FORRO" Then
        '      consulta += " order by lap.lota_nomcortocortadorforrosay"
        '  ElseIf Tipo = "FORROSINT" Then
        '      consulta += " order by lap.lota_nomcortocortadorforrosintsay"
        '  ElseIf Tipo = "PIEL" Then
        '      consulta += " order by lap.lota_nomcortocortadorpielsay"
        '  ElseIf Tipo = "PIELSINT" Then
        '      consulta += " order by lap.lota_nomcortocortadorpielsintsay"
        '  End If
        '  Return operacion.EjecutaConsulta(consulta)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim componenteid As String = "0"

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = nave
        listaParametros.Add(parametro)

        For Each id In lista
            componenteid = componenteid & "," & id.ToString
        Next

        parametro = New SqlParameter
        parametro.ParameterName = "@IdComponentes"
        parametro.Value = componenteid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Tipo"
        parametro.Value = Tipo
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaCortadoresReporte]", listaParametros)



    End Function

    Public Function ReporteOrdenesDeProduccionFake(ByVal fechaPrograma As String, ByVal nave As Integer,
                                              ByVal clasificacion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNaveSay"
        parametro.Value = nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = clasificacion
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaOrdenProduccion]", listaParametros)

        'Dim consulta As String =
        '    <cadena>
        '        select DISTINCT
        '            lote_pares 'Pares',lote_lote 'Lote',m.marc_descripcion+' '+c.cole_descripcion'Colección',p.prod_codigo 'ModeloSAY',
        '            VP.ModeloSICY 'ModeloSICY',
        't.talla_descripcion 'Corrida',piel.piel_descripcion+' '+color.color_descripcion 'Color',mat.mate_descripcion 'Suela', 
        'lap.lota_nomcortocortadorpielsay 'Cortador P',lap.lota_nomcortocortadorpielsintsay 'Cortador F',
        'lp.lote_textocliente 'Cliente'
        '            from Produccion.LoteProduccionSicy as lp
        '            inner join Produccion.LoteAProduccionSicy  as lap on lap.lota_lote=lp.lote_lote and lap.lota_naveid=<%= nave %> and  lap.lota_fechaprogramacion='<%= fechaPrograma %>' 
        '            inner join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid
        '            inner join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
        '            INNER JOIN Programacion.vProductoEstilos_Completo AS VP ON P.prod_productoid = VP.ProductoId
        '            inner join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '            inner join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        '            inner join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
        '            inner join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
        '            inner join Programacion.Pieles as piel on piel.piel_pielid=ep.espr_pielid
        '            inner join Programacion.Colores as color on color.color_colorid=ep.espr_colorid
        '            left join Produccion.ConsumosProduccion as cp on lp.lote_productoestiloid=cp.copr_productoestiloid
        '            INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %>
        '            left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
        '            left join Materiales.Materiales as mat on mat.mate_materialid=mn.mn_materialid 
        '            where lote_fechaprograma='<%= fechaPrograma %>' and lote_navesayid=<%= nave %> and cp.copr_componenteid=9 and cp.copr_activo=1 order by lote_lote
        '    </cadena>
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Consulta para obtener el encabezado de la tarjeta de producción
    ''' </summary>
    ''' <param name="lote"></param>
    ''' <param name="nave"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReporteTarjetaProduccionEncabezado(ByVal lote As Integer, ByVal nave As Integer, ByVal añolote As Integer, ByVal productoestilo As Integer) As DataTable
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '<cadena>
        '            select c.cole_descripcion 'coleccion',l.lote_fechaprograma 'programa',l.lote_lote 'lote',
        '            h.horma_descripcion 'horma',t.talla_descripcion 'corrida',f2.costo,
        '            f.tiempo,la.lota_nomcortocortadorPielSay 'cortador p', la.lota_nomcortocortadorForroSay 'cortador f',
        '            l.lote_pares 'pares',pieles.piel_descripcion+' ' +color.color_descripcion 'corte',
        '            l.lote_textocliente 'cliente t', l.lote_nombrecliente 'cliente n',pe.pres_imagen 'imagen',
        '            p.prod_modelo 'modelo',l.lote_año'año' ,mat.mate_descripcion 'suela',l.lote_loteid 'loteid',
        '            la.lota_clienteid'clienteid'
        '            from Produccion.LoteProduccionSicy  as l
        '            left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=l.lote_productoestiloid
        '            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
        '            left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
        '            left join Programacion.Hormas as h on h.horma_hormaid=pe.pres_horma
        '            left join Programacion.Tallas as t on t.talla_tallaid=l.lote_corridasayid
        '            left join (SELECT fd_productoestiloid, sum( (fd_tiempohoras*60) + fd_tiempominutos + (CONVERT(decimal(10,2), convert(decimal(10,2),fd_tiemposegundos)/60))) AS 'tiempo' FROM Produccion.FraccionesDesarrollo where fd_productoestiloid=<%= productoestilo %> AND fd_naveid=<%= nave %> AND fd_sumartiempo=1 GROUP BY fd_productoestiloid) as f on f.fd_productoestiloid=l.lote_productoestiloid
        'left JOIN (SELECT fd_productoestiloid, sum(fd_costo) AS 'costo' FROM Produccion.FraccionesDesarrollo where fd_productoestiloid=<%= productoestilo %> AND fd_naveid=<%= nave %> AND fd_sumarcosto=1 GROUP BY fd_productoestiloid) as f2 on f2.fd_productoestiloid=l.lote_productoestiloid
        '            left join Produccion.LoteAProduccionSicy as la on la.lota_lote=l.lote_lote and la.lota_naveid=<%= nave %> and la.lota_anio=<%= añolote %>
        '            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '            left join Programacion.Pieles as pieles on pieles.piel_pielid=ep.espr_pielid
        '            left join Programacion.Colores as color on color.color_colorid=ep.espr_colorid
        '            left join Produccion.ConsumosProduccion as cp on cp.copr_productoestiloid=pe.pres_productoestiloid 
        '            INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %> 
        'left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cp.copr_materialid
        'left join Materiales.Materiales as mat on mat.mate_materialid=mn.mn_materialid and cp.copr_componenteid=
        '(select comp_componenteid from Produccion.Componentes where comp_descripción='suela') 
        '            where l.lote_lote='<%= lote %>' and l.lote_navesayid=<%= nave %> and l.lote_año=<%= añolote %> and cp.copr_activo=1  
        '            group BY l.lote_navesayid,pieles.piel_descripcion+' ' +color.color_descripcion,la.lota_clienteid, 
        '            c.cole_descripcion,l.lote_fechaprograma,l.lote_lote,h.horma_descripcion,t.talla_descripcion, 
        '            pe.pres_totalfracciones,la.lota_nomcortocortadorPielSay, la.lota_nomcortocortadorForroSay,l.lote_pares,l.lote_textocliente, 
        '            l.lote_nombrecliente,pe.pres_imagen, p.prod_modelo,l.lote_año,mat.mate_descripcion,l.lote_loteid,f.tiempo,f2.costo
        '</cadena>

        'Dim consulta As String =
        '<cadena>
        '    SELECT 
        ' pe.Coleccion 'coleccion',l.lote_fechaprograma 'programa',l.lote_lote 'lote',
        '    pe.Horma 'horma',pe.talla 'corrida',f.costo,
        '    f.tiempo,la.lota_nomcortocortadorPielSay 'cortador p', la.lota_nomcortocortadorForroSay 'cortador f',
        '    l.lote_pares 'pares',pe.pielColor 'corte',
        '    l.lote_textocliente 'cliente t', l.lote_nombrecliente 'cliente n',pe.pres_imagen 'imagen',
        '    pe.prod_codigo 'modelo',l.lote_año'año'
        ' ,mat.mate_descripcion 'suela',l.lote_loteid 'loteid',
        '    la.lota_clienteid 'clienteid'
        ' from 
        'Produccion.LoteProduccionSicy  as l
        'left join vProductoEstilosProduccion as pe on pe.pres_productoestiloid=l.lote_productoestiloid
        'left join ( SELECT fd_productoestiloid, sum( (fd_tiempohoras*60) + fd_tiempominutos + (CONVERT(decimal(10,2), convert(decimal(10,2),fd_tiemposegundos)/60))) AS 'tiempo',sum(fd_costo) AS 'costo'  FROM Produccion.FraccionesDesarrollo  where fd_productoestiloid=<%= productoestilo %> AND fd_naveid=<%= nave %> AND fd_sumartiempo=1 and fd_activo = 1 GROUP BY fd_productoestiloid) as f on f.fd_productoestiloid=l.lote_productoestiloid
        'left join Produccion.LoteAProduccionSicy as la on la.lota_lote=l.lote_lote and la.lota_naveid=l.lote_navesicyid and la.lota_anio=l.lote_año
        'left join (
        ' select mat.mate_descripcion, cp.copr_productoestiloid from  Produccion.ConsumosProduccion cp
        ' left join Materiales.MaterialesNave mn on mn.mn_materialNaveid=cp.copr_materialid
        ' left join Materiales.Materiales as mat on mat.mate_materialid=mn.mn_materialid
        ' where cp.copr_productoestiloid=10402 and cp.copr_componenteid=9 and cp.copr_activo=1
        ') as mat on mat.copr_productoestiloid=l.lote_productoestiloid
        'where l.lote_lote='<%= lote %>' and l.lote_navesayid=<%= nave %> and l.lote_año=<%= añolote %>
        '</cadena>
        'Return operacion.EjecutaConsulta(consulta)


        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "@Lote"
        parametro.Value = lote.ToString()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Anio"
        parametro.Value = añolote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ProductoEstilo"
        parametro.Value = productoestilo
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Produccion_ObtieneEncabezado_TarjetaProduccion]", listaParametros)
    End Function

    ''' <summary>
    ''' Consulta para obtener el producto estilo del lote para tarjeta de producción
    ''' </summary>
    ''' <param name="lote"></param>
    ''' <param name="nave"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReporteTarjetaProduccionProductoEstilo(ByVal lote As Integer, ByVal nave As Integer, ByVal añolote As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select lote_productoestiloid from Produccion.LoteProduccionSicy
                where lote_lote='<%= lote %>' and lote_navesayid=<%= nave %> and lote_año=<%= añolote %>
            </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Consulta para obtener el total de DCM en consumos considerenado Piel, piel sintetito y piel textil
    ''' </summary>
    ''' <param name="pe"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReporteTarjetaProduccionTotalDCMComponentePiel(ByVal pe As Integer, ByVal Nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        'Dim consulta As String =
        '    <cadena>
        '      select sum(cp.copr_consumo) 
        '    from Produccion.ConsumosProduccion as cp
        '    INNER JOIN Produccion.ProductoNaveProduccion AS pnp ON cp.copr_productonaveid=pnp.pena_productonaveid AND pnp.pena_estatus='AP' AND pnp.pena_naveid=<%= nave %> 
        '    where cp.copr_productoestiloid='<%= pe %>' and cp.copr_activo=1 and cp.copr_componenteid in (select comp_componenteid from Produccion.Componentes where comp_descripción like '%piel%')
        '    </cadena>
        'Return operacion.EjecutaConsulta(consulta)

        parametro = New SqlParameter
        parametro.ParameterName = "@ProductoEstiloId"
        parametro.Value = pe
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = Nave
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Produccion_Reportes_TarjetaProduccion_ObtenerDCMPiel]", listaParametros)
    End Function

    Public Function ReporteTarjetaProduccionTotalDCMPielSintetica(ByVal pi As Integer, ByVal Nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        parametro = New SqlParameter
        parametro.ParameterName = "@ProductoEstiloId"
        parametro.Value = pi
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = Nave
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Produccion_Reportes_TarjetaProduccion_ObtenerDCMPiel_Sintetico]", listaParametros)


    End Function

    Public Function ObtenerRutaID(ByVal clienteid As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
               select R.ruta_rutaid from Cliente.Cliente as cl 
                inner join Ventas.Rutas as r on r.ruta_rutaid=cl.clie_rutaid
                where CL.clie_idsicy=<%= clienteid %>
            </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ReporteTarjetaProduccionNumeracion(ByVal lote As Integer, ByVal nave As Integer, ByVal añolote As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>                
                select l.lote_pares 'pares',
                t.talla_t1 '1',t.talla_t2 '2',t.talla_t3 '3',t.talla_t4 '4',t.talla_t5 '5',t.talla_t6 '6',t.talla_t7 '7',t.talla_t8 '8',
                t.talla_t9 '9',t.talla_t10 '10',t.talla_t11 '11',t.talla_t12 '12',t.talla_t13 '13',t.talla_t14 '14',t.talla_t15 '15',
                t.talla_t16 '16',t.talla_t17 '17',t.talla_t18 '18',t.talla_t19 '19',t.talla_t20 '20',
                CASE   WHEN t.talla_t1 ='' THEN null else  sum(la.lota_lt1) end 't1',
				CASE   WHEN t.talla_t2 ='' THEN null else  sum(la.lota_lt2) end 't2',
				CASE   WHEN t.talla_t3 ='' THEN null else  sum(la.lota_lt3) end 't3',
				CASE   WHEN t.talla_t4 ='' THEN null else  sum(la.lota_lt4) end 't4',
				CASE   WHEN t.talla_t5 ='' THEN null else  sum(la.lota_lt5) end 't5',
				CASE   WHEN t.talla_t6 ='' THEN null else  sum(la.lota_lt6) end 't6',
				CASE   WHEN t.talla_t7 ='' THEN null else  sum(la.lota_lt7) end 't7',
				CASE   WHEN t.talla_t8 ='' THEN null else  sum(la.lota_lt8) end 't8',
				CASE   WHEN t.talla_t9 ='' THEN null else  sum(la.lota_lt9) end 't9',
				CASE   WHEN t.talla_t10 ='' THEN null else  sum(la.lota_lt10) end 't10',
				CASE   WHEN t.talla_t11 ='' THEN null else  sum(la.lota_lt11) end 't11',
				CASE   WHEN t.talla_t12 ='' THEN null else  sum(la.lota_lt12) end 't12',
				CASE   WHEN t.talla_t13 ='' THEN null else  sum(la.lota_lt13) end 't13',
				CASE   WHEN t.talla_t14 ='' THEN null else  sum(la.lota_lt14) end 't14',
				CASE   WHEN t.talla_t15 ='' THEN null else  sum(la.lota_lt15) end 't15',
				CASE   WHEN t.talla_t16 ='' THEN null else  sum(la.lota_lt16) end 't16',
				CASE   WHEN t.talla_t17 ='' THEN null else  sum(la.lota_lt17) end 't17',
				CASE   WHEN t.talla_t18 ='' THEN null else  sum(la.lota_lt18) end 't18',
				CASE   WHEN t.talla_t19 ='' THEN null else  sum(la.lota_lt19) end 't19',
                CASE   WHEN t.talla_t20 ='' THEN null else  sum(la.lota_lt20) end 't20'
                from Produccion.LoteAProduccionSicy as la
                left join Produccion.LoteProduccionSicy as l on l.lote_lote=la.lota_lote and l.lote_navesayid=<%= nave %> and l.lote_año=<%= añolote %>
                left join Programacion.Tallas as t on t.talla_tallaid=l.lote_corridasayid 
                where la.lota_lote='<%= lote %>' and la.lota_naveid=<%= nave %> and la.lota_anio=<%= añolote %> 
                group by l.lote_pares,t.talla_t1,t.talla_t2,t.talla_t3,t.talla_t4,t.talla_t5,t.talla_t6,
                t.talla_t7,t.talla_t8,t.talla_t9,t.talla_t10,t.talla_t11,t.talla_t12,t.talla_t13,
                t.talla_t14,t.talla_t15,t.talla_t16,t.talla_t17,t.talla_t18,t.talla_t19,t.talla_t20
            </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ReporteTarjetaProduccionFracciones(ByVal lote As Integer, ByVal nave As Integer, ByVal añolote As Integer) As DataTable
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '    <cadena>
        '       select 
        '            con.id 'id', CONVERT(DECIMAL(10,3),con.precio) 'precio',con.horas, con.minutos,con.segundos,con.tiempo 'Tiempo1',
        '            con.fraccion 'fraccion', con.maquinaria 'maquinaria', con.observaciones
        '             from(select f.fd_fraccionid 'id',CONVERT(DECIMAL(10,2),f.fd_costo)'precio',
        '            f.fd_tiempohoras 'horas',--convert(int ,f.fd_tiempohoras) / (60 * 60) 'horas',
        '            f.fd_tiempominutos 'minutos',---convert(int, f.fd_tiempominutos) % (60 * 60) / 60 'minutos',
        '            f.fd_tiemposegundos 'segundos',---convert(int, f.fd_tiemposegundos) % (60 * 60) % 60 'segundos',
        '            cf.frap_descripcion 'fraccion',m.mapr_descripcion 'maquinaria',convert(varchar ,RIGHT('00' + Ltrim(Rtrim(f.fd_tiempohoras)),2)) + ':' + convert(varchar ,RIGHT('00' + Ltrim(Rtrim(f.fd_tiempominutos)),2)) + ':' + convert(varchar ,RIGHT('00' + Ltrim(Rtrim(f.fd_tiemposegundos)),2)) 'tiempo',
        '            f.fd_observaciones 'observaciones',fo.fror_numero
        '            from Produccion.LoteProduccionSicy as l
        '            left join Produccion.FraccionesDesarrollo as f on f.fd_productoestiloid=l.lote_productoestiloid and f.fd_naveid=<%= nave %> and f.fd_activo=1
        '            INNER JOIN Produccion.FraccionOrdenamiento as fo on f.fd_fracciondesarrolloid=fo.fror_fraccionid
        '            left join Produccion.CatalagoFracciones as cf on cf.frap_fraccionid=f.fd_fraccionid
        '            left join Produccion.MaquinariaProduccion as m on m.mapr_maquinaid=f.fd_maquinaid
        '            where l.lote_lote='<%= lote %>' and  l.lote_navesayid=<%= nave %> and l.lote_año=<%= añolote %>) as con ORDER BY fror_numero desc
        '    </cadena>
        ''Return operacion.EjecutaConsulta(consulta)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "@lote"
        parametro.Value = lote.ToString()
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Anio"
        parametro.Value = añolote
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Produccion_ObtieneFracciones_TarjetaProduccion]", listaParametros)

    End Function

    Public Function ReporteTarjetaProduccionTotalTiempoFracciones(ByVal tiempo As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                  select 
                    convert(varchar ,RIGHT('00' + Ltrim(Rtrim(con.horas)),2))+':'+convert( varchar ,RIGHT('00' + Ltrim(Rtrim(con.minutos)),2))+':'+convert( varchar ,RIGHT('00' + Ltrim(Rtrim(con.segundos)),2)) 'tiempo'
                    from(select 
            </cadena>
        consulta += " convert(int ," + tiempo.ToString + ") / (60 * 60) 'horas',"
        consulta += " convert(int, " + tiempo.ToString + ") % (60 * 60) / 60 'minutos',"
        consulta += " convert(int, " + tiempo.ToString + ") % (60 * 60) % 60 'segundos') as con"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultaCortadoresPielForroSintetico(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal lista As List(Of Integer), ByVal Tipo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim componenteid As String = "0"

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@nave"
        parametro.Value = nave
        listaParametros.Add(parametro)


        For Each id In lista
            componenteid = componenteid & "," & id.ToString
        Next

        parametro = New SqlParameter
        parametro.ParameterName = "@lista"
        parametro.Value = componenteid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Tipo"
        parametro.Value = Tipo
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaCortadoresPiel_ForroSintetico]", listaParametros)
    End Function

    Public Function ConsultaCortadoresPielForro(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal lista As List(Of Integer), ByVal Tipo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim componenteid As String = "0"

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@nave"
        parametro.Value = nave
        listaParametros.Add(parametro)


        For Each id In lista
            componenteid = componenteid & "," & id.ToString
        Next

        parametro = New SqlParameter
        parametro.ParameterName = "@lista"
        parametro.Value = componenteid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Tipo"
        parametro.Value = Tipo
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaCortadoresPiel_FORRO]", listaParametros)
    End Function

    Public Function ConsultaCortadoresPielSintetico(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal lista As List(Of Integer), ByVal Tipo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim componenteid As String = "0"

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@nave"
        parametro.Value = nave
        listaParametros.Add(parametro)


        For Each id In lista
            componenteid = componenteid & "," & id.ToString
        Next

        parametro = New SqlParameter
        parametro.ParameterName = "@lista"
        parametro.Value = componenteid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Tipo"
        parametro.Value = Tipo
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaCortadoresPielSintetico]", listaParametros)
    End Function


    Public Function ConsultaCortadoresPielPiel(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal lista As List(Of Integer), ByVal Tipo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim componenteid As String = "0"

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@nave"
        parametro.Value = nave
        listaParametros.Add(parametro)


        For Each id In lista
            componenteid = componenteid & "," & id.ToString
        Next

        parametro = New SqlParameter
        parametro.ParameterName = "@lista"
        parametro.Value = componenteid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Tipo"
        parametro.Value = Tipo
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaCortadoresPiel_Piel]", listaParametros)
    End Function

    Public Function ConsultaSumaCortadorPielSint(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal lista As List(Of Integer)) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim componenteid As String = "0"

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@nave"
        parametro.Value = nave
        listaParametros.Add(parametro)


        For Each id In lista
            componenteid = componenteid & "," & id.ToString
        Next

        parametro = New SqlParameter
        parametro.ParameterName = "@lista"
        parametro.Value = componenteid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaCortadoresPielSintetico_SumaCortador]", listaParametros)
    End Function

    Public Function ConsultaSumaCortadorForroSint(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal lista As List(Of Integer)) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim componenteid As String = "0"

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@nave"
        parametro.Value = nave
        listaParametros.Add(parametro)


        For Each id In lista
            componenteid = componenteid & "," & id.ToString
        Next

        parametro = New SqlParameter
        parametro.ParameterName = "@lista"
        parametro.Value = componenteid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaCortadoresPiel_ForroSintetico_SumaCortador]", listaParametros)
    End Function

    Public Function ObtieneConcentradoHerraje(ByVal fechaPrograma As String, ByVal idNave As Integer,
                                    ByVal idClasificacion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pFechaPrograma"
        parametro.Value = fechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdNave"
        parametro.Value = idNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdClasificacion"
        parametro.Value = idClasificacion
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Produccion.[SP_Produccion_ReporteConcentradoHerraje]", listaparametros)
    End Function

    Public Function ObtineExplosionMateriales(ByVal FechaPrograma As String, ByVal Nave As Integer)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = FechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveId"
        parametro.Value = Nave
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaExplosionAplicaciones]", listaparametros)
    End Function


    Public Function ConsultaArticulosNoAutorizados(ByVal idNaveSICY As Integer, ByVal fechaPrograma As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pIdNaveSAY"
        parametro.Value = idNaveSICY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pFechaPrograma"
        parametro.Value = fechaPrograma
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_Produccion_ReportesProduccion_ObtenerArticulosNoAutorizados]", listaparametros)
    End Function

    Public Function ObtieneEncabezado_VistaPreviaTarjetaProduccion(ByVal pProductoEstiloId As Integer, ByVal pNaveId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = pNaveId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ProductoEstiloId"
        parametro.Value = pProductoEstiloId
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Produccion.[SP_Produccion_ObtieneEncabezado_VistaPreviaTarjetaProduccion]", listaparametros)
    End Function

    Public Function ObtieneNumeracion_VistaPreviaTarjetaProduccion(ByVal pProductoEstiloId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ProductoEstiloId"
        parametro.Value = pProductoEstiloId
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Produccion.[SP_ObtieneNumeracion_VistaPreviaTarjetaProduccion]", listaparametros)
    End Function

    Public Function ObtieneFracciones_VistaPreviaTarjetaProduccion(ByVal pProductoEstiloId As Integer, ByVal pNaveId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = pNaveId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ProductoEstiloId"
        parametro.Value = pProductoEstiloId
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Produccion.[SP_ObtieneFracciones_VistaPreviaTarjetaProduccion]", listaparametros)
    End Function

    Public Function ObtieneFichaCostoConsumos(ByVal pProductoEstiloId As Integer, ByVal pNaveId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ProductoEstiloId"
        parametro.Value = pProductoEstiloId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = pNaveId
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Produccion.[SP_ObtieneReporte_FichaCostoConsumo]", listaparametros)
    End Function

    Public Function ObtieneConcentradoCortePielForro(ByVal pFechaPrograma As Date, ByVal pNaveId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = pFechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@nave"
        parametro.Value = pNaveId
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Produccion.[SP_ConsultaConcentradoCortePielForro]", listaparametros)
    End Function

    Public Function ObtieneConcentradoCortePielForroSintetico(ByVal pFechaPrograma As Date, ByVal pNaveId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@fechaPrograma"
        parametro.Value = pFechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@nave"
        parametro.Value = pNaveId
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Produccion.[SP_ConsultaConcentradoCortePielForro_Sintetico]", listaparametros)
    End Function

    Public Function ObtieneArticulosNoAutorizadosProduccion(ByVal NaveSICY As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal ColaboradorId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pIdNaveSicy"
        parametro.Value = NaveSICY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = FechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFin"
        parametro.Value = FechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colaboradorId"
        parametro.Value = ColaboradorId
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Produccion.[SP_Programacion_ConsultarArticulosNoAutorizadosProduccionPorNave]", listaparametros)
    End Function


    Public Function ObtieneLotes_SAY_SICY(ByVal NaveSAY As Integer, ByVal FechaPrograma As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NaveIdSAY"
        parametro.Value = NaveSAY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaPrograma"
        parametro.Value = FechaPrograma
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Produccion.[SP_Produccion_ReportesProduccion_ObtenerLotesSAY_SICY]", listaparametros)
    End Function

    Public Function ActualizaLotes_SICY_a_SAY(ByVal NaveSAY As Integer, ByVal FechaProgramaInicio As String, ByVal FechaProgramaFin As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdNaveSay"
        parametro.Value = NaveSAY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaProgramaInicio"
        parametro.Value = FechaProgramaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaProgramaFin"
        parametro.Value = FechaProgramaFin
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[usp_replicarLotesA_Y_Lotes_SAY_PorNavePrograma]", listaparametros)
    End Function

    Public Function ObtieneLotesPiloto(ByVal pIdNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NavesId"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ReportesProduccion_LotesPiloto]", listaparametros)
    End Function

    Public Function ReporteOrdenesDeProduccion_FacturadoYRemisionado(ByVal fechaPrograma As String, ByVal nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNaveSay"
        parametro.Value = nave
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Produccion_ConsultaOrdenProduccion_FacturaRemision]", listaParametros)
    End Function


    Public Function ReporteOrdenesDeProduccion_FacturadoYRemisionadoPorTipo(ByVal fechaPrograma As String, ByVal nave As Integer, ByVal tipo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaPrograma"
        parametro.Value = fechaPrograma
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNaveSay"
        parametro.Value = nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipo"
        parametro.Value = tipo
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Produccion_ConsultaOrdenProduccion_FacturaRemision_PorTipo]", listaParametros)
    End Function

    Public Function cargarGrupoXNave()
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim parametros = New SqlParameter
        Dim listaParametro = New List(Of SqlParameter)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultarGrupo]", listaParametro)

    End Function

    Public Function cargarNavesXGrupo(ByVal grupo As String)
        Dim ObjPersistencia = New Persistencia.OperacionesProcedimientos
        Dim parametros = New SqlParameter
        Dim listaParametros = New List(Of SqlParameter)

        parametros.ParameterName = "@Grupo"
        parametros.Value = grupo
        listaParametros.Add(parametros)

        Return ObjPersistencia.EjecutarConsultaSP("[Programacion].[SP_ConsultaNaveXGrupo]", listaParametros)

    End Function

    Public Function ObtieneArticulosNoAutorizadosProduccionGrupo(ByVal NaveSICY As Integer,
                                                                 ByVal FechaInicio As Date,
                                                                 ByVal FechaFin As Date,
                                                                 ByVal ColaboradorId As Integer,
                                                                 ByVal Grupo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pIdNaveSicy"
        parametro.Value = NaveSICY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = FechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFin"
        parametro.Value = FechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colaboradorId"
        parametro.Value = ColaboradorId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@grupo"
        parametro.Value = Grupo
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Programacion_ConsultarArticulosNoAutorizadosProduccionPorNaveGrupo]", listaparametros)
    End Function

    Public Function ConsultaOrdenDePedidoDesglosadoParaMaquila(ByVal fecha As String, nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@fecha"
        parametro.Value = fecha
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = nave
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Consulta_OrdenPedido_DesglosadoParaMaquila1]", listaparametros)

    End Function

    Public Function ReporteSuelasTrento(ByVal fechaDel As Date, ByVal fechaAl As Date, ByVal idNave As String, ByVal IdClasificacion As Integer, ByVal proveedor As Integer)
        Dim Persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@fechaDel", fechaDel)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaAl", fechaAl)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@pIdNave", idNave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@pIdClasificacion", IdClasificacion)
        listaParametros.Add(parametro)


        parametro = New SqlParameter("@Proveedor", proveedor)
        listaParametros.Add(parametro)


        Return Persistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_ReporteSuelastrento]", listaParametros)

    End Function


End Class
