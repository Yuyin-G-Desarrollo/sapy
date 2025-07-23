Imports Infragistics.Win.UltraWinGrid
Imports Infragistics
Public Class EditarRegistrosBahiaForm
    Public ListaClientes As New List(Of Entidades.ClientesAlmacen)
    Public ColorCambio As Boolean = False
    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        If cdlgPicket.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtColor.Text = cdlgPicket.Color.ToString
            ColorCambio = True
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each index As UltraGridRow In grdClientes.Rows
            If index.Cells("Seleccionar").Value = True Then
                Dim cliente As New Entidades.ClientesAlmacen
                cliente.Cadena = index.Cells("idCadena").Value
                cliente.NombreAlmacen = index.Cells("Nombre").Value
                cliente.PActivo = True
                'If index.Cells("idCadena").Value = 131 Then
                '    MsgBox(ListaClientes.Count.ToString)
                '    cliente.PActivo = True

                'End If
                ListaClientes.Add(cliente)
            Else
                Dim cliente As New Entidades.ClientesAlmacen
                cliente.Cadena = index.Cells("idCadena").Value
                cliente.NombreAlmacen = index.Cells("Nombre").Value
                cliente.PActivo = False
                'If index.Cells("idCadena").Value = 131 Then
                '    MsgBox("Aqui")
                '    cliente.PActivo = False
                'End If
                ListaClientes.Add(cliente)
            End If
        Next
        Me.Close()
    End Sub

    Private Sub EditarRegistrosBahiaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objbu As New Negocios.ClientesAlmacenBU
        grdClientes.DataSource = objbu.CargarClientes
        FormatearGrid()
        CargarClientes(ListaClientes)
    End Sub


    Private Sub CargarClientes(ByVal listaClientes As List(Of Entidades.ClientesAlmacen))
        Dim hashlist As New HashSet(Of Entidades.ClientesAlmacen)
        For Each entidad As Entidades.ClientesAlmacen In listaClientes
            hashlist.Add(entidad)
        Next
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdClientes.Rows

            For Each entidad As Entidades.ClientesAlmacen In hashlist
                If row.Cells("idCadena").Value = entidad.Cadena Then
                    row.Cells("Seleccionar").Value = True
                End If
            Next

            ' 
        Next




    End Sub


    Private Sub FormatearGrid()
        Dim checkColumn As UltraGridColumn = grdClientes.DisplayLayout.Bands(0).Columns.Add("Seleccionar", "")
        ' checkColumn.Style = ColumnStyle.
        checkColumn.CellActivation = Activation.AllowEdit
        checkColumn.DataType = GetType(Boolean)
        checkColumn.Header.VisiblePosition = 0
        checkColumn.Layout.PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand)
        With grdClientes.DisplayLayout.Bands(0)
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            .Columns("idCadena").AutoSizeMode = ColumnAutoSizeMode.Default
            .Columns("idCadena").Header.VisiblePosition = 1
            .Columns("idCadena").CellAppearance.TextHAlign = Win.HAlign.Right
            '.Columns("idCadena").AutoSizeMode =
            .Columns("nombre").Header.Caption = "Cliente"
            .Columns("idCadena").Header.Caption = "ID Cadena"
            .Columns("nombre").Header.VisiblePosition = 3
            .Columns("Agente").Header.VisiblePosition = 2
            .Columns("idCadena").Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle
            .Columns("nombre").Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle
            .Columns("idCadena").Layout.PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand)
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdClientes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

    End Sub

    Private Sub Button1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Button1.KeyPress

    End Sub

    Private Sub EditarRegistrosBahiaForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If Char.IsLetter(e.KeyChar) Then

            e.KeyChar = Char.ToUpper(e.KeyChar)

        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim Capacidad As Int32
        Capacidad = CInt(txtCapacidad.Text)
        If Capacidad <= 0 Then
            MessageBox.Show("La bahía no puede establecer la capacidad como 0.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        Else


            For Each index As UltraGridRow In grdClientes.Rows
                If index.Cells("Seleccionar").Value = True Then
                    Dim cliente As New Entidades.ClientesAlmacen
                    cliente.Cadena = index.Cells("idCadena").Value
                    cliente.NombreAlmacen = index.Cells("Nombre").Value
                    cliente.PActivo = True
                    'If index.Cells("idCadena").Value = 131 Then
                    '    MsgBox(ListaClientes.Count.ToString)
                    '    cliente.PActivo = True

                    'End If
                    ListaClientes.Add(cliente)
                Else
                    Dim cliente As New Entidades.ClientesAlmacen
                    cliente.Cadena = index.Cells("idCadena").Value
                    cliente.NombreAlmacen = index.Cells("Nombre").Value
                    cliente.PActivo = False
                    'If index.Cells("idCadena").Value = 131 Then
                    '    MsgBox("Aqui")
                    '    cliente.PActivo = False
                    'End If
                    ListaClientes.Add(cliente)
                End If
            Next
            Me.Close()
        End If
    End Sub

    Private Sub btnCncelar_Click(sender As Object, e As EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        If chkSeleccionarTodo.Checked = True Then
            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdClientes.Rows
                If row.IsFilteredOut = False Then
                    row.Cells("Seleccionar").Value = True
                End If

            Next
        Else
            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdClientes.Rows
                If row.IsFilterRow = False Then
                    row.Cells("Seleccionar").Value = False
                End If

            Next



        End If
    End Sub
End Class