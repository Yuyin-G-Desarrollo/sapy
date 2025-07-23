Public Class NotasCreditoBU
    Public Function consultaNCPendientesTimbrar() As DataTable
        Dim objDA As New Datos.NotasCreditoDA
        Return objDA.consultaNCPendientesTimbrar
    End Function

    Public Function validarTimbrado(ByVal IdNotaCredito As Integer) As Boolean
        Dim objDA As New Datos.NotasCreditoDA
        Dim dtResultado As New DataTable
        Dim blnResult As Boolean = False

        dtResultado = objDA.validarTimbrado(IdNotaCredito)

        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            If dtResultado.Rows(0).Item("Timbrado") > 0 Then
                blnResult = True
            End If
        End If

        Return blnResult
    End Function

End Class
