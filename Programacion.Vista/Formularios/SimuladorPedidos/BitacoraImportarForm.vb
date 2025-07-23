Imports Framework.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Programacion.Negocios
Imports Tools

Public Class BitacoraImportarForm

    Private Sub form_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        ConfigurarSeguridad()
        LlenarTabla()
    End Sub

    Private Sub ConfigurarSeguridad()
    End Sub


    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs)
        LlenarTabla()
    End Sub

    Private Sub btnExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportarExcel.Click
        ExportarExcel()
    End Sub


    Private Sub ExportarExcel()
        Dim vErrorForm As New ErroresForm
        Dim vExitoForm As New ExitoForm
        Try
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = ".xls"
            sfd.Filter = "*.xls|*.xls"
            If sfd.ShowDialog = System.Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            If sfd.FileName.Trim = "" Then
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Dim nombre As String = sfd.FileName

            Me.UltraGridExcelExporter1.Export(grdDatos, nombre)
            System.Diagnostics.Process.Start(nombre)

            vExitoForm.Text = "Espacio Reservado"
            vExitoForm.mensaje = "Información exportada correctamente"
            vExitoForm.ShowDialog()
        Catch ex As Exception
            vErrorForm.Text = "Espacio Reservado"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub LlenarTabla()
        Dim vErrorForm As New ErroresForm
        Dim vBitacora As New BitacoraImportacionBU
        Try
            Me.Cursor = Cursors.WaitCursor
            grdDatos.DataSource = Nothing
            grdDatos.DataSource = vBitacora.Tabla
            formatotabla()
        Catch ex As Exception
            vErrorForm.Text = "Bitácora de Importación"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Public Sub formatotabla()
        Dim band As UltraGridBand = Me.grdDatos.DisplayLayout.Bands(0)
        With band
            .Columns("Fecha").CellActivation = Activation.NoEdit
            .Columns("PC").CellActivation = Activation.NoEdit
            .Columns("Tipo").CellActivation = Activation.NoEdit
            .Columns("Nota").CellActivation = Activation.NoEdit
            .Columns("PC").Header.Caption = "Equipo"
            .Columns("Tipo").Header.Caption = "Tipo Archivo"
            .Columns("Nota").Header.Caption = "Ruta Archivo Importado"
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdDatos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdDatos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdDatos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDatos.DisplayLayout.Override.RowSelectorWidth = 35
        grdDatos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

    End Sub

    Private Sub grdDatos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdDatos.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        LlenarTabla()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class