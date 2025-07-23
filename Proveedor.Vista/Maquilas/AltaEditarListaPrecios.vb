Imports System.Drawing
Imports Entidades
Imports Infragistics.Win.UltraWinGrid
Imports Proveedores.BU
Imports Tools

Public Class AltaEditarListaPrecios
    Public idLista As Integer = 0
    Public nuevo As Boolean = False
    Public editar As Boolean = False
    Public idNave As Integer = 0
    Public idEmpresa As Integer = 0
    Public idNavetmp As Integer = 0
    Public idMarca As String = ""
    Public idColeccion As String = ""
    Public nombreLista As String = ""
    Private ReadOnly adv As New AdvertenciaForm
    Private ReadOnly exito As New ExitoForm
    Private listaOriginal As List(Of String)

    Private Sub AltaEditarListaPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listaOriginal = New List(Of String)
        LlenarComboNaves()
        LlenarMarcasAltas()
        LlenarColecciones()
        LlenarGrid()
        cmbColeccion.Enabled = False
        cmbMarca.Enabled = False
        If nuevo = True Then
            cmbColeccion.Enabled = False
            cmbMarca.Enabled = False
        Else
            cmbNave.Enabled = False
        End If

        txtNombreLista.Text = nombreLista
        cmbMarca.SelectedValue = idMarca
        cmbColeccion.SelectedValue = idColeccion
        cmbNave.SelectedValue = idNave
        WindowState = Windows.Forms.FormWindowState.Maximized
    End Sub

    Public Sub LlenarGrid()
        Dim obj As New ListaPreciosProdBU
        Dim tipoprecio As String = lblTipoPrecio.Text
        Dim datos = If(nuevo,
            obj.getModelos(obj.getNaveSIcy(idNave), idMarca, idColeccion),
            obj.getPreciosModelos(idLista, obj.getNaveSIcy(idNave), idMarca, idColeccion, tipoprecio))
        grdListas.DataSource = datos
        lblTotalEstilos.Text = "" & grdListas.Rows.Count
        DisenioGrid()
    End Sub

    Public Sub LlenarComboNaves()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.Items.Count = 2 Then
            cmbNave.SelectedIndex = 1
        End If
    End Sub

    Public Sub LlenarMarcas()
        Dim obj As New ListaPreciosProdBU
        Dim lst As DataTable = obj.getMarcas(idNave, idEmpresa)
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbMarca.DataSource = lst
            cmbMarca.DisplayMember = "Marca"
            cmbMarca.ValueMember = "IdMarca"
        End If
    End Sub

    Public Sub LlenarMarcasAltas()
        Dim obj As New ListaPreciosProdBU
        Dim lst As DataTable = obj.getMarcasAltas(idNave)
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbMarca.DataSource = lst
            cmbMarca.DisplayMember = "Marca"
            cmbMarca.ValueMember = "IdMarca"
        End If
    End Sub

    Public Sub LlenarColecciones()
        Dim obj As New ListaPreciosProdBU
        Dim lst As DataTable = obj.getColecciones(idNave, idMarca)
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbColeccion.DataSource = lst
            cmbColeccion.DisplayMember = "Coleccion"
            cmbColeccion.ValueMember = "IdColeccion"
        End If
    End Sub

    Private Sub CmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        If cmbNave.SelectedIndex > 0 Then
            idNave = cmbNave.SelectedValue
            If nuevo = True Then
                cmbMarca.Enabled = True
                LlenarMarcasAltas()
            End If
        End If
    End Sub

    Private Sub CmbMarca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarca.SelectedIndexChanged
        If cmbMarca.SelectedIndex > 0 Then
            idMarca = cmbMarca.SelectedValue

            If nuevo = True Then
                cmbColeccion.Enabled = True
                txtNombreLista.Text = cmbMarca.Text
                LlenarColecciones()
            End If
        Else
            cmbColeccion.Enabled = False
        End If
    End Sub

    Private Sub CmbColeccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColeccion.SelectedIndexChanged
        If cmbColeccion.SelectedIndex > 0 Then
            idColeccion = cmbColeccion.SelectedValue
            If nuevo = True Then
                txtNombreLista.Text = cmbMarca.Text & " " & cmbColeccion.Text
                idNave = cmbNave.SelectedValue
                LlenarGrid()
            End If

        End If
    End Sub

    Public Sub DisenioGrid()
        Try
            With grdListas.DisplayLayout.Bands(0)
                If nuevo = False Then
                    .Columns("idLista").Hidden = True
                    .Columns("idPrecio").Hidden = True
                    .Columns("Estatus").Hidden = True
                Else

                End If
                .Columns("IdColeccion").Hidden = True
                .Columns("IdMarca").Hidden = True
                .Columns("IdNave").Hidden = True
                .Columns("Seleccion").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns("Seleccion").CellActivation = Activation.AllowEdit
                .Columns("Seleccion").Style = ColumnStyle.CheckBox
                .Columns("Seleccion").Header.Caption = " "
                .Columns("Vacía").Header.Caption = " "
                .Columns("Seleccion").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

                .Columns("Marca").CellActivation = Activation.NoEdit
                If grdListas.DisplayLayout.Bands(0).Columns.Contains("capturó") Then
                    .Columns("Capturó").CellActivation = Activation.NoEdit
                End If
                If grdListas.DisplayLayout.Bands(0).Columns.Contains("FCaptura") Then
                    .Columns("FCaptura").CellActivation = Activation.NoEdit
                    .Columns("FCaptura").Style = ColumnStyle.DateTime
                End If
                If grdListas.DisplayLayout.Bands(0).Columns.Contains("Modifica") Then
                    .Columns("Modifica").CellActivation = Activation.NoEdit
                End If
                If grdListas.DisplayLayout.Bands(0).Columns.Contains("FModificación") Then
                    .Columns("FModificación").CellActivation = Activation.NoEdit
                    .Columns("FModificación").Style = ColumnStyle.DateTime
                End If
                .Columns("Colección").CellActivation = Activation.NoEdit
                .Columns("*Precio").Format = "####0.00"
                .Columns("Modelo").CellActivation = Activation.NoEdit
                .Columns("Color").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Piel").CellActivation = Activation.NoEdit

                .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, True)
                .Columns("Modelo").Width = 150
                .Columns("Corrida").Width = 50
                .Columns("Seleccion").Width = 10
                .Columns("Vacía").Width = 2
                .Columns("Piel").Width = 200
                .Columns("Color").Width = 200

            End With
            grdListas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdListas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            Pintarceldas()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GrdListas_CellChange(sender As Object, e As CellEventArgs) Handles grdListas.CellChange
        ContarRegistrosSeleccionados(e)
    End Sub

    Private Sub ContarRegistrosSeleccionados(e As CellEventArgs)
        Try
            Dim Seleccionados As Integer = 0
            If e.Cell.Column.ToString = "seleccion" Then
                grdListas.ActiveRow.Cells("seleccion").Value = If(e.Cell.Value, False, True)
                For Each row As UltraGridRow In grdListas.Rows.GetFilteredInNonGroupByRows
                    If row.Cells("Seleccion").Value Then
                        Seleccionados += 1
                    End If
                Next
                lblTotalSelec.Text = Format(Seleccionados, "###,###,##0")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GrdListas_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles grdListas.AfterRowFilterChanged
        Try
            Dim Seleccionados As Integer = 0
            For Each row As UltraGridRow In grdListas.Rows.GetFilteredInNonGroupByRows
                If row.Cells("Seleccion").Value Then
                    Seleccionados += 1
                End If
            Next
            lblTotalSelec.Text = Format(Seleccionados, "###,###,##0")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtPrecioUnitario_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtPrecioUnitario.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtPrecioUnitario.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged
        For Each row As UltraGridRow In grdListas.Rows
            row.Cells("Seleccion").Value = False
        Next
        If chkSeleccionar.Checked Then
            For Each row As UltraGridRow In grdListas.Rows.GetFilteredInNonGroupByRows
                row.Cells("Seleccion").Value = True
            Next
        Else
            For Each row As UltraGridRow In grdListas.Rows.GetFilteredInNonGroupByRows
                row.Cells("Seleccion").Value = False
            Next
        End If
        Try
            Dim Seleccionados As Integer = 0
            For Each row As UltraGridRow In grdListas.Rows.GetFilteredInNonGroupByRows
                If row.Cells("Seleccion").Value Then
                    Seleccionados += 1
                End If
            Next
            lblTotalSelec.Text = Format(Seleccionados, "###,###,##0")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GrdListas_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles grdListas.KeyPress
        If grdListas.Rows.Count > 0 Then
            Try
                If Not grdListas.ActiveCell.IsFilterRowCell Then
                    If Char.IsDigit(e.KeyChar) Then
                        e.Handled = False
                    ElseIf Char.IsControl(e.KeyChar) Then
                        e.Handled = False
                    ElseIf e.KeyChar = "." And Not txtPrecioUnitario.Text.IndexOf(".") Then
                        e.Handled = True
                    ElseIf e.KeyChar = "." Then
                        e.Handled = False
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub Pintarceldas()
        Dim conPrecio As Integer = 0
        Dim sinPrecio As Integer = 0
        Dim i As Integer = 0
        Do
            If grdListas.Rows(i).Cells("*Precio").Value = 0 Then
                grdListas.Rows(i).Cells("*Precio").Appearance.BackColor = Color.Salmon
                grdListas.Rows(i).Cells("Vacía").Appearance.BackColor = Color.Salmon
                sinPrecio += 1
            Else
                grdListas.Rows(i).Cells("*Precio").Appearance.BackColor = Color.YellowGreen
                grdListas.Rows(i).Cells("Vacía").Appearance.BackColor = Color.YellowGreen
                conPrecio += 1
            End If
            i += 1
        Loop While i < grdListas.Rows.Count
        lblConPrecio.Text = "" & conPrecio
        lblSinPrecio.Text = "" & sinPrecio
        Dim total As Integer = conPrecio + sinPrecio
        lblTotalEstilos.Text = "" & total
    End Sub

    Private Sub GrdListas_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdListas.AfterCellUpdate
        Try
            If Not grdListas.ActiveCell.IsFilterRowCell Then
                Dim conPrecio As Integer = 0
                Dim sinPrecio As Integer = 0
                If e.Cell.Text.Trim = "" Then
                    e.Cell.Value = 0
                End If
                Dim i As Integer = 0
                Do
                    If grdListas.Rows(i).Cells("*Precio").Value = 0 Then
                        grdListas.Rows(i).Cells("*Precio").Appearance.BackColor = Color.Salmon
                        grdListas.Rows(i).Cells("Vacía").Appearance.BackColor = Color.Salmon
                        sinPrecio += 1
                    Else
                        grdListas.Rows(i).Cells("*Precio").Appearance.BackColor = Color.YellowGreen
                        grdListas.Rows(i).Cells("Vacía").Appearance.BackColor = Color.YellowGreen
                        conPrecio += 1

                    End If
                    i += 1
                Loop While i < grdListas.Rows.Count
                If Not listaOriginal.Contains(grdListas.ActiveRow.Cells("idPrecio").Value) Then
                    listaOriginal.Add(grdListas.ActiveRow.Cells("idPrecio").Value)
                ElseIf grdListas.ActiveRow.Cells("*Precio").Value = 0 Then
                    listaOriginal.Remove(grdListas.ActiveRow.Cells("idPrecio").Value)
                End If
                lblConPrecio.Text = "" & conPrecio
                lblSinPrecio.Text = "" & sinPrecio
                Dim total As Integer = conPrecio + sinPrecio
                lblTotalEstilos.Text = "" & total
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            For Each row As UltraGridRow In grdListas.Rows
                If row.Cells("Seleccion").Value Then
                    row.Cells("*Precio").Value = Convert.ToDecimal(txtPrecioUnitario.Text.Trim)
                    row.Cells("Seleccion").Value = 0
                End If
            Next
            Pintarceldas()
        Catch ex As Exception
            adv.mensaje = "Cantidad no valida."
            adv.ShowDialog()
        End Try
        ContarRegistrosSeleccionados2()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim obj As New ListaPreciosProdBU
        Dim lista As New ListaPrecioProd
        If ValidarCampos() Then
            If nuevo = True Then
                lista.idNave = obj.getNaveSIcy(cmbNave.SelectedValue)
                lista.inicio = dtpFechaInicio.Value
                lista.marca = cmbMarca.SelectedValue
                lista.coleccion = cmbColeccion.SelectedValue
                Dim datos As DataTable = obj.getValidarLista(lista)
                If datos.Rows.Count = 0 Then
                    Cursor = Windows.Forms.Cursors.WaitCursor
                    GuardarLista()
                    Cursor = Windows.Forms.Cursors.Default
                Else
                    adv.mensaje = "Existe otra lista en la nave con la misma colección y coincidencia de vencimiento:  " & datos.Rows(0).Item(2).ToString & " DEL " & datos.Rows(0).Item(3).ToString & " AL " & datos.Rows(0).Item(4).ToString & ". Modifique las fechas de vigencia de la lista que está capturando"
                    adv.ShowDialog()
                End If
            Else
                lista.idNave = obj.getNaveSIcy(cmbNave.SelectedValue)
                lista.inicio = dtpFechaInicio.Value
                lista.marca = cmbMarca.SelectedValue
                lista.coleccion = cmbColeccion.SelectedValue
                lista.listaid = idLista
                Dim datos As DataTable = obj.getValidarLista(lista)
                If datos.Rows.Count = 0 Then
                    Dim ventanaConfirmacion As New confirmarFormGrande With {
                        .mensaje = "Los precios de los lotes ya recibidos en CEDIS 'NO' serán actualizados" + vbCrLf + "¿Desea actualizar los precios?" + vbCrLf + "(En caso de requerir alguna actualización, solicitarla a TI mediante un Ticket de Service Desk)"
                    }
                    ventanaConfirmacion.ShowDialog()
                    If ventanaConfirmacion.DialogResult = Windows.Forms.DialogResult.OK Then
                        Cursor = Windows.Forms.Cursors.WaitCursor
                        ActualizarLista()
                        Cursor = Windows.Forms.Cursors.Default
                    End If
                Else
                    adv.mensaje = "Existe otra lista en la nave con la misma colección y coincidencia de vencimiento:  " & datos.Rows(0).Item(2).ToString & " DEL " & datos.Rows(0).Item(3).ToString & " AL " & datos.Rows(0).Item(4).ToString & ". Modifique las fechas de vigencia de la lista que está capturando"
                    adv.ShowDialog()
                End If
            End If
        End If
    End Sub

    Public Function ValidarCampos()
        If Not cmbNave.SelectedIndex > 0 Then
            adv.mensaje = "Seleccione una nave."
            adv.ShowDialog()
            Return False
        End If
        If nuevo = True Then
            If Not cmbMarca.SelectedIndex > 0 Then
                adv.mensaje = "Seleccione una marca"
                adv.ShowDialog()
                Return False
            End If
            If Not cmbColeccion.SelectedIndex > 0 Then
                adv.mensaje = "Seleccione una colección."
                adv.ShowDialog()
                Return False
            End If
        End If

        Return True
    End Function

    Public Sub GuardarLista()
        Dim obj As New ListaPreciosProdBU
        Dim lista As New ListaPrecioProd
        Dim listaDet As New ListaPrecioProdDetalles
        Dim idList As Integer = 0
        Dim tipoprecio As String = lblTipoPrecio.Text

        Try
            lista.idNave = cmbNave.SelectedValue
            lista.inicio = dtpFechaInicio.Value
            lista.fin = dtpFechaFinal.Value
            lista.marca = cmbMarca.SelectedValue
            lista.coleccion = cmbColeccion.SelectedValue
            lista.nombre = txtNombreLista.Text.Trim
            lista.usuarioId = SesionUsuario.UsuarioSesion.PUserUsername
            Dim idListaD As DataTable = obj.InsertListaPrecioProducto(lista)
            If idListaD.Rows.Count > 0 Then
                idList = Convert.ToInt32(idListaD.Rows(0).Item(0).ToString)
            End If
            lista.listaid = idList
            For Each row As UltraGridRow In grdListas.Rows
                listaDet.claveProducto = row.Cells("Modelo").Value
                listaDet.listaId = idList
                listaDet.precio = row.Cells("*Precio").Value
                listaDet.productoId = row.Cells("listaIdproducto").Value ' row.Cells("IdProducto").Value

                listaDet.usuarioId = lista.usuarioId
                listaDet.tipoprecio = tipoprecio
                obj.InsertListaPrecioProductoDetalles(listaDet)
            Next
            exito.mensaje = "Lista de precio de producto terminado registrada."
            exito.ShowDialog()
            Close()
        Catch ex As Exception
            adv.mensaje = "Surgió algo inesperado. Detalle: " & ex.Message
            adv.ShowDialog()
        End Try
    End Sub

    Public Sub ActualizarLista()
        Dim obj As New ListaPreciosProdBU
        Dim lista As New ListaPrecioProd
        Dim listaDet As New ListaPrecioProdDetalles
        Dim idListaD As New DataTable
        Dim tipoprecio As String = lblTipoPrecio.Text
        Try
            lista.idNave = cmbNave.SelectedValue
            lista.inicio = dtpFechaInicio.Value
            lista.fin = dtpFechaFinal.Value
            lista.nombre = txtNombreLista.Text.Trim
            lista.usuarioId = SesionUsuario.UsuarioSesion.PUserUsername
            lista.listaid = idLista
            obj.UpdateListaPrecioProducto(lista)
            For Each row As UltraGridRow In grdListas.Rows
                If row.Cells("idLista").Value = 0 Then
                    listaDet.claveProducto = row.Cells("Modelo").Value
                    listaDet.listaId = idLista
                    listaDet.precio = row.Cells("*Precio").Value
                    listaDet.productoId = row.Cells("listaIdproducto").Value 'row.Cells("IdProducto").Value
                    listaDet.usuarioId = lista.usuarioId
                    listaDet.tipoprecio = tipoprecio
                    obj.InsertListaPrecioProductoDetalles(listaDet)
                ElseIf listaOriginal.Contains(row.Cells("idPrecio").Value) Then
                    listaDet.claveProducto = row.Cells("Modelo").Value
                    listaDet.precioId = row.Cells("idPrecio").Value
                    listaDet.listaId = idLista
                    listaDet.precio = row.Cells("*Precio").Value
                    listaDet.productoId = row.Cells("listaIdproducto").Value ' row.Cells("IdProducto").Value
                    listaDet.usuarioId = lista.usuarioId
                    listaDet.tipoprecio = tipoprecio
                    obj.UpdateListaPrecioProductoDetalles(listaDet)
                End If
            Next
            exito.mensaje = "Lista de precio de producto terminado registrada."
            exito.ShowDialog()
            Close()
        Catch ex As Exception
            adv.mensaje = "Surgió algo inesperado. Detalle: " & ex.Message
            adv.ShowDialog()
        End Try
    End Sub

    Private Sub GrdListas_Error(sender As Object, e As ErrorEventArgs) Handles grdListas.Error
        If e.ErrorText.Contains("Unable to update the data value: No se puede obtener acceso al objeto desechado.") Then
            e.Cancel = True
        End If
    End Sub

    Private Sub ContarRegistrosSeleccionados2()
        Try
            Dim Seleccionados As Integer = 0
            For Each row As UltraGridRow In grdListas.Rows.GetFilteredInNonGroupByRows
                If row.Cells("Seleccion").Value Then
                    Seleccionados += 1
                End If
            Next
            lblTotalSelec.Text = Format(Seleccionados, "###,###,##0")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GrdListas_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles grdListas.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Enter Then
                grdListas.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdListas.DisplayLayout.Bands(0)
                If grdListas.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdListas.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdListas.ActiveCell = nextRow.Cells(grdListas.ActiveCell.Column)
                    e.Handled = True
                    grdListas.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Close()
    End Sub

    Private Sub pbYuyin_Click(sender As Object, e As EventArgs) Handles pbYuyin.Click

    End Sub
End Class