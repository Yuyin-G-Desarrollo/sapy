Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaClientesForm

    Private Sub ListaClientesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Top = 0
        Me.Left = 0

        Me.WindowState = FormWindowState.Maximized

        poblar_gridListaCliente(String.Empty, True, gridListaCliente)

    End Sub

    Private Sub ListaClientesForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Dim caracter As Char = e.KeyChar

        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If

        If caracter = "|" Or caracter = "~" Or caracter = "'" Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscar.PerformClick()
        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.Cursor = Cursors.WaitCursor
        If txtNombre.TextLength < 1 Then
            poblar_gridListaCliente(String.Empty, False, gridListaCliente)
        Else
            poblar_gridListaCliente(txtNombre.Text, False, gridListaCliente)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        gridListaCliente.DataSource = Nothing
        poblar_gridListaCliente(String.Empty, True, gridListaCliente)
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click

        'If gridListaCliente.ActiveRow Is Nothing Then Return

        'Dim row As UltraGridRow = gridListaCliente.ActiveRow

        'If row Is Nothing Then Return

        'Dim ftc As New FichaTecnicaClienteForm
        ''ftc.clienteID_Busqueda = CInt(row.Cells(0).Value)
        'ftc.alta_cliente = True
        'ftc.ShowDialog()


        Dim ftc As New FichaTecnicaClienteForm
        ftc.MdiParent = Me.MdiParent
        ftc.alta_cliente = True

        'Me.Close()
        ftc.Show()

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        With fbdUbicacionArchivo

            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True
           
            Dim ret As DialogResult = .ShowDialog

            If ret = Windows.Forms.DialogResult.OK Then

                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                gridExcelExporter.Export(Me.gridListaCliente, .SelectedPath + "\Datos_ListaClientes_" + fecha_hora + ".xlsx")

            End If
            show_message("Exito", "Los datos se exportaron correctamente")
            .Dispose()

        End With

    End Sub

    'Muestra el form de mensaje
    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    'Asigna formato a columnas de ultragrid
    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then

                If col.Header.Caption.Equals("TELÉFONO") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("EXTENSIÓN") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If

        Next

    End Sub

    'Acciones grid Lista de Clientes
    Public Sub poblar_gridListaCliente(texto As String, load As Boolean, grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New Negocios.ClientesBU
        Dim ListaCliente As New DataTable
        Dim leerAsignados As Boolean
        'Dim vendedorID As Integer
        Dim usuarioID As Integer
        Dim cedis As Integer

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_LISTA_CLIENTE", "READASIGNADOS") Then
            leerAsignados = True
            'vendedorID = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
            ' Ahora la consulta se realiza con el ID de usuario y no con el ID de colaborador
            usuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_LISTA_CLIENTE", "ALTASCLIENTES") Then
            btnAltas.Enabled = True
        Else
            btnAltas.Enabled = False
        End If

        If cboxNaveAlmacen.Items.Count = 0 Then
            Utilerias.ComboObtenerCEDISUsuario(cboxNaveAlmacen)
        End If

        cedis = cboxNaveAlmacen.SelectedValue

        If rbtnTodo.Checked Then
            ListaCliente = objBU.ListaCliente_Todos(texto, load, leerAsignados, usuarioID, cedis)
        ElseIf rbtnCliente.Checked Then
            ListaCliente = objBU.ListaCliente_Cliente(texto, leerAsignados, usuarioID, cedis)
        ElseIf rbtnRFC.Checked Then
            ListaCliente = objBU.ListaCliente_RFC(texto, leerAsignados, usuarioID, cedis)
        ElseIf rbtnTienda.Checked Then
            ListaCliente = objBU.ListaCliente_TEC(texto, leerAsignados, usuarioID, cedis)
        ElseIf rbtnContacto.Checked Then
            ListaCliente = objBU.ListaCliente_Contacto(texto, leerAsignados, usuarioID, cedis)
        End If

        grid.DataSource = ListaCliente
        
        gridListaClienteDiseno(grid)

    End Sub

    Private Sub gridListaClienteDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        Me.gridListaCliente.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        Me.gridListaCliente.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaCliente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaCliente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaCliente.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

        gridListaCliente.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti

    End Sub

    Private Sub asignar_grid_gridListaCliente(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        gridListaCliente = grid

    End Sub

    Private Sub gridListaCliente_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gridListaCliente.MouseDoubleClick

        If gridListaCliente.ActiveRow Is Nothing Then Return

        If Not gridListaCliente.ActiveRow.IsDataRow Then Return

        Dim row As UltraGridRow = gridListaCliente.ActiveRow

        If row Is Nothing Then Return

        Dim ftc As New FichaTecnicaClienteForm
        'ftc.MdiParent = Me.MdiParent
        ftc.clienteID_Busqueda = CInt(row.Cells(0).Value)
        ftc.clienteID_Sicy = CInt(row.Cells(1).Value)
        ftc.idcomercializadora = cboxNaveAlmacen.SelectedValue
        ftc.ShowDialog()

    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 78
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 26
    End Sub
End Class