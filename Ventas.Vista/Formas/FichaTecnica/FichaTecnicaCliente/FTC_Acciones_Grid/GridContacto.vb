Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Partial Class FichaTecnicaClienteForm


    'CONTACTO
    Public Sub poblar_gridContacto(PersonaID As Integer, grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New Framework.Negocios.ContactosBU
        Dim Contacto, Cargo, TipoTelefono, MAIL, TELEFONO As New DataTable
        Dim vlCargo, vlTipoTelefono As New Infragistics.Win.ValueList

        If grid.Name.Equals("gridCobranzaEvalContacto") Then
            Contacto = objBU.TablaContactosSegunAreaOperativa(PersonaID, 8)
            ' Cargo = objBU.TablaCargosSegunAreaOperativa(8)
        Else
            Contacto = objBU.TablaContactosSegunAreaOperativa(PersonaID, AreaOperativa)
            ' Cargo = objBU.TablaCargosSegunAreaOperativa(AreaOperativa)
        End If

        Dim dtContactoFinal As DataTable

        dtContactoFinal = Contacto.Clone

        For Each ROW As DataRow In Contacto.Rows
            Dim contadorLineasContacto As Integer

            MAIL = objBU.TablaContactosSegunAreaOperativa(ROW.Item("personaid"), 102)
            TELEFONO = objBU.TablaContactosSegunAreaOperativa(ROW.Item("personaid"), 103)

            If MAIL.Rows.Count > TELEFONO.Rows.Count Then
                contadorLineasContacto = MAIL.Rows.Count
            ElseIf MAIL.Rows.Count < TELEFONO.Rows.Count Then
                contadorLineasContacto = TELEFONO.Rows.Count
            ElseIf MAIL.Rows.Count = TELEFONO.Rows.Count And MAIL.Rows.Count > 0 And TELEFONO.Rows.Count > 0 Then
                contadorLineasContacto = MAIL.Rows.Count
            Else
                contadorLineasContacto = 0
            End If

            If contadorLineasContacto = 0 Then
                dtContactoFinal.Rows.Add(ROW.Item(0), ROW.Item(1), ROW.Item(2), ROW.Item(3), "", "", 0)
            Else
                For cont = 0 To contadorLineasContacto - 1 Step 1
                    If cont <= TELEFONO.Rows.Count - 1 And cont <= MAIL.Rows.Count - 1 Then
                        dtContactoFinal.Rows.Add(ROW.Item(0), ROW.Item(1), ROW.Item(2), ROW.Item(3), TELEFONO.Rows(cont).Item(1), MAIL.Rows(cont).Item(1), MAIL.Rows(cont).Item(0))
                    ElseIf cont <= MAIL.Rows.Count - 1 Then
                        dtContactoFinal.Rows.Add(ROW.Item(0), ROW.Item(1), ROW.Item(2), ROW.Item(3), "", MAIL.Rows(cont).Item(1), MAIL.Rows(cont).Item(0))
                    ElseIf cont <= TELEFONO.Rows.Count - 1 Then
                        dtContactoFinal.Rows.Add(ROW.Item(0), ROW.Item(1), ROW.Item(2), ROW.Item(3), TELEFONO.Rows(cont).Item(1), "", 0)
                    End If
                Next
            End If

            'MAIL = objBU.TablaContactosSegunAreaOperativa(ROW.Item("personaid"), 102)

            'If MAIL.Rows.Count > 0 Then
            '    For Each fila As DataRow In MAIL.Rows
            '        If ROW.Item("CORREO ELECTRÓNICO") = "" Then
            '            ROW.Item("CORREO ELECTRÓNICO") = fila.Item(0)
            '        Else
            '            ROW.Item("CORREO ELECTRÓNICO") += vbCrLf + fila.Item(0)
            '        End If
            '    Next
            'End If

            'TELEFONO = objBU.TablaContactosSegunAreaOperativa(ROW.Item("personaid"), 103)
            'If TELEFONO.Rows.Count > 0 Then
            '    For Each fila As DataRow In TELEFONO.Rows
            '        If ROW.Item("TELÉFONO") = "" Then
            '            ROW.Item("TELÉFONO") = fila.Item(0)
            '        Else
            '            ROW.Item("TELÉFONO") += vbCrLf + fila.Item(0)
            '        End If
            '    Next
            'End If
        Next

        grid.DataSource = dtContactoFinal
        'grid.DisplayLayout.Bands(0).Columns(1).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        'grid.DisplayLayout.Bands(0).Columns(1).ValueList = vlCargo
        'grid.DisplayLayout.Bands(0).Columns(10).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        'grid.DisplayLayout.Bands(0).Columns(10).ValueList = vlTipoTelefono

        gridContactoDiseno(grid)

        'For Each row As UltraGridRow In grid.Rows

        '    If row.Index > 0 Then
        '        If row.Cells(4).Value = grid.Rows(row.Index - 1).Cells(4).Value Then
        '            row.Cells(4).Value = Nothing
        '            row.Cells(5).Value = Nothing
        '        End If
        '    End If

        'Next

    End Sub

    Private Sub GridContactoDiseno2(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(2).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(4).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(6).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(9).Hidden = True

        grid.DisplayLayout.Bands(0).Columns(1).Header.Caption = "CARGO"
        grid.DisplayLayout.Bands(0).Columns(3).Header.Caption = "NOMBRE"
        grid.DisplayLayout.Bands(0).Columns(5).Header.Caption = "EMAIL"
        grid.DisplayLayout.Bands(0).Columns(7).Header.Caption = "TELÉFONO"
        grid.DisplayLayout.Bands(0).Columns(8).Header.Caption = "EXTENSIÓN"
        grid.DisplayLayout.Bands(0).Columns(10).Header.Caption = "TIPO TELÉFONO"

        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        'asignaFormato_Columna(grid)

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

    End Sub

    Private Sub gridContactoDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(1).Hidden = True
        grid.DisplayLayout.Bands(0).Columns("empe_emailpersonasid").Hidden = True
        grid.DisplayLayout.Override.RowSizing = RowSizing.AutoFree
        grid.DisplayLayout.Override.CellMultiLine = DefaultableBoolean.True

        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        Dim RespaldoColor As String = "Blanco"

        For cont = 0 To grid.Rows.Count - 1 Step 1
            If cont > 0 Then
                If grid.Rows(cont).Cells(0).Value = grid.Rows(cont - 1).Cells(0).Value Then
                    If RespaldoColor = "Blanco" Then
                        grid.Rows(cont).Appearance.BackColor = Color.White
                    Else
                        grid.Rows(cont).Appearance.BackColor = Color.LightSteelBlue
                    End If
                Else
                    If RespaldoColor = "Blanco" Then
                        RespaldoColor = "Azul"
                    Else
                        RespaldoColor = "Blanco"
                    End If
                    If RespaldoColor = "Blanco" Then
                        grid.Rows(cont).Appearance.BackColor = Color.White
                    Else
                        grid.Rows(cont).Appearance.BackColor = Color.LightSteelBlue
                    End If
                End If
            Else
                grid.Rows(0).Appearance.BackColor = Color.White
            End If
        Next

        grid.DisplayLayout.Bands(0).Columns(2).MergedCellStyle = MergedCellStyle.Always
    End Sub

    Private Sub asignar_grid_gridContacto(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        gridContacto = grid

    End Sub

    Private Sub gridContacto_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridContacto.DoubleClickHeader

        If Me.gridContacto.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridContacto.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridContacto.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridContacto.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridContacto.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridContacto.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridContacto.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub

    Private Sub gridContacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridContacto.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNothing(gridContacto.ActiveRow) Then Return

            Dim NextRowIndex As Integer = gridContacto.ActiveRow.Index + 1
            Try

                If NextRowIndex <= gridContacto.Rows.Count Then
                    gridContacto.DisplayLayout.Rows(NextRowIndex).Activated = True
                    gridContacto.DisplayLayout.Rows(NextRowIndex).Selected = True
                Else
                    gridContacto.DisplayLayout.Rows(0).Activated = True
                    gridContacto.DisplayLayout.Rows(0).Selected = True
                End If

            Catch ex As Exception
                gridContacto.ActiveRow.Activated = False
                'gridContacto.DisplayLayout.Bands(0).Columns(1).Header.Activated = True
                'gridContacto.DisplayLayout.Bands(0).Columns(1).Header.Selected = True
            End Try


        End If

        If e.KeyChar = ChrW(Keys.Escape) Then
            poblar_gridContacto(CInt(lblClientePersonaID_Int.Text), gridContacto)
            gridContacto.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        End If

    End Sub

    Private Sub gridContacto_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles gridContacto.DoubleClickCell
        If (Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") = True) Or (Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue)) Or (Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARDATOS") = True) Or (Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITAR_CONTACTO_COBRANZA") = True) Then
            Dim objContacto As New InformacionDeContactoYReferenciasForm
            objContacto.StartPosition = FormStartPosition.CenterScreen
            objContacto.IdClienteSAY = CInt(lblClienteSAYID_Int.Text)
            objContacto.IdClientePersonaId = CInt(lblClientePersonaID_Int.Text)
            If gridContacto.ActiveRow.IsDataRow Then
                objContacto.IdPersona_Contacto = gridContacto.ActiveRow.Cells(0).Value
            Else
                objContacto.IdPersona_Contacto = 0
            End If

            If rbtnClienteStatusActivo.Checked Then
                objContacto.IdClasificacionPersona = 1
            Else
                objContacto.IdClasificacionPersona = 2
            End If

            objContacto.ShowDialog()
        End If

        If AreaOperativa = 7 Then
            poblar_gridContacto(CInt(lblClientePersonaID_Int.Text), gridDatosContacto)
            asignar_grid_gridContacto(gridDatosContacto)
        ElseIf AreaOperativa = 2 Then
            poblar_gridContacto(CInt(lblClientePersonaID_Int.Text), gridVentasContacto)
            asignar_grid_gridContacto(gridVentasContacto)
        ElseIf AreaOperativa = 3 Then
            poblar_gridContacto(CInt(lblClientePersonaID_Int.Text), gridCobranzaContacto)
            asignar_grid_gridContacto(gridCobranzaContacto)
        ElseIf AreaOperativa = 5 Then
            poblar_gridContacto(CInt(lblClientePersonaID_Int.Text), gridMKTContacto)
            asignar_grid_gridContacto(gridMKTContacto)
        End If


    End Sub

    Private Sub gridContacto_MouseClick(sender As Object, e As MouseEventArgs) Handles gridContacto.MouseClick

        If rbtnClienteStatusInactivo.Checked Then Return

        Dim mainElement As UIElement
        Dim element As UIElement
        Dim screenPoint As Point
        Dim clientPoint As Point
        Dim row As UltraGridRow
        Dim cell As UltraGridCell

        ' Get the control's main element
        mainElement = Me.gridContacto.DisplayLayout.UIElement

        ' Convert the current mouse position to a point
        ' in client coordinates of the control.
        screenPoint = Control.MousePosition
        clientPoint = Me.gridContacto.PointToClient(screenPoint)

        ' Get the element at that point
        element = mainElement.ElementFromPoint(clientPoint)

        If element Is Nothing Then Return

        Debug.WriteLine("Clicked on an " + element.GetType().ToString())
        Debug.Indent()

        ' Get the row that contains this element.
        row = element.GetContext(GetType(UltraGridRow))

        If Not row Is Nothing Then

            Debug.WriteLine("in row: " + row.Index.ToString())

            ' Get the cell that contains this element.
            cell = element.GetContext(GetType(UltraGridCell))

            If Not cell Is Nothing Then

                If e.Button <> Windows.Forms.MouseButtons.Right Then Return

                'MessageBox.Show("CLICK CLICK    ")
                Dim cms = New ContextMenuStrip
                'Dim item1 = cms.Items.Add("Nuevo contacto")
                'item1.Tag = 1
                'AddHandler item1.Click, AddressOf gridContacto_menuChoice

                'Dim item2 = cms.Items.Add("Editar contacto")
                'item2.Tag = 2
                'AddHandler item2.Click, AddressOf gridContacto_menuChoice

                'Dim item3 = cms.Items.Add("Nuevo email")
                'item3.Tag = 3
                'AddHandler item3.Click, AddressOf gridContacto_menuChoice

                'Dim item4 = cms.Items.Add("Nuevo teléfono")
                'item4.Tag = 4
                'AddHandler item4.Click, AddressOf gridContacto_menuChoice


                If AreaOperativa = 2 Then
                    If gridVentasContacto.ActiveRow.IsFilterRow = False Then
                        Dim fila As UltraGridRow
                        fila = gridVentasContacto.ActiveRow

                        If fila.Cells("clpe_clasificacionpersonaid").Value = 23 Then
                            Dim item5 = cms.Items.Add("Relacionar Marca-Agente")
                            item5.Tag = 5
                            AddHandler item5.Click, AddressOf gridContacto_menuChoice
                        End If
                    End If
                ElseIf AreaOperativa = 7 Then
                    If gridDatosContacto.ActiveRow.IsDataRow Then
                        Dim item5 = cms.Items.Add("Agregar a Contacto Pedidos")
                        item5.Tag = 5
                        AddHandler item5.Click, AddressOf gridContacto_menuChoice
                    End If


                End If


                If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
                    cms.Show(Control.MousePosition)
                Else
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
                        cms.Show(Control.MousePosition)
                    End If
                End If

                Debug.WriteLine("in column: " + cell.Column.Key)
                Debug.WriteLine("cell text: " + cell.Text)
            End If
        End If

        ' Walk up the parent element chain and write out a line 
        ' for each parent element.
        While Not element.Parent Is Nothing
            element = element.Parent
            Debug.WriteLine("is a child of an " + element.GetType().ToString())
            Debug.Indent()
        End While

        ' reset the indent level
        Debug.IndentLevel = 0

    End Sub

    Private Sub gridContacto_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)

        If selection = 1 Then ''AGREGAR NUEVO CONTACTO

            Dim grid As DataTable = gridContacto.DataSource
            Dim row As UltraGridRow = gridContacto.ActiveRow
            Dim cargo As UltraGridColumn = gridContacto.DisplayLayout.Bands(0).Columns(1)
            Dim tipoTelefono As UltraGridColumn = gridContacto.DisplayLayout.Bands(0).Columns(10)

            If Not IsNothing(row) Then

                grid.Rows.Add(0, cargo, 0, String.Empty, 0, String.Empty, 0, String.Empty, String.Empty, 0, tipoTelefono)

                gridContacto.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True

                gridContacto.ActiveRow.Activation = Activation.AllowEdit
                gridContacto.ActiveCell = gridContacto.ActiveRow.Cells(1)
                gridContacto.ActiveCell.Activation = Activation.AllowEdit

                gridContacto.PerformAction(UltraGridAction.ToggleCellSel, False, False)
                gridContacto.PerformAction(UltraGridAction.EnterEditMode, False, False)

            End If

        ElseIf selection = 2 Then ''EDITAR CONTACTO ACTUAL

            For Each row In gridContacto.Selected.Rows
                Dim i As Integer = gridContacto.Rows.Count

                gridContacto.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
                gridContacto.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
            Next

        ElseIf selection = 3 Then ''AGREGAR NUEVO EMAIL
            Dim grid As DataTable = gridContacto.DataSource
            Dim row As UltraGridRow = gridContacto.ActiveRow
            Dim cargoID, personaID As Integer
            Dim cargo, persona As String

            If Not IsNothing(row) Then
                cargoID = CInt(row.Cells(0).Value)
                personaID = CInt(row.Cells(2).Value)
                cargo = row.Cells(1).Value.ToString
                persona = row.Cells(3).Value.ToString

                grid.Rows.Add(cargoID, cargo, personaID, persona, 0, String.Empty, 0, String.Empty, String.Empty, 0, String.Empty)

                gridContacto.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True

                gridContacto.ActiveRow.Activation = Activation.AllowEdit
                gridContacto.ActiveCell = gridContacto.ActiveRow.Cells(5)
                gridContacto.ActiveCell.Activation = Activation.AllowEdit

                gridContacto.PerformAction(UltraGridAction.ToggleCellSel, False, False)
                gridContacto.PerformAction(UltraGridAction.EnterEditMode, False, False)

            End If

        ElseIf selection = 4 Then ''AGREGAR NUEVO TELEFONO
            Dim grid As DataTable = gridContacto.DataSource
            Dim row As UltraGridRow = gridContacto.ActiveRow
            Dim cargoID, personaID As Integer
            Dim cargo, persona As String

            If Not IsNothing(row) Then
                cargoID = CInt(row.Cells(0).Value)
                personaID = CInt(row.Cells(2).Value)


                cargo = row.Cells(1).Value.ToString
                persona = row.Cells(3).Value.ToString
                Dim tipoTelefono As UltraGridColumn = gridContacto.DisplayLayout.Bands(0).Columns(10)

                grid.Rows.Add(cargoID, cargo, personaID, persona, 0, String.Empty, 0, String.Empty, String.Empty, 0, tipoTelefono)
                gridContacto.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True

                gridContacto.ActiveRow.Activation = Activation.AllowEdit
                gridContacto.ActiveCell = gridContacto.ActiveRow.Cells(7)
                gridContacto.ActiveCell.Activation = Activation.AllowEdit

                gridContacto.PerformAction(UltraGridAction.ToggleCellSel, False, False)
                gridContacto.PerformAction(UltraGridAction.EnterEditMode, False, False)

            End If

        ElseIf selection = 5 Then ''AGREGAR NUEVO TELEFONO
            Dim objRelacionarContactoMarcaAgente As New FTC_RelacionaContactoMarcaAgente
            Dim Fila As UltraGridRow
            Dim objPersona As New Entidades.Persona
            Dim objClasificacionPersona As New Entidades.ClasificacionPersona
            Dim objCorreo As New Entidades.Email

            objRelacionarContactoMarcaAgente.StartPosition = FormStartPosition.CenterScreen
            objRelacionarContactoMarcaAgente.Bandera = AreaOperativa

            If AreaOperativa = 2 Then
                Fila = gridVentasContacto.ActiveRow

                'If Fila.Cells("clpe_clasificacionpersonaid").Value <> 21 Then
                '    show_message("Advertencia", "Únicamente los contactos de tipo GENERAL pueden convertirse a CONTACTO PEDIDO, si desea agregar este contacto a PEDIDO, primero cambie el cargo a CONTACTO GENERAL.")
                '    Return
                'End If

                ''PERSONA
                objPersona.personaid = Fila.Cells("personaid").Value
                objPersona.nombre = Fila.Cells("Nombre").Value

                ''CLASIFICACION PERSONA
                objClasificacionPersona.clasificacionpersonaid = Fila.Cells("clpe_clasificacionpersonaid").Value
                objClasificacionPersona.nombre = Fila.Cells("Cargo").Value

                ''CORREO PERSONA
                If (Fila.Cells("empe_emailpersonasid").Value) > 0 Then
                    objCorreo.emailpersonasid = Fila.Cells("empe_emailpersonasid").Value
                    objCorreo.email = Fila.Cells("Correo Electrónico").Value
                    objCorreo.persona = objPersona
                    objCorreo.clasificacionpersona = objClasificacionPersona
                Else

                    show_message("Advertencia", "El contacto no cuenta con un email")
                    Return
                End If

                ''ID CLIENTE SAY
                objRelacionarContactoMarcaAgente.ClienteId = CInt(lblClienteSAYID_Int.Text)
                objRelacionarContactoMarcaAgente.objCorreo = objCorreo
            ElseIf AreaOperativa = 7 Then

                Fila = gridDatosContacto.ActiveRow

                If Not IsDBNull(Fila.Cells("empe_emailpersonasid").Value) Then
                    If Fila.Cells("empe_emailpersonasid").Text <> "0" Then
                        objCorreo.emailpersonasid = Fila.Cells("empe_emailpersonasid").Value
                        objCorreo.email = Fila.Cells("Correo Electrónico").Value
                        objCorreo.persona = objPersona
                        objCorreo.clasificacionpersona = objClasificacionPersona
                    Else
                        show_message("Advertencia", "El contacto no cuenta con un email")
                        Return
                    End If
                Else

                    show_message("Advertencia", "El contacto no cuenta con un email")
                    Return
                End If

                ''EL 21 SE REFIERE A QUE EL TIPO DE CONTACTO SELECCIONADO ES UN CONTACTO GENERAL====21====
                If Fila.Cells("clpe_clasificacionpersonaid").Value <> 21 Then
                    show_message("Advertencia", "Únicamente los contactos de tipo GENERAL pueden convertirse a CONTACTO PEDIDO, si desea agregar este contacto a PEDIDO, primero cambie el cargo a CONTACTO GENERAL.")
                    Return
                End If

                Dim objConfirmar As New Tools.ConfirmarForm
                objConfirmar.mensaje = "¿Desea  agregar el contacto seleccionado como CONTACTO DE PEDIDOS?"
                objConfirmar.StartPosition = FormStartPosition.CenterScreen
                If objConfirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    ''PERSONA
                    objPersona.personaid = Fila.Cells("personaid").Value
                    objPersona.nombre = Fila.Cells("Nombre").Value

                    ''CLASIFICACION PERSONA
                    objClasificacionPersona.clasificacionpersonaid = Fila.Cells("clpe_clasificacionpersonaid").Value
                    objClasificacionPersona.nombre = Fila.Cells("Cargo").Value

                    If Not IsDBNull(Fila.Cells("empe_emailpersonasid").Value) Then
                        If Fila.Cells("empe_emailpersonasid").Text <> "" Then
                            objCorreo.emailpersonasid = Fila.Cells("empe_emailpersonasid").Value
                            objCorreo.email = Fila.Cells("Correo Electrónico").Value
                            objCorreo.persona = objPersona
                            objCorreo.clasificacionpersona = objClasificacionPersona
                        Else
                            show_message("Advertencia", "El contacto no cuenta con un email")
                            Return
                        End If
                    Else
                        show_message("Advertencia", "El contacto no cuenta con un email")
                        Return
                    End If

                    ''ID CLIENTE SAY
                    objRelacionarContactoMarcaAgente.ClienteId = CInt(lblClienteSAYID_Int.Text)
                    objRelacionarContactoMarcaAgente.objCorreo = objCorreo
                Else
                    Return
                End If
            End If
            objRelacionarContactoMarcaAgente.ShowDialog()

            If AreaOperativa = 2 Then
                poblar_gridContacto(CInt(lblClientePersonaID_Int.Text), gridVentasContacto)
                asignar_grid_gridContacto(gridVentasContacto)
                poblar_gridVentasVendedores(CInt(lblClienteSAYID_Int.Text))
            Else
                poblar_gridContacto(CInt(lblClientePersonaID_Int.Text), gridDatosContacto)
                asignar_grid_gridContacto(gridDatosContacto)
                recuperar_datos_Panel_Datos(cboxClienteCliente.SelectedValue)

            End If




        End If
    End Sub

    Private Sub gridContacto_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridContacto.BeforeExitEditMode
        Try
            Dim cellIndex As Integer = gridContacto.ActiveCell.Column.Index

            If gridContacto.ActiveRow.DataChanged Then

            Else
                If gridContacto.ActiveCell.DataChanged Then
                Else
                    If String.IsNullOrWhiteSpace(gridContacto.ActiveCell.Value) Then
                        poblar_gridContacto(CInt(lblClientePersonaID_Int.Text), gridContacto)
                        gridContacto.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                    End If
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gridContacto_AfterRowActivate(sender As Object, e As EventArgs) Handles gridContacto.AfterRowActivate
        gridContacto.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        For Each row In gridContacto.Rows
            row.Activation = Activation.NoEdit
        Next
    End Sub

    Private Sub gridContacto_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridContacto.BeforeRowDeactivate

        If gridContacto.ActiveRow.IsFilterRow Then Return

        If gridContacto.ActiveRow.DataChanged Then

            Dim contactoBU As New Framework.Negocios.ContactosBU
            Dim clasificacionPersona As New Entidades.ClasificacionPersona
            Dim cliente As New Entidades.Cliente
            Dim persona As New Entidades.Persona
            Dim cliente_persona As New Entidades.Persona
            Dim email As New Entidades.Email
            Dim telefono As New Entidades.Telefono
            Dim tipoTelefono As New Entidades.TipoTelefono
            Dim row As UltraGridRow = gridContacto.ActiveRow

            clasificacionPersona.clasificacionpersonaid = row.Cells(1).Column.ValueList.GetValue(row.Cells(1).Text, 0)

            If clasificacionPersona.clasificacionpersonaid = 0 Then
                Exit Sub
            End If

            If IsDBNull(row.Cells(2).Value.ToString) Then
                persona.personaid = 0
            ElseIf String.IsNullOrWhiteSpace(row.Cells(2).Value.ToString) Then
                persona.personaid = 0
            Else
                persona.personaid = CInt(row.Cells(2).Value)
            End If

            If IsDBNull(row.Cells(3).Value) Then
                persona.nombre = String.Empty
                persona.activo = False
            ElseIf String.IsNullOrWhiteSpace(row.Cells(3).Value) Then
                persona.nombre = String.Empty
                persona.activo = False
            Else
                persona.nombre = row.Cells(3).Value.ToString
                persona.activo = True
            End If

            If IsDBNull(row.Cells(4).Value) Then
                email.emailpersonasid = 0
            Else
                If String.IsNullOrEmpty(row.Cells(4).Value) Then
                    email.emailpersonasid = 0
                Else
                    email.emailpersonasid = CInt(row.Cells(4).Value)
                End If
            End If

            If IsDBNull(row.Cells(5).Value) Then
                email.email = String.Empty
                email.activo = False
            Else
                If String.IsNullOrEmpty(row.Cells(5).Value) Then
                    email.email = String.Empty
                    email.activo = False
                Else
                    email.email = row.Cells(5).Value.ToString
                    email.activo = True
                End If
            End If


            If IsDBNull(row.Cells(6).Value) Then
                telefono.telefonoid = 0
            Else
                If String.IsNullOrWhiteSpace(row.Cells(6).Value) Then
                    telefono.telefonoid = 0
                Else
                    telefono.telefonoid = row.Cells(6).Value
                End If
            End If

            If IsDBNull(row.Cells(7).Value) Then
                telefono.telefono = String.Empty
                telefono.activo = False
            Else
                If String.IsNullOrWhiteSpace(row.Cells(7).Value) Then
                    telefono.telefono = String.Empty
                    telefono.activo = False
                Else
                    telefono.telefono = row.Cells(7).Value.ToString
                    telefono.activo = True
                End If
            End If

            If IsDBNull(row.Cells(8).Value) Then
                telefono.extension = String.Empty
            Else
                If String.IsNullOrWhiteSpace(row.Cells(8).Value.ToString) Then
                    telefono.extension = String.Empty
                Else
                    telefono.extension = row.Cells(8).Value.ToString
                End If
            End If


            tipoTelefono.tipotelefonoid = row.Cells(10).Column.ValueList.GetValue(row.Cells(10).Text, 0)

            cliente_persona.personaid = CInt(lblClientePersonaID_Int.Text)


            If cboxClienteEstatus.SelectedIndex > -1 Then
                Dim clasificacionPersonas As New Entidades.ClasificacionPersona
                If cboxClienteEstatus.Text.ToUpperInvariant.Equals("PROSPECTO") Then
                    cliente.statuscliente = "P"
                    clasificacionPersonas.clasificacionpersonaid = 3
                    cliente.clasificacionpersona = clasificacionPersonas
                ElseIf cboxClienteEstatus.Text.ToUpperInvariant.Equals("CLIENTE") Then
                    cliente.statuscliente = "C"
                    clasificacionPersonas.clasificacionpersonaid = 1
                    cliente.clasificacionpersona = clasificacionPersonas
                End If
            Else
                show_message("Advertencia", "Falta información")
                lblClienteEstatus.ForeColor = Color.Red
                Exit Sub
            End If


            If persona.personaid = 0 Then
                contactoBU.AltaContacto(persona, clasificacionPersona, cliente_persona, cliente, email, telefono, tipoTelefono)
            Else
                contactoBU.EditarContacto(0, clasificacionPersona, persona, email, telefono, tipoTelefono)
            End If

            poblar_gridContacto(CInt(lblClientePersonaID_Int.Text), gridContacto)
            asignar_grid_gridContacto(gridVentasContacto)

            poblar_gridVentasVendedores(CInt(lblClienteSAYID_Int.Text))

        Else

        End If

        'gridContacto.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

    End Sub


End Class
