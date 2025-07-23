Imports System.Data.SqlClient

Public Class AdministracionKioskoDA

    Public Function InsertarImportacionModelos(ByVal archivo As String, ByVal dtModelos As DataTable) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Archivo", archivo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Modelos", dtModelos)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioGeneroID", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ModuloInformacionCITY_InsertarImportacionModelos]", listaParametros)
    End Function

    Public Function ConsultarModelosImportadosVigentes() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ModuloInformacionCITY_ConsultarModelosImportadosVigentes]", listaParametros)
    End Function

    Public Function InsertarConfiguracionesKioskoCITY(ByVal rutaFotografiaPrincipal As String,
                                                      ByVal rutaFotografiaExterna As String,
                                                      ByVal rutaFotografiaInterna As String,
                                                      ByVal rutaFichaTecnica As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@UsuarioGeneroID", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@RutaFotografiaPrincipal", rutaFotografiaPrincipal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@RutaFotografiaExterna", rutaFotografiaExterna)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@RutaFotografiaInterna", rutaFotografiaInterna)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@RutaFichaTecnica", rutaFichaTecnica)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ModuloInformacionCITY_InsertarConfiguracionesKioskoCITY]", listaParametros)
    End Function

    Public Function ConsultarConfiguracionesKioskoCITY() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ModuloInformacionCITY_ConsultarConfiguracionesKioskoCITY]", listaParametros)
    End Function

    Public Function ConsultarModelos(ByVal tipoBusqueda As String, ByVal busqueda As String, ByVal busqueda2 As String, ByVal busqueda3 As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@TipoBusqueda", tipoBusqueda)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Busqueda", busqueda)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Busqueda2", busqueda2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Busqueda3", busqueda3)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ModuloInformacionCITY_ConsultarModelos]", listaParametros)
    End Function
End Class
