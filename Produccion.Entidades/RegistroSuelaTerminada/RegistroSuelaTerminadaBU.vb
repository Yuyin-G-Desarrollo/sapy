Imports Entidades
Imports Produccion.Datos

Public Class RegistroSuelaTerminadaBU
    ReadOnly objSalidaLoteSuelaDA As New RegistroSuelaTerminadaDA

    Public Function IniciarSesion(ByVal ColaboradorID As Integer) As DataTable
        Return objSalidaLoteSuelaDA.IniciarSesion(ColaboradorID)
    End Function

    Public Function ValidarCodigoLoteSuela(ByVal Codigo As String, ByVal Tipo As String, ByVal ColaboradorID As Integer) As DataTable
        Return objSalidaLoteSuelaDA.ValidarCodigoLoteSuela(Codigo, Tipo, ColaboradorID)
    End Function

    Public Function ConsultarInformacionRegistroActivo() As DataTable
        Return objSalidaLoteSuelaDA.ConsultarInformacionRegistroActivo()
    End Function

    Public Function DescartarRegistro(ByVal RegistroID As Integer, ByVal ColaboradorID As Integer, ByVal Observaciones As String) As DataTable
        Return objSalidaLoteSuelaDA.DescartarRegistro(RegistroID, ColaboradorID, Observaciones)
    End Function

    Public Function FinalizarRegistro(ByVal RegistroID As Integer, ByVal ColaboradorID As Integer, ByVal Observaciones As String) As DataTable
        Return objSalidaLoteSuelaDA.FinalizarRegistro(RegistroID, ColaboradorID, Observaciones)
    End Function

    Public Function ConsultarCodigosErroneos(ByVal RegistroID As Integer) As DataTable
        Return objSalidaLoteSuelaDA.ConsultarCodigosErroneos(RegistroID)
    End Function

    Public Function Consultar(ByVal FechaInicio As String, ByVal FechaTermino As String) As DataTable
        Return objSalidaLoteSuelaDA.Consultar(FechaInicio, FechaTermino)
    End Function

    Public Function ConsultarDetalles(ByVal Folios As String)
        Return objSalidaLoteSuelaDA.ConsultarDetalles(Folios)
    End Function
    Public Function ConsultarReporteAvanceParesPorEntregar() As DataTable
        Return objSalidaLoteSuelaDA.ConsultarReporteAvanceParesPorEntregar()
    End Function

    Public Function ConsultarReporteAvancesProduccion() As DataTable
        Return objSalidaLoteSuelaDA.ConsultarReporteAvancesProduccion()
    End Function

    Public Function ConsultarReporteLotesPendientes() As DataTable
        Return objSalidaLoteSuelaDA.ConsultarReporteLotesPendientes()
    End Function

    Public Function ConsultarReporteAvancePorDia() As DataTable
        Return objSalidaLoteSuelaDA.ConsultarReporteAvancePorDia()
    End Function

    Public Function ConsultarReporteAvancesProduccionPespunte(NaveID As Integer, ConfiguracionID As Integer) As DataTable
        Return objSalidaLoteSuelaDA.ConsultarReporteAvancesProduccionPespunte(NaveID, ConfiguracionID)
    End Function

    Public Function ConsultarReporteAvancePorDiaPespunte(NaveID As Integer, ConfiguracionID As Integer) As DataTable
        Return objSalidaLoteSuelaDA.ConsultarReporteAvancePorDiaPespunte(NaveID, ConfiguracionID)
    End Function

    Public Function ConsultarReporteLotesPendientesPespunte(NaveID As Integer, ConfiguracionID As Integer) As DataTable
        Return objSalidaLoteSuelaDA.ConsultarReporteLotesPendientesPespunte(NaveID, ConfiguracionID)
    End Function

    Public Function ConsultarLotesPendientesDepartamentoNave(NaveID As Integer, DepartamentoID As Integer) As DataTable
        Return objSalidaLoteSuelaDA.ConsultarLotesPendientesDepartamentoNave(NaveID, DepartamentoID)
    End Function

    Public Sub ActualizarMotivoAtraso(LotesActualizar As String, UsuarioID As Integer)
        objSalidaLoteSuelaDA.ActualizarMotivoAtraso(LotesActualizar, UsuarioID)
    End Sub

    Public Function ConsultarNaves(UsuarioID As Integer) As DataTable
        Return objSalidaLoteSuelaDA.ConsultarNaves(UsuarioID)
    End Function

    Public Function ConsultarDepartamentosConfiguracionNave(NaveID As Integer) As DataTable
        Return objSalidaLoteSuelaDA.ConsultarDepartamentosConfiguracionNave(NaveID)
    End Function
End Class
