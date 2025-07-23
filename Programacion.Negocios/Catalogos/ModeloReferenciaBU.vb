Public Class ModeloReferenciaBU


    Public Function VerListaModelosReferencia() As DataTable
        Dim objModeloReferencia As New Programacion.Datos.ModeloReferenciaDA
        Return objModeloReferencia.verListaModelos()
    End Function

    'Public Function verModelos(text As String) As DataTable
    '    Throw New NotImplementedException()
    'End Function

    Public Function verModelos(ByVal ModeloReferencia As String) As DataTable
        Dim objModeloReferenciaDA As New Programacion.Datos.ModeloReferenciaDA
        Try
            Return objModeloReferenciaDA.verModeloreferencia(ModeloReferencia)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


End Class
