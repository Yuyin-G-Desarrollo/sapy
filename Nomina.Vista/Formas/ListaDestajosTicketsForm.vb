Imports Infragistics.Documents.Excel
Imports Stimulsoft.Report
Imports Tools

Public Class ListaDestajosTicketsForm
    Dim Consecutivoin, Descendente As Int32
    Dim Colaboradorid, PeriodoNominaid As Int32
    Dim SumaTotal As Double
    Dim NombreColaborador As String = String.Empty

    Private Sub ListaDestajosTicketsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        grdDestajos.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDestajos.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDestajos.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDestajos.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDestajos.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDestajos.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDestajos.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)
        Try
            If cmbNave.Items.Count = 2 Then
            Else
                cmbNave.SelectedIndex = 0
                If cmbNave.SelectedIndex >= 0 Then
                    cboxPeriodo = Controles.ComboPeriodoSegunNaveSegunAsistencia(cboxPeriodo, cmbNave.SelectedValue)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdDestajos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDestajos.CellClick
        If e.RowIndex >= 0 Then
            Colaboradorid = CInt(grdDestajos.Rows(e.RowIndex).Cells("idColaborador").Value)
            NombreColaborador = CStr(grdDestajos.Rows(e.RowIndex).Cells("Nombre").Value)
        End If
    End Sub

    Private Sub grdDestajos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDestajos.DoubleClick
        If cboxPeriodo.SelectedIndex >= 0 Then
            PeriodoNominaid = cboxPeriodo.SelectedValue

            Dim TicketsPorColaborador As New ListaTicketsColaboradorForm
            TicketsPorColaborador.PColaboradorid = Colaboradorid
            TicketsPorColaborador.PPeriocoNomina = PeriodoNominaid
            TicketsPorColaborador.lblColaborador.Text = NombreColaborador
            TicketsPorColaborador.ShowDialog()
        End If

    End Sub

    Private Sub cmbNave_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
        listado_periodos_asistencia()
    End Sub

    Public Sub llenartabla()

        Dim ListaColaboradoresTickets As New List(Of Entidades.Ticket)
        Dim objBU As New Negocios.TicketsBU
        Consecutivoin = 1
        Dim nave As New Int32

        ListaColaboradoresTickets = objBU.ListaTotalesColaboradoresTickets(cboxPeriodo.SelectedValue, txtBuscarNombreIncentivo.Text)
        Descendente = ListaColaboradoresTickets.Count
        For Each objeto As Entidades.Ticket In ListaColaboradoresTickets


            AgregarFila(objeto)
            Consecutivoin += 1
            Descendente -= 1
        Next



    End Sub


    Public Sub AgregarFila(ByVal Ticket As Entidades.Ticket)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow



        celda = New DataGridViewTextBoxCell
        celda.Value = Ticket.PIDColaborador.PColaboradorid
        fila.Cells.Add(celda)

        'celda = New DataGridViewTextBoxCell
        'celda.Value = Ticket.PNombreColaborador
        'fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Consecutivoin
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Ticket.PNombreColaborador
        fila.Cells.Add(celda)

        Dim Area As New Entidades.Areas
        Area = Ticket.PArea
        celda = New DataGridViewTextBoxCell
        celda.Value = Area.PNombre
        fila.Cells.Add(celda)

        Dim Departamento As New Entidades.Departamentos
        Departamento = Ticket.PDepartamento
        celda = New DataGridViewTextBoxCell
        celda.Value = Departamento.DNombre
        fila.Cells.Add(celda)

        Dim Celula As New Entidades.Celulas
        Celula = Ticket.PCelula
        celda = New DataGridViewTextBoxCell
        Try
            celda.Value = Celula.PNombre
        Catch ex As Exception

        End Try

        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Ticket.PTotalTickets
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Ticket.PMontoTotal
        fila.Cells.Add(celda)
        SumaTotal += Ticket.PMontoTotal


        grdDestajos.Rows.Add(fila)



    End Sub

    Private Sub btnFiltrarSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrarSolicitud.Click
        Me.Cursor = Cursors.WaitCursor
        SumaTotal = 0
        grdDestajos.Rows.Clear()
        llenartabla()
        lblTotal.Text = " Total $ " + FormatNumber(SumaTotal, 2).ToString
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboxPeriodo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxPeriodo.SelectedIndexChanged
        If cboxPeriodo.SelectedIndex > 0 Then
            PeriodoNominaid = cboxPeriodo.SelectedValue
        End If

    End Sub

    Private Sub listado_periodos_asistencia()
        Try

            cboxPeriodo.DataSource = Nothing
            Dim objBU As New Negocios.ControlDePeriodoBU
            Dim tabla As New DataTable

            tabla = objBU.buscarPeriodoSegunNaves_PeriodoActual_Hacia_Atras(cmbNave.SelectedValue.ToString)
            tabla.Rows.InsertAt(tabla.NewRow, 0)
            cboxPeriodo.DisplayMember = "pnom_Concepto"
            cboxPeriodo.ValueMember = "pnom_PeriodoNomId"
            cboxPeriodo.DataSource = tabla
            cboxPeriodo.SelectedValue = 0

            Dim periodoNominaID As Integer = objBU.periodoSegunNaveSegunAsistenciaActual(cmbNave.SelectedValue.ToString).Rows(0).Item(0).ToString

            cboxPeriodo.SelectedValue = periodoNominaID
            cboxPeriodo.SelectedItem = cboxPeriodo.SelectedValue
        Catch
        End Try
    End Sub

    Private Sub btnLimpiarSolicitudes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarSolicitudes.Click
        grdDestajos.Rows.Clear()
        txtBuscarNombreIncentivo.Text = ""
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        gpbFiltroIncentivos.Height = 45
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        gpbFiltroIncentivos.Height = 102
    End Sub


    Private Sub pnlListaPaises_Paint(sender As Object, e As PaintEventArgs) Handles pnlListaPaises.Paint

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim advertencias As New AdvertenciaForm
        Cursor = Cursors.WaitCursor
        CMS_Exportar.Show(MousePosition)
        Cursor = Cursors.Default

    End Sub

    Private Sub PorColaboradorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorColaboradorToolStripMenuItem.Click
        Dim Advertencia As New AdvertenciaForm
        Dim ColaboradorLabID As Integer
        Dim PeriodoNomina As Integer

        ColaboradorLabID = Colaboradorid
        PeriodoNomina = PeriodoNominaid

        If ColaboradorLabID <> 0 And PeriodoNominaid <> 0 Then
            Dim sfd As New SaveFileDialog
            Dim tablaDatos As DataTable
            Dim workbook As New Infragistics.Documents.Excel.Workbook
            Dim worksheet As Infragistics.Documents.Excel.Worksheet = workbook.Worksheets.Add("Colaborador")

            'tbaFracciones = recorrerYgenerarNuevaTablaFracciones()

            sfd.DefaultExt = "xls"
            sfd.Filter = "Excel Files|*.xls"

            Dim result As DialogResult = sfd.ShowDialog()
            Dim fileName As String = sfd.FileName
            If result = Windows.Forms.DialogResult.OK Then
                Try
                    Me.Cursor = Cursors.WaitCursor

                    'ultExportGrid.Export(recorrerYgenerarNuevaTablaFracciones(), fileName)

                    tablaDatos = recorrerYgenerarNuevaTabla(ColaboradorLabID, PeriodoNomina)

                    worksheet.Columns.Item(0).Width = 2520
                    worksheet.Columns.Item(1).Width = 4650
                    worksheet.Columns.Item(2).Width = 6650
                    worksheet.Columns.Item(3).Width = 6650

                    worksheet.Columns.Item(4).Width = 6650
                    worksheet.Columns.Item(5).Width = 3325
                    worksheet.Columns.Item(6).Width = 3325
                    worksheet.Columns.Item(7).Width = 6650

                    'worksheet.Columns.Item(4).Width = 6650
                    'worksheet.Columns.Item(5).Width = 5650
                    'worksheet.Columns.Item(6).Width = 2920
                    'worksheet.Columns.Item(7).Width = 2920
                    'worksheet.Columns.Item(8).Width = 2920

                    worksheet.Columns.Item(8).Width = 6650
                    worksheet.Columns.Item(9).Width = 5650
                    worksheet.Columns.Item(10).Width = 6650
                    worksheet.Columns.Item(11).Width = 5650
                    worksheet.Columns.Item(12).Width = 2920
                    worksheet.Columns.Item(13).Width = 2920
                    worksheet.Columns.Item(14).Width = 2920

                    Dim inicio As Integer = 0

                    worksheet.Rows.Item(inicio).Cells.Item(0).Value = tablaDatos.Columns(0).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(1).Value = tablaDatos.Columns(1).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(2).Value = tablaDatos.Columns(2).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(3).Value = tablaDatos.Columns(3).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(4).Value = tablaDatos.Columns(4).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(5).Value = tablaDatos.Columns(5).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(6).Value = tablaDatos.Columns(6).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(7).Value = tablaDatos.Columns(7).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(8).Value = tablaDatos.Columns(8).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(9).Value = tablaDatos.Columns(9).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(10).Value = tablaDatos.Columns(10).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(11).Value = tablaDatos.Columns(11).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(12).Value = tablaDatos.Columns(12).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(13).Value = tablaDatos.Columns(13).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(14).Value = tablaDatos.Columns(14).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(15).Value = tablaDatos.Columns(15).ColumnName.ToString()

                    For r As Integer = (0) To tablaDatos.Rows.Count - 1
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = tablaDatos.Rows(r).Item("No").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(1).Value = tablaDatos.Rows(r).Item("Numero de ticket").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = tablaDatos.Rows(r).Item("Colaborador").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(3).Value = tablaDatos.Rows(r).Item("Departamento").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = tablaDatos.Rows(r).Item("Celula").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = tablaDatos.Rows(r).Item("Fecha captura").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = tablaDatos.Rows(r).Item("Fecha programa").ToString()

                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(7).Value = tablaDatos.Rows(r).Item("Lote").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = tablaDatos.Rows(r).Item("Modelo Sicy").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(9).Value = tablaDatos.Rows(r).Item("Coleccion").ToString()

                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = tablaDatos.Rows(r).Item("Descripción").ToString()
                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = tablaDatos.Rows(r).Item("Observación").ToString()
                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = tablaDatos.Rows(r).Item("Costo partida").ToString()
                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(7).Value = tablaDatos.Rows(r).Item("Número de pares").ToString()
                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = tablaDatos.Rows(r).Item("Total").ToString()

                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(10).Value = tablaDatos.Rows(r).Item("Descripción").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(11).Value = tablaDatos.Rows(r).Item("Observación").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(12).Value = tablaDatos.Rows(r).Item("Costo partida").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(13).Value = tablaDatos.Rows(r).Item("Número de pares").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = tablaDatos.Rows(r).Item("Total").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(15).Value = tablaDatos.Rows(r).Item("Tiempo").ToString()

                    Next

                    For i As Int16 = inicio To inicio Step 1
                        For j As Int16 = 0 To 14 Step 1
                            worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.LightGray), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        Next
                    Next

                    For i As Int16 = 0 To tablaDatos.Rows.Count - 1 Step 1
                        For j As Int16 = 0 To 14 Step 1

                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        Next
                    Next


                    workbook.Save(fileName)

                    Dim objMensajeExito As New Tools.ExitoForm
                    objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                    objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                    objMensajeExito.ShowDialog()
                    Process.Start(fileName)
                Catch ex As Exception
                    Dim objMensajeError As New Tools.ErroresForm
                    objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                    objMensajeError.StartPosition = FormStartPosition.CenterScreen
                    objMensajeError.ShowDialog()
                End Try
            End If
            Me.Cursor = Cursors.Default
        Else
            Advertencia.mensaje = "Debe seleccionar un colaborador."
            Advertencia.ShowDialog()
        End If

    End Sub

    Private Function recorrerYgenerarNuevaTabla(ByVal Colaborador, Periodo)
        Dim tablaNuevaDestajos As New DataTable
        Dim tablaDestajos As DataTable
        Dim contadorLineas As Integer = 0

        Dim ObjBU As New Negocios.TicketsBU
        tablaDestajos = ObjBU.ConsultarTicketsPorColaboradorPeriodo(Colaborador, Periodo)

        tablaNuevaDestajos.Columns.Add("No")
        tablaNuevaDestajos.Columns.Add("Numero de ticket")
        tablaNuevaDestajos.Columns.Add("Colaborador")
        tablaNuevaDestajos.Columns.Add("Departamento")
        tablaNuevaDestajos.Columns.Add("Celula")
        tablaNuevaDestajos.Columns.Add("Fecha captura")
        tablaNuevaDestajos.Columns.Add("Fecha programa")
        tablaNuevaDestajos.Columns.Add("Lote")
        tablaNuevaDestajos.Columns.Add("Modelo Sicy")
        tablaNuevaDestajos.Columns.Add("Coleccion")
        tablaNuevaDestajos.Columns.Add("Descripción")
        tablaNuevaDestajos.Columns.Add("Observación")
        tablaNuevaDestajos.Columns.Add("Costo partida")
        tablaNuevaDestajos.Columns.Add("Número de pares")
        tablaNuevaDestajos.Columns.Add("Total")
        tablaNuevaDestajos.Columns.Add("Tiempo")

        For i As Integer = 0 To tablaDestajos.Rows.Count - 1
            If tablaDestajos.Rows(i).Item("Ticket").ToString() <> "" Then
                contadorLineas = contadorLineas + 1
                tablaNuevaDestajos.Rows.Add(New Object() {contadorLineas, tablaDestajos.Rows(i).Item("Ticket").ToString(),
                                            tablaDestajos.Rows(i).Item("Nombre").ToString(), tablaDestajos.Rows(i).Item("Departamento").ToString(), tablaDestajos.Rows(i).Item("Celula").ToString(),
                                            Convert.ToDateTime(tablaDestajos.Rows(i).Item("Fecha")).ToShortDateString(), Convert.ToDateTime(tablaDestajos.Rows(i).Item("FechaPrograma")).ToShortDateString(), tablaDestajos.Rows(i).Item("Lote").ToString(), tablaDestajos.Rows(i).Item("ModeloSICY").ToString(), tablaDestajos.Rows(i).Item("Coleccion").ToString(), tablaDestajos.Rows(i).Item("Descripcion").ToString(), tablaDestajos.Rows(i).Item("Observaciones"), tablaDestajos.Rows(i).Item("CostoPar").ToString(), tablaDestajos.Rows(i).Item("Pares").ToString(), tablaDestajos.Rows(i).Item("MontoTicket").ToString(), tablaDestajos.Rows(i).Item("Tiempo").ToString()})
            End If
        Next
        Return tablaNuevaDestajos
    End Function

    Private Sub PorNaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorNaveToolStripMenuItem.Click
        Dim Advertencia As New AdvertenciaForm
        Dim Periodo = cboxPeriodo.SelectedValue

        If Periodo <> 0 Then
            Dim sfd As New SaveFileDialog
            Dim tablaDatos As DataTable
            Dim workbook As New Infragistics.Documents.Excel.Workbook
            Dim worksheet As Infragistics.Documents.Excel.Worksheet = workbook.Worksheets.Add("Nave")

            sfd.DefaultExt = "xls"
            sfd.Filter = "Excel Files|*.xls"

            Dim result As DialogResult = sfd.ShowDialog()
            Dim fileName As String = sfd.FileName
            If result = Windows.Forms.DialogResult.OK Then
                Try
                    Me.Cursor = Cursors.WaitCursor

                    tablaDatos = recorrerYgenerarPorNave(Periodo)

                    worksheet.Columns.Item(0).Width = 2520
                    worksheet.Columns.Item(1).Width = 4650
                    worksheet.Columns.Item(2).Width = 6650
                    worksheet.Columns.Item(3).Width = 6650

                    worksheet.Columns.Item(4).Width = 6650
                    worksheet.Columns.Item(5).Width = 3325
                    worksheet.Columns.Item(6).Width = 6650
                    worksheet.Columns.Item(7).Width = 6650

                    'worksheet.Columns.Item(4).Width = 6650
                    'worksheet.Columns.Item(5).Width = 5650
                    'worksheet.Columns.Item(6).Width = 2920
                    'worksheet.Columns.Item(7).Width = 2920
                    'worksheet.Columns.Item(8).Width = 2920

                    worksheet.Columns.Item(8).Width = 6650
                    worksheet.Columns.Item(9).Width = 5650
                    worksheet.Columns.Item(10).Width = 6650
                    worksheet.Columns.Item(11).Width = 5650
                    worksheet.Columns.Item(12).Width = 2920
                    worksheet.Columns.Item(13).Width = 2920
                    worksheet.Columns.Item(14).Width = 2920

                    Dim inicio As Integer = 0

                    worksheet.Rows.Item(inicio).Cells.Item(0).Value = tablaDatos.Columns(0).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(1).Value = tablaDatos.Columns(1).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(2).Value = tablaDatos.Columns(2).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(3).Value = tablaDatos.Columns(3).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(4).Value = tablaDatos.Columns(4).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(5).Value = tablaDatos.Columns(5).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(6).Value = tablaDatos.Columns(6).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(7).Value = tablaDatos.Columns(7).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(8).Value = tablaDatos.Columns(8).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(9).Value = tablaDatos.Columns(9).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(10).Value = tablaDatos.Columns(10).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(11).Value = tablaDatos.Columns(11).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(12).Value = tablaDatos.Columns(12).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(13).Value = tablaDatos.Columns(13).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(14).Value = tablaDatos.Columns(14).ColumnName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(15).Value = tablaDatos.Columns(15).ColumnName.ToString()

                    For r As Integer = (0) To tablaDatos.Rows.Count - 1
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = tablaDatos.Rows(r).Item("No").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(1).Value = tablaDatos.Rows(r).Item("Numero de ticket").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = tablaDatos.Rows(r).Item("Colaborador").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(3).Value = tablaDatos.Rows(r).Item("Departamento").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = tablaDatos.Rows(r).Item("Celula").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = tablaDatos.Rows(r).Item("Fecha captura").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = tablaDatos.Rows(r).Item("Fecha Programa").ToString()

                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(7).Value = tablaDatos.Rows(r).Item("Lote").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = tablaDatos.Rows(r).Item("Modelo Sicy").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(9).Value = tablaDatos.Rows(r).Item("Coleccion").ToString()

                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = tablaDatos.Rows(r).Item("Descripción").ToString()
                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = tablaDatos.Rows(r).Item("Observación").ToString()
                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = tablaDatos.Rows(r).Item("Costo partida").ToString()
                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(7).Value = tablaDatos.Rows(r).Item("Número de pares").ToString()
                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = tablaDatos.Rows(r).Item("Total").ToString()

                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(10).Value = tablaDatos.Rows(r).Item("Descripción").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(11).Value = tablaDatos.Rows(r).Item("Observación").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(12).Value = tablaDatos.Rows(r).Item("Costo partida").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(13).Value = tablaDatos.Rows(r).Item("Número de pares").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = tablaDatos.Rows(r).Item("Total").ToString()
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(15).Value = tablaDatos.Rows(r).Item("tiempo").ToString()
                    Next

                    For i As Int16 = inicio To inicio Step 1
                        For j As Int16 = 0 To 14 Step 1
                            worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.LightGray), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        Next
                    Next

                    For i As Int16 = 0 To tablaDatos.Rows.Count - 1 Step 1
                        For j As Int16 = 0 To 14 Step 1

                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        Next
                    Next


                    workbook.Save(fileName)

                    Dim objMensajeExito As New Tools.ExitoForm
                    objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                    objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                    objMensajeExito.ShowDialog()
                    Process.Start(fileName)
                Catch ex As Exception
                    Dim objMensajeError As New Tools.ErroresForm
                    objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                    objMensajeError.StartPosition = FormStartPosition.CenterScreen
                    objMensajeError.ShowDialog()
                End Try
            End If
            Me.Cursor = Cursors.Default
        Else
            Advertencia.mensaje = "Debe seleccionar una nave."
            Advertencia.ShowDialog()
        End If
    End Sub

    Public Function recorrerYgenerarPorNave(ByVal Periodo As Integer)
        Dim tablaNuevaDestajos As New DataTable
        Dim tablaDestajos As DataTable
        Dim contadorLineas As Integer = 0

        Dim ObjBU As New Negocios.TicketsBU
        tablaDestajos = ObjBU.ConsultarTicketsPorNavePeriodo(Periodo)

        tablaNuevaDestajos.Columns.Add("No")
        tablaNuevaDestajos.Columns.Add("Numero de ticket")
        tablaNuevaDestajos.Columns.Add("Colaborador")
        tablaNuevaDestajos.Columns.Add("Departamento")
        tablaNuevaDestajos.Columns.Add("Celula")
        tablaNuevaDestajos.Columns.Add("Fecha captura")
        tablaNuevaDestajos.Columns.Add("Fecha Programa")
        tablaNuevaDestajos.Columns.Add("Lote")
        tablaNuevaDestajos.Columns.Add("Modelo Sicy")
        tablaNuevaDestajos.Columns.Add("Coleccion")
        tablaNuevaDestajos.Columns.Add("Descripción")
        tablaNuevaDestajos.Columns.Add("Observación")
        tablaNuevaDestajos.Columns.Add("Costo partida")
        tablaNuevaDestajos.Columns.Add("Número de pares")
        tablaNuevaDestajos.Columns.Add("Total")
        tablaNuevaDestajos.Columns.Add("Tiempo")

        For i As Integer = 0 To tablaDestajos.Rows.Count - 1
            If tablaDestajos.Rows(i).Item("Ticket").ToString() <> "" Then
                contadorLineas = contadorLineas + 1
                'tablaNuevaDestajos.Rows.Add(New Object() {contadorLineas, tablaDestajos.Rows(i).Item("Ticket").ToString(), tablaDestajos.Rows(i).Item("Nombre").ToString(), Convert.ToDateTime(tablaDestajos.Rows(i).Item("Fecha")).ToShortDateString(), tablaDestajos.Rows(i).Item("Descripcion").ToString(), tablaDestajos.Rows(i).Item("Observaciones"), tablaDestajos.Rows(i).Item("CostoPar").ToString(), tablaDestajos.Rows(i).Item("Pares").ToString(), tablaDestajos.Rows(i).Item("MontoTicket").ToString()})
                tablaNuevaDestajos.Rows.Add(New Object() {contadorLineas, tablaDestajos.Rows(i).Item("Ticket").ToString(), tablaDestajos.Rows(i).Item("Nombre").ToString(), tablaDestajos.Rows(i).Item("Departamento").ToString(), tablaDestajos.Rows(i).Item("Celula").ToString(), Convert.ToDateTime(tablaDestajos.Rows(i).Item("Fecha")).ToShortDateString(), Convert.ToDateTime(tablaDestajos.Rows(i).Item("FechaPrograma")).ToShortDateString(), tablaDestajos.Rows(i).Item("Lote").ToString(), tablaDestajos.Rows(i).Item("ModeloSICY").ToString(), tablaDestajos.Rows(i).Item("Coleccion").ToString(), tablaDestajos.Rows(i).Item("Descripcion").ToString(), tablaDestajos.Rows(i).Item("Observaciones"), tablaDestajos.Rows(i).Item("CostoPar").ToString(), tablaDestajos.Rows(i).Item("Pares").ToString(), tablaDestajos.Rows(i).Item("MontoTicket").ToString(), tablaDestajos.Rows(i).Item("Tiempo").ToString()})
            End If
        Next
        Return tablaNuevaDestajos
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim formTickets As New ListaTicketsAgrupadosForm
        If cboxPeriodo.SelectedIndex >= 0 Then
            PeriodoNominaid = cboxPeriodo.SelectedValue

            formTickets.colaboradorid = Colaboradorid
            formTickets.periodoid = PeriodoNominaid
            formTickets.nombrecolaborador = NombreColaborador
            formTickets.ShowDialog()
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If IsDBNull(Colaboradorid) OrElse Colaboradorid = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de seleccionar un colaborador")
        Else

            Dim Destajos = New DataSet("Destajos")
            Dim ticketsBU As New Negocios.TicketsBU
            Dim tablaTickets As New DataTable("Tickets")
            Dim tablaAgrupada As New DataTable("TicketsAgrupado")
            Dim colBu As New Negocios.ColaboradorLaboralBU
            Dim labo As New Entidades.ColaboradorLaboral
            Dim OBJBU As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes

            tablaTickets = ticketsBU.ListaTicketsAgrupados(Colaboradorid, cboxPeriodo.SelectedValue)
            tablaAgrupada = ticketsBU.ListaTicketsAgrupadosSupervisor(Colaboradorid, cboxPeriodo.SelectedValue)
            labo = colBu.buscarInformacionLaboral(Colaboradorid)
            If IsDBNull(labo.PCelula) OrElse labo.PCelula Is Nothing Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El colaborador no tiene asignada una célula")
            Else
                If labo.PCelula.PNombre.Contains("SUPERVISORES") Or labo.PCelula.PNombre.Contains("Supervisor") Then
                    EntidadReporte = OBJBU.LeerReporteporClave("NOM_DESTAJOS_SUPERVISOR")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                  EntidadReporte.Pnombre.Trim + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    reporte.Load(archivo)
                    reporte.Compile()

                    reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(43)
                    reporte("NombreColaborador") = NombreColaborador
                    Dim tabla As New DataTable
                    reporte("Fecha") = cboxPeriodo.Text
                    Dim naveNombre As New Entidades.Naves
                    naveNombre = cmbNave.SelectedItem
                    reporte("Nave") = naveNombre.PNombre

                    If labo.PPuestoId Is Nothing Then
                        Dim mensaje2 As New ErroresForm
                        mensaje2.mensaje = "Debe de elegir un colaborador"
                        mensaje2.ShowDialog()
                        Exit Sub

                    End If
                    reporte("Puesto") = labo.PPuestoId.PNombre
                    reporte("Departamento") = labo.PDepartamentoId.DNombre
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToUpper

                    tablaTickets.TableName = "Tickets"
                    tablaAgrupada.TableName = "TicketsAgrupado"
                    Destajos.Tables.Add(tablaTickets)
                    Destajos.Tables.Add(tablaAgrupada)

                    reporte.RegData(Destajos)
                    reporte.Show()
                Else

                    EntidadReporte = OBJBU.LeerReporteporClave("NOM_DESTAJOS")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre.Trim + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    reporte.Load(archivo)
                    reporte.Compile()

                    reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(43)
                    reporte("NombreColaborador") = NombreColaborador
                    Dim tabla As New DataTable
                    reporte("Fecha") = cboxPeriodo.Text
                    Dim naveNombre As New Entidades.Naves
                    naveNombre = cmbNave.SelectedItem
                    reporte("Nave") = naveNombre.PNombre

                    If labo.PPuestoId Is Nothing Then
                        Dim mensaje2 As New ErroresForm
                        mensaje2.mensaje = "Debe de elegir un colaborador"
                        mensaje2.ShowDialog()
                        Exit Sub

                    End If
                    reporte("Puesto") = labo.PPuestoId.PNombre
                    reporte("Departamento") = labo.PDepartamentoId.DNombre
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToUpper

                    'reporte("Elaboro") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal
                    'If cmbNave.SelectedValue = 43 Then
                    '    reporte("Reviso") = "ALMA VILLAGRANA"
                    'ElseIf cmbNave.SelectedValue = 3 Then
                    '    reporte("Reviso") = "RAFAEL ORTIZ LOPEZ"
                    'End If
                    Destajos.Tables.Add(tablaTickets)

                    reporte.RegData(Destajos)
                    reporte.Show()
                End If
            End If
        End If
    End Sub
End Class
