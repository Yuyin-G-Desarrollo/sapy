Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Drawing

Public Class AltaClasificacionGiroForm

    Public ClasificacionID As Integer = -1
    Public Clasificacion As String = String.Empty
    Private GiroID As Integer = -1
    Private Giro As String = String.Empty
    Dim ExisteClasificaion As Boolean = False

    Private Sub AltaClasificacionGiroForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim DTInformacionClasificacion As DataTable
        Dim objBU As New Proveedores.BU.ClasificacionGiroBU
        Dim EsActivo As Boolean = False
        CargarGirosClasificaciones()


        If ClasificacionID <> -1 Then
            lblTitulo.Text = "Edición Clasificación"
            Me.Text = "Edición Clasificación"

            DTInformacionClasificacion = objBU.ConsultaInformacionClasificacion(ClasificacionID)
            txtClasificacionGiro.Text = Clasificacion
            txtClasificacionGiro.Enabled = False

            If DTInformacionClasificacion.Rows.Count > 0 Then
                EsActivo = CBool(DTInformacionClasificacion.Rows(0).Item("cate_status"))

                If EsActivo = True Then
                    rdoSi.Checked = True
                    rdoNo.Checked = False
                Else
                    rdoSi.Checked = False
                    rdoNo.Checked = True
                End If
            End If
        Else
            rdoSi.Enabled = False
            rdoNo.Enabled = False
            rdoSi.Checked = True
            rdoNo.Checked = False
        End If
    End Sub

    

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub CargarGirosClasificaciones()
        Dim objBU As New Proveedores.BU.ClasificacionGiroBU()
        Dim DTClasificacionesGiros As DataTable

        grdGiros.DataSource = Nothing
        gridDiseno(grdGiros)
        grdGiros.DataSource = objBU.ConsultaGiros(True)

        If ClasificacionID <> -1 Then
            DTClasificacionesGiros = objBU.ConsultaGiroClasificacion(ClasificacionID)
            For Each fila As UltraGridRow In grdGiros.Rows
                For Each FilaGriros As DataRow In DTClasificacionesGiros.Rows
                    If FilaGriros.Item("girp_giroproveedorid").ToString() = fila.Cells("girp_giroproveedorid").Value Then
                        fila.Cells(" ").Value = True
                        Exit For
                    Else
                        fila.Cells(" ").Value = False
                    End If
                Next
            Next
        End If
                   
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New Proveedores.BU.ClasificacionGiroBU
        Dim DtClasificacion As DataTable
        Dim DTClasificacionID As DataTable
        Dim GirosSeleccionados As Integer = 0
        Dim mensajeConfirmacion As New ConfirmarForm

        If txtClasificacionGiro.Text.Trim() = String.Empty Then
            lblClasificacion.ForeColor = Color.Red
            show_message("Advertencia", "El campo de clasificación no puede estar vacío")
        Else
            DtClasificacion = objBU.BuscarClasificacion(txtClasificacionGiro.Text.Trim(), ClasificacionID)
            If DtClasificacion.Rows.Count > 0 Then
                show_message("Advertencia", "Ya existe una clasificación con el mismo nombre")
            Else
                For Each Fila As UltraGridRow In grdGiros.Rows
                    If Fila.Cells(" ").Value = True Then
                        GirosSeleccionados = GirosSeleccionados + 1
                    End If
                Next

                If GirosSeleccionados = 0 Then
                    show_message("Advertencia", "Se debe de seleccionar al menos un giro")

                Else

                    If ClasificacionID = -1 Then
                        mensajeConfirmacion.mensaje = "¿Está seguro de dar de alta la clasificación, ya no se podrán realizar cambios?"
                    Else
                        mensajeConfirmacion.mensaje = "¿Está seguro de guardar los cambios?"
                    End If

                    If mensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then

                        If ClasificacionID = -1 Then
                            DTClasificacionID = objBU.InsertarClasificacion(txtClasificacionGiro.Text.Trim, True, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        Else
                            DTClasificacionID = objBU.EditarClasificacion(ClasificacionID, txtClasificacionGiro.Text.Trim, rdoSi.Checked, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        End If

                        If DTClasificacionID.Rows.Count > 0 Then
                            If ClasificacionID = -1 Then
                                ClasificacionID = CInt(DTClasificacionID.Rows(0).Item("ClasificacionID").ToString())
                            End If

                            For Each Fila As UltraGridRow In grdGiros.Rows
                                If Fila.Cells(" ").Value = True Then
                                    objBU.InsertarClasificacionGiro(ClasificacionID, Fila.Cells("girp_giroproveedorid").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                                Else
                                    objBU.DesactivarClasificacionGiro(ClasificacionID, Fila.Cells("girp_giroproveedorid").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                                End If
                            Next
                        End If
                        If ClasificacionID = -1 Then
                            show_message("Exito", "Se ha guardado la clasificación")
                        Else
                            show_message("Exito", "Se ha guardado los cambios")
                        End If

                        Me.Close()
                    End If



                End If

            End If

            

        End If

    End Sub

    'Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
    '    Dim objBU As New Proveedores.BU.ClasificacionGiroBU
    '    Dim DtClasificacion As DataTable
    '    Dim DTClasificacionID As DataTable
    '    Dim GirosSeleccionados As Integer = 0
    '    Dim mensajeConfirmacion As New ConfirmarForm

    '    If txtClasificacionGiro.Text.Trim() = String.Empty Then
    '        lblClasificacion.ForeColor = Color.Red
    '        show_message("Advertencia", "El campo de clasificación no puede estar vacío")
    '    Else

    '        If ClasificacionID = -1 Then
    '            mensajeConfirmacion.mensaje = "¿Está seguro de registrar la clasificación, ya no se podra realizar cambios?"
    '        Else
    '            mensajeConfirmacion.mensaje = "¿Está seguro de guardar los cambios?"
    '        End If


    '        If mensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
    '            DtClasificacion = objBU.BuscarClasificacion(txtClasificacionGiro.Text.Trim(), ClasificacionID)


    '            For Each Fila As UltraGridRow In grdGiros.Rows
    '                If Fila.Cells(" ").Value = True Then
    '                    GirosSeleccionados = GirosSeleccionados + 1
    '                End If
    '            Next

    '            If GirosSeleccionados = 0 Then
    '                show_message("Advertencia", "Se debe de seleccionar al menos un giro")
    '            Else
    '                If DtClasificacion.Rows.Count = 0 Then
    '                    If ClasificacionID = -1 Then
    '                        DTClasificacionID = objBU.InsertarClasificacion(txtClasificacionGiro.Text.Trim, True)
    '                    Else
    '                        DTClasificacionID = objBU.EditarClasificacion(ClasificacionID, txtClasificacionGiro.Text.Trim, rdoSi.Checked)
    '                    End If

    '                    If DTClasificacionID.Rows.Count > 0 Then
    '                        If ClasificacionID = -1 Then
    '                            ClasificacionID = CInt(DTClasificacionID.Rows(0).Item("ClasificacionID").ToString())
    '                        End If

    '                        For Each Fila As UltraGridRow In grdGiros.Rows
    '                            If Fila.Cells(" ").Value = True Then
    '                                objBU.InsertarClasificacionGiro(ClasificacionID, Fila.Cells("girp_giroproveedorid").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    '                            Else
    '                                objBU.DesactivarClasificacionGiro(ClasificacionID, Fila.Cells("girp_giroproveedorid").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    '                            End If
    '                        Next
    '                    End If
    '                    If ClasificacionID = -1 Then
    '                        show_message("Exito", "Se ha guardado la clasificación")
    '                    Else
    '                        show_message("Exito", "Se ha guardado los cambios clasificación")
    '                    End If

    '                    Me.Close()
    '                Else
    '                    show_message("Advertencia", "Ya existe una clasificacion con el mismo nombre")
    '                End If
    '            End If

    '        End If

    '    End If

    'End Sub

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


        AgregarColumna(grid, " ", " ", False, False, Nothing, 60, , True, HAlign.Right)
        AgregarColumna(grid, "girp_giroproveedorid", "ID", False, False, Nothing, 60, , , HAlign.Right)
        AgregarColumna(grid, "girp_descripcion", "GIRO", False, True, Nothing, 100)




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

  
  
  
    Private Sub btnAltaGiro_Click(sender As Object, e As EventArgs) Handles btnAltaGiro.Click
        Dim AltaGiro As New AltaGiroForm
        AltaGiro.ShowDialog()
        CargarGirosClasificaciones()
        GiroID = -1
        Giro = String.Empty


    End Sub

    Private Sub btnEditarGiro_Click(sender As Object, e As EventArgs)
        Dim AltaGiro As New AltaGiroForm
        AltaGiro.GiroID = GiroID
        AltaGiro.Giro = Giro
        AltaGiro.ShowDialog()
        CargarGirosClasificaciones()
    End Sub

    Private Sub grdGiros_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdGiros.ClickCell
        Dim TotalFiniquito As Double = 0
        Dim row As UltraGridRow = grdGiros.ActiveRow
        If row.IsFilterRow Then Return
        GiroID = CInt(row.Cells("girp_giroproveedorid").Value())
        Giro = row.Cells("girp_descripcion").Value()

    End Sub

    Private Sub txtClasificacionGiro_LostFocus(sender As Object, e As EventArgs) Handles txtClasificacionGiro.LostFocus
        Dim objBU As New Proveedores.BU.ClasificacionGiroBU
        Dim DtClasificacion As DataTable

        If ExisteClasificaion = False Then
            DtClasificacion = objBU.BuscarClasificacion(txtClasificacionGiro.Text.Trim(), ClasificacionID)
            If DtClasificacion.Rows.Count > 0 Then
                ExisteClasificaion = True
                show_message("Advertencia", "Ya existe una clasificacion con el mismo nombre")
                lblClasificacion.ForeColor = Color.Red
                btnGuardar.Enabled = False
            Else
                btnGuardar.Enabled = True
                lblClasificacion.ForeColor = Color.Black
            End If

            ExisteClasificaion = False
        End If
        

    End Sub

    Private Sub pbYuyin_Click(sender As Object, e As EventArgs) Handles pbYuyin.Click

    End Sub
End Class