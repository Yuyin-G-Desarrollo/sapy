Imports System.ComponentModel
Imports System.Drawing
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Imports Proveedores.BU
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Export
Imports Tools

Public Class ProdIngresadoMaquilas
    Private idNave As Integer = 0
    Private inicio As New Date
    Private fin As New Date
    Private destinatarios As String = ""
    Private ReadOnly adv As New AdvertenciaForm
    Private ReadOnly exito As New ExitoForm
    Private Shared mailSent As Boolean = False

    Private Sub BntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Close()
    End Sub

    Private Sub BtnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        grbParametros.Width = 31
    End Sub

    Private Sub BtnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        grbParametros.Width = 74
    End Sub

    Private Sub ProdIngresadoMaquilas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblRazSoc.Text = ""
        LlenarComboNaves()
        CheckForIllegalCrossThreadCalls = False
        WindowState = FormWindowState.Maximized
    End Sub

    Public Sub LlenarComboNaves()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.Items.Count = 2 Then
            cmbNave.SelectedIndex = 1
        End If
    End Sub

    Private Sub ExportarGridAExcel()

        Dim sfd As New SaveFileDialog With {
            .DefaultExt = "xls",
            .Filter = "Excel Files|*.xls"
        }

        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Cursor = Cursors.WaitCursor

                ultExportGrid.Export(grdListas, fileName)

                Dim objMensajeExito As New ExitoForm With {
                    .mensaje = "Archivo exportado correctamente en la ubicación: " + fileName,
                    .StartPosition = FormStartPosition.CenterScreen
                }
                objMensajeExito.ShowDialog()
                Process.Start(fileName)
            Catch ex As Exception
                Dim objMensajeError As New ErroresForm With {
                    .mensaje = "El documento no pudo exportarse." + vbLf + ex.Message,
                    .StartPosition = FormStartPosition.CenterScreen
                }
                objMensajeError.ShowDialog()
            End Try
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If grdListas.Rows.Count > 0 Then
            ExportarGridAExcel()
        End If

    End Sub

    Public Sub DisenioGrid()
        Try
            With grdListas.DisplayLayout.Bands(0)
                .Columns("IdNave").Hidden = True
                .Columns("ProductoEstiloID").Hidden = True
                .Columns("ClaveSAT").Hidden = True
                .Columns("Vacía").Header.Caption = " "
                .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, True)
                .Columns("Vacía").Width = 8
                .Columns("Precio").Format = "##,##0.00"
                .Columns("Total F").Format = "##,##0.00"
                .Columns("Pares F").Format = "##,##0"
                .Columns("Total D").Format = "##,##0.00"
                .Columns("Pares D").Format = "##,##0"
                .Columns("Total").Format = "##,##0.00"
                .Columns("Pares").Format = "##,##0"
                .Columns("Pares F").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Total F").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Pares D").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Total D").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Pares").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Precio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            End With
            grdListas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdListas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

            grdListas.DisplayLayout.Bands(0).Columns("Vacía").Width = 12

            'insertar sumatorias
            Dim sumParesF As SummarySettings = grdListas.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdListas.DisplayLayout.Bands(0).Columns("Pares F"))
            Dim sumParesR As SummarySettings = grdListas.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdListas.DisplayLayout.Bands(0).Columns("Pares D"))
            Dim sumTotalF As SummarySettings = grdListas.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdListas.DisplayLayout.Bands(0).Columns("Total F"))
            Dim sumTotalR As SummarySettings = grdListas.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdListas.DisplayLayout.Bands(0).Columns("Total D"))
            Dim sumPares As SummarySettings = grdListas.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdListas.DisplayLayout.Bands(0).Columns("Pares"))
            Dim sumTotal As SummarySettings = grdListas.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdListas.DisplayLayout.Bands(0).Columns("Total"))

            sumParesF.DisplayFormat = "{0:#,##0}"
            sumParesF.Appearance.TextHAlign = Infragistics.Win.HAlign.Right
            sumParesR.DisplayFormat = "{0:#,##0}"
            sumParesR.Appearance.TextHAlign = Infragistics.Win.HAlign.Right
            sumTotalR.DisplayFormat = "{0:#,##0.00}"
            sumTotalR.Appearance.TextHAlign = Infragistics.Win.HAlign.Right
            sumTotalF.DisplayFormat = "{0:#,##0.00}"
            sumTotalF.Appearance.TextHAlign = Infragistics.Win.HAlign.Right
            sumPares.DisplayFormat = "{0:#,##0}"
            sumPares.Appearance.TextHAlign = Infragistics.Win.HAlign.Right
            sumTotal.DisplayFormat = "{0:#,##0.00}"
            sumTotal.Appearance.TextHAlign = Infragistics.Win.HAlign.Right

            grdListas.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"


        Catch ex As Exception
        End Try
    End Sub

    Public Sub LlenarGrid()
        Try
            Dim obj As New ListaPreciosProdBU
            If cmbNave.SelectedValue > 0 Then
                inicio = dtpFechaInicio.Value
                fin = dtpFechaFinal.Value
                grdListas.DataSource = Nothing
                grdListas.DataSource = obj.getProductoTerminadoMaquila(idNave, inicio, fin)
                DisenioGrid()
                Contar()
            Else
                Dim adv As New AdvertenciaForm With {
                    .mensaje = "Selecciona una nave."
                }
                adv.ShowDialog()
            End If
        Catch ex As Exception
            adv.mensaje = "Surgió un problema con la conexión intentelo mas tarde."
            adv.ShowDialog()
        End Try
    End Sub

    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor
        LlenarGrid()
        Cursor = Cursors.Default
    End Sub

    Private Sub Contar()
        Try
            Dim i As Integer = 0
            Dim totalF As Double = 0.0
            Dim paresF As Integer = 0
            Dim totalR As Double = 0.0
            Dim paresR As Integer = 0
            Do
                grdListas.Rows(i).Cells("Vacía").Appearance.BackColor = If(grdListas.Rows(i).Cells("Precio").Value = 0, Color.Salmon, Color.YellowGreen)

                paresF += Convert.ToInt32(grdListas.Rows(i).Cells("Pares F").Value)
                totalF += Convert.ToDouble(grdListas.Rows(i).Cells("Total F").Value)

                paresR += Convert.ToInt32(grdListas.Rows(i).Cells("Pares D").Value)
                totalR += Convert.ToDouble(grdListas.Rows(i).Cells("Total D").Value)

                i += 1
            Loop While i < grdListas.Rows.Count
            lblPares.Text = "" & (paresR + paresF).ToString("##,##0")
            lblTotal.Text = "$ " & (totalR + totalF).ToString("##,##0.00")

            lblParesF.Text = "" & paresF.ToString("##,##0")
            lblTotalF.Text = "$ " & totalF.ToString("##,##0.00")

            lblParesR.Text = "" & paresR.ToString("##,##0")
            lblTotalR.Text = "$ " & totalR.ToString("##,##0.00")


        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        Try
            idNave = cmbNave.SelectedValue
            Dim objBU As New ListaPreciosProdBU
            lblRazSoc.Text = objBU.getRazSocReceptor(idNave)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirReporteAgrupado("imprimir")
    End Sub

    Public Sub ImprimirReporte(accion As String)
        If grdListas.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor
            Dim dtLista As New DataTable("dtLista")
            Dim datosNave As New DataTable()
            Dim idNav As Integer = 0
            Dim nombreNave As String = ""
            Dim urlNave As String = ""
            Dim obj As New ListaPreciosProdBU
            Try
                Cursor = Cursors.WaitCursor
                dtLista = grdListas.DataSource
                If dtLista.Rows.Count > 0 Then
                    idNav = dtLista.Rows(0).Item("IdNave").ToString
                End If
                datosNave = obj.getURLNave(idNav)
                If datosNave.Rows.Count > 0 Then
                    urlNave = datosNave.Rows(0).Item("url").ToString
                    nombreNave = datosNave.Rows(0).Item("nave_nombre").ToString
                End If
                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("PRODUCTOINGRESADOPRECIO")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre
                My.Computer.FileSystem.WriteAllText(archivo + ".mrt", EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load((archivo + ".mrt"))
                reporte.Compile()
                reporte.RegData(dtLista)
                reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte("urlNave") = urlNave
                reporte("nave") = nombreNave
                reporte("inicio") = dtpFechaInicio.Value
                reporte("fin") = dtpFechaFinal.Value
                reporte("pares") = lblPares.Text
                reporte("totalPagar") = lblTotal.Text
                reporte.Render()
                If accion = "imprimir" Then
                    reporte.Show()
                ElseIf accion = "enviar" Then
                    Dim d As DataTable = obj.getDestinatarios("ENVIO_PRODUCTOINGRESADOPRECIO")
                    If d.Rows.Count > 0 Then
                        Dim PdfExport As New StiPdfExportService()
                        Dim ruta As String
                        ruta = CrearPDF(PdfExport, 0, archivo, reporte)
                        EnviarCorreoArchivo((ruta))
                    Else
                        Dim adv As New AdvertenciaForm With {
                            .mensaje = "No existen destinatarios."
                        }
                        adv.ShowDialog()
                    End If
                End If
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                Dim adv As New AdvertenciaForm With {
                    .mensaje = "Surgió algo inesperado. Detalle: " & ex.ToString
                }
                adv.ShowDialog()
            End Try
        End If
    End Sub

    Public Sub ImprimirReporteAgrupado(accion As String)
        If grdListas.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor

            Dim ProductoIngresado = New DataSet("ProdIngresado")
            Dim dtTipoPedido = New DataTable("dtTipoPedido")
            Dim dtDatos = New DataTable
            Dim dtLista = New DataTable("dtLista")

            Dim datosNave As New DataTable()
            Dim idNav As Integer = 0
            Dim nombreNave As String = ""
            Dim urlNave As String = ""
            Dim semanas As String = String.Empty

            Dim obj As New ListaPreciosProdBU
            Try
                Cursor = Cursors.WaitCursor

                dtTipoPedido.Columns.Add("Tipo Pedido")
                dtTipoPedido.Rows.Add("PREVENDIDO")
                dtTipoPedido.Rows.Add("STOCK")
                dtTipoPedido.Rows.Add("")

                dtDatos = grdListas.DataSource
                dtLista = dtDatos.Copy

                If dtLista.Rows.Count > 0 Then
                    idNav = dtLista.Rows(0).Item("IdNave").ToString
                End If

                datosNave = obj.getURLNave(idNav)
                If datosNave.Rows.Count > 0 Then
                    urlNave = datosNave.Rows(0).Item("url").ToString
                    nombreNave = datosNave.Rows(0).Item("nave_nombre").ToString
                End If

                semanas = obj.ObtenerNumeroSemanas(dtpFechaInicio.Value, dtpFechaFinal.Value)

                dtLista.TableName = "dtLista"
                ProductoIngresado.Tables.Add(dtLista)
                ProductoIngresado.Tables.Add(dtTipoPedido)

                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("PRODUCTOINGRESADOPRECIO_AGRUPADO")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre
                My.Computer.FileSystem.WriteAllText(archivo + ".mrt", EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load((archivo + ".mrt"))
                reporte.Compile()
                reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte("urlNave") = urlNave
                reporte("nave") = nombreNave
                reporte("inicio") = dtpFechaInicio.Value
                reporte("fin") = dtpFechaFinal.Value
                reporte("pares") = lblPares.Text
                reporte("totalPagar") = lblTotal.Text
                reporte("Semanas") = semanas
                reporte.RegData(ProductoIngresado)
                reporte.Render()
                If accion = "imprimir" Then
                    reporte.Show()
                ElseIf accion = "enviar" Then
                    Dim d As DataTable = obj.getDestinatarios("PRODUCTOINGRESADOPRECIO_AGRUPADO")
                    If d.Rows.Count > 0 Then
                        Dim PdfExport As New StiPdfExportService()
                        Dim ruta As String
                        ruta = CrearPDF(PdfExport, 0, archivo, reporte)
                        EnviarCorreoArchivo((ruta))
                    Else
                        Dim adv As New AdvertenciaForm With {
                            .mensaje = "No existen destinatarios."
                        }
                        adv.ShowDialog()
                    End If
                End If
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                Dim adv As New AdvertenciaForm With {
                    .mensaje = "Surgió algo inesperado. Detalle: " & ex.ToString
                }
                adv.ShowDialog()
            End Try
        End If
    End Sub

    Private Sub BtnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        picEstado.Visible = True
        lblEstado.Visible = True
        btnEnviar.Enabled = False
        ImprimirReporteAgrupado("enviar")
    End Sub

    Private Function CrearPDF(PdfExport As StiPdfExportService, num As Integer, archivo As String, reporte As StiReport) As String
        Try
            PdfExport.ExportPdf(reporte, (archivo + num.ToString + ".pdf"))
        Catch ex As Exception
            num += 1
            CrearPDF(PdfExport, num, archivo, reporte)
        End Try
        Dim ruta As String
        ruta = archivo + num.ToString + ".pdf"
        Return ruta
    End Function

    Private Shared Sub SendCompletedCallback(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        'Get the unique identifier for this asynchronous operation.
        Dim token As String = CStr(e.UserState)
        Dim a As New AdvertenciaForm
        Dim x As New ExitoForm
        If e.Cancelled Then
            a.mensaje = "Mensaje cancelado."
            a.ShowDialog()
        End If
        If e.Error IsNot Nothing Then
            a.mensaje = " " + e.Error.ToString()
            a.ShowDialog()
        Else
            x.mensaje = "Mensaje enviado."
            x.ShowDialog()
        End If
        mailSent = True
        CType(sender, SmtpClient).Dispose()
    End Sub

    Public Sub EnviarCorreoArchivo(ByVal archivo As String)
        Dim mensaje As String = "Mensaje enviado correctamente"
        Dim cliente As New SmtpClient
        Dim smtp As New Entidades.SMTP
        Dim autenticacion As New Net.NetworkCredential("servicioselectronicos@grupoyuyin.com", "Yservicios2015@")
        cliente.Credentials = autenticacion
        cliente.Host = "pod51010.outlook.com"
        cliente.Port = 25
        cliente.EnableSsl = True
        Dim obj As New ListaPreciosProdBU
        Dim d As DataTable = obj.getDestinatarios("ENVIO_PRODUCTOINGRESADOPRECIO")

        If d.Rows.Count > 0 Then
            destinatarios = d.Rows(0).Item("envio_destinos").ToString()
        End If

        Dim mailMsg As New MailMessage()
        'Asigna los destinatarios.
        For Each mail As String In destinatarios.Split(New Char() {","c})
            mailMsg.To.Add(New MailAddress(mail))
        Next
        mailMsg.From = New MailAddress("servicioselectronicos@grupoyuyin.com")
        mailMsg.BodyEncoding = System.Text.Encoding.UTF8
        mailMsg.Body = "PRODUCTO INGRESADO POR MAQUILAS"
        mailMsg.Subject = "NOTIFICACIÓN DE PRODUCTO INGRESADO POR MAQUILAS"
        mailMsg.SubjectEncoding = System.Text.Encoding.UTF8
        Dim data = New Attachment(archivo, MediaTypeNames.Application.Octet)
        Dim disposition As ContentDisposition = data.ContentDisposition
        disposition.CreationDate = System.IO.File.GetCreationTime(archivo)
        disposition.ModificationDate = System.IO.File.GetLastWriteTime(archivo)
        disposition.ReadDate = System.IO.File.GetLastAccessTime(archivo)
        'Agregamos un archivo al correo 
        mailMsg.Attachments.Add(data)
        'mailMsg.IsBodyHtml = True
        AddHandler cliente.SendCompleted, AddressOf SendCompletedCallback
        Dim userState As String = "test message1"
        cliente.SendAsync(mailMsg, userState)
        If Not BackgroundWorker1.IsBusy Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub ProdIngresadoMaquilas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If mailSent = True Then
                mailSent = False
                picEstado.Visible = False
                lblEstado.Visible = False
                btnEnviar.Enabled = True
                Cursor = Cursors.Default
                BackgroundWorker1.CancelAsync()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If Not BackgroundWorker1.IsBusy Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            If mailSent = True Then
                mailSent = False
                picEstado.Visible = False
                lblEstado.Visible = False
                btnEnviar.Enabled = True
                Cursor = Cursors.Default
                BackgroundWorker1.CancelAsync()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GrdListas_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListas.ClickCell
        Try
            grdListas.ActiveRow.Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Public Function ValidarPreciosGrid() As Boolean
        Dim d As DataTable = grdListas.DataSource

        For Each row As DataRow In d.Rows
            If row("Precio") <= 0 Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles btnAgregarComp.Click
        If cmbNave.SelectedIndex > 0 Then
            Dim obj As New ListaPreciosProdBU
            Dim obj2 As New AgregarComprobanteBU

            If dtpFechaInicio.Text <> dtpFechaFinal.Text Then
                adv.mensaje = "Solo puede subir comprobantes de un solo día, se tomará la primera fecha seleccionada."
                adv.ShowDialog()
            End If

            If obj2.verificarFecha(dtpFechaInicio.Value, cmbNave.SelectedValue) Then
                Dim dat As DataTable = obj.getProductoTerminadoMaquila(cmbNave.SelectedValue, dtpFechaInicio.Value, dtpFechaInicio.Value)
                If dat.Rows.Count > 0 Then
                    If ValidarPreciosGrid() Then
                        Dim form As New AgregarComprobanteMaquila With {
                            .fecha = dtpFechaInicio.Value,
                            .nave = cmbNave.SelectedValue,
                            .nombreNave = obj.getNombreNave(cmbNave.SelectedValue)
                        }
                        form.ShowDialog()
                    Else
                        adv.mensaje = "Existen productos sin precios."
                        adv.ShowDialog()
                    End If
                Else
                    adv.mensaje = "No existe producto ingresado para esta fecha."
                    adv.ShowDialog()
                End If
            Else
                adv.mensaje = "Ya existen comprobantes para esta fecha."
                adv.ShowDialog()
            End If

        Else
            adv.mensaje = "Seleccione una nave."
            adv.ShowDialog()
        End If

    End Sub
End Class