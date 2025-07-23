Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Tools

Public Class Produccion_ArticulosEstatusNoAutorizadoProduccion_Form
    Dim navesId As String

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New Negocios.ReportesBU
        Dim dtResultado As New DataTable
        Dim naveIdSICY As Integer = 0
        Dim fechaInicio As String = String.Empty
        Dim fechaFin As String = String.Empty
        Dim objMensaje As New AdvertenciaForm

        Cursor = Cursors.WaitCursor
        ' CarlosMtz -- Se crea nueva validacion por grupo -- 04-11-2020 (L19-L50)
        fechaInicio = dtpFechaInicio.Value.ToShortDateString()
        fechaFin = dtpFechaFin.Value.ToShortDateString()

        grdArticulosNoAutorizados.DataSource = Nothing
        VArticulosNoAutorizados.Columns.Clear()

        navesId = String.Empty
        If cmbNave.Enabled = True Then
            naveIdSICY = cmbNave.SelectedValue
            If naveIdSICY > 0 Then
                dtResultado = objBU.ObtieneArticulosNoAutorizadosProduccion(naveIdSICY, fechaInicio, fechaFin, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)
                If dtResultado.Rows.Count() > 0 Then
                    grdArticulosNoAutorizados.DataSource = dtResultado
                    diseñoGrid()
                Else
                    objMensaje.mensaje = "No hay datos para mostrar."
                    objMensaje.ShowDialog()
                End If
            Else
                objMensaje.mensaje = "Seleccione una Nave o Grupo."
                objMensaje.ShowDialog()
            End If
        ElseIf cboGrupo.Text <> String.Empty Then
            dtResultado = objBU.ObtieneArticulosNoAutorizadosProduccionGrupo(0, fechaInicio, fechaFin, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, cboGrupo.Text)
            If dtResultado.Rows.Count() > 0 Then
                grdArticulosNoAutorizados.DataSource = dtResultado
                diseñoGrid()
            Else
                objMensaje.mensaje = "No hay datos para mostrar."
                objMensaje.ShowDialog()
            End If
        End If

        'For Each item As Infragistics.Win.ValueListItem In cboNave2.Items
        '    If item.CheckState = CheckState.Checked Then
        '        If navesId = String.Empty Then
        '            navesId = CStr(item.DataValue)
        '        Else
        '            navesId = CStr(item.DataValue) + "," + navesId
        '        End If
        '    End If
        'Next
        'If navesId.Length < 1 Then
        '    objMensaje.mensaje = "Seleccione al menos una nave del Grupo " & cboGrupo.Text
        '    objMensaje.ShowDialog()
        'End If


        'fechaInicio = dtpFechaInicio.Value.ToShortDateString()
        'fechaFin = dtpFechaFin.Value.ToShortDateString()

        'grdArticulosNoAutorizados.DataSource = Nothing
        'VArticulosNoAutorizados.Columns.Clear()
        'naveIdSICY = cmbNave.SelectedValue
        'If naveIdSICY > 0 Then

        '    dtResultado = objBU.ObtieneArticulosNoAutorizadosProduccion(naveIdSICY, fechaInicio, fechaFin, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)

        '    If dtResultado.Rows.Count() > 0 Then
        '        grdArticulosNoAutorizados.DataSource = dtResultado
        '        diseñoGrid()
        '    Else
        '        objMensaje.mensaje = "No hay datos para mostrar."
        '        objMensaje.ShowDialog()

        '    End If
        'Else

        '    objMensaje.mensaje = "Debe seleccionar una Nave."
        '    objMensaje.ShowDialog()

        'End If


        Cursor = Cursors.Default

    End Sub

    Public Sub diseñoGrid()

        VArticulosNoAutorizados.OptionsView.ColumnAutoWidth = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In VArticulosNoAutorizados.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
            col.Width = 60
        Next

        If cboGrupo.Text <> String.Empty Then
            VArticulosNoAutorizados.Columns.ColumnByFieldName("Grupo").Visible = False
        End If

        VArticulosNoAutorizados.Columns.ColumnByFieldName("Nave").Width = 100
        VArticulosNoAutorizados.Columns.ColumnByFieldName("Modelo SAY").Width = 100
        VArticulosNoAutorizados.Columns.ColumnByFieldName("Modelo SICY").Width = 100
        VArticulosNoAutorizados.Columns.ColumnByFieldName("Código SICY").Width = 200
        VArticulosNoAutorizados.Columns.ColumnByFieldName("Colección").Width = 250
        VArticulosNoAutorizados.Columns.ColumnByFieldName("Corrida").Width = 50
        VArticulosNoAutorizados.Columns.ColumnByFieldName("Piel / Color").Width = 250

        VArticulosNoAutorizados.OptionsView.ShowAutoFilterRow = True
        VArticulosNoAutorizados.IndicatorWidth = 35

        VArticulosNoAutorizados.OptionsView.ShowFooter = GroupFooterShowMode.Hidden

    End Sub

    Private Sub Produccion_ArticulosEstatusNoAutorizadoProduccion_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaInicio.Value = Now.Date.ToShortDateString
        dtpFechaFin.Value = Now.Date.AddDays(7).ToShortDateString
        cmbNave = Tools.Controles.ComboNavesSegunUsuarioConIdSIcy(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        cargarGrupo()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        grdArticulosNoAutorizados.DataSource = Nothing
        VArticulosNoAutorizados.Columns.Clear()
        dtpFechaInicio.Value = Now.Date.ToShortDateString
        dtpFechaFin.Value = Now.Date.ToShortDateString
        cmbNave.SelectedIndex = 0

    End Sub

    Private Sub MVTarjeta_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles VArticulosNoAutorizados.RowStyle
        Dim View As GridView = sender
        If e.RowHandle >= 0 Then
            If (e.RowHandle Mod 2 > 0) Then
                e.Appearance.BackColor = Color.LightSteelBlue
            End If
        End If

    End Sub

    Private Sub MVTarjeta_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles VArticulosNoAutorizados.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If VArticulosNoAutorizados.DataRowCount > 0 Then
                nombreReporte = If(cmbNave.SelectedText <> "", cmbNave.SelectedText + "_", "") + "ArticulosNoAutorizadosProduccion_"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If VArticulosNoAutorizados.GroupCount > 0 Then
                            VArticulosNoAutorizados.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            VArticulosNoAutorizados.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo")
        End Try
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        If (e.RowHandle Mod 2 > 0) Then
            e.Formatting.BackColor = Color.LightSteelBlue
        End If

        e.Handled = True

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 94
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaFin.Value < dtpFechaInicio.Value Then
            dtpFechaFin.Value = dtpFechaInicio.Value
        End If
        dtpFechaFin.MinDate = dtpFechaInicio.Value
    End Sub

    Public Sub cargarGrupo()
        Dim obj = New Negocios.ReportesBU
        Dim tablaGrupos As New DataTable

        tablaGrupos = obj.cargarGrupoXNave()
        tablaGrupos.Rows.InsertAt(tablaGrupos.NewRow, 0)
        cboGrupo.DataSource = tablaGrupos
        cboGrupo.DisplayMember = "grupo"
        cboGrupo.ValueMember = "grupo"
    End Sub

    Private Sub cboGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGrupo.SelectedIndexChanged

        If cboGrupo.Text = String.Empty Or cboGrupo.Text = "" Then
            cmbNave.Visible = True
            cmbNave.Enabled = True
            cboNave2.Visible = False
            cboNave2.Enabled = False
        Else
            cboNave2.Visible = True
            cboNave2.Enabled = True
            cmbNave.Visible = False
            cmbNave.Enabled = False
            cmbNave.Text = ""
            cboNave2.Enabled = False
            cargarNavesXGrupo(cboGrupo.Text)
        End If
    End Sub

    Private Sub cargarNavesXGrupo(ByVal grupo As String)
        Dim obj = New Negocios.ReportesBU
        Dim dtNaves As New DataTable

        dtNaves = obj.cargarNavesXGrupo(grupo)
        dtNaves.Rows.InsertAt(dtNaves.NewRow, 0)
        cboNave2.DataSource = dtNaves
        cboNave2.DisplayMember = "Nave"
        cboNave2.ValueMember = "idNave"

    End Sub

End Class