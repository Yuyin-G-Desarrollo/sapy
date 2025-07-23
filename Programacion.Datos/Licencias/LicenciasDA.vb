Imports System.Data.SqlClient
Public Class LicenciasDA


    Public Function validarClaveLicencia(ByVal clave As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@clave", clave)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Licncias_ValidaExisteClave]", listaParametros)

    End Function

    Public Function validarNombreLicencia(ByVal Licencia As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@licencia", Licencia)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Licncias_ValidaExisteLicencia]", listaParametros)

    End Function

    Public Function validarCodigoSICYLicencia(ByVal codSICY As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@codSICY", codSICY)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Licncias_ValidaExisteCodigoSICY]", listaParametros)

    End Function

    Public Function GuardarAltaLicencia(ByVal nombreLicencia As String, ByVal codigo As String, ByVal activo As Integer, ByVal idUsuario As Integer, ByVal clave As String, ByVal comercializadora As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@nommbrelicencia", nombreLicencia)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@codigo", codigo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@activo", activo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@idusuario", idUsuario)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Clave", clave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@comercializadora", comercializadora)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_GuardarAltaLicencia]", listaParametros)
    End Function

    Public Function ConsultarMarcaLicenciaReedition(ByVal activo As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@activo", activo)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_licencias_ConsultarMarcaLicenciaReedition]", listaParametros)

    End Function

    Public Function validarNombreLicenciaEditar(ByVal Licencia As String, ByVal idmarca As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@licencia", Licencia)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@idmarca", idmarca)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Licncias_ValidaExisteAEditarLicencia]", listaParametros)

    End Function

    Public Function validarCodigoLicenciaEditar(ByVal codSICY As String, ByVal idmarca As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@codSICY", codSICY)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@idmarca", idmarca)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Licncias_ValidaExisteAEditarCodigo]", listaParametros)

    End Function


    Public Function GuardarEditarLicencia(ByVal marcaid As Integer, ByVal nombreLicencia As String, ByVal codigo As String, ByVal activo As Integer, ByVal idUsuaro As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@marcaid", marcaid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@nommbrelicencia", nombreLicencia)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@codigo", codigo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@activo", activo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@idUsiaro", idUsuaro)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_GuardarEditarLicencia]", listaParametros)
    End Function

    Public Function ObtenerIdCodigo()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ObtenerIdCodigoSICYLicencia]", New List(Of SqlParameter))
    End Function

End Class
