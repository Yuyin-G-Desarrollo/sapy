Imports System.Data.SqlClient
Imports Persistencia
Public Class ConciliacionContraSUADA
    Dim objPersistencia As New Persistencia.OperacionesProcedimientos

    Public Function listaBimestre() As DataTable
        Return objPersistencia.EjecutaConsulta("Contabilidad.SP_NFCreditoInfonavit_ListarBimestre")
    End Function

    Public Function obtenerReporteAcumulado(ByVal patronid As Integer, ByVal anio As Integer, ByVal colaboradorIds As String, ByVal nombre As String) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@patronid", patronid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@anio", anio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@colaboradorIds", colaboradorIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@nombre", nombre)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_ConsultaConciliacionSuaAcumulado", listaParametros)

    End Function

    Public Function obtenerReporteBimestre(ByVal patronid As Integer, ByVal anio As Integer, ByVal bimestre As Integer, ByVal colaboradorIds As String, ByVal nombre As String) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@patronid", patronid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@anio", anio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@bimestre", bimestre)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuario", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@colaboradorIds", colaboradorIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@nombre", nombre)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_ConsultaConciliacionSuaBimestre", listaParametros)

    End Function

    Public Function obtenerColumnasEncabezadosReporte(ByVal tiporeporte As String) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@tiporeporte", tiporeporte)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_ObtenerEncabezadosReportesConciliacionSua", listaParametros)

    End Function

    Public Function importarLayoutSUA(ByVal strXML As String, ByVal patronid As Integer, ByVal anio As Integer, ByVal bimestre As Integer) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@XMLCeldas", strXML)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@patronid", patronid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@anio", anio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@bimestre", bimestre)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuario", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_NFCreditoInfonavit_ImportarLayoutConciliacionSUA]", listaParametros)
    End Function

    Public Function actualizaDatosConciliacionSUABimestre(ByVal strXML As String) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@XMLCeldas", strXML)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuario", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_NFCreditoInfonavit_ActualizarDatosConciliacionSUA]", listaParametros)
    End Function

    Public Function actualizaInformacionAcumulado(ByVal strXML As String) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@XMLCeldas", strXML)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuario", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_NFCreditoInfonavit_InsertarActualizarDatosAcumuladoConciliacionSUA]", listaParametros)
    End Function

    Public Function validaEstatusAutorizado(ByVal patronid As Integer, ByVal anio As Integer, ByVal bimestre As Integer) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@patronid", patronid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@anio", anio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@bimestre", bimestre)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_NFCreditoInfonavit_ValidaEstatusConciliacionSUA]", listaParametros)
    End Function

    Public Function autorizarBimestre(ByVal patronid As Integer, ByVal anio As Integer, ByVal bimestre As Integer) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@patronid", patronid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@anio", anio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@bimestre", bimestre)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuario", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_NFCreditoInfonavit_AutorizaConciliacionSua]", listaParametros)
    End Function

    Public Function obtenerEncabezadosReporteImprimr(ByVal patronid As Integer, ByVal bimestre As Integer, ByVal anio As Integer, ByVal reporte As Char) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@patronid", patronid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@bimestre", bimestre)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@anio", anio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@reporte", reporte)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_ObtenerEncabezadosReportesConciliacionSuaImpresion", listaParametros)
    End Function


End Class
