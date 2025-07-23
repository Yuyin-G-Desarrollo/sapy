Public Class AdminCFDITrasladoBU

    Dim objDA As New Datos.AdminCFDITrasladoDA

    Public Function InsertarTraslado(FolioEmbarque As String, Usuario As Integer, Salida As Boolean) As DataTable
        Return objDA.InsertarTraslado(FolioEmbarque, Usuario, Salida)
    End Function

    Public Function ConsultaDocumentosTraslados(FechaInicio As String,
                                                FechaFin As String,
                                                Estatus As String,
                                                Emisor As String,
                                                Cliente As String,
                                                Folio As String,
                                                Nave As String,
                                                Salida As String,
                                                Tipo As Integer,
                                                Cedis As Integer) As DataTable

        Return objDA.ConsultaDocumentosTraslados(FechaInicio, FechaFin, Estatus, Emisor, Cliente, Folio, Nave, Salida, Tipo, Cedis)
    End Function

    Public Function ConsultaEncabezadoTraslado(FolioEmbarque As String) As DataTable
        Return objDA.ConsultaEncabezadoTraslado(FolioEmbarque)
    End Function

    Public Function ConsultaDetallesTraslado(FolioEmbarque As String) As DataTable
        Return objDA.ConsultaDetallesTraslado(FolioEmbarque)
    End Function

    Public Function ConsultaNave(Colaborador As Integer) As DataTable
        Return objDA.ConsultaNave(Colaborador)
    End Function

End Class
