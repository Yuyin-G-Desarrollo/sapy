Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class DiseñoGrid
    ''' <summary>
    ''' Alterna el color de las filas en el grid y resalta la fila seleccionada.
    ''' </summary>
    ''' <param name="GridView">Vista que muestra datos en forma de tabla</param>
    ''' <remarks></remarks>
    Public Shared Sub AlternarColorEnFilas(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView)
        GridView.Appearance.FocusedRow.BackColor = Color.FromName("MenuHighlight")
        GridView.Appearance.FocusedRow.ForeColor = Color.White
        GridView.Appearance.EvenRow.BackColor = Color.White
        GridView.Appearance.OddRow.BackColor = Color.FromName("GradientActiveCaption")
        GridView.OptionsView.EnableAppearanceEvenRow = True
        GridView.OptionsView.EnableAppearanceOddRow = True
    End Sub

    ''' <summary>
    ''' Alterna el color de las filas, siendo el color alterno más tenue, en el grid y resalta la fila seleccionada.
    ''' </summary>
    ''' <param name="GridView">Vista que muestra datos en forma de tabla</param>
    ''' <remarks></remarks>
    Public Shared Sub AlternarColorEnFilasTenue(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView)
        GridView.Appearance.FocusedRow.BackColor = Color.FromName("MenuHighlight")
        GridView.Appearance.FocusedRow.ForeColor = Color.White
        GridView.Appearance.EvenRow.BackColor = Color.White
        GridView.Appearance.OddRow.BackColor = Color.FromName("GradientInactiveCaption")
        GridView.OptionsView.EnableAppearanceEvenRow = True
        GridView.OptionsView.EnableAppearanceOddRow = True
    End Sub
    ''' <summary>
    ''' Alinea el texto de los encabezados, por default se alinea al centro.
    ''' </summary>
    ''' <param name="GridView">Vista que muestra datos en forma de tabla</param>
    ''' <remarks></remarks>
    Public Shared Sub AlinearTextoEncabezadoColumnas(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView)
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In GridView.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="GridView">Vista que muestra datos en forma de tabla</param>
    ''' <param name="Orientacion">Enumerador que Indica la poscicion en que se mostrara el texto  en el encabezado.</param>
    ''' <remarks></remarks>
    Public Shared Sub AlinearTextoEncabezadoColumnas(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal Orientacion As DevExpress.Utils.HorzAlignment)
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In GridView.Columns
            col.AppearanceHeader.TextOptions.HAlignment = Orientacion
        Next
    End Sub

    Public Shared Sub OcultarColumna(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal Columna As String)
        GridView.Columns.ColumnByFieldName(Columna).Visible = False
    End Sub

    ''' <summary>
    ''' "dd/MM/yyyy HH:mm:ss"
    ''' </summary>
    ''' <param name="vwGrid"></param>
    ''' <param name="NombreColumna"></param>
    ''' <param name="Titulo"></param>
    ''' <param name="EsVisible"></param>
    ''' <param name="TipoFiltro"></param>
    ''' <param name="PermitirEdicion"></param>
    ''' <param name="AutoAjustarColumna"></param>
    ''' <param name="AnchoColumna"></param>
    ''' <param name="LlevaSumarizacion"></param>
    ''' <param name="TipoSumarizacion"></param>
    ''' <param name="FormatoColumna"></param>
    Public Shared Sub EstiloColumna(ByVal vwGrid As GridView, ByVal NombreColumna As String, ByVal Titulo As String, ByVal EsVisible As Boolean, ByVal TipoFiltro As Columns.AutoFilterCondition, ByVal PermitirEdicion As Boolean, ByVal AutoAjustarColumna As Boolean, ByVal AnchoColumna As Integer, ByVal LlevaSumarizacion As Boolean, ByVal TipoSumarizacion As DevExpress.Data.SummaryItemType, ByVal FormatoColumna As String)
        Try

            vwGrid.Columns.ColumnByFieldName(NombreColumna).Visible = EsVisible
            vwGrid.Columns.ColumnByFieldName(NombreColumna).OptionsFilter.AutoFilterCondition = TipoFiltro
            vwGrid.Columns.ColumnByFieldName(NombreColumna).Caption = Titulo
            vwGrid.Columns.ColumnByFieldName(NombreColumna).OptionsColumn.AllowSize = True
            vwGrid.Columns.ColumnByFieldName(NombreColumna).OptionsColumn.AllowEdit = PermitirEdicion

            If FormatoColumna <> "" Then
                vwGrid.Columns.ColumnByFieldName(NombreColumna).DisplayFormat.FormatString = FormatoColumna
            End If

            If AutoAjustarColumna = True Then
                vwGrid.Columns.ColumnByFieldName(NombreColumna).BestFit()
            Else
                vwGrid.Columns.ColumnByFieldName(NombreColumna).Width = AnchoColumna
            End If

            If LlevaSumarizacion = True Then
                vwGrid.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways
                If IsNothing(vwGrid.Columns(NombreColumna).Summary.FirstOrDefault(Function(x) x.FieldName = NombreColumna)) = True Then
                    vwGrid.Columns(NombreColumna).Summary.Add(TipoSumarizacion, NombreColumna, FormatoColumna)
                    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                    item.FieldName = NombreColumna
                    item.SummaryType = TipoSumarizacion
                    item.DisplayFormat = FormatoColumna
                    vwGrid.GroupSummary.Add(item)
                Else

                    vwGrid.Columns(NombreColumna).Summary.Remove(vwGrid.Columns(NombreColumna).Summary.FirstOrDefault(Function(x) x.FieldName = NombreColumna))
                    vwGrid.Columns(NombreColumna).Summary.Add(TipoSumarizacion, NombreColumna, FormatoColumna)
                    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                    item.FieldName = NombreColumna
                    item.SummaryType = TipoSumarizacion
                    item.DisplayFormat = FormatoColumna
                    vwGrid.GroupSummary.Add(item)
                End If
            Else
                If IsNothing(vwGrid.Columns(NombreColumna).Summary.FirstOrDefault(Function(x) x.FieldName = NombreColumna)) = False Then
                    vwGrid.Columns(NombreColumna).Summary.Remove(vwGrid.Columns(NombreColumna).Summary.FirstOrDefault(Function(x) x.FieldName = NombreColumna))
                End If


            End If

            'If LlevaSumarizacion = True Then
            '    vwGrid.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways
            '    If IsNothing(vwGrid.Columns(NombreColumna).Summary.FirstOrDefault(Function(x) x.FieldName = NombreColumna)) = True Then
            '        vwGrid.Columns(NombreColumna).Summary.Add(TipoSumarizacion, NombreColumna, "{0:N0}")
            '        Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            '        item.FieldName = NombreColumna
            '        item.SummaryType = TipoSumarizacion
            '        item.DisplayFormat = "{0}"
            '        vwGrid.GroupSummary.Add(item)
            '    End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub PropiedadesGrid(ByVal vwGrid As GridView, ByVal AjustarAnchoColumnas As Boolean, ByVal AlineacionColumnas As DevExpress.Utils.HorzAlignment, ByVal AgregarFilaFiltro As Boolean)
        vwGrid.OptionsView.ColumnAutoWidth = False
        vwGrid.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwGrid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = AlineacionColumnas
        Next
        vwGrid.OptionsView.ShowAutoFilterRow = AgregarFilaFiltro
    End Sub


    Public Shared Sub DiseñoBaseGrid(ByVal vwGrid As GridView)
        AlternarColorEnFilas(vwGrid)
        PropiedadesGrid(vwGrid, True, DevExpress.Utils.HorzAlignment.Center, True)
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwGrid.Columns
            If col.ColumnType() = GetType(Integer) Then
                EstiloColumna(vwGrid, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 0, False, Nothing, "{0:N0}")
            ElseIf col.ColumnType() = GetType(Double) Then
                'EstiloColumna(vwGrid, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 0, True, DevExpress.Data.SummaryItemType.Sum, "N0")
                EstiloColumna(vwGrid, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 0, True, DevExpress.Data.SummaryItemType.Sum, "{0:N2}")
            ElseIf col.ColumnType() = GetType(Boolean) Then
                EstiloColumna(vwGrid, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, True, True, 0, False, Nothing, "")
            Else
                EstiloColumna(vwGrid, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 0, False, Nothing, "")
            End If

            If col.FieldName = "Inicial" Or col.FieldName = "Usados" Or col.FieldName = "Disponibles" Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "{0:N0}"
            End If
        Next

    End Sub

    Public Shared Sub AjustarAltoEncabezados(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView)
        GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True
    End Sub
    Public Shared Sub FiltroContiene(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView)
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In GridView.Columns
            GridView.Columns.ColumnByFieldName(col.FieldName).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Next
    End Sub

    Public Shared Sub DeshabilitarEdicion(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView)
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In GridView.Columns
            GridView.Columns.ColumnByFieldName(col.FieldName).OptionsColumn.AllowEdit = False
        Next
    End Sub

    Public Shared Sub AjustarAnchoColumnas(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView)
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In GridView.Columns
            GridView.Columns.ColumnByFieldName(col.FieldName).Width = GridView.Columns.ColumnByFieldName(col.FieldName).GetBestWidth
        Next
    End Sub

    Public Shared Sub DiseñoBaseGridSinBestFit(ByVal vwGrid As GridView)
        AlternarColorEnFilasTenue(vwGrid)
        PropiedadesGrid(vwGrid, True, DevExpress.Utils.HorzAlignment.Center, True)
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwGrid.Columns
            If col.ColumnType() = GetType(Integer) Then
                EstiloColumnaSinBestFit(vwGrid, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 0, False, Nothing, "N0")
            ElseIf col.ColumnType() = GetType(Double) Then
                'EstiloColumna(vwGrid, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 0, True, DevExpress.Data.SummaryItemType.Sum, "N0")
                EstiloColumnaSinBestFit(vwGrid, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 0, True, DevExpress.Data.SummaryItemType.Sum, "{0:N2}")
            Else
                EstiloColumnaSinBestFit(vwGrid, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 0, False, Nothing, "")
            End If

        Next

    End Sub

    Public Shared Sub EstiloColumnaSinBestFit(ByVal vwGrid As GridView, ByVal NombreColumna As String, ByVal Titulo As String, ByVal EsVisible As Boolean, ByVal TipoFiltro As Columns.AutoFilterCondition, ByVal PermitirEdicion As Boolean, ByVal AutoAjustarColumna As Boolean, ByVal AnchoColumna As Integer, ByVal LlevaSumarizacion As Boolean, ByVal TipoSumarizacion As DevExpress.Data.SummaryItemType, ByVal FormatoColumna As String)
        Try

            vwGrid.Columns.ColumnByFieldName(NombreColumna).Visible = EsVisible
            vwGrid.Columns.ColumnByFieldName(NombreColumna).OptionsFilter.AutoFilterCondition = TipoFiltro
            vwGrid.Columns.ColumnByFieldName(NombreColumna).Caption = Titulo
            vwGrid.Columns.ColumnByFieldName(NombreColumna).OptionsColumn.AllowSize = True
            vwGrid.Columns.ColumnByFieldName(NombreColumna).OptionsColumn.AllowEdit = PermitirEdicion

            If FormatoColumna <> "" Then
                vwGrid.Columns.ColumnByFieldName(NombreColumna).DisplayFormat.FormatString = FormatoColumna
            End If

            If AutoAjustarColumna = True Then
                'vwGrid.Columns.ColumnByFieldName(NombreColumna).BestFit()
            Else
                vwGrid.Columns.ColumnByFieldName(NombreColumna).Width = AnchoColumna
            End If

            If LlevaSumarizacion = True Then
                vwGrid.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways
                If IsNothing(vwGrid.Columns(NombreColumna).Summary.FirstOrDefault(Function(x) x.FieldName = NombreColumna)) = True Then
                    vwGrid.Columns(NombreColumna).Summary.Add(TipoSumarizacion, NombreColumna, FormatoColumna)
                    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                    item.FieldName = NombreColumna
                    item.SummaryType = TipoSumarizacion
                    item.DisplayFormat = FormatoColumna
                    vwGrid.GroupSummary.Add(item)
                Else

                    vwGrid.Columns(NombreColumna).Summary.Remove(vwGrid.Columns(NombreColumna).Summary.FirstOrDefault(Function(x) x.FieldName = NombreColumna))
                    vwGrid.Columns(NombreColumna).Summary.Add(TipoSumarizacion, NombreColumna, FormatoColumna)
                    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                    item.FieldName = NombreColumna
                    item.SummaryType = TipoSumarizacion
                    item.DisplayFormat = FormatoColumna
                    vwGrid.GroupSummary.Add(item)
                End If
            Else
                If IsNothing(vwGrid.Columns(NombreColumna).Summary.FirstOrDefault(Function(x) x.FieldName = NombreColumna)) = False Then
                    vwGrid.Columns(NombreColumna).Summary.Remove(vwGrid.Columns(NombreColumna).Summary.FirstOrDefault(Function(x) x.FieldName = NombreColumna))
                End If


            End If

            'If LlevaSumarizacion = True Then
            '    vwGrid.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways
            '    If IsNothing(vwGrid.Columns(NombreColumna).Summary.FirstOrDefault(Function(x) x.FieldName = NombreColumna)) = True Then
            '        vwGrid.Columns(NombreColumna).Summary.Add(TipoSumarizacion, NombreColumna, "{0:N0}")
            '        Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            '        item.FieldName = NombreColumna
            '        item.SummaryType = TipoSumarizacion
            '        item.DisplayFormat = "{0}"
            '        vwGrid.GroupSummary.Add(item)
            '    End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
