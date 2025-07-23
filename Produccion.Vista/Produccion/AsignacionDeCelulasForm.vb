Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid
Imports DevExpress.Export
Imports Produccion.Negocios
Imports Tools
Imports Entidades
Imports DevExpress.XtraEditors.Repository

Public Class AsignacionDeCelulasForm
    Dim totalLotesPares As New DataTable
    Dim departamentos As New DataTable
    Dim NaveId As Integer
    Dim FechaP As Date
    Dim totalPares As Integer = 0
    Dim totalLotes As Integer = 0

    Private Sub AsignacionDeCelulasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        cboNave = Controles.ComboNavesSegunUsuario(cboNave, SesionUsuario.UsuarioSesion.PUserUsuarioid)
        dtpFecha.Value = Date.Now
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Public Sub obtenerDatos()
        Dim objBU As New AsignacionDeCelulasBU

        Cursor = Cursors.WaitCursor
        Limpiar()

        NaveId = cboNave.SelectedValue
        FechaP = dtpFecha.Value

        Try
            If cboNave.SelectedValue > 0 Then
                totalLotesPares = objBU.totalLotesPares(NaveId, FechaP)
                If totalLotesPares.Rows.Count > 0 Then
                    'grdAsignacionCelulas.DataSource = totalLotesPares
                    llenarGrid()
                    diseñoGrid()
                    calcularTotales()
                    calculaAvance()
                    calculaCelulas()

                Else
                    show_message("Aviso", "No existen registros en fecha seleccionada.")
                End If

            Else
                show_message("Advertencia", "Seleccione la nave.")
            End If
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try

        Cursor = Cursors.Default

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

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New Tools.ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        obtenerDatos()
    End Sub

    Public Sub diseñoGrid()

        Try
            Dim datos As DataTable
            datos = grdAsignacionCelulas.DataSource

            grdVAsignacionCelulas.BestFitColumns()
            grdVAsignacionCelulas.IndicatorWidth = 40

            'Obtiene Datos para campo Pespunte
            Dim dtP As DataTable
            Dim ObjCelulasBUP As New AsignacionDeCelulasBU
            dtP = ObjCelulasBUP.Celulas(cboNave.SelectedValue, "P")
            Dim emptyEditorP As New RepositoryItemLookUpEdit
            emptyEditorP.DataSource = dtP
            emptyEditorP.DisplayMember = "Celula"
            emptyEditorP.ValueMember = "IdCelula"
            emptyEditorP.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
            emptyEditorP.DropDownRows = dtP.Rows.Count
            emptyEditorP.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
            emptyEditorP.AutoSearchColumnIndex = 1
            emptyEditorP.PopulateColumns()
            emptyEditorP.Columns("Departamento").Visible = False
            emptyEditorP.Columns("Color").Visible = False
            emptyEditorP.Columns("IdCelula").Visible = False
            emptyEditorP.ShowHeader = False

            grdVAsignacionCelulas.Columns("Pespunte").ColumnEdit = emptyEditorP


            'Obtiene Datos para campo Montado y Adorno
            Dim dt As DataTable
            Dim ObjCelulasBU As New AsignacionDeCelulasBU
            dt = ObjCelulasBU.Celulas(cboNave.SelectedValue, "")
            Dim emptyEditor As New RepositoryItemLookUpEdit
            emptyEditor.DataSource = dt
            emptyEditor.DisplayMember = "Celula"
            emptyEditor.ValueMember = "IdCelula"
            emptyEditor.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
            emptyEditor.DropDownRows = dt.Rows.Count
            emptyEditor.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
            emptyEditor.AutoSearchColumnIndex = 1
            emptyEditor.PopulateColumns()
            emptyEditor.Columns("Departamento").Visible = False
            emptyEditor.Columns("Color").Visible = False
            emptyEditor.Columns("IdCelula").Visible = False
            emptyEditor.ShowHeader = False
            grdVAsignacionCelulas.Columns("Montado y Adorno").ColumnEdit = emptyEditor

            grdVAsignacionCelulas.Columns("Seleccion").Visible = False
            grdVAsignacionCelulas.Columns("Año").Visible = False
            grdVAsignacionCelulas.Columns("Nave").Visible = False
            grdVAsignacionCelulas.Columns("Año").Visible = False
            grdVAsignacionCelulas.Columns("IdLoteAvancePespunte").Visible = False
            grdVAsignacionCelulas.Columns("IdLoteAvanceMontadoyAdorno").Visible = False
            grdVAsignacionCelulas.Columns("idConfigPes").Visible = False
            grdVAsignacionCelulas.Columns("idConfigMonAdo").Visible = False
            grdVAsignacionCelulas.Columns("EstadoCorte").Visible = False
            grdVAsignacionCelulas.Columns("EstadoPespunte").Visible = False
            grdVAsignacionCelulas.Columns("EstadoMontadoYAdorno").Visible = False
            grdVAsignacionCelulas.Columns("ColorCorte").Visible = False
            grdVAsignacionCelulas.Columns("ColorPespunte").Visible = False
            grdVAsignacionCelulas.Columns("ColorMontado").Visible = False

            grdVAsignacionCelulas.Columns("Lote").OptionsColumn.AllowEdit = False
            grdVAsignacionCelulas.Columns("Modelo").OptionsColumn.AllowEdit = False
            grdVAsignacionCelulas.Columns("Coleccion").OptionsColumn.AllowEdit = False
            grdVAsignacionCelulas.Columns("Talla").OptionsColumn.AllowEdit = False
            grdVAsignacionCelulas.Columns("Color").OptionsColumn.AllowEdit = False
            grdVAsignacionCelulas.Columns("Pares").OptionsColumn.AllowEdit = False
            grdVAsignacionCelulas.Columns("Corte").OptionsColumn.AllowEdit = False
            grdVAsignacionCelulas.Columns("Embarque").OptionsColumn.AllowEdit = False

            grdVAsignacionCelulas.Columns("Lote").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            grdVAsignacionCelulas.Columns("Modelo").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            grdVAsignacionCelulas.Columns("Coleccion").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            grdVAsignacionCelulas.Columns("Talla").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            grdVAsignacionCelulas.Columns("Color").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            grdVAsignacionCelulas.Columns("Pares").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            grdVAsignacionCelulas.Columns("Corte").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            grdVAsignacionCelulas.Columns("Pespunte").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            grdVAsignacionCelulas.Columns("Montado y Adorno").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            grdVAsignacionCelulas.Columns("Embarque").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center

            grdVAsignacionCelulas.Columns("Lote").Caption = "LOTE"
            grdVAsignacionCelulas.Columns("Modelo").Caption = "MODELO"
            grdVAsignacionCelulas.Columns("Coleccion").Caption = "COLECCIÓN"
            grdVAsignacionCelulas.Columns("Talla").Caption = "TALLA"
            grdVAsignacionCelulas.Columns("Color").Caption = "COLOR"
            grdVAsignacionCelulas.Columns("Pares").Caption = "PARES"
            grdVAsignacionCelulas.Columns("Corte").Caption = "CORTE"
            grdVAsignacionCelulas.Columns("Pespunte").Caption = "PESPUNTE"
            grdVAsignacionCelulas.Columns("Montado y Adorno").Caption = "MONTADO Y ADORNO"
            grdVAsignacionCelulas.Columns("Embarque").Caption = "EMBARQUE"

            grdVAsignacionCelulas.OptionsView.EnableAppearanceEvenRow = True
            grdVAsignacionCelulas.OptionsView.EnableAppearanceOddRow = True
            grdVAsignacionCelulas.OptionsSelection.EnableAppearanceFocusedCell = True
            grdVAsignacionCelulas.OptionsSelection.EnableAppearanceFocusedRow = True
            grdVAsignacionCelulas.Appearance.SelectedRow.Options.UseBackColor = True

            grdVAsignacionCelulas.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

            grdVAsignacionCelulas.Appearance.EvenRow.BackColor = Color.White
            grdVAsignacionCelulas.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

            grdVAsignacionCelulas.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
            grdVAsignacionCelulas.Appearance.FocusedRow.ForeColor = Color.White
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
        

    End Sub

    Private Sub grdAsignacionCelulas_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVAsignacionCelulas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Public Sub calcularTotales()
        totalLotes = totalLotesPares.AsEnumerable.Count(Function(x) x.Item("Pares"))
        totalPares = totalLotesPares.AsEnumerable.Sum(Function(x) x.Item("Pares"))

        lblLotes.Text = CInt(totalLotes).ToString("N0")
        lblPares.Text = CInt(totalPares).ToString("N0")

    End Sub

    Public Sub calculaAvance()
        Dim obj As New AsignacionDeCelulasBU
        Dim pares As New DataTable

        Try
            departamentos = obj.departamentosNave(NaveId)
            If departamentos.Rows.Count > 0 Then
                pares = obj.paresPorDepto(NaveId, FechaP, departamentos.Rows(0).Item("IdDepto").ToString, "C")
                lblAvaCorte.Text = CInt(pares.Rows(0).Item("Pares")).ToString("N0")
                lblPenCorte.Text = CInt(totalPares - CInt(lblAvaCorte.Text)).ToString("N0")

                pares = obj.paresPorDepto(NaveId, FechaP, departamentos.Rows(1).Item("IdDepto").ToString, "C")
                lblAvaPespunte.Text = CInt(pares.Rows(0).Item("Pares")).ToString("N0")
                lblPenPespunte.Text = CInt(totalPares - CInt(lblAvaPespunte.Text)).ToString("N0")

                pares = obj.paresPorDepto(NaveId, FechaP, departamentos.Rows(2).Item("IdDepto").ToString, "C")
                lblAvaMontado.Text = CInt(pares.Rows(0).Item("Pares")).ToString("N0")
                lblPenMontado.Text = CInt(totalPares - CInt(lblAvaMontado.Text)).ToString("N0")

                pares = obj.paresPorDepto(NaveId, FechaP, 0, "C")
                lblAvaEmbarque.Text = CInt(pares.Rows(0).Item("Pares")).ToString("N0")

                pares = obj.paresPorDepto(NaveId, FechaP, 0, "P")
                lblPenEmbarque.Text = CInt(pares.Rows(0).Item("Pares")).ToString("N0")

            End If
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Public Sub llenarGrid()
        Dim datos As DataTable
        Dim obj As New AsignacionDeCelulasBU
        Dim bandas As New DataTable
        Dim configuracion As New DataTable
        Dim idCorte As Integer = 0
        Dim idPesunte As Integer = 0
        Dim idMontadoYAdorno As Integer = 0
        Dim ban As Integer = 0
        Dim fechasEmbarques As New DataTable

        datos = obj.totalLotesPares(NaveId, FechaP)
        configuracion = obj.configuracionXNave(NaveId, FechaP)

        Try

            departamentos = obj.departamentosNave(NaveId)

            For Each row As DataRow In departamentos.Rows
                ban += 1
                If ban = 1 Then
                    idCorte = departamentos.Rows(0).Item("IdDepto").ToString
                ElseIf ban = 2 Then
                    idPesunte = departamentos.Rows(1).Item("IdDepto").ToString
                    For Each r As DataRow In datos.Rows
                        r("idConfigPes") = idPesunte
                    Next
                ElseIf ban = 3 Then
                    idMontadoYAdorno = departamentos.Rows(2).Item("IdDepto").ToString
                    For Each r As DataRow In datos.Rows
                        r("idConfigMonAdo") = idMontadoYAdorno
                    Next
                End If
            Next

            For Each lotes As DataRow In datos.Rows
                For Each config As DataRow In configuracion.Rows
                    If lotes("Lote") = config("Lote") Then
                        If idCorte = config("IdConfiguracion") Then
                            lotes("EstadoCorte") = config("Estado")
                        End If
                        If idPesunte = config("IdConfiguracion") Then
                            lotes("Pespunte") = config("IdCelula")
                            lotes("IdLoteAvancePespunte") = config("IdLoteAvance")
                            lotes("idConfigPes") = config("IdConfiguracion")
                            lotes("EstadoPespunte") = config("Estado")
                        End If
                        If idMontadoYAdorno = config("IdConfiguracion") Then
                            lotes("Montado y Adorno") = config("IdCelula")
                            lotes("IdLoteAvanceMontadoyAdorno") = config("IdLoteAvance")
                            lotes("idConfigMonAdo") = config("IdConfiguracion")
                            lotes("EstadoMontadoYAdorno") = config("Estado")
                        End If
                    End If
                Next
            Next

            fechasEmbarques = obj.fechasEmbarque(NaveId, FechaP)
            For Each lotes As DataRow In datos.Rows
                For Each fechas As DataRow In fechasEmbarques.Rows
                    If fechas("Lote") = lotes("Lote") Then
                        lotes("Embarque") = fechas("fecha_salida").ToString()
                    End If
                Next
            Next

            grdAsignacionCelulas.DataSource = Nothing
            grdAsignacionCelulas.DataSource = datos


        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try

    End Sub


    
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim filename As String

        'Ask the user where to save the file to
        Dim SaveFileDialog As New SaveFileDialog()
        SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
        SaveFileDialog.FilterIndex = 2
        SaveFileDialog.RestoreDirectory = True
        If SaveFileDialog.ShowDialog() = DialogResult.OK Then

            'This is required so that excel doesn't make all the grids very small. This will export all grids space out evenly
            grdVAsignacionCelulas.OptionsPrint.AutoWidth = True
            grdVAsignacionCelulas.OptionsPrint.EnableAppearanceEvenRow = True
            grdVAsignacionCelulas.OptionsPrint.PrintPreview = True
            'Set the selected file as the filename
            filename = SaveFileDialog.FileName

            Dim exportOptions = New XlsxExportOptionsEx()
            'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

            'Export the file via inbuild function
            DevExpress.Export.ExportSettings.DefaultExportType = ExportType.Default
            grdVAsignacionCelulas.ExportToXlsx(filename, exportOptions)

            'If the file exists (i.e. export worked), then open it
            If System.IO.File.Exists(filename) Then
                Dim DialogResult As DialogResult = MessageBox.Show("El archivo ha sido exportado a " & filename & vbNewLine & "¿Quieres abrirlo ahora?", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If DialogResult = Windows.Forms.DialogResult.Yes Then
                    System.Diagnostics.Process.Start(filename)
                End If
            End If
        End If
    End Sub

    Public Sub calculaCelulas()
        Dim celulasbandas As New DataTable
        Dim obj As New AsignacionDeCelulasBU
        Dim cel1 As Integer = 0
        Dim cel2 As Integer = 0
        Dim cel3 As Integer = 0
        Dim cel4 As Integer = 0
        Dim ban1 As Integer = 0
        Dim ban2 As Integer = 0


        departamentos = obj.departamentosNave(NaveId)
        If departamentos.Rows.Count > 0 Then
            Try
                celulasbandas = obj.paresPorCelula(NaveId, FechaP, departamentos.Rows(1).Item("IdDepto").ToString)
                If celulasbandas.Rows(0).Item("Celula").ToString.Contains("1") = True Then
                    lblCel1.Text = CInt(celulasbandas.Rows(0).Item("Pares")).ToString("N0")
                End If
                If celulasbandas.Rows(1).Item("Celula").ToString.Contains("2") = True Then
                    lblCel2.Text = CInt(celulasbandas.Rows(1).Item("Pares")).ToString("N0")
                End If
                If celulasbandas.Rows(2).Item("Celula").ToString.Contains("3") = True Then
                    lblCel3.Text = CInt(celulasbandas.Rows(2).Item("Pares")).ToString("N0")
                End If
                If celulasbandas.Rows(3).Item("Celula").ToString.Contains("4") = True Then
                    lblCel4.Text = CInt(celulasbandas.Rows(3).Item("Pares")).ToString("N0")
                End If
            Catch ex As Exception
            End Try
            
            Try
                celulasbandas = obj.paresPorCelula(NaveId, FechaP, departamentos.Rows(2).Item("IdDepto").ToString)
                If celulasbandas.Rows(0).Item("Celula").ToString.Contains("1") = True Then
                    lblBan1.Text = CInt(celulasbandas.Rows(0).Item("Pares")).ToString("N0")
                End If
                If celulasbandas.Rows(1).Item("Celula").ToString.Contains("2") = True Then
                    lblBan2.Text = CInt(celulasbandas.Rows(1).Item("Pares")).ToString("N0")
                End If
            Catch ex As Exception
            End Try
            
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim grid As New DataTable
        Dim obj As New AsignacionDeCelulasBU
        Cursor = Cursors.WaitCursor
        Try
            grid = grdAsignacionCelulas.DataSource
            For Each fila As DataRow In grid.Rows
                If fila("IdLoteAvancePespunte") = 0 Then
                    If fila("Pespunte").ToString.Length > 0 Then
                        obj.InsertaAvanceCelula(fila("Año"), fila("Nave"), fila("Lote"), fila("idConfigPes"), fila("Pespunte"), fila("Pares"), "P")
                    End If
                ElseIf fila("Pespunte").ToString.Length > 0 Then
                    obj.ActualizaAvanceCelula(fila("Pespunte"), fila("IdLoteAvancePespunte"))
                End If

                If fila("IdLoteAvanceMontadoYAdorno") = 0 Then
                    If fila("Montado y Adorno").ToString.Length > 0 Then
                        obj.InsertaAvanceCelula(fila("Año"), fila("Nave"), fila("Lote"), fila("idConfigMonAdo"), fila("Montado y Adorno"), fila("Pares"), "P")
                    End If
                Else
                    If fila("Montado y Adorno").ToString.Length > 0 Then
                        obj.ActualizaAvanceCelula(fila("Montado y Adorno"), fila("IdLoteAvanceMontadoYAdorno"))
                    End If
                End If
            Next
            obtenerDatos()
            show_message("Exito", "Se han guardado los cambio correctamente")
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
        Cursor = Cursors.Default

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        Limpiar()

    End Sub

    Public Sub Limpiar()
        lblCel1.Text = 0
        lblCel2.Text = 0
        lblCel3.Text = 0
        lblCel4.Text = 0
        lblBan1.Text = 0
        lblBan2.Text = 0

        lblAvaCorte.Text = 0
        lblAvaPespunte.Text = 0
        lblAvaMontado.Text = 0
        lblAvaEmbarque.Text = 0
        lblPenCorte.Text = 0
        lblPenPespunte.Text = 0
        lblPenMontado.Text = 0
        lblPenEmbarque.Text = 0
        
        lblLotes.Text = 0
        lblPares.Text = 0

        grdAsignacionCelulas.DataSource = Nothing
        grdVAsignacionCelulas.Columns.Clear()
    End Sub
End Class