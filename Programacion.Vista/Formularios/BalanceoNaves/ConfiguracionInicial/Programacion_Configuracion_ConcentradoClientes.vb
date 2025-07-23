Imports DevExpress.Export
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Programacion.Negocios
Imports Tools

Public Class Programacion_Configuracion_ConcentradoClientes
    Dim NumeroFilas As Integer = 0

    Private Sub Programacion_Configuracion_ConcentradoClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NSemanaInicio.Value = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        NSemanaInicio.TextAlign = HorizontalAlignment.Center
        NAñoInicio.Value = DatePart(DateInterval.Year, Now)
        NAñoInicio.TextAlign = HorizontalAlignment.Center
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

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New BalanceoNavesBU
        Dim dtObtieneClientesBalanceo As New DataTable
        Dim Grupo As String = String.Empty
        Dim NaveID As Integer = 0
        Dim Programa As Integer = 0

        Try

            If cmbGrupo.Text = "TODAS" Or cmbGrupo.Text = "FVO" Or cmbGrupo.Text = "RVO" Then
                Grupo = cmbGrupo.Text
            End If

            If Grupo = "" Then
                If cmbNave.Text <> "" Then
                    NaveID = cmbNave.SelectedValue
                Else
                    show_message("Advertencia", "Seleccione una nave.")
                    Exit Sub
                End If
            End If

            If cmbNave.Text <> "" Then
                NaveID = cmbNave.SelectedValue
            Else
                show_message("Advertencia", "Seleccione una nave.")
                Exit Sub
            End If

            If cmbPrograma.SelectedIndex <> 0 Then
                Programa = cmbPrograma.SelectedValue
            Else
                show_message("Advertencia", "Seleccione un Programa.")
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor

            grdConcentrado.DataSource = Nothing
            vwConcentrado.Columns.Clear()

            dtObtieneClientesBalanceo = objBU.ObtieneClientesBalanceoSemanal(Grupo, NaveID, Programa)

            If dtObtieneClientesBalanceo.Rows.Count > 0 Then
                grdConcentrado.DataSource = dtObtieneClientesBalanceo
                lblUltimaActualizacion.Text = Date.Now
                DisenioGrid()
                lblRegistros.Text = CDbl(vwConcentrado.RowCount.ToString()).ToString("n0")
            Else
                show_message("Advertencia", "No hay datos para mostrar.")
            End If

        Catch ex As Exception
            show_message("Advertencia", "No hay información para mostrar")
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub DisenioGrid()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwConcentrado.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName <> " " And col.FieldName <> "TamañoC" Then
                col.OptionsColumn.AllowEdit = False
            Else
                col.OptionsColumn.AllowEdit = True
            End If
        Next

        vwConcentrado.Columns.ColumnByFieldName("ClienteID").Visible = False
        vwConcentrado.Columns.ColumnByFieldName("ConfID").Visible = False
        vwConcentrado.Columns.ColumnByFieldName("NaveID").Visible = False

        vwConcentrado.Columns.ColumnByFieldName("Cliente").Width = 250
        vwConcentrado.Columns.ColumnByFieldName("Concentra").Width = 100
        vwConcentrado.Columns.ColumnByFieldName("ConcentraCM").Width = 100

        vwConcentrado.Columns.ColumnByFieldName("Usuario").Width = 100
        vwConcentrado.Columns.ColumnByFieldName("FechaCreacion").Width = 100

        vwConcentrado.Columns.ColumnByFieldName("ConcentraCM").Caption = "Concentra" + vbCrLf + "Consigo Mismo"

        vwConcentrado.Columns.ColumnByFieldName("FechaCreacion").Caption = "Fecha" + vbCrLf + "Creación"
        vwConcentrado.Columns.ColumnByFieldName("Usuario").Caption = "Usuario" + vbCrLf + "Creó"

        vwConcentrado.IndicatorWidth = 30

        DiseñoGrid.AlternarColorEnFilas(vwConcentrado)

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New BalanceoNavesBU
        Dim vXmlCeldasModificadas As XElement
        Dim confirmarMensaje As New ConfirmarForm

        Try
            If vwConcentrado.DataRowCount > 0 Then

                vXmlCeldasModificadas = GenerarXML()

                confirmarMensaje.mensaje = "¿Desea actualizar los datos?"
                If confirmarMensaje.ShowDialog() = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    objBU.ActualizarConfiguracionConcentrados(vXmlCeldasModificadas.ToString())

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

        For Each x As Integer In vwConcentrado.GetSelectedRows
            For Each y As DevExpress.XtraGrid.Views.Base.GridCell In vwConcentrado.GetSelectedCells
                If y.RowHandle = x Then
                    Dim vNodo As XElement = New XElement("Celda")
                    vNodo.Add(New XAttribute("ProgramaID", cmbPrograma.SelectedValue))
                    vNodo.Add(New XAttribute("NaveID", cmbNave.SelectedValue))
                    vNodo.Add(New XAttribute("ClienteID", vwConcentrado.GetRowCellValue(x, "ClienteID")))
                    vNodo.Add(New XAttribute("Concentra", vwConcentrado.GetRowCellValue(x, "Concentra")))
                    vNodo.Add(New XAttribute("UsuarioID", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
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

    Private Sub bntLimpiar_Click(sender As Object, e As EventArgs) Handles bntLimpiar.Click
        grdConcentrado.DataSource = Nothing

        cmbNave.Text = ""
        cmbGrupo.Text = ""

        cmbPrograma.Text = ""

        lblRegistros.Text = "0"
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = True
    End Sub

    Private Sub vwConcentrado_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwConcentrado.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
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

    'Evento en vista donde se agrega el menú 
    Private Sub vwConcentrado_PopupMenuShowing(sender As Object, e As Views.Grid.PopupMenuShowingEventArgs) Handles vwConcentrado.PopupMenuShowing
        Dim view As GridView = TryCast(sender, GridView)

        Dim rowHandle As Integer = e.HitInfo.RowHandle
        If e.MenuType = GridMenuType.Row Then
            e.Menu.Items.Clear()
            e.Menu.Items.Add(CreateSubMenuRows(view, rowHandle))
        End If
    End Sub

    Private Function CreateSubMenuRows2(ByVal view As GridView, ByVal rowHandle As Integer) As DXMenuItem
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



    'Función que crea el menú 
    'Se agrega cada opción que tendrá el menú y a su vez se agregan al menú principal
    Private Function CreateSubMenuRows(ByVal view As GridView, ByVal rowHandle As Integer) As DXMenuItem
        Dim subMenu As DXSubMenuItem = New DXSubMenuItem("Concentra")
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
        Dim selectedRowHandles As Int32() = vwConcentrado.GetSelectedRows()
        Dim Rows As New ArrayList()
        Dim OpcionConcentra As String = String.Empty
        Dim columnaEditar As Integer = 0

        If ri IsNot Nothing Then

            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)
                If (selectedRowHandle >= 0) Then
                    Rows.Add(vwConcentrado.GetDataRow(selectedRowHandle))
                End If
            Next

            If vwConcentrado.FocusedColumn.FieldName = "Concentra" Then
                columnaEditar = 1
            Else
                columnaEditar = 2
            End If


            Select Case menuItem.Caption
                Case "SI"
                    OpcionConcentra = "SI"
                Case "NO"
                    OpcionConcentra = "NO"
                Case "ELIMINAR"
                    OpcionConcentra = " "
            End Select

            vwConcentrado.BeginUpdate()
            For I = 0 To Rows.Count - 1
                Dim Row As DataRow = CType(Rows(I), DataRow)

                If columnaEditar = 1 Then
                    Row("Concentra") = OpcionConcentra
                Else
                    Row("ConcentraCM") = OpcionConcentra
                End If

            Next

            vwConcentrado.EndUpdate()
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim filename As String
        Try
            If vwConcentrado.RowCount > 0 Then
                Dim SaveFileDialog As New SaveFileDialog()
                SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
                SaveFileDialog.FilterIndex = 2
                SaveFileDialog.RestoreDirectory = True

                If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                    vwConcentrado.OptionsPrint.AutoWidth = True
                    vwConcentrado.OptionsPrint.EnableAppearanceEvenRow = True
                    vwConcentrado.OptionsPrint.PrintPreview = True
                    filename = SaveFileDialog.FileName

                    Dim exportOptions = New XlsxExportOptionsEx()
                    AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                    DevExpress.Export.ExportSettings.DefaultExportType = ExportType.Default
                    vwConcentrado.ExportToXlsx(filename, exportOptions)

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

    Private Sub cmbGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrupo.SelectedIndexChanged
        If cmbGrupo.Text <> "" Then
            CargarNaveAuxiliar(cmbGrupo.Text)
        End If
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        If cmbNave.SelectedIndex <> 0 Then
            CargarProgramas(cmbNave.SelectedValue)
        End If
    End Sub

    Private Sub CargarProgramas(ByVal NaveID As Integer)
        Dim objBU As New BalanceoNavesBU
        Dim dtCargarProgramas As New DataTable
        Dim Semana As Integer = NSemanaInicio.Value
        Dim Año As Integer = NAñoInicio.Value

        Semana = NSemanaInicio.Value
        Año = NAñoInicio.Value


        dtCargarProgramas = objBU.ObtenerListadoProgramasConcentrado(NaveID, Semana, Año)

        If dtCargarProgramas.Rows.Count > 0 Then
            dtCargarProgramas.Rows.InsertAt(dtCargarProgramas.NewRow, 0)
            cmbPrograma.DataSource = dtCargarProgramas
            cmbPrograma.ValueMember = "ProgramaID"
            cmbPrograma.DisplayMember = "Programa"
        Else
            show_message("Advertencia", "No existen programas para mostrar.")
        End If
    End Sub

End Class