Imports Persistencia
Imports System.Data.SqlClient

Public Class PreordenCompraDA

    Public Function MaterialesPorProveedor(ByVal nave As Integer, ByVal proveedor As Integer, ByVal idmoneda As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", nave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ProveedorID", proveedor)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@MonedaID", idmoneda)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_Consulta_MaterialesporProveedor]", listaParametros)

    End Function

    Public Function ConsultaPreOrdenesDeCompra(ByVal nave As Integer, ByVal fechaInicio As String, fechaFin As String, porSemana As Integer, añoInicio As Integer, SemanaInicio As Integer, ByVal estatus As Integer, ByVal CheckFecha As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", nave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaInicio", fechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", fechaFin)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@PorSemana", porSemana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", añoInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Semana", SemanaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Estatus", IIf(estatus = 0, " ", estatus))
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@CheckFecha", CheckFecha)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_Consulta_PreOrdenesDeCompra]", listaParametros)


    End Function

    Public Function ObtenerNombreClasificacion(ByVal id As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>           
            select clas_nombreclas from Materiales.Clasificaciones where clas_idclasificacion=<%= id %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultaProveedores(ByVal nave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", nave)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_Consulta_ProveedoresPorNave]", listaParametros)
    End Function

    Public Function ConsultaPrecio(ByVal materialNaveid As Integer, ByVal proveedorid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                    select prma_preciounitario from Materiales.MaterialesPrecio
                    where prma_idMaterialNave=<%= materialNaveid %> and prma_provedorid=<%= proveedorid %> and prma_activo=1
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultaImprimio(ByVal preordenid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                    select ordc_usuarioimprimioid, ordc_usuarioreimprimioid 
                        from Produccion.OrdenDeCompra where ordc_preordencompraid=<%= preordenid %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ActualizaImprimio(ByVal preordenid As Integer, ByVal usuario As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                    update Produccion.OrdenDeCompra
                        set ordc_usuarioimprimioid=<%= usuario %>, ordc_fechaimpresion= GETDATE()
                        where ordc_preordencompraid=<%= preordenid %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ActualizaReimprimio(ByVal preordenid As Integer, ByVal usuario As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                    update Produccion.OrdenDeCompra
                        set ordc_usuarioreimprimioid=<%= usuario %>, ordc_fechareimpresion=GETDATE(),
                        ordc_numerodereimpresion=(select ordc_numerodereimpresion +1 from Produccion.OrdenDeCompra  where ordc_preordencompraid=<%= preordenid %> )
                        where ordc_preordencompraid=<%= preordenid %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultaProveedoresMaterial(ByVal materialid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>           
               select DISTINCT
                prov.prov_proveedorid 'ID', prov.prov_razonsocial 'Proveedor'
                from Produccion.OrdenDeCompraDetalle as ocd
                inner join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=ocd.ocde_materialnaveid
                inner join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid
                inner join Materiales.MaterialesPrecio as mp on mp.prma_idMaterialNave=mn.mn_materialNaveid
                inner join Proveedor.Proveedor as prov on prov.prov_proveedorid=mp.prma_provedorid
                where ocd.ocde_materialnaveid=<%= materialid %> and mp.prma_activo=1
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultarOrdenCompletaDetalle(ByVal ordenid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>                   
                select  DISTINCT
                    ocde_ordencompraid 'Idoc',ocde_materialnaveid 'Idmn',oc.ordc_ordennumero'Oc',
                    ocde_cantidadsolicitada 'Cantidad',ocde_cantidadrecibida 'Recibida',ocde_umc 'Idumc',ocde_factorconversion 'Factor',
                    ocde_proveedorid 'Idp',convert(varchar,convert(money,ocde_precio),1) 'Precio unitario',convert(varchar,convert(money,ocde_total),1) 'Importe',
                    case when mp.prma_claveProveedor='' then ' ' else mp.prma_claveProveedor end 'Codigo',
                    m.mate_descripcion'Descripcion', case when m.mate_tipodematerial=1 then 'DIRECTO'else 'INDIRECTO' end 'Tipo',
                    ocde_estatusmaterial,um.unme_descripcion'UMC',oc.ordc_ordennumero 'Numero orden', mon.mone_abreviatura 'Abreviatura', mon.mone_simbolo 'Simbolo'
                    from Produccion.OrdenDeCompraDetalle  
                    inner join Materiales.UnidadDeMedida as um on um.unme_idunidad=ocde_umc
                    inner join Materiales.MaterialesNave as mn on mn.mn_materialNaveid=ocde_materialnaveid
                    inner join Materiales.Materiales as m on m.mate_materialid=mn.mn_materialid 
					inner join Materiales.MaterialesPrecio as mp on mp.prma_idMaterialNave=mn.mn_materialNaveid 
					left join Produccion.OrdenDeCompra as oc on oc.ordc_ordencompraid=ocde_ordencompraid 
                    left join Framework.Moneda AS mon ON mon.mone_monedaid=ocde_monedaid
                    where ocde_ordencompraid=<%= ordenid %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultarOrdenCompleta(ByVal ordenid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>                   
                select 
                    ordc_ordennumero 'Idoc',ordc_naveid 'Idn',ordc_anio 'año',ordc_preordencompraid 'Idpo',ordc_ordennumero'Oc',
                    Convert(char(10), ordc_fechaprograma, 103)'Fecha programa',ordc_cantidadpares'Pares',
					Convert(char(10), ordc_fechaentrega, 103)'Fecha entrega',
                    ordc_prioridad'Prioridad',ordc_componenteid'componente id',dg.dage_nombrecomercial'Cadena comercial',
                    ordc_proveedorid'Idp',ordc_descuento'Descuento',ordc_tipodeorden'Tipo Oorden',p.prov_razonsocial 'Proveedor',
                    ordc_observacion'Observacion',ordc_estatusorden'Estatus orden',
                    ordc_autorizada'autorizada',ordc_usuarioautorizoid'Usuario autorizo',ordc_fechaautorizo 'Fecha autorizo',
                    ordc_tipodedocumento 'documento', mon.mone_abreviatura, mon.mone_simbolo
                    from Produccion.OrdenDeCompra
                    inner join Proveedor.Proveedor as p on p.prov_proveedorid=ordc_proveedorid
                    inner join Proveedor.DatosGenerales as dg on dg.dage_proveedorid=p.dage_proveedorid 
                    left join Framework.Moneda AS mon ON mon.mone_monedaid=ordc_monedaid
                    where ordc_ordencompraid=<%= ordenid %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultarDatosNave(ByVal naveid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>                   
               select 
                    nave_nombre 'Nave',nave_calle'Calle',nave_colonia 'Colonia',nave_codigopostal 'CP' 
                    from Framework.Naves
                    where nave_naveid=<%= naveid %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function NombreDeUsuario(ByVal usuario As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>                   
               select user_nombrereal 'Nombre' from Framework.Usuarios where user_usuarioid=<%= usuario %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultaIdOrdenCompra(ByVal idpo As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>                   
               select ordc_ordencompraid from Produccion.OrdenDeCompra where ordc_preordencompraid=<%= idpo %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function CantidadPorRecibir(ByVal Materialnaveid As Integer, ByVal ProveedorId As Integer, ByVal NaveId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select 
                   pod.pred_cantidadsolicitada  
                    from Produccion.PreOrdenDeCompraDetalle  as pod
                    inner join Produccion.OrdenDeCompra as oc on oc.ordc_preordencompraid=pod.pred_preordencompraid
                    where pred_materialnaveid=<%= Materialnaveid %> AND oc.ordc_naveid=<%= NaveId %> AND (oc.ordc_estatusorden='POR RECIBIR' or oc.ordc_estatusorden='INCOMPLETA')
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ObtieneColumnasParaGrid(ByVal fechaProgramas As String, ByVal nave As Integer,
                                                    ByVal proveedor As Integer, ByVal Preordenid As Integer) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FechaPrograma", fechaProgramas)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveID", nave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ProveedorID", proveedor)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@PreOrdenID", Preordenid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_Consulta_DetallesPreOrdenCompra]", listaParametros)
    End Function

    Public Function AutorizarOrdenCompra(ByVal PreOrdenesCompra As String) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@PreOrdenesCompra", PreOrdenesCompra)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioID", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_Autoriza_OrdenDeCompra]", listaParametros)
    End Function

    Public Function CancelarOrdenCompra(ByVal PreOrdenesCompra As String) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@PreOrdenesCompra", PreOrdenesCompra)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioID", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_Cancela_OrdenDeCompra]", listaParametros)
    End Function

    Public Function GuardarPreOrdenCompra(ByVal Accion As Integer, Celdas As String) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Accion", Accion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Celdas", Celdas)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioID", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_Inserta_PreOrdenCompra]", listaParametros)
    End Function

    Public Function ActualizarPreOrdenCompra(ByVal Accion As Integer, Celdas As String) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Accion", Accion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Celdas", Celdas)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioID", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_Actualiza_PreOrdenCompra]", listaParametros)
    End Function

    Public Function ObtenerDatosProveedor(ByVal Accion As Integer, ByVal ProveedorID As Integer) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Accion", Accion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ProveedorID", ProveedorID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_Obtiene_DatosProveedor]", listaParametros)
    End Function

    Public Function ObtieneEstatusOrdenCompra() As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_Obtiene_EstatusOrdenCompra]", listaParametros)
    End Function

End Class
