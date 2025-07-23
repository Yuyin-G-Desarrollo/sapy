Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class PosibleMaterialesForm
    Public datos As New DataTable
    Public idMaterial As Integer = 0
    Public idMaterialSicy As Integer = 0
    Public descripcionProveedor, claveProveedor As String
    Public NAveDesarrollaIDMAterial As Integer = 0
    Public NombreMaterial As String = String.Empty

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Public noGuardar As Boolean = False
    Public cerrar As Boolean
    Public descripcion As Integer = 0
    Public copiado As Boolean = False
    Private Sub PosibleMaterialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = Windows.Forms.FormWindowState.Maximized
        llenarGrid()
    End Sub
    Public Sub llenarGrid()
        grdPosibleMateriales.DataSource = datos
        With grdPosibleMateriales.DisplayLayout.Bands(0)
            .Columns("ID").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("SKU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("Descripción").Width = 150
            .Columns("Categoria").Width = 50
            .Columns("Tipo").Width = 50
            .Columns("Clasificación").Width = 50
            .Columns("Color").Width = 50
            .Columns("Tamaño").Width = 50
            .Columns("Nave Desarrolla").Width = 60
            .Columns("Exclusivo").Width = 30
            .Columns("ID").Width = 30
            .Columns("Nombre").Width = 50
            .Columns("SKU").Width = 40
            .Columns("nave_naveid").Width = 40
            .Columns("nave_naveid").Hidden = True
            .Columns("Estatus").Width = 40
        End With
        grdPosibleMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdPosibleMateriales.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdPosibleMateriales.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Private Sub grdPosibleMateriales_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdPosibleMateriales.DoubleClickCell
        'If grdPosibleMateriales.Rows.Count > 0 And descripcion = 0 Then
        '    If grdPosibleMateriales.ActiveRow.Selected Then
        '        idMaterial = Convert.ToInt32(grdPosibleMateriales.ActiveRow.Cells("ID").Text)
        '        'idMaterialSicy = Convert.ToInt32(grdPosibleMateriales.ActiveRow.Cells("CódigoSICY").Text)
        '        Me.Close()
        '    End If
        'ElseIf grdPosibleMateriales.Rows.Count > 0 And descripcion = 1 Then
        '    descripcionProveedor = grdPosibleMateriales.ActiveRow.Cells("Descripción").Text
        '    claveProveedor = grdPosibleMateriales.ActiveRow.Cells("Clave Proveedor").Text
        '    Me.Close()
        'End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If grdPosibleMateriales.Rows.Count > 0 And descripcion = 0 Then
            If grdPosibleMateriales.ActiveRow.Selected Then
                idMaterial = Convert.ToInt32(grdPosibleMateriales.ActiveRow.Cells("ID").Text)
                NAveDesarrollaIDMAterial = Convert.ToInt32(grdPosibleMateriales.ActiveRow.Cells("nave_naveid").Text)
                NombreMaterial = grdPosibleMateriales.ActiveRow.Cells("Descripción").Text
                copiado = True
                'idMaterialSicy = Convert.ToInt32(grdPosibleMateriales.ActiveRow.Cells("CódigoSICY").Text)
                Me.Close()
            End If
        ElseIf grdPosibleMateriales.Rows.Count > 0 And descripcion = 1 Then
            descripcionProveedor = grdPosibleMateriales.ActiveRow.Cells("Descripción").Text
            claveProveedor = grdPosibleMateriales.ActiveRow.Cells("Proveedor").Text
            NombreMaterial = grdPosibleMateriales.ActiveRow.Cells("Descripción").Text
            'Descripción
            copiado = True
            Me.Close()
        End If
    End Sub

    Private Sub grdPosibleMateriales_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdPosibleMateriales.ClickCell
        Try
            grdPosibleMateriales.ActiveRow.Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        If descripcion = 0 Then
            objConfirmacion.mensaje = "¿Está seguro que quiere descartar las coincidencias?"
        Else
            objConfirmacion.mensaje = "¿Está seguro que quiere descartar las coincidencias?"
        End If
        If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cerrar = True
            Me.Close()
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        noGuardar = True
        Me.Close()
    End Sub
End Class