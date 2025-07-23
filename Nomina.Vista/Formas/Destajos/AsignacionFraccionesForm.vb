Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class AsignacionFraccionesForm
    Dim objBU As New Negocios.CorteDestajosBU

    Public Sub llenarComboNave()
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.SelectedIndex > 0 Then
            cmbDepartamento.DataSource = objBU.DepartamentosConDestajos(cmbNave.SelectedValue.ToString)
            cmbDepartamento.DisplayMember = "grup_name"
            cmbDepartamento.ValueMember = "grup_grupoid"
        End If
    End Sub

    Private Sub AsignacionFraccionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboNave()
    End Sub

    Private Sub cmbNave_DropDownClosed(sender As Object, e As EventArgs) Handles cmbNave.DropDownClosed
        If cmbNave.SelectedIndex > 0 Then
            cmbDepartamento.DataSource = objBU.DepartamentosConDestajos(cmbNave.SelectedValue.ToString)
            cmbDepartamento.DisplayMember = "grup_name"
            cmbDepartamento.ValueMember = "grup_grupoid"
        End If
    End Sub

    Public Sub llenarTablaInformacion()
        If cmbNave.SelectedIndex > 0 Then
            lblNave.ForeColor = Color.Black
            If cmbDepartamento.SelectedIndex > 0 Then
                grdFracciones.DataSource = objBU.FraccionesNaveAsignadas(CInt(cmbNave.SelectedValue), CInt(cmbDepartamento.SelectedValue))
            Else
                grdFracciones.DataSource = objBU.FraccionesNaveAsignadas(CInt(cmbNave.SelectedValue), 0)
            End If

        Else
            lblNave.ForeColor = Color.Red
        End If
    End Sub


    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        llenarTablaInformacion()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        lblNave.ForeColor = Color.Black
        If cmbNave.Items.Count > 2 Then
            cmbNave.SelectedIndex = 0
        Else
            cmbNave.SelectedIndex = 1
        End If
        cmbDepartamento.SelectedIndex = 0
        grdFracciones.DataSource = Nothing
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim editar As New EditarAsignacionFracciones
        If cmbNave.SelectedIndex > 0 Then
            editar.NaveSeleccionada = cmbNave.SelectedValue
        End If
        If cmbDepartamento.SelectedIndex > 0 Then
            editar.DepartamentoSeleccionado = cmbDepartamento.SelectedValue
        End If
        If editar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            llenarTablaInformacion()
        End If
    End Sub

    Private Sub grdFracciones_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdFracciones.InitializeLayout
        grdFracciones.DisplayLayout.Bands(0).Columns(0).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grdFracciones.DisplayLayout.Bands(0).Columns(1).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grdFracciones.DisplayLayout.Bands(0).Columns(2).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grdFracciones.DisplayLayout.Bands(0).Columns(0).Width = 150
        grdFracciones.DisplayLayout.Bands(0).Columns(1).Width = 350
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        e.Layout.Override.RowSelectorAppearance.ForeColor = Color.Black
        e.Layout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        e.Layout.Override.RowSelectorWidth = 50
    End Sub
End Class