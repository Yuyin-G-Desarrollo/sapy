Imports System.IO
Imports Tools
Imports Programacion.Negocios
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils.Menu
Imports DevExpress.Utils
Public Class Programacion_ImportacionCalendarioForm

    Dim usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
    Dim dtDatosMostrarImportados As New DataTable
    Dim advertencia As New AdvertenciaForm
    Dim exito As New ExitoForm
    Dim tblCalendario As New DataTable
    Dim tblCalendarioCopia As New DataTable
    Private Sub Programacion_ImportacionCalendario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nudAnio.Value = DatePart(DateInterval.Year, Now)
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim obj As New BalanceoNavesBU
        Try
            Me.Cursor = Cursors.WaitCursor
            dgDatos.DataSource = Nothing
            dgVDatos.Columns.Clear()
            tblCalendario = obj.MostrarCalendario(nudAnio.Value)
            If tblCalendario.Rows.Count > 0 Then
                dgDatos.DataSource = tblCalendario
                DisenioGrid()
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            'dgDatos.DataSource = Nothing
            'dgVDatos.Columns.Clear()
            dtDatosMostrarImportados = ImportarExcelNuevoDiseno()
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim objFTP As New Tools.TransferenciaFTP
        'objFTP.DescargarArchivo("/ManualesUsuario/PPCP/", "Descargas\Manuales\PPCP", "ConfiguracionCalendario.xlsx")
        objFTP.DescargarArchivo("/ManualesUsuario/PPCP/", My.Computer.FileSystem.SpecialDirectories.MyDocuments, "ConfiguracionCalendario.xlsx")
        'Process.Start("Descargas\Manuales\PPCP\ConfiguracionCalendario.xlsx")
        Tools.MostrarMensaje(Mensajes.Success, "Se ha guardado el calendario en Documentos con el nombre ConfiguracionCalendario.xlsx.")
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Dim objBU As New BalanceoNavesBU
        Dim anio As Integer
        Dim tblGenerar As New DataTable
        dgDatos.DataSource = Nothing
        dgVDatos.Columns.Clear()

        Try
            Me.Cursor = Cursors.WaitCursor
            anio = nudAnio.Value
            tblGenerar = objBU.GenerarSemanasDeColocacion(anio)
            tblCalendario = objBU.GenerarCalendario(anio, usuario)
            If tblCalendario.Rows.Count > 0 Then
                dgDatos.DataSource = tblCalendario
                DisenioGrid()
            End If
            Tools.MostrarMensaje(Mensajes.Success, "Se han generado las semanas de colocación del año " & nudAnio.Value.ToString)
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New BalanceoNavesBU
        'Dim dtDatosMostrarImportados As New DataTable
        Try
            If dgVDatos.RowCount > 0 Then

                Me.Cursor = Cursors.WaitCursor
                Dim vXmlRegistros As XElement = New XElement("Registros")
                If tblCalendario.Rows.Count > 0 Then

                    'For i As Integer = 0 To dtDatosMostrarImportados.Rows.Count - 1
                    For i As Integer = 0 To tblCalendario.Rows.Count - 1
                        Dim vNodo As XElement = New XElement("Registro")
                        Dim fecha As Date
                        fecha = tblCalendario.Rows(i).Item("Fecha")
                        vNodo.Add(New XAttribute("Fecha", fecha.ToString("yyyy/MM/dd")))
                        vNodo.Add(New XAttribute("Dia", tblCalendario.Rows(i).Item("Día").ToString()))
                        vNodo.Add(New XAttribute("SemanaProduccion", tblCalendario.Rows(i).Item("Semana Producción").ToString()))
                        vNodo.Add(New XAttribute("NumeroMes", tblCalendario.Rows(i).Item("Número Mes").ToString()))
                        vNodo.Add(New XAttribute("NombreMes", tblCalendario.Rows(i).Item("Nombre Mes").ToString()))
                        vNodo.Add(New XAttribute("Anio", tblCalendario.Rows(i).Item("Año").ToString()))
                        vNodo.Add(New XAttribute("EsLaborable", tblCalendario.Rows(i).Item("¿Es Laborable?").ToString()))
                        vNodo.Add(New XAttribute("DiaFestivo", tblCalendario.Rows(i).Item("Día Festivo").ToString()))
                        'vNodo.Add(New XAttribute("Bimestre", dtDatosMostrarImportados.Rows(i).Item("Bimestre").ToString()))
                        'vNodo.Add(New XAttribute("Trimestre", dtDatosMostrarImportados.Rows(i).Item("Trimestre").ToString()))
                        'vNodo.Add(New XAttribute("Cuatrimestre", dtDatosMostrarImportados.Rows(i).Item("Cuatrimestre").ToString()))
                        'vNodo.Add(New XAttribute("Semestre", dtDatosMostrarImportados.Rows(i).Item("Semestre").ToString()))
                        vNodo.Add(New XAttribute("UsuarioCreo", usuario))
                        vNodo.Add(New XAttribute("FechaCreacion", Date.Now.ToShortDateString))
                        vXmlRegistros.Add(vNodo)
                    Next

                    objBU.GuardarConfiguracionCalendario(vXmlRegistros.ToString())


                    Tools.MostrarMensaje(Mensajes.Success, "Se ha guardado el calendario correctamente.")

                End If
            Else
                advertencia.mensaje = "No existen registros para guardar."
                advertencia.ShowDialog()
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub




    Private Sub bntCerrar_Click(sender As Object, e As EventArgs) Handles bntCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros.Visible = True
    End Sub

    Private Sub DisenioGrid()
        dgVDatos.IndicatorWidth = 40
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In dgVDatos.Columns
            If col.FieldName = "Fecha" Then
                col.Caption = "FECHA"
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                'col.DisplayFormat.FormatString = String.Format("{0}: {1:0.0} - {2:yyyy}")
            End If
            If col.FieldName = "Día" Then
                col.Caption = "DÍA"
            End If
            If col.FieldName = "Semana Producción" Then
                col.Caption = "SEMANA PRODUCCIÓN"
            End If
            If col.FieldName = "Número Mes" Then
                col.Caption = "NÚMERO MES"
            End If
            If col.FieldName = "Nombre Mes" Then
                col.Caption = "MES"
            End If
            If col.FieldName = "Año" Then
                col.Caption = "AÑO"
            End If
            If col.FieldName = "¿Es Laborable?" Then
                col.Caption = "¿ES LABORABLE?"
            End If
            If col.FieldName = "Día Festivo" Then
                col.Caption = "DÍA FESTIVO"
            End If
            'If col.FieldName = "Bimestre" Then
            '    col.Caption = "BIMESTRE"
            'End If
            'If col.FieldName = "Trimestre" Then
            '    col.Caption = "TRIMESTRE"
            'End If
            'If col.FieldName = "Cuatrimestre" Then
            '    col.Caption = "CUATRIMESTRE"
            'End If
            'If col.FieldName = "Semestre" Then
            '    col.Caption = "SEMESTRE"
            'End If
            col.OptionsColumn.AllowEdit = False
        Next

        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(dgVDatos)
        Tools.DiseñoGrid.AlternarColorEnFilasTenue(dgVDatos)

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
                                        'Case 8
                                        '    NombreColumna = "Bimestre"
                                        'Case 9
                                        '    NombreColumna = "Trimestre"
                                        'Case 10
                                        '    NombreColumna = "Cuatrimestre"
                                        'Case 11
                                        '    NombreColumna = "Semestre"
                                    Case Else
                                        NombreColumna = row(col).ToString()
                                        If (IsNumeric(NombreColumna)) Then
                                            listColumnasEnteros.Add(NombreColumna)
                                        End If
                                End Select
                                If NumColumna >= 0 Then
                                    If NumColumna = 0 Then
                                        dtDatosMostrarImportados.Columns.Add(NombreColumna, Type.GetType("System.DateTime"))
                                        'dtDatosMostrarImportados.Columns(NombreColumna).DataType = System.Type.GetType("System.Date")
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
                'tblCalendarioCopia = tblCalendario.Copy

                'dgDatos.DataSource = tblCalendarioCopia

                'If dtDatosMostrarImportados.Rows.Count > 0 - 1 Then
                '    For index As Integer = 0 To dtDatosMostrarImportados.Rows.Count - 1
                '        Dim fechaImp = dtDatosMostrarImportados.Rows(index).Item("Fecha").ToString
                '        Dim eslaborable = dtDatosMostrarImportados.Rows(index).Item("¿Es Laborable?").ToString()
                '        Dim diaFestivo = dtDatosMostrarImportados.Rows(index).Item("Día Festivo").ToString()

                '        For index2 As Integer = 0 To dgVDatos.RowCount - 1
                '            Dim fechaCal = dgVDatos.GetRowCellValue(index2, "Fecha").ToString()

                '            If fechaImp = fechaCal Then
                '                dgVDatos.SetRowCellValue(index2, "¿Es Laborable?", eslaborable)
                '                dgVDatos.SetRowCellValue(index2, "Día Festivo", diaFestivo)
                '            End If

                '        Next
                '    Next
                'End If

                If dtDatosMostrarImportados.Rows.Count > 0 - 1 Then
                    For index As Integer = 0 To dtDatosMostrarImportados.Rows.Count - 1
                        Dim fechaImp = dtDatosMostrarImportados.Rows(index).Item("Fecha").ToString
                        Dim eslaborable = dtDatosMostrarImportados.Rows(index).Item("¿Es Laborable?").ToString()
                        Dim diaFestivo = dtDatosMostrarImportados.Rows(index).Item("Día Festivo").ToString()

                        Dim query = (From q In tblCalendario.AsEnumerable
                                     Where q.Field(Of Date)("Fecha") = fechaImp
                                     Select q).SingleOrDefault()
                        query.Item("¿Es Laborable?") = eslaborable
                        query.Item("Día Festivo") = diaFestivo


                        'Dim prueba = tblCalendario.AsEnumerable().Where(Function(x) x.Item("Fecha") = fechaImp).Single()

                    Next
                End If
                dgDatos.DataSource = tblCalendario

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

    Private Sub dgVDatos_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles dgVDatos.CustomDrawRowIndicator
        If (e.RowHandle >= 0) Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub

End Class