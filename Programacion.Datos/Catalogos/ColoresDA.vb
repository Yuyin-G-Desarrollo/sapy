Imports System.Data.SqlClient
Public Class ColoresDA

    Public Function VerListaColores(ByVal idColor As String, ByVal descripcion As String, ByVal activo As Boolean, ByVal codsicy As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String
        cadena = "SELECT color_colorid, color_descripcion, color_codsicy, color_activo FROM Programacion .Colores where color_activo='" + activo.ToString + "' and color_descripcion like '%" + descripcion + "%'"
        If (idColor <> "") Then
            cadena += " and color_colorid like '%" + idColor + "%'"
        End If
        If (codsicy <> "") Then
            cadena += " and color_codsicy like '%" + codsicy + "%'"
        End If
        cadena += " ORDER BY color_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function VerFilasColores() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("select color_colorid,color_descripcion,color_activo from Programacion.Colores")
    End Function

    Public Function VerIdMaximoColores() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("select MAX(color_colorid) from Programacion.Colores ")
    End Function

    Public Sub RegistrarColor(ByVal entidadColor As Entidades.Colores, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = entidadColor.PCDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = entidadColor.PCActivo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "codSicy"
        ParametroParaLista.Value = entidadColor.PCCodSicy
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Alta_Colores", ListaParametros)
    End Sub

    Public Sub Editarcolor(ByVal entidadColor As Entidades.Colores, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = entidadColor.PCDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = entidadColor.PCActivo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idColor"
        ParametroParaLista.Value = entidadColor.PColorId
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "codSicy"
        ParametroParaLista.Value = entidadColor.PCCodSicy
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_EditarColor", ListaParametros)
    End Sub

    Public Function VerComboColor() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("select color_colorid , color_descripcion  from Programacion.Colores  where color_activo ='True'")
    End Function

    Public Function VerColoresGridProducto() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("select color_colorid , color_descripcion, color_codsicy  from Programacion.Colores  where color_activo ='True'")
    End Function

    Public Function validaExistenModelos(ByVal idColor As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT a.prod_codigo, a.prod_descripcion FROM Programacion.Productos a" +
                                " INNER JOIN Programacion.ProductoEstilo b ON a.prod_productoid = b.pres_productoid" +
                                " INNER JOIN Programacion.EstilosProducto c ON b.pres_estiloid = c.espr_estiloproductoid" +
                                " WHERE a.prod_activo = 1 AND b.pres_activo = 1" +
                                " AND c.espr_colorid = " + idColor +
                                " GROUP BY	a.prod_codigo, a.prod_descripcion "
        Return operaciones.EjecutaConsulta(cadena)
    End Function

End Class
