Imports Programacion.Negocios
Imports Tools.modMensajes

Public Class AdministradorDeLicenciasForm
    Dim activo As Integer

    Dim idmarca As Integer
    Dim codigoSICY As String
    Dim codigo As Integer
    Dim nombre As String
    Dim claveActivo As Integer
    Private Sub AdministradorDeLicenciasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar()
    End Sub
    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim form As New LicenciasForm
        form.Accion = "Alta"
        form.ShowDialog()
        Mostrar()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim form As New LicenciasForm
        form.Accion = "Editar"
        form.marcaid = idmarca
        form.IdLicencia = codigoSICY
        form.ClaveLiencia = nombre
        form.CodigoSICY = codigo
        form.Activo = claveActivo
        form.ShowDialog()
        Mostrar()
    End Sub

    Private Sub btncCerrar_Click(sender As Object, e As EventArgs) Handles btncCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Mostrar()
    End Sub

    Private Sub Mostrar()
        Dim obj As New LicenciasBU
        Dim tblLicencias As New DataTable
        Try
            Me.Cursor = Cursors.WaitCursor
            dgLicencias.DataSource = Nothing
            dgVLicencias.Columns.Clear()
            If rbtActivo.Checked Then
                activo = 1
            End If
            If rbtInactivo.Checked Then
                activo = 0
            End If

            tblLicencias = obj.ConsultarMarcaLicenciaReedition(activo)
            If tblLicencias.Rows.Count > 0 Then
                dgLicencias.DataSource = tblLicencias
                DisenioGrid()
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No existen registros")
            End If
        Catch ex As Exception
        Finally
            ActualizaRegistrosFecha()
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub DisenioGrid()
        dgVLicencias.IndicatorWidth = 40
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In dgVLicencias.Columns
            If col.FieldName = "marc_marcaid" Then
                col.Caption = "Marcaid"
                col.OptionsColumn.AllowEdit = False
                col.Visible = False
            End If
            If col.FieldName = "marc_descripcion" Then
                col.Caption = "Licencia"
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "marc_codigo" Then
                col.Caption = "Código"
                col.OptionsColumn.AllowEdit = False
                col.Visible = False
            End If
            If col.FieldName = "marc_activo" Then
                col.Caption = "Activo"
                col.OptionsColumn.AllowEdit = False
                col.Visible = False
            End If
            If col.FieldName = "marc_activo" Then
                col.Caption = "Activo"
                col.OptionsColumn.AllowEdit = False
                col.Visible = False
            End If
            If col.FieldName = "marc_codigosicy" Then
                col.Caption = "CódigoSICY"
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "marc_fechacreacion" Then
                col.Caption = "Fecha creación"
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "user_username" Then
                col.Caption = "Usuario creo"
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "marc_usuariocreoid" Then
                col.Caption = "Usuario creo id"
                col.OptionsColumn.AllowEdit = False
                col.Visible = False
            End If
        Next
        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(dgVLicencias)
        Tools.DiseñoGrid.AlternarColorEnFilasTenue(dgVLicencias)
    End Sub

    Private Sub ActualizaRegistrosFecha()
        lblRegistros.Text = dgVLicencias.RowCount
        lblUltimaActualizacion.Text = Date.Now
    End Sub

    Private Sub dgVLicencias_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles dgVLicencias.CustomDrawRowIndicator
        If (e.RowHandle >= 0) Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub

    Private Sub dgVLicencias_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles dgVLicencias.RowClick
        If e.Clicks = 1 Then
            idmarca = dgVLicencias.GetRowCellValue(e.RowHandle, "marc_marcaid")
            codigoSICY = dgVLicencias.GetRowCellValue(e.RowHandle, "marc_codigosicy")
            codigo = dgVLicencias.GetRowCellValue(e.RowHandle, "marc_codigo")
            nombre = dgVLicencias.GetRowCellValue(e.RowHandle, "marc_descripcion")
            claveActivo = dgVLicencias.GetRowCellValue(e.RowHandle, "marc_activo")
        End If
    End Sub
End Class