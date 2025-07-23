Public Class TabuladorSueldosForm
    Private Sub TabuladorSueldosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarComboEmpresaPatron()
    End Sub

    Public Sub cargarComboEmpresaPatron()
        Dim objBu As New Contabilidad.Negocios.ReporteAcumuladoSueldosSalariosBU
        Dim dtEmpresa As New DataTable
        dtEmpresa = objBu.consultarPatronEmpresaBU()
        If dtEmpresa.Rows.Count > 0 Then
            If dtEmpresa.Rows.Count = 1 Then
                Dim dtRow As DataRow = dtEmpresa.NewRow
                dtRow("ID") = 0
                dtRow("PATRON") = ""
                dtEmpresa.Rows.InsertAt(dtRow, 0)
                cmbPatron.DataSource = dtEmpresa
                cmbPatron.DisplayMember = "Patron"
                cmbPatron.ValueMember = "ID"
                cmbPatron.SelectedIndex = 1
            Else
                cmbPatron.DataSource = dtEmpresa
                cmbPatron.DisplayMember = "Patron"
                cmbPatron.ValueMember = "ID"
            End If
        End If
    End Sub

    Private Sub llenarComboAnios()
        Dim objMsjError As New Tools.ErroresForm
        Dim objBU As New Negocios.RecalculosBU
        Dim dtListado As New DataTable
        cmbAnio.DataSource = Nothing

        Try
            If Not cmbPatron Is Nothing Then
                If cmbPatron.SelectedIndex <> 0 Then
                    dtListado = objBU.obtenerAniosPatron(cmbPatron.SelectedValue)
                    If Not dtListado Is Nothing Then
                        If dtListado.Rows.Count > 0 Then
                            cmbAnio.DataSource = dtListado
                            cmbAnio.DisplayMember = "Anios"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            objMsjError.mensaje = ex.Message
            objMsjError.ShowDialog()
        End Try
    End Sub
End Class