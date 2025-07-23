Imports System.Data.SqlClient
Public Class GruposDA
    Public Function VerGrupos(ByVal idGrupo As String, ByVal descripcion As String, ByVal activo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String
        cadena = "SELECT" +
                    " grpo_grupoid, grpo_descripcion, grpo_activo" +
                    " FROM Programacion.Grupos" +
                    " where grpo_activo='" + activo.ToString + "'" +
                    " and  grpo_descripcion like '%" + descripcion + "%' "
        If (idGrupo <> "") Then
            cadena += " and grpo_grupoid=" + idGrupo + ""
        End If
        cadena += " ORDER BY grpo_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function VerFilasGrupos() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select grpo_grupoid,grpo_descripcion,grpo_activo FROM Programacion.Grupos ")
    End Function

    Public Function VerIdMaximoGrupos() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT grpo_grupoid, grpo_descripcion" +
                                             " FROM Programacion.Grupos" +
                                             " where grpo_grupoid =(Select max(grpo_grupoid)" +
                                             " FROM Programacion.Grupos)"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub RegistrarGrupo(ByVal entidadGrupo As Entidades.Grupos)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = entidadGrupo.PGDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = entidadGrupo.PGActivo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Alta_Grupo", ListaParametros)
    End Sub

    Public Sub EditarGrupo(ByVal entidadGrupo As Entidades.Grupos, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "idGrupo"
        ParametroParaLista.Value = entidadGrupo.PGrupoId
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = entidadGrupo.PGDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = entidadGrupo.PGActivo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Editar_Grupo", ListaParametros)
    End Sub

    Public Function verComboGrupos(ByVal grupo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadenas As String = "Select" +
                                " grpo_grupoid, grpo_descripcion" +
                                " FROM Programacion.Grupos" +
                                " where grpo_activo='True'"
        If (grupo <> "") Then
            cadenas += " and grpo_descripcion like '%" + grupo + "%'"
        End If
        Return operacion.EjecutaConsulta(cadenas)
    End Function

    Public Function VerGruposPorIdentificador(ByVal idGrupo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String
        cadena = "SELECT" +
            " grpo_grupoid,grpo_descripcion" +
            " FROM Programacion.Grupos" +
            " where grpo_activo='True'" +
            " And grpo_grupoid = " + idGrupo + ""
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function validaExistenModelos(ByVal idGrupo As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " prod_codigo, prod_descripcion" +
                                " FROM Programacion.Productos" +
                                " WHERE prod_grupo =" + idGrupo + " and prod_activo = 1"
        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Function consultaGruposActualizarCapacidadLinea(ByVal idLinea As Int32, ByVal anio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT grpo_grupoid, grpo_descripcion, grpo_activo" +
        " FROM Programacion.Grupos" +
        " WHERE grpo_grupoid NOT IN (SELECT gcap_grupoID " +
        " FROM Programacion.GruposCapacidad" +
        " WHERE gcap_linpID = " + idLinea.ToString +
        " AND gcap_año = " + anio.ToString + ")" +
        " AND grpo_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function


End Class
