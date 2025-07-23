
Imports Excel = Microsoft.Office.Interop.Excel
Imports Stimulsoft.Report

Public Class EnvioDepositoForm

    Public ListaDepositosEfectivo As New List(Of Entidades.CalcularNominaReal)
    Public FechaInicio As DateTime
    Public FechaFin As DateTime
    Public NaveID As Integer

    Private Sub grdNumCuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            grdDeposito.Rows.Clear()
            Dim contador As Integer = 1
            Dim Total As Double = 0
            For Each fila As Entidades.CalcularNominaReal In ListaDepositosEfectivo
                grdDeposito.Rows.Add(contador.ToString, fila.PCuenta, fila.PColaborador.PNombre + " " + fila.PColaborador.PApaterno + " " + fila.PColaborador.PAmaterno, fila.PTotalEntregar.ToString("N0"))
                contador += 1
                Total += fila.PTotalEntregar
            Next
            grdDeposito.Rows.Add("", "", "", Total.ToString("N0"))
            grdDeposito.Rows(contador - 1).DefaultCellStyle.BackColor = Color.GreenYellow
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCncelar_Click(sender As Object, e As EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim contador As Integer = 0
        For Each row As DataGridViewRow In grdDeposito.Rows
            contador += 1
            Exit For
        Next

        If contador > 0 Then
            Dim Cuentas = New DataTable("Cuentas")
            With Cuentas
                .Columns.Add("Numero")
                .Columns.Add("Cuenta")
                .Columns.Add("Titular")
                .Columns.Add("Total")
            End With

            For Each row As DataGridViewRow In grdDeposito.Rows
                Cuentas.Rows.Add( _
row.Cells("clmConsecutivo").Value, _
row.Cells("clmNumCuenta").Value, _
row.Cells("clmTitular").Value, _
row.Cells("clmTotal").Value _
                )

            Next
            Me.Cursor = Cursors.WaitCursor
            Dim OBJBU As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            EntidadReporte = OBJBU.LeerReporteporClave("NOM_ENV_CUEN")
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
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments.Trim + "\" + "CuentasBancarias.xlsx")
        Catch ex As Exception
        End Try

        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        save.FileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments.Trim + "\" + "CuentasBancarias.xlsx"
        'Exportar_Excelprueba()
        Exportar_Excel(Me.grdDeposito, save.FileName)
        System.Threading.Thread.Sleep(3000)

        enviar_correo(NaveID, "ENVIO_DEPOSITO_CUENTAS")
        Me.Close()
        Try
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments.Trim + "\" + "CuentasBancarias.xlsx")
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub

   


    Private Sub enviar_correo(ByVal naveID As Integer, ByVal clave As String)

        Dim archivoAdjunto = New System.Net.Mail.Attachment(My.Computer.FileSystem.SpecialDirectories.MyDocuments.Trim + "\" + "CuentasBancarias.xlsx")


        Dim Remitente As String = ""
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String
        Dim correo As New Tools.Correo
        Dim fecha As DateTime = Now.Date
        destinatarios = enviosCorreoBU.consulta_destinatarios_email(naveID, clave)

        'If naveID = 43 Then
        '    Remitente = "CINTHYA MARGARITA RAMIREZ ORTIZ"
        'End If

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
        'Email += "<img src='" + "http://www.grupoyuyin.com.mx/GRUPO_YUYIN.jpg" + "''height='" + "57" + "' width='" + "125" + "'alt='" + "logo" + "'>"
        'Email += "<h2>Envio cuentas para depósito</h1>  "
        'Email += "<h5>Cuenta bancaria:" + Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString + " <h5>"
        'Email += "<h5>Nombre:" + Now.Date.ToShortDateString.ToString + "<h5>"
        Email += "<h5>Atención: " + Remitente.ToString + "</h5>"
        Email += "<h5>Envio reporte de depósitos correspondiente al periodo " + Now.Date.ToShortDateString + " </h5>"
        Email += "<h5>Cualquier duda y/o comentario, quedo a sus ordenes. </h5>"
        Email += "<h5>Saludos.</h5>"
        Email += "</div>"
        Email += "</body> "
        Email += "</html> "

        correo.EnviarCorreoHtmlArchivoAdjunto(destinatarios, "say_depositos@grupoyuyin.com.mx", "Deposito a cuentas ", Email, archivoAdjunto)
    End Sub

    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal ruta As String)
        Dim appXL As Excel.Application
        Dim wbXl As Excel.Workbook
        Dim shXL As Excel.Worksheet
        Dim raXL As Excel.Range
        ' Start Excel and get Application object.
        appXL = CreateObject("Excel.Application")
        appXL.Visible = False
        ' Add a new workbook.
        wbXl = appXL.Workbooks.Add
        shXL = wbXl.ActiveSheet

        'exportamos los caracteres de las columnas 
        For c As Integer = 0 To grdDeposito.Columns.Count - 1
            shXL.Cells(1, c + 1).value = grdDeposito.Columns(c).HeaderText
        Next
        With shXL.Range("A1", "D1")
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With

        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grdDeposito.RowCount - 1
            For c As Integer = 0 To grdDeposito.Columns.Count - 1
                shXL.Cells(r + 2, c + 1).value = grdDeposito.Item(c, r).Value
            Next
        Next
        raXL = shXL.Range("A1", "D1")
        raXL.EntireColumn.AutoFit()
        raXL = shXL.Range("B1", "B1")
        raXL.EntireColumn.NumberFormat = "#"
        'guardamos la hoja de calculo en la ruta especificada 
        'wbXl.SaveAs("c:\vb.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal)

        'wbXl.Close(True)

        'wbXl.Quit()


        Try
            wbXl.SaveAs(ruta)
            wbXl = Nothing
            shXL = Nothing
            raXL = Nothing
            appXL.Quit()
            appXL = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

  
End Class