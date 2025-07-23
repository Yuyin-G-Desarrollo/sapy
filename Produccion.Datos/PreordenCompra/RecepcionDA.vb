Imports Entidades
Imports System.Data.SqlClient

Public Class RecepcionDA
    Public Function getNextFolioRemision(ByVal idNavesay As Integer, ByVal idProveedorsay As Integer) As String
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena> 
            select top(1)NUMDOCTO from CxPSALDOS where CVEPROV=<%= getidSicyProveedor(idProveedorsay) %> and NAVE=<%= getNaveIdAlmacenSIcy(getNaveSIcy(idNavesay)) %> and TIPODOCTO=2 order by IDTABLA desc
            </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Try
                Dim folio As Integer = CInt(datos.Rows(0).Item(0).ToString.Trim.Replace(" ", ""))
                folio += 1
                Return folio
            Catch ex As Exception
                Return datos.Rows(0).Item(0).ToString.Trim.Replace(" ", "") & "$CONTIENE LETRAS"
            End Try
        End If
        Return "1"
    End Function

    Public Function getProveedorOrdenCompra(ByVal idordencompra As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena> 
            select ordc_proveedorid from Produccion.OrdenDeCompra where ordc_ordencompraid=<%= idordencompra %>
            </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return datos.Rows(0).Item(0).ToString.Trim.Replace(" ", "")
        End If
        Return 0
    End Function

    Public Function insertarComprobante(ByVal idordencompra As Integer, ByVal ruta As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena> 
            INSERT INTO [Produccion].[ComprobanteOrdenCompra]
           ([como_idordencompra]
           ,[como_rutaPDF])
            VALUES
           (<%= idordencompra %>,'<%= ruta %>')
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getNombreNave(ByVal idNave As Integer) As String
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena> 
            select nave_nombre from Framework.Naves where nave_naveid=<%= idNave %>
            </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return datos.Rows(0).Item(0).ToString.Trim.Replace(" ", "")
        End If
        Return ""
    End Function
    Public Function validarFolio(ByVal folio As String, ByVal idProveedor As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena> 
            select NUMDOCTO from CxPSALDOS where CVEPROV=<%= getidSicyProveedor(idProveedor) %> and NUMDOCTO like '<%= folio %>'
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getidSicyProveedor(ByVal idProveedorSAY As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena> 
            select prov_sicyid from Proveedor.Proveedor where prov_proveedorid=<%= idProveedorSAY %>
            </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return datos.Rows(0).Item(0).ToString.Trim.Replace(" ", "")
        End If
        Return 0
    End Function

    Public Function getDatosOrdendeCompra(ByVal idOrdenCompra As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@OrdenCompraID", idOrdenCompra)
        listaparametros.Add(parametro)

        'Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '    <cadena> 
        '    select mone_monedaid,prov_pais pais,oc.ordc_naveid,oc.ordc_proveedorid,ordc_ordennumero,m.mone_nombre,p.prov_razonsocial,p.prov_rfc,
        '    (select sum(ocde_total) from Produccion.OrdenDeCompraDetalle where 
        '    ocde_ordencompraid=oc.ordc_ordencompraid and ocde_estatusmaterial='COMPLETO') subtotal,oc.ordc_descuento from Produccion.OrdenDeCompra oc
        '    inner join Proveedor.Proveedor p on p.prov_proveedorid=oc.ordc_proveedorid
        '    left join Framework.Moneda m on m.mone_monedaid=oc.ordc_monedaid
        '    where oc.ordc_ordencompraid=<%= idOrdenCompra %>
        '    </cadena>
        'Return operaciones.EjecutaConsulta(consulta)

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_RecibirDocumento_DatosOrdendeCompra]", listaparametros)
    End Function

    Public Function getEmpresasXNave(ByVal idNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select empr_empresaid,empr_nombre,empr_rfc from Framework.Empresas where empr_empresaid=6--Cambiar cuando se tenga la configuracion de las empresas por nave
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getFacturas(ByVal idNave As Integer, ByVal idProveedor As Integer, ByVal total As Double, ByVal idEmpresa As Integer, ByVal idmoneda As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select 0 seleccion,cfd_Id,cfd_Serie+cfd_Folio 'Folio',cfd_Fecha,cfd_SubTotal 'Subtotal',
                '' 'Descuento',cfd_SubTotal*.16 'IVA',cfd_Total 'Total',0 'Artículos' ,
                cfd_IdComprobantesicy,cfd_Serie,cfd_Folio,cfd_RfcEmpresa,
                cfd_RfcProveedor,cfd_modenaid,cfd_IdNave                
                from Proveedor.CFDSOrdenCompra 
                where cfd_IdProveedor=<%= idProveedor %> and cfd_Total  BETWEEN  <%= total - 1 %> and <%= total + 1 %>
                and cfd_IdEmpresa=<%= idEmpresa %> and cfd_IdNave=<%= idNave %>
                and cfd_modenaid=<%= idmoneda %>
                AND (cfd_recibida= 0 OR cfd_recibida IS NULL)
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getPlazoProveedor(ByVal idProveedor As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select plpa_plazopagoid,plpa_plazo from Proveedor.PlazoProveedor inner join Proveedor.PlazoPago
                on plpa_plazopagoid=plpr_plazopagoid where plpr_proveedorid=<%= idProveedor %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function InsertcxpSaldoscxpMovimientos(ByVal c As CxPSaldos) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY

        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@tipoDoc"
        parametro.Value = c.TIPODOCTO
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idProveedor"
        parametro.Value = c.CVEPROV
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@numDoc"
        parametro.Value = c.NUMDOCTO
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@fechaDoc"
        parametro.Value = c.FECDOCTO
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@fechaVencimiento"
        parametro.Value = c.FECVENTO
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@semanaPago"
        parametro.Value = c.SEMPAGO
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@semanaPagada"
        parametro.Value = c.SEMPAGADA
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@subTotal"
        parametro.Value = c.SUBTOT
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@iva"
        parametro.Value = c.IMPIVA
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@nave"
        parametro.Value = getNaveIdAlmacenSIcy(getNaveSIcy(c.NAVE))
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@total"
        parametro.Value = c.IMPDOCTO
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@totalDoc"
        parametro.Value = c.SDODOCTO
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@moneda"
        parametro.Value = c.MONEDA
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@añoSemPago"
        parametro.Value = c.AÑOSEMPAGO
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@rfcContribuyente"
        parametro.Value = c.RfcEmpresa
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@rfcProveedor"
        parametro.Value = c.RfcProveedor
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@giro"
        parametro.Value = c.REFERENCIA
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idcomprobantesicy"
        parametro.Value = c.IdComprobante
        listaparametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_InsertcxpSaldoscxpMovimientosOrdenCompra]", listaparametros)
    End Function
    Public Function getNaveSIcy(ByVal idNave As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
           select nave_navesicyid from Framework.Naves where nave_naveid=<%= idNave %>
            </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return Convert.ToInt32(datos.Rows(0).Item(0).ToString)
        End If
        Return 0
    End Function

    Public Function getNaveIdAlmacenSIcy(ByVal idNaveSicy As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
           select idAlmacen from NavesAlmacen where idnave=<%= idNaveSicy %>
            </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return Convert.ToInt32(datos.Rows(0).Item(0).ToString)
        End If
        Return 0
    End Function

    Public Function getDatosProveedor(ByVal idProveedor As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select prov_pais,prov_proveedorid,isnull(prov_sicyid,0) sicy,isnull(girp_descripcion,'') giro from Proveedor.Proveedor
                left join Proveedor.ClasificacionGiro on clag_clasificaciongiroid=prov_clasificaciongiroid
                left join Proveedor.GiroProveedor on girp_giroproveedorid=clag_giroproveedorid
                where prov_proveedorid=<%= idProveedor %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getSemana(ByVal idsemana As Integer, ByVal fecha As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
                select * from catSemanas
            </cadena>
        If idsemana > 0 Then
            consulta += " where numsem=" & idsemana
        Else
            consulta += " where '" & fecha.ToString("dd/MM/yyyy") & "' BETWEEN FecIni and FecFin"
        End If

        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getSemanaPago(ByVal idsemanaRecibido As Integer, ByVal idplazo As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select * from Proveedor.SemanaCompraPago 
                where secp_plazopagoid=<%= idplazo %>
                and secp_semanaid=<%= idsemanaRecibido %>
            </cadena>

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function cerrarDatosOrdenCompraFacturaRecibida(ByVal idordencompra As Integer, ByVal idcfdsOrdenCompra As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ordencompraid"
        parametro.Value = idordencompra
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@IdcfdsOrdenCompra"
        parametro.Value = idcfdsOrdenCompra
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[cerrarDatosOrdenCompraFacturaRecibida]", listaparametros)
    End Function
    Public Function getRFCProveedor(ByVal idproveedor As Integer) As String
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
                select prov_rfc from Proveedor.Proveedor where prov_proveedorid=<%= idproveedor %>
            </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return datos.Rows(0).Item(0).ToString.Trim.Replace(" ", "")
        End If
        Return ""
    End Function
    Public Function getPaisProveedor(ByVal idproveedor As Integer) As String
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
                select isnull(prov_pais,'') from Proveedor.Proveedor where prov_proveedorid=<%= idproveedor %>
            </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return datos.Rows(0).Item(0).ToString.Trim.Replace(" ", "")
        End If
        Return ""
    End Function
    Public Function getDocumentosOrden(ByVal idordencompra As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
               select cfd_RutaXml,cfd_RutaVisor from Proveedor.CFDSOrdenCompra where cfd_ordenCompraid=<%= idordencompra %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getPDFProveedorExtranjero(ByVal idordencompra As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
               SELECT como_rutaPDF  FROM Produccion.ComprobanteOrdenCompra where como_idordencompra=<%= idordencompra %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getConfiguracionNave(ByVal idNaveSay As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
           CStr(<cadena>
           select fac_correo,fac_serverEntrada,fac_contrasena,naem_rutafacturas fac_rutaFacturas,fac_puertoEntrada 
            from ConfiguracionRecepcionFacturas 
            left join  Framework.NaveEmpresa on naem_naveid=fac_idNaveSay where fac_idNaveSay=<%= idNaveSay %>
                </cadena>)
        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
