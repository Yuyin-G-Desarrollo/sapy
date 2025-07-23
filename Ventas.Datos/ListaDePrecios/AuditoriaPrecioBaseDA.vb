Imports System.Data.SqlClient

Public Class AuditoriaPrecioBaseDA

    Public Function verListaPreciosBase() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim cadena As String = "SELECT" +
        '                    " lpba_listapreciosbaseid,lpba_nombrelista , StatusLB = case lpba_estatus " +
        '                    " WHEN 2 then 'AUTORIZADA'  " +
        '                    " WHEN 1 THEN 'ACTIVA' END " +
        '                    " FROM Ventas.ListaPreciosBase where lpba_estatus in (1,2)" +
        '                    " ORDER BY lpba_listapreciosbaseid DESC"

        Return operacion.EjecutaConsulta("Ventas.SP_verListaPreciosBase")
    End Function

    Public Function verProductosPrecioBase(idLstPrecioBase As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdListaPrecioBase"
        parametro.Value = idLstPrecioBase
        listaParametros.Add(parametro)
        Return operacion.EjecutarConsultaSP("Ventas.SP_ListaProductosPrecioBase", listaParametros)

        '        Dim idLstPrecBase As String = CStr(idLstPrecioBase)

        'Dim cadena As String =
        '    " select CL.clie_clienteid as idCliente, CL.clie_nombregenerico as Cliente,lv.lvcp_descripcion as Descripción,lv.lvcp_incrementoporpar as IXP," +
        '    " c.MarcaSAY as 'Marca SAY',c.ColeccionSAY as 'Colección SAY',c.ModeloSAY as 'Modelo SAY',c.ModeloSICY as 'Modelo SICY',c.Talla as Talla,c.Piel as Piel,c.Color as Color," +
        '    " l.lpcp_preciobase as 'P. Base Guardado',l.lpcp_preciocalculado as 'P. Calculado',l.lpcp_precio as 'P. Final'," +
        '    " LB.lpbp_preciobase as 'P. Base Actual',pc.paca_paridadpesos as 'Paridad Pesos'," +
        '    " (LB.lpbp_preciobase* (1+(lv.lvcp_incrementoporpar/100))) as 'P. Calculado Nuevo'," +
        '    " (LB.lpbp_preciobase* (1+(lv.lvcp_incrementoporpar/100))) as '*P. Final Nuevo'," +
        '    " ((LB.lpbp_preciobase* (1+(lv.lvcp_incrementoporpar/100)))/pc.paca_paridadpesos) as 'Paridad P. Base' ," +
        '    " l.lpcp_listaprecioclienteproductoid as 'Id Lista Precio Cliente Producto'" +
        '    " from Ventas.ListaPrecioClienteProducto l" +
        '    " inner join Programacion.vProductoEstilos_Completo c on l.lpcp_productoestiloid=c.ProductoEstiloId" +
        '    "  inner join Ventas.ListaVentasClientePrecio lv on lv.lvcp_listaventasclienteprecioid=l.lpcp_listaventasclienteid" +
        '    " inner join Ventas.ListaVentasCliente lvc on lvc.lvcl_listaventasclienteid=lv.lvcp_listaventasclienteid" +
        '    " INNER JOIN Ventas.ListaPreciosVenta LPV on lpv.lpvt_listaprecioventaid=lvc.lvcl_listaprecioventasid " +
        '    " inner join Ventas.ListaPreciosBase ba on ba.lpba_listapreciosbaseid=lpv.lpvt_listapreciosbaseid" +
        '    " INNER JOIN Ventas.ListaPrecioBaseProducto LB ON c.ProductoEstiloId=LB.lpbp_productoestiloid" +
        '    " AND LB.lpbp_listapreciosbaseid=BA.lpba_listapreciosbaseid" +
        '    " INNER JOIN Cliente.Cliente CL ON CL.clie_clienteid=lvc.lvcl_clienteid" +
        '    " inner join Cobranza.InfoCliente ic on ic.iccl_clienteid =CL.clie_clienteid" +
        '    " inner JOIN Framework.Moneda mo ON mo.mone_monedaid  = ic.iccl_monedaid " +
        '    " inner JOIN Framework.ParidadCambiaria pc ON pc.paca_monedaid = mo.mone_monedaid  " +
        '    " where l.lpcp_preciobase<>LB.lpbp_preciobase" +
        '    " and CL.clie_activo=1 and lv.lvcp_estatusid in (25,26)" +
        '    " AND ic.iccl_clienteid = CL.clie_clienteid" +
        '    " AND ba.lpba_listapreciosbaseid= " + idLstPrecBase + " "




    End Function

    Public Function verProductosPrecioFinal(idLstPrecioBase As Integer) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim idLstPrecBase As String = CStr(idLstPrecioBase)

        Dim cadena As String = "select" +
        " CL.clie_clienteid as idCliente,CL.clie_nombregenerico as Cliente,lv.lvcp_descripcion as Descripción,lv.lvcp_incrementoporpar as IXP," +
        " c.MarcaSAY as 'Marca SAY',c.ColeccionSAY as 'Colección SAY',c.ModeloSAY as 'Modelo SAY',c.ModeloSICY as 'Modelo SICY',c.Talla as Talla,c.Piel as Piel,c.Color as Color," +
        " l.lpcp_preciobase as 'P. Base Guardado',l.lpcp_preciocalculado as 'P. Calculado',l.lpcp_precio as 'P. Final'," +
        " LB.lpbp_preciobase as 'P. Base Actual',pc.paca_paridadpesos as 'Paridad Pesos'," +
        " (LB.lpbp_preciobase* (1+(lv.lvcp_incrementoporpar/100))) as 'P. Calculado Nuevo'," +
        " (LB.lpbp_preciobase* (1+(lv.lvcp_incrementoporpar/100))) as '*P. Final Nuevo'," +
        " ((LB.lpbp_preciobase* (1+(lv.lvcp_incrementoporpar/100)))/pc.paca_paridadpesos) as 'Paridad P. Base'," +
        " l.lpcp_listaprecioclienteproductoid as 'Id Lista Precio Cliente Producto'" +
        " from Ventas.ListaPrecioClienteProducto as l" +
        " inner join Programacion.vProductoEstilos_Completo c on l.lpcp_productoestiloid=c.ProductoEstiloId" +
        " inner join Ventas.ListaVentasClientePrecio lv on lv.lvcp_listaventasclienteprecioid=l.lpcp_listaventasclienteid " +
        " inner join Ventas.ListaVentasCliente lvc on lvc.lvcl_listaventasclienteid=lv.lvcp_listaventasclienteid" +
        " INNER JOIN Ventas.ListaPreciosVenta LPV on lpv.lpvt_listaprecioventaid=lvc.lvcl_listaprecioventasid " +
        " inner join Ventas.ListaPreciosBase ba on ba.lpba_listapreciosbaseid=lpv.lpvt_listapreciosbaseid" +
        " INNER JOIN Ventas.ListaPrecioBaseProducto LB ON c.ProductoEstiloId=LB.lpbp_productoestiloid" +
        " AND LB.lpbp_listapreciosbaseid=BA.lpba_listapreciosbaseid" +
        " INNER JOIN Cliente.Cliente CL ON CL.clie_clienteid=lvc.lvcl_clienteid" +
        " inner join Cobranza.InfoCliente ic on ic.iccl_clienteid =CL.clie_clienteid" +
        " inner JOIN Framework.Moneda mo ON mo.mone_monedaid  = ic.iccl_monedaid" +
        " inner JOIN Framework.ParidadCambiaria pc ON pc.paca_monedaid = mo.mone_monedaid " +
        "  where l.lpcp_preciocalculado<>l.lpcp_precio " +
        " and CL.clie_activo=1 and lv.lvcp_estatusid in (25,26) AND ba.lpba_listapreciosbaseid= " + idLstPrecBase + " " +
        " AND ic.iccl_activo = 1" +
        " AND mo.mone_activo = 1" +
        " AND pc.paca_activo = 1 " +
        " AND ic.iccl_clienteid = CL.clie_clienteid "

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function actualizarPrecioCliente(ByVal precioBaseActual, ByVal precioCalculadoNuevo, ByVal paridadPrecioBase, ByVal precioFinalNuevo, ByVal paridadPrecioBase1, ByVal usuarioId, ByVal idListaPrecioCliente)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@precioBaseActual"
        parametro.Value = precioBaseActual
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@precioCalculadoNuevo"
        parametro.Value = precioCalculadoNuevo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@paridadPrecioBase"
        parametro.Value = paridadPrecioBase
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@precioFinalNuevo"
        parametro.Value = precioFinalNuevo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@paridadPrecioBase1"
        parametro.Value = paridadPrecioBase1
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioId"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idListaPrecioCliente"
        parametro.Value = idListaPrecioCliente
        listaParametros.Add(parametro)        
        'al pasarlo a una bd de prueba se necesita crear el SP y agregar la paridad de pesos mexicanos a 1 en (Framework.ParidadCambiaria)
        'si no los que se manejen en moneda mexicana no se mostrarán porque la paridad es null
        Return operacion.EjecutarConsultaSP("Ventas.SP_Actualiza_ListaPrecioClienteProducto", listaParametros)
    End Function


End Class
