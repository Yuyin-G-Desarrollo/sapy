Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ReportesVistaPrevia

    Public Function Imprimir(ByVal vReporte As ReportDocument, Optional ByVal ParamNombres As String = "", Optional ByVal ParamValores As String = "", Optional ByVal ParamTipos As String = "", Optional ByVal vExpPDF As Boolean = False, Optional ByVal vExpEXCEL As Boolean = False) As Boolean
        Try
            Dim i As Int32 = 0
            Dim Parametro As String = ""

            If ParamNombres.Length > 0 Then
                Dim ListNombresParametros As List(Of String) = ParamNombres.Split("|").ToList()
                Dim ListValoresParametros As List(Of String) = ParamValores.Split("|").ToList()
                Dim ListTiposParametros As List(Of String) = ParamTipos.Split("|").ToList()

                For Each Parametro In ListNombresParametros
                    vReporte.SetParameterValue(Parametro.ToString, ConvertirTipos(ListValoresParametros(i).ToString, ListTiposParametros(i).ToString))
                    i += 1
                Next

            End If

            vReporte.SetDatabaseLogon("sa", "poder335")

            If vExpPDF Then
                Dim sfd As New SaveFileDialog()
                sfd.Filter = "Documento PDF|*.pdf"
                sfd.Title = "Exportar Reporte"
                Dim dlgResult As DialogResult = sfd.ShowDialog()

                If dlgResult = Windows.Forms.DialogResult.OK Then
                    If sfd.FileName <> "" Then
                        vReporte.ExportToDisk(ExportFormatType.PortableDocFormat, sfd.FileName)
                        'vReporte.ExportToDisk(ExportFormatType.Excel, sfd.FileName)
                        MessageBox.Show("Reporte exportado correctamente.", "Exportar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Imprimir = False
                    End If
                End If
            ElseIf vExpEXCEL Then
                Dim sfd As New SaveFileDialog()
                sfd.Filter = "Documento EXCEL|*.xls"
                sfd.Title = "Exportar Reporte"
                Dim dlgResult As DialogResult = sfd.ShowDialog()

                If dlgResult = Windows.Forms.DialogResult.OK Then
                    If sfd.FileName <> "" Then
                        vReporte.ExportToDisk(ExportFormatType.Excel, sfd.FileName)
                        MessageBox.Show("Reporte exportado correctamente.", "Exportar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Imprimir = False
                    End If
                End If
            Else
                crvreporte.ReportSource = vReporte
                crvreporte.Refresh()
                Imprimir = True
            End If

        Catch ex As Exception
            MessageBox.Show("Error al intentar imprimir." + ControlChars.CrLf + "Codigo de Error: " + ex.Message.ToString, "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Imprimir = False
        End Try

    End Function

    Public Function Imprimir(ByVal vReporte As ReportDocument, ByVal vDatatable As DataTable, Optional ByVal vExpPDF As Boolean = False, Optional ByVal vExpEXCEL As Boolean = False) As Boolean
        Try

            If vDatatable.Rows.Count > 0 Then

                vReporte.SetDataSource(vDatatable)

                If vExpPDF Then
                    Dim sfd As New SaveFileDialog()
                    sfd.Filter = "Documento PDF|*.pdf"
                    sfd.Title = "Exportar Reporte"
                    Dim dlgResult As DialogResult = sfd.ShowDialog()

                    If dlgResult = Windows.Forms.DialogResult.OK Then
                        If sfd.FileName <> "" Then
                            vReporte.ExportToDisk(ExportFormatType.PortableDocFormat, sfd.FileName)
                            'vReporte.ExportToDisk(ExportFormatType.Excel, sfd.FileName)
                            MessageBox.Show("Reporte exportado correctamente.", "Exportar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Imprimir = False
                        End If
                    End If
                ElseIf vExpEXCEL Then
                    Dim sfd As New SaveFileDialog()
                    sfd.Filter = "Documento EXCEL|*.xls"
                    sfd.Title = "Exportar Reporte"
                    Dim dlgResult As DialogResult = sfd.ShowDialog()

                    If dlgResult = Windows.Forms.DialogResult.OK Then
                        If sfd.FileName <> "" Then
                            vReporte.ExportToDisk(ExportFormatType.Excel, sfd.FileName)
                            MessageBox.Show("Reporte exportado correctamente.", "Exportar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Imprimir = False
                        End If
                    End If
                Else
                    crvreporte.ReportSource = vReporte
                    crvreporte.Refresh()
                    Imprimir = True
                End If
            Else
                Imprimir = False
            End If
        Catch ex As Exception
            MessageBox.Show("Error al intentar imprimir." + ControlChars.CrLf + "Codigo de Error: " + ex.Message.ToString, "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Imprimir = False
        End Try

    End Function

    Private Function ConvertirTipos(ByVal Valor As String, ByVal Tipo As String) As Object

        Select Case Tipo
            Case "Entero"
                ConvertirTipos = CInt(Valor)

            Case "Largo"
                ConvertirTipos = CLng(Valor)
            Case "Double"
                ConvertirTipos = CDbl(Valor)
            Case "Cadena"
                ConvertirTipos = CStr(Valor)
            Case "Fecha"
                ConvertirTipos = CDate(Valor)
        End Select

    End Function




    Public Function ImprimirYuyinERP(ByVal vReporte As ReportDocument, Optional ByVal ParamNombres As String = "", Optional ByVal ParamValores As String = "", Optional ByVal ParamTipos As String = "", Optional ByVal vExpPDF As Boolean = False, Optional ByVal vExpEXCEL As Boolean = False) As Boolean
        ImprimirYuyinERP = False
        Try
            Dim i As Int32 = 0
            Dim Parametro As String = ""

            If ParamNombres.Length > 0 Then
                Dim ListNombresParametros As List(Of String) = ParamNombres.Split("|").ToList()
                Dim ListValoresParametros As List(Of String) = ParamValores.Split("|").ToList()
                Dim ListTiposParametros As List(Of String) = ParamTipos.Split("|").ToList()

                For Each Parametro In ListNombresParametros
                    vReporte.SetParameterValue(Parametro.ToString, ConvertirTipos(ListValoresParametros(i).ToString, ListTiposParametros(i).ToString))
                    i += 1
                Next

            End If

            vReporte.SetDatabaseLogon("say", "Yuyin2017")

            If vExpPDF Then
                Dim sfd As New SaveFileDialog()
                sfd.Filter = "Documento PDF|*.pdf"
                sfd.Title = "Exportar Reporte"
                Dim dlgResult As DialogResult = sfd.ShowDialog()

                If dlgResult = Windows.Forms.DialogResult.OK Then
                    If sfd.FileName <> "" Then
                        vReporte.ExportToDisk(ExportFormatType.PortableDocFormat, sfd.FileName)
                        'vReporte.ExportToDisk(ExportFormatType.Excel, sfd.FileName)
                        MessageBox.Show("Reporte exportado correctamente.", "Exportar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ImprimirYuyinERP = False
                    End If
                End If
            ElseIf vExpEXCEL Then
                Dim sfd As New SaveFileDialog()
                sfd.Filter = "Documento EXCEL|*.xls"
                sfd.Title = "Exportar Reporte"
                Dim dlgResult As DialogResult = sfd.ShowDialog()

                If dlgResult = Windows.Forms.DialogResult.OK Then
                    If sfd.FileName <> "" Then
                        vReporte.ExportToDisk(ExportFormatType.Excel, sfd.FileName)
                        MessageBox.Show("Reporte exportado correctamente.", "Exportar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ImprimirYuyinERP = False
                    End If
                End If
            Else
                crvreporte.ReportSource = vReporte
                crvreporte.Refresh()
                ImprimirYuyinERP = True
            End If

        Catch ex As Exception
            MessageBox.Show("Error al intentar imprimir." + ControlChars.CrLf + "Codigo de Error: " + ex.Message.ToString, "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ImprimirYuyinERP = False
        End Try
        Return ImprimirYuyinERP
    End Function




End Class