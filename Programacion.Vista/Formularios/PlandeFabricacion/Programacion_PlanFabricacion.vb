Imports System.IO
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Framework.Negocios
Imports Programacion.Negocios
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Export
Imports Tools
Imports Tools.modMensajes

Public Class Programacion_PlanFabricacion
    Dim advertencia As New AdvertenciaForm
    Dim NaveID As Integer = 0
    Dim Semana As Integer = 0
    Dim Año As Integer = 0
    Dim confirmar As New ConfirmarForm
    Dim Accion As Integer = 0
    Dim Exportado As Boolean = False
    Dim EstatusPlanFabricacion As String = String.Empty

    Private Sub Programacion_PlanFabricacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        NSemanaInicio.Value = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        NSemanaInicio.TextAlign = HorizontalAlignment.Center
        NAñoInicio.Value = DatePart(DateInterval.Year, Now)
        NAñoInicio.TextAlign = HorizontalAlignment.Center
        ConsultarPermisos()
        CargarNaveSegunUsuario()
        lblUltimaActualizacion.Text = ""
        lblSemanaActual.Text = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
    End Sub

    Private Sub ConsultarPermisos()

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PLAN_FABRICACION", "PLA_CONTROL_TOTAL") Then
            pnlSolicitaModificaciones.Visible = True
            pnlBitacora.Visible = True
            pnlEnviarCorreo.Visible = True

        Else
            pnlSolicitaModificaciones.Visible = False
            pnlBitacora.Visible = False
            pnlEnviarCorreo.Visible = False

        End If

    End Sub

    Private Sub CargarNaveSegunUsuario()
        Dim UsuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim objBU As New PlanFabricacionBU
        Dim dtNaves As New DataTable

        dtNaves = objBU.ObtenerNavesPorUsuario(UsuarioID)

        If dtNaves.Rows.Count > 0 Then

            If dtNaves.Rows.Count = 1 Then

                cmbNave.Enabled = False
                cmbGrupo.Visible = False
                lblGrupo.Visible = False
                pnlCambiosRealizados.Visible = False

            Else
                dtNaves.Rows.InsertAt(dtNaves.NewRow, 0)

                cmbNave.Enabled = True
                cmbGrupo.Visible = True
                lblGrupo.Visible = True
                pnlCambiosRealizados.Visible = True
            End If

            cmbNave.DataSource = dtNaves
            cmbNave.ValueMember = "NaveID"
            cmbNave.DisplayMember = "Nave"

        Else
            advertencia.mensaje = "El usuario no cuenta con una nave asignada."
            advertencia.ShowDialog()
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

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New PlanFabricacionBU
        Dim dtObtienePlanFabricacion As New DataTable
        Dim Grupo As String = String.Empty

        If cmbGrupo.Text = "TODAS" Or cmbGrupo.Text = "RVO" Or cmbGrupo.Text = "FVO" Then
            Grupo = cmbGrupo.Text
        End If

        If Grupo = "" Then
            If cmbNave.Text <> "" Then
                NaveID = cmbNave.SelectedValue
            Else
                show_message("Advertencia", "Seleccione una Nave.")
                Exit Sub
            End If
        End If

        Semana = NSemanaInicio.Value
        Año = NAñoInicio.Value

        Try
            Cursor = Cursors.WaitCursor

            grdPlanFabricacion.DataSource = Nothing
            vwPlanFabricacion.Columns.Clear()

            dtObtienePlanFabricacion = objBU.ObtienePlanFabricacion(NaveID, Semana, Año, Grupo)

            If dtObtienePlanFabricacion.Rows.Count > 0 Then
                grdPlanFabricacion.DataSource = dtObtienePlanFabricacion
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
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwPlanFabricacion.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName <> " " Then
                col.OptionsColumn.AllowEdit = False
            Else
                col.OptionsColumn.AllowEdit = True
            End If
        Next

        vwPlanFabricacion.Columns.ColumnByFieldName(" ").Width = 30
        vwPlanFabricacion.Columns.ColumnByFieldName("ST").Width = 20
        vwPlanFabricacion.Columns.ColumnByFieldName("Descripción").Width = 200
        vwPlanFabricacion.Columns.ColumnByFieldName("Nave").Width = 100
        vwPlanFabricacion.Columns.ColumnByFieldName("Usuario Creó").Width = 100
        vwPlanFabricacion.Columns.ColumnByFieldName("Fecha Creación").Width = 100
        vwPlanFabricacion.Columns.ColumnByFieldName("Fecha Modifica PPCP").Width = 100
        vwPlanFabricacion.Columns.ColumnByFieldName("Usuario Nave Autoriza").Width = 100
        vwPlanFabricacion.Columns.ColumnByFieldName("Fecha Autoriza Nave").Width = 100
        vwPlanFabricacion.Columns.ColumnByFieldName("Fecha Solicita Cambio").Width = 100
        vwPlanFabricacion.Columns.ColumnByFieldName("Usuario Solicita Cambio").Width = 100
        vwPlanFabricacion.Columns.ColumnByFieldName("Observaciones").Width = 270

        vwPlanFabricacion.Columns.ColumnByFieldName("ST").Caption = " "
        vwPlanFabricacion.Columns.ColumnByFieldName("Observaciones").Caption = "Última Observación"

        vwPlanFabricacion.Columns.ColumnByFieldName("TieneSAY").Visible = False
        vwPlanFabricacion.Columns.ColumnByFieldName("EstatusNombre").Visible = False
        vwPlanFabricacion.Columns.ColumnByFieldName("NaveID").Visible = False

        DiseñoGrid.AlternarColorEnFilas(vwPlanFabricacion)

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


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click

        If vwPlanFabricacion.DataRowCount > 0 Then
            Try
                Dim cantidadPlanFabricacion As Integer = 0
                Dim NumeroFilas As Integer = vwPlanFabricacion.DataRowCount
                Dim objBU As New PlanFabricacionBU
                Dim TieneSAY As Boolean = False
                Dim NaveIDPlan As Integer = 0
                Dim NaveNombre As String = String.Empty

                With vwPlanFabricacion
                    For index As Integer = 0 To NumeroFilas Step 1
                        If .GetRowCellValue(index, " ") Then
                            cantidadPlanFabricacion += 1
                            TieneSAY = .GetRowCellValue(index, "TieneSAY")
                            NaveIDPlan = .GetRowCellValue(index, "NaveID")
                            NaveNombre = .GetRowCellValue(index, "Nave")
                        End If
                    Next
                End With

                If cantidadPlanFabricacion = 1 Then
                    Dim dtObtienePlanFabricacion As New DataTable("dtPlanFabricacion")
                    Dim objBUReporte As New ReportesBU
                    Dim EntidadReporte As New Entidades.Reportes
                    Dim MasterPlanFabricacion As New DataSet("MasterPlanFabricacion")


                    Cursor = Cursors.WaitCursor

                    If cmbNave.SelectedIndex <> 0 Then
                        NaveID = cmbNave.SelectedValue
                    Else
                        NaveID = NaveIDPlan
                    End If

                    Semana = NSemanaInicio.Value
                    Año = NAñoInicio.Value

                    dtObtienePlanFabricacion = objBU.ObtienePlanFabricacionReporte(NaveID, Semana, Año)

                    dtObtienePlanFabricacion.Columns(10).ColumnName = 1
                    dtObtienePlanFabricacion.Columns(11).ColumnName = 2
                    dtObtienePlanFabricacion.Columns(12).ColumnName = 3
                    dtObtienePlanFabricacion.Columns(13).ColumnName = 4

                    MasterPlanFabricacion.Tables.Add(dtObtienePlanFabricacion)

                    EntidadReporte = objBUReporte.LeerReporteporClave("RPT_PLANFABRICACION")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                                            EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport()

                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("Semana1") = Str(Semana)
                    reporte("Semana2") = Str(Semana + 1)
                    reporte("Semana3") = Str(Semana + 2)
                    reporte("Semana4") = Str(Semana + 3)
                    reporte("Nave") = IIf(cmbNave.Text = "", NaveNombre, cmbNave.Text)
                    reporte("Usuario") = dtObtienePlanFabricacion.Rows(0).Item("Usuario").ToString()
                    reporte("Fecha") = dtObtienePlanFabricacion.Rows(0).Item("Fecha")
                    reporte.Dictionary.Clear()
                    reporte.RegData(MasterPlanFabricacion)
                    reporte.Dictionary.Synchronize()

                    If TieneSAY = False Then
                        Dim formatoExcel As StiExcelExportSettings = New StiExcelExportSettings()
                        Dim rutaPlanFabricacion As String = String.Empty

                        rutaPlanFabricacion = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\PlanFabricacion\NavesSinSAY"

                        If Not System.IO.Directory.Exists(rutaPlanFabricacion) Then
                            Directory.CreateDirectory(rutaPlanFabricacion)
                        End If

                        reporte.Render()
                        formatoExcel.ExportObjectFormatting = True
                        StiOptions.Export.Excel.ShowGridLines = False
                        Exportado = True
                        reporte.ExportDocument(StiExportFormat.Excel, rutaPlanFabricacion + "\Plan Fabricacion Semana " + Semana.ToString + "-" + Año.ToString + " Nave " + cmbNave.Text.ToUpperInvariant + ".xls")
                    End If

                    reporte.Show()
                Else
                    show_message("Advertencia", "Seleccione un solo plan para generar vista previa.")

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)

            Finally
                Cursor = Cursors.Default
            End Try
        Else
            show_message("Advertencia", "No hay información para exportar.")
            '
        End If

    End Sub

    Private Sub btnObservaciones_Click(sender As Object, e As EventArgs) Handles btnObservaciones.Click
        Dim SolicitaCambios As New Programacion_PlanFabricacion_SolicitudCambios
        Dim NumeroFilas As Integer = vwPlanFabricacion.DataRowCount
        Dim cantidadPlanFabricacion As Integer = 0
        Dim EstatusID As Integer = 0

        If vwPlanFabricacion.DataRowCount > 0 Then



            With vwPlanFabricacion
                For index As Integer = 0 To NumeroFilas Step 1
                    If .GetRowCellValue(index, " ") Then
                        cantidadPlanFabricacion += 1
                        EstatusID = .GetRowCellValue(index, "ST")
                    End If
                Next
            End With

            If cantidadPlanFabricacion = 1 And EstatusID <> 444 Then
                SolicitaCambios.Año = Año
                SolicitaCambios.Semana = Semana

                If cmbNave.Text = "" Then
                    show_message("Advertencia", "Seleccione una nave.")
                    Exit Sub
                Else
                    SolicitaCambios.NaveID = cmbNave.SelectedValue
                End If
                SolicitaCambios.ShowDialog()
                btnMostrar_Click(Nothing, Nothing)
            ElseIf cantidadPlanFabricacion > 1 Then
                show_message("Advertencia", "Seleccione un plan no autorizado para colocar observaciones.")
            Else
                show_message("Advertencia", "Seleccione un plan no autorizado para colocar observaciones.")
            End If


        Else
            show_message("Advertencia", "Seleccione un registro para colocar observaciones")
            Exit Sub
        End If
    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        Dim objBU As New PlanFabricacionBU
        Dim NumeroFilas As Integer = vwPlanFabricacion.DataRowCount
        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")

        Try
            With vwPlanFabricacion

                For index As Integer = 0 To NumeroFilas Step 1
                    If .GetRowCellValue(index, " ") Then
                        Dim vNodo As XElement = New XElement("Celda")
                        vNodo.Add(New XAttribute("NaveId", .GetRowCellValue(index, "NaveID")))
                        vNodo.Add(New XAttribute("Semana", Semana))
                        vNodo.Add(New XAttribute("Año", Año))
                        vNodo.Add(New XAttribute("UsuarioModificoId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                        Dim EstatusID = .GetRowCellValue(index, "ST")

                        If EstatusID <> 444 And EstatusID <> 443 Then
                            vNodo.Add(New XAttribute("EstatusID", .GetRowCellValue(index, "ST")))
                        Else
                            show_message("Advertencia", "Seleccione un plan al que se le hayan realizado las modificaciones.")
                            Exit Sub
                        End If

                        vXmlCeldasModificadas.Add(vNodo)
                    End If
                Next
            End With

            If vXmlCeldasModificadas.HasElements = True Then
                confirmar.mensaje = "¿Desea autorizar el plan de fabricación de la semana " + Semana.ToString + " ? No se podrá revertir esta acción."
                If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Accion = 1

                    objBU.AutorizarPlanFabricacion(vXmlCeldasModificadas.ToString(), Accion)
                    'EnvioAvisoCorreo()
                    show_message("Exito", "Plan autorizado correctamente.")
                    btnMostrar_Click(Nothing, Nothing)
                End If
            Else
                show_message("Advertencia", "Seleccione un plan con las modificaciones realizadas para esta acción.")
            End If



            'Else
            '    show_message("Advertencia", "Seleccione un plan con las modificaciones realizadas para esta acción.")
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally

        End Try

    End Sub

    Private Sub btnBitacora_Click(sender As Object, e As EventArgs) Handles btnBitacora.Click
        Dim BitacoraCambios As New Programacion_PlanFabricacion_BitacoraCambiosSolicitados

        Try
            BitacoraCambios.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub vwPlanFabricacion_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwPlanFabricacion.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub vwPlanFabricacion_CustomDrawCell(sender As Object, e As Views.Base.RowCellCustomDrawEventArgs) Handles vwPlanFabricacion.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)


        If vwPlanFabricacion.DataRowCount > 0 Then
            If e.Column.FieldName = "ST" Then
                e.Appearance.BackColor = ObtenerColorEstatus(currentView.GetRowCellValue(e.RowHandle, "ST"))
                e.Appearance.ForeColor = ObtenerColorEstatus(currentView.GetRowCellValue(e.RowHandle, "ST"))
            End If
        End If

    End Sub

    Private Function ObtenerColorEstatus(ByVal Estatus As Integer) As Color
        Dim TipoColor As Color = Color.Empty

        If Estatus = 442 Then
            TipoColor = pnlEnviadoPPCP.BackColor
        ElseIf Estatus = 443 Then
            TipoColor = pnlSolicitaModificaciones.BackColor
        ElseIf Estatus = 444 Then
            TipoColor = pnlPlanAutorizado.BackColor
        Else
            TipoColor = Color.Empty
        End If

        Return TipoColor
    End Function



    Public Function GenerarAlertaDesdeMDIParent(ByVal UsuarioID As Integer, ByVal SemanaActual As Integer, ByVal AñoActual As Integer) As DataTable

        Dim objBU As New PlanFabricacionBU
        Dim dtObtieneInformacionAlerta As New DataTable

        dtObtieneInformacionAlerta = objBU.GenerarAlertaDesdeMDIParent(UsuarioID, SemanaActual, AñoActual)

        Return dtObtieneInformacionAlerta

    End Function

    Private Function generarXML()

        Dim Contador As Integer = 0
        Dim NaveIDPlan As Integer = 0

        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
        For i = 0 To vwPlanFabricacion.RowCount - 1
            If vwPlanFabricacion.GetRowCellValue(i, " ") Then
                Contador += 1
                EstatusPlanFabricacion = vwPlanFabricacion.GetRowCellValue(i, "EstatusNombre")
                NaveIDPlan = vwPlanFabricacion.GetRowCellValue(i, "NaveID")
            End If
        Next

        If Contador >= 2 Then
            show_message("Advertencia", "Seleccione un registro para realizar esta acción.")
            Exit Function
        End If

        Dim vNodo As XElement = New XElement("Celda")
        vNodo.Add(New XAttribute("NaveId", IIf(NaveID = 0, NaveIDPlan, NaveID)))
        vNodo.Add(New XAttribute("Semana", Semana))
        vNodo.Add(New XAttribute("UsuarioModificoId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))

        vXmlCeldasModificadas.Add(vNodo)

        Return vXmlCeldasModificadas

    End Function

    Private Sub EnvioAvisoCorreo()
        Dim remitente As String = String.Empty
        Dim asuntoCorreo As String = String.Empty
        Dim cadenaCorreo As String = String.Empty
        Dim entCorreo As New Entidades.DatosCorreo
        Dim CorreosDestinatario As String = String.Empty
        Dim dtCorreosDestinarios As New DataTable
        Dim correo As New Tools.Correo
        Dim objBU As New PlanFabricacionBU
        Dim dtResultadoDatosCorreos As New DataTable
        Dim NaveNombre As String = String.Empty
        Dim vXmlCeldasModificadas As XElement = generarXML()

        Try

            dtCorreosDestinarios = objBU.ObtenerCorreosDestinatario(vXmlCeldasModificadas.ToString())
            dtResultadoDatosCorreos = objBU.consultaCorreosEnvioFactura("ENVIO_FACTURAS_CLIENTES")
            remitente = dtResultadoDatosCorreos.Rows(0).Item("CorreoEnvia").ToString()


            If dtCorreosDestinarios.Rows.Count > 0 Then

                CorreosDestinatario = dtCorreosDestinarios.Rows(0).Item("Destinos").ToString()
                NaveNombre = dtCorreosDestinarios.Rows(0).Item("Nave")


                asuntoCorreo = "Asunto: Aviso Plan de Fabricación Semana " + Semana.ToString() + "-" + Año.ToString() + " de la nave " + NaveNombre

                cadenaCorreo = "<html> " +
                                 " <head>" +
                                 " </head>"
                cadenaCorreo += " <body> "
                cadenaCorreo += " <br><p>Buen día</p>"
                cadenaCorreo += " <br><p>Se ACEPTA el plan de fabricación de la semana " + Semana.ToString() + "-" + Año.ToString() + " de la nave " + NaveNombre + " 
                                           ,favor de generar el balanceo semanal correspondiente.</p>"


                cadenaCorreo += " <p>Saludos!!!</p>"
                cadenaCorreo += " <br><p><b>Favor de no contestar este correo, este es un envío automático.</b></p>"
                cadenaCorreo += " </body> " +
                                    " </html> "


                correo.EnviarCorreoHtml(CorreosDestinatario, remitente, asuntoCorreo, cadenaCorreo)

            Else
                advertencia.mensaje = "No existen destinatarios para envío de correo."
                advertencia.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub btnCambiosRealizados_Click(sender As Object, e As EventArgs) Handles btnCambiosRealizados.Click
        Dim objBU As New PlanFabricacionBU
        Dim NumeroFilas As Integer = vwPlanFabricacion.DataRowCount
        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")

        Try

            With vwPlanFabricacion

                For index As Integer = 0 To NumeroFilas Step 1
                    If .GetRowCellValue(index, " ") Then
                        Dim vNodo As XElement = New XElement("Celda")
                        vNodo.Add(New XAttribute("NaveId", .GetRowCellValue(index, "NaveID")))
                        vNodo.Add(New XAttribute("Semana", Semana))
                        vNodo.Add(New XAttribute("Año", Año))
                        vNodo.Add(New XAttribute("UsuarioModificoId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                        Dim EstatusID = .GetRowCellValue(index, "ST")

                        If EstatusID <> 444 Then
                            vNodo.Add(New XAttribute("EstatusID", .GetRowCellValue(index, "ST")))
                        Else
                            show_message("Advertencia", "Seleccione un plan al que se le hayan realizado las modificaciones.")
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

                    objBU.AutorizarPlanFabricacion(vXmlCeldasModificadas.ToString(), Accion)
                    'EnvioAvisoCorreoModificacionesRealizadas(generarXML)
                    show_message("Exito", "Plan en estatus Enviado PPCP.")
                    btnMostrar_Click(Nothing, Nothing)
                End If
            Else
                show_message("Advertencia", "Seleccione un plan no autorizado para cambiar de estatus a enviado PPCP.")
            End If


            'Else
            '    show_message("Advertencia", "Seleccione un plan no autorizado para cambiar de estatus a enviado PPCP.")
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally

        End Try
    End Sub



    Private Function EnvioAvisoCorreoModificacionesRealizadas(ByVal vXmlCeldasModificadas As XElement) As Boolean
        Dim CorreoEnviado As String = String.Empty
        Dim dtResultadoDatosCorreos As New DataTable
        Dim objBU As New PlanFabricacionBU
        Dim remitente As String = String.Empty
        Dim asuntoCorreo As String = String.Empty
        Dim cadenaCorreo As String = String.Empty
        Dim entCorreo As New Entidades.DatosCorreo
        Dim CorreosDestinatario As String = String.Empty
        Dim dtCorreosDestinarios As New DataTable
        Dim correo As New Tools.Correo
        Dim StatusCorreo As Boolean = False

        Dim NaveNombre As String = String.Empty
        Dim rutaPlanFabricacion As String = String.Empty
        Dim archivoAdjunto As System.Net.Mail.Attachment
        Dim lstArchivoAdjuntos As New List(Of System.Net.Mail.Attachment)
        Dim rutaPlanAdjunto As String = String.Empty
        Dim TieneSAY As Boolean = False

        Try

            dtCorreosDestinarios = objBU.ObtenerCorreosDestinatario(vXmlCeldasModificadas.ToString())
            dtResultadoDatosCorreos = objBU.consultaCorreosEnvioFactura("ENVIO_FACTURAS_CLIENTES")
            remitente = dtResultadoDatosCorreos.Rows(0).Item("CorreoEnvia").ToString()



            If dtCorreosDestinarios.Rows.Count > 0 Then

                CorreosDestinatario = dtCorreosDestinarios.Rows(0).Item("Destinos").ToString()
                NaveNombre = dtCorreosDestinarios.Rows(0).Item("Nave")
                TieneSAY = CBool(dtCorreosDestinarios.Rows(0).Item("TieneSAY").ToString())

                asuntoCorreo = "Asunto: Aviso Plan de Fabricación Semana " + Semana.ToString() + "-" + Año.ToString() + " de la nave " + NaveNombre

                Cursor = Cursors.WaitCursor

                Select Case TieneSAY


                    Case 0

                        rutaPlanAdjunto = "Plan Fabricacion Semana " + Semana.ToString() + "-" + Año.ToString + " Nave " + NaveNombre

                        rutaPlanFabricacion = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\PlanFabricacion\NavesSinSAY\" + rutaPlanAdjunto + ".xls"

                        If rutaPlanFabricacion <> String.Empty Then
                            archivoAdjunto = New System.Net.Mail.Attachment(rutaPlanFabricacion)
                            lstArchivoAdjuntos.Add(archivoAdjunto)

                        End If

                        cadenaCorreo = "<html> " +
                                    " <head>" +
                                    " </head>"
                        cadenaCorreo += " <body> "
                        cadenaCorreo += " <br><p>Buen día</p>"
                        cadenaCorreo += " <br><p>Envío plan de fabricación correspondiente a la semana " + Semana.ToString() + " de la nave " + NaveNombre + "  </p>"
                        cadenaCorreo += " <p>Favor de revisar disponibilidad de materiales y factibilidad del proceso. </p>"
                        cadenaCorreo += " <p>Quedo al pendiente de su respuesta y a sus órdenes para cualquier duda o comentario.</p>"
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

                    Case 1

                        cadenaCorreo = "<html> " +
                                    " <head>" +
                                    " </head>"
                        cadenaCorreo += " <body> "
                        cadenaCorreo += " <br><p>Buen día</p>"
                        cadenaCorreo += " <br><p>Les comento que el plan de fabricación correspondiente a la semana " + Semana.ToString() + " de la nave " + NaveNombre + " se encuentra ya disponible 
                                           en sistema para su análisis y revisión de viabilidad.</p>"
                        cadenaCorreo += " <p>Favor de revisar disponibilidad de materiales y factibilidad del proceso. </p>"
                        cadenaCorreo += " <p>Si tienen cualquier observación favor de colocarla en el módulo, en caso contrario autorizar dicho plan dentro del mismo módulo.</p>"
                        cadenaCorreo += " <br><p><b>Favor de no contestar este correo</b></p>"
                        cadenaCorreo += " <p>Saludos!!!</p>"
                        cadenaCorreo += " </body> " +
                                            " </html> "


                        correo.EnviarCorreoHtml(CorreosDestinatario, remitente, asuntoCorreo, cadenaCorreo)

                        CorreoEnviado = "S"
                        StatusCorreo = True

                End Select

            Else
                advertencia.mensaje = "No existen destinatarios para envío de correo."
                advertencia.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

        Return StatusCorreo
    End Function

    Private Sub btnReenviarCorreo_Click(sender As Object, e As EventArgs) Handles btnReenviarCorreo.Click
        If ReenviarCorreo(generarXML()) Then
            show_message("Exito", "Correo enviado correctamente.")

        Else
            show_message("Advertencia", "Ocurrió un error, intente nuevamente.")
        End If

    End Sub

    Private Function ReenviarCorreo(ByVal vXmlCeldasModificadas As XElement)
        Dim CorreoEnviado As String = String.Empty
        Dim dtResultadoDatosCorreos As New DataTable
        Dim objBU As New PlanFabricacionBU
        Dim remitente As String = String.Empty
        Dim asuntoCorreo As String = String.Empty
        Dim cadenaCorreo As String = String.Empty
        Dim entCorreo As New Entidades.DatosCorreo
        Dim CorreosDestinatario As String = String.Empty
        Dim dtCorreosDestinarios As New DataTable
        Dim correo As New Tools.Correo
        Dim StatusCorreo As Boolean = False

        Dim NaveNombre As String = String.Empty
        Dim rutaPlanFabricacion As String = String.Empty
        Dim archivoAdjunto As System.Net.Mail.Attachment
        Dim lstArchivoAdjuntos As New List(Of System.Net.Mail.Attachment)
        Dim rutaPlanAdjunto As String = String.Empty
        Dim TieneSAY As Boolean = False

        Try


            Cursor = Cursors.WaitCursor

            dtCorreosDestinarios = objBU.ObtenerCorreosDestinatario(vXmlCeldasModificadas.ToString())
            dtResultadoDatosCorreos = objBU.consultaCorreosEnvioFactura("ENVIO_FACTURAS_CLIENTES")
            remitente = dtResultadoDatosCorreos.Rows(0).Item("CorreoEnvia").ToString()

            If dtCorreosDestinarios.Rows.Count > 0 Then
                CorreosDestinatario = dtCorreosDestinarios.Rows(0).Item("Destinos").ToString()
                NaveNombre = dtCorreosDestinarios.Rows(0).Item("Nave")
                TieneSAY = CBool(dtCorreosDestinarios.Rows(0).Item("TieneSAY").ToString())

                asuntoCorreo = "Asunto: Aviso Plan de Fabricación " + StrConv(EstatusPlanFabricacion, vbProperCase) + " Semana " + Semana.ToString() + "-" + Año.ToString() + " de la nave " + NaveNombre

                Select Case TieneSAY
                    Case 0  'No tienen SAY

                        Select Case EstatusPlanFabricacion

                            Case "ENVIADO PPCP"

                                rutaPlanAdjunto = "Plan Fabricacion Semana " + Semana.ToString() + "-" + Año.ToString + " Nave " + NaveNombre

                                rutaPlanFabricacion = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\PlanFabricacion\NavesSinSAY\" + rutaPlanAdjunto + ".xls"

                                If rutaPlanFabricacion <> String.Empty Then
                                    archivoAdjunto = New System.Net.Mail.Attachment(rutaPlanFabricacion)
                                    lstArchivoAdjuntos.Add(archivoAdjunto)

                                End If

                                cadenaCorreo = "<html> " +
                                            " <head>" +
                                            " </head>"
                                cadenaCorreo += " <body> "
                                cadenaCorreo += " <br><p>Buen día</p>"
                                cadenaCorreo += " <br><p>Envío plan de fabricación correspondiente a la semana " + Semana.ToString() + " de la nave " + NaveNombre + "  </p>"
                                cadenaCorreo += " <p>Favor de revisar disponibilidad de materiales y factibilidad del proceso. </p>"
                                cadenaCorreo += " <p>Quedo al pendiente de su respuesta y a sus órdenes para cualquier duda o comentario.</p>"
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

                            Case Else
                                show_message("Advertencia", "Movimiento sin archivo adjunto.")
                                Exit Function

                        End Select

                    Case 1 'SI TIENEN SAY 

                        Select Case EstatusPlanFabricacion
                            Case "ENVIADO PPCP"

                                cadenaCorreo = "<html> " +
                                    " <head>" +
                                    " </head>"
                                cadenaCorreo += " <body> "
                                cadenaCorreo += " <br><p>Buen día</p>"
                                cadenaCorreo += " <br><p>Les comento que el plan de fabricación correspondiente a la semana " + Semana.ToString() + " de la nave " + NaveNombre + " se encuentra ya disponible 
                                           en sistema para su análisis y revisión de viabilidad.</p>"
                                cadenaCorreo += " <p>Favor de revisar disponibilidad de materiales y factibilidad del proceso. </p>"
                                cadenaCorreo += " <p>Si tienen cualquier observación favor de colocarla en el módulo, en caso contrario autorizar dicho plan dentro del mismo módulo.</p>"
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
                                cadenaCorreo += " <br><p>Se RECHAZA el plan de fabricación de la semana " + Semana.ToString() + "-" + Año.ToString() + " de la nave " + NaveNombre + " 
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
                                cadenaCorreo += " <br><p>Se ACEPTA el plan de fabricación de la semana " + Semana.ToString() + "-" + Año.ToString() + " de la nave " + NaveNombre + " 
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
End Class