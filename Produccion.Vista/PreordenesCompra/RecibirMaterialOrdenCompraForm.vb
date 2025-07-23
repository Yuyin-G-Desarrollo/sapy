Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Infragistics.Win
Imports Programacion.Vista

Public Class RecibirMaterialOrdenCompraForm
    Dim adv As New AdvertenciaForm
    Dim exito As New ExitoForm
    Dim listaInicial As New List(Of String)

    Private Sub RecibirMaterialOrdenCompraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        'cmbEstatus.SelectedIndex = 1
        LlenarListasNaves()
        grdEstatus.DataSource = listaInicial
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cmbNave.SelectedValue = 0
        grdOrdenCompra.DataSource = Nothing
    End Sub

    Public Sub LlenarListasNaves()
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
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

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If cmbNave.SelectedIndex > 0 Then
            llenarGrid()
        End If
    End Sub

    Public Sub llenarGrid()
        Me.Cursor = Cursors.WaitCursor
        Dim simbolo As String = ""
        Dim FEstatus As String = String.Empty

        If cmbNave.SelectedIndex > 0 Then
            Dim obj As New OrdenDeCompraBU
            'Dim estatus As String = ""
            grdOrdenCompra.DataSource = Nothing
            Try
                'If Not IsDBNull(cmbEstatus.SelectedValue) Then
                '    estatus = cmbEstatus.SelectedItem.ToString
                'End If
            Catch ex As Exception
            End Try

            FEstatus = ObtenerFiltrosGrid(grdEstatus)
            Dim datos As New DataTable
            datos = obj.consultarOrdenesDeCompra(dtpPrograma.Value, cmbNave.SelectedValue, FEstatus, chkFecha.Checked)
            For Each row As DataRow In datos.Rows
                row("NoOrden") = getNumOrden(row("ORDEN"))
                simbolo = row("mone_simbolo")
            Next
            grdOrdenCompra.DataSource = datos
        End If
        With grdOrdenCompra.DisplayLayout.Bands(0)
            .Columns("ordc_ordencompraid").Hidden = True
            .Columns("ordc_tipodedocumento").Hidden = True
            .Columns("mone_simbolo").Hidden = True
            .Columns("Estatus").Hidden = True
            .Columns("Subtotal Recibido").Format = "##,##0.00"
            .Columns("TOTAL").Format = "##,##0.00"
            .Columns("Subtotal Recibido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Programa").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Entrega").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("autorizo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Programa").Header.Caption = "Fecha" & vbCrLf & "Programa"
            .Columns("Entrega").Header.Caption = "Fecha" & vbCrLf & "Entrega"
            .Columns("Tipo").Header.Caption = "Tipo" & vbCrLf & "Orden"
            .Columns("TipoCaptura").Hidden = True
            .Columns("TOTAL").Header.Caption = "Subtotal"
            .Columns("DESCUENTO").Header.Caption = "Descuento" & vbCrLf & "%"
            .Columns("ORDEN").Hidden = True
            .Columns("NoOrden").Header.Caption = "Número" & vbCrLf & "Orden"
            .Columns("Subtotal Recibido").Header.Caption = "Subtotal" & vbCrLf & "Recibido"
            .Columns("materiales").Header.Caption = "Número" & vbCrLf & "Materiales"
            .Columns("TipoCaptura").Header.Caption = "Tipo" & vbCrLf & "Captura"
            .Columns("fechaCreo").Hidden = True
            .Columns("autorizo").Header.Caption = "Fecha" & vbCrLf & "Autorización"
            .Columns("Recepción").Header.Caption = "Fecha" & vbCrLf & "Recibido"
            .Columns("Usuario").Header.Caption = "Usuario" & vbCrLf & "Recibió"
            .Columns("fechaCreo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Recepción").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Usuario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("TOTAL").Width = 70
            .Columns("Proveedor").Width = 300
            .Columns("NoOrden").Width = 55
            .Columns("TOTAL").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("NoOrden").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("materiales").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("NoOrden").CellAppearance.FontData.Bold = DefaultableBoolean.True
            .Columns("Seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Seleccion").Style = ColumnStyle.CheckBox
            .Columns("Seleccion").Header.Caption = " "
            .Columns("Seleccion").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("Seleccion").Width = 20
            Try
                'If cmbEstatus.SelectedIndex = 0 Or cmbEstatus.SelectedIndex = 4 Then
                '    .Columns("Recepción").Hidden = False
                '    .Columns("Usuario").Hidden = False
                'Else
                '    .Columns("Recepción").Hidden = True
                '    .Columns("Usuario").Hidden = True
                'End If
            Catch ex As Exception

            End Try
        End With

        grdOrdenCompra.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdOrdenCompra.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdOrdenCompra.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        pintarceldas()
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub pintarceldas()
        Try
            Dim i As Integer = 0
            Do
                Dim wD As Long = DateDiff(DateInterval.Day, CDate(grdOrdenCompra.Rows(i).Cells("Entrega").Value), Now.Date)
                If grdOrdenCompra.Rows(i).Cells("Estatus").Value = "POR RECIBIR" Then
                    grdOrdenCompra.Rows(i).Cells("NoOrden").Appearance.BackColor = pnlPorRecibir.BackColor
                    If wD >= 8 Then
                        grdOrdenCompra.Rows(i).Cells("Entrega").Appearance.BackColor = pnlFechaEntrega.BackColor
                    End If
                ElseIf grdOrdenCompra.Rows(i).Cells("Estatus").Value = "INCOMPLETA" Then
                    grdOrdenCompra.Rows(i).Cells("NoOrden").Appearance.BackColor = pnlIncompleta.BackColor
                    If wD >= 8 Then
                        grdOrdenCompra.Rows(i).Cells("Entrega").Appearance.BackColor = Color.Crimson
                    End If
                ElseIf grdOrdenCompra.Rows(i).Cells("Estatus").Value = "COMPLETA" Then
                    grdOrdenCompra.Rows(i).Cells("NoOrden").Appearance.BackColor = pnlCompleta.BackColor
                ElseIf grdOrdenCompra.Rows(i).Cells("Estatus").Value = "CANCELADA" Then
                    grdOrdenCompra.Rows(i).Cells("NoOrden").Appearance.BackColor = pnlCancelada.BackColor
                ElseIf grdOrdenCompra.Rows(i).Cells("Estatus").Value = "CERRADA" Then
                    grdOrdenCompra.Rows(i).Cells("NoOrden").Appearance.BackColor = pnlCerrada.BackColor
                End If
                If grdOrdenCompra.Rows(i).Cells("TipoCaptura").Value = "AUTOMÁTICA" Then
                    grdOrdenCompra.Rows(i).Cells("Seleccion").Appearance.BackColor = pnlAutomatica.BackColor
                Else
                    grdOrdenCompra.Rows(i).Cells("Seleccion").Appearance.BackColor = pnlManual.BackColor
                End If



                i = i + 1
            Loop While i < grdOrdenCompra.Rows.Count
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdOrdenCompra_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdOrdenCompra.ClickCell
        Try
            If Not grdOrdenCompra.ActiveCell.Column.ToString = "Seleccion" Then
                grdOrdenCompra.ActiveRow.Selected = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        Try
            Dim contador As Integer = 0
            Dim f As New RecibirMaterialesForm

            For value = 0 To grdOrdenCompra.Rows.Count - 1
                If grdOrdenCompra.Rows(value).Cells("Seleccion").Value = 1 Then
                    contador = contador + 1
                End If
            Next

            If grdOrdenCompra.ActiveRow.Selected = True Or contador > 0 Then

                f.idOrdenCompra = grdOrdenCompra.ActiveRow.Cells("ordc_ordencompraid").Value
                f.estatusOrdenDeCompra = grdOrdenCompra.ActiveRow.Cells("Estatus").Value
                f.ShowDialog()
                If cmbNave.SelectedIndex > 0 Then
                    llenarGrid()
                End If
            Else
                adv.mensaje = "Selecciona una orden de compra"
                adv.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        cancelar()
    End Sub
    Public Sub validarSeleccion()
        Dim datos As New DataTable
        datos = grdOrdenCompra.DataSource
        For Each row As DataRow In datos.Rows
            If row("Seleccion") = 1 Then
                If row("Estatus") = "POR RECIBIR" Then
                    row("Seleccion") = 1
                Else
                    row("Seleccion") = 0
                End If
            End If
        Next
    End Sub
    Public Sub cancelar()
        Try
            validarSeleccion()
            Dim objConfirmacion As New ConfirmarForm
            objConfirmacion.mensaje = "¿Está seguro de cancelar las órdenes de compra seleccionadas?"
            If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim obj As New OrdenDeCompraBU
                Dim datos As New DataTable
                datos = grdOrdenCompra.DataSource
                For Each row As DataRow In datos.Rows
                    If CBool(row("Seleccion")) Then
                        obj.cancelarOrdenDeCompra(row("ordc_ordencompraid"))
                    End If
                Next
                exito.mensaje = "Órdenes Canceladas"
                exito.ShowDialog()
                If cmbNave.SelectedIndex > 0 Then
                    llenarGrid()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFecha.CheckedChanged
        If chkFecha.Checked Then
            dtpPrograma.Enabled = True
        Else
            dtpPrograma.Value = Date.Now
            dtpPrograma.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRecibirDocFac.Click
        Try
            If grdOrdenCompra.ActiveRow.Selected = True Then
                If grdOrdenCompra.ActiveRow.Cells("Estatus").Value = "COMPLETA" Then
                    'If grdOrdenCompra.ActiveRow.Cells("ordc_tipodedocumento").Value = "FACTURA" Then
                    Dim form As New RecepcionFacturasForm
                        form.idOrdendeCompra = grdOrdenCompra.ActiveRow.Cells("ordc_ordencompraid").Value
                        form.ShowDialog()
                    'Else
                    '    Dim form As New RecibirRemisionesForm
                    '    form.idOrdendeCompra = grdOrdenCompra.ActiveRow.Cells("ordc_ordencompraid").Value
                    '    form.ShowDialog()
                    'End If
                    llenarGrid()
                Else
                    adv.mensaje = "Selecciona una orden de compra 'COMPLETA'"
                    adv.ShowDialog()
                End If
            Else
                adv.mensaje = "Selecciona una orden de compra"
                adv.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnVerxml_Click(sender As Object, e As EventArgs) Handles btnVerxml.Click
        If grdOrdenCompra.ActiveRow.Selected = True Then
            If grdOrdenCompra.ActiveRow.Cells("Estatus").Value = "CERRADA" Then
                If grdOrdenCompra.ActiveRow.Cells("ordc_tipodedocumento").Value = "FACTURA" Then 'vALIDAR SI ES FACTURA
                    Dim datos As New DataTable
                    Dim obj As New RecepcionBU
                    datos = obj.getDocumentosOrden(grdOrdenCompra.ActiveRow.Cells("ordc_ordencompraid").Value)
                    If datos.Rows.Count > 0 Then
                        Me.Cursor = Cursors.WaitCursor
                        If datos.Rows(0).Item(0).ToString.Length > 0 Then
                            abrirArchivo(datos.Rows(0).Item(0).ToString)
                        Else
                            adv.mensaje = "La orden de compra no contiene un pdf relacionado"
                            adv.ShowDialog()
                        End If
                        Me.Cursor = Cursors.Default
                    End If
                Else
                    adv.mensaje = "La orden de compra no contiene un xml relacionado"
                    adv.ShowDialog()
                End If
            Else
                adv.mensaje = "Seleccione una orden de compra con estatus 'CERRADA'"
                adv.ShowDialog()
            End If
        Else
            adv.mensaje = "Seleccione un registro."
            adv.ShowDialog()
        End If
    End Sub

    Private Sub btnVerpdf_Click(sender As Object, e As EventArgs) Handles btnVerpdf.Click
        If grdOrdenCompra.ActiveRow.Selected = True Then
            If grdOrdenCompra.ActiveRow.Cells("Estatus").Value = "CERRADA" Then
                Dim datos As New DataTable
                Dim obj As New RecepcionBU
                If grdOrdenCompra.ActiveRow.Cells("ordc_tipodedocumento").Value = "FACTURA" Or validarRemisionExtranjera(grdOrdenCompra.ActiveRow.Cells("ordc_ordencompraid").Value) Then
                    If grdOrdenCompra.ActiveRow.Cells("ordc_tipodedocumento").Value = "FACTURA" Then

                        datos = obj.getDocumentosOrden(grdOrdenCompra.ActiveRow.Cells("ordc_ordencompraid").Value)
                        If datos.Rows.Count > 0 Then
                            Me.Cursor = Cursors.WaitCursor
                            If datos.Rows(0).Item(0).ToString.Length > 0 Then
                                abrirArchivo(datos.Rows(0).Item(1).ToString)
                            Else
                                adv.mensaje = "La orden de compra no contiene un pdf relacionado"
                                adv.ShowDialog()
                            End If
                            Me.Cursor = Cursors.Default
                        End If
                    ElseIf validarRemisionExtranjera(grdOrdenCompra.ActiveRow.Cells("ordc_ordencompraid").Value) Then
                        datos = obj.getPDFProveedorExtranjero(grdOrdenCompra.ActiveRow.Cells("ordc_ordencompraid").Value)
                        Me.Cursor = Cursors.WaitCursor
                        If datos.Rows(0).Item(0).ToString.Length > 0 Then
                            abrirArchivo(datos.Rows(0).Item(0).ToString)
                        Else
                            adv.mensaje = "La orden de compra no contiene un pdf relacionado"
                            adv.ShowDialog()
                        End If
                        Me.Cursor = Cursors.Default
                    Else
                        adv.mensaje = "La orden de compra no contiene un pdf relacionado"
                        adv.ShowDialog()
                    End If

                Else
                    adv.mensaje = "La orden de compra no contiene un pdf relacionado"
                    adv.ShowDialog()
                End If
            Else
                adv.mensaje = "Seleccione una orden de compra con estatus 'CERRADA'"
                adv.ShowDialog()
            End If
        Else
            adv.mensaje = "Seleccione un registro."
            adv.ShowDialog()
        End If
    End Sub
    Function validarRemisionExtranjera(ByVal ordencompraid As Integer) As Boolean
        Dim idProveedor As Integer = 0
        Dim obj As New RecepcionBU
        idProveedor = obj.getProveedorOrdenCompra(ordencompraid)
        If obj.getPaisProveedor(idProveedor) <> "MÉXICO" Then
            adv.mensaje = "La orden de compra no contiene un pdf relacionado"
            adv.ShowDialog()
            Return False
        End If
        Return True
    End Function
    Private Sub abrirArchivo(ByVal ruta As String)
        Try
            Process.Start(ruta) 'Este evento lo corre en segundo plano puede tardar en ejecutarse y mostrar algún error
            'Al correrse en segundo plano permite ejecutar el método varias veces
        Catch ex As Exception
            adv.mensaje = ex.Message
            adv.ShowDialog()
        End Try
    End Sub

    Private Sub btnAgregarEstatus_Click(sender As Object, e As EventArgs) Handles btnAgregarEstatus.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 15

        For Each row As UltraGridRow In grdEstatus.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdEstatus.DataSource = listado.listParametros
        With grdEstatus
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Estatus"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimpiarEstatus_Click(sender As Object, e As EventArgs) Handles btnLimpiarEstatus.Click
        grdEstatus.DataSource = listaInicial

    End Sub

    Private Sub grdEstatus_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdEstatus.InitializeLayout
        grid_diseño(grdEstatus)
        grdEstatus.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Estatus"
    End Sub

    Private Sub grdEstatus_KeyDown(sender As Object, e As KeyEventArgs) Handles grdEstatus.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdEstatus.DeleteSelectedRows(False)
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        asignaFormato_Columna(grid)
    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                col.CellAppearance.TextHAlign = HAlign.Left
            End If
        Next
    End Sub

    Private Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty
        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next
        Return Resultado
    End Function

    Private Sub grdOrdenCompra_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles grdOrdenCompra.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        btnDetalle_Click(Nothing, Nothing)
        Me.Cursor = Cursors.Default
    End Sub
End Class