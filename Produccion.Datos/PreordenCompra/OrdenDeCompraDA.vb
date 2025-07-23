Imports System.Data.SqlClient
Imports Entidades

Public Class OrdenDeCompraDA
    Public Function consultarOrdenesDeCompra(ByVal fechaPrograma As Date, ByVal idnave As Integer, ByVal estatusC As String, ByVal ban As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FechaPrograma", fechaPrograma.ToShortDateString())
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@NaveID", idnave)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@Estatus", estatusC)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@BanderaFecha", ban)
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_Consulta_OrdenesDeCompra]", listaparametros)

        ' Dim operaciones As New Persistencia.OperacionesProcedimientos

        '    Dim estatus As String = ""
        '    If estatusC = "TODAS" Or estatusC = "" Then
        '        estatus = "%%"
        '    Else
        '        estatus = estatusC
        '    End If
        '    Dim consulta As String =
        '        <cadena>
        '         select oc.ordc_tipodedocumento,m.mone_simbolo,0 'Seleccion','' 'NoOrden',oc.ordc_ordennumero 'ORDEN',oc.ordc_ordencompraid,p.prov_razonsocial 'Proveedor',oc.ordc_fechaprograma 'programa',
        'oc.ordc_fechaentrega 'Entrega',
        'oc.ordc_prioridad 'Tipo',oc.ordc_descuento 'DESCUENTO',
        'oc.ordc_observacion 'Observaciones',(select count(ocde_ordencompradetalleid) from Produccion.OrdenDeCompraDetalle where ocde_ordencompraid=oc.ordc_ordencompraid) materiales ,
        '         (SELECT sum(ocde_total) FROM Produccion.OrdenDeCompraDetalle where oc.ordc_ordencompraid=ocde_ordencompraid) 'TOTAL',
        '         (SELECT sum(ocde_cantidadrecibida*ocde_precio) FROM Produccion.OrdenDeCompraDetalle where oc.ordc_ordencompraid=ocde_ordencompraid) 'Subtotal Recibido',
        'm.mone_abreviatura Moneda,oc.ordc_tipodeorden 'TipoCaptura',oc.ordc_fechacreo 'fechaCreo',oc.ordc_estatusorden 'Estatus',oc.ordc_fechaautorizo 'autorizo',u.user_username 'Usuario',oc.ordc_fecharecepcion 'Recepción' from Produccion.OrdenDeCompra oc 
        '         inner join  Proveedor.Proveedor as p on p.prov_proveedorid=oc.ordc_proveedorid
        '         left join Framework.Usuarios u on u.user_usuarioid=oc.ordc_usuariorecepcion
        '         inner join Framework.Moneda m on m.mone_monedaid=oc.ordc_monedaid
        '         where oc.ordc_estatusorden like '<%= estatus %>' and oc.ordc_naveid=<%= idnave %>
        '        </cadena>
        '    If ban Then
        '        consulta += " and oc.ordc_fechaprograma BETWEEN '" & fechaPrograma.ToString("dd/MM/yyyy") & " 00:00:00' and '" & fechaPrograma.ToString("dd/MM/yyyy") & " 23:59:00'"
        '    Else
        '        consulta += " and oc.ordc_fechaprograma <= '" & fechaPrograma.ToString("dd/MM/yyyy") & " 23:59:00'"
        '    End If
        '    Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getEncabezadoDatosOrdenCompra(ByVal idOrden As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena> 
             select  oc.ordc_monedaid,oc.ordc_ordennumero 'NO. ORDEN',oc.ordc_ordencompraid,p.prov_razonsocial 'PROVEEDOR',oc.ordc_fechaprograma 'PROGRAMA',
			 oc.ordc_fechaentrega 'Entrega',
			 oc.ordc_prioridad 'TipoOrden',oc.ordc_tipodedocumento 'TipoCompra',oc.ordc_descuento 'DESCUENTO',
			 oc.ordc_observacion 'Observaciones',
			 oc.ordc_tipodeorden 'TipoCaptura',oc.ordc_fechacreo 'fechaCreo',oc.ordc_estatusorden 'Estatus',oc.ordc_cantidadpares 'Pares' from Produccion.OrdenDeCompra oc 
             inner join  Proveedor.Proveedor as p on p.prov_proveedorid=oc.ordc_proveedorid
             where oc.ordc_ordencompraid=<%= idOrden %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getMaterialesOrdenCompra(ByVal idOrden As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select mn.mn_idNave,mn.mn_materialNaveid,p.prov_proveedorid,ocd.ocde_factorconversion,0 modificado,ocd.ocde_tipodeorden,c.clas_idclasificacion 'IDc',ocd.ocde_ordencompradetalleid,m.mate_descripcion 'Material',isnull(mp.prma_umproduccion,'') 'UMP',um.unme_descripcion 'UMC',
            p.prov_razonsocial 'Proveedor',ocd.ocde_precio 'Precio',ocd.ocde_cantidadsolicitada 'Por Recibir',
            ocd.ocde_cantidadrecibida 'Total Recibido',ocd.ocde_cantidadrecibida 'TotalRecibidoOriginal',(ocde_cantidadrecibida*ocde_precio) as Total,(ocd.ocde_cantidadsolicitada*ocde_precio) as totalRecibir,ocd.ocde_estatusmaterial Estatus,ocd.ocde_estatusmaterial EstatusOriginal, mp.prma_monedaid, 0 as Modificada
             from Produccion.OrdenDeCompraDetalle ocd
            inner join Materiales.MaterialesNave mn on mn.mn_materialNaveid=ocd.ocde_materialnaveid
            inner join Materiales.Materiales m on m.mate_materialid=mn.mn_materialid
            inner join Materiales.UnidadDeMedida um on um.unme_idunidad=ocd.ocde_umc
            left  join Materiales.MaterialesPrecio mp on mp.prma_idMaterialNave=mn.mn_materialNaveid and mp.prma_provedorid=ocd.ocde_proveedorid and mp.prma_preciounitario=ocd.ocde_precio and mp.prma_activo=1
            inner join Proveedor.Proveedor p on p.prov_proveedorid=ocd.ocde_proveedorid
            inner join Materiales.Clasificaciones c on c.clas_idclasificacion=m.mate_idClasificacion
            where ocde_ordencompraid=<%= idOrden %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getEstatusMaterialesOC() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            SELECT 'INCOMPLETO' val ,'INCOMPLETO' estatus UNION
            SELECT 'COMPLETO' ,'COMPLETO'  UNION
            SELECT 'CANCELADO' ,'CANCELADO' 
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function ActualizarMaterialOrdenCompra(ByVal estatus As String, ByVal idocd As Integer, ByVal cantidadRecibida As Double) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            update Produccion.OrdenDeCompraDetalle set ocde_estatusmaterial='<%= estatus %>',
            ocde_cantidadrecibida=<%= cantidadRecibida %>,
            ocde_usuariomodificoid=<%= Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid %> ,ocde_fechamodifico=getdate() where ocde_ordencompradetalleid=<%= idocd %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function actualizarOrdenCompraEstatus(ByVal idOrdenCompra As Integer, ByVal estatus As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idOrdenCompra"
        parametro.Value = idOrdenCompra
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@status"
        parametro.Value = estatus
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[cambiarEstatusOrdenDeCompra]", listaparametros)
    End Function
    Public Function cancelarOrdenDeCompra(ByVal idOrdenCompra As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idOrdenCompra"
        parametro.Value = idOrdenCompra
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[cancelarOrdenDeCompra]", listaparametros)
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
        parametro.Value = 0
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

        '@monedaid

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[insertarInventarioNave]", listaparametros)
    End Function
    Public Function getMovimientoXTipoCapturaOrden(ByVal tipo As String) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        Dim datos As New DataTable
        If tipo = "MANUAL" Then
            consulta =
           <cadena>
            select movi_movimientoinventarioid,movi_movimiento from Produccion.MovimientosInventarios where movi_realizamovimiento='SISTEMA' and movi_movimiento like '%MANUAL%'
            </cadena>
        Else
            consulta =
                   <cadena>
            select movi_movimientoinventarioid,movi_movimiento from Produccion.MovimientosInventarios where movi_realizamovimiento='SISTEMA' and movi_movimiento like '%AUTOMÁTICA%'
            </cadena>
        End If
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return datos.Rows(0).Item(0)
        Else
            Return 0
        End If
    End Function
    Public Function getUnidadMedida(ByVal nombre As String) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
       <cadena>
            select unme_idunidad from Materiales.UnidadDeMedida WHERE unme_descripcion LIKE '<%= nombre %>'
       </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return datos.Rows(0).Item(0)
        Else
            Return 0
        End If
    End Function

    Public Function getCantidadInicial(ByVal i As InventarioNave) As Double
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
       <cadena>
            select top(1) invn_inventariofinal from Produccion.InventarioNave where invn_materialnaveid=<%= i.materialnaveid %> and invn_proveedorid=<%= i.proveedorid %>
            and invn_precio=<%= i.precio %> and invn_factorconversion=<%= i.factorconversion %>
           order by invn_inventarionaveid desc
       </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return datos.Rows(0).Item(0)
        Else
            Return 0
        End If
    End Function
    Public Function entraEnInventario(ByVal i As InventarioNave) As Boolean
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
       <cadena>
            select m.* from Materiales.Materiales m inner join Materiales.MaterialesNave mn on m.mate_materialid=mn.mn_materialid
            where mn.mn_materialNaveid=<%= i.materialnaveid %> and m.mate_idClasificacion 
            in (select clas_idclasificacion from Materiales.Clasificaciones where clas_controlinventario=1)
       </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function getDatosMoneda(ByVal idModena As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select mone_nombre,mone_abreviatura,mone_simbolo from Framework.Moneda where mone_monedaid=<%= idModena %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function
End Class
