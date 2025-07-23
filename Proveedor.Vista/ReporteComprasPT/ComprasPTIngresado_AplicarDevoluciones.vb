Imports System.Globalization
Imports System.IO
Imports System.Windows.Forms
Imports System.Xml
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports Tools

Public Class ComprasPTIngresado_AplicarDevoluciones
    Dim objBU As New Proveedores.BU.DevolucionesPreliminares_BU
    Dim blnCargaXML As Boolean = False
    Dim blnCargaPDF As Boolean = False
    Dim ArchivoPDF As String = String.Empty
    Dim ArchivoXML As String = String.Empty
    Dim EntXML As Entidades.DevComprasPT_XML

    Public devolucionId As Integer
    Public emisorId As Integer
    Public emisorRazSoc As String
    Public emisorRFC As String
    Public receptorId As Integer
    Public receptorRazSoc As String
    Public receptorRFC As String
    Public paresDevolucion As Integer
    Public totalDevolucion As Double
    Public esAplicacion As Boolean
    Public folioNC As String

    Private Sub ComprasPTIngresado_AplicarDevoluciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarInformacion()
    End Sub

    Private Sub cargarInformacion()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim dtResultado As New DataTable
            dtResultado = objBU.obtenerDetalleDevolucion(devolucionId)

            If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
                lblRazonSocialEmisor.Text = emisorRazSoc
                lblRFCEmisor.Text = emisorRFC
                lblRazonSocialReceptor.Text = receptorRazSoc
                lblRFCReceptor.Text = receptorRFC
                grdListado.DataSource = dtResultado
                DisenioGrid()
                lblRegistros.Text = dtResultado.Rows.Count.ToString("N0", CultureInfo.InvariantCulture)
                lblFolio.Text = folioNC

                lblNC.Visible = Not esAplicacion
                lblFolio.Visible = Not esAplicacion
                pnlXML.Visible = esAplicacion
                pnlPDF.Visible = esAplicacion
                pnlExportar.Visible = Not esAplicacion
                pnlGuardarDev.Visible = esAplicacion

                If esAplicacion Then
                    lblTitulo.Text = "Aplicar Devolución de Compra"
                Else
                    lblTitulo.Text = "Detalles Devolución"
                End If

            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No fue posible cargar la información de la devolución.")
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al consultar el detalle de la devolución: " & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub GvwListado_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles gvwListado.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub DisenioGrid()
        gvwListado.BestFitColumns()
        gvwListado.OptionsView.ColumnAutoWidth = True
        gvwListado.OptionsView.EnableAppearanceEvenRow = True
        gvwListado.IndicatorWidth = 30
        gvwListado.OptionsView.ShowAutoFilterRow = True
        gvwListado.OptionsView.RowAutoHeight = True

        gvwListado.Columns.ColumnByFieldName("DEVOLUCIONID").Visible = False

        gvwListado.Columns.ColumnByFieldName("PARES DEVUELTOS").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("PARES DEVUELTOS").DisplayFormat.FormatString = "N0"
        gvwListado.Columns.ColumnByFieldName("SUBTOTAL").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("SUBTOTAL").DisplayFormat.FormatString = "N2"
        gvwListado.Columns.ColumnByFieldName("IVA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("IVA").DisplayFormat.FormatString = "N2"
        gvwListado.Columns.ColumnByFieldName("TOTAL").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("TOTAL").DisplayFormat.FormatString = "N2"
        gvwListado.Columns.ColumnByFieldName("PRECIO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("PRECIO").DisplayFormat.FormatString = "N2"

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvwListado.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains

            If col.FieldName.Contains("SUBTOTAL") Or col.FieldName.Contains("IVA") Or col.FieldName.Contains("TOTAL") Or col.FieldName.Contains("PARES DEVUELTOS") Then
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "SUBTOTAL")) = True And col.FieldName = "SUBTOTAL" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "IVA")) = True And col.FieldName = "IVA" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "TOTAL")) = True And col.FieldName = "TOTAL" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
            End If
        Next
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Visible = True
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validarArchivos() Then
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim objMensajeConf As New Tools.ConfirmarForm With {
                    .mensaje = "¿Está seguro de aplicar la devolución? Este proceso no se podrá revertir."
                }
                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    If emisorId <> 0 Then
                        Dim dtRutasSICY As New DataTable
                        dtRutasSICY = objBU.obtenerRutasSICY_Emisor(emisorId)

                        If Not dtRutasSICY Is Nothing AndAlso dtRutasSICY.Rows.Count > 0 Then
                            Dim rutaSICY_XML As String = dtRutasSICY.Rows(0).Item(0)
                            Dim rutaSICY_PDF As String = dtRutasSICY.Rows(0).Item(1)
                            Dim dtResultado As New DataTable

                            Dim fechaCarpeta As String = String.Empty
                            fechaCarpeta = EntXML.PFechaTimbrado.ToString("MM") & EntXML.PFechaTimbrado.ToString("yyyy")

                            If CopiarArchivos(rutaSICY_PDF & fechaCarpeta, rutaSICY_XML & fechaCarpeta) Then
                                dtResultado = objBU.aplicarDevolucion(devolucionId, EntXML, Path.GetFileName(ArchivoXML), Path.GetFileName(ArchivoPDF))
                                If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
                                    If dtResultado.Rows(0).Item("mensaje").ToString = "EXITO" Then
                                        Try
                                            objBU.insertarRegistroDevolucionCompras(devolucionId)
                                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se actualizó correctamente el estatus de la devolución.")
                                        Catch ex As Exception
                                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Se actualizó correctamente el estatus de la devolución, pero ocurrió un error al insertar el registro en tarjeta de almacén favor de reportarlo a sistemas.")
                                        Finally
                                            Me.Cursor = Cursors.Default
                                        End Try
                                        Me.Close()
                                    Else
                                        Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió el siguiente error: " & dtResultado.Rows(0).Item("mensaje").ToString)
                                    End If
                                Else
                                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se pudo recuprerar el estatus de la devolución, favor de reportar a sistemas.")
                                End If
                            End If
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No fue posible obtener la ruta para guardar los archivos XML y PDF.")
                        End If
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se pudo obtener el RFC del emisor.")
                    End If
                End If
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió el siguiente error: " & ex.Message)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Function CopiarArchivos(ByVal rutaPDF As String, ByVal rutaXML As String) As Boolean
        Dim blnEnviado As Boolean = True
        Dim rutaArchivoPDF As String = String.Empty
        Dim rutaArchivoXML As String = String.Empty
        Try
            rutaArchivoPDF = rutaPDF & "\" & Path.GetFileName(ArchivoPDF)
            rutaArchivoXML = rutaXML & "\" & Path.GetFileName(ArchivoXML)

            CrearDirectorio(rutaArchivoPDF)
            File.Copy(ArchivoPDF, rutaArchivoPDF, True)
            CrearDirectorio(rutaArchivoXML)
            File.Copy(ArchivoXML, rutaArchivoXML, True)
        Catch ex As Exception
            blnEnviado = False
        End Try
        Return blnEnviado
    End Function

    Public Sub CrearDirectorio(ByVal Ruta As String)

        Dim DirectorioCliente As String = String.Empty
        Dim FileName As String = String.Empty
        Dim DirectoryName As String = String.Empty
        Try
            DirectorioCliente = Path.GetDirectoryName(Ruta)
            If System.IO.Directory.Exists(DirectorioCliente) = False Then
                System.IO.Directory.CreateDirectory(DirectorioCliente)
            End If
            FileName = Path.GetFileName(Ruta)
            DirectorioCliente &= FileName
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function validarArchivos() As Boolean
        Dim blnValidaDoctos As Boolean = True

        If ArchivoPDF.Trim = "" Or ArchivoPDF Is Nothing Then
            blnValidaDoctos = False
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se cargó correctamente el archivo PFD, favor de seleccionarlo nuevamente.")
        ElseIf EntXML Is Nothing Then
            blnValidaDoctos = False
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se cargó correctamente el archivo XML, favor de seleccionarlo nuevamente.")
        ElseIf objBU.validarExisteDevolucion(EntXML.PRFCEmisor, EntXML.PSerie, EntXML.PFolio, EntXML.PUUID) Then
            blnValidaDoctos = False
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El registro de la devolución ya se encuentra en el sistema, favor de validar.")
        End If

        Return blnValidaDoctos
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnXML_Click(sender As Object, e As EventArgs) Handles btnXML.Click
        Try

            cargarXML()

            'blnCargaXML = True
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al cargar el XML " & ex.Message)
        End Try
    End Sub

    Private Sub cargarXML()
        EntXML = Nothing
        OpenFileDialog1.Filter = "xml files (*.xml)|*.xml"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                If System.IO.Path.GetExtension(OpenFileDialog1.FileName).ToUpper = ".XML" Then
                    Me.Cursor = Cursors.WaitCursor
                    Dim reader As XmlTextReader = New XmlTextReader(OpenFileDialog1.FileName)
                    ArchivoXML = OpenFileDialog1.FileName
                    EntXML = New Entidades.DevComprasPT_XML
                    Dim serieXML As String = ""
                    Dim folioXML As Integer = 0
                    Dim totalXML As Double = 0
                    Dim rfcEmisorXML As String = ""
                    Dim rfcReceptorXML As String = ""
                    Dim uuidXML As String = ""
                    Dim fechaTimbradoXML As String = ""
                    Dim paresXML As Integer = 0
                    Dim monedaXML As String = ""

                    Do While (reader.Read())
                        If reader.Name = "cfdi:Comprobante" Or reader.Name.ToLower = "comprobante" Then
                            If reader.HasAttributes Then
                                While reader.MoveToNextAttribute()
                                    Select Case reader.Name.ToLower
                                        Case "serie"
                                            serieXML = reader.Value
                                        Case "folio"
                                            folioXML = reader.Value
                                        Case "total"
                                            totalXML = reader.Value
                                        Case "moneda"
                                            monedaXML = reader.Value
                                    End Select
                                End While
                            End If
                        End If
                        If reader.Name = "cfdi:Emisor" Or reader.Name.ToLower = "emisor" Then
                            If reader.HasAttributes Then
                                While reader.MoveToNextAttribute()
                                    If reader.Name.ToUpper = "RFC" Then
                                        rfcEmisorXML = reader.Value
                                    End If
                                End While
                            End If
                        End If
                        If reader.Name = "cfdi:Receptor" Or reader.Name.ToLower = "receptor" Then
                            If reader.HasAttributes Then
                                While reader.MoveToNextAttribute()
                                    If reader.Name.ToUpper = "RFC" Then
                                        rfcReceptorXML = reader.Value
                                    End If
                                End While
                            End If
                        End If
                        If reader.Name = "tfd:TimbreFiscalDigital" Or reader.Name.ToLower = "timbrefiscaldigital" Then
                            If reader.HasAttributes Then
                                While reader.MoveToNextAttribute()
                                    If reader.Name.ToUpper = "UUID" Then
                                        uuidXML = reader.Value
                                    ElseIf reader.Name.ToLower = "fechatimbrado" Then
                                        fechaTimbradoXML = reader.Value
                                    End If
                                End While
                            End If
                        End If
                        If reader.Name = "cfdi:Concepto" Or reader.Name.ToLower = "concepto" Then
                            If reader.HasAttributes Then
                                While reader.MoveToNextAttribute()
                                    If reader.Name.ToLower = "cantidad" Then
                                        paresXML += reader.Value
                                    End If
                                End While
                            End If
                        End If
                    Loop

                    With EntXML
                        .PSerie = serieXML
                        .PFolio = folioXML
                        .PFechaTimbrado = fechaTimbradoXML
                        .PTotal = totalXML
                        .PUUID = uuidXML
                        .PTotalPares = paresXML
                        .PRFCEmisor = rfcEmisorXML
                        .PRFCReceptor = rfcReceptorXML
                        .PTipoMoneda = monedaXML
                    End With

                    If Not EntXML Is Nothing Then
                        If rfcEmisorXML <> emisorRFC Then
                            blnCargaXML = False
                            EntXML = Nothing
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El Emisor del XML no coincide con la información de la devolución.")
                        ElseIf rfcReceptorXML <> receptorRFC Then
                            blnCargaXML = False
                            EntXML = Nothing
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El Receptor del XML no coincide con la información de la devolución.")
                        ElseIf paresXML <> paresDevolucion Then
                            blnCargaXML = False
                            EntXML = Nothing
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Hay una diferencia de " & CStr(paresDevolucion - paresXML) & " pares.")
                        ElseIf totalXML <> totalDevolucion Then
                            blnCargaXML = False
                            EntXML = Nothing
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Hay una diferencia de " & CStr(totalDevolucion - totalXML) & " pesos.")
                        Else
                            blnCargaXML = True
                        End If
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Errores, "No fue posible obtener la información del XML, favor de reportarlo a sistemas.")
                        EntXML = Nothing
                        blnCargaXML = False
                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El archivo seleccionado no es un XML.")
                End If
            Catch ex As Exception

            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If

    End Sub

    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        If blnCargaXML Then
            ArchivoPDF = ""
            OpenFileDialog1.Filter = "pdf files (*.pdf)|*.pdf"
            OpenFileDialog1.FilterIndex = 2
            OpenFileDialog1.RestoreDirectory = True
            If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                If System.IO.Path.GetExtension(OpenFileDialog1.FileName).ToUpper = ".PDF" Then
                    ArchivoPDF = OpenFileDialog1.FileName
                    blnCargaPDF = True
                    If blnCargaPDF And blnCargaXML Then
                        btnGuardar.Enabled = True
                    Else
                        btnGuardar.Enabled = False
                    End If
                Else
                    Dim objMensajeAdv As New Tools.AdvertenciaForm
                    objMensajeAdv.mensaje = "El archivo seleccionado no es un PDF."
                    objMensajeAdv.ShowDialog()
                End If
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Es necesario cargar el archivo XML.")
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If gvwListado.DataRowCount > 0 Then

                nombreReporte = "DetallesDevolucionCompraPTIngresado"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = "Seleccione una carpeta "
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.ToString("yyyyMMdd_Hmmss")

                    If ret = Windows.Forms.DialogResult.OK Then
                        If gvwListado.GroupCount > 0 Then
                            gvwListado.ExportToXlsx(.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            gvwListado.ExportToXlsx(.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With

            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo.")
        End Try
    End Sub
End Class