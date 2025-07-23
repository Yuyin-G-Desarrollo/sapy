Imports System.Data.SqlClient

Public Class CategoriasDA

    Public Function verListaCategorias(ByVal activo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT " +
                                    "tica_tipocategoriaid, " +
                                    "tica_descripcion, " +
                                    "tica_activo " +
                                    "FROM Programacion.TipoCategoria " +
                            "WHERE tica_activo = '" + activo.ToString + "'"
        cadena += "ORDER BY tica_descripcion "
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verIdMaxCategorias() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT " +
                                    "MAX(tica_tipocategoriaid) " +
                                    "FROM Programacion.TipoCategoria "
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub registrarEditaCategoria(ByVal entCategoria As Entidades.Categorias, ByVal altaCat As Boolean)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idCategoria"
        If altaCat = True Then
            ParametroParaLista.Value = DBNull.Value
        Else
            ParametroParaLista.Value = entCategoria.PidCategoria
        End If
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@nombreCat"
        ParametroParaLista.Value = entCategoria.PnombreCategoria
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@activo"
        ParametroParaLista.Value = entCategoria.PactivoCategoria.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuarioid"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@AltaCat"
        ParametroParaLista.Value = altaCat.ToString
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_AltaEditarCategoria", ListaParametros)
    End Sub

    Public Function verCategoriaRapido(ByVal idCategoria As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT " +
                                    "tica_tipocategoriaid, " +
                                    "tica_descripcion, " +
                                    "tica_activo " +
                                    "FROM Programacion.TipoCategoria " +
                            "WHERE tica_tipocategoriaid = '" + idCategoria.ToString + "'"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function contarRegistrosCategoria(ByVal idCategoria As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT COUNT(*) FROM Programacion.Productos WHERE prod_categoria=" + idCategoria.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verListaSuelas(ByVal activo As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@Activo"
            parametro.Value = activo
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Modelos_ConsultaSuelas]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function verListaColorSuela(ByVal activo As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@cosu_activo"
            parametro.Value = activo
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Obtener_ColoresSuelas]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
