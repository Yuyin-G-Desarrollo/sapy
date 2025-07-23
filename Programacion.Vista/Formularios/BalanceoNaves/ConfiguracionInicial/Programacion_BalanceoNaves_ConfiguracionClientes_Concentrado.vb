Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Negocios
Imports Tools

Public Class Programacion_BalanceoNaves_ConfiguracionClientes_Concentrado
    Dim listaInicial As New List(Of String)

    Private Sub Programacion_BalanceoNaves_ConfiguracionClientes_Concentrado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New BalanceoNavesBU
        Dim FCliente As String = String.Empty
        Dim dtClientesTodos As New DataTable

        Try
            Cursor = Cursors.WaitCursor
            FCliente = ObtenerFiltrosGrid(grdCliente)

            grdConfCliente.DataSource = Nothing
            vwConfCliente.Columns.Clear()

            dtClientesTodos = objBU.ObtenerTodosClientes(FCliente)

            If dtClientesTodos.Rows.Count > 0 Then
                grdConfCliente.DataSource = dtClientesTodos
                lblUltimaActualizacion.Text = Date.Now
                DisenioGrid()
                lblRegistros.Text = CDbl(vwConfCliente.RowCount.ToString()).ToString("n0")
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

    Private Sub vwConfCliente_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwConfCliente.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub DisenioGrid()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwConfCliente.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
        Next

        vwConfCliente.Columns.ColumnByFieldName("Cliente").Width = 250
        vwConfCliente.Columns.ColumnByFieldName("Concentra Consigo Mismo").Width = 100

        vwConfCliente.Columns.ColumnByFieldName("FechaModifica").Caption = "Fecha Modifica"
        vwConfCliente.Columns.ColumnByFieldName("FechaModifica").Width = 100

        vwConfCliente.Columns.ColumnByFieldName("UsuarioModifica").Caption = "Usuario Modifica"
        vwConfCliente.Columns.ColumnByFieldName("UsuarioModifica").Width = 100

        vwConfCliente.Columns.ColumnByFieldName("ClienteID").Visible = False
        vwConfCliente.IndicatorWidth = 30

        DiseñoGrid.AlternarColorEnFilas(vwConfCliente)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    'Evento en vista donde se agrega el menú 
    Private Sub vwConfCliente_PopupMenuShowing(sender As Object, e As Views.Grid.PopupMenuShowingEventArgs) Handles vwConfCliente.PopupMenuShowing
        Dim view As GridView = TryCast(sender, GridView)

        If e.MenuType = GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            e.Menu.Items.Clear()
            e.Menu.Items.Add(CreateSubMenuRows(view, rowHandle))
        End If
    End Sub

    'Esta mini clase tiene las variables que se utilizan para el funcionamiento del menú, se pasa la vista y el renglón
    Class RowInfo
        Public Sub New(ByVal view As GridView, ByVal rowHandle As Integer)
            Me.RowHandle = rowHandle
            Me.View = view
        End Sub

        Public View As GridView
        Public RowHandle As Integer
    End Class


    'Función que crea el menú 
    'Se agrega cada opción que tendrá el menú y a su vez se agregan al menú principal
    Private Function CreateSubMenuRows(ByVal view As GridView, ByVal rowHandle As Integer) As DXMenuItem
        Dim subMenu As DXSubMenuItem = New DXSubMenuItem("Concentra Consigo Mismo")
        Dim ConcentraSI As String = String.Empty
        Dim ConcentraNO As String = String.Empty
        Dim EliminarC As String = String.Empty

        ConcentraSI = "SI"
        ConcentraNO = "NO"
        EliminarC = "ELIMINAR"


        Dim CSi As DXMenuItem = New DXMenuItem(ConcentraSI, New EventHandler(AddressOf OpcionElegidaMenu))
        CSi.Tag = New RowInfo(view, rowHandle)
        CSi.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        Dim CNo As DXMenuItem = New DXMenuItem(ConcentraNO, New EventHandler(AddressOf OpcionElegidaMenu))
        CNo.Tag = New RowInfo(view, rowHandle)
        CNo.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        Dim ElC As DXMenuItem = New DXMenuItem(EliminarC, New EventHandler(AddressOf OpcionElegidaMenu))
        ElC.Tag = New RowInfo(view, rowHandle)
        ElC.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        subMenu.Items.Add(CSi)
        subMenu.Items.Add(CNo)
        subMenu.Items.Add(ElC)
        Return subMenu

    End Function

    'Se crea la funcionalidad al elegir una opción del menú
    Private Sub OpcionElegidaMenu(ByVal sender As Object, ByVal e As EventArgs)
        Dim menuItem As DXMenuItem = TryCast(sender, DXMenuItem)
        Dim ri As RowInfo = TryCast(menuItem.Tag, RowInfo)
        Dim selectedRowHandles As Int32() = vwConfCliente.GetSelectedRows()
        Dim Rows As New ArrayList()
        Dim OpcionConcentra As String = String.Empty
        Dim columnaEditar As Integer = 0

        If ri IsNot Nothing Then

            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)
                If (selectedRowHandle >= 0) Then
                    Rows.Add(vwConfCliente.GetDataRow(selectedRowHandle))
                End If
            Next

            Select Case menuItem.Caption
                Case "SI"
                    OpcionConcentra = "SI"
                Case "NO"
                    OpcionConcentra = "NO"
                Case "ELIMINAR"
                    OpcionConcentra = " "
            End Select

            vwConfCliente.BeginUpdate()
            For I = 0 To Rows.Count - 1
                Dim Row As DataRow = CType(Rows(I), DataRow)
                Row("Concentra Consigo Mismo") = OpcionConcentra
            Next

            vwConfCliente.EndUpdate()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New BalanceoNavesBU
        Dim vXmlCeldasModificadas As XElement
        Dim confirmarMensaje As New ConfirmarForm

        Try

            If vwConfCliente.DataRowCount > 0 Then
                vXmlCeldasModificadas = GenerarXML()

                confirmarMensaje.mensaje = "¿Desea actualizar los datos?."
                If confirmarMensaje.ShowDialog() = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    objBU.ActualizarTodosClienteConcentrado(vXmlCeldasModificadas.ToString())

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

        For Each x As Integer In vwConfCliente.GetSelectedRows
            For Each y As DevExpress.XtraGrid.Views.Base.GridCell In vwConfCliente.GetSelectedCells
                If y.RowHandle = x Then
                    Dim vNodo As XElement = New XElement("Celda")
                    vNodo.Add(New XAttribute("ClienteID", vwConfCliente.GetRowCellValue(x, "ClienteID")))
                    vNodo.Add(New XAttribute("Concentra", vwConfCliente.GetRowCellValue(x, "Concentra Consigo Mismo")))
                    vNodo.Add(New XAttribute("UsuarioID", 350))
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

End Class