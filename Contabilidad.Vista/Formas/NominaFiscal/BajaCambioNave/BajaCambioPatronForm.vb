Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports Framework.Negocios

Public Class BajaCambioPatronForm
    Private Sub BajaCambioPatronForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        BajaPorCambioPatrónWordToolStripMenuItem.Visible = PermisosUsuarioBU.ConsultarPermiso("SOLBAJA_CONTA_INDUSTAR", "MODIF_WORD")
        cmbNave.Visible = PermisosUsuarioBU.ConsultarPermiso("SOLBAJA_CONTA_INDUSTAR", "CAMBIAR_NAVE")
        lblNave.Visible = cmbNave.Visible
        llenarComboNave()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Visible = False
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Visible = True
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click, lblCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click, lblLimpiar.Click
        limpiarFiltros()
    End Sub

    Private Sub limpiarFiltros()
        'cmbNave.SelectedIndex = 0
        txtNombre.Text = ""
        grdListado.DataSource = Nothing

    End Sub

    Private Sub llenarComboNave()
        Tools.Controles.ComboNavesSegunUsuario(cmbNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
        cmbNave.SelectedValue = 61
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        grdListado.DataSource = Nothing
        cmbPatron.DataSource = Nothing
        pnlBajaCambioPatron.Enabled = True

        If cmbNave.SelectedIndex > 0 Then
            Dim objBu As New Negocios.BajaCambioPatronBU 'Contabilidad.Negocios.UtileriasBU
            Dim dtEmpresa As New DataTable

            'dtEmpresa = objBu.consultaPatronPorNave(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue)
            dtEmpresa = objBu.consultaPatrones(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue, 0)
            If dtEmpresa.Rows.Count > 0 Then
                If dtEmpresa.Rows.Count = 1 Then
                    Dim dtRow As DataRow = dtEmpresa.NewRow
                    dtRow("ID") = 0
                    dtRow("PATRON") = ""
                    dtEmpresa.Rows.InsertAt(dtRow, 0)
                End If

                cmbPatron.DataSource = dtEmpresa
                cmbPatron.DisplayMember = "Patron"
                cmbPatron.ValueMember = "ID"

                If dtEmpresa.Rows.Count = 2 Then
                    cmbPatron.SelectedIndex = 1
                End If
            End If
        End If
    End Sub

    Private Sub cmbPatron_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPatron.SelectedIndexChanged
        grdListado.DataSource = Nothing
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        cargarListado()
    End Sub

    Private Sub txtNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyDown
        If (e.KeyValue = Keys.Enter) Then
            cargarListado()
        End If
    End Sub


    Private Function validarFiltros() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbNave.Items.Count > 1 And cmbNave.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar una Nave."
            objMensajeAdv.ShowDialog()
            Return False
        End If

        If cmbPatron.Items.Count > 1 And cmbPatron.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar un Patrón."
            objMensajeAdv.ShowDialog()
            Return False
        End If

        Return True
    End Function
    Public Sub cargarListado()
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        grdListado.DataSource = Nothing
        Try
            If validarFiltros() Then
                Dim objBu As New Negocios.BajaCambioPatronBU
                Dim dtListado As New DataTable
                Dim patronId As Integer = cmbPatron.SelectedValue

                Dim nombre As String = txtNombre.Text

                dtListado = objBu.obtenerListaColaboradores(patronId, nombre)
                If Not dtListado Is Nothing Then
                    If dtListado.Rows.Count > 0 Then
                        grdListado.DataSource = dtListado
                        disenioGrid()
                    Else
                        objMensajeAdv.mensaje = "La consulta no devolvió ningún resultado"
                        objMensajeAdv.Show()
                    End If
                Else
                    objMensajeAdv.mensaje = "La consulta no devolvió ningún resultado"
                    objMensajeAdv.Show()
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar listado de colaboradores."
            objMensajeError.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub disenioGrid()
        With GridView1
            .Columns("idCol").Visible = False
            .Columns("idNave").Visible = False
            .Columns("idPatron").Visible = False
            .Columns("idPatron").Visible = False
            .Columns("Sel").Visible = False
            .Columns("SDI").Visible = False

            .Columns("Codigo").Width = 60
            .Columns("Nombre").Width = 300
            .Columns("CURP").Width = 150
            .Columns("NSS").Width = 100

            .OptionsView.EnableAppearanceEvenRow = True
            .OptionsView.EnableAppearanceOddRow = True
        End With
    End Sub

    Private Sub btnBajaCambioPatron_Click(sender As Object, e As EventArgs) Handles btnBajaCambioPatron.Click
        abrirCambioPatronColaborador()
    End Sub

    Private Sub abrirCambioPatronColaborador()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim filaSeleccionada As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)

        If Not filaSeleccionada Is Nothing Then
            Dim idColaborador As Integer = filaSeleccionada.Item("idCol")
            Dim idNave As Integer = filaSeleccionada.Item("idNave")
            Dim nombre As String = filaSeleccionada.Item("Nombre")
            Dim infonavit As Boolean = CBool(filaSeleccionada.Item("Infonavit").ToString.ToUpper = "SI")
            Dim sdi As Double = filaSeleccionada.Item("SDI")
            Dim patronorigenid As Integer = filaSeleccionada.Item("idPatron")

            Dim objForm As New CambioPatronColaboradorForm
            If Not CheckForm(objForm) Then
                objForm.idColaborador = idColaborador
                objForm.idNave = idNave
                objForm.nombre = nombre
                objForm.infonavit = infonavit
                objForm.sdiAnterior = sdi
                objForm.patronOrigenId = patronorigenid
                objForm.ShowDialog()
                If objForm.guardado Then
                    cargarListado()
                End If
            End If
        Else
            objMensajeAdv.mensaje = "Favor de seleccionar un colaborador."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        menuAyuda.Show(btnAyuda, 0, btnAyuda.Height)
    End Sub

    Private Sub AyudaSolBajaCambioDePatron_Click(sender As Object, e As EventArgs) Handles AyudaSolBajaCambioDePatron.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_BajaCambioPatron_NominaFiscal_V1.pdf")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_BajaCambioPatron_NominaFiscal_V1.pdf")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BajaPorCambioPatrónWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BajaPorCambioPatrónWordToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_BajaCambioPatron_NominaFiscal_V1.docx")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_BajaCambioPatron_NominaFiscal_V1.docx")
        Catch ex As Exception
        End Try
    End Sub
End Class