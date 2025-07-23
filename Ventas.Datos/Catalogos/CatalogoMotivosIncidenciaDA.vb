Imports System.Data.SqlClient

Public Class CatalogoMotivosIncidenciaDA


    
    Public Function ListaTiposMotivosIncidencias(ByVal Activo As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = Activo.ToString()
        listaparametros.Add(parametro)
        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Prospecta_Consulta_TiposMotivosIncidencia]", listaparametros)
    End Function


   



    ''' <summary>
    ''' Inserta un nuevo motivo de incidencia en una categoria
    ''' </summary>
    ''' <param name="objMotivoIncidencia">Tiene la informacion del motivo de la incidencia</param>    
    ''' <remarks></remarks>
    Public Sub AltaMotivoIncidencia(ByVal objMotivoIncidencia As Entidades.CatalogoMotivosIncidencias)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "MotivoIncidencia"
        parametro.Value = objMotivoIncidencia.Motivo.Trim()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CategoriaID"
        parametro.Value = objMotivoIncidencia.CategoriaID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreoID"
        parametro.Value = objMotivoIncidencia.UsuarioCreoID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = objMotivoIncidencia.Activo.ToString()
        listaparametros.Add(parametro)

        
        operaciones.EjecutarConsultaSP("[Ventas].[SP_Prospecta_AltaMotivoIncidencia]", listaparametros)

    End Sub

    ''' <summary>
    ''' Edita la informacion de un un motivo de incidencia
    ''' </summary>
    ''' <param name="objMotivoIncidencia">Contiene la informacion del motivo de incidencia</param>
    ''' <remarks></remarks>
    Public Sub EditarMotivoIncidencia(ByVal objMotivoIncidencia As Entidades.CatalogoMotivosIncidencias)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "motivoincidenciaid"
        parametro.Value = objMotivoIncidencia.MotivoIncidenciaID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Motivo"
        parametro.Value = objMotivoIncidencia.Motivo.Trim()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CategoriaID"
        parametro.Value = objMotivoIncidencia.CategoriaID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = objMotivoIncidencia.Activo.ToString()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModificoID"
        parametro.Value = objMotivoIncidencia.UsuarioModificoID
        listaparametros.Add(parametro)

        operaciones.EjecutarConsultaSP("[Ventas].[SP_Prospecta_EditarMotivoIncidencia]", listaparametros)

    End Sub

   



End Class
