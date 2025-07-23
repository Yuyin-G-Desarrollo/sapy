Imports System.IO
Imports Tools
Imports Programacion.Negocios
Imports DevExpress.XtraGrid.Views.Menu
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils.Menu

Public Class Programacion_ImportarCalendarioForm
    Dim usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
    Dim dtDatosMostrarImportados As New DataTable
    Dim advertencia As New AdvertenciaForm
    Dim exito As New ExitoForm
    Dim tblCalendario As New DataTable
    Dim tblCalendarioCopia As New DataTable
    Dim accion As Integer = 0

    Private Sub Programacion_ImportarCalendarioForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nudAnio.Value = DatePart(DateInterval.Year, Date.Now)
    End Sub

    Private Sub btnMosrar_Click(sender As Object, e As EventArgs) Handles btnMosrar.Click
        Dim obj As New BalanceoNavesBU
        Try
            Me.Cursor = Cursors.WaitCursor
            dgDatos.DataSource = Nothing
            dgVDatos.Columns.Clear()
            tblCalendario = obj.MostrarCalendario(nudAnio.Value)
            If tblCalendario.Rows.Count > 0 Then
                dgDatos.DataSource = tblCalendario
                DisenioGrid()
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "Importe el documento del año " & nudAnio.Value.ToString)
            End If
        Catch ex As Exception
        Finally
            lblUltimaActualizacion.Text = Date.Now
            lblRegistros.Text = tblCalendario.Rows.Count.ToString()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            dtDatosMostrarImportados = ImportarExcelNuevoDiseno()
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnDescargar_Click(sender As Object, e As EventArgs) Handles btnDescargar.Click
        Dim objFTP As New Tools.TransferenciaFTP
        objFTP.DescargarArchivo("/ManualesUsuario/PPCP/", My.Computer.FileSystem.SpecialDirectories.MyDocuments, "ConfiguracionCalendario.xlsx")
        Tools.MostrarMensaje(Mensajes.Success, "Se ha guardado el calendario en Documentos con el nombre ConfiguracionCalendario.xlsx.")
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Dim objBU As New BalanceoNavesBU
        Dim anio As Integer
        Dim tblGenerar As New DataTable
        Dim dtExistenCalendarioDelAño As DataTable
        Dim dtExisteSemanaColocacion As DataTable
        dgDatos.DataSource = Nothing
        dgVDatos.Columns.Clear()

        Try
            Me.Cursor = Cursors.WaitCursor
            anio = nudAnio.Value

            dtExistenCalendarioDelAño = objBU.ExisteCalendarioDelAño(anio, 1)

            If dtExistenCalendarioDelAño.Rows(0).Item("Existe").ToString = "SI" Then

                dtExisteSemanaColocacion = objBU.ExisteCalendarioDelAño(anio, 2)

                If dtExisteSemanaColocacion.Rows(0).Item("Existe").ToString = "SI" Then
                    Tools.MostrarMensaje(Mensajes.Warning, "Las semanas del año " & nudAnio.Value.ToString & " ya fueron generadas.")
                Else
                    tblGenerar = objBU.GenerarSemanasDeColocacion(anio)

                    If tblGenerar.Rows.Count > 0 Then
                        Tools.MostrarMensaje(Mensajes.Success, "Se han generado las semanas de colocación del año " & nudAnio.Value.ToString)
                    Else
                        Tools.MostrarMensaje(Mensajes.Warning, "Ocurrió un error, no se generaron las semanas del año, intente nuevamente.")
                    End If
                End If

            Else
                Tools.MostrarMensaje(Mensajes.Warning, "Importe el calendario del año seleccionado.")
                Exit Sub
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New BalanceoNavesBU
        Dim dtExistenCalendarioDelAño As New DataTable
        Dim UsuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        Try
            If dgVDatos.RowCount > 0 Then
                Dim vXmlRegistros As XElement = New XElement("Registros")
                Me.Cursor = Cursors.WaitCursor

                dtExistenCalendarioDelAño = objBU.ExisteCalendarioDelAño(nudAnio.Value, 1)

                If dtExistenCalendarioDelAño.Rows(0).Item("Existe").ToString = "SI" Then
                    For Each x As Integer In dgVDatos.GetSelectedRows
                        For Each y As DevExpress.XtraGrid.Views.Base.GridCell In dgVDatos.GetSelectedCells
                            If y.RowHandle = x Then
                                Dim vNodo As XElement = New XElement("Registro")
                                vNodo.Add(New XAttribute("Fecha", dgVDatos.GetRowCellValue(x, "Fecha")))
                                vNodo.Add(New XAttribute("Dia", dgVDatos.GetRowCellValue(x, "Día")))
                                vNodo.Add(New XAttribute("SemanaProduccion", dgVDatos.GetRowCellValue(x, "Semana Producción")))
                                vNodo.Add(New XAttribute("NumeroMes", dgVDatos.GetRowCellValue(x, "Número Mes")))
                                vNodo.Add(New XAttribute("NombreMes", dgVDatos.GetRowCellValue(x, "Nombre Mes")))
                                vNodo.Add(New XAttribute("Anio", dgVDatos.GetRowCellValue(x, "Año")))
                                vNodo.Add(New XAttribute("EsLaborable", dgVDatos.GetRowCellValue(x, "¿Es Laborable?")))
                                vNodo.Add(New XAttribute("DiaFestivo", dgVDatos.GetRowCellValue(x, "Día Festivo")))
                                vNodo.Add(New XAttribute("UsuarioCreo", usuario))
                                vNodo.Add(New XAttribute("FechaCreacion", Date.Now.ToShortDateString))
                                vNodo.Add(New XAttribute("UsuarioID", UsuarioID))
                                vXmlRegistros.Add(vNodo)
                            End If

                        Next
                    Next

                Else
                    For i As Integer = 0 To dtDatosMostrarImportados.Rows.Count - 1
                        Dim vNodo As XElement = New XElement("Registro")
                        Dim fecha As Date

                        fecha = dtDatosMostrarImportados.Rows(i).Item("Fecha")
                        vNodo.Add(New XAttribute("Fecha", fecha.ToString("yyyy/MM/dd")))
                        vNodo.Add(New XAttribute("Dia", dtDatosMostrarImportados.Rows(i).Item("Día").ToString()))
                        vNodo.Add(New XAttribute("SemanaProduccion", dtDatosMostrarImportados.Rows(i).Item("Semana Producción").ToString()))
                        vNodo.Add(New XAttribute("NumeroMes", dtDatosMostrarImportados.Rows(i).Item("Número Mes").ToString()))
                        vNodo.Add(New XAttribute("NombreMes", dtDatosMostrarImportados.Rows(i).Item("Nombre Mes").ToString()))
                        vNodo.Add(New XAttribute("Anio", dtDatosMostrarImportados.Rows(i).Item("Año").ToString()))
                        vNodo.Add(New XAttribute("EsLaborable", dtDatosMostrarImportados.Rows(i).Item("¿Es Laborable?").ToString()))
                        vNodo.Add(New XAttribute("DiaFestivo", dtDatosMostrarImportados.Rows(i).Item("Día Festivo").ToString()))
                        vNodo.Add(New XAttribute("UsuarioCreo", usuario))
                        vNodo.Add(New XAttribute("FechaCreacion", Date.Now.ToShortDateString))
                        vXmlRegistros.Add(vNodo)
                    Next
                End If

                objBU.GuardarConfiguracionCalendario(vXmlRegistros.ToString())
                Tools.MostrarMensaje(Mensajes.Success, "Se ha guardado el calendario correctamente.")
                btnMosrar_Click(Nothing, Nothing)
            Else
                advertencia.mensaje = "No existen registros para guardar."
                advertencia.ShowDialog()
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros.Visible = True
    End Sub

    Private Sub DisenioGrid()

        lblRegistros.Text = dgVDatos.DataRowCount

        dgVDatos.IndicatorWidth = 40
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In dgVDatos.Columns
            If col.FieldName = "Fecha" Then
                col.Caption = "Fecha"
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            End If
            If col.FieldName = "Día" Then
                col.Caption = "Día"
            End If
            If col.FieldName = "Semana Producción" Then
                col.Caption = "Semana" + vbCrLf + "Producción"
            End If
            If col.FieldName = "Número Mes" Then
                col.Caption = "Número Mes"
            End If
            If col.FieldName = "Nombre Mes" Then
                col.Caption = "Mes"
            End If
            If col.FieldName = "Año" Then
                col.Caption = "Año"
            End If
            If col.FieldName = "¿Es Laborable?" Then
                col.Caption = "¿Es Laborable?"
            End If
            If col.FieldName = "Día Festivo" Then
                col.Caption = "Día Festivo"
            End If
            col.OptionsColumn.AllowEdit = False
        Next

        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(dgVDatos)
        Tools.DiseñoGrid.AlternarColorEnFilas(dgVDatos)

    End Sub

    Public Function ImportarExcelNuevoDiseno() As DataTable
        Dim advertencia As New AdvertenciaForm
        Dim datosExcel As New DataTable
        Dim NombreArchivo As String = ""
        Dim NumRenglon As Integer = 0
        Dim NumRenglonDataTable As Integer = 0
        Dim NumColumna As Integer = 0
        Dim dtDatosMostrarImportados As New DataTable
        Dim NombreColumna As String = ""
        Dim listColumnasEnteros As New List(Of String)
        Dim fecha As String = String.Empty
        Dim dia As String = String.Empty
        Dim mes As String = String.Empty
        Dim anio As String = String.Empty

        Try
            Dim hoja As String = "ConfigCalendario$"
            datosExcel = Tools.Excel.LlenarTablaExcelListaTablasSinSeleccionarHojaConfiguracionCalendario(hoja, "", NombreArchivo)
            Cursor = Cursors.WaitCursor

            If IsNothing(datosExcel) = False Then
                If datosExcel.Rows.Count > 0 Then
                    For Each row As DataRow In datosExcel.Rows

                        If NumRenglon = 0 Then
                            For Each col As DataColumn In datosExcel.Columns
                                Select Case NumColumna
                                    Case 0
                                        NombreColumna = "Fecha"
                                    Case 1
                                        NombreColumna = "Día"
                                    Case 2
                                        NombreColumna = "Semana Producción"
                                    Case 3
                                        NombreColumna = "Número Mes"
                                    Case 4
                                        NombreColumna = "Nombre Mes"
                                    Case 5
                                        NombreColumna = "Año"
                                    Case 6
                                        NombreColumna = "¿Es Laborable?"
                                    Case 7
                                        NombreColumna = "Día Festivo"
                                    Case Else
                                        NombreColumna = row(col).ToString()
                                        If (IsNumeric(NombreColumna)) Then
                                            listColumnasEnteros.Add(NombreColumna)
                                        End If
                                End Select
                                If NumColumna >= 0 Then
                                    If NumColumna = 0 Then
                                        dtDatosMostrarImportados.Columns.Add(NombreColumna, Type.GetType("System.DateTime"))
                                    Else
                                        dtDatosMostrarImportados.Columns.Add(NombreColumna)
                                    End If

                                    If listColumnasEnteros.Contains(NombreColumna) Then
                                        dtDatosMostrarImportados.Columns(NombreColumna).DataType = System.Type.GetType("System.int32")
                                    End If
                                End If
                                NumColumna += 1
                            Next
                        ElseIf NumRenglon > 0 Then
                            Dim id As String = LTrim(RTrim(row.Item(0).ToString()))
                            If id <> "" Then
                                dtDatosMostrarImportados.Rows.Add()
                                For columna As Integer = 0 To dtDatosMostrarImportados.Columns.Count - 1 Step 1
                                    If row(columna).ToString() <> "" Then
                                        dtDatosMostrarImportados.Rows(NumRenglonDataTable - 1)(columna) = row(columna)
                                    End If
                                Next
                            Else
                                NumRenglonDataTable -= 1
                            End If
                        End If
                        NumRenglon += 1
                        NumRenglonDataTable += 1
                    Next
                End If

                dgDatos.DataSource = dtDatosMostrarImportados
                DisenioGrid()
            Else
                advertencia.mensaje = "El nombre del archivo a importar debe llamarse: ConfiguracionCalendario"
                advertencia.ShowDialog()
            End If

        Catch ex As Exception
            MostrarMensaje(Mensajes.Fault, ex.Message)
        End Try
        Cursor = Cursors.WaitCursor
        Return dtDatosMostrarImportados
    End Function

    Private Sub dgVDatos_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles dgVDatos.CustomDrawRowIndicator
        If (e.RowHandle >= 0) Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub

    Private Sub vwAsignarPrioridad_PopupMenuShowing(ByVal sender As Object, ByVal e As PopupMenuShowingEventArgs) Handles dgVDatos.PopupMenuShowing
        Dim view As GridView = TryCast(sender, GridView)

        If e.MenuType = GridMenuType.Row Then
            Dim rowHandle As Integer = e.HitInfo.RowHandle
            e.Menu.Items.Clear()
            e.Menu.Items.Add(CreateSubMenuRows(view, rowHandle))

        End If
    End Sub

    Private Function CreateSubMenuRows(ByVal view As GridView, ByVal rowHandle As Integer) As DXMenuItem
        Dim subMenu As DXSubMenuItem = New DXSubMenuItem("Día Festivo")
        Dim si As String = String.Empty
        Dim no As String = String.Empty
        Dim limpiar As String = String.Empty

        si = "SI"
        no = "NO"
        limpiar = "LIMPIAR"

        Dim s As DXMenuItem = New DXMenuItem(si, New EventHandler(AddressOf OpcionElegidaMenu))
        s.Tag = New RowInfo(view, rowHandle)
        s.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        Dim n As DXMenuItem = New DXMenuItem(no, New EventHandler(AddressOf OpcionElegidaMenu))
        n.Tag = New RowInfo(view, rowHandle)
        n.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        Dim limp As DXMenuItem = New DXMenuItem(limpiar, New EventHandler(AddressOf OpcionElegidaMenu))
        limp.Tag = New RowInfo(view, rowHandle)
        limp.Enabled = view.IsDataRow(rowHandle) OrElse view.IsGroupRow(rowHandle)

        subMenu.Items.Add(s)
        subMenu.Items.Add(n)
        subMenu.Items.Add(limp)

        Return subMenu

    End Function

    Private Sub OpcionElegidaMenu(ByVal sender As Object, ByVal e As EventArgs)
        Dim menuItem As DXMenuItem = TryCast(sender, DXMenuItem)
        Dim ri As RowInfo = TryCast(menuItem.Tag, RowInfo)
        Dim selectedRowHandles As Int32() = dgVDatos.GetSelectedRows()
        Dim Rows As New ArrayList()
        Dim Seleccionado As String = String.Empty

        If ri IsNot Nothing Then

            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)
                If (selectedRowHandle >= 0) Then
                    Rows.Add(dgVDatos.GetDataRow(selectedRowHandle))
                End If
            Next

            Select Case menuItem.Caption
                Case "SI"
                    Seleccionado = "SI"
                Case "NO"
                    Seleccionado = "NO"
                Case "LIMPIAR"
                    Seleccionado = ""
            End Select

            dgVDatos.BeginUpdate()
            For I = 0 To Rows.Count - 1
                Dim Row As DataRow = CType(Rows(I), DataRow)
                Row("Día Festivo") = Seleccionado
            Next

            dgVDatos.EndUpdate()
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

    Private Sub btnHabilitarProgramaSICY_Click(sender As Object, e As EventArgs) Handles btnHabilitarProgramaSICY.Click
        Dim form As New Programacion_BalanceoNaves_HabilitarProgramasSICY
        Dim dtExisteSemanaColocacion As New DataTable
        Dim anio As Integer = nudAnio.Value
        Dim objBU As New BalanceoNavesBU

        dtExisteSemanaColocacion = objBU.ExisteCalendarioDelAño(anio, 2)

        If dtExisteSemanaColocacion.Rows(0).Item("Existe").ToString = "SI" Then

            form.Año = anio
            form.ShowDialog()
        Else
            Tools.MostrarMensaje(Mensajes.Warning, "Genere las semanas del año para realizar esta acción.")
        End If

    End Sub
End Class