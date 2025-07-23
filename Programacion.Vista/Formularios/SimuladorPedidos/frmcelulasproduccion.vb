Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class frmcelulasproduccion
    Public Sub disenoGrids()

        With grdListadePrecios.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .Columns("idNave").Hidden = True
          
            .Columns("Nombre").Header.Caption = "Célula"
            .Columns("Capacidad").Header.Caption = "Capacidad"
            .Columns("nave").Header.Caption = "Nave"
     
            .Columns("Nombre").CellActivation = Activation.NoEdit
            .Columns("Capacidad").CellActivation = Activation.NoEdit
            .Columns("nave").CellActivation = Activation.NoEdit
          
            '.Columns("clie_clienteid").Width = 50
        
            .Columns("Capacidad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Capacidad").Format = "###,###,##0"

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        grdListadePrecios.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListadePrecios.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListadePrecios.DisplayLayout.Override.RowSelectorWidth = 35
        grdListadePrecios.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdListadePrecios.Rows(0).Selected = True

    End Sub

    Public Sub llenarTablaCeluas()
        Dim objN As New Negocios.LineasProduccionBU
        Dim dtLineas As New DataTable
        Me.Cursor = Cursors.WaitCursor
        dtLineas = objN.tablaLineas(CBool(rdoActivo.Checked))
        Me.Cursor = Cursors.Default
        If dtLineas.Rows.Count > 0 Then
            grdListadePrecios.DataSource = dtLineas
            disenoGrids()
        Else
            grdListadePrecios.DataSource = Nothing
        End If

    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Try
            Dim objFrm As New frmAltaEditarCelulaProduccion
            objFrm.accion = "ALTAS"
            objFrm.ShowDialog()
            llenarTablaCeluas()
        Catch ex As Exception
     
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try

            If grdListadePrecios.Rows.Count > 0 Then
                If grdListadePrecios.ActiveRow.IsFilterRow = False Then
                    Dim objFrm As New frmAltaEditarCelulaProduccion
                    objFrm.idCelula = grdListadePrecios.ActiveRow.Cells("ID").Value
                    objFrm.idNave = grdListadePrecios.ActiveRow.Cells("idNave").Value
                    objFrm.nombreCelula = grdListadePrecios.ActiveRow.Cells("Nombre").Value
                    objFrm.capacidad = grdListadePrecios.ActiveRow.Cells("Capacidad").Value
                    objFrm.activo = CBool(rdoActivo.Checked)
                    objFrm.accion = "EDITAR"
                    objFrm.ShowDialog()
                    llenarTablaCeluas()
                Else
                    Dim objMensaje As New Tools.AdvertenciaForm
                    objMensaje.mensaje = "Seleccione una célula."
                    objMensaje.ShowDialog()
                End If
            Else
                Dim objMensaje As New Tools.AdvertenciaForm
                objMensaje.mensaje = "Seleccione una célula."
                objMensaje.ShowDialog()
            End If

        Catch ex As Exception
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "Seleccione una célula."
            objMensaje.ShowDialog()
        End Try
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpBotones.Height = 42
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpBotones.Height = 75
    End Sub

    Private Sub grdListadePrecios_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListadePrecios.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdListadePrecios_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdListadePrecios.DoubleClickRow
        If e.Row.IsFilterRow = False Then
            Dim objFrm As New frmAltaEditarCelulaProduccion
            objFrm.idCelula = e.Row.Cells("ID").Value
            objFrm.idNave = e.Row.Cells("idNave").Value
            objFrm.nombreCelula = e.Row.Cells("Nombre").Value
            objFrm.capacidad = e.Row.Cells("Capacidad").Value
            objFrm.activo = CBool(rdoActivo.Checked)
            objFrm.accion = "CONSULTA"
            objFrm.ShowDialog()
        End If
    End Sub

    Private Sub grdListadePrecios_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdListadePrecios.InitializeLayout
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

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        llenarTablaCeluas()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged

    End Sub

    Private Sub frmcelulasproduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        rdoActivo.Checked = True
    End Sub
End Class