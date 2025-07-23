Imports Persistencia
Imports System.Data.SqlClient
Imports Entidades
Imports Tools

Public Class ClasificacionGiroDA

    Public Function ConsultaInformacionGiro(ByVal GiroID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "GiroID"
        parametro.Value = GiroID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ConsultaGiro]", listaParametros)
    End Function


    Public Function InsertarClasificacion(ByVal Clasificacion As String, ByVal Activo As Boolean, ByVal UsuarioCreoID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro = New SqlParameter
        parametro.ParameterName = "Clasificacion"
        parametro.Value = Clasificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = Activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreoID"
        parametro.Value = UsuarioCreoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_AltaClasificacion]", listaParametros)
    End Function

    Public Function EditarClasificacion(ByVal ClasificacionID As Integer, ByVal Clasificacion As String, ByVal Activo As Boolean, ByVal UsuarioModificoID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ClasificacionID"
        parametro.Value = ClasificacionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Clasificacion"
        parametro.Value = Clasificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = Activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModifico"
        parametro.Value = UsuarioModificoID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_EditarClasificacion]", listaParametros)
    End Function

    Public Function InsertarGiro(ByVal Giro As String, ByVal Activo As Boolean, ByVal UsuarioCreoID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "Giro"
        parametro.Value = Giro
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = Activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreoID"
        parametro.Value = UsuarioCreoID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_AltaGiro]", listaParametros)
    End Function

    Public Function EditarGiro(ByVal GiroID As Integer, ByVal Giro As String, ByVal Activo As Boolean, ByVal UsuarioCreoID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "GiroID"
        parametro.Value = GiroID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Giro"
        parametro.Value = Giro
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = Activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreoID"
        parametro.Value = UsuarioCreoID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_EditarGiro]", listaParametros)
    End Function

    Public Function ConsultaClasificaciones(ByVal Activo As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = Activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ColaboradorID", Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ConsultaClasificaciones]", listaParametros)
    End Function

    Public Function ConsultaGiros(ByVal Activo As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = Activo
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ConsultaGiros]", listaParametros)
    End Function

    Public Function ConsultaGiroClasificacion(ByVal ClasificacionId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ClasificacionID"
        parametro.Value = ClasificacionId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ConsultaGiroClasificacion]", listaParametros)
    End Function

    Public Function ConsultaInformacionClasificacion(ByVal ClasificacionId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ClasificacionID"
        parametro.Value = ClasificacionId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ConsultaClasificacion]", listaParametros)
    End Function


    Public Function BuscarClasificacion(ByVal Clasificacion As String, ByVal ClasificacionID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "Clasificacion"
        parametro.Value = Clasificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClasificacionID"
        parametro.Value = ClasificacionID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_BuscarClasificacion]", listaParametros)
    End Function

    Public Function BuscarGiro(ByVal Giro As String, ByVal GiroID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "Giro"
        parametro.Value = Giro
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "GiroID"
        parametro.Value = GiroID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_BuscarGiro]", listaParametros)
    End Function

    Public Function InsertarClasificacionGiro(ByVal ClasificacionID As Integer, ByVal GiroID As Integer, ByVal UsuarioCreoId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ClasificacionId"
        parametro.Value = ClasificacionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "GiroId"
        parametro.Value = GiroID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreoID"
        parametro.Value = UsuarioCreoId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_InsertarClasificacionGiro]", listaParametros)
    End Function

    Public Function DesactivarClasificacionGiro(ByVal ClasificacionID As Integer, ByVal GiroID As Integer, ByVal UsuarioCreoId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ClasificacionID"
        parametro.Value = ClasificacionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "GiroID"
        parametro.Value = GiroID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioCreoid"
        parametro.Value = UsuarioCreoId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_DesactivarClasificacionGiro]", listaParametros)
    End Function


End Class
