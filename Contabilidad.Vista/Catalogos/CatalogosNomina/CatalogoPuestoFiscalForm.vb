Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools

Public Class PuestoFiscalForm
    Private Sub PuestoFiscalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ObjB As New Contabilidad.Negocios.CatalogoPuestoFiscalBU
        cmbPatrón = ObjB.llenarcmbPatrón(cmbPatrón)
        Dim patron = cmbPatrón.SelectedValue
        Dim datatable As New DataTable
        If patron = 0 Then
            If rdbSi.Checked Then
                PoblarGrid(patron, 1)
                btnactivar.Visible = False
                lblactivar.Visible = False
                lblesactivar.Visible = True
                btndesactivar.Visible = True
            ElseIf rdbNo.Checked Then
                PoblarGrid(patron, 0)
                btnactivar.Visible = True
                lblactivar.Visible = True
                lblesactivar.Visible = False
                btndesactivar.Visible = False
            End If
        Else
            If rdbSi.Checked Then
                PoblarGrid(patron, 1)
                btnactivar.Visible = False
                lblactivar.Visible = False
                lblesactivar.Visible = True
                btndesactivar.Visible = True
            ElseIf rdbNo.Checked Then
                PoblarGrid(patron, 0)
                btnactivar.Visible = True
                lblactivar.Visible = True
                lblesactivar.Visible = False
                btndesactivar.Visible = False
            End If
        End If

    End Sub


    Public Sub PoblarGrid(ByVal patron As Integer, ByRef estatus As Integer)
        Try
            Dim ObjB As New Contabilidad.Negocios.CatalogoPuestoFiscalBU
            Dim dataTable = ObjB.Consulta_Puestos_Por_Patron(patron, estatus)
            grdPuestoFiscal.DataSource = dataTable
            DiseñoGrid.DiseñoBaseGrid(viewPuestoFiscal)
            viewPuestoFiscal.IndicatorWidth = 35
            viewPuestoFiscal.OptionsView.ColumnAutoWidth = False
            DiseñoGrid.EstiloColumna(viewPuestoFiscal, "PatronId", "ID", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewPuestoFiscal, "Patron", "Patron", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 300, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewPuestoFiscal, "Puesto", "Puesto", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 150, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewPuestoFiscal, "IDPuesto", "IDPuesto", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewPuestoFiscal, "Usuario", "Usuario Creo", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 150, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewPuestoFiscal, "FechaCreacion", "Fecha Creación", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 195, False, Nothing, "")
            lblTotalRegistros.Text = dataTable.Rows.Count
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim listado As New AltaPuestoFiscalForm
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
                lblesactivar.Visible = True
                btndesactivar.Visible = True
            ElseIf rdbNo.Checked Then
                PoblarGrid(cmbPatrón.SelectedValue, 0)
                btnactivar.Visible = True
                lblactivar.Visible = True
                lblesactivar.Visible = False
                btndesactivar.Visible = False
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btndesactivar.Click
        ElimianrPuesto_PorPatron()
        If rdbSi.Checked Then
            PoblarGrid(cmbPatrón.SelectedValue, 1)
            btnactivar.Visible = False
            lblactivar.Visible = False
        ElseIf rdbNo.Checked Then
            PoblarGrid(cmbPatrón.SelectedValue, 0)
            btnactivar.Visible = True
            lblactivar.Visible = True
        End If
    End Sub
    Public Sub ElimianrPuesto_PorPatron()
        Dim ObjBU As New Contabilidad.Negocios.CatalogoPuestoFiscalBU
        Dim entPuesto As New Entidades.PuestoFiscal
        Dim NumeroFilas As Integer = 0
        Dim PuestoID As String = String.Empty

        Try

            NumeroFilas = viewPuestoFiscal.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(viewPuestoFiscal.GetRowCellValue(viewPuestoFiscal.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(viewPuestoFiscal.IsRowSelected(viewPuestoFiscal.GetVisibleRowHandle(index))) = True Then
                    PuestoID = viewPuestoFiscal.GetRowCellValue(viewPuestoFiscal.GetVisibleRowHandle(index), "IDPuesto").ToString()
                    If PuestoID <> String.Empty Then
                        Dim ventanaConfirmacion As New Tools.ConfirmarForm
                        ventanaConfirmacion.mensaje = "¿Está seguro de desactivar el Puesto fiscal?"
                        ventanaConfirmacion.ShowDialog()
                        If ventanaConfirmacion.DialogResult <> DialogResult.OK Then Return
                        entPuesto.UsuarioCreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        entPuesto.ID_Patron = PuestoID
                        entPuesto.FechaCreo = Date.Now
                        Dim success = ObjBU.EliminarPuesto_PorPatron(0, entPuesto)
                        If success.Resp > 0 Then
                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, success.Mensaje)
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, success.Mensaje)
                        End If
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se selecciono un puesto")
                    End If
                End If
            Next

        Catch ex As Exception

            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El puesto no es valido" + ex.Message)
        End Try
    End Sub
    Public Sub ActivarPuesto_PorPatron()
        Dim ObjBU As New Contabilidad.Negocios.CatalogoPuestoFiscalBU
        Dim entPuesto As New Entidades.PuestoFiscal
        Dim NumeroFilas As Integer = 0
        Dim PuestoID As String = String.Empty

        Try

            NumeroFilas = viewPuestoFiscal.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(viewPuestoFiscal.GetRowCellValue(viewPuestoFiscal.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(viewPuestoFiscal.IsRowSelected(viewPuestoFiscal.GetVisibleRowHandle(index))) = True Then
                    PuestoID = viewPuestoFiscal.GetRowCellValue(viewPuestoFiscal.GetVisibleRowHandle(index), "IDPuesto").ToString()
                    If PuestoID <> String.Empty Then
                        Dim ventanaConfirmacion As New Tools.ConfirmarForm
                        ventanaConfirmacion.mensaje = "¿Está seguro de Activar el Puesto fiscal?"
                        ventanaConfirmacion.ShowDialog()
                        If ventanaConfirmacion.DialogResult <> DialogResult.OK Then Return
                        entPuesto.UsuarioCreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        entPuesto.ID_Patron = PuestoID
                        entPuesto.FechaCreo = Date.Now
                        Dim success = ObjBU.EliminarPuesto_PorPatron(1, entPuesto)
                        If success.Resp > 0 Then
                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, success.Mensaje)
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, success.Mensaje)
                        End If
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se selecciono un puesto")
                    End If
                End If
            Next

        Catch ex As Exception

            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El puesto no es valido" + ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
    Private Sub viewPuestoFiscal_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewPuestoFiscal.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub btnMostrar_Click_1(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim patron = cmbPatrón.SelectedValue
        Dim datatable As New DataTable
        If patron = 0 Then
            If rdbSi.Checked Then
                PoblarGrid(patron, 1)
                btnactivar.Visible = False
                lblactivar.Visible = False
                lblesactivar.Visible = True
                btndesactivar.Visible = True
            ElseIf rdbNo.Checked Then
                PoblarGrid(patron, 0)
                btnactivar.Visible = True
                lblactivar.Visible = True
                lblesactivar.Visible = False
                btndesactivar.Visible = False
            End If
        Else
            If rdbSi.Checked Then
                PoblarGrid(patron, 1)
                btnactivar.Visible = False
                lblactivar.Visible = False
                lblesactivar.Visible = True
                btndesactivar.Visible = True
            ElseIf rdbNo.Checked Then
                PoblarGrid(patron, 0)
                btnactivar.Visible = True
                lblactivar.Visible = True
                lblesactivar.Visible = False
                btndesactivar.Visible = False
            End If
        End If



    End Sub

    Private Sub btnCerrar_Click_1(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnactivar_Click(sender As Object, e As EventArgs) Handles btnactivar.Click
        ActivarPuesto_PorPatron()
        If rdbSi.Checked Then
            PoblarGrid(cmbPatrón.SelectedValue, 1)
            btnactivar.Visible = False
            lblactivar.Visible = False
        ElseIf rdbNo.Checked Then
            PoblarGrid(cmbPatrón.SelectedValue, 0)
            btnactivar.Visible = True
            lblactivar.Visible = True
        End If
    End Sub
End Class