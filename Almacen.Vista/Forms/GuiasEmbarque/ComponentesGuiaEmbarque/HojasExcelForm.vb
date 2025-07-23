Public Class HojasExcelForm

    Public numeroHoja As String = ""
    Public hojas As List(Of Entidades.SheetsExcel)

    Private Sub llenarcombo()
        If hojas.Count > 0 Then
            cmbImpresoras.DataSource = hojas
            cmbImpresoras.DisplayMember = "NombreHoja"
            cmbImpresoras.ValueMember = "NombreHoja"
        End If
    End Sub

    Private Sub HojasExcelForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarcombo()

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        numeroHoja = cmbImpresoras.SelectedValue
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class