Imports Persistencia
Imports System.Data.SqlClient

Public Class CondicionesDA

    Public Function Datos_TablaCondicionesClienteArea(editando As Boolean, clienteID As Integer, areaOperativa As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT " +
                                "  cope_condicionpersonaid " +
                                " ,clie_personaidcliente " +
                                " , tico_tipocondicionid " +
                                " , LTRIM(RTRIM(UPPER(tico_nombre))) AS tico_nombre " +
                                " , cond_condicionid " +
                                " , LTRIM(RTRIM(UPPER(cond_nombre))) AS cond_nombre " +
                                " , coca_condicioncatalogoid " +
                                " , LTRIM(RTRIM(UPPER(coca_descripcion ))) AS coca_descripcion " +
                                " , LTRIM(RTRIM(UPPER(cope_valor))) AS cope_valor " +
                                " , LTRIM(RTRIM(UPPER(cope_descripcion))) AS cope_descripcion " +
                                " , arop_areaoperativaid" +
                                " , coao_controla, cond_activo as 'ACTIVO'" +
                                " FROM Framework.CondicionCatalogo " +
                                " INNER JOIN Framework.Condicion ON cond_condicionid = coca_condicionid " +
                                " INNER JOIN Framework.TipoCondicion ON tico_tipocondicionid = cond_tipocondicionid " +
                                " LEFT JOIN Framework.CondicionPersona ON cope_condicioncatalogoid = coca_condicioncatalogoid " +
                                " LEFT JOIN Framework.CondicionAreaOperativa ON coao_condicionid = coca_condicionid " +
                                " JOIN Framework.AreaOperativa ON arop_areaoperativaid = coao_areaoperativaid " +
                                " JOIN Cliente.Cliente ON clie_personaidcliente = cope_personaid " +
                                " WHERE arop_areaoperativaid = " + areaOperativa.ToString +
                                " AND clie_clienteid = " + clienteID.ToString
        If Not editando Then
            consulta += " AND coca_opciondefault = 0 "
        End If

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_TablaCondicionesCatalogoCondicion(condicionID As Integer, areaOperativa As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                " coca_condicioncatalogoid " +
                                " , LTRIM(RTRIM(UPPER(coca_descripcion))) AS coca_descripcion " +
                                " FROM Framework.CondicionCatalogo " +
                                " WHERE coca_condicionid = " + condicionID.ToString +
                                " ORDER BY coca_descripcion"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub EditarCondicionPersona(condicion As Entidades.CondicionPersona)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@condicionpersonaid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "condicionpersonaid"
        parametro.Value = condicion.condicionpersonaid
        listaParametros.Add(parametro)

        ',@valor AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "valor"
        parametro.Value = condicion.valor
        listaParametros.Add(parametro)

        ',@descripcion AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "descripcion"
        parametro.Value = condicion.descripcion
        listaParametros.Add(parametro)

        ',@condicioncatalogoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "condicioncatalogoid"
        parametro.Value = condicion.condicioncatalogo.condicioncatalogoid
        listaParametros.Add(parametro)

        ',@usuariomodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Editar_CondicionPersona", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub


    Public Function AreaOperativa_Controla(editando As Boolean, clienteID As Integer, areaOperativa As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "  cope_condicionpersonaid " +
                                " ,clie_personaidcliente " +
                                " , tico_tipocondicionid " +
                                " , LTRIM(RTRIM(UPPER(tico_nombre))) AS tico_nombre " +
                                " , cond_condicionid " +
                                " , LTRIM(RTRIM(UPPER(cond_nombre))) AS cond_nombre " +
                                " , coca_condicioncatalogoid " +
                                " , LTRIM(RTRIM(UPPER(coca_descripcion ))) AS coca_descripcion " +
                                " , LTRIM(RTRIM(UPPER(cope_valor))) AS cope_valor " +
                                " , LTRIM(RTRIM(UPPER(cope_descripcion))) AS cope_descripcion " +
                                " FROM Framework.CondicionCatalogo " +
                                " INNER JOIN Framework.Condicion ON cond_condicionid = coca_condicionid " +
                                " INNER JOIN Framework.TipoCondicion ON tico_tipocondicionid = cond_tipocondicionid " +
                                " LEFT JOIN Framework.CondicionPersona ON cope_condicioncatalogoid = coca_condicioncatalogoid " +
                                " LEFT JOIN Framework.CondicionAreaOperativa ON coao_condicionid = coca_condicionid " +
                                " JOIN Framework.AreaOperativa ON arop_areaoperativaid = coao_areaoperativaid " +
                                " JOIN Cliente.Cliente ON clie_personaidcliente = cope_personaid " +
                                " WHERE cond_activo = 1 " +
                                " AND arop_areaoperativaid = " + areaOperativa.ToString +
                                " AND clie_clienteid = " + clienteID.ToString
        If Not editando Then
            consulta += " AND coca_opciondefault = 0 "
        End If

        Return operaciones.EjecutaConsulta(consulta)

    End Function


End Class
