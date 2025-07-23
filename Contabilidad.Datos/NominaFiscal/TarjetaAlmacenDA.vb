Imports System.Data.SqlClient

Public Class TarjetaAlmacenDA

    ''Empresas consultaEmpresas
    Public Function consultaEmpresas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_TarjetaAlmacen_ConsultarEmpresas", listaParametros)
    End Function

    ''Anios
    Public Function obtenerAniosEmpresa(ByVal empresaId As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "empresaId"
        parametro.Value = empresaId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_TarjetaAlmacen_ObtenerAniosEmpresa", listaParametros)
    End Function

    Public Function obtenerProductosEmpresa(ByVal empresaId As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "empresaId"
        parametro.Value = empresaId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_TarjetaAlmacen_ObtenerProductosEmpresa", listaParametros)
    End Function

    Public Function obtenerTarjetaAlmacen(ByVal empresaId As Integer, ByVal anio As Integer, ByVal mesIni As Integer, ByVal mesFin As Integer, ByVal productoId As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "EmpresaId"
        parametro.Value = empresaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MesIni"
        parametro.Value = mesIni
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MesFin"
        parametro.Value = mesFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProductoId"
        parametro.Value = productoId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_TarjetaAlmacen_ConsultarTarjetaAlmacen", listaParametros)
    End Function

    Public Function obtenerInventario(ByVal empresaId As Integer, ByVal anio As Integer, ByVal mesIni As Integer, ByVal mesFin As Integer, ByVal productoId As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "EmpresaId"
        parametro.Value = empresaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MesIni"
        parametro.Value = mesIni
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MesFin"
        parametro.Value = mesFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProductoId"
        parametro.Value = productoId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_TarjetaAlmacen_ConsultarInventario", listaParametros)
    End Function

    Public Function consultaConfigPrecioVenta() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_TarjetaAlmacen_ConsultarConfigPrecioVenta]", listaParametros)
    End Function

    Public Function actualizarConfigPrecioVenta(ByVal configuracionId As Integer, ByVal limiteInferior As Double, ByVal limiteSuperior As Double) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@ConfiguracionId"
        parametro.Value = configuracionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@LimiteInferior"
        parametro.Value = limiteInferior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@LimiteSuperior"
        parametro.Value = limiteSuperior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_TarjetaAlmacen_ModificarConfigPrecioVenta]", listaParametros)
    End Function

    Public Function ListadoParametrosReportes(tipo_busqueda As Integer, idUsuario As Integer, empresaId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EmpresaId"
        parametro.Value = empresaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoBusqueda"
        parametro.Value = tipo_busqueda
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_TarjetaAlmacen_Filtros]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function validarPorcentajePrecioVenta(ByVal tarjetaId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@TarjetaId"
        parametro.Value = tarjetaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_TarjetaAlmacen_ValidarPorcentajeCostoVenta]", listaParametros)
    End Function

    Public Function obtenerConfigPorcentaje(ByVal empresaId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@empresaId"
        parametro.Value = empresaId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_TarjetaAlmacen_ObtenerConfiguracionPorcentaje]", listaParametros)
    End Function

End Class
