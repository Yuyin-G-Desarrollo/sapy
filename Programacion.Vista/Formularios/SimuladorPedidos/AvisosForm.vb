Imports Framework.Negocios
Imports Programacion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class AvisosForm


    Private Sub form_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        ConfigurarSeguridad()
        InitCombos()
        LlenarTabla()
    End Sub

    Private Sub btnAltasUsuario_Click(sender As System.Object, e As System.EventArgs) Handles btnAltasUsuario.Click
        Dim vAdvertenciaForm As New AdvertenciaForm
        If Not cmbUsuario.Text = "" Then
            With grdDatos
                If .ActiveRow Is Nothing Then Exit Sub
                If .ActiveRow.Index < 0 Then Exit Sub
            End With

            AgregarUsuarioAviso()
        Else
            vAdvertenciaForm.Text = "Avisos"
            vAdvertenciaForm.mensaje = "Debe seleccionar un usuario"
            vAdvertenciaForm.ShowDialog()
        End If


    End Sub

    Private Sub bntBajasUsuario_Click(sender As System.Object, e As System.EventArgs) Handles bntBajasUsuario.Click
        With grdUsuarios
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        EliminarUsuarioAviso()
    End Sub


    Private Sub grdDatos_AfterCellUpdate(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdDatos.AfterCellUpdate
        With grdDatos
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        Dim vAdvertenciaForm As New AdvertenciaForm
        If Not ModificarAviso() Then

            vAdvertenciaForm.Text = "Avisos"
            vAdvertenciaForm.mensaje = "No se puede registrar la misma hora"
            vAdvertenciaForm.ShowDialog()
            LlenarTabla()
        End If

    End Sub

    Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltasAvisos.Click
        AltaAviso()
    End Sub

    Private Sub btnBaja_Click(sender As System.Object, e As System.EventArgs) Handles btnBajaAvisos.Click
        With grdDatos
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        BajaAviso()

    End Sub

    Private Sub grdDatos_AfterRowActivate(sender As System.Object, e As System.EventArgs) Handles grdDatos.AfterRowActivate
        LlenarTablaUsuarios()
    End Sub
    Private Sub LlenarTabla()
        Dim vErrorForm As New ErroresForm
        Dim vPedidosBU As New PedidosBU
        grdDatos.DataSource = Nothing
        Try
            Me.Cursor = Cursors.WaitCursor
            grdDatos.DataSource = vPedidosBU.ObtenerAvisos
            formatoGrig()
        Catch ex As Exception
            vErrorForm.Text = "Avisos"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub LlenarTablaUsuarios()
        Dim vPedidosBU As New PedidosBU
        Dim vErrorForm As New ErroresForm
        grdUsuarios.DataSource = Nothing
        Try
            grdUsuarios.DataSource = vPedidosBU.TablaUsuarioAviso(grdDatos.ActiveRow.Cells("ID").Value)
            formatoGrigUsuario()
        Catch ex As Exception
            vErrorForm.Text = "Avisos"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        End Try

    End Sub

    Public Sub formatoGrig()
        Dim band As UltraGridBand = Me.grdDatos.DisplayLayout.Bands(0)
        With band
            .Columns("ID").CellActivation = Activation.NoEdit
            .Columns("Hora").CellActivation = Activation.AllowEdit
            .Columns("ID").CellAppearance.TextHAlign = HAlign.Right
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdUsuarios.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdUsuarios.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdUsuarios.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdUsuarios.DisplayLayout.Override.RowSelectorWidth = 35
        grdUsuarios.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True


    End Sub
    Public Sub formatoGrigUsuario()
        Dim band As UltraGridBand = Me.grdUsuarios.DisplayLayout.Bands(0)
        With band
            .Columns("ID").CellActivation = Activation.NoEdit
            .Columns("Usuario").CellActivation = Activation.NoEdit
            .Columns("Hora").CellActivation = Activation.NoEdit
            .Columns("ID").CellAppearance.TextHAlign = HAlign.Right

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdDatos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdDatos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdDatos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDatos.DisplayLayout.Override.RowSelectorWidth = 35
        grdDatos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        ' grdDatos.Rows(0).Selected = True

        band.Columns("ID").Width = 18
        'band.Columns("Usuario").Width = 18
        band.Columns("Hora").Width = 18

    End Sub
    Private Sub InitCombos()
        Dim objUsuarioBU As New Framework.Negocios.UsuariosBU
        Dim tablaUsuarios As New DataTable
        tablaUsuarios = objUsuarioBU.ListarUsuariosSegunPerfil(33)
        tablaUsuarios.Rows.InsertAt(tablaUsuarios.NewRow, 0)
        With cmbUsuario
            .DisplayMember = "user_nombrereal"
            .ValueMember = "user_usuarioid"
            .DataSource = tablaUsuarios
        End With
    End Sub

    Private Sub ConfigurarSeguridad()
        ' Dim permiso As Boolean

        'permiso = PermisosUsuarioBU.ConsultarPermiso("PRG_AUTORIZAR", "WRITE")
        'btnAutorizar.Visible = permiso
        'lblAutorizar.Visible = permiso


    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub AltaAviso()
        Dim vPedidosBU As New PedidosBU
        Dim vExitoForm As New ExitoForm
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim Hora As String = ""
        Dim frmAviso As New AvisosPedirHoraForm
        Dim dlrResultado As DialogResult = frmAviso.ShowDialog
        If dlrResultado = Windows.Forms.DialogResult.OK Then
            Hora = frmAviso.Hora
            frmAviso.Dispose()
            If vPedidosBU.VerificarHoraAviso(Hora) Then
                vPedidosBU.AgregarHoraAviso(Hora)
                LlenarTabla()
                vExitoForm.Text = "Avisos"
                vExitoForm.mensaje = "Registro guardado"
                vExitoForm.ShowDialog()
            Else
                vAdvertenciaForm.Text = "Avisos"
                vAdvertenciaForm.mensaje = "No se puede registrar la misma hora"
                vAdvertenciaForm.ShowDialog()
            End If

        End If

    End Sub
    Private Function ModificarAviso() As Boolean
        Dim vPedidosBU As New PedidosBU
        Dim vExitoForm As New ExitoForm
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vConfirmarForm As New ConfirmarForm
        Dim vErrorForm As New ErroresForm
        Dim Hora As String = ""
        Dim bandera = True
        Try
            vConfirmarForm.Text = "Avisos"
            vConfirmarForm.mensaje = "¿ Está seguro de modificar el aviso seleccionado ?"
            Dim vDialogResult As New DialogResult
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                If vPedidosBU.VerificarHoraAviso(grdDatos.ActiveRow.Cells("Hora").Value) Then
                    vPedidosBU.ModificarHoraAviso(grdDatos.ActiveRow.Cells("ID").Value, grdDatos.ActiveRow.Cells("Hora").Value)
                Else
                    bandera = False

                End If
            Else
                bandera = False
            End If
        Catch ex As Exception
            vErrorForm.Text = "Avisos"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
            bandera = False
        Finally
            Me.Cursor = Cursors.Default

        End Try
        Return bandera
    End Function
    Private Sub BajaAviso()
        Dim vPedidosBU As New PedidosBU
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vExitoForm As New ExitoForm
        Dim vConfirmarForm As New ConfirmarForm
        Try
            vConfirmarForm.Text = "Avisos"
            vConfirmarForm.mensaje = "¿ Está seguro de eliminar el aviso seleccionado ?"
            Dim vDialogResult As New DialogResult
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                vPedidosBU.EliminarHoraAviso(grdDatos.ActiveRow.Cells("ID").Value)
                LlenarTabla()
                vExitoForm.Text = "Avisos"
                vExitoForm.mensaje = "Registro Eliminado"
                vExitoForm.ShowDialog()
            End If

        Catch ex As Exception
            vAdvertenciaForm.Text = "Avisos"
            vAdvertenciaForm.mensaje = "No se puede eliminar el aviso, existen usuarios relacionados con el mismo"
            vAdvertenciaForm.ShowDialog()
        End Try


    End Sub

    Private Sub AgregarUsuarioAviso()
        Dim vPedidosBU As New PedidosBU
        Dim vExitoForm As New ExitoForm
        Dim vAdvertenciaForm As New AdvertenciaForm
        If vPedidosBU.VerificarUsuarioAviso(cmbUsuario.SelectedValue) Then
            vPedidosBU.AgregarUsuarioAviso(cmbUsuario.SelectedValue, grdDatos.ActiveRow.Cells("ID").Value)
            LlenarTablaUsuarios()
            vExitoForm.Text = "Avisos"
            vExitoForm.mensaje = "Registro Guardado"
            vExitoForm.ShowDialog()
        Else
            vAdvertenciaForm.Text = "Avisos"
            vAdvertenciaForm.mensaje = "Ya existe este aviso para el usuario"
            vAdvertenciaForm.ShowDialog()
        End If

    End Sub
    Private Sub EliminarUsuarioAviso()
        Dim vPedidosBU As New PedidosBU
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vExitoForm As New ExitoForm
        Dim vConfirmarForm As New ConfirmarForm
        Try
            vConfirmarForm.Text = "Avisos"
            vConfirmarForm.mensaje = "¿ Está seguro de eliminar el aviso del usuario seleccionado ?"
            Dim vDialogResult As New DialogResult
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                vPedidosBU.EliminarUsuarioAviso(grdUsuarios.ActiveRow.Cells("ID").Value)
                LlenarTablaUsuarios()
                vExitoForm.Text = "Avisos"
                vExitoForm.mensaje = "Registro Eliminado"
                vExitoForm.ShowDialog()
            End If
        Catch ex As Exception
            vAdvertenciaForm.Text = "Avisos"
            vAdvertenciaForm.mensaje = "No se puede eliminar el aviso"
            vAdvertenciaForm.ShowDialog()
        End Try


    End Sub

    Private Sub grdDatos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdDatos.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdUsuarios_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdUsuarios.BeforeRowsDeleted
        e.Cancel = True
    End Sub

End Class