Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization

Public Class CatalogoMotivosIncidenciaForm

    Dim CategoriaID As Integer = -1
    Dim NombreCategoria As String = String.Empty
    Dim TipoMotivoId As Integer = -1
    Dim NombreTipoMotivo As String = String.Empty
    Dim EsActivaCategoria As Boolean = True


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CatalogoMotivosIncidenciaForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Location = New Point(0, 0)        
        btnEditarTipo.Enabled = False
        btnEditarCategoria.Enabled = False
        LimpiarVariables()
    End Sub

    Private Sub gridListaUbicacionDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy       
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub gridCatalogoTiposIncidencia_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridCatalogoTiposIncidencia.ClickCell
        Dim row As UltraGridRow = gridCatalogoTiposIncidencia.ActiveRow
        If row.IsFilterRow Then Return
        TipoMotivoId = CInt(row.Cells("MotivoID").Value())
        CategoriaID = CInt(row.Cells("CategoriaID").Value())
        NombreTipoMotivo = CStr(row.Cells("Tipo Motivo").Value())
        NombreCategoria = CStr(row.Cells("Categoría").Value())
        btnEditarTipo.Enabled = True
        btnEditarCategoria.Enabled = True
    End Sub


    Private Sub gridCatalogoTiposIncidencia_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridCatalogoTiposIncidencia.InitializeLayout
        With gridCatalogoTiposIncidencia
            .DisplayLayout.Bands(0).Columns("MotivoID").Hidden = True
            .DisplayLayout.Bands(0).Columns("CategoriaID").Hidden = True
            .DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .DisplayLayout.Bands(0).Columns("Tipo Motivo").CellAppearance.TextHAlign = HAlign.Left
            .DisplayLayout.Bands(0).Columns("Categoría").CellAppearance.TextHAlign = HAlign.Left                                    
        End With
    End Sub

    Private Sub btnAltaCategoria_Click(sender As Object, e As EventArgs) Handles btnAltaCategoria.Click
        Dim form As New AgregarEditarCategoriasMotivosIncidenciaForm
        'form.MdiParent = Me.MdiParent
        form.CategoriaID = -1
        form.ShowDialog()
        LimpiarVariables()
        LlenaCatalgoCategoriasMotivosIncidencia()
    End Sub

    Private Sub btnAltaTipo_Click(sender As Object, e As EventArgs) Handles btnAltaTipo.Click
        Dim form As New AgregarEditarMotivoIncidenciaForm
        'form.MdiParent = Me.MdiParent
        form.TipoMotivoId = -1
        form.ShowDialog()
        LimpiarVariables()
        LlenaCatalgoCategoriasMotivosIncidencia()
    End Sub

    Private Sub btnEditarCategoria_Click(sender As Object, e As EventArgs) Handles btnEditarCategoria.Click
        Dim form As New AgregarEditarCategoriasMotivosIncidenciaForm
        'form.MdiParent = Me.MdiParent
        form.CategoriaID = CategoriaID
        form.NombreCategoria = NombreCategoria
        form.CategoriaActiva = EsActivaCategoria
        form.ShowDialog()
        LimpiarVariables()
        LlenaCatalgoCategoriasMotivosIncidencia()
    End Sub

    Private Sub btnEditarTipo_Click(sender As Object, e As EventArgs) Handles btnEditarTipo.Click
        Dim form As New AgregarEditarMotivoIncidenciaForm
        'form.MdiParent = Me.MdiParent
        form.TipoMotivoId = TipoMotivoId
        form.TipoMotivoIncidencia = NombreTipoMotivo
        form.Activo = EsActivaCategoria
        form.CategoriaId = CategoriaID
        form.ShowDialog()
        LlenaCatalgoCategoriasMotivosIncidencia()
    End Sub

    Private Sub LimpiarVariables()
        CategoriaID = -1
        TipoMotivoId = -1
        NombreCategoria = String.Empty
        NombreTipoMotivo = String.Empty
        btnEditarTipo.Enabled = False
        btnEditarCategoria.Enabled = False
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        EsActivaCategoria = rdoSi.Checked
        LimpiarVariables()
        LlenaCatalgoCategoriasMotivosIncidencia()
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub


    Public Sub LlenaCatalgoCategoriasMotivosIncidencia()
        Dim objCatalogoMotiIncidencia As New Ventas.Negocios.CatalogoMotivosIncidenciaBU()
        Dim dtCataloggIncidencia As DataTable
        dtCataloggIncidencia = objCatalogoMotiIncidencia.ListaTiposMotivosIncidencias(rdoSi.Checked)
        gridCatalogoTiposIncidencia.DataSource = dtCataloggIncidencia

        If dtCataloggIncidencia.Rows.Count = 0 Then
            show_message("Aviso", "No hay datos para mostrar")
        End If

    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbRamos.Height = 93
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbRamos.Height = 28
    End Sub
End Class
