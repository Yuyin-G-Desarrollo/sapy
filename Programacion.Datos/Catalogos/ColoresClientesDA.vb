Public Class ColoresClientesDA

    Public Function VerColoresClientes() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select c.clie_clienteid,c.clie_razonsocial from ventas.InfoCliente ic inner join" +
        " cliente.Cliente c on ic.ivcl_infoclienteid=clie_clienteid" +
        " where c.clie_activo=1 and ic.ivcl_codigoespecialcliente=1"
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function TablaColoresClientesListaPrecios(ByVal idCliente As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT" +
        " ISNULL(cc.ccli_colorclienteid, '0') AS idColorCliente," +
        " color_colorid as Código,color_descripcion as Nombre,color_codsicy as SICY," +
        " ISNULL(cc.ccli_codigocolorcliente,'') as CódigoCliente," +
        " ISNULL(cc.ccil_nombrecolorcliente,'') as NombreCliente" +
        " FROM Programacion.Colores left join Programacion.ColoresClientes cc" +
        " on  Programacion.Colores.color_colorid=cc.ccli_colorid WHERE color_colorid IN (" +
        " SELECT LC.IdColorSAY FROM Ventas.vListaPrecioClienteProductos  LC " +
        " INNER JOIN Ventas.vListaPrecioCliente L ON L.idListaVentasClientePrecio=LC.idListaVentasClientePrecio" +
        " WHERE L.IdSAY=" & idCliente & ") AND color_activo=1 and ccli_activo=1 order by Nombre;"
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function TablaColoresClientesColoresActivos(ByVal idCliente As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT" +
        " ISNULL(cc.ccli_colorclienteid, '0') AS idColorCliente," +
        " color_colorid AS Código," +
        " color_descripcion AS Nombre," +
        " color_codsicy AS SICY," +
        " ISNULL(cc.ccli_codigocolorcliente, '') AS CódigoCliente," +
        " ISNULL(cc.ccil_nombrecolorcliente, '') AS NombreCliente" +
        " FROM Programacion.Colores" +
        " LEFT JOIN Programacion.ColoresClientes cc" +
        " ON Programacion.Colores.color_colorid = cc.ccli_colorid" +
        " and cc.ccli_clienteid=" & idCliente & " where color_activo = 1 and ccli_activo=1 order by Nombre;"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function insertarActualizarColoresClientes(ByVal idColorCliente As Integer, ByVal idColor As Integer,
    ByVal idCliente As Integer, ByVal codigoColorCliente As String, ByVal nomColorCliente As String) As String
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim mensaje As String = String.Empty
        Dim listaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@idColorCliente"
        parametro.Value = idColorCliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@idColor"
        parametro.Value = idColor
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@codigoColorCliente"
        parametro.Value = codigoColorCliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@nomColorCliente"
        parametro.Value = nomColorCliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@idUsuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)
        dt = operacion.EjecutarConsultaSP("Programacion.SP_AltaEditarColoresClientes", listaParametros)
        If dt.Rows.Count > 0 Then
            mensaje = dt.Rows(0).Item(0).ToString
        End If
        Return mensaje
    End Function
    Public Function getListaColores() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = <cadena>
            select color_colorid,color_descripcion,color_codsicy 
            from Programacion.Colores where color_activo=1 order by color_descripcion
                                 </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function actualizarEstatusColorCliente(ByVal estatus As Boolean, ByVal idColorCliente As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = <cadena>
           update Programacion.ColoresClientes set ccli_activo='<%= estatus %>' where ccli_colorclienteid=<%= idColorCliente %>
                                 </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function


    Public Function ExisteCombinacionColorCliente(ByVal ColorID As Integer, ByVal CodigoColor As String, ByVal NombreCliente As String, ByVal ClienteID As Integer, ByVal ColorClienteID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim mensaje As String = String.Empty
        Dim listaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@ColorID"
        parametro.Value = ColorID
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@CodigoCliente"
        parametro.Value = CodigoColor
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@NombreCliente"
        parametro.Value = NombreCliente
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@ClienteID"
        parametro.Value = ClienteID
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@ColorClienteID"
        parametro.Value = ColorClienteID
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Programacion_ExisteCombinacionColorCliente]", listaParametros)


    End Function

End Class
