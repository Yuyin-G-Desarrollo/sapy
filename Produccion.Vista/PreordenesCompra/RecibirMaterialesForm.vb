Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports Entidades

Public Class RecibirMaterialesForm
    Public idOrdenCompra As Integer = 0
    Dim descuento As Double = 0
    Dim tipoCompra As String = ""
    Dim tipoCaptura As String = ""
    Dim idMoneda As Integer = 0
    Dim fechaPrograma As Date
    Dim exito As New ExitoForm
    Dim datosMoneda As DataTable
    Dim simbolo As String = ""
    Dim nombreSimbolo As String = ""
    Dim abreviaturaSimbolo As String = ""
    Public estatusOrdenDeCompra As String = ""
    Dim adv As New AdvertenciaForm

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub RecibirMaterialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCampos()
        grdOrdenCompra.Focus()
    End Sub
    Private Sub llenarCampos()
        Dim obj As New OrdenDeCompraBU
        Dim datos As New DataTable
        datos = obj.getEncabezadoDatosOrdenCompra(idOrdenCompra)
        For Each row As DataRow In datos.Rows
            idMoneda = row("ordc_monedaid")
            lblNumeroOCText.Text = getNumOrden(row("NO. ORDEN").ToString)
            lblIdoc.Text = row("ordc_ordencompraid")
            lblProv.Text = row("PROVEEDOR")
            fechaPrograma = CDate(row("PROGRAMA")).ToLongDateString
            lblFechaProg.Text = CDate(row("PROGRAMA")).ToLongDateString
            lblFechaEntreg.Text = CDate(row("Entrega")).ToLongDateString
            lblTipoOrd.Text = row("TipoOrden")
            ' lblTipoComp.Text = row("TipoCompra")
            tipoCompra = row("TipoCompra")
            descuento = CDbl(row("DESCUENTO"))
            tipoCaptura = row("TipoCaptura")
            txtObservaciones.Text = row("Observaciones")
            lblParesText.Text = row("Pares")
            lblEstatus1.Text = row("Estatus")
        Next
        datosMoneda = obj.getDatosMoneda(idMoneda)
        For Each row As DataRow In datosMoneda.Rows
            nombreSimbolo = row("mone_nombre")
            simbolo = row("mone_simbolo")
            abreviaturaSimbolo = row("mone_abreviatura")
        Next
        lblAbreviatura.Text = abreviaturaSimbolo
        lblAbreviatura2.Text = abreviaturaSimbolo
        getMaterialesOrdenCompra()
        calcularTotales()
        totalesGrid()
        If estatusOrdenDeCompra = "COMPLETA" Or estatusOrdenDeCompra = "CERRADA" Or estatusOrdenDeCompra = "CANCELADA" Then
            btnGuardar.Enabled = False
        End If
    End Sub
    Private Sub getMaterialesOrdenCompra()
        Dim obj As New OrdenDeCompraBU
        Dim datos As New DataTable
        datos = obj.getMaterialesOrdenCompra(idOrdenCompra)
        grdOrdenCompra.DataSource = Nothing
        grdOrdenCompra.DataSource = datos
        Dim total As Double = 0
        For Each row As DataRow In datos.Rows
            total += row("TotalRecibir")
            If row("Estatus") = "INCOMPLETO" Then
                row("Total Recibido") = 0
            End If
        Next
        txtsubTotal1.Text = Format(total, simbolo & " ##,##0.00")
        txtDescuento1.Text = Format(total * ((descuento / 100)), simbolo & " ##,##0.00")
        If tipoCompra = "FACTURA" Then
            txtIVA1.Text = Format((CDbl(txtsubTotal1.Text.Replace(simbolo, "")) - CDbl(txtDescuento1.Text.Replace(simbolo, ""))) * 0.16, simbolo & " ##,##0.00")
        Else
            txtIVA1.Text = simbolo & " 0.00"
        End If
        txtTotal1.Text = Format(CDbl(txtsubTotal1.Text.Replace(simbolo, "")) - CDbl(txtDescuento1.Text.Replace(simbolo, "")) + CDbl(txtIVA1.Text.Replace(simbolo, "")), simbolo & " ##,##0.00")
        pintarceldas()
    End Sub
    Private Sub setDiseño()
        Dim obj As New OrdenDeCompraBU
        With grdOrdenCompra.DisplayLayout.Bands(0)
            .Columns("mn_idNave").Hidden = True
            .Columns("EstatusOriginal").Hidden = True
            .Columns("mn_materialNaveid").Hidden = True
            .Columns("prov_proveedorid").Hidden = True
            .Columns("ocde_factorconversion").Hidden = True
            .Columns("ocde_ordencompradetalleid").Hidden = True
            .Columns("ocde_tipodeorden").Hidden = True
            .Columns("IDc").Hidden = True
            .Columns("modificado").Hidden = True
            .Columns("TotalRecibidoOriginal").Header.Caption = "Total" & vbCrLf & "ya Recibido"
            .Columns("TotalRecibidoOriginal").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("UMP").Hidden = True
            .Columns("totalRecibir").Hidden = True
            .Columns("Total").Format = simbolo & " ##,##0.00"
            .Columns("Total").Header.Caption = "Total" & vbCrLf & "Compra"
            .Columns("Precio").Format = simbolo & " ##,##0.00"
            .Columns("Por Recibir").Format = "##,##0.00"
            .Columns("Total Recibido").Format = "##,##0.00"
            .Columns("Material").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("UMP").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("UMC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Proveedor").Hidden = True
            .Columns("Precio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Por Recibir").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Total").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Total").Width = 50
            .Columns("Material").Width = 300
            .Columns("Proveedor").Width = 400
            .Columns("Total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Precio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Por Recibir").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Total Recibido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Por Recibir").Header.Caption = "Total Pedido"
            .Columns("prma_monedaid").Hidden = True
            .Columns("Modificada").Hidden = True
            Dim listaEstatus As New ValueList
            Dim tablaEstatus As New DataTable
            tablaEstatus = obj.getEstatusMaterialesOC()

            For Each rowDt As DataRow In tablaEstatus.Rows
                listaEstatus.ValueListItems.Add(rowDt.Item("val"), rowDt.Item("estatus").ToString.ToUpper.Trim)
            Next
            grdOrdenCompra.DisplayLayout.Bands(0).Columns("Estatus").Style = UltraWinGrid.ColumnStyle.DropDown
            grdOrdenCompra.DisplayLayout.Bands(0).Columns("Estatus").ValueList = listaEstatus
        End With
        grdOrdenCompra.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdOrdenCompra.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdOrdenCompra.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub


    Private Sub grdOrdenCompra_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdOrdenCompra.AfterCellUpdate
        If e.Cell.Row.IsFilterRow = False Then
            If e.Cell.Column.ToString = "Estatus" Then
                If grdOrdenCompra.ActiveRow.Cells("Estatus").Value = "COMPLETO" And grdOrdenCompra.ActiveRow.Cells("Total Recibido").Value = 0 Then
                    grdOrdenCompra.ActiveRow.Cells("Estatus").Value = "INCOMPLETO"
                ElseIf grdOrdenCompra.ActiveRow.Cells("Estatus").Value = "COMPLETO" And grdOrdenCompra.ActiveRow.Cells("Total Recibido").Value < grdOrdenCompra.ActiveRow.Cells("Por Recibir").Value Then
                    grdOrdenCompra.ActiveRow.Cells("Estatus").Activation = Activation.AllowEdit
                ElseIf grdOrdenCompra.ActiveRow.Cells("Estatus").Value = "COMPLETO" Then
                    grdOrdenCompra.ActiveRow.Cells("Estatus").Activation = Activation.NoEdit
                ElseIf grdOrdenCompra.ActiveRow.Cells("Estatus").Value = "CANCELADO" Then
                    grdOrdenCompra.ActiveRow.Cells("Total Recibido").Value = 0
                End If
            ElseIf e.Cell.Column.ToString = "Total Recibido" Then
                If grdOrdenCompra.ActiveRow.Cells("Total Recibido").Value >= grdOrdenCompra.ActiveRow.Cells("Por Recibir").Value Then
                    grdOrdenCompra.ActiveRow.Cells("Estatus").Value = "COMPLETO"
                ElseIf grdOrdenCompra.ActiveRow.Cells("Total Recibido").Value = 0 And grdOrdenCompra.ActiveRow.Cells("Estatus").Value = "CANCELADO" Then

                ElseIf grdOrdenCompra.ActiveRow.Cells("Total Recibido").Value < grdOrdenCompra.ActiveRow.Cells("Por Recibir").Value Then
                    grdOrdenCompra.ActiveRow.Cells("Estatus").Value = "INCOMPLETO"
                End If
            End If
        End If
        pintarceldas()
        'Try
        '    If modifica Then
        '        If Not grdOrdenCompra.ActiveCell.IsFilterRowCell Then
        '            Dim i As Integer = 0
        '            If Not e.Cell.Column.ToString = "modificado" Then
        '                grdOrdenCompra.ActiveRow.Cells("modificado").Value = 1
        '            End If
        '            Do
        '                If grdOrdenCompra.Rows(i).Cells("modificado").Value = 1 Then
        '                    If grdOrdenCompra.Rows(i).Cells("Total Recibido").Value = 0 Then
        '                        modifica = False
        '                        grdOrdenCompra.Rows(i).Cells("Total Recibido").Appearance.BackColor = Color.Salmon
        '                        grdOrdenCompra.Rows(i).Cells("Estatus").Value = "CANCELADO"
        '                    ElseIf grdOrdenCompra.Rows(i).Cells("Total Recibido").Value < grdOrdenCompra.Rows(i).Cells("Por Recibir").Value Then
        '                        modifica = False
        '                        grdOrdenCompra.Rows(i).Cells("Total Recibido").Appearance.BackColor = Color.Orange
        '                        If Not e.Cell.Column.ToString = "Estatus" And modifica = False Then
        '                            grdOrdenCompra.Rows(i).Cells("Estatus").Value = "INCOMPLETO"
        '                        End If
        '                    ElseIf grdOrdenCompra.Rows(i).Cells("Estatus").Value = "CANCELADO" Then
        '                        modifica = False
        '                        grdOrdenCompra.Rows(i).Cells("Total Recibido").Appearance.BackColor = Color.Salmon
        '                        grdOrdenCompra.Rows(i).Cells("Total Recibido").Value = 0


        '                    ElseIf grdOrdenCompra.Rows(i).Cells("Total Recibido").Value >= grdOrdenCompra.Rows(i).Cells("Por Recibir").Value Then
        '                        modifica = False
        '                        grdOrdenCompra.Rows(i).Cells("Estatus").Value = "COMPLETO"
        '                        grdOrdenCompra.Rows(i).Cells("Estatus").Activation = Activation.NoEdit
        '                    Else
        '                        grdOrdenCompra.Rows(i).Cells("Total Recibido").Appearance.BackColor = Color.YellowGreen
        '                    End If
        '                Else
        '                    If grdOrdenCompra.Rows(i).Cells("Total Recibido").Value = 0 Then
        '                        grdOrdenCompra.Rows(i).Cells("Total Recibido").Appearance.BackColor = Color.Salmon
        '                    ElseIf grdOrdenCompra.Rows(i).Cells("Estatus").Value = "CANCELADO" Then
        '                        grdOrdenCompra.Rows(i).Cells("Total Recibido").Appearance.BackColor = Color.Salmon
        '                        modifica = False
        '                        grdOrdenCompra.Rows(i).Cells("Total Recibido").Value = 0
        '                    ElseIf grdOrdenCompra.Rows(i).Cells("Estatus").Value = "INCOMPLETO" Then
        '                        grdOrdenCompra.Rows(i).Cells("Total Recibido").Appearance.BackColor = Color.Orange
        '                    Else
        '                        grdOrdenCompra.Rows(i).Cells("Total Recibido").Appearance.BackColor = Color.YellowGreen
        '                    End If
        '                End If
        '                i = i + 1
        '            Loop While i < grdOrdenCompra.Rows.Count
        '        End If
        '        totalesGrid()
        '        modifica = True
        '    Else
        '        modifica = True
        '    End If
        'Catch ex As Exception
        '    modifica = True
        'End Try
    End Sub

    Private Sub grdOrdenCompra_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdOrdenCompra.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdOrdenCompra_CellChange(sender As Object, e As CellEventArgs) Handles grdOrdenCompra.CellChange
        Try
            grdOrdenCompra.ActiveRow.Cells("Modificada").Value = 1
            pintarceldas()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub pintarceldas()
        Dim conPrecio As Integer = 0
        Dim sinPrecio As Integer = 0
        Dim i As Integer = 0
        Do
            Try
                If grdOrdenCompra.Rows(i).Cells("Estatus").Value = "CANCELADO" And estatusOrdenDeCompra <> "POR RECIBIR" Then
                    grdOrdenCompra.Rows(i).Cells("Total Recibido").Appearance.BackColor = Color.Gray
                    grdOrdenCompra.Rows(i).Cells("TotalRecibidoOriginal").Appearance.BackColor = Color.Gray
                ElseIf grdOrdenCompra.Rows(i).Cells("Total Recibido").Value <= 0 Then
                    grdOrdenCompra.Rows(i).Cells("Total Recibido").Appearance.BackColor = Color.Salmon
                ElseIf grdOrdenCompra.Rows(i).Cells("Estatus").Value = "INCOMPLETO" Then
                    grdOrdenCompra.Rows(i).Cells("Total Recibido").Appearance.BackColor = Color.Orange
                Else
                    grdOrdenCompra.Rows(i).Cells("Total Recibido").Appearance.BackColor = Color.YellowGreen
                End If
                If grdOrdenCompra.Rows(i).Cells("ocde_tipodeorden").Value <> "AUTOMATICA" Then
                    grdOrdenCompra.Rows(i).Cells("Material").Appearance.BackColor = System.Drawing.Color.FromArgb(250, 172, 88)
                End If
            Catch ex As Exception
            End Try
            i += 1
        Loop While i < grdOrdenCompra.Rows.Count
    End Sub

    Private Sub grdOrdenCompra_KeyDown(sender As Object, e As KeyEventArgs) Handles grdOrdenCompra.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Enter Then
                grdOrdenCompra.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdOrdenCompra.DisplayLayout.Bands(0)
                If grdOrdenCompra.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdOrdenCompra.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdOrdenCompra.ActiveCell = nextRow.Cells(grdOrdenCompra.ActiveCell.Column)
                    e.Handled = True
                    grdOrdenCompra.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
            calcularTotales()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub calcularTotales()
        Dim datos As New DataTable
        datos = grdOrdenCompra.DataSource
        Dim total As Double = 0
        For Each row As DataRow In datos.Rows
            If row("EstatusOriginal") <> "COMPLETO" Then
                row("Total") = row("Precio") * (row("Total Recibido") + row("TotalRecibidoOriginal"))
            End If
            total += row("Total")
        Next
        lblDesc.Text = Format(descuento, "##,##0.00")
        txtSubtotalText.Text = Format(total, simbolo & " ##,##0.00")
        txtDecuentoText.Text = Format(total * ((descuento / 100)), simbolo & " ##,##0.00")
        'If tipoCompra = "FACTURA" Then
        txtIvaText.Text = Format((CDbl(txtSubtotalText.Text.Replace(simbolo, "")) - CDbl(txtDecuentoText.Text.Replace(simbolo, ""))) * 0.16, simbolo & " ##,##0.00")
        'Else
        '    txtIvaText.Text = simbolo & " 0.00"
        'End If
        txtTotalText.Text = Format(CDbl(txtSubtotalText.Text.Replace(simbolo, "")) - CDbl(txtDecuentoText.Text.Replace(simbolo, "")) + CDbl(txtIvaText.Text.Replace(simbolo, "")), simbolo & " ##,##0.00")
        'grdOrdenCompra.DataSource = Nothing
        grdOrdenCompra.DataSource = datos
        setDiseño()
        pintarceldas()
    End Sub

    Private Sub grdOrdenCompra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdOrdenCompra.KeyPress
        If grdOrdenCompra.Rows.Count > 0 Then
            Try
                If Not grdOrdenCompra.ActiveCell.IsFilterRowCell Then
                    If grdOrdenCompra.ActiveCell.Column.ToString = "Estatus" Then
                        e.Handled = True
                        Return
                    Else
                        If (Convert.ToInt32(e.KeyChar) = 8) Then
                            ' Se ha pulsado la tecla retroceso 
                            Return
                        End If

                        If Char.IsDigit(e.KeyChar) Then
                            e.Handled = False
                        ElseIf Char.IsControl(e.KeyChar) Then
                            e.Handled = False
                        ElseIf e.KeyChar = "." And Not grdOrdenCompra.ActiveCell.Text.IndexOf(".") Then
                            e.Handled = True
                            Return
                        ElseIf e.KeyChar = "." Then
                            e.Handled = False
                        Else
                            e.Handled = True
                        End If
                        Dim separadorDecimal As String = _
                      Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator

                        Dim index As Integer = grdOrdenCompra.ActiveCell.Text.IndexOf(separadorDecimal)

                        If (index >= 0) Then
                            Dim decimales As String = grdOrdenCompra.ActiveCell.Text.Substring(index + 1)
                            e.Handled = (decimales.Length = 2)
                        End If

                        If (grdOrdenCompra.ActiveCell.SelLength > 0) Then e.Handled = False
                    End If

                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        guardar()
    End Sub
    Private Sub guardar()
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim estatusIncompleto As Boolean = False
            Dim contadorCancelado As Integer = 0
            Dim estatus As String = "COMPLETA"
            Dim obj As New OrdenDeCompraBU
            Dim datos As New DataTable
            datos = grdOrdenCompra.DataSource
            Dim estatusorden As String = ""

            For Each row As DataRow In datos.Rows

                obj.actualizarMaterialOrdenCompra(row("Estatus"), row("ocde_ordencompradetalleid"), row("Total Recibido"))
                If row("Estatus") = "INCOMPLETO" Or row("Estatus") = "POR RECIBIR" Then
                    estatusIncompleto = True
                ElseIf row("Estatus") = "CANCELADO" Then
                    contadorCancelado += 1
                End If
            Next
            If contadorCancelado = datos.Rows.Count Then
                Dim objConfirmacion As New ConfirmarForm
                objConfirmacion.mensaje = "¿Está seguro de cancelar todos lo materiales?, la orden de compra se cancelará."

                If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                   insertarInventario(datos)
                    obj.cancelarOrdenDeCompra(idOrdenCompra)
                End If
            Else
                    insertarInventario(datos)
                    If estatusIncompleto Then
                        estatusorden = "INCOMPLETA"
                    ElseIf contadorCancelado > 0 And contadorCancelado < datos.Rows.Count Then
                        estatusorden = "COMPLETA"
                    Else
                        estatusorden = "COMPLETA"
                    End If
                    obj.actualizarOrdenCompraEstatus(idOrdenCompra, estatusorden)
                    exito.mensaje = "Información guardada."
                    exito.ShowDialog()
                Me.Close()
            End If
        Catch ex As Exception
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub insertarInventario(ByVal datos As DataTable)
        Dim obj As New OrdenDeCompraBU
        Dim inventario As New InventarioNave

        For Each Fila As UltraGridRow In grdOrdenCompra.Rows

            inventario = New InventarioNave
            With inventario
                .naveid = Fila.Cells("mn_idNave").Value
                .materialnaveid = Fila.Cells("mn_materialNaveid").Value
                .proveedorid = Fila.Cells("prov_proveedorid").Value
                .ordencompraid = idOrdenCompra
                .fechaprograma = fechaPrograma
                '.movimientoinventarioid = obj.getMovimientoXTipoCapturaOrden(Fila.Cells("ocde_tipodeorden").Value)
                .cantidad = Fila.Cells("Total Recibido").Value
                .umc = obj.getUnidadMedida(Fila.Cells("UMC").Value)
                .ump = obj.getUnidadMedida(Fila.Cells("UMP").Value)
                .precio = Fila.Cells("Precio").Value
                .factorconversion = Fila.Cells("ocde_factorconversion").Value
                .invn_observaciones = ""
                .inventarioinicial = obj.getCantidadInicial(inventario)
                .inventariofinal = .inventarioinicial + (Fila.Cells("Total Recibido").Value)
                .monedaid = Fila.Cells("prma_monedaid").Value
                If estatusOrdenDeCompra = "POR RECIBIR" Then
                    If Fila.Cells("Estatus").Value = "COMPLETO" Or Fila.Cells("Estatus").Value = "INCOMPLETO" Then 'En estos 2 estatus solo se debe ingresar a inventario
                        If (Fila.Cells("Total Recibido").Value) > 0 Then 'Esta validación solo es para el estatus de incompleto ya que lo pueden dejar en 0 y en se caso no se debe de insertar en inventario
                            obj.insertarMovimientoInventario(inventario)
                        End If
                    End If
                Else
                    If Fila.Cells("Estatus").Value = "INCOMPLETO" Or (Fila.Cells("EstatusOriginal").Value = "INCOMPLETO" And Fila.Cells("Estatus").Value = "COMPLETO") Then 'AL estar en otro estatus(INCOMPLETA) no se deben insertar los completos
                        If (Fila.Cells("Total Recibido").Value) > 0 Then 'Esta validación solo es para el estatus de incompleto ya que lo pueden dejar en 0 y en se caso no se debe de insertar en inventario
                            obj.insertarMovimientoInventario(inventario)
                        End If
                    End If
                End If

                If Fila.Cells("Modificada").Value = 1 Then
                    obj.actualizarMaterialOrdenCompra(Fila.Cells("Estatus").Value, Fila.Cells("ocde_ordencompradetalleid").Value, (Fila.Cells("Total Recibido").Value + Fila.Cells("TotalRecibidoOriginal").Value))
                End If


            End With
        Next

        'For Each row As DataRow In datos.Rows
        '    inventario = New InventarioNave
        '    With inventario
        '        .naveid = row("mn_idNave")
        '        .materialnaveid = row("mn_materialNaveid")
        '        .proveedorid = row("prov_proveedorid")
        '        .ordencompraid = idOrdenCompra
        '        .fechaprograma = fechaPrograma
        '        .movimientoinventarioid = obj.getMovimientoXTipoCapturaOrden(row("ocde_tipodeorden"))
        '        .cantidad = row("Total Recibido")
        '        .umc = obj.getUnidadMedida(row("UMC"))
        '        .ump = obj.getUnidadMedida(row("UMP"))
        '        .precio = row("Precio")
        '        .factorconversion = row("ocde_factorconversion")
        '        .invn_observaciones = ""
        '        .inventarioinicial = obj.getCantidadInicial(inventario)
        '        .inventariofinal = .inventarioinicial + (row("Total Recibido"))
        '        .monedaid = row("prma_monedaid")
        '        If estatusOrdenDeCompra = "POR RECIBIR" Then
        '            If row("Estatus") = "COMPLETO" Or row("Estatus") = "INCOMPLETO" Then 'En estos 2 estatus solo se debe ingresar a inventario
        '                If (row("Total Recibido")) > 0 Then 'Esta validación solo es para el estatus de incompleto ya que lo pueden dejar en 0 y en se caso no se debe de insertar en inventario
        '                    obj.insertarMovimientoInventario(inventario)
        '                End If
        '            End If
        '        Else
        '            If row("Estatus") = "INCOMPLETO" Or (row("EstatusOriginal") = "INCOMPLETO" And row("Estatus") = "COMPLETO") Then 'AL estar en otro estatus(INCOMPLETA) no se deben insertar los completos
        '                If (row("Total Recibido")) > 0 Then 'Esta validación solo es para el estatus de incompleto ya que lo pueden dejar en 0 y en se caso no se debe de insertar en inventario
        '                    obj.insertarMovimientoInventario(inventario)
        '                End If
        '            End If
        '        End If


        '        obj.actualizarMaterialOrdenCompra(row("Estatus"), row("ocde_ordencompradetalleid"), (row("Total Recibido") + row("TotalRecibidoOriginal")))
        '    End With
        'Next
    End Sub
    Private Sub grdOrdenCompra_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdOrdenCompra.InitializeRow
        If estatusOrdenDeCompra = "POR RECIBIR" Then
            If (e.Row.Cells("Total Recibido").Value + e.Row.Cells("TotalRecibidoOriginal").Value) >= e.Row.Cells("Por Recibir").Value Then
                e.Row.Cells("Estatus").Value = "COMPLETO"
                e.Row.Cells("Estatus").Activation = Activation.NoEdit
            ElseIf e.Row.Cells("Estatus").Value = "CANCELADO" Then
                e.Row.Cells("Estatus").Value = "CANCELADO"
                e.Row.Cells("Estatus").Activation = Activation.AllowEdit
            Else
                e.Row.Cells("Estatus").Activation = Activation.AllowEdit
            End If
        ElseIf estatusOrdenDeCompra = "COMPLETA" Then
            e.Row.Cells("Estatus").Activation = Activation.NoEdit
            e.Row.Cells("Total Recibido").Activation = Activation.NoEdit
        Else
            If (e.Row.Cells("Total Recibido").Value + e.Row.Cells("TotalRecibidoOriginal").Value) >= e.Row.Cells("Por Recibir").Value Then
                e.Row.Cells("Estatus").Value = "COMPLETO"
                e.Row.Cells("Estatus").Activation = Activation.NoEdit
                e.Row.Cells("Total Recibido").Activation = Activation.NoEdit
            ElseIf e.Row.Cells("Estatus").Value = "CANCELADO" Then
                e.Row.Cells("Estatus").Value = "CANCELADO"
                e.Row.Cells("Estatus").Activation = Activation.NoEdit
                e.Row.Cells("Total Recibido").Activation = Activation.NoEdit
            ElseIf e.Row.Cells("Estatus").Value = "COMPLETO" Then
                e.Row.Cells("Total Recibido").Activation = Activation.NoEdit
                e.Row.Cells("Estatus").Activation = Activation.NoEdit
            Else
                e.Row.Cells("Estatus").Activation = Activation.AllowEdit
            End If
        End If
    End Sub
    Function getNumOrden(num As String) As String
        If num.Length = 1 Then
            num = "0000" & num
        ElseIf num.Length = 2 Then
            num = "000" & num
        ElseIf num.Length = 3 Then
            num = "00" & num
        ElseIf num.Length = 4 Then
            num = "0" & num
        ElseIf num.Length = 5 Then
            num = num
        End If
        Return num
    End Function
    Public Sub totalesGrid()
        Dim obj As New PreordenCompraBU
        Dim componente As String = ""
        Dim clasificacion As String = ""
        Dim unidadmedida As String = ""
        Dim total As Double = 0
        Dim idclasificacion As Integer = 0
        Dim consumo As Double = 0

        Dim listaClasificaciones As New List(Of Integer)
        Dim Tabla As New DataTable
        Tabla.Columns.Add("Clasificación")
        Tabla.Columns.Add("Consumo")
        Tabla.Columns.Add("UMC")
        Tabla.Columns.Add("Total")
        Try
            For value = 0 To grdOrdenCompra.Rows.Count - 1
                Try
                    clasificacion = grdOrdenCompra.Rows(value).Cells("IDc").Value
                    If listaClasificaciones.Contains(clasificacion) Then
                    Else
                        listaClasificaciones.Add(clasificacion)
                    End If
                Catch ex As Exception

                End Try
            Next

            For x = 0 To listaClasificaciones.Count - 1
                consumo = 0
                total = 0
                Dim tablaclasificaciones = obj.ObtenerNombreClasificacion(listaClasificaciones.Item(x))
                clasificacion = tablaclasificaciones.Rows(0).Item(0).ToString
                For value = 0 To grdOrdenCompra.Rows.Count - 1
                    If grdOrdenCompra.Rows(value).Cells("IDc").Text <= "CANCELADO" Then
                        If grdOrdenCompra.Rows(value).Cells("IDc").Text = listaClasificaciones.Item(x).ToString Then
                            consumo = consumo + grdOrdenCompra.Rows(value).Cells("Total Recibido").Text
                            unidadmedida = grdOrdenCompra.Rows(value).Cells("UMC").Text
                            total = total + (CDbl(grdOrdenCompra.Rows(value).Cells("Total Recibido").Text)) * grdOrdenCompra.Rows(value).Cells("Precio").Text.Replace(simbolo, "")
                            End If
                    End If
                Next
                Dim rowc As DataRow = Tabla.NewRow()
                rowc("Clasificación") = clasificacion
                rowc("Consumo") = Format(consumo, "##,##0.00")
                rowc("UMC") = unidadmedida
                rowc("Total") = Format(total, simbolo & " ##,##0.00")
                Tabla.Rows.Add(rowc)
            Next

            grdClasificacion.DataSource = Tabla
            diseñoGridClasificacion()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub diseñoGridClasificacion()
        Me.Cursor = Cursors.WaitCursor

        With grdClasificacion.DisplayLayout.Bands(0)

            .Columns("Clasificación").Width = 50
            .Columns("Consumo").Width = 30
            .Columns("Consumo").Header.Caption = "Total Recibido"
            .Columns("UMC").Width = 30
            .Columns("Total").Width = 30
            .Columns("Total").Header.Caption = "Total Compra"

            .Columns("Consumo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total").CellAppearance.TextHAlign = HAlign.Right

            .Columns("Clasificación").CellActivation = Activation.NoEdit
            .Columns("Consumo").CellActivation = Activation.NoEdit
            .Columns("UMC").CellActivation = Activation.NoEdit
            .Columns("Total").CellActivation = Activation.NoEdit

            .Columns("Consumo").Format = "##,##0.00"
            .Columns("Total").Format = "##,##0.00"

        End With
        grdClasificacion.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdClasificacion.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdClasificacion.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub grdOrdenCompra_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdOrdenCompra.BeforeCellUpdate
        If Not e.Cell.IsFilterRowCell Then
            If Not estatusOrdenDeCompra = "POR RECIBIR" Then
                'If e.Cell.Column.ToString = "Total Recibido" Then
                '    If e.Cell.Value > e.NewValue And grdOrdenCompra.ActiveRow.Cells("Estatus").Value = "INCOMPLETO" Then
                '        adv.mensaje = "Cantidad no válida"
                '        adv.ShowDialog()
                '        e.Cancel = True
                '    End If
                'End If
                If e.Cell.Column.ToString = "Estatus" Then
                    If e.NewValue = "CANCELADO" And grdOrdenCompra.ActiveRow.Cells("totalRecibidoOriginal").Value > 0 Then
                        adv.mensaje = "Existen materiales ya recibidos."
                        adv.ShowDialog()
                        e.Cancel = True
                    End If
                End If
               
            End If
        End If
    End Sub
End Class