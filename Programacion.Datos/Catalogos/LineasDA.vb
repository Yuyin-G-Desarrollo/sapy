Imports System.Data.SqlClient

Public Class LineasDA

    Public Function verListaLineas(ByVal activo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                    " linea_lineaid," +
                                    " linea_descripcion," +
                                    " linea_activo" +
                                    " FROM Programacion.Lineas" +
                            " WHERE linea_activo = '" + activo.ToString + "' ORDER BY linea_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verIdMaxLineas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " MAX(linea_lineaid)" +
                        "FROM Programacion.Lineas"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub registrarEditaLinea(ByVal entLineas As Entidades.Lineas, ByVal altaLinea As Boolean)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idLinea"
        If altaLinea = True Then
            ParametroParaLista.Value = DBNull.Value
        Else
            ParametroParaLista.Value = entLineas.PidLinea
        End If
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@nombreLinea"
        ParametroParaLista.Value = entLineas.PnombreLinea
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuarioid"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@activo"
        ParametroParaLista.Value = entLineas.PactivoLinea.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@AltaLinea"
        ParametroParaLista.Value = altaLinea.ToString
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_AltaEditarLinea", ListaParametros)
    End Sub

    Public Function validarInactivarLinea(ByVal idLinea As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT COUNT(*) FROM Programacion.ProductoEstilo WHERE pres_lineaid=" + idLinea.ToString
        Return operacion.EjecutaConsulta(cadena)

    End Function

    Public Function verRegistroLineaRapido(ByVal idsLineas As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                    " linea_lineaid," +
                                    " linea_descripcion," +
                                    " linea_activo" +
                                    " FROM Programacion.Lineas" +
                            " WHERE linea_activo = 1" +
                            " AND linea_lineaid NOT IN (" + idsLineas + ")"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verComboLineas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                    " linea_lineaid," +
                                    " linea_descripcion," +
                                    " linea_activo" +
                                    " FROM Programacion.Lineas" +
                            " WHERE linea_activo = 1 order by linea_descripcion "

        Return operacion.EjecutaConsulta(cadena)
    End Function
End Class
