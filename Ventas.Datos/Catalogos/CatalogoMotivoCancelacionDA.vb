Imports System.Data.SqlClient

Public Class CatalogoMotivoCancelacionDA



    Public Function ListaMotivosCancelacion(ByVal Activo As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Activo"
        parametro.Value = Activo
        listaparametros.Add(parametro)
        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_AdministracionPedidos_MotivosCancelacion]", listaparametros)
    End Function



    ''' <summary>
    ''' Inserta un nuevo motivo de cancelación
    ''' </summary>
    ''' <param name="objMotivoCancelacion">Tiene la informacion del motivo de la Cancelacion</param>    
    ''' <remarks></remarks>
    Public Function AltaMotivoCancelacion(ByVal objMotivoCancelacion As Entidades.CatalogoMotivoCancelacion)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "NombreMotivoCancelacion"
        parametro.Value = objMotivoCancelacion.Nombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DescripcionMotivoCancelacion"
        parametro.Value = objMotivoCancelacion.Descripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioCreoID"
        parametro.Value = objMotivoCancelacion.UsuarioCreoID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = objMotivoCancelacion.Activo.ToString()
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_MotivoCancelacion]", listaparametros)

    End Function

    ''' <summary>
    ''' Edita la informacion de un un motivo de cancelación
    ''' </summary>
    ''' <param name="objMotivoCancelacion"></param>
    ''' <remarks></remarks>
    Public Sub EditarMotivoCancelacion(ByVal objMotivoCancelacion As Entidades.CatalogoMotivoCancelacion)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        ''id
        Dim parametro As New SqlParameter
        parametro.ParameterName = "motivocancelacionid"
        parametro.Value = objMotivoCancelacion.MotivoCancelacionID
        listaparametros.Add(parametro)
        ''NOMBRE
        parametro = New SqlParameter
        parametro.ParameterName = "motivo"
        parametro.Value = objMotivoCancelacion.Nombre.Trim()
        listaparametros.Add(parametro)
        ''DESCRIPCION
        parametro = New SqlParameter
        parametro.ParameterName = "descripcion"
        parametro.Value = objMotivoCancelacion.Descripcion.Trim()
        listaparametros.Add(parametro)
        ''ESTATUS
        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = objMotivoCancelacion.Activo.ToString()
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModificoID"
        parametro.Value = objMotivoCancelacion.UsuarioModificoID
        listaparametros.Add(parametro)

        operaciones.EjecutarConsultaSP("[Ventas].[SP_EditarMotivoCancelacion]", listaparametros)

    End Sub

End Class
