Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class frmAlertaListaVentas
    Public dtClientesLVTemporales As DataTable
    Public dtListasVigenciaProxima As DataTable

    Public Sub llenarTablaClientesLVTemporales()
        If Not dtClientesLVTemporales Is Nothing Then
            If dtClientesLVTemporales.Rows.Count > 0 Then
                grdClientesLVTemp.DataSource = dtClientesLVTemporales
                lblContClientesTemporal.Text = dtClientesLVTemporales.Rows.Count.ToString("N0")

                With grdClientesLVTemp.DisplayLayout.Bands(0)
                    .Columns("iccl_tipoivaid").Hidden = True
                    .Columns("iccl_tipofleteid").Hidden = True
                    .Columns("iccl_monedaid").Hidden = True
                    .Columns("clie_clienteid").Header.Caption = "Id SAY"
                    .Columns("clie_idsicy").Header.Caption = "Id SICY"
                    .Columns("clie_nombregenerico").Header.Caption = "Cliente"
                    .Columns("tiva_nombre").Header.Caption = "IVA"
                    .Columns("iccl_facturar").Header.Caption = "Facturación"
                    .Columns("tifl_nombre").Header.Caption = "Flete"
                    .Columns("mone_nombre").Header.Caption = "Moneda"
                    .Columns("Descuento").Header.Caption = "Descuento"
                    .Columns("clie_clienteid").CellActivation = Activation.NoEdit
                    .Columns("clie_idsicy").CellActivation = Activation.NoEdit
                    .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
                    .Columns("tiva_nombre").CellActivation = Activation.NoEdit
                    .Columns("iccl_facturar").CellActivation = Activation.NoEdit
                    .Columns("tifl_nombre").CellActivation = Activation.NoEdit
                    .Columns("mone_nombre").CellActivation = Activation.NoEdit
                    .Columns("Descuento").CellActivation = Activation.NoEdit
                    .Columns("clie_clienteid").CellAppearance.TextHAlign = HAlign.Right
                    .Columns("clie_idsicy").CellAppearance.TextHAlign = HAlign.Right
                    .Columns("Descuento").CellAppearance.TextHAlign = HAlign.Right
                    .Columns("iccl_facturar").CellAppearance.TextHAlign = HAlign.Right

                    .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
                End With
                grdClientesLVTemp.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                grdClientesLVTemp.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
                grdClientesLVTemp.DisplayLayout.Override.RowSelectorWidth = 35
                grdClientesLVTemp.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                grdClientesLVTemp.Rows(0).Selected = True
            Else
                lblContClientesTemporal.Text = "0"
            End If
        Else
            lblContClientesTemporal.Text = "0"
            grpClientesListaTemp.Visible = False
        End If
    End Sub

    Public Sub llenarTablaVigenciasProximas()
        If Not dtListasVigenciaProxima Is Nothing Then
            If dtListasVigenciaProxima.Rows.Count > 0 Then
                grdListaVigenciasProx.DataSource = dtListasVigenciaProxima
                lblContListasVigencia.Text = dtListasVigenciaProxima.Rows.Count.ToString("N0")
                With grdListaVigenciasProx.DisplayLayout.Bands(0)
                    .Columns("FechaMax").Hidden = True
                    .Columns("TIPO").Hidden = True
                    .Columns("VFINORIGINAL").Hidden = True
                    .Columns("ID").Hidden = True
                    .Columns("LISTABASE").Header.Caption = "Lista Base"
                    .Columns("ESTATISLPB").Header.Caption = "Estatus LPB"
                    .Columns("TIPOLISTA").Header.Caption = "Tipo Lista"
                    .Columns("LISTAVENTAS").Header.Caption = "Lista Ventas"
                    .Columns("DESCRIPCION").Header.Caption = "Descripción"
                    .Columns("VINICIO").Header.Caption = "Inicio"
                    .Columns("VFIN").Header.Caption = "*Fin"
                    .Columns("DIAS").Header.Caption = "Días"
                    .Columns("CLIENTE").Header.Caption = "Cliente"
                    .Columns("LISTACLIENTE").Header.Caption = "Lista Cliente"
                    .Columns("ESTATUSLPC").Header.Caption = "*Estatus LPC"

                    .Columns("ID").CellActivation = Activation.NoEdit
                    .Columns("LISTABASE").CellActivation = Activation.NoEdit
                    .Columns("ESTATISLPB").CellActivation = Activation.NoEdit
                    .Columns("TIPOLISTA").CellActivation = Activation.NoEdit
                    .Columns("LISTAVENTAS").CellActivation = Activation.NoEdit
                    .Columns("DESCRIPCION").CellActivation = Activation.NoEdit
                    .Columns("VINICIO").CellActivation = Activation.NoEdit
                    .Columns("DIAS").CellActivation = Activation.NoEdit
                    .Columns("CLIENTE").CellActivation = Activation.NoEdit
                    .Columns("LISTACLIENTE").CellActivation = Activation.NoEdit

                    .Columns("ID").CellAppearance.TextHAlign = HAlign.Right
                    .Columns("DIAS").CellAppearance.TextHAlign = HAlign.Right

                    .Columns("ESTATUSLPC").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown

                    .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
                End With

                'grdClientes.DisplayLayout.Bands(0).Columns("tiva_nombre").ValueList = listaValoresIva

                grdListaVigenciasProx.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                grdListaVigenciasProx.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
                grdListaVigenciasProx.DisplayLayout.Override.RowSelectorWidth = 35
                grdListaVigenciasProx.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                grdListaVigenciasProx.Rows(0).Selected = True

            Else
                lblContListasVigencia.Text = "0"
            End If
        Else
            lblContListasVigencia.Text = "0"
            grpVigenciasListas.Visible = False
        End If
    End Sub

    Public Sub guardarCambiosVigencia()
        Dim objLVBU As New Negocios.ListaVentasBU
        Dim idEstatus As Int32 = 0
        For Each rowGrd As UltraGridRow In grdListaVigenciasProx.Rows
            idEstatus = 0
            If rowGrd.Cells("VFIN").Value <> rowGrd.Cells("VFINORIGINAL").Value Then
                objLVBU.guardarCambiosVigenciaAlerta(rowGrd.Cells("VFIN").Value, rowGrd.Cells("ID").Value, rowGrd.Cells("TIPO").Value)
            End If

            If rowGrd.Cells("TIPO").Value = "LVCLIENTE" Then
                If rowGrd.Cells("ESTATUSLPC").Value <> "CAPTURADA" And rowGrd.Cells("ESTATUSLPC").Value <> "ACEPTADA" Then
                    idEstatus = rowGrd.Cells("ESTATUSLPC").Value
                    objLVBU.guardarCambiosEstatusLVCPAlerta(idEstatus, rowGrd.Cells("ID").Value)
                End If
            End If


        Next
    End Sub

    Public Sub llenarDatos()
        Dim objAlert As New Framework.Negocios.AlertasBU
        Dim dtDatosClienteLVTemp As New DataTable
        Dim dtDatosListasVigenciasProx As New DataTable

        dtDatosClienteLVTemp = objAlert.consultaClientesTemporal
        dtDatosListasVigenciasProx = objAlert.consultaVigenciasProximasLVS

        If dtDatosClienteLVTemp.Rows.Count > 0 Or dtDatosListasVigenciasProx.Rows.Count > 0 Then
            If dtDatosClienteLVTemp.Rows.Count > 0 Then
                dtClientesLVTemporales = dtDatosClienteLVTemp
            End If

            If dtDatosListasVigenciasProx.Rows.Count > 0 Then
                dtListasVigenciaProxima = dtDatosListasVigenciasProx
            End If
        End If

    End Sub

    Private Sub frmAlertaListaVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblHoraEnvioAlerta.Text = Date.Now
        If dtClientesLVTemporales Is Nothing And dtListasVigenciaProxima Is Nothing Then
            llenarDatos()
        End If
        llenarTablaClientesLVTemporales()
        llenarTablaVigenciasProximas()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub grdListaVigenciasProx_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdListaVigenciasProx.AfterCellUpdate
        If e.Cell.Column.Key = "VFIN" Then
            e.Cell.Row.Cells("DIAS").Value = CInt(DateDiff(DateInterval.Day, Date.Now, CDate(e.Cell.Value))) + 1
        End If
    End Sub

    Private Sub grdListaVigenciasProx_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdListaVigenciasProx.BeforeCellUpdate
        If e.Cell.Column.Key = "VFIN" Then
            If e.NewValue < e.Cell.Row.Cells("VFINORIGINAL").Value Then
                e.Cancel = True
                Dim objMensaje As New Tools.AdvertenciaForm
                objMensaje.mensaje = "La fecha de fin de vigencia no puede ser menor a la mostrada en esta alerta, para realizar el cambio vaya a la pantalla correspondiente."
                objMensaje.ShowDialog()
            End If
            If e.Cell.Row.Cells("FechaMax").Value.ToString <> "" Then
                If CDate(e.NewValue) > CDate(e.Cell.Row.Cells("FechaMax").Value) Then
                    e.Cancel = True
                    Dim objMensaje As New Tools.AdvertenciaForm
                    objMensaje.mensaje = "La vigencia fin de una lista de ventas no puede ser mayor a la fecha de vigencia fin de su lista base."
                    objMensaje.ShowDialog()
                End If
            End If
        End If
    End Sub

    Private Sub grdListaVigenciasProx_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdListaVigenciasProx.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNothing(grdListaVigenciasProx.ActiveRow) Then Return
            Dim NextRowIndex As Integer = grdListaVigenciasProx.ActiveRow.Index + 1
            Try

                If NextRowIndex <= grdListaVigenciasProx.Rows.Count Then
                    grdListaVigenciasProx.DisplayLayout.Rows(NextRowIndex).Activated = True
                    grdListaVigenciasProx.DisplayLayout.Rows(NextRowIndex).Selected = True
                Else
                    grdListaVigenciasProx.DisplayLayout.Rows(0).Activated = True
                    grdListaVigenciasProx.DisplayLayout.Rows(0).Selected = True
                End If

            Catch ex As Exception
                grdListaVigenciasProx.ActiveRow.Activated = False
            End Try

        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objMsgSINO As New Tools.ConfirmarForm
        objMsgSINO.mensaje = "¿Está seguro de guardar los cambios?"
        If objMsgSINO.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim objCaptcha As New Tools.frmCaptcha
            objCaptcha.mensaje = "Se actualizarán las vigencias."
            If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then
                guardarCambiosVigencia()
                Dim objMsgExito As New Tools.ExitoForm
                objMsgExito.mensaje = "Registro exitoso."
                objMsgExito.ShowDialog()
                Dim objAlert As New Framework.Negocios.AlertasBU
                dtListasVigenciaProxima = objAlert.consultaVigenciasProximasLVS
                llenarTablaVigenciasProximas()
            End If
        End If
    End Sub

    Private Sub grdListaVigenciasProx_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaVigenciasProx.InitializeLayout
        Me.grdListaVigenciasProx.DisplayLayout.GroupByBox.Prompt = "Arrastra para agrupar datos."
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

    Private Sub grdListaVigenciasProx_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdListaVigenciasProx.InitializeRow
        Dim listaValoresIva As New ValueList
        If e.Row.Cells("ESTATUSLPC").Value.ToString = "CAPTURADA" Then
            listaValoresIva.ValueListItems.Add(25, "CAPTURADA")
            listaValoresIva.ValueListItems.Add(27, "DESCARTADA")
            grdListaVigenciasProx.Rows(e.Row.Index).Cells("ESTATUSLPC").ValueList = listaValoresIva
        ElseIf e.Row.Cells("ESTATUSLPC").Value.ToString = "ACEPTADA" Then
            listaValoresIva.ValueListItems.Add(26, "ACEPTADA")
            listaValoresIva.ValueListItems.Add(28, "CERRADA")
            grdListaVigenciasProx.Rows(e.Row.Index).Cells("ESTATUSLPC").ValueList = listaValoresIva
        End If
    End Sub

    Private Sub grdClientesLVTemp_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientesLVTemp.InitializeLayout
        Me.grdClientesLVTemp.DisplayLayout.GroupByBox.Prompt = "Arrastra para agrupar datos."
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