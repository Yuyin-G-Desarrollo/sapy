Imports System.Data.SqlClient

Public Class ClientesProgramacionDA

    Public Function llenarListaClientesConsulta(ByVal marcaid As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " c.clie_clienteid," +
                                " c.clie_nombregenerico," +
                                " t.ticl_nombre" +
                        " FROM Cliente.Cliente c" +
                        " JOIN Programacion.ClienteMarcaEspecial cm" +
                            " ON c.clie_clienteid = cm.clme_clienteid" +
                            " JOIN Ventas.TipoCliente t" +
                                " ON c.clie_tipoclienteid = t.ticl_tipoclienteid" +
                                " WHERE cm.clme_marcaid = " + marcaid.ToString +
                                " And cm.clme_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function mostrarClientesAgregarConsulta(ByVal marcaid As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " c.clie_clienteid," +
                                " c.clie_nombregenerico," +
                                " t.ticl_nombre," +
                                " 1 AS relacion" +
                            " FROM Cliente.Cliente c" +
                            " JOIN Programacion.ClienteMarcaEspecial cm" +
                                " ON c.clie_clienteid = cm.clme_clienteid" +
                            " JOIN Ventas.TipoCliente t" +
                                " ON c.clie_tipoclienteid = t.ticl_tipoclienteid" +
                                    " WHERE cm.clme_marcaid = " + marcaid.ToString +
                            " AND cm.clme_activo = 1 UNION SELECT" +
                                " c.clie_clienteid," +
                                " c.clie_nombregenerico," +
                                " t.ticl_nombre," +
                                " 0 AS relacion" +
                            " FROM Cliente.Cliente c" +
                            " JOIN Ventas.TipoCliente t" +
                                " ON c.clie_tipoclienteid = t.ticl_tipoclienteid" +
                            " WHERE c.clie_clienteid NOT IN (SELECT" +
                                    " cme.clme_clienteid" +
                            " FROM Programacion.ClienteMarcaEspecial cme" +
                                    " WHERE cme.clme_marcaid = " + marcaid.ToString +
                            " AND cme.clme_activo = 1)" +
                            " AND c.clie_activo = 1" +
                            " ORDER BY relacion DESC, c.clie_nombregenerico"
        Return operacion.EjecutaConsulta(cadena)
    End Function


    Public Function mostrarTodosLosClientes(ByVal idMarca As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idMarca"
        ParametroParaLista.Value = idMarca
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Programacion.SP_ConsultaClientesPorMarca", ListaParametros)
    End Function

    Public Sub inactivarRelacionMarcaCliente(ByVal idMarca As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idMarca"
        ParametroParaLista.Value = idMarca
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idUsuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_InactivarRelacionClienteMarca", ListaParametros)
    End Sub

    Public Sub registrarRelacionMarcaCLiente(ByVal idMarca As Int32, ByVal idCliente As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@marcaId"
        ParametroParaLista.Value = idMarca
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@cienteId"
        ParametroParaLista.Value = idCliente
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_AltaEditarRelacionMarcaCliente", ListaParametros)
    End Sub

    Public Sub registrarClienteDescripcionModelo(ByVal idDescripcion As Int32, ByVal idCliente As Int32, ByVal idModelo As Int32, ByVal descripcion As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idDescripcion"
        ParametroParaLista.Value = idDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idCliente"
        ParametroParaLista.Value = idCliente
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idModelo"
        ParametroParaLista.Value = idModelo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@descripcion"
        ParametroParaLista.Value = descripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@activo"
        If descripcion = "" Then
            ParametroParaLista.Value = False
        Else
            ParametroParaLista.Value = True
        End If
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_AltaClienteDescripcionModelo", ListaParametros)
    End Sub

    Public Function mostrarClientesColeccionMarca(ByVal idMarca As Int32, ByVal idColeccion As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idMarca"
        ParametroParaLista.Value = idMarca
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idColeccion"
        ParametroParaLista.Value = idColeccion
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Programacion.SP_ConsultaClientesPorColeccionMarca", ListaParametros)
    End Function

    Public Function mostrarDescripcionPorModelo(ByVal idModelo As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                            " cldm_clientemodelodescripcionid," +
                            " cldm_clienteid," +
                            " cldm_modeloid," +
                            " cldm_descripcion," +
                            " cldm_activo" +
                            " FROM Programacion.ClienteModeloDescripcion" +
                            " WHERE cldm_modeloid = " + idModelo.ToString +
                            " AND cldm_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function


    Public Function ConsultaClientesExclucionProductosNuevos() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = <cadena>
                     SELECT
	                    clie_clienteid,
	                    clie_nombregenerico,
	                    clie_excluirproductosnuevos
                    FROM Cliente.Cliente
                    WHERE clie_activo = 1
                    ORDER BY clie_nombregenerico</cadena>.Value
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub editarExcluirCliente(ByVal excluir As Boolean, ByVal idCliente As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "UPDATE Cliente.Cliente SET clie_excluirproductosnuevos = '" + excluir.ToString + "' WHERE clie_clienteid = " + idCliente.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

End Class
