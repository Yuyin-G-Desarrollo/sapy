Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Drawing
Imports Framework.Negocios

Public Class ConsultaProveedoresForm

    Dim ProveedorID As Integer = -1
    Dim NombreProveedor As String = String.Empty


    Private Sub ConsultaProveedoresForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Location = New Point(0, 0)
        Me.WindowState = FormWindowState.Maximized
        CargarNaves()
        btnEditar.Enabled = False
        btnContactos.Enabled = False
        btnAlta.Enabled = False
        btnExportar.Enabled = False


    End Sub

    Private Sub PermisosInterfaz(ByVal ProveedorSeleccionado As Boolean)

        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "PERMISO_COMERCIALIZADORA") Then
        '    btnAlta.Enabled = True
        '    If ProveedorSeleccionado = True Then
        '        btnEditar.Enabled = True
        '    Else
        '        btnEditar.Enabled = False
        '    End If

        '    btnContactos.Enabled = True
        '    btnExportar.Enabled = True

        'ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "PERMISO_NAVE") Then
        '    btnAlta.Enabled = True
        '    If ProveedorSeleccionado = True Then
        '        btnEditar.Enabled = True
        '    Else
        '        btnEditar.Enabled = False
        '    End If

        '    btnContactos.Enabled = True
        '    btnExportar.Enabled = True

        'Else
        '    btnContactos.Enabled = False
        '    btnExportar.Enabled = False
        '    btnEditar.Enabled = False
        '    btnAlta.Enabled = False
        'End If

    End Sub

 
    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If cmbNave.SelectedIndex > 0 Then
            CargarGridProveedores()
            btnAlta.Enabled = True
            btnExportar.Enabled = True
            lblNave.ForeColor = Color.Black

            PermisosInterfaz(False)



        Else
            show_message("Advertencia", "No se ha seleccionado una nave")
            btnAlta.Enabled = False
            btnExportar.Enabled = False
            lblNave.ForeColor = Color.Red
        End If
    End Sub

    Private Sub CargarGridProveedores()
        Dim objProvedorBu As New Proveedores.BU.ProveedorBU
        Dim DTInformacionProveedor As DataTable
        grdProveedores.DataSource = Nothing
        gridDiseno(grdProveedores)
        Dim NAveID As Integer = 0
        If cmbNave.SelectedIndex = 0 Then
            NAveID = -1
        Else
            NAveID = cmbNave.SelectedValue
        End If


        DTInformacionProveedor = objProvedorBu.ConsultaInformacionProveedores(NAveID, rdoSi.Checked)
        grdProveedores.DataSource = DTInformacionProveedor

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


        AgregarColumna(grid, "prov_proveedorid", "ID", False, False, Nothing, 80, , , HAlign.Right)
        AgregarColumna(grid, "dage_nombrecomercial", "NOMBRE COMERCIAL", False, True, Nothing, 100)        
        AgregarColumna(grid, "prov_razonsocial", "RAZÓN SOCIAL", False, True, Nothing, 100)
        AgregarColumna(grid, "prov_rfc", "RFC", False, True, Nothing, 100)
        AgregarColumna(grid, "prov_pais", "PAÍS", False, True, Nothing, 100)
        AgregarColumna(grid, "cate_nombre", "CLASIFICACIÓN", False, True, Nothing, 100)
        AgregarColumna(grid, "girp_descripcion", "GIRO", False, True, Nothing, 100)
        AgregarColumna(grid, "prov_clasificaciongiroid", "prov_clasificaciongiroid", True, True, Nothing, 100)
       



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
            If EsCadena = False Then
                columna.MaxWidth = Width
            End If

        End If
    End Sub

    Private Sub SumarizarColumnaGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal NombreColumna As String, ByVal Key As String)
        Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns(NombreColumna)
        Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add(Key, SummaryType.Sum, columnToSummarize)
        summary.DisplayFormat = "{0:###,###,##0}"
        summary.Appearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
    End Sub



    Private Sub CargarNaves()

        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If cmbNave.Items.Count = 2 Then
            cmbNave.SelectedIndex = 1
        End If
       
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel(grdProveedores)
    End Sub

    Public Sub exportarExcel(ByVal grd As UltraGrid)
        Dim sfd As New SaveFileDialog
        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                UltraGridExcelExporter1.Export(grd, fileName)
                show_message("Exito", "El archivo se ha exportado correctamente en la ruta " + fileName)
                Process.Start(fileName)
                Me.Cursor = Cursors.Default


            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim AltaProveedor As New AltaProveedorForm2
        AltaProveedor.NaveID = cmbNave.SelectedValue
        AltaProveedor.ShowDialog()
        CargarGridProveedores()

        'AltaProveedor.MdiParent = Me.MdiParent
        'AltaProveedor.Show()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim AltaProveedor As New AltaProveedorForm2
        AltaProveedor.ProveedorID = ProveedorID
        AltaProveedor.NaveID = cmbNave.SelectedValue
        AltaProveedor.ShowDialog()
        CargarGridProveedores()
        'AltaProveedor.MdiParent = Me.MdiParent
        'AltaProveedor.Show()
    End Sub

    Private Sub btnContactos_Click(sender As Object, e As EventArgs) Handles btnContactos.Click
        Dim ContactosProveedor As New ContactosProveedorForm
        ContactosProveedor.ProveedorId = ProveedorID
        ContactosProveedor.NombreProveedor = NombreProveedor
        'ContactosProveedor.MdiParent = Me.MdiParent
        ContactosProveedor.Show()
        'ContactosProveedor.MdiParent = Me.MdiParent
        'ContactosProveedor.Show()
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cmbNave.SelectedIndex = 0
        rdoSi.Checked = True
        rdoNo.Checked = False
        grdProveedores.DataSource = Nothing
        btnAlta.Enabled = False
        btnEditar.Enabled = False
        btnExportar.Enabled = False
        btnContactos.Enabled = False
    End Sub

    
   

    Private Sub grdProveedores_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdProveedores.ClickCell


        Dim TotalFiniquito As Double = 0
        Dim row As UltraGridRow = grdProveedores.ActiveRow
        If row.IsFilterRow Then Return
        ProveedorID = CInt(row.Cells("prov_proveedorid").Value())

        If IsDBNull(row.Cells("prov_razonsocial").Value()) = False Then
            NombreProveedor = row.Cells("prov_razonsocial").Value()
        End If

        PermisosInterfaz(True)

        btnEditar.Enabled = True
        btnContactos.Enabled = True

    End Sub

    Public Function show_message(ByVal tipo As String, ByVal mensaje As String) As DialogResult
        Dim ResultadoDialogo As DialogResult

        If tipo.ToString.Equals("Advertencia") Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then
            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            ResultadoDialogo = mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            ResultadoDialogo = mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        Return ResultadoDialogo
    End Function

    
End Class

