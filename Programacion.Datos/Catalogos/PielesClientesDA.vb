Public Class PielesClientesDA
    Public Function VerPielesClientes() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select c.clie_clienteid,c.clie_razonsocial from ventas.InfoCliente ic inner join" +
        " cliente.Cliente c on ic.ivcl_infoclienteid=clie_clienteid" +
        " where c.clie_activo=1 and ic.ivcl_codigoespecialcliente=1"
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function TablaPielesClientesListaPrecios(ByVal idCliente As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT" +
            " ISNULL(cc.pcli_pielclienteid, '0') AS idPielCliente," +
            " piel_pielid AS Código," +
            " piel_descripcion AS Nombre," +
            " piel_nombrecorto AS Corto," +
            " piel_codsicy AS SICY," +
            " ISNULL(cc.pcli_codigopielcliente, '') AS CódigoCliente," +
            " ISNULL(cc.ccil_nombrepielcliente, '') AS NombreCliente" +
            " FROM Programacion.Pieles" +
            " left JOIN Programacion.PielesClientes cc" +
            " ON Programacion.Pieles.piel_pielid = cc.pcli_pielid" +
            " WHERE piel_pielid IN (SELECT" +
            " LC.IdPielSAY" +
            " FROM Ventas.vListaPrecioClienteProductos LC" +
            " INNER JOIN Ventas.vListaPrecioCliente L" +
            " ON L.idListaVentasClientePrecio = LC.idListaVentasClientePrecio" +
            " WHERE L.IdSAY = " & idCliente & ")" +
            " AND piel_activo = 1 and pcli_activo=1 order by Nombre"
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function TablaPielesClientesColoresActivos(ByVal idCliente As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT" +
            " ISNULL(cc.pcli_pielclienteid, '0') AS idPielCliente," +
            " piel_pielid AS Código," +
            " piel_descripcion AS Nombre," +
            " piel_nombrecorto AS Corto," +
            " piel_codsicy AS SICY," +
            " ISNULL(cc.pcli_codigopielcliente, '') AS CódigoCliente," +
            " ISNULL(cc.ccil_nombrepielcliente, '') AS NombreCliente" +
            " FROM Programacion.Pieles" +
            " LEFT JOIN Programacion.PielesClientes cc" +
            " ON Programacion.Pieles.piel_pielid = cc.pcli_pielid" +
            " and cc.pcli_clienteid=" & idCliente & " where piel_activo = 1 and pcli_activo=1 order by Nombre;"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function insertarActualizarPielesClientes(ByVal idPielCliente As Integer, ByVal idPiel As Integer,
    ByVal idCliente As Integer, ByVal codigoPielCliente As String, ByVal nomPielCliente As String) As String
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim mensaje As String = String.Empty
        Dim listaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@idPielCliente"
        parametro.Value = idPielCliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@idPiel"
        parametro.Value = idPiel
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@codigoPielCliente"
        parametro.Value = codigoPielCliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@nomPielCliente"
        parametro.Value = nomPielCliente
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@idUsuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)
        dt = operacion.EjecutarConsultaSP("Programacion.SP_AltaEditarPielesClientes", listaParametros)
        If dt.Rows.Count > 0 Then
            mensaje = dt.Rows(0).Item(0).ToString
        End If
        Return mensaje
    End Function
    Public Function getListaPieles() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = <cadena>
            select piel_pielid,piel_descripcion,piel_nombrecorto,piel_codsicy 
            from Programacion.Pieles where piel_activo=1 order by piel_descripcion
                                 </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function actualizarEstatusPielCliente(ByVal estatus As Boolean, ByVal idPielCliente As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = <cadena>
           update Programacion.PielesClientes set pcli_activo='<%= estatus %>' where pcli_pielclienteid=<%= idPielCliente %>
                                 </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function


    Public Function ExisteCombinacionPielCliente(ByVal PielID As Integer, ByVal CodigoCliente As String, ByVal NombreCliente As String, ByVal ClienteID As Integer, ByVal PielClienteID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim mensaje As String = String.Empty
        Dim listaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@PielID"
        parametro.Value = PielID
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@CodigoCliente"
        parametro.Value = CodigoCliente
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
        parametro.ParameterName = "@PielClienteID"
        parametro.Value = PielClienteID
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Programacion_ExisteCombinacionPielCliente]", listaParametros)
        
    End Function

End Class