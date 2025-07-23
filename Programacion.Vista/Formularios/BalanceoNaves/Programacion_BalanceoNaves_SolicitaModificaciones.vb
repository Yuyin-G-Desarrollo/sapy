Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports Programacion.Negocios
Imports Tools

Public Class Programacion_BalanceoNaves_SolicitaModificaciones
    Public Año As Integer
    Public Semana As Integer
    Public NaveID As Integer
    Dim editorMotivoSolicitudCambio As New RepositoryItemLookUpEdit()
    Dim advertencia As New AdvertenciaForm


    Private Sub Programacion_BalanceoNaves_SolicitaModificaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarBalanceoNaves(NaveID, Semana, Año)
        CargarRangoSemana()
    End Sub

    Private Sub CargarRangoSemana()
        Dim objBU As New BalanceoNavesBU
        Dim dtCargarRangoSemana As New DataTable

        dtCargarRangoSemana = objBU.CargarSemanaDato(NaveID, Semana, Año)

        If dtCargarRangoSemana.Rows.Count > 0 Then
            lblSemanaFecha.Text = dtCargarRangoSemana.Rows(0).Item("rangoFecha").ToString()
        End If

    End Sub

    Private Sub CargarBalanceoNaves(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer)
        Dim objBU As New BalanceoNavesBU
        Dim dtObtieneBalanceoNaves As New DataTable

        Try

            Cursor = Cursors.WaitCursor

            grdSolicitaCambios.DataSource = Nothing
            vwSolicitaCambios.Columns.Clear()

            dtObtieneBalanceoNaves = objBU.ObtieneBalanceoNavesReporte(NaveID, Semana, Año)

            If dtObtieneBalanceoNaves.Rows.Count > 0 Then
                grdSolicitaCambios.DataSource = dtObtieneBalanceoNaves

                dtObtieneBalanceoNaves.Columns(12).ColumnName = 1
                dtObtieneBalanceoNaves.Columns(13).ColumnName = 2
                dtObtieneBalanceoNaves.Columns(14).ColumnName = 3
                dtObtieneBalanceoNaves.Columns(15).ColumnName = 4
                dtObtieneBalanceoNaves.Columns(16).ColumnName = 5
                dtObtieneBalanceoNaves.Columns(17).ColumnName = 6

                lblRegistros.Text = CDbl(vwSolicitaCambios.RowCount.ToString()).ToString("n0")
                DisenioGrid()

            Else
                show_message("Advertencia", "No hay información para mostrar.")
                Me.Dispose()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DisenioGrid()
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand

        vwSolicitaCambios.Columns.Clear()
        vwSolicitaCambios.Bands.Clear()
        vwSolicitaCambios.Appearance.HeaderPanel.Options.UseBackColor = True
        vwSolicitaCambios.OptionsBehavior.Editable = True
        vwSolicitaCambios.OptionsView.ShowFooter = True
        DiseñoGrid.DiseñoBaseGrid(vwSolicitaCambios)
        DiseñoGrid.AlternarColorEnFilas(vwSolicitaCambios)


        band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band.Caption = ""
        vwSolicitaCambios.Columns.AddField("Colección")
        vwSolicitaCambios.Columns.ColumnByFieldName("Colección").OwnerBand = band
        vwSolicitaCambios.Columns.ColumnByFieldName("Colección").Visible = True
        vwSolicitaCambios.Columns.ColumnByFieldName("Colección").OptionsColumn.AllowEdit = False

        vwSolicitaCambios.Columns.AddField("Modelo")
        vwSolicitaCambios.Columns.ColumnByFieldName("Modelo").OwnerBand = band
        vwSolicitaCambios.Columns.ColumnByFieldName("Modelo").Visible = True
        vwSolicitaCambios.Columns.ColumnByFieldName("Modelo").OptionsColumn.AllowEdit = False

        vwSolicitaCambios.Columns.AddField("Piel y Color")
        vwSolicitaCambios.Columns.ColumnByFieldName("Piel y Color").OwnerBand = band
        vwSolicitaCambios.Columns.ColumnByFieldName("Piel y Color").Visible = True
        vwSolicitaCambios.Columns.ColumnByFieldName("Piel y Color").OptionsColumn.AllowEdit = False

        vwSolicitaCambios.Columns.AddField("Corrida")
        vwSolicitaCambios.Columns.ColumnByFieldName("Corrida").OwnerBand = band
        vwSolicitaCambios.Columns.ColumnByFieldName("Corrida").Visible = True
        vwSolicitaCambios.Columns.ColumnByFieldName("Corrida").OptionsColumn.AllowEdit = False

        vwSolicitaCambios.Bands.Add(band)

        band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band.Caption = "Semana " + Semana.ToString() + " " + Año.ToString()

        vwSolicitaCambios.Columns.AddField("1")
        vwSolicitaCambios.Columns.ColumnByFieldName("1").OwnerBand = band
        vwSolicitaCambios.Columns.ColumnByFieldName("1").Visible = True
        vwSolicitaCambios.Columns.ColumnByFieldName("1").OptionsColumn.AllowEdit = False
        vwSolicitaCambios.Columns.ColumnByFieldName("1").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        vwSolicitaCambios.Columns.ColumnByFieldName("1").Caption = "L"
        vwSolicitaCambios.Columns.ColumnByFieldName("1").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        vwSolicitaCambios.Columns.AddField("2")
        vwSolicitaCambios.Columns.ColumnByFieldName("2").OwnerBand = band
        vwSolicitaCambios.Columns.ColumnByFieldName("2").Visible = True
        vwSolicitaCambios.Columns.ColumnByFieldName("2").OptionsColumn.AllowEdit = False
        vwSolicitaCambios.Columns.ColumnByFieldName("2").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        vwSolicitaCambios.Columns.ColumnByFieldName("2").Caption = "M"
        vwSolicitaCambios.Columns.ColumnByFieldName("2").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        vwSolicitaCambios.Columns.AddField("3")
        vwSolicitaCambios.Columns.ColumnByFieldName("3").OwnerBand = band
        vwSolicitaCambios.Columns.ColumnByFieldName("3").Visible = True
        vwSolicitaCambios.Columns.ColumnByFieldName("3").OptionsColumn.AllowEdit = False
        vwSolicitaCambios.Columns.ColumnByFieldName("3").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        vwSolicitaCambios.Columns.ColumnByFieldName("3").Caption = "MM"
        vwSolicitaCambios.Columns.ColumnByFieldName("3").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        vwSolicitaCambios.Columns.AddField("4")
        vwSolicitaCambios.Columns.ColumnByFieldName("4").OwnerBand = band
        vwSolicitaCambios.Columns.ColumnByFieldName("4").Visible = True
        vwSolicitaCambios.Columns.ColumnByFieldName("4").OptionsColumn.AllowEdit = False
        vwSolicitaCambios.Columns.ColumnByFieldName("4").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        vwSolicitaCambios.Columns.ColumnByFieldName("4").Caption = "J"
        vwSolicitaCambios.Columns.ColumnByFieldName("4").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        vwSolicitaCambios.Columns.AddField("5")
        vwSolicitaCambios.Columns.ColumnByFieldName("5").OwnerBand = band
        vwSolicitaCambios.Columns.ColumnByFieldName("5").Visible = True
        vwSolicitaCambios.Columns.ColumnByFieldName("5").OptionsColumn.AllowEdit = False
        vwSolicitaCambios.Columns.ColumnByFieldName("5").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        vwSolicitaCambios.Columns.ColumnByFieldName("5").Caption = "V"
        vwSolicitaCambios.Columns.ColumnByFieldName("5").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        vwSolicitaCambios.Columns.AddField("6")
        vwSolicitaCambios.Columns.ColumnByFieldName("6").OwnerBand = band
        vwSolicitaCambios.Columns.ColumnByFieldName("6").Visible = True
        vwSolicitaCambios.Columns.ColumnByFieldName("6").OptionsColumn.AllowEdit = False
        vwSolicitaCambios.Columns.ColumnByFieldName("6").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        vwSolicitaCambios.Columns.ColumnByFieldName("6").Caption = "S"
        vwSolicitaCambios.Columns.ColumnByFieldName("6").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        vwSolicitaCambios.Bands.Add(band)

        band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band.Caption = ""

        vwSolicitaCambios.Columns.AddField("MotivoID")
        vwSolicitaCambios.Columns.ColumnByFieldName("MotivoID").OwnerBand = band
        vwSolicitaCambios.Columns.ColumnByFieldName("MotivoID").Visible = True
        vwSolicitaCambios.Columns.ColumnByFieldName("MotivoID").Caption = "Motivo Cambio"

        ObtieneMotivosID()

        Dim editor As New RepositoryItemTextEdit
        editor.CharacterCasing = CharacterCasing.Upper

        vwSolicitaCambios.Columns.AddField("Observaciones")
        vwSolicitaCambios.Columns.ColumnByFieldName("Observaciones").OwnerBand = band
        vwSolicitaCambios.Columns.ColumnByFieldName("Observaciones").Visible = True
        vwSolicitaCambios.Columns.ColumnByFieldName("Observaciones").Caption = "Observación"
        vwSolicitaCambios.Columns.ColumnByFieldName("Observaciones").OptionsColumn.AllowEdit = True
        vwSolicitaCambios.Columns.ColumnByFieldName("Observaciones").ColumnEdit = editor

        vwSolicitaCambios.Bands.Add(band)

        Dim blnSum As Boolean = False
        Dim strFormat As String = String.Empty

        For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In vwSolicitaCambios.Bands
            gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            For Each childrenBand In gridband.Children
                childrenBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Next
        Next

        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In vwSolicitaCambios.Columns
            blnSum = False
            strFormat = String.Empty

            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

            Select Case Col.FieldName
                Case "Colección"
                    Col.Width = 200
                Case "Modelo"
                    Col.Width = 60
                Case "Piel y Color"
                    Col.Width = 200
                Case "Corrida"
                    Col.Width = 60
                Case "Observaciones"
                    Col.Width = 200
                Case "MotivoID"
                    Col.Width = 196
                Case "1"
                    blnSum = True
                    strFormat = "{0:N0}"
                    Col.Width = 40
                Case "2"
                    blnSum = True
                    strFormat = "{0:N0}"
                    Col.Width = 40
                Case "3"
                    blnSum = True
                    strFormat = "{0:N0}"
                    Col.Width = 40
                Case "4"
                    blnSum = True
                    strFormat = "{0:N0}"
                    Col.Width = 40
                Case "5"
                    blnSum = True
                    strFormat = "{0:N0}"
                    Col.Width = 40
                Case "6"
                    blnSum = True
                    strFormat = "{0:N0}"
                    Col.Width = 40
            End Select

            If blnSum = True AndAlso IsNothing(vwSolicitaCambios.Columns(Col.FieldName).Summary.FirstOrDefault(Function(x) x.FieldName = Col.FieldName)) = True Then
                vwSolicitaCambios.Columns(Col.FieldName).Summary.Add(DevExpress.Data.SummaryItemType.Sum, Col.FieldName, strFormat) '"{0:N2}")
                Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                item.FieldName = Col.FieldName
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = strFormat ' "{0:N2}"
                vwSolicitaCambios.GroupSummary.Add(item)

            End If
            Col.DisplayFormat.FormatString = strFormat
        Next
        vwSolicitaCambios.IndicatorWidth = 40
    End Sub

    Private Sub ObtieneMotivosID()
        Dim objBU As New BalanceoNavesBU
        Dim dtResultado As New DataTable

        If IsNothing(vwSolicitaCambios.Columns("MotivoID").ColumnEdit) = True Then
            dtResultado = objBU.ObtieneMotivosSolicitudCambio()
            dtResultado.Rows.InsertAt(dtResultado.NewRow, 0)

            editorMotivoSolicitudCambio.DataSource = dtResultado
            editorMotivoSolicitudCambio.DisplayMember = "Motivo"
            editorMotivoSolicitudCambio.ValueMember = "IdMotivo"

            vwSolicitaCambios.Columns("MotivoID").ColumnEdit = Nothing
            editorMotivoSolicitudCambio.PopulateColumns()

            editorMotivoSolicitudCambio.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
            editorMotivoSolicitudCambio.Columns("IdMotivo").Visible = False
            editorMotivoSolicitudCambio.ShowHeader = False
            editorMotivoSolicitudCambio.BestFitMode = True

            vwSolicitaCambios.Columns("MotivoID").ColumnEdit = Nothing
            vwSolicitaCambios.Columns("MotivoID").ColumnEdit = editorMotivoSolicitudCambio
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

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New BalanceoNavesBU
        Dim dtInsertaSolitudCambios As New DataTable
        Dim UsuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim Confirmar As New ConfirmarForm

        Try
            Confirmar.mensaje = "¿Desea guardar las solicitudes de cambio?"
            If Confirmar.ShowDialog() = DialogResult.OK Then
                Cursor = Cursors.WaitCursor

                Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
                For i = 0 To vwSolicitaCambios.RowCount - 1
                    If vwSolicitaCambios.GetRowCellValue(i, "MotivoID").ToString <> "0" And vwSolicitaCambios.GetRowCellValue(i, "MotivoID").ToString <> "" Then
                        Dim vNodo As XElement = New XElement("Celda")
                        vNodo.Add(New XAttribute("NaveID", NaveID))
                        vNodo.Add(New XAttribute("Año", Año))
                        vNodo.Add(New XAttribute("Semana", Semana))
                        vNodo.Add(New XAttribute("ColeccionID", vwSolicitaCambios.GetRowCellValue(i, "ColeccionID")))
                        vNodo.Add(New XAttribute("ProductoEstiloID", vwSolicitaCambios.GetRowCellValue(i, "ProductoEstiloID")))
                        vNodo.Add(New XAttribute("MotivoCambioID", vwSolicitaCambios.GetRowCellValue(i, "MotivoID")))
                        vNodo.Add(New XAttribute("UsuarioSolicitaCambioNaveID", UsuarioID))
                        If vwSolicitaCambios.GetRowCellValue(i, "Observaciones").ToString = "" Then
                            show_message("Advertencia", "Ingrese una observación para la solicitud de cambio.")
                            Exit Sub
                        Else
                            vNodo.Add(New XAttribute("Observaciones", vwSolicitaCambios.GetRowCellValue(i, "Observaciones")))
                        End If

                        vXmlCeldasModificadas.Add(vNodo)
                    End If

                    If vwSolicitaCambios.GetRowCellValue(i, "Observaciones").ToString <> "" And vwSolicitaCambios.GetRowCellValue(i, "MotivoID").ToString = "0" And vwSolicitaCambios.GetRowCellValue(i, "MotivoID").ToString <> "" Then
                        show_message("Advertencia", "Ingrese un motivo de solicitud para la observación.")
                        Exit Sub
                    End If
                Next

                If vXmlCeldasModificadas.IsEmpty = False Then
                    dtInsertaSolitudCambios = objBU.InsertaSolicitudCambios_BalanceoNaves(vXmlCeldasModificadas.ToString())
                    'EnviarCorreoAvisoModificaciones()
                    show_message("Exito", "Datos guardados correctamente.")
                    Me.Dispose()
                Else
                    show_message("Advertencia", "Seleccione motivo de cambio y observación.")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub vwSolicitaCambios_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwSolicitaCambios.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
End Class