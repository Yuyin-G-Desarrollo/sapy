Imports Proveedores.DA
Imports Entidades
Public Class ConfiguracionPorcentajeMaquilasBU
    Public Function ObtenerConfiguracionesPorcentajesMaquila() As DataTable
        Dim objConfiguracion As New ConfiguracionPorcentajesMaquilasDA
        Return objConfiguracion.ObtenerConfiguracionMaquilas
    End Function
    Public Function EditaPorcentajesMaquila(ByVal objConfigPorcentajes As Entidades.ConfiguracionPorcentajesMaquilas) As String
        Dim objEditarPorcentajesMaquila As New ConfiguracionPorcentajesMaquilasDA
        Dim dtResultado As New DataTable
        dtResultado = objEditarPorcentajesMaquila.EditaPorcentajesMaquila(objConfigPorcentajes)

        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            objConfigPorcentajes.cpmMsgResult = dtResultado.Rows(0).Item("mensaje")
        Else
            objConfigPorcentajes.cpmMsgResult = Nothing
        End If

        Return objConfigPorcentajes.cpmMsgResult
    End Function
End Class
