Imports Persistencia
Imports Entidades
Imports System.Data.SqlClient


Public Class InventarioDA
    Function getTotalInventario(ByVal idMaterialNave As Integer, ByVal idProveedor As Integer, ByVal precio As Double, ByVal fechafinal As Date)
        Dim obj As New OperacionesProcedimientos
        Dim datos As New DataTable
        Dim total As Double = 0
        Dim consulta As String = <cadena>
            SELECT top(1)invn_inventariofinal,invn_inventarionaveid FROM Produccion.InventarioNave 
            where invn_materialnaveid=<%= idMaterialNave %> and invn_proveedorid=<%= idProveedor %> and invn_precio=<%= precio %>
                                 </cadena>
        consulta += " and invn_fechacreoid <= '" & fechafinal.ToString("dd/MM/yyyy") & " 23:59:00' order by invn_inventarionaveid desc"
        datos = obj.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            total = datos.Rows(0).Item(0)
        End If
        Return total
    End Function

    Function getCierres(ByVal idNave As Integer, ByVal fecha As Date)
        Dim obj As New OperacionesProcedimientos
        Dim consulta As String = <cadena>
            select m.mate_descripcion,p.prov_razonsocial,i.innc_entradas,i.innc_salidas,
            i.innc_precio,i.innc_total,i.innc_fechacierre
            from Produccion.InventarioNaveCierres i
            inner join Materiales.MaterialesNave mn 
            on mn.mn_materialNaveid=i.innc_materialnaveid
            inner join Materiales.Materiales m on m.mate_materialid=mn.mn_materialid
            inner join Proveedor.Proveedor p on p.prov_proveedorid=i.innc_proveedorid
            where i.innc_fechacierre BETWEEN '<%= fecha.ToString("dd/MM/yyyy") %> 00:00:00' and '<%= fecha.ToString("dd/MM/yyyy") %> 23:59:00'
            and i.innc_naveid=<%= idNave %>
            order by i.innc_fechacierre asc
            </cadena>
        Return obj.EjecutaConsulta(consulta)
    End Function

    Public Function getNoSemana(ByVal fecha As Date) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim no As Integer = 0
        Dim consulta As String =
           CStr(<cadena>
                    select numsem from catSemanas where '<%= fecha.ToString("dd/MM/yyyy") %> 00:00:00.000' BETWEEN FecIni and FecFin
                </cadena>)
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            no = CInt(datos.Rows(0).Item(0).ToString)
        End If
        Return no
    End Function
    Function getURLNave(ByVal idNave As Integer) As String
        Dim obj As New OperacionesProcedimientos
        Dim url As String = ""
        Dim datos As New DataTable
        Dim consulta As String = <cadena>
                                     select nave_logotipourl from Framework.Naves where nave_naveid=<%= idNave %>
                                 </cadena>
        datos = obj.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            url = datos.Rows(0).Item(0).ToString
        End If
        Return url
    End Function

    Function getInventarioXProveedor(ByVal idNave As Integer, ByVal fecha As Date) As DataTable
        Dim obj As New OperacionesProcedimientos
        Dim tmp As String = ""
        Dim consulta As String = <cadena>
            select m.mate_descripcion 'material',um.unme_descripcion 'umc',
            isnull((select top(1)i2.invn_inventariofinal from Produccion.InventarioNave i2 
            where i2.invn_materialnaveid=i.invn_materialnaveid AND 
            i2.invn_proveedorid=i.invn_proveedorid and i2.invn_precio=i.invn_precio 
        </cadena>
        consulta += " and i2.invn_fechacreoid <= '" & fecha.ToString("dd/MM/yyyy") & " 23:59:00'"
        tmp = <cadena>
            and i.invn_umc=i2.invn_umc order by i2.invn_inventarionaveid desc),0.00) as cantidad, i.invn_precio 'precio',0.0 'total',i.invn_proveedorid 'idProveedor',
            p.prov_razonsocial 'proveedor' from Produccion.InventarioNave i
            inner join Materiales.MaterialesNave mn on mn.mn_materialNaveid=invn_materialnaveid
            inner join Materiales.Materiales m on m.mate_materialid=mn.mn_materialid
            inner join Proveedor.Proveedor p on p.prov_proveedorid=i.invn_proveedorid
            inner join Materiales.UnidadDeMedida um on um.unme_idunidad=i.invn_umc
            where i.invn_naveid = <%= idNave %> AND m.mate_autorizado='P'
            GROUP by i.invn_materialnaveid,i.invn_proveedorid,i.invn_precio,
            mate_descripcion,invn_umc,i.invn_proveedorid,p.prov_razonsocial,um.unme_descripcion 
            order by prov_razonsocial desc
        </cadena>
        consulta += tmp
        Return obj.EjecutaConsulta(consulta)
    End Function
    'Function getClasificaciones() As DataTable
    '    Dim obj As New OperacionesProcedimientos
    '    Dim consulta As String = <cadena>
    '                                 select clas_idclasificacion 'id',clas_nombreclas 'clasificacion' from Materiales.Clasificaciones where clas_controlinventario=1
    '                             </cadena>
    '    Return obj.EjecutaConsulta(consulta)
    'End Function
    Function getMovimientos(ByVal movsGerente As Boolean, ByVal movsUsuario As Boolean) As DataTable
        Dim obj As New OperacionesProcedimientos
        Dim consulta As String = <cadena>
        select movi_movimientoinventarioid,movi_movimiento,movi_tipomovimiento,movi_realizamovimiento
        from Produccion.MovimientosInventarios where movi_activo=1
        </cadena>
        If movsGerente = True And movsUsuario = False Then
            consulta += " and movi_realizamovimiento='GERENTE'"
        End If
        If movsGerente = False And movsUsuario = True Then
            consulta += " and movi_realizamovimiento='USUARIO'"
        End If
        If movsGerente = True And movsUsuario = True Then
            consulta += " and (movi_realizamovimiento='USUARIO' or movi_realizamovimiento='GERENTE')"
        End If
        If movsGerente = False And movsUsuario = False Then
            consulta += " and movi_realizamovimiento=''"
        End If
        Return obj.EjecutaConsulta(consulta)
    End Function
    Function getDatosInventario(ByVal idNave As Integer, ByVal idClasificacion As String, ByVal fecini As Date) As DataTable
        Dim objPersistencia As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", idNave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Clasificacion", idClasificacion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaInicio", fecini)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_Inventario_ObtieneDatosInventario]", listaParametros)

        'Dim obj As New OperacionesProcedimientos
        'Dim cadena As String = " "
        'Dim consulta As String = <cadena>
        '    select DISTINCT invn_naveid,nave_nombre,iv.invn_proveedorid,iv.invn_materialnaveid,
        '    m.mate_materialid,p.prov_razonsocial 'PROVEEDOR',iv.invn_ump,iv.invn_umc,iv.invn_factorconversion,
        '    m.mate_descripcion 'MATERIAL',un.unme_descripcion 'UMC',iv.invn_precio 'PRECIO',
        '    isnull((SELECT top(1)i2.invn_inventariofinal 
        '    FROM Produccion.InventarioNave i2 
        '    where i2.invn_materialnaveid=iv.invn_materialnaveid and i2.invn_proveedorid=iv.invn_proveedorid 
        '    and i2.invn_precio=iv.invn_precio
        '    </cadena>
        'consulta += "  and  i2.invn_fechacreoid <= '" & fecini.ToString("dd/MM/yyyy") & " 23:59:00' order by i2.invn_inventarionaveid desc),0.0) 'INVENTARIO', 0.00 'SUBTOTAL',  "
        'cadena = <cadena>   
        '    isnull((SELECT top(1)i2.invn_inventariofinal 
        '    FROM Produccion.InventarioNave i2 
        '    where i2.invn_materialnaveid=iv.invn_materialnaveid and i2.invn_proveedorid=iv.invn_proveedorid 
        '    and i2.invn_precio=iv.invn_precio
        '    order by i2.invn_inventarionaveid desc),0.0) 'INVENTARIOFINAL', iv.invn_monedaid 'IdMoneda'  
        '    from Materiales.MaterialesNave mn inner join Materiales.Materiales m on m.mate_materialid=mn.mn_materialid 
        '    inner join Produccion.InventarioNave iv on iv.invn_materialnaveid=mn.mn_materialNaveid inner join Proveedor.Proveedor p
        '    on iv.invn_proveedorid=p.prov_proveedorid
        '    inner join Materiales.UnidadDeMedida un on un.unme_idunidad=invn_umc
        '    inner join Framework.Naves n on n.nave_naveid=iv.invn_naveid
        '    where mn.mn_idNave = <%= idNave %>
        '         </cadena>
        'consulta += cadena
        'If idClasificacion > 0 Then
        '    consulta += " and m.mate_idClasificacion=" & idClasificacion & " "
        'End If
        'consulta += " GROUP BY iv.invn_precio,invn_materialnaveid, prov_proveedorid,prov_razonsocial,mate_descripcion,unme_descripcion,invn_proveedorid, iv.invn_naveid,nave_nombre,invn_factorconversion,invn_ump,invn_umc,mate_materialid, iv.invn_monedaid"
        'Return obj.EjecutaConsulta(consulta)
    End Function
    Function getEntradasSalidas(ByVal idMaterialNave As Integer,
                               ByVal idProveedor As Integer,
                               ByVal precio As Double, ByVal fecini As String, ByVal fecfin As String) As DataTable
        Dim obj As New OperacionesProcedimientos
        Dim consulta As String = <cadena>
            SELECT isnull((select sum(invn_cantidad) from Produccion.InventarioNave inner join Produccion.MovimientosInventarios
            on invn_movimientoinventarioid=movi_movimientoinventarioid 
            where invn_materialnaveid=<%= idMaterialNave %> and invn_proveedorid=<%= idProveedor %> and invn_precio=<%= precio %>
            and movi_tipomovimiento LIKE 'ENTRADA' and invn_fechacreoid BETWEEN '<%= fecini %> 00:00:00' and '<%= fecfin %>  23:59:00'),0) 'ENTRADA',
            isnull((select sum(invn_cantidad) from Produccion.InventarioNave inner join Produccion.MovimientosInventarios
            on invn_movimientoinventarioid=movi_movimientoinventarioid 
            where invn_materialnaveid=<%= idMaterialNave %> and invn_proveedorid=<%= idProveedor %> and invn_precio=<%= precio %>
            and movi_tipomovimiento LIKE 'SALIDA' and invn_fechacreoid BETWEEN '<%= fecini %> 00:00:00' and '<%= fecfin %>  23:59:00'),0) 'SALIDA'
                                 </cadena>
        Return obj.EjecutaConsulta(consulta)
    End Function
    Function getMovimientosMaterial(ByVal idProveedor As Integer, ByVal idMaterialNave As Integer, ByVal precio As Double, ByVal fecini As Date, ByVal fecfin As Date)
        Dim obj As New OperacionesProcedimientos
        Dim consulta As String = <cadena>
            select invn_fechacreoid 'FECHA',movi_movimiento 'MOVIMIENTO',
            unme_descripcion 'UMC',invn_inventarioinicial 'INVENTARIO INICIAL',
            (case movi_tipomovimiento when 'ENTRADA' then invn_cantidad else 0.00 end) 'ENTRADAS',
            (case movi_tipomovimiento when 'SALIDA' then invn_cantidad else 0.00 end) 'SALIDAS' from Produccion.InventarioNave
            inner join Produccion.MovimientosInventarios
            on invn_movimientoinventarioid=movi_movimientoinventarioid
            inner join Materiales.UnidadDeMedida 
            on invn_umc=unme_idunidad
            where invn_materialnaveid=<%= idMaterialNave %>
            and invn_proveedorid=<%= idProveedor %> and invn_precio=<%= precio %>
            and invn_fechacreoid BETWEEN '<%= fecini.ToString("dd/MM/yyyy") %> 00:00:00' 
            and '<%= fecfin.ToString("dd/MM/yyyy") %> 23:59:00'
            order by invn_inventarionaveid asc
                               </cadena>
        Return obj.EjecutaConsulta(consulta)
    End Function

    Public Function insertarMovimientoInventario(ByVal p As InventarioNave) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@invn_naveid"
        parametro.Value = p.naveid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@invn_materialnaveid"
        parametro.Value = p.materialnaveid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@invn_proveedorid"
        parametro.Value = p.proveedorid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@invn_ordencompraid"
        parametro.Value = p.ordencompraid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@invn_fechaprograma"
        parametro.Value = p.fechaprograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@invn_movimientoinventarioid"
        parametro.Value = p.movimientoinventarioid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@invn_inventarioinicial"
        parametro.Value = p.inventarioinicial
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@invn_cantidad"
        parametro.Value = p.cantidad
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@invn_umc"
        parametro.Value = p.umc
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@invn_precio"
        parametro.Value = p.precio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@invn_factorconversion"
        parametro.Value = p.factorconversion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@invn_inventariofinal"
        parametro.Value = p.inventariofinal
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@invn_ump"
        parametro.Value = p.ump
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@invn_observaciones"
        parametro.Value = p.invn_observaciones
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@invn_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@monedaid"
        parametro.Value = p.monedaid
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[insertarInventarioNave]", listaparametros)
    End Function


    Public Function ConsultaInventarioNaves() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_ConsultaInvetarioNaves_v2]", listaparametros)
    End Function

End Class
