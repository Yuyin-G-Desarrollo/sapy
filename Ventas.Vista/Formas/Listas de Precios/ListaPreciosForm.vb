Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaPreciosForm
    Dim NombreLista As String
    Dim CodigoLista As String
    Dim idLista As Int32
    Dim idListaBase As Int16 = 0
    Dim estatusLista As String

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim abrirFormAltas As Boolean = True
        For Each rowDT As UltraGridRow In grdListadePrecios.Rows
                If rowDT.Cells("ESTATUS").Value.ToString = "ACTIVA" Then
                    abrirFormAltas = False
                End If
            Next
        If abrirFormAltas = True Then
            Dim objMensaje As New Tools.AvisoForm
            objMensaje.mensaje = "Recuperando listado de artículos activos... Esta operación puede tardar varios minutos."
            objMensaje.ShowDialog()

            Dim objAlta As New AltaPrecios
            objAlta.MdiParent = MdiParent
            objAlta.Show()
            ' ''llenarListasBaseActivas()
            ' ''formatoGrids()
            ' ''grdListasVentas.DataSource = Nothing
        Else
            Dim objMensajeADV As New Tools.AvisoForm
            objMensajeADV.mensaje = "Existe una Lista Base ACTIVA."
            objMensajeADV.ShowDialog()
        End If
    End Sub

    Public Sub llenarListasBaseActivas()
        Dim objLBA As New Ventas.Negocios.ListaBaseBU
        Dim dtDatosLBA As New DataTable
        dtDatosLBA = objLBA.listaListasBase
        grdListadePrecios.DataSource = dtDatosLBA
    End Sub

    Public Function localizarListaBaseActual() As String
        Dim ListaBaseActual As String = ""
        For Each rowD As UltraGridRow In grdListadePrecios.Rows
            If rowD.Cells("ESTATUS").Value.ToString = "AUTORIZADA" Then
                ListaBaseActual = rowD.Cells("lpba_nombrelista").Value.ToString + "  Cod: " + rowD.Cells("lpba_codigolistabase").Value.ToString + " |"
            End If
        Next
        Return ListaBaseActual
    End Function

    Public Sub formatoGrids()
        'lpba_listapreciosbaseid()
        'lpba_codigolistabase()
        'lpba_nombrelista()
        'lpba_vigenciainicio()
        'lpba_vigenciafin()
        'ucreo()
        'umodifico()
        'ESTATUS()
        With grdListadePrecios.DisplayLayout.Bands(0)
            .Columns("lpba_listapreciosbaseid").Hidden = True
            .Columns("ORDENAMIENTO").Hidden = True
            .Columns("lpba_estatus").Hidden = True
            .Columns("lpba_codigolistabase").Header.Caption = "Código"
            .Columns("lpba_nombrelista").Header.Caption = "Lista"
            .Columns("lpba_vigenciainicio").Header.Caption = "Inicio"
            .Columns("lpba_vigenciafin").Header.Caption = "Fin"
            .Columns("ucreo").Header.Caption = "Usuario Creo"
            .Columns("umodifico").Header.Caption = "Usuario Modifico"
            .Columns("ESTATUS").Header.Caption = "Estatus"
            .Columns("lpba_listapreciosbaseid").CellActivation = Activation.NoEdit
            .Columns("lpba_codigolistabase").CellActivation = Activation.NoEdit
            .Columns("lpba_nombrelista").CellActivation = Activation.NoEdit
            .Columns("lpba_vigenciainicio").CellActivation = Activation.NoEdit
            .Columns("lpba_vigenciafin").CellActivation = Activation.NoEdit
            .Columns("ucreo").CellActivation = Activation.NoEdit
            .Columns("umodifico").CellActivation = Activation.NoEdit
            .Columns("ESTATUS").CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListadePrecios.DisplayLayout.Appearance.BackColor = Color.LightSteelBlue
        grdListadePrecios.DisplayLayout.Appearance.BorderColor = Color.DarkGray
        grdListadePrecios.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListadePrecios.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.VisibleIndex

        'For Each rodD As UltraGridRow In grdListadePrecios.Rows
        '    If rodD.Cells("elp_nombreEstatus").Value.ToString = "AUTORIZADA" Then
        '        rodD.Appearance.BorderColor = Color.DeepSkyBlue
        '    ElseIf rodD.Cells("elp_nombreEstatus").Value = "ACTIVA" Then
        '        rodD.Appearance.BorderColor = Color.Aquamarine
        '    ElseIf rodD.Cells("elp_nombreEstatus").Value.ToString = "INACTIVA" Then
        '        rodD.Cells("elp_nombreEstatus").Appearance.BackColor = Color.AliceBlue
        '    End If
        'Next
    End Sub


    Public Sub disenioGridListaVentas()

        With grdListasVentas.DisplayLayout.Bands(0)
            .Columns("lpvt_listaprecioventaid").Hidden = True
            .Columns("lpvt_listapreciosbaseid").Hidden = True
            .Columns("lpvt_fechamodificacion").Hidden = True
            .Columns("lpvt_fechacreacion").Hidden = True
            .Columns("lpvt_usuariocreo").Hidden = True
            .Columns("lpvt_usuariomodifico").Hidden = True
            .Columns("lpvt_activo").Hidden = True
            .Columns("lpvt_estemporal").Hidden = True
            .Columns("even_eventoid").Hidden = True
            ',
            ',
            'lpvt_codigolistaventa,
            'lpvt_descripcion,
            'lpvt_incrementoporpar,
            'lpvt_porcentaje,
            'lpvt_vigenciainicio,
            'lpvt_vigenciafin,
            'lpvt_facturacioninicio,
            'lpvt_facturacionfin,
            'lpvt_descuentoinicio,
            'lpvt_descuentofin,

            .Columns("lpvt_codigolistaventa").Header.Caption = "Código Lista"
            .Columns("lpvt_descripcion").Header.Caption = "Descripción"
            .Columns("lpvt_incrementoporpar").Header.Caption = "Incr X Par"
            .Columns("lpvt_porcentaje").Header.Caption = "%"
            .Columns("lpvt_vigenciainicio").Header.Caption = "Inicio"
            .Columns("lpvt_vigenciafin").Header.Caption = "Fin"
            .Columns("lpvt_facturacioninicio").Header.Caption = "% Fact Inicio"
            .Columns("lpvt_facturacionfin").Header.Caption = "% Fact Fin"
            .Columns("lpvt_descuentoinicio").Header.Caption = "Desc Inicio"
            .Columns("lpvt_descuentofin").Header.Caption = "Desc Fin"
            .Columns("even_nombre").Header.Caption = "Evento"
            .Columns("FLETE").Header.Caption = "Flete"
            .Columns("CLIENTES").Header.Caption = "# Clientes"

            .Columns("lpvt_codigolistaventa").CellActivation = Activation.NoEdit
            .Columns("lpvt_descripcion").CellActivation = Activation.NoEdit
            .Columns("lpvt_incrementoporpar").CellActivation = Activation.NoEdit
            .Columns("lpvt_porcentaje").CellActivation = Activation.NoEdit
            .Columns("lpvt_vigenciainicio").CellActivation = Activation.NoEdit
            .Columns("lpvt_vigenciafin").CellActivation = Activation.NoEdit
            .Columns("lpvt_facturacioninicio").CellActivation = Activation.NoEdit
            .Columns("lpvt_facturacionfin").CellActivation = Activation.NoEdit
            .Columns("lpvt_descuentoinicio").CellActivation = Activation.NoEdit
            .Columns("lpvt_descuentofin").CellActivation = Activation.NoEdit
            .Columns("FLETE").CellActivation = Activation.NoEdit
            .Columns("IVA").CellActivation = Activation.NoEdit
            .Columns("CLIENTES").CellActivation = Activation.NoEdit
            .Columns("even_nombre").CellActivation = Activation.NoEdit

            .Columns("lpvt_codigolistaventa").CellAppearance.TextHAlign = HAlign.Right
            .Columns("lpvt_incrementoporpar").CellAppearance.TextHAlign = HAlign.Right
            .Columns("lpvt_facturacioninicio").CellAppearance.TextHAlign = HAlign.Right
            .Columns("lpvt_facturacionfin").CellAppearance.TextHAlign = HAlign.Right
            .Columns("lpvt_descuentoinicio").CellAppearance.TextHAlign = HAlign.Right
            .Columns("lpvt_descuentofin").CellAppearance.TextHAlign = HAlign.Right
            .Columns("CLIENTES").CellAppearance.TextHAlign = HAlign.Right

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListasVentas.DisplayLayout.Appearance.BackColor = Color.LightSteelBlue
        grdListasVentas.DisplayLayout.Appearance.BorderColor = Color.DarkGray
        grdListasVentas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListasVentas.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.VisibleIndex

    End Sub

    Private Sub ListaPreciosForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        llenarListasBaseActivas()
        formatoGrids()
        grdListasVentas.DataSource = Nothing
    End Sub

    Private Sub ListaPreciosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized
        llenarListasBaseActivas()
        formatoGrids()
        grdListasVentas.DataSource = Nothing
        'Se agrego para que ya no todos los que posean esta pantalla puedan usar todas las opciones---06072020
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VE_LP_PRECIOBASE", "MOSTRAR_ALTA_LBASE") Then
            pnl_AltaLB.Visible = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VE_LP_PRECIOBASE", "MOSTRAR_HISTORICO_LISTABASE") Then
            pnl_HistoricoLB.Visible = True
            grpBotonesListaBase.Visible = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VE_LP_PRECIOBASE", "MOSTRAR_ALTA_LISTAVENTAS") Then
            grpBotonesListaVentas.Visible = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VE_LP_PRECIOBASE", "MOSTRAR_RESUMEN_LB") Then
            pnl_ResumenLB.Visible = True
        End If

        If pnl_AltaLB.Visible = False And pnl_HistoricoLB.Visible = False Then
            grpBotonesListaBase.Visible = False
        Else
            grpBotonesListaBase.Visible = True
        End If

        'verificarValidezVigencia()
        ''timerAlertaVigencia.Interval = 120000
        ''timerAlertaVigencia.Start()
    End Sub



    Private Sub btnHistorico_Click(sender As Object, e As EventArgs) Handles btnHistorico.Click
        Dim objHistoricodePrecios As New ListaBaseHistorico
        objHistoricodePrecios.MdiParent = MdiParent
        objHistoricodePrecios.Show()
    End Sub

    Private Sub grdListadePrecios_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListadePrecios.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdListadePrecios_Click(sender As Object, e As EventArgs) Handles grdListadePrecios.Click

    End Sub

    Private Sub grdListadePrecios_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListadePrecios.ClickCell
        Try
            If grdListadePrecios.Rows.Count > 0 Then
                idListaBase = grdListadePrecios.Rows(e.Cell.Row.Index).Cells(0).Value
            End If
            If grdListasVentas.Rows.Count > 0 Then

                If grdListadePrecios.Rows(e.Cell.Row.Index).Cells(0).Value <> grdListasVentas.Rows(0).Cells("lpvt_listapreciosbaseid").Value Then
                    Dim objLVBU As New Negocios.ListaVentasBU
                    Dim dtDatosListaVentas As New DataTable
                    dtDatosListaVentas = objLVBU.consultaListaVentas(grdListadePrecios.Rows(e.Cell.Row.Index).Cells(0).Value)
                    grdListasVentas.DataSource = dtDatosListaVentas
                    disenioGridListaVentas()
                End If
            Else
                Dim objLVBU As New Negocios.ListaVentasBU
                Dim dtDatosListaVentas As New DataTable
                dtDatosListaVentas = objLVBU.consultaListaVentas(grdListadePrecios.Rows(e.Cell.Row.Index).Cells(0).Value)
                grdListasVentas.DataSource = dtDatosListaVentas
                disenioGridListaVentas()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub grdListadePrecios_DockChanged(sender As Object, e As EventArgs) Handles grdListadePrecios.DockChanged

    End Sub

    Private Sub grdListadePrecios_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdListadePrecios.DoubleClickRow
        Dim objaDetalles As New detallesListasBases
        If e.Row.Index <> grdListadePrecios.Rows.FilterRow.Index Then
            objaDetalles.idLista = CInt(grdListadePrecios.Rows(e.Row.Index.ToString).Cells("lpba_listapreciosbaseid").Value.ToString)
            objaDetalles.MdiParent = MdiParent
            objaDetalles.Show()
            llenarListasBaseActivas()
            formatoGrids()
            grdListasVentas.DataSource = Nothing
        End If

    End Sub

    Private Sub grdListadePrecios_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListadePrecios.InitializeLayout
        Me.grdListadePrecios.DisplayLayout.GroupByBox.Prompt = "Arrastra para agrupar datos."
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

    Private Sub grdListadePrecios_MouseClick(sender As Object, e As MouseEventArgs) Handles grdListadePrecios.MouseClick

        Dim mainElement As UIElement
        Dim element As UIElement
        Dim screenPoint As Point
        Dim clientPoint As Point
        Dim row As UltraGridRow
        Dim cell As UltraGridCell

        NombreLista = String.Empty
        estatusLista = String.Empty
        CodigoLista = ""
        idLista = 0

        mainElement = Me.grdListadePrecios.DisplayLayout.UIElement
        screenPoint = Control.MousePosition
        clientPoint = Me.grdListadePrecios.PointToClient(screenPoint)
        element = mainElement.ElementFromPoint(clientPoint)

        If element Is Nothing Then Return
        row = element.GetContext(GetType(UltraGridRow))

        If Not row Is Nothing Then
            cell = element.GetContext(GetType(UltraGridCell))

            If Not cell Is Nothing Then
                If cell.IsActiveCell = True And cell.Row.Index <> grdListadePrecios.Rows.FilterRow.Index Then
                    If grdListadePrecios.Rows(row.Index).Cells("ESTATUS").Value.ToString = "ACTIVA" Then
                        Dim nameItem As String = "Autorizar"

                        NombreLista = grdListadePrecios.Rows(row.Index).Cells("lpba_nombrelista").Value.ToString
                        CodigoLista = grdListadePrecios.Rows(row.Index).Cells("lpba_codigolistabase").Value.ToString
                        estatusLista = grdListadePrecios.Rows(row.Index).Cells("ESTATUS").Value.ToString
                        idLista = grdListadePrecios.Rows(row.Index).Cells("lpba_listapreciosbaseid").Value.ToString

                        If e.Button <> Windows.Forms.MouseButtons.Right Then Return
                        Dim cms = New ContextMenuStrip
                        Dim itemd = cms.Items.Add(nameItem)
                        itemd.Tag = 1
                        AddHandler itemd.Click, AddressOf grdListadePrecios_MenuTool
                        cms.Show(Control.MousePosition)
                    End If
                End If
            End If
        End If
        While Not element.Parent Is Nothing
            element = element.Parent
        End While
    End Sub

    Private Sub grdListadePrecios_MenuTool(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection As String = CStr(item.Tag)
        If idLista > 0 And NombreLista <> "" And estatusLista <> "" And CodigoLista <> "" Then
            If selection = 1 Then
                Dim objMsjConfirmacion As New MotivoInactivacion
                Dim objLVBU As New Negocios.ListaVentasBU
                Dim dtDatosListaVentas As New DataTable

                objMsjConfirmacion.nombreLista = NombreLista
                objMsjConfirmacion.codiLista = CodigoLista
                objMsjConfirmacion.idLista = idLista
                objMsjConfirmacion.estatusLista = estatusLista
                objMsjConfirmacion.codListaBaseActual = localizarListaBaseActual()
                objMsjConfirmacion.ShowDialog()
                llenarListasBaseActivas()
                dtDatosListaVentas = objLVBU.consultaListaVentas(idLista)
                grdListasVentas.DataSource = dtDatosListaVentas
                disenioGridListaVentas()
            End If
        End If
    End Sub

    Private Sub pnlBotonActivo_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    'Private Sub timerAlertaVigencia_Tick(sender As Object, e As EventArgs) Handles timerAlertaVigencia.Tick
    '    verificarValidezVigencia()
    'End Sub

    Private Sub pcbTitulo_Click(sender As Object, e As EventArgs) Handles pcbTitulo.Click
        'Dim form As New ListaOrdenamientoForm
        'form.ShowDialog()
    End Sub

    Private Sub grdListasVentas_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdListasVentas.DoubleClickRow
        Try
            Dim objListaVentas As New AltaConfiguracionListaVentas
            If e.Row.Cells(0).Value <> 0 Then
                objListaVentas.idListaBase = grdListadePrecios.Rows(grdListadePrecios.ActiveRow.Index).Cells("lpba_listapreciosbaseid").Value
                objListaVentas.idListaVentas = e.Row.Cells(0).Value
                objListaVentas.accionPantalla = "EDITAR"
                objListaVentas.codigoLB = grdListadePrecios.Rows(grdListadePrecios.ActiveRow.Index).Cells("lpba_codigolistabase").Value
                objListaVentas.nombreLista = grdListadePrecios.Rows(grdListadePrecios.ActiveRow.Index).Cells("lpba_nombrelista").Value
                objListaVentas.estatusListaid = grdListadePrecios.Rows(grdListadePrecios.ActiveRow.Index).Cells("lpba_estatus").Value
                objListaVentas.estatusListaCad = grdListadePrecios.Rows(grdListadePrecios.ActiveRow.Index).Cells("ESTATUS").Value
                objListaVentas.vigenciaInicio = grdListadePrecios.Rows(grdListadePrecios.ActiveRow.Index).Cells("lpba_vigenciainicio").Value
                objListaVentas.vigenciaFin = grdListadePrecios.Rows(grdListadePrecios.ActiveRow.Index).Cells("lpba_vigenciafin").Value

                objListaVentas.ShowDialog()

                Dim objLVBU As New Negocios.ListaVentasBU
                Dim dtDatosListaVentas As New DataTable
                dtDatosListaVentas = objLVBU.consultaListaVentas(grdListadePrecios.ActiveRow.Cells(0).Value)
                If dtDatosListaVentas.Rows.Count > 0 Then
                    grdListasVentas.DataSource = Nothing
                    grdListasVentas.DataSource = dtDatosListaVentas
                    disenioGridListaVentas()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdListasVentas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListasVentas.InitializeLayout
        Me.grdListasVentas.DisplayLayout.GroupByBox.Prompt = "Arrastra para agrupar datos."
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

    Private Sub btnAltaListaVentas_Click(sender As Object, e As EventArgs) Handles btnAltaListaVentas.Click
        Try
            If grdListadePrecios.Rows(grdListadePrecios.ActiveRow.Index).Cells("lpba_estatus").Value = 1 Or grdListadePrecios.Rows(grdListadePrecios.ActiveRow.Index).Cells("lpba_estatus").Value = 2 Then
                Dim objAltaListVenta As New AltaConfiguracionListaVentas
                objAltaListVenta.idListaBase = grdListadePrecios.Rows(grdListadePrecios.ActiveRow.Index).Cells("lpba_listapreciosbaseid").Value
                objAltaListVenta.codigoLB = grdListadePrecios.Rows(grdListadePrecios.ActiveRow.Index).Cells("lpba_codigolistabase").Value
                objAltaListVenta.nombreLista = grdListadePrecios.Rows(grdListadePrecios.ActiveRow.Index).Cells("lpba_nombrelista").Value
                objAltaListVenta.estatusListaid = grdListadePrecios.Rows(grdListadePrecios.ActiveRow.Index).Cells("lpba_estatus").Value
                objAltaListVenta.estatusListaCad = grdListadePrecios.Rows(grdListadePrecios.ActiveRow.Index).Cells("ESTATUS").Value
                objAltaListVenta.vigenciaInicio = grdListadePrecios.Rows(grdListadePrecios.ActiveRow.Index).Cells("lpba_vigenciainicio").Value
                objAltaListVenta.vigenciaFin = grdListadePrecios.Rows(grdListadePrecios.ActiveRow.Index).Cells("lpba_vigenciafin").Value

                objAltaListVenta.accionPantalla = "ALTA"
                objAltaListVenta.ShowDialog()
                Dim objLVBU As New Negocios.ListaVentasBU
                Dim dtDatosListaVentas As New DataTable
                dtDatosListaVentas = objLVBU.consultaListaVentas(grdListadePrecios.ActiveRow.Cells(0).Value)
                If dtDatosListaVentas.Rows.Count > 0 Then
                    grdListasVentas.DataSource = Nothing
                    grdListasVentas.DataSource = dtDatosListaVentas
                    disenioGridListaVentas()
                End If
            Else
                MsgBox("Seleccione una lista base (Autorizada o Activa).")
            End If
        Catch ex As Exception
            MsgBox("Seleccione una lista base (Autorizada o Activa).")
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        If idListaBase <> 0 Then
                Dim formResumen As New ResumenListaPrecios_Form
                formResumen.idLista = idListaBase
                formResumen.ShowDialog(Me)
            Else
                Dim advertencia As New AdvertenciaForm
                advertencia.mensaje = "Debe seleccionar una lista base"
                advertencia.ShowDialog()
            End If

    End Sub
End Class