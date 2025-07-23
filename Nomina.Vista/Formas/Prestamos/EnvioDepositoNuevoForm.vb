Imports Excel = Microsoft.Office.Interop.Excel
Imports Stimulsoft.Report
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class EnvioDepositoNuevoForm
    Public ListaDepositosEfectivo As New DataTable
    Public NaveID As Integer

    Dim nombreArchivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments.Trim + "\" + "CuentasBancarias.xlsx"

    Private Sub EnvioDepositoNuevoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            grdDepositos.DataSource = Nothing

            If ListaDepositosEfectivo.Rows.Count > 0 Then
                grdDepositos.DataSource = ListaDepositosEfectivo
                'grdDepositos.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
                grdDepositos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                grdDepositos.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
                grdDepositos.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
                grdDepositos.DisplayLayout.Bands(0).Override.CellClickAction = CellClickAction.RowSelect
                grdDepositos.DisplayLayout.Bands(0).Columns("Numero").Header.Caption = "#"

                grdDepositos.DisplayLayout.Bands(0).Columns("Numero").Width = 10
                grdDepositos.DisplayLayout.Bands(0).Columns("Cuenta").Width = 20
                grdDepositos.DisplayLayout.Bands(0).Columns("Total").Width = 25

                grdDepositos.DisplayLayout.Bands(0).Columns("Cuenta").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                grdDepositos.DisplayLayout.Bands(0).Columns("Total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

                grdDepositos.DisplayLayout.Bands(0).Columns("Total").Format = "###,###,##0"



                Dim sumTotal As SummarySettings = grdDepositos.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdDepositos.DisplayLayout.Bands(0).Columns("Total"))

                sumTotal.DisplayFormat = "{0:#,##0}"
                sumTotal.Appearance.TextHAlign = HAlign.Right
                sumTotal.Appearance.BackColor = Color.GreenYellow
                grdDepositos.DisplayLayout.Bands(0).SummaryFooterCaption = "Total"

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCncelar_Click(sender As Object, e As EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If ListaDepositosEfectivo.Rows.Count > 0 Then
            Me.Cursor = Cursors.WaitCursor
            Dim Total As Double = 0
            Dim ContadorFila As Integer = 0
            Dim Cuentas = New DataTable("Cuentas")
            With Cuentas
                .Columns.Add("Numero")
                .Columns.Add("Cuenta")
                .Columns.Add("Titular")
                .Columns.Add("Total", Type.GetType("System.Decimal"))
            End With

            For Each row As UltraGridRow In grdDepositos.Rows
                ContadorFila += 1
                Total += row.Cells("Total").Value
                Cuentas.Rows.Add(
                    ContadorFila,
                    row.Cells("Cuenta").Value,
                    row.Cells("Titular").Value,
                    row.Cells("Total").Value)
            Next
            Cuentas.Rows.Add("", "", "", Total.ToString("N0"))

            Dim OBJBU As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            EntidadReporte = OBJBU.LeerReporteporClave("NOM_ENV_CUEN_NUEVO")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport
            reporte.Load(archivo)
            reporte.Compile()
            reporte.RegData(Cuentas)
            reporte.Show()
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub btnenviar_Click(sender As Object, e As EventArgs) Handles btnenviar.Click
        Try
            My.Computer.FileSystem.DeleteFile(nombreArchivo)
        Catch ex As Exception
        End Try

        UltraGridExcelExporter1.Export(grdDepositos, nombreArchivo)

        System.Threading.Thread.Sleep(3000)

        enviar_correo(NaveID, "ENVIO_DEPOSITO_CUENTAS")
        Me.Close()

        Try
            My.Computer.FileSystem.DeleteFile(nombreArchivo)
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub UltraGridExcelExporter1_InitializeColumn(sender As Object, e As ExcelExport.InitializeColumnEventArgs) Handles UltraGridExcelExporter1.InitializeColumn
        e.ExcelFormatStr = e.Column.Format
    End Sub

    Private Sub enviar_correo(ByVal naveID As Integer, ByVal clave As String)
        Dim archivoAdjunto = New System.Net.Mail.Attachment(nombreArchivo)
        Dim Remitente As String = ""
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String
        Dim correo As New Tools.Correo
        Dim fecha As DateTime = Now.Date
        destinatarios = enviosCorreoBU.consulta_destinatarios_email(naveID, clave)

        Dim Email As String = ""
        Email += "<!DOCTYPE html>"
        Email += "<html> "
        Email += "<head> "
        Email += "<style type = '" + "text/css" + "'>"
        Email += "body {display: block; margin: 8px; background: #FFFFFF;}"
        Email += "#header{	position: absolute;"
        Email += "height: 62px;"
        Email += "top: 0;"
        Email += "left: 0;"
        Email += "right: 0;"
        Email += "color: #003366;"
        Email += "font-family: Arial, Helvetica, sans-serif;"
        Email += "font-size: 18px;"
        Email += "font-weight: bold;}"
        Email += "</style> "
        Email += "</head> "
        Email += "<body> "
        Email += "<div id='" + "header" + "' >"
        Email += "<h5>Atención: " + Remitente.ToString + "</h5>"
        Email += "<h5>Envio reporte de depósitos correspondiente al periodo " + Now.Date.ToShortDateString + " </h5>"
        Email += "<h5>Cualquier duda y/o comentario, quedo a sus ordenes. </h5>"
        Email += "<h5>Saludos.</h5>"
        Email += "</div>"
        Email += "</body> "
        Email += "</html> "

        correo.EnviarCorreoHtmlArchivoAdjunto(destinatarios, "say_depositos@grupoyuyin.com.mx", "Deposito a cuentas ", Email, archivoAdjunto)
    End Sub

End Class