Imports Framework.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class NavesAuxForm
    Dim listanaves As New ValueList
    Dim AlturaMaximaPanel As Int32 = 0
#Region "UI"

    Private Sub form_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        LlenarTabla()
        listanaves = obternerNaves()
    End Sub
    Public Function obternerNaves() As ValueList
        Dim listanaves2 As New ValueList
        Dim vNaves As New NavesBU
        Dim tabla As New DataTable
        tabla = vNaves.obtenerNavesComboAuxiliar
        For Each rowDt As DataRow In tabla.Rows
            listanaves2.ValueListItems.Add(rowDt.Item("idNave"), rowDt.Item("Nave").ToString.ToUpper.Trim)
        Next
        Return listanaves2
    End Function

#End Region
    Private Sub btnExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportarExcel.Click
        ExportarExcel()
    End Sub

    Private Sub ExportarExcel()
        Dim vErrorForm As New ErroresForm
        Dim vExitoForm As New ExitoForm
        Try
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = ".xls"
            sfd.Filter = "*.xls|*.xls"
            If sfd.ShowDialog = System.Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            If sfd.FileName.Trim = "" Then
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Dim nombre As String = sfd.FileName

            Me.UltraGridExcelExporter1.Export(grdDatos, nombre)
            System.Diagnostics.Process.Start(nombre)

            vExitoForm.Text = "Naves Auxiliar"
            vExitoForm.mensaje = "Información exportada correctamente"
            vExitoForm.ShowDialog()
        Catch ex As Exception
            vErrorForm.Text = "Espacio Reservado"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub


    Private Sub grdDatos_AfterCellUpdate(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdDatos.AfterCellUpdate


        '------------------

        With grdDatos
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub


        End With

        Dim columna As String = e.Cell.Column.Key.ToUpper.Trim
        If columna = "ACTIVO" Or columna = "NAVESICY" Or columna = "NORDEN" Then
            If columna = "NAVESICY" Then
                actualizarnaveSicy()

            End If
        Else

            Dim valor As Double = e.Cell.Value
            actualizarDia(columna, valor)
        End If


    End Sub
    Public Sub actualizarnaveSicy()
        Dim vConfirmarForm As New ConfirmarForm
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vNaves As New NavesBU
        Dim vErrorForm As New ErroresForm
        Try

            vConfirmarForm.Text = "Naves Auxiliar"
            vConfirmarForm.mensaje = "¿ Está seguro de actualizar el registro?"
            Dim vDialogResult As New DialogResult
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                If IsDBNull(grdDatos.ActiveRow.Cells("NaveSicy").Value) Then
                    vNaves.ActualizarNaveSicy(grdDatos.ActiveRow.Cells("ID_").Value, 0)
                Else
                    vNaves.ActualizarNaveSicy(grdDatos.ActiveRow.Cells("ID_").Value, grdDatos.ActiveRow.Cells("NaveSicy").Value)
                End If


            End If
            Me.Cursor = Cursors.WaitCursor


        Catch ex As Exception
            vErrorForm.Text = "Naves Auxiliares"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
            LlenarTabla()
        End Try

    End Sub
    Public Sub actualizarDia(ByVal columna As String, ByVal valor As Double)
        Dim vConfirmarForm As New ConfirmarForm
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vNaves As New NavesBU
        Dim vErrorForm As New ErroresForm
        Try
            If valor < 1.01 Or columna = "TAMAÑO LOTE" Then
                vConfirmarForm.Text = "Naves Auxiliar"
                vConfirmarForm.mensaje = "¿ Está seguro de actualizar el registro?"
                Dim vDialogResult As New DialogResult
                vDialogResult = vConfirmarForm.ShowDialog
                If vDialogResult = Windows.Forms.DialogResult.OK Then
                    vNaves.actualizarDiaNaveAuxiliar(columna, valor, grdDatos.ActiveRow.Cells("ID_").Value)
                Else

                End If
            Else
                vAdvertenciaForm.Text = "Naves Auxiliar"
                vAdvertenciaForm.mensaje = "El valor de las columnas Lun / Mar / Mie / Jue / Vie / Sab y Dom debe ser un número no mayor a 1.00 "

                vAdvertenciaForm.ShowDialog()

            End If

            Me.Cursor = Cursors.WaitCursor


        Catch ex As Exception
            vErrorForm.Text = "Naves Auxiliares"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            LlenarTabla()
            Me.Cursor = Cursors.Default
        End Try




    End Sub
    Private Sub lnLigar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

        With grdDatos
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With
    End Sub

    Private Sub grdDatos_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdDatos.BeforeRowsDeleted
        e.Cancel = True

    End Sub

    Private Sub grdDatos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdDatos.InitializeLayout

    End Sub

    Private Sub cbNaves_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        LlenarTabla()
    End Sub
    Private Sub LlenarTabla()
        Dim vErrorForm As New ErroresForm
        Dim vNaves As New NavesBU
        Try
            Me.Cursor = Cursors.WaitCursor
            grdDatos.DataSource = Nothing
            grdDatos.DataSource = vNaves.TablaNavesAux
            formatotabla()
        Catch ex As Exception
            vErrorForm.Text = "Naves Auxiliares"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Public Sub formatotablaOrdenar()
        grdDatos.DisplayLayout.Bands(0).Columns.Add("NOrden", "Orden Nuevo")
        grdDatos.DisplayLayout.Bands(0).Columns("Activo").Header.VisiblePosition = 0
        grdDatos.DisplayLayout.Bands(0).Columns("Nombre").Header.VisiblePosition = 1
        grdDatos.DisplayLayout.Bands(0).Columns("NaveSicy").Header.VisiblePosition = 2
        grdDatos.DisplayLayout.Bands(0).Columns("Orden").Header.VisiblePosition = 3
        grdDatos.DisplayLayout.Bands(0).Columns("NOrden").Header.VisiblePosition = 4
        Dim band As UltraGridBand = Me.grdDatos.DisplayLayout.Bands(0)
        With band
            .Columns("ID_").CellActivation = Activation.NoEdit
            .Columns("Nombre").CellActivation = Activation.NoEdit
            .Columns("Activo").CellActivation = Activation.NoEdit
            .Columns("Lun").CellActivation = Activation.NoEdit
            .Columns("Mar").CellActivation = Activation.NoEdit
            .Columns("Mie").CellActivation = Activation.NoEdit
            .Columns("Jue").CellActivation = Activation.NoEdit
            .Columns("Vie").CellActivation = Activation.NoEdit
            .Columns("Sab").CellActivation = Activation.NoEdit
            .Columns("Dom").CellActivation = Activation.NoEdit
            .Columns("nave_idSicy").CellActivation = Activation.NoEdit
            .Columns("NaveSicy").CellActivation = Activation.AllowEdit
            .Columns("Orden").CellActivation = Activation.NoEdit

            .Columns("Activo").Header.Caption = "*Produccion"
            .Columns("Nombre").Header.Caption = "Nave SAY"
            .Columns("NaveSicy").Header.Caption = "*Nave SICY"
            .Columns("Lun").Header.Caption = "*Lun"
            .Columns("Mar").Header.Caption = "*Mar"
            .Columns("Mie").Header.Caption = "*Mie"
            .Columns("Jue").Header.Caption = "*Jue"
            .Columns("Vie").Header.Caption = "*Vie"
            .Columns("Sab").Header.Caption = "*Sab"
            .Columns("Dom").Header.Caption = "*Dom"
            .Columns("Orden").Header.Caption = "Orden Actual"

            .Columns("ID_").Hidden = True
            .Columns("nave_idSicy").Hidden = True

            .Columns("Lun").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Mar").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Mie").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Jue").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Vie").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Sab").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Dom").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Orden").CellAppearance.TextHAlign = HAlign.Right
            .Columns("NOrden").CellAppearance.TextHAlign = HAlign.Right

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdDatos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdDatos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdDatos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDatos.DisplayLayout.Override.RowSelectorWidth = 35
        grdDatos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdDatos.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdDatos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grdDatos.DisplayLayout.Override.SelectTypeRow = SelectType.SingleAutoDrag
        grdDatos.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdDatos.AllowDrop = True
        grdDatos.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select

        band.Columns("Lun").Width = 50
        band.Columns("Mar").Width = 50
        band.Columns("Mie").Width = 50
        band.Columns("Jue").Width = 50
        band.Columns("Vie").Width = 50
        band.Columns("Sab").Width = 50
        band.Columns("Dom").Width = 50
        band.Columns("Activo").Width = 50
        Dim contador As Integer = 1
        For Each rowGrd As UltraGridRow In grdDatos.Rows
            If rowGrd.Cells("Activo").Value Then
                rowGrd.Cells("NOrden").Value = contador
                contador = contador + 1
            Else
                rowGrd.Cells("NOrden").Value = 0
            End If

        Next
    End Sub
    Public Sub formatotabla()

        grdDatos.DisplayLayout.Bands(0).Columns("Activo").Header.VisiblePosition = 0
        grdDatos.DisplayLayout.Bands(0).Columns("Nombre").Header.VisiblePosition = 1
        grdDatos.DisplayLayout.Bands(0).Columns("NaveSicy").Header.VisiblePosition = 2
        grdDatos.DisplayLayout.Bands(0).Columns("Orden").Header.VisiblePosition = 3
        Dim band As UltraGridBand = Me.grdDatos.DisplayLayout.Bands(0)
        With band
            .Columns("ID_").CellActivation = Activation.NoEdit
            .Columns("Nombre").CellActivation = Activation.NoEdit
            .Columns("Activo").CellActivation = Activation.AllowEdit
            .Columns("Lun").CellActivation = Activation.AllowEdit
            .Columns("Mar").CellActivation = Activation.AllowEdit
            .Columns("Mie").CellActivation = Activation.AllowEdit
            .Columns("Jue").CellActivation = Activation.AllowEdit
            .Columns("Vie").CellActivation = Activation.AllowEdit
            .Columns("Sab").CellActivation = Activation.AllowEdit
            .Columns("Dom").CellActivation = Activation.AllowEdit
            .Columns("nave_idSicy").CellActivation = Activation.NoEdit
            .Columns("NaveSicy").CellActivation = Activation.AllowEdit
            .Columns("Orden").CellActivation = Activation.NoEdit

            .Columns("Activo").Header.Caption = "*Producción"
            .Columns("Nombre").Header.Caption = "Nave SAY"
            .Columns("NaveSicy").Header.Caption = "*Nave SICY"
            .Columns("Lun").Header.Caption = "*Lun"
            .Columns("Mar").Header.Caption = "*Mar"
            .Columns("Mie").Header.Caption = "*Mie"
            .Columns("Jue").Header.Caption = "*Jue"
            .Columns("Vie").Header.Caption = "*Vie"
            .Columns("Sab").Header.Caption = "*Sab"
            .Columns("Dom").Header.Caption = "*Dom"
            .Columns("Orden").Header.Caption = "Orden"

            .Columns("NaveSicy").Style = UltraWinGrid.ColumnStyle.DropDown

            .Columns("Lun").Style = ColumnStyle.DoubleNonNegative
            .Columns("Lun").Format = "0.00"
            .Columns("Mar").Style = ColumnStyle.DoubleNonNegative
            .Columns("Mar").Format = "0.00"
            .Columns("Mie").Style = ColumnStyle.DoubleNonNegative
            .Columns("Mie").Format = "0.00"
            .Columns("Jue").Style = ColumnStyle.DoubleNonNegative
            .Columns("Jue").Format = "0.00"
            .Columns("Vie").Style = ColumnStyle.DoubleNonNegative
            .Columns("Vie").Format = "0.00"
            .Columns("Sab").Style = ColumnStyle.DoubleNonNegative
            .Columns("Sab").Format = "0.00"
            .Columns("Dom").Style = ColumnStyle.DoubleNonNegative
            .Columns("Dom").Format = "0.00"

            .Columns("ID_").Hidden = True
            .Columns("nave_idSicy").Hidden = True

            .Columns("Lun").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Mar").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Mie").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Jue").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Vie").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Sab").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Dom").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Orden").CellAppearance.TextHAlign = HAlign.Right

            .Columns("Activo").Style = ColumnStyle.CheckBox


            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdDatos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdDatos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdDatos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDatos.DisplayLayout.Override.RowSelectorWidth = 35
        grdDatos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdDatos.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdDatos.DisplayLayout.Override.CellClickAction = CellClickAction.Default
        grdDatos.DisplayLayout.Override.SelectTypeRow = SelectType.Default
        grdDatos.DisplayLayout.Override.AllowAddNew = AllowAddNew.Default
        grdDatos.AllowDrop = True
        grdDatos.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
        band.Columns("Lun").Width = 50
        band.Columns("Mar").Width = 50
        band.Columns("Mie").Width = 50
        band.Columns("Jue").Width = 50
        band.Columns("Vie").Width = 50
        band.Columns("Sab").Width = 50
        band.Columns("Dom").Width = 50
        band.Columns("Activo").Width = 50



        listanaves = obternerNaves()
        For Each rowGrd As UltraGridRow In grdDatos.Rows
            If rowGrd.Cells("Activo").Value Then
                rowGrd.Cells("NaveSicy").ValueList = listanaves
            End If

        Next
    End Sub
    Private Sub grdDatos_BeforeRowExpanded(sender As Object, e As CancelableRowEventArgs) Handles grdDatos.BeforeRowExpanded
        e.Cancel = True
    End Sub



    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub gridRanking_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdDatos.SelectionDrag

        grdDatos.DoDragDrop(grdDatos.Selected.Rows, DragDropEffects.Move)

    End Sub

    Private Sub gridRanking_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdDatos.DragOver
        e.Effect = DragDropEffects.Move
        Dim grid As UltraGrid = TryCast(sender, UltraGrid)
        Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

        If pointInGridCoords.Y < 20 Then
            Me.grdDatos.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
        ElseIf pointInGridCoords.Y > grid.Height - 20 Then
            Me.grdDatos.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
        End If
    End Sub

    Private Sub gridRanking_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdDatos.DragDrop
        Dim dropIndex As Integer = 0
        Dim uieOver As UIElement = grdDatos.DisplayLayout.UIElement.ElementFromPoint(grdDatos.PointToClient(New Point(e.X, e.Y)))
        Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

        If ugrOver IsNot Nothing Then
            dropIndex = ugrOver.Index
            If dropIndex = -1 Then
                dropIndex = 0
            End If
            Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)

            For Each aRow As UltraGridRow In SelRows
                grdDatos.Rows.Move(aRow, dropIndex)
            Next
            Dim contador As Integer = 1
            For Each rowGrd As UltraGridRow In grdDatos.Rows
                If rowGrd.Cells("Activo").Value Then
                    rowGrd.Cells("NOrden").Value = contador
                    contador = contador + 1

                Else
                    rowGrd.Cells("NOrden").Value = 0
                End If

            Next

        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        btnGuardar.Enabled = True
        btnCancelar.Enabled = True
        lblGuardar.Enabled = True
        lblGuardar.Enabled = True

        btnActualizar.Enabled = False
        lblOrdenar.Enabled = False
        lblExportarExcel.Enabled = False
        btnExportarExcel.Enabled = False
        lblBuscar.Enabled = False
        btnBuscar.Enabled = False
        llenarTablaOrdenamiento()

    End Sub
    Public Sub llenarTablaOrdenamiento()
        Dim vErrorForm As New ErroresForm
        Dim vNaves As New NavesBU
        Try
            Me.Cursor = Cursors.WaitCursor
            grdDatos.DataSource = Nothing
            grdDatos.DataSource = vNaves.TablaNavesAuxOrdenar
            formatotablaOrdenar()
        Catch ex As Exception
            vErrorForm.Text = "Naves Auxiliar"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        btnGuardar.Enabled = False
        btnCancelar.Enabled = False
        lblGuardar.Enabled = False
        lblGuardar.Enabled = False

        btnActualizar.Enabled = True
        lblOrdenar.Enabled = True
        lblExportarExcel.Enabled = True
        btnExportarExcel.Enabled = True
        lblBuscar.Enabled = True
        btnBuscar.Enabled = True
        LlenarTabla()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click


        guardarCambiosActualizacion()


    End Sub
    Public Sub guardarCambiosActualizacion()
        Dim vErrorForm As New ErroresForm
        Dim vConfirmarForm As New ConfirmarForm
        Dim vExitoForm As New ExitoForm
        Dim vNaves As New NavesBU
        Try
            Me.Cursor = Cursors.WaitCursor
            vConfirmarForm.Text = "Nave Auxiliar"
            vConfirmarForm.mensaje = "¿ Está seguro de actualizar el orden de las naves?"
            Dim vDialogResult As New DialogResult
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then

                Dim i As Integer = 1
                For Each rowGrd As UltraGridRow In grdDatos.Rows
                    vNaves.Actualizar(CInt(rowGrd.Cells("ID_").Value), i)
                    i += 1
                Next
                vExitoForm.Text = "Naves Auxiliar"
                vExitoForm.mensaje = "Registros actualizados con éxito"
                vExitoForm.ShowDialog()
                btnGuardar.Enabled = False
                btnCancelar.Enabled = False
                lblGuardar.Enabled = False
                lblGuardar.Enabled = False
                btnActualizar.Enabled = True
                lblOrdenar.Enabled = True
                lblExportarExcel.Enabled = True
                btnExportarExcel.Enabled = True
                lblBuscar.Enabled = True
                btnBuscar.Enabled = True
                LlenarTabla()
            End If
        Catch ex As Exception
            vErrorForm.Text = "Naves Auxiliar"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Public Sub actualizarEstatusNave()
        Dim vConfirmarForm As New ConfirmarForm
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vNaves As New NavesBU
        Dim vErrorForm As New ErroresForm
        Dim valor As Integer
        Try

            vConfirmarForm.Text = "Naves Auxiliar"
            vConfirmarForm.mensaje = "¿ Está seguro de clasificar esta nave como nave de produccion ?"
            Dim vDialogResult As New DialogResult
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then

                If grdDatos.ActiveRow.Cells("Activo").Text Then
                    valor = 1
                Else
                    valor = 0
                End If
                vNaves.ActualizarNaveProduccion(grdDatos.ActiveRow.Cells("ID_").Value, CInt(valor))
                LlenarTabla()
            Else
                If grdDatos.ActiveRow.Cells("Activo").Text Then
                    valor = 0
                Else
                    valor = 1
                End If
                grdDatos.ActiveRow.Cells("Activo").Value = valor
            End If
            Me.Cursor = Cursors.WaitCursor


        Catch ex As Exception
            vErrorForm.Text = "Naves Auxiliar"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub grdDatos_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdDatos.BeforeCellUpdate

    End Sub

    Private Sub grdDatos_CellChange(sender As Object, e As CellEventArgs) Handles grdDatos.CellChange
        With grdDatos
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        Select Case e.Cell.Column.Key.ToUpper.Trim
            Case "ACTIVO"
                actualizarEstatusNave()
            Case Else
                Exit Sub
        End Select



    End Sub
End Class