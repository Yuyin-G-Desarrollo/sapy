Imports DevExpress.XtraGrid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Negocios
Imports Tools

Public Class Programacion_Configuracion_TamañoLote
    Dim listaInicial As New List(Of String)
    Dim eventoActivo As Boolean = False
    Dim Accion As String = String.Empty

    Private Sub Programacion_Configuracion_TamañoLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdColeccion.DataSource = listaInicial
        txtParesMultiple.Value = 12
        txtParesMultiple.Minimum = 12
    End Sub

    Private Sub CargarNaveAuxiliar(ByVal Grupo As String)
        Dim dtNaves As New DataTable
        Dim objBU As New BalanceoNavesBU

        dtNaves = objBU.ConsultarNavesAux(Grupo)

        If dtNaves.Rows.Count > 0 Then
            dtNaves.Rows.InsertAt(dtNaves.NewRow, 0)
            cmbNave.DataSource = dtNaves
            cmbNave.ValueMember = "NaveSAYId"
            cmbNave.DisplayMember = "Nave"

        Else
            show_message("Advertencia", "No existe información de naves.")
        End If
    End Sub

    Private Sub CargarFamiliaPorNave(ByVal NaveID As Integer)
        Dim dtFamiliaNave As New DataTable
        Dim objBU As New BalanceoNavesBU

        dtFamiliaNave = objBU.CargarFamiliaPorNave(NaveID)

        If dtFamiliaNave.Rows.Count > 0 Then
            dtFamiliaNave.Rows.InsertAt(dtFamiliaNave.NewRow, 0)
            cmbFamilia.DataSource = dtFamiliaNave
            cmbFamilia.ValueMember = "FamiliaID"
            cmbFamilia.DisplayMember = "Familia"
        Else
            show_message("Advertencia", "No existen familias para la nave seleccionada.")
        End If



    End Sub


    Private Sub chSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chSeleccionarTodo.CheckedChanged
        Cursor = Cursors.WaitCursor

        Dim activar = False
        If (chSeleccionarTodo.Checked) Then
            activar = True
        End If
        If (eventoActivo = False) Then
            eventoActivo = True
            For i As Integer = 0 To (vwConfLote.RowCount) Step 1
                vwConfLote.SetRowCellValue(i, " ", activar)
            Next
            eventoActivo = False
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = True
    End Sub

    Private Sub cmbGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrupo.SelectedIndexChanged
        If cmbGrupo.Text <> "" Then
            CargarNaveAuxiliar(cmbGrupo.Text)
        End If
    End Sub

    Private Sub cmbNave_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedValueChanged
        If cmbNave.SelectedIndex <> 0 Then
            CargarFamiliaPorNave(cmbNave.SelectedValue)
        End If
    End Sub

    Private Sub btnLimpiarFiltroColeccion_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroColeccion.Click
        grdColeccion.DataSource = listaInicial
    End Sub

    Private Sub btnColeccion_Click(sender As Object, e As EventArgs) Handles btnColeccion.Click
        Dim listado As New Programacion_BalanceoNaves_ListadoParametros
        Dim listaParametroID As New List(Of String)
        Dim FamiliaNaveID As Integer = 0
        Dim NaveID As Integer = 0

        listado.tipo_busqueda = 1

        If IsDBNull(cmbNave.SelectedValue) Or IsDBNull(cmbFamilia.SelectedValue) = False Then
            NaveID = cmbNave.SelectedValue
            FamiliaNaveID = cmbFamilia.SelectedValue
        Else
            show_message("Advertencia", "Seleccione una Nave y Familia.")
            Exit Sub
        End If

        For Each row As UltraGridRow In grdColeccion.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.NaveID = NaveID
        listado.FamiliaID = FamiliaNaveID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColeccion.DataSource = listado.listParametros
        With grdColeccion
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colección"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With

    End Sub

    Private Sub grdColeccion_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        grid_diseño(grdColeccion)
        grdColeccion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colección"
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        asignaFormato_Columna(grid)
    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                col.CellAppearance.TextHAlign = HAlign.Left
            End If
        Next
    End Sub
    Private Sub grdColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub btnMultiplePares_Click(sender As Object, e As EventArgs) Handles btnMultiplePares.Click
        asignarParesMultiple()
    End Sub

     Private Sub asignarParesMultiple()
        Dim objBU As New BalanceoNavesBU
        Dim NumeroFilas As Integer = 0
        Dim CantidadParesMultiple As Integer = 0

        Try
            CantidadParesMultiple = txtParesMultiple.Value

            If (CantidadParesMultiple Mod 12) <> 0 Then
                show_message("Advertencia", "Debe colocar múltiplos de 12.")
            Else

                If vwConfLote.DataRowCount > 0 Then
                    NumeroFilas = vwConfLote.DataRowCount

                    For index As Integer = 0 To NumeroFilas Step 1
                        If CBool(vwConfLote.GetRowCellValue(vwConfLote.GetVisibleRowHandle(index), " ")) = True Then
                            vwConfLote.SetRowCellValue(vwConfLote.GetVisibleRowHandle(index), "Pares por Lote", CantidadParesMultiple)
                        End If
                    Next

                Else
                    show_message("Advertencia", "Seleccione un registro.")
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New BalanceoNavesBU
        Dim dtConfLotes As New DataTable
        Dim FColeccion As String = String.Empty
        Dim NaveID As Integer = 0
        Dim FamiliaID As Integer = 0

        Try

            Cursor = Cursors.WaitCursor
            FColeccion = ObtenerFiltrosGrid(grdColeccion)

            If IsDBNull(cmbNave.SelectedValue) = False Then
                NaveID = cmbNave.SelectedValue
            Else
                show_message("Advertencia", "Seleccione una Nave.")
                Exit Sub
            End If

            If IsDBNull(cmbFamilia.SelectedValue) = False Then
                FamiliaID = cmbFamilia.SelectedValue
            End If

            grdConfLote.DataSource = Nothing
            vwConfLote.Columns.Clear()

            dtConfLotes = objBU.ObtenerConfiguracionTamañoLote(FColeccion, NaveID, FamiliaID)

            If dtConfLotes.Rows.Count > 0 Then
                grdConfLote.DataSource = dtConfLotes
                lblUltimaActualizacion.Text = Date.Now
                DisenioGrid()
                lblRegistros.Text = CDbl(vwConfLote.RowCount.ToString()).ToString("n0")
            Else
                show_message("Advertencia", "No hay información para mostrar.")
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DisenioGrid()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwConfLote.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName <> " " And col.FieldName <> "Tamaño Lote" And col.FieldName <> "Pares por Lote" Then
                col.OptionsColumn.AllowEdit = False
            Else
                col.OptionsColumn.AllowEdit = True
            End If
        Next

        vwConfLote.Columns.ColumnByFieldName("NaveID").Visible = False
        vwConfLote.Columns.ColumnByFieldName("ColeccionID").Visible = False


        vwConfLote.Columns.ColumnByFieldName("Pares por Lote").Caption = "Pares" + vbCrLf + "por Lote"
        vwConfLote.Columns.ColumnByFieldName("Usuario Creo").Caption = "Usuario" + vbCrLf + "Creo"
        vwConfLote.Columns.ColumnByFieldName("Usuario Modifica").Caption = "Usuario" + vbCrLf + "Modifica"

        vwConfLote.Columns.ColumnByFieldName(" ").Width = 30
        vwConfLote.Columns.ColumnByFieldName("Nave").Width = 80
        vwConfLote.Columns.ColumnByFieldName("Colección").Width = 200
        vwConfLote.Columns.ColumnByFieldName("Familia").Width = 130

        vwConfLote.Columns.ColumnByFieldName("Pares por Lote").Width = 70
        vwConfLote.Columns.ColumnByFieldName("Fecha Creación").Width = 85
        vwConfLote.Columns.ColumnByFieldName("Fecha Modifica").Width = 85
        vwConfLote.Columns.ColumnByFieldName("Usuario Modifica").Width = 85
        vwConfLote.Columns.ColumnByFieldName("Usuario Creo").Width = 85

        vwConfLote.IndicatorWidth = 30

        DiseñoGrid.AlternarColorEnFilas(vwConfLote)
    End Sub

    Private Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty
        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next
        Return Resultado
    End Function

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cmbGrupo.Text = ""
        cmbNave.Text = ""
        cmbFamilia.Text = ""

        grdColeccion.DataSource = listaInicial
        grdConfLote.DataSource = Nothing
        txtParesMultiple.Value = 12

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New BalanceoNavesBU
        Dim vXmlCeldasModificadas As XElement
        Dim confirmar As New ConfirmarForm

        Try
            If vwConfLote.DataRowCount > 0 Then
                Accion = "Mostrar"
                vXmlCeldasModificadas = GenerarXML(Accion)

                If vXmlCeldasModificadas.IsEmpty = False Then
                    confirmar.mensaje = "¿Desea actualizar los datos?."
                    If confirmar.ShowDialog() = DialogResult.OK Then
                        Cursor = Cursors.WaitCursor
                        objBU.ActualizarTamanioLote(vXmlCeldasModificadas.ToString())

                        show_message("Exito", "Datos actualizados correctamente.")
                        btnMostrar_Click(Nothing, Nothing)
                    End If
                Else
                    show_message("Advertencia", "No existen registros por modificar.")
                    Exit Sub
                End If
             End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function GenerarXML(ByVal Accion As String)
        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
        Dim NumeroFilas As Integer = 0

        NumeroFilas = vwConfLote.DataRowCount

        For i = 0 To vwConfLote.RowCount - 1
            If vwConfLote.GetRowCellValue(i, "Pares por Lote").ToString <> "0" Or vwConfLote.GetRowCellValue(i, " ").ToString Then
                Dim vNodo As XElement = New XElement("Celda")
                vNodo.Add(New XAttribute("NaveID", vwConfLote.GetRowCellValue(i, "NaveID")))
                vNodo.Add(New XAttribute("ColeccionID", vwConfLote.GetRowCellValue(i, "ColeccionID")))
                If Accion = "Eliminar" Then
                    vNodo.Add(New XAttribute("ParesporLote", 0))
                Else
                    vNodo.Add(New XAttribute("ParesporLote", IIf(IsDBNull(vwConfLote.GetRowCellValue(i, "Pares por Lote")), 0, vwConfLote.GetRowCellValue(i, "Pares por Lote"))))
                End If
                vNodo.Add(New XAttribute("UsuarioID", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                vXmlCeldasModificadas.Add(vNodo)
            End If
        Next

        Return vXmlCeldasModificadas
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New Tools.AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New Tools.AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If
    End Sub

    Private Sub vwConfLote_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwConfLote.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub vwConfLote_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles vwConfLote.ValidatingEditor
        Select Case vwConfLote.FocusedColumn.FieldName

            Case "Pares por Lote"
                Dim num As Integer

                If IsNumeric(e.Value) Then
                    If Convert.ToInt32(e.Value) < 0 Or Convert.ToInt32(e.Value) Mod 12 <> 0 Then
                        e.Valid = False
                    End If
                Else
                    If Not Integer.TryParse(e.Value, num) Then
                        e.Valid = False
                    End If
                End If

        End Select
    End Sub

    Private Sub vwConfLote_InvalidValueException(sender As Object, e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles vwConfLote.InvalidValueException
        Select Case vwConfLote.FocusedColumn.FieldName

            Case "Pares por Lote"
                e.ErrorText = "El valor ingresado debe ser númerico y múltiplos de 12."
        End Select
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim objBU As New BalanceoNavesBU
        Dim vXmlCeldasModificadas As XElement
        Dim confirmar As New ConfirmarForm

        Try
            If vwConfLote.DataRowCount > 0 Then
                Accion = "Eliminar"
                vXmlCeldasModificadas = GenerarXML(Accion)

                confirmar.mensaje = "¿Desea actualizar los datos?."
                If confirmar.ShowDialog() = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    objBU.ActualizarTamanioLote(vXmlCeldasModificadas.ToString())

                    show_message("Exito", "Datos actualizados correctamente.")
                    btnMostrar_Click(Nothing, Nothing)
                End If
            Else
                show_message("Advertencia", "No existen datos para actualizar.")
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmbFamilia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFamilia.SelectedIndexChanged
        If cmbFamilia.SelectedIndex <> 0 Then
            grdColeccion.DataSource = listaInicial
        End If
    End Sub
End Class