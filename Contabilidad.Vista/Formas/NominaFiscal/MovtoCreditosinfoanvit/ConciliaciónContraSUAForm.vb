Imports System.Windows.Forms
Imports Framework.Negocios
Imports DevExpress.XtraPrinting
Imports Tools

Public Class ConciliaciónContraSUAForm
    Dim colaboradorIds As String = String.Empty
    Dim registrosEdicion As Integer = 0
    Private Sub ConciliaciónContraSUAForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized

        ''Permisos menú
        'READ
        'IMPORTAR
        'EDITAR-GRID
        'AUTORIZAR_MES
        'MODIF-WORD_DATOS
        'PROPUESTA_CARGA_DATOS

        llenarComboBimestre()
        llenarComboPatrones()
        numAnio.Value = Now.Year
    End Sub

    Private Sub btnSeleccionarColaborador_Click(sender As Object, e As EventArgs) Handles btnSeleccionarColaborador.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbPatron.Items.Count > 1 And cmbPatron.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar un Patrón"
            objMensajeAdv.ShowDialog()
        Else
            Dim objForm As New SeleccionarColaboradoresForm
            If Not CheckForm(objForm) Then
                objForm.colaboradorIds = colaboradorIds
                objForm.patronId = cmbPatron.SelectedValue
                objForm.ShowDialog()
                colaboradorIds = String.Empty
                colaboradorIds = objForm.colaboradorIds

                If colaboradorIds <> "" Then
                    pnlArchivoCargado.Visible = True
                Else
                    pnlArchivoCargado.Visible = False
                End If
            End If
        End If
    End Sub

#Region "METODOS"

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub llenarComboBimestre()

        Dim objBU As New Negocios.DatosSPEMensualBU
        Dim dtLista As New DataTable

        dtLista = objBU.consultaListaMeses()

        If Not dtLista Is Nothing AndAlso dtLista.Rows.Count > 0 Then
            cmbMes.DataSource = dtLista
            cmbMes.ValueMember = "NumMes"
            cmbMes.DisplayMember = "Descripcion"
        Else
            cmbMes.DataSource = Nothing
        End If

    End Sub
    Private Sub llenarComboPatrones()
        Dim objBU As New Negocios.UtileriasBU
        Dim dtPatrones As New DataTable

        dtPatrones = objBU.consultarPatronEmpresa()

        If Not dtPatrones Is Nothing AndAlso dtPatrones.Rows.Count > 0 Then
            cmbPatron.DataSource = dtPatrones
            cmbPatron.ValueMember = "ID"
            cmbPatron.DisplayMember = "PATRON"
        Else
            cmbPatron.DataSource = Nothing
        End If

    End Sub

    Private Sub btnImportarDatos_Click(sender As Object, e As EventArgs) Handles btnImportarDatos.Click

    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Visible = False
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Visible = True
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        If registrosEdicion = 0 Then
            Me.Close()
        Else
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Existen registros en edición, ¿Esta seguro de continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Dim blnLimpiar As Boolean = False
        If registrosEdicion = 0 Then
            blnLimpiar = True
        Else
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Existen registros en edición, ¿Esta seguro de continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                blnLimpiar = True
            End If
        End If

        If blnLimpiar Then
            ''limpiar()
            cmbPatron.SelectedIndex = 0
            cmbMes.SelectedIndex = 0
            numAnio.Value = Now.Year
            pnlArchivoCargado.Enabled = False
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs)
        If registrosEdicion = 0 Then
            Me.Close()
        Else
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Existen registros en edición, ¿Esta seguro de continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If
        End If
    End Sub





#End Region
End Class