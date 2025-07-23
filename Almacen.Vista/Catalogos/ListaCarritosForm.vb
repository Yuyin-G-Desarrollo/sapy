Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Stimulsoft.Report

Public Class ListaCarritosForm

    Private Sub ListaCarritosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        listado_naves()
    End Sub

    Private Sub listado_naves()

        Try

            Controles.ComboNavesConAlmacenSegunUsuario(cboxNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))

        Catch ex As Exception

        End Try

        If cboxNave.SelectedIndex = 1 Then
            listado_almacen()
        End If

    End Sub

    Private Sub listado_almacen()

        Try

            Controles.ComboAlmacenSegunNave(cboxAlmacen, CInt(cboxNave.SelectedValue))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cboxNave_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboxNave.SelectionChangeCommitted
        listado_almacen()
        gridListaCarritos.DataSource = Nothing
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        If cboxNave.SelectedValue = 0 Or IsNothing(cboxNave.SelectedValue) Then
            show_message("Aviso", "Debe seleccionar un almacén")
            Return
        End If

        poblar_gridListaCarritos(gridListaCarritos)

    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click

        Dim form As New AltaCarritosForm

        form.ShowDialog()
        rbtnEstatusActivo.Checked = True
        If form.naveid > 0 Then
            cboxNave.SelectedValue = form.naveid
            listado_almacen()
            cboxAlmacen.Text = form.almacenid
            btnMostrar.PerformClick()
        End If

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If cboxNave.SelectedValue = 0 Or IsNothing(cboxNave.SelectedValue) Then
            show_message("Aviso", "Debe seleccionar un almacén")
            Return
        End If

        If IsNothing(gridListaCarritos.ActiveRow) Then
            show_message("Aviso", "Debe seleccionar un carrito")
            Return
        End If

        Dim form As New EditarCarritosForm
        form.carritoid = CInt(gridListaCarritos.ActiveRow.Cells(1).Text)
        form.descripcion = CStr(gridListaCarritos.ActiveRow.Cells(2).Text)
        form.naveid = CInt(cboxNave.SelectedValue)
        form.almacenid = CStr(cboxAlmacen.Text)
        form.tipocarritoid = CInt(gridListaCarritos.ActiveRow.Cells(3).Text)

        If rbtnEstatusActivo.Checked Then
            form.estatus = True
        Else
            form.estatus = False
        End If

        form.ShowDialog()
        rbtnEstatusActivo.Checked = True
        If form.naveid > 0 Then
            cboxNave.SelectedValue = form.naveid
            listado_almacen()
            cboxAlmacen.Text = form.almacenid
            btnMostrar.PerformClick()
        End If
        btnMostrar.PerformClick()

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        gridListaCarritos.DataSource = Nothing
    End Sub

    Private Sub btnImprimirCodigo_Click(sender As Object, e As EventArgs) Handles btnImprimirCodigo.Click
        If gridListaCarritos.Rows.Count = 0 Then Return

        Dim grid As DataTable = gridListaCarritos.DataSource
        Dim listParametros As DataTable = grid.Clone
        For Each row As UltraGridRow In gridListaCarritos.Rows
            If CBool(row.Cells(" ").Value) Then
                Dim fila As DataRow = listParametros.NewRow

                For index = 0 To row.Cells.Count - 1 Step 1
                    fila(index) = row.Cells(index).Value
                Next
                listParametros.Rows.Add(fila)
            End If
        Next

        Me.Cursor = Cursors.WaitCursor
        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        EntidadReporte = OBJBU.LeerReporteporClave("ALM_COD_PLAT")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            EntidadReporte.Pnombre + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()
        reporte.RegData(listParametros)
        reporte.Show()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub gboxContenido_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gboxContenido.MouseDoubleClick
        If gboxFiltros.Dock = DockStyle.None Then
            gboxFiltros.Dock = DockStyle.Top
        Else
            gboxFiltros.Dock = DockStyle.None
        End If
    End Sub

    Public Sub poblar_gridListaCarritos(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New Negocios.ClientesAlmacenBU
        Dim Tabla_ListadoCarritos As New DataTable

        Dim estatus, naveID, almacenID As Integer

        If rbtnEstatusActivo.Checked Then
            estatus = 1
        Else
            estatus = 0
        End If

        If cboxNave.SelectedValue > 0 Then
            naveID = cboxNave.SelectedValue
        Else
            show_message("Aviso", "Debe seleccionar una nave")
        End If

        If Not String.IsNullOrEmpty(cboxAlmacen.Text) Then
            almacenID = CInt(cboxAlmacen.Text)
        Else
            show_message("Aviso", "Debe seleccionar un almacén")
        End If

        Tabla_ListadoCarritos = objBU.ListadoCarritos(estatus, naveID, almacenID)

        grid.DataSource = Tabla_ListadoCarritos

        gridListaCarritosDiseno(grid)

    End Sub

    Private Sub gridListaCarritosDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns(1).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(3).Hidden = True

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

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

    Private Sub gridListaCarritos_DoubleClick(sender As Object, e As EventArgs) Handles gridListaCarritos.DoubleClick
        If IsNothing(gridListaCarritos.ActiveRow) Then Return

        If gridListaCarritos.ActiveRow.Cells(" ").Value Then

            gridListaCarritos.ActiveRow.Cells(" ").Value = False
        Else
            gridListaCarritos.ActiveRow.Cells(" ").Value = True
        End If
    End Sub

    Private Sub chboxMarcarTodo_CheckStateChanged(sender As Object, e As EventArgs) Handles chboxMarcarTodo.CheckStateChanged
        If chboxMarcarTodo.Checked Then
            For Each row As UltraGridRow In gridListaCarritos.Rows
                row.Cells(" ").Value = True
            Next
        Else
            For Each row As UltraGridRow In gridListaCarritos.Rows
                row.Cells(" ").Value = False
            Next
        End If
    End Sub

End Class