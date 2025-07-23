Imports System.Data.SqlClient

Public Class ProductosFactDA
    Public Function obtenerListadoProductos(ByVal idUsuario As Integer, ByVal idSucursal As Integer, ByVal activo As Boolean, ByVal filtro As String, ByVal ids As String, ByVal pesos As Boolean)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim strSucursal As String = String.Empty
        Dim strFiltro As String = String.Empty
        Dim precio As String = String.Empty

        If idSucursal <> 0 Then
            strSucursal = " and su.sucu_sucursaldid = " & idSucursal & " "
        End If

        If filtro <> "" Then
            strFiltro = " and fapr_descripción like '%" & filtro & "%' "
        End If

        If ids <> "" Then
            strFiltro &= " and fapr_productoid not in (" & ids & ")"
        End If

        If pesos Then
            precio = "fapr_preciopesos"
        Else
            precio &= "fapr_preciodolares"
            strFiltro &= " and fapr_preciodolares is not null "
        End If

        consulta = "select row_number() OVER(ORDER BY fapr_descripción) as NUM, " & _
                    "fapr_productoid as ID, " & _
                    "ISNULL(fapr_descripción, '') as DESCRIPCION, " & _
                    "ISNULL(fapr_unidadmedidaid, '') as IDUNIDADMEDIDA, " & _
                    "ISNULL(um.unme_descripcion, '') as UNIDAD_MEDIDA, " & _
                    "ISNULL(fapr_preciopesos, '') as PRECIO_PESOS, " & _
                    "ISNULL(fapr_preciodolares, '') as PRECIO_DOLARES, " & _
                    "ISNULL(" & precio & ", '') as PRECIO, " & _
                    "ISNULL(convert(varchar(10),fapr_fechacreacion, 103), '') as FECHA_CREACION, " & _
                    "ISNULL(u.user_username, '') as USUARIO  " & _
                    "from Facturacion.FacturacionProductos fc " & _
                    "inner join Facturacion.SucursalUsuarios su on fc.fapr_sucursalid = su.sucu_sucursaldid " & _
                    "inner join Materiales.UnidadDeMedida um on fc.fapr_unidadmedidaid = um.unme_idunidad " & _
                    "inner join Framework.Usuarios u on u.user_usuarioid = fc.fapr_usuariocreoid " & _
                    "where susu_usuarioid = " & idUsuario & " and fapr_activo = '" & activo & "' " & strSucursal & strFiltro & _
                    "order by fapr_descripción"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerUnidadMedida() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String

        consulta = "select unme_idunidad ID, unme_descripcion descripcion from Materiales.UnidadDeMedida where unme_status = 1 order by unme_descripcion"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerProducto(ByVal idProducto As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "select fapr_productoid, " & _
            "ISNULL(fapr_descripción, '') fapr_descripción, " & _
            "ISNULL(fapr_unidadmedidaid, 0) fapr_unidadmedidaid, " & _
            "ISNULL(fapr_preciopesos, 0) fapr_preciopesos, " & _
            "ISNULL(fapr_preciodolares, 0) fapr_preciodolares, " & _
            "ISNULL(fapr_sucursalid, 0) fapr_sucursalid, " & _
            "fapr_activo " & _
            "from Facturacion.FacturacionProductos " & _
            "where fapr_productoid = " & idProducto

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function existeRegistro(ByVal descripcion As String, ByVal idSucursal As Integer, ByVal idProducto As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim condicion As String = String.Empty

        If idProducto <> 0 Then
            condicion = " and fapr_productoid <> " & idProducto
        End If

        consulta = "Select * from Facturacion.FacturacionProductos where fapr_sucursalid = " & idSucursal & " and fapr_descripción = '" & descripcion & "' " & condicion
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Sub guardarProducto(ByVal producto As Entidades.ProductosFacturacion)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "productoid"
        parametro.Value = producto.PProdId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "sucursalid"
        parametro.Value = producto.PSucursalId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descripcion"
        parametro.Value = producto.PDescripcion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "unidadmedidaid"
        parametro.Value = producto.PUnidadMedidaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "preciopesos"
        parametro.Value = producto.PPrecioPesos
        listaParametros.Add(parametro)

        If producto.PPrecioDolares > 0 Then
            parametro = New SqlParameter
            parametro.ParameterName = "preciodolares"
            parametro.Value = producto.PPrecioDolares
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "usuario"
        parametro.Value = producto.PUsuarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = producto.PActivo
        listaParametros.Add(parametro)

        operacion.EjecutarConsultaSP("Facturacion.SP_GuardarProducto", listaParametros)
    End Sub
End Class
