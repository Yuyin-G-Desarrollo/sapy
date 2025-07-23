Public Class BarraProgresoFacturacionForm
    Public NumeroDocumentos As Integer = 0
    Public DocumentoProcesado As Integer = 0
    Public StatusProgreso As String = String.Empty

    Private Sub BarraProgresoFacturacionForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        pgrBarFacturas.Maximum = NumeroDocumentos
        lblNumeroDeDocumentos.Text = NumeroDocumentos.ToString
        lblDocumentosProcesados.Text = DocumentoProcesado.ToString
        If NumeroDocumentos > 0 Then
            lblPorcentaje.Text = CInt(DocumentoProcesado / NumeroDocumentos).ToString
        End If

    End Sub

    Public Sub DibujarBarra(ByVal DocumentosProcesados As Integer, ByVal StatusProgreso As String)
        pgrBarFacturas.Value = DocumentosProcesados
        lblDocumentosProcesados.Text = DocumentosProcesados.ToString
        lblStatusProcesoDocumento.Text = StatusProgreso
        lblPorcentaje.Text = CInt((DocumentosProcesados / NumeroDocumentos) * 100).ToString & "%"
    End Sub

End Class