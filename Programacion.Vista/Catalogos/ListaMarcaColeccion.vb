Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ListaMarcaColeccion
    Dim dtDatosMarca As DataTable
    Dim dtTablaContenidoCoMa As DataTable
    Dim mostrarDetalles As Boolean

    Public Sub LlenarTabla()
        Dim marcaId As String = String.Empty
        Dim MarcaColeBU As New Programacion.Negocios.ColeccionBU
        dtTablaContenidoCoMa = New DataTable
        grdListMarcaColeccion.DataSource = Nothing
        Dim activo As Boolean = True
        If (rdoActivo.Checked = True) Then
            activo = True
        ElseIf (rdoInactivo.Checked = True) Then
            activo = False
        End If

        dtDatosMarca = MarcaColeBU.VerMarcaColecion(activo)
        grdListMarcaColeccion.DataSource = dtDatosMarca

        With grdListMarcaColeccion.DisplayLayout.Bands(0)
            .Columns("cole_coleccionid").Hidden = True
            .Columns("cole_temporadaid").Hidden = True
            .Columns("cole_descripcion").Header.Caption = "Nombre"
            .Columns("cole_Anio").Header.Caption = "Año"
            .Columns("temp_nombre").Header.Caption = "Temporada"
            .Columns("temp_nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("cole_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("cole_Anio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Nave(s) Desarrolla").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListMarcaColeccion.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'grdListMarcaColeccion.DisplayLayout.Bands(0).Columns("coma_codigo").Width = 28
    End Sub

    Public Sub LlenarTablaDetalle()
        Dim marcaId As String = String.Empty
        Dim MarcaColeBU As New Programacion.Negocios.ColeccionBU
        dtTablaContenidoCoMa = New DataTable
        grdListMarcaColeccion.DataSource = Nothing
        Dim activo As Boolean = True
        If (rdoActivo.Checked = True) Then
            activo = True
        ElseIf (rdoInactivo.Checked = True) Then
            activo = False
        End If

        dtDatosMarca = MarcaColeBU.LlenarDatosMarcaColeccionDetalle(activo)
        grdListMarcaColeccion.DataSource = dtDatosMarca

        With grdListMarcaColeccion.DisplayLayout.Bands(0)
            .Columns("cole_coleccionid").Hidden = True
            .Columns("cole_temporadaid").Hidden = True
            .Columns("coma_clienteid").Hidden = True
            .Columns("cole_descripcion").Header.Caption = "Nombre"
            '.Columns("nave_nombre").Header.Caption = "Nave Desarrolla"
            .Columns("marc_descripcion").Header.Caption = "Marca"
            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("cole_Anio").Header.Caption = "Año"
            .Columns("temp_nombre").Header.Caption = "Temporada"
            .Columns("Nave(s) Desarrolla").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("temp_nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("marc_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("cole_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("cole_Anio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("clie_nombregenerico").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListMarcaColeccion.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'grdListMarcaColeccion.DisplayLayout.Bands(0).Columns("coma_codigo").Width = 28
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LlenarTabla()
    End Sub

    Private Sub cmbMarca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ListaMarcaColeccion_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

    End Sub

    Private Sub ListaMarcaColeccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        mostrarDetalles = False
        grdListMarcaColeccion.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListMarcaColeccion.DisplayLayout.Override.RowSelectorWidth = 35
        grdListMarcaColeccion.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        rdoActivo.Checked = True
        'LlenarComboMarcas()
        'LlenarTabla()
        grdListMarcaColeccion.Rows(0).Selected = True
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Try
            Dim Fila As Int32 = 0
            Fila = grdListMarcaColeccion.ActiveRow.Index
            Dim idColeccion As Int32 = grdListMarcaColeccion.Rows(Fila).Cells("cole_coleccionid").Value.ToString
            Dim edColec As New EditarColeccionForm
            edColec.actividadFormulario = "edicion"
            edColec.RecibirIdColeccion(idColeccion)
            edColec.ShowDialog()
            'LlenarComboMarcas()
            LlenarTabla()
        Catch ex As Exception
            Dim forma As New AdvertenciaForm
            forma.mensaje = "Debe selecionar un registro."
            forma.ShowDialog()
        End Try

    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        pnlParametros.Height = 42
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        pnlParametros.Height = 114
    End Sub

    Private Sub btnAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlta.Click
        Dim coleForm As New AltaMarcaColeccion
        coleForm.ShowDialog()
        LlenarTabla()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        LlenarTabla()
    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        LlenarTabla()
    End Sub

    Private Sub grdListMarcaColeccion_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListMarcaColeccion.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdListMarcaColeccion_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdListMarcaColeccion.DoubleClickRow
        Try
            Dim idColeccion As Int32 = grdListMarcaColeccion.Rows(e.Row.Index).Cells("cole_coleccionid").Value.ToString
            Dim edColec As New EditarColeccionForm
            edColec.actividadFormulario = "consulta"
            edColec.RecibirIdColeccion(idColeccion)
            edColec.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnVerDetalles_Click(sender As Object, e As EventArgs) Handles btnVerDetalles.Click
        If mostrarDetalles = True Then
            LlenarTabla()
            mostrarDetalles = False
        Else
            LlenarTablaDetalle()
            mostrarDetalles = True
        End If
    End Sub

    Private Sub grdListMarcaColeccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListMarcaColeccion.InitializeLayout
        Me.grdListMarcaColeccion.DisplayLayout.GroupByBox.Prompt = "Arrastra columnas para agruparlas."
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