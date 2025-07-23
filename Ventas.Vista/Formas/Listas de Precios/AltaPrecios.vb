Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
Imports Infragistics.Win.SupportDialogs.FilterUIProvider
Imports Infragistics.Win

Public Class AltaPrecios
    Dim dtFiltroMarca As DataTable
    Dim dtFiltroColeccion As DataTable
    Dim dtFiltroPiel As DataTable
    Dim dtFiltroColor As DataTable
    Dim cadenaMarca As String
    Dim cierraForm As Boolean = True
    Dim endEdit As Boolean = True

    Public Sub generarCodigo()
        Dim objLBP As New Ventas.Negocios.ListaBaseBU
        Dim dtDatosListaBase As New DataTable
        dtDatosListaBase = objLBP.consecutivoCod(DateTime.Now.Year)
        Dim consecutivo As String = String.Empty
        consecutivo = CStr(CInt(dtDatosListaBase.Rows(0)(0).ToString) + 1)

        txtCodigo.Text = consecutivo + DateTime.Now.Year.ToString + DateTime.Now.Month.ToString.PadLeft(2, "0")
        dttInicio.Value = DateTime.Now
    End Sub

    Public Sub llenarListaDeModelos()
        Dim objProd As New Ventas.Negocios.ListaBaseBU
        Dim dtDatosModelos As New DataTable
        dtDatosModelos = objProd.verProductosListasPrecios
        grdDatosProductos.DataSource = dtDatosModelos
        lblTotalArticulos.Text = dtDatosModelos.Rows.Count.ToString("N0")

        Dim colPrecio As UltraGridColumn = grdDatosProductos.DisplayLayout.Bands(0).Columns("Precio")
        colPrecio.Style = ColumnStyle.CurrencyNonNegative
        'colPrecio.MaskInput = "nnnn.nn"
        colPrecio.FilterOperandStyle = FilterOperandStyle.Edit
        colPrecio.CellActivation = Activation.AllowEdit
        colPrecio.Header.Caption = "Precio"

        grdDatosProductos.DisplayLayout.Bands(0).Columns.Add("Estado", "Estado")
        Dim colEstado As UltraGridColumn = grdDatosProductos.DisplayLayout.Bands(0).Columns("Estado")
        colEstado.DefaultCellValue = False
        colEstado.Header.Caption = ""
        colEstado.Header.VisiblePosition = 0
        colEstado.CellAppearance.TextHAlign = HAlign.Center
        colEstado.Width = 50

        grdDatosProductos.DisplayLayout.Bands(0).Columns.Add("Seleccion", "Seleccion")
        Dim colSeleccion As UltraGridColumn = grdDatosProductos.DisplayLayout.Bands(0).Columns("Seleccion")
        colSeleccion.DefaultCellValue = False
        colSeleccion.Header.Caption = ""
        colSeleccion.Header.VisiblePosition = 0
        colSeleccion.Style = ColumnStyle.CheckBox
        colSeleccion.Width = 50
  

        For Each rowGR As UltraGridRow In grdDatosProductos.Rows
            rowGR.Cells("Seleccion").Value = False
            rowGR.Cells("Estado").Value = "N"
            rowGR.Cells("Estado").Appearance.BackColor = Color.Red
            ''If CBool(rowGR.Cells("marc_decimales").Value) = True Then
            'rowGR.Cells("Precio").Value =0
            ''End If
        Next

        ' ''For Each rowD As UltraGridRow In grdDatosProductos.Rows
        ' ''    If CBool(rowD.Cells("pres_activo").Value.ToString) = True Then
        ' ''        rowD.Cells("pres_activo").Appearance.BackColor = Color.Beige
        ' ''    Else
        ' ''        rowD.Cells("pres_activo").Appearance.BackColor = Color.Red
        ' ''        'rowD.Cells("estatusColumn").Appearance.ImageBackground = Global.Ventas.Vista.My.Resources.Resources._1373583708_10
        ' ''        'rowD.Cells("estatusColumn").Appearance.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered
        ' ''        'rowD.Cells("estatusColumn").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image
        ' ''    End If
        ' ''Next
        lblArticulosConPrecio.Text = "0"
        lblSinPrecio.Text = dtDatosModelos.Rows.Count.ToString("N0")
        formatosGrid()
        endEdit = False
    End Sub

    Public Sub formatosGrid()
        With grdDatosProductos.DisplayLayout.Bands(0)
            .Columns("pres_productoestiloid").Hidden = True
            .Columns("cole_coleccionid").Hidden = True
            .Columns("marc_marcaid").Hidden = True
            .Columns("piel_pielid").Hidden = True
            .Columns("color_colorid").Hidden = True
            .Columns("talla_tallaid").Hidden = True
            .Columns("pres_activo").Hidden = True
            .Columns("fami_familiaid").Hidden = True
            .Columns("linea_lineaid").Hidden = True
            .Columns("stpr_productoStatusId").Hidden = True
            .Columns("marc_decimales").Hidden = True

            .Columns("prod_codigo").Header.Caption = "Modelo"
            .Columns("prod_descripcion").Header.Caption = "Descripción"
            .Columns("cole_descripcion").Header.Caption = "Colección"
            .Columns("marc_descripcion").Header.Caption = "Marca"
            .Columns("piel_descripcion").Header.Caption = "Piel"
            .Columns("color_descripcion").Header.Caption = "Color"
            .Columns("talla_descripcion").Header.Caption = "Corrida"
            .Columns("pres_codSicy").Header.Caption = "SICY"
            .Columns("fami_descripcion").Header.Caption = "Familia"
            .Columns("linea_descripcion").Header.Caption = "Linea"
            .Columns("stpr_descripcion").Header.Caption = "Estatus"

            '.Columns("pres_activo").Header.Caption = "Estatus"
            .Columns("prod_codigo").CellActivation = Activation.NoEdit
            .Columns("prod_descripcion").CellActivation = Activation.NoEdit
            .Columns("cole_descripcion").CellActivation = Activation.NoEdit
            .Columns("marc_descripcion").CellActivation = Activation.NoEdit
            .Columns("piel_descripcion").CellActivation = Activation.NoEdit
            .Columns("color_descripcion").CellActivation = Activation.NoEdit
            .Columns("talla_descripcion").CellActivation = Activation.NoEdit
            .Columns("pres_codSicy").CellActivation = Activation.NoEdit
            .Columns("fami_descripcion").CellActivation = Activation.NoEdit
            .Columns("linea_descripcion").CellActivation = Activation.NoEdit
            .Columns("stpr_descripcion").CellActivation = Activation.NoEdit

            .Columns("prod_codigo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("talla_descripcion").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Precio").CellAppearance.TextHAlign = HAlign.Right

            '.Columns("Precio").MaskInput = "nnn.nn"

            '.Columns("pres_activo").CellActivation = Activation.NoEdit
            .Columns("Precio").FilterOperatorDefaultValue = FilterOperatorDefaultValue.Equals
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdDatosProductos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdDatosProductos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDatosProductos.DisplayLayout.Override.RowSelectorWidth = 35
        grdDatosProductos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdDatosProductos.Rows(0).Selected = True
    End Sub

    Private Sub AltaPrecios_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If cierraForm = True Then
            e.Cancel = True
            Dim objMsjConfirma As New Tools.ConfirmarForm
            objMsjConfirma.mensaje = "¿Está seguro de cerrar sin guardar cambios?" + vbLf + "Si la pantalla se cierra se perderá la información y no podrá ser recuperada."
            If objMsjConfirma.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim nuevoMensaje As New Tools.AvisoForm
                nuevoMensaje.mensaje = "La pantalla se cerrará sin guardar cambios."
                nuevoMensaje.ShowDialog()
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub AltaPrecios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub AltaPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized
        generarCodigo()
        Me.Cursor = Cursors.WaitCursor
        llenarListaDeModelos()
        Me.Cursor = Cursors.Default
        dttFin.MinDate = DateTime.Today.AddMonths(1)
        dttInicio.MinDate = DateTime.Today
    End Sub

    Private Sub btnCargarPrecioMultiple_Click(sender As Object, e As EventArgs) Handles btnCargarPrecioMultiple.Click
        asignarPrecios()
    End Sub

    Public Sub asignarPrecios()
        If txtPrecioMultiple.Text.Length > 0 Then
            If CDec(txtPrecioMultiple.Text) > 0 Then
                Dim contFilasCambio As Int32 = 0
                For Each rowGR As UltraGridRow In grdDatosProductos.Rows.GetFilteredInNonGroupByRows
                    If CBool(rowGR.Cells("Seleccion").Text) = True Then
                        contFilasCambio += 1
                    End If
                Next
                If contFilasCambio > 0 Then

                    Dim objCaptcha As New Tools.frmCaptcha
                    objCaptcha.mensaje = "Registros por actualizar: " + contFilasCambio.ToString("N0")

                    If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then
                        For Each rowLB As UltraGridRow In grdDatosProductos.Rows.GetFilteredInNonGroupByRows

                            If CBool(rowLB.Cells("Seleccion").Value) = True Then
                                If CBool(rowLB.Cells("marc_decimales").Value) = False Then
                                    rowLB.Cells("precio").Value = Math.Round(CDbl(txtPrecioMultiple.Text))
                                Else
                                    rowLB.Cells("precio").Value = txtPrecioMultiple.Text
                                End If
                            End If
                        Next

                        Dim contadorPrecio As Int32 = 0
                        For Each rowGR As UltraGridRow In grdDatosProductos.Rows
                            If rowGR.Cells("Precio").Value > 0 Then
                                contadorPrecio += 1
                            End If
                        Next
                        lblArticulosConPrecio.Text = contadorPrecio.ToString("N0")
                        chkSeleccionarFiltrados.Checked = False
                        For Each rowGr As UltraGridRow In grdDatosProductos.Rows
                            rowGr.Cells("Seleccion").Value = False
                        Next
                        lblTotalSeleccionados.Text = "0"
                    End If
                Else
                    MsgBox("Debe seleccionar al menos un registro", MsgBoxStyle.Information, "Atención")
                End If
            End If
        End If
    End Sub

    Public Function validaCeros() As Boolean
        Dim cont As Int32 = 0
        For Each rowP As UltraGridRow In grdDatosProductos.Rows
            If rowP.Cells("precio").Value = 0 Then
                rowP.Appearance.BackColor = Color.PaleTurquoise
                cont = cont + 1
            Else
                rowP.Appearance.BackColor = Nothing
            End If
        Next
        If cont > 0 Then
            Return False
        End If
        Return True

    End Function

    Public Function validarFechas() As Boolean
        If dttFin.Value.Date <= DateTime.Now.Date Or dttFin.Value.Date <= dttInicio.Value.Date Then
            lblFechaFin.ForeColor = Color.Red
            Return False
        Else
            lblFechaFin.ForeColor = Color.Black
        End If
        Return True
    End Function

    Public Function validarVacios() As Boolean
        If txtDescripcion.Text = "" Then
            lblDescripcion.ForeColor = Color.Red
            Return False
        Else
            lblDescripcion.ForeColor = Color.Black
        End If
        Return True
    End Function

    Public Sub guardarDatos()
        Try
            Dim objLPB As New Ventas.Negocios.ListaBaseBU
            Dim enLBS As New Entidades.ListaBase
            Dim idListaMax As Int32 = 0
            Dim idListaTempotal As Int32 = 0
            Dim dtDatoIdMaxLPB As New DataTable
            enLBS.PListaBaseCodigo = txtCodigo.Text
            enLBS.PListaBaseNombre = txtDescripcion.Text
            enLBS.PVigenciaInicio = dttInicio.Value.ToString
            enLBS.PVigenciaFin = dttFin.Value.ToString
            Cursor = Cursors.WaitCursor
            dtDatoIdMaxLPB = objLPB.guardarListaBaseNueva(enLBS)
            idListaMax = CInt(dtDatoIdMaxLPB.Rows(0)(0).ToString)
            idListaTempotal = CInt(dtDatoIdMaxLPB.Rows(0)(1).ToString)
            If idListaMax > 0 Then
                For Each rowP As UltraGridRow In grdDatosProductos.Rows
                    'If (rowP.Cells("Precio").Text.Replace("_", "")).Replace("$", "") <> "." And (rowP.Cells("Precio").Text.Replace("_", "")).Replace("$", "") <> "" Then
                    '    If CDbl((rowP.Cells("Precio").Text.Replace("_", "")).Replace("$", "")) > 0 Then
                    If rowP.Cells("Precio").Value.ToString.Length > 0 Then
                        If CInt(rowP.Cells("Precio").Value) > 0 Then
                            objLPB.guardarListaBaseDetalles(idListaMax, rowP.Cells("pres_productoestiloid").Value.ToString, rowP.Cells("Precio").Value.ToString)
                        End If
                    End If
                Next

                Dim dtArticulosListaBase As New DataTable
                Dim objLVBU As New Negocios.ListaVentasBU
                Dim dtTipoIvas As New DataTable
                Dim dtTipoFletes As New DataTable

                dtTipoIvas = objLVBU.tipoIva("ALTA", 0)
                dtTipoFletes = objLVBU.tipoFlete("ALTA", 0)

                dtArticulosListaBase = objLPB.consultaEstiloPrecio(idListaMax)
                For Each rowdt As DataRow In dtArticulosListaBase.Rows
                    objLVBU.guardarPrestiloPrecio(idListaTempotal, rowdt.Item("lpbp_productoestiloid"), rowdt.Item("lpbp_preciobase"), rowdt.Item("lpbp_preciobase"))
                Next

                For Each rowDT As DataRow In dtTipoIvas.Rows
                    objLVBU.registrarIvaFlete(idListaTempotal, rowDT.Item("tiva_tipoivaid").ToString, "TIPOIVA")
                Next

                For Each rowGTF As DataRow In dtTipoFletes.Rows
                    objLVBU.registrarIvaFlete(idListaTempotal, rowGTF.Item("tifl_tipofleteid").ToString, "TIPOFLETE")
                Next

                Cursor = Cursors.Default
            Else
                Cursor = Cursors.Default
                MsgBox("La lista no se pudo guardar", MsgBoxStyle.Critical, "Atención")
                Me.Close()
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validarVacios() = True Then
            If validarFechas() = True Then

                Dim objMsgSINO As New Tools.ConfirmarForm
                objMsgSINO.mensaje = "¿Está seguro de guardar los cambios?"
                If objMsgSINO.ShowDialog = Windows.Forms.DialogResult.OK Then
                    guardarDatos()
                    Dim objMsgExito As New Tools.ExitoForm
                    objMsgExito.mensaje = "La lista base se registró exitosamente."
                    objMsgExito.ShowDialog()
                    cierraForm = False
                    Me.Close()
                Else
                    Exit Sub
                End If
            Else
                Dim objMsAdv As New Tools.AdvertenciaForm
                objMsAdv.mensaje = "La Fecha Fin no es valida."
                objMsAdv.ShowDialog()
            End If
        Else
            Dim objMsAdv As New Tools.AdvertenciaForm
            objMsAdv.mensaje = "Debe ingresar un nombre para la lista base."
            objMsAdv.ShowDialog()
        End If

    End Sub

    Private Sub grdDatosProductos_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdDatosProductos.AfterCellUpdate
        If endEdit = False Then
            If (e.Cell.Column.ToString = "precio" And e.Cell.Row.Index <> grdDatosProductos.Rows.FilterRow.Index) Then
                If e.Cell.Value.ToString = "" Then
                    e.Cell.Value = 0
                ElseIf e.Cell.Value > 9999 Then
                    e.Cell.Value = 0
                End If
            End If
        End If
        If e.Cell.Column.Key = "Precio" And e.Cell.Row.Index <> grdDatosProductos.Rows.FilterRow.Index Then

            Dim PrecioAnterior As String = e.Cell.OriginalValue.ToString
            If Not e.Cell.Value Is DBNull.Value Then
                If e.Cell.Value = 0 Then
                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Estado").Appearance.BackColor = Color.Red
                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "N"
                    If PrecioAnterior = 0 And e.Cell.Value = 0 Then
                    ElseIf PrecioAnterior > 0 And e.Cell.Value > 0 Then
                    ElseIf PrecioAnterior = 0 And e.Cell.Value > 0 Then
                        lblConPrecio.Text = (CInt(lblConPrecio.Text) + 1).ToString("N0")
                        lblArticulosConPrecio.Text = (CInt(lblArticulosConPrecio.Text) + 1).ToString("N0")
                        lblSinPrecio.Text = (CInt(lblSinPrecio.Text) - 1).ToString("N0")
                    ElseIf PrecioAnterior > 0 And e.Cell.Value = 0 Then
                        lblConPrecio.Text = (CInt(lblConPrecio.Text) - 1).ToString("N0")
                        lblArticulosConPrecio.Text = (CInt(lblArticulosConPrecio.Text) - 1).ToString("N0")
                        lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")
                    End If
                ElseIf e.Cell.Value > 0 Then
                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Estado").Appearance.BackColor = Color.DodgerBlue
                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "P"
                    If PrecioAnterior = 0 And e.Cell.Value = 0 Then
                    ElseIf PrecioAnterior > 0 And e.Cell.Value > 0 Then
                    ElseIf PrecioAnterior = 0 And e.Cell.Value > 0 Then
                        lblConPrecio.Text = (CInt(lblConPrecio.Text) + 1).ToString("N0")
                        lblArticulosConPrecio.Text = (CInt(lblArticulosConPrecio.Text) + 1).ToString("N0")
                        lblSinPrecio.Text = (CInt(lblSinPrecio.Text) - 1).ToString("N0")
                    ElseIf PrecioAnterior > 0 And e.Cell.Value = 0 Then
                        lblConPrecio.Text = (CInt(lblConPrecio.Text) - 1).ToString("N0")
                        lblArticulosConPrecio.Text = (CInt(lblArticulosConPrecio.Text) - 1).ToString("N0")
                        lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")
                    End If
                End If
            Else
                e.Cell.Value = 0
            End If
        End If
    End Sub

    Private Sub grdDatosProductos_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdDatosProductos.BeforeCellUpdate
        If e.Cell.Row.IsFilterRow = False Then
            If e.Cell.Column.Key = "Precio" Then
                If e.NewValue.ToString = "" Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub grdDatosProductos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdDatosProductos.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdDatosProductos_CellChange(sender As Object, e As CellEventArgs) Handles grdDatosProductos.CellChange
        If e.Cell.Column.Key = "Seleccion" And e.Cell.Row.Index <> grdDatosProductos.Rows.FilterRow.Index Then
            Dim contadorSeleccion As Int32 = 0
            For Each rowGR As UltraGridRow In grdDatosProductos.Rows
                If CBool(rowGR.Cells("Seleccion").Text) = True Then
                    contadorSeleccion += 1
                End If
            Next
            lblTotalSeleccionados.Text = contadorSeleccion.ToString("N0")
        End If
    End Sub

    Private Sub grdDatosProductos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdDatosProductos.InitializeLayout
        Me.grdDatosProductos.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"
        Dim valueList As ValueList = e.Layout.FilterOperatorsValueList
        Dim item As ValueListItem
        For Each item In valueList.ValueListItems
            Dim filterOperator As FilterComparisionOperator = DirectCast(item.DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Contains = filterOperator Then
                item.DisplayText = "CONTIENE"
            ElseIf FilterComparisionOperator.DoesNotEndWith = filterOperator Then
                item.DisplayText = "NO TERMINA CON"
            ElseIf FilterComparisionOperator.DoesNotStartWith = filterOperator Then
                item.DisplayText = "NO COMIENZA CON"
            ElseIf FilterComparisionOperator.EndsWith = filterOperator Then
                item.DisplayText = "TERMINA CON"
            ElseIf FilterComparisionOperator.Equals = filterOperator Then
                item.DisplayText = "IGUAL"
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                item.DisplayText = "MAYOR QUE"
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                item.DisplayText = "MAYOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                item.DisplayText = "MENOR QUE"
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                item.DisplayText = "MENOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.NotEquals = filterOperator Then
                item.DisplayText = "DIFERENTE A"
            ElseIf FilterComparisionOperator.StartsWith = filterOperator Then
                item.DisplayText = "COMIENZA CON"
            End If
        Next

        Dim cont As Integer
        For cont = valueList.ValueListItems.Count - 1 To 0 Step -1
            Dim filterOperator As FilterComparisionOperator = DirectCast(valueList.ValueListItems.Item(cont).DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Custom = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotContain = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotMatch = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Like = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Match = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.NotLike = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            End If
        Next
    End Sub

    Private Sub grdDatosProductos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdDatosProductos.InitializeRow
        If CBool(e.Row.Cells("marc_decimales").Value) = False Then
            e.Row.Cells("Precio").Style = ColumnStyle.Integer
        Else
            e.Row.Cells("Precio").Style = ColumnStyle.Double
        End If
    End Sub

    Private Sub grdDatosProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles grdDatosProductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdDatosProductos.PerformAction(UltraGridAction.ExitEditMode, False, False)
            Dim banda As UltraGridBand = grdDatosProductos.DisplayLayout.Bands(0)
            If grdDatosProductos.ActiveRow.HasNextSibling(True) Then
                Dim nextRow As UltraGridRow = grdDatosProductos.ActiveRow.GetSibling(SiblingRow.Next, True)
                grdDatosProductos.ActiveCell = nextRow.Cells(grdDatosProductos.ActiveCell.Column)
                e.Handled = True
                grdDatosProductos.PerformAction(UltraGridAction.EnterEditMode, False, False)
            End If
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 100) Then

            If (caracter <> "'" And caracter <> """" And caracter <> "*") Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtDescripcion.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dttInicio_ValueChanged(sender As Object, e As EventArgs) Handles dttInicio.ValueChanged
        Dim objLBP As New Ventas.Negocios.ListaBaseBU
        Dim dtDatosListaBase As New DataTable
        dtDatosListaBase = objLBP.consecutivoCod(dttInicio.Value.Year)
        Dim consecutivo As String = String.Empty
        consecutivo = dtDatosListaBase.Rows(0)(0).ToString
        txtCodigo.Text = consecutivo + dttInicio.Value.Year.ToString + dttInicio.Value.Month.ToString.PadLeft(2, "0")

    End Sub

    Private Sub chkSeleccionarFiltrados_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarFiltrados.CheckedChanged
        For Each rowGr As UltraGridRow In grdDatosProductos.Rows.GetFilteredInNonGroupByRows
            rowGr.Cells("Seleccion").Value = CBool(chkSeleccionarFiltrados.Checked)
        Next

        Dim contadorSeleccion As Int32 = 0
        For Each rowGR As UltraGridRow In grdDatosProductos.Rows
            If CBool(rowGR.Cells("Seleccion").Text) = True Then
                contadorSeleccion += 1
            End If
        Next
        lblTotalSeleccionados.Text = contadorSeleccion.ToString("N0")

    End Sub

    Private Sub dttFin_ValueChanged(sender As Object, e As EventArgs) Handles dttFin.ValueChanged

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlGrups.Visible = True
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlGrups.Visible = False
    End Sub

    Private Sub txtPrecioMultiple_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioMultiple.KeyDown
        If e.KeyCode = Keys.Enter Then
            asignarPrecios()
        End If
    End Sub

End Class