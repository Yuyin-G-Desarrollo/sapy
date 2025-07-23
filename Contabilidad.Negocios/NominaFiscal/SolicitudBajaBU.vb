Public Class SolicitudBajaBU


    Public Function ObtenerSolicitudBajaPorFiniquitoRealID(ByVal FiniquitoRealID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.SolicitudBajaDA
        Return objDA.ObtenerSolicitud(-1, -1, FiniquitoRealID, -1)
    End Function


    Public Function ConsultarSolicitudBajaExterno(ByVal ColaboradorID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.SolicitudBajaDA
        Return objDA.ConsultarSolicitudBajaExterno(ColaboradorID)
    End Function

    Public Function ConsultaEnvioCorreo(ByVal SolicitudBajaID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.SolicitudBajaDA
        Return objDA.ConsultaEnvioCorreo(SolicitudBajaID)
    End Function

    Public Function EditarSolicitudBaja(ByVal SolicitudBajaID As Integer, ByVal ColaboradorID As Integer, ByVal FechaBaja As Date, ByVal UsuarioCreoID As Integer, ByVal FechaCreacion As Date, ByVal Motivo As String) As DataTable
        Dim objDA As New Contabilidad.Datos.SolicitudBajaDA
        Return objDA.EditarSolicitudBaja(SolicitudBajaID, ColaboradorID, FechaBaja, UsuarioCreoID, FechaCreacion, Motivo)
    End Function

    Public Function GuardarSolicitudBaja(ByVal ColaboradorID As Integer, ByVal FechaBaja As Date, ByVal UsuarioCreoID As Integer, ByVal FechaCreacion As Date, ByVal Motivo As String, ByVal TipoCliente As String, ByVal FinquitoRealID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.SolicitudBajaDA
        Dim DTSoliciutdBaja As DataTable
        Dim SolicitudBajaID As Integer = -1
        Dim objFiniquitoBU As New Contabilidad.Negocios.FiniquitoFiscalBU
        Dim EntFinquitoFiscal As Entidades.FiniquitoFiscal

        DTSoliciutdBaja = objDA.GuardarSolicitudBaja(ColaboradorID, FechaBaja, UsuarioCreoID, FechaCreacion, Motivo, FinquitoRealID)
        SolicitudBajaID = DTSoliciutdBaja.Rows(0).Item("SolicitudBajaID")
        'Tipo cliente 1 => Externo, 0 Interno
        If TipoCliente = "INTERNO" Then
            If SolicitudBajaID > 0 Then
                EntFinquitoFiscal = objFiniquitoBU.CalcularFinquitoFiscal(ColaboradorID, FechaBaja, 0)
                EntFinquitoFiscal.SolicitudBajaID = SolicitudBajaID
                EntFinquitoFiscal.FechaCreacion = Date.Now
                EntFinquitoFiscal.UsuarioCreoID = UsuarioCreoID
                EntFinquitoFiscal.ColaboradorID = ColaboradorID
                objFiniquitoBU.GuardarFiniquitoFiscal(EntFinquitoFiscal)
            End If
        End If

        Return DTSoliciutdBaja

    End Function


    Public Function ConsultaSolicitudesBaja(ByVal NaveID As Integer, ByVal EmpresaId As Integer, ByVal EstatusSolicitudID As Integer, ByVal Nombre As String, ByVal EsFiltroFechaBaja As Boolean, ByVal EsFiltroRango As Boolean, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal PeriodoId As Integer, ByVal FiltroFechas As Boolean) As DataTable
        Dim objDA As New Contabilidad.Datos.SolicitudBajaDA
        Return objDA.ConsultaSolicitudesBaja(NaveID, EmpresaId, EstatusSolicitudID, Nombre, EsFiltroFechaBaja, EsFiltroRango, FechaInicio, FechaFin, PeriodoId, FiltroFechas)
    End Function

    Public Function ConsultaEstatusSolicitudBaja() As DataTable
        Dim objDA As New Contabilidad.Datos.SolicitudBajaDA
        Return objDA.ConsultaEstatusSolicitudBaja()
    End Function

    Public Function EditarEstatusSolicitud(ByVal SolicitudBajaID As Integer, ByVal EstatusID As Integer, ByVal UsuarioID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.SolicitudBajaDA
        Return objDA.EditarEstatusSolicitud(SolicitudBajaID, EstatusID, UsuarioID)
    End Function

    Public Function SolicitudAceptada(ByVal FinquitoRealID As Integer, ByVal UsuarioID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.SolicitudBajaDA
        Dim DTSolicitudBaja As DataTable
        Dim DTVacio As New DataTable
        Dim SolicitudBajaId As Integer = 0
        Dim ExisteSolicitudBaja As Boolean = True

        DTSolicitudBaja = ObtenerSolicitud(-1, -1, FinquitoRealID, -1)
        If DTSolicitudBaja.Rows.Count > 0 Then
            If IsDBNull(DTSolicitudBaja.Rows(0).Item("baim_bajaimssid")) = False Then
                If IsNothing(DTSolicitudBaja.Rows(0).Item("baim_bajaimssid")) = False Then
                    SolicitudBajaId = DTSolicitudBaja.Rows(0).Item("baim_bajaimssid")
                    Return objDA.EditarEstatusSolicitud(SolicitudBajaId, 106, UsuarioID)
                End If
            End If
            Return DTVacio
        End If


    End Function

    Public Function SolicitudCancelada(ByVal FinquitoRealID As Integer, ByVal UsuarioID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.SolicitudBajaDA
        Dim DTSolicitudBaja As DataTable
        Dim DTVacio As New DataTable
        Dim SolicitudBajaId As Integer = 0
        Dim ExisteSolicitudBaja As Boolean = True

        DTSolicitudBaja = ObtenerSolicitud(-1, -1, FinquitoRealID, -1)
        If IsDBNull(DTSolicitudBaja.Rows(0).Item("baim_bajaimssid")) = False Then
            If IsNothing(DTSolicitudBaja.Rows(0).Item("baim_bajaimssid")) = False Then
                SolicitudBajaId = DTSolicitudBaja.Rows(0).Item("baim_bajaimssid")
                Return objDA.EditarEstatusSolicitud(SolicitudBajaId, 107, UsuarioID)
            End If
        End If
        Return DTVacio

    End Function


    Public Function ObtenerSolicitud(ByVal ColaboradorID As Integer, ByVal SolicitudIMSS As Integer, ByVal FiniquitoRealId As Integer, ByVal FinquitoFiscalID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.SolicitudBajaDA
        Return objDA.ObtenerSolicitud(ColaboradorID, SolicitudIMSS, FiniquitoRealId, FinquitoFiscalID)
    End Function


    Public Function ObtenerInformacionDocumentoIDSE(ByVal ColaboradorId As Integer, ByVal FiniquitoFiscalID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.SolicitudBajaDA
        Return objDA.ObtenerInformacionDocumentoIDSE(ColaboradorId, FiniquitoFiscalID)
    End Function

    Public Function SolicitudBajaAceptada(ByVal BajaIMSS As Integer, ByVal ColaboradorID As Integer, ByVal Carpeta As String, ByVal Archivo As String, ByVal Movimiento As String, ByVal UsuarioID As Integer) As DataTable
        Dim objDA As New Contabilidad.Datos.SolicitudBajaDA
        Return objDA.SolicitudBajaAceptada(BajaIMSS, ColaboradorID, Carpeta, Archivo, Movimiento, UsuarioID)
    End Function

    Public Function SolicitudBajaRechazada(ByVal BajaIMSS As Integer, ByVal ColaboradorID As Integer, ByVal Carpeta As String, ByVal Archivo As String, ByVal Movimiento As String, ByVal UsuarioID As Integer, ByVal motivo As String) As DataTable
        Dim objDA As New Contabilidad.Datos.SolicitudBajaDA
        Return objDA.SolicitudBajaRechazada(BajaIMSS, ColaboradorID, Carpeta, Archivo, Movimiento, UsuarioID, motivo)
    End Function

    Public Function existePeriodoNominaBajas(ByVal colaboradorId As Int32, ByVal opcOperacion As Int32, ByVal fecha As Date) As Boolean
        Dim objDA As New Datos.SolicitudBajaDA
        Dim dtPeriodo As New DataTable
        Dim existe As Boolean = False
        dtPeriodo = objDA.existePeriodoNominaBajas(colaboradorId, opcOperacion, fecha)

        If Not dtPeriodo Is Nothing Then
            If dtPeriodo.Rows.Count > 0 Then
                existe = CBool(dtPeriodo.Rows(0)("Existe").ToString)
            End If
        End If

        Return existe
    End Function

    Public Function validaIncapacidadColaborador(ByVal idColaborador As Int32, ByVal fechaBaja As Date) As Int32
        Dim objDA As New Datos.SolicitudBajaDA
        Dim dtIncapacidad As New DataTable
        Dim existe As Boolean = False
        dtIncapacidad = objDA.validaIncapacidadColaborador(idColaborador, fechaBaja)

        If Not dtIncapacidad Is Nothing Then
            If dtIncapacidad.Rows.Count > 0 Then
                existe = CBool(dtIncapacidad.Rows(0)("existeIncapacidad").ToString)
            End If
        End If

        Return existe
    End Function

    Public Function validaTxtGenerado(ByVal solicitudId As Integer) As Boolean
        Dim objDA As New Datos.SolicitudBajaDA
        Dim dtResult As New DataTable
        Dim generado As Boolean = False
        dtResult = objDA.validaTxtGenerado(solicitudId)

        If Not dtResult Is Nothing Then
            If dtResult.Rows.Count > 0 Then
                generado = CBool(dtResult.Rows(0)("TxtGenerado").ToString)
            End If
        End If

        Return generado
    End Function
End Class
