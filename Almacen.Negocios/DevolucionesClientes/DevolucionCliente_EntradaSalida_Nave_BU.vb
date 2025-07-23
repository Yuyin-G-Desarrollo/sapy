Public Class DevolucionCliente_EntradaSalida_Nave_BU

    Dim salidasNaveDA As New Datos.DevolucionCliente_EntradaSalida_Naves

    Public Function ConsultaNaves()
        Return salidasNaveDA.ConsultaNaves()
    End Function

    Public Function ConsultarSalidas(ByVal FiltroFecha As Int16,
                                     ByVal TipoFecha As String,
                                     ByVal fechaInicio As Date,
                                     ByVal fechaFin As Date,
                                     ByVal folioSalida As String,
                                     ByVal estatus As String,
                                     ByVal Cliente As String,
                                     ByVal FoliosDevolucion As String) As DataTable


        ConsultarSalidas = salidasNaveDA.ConsultarSalidas(FiltroFecha, TipoFecha, fechaInicio, fechaFin, folioSalida, estatus, Cliente, FoliosDevolucion)
        Return ConsultarSalidas
    End Function

    Public Function ConsultaCodigoPar(ByVal codigo As String, ByVal NaveSICY As Int16) As DataTable
        ConsultaCodigoPar = salidasNaveDA.ConsultaCodigoPar(codigo, NaveSICY)
        Return ConsultaCodigoPar
    End Function

    Public Function GenerarSalida(ByVal xmlSalidas As String)
        Return salidasNaveDA.GenerarSalida(xmlSalidas)
    End Function

    Public Function GenerarEntrada(ByVal xmlEntrada As String)
        Return salidasNaveDA.GenerarEntrada(xmlEntrada)
    End Function

    Public Function ConsultaDetallesSalidas(ByVal FolioSalida As Integer)
        Return salidasNaveDA.ConsultaDetallesSalidas(FolioSalida)
    End Function

    Public Function ConsultaReporteSalidas(ByVal FolioSalida As Integer)
        Return salidasNaveDA.ConsultaReporteSalidas(FolioSalida)
    End Function
End Class
