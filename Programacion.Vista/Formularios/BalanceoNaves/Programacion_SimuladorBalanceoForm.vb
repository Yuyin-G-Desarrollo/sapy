Imports Tools.modMensajes
Imports Programacion.Negocios
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid
Imports DevExpress

Public Class Programacion_SimuladorBalanceoForm
    Dim usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
    Dim usuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    Public semana As Integer
    Public idnave As Integer
    Public nave As String
    Public anio As Integer
    Public idBalanceo As Integer

    Dim tblBalanceo As New DataTable
    Private WithEvents repositorio As New RepositoryItemTextEdit
    Dim columna As GridColumn
    Dim columnaD As Integer
    Dim columnaOrigen As String = String.Empty
    Dim columnaDestino As String = String.Empty

    Dim programaOrigen As String = String.Empty
    Dim programaDestino As String = String.Empty
    Dim pedido As Integer = 0
    Dim partida As Integer = 0
    Dim pares As Integer = 0

    Public cambiosRealizados As Integer = 0
    Public SesionID As Integer = 0
    Public verDetalles As Integer = 0
    Public inicio As Boolean = False
    Public botonActualizar As Boolean = False

    Private Sub Programacion_SimuladorBalanceoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblSemanaNave.Text = " Nave " & nave & " Semana " & semana & " - " & anio
        ConsultaBalanceo()
        calcularTotalesPartida()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dim confirmar As New Tools.ConfirmarForm
        Dim objBU As New BalanceoNavesBU

        Try
            confirmar.mensaje = "¿Está seguro de cerrar sin guardar cambios?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                objBU.CerrarSesionUsuarioSimulador(SesionID)
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

        End Try

    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs)
        pnlFiltros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs)
        pnlFiltros.Visible = True
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If dgVSimuladorBalanceo.RowCount > 0 Then
            Tools.Excel.ExportarExcel(dgVSimuladorBalanceo, "Reporte Balanceo " & nave & " Semana " & semana)
        Else
            Tools.MostrarMensaje(Mensajes.Warning, "No existen registros a exportar.")
        End If
    End Sub

    Private Sub ConsultaBalanceo()
        Dim obj As New BalanceoNavesBU
        Try
            Me.Cursor = Cursors.WaitCursor
            tblBalanceo = obj.ConsultarBalanceo(anio, semana, idnave, verDetalles)
            If tblBalanceo.Rows.Count > 0 Then
                dgVSimuladorBalanceo.Columns.Clear()
                dgSimuladorBlanceo.DataSource = tblBalanceo
                DisenioGrid()
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "Mensaje error")
            End If
        Catch ex As Exception
        Finally
            ActualizarRegistrosActualizacion()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DisenioGrid()
        dgVSimuladorBalanceo.IndicatorWidth = 40

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In dgVSimuladorBalanceo.Columns
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains

            If col.FieldName = "ColeccionSAY" Then
                col.Caption = "Colección SAY"
                col.OptionsColumn.AllowEdit = False
            End If

            If col.FieldName = "ModeloSay" Then
                col.Caption = "Modelo SAY"
                col.OptionsColumn.AllowEdit = False
            End If

            If col.FieldName = "PielColor" Then
                col.Caption = "Piel Color"
                col.OptionsColumn.AllowEdit = False
            End If

            If col.FieldName = "Talla" Then
                col.Caption = "Corrida"
                col.OptionsColumn.AllowEdit = False
            End If

            If col.FieldName = "ProductoEstiloId" Then
                col.Caption = "Prod.E."
                col.OptionsColumn.AllowEdit = False
                col.Visible = False
            End If

            If col.FieldName = "ST" Then
                col.Caption = "P"
                col.OptionsColumn.AllowEdit = False
            End If



            If verDetalles = 0 Then
                If col.FieldName = "Partida" Then
                    col.Visible = False
                End If

                If col.FieldName = "PedidoSAY" Then
                    col.Visible = False
                End If

                If col.FieldName = "Cliente" Then
                    col.Visible = False
                End If

                If col.FieldName = "Anotacion" Then
                    col.Visible = False
                End If

            Else
                If col.FieldName = "Partida" Then
                    col.Caption = "Partida"
                    col.OptionsColumn.AllowEdit = False
                End If

                If col.FieldName = "PedidoSAY" Then
                    col.Caption = "Pedido SAY"
                    col.OptionsColumn.AllowEdit = False
                End If

                If col.FieldName = "Cliente" Then
                    col.Caption = "Cliente"
                    col.OptionsColumn.AllowEdit = False
                End If

                If col.FieldName = "Anotacion" Then
                    col.Caption = "Anotación"
                    col.OptionsColumn.AllowEdit = False
                End If
            End If

            If IsNumeric(col.FieldName) Then
                col.Caption = ObtenerNombreFechaPrograma(col.FieldName)
                col.OptionsColumn.AllowEdit = False
                col.DisplayFormat.FormatString = "{0:N0}"

            End If

        Next
        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(dgVSimuladorBalanceo)
        Tools.DiseñoGrid.AlternarColorEnFilas(dgVSimuladorBalanceo)
        Tools.DiseñoGrid.AjustarAnchoColumnas(dgVSimuladorBalanceo)


        dgVSimuladorBalanceo.OptionsView.ShowFooter = True




    End Sub

    Private Function ObtenerNombreFechaPrograma(ByVal idPrograma As Integer) As String
        Dim obj As New BalanceoNavesBU
        Dim NombreFecha As String
        NombreFecha = obj.ObtenerNombreFechaPrograma(idPrograma)
        Return NombreFecha
    End Function

    Private Sub calcularTotalesPartida()
        Dim Lunes, Martes, Miercoles, Jueves, Viernes, Sabado As String
        Dim L, M, MM, J, V, S As String
        Dim Total As Integer = 0

        If dgVSimuladorBalanceo.GroupSummary.Count() = 0 Then

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In dgVSimuladorBalanceo.Columns
                col.Summary.Remove(col.SummaryItem)

                If col.Caption.Contains("Lunes") Then
                    Lunes = col.FieldName
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                    If botonActualizar = True Then
                        lblLunes.Text = col.SummaryText
                    End If

                End If
                If col.Caption.Contains("Martes") Then
                    Martes = col.FieldName
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                    If botonActualizar = True Then
                        lblMartes.Text = col.SummaryText
                    End If

                End If
                If col.Caption.Contains("Miércoles") Then
                    Miercoles = col.FieldName
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                    If botonActualizar = True Then
                        lblMiercoles.Text = col.SummaryText
                    End If

                End If
                If col.Caption.Contains("Jueves") Then
                    Jueves = col.FieldName
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                    If botonActualizar = True Then
                        lblJueves.Text = col.SummaryText
                    End If

                End If
                If col.Caption.Contains("Viernes") Then
                    Viernes = col.FieldName
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                    If botonActualizar = True Then
                        lblViernes.Text = col.SummaryText
                    End If

                End If
                If col.Caption.Contains("Sábado") Then
                    Sabado = col.FieldName
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                    If botonActualizar = True Then
                        lblSabado.Text = col.SummaryText

                    End If

                End If
            Next

            For i = 0 To dgVSimuladorBalanceo.RowCount - 1
                L = IIf(IsDBNull(dgVSimuladorBalanceo.GetRowCellValue(i, Lunes)), " ", dgVSimuladorBalanceo.GetRowCellValue(i, Lunes))
                M = IIf(IsDBNull(dgVSimuladorBalanceo.GetRowCellValue(i, Martes)), " ", dgVSimuladorBalanceo.GetRowCellValue(i, Martes))
                MM = IIf(IsDBNull(dgVSimuladorBalanceo.GetRowCellValue(i, Miercoles)), " ", dgVSimuladorBalanceo.GetRowCellValue(i, Miercoles))
                J = IIf(IsDBNull(dgVSimuladorBalanceo.GetRowCellValue(i, Jueves)), " ", dgVSimuladorBalanceo.GetRowCellValue(i, Jueves))
                V = IIf(IsDBNull(dgVSimuladorBalanceo.GetRowCellValue(i, Viernes)), " ", dgVSimuladorBalanceo.GetRowCellValue(i, Viernes))
                S = IIf(IsDBNull(dgVSimuladorBalanceo.GetRowCellValue(i, Sabado)), " ", dgVSimuladorBalanceo.GetRowCellValue(i, Sabado))

                If LTrim(RTrim(L.ToString())) = "" Then
                    L = "0"
                End If

                If LTrim(RTrim(M.ToString())) = "" Then
                    M = "0"
                End If

                If LTrim(RTrim(MM.ToString())) = "" Then
                    MM = "0"
                End If

                If LTrim(RTrim(J.ToString())) = "" Then
                    J = "0"
                End If

                If LTrim(RTrim(V.ToString())) = "" Then
                    V = "0"
                End If

                If LTrim(RTrim(S.ToString())) = "" Then
                    S = "0"
                End If

                Total = CInt(L) + CInt(M) + CInt(MM) + CInt(J) + CInt(V) + CInt(S)

                Dim colModelPrice As GridColumn = dgVSimuladorBalanceo.Columns("Total")
                colModelPrice.DisplayFormat.FormatType = Utils.FormatType.Numeric
                colModelPrice.DisplayFormat.FormatString = "{0:N0}"

                dgVSimuladorBalanceo.SetRowCellValue(i, "Total", Total)

                botonActualizar = False

            Next
        End If
    End Sub

    Private Function CreateSubMenuRows(ByVal view As GridView, ByVal rowHandle As Integer) As DXMenuItem
        Dim subMenu As DXSubMenuItem = New DXSubMenuItem("Movimiento")
        Dim lunes As String = String.Empty
        Dim martes As String = String.Empty
        Dim miercoles As String = String.Empty
        Dim jueves As String = String.Empty
        Dim viernes As String = String.Empty
        Dim sabado As String = String.Empty

        lunes = "Lunes"
        martes = "Martes"
        miercoles = "Miércoles"
        jueves = "Jueves"
        viernes = "Viernes"
        sabado = "Sábado"

        Dim lun As DXMenuItem = New DXMenuItem(lunes, New EventHandler(AddressOf OpcionElegidaEnMenu))
        lun.Tag = New RowInfo(view, rowHandle)
        lun.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        Dim mar As DXMenuItem = New DXMenuItem(martes, New EventHandler(AddressOf OpcionElegidaEnMenu))
        mar.Tag = New RowInfo(view, rowHandle)
        mar.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        Dim mie As DXMenuItem = New DXMenuItem(miercoles, New EventHandler(AddressOf OpcionElegidaEnMenu))
        mie.Tag = New RowInfo(view, rowHandle)
        mie.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        Dim jue As DXMenuItem = New DXMenuItem(jueves, New EventHandler(AddressOf OpcionElegidaEnMenu))
        jue.Tag = New RowInfo(view, rowHandle)
        jue.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        Dim vie As DXMenuItem = New DXMenuItem(viernes, New EventHandler(AddressOf OpcionElegidaEnMenu))
        vie.Tag = New RowInfo(view, rowHandle)
        vie.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        Dim sab As DXMenuItem = New DXMenuItem(sabado, New EventHandler(AddressOf OpcionElegidaEnMenu))
        sab.Tag = New RowInfo(view, rowHandle)
        sab.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        subMenu.Items.Add(lun)
        subMenu.Items.Add(mar)
        subMenu.Items.Add(mie)
        subMenu.Items.Add(jue)
        subMenu.Items.Add(vie)
        subMenu.Items.Add(sab)

        Return subMenu

    End Function

    Private Sub OpcionElegidaEnMenu(ByVal sender As Object, ByVal e As EventArgs)
        Dim obj As New BalanceoNavesBU
        Dim menuItem As DXMenuItem = TryCast(sender, DXMenuItem)
        Dim ri As RowInfo = TryCast(menuItem.Tag, RowInfo)
        Dim selectedRowHandles As Int32() = dgVSimuladorBalanceo.GetSelectedRows()
        Dim Rows As New ArrayList()
        Dim CantidadSeleccionada As String = String.Empty
        Dim dtMovimientoPares As New DataTable
        Dim posicionInicial As Integer = 0
        Dim paresMover As Integer = 0
        Dim paresIniciales As Integer = 0
        Dim posicionFinal As Integer = 0
        Dim FieldNameInicial As String = String.Empty
        Dim contador As Integer = 0

        If ri IsNot Nothing Then

            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)
                If (selectedRowHandle >= 0) Then
                    Rows.Add(dgVSimuladorBalanceo.GetDataRow(selectedRowHandle))
                    columna = dgVSimuladorBalanceo.FocusedColumn()

                End If
            Next

            Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
            Dim DiaNuevo As String = String.Empty
            Dim DiaAnterior As String = String.Empty


            For Each x As Integer In dgVSimuladorBalanceo.GetSelectedRows

                For Each y As DevExpress.XtraGrid.Views.Base.GridCell In dgVSimuladorBalanceo.GetSelectedCells

                    If y.RowHandle = x Then
                        Dim vNodo As XElement = New XElement("Celda")
                        vNodo.Add(New XAttribute("PedidoSAYID", dgVSimuladorBalanceo.GetRowCellValue(x, "PedidoSAY")))
                        vNodo.Add(New XAttribute("PartidaID", dgVSimuladorBalanceo.GetRowCellValue(x, "Partida")))
                        vNodo.Add(New XAttribute("ProductoEstiloID", dgVSimuladorBalanceo.GetRowCellValue(x, "ProductoEstiloId")))


                        Select Case menuItem.Caption
                            Case "Lunes"
                                DiaNuevo = "L"
                                posicionFinal = 11
                            Case "Martes"
                                DiaNuevo = "M"
                                posicionFinal = 12
                            Case "Miércoles"
                                DiaNuevo = "MM"
                                posicionFinal = 13
                            Case "Jueves"
                                DiaNuevo = "J"
                                posicionFinal = 14
                            Case "Viernes"
                                DiaNuevo = "V"
                                posicionFinal = 15
                            Case "Sábado"
                                DiaNuevo = "S"
                                posicionFinal = 16
                        End Select

                        vNodo.Add(New XAttribute("DiaNuevo", DiaNuevo))
                        vNodo.Add(New XAttribute("Semana", semana))
                        vNodo.Add(New XAttribute("Año", anio))
                        vNodo.Add(New XAttribute("NaveID", idnave))

                        Select Case columna.ToString
                            Case "Lunes"
                                DiaAnterior = "L"
                                posicionInicial = 11
                            Case "Martes"
                                DiaAnterior = "M"
                                posicionInicial = 12
                            Case "Miércoles"
                                DiaAnterior = "MM"
                                posicionInicial = 13
                            Case "Jueves"
                                DiaAnterior = "J"
                                posicionInicial = 14
                            Case "Viernes"
                                DiaAnterior = "V"
                                posicionInicial = 15
                            Case "Sábado"
                                DiaAnterior = "S"
                                posicionInicial = 16


                        End Select

                        paresMover = dgVSimuladorBalanceo.GetRowCellValue(x, columna.FieldName)

                        dgVSimuladorBalanceo.BeginUpdate()

                        Dim Row As DataRow = CType(Rows(contador), DataRow)

                        Row(posicionInicial) = ""

                        If LTrim(RTrim(Row(posicionFinal))) = "" Then
                            Row(posicionFinal) = "0"
                        End If

                        Row(posicionFinal) += paresMover

                        dgVSimuladorBalanceo.EndUpdate()

                        vNodo.Add(New XAttribute("DiaAnterior", DiaAnterior))
                        vNodo.Add(New XAttribute("UsuarioID", usuarioId))
                        vXmlCeldasModificadas.Add(vNodo)
                    End If

                Next

                contador += 1

                dtMovimientoPares = obj.MovimientoParesSimulador(vXmlCeldasModificadas.ToString())

            Next

            If dtMovimientoPares.Rows(0).Item("respuesta").ToString <> "EXITO" Then
                Tools.MostrarMensaje(Mensajes.Warning, "Ocurrió un error al mover los pares, intente nuevamente.")

            Else
                ' ConsultaBalanceo()
                calcularTotalesPartida()
            End If


            ActualizarRegistrosActualizacion()
            lblSemanaNave.Select()

        End If
    End Sub

    Private Function MensajePares()
        Tools.MostrarMensaje(Mensajes.Warning, "No existen pares a mover en la celda seleccionada")
    End Function

    Class RowInfo
        Public Sub New(ByVal view As GridView, ByVal rowHandle As Integer)
            Me.RowHandle = rowHandle
            Me.View = view
        End Sub

        Public View As GridView
        Public RowHandle As Integer
    End Class

    Private Sub ActualizarRegistrosActualizacion()
        lblRegistros.Text = tblBalanceo.Rows.Count
        lblUltimaActualizacion.Text = Date.Now
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim obj As New BalanceoNavesBU
        Dim confirmar As New Tools.ConfirmarForm

        confirmar.mensaje = "¿Está seguro de guardar los cambios en el balanceo de naves.?"
        If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            obj.CambiaEstatusBalanceo(idBalanceo, cambiosRealizados)
            obj.CerrarSesionUsuarioSimulador(SesionID)
            Tools.MostrarMensaje(Mensajes.Success, "Se han realizado los cambios correctamente.")
            dgSimuladorBlanceo.DataSource = Nothing
            dgVSimuladorBalanceo.Columns.Clear()
            Me.Close()
        Else
            Tools.MostrarMensaje(Mensajes.Warning, "Acción cancelada por el usuario.")
        End If


    End Sub

    Private Sub dgVSimuladorBalanceo_PopupMenuShowing_1(sender As Object, e As PopupMenuShowingEventArgs) Handles dgVSimuladorBalanceo.PopupMenuShowing
        Dim view As GridView = TryCast(sender, GridView)

        If e.MenuType = GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            e.Menu.Items.Clear()
            e.Menu.Items.Add(CreateSubMenuRows(view, rowHandle))
        End If

    End Sub

    Private Sub dgVSimuladorBalanceo_CustomDrawRowIndicator_1(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles dgVSimuladorBalanceo.CustomDrawRowIndicator
        If (e.RowHandle >= 0) Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub

    Dim si As Integer = 0
    Private Sub dgVSimuladorBalanceo_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles dgVSimuladorBalanceo.CustomDrawFooterCell
        Dim summary = e.Info.SummaryItem
        Dim L, M, MM, J, V, S As Integer

        If inicio = False Then
            If e.Column.GetCaption.Equals("Lunes") Then
                si += summary.SummaryValue
                L = summary.SummaryValue
                lblLunes.Text = L.ToString("##,###")
            End If
            If e.Column.GetCaption.Equals("Martes") Then
                si += summary.SummaryValue
                M = summary.SummaryValue
                lblMartes.Text = M.ToString("##,###")
            End If
            If e.Column.GetCaption.Equals("Miércoles") Then
                si += summary.SummaryValue
                MM = summary.SummaryValue
                lblMiercoles.Text = MM.ToString("##,###")
            End If
            If e.Column.GetCaption.Equals("Jueves") Then
                si += summary.SummaryValue
                J = summary.SummaryValue
                lblJueves.Text = J.ToString("##,###")
            End If
            If e.Column.GetCaption.Equals("Viernes") Then
                si += summary.SummaryValue
                V = summary.SummaryValue
                lblViernes.Text = V.ToString("##,###")
                inicio = True
            End If
            If e.Column.GetCaption.Equals("Sábado") Then
                si += summary.SummaryValue
                S = summary.SummaryValue
                lblSabado.Text = S.ToString("##,###")
            End If
        End If

        lblParesTotales.Text = si.ToString("##,###")


    End Sub

    Private Sub dgVSimuladorBalanceo_CustomDrawCell(sender As Object, e As Views.Base.RowCellCustomDrawEventArgs) Handles dgVSimuladorBalanceo.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)


        If dgVSimuladorBalanceo.DataRowCount > 0 Then
            If e.Column.FieldName = "ST" Then
                e.Appearance.BackColor = obtenerColorEstatus(currentView.GetRowCellValue(e.RowHandle, "ST"))
                e.Appearance.ForeColor = obtenerColorEstatus(currentView.GetRowCellValue(e.RowHandle, "ST"))
            End If
        End If

    End Sub

    Private Function obtenerColorEstatus(ByVal Estatus As String) As Color
        Dim TipoColor As Color = Color.Empty

        If Estatus = "PA" Then
            TipoColor = PrioridadAlta.BackColor

        ElseIf Estatus = "PM" Then
            TipoColor = PrioridadMedia.BackColor

        ElseIf Estatus = "PB" Then
            TipoColor = PrioridadBaja.BackColor

        Else
            TipoColor = Color.Empty
        End If

        Return TipoColor
    End Function

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        botonActualizar = True
        calcularTotalesPartida()
    End Sub

    'Private Sub dgVSimuladorBalanceo_ColumnFilterChanged(sender As Object, e As EventArgs) Handles dgVSimuladorBalanceo.ColumnFilterChanged
    '    calcularTotalesPartida()
    'End Sub


End Class