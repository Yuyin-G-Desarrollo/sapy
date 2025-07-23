Imports Entidades
Imports System.Data.SqlClient

Public Class DevolucionDA
    Public Function getDevoluciones(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal nave As Integer, ByVal todosModelos As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        'Dim consulta2 As String = ""
        'Dim consulta As String =
        '    <cadena>        
        '    SELECT
        '    0 seleccionar,
        ' d.IdDevolucion,
        ' d.Folio,
        ' d.Fecha,
        ' (SELECT
        '  Descripcion
        ' FROM catGeneral
        ' WHERE IdGeneral = d.Tipo)
        ' AS TDevolucion,
        ' d.IdCadena,
        ' (SELECT
        '  Nombre
        ' FROM Cadenas
        ' WHERE IdCadena = d.IdCadena)
        ' AS Cliente,
        ' dd.IdDetalleDevolucion,
        ' (SELECT
        '  Descripcion
        ' FROM catGeneral
        ' WHERE IdGeneral = dd.IdCat)
        ' AS Categoria,
        ' dd.codigo 'Código',
        '    catProductos.IdModelo 'Modelo',
        '    dd.Lote,
        ' dd.descripcion 'Descripción',
        ' (SELECT
        '  Descripcion
        ' FROM catGeneral
        ' WHERE IdGeneral = dd.IdCatDef)
        ' AS Defecto,
        ' dd.Nave,
        ' dd.Cantidad 'Pares',
        ' dd.IdTalla,
        ' dd.aplicadoMaquila,
        ' isnull(pptd_precio,0) 'Precio',
        ' isnull((dd.Cantidad*pptd_precio),0) 'Total',
        '    catProductos.Estatus
        '    FROM [dev devoluciones] d
        '    INNER JOIN [dev devolucionesdetalles] dd
        ' ON d.IdDevolucion = dd.IdDevolucion
        ' inner JOIN catProductos
        ' ON IdCodigo = dd.Codigo
        ' AND dd.IdTalla = IdCorrida
        ' AND IdNave = dd.Nave
        ' AND Estatus IN ('AUTORIZADO', '')
        ' LEFT JOIN Proveedores.vPrecioProductoTerminadoDetalles
        ' ON IdProducto = pptd_productoid
        '    LEFT JOIN Proveedores.PreciosProductoTerminado
        ' ON ppt_listaid = pptd_listaid
        ' AND ppt_naveid = dd.Nave
        ' AND ppt_estatus = 'AUTORIZADA'
        '    WHERE d.St='PROCEDE' 
        '    </cadena>
        'consulta += " and  dd.Nave=" & nave & " and dd.aplicadoMaquila is null and"
        'consulta += " d.Fecha BETWEEN '" & fechaInicio.ToString("dd/MM/yyyy") & "' and '" & fechaFin.ToString("dd/MM/yyyy") & "' and d.Tipo=36"
        'If todosModelos Then
        '    consulta2 = <cadena>
        '     union SELECT
        '    0 seleccionar,
        ' d.IdDevolucion,
        ' d.Folio,
        ' d.Fecha,
        ' (SELECT
        '  Descripcion
        ' FROM catGeneral
        ' WHERE IdGeneral = d.Tipo)
        ' AS TDevolucion,
        ' d.IdCadena,
        ' (SELECT
        '  Nombre
        ' FROM Cadenas
        ' WHERE IdCadena = d.IdCadena)
        ' AS Cliente,
        ' dd.IdDetalleDevolucion,
        ' (SELECT
        '  Descripcion
        ' FROM catGeneral
        ' WHERE IdGeneral = dd.IdCat)
        ' AS Categoria,
        ' dd.codigo 'Código',
        '    catProductos.IdModelo 'Modelo',
        '    dd.Lote,
        ' dd.descripcion 'Descripción',
        ' (SELECT
        '  Descripcion
        ' FROM catGeneral
        ' WHERE IdGeneral = dd.IdCatDef)
        ' AS Defecto,
        ' dd.Nave,
        ' dd.Cantidad 'Pares',
        ' dd.IdTalla,
        ' dd.aplicadoMaquila,
        ' isnull(pptd_precio,0) 'Precio',
        ' isnull((dd.Cantidad*pptd_precio),0) 'Total',
        '    catProductos.Estatus
        '    FROM [dev devoluciones] d
        '    INNER JOIN [dev devolucionesdetalles] dd
        ' ON d.IdDevolucion = dd.IdDevolucion
        ' inner JOIN catProductos
        ' ON IdCodigo = dd.Codigo
        ' AND dd.IdTalla = IdCorrida
        ' AND IdNave = dd.Nave
        ' AND Estatus IN ('INACTIVO','ELIMINADO','DESCONTINUADO')
        ' LEFT JOIN Proveedores.vPrecioProductoTerminadoDetalles
        ' ON IdProducto = pptd_productoid
        '    LEFT JOIN Proveedores.PreciosProductoTerminado
        ' ON ppt_listaid = pptd_listaid
        ' AND ppt_naveid = dd.Nave
        ' AND ppt_estatus = 'AUTORIZADA'
        '    WHERE d.St='PROCEDE' 
        '    and  dd.Nave=<%= nave %> and dd.aplicadoMaquila is null and
        '    d.Fecha BETWEEN '<%= fechaInicio.ToString("dd/MM/yyyy") %>' and '<%= fechaFin.ToString("dd/MM/yyyy") %>' and d.Tipo=36
        '    and dd.IdDetalleDevolucion not in (    SELECT
        ' dd.IdDetalleDevolucion
        '    FROM [dev devoluciones] d
        '    INNER JOIN [dev devolucionesdetalles] dd
        ' ON d.IdDevolucion = dd.IdDevolucion
        ' inner JOIN catProductos
        ' ON IdCodigo = dd.Codigo
        ' AND dd.IdTalla = IdCorrida
        ' AND IdNave = dd.Nave
        ' AND Estatus IN ('AUTORIZADO', '')
        ' LEFT JOIN Proveedores.vPrecioProductoTerminadoDetalles
        ' ON IdProducto = pptd_productoid
        '    LEFT JOIN Proveedores.PreciosProductoTerminado
        ' ON ppt_listaid = pptd_listaid
        ' AND ppt_naveid = dd.Nave
        ' AND ppt_estatus = 'AUTORIZADA'
        '    WHERE d.St='PROCEDE' 
        '     and  dd.Nave=<%= nave %> and dd.aplicadoMaquila is null and d.Fecha BETWEEN '<%= fechaInicio.ToString("dd/MM/yyyy") %>' and '<%= fechaFin.ToString("dd/MM/yyyy") %>' and d.Tipo=36)
        '    </cadena>
        'End If
        'Dim c As String = consulta + consulta2
        'Return operaciones.EjecutaConsulta(c)
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = fechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = fechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = nave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@todosModelos"
        parametro.Value = todosModelos
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_ProductoTerminado_ObtenerDevoluciones]", listaparametros)

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
    Public Function getDatosComprobante(ByVal idcomprobante As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
          select m.*,Nave from Proveedores.MaquilaComprobantes m join naves on IdNave=maco_naveid
            </cadena>
        consulta += " WHERE maco_comprobanteid=" & idcomprobante & "  "
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function aplicarDevolucion(ByVal devolucion As DevolucionMaquila) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idComprobante"
        parametro.Value = devolucion.idComprobante
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idDevDetalles"
        parametro.Value = devolucion.idDevolucionDetalle
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@pares"
        parametro.Value = devolucion.pares
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idCadena"
        parametro.Value = devolucion.idCadena
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@precio"
        parametro.Value = devolucion.precio
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@total"
        parametro.Value = devolucion.total
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@descripcion"
        parametro.Value = devolucion.descripcion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@codigo"
        parametro.Value = devolucion.codigo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = devolucion.usuario
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_aplicarDevolucion]", listaparametros)
    End Function

    Public Function getDetalleDevolucionPares(ByVal idDetalleDevolucion As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
           select IdDetalleDevolucion,Talla,Calce,Cantidad from [dev DevolucionesDetallesPares] where IdDetalleDevolucion=<%= idDetalleDevolucion %>
            </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        Return datos
    End Function
    Public Function getPrecioPorTalla(ByVal idNave As Integer, ByVal talla As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
           select isnull(avg(DISTINCT pma_precio),0) 'precio' from Proveedores.PrecioModelosAntiguos where pma_idNave=<%= idNave %> and pma_talla='<%= talla %>'
            </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        Return datos
    End Function
    Public Function getPrecioFamiliaTalla(ByVal idFamilia As Integer, ByVal talla As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
           select isnull(avg(pma_precio),0) 'precio' from Proveedores.PrecioModelosAntiguos where pma_idFamiliaSay=<%= idFamilia %> and pma_idNave=0 and pma_talla='<%= talla %>'
            </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        Return datos
    End Function
    Public Function getFamiliaModelo(ByVal modeloSicy As String, ByVal idTallaSicy As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
            select top(1) fp.fapr_familiaproyeccionid 'Familia' from Programacion.vProductoEstilos_Completo vpe INNER JOIN 
            Programacion.ColeccionMarca cm on cm.coma_coleccionid=vpe.ColeccionId AND vpe.MarcaIdSAY=cm.coma_marcaid
            INNER JOIN Programacion.Familias_Proyeccion fp on 
            fp.fapr_familiaproyeccionid=cm.coma_familiaproyeccionid where vpe.ModeloSICY='<%= modeloSicy %>' AND vpe.IdTallaSicy='<%= idTallaSicy %>'
            </cadena>
        datos = operaciones.EjecutaConsulta(consulta)
        Return datos

    End Function

End Class
