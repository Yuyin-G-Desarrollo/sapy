Imports System.IO
Imports DevExpress.XtraGrid
Imports Framework.Negocios
Imports Programacion.Negocios
Imports Stimulsoft.Report
Imports Tools

Public Class Programacion_ColocacionSemanal_CerrarSemanasForm
    Public tabla As DataTable
    Public año As Integer
    Dim objExito As New Tools.ExitoForm
    Dim advertencia As New AdvertenciaForm
    Public TieneSAY As Boolean = False
    Public Exportado As Boolean

    Private Sub diseñoGrid()
        grdVReporte.OptionsView.ColumnAutoWidth = True
        grdVReporte.OptionsView.EnableAppearanceEvenRow = True
        grdVReporte.OptionsSelection.EnableAppearanceFocusedRow = True
        grdVReporte.IndicatorWidth = 30
        grdVReporte.OptionsView.ShowAutoFilterRow = False
        grdVReporte.OptionsView.RowAutoHeight = True
        grdVReporte.OptionsClipboard.AllowCopy = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
        Next
        grdVReporte.Columns.ColumnByFieldName(" ").Visible = False
        grdVReporte.Columns.ColumnByFieldName("NaveId").Visible = False
        'grdVReporte.Columns.ColumnByFieldName("Capacidad").Visible = False
        'grdVReporte.Columns.ColumnByFieldName("ATR").Visible = False
        'grdVReporte.Columns.ColumnByFieldName("CapacidadOriginal").Visible = False
        'grdVReporte.Columns.ColumnByFieldName("ATROriginal").Visible = False
        grdVReporte.BestFitColumns()
    End Sub
    Private Function generarXML()
        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
        For i = 0 To grdVReporte.RowCount - 1
            Dim vNodo As XElement = New XElement("Celda")
            vNodo.Add(New XAttribute("NaveId", grdVReporte.GetRowCellValue(i, "NaveId")))
            vNodo.Add(New XAttribute("Semana", grdVReporte.GetRowCellValue(i, "Semana")))
            vNodo.Add(New XAttribute("UsuarioModificoId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
            vXmlCeldasModificadas.Add(vNodo)
        Next
        Return vXmlCeldasModificadas
    End Function
    Private Sub Programacion_ColocacionSemanal_CerrarSemanasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdReporte.DataSource = tabla
        diseñoGrid()
    End Sub
    Private Sub grdVReporte_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdVReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim obj As New Programacion_MapaOcupacionBU
        Dim vXmlCeldasModificadas As XElement = generarXML()
        Dim mensajeCorreo As String = String.Empty
        Dim NaveID As String = ""
        Dim Semana As String = ""
        Dim Nave As String = ""
        Dim AñoPlan As Integer = 0
        Dim Usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        Dim reporte As New StiReport()

        Dim objBU As New PlanFabricacionBU
        Dim dtObtienePlanFabricacion As New DataTable("dtPlanFabricacion")
        Dim objBUReporte As New ReportesBU
        Dim EntidadReporte As New Entidades.Reportes
        Dim MasterPlanFabricacion As New DataSet("MasterPlanFabricacion")

        If chPlanFabricacion.Checked = True Then
            For Each row As DataRow In tabla.Rows
                If NaveID <> "" Then
                    NaveID += ","
                End If

                If Semana <> "" Then
                    Semana += ","
                End If

                If Nave <> "" Then
                    Nave += ","
                End If

                NaveID = row.Item("NaveId").ToString()
                Semana = row.Item("Semana").ToString()
                Nave = row.Item("Nave").ToString()
                AñoPlan = row.Item("Año").ToString()
            Next

            dtObtienePlanFabricacion = objBU.ObtienePlanFabricacionReporte(NaveID, Semana, AñoPlan)

            If dtObtienePlanFabricacion.Rows.Count > 0 Then

                dtObtienePlanFabricacion.Columns(10).ColumnName = 1
                dtObtienePlanFabricacion.Columns(11).ColumnName = 2
                dtObtienePlanFabricacion.Columns(12).ColumnName = 3
                dtObtienePlanFabricacion.Columns(13).ColumnName = 4


                MasterPlanFabricacion.Tables.Add(dtObtienePlanFabricacion)

                EntidadReporte = objBUReporte.LeerReporteporClave("RPT_PLANFABRICACION")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                                        EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)


                reporte.Load(archivo)
                reporte.Compile()
                reporte("Semana1") = Semana
                reporte("Semana2") = Str(Semana + 1)
                reporte("Semana3") = Str(Semana + 2)
                reporte("Semana4") = Str(Semana + 3)
                reporte("Nave") = Nave
                reporte("Usuario") = Usuario
                reporte("Fecha") = dtObtienePlanFabricacion.Rows(0).Item("Fecha")

                reporte.Dictionary.Clear()
                reporte.RegData(MasterPlanFabricacion)
                reporte.Dictionary.Synchronize()

            End If

            reporte.Show(True)
        End If

        obj.CerrarSemana(vXmlCeldasModificadas.ToString, año) 'Descomentar para realizar las pruebas 
        'If EnviaCorreoPlanAutorizado(vXmlCeldasModificadas) = True Then
        '    mensajeCorreo = ", correo de aviso enviado. "

        'Else 
        '    mensajeCorreo = ", correo de aviso no enviado."
        'End If

        objExito.mensaje = "Datos guardados correctamente" + mensajeCorreo
        objExito.ShowDialog()
    End Sub

    Private Function EnviaCorreoPlanAutorizado(ByVal vXmlCeldasModificadas As XElement) As Boolean
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

        Try
            Dim Semana = (From celda In vXmlCeldasModificadas.Descendants("Celda")
                          Select New With {
                              .SemanaCerrada = CType(celda.Attribute("Semana"), String)}).FirstOrDefault()


            dtCorreosDestinarios = objBU.ObtenerCorreosDestinatario(vXmlCeldasModificadas.ToString())
            dtResultadoDatosCorreos = objBU.consultaCorreosEnvioFactura("ENVIO_FACTURAS_CLIENTES")
            remitente = dtResultadoDatosCorreos.Rows(0).Item("CorreoEnvia").ToString()



            If dtCorreosDestinarios.Rows.Count > 0 Then

                CorreosDestinatario = dtCorreosDestinarios.Rows(0).Item("Destinos").ToString()
                NaveNombre = dtCorreosDestinarios.Rows(0).Item("Nave")

                asuntoCorreo = "Asunto: Aviso Plan de Fabricación Semana " + Semana.SemanaCerrada.ToString() + " de la nave " + NaveNombre.ToString()
                Cursor = Cursors.WaitCursor

                Select Case TieneSAY


                    Case 0

                        If Exportado = False Then
                            advertencia.mensaje = "Para enviar el correo, necesita exportar el archivo."
                            advertencia.ShowDialog()
                            Exit Function
                        End If

                        rutaPlanAdjunto = "Plan Fabricacion Semana " + Semana.SemanaCerrada.ToString() + "-" + año.ToString + " Nave " + NaveNombre

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
                        cadenaCorreo += " <br><p>Envío plan de fabricación correspondiente a la semana " + Semana.SemanaCerrada.ToString() + " de la nave " + NaveNombre + "  </p>"
                        cadenaCorreo += " <p>Favor de revisar disponibilidad de materiales y factibilidad del proceso. </p>"
                        cadenaCorreo += " <p>Quedo al pendiente de su respuesta y a sus órdenes para cualquier duda o comentario.</p>"
                        cadenaCorreo += " <br><p><b>Favor de no contestar este correo, este es un envío automático</b></p>"
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
                        cadenaCorreo += " <br><p>Les comento que el plan de fabricación correspondiente a la semana " + Semana.SemanaCerrada.ToString() + " de la nave " + NaveNombre + " se encuentra ya disponible 
                                           en sistema para su análisis y revisión de viabilidad.</p>"
                        cadenaCorreo += " <p>Favor de revisar disponibilidad de materiales y factibilidad del proceso. </p>"
                        cadenaCorreo += " <p>Si tienen cualquier observación favor de colocarla en el módulo, en caso contrario autorizar dicho plan dentro del mismo módulo.</p>"
                        cadenaCorreo += " <br><p><b>Favor de no contestar este correo, este es un envío automático</b></p>"
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

        Finally
            Cursor = Cursors.Default
        End Try

        Return StatusCorreo
    End Function


End Class