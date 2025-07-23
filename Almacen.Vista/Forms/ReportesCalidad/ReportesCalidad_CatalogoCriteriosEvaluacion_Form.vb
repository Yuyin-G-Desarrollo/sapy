Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository

Public Class ReportesCalidad_CatalogoCriteriosEvaluacion_Form

    Public riNudValorInicial As New RepositoryItemSpinEdit
    Public riNudValorFinal As New RepositoryItemSpinEdit
    Public riPuntos As New RepositoryItemSpinEdit
    Public dtOriginal As New DataTable

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Public Sub CargarNaves()
        Dim lstNavesCombo As New List(Of Entidades.Naves)
        Dim lstNavesMostrar As New List(Of Integer)
        Dim dtDatosNaves As New DataTable
        Try
            dtDatosNaves = (New Negocios.ReporteEvaluacionCalidadNaveBU).ConsultaNaves()
            cmbNave.DataSource = Nothing
            cmbNave.DataSource = dtDatosNaves
            cmbNave.ValueMember = "IdNave"
            cmbNave.DisplayMember = "Nave"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FormatoGrid()
        bgvCriteriosEvaluacion.OptionsView.ColumnAutoWidth = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvCriteriosEvaluacion.Columns
            col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            If col.FieldName = "Criterio" Or col.FieldName = "Nave" Then
                col.OptionsColumn.AllowEdit = False
            Else
                col.OptionsColumn.AllowEdit = True
            End If
        Next

        bgvCriteriosEvaluacion.Columns.ColumnByFieldName("CriterioEvaluacionID").Visible = False
        bgvCriteriosEvaluacion.Columns.ColumnByFieldName("NaveID").Visible = False
        bgvCriteriosEvaluacion.Columns.ColumnByFieldName("UsuarioCreoID").Visible = False
        bgvCriteriosEvaluacion.Columns.ColumnByFieldName("FechaCreación").Visible = False

        bgvCriteriosEvaluacion.Columns.ColumnByFieldName("ValorInicial").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvCriteriosEvaluacion.Columns.ColumnByFieldName("ValorFinal").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvCriteriosEvaluacion.Columns.ColumnByFieldName("Puntos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        bgvCriteriosEvaluacion.Columns.ColumnByFieldName("ValorInicial").DisplayFormat.FormatString = "N0"
        bgvCriteriosEvaluacion.Columns.ColumnByFieldName("ValorFinal").DisplayFormat.FormatString = "N0"
        bgvCriteriosEvaluacion.Columns.ColumnByFieldName("Puntos").DisplayFormat.FormatString = "N0"

        'bgvDevolucionesClientes.Columns.ColumnByFieldName("St").Width = 20

        bgvCriteriosEvaluacion.IndicatorWidth = 40

        'bgvDocumentos.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        'bgvDevolucionesClientes.BestFitColumns()
        'bgvDevolucionesClientes.Columns.ColumnByFieldName("St").Width = 20
        'bgvDevolucionesClientes.Columns.ColumnByFieldName("Rs").Width = 20
    End Sub

    Public Sub PoblarGrid()
        Dim naveID As Integer
        Dim criterios As String = ""

        If Not IsNothing(cmbNave.SelectedValue) Then
            naveID = cmbNave.SelectedValue
            If chkDevolucion.Checked = True Then
                criterios += "DEVOLUCIONES"
            End If

            If chkAlertaMayor.Checked = True Then
                If criterios.Length > 0 Then
                    criterios += ","
                End If
                criterios += "ALERTAS_MAYORES"
            End If

            If chkAlertaMenor.Checked = True Then
                If criterios.Length > 0 Then
                    criterios += ","
                End If
                criterios += "ALERTAS_MENORES"
            End If

            dtOriginal = (New Negocios.ReporteEvaluacionCalidadNaveBU).ConsultaCriteriosEvaluacion(naveID, criterios)
            grdCriteriosEvaluacion.DataSource = dtOriginal
        End If
    End Sub

    Private Sub ReportesCalidad_CatalogoCriteriosEvaluacion_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarNaves()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        PoblarGrid()
        grdCriteriosEvaluacion.RepositoryItems.Add(riNudValorInicial)
        bgvCriteriosEvaluacion.Columns("ValorInicial").ColumnEdit = riNudValorInicial
        FormatoGrid()
        bgvCriteriosEvaluacion.BestFitColumns()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If Not IsNothing(cmbNave.SelectedValue) Then
            Dim formAltaCriterio As New ReportesCalidad_AltaRangoEvaluacion_Form
            formAltaCriterio.lblNave.Text = cmbNave.Text
            formAltaCriterio.IdNave = cmbNave.SelectedValue
            formAltaCriterio.StartPosition = FormStartPosition.CenterScreen
            formAltaCriterio.ShowDialog()
            PoblarGrid()
        Else
            Dim ventanaAdvertencia As New Tools.AdvertenciaForm
            ventanaAdvertencia.mensaje = "Seleccione una nave"
            ventanaAdvertencia.ShowDialog()
        End If
    End Sub

    Private Sub bgvCriteriosEvaluacion_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvCriteriosEvaluacion.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub bgvCriteriosEvaluacion_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles bgvCriteriosEvaluacion.CellValueChanged
        Try
            If e.Column.FieldName = "ValorInicial" Then
                Dim valor As Int16
                If e.RowHandle = 0 Then
                    valor = 0
                ElseIf bgvCriteriosEvaluacion.GetRowCellValue(e.RowHandle - 1, "Criterio").ToString = bgvCriteriosEvaluacion.GetRowCellValue(e.RowHandle, "Criterio").ToString Then
                    valor = bgvCriteriosEvaluacion.GetRowCellValue(e.RowHandle - 1, "ValorFinal") + 1
                Else
                    valor = 0
                End If

                If bgvCriteriosEvaluacion.GetRowCellValue(e.RowHandle, "ValorFinal").ToString < bgvCriteriosEvaluacion.GetRowCellValue(e.RowHandle, "ValorInicial").ToString Then
                    bgvCriteriosEvaluacion.SetRowCellValue(e.RowHandle, "ValorFinal", CInt(bgvCriteriosEvaluacion.GetRowCellValue(e.RowHandle, "ValorInicial").ToString))
                End If
                Try
                    Dim editor As RepositoryItemSpinEdit
                    editor = TryCast(sender, RepositoryItemSpinEdit)
                    If editor IsNot Nothing Then
                        editor.MinValue = valor
                        editor.MaxValue = 1000
                    End If

                    If e.RowHandle < (bgvCriteriosEvaluacion.RowCount - 1) Then
                        If bgvCriteriosEvaluacion.GetRowCellValue(e.RowHandle + 1, "Criterio").ToString = bgvCriteriosEvaluacion.GetRowCellValue(e.RowHandle, "Criterio").ToString Then
                            bgvCriteriosEvaluacion.SetRowCellValue(e.RowHandle + 1, "ValorInicial", (bgvCriteriosEvaluacion.GetRowCellValue(e.RowHandle, "ValorFinal") + 1))
                        End If
                    End If
                    'bgvCriteriosEvaluacion_CellValueChanged(sender, e)
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim NumeroFilas = bgvCriteriosEvaluacion.DataRowCount
        Dim seleccion As Boolean = False
        Dim CriterioID As String = ""
        For index As Integer = 0 To NumeroFilas Step 1
            If CBool(bgvCriteriosEvaluacion.GetRowCellValue(bgvCriteriosEvaluacion.GetVisibleRowHandle(index), " ")) = True Then
                seleccion = True
                If CriterioID.Length > 0 Then
                    CriterioID += ","
                End If
                CriterioID += bgvCriteriosEvaluacion.GetRowCellValue(bgvCriteriosEvaluacion.GetVisibleRowHandle(index), "CriterioEvaluacionID").ToString
            End If
        Next

        If seleccion = True Then
            Dim ventanaConfirmacion As New Tools.ConfirmarForm
            ventanaConfirmacion.mensaje = "Los registros seleccionados se eliminarán. ¿Desea continuar?"
            ventanaConfirmacion.ShowDialog()
            If ventanaConfirmacion.DialogResult <> DialogResult.OK Then Return
            Dim negocios As New Negocios.ReporteEvaluacionCalidadNaveBU
            negocios.EliminarCriterioEvaluacion(CriterioID)
            Dim ventanaExito As New Tools.ExitoForm
            ventanaExito.mensaje = "Criterios eliminados con éxito"
            ventanaExito.ShowDialog()
            PoblarGrid()
        Else
            Dim ventanaAdvertencias As New Tools.AdvertenciaForm
            ventanaAdvertencias.mensaje = "Debe seleccionar un registro"
            ventanaAdvertencias.ShowDialog()
        End If
    End Sub

    Private Sub bgvCriteriosEvaluacion_CustomRowCellEdit(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles bgvCriteriosEvaluacion.CustomRowCellEdit
        If e.Column.FieldName = "ValorInicial" Then
            Dim valor As Int16
            If e.RowHandle = 0 Then
                valor = 0
            Else
                valor = bgvCriteriosEvaluacion.GetRowCellValue(e.RowHandle - 1, "ValorInicial") + 1
            End If

            riNudValorInicial = New RepositoryItemSpinEdit
            riNudValorInicial.MinValue = valor
            riNudValorInicial.MaxValue = 1000
            e.RepositoryItem = riNudValorInicial
        ElseIf e.Column.FieldName = "ValorFinal" Then
            Dim valor As Int16
            Try
                If e.RowHandle = 0 Then
                    valor = 0
                ElseIf bgvCriteriosEvaluacion.GetRowCellValue(e.RowHandle - 1, "Criterio").ToString = bgvCriteriosEvaluacion.GetRowCellValue(e.RowHandle, "Criterio").ToString Then
                    valor = bgvCriteriosEvaluacion.GetRowCellValue(e.RowHandle - 1, "ValorFinal") + 1
                Else
                    valor = 0
                End If

                If CInt(bgvCriteriosEvaluacion.GetRowCellValue(e.RowHandle, "ValorFinal").ToString) < CInt(bgvCriteriosEvaluacion.GetRowCellValue(e.RowHandle, "ValorInicial").ToString) Then
                    bgvCriteriosEvaluacion.SetRowCellValue(e.RowHandle, "ValorFinal", CInt(bgvCriteriosEvaluacion.GetRowCellValue(e.RowHandle, "ValorInicial").ToString))
                End If
                riNudValorInicial = New RepositoryItemSpinEdit
                riNudValorInicial.MinValue = valor
                riNudValorInicial.MaxValue = 1000
                e.RepositoryItem = riNudValorInicial
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub bgvCriteriosEvaluacion_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles bgvCriteriosEvaluacion.CustomDrawCell
        If dtOriginal.Rows.Count > 0 Then
            Try
                If bgvCriteriosEvaluacion.GetRowCellValue(e.RowHandle, "ValorInicial").ToString <> dtOriginal.Rows(e.RowHandle).Item("ValorInicial").ToString Then
                    e.Appearance.ForeColor = Color.Purple
                End If
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim formConfirm As New Tools.ConfirmarForm
        formConfirm.mensaje = "¿Desea guardar los cambios?"
        formConfirm.ShowDialog()
        If formConfirm.DialogResult <> DialogResult.OK Then Return
        Try
            pgrsPnlCargando.ContentAlignment = ContentAlignment.MiddleCenter
            pgrsPnlCargando.Top = (Me.Height - pgrsPnlCargando.Height) / 2
            pgrsPnlCargando.Left = (Me.Width - pgrsPnlCargando.Width) / 2
            pgrsPnlCargando.Description = "Guardando cambios..."

            pgrsPnlCargando.Show()
            pgrsPnlCargando.Refresh()

            Dim obj As New Negocios.ReporteEvaluacionCalidadNaveBU
            Cursor = Cursors.WaitCursor
            Dim vXMLCriterios As XElement = New XElement("Criterios")

            Dim numFilas As Int64 = bgvCriteriosEvaluacion.DataRowCount

            For index As Int64 = 0 To numFilas - 1 Step 1
                Dim vNodo As XElement = New XElement("Criterio")
                vNodo.Add(New XAttribute("CriterioEvaluacionID", bgvCriteriosEvaluacion.GetRowCellValue(bgvCriteriosEvaluacion.GetVisibleRowHandle(index), "CriterioEvaluacionID")))
                vNodo.Add(New XAttribute("Criterio", bgvCriteriosEvaluacion.GetRowCellValue(bgvCriteriosEvaluacion.GetVisibleRowHandle(index), "Criterio")))
                vNodo.Add(New XAttribute("NaveID", bgvCriteriosEvaluacion.GetRowCellValue(bgvCriteriosEvaluacion.GetVisibleRowHandle(index), "NaveID")))
                vNodo.Add(New XAttribute("ValorInicial", bgvCriteriosEvaluacion.GetRowCellValue(bgvCriteriosEvaluacion.GetVisibleRowHandle(index), "ValorInicial")))
                vNodo.Add(New XAttribute("ValorFinal", bgvCriteriosEvaluacion.GetRowCellValue(bgvCriteriosEvaluacion.GetVisibleRowHandle(index), "ValorFinal")))
                vNodo.Add(New XAttribute("Puntos", bgvCriteriosEvaluacion.GetRowCellValue(bgvCriteriosEvaluacion.GetVisibleRowHandle(index), "Puntos")))
                vNodo.Add(New XAttribute("UsuarioCreoID", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                vXMLCriterios.Add(vNodo)
            Next

            obj.ModificarPuntajeCriterios(vXMLCriterios.ToString())
            Dim formExito As New Tools.ExitoForm
            formExito.mensaje = "Cambios guardados correctamente"
            formExito.ShowDialog()
            PoblarGrid()
            pgrsPnlCargando.Hide()
            Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            pgrsPnlCargando.Hide()
            Cursor = Cursors.Default
        End Try
    End Sub
End Class