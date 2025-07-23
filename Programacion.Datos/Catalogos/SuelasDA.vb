Imports System.Data.SqlClient
Public Class SuelasDA

    Public Function VerListaSuelas(ByVal descripcion As String, ByVal activo As String, ByVal codigo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT suel_suelaid, suel_codigo,suel_descripcion, suel_activo FROM Programacion.Suelas where suel_descripcion like '%" + descripcion + "%' and suel_activo='" + activo + "'"
        If (codigo <> "") Then
            cadena += " and suel_codigo like '%" + codigo + "%'"
        End If
        cadena += " ORDER BY suel_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function ContarFilas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select COUNT(*) from Programacion.Suelas")
    End Function

    Public Function VeridMaximoSuela() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select max(suel_suelaid) from Programacion.Suelas")
    End Function

    Public Sub RegistrarSuela(ByVal entidadSuela As Entidades.Suelas, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
    
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "codigo"
        ParametroParaLista.Value = entidadSuela.PCodigoSuela
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = entidadSuela.PDescriopcionSuela
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = entidadSuela.PActivoSuela
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Alta_Suela", ListaParametros)
    End Sub

    Public Function verCodigosDisponibles() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("SELECT suel_codigo from Programacion.Suelas  where suel_activo ='False' and suel_codigo not in (select suel_codigo  from Programacion.Suelas where suel_activo ='True')")
    End Function

    Public Sub editarSuela(ByVal entidadSuela As Entidades.Suelas, ByVal usuario As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "idsuela"
        ParametroParaLista.Value = entidadSuela.PIdSuela
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = entidadSuela.PDescriopcionSuela
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = entidadSuela.PActivoSuela
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Editar_Suelas", ListaParametros)
    End Sub

    Public Function validarRepetidos(ByVal codigo As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutaConsulta("SELECT COUNT(*) FROM Programacion.Suelas WHERE suel_activo ='TRUE' AND suel_codigo ='" + codigo + "'")
    End Function

    Public Function verComboSuelas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select suel_suelaid, suel_codigo, suel_descripcion from Programacion.Suelas" +
            " where suel_activo=1 ORDER BY suel_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function validaExistenModelos(ByVal idSuela As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT a.prod_codigo, a.prod_descripcion FROM Programacion.Productos a" +
                                " INNER JOIN Programacion.ProductoEstilo b ON a.prod_productoid = b.pres_productoid" +
                                " INNER JOIN Programacion.EstilosProducto c ON b.pres_estiloid = c.espr_estiloproductoid" +
                                " WHERE a.prod_activo = 1 AND b.pres_activo = 1" +
                                " AND c.espr_suelaid = " + idSuela +
                                " GROUP BY	a.prod_codigo, a.prod_descripcion" 
        Return operaciones.EjecutaConsulta(cadena)
    End Function


    Public Function verSuelasRegistradasRapido(ByVal idsSuelas As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " suel_suelaid," +
                                " suel_codigo," +
                                " suel_descripcion" +
                                " FROM Programacion.Suelas" +
                        " WHERE suel_activo = 'True'" +
                        " AND suel_suelaid NOT IN(" + idsSuelas + ")"
        Return operacion.EjecutaConsulta(cadena)
    End Function

End Class
