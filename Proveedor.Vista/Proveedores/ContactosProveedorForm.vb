Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Drawing

Public Class ContactosProveedorForm

    Public ProveedorId As Integer = -1
    Public NombreProveedor As String = String.Empty
    Dim ContactoId As Integer = -1

    Private Sub ContactosProveedorForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtProveedor.Text = NombreProveedor
        btnEditar.Enabled = False
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        CargarContactosProveedor()
    End Sub

    Private Sub CargarContactosProveedor()
        Dim objProveedor As New Proveedores.BU.ProveedorBU
        grdContactosProveedor.DataSource = Nothing
        gridDiseno(grdContactosProveedor)
        grdContactosProveedor.DataSource = objProveedor.ConsultarContactosProveedor(ProveedorId, rdoActivo.Checked)
    End Sub

    Private Sub gridDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        '        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns


        AgregarColumna(grid, "daco_datoscontactoid", "daco_datoscontactoid", True, False, Nothing, 100, , , HAlign.Right)
        AgregarColumna(grid, "NombreCompleto", "NOMBRE", False, True, Nothing, 100)       
        AgregarColumna(grid, "daco_telefono", "TELEFONO", False, True, Nothing, 100, , , HAlign.Right)
        AgregarColumna(grid, "daco_cargo", "CARGO", False, True, Nothing, 100)
        AgregarColumna(grid, "daco_email", "EMAIL", False, True, Nothing, 100)
        AgregarColumna(grid, "daco_tipocontacto", "TIPO CONTACTO", False, True, Nothing, 100)
        AgregarColumna(grid, "daco_proveedorid", "daco_proveedorid", True, True, Nothing, 100)
        AgregarColumna(grid, "daco_usuariocreoid", "daco_usuariocreoid", True, True, Nothing, 100)
        AgregarColumna(grid, "daco_foto", "daco_foto", True, True, Nothing, 100)
        AgregarColumna(grid, "daco_firma", "daco_firma", True, True, Nothing, 100)
        AgregarColumna(grid, "daco_activo", "daco_activo", True, True, Nothing, 100)
        AgregarColumna(grid, "daco_usuariomodificoid", "daco_usuariomodificoid", True, True, Nothing, 100)
        AgregarColumna(grid, "daco_fechamodificacion", "daco_fechamodificacion", True, True, Nothing, 100)
        AgregarColumna(grid, "daco_nombre", "daco_nombre", True, True, Nothing, 100)
        AgregarColumna(grid, "daco_apaterno", "daco_apaterno", True, True, Nothing, 100)
        AgregarColumna(grid, "daco_amaterno", "daco_amaterno", True, True, Nothing, 100)

    End Sub

    Private Sub AgregarColumna(ByRef grid As UltraGrid, ByVal Key As String, ByVal NombreColumna As String, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, ByVal ColorColumna As Color, Optional ByVal Width As Integer = -1, Optional ByVal SumarizarColumna As Boolean = False, Optional ByVal Edicion As Boolean = False, Optional ByVal Alineacion As HAlign = Nothing, Optional ByVal NEgrita As Boolean = False, Optional ByVal EsPorcentaje As Boolean = False, Optional ByVal Tooltip As String = "")
        With grid
            .DisplayLayout.Bands(0).Columns.Add(Key, NombreColumna)
            FormatoColumna(.DisplayLayout.Bands(0).Columns(Key), Ocultar, EsCadena, Width, EsPorcentaje)
            If IsNothing(ColorColumna) Then
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = Color.Black
            Else
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = ColorColumna
            End If
            If SumarizarColumna = True Then
                SumarizarColumnaGrid(grid, Key, "Sumarizar " + Key)
            End If
            If Tooltip <> "" Then
                grid.DisplayLayout.Bands(0).Columns(Key).Header.ToolTipText = Tooltip
            End If

            'If Alineacion <> HAlign.Default Then
            '    .DisplayLayout.Bands(0).Columns(Key).CellAppearance.TextHAlign = Alineacion
            'End If

            If IsNothing(Alineacion) = False Then
                .DisplayLayout.Bands(0).Columns(Key).CellAppearance.TextHAlign = Alineacion
            End If
            If NEgrita = True Then
                .DisplayLayout.Bands(0).Columns(Key).CellAppearance.FontData.Bold = DefaultableBoolean.True
            End If


            If Edicion = True Then
                .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.AllowEdit
            Else
                .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.NoEdit
            End If

        End With
    End Sub

    Private Sub FormatoColumna(ByRef columna As UltraGridColumn, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, Optional ByVal Width As Integer = -1, Optional ByVal EsPorcentaje As Boolean = False)
        Dim FormatoNumero As String = "###,###,##0"
        Dim FormatoPorcentaje As String = "##0%"
        columna.Hidden = Ocultar
        If EsCadena = True Then
            columna.CellAppearance.TextHAlign = HAlign.Left
        Else

            If EsPorcentaje = True Then
                columna.Format = FormatoPorcentaje
                columna.CellAppearance.TextHAlign = HAlign.Right
            Else
                columna.Format = FormatoNumero
                columna.CellAppearance.TextHAlign = HAlign.Right
            End If

        End If

        If Width <> -1 Then
            columna.Width = Width
        End If
    End Sub

    Private Sub SumarizarColumnaGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal NombreColumna As String, ByVal Key As String)
        Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns(NombreColumna)
        Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add(Key, SummaryType.Sum, columnToSummarize)
        summary.DisplayFormat = "{0:###,###,##0}"
        summary.Appearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
    End Sub



    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim FormAltaContacto As New AltaContactoProveedorForm
        FormAltaContacto.ProveedorId = ProveedorId
        FormAltaContacto.NombreProveedor = NombreProveedor
        FormAltaContacto.ContactoID = -1
        FormAltaContacto.ShowDialog()
        CargarContactosProveedor()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim FormAltaContacto As New AltaContactoProveedorForm
        FormAltaContacto.ProveedorId = ProveedorId
        FormAltaContacto.NombreProveedor = NombreProveedor
        FormAltaContacto.ContactoID = ContactoId
        FormAltaContacto.ShowDialog()
        CargarContactosProveedor()
    End Sub


    Private Sub grdContactosProveedor_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdContactosProveedor.ClickCell

        Dim TotalFiniquito As Double = 0
        Dim row As UltraGridRow = grdContactosProveedor.ActiveRow
        If row.IsFilterRow Then Return
        ContactoId = CInt(row.Cells("daco_datoscontactoid").Value())
        ProveedorId = row.Cells("daco_proveedorid").Value()


        PermisosInterfaz()
    End Sub


    Private Sub PermisosInterfaz()
        Dim TipoContacto As String = String.Empty

        TipoContacto = grdContactosProveedor.ActiveRow.Cells("daco_tipocontacto").Value

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "PERMISO_COMERCIALIZADORA") Then
            If TipoContacto = "VENTAS" Then
                btnEditar.Enabled = False
            ElseIf TipoContacto = "COBRANZA" Then
                btnEditar.Enabled = True
            ElseIf TipoContacto = "COBRANZA/VENTAS" Then
                btnEditar.Enabled = True
            End If
        ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "PERMISO_NAVE") Then
            If TipoContacto = "VENTAS" Then
                btnEditar.Enabled = True
            ElseIf TipoContacto = "COBRANZA" Then
                btnEditar.Enabled = False
            ElseIf TipoContacto = "COBRANZA/VENTAS" Then
                btnEditar.Enabled = True
            End If
        Else
            btnEditar.Enabled = False
        End If
    End Sub

End Class