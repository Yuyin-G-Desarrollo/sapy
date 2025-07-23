Imports Entidades
Imports System.Data.SqlClient
Imports Persistencia

Public Class catalagosDA
    Public Function getTiposCortadores() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select tcor_tipocortadorid,tcor_descripcion from Produccion.TipoCortador where tcor_activo=1
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function validarPrecioActivoMaterialNave(ByVal idMaterialNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select * from Materiales.MaterialesPrecio 
            </cadena>
        consulta += " where prma_idMaterialNave=" & idMaterialNave & " and prma_activo=1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaProveedores(ByVal naveid As Integer, ByVal materialnaveid As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>        
            select distinct dg.prov_proveedorid 'ID', dg.prov_razonsocial 'Proveedor',
            mp.prma_preciounitario 'Precio',um.unme_idUnidad 'idUnidad',mp.prma_umproveedor 'UMP', mp.prma_equivalencia'Factor de Conversión'  
            from  Materiales.MaterialesPrecio as mp
            join Proveedor.Proveedor as dg on dg.prov_proveedorid=mp.prma_provedorid
            join Materiales.UnidadDeMedida um on um.unme_descripcion=mp.prma_umproduccion
            where mp.prma_idMaterialNave=
        </cadena>
        'Antes join Materiales.UnidadDeMedida um on um.unme_descripcion=mp.prma_umproveedor
        consulta += materialnaveid.ToString
        consulta += " and  mp.prma_idnave=" + naveid.ToString + " and mp.prma_activo=1"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaNaves() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select 0 ' ',nave_naveid 'ID', nave_nombre 'Nave' from Framework.Naves order by nave_nombre
        </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaNavesNoSeleccioandas(ByVal lista As List(Of Integer)) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select 0 ' ',nave_naveid 'ID', nave_nombre 'Nave' 
            from Framework.Naves 
            where nave_naveid in (
        </cadena>
        For Each id As Integer In lista
            consulta += " " & id & ","
        Next
        consulta += " 0)"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaFracciones() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
              select frap_fraccionid 'ID',frap_descripcion 'Fracción', frap_paga 'Paga', m.mapr_maquinaid 'IDmaq',
            frap_tiempo 'Tiempo', frap_precio 'Precio', m.mapr_descripcion 'Maquinaria',frap_activo'Activo'
			from Produccion.CatalagoFracciones 
            left join Produccion.MaquinariaProduccion as m on m.mapr_maquinaid=frap_maquinariaid
			where frap_activo=1 order by frap_descripcion
        </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaFraccionesCatalogo(ByVal pActivo As Boolean, ByVal pTodos As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        '     Dim consulta As String =
        '     <cadena>
        '         select frap_fraccionid 'ID',frap_descripcion 'Fracción', frap_paga 'Paga',
        '         frap_tiempo 'Tiempo', frap_precio 'Precio', frap_activo'Activo',
        '         dg.depg_departamentogeneral 'Departamento',dg.depg_departamentogeneralid 'idd'
        'from Produccion.CatalagoFracciones 
        'left join Framework.DepartamentosGenerales as dg on dg.depg_departamentogeneralid=frap_departamentogeneralid
        'order by frap_descripcion
        '     </cadena>
        '     Return operacion.EjecutaConsulta(consulta)

        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Activo"
        parametro.Value = pActivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Todos"
        parametro.Value = pTodos
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaFracciones]", listaparametros)


    End Function

    Public Function listaClasificacionesComponentes(ByVal componente As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select c.clas_idclasificacion 'ID', c.clas_nombreClas 'Clasificación' 
            from Produccion.componenteClasificacion as cc
            left join Materiales.Clasificaciones as c on c.clas_idclasificacion=cc.cocl_idclasificacion
            where cc.cocl_activo=1 and cc.cocl_idcomponente=
        </cadena>
        consulta += componente.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaMaquinaria() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select mp.mapr_maquinaid 'ID',mp.mapr_descripcion 'Maquinaria',mp.mapr_activo'Activo'
            from Produccion.MaquinariaProduccion as mp
            order by mp.mapr_descripcion
                 </cadena>
        ' consulta += " where mp.mapr_naveid= "+nave.ToString + " order by mp.mapr_descripcion"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaDepartamentosGenerales() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select depg_departamentogeneralid 'ID', depg_departamentogeneral 'DEPARTAMENTO' from Framework.DepartamentosGenerales
        </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaDepartamentos(ByVal nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
           SELECT dept_iddepto 'ID', dept_departamento 'Departamento' FROM Materiales.departamentos WHERE dept_nave=
        </cadena>
        consulta += nave.ToString + " order by Departamento"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaMaterialesParaDesarrollo(ByVal naveid As Integer, ByVal clasificacion As Integer, ByVal lista As List(Of Integer), ByVal EstatusEstilo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaArticulos As String = String.Empty
        '     Dim consulta As String =
        '     <cadena>        
        '         select  m.mate_sku 'SKU',m.mate_materialid 'ID', m.mate_descripcion 'Material' ,
        '         mn.mn_materialNaveid 'IDmn',um2.unme_idUnidad 'idUnidad', mp.prma_umproveedor 'UMC',
        '         p.prov_proveedorid 'ID', p.prov_razonsocial 'Proveedor',
        '         mp.prma_preciounitario 'Precio',um.unme_idunidad 'idUnidad1',mp.prma_umproduccion 'UMP', mp.prma_equivalencia'Factor de Conversión' , m.mate_autorizado , case  m.mate_autorizado when 'P' then 'PRODUCCIÓN' WHEN 'D' THEN 'DESARROLLO' END AS Estatus
        '         from Materiales.MaterialesPrecio as mp
        '         join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=mp.prma_idMaterialNave
        'join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid  
        '         join Materiales.UnidadDeMedida um on um.unme_descripcion=mp.prma_umproduccion
        '         inner join Proveedor.Proveedor as p on p.prov_proveedorid=mp.prma_provedorid
        'join Materiales.UnidadDeMedida um2 on um2.unme_descripcion=mp.prma_umproveedor
        '     </cadena>
        '     consulta += " where mn.mn_idNave=" & naveid.ToString
        '     If EstatusEstilo.Trim() = "AP" Or EstatusEstilo.Trim() = "AD" Then
        '         consulta += " and m.mate_autorizado= 'P' "
        '     End If

        '     consulta += " and m.mate_idClasificacion="
        '     consulta += clasificacion.ToString + " and mn.mn_activo=1  and m.mate_tipodematerial=1 and mp.prma_activo=1  and p.prov_activo=1 and mn.mn_materialNaveid not in ("
        '     For Each id As Integer In lista
        '         consulta += " " & id & ","
        '     Next
        '     consulta += "0) order by m.mate_descripcion"
        '     Return operacion.EjecutaConsulta(consulta)

        For Each id As Integer In lista

            If ListaArticulos = String.Empty Then
                ListaArticulos += " '" & id & "' "
            Else
                ListaArticulos += " ,'" & id & "'"
            End If


        Next


        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NaveSAYID"
        parametro.Value = naveid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clasificacion"
        parametro.Value = clasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EstatusEstilo"
        parametro.Value = EstatusEstilo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ListaArticulo"
        parametro.Value = ListaArticulos
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsumosNave_ListaMaterialesParaDesarrollo]", listaparametros)



    End Function

    Public Function listaMateriales(ByVal naveid As Integer, ByVal clasificacion As Integer, ByVal material As Integer, ByVal EstatusEstilo As String) As DataTable
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '<cadena>        
        '    select  m.mate_sku 'SKU',m.mate_materialid 'ID', m.mate_descripcion 'Material' ,
        '    mn.mn_materialNaveid 'IDmn',um.unme_idUnidad 'idUnidad', mp.prma_umproveedor 'UMC',m.mate_autorizado
        '    from Materiales.MaterialesPrecio as mp
        '    join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=mp.prma_idMaterialNave
        '</cadena>
        ''consulta += naveid.ToString
        'consulta += " join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid  "
        'consulta += " join Materiales.UnidadDeMedida um on um.unme_descripcion=mp.prma_umproveedor "
        'consulta += " where "
        'If clasificacion <> 0 Then
        '    consulta += "m.mate_idClasificacion = " + clasificacion.ToString + " and"
        'End If


        'consulta += " mp.prma_activo=1 and m.mate_tipodematerial=1 and mn.mn_idNave=" + naveid.ToString
        'If EstatusEstilo.Trim() = "AP" Then
        '    consulta += " and m.mate_autorizado = 'P' "
        'End If

        'consulta += " and m.mate_materialid<>" + material.ToString + "    order by m.mate_descripcion"
        'Return operacion.EjecutaConsulta(consulta)


        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
             select  m.mate_sku 'SKU',m.mate_materialid 'ID', m.mate_descripcion 'Material' ,
            mn.mn_materialNaveid 'IDmn',um2.unme_idUnidad 'idUnidad', mp.prma_umproveedor 'UMC',
            p.prov_proveedorid 'ID', p.prov_razonsocial 'Proveedor',
            mp.prma_preciounitario 'Precio',um.unme_idunidad 'idUnidad1',mp.prma_umproduccion 'UMP', mp.prma_equivalencia'Factor de Conversión' , m.mate_autorizado  , case  m.mate_autorizado when 'P' then 'PRODUCCIÓN' WHEN 'D' THEN 'DESARROLLO' END AS Estatus
            from Materiales.MaterialesPrecio as mp
            join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=mp.prma_idMaterialNave
			join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid 
			 join Materiales.UnidadDeMedida um on um.unme_descripcion=mp.prma_umproduccion
            inner join Proveedor.Proveedor as p on p.prov_proveedorid=mp.prma_provedorid
			join Materiales.UnidadDeMedida um2 on um2.unme_descripcion=mp.prma_umproveedor
            where
        </cadena>

        If clasificacion <> 0 Then
            consulta += "m.mate_idClasificacion = " + clasificacion.ToString + " and"
        End If


        consulta += " mp.prma_activo=1 and m.mate_tipodematerial=1 and p.prov_activo=1 and mn.mn_activo=1  and mn.mn_idNave=" + naveid.ToString

        If EstatusEstilo.Trim() = "AP" Then
            consulta += " and m.mate_autorizado = 'P' "
        End If

        consulta += " and m.mate_materialid<>" + material.ToString + "    order by m.mate_descripcion"

        Return operacion.EjecutaConsulta(consulta)

    End Function

    Public Function listaMaterialesCompleta(ByVal naveid As Integer, ByVal componente As Integer, ByVal material As Integer, Optional ByVal MaterialIdReemplazar As Integer = 0, Optional ByVal proveedorMaterial As Integer = 0) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>        
             select DISTINCT m.mate_sku 'SKU',m.mate_materialid 'ID', m.mate_descripcion 'Material' ,
            mn.mn_materialNaveid 'IDmn',um2.unme_idunidad 'idunidad', mp.prma_umproveedor 'UMC',
            prov.prov_proveedorid 'ID', prov.prov_razonsocial 'Proveedor',
            mp.prma_preciounitario 'Precio',um.unme_idunidad 'idunidad1',mp.prma_umproduccion 'UMP', mp.prma_equivalencia'Factor de Conversión',
			cl.clas_nombreclas 'Clasificación', m.mate_idClasificacion 'idclass' ,mn.mn_materialNaveid 'MaterialNAve' , m.mate_autorizado, case  m.mate_autorizado when 'P' then 'PRODUCCIÓN' WHEN 'D' THEN 'DESARROLLO' END AS Estatus
            from Materiales.MaterialesPrecio as mp
            join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=mp.prma_idMaterialNave
			join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid  
			join Materiales.UnidadDeMedida um on um.unme_descripcion=mp.prma_umproduccion
            join Proveedor.Proveedor as prov on prov.prov_proveedorid=mp.prma_provedorid
			join Materiales.UnidadDeMedida um2 on um2.unme_descripcion=mp.prma_umproveedor
			left join Materiales.Clasificaciones as cl on cl.clas_idclasificacion=m.mate_idClasificacion
            left join Produccion.componenteClasificacion as cocl on cocl.cocl_idclasificacion=cl.clas_idclasificacion and cocl.cocl_activo=1
			where mn.mn_idNave=  
        </cadena>
        consulta += naveid.ToString
        consulta += " and mp.prma_activo=1 and mn.mn_activo=1  and prov.prov_activo=1 "
        If componente <> 0 Then
            consulta += " 	and cocl.cocl_idcomponente in (select cocl_idcomponente from Produccion.componenteClasificacion "
            consulta += " where cocl_idclasificacion=" + componente.ToString + " and cocl_activo=1) "
        End If
        If MaterialIdReemplazar > 0 Then

            If proveedorMaterial <> 0 Then
                consulta += " and  not mP.prma_preciosmaterialid in (SELECT mP1.prma_preciosmaterialid  from Materiales.MaterialesPrecio as mp1 join Materiales.MaterialesNave as mn1 on mn1.mn_materialNaveid=mp1.prma_idMaterialNave join Materiales.Materiales as m1 on m1.mate_materialid=mn1.mn_materialid join Proveedor.Proveedor as prov1 on prov1.prov_proveedorid=mp1.prma_provedorid WHERE m1.mate_materialid = " + MaterialIdReemplazar.ToString + " AND prov1.prov_proveedorid  in (" + proveedorMaterial.ToString + ") )"
            Else
                consulta += " and  not m.mate_materialid in(" + MaterialIdReemplazar.ToString + ")"
            End If
        End If
        If material <> 0 Then
            'consulta += " and m.mate_materialid<>" + material.ToString & " and prov.prov_proveedorid<> " & idProveedor
        End If

        consulta += " and m.mate_tipodematerial=1  order by m.mate_descripcion"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaMaterialesEnConsumos(ByVal naveid As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveDesarrollaID"
        parametro.Value = naveid
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Consumos_ListaMateriales]", listaParametros)

        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '<cadena>        
        '    select DISTINCT m.mate_sku 'SKU',m.mate_materialid 'ID', m.mate_descripcion 'Material', 
        '    mn.mn_materialNaveid 'IDmn',um2.unme_idunidad 'idunidad',mp.prma_umproveedor 'UMC', 
        '    prov.prov_proveedorid 'ID', prov.prov_razonsocial 'Proveedor',
        '    mp.prma_preciounitario 'Precio',um.unme_idunidad 'idunidad1',mp.prma_umproduccion 'UMP', mp.prma_equivalencia'Factor de Conversión',
        '    cl.clas_nombreclas 'Clasificación', m.mate_idClasificacion 'idclass' ,mn.mn_materialNaveid 'MaterialNAve' , m.mate_autorizado, case  m.mate_autorizado when 'P' then 'PRODUCCIÓN' WHEN 'D' THEN 'DESARROLLO' END AS Estatus
        '    from Produccion.ConsumosDesarrollo as cd
        '    left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=cd.code_productoestiloid
        '    left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cd.code_materialid
        '    left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
        '    left join Materiales.MaterialesPrecio as mp on mp.prma_idMaterialNave=mn.mn_materialNaveid
        '    join Materiales.UnidadDeMedida um2 on um2.unme_descripcion=mp.prma_umproveedor
        '    join Materiales.UnidadDeMedida um on um.unme_descripcion=mp.prma_umproduccion
        '    join Proveedor.Proveedor as prov on prov.prov_proveedorid=mp.prma_provedorid
        '    left join Materiales.Clasificaciones as cl on cl.clas_idclasificacion=m.mate_idClasificacion
        '    left join Produccion.componenteClasificacion as cocl on cocl.cocl_idclasificacion=cl.clas_idclasificacion and cocl.cocl_activo=1
        '    where pe.pres_navedesarrollaid=
        '</cadena>
        'consulta += naveid.ToString & " and pe.pres_estatusdesarrollo<>'DP' AND mp.prma_activo=1 and mn.mn_activo=1 and prov.prov_activo=1 ORDER BY  m.mate_descripcion"
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function AutorizarDesarrollo(ByVal estilo As Integer, ByVal naveId As Integer, ByVal usuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = estilo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveId"
        parametro.Value = naveId
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioId"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_Desarrollo_Consumos_AutorizarDesarrollo]", listaParametros)
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '<cadena>        
        '    update Programacion.ProductoEstilo 
        '    set pres_estatusdesarrollo='AD'
        '    where pres_productoestiloid=
        '</cadena>
        'consulta += estilo.ToString
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function Descontinuar(ByVal estilo As Integer, ByVal naveId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = estilo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveId"
        parametro.Value = naveId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_Desarrollo_Consumos_Descontinuar]", listaParametros)
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '<cadena>        
        '    update Programacion.ProductoEstilo 
        '    set pres_estatusdesarrollo='DP'
        '    where pres_productoestiloid=
        '</cadena>
        'consulta += estilo.ToString
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function DescontinuarEnNAves(ByVal estilo As Integer, ByVal naveId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = estilo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveId"
        parametro.Value = naveId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_Desarrollo_Consumos_DescontinuarEnNaves]", listaParametros)
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '<cadena>        
        '    update Produccion.ProductoNaveProduccion
        '    set pena_estatus='I'
        '    where pena_productoestiloid=
        '</cadena>
        'consulta += estilo.ToString
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function Inactivar(ByVal estilo As Integer, ByVal nave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = estilo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveId"
        parametro.Value = nave
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_Desarrollo_Consumos_Inactivar]", listaParametros)

        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '<cadena>        
        '    update Produccion.ProductoNaveProduccion 
        '    set pena_estatus='I'
        '    where pena_productoestiloid=
        '</cadena>
        'consulta += estilo.ToString + ""
        'consulta += "and pena_naveid=" + nave.ToString
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function InactivarEnNaveConsumos(ByVal estilo As Integer, ByVal nave As Integer, ByVal tiponave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = estilo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveId"
        parametro.Value = nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoNave"
        parametro.Value = tiponave
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_Desarrollo_Consumos_Inactivar_v2]", listaParametros)
    End Function

    Public Function ActualizaEstatusProuctoEstilo(ByVal poductoEstiloid As Integer, ByVal idNaveSay As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = poductoEstiloid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idNaveSay"
        parametro.Value = idNaveSay
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_ActualizarEstatusProductoEstilo]", listaparametros)

    End Function

    Public Function TodasNavesInactivaEstilo(ByVal ProductoEstilo As Integer) As Integer
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>        
           SELECT COUNT(*)
            from Produccion.ProductoNaveProduccion
            where pena_estatus not in ('I')
            and pena_productoestiloid = '<%= ProductoEstilo.ToString %>'
        </cadena>

        Return operacion.EjecutaConsultaEscalar(consulta)
    End Function

    Public Function InactivarEnNave(ByVal estilo As Integer, ByVal nave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = estilo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveId"
        parametro.Value = nave
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_Desarrollo_Consumos_InactivarEnNave]", listaParametros)
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '<cadena>        
        '    update Produccion.ProductoNaveProduccion 
        '    set pena_estatus='I'
        '    where pena_productoestiloid=
        '</cadena>
        'consulta += estilo.ToString + ""
        'consulta += "and pena_naveid=" + nave.ToString
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function InactivarEnNavePrincipal(ByVal estilo As Integer, ByVal nave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = estilo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveId"
        parametro.Value = nave
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_Desarrollo_Consumos_InactivarEnNavePrincipal]", listaParametros)
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '<cadena>        
        '    update Programacion.ProductoEstilo 
        '    set pres_estatusdesarrollo='I'
        '    where pres_productoestiloid=
        '</cadena>
        'consulta += estilo.ToString + ""
        ''consulta += " and pena_naveid=" + nave.ToString
        'Return operacion.EjecutaConsulta(consulta)
    End Function
    ''' <summary>
    ''' Autorizacion material principal en nave de desarrollo
    ''' </summary>
    ''' <param name="estilo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AutorizarProduccion(ByVal estilo As Integer, ByVal naveId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = estilo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveId"
        parametro.Value = naveId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_Desarrollo_Consumos_AutorizarProduccion]", listaParametros)
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '<cadena>        
        '    update Programacion.ProductoEstilo 
        '    set pres_estatusdesarrollo='AP'
        '    where pres_productoestiloid=
        '</cadena>
        'consulta += estilo.ToString
        'Return operacion.EjecutaConsulta(consulta)
    End Function
    ''' <summary>
    ''' Autorizacion material a produccion en nave
    ''' </summary>
    ''' <param name="estilo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AutorizarProduccionNaveProduccion(ByVal estilo As Integer, ByVal nave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = estilo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveId"
        parametro.Value = nave
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_Desarrollo_Consumos_AutorizarProduccionNaveProduccion]", listaParametros)
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '<cadena>        
        '    update Produccion.ProductoNaveProduccion 
        '    set pena_estatus='AP'
        '    where pena_productoestiloid=
        '</cadena>
        'consulta += estilo.ToString + "  and pena_naveid=" + nave.ToString + " and pena_estatus='AD'"
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function EstatusAnterior(ByVal estilo As Integer, ByVal estatus As String, ByVal naveId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = estilo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatus"
        parametro.Value = estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveId"
        parametro.Value = naveId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_Desarrollo_Consumos_EstatusAnterior]", listaParametros)
        ' Dim operacion As New Persistencia.OperacionesProcedimientos
        ' Dim consulta As String =
        ' <cadena>        
        '     update Programacion.ProductoEstilo 
        '     set pres_estatusdesarrollo=
        '</cadena>
        ' consulta += "'" + estatus + "' where pres_productoestiloid="
        ' consulta += estilo.ToString
        ' Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function descontinuadoAInactivoEnNave(ByVal estilo As Integer, ByVal naveId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = estilo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveId"
        parametro.Value = naveId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_Desarrollo_Consumos_DescontinuadoAInactivoEnNave]", listaParametros)
        ' Dim operacion As New Persistencia.OperacionesProcedimientos
        ' Dim consulta As String =
        ' <cadena>        
        '     update Produccion.ProductoNaveProduccion
        '     set pena_estatus= 'I'
        '</cadena>
        ' consulta += " where pena_productoestiloid="
        ' consulta += estilo.ToString
        ' Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function AsignarProductoNaveProduccion(ByVal componente As Consumos) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@estiloid"
        parametro.Value = componente.cons_productoestiloid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveid"
        parametro.Value = componente.cons_naveid
        listaparametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@asignoid"
        parametro.Value = componente.cons_asignoid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveasignoid"
        parametro.Value = componente.cons_naveasignaid
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_AsignarProductoNaveProduccion]", listaparametros)
    End Function

    Public Function ActualizarHistorialProductoEstilo(ByVal componente As Consumos) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@estiloid"
        parametro.Value = componente.hipe_productoestid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatusde"
        parametro.Value = componente.hipe_estatusde
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatusa"
        parametro.Value = componente.hipe_estatusa
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveid"
        parametro.Value = componente.hipe_idnavehipe
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioid"
        parametro.Value = componente.hipe_usuarioid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveasignadaid"
        parametro.Value = componente.hipe_naveasignadaid
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ActualizarHistorialProductoEstilo]", listaparametros)
    End Function

    Public Function ActualizarHistorialProductoEstiloConNave(ByVal componente As Consumos) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@estiloid"
        parametro.Value = componente.hipe_productoestid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatusde"
        parametro.Value = componente.hipe_estatusde
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatusa"
        parametro.Value = componente.hipe_estatusa
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveid"
        parametro.Value = componente.hipe_idnavehipe
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioid"
        parametro.Value = componente.hipe_usuarioid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@asignado"
        parametro.Value = componente.hipe_asignado
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveasignadaid"
        parametro.Value = componente.hipe_naveasignadaid
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ActualizarHistorialProductoEstiloConNave]", listaparametros)
    End Function

    Public Function HistorialEstilo(ByVal estilo As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>        
            select 
            'Estatus de'= case hpe.hipe_estatusde  when 'D' then 'DESARROLLO'  when 'AD' then 'AUTORIZADO DESARROLLO'
            when 'AP' then 'AUTORIZADO PRODUCCIÓN'  when 'I' then 'INACTIVO NAVE'  when 'DP' then 'DESCONTINUADO' end,
            'Estatus a'= case hpe.hipe_estatusa  when 'D' then 'DESARROLLO'  when 'AD' then 'AUTORIZADO DESARROLLO'
            when 'AP' then 'AUTORIZADO PRODUCCIÓN'  when 'I' then 'INACTIVO NAVE'  when 'DP' then 'DESCONTINUADO' end, 
            hipe_fecha 'Fecha',u.user_username 'Usuario',n.nave_nombre 'Nave asignada'
            from Produccion.HistorialProductoEstilo as hpe
            join Framework.Usuarios as u on u.user_usuarioid=hpe.hipe_usuarioid
            left join Framework.Naves as n on n.nave_naveid=hpe.hipe_naveasignadaid
            where hpe.hipe_productoestiloid=
        </cadena>
        consulta += estilo.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function GuardarFracciones(ByVal fracciones As Fracciones) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@descripcion"
        parametro.Value = fracciones.frap_descripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pagar"
        parametro.Value = fracciones.frap_paga
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tiempo"
        parametro.Value = fracciones.frap_tiempo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@precio"
        parametro.Value = fracciones.frap_precio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuariocreo"
        parametro.Value = fracciones.frap_usuariocreo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@departamentoid"
        parametro.Value = fracciones.departamentogeneralid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = fracciones.frap_activo
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_GuardarFracciones]", listaparametros)
    End Function

    Public Function ActualizarFracciones(ByVal fracciones As Fracciones) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@descripcion"
        parametro.Value = fracciones.frap_descripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pagar"
        parametro.Value = fracciones.frap_paga
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tiempo"
        parametro.Value = fracciones.frap_tiempo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@precio"
        parametro.Value = fracciones.frap_precio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuariomodifico"
        parametro.Value = fracciones.frap_usuariomodifico
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = fracciones.frap_activo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@departamentoid"
        parametro.Value = fracciones.departamentogeneralid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idFraccion"
        parametro.Value = fracciones.frap_fraccionid
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ModificarFracciones]", listaparametros)
    End Function

    Public Function GuardarMaquinaria(ByVal maquinaria As Maquinaria) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@descripcion"
        parametro.Value = maquinaria.maq_descripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuariocreo"
        parametro.Value = maquinaria.maq_usuariocreoid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = maquinaria.maq_activo
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_InsertarMaquinaria]", listaparametros)
    End Function

    Public Function ActualizarMaquinaria(ByVal maquinaria As Maquinaria) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@descripcion"
        parametro.Value = maquinaria.maq_descripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuariomodifica"
        parametro.Value = maquinaria.maq_usuariomodificoid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = maquinaria.maq_activo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idmaquinaria"
        parametro.Value = maquinaria.maq_maquinaid
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ModificarMaquinaria]", listaparametros)
    End Function

    Public Function listaFraccioness(Optional FraccionesRepetidas As String = "") As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select frap_fraccionid 'ID', frap_descripcion 'Fracción' from Produccion.CatalagoFracciones where frap_activo=1 "
        If FraccionesRepetidas = "" Then
            consulta += " order by frap_descripcion"
        Else
            consulta += "and not frap_fraccionid in ( " + FraccionesRepetidas.ToString() + ") order by frap_descripcion"
        End If

        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function listaFraccionesNave(ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "NaveID"
        parametro.Value = NaveID
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_FraccionesNave]", listaparametros)
    End Function

    Public Function filtradoCambiosGlobales(ByVal nave As Integer, ByVal marca As Integer, ByVal coleccion As Integer,
                                            ByVal componentes As List(Of Integer), ByVal prodEstilo As List(Of Integer), ByVal accion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
          select distinct 0 ' ',pe.pres_estatusdesarrollo 'Estatus',         
            m.marc_descripcion 'Marca', p.prod_codigo 'Codigo', c.cole_descripcion 'Colección' ,p.prod_modelo 'Modelo',
            CONCAT(piel.piel_descripcion,' ',color.color_descripcion) 'Piel Color',
            t.talla_descripcion 'Corrida', pe.pres_totalconsumos 'Total Materiales', 

            ISNULL( STUFF((SELECT CAST(',' AS varchar(MAX)) + nave_nombre
	        from Produccion.ProductoNaveProduccion 
			left join Framework.Naves on nave_naveid=pena_naveid
			where pena_productoestiloid = pe.pres_productoestiloid
	        FOR XML PATH('')), 1, 1, ''),'') as 'Asignado a Producción', 

            cliente.clie_nombregenerico 'Cliente',pe.pres_productoestiloid 'idEstilo' ,cd.code_componenteid 'comp' 
            from Produccion.ConsumosDesarrollo as cd
            left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=cd.code_productoestiloid
            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
            left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
            left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
            left join Programacion.Pieles as piel on piel.piel_pielid=ep.espr_pielid
            left join Programacion.Colores as color on color.color_colorid=ep.espr_colorid
            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
            left join Cliente.Cliente as cliente on cliente.clie_clienteid=p.prod_clienteid
            left join Produccion.ProductoNaveProduccion as pnp on pnp.pena_productoestiloid=pe.pres_productoestiloid
            left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
            where pe.pres_navedesarrollaid=
        </cadena>
        consulta += nave.ToString
        If marca > 0 Then
            consulta += " and m.marc_marcaid=" + marca.ToString
        End If
        If coleccion > 0 Then
            consulta += " and c.cole_coleccionid=" + coleccion.ToString
        End If
        If accion = 1 Then
            If prodEstilo.Count > 0 Then
                consulta += " and pe.pres_productoestiloid not in ("
                For Each id As Integer In prodEstilo
                    consulta += " " & id & ","
                Next
                consulta += " 0)"
            End If
        End If

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function filtradoFracciones(ByVal nave As Integer, ByVal marca As Integer, ByVal coleccion As Integer,
                                       ByVal fraccion As Integer, ByVal nuevo As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>

          select distinct 0 ' ',pe.pres_estatusdesarrollo 'Estatus',         
            m.marc_descripcion 'Marca', p.prod_codigo 'Codigo', c.cole_descripcion 'Colección' ,p.prod_modelo 'Modelo',
            CONCAT(piel.piel_descripcion,' ',color.color_descripcion) 'Piel Color',
            t.talla_descripcion 'Corrida', pe.pres_totalconsumos 'Total Materiales', 

            ISNULL( STUFF((SELECT CAST(',' AS varchar(MAX)) + nave_nombre
	        from Produccion.ProductoNaveProduccion 
			left join Framework.Naves on nave_naveid=pena_naveid
			where pena_productoestiloid = pe.pres_productoestiloid
	        FOR XML PATH('')), 1, 1, ''),'') as 'Asignado a Producción', 

            cliente.clie_nombregenerico 'Cliente',pe.pres_productoestiloid 'idEstilo'
            from Produccion.FraccionesDesarrollo as fd
            left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=fd.fd_productoestiloid
            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
            left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
            left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
            left join Programacion.Pieles as piel on piel.piel_pielid=ep.espr_pielid
            left join Programacion.Colores as color on color.color_colorid=ep.espr_colorid
            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
            left join Cliente.Cliente as cliente on cliente.clie_clienteid=p.prod_clienteid
            left join Produccion.ProductoNaveProduccion as pnp on pnp.pena_productoestiloid=pe.pres_productoestiloid
            left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
            where pe.pres_navedesarrollaid=
        </cadena>
        consulta += nave.ToString
        If marca > 0 Then
            consulta += " and m.marc_marcaid=" + marca.ToString
        End If
        If coleccion > 0 Then
            consulta += " and c.cole_coleccionid=" + coleccion.ToString
        End If
        If nuevo <> 0 Then
            consulta += "and fd.fd_fraccionid=" + fraccion.ToString
        End If
        consulta += " and pe.pres_estatusdesarrollo<>'I' and pe.pres_estatusdesarrollo<>'DP'"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function filtradoCambiosGlobales2(ByVal nave As Integer, ByVal marca As Integer, ByVal coleccion As Integer,
                                            ByVal componentes As List(Of Integer), ByVal prodEstilo As List(Of Integer), ByVal accion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
          select distinct 0 ' ',pe.pres_estatusdesarrollo 'Estatus',         
            m.marc_descripcion 'Marca', p.prod_codigo 'Codigo', c.cole_descripcion 'Colección' ,p.prod_modelo 'Modelo',
            CONCAT(piel.piel_descripcion,' ',color.color_descripcion) 'Piel Color',
            t.talla_descripcion 'Corrida', pe.pres_totalconsumos 'Total Materiales', 

            ISNULL( STUFF((SELECT CAST(',' AS varchar(MAX)) + nave_nombre
	        from Produccion.ProductoNaveProduccion 
			left join Framework.Naves on nave_naveid=pena_naveid
			where pena_productoestiloid = pe.pres_productoestiloid
	        FOR XML PATH('')), 1, 1, ''),'') as 'Asignado a Producción', 

            cliente.clie_nombregenerico 'Cliente',pe.pres_productoestiloid 'idEstilo'
            from Produccion.ConsumosDesarrollo as cd
            left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=cd.code_productoestiloid
            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
            left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
            left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
            left join Programacion.Pieles as piel on piel.piel_pielid=ep.espr_pielid
            left join Programacion.Colores as color on color.color_colorid=ep.espr_colorid
            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
            left join Cliente.Cliente as cliente on cliente.clie_clienteid=p.prod_clienteid
            left join Produccion.ProductoNaveProduccion as pnp on pnp.pena_productoestiloid=pe.pres_productoestiloid
            left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
            where pe.pres_navedesarrollaid=
        </cadena>
        consulta += nave.ToString
        If marca > 0 Then
            consulta += " and m.marc_marcaid=" + marca.ToString
        End If
        If coleccion > 0 Then
            consulta += " and c.cole_coleccionid=" + coleccion.ToString
        End If
        If accion = 1 Then
            If prodEstilo.Count > 0 Then
                consulta += " and pe.pres_productoestiloid not in ("
                For Each id As Integer In prodEstilo
                    consulta += " " & id & ","
                Next
                consulta += " 0)"
            End If
        End If

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function filtradoCambiosGlobales3(ByVal idnave As Integer, ByVal material As Integer, ByVal clas As Integer,
                                              ByVal marca As Integer, ByVal coleccion As Integer, ByVal pProveedor As Integer) As DataTable
        '      '(ByVal nave As Integer, ByVal marca As Integer, ByVal coleccion As Integer,
        '      'ByVal componentes As List(Of Integer), ByVal prodEstilo As List(Of Integer), ByVal accion As Integer) As DataTable
        '      Dim operacion As New Persistencia.OperacionesProcedimientos

        '      '  select distinct 0 ' ',pe.pres_estatusdesarrollo 'Estatus',         
        '      '    m.marc_descripcion 'Marca', p.prod_codigo 'Codigo', c.cole_descripcion 'Colección' ,p.prod_modelo 'Modelo',
        '      '    CONCAT(piel.piel_descripcion,' ',color.color_descripcion) 'Piel Color',
        '      '    t.talla_descripcion 'Corrida', pe.pres_totalconsumos 'Total Materiales', 
        '      '    n.nave_nombre 'Asignado a Producción', cliente.clie_nombregenerico 'Cliente',
        '      '    pe.pres_productoestiloid 'idEstilo'
        '      '    from Produccion.ConsumosDesarrollo as cd
        '      '    left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=cd.code_productoestiloid
        '      '    left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
        '      '    left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
        '      '    left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
        '      '    left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '      '    left join Programacion.Pieles as piel on piel.piel_pielid=ep.espr_pielid
        '      '    left join Programacion.Colores as color on color.color_colorid=ep.espr_colorid
        '      '    left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        '      '    left join Cliente.Cliente as cliente on cliente.clie_clienteid=p.prod_clienteid
        '      '    left join Produccion.ProductoNaveProduccion as pnp on pnp.pena_productoestiloid=pe.pres_productoestiloid
        '      '    left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
        '      '    where pe.pres_navedesarrollaid=
        '      '</cadena>
        '      Dim consulta As String =
        '      <cadena>
        '          select distinct 0 ' ',pe.pres_estatusdesarrollo 'Estatus',         
        '          m.marc_descripcion 'Marca', p.prod_codigo 'Codigo', c.cole_descripcion 'Colección' ,p.prod_modelo 'Modelo',
        '          piel.piel_descripcion+' '+color.color_descripcion 'Piel Color',t.talla_descripcion 'Corrida', round(pe.pres_totalconsumos,2,0) 'Total Materiales', 
        '          cliente.clie_nombregenerico 'Cliente',pe.pres_productoestiloid 'idEstilo',comp.comp_descripción 'Componente',m2.mate_descripcion 'Material',
        '	ISNULL( STUFF((SELECT CAST(',' AS varchar(MAX)) + nave_nombre
        '       from Produccion.ProductoNaveProduccion left join Framework.Naves on nave_naveid=pena_naveid
        '	where pena_productoestiloid = pe.pres_productoestiloid  FOR XML PATH('')), 1, 1, ''),'') as 'Asignado a Producción'
        '          from Produccion.ConsumosDesarrollo as cd
        '          left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=cd.code_productoestiloid
        '          left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
        '          left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
        '          left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
        '          left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '          left join Programacion.Pieles as piel on piel.piel_pielid=ep.espr_pielid
        '          left join Programacion.Colores as color on color.color_colorid=ep.espr_colorid
        '          left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        '	left join Materiales.Materiales as mat on mat.mate_materialid=cd.code_materialid
        '          left join Cliente.Cliente as cliente on cliente.clie_clienteid=p.prod_clienteid
        '          left join Produccion.ProductoNaveProduccion as pnp on pnp.pena_productoestiloid=pe.pres_productoestiloid
        '          left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
        '	left join Produccion.Componentes as comp on comp.comp_componenteid=cd.code_componenteid
        '	join Materiales.MaterialesNave as mn on cd.code_materialid=mn.mn_materialNaveid
        '	join Materiales.Materiales as m2 on m2.mate_materialid=mn.mn_materialid
        '	where pe.pres_navedesarrollaid= 
        '</cadena>
        '      consulta += idnave.ToString
        '      consulta += " and cd.code_materialid =" + material.ToString
        '      consulta += "and cd.code_componenteid in (select cc.cocl_idcomponente from Produccion.componenteClasificacion cc where cocl_idclasificacion=" + clas.ToString + ")"
        '      If marca > 0 Then
        '          consulta += " and m.marc_marcaid=" + marca.ToString
        '      End If
        '      If coleccion > 0 Then
        '          consulta += " and c.cole_coleccionid=" + coleccion.ToString
        '      End If
        '      consulta += " and pe.pres_estatusdesarrollo<> 'DP'"
        '      'If accion = 1 Then
        '      'For Each id As Integer In material
        '      '    consulta += " " & id & ","
        '      'Next
        '      'consulta += "0)"
        '      'End If
        'Return operacion.EjecutaConsulta(consulta)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = idnave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MaterialId"
        parametro.Value = material
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClasificacionId"
        parametro.Value = clas
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MarcaId"
        parametro.Value = marca
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ColeccionId"
        parametro.Value = IIf(coleccion = 0, Nothing, coleccion)
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ProveedorId"
        parametro.Value = pProveedor
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ObtieneCambioGlobal_PRUEBAS]", listaparametros)


    End Function

    Public Function filtradoCambiosGlobales4(ByVal nave As Integer, ByVal clasificacionid As Integer, ByVal materialnaveid As Integer,
                                             ByVal proveedorid As Integer, ByVal marca As Integer, ByVal coleccion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
          select distinct 0 ' ',pe.pres_estatusdesarrollo 'Estatus',         
            m.marc_descripcion 'Marca', p.prod_codigo 'Codigo', c.cole_descripcion 'Colección' ,p.prod_modelo 'Modelo',
            CONCAT(piel.piel_descripcion,' ',color.color_descripcion) 'Piel Color',
            t.talla_descripcion 'Corrida', pe.pres_totalconsumos 'Total Materiales', 

            ISNULL( STUFF((SELECT CAST(',' AS varchar(MAX)) + nave_nombre
	        from Produccion.ProductoNaveProduccion 
			left join Framework.Naves on nave_naveid=pena_naveid
			where pena_productoestiloid = pe.pres_productoestiloid
	        FOR XML PATH('')), 1, 1, ''),'') as 'Asignado a Producción' ,

            cliente.clie_nombregenerico 'Cliente',pe.pres_productoestiloid 'idEstilo'
            from Produccion.ConsumosDesarrollo as cd
            left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=cd.code_productoestiloid
            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
            left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
            left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
            left join Programacion.Pieles as piel on piel.piel_pielid=ep.espr_pielid
            left join Programacion.Colores as color on color.color_colorid=ep.espr_colorid
            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
            left join Cliente.Cliente as cliente on cliente.clie_clienteid=p.prod_clienteid
            left join Produccion.ProductoNaveProduccion as pnp on pnp.pena_productoestiloid=pe.pres_productoestiloid
            left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
			left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=
        </cadena>
        consulta += materialnaveid.ToString
        consulta += "   where pe.pres_navedesarrollaid=" + nave.ToString
        consulta += " and m.marc_marcaid=" + marca.ToString
        If coleccion = 0 Then
        Else
            consulta += " and p.prod_coleccionid=" + coleccion.ToString
        End If
        consulta += " and cd.code_clasificacionid=" + clasificacionid.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaDeMarcasPNP(ByVal nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select DISTINCT  m.marc_marcaid 'ID', m.marc_descripcion 'Marca'
            from Programacion.ProductoEstilo as pe
            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
            left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
            WHERE pe.pres_navedesarrollaid=
        </cadena>
        consulta += nave.ToString
        'Dim consulta As String =
        '<cadena>
        '    select distinct m.marc_marcaid 'ID', m.marc_descripcion 'Marca'  
        '    from Produccion.ConsumosDesarrollo as cd
        '    left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid= cd.code_productoestiloid
        '    left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
        '    left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
        '    where pe.pres_navedesarrollaid=
        '</cadena>
        'consulta += nave.ToString + " order by marc_descripcion"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaDeMarcasEnMaterialSeleccionado(ByVal pNaveId As Integer, ByVal pMaterialNaveId As Integer) As DataTable
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '<cadena>
        '    select  DISTINCT marc.marc_descripcion 'Marca',marc.marc_marcaid 'ID'
        '    from Materiales.MaterialesNave as mn
        '    left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
        '    left join Produccion.ConsumosDesarrollo as cd on cd.code_materialid=mn.mn_materialNaveid
        '    left join Programacion.ProductoEstilo  as pe on pe.pres_productoestiloid=cd.code_productoestiloid
        '    left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
        '    left join Programacion.Marcas as marc on marc.marc_marcaid=p.prod_marcaid
        '    where mn_materialNaveid=
        '</cadena>
        'consulta += materialNave & "  and pe.pres_navedesarrollaid=" & nave.ToString
        'consulta += " and pe.pres_estatusdesarrollo<>'DP'"
        'Return operacion.EjecutaConsulta(consulta)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = pNaveId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MaterialNaveId"
        parametro.Value = pMaterialNaveId
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaMarcasEnMateriales]", listaparametros)


    End Function

    Public Function listaDeMarcasEnMaterialSeleccionadoNave(ByVal pNaveId As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = pNaveId
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaMarcasEnMaterialesNave]", listaparametros)

    End Function

    Public Function ListaMArcasArticulosConConsumos() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select DISTINCT marc.marc_descripcion 'Marca',marc.marc_marcaid 'ID'
            from Programacion.ProductoEstilo as pe
            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
            left join Programacion.Marcas as marc on marc.marc_marcaid=p.prod_marcaid
            where pe.pres_totalfracciones > 0
        </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ListaColeccionesArticulosConConsumos(ByVal marca As Integer, ByVal nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select DISTINCT cl.cole_descripcion 'Coleccion',cl.cole_coleccionid 'ID'
            from Programacion.ProductoEstilo as pe
            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
            left join Programacion.Marcas as marc on marc.marc_marcaid=p.prod_marcaid
            left join Programacion.Colecciones as cl on cl.cole_coleccionid=p.prod_coleccionid
            where marc.marc_marcaid=
        </cadena>
        consulta += marca.ToString & " and pe.pres_totalfracciones > 0 and pe.pres_navedesarrollaid=" & nave.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaDeColeccionesPNP(ByVal nave As Integer, ByVal marca As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '<cadena>
        '    select distinct c.cole_coleccionid 'ID', c.cole_descripcion 'Coleccion'
        '    from Produccion.ConsumosDesarrollo as cd
        '    join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=  cd.code_productoestiloid
        '    join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
        '    join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
        '    where pe.pres_navedesarrollaid=
        '</cadena>
        'consulta += nave.ToString
        'consulta += " and p.prod_marcaid=" + marca.ToString + " order by c.cole_descripcion"
        Dim consulta As String =
       <cadena>
            select DISTINCT c.cole_coleccionid 'ID', c.cole_descripcion 'Coleccion' 
            from Programacion.ProductoEstilo as pe
            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
            left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
            left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
        </cadena>
        consulta += "WHERE pe.pres_navedesarrollaid=" + nave.ToString + "  and p.prod_marcaid=" + marca.ToString
        consulta += " order by c.cole_descripcion"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaDeColeccionesMaterialesSeleccionados(ByVal nave As Integer, ByVal materialNave As Integer,
                                                              ByVal marca As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
       <cadena>
            select DISTINCT c.cole_coleccionid 'ID', c.cole_descripcion 'Coleccion' 
            from Materiales.MaterialesNave as mn
            left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
            left join Produccion.ConsumosDesarrollo as cd on cd.code_materialid=mn.mn_materialNaveid
            left join Programacion.ProductoEstilo  as pe on pe.pres_productoestiloid=cd.code_productoestiloid
            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
            left join Programacion.Marcas as marc on marc.marc_marcaid=p.prod_marcaid
            left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
            where mn_materialNaveid=
        </cadena>
        consulta += materialNave.ToString & " and pe.pres_navedesarrollaid=" & nave.ToString
        consulta += "  and p.prod_marcaid=" & marca.ToString
        consulta += " and pe.pres_estatusdesarrollo<>'DP'"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ObtieneColeccionesNaveMaterialesSeleccionados(ByVal pNaveId As Integer, ByVal pMarcaId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = pNaveId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MarcaId"
        parametro.Value = pMarcaId
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaColeccionEnNaveMarca]", listaparametros)
    End Function

    Public Function listaDeMaquinaria(ByVal nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select mapr_maquinaid 'ID', mapr_descripcion 'Maquina' 
            from Produccion.MaquinariaProduccion where mapr_naveid=
        </cadena>
        consulta += nave.ToString + " order by mapr_descripcion"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function HistorialProductoEstilo(ByVal idproductoestilo As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select hipe_estatusde 'Estatus de', hipe_estatusa 'Estatus a', us.user_username 'Usuario', hipe_fecha 'Fecha Cambio',
            n.nave_nombre 'Nave Asignada'  from Produccion.HistorialProductoEstilo
            left join Framework.Naves as n on n.nave_naveid = hipe_naveasignadaid
            left join Framework.Usuarios as us on us.user_usuarioid=hipe_usuarioid
            where hipe_productoestiloid=
        </cadena>
        consulta += idproductoestilo.ToString + " order by hipe_fecha asc"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function actualizarProveedor(ByVal proveedorid As Integer, ByVal precioP As Double, ByVal umpid As Integer,
                                        ByVal factor As Double, ByVal materialid As Integer, ByVal productoestiloid As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = productoestiloid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@proveedorId"
        parametro.Value = proveedorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@materialId"
        parametro.Value = materialid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@precioumproduccion"
        parametro.Value = precioP
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@umproveedorid"
        parametro.Value = umpid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@factorconversion"
        parametro.Value = factor
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_Desarrollo_Consumos_ActualizarProveedor]", listaParametros)
        'Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = "update Produccion.ConsumosDesarrollo"
        'consulta += " SET "
        'consulta += " code_proveedorid=" + proveedorid.ToString + ","
        'consulta += " code_precioumproduccion=" + precioP.ToString + ","
        'consulta += " code_umproveedorid=" + umpid.ToString + ","
        'consulta += " code_factorconversion=" + factor.ToString
        'consulta += " where code_materialid=" + materialid.ToString + " and code_productoestiloid=" + productoestiloid.ToString
        'Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaClasificaciones() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select 0 ' ',clas_idclasificacion 'ID', clas_nombreclas 'Clasificación' from Materiales.Clasificaciones order by clas_nombreclas"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function GuardarComponenteClasificacion(ByVal cocl As ComponenteClasificacion) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@clasificacion"
        parametro.Value = cocl.cocl_idclasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@componente"
        parametro.Value = cocl.cocl_idcomponente
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuariocreo"
        parametro.Value = cocl.cocl_usuariocreo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = cocl.cocl_activo
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ComponenteClasificacion]", listaparametros)
    End Function

    Public Function ModificarComponenteClasificacion(ByVal cocl As ComponenteClasificacion) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@clasificacion"
        parametro.Value = cocl.cocl_idclasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@componente"
        parametro.Value = cocl.cocl_idcomponente
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuariomodifico"
        parametro.Value = cocl.cocl_usuariomodifico
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = cocl.cocl_activo
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_CambioComponenteClasificacion]", listaparametros)
    End Function

    Public Function listaClasificacionesSeleccionadas(ByVal componente As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select clas.clas_idclasificacion 'idc',clas.clas_nombreclas 'Clasificacion'
                from Produccion.componenteClasificacion as cocl
                left join Materiales.Clasificaciones as clas on clas.clas_idclasificacion=cocl.cocl_idclasificacion
                where cocl.cocl_activo=1 and  cocl.cocl_idcomponente=
            </cadena>
        consulta += componente.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaMarcas(ByVal nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NavesId"
        parametro.Value = nave
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ListaMarcasporNAve]", listaparametros)

        'Dim consulta As String =
        '<cadena>
        '    select DISTINCT  m.marc_marcaid 'ID', m.marc_descripcion 'Marca'
        '    from Programacion.ProductoEstilo as pe
        '    left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
        '    left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
        '    left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid
        '    WHERE (pena_naveid=
        '</cadena>
        'consulta += nave.ToString + " or pe.pres_navedesarrollaid=" + nave.ToString + ") order by m.marc_descripcion "
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ListadoMarcasFraccionesNave(ByVal NaveId As Integer, ByVal FraccionId As Integer, ByVal Observaciones As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "NaveID"
        parametro.Value = NaveId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FraccionID"
        parametro.Value = FraccionId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Observaciones"
        parametro.Value = Observaciones
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ObtenerMarcasFraccionesNave]", listaparametros)
    End Function

    Public Function ListadoColeccionFraccionesNaveMarca(ByVal NaveId As Integer, ByVal FraccionId As Integer, ByVal Observaciones As String, ByVal MarcaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "NaveID"
        parametro.Value = NaveId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FraccionID"
        parametro.Value = FraccionId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Observaciones"
        parametro.Value = Observaciones
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MarcaID"
        parametro.Value = MarcaID
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ObtenerColeccionesFraccionesNave]", listaparametros)
    End Function


    Public Function listaMarcasImportarConsumos(ByVal nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select DISTINCT  m.marc_marcaid 'ID', m.marc_descripcion 'Marca'
            from Programacion.ProductoEstilo as pe
            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
            left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
            left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid
            WHERE (pena_naveid=
        </cadena>
        consulta += nave.ToString + " or pe.pres_navedesarrollaid=" + nave.ToString + " and pnp.pena_totalConsumos>0) order by m.marc_descripcion "
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaMarcasProduccion(ByVal nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select DISTINCT m.marc_marcaid 'ID', m.marc_descripcion 'Marca'
            from Produccion.ProductoNaveProduccion as pnp
            left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=pnp.pena_productoestiloid
            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
            left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
            WHERE pnp.pena_naveid=
        </cadena>
        consulta += nave.ToString + " and pnp.pena_estatus<>'I' order by m.marc_descripcion"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaMarcasPorAsignar() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
           select DISTINCT  m.marc_marcaid 'ID', m.marc_descripcion 'Marca'
            from Programacion.ProductoEstilo as pe
            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
            left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
            left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid
            WHERE (pe.pres_navedesarrollaid is null)
            order by m.marc_descripcion
        </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaMarcasPorAsignar(ByVal NaveID As Integer) As DataTable
        '     Dim operacion As New Persistencia.OperacionesProcedimientos
        '     Dim consulta As String =
        '     <cadena>
        '      select DISTINCT  m.marc_marcaid 'ID', m.marc_descripcion 'Marca'
        '         from Programacion.ProductoEstilo as pe
        '         left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
        '         left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
        '         left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid
        'left join Produccion.HistorialProductoEstilo hpe    on hpe.hipe_productoestiloid = pe.pres_productoestiloid   
        '         WHERE hpe.hipe_estatusa is NULL
        'and pe.pres_navedesarrollaid =<%= NaveID.ToString %>
        '         and pe.pres_activo=1
        'and pe.pres_estatus in (3,4)
        '         and p.prod_activo =1
        '         order by m.marc_descripcion

        '     </cadena>
        '     Return operacion.EjecutaConsulta(consulta)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@NaveSAYID"
            parametro.Value = NaveID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsumosNave_ListadoMarcasPorAsignar]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function



    ''' <summary>
    ''' lista de colecciones nave de produccion
    ''' </summary>
    ''' <param name="nave"></param>
    ''' <param name="marca"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listaColecciones(ByVal nave As Integer, ByVal marca As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select DISTINCT c.cole_coleccionid 'ID', c.cole_descripcion 'Coleccion'
            from Produccion.ProductoNaveProduccion as pnp
            left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=pnp.pena_productoestiloid
            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
            left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
            left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
        </cadena>
        consulta += "WHERE (pnp.pena_naveid=" + nave.ToString + "or pnp.pena_naveasigno= " + nave.ToString + ") and p.prod_marcaid=" + marca.ToString + " order by c.cole_descripcion"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' lista de colecciones sin asignar
    ''' </summary>
    ''' <param name="nave"></param>
    ''' <param name="marca"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listaColeccionesSinAsignar(ByVal marca As Integer, ByVal Nave As Integer) As DataTable
        '     Dim operacion As New Persistencia.OperacionesProcedimientos
        '     Dim consulta As String =
        '     <cadena>
        '         select DISTINCT c.cole_coleccionid 'ID', c.cole_descripcion+' - '+t.temp_nombre 'Coleccion'
        '         from Programacion.ProductoEstilo as pe  
        '         left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid 
        '         left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid 
        '         left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid 
        'left join Programacion.Temporadas as t on t.temp_temporadaid=p.prod_temporadaid 
        '         WHERE p.prod_marcaid=<%= marca %> and (pe.pres_navedesarrollaid is null or pe.pres_navedesarrollaid=<%= Nave %>) 
        '      AND pe.pres_totalconsumos is NULL 
        '         order by c.cole_descripcion+' - '+t.temp_nombre
        '     </cadena>
        '     consulta += ""
        '     Return operacion.EjecutaConsulta(consulta)
        '     Dim operacion As New Persistencia.OperacionesProcedimientos
        '     Dim consulta As String =
        '     <cadena>
        '         select DISTINCT c.cole_coleccionid 'ID', c.cole_descripcion+' - '+t.temp_nombre 'Coleccion'
        '         from Programacion.ProductoEstilo as pe  
        '         left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid 
        '         left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid 
        '         left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid 
        'left join Programacion.Temporadas as t on t.temp_temporadaid=p.prod_temporadaid 
        '         left join Produccion.HistorialProductoEstilo hpe    on hpe.hipe_productoestiloid = pe.pres_productoestiloid  
        '         WHERE p.prod_marcaid=<%= marca %> and ( pe.pres_navedesarrollaid=<%= Nave %>) 
        '      and hpe.hipe_estatusa is NULL  
        '         and pe.pres_activo=1
        'and pe.pres_estatus in (3,4)
        '         and p.prod_activo =1
        '         order by c.cole_descripcion+' - '+t.temp_nombre
        '     </cadena>
        '     consulta += ""
        '     Return operacion.EjecutaConsulta(consulta)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@NaveSAYID"
            parametro.Value = Nave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@marca"
            parametro.Value = marca
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsumosNave_ListadoColeccionesSinAsignar]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    ''' <summary>
    ''' lista de colecciones nave que desarrolla
    ''' </summary>
    ''' <param name="nave"></param>
    ''' <param name="marca"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listaColeccionesNaveDesarrolla(ByVal nave As Integer, ByVal marca As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select DISTINCT c.cole_coleccionid 'ID', c.cole_descripcion +' - '+ t.temp_nombre 'Coleccion' 
            from Programacion.ProductoEstilo as pe
            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
            left join Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
            left join Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
            left join Programacion.Temporadas as t on t.temp_temporadaid=p.prod_temporadaid 
            left join Produccion.ProductoNaveProduccion as pnp  on pe.pres_productoestiloid=pnp.pena_productoestiloid
        </cadena>
        consulta += "WHERE (pena_naveid=" + nave.ToString + " or pe.pres_navedesarrollaid=" + nave.ToString + ")  and p.prod_marcaid=" + marca.ToString
        consulta += " order by c.cole_descripcion +' - '+ t.temp_nombre "
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function VerListaProductosImportarConsumos(ByVal naveid As Integer, ByVal marca As Integer,
                                                      ByVal coleccion As Integer, ByVal articulo As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
               select DISTINCT 0 ' ',
                ' ' 'Estatus',pe.pres_imagen 'Ruta',' ' 'Imagen',m.marc_descripcion 'Marca',
                status= case pe.pres_estatusdesarrollo  when 'D' then 'DESARROLLO'  when 'AD' then 'AUTORIZADO DESARROLLO'
				when 'AP' then 'AUTORIZADO PRODUCCIÓN'  when 'I' then 'INACTIVO NAVE'  when 'DP' then 'DESCONTINUADO' end,
                pe.pres_codSicy 'Código',pe.pres_productoestiloid 'EstiloID',prod.prod_descripcion 'Colección',
				prod.prod_codigo 'Modelo',prod.prod_modelo 'Modelo SICY',p.piel_descripcion 'Piel',c.color_descripcion 'Color','' 'Piel Color',
				t.talla_descripcion 'Corrida',pe.pres_totalconsumos 'Total Materiales',
                 pnp.pena_totalFracciones  'Total Fracciones',
                pnp.pena_naveid as NaveID, pnp.pena_productonaveid as ProductoNaveId,

                ISNULL( STUFF((SELECT CAST(',' AS varchar(MAX)) + nave_nombre
	            from Produccion.ProductoNaveProduccion 
			    left join Framework.Naves on nave_naveid=pena_naveid
			    where pena_productoestiloid = pe.pres_productoestiloid
	            FOR XML PATH('')), 1, 1, ''),'') as 'Asignación Producción', 

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
				left join Programacion.Colecciones as col on col.cole_coleccionid=prod.prod_coleccionid
            </cadena>
        consulta += " where (pena_naveid=" + naveid.ToString + " or pe.pres_navedesarrollaid=" + naveid.ToString
        consulta += " and pe.pres_activo=1 and pe.pres_totalconsumos is not null) "
        If marca <> 0 Then
            consulta += " and m.marc_marcaid=" + marca.ToString
        End If
        If coleccion <> 0 Then
            consulta += " and col.cole_coleccionid= " + coleccion.ToString
        End If
        consulta += "and pe.pres_productoestiloid<>" + articulo.ToString
        consulta += " and pe.pres_estatusdesarrollo <>'I' and pe.pres_estatusdesarrollo <>'DP'"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function VerListaProductosImportarConsumos2(ByVal naveid As Integer, ByVal marca As Integer,
                                                      ByVal coleccion As Integer, ByVal articulo As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "Naveid"
        parametro.Value = naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Marca"
        parametro.Value = marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Coleccion"
        parametro.Value = coleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Articulo"
        parametro.Value = articulo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Materiales].[SP_ListadoProductosImportar]", listaParametros)

    End Function


    Public Function getconsumosCopiar(ByVal productoEstiloId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>                        
            select 0 ' ', cd.code_activo 'Activo',0 'Editado',cd.code_bloqueado 'Bloqueado',cd.code_explosionar 'Explosionar',cd.code_lotear 'Lotear',
            c.comp_componenteid 'idComponente',c.comp_descripción 'Componente',cl.clas_idclasificacion 'idClasificacion', cl.clas_nombreclas 'Clasificación',
            mn.mn_materialNaveid 'IdMaterial',m.mate_sku 'SKU',
            m.mate_descripcion 'Material',cd.code_consumodesarrolloid 'idConsumo', cd.code_consumo 'Consumo',um1.unme_idunidad 'idUMC',um1.unme_descripcion 'UMC',
             p.prov_proveedorid 'idProveedor', p.prov_razonsocial 'Proveedor',cd.code_preciocompra 'Precio UMC',um2.unme_idunidad 'idUMProd',um2.unme_descripcion 'UMP',
            cd.code_factorconversion 'Factor',cd.code_precioumproduccion 'Precio UMP',
            --(cd.code_precioumproduccion *cd.code_consumo) 'Costo X Par',
            cd.code_costopar as 'Costo X Par',
            pe.pres_productoestiloid 'productoEstiloId'
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
        consulta += " where pe.pres_productoestiloid=" & productoEstiloId & " and cd.code_activo=1  and pe.pres_activo =1 "
        'consulta += " where pe.pres_productoestiloid=" & productoEstiloId & " and cd.code_activo=1 and  m.mate_activo =1 and pe.pres_activo =1 "
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function getfraccionesCopiar(ByVal productoEstiloId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
           select 0 ' ' ,fd_activo 'Activo',frap_fraccionid 'idFraccion',fd_fracciondesarrolloid 'idFraccDes',
            frap_descripcion 'Fracción',fd.fd_costo 'Costo',Convert(Bit,frap_paga) 'Pagar',fd.fd_sumarcosto'Sumar Costo',
            fd.fd_tiempohoras'Horas',fd.fd_tiempominutos'Minutos',fd.fd_tiemposegundos'Segundos',fd.fd_sumartiempo 'Sumar Tiempo',
            mapr_descripcion 'Maquinaria',fd.fd_observaciones 'Observaciones' from Produccion.CatalagoFracciones inner join 
            Produccion.FraccionesDesarrollo  fd ON frap_fraccionid=fd_fraccionid left join Produccion.MaquinariaProduccion
			on fd.fd_maquinaid=mapr_maquinaid
            left join Produccion.FraccionOrdenamiento fo on fo.fror_fraccionid = fd.fd_fracciondesarrolloid
            and mapr_activo =1
            </cadena>
        consulta += " where fd_productoestiloid=" & productoEstiloId & " and fd_activo=1  "
        consulta += "  order by fo.fror_numero asc "
        Dim d As New DataTable
        d = operacion.EjecutaConsulta(consulta)
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function getfraccionesCopiar2(ByVal productoEstiloId As Integer, ByVal NaveID As Integer, ByVal ProductoNAveID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos


        Dim consulta As String =
            <cadena>
           select 0 ' ' ,fd_activo 'Activo',frap_fraccionid 'idFraccion',fd_fracciondesarrolloid 'idFraccDes',
            frap_descripcion 'Fracción',fd.fd_costo 'Costo',Convert(Bit,frap_paga) 'Pagar',fd.fd_sumarcosto'Sumar Costo',
            fd.fd_tiempohoras'Horas',fd.fd_tiempominutos'Minutos',fd.fd_tiemposegundos'Segundos',fd.fd_sumartiempo 'Sumar Tiempo',
            mapr_descripcion 'Maquinaria',fd.fd_observaciones 'Observaciones' from Produccion.CatalagoFracciones inner join 
            Produccion.FraccionesDesarrollo  fd ON frap_fraccionid=fd_fraccionid left join Produccion.MaquinariaProduccion
			on fd.fd_maquinaid=mapr_maquinaid
            left join Produccion.FraccionOrdenamiento fo on fo.fror_fraccionid = fd.fd_fracciondesarrolloid
            and mapr_activo =1
            </cadena>
        consulta += " where fd_productoestiloid=" & productoEstiloId & " and fd_activo=1  "
        consulta += "  order by fo.fror_numero asc "
        Dim d As New DataTable
        d = operacion.EjecutaConsulta(consulta)
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ConsumosSeleccionados(ByVal listaConsumos As List(Of Integer)) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                  select 0 ' ' ,
                cd.code_activo 'Activo', 0 'Editado' ,cd.code_bloqueado 'Bloqueado',cd.code_explosionar 'Explosionar', cd.code_lotear 'Lotear', 
                cd.code_componenteid 'idComponente', c.comp_descripción 'Componente',
                cd.code_clasificacionid 'idClasificacion', clas.clas_nombreclas 'Clasificación', cd.code_materialid 'IdMaterial',
                m.mate_sku 'SKU',m.mate_descripcion 'Material', cd.code_consumodesarrolloid 'idConsumo',
                cd.code_consumo 'Consumo',cd.code_umproveedorid 'idUMC',unm.unme_descripcion 'UMC',
                dg.prov_proveedorid 'idProveedor', dg.prov_razonsocial 'Proveedor',cd.code_preciocompra 'Precio Compra',
                cd.code_umproduccionid 'idUMProd',um.unme_descripcion 'UMP',cd.code_factorconversion 'Factor',
                cd.code_precioumproduccion 'PrecioUM',cd.code_costopar 'Costo X Par',cd.code_productoestiloid 'productoEstiloId',
                isnull(co.coor_numero,1) as Orden
                from Produccion.ConsumosDesarrollo as cd
				left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cd.code_materialid
                left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
                left join Materiales.UnidadDeMedida as um on um.unme_idunidad=cd.code_umproduccionid
                left join Produccion.Componentes as c on c.comp_componenteid=cd.code_componenteid
                left join Materiales.Clasificaciones as clas on clas.clas_idclasificacion=cd.code_clasificacionid
                left join Proveedor.Proveedor as dg on dg.prov_proveedorid=cd.code_proveedorid
                left join Materiales.UnidadDeMedida as unm on unm.unme_idunidad=cd.code_umproveedorid
                left join Produccion.ConsumoOrdenamiento co on co.coor_idconsumoid = cd.code_consumodesarrolloid
            </cadena>
        consulta += " where cd.code_consumodesarrolloid in ("
        For Each id As Integer In listaConsumos
            consulta += " " & id & ","
        Next
        consulta += " 0) order by ORDEN asc "

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ConsumoSeleccionadId(ByVal ConsumoId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                  select 0 ' ' ,
                cd.code_activo 'Activo', 0 'Editado' ,cd.code_bloqueado 'Bloqueado',cd.code_explosionar 'Explosionar', cd.code_lotear 'Lotear', 
                cd.code_componenteid 'idComponente', c.comp_descripción 'Componente',
                cd.code_clasificacionid 'idClasificacion', clas.clas_nombreclas 'Clasificación', cd.code_materialid 'IdMaterial',
                m.mate_sku 'SKU',m.mate_descripcion 'Material', cd.code_consumodesarrolloid 'idConsumo',
                cd.code_consumo 'Consumo',cd.code_umproveedorid 'idUMC',unm.unme_descripcion 'UMC',
                dg.prov_proveedorid 'idProveedor', dg.prov_razonsocial 'Proveedor',cd.code_preciocompra 'Precio Compra',
                cd.code_umproduccionid 'idUMProd',um.unme_descripcion 'UMP',cd.code_factorconversion 'Factor',
                cd.code_precioumproduccion 'PrecioUM',cd.code_costopar 'Costo X Par',cd.code_productoestiloid 'productoEstiloId',
                isnull(co.coor_numero,1) as Orden
                from Produccion.ConsumosDesarrollo as cd
				left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cd.code_materialid
                left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
                left join Materiales.UnidadDeMedida as um on um.unme_idunidad=cd.code_umproduccionid
                left join Produccion.Componentes as c on c.comp_componenteid=cd.code_componenteid
                left join Materiales.Clasificaciones as clas on clas.clas_idclasificacion=cd.code_clasificacionid
                left join Proveedor.Proveedor as dg on dg.prov_proveedorid=cd.code_proveedorid
                left join Materiales.UnidadDeMedida as unm on unm.unme_idunidad=cd.code_umproveedorid
                left join Produccion.ConsumoOrdenamiento co on co.coor_idconsumoid = cd.code_consumodesarrolloid
            </cadena>
        consulta += " where cd.code_consumodesarrolloid in (" + ConsumoId.ToString + " "
        'For Each id As Integer In listaConsumos
        '    consulta += " " & id & ","
        'Next
        consulta += " ) order by ORDEN asc "

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function FraccionesSeleccionadss(ByVal listaFracciones As List(Of Integer)) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                 select fd_activo 'Activo',frap_fraccionid 'idFraccion',fd_fracciondesarrolloid 'idFraccDes',
			frap_descripcion 'Fracción',frap_precio 'Costo',Convert(Bit,frap_paga) 'Pagar',mapr_descripcion 'Maquinaria',fd_observaciones 'Observaciones'
			from Produccion.CatalagoFracciones inner join 
            Produccion.FraccionesDesarrollo ON frap_fraccionid=fd_fraccionid left join Produccion.MaquinariaProduccion
            on fd_maquinaid=mapr_maquinaid
            </cadena>
        consulta += " where fd_fracciondesarrolloid in ("
        For Each id As Integer In listaFracciones
            consulta += " " & id & ","
        Next
        consulta += " 0)"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ListaMaterialesConsumosProductoEstilo(ByVal idproductoestilo As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select DISTINCT 0 ' ',cd.code_productoestiloid 'IDPE', mn.mn_materialNaveid 'ID',m.mate_descripcion 'Material',
            m.mate_sku 'SKU',prov.prov_razonsocial 'Proveedor',n.nave_nombre
            from Produccion.ConsumosDesarrollo as cd
            left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cd.code_materialid
            left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
            left join Proveedor.Proveedor as prov on prov.prov_proveedorid=cd.code_proveedorid
			left join Framework.Naves as n on n.nave_naveid=m.mate_navedesarrollaid
            where cd.code_productoestiloid=
        </cadena>
        consulta += idproductoestilo.ToString + " and cd.code_activo=1 and m.mate_autorizado='D' "
        Return operacion.EjecutaConsulta(consulta) '26/04/2021
    End Function
    Public Function ConsuelaProductoEstilo(ByVal idproductoestilo As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@ProductoEstiloId"
        parametro.Value = idproductoestilo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_Desarrollo_Consumos_ProductoEsticoSuela]", listaParametros)
    End Function


    Public Function ListaMaterialesDesarrollo(ByVal listaMateriales As List(Of Integer)) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select *
            from Materiales.Materiales 
            where mate_materialid in (
        </cadena>
        For Each id In listaMateriales
            consulta += " " & id & ","
        Next
        consulta += " 0)"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function EstatusProduccionMateriales(ByVal listaMateriales As List(Of Integer)) As DataTable
        Dim materialesID As String = ""
        For Each id In listaMateriales
            materialesID = materialesID & id & ","
        Next
        materialesID = materialesID & "0"

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioModificoId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@materialesId"
        parametro.Value = materialesID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_Desarrollo_Consumos_EstatusProduccionMateriales]", listaParametros)
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '<cadena>
        '   update Materiales.Materiales
        '    set mate_autorizado='P',
        '       </cadena>
        'consulta += " mate_fechademodificacion='" + DateTime.Now.ToString("dd/MM/yyyy") + "',"
        'consulta += " mate_usuariomodificoid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ""
        'consulta += " where mate_materialid in ("
        'For Each id In listaMateriales
        '    consulta += " " & id & ","
        'Next
        'consulta += " 0) "
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function reemplazarMaterialConsumos(ByVal c As Consumo, ByVal material As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = c.productoEstiloId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@materialId"
        parametro.Value = material
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clasificacionid"
        parametro.Value = c.clasificacionid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@materialModificadoId"
        parametro.Value = c.materialId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@proveedorid"
        parametro.Value = c.proveedorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@umproveedorid"
        parametro.Value = c.umProveedorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@factorconversion"
        parametro.Value = c.factorconversion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@preciocompra"
        parametro.Value = c.preciocompra
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@precioumproduccion"
        parametro.Value = c.precioumproduccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@modificousuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_Desarrollo_Consumos_ReemplazarMaterialConsumos]", listaParametros)
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = " UPDATE Produccion.ConsumosDesarrollo"
        'consulta += " set "
        'consulta += "[code_clasificacionid]=" + c.clasificacionid.ToString + ","
        'consulta += "[code_materialid]=" + c.materialId.ToString + ","
        'consulta += "[code_proveedorid]=" + c.proveedorId.ToString + ","
        'consulta += "[code_umproveedorid]=" + c.umProveedorId.ToString + ","
        'consulta += "[code_factorconversion]=" + c.factorconversion.ToString + ","
        'consulta += "[code_preciocompra]=" + c.preciocompra.ToString + ","

        'consulta += "[code_precioumproduccion]=" + c.precioumproduccion.ToString + ","
        'consulta += "[code_costopar]=code_consumo *" + c.precioumproduccion.ToString + ","
        'consulta += "[code_modificousuarioid]=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ","
        'consulta += "[code_fechamodifico]=getdate()"

        'consulta += " where code_productoestiloid=" + c.productoEstiloId.ToString + " and code_materialid=" + material.ToString
        'Return operacion.EjecutaConsulta(consulta)
    End Function


    Public Sub ReemplazarMaterialConsumos2(ByVal MaterialConsumoNuevo As Consumo, ByVal MaterialIDAnterior As Integer, ByVal UsuarioModificaID As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ProductoEstilo"
        parametro.Value = MaterialConsumoNuevo.productoEstiloId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MaterialIDAnterior"
        parametro.Value = MaterialIDAnterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClasificacionID"
        parametro.Value = MaterialConsumoNuevo.clasificacionid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MaterialIDNuevo"
        parametro.Value = MaterialConsumoNuevo.materialId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProveedorID"
        parametro.Value = MaterialConsumoNuevo.proveedorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UmProveedorID"
        parametro.Value = MaterialConsumoNuevo.umProveedorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UmPRoduccionID"
        parametro.Value = MaterialConsumoNuevo.umproduccionid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FactorConversion"
        parametro.Value = MaterialConsumoNuevo.factorconversion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PrecioCompra"
        parametro.Value = MaterialConsumoNuevo.preciocompra
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PrecioUmProduccion"
        parametro.Value = MaterialConsumoNuevo.precioumproduccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModificaID"
        parametro.Value = UsuarioModificaID
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ReemplazarMaterialConsumoProductoEstilo]", listaParametros)
    End Sub

    Public Function ActualizarPrecioFraccion(ByVal productoEstiloid As Integer, ByVal fraccionid As Integer, ByVal precio As Double) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = productoEstiloid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioModificoId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fraccionId"
        parametro.Value = fraccionid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@precio"
        parametro.Value = precio
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_Desarrollo_Consumos_ActualizarPrecioFraccion]", listaParametros)
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '<cadena>
        '    UPDATE Produccion.FraccionesDesarrollo
        '    SET fd_costo=
        '</cadena>
        'consulta += precio.ToString + ", "
        'consulta += " fd_usuarioModifico=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ","
        'consulta += " fd_fechaModifico='" + DateTime.Now.ToString("dd/MM/yyyy") + "'"
        'consulta += " where fd_productoestiloid=" + productoEstiloid.ToString
        'consulta += " and fd_fraccionid=" + fraccionid.ToString

        'Return operacion.EjecutaConsulta(consulta)
    End Function


    Public Function ActualizarPrecioFraccion2(ByVal productoEstiloid As Integer, ByVal fraccionid As Integer, ByVal precio As Double, ByVal NaveID As Integer, ByVal Observaciones As String, ByVal UsuarioID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ProductoEstilo"
        parametro.Value = productoEstiloid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FraccionID"
        parametro.Value = fraccionid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Precio"
        parametro.Value = precio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NaveID"
        parametro.Value = NaveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Observaciones"
        parametro.Value = Observaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ActualizarCostoFraccionNave]", listaParametros)

        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '<cadena>
        '    UPDATE Produccion.FraccionesDesarrollo
        '    SET fd_costo=
        '</cadena>
        'consulta += precio.ToString + ", "
        'consulta += " fd_usuarioModifico=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ","
        'consulta += " fd_fechaModifico='" + DateTime.Now.ToString("dd/MM/yyyy") + "'"
        'consulta += " where fd_productoestiloid=" + productoEstiloid.ToString
        'consulta += " and fd_fraccionid=" + fraccionid.ToString
        'consulta += " and fd_naveid='" + NaveID.ToString() + "' "
        'consulta += " and fd_observaciones = '" + Observaciones.Trim().ToString() + "' "
        'Return operacion.EjecutaConsulta(consulta)


    End Function

    Public Function listaNavesAsignadasEstilo(ByVal estilo As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select pena_naveid from Produccion.ProductoNaveProduccion where pena_productoestiloid=
        </cadena>
        consulta += estilo.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaProveedoresNave(ByVal nave As Integer, ByVal proveedor As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
           select dage_proveedorid from Proveedor.ProveedorNave where nave_naveid=
        </cadena>
        consulta += nave.ToString + " and dage_proveedorid=" + proveedor.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaMaterialesNave(ByVal nave As Integer, ByVal material As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select mn_materialid from Materiales.MaterialesNave where mn_idNave=
        </cadena>
        consulta += nave.ToString + " and mn_materialid= " + material.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function BuscarFraccionesRepetidas(ByVal ProductoEstilo As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select fd_fraccionid 
            from Produccion.FraccionesDesarrollo
            where fd_productoestiloid=
        </cadena>
        consulta += ProductoEstilo.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ObtenerFraccionesProductoEstiloNave(ByVal ProductoEstilo As Integer, ByVal NaveID As Integer, ByVal FraccionId As Integer, ByVal Observaciones As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select top 1 fd_fraccionid 
            from Produccion.FraccionesDesarrollo
            where fd_productoestiloid=
        </cadena>
        consulta += ProductoEstilo.ToString
        consulta += "and fd_naveid = '" + NaveID.ToString() + "'  and fd_activo = 1 and fd_fraccionid ='" + FraccionId.ToString() + "'  and fd_observaciones ='" + Observaciones.ToString.Trim() + "' "
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ObtenerFraccionesProductoEstiloNave(ByVal ProductoEstilo As Integer, ByVal NaveID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select fd_fraccionid 
            from Produccion.FraccionesDesarrollo
            where fd_productoestiloid=
        </cadena>
        consulta += ProductoEstilo.ToString
        consulta += "and fd_naveid = '" + NaveID.ToString() + "'  and fd_activo = 1 "
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ObtenerFraccionesProductoEstiloNavePorOrden(ByVal ProductoEstilo As Integer, ByVal NaveID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
               SELECT fd.fd_fraccionid  as FraccionID, fd. fd_fracciondesarrolloid as FraccionDesarrolloID, fo.fror_numero as Orden, fd.fd_observaciones as Observaciones 
                from Produccion.FraccionesDesarrollo fd inner join Produccion.FraccionOrdenamiento fo
                on fd.fd_fracciondesarrolloid = fo.fror_fraccionid
                where fd.fd_naveid =
        </cadena>
        consulta += NaveID.ToString
        consulta += " and fd.fd_productoestiloid ='" + ProductoEstilo.ToString + "' "
        consulta += " and fd. fd_activo =1 "
        consulta += " order by fo.fror_numero ASC"


        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaNavesYaAsginadas(ByVal estilosId As String, ByVal accionConsulta As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@productoEstiloIDS"
        parametro.Value = estilosId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@accionConsulta"
        parametro.Value = accionConsulta
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Consumos_ListaNaves Asignadas]", listaParametros)
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '<cadena>
        '   select pena_naveid, pena_estatus from Produccion.ProductoNaveProduccion WHERE pena_productoestiloid in(
        '</cadena>
        'consulta += estilosId.ToString + ") AND (pena_estatus ='AP' OR pena_estatus ='AD')"
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function InsertarProveedoresNave(ByVal nave As Integer, ByVal proveedor As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            insert into Proveedor.ProveedorNave
            (prna_activo,dage_proveedorid,nave_naveid,prna_usuariocreoid,prna_usuariomodificoid,prna_fechacreacion,prna_fechamodificacion)
            VALUES
            (
        </cadena>
        consulta += "1,"
        consulta += proveedor.ToString + ","
        consulta += nave.ToString + ","
        consulta += Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ","
        consulta += Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ","
        consulta += "'" + DateTime.Now.ToString("dd/MM/yyyy") + "',"
        consulta += "'" + DateTime.Now.ToString("dd/MM/yyyy") + "')"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function InsertarMaterialesNave(ByVal nave As Integer, ByVal material As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            insert into Materiales.MaterialesNave
            (mn_materialid,mn_idNave,mn_idDepartamento,mn_usuarioCreo,mn_fechaCreacion,mn_critico,mn_idMaterialRemplazo,mn_activo)
            values
            (
        </cadena>
        consulta += material.ToString + ","
        consulta += nave.ToString + ","
        consulta += "0,"
        consulta += Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ","
        consulta += "'" + DateTime.Now.ToString("dd/MM/yyyy") + "',"
        consulta += "0,"
        consulta += "0,"
        consulta += "1)"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function TipoNave(ByVal nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select ISNULL(nave_desarrolla,0) from Framework.Naves where nave_naveid=
        </cadena>
        consulta += nave.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaNavesAsiganadasaProduccionEstilo(ByVal productoEstiloId As Integer, ByVal naveid As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select DISTINCT 0 ' ',pnp.pena_naveid 'ID', n.nave_nombre 'NAVE',pnp.pena_estatus 'Estatus'
            from Produccion.ProductoNaveProduccion AS pnp
            left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
            where pnp.pena_productoestiloid=
        </cadena>
        consulta += productoEstiloId.ToString + " and (pnp.pena_estatus='AD' or pnp.pena_estatus='AP') and pnp.pena_naveasigno=" + naveid.ToString
        consulta += " "
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function VerListaProductosImagenProduccion(ByVal naveid As Integer, ByVal estatus As String,
                                            ByVal marca As Integer, ByVal coleccion As Integer, ByVal tipoNave As Integer) As DataTable

        Dim EstatusArticulo As String = String.Empty
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select *
                from (
                select DISTINCT 0 " ",
                ' ' 'Estatus',pe.pres_imagen 'Ruta',' ' 'Imagen',m.marc_descripcion 'Marca',
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
                pe.pres_codSicy 'Código', prod.prod_modelo 'Modelo SICY',pe.pres_productoestiloid 'EstiloID',--prod.prod_descripcion 'Colección',
                col.cole_descripcion 'Colección',
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

				cl.clie_razonsocial 'Cliente',pe.pres_navedesarrollaid,pnp.pena_estatus 'OtroStatus',
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
        consulta += " where (pena_naveid=" + naveid.ToString + " or pe.pres_navedesarrollaid=" + naveid.ToString + ") and hpe.hipe_estatusa ='D'"
        'If estatus <> "" Then
        '    consulta += " and pe.pres_estatusdesarrollo='" + estatus.ToString + "'"
        'End If
        If marca <> 0 Then
            consulta += " and prod.prod_marcaid='" + marca.ToString + "'"
        End If
        If coleccion <> 0 Then
            consulta += " and prod.prod_coleccionid='" + coleccion.ToString + "'"
        End If
        consulta += "  and pe.pres_activo=1"
        If tipoNave = 0 Then
            ' consulta += " and pnp.pena_naveid is not null and pnp.pena_estatus<>'I'"
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


        'consulta += " order by prod.prod_descripcion"
        Return operacion.EjecutaConsulta(consulta)







        '===============================
        '    Dim operacion As New Persistencia.OperacionesProcedimientos
        '    Dim consulta As String =
        '        <cadena>
        '           select 0 ' ',
        '            ' ' 'Estatus',pe.pres_imagen 'Ruta',' ' 'Imagen',m.marc_descripcion 'Marca',
        '            status= case (case (
        '                            select COUNT(*)
        '			    From Programacion.ProductoEstilo pe1
        '			    where pe1. pres_navedesarrollaid = <%= naveid %>
        '			    and pe1.pres_productoestiloid =pe.pres_productoestiloid                                     
        '                ) when 1 then pe.pres_estatusdesarrollo else pnp.pena_estatus end
        '            )  when 'D' then 'DESARROLLO'  when 'AD' then 'AUTORIZADO DESARROLLO'
        'when 'AP' then 'AUTORIZADO PRODUCCIÓN'  when 'I' then 'INACTIVO NAVE'  when 'DP' then 'DESCONTINUADO' end,
        '            pe.pres_codSicy'Código', prod.prod_modelo 'Modelo SICY',pe.pres_productoestiloid 'EstiloID',prod.prod_descripcion 'Colección',
        'prod.prod_codigo 'Modelo',p.piel_descripcion 'Piel',c.color_descripcion 'Color','' 'Piel Color',
        't.talla_descripcion 'Corrida',pe.pres_totalconsumos 'Total Materiales',                 
        '            case isnull(pnp.pena_naveid,-1) when -1 then pe.pres_totalfracciones else pnp.pena_totalFracciones end 'Total Fracciones',           
        'cl.clie_razonsocial 'Cliente',pnp.pena_estatus 'OtroStatus', pe.pres_navedesarrollaid
        '            from Produccion.ProductoNaveProduccion as pnp 
        '            left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=pnp.pena_productoestiloid and pnp.pena_naveid=<%= naveid %>
        '            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '            left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
        '            left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
        '            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        '            left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
        '            left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
        '            left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
        '            left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
        '            left join Produccion.HistorialProductoEstilo hpe    on hpe.hipe_productoestiloid = pe.pres_productoestiloid 
        '        </cadena>
        '    consulta += " where (pena_naveid=" + naveid.ToString + " or pe.pres_navedesarrollaid=" + naveid.ToString + ") and hpe.hipe_estatusa ='D'"
        '    If estatus <> "" Then
        '        consulta += " and pe.pres_estatusdesarrollo='" + estatus.ToString + "'"
        '    End If
        '    If marca <> 0 Then
        '        consulta += " and prod.prod_marcaid='" + marca.ToString + "'"
        '    End If
        '    If coleccion <> 0 Then
        '        consulta += " and prod.prod_coleccionid='" + coleccion.ToString + "'"
        '    End If
        '    consulta += "  and pe.pres_activo=1"
        '    If tipoNave = 0 Then
        '        consulta += " and pnp.pena_naveid is not null and pnp.pena_estatus<>'I'"
        '    End If
        '    consulta += " order by prod.prod_descripcion"
        '    Return operacion.EjecutaConsulta(consulta)


        '    Dim operacion As New Persistencia.OperacionesProcedimientos
        '    Dim consulta As String =
        '        <cadena>
        '           select 0 ' ',
        '            ' ' 'Estatus',pe.pres_imagen 'Ruta',' ' 'Imagen',m.marc_descripcion 'Marca',
        '            status= case (case (select count(pnp1.pena_productonaveid) 
        'from Produccion.ProductoNaveProduccion pnp1 where pnp1.pena_naveid=<%= naveid %>
        'and pnp1.pena_productoestiloid=pnp.pena_productoestiloid ) when 0 
        'then pe.pres_estatusdesarrollo else pnp.pena_estatus end)  when 'D' then 'DESARROLLO'  when 'AD' then 'AUTORIZADO DESARROLLO'
        'when 'AP' then 'AUTORIZADO PRODUCCIÓN'  when 'I' then 'INACTIVO NAVE'  when 'DP' then 'DESCONTINUADO' end,
        '            pe.pres_codSicy'Código', prod.prod_modelo 'Modelo SICY',pe.pres_productoestiloid 'EstiloID',prod.prod_descripcion 'Colección',
        'prod.prod_codigo 'Modelo',p.piel_descripcion 'Piel',c.color_descripcion 'Color','' 'Piel Color',
        't.talla_descripcion 'Corrida',pe.pres_totalconsumos 'Total Materiales',                 
        '            case isnull(pnp.pena_naveid,-1) when -1 then pe.pres_totalfracciones else pnp.pena_totalFracciones end 'Total Fracciones',           
        'cl.clie_razonsocial 'Cliente',pnp.pena_estatus 'OtroStatus', pe.pres_navedesarrollaid
        '            from Produccion.ProductoNaveProduccion as pnp 
        '            left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=pnp.pena_productoestiloid and pnp.pena_naveid=<%= naveid %>
        '            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '            left join Programacion.Pieles as p on p.piel_pielid=ep.espr_pielid
        '            left join Programacion.Colores as c on c.color_colorid=ep.espr_colorid
        '            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        '            left join Programacion.Productos as prod on prod.prod_productoid=pe.pres_productoid
        '            left join Cliente.Cliente as cl on cl.clie_clienteid=prod.prod_clienteid
        '            left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
        '            left join Programacion.Marcas as m on m.marc_marcaid=prod.prod_marcaid
        '            left join Produccion.HistorialProductoEstilo hpe    on hpe.hipe_productoestiloid = pe.pres_productoestiloid 
        '        </cadena>
        '    consulta += " where (pena_naveid=" + naveid.ToString + " or pe.pres_navedesarrollaid=" + naveid.ToString + ") and hpe.hipe_estatusa ='D'"
        '    If estatus <> "" Then
        '        consulta += " and pe.pres_estatusdesarrollo='" + estatus.ToString + "'"
        '    End If
        '    If marca <> 0 Then
        '        consulta += " and prod.prod_marcaid='" + marca.ToString + "'"
        '    End If
        '    If coleccion <> 0 Then
        '        consulta += " and prod.prod_coleccionid='" + coleccion.ToString + "'"
        '    End If
        '    consulta += "  and pe.pres_activo=1"
        '    If tipoNave = 0 Then
        '        consulta += " and pnp.pena_naveid is not null and pnp.pena_estatus<>'I'"
        '    End If
        '    consulta += " order by prod.prod_descripcion"
        '    Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaNavesSicy(ByVal nave As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
        <cadena>
           select IdNave,Nave from Naves
        </cadena>
        consulta += " where Nave like '%" + nave + "%'"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function naveMaquila(ByVal nave As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select nave_maquila
            from Framework.Naves where nave_naveid=
        </cadena>
        consulta += nave.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function idLoteProduccion(ByVal fechade As String, ByVal fechaal As String, ByVal nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosPruebas
        Dim consulta As String =
        <cadena>
            select p.idprograma, p.estatus, pn.St from programas p 
        INNER JOIN prgProgramasNave pn ON p.IdPrograma = pn.IdcatPrograma
        </cadena>
        consulta += " where (p.fechaprograma BETWEEN'" + fechade.ToString + "' and '" + fechaal.ToString + "' )and pn.IdCatNave=" + nave.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function consultaLoteProduccion(ByVal listaID As List(Of Integer), ByVal nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
        <cadena>
            SELECT DISTINCT l.año, l.nave, l.lote, cp.IdModelo, ve.IdCodigo, ve.Marca + SPACE(1) + 
            ve.Coleccion AS Coleccion, t.talla, l.color, l.pares, 
            la.NomCortoCortadorPielSay 'cortador',
            la.nomcortocortadorpielsint 'cortadorSint',
            la.NomCortoCortadorForroSay 'cortador_Forro',            
            la.nomcortocortadorforrosint 'cortador_ForroSint', 
            l.Cliente_texto, l.cliente_Nombre,  (Select Sum(Pares) From lotes l 
            inner join Programas pgr on l.Fecha=pgr.FechaPrograma WHERE l.nave=
        </cadena>
        consulta += nave.ToString + " AND pgr.IdPrograma in("
        For Each id In listaID
            consulta += " " & id & ","
        Next
        consulta += "0) ) as TotalPares,   (Select Count(Lote) From lotes l "
        consulta += "inner join Programas pgr on l.Fecha=pgr.FechaPrograma WHERE l.nave=" + nave.ToString + "AND pgr.IdPrograma in("
        For Each id In listaID
            consulta += " " & id & ","
        Next
        consulta += "0))"
        consulta += "as TotalLotes,  (Select top 1 lote  From lotes l inner join Programas pgr on l.Fecha=pgr.FechaPrograma WHERE l.nave=" + nave.ToString
        consulta += " AND pgr.IdPrograma in("
        For Each id In listaID
            consulta += " " & id & ","
        Next
        consulta += "0) order by lote asc) as primer_lote,"
        consulta += "(Select top 1 lote  From lotes l inner join Programas pgr on l.Fecha=pgr.FechaPrograma "
        consulta += " WHERE l.nave= " + nave.ToString + " AND pgr.IdPrograma in("
        For Each id In listaID
            consulta += " " & id & ","
        Next
        consulta += "0) order by lote desc) as ultimo_lote "
        consulta += " FROM lotes l INNER JOIN Programas pgr ON l.Fecha=pgr.FechaPrograma INNER JOIN vEstilos ve ON l.IdCodigo = ve.IdCodigo "
        consulta += " LEFT OUTER JOIN CatProductos cp ON l.IdCatProducto=cp.IdProducto AND l.Nave=cp.IdNave INNER"
        consulta += " JOIN Tallas t ON l.Idtalla=t.Idtalla inner join LotesA la on la.NoLote=l.Lote and la.IdNave=l.Nave and l.Año=la.[Año   ] WHERE l.nave = " + nave.ToString
        consulta += " AND pgr.IdPrograma in("
        For Each id In listaID
            consulta += " " & id & ","
        Next
        consulta += "0) ORDER BY l.lote"

        Return operacion.EjecutaConsulta(consulta)
    End Function

    ' Public Function consultaLoteProduccion(ByVal listaID As List(Of Integer), ByVal nave As Integer) As DataTable
    '     Dim operacion As New Persistencia.OperacionesProcedimientosPruebas
    '     Dim consulta As String =
    '     <cadena>
    '      SELECT rank() over (order by l.lote asc) 'No', l.lote 'Lote', cp.IdModelo 'Modelo', 
    've.IdCodigo, ve.Marca + SPACE(1) + ve.Coleccion 'Colección',
    ' t.talla 'Corrida', l.color 'Color', l.pares 'Pares', l.Suela 'Suela',
    'l.cortador 'Cortador Piel', l.cortador_Forro 'Cortador Forro', 
    '         l.cliente_Nombre 'CLiente'
    'FROM lotes l 
    'INNER JOIN Programas pgr ON l.Fecha=pgr.FechaPrograma INNER JOIN vEstilos ve ON l.IdCodigo = ve.IdCodigo  
    'LEFT OUTER JOIN CatProductos cp ON l.IdCatProducto=cp.IdProducto AND l.Nave=cp.IdNave 
    'INNER JOIN Tallas t ON l.Idtalla=t.Idtalla WHERE  l.nave=
    '     </cadena>
    '     consulta += nave.ToString + " AND pgr.IdPrograma in ("
    '     For Each id In listaID
    '         consulta += " " & id & ","
    '     Next
    '     consulta += "0) ORDER BY l.lote"
    '     Return operacion.EjecutaConsulta(consulta)
    ' End Function

    Public Function consultaLoteProduccionReporte(ByVal listaID As List(Of Integer), ByVal nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosPruebas
        Dim consulta As String =
        <cadena>
            SELECT rank() over (order by l.lote asc) 'No', l.lote 'Lote', cp.IdModelo 'Modelo', 
			ve.IdCodigo, ve.Marca + SPACE(1) + ve.Coleccion 'Colección',
			 t.talla 'Corrida', l.color 'Color', l.pares 'Pares', l.Suela 'Suela',
			l.cortador 'Cortador Piel', l.cortador_Forro 'Cortador Forro', 
            l.Cliente_Texto 'CLiente'
			FROM lotes l 
			INNER JOIN Programas pgr ON l.Fecha=pgr.FechaPrograma INNER JOIN vEstilos ve ON l.IdCodigo = ve.IdCodigo  
			LEFT OUTER JOIN CatProductos cp ON l.IdCatProducto=cp.IdProducto AND l.Nave=cp.IdNave 
			INNER JOIN Tallas t ON l.Idtalla=t.Idtalla WHERE  l.nave=
        </cadena>
        consulta += nave.ToString + " AND pgr.IdPrograma in ("
        For Each id In listaID
            consulta += " " & id & ","
        Next
        consulta += "0) ORDER BY l.lote"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultaCortadores(ByVal nave As Integer, ByVal tipo As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosPruebas
        Dim consulta As String =
        <cadena>
            select pdc.IdCortador 'ID', pdc.IdEmpleado 'ID colaborador',
            c.Nombre + ' ' +c.ApellidoPaterno + ' ' +c.ApellidoMaterno 'Cortador', 
            pdc.NombreCorto 'Nombre Corto',
            case WHEN  pdc.TipoCortador=1 then 'CORTADOR PIEL' else 'CORTADOR FORRO' end as 'Tipo Cortador',
            case WHEN pdc.StCortador='A' then 'ACTIVO' ELSE 'INACTIVO' END AS 'Estatus'
            from pdCortadores AS pdc
            left join nmaEmpleados as c on c.IdEmpleado=pdc.IdEmpleado          
        </cadena>
        consulta += " where pdc.IdNave=" + nave.ToString + " and pdc.StCortador='A' "
        If tipo <> 0 Then
            consulta += " and pdc.TipoCortador=" + tipo.ToString
        End If
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function listaColaboradoresSicy(ByVal nave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosPruebas
        Dim consulta As String =
            <cadena>
               select rank() OVER (ORDER BY c.codr_nombre) as 'No',
    c.codr_nombre +' '+ codr_apellidopaterno+' '+ codr_apellidomaterno 'Colaborador',
    c.codr_colaboradorid 'ID colaborador', 
                isnull (c.codr_nombrecorto,'') 'Nombre Corto',d.IdDepto,d.Departamento,p.IdPuesto,p.Puesto, n.Nave
                from Nomina.Colaborador c left OUTER join nmaEmpleados e on c.codr_nombre=e.Nombre 
                and e.ApellidoPaterno=c.codr_apellidopaterno and c.codr_apellidomaterno=e.ApellidoMaterno
                left join nmaDepartamentos d on e.IdDepto=d.IdDepto and d.Nave=e.Nave
                left join nmaPuestos p on e.IdPuesto=p.IdPuesto and p.Nave=e.Nave
                left join Naves n on e.Nave=n.IdNave
                where c.codr_activo=1 and n.IdNave=
            </cadena>
        consulta += nave.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function listaDepartamentossicy(ByVal nave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosPruebas
        Dim consulta As String =
            <cadena>
                 select 
                 rank() OVER (ORDER BY Departamento) as 'No',
                 IdDepto 'ID', Departamento from nmaDepartamentos
            </cadena>
        consulta += " where Nave=" + nave.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function listaEmpledosLotesProduccion(ByVal Estatus As String, ByVal nave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveId"
        parametro.Value = nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Estatus"
        parametro.Value = Estatus
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_ColaboradoresAvancesProduccion]", listaParametros)

        'Dim consulta As String =
        '    <cadena>                
        '    select distinct laed.IdEmpleadoDepto 'ID', emp.Nombre+' '+emp.ApellidoPaterno+' '+emp.ApellidoMaterno 'Empleado',
        '    emp.IdEmpleado,dpto.IdDepto,laed.IdConfiguracion  'IDC',
        '    dpto.Departamento 'Departamento', laed.Estatus
        '    from LotesAvancesEmpleadosDepto as laed
        '    left join nmaEmpleados as emp on emp.IdEmpleado=laed.IdEmpleado
        '    left join LotesAvancesConfigNaveDepto as lacnd on lacnd.IdConfiguracion=laed.IdConfiguracion
        '    left join nmaDepartamentos as dpto on dpto.IdDepto=lacnd.IdDepto
        '   </cadena>
        'consulta += " where  emp.Nave=" + nave.ToString
        'If Estatus <> "" Then
        '    consulta += " and laed.Estatus='" + Estatus + "'"
        'End If
        'Return operaciones.EjecutaConsulta(consulta)
    End Function

    'Public Function listaEmpledosLotesProduccion(ByVal Estatus As String, ByVal nave As Integer) As DataTable
    '    Dim operaciones As New Persistencia.OperacionesProcedimientosSICY

    '    Dim obj As New Persistencia.OperacionesProcedimientos
    '    Dim listaParametros As New List(Of SqlParameter)
    '    Dim parametro As New SqlParameter

    '    parametro.ParameterName = "@NaveId"
    '    parametro.Value = nave
    '    listaParametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@Estatus"
    '    parametro.Value = Estatus
    '    listaParametros.Add(parametro)

    '    Return obj.EjecutarConsultaSP("[Produccion].[SP_ColaboradoresAvancesProduccion]", listaParametros)

    'End Function

    Public Function ListaMAterialesNaveObtenerMaterialID(ByVal listaMateriales As List(Of Integer)) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
           select mn_materialid 'ID' from Materiales.MaterialesNave
        </cadena>
        consulta += " where mn_materialNaveid in ("
        For Each id In listaMateriales
            consulta += " " & id & ","
        Next
        consulta += " 0) "
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function buscarFraccion(ByVal fraccion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select frap_descripcion from Produccion.CatalagoFracciones 
        </cadena>
        consulta += "where frap_descripcion like '" + fraccion + "'"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function buscarMaquinaria(ByVal maquinaria As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select mapr_descripcion from Produccion.MaquinariaProduccion
        </cadena>
        consulta += "where mapr_descripcion ='" + maquinaria + "'"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultarEstatusProductoEstilo(ByVal articulo As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
                select DISTINCT pnp.pena_estatus 'Estatus', n.nave_nombre 'Nave' , n.nave_naveid
                from Produccion.ProductoNaveProduccion as pnp
                left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
                where pena_productoestiloid=
        </cadena>
        consulta += articulo.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultarEstatusProductoEstiloConNave(ByVal articulo As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
                select pnp.pena_estatus 'Estatus', n.nave_nombre 'Nave' 
                from Produccion.ProductoNaveProduccion as pnp
                left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
                where pena_productoestiloid=
        </cadena>
        consulta += articulo.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultarEstatusProductoEstiloConId(ByVal articulo As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
                select pnp.pena_estatus 'Estatus', n.nave_naveid 'Nave' 
                from Produccion.ProductoNaveProduccion as pnp
                left join Framework.Naves as n on n.nave_naveid=pnp.pena_naveid
                where pena_productoestiloid=
        </cadena>
        consulta += articulo.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function


    '''**************************************************************************
    '''**************************************************************************
    '''**************************************************************************
    Public Function reportePrueba() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos



        Dim consulta As String =
        <cadena>
            select  ROW_NUMBER () OVER (ORDER BY lote_lote) 'No', 
            lote_pares 'Pares',lote_lote 'Lote',m.marc_descripcion+' '+c.cole_descripcion'Colección',p.prod_codigo 'Modelo',t.talla_descripcion 'Corrida',
            piel.piel_descripcion+' '+color.color_descripcion 'Color','SUELA COLLAGE TR  CARAMELO' 'Suela',lp.lote_textocliente 'Cliente'
            from [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteProduccionSicy as lp
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.Marcas as m on m.marc_marcaid=p.prod_marcaid
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.Pieles as piel on piel.piel_pielid=ep.espr_pielid
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.Colores as color on color.color_colorid=ep.espr_colorid
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.ConsumosDesarrollo as cd on cd.code_productoestiloid=lp.lote_productoestiloid
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cd.code_materialid
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Materiales.Materiales as mat on mat.mate_materialid=mn.mn_materialid
            where lote_fechaprograma='25-07-2016' and lote_navesayid=2 
        </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function reportePruebaNoPares() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select  sum(lp.lote_pares) 
			from [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteProduccionSicy as lp
            where lote_fechaprograma='25-07-2016' and lote_navesayid=2
        </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function pedidoEspecialEnProceso() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            			select ROW_NUMBER () OVER (ORDER BY lote_lote) 'No',
			lp.lote_pares 'Pares',lp.lote_lote 'Lote' ,'SUELA COLLAGE TR  CARAMELO' 'Suela', 
            'YUYIN OXFORD' 'Coleccion',t.talla_descripcion'Corrida',
            t.talla_t1 'tl1',t.talla_t2 'tl2',t.talla_t3 'tl3',t.talla_t4 'tl4',t.talla_t5 'tl5',t.talla_t6 'tl6',
            t.talla_t7 'tl7',t.talla_t8 'tl8',t.talla_t9 'tl9',t.talla_t10 'tl10',t.talla_t11 'tl11',t.talla_t12 'tl12',
            t.talla_t13 'tl13',t.talla_t14 'tl14',t.talla_t15 'tl15',t.talla_t16 'tl16',t.talla_t17 'tl17',t.talla_t18 'tl18',
            t.talla_t19 'tl19',t.talla_t20 'tl20'
            ,sum(lap.lota_lt1) 't1',sum(lap.lota_lt2) 't2',sum(lap.lota_lt3) 't3',sum(lap.lota_lt4)'t4',sum(lap.lota_lt5)'t5',
            sum(lap.lota_lt6)'t6',sum(lap.lota_lt7)'t7',sum(lap.lota_lt8)'t8',sum(lap.lota_lt9)'t9',sum(lap.lota_lt10)'t10',
            sum(lap.lota_lt11)'t11',sum(lap.lota_lt12)'t12',sum(lap.lota_lt13)'t13',sum(lap.lota_lt14)'t14',sum(lap.lota_lt15)'t15',
            sum(lap.lota_lt16)'t16',sum(lap.lota_lt17)'t17',sum(lap.lota_lt18)'t18',sum(lap.lota_lt19)'t19',sum(lap.lota_lt20)'t20'
            from [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteProduccionSicy as lp
            left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid
            left join Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
            left join Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.CortadorPielForro as cpf on cpf.copf_cortadorpielforroid=lp.lote_cortadorpielid
            left join Nomina.Colaborador as c on c.codr_colaboradorid=cpf.copf_colaboradorid
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteAProduccionSicy  as lap on lap.lota_lote=lp.lote_lote and lap.lota_naveSicy=11
            and lap.lota_fechaprogramacion='27-06-2016'
            where lp.lote_fechaprograma = '27-06-2016' and lp.lote_navesicyid=11 
            GROUP BY
            lp.lote_lote ,p.prod_descripcion+' '+p.prod_modelo+' '+t.talla_descripcion,
            c.codr_nombre ,lp.lote_pares ,lp.lote_textocliente ,
            t.talla_t1 ,t.talla_t2 ,t.talla_t3,t.talla_t4 ,t.talla_t5 ,t.talla_t6 ,
            t.talla_t7 ,t.talla_t8 ,t.talla_t9 ,t.talla_t10 ,t.talla_t11 ,t.talla_t12 ,
            t.talla_t13 ,t.talla_t14 ,t.talla_t15 ,t.talla_t16 ,t.talla_t17 ,t.talla_t18 ,
            t.talla_t19 ,t.talla_t20,t.talla_descripcion 
            order by lp.lote_lote
        </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    'Reporte de sicy
    'Public Function ConcentradoCasco1() As DataTable
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String =
    '    <cadena>
    '    SELECT EM.Material,sum(LT.Pares) 'Pares',T.Talla 'Corrida',
    '    t.T1,t.T2,t.T3,t.T4,t.T5,t.T6,t.T7,t.T8,t.T9,t.T10,
    '    t.T11,t.T12,t.T13,t.T14,t.T15,t.T16
    '    FROM  [192.168.2.2].[Yuyin_Respaldo].dbo.Lotes AS LT  
    '    JOIN [192.168.2.2].[Yuyin_Respaldo].dbo.Tallas AS T ON LT.IdTalla=T.IdTalla
    '    left JOIN [192.168.2.2].[Yuyin_Respaldo].dbo.pdExplosionMateriales AS EM ON EM.Lote=LT.Lote AND EM.Nave=LT.Nave AND EM.Año=LT.Año
    '    left join [192.168.2.2].[Yuyin_Respaldo].dbo.Proveedores as pro on pro.IdProveedor=em.IdProveedor
    '    WHERE LT.Año=2016 AND LT.Nave=3 AND lt.Fecha='07-07-16' AND EM.IdClasificacion=21 AND EM.IdComponente= 12
    '    and pro.IdProveedor=445
    '    GROUP by EM.Material,T.Talla,
    '    t.T1,t.T2,t.T3,t.T4,t.T5,t.T6,t.T7,t.T8,t.T9,t.T10,
    '    t.T11,t.T12,t.T13,t.T14,t.T15,t.T16
    '    ORDER BY T.Talla
    '    </cadena>
    '    Return operacion.EjecutaConsulta(consulta)
    'End Function

    Public Function ConcentradoCasco1() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select l.lote_productoestiloid 'Producto estilo',m.mate_descripcion 'Material',sum(l.lote_pares) 'Pares',
            t.talla_descripcion 'Corrida',talla_t1 't1',talla_t2't2',talla_t3't3',talla_t4't4',talla_t5't5',talla_t6't6',talla_t7't7',talla_t8't8',
            talla_t9't9',talla_t10't10',talla_t11't11',talla_t12't12',talla_t13't13',talla_t14't14',talla_t15't15',talla_t16't16'
            from [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteProduccionSicy as l
            inner join Produccion.ConsumosDesarrollo as cd on cd.code_productoestiloid=l.lote_productoestiloid
            inner join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cd.code_materialid
            inner join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
            inner join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.Tallas as t on t.talla_tallaid=l.lote_corridasayid
            WHERE lote_fechaprograma ='26-07-2016' and lote_navesicyid=16 and mate_idClasificacion=13
            GROUP by l.lote_productoestiloid,m.mate_descripcion,
            t.talla_descripcion,talla_t1,talla_t2,talla_t3,talla_t4,talla_t5,talla_t6,talla_t7,talla_t8,
            talla_t9,talla_t10,talla_t11,talla_t12,talla_t13,talla_t14,talla_t15,talla_t16
        </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ConcentradoCascoSumado() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select 
            sum(l.lote_pares) 'Pares',count(l.lote_lote) 'Lotes',
            l.lote_productoestiloid 'Producto estilo',m.mate_descripcion 'Material',
            t.talla_descripcion 'Corrida',talla_t1,talla_t2,talla_t3,talla_t4,talla_t5,talla_t6,talla_t7,talla_t8,
            talla_t9,talla_t10,talla_t11,talla_t12,talla_t13,talla_t14,talla_t15,talla_t16
            from [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteProduccionSicy as l
            inner join Produccion.ConsumosDesarrollo as cd on cd.code_productoestiloid=l.lote_productoestiloid
            inner join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cd.code_materialid
            inner join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
            inner join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>]. Programacion.Tallas as t on t.talla_tallaid=l.lote_corridasayid
            WHERE lote_fechaprograma ='26-07-2016' and lote_navesicyid=16 and mate_idClasificacion=13
            GROUP by l.lote_productoestiloid,m.mate_descripcion,
            t.talla_descripcion,talla_t1,talla_t2,talla_t3,talla_t4,talla_t5,talla_t6,talla_t7,talla_t8,
            talla_t9,talla_t10,talla_t11,talla_t12,talla_t13,talla_t14,talla_t15,talla_t16
        </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ConcentradoContrafuerte1() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select l.lote_productoestiloid 'Producto estilo',m.mate_descripcion 'Material',sum(l.lote_pares) 'Pares',
            t.talla_descripcion 'Corrida',talla_t1 't1',talla_t2't2',talla_t3't3',talla_t4't4',talla_t5't5',talla_t6't6',talla_t7't7',talla_t8't8',
            talla_t9't9',talla_t10't10',talla_t11't11',talla_t12't12',talla_t13't13',talla_t14't14',talla_t15't15',talla_t16't16'
            from [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteProduccionSicy as l
            inner join Produccion.ConsumosDesarrollo as cd on cd.code_productoestiloid=l.lote_productoestiloid
            inner join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cd.code_materialid
            inner join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
            inner join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.Tallas as t on t.talla_tallaid=l.lote_corridasayid
            WHERE lote_fechaprograma ='26-07-2016' and lote_navesicyid=16 and mate_idClasificacion=12
            GROUP by l.lote_productoestiloid,m.mate_descripcion,
            t.talla_descripcion,talla_t1,talla_t2,talla_t3,talla_t4,talla_t5,talla_t6,talla_t7,talla_t8,
            talla_t9,talla_t10,talla_t11,talla_t12,talla_t13,talla_t14,talla_t15,talla_t16
        </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    'Reporte de sicy
    '  Public Function ConcentradoCasco2() As DataTable
    '      Dim operacion As New Persistencia.OperacionesProcedimientos
    '      Dim consulta As String =
    '      <cadena>
    '      select DISTINCT em.Material, T.Talla 'Corrida',
    'sum(la.LT01),sum(la.LT02),sum(la.LT03),sum(la.LT04),sum(la.LT05),sum(la.LT06),sum(la.LT07),sum(la.LT08),
    'sum(la.LT09),sum(la.LT10),sum(la.LT11),sum(la.LT12),sum(la.LT13),sum(la.LT14),sum(la.LT15),sum(la.LT16)
    'from [192.168.2.2].[Yuyin_Respaldo].dbo.LotesA as la
    'left JOIN [192.168.2.2].[Yuyin_Respaldo].dbo.pdExplosionMateriales AS EM ON EM.Lote=la.NoLote AND EM.Nave=la.IdNave AND EM.Año=la.[Año   ]
    'JOIN [192.168.2.2].[Yuyin_Respaldo].dbo.Tallas AS T ON La.pltIdTalla=T.IdTalla
    'where la.[Año   ]=2016 and la.IdNave=3 and la.FechaProgramado='07-07-2016' AND EM.IdClasificacion=21 AND EM.IdComponente= 12
    'group by em.Material, T.Talla 
    'ORDER BY T.Talla
    '      </cadena>
    '      Return operacion.EjecutaConsulta(consulta)
    '  End Function

    Public Function ConcentradoCasco2() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select  DISTINCT l.lote_productoestiloid,m.mate_descripcion,t.talla_descripcion 'Corrida', 
            sum(la.lota_lt1)'tl1',sum(la.lota_lt2)'tl2',sum(la.lota_lt3)'tl3',sum(la.lota_lt4)'tl5',sum(la.lota_lt5)'tl5',sum(la.lota_lt6)'tl6',
            sum(la.lota_lt7)'tl7',sum(la.lota_lt8)'tl8',sum(la.lota_lt9)'tl9',sum(la.lota_lt10)'tl10',sum(la.lota_lt11)'tl11',sum(la.lota_lt12)'tl12',
            sum(la.lota_lt13)'tl13',sum(la.lota_lt14)'tl14',sum(la.lota_lt15)'tl15',sum(la.lota_lt16)'tl16'
            from [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteProduccionSicy as l
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteAProduccionSicy as la on la.lota_lote=l.lote_lote 
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.Tallas as t on t.talla_tallaid=l.lote_corridasayid
            left join Produccion.ConsumosDesarrollo as cd on cd.code_productoestiloid=l.lote_productoestiloid
            left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cd.code_materialid
            left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
            where  la.lota_fechaprogramacion='26-07-2016' and la.lota_naveSicy=16 and m.mate_idClasificacion=13
            group by l.lote_productoestiloid,m.mate_descripcion,t.talla_descripcion
        </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ConcentradoContrafuerte2() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select  DISTINCT l.lote_productoestiloid,m.mate_descripcion,t.talla_descripcion 'Corrida', 
            sum(la.lota_lt1)'tl1',sum(la.lota_lt2)'tl2',sum(la.lota_lt3)'tl3',sum(la.lota_lt4)'tl5',sum(la.lota_lt5)'tl5',sum(la.lota_lt6)'tl6',
            sum(la.lota_lt7)'tl7',sum(la.lota_lt8)'tl8',sum(la.lota_lt9)'tl9',sum(la.lota_lt10)'tl10',sum(la.lota_lt11)'tl11',sum(la.lota_lt12)'tl12',
            sum(la.lota_lt13)'tl13',sum(la.lota_lt14)'tl14',sum(la.lota_lt15)'tl15',sum(la.lota_lt16)'tl16'
            from [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteProduccionSicy as l
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteAProduccionSicy as la on la.lota_lote=l.lote_lote 
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.Tallas as t on t.talla_tallaid=l.lote_corridasayid
            left join Produccion.ConsumosDesarrollo as cd on cd.code_productoestiloid=l.lote_productoestiloid
            left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cd.code_materialid
            left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
            where  la.lota_fechaprogramacion='26-07-2016' and la.lota_naveSicy=16 and m.mate_idClasificacion=12
            group by l.lote_productoestiloid,m.mate_descripcion,t.talla_descripcion
        </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function PedidoDeSuelaEspecial() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select lp.lote_lote 'Lote' ,p.prod_descripcion+' '+p.prod_modelo+' '+t.talla_descripcion 'Modelo', lp.lote_color 'Color',
            c.codr_nombre 'Cortador',lp.lote_pares 'Pares',lap.lota_cn 'CN',lp.lote_textocliente 'Cliente',
            t.talla_t1 'tl1',t.talla_t2 'tl2',t.talla_t3 'tl3',t.talla_t4 'tl4',t.talla_t5 'tl5',t.talla_t6 'tl6',
            t.talla_t7 'tl7',t.talla_t8 'tl8',t.talla_t9 'tl9',t.talla_t10 'tl10',t.talla_t11 'tl11',t.talla_t12 'tl12',
            t.talla_t13 'tl13',t.talla_t14 'tl14',t.talla_t15 'tl15',t.talla_t16 'tl16',t.talla_t17 'tl17',t.talla_t18 'tl18',
            t.talla_t19 'tl19',t.talla_t20 'tl20'
            ,sum(lap.lota_lt1) 't1',sum(lap.lota_lt2) 't2',sum(lap.lota_lt3) 't3',sum(lap.lota_lt4)'t4',sum(lap.lota_lt5)'t5',
            sum(lap.lota_lt6)'t6',sum(lap.lota_lt7)'t7',sum(lap.lota_lt8)'t8',sum(lap.lota_lt9)'t9',sum(lap.lota_lt10)'t10',
            sum(lap.lota_lt11)'t11',sum(lap.lota_lt12)'t12',sum(lap.lota_lt13)'t13',sum(lap.lota_lt14)'t14',sum(lap.lota_lt15)'t15',
            sum(lap.lota_lt16)'t16',sum(lap.lota_lt17)'t17',sum(lap.lota_lt18)'t18',sum(lap.lota_lt19)'t19',sum(lap.lota_lt20)'t20',
			t.talla_descripcion'corrida',CONVERT(varchar(150),n.nave_logotipourl),lp.lote_fechaprograma'Fecha'
            from [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteProduccionSicy as lp
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.CortadorPielForro as cpf on cpf.copf_cortadorpielforroid=lp.lote_cortadorpielid
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Nomina.Colaborador as c on c.codr_colaboradorid=cpf.copf_colaboradorid
            left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteAProduccionSicy  as lap on lap.lota_lote=lp.lote_lote and lap.lota_naveSicy=11
            and lap.lota_fechaprogramacion='27-06-2016'
			left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Framework.Naves as n on n.nave_navesicyid=lap.lota_naveSicy
            where lp.lote_fechaprograma = '27-06-2016' and lp.lote_navesicyid=11 
            GROUP BY
            lp.lote_lote ,p.prod_descripcion+' '+p.prod_modelo+' '+t.talla_descripcion , lp.lote_color ,
            c.codr_nombre ,lp.lote_pares ,lap.lota_cn ,lp.lote_textocliente ,
            t.talla_t1 ,t.talla_t2 ,t.talla_t3,t.talla_t4 ,t.talla_t5 ,t.talla_t6 ,
            t.talla_t7 ,t.talla_t8 ,t.talla_t9 ,t.talla_t10 ,t.talla_t11 ,t.talla_t12 ,
            t.talla_t13 ,t.talla_t14 ,t.talla_t15 ,t.talla_t16 ,t.talla_t17 ,t.talla_t18 ,
            t.talla_t19 ,t.talla_t20,t.talla_descripcion,CONVERT(varchar(150),n.nave_logotipourl),lp.lote_fechaprograma
            order by lp.lote_lote
        </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function X() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select ROW_NUMBER () OVER (ORDER BY code_productoestiloid) 'C1',
            m.mate_idClasificacion 'C2',cd.code_productoestiloid 'C3',m.mate_descripcion 'C4',
            t.talla_descripcion 'C5',comp.comp_descripción 'C6'
            from Produccion.ConsumosDesarrollo as cd
            left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cd.code_materialid
            left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
            left join Produccion.Componentes as comp on comp.comp_componenteid=cd.code_componenteid
            left JOIN Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=cd.code_productoestiloid
            left JOIN Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
            left join Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
            where cd.code_productoestiloid IN
            (8400,8401,8402,8403,8404,8405,8406,8407,8408,8409,8410,8411,8412,8413,8414)
            and comp.comp_descripción like '%HERR%'
            order by cd.code_productoestiloid
        </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function Y() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>
            select 
            sum(l.lote_pares) 'C1',count(l.lote_lote) 'C2',
            l.lote_productoestiloid 'C3',m.mate_descripcion 'C4',
            t.talla_descripcion 'C5',talla_t1 'C6'
            from [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteProduccionSicy as l
            inner join Produccion.ConsumosDesarrollo as cd on cd.code_productoestiloid=l.lote_productoestiloid
            inner join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cd.code_materialid
            inner join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
            inner join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>]. Programacion.Tallas as t on t.talla_tallaid=l.lote_corridasayid
            WHERE lote_fechaprograma ='26-07-2016' and lote_navesicyid=16 and mate_idClasificacion=13
            GROUP by l.lote_productoestiloid,m.mate_descripcion,
            t.talla_descripcion,talla_t1
        </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultaReporteHerrajes(ByVal fechaPrograma As String, ByVal nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select
                ROW_NUMBER () OVER (ORDER BY lote_lote) 'No.',
                lote_lote 'Lote',p.prod_modelo 'Modelo',t.talla_descripcion 'Corrida',lp.lote_pares 'Pares',
                m.mate_descripcion 'Material',c.cole_descripcion 'Coleccion',cp.comp_descripción'Herraje'
                from [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteProduccionSicy as lp
                left join Produccion.ConsumosDesarrollo as cd on cd.code_productoestiloid=lp.lote_productoestiloid
                left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cd.code_materialid
                left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
                left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.Tallas as t on t.talla_tallaid=lp.lote_corridasayid
                left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=lp.lote_productoestiloid
                left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
                left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.Colecciones as c on c.cole_coleccionid=p.prod_coleccionid
                left join Produccion.Componentes as cp on cp.comp_componenteid=cd.code_componenteid
            </cadena>
        consulta += "where lp.lote_fechaprograma = '" + fechaPrograma + "' and lote_navesicyid=" + nave.ToString + " and cd.code_componenteid in (9,10,29,30)"
        consulta += " order by cd.code_componenteid ASC"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultaCortadoresPiel(ByVal fechaPrograma As String, ByVal nave As Integer) As DataTable
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '    <cadena>
        '        select DISTINCT ROW_NUMBER() OVER(ORDER BY c.NombreCorto,t.talla_descripcion,p.prod_codigo DESC) AS No,
        '        l.lote_productoestiloid'Pe',l.lote_pares 'Pares',l.lote_lote 'Lote',col.cole_descripcion 'Colección',
        '        p.prod_codigo 'Modelo',t.talla_descripcion 'Corrida',l.lote_color 'Color',m.mate_descripcion 'Material',
        '        c.NombreCorto 'Cortador',sum(cd.code_consumo)'Cantidad',um.unme_descripcion'Unidad'--,cd.code_componenteid 
        '        from [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteProduccionSicy as l
        '        left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteAProduccionSicy as la on la.lota_lote=l.lote_lote
        '        left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=l.lote_productoestiloid
        '        left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.Productos as p on p.prod_productoid=pe.pres_productoid
        '        left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.EstilosProducto as ep on ep.espr_estiloproductoid=pe.pres_estiloid
        '        left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.Tallas as t on t.talla_tallaid=ep.espr_tallaid
        '        left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Programacion.Colecciones as col on col.cole_coleccionid=p.prod_coleccionid
        '        inner join [192.168.2.2].[Yuyin_Respaldo].dbo.pdCortadores as c on c.IdCortador=la.lota_cortadorpielid
        '        left join Produccion.ConsumosDesarrollo as cd on cd.code_productoestiloid=l.lote_productoestiloid
        '        left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Materiales.UnidadDeMedida as um on um.unme_idunidad=cd.code_umproduccionid
        '        left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cd.code_materialid
        '        left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
        '    </cadena>
        'consulta += " where l.lote_fechaprograma = '" + fechaPrograma + "' and l.lote_navesicyid=" + nave.ToString + " and cd.code_componenteid in (1,2,3,4) and cd.code_clasificacionid in (3,24) "
        'consulta += " group by l.lote_productoestiloid,l.lote_lote ,col.cole_descripcion ,m.mate_descripcion,"
        'consulta += " p.prod_codigo ,t.talla_descripcion ,l.lote_color,c.NombreCorto,l.lote_pares,um.unme_descripcion,cd.code_componenteid "
        'consulta += " order by c.NombreCorto,t.talla_descripcion,p.prod_codigo,l.lote_lote"
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultaMaterialesCortadoresPiel(ByVal fechaPrograma As String, ByVal nave As Integer) As DataTable
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '    <cadena>
        '        select  DISTINCT
        '        p.dage_nombrecomercial'Proveedor',m.mate_descripcion 'Material',sum(cd.code_consumo)'Concentrado',c.NombreCorto 'Corta'
        '        from [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteProduccionSicy as l
        '        left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=l.lote_productoestiloid
        '        left join Produccion.ConsumosDesarrollo as cd on cd.code_productoestiloid=l.lote_productoestiloid
        '        left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cd.code_materialid
        '        left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
        '        left join Proveedor.DatosGenerales as p on p.dage_proveedorid=cd.code_proveedorid
        '        left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteAProduccionSicy as la on la.lota_lote=l.lote_lote
        '        inner join [192.168.2.2].[Yuyin_Respaldo].dbo.pdCortadores as c on c.IdCortador=la.lota_cortadorpielid            
        '    </cadena>
        'consulta += "  where  l.lote_fechaprograma = '" + fechaPrograma + "' and l.lote_navesicyid=" + nave.ToString + " and cd.code_componenteid in (1,2,3,4,18,19) and cd.code_clasificacionid in (3,24) "
        'consulta += " group by p.dage_nombrecomercial,m.mate_descripcion,c.NombreCorto order by c.NombreCorto"
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultaCortadoresReporte(ByVal fechaPrograma As String, ByVal nave As Integer) As DataTable
        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '    <cadena>
        '        select  DISTINCT
        '        c.NombreCorto 'Cortadoress'
        '        from [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteProduccionSicy as l
        '        left join Programacion.ProductoEstilo as pe on pe.pres_productoestiloid=l.lote_productoestiloid
        '        left join Produccion.ConsumosDesarrollo as cd on cd.code_productoestiloid=l.lote_productoestiloid
        '        left join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=cd.code_materialid
        '        left join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
        '        left join Proveedor.DatosGenerales as p on p.dage_proveedorid=cd.code_proveedorid
        '        left join [<%= operacion.Servidor %>].[<%= operacion.NombreDB %>].Produccion.LoteAProduccionSicy as la on la.lota_lote=l.lote_lote
        '        inner join [192.168.2.2].[Yuyin_Respaldo].dbo.pdCortadores as c on c.IdCortador=la.lota_cortadorpielid            
        '    </cadena>
        'consulta += "  where  l.lote_fechaprograma = '" + fechaPrograma + "' and l.lote_navesicyid=" + nave.ToString + " and cd.code_componenteid in (1,2,3,4,18,19)"
        'consulta += " group by p.dage_nombrecomercial,m.mate_descripcion,c.NombreCorto order by c.NombreCorto"
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function getidMaquinaria(ByVal descripcion As String) As Integer
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
              select mapr_maquinaid from Produccion.MaquinariaProduccion where mapr_descripcion like '<%= descripcion %>'      
            </cadena>
        datos = operacion.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return datos.Rows(0).Item(0)
        Else
            Return 0
        End If
    End Function

    Public Function GETEstatusProductoEstilo(ByVal ProductoEstilo As Integer) As String
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
              SELECT pres_estatusdesarrollo
                from Programacion.ProductoEstilo
                where pres_productoestiloid ='<%= ProductoEstilo.ToString %>'
            </cadena>
        datos = operacion.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return datos.Rows(0).Item(0)
        Else
            Return 0
        End If
    End Function

    ' '''**************************************************************************
    ' '''**************************************************************************
    ' ''' '''**************************************************************************

    Public Sub ReemplazarMaterialConsumosXml(ByVal MaterialConsumo As String, ByVal UsuarioModificaID As Integer, SoloNaveDesarrollo As Boolean, idNave As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "XmlConsumo"
        parametro.Value = MaterialConsumo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModifica"
        parametro.Value = UsuarioModificaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SoloNaveDesarrollo"
        parametro.Value = SoloNaveDesarrollo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idNave"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ReemplazarMaterialConsumoProductoEstiloXML]", listaParametros)
    End Sub

    Public Function ObtineArticulosMarcaColeccion(ByVal pMarcaId As Integer, ByVal pColeccionId As Integer, ByVal pNaveId As Integer, ByVal pMaterialIds As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@MarcaId"
        parametro.Value = pMarcaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ColeccionId"
        parametro.Value = pColeccionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = pNaveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MaterialIds"
        parametro.Value = pMaterialIds
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaArticulosMarcaColeccion]", listaParametros)
    End Function


    Public Sub GuardaMaterialesCambiosGlobales(ByVal pXmlMateriales As String, ByVal pArticulos As String, ByVal UsuarioModificaID As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@XmlMateriales"
        parametro.Value = pXmlMateriales
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Articulos"
        parametro.Value = pArticulos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IsUsuarioModifica"
        parametro.Value = UsuarioModificaID
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Produccion].[SP_GuardaMaterialesCambiosGlobales]", listaParametros)
    End Sub

    Public Sub ActualizarProduccionNaveProduccion(ByVal pXmlArticulos As String, ByVal pNaveId As Integer, ByVal pUsuarioId As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@xmlArticulos"
        parametro.Value = pXmlArticulos
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = pNaveId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = pUsuarioId
        listaparametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ActualizarProduccionNaveProduccion]", listaparametros)
    End Sub

    Public Sub InsertaActualizaComponenteClasificacion(ByVal pXmlClasificacion As String, ByVal pUsuarioId As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@XmlClasificaciones"
        parametro.Value = pXmlClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdUsuario"
        parametro.Value = pUsuarioId
        listaparametros.Add(parametro)
        objPersistencia.EjecutarConsultaSP("[Produccion].[SP_InsertaActualiza_ComponenteClasificacion]", listaparametros)
    End Sub

    Public Sub EliminaFraccionesGlobales(ByVal pXmlFraccionesProductos As String, ByVal pIdFraccion As Integer, ByVal pIdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@XmlFracciones"
        parametro.Value = pXmlFraccionesProductos
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdFraccion"
        parametro.Value = pIdFraccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Produccion].[SP_EliminarFraccionesGlobales]", listaparametros)
    End Sub

    Public Function ObtieneNavesMaquilas() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Dim parametro As New SqlParameter

        Return operaciones.EjecutaConsulta("[Produccion].[SP_ConsultaListaNavesMaquilas] ")
    End Function

    Public Sub EliminarMaterialConsumosXml(ByVal MaterialConsumo As String, ByVal UsuarioModificaID As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "XmlConsumo"
        parametro.Value = MaterialConsumo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModifica"
        parametro.Value = UsuarioModificaID
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Produccion].[SP_EliminarMaterialConsumoCambioGlobal]", listaParametros)
    End Sub

    Public Function InactivarMaterialConsumoProduccionNave(ByVal productoEstiloID As Integer, ByVal idNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter("@ProductoEstiloId", productoEstiloID)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@IdNave", idNave)
        listaParametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_InactivarMaterialConsumoProduccionNave]", listaParametros)
    End Function

End Class

