Imports System.Data.OleDb
Imports Infragistics.Win.UltraWinGrid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.Export
Imports DevExpress.Export.Xl
Imports Infragistics.Documents.Excel

Public Class CargaBasesSimulacionForm

    Dim msjError As New Tools.AdvertenciaForm
    Dim msjExito As New Tools.ExitoForm
    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
        If uccFechaIni.Value >= uccFechaFin.Value Then
            'MessageBox.Show("La fecha fin debe ser mayor a la fecha inicio", "SAYERP")
            'MsgBox("La fecha fin debe ser mayor a la fecha inicio", MsgBoxStyle.Critical, "Atención")
            msjError.mensaje = "La fecha fin debe ser mayor a la fecha inicio"
            msjError.ShowDialog()
        End If
        grdBase.DataSource = Nothing
        ViewConsultaBaseSimula.Columns.Clear()
        opCargaExcel.Filter = "Excel Files|*.xlsx"
        If opCargaExcel.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim ruta, resultado As String
            Dim hojas, archivo As DataTable
            Dim objCargaBasesBU As Programacion.Negocios.CargaSimulacionBU = New Negocios.CargaSimulacionBU
            Dim tb As DataTable
            ruta = opCargaExcel.FileName
            txtArchivo.Text = opCargaExcel.FileName.ToString()
            resultado = ""
            txtLogErrores.Text = ""
            'hojas = obtenerHojasExcel(ruta)
            Try
                archivo = obtenerDatosHojaExcel2(ruta, "")
            Catch ex As Exception
                'Hoja1$
                archivo = obtenerDatosHojaExcel2(ruta, "Hoja1$")
            End Try
            If validaTabla(archivo) = False Then
                Try
                    archivo = obtenerDatosHojaExcel2(ruta, "Hoja1$")
                Catch ex As Exception
                    'Hoja1$
                    resultado = "El archivo no contiene información"
                End Try
            End If
            If validaTabla(archivo) = False Then
                resultado = "El archivo no contiene información"
                txtLogErrores.Text = resultado
                'MsgBox("Se encontraron errores en el archivo" & vbNewLine & "Consulte la pestaña de log de errores, verifique la información e intente nuevamente", MsgBoxStyle.Critical, "Atención")
                msjError.mensaje = "Se encontraron errores en el archivo" & vbNewLine & "Consulte la pestaña de log de errores, verifique la información e intente nuevamente"
                msjError.ShowDialog()
                'MessageBox.Show("Se encontraron errores en el archivo" & vbNewLine & "Consulte la pestaña de log de errores, verifique la información e intente nuevamente", "SAYERP")
                Exit Sub
            End If
            resultado = objCargaBasesBU.CargaSimulacionValidaLayout(archivo, cmbBase.SelectedValue)
            If resultado <> "" Then
                txtLogErrores.Text = resultado
                'MsgBox("Se encontraron errores en el archivo" & vbNewLine & "Consulte la pestaña de log de errores, verifique la información e intente nuevamente", MsgBoxStyle.Critical, "Atención")
                'MessageBox.Show("Se encontraron errores en el archivo" & vbNewLine & "Consulte la pestaña de log de errores, verifique la información e intente nuevamente", "SAYERP")
                msjError.mensaje = "Se encontraron errores en el archivo" & vbNewLine & "Consulte la pestaña de log de errores, verifique la información e intente nuevamente"
                msjError.ShowDialog()
                Exit Sub
            End If
            Select Case cmbBase.SelectedValue
                Case 1 'Horma
                    resultado = objCargaBasesBU.ValidarArchivo(archivo)
                    If resultado <> "" Then
                        txtLogErrores.Text = resultado
                        'MsgBox("Se encontraron errores en el archivo" & vbNewLine & "Consulte la pestaña de log de errores, verifique la información e intente nuevamente", MsgBoxStyle.Critical, "Atención")
                        'MessageBox.Show("Se encontraron errores en el archivo" & vbNewLine & "Consulte la pestaña de log de errores, verifique la información e intente nuevamente", "SAYERP")
                        msjError.mensaje = "Se encontraron errores en el archivo" & vbNewLine & "Consulte la pestaña de log de errores, verifique la información e intente nuevamente"
                        msjError.ShowDialog()
                        Exit Sub
                    End If

                    resultado = objCargaBasesBU.InsertarHomaNaveTallaBase(archivo, cmbBase.ValueMember, uccFechaIni.Value, uccFechaFin.Value)
                    If resultado = "" Then
                        tb = objCargaBasesBU.InsertarBaseSimulacion(uccFechaIni.Value, uccFechaFin.Value)
                        grdBase.DataSource = tb
                        ViewConsultaBaseSimula.Columns("hor_valnavasigna").Visible = False
                        resultado = objCargaBasesBU.ConsultaHomaNaveTallaBase()
                        If resultado <> "" Then
                            txtLogErrores.Text = resultado
                            'MsgBox("La carga se generó correctamente, pero existen registros cargados previamente" & vbNewLine & "Revise el Log de errores para mas información", MsgBoxStyle.Critical, "Atención")
                            msjExito.mensaje = "La carga se generó correctamente, pero existen registros cargados previamente" & vbNewLine & "Revise el Log de errores para mas información"
                            msjExito.ShowDialog()
                        Else
                            'MsgBox("La carga se generó correctamente", MsgBoxStyle.Critical, "Atención")
                            msjExito.mensaje = "La carga se generó correctamente"
                            msjExito.ShowDialog()
                        End If
                        'MessageBox.Show("La carga se generó correctamente", "SAYERP")
                    Else
                        txtLogErrores.Text = resultado
                        'MsgBox("Se encontraron errores en el archivo" & vbNewLine & "Consulte la pestaña de log de errores, verifique la información e intente nuevamente", MsgBoxStyle.Critical, "Atención")
                        msjError.mensaje = "Se encontraron errores en el archivo" & vbNewLine & "Consulte la pestaña de log de errores, verifique la información e intente nuevamente"
                        msjError.ShowDialog()
                    End If
                Case 2 'Talla
                    'MsgBox("Opción no habilitada aun", MsgBoxStyle.Critical, "Atención")
                    msjError.mensaje = "Opción no habilitada aun"
                    msjError.ShowDialog()
                    'MessageBox.Show("Opción no habilitada aun", "SAYERP")
                Case 3 'Suela
                    resultado = objCargaBasesBU.ValidarArchivoSuelaTalla(archivo)
                    If resultado <> "" Then
                        txtLogErrores.Text = resultado
                        'MsgBox("Se encontraron errores en el archivo" & vbNewLine & "Consulte la pestaña de log de errores, verifique la información e intente nuevamente", MsgBoxStyle.Critical, "Atención")
                        'MessageBox.Show("Se encontraron errores en el archivo" & vbNewLine & "Consulte la pestaña de log de errores, verifique la información e intente nuevamente", "SAYERP")
                        msjError.mensaje = "Se encontraron errores en el archivo" & vbNewLine & "Consulte la pestaña de log de errores, verifique la información e intente nuevamente"
                        msjError.ShowDialog()
                        Exit Sub
                    End If

                    resultado = objCargaBasesBU.InsertarSuelaTalla(archivo, cmbBase.ValueMember, uccFechaIni.Value, uccFechaFin.Value)
                    If resultado = "" Then
                        tb = objCargaBasesBU.InsertarSuelaBaseSimulacion(uccFechaIni.Value, uccFechaFin.Value)
                        grdBase.DataSource = tb
                        ViewConsultaBaseSimula.Columns("valnaveasigna").Visible = False
                        resultado = objCargaBasesBU.ConsultaDuplicadosSuelaTalla()
                        If resultado <> "" Then
                            txtLogErrores.Text = resultado
                            ' MsgBox("La carga se generó correctamente, pero existen registros cargados previamente" & vbNewLine & "Revise el Log de errores para mas información", MsgBoxStyle.Critical, "Atención")
                            msjExito.mensaje = "La carga se generó correctamente, pero existen registros cargados previamente" & vbNewLine & "Revise el Log de errores para mas información"
                            msjExito.ShowDialog()
                        Else
                            ' MsgBox("La carga se generó correctamente", MsgBoxStyle.Critical, "Atención")
                            msjExito.mensaje = "La carga se generó correctamente"
                            msjExito.ShowDialog()
                        End If

                        'MessageBox.Show("La carga se generó correctamente", "SAYERP")
                    Else
                        txtLogErrores.Text = resultado
                        'MsgBox("Se encontraron errores en el archivo" & vbNewLine & "Consulte la pestaña de log de errores, verifique la información e intente nuevamente", MsgBoxStyle.Critical, "Atención")
                        msjError.mensaje = "Se encontraron errores en el archivo" & vbNewLine & "Consulte la pestaña de log de errores, verifique la información e intente nuevamente"
                        msjError.ShowDialog()
                    End If
            End Select


        End If
    End Sub
    Private Function validaTabla(ByVal tabla As DataTable) As Boolean
        If tabla Is Nothing Then
            Return False
        End If
        If tabla.Rows Is Nothing Then
            Return False
        End If
        If tabla.Rows.Count = 0 Then
            Return False
        End If
        Return True
    End Function


    Private Sub CargaBasesSimulacionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargaComboCatalogo()
        uccFechaIni.Value = Today.Date
        uccFechaFin.Value = Today.Date.AddYears(1)

    End Sub

    Private Sub CargaComboCatalogo()
        Dim objCargaBasesBU As Programacion.Negocios.CargaSimulacionBU = New Negocios.CargaSimulacionBU
        Dim dtCatalogo As DataTable = objCargaBasesBU.CargaCatalogoBases()
        cmbBase.DataSource = dtCatalogo
        cmbBase.DisplayMember = "cbs_descripcion"
        cmbBase.ValueMember = "cbs_BaseId"
        objCargaBasesBU = Nothing
    End Sub
    Public Function obtenerHojasExcel(ByVal rutaExcel As String) As DataTable
        Dim cnn As New OleDb.OleDbConnection
        cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + rutaExcel + ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
        cnn.Open()
        Dim dtSheets As DataTable = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        cnn.Close()
        Return dtSheets
    End Function
    'Public Function obtenerDatosHojaExcel(ByVal rutaExcel As String, ByVal hoja As String) As DataTable
    '    Dim cnn As New OleDb.OleDbConnection
    '    Dim cmd As New OleDb.OleDbCommand
    '    Dim da As New OleDb.OleDbDataAdapter
    '    Dim datos As New DataTable
    '    cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + rutaExcel + ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
    '    cnn.Open()
    '    cmd.Connection = cnn
    '    cmd.CommandText = "SELECT * FROM [" + hoja + "]"
    '    cmd.CommandType = CommandType.Text
    '    da.SelectCommand = cmd
    '    da.Fill(datos)
    '    cnn.Close()
    '    Return datos
    'End Function
    Public Function obtenerDatosHojaExcel2(ByVal rutaExcel As String, ByVal hoja As String) As DataTable
        Dim table As New DataTable()
        Dim theWorkbook As Workbook



        'Load the Excel File into the Workbook Object

        theWorkbook = Workbook.Load(rutaExcel)

        'We will only work with the first Worksheet in the Workbook
        Dim theWorksheet As Worksheet = theWorkbook.Worksheets(0)


        Dim FirstDataRow As Integer = -1

        For Each reg As WorksheetMergedCellsRegion In theWorksheet.MergedCellsRegions
            If reg.LastRow > FirstDataRow Then
                FirstDataRow = reg.LastRow
            End If
        Next

        For Each theWorksheetCell As WorksheetCell In theWorksheet.Rows(FirstDataRow + 2).Cells
            Dim theDataColumn As DataColumn = table.Columns.Add()
            If theWorksheetCell.Value IsNot Nothing Then
                If theWorksheetCell.Value.[GetType]() IsNot GetType(FormattedString) Then
                    theDataColumn.DataType = theWorksheetCell.Value.[GetType]()
                End If
            End If
            Dim colname As Object = theWorksheet.Rows(FirstDataRow + 1).Cells(theWorksheetCell.ColumnIndex).Value
            theDataColumn.ColumnName = If(colname IsNot Nothing, colname.ToString(), theDataColumn.ColumnName)
        Next

        For row As Integer = FirstDataRow + 2 To theWorksheet.Rows.Count() - 1
            Dim cells As New List(Of Object)()
            For Each theWorksheetCell As WorksheetCell In theWorksheet.Rows(row).Cells
                cells.Add(theWorksheetCell.Value)
            Next
            table.Rows.Add(cells.ToArray())
        Next
        Return table
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtLogErrores.Text = ""
        grdBase.DataSource = Nothing
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Dim tb As DataTable
        Dim objCargaBasesBU As Programacion.Negocios.CargaSimulacionBU = New Negocios.CargaSimulacionBU
        tb = objCargaBasesBU.ConsultarInformacionPeriodo(uccFechaIni.Value, uccFechaFin.Value, cmbBase.SelectedValue)
        grdBase.DataSource = tb
        If tb.Columns.Contains("hor_valnavasigna") Then
            ViewConsultaBaseSimula.Columns("hor_valnavasigna").Visible = False
        End If
        If tb.Columns.Contains("valnaveasigna") Then
            ViewConsultaBaseSimula.Columns("valnaveasigna").Visible = False
        End If
    End Sub

    Public Sub exportarExcel(ByVal grd As GridControl)
        Dim sfd As New SaveFileDialog
        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xlsx"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                ' Ensure that the data-aware export mode is enabled.
                ExportSettings.DefaultExportType = ExportType.DataAware
                ' Create a new object defining how a document is exported to the XLSX format.
                Dim options = New XlsxExportOptionsEx()
                options.ApplyFormattingToEntireColumn = DevExpress.Utils.DefaultBoolean.False
                'AddHandler options.AfterAddRow, AddressOf options_AfterAddRow
                AddHandler options.CustomizeCell, AddressOf options_CustomizeCell

                grd.ExportToXlsx(fileName, options)
                Process.Start(fileName)
                Me.Cursor = Cursors.Default

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                'MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
                msjError.mensaje = "El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre."
                msjError.ShowDialog()
            End Try
        End If
    End Sub
    'Private Sub options_AfterAddRow(ByVal e As AfterAddRowEventArgs)
    '    ' Merge cells in rows that correspond to the grid's group rows.
    '    If e.DataSourceRowIndex < 0 Then
    '        Dim tabla As DataTable
    '        tabla = grdBase.DataSource
    '        Dim intRow As Integer = e.DataSourceRowIndex
    '        If tabla.Columns.Contains("valnaveasigna") Then
    '            If tabla.Rows(intRow)("valnaveasigna").ToString() = "1" Or tabla.Rows(intRow)("valnaveasigna").ToString() = "Seleccionado" Or tabla.Rows(intRow)("valnaveasigna").ToString() = "True" Then

    '            End If
    '        End If
    '        If tabla.Columns.Contains("hor_valnavasigna") Then
    '            If tabla.Rows(intRow)("hor_valnavasigna").ToString() = "1" Or tabla.Rows(intRow)("hor_valnavasigna").ToString() = "Seleccionado" Or tabla.Rows(intRow)("hor_valnavasigna").ToString() = "True" Then

    '            End If
    '        End If

    '    End If
    'End Sub

    Private Sub options_CustomizeCell(ByVal e As CustomizeCellEventArgs)
        ' Substitute Boolean values within the Discontinued column by special symbols.
        Dim tabla As DataTable
        tabla = grdBase.DataSource
        Dim intRow As Integer = e.DataSourceRowIndex
        If intRow >= 0 Then
            If tabla.Columns.Contains("valnaveasigna") Then
                If tabla.Rows(intRow)("valnaveasigna").ToString() = "1" Or tabla.Rows(intRow)("valnaveasigna").ToString() = "Seleccionado" Or tabla.Rows(intRow)("valnaveasigna").ToString() = "True" Then

                    e.Handled = True
                    e.Formatting.BackColor = Color.Salmon

                End If
            End If
            If tabla.Columns.Contains("hor_valnavasigna") Then
                If tabla.Rows(intRow)("hor_valnavasigna").ToString() = "1" Or tabla.Rows(intRow)("hor_valnavasigna").ToString() = "Seleccionado" Or tabla.Rows(intRow)("hor_valnavasigna").ToString() = "True" Then

                    e.Handled = True
                    e.Formatting.BackColor = Color.Salmon

                End If
            End If
        End If

    End Sub
    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim dt As DataTable = Nothing
        dt = grdBase.DataSource
        If validaTabla(dt) Then
            exportarExcel(grdBase)
        Else
            'MsgBox("No existen datos a exportar", MsgBoxStyle.Critical, "Atención")
            msjError.mensaje = "No existen datos a exportar"
            msjError.ShowDialog()
        End If
    End Sub

    Private Sub ViewConsultaBaseSimula_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles ViewConsultaBaseSimula.RowStyle
        Dim View As GridView = sender
        Dim tablas As DataTable = grdBase.DataSource
        If validaTabla(tablas) Then
            If tablas.Columns.Contains("valnaveasigna") Then
                If (e.RowHandle >= 0) Then

                    Dim validacionNave As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("valnaveasigna"))
                    If validacionNave = "1" Or validacionNave = "Seleccionado" Or validacionNave = "True" Then
                        e.Appearance.BackColor = Color.Salmon
                        e.Appearance.BackColor2 = Color.SeaShell
                    End If
                End If
            Else
                If (e.RowHandle >= 0) Then

                    Dim validacionHorma As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("hor_valnavasigna"))
                    If validacionHorma = "1" Or validacionHorma = "Seleccionado" Or validacionHorma = "True" Then
                        e.Appearance.BackColor = Color.Salmon
                        e.Appearance.BackColor2 = Color.SeaShell
                    End If
                End If
            End If
        End If


    End Sub
End Class