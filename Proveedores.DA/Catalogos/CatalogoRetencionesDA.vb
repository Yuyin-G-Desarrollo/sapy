Imports System.Data.SqlClient

Public Class CatalogoRetencionesDA

    Public Function InsertaEditaRetenciones(ByVal descripcion As String, ByVal base As String, ByVal porcentaje As Double, ByVal RetencionID As Integer, ByVal Activo As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Descripcion", descripcion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Base", base)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Porcentaje", porcentaje)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@RetencionID", RetencionID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Activo", Activo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioID", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_InsertaActualiza_Retenciones]", listaParametros)
    End Function

    Public Function ObtenerRetenciones(ByVal RetencionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@RetencionID", RetencionID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_Obtiene_Retenciones]", listaParametros)
    End Function

End Class
