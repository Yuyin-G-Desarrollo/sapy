Imports System.Data.OleDb
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Documents.Excel


Public Class AsignaEquivalenciaForm
    Dim msjError As New Tools.AdvertenciaForm
    Dim msjExito As New Tools.ExitoForm
    Dim objCargaEquivalenciaBU As New Programacion.Negocios.CargaEquivalenciaBU
    '1 = Consulta, 0 = Excel
    Dim tipoCarga As Integer
    Dim consultaGral As DataTable


    Private Sub AsignaEquivalenciaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarComboNaves()
    End Sub
    Private Sub CargarComboNaves()
        Dim objCargaSimulacion As New Programacion.Negocios.CargaEquivalenciaBU
        Dim dt As DataTable
        dt = objCargaSimulacion.CargaCatalogoNaveBases()
        If validaTabla(dt) Then
            cmbNave.DisplayMember = "nave_nombre"
            cmbNave.ValueMember = "nave_naveid"
            cmbNave.DataSource = dt
        Else
            msjError.mensaje = "No existen Naves disponibles"
            msjError.ShowDialog()
        End If
    End Sub

    Private Function validaTabla(ByVal tabla As DataTable) As Boolean
        Dim respuesta As Boolean = True
        If tabla Is Nothing Then
            respuesta = False
        Else
            If tabla.Rows Is Nothing Then
                respuesta = False
            Else
                If tabla.Rows.Count = 0 Then
                    respuesta = False
                Else
                    respuesta = True
                End If
            End If
        End If
        
        Return respuesta
    End Function

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtValEquivalencia.Text = ""
        grdProductosNuevos.DataSource = Nothing
        chkSeleccionarArts.Checked = False
        btnGuardar.Enabled = True
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        guardadoGeneral()
    End Sub
    Private Sub guardadoGeneral(Optional ByVal opcion As Integer = 0)
        Dim dt As DataTable
        dt = grdProductosNuevos.DataSource
        If validaTabla(dt) Then

            If dt.Select("Marcar = 1").Length > 0 Then
                Dim tb As DataTable
                tb = dt.Select("Marcar = 1").CopyToDataTable

                If objCargaEquivalenciaBU.GuardarEquivalencia(tb, tipoCarga, cmbNave.SelectedValue) Then
                    If opcion = 1 Then
                        msjExito.mensaje = "Se Guardo/Actualizo correctamente las equivalencias"
                        msjExito.ShowDialog()
                    Else
                        msjExito.mensaje = "Se Guardo/Actualizo correctamente las equivalencias"
                        msjExito.ShowDialog()
                        grdProductosNuevos.DataSource = Nothing
                    End If
                    
                Else
                    msjError.mensaje = "Ocurrio un error al Guardar/Actualizar equivalencias, puede que no toda la información se haya guardado"
                    msjError.ShowDialog()
                End If
            Else
                msjError.mensaje = "No existe información seleccionada"
                msjError.ShowDialog()
            End If

        Else
            msjError.mensaje = "No existe información para guardar"
            msjError.ShowDialog()
            Exit Sub
        End If
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click

        'msjError.mensaje = "La fecha fin debe ser mayor a la fecha inicio"
        'msjError.ShowDialog()
        btnGuardar.Enabled = True
        opCargaExcel.Filter = "Excel Files|*.xlsx;*.xls"
        If opCargaExcel.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim ruta, resultado As String
            Dim hojas, archivo As DataTable
            Dim rutaExcel As String
            Dim objCargaBasesBU As Programacion.Negocios.CargaSimulacionBU = New Negocios.CargaSimulacionBU

            ruta = opCargaExcel.FileName
            rutaExcel = opCargaExcel.FileName.ToString()
            resultado = ""

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

                msjError.mensaje = "Se encontraron errores en el archivo" & vbNewLine & "Consulte la pestaña de log de errores, verifique la información e intente nuevamente"
                msjError.ShowDialog()

                Exit Sub
            Else
                If Not objCargaEquivalenciaBU.ValidarLayout(archivo) Then
                    msjError.mensaje = "El archivo no tiene el formato correcto"
                    msjError.ShowDialog()
                    Exit Sub
                End If

                Dim validar As String = objCargaEquivalenciaBU.ValidarDuplicados(archivo)
                If validar <> "" Then
                    msjError.mensaje = validar
                    msjError.ShowDialog()
                    Exit Sub
                End If
                grdProductosNuevos.DataSource = archivo

                Dim validaciones As String = ""
                validaciones = objCargaEquivalenciaBU.ValidarColeccion(cmbNave.SelectedValue, archivo)
                If validaciones <> "" Then
                    btnGuardar.Enabled = False
                    msjError.mensaje = "El archivo contiene Colecciones invalidas:" & vbNewLine & validaciones
                    msjError.ShowDialog()
                    Exit Sub
                End If

                validaciones = objCargaEquivalenciaBU.ValidarMarcas(cmbNave.SelectedValue, archivo)
                If validaciones <> "" Then
                    btnGuardar.Enabled = False
                    msjError.mensaje = "El archivo contiene Marcas invalidas:" & vbNewLine & validaciones
                    msjError.ShowDialog()
                    Exit Sub
                End If

                validaciones = objCargaEquivalenciaBU.ValidarModelos(cmbNave.SelectedValue, archivo)
                If validaciones <> "" Then
                    btnGuardar.Enabled = False
                    msjError.mensaje = "El archivo contiene Modelos invalidos:" & vbNewLine & validaciones
                    msjError.ShowDialog()
                    Exit Sub
                End If

                validaciones = objCargaEquivalenciaBU.ValidarModelosSICY(cmbNave.SelectedValue, archivo)
                If validaciones <> "" Then
                    btnGuardar.Enabled = False
                    msjError.mensaje = "El archivo contiene Modelos SICY invalidos:" & vbNewLine & validaciones
                    msjError.ShowDialog()
                    Exit Sub
                End If

                validaciones = objCargaEquivalenciaBU.ValidarProductoEstilo(cmbNave.SelectedValue, archivo)
                If validaciones <> "" Then
                    btnGuardar.Enabled = False
                    msjError.mensaje = "El archivo contiene Productos invalidos:" & vbNewLine & validaciones
                    msjError.ShowDialog()
                    Exit Sub
                End If

                consultaGral = archivo
                tipoCarga = 0

            End If

        End If
    End Sub

    'Public Function obtenerHojasExcel(ByVal rutaExcel As String) As DataTable
    '    Dim cnn As New OleDb.OleDbConnection
    '    cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + rutaExcel + ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
    '    cnn.Open()
    '    Dim dtSheets As DataTable = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
    '    cnn.Close()
    '    Return dtSheets
    'End Function

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

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Dim tbEquivalencias As DataTable = Nothing
        tipoCarga = 1
        btnGuardar.Enabled = True
        If cmbNave.SelectedValue = Nothing Then
            msjError.mensaje = "Es necesario seleccionar campo de Nave"
            msjError.ShowDialog()
            Exit Sub
        End If
        If rbVigentes.Checked Then
            tbEquivalencias = objCargaEquivalenciaBU.ConsultaFactorEquivalencia(cmbNave.SelectedValue, 1)

        Else
            tbEquivalencias = objCargaEquivalenciaBU.ConsultaFactorEquivalencia(cmbNave.SelectedValue, 1)
        End If
        'Dim view As DataView = New DataView(tbEquivalencias)
        'Dim tbDistintos As DataTable = view.ToTable(True, "Marcar", "ModeloSICY", "Modelo", "Marca", "Coleccion", "Aplicaciones", "TipoProducto", "FechaInicioProduccion", "FechaFinProduccion", "FactorDeEquivalencia")
        If validaTabla(tbEquivalencias) Then
            grdProductosNuevos.DataSource = tbEquivalencias
        Else
            msjError.mensaje = "No se encontraron registros con los campos seleccionados"
            msjError.ShowDialog()
        End If
    End Sub

    Private Sub chkSeleccionarArts_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarArts.CheckedChanged
        Dim dtGrid As DataTable
        dtGrid = grdProductosNuevos.DataSource
        If validaTabla(dtGrid) Then
            If chkSeleccionarArts.Checked Then
                For Each row As DataRow In dtGrid.Rows
                    row("Marcar") = True
                Next
            Else
                For Each row As DataRow In dtGrid.Rows
                    row("Marcar") = False
                Next
            End If
        End If

    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim tbEquivalencias As DataTable = Nothing
        tipoCarga = 1
        If cmbNave.SelectedValue = Nothing Then
            msjError.mensaje = "Es necesario seleccionar campo de Nave"
            msjError.ShowDialog()
            Exit Sub
        End If
        If rbVigentes.Checked Then
            tbEquivalencias = objCargaEquivalenciaBU.ConsultaFactorEquivalenciaExport(cmbNave.SelectedValue, 1)

        Else
            tbEquivalencias = objCargaEquivalenciaBU.ConsultaFactorEquivalenciaExport(cmbNave.SelectedValue, 1)
        End If
        'Dim view As DataView = New DataView(tbEquivalencias)
        'Dim tbDistintos As DataTable = view.ToTable(True, "Marcar", "ModeloSICY", "Modelo", "Marca", "Coleccion", "Aplicaciones", "TipoProducto", "FechaInicioProduccion", "FechaFinProduccion", "FactorDeEquivalencia")
        If validaTabla(tbEquivalencias) Then
            grdExcel.DataSource = tbEquivalencias
        Else
            msjError.mensaje = "No se encontraron registros con los campos seleccionados"
            msjError.ShowDialog()
            Exit Sub
        End If
        ExportarGridAExcel()
    End Sub
    Private Sub ExportarGridAExcel()

        Dim sfd As New SaveFileDialog
        'sfd.DefaultExt = "xlsx"
        'sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"

        sfd.DefaultExt = "xls"
        sfd.Filter = "Excel Files|*.xls"

        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor

                exeExportar.Export(grdExcel, fileName)

                Dim objMensajeExito As New Tools.ExitoForm
                msjError.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                msjError.StartPosition = FormStartPosition.CenterScreen
                msjError.ShowDialog()
                Process.Start(fileName)
            Catch ex As Exception
                msjError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                msjError.StartPosition = FormStartPosition.CenterScreen
                msjError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub grdProductosNuevos_AfterCellUpdate(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdProductosNuevos.AfterCellUpdate
        If e.Cell.Column.Header.Caption = "FactorDeEquivalencia" Then
            Dim numero As Decimal = 0.0
            Try
                numero = Decimal.Parse(e.Cell.Value.ToString)
            Catch ex As Exception
                msjError.mensaje = "El Factor de equivalecia debe ser numérico"
                msjError.ShowDialog()
                e.Cell.CancelUpdate()
                Exit Sub
            End Try
            If numero >= 10 Then
                msjError.mensaje = "El Factor de Equivalencia no es valido, revise la información"
                msjError.ShowDialog()
                e.Cell.CancelUpdate()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub grdProductosNuevos_CellDataError(sender As Object, e As Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs) Handles grdProductosNuevos.CellDataError
        Dim grid As UltraGrid = CType(sender, UltraGrid)

        Dim celda As UltraGridCell = grid.ActiveCell
        If Not celda Is Nothing And celda.Column.Header.Caption = "FactorDeEquivalencia" Then
            e.RaiseErrorEvent = False
            msjError.mensaje = "El Factor de Equivalencia no es valido, revise la información"
            msjError.ShowDialog()
        End If

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim tabla As DataTable
        tabla = grdProductosNuevos.DataSource
        If validaTabla(tabla) Then
            If tabla.Select("Marcar = 1").Length > 0 Then
                Dim numero As Decimal = 0.0
                Try
                    numero = Decimal.Parse(txtValEquivalencia.Text)
                Catch ex As Exception
                    msjError.mensaje = "El Factor de equivalecia debe ser numérico"
                    msjError.ShowDialog()
                    Exit Sub
                End Try
                If numero >= 10 Then
                    msjError.mensaje = "El Factor de Equivalencia no es valido, revise la información"
                    msjError.ShowDialog()
                    Exit Sub
                End If
                For Each row As DataRow In tabla.Rows
                    If row("Marcar") = True Then
                        row("FactorDeEquivalencia") = numero
                    End If
                Next
                'Se agrega guardado al momento de actualizar
                guardadoGeneral(1)
                'msjExito.mensaje = "Se asigno la Equivalencia a los registros marcados"
                'msjExito.ShowDialog()
                txtValEquivalencia.Text = "0"
            Else
                msjError.mensaje = "No existen filas marcadas para asignar Factor de Equivalencia, revise la información"
                msjError.ShowDialog()
                Exit Sub
            End If
        Else
            msjError.mensaje = "No existen filas marcadas para asignar Factor de Equivalencia, revise la información"
            msjError.ShowDialog()
            Exit Sub
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class