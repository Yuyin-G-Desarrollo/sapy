Public Class SolicitarCancelacionBU
    Public Function ConsultarMotivosInternos(ByVal Optional motivoid As Integer = 0) As DataTable
        Dim obDA As New Datos.SolicitarCancelacionDA
        Return obDA.ConsultarMotivosInternos(motivoid)
    End Function

    Public Function ConsultarMotivosInternoEditar(motivoid As Integer) As DataTable
        Dim obDA As New Datos.SolicitarCancelacionDA
        Return obDA.ConsultarMotivosInternoEditar(motivoid)
    End Function

    Public Function ConsultarTodosMotivosCancelacion(activo As Boolean) As DataTable
        Dim obDA As New Datos.SolicitarCancelacionDA
        Return obDA.ConsultarTodosMotivosCancelacion(activo)
    End Function

    Public Function ConsultarColaboradores() As DataTable
        Dim obDA As New Datos.SolicitarCancelacionDA
        Return obDA.ConsultarColaboradores()
    End Function
    Public Function ConsultarSolicitudesPendientes(documentoid As Integer) As DataTable
        Dim obDA As New Datos.SolicitarCancelacionDA
        Return obDA.ConsultarSolicitudesPendientes(documentoid)
    End Function
    Public Function InsertarSolicitudCancelacionFactura(ByVal documentoId As Integer,
                                                        ByVal metodoPago As String,
                                                        ByVal razonsocialemisorid As Integer,
                                                        ByVal razonsocialreceptorid As Integer,
                                                        ByVal quienSolicita As Boolean,
                                                        ByVal facturaRequiereSustitucion As Boolean,
                                                        ByVal facturaMismoEmisorReceptor As Boolean,
                                                        ByVal motivoInternoid As Integer,
                                                        ByVal seRelaciona As Boolean,
                                                        ByVal observacion As String,
                                                        Optional nombreSolicita As String = "",
                                                        Optional solicitaColaboradorId As String = "") As DataTable

        Dim obDA As New Datos.SolicitarCancelacionDA

        Return obDA.InsertarSolicitudCancelacionFactura(documentoId, metodoPago, razonsocialemisorid, razonsocialreceptorid, quienSolicita, facturaRequiereSustitucion, facturaMismoEmisorReceptor, motivoInternoid, seRelaciona, observacion, nombreSolicita, solicitaColaboradorId)

    End Function

    Public Function ConsultarSolicitudesCancelacionFactura(ByVal filtros As Entidades.FiltrosAdministradorSoliciturCancelacion) As DataTable
        Dim objDA As New Ventas.Datos.SolicitarCancelacionDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarSolicitudesCancelacionFactura(filtros)
        Return tabla
    End Function

    Public Function ConsultarDeclaracionesAnteriores(ByVal documento As Integer) As DataTable
        Dim objDA As New Ventas.Datos.SolicitarCancelacionDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarDeclaracionesAnteriores(documento)
        Return tabla
    End Function

    Public Function ConsultarMotivosSAT(Optional motimoid As Integer = 0) As DataTable
        Dim obDA As New Datos.SolicitarCancelacionDA
        Return obDA.ConsultarMotivosSat(motimoid) ''ConsultarMotivosSAT
    End Function

    Public Function InsertarMotivoCancelacion(ByVal motivo As String,
                                              ByVal seRelaciona As Boolean,
                                              ByVal motivoSat As Integer,
                                              ByVal activo As Boolean) As DataTable

        Dim obDA As New Datos.SolicitarCancelacionDA

        Return obDA.InsertarMotivoCancelacion(motivo, seRelaciona, motivoSat, activo)

    End Function

    Public Function EditarMotivoCancelacion(ByVal motivo As String,
                                              ByVal seRelaciona As Boolean,
                                              ByVal motivoSat As Integer,
                                              ByVal activo As Boolean,
                                              ByVal motivoInterno As Integer) As DataTable

        Dim obDA As New Datos.SolicitarCancelacionDA

        Return obDA.EditarMotivoCancelacion(motivo, seRelaciona, motivoSat, activo, motivoInterno)
    End Function

    Public Function AutorizarSolicitudCancelacion(ByVal solicitudID As Integer,
                                                  ByVal Observaciones As String) As DataTable
        Dim obDA As New Datos.SolicitarCancelacionDA
        Return obDA.AutorizarSolicitudCancelacion(solicitudID, Observaciones)
    End Function

    Public Function RechazarSolicitudCancelacion(ByVal solicitudID As Integer,
                                                  ByVal Observaciones As String) As DataTable
        Dim obDA As New Datos.SolicitarCancelacionDA
        Return obDA.RechazarSolicitudCancelacion(solicitudID, Observaciones)
    End Function



    Public Function ConsultarDeclaraciones(ByVal empresa As String, ByVal anio As Integer) As DataTable
        Dim objDA As New Ventas.Datos.SolicitarCancelacionDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarDeclaraciones(empresa, anio)
        Return tabla
    End Function

    Public Function ConsultarEmpresas() As DataTable
        Dim objDA As New Ventas.Datos.SolicitarCancelacionDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarEmpresas()
        Return tabla
    End Function

    Public Function InsertarDeclaracionComplementaria(ByVal empresa As Integer, ByVal mes As String,
                                                ByVal fecha As String
                                               ) As DataTable
        Dim objDA As New Ventas.Datos.SolicitarCancelacionDA
        Dim tabla As New DataTable
        tabla = objDA.InsertarDeclaracionComplementaria(empresa, mes, fecha)
        Return tabla
    End Function

    Public Function ConsultarDeclaracionesPorMes(ByVal mes As String, ByVal empresaid As Integer) As DataTable
        Dim objDA As New Ventas.Datos.SolicitarCancelacionDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarDeclaracionesPorMes(mes, empresaid)
        Return tabla
    End Function

    Public Function ConsultarEstatusSolicitud(ByVal solicitudid As Integer) As DataTable
        Dim objDA As New Ventas.Datos.SolicitarCancelacionDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarEstatusSolicitud(solicitudid)
        Return tabla
    End Function

    Public Function ActualizarEstatusSolicitud(ByVal Documento As Integer, ByVal Status As Integer) As DataTable
        Dim objDA As New Ventas.Datos.SolicitarCancelacionDA
        Dim tabla As New DataTable
        tabla = objDA.ActualizarEstatusSolicitud(Documento, Status)
        Return tabla
    End Function

    Public Function InsertarCancelacion(ByVal DocumentoCancelar As Entidades.CancelacionDocumento) As DataTable
        Dim objDA As New Ventas.Datos.SolicitarCancelacionDA
        Dim tabla As New DataTable
        tabla = objDA.InsertaCancelacion(DocumentoCancelar)
        Return tabla
    End Function

    Public Function ConsultarSolcitud(ByVal documentoId As Integer) As DataTable
        Dim dtRespuesta As New DataTable
        Dim objSolicitud As New Ventas.Datos.SolicitarCancelacionDA
        dtRespuesta = objSolicitud.ConsultarSolcitud(documentoId)
        Return dtRespuesta
    End Function

    Public Function ActualizarDocumentoARechazadoCliente(ByVal documentoId As Integer) As DataTable
        Dim dtRespuesta As New DataTable
        Dim objSolicitud As New Ventas.Datos.SolicitarCancelacionDA
        dtRespuesta = objSolicitud.ActualizarDocumentoRechazadoCliente(documentoId)
        Return dtRespuesta
    End Function

    Public Function ConsultarClaveSatSolicitud(ByVal solictudid As Integer) As DataTable
        Dim dtRespuesta As New DataTable
        Dim objSolicitud As New Ventas.Datos.SolicitarCancelacionDA
        dtRespuesta = objSolicitud.ConsultarClaveSatSolicitud(solictudid)
        Return dtRespuesta
    End Function

    Public Function EnviarParesRefacturarOT(ByVal DocumentoID As Integer) As DataTable
        Dim dtRespuesta As New DataTable
        Dim objSolicitud As New Ventas.Datos.SolicitarCancelacionDA
        dtRespuesta = objSolicitud.EnviarParesRefacturarOT(DocumentoID)
        Return dtRespuesta
    End Function

    Public Function tieneSolicitudesEnProceso(ByVal DocumentoID As Integer) As DataTable
        Dim dtRespuesta As New DataTable
        Dim objSolicitud As New Ventas.Datos.SolicitarCancelacionDA
        dtRespuesta = objSolicitud.TieneSolicitudesEnProceso(DocumentoID)
        Return dtRespuesta
    End Function

    Public Function ActualizarSolicitudConDocumentoRelacionado(ByVal DocumentoID As Integer) As DataTable
        Dim dtRespuesta As New DataTable
        Dim objSolicitud As New Ventas.Datos.SolicitarCancelacionDA
        dtRespuesta = objSolicitud.ActualizarSolicitudConDocumentoRelacionado(DocumentoID)
        Return dtRespuesta
    End Function

End Class