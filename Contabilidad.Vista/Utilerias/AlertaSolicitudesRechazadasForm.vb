Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class AlertaSolicitudesRechazadasForm

    Public dtSolicitudesRechazadas As DataTable

    Private Sub AlertaSolicitudesRechazadasForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblHoraEnvioAlerta.Text = Date.Now
        If dtSolicitudesRechazadas Is Nothing Then
            llenarDatos()
        End If
        mostrarSolicitudesRechazadas()
    End Sub

    Public Sub llenarDatos()
        Dim objBu As New Framework.Negocios.AlertasBU
        Dim dtSolicitudes As New DataTable

        dtSolicitudesRechazadas = objBu.consultaSolicitudesRechazadas

        If dtSolicitudes.Rows.Count > 0 Then
            grdSoicitudesRechazadas.DataSource = dtSolicitudesRechazadas
        End If
    End Sub

    Public Sub mostrarSolicitudesRechazadas()
        If Not dtSolicitudesRechazadas Is Nothing Then
            If dtSolicitudesRechazadas.Rows.Count > 0 Then
                grdSoicitudesRechazadas.DataSource = dtSolicitudesRechazadas
                With grdSoicitudesRechazadas.DisplayLayout.Bands(0)
                    .Columns("idMovimiento").Hidden = True
                    .Columns("idPatron").Hidden = True
                    .Columns("seleccion").Header.Caption = ""
                    .Columns("movimiento").Header.Caption = "Tipo Movimiento"
                    .Columns("nombre").Header.Caption = "Colaborador"
                    .Columns("fechaRechazo").Header.Caption = "Fecha Rechazo"
                    .Columns("motivo").Header.Caption = "Motivo Rechazo"
                    .Columns("movimiento").CellActivation = Activation.NoEdit
                    .Columns("nombre").CellActivation = Activation.NoEdit
                    .Columns("fechaRechazo").CellActivation = Activation.NoEdit
                    .Columns("motivo").CellActivation = Activation.NoEdit

                    '.Columns("clie_clienteid").CellAppearance.TextHAlign = HAlign.Right

                    .Columns("Seleccion").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

                    .Columns("Seleccion").AllowRowFiltering = DefaultableBoolean.False

                    .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
                End With

                grdSoicitudesRechazadas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                grdSoicitudesRechazadas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
                grdSoicitudesRechazadas.DisplayLayout.Override.RowSelectorWidth = 35
                grdSoicitudesRechazadas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                grdSoicitudesRechazadas.Rows(0).Selected = True

            End If
        End If
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        If Not grdSoicitudesRechazadas.DataSource Is Nothing Then
            For Each rowGR As UltraGridRow In grdSoicitudesRechazadas.Rows.GetFilteredInNonGroupByRows
                rowGR.Cells("seleccion").Value = CBool(chkSeleccionarTodo.Checked)
            Next
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        aplicarCambiosSolicitudes()
    End Sub

    Public Sub aplicarCambiosSolicitudes()
        Dim objMsgSINO As New Tools.ConfirmarForm
        Dim resul As String = String.Empty
        Dim objBuSol As New Negocios.AlertaMovimientosBU
        Dim cont As Integer = 0
        Dim totalSOl As Integer = 0

        objMsgSINO.mensaje = "¿Está seguro de aplicar las solicitudes como modificadas?"
        If objMsgSINO.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each rowGr As UltraGridRow In grdSoicitudesRechazadas.Rows
                If CBool(rowGr.Cells("Seleccion").Value) = True Then
                    totalSOl += 1
                    resul = objBuSol.actualizaSolicitudesRechazadas(CInt(rowGr.Cells("idMovimiento").Value), rowGr.Cells("movimiento").Value)
                    If resul = "EXITO" Then
                        enviar_correo(rowGr)
                        cont = cont + 1
                    End If
                End If
            Next

            If cont = totalSOl Then
                Dim exito As New Tools.ExitoForm
                exito.mensaje = "Las solicitudes fueron marcadas como modificadas"
                exito.ShowDialog()
            Else
                Dim advertencia As New Tools.AdvertenciaForm
                advertencia.mensaje = "No fue posible actualizar todas las solictudes.Intente nuevamente"
                advertencia.ShowDialog()
            End If
            llenarDatos()
            grdSoicitudesRechazadas.DataSource = Nothing
            mostrarSolicitudesRechazadas()
        End If
    End Sub

    Private Sub enviar_correo(ByVal eRow As UltraGridRow)
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim objBU As New Framework.Negocios.AlertasBU
        Dim dtDatosCorreo As New DataTable
        Dim destinatarios As String = String.Empty
        Dim correoEnvia As String = String.Empty
        Dim mensaje As String = String.Empty
        Dim asunto As String = String.Empty
        Dim correo As New Tools.Correo

        dtDatosCorreo = objBU.envioCorreoRechazadas(eRow.Cells("idPatron").Value)
        If Not dtDatosCorreo Is Nothing Then
            If dtDatosCorreo.Rows().Count > 0 Then
                If dtDatosCorreo.Rows(0)("destinatarios").ToString <> "" Then
                    mensaje = cuerpoCorreo(eRow)
                    destinatarios = dtDatosCorreo.Rows(0)("destinatarios").ToString
                    correoEnvia = dtDatosCorreo.Rows(0)("correoEnvia").ToString
                    asunto = "Modificación de informacion de movimiento rechazado IDSE " & dtDatosCorreo.Rows(0)("nave").ToString

                    correo.EnviarCorreoHtml(destinatarios, correoEnvia, asunto, mensaje)
                End If
            End If
        End If
    End Sub

    Private Function cuerpoCorreo(ByVal eRow As UltraGridRow) As String
        Dim mensaje As String = String.Empty
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        mensaje = "<html>"
        mensaje &= "<head>"
        mensaje &= "<style type ='text/css'>" &
                "body {display:block; margin:8px; background:#FFFFFF;}" &
                "#header {position:fixed; height:62px; top:0; left:0; right:0; color:#003366; font-family:Arial, Helvetica, sans-serif; font-size:18px; font-weight: bold;}" &
                "#leftcolumn {float:left; position:fixed; width:2%; margin:1%; padding-top:3%; top:0; left:0; right:0;}" &
                "#content {width:90%; position:fixed; margin:1% 5%; padding-top:3%; padding-bottom:1%;}" &
                "#rightcolumn {float:right; width:5%; margin:1%; padding-top:3%;}" &
                "#footer {position:fixed; width:100%; heigt:5%; bottom:0; margin:0; padding:0; color:#FFFFFF;}" &
                "table.tableizer-table {font-family:Arial, Helvetica, sans-serif; font-size:9px;} " &
                ".tableizer-table td {padding:4px; margin:0px; border:1px solid #FFFFFF;	border-color: #FFFFFF; border:1px solid #CCCCCC; width:200px;}" &
                ".tableizer-table tr {padding: 4px; margin:0; color:#003366; font-weight:bold; background-color:#transparent; opacity:1;}" &
                ".tableizer-table th {background-color: #003366; color:#FFFFFF; font-weight:bold; height:30px; font-size:10px;}" &
                "A:link {text-decoration:none; color:#FFFFFF;}" &
                "A:visited {text-decoration:none; color:#FFFFFF;}" &
                "A:active {text-decoration:none; color:#FFFFFF;}" &
                "A:hover {text-decoration:none;color:#006699;} "
        mensaje &= "</style>"
        mensaje &= "</head>"
        mensaje &= "<body>"
        mensaje &= "<div id='wrapper'>" &
                "<div id='header'>" &
                "<img src='http://grupoyuyin.com.mx/images/SAY170.jpg' style='vertical-align:middle' height='57' widht='125'>Movimiento de Crédito Infonavit" &
                "</div>" &
                "<div id='leftcolumn'></div>" &
                "<div id='rightcolumn'></div>"
        mensaje &= "<div id='content'>"
        mensaje &= "<p>La información del movimiento rechazado ha sido modificada.</p>"

        mensaje &= "<table id='tblInformacion' class='tableizer-table'>" &
                "<thead>" &
                "<tr class='tableizer-firstrow'>" &
                "<th>TIPO MOVIMIENTO</th>" &
                "<th>COLABORADOR</th>" &
                "<th>FECHA RECHAZO</th>" &
                "<th>MOTIVO RECHAZO</th>" &
                "</tr>" &
                "</thead>"
        'mensaje &= "<tbody>" &
        '        "<tr>" &
        '        "<td>" & eRow.Cells("Tipo Movimiento").Value & "</td>" &
        '        "<td>" & eRow.Cells("Colaborador").Value & "</td>" &
        '        "<td>" & eRow.Cells("Fecha Rechazo").Value & "</td>" &
        '        "<td>" & eRow.Cells("Motivo Rechazo").Value & "</td>" &
        '        "</tr>"
        mensaje &= "<tbody>" &
                "<tr>" &
                "<td>" & eRow.Cells("movimiento").Value & "</td>" &
                "<td>" & eRow.Cells("nombre").Value & "</td>" &
                "<td>" & eRow.Cells("fechaRechazo").Value & "</td>" &
                "<td>" & eRow.Cells("motivo").Value & "</td>" &
                "</tr>"

        mensaje &= "</tbody>"
        mensaje &= "</table>"
        mensaje &= "</div>"
        mensaje &= "<div id='footer'></div>"
        mensaje &= "</div>"
        mensaje &= "</body>"
        mensaje &= "</html>"

        Return mensaje
    End Function
End Class