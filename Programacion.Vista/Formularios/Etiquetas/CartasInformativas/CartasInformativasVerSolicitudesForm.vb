Imports DevExpress.XtraGrid
Imports Programacion.Negocios
Imports Tools

Public Class CartasInformativasVerSolicitudesForm
    Public acciones As String
    Dim objBU As New Tools.Correo
    Dim resultadoDialog As DialogResult
    Dim confirmarDialog As New ConfirmarForm
    Dim filtroFecha As Integer

    Private Sub CartasInformativasVerSolicitudesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CARTAS_INFORMATIVAS", "PPCP_VALIDAR") Then
            pnlAutorizar.Hide()
            pnlRechazar.Hide()
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CARTAS_INFORMATIVAS", "PPCP_SOLICITAR_CARTA") Then
            pnlAutorizar.Hide()
            pnlRechazar.Hide()
        End If

        llenarComboEstatus()

        dtpDel.Value = Date.Now
        dtpAl.Value = Date.Now
    End Sub

    Private Sub disenioGrig()
        Dim gridFormatRule As New GridFormatRule()
        Dim formatConditionRuleExpression As New DevExpress.XtraEditors.FormatConditionRuleExpression()
        'Me.Cursor = Cursors.WaitCursor

        grdVSolicitud.IndicatorWidth = 40
        grdVSolicitud.BestFitColumns()

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVSolicitud.Columns
            col.OptionsColumn.AllowEdit = False
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName = "SEL" Then
                col.OptionsColumn.AllowEdit = True
            ElseIf col.FieldName = "NaveId" Then
                col.Visible = False
            End If
            If acciones = "VALIDAR_SOLICITAR" Then
                If col.FieldName = "SEL" Then
                    col.Visible = False
                ElseIf col.FieldName = "NaveId" Then
                    col.Visible = False
                End If
            Else
                If col.FieldName = "SEL" Then
                    col.OptionsColumn.AllowEdit = True
                ElseIf col.FieldName = "NaveId" Then
                    col.Visible = False
                End If
            End If
        Next



        grdVSolicitud.Columns("FALTANTE").Caption = "FALTANTE" & vbCrLf & "ETIQUETAS"

        grdVSolicitud.OptionsView.EnableAppearanceEvenRow = True
        grdVSolicitud.OptionsView.EnableAppearanceOddRow = True
        grdVSolicitud.OptionsSelection.EnableAppearanceFocusedCell = True
        grdVSolicitud.OptionsSelection.EnableAppearanceFocusedRow = True
        grdVSolicitud.Appearance.SelectedRow.Options.UseBackColor = True
        grdVSolicitud.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVSolicitud.Appearance.EvenRow.BackColor = Color.White
        grdVSolicitud.Appearance.OddRow.BackColor = SystemColors.ActiveCaption
        grdVSolicitud.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVSolicitud.Appearance.FocusedRow.ForeColor = Color.White

        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub dtpDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpDel.ValueChanged
        dtpAl.MinDate = dtpDel.Value
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Me.Cursor = Cursors.WaitCursor
        llenarGrid()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub grdVSolicitud_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdVSolicitud.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub grdVSolicitud_RowClick(sender As Object, e As Views.Grid.RowClickEventArgs) Handles grdVSolicitud.RowClick
        If e.Clicks = 2 Then
            Dim form As New CartasInformativasVerSolicitudDetallesForm
            form.folio = grdVSolicitud.GetFocusedRowCellValue("FOLIO")
            form.ShowDialog()
        End If
    End Sub

    Private Sub btnSolicitarCarta_Click(sender As Object, e As EventArgs) Handles btnSolicitarCarta.Click
        Dim Acicon As Integer = 1
        Dim filas As Integer = 0
        Dim totAutorizar As Integer = 0
        Dim idNave As Integer = 0
        Dim folio As Integer = 0
        Dim lotes As String = String.Empty

        Me.Cursor = Cursors.WaitCursor
        Try
            filas = grdVSolicitud.DataRowCount
            If filas > 0 Then
                For index As Integer = 0 To filas - 1 Step 1
                    If grdVSolicitud.GetRowCellValue(index, "SEL") = True Then
                        totAutorizar += 1
                    End If
                Next
                If totAutorizar > 0 Then
                    confirmarDialog.mensaje = "Se Autorizarán " & CStr(totAutorizar) & " folios"
                    resultadoDialog = confirmarDialog.ShowDialog
                    If resultadoDialog = DialogResult.OK Then
                        autorizarRechazarFolios(Acicon, filas)
                        For index As Integer = 0 To grdVSolicitud.DataRowCount - 1 Step 1
                            If grdVSolicitud.GetRowCellValue(index, "SEL") Then
                                idNave = CInt(grdVSolicitud.GetRowCellValue(index, "NaveId"))
                                folio = CInt(grdVSolicitud.GetRowCellValue(index, "FOLIO"))
                                solicitarCarta(idNave, folio)
                            End If
                        Next
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se ha enviado la carta correctamente.")
                        llenarGrid()
                    Else
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleccione al menos un folio")
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No exixten registros en la tabla.")
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRechazarCarta.Click
        Dim Acicon As Integer = 2
        Dim filas As Integer = 0
        Dim totCancelar As Integer = 0
        Dim folios As String = String.Empty

        filas = grdVSolicitud.DataRowCount

        If filas > 0 Then
            For index As Integer = 0 To filas - 1 Step 1
                If grdVSolicitud.GetRowCellValue(index, "SEL") = True Then
                    folios = folios & ", " & grdVSolicitud.GetRowCellValue(index, "FOLIO")
                    totCancelar += 1
                End If
            Next
            If totCancelar > 0 Then
                confirmarDialog.mensaje = "Se rechazará los folios" & folios
                resultadoDialog = confirmarDialog.ShowDialog
                If resultadoDialog = DialogResult.OK Then
                    autorizarRechazarFolios(Acicon, filas)
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se han rechazado los folios seleccionados.")
                Else
                    Exit Sub
                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleccione al menos un folio")
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No exixten registros en la tabla.")
        End If

    End Sub

    Private Sub autorizarRechazarFolios(ByVal accion As Integer, ByVal filas As Integer)
        Dim obj As New CartasInformativasBU
        'Dim filas As Integer = 0
        Dim folios As String = String.Empty


        For index As Integer = 0 To filas Step 1
            If grdVSolicitud.GetRowCellValue(index, "SEL") = True Then
                If folios = String.Empty Then
                    folios = CStr(grdVSolicitud.GetRowCellValue(index, "FOLIO"))
                Else
                    folios = folios & "," & CStr(grdVSolicitud.GetRowCellValue(index, "FOLIO"))
                End If
            End If

        Next
        obj.rechazarAutorizarFolioCarta(accion, folios)

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub solicitarCarta(ByVal NaveId As Integer, ByVal folio As Integer)
        Dim obj = New Framework.Negocios.EnviosCorreoBU
        Dim objC = New CartasInformativasBU
        Dim destinatarios As String = String.Empty
        Dim remitente As String = String.Empty
        Dim asunto As String = "Carta Informativa Lotes Sin Etiqueta"
        Dim mensaje As String = String.Empty
        Dim dtLotesSolicitados As New DataTable
        Dim correo As String = String.Empty

        Try
            destinatarios = obj.consultaDestinatariosSolicitudCarta(NaveId)
            remitente = "servicioselectronicos@grupoyuyin.com.mx"
            dtLotesSolicitados = objC.solicitarCarta(NaveId, folio)

            correo =
                "<html>
                    <head>
                        <style type ='text/css'>
                            body {display: block; margin: 8px; background: #FFFFFF;}
                            #header 
                                {   position: fixed;
                                    height: 62px;
                                    margin: 1% 1%;
                                    top: 0;
                                    left: 0;
                                    right: 0;
                                    color: black;
                                    font-family: Arial, Helvetica ,sans-serif;
                                    font-size: 12px;
                                }
                            #content 
                                {   width: 90%;
                                    position: fixed;
                                    margin: 0% 0%;
                                    padding-top: 15%;
                                    padding-bottom: 1%;
                                    font-family: Arial, Helvetica ,sans-serif;
                                    font-size: 12px;
                                }
                            table.tableizer-table
                                {   font-family: Arial, Helvetica, sans-serif;
                                    font-size: 10px;
                                }
                            .tableizer-table td 
                                {   padding: 4px;
                                    margin: 0px;
                                    border: 1px solid #FFFFFF;
                                    border-color: #FFFFFF;
                                    border: 1px solid #CCCCCC;
                                    width: 90px;
                                }
                            .tableizer-table tr 
                                {   padding: 4px;
                                    margin: 0;
                                    color: #003366;
                                    font-weight: bold;
                                    background-color: #transparent;
                                    opacity: 1;
                                }
                            .tableizer-table th 
                                {   background-color: #DFDFDF;
                                    color: black;
                                    font-weight: bold;
                                    height: 30px;
                                    font-size: 11px;
                                }
                            .tableizer-table tr:nth-child(odd) { background-color: #9BC4E2; }
                            .tableizer-table tr:nth-child(even){ background-color:  #transparent;}
                        </style>
                    </head>
                    <body>
                        <div id='wrapper'>
                            <div id='header'>
                                
                                <img src= '\\192.168.2.156\catalogo\ImagenCartaInformativa\LogoGrupoYuyin.png' width='173' height='65' align='right'>
                                
                                <p style='font-family: Times New Roman, Times, serif; color:red; font-size:30px;'>Folio: " + dtLotesSolicitados.Rows(0).Item("FOLIO").ToString + " </p>
                                <p style='font-family: Times New Roman, Times, serif; color:grey; font-size:18px;'>CARTA INFORMATIVA</p>    
                                
                                <div id='content'>
                                    <p><b>" + dtLotesSolicitados.Rows(0).Item("RESPONSABLE").ToString + "</b> </p>
                                    <p><b>FECHA: </b>" + Date.Now.ToString() + " </p>
                                    <p>Se le informa que, en el <b>Programa del " + dtLotesSolicitados.Rows(0).Item("FECHA_PROGRAMA").ToString + "</b> de la siguuente lista, no se han entregado las etiquetas por parte del Cliente por lo cual solicito de la manera más atenta se entreguen estos lotes sin las mismas.</p>
                                    
                                    <table id='mi_tabla' class='tableizer-table' align='center'>
                                        <thead>
                                            <tr class='tableizer-firstrow'>
                                                <th width='30%'>Cliente</th>
                                                <th>Pedido</th>
                                                <th>Lote</th>
                                                <th>Modelo</th>
                                                <th width='30%'>Piel-Color</th>
                                                <th>Corrida</th>
                                                <th>Pares</th>
                                                <th width='30%'>Observaciones</th>
                                            </tr>
                                        </thead>
                                        <tbody> "

            For index = 0 To dtLotesSolicitados.Rows.Count - 1

                correo +=
                    "<tr>" +
                        "<td align='center'>" + dtLotesSolicitados.Rows(index).Item("CLIENTE").ToString + "</td>" +
                        "<td align='center'>" + dtLotesSolicitados.Rows(index).Item("PEDIDO").ToString + "</td>" +
                        "<td align='center'>" + dtLotesSolicitados.Rows(index).Item("LOTE").ToString + "</td>" +
                        "<td align='center'>" + dtLotesSolicitados.Rows(index).Item("MODELO").ToString + "</td>" +
                        "<td align='center'>" + dtLotesSolicitados.Rows(index).Item("PIEL_COLOR").ToString + "</td>" +
                        "<td align='center'>" + dtLotesSolicitados.Rows(index).Item("CORRIDA").ToString + "</td>" +
                        "<td align='center'>" + dtLotesSolicitados.Rows(index).Item("PARES").ToString + "</td>" +
                        "<td align='center'>" + dtLotesSolicitados.Rows(index).Item("OBSERVACIONES").ToString + "</td>" +
                    "</tr>"
            Next

            'Total
            correo +=
                "<tr>" +
                        "<td align='center'></td>" +
                        "<td align='center'></td>" +
                        "<td align='center'></td>" +
                        "<td align='center'></td>" +
                        "<td align='center'></td>" +
                        "<td align='center'></td>" +
                        "<td align='center'>" + dtLotesSolicitados.Compute("Sum(PARES)", String.Empty).ToString + "</td>" +
                        "<td align='center'></td>" +
                "</tr>"

            correo +=
                                        "</tbody>
                                    </table>
                                    <p>Favor de mencionar el número de folio de este documento al momento de ser entregados estos lotes en el Álmacen de Distribución, para que puedan recibir sin nungún problema.</p>
                                    <p>Quedo a sus órdenes para cualquier duda o aclaración.</p>
                                    <p align='center'><b>Atentamente: </b><br>" + dtLotesSolicitados.Rows(0).Item("SOLICITANTE").ToString +
                                    "</p>
                                </div>
                            </div>
                        </div>
                    </body>
                </html>"

            objBU.EnviarCorreoHtml(destinatarios, remitente, asunto, correo)

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
        '<br><p align='center'><b>DETALLES DE SOLICITUD</b></p></br> linea 263
        '<img src='\\192.168.2.16\Sistemas\PRIVADO\PROYECTOS TI\DESARROLLO\PROGRAMACION\20201210_CARTA DE ETIQUETAS FALTANTES EN SAY\Scripts\LogoGrupoYuyin.jpg' width='173' height='95' align='right'>
    End Sub

    Private Sub llenarGrid()
        Dim obj = New CartasInformativasBU
        grdSolicitud.DataSource = Nothing
        grdVSolicitud.Columns.Clear()
        Dim tblSolicitudes As New DataTable
        Dim pedido As Integer = 0
        Dim idEstatus As Integer = 0

        'Me.Cursor = Cursors.WaitCursor
        If txtPedidoSay.Text <> "" Then
            pedido = CInt(txtPedidoSay.Text)
        End If

        If cboEstatus.Text <> "" Then
            idEstatus = cboEstatus.SelectedValue
        End If
        

        If chkFechas.Checked Then
            filtroFecha = 1
        Else
            filtroFecha = 0
        End If

        tblSolicitudes = obj.consultaFolioSolicitud(filtroFecha, dtpDel.Value, dtpAl.Value, idEstatus, pedido)

        If tblSolicitudes.Rows.Count > 0 Then
            grdSolicitud.DataSource = tblSolicitudes
            disenioGrig()
            ActualizarRegistrosyFecha()
        Else
            grdVSolicitud.Columns.Clear()
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontraron folios.")
            lblTotalRegistros.Text = "0"
            lblActualizacion.Text = Date.Now
        End If
        '        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ActualizarRegistrosyFecha()
        lblTotalRegistros.Text = grdVSolicitud.DataRowCount.ToString("n0")
        lblActualizacion.Text = Date.Now
    End Sub

    Private Sub txtPedidoSay_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSay.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True

        End If


    End Sub

    Private Sub llenarComboEstatus()
        Dim obj = New CartasInformativasBU
        Dim dtEstatus As New DataTable

        dtEstatus = obj.ConsultaEstatusSolicitud()
        dtEstatus.Rows.InsertAt(dtEstatus.NewRow, 0)
        cboEstatus.DataSource = dtEstatus
        cboEstatus.ValueMember = "EstatusId"
        cboEstatus.DisplayMember = "EstatusNombre"

    End Sub

    Private Sub chkFechas_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechas.CheckedChanged
        If chkFechas.Checked Then
            gpoFechas.Enabled = True
            filtroFecha = 1
        Else
            gpoFechas.Enabled = False
            filtroFecha = 0
        End If
    End Sub
End Class