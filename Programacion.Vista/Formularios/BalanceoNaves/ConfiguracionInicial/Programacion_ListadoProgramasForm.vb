Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils.Menu
Imports Programacion.Negocios
Imports Tools.modMensajes

Public Class Programacion_ListadoProgramasForm
    Dim usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
    Dim tblGrupo As New DataTable
    Dim tbllista As New DataTable
    Dim semana As Int32
    Dim anio As Int32

    Private Sub Programacion_ListadoProgramasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarCombo()
        LlenarSemanaAnio()
        nudSemana.Minimum = 1
    End Sub
    Private Sub LlenarCombo()
        Dim obj As New BalanceoNavesBU
        tblGrupo = obj.ConsultarGrupo()
        tblGrupo.Rows.InsertAt(tblGrupo.NewRow, 0)
        cboGrupo.DataSource = tblGrupo
        cboGrupo.DisplayMember = "grupo"
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros.Visible = True
    End Sub

    'Botón de Limpiar
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cboGrupo.Text = ""
        LlenarSemanaAnio()
        dgListado.DataSource = Nothing
        dgVListado.Columns.Clear()
    End Sub

    Private Sub LlenarSemanaAnio()
        semana = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        anio = DatePart(DateInterval.Year, Now)
        nudSemana.Value = semana
        nudAnio.Value = anio
    End Sub

    'Botón Guardar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim obj As New BalanceoNavesBU
        Try
            dgListado.DataSource = Nothing
            dgVListado.Columns.Clear()
            If cboGrupo.Text = String.Empty Then
                Tools.MostrarMensaje(Mensajes.Warning, "Seleccione el grupo.")
            Else
                tbllista = obj.ListaProgramas(cboGrupo.Text, nudSemana.Value, nudAnio.Value)
                If tbllista.Rows.Count > 0 Then

                    Dim FechaIni As String = tbllista.Columns(2).ColumnName
                    Dim FechaFin As String = tbllista.Columns(7).ColumnName

                    Dim f1 As String = FechaIni.Substring(8, 2)
                    Dim f2 As String = FechaFin.Substring(8, 2)
                    Dim m1 As String = FechaIni.Substring(5, 2)
                    Dim m2 As String = FechaFin.Substring(5, 2)

                    lblRangoFechas.Text = "Del   " + f1 + "/" + m1 + "/" + nudAnio.Value.ToString + "    Al   " + f2 + "/" + m2 + "/" + nudAnio.Value.ToString

                    tbllista.Columns(2).ColumnName = "Lunes"
                    tbllista.Columns(3).ColumnName = "Martes"
                    tbllista.Columns(4).ColumnName = "Miércoles"
                    tbllista.Columns(5).ColumnName = "Jueves"
                    tbllista.Columns(6).ColumnName = "Viernes"
                    tbllista.Columns(7).ColumnName = "Sábado"

                    dgListado.DataSource = tbllista
                    DisenioGrid()
                Else
                    Tools.MostrarMensaje(Mensajes.Warning, "No se encontraron registros.")
                End If
            End If

        Catch ex As Exception
        Finally
            lblUltimaActualizacion.Text = Date.Now
            lblRegistros.Text = tbllista.Rows.Count.ToString()
        End Try
    End Sub

    Private Sub DisenioGrid()
        dgVListado.IndicatorWidth = 40

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In dgVListado.Columns
            If col.FieldName = "nave_naveid" Then
                col.Caption = "id nave"
                col.Visible = False
            End If
            If col.FieldName = "nave_nombre" Then
                col.Caption = "Nave"
            End If
            col.OptionsColumn.AllowEdit = False
        Next

        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(dgVListado)
        Tools.DiseñoGrid.AlternarColorEnFilas(dgVListado)
    End Sub

    Private Sub dgVListado_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles dgVListado.CustomDrawRowIndicator
        If (e.RowHandle >= 0) Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub

    Private Sub dgVListado_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles dgVListado.PopupMenuShowing
        Dim view As GridView = TryCast(sender, GridView)

        If e.MenuType = GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            e.Menu.Items.Clear()
            e.Menu.Items.Add(CreateSubMenuRows(view, rowHandle))

        End If
        'PintarCelda()
    End Sub
    Private Function CreateSubMenuRows(ByVal view As GridView, ByVal rowHandle As Integer) As DXMenuItem
        Dim subMenu As DXSubMenuItem = New DXSubMenuItem("Configuración")
        Dim habilitado As String = String.Empty
        Dim bloqueado As String = String.Empty
        Dim mediodia As String = String.Empty
        Dim limpiar As String = String.Empty

        habilitado = "Habilitado"
        bloqueado = "Bloqueado"
        mediodia = "Medio Día"
        limpiar = "Limpiar"

        Dim h As DXMenuItem = New DXMenuItem(habilitado, New EventHandler(AddressOf OpcionElegidaMenu))
        h.Tag = New RowInfo(view, rowHandle)
        h.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        Dim b As DXMenuItem = New DXMenuItem(bloqueado, New EventHandler(AddressOf OpcionElegidaMenu))
        b.Tag = New RowInfo(view, rowHandle)
        b.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        Dim md As DXMenuItem = New DXMenuItem(mediodia, New EventHandler(AddressOf OpcionElegidaMenu))
        md.Tag = New RowInfo(view, rowHandle)
        md.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        Dim l As DXMenuItem = New DXMenuItem(limpiar, New EventHandler(AddressOf OpcionElegidaMenu))
        l.Tag = New RowInfo(view, rowHandle)
        l.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        subMenu.Items.Add(h)
        subMenu.Items.Add(b)
        subMenu.Items.Add(md)
        subMenu.Items.Add(l)

        Return subMenu

    End Function

    Private Sub OpcionElegidaMenu(ByVal sender As Object, ByVal e As EventArgs)
        Dim menuItem As DXMenuItem = TryCast(sender, DXMenuItem)
        Dim ri As RowInfo = TryCast(menuItem.Tag, RowInfo)
        Dim selectedRowHandles As Int32() = dgVListado.GetSelectedRows()
        Dim Rows As New ArrayList()
        Dim Seleccionado As String = String.Empty
        Dim columna As GridColumn

        If ri IsNot Nothing Then

            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)
                If (selectedRowHandle >= 0) Then
                    Rows.Add(dgVListado.GetDataRow(selectedRowHandle))
                    columna = dgVListado.FocusedColumn()
                End If
            Next

            Select Case menuItem.Caption
                Case "Habilitado"
                    Seleccionado = "Habilitado"
                Case "Bloqueado"
                    Seleccionado = "Bloqueado"
                Case "Medio Día"
                    Seleccionado = "Medio Día"
                Case "Limpiar"
                    Seleccionado = ""
            End Select

            dgVListado.BeginUpdate()
            For I = 0 To Rows.Count - 1
                Dim Row As DataRow = CType(Rows(I), DataRow)
                Row(columna.FieldName) = Seleccionado
            Next

            dgVListado.EndUpdate()

        End If
    End Sub
    Class RowInfo
        Public Sub New(ByVal view As GridView, ByVal rowHandle As Integer)
            Me.RowHandle = rowHandle
            Me.View = view
        End Sub

        Public View As GridView
        Public RowHandle As Integer
    End Class

    Private Sub PintarCelda()
        Dim columna As GridColumn
        If dgVListado.RowCount > 0 Then
            For Each row As DevExpress.XtraGrid.Columns.GridColumn In dgVListado.Columns
                columna = dgVListado.FocusedColumn()
                For index As Integer = 0 To dgVListado.RowCount - 1
                    If IsDBNull(dgVListado.GetRowCellValue(index, columna)) = False Then
                        If dgVListado.GetRowCellValue(index, columna) = "Habilitado" Then
                            dgVListado.Appearance.FocusedCell.BackColor = Color.LightSalmon
                        ElseIf dgVListado.GetRowCellValue(index, columna) = "Bloqueado" Then
                            dgVListado.Appearance.FocusedCell.BackColor = Color.DarkGray
                        End If

                    End If
                Next
            Next
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim obj As New BalanceoNavesBU
        Dim vxmlRegistros As XElement = New XElement("Registros")
        Dim columna As New GridColumn
        Dim dia As String
        If tbllista.Rows.Count > 0 Then

            For index As Integer = 0 To tbllista.Rows.Count - 1
                Dim vNodo As XElement = New XElement("Registro")
                vNodo.Add(New XAttribute("Año", nudAnio.Value))
                vNodo.Add(New XAttribute("Semana", nudSemana.Value))
                vNodo.Add(New XAttribute("Grupo", cboGrupo.Text))
                For Each col As DataColumn In tbllista.Columns
                    Try
                        If col.ColumnName.Contains("nave") Then
                            vNodo.Add(New XAttribute(col.ColumnName, tbllista.Rows(index).Item(col.Caption.ToString()).ToString()))
                        Else
                            dia = ValidarDia(col.ColumnName)
                            vNodo.Add(New XAttribute(dia, tbllista.Rows(index).Item(col.Caption.ToString()).ToString()))
                        End If
                    Catch ex As Exception
                    End Try
                Next
                vNodo.Add(New XAttribute("UsuarioCreo", usuario))
                vNodo.Add(New XAttribute("FechaCreacion", Date.Now.ToShortDateString))
                vxmlRegistros.Add(vNodo)
            Next
            obj.GuardarProgramasDiasHabilitados(cboGrupo.Text, nudSemana.Value, nudAnio.Value, vxmlRegistros.ToString())
            Tools.MostrarMensaje(Mensajes.Success, "Se ha guardado el calendario correctamente.")
            Button1_Click(Nothing, Nothing)
        Else
            Tools.MostrarMensaje(Mensajes.Warning, "No existen registros para guardar.")
        End If
    End Sub

    Public Function ValidarDia(ByVal NombreDia As String) As String
        Dim dia As String = NombreDia

        Select Case dia
            Case "Lunes"
                dia = "D1"
            Case "Martes"
                dia = "D2"
            Case "Miércoles"
                dia = "D3"
            Case "Jueves"
                dia = "D4"
            Case "Viernes"
                dia = "D5"
            Case "Sábado"
                dia = "D6"
        End Select

        Return dia
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub nudSemana_ValueChanged(sender As Object, e As EventArgs) Handles nudSemana.ValueChanged
        If (nudSemana.Value >= 54) Then
            nudSemana.Value = nudSemana.Minimum
        End If
    End Sub

End Class