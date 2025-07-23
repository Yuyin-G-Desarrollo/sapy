Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class AgregarMaterialOrdenCompraForm

    Public nave As Integer = 0
    Public proveedor As Integer = 0
    Public ProveedorNombre As String = ""
    Public listaMateriales As New List(Of Integer)

    Public material As String = ""
    Public idmn As Integer = 0
    Public precio As Double = 0
    Public idc As Integer = 0
    Public idp As Integer = 0
    Public factor As Double = 0
    Public almacen As Double = 0
    Public idmoneda As Integer = 0
    Public monedasim As String = ""
    Public monedaabr As String = ""
    Public proveedorTabla As Integer = 0
    Public ProveedorNombreTabla As String = ""
    Public fechaPrograma As String = ""
    Public listParametros As New DataTable
    Public listaParametroID As List(Of String)

    Private Sub AgregarMaterialOrdenCompraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarMaterialesProveedor()
    End Sub

    Public Sub CargarMaterialesProveedor()
        Dim obj As New PreordenCompraBU
        Dim tabla As New DataTable
        Dim accion As Integer = 1
        tabla = obj.MaterialesPorProveedor(nave, proveedor, idmoneda)
        grdMaterial.DataSource = tabla
        lblProveedorText.Text = "- " & ProveedorNombre
        diseñoGrid()
    End Sub

    Public Sub diseñoGrid()
        Me.Cursor = Cursors.WaitCursor

        With grdMaterial.DisplayLayout.Bands(0)
            .Columns(" ").Width = 15
            .Columns("ID").Width = 20
            .Columns("Material").Width = 150
            .Columns("Precio").Width = 20
            .Columns("mone_abreviatura").Width = 35
            .Columns("UMC").Width = 35

            .Columns("Clasificación").Width = 50
            .Columns("Almacen").Width = 35
            .Columns("Clave").Width = 35
            .Columns("Días Entrega").Width = 35
            .Columns("Tipo Material").Width = 40

            .Columns("mone_abreviatura").Header.Caption = "Tipo de Moneda"
            .Columns("IDmn").Hidden = True
            .Columns("IDp").Hidden = True
            .Columns("IDc").Hidden = True
            .Columns("IdMoneda").Hidden = True
            .Columns("mone_simbolo").Hidden = True

            .Columns("Precio").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Almacen").CellAppearance.TextHAlign = HAlign.Right

            .Columns("Almacen").CellActivation = Activation.NoEdit
            .Columns("ID").CellActivation = Activation.NoEdit
            .Columns("Material").CellActivation = Activation.NoEdit
            .Columns("Precio").CellActivation = Activation.NoEdit
            .Columns("Clasificación").CellActivation = Activation.NoEdit
            .Columns("Clave").CellActivation = Activation.NoEdit
            .Columns("Días Entrega").CellActivation = Activation.NoEdit
            .Columns("Tipo Material").CellActivation = Activation.NoEdit
            .Columns("UMC").CellActivation = Activation.NoEdit

            .Columns("Almacen").Header.Caption = "Inventario"

            .Columns("Almacen").Format = "##,##0.00"
            .Columns("Precio").Format = "##,##0.00"

        End With
        grdMaterial.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdMaterial.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        'grdMaterial.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        grdMaterial.DisplayLayout.Override.DefaultRowHeight = 23


        Me.Cursor = Cursors.Default
    End Sub

    Private Sub grdMaterial_DoubleClick(sender As Object, e As EventArgs)
        Try
            material = grdMaterial.ActiveRow.Cells("Material").Value
            idmn = grdMaterial.ActiveRow.Cells("IDmn").Value
            idc = grdMaterial.ActiveRow.Cells("IDc").Value
            precio = grdMaterial.ActiveRow.Cells("Precio").Value
            factor = grdMaterial.ActiveRow.Cells("fd").Value
            idmoneda = grdMaterial.ActiveRow.Cells("IdMoneda").Value
            monedasim = grdMaterial.ActiveRow.Cells("mone_simbolo").Text
            monedaabr = grdMaterial.ActiveRow.Cells("mone_abreviatura").Text
            ProveedorNombreTabla = grdMaterial.ActiveRow.Cells("Proveedor").Value
            proveedorTabla = grdMaterial.ActiveRow.Cells("IDp").Value
            Try
                almacen = grdMaterial.ActiveRow.Cells("Almacen").Value
            Catch ex As Exception
                almacen = 0
            End Try
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If grdMaterial.Rows.Count = 0 Then Return
        Dim grid As DataTable = grdMaterial.DataSource
        listParametros = grid.Clone
        For Each row As UltraGridRow In grdMaterial.Rows
            If CBool(row.Cells(" ").Value) Then
                Dim fila As DataRow = listParametros.NewRow
                For index = 0 To row.Cells.Count - 1 Step 1
                    fila(index) = row.Cells(index).Value
                Next
                listParametros.Rows.Add(fila)
            End If
        Next
        Me.Close()
    End Sub

    Private Sub chSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chSeleccionarTodo.CheckedChanged
        If chSeleccionarTodo.Checked Then
            For Each row In grdMaterial.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next
        Else
            For Each row As UltraGridRow In grdMaterial.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
        End If
    End Sub
End Class