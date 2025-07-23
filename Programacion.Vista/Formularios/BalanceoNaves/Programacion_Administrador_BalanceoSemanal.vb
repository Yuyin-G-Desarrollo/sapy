Imports System.IO
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Framework.Negocios
Imports Programacion.Negocios
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Export
Imports Tools

Public Class Programacion_Administrador_BalanceoSemanal
    Dim NaveID As Integer = 0
    Dim Semana As Integer = 0
    Dim Año As Integer = 0
    Dim confirmar As New ConfirmarForm
    Dim Accion As Integer = 0
    Dim Exportado As Boolean = False

    Private Sub Programacion_Administrador_BalanceoSemanal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        NSemanaInicio.Value = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        NSemanaInicio.TextAlign = HorizontalAlignment.Center
        NAñoInicio.Value = DatePart(DateInterval.Year, Now)
        NAñoInicio.TextAlign = HorizontalAlignment.Center
        'ConsultarPermisos()
        CargarNaveSegunUsuario("")
        lblUltimaActualizacion.Text = ""
        lblSemanaActual.Text = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
    End Sub

    Private Sub ConsultarPermisos()

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("BALANCEO_SEMANAL", "BAL_CONTROL_TOTAL") Then
            pnlBalanceoSolicitaModificaciones.Visible = True
            pnlBitacora.Visible = True
            pnlEnviarCorreo.Visible = True
            pnlGenerarPreLoteo.Visible = True
        Else
            pnlBalanceoSolicitaModificaciones.Visible = False
            pnlBitacora.Visible = False
            pnlEnviarCorreo.Visible = False

        End If

    End Sub

    Private Sub cmbGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrupo.SelectedIndexChanged
        If cmbGrupo.Text <> "" Then
            CargarNaveSegunUsuario(cmbGrupo.Text)
        End If
    End Sub

    Private Sub CargarNaveSegunUsuario(ByVal Grupo As String)
        Dim UsuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        'Dim UsuarioID As Integer = 20
        Dim objBU As New BalanceoNavesBU
        Dim objBUP As New PlanFabricacionBU
        Dim dtNaves As New DataTable

        dtNaves = objBUP.ObtenerNavesPorUsuario(UsuarioID)

        If dtNaves.Rows.Count > 0 Then

            If dtNaves.Rows.Count = 1 Then
                cmbNave.Enabled = False
                cmbGrupo.Visible = False
                lblGrupo.Visible = False
                btnCambiosRealizadosBalanceo.Visible = False

                cmbNave.DataSource = dtNaves
                cmbNave.ValueMember = "NaveID"
                cmbNave.DisplayMember = "Nave"
            Else
                cmbNave.Enabled = True
                cmbGrupo.Visible = True
                lblGrupo.Visible = True
                btnCambiosRealizadosBalanceo.Visible = True

                If cmbGrupo.Text <> "" Then
                    dtNaves = objBU.ConsultarNavesAux(Grupo)

                    If dtNaves.Rows.Count > 0 Then
                        dtNaves.Rows.InsertAt(dtNaves.NewRow, 0)
                        cmbNave.DataSource = dtNaves
                        cmbNave.ValueMember = "NaveSAYId"
                        cmbNave.DisplayMember = "Nave"

                    Else
                        show_message("Advertencia", "No existe información de naves.")
                    End If
                End If
            End If

        Else
            show_message("Advertencia", "El usuario no cuenta con una nave asignada.")
        End If
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New Tools.AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New Tools.AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New BalanceoNavesBU
        Dim dtObtieneBalanceoNaves As New DataTable
        Dim Grupo As String = String.Empty

        Try

            'If cmbNave.Text <> "" Then
            '    NaveID = cmbNave.SelectedValue
            'Else
            '    show_message("Advertencia", "Seleccione una Nave.")
            '    Exit Sub
            'End If
            If cmbGrupo.Text = "TODAS" Or cmbGrupo.Text = "RVO" Or cmbGrupo.Text = "FVO" Then
                Grupo = cmbGrupo.Text
            End If

            'If Grupo = "" Then
            If cmbNave.Text <> "" Then
                NaveID = cmbNave.SelectedValue
            Else
                NaveID = 0
                'Exit Sub
            End If
            'Else

            'End If

            Semana = NSemanaInicio.Value
            Año = NAñoInicio.Value

            Cursor = Cursors.WaitCursor

            grdAdmBalanceo.DataSource = Nothing
            vwAdmBalanceo.Columns.Clear()

            dtObtieneBalanceoNaves = objBU.ObtieneBalanceoNaves(NaveID, Semana, Año, Grupo)

            If dtObtieneBalanceoNaves.Rows.Count > 0 Then
                grdAdmBalanceo.DataSource = dtObtieneBalanceoNaves
                lblUltimaActualizacion.Text = Date.Now
                DisenioGrid()

            Else
                show_message("Advertencia", "No hay información para mostrar.")
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub DisenioGrid()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwAdmBalanceo.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName <> " " Then
                col.OptionsColumn.AllowEdit = False
            Else
                col.OptionsColumn.AllowEdit = True
            End If
        Next

        vwAdmBalanceo.Columns.ColumnByFieldName("EstatusID").Visible = False
        vwAdmBalanceo.Columns.ColumnByFieldName("NaveID").Visible = False

        vwAdmBalanceo.Columns.ColumnByFieldName(" ").Width = 30
        vwAdmBalanceo.Columns.ColumnByFieldName("ST").Width = 20
        vwAdmBalanceo.Columns.ColumnByFieldName("Descripción").Width = 240

        vwAdmBalanceo.Columns.ColumnByFieldName("Usuario Creó").Width = 100
        vwAdmBalanceo.Columns.ColumnByFieldName("Fecha Creación").Width = 100
        vwAdmBalanceo.Columns.ColumnByFieldName("Usuario Autoriza").Width = 100
        vwAdmBalanceo.Columns.ColumnByFieldName("Fecha Autoriza").Width = 100
        vwAdmBalanceo.Columns.ColumnByFieldName("Usuario Solicita Cambio").Width = 100
        vwAdmBalanceo.Columns.ColumnByFieldName("Fecha Solicita Cambio").Width = 100
        vwAdmBalanceo.Columns.ColumnByFieldName("Usuario Actualiza PPCP").Width = 100
        vwAdmBalanceo.Columns.ColumnByFieldName("Fecha Actualiza PPCP").Width = 100
        vwAdmBalanceo.Columns.ColumnByFieldName("Última Observación").Width = 240
        vwAdmBalanceo.Columns.ColumnByFieldName("ST").Caption = " "

        vwAdmBalanceo.Columns.ColumnByFieldName("Nave").Visible = False

        DiseñoGrid.AlternarColorEnFilas(vwAdmBalanceo)

    End Sub



    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If vwAdmBalanceo.DataRowCount > 0 Then
            Try
                Dim cantidadBalanceo As Integer = 0
                Dim NumeroFilas As Integer = vwAdmBalanceo.DataRowCount
                Dim objBU As New BalanceoNavesBU
                Dim TieneSAY As Boolean = False
                Dim NaveIDBalanceo As Integer = 0
                Dim NaveNombre As String = String.Empty

                With vwAdmBalanceo
                    For index As Integer = 0 To NumeroFilas Step 1
                        If .GetRowCellValue(index, " ") Then
                            cantidadBalanceo += 1
                            NaveID = .GetRowCellValue(index, "NaveID")
                            NaveNombre = .GetRowCellValue(index, "Nave")

                        End If
                    Next
                End With

                If cantidadBalanceo = 1 Then
                    Dim dtObtieneBalanceoSemanal As New DataTable("dtBalanceoNaves")
                    Dim objBUReporte As New ReportesBU
                    Dim EntidadReporte As New Entidades.Reportes
                    Dim MasterBalanceoNaves As New DataSet("MasterBalanceoNaves")

                    Cursor = Cursors.WaitCursor

                    Semana = NSemanaInicio.Value
                    Año = NAñoInicio.Value

                    dtObtieneBalanceoSemanal = objBU.ObtieneBalanceoNavesReporte(NaveID, Semana, Año)

                    If dtObtieneBalanceoSemanal.Rows.Count > 0 Then
                        dtObtieneBalanceoSemanal.Columns(12).ColumnName = 1
                        dtObtieneBalanceoSemanal.Columns(13).ColumnName = 2
                        dtObtieneBalanceoSemanal.Columns(14).ColumnName = 3
                        dtObtieneBalanceoSemanal.Columns(15).ColumnName = 4
                        dtObtieneBalanceoSemanal.Columns(16).ColumnName = 5
                        dtObtieneBalanceoSemanal.Columns(17).ColumnName = 6

                        MasterBalanceoNaves.Tables.Add(dtObtieneBalanceoSemanal)

                        EntidadReporte = objBUReporte.LeerReporteporClave("RPT_BALANCEONAVES")
                        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                                                EntidadReporte.Pnombre + ".mrt"
                        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                        Dim reporte As New StiReport()

                        reporte.Load(archivo)
                        reporte.Compile()
                        reporte("Nave") = IIf(cmbNave.Text = "", NaveNombre, cmbNave.Text)
                        reporte("Usuario") = dtObtieneBalanceoSemanal.Rows(0).Item("Usuario").ToString()
                        reporte("Fecha") = dtObtieneBalanceoSemanal.Rows(0).Item("Fecha")
                        reporte("Semana") = Semana
                        reporte.Dictionary.Clear()
                        reporte.RegData(MasterBalanceoNaves)
                        reporte.Dictionary.Synchronize()

                        TieneSAY = dtObtieneBalanceoSemanal.Rows(0).Item("TieneSAY")


                        If TieneSAY = False Then
                            Dim formatoExcel As StiExcelExportSettings = New StiExcelExportSettings()
                            Dim rutaBalanceoNaves As String = String.Empty

                            rutaBalanceoNaves = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\BalanceoNaves\NavesSinSAY"

                            If Not System.IO.Directory.Exists(rutaBalanceoNaves) Then
                                Directory.CreateDirectory(rutaBalanceoNaves)
                            End If

                            reporte.Render()
                            formatoExcel.ExportObjectFormatting = True
                            StiOptions.Export.Excel.ShowGridLines = False
                            Exportado = True
                            reporte.ExportDocument(StiExportFormat.Excel, rutaBalanceoNaves + "\Balanceo de la Proyección Semana " + Semana.ToString + "-" + Año.ToString + " Nave " + cmbNave.Text.ToUpperInvariant + ".xls")
                        End If

                        reporte.Show()
                    Else
                        show_message("Advertencia", "No existe información para mostrar.")
                    End If
                Else
                    show_message("Advertencia", "Seleccione un solo balanceo para generar vista previa.")

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                Cursor = Cursors.Default
            End Try
        Else
            show_message("Advertencia", "No hay información para mostrar.")
        End If
    End Sub

    Private Sub btnAbrirBalanceo_Click(sender As Object, e As EventArgs) Handles btnAbrirBalanceo.Click
        Dim SolicitaCambios As New Programacion_BalanceoNaves_SolicitaModificaciones
        Dim NumeroFilas As Integer = vwAdmBalanceo.DataRowCount
        Dim cantidadBalanceo As Integer = 0
        Dim EstatusID As String = ""

        If vwAdmBalanceo.DataRowCount > 0 Then
            With vwAdmBalanceo
                For index As Integer = 0 To NumeroFilas Step 1
                    If .GetRowCellValue(index, " ") Then
                        cantidadBalanceo += 1
                        EstatusID = .GetRowCellValue(index, "ST")
                        SolicitaCambios.NaveID = .GetRowCellValue(index, "NaveID")
                    End If
                Next
            End With


            If cantidadBalanceo = 1 And EstatusID <> "AUTORIZADO" Then
                SolicitaCambios.Año = Año
                SolicitaCambios.Semana = Semana
                SolicitaCambios.ShowDialog()

                btnMostrar_Click(Nothing, Nothing)
            ElseIf cantidadBalanceo > 1 Then
                show_message("Advertencia", "Seleccione un balanceo no autorizado para colocar observaciones.")
            Else
                show_message("Advertencia", "Seleccione un balanceo no autorizado para colocar observaciones.")
            End If
        Else
            show_message("Advertencia", "Seleccione un registro para colocar observaciones")
            Exit Sub
        End If
    End Sub

    Private Sub btnAutorizarBalanceo_Click(sender As Object, e As EventArgs) Handles btnAutorizarBalanceo.Click
        Dim objBU As New BalanceoNavesBU
        Dim NumeroFilas As Integer = vwAdmBalanceo.DataRowCount
        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")


        Try
            With vwAdmBalanceo

                For index As Integer = 0 To NumeroFilas Step 1
                    If .GetRowCellValue(index, " ") Then
                        Dim vNodo As XElement = New XElement("Celda")
                        vNodo.Add(New XAttribute("NaveId", .GetRowCellValue(index, "NaveID")))
                        vNodo.Add(New XAttribute("Semana", Semana))
                        vNodo.Add(New XAttribute("Año", Año))
                        vNodo.Add(New XAttribute("UsuarioModificoId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)) 'Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                        Dim EstatusID = .GetRowCellValue(index, "ST")

                        If EstatusID <> "SOLICITA MODIFICACIONES" And EstatusID <> "AUTORIZADO" Then

                        Else
                            show_message("Advertencia", "Seleccione un balanceo con estatus diferente a autorizado y pendiente de modificar.")
                            Exit Sub
                        End If

                        vXmlCeldasModificadas.Add(vNodo)
                    End If
                Next
            End With

            If vXmlCeldasModificadas.HasElements = True Then
                confirmar.mensaje = "¿Se autorizará el balanceo de la semana " + Semana.ToString + " de la nave " + cmbNave.Text + " ?. Está acción no se podrá revertir."
                If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Accion = 1
                    objBU.AutorizarBalanceoNaves(vXmlCeldasModificadas.ToString(), Accion)
                    'EnvioAvisoCorreoModificacionesRealizadas(generarXML)
                    show_message("Exito", "Balanceo Autorizado.")
                    btnMostrar_Click(Nothing, Nothing)
                End If
            Else
                show_message("Advertencia", "Seleccione un balanceo no autorizado para cambiar de estatus a enviado PPCP.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub btnCambiosRealizadosBalanceo_Click(sender As Object, e As EventArgs) Handles btnCambiosRealizadosBalanceo.Click
        Dim objBU As New BalanceoNavesBU
        Dim NumeroFilas As Integer = vwAdmBalanceo.DataRowCount
        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")

        Try

            With vwAdmBalanceo

                For index As Integer = 0 To NumeroFilas Step 1
                    If .GetRowCellValue(index, " ") Then
                        Dim vNodo As XElement = New XElement("Celda")
                        vNodo.Add(New XAttribute("NaveId", .GetRowCellValue(index, "NaveID")))
                        vNodo.Add(New XAttribute("Semana", Semana))
                        vNodo.Add(New XAttribute("Año", Año))
                        vNodo.Add(New XAttribute("UsuarioModificoId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)) 'Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                        Dim EstatusID = .GetRowCellValue(index, "ST")

                        If EstatusID <> "AUTORIZADO" And EstatusID <> "ENVIADO PPCP" Then

                        Else
                            show_message("Advertencia", "Seleccione un balanceo al que se le hayan realizado las modificaciones.")
                            Exit Sub
                        End If

                        vXmlCeldasModificadas.Add(vNodo)
                    End If
                Next
            End With

            If vXmlCeldasModificadas.HasElements = True Then
                confirmar.mensaje = "¿Se realizaron los cambios solicitados de la semana " + Semana.ToString + " de la nave " + cmbNave.Text + " ?."
                If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Accion = 2
                    objBU.AutorizarBalanceoNaves(vXmlCeldasModificadas.ToString(), Accion)
                    ReenviarCorreo("ENVIADO PPCP")
                    show_message("Exito", "Balanceo en estatus Enviado PPCP.")
                    btnMostrar_Click(Nothing, Nothing)
                End If
            Else
                show_message("Advertencia", "Seleccione un balanceo no autorizado para cambiar de estatus a enviado PPCP.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally

        End Try
    End Sub

    Private Sub btnReenviarCorreoBalanceo_Click(sender As Object, e As EventArgs) Handles btnReenviarCorreoBalanceo.Click
        If vwAdmBalanceo.DataRowCount > 0 Then
            Dim NumeroFilas As Integer = vwAdmBalanceo.DataRowCount
            Dim contador As Integer = 0
            Dim EstatusBalanceo As String = String.Empty

            With vwAdmBalanceo
                For index As Integer = 0 To NumeroFilas Step 1
                    If .GetRowCellValue(index, " ") Then
                        EstatusBalanceo = .GetRowCellValue(index, "ST")
                        contador += 1
                    End If
                Next
            End With

            If contador = 1 Then
                If ReenviarCorreo(EstatusBalanceo) Then
                    show_message("Exito", "Correo enviado correctamente.")

                Else
                    show_message("Advertencia", "Ocurrió un error, intente nuevamente.")
                End If
            Else
                show_message("Advertencia", "Seleccione únicamente un registro para el envío.")
                Exit Sub
            End If

        Else
                show_message("Advertencia", "No existe información para el envío de correo.")
        End If

    End Sub

    Private Function ReenviarCorreo(ByVal EstatusBalanceo As String)
        Dim CorreoEnviado As String = String.Empty
        Dim dtResultadoDatosCorreos As New DataTable
        Dim objBU As New BalanceoNavesBU
        Dim remitente As String = String.Empty
        Dim asuntoCorreo As String = String.Empty
        Dim cadenaCorreo As String = String.Empty
        Dim entCorreo As New Entidades.DatosCorreo
        Dim CorreosDestinatario As String = String.Empty
        Dim dtCorreosDestinarios As New DataTable
        Dim correo As New Tools.Correo
        Dim StatusCorreo As Boolean = False

        Dim NaveNombre As String = String.Empty
        Dim rutaBalanceoNaves As String = String.Empty
        Dim archivoAdjunto As System.Net.Mail.Attachment
        Dim lstArchivoAdjuntos As New List(Of System.Net.Mail.Attachment)
        Dim rutaBalanceoAdjunto As String = String.Empty
        Dim TieneSAY As Boolean = False

        Try
            Cursor = Cursors.WaitCursor


            dtCorreosDestinarios = objBU.ObtenerCorreosDestinatario(NaveID) 'Entidades.SesionUsuario.UsuarioSeion)
            dtResultadoDatosCorreos = objBU.consultaCorreosEnvioFactura("ENVIO_FACTURAS_CLIENTES")
            remitente = dtResultadoDatosCorreos.Rows(0).Item("CorreoEnvia").ToString()

            If dtCorreosDestinarios.Rows.Count > 0 Then
                CorreosDestinatario = dtCorreosDestinarios.Rows(0).Item("Destinos").ToString()
                NaveNombre = dtCorreosDestinarios.Rows(0).Item("Nave")
                TieneSAY = CBool(dtCorreosDestinarios.Rows(0).Item("TieneSAY").ToString())

                asuntoCorreo = "Asunto: Aviso Balanceo de la Proyección " + EstatusBalanceo + " Semana " + Semana.ToString() + "-" + Año.ToString() + " de la nave " + NaveNombre

                Select Case TieneSAY
                    Case 0
                        Select Case EstatusBalanceo
                            Case "ENVIADO PPCP"
                                rutaBalanceoAdjunto = "Balanceo de la Proyección Semana " + Semana.ToString() + "-" + Año.ToString + " Nave " + NaveNombre
                                rutaBalanceoNaves = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\PlanFabricacion\NavesSinSAY\" + rutaBalanceoAdjunto + ".xls"


                                If rutaBalanceoNaves <> String.Empty Then
                                    archivoAdjunto = New System.Net.Mail.Attachment(rutaBalanceoNaves)
                                    lstArchivoAdjuntos.Add(archivoAdjunto)
                                End If


                                cadenaCorreo = "<html> " +
                                            " <head>" +
                                            " </head>"
                                cadenaCorreo += " <body> "
                                cadenaCorreo += " <br><p>Buen día</p>"
                                cadenaCorreo += " <br><p>Se envía propuesta de balanceo correspondiente a la semana " + Semana.ToString() + " de la nave " + NaveNombre + "  </p>"
                                cadenaCorreo += " <p>Cualquier cambio con respecto a esta propuesta, enviarla por este medio.</p>"
                                cadenaCorreo += " <br><p><b>Favor de no contestar este correo, este es un envío automático.</b></p>"
                                cadenaCorreo += " <p>Saludos!!!</p>"
                                cadenaCorreo += " </body> " +
                                                    " </html> "

                                entCorreo = correo.EnviarCorreoFacturasHtmlVariosArchivosAdjuntos(CorreosDestinatario, remitente, asuntoCorreo, cadenaCorreo, lstArchivoAdjuntos)

                                If entCorreo.CorreoEnviado = True Then

                                    CorreoEnviado = "S"
                                    StatusCorreo = True

                                Else
                                    CorreoEnviado = "N"
                                    StatusCorreo = False
                                End If
                            Case "AUTORIZADO"

                                cadenaCorreo = "<html> " +
                               " <head>" +
                               " </head>"
                                cadenaCorreo += " <body> "
                                cadenaCorreo += " <br><p>Buen día</p>"
                                cadenaCorreo += " <br><p>Se ACEPTA el balanceo de la proyección de la semana " + Semana.ToString() + "-" + Año.ToString() + " de la nave " + NaveNombre + " 
                                           ,favor de generar el balanceo semanal correspondiente.</p>"

                                cadenaCorreo += " <br><p><b>Favor de no contestar este correo</b></p>"
                                cadenaCorreo += " <p>Saludos!!!</p>"
                                cadenaCorreo += " </body> " +
                                                    " </html> "


                                correo.EnviarCorreoHtml(CorreosDestinatario, remitente, asuntoCorreo, cadenaCorreo)

                                CorreoEnviado = "S"
                                StatusCorreo = True

                            Case Else
                                show_message("Advertencia", "Movimiento sin archivo adjunto.")
                                Exit Function
                        End Select

                    Case 1 'SI TIENEN SAY 

                        Select Case EstatusBalanceo
                            Case "ENVIADO PPCP"

                                cadenaCorreo = "<html> " +
                                    " <head>" +
                                    " </head>"
                                cadenaCorreo += " <body> "
                                cadenaCorreo += " <br><p>Buen día</p>"
                                cadenaCorreo += " <br><p>Les informo que la propuesta de balanceo de la semana " + Semana.ToString() + " de la nave " + NaveNombre + " se encuentra disponible 
                                           dentro del sistema SAY.</p>"
                                cadenaCorreo += " <p>Cualquier cambio con respecto a esta propuesta, realizarla por dicho medio.</p>"
                                cadenaCorreo += " <br><p><b>Favor de no contestar este correo</b></p>"
                                cadenaCorreo += " <p>Saludos!!!</p>"
                                cadenaCorreo += " </body> " +
                                            " </html> "


                                correo.EnviarCorreoHtml(CorreosDestinatario, remitente, asuntoCorreo, cadenaCorreo)

                                CorreoEnviado = "S"
                                StatusCorreo = True

                            Case "SOLICITA MODIFICACIONES"

                                cadenaCorreo = "<html> " +
                             " <head>" +
                             " </head>"
                                cadenaCorreo += " <body> "
                                cadenaCorreo += " <br><p>Buen día</p>"
                                cadenaCorreo += " <br><p>Se RECHAZA el balanceo de la proyección de la semana " + Semana.ToString() + "-" + Año.ToString() + " de la nave " + NaveNombre + " 
                                           ,favor de revisar las observaciones y solicitud de cambios registrados en el sistema y volver a enviar la propuesta del plan semanal de programación para su valoración.</p>"

                                cadenaCorreo += " <br><p><b>Favor de no contestar este correo</b></p>"
                                cadenaCorreo += " <p>Saludos!!!</p>"
                                cadenaCorreo += " </body> " +
                                                    " </html> "


                                correo.EnviarCorreoHtml(CorreosDestinatario, remitente, asuntoCorreo, cadenaCorreo)

                                CorreoEnviado = "S"
                                StatusCorreo = True

                            Case "AUTORIZADO"

                                cadenaCorreo = "<html> " +
                               " <head>" +
                               " </head>"
                                cadenaCorreo += " <body> "
                                cadenaCorreo += " <br><p>Buen día</p>"
                                cadenaCorreo += " <br><p>Se ACEPTA el balanceo de la proyección de la semana " + Semana.ToString() + "-" + Año.ToString() + " de la nave " + NaveNombre + " 
                                           ,favor de generar el balanceo semanal correspondiente.</p>"

                                cadenaCorreo += " <br><p><b>Favor de no contestar este correo</b></p>"
                                cadenaCorreo += " <p>Saludos!!!</p>"
                                cadenaCorreo += " </body> " +
                                                    " </html> "


                                correo.EnviarCorreoHtml(CorreosDestinatario, remitente, asuntoCorreo, cadenaCorreo)

                                CorreoEnviado = "S"
                                StatusCorreo = True

                        End Select
                End Select

            Else
                show_message("Advertencia", "No existen destinatarios para el envío de correo.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try


        Return StatusCorreo

    End Function

    Private Sub vwAdmBalanceo_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwAdmBalanceo.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub vwAdmBalanceo_CustomDrawCell(sender As Object, e As Views.Base.RowCellCustomDrawEventArgs) Handles vwAdmBalanceo.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        If vwAdmBalanceo.DataRowCount > 0 Then
            If e.Column.FieldName = "ST" Then
                e.Appearance.BackColor = ObtenerColorEstatus(currentView.GetRowCellValue(e.RowHandle, "ST"))
                e.Appearance.ForeColor = ObtenerColorEstatus(currentView.GetRowCellValue(e.RowHandle, "ST"))
            End If
        End If
    End Sub

    Private Function ObtenerColorEstatus(ByVal Estatus As String) As Color
        Dim TipoColor As Color = Color.Empty

        If Estatus = "ENVIADO PPCP" Then
            TipoColor = pnlBalanceoEnviadoPPCP.BackColor
        ElseIf Estatus = "SOLICITA MODIFICACIONES" Then
            TipoColor = pnlBalanceoSolicitaModificaciones.BackColor
        ElseIf Estatus = "AUTORIZADO" Then
            TipoColor = pnlBalanceoAutorizado.BackColor
        Else
            TipoColor = Color.Empty
        End If

        Return TipoColor
    End Function

    Private Sub btnGenerarBalanceo_Click(sender As Object, e As EventArgs) Handles btnGenerarBalanceo.Click
        Dim form As New Programacion_SimuladorBalanceoForm
        Dim NaveID As Integer = 0
        Dim BalanceoGeneradoSinGuardar As DataTable
        Dim objBU As New BalanceoNavesBU

        If cmbNave.Text <> "" Then
            NaveID = cmbNave.SelectedValue
        Else
            show_message("Advertencia", "Seleccione una nave.")
            Exit Sub
        End If


        BalanceoGeneradoSinGuardar = objBU.VerificarExisteBalanceoSinGuardar(NaveID, NSemanaInicio.Value, NAñoInicio.Value)

        If BalanceoGeneradoSinGuardar.Rows.Count > 0 Then
            If BalanceoGeneradoSinGuardar.Rows(0).Item("EstatusBalanceo").ToString = "ENVIADO PPCP" Or BalanceoGeneradoSinGuardar.Rows(0).Item("EstatusBalanceo").ToString = "AUTORIZADO" Then
                Tools.MostrarMensaje(Mensajes.Warning, "Verifique que el estatus de balanceo sea diferente a Enviado u Autorizado.")
                Exit Sub
            Else
                form.cambiosRealizados = 1
                form.semana = NSemanaInicio.Value
                form.idnave = NaveID
                form.nave = cmbNave.Text
                form.anio = NAñoInicio.Value
                form.idBalanceo = BalanceoGeneradoSinGuardar.Rows(0).Item("idBalanceo")
                form.MdiParent = Me.MdiParent
                form.Show()
            End If
            btnMostrar_Click(Nothing, Nothing)
        End If


    End Sub

    Private Sub btnGenerarPreLoteo_Click(sender As Object, e As EventArgs) Handles btnGenerarPreLoteo.Click
        Dim datosPreLoteoForm As New Programacion_BalanceoNaves_DatosPreLoteo
        Dim EstatusID As String = ""
        Dim NumeroFilas As Integer = vwAdmBalanceo.DataRowCount
        Dim cantidadBalanceo As Integer = 0

        If vwAdmBalanceo.DataRowCount > 0 Then
            With vwAdmBalanceo
                For index As Integer = 0 To NumeroFilas Step 1
                    If .GetRowCellValue(index, " ") Then
                        cantidadBalanceo += 1
                        EstatusID = .GetRowCellValue(index, "ST")
                        NaveID = .GetRowCellValue(index, "NaveID")
                    End If
                Next
            End With

            If cantidadBalanceo = 1 And EstatusID = "AUTORIZADO" Then
                datosPreLoteoForm.Semana = Semana
                datosPreLoteoForm.NaveID = NaveID
                datosPreLoteoForm.Año = Año
                datosPreLoteoForm.ShowDialog()
            Else
                show_message("Advertencia", "Seleccione un solo registro que se encuentre autorizado.")
            End If
        Else
            show_message("Advertencia", "Seleccione un registro.")
        End If


    End Sub
End Class