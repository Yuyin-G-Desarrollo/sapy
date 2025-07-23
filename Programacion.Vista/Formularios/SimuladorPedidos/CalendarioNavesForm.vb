Imports Framework.Negocios
Imports Programacion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class CalendarioNavesForm

    Dim AlturaMaximaPanel As Int32 = 0
    Dim Listo As Boolean = False



    Private Sub form_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0

        LlenarAños()
        LlenarNaves()

        Listo = True
        CargarCalendarioNave()
    End Sub






    Private Sub cmbNaves_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNaves.SelectedIndexChanged
        If Not Listo Then Exit Sub
        CargarCalendarioNave()
    End Sub



    Private Sub grd_años_AfterCellActivate(sender As System.Object, e As System.EventArgs) Handles grd_años.AfterCellActivate
        'CargarCalendarioNave()
    End Sub

    Private Sub grd_años_AfterSelectChange(sender As Object, e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles grd_años.AfterSelectChange
        If Not Listo Then Exit Sub

        CargarCalendarioNave()

    End Sub

    Private Sub grd_años_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grd_años.BeforeRowsDeleted
        e.Cancel = True
    End Sub



    Private Sub grd_años_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles grd_años.DoubleClickCell
        CargarCalendarioNave()
    End Sub

    Private Sub grdDatos_AfterCellUpdate(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdDatos.AfterCellUpdate

        With grdDatos
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With


        actualizarDia()


    End Sub

    Private Sub grdDatos_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdDatos.BeforeRowsDeleted
        e.Cancel = True
    End Sub



    Private Sub UltraGrid1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDatos.KeyUp

        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            grdDatos.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, False, False)
            grdDatos.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
        End If
    End Sub



    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        With grd_años
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        guardarCalendario()

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Public Sub actualizarDia()
        Dim vConfirmarForm As New ConfirmarForm
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vCalendarioBU As New CalendarioBU
        Dim valor As Double = grdDatos.ActiveRow.Cells("Dias").Value
        Try
            If valor < 1.01 Then
                vConfirmarForm.Text = "Calendario Naves"
                If Not cmbNaves.Text = "" Then
                    vConfirmarForm.mensaje = "¿ Cambiar el dia para esta nave ?"
                Else
                    vConfirmarForm.mensaje = "¿ Cambiar el dia para todas las naves?"
                End If

                Dim vDialogResult As New DialogResult
                vDialogResult = vConfirmarForm.ShowDialog
                If vDialogResult = Windows.Forms.DialogResult.OK Then
                    If Not cmbNaves.Text = "" Then
                        vCalendarioBU.actualizarDia(grdDatos.ActiveRow.Cells("Dias").Value.ToString, CDate(grdDatos.ActiveRow.Cells("fecha").Value), (grdDatos.ActiveRow.Cells("id_nave").Value))
                    Else
                        vCalendarioBU.actualizarDiaNaves(grdDatos.ActiveRow.Cells("Dias").Value.ToString, CDate(grdDatos.ActiveRow.Cells("fecha").Value))
                        CargarCalendarioNave()
                    End If

                End If
            Else
                vAdvertenciaForm.Text = "Calendario Naves"
                vAdvertenciaForm.mensaje = "El valor de la columna Días debe ser un número no mayor a 1.00 "
                vAdvertenciaForm.ShowDialog()
            End If

            Me.Cursor = Cursors.WaitCursor


        Catch ex As Exception
            'InterfazUsuario.MostrarError(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub guardarCalendario()

        Dim vErrorForm As New ErroresForm
        Dim vExitoForm As New ExitoForm
        Dim vConfirmarForm As New ConfirmarForm
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vCalendarioBU As New CalendarioBU
        Try
            Me.Cursor = Cursors.WaitCursor
            vConfirmarForm.Text = "Calendario Naves"
            vConfirmarForm.mensaje = "¿ Desea generar los registros del año y las naves seleccionadas ?"
            Dim vDialogResult As New DialogResult
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                Dim inicio As Date = CDate("01/01/" & grd_años.ActiveRow.Cells("año").Value)
                Dim final As Date = CDate("31/12/" & grd_años.ActiveRow.Cells("año").Value)
                'If chkModificarTodas.Checked Then
                If cmbNaves.Text = "" Then
                    For Each naveid As DataRowView In cmbNaves.Items
                        If Not CInt(naveid.Item(0)) = 0 Then
                            If vCalendarioBU.verificarAniosNave(CInt(naveid.Item(0)), grd_años.ActiveRow.Cells("año").Value) Then
                                vCalendarioBU.agregarAnioCalendario(CInt(naveid.Item(0)), inicio, final)
                            Else
                                vAdvertenciaForm.Text = "Calendario Naves"
                                vAdvertenciaForm.mensaje = "La nave " + naveid.Item(1).ToString + " ya tiene el calendario del año " + grd_años.ActiveRow.Cells("año").Value.ToString + " registrado"
                                vAdvertenciaForm.ShowDialog()
                            End If
                        End If
                    Next
                    CargarCalendarioNave()
                    vExitoForm.Text = "Calendario Naves"
                    vExitoForm.mensaje = "Registros generados con éxito."
                    vExitoForm.ShowDialog()
                Else
                    'If Not cmbNaves.Text = "" Then
                    If vCalendarioBU.verificarAniosNave(cmbNaves.SelectedValue, grd_años.ActiveRow.Cells("año").Value) Then
                        vCalendarioBU.agregarAnioCalendario(cmbNaves.SelectedValue, inicio, final)
                        CargarCalendarioNave()
                        vExitoForm.Text = "Calendario Naves"
                        vExitoForm.mensaje = "Registros generados con éxito."
                        vExitoForm.ShowDialog()
                    Else
                        vAdvertenciaForm.Text = "Calendario Naves"
                        vAdvertenciaForm.mensaje = "La nave " + cmbNaves.Text + " ya tiene el calendario del año " + grd_años.ActiveRow.Cells("año").Value.ToString + " registrado"
                        vAdvertenciaForm.ShowDialog()
                    End If
                    '    Else
                    '    vAdvertenciaForm.Text = "Calendario Naves"
                    '    vAdvertenciaForm.mensaje = "Debe de seleccionar una nave o seleccionar la opcion de 'Crear Año para todas las naves'"
                    '    vAdvertenciaForm.ShowDialog()
                    'End If

                End If

            Else

            End If
        Catch ex As Exception
            vErrorForm.Text = "Calendario Naves"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try


    End Sub
    Private Sub LlenarNaves()
        Dim obj As New Framework.Negocios.NavesBU

        With cmbNaves
            .DataSource = obj.TablaDeNavesActivas
            .DisplayMember = "nave_nombre"
            .ValueMember = "id_"
            .SelectedIndex = 0
        End With

    End Sub

    Private Sub LlenarAños()
        Dim vCalendarioBU As New CalendarioBU
        Dim vErrorForm As New ErroresForm
        Try
            grd_años.DataSource = vCalendarioBU.TablaAños
            formatotablaAnio()
        Catch ex As Exception
            vErrorForm.Text = "Calendario Nave"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        End Try

    End Sub

    Private Sub CargarCalendarioNave()
        If Not Listo Then Exit Sub
        With grd_años
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With
        Dim vCalendarioBU As New CalendarioBU
        Dim vErrorForm As New ErroresForm
        Try
            Me.Cursor = Cursors.WaitCursor
            grdDatos.DataSource = vCalendarioBU.TablaNaveAño(cmbNaves.SelectedValue, grd_años.ActiveRow.Cells("año").Value)
            formatotablaCalendario()
        Catch ex As Exception
            vErrorForm.Text = "Calendario Nave"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try


    End Sub








    Public Sub formatotablaCalendario()
        Dim band As UltraGridBand = Me.grdDatos.DisplayLayout.Bands(0)
        With band
            .Columns("Nave").CellActivation = Activation.NoEdit
            .Columns("Fecha").CellActivation = Activation.NoEdit
            .Columns("Dia").CellActivation = Activation.NoEdit
            .Columns("Semana").CellActivation = Activation.NoEdit
            .Columns("Dias").CellActivation = Activation.AllowEdit

            .Columns("Dias").Style = ColumnStyle.DoubleNonNegative
            .Columns("Dias").Format = "0.00"
            .Columns("id_nave").Hidden = True

            .Columns("Dia").Header.Caption = "Día"
            .Columns("Dias").Header.Caption = "Días"

            .Columns("Semana").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Dias").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Dia").CellAppearance.TextHAlign = HAlign.Left

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdDatos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdDatos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdDatos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDatos.DisplayLayout.Override.RowSelectorWidth = 35
        grdDatos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        band.Columns("Dia").Width = 30
        band.Columns("Semana").Width = 30
        band.Columns("Fecha").Width = 35
        band.Columns("Dias").Width = 30
    End Sub
    Public Sub formatotablaAnio()
        Dim band As UltraGridBand = Me.grd_años.DisplayLayout.Bands(0)
        With band
            .Columns("Año").CellActivation = Activation.NoEdit
            .Columns("Año").CellAppearance.TextHAlign = HAlign.Right
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grd_años.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grd_años.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grd_años.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grd_años.DisplayLayout.Override.RowSelectorWidth = 35
        grd_años.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

    End Sub
End Class