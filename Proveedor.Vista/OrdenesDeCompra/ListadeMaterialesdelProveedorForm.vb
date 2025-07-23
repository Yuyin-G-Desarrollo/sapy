Imports Infragistics.Win.UltraWinGrid
Imports Proveedores.BU
Imports Tools

Public Class ListadeMaterialesdelProveedorForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm
    Public tamanoTabla As Integer
    Dim numeroSelecciones As Integer
    Public list As New List(Of Integer)
    Public proveevorid As Integer
    Public naveid As Integer

    Private Sub ListadeMaterialesdelProveedorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If proveevorid <> 0 And naveid <> 0 Then
            LlenarTabla(proveevorid, naveid)
            disenioGrid()
        End If

    End Sub

    Public Sub LlenarTabla(ByVal idproveedor As Integer, ByVal naveid As Integer)
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New OrdenesDeCompra
        Dim dtListaProveedores As New DataTable
        grdListaMateriales.DataSource = Nothing
        dtListaProveedores = objBU.ListaMateriales(idproveedor, naveid)
        grdListaMateriales.DataSource = dtListaProveedores
        Me.Cursor = Windows.Forms.Cursors.Default

        Return
    End Sub

    Public Sub disenioGrid()

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        With grdListaMateriales.DisplayLayout.Bands(0)

            .Columns("Seleccion").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Seleccion").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Seleccion").Header.Caption = " "
            .Columns("Seleccion").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("#").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("SKU").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Descripción").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Clave Proveedor").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Clasificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("UMP").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("UMC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Tiempo Entrega").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Precio Unitario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ID").Hidden = True
            .Columns("Precio Unitario").Format = "##,##0.00"

            .Columns("Tiempo Entrega").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Precio Unitario").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Seleccion").Width = 4
            .Columns("#").Width = 20
            .Columns("SKU").Width = 60
            .Columns("Descripción").Width = 100
            .Columns("UMP").Width = 70
            .Columns("UMC").Width = 70
            .Columns("Clasificación").Width = 75
            grdListaMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            Me.Cursor = Windows.Forms.Cursors.Default
        End With
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        objConfirmacion.mensaje = "¿Está seguro de limpiar todas las selecciones realizadas?"
        If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LlenarTabla(proveevorid, naveid)
            disenioGrid()
        End If

    End Sub

    Public Sub buscarSeleccionados()

        tamanoTabla = grdListaMateriales.Rows.Count()
        If tamanoTabla > 0 Then
            For value As Integer = 0 To tamanoTabla - 1
                If grdListaMateriales.Rows(value).Cells("Seleccion").Text = 1 Then
                    numeroSelecciones = numeroSelecciones + 1
                End If
            Next
            For value2 As Integer = 0 To tamanoTabla - 1
                If grdListaMateriales.Rows(value2).Cells("Seleccion").Text = 1 Then
                    list.Add(grdListaMateriales.Rows(value2).Cells("ID").Text)
                End If
            Next
        Else
            objAdvertencia.mensaje = "No hay materiales  seleccionados de la lista de materiales."
            objAdvertencia.ShowDialog()
        End If
        
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim tamanoTabla = grdListaMateriales.Rows.Count()
        If tamanoTabla > 0 Then
            For value As Integer = 0 To tamanoTabla - 1
                If grdListaMateriales.Rows(value).Cells("Seleccion").Text = 1 Then
                    numeroSelecciones = numeroSelecciones + 1
                End If
            Next
        End If
        If numeroSelecciones > 0 Then
            objConfirmacion.mensaje = "¿Está seguro que desea agregar los materiales a la orden de compra?"
            If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                buscarSeleccionados()
            End If
        Else
            objAdvertencia.mensaje = "No hay materiales  seleccionados de la lista de materiales."
            objAdvertencia.ShowDialog()
        End If
        
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class