Imports System.Data.SqlClient

Public Class CatalogoCategoriaMotivoIncidenciaDA

    ''' <summary>
    ''' Obtiene las categorias de los motivos de incidencia
    ''' </summary>
    ''' <param name="Activo">TRUE: consulta las categorias activos, FALSE: Consulta las categorias inactivas</param>    
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaCategoriasMotivosIncidencias(ByVal Activo As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = Activo.ToString()
        listaparametros.Add(parametro)
        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_Categoria]", listaparametros)
    End Function


    ''' <summary>
    ''' Alta de la categoria
    ''' </summary>
    ''' <param name="objCategoria">Contiene la informacion de la categoria</param>
    ''' <remarks></remarks>
    Public Sub AltaCategoria(ByVal objCategoria As Entidades.CategoriaMotivoIncidencia)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim DtDatosProcedimiento As DataTable
        Dim CategoriaID As Integer = 0
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Categoria"
        parametro.Value = objCategoria.Categoria.Trim()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = objCategoria.Activo.ToString().Trim()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreoID"
        parametro.Value = objCategoria.UsuarioCreoID
        listaparametros.Add(parametro)

        DtDatosProcedimiento = operaciones.EjecutarConsultaSP("[Ventas].[SP_Prospecta_AltaCategoriaMotivoIncidencia]", listaparametros)


    End Sub

    'Public Sub ActualizarRelacionMotivosIncidenciaCategorias(ByVal CategoriaID As Integer, ByVal ListaMotivosActivos As String, ByVal UsuarioID As Integer)
    '    Dim operaciones As New Persistencia.OperacionesProcedimientos
    '    Dim listaparametros As New List(Of SqlParameter)

    '    Dim parametro As New SqlParameter
    '    parametro.ParameterName = "CategoriaID"
    '    parametro.Value = CategoriaID
    '    listaparametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "ListaMotivosCatg"
    '    parametro.Value = ListaMotivosActivos
    '    listaparametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "usuarioID"
    '    parametro.Value = UsuarioID
    '    listaparametros.Add(parametro)

    '    operaciones.EjecutarConsultaSP("[Ventas].[SP_Prospecta_RelacionCategoriaMotivoIncidencia]", listaparametros)

    'End Sub

    Public Sub EditarCategoria(ByVal objCategoria As Entidades.CategoriaMotivoIncidencia)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "CategoriaIncidenciaID"
        parametro.Value = objCategoria.CategoriaID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Categoria"
        parametro.Value = objCategoria.Categoria.Trim()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = objCategoria.Activo.ToString()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModificoID"
        parametro.Value = objCategoria.UsuarioNModificoID
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("[Ventas].[SP_Prospecta_EditarCategoriaMotivoIncidencia]", listaparametros)


    End Sub

End Class
