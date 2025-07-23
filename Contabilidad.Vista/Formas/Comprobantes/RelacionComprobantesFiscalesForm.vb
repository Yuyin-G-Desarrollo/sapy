Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports Infragistics.Win
Imports System.Windows.Forms
Imports System.IO
Imports System.Xml
Imports Tools

Public Class RelacionComprobantesFiscalesForm

    Public Archivos As New Entidades.ColaboradorExpediente
    Public tipo_busqueda As Integer
    Public fechaInicio As Date
    Public fechaFin As Date
    Public empresaID As String
    Dim Poliza As New Entidades.Polizas
    Dim RutaArchivoXML As String
    Dim lista_Comprobantes As New DataTable



    Private Sub RelacionComprobantesFiscalesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        poblar_gridRelacionarComprobantesFiscales()
    End Sub

    'ETIQUETADO ETIQUETADO
    Public Sub poblar_gridRelacionarComprobantesFiscales()

        gridRelacionarComprobantesFiscales.DataSource = Nothing
        Dim objBU As New Negocios.AltaPolizaBU
        If tipo_busqueda = 1 Then
            lista_Comprobantes = objBU.buscaDocumentosSinXML_Transferencias(fechaInicio, fechaFin, empresaID)
        End If
        If tipo_busqueda = 2 Then
            lista_Comprobantes = objBU.CargaComprasSinComprobante(fechaInicio, fechaFin, empresaID)
        End If
        'lista_Comprobantes = objBU.buscaDocumentosSinXML_Transferencias(fechaInicio, fechaFin, empresaID)
        lista_Comprobantes.Columns.Add(" ")
        lista_Comprobantes.Columns.Add("RutaArchivos")
        gridRelacionarComprobantesFiscales.DataSource = lista_Comprobantes

        gridRelacionarComprobantesFiscalesDiseno(gridRelacionarComprobantesFiscales)

    End Sub

    Private Sub gridRelacionarComprobantesFiscalesDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col As UltraGridColumn In grid.DisplayLayout.Bands(0).Columns
            col.Hidden = True
            col.CellActivation = Activation.NoEdit
        Next

        grid.DisplayLayout.Bands(0).Columns("Folio").Hidden = False
        grid.DisplayLayout.Bands(0).Columns("Fecha").Hidden = False
        grid.DisplayLayout.Bands(0).Columns("Fecha").MaskInput = "dd/mm/yyyy"
        grid.DisplayLayout.Bands(0).Columns("Tipo Documento").Hidden = False
        grid.DisplayLayout.Bands(0).Columns("RFC").Hidden = False
        grid.DisplayLayout.Bands(0).Columns("Razon Social").Hidden = False
        grid.DisplayLayout.Bands(0).Columns("Total").Hidden = False
        grid.DisplayLayout.Bands(0).Columns("Total").Format = "N2"
        grid.DisplayLayout.Bands(0).Columns("Total").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("UUID").Hidden = False
        grid.DisplayLayout.Bands(0).Columns("XML").Hidden = False
        grid.DisplayLayout.Bands(0).Columns("XML").Style = UltraWinGrid.ColumnStyle.Default
        'grid.DisplayLayout.Bands(0).Columns("XML").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
        grid.DisplayLayout.Bands(0).Columns("PDF").Hidden = False
        grid.DisplayLayout.Bands(0).Columns("PDF").Style = UltraWinGrid.ColumnStyle.Default
        'grid.DisplayLayout.Bands(0).Columns("PDF").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
        grid.DisplayLayout.Bands(0).Columns(" ").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns(" ").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always

        With grid.DisplayLayout
            .Bands(0).Columns(0).Hidden = True
            .Bands(0).Columns(1).FilterOperandStyle = FilterOperandStyle.Combo
            .Bands(0).Columns(2).FilterOperandStyle = FilterOperandStyle.Combo
            .Bands(0).Columns(3).FilterOperandStyle = FilterOperandStyle.Combo
            .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectors = DefaultableBoolean.True
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.FilterUIType = FilterUIType.FilterRow
            .Override.AllowAddNew = AllowAddNew.No
        End With

        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

    End Sub

    Private Sub gridRelacionarComprobantesFiscales_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridRelacionarComprobantesFiscales.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    'metodo Vale
    'Private Sub gridRelacionarComprobantesFiscales_ClickCellButton(sender As Object, e As CellEventArgs) Handles gridRelacionarComprobantesFiscales.ClickCellButton

    '    'Dim objBU As New Negocios.VentasPoliticasBU
    '    Dim row As UltraGridRow = gridRelacionarComprobantesFiscales.ActiveRow
    '    If IsNothing(row) Then Return

    '    Dim ruta As String
    '    If e.Cell.Column.ToString.Equals("XML") Then
    '        ofdComprobantesFiscales.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Recent)
    '        ofdComprobantesFiscales.Filter = "XML|*.xml"
    '        ofdComprobantesFiscales.Filter = "XML|*.xml"
    '        ofdComprobantesFiscales.FilterIndex = 3
    '        If ofdComprobantesFiscales.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '            ruta = ofdComprobantesFiscales.FileName

    '            Dim archivo() As String
    '            archivo = Split(ruta, "\")

    '            For n = 0 To UBound(archivo, 1)
    '                If UBound(archivo) = n Then
    '                    Archivos.PNombreArchivo = archivo(n)
    '                End If
    '            Next


    '            Poliza = extraerUUID(ruta)

    '            Dim RutaArchivo As String = CStr(row.Cells("ruta").Value) + Poliza.Pfecha.Month.ToString + Poliza.Pfecha.Year.ToString

    '            If Not Directory.Exists(RutaArchivo) Then
    '                System.IO.Directory.CreateDirectory(RutaArchivo)
    '            End If
    '            RutaArchivo = RutaArchivo + "\" + Poliza.Puuid + ".xml"
    '            RutaArchivoXML = RutaArchivo
    '            row.Cells("RutaArchivos").Value = RutaArchivoXML
    '            Try
    '                File.Copy(Path.Combine(ruta), Path.Combine(RutaArchivo))
    '            Catch copyError As IOException
    '                Console.WriteLine(copyError.Message)
    '            End Try

    '            row.Cells(8).Value = Poliza.Puuid
    '            row.Cells(9).Value = Poliza.Puuid + ".xml"
    '            row.Cells(9).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default

    '        End If

    '    End If

    '    If row.Cells("XML").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default Then
    '        If e.Cell.Column.ToString.Equals("PDF") Then
    '            ofdComprobantesFiscales.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Recent)
    '            ofdComprobantesFiscales.Filter = "PDF|*.pdf" ', DOC, DOCX, XLS, XLSX, PNG, GIF|*.pdf;*.jpg; *.doc; *.docx;*.xls; *.png;*.gif"
    '            ofdComprobantesFiscales.Filter = "PDF|*.pdf"
    '            ofdComprobantesFiscales.FilterIndex = 3
    '            ofdComprobantesFiscales.ShowDialog()
    '            ruta = ofdComprobantesFiscales.FileName

    '            Dim archivo() As String
    '            archivo = Split(ruta, "\")

    '            For n = 0 To UBound(archivo, 1)

    '                If UBound(archivo) = n Then
    '                    Archivos.PNombreArchivo = archivo(n)

    '                End If

    '            Next

    '            Dim RutaArchivo As String = CStr(row.Cells("ruta").Value) + Poliza.Pfecha.Month.ToString + Poliza.Pfecha.Year.ToString

    '            If Not Directory.Exists(RutaArchivo) Then
    '                System.IO.Directory.CreateDirectory(RutaArchivo)
    '            End If
    '            RutaArchivo = RutaArchivo + "\" + Poliza.Puuid + ".pdf"
    '            Try
    '                File.Copy(Path.Combine(ruta), Path.Combine(RutaArchivo))
    '            Catch copyError As IOException
    '                Console.WriteLine(copyError.Message)
    '            End Try

    '            row.Cells("PDF").Value = Poliza.Puuid + ".pdf"
    '            row.Cells("PDF").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default
    '        End If
    '        If Not IsNothing(row.Cells("UUID").Value.ToString) Then
    '            If e.Cell.Column.ToString.Equals(" ") Then
    '                Dim objBU As New Negocios.ComprobantesFiscalesBU

    '                Dim cfdIdNave As Integer = CInt(row.Cells("Nave").Value)
    '                Dim IdEmpresa As Integer = CInt(row.Cells("EmpresaId").Value)
    '                Dim RfcEmpresa As String = CStr(row.Cells("RFCEmpresa").Value).Replace("-", "")
    '                Dim RfcProveedor As String = CStr(row.Cells("RFC").Value).Replace("-", "")
    '                Dim IdProveedor As Integer = CInt(row.Cells("IdProveedor").Value)
    '                Dim Fecha As DateTime = Poliza.Pfecha.ToShortDateString
    '                Dim Version As String = "3.2"
    '                Dim Serie As String = String.Empty
    '                If Not IsNothing(Poliza.Pserie) Then
    '                    Serie = Poliza.Pserie
    '                End If
    '                Dim Folio As String = Poliza.Pfolio
    '                Dim Total As Decimal = CDec(row.Cells("Total").Value)
    '                Dim RutaXml As String = RutaArchivoXML
    '                Dim RutaVisor As String = String.Empty
    '                If Not String.IsNullOrEmpty(row.Cells("PDF").Value.ToString) Then
    '                    RutaVisor = RutaArchivoXML.Replace(".xml", ".pdf")
    '                End If
    '                Dim Estatus As String = "A"
    '                Dim IdTabla As Integer = CInt(row.Cells("IDTABLA").Value)
    '                Try
    '                    objBU.Alta_archivos_XML_CFDS(cfdIdNave, IdEmpresa, RfcEmpresa, RfcProveedor, IdProveedor, Fecha, Version, Serie, Folio, Total, RutaXml, RutaVisor, Estatus, IdTabla)
    '                    show_message("Exito", "Se registró el archivo XML correctamente. Ahora puede agregar el archivo PDF.")
    '                    row.Cells("XML").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default
    '                    row.Cells("PDF").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default
    '                    row.Cells(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default
    '                    row.Cells(" ").Value = "Guardado"
    '                    row.Appearance.BackColor = Color.LimeGreen
    '                    RutaArchivoXML = String.Empty
    '                Catch ex As Exception
    '                    show_message("Error", "Algo surgió mal durante la operación")
    '                End Try

    '            End If
    '        End If
    '    Else
    '        show_message("Aviso", "Debe seleccionar un archivo XML primero")
    '    End If

    '    Dim width As Integer
    '    For Each col As UltraGridColumn In gridRelacionarComprobantesFiscales.Rows.Band.Columns
    '        If Not col.Hidden Then
    '            width += col.Width
    '        End If
    '    Next

    '    If width > gridRelacionarComprobantesFiscales.Width Then
    '        gridRelacionarComprobantesFiscales.DisplayLayout.AutoFitStyle = AutoFitStyle.None
    '    Else
    '        gridRelacionarComprobantesFiscales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    '    End If

    'End Sub

    'Private Sub gridRelacionarComprobantesFiscales_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridRelacionarComprobantesFiscales.KeyPress

    '    If e.KeyChar = ChrW(Keys.Enter) Then

    '        If IsNothing(gridRelacionarComprobantesFiscales.ActiveRow) Then Return

    '        Dim NextRowIndex As Integer = gridRelacionarComprobantesFiscales.ActiveRow.Index + 1
    '        Try
    '            gridRelacionarComprobantesFiscales.DisplayLayout.Rows(NextRowIndex).Activated = True
    '            gridRelacionarComprobantesFiscales.DisplayLayout.Rows(NextRowIndex).Selected = True
    '        Catch ex As Exception
    '            gridRelacionarComprobantesFiscales.ActiveRow.Activated = False
    '        End Try

    '    End If

    '    If e.KeyChar = ChrW(Keys.Escape) Then

    '        poblar_gridRelacionarComprobantesFiscales()
    '        gridRelacionarComprobantesFiscales.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '    End If

    'End Sub

    Private Sub gridRelacionarComprobantesFiscales_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gridRelacionarComprobantesFiscales.MouseDoubleClick
        Try
            Dim row As UltraGridRow = gridRelacionarComprobantesFiscales.ActiveRow
            If Not String.IsNullOrEmpty(row.Cells("XML").Value.ToString) Then

                Dim ruta As String = CStr(row.Cells("XML").Value)
                Process.Start(ruta)
                If Not String.IsNullOrEmpty(row.Cells("PDF").Value.ToString) Then
                    ruta = row.Cells("PDF").Value.ToString
                    Process.Start(ruta)
                End If
           
        'Else
        '    For Each fila In gridRelacionarComprobantesFiscales.Rows
        '        If Not fila.Cells(" ").Value.ToString.Equals("Guardar") Then
        '            row.Cells("XML").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        '            row.Cells("XML").Appearance.Image = My.Resources.xml_32
        '            row.Cells("XML").ButtonAppearance.Image = My.Resources.agregar_simple
        '            row.Cells("XML").ButtonAppearance.ImageHAlign = HAlign.Center
        '            row.Cells("XML").ButtonAppearance.ImageVAlign = VAlign.Middle
        '            row.Cells("PDF").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        '            row.Cells("PDF").ButtonAppearance.Image = My.Resources.agregar_simple
        '            row.Cells("PDF").ButtonAppearance.ImageHAlign = HAlign.Center
        '            row.Cells("PDF").ButtonAppearance.ImageVAlign = VAlign.Middle
        '            row.Cells(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        '            row.Cells(" ").Value = "Guardar"
        '            row.Activation = Activation.AllowEdit
        '        Else
        '            If Not fila.Index = row.Index Then
        '                show_message("Aviso", "Aun hay cambios pendientes en la fila " + CStr(fila.Index + 1))
        '                row.Cells("XML").Style = UltraWinGrid.ColumnStyle.Default
        '                row.Cells("PDF").Style = UltraWinGrid.ColumnStyle.Default
        '                row.Cells(" ").Style = UltraWinGrid.ColumnStyle.Default
        '                row.Cells(" ").Value = " "
        '                row.Activation = Activation.AllowEdit
        '                Exit Sub
        '            End If
        '        End If
        '    Next

            End If
        Catch ex As Exception

        End Try

    End Sub

    'Private Sub gridRelacionarComprobantesFiscales_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridRelacionarComprobantesFiscales.BeforeExitEditMode
    '    Try
    '        Dim cellIndex As Integer = gridRelacionarComprobantesFiscales.ActiveCell.Column.Index

    '        If gridRelacionarComprobantesFiscales.ActiveRow.DataChanged Then

    '        Else
    '            If gridRelacionarComprobantesFiscales.ActiveCell.DataChanged Then
    '            Else
    '                If String.IsNullOrWhiteSpace(gridRelacionarComprobantesFiscales.ActiveCell.Value) Then
    '                    gridRelacionarComprobantesFiscales.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '                End If
    '            End If

    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Private Sub gridRelacionarComprobantesFiscales_AfterRowActivate(sender As Object, e As EventArgs) Handles gridRelacionarComprobantesFiscales.AfterRowActivate
    '    gridRelacionarComprobantesFiscales.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '    For Each row In gridRelacionarComprobantesFiscales.Rows
    '        row.Activation = Activation.NoEdit
    '    Next
    'End Sub

    'Private Sub gridRelacionarComprobantesFiscales_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridRelacionarComprobantesFiscales.BeforeRowDeactivate

    '    gridRelacionarComprobantesFiscales.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

    'End Sub

    Public Function extraerUUID(ByVal Ruta As String) As Entidades.Polizas

        Dim reader As XmlTextReader = New XmlTextReader(Ruta)
        Dim lista As New Entidades.Polizas

        Try
            Do While (reader.Read())

                Select Case reader.NodeType
                    Case XmlNodeType.Element 'Mostrar comienzo del elemento.                    
                        If reader.HasAttributes Then 'If attributes exist
                            While reader.MoveToNextAttribute()
                                If reader.Name.ToUpper = "UUID" Then
                                    lista.Puuid = reader.Value
                                End If

                                If reader.Name.ToLower = "serie" Then
                                    lista.Pserie = reader.Value
                                End If

                                If reader.Name.ToLower = "folio" Then
                                    lista.Pfolio = reader.Value
                                End If

                                If reader.Name.ToLower = "fecha" Then
                                    lista.Pfecha = reader.Value
                                End If

                            End While
                        End If
                End Select
            Loop
        Catch ex As Exception
            show_message("Error", ex.ToString)
        End Try
        Return lista
        reader.Close()
    End Function

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Function ChecaLetras(ByVal StringToCheck As String) As String

        Dim strLetras As String = String.Empty
        For i = 0 To StringToCheck.Length - 1
            If Char.IsLetter(StringToCheck.Chars(i)) Then
                strLetras += StringToCheck.Chars(i)
            End If
        Next

        Return strLetras

    End Function

    Function ChecaNumeros(ByVal StringToCheck As String) As String

        Dim strNumeros As String = String.Empty
        For i = 0 To StringToCheck.Length - 1
            If Not Char.IsLetter(StringToCheck.Chars(i)) Then
                strNumeros += StringToCheck.Chars(i)
            End If
        Next

        Return strNumeros

    End Function

    Private Sub btnXml_Click(sender As Object, e As EventArgs) Handles btnXml.Click

        Dim row As UltraGridRow = gridRelacionarComprobantesFiscales.ActiveRow
        If String.IsNullOrEmpty(row.Cells("XML").Value.ToString) Then
            ofdComprobantesFiscales.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Recent)
            ofdComprobantesFiscales.Filter = "XML|*.xml"
            ofdComprobantesFiscales.Filter = "XML|*.xml"
            ofdComprobantesFiscales.FilterIndex = 3
            Dim ruta As String

            If ofdComprobantesFiscales.ShowDialog() = Windows.Forms.DialogResult.OK Then

                Dim pregunta As New ConfirmarForm
                pregunta.mensaje = "¿Está seguro que el archivo seleccionado es correcto? Posteriormente no podrá realizar cambios."
                If pregunta.ShowDialog = Windows.Forms.DialogResult.OK Then

                    ruta = ofdComprobantesFiscales.FileName

                    Dim archivo() As String
                    archivo = Split(ruta, "\")

                    For n = 0 To UBound(archivo, 1)
                        If UBound(archivo) = n Then
                            Archivos.PNombreArchivo = archivo(n)
                        End If
                    Next

                    Poliza = extraerUUID(ruta)

                    Dim RutaArchivo As String = CStr(row.Cells("ruta").Value) + Poliza.Pfecha.Month.ToString + Poliza.Pfecha.Year.ToString

                    If Not Directory.Exists(RutaArchivo) Then
                        System.IO.Directory.CreateDirectory(RutaArchivo)
                    End If

                    RutaArchivo = RutaArchivo + "\" + Poliza.Puuid + ".xml"
                    RutaArchivoXML = RutaArchivo
                    row.Cells("RutaArchivos").Value = RutaArchivoXML
                    Try
                        File.Copy(Path.Combine(ruta), Path.Combine(RutaArchivo))
                    Catch copyError As IOException
                        show_message("Advertencia", "Ocurrió un error al copiar el archivo. Consulte este error con el área de TI: Verificar permisos en carpeta de comprobantes de compra." + copyError.Message)
                        Exit Sub
                    End Try

                    row.Cells(8).Value = Poliza.Puuid 'nombre del uuid
                    row.Cells(9).Value = Poliza.Puuid + ".xml" 'ruta del xml
                    row.Cells(9).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default

                    If Not IsNothing(row.Cells("UUID").Value.ToString) Then
                        Dim objBU As New Negocios.ComprobantesFiscalesBU

                        Dim cfdIdNave As Integer = CInt(row.Cells("Nave").Value)
                        Dim IdEmpresa As Integer = CInt(row.Cells("EmpresaId").Value)
                        Dim RfcEmpresa As String = CStr(row.Cells("RFCEmpresa").Value).Replace("-", "")
                        Dim RfcProveedor As String = CStr(row.Cells("RFC").Value).Replace("-", "")
                        Dim IdProveedor As Integer = CInt(row.Cells("IdProveedor").Value)
                        Dim Fecha As DateTime = Poliza.Pfecha.ToShortDateString
                        Dim Version As String = "3.2"
                        Dim Serie As String = String.Empty
                        If Not IsNothing(Poliza.Pserie) Then
                            Serie = Poliza.Pserie
                        End If
                        Dim Folio As String = Poliza.Pfolio
                        Dim Total As Decimal = CDec(row.Cells("Total").Value)
                        Dim RutaXml As String = RutaArchivoXML
                        Dim RutaVisor As String = String.Empty
                        
                        Dim Estatus As String = "A"
                        Dim IdTabla As Integer = CInt(row.Cells("IDTABLA").Value)
                        Try
                            objBU.Alta_archivos_XML_CFDS(cfdIdNave, IdEmpresa, RfcEmpresa, RfcProveedor, IdProveedor, Fecha, Version, Serie, Folio, Total, RutaXml, RutaVisor, Estatus, IdTabla)
                            show_message("Exito", "Se guardó el archivo XML correctamente, ahora puede agregar el archivo PDF.")
                            row.Cells("XML").Value = RutaXml
                           
                            row.Appearance.BackColor = Color.LimeGreen
                            RutaArchivoXML = String.Empty
                        Catch ex As Exception
                            show_message("Error", "Algo surgió mal durante la operación")
                        End Try

                    End If
                Else
                    Exit Sub
                End If

            End If
        Else
            show_message("Advertencia", "Ya se agregó un archivo XML para este registro.")
        End If

    End Sub

    Private Sub btnPdf_Click(sender As Object, e As EventArgs) Handles btnPdf.Click

        Dim row As UltraGridRow = gridRelacionarComprobantesFiscales.ActiveRow
        If Not String.IsNullOrEmpty(row.Cells("XML").Value.ToString) Then
            If Not (row.Cells("UUID").Value.ToString = "") Then

                ofdComprobantesFiscales.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Recent)
                ofdComprobantesFiscales.Filter = "PDF|*.pdf"
                ofdComprobantesFiscales.Filter = "PDF|*.pdf"
                ofdComprobantesFiscales.FilterIndex = 3
                Dim ruta As String

                If ofdComprobantesFiscales.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    Dim pregunta As New ConfirmarForm
                    pregunta.mensaje = "¿Está seguro que el archivo seleccionado es correcto? Posteriormente no podrá realizar cambios."
                    If pregunta.ShowDialog = Windows.Forms.DialogResult.OK Then

                        ruta = ofdComprobantesFiscales.FileName

                        Dim archivo() As String
                        archivo = Split(ruta, "\")

                        For n = 0 To UBound(archivo, 1)
                            If UBound(archivo) = n Then
                                Archivos.PNombreArchivo = archivo(n)
                            End If
                        Next


                        'Poliza = extraerUUID(ruta)

                        Dim RutaArchivo As String = CStr(row.Cells("RutaArchivos").Value).Replace(".xml", ".pdf")

                        'If Not Directory.Exists(RutaArchivo) Then
                        '    System.IO.Directory.CreateDirectory(RutaArchivo)
                        'End If
                        'RutaArchivo = RutaArchivo + "\" + Poliza.Puuid + ".pdf"
                        'RutaArchivoXML = RutaArchivo
                        'row.Cells("RutaArchivos").Value = RutaArchivo
                        Try
                            File.Copy(Path.Combine(ruta), Path.Combine(RutaArchivo))
                        Catch copyError As IOException
                            show_message("Advertencia", "Ocurrió un error al copiar el archivo. Consulte este error con el área de TI: Verificar permisos en carpeta de comprobantes de compra.")
                        End Try

                        'row.Cells(8).Value = Poliza.Puuid
                        'row.Cells(9).Value = Poliza.Puuid + ".xml"
                        'row.Cells(9).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default

                        If Not IsNothing(row.Cells("UUID").Value.ToString) Then
                            'If e.Cell.Column.ToString.Equals(" ") Then
                            Dim objBU As New Negocios.ComprobantesFiscalesBU

                            'Dim cfdIdNave As Integer = CInt(row.Cells("Nave").Value)
                            'Dim IdEmpresa As Integer = CInt(row.Cells("EmpresaId").Value)
                            'Dim RfcEmpresa As String = CStr(row.Cells("RFCEmpresa").Value).Replace("-", "")
                            'Dim RfcProveedor As String = CStr(row.Cells("RFC").Value).Replace("-", "")
                            'Dim IdProveedor As Integer = CInt(row.Cells("IdProveedor").Value)
                            'Dim Fecha As DateTime = Poliza.Pfecha.ToShortDateString
                            'Dim Version As String = "3.2"
                            'Dim Serie As String = String.Empty
                            'If Not IsNothing(Poliza.Pserie) Then
                            '    Serie = Poliza.Pserie
                            'End If
                            'Dim Folio As String = Poliza.Pfolio
                            'Dim Total As Decimal = CDec(row.Cells("Total").Value)
                            'Dim RutaXml As String = RutaArchivoXML
                            Dim RutaVisor As String = RutaArchivo
                            'If Not String.IsNullOrEmpty(row.Cells("PDF").Value.ToString) Then
                            '    RutaVisor = RutaArchivoXML.Replace(".xml", ".pdf")
                            'End If
                            'Dim Estatus As String = "A"
                            Dim IdTabla As Integer = CInt(row.Cells("IDTABLA").Value)
                            Try
                                objBU.Actualiza_archivos_PDF_CFDS(RutaVisor, IdTabla)
                                show_message("Exito", "Se guardó el archivo PDF correctamente.")
                                row.Cells("PDF").Value = RutaVisor
                                'row.Cells("XML").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default
                                'row.Cells("PDF").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default
                                'row.Cells(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default
                                'row.Cells(" ").Value = "Guardado"
                                row.Appearance.BackColor = Color.LightGreen
                                RutaArchivoXML = String.Empty
                            Catch ex As Exception
                                show_message("Error", "Algo surgió mal durante la operación")
                            End Try

                        End If
                    End If

                End If
            Else
                show_message("Advertencia", "Ya se agregó un archivo PDF para este registro.")
            End If
        Else
            show_message("Advertencia", "Tiene que cargar primero el archivo XML.")

        End If

    End Sub

    Private Sub RelacionComprobantesFiscalesForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'MessageBox.Show("ahora")
        Dim pregunta As New ConfirmarForm
        Dim faltanPDF As Boolean = False
        Dim faltanXML As Boolean = False
        For Each row As UltraGridRow In gridRelacionarComprobantesFiscales.Rows
            'MessageBox.Show(row.Cells("Folio").Value.ToString)
            If String.IsNullOrEmpty(row.Cells("XML").Value.ToString) Then
                faltanXML = True
                pregunta.mensaje = "Aún tiene documentos sin XML ¿Está seguro que desea salir?"
                If pregunta.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Exit Sub
                Else
                    e.Cancel = True
                    Exit Sub
                End If
            End If
            If (Not String.IsNullOrEmpty(row.Cells("XML").Value.ToString) And (String.IsNullOrEmpty(row.Cells("PDF").Value.ToString))) Then
                pregunta.mensaje = "Aún tiene documentos sin PDF ¿Está seguro que desea salir? No podrá agregarlos posteriormente."
                If pregunta.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Exit Sub
                Else
                    e.Cancel = True
                End If
            End If
        Next

      
    End Sub
End Class