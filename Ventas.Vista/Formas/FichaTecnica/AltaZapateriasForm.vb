Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools.Controles
Imports Infragistics.Win.SupportDialogs.FilterUIProvider

Public Class AltaZapateriasForm

    Private Sub AltaZapateriasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarCatalogoZApaterias()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub


    Private Sub LlenarCatalogoZApaterias()
        Dim objBU As New Negocios.ClientesDatosBU
        Dim dtCatalogo As New DataTable

        dtCatalogo = objBU.Datos_Catalogo_ZapateriasCompetencia()

        grdZapaterias.DataSource = Nothing
        grdZapaterias.DataSource = dtCatalogo
    End Sub

    Private Sub grdZapaterias_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdZapaterias.InitializeLayout
        With grdZapaterias
            Dim ugFilter As New UltraGridFilterUIProvider

            .DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.Edit
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .DisplayLayout.Override.AllowDelete = DefaultableBoolean.False

            .DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            .DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            .DisplayLayout.Override.FilterUIProvider = ugFilter
            .DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            .DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.AboveOperand
            .DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            .DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            .DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

        End With

        'For Each row In grdZapaterias.Rows
        '    row.Activation = Activation.AllowEdit
        '    grdZapaterias.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
        '    grdZapaterias.DisplayLayout.Bands(0).Columns(1).CellClickAction = CellClickAction.Edit
        '    grdZapaterias.DisplayLayout.Bands(0).Columns(2).CellClickAction = CellClickAction.Edit
        '    grdZapaterias.DisplayLayout.Bands(0).Columns(3).CellClickAction = CellClickAction.Edit
        'Next
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        GuardarNuevaZapateria()
        LlenarCatalogoZApaterias()
        txtNombreZapateria.Text = ""
        chkClienteYuyin.Checked = False
    End Sub

    Private Sub GuardarNuevaZapateria()
        Dim objCatalogozapaterias As New Entidades.ZapateriaCompetencia
        Dim objBU As New Negocios.ClientesDatosBU

        If ValidarCampoVacios() Then Return

        If Validar_PosibleNuevaZApateria_Existente() Then Return

        objCatalogozapaterias.zapateriasid = 0
        objCatalogozapaterias.nombre = txtNombreZapateria.Text.Trim
        objCatalogozapaterias.clienteyuyin = chkClienteYuyin.Checked
        objCatalogozapaterias.activo = True

        Try
            objBU.AltaZapateria(objCatalogozapaterias)
            Mensajes_Y_Alertas("EXITO", "La zapateria se ha registrado correctamente")
        Catch ex As Exception
            Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado al tratar de dar de alta una nueva zapateria. Error: " + ex.Message)
        End Try

    End Sub

    Private Function ValidarCampoVacios() As Boolean
        ValidarCampoVacios = False

        If LTrim(RTrim(txtNombreZapateria.Text)) = "" Then
            ValidarCampoVacios = True
            Mensajes_Y_Alertas("ADVERTENCIA", "Ingrese el nombre de la zapatería")
        End If

        Return ValidarCampoVacios
    End Function

    Private Function Validar_PosibleNuevaZApateria_Existente() As Boolean
        Validar_PosibleNuevaZApateria_Existente = False

        For Each row As UltraGridRow In grdZapaterias.Rows
            If row.Cells("*ZAPATERÍA").Text.Trim = txtNombreZapateria.Text.Trim Then
                Validar_PosibleNuevaZApateria_Existente = True

                If row.Cells("*ACTIVO").Value = False Then
                    Try
                        ''actualizamos el registro existente
                        Dim objCatalogozapaterias As New Entidades.ZapateriaCompetencia
                        Dim objBU As New Negocios.ClientesDatosBU

                        objCatalogozapaterias.zapateriasid = row.Cells("zaco_zapateriasid").Value
                        objCatalogozapaterias.nombre = row.Cells("*ZAPATERÍA").Value
                        objCatalogozapaterias.clienteyuyin = chkClienteYuyin.Checked
                        objCatalogozapaterias.activo = True

                        objBU.EditarZapateria(objCatalogozapaterias)

                        LlenarCatalogoZApaterias()

                        Mensajes_Y_Alertas("INFORMACION", "La zapatería capturada ya existe, se activó y actualizó el registro.")
                    Catch ex As Exception
                        Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado al tratar de activar un registo existente. Error: " + ex.Message)
                    End Try
                Else
                    Mensajes_Y_Alertas("ADVERTENCIA", "Ya existe una zapatería con este nombre")
                End If

                Exit For
            End If
        Next

        Return Validar_PosibleNuevaZApateria_Existente
    End Function

#Region "EVENTOS GRID"

    Private Sub grdZapaterias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdZapaterias.KeyPress
        Dim caracter As Char = e.KeyChar

        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If

        If caracter = "|" Or caracter = "~" Or caracter = "'" Then
            e.Handled = True
        End If


        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNothing(grdZapaterias.ActiveRow) Then Return

            grdZapaterias.ActiveRow.Cells("*ACTIVO").Activated = True

            If ValidarCamposVacios_grdZapaterias() Then Return

            Dim NextRowIndex As Integer = grdZapaterias.ActiveRow.Index + 1
            grdZapaterias.ActiveRow.Update()

            Try
                grdZapaterias.DisplayLayout.Rows(NextRowIndex).Activated = True
                grdZapaterias.DisplayLayout.Rows(NextRowIndex).Selected = True
            Catch ex As Exception
                grdZapaterias.DisplayLayout.Rows(grdZapaterias.Rows.Count - 1).Activated = True
                grdZapaterias.DisplayLayout.Rows(grdZapaterias.Rows.Count - 1).Selected = True
            End Try
        End If

        If e.KeyChar = ChrW(Keys.Escape) Then
            LlenarCatalogoZApaterias()
        End If
    End Sub

    Private Function ValidarCamposVacios_grdZapaterias() As Boolean
        ValidarCamposVacios_grdZapaterias = False

        If grdZapaterias.ActiveRow.Cells("*ZAPATERÍA").Text.Trim = "" Then
            ValidarCamposVacios_grdZapaterias = True
            Mensajes_Y_Alertas("ADVERTENCIA", "Introduzca un nombre de zapateria valido.")
        End If

    End Function

    Private Function ValidarActualizacionZapateria_Existente() As Boolean
        ValidarActualizacionZapateria_Existente = False

        Dim RowIndex As Integer

        RowIndex = grdZapaterias.ActiveRow.Index

        For Each row As UltraGridRow In grdZapaterias.Rows
            If row.Index <> RowIndex Then
                If row.Cells("*ZAPATERÍA").Text = grdZapaterias.Rows(RowIndex).Cells("*ZAPATERÍA").Text Then
                    ValidarActualizacionZapateria_Existente = True

                    Dim objCatalogozapaterias As New Entidades.ZapateriaCompetencia
                    Dim objClienteDatosBU As New Negocios.ClientesDatosBU

                    objCatalogozapaterias.zapateriasid = row.Cells("zaco_zapateriasid").Value
                    objCatalogozapaterias.nombre = row.Cells("*ZAPATERÍA").Value
                    objCatalogozapaterias.clienteyuyin = CBool(grdZapaterias.ActiveRow.Cells("*CLIENTE YUYIN").Text)
                    objCatalogozapaterias.activo = CBool(grdZapaterias.ActiveRow.Cells("*ACTIVO").Text)

                    objClienteDatosBU.EditarZapateria(objCatalogozapaterias)

                    If row.Cells("zaco_zapateriasid").Value = 0 Then
                        Mensajes_Y_Alertas("INFORMACION", "La zapatería capturada ya existe, se activó y actualizó el registro.")
                    Else
                        Mensajes_Y_Alertas("EXITO", "La zapatería se actualizo correctamente.")
                    End If

                    LlenarCatalogoZApaterias()


                    Exit For
                End If
            End If
        Next

        Return ValidarActualizacionZapateria_Existente
    End Function

    Private Sub ActualizarZapateria()
        Dim objCatalogozapaterias As New Entidades.ZapateriaCompetencia
        Dim objClienteDatosBU As New Negocios.ClientesDatosBU
        Dim row As UltraGridRow = grdZapaterias.ActiveRow


        If Mensajes_Y_Alertas("CONFIRMACION", "¿Desea guardar los cambios realizados?") Then
            'If objClienteDatosBU.ValidarRelaciones_Zapaterias(row.Cells("zaco_zapateriasid").Value) = True Then
            '    Mensajes_Y_Alertas("ADVERTENCIA", "No se puede inactivar esta zapatería ya que esta relacionada con uno o varios cliente, para incactivarla, inactive las relaciones de esta tienda.")
            'Else
            If CBool(row.Cells("*ACTIVO").Text) = False Then
                If objClienteDatosBU.ValidarRelaciones_Zapaterias(row.Cells("zaco_zapateriasid").Value) = True Then
                    Mensajes_Y_Alertas("ADVERTENCIA", "No se puede inactivar esta zapatería ya que esta relacionada con uno o varios cliente, para incactivarla, inactive las relaciones de esta tienda.")
                Else
                    objCatalogozapaterias.zapateriasid = row.Cells("zaco_zapateriasid").Value
                    objCatalogozapaterias.nombre = row.Cells("*Zapatería").Text
                    objCatalogozapaterias.activo = CBool(row.Cells("*ACTIVO").Text)
                    objCatalogozapaterias.clienteyuyin = CBool(row.Cells("*CLIENTE YUYIN").Text)
                    Try
                        objClienteDatosBU.EditarZapateria(objCatalogozapaterias)
                        Mensajes_Y_Alertas("EXITO", "La zapatería se actualizo correctamente.")
                    Catch ex As Exception

                    End Try
                End If
            Else

                If ValidarActualizacionZapateria_Existente() = False Then
                    objCatalogozapaterias.zapateriasid = row.Cells("zaco_zapateriasid").Value
                    objCatalogozapaterias.nombre = row.Cells("*ZAPATERÍA").Text
                    objCatalogozapaterias.clienteyuyin = CBool(row.Cells("*CLIENTE YUYIN").Text)
                    objCatalogozapaterias.activo = CBool(row.Cells("*ACTIVO").Text)
                    Try
                        objClienteDatosBU.EditarZapateria(objCatalogozapaterias)
                        Mensajes_Y_Alertas("EXITO", "La zapatería se actualizo correctamente.")
                    Catch ex As Exception

                    End Try
                End If

            End If

                'End If


                LlenarCatalogoZApaterias()
            Else
                LlenarCatalogoZApaterias()
            End If
    End Sub

    Private Sub gridHorario_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdZapaterias.BeforeRowDeactivate
        If grdZapaterias.ActiveRow.IsDataRow Then
            If ValidarCamposVacios_grdZapaterias() = True Then
                e.Cancel = True
                Return
            End If
        End If
    End Sub

    Private Sub grdZapaterias_Leave(sender As Object, e As EventArgs) Handles grdZapaterias.Leave
        If Not IsNothing(grdZapaterias.ActiveRow) Then
            If grdZapaterias.ActiveRow.IsDataRow Then
                If ValidarCamposVacios_grdZapaterias() = True Then
                    grdZapaterias.Focus()
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub grdZapaterias_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles grdZapaterias.BeforeRowUpdate
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Framework.Negocios.ContactosBU
        If grdZapaterias.ActiveRow.IsDataRow Then
            ActualizarZapateria()
        End If
        Me.Cursor = Cursors.Default
    End Sub
#End Region



End Class