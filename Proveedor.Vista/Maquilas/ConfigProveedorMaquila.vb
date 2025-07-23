Imports Tools
Imports Proveedores.BU
Imports Infragistics.Win.UltraWinGrid

Public Class ConfigProveedorMaquila
    Dim adv As New AdvertenciaForm
    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub ConfigProveedorMaquila_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboNaves()
        llenarComboProveedores()
    End Sub
    Public Sub llenarComboNaves()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.Items.Count = 2 Then
            cmbNave.SelectedIndex = 1
        End If
    End Sub
    Private Sub getProveedoresNave()
        Dim obj As New ConfigProveedorMaquilaBU
        Dim lstProvee As DataTable
        lstProvee = obj.getProveedoresNave(cmbNave.SelectedValue)
        grdConfig.DataSource = lstProvee
        diseño()
    End Sub
    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        If cmbNave.SelectedIndex > 0 Then
            getProveedoresNave()
        End If
    End Sub
    Public Sub llenarComboProveedores()
        Dim obj As New ConfigProveedorMaquilaBU
        Dim lstProvee As DataTable
        lstProvee = obj.getProveedores()
        If Not lstProvee.Rows.Count = 0 Then
            cmbProveedor.DataSource = lstProvee
            cmbProveedor.DisplayMember = "RazonSocial"
            cmbProveedor.ValueMember = "IdProveedor"
        End If
    End Sub

    Private Sub btnXML_Click(sender As Object, e As EventArgs) Handles btnXML.Click
        If cmbNave.SelectedIndex > 0 Then
            If cmbProveedor.SelectedIndex >= 0 Then
                Try
                    Dim obj As New ConfigProveedorMaquilaBU
                    If Not obj.verificarProveedorConfig(cmbProveedor.SelectedValue, cmbNave.SelectedValue) Then
                        obj.insertProveedorConfig(cmbNave.SelectedValue, cmbProveedor.SelectedValue)
                        getProveedoresNave()
                    End If
                    
                Catch ex As Exception
                    adv.mensaje = "Surgió algo inesperado. Detalles: " & ex.Message
                    adv.ShowDialog()
                End Try
               
            Else
                adv.mensaje = "Seleccione una proveedor."
                adv.ShowDialog()
            End If
        Else
            adv.mensaje = "Seleccione una nave."
            adv.ShowDialog()
        End If
    End Sub
    Public Sub diseño()
        Try
            With grdConfig.DisplayLayout.Bands(0)
                .Columns("mapo_maquilaproveedorid").Hidden = True
                .Columns("Nombre Comercial").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Plazo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Razón Social").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                '.Columns("Seleccion").Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
                .Columns("Seleccionar").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns("Plazo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                '.Columns("Seleccion").Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection
                .Columns("Seleccionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .Columns("Seleccionar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                .Columns("Seleccionar").Header.Caption = " "
                .Columns("Seleccionar").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
                .Columns("Seleccionar").Width = 1
                .Columns("Plazo").Width = 80
            End With
            grdConfig.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdConfig.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdConfig.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
            'pintarceldas()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rows As New DataTable
        rows = grdConfig.DataSource
        For Each row As DataRow In rows.Rows
            If CBool(row("Seleccionar")) Then
                Try
                    Dim obj As New ConfigProveedorMaquilaBU
                    obj.eliminarProveedorConfig(row("mapo_maquilaproveedorid"))
                    row.Delete()
                Catch ex As Exception
                    adv.mensaje = "Surgió algo inesperado. Detalles: " & ex.Message
                    adv.ShowDialog()
                End Try
            End If
        Next
        getProveedoresNave()
    End Sub
End Class