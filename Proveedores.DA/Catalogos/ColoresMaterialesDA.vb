Imports Persistencia
Imports System.Data.SqlClient

Public Class ColoresMaterialesDa

    Public Function getColoresMateriales(ByVal id As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select mcol_idcolor 'ID',mcol_color 'Color',CASE WHEN LTRIM(mcol_sku) = ''THEN mcol_skuSistema ELSE LTRIM(mcol_sku)
            END AS 'SKU',mcol_status 'Activo',mcol_skuSistema 'skuSistema' from Materiales.MaterialesColores   order by mcol_color ASC 
            </cadena>
        If id > 0 Then
            consulta += " where mcol_idcolor=" & id
        End If
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getColoresMaterialesultimoid(ByVal id As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select mcol_idcolor 'ID',mcol_color 'Color',CASE WHEN LTRIM(mcol_sku) = ''THEN mcol_skuSistema ELSE LTRIM(mcol_sku)
            END AS 'SKU',mcol_status 'Activo',mcol_skuSistema 'skuSistema' from Materiales.MaterialesColores 
            </cadena>
        If id > 0 Then
            consulta += " where mcol_idcolor=" & id
        End If
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function idColorInsertado() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT TOP 1 mcol_idcolor FROM Materiales.MaterialesColores ORDER BY mcol_idcolor DESC "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ColoresRepetidos(ByVal color As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        Dim separators() As String = {",", ".", "!", "?", ";", ":", "#", "-", "/", "\", " Y ", " DE ", " "}
        Dim words() As String = color.Split(separators, StringSplitOptions.RemoveEmptyEntries)

        consulta = "SELECT mcol_color 'Color' FROM Materiales.MaterialesColores where mcol_color like '%" + color + "%'"
        For Each word In words
            If word.Length >= 3 Then
                consulta += " or mcol_color like '" & word.Substring(0, 3) & "%'"
            End If
        Next
        consulta += ""
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function TamanosRepetidos(ByVal tamano As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        Dim separators() As String = {",", "!", "?", ";", ":", "-", "/", "\", " Y ", " DE "}
        Dim words() As String = tamano.Split(separators, StringSplitOptions.RemoveEmptyEntries)

        consulta = "SELECT tama_nombre 'Tamaño' FROM Materiales.Tamano where  tama_nombre = '%" + tamano + "%'"
        For Each word In words
            If word.Length > 1 Then
                consulta += " or tama_nombre like '" & word.Substring(0, 2) & "%'"
            End If
        Next
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ClasificacionRepetida(ByVal clasificacion As String, ByVal CategoriaID As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Clasificacion", clasificacion)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@CategoriaID", CategoriaID)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Compras].[SP_Consulta_ClasificacionRepetida]", listaParametros)

        'Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String
        'consulta = "select clas_nombreclas 'nombreClas' from Materiales.Clasificaciones where clas_nombreclas like '%" + clasificacion + "%'"
        'Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function updateColoresMateriales(ByVal idColor As Integer, ByVal color As String, ByVal sku As String, ByVal status As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim usuariomodifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        Dim consulta As String =
            <cadena>
            update Materiales.MaterialesColores set mcol_color=
            </cadena>
        consulta += " '" & color & "' , mcol_sku='" & sku & "',mcol_status=" & status & ", mcol_usuariomodificoid=" & usuariomodifico & ", mcol_fechamodificacion='" & fechamodificacion & "' where mcol_idcolor=" & idColor & ""
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function insertColoresMateriales(ByVal color As String, ByVal sku As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim obj As New Tools.Combinaciones
        Dim datos As New DataTable
        Dim skuSistema As String = ""
        Dim usuariocreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
        Dim usuariomodifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        datos = getColoresMaterialesultimoid(0)
        If datos.Rows.Count > 0 Then
            skuSistema = datos.Rows(datos.Rows.Count - 1).Item(4).ToString
            skuSistema = obj.getNextNumeroAlfaNumerico(skuSistema)
        Else
            skuSistema = "00"
        End If
        Dim consulta As String =
            <cadena>
            insert into Materiales.MaterialesColores(mcol_color,mcol_sku,mcol_skuSistema,mcol_status,mcol_usuariocreoid,mcol_fechacreacion,mcol_usuariomodificoid,mcol_fechamodificacion)
            </cadena>
        consulta += " values('" & color & "','" & sku & "','" & skuSistema & "',1," & usuariocreo & ",'" & fechacreacion & "'," & usuariomodifico & ",'" & fechamodificacion & "')"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub insertColoresMaterialesClasificacion(ByVal AltaCategoriaClasificacion As Entidades.ClasificacionColores)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@clco_idclasificacion"
        parametro.Value = AltaCategoriaClasificacion.clco_idclasificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clco_idcolor"
        parametro.Value = AltaCategoriaClasificacion.clco_idcolor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clco_usuariocreoid"
        parametro.Value = AltaCategoriaClasificacion.clco_usuariocreoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clco_fechacreacion"
        parametro.Value = AltaCategoriaClasificacion.clco_fechacreacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clco_usuariomodificoid"
        parametro.Value = AltaCategoriaClasificacion.clco_usuariomodificoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clco_fechamodificacion"
        parametro.Value = AltaCategoriaClasificacion.clco_fechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clco_estatus"
        parametro.Value = AltaCategoriaClasificacion.clco_estatus
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Materiales.SP_ClasificacionesColores", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    Public Sub ActualizarColorClasificacion(ByVal ActualizarColorClasificacion As Entidades.ClasificacionColores)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@clco_clasificacioncoloresid"
        parametro.Value = ActualizarColorClasificacion.clco_clasificacioncoloresid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clco_usuariomodificoid"
        parametro.Value = ActualizarColorClasificacion.clco_usuariomodificoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clco_fechamodificacion"
        parametro.Value = ActualizarColorClasificacion.clco_fechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clco_estatus"
        parametro.Value = ActualizarColorClasificacion.clco_estatus
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Materiales.SP_ActualizarColorClasificacion", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    Public Function ActualizarColorClasificaciones(ByVal estatus As Integer, ByVal idclas As Integer, ByVal usumod As Integer,
                                              ByVal clasificaciontamid As Integer, ByVal fecha As Date, ByVal idcolor As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = ""

        consulta += "update Materiales.ClasificacionColores"
        consulta += "  set"
        consulta += "  clco_estatus=" + estatus.ToString
        consulta += " , clco_usuariomodificoid=" + usumod.ToString
        consulta += " , clco_fechamodificacion='" + fecha.ToString + "'"
        consulta += "  where clco_idclasificacion=" + idclas.ToString + "and clco_idcolor=" + idcolor.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function
End Class
