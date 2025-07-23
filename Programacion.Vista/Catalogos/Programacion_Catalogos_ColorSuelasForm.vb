Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports Tools


Public Class Programacion_Catalogos_ColorSuelasForm

    Private Sub Programacion_Catalogos_ColorSuelasForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        LlenarTablaColoresSuela()
        Me.Top = 0
        Me.Left = 0
        DisenoGrid()
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim AltaColorSuela As New Programacion_Catalogos_AltaColorSuelaForm
        AltaColorSuela.ShowDialog()
        LlenarTablaColoresSuela()
    End Sub

    Public Sub LlenarTablaColoresSuela()
        Dim dtTablaColoresSuela As New DataTable
        Dim objBU As New Programacion.Negocios.ColoresSuelaBU
        Dim cosu_activo As String

        Dim activo As String = String.Empty
        If rdoActivo.Checked = True Then
            activo = "True"
        ElseIf rdoInactivo.Checked = True Then
            activo = "False"
        End If

        cosu_activo = activo

        dtTablaColoresSuela = objBU.obtenerColoresSuelas(cosu_activo)
        grdCntrlColorSuela.DataSource = dtTablaColoresSuela
    End Sub

    Public Sub DisenoGrid()

        MVSuelasColor.Columns.ColumnByFieldName("cosu_colorsuelaid").Caption = "Código"
        MVSuelasColor.Columns.ColumnByFieldName("cosu_nombrecolor").Caption = "Color"
        MVSuelasColor.OptionsView.ColumnAutoWidth = False
        MVSuelasColor.Columns.ColumnByFieldName("cosu_colorsuelaid").Width = 80
        MVSuelasColor.Columns.ColumnByFieldName("cosu_nombrecolor").Width = 305

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVSuelasColor.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        MVSuelasColor.Columns.ColumnByFieldName("cosu_colorsuelaid").OptionsColumn.AllowEdit = False
        MVSuelasColor.Columns.ColumnByFieldName("cosu_nombrecolor").OptionsColumn.AllowEdit = False
        MVSuelasColor.Columns.ColumnByFieldName("cosu_activo").Visible = False
        'MVSuelasColor.Columns.ColumnByFieldName("cosu_usuariocreoid").Visible = False
        'MVSuelasColor.Columns.ColumnByFieldName("cosu_fechacreacion").Visible = False
        ' MVSuelasColor.Columns.ColumnByFieldName("cosu_usuariomodificoid").Visible = False
        ' MVSuelasColor.Columns.ColumnByFieldName("cosu_fechamodificacion").Visible = False


    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        EnviarDatoEditar()
        LlenarTablaColoresSuela()
    End Sub

    Public Sub EnviarDatoEditar()
        Try
            Dim EntidadColorSuela As New Entidades.ColorSuela
            Dim Fila As Integer = MVSuelasColor.DataRowCount
            If MVSuelasColor.FocusedRowHandle > 0 Then
                For item As Integer = 0 To Fila Step 1
                    If CBool(MVSuelasColor.IsRowSelected(MVSuelasColor.GetVisibleRowHandle(item))) = True Then
                        EntidadColorSuela.PColorSuelaId = MVSuelasColor.GetRowCellValue(item, "cosu_colorsuelaid").ToString
                        EntidadColorSuela.PNombreColor = MVSuelasColor.GetRowCellValue(item, "cosu_nombrecolor")
                        EntidadColorSuela.PActivo = MVSuelasColor.GetRowCellValue(item, "cosu_activo").ToString
                    End If
                Next
                Dim EditarSuela As New Programacion_Catalogos_EditarColorSuelaForm
                EditarSuela.LlenarDatos(EntidadColorSuela)
                EditarSuela.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox("Debe seleccionar un registro.")
        End Try
    End Sub



    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        LlenarTablaColoresSuela()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        LlenarTablaColoresSuela()
    End Sub
End Class