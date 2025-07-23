Imports System.Data.SqlClient

Public Class ReporteAcumuladoSueldosSalariosDA
    Public Function consultarPatronEmpresaDA() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFReportes_Acumulado_ConsultarPatronEmpresa", listaParametros)
    End Function
    Public Function validarExistenciaDA(ByVal patronId As Int32, ByVal anio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFReportes_Acumulado_ValidarExistencia]", listaParametros)
    End Function

    Public Function mostrarAcumuladoDA(ByVal patronId As Int32, ByVal periodoDel As Int32, ByVal periodoAl As Int32, ByVal anio As Int32, ByVal nombre As String, ByVal colaboradorIds As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametro As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronid"
        parametro.Value = patronId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periododel"
        parametro.Value = periodoDel
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periodoal"
        parametro.Value = periodoAl
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@nombre"
        parametro.Value = nombre
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorIds"
        parametro.Value = colaboradorIds
        listaParametro.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[Contabilidad].[SP_NFReportes_Acumulado_SueldosSalarios]", listaParametro)
    End Function
    Public Function guardarCalculoDA(ByVal patronId As Int32, ByVal periodoDel As Int32, ByVal periodoAl As Int32, ByVal anio As Int32, ByVal nombre As String, ByVal colaboradorIds As String, ByVal accion As Int32) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametro As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronid"
        parametro.Value = patronId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periododel"
        parametro.Value = periodoDel
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periodoal"
        parametro.Value = periodoAl
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@nombre"
        parametro.Value = nombre
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorIds"
        parametro.Value = colaboradorIds
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@accion"
        parametro.Value = accion
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametro.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[Contabilidad].[SP_NFReportes_Acumulado_SueldosSalarios_Calcular]", listaParametro)
    End Function

    Public Function consultarDatosPatronDA(ByVal patronId As Int32, ByVal periodoDel As Int32, ByVal periodoAl As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametro As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronid"
        parametro.Value = patronId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periododel"
        parametro.Value = periodoDel
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periodoal"
        parametro.Value = periodoAl
        listaParametro.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[Contabilidad].[SP_NFReportes_Acumulado_Impresion]", listaParametro)
    End Function




    Public Function consultarCalculoDA(ByVal patronId As Int32, ByVal anio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFReportes_Acumulado_ConsultarCalculo]", listaParametros)
    End Function

    Public Function actualizarCalculoDA(ByVal patronId As Int32, ByVal anio As Int32, ByVal colaboradorid As Integer, ByVal exentocargado As String, ByVal gravadocargado As String, ByVal isrcargado As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametro As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronid"
        parametro.Value = patronId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametro.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@rfc"
        'parametro.Value = rfc
        'listaParametro.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@clave"
        'parametro.Value = clave
        'listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colaboradorid"
        parametro.Value = colaboradorid
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@exentocargado"
        parametro.Value = exentocargado
        listaParametro.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@gravadocargado"
        parametro.Value = gravadocargado
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@isrcargado"
        parametro.Value = isrcargado
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametro.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[Contabilidad].[SP_NFReportes_Acumulado_SueldosSalarios_Actualizar]", listaParametro)
    End Function

    Public Function autorizarCalculoDA(ByVal patronId As Int32, ByVal anio As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametro As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronid"
        parametro.Value = patronId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametro.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[Contabilidad].[SP_NFReportes_Acumulado_SueldosSalarios_Autorizar]", listaParametro)
    End Function
End Class
