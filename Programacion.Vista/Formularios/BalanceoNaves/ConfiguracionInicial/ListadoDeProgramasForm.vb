Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports Programacion.Negocios
Imports Tools.modMensajes

Public Class ListadoDeProgramasForm
    Dim usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
    Dim tblGrupo As New DataTable
    Dim tbllista As New DataTable
    Dim semana As Int32
    Dim anio As Int32

    Private Sub ListadoDeProgramasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Hola1
        LlenarCombo()
        LlenarSemanaAnio()
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

    Private Sub bntCerrar_Click(sender As Object, e As EventArgs) Handles bntCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cboGrupo.Text = ""
        LlenarSemanaAnio()
    End Sub

    Private Sub LlenarSemanaAnio()
        semana = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        anio = DatePart(DateInterval.Year, Now)
        nudSemana.Value = semana
        nudAnio.Value = anio
    End Sub

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
                    dgListado.DataSource = tbllista
                    DisenioGrid()
                Else
                    Tools.MostrarMensaje(Mensajes.Warning, "Se ha guardado el calendario correctamente.")
                End If
            End If

        Catch ex As Exception
        Finally
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
                col.Caption = "NAVE"
            End If
            col.OptionsColumn.AllowEdit = False
        Next

        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(dgVListado)
        Tools.DiseñoGrid.AlternarColorEnFilasTenue(dgVListado)
        'PintarCelda()
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
                            'dgVListado.SetRowCellValue(index, columna, Color.Green)
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
        'Guardar()
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
                            ' Devuelve la columna Día concatenabdo la fecha ejemplo (Dia2021-08-30)
                            'vNodo.Add(New XAttribute("F_" + col.ColumnName, tbllista.Rows(index).Item(col.Caption.ToString()).ToString()))

                            ' Devuelve la columna día de la semana, ejemplo (LUNES, MARTES, MIÉRCOLES)  y valor asignado (Habilitado, Bloqueado, Medio día ó vacío)
                            dia = ValidarDia(col.ColumnName)
                            vNodo.Add(New XAttribute(dia, tbllista.Rows(index).Item(col.Caption.ToString()).ToString()))
                        End If
                    Catch ex As exception
                    End Try
                Next
                vNodo.Add(New XAttribute("UsuarioCreo", usuario))
                vNodo.Add(New XAttribute("FechaCreacion", Date.Now.ToShortDateString))
                vxmlRegistros.Add(vNodo)
            Next
            'obj.Guardardiasprogramas(vxmlRegistros.ToString())
            obj.GuardarProgramasDiasHabilitados(cboGrupo.Text, nudSemana.Value, nudAnio.Value, vxmlRegistros.ToString())
            Tools.MostrarMensaje(Mensajes.Success, "Se ha guardado el calendario correctamente.")
        Else
            Tools.MostrarMensaje(Mensajes.Warning, "No existen registros para guardar.")
                End If
    End Sub

    Private Sub Guardar()
        Dim obj As New BalanceoNavesBU

    End Sub

    Public Function ValidarDia(ByVal fecha As Date) As String
        Dim dia As String

        dia = DatePart(DateInterval.Weekday, fecha)
        Select Case dia
            Case "1"
                dia = "D0"
            Case "2"
                dia = "D1"
            Case "3"
                dia = "D2"
            Case "4"
                dia = "D3"
            Case "5"
                dia = "D4"
            Case "6"
                dia = "D5"
            Case "7"
                dia = "D6"
        End Select

        Return dia
    End Function

End Class