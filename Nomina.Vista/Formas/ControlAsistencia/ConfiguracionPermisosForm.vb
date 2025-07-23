Imports Entidades

Public Class ConfiguracionPermisosForm

    Dim objUsuarioSesion As Usuarios
    Dim frmFormE As ConfiguracionPermisosDetalleForm

    Private Sub ConfiguracionPermisosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        load_configuracion_Colores()
        load_componenentesInicio()
        load_gridConfiguracionPermisos(cmbNave.SelectedValue)

    End Sub

    Private Sub load_configuracion_Colores()

        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)

        'pnlCabezera.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)
        'pnlPie.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)
        'lblAgregar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblEditar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblTitulo.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'grdConfiguracionPermisos.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.grid)

    End Sub

    Private Sub load_componenentesInicio()

        btnAgregar.Focus()
        btnAgregar.Visible = True
        lblAgregar.Visible = True

        btnEditar.Visible = True
        lblEditar.Visible = True

        Dim objUsuarioSesion = SesionUsuario.UsuarioSesion

        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, objUsuarioSesion.PUserUsuarioid)

    End Sub

    Private Sub load_gridConfiguracionPermisos(ByVal IDNave As Int32)

        Dim configuracionpermisosBU As New Negocios.ConfiguracionPermisosBU
        Dim listaConfiguracionPermisos As New List(Of Entidades.ConfiguracionPermisos)

        listaConfiguracionPermisos = configuracionpermisosBU.listaConfiguracionPermisos(IDNave)

        grdConfiguracionPermisos.Rows.Count = 1

        If listaConfiguracionPermisos.Capacity > 0 Then
            For Each fila As Entidades.ConfiguracionPermisos In listaConfiguracionPermisos
                grdConfiguracionPermisos.AddItem(fila.PConfiguracionPermisos_id.ToString + ControlChars.Tab + fila.PConfiguracionPermisos_nombre + ControlChars.Tab + fila.PConfiguracionPermisos_puntualidad_asistencia.ToString + ControlChars.Tab + fila.PConfiguracionPermisos_caja_ahorro.ToString)
            Next
        End If

    End Sub

    'Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

    '    Dim navesBU As New Framework.Negocios.NavesBU
    '    Dim ListaNavesSegunUsuario As New List(Of Entidades.Naves)

    '    validar_Componentes(btnAgregar.Name.ToString)

    '    ListaNavesSegunUsuario = navesBU.ListaNavesSegunUsuario("", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

    '    If ListaNavesSegunUsuario.Capacity > 0 Then

    '        Dim i As Integer = 0

    '        For Each fila As Entidades.Naves In ListaNavesSegunUsuario

    '            Me.gridConfiguracionAsistencia.Rows.Insert(0, 0, fila.PNaveId, fila.PNombre)
    '            gridConfiguracionAsistencia.Rows(i).DefaultCellStyle.BackColor = Color.LightSalmon

    '        Next

    '        i += 1

    '    End If

    'End Sub

    'Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click

    '    validar_Componentes(btnEditar.Name.ToString)
    '    clmRango.ReadOnly = False
    '    clmResultado.ReadOnly = False
    '    clmPorcentaje.ReadOnly = False

    'End Sub

    'Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

    '    validar_Componentes(btnCancelar.Name.ToString)

    '    For Each row As DataGridViewRow In gridConfiguracionAsistencia.Rows 'Recorro todo el grid fila por fila

    '        If row.Cells(0).Value = 0 Then

    '            row.Cells(3).Value = Nothing
    '            row.Cells(4).Value = Nothing
    '            row.Cells(5).Value = Nothing

    '        End If

    '    Next

    '    load_gridConfiguracionAsistencia()

    'End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
        If cmbNave.SelectedIndex > 0 Then
            load_gridConfiguracionPermisos(cmbNave.SelectedValue)
        Else
            grdConfiguracionPermisos.Rows.Count = 1
        End If
    End Sub
   
    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        'If grdConfiguracionPermisos.Row <= 0 Then Exit Sub

        frmFormE = New ConfiguracionPermisosDetalleForm
        With frmFormE
            .lblIdNave.Text = cmbNave.SelectedValue
            .ShowDialog()
            If .Tag = 1 Then
                load_gridConfiguracionPermisos(cmbNave.SelectedValue)
            End If
        End With
        frmFormE.Close()
        frmFormE = Nothing
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        If grdConfiguracionPermisos.Row <= 0 Then Exit Sub

        frmFormE = New ConfiguracionPermisosDetalleForm
        With frmFormE
            .load_infoMotivo(Int(grdConfiguracionPermisos.GetData(grdConfiguracionPermisos.Row, 0)), False)
            .ShowDialog()
            If .Tag = 1 Then
                load_gridConfiguracionPermisos(cmbNave.SelectedValue)
            End If
        End With
        frmFormE.Close()
        frmFormE = Nothing
    End Sub

    Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
        grbConfiguracionPermisos.Height = 39
    End Sub

    Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
        grbConfiguracionPermisos.Height = 70
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub grdConfiguracionPermisos_Click(sender As Object, e As EventArgs) Handles grdConfiguracionPermisos.Click

    End Sub
End Class