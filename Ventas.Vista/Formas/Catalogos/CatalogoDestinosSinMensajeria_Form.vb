Imports Infragistics.Win.UltraWinGrid
Imports embarque.Vista
Imports Infragistics.Win
Imports Tools.Controles

Public Class CatalogoDestinosSinMensajeria_Form

    Private Sub CatalogoDestinosSinMensajeria_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_EMB_DESTINOSINMSG", "VER_BTNALTAS") Then
        Else
            pnlBtnAltas.Visible = False
        End If
        poblar_Lista_DestinosSinMensajeria()
    End Sub


    Private Sub poblar_Lista_DestinosSinMensajeria()
        Dim objBU As New Negocios.LugarEntregaBU
        Dim dtLista As New DataTable
        dtLista = objBU.ListaDestinos_Sin_MensajeriaRelacionada()
        grdDestinosSinMensajeria.DataSource = Nothing
        grdDestinosSinMensajeria.DataSource = dtLista

    End Sub


    Private Sub Diseno_Grid(ByVal Grid As UltraGrid)
        With Grid
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub

    Private Sub Diseno_Agrupacion_Headers(ByVal Grid As UltraGrid, e As InitializeLayoutEventArgs)
        Grid.DisplayLayout.GroupByBox.Prompt = "Arrastra columnas para agruparlas."
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


    Private Sub grdDestinosSinMensajeria_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdDestinosSinMensajeria.InitializeLayout
        Diseno_Agrupacion_Headers(grdDestinosSinMensajeria, e)
        Diseno_Grid(grdDestinosSinMensajeria)

        For Each col As UltraGridColumn In grdDestinosSinMensajeria.DisplayLayout.Bands(0).Columns
            col.CellActivation = Activation.NoEdit
        Next

        grdDestinosSinMensajeria.DisplayLayout.Bands(0).Columns("contador").Header.Caption = "Cantidad TEC"
        grdDestinosSinMensajeria.DisplayLayout.Bands(0).Columns("contador").Width = 100

        grdDestinosSinMensajeria.DisplayLayout.Bands(0).Columns("IdPais").Hidden = True
        grdDestinosSinMensajeria.DisplayLayout.Bands(0).Columns("IdEstado").Hidden = True
        grdDestinosSinMensajeria.DisplayLayout.Bands(0).Columns("IdCiudad").Hidden = True
        grdDestinosSinMensajeria.DisplayLayout.Bands(0).Columns("IdPoblacion").Hidden = True
        grdDestinosSinMensajeria.DisplayLayout.Bands(0).Columns("contador").CellAppearance.TextHAlign = HAlign.Right

        If grdDestinosSinMensajeria.DisplayLayout.Bands(0).Summaries.Exists("contador") = False Then
            Dim ColumnaSumarPares As UltraGridColumn = grdDestinosSinMensajeria.DisplayLayout.Bands(0).Columns("contador")
            Dim sumaPares As SummarySettings = grdDestinosSinMensajeria.DisplayLayout.Bands(0).Summaries.Add("Totales", SummaryType.Sum, ColumnaSumarPares)
            grdDestinosSinMensajeria.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
            sumaPares.DisplayFormat = "{0:###,###,###,###}"
            sumaPares.Appearance.TextHAlign = HAlign.Right
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        poblar_Lista_DestinosSinMensajeria()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarExcel(grdDestinosSinMensajeria)
    End Sub

    Public Sub ExportarExcel(ByVal grid As UltraGrid)

        If grid.Rows.Count = 0 Then
            Mensajes_Y_Alertas("ADVERTENCIA", "No existen registros por exportar en el listado seleccionado.")
        Else
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = "xlsx"
            sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"

            Dim result As DialogResult = sfd.ShowDialog()
            Dim fileName As String = sfd.FileName
            If result = Windows.Forms.DialogResult.OK Then
                Try
                    'Carpeta = My.Computer.FileSystem.SpecialDirectories.Desktop + "\" + +".xlsx"
                    Me.Cursor = Cursors.WaitCursor
                    ultExportGrid.Export(grid, fileName)

                    Mensajes_Y_Alertas("EXITO", "Archivo exportado correctamente en la ubicación: " + fileName)
                    Me.Cursor = Cursors.Default
                    Process.Start(fileName)
                Catch ex As Exception
                    Mensajes_Y_Alertas("ERROR", "El documento no pudo exportarse." + vbLf + ex.Message)
                End Try
            End If

        End If


    End Sub



    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        'Dim objAgregarDestinoMensajeria As New Embarque.Vista.AltaEdicionMensajeriasDestinosCostos



        'If grdDestinosSinMensajeria.ActiveRow.IsDataRow Then
        '    If grdDestinosSinMensajeria.Selected.Rows.Count >= 1 Then
        '        objAgregarDestinoMensajeria.Destinos_SinPaqueteria = True
        '        objAgregarDestinoMensajeria.IdPais = grdDestinosSinMensajeria.Selected.Rows(0).Cells("IdPais").Value
        '        objAgregarDestinoMensajeria.IdEstado = grdDestinosSinMensajeria.Selected.Rows(0).Cells("IdEstado").Value
        '        objAgregarDestinoMensajeria.IdCiudad = grdDestinosSinMensajeria.Selected.Rows(0).Cells("IdCiudad").Value
        '        objAgregarDestinoMensajeria.IdPoblacion = grdDestinosSinMensajeria.Selected.Rows(0).Cells("IdPoblacion").Value
        '    End If
        'End If

        'objAgregarDestinoMensajeria.ShowDialog()

        'poblar_Lista_DestinosSinMensajeria()
    End Sub

    Private Sub grdDestinosSinMensajeria_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdDestinosSinMensajeria.BeforeRowsDeleted
        e.Cancel = True
    End Sub
End Class