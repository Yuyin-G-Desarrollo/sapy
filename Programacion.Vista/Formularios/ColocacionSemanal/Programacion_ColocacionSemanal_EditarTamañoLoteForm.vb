Imports Programacion.Negocios

Public Class Programacion_ColocacionSemanal_EditarTamañoLoteForm
    Dim objExito As New Tools.ExitoForm
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim obj As New Programacion_MapaOcupacionBU
        Try
            Dim tamañoLote As Integer = Integer.Parse(txtCantidadLote.Text)
            obj.EditarTamañoLote(tamañoLote)
            objExito.mensaje = "Datos guardados correctamente."
            objExito.ShowDialog()
        Catch ex As Exception
            objAdvertencia.mensaje = "Solo se ingresan valores numericos."
            objAdvertencia.ShowDialog()
        End Try
    End Sub

    Private Sub Programacion_ColocacionSemanal_EditarTamañoLoteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New Programacion_MapaOcupacionBU
        Dim tabla As DataTable
        tabla = obj.ConsultarTamañoLoteActual()
        If tabla.Rows.Count > 0 Then
            lblTamañoActual.Text = "Actual: " + tabla(0)(0).ToString
        Else
            lblTamañoActual.Text = "Actual: Sin registro."
        End If
    End Sub
End Class