Imports Persistencia
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports Entidades

Public Class MaterialesDA
    Public Function getEstatusAutorizado(ByVal idMaterial As Integer) As String
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim estatusAutorizado As String = ""
        Dim consulta As String = <cadena>
        select mate_autorizado from Materiales.Materiales where mate_materialid=<%= idMaterial %>
                                 </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            estatusAutorizado = datos.Rows(0).Item(0).ToString
        End If
        Return estatusAutorizado
    End Function

    Public Function ExisteMaterialEnConsumo(ByVal idMaterial As Integer, ByVal ProveedorID As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim estatusAutorizado As String = ""
        Dim consulta As String =
        <cadena>
            SELECT COUNT(*)
            from Produccion.ConsumosDesarrollo cd inner join Materiales.MaterialesNave mnv on cd.code_materialid = mnv.mn_materialNaveid
            where code_activo =1                                            
        </cadena>
        consulta += " and mnv.mn_materialid='" + idMaterial.ToString + "' "
        consulta += " and code_proveedorid='" + ProveedorID.ToString + "' "
        Return operaciones.EjecutaConsultaEscalar(consulta)

    End Function


    Public Function ExisteMaterialEnInventario(ByVal MAterialNAveID As Integer, ByVal ProveedorID As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim estatusAutorizado As String = ""
        Dim consulta As String =
        <cadena>
                SELECT COUNT(*)
                from Produccion.InventarioNave                                                                      
        </cadena>
        consulta += " where invn_materialnaveid='" + MAterialNAveID.ToString + "'  "
        consulta += " and invn_proveedorid ='" + ProveedorID.ToString + "'   "
        Return operaciones.EjecutaConsultaEscalar(consulta)

    End Function

    Public Function ExisteMaterialActivoEnConsumo(ByVal idMaterial As Integer, ByVal idNave As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim estatusAutorizado As String = ""
        Dim consulta As String =
        <cadena>
            SELECT COUNT(*)
            from Produccion.ConsumosDesarrollo cd inner join Materiales.MaterialesNave mnv 
            on cd.code_materialid = mnv.mn_materialNaveid inner join 
            Programacion.vProductoEstilos_Completo pe on pe.ProductoEstiloId = cd.code_productoestiloid
            where code_activo =1
            and pe.pres_activo=1        
            and pe.EstatusDesarrollo not in ('DP', 'I') and (pe.StatusId not in (5,6))                                                         
        </cadena>
        consulta += " and mnv.mn_materialid='" + idMaterial.ToString + "' "
        consulta += " and mn_idNave = " + idNave.ToString

        Return operaciones.EjecutaConsultaEscalar(consulta)
    End Function


    Public Function getInventarioTotal(ByVal idMaterialNave As Integer, ByVal idProveedor As Integer) As Double
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim inventarioTotal As Double = 0.0
        Dim consulta As String = <cadena>
        select invn_inventariototal from Produccion.InventarioNave where invn_materialnaveid=<%= idMaterialNave %> and invn_proveedorid=<%= idProveedor %>
                                 </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            inventarioTotal = CDbl(datos.Rows(0).Item(0).ToString)
        End If
        Return inventarioTotal
    End Function


    Public Function insertarInventarioNave(ByVal material As MaterialInventario) As String
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim mensaje As New DataTable
        Dim msg As String = ""
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@naveid"
        parametro.Value = material.invn_naveid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@materialnaveid"
        parametro.Value = material.invn_materialnaveid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@proveedorid"
        parametro.Value = material.invn_proveedorid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@movimientoinventarioid"
        parametro.Value = material.invn_movimientoinventarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@cantidad"
        parametro.Value = material.invn_cantidad
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idumc"
        parametro.Value = material.invn_umc
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@precio"
        parametro.Value = material.invn_precio
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@factorconversion"
        parametro.Value = material.invn_factorconversion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idump"
        parametro.Value = material.invn_ump
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@inventariototal"
        parametro.Value = material.invn_inventariototal
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@monedaid"
        parametro.Value = 1
        listaparametros.Add(parametro)
        mensaje = objPersistencia.EjecutarConsultaSP("[Produccion].[InsertInventarioNaveMaterialProduccion]", listaparametros)
        If mensaje.Rows.Count > 0 Then
            msg = mensaje.Rows(0).Item(0).ToString
        End If
        Return msg
    End Function



    Public Sub ActualizarInventarioNave(ByVal material As MaterialInventario)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim mensaje As New DataTable
        Dim msg As String = ""
        Dim listaparametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "MAterialNaveID"
        parametro.Value = material.invn_materialnaveid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProveedorId"
        parametro.Value = material.invn_proveedorid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Precio"
        parametro.Value = material.invn_precio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "umcID"
        parametro.Value = material.invn_umc
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "umpid"
        parametro.Value = material.invn_ump
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Factor"
        parametro.Value = material.invn_factorconversion
        listaparametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ActualizarInventarioNave]", listaparametros)

    End Sub

    Public Function ExisteInventarioMaterialProveedor(ByVal MaterialNaveID As Integer, ByVal ProveedorId As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = <cadena>
    
                SELECT COUNT(*)
                from Produccion.InventarioNave
                where invn_materialnaveid='<%= MaterialNaveID.ToString %>'
                and invn_proveedorid ='<%= ProveedorId.ToString %>'
     
        </cadena>

        Return operaciones.EjecutaConsultaEscalar(consulta)
    End Function

    Public Function ExisteInventarioMaterialProveedorPrecio(ByVal MaterialNaveID As Integer, ByVal ProveedorId As Integer, ByVal Precio As Double) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = <cadena>
    
                SELECT COUNT(*)
                from Produccion.InventarioNave
                where invn_materialnaveid='<%= MaterialNaveID.ToString %>'
                and invn_proveedorid ='<%= ProveedorId.ToString %>'
                and invn_precio='<%= Precio.ToString %>'
        </cadena>

        Return operaciones.EjecutaConsultaEscalar(consulta)
    End Function

    Public Function getMaterial(ByVal idMaterial As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                SELECT mate_materialid, mate_sku, mate_descripcion, mate_idCategoria, mate_idClasificacion, mate_tipodematerial, mate_navedesarrollaid, mate_exclusivo, mate_nombreMaterial
                from Materiales.Materiales
                where mate_materialid='<%= idMaterial.ToString %>'
            </cadena>

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getMaterialNavesParaAgregarEnInventario(ByVal idMaterial As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = <cadena>
        select mn_idNave,nave_nombre 'Nave',mn_materialNaveid,prma_provedorid,prma_idumproveedor,
        prma_idumproduccion,prma_equivalencia 'factorConversion',
        mate_sku 'SKU',mate_descripcion 'Material',prov_razonsocial 'Proveedor',
        prma_umproveedor 'UMC',prma_preciounitario 'Precio',0.0 'Cantidad' from Materiales.Materiales
        inner join Materiales.MaterialesNave
        on mate_materialid=mn_materialid
        inner join Materiales.MaterialesPrecio
        on mn_materialNaveid=prma_idMaterialNave
        inner join Proveedor.Proveedor
        on prma_provedorid=prov_proveedorid
        inner join Framework.Naves 
		on mn_idNave=nave_naveid
        where   prma_activo=1  
        and  mate_materialid=<%= idMaterial %> and
        mate_idClasificacion in (select clas_idclasificacion from Materiales.Clasificaciones where clas_controlinventario=1)
                                 </cadena>
        consulta += " GROUP by prma_preciounitario,prma_provedorid,mn_idNave,mn_materialNaveid,prma_idumproduccion,prma_equivalencia,mate_sku,mate_descripcion,prov_razonsocial,prma_umproveedor,prma_idumproveedor,nave_nombre"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getMaterialParaAgregarEnInventario(ByVal idMaterialNave As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = <cadena>
        select mn_idNave,nave_nombre 'Nave',mn_materialNaveid,prma_provedorid,prma_idumproveedor,
        prma_idumproduccion,prma_equivalencia 'factorConversion',
        mate_sku 'SKU',mate_descripcion 'Material',prov_razonsocial 'Proveedor',
        prma_umproveedor 'UMC',prma_preciounitario 'Precio',0.0 'Cantidad', prma_monedaid 'IdMoneda', mone_simbolo 'MonedaSimbolo', mone_nombre
        from Materiales.Materiales
        inner join Materiales.MaterialesNave on mate_materialid=mn_materialid 
        inner join Materiales.MaterialesPrecio on mn_materialNaveid=prma_idMaterialNave 
        inner join Proveedor.Proveedor on prma_provedorid=prov_proveedorid 
        inner join Framework.Naves on mn_idNave=nave_naveid 
        left join Framework.Moneda on prma_monedaid=mone_monedaid
        where mn_materialNaveid=<%= idMaterialNave %> and prma_activo=1  
        and mate_idClasificacion in (select clas_idclasificacion from Materiales.Clasificaciones where clas_controlinventario=1)
                                 </cadena>
        consulta += " AND mate_materialid in (select mn_materialid from Materiales.MaterialesNave where mn_materialNaveid IN (" & idMaterialNave & "))"
        consulta += " GROUP by prma_preciounitario,prma_provedorid,mn_idNave,mn_materialNaveid,prma_idumproduccion,prma_equivalencia,mate_sku,mate_descripcion,prov_razonsocial,prma_umproveedor,prma_idumproveedor,nave_nombre, prma_monedaid, mone_simbolo, mone_nombre"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getMaterialesParaAgregarEnInventario(ByVal list As List(Of Integer))
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = <cadena>
        select mn_idNave,nave_nombre 'Nave',mn_materialNaveid,prma_provedorid,prma_idumproveedor,
        prma_idumproduccion,prma_equivalencia 'factorConversion',
        mate_sku 'SKU',mate_descripcion 'Material',prov_razonsocial 'Proveedor',
        prma_umproveedor 'UMC',prma_preciounitario 'Precio',0.0 'Cantidad', prma_monedaid 'IdMoneda', mone_simbolo 'MonedaSimbolo' , mone_nombre
        from Materiales.Materiales
        inner join Materiales.MaterialesNave on mate_materialid=mn_materialid 
        inner join Materiales.MaterialesPrecio on mn_materialNaveid=prma_idMaterialNave 
        inner join Proveedor.Proveedor on prma_provedorid=prov_proveedorid 
        inner join Framework.Naves on mn_idNave=nave_naveid
        left join Framework.Moneda on prma_monedaid=mone_monedaid
        where   prma_activo=1 and 
        mate_idClasificacion in (select clas_idclasificacion from Materiales.Clasificaciones where clas_controlinventario=1)
                                 </cadena>
        consulta += " and mate_materialid in ("
        For Each id As Integer In list
            consulta += "" & id & ","
        Next
        consulta += "0)"
        consulta += " GROUP by prma_preciounitario,prma_provedorid,mn_idNave,mn_materialNaveid,prma_idumproduccion,prma_equivalencia,mate_sku,mate_descripcion,prov_razonsocial,prma_umproveedor,prma_idumproveedor,nave_nombre, prma_monedaid, mone_simbolo, mone_nombre"
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function getSKUMaterial(ByVal material As Material) As String
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim sku As New DataTable
        Dim cadena As String = ""
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idMaterial"
        parametro.Value = material.materialId
        listaparametros.Add(parametro)
        sku = objPersistencia.EjecutarConsultaSP("[Materiales].[getSKUMaterial]", listaparametros)
        If sku.Rows.Count > 0 Then
            cadena = sku.Rows(0).Item(0).ToString
        End If
        Return cadena
    End Function

    Public Function consultaCaracteristicas(ByVal idmaterial As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select cara_idcaracteristicas 'ID', "
        consulta += "cara_descripcion 'CARACTERISTICA' ,cara_activo ' 'from materiales.Caracteristicas "
        consulta += "where cara_idmaterial = " + idmaterial.ToString + " and cara_eliminada is null"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function eliminarCaracteristica(ByVal idmaterial As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "update materiales.Caracteristicas"
        consulta += " set cara_eliminada=1 where  cara_idmaterial =" + idmaterial.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function eliminarCaracteristica(ByVal idmaterial As Integer, ByVal Caracteristica As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "update materiales.Caracteristicas "
        consulta += " set cara_eliminada=1 where  cara_idmaterial =" + idmaterial.ToString()
        consulta += "  and cara_descripcion ='" + Caracteristica.Trim().ToString() + "' "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ActualizarCaracteristica(ByVal IDCaracteristica As Integer, ByVal Caracteristica As String, ByVal UsuarioID As Integer) As DataTable
        'Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String

        'consulta = "update Materiales.Caracteristicas "
        'consulta += " set cara_descripcion ='" + Caracteristica.ToString + "', "
        'consulta += " cara_usuariomodificoid ='" + UsuarioID.ToString() + "', "
        'consulta += " cara_fechamodificacion = GETDATE() "
        'consulta += " where cara_idcaracteristicas='" + IDCaracteristica.ToString() + "' "

        'Return operaciones.EjecutaConsulta(consulta)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Descripcion"
        parametro.Value = Caracteristica
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@IdCaracteristica"
        parametro.Value = IDCaracteristica
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        parametro.ParameterName = "@IdUsuario"
        parametro.Value = UsuarioID
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Materiales].[SP_ActualizarCaracteristicasMateriales]", listaparametros)

    End Function



    Public Function ExisteCaracteristicaMaterial(ByVal IdMaterial As Integer, ByVal Caracteristica As String) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String

        consulta = " SELECT COUNT(*) "
        consulta += " from Materiales.Caracteristicas "
        consulta += " where cara_idmaterial ='" + IdMaterial.ToString + "' "
        consulta += " and cara_descripcion ='" + Caracteristica.Trim.ToString() + "' "
        consulta += " and cara_activo =1  "

        Return operaciones.EjecutaConsultaEscalar(consulta)

    End Function

    Public Function insertarCaracteristica(ByVal descripcion As String,
                                           ByVal idmaterial As Integer, ByVal activo As Integer,
                                           ByVal usuariocreo As Integer, ByVal usuariomodifico As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "insert into Materiales.Caracteristicas"
        consulta += "(cara_descripcion,cara_idmaterial,cara_activo,cara_usuariocreoid,cara_fechacreacion,cara_usuariomodificoid,cara_fechamodificacion) VALUES"
        consulta += "('" + descripcion + "'," + idmaterial.ToString + "," + activo.ToString + "," + usuariocreo.ToString + ", GETDATE()," + usuariomodifico.ToString + ",GETDATE())"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getColoresMateriales(ByVal clasificacion As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        'consulta = "select 1 'ID','NO APLICA' 'Color', '00' 'SKU',1'Activo', '00' 'skuSistema'"
        'consulta += " union"
        'consulta += " select M.idColor 'ID', M.color 'Color',CASE WHEN LTRIM(sku) = ''THEN skuSistema ELSE LTRIM(sku)"
        'consulta += " END AS 'SKU',status 'Activo',skuSistema from Materiales.MaterialesColores AS M"
        'consulta += " JOIN MATERIALES.ClasificacionColores AS CLC ON CLC.clco_idcolor=M.idColor"
        'consulta += " where status=1 AND CLC.clco_idclasificacion=" + clasificacion.ToString + " and CLC.clco_estatus=1 order by Color asc"
        consulta = "select M.mcol_idcolor 'ID', M.mcol_color 'Color',"
        consulta += " CASE WHEN LTRIM(M.mcol_sku) = ''THEN M.mcol_skuSistema ELSE LTRIM(M.mcol_sku) END AS 'SKU',M.mcol_status 'Activo',"
        consulta += " M.mcol_skuSistema 'skuSistema' from Materiales.MaterialesColores AS M JOIN MATERIALES.ClasificacionColores AS CLC ON CLC.clco_idcolor=M.mcol_idcolor "
        consulta += " where CLC.clco_estatus=1 AND CLC.clco_idclasificacion=" + clasificacion.ToString + " and CLC.clco_estatus=1 and M.mcol_idcolor<>1 order by Color desc"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getTamañosMateriales(ByVal clasificacion As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select t.tama_idTamano 'ID',t.tama_nombre 'Tamaño',t.tama_sku 'SKU' from Materiales.Tamano as t"
        consulta += " join Materiales.ClasificacionTamanos as c on c.clta_idtamano=t.tama_idTamano"
        consulta += " where t.tama_status=1 and c.clta_idclasificacion=" + clasificacion.ToString + " and c.clta_estatus=1 order by t.tama_nombre asc"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getDepartamentos(ByVal nave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select * from Materiales.departamentos where dept_status=1 and dept_nave=
            </cadena>
        consulta += "" & nave
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getListaTipoMateriales() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select * from Materiales.TiposMateriales where tima_status=1
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getListaMateriales(ByVal material As Material, ByVal nave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select 0 'mate_materialid','NINGUNO' 'mate_descripcion' union " +
            "select mate_materialid,mate_descripcion from Materiales.Materiales as m join Materiales.MaterialesNave as mn on mn.mn_materialid=m.mate_materialid  where mate_activo=1 "
        If material.categoria > 0 Then
            consulta += " and mate_idCategoria=" & material.categoria & " "
        End If
        If material.clasificacion > 0 Then
            consulta += " and mate_idClasificacion=" & material.clasificacion & " "
        End If
        If material.materialId > 0 Then
            consulta += " and mate_materialid<>" & material.materialId & " "
        End If
        consulta += "and mn.mn_idNave= " + nave.ToString + " order by mate_materialid"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getDatosMaterial(ByVal idMaterial As Integer, ByVal idNave As Integer, ByVal idMaterialNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select top 1 * from Materiales.Materiales m join Materiales.MaterialesNave n 
            on m.mate_materialid=n.mn_materialid
            where mate_materialid=
            </cadena>
        consulta += "" & idMaterial & " "
        If idMaterialNave > 0 Then
            consulta += " and mn_idNave=" & idNave
        End If
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getPreciosMateriales(ByVal idMaterialNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@idMaterialNave"
        parametro.Value = idMaterialNave
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Materiales].[SP_ConsultaPreciosMateriales]", listaParametros)

        '    Dim consulta As String =
        '        <cadena>
        '         select  prma_descripcionProv 'Descripción Material Proveedor',
        'case when (p.prov_nombre is null or p.prov_nombre='-' or p.prov_nombre='NULL') 
        '         then  RTRIM(p.prov_razonsocial) else RTRIM(p.prov_razonsocial) end 'Proveedor',
        'prma_preciounitario 'Precio',
        '      m.mone_monedaid 'idMoneda',m.mone_nombre 'Moneda',mp.prma_activo 'Activo',prma_umproveedor 'umc',prma_equivalencia 'Factor de conversión',
        '      prma_umproduccion 'ump', prma_claveProveedor 'Clave',mp.prma_fechaderegistro 'Registro',u.user_username 'Usuario Alta',
        '         mp.prma_fechamodificacion 'Fecha Modificacion', mp.prma_usuariomodificoid 'Usuario Modifico', mp.prma_usuariomodifico 'Modifico',
        '      prma_provedorid 'idProveedor',1 'Existe',mp.prma_preciosmaterialid 'precioMaterialId',mp.prma_dageproveedorid'dageproveedorid',
        'isnull(mp.prma_idumproveedor,0) 'idumProv',isnull(mp.prma_idumproduccion,0) 'idumProd',
        '         prma_diasDeEntrega 'Días Entrega',n.nave_nombre 'Nave Alta',isnull(mp.prma_navedesarrollaid,0) 'IdNaveAlta' , n.nave_naveid
        '      from Materiales.MaterialesPrecio mp JOIN
        '      Proveedor.Proveedor p on p.prov_proveedorid=mp.prma_provedorid
        '      join Framework.Moneda as m on m.mone_monedaid=prma_monedaid
        '      join Framework.Usuarios as u on u.user_usuarioid=mp.prma_usuariocreoid
        'left join Framework.Naves as n on n.nave_naveid=mp.prma_idnave
        '        </cadena>
        '    consulta += "where mp.prma_idMaterialNave= " & idMaterialNave & "  order by prma_preciosmaterialid DESC  "
        '    Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getClasificaciones(ByVal CATEGORIA As Integer, ByVal directo As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select * from Materiales.Clasificaciones AS C "
        consulta += " JOIN Materiales.CategoriaClasificacion AS CC ON CC.cacl_idclasificacion=C.clas_idclasificacion"
        consulta += " where CC.cacl_idcategoria=" + CATEGORIA.ToString + " and C.clas_directo= " + directo.ToString + " and C.clas_status=1 order by C.clas_nombreclas asc"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getCategorias(ByVal tipo As Integer, NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@tipo", tipo)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@NaveID", NaveID)
        listaparametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Materiales].[SP_ObtieneMateriales_AltaMaterial]", listaparametros)

        'Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '    <cadena>
        '    select DISTINCT cate_idCategoria 'idCat',cate_nombre 'nombre' 
        '    from Materiales.Categorias
        '    where Categorias.cate_status=1  order by cate_nombre asc
        '    </cadena>
        ''consulta += " and clas_directo='" & tipo & "' order by cate_nombre asc"
        'Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getHormas() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select horma_hormaid 'ID', horma_descripcion 'NOMBRE' from Programacion.Hormas where horma_activo=1
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getTemporadas() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select temp_temporadaid 'ID', temp_nombre 'NOMBRE' from Programacion.Temporadas where temp_año=year(getdate())
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getForro() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select forr_forroid 'ID', forr_descripcion 'NOMBRE' from Programacion.Forros where forr_activo=1
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getSuelas() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select suel_suelaid 'ID', suel_descripcion 'NOMBRE' from Programacion.Suelas where suel_activo=1
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getLineas() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select linea_lineaid 'ID', linea_descripcion 'NOMBRE' from Programacion.Lineas where linea_activo=1
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getColores() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select pc.color_colorid 'ID', pc.color_descripcion 'Nombre' 
                from Materiales.ClasificacionColores as mc JOIN Programacion.Colores as pc 
                on mc.clco_idcolor=pc.color_colorid where clco_idclasificacion=1
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getPieles() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
           select piel_pielid 'ID', piel_descripcion 'NOMBRE' from Programacion.Pieles where piel_activo=1
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getFamilias() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select fami_familiaid 'ID', fami_descripcion 'Nombre' from Programacion.Familias where fami_activo=1
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getProveedores(ByVal idNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>          
            --SELECT
	        --DatosGenerales.dage_proveedorid,
	        --dage_nombrecomercial
            --FROM Proveedor.DatosGenerales
			--inner join Proveedor.ProveedorNave 
			--on DatosGenerales.dage_proveedorid=ProveedorNave.dage_proveedorid
            --WHERE dage_activo = 'SI' and prna_activo='SI' AND nave_naveid=

            select 
                p.prov_proveedorid 'IDP',
               case when (p.prov_nombre is null or p.prov_razonsocial='-' or p.prov_razonsocial='NULL') 
                then RTRIM(p.prov_razonsocial) else  RTRIM(p.prov_razonsocial) end 'Proveedor', 
                --then p.prov_nombregenerico else  RTRIM(p.prov_razonsocial)+' - '+RTRIM(p.prov_nombregenerico) end 'Proveedor',  
                dg.dage_proveedorid 'IDDG'
                from Proveedor.Proveedor as p
                inner join Proveedor.DatosGenerales as dg on dg.dage_proveedorid=p.dage_proveedorid
                inner join Proveedor.ProveedorNave as pn on pn.dage_proveedorid=p.dage_proveedorid
                where pn.nave_naveid=
            </cadena>
        consulta += idNave.ToString
        consulta += " and p.prov_activo=1 and pn.prna_activo='SI'"
        consulta += " order by p.prov_razonsocial --case when (p.prov_nombre is null or p.prov_nombre='-' or p.prov_nombre='NULL') then p.prov_nombregenerico else p.prov_nombre end"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getProveedoresNoEnPrecios(ByVal idNave As Integer, ByVal lista As List(Of Integer)) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>          
            --SELECT
	        --DatosGenerales.dage_proveedorid,
	        --dage_nombrecomercial
            --FROM Proveedor.DatosGenerales
			--inner join Proveedor.ProveedorNave 
			--on DatosGenerales.dage_proveedorid=ProveedorNave.dage_proveedorid
            --WHERE dage_activo = 'SI' and prna_activo='SI' AND nave_naveid=

            select 
                p.prov_proveedorid 'IDP',
                case when (p.prov_nombre is null or p.prov_razonsocial='-' or p.prov_razonsocial='NULL') 
                then RTRIM(p.prov_razonsocial) else  RTRIM(p.prov_razonsocial) end 'Proveedor', 
                dg.dage_proveedorid 'IDDG'
                from Proveedor.Proveedor as p
                inner join Proveedor.DatosGenerales as dg on dg.dage_proveedorid=p.dage_proveedorid
                inner join Proveedor.ProveedorNave as pn on pn.dage_proveedorid=p.dage_proveedorid
                where pn.nave_naveid=
            </cadena>
        consulta += " " & idNave & " and dg.dage_proveedorid not in ("
        For Each id As Integer In lista
            consulta += " " & id & ","
        Next
        consulta += "0) order by p.prov_razonsocial --case when (p.prov_nombre is null or p.prov_nombre='-' or p.prov_nombre='NULL') then p.prov_nombregenerico else RTRIM(p.prov_nombregenerico)+' - '+p.prov_nombre end asc"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getProveedrorDatosGeneralesID(ByVal proveedorid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>          
                select 
                    dg.dage_proveedorid,dg.dage_nombrecomercial
                    from Proveedor.DatosGenerales as dg
                    inner join Proveedor.Proveedor as p on dg.dage_proveedorid=p.dage_proveedorid
                    where p.prov_proveedorid= <%= proveedorid %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getMoneda() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>          
            select mone_monedaid 'ID', mone_nombre 'MONEDA' from Framework.Moneda where mone_monedaid
            </cadena>
        consulta += " <> 5"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function insertPrecioMaterial(ByVal precioMaterial As PrecioMaterial, ByVal accion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@accion"
        parametro.Value = accion
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        parametro.ParameterName = "@prma_usuariocreoid"
        parametro.Value = precioMaterial.usuarioCreoid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_idnave"
        parametro.Value = precioMaterial.naveId
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        parametro.ParameterName = "@prma_idMaterialNave"
        parametro.Value = precioMaterial.idMaterialNave
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        parametro.ParameterName = "@prma_diasDeEntrega"
        parametro.Value = precioMaterial.tiempodeEntrega
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_provedorid"
        parametro.Value = precioMaterial.proveedorId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@dage_provedorid"
        parametro.Value = precioMaterial.proveedordgId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_umproveedor"
        parametro.Value = precioMaterial.umc
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_umproduccion"
        parametro.Value = precioMaterial.ump
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_equivalencia"
        parametro.Value = precioMaterial.equivalenciaUMP
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_preciounitario"
        parametro.Value = precioMaterial.precioUnitario
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_descripcionProv"
        parametro.Value = precioMaterial.descripcionProv
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_claveProveedor"
        parametro.Value = precioMaterial.claveProveedor
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_moneda"
        parametro.Value = precioMaterial.monedaId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_idumproveedor"
        parametro.Value = precioMaterial.idumc
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_idumproduccion"
        parametro.Value = precioMaterial.idump
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_idNaveDesarrolla"
        parametro.Value = precioMaterial.navedesarrollaid
        listaparametros.Add(parametro)
        'Agregado
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_usuariomodificoid"
        parametro.Value = precioMaterial.usuarioModificoid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_usuariomodifico"
        parametro.Value = precioMaterial.usuarioModifico
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_fechaderegistro"
        parametro.Value = precioMaterial.fechaRegistro
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@prma_origenpreciomaterial"
        parametro.Value = precioMaterial.origenpreciomaterial
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Materiales].[insertPrecioMaterial]", listaparametros)
    End Function

    Public Function insertMaterial(ByVal material As Material) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim precioMaterial As New PrecioMaterial
        Dim listaparametros As New List(Of SqlParameter)
        Dim datos As New DataTable
        Dim idSicyMaterial As Integer = 0
        'datos = insertUpdateMaterial(material, precioMaterial, "1")
        'If datos.Rows.Count > 0 Then
        '    idSicyMaterial = Convert.ToInt32(datos.Rows(0).Item(0).ToString)
        'End If
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idSicy"
        parametro.Value = idSicyMaterial
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@sku"
        parametro.Value = material.sku
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = material.activo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@descripcion"
        parametro.Value = material.descripcion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@nombreMaterial"
        parametro.Value = material.materiaNombre
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@clasificacion"
        parametro.Value = material.clasificacion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@categoria"
        parametro.Value = material.categoria
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@tipodematerial"
        parametro.Value = material.tipoMaterial
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@critico"
        parametro.Value = material.critico
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idMaterialremplazo"
        parametro.Value = material.idMaterialRemplazo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idTam"
        parametro.Value = material.idTamaño
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idColor"
        parametro.Value = material.idColor
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@estatus"
        parametro.Value = material.materialEstatus
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@navedesarrollaid"
        parametro.Value = material.idNaveDesarrolla
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@exclusivo"
        parametro.Value = material.exclusivo
        listaparametros.Add(parametro)

        datos = objPersistencia.EjecutarConsultaSP("[Materiales].[insertMaterial]", listaparametros)
        datos.Columns.Add("idSicy", Type.GetType("System.String"))
        For Each r As DataRow In datos.Rows
            r("idSicy") = "" & idSicyMaterial
        Next

        Return datos
    End Function

    Public Function updateMaterial(ByVal material As Material)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idMaterial"
        parametro.Value = material.materialId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@sku"
        parametro.Value = material.sku
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@nombre"
        parametro.Value = material.materiaNombre
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = material.activo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@descripcion"
        parametro.Value = material.descripcion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@categoria"
        parametro.Value = material.categoria
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@clasificacion"
        parametro.Value = material.clasificacion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@tipodematerial"
        parametro.Value = material.tipoMaterial
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idTam"
        parametro.Value = material.idTamaño
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idColor"
        parametro.Value = material.idColor
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@estatus"
        parametro.Value = material.materialEstatus
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Exclusivo"
        parametro.Value = material.exclusivo
        listaparametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[Materiales].[updateMaterial]", listaparametros)

    End Function

    Public Function updateMaterial2(ByVal material As Material, ByVal idmaterialnave As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            update Materiales.MaterialesNave set mn_activo=
            </cadena>
        consulta += material.activo + " where mn_materialNaveid="
        consulta += idmaterialnave.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function updatePrecioMaterial(ByVal precioMaterial As PrecioMaterial)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idPrecioMaterial"
        parametro.Value = precioMaterial.preciosmaterialid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_clavenave"
        parametro.Value = precioMaterial.naveId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_provedorid"
        parametro.Value = precioMaterial.proveedorId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_descripcion"
        parametro.Value = precioMaterial.descripcion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_tiempodeentrega"
        parametro.Value = precioMaterial.tiempodeEntrega
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_preciounitario"
        parametro.Value = precioMaterial.precioUnitario
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_clasificacion"
        parametro.Value = precioMaterial.clasificacion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_ump"
        parametro.Value = precioMaterial.ump
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@prma_equivalenciaump"
        parametro.Value = precioMaterial.equivalenciaUMP
        listaparametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[Materiales].[updatePrecioMaterial]", listaparametros)
    End Function

    Public Function removePrecioMaterial(ByVal precioMaterial As PrecioMaterial)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idPrecioMaterial"
        parametro.Value = precioMaterial.preciosmaterialid
        listaparametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[Materiales].[removePrecioMaterial]", listaparametros)
    End Function

    Public Function verificarSKU(ByVal sku As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select * from Materiales.Materiales where mate_sku=
            </cadena>
        consulta += " '" & sku & "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ExisteNaveAsignadaMaterial(ByVal MAterialID As Integer, ByVal NaveId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                    SELECT mn_materialNaveid
                    from Materiales.MaterialesNave                                      
            </cadena>
        consulta += " where mn_materialid='" + MAterialID.ToString + "' "
        consulta += "  and mn_idNave ='" + NaveId.ToString + "' "

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getIdUnidadDeMedidaPorDescripcion(ByVal des As String) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
            select isnull(unme_idsicy,0)'idSicy' from Materiales.UnidadDeMedida where unme_descripcion like 
            </cadena>
        consulta += " '" & des & "'"
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return Convert.ToInt32(datos.Rows(0).Item(0).ToString)
        End If
        Return 0
    End Function

    Public Function getMateriales(ByVal idNave As Integer, ByVal activo As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        '-----------------------------------Inicio Consulta usada a partir del 03/05/2019-----------------------------------
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = idNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = activo
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Materiales].[ObtenerMateriales]", listaparametros)
        '-----------------------------------Fin Consulta usada a partir del 03/05/2019-----------------------------------

        '-----------------------------------Inicio Consulta usada hasta 03/05/2019-----------------------------------
        '     Dim consulta As String =
        '          <cadena>

        '           select	0 ' ',m.mate_materialid 'ID',mn.mn_materialNaveid 'idMaterialNave',m.mate_sku 'SKU',cl.clas_nombreclas 'Clasificación',
        'm.mate_descripcion 'Material',
        '         case when (p.prov_nombre is null or p.prov_razonsocial='-' or p.prov_razonsocial='NULL') 
        'then RTRIM(p.prov_razonsocial) else  RTRIM(p.prov_razonsocial) end 'Proveedor',
        '         --then RTRIM(p.prov_razonsocial)+ ' - '+ RTRIM(p.prov_nombregenerico) else  RTRIM(p.prov_razonsocial)+' - '+RTRIM(p.prov_nombregenerico) end 'Proveedor',
        '         mp.prma_umproveedor 'UM prov', 
        '         'Precio' = CASE  when mp.prma_preciounitario is null then '0.00' else mp.prma_preciounitario end,
        'mp.prma_umproduccion 'UM-Prod',mp.prma_equivalencia 'Rendimiento','Estatus' = case when M.mate_autorizado ='D' then 'DESARROLLO' ELSE 'PRODUCCIÓN' end, 
        't.tima_tipoMaterial 'Tipo',co.mcol_color 'Color',
        'mn.mn_critico 'Crítico', c.cate_nombre 'Categoría',
        '         isnull(co.mcol_idcolor,0)'idColor',ta.tama_nombre'Tamaño',isnull(ta.tama_idTamano,0)'idTam',d.dept_departamento 'Departamento',
        '         isnull((select mate_descripcion from Materiales.Materiales where mate_materialid=mn_idMaterialRemplazo),'') 'Remplazo',
        'mn_idMaterialRemplazo 'IdRemplazo',m.mate_nombreMaterial 'Nombre',
        '         isnull(m.mate_idMaterialSicy,0) 'IdMatSicy', m.mate_idCategoria 'idc', m.mate_idClasificacion 'idclas', 
        '         nave.nave_nombre 'Nave Desarrolla',isnull(nave.nave_naveid,0) 'ID Nave Desarrolla', m.mate_exclusivo 'Exclusivo'  ,mn.mn_idNave 'Nave'          

        '         from Materiales.MaterialesNave mn left join
        '         Materiales.Materiales m on m.mate_materialid=mn.mn_materialid left join
        '         materiales.categorias c on m.mate_idCategoria=c.cate_idCategoria left JOIN
        '         Materiales.Clasificaciones cl on cl.clas_idclasificacion=m.mate_idClasificacion left JOIN
        '         Materiales.TiposMateriales t on t.tima_idTipo=m.mate_tipodematerial left JOIN
        '         Materiales.departamentos d on d.dept_iddepto=mn.mn_idDepartamento left JOIN
        '         Materiales.MaterialesColores co on m.mate_idColor=co.mcol_idcolor left JOIN
        '         Materiales.Tamano ta on ta.tama_idTamano=m.mate_idTamaño left join
        '         Materiales.MaterialesPrecio as mp on mp.prma_idMaterialNave = mn.mn_materialNaveid  and mp.prma_activo=1 left join 
        '         Proveedor.Proveedor as p on p.prov_proveedorid=mp.prma_provedorid
        'left join Framework.Naves as nave on nave.nave_naveid=mate_navedesarrollaid
        '         left join Proveedor.ProveedorNave pnv on pnv.dage_proveedorid = p.dage_proveedorid

        '         </cadena>
        'consulta += " and pnv.nave_naveid = " & idNave.ToString + " "
        'consulta += " where  mn.mn_activo=" & activo & " and mn.mn_idNave=" & idNave.ToString & " "
        'consulta += " order by m.mate_descripcion asc"

        'Return operaciones.EjecutaConsulta(consulta)
        '-----------------------------------Fin Consulta usada hasta 03/05/2019-----------------------------------

        '-----------------------------------Inicio Consulta obsoleta antes del 03/05/2019-----------------------------------

        '         <cadena>

        '           select	0 ' ',m.mate_materialid 'ID',mn.mn_materialNaveid 'idMaterialNave',m.mate_sku 'SKU',cl.clas_nombreclas 'Clasificación',
        'm.mate_descripcion 'Material',
        '         case when (p.prov_nombre is null or p.prov_razonsocial='-' or p.prov_razonsocial='NULL') 
        'then RTRIM(p.prov_razonsocial) else  RTRIM(p.prov_razonsocial) end 'Proveedor',
        '         --then RTRIM(p.prov_razonsocial)+ ' - '+ RTRIM(p.prov_nombregenerico) else  RTRIM(p.prov_razonsocial)+' - '+RTRIM(p.prov_nombregenerico) end 'Proveedor',
        '         mp.prma_umproveedor 'UM prov', 
        '         'Precio' = CASE  when mp.prma_preciounitario is null then '0.00' else mp.prma_preciounitario end,
        'mp.prma_umproduccion 'UM-Prod',mp.prma_equivalencia 'Rendimiento','Estatus' = case when M.mate_autorizado ='D' then 'DESARROLLO' ELSE 'PRODUCCIÓN' end, 
        't.tima_tipoMaterial 'Tipo',co.mcol_color 'Color',
        'mn.mn_critico 'Crítico', c.cate_nombre 'Categoría',
        '         isnull(co.mcol_idcolor,0)'idColor',ta.tama_nombre'Tamaño',isnull(ta.tama_idTamano,0)'idTam',d.dept_departamento 'Departamento',
        '         isnull((select mate_descripcion from Materiales.Materiales where mate_materialid=mn_idMaterialRemplazo),'') 'Remplazo',
        'mn_idMaterialRemplazo 'IdRemplazo',m.mate_nombreMaterial 'Nombre',
        '         isnull(m.mate_idMaterialSicy,0) 'IdMatSicy', m.mate_idCategoria 'idc', m.mate_idClasificacion 'idclas', 
        '         nave.nave_nombre 'Nave Desarrolla',isnull(nave.nave_naveid,0) 'ID Nave Desarrolla', m.mate_exclusivo 'Exclusivo'  ,mn.mn_idNave 'Nave'          

        '         from Materiales.MaterialesNave mn left join
        '         Materiales.Materiales m on m.mate_materialid=mn.mn_materialid left join
        '         materiales.categorias c on m.mate_idCategoria=c.cate_idCategoria left JOIN
        '         Materiales.Clasificaciones cl on cl.clas_idclasificacion=m.mate_idClasificacion left JOIN
        '         Materiales.TiposMateriales t on t.tima_idTipo=m.mate_tipodematerial left JOIN
        '         Materiales.departamentos d on d.dept_iddepto=mn.mn_idDepartamento left JOIN
        '         Materiales.MaterialesColores co on m.mate_idColor=co.mcol_idcolor left JOIN
        '         Materiales.Tamano ta on ta.tama_idTamano=m.mate_idTamaño left join
        '         Materiales.MaterialesPrecio as mp on mp.prma_idMaterialNave = mn.mn_materialNaveid  and mp.prma_activo=1 left join 
        '         Proveedor.Proveedor as p on p.prov_proveedorid=mp.prma_provedorid
        'left join Framework.Naves as nave on nave.nave_naveid=mate_navedesarrollaid
        '         </cadena>



        '         <cadena>
        '         select	m.mate_materialid 'ID',mn.mn_materialNaveid 'idMaterialNave',m.mate_sku 'SKU',m.mate_descripcion 'Material',
        'dg.dage_nombrecomercial 'Proveedor',mp.prma_umproveedor 'UM prov', 
        '         'Precio' = CASE  when mp.prma_preciounitario is null then '0.00' else mp.prma_preciounitario end,
        'mp.prma_umproduccion 'UM-Prod',mp.prma_equivalencia 'Rendimiento','Estatus' = case when M.mate_autorizado ='D' then 'DESARROLLO' ELSE 'PRODUCCIÓN' end, 
        'cl.clas_nombreclas 'Clasificación',t.tima_tipoMaterial 'Tipo',co.mcol_color 'Color',
        'mn.mn_critico 'Crítico', c.cate_nombre 'Categoría',
        '         isnull(co.mcol_idcolor,0)'idColor',ta.tama_nombre'Tamaño',isnull(ta.tama_idTamano,0)'idTam',d.dept_departamento 'Departamento',
        '         isnull((select mate_descripcion from Materiales.Materiales where mate_materialid=mn_idMaterialRemplazo),'') 'Remplazo',
        'mn_idMaterialRemplazo 'IdRemplazo',m.mate_nombreMaterial 'Nombre',
        '         isnull(m.mate_idMaterialSicy,0) 'IdMatSicy', m.mate_idCategoria 'idc', m.mate_idClasificacion 'idclas', 
        '         isnull(m.mate_navedesarrollaid,0) 'ID Nave Desarrolla' , m.mate_exclusivo 'Exclusivo'  ,mn.mn_idNave 'Nave'          
        '         from Materiales.MaterialesNave mn left join
        '         Materiales.Materiales m on m.mate_materialid=mn.mn_materialid left join
        '         materiales.categorias c on m.mate_idCategoria=c.cate_idCategoria left JOIN
        '         Materiales.Clasificaciones cl on cl.clas_idclasificacion=m.mate_idClasificacion left JOIN
        '         Materiales.TiposMateriales t on t.tima_idTipo=m.mate_tipodematerial left JOIN
        '         Materiales.departamentos d on d.dept_iddepto=mn.mn_idDepartamento left JOIN
        '         Materiales.MaterialesColores co on m.mate_idColor=co.mcol_idcolor left JOIN
        '         Materiales.Tamano ta on ta.tama_idTamano=m.mate_idTamaño left join
        '         Materiales.MaterialesPrecio as mp on mp.prma_idMaterialNave = mn.mn_materialNaveid  and mp.prma_activo=1 left join 
        '         Proveedor.DatosGenerales as dg on dg.dage_proveedorid=mp.prma_provedorid 
        '         </cadena>
        '<cadena>
        'select m.dage_materialid 'ID',mn.mn_materialNaveid 'idMaterialNave',m.dage_sku 'SKU',m.dage_descripcion 'Material',dg.dage_nombrecomercial 'Proveedor',
        ''Precio' = CASE  when mp.prma_preciounitario is null then '0.00' else mp.prma_preciounitario end,mn.mn_critico 'Crítico','Estatus' = case when M.autorizado ='D' then 'DESARROLLO' ELSE 'PRODUCCIÓN' end,mp.prma_umproveedor 'UM-Prov', mp.prma_umproduccion 'UM-Prod', mp.prma_equivalencia 'Rendimiento' ,c.nombre 'Categoría',cl.nombreClas 'Clasificación',
        't.tipoMaterial 'Tipo',co.color 'Color',isnull(co.idColor,0)'idColor',ta.nombre'Tamaño',isnull(ta.idTam,0)'idTam',d.Departamento 'Departamento',
        'isnull((select dage_descripcion from Materiales.Materiales where dage_materialid=mn_idMaterialRemplazo),'') 'Remplazo',mn_idMaterialRemplazo 'IdRemplazo',m.dage_nombreMaterial 'Nombre',
        'isnull(m.idMaterialSicy,0) 'IdMatSicy', m.dage_idCategoria 'idc', m.dage_idClasificacion 'idclas'              
        'from Materiales.MaterialesNave mn left join
        'Materiales.Materiales m on m.dage_materialid=mn.mn_materialid left join
        'materiales.categorias c on m.dage_idCategoria=c.idCat left JOIN
        'Materiales.Clasificaciones cl on cl.idClas=m.dage_idClasificacion left JOIN
        'Materiales.TiposMateriales t on t.idTipo=m.dage_tipodematerial left JOIN
        'Materiales.departamentos d on d.IdDepto=mn.mn_idDepartamento left JOIN
        'Materiales.MaterialesColores co on m.idColor=co.idColor left JOIN
        'Materiales.Tamano ta on ta.idTam=m.idTam left join
        'Materiales.MaterialesPrecio as mp on mp.prma_idMaterialNave = mn.mn_materialNaveid  and mp.prma_activo=1 left join 
        'Proveedor.DatosGenerales as dg on dg.dage_proveedorid=mp.prma_provedorid  
        'where
        '</cadena>
        '-----------------------------------Fin Consulta obsoleta antes del 03/05/2019-----------------------------------

    End Function

    Public Function ejecutarConsulta(ByVal consulta As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function asignarMaterialNave(ByVal material As Material) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idMaterial"
        parametro.Value = material.materialId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = material.idNave
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idDepartamento"
        parametro.Value = material.departamento
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@critico"
        parametro.Value = material.critico
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idMaterialremplazo"
        parametro.Value = material.idMaterialRemplazo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = material.activo
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Materiales].[AsignarMaterialNave]", listaparametros)
    End Function

    Public Function agregarCaracteristica(ByVal caracteristica As Caracteristicas) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@cara_descripcion"
        parametro.Value = caracteristica.cara_descripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cara_idmaterial"
        parametro.Value = caracteristica.cara_idmaterial
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cara_activo"
        parametro.Value = caracteristica.cara_activo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cara_usuariocreoid"
        parametro.Value = caracteristica.cara_usuariocreoid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cara_fechacreacion"
        parametro.Value = caracteristica.cara_fechacreacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cara_usuariomodificoid"
        parametro.Value = caracteristica.cara_usuariomodificoid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cara_fechamodificacion"
        parametro.Value = caracteristica.cara_fechamodificacion
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Materiales].[SP_InsertarCaracteristicas]", listaparametros)
    End Function

    Public Function updateCaracteristicasMaterial(ByVal caracteristica As Caracteristicas) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@cara_descripcion"
        parametro.Value = caracteristica.cara_descripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cara_idcaracteristica"
        parametro.Value = caracteristica.cara_idcaracteristica
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cara_activo"
        parametro.Value = caracteristica.cara_activo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cara_usuariomodificoid"
        parametro.Value = caracteristica.cara_usuariomodificoid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cara_fechamodificacion"
        parametro.Value = caracteristica.cara_fechamodificacion
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Materiales].[SP_ModificarCaracteristicas]", listaparametros)
    End Function

    Public Function updateMaterialNave(ByVal material As Material) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idMaterialNave"
        parametro.Value = material.materialIdNave
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idDepartamento"
        parametro.Value = material.departamento
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@critico"
        parametro.Value = material.critico
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idMaterialremplazo"
        parametro.Value = material.idMaterialRemplazo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = material.activo
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Materiales].[updateMaterialNave]", listaparametros)
    End Function

    Public Function verificarSKU(ByVal idprov As String, ByVal idMaterialNave As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select * from Materiales.MaterialesPrecio where 
            </cadena>
        consulta += " prma_provedorid=" & idprov & " and prma_idMaterialNave=" & idMaterialNave & ""
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function verificaridMaterial(ByVal idMaterial As Integer, ByVal idNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
           select mn_materialNaveid from Materiales.MaterialesNave where 
            </cadena>
        consulta += "mn_idNave=" & idNave & " and mn_materialid=" & idMaterial & ""
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function removerPreciosConMismoProveedorXnave(ByVal idProveedor As Integer, ByVal idMaterialNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            update Materiales.MaterialesPrecio set prma_activo=0 where 
            </cadena>
        consulta += " prma_idMaterialNave=" & idMaterialNave & " and prma_provedorid=" & idProveedor
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getNavesUtilizandoMaterial(ByVal idMaterial As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim naves As Integer = 0 'naves Utilizando el Material
        Dim consulta As String =
            <cadena>
            select  COUNT(mn_materialid) 'NavesUtilizandoMaterial' from Materiales.MaterialesNave inner join Framework.Naves on mn_idNave=nave_naveid
            inner join Materiales.Materiales on mate_materialid=mn_materialid where mn_activo=1 and mn_materialid=
            </cadena>
        consulta += " " & idMaterial
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            naves = Convert.ToInt32(datos.Rows(0).Item(0).ToString) 'Trae ell número de naves utilizando ese material
        End If
        Return naves
    End Function

    Public Function getIdDepSIcy(ByVal idDep As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
           select dept_idsicy from Materiales.departamentos where dept_iddepto= 
            </cadena>
        consulta += " " & idDep & " "
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return Convert.ToInt32(datos.Rows(0).Item(0).ToString)
        End If
        Return 0
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

    Public Function getIdProveedorSICY(ByVal idProv As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
            select prov_sicyid from Proveedor.Proveedor where dage_proveedorid=
            </cadena>
        consulta += " " & idProv & " "
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return Convert.ToInt32(datos.Rows(0).Item(0).ToString)
        End If
        Return 0
    End Function

    Public Function getIdUMSICY(ByVal idUM As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
            select unme_idSicy 'idSicy' from Materiales.UnidadDeMedida where unme_descripcion like
            </cadena>
        consulta += " '" & idUM & "' "
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return Convert.ToInt32(datos.Rows(0).Item(0).ToString)
        End If
        Return 0
    End Function

#Region "PROCEDIMIENTOS PARA REPLICAR EN EL SICY"
    Public Function getNaveIdAlmacenSIcy(ByVal idNaveSicy As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
           select idAlmacen from NavesAlmacen where idnave=
            </cadena>
        consulta += " " & idNaveSicy & " "
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return Convert.ToInt32(datos.Rows(0).Item(0).ToString)
        End If
        Return 0
    End Function

    Public Function spUpdatePrecioMaterialSICY(ByVal precioMaterial As PrecioMaterial)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdProveedor"
        parametro.Value = getIdProveedorSICY(precioMaterial.proveedorId)
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@IdMaterial"
        parametro.Value = precioMaterial.idMaterialSICY
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Precio"
        parametro.Value = precioMaterial.precioUnitario
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Descripcion2"
        parametro.Value = precioMaterial.descripcion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Entrega"
        parametro.Value = precioMaterial.tiempodeEntrega
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Descuento"
        parametro.Value = 0.0
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@CodigoProveedor"
        parametro.Value = precioMaterial.claveProveedor
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = getNaveIdAlmacenSIcy(getNaveSIcy(precioMaterial.naveId))
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@umc"
        parametro.Value = precioMaterial.umc
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@ump"
        parametro.Value = precioMaterial.ump
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@rendimiento"
        parametro.Value = precioMaterial.equivalenciaUMP
        listaparametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[dbo].[spUpdatePrecioMaterial3]", listaparametros)
    End Function

    Public Function ActualizaPrecioFichaTecSICY(ByVal precioMaterial As PrecioMaterial)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdProv"
        parametro.Value = getIdProveedorSICY(precioMaterial.proveedorId)
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@IdMat"
        parametro.Value = precioMaterial.idMaterialSICY
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@IdNav"
        parametro.Value = getNaveIdAlmacenSIcy(getNaveSIcy(precioMaterial.naveId))
        listaparametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[dbo].[sp_ActualizaPrecioFichaTec3]", listaparametros)
    End Function

    Public Function addPrecioMaterialSICY(ByVal precioMaterial As PrecioMaterial)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdProveedor"
        parametro.Value = getIdProveedorSICY(precioMaterial.proveedorId)
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@IdMaterial"
        parametro.Value = precioMaterial.idMaterialSICY
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Precio"
        parametro.Value = precioMaterial.precioUnitario
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Descripcion2"
        parametro.Value = precioMaterial.descripcion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Entrega"
        parametro.Value = precioMaterial.tiempodeEntrega
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Descuento"
        parametro.Value = 0.0
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@CodigoProveedor"
        parametro.Value = precioMaterial.claveProveedor
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = getNaveIdAlmacenSIcy(getNaveSIcy(precioMaterial.naveId))
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@umc"
        parametro.Value = precioMaterial.umc
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@ump"
        parametro.Value = precioMaterial.ump
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@rendimiento"
        parametro.Value = precioMaterial.equivalenciaUMP
        listaparametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[dbo].[spAddPrecioMaterial3]", listaparametros)
    End Function

    Public Function insertUpdateMaterial(ByVal material As Material, ByVal precioMaterial As PrecioMaterial, ByVal operacion As Char) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim idDeptmp As Integer = material.departamento
        If operacion = "1" Then
            precioMaterial.ump = 0
            precioMaterial.umc = 0
            idDeptmp = 0
        End If
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@usu"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Operacion"
        parametro.Value = operacion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idcatColor"
        parametro.Value = 0
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idTipMat"
        parametro.Value = material.tipoMaterial
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idUmp"
        parametro.Value = precioMaterial.idump = getIdUnidadDeMedidaPorDescripcion(precioMaterial.ump)
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idUmc"
        parametro.Value = precioMaterial.idumc = getIdUnidadDeMedidaPorDescripcion(precioMaterial.umc)
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@IdDepto"
        parametro.Value = idDeptmp
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Rendimiento"
        parametro.Value = precioMaterial.equivalenciaUMP
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Estatus"
        If material.activo = 1 Then
            parametro.Value = "Activo"
        Else
            parametro.Value = "Bloqueado"
        End If
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Costo"
        parametro.Value = 0
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Precio"
        parametro.Value = 0
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Minimo"
        parametro.Value = 0
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Maximo"
        parametro.Value = 0
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Calidad"
        parametro.Value = 0
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Descripcion1"
        parametro.Value = material.descripcion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@FechaReg"
        parametro.Value = material.fechaRegistro = Date.Today
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Talla"
        parametro.Value = 0
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@IdTalla"
        parametro.Value = " "
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@IdSubFam"
        parametro.Value = 0
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@IdFamilia"
        parametro.Value = material.clasificacion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@IdTipo"
        parametro.Value = material.descripcion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@IdMaterial" 'idMaterial para insertar o actualizar en sicy
        parametro.Value = material.materialId
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[dbo].[spMateriales3]", listaparametros)
    End Function

    Public Function updateMaterialSICYidDep(ByVal idDep As Integer, ByVal idMatSicy As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "update Materiales set Iddepto=" & getIdDepSIcy(idDep) & "where IdMaterial=" & idMatSicy & ""
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function updateMaterialSICYidUMsRendimiento(ByVal idUMP As String, ByVal idUMC As String, ByVal rendimiento As Double,
                                                       ByVal idMatSicy As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "update Materiales set IdUMC=" & getIdUMSICY(idUMC) & ", IdUMP=" & getIdUMSICY(idUMP) & ", Rendimiento=" & rendimiento & " where IdMaterial=" & idMatSicy & ""
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function insertMaterialAlmacenSICY(ByVal material As Material) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Idmaterial"
        parametro.Value = material.materialIdSICY
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Idalmacen"
        parametro.Value = getNaveIdAlmacenSIcy(getNaveSIcy(material.idNave)) 'Busca el id de la nave del sicy después busca el idAlmacen del sicy
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@Operacion"
        parametro.Value = 1
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usu"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@existencia"
        parametro.Value = 0
        listaparametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[dbo].[spMaterialesAlm3]", listaparametros)
    End Function

    ''' <summary>
    ''' Actualiza los campos de la tabla materiales del sicy y solo actualiza el nombre del material de materialesAlm
    ''' </summary>
    ''' <param name="material"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateMaterialesSiCY(ByVal material As Material) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Idmaterial"
        parametro.Value = material.materialIdSICY
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@descripcion"
        parametro.Value = material.descripcion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idClasificacion"
        parametro.Value = material.clasificacion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@tipoMaterial"
        parametro.Value = material.tipoMaterial
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioMod"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@estatus"
        parametro.Value = material.activo
        listaparametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[dbo].[spUpdateMaterialesAlm3]", listaparametros)
    End Function

    Public Sub actualizarEstatusMaterialAlmSIcy(ByVal material As Material)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY

        Dim consulta As String =
            <cadena>
           update MaterialesAlm set 
            </cadena>
        If material.activo = 1 Then
            consulta += " Status='A' where idmaterial=" & material.materialIdSICY & " and idalmacen=" & getNaveIdAlmacenSIcy(getNaveSIcy(material.idNave)) & " "
        Else
            consulta += " Status='B' where idmaterial=" & material.materialIdSICY & " and idalmacen=" & getNaveIdAlmacenSIcy(getNaveSIcy(material.idNave)) & " "
        End If
        operaciones.EjecutaConsulta(consulta)
    End Sub
#End Region

    Public Function idmaterial() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "SELECT TOP 1 mate_materialid FROM Materiales.Materiales ORDER BY mate_materialid DESC"
        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function getIdUnidadesDeMedidas() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
            select unme_idunidad 'idunidad',unme_descripcion 'descripcion' from Materiales.UnidadDeMedida where unme_status=1
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getNaveDesarrolla(ByVal idMaterialNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select pres_navedesarrollaid from Programacion.ProductoEstilo join Produccion.ConsumosDesarrollo 
                on code_productoestiloid=pres_productoestiloid join Materiales.MaterialesNave on code_materialid=mn_materialNaveid
            </cadena>
        consulta += " where code_materialid=" & idMaterialNave
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getNaveDesarrolla2(ByVal idMaterialNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
               SELECT m.mate_navedesarrollaid
                FROM Materiales.MaterialesNave mnv inner join Materiales.Materiales m
                on mnv.mn_materialid = m.mate_materialid
                where mnv.mn_materialNaveid = 
            </cadena>
        consulta += " " & idMaterialNave.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getidMaterialXidMaterialNave(ByVal materialNaveid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select mn_materialid from  Materiales.MaterialesNave 
            </cadena>
        consulta += " where mn_materialNaveid=" & materialNaveid
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getidMaterialNavesXidMaterial(ByVal idMaterial As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select DISTINCT(mn_idNave),mn_materialNaveid from Materiales.MaterialesNave 
            </cadena>
        consulta += " where mn_materialid=" & idMaterial
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getProveedorAsignado(ByVal proveedorid As Integer, ByVal naveid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select * from Proveedor.ProveedorNave 
            </cadena>
        consulta += " where dage_proveedorid=" & proveedorid & " and nave_naveid=" & naveid
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function insertProveedorNave(ByVal proveedorid As Integer, ByVal naveid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                insert INto Proveedor.ProveedorNave(prna_activo,dage_proveedorid,nave_naveid,prna_usuariocreoid,prna_usuariomodificoid,prna_fechacreacion,prna_fechamodificacion)
            </cadena>
        consulta += " values('SI'," & proveedorid & "," & naveid & "," & Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid & "," & Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid & ",getdate(),getdate())"
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

    Public Function SaberTipoNave(ByVal nave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select isnull(nave_desarrolla,0) from Framework.Naves where nave_naveid
            </cadena>
        consulta += "=" & nave
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function GetNaveDesarrollaMaterial(ByVal IdMaterial As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
               select mate_navedesarrollaid from Materiales.Materiales where mate_materialid
            </cadena>
        consulta += "=" & IdMaterial
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getNaveSAY(ByVal idNaveSay As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
           select nave_naveid,nave_nombre from Framework.Naves where nave_naveid=
            </cadena>
        consulta += " " & idNaveSay & " "
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function GetNaveDesarrollaPrecio(ByVal IdMaterial As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
               select mate_navedesarrollaid from Materiales.Materiales where mate_materialid
            </cadena>
        consulta += "=" & IdMaterial
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function GetIdUsuario(ByVal usuario As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                SELECT user_usuarioid FROM Framework.Usuarios 
            </cadena>
        consulta += "WHERE user_username ='" & usuario & "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getDatosPrecioXIdMaterialNAveDesarrollo(ByVal idMaterial As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
             select DISTINCT(prma_provedorid) 'prov',   prma_descripcionProv 'Descripción Material Proveedor',p.prov_razonsocial 'Proveedor',prma_preciounitario 'Precio',
             m.mone_monedaid 'idMoneda',m.mone_nombre 'Moneda',mp.prma_activo 'Activo',prma_umproveedor 'umc',prma_equivalencia 'Factor de conversión',
	         prma_umproduccion 'ump', prma_claveProveedor 'Clave',getdate() 'Registro',u.user_username 'Usuario Alta',
	         prma_provedorid 'idProveedor',0 'Existe',0 'precioMaterialId',mp.prma_dageproveedorid'dageproveedorid',
			 isnull(mp.prma_idumproveedor,0) 'idumProv',isnull(mp.prma_idumproduccion,0) 'idumProd',
             prma_diasDeEntrega 'Días Entrega',n.nave_nombre 'Nave Alta',isnull(mp.prma_navedesarrollaid,0) 'IdNaveAlta'
	         from Materiales.MaterialesPrecio mp JOIN
	         Proveedor.Proveedor p on p.prov_proveedorid=mp.prma_provedorid
	         join Framework.Moneda as m on m.mone_monedaid=prma_monedaid
	         join Framework.Usuarios as u on u.user_usuarioid=mp.prma_usuariocreoid
			 join Materiales.MaterialesNave mn on mn.mn_materialNaveid=mp.prma_idMaterialNave
			 join Materiales.Materiales ma on ma.mate_materialid=mn.mn_materialid 
			 left join Framework.Naves as n on n.nave_naveid=mp.prma_navedesarrollaid
			 where ma.mate_materialid=<%= idMaterial %> and mp.prma_activo=1
            </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        datos.Columns.RemoveAt(0)
        Return datos
    End Function

    Public Function getDatosPrecioXIdMaterialNAveDesarrollo2(ByVal idMaterial As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
             select DISTINCT(prma_provedorid) 'prov',   prma_descripcionProv 'Descripción Material Proveedor',p.prov_razonsocial 'Proveedor',prma_preciounitario 'Precio',
             m.mone_monedaid 'idMoneda',m.mone_nombre 'Moneda',mp.prma_activo 'Activo',prma_umproveedor 'umc',prma_equivalencia 'Factor de conversión',
	         prma_umproduccion 'ump', prma_claveProveedor 'Clave',getdate() 'Registro',u.user_username 'Usuario Alta',
	         prma_provedorid 'idProveedor',0 'Existe',0 'precioMaterialId',mp.prma_dageproveedorid'dageproveedorid',
			 isnull(mp.prma_idumproveedor,0) 'idumProv',isnull(mp.prma_idumproduccion,0) 'idumProd',
             prma_diasDeEntrega 'Días Entrega',n.nave_nombre 'Nave Alta',isnull(mp.prma_navedesarrollaid,0) 'IdNaveAlta', n.nave_naveid
	         from Materiales.MaterialesPrecio mp JOIN
	         Proveedor.Proveedor p on p.prov_proveedorid=mp.prma_provedorid
	         join Framework.Moneda as m on m.mone_monedaid=prma_monedaid
	         join Framework.Usuarios as u on u.user_usuarioid=mp.prma_usuariocreoid
			 join Materiales.MaterialesNave mn on mn.mn_materialNaveid=mp.prma_idMaterialNave
			 join Materiales.Materiales ma on ma.mate_materialid=mn.mn_materialid 
			 left join Framework.Naves as n on n.nave_naveid=mp.prma_idnave
			 where ma.mate_materialid=<%= idMaterial %> and mp.prma_activo=1
            </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        datos.Columns.RemoveAt(0)
        Return datos
    End Function

    Public Function ObtienePrecioMaterialNaveDesarrollo(ByVal idMaterial As Integer, ByVal idNave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idMaterial"
        parametro.Value = idMaterial
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = idNave
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Materiales].[SP_ObtienePrecioMaterialNaveDesarrollo]", listaparametros)
    End Function
    Public Function asignarProveedor(ByVal idNave As Integer, ByVal idProveedor As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = idNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idProveedor"
        parametro.Value = idProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Materiales].[AsignarProveedor]", listaparametros)
    End Function

    Public Function AutorizarMaterialProduccion(ByVal listaMateriales As IList(Of Integer)) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>        
            update Materiales.Materiales
            set mate_autorizado='P' where mate_materialid in (
        </cadena>
        For Each id In listaMateriales
            consulta += " " & id & ","
        Next
        consulta += " 0)"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function DesactivarPrecioMaterial(ByVal idpreciomaterial As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
        <cadena>        
                UPDATE  Materiales.MaterialesPrecio
                SET prma_activo=0 WHERE prma_preciosmaterialid=
        </cadena>
        consulta += idpreciomaterial.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function


    Public Sub DesactivarPrecioMaterialxId(ByVal idpreciomaterial As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "PrecioMaterialId"
        parametro.Value = idpreciomaterial
        listaparametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Materiales].[SP_DesactivarPrecioNave]", listaparametros)

    End Sub

    'Public Function DesactivarPrecioMaterialxMAterialID(ByVal MAterialId As Integer, ByVal ProveedorID As Integer, ByVal Precio As Double) As DataTable
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String =
    '    <cadena>        
    '            UPDATE  Materiales.MaterialesPrecio
    '            SET prma_activo=0 WHERE prma_preciosmaterialid=
    '    </cadena>
    '    consulta += idpreciomaterial.ToString
    '    Return operacion.EjecutaConsulta(consulta)
    'End Function

    Public Sub InsertarMaterialPrecio(ByVal NaveOrigenID As Integer, ByVal MaterialNaveID As Integer, ByVal NaveId As Integer, ByVal MaterialID As Integer, ByVal ProveedorID As Integer, ByVal Precio As Double, ByVal UsuarioID As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "MaterialNaveID"
        parametro.Value = MaterialNaveID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NaveID"
        parametro.Value = NaveId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MaterialID"
        parametro.Value = MaterialID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Proveedor"
        parametro.Value = ProveedorID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Precio"
        parametro.Value = Precio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "opcion"
        parametro.Value = 1
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NaveOrigenID"
        parametro.Value = NaveOrigenID
        listaparametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("[Materiales].[SP_InsertarMaterialPrecioNaveAsignada]", listaparametros)

    End Sub

    Public Function ConsultaSiEsNaveDesarrollo(ByVal idNave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@naveId"
        parametro.Value = idNave
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Materiales].[SP_ConsultaSiEsNaveDesarrollo]", listaparametros)
    End Function

    Public Function ActualizaMaterialCritico(ByVal material As Material)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaPatametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdMaterial"
        parametro.Value = material.materialId
        listaPatametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@critico"
        parametro.Value = material.critico
        listaPatametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Materiales].[SP_ActualizaMaterialCritico]", listaPatametros)
    End Function

    Public Function ActualizaNombreMaterial(ByVal material As Material)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@MaterialId", material.materialId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Nombre", material.materiaNombre)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Descripcion", material.descripcion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ColorID", material.idColor)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@TamañoID", material.idTamaño)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Materiales].[SP_ActualizaNombreDescripcionMaterial]", listaParametros)

    End Function

End Class
