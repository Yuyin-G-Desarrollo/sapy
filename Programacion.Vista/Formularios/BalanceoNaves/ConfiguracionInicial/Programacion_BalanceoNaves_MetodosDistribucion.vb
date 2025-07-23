Imports DevExpress.Export
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Negocios
Imports Tools

Public Class Programacion_BalanceoNaves_MetodosDistribucion
    Dim listaInicial As New List(Of String)
    Private Sub Programacion_BalanceoNaves_MetodosDistribucion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdCliente.DataSource = listaInicial
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 5

        For Each row As UltraGridRow In grdCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdCliente.DataSource = listado.listParametros
        With grdCliente
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Clientes"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdCliente.DataSource = listaInicial
    End Sub

    Private Sub grdClientes_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_diseño(grdCliente)
        grdCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Clientes"
    End Sub

    Private Sub grdClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
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

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = True
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

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New BalanceoNavesBU
        Dim FCliente As String = String.Empty
        Dim dtClienteDistribucion As New DataTable

        Try
            Cursor = Cursors.WaitCursor
            FCliente = ObtenerFiltrosGrid(grdCliente)

            grdDistribucionClientes.DataSource = Nothing
            vwDistribucionClientes.Columns.Clear()

            dtClienteDistribucion = objBU.ObtenerDistribucionCliente(FCliente)

            If dtClienteDistribucion.Rows.Count > 0 Then
                grdDistribucionClientes.DataSource = dtClienteDistribucion
                lblUltimaActualizacion.Text = Date.Now
                DisenioGrid()
                lblRegistros.Text = CDbl(vwDistribucionClientes.RowCount.ToString()).ToString("n0")
            Else
                show_message("Advertencia", "No hay información para mostrar")
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DisenioGrid()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwDistribucionClientes.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
        Next

        vwDistribucionClientes.Columns.ColumnByFieldName("Cliente").Width = 245
        vwDistribucionClientes.Columns.ColumnByFieldName("Distribución").Width = 250
        vwDistribucionClientes.Columns.ColumnByFieldName("Tam Atado").Width = 65
        vwDistribucionClientes.Columns.ColumnByFieldName("Usuario Creó").Width = 80
        vwDistribucionClientes.Columns.ColumnByFieldName("Fecha Creación").Width = 80

        vwDistribucionClientes.Columns.ColumnByFieldName("ClienteID").Visible = False
        vwDistribucionClientes.IndicatorWidth = 40

        DiseñoGrid.AlternarColorEnFilas(vwDistribucionClientes)
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New BalanceoNavesBU
        Dim vXmlCeldasModificadas As XElement
        Dim confirmar As New ConfirmarForm

        Try
            If vwDistribucionClientes.DataRowCount > 0 Then
                vXmlCeldasModificadas = GenerarXML()
                confirmar.mensaje = "¿Desea actualizar los datos?"
                If confirmar.ShowDialog() = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    objBU.ActualizarConfiguracionDistribucion(vXmlCeldasModificadas.ToString())

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

    Private Function GenerarXML()
        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")

        For Each x As Integer In vwDistribucionClientes.GetSelectedRows
            For Each y As DevExpress.XtraGrid.Views.Base.GridCell In vwDistribucionClientes.GetSelectedCells
                If y.RowHandle = x Then
                    Dim vNodo As XElement = New XElement("Celda")
                    vNodo.Add(New XAttribute("ClienteID", vwDistribucionClientes.GetRowCellValue(x, "ClienteID")))
                    vNodo.Add(New XAttribute("Distribucion", vwDistribucionClientes.GetRowCellValue(x, "Distribución")))
                    vNodo.Add(New XAttribute("TamañoLote", vwDistribucionClientes.GetRowCellValue(x, "Tam Atado")))
                    vNodo.Add(New XAttribute("UsuarioID", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)) 'Modificar antes de publicar en este y en asignación de prioridades. 
                    vXmlCeldasModificadas.Add(vNodo)
                End If

            Next
        Next

        If vXmlCeldasModificadas.IsEmpty = True Then
            show_message("Advertencia", "No existen registros por modificar.")
            Exit Function
        End If

        Return vXmlCeldasModificadas
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub vwDistribucionClientes_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwDistribucionClientes.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdDistribucionClientes.DataSource = Nothing
        lblRegistros.Text = "0"
    End Sub

    Class RowInfo
        Public Sub New(ByVal view As GridView, ByVal rowHandle As Integer)
            Me.RowHandle = rowHandle
            Me.View = view
        End Sub

        Public View As GridView
        Public RowHandle As Integer
    End Class

    Private Sub vwDistribucionClientes_PopupMenuShowing(sender As Object, e As Views.Grid.PopupMenuShowingEventArgs) Handles vwDistribucionClientes.PopupMenuShowing
        Dim view As GridView = TryCast(sender, GridView)

        If e.MenuType = GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            e.Menu.Items.Clear()
            e.Menu.Items.Add(CreateSubMenuRows(view, rowHandle))
        End If
    End Sub

    'Función que crea el menú 
    'Se agrega cada opción que tendrá el menú y a su vez se agregan al menú principal
    Private Function CreateSubMenuRows(ByVal view As GridView, ByVal rowHandle As Integer) As DXMenuItem
        Dim subMenu As DXSubMenuItem = New DXSubMenuItem("Distribución")
        Dim AlgoritmoSurtido As String = String.Empty
        Dim AlgoritmoAndrea As String = String.Empty
        Dim AlgoritmoDestroyer As String = String.Empty
        Dim EliminarD As String = String.Empty

        AlgoritmoSurtido = "SURTIDO"
        AlgoritmoAndrea = "POR PUNTO ANDREA"
        AlgoritmoDestroyer = "POR PUNTO DESTROYER"
        EliminarD = "ELIMINAR"

        Dim DP As DXMenuItem = New DXMenuItem(AlgoritmoSurtido, New EventHandler(AddressOf OpcionElegidaMenu))
        DP.Tag = New RowInfo(view, rowHandle)
        DP.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        Dim DM6 As DXMenuItem = New DXMenuItem(AlgoritmoAndrea, New EventHandler(AddressOf OpcionElegidaMenu))
        DM6.Tag = New RowInfo(view, rowHandle)
        DM6.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        Dim DM5 As DXMenuItem = New DXMenuItem(AlgoritmoDestroyer, New EventHandler(AddressOf OpcionElegidaMenu))
        DM5.Tag = New RowInfo(view, rowHandle)
        DM5.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        Dim ELD As DXMenuItem = New DXMenuItem(EliminarD, New EventHandler(AddressOf OpcionElegidaMenu))
        ELD.Tag = New RowInfo(view, rowHandle)
        ELD.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        subMenu.Items.Add(DP)
        subMenu.Items.Add(DM6)
        subMenu.Items.Add(DM5)
        subMenu.Items.Add(ELD)

        Return subMenu

    End Function

    'Se crea la funcionalidad al elegir una opción del menú
    Private Sub OpcionElegidaMenu(ByVal sender As Object, ByVal e As EventArgs)
        Dim menuItem As DXMenuItem = TryCast(sender, DXMenuItem)
        Dim ri As RowInfo = TryCast(menuItem.Tag, RowInfo)
        Dim selectedRowHandles As Int32() = vwDistribucionClientes.GetSelectedRows()
        Dim Rows As New ArrayList()
        Dim OpcionDistri As String = String.Empty
        Dim TamAtado As Integer = 0
        Dim columnaEditar As Integer = 0

        If ri IsNot Nothing Then
            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)
                If (selectedRowHandle >= 0) Then
                    Rows.Add(vwDistribucionClientes.GetDataRow(selectedRowHandle))
                End If
            Next

            Select Case menuItem.Caption
                Case "SURTIDO"
                    OpcionDistri = "ALGORITMO SURTIDO CASILLAS"
                    TamAtado = 6
                Case "POR PUNTO ANDREA"
                    OpcionDistri = "ALGORITMO POR PUNTO ANDREA"
                    TamAtado = 5
                Case "POR PUNTO DESTROYER"
                    OpcionDistri = "ALGORITMO POR PUNTO DESTROYER"
                    TamAtado = 6
                Case "ELIMINAR"
                    OpcionDistri = " "
                    TamAtado = 0
            End Select

            vwDistribucionClientes.BeginUpdate()

            For I = 0 To Rows.Count - 1
                Dim Row As DataRow = CType(Rows(I), DataRow)
                Row("Distribución") = OpcionDistri
                Row("Tam Atado") = TamAtado
            Next

            vwDistribucionClientes.EndUpdate()
        End If

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim filename As String
        Try
            If vwDistribucionClientes.RowCount > 0 Then
                Dim SaveFileDialog As New SaveFileDialog()
                SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
                SaveFileDialog.FilterIndex = 2
                SaveFileDialog.RestoreDirectory = True

                If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                    vwDistribucionClientes.OptionsPrint.AutoWidth = True
                    vwDistribucionClientes.OptionsPrint.EnableAppearanceEvenRow = True
                    vwDistribucionClientes.OptionsPrint.PrintPreview = True
                    filename = SaveFileDialog.FileName

                    Dim exportOptions = New XlsxExportOptionsEx()
                    AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                    DevExpress.Export.ExportSettings.DefaultExportType = ExportType.Default
                    vwDistribucionClientes.ExportToXlsx(filename, exportOptions)

                    If System.IO.File.Exists(filename) Then
                        Dim DialogResult As DialogResult = MessageBox.Show("El archivo ha sido exportado a " & filename & vbNewLine & "¿Quieres abrirlo ahora?", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If DialogResult = Windows.Forms.DialogResult.Yes Then
                            System.Diagnostics.Process.Start(filename)
                        End If
                    End If
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No existen registros para exportar")
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        If (e.RowHandle Mod 2 > 0) Then
            e.Formatting.BackColor = Color.LightSteelBlue
        End If

        e.Handled = True
    End Sub
End Class