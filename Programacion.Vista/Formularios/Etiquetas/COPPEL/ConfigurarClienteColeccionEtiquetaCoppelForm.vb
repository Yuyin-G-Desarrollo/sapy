Imports DevExpress.XtraGrid
Imports Programacion.Negocios

Public Class ConfigurarClienteColeccionEtiquetaCoppelForm
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objError As New Tools.ErroresForm
    Dim objConfirmar As New Tools.ConfirmarForm
    Dim clienteId As Integer = 763 'Coppel
    Dim tipoEtiqueta As Integer = 6 'Especial (Par)
    Private Function obtenerColeccionesSeleccionadas() As List(Of Integer)
        obtenerColeccionesSeleccionadas = New List(Of Integer)
        For i = 0 To vwEtiquetas.RowCount - 1
            If vwEtiquetas.GetRowCellValue(i, " ") Then obtenerColeccionesSeleccionadas.Add(vwEtiquetas.GetRowCellValue(i, "ColeccionId"))
        Next
    End Function

    Public Sub diseñoGrid()
        vwEtiquetas.OptionsView.ColumnAutoWidth = True
        vwEtiquetas.OptionsView.EnableAppearanceEvenRow = True
        vwEtiquetas.OptionsCustomization.AllowSort = False
        vwEtiquetas.OptionsCustomization.AllowFilter = False
        vwEtiquetas.IndicatorWidth = 30
        vwEtiquetas.OptionsView.ShowAutoFilterRow = True
        vwEtiquetas.OptionsView.RowAutoHeight = True
        vwEtiquetas.Columns(" ").Width = 40

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwEtiquetas.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If (col.FieldName <> " ") Then
                col.OptionsColumn.AllowEdit = False
            End If
            vwEtiquetas.Columns.ColumnByFieldName(" ").OptionsFilter.AllowAutoFilter = False
            vwEtiquetas.Columns.ColumnByFieldName("ColeccionId").Visible = False
        Next
    End Sub
    Public Sub mostrarColeccionesEtiquetas()
        Dim obj As New EtiquetasBU
        vwEtiquetas.Columns.Clear()
        grdEtiquetas.DataSource = Nothing
        Try
            Dim dt As DataTable = obj.ConsultaEtiquetasClienteColeccion(cmbNave.SelectedValue)
            If dt.Rows.Count > 0 Then
                grdEtiquetas.DataSource = dt
                diseñoGrid()
            Else
                objAdvertencia.mensaje = "No se encontro información."
                objAdvertencia.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ConfigurarClienteColeccionEtiquetaCoppelForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Dim obj As New EtiquetasBU
        Dim consulta As DataTable = obj.CmbConsultaEtiquetasCliente(clienteId, tipoEtiqueta)
        cmbNave.DataSource = consulta
        cmbNave.ValueMember = "etiq_etiquetaid"
        cmbNave.DisplayMember = "etiq_descripcion"
        'mostrarColeccionesEtiquetas()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        mostrarColeccionesEtiquetas()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Dim objAsignar As New AsignarEtiquetaClienteColeccionForm
        objAsignar.clienteId = clienteId
        objAsignar.etiquetaId = cmbNave.SelectedValue
        If objAsignar.ShowDialog = DialogResult.OK Then
            mostrarColeccionesEtiquetas()
        End If
    End Sub

    Private Sub chkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged
        Dim activo As Boolean = False
        If chkSeleccionar.Checked Then activo = True
        For i = 0 To vwEtiquetas.RowCount - 1
            vwEtiquetas.SetRowCellValue(i, " ", activo)
        Next
    End Sub

    Private Sub btnEliminarColeccion_Click(sender As Object, e As EventArgs) Handles btnEliminarColeccion.Click
        Dim listaColecciones As List(Of Integer) = obtenerColeccionesSeleccionadas()

        If listaColecciones.Count > 0 Then
            objConfirmar.mensaje = "Desea eliminar estas colecciones asignadas a la etiqueta."

            If objConfirmar.ShowDialog = DialogResult.OK Then

                Dim obj As New EtiquetasBU
                Dim UsuarioId As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

                Try
                    obj.EliminarColeccionesAsignadasPorCliente(clienteId, cmbNave.SelectedValue, String.Join(",", listaColecciones), UsuarioId)
                    objExito.mensaje = "Se han registrado los cambios correctamente."
                    objExito.ShowDialog()
                    mostrarColeccionesEtiquetas()
                    chkSeleccionar.Checked = False
                Catch ex As Exception
                    objError.mensaje = "Se produjo un error al procesar la solicitud."
                    objError.ShowDialog()
                End Try

            End If
        Else
            objAdvertencia.mensaje = "Seleccione al menos un registro para eliminar."
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Private Sub vwEtiquetas_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwEtiquetas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

End Class