Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools

Public Class AgregarModelosForm
    Dim objInstancia As New Negocios.SpeedTrackBU
    Dim FilasSeleccionadas As Integer = 0
    Dim emptyEditor As RepositoryItem
    Private Sub AgregarModelosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        llenarcomboLPB()

        consultarDatos(ComboBox1.SelectedValue)
    End Sub

    Private Sub llenarcomboLPB()
        Dim listaPrecio = objInstancia.ConsultarListasDePrecios()

        ComboBox1.DataSource = listaPrecio
        ComboBox1.ValueMember = "lpba_listapreciosbaseid"
        ComboBox1.DisplayMember = "LISTABASE"
    End Sub



    Private Sub consultarDatos(ByVal lista As Integer)

        Cursor = Cursors.WaitCursor
        Dim dataTable = objInstancia.ConsultarModelosADDSpeedTrack(lista)
        If dataTable.Rows.Count = 0 Then
            grdModelos.DataSource = Nothing
            vwModelos.Columns.Clear()
            show_message("Aviso", "No hay modelos en la lista o ya agregaste todos")
            Cursor = Cursors.Default
            lblFechaUltimaActualizacion.Text = Date.Now
            Return
        End If
        grdModelos.DataSource = Nothing
        vwModelos.Columns.Clear()
        grdModelos.DataSource = dataTable
        DiseñoGrid.DiseñoBaseGrid(vwModelos)
        vwModelos.OptionsView.ColumnAutoWidth = True
        vwModelos.IndicatorWidth = 35
        DiseñoGrid.EstiloColumna(vwModelos, "Seleccion", "SELECCIÓN", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 50, False, Nothing, "")
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwModelos.Columns
            If (col.FieldName <> "MODELO SAY" And col.FieldName <> "Seleccion" And col.FieldName <> "MODELOS SICY" And col.FieldName <> "PIEL" And col.FieldName <> "FAMILIA" And col.FieldName <> "COLOR" And col.FieldName <> "COLECCIÓN" And col.FieldName <> "ESTATUS") Then
                vwModelos.Columns.ColumnByFieldName(col.FieldName).Visible = False
            End If
        Next

        Dim agregados As Integer = 0
        Dim NoAgregados As Integer = 0
        For index = 0 To dataTable.Rows.Count - 1
            If dataTable.Rows(index).Item("ESTATUS").ToString = "AGREGADO" Then
                agregados = agregados + 1
            Else
                NoAgregados = NoAgregados + 1
            End If
        Next
        Label4.Text = String.Format("{0:N0}", agregados)
        Label6.Text = String.Format("{0:N0}", NoAgregados)
        lblTotalParesProceso.Text = String.Format("{0:N0}", dataTable.Rows.Count)
        lblFechaUltimaActualizacion.Text = Date.Now
        Cursor = Cursors.Default
    End Sub
    Private Sub viewInventario_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwModelos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Function obtenerModelosSeleccionados() As String
        Dim documentosSeleccionados As String = String.Empty
        Dim NumeroFilas As Integer
        FilasSeleccionadas = 0

        Cursor = Cursors.WaitCursor

        Try

            NumeroFilas = vwModelos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1

                If CBool(vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(index), "Seleccion")) = True And vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(index), "ESTATUS") <> "AGREGADO" Then
                    FilasSeleccionadas += 1

                    If documentosSeleccionados = String.Empty Then
                        documentosSeleccionados = vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(index), "ProductoID").ToString & "-A" & "," &
                        vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(index), "ColorID").ToString() & "-B" & "," &
                        vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(index), "PielID").ToString() & "-C" & "/"
                    Else
                        documentosSeleccionados = documentosSeleccionados & vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(index), "ProductoID").ToString & "-A" & "," &
                        vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(index), "ColorID").ToString() & "-B" & "," &
                        vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(index), "PielID").ToString() & "-C" & "/"
                    End If
                End If
            Next
        Catch ex As Exception

            show_message("Error", ex.Message.ToString())

        End Try

        Cursor = Cursors.Default

        Return documentosSeleccionados

    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Dim modelos = obtenerModelosSeleccionados()
            If modelos = "" Then
                show_message("Advertencia", "Selecciona por lo menos un modelo")
            Else
                objInstancia.AgregarModelosSpeedTrack(modelos, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                show_message("Exito", "Los artículos seleccionados se agregaron al speedTrack correctamente")
                Me.Close()
            End If
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        consultarDatos(ComboBox1.SelectedValue)
        CheckBox1.Checked = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = vwModelos.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                vwModelos.SetRowCellValue(vwModelos.GetVisibleRowHandle(index), "Seleccion", CheckBox1.Checked)

                If CBool(CheckBox1.Checked) = False Then
                    vwModelos.SetRowCellValue(vwModelos.GetVisibleRowHandle(index), "%", 0)
                End If

            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub viewModelos_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles vwModelos.CustomDrawCell


        Dim estatus As String = vwModelos.GetRowCellValue(e.RowHandle, "ESTATUS")


        If e.Column.FieldName = "ESTATUS" Then
            If estatus = "AGREGADO" Then
                e.Appearance.BackColor = Color.FromArgb(216, 228, 188)
                e.Appearance.ForeColor = Color.Green
            End If
        End If
    End Sub
    Private Sub grdVpedidosMuestras_CustomRowCellEdit(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles vwModelos.CustomRowCellEdit

        If e.Column.FieldName = "Seleccion" And (vwModelos.GetRowCellValue(e.RowHandle, "ESTATUS") = "AGREGADO") Then
            emptyEditor = New RepositoryItem
            e.RepositoryItem = emptyEditor
        End If

    End Sub
End Class