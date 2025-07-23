Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaFamiliasForm
    Dim dtTablaFamilias As DataTable

    Public Sub LlenarTablaFamilias()
        Dim FamiliaNegocios As New Programacion.Negocios.FamiliasBU
        Dim codigo As String = txtCodigo.Text.Trim
        Dim descripcion As String = txtDescripcion.Text.Trim
        Dim activo As Boolean = True
        If (rdoActivo.Checked = True) Then
            activo = True
        ElseIf (rdoInactivo.Checked = True) Then
            activo = False
        End If

        dtTablaFamilias = FamiliaNegocios.ListarFamilias(codigo, descripcion, activo)
        grdListaFamilias.DataSource = dtTablaFamilias

        With grdListaFamilias.DisplayLayout.Bands(0)
            .Columns("fami_familiaid").Hidden = True
            .Columns("fami_activo").Hidden = True

            .Columns("fami_codigo").Header.Caption = "Código"
            .Columns("fami_descripcion").Header.Caption = "Nombre"
            .Columns("fami_codigo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("fami_codigo").CellActivation = Activation.NoEdit
            .Columns("fami_descripcion").CellActivation = Activation.NoEdit

            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaFamilias.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListaFamilias.DisplayLayout.Appearance.BorderColor = Color.Gray
        grdListaFamilias.DisplayLayout.Override.DefaultRowHeight = 22
        grdListaFamilias.DisplayLayout.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle
        grdListaFamilias.DisplayLayout.Bands(0).Columns("fami_codigo").Width = 40
        'grdListaFamiliasUno.DataSource = dtTablaFamilias
        'grdListaFamiliasUno.Columns("fami_familiaid").Visible = False
        'grdListaFamiliasUno.Columns("fami_activo").Visible = False
        'grdListaFamiliasUno.Columns(1).ReadOnly = True
        'grdListaFamiliasUno.Columns(2).ReadOnly = True
        'grdListaFamiliasUno.Columns(1).Width = 70
        'grdListaFamilias.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Public Sub LimpiarTablaFamilias()
        Dim FamiliaNegocios As New Programacion.Negocios.FamiliasBU
        Dim activo As Boolean = True

        If (rdoActivo.Checked = True) Then
            activo = True
        ElseIf (rdoInactivo.Checked = True) Then
            activo = False
        End If
        dtTablaFamilias = FamiliaNegocios.ListarFamilias("0", "0", "0")

        grdListaFamilias.DataSource = dtTablaFamilias

        With grdListaFamilias.DisplayLayout.Bands(0)
            .Columns("fami_familiaid").Hidden = True
            .Columns("fami_activo").Hidden = True

            .Columns("fami_codigo").Header.Caption = "Código"
            .Columns("fami_descripcion").Header.Caption = "Descripción"

            .Columns("fami_codigo").CellActivation = Activation.NoEdit
            .Columns("fami_descripcion").CellActivation = Activation.NoEdit

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaFamilias.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        'grdListaFamiliasUno.DataSource = dtTablaFamilias

        'grdListaFamiliasUno.Columns("fami_familiaid").Visible = False
        'grdListaFamiliasUno.Columns("fami_activo").Visible = False
        'grdListaFamiliasUno.Columns(1).Width = 80
        'grdListaFamiliasUno.Columns(2).Width = 555
        'grdListaFamiliasUno.Columns(1).ReadOnly = True
        'grdListaFamiliasUno.Columns(2).ReadOnly = True
        ''grdListaFamilias.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        rdoActivo.Checked = True
        txtCodigo.Text = String.Empty
        txtDescripcion.Text = String.Empty
    End Sub

    Public Sub EnviarEditarFamilia()
        Try
            Dim EntidadFamilia As New Entidades.Familias
            Dim Fila As Int32 = 0

            Fila = grdListaFamilias.ActiveRow.Index
            EntidadFamilia.PIdFamilia = grdListaFamilias.Rows(Fila).Cells(0).Value.ToString
            EntidadFamilia.PCodigo = grdListaFamilias.Rows(Fila).Cells(1).Value.ToString
            EntidadFamilia.PDescripcion = grdListaFamilias.Rows(Fila).Cells(2).Value.ToString
            EntidadFamilia.PActivo = grdListaFamilias.Rows(Fila).Cells(3).Value.ToString

            'EntidadFamilia.PIdFamilia = grdListaFamiliasUno.Item(0, Fila).Value().ToString
            'EntidadFamilia.PCodigo = grdListaFamiliasUno.Item(1, Fila).Value().ToString
            'EntidadFamilia.PDescripcion = grdListaFamiliasUno.Item(2, Fila).Value().ToString
            'EntidadFamilia.PActivo = grdListaFamiliasUno.Item(3, Fila).Value().ToString

            Dim edFam As New EditarFamiliaForm
            edFam.LlenarDatosFamilia(EntidadFamilia)
            edFam.ShowDialog()
        Catch ex As Exception
            MsgBox(" Debe seleccionar un registro.")
        End Try
    End Sub


    Public Function ValidarExistencia() As Boolean
        Dim FamiliasbNegocio As New Programacion.Negocios.FamiliasBU

        Dim dtTabla As DataTable = FamiliasbNegocio.ContadorFilas
        Dim ValidacionExistePrimero As Int32 = dtTabla.Rows.Count
        Dim dtidFamilia As DataTable = New DataTable
        dtidFamilia = FamiliasbNegocio.VerIdfamiliaMasAlto
        Dim codigoNuevo As String = String.Empty
        Dim IdMaximo As Int32 = 0
        Dim IdNuevo As Int32 = 0

        If (dtTabla.Rows.Count = 0) Then
            IdMaximo = 1
        Else
            IdMaximo = Convert.ToInt32(dtidFamilia.Rows(0)("Maximo").ToString)
        End If
        Dim dtCodigosDisponibles As DataTable
        dtCodigosDisponibles = New DataTable
        dtCodigosDisponibles = FamiliasbNegocio.VerCodigosDisponibles()
        If (ValidacionExistePrimero >= 37) Then
            If (dtCodigosDisponibles.Rows.Count = 0) Then
                Return False
            End If
        End If

        Return True

    End Function

    Private Sub ListaFamiliasForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        txtDescripcion.Focus()
        LlenarTablaFamilias()
        Me.Top = 0
        Me.Left = 0
        grdListaFamilias.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaFamilias.DisplayLayout.Override.RowSelectorWidth = 35
        grdListaFamilias.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdListaFamilias.Rows(0).Selected = True
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        LlenarTablaFamilias()
    End Sub

    Private Sub btnAltas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltas.Click
        If (ValidarExistencia() = True) Then
            Dim alFamilia As New AltaFamiliaForm
            alFamilia.ShowDialog()
            LlenarTablaFamilias()
        ElseIf (ValidarExistencia() = False) Then
            MsgBox("No hay códigos para asignar.")
        End If
    End Sub

    Private Sub btnlimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlimpiar.Click
        LimpiarTablaFamilias()

    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        EnviarEditarFamilia()
        LlenarTablaFamilias()
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 50) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtDescripcion.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnRestaurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestaurar.Click
        pnlParametrosBusqueda.Height = 46

    End Sub

    Private Sub btnOcultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOcultar.Click
        pnlParametrosBusqueda.Height = 77
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtCodigo.Text.Length < 3) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtCodigo.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        LlenarTablaFamilias()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        LlenarTablaFamilias()
    End Sub

    Private Sub grdListaFamilias_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaFamilias.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    'Private Sub grdListaFamilias_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdListaFamilias.DoubleClickRow
    '    Try
    '        Dim EntidadFamilia As New Entidades.Familias
    '        Dim Fila As Int32 = 0

    '        Fila = e.Row.Index
    '        EntidadFamilia.PIdFamilia = grdListaFamilias.Rows(Fila).Cells(0).Value.ToString
    '        EntidadFamilia.PCodigo = grdListaFamilias.Rows(Fila).Cells(1).Value.ToString
    '        EntidadFamilia.PDescripcion = grdListaFamilias.Rows(Fila).Cells(2).Value.ToString
    '        EntidadFamilia.PActivo = grdListaFamilias.Rows(Fila).Cells(3).Value.ToString

    '        Dim edFam As New ConsultaFamiliaTallas
    '        edFam.LlenarDatosFamilia(EntidadFamilia)
    '        edFam.ShowDialog()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub grdListaFamilias_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaFamilias.InitializeLayout
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