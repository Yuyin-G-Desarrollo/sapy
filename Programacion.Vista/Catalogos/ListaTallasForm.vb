Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ListaTallasForm
    Dim dtTablaTallas As DataTable
    Dim dtDatosComboTallas As DataTable


    Public Sub LlenarTablaTallas()
        Dim TallaNegocios As New Programacion.Negocios.TallasBU
        Dim activo As Boolean = True
        If rdoActivo.Checked = True Then
            activo = True
        ElseIf rdoInactivo.Checked = True Then
            activo = False
        End If

        grdListaTallas.DataSource = Nothing
        dtTablaTallas = New DataTable
        dtTablaTallas = TallaNegocios.VerTablaTallas("", "", activo, "")
        grdListaTallas.DataSource = dtTablaTallas

        With grdListaTallas.DisplayLayout.Bands(0)
            .Columns("talla_tallaid").Hidden = True
            .Columns("talla_sicy").Header.Caption = "SICY"
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaTallas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        Dim alines As Int32 = 0
        For alinea = 0 To 25
            Me.grdListaTallas.DisplayLayout.Bands(0).Columns(alinea).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        Next
        Me.grdListaTallas.DisplayLayout.Bands(0).Columns(28).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        For alineaDT = 0 To 29
            Me.grdListaTallas.DisplayLayout.Bands(0).Columns(alineaDT).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Next

    End Sub

    'Public Sub LlenarComboTallasPrincipales()
    '    Dim TallaNegocios As New Programacion.Negocios.TallasBU
    '    cmbTallasPrincipales.DataSource = Nothing
    '    dtDatosComboTallas = New DataTable
    '    dtDatosComboTallas = TallaNegocios.VerTallasPrincipales
    '    dtDatosComboTallas.Rows.InsertAt(dtDatosComboTallas.NewRow, 0)

    '    cmbTallasPrincipales.DataSource = dtDatosComboTallas
    '    cmbTallasPrincipales.ValueMember = "talla_tallaid"
    '    cmbTallasPrincipales.DisplayMember = "pais"
    'End Sub

    Public Sub EnviarDatoIdTalla()
        Dim fila As Int32 = grdListaTallas.ActiveRow.Index
        If grdListaTallas.ActiveRow.Index <> grdListaTallas.Rows.FilterRow.Index Then
            Dim IdTalla As Int32 = Convert.ToInt32(grdListaTallas.Rows(fila).Cells(0).Value.ToString)
            Dim pais As String = grdListaTallas.Rows(fila).Cells("País").Value.ToString
            Dim edTalla As New EditarTallaForm
            edTalla.idTalla = IdTalla
            edTalla.nombrePais = pais
            edTalla.editando = 1
            edTalla.ShowDialog()
            LlenarTablaTallas()
        End If

    End Sub

    Private Sub btnAltas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltas.Click
        Dim alTalla As New AltaTallasForm
        alTalla.ShowDialog()
        LlenarTablaTallas()

    End Sub

    Private Sub ListaTallasForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        rdoActivo.Checked = True
        LlenarTablaTallas()
        Me.Top = 0
        Me.Left = 0
        grdListaTallas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaTallas.DisplayLayout.Override.RowSelectorWidth = 35
        grdListaTallas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdListaTallas.Rows(0).Selected = True
    End Sub

    Private Sub bntFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LlenarTablaTallas()

    End Sub

    Private Sub btnUP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        pnlParametros.Height = 45
    End Sub

    Private Sub bntDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        pnlParametros.Height = 105
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Try
            EnviarDatoIdTalla()

        Catch ex As Exception
            Dim forma As New AdvertenciaForm
            forma.mensaje = "Debe seleccionar un registro."
            forma.ShowDialog()
        End Try
    End Sub

    Private Sub grdListaTallas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaTallas.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdListaTallas_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdListaTallas.DoubleClickRow

        Dim fila As Int32 = grdListaTallas.ActiveRow.Index
        If grdListaTallas.ActiveRow.Index <> grdListaTallas.Rows.FilterRow.Index Then
            Dim IdTalla As Int32 = Convert.ToInt32(grdListaTallas.Rows(fila).Cells(0).Value.ToString)
            Dim pais As String = grdListaTallas.Rows(fila).Cells("País").Value.ToString
            If pais = "MÉXICO" Then
                Dim alAmarre As New AltaAmarreForm
                alAmarre.IdTalla = IdTalla
                alAmarre.ShowDialog()
            Else
                Dim edEditar As New EditarTallaForm
                edEditar.idTalla = IdTalla
                edEditar.nombrePais = pais
                edEditar.editando = 0
                edEditar.ShowDialog()
            End If
        End If

    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        LlenarTablaTallas()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        LlenarTablaTallas()
    End Sub

    Private Sub grdListaTallas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaTallas.InitializeLayout
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

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class