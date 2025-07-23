Imports Proveedores.BU
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports Entidades
Imports Tools


Public Class InventarioInicialForm

    Public list As New List(Of Integer)
    Public idMaterialNave As Integer = 0
    Public idMaterial As Integer = 0
    Public cerrado As Boolean = True


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        guardar()
    End Sub
    Private Sub guardar()
        Try
            Dim inv As New MaterialInventario
            Dim obj As New MaterialesBU
            Dim datos As New DataTable
            datos = grdMateriales.DataSource
            Dim m As New MaterialInventario
            For Each row As DataRow In datos.Rows
                m = New MaterialInventario
                m.invn_cantidad = row("Cantidad")
                m.invn_factorconversion = row("factorConversion")
                m.invn_naveid = row("mn_idNave")
                m.invn_inventariototal = row("Cantidad")
                m.invn_movimientoinventarioid = 1
                m.invn_precio = row("Precio")
                m.invn_proveedorid = row("prma_provedorid")
                m.invn_umc = row("prma_idumproveedor")
                m.invn_ump = row("prma_idumproduccion")
                m.invn_materialnaveid = row("mn_materialNaveid")
                m.invn_monedaid = row("IdMoneda")
                obj.insertarInventarioNave(m)
            Next
            cerrado = False
            obj.AutorizarMaterialProduccion(list)
            Dim msg As New ExitoForm
            msg.mensaje = "Materiales Agregados al Inventario."
            msg.ShowDialog()
            Me.Close()
        Catch ex As Exception
            Dim msg As New AdvertenciaForm
            msg.mensaje = "Surgió un problema: " & ex.Message
            msg.ShowDialog()
        End Try
    End Sub


    Private Sub InventarioInicialForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarGrid()
    End Sub
    Public Sub llenarGrid()

        Dim obj As New MaterialesBU
        grdMateriales.DataSource = Nothing

        If list.Count > 0 Then
            grdMateriales.DataSource = obj.getMaterialesParaAgregarEnInventario(list)
        ElseIf idMaterialNave > 0 Then
            grdMateriales.DataSource = obj.getMaterialParaAgregarEnInventario(idMaterialNave)
        ElseIf idMaterial > 0 Then
            grdMateriales.DataSource = obj.getMaterialParaAgregarEnInventario(idMaterial)
        End If

        With grdMateriales.DisplayLayout.Bands(0)
            .Columns("mn_idNave").Hidden = True
            .Columns("mn_materialNaveid").Hidden = True
            .Columns("prma_provedorid").Hidden = True
            .Columns("prma_idumproveedor").Hidden = True
            .Columns("prma_idumproduccion").Hidden = True
            .Columns("factorConversion").Hidden = True
            .Columns("Precio").Format = "##,##0.00"
            .Columns("Cantidad").Format = "##,##0.00"
            .Columns("Precio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Nave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Material").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Proveedor").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("SKU").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("UMC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("SKU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Precio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("Precio").Width = 50
            .Columns("Material").Width = 300
            .Columns("Proveedor").Width = 300
            .Columns("IdMoneda").Hidden = True
            .Columns("MonedaSimbolo").Hidden = True
            .Columns("mone_nombre").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            .Columns("mone_nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        End With
        grdMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'grdMateriales.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdMateriales.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        pintarceldas()
    End Sub

    Private Sub grdMateriales_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdMateriales.BeforeRowsDeleted
        e.Cancel = True
    End Sub
    Public Sub pintarceldas()
        Dim conPrecio As Integer = 0
        Dim sinPrecio As Integer = 0
        Dim i As Integer = 0
        Do
            Try
                If grdMateriales.Rows(i).Cells("Cantidad").Value <= 0 Then
                    grdMateriales.Rows(i).Cells("Cantidad").Appearance.BackColor = Color.Salmon
                Else
                    grdMateriales.Rows(i).Cells("Cantidad").Appearance.BackColor = Color.YellowGreen
                End If
            Catch ex As Exception
            End Try
            i += 1
        Loop While i < grdMateriales.Rows.Count
    End Sub

    Private Sub grdMateriales_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles grdMateriales.KeyPress
        If grdMateriales.Rows.Count > 0 Then
            Try
                If Not grdMateriales.ActiveCell.IsFilterRowCell Then
                    If (Convert.ToInt32(e.KeyChar) = 8) Then
                        ' Se ha pulsado la tecla retroceso 
                        Return
                    End If

                    If Char.IsDigit(e.KeyChar) Then
                        e.Handled = False
                    ElseIf Char.IsControl(e.KeyChar) Then
                        e.Handled = False
                    ElseIf e.KeyChar = "." And Not grdMateriales.ActiveCell.Text.IndexOf(".") Then
                        e.Handled = True
                        Return
                    ElseIf e.KeyChar = "." Then
                        e.Handled = False
                    Else
                        e.Handled = True
                    End If
                    Dim separadorDecimal As String = _
                  Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator

                    Dim index As Integer = grdMateriales.ActiveCell.Text.IndexOf(separadorDecimal)

                    If (index >= 0) Then
                        Dim decimales As String = grdMateriales.ActiveCell.Text.Substring(index + 1)
                        e.Handled = (decimales.Length = 2)
                    End If

                    ''If (txtCantidad.SelectionLength > 0) Then e.Handled = False
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub grdMateriales_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles grdMateriales.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Enter Then
                grdMateriales.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdMateriales.DisplayLayout.Bands(0)
                If grdMateriales.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdMateriales.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdMateriales.ActiveCell = nextRow.Cells(grdMateriales.ActiveCell.Column)
                    e.Handled = True
                    grdMateriales.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdMateriales_CellChange(sender As Object, e As CellEventArgs) Handles grdMateriales.CellChange
        Try
            pintarceldas()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdMateriales_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdMateriales.AfterCellUpdate
        Try
            If Not grdMateriales.ActiveCell.IsFilterRowCell Then
                Dim conPrecio As Integer = 0
                Dim sinPrecio As Integer = 0
                If e.Cell.Text.Trim = "" Then
                    e.Cell.Value = 0
                End If
                Dim i As Integer = 0
                Do
                    If grdMateriales.Rows(i).Cells("Cantidad").Value = 0 Then
                        grdMateriales.Rows(i).Cells("Cantidad").Appearance.BackColor = Color.Salmon
                    Else
                        grdMateriales.Rows(i).Cells("Cantidad").Appearance.BackColor = Color.YellowGreen
                    End If
                    i = i + 1
                Loop While i < grdMateriales.Rows.Count
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub InventarioInicialForm_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not cerrado = False Then
            guardar()
        End If

    End Sub
End Class