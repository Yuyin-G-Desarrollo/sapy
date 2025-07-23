Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Stimulsoft.Report
Imports Ventas.Vista
Imports Ventas.Negocios
Imports Tools

Public Class OrdenesTrabajoCoppelForm
    Dim fecha As New DataTable
    Dim datos As Boolean = False
    Dim listOrdenesTrabajo As New List(Of String)
    Dim listTiendas As New List(Of String)
    Dim listTiendasIds As New List(Of String)
    Dim listPedido As New List(Of String)
    Dim listEstatusOT As New List(Of String)
    Dim listEstatusOTid As New List(Of String)


    Public Sub cargarTiendas()
        Dim objBu = New Negocios.OTCoppelBU
        Dim idPedido As Int32 = 0
        Dim dtComboDistribuciones As New DataTable
        If txtPedido.Text <> "" Then
            idPedido = txtPedido.Text
        End If
        dtComboDistribuciones = objBu.RecuperaTiendasPedido(idPedido)
        dtComboDistribuciones.Rows.InsertAt(dtComboDistribuciones.NewRow, 0)
        cmbDistribuciones.DataSource = dtComboDistribuciones
        cmbDistribuciones.DisplayMember = "Nombre_Tienda"
        cmbDistribuciones.ValueMember = "IdDistribucion"
        If txtPedido.Text <> "" And datos = True Then
            fecha = objBu.RecuperaFechaEntrega(txtPedido.Text)
            If fecha.Rows.Count > 0 Then
                lblFechaE.Text = CDate(fecha.Rows(0).Item(0)).ToLongDateString
                lblFechaE.Visible = True
                lblFechaEntrega.Visible = True
            End If
        Else
            lblFechaE.Text = ""
            lblFechaE.Visible = False
            lblFechaEntrega.Visible = False
        End If
    End Sub

    Public Sub aplicarpermisos()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_OT_COPPEL", "ALM_OT_COPPEL_QUITAR_CONFIRMA") Then
            Panel14.Visible = True
        Else
            Panel14.Visible = False

        End If

    End Sub


    Public Sub llenarTablaTiendas()
        Dim dtTiendas As New DataTable
        Dim objBu As New Negocios.OTCoppelBU
        Dim estatus As String = String.Empty
        grdListaOrdenes.DataSource = Nothing
        Dim idDistribucion As String = String.Empty
        Dim idPedido As String = String.Empty
        Dim idOrdenTrabajo As String = String.Empty
        Dim fechaEntregaDe As String = String.Empty
        Dim fechaEntregaA As String = String.Empty

        'If txtOrdenTrabajo.Text <> "" Then
        '    idOrdenTrabajo = txtOrdenTrabajo.Text
        'Else
        '    idOrdenTrabajo = 0
        'End If

        For Each row As UltraGridRow In grpOrdenTrabajo.Rows
            If row.Index = 0 Then
                idOrdenTrabajo += " " + Replace(row.Cells(0).Text, ",", "")
            Else
                idOrdenTrabajo += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        For Each row As UltraGridRow In grpPedidos.Rows
            If row.Index = 0 Then
                idPedido += " " + Replace(row.Cells(0).Text, ",", "")
            Else
                idPedido += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        For Each row As UltraGridRow In grdEstatusOT.Rows
            If row.Cells(0).Text = "NO FACTURADO" Then
                estatus += ",'PF'"
            ElseIf row.Cells(0).Text = "FACTURADO" Then
                estatus += ",'S'"
            ElseIf row.Cells(0).Text = "PARCIALMENTE CONFIRMADO" Then
                estatus += ",'PC'"
            ElseIf row.Cells(0).Text = "CONFIRMADO" Then
                estatus += ",'C'"
            ElseIf row.Cells(0).Text = "EMBARCADO" Then
                estatus += ",'E'"
            ElseIf row.Cells(0).Text = "CANCELADO" Then
                estatus += ",'CN'"
            End If

            If row.Index = 0 Then
                estatus = estatus.Substring(1, estatus.Length - 1)
            End If
        Next

        For index = 0 To listTiendasIds.Count - 1
            If index = 0 Then
                idDistribucion += " " + Replace(listTiendasIds(index), ",", "")
            Else
                idDistribucion += ", " + Replace(listTiendasIds(index), ",", "")
            End If
        Next

        If chkBuscarPorFecha.Checked Then
            fechaEntregaDe = dtpFechaEntregaDe.Value.ToShortDateString
            fechaEntregaA = dtpFechaEntregaA.Value.ToShortDateString
        End If

        'If txtPedido.Text <> "" Then
        '    cargarTiendas()
        '    idPedido = txtPedido.Text
        'Else
        '    idPedido = 0
        'End If

        'If cmbDistribuciones.SelectedIndex > 0 Then
        '    idDistribucion = cmbDistribuciones.SelectedValue
        'Else
        '    idDistribucion = 0
        'End If

        'If dtpFechaEntregaDe.Visible = True And dtpFechaEntregaA.Visible = True Then
        '    fechaEntregaDe = dtpFechaEntregaDe.Value.Year.ToString + "-" + dtpFechaEntregaDe.Value.Month.ToString + "-" + dtpFechaEntregaDe.Value.Day.ToString
        '    fechaEntregaA = dtpFechaEntregaA.Value.Year.ToString + "-" + dtpFechaEntregaA.Value.Month.ToString + "-" + dtpFechaEntregaA.Value.Day.ToString
        'Else
        '    fechaEntregaDe = ""
        '    fechaEntregaA = ""
        'End If

        dtTiendas = objBu.DetalleTiendasPedido(idOrdenTrabajo, idPedido, idDistribucion, estatus, fechaEntregaDe, fechaEntregaA)

        If dtTiendas.Rows.Count > 0 Then
            grdListaOrdenes.DataSource = dtTiendas
            'If idPedido <> "" Then
            '    fecha = objBu.RecuperaFechaEntrega(txtPedido.Text)
            '    lblFechaEntrega.Visible = True
            '    lblFechaE.Text = CDate(fecha.Rows(0).Item(0)).ToLongDateString
            '    lblFechaE.Visible = True
            'Else
            '    lblFechaEntrega.Visible = False
            '    lblFechaE.Text = ""
            '    lblFechaE.Visible = False
            'End If
            formatoGrid()
            datos = True
            btnExportar.Enabled = True
            lblExportar.Enabled = True
        Else

            btnExportar.Enabled = False
            lblExportar.Enabled = False
            Dim advertencia As New Tools.AdvertenciaForm
            advertencia.mensaje = "La consulta no devolvió resultados"
            advertencia.ShowDialog()
            datos = False
        End If
    End Sub

    Public Sub formatoGrid()
        With grdListaOrdenes.DisplayLayout.Bands(0)

            .Columns("otco_idTienda").Hidden = True
            .Columns("estatus").Hidden = True
            .Columns("pares_Inventario").Hidden = True
            .Columns("estatus_incidencias").Hidden = True

            .Columns("seleccion").Header.Caption = ""
            .Columns("estatus_Facturado").Header.Caption = "F"
            .Columns("estatus_Confirmado").Header.Caption = "C"
            .Columns("estatus_Embarque").Header.Caption = "E"
            .Columns("i").Header.Caption = "I"

            .Columns("otco_idotcoppel").Header.Caption = "ID Orden"
            .Columns("otco_idpedido").Header.Caption = "Pedido"
            .Columns("otco_idTienda").Header.Caption = "Id_Tienda"
            .Columns("NombreTienda").Header.Caption = "Tienda"
            .Columns("otco_totalPares").Header.Caption = "Pares"

            .Columns("pares_Confirmados").Header.Caption = "Confirmado"
            .Columns("pares_Correctos").Header.Caption = "Correctos"
            .Columns("pares_Externos").Header.Caption = "Externos"
            .Columns("pares_Faltantes").Header.Caption = "Faltante"
            .Columns("pares_Salida").Header.Caption = "Salidas"

            .Columns("fechaFacturacion").Header.Caption = "Facturación"
            .Columns("fechaConfirmacion").Header.Caption = "Confirmación"
            .Columns("fechaEmbarque").Header.Caption = "Embarque"
            .Columns("colaboradorConfirmo").Header.Caption = "Confirmó"

            .Columns("texto_Incidencias").Header.Caption = "Incidencia"
            .Columns("ot_say").Header.Caption = "OT SAY"

            .Columns("seleccion").Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
            .Columns("seleccion").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("seleccion").Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection

            .Columns("seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("seleccion").Style = ColumnStyle.CheckBox
            .Columns("seleccion").DefaultCellValue = False

            .Columns("estatus_Facturado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("estatus_Confirmado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("estatus_Embarque").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("i").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("otco_idotcoppel").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("otco_idpedido").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("otco_idTienda").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NombreTienda").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("otco_totalPares").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("pares_Inventario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("pares_Confirmados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("pares_Correctos").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("pares_Externos").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("pares_Faltantes").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("pares_Salida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("PedidoSAY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("fechaFacturacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fechaConfirmacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fechaEmbarque").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("colaboradorConfirmo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("texto_incidencias").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ot_say").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("otco_idotcoppel").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("otco_idpedido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("otco_totalPares").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("pares_Inventario").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("pares_Confirmados").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("pares_Correctos").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("pares_Externos").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("pares_Faltantes").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("pares_Salida").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("otco_totalPares").Format = "n0"
            .Columns("pares_Confirmados").Format = "n0"
            .Columns("pares_Correctos").Format = "n0"
            .Columns("pares_Externos").Format = "n0"
            .Columns("pares_Faltantes").Format = "n0"
            .Columns("pares_Salida").Format = "n0"


            .Columns("seleccion").AllowRowFiltering = DefaultableBoolean.False
            .Columns("estatus_Facturado").AllowRowFiltering = DefaultableBoolean.False
            .Columns("estatus_Confirmado").AllowRowFiltering = DefaultableBoolean.False
            .Columns("estatus_Embarque").AllowRowFiltering = DefaultableBoolean.False
            .Columns("i").AllowRowFiltering = DefaultableBoolean.False

            .Columns("fechaFacturacion").Style = ColumnStyle.DateTime
            .Columns("fechaConfirmacion").Style = ColumnStyle.DateTime
            .Columns("fechaEmbarque").Style = ColumnStyle.DateTime


            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)


        End With

        grdListaOrdenes.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdListaOrdenes.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdListaOrdenes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaOrdenes.DisplayLayout.Override.RowSelectorWidth = 35
        grdListaOrdenes.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grdListaOrdenes.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grdListaOrdenes.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grdListaOrdenes.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grdListaOrdenes.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdListaOrdenes.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grdListaOrdenes.DisplayLayout.GroupByBox.Hidden = False
        grdListaOrdenes.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"


        'grdListaOrdenes.DisplayLayout.Bands(0).SummaryFooterCaption = "Faltante"
        grdListaOrdenes.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdListaOrdenes.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdListaOrdenes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListaOrdenes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaOrdenes.DisplayLayout.Override.RowSelectorWidth = 35
        grdListaOrdenes.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdListaOrdenes.Rows(0).Selected = True

        grdListaOrdenes.DisplayLayout.Bands(0).Columns("estatus_Facturado").Width = 20
        grdListaOrdenes.DisplayLayout.Bands(0).Columns("estatus_Confirmado").Width = 20
        grdListaOrdenes.DisplayLayout.Bands(0).Columns("estatus_Embarque").Width = 20
        grdListaOrdenes.DisplayLayout.Bands(0).Columns("i").Width = 20
        grdListaOrdenes.DisplayLayout.Bands(0).Columns("seleccion").Width = 20
        grdListaOrdenes.DisplayLayout.Bands(0).Columns("fechaConfirmacion").Width = 110
        grdListaOrdenes.DisplayLayout.Bands(0).Columns("fechaFacturacion").Width = 110
        grdListaOrdenes.DisplayLayout.Bands(0).Columns("fechaEmbarque").Width = 110
        grdListaOrdenes.DisplayLayout.Bands(0).Columns("colaboradorConfirmo").Width = 80
        grdListaOrdenes.DisplayLayout.Bands(0).Columns("otco_totalPares").Width = 40
        grdListaOrdenes.DisplayLayout.Bands(0).Columns("pares_Confirmados").Width = 60
        grdListaOrdenes.DisplayLayout.Bands(0).Columns("pares_Correctos").Width = 60
        grdListaOrdenes.DisplayLayout.Bands(0).Columns("pares_Externos").Width = 60
        grdListaOrdenes.DisplayLayout.Bands(0).Columns("otco_idotcoppel").Width = 50
        grdListaOrdenes.DisplayLayout.Bands(0).Columns("otco_idpedido").Width = 60
        grdListaOrdenes.DisplayLayout.Bands(0).Columns("PedidoSAY").Width = 60
        grdListaOrdenes.DisplayLayout.Bands(0).Columns("texto_Incidencias").Width = 120



        grdListaOrdenes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        Dim totalPares, totalConfirmados, totalCorrectos, totalExternos, totalFaltantes, totalSalidas As SummarySettings
        totalPares = grdListaOrdenes.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grdListaOrdenes.DisplayLayout.Bands(0).Columns("otco_totalPares"))
        totalConfirmados = grdListaOrdenes.DisplayLayout.Bands(0).Summaries.Add("Total Confirmados", SummaryType.Sum, grdListaOrdenes.DisplayLayout.Bands(0).Columns("pares_Confirmados"))
        totalCorrectos = grdListaOrdenes.DisplayLayout.Bands(0).Summaries.Add("Total Correctos", SummaryType.Sum, grdListaOrdenes.DisplayLayout.Bands(0).Columns("pares_Correctos"))
        totalExternos = grdListaOrdenes.DisplayLayout.Bands(0).Summaries.Add("Total Externos", SummaryType.Sum, grdListaOrdenes.DisplayLayout.Bands(0).Columns("pares_Externos"))
        totalFaltantes = grdListaOrdenes.DisplayLayout.Bands(0).Summaries.Add("Total Faltantes", SummaryType.Sum, grdListaOrdenes.DisplayLayout.Bands(0).Columns("pares_Faltantes"))
        totalSalidas = grdListaOrdenes.DisplayLayout.Bands(0).Summaries.Add("Total Salidas", SummaryType.Sum, grdListaOrdenes.DisplayLayout.Bands(0).Columns("pares_Salida"))

        grdListaOrdenes.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        totalPares.DisplayFormat = "{0:#,##0}"
        totalPares.Appearance.TextHAlign = HAlign.Right
        totalConfirmados.DisplayFormat = "{0:#,##0}"
        totalConfirmados.Appearance.TextHAlign = HAlign.Right
        totalCorrectos.DisplayFormat = "{0:#,##0}"
        totalCorrectos.Appearance.TextHAlign = HAlign.Right
        totalExternos.DisplayFormat = "{0:#,##0}"
        totalExternos.Appearance.TextHAlign = HAlign.Right
        totalFaltantes.DisplayFormat = "{0:#,##0}"
        totalFaltantes.Appearance.TextHAlign = HAlign.Right
        totalSalidas.DisplayFormat = "{0:#,##0}"
        totalSalidas.Appearance.TextHAlign = HAlign.Right

    End Sub


    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpParametros.Height = 112
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpParametros.Height = 10
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim formaConfirmacion As New Tools.ConfirmarForm
        formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
        formaConfirmacion.mensaje = "¿Estas seguro que deseas salir?"

        If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub grdListaOrdenes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaOrdenes.InitializeLayout
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


    Private Sub grdListaOrdenes_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdListaOrdenes.InitializeRow
        If e.Row.Cells("estatus").Value = "PF" Then 'Por Facturar
            e.Row.Cells("estatus_facturado").Appearance.BackColor = Color.Tomato
        ElseIf e.Row.Cells("estatus").Value = "S" Then 'Facturado
            e.Row.Cells("estatus_facturado").Appearance.BackColor = Color.LimeGreen
        ElseIf e.Row.Cells("estatus").Value = "PC" Then 'Parcialmente Confirmado
            e.Row.Cells("estatus_confirmado").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#800080")
            e.Row.Cells("estatus_facturado").Appearance.BackColor = Color.LimeGreen
        ElseIf e.Row.Cells("estatus").Value = "C" Then 'Confirmado
            e.Row.Cells("estatus_Confirmado").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#00C0C0")
            e.Row.Cells("estatus_facturado").Appearance.BackColor = Color.LimeGreen
        ElseIf e.Row.Cells("estatus").Value = "E" Then 'Embarque
            e.Row.Cells("estatus_Embarque").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#4169E1")
            e.Row.Cells("estatus_Confirmado").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#00C0C0")
            e.Row.Cells("estatus_facturado").Appearance.BackColor = Color.LimeGreen
        ElseIf e.Row.Cells("estatus").Value = "CN" Then 'Cancelado
            e.Row.Appearance.ForeColor = Color.Red
            e.Row.Cells("seleccion").Hidden = True
        End If
        Try
            If e.Row.Cells("estatus_Incidencias").Value Then 'Incidencias
                e.Row.Cells("i").Appearance.BackColor = Color.Red
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnFiltrarDistribucion_Click(sender As Object, e As EventArgs) Handles btnFiltrarDistribucion.Click
        'If txtOrdenTrabajo.Text <> "" Or txtPedido.Text <> "" Or cmbDistribuciones.SelectedIndex > 0 Or cmbEstatus.SelectedIndex > 0 Then
        '    'If txtPedido.Text <> "" Then
        '    '    lblPedido.ForeColor = Color.Black
        '    If txtPedido.Text <> "" Or txtOrdenTrabajo.Text <> "" Then
        '        lblFiltroFechaEntreDe.Visible = False
        '        lblFiltroFechaEntreA.Visible = False
        '        dtpFechaEntregaDe.Visible = False
        '        dtpFechaEntregaA.Visible = False
        '    Else
        '        If cmbEstatus.SelectedIndex > 0 Or cmbDistribuciones.SelectedIndex > 0 Then
        '            lblFiltroFechaEntreDe.Visible = True
        '            lblFiltroFechaEntreA.Visible = True
        '            dtpFechaEntregaDe.Visible = True
        '            dtpFechaEntregaA.Visible = True
        '            'dtpFechaEntregaDe.Value = DateTime.Now.ToShortDateString
        '            'dtpFechaEntregaA.Value = dtpFechaEntregaDe.Value.AddDays(7)
        '        End If
        '    End If
        Cursor = Cursors.WaitCursor
        llenarTablaTiendas()
        Cursor = Cursors.Default
        'Else
        '    Dim advertencia As New AdvertenciaForm
        '    advertencia.mensaje = "Debe ingresar un pedido para realizar la búsqueda"
        '    advertencia.ShowDialog()
        '    lblPedido.ForeColor = Color.Red
        '    grdListaOrdenes.DataSource = Nothing
        'End If

        'Else
        '    Dim advertencia As New AdvertenciaForm
        '    advertencia.mensaje = "Debes utilizar al menos uno de los filtros"
        '    advertencia.ShowDialog()
        '    grdListaOrdenes.DataSource = Nothing
        'End If
    End Sub

    'Private Sub txtPedido_KeyDown(sender As Object, e As KeyEventArgs)
    '    If (e.KeyValue = Keys.Enter) Then
    '        '    llenarTablaTiendas()
    '        cargarTiendas()
    '        btnFiltrarDistribucion_Click(sender, e)
    '    End If
    'End Sub


    Private Sub txtPedido_LostFocus(sender As Object, e As EventArgs)
        cargarTiendas()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdListaOrdenes.DataSource = Nothing
        'cmbDistribuciones.DataSource = Nothing
        cargarTiendas()
        cmbDistribuciones.SelectedIndex = 0
        cmbEstatus.SelectedIndex = 0
        txtPedido.Text = ""
        lblFechaE.Text = ""
        lblFechaEntrega.Visible = False
        lblFiltroFechaEntreDe.Visible = False
        lblFiltroFechaEntreA.Visible = False
        dtpFechaEntregaDe.Visible = False
        dtpFechaEntregaA.Visible = False
        dtpFechaEntregaDe.Value = DateTime.Now.ToShortDateString
        dtpFechaEntregaA.Value = dtpFechaEntregaDe.Value.AddDays(7)
        txtOrdenTrabajo.Text = ""
        btnExportar.Enabled = False
        lblExportar.Enabled = False
    End Sub

    Private Sub btnConfirmarOrden_Click(sender As Object, e As EventArgs) Handles btnConfirmarOrden.Click
        Dim advertencia As New Tools.AdvertenciaForm
        Dim renglonSeleccionado As Int32 = 0
        If grdListaOrdenes.Rows.Count > 0 Then
            For Each renglon As UltraGridRow In grdListaOrdenes.Rows.GetFilteredInNonGroupByRows
                If CBool(renglon.Cells("Seleccion").Value) = True Or renglon.IsActiveRow = True Then
                    renglonSeleccionado += 1
                End If
            Next
            If renglonSeleccionado = 1 Then
                For Each renglon As UltraGridRow In grdListaOrdenes.Rows.GetFilteredInNonGroupByRows
                    If CBool(renglon.Cells("Seleccion").Value) = True Or renglon.IsActiveRow = True Then
                        If renglon.Cells("estatus").Value = "S" Or renglon.Cells("estatus").Value = "PC" Then
                            Dim formConfirmar As New ConfirmarOrdenTrabajoForm
                            With formConfirmar
                                .idPedido = renglon.Cells("otco_idpedido").Value
                                .idTienda = renglon.Cells("otco_idTienda").Value
                                .nombreTienda = renglon.Cells("NombreTienda").Value
                                .idOtCoppel = renglon.Cells("otco_idotcoppel").Value
                                .VerDetalles = False
                            End With
                            formConfirmar.MdiParent = Me.MdiParent
                            'formConfirmar.ShowDialog()
                            formConfirmar.Show()
                        ElseIf renglon.Cells("estatus").Value = "PF" Then
                            advertencia.mensaje = "No es posible confirmar la tienda, aún no ha sido facturada"
                            advertencia.ShowDialog()
                        ElseIf renglon.Cells("estatus").Value = "C" Or renglon.Cells("estatus").Value = "E" Then
                            advertencia.mensaje = "No es posible confirmar la tienda, ya fue confirmada "
                            advertencia.ShowDialog()
                        End If
                    End If
                Next

                'With grdListaOrdenes
                '    If .ActiveRow Is Nothing Then Exit Sub
                '    If .ActiveRow.Index < 0 Then Exit Sub
                'End With
                'If grdListaOrdenes.ActiveRow.Cells("estatus").Value = "S" Or grdListaOrdenes.ActiveRow.Cells("estatus").Value = "PC" Then
                '    Dim formConfirmar As New ConfirmarOrdenTrabajoForm
                '    With formConfirmar
                '        .idPedido = grdListaOrdenes.ActiveRow.Cells("otco_idpedido").Value
                '        .idTienda = grdListaOrdenes.ActiveRow.Cells("otco_idTienda").Value
                '        .nombreTienda = grdListaOrdenes.ActiveRow.Cells("NombreTienda").Value
                '        .idOtCoppel = grdListaOrdenes.ActiveRow.Cells("otco_idotcoppel").Value
                '        .VerDetalles = False
                '    End With
                '    formConfirmar.MdiParent = Me.MdiParent
                '    'formConfirmar.ShowDialog()
                '    formConfirmar.Show()
                'ElseIf grdListaOrdenes.ActiveRow.Cells("estatus").Value = "PF" Then
                '    advertencia.mensaje = "No es posible confirmar la tienda, aún no ha sido facturada"
                '    advertencia.ShowDialog()
                'ElseIf grdListaOrdenes.ActiveRow.Cells("estatus").Value = "C" Or grdListaOrdenes.ActiveRow.Cells("estatus").Value = "E" Then
                '    advertencia.mensaje = "No es posible confirmar la tienda, ya fue confirmada "
                '    advertencia.ShowDialog()
                'End If
            Else
                advertencia.mensaje = "Debe seleccionar una orden a la vez "
                advertencia.ShowDialog()
            End If
        Else
            advertencia.mensaje = "Debe seleccionar al menos una orden para confirmar "
            advertencia.ShowDialog()
        End If
    End Sub

    Private Sub btnDetalles_Click(sender As Object, e As EventArgs) Handles btnDetalles.Click
        Dim formConfirmar As New ConfirmarOrdenTrabajoForm
        Dim advertencia As New Tools.AdvertenciaForm
        Dim renglonSeleccionado As Int32 = 0
        If grdListaOrdenes.Rows.Count > 0 Then
            For Each renglon As UltraGridRow In grdListaOrdenes.Rows.GetFilteredInNonGroupByRows
                If CBool(renglon.Cells("Seleccion").Value) = True Or renglon.IsActiveRow = True Then
                    renglonSeleccionado += 1
                End If
            Next
            If renglonSeleccionado = 1 Then
                For Each renglon As UltraGridRow In grdListaOrdenes.Rows.GetFilteredInNonGroupByRows
                    If CBool(renglon.Cells("Seleccion").Value) = True Or renglon.IsActiveRow = True Then
                        With formConfirmar
                            .idPedido = renglon.Cells("otco_idpedido").Value
                            .idTienda = renglon.Cells("otco_idTienda").Value
                            .nombreTienda = renglon.Cells("NombreTienda").Value
                            .idOtCoppel = renglon.Cells("otco_idotcoppel").Value
                            .VerDetalles = True
                        End With
                        formConfirmar.MdiParent = Me.MdiParent
                        'formConfirmar.ShowDialog()
                        formConfirmar.Show()
                    End If
                Next

                'With grdListaOrdenes
                '    If .ActiveRow Is Nothing Then Exit Sub
                '    If .ActiveRow.Index < 0 Then Exit Sub
                'End With
                'With formConfirmar
                '    .idPedido = grdListaOrdenes.ActiveRow.Cells("otco_idpedido").Value
                '    .idTienda = grdListaOrdenes.ActiveRow.Cells("otco_idTienda").Value
                '    .nombreTienda = grdListaOrdenes.ActiveRow.Cells("NombreTienda").Value
                '    .idOtCoppel = grdListaOrdenes.ActiveRow.Cells("otco_idotcoppel").Value
                '    .VerDetalles = True
                'End With
                'formConfirmar.MdiParent = Me.MdiParent
                ''formConfirmar.ShowDialog()
                'formConfirmar.Show()
            Else
                advertencia.mensaje = "Debe seleccionar una orden a la vez "
                advertencia.ShowDialog()
            End If
        Else
            advertencia.mensaje = "Debe seleccionar al menos una orden "
            advertencia.ShowDialog()
        End If
    End Sub

    Public Sub imprimirOrdenTrabajo()
        Dim dsOrdenesTrabajo As New DataSet("dsOrdenesTrabajo")
        'Dim dsOrdenesTrabajo As New DataSet("Colaborador")
        Dim ordenTrabajo As New DataTable("ordenTrabajo")
        Dim detalleOrdenTrabajo As New DataTable("detalleOrdenTrabajo")
        Dim obj As New Negocios.OTCoppelBU
        Dim objBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim idOtCoppel As Integer = 0
        Dim totalPares As Integer = 0
        Dim idPedido As Integer = 0
        Dim orden As Integer = 0
        Dim otSeleccionadas As String = ""

        'With ordenTrabajo
        '    .Columns.Add("otcod_idotCoppel")
        '    .Columns.Add("otco_idPedido")
        '    .Columns.Add("Orden")
        '    .Columns.Add("otco_fechaEntrega")
        '    .Columns.Add("nombre")
        '    .Columns.Add("totalPares")
        'End With

        'With detalleOrdenTrabajo
        '    .Columns.Add("otcod_idProducto")
        '    .Columns.Add("idModelo")
        '    .Columns.Add("idTalla")
        '    .Columns.Add("otcod_talla")
        '    .Columns.Add("Descripcion")
        '    .Columns.Add("total")
        'End With

        With grdListaOrdenes
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        'idOtCoppel = grdListaOrdenes.ActiveRow.Cells("otco_idotcoppel").Value
        'totalPares = grdListaOrdenes.ActiveRow.Cells("otco_totalPares").Value
        For Each renglon As UltraGridRow In grdListaOrdenes.Rows.GetFilteredInNonGroupByRows
            If CBool(renglon.Cells("Seleccion").Value) = True Or renglon.IsActiveRow = True Then
                idOtCoppel = renglon.Cells("otco_idotcoppel").Value
                'totalPares = renglon.Cells("otco_totalPares").Value 
                'idPedido = renglon.Cells("otco_idpedido").Value
                'detalleOrdenTrabajo = obj.imprimirOrdenTrabajoCoppel(idOtCoppel, 1)
                If otSeleccionadas = "" Then
                    otSeleccionadas += idOtCoppel.ToString
                Else
                    otSeleccionadas += ", " + idOtCoppel.ToString
                End If
            End If
        Next

        detalleOrdenTrabajo = obj.imprimirOrdenTrabajoCoppel(otSeleccionadas, 1)
        detalleOrdenTrabajo.TableName = "detalleOrdenTrabajo"
        ordenTrabajo = obj.imprimirOrdenTrabajoCoppel(otSeleccionadas, 2)
        ordenTrabajo.TableName = "ordenTrabajo"
        dsOrdenesTrabajo.Tables.Add(ordenTrabajo)
        dsOrdenesTrabajo.Tables.Add(detalleOrdenTrabajo)


        'dsOrdenesTrabajo.DataSetName = "dsOrdenesTrabajo"
        EntidadReporte = objBU.LeerReporteporClave("ALM_IMP_OTCOPPEL")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

        Dim reporte As New StiReport
        reporte.Load(archivo)

        reporte.Compile()
        reporte("prueba") = "prueba"
        reporte.Dictionary.Clear()
        reporte.RegData(dsOrdenesTrabajo)
        reporte.Dictionary.Synchronize()
        reporte.Show()

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim advertencia As New Tools.AdvertenciaForm
        If grdListaOrdenes.Rows.Count > 0 Then
            imprimirOrdenTrabajo()
        Else
            advertencia.mensaje = "Debe seleccionar al menos una orden "
            advertencia.ShowDialog()
        End If
    End Sub

    Private Sub OrdenesTrabajoCoppelForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Top = 0
        Me.Left = 0
        Me.Location = New Point(0, 0)
        Me.WindowState = 2
        'lblFechaE.Visible = False
        'lblFechaEntrega.Visible = False
        'lblFiltroFechaEntreDe.Visible = False
        'lblFiltroFechaEntreA.Visible = False
        'dtpFechaEntregaDe.Visible = False
        'dtpFechaEntregaA.Visible = False
        'dtpFechaEntregaDe.Value = DateTime.Now.ToShortDateString
        'dtpFechaEntregaA.Value = dtpFechaEntregaDe.Value.AddDays(7)
        ''dtpFechaEntregaA.Value = DateAdd(DateInterval.Day, 7, dtpFechaEntregaDe.Value)
        aplicarpermisos()
        cargarTiendas()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_OT_COPPEL", "ALM_OT_COPPEL_SOLODETALLES") Then
            btnImprimir.Enabled = False
            btnConfirmarOrden.Enabled = False
            btnCancelarConfirmación.Enabled = False
            btnExportar.Enabled = False
            lblImprimir.Enabled = False
            lblConfirmar.Enabled = False
            lblExportar.Enabled = False
        End If

    End Sub

    'Private Sub txtPedido_KeyPress(sender As Object, e As KeyPressEventArgs)
    '    Dim caracter As Char = e.KeyChar
    '    If (caracter = ChrW(Keys.Back)) Then
    '        e.Handled = False
    '    Else
    '        If Not IsNumeric(e.KeyChar) Then
    '            e.Handled = True
    '        End If
    '    End If

    'End Sub

    'Private Sub txtOrdenTrabajo_KeyDown(sender As Object, e As KeyEventArgs)
    '    If (e.KeyValue = Keys.Enter) Then
    '        'llenarTablaTiendas()
    '        btnFiltrarDistribucion_Click(sender, e)
    '        btnConfirmarOrden_Click(sender, e)
    '    End If
    'End Sub

    'Private Sub txtOrdenTrabajo_KeyPress(sender As Object, e As KeyPressEventArgs)
    '    Dim caracter As Char = e.KeyChar
    '    If (caracter = ChrW(Keys.Back)) Then
    '        e.Handled = False
    '    Else
    '        If Not IsNumeric(e.KeyChar) Then
    '            e.Handled = True
    '        End If
    '    End If
    'End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New Tools.AdvertenciaForm
        grid = grdListaOrdenes
        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
            With grid.DisplayLayout.Bands(0)
                .Columns("seleccion").Hidden = True
            End With
            nombreDocumento = "\Ordenes_Trabajo_Coppel"

            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog

                If ret = Windows.Forms.DialogResult.OK Then

                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                    gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                    With grid.DisplayLayout.Bands(0)
                        .Columns("seleccion").Hidden = False
                    End With
                    Dim mensajeExito As New Tools.ExitoForm
                    mensajeExito.mensaje = "Los datos se exportaron correctamente"
                    mensajeExito.ShowDialog()

                End If
                .Dispose()
            End With
        Else
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
    End Sub

    Private Sub cmbEstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstatus.SelectedIndexChanged
        'If cmbEstatus.SelectedIndex > 0 And txtOrdenTrabajo.Text = "" And txtPedido.Text = "" And cmbDistribuciones.SelectedIndex < 1 Then
        '    lblFiltroFechaEntreDe.Visible = True
        '    lblFiltroFechaEntreA.Visible = True
        '    dtpFechaEntregaDe.Visible = True
        '    dtpFechaEntregaA.Visible = True
        'Else
        '    If cmbDistribuciones.SelectedIndex < 1 Then
        '        lblFiltroFechaEntreDe.Visible = False
        '        lblFiltroFechaEntreA.Visible = False
        '        dtpFechaEntregaDe.Visible = False
        '        dtpFechaEntregaA.Visible = False
        '    End If
        'End If

        If cmbEstatus.SelectedIndex = 0 Then Return
        listEstatusOT.Add(cmbEstatus.Text)
        listEstatusOTid.Add(cmbEstatus.SelectedValue)
        grdEstatusOT.DataSource = Nothing
        grdEstatusOT.DataSource = listEstatusOT

        cmbEstatus.SelectedIndex = 0
    End Sub

    Private Sub cmbDistribuciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDistribuciones.SelectedIndexChanged
        'If cmbDistribuciones.SelectedIndex > 0 And txtOrdenTrabajo.Text = "" And txtPedido.Text = "" And cmbEstatus.SelectedIndex < 1 Then
        '    lblFiltroFechaEntreDe.Visible = True
        '    lblFiltroFechaEntreA.Visible = True
        '    dtpFechaEntregaDe.Visible = True
        '    dtpFechaEntregaA.Visible = True
        'Else
        '    If cmbEstatus.SelectedIndex < 1 Then
        '        lblFiltroFechaEntreDe.Visible = False
        '        lblFiltroFechaEntreA.Visible = False
        '        dtpFechaEntregaDe.Visible = False
        '        dtpFechaEntregaA.Visible = False
        '    End If
        'End If

        If cmbDistribuciones.SelectedIndex = 0 Then Return
        listTiendas.Add(cmbDistribuciones.Text)
        listTiendasIds.Add(cmbDistribuciones.SelectedValue)
        grpTiendas.DataSource = Nothing
        grpTiendas.DataSource = listTiendas


        cmbDistribuciones.SelectedIndex = 0

    End Sub

    Private Sub txtOrdenTrabajo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrdenTrabajo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtOrdenTrabajo.Text) Then Return

            listOrdenesTrabajo.Add(txtOrdenTrabajo.Text)
            grpOrdenTrabajo.DataSource = Nothing
            grpOrdenTrabajo.DataSource = listOrdenesTrabajo

            txtOrdenTrabajo.Text = String.Empty

        End If
    End Sub

    Private Sub grpOrdenTrabajo_KeyDown(sender As Object, e As KeyEventArgs) Handles grpOrdenTrabajo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grpOrdenTrabajo.DeleteSelectedRows(False)
    End Sub

    Private Sub DisenioGrid_Filtros(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

    End Sub

    Private Sub grpOrdenTrabajo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grpOrdenTrabajo.InitializeLayout
        DisenioGrid_Filtros(grpOrdenTrabajo)
        grpOrdenTrabajo.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Orden Trabajo"
    End Sub

    Private Sub grpTiendas_KeyDown(sender As Object, e As KeyEventArgs) Handles grpTiendas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grpTiendas.DeleteSelectedRows(False)
    End Sub

    Private Sub grpTiendas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grpTiendas.InitializeLayout
        DisenioGrid_Filtros(grpTiendas)
        grpTiendas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Tienda"
    End Sub

    Private Sub txtPedido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedido.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedido.Text) Then Return

            listPedido.Add(txtPedido.Text)
            grpPedidos.DataSource = Nothing
            grpPedidos.DataSource = listPedido

            txtPedido.Text = String.Empty

        End If
    End Sub

    Private Sub grpPedidos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grpPedidos.InitializeLayout
        DisenioGrid_Filtros(grpPedidos)
        grpPedidos.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido"
    End Sub

    Private Sub grpPedidos_KeyDown(sender As Object, e As KeyEventArgs) Handles grpPedidos.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grpPedidos.DeleteSelectedRows(False)
    End Sub

    Private Sub grdEstatusOT_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdEstatusOT.InitializeLayout
        DisenioGrid_Filtros(grdEstatusOT)
        grdEstatusOT.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido"
    End Sub

    Private Sub grdEstatusOT_KeyDown(sender As Object, e As KeyEventArgs) Handles grdEstatusOT.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdEstatusOT.DeleteSelectedRows(False)
    End Sub

    Private Sub dtpFechaEntregaA_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEntregaA.ValueChanged

    End Sub

    Private Sub dtpFechaEntregaDe_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEntregaDe.ValueChanged
        If dtpFechaEntregaA.Value < dtpFechaEntregaDe.Value Then
            dtpFechaEntregaA.Value = dtpFechaEntregaDe.Value
        End If
        dtpFechaEntregaA.MinDate = dtpFechaEntregaDe.Value
    End Sub

    Private Sub btnCancelarConfirmación_Click(sender As Object, e As EventArgs) Handles btnCancelarConfirmación.Click
        cancelarConfirmacion()
    End Sub

    Private Sub cancelarConfirmacion()
        Dim advertencia As New Tools.AdvertenciaForm
        Dim renglonSeleccionado As Int32 = 0
        Dim objBu As New Negocios.OTCoppelBU
        Dim ordentrabajo As String = String.Empty
        If grdListaOrdenes.Rows.Count > 0 Then
            'For Each renglon As UltraGridRow In grdListaOrdenes.Rows.GetFilteredInNonGroupByRows
            '    If CBool(renglon.Cells("Seleccion").Value) = True Or renglon.IsActiveRow = True Then
            '        If renglon.Index = 0 Then
            '            ordentrabajo += " " + Replace(renglon.Cells("otco_idotcoppel").Text, ",", "")
            '        Else
            '            ordentrabajo += ", " + Replace(renglon.Cells("otco_idotcoppel").Text, ",", "")
            '        End If
            '        renglonSeleccionado = 1
            '    End If
            'Next

            For Each renglon As UltraGridRow In grdListaOrdenes.Rows.GetFilteredInNonGroupByRows
                If CBool(renglon.Cells("Seleccion").Value) = True Or renglon.IsActiveRow = True Then
                    renglonSeleccionado += 1
                End If
            Next

            If renglonSeleccionado = 1 Then
                For Each renglon As UltraGridRow In grdListaOrdenes.Rows.GetFilteredInNonGroupByRows
                    If CBool(renglon.Cells("Seleccion").Value) = True Or renglon.IsActiveRow = True Then
                        Dim exito As New Tools.ExitoForm
                        If Not renglon.Cells("estatus").Value = "E" Then
                            Dim confirmar As New Tools.ConfirmarForm
                            confirmar.mensaje = "¿Cancelar la confirmación de la orden de trabajo?"
                            If confirmar.ShowDialog = DialogResult.OK Then
                                ordentrabajo = renglon.Cells("otco_idotcoppel").Text + ","
                                objBu.CancelarConfirmacionOT(ordentrabajo)
                                exito.mensaje = "Se ha cancelado la confirmación. Proceda a cancelar la factura de la OT"
                                exito.ShowDialog()
                                btnFiltrarDistribucion_Click(Nothing, Nothing)
                            End If
                            'ElseIf renglon.Cells("estatus").Value = "C" Or renglon.Cells("estatus").Value = "E" Then
                            '    advertencia.mensaje = "No es posible cancelar la OT, ya fue confirmada "
                            '    advertencia.ShowDialog()
                        Else
                            advertencia.mensaje = "No es posible cancelar la OT, ya fue entregada "
                            advertencia.ShowDialog()
                        End If
                    End If
                Next

                'With grdListaOrdenes
                '    If .ActiveRow Is Nothing Then Exit Sub
                '    If .ActiveRow.Index < 0 Then Exit Sub
                'End With
                'If grdListaOrdenes.ActiveRow.Cells("estatus").Value = "S" Or grdListaOrdenes.ActiveRow.Cells("estatus").Value = "PC" Then
                '    Dim formConfirmar As New ConfirmarOrdenTrabajoForm
                '    With formConfirmar
                '        .idPedido = grdListaOrdenes.ActiveRow.Cells("otco_idpedido").Value
                '        .idTienda = grdListaOrdenes.ActiveRow.Cells("otco_idTienda").Value
                '        .nombreTienda = grdListaOrdenes.ActiveRow.Cells("NombreTienda").Value
                '        .idOtCoppel = grdListaOrdenes.ActiveRow.Cells("otco_idotcoppel").Value
                '        .VerDetalles = False
                '    End With
                '    formConfirmar.MdiParent = Me.MdiParent
                '    'formConfirmar.ShowDialog()
                '    formConfirmar.Show()
                'ElseIf grdListaOrdenes.ActiveRow.Cells("estatus").Value = "PF" Then
                '    advertencia.mensaje = "No es posible confirmar la tienda, aún no ha sido facturada"
                '    advertencia.ShowDialog()
                'ElseIf grdListaOrdenes.ActiveRow.Cells("estatus").Value = "C" Or grdListaOrdenes.ActiveRow.Cells("estatus").Value = "E" Then
                '    advertencia.mensaje = "No es posible confirmar la tienda, ya fue confirmada "
                '    advertencia.ShowDialog()
                'End If
            Else
                advertencia.mensaje = "Debe seleccionar una orden a la vez "
                advertencia.ShowDialog()
            End If
        Else
            advertencia.mensaje = "Debe seleccionar al menos una orden para confirmar "
            advertencia.ShowDialog()
        End If

    End Sub

    Private Sub chkBuscarPorFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkBuscarPorFecha.CheckedChanged
        If chkBuscarPorFecha.Checked Then
            dtpFechaEntregaDe.Enabled = True
            dtpFechaEntregaA.Enabled = True
        Else
            dtpFechaEntregaDe.Enabled = False
            dtpFechaEntregaA.Enabled = False
        End If
    End Sub

    Private Sub btnLimpiarOtCoppel_Click(sender As Object, e As EventArgs) Handles btnLimpiarOtCoppel.Click
        Dim obj As New Negocios.OTCoppelBU
        Dim exito As New Tools.ExitoForm
        Dim aviso As New Tools.AvisoForm
        Dim confirmar As New Tools.ConfirmarForm
        Dim advertencia As New Tools.AdvertenciaForm
        Dim contCyE As Integer = 0
        Me.Cursor = Cursors.WaitCursor
        Try
            If grdListaOrdenes.Rows.Count > 0 Then
                For Each renglon As UltraGridRow In grdListaOrdenes.Rows.GetFilteredInNonGroupByRows
                    If CBool(renglon.Cells("Seleccion").Value) = True Or renglon.IsActiveRow = True Then
                        If renglon.Cells("estatus").Value = "C" Or renglon.Cells("estatus").Value = "E" Then
                            contCyE += 1
                        End If
                    End If
                Next

                If contCyE > 0 Then
                    advertencia.mensaje = "No es posible limpiar las ordenes de Trabajo, algunas tienen estatus de CONFIRMADO o EMBARCADO"
                    advertencia.ShowDialog()
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else contCyE = 0
                    confirmar.mensaje = "¿Desea limpiar las ordenes de trabajo?"
                    If confirmar.ShowDialog = DialogResult.OK Then
                        For Each renglon As UltraGridRow In grdListaOrdenes.Rows.GetFilteredInNonGroupByRows
                            If CBool(renglon.Cells("Seleccion").Value) = True Or renglon.IsActiveRow = True Then
                                If renglon.Cells("estatus").Value IsNot "C" Or renglon.Cells("estatus").Value IsNot "E" Then
                                    obj.LimpiarOtCoppel(renglon.Cells("otco_idotcoppel").Value)
                                End If
                            End If
                        Next
                    End If
                    exito.mensaje = "Se han limpiado las Ordenes de trabajo correctametne"
                    exito.ShowDialog()
                End If
            Else
                advertencia.mensaje = "Debe seleccionar al menos una orden para confirmar "
                advertencia.ShowDialog()
                Me.Cursor = Cursors.Default
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try


    End Sub
End Class