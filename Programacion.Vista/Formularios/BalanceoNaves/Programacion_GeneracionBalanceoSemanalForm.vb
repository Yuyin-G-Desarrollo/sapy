Imports Programacion.Negocios
Imports Tools.modMensajes
Public Class Programacion_GeneracionBalanceoSemanalForm

    Dim usuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    Dim tblGrupo As New DataTable
    Dim tbllista As New DataTable
    Dim tblBalanceo As New DataTable
    Dim semana As Int32
    Dim anio As Integer
    Dim Grupo As String = String.Empty
    Dim sesionId As Integer
    Private Sub Programacion_GeneracionBalanceoSemanalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        LlenarSemanaAnio()
        nudSemana.Minimum = 1
    End Sub

    Private Sub LlenarSemanaAnio()
        semana = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        anio = DatePart(DateInterval.Year, Now)
        nudSemana.Value = semana
        nudAnio.Value = anio
    End Sub

    Private Sub cboGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGrupo.SelectedIndexChanged
        Dim tblCnaves As New DataTable
        Try
            Grupo = cboGrupo.Text
            tblCnaves = LlenarComboNaves(Grupo)
            tblCnaves.Rows.InsertAt(tblCnaves.NewRow, 0)
            cboNaves.DataSource = tblCnaves
            cboNaves.DisplayMember = "Nave"
            cboNaves.ValueMember = "NaveSAYId"
        Catch ex As Exception
        End Try
    End Sub
    Private Function LlenarComboNaves(ByVal Grupo As String) As DataTable
        Dim obj As New BalanceoNavesBU
        Dim tblNaves As New DataTable
        tblNaves = obj.ConsultarNavesXGrupo(Grupo)
        Return tblNaves
    End Function

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros.Visible = True
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Public Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim obj As New BalanceoNavesBU
        Dim idNave As Integer = 0
        Dim grupo As String = String.Empty
        Dim año As Integer
        Dim semana As Integer
        dgBalanceo.DataSource = Nothing
        dgVBalanceo.Columns.Clear()

        Try
            grupo = cboGrupo.Text

            If cboGrupo.Text = String.Empty Then
                Tools.MostrarMensaje(Mensajes.Warning, "Seleccione un grupo.")
                Return
            Else
                idNave = cboNaves.SelectedValue
                año = nudAnio.Value
                semana = nudSemana.Value

                tblBalanceo = obj.ConsultaBalanceoXNave(idNave, semana, año)
                If tblBalanceo.Rows.Count > 0 Then
                    dgBalanceo.DataSource = tblBalanceo
                    DisenioGrid()
                    lblRegistros.Text = tblBalanceo.Rows.Count
                    lblUltimaActualizacion.Text = Date.Now
                Else
                    Tools.MostrarMensaje(Mensajes.Warning, "No existe información para mostrar.")
                End If
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ocurrió un error.")
        End Try


    End Sub

    Private Sub DisenioGrid()
        dgVBalanceo.IndicatorWidth = 40
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In dgVBalanceo.Columns
            If col.FieldName = "IdNave" Then
                col.Visible = False
            End If
            If col.FieldName = "Nave" Then
                col.Caption = "Nave"
            End If
            If col.FieldName = "Semana" Then
                col.Caption = "Semana"
            End If
            If col.FieldName = "Año" Then
                col.Caption = "Año"
                col.Visible = False
            End If
            If col.FieldName = "EstatusPlan" Then
                col.Caption = "Estatus" & vbCrLf & "Plan"
            End If
            If col.FieldName = "EstatusPlanId" Then
                col.Caption = "Estatus plan id"
                col.Visible = False
            End If
            If col.FieldName = "ParesAProducir" Then
                col.Caption = "Pares a" & vbCrLf & "Producir"
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "N0"
            End If
            If col.FieldName = "ParesEquivalencia" Then
                col.Caption = "Equivalencia " & vbCrLf & "Pares"
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "N0"
            End If
            If col.FieldName = "CantidadArticulos" Then
                col.Caption = "Cantidad" & vbCrLf & " Artículos"
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "N0"
            End If
            If col.FieldName = "BalanceoGenerado" Then
                col.Caption = "Balanceo" & vbCrLf & "Generado"
            End If
            If col.FieldName = "Capacidad" Then
                col.Caption = "Capacidad"
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "N0"
            End If
            If col.FieldName = "UsuarioCreo" Then
                col.Caption = "Usuario" & vbCrLf & "Creó Balanceo"
            End If
            If col.FieldName = "UsuarioCreoID" Then
                col.Caption = "Usuario" & vbCrLf & "creo"
                col.Visible = False
            End If
            If col.FieldName = "FechaPlancreacion" Then
                col.Caption = "Fecha Plan" & vbCrLf & "Creación"
            End If
            If col.FieldName = "FechaPlanAutorizado" Then
                col.Caption = "Fecha Plan" & vbCrLf & "Autorizó"
            End If
            If col.FieldName = "FechaBalanceoModificaciones" Then
                col.Caption = "Fecha Balanceo" & vbCrLf & " Modificación"
            End If
            col.OptionsColumn.AllowEdit = False
        Next

        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(dgVBalanceo)
        Tools.DiseñoGrid.AlternarColorEnFilas(dgVBalanceo)
    End Sub

    Private Sub dgVBalanceo_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles dgVBalanceo.CustomDrawRowIndicator
        If (e.RowHandle >= 0) Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub

    Private Sub btnGenerarBalanceo_Click(sender As Object, e As EventArgs) Handles btnGenerarBalanceo.Click
        Dim obj As New BalanceoNavesBU
        Dim form As New Programacion_SimuladorBalanceoForm
        Dim tblREgistroSimulador As New DataTable
        Dim tblsesion As New DataTable
        Dim mensajeSesion As String = String.Empty
        Dim tblRegistroBalanceo As New DataTable
        Dim idbalanceo As Integer
        Dim tblSimulador As New DataTable
        Dim BalanceoGeneradoSinGuardar As DataTable
        Dim VerDetalles As Integer = 0

        If cboNaves.Text = "" Then
            Tools.MostrarMensaje(Mensajes.Warning, "Seleccione la nave.")
            Return
        End If

        If dgVBalanceo.RowCount > 0 Then

            Dim EstatusPlan As String = dgVBalanceo.GetRowCellValue(0, "EstatusPlan").ToString

            If EstatusPlan = "ABIERTA" Then
                Tools.MostrarMensaje(Mensajes.Warning, "Verifique que el plan de fabricación se encuentre autorizado.")
                Exit Sub
            End If

            If chVerDetalles.Checked = True Then
                VerDetalles = 1
            End If

            BalanceoGeneradoSinGuardar = obj.VerificarExisteBalanceoSinGuardar(cboNaves.SelectedValue, nudSemana.Value, nudAnio.Value)

            If BalanceoGeneradoSinGuardar.Rows.Count > 0 Then

                If BalanceoGeneradoSinGuardar.Rows(0).Item("EstatusBalanceo").ToString = "ENVIADO PPCP" Or BalanceoGeneradoSinGuardar.Rows(0).Item("EstatusBalanceo").ToString = "AUTORIZADO" Then
                    Tools.MostrarMensaje(Mensajes.Warning, "Verifique que el estatus de balanceo sea diferente a Enviado u Autorizado.")

                    Exit Sub
                Else
                    sesionId = BalanceoGeneradoSinGuardar.Rows(0).Item("SesionID").ToString()
                    idbalanceo = BalanceoGeneradoSinGuardar.Rows(0).Item("idBalanceo").ToString()

                    If sesionId <> 0 Then
                        obj.BalanceoNaves_GeneraRegistroBalanceoDetalle(idbalanceo, usuarioId, sesionId)
                    End If

                    form.semana = nudSemana.Value
                    form.idnave = cboNaves.SelectedValue
                    form.nave = cboNaves.Text
                    form.anio = nudAnio.Value
                    form.idBalanceo = BalanceoGeneradoSinGuardar.Rows(0).Item("idBalanceo")
                    form.verDetalles = VerDetalles
                    form.ShowDialog()
                    btnBuscar_Click(Nothing, Nothing)
                End If

            Else
                tblsesion = obj.SP_BalanceoNaves_GenerarSession(usuarioId, cboNaves.SelectedValue, nudSemana.Value, nudAnio.Value)
                sesionId = tblsesion.Rows(0).Item("SessionId")


                If sesionId <> 0 Then
                    tblSimulador = obj.SP_BalanceoNaves_GeneraRegistroSimulador(cboNaves.SelectedValue, nudSemana.Value, nudAnio.Value, sesionId)

                    If tblSimulador.Rows.Count > 0 Then
                        Dim vXmlRegistros As XElement = New XElement("Registros")
                        For i As Integer = 0 To tblBalanceo.Rows.Count - 1
                            Dim vNodo As XElement = New XElement("Registro")
                            vNodo.Add(New XAttribute("IdNave", tblBalanceo.Rows(i).Item("IdNave").ToString()))
                            vNodo.Add(New XAttribute("Nave", tblBalanceo.Rows(i).Item("Nave").ToString()))
                            vNodo.Add(New XAttribute("Semana", tblBalanceo.Rows(i).Item("Semana").ToString()))
                            vNodo.Add(New XAttribute("Año", tblBalanceo.Rows(i).Item("Año").ToString()))
                            vNodo.Add(New XAttribute("EstatusPlan", tblBalanceo.Rows(i).Item("EstatusPlan").ToString()))
                            vNodo.Add(New XAttribute("EstatusPlanId", tblBalanceo.Rows(i).Item("EstatusPlanId").ToString()))
                            vNodo.Add(New XAttribute("ParesAProducir", tblBalanceo.Rows(i).Item("ParesAProducir").ToString()))
                            vNodo.Add(New XAttribute("CantidadArticulos", tblBalanceo.Rows(i).Item("CantidadArticulos").ToString()))
                            vNodo.Add(New XAttribute("Capacidad", tblBalanceo.Rows(i).Item("Capacidad").ToString()))
                            vNodo.Add(New XAttribute("BalanceoGenerado", tblBalanceo.Rows(i).Item("BalanceoGenerado").ToString()))
                            vNodo.Add(New XAttribute("UsuarioCreoID", IIf(tblBalanceo.Rows(i).Item("UsuarioCreoID").ToString() <> "", tblBalanceo.Rows(i).Item("UsuarioCreoID").ToString(), usuarioId.ToString())))
                            vNodo.Add(New XAttribute("UsuarioCreo", IIf(tblBalanceo.Rows(i).Item("UsuarioCreo").ToString() <> "", tblBalanceo.Rows(i).Item("UsuarioCreo").ToString(), usuarioId.ToString())))
                            vNodo.Add(New XAttribute("FechaPlanCreacion", tblBalanceo.Rows(i).Item("FechaPlanCreacion").ToString()))
                            vNodo.Add(New XAttribute("FechaPlanAutorizado", tblBalanceo.Rows(i).Item("FechaPlanAutorizado").ToString()))
                            vNodo.Add(New XAttribute("FechaBalanceoModificaciones", tblBalanceo.Rows(i).Item("FechaBalanceoModificaciones").ToString()))
                            vXmlRegistros.Add(vNodo)
                        Next

                        tblRegistroBalanceo = obj.BalanceoNaves_GeneraRegistroBalanceo(nudAnio.Value, nudSemana.Value, cboNaves.SelectedValue, vXmlRegistros.ToString())
                        If tblRegistroBalanceo.Rows.Count > 0 Then
                            Dim dtGeneraAlgoritmoBalanceo As New DataTable

                            idbalanceo = tblRegistroBalanceo.Rows(0).Item("blnv_balanceonaveid")

                            Cursor = Cursors.WaitCursor

                            dtGeneraAlgoritmoBalanceo = obj.BalanceoNaves_GeneraAlgoritmoBalanceo(sesionId)

                            If dtGeneraAlgoritmoBalanceo.Rows(0).Item("respuesta") <> "ERROR" Then
                                Cursor = Cursors.Default
                                obj.BalanceoNaves_GeneraRegistroBalanceoDetalle(idbalanceo, usuarioId, sesionId)
                                form.semana = nudSemana.Value
                                form.idnave = cboNaves.SelectedValue
                                form.nave = cboNaves.Text
                                form.anio = nudAnio.Value
                                form.idBalanceo = idbalanceo
                                form.SesionID = sesionId
                                form.verDetalles = VerDetalles
                                form.ShowDialog()
                                btnBuscar_Click(Nothing, Nothing)
                            Else
                                Cursor = Cursors.Default
                                Tools.MostrarMensaje(Mensajes.Warning, "Ocurrió un error al ejecutar el algoritmo, intente nuevamente.")
                                Exit Sub
                            End If


                        End If
                    End If
                Else
                    mensajeSesion = tblsesion.Rows(0).Item("Mensaje")
                    Tools.MostrarMensaje(Mensajes.Warning, mensajeSesion)
                End If
            End If


        Else
            Tools.MostrarMensaje(Mensajes.Warning, "Consulte la nave de balanceo")
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Tools.Excel.ExportarExcel(dgVBalanceo, "Reporte Balanceo")
    End Sub

    Private Sub nudSemana_ValueChanged(sender As Object, e As EventArgs) Handles nudSemana.ValueChanged
        If (nudSemana.Value >= 54) Then
            nudSemana.Value = nudSemana.Minimum
        End If
    End Sub
End Class