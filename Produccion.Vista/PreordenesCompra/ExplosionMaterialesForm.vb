Imports Produccion.Negocios
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Stimulsoft.Report
Imports Tools


Public Class ExplosionMaterialesForm

    Dim tablaDatosNave As New DataTable
    Dim tablaOrdenCompra As New DataTable
    Dim TablaOrdenDeCompraDetalle As New DataTable
    Dim objConfirmacion As New Tools.ConfirmarForm
    Dim cont As Integer = 0
    Dim mensaje = 0
    Dim NumSemana As Integer
    Public proveedor As Integer


    Private Sub PreOrdenDeCompraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        LlenarEstatusCombo()
        LlenarListasNaves()
        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now
        NumSemana = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        nudAño.Value = DatePart(DateInterval.Year, Now)
        nudSemanaInicio.Value = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        nudSemanaInicio.TextAlign = HorizontalAlignment.Center
        lblNoSemana.Text = NumSemana.ToString()
        gbFecha.Enabled = False
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Me.Cursor = Cursors.WaitCursor
        mensaje = 0
        mostrar()
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub LlenarListasNaves()
        cbxNave = Tools.Controles.ComboNavesSegunUsuario(cbxNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub LlenarEstatusCombo()
        Dim dtEstatusCombo As New DataTable
        Dim objBU As New PreordenCompraBU
        dtEstatusCombo = objBU.ObtieneEstatusOrdenCompra()
        If dtEstatusCombo.Rows.Count > 0 Then
            dtEstatusCombo.Rows.InsertAt(dtEstatusCombo.NewRow, 0)
            cmbEstatus.DataSource = dtEstatusCombo
            cmbEstatus.DisplayMember = "Estatus"
            cmbEstatus.ValueMember = "EstatusID"
        End If
        cmbEstatus.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Suggest
        cmbEstatus.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Public Sub Totales()
        Dim pares As Integer = 0
        Dim inventario As Double = 0
        Dim totalPedido As Double = 0
        Dim totalCompra As Double = 0

        For value = 0 To grdPreorden.Rows.Count - 1
            pares += grdPreorden.Rows(value).Cells("Pares").Value
            Try
                inventario += grdPreorden.Rows(value).Cells("Almacen").Value
            Catch ex As Exception
            End Try
            totalPedido += grdPreorden.Rows(value).Cells("Total Pedir").Value
            totalCompra += grdPreorden.Rows(value).Cells("Costo Total").Value
        Next

        lblParesNumero.Text = Format(pares, "##,##0")
        lblSurtidosNumero.Text = Format(inventario, "##,##0.00")
        lblCantidadSolicitadaNumero.Text = Format(totalPedido, "##,##0.00")
        lblTotalNumero.Text = Format(totalCompra, "##,##0.00")
    End Sub

    Public Sub mostrar()
        Dim obj As New PreordenCompraBU
        Dim tablaPreorden As New DataTable
        Dim listaOrdenes As New List(Of Integer)
        Dim FechaInicio As Date = dtpFechaInicio.Value
        Dim FechaFin As Date = dtpFechaFin.Value
        Dim SemanaInicio As Integer = 0
        Dim SemanaFin As Integer = 0
        Dim añoInicio As Integer = 0
        Dim añoFin As Integer = 0
        Dim CheckSemana As Integer = 0
        Dim CheckFecha As Integer = 0
        Dim FEstatus As Integer = 0

        If FechaInicio > FechaFin And chReporteSemanal.Checked = False Then
            Tools.MostrarMensaje(Mensajes.Warning, "La fecha fin no puede ser menor a la fecha inicio.")
            dtpFechaFin.Value = dtpFechaInicio.Value
            Exit Sub
        End If

        If cbxNave.Text = "" Then
            Tools.MostrarMensaje(Mensajes.Warning, "Seleccione una nave.")
            Exit Sub
        Else

            If chReporteSemanal.Checked = True Then
                CheckSemana = 1
                añoInicio = nudAño.Value
                SemanaInicio = nudSemanaInicio.Value
            End If
            If chFechaPrograma.Checked = True Then
                CheckFecha = 1
            End If

            If cmbEstatus.SelectedIndex <> 0 Then
                FEstatus = cmbEstatus.SelectedValue
            End If


            tablaPreorden = obj.ConsultaPreOrdenesDeCompra(cbxNave.SelectedValue, FechaInicio.ToShortDateString(), FechaFin.ToShortDateString(), CheckSemana, añoInicio, SemanaInicio, FEstatus, CheckFecha)

            grdPreorden.DataSource = tablaPreorden


            If tablaPreorden.Rows.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "No hay Órdenes de Compra para esta nave, Fecha de Programa o Estatus seleccionado.")
                Exit Sub
            End If
            diseñoGrid()
        End If
    End Sub

    Public Sub diseñoGrid()
        Me.Cursor = Cursors.WaitCursor
        Dim band As UltraGridBand = Me.grdPreorden.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        With grdPreorden.DisplayLayout.Bands(0)
            .Columns(" ").Width = 2
            .Columns("Pre Orden").Width = 20
            .Columns("Oc").Width = 20
            .Columns("NumeroOc").Width = 20
            .Columns("Proveedor").Width = 90
            .Columns("Fecha Entrega").Width = 30
            .Columns("fp").Width = 30
            .Columns("Tipo Orden").Width = 25
            .Columns("Prioridad").Width = 30
            .Columns("Descuento").Width = 25
            .Columns("Observación").Width = 80
            .Columns("Numero Materiales").Width = 20
            .Columns("Total Pre Orden").Width = 30
            .Columns("MonedaAbreviacion").Width = 25
            .Columns("Usuario").Width = 40
            .Columns("Fecha Captura").Width = 27
            .Columns("Estatus").Width = 50
            .Columns("EstatusRecepcion").Width = 50

            .Columns("Pre Orden").Header.Caption = "Id" & vbCrLf & "Orden"
            .Columns("Observación").Header.Caption = "Observaciones"
            .Columns("Fecha Entrega").Header.Caption = "Fecha" & vbCrLf & "Entrega"
            .Columns("Tipo Orden").Header.Caption = "Tipo" & vbCrLf & "Captura"
            .Columns("Prioridad").Header.Caption = "Tipo" & vbCrLf & "Orden"
            .Columns("Total Pre Orden").Header.Caption = "Subtotal"
            .Columns("MonedaAbreviacion").Header.Caption = "Tipo de" & vbCrLf & "Moneda"
            .Columns("Numero Materiales").Header.Caption = "No. de" & vbCrLf & "Materiales"
            .Columns("Fecha Captura").Header.Caption = "Fecha de" & vbCrLf & "Captura"
            .Columns("fp").Header.Caption = "Fecha de" & vbCrLf & "Programa"
            .Columns("Descuento").Header.Caption = "Descuento" & vbCrLf & "%"
            .Columns("Estatus").Header.Caption = "Estatus" & vbCrLf & "Orden"
            .Columns("EstatusRecepcion").Header.Caption = "Estatus" & vbCrLf & "Recepción"

            .Columns("Idpo").Hidden = True
            .Columns("Idp").Hidden = True
            .Columns("Pares").Hidden = True
            .Columns("OC").Hidden = True
            .Columns("NumeroOc").Header.Caption = "No." & vbCrLf & "Orden"
            .Columns("IdMoneda").Hidden = True
            .Columns("MonedaSimbolo").Hidden = True
            .Columns("TipoCompra").Hidden = True

            .Columns("NumeroOc").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Pre Orden").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Descuento").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Numero Materiales").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total Pre Orden").CellAppearance.TextHAlign = HAlign.Right
            .Columns("MonedaAbreviacion").CellAppearance.TextHAlign = HAlign.Left
            .Columns("Oc").CellActivation = Activation.NoEdit
            .Columns("NumeroOc").CellActivation = Activation.NoEdit
            .Columns("Pre Orden").CellActivation = Activation.NoEdit
            .Columns("Proveedor").CellActivation = Activation.NoEdit
            .Columns("Tipo Orden").CellActivation = Activation.NoEdit
            .Columns("Numero Materiales").CellActivation = Activation.NoEdit
            .Columns("Total Pre Orden").CellActivation = Activation.NoEdit
            .Columns("IdMoneda").CellActivation = Activation.NoEdit
            .Columns("Usuario").CellActivation = Activation.NoEdit
            .Columns("Fecha Captura").CellActivation = Activation.NoEdit
            .Columns("fp").CellActivation = Activation.NoEdit
            .Columns("Descuento").CellActivation = Activation.NoEdit
            .Columns("Tipo Orden").CellActivation = Activation.NoEdit
            .Columns("Prioridad").CellActivation = Activation.NoEdit
            .Columns("Fecha Entrega").CellActivation = Activation.NoEdit
            .Columns("Observación").CellActivation = Activation.NoEdit
            .Columns("Estatus").CellActivation = Activation.NoEdit
            .Columns("EstatusRecepcion").CellActivation = Activation.NoEdit

            .Columns(" ").CellActivation = Activation.AllowEdit

            .Columns("Descuento").Format = "##,##0.00"

            .Columns("NumeroOc").CellAppearance.FontData.Bold = DefaultableBoolean.True

            .Columns(" ").CellAppearance.FontData.Bold = DefaultableBoolean.False

            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("Fecha Entrega").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date
            For value = 0 To grdPreorden.Rows.Count - 1
                If grdPreorden.Rows(value).Cells("Estatus").Text = "CAPTURADA" Then
                    grdPreorden.Rows(value).Cells("Pre Orden").Appearance.BackColor = pnlPorAutorizar.BackColor
                ElseIf grdPreorden.Rows(value).Cells("Estatus").Text = "AUTORIZADA" Then
                    grdPreorden.Rows(value).Cells("Pre Orden").Appearance.BackColor = pnlAutorizada.BackColor
                ElseIf grdPreorden.Rows(value).Cells("Estatus").Text = "CANCELADA" Then
                    grdPreorden.Rows(value).Cells("Pre Orden").Appearance.BackColor = pnlCancelada.BackColor
                End If
                Try
                    If CDate(grdPreorden.Rows(value).Cells("fp").Value) > CDate(grdPreorden.Rows(value).Cells("Fecha Entrega").Value) Then
                        grdPreorden.Rows(value).Cells("Fecha Entrega").Appearance.BackColor = pnlFechaEntrega.BackColor
                    End If
                Catch ex As Exception
                End Try

            Next
            Try
                Dim listaPriorirdades As New ValueList
                listaPriorirdades.ValueListItems.Add("NORMAL")
                listaPriorirdades.ValueListItems.Add("URGENTE")
                For value = 0 To grdPreorden.Rows.Count - 1
                    grdPreorden.Rows(value).Cells("Prioridad").Style = UltraWinGrid.ColumnStyle.DropDown
                    grdPreorden.Rows(value).Cells("Prioridad").ValueList = listaPriorirdades
                    grdPreorden.Rows(value).Cells("Prioridad").Value = grdPreorden.Rows(value).Cells("Prioridad").Text
                Next

            Catch ex As Exception
            End Try
        End With
        grdPreorden.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdPreorden.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdPreorden.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdPreorden.DataSource = Nothing
        cbxNave.SelectedValue = 0
        lblParesNumero.Text = 0
        lblSurtidosNumero.Text = 0
        lblCantidadSolicitadaNumero.Text = 0
        lblTotalNumero.Text = "$" & 0
        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub grdPreorden_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdPreorden.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." Then
            cont = 1
            e.Handled = False
        Else
            e.Handled = True
        End If
        Dim c As Short = 0
        If UCase(e.KeyChar) Like "[.]" Then
            If InStr(grdPreorden.ActiveRow.Cells("Total Pedir").Text, ".") > 0 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        End If
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub grdPreorden_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPreorden.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Enter Then
                grdPreorden.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdPreorden.DisplayLayout.Bands(0)
                If grdPreorden.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdPreorden.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdPreorden.ActiveCell = nextRow.Cells(grdPreorden.ActiveCell.Column)
                    e.Handled = True
                    grdPreorden.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Up Then
                grdPreorden.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdPreorden.DisplayLayout.Bands(0)
                If grdPreorden.ActiveRow.HasPrevSibling(True) Then
                    Dim nextRow As UltraGridRow = grdPreorden.ActiveRow.GetSibling(SiblingRow.Previous, True)
                    grdPreorden.ActiveCell = nextRow.Cells(grdPreorden.ActiveCell.Column)
                    e.Handled = True
                    grdPreorden.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Down Then
                grdPreorden.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdPreorden.DisplayLayout.Bands(0)
                If grdPreorden.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdPreorden.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdPreorden.ActiveCell = nextRow.Cells(grdPreorden.ActiveCell.Column)
                    e.Handled = True
                    grdPreorden.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cbxTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chxTodo.CheckedChanged
        If chxTodo.Checked = True Then
            For value = 0 To grdPreorden.Rows.Count - 1
                If grdPreorden.Rows(value).Cells("Estatus").Text <> "AUTORIZADA" Then
                    grdPreorden.Rows(value).Cells(" ").Value = True
                End If
            Next
        Else
            For value = 0 To grdPreorden.Rows.Count - 1
                grdPreorden.Rows(value).Cells(" ").Value = False
            Next
        End If
    End Sub

    Public Sub ActualizarPrecioProveedorSeleccionado()
        Try
            If grdPreorden.ActiveCell.Column.ToString = "Proveedor Pedido" Or grdPreorden.ActiveCell.Column.ToString = "Total Pedir" Then
                Dim obj As New PreordenCompraBU
                Dim precio As New DataTable
                Try
                    Dim MaterialNaveId = grdPreorden.ActiveRow.Cells("IDmn").Value
                    Dim proveedorId = grdPreorden.ActiveRow.Cells("Proveedor Pedido").Value
                    precio = obj.ConsultaPrecio(MaterialNaveId, grdPreorden.ActiveRow.Cells("IDpp").Value)
                    Dim precioUnitario = precio.Rows(0).Item(0).ToString
                    grdPreorden.ActiveRow.Cells("Precio Unitario").Value = precioUnitario
                    Dim total = precioUnitario * grdPreorden.ActiveRow.Cells("Total Pedir").Value
                    grdPreorden.ActiveRow.Cells("Costo Total").Value = Format(total, "##,##0.00")
                    Dim idproveedorpedir = grdPreorden.ActiveRow.Cells("Proveedor Pedido").Value
                    grdPreorden.ActiveRow.Cells("IDpp").Value = idproveedorpedir
                    diseñoGrid()
                    Totales()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdPreorden_AfterExitEditMode(sender As Object, e As EventArgs) Handles grdPreorden.AfterExitEditMode
        ActualizarPrecioProveedorSeleccionado()
    End Sub


    Private Sub cbxMaterial_SelectedIndexChanged(sender As Object, e As EventArgs)
        grdPreorden.DataSource = Nothing
    End Sub

    Private Sub btnConsultarOrdenes_Click(sender As Object, e As EventArgs) Handles btnConsultarOrdenes.Click
        Me.Cursor = Cursors.WaitCursor
        Dim form As New DetallePreOrdenDeCompraForm
        Dim contador As Integer = 0

        For value = 0 To grdPreorden.Rows.Count - 1
            If CBool(grdPreorden.Rows(value).Cells(" ").Value) = True Then
                contador = contador + 1
            End If
        Next


        If grdPreorden.ActiveRow.Selected = True Or contador > 0 Then
            Dim NUMERO As String = String.Empty
            Dim tipo As String = ""
            form.proveedor = grdPreorden.ActiveRow.Cells("Idp").Value
            form.nave = cbxNave.SelectedValue
            form.NuevoRegistro = False
            form.Text = form.Text + " - " + tipo
            form.lblTitulo.Text = form.lblTitulo.Text
            form.programa = grdPreorden.ActiveRow.Cells("fp").Value
            form.proveedornombre = grdPreorden.ActiveRow.Cells("Proveedor").Value
            form.cbxProveedores.Text = grdPreorden.ActiveRow.Cells("Proveedor").Value
            proveedor = grdPreorden.ActiveRow.Cells("Idp").Value
            form.tipodeorden = grdPreorden.ActiveRow.Cells("Prioridad").Value
            form.cbxTipoDeOrden.Text = grdPreorden.ActiveRow.Cells("Prioridad").Value
            Try
                form.fechaentrega = grdPreorden.ActiveRow.Cells("Fecha Entrega").Value
                form.dtpEntrega.Value = grdPreorden.ActiveRow.Cells("Fecha Entrega").Value
                form.dtpFechaPrograma.Value = grdPreorden.ActiveRow.Cells("fp").Value
            Catch ex As Exception
            End Try

            form.descuento = grdPreorden.ActiveRow.Cells("Descuento").Value
            form.txtDescuento.Text = grdPreorden.ActiveRow.Cells("Descuento").Value
            form.idpo = grdPreorden.ActiveRow.Cells("Idpo").Value
            form.lblIdoc.Text = grdPreorden.ActiveRow.Cells("Idpo").Value
            form.estatus = grdPreorden.ActiveRow.Cells("Estatus").Value
            If grdPreorden.ActiveRow.Cells("Observación").Text = "" Then
                form.observaciones = " "
            Else
                form.observaciones = grdPreorden.ActiveRow.Cells("Observación").Value
            End If
            If grdPreorden.ActiveRow.Cells("Estatus").Text = "COMPLETA" Or grdPreorden.ActiveRow.Cells("Estatus").Text = "AUTORIZADA" Then
                form.btnGuardar.Enabled = False
            Else
                form.btnGuardar.Enabled = True
            End If

            If grdPreorden.ActiveRow.Cells("NumeroOc").Text.Length = 1 Then
                NUMERO = "0000" & grdPreorden.ActiveRow.Cells("NumeroOc").Text
            ElseIf grdPreorden.ActiveRow.Cells("NumeroOc").Text.Length = 2 Then
                NUMERO = "000" & grdPreorden.ActiveRow.Cells("NumeroOc").Text
            ElseIf grdPreorden.ActiveRow.Cells("NumeroOc").Text.Length = 3 Then
                NUMERO = "00" & grdPreorden.ActiveRow.Cells("NumeroOc").Text
            ElseIf grdPreorden.ActiveRow.Cells("NumeroOc").Text.Length = 4 Then
                NUMERO = "0" & grdPreorden.ActiveRow.Cells("NumeroOc").Text
            ElseIf grdPreorden.ActiveRow.Cells("NumeroOc").Text.Length = 5 Then
                NUMERO = grdPreorden.ActiveRow.Cells("NumeroOc").Text
            End If
            form.oc = NUMERO
            form.lblNumeroOCText.Text = NUMERO
            form.numeroorden = grdPreorden.ActiveRow.Cells("Pre Orden").Text
            form.pares = grdPreorden.ActiveRow.Cells("Pares").Value
            form.lblParesText.Text = grdPreorden.ActiveRow.Cells("Pares").Value
            form.fechaprograma = grdPreorden.ActiveRow.Cells("fp").Value
            form.lblMoneAbreviatura.Text = grdPreorden.ActiveRow.Cells("monedaabreviacion").Text
            form.monedaID = grdPreorden.ActiveRow.Cells("IdMoneda").Text
            form.ShowDialog()
            Me.Cursor = Cursors.Default

        End If

        Me.Cursor = Cursors.WaitCursor
        mostrar()
        Me.Cursor = Cursors.Default
    End Sub


    Public Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        Dim objBU As New PreordenCompraBU
        Dim PreOrdenesCompra As String = String.Empty
        Dim TablaAutorizar As New DataTable

        If grdPreorden.Rows.Count > 0 Then
            For value = 0 To grdPreorden.Rows.Count - 1
                If CBool(grdPreorden.Rows(value).Cells(" ").Value) = True Then
                    If PreOrdenesCompra = " " Then
                        PreOrdenesCompra += grdPreorden.Rows(value).Cells("Idpo").Value
                    Else
                        PreOrdenesCompra += "" + Replace(grdPreorden.Rows(value).Cells("Idpo").Value, ",", "") + ""
                    End If

                End If
            Next

            TablaAutorizar = objBU.AutorizarOrdenCompra(PreOrdenesCompra)

            If TablaAutorizar.Rows.Count > 0 Then
                Tools.MostrarMensaje(Mensajes.Success, "Órdenes actualizadas correctamente.")
                mostrar()
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "Ocurrió un error al autorizar.")
            End If

        Else
            Tools.MostrarMensaje(Mensajes.Warning, "Seleccione una orden para autorizar.")
        End If

    End Sub

    Private Sub btnAltaManual_Click(sender As Object, e As EventArgs) Handles btnAltaManual.Click
        Me.Cursor = Cursors.WaitCursor
        Dim form As New DetallePreOrdenDeCompraForm
        If cbxNave.Text = "" Then
            Tools.MostrarMensaje(Mensajes.Warning, "Seleccione una nave.")
            Exit Sub
        Else
            form.cbxProveedores.Enabled = True
            form.NuevoRegistro = True
            form.dtpFechaPrograma.Enabled = True
            form.cbxTipoDeOrden.Text = "NORMAL"
            form.lblEstatus.ForeColor = Color.BlueViolet
            form.nave = cbxNave.SelectedValue
            form.lblParesText.Visible = False
            form.lblPares.Visible = False
            form.Manual = 1
            form.pnlColor.Visible = False
            form.lblTitulo.Text = "Orden de Compra"
            form.lblTitulo.Location = New Point(951, 22)
            Me.Cursor = Cursors.Default
            form.ShowDialog()
            Me.Cursor = Cursors.WaitCursor
            mostrar()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim objBU As New PreordenCompraBU
        Dim PreOrdenesCompra As String = String.Empty
        Dim TablaCancelar As New DataTable

        If grdPreorden.Rows.Count > 0 Then
            For value = 0 To grdPreorden.Rows.Count - 1
                If grdPreorden.Rows(value).Cells(" ").Value = True Then
                    If PreOrdenesCompra = "" Then
                        PreOrdenesCompra += grdPreorden.Rows(value).Cells("Idpo").Value
                    Else
                        PreOrdenesCompra += "" + Replace(grdPreorden.Rows(value).Cells("Idpo").Value, ",", "") + ""
                    End If

                End If
            Next

            TablaCancelar = objBU.CancelarOrdenCompra(PreOrdenesCompra)

            If TablaCancelar.Rows.Count > 0 Then
                Tools.MostrarMensaje(Mensajes.Success, "Órdenes canceladas correctamente.")
                mostrar()
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "Ocurrió un error al autorizar.")
            End If

        Else
            Tools.MostrarMensaje(Mensajes.Warning, "Seleccione una orden para autorizar.")
        End If
    End Sub

    Private Sub cbxNave_SelectedIndexChanged(sender As Object, e As EventArgs)
        grdPreorden.DataSource = Nothing
    End Sub

    Private Sub dtpPrograma_ValueChanged(sender As Object, e As EventArgs)
        grdPreorden.DataSource = Nothing
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New PreordenCompraBU
        Dim contador = 0
        Dim TablaIdOrdenCompra As New DataTable

        For value = 0 To grdPreorden.Rows.Count - 1
            If CBool(grdPreorden.Rows(value).Cells(" ").Value) = True Then
                contador = contador + 1
            End If
        Next

        If contador = 0 Then
            Tools.MostrarMensaje(Mensajes.Warning, "Seleccione una Orden de Compra.")
            Exit Sub
        ElseIf contador > 1 Then
            Tools.MostrarMensaje(Mensajes.Warning, "Seleccione solo una Orden de Compra.")
            Exit Sub
        ElseIf contador = 1 Then
            If grdPreorden.ActiveRow.Cells("Estatus").Text = "AUTORIZADA" Or grdPreorden.ActiveRow.Cells("Estatus").Text = "COMPLETA" Then
                TablaIdOrdenCompra = obj.ConsultaIdOrdenCompra(grdPreorden.ActiveRow.Cells("idpo").Value)
                tablaOrdenCompra = Nothing
                TablaOrdenDeCompraDetalle = Nothing
                Try
                    tablaOrdenCompra = obj.ConsultarOrdenCompleta(TablaIdOrdenCompra.Rows(0).Item(0))
                    TablaOrdenDeCompraDetalle = obj.ConsultarOrdenCompletaDetalle(TablaIdOrdenCompra.Rows(0).Item(0))
                    tablaDatosNave = obj.ConsultarDatosNave(cbxNave.SelectedValue)
                    CrearReporte()
                    Dim tablaImprimio As DataTable
                    tablaImprimio = obj.ConsultaImprimio(grdPreorden.ActiveRow.Cells("idpo").Value)
                    If tablaImprimio.Rows(0).Item(0).ToString.Length = 0 Then
                        obj.ActualizaImprimio(grdPreorden.ActiveRow.Cells("idpo").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                    Else
                        obj.ActualizaReimprimio(grdPreorden.ActiveRow.Cells("idpo").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                    End If
                Catch ex As Exception
                End Try
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No se puede imprimir una Orden de Compra NO Autorizada.")
                Exit Sub
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub CrearReporte()
        Dim subtotal As Decimal = 0
        Dim iva As Decimal = 0
        Dim total As Decimal = 0
        Dim descuento As Decimal = 0
        Dim obj As New PreordenCompraBU
        Dim usuario As DataTable
        Dim totalidad As Decimal = 0
        Dim MonedaSimbolo As String

        If tablaOrdenCompra.Rows(0).Item("documento") = "FACTURA" Then
            For value = 0 To TablaOrdenDeCompraDetalle.Rows.Count - 1
                subtotal += TablaOrdenDeCompraDetalle.Rows(value).Item("Importe")
            Next
            Try
                descuento = tablaOrdenCompra.Rows(0).Item("Descuento")
                descuento = subtotal * (descuento / 100)
                totalidad = subtotal - descuento
            Catch ex As Exception
            End Try
            iva = totalidad * 0.16

            total = totalidad + iva
        Else
            For value = 0 To TablaOrdenDeCompraDetalle.Rows.Count - 1
                subtotal += TablaOrdenDeCompraDetalle.Rows(value).Item("Importe")
            Next
            Try
                descuento = tablaOrdenCompra.Rows(0).Item("Descuento")
                descuento = subtotal * (descuento / 100)
                totalidad = subtotal - descuento
            Catch ex As Exception
            End Try

            total = totalidad
        End If

        '*********************************************************************************************************************
        '' Dar formato a la fecha
        'Dim dateValue As Date = dtpPrograma.Value.ToShortDateString
        Dim dateValue As Date = Date.Now
        Dim DAY = dateValue.DayOfWeek()
        Dim NUMEROMES = dateValue.Month()
        Dim dia As String = ""
        Dim mes As String = ""
        Dim fechaDias As String = ""
        Dim Logo As String = ""
        Logo = Tools.Controles.ObtenerLogoNave(cbxNave.SelectedValue)

        Select Case DAY
            Case 1
                dia = "Lunes"
            Case 2
                dia = "Martes"
            Case 3
                dia = "Miércoles"
            Case 4
                dia = "Jueves"
            Case 5
                dia = "Viernes"
            Case 6
                dia = "Sábado"
        End Select

        Select Case NUMEROMES
            Case 1
                mes = "Enero"
            Case 2
                mes = "Febrero"
            Case 3
                mes = "Marzo"
            Case 4
                mes = "Abril"
            Case 5
                mes = "Mayo"
            Case 6
                mes = "Junio"
            Case 7
                mes = "Julio"
            Case 8
                mes = "Agosto"
            Case 9
                mes = "Septiembre"
            Case 10
                mes = "Octubre"
            Case 11
                mes = "Noviembre"
            Case 12
                mes = "Diciembre"
        End Select

        fechaDias = dia & ",  " & dateValue.ToString("dd") & "  " & mes & " de " & dateValue.ToString("yyyy")
        ''******************************************************************************************************************
        usuario = obj.NombreDeUsuario(tablaOrdenCompra.Rows(0).Item("Usuario autorizo"))
        '********************************Creación de reporte
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor
            Dim OBJReporte As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            Dim tablaImprimio As DataTable
            tablaImprimio = obj.ConsultaImprimio(grdPreorden.ActiveRow.Cells("idpo").Value)
            If TablaOrdenDeCompraDetalle.Rows.Count > 10 Then
                If tablaImprimio.Rows(0).Item(0).ToString.Length = 0 Then
                    EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_ORDCOMPRA_EXPLOSION2")
                Else
                    EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_ORDEN_DE_COMPRA_EXPLOSION")
                End If
            Else
                For value = TablaOrdenDeCompraDetalle.Rows.Count To 10
                    TablaOrdenDeCompraDetalle.Rows.Add(0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, "-", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                Next
                If tablaImprimio.Rows(0).Item(0).ToString.Length = 0 Then
                    EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_ORDCOMPRA_MEDIACARTA2")
                Else
                    EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_ORDCOMPRA_MEDIACARTA")
                End If
            End If
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport
            ' Dim ruta As String
            Dim numero As String = ""
            reporte.Load(archivo)
            reporte.Compile()
            reporte("log") = Logo
            reporte("fecha") = fechaDias
            reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
            reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte("cadenacomercial") = tablaOrdenCompra.Rows(0).Item("Cadena comercial")
            reporte("proveedor") = tablaOrdenCompra.Rows(0).Item("Proveedor")
            reporte("telefono") = ""
            Dim fp As Date = tablaOrdenCompra.Rows(0).Item("Fecha programa").ToString
            Dim fpp = fp.ToString("dd-MMM-yyyy")
            Dim fe As Date = tablaOrdenCompra.Rows(0).Item("Fecha entrega").ToString
            Dim fee = fe.ToString("dd-MMM-yyyy")
            reporte("fechaprograma") = fpp.Replace(".", "")
            reporte("fechaentrega") = fee.Replace(".", "")
            reporte("urgencia") = tablaOrdenCompra.Rows(0).Item("prioridad")
            reporte("observacion") = tablaOrdenCompra.Rows(0).Item("Observacion")
            MonedaSimbolo = tablaOrdenCompra.Rows(0).Item("mone_simbolo").ToString
            reporte("descuento") = Format(descuento, "" & MonedaSimbolo & " ##,##0.00").ToString
            reporte("subtotal") = Format(subtotal, "" & MonedaSimbolo & " ##,##0.00").ToString
            reporte("total") = Format(total, "" & MonedaSimbolo & " ##,##0.00").ToString
            reporte("iva") = Format(iva, "" & MonedaSimbolo & " ##,##0.00").ToString
            reporte("nave") = tablaDatosNave.Rows(0).Item("Nave")
            reporte("colonia") = tablaDatosNave.Rows(0).Item("Colonia")
            reporte("domicilio") = tablaDatosNave.Rows(0).Item("CaLLE")
            reporte("telnave") = ""
            reporte("autorizo") = usuario.Rows(0).Item(0)
            If tablaOrdenCompra.Rows(0).Item("documento") = "FACTURA" Then
                reporte("facturar") = "FACTURAR"
            Else
                reporte("facturar") = ""
            End If
            reporte("desc") = tablaOrdenCompra.Rows(0).Item("Descuento").ToString
            reporte("cp") = tablaDatosNave.Rows(0).Item("CP")
            If tablaOrdenCompra.Rows(0).Item("Oc").ToString.Length = 1 Then
                numero = "0000" & tablaOrdenCompra.Rows(0).Item("Oc")
            ElseIf tablaOrdenCompra.Rows(0).Item("Oc").ToString.Length = 2 Then
                numero = "000" & tablaOrdenCompra.Rows(0).Item("Oc")
            ElseIf tablaOrdenCompra.Rows(0).Item("Oc").ToString.Length = 3 Then
                numero = "00" & tablaOrdenCompra.Rows(0).Item("Oc")
            ElseIf tablaOrdenCompra.Rows(0).Item("Oc").ToString.Length = 4 Then
                numero = "0" & tablaOrdenCompra.Rows(0).Item("Oc")
            ElseIf tablaOrdenCompra.Rows(0).Item("Oc").ToString.Length = 5 Then
                numero = tablaOrdenCompra.Rows(0).Item("Oc")
            End If
            reporte("numeroorden") = numero
            If tablaImprimio.Rows(0).Item(0).ToString.Length = 0 Then
                reporte("imp") = ""
            Else
                reporte("imp") = "REIMPRESIÓN"
            End If
            reporte.RegData(TablaOrdenDeCompraDetalle)
            reporte.Show()
            '*********************
            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        '********************************Fin de creación de reporte
    End Sub


    Private Sub grdPreorden_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdPreorden.ClickCell
        Try
            If grdPreorden.ActiveCell.Column.ToString <> " " Then
                grdPreorden.ActiveRow.Selected = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdPreorden_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles grdPreorden.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Try
            grdPreorden.ActiveRow.Selected = True
            btnConsultarOrdenes_Click(Nothing, Nothing)

        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub chReporteSemanal_CheckedChanged(sender As Object, e As EventArgs) Handles chReporteSemanal.CheckedChanged
        If chReporteSemanal.Checked = True Then
            grpReporte.Enabled = True
        Else
            grpReporte.Enabled = False
        End If
    End Sub

    Private Sub chFechaPrograma_CheckedChanged(sender As Object, e As EventArgs) Handles chFechaPrograma.CheckedChanged
        If chFechaPrograma.Checked = True Then
            gbFecha.Enabled = True
        Else
            gbFecha.Enabled = False
        End If
    End Sub
End Class