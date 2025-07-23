Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class EditarAsignacionFracciones

    Public NaveSeleccionada As Integer
    Public DepartamentoSeleccionado As Integer

    Dim objBU As New Negocios.CorteDestajosBU
    Private Sub EditarAsignacionFracciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnGuardar.DialogResult = Windows.Forms.DialogResult.None
        grdFracciones.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdFracciones.DisplayLayout.Override.RowSelectorWidth = 35
        grdFracciones.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If NaveSeleccionada > 0 Then
            cmbNave.SelectedValue = NaveSeleccionada
        End If
        If cmbNave.SelectedIndex > 0 Then
            cmbDepartamento.DataSource = objBU.DepartamentosConDestajos(cmbNave.SelectedValue.ToString)
            cmbDepartamento.DisplayMember = "grup_name"
            cmbDepartamento.ValueMember = "grup_grupoid"
            If DepartamentoSeleccionado > 0 Then
                cmbDepartamento.SelectedValue = DepartamentoSeleccionado
                If cbSinDepartamento.Checked = True Then 'MOSTRAR FRACCIONES NO ASIGNADAS

                    If cmbNave.SelectedIndex > 0 Then
                        Dim tabla As New DataTable
                        tabla = objBU.FraccionesNaveSinAsignar(CInt(cmbNave.SelectedValue))
                        If tabla.Rows.Count > 0 Then
                            grdFracciones.DataSource = tabla
                            grdFracciones.DisplayLayout.Bands(0).Columns("Asignar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                            grdFracciones.DisplayLayout.Bands(0).Columns("Asignar").Width = 15
                        End If
                    End If
                Else 'MOSTRAR TODAS LAS FRACCIONES MARCANDO LAS QUE YA ESTAN ASIGNADAS AL DEPARTAMENTO
                    If cmbNave.SelectedIndex > 0 And cmbDepartamento.SelectedIndex > 0 Then
                        Dim tabla As New DataTable
                        tabla = objBU.FraccionesNaveEditar(CInt(cmbNave.SelectedValue), CInt(cmbDepartamento.SelectedValue))
                        grdFracciones.DataSource = tabla
                        If tabla.Rows.Count > 0 Then
                            grdFracciones.DisplayLayout.Bands(0).Columns("Asignar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                            grdFracciones.DisplayLayout.Bands(0).Columns("Asignar").Width = 15
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmbNave_DropDownClosed(sender As Object, e As EventArgs) Handles cmbNave.DropDownClosed
        If cmbNave.SelectedIndex > 0 Then
            cmbDepartamento.DataSource = objBU.DepartamentosConDestajos(cmbNave.SelectedValue.ToString)
            cmbDepartamento.DisplayMember = "grup_name"
            cmbDepartamento.ValueMember = "grup_grupoid"
        End If
    End Sub

    Private Sub grdFracciones_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdFracciones.InitializeLayout
        grdFracciones.DisplayLayout.Bands(0).Columns("Fracción").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grdFracciones.DisplayLayout.Bands(0).Columns("Asignar").Width = 40
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        e.Layout.Override.RowSelectorAppearance.ForeColor = Color.Black
        e.Layout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        e.Layout.Override.RowSelectorWidth = 50
    End Sub

    Private Sub cbSinDepartamento_CheckedChanged(sender As Object, e As EventArgs) Handles cbSinDepartamento.CheckedChanged
        'Dim msj As New ConfirmarForm
        'msj.mensaje = "Perderá los cambios sin guardar. ¿Desea continuar?"
        'If msj.ShowDialog = Windows.Forms.DialogResult.OK Then
        If cbSinDepartamento.Checked = True Then 'MOSTRAR FRACCIONES NO ASIGNADAS

            If cmbNave.SelectedIndex > 0 Then
                Dim tabla As New DataTable
                tabla = objBU.FraccionesNaveSinAsignar(CInt(cmbNave.SelectedValue))
                If tabla.Rows.Count > 0 Then
                    grdFracciones.DataSource = tabla

                    grdFracciones.DisplayLayout.Bands(0).Columns("Asignar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

                End If
            End If
        Else 'MOSTRAR TODAS LAS FRACCIONES MARCANDO LAS QUE YA ESTAN ASIGNADAS AL DEPARTAMENTO
            If cmbNave.SelectedIndex > 0 And cmbDepartamento.SelectedIndex > 0 Then
                Dim tabla As New DataTable
                tabla = objBU.FraccionesNaveEditar(CInt(cmbNave.SelectedValue), CInt(cmbDepartamento.SelectedValue))
                grdFracciones.DataSource = tabla
                If tabla.Rows.Count > 0 Then

                    grdFracciones.DisplayLayout.Bands(0).Columns("Asignar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                End If
            End If
        End If
        'End If
    End Sub

    Private Sub cmbDepartamento_DropDownClosed(sender As Object, e As EventArgs) Handles cmbDepartamento.DropDownClosed
        If cmbDepartamento.SelectedIndex > 0 Then
            If cbSinDepartamento.Checked = True Then
                Dim tabla As New DataTable
                tabla = objBU.FraccionesNaveSinAsignar(CInt(cmbNave.SelectedValue))
                grdFracciones.DataSource = tabla
                If tabla.Rows.Count > 0 Then
                    grdFracciones.DisplayLayout.Bands(0).Columns("Asignar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                End If
            Else

                Dim tabla As New DataTable
                tabla = objBU.FraccionesNaveEditar(CInt(cmbNave.SelectedValue), CInt(cmbDepartamento.SelectedValue))
                grdFracciones.DataSource = tabla
                If tabla.Rows.Count > 0 Then
                    grdFracciones.DisplayLayout.Bands(0).Columns("Asignar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                End If
            End If
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If cmbNave.SelectedIndex > 0 And cmbDepartamento.SelectedIndex > 0 Then
            lblNave.ForeColor = Color.Black
            lblDepartamento.ForeColor = Color.Black
            Dim fraccionSeleccionada As String
            fraccionSeleccionada = String.Empty
            Dim msj As New ConfirmarForm
            For Each row As UltraGridRow In grdFracciones.Rows
                If CBool(row.Cells("Asignar").Value) Then
                    fraccionSeleccionada += row.Cells("Fracción").Value.ToString + "|"
                End If

            Next
            If fraccionSeleccionada.Length <= 0 Then
                Dim ms As New AdvertenciaForm
                ms.mensaje = "No hay fracciones seleccionadas."
                ms.ShowDialog()
            Else
                msj.mensaje = "¿Esta seguro de asignar las fracciones seleccionadas al departamento " + cmbDepartamento.SelectedText + "?"
                If msj.ShowDialog = Windows.Forms.DialogResult.OK Then


                    Dim restaurar = 1
                    If cbSinDepartamento.Checked = True Then
                        restaurar = 0
                    End If
                    objBU.guardarAsignacionFracciones(CInt(cmbNave.SelectedValue), CInt(cmbDepartamento.SelectedValue), fraccionSeleccionada, restaurar)
                    Dim msj2 As New ExitoForm
                    msj2.mensaje = "Fracciones asignadas al departamento " + cmbDepartamento.SelectedText + " correctamente."
                    btnGuardar.DialogResult = Windows.Forms.DialogResult.OK
                    msj2.ShowDialog()
                    Me.Close()
                End If
            End If

        Else
            If cmbNave.SelectedIndex <= 0 Then
                lblNave.ForeColor = Color.Red
            End If

            If cmbDepartamento.SelectedIndex <= 0 Then
                lblDepartamento.ForeColor = Color.Red
            End If
        End If

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Me.Close()
    End Sub
End Class