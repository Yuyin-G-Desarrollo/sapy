Imports System.Data.OleDb
Imports DevExpress.Export
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting

Public Class Excel
    ''' <summary>
    ''' Regresa el archivo excel convertido en un DataTable
    ''' </summary>
    ''' <param name="hoja"></param>
    ''' <param name="archivo"></param>
    ''' <param name="nombre_archivo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LlenarTablaExcelListaTablas(Optional hoja As String = "Datos", Optional archivo As String = "", Optional ByRef nombre_archivo As String = "") As DataTable
        Dim cnn As New OleDb.OleDbConnection
        LlenarTablaExcelListaTablas = New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim cmd As New OleDb.OleDbCommand

        Dim ofd As New OpenFileDialog
        ofd.Filter = "*.xlsx|*.xlsx|Excel|*.xls|Excel|*.xlsm"
        Dim file As String = ""

        If archivo <> "" Then
            file = archivo
        Else
            ofd.ShowDialog()
            If ofd.FileName.Length > 5 Then
                file = ofd.FileName
            Else

                cnn.Close()
                Exit Function
            End If
        End If

        nombre_archivo = file
        Dim hojas As String = hoja

        cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & file & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";" '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\brunoc\Desktop\Projects.accdb;Persist Security Info=False"
        cnn.Open()

        '-seleccionar hoja
        Dim dtSheets As DataTable =
              cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        Dim listSheet As New List(Of String)
        Dim dt As DataTable = cnn.GetSchema()
        Dim drSheet As DataRow
        Dim f_hoja As New Tools.SeleccionarHojaExcel

        Dim valor As Integer = 2
        Dim dtSheets2 As DataTable =
              cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})

        For Each drSheet In dtSheets.Rows
            If drSheet("TABLE_NAME").ToString().Contains("$") Then
                listSheet.Add(drSheet("TABLE_NAME").ToString())
                f_hoja.ComboBox1.Items.Add(drSheet("TABLE_NAME").ToString())
            End If
        Next
        f_hoja.StartPosition = FormStartPosition.CenterParent
        Try
            f_hoja.ComboBox1.SelectedIndex = 0
        Catch ex As Exception

        End Try
        f_hoja.ShowDialog()


        cmd.Connection = cnn
        cmd.CommandText = "SELECT * FROM [" & f_hoja.ComboBox1.Text & "]"
        cmd.CommandType = CommandType.Text

        da.SelectCommand = cmd
        da.Fill(LlenarTablaExcelListaTablas)

        Dim col As New DataColumn("Ok", System.Type.GetType("System.Boolean"))
        col.DefaultValue = False
        LlenarTablaExcelListaTablas.Columns.Add(col)

        Dim col_con As New DataColumn("Renglon", System.Type.GetType("System.Int32"))

        LlenarTablaExcelListaTablas.Columns.Add(col_con)

        Dim con As Int32 = 1
        For Each r As DataRow In LlenarTablaExcelListaTablas.Rows
            r("renglon") = con
            con += 1
        Next

        LlenarTablaExcelListaTablas.AcceptChanges()

        cnn.Close()

    End Function

    Public Shared Function LlenarTablaExcelInventarioSAP(Optional hoja As String = "", Optional archivo As String = "", Optional ByRef nombre_archivo As String = "") As DataTable
        Dim cnn As New OleDb.OleDbConnection
        LlenarTablaExcelInventarioSAP = New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim cmd As New OleDb.OleDbCommand

        Dim ofd As New OpenFileDialog
        ofd.Filter = "*.xlsx|*.xlsx|Excel|*.xls|Excel|*.xlsm"
        Dim file As String = String.Empty

        If archivo <> "" Then
            file = archivo
        Else
            ofd.ShowDialog()
            If ofd.FileName.Length > 5 Then
                file = ofd.FileName
            Else
                cnn.Close()
                LlenarTablaExcelInventarioSAP = Nothing

            End If
        End If
        nombre_archivo = file

        If nombre_archivo <> "" Then
            cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & file & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
            cnn.Open()

            Dim dtSheets As DataTable = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

            cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

            cmd.Connection = cnn
            cmd.CommandText = "SELECT * FROM [" & hoja & "]"
            cmd.CommandType = CommandType.Text

            da.SelectCommand = cmd
            da.Fill(LlenarTablaExcelInventarioSAP)


            LlenarTablaExcelInventarioSAP.AcceptChanges()

            cnn.Close()


        Else
            cnn.Close()
            LlenarTablaExcelInventarioSAP = Nothing
        End If

    End Function


    ''' <summary>
    ''' Regresa el archivo excel convertido en un DataTable
    ''' </summary>
    ''' <param name="hoja"></param>
    ''' <param name="archivo"></param>
    ''' <param name="nombre_archivo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LlenarTablaExcelListaTablasSinSeleccionarHoja(Optional hoja As String = "", Optional archivo As String = "", Optional ByRef nombre_archivo As String = "") As DataTable
        Dim cnn As New OleDb.OleDbConnection
        LlenarTablaExcelListaTablasSinSeleccionarHoja = New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim cmd As New OleDb.OleDbCommand

        Dim ofd As New OpenFileDialog
        ofd.Filter = "*.xlsx|*.xlsx|Excel|*.xls|Excel|*.xlsm"
        Dim file As String = ""

        If archivo <> "" Then
            file = archivo
        Else
            ofd.ShowDialog()
            If ofd.FileName.Length > 5 Then
                file = ofd.FileName
            Else

                cnn.Close()
                LlenarTablaExcelListaTablasSinSeleccionarHoja = Nothing
                Exit Function
            End If
        End If

        nombre_archivo = file
        If nombre_archivo.Contains("Proyeccion") Then
            Dim hojas As String = hoja

            ' abro la conexion
            cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & file & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";" '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\brunoc\Desktop\Projects.accdb;Persist Security Info=False"
            cnn.Open()
            '-seleccionar hoja
            Dim dtSheets As DataTable =
                  cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim listSheet As New List(Of String)
            Dim drSheet As DataRow
            If hoja = "" Then
                Dim f_hoja As New Tools.SeleccionarHojaExcel

                For Each drSheet In dtSheets.Rows
                    If drSheet("TABLE_NAME").ToString().Contains("$") Then
                        listSheet.Add(drSheet("TABLE_NAME").ToString())
                        f_hoja.ComboBox1.Items.Add(drSheet("TABLE_NAME").ToString())
                    End If
                Next
                f_hoja.StartPosition = FormStartPosition.CenterParent
                Try
                    f_hoja.ComboBox1.SelectedIndex = 0
                Catch ex As Exception

                End Try
                f_hoja.ShowDialog()
                hoja = f_hoja.ComboBox1.Text
            End If
            ' creo el comando y lo lleno con la tabla empleados
            cmd.Connection = cnn
            cmd.CommandText = "SELECT * FROM [" & hoja & "]"
            cmd.CommandType = CommandType.Text

            da.SelectCommand = cmd
            da.Fill(LlenarTablaExcelListaTablasSinSeleccionarHoja)


            LlenarTablaExcelListaTablasSinSeleccionarHoja.AcceptChanges()
            ' muestro los resultados en la datagridview
            cnn.Close()

            ' Return LlenarTablaExcelListaTablas()
        Else
            LlenarTablaExcelListaTablasSinSeleccionarHoja = Nothing
        End If
    End Function

    ''' <summary>
    ''' Regresa el archivo excel convertido en un DataTable !CONTROL ASISTENCIA!
    ''' </summary>
    ''' <param name="hoja"></param>
    ''' <param name="archivo"></param>
    ''' <param name="nombre_archivo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LlenarTablaExcelListaTablasSinSeleccionarHojaControlAsistencia(Optional hoja As String = "", Optional archivo As String = "", Optional ByRef nombre_archivo As String = "") As DataTable
        Dim cnn As New OleDb.OleDbConnection
        LlenarTablaExcelListaTablasSinSeleccionarHojaControlAsistencia = New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim cmd As New OleDb.OleDbCommand

        Dim ofd As New OpenFileDialog
        'ofd.Filter = "*.xlsm|*.xlsm|Excel|*.xlsx|Excel|*.xls"
        'ofd.Filter = "*.xls|*.xls|Excel|*.xlsx|Excel|*.xlsm"
        ofd.Filter = "*.xlsx|*.xlsx|Excel|*.xls|Excel|*.xlsm"
        Dim file As String = ""

        If archivo <> "" Then
            file = archivo
        Else
            ofd.ShowDialog()
            If ofd.FileName.Length > 5 Then
                file = ofd.FileName
            Else

                cnn.Close()
                LlenarTablaExcelListaTablasSinSeleccionarHojaControlAsistencia = Nothing
                Exit Function
            End If
        End If

        nombre_archivo = file
        If nombre_archivo.Contains("Asistencia") Then
            Dim hojas As String = hoja
            'If hoja <> "" Then
            '    hojas = hoja
            'Else
            '    hojas = InputBox("Nombre de la hoja:", "Hoja", hojas)
            'End If


            ' abro la conexion
            cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & file & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";" '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\brunoc\Desktop\Projects.accdb;Persist Security Info=False"
            cnn.Open()
            '-seleccionar hoja
            Dim dtSheets As DataTable =
                  cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim listSheet As New List(Of String)
            Dim drSheet As DataRow
            If hoja = "" Then
                Dim f_hoja As New Tools.SeleccionarHojaExcel

                For Each drSheet In dtSheets.Rows
                    If drSheet("TABLE_NAME").ToString().Contains("$") Then
                        listSheet.Add(drSheet("TABLE_NAME").ToString())
                        f_hoja.ComboBox1.Items.Add(drSheet("TABLE_NAME").ToString())
                    End If
                Next
                f_hoja.StartPosition = FormStartPosition.CenterParent
                Try
                    f_hoja.ComboBox1.SelectedIndex = 0
                Catch ex As Exception

                End Try
                f_hoja.ShowDialog()
                hoja = f_hoja.ComboBox1.Text
            End If
            ' creo el comando y lo lleno con la tabla empleados
            cmd.Connection = cnn
            cmd.CommandText = "SELECT * FROM [" & hoja & "]"
            cmd.CommandType = CommandType.Text

            da.SelectCommand = cmd
            da.Fill(LlenarTablaExcelListaTablasSinSeleccionarHojaControlAsistencia)


            LlenarTablaExcelListaTablasSinSeleccionarHojaControlAsistencia.AcceptChanges()
            ' muestro los resultados en la datagridview
            cnn.Close()

            ' Return LlenarTablaExcelListaTablas()
        Else
            LlenarTablaExcelListaTablasSinSeleccionarHojaControlAsistencia = Nothing
        End If
    End Function

    Public Shared Function LlenarTablaExcelListaTablasSinSeleccionarHojaControlAsistenciaFormatoNuevo(Optional hoja As String = "", Optional archivo As String = "", Optional ByRef nombre_archivo As String = "") As DataTable
        Dim cnn As New OleDb.OleDbConnection
        LlenarTablaExcelListaTablasSinSeleccionarHojaControlAsistenciaFormatoNuevo = New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim cmd As New OleDb.OleDbCommand

        Dim ofd As New OpenFileDialog
        'ofd.Filter = "*.xlsm|*.xlsm|Excel|*.xlsx|Excel|*.xls"
        'ofd.Filter = "*.xls|*.xls|Excel|*.xlsx|Excel|*.xlsm"
        ofd.Filter = "*.xlsx|*.xlsx|Excel|*.xls|Excel|*.xlsm"
        Dim file As String = ""

        If archivo <> "" Then
            file = archivo
        Else
            ofd.ShowDialog()
            If ofd.FileName.Length > 5 Then
                file = ofd.FileName
            Else

                cnn.Close()
                LlenarTablaExcelListaTablasSinSeleccionarHojaControlAsistenciaFormatoNuevo = Nothing
                Exit Function
            End If
        End If

        nombre_archivo = file
        If nombre_archivo.Contains("Informe") Then
            Dim hojas As String = hoja
            'If hoja <> "" Then
            '    hojas = hoja
            'Else
            '    hojas = InputBox("Nombre de la hoja:", "Hoja", hojas)
            'End If


            ' abro la conexion
            cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & file & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";" '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\brunoc\Desktop\Projects.accdb;Persist Security Info=False"
            cnn.Open()
            '-seleccionar hoja
            Dim dtSheets As DataTable =
                  cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim listSheet As New List(Of String)
            Dim drSheet As DataRow
            If hoja = "" Then
                Dim f_hoja As New Tools.SeleccionarHojaExcel

                For Each drSheet In dtSheets.Rows
                    If drSheet("TABLE_NAME").ToString().Contains("$") Then
                        listSheet.Add(drSheet("TABLE_NAME").ToString())
                        f_hoja.ComboBox1.Items.Add(drSheet("TABLE_NAME").ToString())
                    End If
                Next
                f_hoja.StartPosition = FormStartPosition.CenterParent
                Try
                    f_hoja.ComboBox1.SelectedIndex = 0
                Catch ex As Exception

                End Try
                f_hoja.ShowDialog()
                hoja = f_hoja.ComboBox1.Text
            End If
            ' creo el comando y lo lleno con la tabla empleados
            cmd.Connection = cnn
            cmd.CommandText = "SELECT * FROM [" & hoja & "]"
            cmd.CommandType = CommandType.Text

            da.SelectCommand = cmd
            da.Fill(LlenarTablaExcelListaTablasSinSeleccionarHojaControlAsistenciaFormatoNuevo)


            LlenarTablaExcelListaTablasSinSeleccionarHojaControlAsistenciaFormatoNuevo.AcceptChanges()
            ' muestro los resultados en la datagridview
            cnn.Close()

            ' Return LlenarTablaExcelListaTablas()
        Else
            LlenarTablaExcelListaTablasSinSeleccionarHojaControlAsistenciaFormatoNuevo = Nothing
        End If
    End Function


    Public Shared Sub ExportarExcel(ByVal grdVWReporteFolios As DevExpress.XtraGrid.Views.Grid.GridView, ByVal nombreReporte As String)
        Dim filename As String
        Try
            If grdVWReporteFolios.RowCount > 0 Then
                'Ask the user where to save the file to
                Dim SaveFileDialog As New SaveFileDialog()
                SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
                SaveFileDialog.FilterIndex = 2
                SaveFileDialog.RestoreDirectory = True

                SaveFileDialog.FileName = nombreReporte

                If SaveFileDialog.ShowDialog() = DialogResult.OK Then

                    'This is required so that excel doesn't make all the grids very small. This will export all grids space out evenly
                    grdVWReporteFolios.OptionsPrint.AutoWidth = True
                    grdVWReporteFolios.OptionsPrint.EnableAppearanceEvenRow = True
                    grdVWReporteFolios.OptionsPrint.PrintPreview = True
                    'Set the selected file as the filename
                    filename = SaveFileDialog.FileName

                    Dim exportOptions = New XlsxExportOptionsEx()
                    'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                    'Export the file via inbuild function
                    DevExpress.Export.ExportSettings.DefaultExportType = ExportType.Default
                    grdVWReporteFolios.ExportToXlsx(filename, exportOptions)

                    'If the file exists (i.e. export worked), then open it
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

        End Try

    End Sub

    Public Shared Function LlenarTablaExcelListaTablasSinSeleccionarHojaConfiguracionCalendario(Optional hoja As String = "", Optional archivo As String = "", Optional ByRef nombre_archivo As String = "") As DataTable
        Dim cnn As New OleDb.OleDbConnection
        LlenarTablaExcelListaTablasSinSeleccionarHojaConfiguracionCalendario = New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim cmd As New OleDb.OleDbCommand

        Dim ofd As New OpenFileDialog
        'ofd.Filter = "*.xlsm|*.xlsm|Excel|*.xlsx|Excel|*.xls"
        'ofd.Filter = "*.xls|*.xls|Excel|*.xlsx|Excel|*.xlsm"
        ofd.Filter = "*.xlsx|*.xlsx|Excel|*.xls|Excel|*.xlsm"
        Dim file As String = ""

        If archivo <> "" Then
            file = archivo
        Else
            ofd.ShowDialog()
            If ofd.FileName.Length > 5 Then
                file = ofd.FileName
            Else

                cnn.Close()
                LlenarTablaExcelListaTablasSinSeleccionarHojaConfiguracionCalendario = Nothing
                Exit Function
            End If
        End If

        nombre_archivo = file
        If file.Contains("Calendario") Then
            Dim hojas As String = hoja
            'If hoja <> "" Then
            '    hojas = hoja
            'Else
            '    hojas = InputBox("Nombre de la hoja:", "Hoja", hojas)
            'End If


            ' abro la conexion
            cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & file & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";" '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\brunoc\Desktop\Projects.accdb;Persist Security Info=False"
            cnn.Open()
            '-seleccionar hoja
            Dim dtSheets As DataTable =
                  cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim listSheet As New List(Of String)
            Dim drSheet As DataRow
            If hoja = "" Then
                Dim f_hoja As New Tools.SeleccionarHojaExcel

                For Each drSheet In dtSheets.Rows
                    If drSheet("TABLE_NAME").ToString().Contains("$") Then
                        listSheet.Add(drSheet("TABLE_NAME").ToString())
                        f_hoja.ComboBox1.Items.Add(drSheet("TABLE_NAME").ToString())
                    End If
                Next
                f_hoja.StartPosition = FormStartPosition.CenterParent
                Try
                    f_hoja.ComboBox1.SelectedIndex = 0
                Catch ex As Exception

                End Try
                f_hoja.ShowDialog()
                hoja = f_hoja.ComboBox1.Text
            End If
            ' creo el comando y lo lleno con la tabla empleados
            cmd.Connection = cnn
            cmd.CommandText = "SELECT * FROM [" & hoja & "]"
            cmd.CommandType = CommandType.Text

            da.SelectCommand = cmd
            da.Fill(LlenarTablaExcelListaTablasSinSeleccionarHojaConfiguracionCalendario)


            LlenarTablaExcelListaTablasSinSeleccionarHojaConfiguracionCalendario.AcceptChanges()
            ' muestro los resultados en la datagridview
            cnn.Close()

            ' Return LlenarTablaExcelListaTablas()
        Else
            LlenarTablaExcelListaTablasSinSeleccionarHojaConfiguracionCalendario = Nothing
        End If
    End Function

End Class
