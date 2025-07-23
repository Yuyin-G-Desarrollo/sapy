Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns

Public Class DevolucionCliente_CapturaGeneral_BusquedaMotivosCalidad

    Dim btnSeleccion As New RepositoryItemButtonEdit
    Public idDetalle As Integer = 0
    Public IdMotivo As Integer = 0
    Public Motivo As String = ""

    Private Sub DevolucionCliente_CapturaGeneral_BusquedaMotivosCalidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdMotivosCalidad.DataSource = (New Negocios.DevolucionClientesBU).ConsultaMotivos_Calidad()
        lblNumFiltrados.Text = bgvMotivosCalidad.DataRowCount

        With btnSeleccion
            .Name = "BtnSeleccion"
            .Buttons(0).Image = Global.Almacen.Vista.My.Resources.Resources.seleccionar
            .AutoHeight = False
            .TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
            .Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
            .Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph

            AddHandler btnSeleccion.Click, AddressOf BtnSeleccion_Clic
        End With

        grdMotivosCalidad.RepositoryItems.Add(btnSeleccion)

        bgvMotivosCalidad.Columns(" ").ColumnEdit = btnSeleccion
        bgvMotivosCalidad.Columns(" ").ColumnEdit.Name = "BtnSeleccion2"

        FormatoGrid()
        grdMotivosCalidad.Select()
    End Sub

    Public Sub FormatoGrid()
        bgvMotivosCalidad.OptionsView.ColumnAutoWidth = True
        For Each col As GridColumn In bgvMotivosCalidad.Columns
            If col.FieldName <> " " Then
                col.OptionsColumn.AllowEdit = False
                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            Else
                col.ColumnEdit = btnSeleccion
            End If
        Next

        bgvMotivosCalidad.Columns.ColumnByFieldName("Departamento").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvMotivosCalidad.Columns.ColumnByFieldName("Incidencia").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        bgvMotivosCalidad.Columns.ColumnByFieldName("Activo").Visible = False
        bgvMotivosCalidad.Columns.ColumnByFieldName("Parámetro").Visible = False
        bgvMotivosCalidad.Columns.ColumnByFieldName(" ").Width = 10
        bgvMotivosCalidad.Columns.ColumnByFieldName("Departamento").Width = 40
        bgvMotivosCalidad.IndicatorWidth = 40
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub bgvMotivosCalidad_ColumnFilterChanged(sender As Object, e As EventArgs) Handles bgvMotivosCalidad.ColumnFilterChanged
        lblNumFiltrados.Text = bgvMotivosCalidad.DataRowCount
    End Sub

    Private Sub bgvMotivosCalidad_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvMotivosCalidad.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Public Sub BtnSeleccion_Clic(ByVal sender As Object, ByVal e As EventArgs)
        Dim filaActual As Int64 = bgvMotivosCalidad.FocusedRowHandle
        IdMotivo = bgvMotivosCalidad.GetRowCellValue(filaActual, "Parámetro")
        Motivo = bgvMotivosCalidad.GetRowCellValue(filaActual, "Incidencia")
        If idDetalle <> 0 Then
            Dim negocios As New Negocios.DevolucionClientesBU
            Try
                negocios.MoficiarMotivoDevolucionCalidad(idDetalle, IdMotivo)
            Catch ex As Exception
                Dim ventanaError As New Tools.ErroresForm
                ventanaError.mensaje = "Error " + ex.Message
                ventanaError.ShowDialog()
            End Try
        End If

        Me.Close()
    End Sub

    Private Sub bgvMotivosCalidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bgvMotivosCalidad.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            BtnSeleccion_Clic(Nothing, Nothing)
        End If
    End Sub
End Class
