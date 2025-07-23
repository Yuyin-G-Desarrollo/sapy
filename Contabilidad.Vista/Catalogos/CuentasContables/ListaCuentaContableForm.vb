Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing
Imports Tools

Public Class ListaCuentaContableForm

    Private Sub ListaCuentaContableForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        lista_Empresas_SaySicyContpaq()
        lista_TipoCuentaContable()

    End Sub

    ''' <summary>
    ''' ASIGNA LAS EMPRESAS DADAS DE ALTA EN LA BASE DE DATOS DEL SAY(EMPRESA SAY-SICY-CONTPAQ) ASIGNANDO COMO VALOR EL ID DE LA EMPRESA Y EL TEXTO A MOSTRAR LA RAZON SOCIAL
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub lista_Empresas_SaySicyContpaq()
        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_Empresas_Say_Sicy_Contpaq
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cboxRazonSocial.DataSource = tabla
        cboxRazonSocial.DisplayMember = "essc_razonsocial"
        cboxRazonSocial.ValueMember = "essc_empresaid"
    End Sub

    Private Sub lista_TipoCuentaContable()

        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_TipoCuentaContable
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cboxTipoCuenta.DataSource = tabla
        cboxTipoCuenta.ValueMember = "ticc_tipocuentacontabilidadid"
        cboxTipoCuenta.DisplayMember = "ticc_nombre"
    End Sub

    Public Sub poblar_gridListaCuentaContable()

        Dim objBU As New Negocios.CuentasContablesBU
        gridListaCuentaContable.DataSource = Nothing
        Dim empresaID As String = String.Empty
        Dim tipoCuentaID As String = String.Empty
        Dim proveedorID As String = String.Empty
        Dim clienteID As String = String.Empty
        Dim ClienteProveedor As Boolean

        If Not IsDBNull(cboxRazonSocial.SelectedValue) Then
            empresaID = CStr(cboxRazonSocial.SelectedValue)
        End If

        If Not IsDBNull(cboxTipoCuenta.SelectedValue) Then
            tipoCuentaID = CStr(cboxTipoCuenta.SelectedValue)
        End If

        If cboxProveedor.SelectedValue Then
            proveedorID = CStr(cboxProveedor.SelectedValue)
        Else
            proveedorID = ""
        End If

        If cboxCliente.SelectedValue Then
            clienteID = CStr(cboxCliente.SelectedValue)
        Else
            clienteID = ""
        End If

        If cboxTipoCuenta.SelectedIndex <= 0 Then
            ClienteProveedor = True
        ElseIf cboxTipoCuenta.Text = "CLIENTES" Or cboxTipoCuenta.Text = "PROVEEDORES" Then
            ClienteProveedor = True
        Else
            ClienteProveedor = False
        End If

        gridListaCuentaContable.DataSource = objBU.Consulta_lista_Cuentas_Contables(empresaID, tipoCuentaID, proveedorID, clienteID, ClienteProveedor)

        gridListaCuentaContableDiseno(gridListaCuentaContable)

    End Sub

    Private Sub gridListaCuentaContableDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        With grid.DisplayLayout
            .Bands(0).Columns("Empresa ID").Hidden = True
            .Bands(0).Columns("Empresa").FilterOperandStyle = FilterOperandStyle.Combo
            .Bands(0).Columns("Cuenta ID").Hidden = True
            .Bands(0).Columns("Cuenta").FilterOperandStyle = FilterOperandStyle.Combo
            .Bands(0).Columns("Tipo Cuenta ID").Hidden = True
            .Bands(0).Columns("Tipo Cuenta").FilterOperandStyle = FilterOperandStyle.Combo
            .Bands(0).Columns("Proveedor ID").Hidden = True
            .Bands(0).Columns("Cliente ID").Hidden = True
            If cboxTipoCuenta.SelectedIndex > 0 Then
                If cboxTipoCuenta.Text = "CLIENTES" Then
                    .Bands(0).Columns("Cliente").FilterOperandStyle = FilterOperandStyle.Combo
                    .Bands(0).Columns("Proveedor").Hidden = True
                ElseIf cboxTipoCuenta.Text = "PROVEEDORES" Then
                    .Bands(0).Columns("Proveedor").FilterOperandStyle = FilterOperandStyle.Combo
                    .Bands(0).Columns("Cliente").Hidden = True
                End If
            End If


            .Bands(0).Columns("Constante_1").Hidden = True
            .Bands(0).Columns("Constante_2").Hidden = True
            .Bands(0).Columns("Letra").Hidden = True
            .Bands(0).Columns("Consecutivo").Hidden = True
            .Bands(0).Columns("Id_Cuenta_Contpaq").Hidden = True
            .Bands(0).Columns("Id_Cuenta_Sicy").Hidden = True
            .Bands(0).Columns("Status").Hidden = True

            .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectors = DefaultableBoolean.True
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.FilterUIType = FilterUIType.FilterRow
            .Override.AllowAddNew = AllowAddNew.No
        End With

        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

    End Sub

    Private Sub gridListaCuentaContable_KeyPress(sender As Object, e As KeyPressEventArgs)

        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim NextRowIndex As Integer = gridListaCuentaContable.ActiveRow.Index + 1
            Try
                gridListaCuentaContable.DisplayLayout.Rows(NextRowIndex).Activated = True
                gridListaCuentaContable.DisplayLayout.Rows(NextRowIndex).Selected = True
            Catch ex As Exception
                gridListaCuentaContable.ActiveRow.Activated = False
            End Try
        End If

        If e.KeyChar = ChrW(Keys.Escape) Then
            poblar_gridListaCuentaContable()
            gridListaCuentaContable.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        End If

    End Sub

    Private Sub gridListaCuentaContable_MouseClick(sender As Object, e As MouseEventArgs)

        Dim mainElement As UIElement
        Dim element As UIElement
        Dim screenPoint As Point
        Dim clientPoint As Point
        Dim row As UltraGridRow
        Dim cell As UltraGridCell

        mainElement = Me.gridListaCuentaContable.DisplayLayout.UIElement
        screenPoint = Control.MousePosition
        clientPoint = Me.gridListaCuentaContable.PointToClient(screenPoint)
        element = mainElement.ElementFromPoint(clientPoint)

        If element Is Nothing Then Return

        row = element.GetContext(GetType(UltraGridRow))

        If Not row Is Nothing Then
            cell = element.GetContext(GetType(UltraGridCell))

            If Not cell Is Nothing Then

                'If e.Button <> Windows.Forms.MouseButtons.Right Then Return
                'Dim cms = New ContextMenuStrip
                'Dim item1 = cms.Items.Add("Nuevo")
                'item1.Tag = 1
                'AddHandler item1.Click, AddressOf gridListaCuentaContable_menuChoice

                'Dim item2 = cms.Items.Add("Editar")
                'item2.Tag = 2
                'AddHandler item2.Click, AddressOf gridListaCuentaContable_menuChoice
                'cms.Show(Control.MousePosition)

            End If
        End If

    End Sub

    Private Sub gridListaCuentaContable_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)

        If selection = 1 Then ''AGREGAR NUEVO HORARIO

            Dim grid As DataTable = gridListaCuentaContable.DataSource
            Dim row As UltraGridRow = gridListaCuentaContable.ActiveRow

            If Not IsNothing(row) Then

                grid.Rows.Add(0, "", False)

                gridListaCuentaContable.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
                Try
                    gridListaCuentaContable.ActiveRow.Activation = Activation.AllowEdit
                    gridListaCuentaContable.ActiveCell = gridListaCuentaContable.ActiveRow.Cells(1)
                    gridListaCuentaContable.ActiveCell.Activation = Activation.AllowEdit
                Catch ex As Exception

                End Try

                gridListaCuentaContable.PerformAction(UltraGridAction.ToggleCellSel, False, False)
                gridListaCuentaContable.PerformAction(UltraGridAction.EnterEditMode, False, False)

            End If

        End If

        If selection = 2 Then ''EDITAR

            For Each row In gridListaCuentaContable.Selected.Rows
                Dim i As Integer = gridListaCuentaContable.Rows.Count

                gridListaCuentaContable.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
                gridListaCuentaContable.DisplayLayout.Override.CellClickAction = CellClickAction.Edit

            Next

        End If

    End Sub

    Private Sub gridListaCuentaContable_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs)
        'Dim cellIndex As Integer = gridListaCuentaContable.ActiveCell.Column.Index

        'If Not gridListaCuentaContable.ActiveRow.DataChanged Then
        '    If gridListaCuentaContable.ActiveCell.DataChanged Then
        '    Else
        '        If String.IsNullOrWhiteSpace(gridListaCuentaContable.ActiveCell.Value) Then
        '            poblar_gridListaCuentaContable()
        '            gridListaCuentaContable.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        '        End If
        '    End If
        'End If

    End Sub

    Private Sub gridListaCuentaContable_AfterRowActivate(sender As Object, e As EventArgs)
        gridListaCuentaContable.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        For Each row In gridListaCuentaContable.Rows
            row.Activation = Activation.NoEdit
        Next
    End Sub

    Private Sub gridListaCuentaContable_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs)

        If gridListaCuentaContable.ActiveRow.DataChanged Then
            Dim tipoPoliza As New Entidades.TipoPoliza
            Dim objBU As New Negocios.TipoPolizasBU
            Dim row As UltraGridRow = gridListaCuentaContable.ActiveRow

            tipoPoliza.polizatipoid = gridListaCuentaContable.ActiveRow.Cells(0).Value
            tipoPoliza.nombre = CStr(gridListaCuentaContable.ActiveRow.Cells(1).Value)
            tipoPoliza.status = CBool(gridListaCuentaContable.ActiveRow.Cells(2).Value)

            objBU.alta_edicion_tipo_poliza(tipoPoliza)

            poblar_gridListaCuentaContable()

        End If

        gridListaCuentaContable.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

    End Sub

    Public Sub exportarExcel(ByVal grd As UltraGrid)
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim ruta As String = String.Empty
        Dim nombreDocumento As String = "\CUENTAS CONTABLES_"
        Dim exito As New ExitoForm

        If IsNothing(grd) = False Then
            With fbdUbicacionArchivo
                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog

                If ret = Windows.Forms.DialogResult.OK Then
                    Dim fecha_hora As String = "_" + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                    ruta = .SelectedPath + nombreDocumento + cboxTipoCuenta.Text + "_" + cboxRazonSocial.Text.Trim + fecha_hora + ".xlsx"

                    UltraGridExcelExporter1.Export(grd, ruta)

                    exito.mensaje = "Los datos se exportaron correctamente"
                    exito.ShowDialog()
                    Process.Start(ruta)
                    .Dispose()
                End If
            End With
        End If
    End Sub


#Region "ACCIONES BOTÓNES"

    Private Sub btnProveedor_Click(sender As Object, e As EventArgs) Handles btnProveedor.Click
        Dim listado As New ListadoParametrosBusquedaForm
        listado.tipo_busqueda = 1

        Dim listaParametroID As New List(Of String)
        Dim parametro As String
        If IsNothing(cboxProveedor.SelectedValue) Then
            parametro = String.Empty
        Else
            parametro = cboxProveedor.SelectedValue.ToString
        End If
        listaParametroID.Add(parametro)
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)

        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return

        If listado.listParametros.Rows.Count = 0 Then Return

        cboxProveedor.DataSource = listado.listParametros
        cboxProveedor.ValueMember = "Parámetro"
        cboxProveedor.DisplayMember = "Proveedor"
        cboxProveedor.SelectedValue = CInt(listado.listParametros.Rows(0).Item("Parámetro"))

    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosBusquedaForm
        Dim listaParametroID As New List(Of String)
        Dim parametro As String

        listado.tipo_busqueda = 2

        If IsNothing(cboxCliente.SelectedValue) Then
            parametro = String.Empty
        Else
            parametro = cboxCliente.SelectedValue.ToString
        End If
        listaParametroID.Add(parametro)
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)

        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return

        If listado.listParametros.Rows.Count = 0 Then Return

        cboxCliente.DataSource = listado.listParametros
        cboxCliente.ValueMember = "Parámetro"
        cboxCliente.DisplayMember = "Cliente"
        cboxCliente.SelectedValue = CInt(listado.listParametros.Rows(0).Item("Parámetro"))
    End Sub


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        gridListaCuentaContable.DataSource = Nothing
        cboxRazonSocial.SelectedValue = 0
        cboxTipoCuenta.SelectedValue = 0
        If cboxProveedor.Items.Count > 0 Then
            cboxProveedor.SelectedValue = 0
        End If
        If cboxCliente.Items.Count > 0 Then
            cboxCliente.SelectedValue = 0
        End If

    End Sub

    Private Sub btnMostrar_Click_1(sender As Object, e As EventArgs) Handles btnMostrar.Click
        poblar_gridListaCuentaContable()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim form As New AltaEditarCuentaContableForm
        form.StartPosition = FormStartPosition.CenterScreen
        form.ShowDialog()
        form.Alta_Edicion = True
        btnMostrar.PerformClick()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros.Height = 30
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros.Height = 119
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim form As New AltaEditarCuentaContableForm
        form.StartPosition = FormStartPosition.CenterScreen
        Dim objCuentaContable As New Entidades.CuentaContable
        Dim objAdvertencia As New Tools.AdvertenciaForm

        If gridListaCuentaContable.Selected.Rows.Count = 0 Then
            objAdvertencia.mensaje = "Selecciona un registro para poder editar."
        ElseIf gridListaCuentaContable.Selected.Rows.Count > 1 Then
            objAdvertencia.mensaje = "Seleccione solo un registro para poder editar."
        Else
            form.Alta_Edicion = False

            objCuentaContable.PIdCuentaContable = gridListaCuentaContable.Selected.Rows(0).Cells("Cuenta ID").Value
            objCuentaContable.PConstante1 = gridListaCuentaContable.Selected.Rows(0).Cells("Constante_1").Value
            objCuentaContable.PConstante2 = gridListaCuentaContable.Selected.Rows(0).Cells("Constante_2").Value
            objCuentaContable.PLetra = gridListaCuentaContable.Selected.Rows(0).Cells("Letra").Value
            objCuentaContable.PConsecutivo = gridListaCuentaContable.Selected.Rows(0).Cells("Consecutivo").Value
            objCuentaContable.PDescripcion = gridListaCuentaContable.Selected.Rows(0).Cells("Descripción").Value
            objCuentaContable.PIdTipoCuenta = gridListaCuentaContable.Selected.Rows(0).Cells("Tipo Cuenta ID").Value
            objCuentaContable.PIDCuentaContableContpaq = gridListaCuentaContable.Selected.Rows(0).Cells("Id_Cuenta_Contpaq").Value
            If Not IsDBNull(gridListaCuentaContable.Selected.Rows(0).Cells("Cliente ID").Value) Then
                objCuentaContable.PIdCliente = gridListaCuentaContable.Selected.Rows(0).Cells("Cliente ID").Value
            Else
                objCuentaContable.PIdCliente = 0
            End If
            If Not IsDBNull(gridListaCuentaContable.Selected.Rows(0).Cells("Proveedor ID").Value) Then
                objCuentaContable.PIdProveedor = gridListaCuentaContable.Selected.Rows(0).Cells("Proveedor ID").Value
            Else
                objCuentaContable.PIdProveedor = 0
            End If

            If Not IsDBNull(gridListaCuentaContable.Selected.Rows(0).Cells("Id_Cuenta_Sicy").Value) Then
                objCuentaContable.PIdCuentaContableSicy = gridListaCuentaContable.Selected.Rows(0).Cells("Id_Cuenta_Sicy").Value
            Else
                objCuentaContable.PIdCuentaContableSicy = 0
            End If

            objCuentaContable.PIdEmpresa = gridListaCuentaContable.Selected.Rows(0).Cells("Empresa ID").Value
            objCuentaContable.PStatus = gridListaCuentaContable.Selected.Rows(0).Cells("Status").Value

            form.objCuentaContable = objCuentaContable
            form.ShowDialog()
        End If


        btnMostrar.PerformClick()
    End Sub
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If gridListaCuentaContable.Rows.Count > 0 Then
            exportarExcel(gridListaCuentaContable)
        End If
    End Sub

#End Region

    Private Sub cboxTipoCuenta_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboxTipoCuenta.SelectionChangeCommitted
        Dim lsNada As New List(Of String)

        If cboxTipoCuenta.SelectedIndex <= 0 Then
            pnlCliente.Visible = True
            pnlProveedor.Visible = True
            cboxCliente.DataSource = Nothing
            cboxProveedor.DataSource = Nothing
        Else
            If cboxTipoCuenta.Text = "CLIENTES" Then
                pnlCliente.Visible = True
                pnlProveedor.Visible = False
                cboxProveedor.DataSource = lsNada
            ElseIf cboxTipoCuenta.Text = "PROVEEDORES" Then
                pnlCliente.Visible = False
                pnlProveedor.Visible = True
                cboxCliente.DataSource = lsNada
            Else
                pnlCliente.Visible = False
                pnlProveedor.Visible = False
                cboxCliente.DataSource = lsNada
                cboxProveedor.DataSource = lsNada
            End If
        End If
    End Sub

End Class