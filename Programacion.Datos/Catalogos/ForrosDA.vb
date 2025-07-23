Imports System.Data.SqlClient
Public Class ForrosDA

    Public Function VerListaForros(ByVal descripcion As String, ByVal codigo As String, ByVal activo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select forr_forroid, forr_codigo, forr_descripcion, forr_activo from Programacion.Forros where forr_descripcion like '%" + descripcion + "%' and forr_activo='" + activo.ToString + "'"
        If (codigo <> "") Then
            cadena += " and forr_codigo like '%" + codigo + "%'"
        End If

        cadena += " ORDER BY forr_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function VerIdMaximoForros() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select max(forr_forroid) as 'idMax' from Programacion.Forros")
    End Function

    Public Function verFilasForros() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select * from Programacion.Forros")
    End Function


    Public Sub RegistraForro(ByVal entidadForro As Entidades.Forros, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "codigo"
        ParametroParaLista.Value = entidadForro.ForroCodigo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = entidadForro.ForroDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = entidadForro.ForroActivo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Alta_Forro", ListaParametros)
    End Sub


    Public Sub EditarForro(ByVal EntidadForro As Entidades.Forros, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = EntidadForro.ForroDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = EntidadForro.ForroActivo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idForro"
        ParametroParaLista.Value = EntidadForro.ForroId
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_EditarForro", ListaParametros)

    End Sub

    Public Function verComboForros() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT forr_forroid, forr_codigo, forr_descripcion" +
                                " from Programacion.Forros" +
                                " where forr_activo =1 ORDER BY forr_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function validaExistenModelos(ByVal idForro As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT a.prod_codigo, a.prod_descripcion FROM Programacion.Productos a" +
                                " INNER JOIN Programacion.ProductoEstilo b ON a.prod_productoid = b.pres_productoid" +
                                " INNER JOIN Programacion.EstilosProducto c ON b.pres_estiloid = c.espr_estiloproductoid" +
                                " WHERE a.prod_activo = 1 AND b.pres_activo = 1" +
                                " AND c.espr_forroid = " + idForro +
                                " GROUP BY	a.prod_codigo, a.prod_descripcion "
        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Function verForrosRegistroRapido(ByVal idsForros As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " forr_forroid," +
                                " forr_codigo," +
                                " forr_descripcion" +
                                " FROM Programacion.Forros" +
                        " WHERE forr_activo = 'True'" +
                        " AND forr_forroid NOT IN (" + idsForros + ")"
        Return operacion.EjecutaConsulta(cadena)
    End Function


End Class
