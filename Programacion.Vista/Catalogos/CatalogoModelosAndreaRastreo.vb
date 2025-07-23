
Imports Programacion.Negocios.EtiquetasBU
Imports Tools
Public Class CatalogoModelosAndreaRastreo

    Dim idusuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    Dim tblModelos As New DataTable

    Private Sub CatalogoModelosAndreaRastreo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        chkDesasignar.Visible = False
        ConsultarModelos()

    End Sub

    Private Sub ConsultarModelos()
        Dim obj As New Programacion.Negocios.EtiquetasBU
        Dim asignados As Integer

        grdModelosAndrea.DataSource = Nothing
        grdVModelosAndrea.Columns.Clear()

        If rbtNoAsignados.Checked Then
            asignados = 0
        ElseIf rbtAsignados.Checked Then
            asignados = 1
        End If
        Me.Cursor = Cursors.WaitCursor
        tblModelos = obj.ConsultaModelosAndrea(asignados)
        Try
            If tblModelos.Rows.Count > 0 Then
                grdModelosAndrea.DataSource = tblModelos
                DisenioGrid(asignados)

            End If
        Catch ex As Exception
        Finally
            lblTotalRegistros.Text = tblModelos.Rows.Count
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub DisenioGrid(ByVal asignados As Integer)
        grdVModelosAndrea.IndicatorWidth = 40

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVModelosAndrea.Columns
            col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            If col.FieldName = "Sel" Then
                col.Width = 15
                If asignados = 1 Then
                    col.Visible = False
                Else
                    col.Visible = True
                End If
            End If
            If col.FieldName = "ColeccionId" Then
                col.Visible = False
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Colección" Then
                col.Width = 100
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Modelo" Then
                col.Width = 50
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Modelo Sicy" Then
                col.Width = 50
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "TallaId" Then
                col.Visible = False
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Talla" Then
                col.Width = 50
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "ProductoEstiloId" Then
                col.Visible = False
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Activo" Then
                col.Visible = False
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Piel Color" Then
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Familia" Then
                col.OptionsColumn.AllowEdit = False
            End If
        Next

        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(grdVModelosAndrea)
        Tools.DiseñoGrid.AlternarColorEnFilas(grdVModelosAndrea)

    End Sub

    Private Sub grdVModelosAndrea_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdVModelosAndrea.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString + 1
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub rbtNoAsignados_CheckedChanged(sender As Object, e As EventArgs) Handles rbtNoAsignados.CheckedChanged
        chkDesasignar.Visible = False
        chkDesasignar.Checked = False
        chkSeleccionarTodo.Visible = True
        ConsultarModelos()
    End Sub

    Private Sub rbtAsignados_CheckedChanged(sender As Object, e As EventArgs) Handles rbtAsignados.CheckedChanged
        chkDesasignar.Visible = True
        chkSeleccionarTodo.Visible = False
        ConsultarModelos()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim obj As New Programacion.Negocios.EtiquetasBU
        Dim tbl As New DataTable
        Dim Xmlceldamodificada As XElement = New XElement("Celdas")


        If tblModelos.Rows.Count > 0 Then
            Try
                tbl = tblModelos.AsEnumerable().Where(Function(y) y.Item("Sel") = True).CopyToDataTable()
                If tbl.Rows.Count > 0 Then
                    For index As Integer = 0 To tbl.Rows.Count - 1
                        Dim Xnodo As XElement = New XElement("Celda")
                        Xnodo.Add(New XAttribute("ColeccionId", tbl.Rows(index).Item("ColeccionId")))
                        Xnodo.Add(New XAttribute("TallaId", tbl.Rows(index).Item("TallaId")))
                        Xnodo.Add(New XAttribute("ProductoEstiloId", tbl.Rows(index).Item("ProductoEstiloId")))
                        Xnodo.Add(New XAttribute("UsuarioCreoId", idusuario))
                        Xnodo.Add(New XAttribute("FechaCreacion", Date.Now))
                        Xnodo.Add(New XAttribute("Activo", tbl.Rows(index).Item("Activo")))
                        Xmlceldamodificada.Add(Xnodo)
                    Next
                    obj.GuardarModelosAndreaRastreo(Xmlceldamodificada.ToString())
                    If rbtAsignados.Checked Then
                        Tools.MostrarMensaje(Mensajes.Success, "Se han desasignado correctamente.")
                        chkSeleccionarTodo.Checked = False
                    ElseIf rbtNoAsignados.Checked Then
                        Tools.MostrarMensaje(Mensajes.Success, "Se han asignado correctamente.")
                    End If
                Else
                        Tools.MostrarMensaje(Mensajes.Warning, "Seleccione al menos un registro.")
                End If
            Catch ex As Exception

            End Try
        Else
            Tools.MostrarMensaje(Mensajes.Warning, "No existen registros")
        End If





        ConsultarModelos()
        chkDesasignar.Checked = False
    End Sub

    Private Sub chkDesasignar_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesasignar.CheckedChanged
        Try
            If chkDesasignar.Checked Then
                If grdVModelosAndrea.RowCount > 0 Then
                    chkSeleccionarTodo.Visible = True
                    grdVModelosAndrea.Columns("Sel").Visible = True
                End If
            Else
                If grdVModelosAndrea.RowCount > 0 Then
                    chkSeleccionarTodo.Visible = False
                    grdVModelosAndrea.Columns("Sel").Visible = False
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        If chkSeleccionarTodo.Checked Then
            For i As Integer = 0 To grdVModelosAndrea.RowCount - 1
                grdVModelosAndrea.SetRowCellValue(i, "Sel", True)
            Next
        Else
            If chkSeleccionarTodo.Checked = False Then
                For i As Integer = 0 To grdVModelosAndrea.RowCount - 1
                    grdVModelosAndrea.SetRowCellValue(i, "Sel", False)
                Next
            End If
        End If
    End Sub
End Class