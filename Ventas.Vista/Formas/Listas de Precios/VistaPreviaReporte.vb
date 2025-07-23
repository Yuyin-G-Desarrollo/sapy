Imports System.Net.Mail
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
Imports Infragistics.Documents

Public Class VistaPreviaReporte
    Public idlista As Int32
    Public nombreLista As String

    Private Sub btnPrueba_Click(sender As Object, e As EventArgs)
        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Credentials = New Net.NetworkCredential("username@gmail.com", "password")
        Smtp_Server.Port = 587
        Smtp_Server.EnableSsl = True
        Smtp_Server.Host = "smtp.gmail.com"

        e_mail = New MailMessage()
        e_mail.From = New MailAddress("gdesarrollo.ti@grupoyuyin.com.mx")
        e_mail.To.Add("gdesarrollo.ti@grupoyuyin.com.mx")
        e_mail.Subject = "Email Sending"
        e_mail.IsBodyHtml = False
        e_mail.Body = "Hola"
        Smtp_Server.Send(e_mail)
        MsgBox("Mail Sent")
    End Sub

    Public Sub llenarTablaPrevia()
        Dim dtTablaConcentradaUNO As New DataTable
        idlista = 7
        dtTablaConcentradaUNO.Columns.Add("Modelo")
        dtTablaConcentradaUNO.Columns.Add("Codigos")

        Dim objListasBu As New Negocios.ListaBaseBU
        Dim dtDatosColumasTallas As New DataTable
        dtDatosColumasTallas = objListasBu.VerTitulosTallas(idlista)

        Dim cont As Int32 = 1
        For Each rowD As DataRow In dtDatosColumasTallas.Rows
            dtTablaConcentradaUNO.Columns.Add(rowD.Item(0).ToString)
            cont = cont + 1
        Next

        Dim dtDatosTabla As New DataTable
        dtDatosTabla = objListasBu.VerModelosGrupo(idlista)
        Dim contTab As Int32 = 0

        Dim contFilas As Int32 = 0

        For Each rowDTT As DataRow In dtDatosTabla.Rows
            Dim contadorValida As Boolean = False

            If contTab = 0 Then
                dtTablaConcentradaUNO.Rows.Add()
                contFilas = contFilas + 1
                dtTablaConcentradaUNO.Rows(0)(0) = rowDTT.Item(1).ToString
                dtTablaConcentradaUNO.Rows(0)(1) = rowDTT.Item(2).ToString
                For Each colTT As DataColumn In dtTablaConcentradaUNO.Columns
                    If rowDTT.Item(7).ToString = colTT.Caption.ToString Then
                        dtTablaConcentradaUNO.Rows(0)(colTT.Caption.ToString) = rowDTT.Item(0).ToString
                    End If
                Next
            Else

                For i As Int32 = dtTablaConcentradaUNO.Rows.Count - 1 To 0 Step -1
                    Dim cosa As String = rowDTT.Item(1).ToString + "_     _" + rowDTT.Item(2).ToString
                    Dim cosaDos As String = dtTablaConcentradaUNO.Rows(i)(0).ToString + "        " + dtTablaConcentradaUNO.Rows(i)(1).ToString
                    If rowDTT.Item(1).ToString = dtTablaConcentradaUNO.Rows(i)(0).ToString And rowDTT.Item(2).ToString = dtTablaConcentradaUNO.Rows(i)(1).ToString Then
                        contadorValida = False
                        Dim contValidaContinua As Int32 = 0
                        For Each colTT As DataColumn In dtTablaConcentradaUNO.Columns
                            Dim nameCol As String = rowDTT.Item(7).ToString
                            If colTT.Caption.ToString = rowDTT.Item(7).ToString Then
                                Dim pres As String = rowDTT.Item(0).ToString
                                Dim presdos As String = dtTablaConcentradaUNO.Rows(i)("Modelo").ToString

                                If Not dtTablaConcentradaUNO.Rows(i)(colTT.Caption.ToString).ToString = "" Then
                                    If dtTablaConcentradaUNO.Rows(i)(colTT.Caption.ToString) = rowDTT.Item(0).ToString And dtTablaConcentradaUNO.Rows(i)("Modelo").ToString = rowDTT.Item(1).ToString Then
                                        contadorValida = False
                                        Exit For

                                    ElseIf dtTablaConcentradaUNO.Rows(i)(colTT.Caption.ToString).ToString <> "" And dtTablaConcentradaUNO.Rows(i)(colTT.Caption.ToString).ToString <> rowDTT.Item(0).ToString Then

                                        For Each contFilaIgual As DataRow In dtTablaConcentradaUNO.Rows
                                            If contFilaIgual.Item(colTT.Caption.ToString).ToString = "" And contFilaIgual.Item("Modelo").ToString = rowDTT.Item(1).ToString And contFilaIgual.Item("Codigos").ToString = rowDTT.Item(2).ToString Then
                                                contValidaContinua = contValidaContinua + 1
                                            End If
                                        Next

                                        If contValidaContinua = 0 Then
                                            dtTablaConcentradaUNO.Rows.Add()
                                            dtTablaConcentradaUNO.Rows(contFilas)(0) = rowDTT.Item(1).ToString
                                            dtTablaConcentradaUNO.Rows(contFilas)(1) = rowDTT.Item(2).ToString
                                            dtTablaConcentradaUNO.Rows(contFilas)(colTT.Caption.ToString) = rowDTT.Item(0).ToString
                                            contFilas = contFilas + 1
                                            contadorValida = False
                                            Exit For
                                        End If
                                    End If
                                Else
                                    dtTablaConcentradaUNO.Rows(i)(colTT.Caption.ToString) = rowDTT.Item(0).ToString
                                    contadorValida = False
                                    Exit For
                                End If
                            End If
                        Next
                        If contValidaContinua = 0 Then
                            Exit For
                        End If
                    Else
                        contadorValida = True
                        ' ''Exit For
                    End If
                Next

                If contadorValida = True Then
                    dtTablaConcentradaUNO.Rows.Add()
                    dtTablaConcentradaUNO.Rows(contFilas)(0) = rowDTT.Item(1).ToString
                    dtTablaConcentradaUNO.Rows(contFilas)(1) = rowDTT.Item(2).ToString

                    For Each colTab As DataColumn In dtTablaConcentradaUNO.Columns
                        If rowDTT.Item(7).ToString = colTab.Caption.ToString Then
                            dtTablaConcentradaUNO.Rows(contFilas)(colTab.Caption.ToString) = rowDTT.Item(0).ToString
                        End If
                    Next
                    contFilas = contFilas + 1
                End If

            End If
            contTab = contTab + 1
        Next
        'grdDatosGrupo.DataSource = dtTablaConcentradaUNO
        llenarTablaPreviaPasoDos(dtTablaConcentradaUNO)
    End Sub

    Public Sub llenarTablaPreviaPasoDos(ByVal tablaPrev As DataTable)
        Dim dtDatosPrevios As DataTable = tablaPrev
        Dim dtTablaNuevaDos As New DataTable
        Dim contInicial As Int32 = 0
        Dim contFilas As Int32 = 0
        For Each column As DataColumn In dtDatosPrevios.Columns
            dtTablaNuevaDos.Columns.Add(column.Caption.ToString)
        Next

        For Each rowDT As DataRow In dtDatosPrevios.Rows
            If contInicial = 0 Then
                dtTablaNuevaDos.Rows.Add()
                For Each column As DataColumn In dtDatosPrevios.Columns
                    dtTablaNuevaDos.Rows(0)(column.Caption.ToString) = dtDatosPrevios.Rows(0)(column.Caption.ToString)
                Next
                contInicial = contInicial + 1
                contFilas = contFilas + 1
            Else

                For i As Int32 = dtTablaNuevaDos.Rows.Count - 1 To 0 Step -1
                    Dim datoBool As Boolean = True

                    For Each column As DataColumn In dtDatosPrevios.Columns
                        If column.Caption.ToString <> "Codigos" And column.Caption.ToString <> "Modelo" Then

                            'Dim datoModelo As String = dtTablaNuevaDos.Rows(i)("Modelo").ToString + " " + rowDT.Item("Modelo").ToString
                            'Dim datos As String = dtTablaNuevaDos.Rows(i)(column.Caption.ToString).ToString + "" + rowDT.Item(column.Caption.ToString).ToString
                            If dtTablaNuevaDos.Rows(i)(column.Caption.ToString).ToString <> "" And rowDT.Item(column.Caption.ToString).ToString <> "" Then
                                If dtTablaNuevaDos.Rows(i)("Modelo").ToString = rowDT.Item("Modelo").ToString And dtTablaNuevaDos.Rows(i)(column.Caption.ToString).ToString = rowDT.Item(column.Caption.ToString).ToString Then
                                    datoBool = False
                                End If
                            End If
                        End If
                    Next

                    If datoBool = True Then

                        Dim conVAlidaIgual As Int32 = 0
                        For Each rowDTNvos As DataRow In dtDatosPrevios.Rows
                            For Each column As DataColumn In dtDatosPrevios.Columns

                                'Dim datoModelo As String = dtTablaNuevaDos.Rows(i)("Modelo").ToString + " " + rowDT.Item("Modelo").ToString
                                'Dim datos As String = dtTablaNuevaDos.Rows(i)(column.Caption.ToString).ToString + "" + rowDT.Item(column.Caption.ToString).ToString

                                If column.Caption.ToString <> "Codigos" And column.Caption.ToString <> "Modelo" Then

                                    If dtTablaNuevaDos.Rows(i)(column.Caption.ToString).ToString <> "" And rowDTNvos.Item(column.Caption.ToString).ToString <> "" Then

                                        If dtTablaNuevaDos.Rows(i)("Modelo").ToString = rowDTNvos.Item("Modelo").ToString And
                                            dtTablaNuevaDos.Rows(i)("Codigos").ToString <> rowDTNvos.Item("Codigos").ToString And
                                            dtTablaNuevaDos.Rows(i)(column.Caption.ToString).ToString = rowDTNvos.Item(column.Caption.ToString).ToString Then
                                            conVAlidaIgual = conVAlidaIgual + 1
                                        End If

                                    End If

                                End If
                            Next
                        Next
                        If conVAlidaIgual = 0 Then

                            dtTablaNuevaDos.Rows.Add()
                            For Each column As DataColumn In dtDatosPrevios.Columns
                                dtTablaNuevaDos.Rows(contFilas)(column.Caption.ToString) = rowDT.Item(column.Caption.ToString)
                            Next
                            contInicial = contInicial + 1
                            contFilas = contFilas + 1
                            Exit For
                        End If
                    Else
                        dtTablaNuevaDos.Rows(i)("Codigos") = dtTablaNuevaDos.Rows(i)("Codigos").ToString + ", " + rowDT.Item("Codigos").ToString

                        Exit For

                    End If
                Next
            End If
        Next
        llenarTablaPreviaPasoTRES(dtTablaNuevaDos)
    End Sub

    Public Sub llenarTablaPreviaPasoTRES(ByVal tablaPrev As DataTable)
        Dim dtDatosPrevios As DataTable = tablaPrev
        Dim dtTablaNuevaTres As New DataTable

        Dim contInicial As Int32 = 0
        Dim contFilas As Int32 = 0

        For Each column As DataColumn In dtDatosPrevios.Columns
            dtTablaNuevaTres.Columns.Add(column.Caption.ToString)
        Next

        For Each rowPrevia As DataRow In dtDatosPrevios.Rows

            If contInicial = 0 Then
                dtTablaNuevaTres.Rows.Add()

                For Each column As DataColumn In dtDatosPrevios.Columns
                    dtTablaNuevaTres.Rows(0)(column.Caption.ToString) = dtDatosPrevios.Rows(0)(column.Caption.ToString)
                Next

                contInicial = contInicial + 1
                contFilas = contFilas + 1

            Else

                For i As Int32 = dtTablaNuevaTres.Rows.Count - 1 To 0 Step -1

                    Dim validaSiguiente As Boolean = False

                    For Each column As DataColumn In dtDatosPrevios.Columns
                        If column.Caption.ToString <> "Modelo" And column.Caption.ToString <> "Codigos" Then
                            If dtTablaNuevaTres.Rows(i)("Modelo").ToString = rowPrevia.Item("Modelo").ToString Then
                                If dtTablaNuevaTres.Rows(i)(column.Caption.ToString).ToString = "" And rowPrevia.Item(column.Caption.ToString).ToString <> "" Then
                                    validaSiguiente = True
                                End If

                            End If
                        End If
                    Next

                    If validaSiguiente = True Then
                        dtTablaNuevaTres.Rows(i)("Codigos") = dtTablaNuevaTres.Rows(i)("Codigos").ToString + ", " + rowPrevia.Item("Codigos").ToString

                        For Each columnDT As DataColumn In dtDatosPrevios.Columns
                            If dtTablaNuevaTres.Rows(i)("Modelo").ToString = rowPrevia.Item("Modelo").ToString Then
                                If columnDT.Caption.ToString <> "Modelo" And columnDT.Caption.ToString <> "Codigos" Then

                                    If rowPrevia.Item(columnDT.Caption.ToString).ToString <> "" Then

                                        dtTablaNuevaTres.Rows(i)(columnDT.Caption.ToString) = rowPrevia.Item(columnDT.Caption.ToString).ToString
                                        'Else
                                        '    Exit For
                                    End If
                                End If
                            End If
                        Next
                        Exit For
                    Else

                        Dim contValidaIgual As Int32 = 0

                        For Each rowNVO As DataRow In dtTablaNuevaTres.Rows
                            For Each columnDT As DataColumn In dtDatosPrevios.Columns
                                If rowNVO.Item("Modelo").ToString = rowPrevia.Item("Modelo").ToString Then
                                    If columnDT.Caption.ToString <> "Modelo" And columnDT.Caption.ToString <> "Codigos" Then

                                        If dtTablaNuevaTres.Rows(i)(columnDT.Caption.ToString).ToString = "" And rowNVO.Item(columnDT.Caption.ToString).ToString <> "" Then
                                            contValidaIgual = contValidaIgual + 1
                                        End If

                                    End If
                                Else
                                    Exit For
                                End If
                Next
                        Next

                        If contValidaIgual = 0 Then
                            dtTablaNuevaTres.Rows.Add()
                            For Each columnNVO As DataColumn In dtDatosPrevios.Columns
                                dtTablaNuevaTres.Rows(contFilas)(columnNVO.Caption.ToString) = rowPrevia.Item(columnNVO.Caption.ToString)
                            Next
                            contInicial = contInicial + 1
                            contFilas = contFilas + 1
                            Exit For
                        Else
                        End If

                    End If
                    Exit For
                Next

            End If

        Next
        grdReporte.DataSource = dtTablaNuevaTres
    End Sub

    Private Sub VistaPreviaReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarTablaPrevia()
        'Dim objDatos As New Negocios.ListaBaseBU
        'Dim dtDatos As New DataTable
        'dtDatos = objDatos.verConsultaListaBaseAgrupada(idlista)
        'grdReporte.DataSource = dtDatos
        'grdReporte.DisplayLayout.Bands(0).Columns("piel_pielid").Hidden = True
        'grdReporte.DisplayLayout.Bands(0).Columns("color_colorid").Hidden = True
        'grdReporte.DisplayLayout.Bands(0).Columns("marc_marcaid").Hidden = True
        'grdReporte.DisplayLayout.Bands(0).Columns("cole_coleccionid").Hidden = True
        'grdReporte.DisplayLayout.Bands(0).Columns("piel_descripcion").Hidden = True
        'grdReporte.DisplayLayout.Bands(0).Columns("color_descripcion").Hidden = True
        'grdReporte.DisplayLayout.Bands(0).Columns("marc_descripcion").Hidden = True
        'grdReporte.DisplayLayout.Bands(0).Columns("cole_descripcion").Hidden = True

        'grdReporte.DisplayLayout.Bands(0).Columns("prod_descripcion").MergedCellStyle = MergedCellStyle.Always

        grdReporte.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdReporte.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        
    End Sub

    Private Sub lblCliente_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub
End Class