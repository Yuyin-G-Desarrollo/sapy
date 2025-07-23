Public Class ListaBancosForm

    Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltas.Click
        Dim altasForm As New AltasBancosForm
        altasForm.StartPosition = FormStartPosition.CenterScreen
        altasForm.ShowDialog()
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        Dim bancosid As Int32 = 0
        For Each fila As DataGridViewRow In grdBancos.SelectedRows
            For Each columna As DataGridViewCell In fila.Cells
                If (columna.OwningColumn.Name = "ColId") Then
                    bancosid = CInt(columna.Value)
                End If
            Next
        Next

        If bancosid = 0 Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Selecciona los datos del banco que deseas editar"
            mensajeAdvertencia.Show()
        Else
            Dim editarForm As New EditarBancosForm
            editarForm.StartPosition = FormStartPosition.CenterScreen
            editarForm.PBancosid = bancosid
            editarForm.ShowDialog()
        End If

    End Sub

    Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
        grbBancos.Height = 44
    End Sub

    Public Sub AgregarFila(ByVal banco As Entidades.Bancos)
        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        celda = New DataGridViewTextBoxCell
        celda.Value = banco.PBancosId
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = banco.PNombre
        fila.Cells.Add(celda)


        celda = New DataGridViewCheckBoxCell
        celda.Value = banco.PActivo
        fila.Cells.Add(celda)

        grdBancos.Rows.Add(fila)


    End Sub

    Public Sub llenarTabla()
        Dim listaBancos As New List(Of Entidades.Bancos)
        Dim objBU As New Negocios.BancosBU
        listaBancos = objBU.listaBancos(txtNombreBanco.Text, rdoSi.Checked)
        For Each objeto As Entidades.Bancos In listaBancos
            AgregarFila(objeto)
        Next
        Dim col As New DataGridViewTextBoxColumn

        col.Name = "colnum"
        col.HeaderText = "#"
        col.Width = 35
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        ' Indicamos que será la primera columna del control DataGridView
        grdBancos.Columns.Insert(0, col)

        ' Conforme recorremos las filas existentes en el control
        ' DataGridView, escribimos el número de fila
        Dim n As Integer = 1
        For Each row As DataGridViewRow In grdBancos.Rows
            row.Cells(0).Value = n
            n += 1
        Next
        grdBancos.ClearSelection()
    End Sub

    Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
        grbBancos.Height = 132
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        grdBancos.Columns.Remove("colnum")
        grdBancos.Rows.Clear()
        llenarTabla()
    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
        txtNombreBanco.Text = ""
        rdoSi.Checked = True
        grdBancos.Columns.Remove("colnum")
        grdBancos.Rows.Clear()
        llenarTabla()
    End Sub


    Private Sub ListaBancosForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        llenarTabla()
        Me.Location = New Point(0, 0)

        With grdBancos
            .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(0).Width = 35

            .Columns("colId").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("colId").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("colId").Width = 35

            .Columns("colNombre").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("colNombre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("colNombre").Width = 500
            .Columns("colNombre").ToolTipText.ToUpper()

            .Columns("colActivo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("colActivo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("colActivo").Width = 65
        End With

    End Sub



    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        'codigo para mandar llamar id de sucursales '
        ListaSucursalesForm.Show()
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles btnSucursales.Click
        Dim idbancos As Int32 = 0
        For Each fila As DataGridViewRow In grdBancos.SelectedRows

            For Each columna As DataGridViewCell In fila.Cells
                If (columna.OwningColumn.Name = "ColId") Then
                    idbancos = CInt(columna.Value)
                End If
            Next
        Next
        Dim listasucursal As New ListaSucursalesForm
        listasucursal.pidbancos = idbancos
        listasucursal.StartPosition = FormStartPosition.CenterScreen
        listasucursal.ShowDialog()
        'ListaSucursalesForm.Show()
    End Sub




	Private Sub txtNombreBanco_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreBanco.KeyPress
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub
End Class