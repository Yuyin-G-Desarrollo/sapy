Imports System.Data.SqlClient
Imports Persistencia
Public Class ControlAsistenciaFiscalDA
    Public Function consultarPeriodoNomina(ByVal patronId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFControlAsistencia_ConsultaPeriodoNomina", listaParametros)
    End Function

    Public Function obtenerPeriodoNominaActual(ByVal patronId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFControlAsistencia_ObtenerPeriodoNominaActual", listaParametros)
    End Function

    Public Function obtenerPoliticasPremios(ByVal periodoId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "periodoId"
        parametro.Value = periodoId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFControlAsistencia_ObtenerPoliticasPremios", listaParametros)
    End Function

    Public Function consultaTieneChecador(ByVal patronId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFControlAsistencia_ConsultaTieneChecador", listaParametros)
    End Function

    Public Function validadExistenChecadas(ByVal patronId As Integer, ByVal periodoId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "periodoId"
        parametro.Value = periodoId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFControlAsistencia_ValidaExistenChecadas", listaParametros)
    End Function

    Public Function consultaChecadasPeriodoNomina(ByVal patronId As Integer, ByVal periodoNominaId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "periodoNominaId"
        parametro.Value = periodoNominaId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFControlAsistencia_ConsultaChecadasPeriodoNomina", listaParametros)
    End Function

    Public Function consultaIncapacidadColaborador(ByVal colaboradorId As Integer, ByVal periodoNominaId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "periodoNominaId"
        parametro.Value = periodoNominaId
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "incapacidadId"
        'parametro.Value = incapacidadId
        'listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFControlAsistencia_ConsultaIncapacidadColaborador", listaParametros)
    End Function

    Public Function validaPeriodoGenerarChecadas(ByVal periodoNominaId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "periodoNominaId"
        parametro.Value = periodoNominaId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFControlAsistencia_ValidaPeriodoGenerarChecadas", listaParametros)
    End Function

    Public Function generaRegistrosChecadas(ByVal patronId As Integer, ByVal eliminar As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "eliminar"
        parametro.Value = eliminar
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFControlAsistencia_GenerarChecadas", listaParametros)
    End Function

    Public Function generaFaltaRegistro(ByVal registroId As Integer, ByVal colaboradorId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "registroId"
        parametro.Value = registroId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFControlAsistencia_GeneraFaltaRegistro", listaParametros)
    End Function

    Public Function generaRetardoRegistro(ByVal registroId As Integer, ByVal colaboradorId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "registroId"
        parametro.Value = registroId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFControlAsistencia_GeneraRetardoRegistro", listaParametros)
    End Function

    Public Function validaCierreChecador(ByVal periodoNominaId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "periodoNominaId"
        parametro.Value = periodoNominaId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFControlAsistencia_ValidaCierreChecador_NominaReal", listaParametros)
    End Function

    Public Function generaCorteChecadorFiscal(ByVal periodoId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "checador"
        'parametro.Value = False
        'listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "periodoId"
        parametro.Value = periodoId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFControlAsistencia_GeneraCorteChecadorFiscal", listaParametros)
    End Function

    Public Function obtenerPeriodoNominaFiscalPeriodo(ByVal periodoRealId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "periodoRealId"
        parametro.Value = periodoRealId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFControlAsistencia_ObtenerPeriodoNominaFiscalPeriodo", listaParametros)
    End Function

    Public Function consultaPatronNave(ByVal naveId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "naveId"
        parametro.Value = naveId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFControlAsistencia_ConsultaPatronNave_Activos", listaParametros)
    End Function

    Public Function consultaFechasVacaciones(ByVal patronId As Integer, ByVal periodoNominaId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "periodoNominaId"
        parametro.Value = periodoNominaId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFControlAsistencia_ConsultaFechasVacaciones", listaParametros)
    End Function

    Public Function consultaMovimientosPendientes(ByVal patronId As Integer, ByVal periodoFiscalId As Integer, ByVal NaveId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronid"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periodoId"
        parametro.Value = periodoFiscalId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = NaveId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFCierre_ValidaMovimientosAntesCierre_nominaReal", listaParametros)
    End Function
End Class