Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmFiltroClientes
    Public idCliente As Int32 = 0
    Public nomCliente As String = ""
    Public accion As String = ""
    Public idLb As Int32 = 0
    Public idLv As Int32 = 0
    Public idLVC As Int32

    Public Sub cargarListaCliente()
        Dim objCltsBU As New Negocios.ClientesBU
        Dim dtClientes As New DataTable
        dtClientes = objCltsBU.buscarClientesNombreComercial(rdoActivo.Checked, 0, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        grdClientes.DataSource = dtClientes
        formatoGridsgrdClientes()
    End Sub

    Public Sub cargarClienteConsultaLC()
       
        If idLb > 0 Then
            If idLv > 0 Then
                Dim objLVC As New Negocios.ListaVentasClienteBU
                Dim dtListaVentasCliente As New DataTable
                dtListaVentasCliente = objLVC.consultaListaVentasClienteLV(0, idLv, True, rdoActivo.Checked)
                If dtListaVentasCliente.Rows.Count > 0 Then
                    grdClientes.DataSource = dtListaVentasCliente
                    formatoGridsgrdClientesLC()
                Else
                    grdClientes.DataSource = Nothing
                End If
            Else
                grdClientes.DataSource = Nothing
                Dim objLVC As New Negocios.ListaVentasClienteBU
                Dim dtListaVentasCliente As New DataTable
                dtListaVentasCliente = objLVC.consultaListaVentasClienteLV(idLb, 0, True, rdoActivo.Checked)
                If dtListaVentasCliente.Rows.Count > 0 Then
                    grdClientes.DataSource = dtListaVentasCliente
                    formatoGridsgrdClientesLC()
                Else
                    grdClientes.DataSource = Nothing
                End If

            End If
        Else
            If accion = "CONSULTALC" Then

                grdClientes.DataSource = Nothing
                Dim objLVC As New Negocios.ListaVentasClienteBU
                Dim dtListaVentasCliente As New DataTable
                dtListaVentasCliente = objLVC.consultaListaVentasClienteLV(0, 0, True, rdoActivo.Checked)
                If dtListaVentasCliente.Rows.Count > 0 Then
                    grdClientes.DataSource = dtListaVentasCliente
                    formatoGridsgrdClientesLC()
                Else
                    grdClientes.DataSource = Nothing
                End If
            End If
        End If
    End Sub

    Public Sub formatoGridsgrdClientes()
        '	
        With grdClientes.DisplayLayout.Bands(0)
            .Columns("pers_personaid").Hidden = True
            .Columns("clie_clasificacionpersonaid").Hidden = True
            .Columns("clie_razonsocial").Hidden = True
            .Columns("clie_ranking").Hidden = True
            .Columns("clie_fechacreacion").Hidden = True
            .Columns("clie_statuscliente").Hidden = True
            .Columns("clie_statuscliente").Hidden = True

            .Columns("clie_statuscliente").Header.Caption = "Estatus"
            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("clie_clienteid").Header.Caption = ""

            .Columns("pers_personaid").CellActivation = Activation.NoEdit
            .Columns("clie_clasificacionpersonaid").CellActivation = Activation.NoEdit
            .Columns("clie_razonsocial").CellActivation = Activation.NoEdit
            .Columns("clie_ranking").CellActivation = Activation.NoEdit
            .Columns("clie_fechacreacion").CellActivation = Activation.NoEdit
            .Columns("clie_statuscliente").CellActivation = Activation.NoEdit
            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit

            .Columns("clie_statuscliente").CellAppearance.TextHAlign = HAlign.Center

        End With
    
        Dim colSel As UltraGridColumn = grdClientes.DisplayLayout.Bands(0).Columns("clie_clienteid")
        colSel.Style = ColumnStyle.Image
        colSel.Header.VisiblePosition = 0

        grdClientes.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdClientes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdClientes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdClientes.DisplayLayout.Override.RowSelectorWidth = 35
        grdClientes.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdClientes.Rows(0).Selected = True

        grdClientes.DisplayLayout.Bands(0).Columns("clie_clienteid").Width = 30
        grdClientes.DisplayLayout.Bands(0).Columns("clie_statuscliente").Width = 30
    End Sub

    Public Sub formatoGridsgrdClientesLC()
        With grdClientes.DisplayLayout.Bands(0)
            .Columns("lvcl_listaprecioventasid").Hidden = True
            .Columns("lvcl_clienteid").Hidden = True
            .Columns("clie_tipoclienteid").Hidden = True

            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("lvcl_listaventasclienteid").Header.Caption = ""

            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
            .Columns("lvcl_listaventasclienteid").CellActivation = Activation.NoEdit

            .Columns("lvcl_listaventasclienteid").CellAppearance.TextHAlign = HAlign.Center

        End With

        Dim colSel As UltraGridColumn = grdClientes.DisplayLayout.Bands(0).Columns("lvcl_listaventasclienteid")
        colSel.Style = ColumnStyle.Image
        colSel.Header.VisiblePosition = 0

        grdClientes.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdClientes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdClientes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdClientes.DisplayLayout.Override.RowSelectorWidth = 35
        grdClientes.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdClientes.Rows(0).Selected = True

        grdClientes.DisplayLayout.Bands(0).Columns("lvcl_listaventasclienteid").Width = 30
    End Sub


    Private Sub frmFiltroClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub grdClientes_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdClientes.ClickCell
        If e.Cell.Column.ToString = "clie_clienteid" Or e.Cell.Column.ToString = "lvcl_listaventasclienteid" Then

            If accion = "REPORTE" Then
                idCliente = e.Cell.Row.Cells("clie_clienteid").Value
                Me.Close()
            ElseIf accion = "CONSULTALC" Then
                idLVC = e.Cell.Row.Cells("lvcl_listaventasclienteid").Value
                Me.Close()
            End If

        End If
    End Sub

    Private Sub grdClientes_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdClientes.InitializeRow
        If e.Row.Cells.Exists("clie_clienteid") Then
            e.Row.Cells("clie_clienteid").Appearance.ImageBackground = Global.Ventas.Vista.My.Resources.Resources.seleccionar
        ElseIf e.Row.Cells.Exists("lvcl_listaventasclienteid") Then
            e.Row.Cells("lvcl_listaventasclienteid").Appearance.ImageBackground = Global.Ventas.Vista.My.Resources.Resources.seleccionar
        End If
    End Sub

    Private Sub grdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        Me.grdClientes.DisplayLayout.GroupByBox.Prompt = "Arrastra para agrupar datos."
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

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged

    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        If accion = "REPORTE" Then
            cargarListaCliente()
        ElseIf accion = "CONSULTALC" Then
            cargarClienteConsultaLC()
        End If
    End Sub
End Class