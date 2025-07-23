Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.SupportDialogs.FilterUIProvider
Imports Infragistics.Win
Imports Tools

Public Class ListaProductosForm
    Dim filaValidacion As Int32
    Dim dtListaMarcas As DataTable
    Dim cadenaFiltroMarcas As String
    Dim advMensaje As New AdvertenciaForm
    Dim value As New Object
    Public Sub LlenarComboMarca()
        Dim objMBU As New Programacion.Negocios.MarcasBU
        dtListaMarcas = objMBU.ComboMarcas
        'dtListaMarcas.Rows.InsertAt(dtListaMarcas.NewRow, 0)
        cmbUMarca.DataSource = dtListaMarcas
        cmbUMarca.ValueMember = "marc_marcaid"
        cmbUMarca.DisplayMember = "Descripción"
    End Sub

    Public Sub LlenarComoFamilia()
        Dim objFBU As New Programacion.Negocios.FamiliasBU
        Dim dtListaFamilias As DataTable
        dtListaFamilias = objFBU.verComboFamilias("")
        dtListaFamilias.Rows.InsertAt(dtListaFamilias.NewRow, 0)
        cmbFamilia.DataSource = dtListaFamilias
        cmbFamilia.ValueMember = "fami_familiaid"
        cmbFamilia.DisplayMember = "fami_descripcion"
    End Sub

    Public Sub LlenarComboColeccion()
        Dim objCBU As New Programacion.Negocios.ColeccionBU
        Dim dtListaColecciones As DataTable
        If (cadenaFiltroMarcas <> "") Then
            dtListaColecciones = objCBU.verComboColeccion(cadenaFiltroMarcas)
        Else
            dtListaColecciones = objCBU.verComboColeccion("")
        End If
        cmbUColeccion.DataSource = dtListaColecciones
        cmbUColeccion.ValueMember = "cole_descripcion"
        cmbUColeccion.DisplayMember = "cole_descripcion"
    End Sub

    Public Sub LlenarTablaProductos()
        Dim objPBU As New Programacion.Negocios.ProductosBU
        Dim dtTablaProductos As DataTable
        Dim activo As Boolean
        If (rdoActivo.Checked = True) Then
            activo = True
        ElseIf (rdoInactivo.Checked = True) Then
            activo = False
        End If

        dtTablaProductos = objPBU.VerListaProductos(activo, cboComercializadora.SelectedValue)
        grdListaProductos.DataSource = dtTablaProductos
        disenoGrid()

    End Sub

    Public Sub limpiarTabla()
        Dim objPBU As New Programacion.Negocios.ProductosBU
        Dim dtTablaProductos As DataTable
        dtTablaProductos = objPBU.VerListaProductos(True, cboComercializadora.SelectedValue)
        grdListaProductos.DataSource = dtTablaProductos
        disenoGrid()
        rdoActivo.Checked = True
    End Sub

    Public Sub disenoGrid()

        With grdListaProductos.DisplayLayout.Bands(0)
            .Columns("prod_productoid").Hidden = True
            .Columns("prod_activo").Hidden = True
            .Columns("prod_foto").Hidden = True
            .Columns("prod_dibujo").Hidden = True
            '.Columns("grpo_grupoid").Hidden = True
            .Columns("tica_tipocategoriaid").Hidden = True
            .Columns("prod_codigo").Header.Caption = "Modelo SAY" ' "Código" '22/06/2020
            .Columns("marc_descripcion").Header.Caption = "Marca"
            .Columns("cole_descripcion").Header.Caption = "Colección"
            .Columns("prod_descripcion").Header.Caption = "Descripción"
            .Columns("temp_nombre").Header.Caption = "Temporada"
            .Columns("temp_año").Header.Caption = "Año"
            '.Columns("grpo_descripcion").Header.Caption = "Grupo"
            .Columns("subfamilias").Header.Caption = "Aplicaciones"
            .Columns("tica_descripcion").Header.Caption = "Tipo de Producto"
            .Columns("prod_modelo").Header.Caption = "Modelo SICY"  '"Modelo" '22/06/2020
            .Columns("subfamilias").Hidden = True
            .Columns("tica_descripcion").Hidden = True
            .Columns("tica_descripcion").CellActivation = Activation.NoEdit
            .Columns("subfamilias").CellActivation = Activation.NoEdit
            .Columns("prod_codigo").CellActivation = Activation.NoEdit
            .Columns("marc_descripcion").CellActivation = Activation.NoEdit
            .Columns("cole_descripcion").CellActivation = Activation.NoEdit
            .Columns("prod_descripcion").CellActivation = Activation.NoEdit
            .Columns("temp_nombre").CellActivation = Activation.NoEdit
            .Columns("temp_año").CellActivation = Activation.NoEdit
            '.Columns("grpo_descripcion").CellActivation = Activation.NoEdit
            .Columns("prod_modelo").CellActivation = Activation.NoEdit

            .Columns("prod_codigo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("prod_modelo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("temp_año").CellAppearance.TextHAlign = HAlign.Right
            .Columns("marc_esLicencia").Hidden = True

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaProductos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListaProductos.DisplayLayout.Bands(0).Columns("prod_codigo").Width = 100
        grdListaProductos.DisplayLayout.Bands(0).Columns("marc_descripcion").Width = 100
    End Sub

    Private Sub ListaProductosForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub ListaProductosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROG_CAT_PROD", "NO_PERMISO_EDITAR_NI_ALTAS") Then
            pnlOperaciones.Enabled = False
        End If

        Utilerias.ComboObtenerCEDISUsuario(cboComercializadora)

        'rdoActivo.Checked = True
        'LlenarComboMarca()
        'LlenarComboColeccion()
        'Me.Top = 0
        'Me.Left = 0
        'grdListaProductos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        'grdListaProductos.DisplayLayout.Override.RowSelectorWidth = 35
        'grdListaProductos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        'If grdListaProductos.Rows.Count > 0 Then
        '    grdListaProductos.Rows(0).Selected = True
        'End If
        ''LlenarTablaProductos()


        Me.WindowState = FormWindowState.Maximized
    End Sub

    Public Sub AbrirDetallesProducto()
        Dim fila As Int32
        Dim idProducto As String
        Dim codigo As String
        Dim descripcion As String
        Dim marca As String
        Dim coleccion As String
        Dim temporada As String
        Dim anio As String
        Dim subfamilia As String
        Dim foto As String
        Dim dibujo As String
        Dim categoria As String

        If grdListaProductos.ActiveRow.Index <> grdListaProductos.Rows.FilterRow.Index Then
            fila = grdListaProductos.ActiveRow.Index
            filaValidacion = fila

            idProducto = grdListaProductos.Rows(fila).Cells("prod_productoid").Value.ToString
            codigo = grdListaProductos.Rows(fila).Cells("prod_codigo").Value.ToString
            marca = grdListaProductos.Rows(fila).Cells("marc_descripcion").Value.ToString
            coleccion = grdListaProductos.Rows(fila).Cells("cole_descripcion").Value.ToString
            descripcion = grdListaProductos.Rows(fila).Cells("prod_descripcion").Value.ToString
            temporada = grdListaProductos.Rows(fila).Cells("temp_nombre").Value.ToString
            anio = grdListaProductos.Rows(fila).Cells("temp_año").Value.ToString
            foto = grdListaProductos.Rows(fila).Cells("prod_foto").Value.ToString
            dibujo = grdListaProductos.Rows(fila).Cells("prod_dibujo").Value.ToString
            subfamilia = grdListaProductos.Rows(fila).Cells("subfamilias").Value.ToString
            categoria = grdListaProductos.Rows(fila).Cells("tica_descripcion").Value.ToString
            Dim detalle As New ListaDetalleProductoForm
            detalle.MdiParent = MdiParent
            detalle.LlenarTablaDetalles(idProducto, codigo, descripcion, marca, coleccion, temporada, anio, subfamilia, foto, dibujo, categoria)
            detalle.Show()
        End If

    End Sub

    Public Sub EnviarDatosProductoEditar()
        Try
            Dim fila As Int32 = 0

            fila = grdListaProductos.ActiveRow.Index.ToString
            Dim Producto As New EditarProductoForm
            Producto.idProducto = grdListaProductos.Rows(fila).Cells("prod_productoid").Value.ToString()
            Producto.activo = grdListaProductos.Rows(fila).Cells("prod_activo").Value.ToString()
            'Producto.txtCodSicy.Enabled = False
            Producto.esLicencia = grdListaProductos.Rows(fila).Cells("marc_esLicencia").Value.ToString()
            Producto.idcedis = cboComercializadora.SelectedValue
            Producto.ShowDialog()

        Catch ex As Exception
            ' MsgBox("Debe seleccionar un registro.")
        End Try
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        LlenarTablaProductos()
    End Sub

    Private Sub txtEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Me.Cursor = Cursors.WaitCursor
        EnviarDatosProductoEditar()
        LlenarTablaProductos()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub grdListaProductos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles grdListaProductos.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        EnviarDatosProductoEditar()
        LlenarTablaProductos()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub txtAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlta.Click
        Dim prod As New RegistraProductosForm
        'prod.MdiParent = MdiParent
        prod.idcedis = cboComercializadora.SelectedValue
        prod.ShowDialog()
        LlenarTablaProductos()
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        grpParametros.Height = 117
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        grpParametros.Height = 42
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        limpiarTabla()
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtCodigo.Text.Length < 5) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
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

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 100) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Or (caracter = ("-")) Or (caracter = ("/")) Then
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

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub grdListaProductos_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles grdListaProductos.AfterRowFilterChanged
        If grdListaProductos.DisplayLayout.Bands(0).ColumnFilters(2).ToString = "" Then
            'cmbUMarca.Clear()
            Dim contcmbUMarca As Int32 = cmbUMarca.CheckedItems.Count
            If contcmbUMarca = 1 Then
                cmbUMarca.SelectedItem.CheckState = CheckState.Unchecked
            ElseIf contcmbUMarca > 1 Then
                cmbUMarca.Clear()
            End If
        End If
        If grdListaProductos.DisplayLayout.Bands(0).ColumnFilters(3).ToString = "" Then
            'cmbUColeccion.Clear()
            Dim contcmbUColeccion As Int32 = cmbUColeccion.CheckedItems.Count
            If contcmbUColeccion = 1 Then
                cmbUColeccion.SelectedItem.CheckState = CheckState.Unchecked
            ElseIf contcmbUColeccion > 1 Then
                cmbUColeccion.Clear()
            End If

        End If

    End Sub

    Private Sub grdListaProductos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaProductos.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    '14/09/2020
    'Private Sub grdListaProductos_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdListaProductos.DoubleClickRow
    '    EnviarDatosProductoEditar()
    '    LlenarTablaProductos()
    '    'AbrirDetallesProducto()
    'End Sub
    Private Sub grdListaProductos_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdListaProductos.DoubleClickRow
        btnEditar.PerformClick()
    End Sub

    Private Sub filtarColeccion()
        Dim cadenaC As String = cmbUColeccion.Text
        Dim lugarC As Integer
        Dim matrizC() As String

        Try
            matrizC = Split(Trim(cadenaC), ",")
            Dim tamanoCadena As Integer
            tamanoCadena = UBound(matrizC) + 1

            grdListaProductos.DisplayLayout.Bands(0).ColumnFilters(4).ClearFilterConditions()
            grdListaProductos.DisplayLayout.Bands(0).ColumnFilters(4).LogicalOperator = FilterLogicalOperator.Or

            For lugarC = 1 To tamanoCadena
                If Trim(matrizC(lugarC - 1)) <> "" Then
                    grdListaProductos.DisplayLayout.Bands(0).ColumnFilters(4).FilterConditions.Add(FilterComparisionOperator.Equals, Trim(matrizC(lugarC - 1)))
                Else
                    grdListaProductos.DisplayLayout.Bands(0).ColumnFilters(4).ClearFilterConditions()
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbUColeccion_ValueChanged(sender As Object, e As EventArgs) Handles cmbUColeccion.ValueChanged


    End Sub
    Private Sub filtarMarca()
        Dim dtDatosFiltrados As New DataTable
        Dim cadena As String = cmbUMarca.Text
        Dim lugar As Integer
        Dim matriz() As String
        Dim datosCombo As System.Collections.IList = Nothing
        Dim dtsCmbFiltro As IValueList = Nothing
        Try
            matriz = Split(Trim(cadena), ",")
            Dim tamanoCadena As Integer
            tamanoCadena = UBound(matriz) + 1

            grdListaProductos.DisplayLayout.Bands(0).ColumnFilters(3).ClearFilterConditions()
            grdListaProductos.DisplayLayout.Bands(0).ColumnFilters(3).LogicalOperator = FilterLogicalOperator.Or

            For lugar = 1 To tamanoCadena
                If Trim(matriz(lugar - 1)) <> "" Then
                    grdListaProductos.DisplayLayout.Bands(0).ColumnFilters(3).FilterConditions.Add(FilterComparisionOperator.Equals, Trim(matriz(lugar - 1)))
                Else
                    grdListaProductos.DisplayLayout.Bands(0).ColumnFilters(3).ClearFilterConditions()
                End If
            Next
            datosCombo = Me.cmbUMarca.Value
            dtsCmbFiltro = Me.cmbUMarca.Items.ValueList
            If Not datosCombo Is Nothing Then
                Dim index As Int32 = -1
                cadenaFiltroMarcas = ""
                For Each value As Object In datosCombo
                    Dim text As String = dtsCmbFiltro.GetText(value, index)
                    cadenaFiltroMarcas += value.ToString + ", "
                Next
                cadenaFiltroMarcas += "0"
            Else
                cadenaFiltroMarcas = ""
            End If

            LlenarComboColeccion()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub grdListaProductos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaProductos.InitializeLayout
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

    'Private Sub btnCargarDiferencia_Click(sender As Object, e As EventArgs) Handles btnCargarDiferencia.Click
    '    Dim bojPBU As New Negocios.ProductosBU
    '    Dim dtDatos As New DataTable
    '    dtDatos = bojPBU.cargacadena
    '    Dim cadena As String = ""
    '    For Each row As DataRow In dtDatos.Rows
    '        If row.Item("pres_codSicy").ToString <> "" Then
    '            cadena += "'" + row.Item("pres_codSicy").ToString + "', "
    '        End If
    '    Next
    '    cadena += ""
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim form2 As New pruebainfra()
        'form2.Opacity = 0.75
        form2.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnVerModelosDetalles.Click
        Dim objVerModelos As New pruebainfra
        objVerModelos.MdiParent = MdiParent
        objVerModelos.Show()
    End Sub


    Private Sub btnFotografia_Click(sender As Object, e As EventArgs) Handles btnFotografia.Click
        If grdListaProductos.Rows.Count > 0 Then
            If grdListaProductos.ActiveRow.Selected Then
                AbrirDetallesProducto()
            Else
                advMensaje.mensaje = "Seleccione un registro."
                advMensaje.ShowDialog()
            End If
        End If
    End Sub

    Private Sub grdListaProductos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListaProductos.ClickCell
        Try
            If grdListaProductos.Rows.Count > 0 Then
                grdListaProductos.ActiveRow.Selected = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEstatus_Click(sender As Object, e As EventArgs) Handles btnEstatus.Click
        Me.Cursor = Cursors.WaitCursor
        Dim formEstatus As New CambioEstatusProductoForm
        formEstatus.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim datosCombo As System.Collections.IList = Nothing
        Dim dtsCmbFiltro As IValueList = Nothing
        datosCombo = Me.cmbUMarca.Value

        'If datosCombo IsNot Nothing Then
        LlenarTablaProductos()
            filtarMarca()
            filtarColeccion()
            'Else
            '    Me.Cursor = System.Windows.Forms.Cursors.Default
            '    Dim msg As New AdvertenciaForm
            '    msg.mensaje = "Seleccione una marca."
            '    msg.ShowDialog()
            'End If

            Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnLimpiar2_Click(sender As Object, e As EventArgs) Handles btnLimpiar2.Click
        grdListaProductos.DataSource = Nothing
        LlenarComboMarca()
        LlenarComboColeccion()
    End Sub

    Private Sub cboComercializadora_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboComercializadora.SelectedIndexChanged
        value = cboComercializadora.SelectedValue
        If (TypeOf value Is Integer) Then
            rdoActivo.Checked = True
            LlenarComboMarcaCedis()
            LlenarComboColeccion()
            Me.Top = 0
            Me.Left = 0
            grdListaProductos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdListaProductos.DisplayLayout.Override.RowSelectorWidth = 35
            grdListaProductos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            If grdListaProductos.Rows.Count > 0 Then
                grdListaProductos.Rows(0).Selected = True
            End If

        End If
    End Sub

    Private Sub LlenarComboMarcaCedis()
        Dim objMBU As New Programacion.Negocios.MarcasBU
        Dim idcedis As Integer = cboComercializadora.SelectedValue
        dtListaMarcas = objMBU.ModelosLlenarComboMarcas(idcedis)
        'dtListaMarcas.Rows.InsertAt(dtListaMarcas.NewRow, 0)
        cmbUMarca.DataSource = dtListaMarcas
        cmbUMarca.ValueMember = "marc_marcaid"
        cmbUMarca.DisplayMember = "Descripción"
    End Sub

    Private Sub btnRastroModelosAndrea_Click(sender As Object, e As EventArgs) Handles btnRastroModelosAndrea.Click
        Dim form As New Programacion.Vista.CatalogoModelosAndreaRastreo
        'Nuevoform
        form.ShowDialog()
    End Sub
End Class