Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools

Public Class CatalogoDepartamentosForm
    Private Sub CatalogoDepartamentosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ObjB As New Contabilidad.Negocios.CatalogoDepartamentoBU
        cmbPatrón = ObjB.llenarcmbPatrón(cmbPatrón)
        Dim patron = cmbPatrón.SelectedValue
        Dim datatable As New DataTable
        If patron = 0 Then
            If rdbSi.Checked Then
                PoblarGrid(patron, 1)
                btnactivar.Visible = False
                lblactivar.Visible = False
                lbldesactivar.Visible = True
                btndesactivar.Visible = True
            ElseIf rdbNo.Checked Then
                PoblarGrid(patron, 0)
                btnactivar.Visible = False
                lblactivar.Visible = False
                lbldesactivar.Visible = True
                btndesactivar.Visible = True
            End If
        Else
            If rdbSi.Checked Then
                PoblarGrid(patron, 1)
                btnactivar.Visible = False
                lblactivar.Visible = False
                lbldesactivar.Visible = True
                btndesactivar.Visible = True
            ElseIf rdbNo.Checked Then
                PoblarGrid(patron, 0)
                btnactivar.Visible = False
                lblactivar.Visible = False
                lbldesactivar.Visible = True
                btndesactivar.Visible = True
            End If
        End If
    End Sub

    Public Sub PoblarGrid(ByVal patron As Integer, ByRef estatus As Integer)
        Try
            Dim ObjB As New Contabilidad.Negocios.CatalogoDepartamentoBU
            Dim dataTable = ObjB.Consulta_Departamento_Por_Patron(patron, estatus)
            grdDepartamentos.DataSource = dataTable
            DiseñoGrid.DiseñoBaseGrid(viewDepartamentos)
            viewDepartamentos.IndicatorWidth = 35
            viewDepartamentos.OptionsView.ColumnAutoWidth = False
            DiseñoGrid.EstiloColumna(viewDepartamentos, "ID_Departamento", "ID", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDepartamentos, "Nombre", "Departamento", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 250, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDepartamentos, "PatronID", "PID", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 250, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDepartamentos, "NombrePatron", "Patron", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 250, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDepartamentos, "C_Sueldo", "Clave Sueldo", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDepartamentos, "C_PremioP", "Clave Premio" & vbCrLf & " Puntualidad", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 195, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDepartamentos, "C_PremioA", "Clave Premio" & vbCrLf & " Asistencia", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 195, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDepartamentos, "C_Vacacional", "Clave Vacaciones", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 195, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDepartamentos, "C_PrimaV", "Clave Prima" & vbCrLf & " Vacacional", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 195, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDepartamentos, "CLaveA", "Clave Aguinaldo" & vbCrLf & " Vacacional", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 195, False, Nothing, "")
            lblTotalRegistros.Text = dataTable.Rows.Count
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim patron = cmbPatrón.SelectedValue
        Dim datatable As New DataTable
        If patron = 0 Then
            If rdbSi.Checked Then
                btnactivar.Visible = False
                lblactivar.Visible = False
                lbldesactivar.Visible = True
                btndesactivar.Visible = True
                PoblarGrid(patron, 1)
            ElseIf rdbNo.Checked Then
                PoblarGrid(patron, 0)
                btnactivar.Visible = True
                lblactivar.Visible = True
                lbldesactivar.Visible = False
                btndesactivar.Visible = False
            End If
        Else
            If rdbSi.Checked Then
                PoblarGrid(patron, 1)
                btnactivar.Visible = False
                lblactivar.Visible = False
                lbldesactivar.Visible = True
                btndesactivar.Visible = True
            ElseIf rdbNo.Checked Then
                PoblarGrid(patron, 0)
                btnactivar.Visible = True
                lblactivar.Visible = True
                lbldesactivar.Visible = False
                btndesactivar.Visible = False
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim listado As New AltaDepartamentosForm
        Dim patron = cmbPatrón.SelectedValue
        If patron = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se selecciono un patron")
        Else
            listado.StartPosition = FormStartPosition.CenterScreen
            listado.txtPatron.Text = cmbPatrón.Text
            listado.txtidpatron.Text = cmbPatrón.SelectedValue
            listado.ShowDialog()
            If rdbSi.Checked Then
                PoblarGrid(cmbPatrón.SelectedValue, 1)
                btnactivar.Visible = False
                lblactivar.Visible = False
                lbldesactivar.Visible = True
                btndesactivar.Visible = True
            ElseIf rdbNo.Checked Then
                PoblarGrid(cmbPatrón.SelectedValue, 0)
                btnactivar.Visible = True
                lblactivar.Visible = True
                lbldesactivar.Visible = False
                btndesactivar.Visible = False
            End If
        End If
    End Sub


    Private Sub viewDepartamentos_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewDepartamentos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btndesactivar.Click
        EliminarDepartamento_PorPatron()
        If rdbSi.Checked Then
            PoblarGrid(cmbPatrón.SelectedValue, 1)
            btnactivar.Visible = False
            lblactivar.Visible = False
            lbldesactivar.Visible = True
            btndesactivar.Visible = True
        ElseIf rdbNo.Checked Then
            PoblarGrid(cmbPatrón.SelectedValue, 0)
            btnactivar.Visible = True
            lblactivar.Visible = True
            lbldesactivar.Visible = False
            btndesactivar.Visible = False
        End If
    End Sub

    Public Sub EliminarDepartamento_PorPatron()
        Dim ObjBU As New Contabilidad.Negocios.CatalogoDepartamentoBU
        Dim entDepartamento As New Entidades.DepartamentosByPatron
        Dim NumeroFilas As Integer = 0
        Dim departamentoID As String = String.Empty

        Try

            NumeroFilas = viewDepartamentos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(viewDepartamentos.GetRowCellValue(viewDepartamentos.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(viewDepartamentos.IsRowSelected(viewDepartamentos.GetVisibleRowHandle(index))) = True Then
                    departamentoID = viewDepartamentos.GetRowCellValue(viewDepartamentos.GetVisibleRowHandle(index), "ID_Departamento").ToString()
                    If departamentoID <> String.Empty Then
                        Dim ventanaConfirmacion As New Tools.ConfirmarForm
                        ventanaConfirmacion.mensaje = "¿Está seguro de desactivar el Departamento?"
                        ventanaConfirmacion.ShowDialog()
                        If ventanaConfirmacion.DialogResult <> DialogResult.OK Then Return
                        entDepartamento.Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        entDepartamento.ID_Departamento = departamentoID
                        entDepartamento.Fecha = Date.Now
                        Dim success = ObjBU.EliminarDepartamento_PorPatron(0, entDepartamento)
                        If success.Resp > 0 Then
                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, success.Mensaje)
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, success.Mensaje)
                        End If
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se selecciono un departamento")
                    End If
                End If
            Next

        Catch ex As Exception

            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El departamento no es valido" + ex.Message)
        End Try
    End Sub
    Public Sub ActivarDepartamento_PorPatron()
        Dim ObjBU As New Contabilidad.Negocios.CatalogoDepartamentoBU
        Dim entDepartamento As New Entidades.DepartamentosByPatron
        Dim NumeroFilas As Integer = 0
        Dim departamentoID As String = String.Empty

        Try

            NumeroFilas = viewDepartamentos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(viewDepartamentos.GetRowCellValue(viewDepartamentos.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(viewDepartamentos.IsRowSelected(viewDepartamentos.GetVisibleRowHandle(index))) = True Then
                    departamentoID = viewDepartamentos.GetRowCellValue(viewDepartamentos.GetVisibleRowHandle(index), "ID_Departamento").ToString()
                    If departamentoID <> String.Empty Then
                        Dim ventanaConfirmacion As New Tools.ConfirmarForm
                        ventanaConfirmacion.mensaje = "¿Está seguro de activar el Departamento?"
                        ventanaConfirmacion.ShowDialog()
                        If ventanaConfirmacion.DialogResult <> DialogResult.OK Then Return
                        entDepartamento.Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        entDepartamento.ID_Departamento = departamentoID
                        entDepartamento.Fecha = Date.Now
                        Dim success = ObjBU.EliminarDepartamento_PorPatron(1, entDepartamento)
                        If success.Resp > 0 Then
                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, success.Mensaje)
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, success.Mensaje)
                        End If
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se selecciono un departamento")
                    End If
                End If
            Next

        Catch ex As Exception

            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El departamento no es valido" + ex.Message)
        End Try
    End Sub
    Private Sub btnactivar_Click(sender As Object, e As EventArgs) Handles btnactivar.Click
        ActivarDepartamento_PorPatron()
        If rdbSi.Checked Then
            PoblarGrid(cmbPatrón.SelectedValue, 1)
            btnactivar.Visible = False
            lblactivar.Visible = False
            lbldesactivar.Visible = True
            btndesactivar.Visible = True
        ElseIf rdbNo.Checked Then
            PoblarGrid(cmbPatrón.SelectedValue, 0)
            btnactivar.Visible = True
            lblactivar.Visible = True
            lbldesactivar.Visible = False
            btndesactivar.Visible = False
        End If
    End Sub
End Class