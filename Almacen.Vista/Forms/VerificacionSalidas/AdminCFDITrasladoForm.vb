Imports System.IO
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Facturacion.Negocios
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Ventas.Vista

Public Class AdminCFDITrasladoForm

#Region "Variables Globales"
    Private filtro_FechaInicio As String = String.Empty
    Private filtro_FechaFin As String = String.Empty
    Private filtro_Estatus As String = String.Empty
    Private filtro_Emisor As String = String.Empty
    Private filtro_Cliente As String = String.Empty
    Private filtro_Folio As String = String.Empty
    Private filtro_Nave As String = String.Empty
    Private filtro_Salida As String = String.Empty
    Private filtro_Tipo As Integer = 1
    Private filtro_Cedis As Short
    Private ReadOnly listInicial As New List(Of String)
    Private ReadOnly lstFiltroFolio As New List(Of String)
    Private ReadOnly objBUTimbrado As New TrasladosBU
    Private ReadOnly objBU As New Negocios.AdminCFDITrasladoBU
    ReadOnly objFTP As New TransferenciaFTP

#End Region

    Private Sub AdminCFDITrasladoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        cmbCEDIS = Utilerias.ComboObtenerCEDISUsuario(cmbCEDIS)

        Inicializar()
        PermisosPerfil()
    End Sub

#Region "Panel Cabecera"

    Private Sub ChboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Try
            Dim NumeroFilas As Integer = vwAdminTraslado.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                vwAdminTraslado.SetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), " ", chboxSeleccionarTodo.Checked)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnTimbrar_Click(sender As Object, e As EventArgs) Handles btnTimbrar.Click
        Dim FilasSeleccionadas As Integer = 0
        Dim FacturasTimbradas As Integer = 0
        Dim DocumentoNoTimbrados As String = String.Empty
        Dim FacturasNoTimbradas As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            btnTimbrar.Enabled = False
            Dim NumeroFilas As Integer = vwAdminTraslado.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), " ")) = True Then
                    FilasSeleccionadas += 1

                    Dim ID As Integer = vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), "ID")
                    Dim DocumentoIDSeleccionado As Integer = vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), "Embarque")
                    Dim EmpresaDocumentoID As Integer = vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), "Empresa")
                    Dim StatusDocumento As Integer = vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), "Estatus")
                    Dim tipo As Boolean = vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), "Tipo")

                    If DocumentoIDSeleccionado > 0 Then
                        If StatusDocumento = 451 Then 'Por timbrar

                            'Genera la informacion para el timbrado y realiza el timbre
                            objBUTimbrado.GenerarInformacionTimbrado(DocumentoIDSeleccionado, EmpresaDocumentoID, tipo) 'lblFolio.Text
                            Dim ResultadoTimbrado = objBUTimbrado.TimbrarFactura(ID, EmpresaDocumentoID, "TRASLADO")

                            If ResultadoTimbrado = True Then
                                FacturasTimbradas += 1

                                'Generar PDF                                                                        
                                If objBUTimbrado.GenerarPDFFactura(ID, "TRASLADO") = True Then
                                    Dim RutaPDFFactura = objBUTimbrado.ConsultarRutaPDFFactura(ID)
                                    AbrirPDFFactura(RutaPDFFactura)
                                End If
                            Else
                                If DocumentoNoTimbrados = String.Empty Then
                                    DocumentoNoTimbrados = DocumentoIDSeleccionado.ToString()
                                Else
                                    DocumentoNoTimbrados &= "," & DocumentoIDSeleccionado.ToString()
                                End If

                                FacturasNoTimbradas += 1
                            End If
                        End If

                    Else

                        FacturasNoTimbradas += 1
                        If DocumentoNoTimbrados = String.Empty Then
                            DocumentoNoTimbrados = DocumentoIDSeleccionado.ToString()
                        Else
                            DocumentoNoTimbrados &= "," & DocumentoIDSeleccionado.ToString()
                        End If
                        objBUTimbrado.InsertarErrorAlTimbrar(DocumentoIDSeleccionado, "TRASLADO", "NA", "NO SE TIMBRO.")
                        Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Error al TIMBRAR.")
                    End If

                End If
            Next

            If FilasSeleccionadas > 0 Then

                If FacturasTimbradas > 0 Then
                    If FacturasNoTimbradas > 0 Then
                        'Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se han timbrado " & FacturasTimbradas.ToString & " de " & FilasSeleccionadas.ToString())
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se generaron correctamente los comprobantes de traslado")
                    Else
                        'Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se han timbrado " & FacturasTimbradas.ToString)
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se generó correctamente el comprobante de traslado")
                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se timbro los documentos seleccionados.")
                End If

                'Mostrar los documentos no timbrados
                If FacturasNoTimbradas > 0 Then
                    Dim form As New ErroresTimbradoForm With {
                        .DocumentoID = DocumentoNoTimbrados,
                        .TipoComprobante = "TRASLADO"
                    }
                    form.Show()
                End If
            End If

            BtnMostrar_Click(sender, e)
            btnTimbrar.Enabled = True
            Cursor = Cursors.Default
        Catch ex As Exception
            btnTimbrar.Enabled = True
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            BtnMostrar_Click(Nothing, Nothing)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cursor = Cursors.WaitCursor

        If CBool(vwAdminTraslado.GetRowCellValue(vwAdminTraslado.FocusedRowHandle, " ")) = True Then
            If vwAdminTraslado.GetRowCellValue(vwAdminTraslado.FocusedRowHandle, "Estatus") = 157 Then
                Dim folioEmbarque = vwAdminTraslado.GetRowCellValue(vwAdminTraslado.FocusedRowHandle, "Embarque")
                Dim UUID = vwAdminTraslado.GetRowCellValue(vwAdminTraslado.FocusedRowHandle, "Folio Fiscal")
                Dim empresa = vwAdminTraslado.GetRowCellValue(vwAdminTraslado.FocusedRowHandle, "Empresa")

                Dim CancelacionTimbrada = objBUTimbrado.CancelarFactura(folioEmbarque, UUID, empresa, "TRASLADO", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                If CancelacionTimbrada = True Then
                    If objBUTimbrado.GenerarPDFFacturaCancelada(folioEmbarque, "TRASLADO") = True Then
                        Dim RutaPDFFactura = objBUTimbrado.ConsultarRutaPDFFactura(folioEmbarque)
                        AbrirPDFFactura(RutaPDFFactura)
                    End If

                    'entFactura = objBUTimbrado.ConsultarRutasDocumento(DocumentoId)
                    'objBUTimbrado.CancelarDocumentoSICY(entFactura.RemisionID, entFactura.Año, entFactura.UUID, entFactura.RutaXML, entFactura.RutaPDF)

                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Documento cancelado correctamente")
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El documento no se pudo cancelar.")
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Solo se pueden cancelar documentos timbrados.")
            End If
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub BtnVerPDF_Click(sender As Object, e As EventArgs) Handles btnVerPDF.Click
        If vwAdminTraslado.RowCount > 0 Then
            Try
                Dim NumeroFilas As Integer = vwAdminTraslado.DataRowCount
                Dim lst As New List(Of String)

                For index As Integer = 0 To NumeroFilas Step 1
                    If CBool(vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), " ")) = True Then
                        Try
                            Dim folio = vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), "Embarque").ToString
                            Dim pdf = vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), "PDF").ToString
                            pdf = pdf.Replace("ftp://192.168.2.158", "")
                            pdf = pdf.Substring(1)

                            If pdf IsNot "" Then
                                objFTP.DescargarArchivo(Path.GetDirectoryName(pdf), My.Computer.FileSystem.SpecialDirectories.MyDocuments + Path.GetDirectoryName(pdf.Substring(3)), Path.GetFileName(pdf))
                                'objFTP.DescargarArchivo(Path.GetDirectoryName(pdf), "\\192.168.2.156\" + Path.GetDirectoryName(pdf), Path.GetFileName(pdf))
                                Dim ARCHIVO = My.Computer.FileSystem.SpecialDirectories.MyDocuments + Path.GetDirectoryName(pdf.Substring(3)) + "\" + Path.GetFileName(pdf)
                                Process.Start(ARCHIVO)
                            Else
                                lst.Add(folio)
                            End If
                        Catch ex As Exception
                            If ex.Message.Contains("no puede encontrar") Then
                                Dim form As New Tools.AdvertenciaForm With {
                                .mensaje = ex.Message
                            }
                                form.ShowDialog()
                            End If
                        End Try
                    End If
                Next

                If lst.Count > 0 Then
                    Dim folios As String = String.Empty
                    For Each item As String In lst
                        If folios <> "" Then
                            folios += ","
                        End If
                        folios += item
                    Next
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Los folios: " + folios + ". No cuentan con PDF.")
                End If

                'Dim NumeroFilas As Integer = vwAdminTraslado.DataRowCount
                'Dim lst As New List(Of String)

                'For index As Integer = 0 To NumeroFilas Step 1
                '    If CBool(vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), " ")) = True Then
                '        Try
                '            Dim folio = vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), "Embarque").ToString
                '            Dim pdf = vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), "PDF").ToString
                '            If pdf IsNot "" Then
                '                Process.Start(pdf)
                '            Else
                '                lst.Add(folio)
                '            End If
                '        Catch ex As Exception
                '            If ex.Message.Contains("no puede encontrar") Then
                '                Dim form As New Tools.AdvertenciaForm With {
                '                .mensaje = ex.Message
                '            }
                '                form.ShowDialog()
                '            End If
                '        End Try
                '    End If
                'Next

                'If CBool(vwAdminTraslado.GetRowCellValue(vwAdminTraslado.FocusedRowHandle, " ")) = True Then
                '    Try
                '        Dim pdf = vwAdminTraslado.GetRowCellValue(vwAdminTraslado.FocusedRowHandle, "PDF")
                '        Process.Start(pdf)
                '    Catch ex As Exception
                '        If ex.Message.Contains("no puede encontrar") Then
                '            Dim form As New Tools.AdvertenciaForm With {
                '                .mensaje = ex.Message
                '            }
                '            form.ShowDialog()
                '        End If
                '    End Try
                'End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub BtnVerXML_Click(sender As Object, e As EventArgs) Handles btnVerXML.Click
        If vwAdminTraslado.RowCount > 0 Then
            Try
                Dim NumeroFilas As Integer = vwAdminTraslado.DataRowCount
                Dim lst As New List(Of String)

                For index As Integer = 0 To NumeroFilas Step 1
                    If CBool(vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), " ")) = True Then
                        Try
                            Dim folio = vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), "Embarque").ToString
                            Dim xml = vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), "XML").ToString
                            xml = xml.Replace("ftp://192.168.2.158", "")
                            xml = xml.Substring(1)

                            If xml IsNot "" Then
                                objFTP.DescargarArchivo(Path.GetDirectoryName(xml), My.Computer.FileSystem.SpecialDirectories.MyDocuments + Path.GetDirectoryName(xml.Substring(3)), Path.GetFileName(xml))
                                'objFTP.DescargarArchivo(Path.GetDirectoryName(xml), "\\192.168.2.156\" + Path.GetDirectoryName(xml), Path.GetFileName(xml))
                                Dim ARCHIVO = My.Computer.FileSystem.SpecialDirectories.MyDocuments + Path.GetDirectoryName(xml.Substring(3)) + "\" + Path.GetFileName(xml)
                                Process.Start(ARCHIVO)
                            Else
                                lst.Add(folio)
                            End If
                        Catch ex As Exception
                            If ex.Message.Contains("no puede encontrar") Then
                                Dim form As New Tools.AdvertenciaForm With {
                                .mensaje = ex.Message
                            }
                                form.ShowDialog()
                            End If
                        End Try
                    End If
                Next

                If lst.Count > 0 Then
                    Dim folios As String = String.Empty
                    For Each item As String In lst
                        If folios <> "" Then
                            folios += ","
                        End If
                        folios += item
                    Next
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Los folios: " + folios + ". No cuentan con XML.")
                End If

                'If vwAdminTraslado.RowCount > 0 Then
                '    Try
                '        If CBool(vwAdminTraslado.GetRowCellValue(vwAdminTraslado.FocusedRowHandle, " ")) = True Then
                '            Try
                '                Dim xml = vwAdminTraslado.GetRowCellValue(vwAdminTraslado.FocusedRowHandle, "XML")
                '                Process.Start(xml)
                '            Catch ex As Exception
                '                If ex.Message.Contains("no puede encontrar") Then
                '                    Dim form As New Tools.AdvertenciaForm With {
                '                        .mensaje = ex.Message
                '                    }
                '                    form.ShowDialog()
                '                End If
                '            End Try
                '        End If
                '    Catch ex As Exception

                '    End Try
                'End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub BtnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreDocumento = "\ReporteTraslados_"

        If vwAdminTraslado.RowCount > 0 Then
            Try
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True
                    Dim exportOptions = New XlsxExportOptionsEx()
                    AddHandler exportOptions.CustomizeCell, AddressOf ExportOptions_CustomizeCell

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        grdAdminTraslado.ExportToXlsx(.SelectedPath + nombreDocumento + fecha_hora + ".xlsx", exportOptions)
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & nombreDocumento & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                    End If
                End With

            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            End Try
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos para exportar.")
        End If
    End Sub

    Private Sub BtnVerDetalles_Click(sender As Object, e As EventArgs) Handles btnVerDetalles.Click
        'Dim folios = ObtenerFoliosEmbarques()
        'Dim emisores = ObtenerEmisoresEmbarques()
        Dim cartas = ObtenerCartasEmbarques()

        If Not cartas = String.Empty Then
            Dim detalles As New DetallesCFDITraslados With {
                .folioEmbarque = cartas
            }

            detalles.Show(Me)
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay folios seleccionados.")
        End If
    End Sub

#End Region

#Region "Panel de Parametros"

#Region "Eventos Estatus"

    Private Sub GrdStatus_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdStatus.InitializeLayout
        DiseñoFiltro(grdStatus)
        grdStatus.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Estatus"
    End Sub

    Private Sub BtnAgregarFiltroStatus_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroStatus.Click
        Dim filtroReporte As New FiltrosReportesForm With {
            .TIPO_BUSQUEDA = 12
        }

        Dim lstIDFiltro As New List(Of String)
        For Each row As UltraGridRow In grdStatus.Rows
            Dim parametro As String = row.Cells(0).Text
            lstIDFiltro.Add(parametro)
        Next

        filtroReporte.LST_ID_FILTRO = lstIDFiltro
        filtroReporte.ShowDialog(Me)

        If Not filtroReporte.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If filtroReporte.LST_PARAMETROS.Rows.Count = 0 Then Return

        grdStatus.DataSource = filtroReporte.LST_PARAMETROS
        With grdStatus
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub BtnLimpiarFiltroStatus_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroStatus.Click
        grdStatus.DataSource = listInicial
    End Sub

    Private Sub GrdEstatus_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdStatus.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

#End Region

#Region "Eventos Cliente"

    Private Sub GrdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        DiseñoFiltro(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub BtnAgregarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroCliente.Click
        Dim filtroReporte As New FiltrosReportesForm With {
            .TIPO_BUSQUEDA = 2
        }

        Dim lstIDFiltro As New List(Of String)
        For Each row As UltraGridRow In grdClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            lstIDFiltro.Add(parametro)
        Next

        filtroReporte.LST_ID_FILTRO = lstIDFiltro
        filtroReporte.ShowDialog(Me)

        If Not filtroReporte.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If filtroReporte.LST_PARAMETROS.Rows.Count = 0 Then Return

        grdClientes.DataSource = filtroReporte.LST_PARAMETROS
        With grdClientes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub BtnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdClientes.DataSource = listInicial
    End Sub

    Private Sub GrdClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

#End Region

#Region "Eventos Emisor"

    Private Sub GrdEmisor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdEmisor.InitializeLayout
        DiseñoFiltro(grdEmisor)
        grdEmisor.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Emisor"
    End Sub

    Private Sub BtnAgregarFiltroEmisor_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroEmisor.Click
        Dim filtroReporte As New FiltrosReportesForm With {
            .TIPO_BUSQUEDA = 13
        }

        Dim lstIDFiltro As New List(Of String)
        For Each row As UltraGridRow In grdEmisor.Rows
            Dim parametro As String = row.Cells(0).Text
            lstIDFiltro.Add(parametro)
        Next

        filtroReporte.LST_ID_FILTRO = lstIDFiltro
        filtroReporte.ShowDialog(Me)

        If Not filtroReporte.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If filtroReporte.LST_PARAMETROS.Rows.Count = 0 Then Return

        grdEmisor.DataSource = filtroReporte.LST_PARAMETROS
        With grdEmisor
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub BtnLimpiarFiltroEmisor_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroEmisor.Click
        grdEmisor.DataSource = listInicial
    End Sub

    Private Sub GrdEmisor_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdEmisor.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

#End Region

#Region "Eventos Folio"

    Private Sub GrdFolio_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFolio.InitializeLayout
        DiseñoFiltro(grdFolio)
        grdFolio.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Folio"
    End Sub

    Private Sub TxtFiltroFolio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroFolio.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroFolio.Text) Then Return

            lstFiltroFolio.Add(txtFiltroFolio.Text)
            grdFolio.DataSource = Nothing
            grdFolio.DataSource = lstFiltroFolio

            txtFiltroFolio.Text = String.Empty

        End If
    End Sub

    Private Sub GrdFolio_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFolio.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

#End Region

#Region "Eventos Nave"

    Private Sub GrdNave_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdNave.InitializeLayout
        DiseñoFiltro(grdNave)
        grdNave.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Nave"
    End Sub

    Private Sub BtnAgregarFiltroNave_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroNave.Click
        Dim filtroReporte As New FiltrosReportesForm With {
            .TIPO_BUSQUEDA = 11
        }

        Dim lstIDFiltro As New List(Of String)
        For Each row As UltraGridRow In grdNave.Rows
            Dim parametro As String = row.Cells(0).Text
            lstIDFiltro.Add(parametro)
        Next

        filtroReporte.LST_ID_FILTRO = lstIDFiltro
        filtroReporte.ShowDialog(Me)

        If Not filtroReporte.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If filtroReporte.LST_PARAMETROS.Rows.Count = 0 Then Return

        grdNave.DataSource = filtroReporte.LST_PARAMETROS
        With grdNave
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub BtnLimpiarFiltroNave_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroNave.Click
        grdNave.DataSource = listInicial
    End Sub

    Private Sub GrdNaves_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdNave.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

#End Region

#Region "Eventos Fechas"

    Private Sub DtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaFin.Value < dtpFechaInicio.Value Then
            dtpFechaFin.Value = dtpFechaInicio.Value
        End If
    End Sub

    Private Sub DtpFechaAl_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFin.ValueChanged
        If dtpFechaFin.Value < dtpFechaInicio.Value Then
            dtpFechaInicio.Value = dtpFechaFin.Value
        End If
    End Sub

#End Region

#Region "Eventos de cierre de parametros"
    Private Sub BtnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub BtnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 201
    End Sub

#End Region

#End Region

#Region "Panel Contenido"

    Private Sub VwAdminTraslado_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwAdminTraslado.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub VwAdminTraslado_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles vwAdminTraslado.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        Try
            Cursor = Cursors.WaitCursor
            If e.Column.FieldName = "ST" Then
                If currentView.GetRowCellValue(e.RowHandle, "Estatus") = 451 Then
                    e.Appearance.BackColor = pnlCanceladoFaltaSAT.BackColor
                ElseIf currentView.GetRowCellValue(e.RowHandle, "Estatus") = 452 Then
                    e.Appearance.BackColor = pnlColorFA.BackColor
                ElseIf currentView.GetRowCellValue(e.RowHandle, "Estatus") = 453 Then
                    e.Appearance.BackColor = pnlStatusNoTimbrado.BackColor
                End If
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

        Cursor = Cursors.Default
    End Sub

#End Region

#Region "Panel de Acciones"

    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        ObtenerFiltros()
        Dim dtResultadoReporte As DataTable = objBU.ConsultaDocumentosTraslados(filtro_FechaInicio,
                                                                                filtro_FechaFin,
                                                                                filtro_Estatus,
                                                                                filtro_Emisor,
                                                                                filtro_Cliente,
                                                                                filtro_Folio,
                                                                                filtro_Nave,
                                                                                filtro_Salida,
                                                                                filtro_Tipo,
                                                                                filtro_Cedis)
        If dtResultadoReporte.Rows.Count > 0 Then
            grdAdminTraslado.DataSource = Nothing
            vwAdminTraslado.Columns.Clear()

            grdAdminTraslado.DataSource = dtResultadoReporte
            DiseñoGrid.DiseñoBaseGrid(vwAdminTraslado)
            DiseñoDevGrid()

            lblRegistroR.Text = dtResultadoReporte.Rows.Count
            lblFechaUltimaActualización.Text = Date.Now.ToString()
            BtnArriba_Click(sender, e)
        Else
            grdAdminTraslado.DataSource = Nothing
            vwAdminTraslado.Columns.Clear()
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos para mostrar.")
        End If

    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Inicializar()
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

#End Region

#Region "Metodos Privados"

    Private Sub Inicializar()

        grdAdminTraslado.DataSource = Nothing
        vwAdminTraslado.Columns.Clear()

        rdoFechaFacturacion.Checked = True
        rdoFechaCancelacion.Checked = False

        grdStatus.DataSource = listInicial
        grdClientes.DataSource = listInicial
        grdEmisor.DataSource = listInicial

        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now

        lblRegistroR.Text = "-"
        lblFechaUltimaActualización.Text = "-"

        chboxEmbarque.Checked = True
        chboxSalidaNave.Checked = True
        chboxSeleccionarTodo.Checked = False
    End Sub

    Private Sub DiseñoDevGrid()

        vwAdminTraslado.IndicatorWidth = 50
        For Each col As Columns.GridColumn In vwAdminTraslado.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
            If (col.FieldName = "Cantidad") Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "N0"
                DiseñoGrid.EstiloColumna(vwAdminTraslado, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, False, 100, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            Else
                If col.FieldName = "F Capturo" Or col.FieldName = "F Timbrado" Or col.FieldName = "F Cancelación" Then
                    DiseñoGrid.EstiloColumna(vwAdminTraslado, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "dd/MM/yyyy HH:mm:ss")
                Else
                    DiseñoGrid.EstiloColumna(vwAdminTraslado, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
                End If
            End If
        Next

        vwAdminTraslado.Columns.ColumnByFieldName("ID").Visible = False
        vwAdminTraslado.Columns.ColumnByFieldName("Estatus").Visible = False
        vwAdminTraslado.Columns.ColumnByFieldName("Empresa").Visible = False
        vwAdminTraslado.Columns.ColumnByFieldName("Tipo").Visible = False
        'vwAdminTraslado.Columns.ColumnByFieldName("PDF").Width = 100
        'vwAdminTraslado.Columns.ColumnByFieldName("XML").Width = 100
        vwAdminTraslado.Columns.ColumnByFieldName("ST").Width = 25
        vwAdminTraslado.Columns.ColumnByFieldName("ST").OptionsFilter.AllowFilter = False
        vwAdminTraslado.Columns.ColumnByFieldName("ST").OptionsColumn.AllowEdit = False
        vwAdminTraslado.Columns.ColumnByFieldName(" ").OptionsColumn.AllowEdit = True


        'vwAdminTraslado.OptionsView.ColumnAutoWidth = True
    End Sub

    Private Sub ObtenerFiltros()
        filtro_FechaInicio = dtpFechaInicio.Text
        filtro_FechaFin = dtpFechaFin.Text

        filtro_Tipo = If(rdoFechaFacturacion.Checked, 1, 2)

        filtro_Cedis = cmbCEDIS.SelectedValue

        filtro_Estatus = String.Empty
        filtro_Emisor = String.Empty
        filtro_Cliente = String.Empty
        filtro_Folio = String.Empty
        filtro_Nave = String.Empty
        filtro_Salida = String.Empty

        If chboxEmbarque.Checked Then
            filtro_Salida = "0"
        End If
        If chboxSalidaNave.Checked Then
            If filtro_Salida <> "" Then
                filtro_Salida += ","
            End If
            filtro_Salida += "1"
        End If

        For Each Row As UltraGridRow In grdStatus.Rows
            If filtro_Estatus <> "" Then
                filtro_Estatus += ","
            End If
            filtro_Estatus += Row.Cells("Parametro").Value.ToString()
        Next
        For Each Row As UltraGridRow In grdEmisor.Rows
            If filtro_Emisor <> "" Then
                filtro_Emisor += ","
            End If
            filtro_Emisor += Row.Cells("Parametro").Value.ToString()
        Next
        For Each Row As UltraGridRow In grdClientes.Rows
            If filtro_Cliente <> "" Then
                filtro_Cliente += ","
            End If
            filtro_Cliente += Row.Cells("Parametro").Value.ToString()
        Next
        For Each Row As UltraGridRow In grdFolio.Rows
            If filtro_Folio <> "" Then
                filtro_Folio += ","
            End If
            filtro_Folio += Row.Cells(0).Text
        Next
        For Each Row As UltraGridRow In grdNave.Rows
            If filtro_Nave <> "" Then
                filtro_Nave += ","
            End If
            filtro_Nave += Row.Cells("Parametro").Text
        Next
    End Sub

    Private Sub PermisosPerfil()
        If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMIN_CFDI_TRASLADOS", "TRASLADOS_CONTA") Then
            Dim DTInformacionUsuario As New DataTable

            Dim resultado = objBU.ConsultaNave(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)
            btnAgregarFiltroNave.Enabled = False
            btnLimpiarFiltroNave.Enabled = False

            DTInformacionUsuario.Columns.Add("Parametro")
            DTInformacionUsuario.Columns.Add(" ")
            DTInformacionUsuario.Columns.Add("Nave")
            DTInformacionUsuario.Rows.Add(resultado(0)(0), 0, resultado(0)(2))

            grdNave.DataSource = DTInformacionUsuario
            grdNave.DisplayLayout.Bands(0).Columns(0).Hidden = True
            grdNave.DisplayLayout.Bands(0).Columns(1).Hidden = True

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMIN_CFDI_TRASLADOS", "TRASLADOS_NAVE") Then
                chboxEmbarque.Checked = False
                chboxEmbarque.Visible = False

                chboxSalidaNave.Checked = True
            Else
                chboxSalidaNave.Checked = False
                chboxSalidaNave.Visible = False

                chboxEmbarque.Checked = True
            End If
        End If
    End Sub

    Private Sub DiseñoFiltro(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

    End Sub

    Private Function ObtenerFoliosEmbarques() As String
        Dim folioEmbarques = String.Empty
        Dim NumeroFilas As Integer = vwAdminTraslado.DataRowCount

        For index As Integer = 0 To NumeroFilas Step 1
            If CBool(vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), " ")) = True Then
                If folioEmbarques <> "" Then
                    folioEmbarques += ","
                End If
                folioEmbarques += vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), "Embarque").ToString
            End If
        Next

        Return folioEmbarques
    End Function

    Private Function ObtenerCartasEmbarques() As String
        Dim cartasEmbarques = String.Empty
        Dim NumeroFilas As Integer = vwAdminTraslado.DataRowCount

        For index As Integer = 0 To NumeroFilas Step 1
            If CBool(vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), " ")) = True Then
                If cartasEmbarques <> "" Then
                    cartasEmbarques += ","
                End If
                cartasEmbarques += vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), "ID").ToString
            End If
        Next

        Return cartasEmbarques
    End Function

    Private Sub AbrirPDFFactura(ByVal RutaPDF As String)
        Try
            RutaPDF = RutaPDF.Replace("ftp://192.168.2.158", "")
            RutaPDF = RutaPDF.Substring(1)

            If RutaPDF IsNot "" Then
                objFTP.DescargarArchivo(Path.GetDirectoryName(RutaPDF), My.Computer.FileSystem.SpecialDirectories.MyDocuments + Path.GetDirectoryName(RutaPDF.Substring(3)), Path.GetFileName(RutaPDF))
                Dim ARCHIVO = My.Computer.FileSystem.SpecialDirectories.MyDocuments + Path.GetDirectoryName(RutaPDF.Substring(3)) + "\" + Path.GetFileName(RutaPDF)
                Process.Start(ARCHIVO)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function ObtenerEmisoresEmbarques() As String
        Dim emisorEmbarques = String.Empty
        Dim NumeroFilas As Integer = vwAdminTraslado.DataRowCount

        For index As Integer = 0 To NumeroFilas Step 1
            If CBool(vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), " ")) = True Then
                If emisorEmbarques <> "" Then
                    emisorEmbarques += ","
                End If
                emisorEmbarques += vwAdminTraslado.GetRowCellValue(vwAdminTraslado.GetVisibleRowHandle(index), "Empresa").ToString
            End If
        Next

        Return emisorEmbarques
    End Function

    Private Sub ExportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

    End Sub

#End Region

End Class