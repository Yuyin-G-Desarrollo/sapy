Imports System.Data.SqlClient

Public Class CategoriasMaterialesDA
    Public Function getCategorias(ByVal idCategoria As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@CategoriaID", idCategoria)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_Obtiene_CategoriasMateriales]", listaParametros)

        'Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '    <cadena>
        '    select cate_idCategoria 'Código',cate_nombre 'Categoría',cate_status 'Activo' from Materiales.Categorias 
        '    </cadena>
        'If idCategoria > 0 Then
        '    consulta += " where cate_idCategoria =" & idCategoria
        'End If
        'consulta += " order by cate_nombre asc"
        'Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function updateCategorias(ByVal idCategoria As Integer, ByVal nombre As String, ByVal status As String, ByVal Giro As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@CategoriaID", idCategoria)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Categoria", nombre)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Status", status)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Giro", Giro)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioModifica", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_Actualiza_CategoriasMateriales]", listaParametros)


        'Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '    <cadena>
        '    update Materiales.Categorias set cate_nombre=
        '    </cadena>
        'consulta += "'" & nombre & "', cate_status='" & status & "'  where cate_idCategoria =" & idCategoria
        'Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function insertCategorias(ByVal categoria As String, ByVal Giro As Integer, ByVal UsuarioCreoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Categoria", categoria)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Giro", Giro)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioCreoID", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_Inserta_CategoriasParaMateriales]", listaParametros)

        'Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String =
        '    <cadena>
        '    insert into Materiales.Categorias(cate_nombre,cate_status)
        '    </cadena>
        'consulta += " values('" & categoria & "',1)"
        'Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function verificarCategoria(ByVal des As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
            select cate_idCategoria 'Código',cate_nombre 'Categoría',cate_status 'Activo' from Materiales.Categorias 
            </cadena>
        consulta += " where cate_nombre like '" & des & "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function ObtieneGiroDeNave() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_Obtiene_GirosParaMateriales]", listaParametros)

    End Function

End Class
