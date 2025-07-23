Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmCatalogoMultiple
    Public tabla As DataTable
    Public modulo As String = ""
    Public idListaVentas As Int32 = 0
    Public idCliente As Int32 = 0
    Public accion As String = ""
    Public valorMaximo As Double
    Public valorMinimo As Double
    Private idsResultado As String

    Public Property PidsResultado As String
        Get
            Return idsResultado
        End Get
        Set(value As String)
            idsResultado = value
        End Set
    End Property

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmCatalogoMultiple_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarDatos()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
  If accion = "DESCUENTO" Then
            Dim contSumaDescuento As Double = 0
            For Each rowGrd As UltraGridRow In grdLista.Rows
                contSumaDescuento += rowGrd.Cells("Cantidad").Value
            Next
            If contSumaDescuento > 0 Then
                If contSumaDescuento <= 100 Then
                    If contSumaDescuento <= valorMaximo Then
                        If contSumaDescuento >= valorMinimo Then
                            If idListaVentas <> 0 And idCliente <> 0 Then
                                Dim objConfirma As New Tools.ConfirmarForm
                                objConfirma.mensaje = "¿Está seguro de guardar los cambios?"
                                If objConfirma.ShowDialog = Windows.Forms.DialogResult.OK Then
                                    Dim objLVBU As New Negocios.ListaVentasBU
                                    objLVBU.inactivarConfClienteDescuento(idListaVentas, idCliente)
                                    For Each rowGrd As UltraGridRow In grdLista.Rows
                                        If rowGrd.Cells("Cantidad").Value > 0 Then
                                            objLVBU.guardarClienteDescuentoConfiguraion(idListaVentas, idCliente, rowGrd.Cells("mode_motivodescuentoid").Value, rowGrd.Cells("lude_lugardescuentoid").Value, CBool(rowGrd.Cells("Encadenado").Value), rowGrd.Cells("Porcentaje").Value, rowGrd.Cells("Cantidad").Value, rowGrd.Cells("dias").Value)
                                        End If
                                    Next
                                    PidsResultado = contSumaDescuento.ToString
                                    Dim objExito As New Tools.ExitoForm
                                    objExito.mensaje = "Registro Correcto"
                                    objExito.ShowDialog()
                                    Me.Close()
                                End If

                            End If

                        Else
                            Dim objMAlerta As New Tools.AdvertenciaForm
                            objMAlerta.mensaje = "Los descuentos no pueden sumar menos que la cantidad configurada en la lista de ventas"
                            objMAlerta.ShowDialog()
                        End If

                    Else
                        Dim objMAlerta As New Tools.AdvertenciaForm
                        objMAlerta.mensaje = "Los descuentos no pueden sumar mas que la cantidad configurada en la lista de ventas"
                        objMAlerta.ShowDialog()
                    End If
                Else
                    Dim objMAlerta As New Tools.AdvertenciaForm
                    objMAlerta.mensaje = "Los descuentos no pueden sumar más del 100%"
                    objMAlerta.ShowDialog()
                End If
            End If
            End If



    End Sub

    Public Function validarVacios() As Boolean
        Dim contSeleccionados As Int32 = 0
        For Each rowGrd As UltraGridRow In grdLista.Rows
            If CBool(rowGrd.Cells("Seleccion").Value) = True Then
                contSeleccionados += 1
            End If
        Next
        If contSeleccionados = 0 Or idListaVentas = 0 Or idCliente = 0 Then
            Return False
        End If
        Return True
    End Function

    Public Sub llenarDatos()
        grdLista.DataSource = tabla
        If accion = "FLETE" Then
            grdLista.DisplayLayout.Bands(0).Columns.Add("Seleccion", "Seleccion")
            Dim colSeleccion As UltraGridColumn = grdLista.DisplayLayout.Bands(0).Columns("Seleccion")
            colSeleccion.DefaultCellValue = False
            colSeleccion.Header.Caption = "Selección"
            colSeleccion.Style = ColumnStyle.CheckBox
            For Each rowGR As UltraGridRow In grdLista.Rows
                rowGR.Cells("Seleccion").Value = False
            Next
            grdLista.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdLista.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdLista.DisplayLayout.Override.RowSelectorWidth = 35
            grdLista.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            grdLista.Rows(0).Selected = True

            grdLista.DisplayLayout.Bands(0).Columns("tifl_tipofleteid").Hidden = True
            grdLista.DisplayLayout.Bands(0).Columns("tifl_nombre").CellActivation = Activation.NoEdit
            grdLista.DisplayLayout.Bands(0).Columns("tifl_nombre").Header.Caption = "Felte"

            grdLista.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            grdLista.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdLista.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.VisibleIndex

        ElseIf accion = "DESCUENTO" Then
            Me.Width = 470
            Dim objLBVBU As New Negocios.ListaVentasBU
            Dim dtDatosDescConfigurados As New DataTable
            dtDatosDescConfigurados = objLBVBU.consultaDescuentosConfiguracionCliente(idCliente, idListaVentas)


            grdLista.DisplayLayout.Bands(0).Columns.Add("Porcentaje", "Porcentaje")
            Dim colPorcentaje As UltraGridColumn = grdLista.DisplayLayout.Bands(0).Columns("Porcentaje")
            colPorcentaje.DefaultCellValue = False
            colPorcentaje.Header.Caption = "%"
            colPorcentaje.Style = ColumnStyle.CheckBox
            For Each rowGR As UltraGridRow In grdLista.Rows
                rowGR.Cells("Porcentaje").Value = False
            Next

            grdLista.DisplayLayout.Bands(0).Columns.Add("Cantidad", "Cantidad")
            Dim colValor As UltraGridColumn = grdLista.DisplayLayout.Bands(0).Columns("Cantidad")
            colValor.Style = ColumnStyle.CurrencyNonNegative
            colValor.MaskInput = "nnn.nn"
            colValor.CellAppearance.TextHAlign = HAlign.Right
            colValor.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Equals

            grdLista.DisplayLayout.Bands(0).Columns.Add("Dias", "Dias")
            Dim colDias As UltraGridColumn = grdLista.DisplayLayout.Bands(0).Columns("Dias")
            colDias.DefaultCellValue = 0
            colDias.Header.Caption = "Días"
            colDias.CellAppearance.TextHAlign = HAlign.Right
            colDias.MaskInput = "nnn"

            grdLista.DisplayLayout.Bands(0).Columns.Add("Encadenado", "Encadenado")
            Dim colEncadenado As UltraGridColumn = grdLista.DisplayLayout.Bands(0).Columns("Encadenado")
            colEncadenado.DefaultCellValue = False
            colEncadenado.Header.Caption = "Encadenado"
            colEncadenado.Style = ColumnStyle.CheckBox

            For Each rowGR As UltraGridRow In grdLista.Rows
                rowGR.Cells("Encadenado").Value = False
                rowGR.Cells("Cantidad").Value = 0
                rowGR.Cells("Dias").Value = 0
            Next

            If dtDatosDescConfigurados.Rows.Count > 0 Then
                For Each rowGrd As UltraGridRow In grdLista.Rows
                    For Each rowDt As DataRow In dtDatosDescConfigurados.Rows
                        If rowGrd.Cells("mode_motivodescuentoid").Value.ToString = rowDt.Item("mode_motivodescuentoid").ToString And
                            rowGrd.Cells("lude_lugardescuentoid").Value.ToString = rowDt.Item("cdlv_lugardescuentoid").ToString Then
                            rowGrd.Cells("Cantidad").Value = rowDt.Item("cdlv_cantidad").ToString
                            rowGrd.Cells("Encadenado").Value = CBool(rowDt.Item("cdlv_encadenado").ToString)
                            rowGrd.Cells("Porcentaje").Value = CBool(rowDt.Item("cdlv_porcentaje").ToString)
                            rowGrd.Cells("Dias").Value = rowDt.Item("cdlv_diasvigencia").ToString
                        End If
                    Next
                Next
            End If

            grdLista.DisplayLayout.Bands(0).Columns("mode_motivodescuentoid").Hidden = True
            grdLista.DisplayLayout.Bands(0).Columns("lude_lugardescuentoid").Hidden = True
            grdLista.DisplayLayout.Bands(0).Columns("mode_nombre").CellActivation = Activation.NoEdit
            grdLista.DisplayLayout.Bands(0).Columns("lude_nombre").CellActivation = Activation.NoEdit
            grdLista.DisplayLayout.Bands(0).Columns("mode_nombre").Header.Caption = "Motivo"
            grdLista.DisplayLayout.Bands(0).Columns("lude_nombre").Header.Caption = "Lugar"
            grdLista.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            grdLista.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdLista.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.VisibleIndex
            End If
    End Sub

    Public Sub retornarIds()

        For Each rowTab As UltraGridRow In grdLista.Rows
            If CBool(rowTab.Cells("Seleccion").Value) = True Then
                If idsResultado = "" Then
                    idsResultado = rowTab.Cells(1).Value.ToString.Trim
                Else
                    idsResultado += ", " + rowTab.Cells(1).Value.ToString.Trim
                End If
            End If
        Next
    End Sub

    Private Sub grdLista_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdLista.AfterCellUpdate

    End Sub

    Private Sub grdLista_KeyDown(sender As Object, e As KeyEventArgs) Handles grdLista.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdLista.PerformAction(UltraGridAction.ExitEditMode, False, False)
            Dim banda As UltraGridBand = grdLista.DisplayLayout.Bands(0)
            If grdLista.ActiveRow.HasNextSibling(True) Then
                Dim nextRow As UltraGridRow = grdLista.ActiveRow.GetSibling(SiblingRow.Next, True)
                grdLista.ActiveCell = nextRow.Cells(grdLista.ActiveCell.Column)
                e.Handled = True
                grdLista.PerformAction(UltraGridAction.EnterEditMode, False, False)
            End If
        End If
    End Sub

    Private Sub grdLista_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdLista.InitializeLayout
        Me.grdLista.DisplayLayout.GroupByBox.Prompt = "Arrastra para agrupar datos."
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
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            End If
        Next
    End Sub
End Class