Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.SupportDialogs.FilterUIProvider

Public Class InformacionDeContactoYReferenciasForm

    Public IdClienteSAY As Integer
    Public IdClientePersonaId As Integer
    Public IdClasificacionPersona As Integer
    Public IdPersona_Contacto As Integer


    Private Sub InformacionDeContactoYReferenciasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listaContactoReferencias()

        If IdPersona_Contacto > 0 Then
            For Each row As UltraGridRow In grdReferenciasComerciales.Rows
                If row.Cells("Id").Value = IdPersona_Contacto Then
                    row.Activated = True
                    row.Selected = True
                    lblCliente.Text = row.Cells("Nombre").Value
                    Exit For
                End If
            Next
            listaCargosDelContacto(IdPersona_Contacto)
            listaCorreosElectronicos()
            listaTelefonos()
        End If
       
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim objAgregarContacto As New Alta_Contacto_ReferenciaComercialForm
        objAgregarContacto.StartPosition = FormStartPosition.CenterScreen
        objAgregarContacto.Cliente_IdPersona = IdClientePersonaId
        objAgregarContacto.ShowDialog()

        listaContactoReferencias()
    End Sub


#Region "POBLAR LISTAS"

#Region "CONTACTOS REFERENCIAS"

    Private Sub listaContactoReferencias()
        Dim objBU As New Framework.Negocios.ContactosBU
        Dim dtContactoReferencia As New DataTable
        Dim dtContactoFinal As DataTable
        Dim permiso As Boolean = 0
        ''VALIDAR PERMISOS, PARA MOSTRAR INFORMACION DE: CONTACTOS Y REFERENCIAS.
        permiso = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITAR_CONTACTO_COBRANZA")

        dtContactoReferencia = objBU.ConsultaContactosReferenciasComerciales(IdClientePersonaId, permiso)
        dtContactoFinal = dtContactoReferencia.Clone

        For cont = 0 To dtContactoReferencia.Rows.Count - 1 Step 1

            If cont = 0 Then
                dtContactoFinal.Rows.Add()
                dtContactoFinal.Rows(cont).Item(0) = dtContactoReferencia.Rows(cont).Item(0)
                dtContactoFinal.Rows(cont).Item(1) = dtContactoReferencia.Rows(cont).Item(1)
                dtContactoFinal.Rows(cont).Item(2) = dtContactoReferencia.Rows(cont).Item(2)
                dtContactoFinal.Rows(cont).Item(3) = dtContactoReferencia.Rows(cont).Item(3)
                dtContactoFinal.Rows(cont).Item(4) = dtContactoReferencia.Rows(cont).Item(4)
                dtContactoFinal.Rows(cont).Item(5) = dtContactoReferencia.Rows(cont).Item(5)
            Else
                Dim i As Integer = 0
                'For Each rowF As DataRow In dtContactoFinal.Rows
                '    If dtContactoReferencia.Rows(cont).Item(0) = rowF.Item(0) And dtContactoReferencia.Rows(cont).Item(3) <> rowF.Item(3) Then
                '        i += 1
                '        rowF.Item(3) = rowF.Item(3) + ", " + dtContactoReferencia.Rows(cont).Item(3)
                '    End If
                'Next

                For Each rowF As DataRow In dtContactoFinal.Rows
                    If dtContactoReferencia.Rows(cont).Item(0) = rowF.Item(0) And dtContactoReferencia.Rows(cont).Item(3) <> rowF.Item(3) Then

                        ' If dtContactoReferencia.Rows(cont).Item(2) = 1 Then
                        i += 1
                        rowF.Item(3) = rowF.Item(3) + ", " + dtContactoReferencia.Rows(cont).Item(3)
                        'End If

                    End If
                Next

                If i = 0 Then
                    dtContactoFinal.Rows.Add()
                    dtContactoFinal.Rows(dtContactoFinal.Rows.Count - 1).Item(0) = dtContactoReferencia.Rows(cont).Item(0)
                    dtContactoFinal.Rows(dtContactoFinal.Rows.Count - 1).Item(1) = dtContactoReferencia.Rows(cont).Item(1)
                    dtContactoFinal.Rows(dtContactoFinal.Rows.Count - 1).Item(2) = dtContactoReferencia.Rows(cont).Item(2)
                    dtContactoFinal.Rows(dtContactoFinal.Rows.Count - 1).Item(3) = dtContactoReferencia.Rows(cont).Item(3)
                    dtContactoFinal.Rows(dtContactoFinal.Rows.Count - 1).Item(4) = dtContactoReferencia.Rows(cont).Item(4)
                    dtContactoFinal.Rows(dtContactoFinal.Rows.Count - 1).Item(5) = dtContactoReferencia.Rows(cont).Item(5)

                End If
            End If
        Next

        grdReferenciasComerciales.DataSource = dtContactoFinal

        If IdPersona_Contacto > 0 Then
            For Each row As UltraGridRow In grdReferenciasComerciales.Rows
                If row.Cells(0).Value = IdPersona_Contacto Then
                    row.Activate()
                End If
            Next

            listaCargosDelContacto(IdPersona_Contacto)
            listaTelefonos()
            listaCorreosElectronicos()
        End If

    End Sub

    Private Sub grdReferenciasComerciales_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdReferenciasComerciales.InitializeLayout
        Formato_Gral_Grids(grdReferenciasComerciales)

        With grdReferenciasComerciales

            .DisplayLayout.Bands(0).Columns("Tipo de Contacto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Modificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Usuario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Id").Hidden = True
            .DisplayLayout.Bands(0).Columns("Nombre").Width = 200
            .DisplayLayout.Bands(0).Columns("Activo").Width = 40
            .DisplayLayout.Bands(0).Columns("Tipo de Contacto").Width = 200
            .DisplayLayout.Bands(0).Columns("Usuario").Width = 100

            If gpbContactosReferenciasComerciales.Dock = DockStyle.Fill Then
                .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            End If


            Dim ugFilter As New UltraGridFilterUIProvider
            .DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            .DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            .DisplayLayout.Override.FilterUIProvider = ugFilter
            .DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            .DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.AboveOperand
            .DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            .DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            .DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End With
    End Sub

    Private Sub grdReferenciasComerciales_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdReferenciasComerciales.DoubleClickCell
        If grdReferenciasComerciales.ActiveRow.IsDataRow Then
            lblCliente.Text = grdReferenciasComerciales.ActiveRow.Cells("Nombre").Text
            chkVerTodo.Checked = False

            IdPersona_Contacto = grdReferenciasComerciales.ActiveRow.Cells(0).Value
            listaCargosDelContacto(IdPersona_Contacto)
            listaCorreosElectronicos()
            listaTelefonos()

            btnAgregarCargos.Enabled = True
            btnAgregarEmail.Enabled = True
            btnAgregarTelefono.Enabled = True
        End If
        

    End Sub

    Private Sub grdReferenciasComerciales_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdReferenciasComerciales.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim NextRowIndex As Integer = grdReferenciasComerciales.ActiveRow.Index + 1
            Try
                grdReferenciasComerciales.ActiveRow.Update()
                If NextRowIndex <= grdReferenciasComerciales.Rows.Count - 1 Then
                    grdReferenciasComerciales.DisplayLayout.Rows(NextRowIndex).Selected = True
                Else
                    grdReferenciasComerciales.DisplayLayout.Rows(0).Selected = True
                End If
            Catch ex As Exception
                grdReferenciasComerciales.ActiveRow.Activated = False
            End Try
        ElseIf e.KeyChar = ChrW(Keys.Escape) Then
            listaContactoReferencias()
        End If
    End Sub

    Private Sub grdReferenciasComerciales_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles grdReferenciasComerciales.BeforeRowUpdate
        If grdReferenciasComerciales.ActiveRow.IsDataRow Then
            If grdReferenciasComerciales.ActiveRow.DataChanged Then
                If Tools.Controles.Mensajes_Y_Alertas("CONFIRMACION", "¿Esta seguro de actualizar la información del contacto?") Then
                    Dim objBU As New Framework.Negocios.ContactosBU
                    Try
                        objBU.ActualizarContacto(grdReferenciasComerciales.ActiveRow.Cells("Id").Value, _
                                                 grdReferenciasComerciales.ActiveRow.Cells("Nombre").Text, _
                                                 grdReferenciasComerciales.ActiveRow.Cells("Activo").Text)
                        Tools.Controles.Mensajes_Y_Alertas("EXITO", "Contacto actualizado exitosamente.")

                    Catch ex As Exception
                        Tools.Controles.Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado. Error: " + ex.Message)
                    End Try

                    If chkVerTodo.Checked Then
                        listaCargosDelContacto(IdPersona_Contacto)
                        listaTelefonos()
                        listaCorreosElectronicos()
                    End If
                    listaContactoReferencias()
                Else
                    listaContactoReferencias()
                End If
            End If
        End If
    End Sub

#End Region

#Region "CARGOS DEL CONTACTO"

    Private Sub listaCargosDelContacto(ByVal IdPersonaContacto As String)
        Dim objBU As New Framework.Negocios.ContactosBU
        Dim dtCargos, dtCargosActivos As New DataTable
        Dim vlCargo As New Infragistics.Win.ValueList

        dtCargosActivos = objBU.Lista_ClasificacionPersona_Activos_Sin_Asignar(IdPersonaContacto, IdClientePersonaId)
        dtCargos = objBU.listaAsignacionesdeContacto(IdPersonaContacto)
        grdContactoSeleccionado.DataSource = dtCargos

        For Each row As DataRow In dtCargosActivos.Rows
            vlCargo.ValueListItems.Add(row.Item("Id"), row.Item("Nombre"))
        Next

        grdContactoSeleccionado.DisplayLayout.Bands(0).Columns("Activo").Style = ColumnStyle.CheckBox
        grdContactoSeleccionado.DisplayLayout.Bands(0).Columns("Cargos").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        grdContactoSeleccionado.DisplayLayout.Bands(0).Columns("Cargos").ValueList = vlCargo
    End Sub

    Private Sub grdContactoSeleccionado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdContactoSeleccionado.InitializeLayout
        Formato_Gral_Grids(grdContactoSeleccionado)

        If Not IsNothing(grdContactoSeleccionado.DataSource) Then
            With grdContactoSeleccionado
                If chkVerTodo.Checked = True Then
                    .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                End If
                .DisplayLayout.Bands(0).Columns("Cargos").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .DisplayLayout.Bands(0).Columns("Nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .DisplayLayout.Bands(0).Columns("Modificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .DisplayLayout.Bands(0).Columns("Usuario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .DisplayLayout.Bands(0).Columns("pers_PersonaId").Hidden = True
                .DisplayLayout.Bands(0).Columns("repe_relacionespersonaid").Hidden = True
                .DisplayLayout.Bands(0).Columns("Activo").Width = 40
                .DisplayLayout.Bands(0).Columns("Nombre").Width = 200
                .DisplayLayout.Bands(0).Columns("Cargos").Width = 200

                If gpbCargosContacto.Dock = DockStyle.Fill Then
                    .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                End If

                Dim ugFilter As New UltraGridFilterUIProvider
                .DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
                .DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
                .DisplayLayout.Override.FilterUIProvider = ugFilter
                .DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
                .DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.AboveOperand
                .DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
                .DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
                .DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

            End With
        End If

    End Sub

    Private Sub grdContactoSeleccionado_Leave(sender As Object, e As EventArgs) Handles grdContactoSeleccionado.Leave
        If Not IsNothing(grdContactoSeleccionado.ActiveRow) Then
            If grdContactoSeleccionado.ActiveRow.IsDataRow Then
                If grdContactoSeleccionado.ActiveRow.Cells("Cargos").Value = "--Selecciona--" Then
                    Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione un cargo ó presione ""ESCAPE"" para cancelar esta acción.")
                    grdContactoSeleccionado.Focus()
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub grdContactoSeleccionado_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdContactoSeleccionado.BeforeRowDeactivate
        If grdContactoSeleccionado.ActiveRow.IsDataRow Then
            If grdContactoSeleccionado.ActiveRow.Cells("Cargos").Value = "--Selecciona--" Then
                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione un cargo ó presione ""ESCAPE"" para cancelar esta acción.")
                e.Cancel = True
                Return
            End If
        End If
        

    End Sub

    Private Sub grdContactoSeleccionado_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdContactoSeleccionado.ClickCell
        If Not IsNothing(grdContactoSeleccionado.ActiveRow) Then
            If grdContactoSeleccionado.ActiveRow.IsDataRow Then
                If grdContactoSeleccionado.ActiveRow.Cells("repe_relacionespersonaid").Value = 0 Then
                    If e.Cell.Column.ToString = "Cargos" Then
                        grdContactoSeleccionado.ActiveRow.Cells("Cargos").Activation = Activation.AllowEdit
                    End If
                    If e.Cell.Column.ToString = "activo" Then
                        grdContactoSeleccionado.ActiveRow.Cells("activo").Activation = Activation.NoEdit
                    End If
                Else
                    If e.Cell.Column.ToString = "Cargos" Then
                        grdContactoSeleccionado.ActiveRow.Cells("Cargos").Activation = Activation.NoEdit
                        grdContactoSeleccionado.ActiveRow.Selected = True
                    End If
                    If e.Cell.Column.ToString = "activo" Then
                        grdContactoSeleccionado.ActiveRow.Cells("activo").Activation = Activation.AllowEdit
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub grdContactoSeleccionado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdContactoSeleccionado.KeyPress
       
        If e.KeyChar = ChrW(Keys.Enter) Then
            grdContactoSeleccionado.ActiveRow.Selected = True
            If grdContactoSeleccionado.ActiveRow.Cells("Cargos").Value = "--Selecciona--" Then
                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione un cargo ó presione ""ESCAPE"" para cancelar esta acción.")
                Return
            End If
            
            Dim NextRowIndex As Integer = grdContactoSeleccionado.ActiveRow.Index + 1
            Try
                If grdContactoSeleccionado.ActiveRow.Cells(1).Value = 0 Then
                    grdContactoSeleccionado.ActiveRow.Cells("Activo").Value = 0
                    grdContactoSeleccionado.ActiveRow.Cells("Activo").Value = 1
                End If

                grdContactoSeleccionado.ActiveRow.Update()

                If NextRowIndex <= grdContactoSeleccionado.Rows.Count - 1 Then
                    grdContactoSeleccionado.DisplayLayout.Rows(NextRowIndex).Selected = True
                Else
                    grdContactoSeleccionado.DisplayLayout.Rows(0).Selected = True
                End If
            Catch ex As Exception
                If Not IsNothing(grdContactoSeleccionado.ActiveRow) Then
                    grdContactoSeleccionado.ActiveRow.Activated = False
                End If
            End Try
        ElseIf e.KeyChar = ChrW(Keys.Escape) Then
            listaCargosDelContacto(grdReferenciasComerciales.ActiveRow.Cells("Id").Value)
        End If
    End Sub

    Private Sub grdContactoSeleccionado_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles grdContactoSeleccionado.BeforeRowUpdate
        Me.Cursor = Cursors.WaitCursor
        If grdContactoSeleccionado.ActiveRow.IsDataRow Then
            If grdContactoSeleccionado.ActiveRow.DataChanged Then

                If grdContactoSeleccionado.ActiveRow.Cells("repe_relacionespersonaid").Value = 0 Then
                    If Tools.Controles.Mensajes_Y_Alertas("CONFIRMACION", "¿Esta seguro de guardar el cargo para el contacto seleccionado?") Then
                        Dim objBU As New Framework.Negocios.ContactosBU
                        Try
                            Dim objEntidades As New Entidades.RelacionesPersonas
                            objEntidades.PPersonaId = grdContactoSeleccionado.ActiveRow.Cells("pers_personaid").Value
                            objEntidades.PCLasificacionPersona1 = grdContactoSeleccionado.ActiveRow.Cells("Cargos").Value
                            objEntidades.PPersona2_Id = IdClientePersonaId
                            objEntidades.PClasificacionPersona2 = IdClasificacionPersona
                            objEntidades.PActivo = True

                            If Validar_Registro_AsignacionContacto_Existente(objEntidades) = False Then
                                Tools.Controles.Mensajes_Y_Alertas("EXITO", "El cargo se guardo exitosamente.")
                                objBU.GuardarCargoContacto(objEntidades)
                            End If

                            listaCargosDelContacto(grdReferenciasComerciales.ActiveRow.Cells("Id").Value)
                        Catch ex As Exception
                            Tools.Controles.Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado. Error: " + ex.Message)
                        End Try
                    Else
                        listaCargosDelContacto(grdReferenciasComerciales.ActiveRow.Cells("Id").Value)
                    End If
                Else
                    If Tools.Controles.Mensajes_Y_Alertas("CONFIRMACION", "¿Esta seguro de actualizar la información del contacto?") Then
                        Dim objBU As New Framework.Negocios.ContactosBU
                        Try
                            objBU.ActualizarCargoContacto(grdContactoSeleccionado.ActiveRow.Cells("repe_relacionespersonaid").Value, _
                                                     CBool(grdContactoSeleccionado.ActiveRow.Cells("Activo").Text))
                            Tools.Controles.Mensajes_Y_Alertas("EXITO", "Contacto actualizado exitosamente.")

                            listaTelefonos()
                            listaCorreosElectronicos()

                        Catch ex As Exception
                            Tools.Controles.Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado. Error: " + ex.Message)
                        End Try
                    Else
                        listaCargosDelContacto(grdReferenciasComerciales.ActiveRow.Cells("Id").Value)
                    End If
                End If
            End If
        End If

        listaContactoReferencias()

        Me.Cursor = Cursors.Default
    End Sub

    Public Sub iniciarFormatoGridCargos()
        Dim dtCargos As New DataTable
        With dtCargos
            .Columns.Add("pers_personaid")
            .Columns.Add("repe_relacionespersonaid")
            .Columns.Add("Cargos")
            .Columns.Add("Activo")
            .Columns.Add("Nombre")
            .Columns.Add("Modificación")
            .Columns.Add("Usuario")
        End With
        grdContactoSeleccionado.DataSource = dtCargos
    End Sub
    Private Sub btnAgregarCargos_Click(sender As Object, e As EventArgs) Handles btnAgregarCargos.Click
        'iniciarFormatoGridCargos()
        Dim grid As DataTable = grdContactoSeleccionado.DataSource
        Dim cargo As UltraGridColumn = grdContactoSeleccionado.DisplayLayout.Bands(0).Columns(1)
        Dim objbu As New Framework.Negocios.ContactosBU

        Dim dtCargosActivos As DataTable = objbu.Lista_ClasificacionPersona_Activos_Sin_Asignar(grdReferenciasComerciales.ActiveRow.Cells(0).Value, IdClientePersonaId)
        
        grid.Rows.Add(grdReferenciasComerciales.ActiveRow.Cells(0).Value, 0, "--Selecciona--", 1, grdReferenciasComerciales.ActiveRow.Cells("Nombre").Text)

        grdContactoSeleccionado.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True

        grdContactoSeleccionado.ActiveRow.Activation = Activation.AllowEdit
        grdContactoSeleccionado.ActiveCell = grdContactoSeleccionado.ActiveRow.Cells(1)
        grdContactoSeleccionado.ActiveCell.Activation = Activation.AllowEdit

        grdContactoSeleccionado.PerformAction(UltraGridAction.ToggleCellSel, False, False)
        grdContactoSeleccionado.PerformAction(UltraGridAction.EnterEditMode, False, False)

    End Sub

 
#End Region

#Region "TELEFONOS"

    Private Sub listaTelefonos()
        Dim objBU As New Framework.Negocios.ContactosBU
        Dim dtTelefonos, dtCargos, dtContactos, dtTiposTelefonos As New DataTable
        Dim vlCargo, vlTipoTelefono, vlContactos As New Infragistics.Win.ValueList

        Dim IdsPersonas_Contactos As String = RecuperarIdPersona()

        dtTelefonos = objBU.ListaTelefonosdeContacto(IdsPersonas_Contactos)
        grdTelefono.DataSource = dtTelefonos

        If chkVerTodo.Checked = False Then
            dtCargos = objBU.lista_Asignaciones_De_Contacto_Activas(IdClientePersonaId, IdPersona_Contacto)
            dtContactos = objBU.Lista_Contactos_Activos(IdClientePersonaId)
            dtTiposTelefonos = objBU.Lista_Tipo_Telefono_Activo()
            
            For Each row As DataRow In dtCargos.Rows
                vlCargo.ValueListItems.Add(row.Item("Id_Clasificacion"), row.Item("Tipo de Contacto"))
            Next
            For Each row As DataRow In dtContactos.Rows
                vlContactos.ValueListItems.Add(row.Item("Id"), row.Item("Nombre"))
            Next
            For Each row As DataRow In dtTiposTelefonos.Rows
                vlTipoTelefono.ValueListItems.Add(row.Item("Id"), row.Item("tite_nombre"))
            Next

            grdTelefono.DisplayLayout.Bands(0).Columns("Cargo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
            grdTelefono.DisplayLayout.Bands(0).Columns("Cargo").ValueList = vlCargo
            grdTelefono.DisplayLayout.Bands(0).Columns("Nombre").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
            grdTelefono.DisplayLayout.Bands(0).Columns("Nombre").ValueList = vlContactos

            grdTelefono.DisplayLayout.Bands(0).Columns("WA").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

            grdTelefono.DisplayLayout.Bands(0).Columns("Tipo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
            grdTelefono.DisplayLayout.Bands(0).Columns("Tipo").ValueList = vlTipoTelefono

            grdTelefono.DisplayLayout.Bands(0).Columns("Activo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

        End If
        


    End Sub

    Private Sub grdTelefono_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdTelefono.InitializeLayout
        Formato_Gral_Grids(grdTelefono)


        If Not IsNothing(grdTelefono.DataSource) Then
            With grdTelefono
                If chkVerTodo.Checked = True Then
                    .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                End If
                .DisplayLayout.Bands(0).Columns("Modificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .DisplayLayout.Bands(0).Columns("Usuario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .DisplayLayout.Bands(0).Columns("IdTelefono").Hidden = True
                .DisplayLayout.Bands(0).Columns("Activo").Width = 37
                .DisplayLayout.Bands(0).Columns("Ext.").Width = 60
                .DisplayLayout.Bands(0).Columns("Teléfono").Width = 110
                .DisplayLayout.Bands(0).Columns("WA").Width = 37

                .DisplayLayout.Bands(0).Columns("Tipo").Width = 110
                .DisplayLayout.Bands(0).Columns("Nombre").Width = 125

                .DisplayLayout.Bands(0).Columns("Teléfono").Format = "n0"
                '.DisplayLayout.Bands(0).Columns("Teléfono").MaskInput = "############"
                .DisplayLayout.Bands(0).Columns("Teléfono").MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                .DisplayLayout.Bands(0).Columns("Teléfono").CellAppearance.TextHAlign = HAlign.Right

                .DisplayLayout.Bands(0).Columns("Ext.").Format = "n0"
                '.DisplayLayout.Bands(0).Columns("Ext.").MaskInput = "####"
                .DisplayLayout.Bands(0).Columns("Ext.").MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                .DisplayLayout.Bands(0).Columns("Ext.").CellAppearance.TextHAlign = HAlign.Right

                If gpbTelefonos.Dock = DockStyle.Fill Then
                    .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                End If

                Dim ugFilter As New UltraGridFilterUIProvider
                .DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
                .DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
                .DisplayLayout.Override.FilterUIProvider = ugFilter
                .DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
                .DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.AboveOperand
                .DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
                .DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
                .DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

            End With

        End If

    End Sub

    Private Sub grdTelefono_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdTelefono.BeforeCellUpdate
        Try
            If e.Cell.Column.ToString = "Nombre" Then

                If grdTelefono.ActiveRow.Cells("Nombre").Value = grdTelefono.ActiveRow.Cells("Nombre").Text Then
                    e.Cancel = True
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdTelefono_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdTelefono.AfterCellUpdate
        Dim dtListaCargosContacto As New DataTable
        Dim objBU As New Framework.Negocios.ContactosBU
        Dim vlCargos As New Infragistics.Win.ValueList

        

        If e.Cell.Column.ToString = "Nombre" Then
            dtListaCargosContacto = objBU.lista_Asignaciones_De_Contacto_Activas(IdClientePersonaId, grdTelefono.ActiveRow.Cells("Nombre").Value)

            grdTelefono.ActiveRow.Cells("Nombre").Activated = True
            grdTelefono.ActiveRow.Selected = True

            For Each row As DataRow In dtListaCargosContacto.Rows
                vlCargos.ValueListItems.Add(row.Item("Id_Clasificacion"), row.Item("Tipo de Contacto"))
            Next

            grdTelefono.DisplayLayout.Bands(0).Columns("Cargo").ValueList = vlCargos

            If dtListaCargosContacto.Rows.Count > 1 Then
                grdTelefono.ActiveRow.Cells("Cargo").Value = "--Selecciona--"
            Else
                If dtListaCargosContacto.Rows.Count = 1 Then
                    grdTelefono.ActiveRow.Cells("Cargo").Value = dtListaCargosContacto.Rows(0).Item(0)
                End If
            End If



            grdTelefono.ActiveRow.Cells("Nombre").Activated = True
            grdTelefono.ActiveRow.Selected = True

        End If
    End Sub

    Private Sub grdTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdTelefono.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then

            grdTelefono.ActiveRow.Cells("Teléfono").Activated = True


            If ValidarCamposDelTelefonoVacios() Then
                Return
            End If

            Dim NextRowIndex As Integer = grdTelefono.ActiveRow.Index + 1
            Try
                If grdTelefono.ActiveRow.Cells("IdTelefono").Value = 0 Then
                    grdTelefono.ActiveRow.Cells("Activo").Value = 0
                    grdTelefono.ActiveRow.Cells("Activo").Value = 1
                End If

                grdTelefono.ActiveRow.Update()

                If NextRowIndex <= grdTelefono.Rows.Count - 1 Then
                    grdTelefono.DisplayLayout.Rows(NextRowIndex).Selected = True
                Else
                    grdTelefono.DisplayLayout.Rows(0).Selected = True
                End If
            Catch ex As Exception
                If Not IsNothing(grdTelefono.ActiveRow) Then
                    grdTelefono.ActiveRow.Activated = False
                End If

            End Try
        ElseIf e.KeyChar = ChrW(Keys.Escape) Then
            listaTelefonos()
        Else
            If Char.IsNumber(e.KeyChar) = False And (Char.IsLetter(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar)) Then
                e.Handled = True
            Else
                If Char.IsNumber(e.KeyChar) Then

                    If grdTelefono.ActiveRow.Cells("Teléfono").IsActiveCell Then
                        If grdTelefono.ActiveRow.Cells("Teléfono").Text.Length = 12 Then
                            e.Handled = True
                        End If
                    ElseIf grdTelefono.ActiveRow.Cells("Ext.").IsActiveCell Then
                        If grdTelefono.ActiveRow.Cells("Ext.").Text.Length > 4 Then
                            e.Handled = True
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Function ValidarCamposDelTelefonoVacios() As Boolean
        ValidarCamposDelTelefonoVacios = False

        Dim Telefono As String = (((((RTrim(LTrim(grdTelefono.ActiveRow.Cells("Teléfono").Text)).Replace("+", "")).Replace("-", "")).Replace("(", "")).Replace(")", "")).Replace(" ", "")).Replace("_", "")

        If Telefono = "" Then
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Ingrese un teléfono ó presione ""ESCAPE"" para cancelar esta acción.")
            ValidarCamposDelTelefonoVacios = True
        ElseIf Telefono.Length < 7 Then
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Ingrese el teléfono telefono con clave internaciona, clave nacional y numero ó presione ""ESCAPE"" para cancelar esta acción.")
            ValidarCamposDelTelefonoVacios = True
        ElseIf grdTelefono.ActiveRow.Cells("Tipo").Value = "--Selecciona--" Then
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione un tipo de telefono ó presione ""ESCAPE"" para cancelar esta acción.")
            ValidarCamposDelTelefonoVacios = True
        ElseIf grdTelefono.ActiveRow.Cells("Nombre").Value = "--Selecciona--" Then
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione un contacto ó presione ""ESCAPE"" para cancelar esta acción.")
            ValidarCamposDelTelefonoVacios = True
        ElseIf grdTelefono.ActiveRow.Cells("Cargo").Value = "--Selecciona--" Then
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione un cargo ó presione ""ESCAPE"" para cancelar esta acción.")
            ValidarCamposDelTelefonoVacios = True
        ElseIf IsNumeric(grdTelefono.ActiveRow.Cells("Nombre").Value) = False Then
            If grdTelefono.ActiveRow.Cells("Nombre").Value <> grdTelefono.ActiveRow.Cells("Nombre").Text Then
                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione un el cargo para el contacto seleccionado ó ""ESCAPE"" para cancelar esta acción.")
                ValidarCamposDelTelefonoVacios = True
            End If
        End If

        Return ValidarCamposDelTelefonoVacios
    End Function

    Private Sub grdTelefono_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdTelefono.BeforeRowDeactivate
        If grdTelefono.ActiveRow.IsDataRow Then
            If ValidarCamposDelTelefonoVacios() = True Then
                e.Cancel = True
                Return
            End If
        End If        
    End Sub

    Private Sub grdTelefono_Leave(sender As Object, e As EventArgs) Handles grdTelefono.Leave
        If Not IsNothing(grdTelefono.ActiveRow) Then
            If grdTelefono.ActiveRow.IsDataRow Then
                If ValidarCamposDelTelefonoVacios() = True Then
                    grdTelefono.Focus()
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub grdTelefono_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles grdTelefono.BeforeRowUpdate
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Framework.Negocios.ContactosBU
        If grdTelefono.ActiveRow.IsDataRow Then
            If grdTelefono.ActiveRow.DataChanged Then
                If grdTelefono.ActiveRow.Cells("Cargo").Value <> "--Selecciona--" Then
                    Actualizar_Agregar_TelefonoDeContacto()
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Actualizar_Agregar_TelefonoDeContacto()

        Dim objBU As New Framework.Negocios.ContactosBU
        Dim objPersona As New Entidades.Persona
        Dim objClasificacion As New Entidades.ClasificacionPersona
        Dim objTelefono As New Entidades.Telefono
        Dim objTipoTelefono As New Entidades.TipoTelefono

        If IsNumeric(grdTelefono.ActiveRow.Cells("Nombre").Value) Then
            objPersona.personaid = grdTelefono.ActiveRow.Cells("Nombre").Value
        Else
            objPersona.personaid = 0
        End If

        If IsNumeric(grdTelefono.ActiveRow.Cells("Cargo").Value) Then
            objClasificacion.clasificacionpersonaid = grdTelefono.ActiveRow.Cells("Cargo").Value
        Else
            objClasificacion.clasificacionpersonaid = 0
        End If

        If IsNumeric(grdTelefono.ActiveRow.Cells("Tipo").Value) Then
            objTipoTelefono.tipotelefonoid = grdTelefono.ActiveRow.Cells("Tipo").Value
        Else
            objTipoTelefono.tipotelefonoid = 0
        End If

        objTelefono.telefonoid = grdTelefono.ActiveRow.Cells("IdTelefono").Value
        objTelefono.telefono = ((((RTrim(LTrim(grdTelefono.ActiveRow.Cells("Teléfono").Text)).Replace("+", "")).Replace("-", "")).Replace("(", "")).Replace(")", "")).Replace(" ", "")
        objTelefono.extension = LTrim(RTrim(((grdTelefono.ActiveRow.Cells("Ext.").Text.Replace("ext", "").Replace("_", "")).Replace(".", "")).Replace(":", "")))
        objTelefono.tipotelefono = objTipoTelefono
        objTelefono.persona = objPersona
        objTelefono.clasificacionpersona = objClasificacion
        objTelefono.activo = grdTelefono.ActiveRow.Cells("Activo").Text
        objTelefono.whatsaap = grdTelefono.ActiveRow.Cells("WA").Text

        If grdTelefono.ActiveRow.Cells(0).Value = 0 Then
            ''AGREGAR NUEVO TELEFONO
            If Tools.Controles.Mensajes_Y_Alertas("CONFIRMACION", "¿Esta seguro de guardar el teléfono para el contacto seleccionado?") Then
                Try
                    If Validar_Registro_TelefonoContacto_Existente(objTelefono) = False Then
                        objBU.GuardarTelefonoContacto(objTelefono)
                        listaTelefonos()
                    End If
                Catch ex As Exception
                    Tools.Controles.Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado. Error: " + ex.Message)
                End Try
            End If
        Else
            ''ACTUALIZAR TELEFONO EXISTENTE
            If Tools.Controles.Mensajes_Y_Alertas("CONFIRMACION", "¿Esta seguro de actualizar el teléfono para el contacto seleccionado?") Then
                Try
                    If Validar_Registro_TelefonoContacto_Existente(objTelefono) = False Then
                        objBU.GuardarTelefonoContacto(objTelefono)
                        listaTelefonos()
                    End If
                Catch ex As Exception
                    Tools.Controles.Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado. Error: " + ex.Message)
                End Try
            Else
                listaTelefonos()
            End If
        End If
    End Sub

    Public Sub iniciarGrid()
        Dim dtGridTelefono As New DataTable
        With dtGridTelefono
            .Columns.Add("IdTelefono")
            .Columns.Add("Teléfono")
            .Columns.Add("Ext.")
            .Columns.Add("Tipo")
            .Columns.Add("Activo")
            .Columns.Add("Nombre")
            .Columns.Add("Cargo")
            .Columns.Add("Modificación")
            .Columns.Add("Usuario")

        End With
        grdTelefono.DataSource = dtGridTelefono
    End Sub

    Private Sub btnAgregarTelefono_Click(sender As Object, e As EventArgs) Handles btnAgregarTelefono.Click
        If grdTelefono.DataSource Is Nothing Then
            iniciarGrid()
        End If

        Dim dtCargos, dtContactos, dtTiposTelefonos As DataTable
        Dim grid As DataTable = grdTelefono.DataSource
        Dim vlCargo, vlTipoTelefono, vlContactos As New Infragistics.Win.ValueList
        ''Dim cargo As UltraGridColumn = grdTelefono.DisplayLayout.Bands(0).Columns("Cargo")
        Dim objbu As New Framework.Negocios.ContactosBU

        dtCargos = objbu.lista_Asignaciones_De_Contacto_Activas(IdClientePersonaId, IdPersona_Contacto)
        dtContactos = objbu.Lista_Contactos_Activos(IdClientePersonaId)
        dtTiposTelefonos = objbu.Lista_Tipo_Telefono_Activo()

        For Each row As DataRow In dtCargos.Rows
            vlCargo.ValueListItems.Add(row.Item("Id_Clasificacion"), row.Item("Tipo de Contacto"))
        Next
        For Each row As DataRow In dtContactos.Rows
            vlContactos.ValueListItems.Add(row.Item("Id"), row.Item("Nombre"))
        Next
        For Each row As DataRow In dtTiposTelefonos.Rows
            vlTipoTelefono.ValueListItems.Add(row.Item("Id"), row.Item("tite_nombre"))
        Next

        grdTelefono.DisplayLayout.Bands(0).Columns("Cargo").ValueList = vlCargo


        grdTelefono.DisplayLayout.Bands(0).Columns("Nombre").ValueList = vlContactos
        grdTelefono.DisplayLayout.Bands(0).Columns("Tipo").ValueList = vlTipoTelefono


        If dtCargos.Rows.Count = 1 Then
            grid.Rows.Add(0, "", "", 0, "--Selecciona--", 1, IdPersona_Contacto, dtCargos.Rows(0).Item(0))
        Else
            grid.Rows.Add(0, "", "", 0, "--Selecciona--", 1, IdPersona_Contacto, "--Selecciona--")
        End If


        grdTelefono.Focus()
        grdTelefono.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
        'grdTelefono.DisplayLayout.Rows(grid.Rows.Count - 1).Selected = True
        grdTelefono.ActiveRow.Activation = Activation.AllowEdit
        grdTelefono.PerformAction(UltraGridAction.ToggleCellSel, False, False)
        grdTelefono.PerformAction(UltraGridAction.EnterEditMode, False, False)


    End Sub

#End Region

#Region "CORREOS"

    Private Sub listaCorreosElectronicos()
        Dim objBU As New Framework.Negocios.ContactosBU
        Dim dtCorreos, dtCargos, dtContactos As New DataTable
        Dim vlCargo, vlContacto As New Infragistics.Win.ValueList
        Dim IdsPersonas_Contactos As String = RecuperarIdPersona()

        dtCorreos = objBU.ListaCorreosdeContacto(IdsPersonas_Contactos)

        grdCorreo.DataSource = dtCorreos

        If chkVerTodo.Checked = False Then
            dtCargos = objBU.lista_Asignaciones_De_Contacto_Activas(IdClientePersonaId, IdPersona_Contacto)
            dtContactos = objBU.Lista_Contactos_Activos(IdClientePersonaId)
            
            For Each row As DataRow In dtCargos.Rows
                vlCargo.ValueListItems.Add(row.Item("Id_Clasificacion"), row.Item("Tipo de Contacto"))
            Next
            For Each row In dtContactos.Rows
                vlContacto.ValueListItems.Add(row.Item("Id"), row.Item("Nombre"))
            Next

            grdCorreo.DisplayLayout.Bands(0).Columns("Nombre").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
            grdCorreo.DisplayLayout.Bands(0).Columns("Nombre").ValueList = vlContacto
            grdCorreo.DisplayLayout.Bands(0).Columns("Cargo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
            grdCorreo.DisplayLayout.Bands(0).Columns("Cargo").ValueList = vlCargo
            grdCorreo.DisplayLayout.Bands(0).Columns("Activo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

        End If
        

    End Sub

    Private Sub grdCorreo_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdCorreo.InitializeLayout
        Formato_Gral_Grids(grdCorreo)

        If Not IsNothing(grdCorreo.DataSource) Then
            With grdCorreo
                If chkVerTodo.Checked = True Then
                    .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                End If

                .DisplayLayout.Bands(0).Columns("Modificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .DisplayLayout.Bands(0).Columns("Usuario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .DisplayLayout.Bands(0).Columns("Id").Hidden = True
                .DisplayLayout.Bands(0).Columns("Activo").Width = 40
                .DisplayLayout.Bands(0).Columns("Correo Electrónico").Width = 270
                .DisplayLayout.Bands(0).Columns("Nombre").Width = 120
                .DisplayLayout.Bands(0).Columns("Cargo").Width = 120

                If gpbCorreoElectronico.Dock = DockStyle.Fill Then
                    .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                End If

                Dim ugFilter As New UltraGridFilterUIProvider
                .DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
                .DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
                .DisplayLayout.Override.FilterUIProvider = ugFilter
                .DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
                .DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.AboveOperand
                .DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
                .DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
                .DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

            End With
        End If
        

    End Sub

    Private Sub grdCorreo_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdCorreo.BeforeCellUpdate
        Try
            If e.Cell.Column.ToString = "Nombre" Then
                If grdCorreo.ActiveRow.Cells("Nombre").Value = grdCorreo.ActiveRow.Cells("Nombre").Text Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception

        End Try


        'If e.Cell.Column.ToString = "Cargo" Then
        '    If grdCorreo.ActiveRow.Cells("Cargo").Value = grdCorreo.ActiveRow.Cells("Cargo").Text Then
        '        e.Cancel = True
        '    End If
        'End If
    End Sub

    Private Sub grdCorreo_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdCorreo.AfterCellUpdate
        Dim dtListaCargosContacto As New DataTable
        Dim objBU As New Framework.Negocios.ContactosBU
        Dim vlCargos As New Infragistics.Win.ValueList

        If e.Cell.Column.ToString = "Nombre" Then
            dtListaCargosContacto = objBU.lista_Asignaciones_De_Contacto_Activas(IdClientePersonaId, grdCorreo.ActiveRow.Cells("Nombre").Value)

            For Each row As DataRow In dtListaCargosContacto.Rows
                vlCargos.ValueListItems.Add(row.Item("Id_Clasificacion"), row.Item("Tipo de Contacto"))
            Next

            grdCorreo.DisplayLayout.Bands(0).Columns("Cargo").ValueList = vlCargos

            If dtListaCargosContacto.Rows.Count > 1 Then
                grdCorreo.ActiveRow.Cells("Cargo").Value = "--Selecciona--"
            ElseIf dtListaCargosContacto.Rows.Count = 1 Then
                grdCorreo.ActiveRow.Cells("Cargo").Value = dtListaCargosContacto.Rows(0).Item(0)
            End If

        End If
    End Sub

    Private Sub grdCorreo_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles grdCorreo.BeforeRowUpdate
        If grdCorreo.ActiveRow.IsDataRow Then
            If grdCorreo.ActiveRow.DataChanged Then
                If grdCorreo.ActiveRow.Cells("Cargo").Value <> "--Selecciona--" Then
                    Alctualizar_Agregar_CorreoContacto()
                End If
            End If
        End If
    End Sub

    Private Sub Alctualizar_Agregar_CorreoContacto()
        Dim objBU As New Framework.Negocios.ContactosBU
        Dim objPersona As New Entidades.Persona
        Dim objClasificacion As New Entidades.ClasificacionPersona
        Dim objEmail As New Entidades.Email

        If IsNumeric(grdCorreo.ActiveRow.Cells("Nombre").Value) Then
            objPersona.personaid = grdCorreo.ActiveRow.Cells("Nombre").Value
        Else
            objPersona.personaid = 0
        End If
        If IsNumeric(grdCorreo.ActiveRow.Cells("Cargo").Value) Then
            objClasificacion.clasificacionpersonaid = grdCorreo.ActiveRow.Cells("Cargo").Value
        Else
            objClasificacion.clasificacionpersonaid = 0
        End If

        objEmail.emailpersonasid = grdCorreo.ActiveRow.Cells("Id").Value
        objEmail.activo = grdCorreo.ActiveRow.Cells("Activo").Text
        objEmail.persona = objPersona
        objEmail.clasificacionpersona = objClasificacion
        objEmail.email = grdCorreo.ActiveRow.Cells("Correo Electrónico").Text

        If grdCorreo.ActiveRow.Cells("Id").Value = 0 Then
            ''AGREGAR NUEVO TELEFONO
            If Tools.Controles.Mensajes_Y_Alertas("CONFIRMACION", "¿Esta seguro de guardar el Correo Electónico para el contacto seleccionado?") Then
                Try
                    If Validar_Registro_CorreoContacto_Existente(objEmail) = False Then
                        objBU.GuardarCorreoContacto(objEmail)
                    End If
                Catch ex As Exception
                    Tools.Controles.Mensajes_Y_Alertas("Error", "Ocurrio un error inesperado. Error: " + ex.Message)
                    listaCorreosElectronicos()
                End Try
            Else
                listaCorreosElectronicos()
            End If
        Else
            ''ACTUALIZAR TELEFONO EXISTENTE
            If Tools.Controles.Mensajes_Y_Alertas("CONFIRMACION", "¿Esta seguro de actualizar el Correo Electrónico para el contacto seleccionado?") Then
                Try
                    If Validar_Registro_CorreoContacto_Existente(objEmail) = False Then
                        objBU.ActualizarCorreoContacto(objEmail)
                    End If
                Catch ex As Exception
                    Tools.Controles.Mensajes_Y_Alertas("Error", "Ocurrio un error inesperado. Error: " + ex.Message)
                    listaCorreosElectronicos()
                End Try
            Else
                listaCorreosElectronicos()
            End If
        End If
    End Sub

    Private Sub grdCorreo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdCorreo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            grdCorreo.ActiveRow.Cells(1).Activated = True

            If ValidarCamposDelEMailVacios() Then
                Return
            End If

            Dim NextRowIndex As Integer = grdCorreo.ActiveRow.Index + 1
            Try
                grdCorreo.ActiveRow.Update()
                If NextRowIndex <= grdCorreo.Rows.Count - 1 Then
                    grdCorreo.DisplayLayout.Rows(NextRowIndex).Selected = True
                Else
                    grdCorreo.DisplayLayout.Rows(0).Selected = True
                End If
            Catch ex As Exception
                If Not IsNothing(grdCorreo.ActiveRow) Then
                    grdCorreo.ActiveRow.Activated = False
                End If
            End Try
        ElseIf e.KeyChar = ChrW(Keys.Escape) Then
            listaCorreosElectronicos()
        End If
    End Sub

    Private Function ValidarCamposDelEMailVacios() As Boolean
        ValidarCamposDelEMailVacios = False

        If RTrim(LTrim(grdCorreo.ActiveRow.Cells("Correo Electrónico").Text)) = "" Then
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Ingrese un Correo Electrónico ó presione ""ESCAPE"" para cancelar esta acción.")
            ValidarCamposDelEMailVacios = True

        ElseIf grdCorreo.ActiveRow.Cells("Nombre").Value = "--Selecciona--" Then
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione un contacto ó presione ""ESCAPE"" para cancelar esta acción.")
            ValidarCamposDelEMailVacios = True

        ElseIf grdCorreo.ActiveRow.Cells("Cargo").Value = "--Selecciona--" Then
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione un cargo ó presione ""ESCAPE"" para cancelar esta acción.")
            ValidarCamposDelEMailVacios = True
        ElseIf IsNumeric(grdCorreo.ActiveRow.Cells("Nombre").Value) = False Then
            If grdCorreo.ActiveRow.Cells("Nombre").Value <> grdCorreo.ActiveRow.Cells("Nombre").Text Then
                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione un el cargo para el contacto seleccionado ó ""ESCAPE"" para cancelar esta acción.")
                ValidarCamposDelEMailVacios = True
            End If
        End If

        Return ValidarCamposDelEMailVacios
    End Function

    Private Sub grdCorreo_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdCorreo.BeforeRowDeactivate
        If grdCorreo.ActiveRow.IsDataRow Then
            If ValidarCamposDelEMailVacios() = True Then
                e.Cancel = True
                Return
            End If
        End If
    End Sub

    Private Sub grdCorreo_Leave(sender As Object, e As EventArgs) Handles grdCorreo.Leave
        If Not IsNothing(grdCorreo.ActiveRow) Then
            If grdCorreo.ActiveRow.IsDataRow Then
                If ValidarCamposDelEMailVacios() = True Then
                    grdCorreo.Focus()
                    Return
                End If
            End If
        End If
    End Sub

    Public Sub iniciarGridCorreo()
        Dim dtCorreo As New DataTable

        With dtCorreo
            .Columns.Add("Id")
            .Columns.Add("Correo Electrónico")
            .Columns.Add("Activo")
            .Columns.Add("Nombre")
            .Columns.Add("Cargo")
            .Columns.Add("Modificación")
            .Columns.Add("Usuario")

        End With
        grdCorreo.DataSource = dtCorreo
    End Sub
    Private Sub btnAgregarEmail_Click(sender As Object, e As EventArgs) Handles btnAgregarEmail.Click
        Dim dtCargos, dtContactos As DataTable

        Dim vlCargo, vlContactos As New Infragistics.Win.ValueList
        Dim objbu As New Framework.Negocios.ContactosBU

        If grdCorreo.DataSource Is Nothing Then
            iniciarGridCorreo()
        End If
        Dim grid As DataTable = grdCorreo.DataSource
        dtCargos = objbu.lista_Asignaciones_De_Contacto_Activas(IdClientePersonaId, IdPersona_Contacto)
        dtContactos = objbu.Lista_Contactos_Activos(IdClientePersonaId)

        For Each row As DataRow In dtCargos.Rows
            vlCargo.ValueListItems.Add(row.Item("Id_Clasificacion"), row.Item("Tipo de Contacto"))
        Next
        For Each row As DataRow In dtContactos.Rows
            vlContactos.ValueListItems.Add(row.Item("Id"), row.Item("Nombre"))
        Next

        grdCorreo.DisplayLayout.Bands(0).Columns("Cargo").ValueList = vlCargo
        grdCorreo.DisplayLayout.Bands(0).Columns("Nombre").ValueList = vlContactos

        If dtCargos.Rows.Count = 1 Then
            grid.Rows.Add(0, "", 1, IdPersona_Contacto, dtCargos.Rows(0).Item(0))
        Else
            grid.Rows.Add(0, "", 1, IdPersona_Contacto, "--Selecciona--")
        End If


        grdCorreo.Focus()
        grdCorreo.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
        grdCorreo.ActiveRow.Activation = Activation.AllowEdit

        grdCorreo.PerformAction(UltraGridAction.ToggleCellSel, False, False)
        grdCorreo.PerformAction(UltraGridAction.EnterEditMode, False, False)
    End Sub


#End Region

    Private Sub Formato_Gral_Grids(ByVal grid As UltraGrid)
        With grid
            .DisplayLayout.Override.CellClickAction = CellClickAction.Edit
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 30
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.AutoFitStyle = AutoFitStyle.None
            .DisplayLayout.Bands(0).Columns("Activo").Style = ColumnStyle.CheckBox
            .DisplayLayout.Bands(0).Columns("Modificación").Style = ColumnStyle.DateTime
            .DisplayLayout.Bands(0).Columns("Modificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Modificación").Width = 150

        End With

    End Sub

    Private Function RecuperarIdPersona()
        Dim IdsPersonas_Contactos As String = String.Empty

        If chkVerTodo.Checked Then
            For Each row As UltraGridRow In grdReferenciasComerciales.Rows
                If IdsPersonas_Contactos = "" Then
                    IdsPersonas_Contactos = row.Cells(0).Text
                Else
                    IdsPersonas_Contactos += "," + row.Cells(0).Text
                End If
            Next
        Else
            If Not grdReferenciasComerciales.DataSource Is Nothing Then
                If Not IsDBNull(grdReferenciasComerciales.ActiveRow) AndAlso Not IsNothing(grdReferenciasComerciales.ActiveRow) Then
                    If grdReferenciasComerciales.ActiveRow.IsDataRow Then
                        IdsPersonas_Contactos = grdReferenciasComerciales.ActiveRow.Cells(0).Value
                    End If
                Else
                    IdsPersonas_Contactos = 0
                End If
            Else
                IdsPersonas_Contactos = 0
            End If
        End If

        Return IdsPersonas_Contactos
    End Function

    Private Sub chkVerTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerTodo.CheckedChanged
        lblCliente.Text = ""
        IdPersona_Contacto = 0
        btnAgregarCargos.Enabled = False
        btnAgregarTelefono.Enabled = False
        btnAgregarEmail.Enabled = False

        If chkVerTodo.Checked Then

            grdContactoSeleccionado.DataSource = Nothing
            listaTelefonos()
            listaCorreosElectronicos()
        Else
            grdCorreo.DataSource = Nothing
            grdTelefono.DataSource = Nothing
            grdContactoSeleccionado.DataSource = Nothing
        End If
    End Sub

#End Region

  
    Private Sub gpbContactosReferenciasComerciales_DoubleClick(sender As Object, e As EventArgs) Handles gpbContactosReferenciasComerciales.DoubleClick
        If gpbContactosReferenciasComerciales.Dock = DockStyle.Fill Then
            grdReferenciasComerciales.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            gpbContactosReferenciasComerciales.Dock = DockStyle.None
            gpbTelefonos.Visible = True
            gpbCargosContacto.Visible = True
            gpbCorreoElectronico.Visible = True
            With grdReferenciasComerciales
                .DisplayLayout.Bands(0).Columns("Nombre").Width = 200
                .DisplayLayout.Bands(0).Columns("Activo").Width = 40
                .DisplayLayout.Bands(0).Columns("Tipo de Contacto").Width = 200
                .DisplayLayout.Bands(0).Columns("Usuario").Width = 60
                .DisplayLayout.Bands(0).Columns("Modificación").Width = 60
            End With
        Else
            grdReferenciasComerciales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            gpbContactosReferenciasComerciales.Dock = DockStyle.Fill
            gpbTelefonos.Visible = False
            gpbCargosContacto.Visible = False
            gpbCorreoElectronico.Visible = False
        End If
    End Sub

    Private Sub gpbTelefonos_DoubleClick(sender As Object, e As EventArgs) Handles gpbTelefonos.DoubleClick
        If gpbTelefonos.Dock = DockStyle.Fill Then
            grdTelefono.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            gpbTelefonos.Dock = DockStyle.None
            gpbCargosContacto.Visible = True
            gpbCorreoElectronico.Visible = True
            gpbContactosReferenciasComerciales.Visible = True
            With grdTelefono
                .DisplayLayout.Bands(0).Columns("Activo").Width = 37
                .DisplayLayout.Bands(0).Columns("Ext.").Width = 60
                .DisplayLayout.Bands(0).Columns("Teléfono").Width = 110
                .DisplayLayout.Bands(0).Columns("Tipo").Width = 110
                .DisplayLayout.Bands(0).Columns("Nombre").Width = 125


            End With
        Else
            grdTelefono.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            gpbTelefonos.Dock = DockStyle.Fill
            gpbCargosContacto.Visible = False
            gpbCorreoElectronico.Visible = False
            gpbContactosReferenciasComerciales.Visible = False
        End If
    End Sub

    Private Sub gpbCargosContacto_DoubleClick(sender As Object, e As EventArgs) Handles gpbCargosContacto.DoubleClick
        If gpbCargosContacto.Dock = DockStyle.Fill Then
            grdContactoSeleccionado.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            gpbCargosContacto.Dock = DockStyle.None
            gpbTelefonos.Visible = True
            gpbCorreoElectronico.Visible = True
            gpbContactosReferenciasComerciales.Visible = True
            With grdContactoSeleccionado
                .DisplayLayout.Bands(0).Columns("Activo").Width = 40
                .DisplayLayout.Bands(0).Columns("Nombre").Width = 200
                .DisplayLayout.Bands(0).Columns("Cargos").Width = 200
            End With
        Else
            grdContactoSeleccionado.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            gpbCargosContacto.Dock = DockStyle.Fill
            gpbTelefonos.Visible = False
            gpbCorreoElectronico.Visible = False
            gpbContactosReferenciasComerciales.Visible = False
        End If
    End Sub

    Private Sub gpbCorreoElectronico_DoubleClick(sender As Object, e As EventArgs) Handles gpbCorreoElectronico.DoubleClick
        If gpbCorreoElectronico.Dock = DockStyle.Fill Then
            grdCorreo.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            gpbCorreoElectronico.Dock = DockStyle.None
            gpbTelefonos.Visible = True
            gpbCargosContacto.Visible = True
            gpbContactosReferenciasComerciales.Visible = True

            With grdCorreo
                .DisplayLayout.Bands(0).Columns("Activo").Width = 40
                .DisplayLayout.Bands(0).Columns("Correo Electrónico").Width = 270
                .DisplayLayout.Bands(0).Columns("Nombre").Width = 120
                .DisplayLayout.Bands(0).Columns("Cargo").Width = 120
            End With
        Else
            grdCorreo.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            gpbCorreoElectronico.Dock = DockStyle.Fill
            gpbTelefonos.Visible = False
            gpbCargosContacto.Visible = False
            gpbContactosReferenciasComerciales.Visible = False
        End If
    End Sub

    Private Function Validar_Registro_TelefonoContacto_Existente(ByVal Telefono As Entidades.Telefono) As Boolean
        Dim objBU As New Framework.Negocios.ContactosBU
        Dim objTelefonoActual As New Entidades.Telefono
        Dim dtTablaRegistrosExistentes, dtTablaTelefonoActualizar As New DataTable

        Validar_Registro_TelefonoContacto_Existente = False

        ''INDICA QUE EL SE PRETENDE REGISTRAR UN TELEFONO TELEFONO NUEVO
        If Telefono.telefonoid = 0 Then
            dtTablaRegistrosExistentes = objBU.RecuperarRegistroExistente_Telefono(Telefono, False)
        Else
            '' INDICA QUE SE PRETENDE EDITAR UN TELEFONO EXISTENTE
            dtTablaTelefonoActualizar = objBU.RecuperarRegistroExistente_Telefono(Telefono, True)
            If Telefono.persona.personaid = 0 Then
                Telefono.persona.personaid = dtTablaTelefonoActualizar.Rows(0).Item("tele_personaid")
            End If
            If Telefono.tipotelefono.tipotelefonoid = 0 Then
                Telefono.tipotelefono.tipotelefonoid = dtTablaTelefonoActualizar.Rows(0).Item("tele_tipotelefonoid")
            End If
            If Telefono.clasificacionpersona.clasificacionpersonaid = 0 Then
                Telefono.clasificacionpersona.clasificacionpersonaid = dtTablaTelefonoActualizar.Rows(0).Item("tele_clasificacionpersonaid")
            End If

            dtTablaRegistrosExistentes = objBU.RecuperarRegistroExistente_Telefono(Telefono, False)
        End If

        If dtTablaRegistrosExistentes.Rows.Count > 0 Then
            Validar_Registro_TelefonoContacto_Existente = True

            If dtTablaRegistrosExistentes.Rows(0).Item("tele_activo") = False Then
                Dim objTelefono As New Entidades.Telefono
                Dim objPersona As New Entidades.Persona
                Dim objTipoTelefono As New Entidades.TipoTelefono
                Dim objClasificacionPersona As New Entidades.ClasificacionPersona

                objTelefono.telefonoid = dtTablaRegistrosExistentes.Rows(0).Item("tele_telefonoid")
                objTelefono.telefono = dtTablaRegistrosExistentes.Rows(0).Item("Telefono")
                objTelefono.extension = dtTablaRegistrosExistentes.Rows(0).Item("tele_extension")
                objTipoTelefono.tipotelefonoid = dtTablaRegistrosExistentes.Rows(0).Item("tele_tipotelefonoid")
                objTelefono.tipotelefono = objTipoTelefono

                objPersona.personaid = dtTablaRegistrosExistentes.Rows(0).Item("tele_personaid")
                objTelefono.persona = objPersona

                objClasificacionPersona.clasificacionpersonaid = dtTablaRegistrosExistentes.Rows(0).Item("tele_clasificacionpersonaid")
                objTelefono.clasificacionpersona = objClasificacionPersona
                objTelefono.activo = True
                objTelefono.whatsaap = dtTablaRegistrosExistentes.Rows(0).Item("tele_whatsapp")

                objBU.GuardarTelefonoContacto(objTelefono)

                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "El teléfono capturado ya existe, Se activó y actualizó el registro.")
            Else
                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "El teléfono capturado ya existe.")
            End If
            listaTelefonos()
        End If

        Return Validar_Registro_TelefonoContacto_Existente
    End Function

    Private Function Validar_Registro_CorreoContacto_Existente(ByVal EMail As Entidades.Email) As Boolean
        Validar_Registro_CorreoContacto_Existente = False

        Dim objBU As New Framework.Negocios.ContactosBU
        Dim objCorreoActual As New Entidades.Telefono
        Dim dtTablaRegistrosExistentes, dtTablaCorreoActualizar As New DataTable


        ''INDICA QUE EL SE PRETENDE REGISTRAR UN EMAIL NUEVO
        If EMail.emailpersonasid = 0 Then
            dtTablaRegistrosExistentes = objBU.RecuperarRegistroExistente_Correo(EMail, False)
        Else
            '' INDICA QUE SE PRETENDE EDITAR UN EMAIL EXISTENTE
            dtTablaCorreoActualizar = objBU.RecuperarRegistroExistente_Correo(EMail, True)
            If EMail.persona.personaid = 0 Then
                EMail.persona.personaid = dtTablaCorreoActualizar.Rows(0).Item("empe_personaid")
            End If

            If EMail.clasificacionpersona.clasificacionpersonaid = 0 Then
                EMail.clasificacionpersona.clasificacionpersonaid = dtTablaCorreoActualizar.Rows(0).Item("empe_clasificacionpersonaid")
            End If

            dtTablaRegistrosExistentes = objBU.RecuperarRegistroExistente_Correo(EMail, False)
        End If

        If dtTablaRegistrosExistentes.Rows.Count > 0 Then
            Validar_Registro_CorreoContacto_Existente = True

            If dtTablaRegistrosExistentes.Rows(0).Item("empe_activo") = False Then
                Dim objCorreo As New Entidades.Email
                Dim objPersona As New Entidades.Persona
                Dim objClasificacionPersona As New Entidades.ClasificacionPersona

                objCorreo.emailpersonasid = dtTablaRegistrosExistentes.Rows(0).Item("empe_emailpersonasid")
                objCorreo.email = dtTablaRegistrosExistentes.Rows(0).Item("empe_email")

                objPersona.personaid = dtTablaRegistrosExistentes.Rows(0).Item("empe_personaid")
                objCorreo.persona = objPersona
                objClasificacionPersona.clasificacionpersonaid = dtTablaRegistrosExistentes.Rows(0).Item("empe_clasificacionpersonaid")
                objCorreo.clasificacionpersona = objClasificacionPersona
                objCorreo.activo = True

                objBU.ActualizarCorreoContacto(objCorreo)

                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "El correo electrónico capturado ya existe, Se activó y actualizó el registro.")

            Else
                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "El correo electrónico capturado ya existe para la persona y el cargo asignado.")
            End If

            listaCorreosElectronicos()
        End If

        Return Validar_Registro_CorreoContacto_Existente
    End Function

    Private Function Validar_Registro_AsignacionContacto_Existente(ByVal Relacion As Entidades.RelacionesPersonas) As Boolean

        Validar_Registro_AsignacionContacto_Existente = False

        Dim objBU As New Framework.Negocios.ContactosBU
        Dim objRelacionesPersonas As New Entidades.RelacionesPersonas
        Dim dtTablaRegistrosExistentes, dtTablaPersonaActualizar As New DataTable


        ''INDICA QUE EL SE PRETENDE REGISTRAR UN EMAIL NUEVO
        If Relacion.PrelacionPersonaId = 0 Then
            dtTablaRegistrosExistentes = objBU.RecuperarRegistroExistente_Asignacion(Relacion, False)
        Else
            '' INDICA QUE SE PRETENDE EDITAR UN EMAIL EXISTENTE
            dtTablaPersonaActualizar = objBU.RecuperarRegistroExistente_Asignacion(Relacion, True)
            If Relacion.PPersonaId = 0 Then
                Relacion.PPersonaId = dtTablaPersonaActualizar.Rows(0).Item("repe_personaid1")
            End If

            If Relacion.PCLasificacionPersona1 = 0 Then
                Relacion.PCLasificacionPersona1 = dtTablaPersonaActualizar.Rows(0).Item("repe_clasificacionpersonaid1")
            End If

            dtTablaRegistrosExistentes = objBU.RecuperarRegistroExistente_Asignacion(Relacion, False)
        End If

        If dtTablaRegistrosExistentes.Rows.Count > 0 Then
            Validar_Registro_AsignacionContacto_Existente = True

            If dtTablaRegistrosExistentes.Rows(0).Item("repe_activo") = False Then
                objRelacionesPersonas.PrelacionPersonaId = dtTablaRegistrosExistentes.Rows(0).Item("repe_relacionespersonaid")
                objRelacionesPersonas.PPersonaId = dtTablaRegistrosExistentes.Rows(0).Item("repe_personaid1")
                objRelacionesPersonas.PCLasificacionPersona1 = dtTablaRegistrosExistentes.Rows(0).Item("repe_clasificacionpersonaid1")
                objRelacionesPersonas.PPersona2_Id = dtTablaRegistrosExistentes.Rows(0).Item("repe_persona2")
                objRelacionesPersonas.PClasificacionPersona2 = dtTablaRegistrosExistentes.Rows(0).Item("repe_clasificacionpersona2")
                objRelacionesPersonas.PActivo = True

                objBU.ActualizarCargoContacto(objRelacionesPersonas.PrelacionPersonaId, True)

                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "El correo electrónico capturado ya existe, Se activó y actualizó el registro.")

            Else
                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "El correo electrónico capturado ya existe para la persona y el cargo asignado.")
            End If

            listaCargosDelContacto(grdReferenciasComerciales.ActiveRow.Cells("Id").Value)
        End If

        Return Validar_Registro_AsignacionContacto_Existente
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

End Class