Public Class EntradaSalidaMuestrasBU

    Dim objDa As New Datos.EntradaSalidaMuestrasDA

    Public Function ConsultarNavesUsuario_EnvioRecepcion(ByVal NombreUsuario As String, Proceso As Integer) As DataTable
        Dim dt As DataTable
        Try
            dt = objDa.ConsultarNavesUsuario_EnvioRecepcion(NombreUsuario, Proceso)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarNavesUsuario_Recepcion(ByVal NombreUsuario As String) As DataTable
        Dim dt As New DataTable
        Try
            dt = objDa.ConsultarNavesUsuario_Recepcion(NombreUsuario)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ValidarCodigoMuestra(ByVal codigo As String, NaveID As Integer) As DataTable
        Dim dt As DataTable
        Try
            dt = objDa.ValidarCodigoMuestra(codigo, NaveID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarCodigoMuestra_Recepcion(ByVal codigo As String, FolioRecepcion As Integer, NaveID As Integer) As DataTable
        Dim dt As DataTable
        Try
            dt = objDa.ValidarCodigoMuestra_Recepcion(codigo, FolioRecepcion, NaveID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GuardarEncabezadoPrimerCodigoLeido(NaveID As Integer, UsuarioEnviaID As Integer, CodigoPieza As String, ByVal cedisId As Integer) As DataTable
        Try
            Return objDa.GuardarEncabezadoPrimerCodigoLeido(NaveID, UsuarioEnviaID, CodigoPieza, cedisId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarFolioEnProceso(ByVal NaveID As Integer) As DataTable

        Try
            Return objDa.ValidarFolioEnProceso(NaveID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ConsultarPiezasEscaneadas(Folio As Integer) As DataTable
        Try
            Return objDa.ConsultarPiezasEscaneadas(Folio)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub GuardarPiezaMuestra(FolioEnvio As Integer, Codigo As String, UsuarioID As Integer, ByVal cedisId As Integer)
        Try
            objDa.GuardarPiezaMuestra(FolioEnvio, Codigo, UsuarioID, cedisId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ActualizarEstausEnvioRecepcionMuestras(Folio As Integer, UsuarioID As Integer, Proceso As Integer, ByVal sevanpiezasenreproceso As Boolean, ByVal reprocesoid As Integer) As DataTable
        Try
            Return objDa.ActualizarEstausEnvioRecepcionMuestras(Folio, UsuarioID, Proceso, sevanpiezasenreproceso, reprocesoid)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarPiezasPorFolioEnvio_Reporte(ByVal FolioEnvio As Integer) As DataTable
        Try
            Return objDa.ConsultarPiezasPorFolioEnvio_Reporte(FolioEnvio)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarPiezasPorFolioEnvio_Reporte_EnviadasDeReproceso(ByVal FolioEnvio As Integer) As DataTable
        Try
            Return objDa.ConsultarPiezasPorFolioEnvio_Reporte_EnviadasDeReproceso(FolioEnvio)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarFoliosEnvioRecepcion_Reporte(NaveID As Integer, FechaInicio As String, FechaFin As String, ByVal cedisId As Integer) As DataTable
        Try
            Return objDa.ConsultarFoliosEnvioRecepcion_Reporte(NaveID, FechaInicio, FechaFin, cedisId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarTipoNave_Recepcion(NaveID As Integer) As DataTable
        Try
            Return objDa.ValidarTipoNave_Recepcion(NaveID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarFoliosEnviosNaves_Recepcion(NaveID As Integer) As DataTable
        Try
            Return objDa.ConsultarFoliosEnviosNaves_Recepcion(NaveID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function RecibirPrimerPiezaRecepcion(NaveID As Integer, CodigoPieza As String, FolioEnvio As Integer, UsuarioID As Integer) As DataTable
        Try
            Return objDa.RecibirPrimerPiezaRecepcion(NaveID, CodigoPieza, FolioEnvio, UsuarioID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecibirPrimerPiezaRecepcion_NaveExterna(NaveID As Integer, CodigoPieza As String, UsuarioID As Integer, ByVal cedisid As Integer) As DataTable
        Try
            Return objDa.RecibirPrimerPiezaRecepcion_NaveExterna(NaveID, CodigoPieza, UsuarioID, cedisid)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub ActualizaPiezaRecibidaComercializadora(CodigoPieza As String, UsuarioID As Integer, FolioEnvio As Integer)
        Try
            objDa.ActualizaPiezaRecibidaComercializadora(CodigoPieza, UsuarioID, FolioEnvio)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizaPiezaRecibidaComercializadora_NaveExterna(CodigoPieza As String, UsuarioID As Integer, FolioEnvio As Integer, ByVal cedisid As Integer)
        Try
            objDa.ActualizaPiezaRecibidaComercializadora_NaveExterna(CodigoPieza, UsuarioID, FolioEnvio, cedisid)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ValidarFolioIngresando(NaveID As Integer, ComercializadoraID As Integer) As DataTable
        Try
            Return objDa.ValidarFolioIngresando(NaveID, ComercializadoraID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarPiezasRecibidas(Folio As Integer) As DataTable
        Try
            Return objDa.ConsultarPiezasRecibidas(Folio)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub DescartarPiezas(PiezaID As String, UsuarioRecibe As Integer, FolioEnvio As Integer)

        Try
            objDa.DescartarPiezas(PiezaID, UsuarioRecibe, FolioEnvio)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Function ConsultarEncabezadoReporte(Folio As Integer, ByVal cedisId As Integer) As DataTable
        Try
            Return objDa.ConsultarEncabezadoReporte(Folio, cedisId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ConsultarPiezasDescartadas(Folio As Integer) As DataTable
        Try
            Return objDa.ConsultarPiezasDescartadas(Folio)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function obtenerCedisNaves() As DataTable
        Try
            Return objDa.obtenerCedisNaves
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function obtenerCedisPertenecienteCodigo(ByVal codigoMuestra As String) As DataTable
        Try
            Return objDa.ConsultarNaveCedisPieza(codigoMuestra)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function obtenerCedisCorrespondientePieza(ByVal codigoMuestra As String) As DataTable
        Try
            Return objDa.ConsultarNaveCedisPiezaCorrespondiente(codigoMuestra)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function obtenerReportePiezasReproceso(ByVal folio As Integer, ByVal tipoReporte As String) As DataTable
        Return objDa.obtenerReporteEnvioPiezasReproceso(folio, tipoReporte)
    End Function

    Public Sub actualizaPiezasReprocesos(ByVal folioReproceso As Integer)
        objDa.actualizaReprocesosPiezas(folioReproceso)
    End Sub

    Public Function obtenerTotalPiezasEnviadas(ByVal folio As Integer) As DataTable
        Return objDa.obtenerTotalPiezasEnvidas(folio)
    End Function

End Class
