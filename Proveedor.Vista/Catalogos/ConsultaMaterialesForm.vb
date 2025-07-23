Imports Proveedores.BU
Imports Infragistics.Win.UltraWinGrid
Imports System.Windows.Forms
Imports Tools
Imports System.Drawing
Imports System.Text.RegularExpressions
Imports Entidades
Imports DevExpress.XtraPrinting

Public Class ConsultaMaterialesForm
    Dim editar As Boolean

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm
    Dim naveDesarrollaMaterialTabla As DataTable
    Dim activo As Integer = 1
    Dim listaMateriales As New List(Of Integer)
    Dim listasMatEditar As New List(Of Integer)
    Dim Seleccionados As Int32 = 0
    Dim precioAnterior As String
    Dim precioActual As String
    Dim ColorActu As Int32 = 0

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub ConsultaMaterialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' cargarMateriales(0, 1)
        grvMaterial.IndicatorWidth = 30
        llenarComboNaves()
        aplicarpermisos()
        DisenioGrid()
        Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub DisenioGrid()
        DiseñoGrid.AlternarColorEnFilas(grvMaterial)
    End Sub

    Public Sub aplicarpermisos()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "ALTAMATERIAL") Then
            pnlAlta.Visible = True
        Else
            pnlAlta.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "EDITARMATERIAL") Then
            pnlEditar.Visible = True
            editar = True
            pnlEditMasivaPrecio.Visible = True
        Else
            pnlEditar.Visible = False
            pnlEditMasivaPrecio.Visible = False
            editar = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "COORDINADOR") Then
            pnlAutorizar.Visible = True
            'cbxTodo.Visible = True
        Else
            pnlAutorizar.Visible = False
            ' cbxTodo.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "EXPORTAREXCEL") Then
            pnlExportar.Visible = True
        Else
            pnlExportar.Visible = False
        End If
    End Sub

    Public Sub llenarComboNaves()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROYECCION_MATERIALES", "LECTURA_FVO") Then
            cmbNave = Tools.Controles.ComboNavesSegunUsuario_Especial(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        Else
            cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        End If
        If cmbNave.Items.Count = 2 Then
            cmbNave.SelectedIndex = 1
        End If
    End Sub

    Public Sub cargarMateriales(id As Integer, activo As Integer)
        If cmbNave.SelectedIndex > 0 Then
            Dim obj As New MaterialesBU
            Me.Cursor = Cursors.WaitCursor
            grdMaterial.DataSource = obj.getMateriales(id, activo)

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "ADMINISTRADORMATERIALES") Then
                cExclusivo.Visible = True
                cNaveDesarrolla.Visible = True
            Else
                cExclusivo.Visible = False
                cNaveDesarrolla.Visible = False

            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    'Public Sub diseñoMateriales(ColumnaPrecio As Integer)
    '    With grdMateriales.DisplayLayout.Bands(0)

    '        .Columns("Nave").Hidden = True
    '        .Columns("idMaterialNave").Hidden = True
    '        .Columns("idRemplazo").Hidden = True
    '        .Columns("IdMatSicy").Hidden = True
    '        .Columns("idColor").Hidden = True
    '        .Columns("idTam").Hidden = True
    '        .Columns("Nombre").Hidden = True
    '        .Columns("Remplazo").Hidden = True
    '        .Columns("Departamento").Hidden = True
    '        .Columns("idc").Hidden = True
    '        .Columns("idclas").Hidden = True
    '        .Columns("Categoría").Hidden = True
    '        .Columns("Tamaño").Hidden = True
    '        .Columns("Color").Hidden = True
    '        .Columns("Crítico").Hidden = True
    '        .Columns("Nave").Hidden = True
    '        .Columns("ID Nave Desarrolla").Hidden = True


    '        grdMateriales.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    '        grdMateriales.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

    '        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "ADMINISTRADORMATERIALES") Then
    '        Else
    '            .Columns("Exclusivo").Hidden = True
    '            .Columns("Nave Desarrolla").Hidden = True
    '        End If

    '        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "COORDINADOR") Then
    '        Else
    '            .Columns(" ").Hidden = True
    '        End If

    '        .Columns("Precio").Format = "##,##0.00"
    '        .Columns("PrecioMod").Format = "##,##0.00"
    '        .Columns("Rendimiento").Format = "####0.00"
    '        .Columns("SKU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    '        .Columns("Rendimiento").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    '        .Columns("Precio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    '        .Columns("PrecioMod").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

    '        .Columns(" ").Width = 40
    '        .Columns("ID").Width = 50
    '        .Columns("Precio").Width = 50
    '        .Columns("PrecioMod").Width = 50
    '        .Columns("Material").Width = 400
    '        .Columns("Proveedor").Width = 310
    '        .Columns("Estatus").Width = 120

    '        .Columns("Nave Desarrolla").Header.Caption = "Nave" & vbCrLf & "Desarrolla"
    '        .Columns("Rendimiento").Header.Caption = "Factor de" & vbCrLf & "Conversión"
    '        .Columns("Días Entrega").Header.Caption = "Días" & vbCrLf & "Entrega"
    '        .Columns("UM-Prod").Header.Caption = "UMP"
    '        .Columns("UM prov").Header.Caption = "UMC"
    '        .Columns("origenprecio").Header.Caption = "Orígen"

    '        For value = 0 To grdMateriales.Rows.Count - 1
    '            If grdMateriales.Rows(value).Cells("Estatus").Text = "DESARROLLO" Then
    '                grdMateriales.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E9AFE")
    '            ElseIf grdMateriales.Rows(value).Cells("Estatus").Text = "PRODUCCIÓN" Then
    '                grdMateriales.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#58FAAC")
    '            End If
    '        Next

    '        .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
    '        .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
    '        .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
    '        .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
    '    End With
    '    grdMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    '    'grdMateriales.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    '    grdMateriales.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    'End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        editarMaterial()
    End Sub

    Private Sub editarMaterial()
        If grvMaterial.RowCount > 0 Then
            If grvMaterial.GetFocusedRowCellValue(cIdMaterial).ToString <> "" Then
                Me.Cursor = Cursors.WaitCursor
                Dim form As New AltaMaterialesForm
                Dim list As DataTable
                Dim obj As New MaterialesBU

                list = obj.consultaCaracteristicas(Convert.ToInt32(grvMaterial.GetFocusedRowCellValue(cIdMaterial).ToString))
                form.NombreNaveAlta = cmbNave.Text
                form.idMaterial = Convert.ToInt32(grvMaterial.GetFocusedRowCellValue(cIdMaterial).ToString)
                form.idMaterialNave = Convert.ToInt32(grvMaterial.GetFocusedRowCellValue(cIdMaterialNave).ToString)
                form.idMaterialSicy = Convert.ToInt32(grvMaterial.GetFocusedRowCellValue(cIdMatSicy).ToString)
                form.idNaveDesarrolloMaterial = Convert.ToInt32(grvMaterial.GetFocusedRowCellValue(cIdNaveDesarrolla).ToString)
                form.txtSKU.ReadOnly = True
                form.idNave = Convert.ToInt32(grvMaterial.GetFocusedRowCellValue(cNave).ToString)
                form.nombre = grvMaterial.GetFocusedRowCellValue(cMaterial).ToString
                form.idMaterialRemplazo = grvMaterial.GetFocusedRowCellValue(cIdRemplazo).ToString
                form.accion = "EDITAR"
                form.accion2 = "EDITAR"
                form.txtNombre.Text = grvMaterial.GetFocusedRowCellValue(cNombre).ToString
                form.cmbColor.Text = grvMaterial.GetFocusedRowCellValue(cColor).ToString
                form.idcolor2 = grvMaterial.GetFocusedRowCellValue(cIdColor).ToString
                form.idtamano = grvMaterial.GetFocusedRowCellValue(cIdTam).ToString
                form.estatus = grvMaterial.GetFocusedRowCellValue(cEstatus).ToString
                form.txtSKU.Text = grvMaterial.GetFocusedRowCellValue(cSKU).ToString
                form.sku2 = grvMaterial.GetFocusedRowCellValue(cSKU).ToString
                form.estatus = grvMaterial.GetFocusedRowCellValue(cEstatus).ToString
                form.idcolor2 = grvMaterial.GetFocusedRowCellValue(cIdColor).ToString
                form.idtamano = grvMaterial.GetFocusedRowCellValue(cIdTam).ToString
                form.categoria = grvMaterial.GetFocusedRowCellValue(cIdc).ToString
                form.clasificacion = grvMaterial.GetFocusedRowCellValue(cIdclas).ToString
                form.Material = grvMaterial.GetFocusedRowCellValue(cTipo).ToString
                form.lista = list
                form.naveDesarollaMaterial = grvMaterial.GetFocusedRowCellValue(cNaveDesarrolla).ToString
                form.TipoMaterial = form.Material = grvMaterial.GetFocusedRowCellValue(cTipo).ToString

                form.AccionMaterial = 2 ' Pasamos la acción de modificar al formulario.  -- CAMBIO OAMB (10/08/2023)

                Try
                    form.naveDesarrolla = Convert.ToInt32(grvMaterial.GetFocusedRowCellValue(cIdNaveDesarrolla).ToString)
                Catch ex As Exception
                End Try
                Try
                    form.exclusivo = grvMaterial.GetFocusedRowCellValue(cExclusivo).ToString
                Catch ex As Exception
                End Try
                If rdboActivo.Checked Then
                    form.activo = 1
                Else
                    form.activo = 0
                    form.txtNombre.Enabled = False
                    form.cmbCategoria.Enabled = False
                    form.cmbTipoMaterial.Enabled = False
                    form.cmbClas.Enabled = False
                    form.cmbColor.Enabled = False
                    form.cmbTam.Enabled = False
                    form.grdCaracterisitcas.Enabled = False
                    form.cmbDepartamento.Enabled = False
                    form.cmbMaterialRemplazo.Enabled = False
                    form.btnGuardar.Visible = True
                    form.btnNuevoPrecio.Visible = False
                    form.btnEditarPrecio.Visible = False
                    form.lblGuardar.Visible = True
                    form.lblAltaPrecio.Visible = False
                    form.lblEditarPrecio.Visible = False
                    form.cmbClas.Enabled = False
                    form.cmbCategoria.Enabled = False
                    form.txtNombre.Enabled = False
                    form.gbxActivo.Enabled = True
                    form.gbxEstatus.Enabled = False
                    form.rdboSiCritico.Enabled = False
                    form.rdboNoCritico.Enabled = False
                    form.rdoInactivoNave.Enabled = False
                    form.rdoActivoNave.Enabled = False
                    form.cmbCategoria.Enabled = False
                    form.cmbClas.Enabled = False
                    form.noPrecio = True
                    form.gbxActivo.Enabled = True
                    form.cmbClas.Enabled = False
                    form.cmbCategoria.Enabled = False
                    form.btnAgregarColor.Enabled = False
                    form.btnAgregarDepartamento.Enabled = False
                    form.btnAgregarTamano.Enabled = False
                    form.cbxExclusivo.Enabled = False
                End If
                form.EDITAR = 1

                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOCOMPRAS") And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISODESARROLLO") Then

                ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISODESARROLLO") And grvMaterial.GetFocusedRowCellValue(cTipo).ToString = "INDIRECTO" Then
                    form.txtNombre.Enabled = False
                    form.cmbCategoria.Enabled = False
                    form.cmbTipoMaterial.Enabled = False
                    form.cmbClas.Enabled = False
                    form.cmbColor.Enabled = False
                    form.cmbTam.Enabled = False
                    form.grdCaracterisitcas.Enabled = False
                    form.cmbDepartamento.Enabled = False
                    form.cmbMaterialRemplazo.Enabled = False
                    form.btnGuardar.Visible = False
                    form.btnNuevoPrecio.Visible = False
                    form.btnEditarPrecio.Visible = False
                    form.lblGuardar.Visible = False
                    form.lblAltaPrecio.Visible = False
                    form.lblEditarPrecio.Visible = False
                    form.cmbClas.Enabled = False
                    form.cmbCategoria.Enabled = False
                    form.txtNombre.Enabled = False
                    form.lblMensaje2.Text = "NO TIENE PERMISOS PARA EDITAR ESTE MATERIAL,"
                    form.lblMensaje3.Text = "NO CORRESPONDE AL TIPO DE MATERIAL AL QUE TIENE ACCESO"
                    form.lblMensaje2.Visible = True
                    form.lblMensaje3.Visible = True
                    form.gbxActivo.Enabled = False
                    form.gbxEstatus.Enabled = False
                    form.rdboSiCritico.Enabled = False
                    form.rdboNoCritico.Enabled = False
                    form.rdoInactivoNave.Enabled = False
                    form.rdoActivoNave.Enabled = False
                    form.cmbCategoria.Enabled = False
                    form.cmbClas.Enabled = False
                    form.noPrecio = True
                    form.btnGuardar.Enabled = False
                    form.gbxActivo.Enabled = False
                ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOCOMPRAS") And grvMaterial.GetFocusedRowCellValue(cTipo).ToString = "DIRECTO" Then
                    form.txtNombre.Enabled = False
                    form.cmbCategoria.Enabled = False
                    form.cmbTipoMaterial.Enabled = False
                    form.cmbClas.Enabled = False
                    form.cmbColor.Enabled = False
                    form.cmbTam.Enabled = False
                    form.grdCaracterisitcas.Enabled = False
                    form.cmbDepartamento.Enabled = False
                    form.cmbMaterialRemplazo.Enabled = False
                    form.btnGuardar.Visible = False
                    form.btnNuevoPrecio.Visible = False
                    form.btnEditarPrecio.Visible = False
                    form.lblGuardar.Visible = False
                    form.lblMensaje2.Text = "NO TIENE PERMISOS PARA EDITAR ESTE MATERIAL,"
                    form.lblMensaje3.Text = "NO CORRESPONDE AL TIPO DE MATERIAL AL QUE TIENE ACCESO"
                    form.lblMensaje2.Visible = True
                    form.lblMensaje3.Visible = True
                    form.gbxActivo.Enabled = False
                    form.gbxEstatus.Enabled = False
                    form.rdboSiCritico.Enabled = False
                    form.rdboNoCritico.Enabled = False
                    form.rdoInactivoNave.Enabled = False
                    form.rdoActivoNave.Enabled = False
                    form.cmbCategoria.Enabled = False
                    form.cmbClas.Enabled = False
                    form.lblAltaPrecio.Visible = False
                    form.lblEditarPrecio.Visible = False
                    form.cmbClas.Enabled = False
                    form.cmbCategoria.Enabled = False
                    form.txtNombre.Enabled = False
                    form.noPrecio = True
                    form.btnGuardar.Enabled = False
                    form.gbxActivo.Enabled = False
                End If

                Me.Cursor = Cursors.Default
                form.ShowDialog()
                Dim activo As Integer = 0
                If rdboActivo.Checked = True Then
                    activo = 1
                Else
                    activo = 0
                End If
                cargarMateriales(cmbNave.SelectedValue, activo)
                'rdboActivo.Checked = True
                'rdboInactivo.Checked = False
            End If
        End If
    End Sub

    Private Sub btnNuevoPrecio_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If cmbNave.SelectedIndex > 0 Then
            Dim form As New AltaMaterialesForm
            form.idNave = cmbNave.SelectedValue
            form.accion = "NUEVO"
            form.accion2 = "NUEVO"
            form.rdboInactivo.Enabled = False
            form.naveDesarollaMaterial = cmbNave.Text
            form.NombreNaveAlta = cmbNave.Text

            form.AccionMaterial = 1 ' Pasamos la acción de inserción al formulario.  -- CAMBIO OAMB (10/08/2023)

            form.ShowDialog()
            cargarMateriales(cmbNave.SelectedValue, 1)
            rdboActivo.Checked = True
            rdboInactivo.Checked = False
        Else
            Dim adv As New Tools.AdvertenciaForm
            objMensaje.mensaje = "Seleccione una nave para registrar el material."
            objMensaje.StartPosition = FormStartPosition.CenterScreen
            objMensaje.ShowDialog()
            Dim activo As Integer = 0
            If rdboActivo.Checked = True Then
                activo = 1
            Else
                activo = 0
            End If
            cargarMateriales(cmbNave.SelectedValue, activo)
        End If
    End Sub

    'Public Sub validarSeleccion()
    '    Try
    '        If grdMateriales.ActiveRow.Cells(" ").IsActiveCell And grdMateriales.ActiveRow.Cells("Nave Desarrolla").Text = cmbNave.Text And
    '             grdMateriales.ActiveRow.Cells("Tipo").Text = "DIRECTO" And grdMateriales.ActiveRow.Cells("Precio").Text <> "0.00" And
    '             grdMateriales.ActiveRow.Cells("Estatus").Text <> "PRODUCCIÓN" And activo = 1 Then
    '            If grdMateriales.ActiveRow.Cells(" ").Value = 1 Then
    '                grdMateriales.ActiveRow.Cells(" ").Value = 0
    '            Else
    '                grdMateriales.ActiveRow.Cells(" ").Value = 1
    '            End If
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    'Private Sub grdMateriales_ClickCell(sender As Object, e As ClickCellEventArgs)
    '    Try
    '        grdMateriales.ActiveRow.Selected = True
    '    Catch ex As Exception
    '    End Try
    '    validarSeleccion()
    'End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If grvMaterial.RowCount > 0 Then
            exportarExcel()
        End If
    End Sub

    Public Sub exportarExcel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            'CargarReporteParaExcel()
            If grvMaterial.DataRowCount > 0 Then
                nombreReporte = "Reporte_Materiales _"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If grvMaterial.GroupCount > 0 Then
                            grvMaterial.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            grvMaterial.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")

                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")

            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo")

        End Try
        'Dim sfd As New SaveFileDialog
        ''sfd.DefaultExt = "xlsx"
        ''sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        'sfd.DefaultExt = "xls"
        'sfd.Filter = "Excel Files|*.xls"
        'Dim result As DialogResult = sfd.ShowDialog()
        'Dim fileName As String = sfd.FileName
        'If result = Windows.Forms.DialogResult.OK Then
        '    Try
        '        Me.Cursor = Cursors.WaitCursor
        '        ultExportGrid.Export(grdMateriales, fileName)
        '        Dim objMensajeExito As New Tools.ExitoForm
        '        objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
        '        objMensajeExito.StartPosition = FormStartPosition.CenterScreen
        '        objMensajeExito.ShowDialog()
        '        Process.Start(fileName)
        '        'grdMateriales.DataSource = Nothing
        '    Catch ex As Exception
        '        Dim objMensajeError As New Tools.ErroresForm
        '        objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
        '        objMensajeError.StartPosition = FormStartPosition.CenterScreen
        '        objMensajeError.ShowDialog()
        '    End Try
        'End If
        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        If (e.RowHandle Mod 2 > 0) Then
            e.Formatting.BackColor = Color.LightSteelBlue
        End If

        e.Handled = True

    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        grdMaterial.DataSource = Nothing
    End Sub

    Public Sub buscar()
        If cmbNave.SelectedIndex > 0 Then

            If rdboActivo.Checked Then
                activo = 1
            Else
                activo = 0
            End If
            cargarMateriales(cmbNave.SelectedValue, activo)
        End If
    End Sub

    'Private Sub grdMateriales_InitializeRow(sender As Object, e As InitializeRowEventArgs)
    '    Try
    '        If e.Row.Cells("Precio").Value = 0 Then
    '            e.Row.Cells("Precio").Appearance.BackColor = Color.Salmon
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            buscar()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdMaterial.DataSource = Nothing
        rdboActivo.Checked = True
        cPrecio.Caption = "Precio"
        cPrecioM.Caption = "Precio Nuevo"
        cPrecioM.Visible = False
        lblGuardarMasivo.Visible = False
        btnGuardarMasivo.Visible = False
    End Sub

    Public Sub AutorizarProduccion()
        Dim obj As New MaterialesBU


        'For value = 0 To grdMateriales.Rows.Count - 1
        '    If grdMateriales.Rows(value).Cells(" ").Value = 1 And grdMateriales.Rows(value).Cells("Nave Desarrolla").Text = cmbNave.Text And
        '        grdMateriales.Rows(value).Cells("Tipo").Text = "DIRECTO" And grdMateriales.Rows(value).Cells("Precio").Text <> "0.00" Then
        '        listaMateriales.Add(grdMateriales.Rows(value).Cells("ID").Value)
        '    End If
        'Next
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "COORDINADOR") Then
            If listaMateriales.Count > 0 Then
                objConfirmacion.mensaje = "¿Está seguro de autorizar los materiales seleccionados para producción?"

                If obj.getMaterialesParaAgregarEnInventario(listaMateriales).Rows.Count > 0 Then
                    Dim v As New InventarioInicialForm
                    v.lblMensaje.Text = "Se autorizará(n) a producción " & listaMateriales.Count & " material(es)"
                    v.list = listaMateriales
                    v.ShowDialog()
                Else
                    obj.AutorizarMaterialProduccion(listaMateriales)
                    objExito.mensaje = "Se autorizaron a producción con éxito " & vbCrLf & listaMateriales.Count & " materiales"
                    objExito.ShowDialog()
                End If
                buscar()
            Else
                objMensaje.mensaje = "Seleccione algún material directo" & vbCrLf & "que pertenezca a su nave" & vbCrLf & "y que ta tenga un precio" & vbCrLf & "para poder autorizarlo a producción"
                objMensaje.ShowDialog()
            End If
        Else
            listaMateriales.Clear()
            Seleccionados = 0
            Tools.MostrarMensaje(Mensajes.Warning, "No cuentas con el permiso para autorizar los materiales seleccionados a produccion")
            grvMaterial.ClearSelection()
            'cargarMateriales(cmbNave.SelectedValue, activo)
        End If


    End Sub

    Private Sub btnAutorizarProduccion_Click(sender As Object, e As EventArgs) Handles btnAutorizarProduccion.Click
        Try
            If grvMaterial.RowCount > 0 Then
                AutorizarProduccion()
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub cbxTodo_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTodo.CheckedChanged
    '    'For value = 0 To grdMateriales.Rows.Count - 1
    '    '    grdMateriales.Rows(value).Cells(" ").Value = 0
    '    'Next
    '    For value = 0 To grdMateriales.Rows.Count - 1
    '        validarSeleccionRow(value)
    '    Next
    'End Sub

    'Public Sub validarSeleccionRow(ByVal row As Integer)
    '    Try
    '        If grdMateriales.Rows(row).Cells("Nave Desarrolla").Text = cmbNave.Text And grdMateriales.Rows(row).Cells("Tipo").Text = "DIRECTO" And
    '            grdMateriales.Rows(row).Cells("Precio").Text <> "0.00" And grdMateriales.Rows(row).Cells("Estatus").Text <> "PRODUCCIÓN" Then

    '            If grdMateriales.Rows(row).Cells(" ").Value = 0 Then
    '                grdMateriales.Rows(row).Cells(" ").Value = 1
    '            Else
    '                grdMateriales.Rows(row).Cells(" ").Value = 0
    '            End If
    '        Else
    '            grdMateriales.Rows(row).Cells(" ").Value = 0
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    'Private Sub grdMateriales_KeyDown(sender As Object, e As KeyEventArgs)
    '    Try
    '        If e.KeyCode = Windows.Forms.Keys.Enter Then
    '            grdMateriales.PerformAction(UltraGridAction.ExitEditMode, False, False)
    '            Dim banda As UltraGridBand = grdMateriales.DisplayLayout.Bands(0)
    '            If grdMateriales.ActiveRow.HasNextSibling(True) Then
    '                Dim nextRow As UltraGridRow = grdMateriales.ActiveRow.GetSibling(SiblingRow.Next, True)
    '                grdMateriales.ActiveCell = nextRow.Cells(grdMateriales.ActiveCell.Column)
    '                e.Handled = True
    '                ' grdMateriales.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '            End If
    '        End If
    '    Catch ex As Exception
    '    End Try
    '    Try
    '        If e.KeyCode = Windows.Forms.Keys.Up Then
    '            grdMateriales.PerformAction(UltraGridAction.ExitEditMode, False, False)
    '            Dim banda As UltraGridBand = grdMateriales.DisplayLayout.Bands(0)
    '            If grdMateriales.ActiveRow.HasPrevSibling(True) Then
    '                Dim nextRow As UltraGridRow = grdMateriales.ActiveRow.GetSibling(SiblingRow.Previous, True)
    '                grdMateriales.ActiveCell = nextRow.Cells(grdMateriales.ActiveCell.Column)
    '                e.Handled = True
    '                'grdMateriales.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '            End If
    '        End If
    '    Catch ex As Exception
    '    End Try
    '    Try
    '        If e.KeyCode = Windows.Forms.Keys.Down Then
    '            grdMateriales.PerformAction(UltraGridAction.ExitEditMode, False, False)
    '            Dim banda As UltraGridBand = grdMateriales.DisplayLayout.Bands(0)
    '            If grdMateriales.ActiveRow.HasNextSibling(True) Then
    '                Dim nextRow As UltraGridRow = grdMateriales.ActiveRow.GetSibling(SiblingRow.Next, True)
    '                grdMateriales.ActiveCell = nextRow.Cells(grdMateriales.ActiveCell.Column)
    '                e.Handled = True
    '                'grdMateriales.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '            End If
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub btnEditMasivo_Click(sender As Object, e As EventArgs) Handles btnEditMasivo.Click
        If grvMaterial.RowCount > 0 Then
            cPrecio.Caption = "Precio Ant"
            cPrecioM.Caption = "Precio Nuevo"
            cPrecioM.Visible = True
            cPrecioM.VisibleIndex = 8
            lblGuardarMasivo.Visible = True
            btnGuardarMasivo.Visible = True
        Else
            Tools.MostrarMensaje(Mensajes.Warning, "No hay información")
        End If


    End Sub

    Private Sub grvMaterial_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grvMaterial.CustomDrawRowIndicator
        If (e.RowHandle >= 0) Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub

    Private Sub grvMaterial_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles grvMaterial.SelectionChanged
        Dim filasSeleccionadas As Integer()
        listaMateriales.Clear()
        Seleccionados = 0

        filasSeleccionadas = grvMaterial.GetSelectedRows()

        For Each filaIndex As Integer In filasSeleccionadas
            Dim dataRow As DataRowView = CType(grvMaterial.GetRow(filaIndex), DataRowView)

            If dataRow("Nave Desarrolla").ToString() = cmbNave.Text And dataRow("Tipo").ToString() = "DIRECTO" And
                 dataRow("Precio").ToString() <> "0.00" And dataRow("Estatus").ToString() <> "PRODUCCIÓN" And activo = 1 Then

                Seleccionados = Seleccionados + 1
                listaMateriales.Add(dataRow("ID").ToString())

            End If
        Next
    End Sub

    Private Sub grvMaterial_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles grvMaterial.CustomDrawCell
        If e.CellValue IsNot Nothing Then


            If e.Column.FieldName = "Precio" AndAlso e.CellValue.ToString() = "0" Then
                e.Appearance.ForeColor = Color.Salmon
            End If

            If e.Column.FieldName = "Estatus" AndAlso e.CellValue.ToString() = "DESARROLLO" Then
                e.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E9AFE")
            End If

            If e.Column.FieldName = "Estatus" AndAlso e.CellValue.ToString() = "PRODUCCIÓN" Then
                e.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#58FAAC")
            End If

            If e.Column.FieldName = "Precio" AndAlso Convert.ToDecimal(e.CellValue.ToString()) > 0 AndAlso ColorActu = 1 Then
                precioAnterior = e.CellValue.ToString()
            End If


            If e.Column.FieldName = "PrecioM" AndAlso e.CellValue IsNot Nothing AndAlso ColorActu = 1 Then
                precioActual = e.CellValue.ToString()

                If precioActual <> precioAnterior And precioActual <> "0" Then
                    e.Appearance.BackColor = Color.GreenYellow
                Else
                    e.Appearance.BackColor = Color.White
                End If
            End If


        End If
    End Sub



    Private Sub grvMaterial_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvMaterial.CellValueChanged
        Dim PrecioAnt As Double
        Dim PrecioNuevo As Double
        Dim IdMaterial As Integer

        PrecioAnt = grvMaterial.GetFocusedRowCellValue(cPrecio)
        IdMaterial = grvMaterial.GetFocusedRowCellValue(cIdMaterial)

        If e.Column.FieldName = cPrecioM.FieldName Then
            If grvMaterial.GetFocusedRowCellValue(cPrecioM) Is DBNull.Value Or grvMaterial.GetFocusedRowCellValue(cPrecioM) Is Nothing Then

                grvMaterial.SetFocusedRowCellValue(cPrecioM, PrecioAnt)
                Tools.MostrarMensaje(Mensajes.Warning, "Es necesario colocar un valor numerico mayor a 0")
            Else


                PrecioNuevo = grvMaterial.GetRowCellValue(e.RowHandle, cPrecioM)

                If PrecioNuevo > 0 Then
                    If PrecioAnt = PrecioNuevo Then
                        ColorActu = 1
                        grvMaterial.RefreshRowCell(e.RowHandle, cPrecioM)
                    Else
                        ColorActu = 1
                        grvMaterial.RefreshRowCell(e.RowHandle, cPrecioM)
                    End If

                Else
                    grvMaterial.SetFocusedRowCellValue(cPrecioM, PrecioAnt)
                    Tools.MostrarMensaje(Mensajes.Warning, "El precio nuevo no puede ser menor o igual a 0")
                End If

            End If
        End If
    End Sub

    Private Sub btnGuardarMasivo_Click(sender As Object, e As EventArgs) Handles btnGuardarMasivo.Click
        Dim dtVMaterial As DataView = DirectCast(grvMaterial.DataSource, DataView)
        Dim objConfirmacion As New Tools.ConfirmarForm
        Dim dtMaterial As New DataTable()
        Dim obj As New MaterialesBU
        Dim ObjMaterial As New Material
        Dim objMaterialInventario As New MaterialInventario
        Dim dtTipoNave As New DataTable
        Dim tablePreciosDeMaterial As New DataTable()
        Dim tipoNave As String = ""
        Dim estatusAutorizado As String = ""
        Dim IdNave As Integer
        Dim IdProveedor As Integer
        Dim IdMaterialNave As Integer
        Dim ActivoMaterial As Boolean
        Dim IdMaterial As Integer
        Dim PrecioNuevo As Double
        Dim Material As String
        Dim dtMaterialNaveID As DataTable
        Dim dtDageProveedor As DataTable
        Dim CantActualizados As Integer
        Dim ActualizadoExito As Integer
        Dim critico As Integer


        For Each column As DataColumn In dtVMaterial.Table.Columns
            dtMaterial.Columns.Add(column.ColumnName, column.DataType)
        Next

        For Each rowView As DataRowView In dtVMaterial
            Dim row As DataRow = dtMaterial.NewRow()
            For Each column As DataColumn In dtVMaterial.Table.Columns
                row(column.ColumnName) = rowView(column.ColumnName)
            Next
            dtMaterial.Rows.Add(row)
        Next

        Dim dtResultados As DataTable = dtMaterial.Clone()

        Dim RegistrosModificados = From row As DataRow In dtMaterial.Rows.Cast(Of DataRow)()
                                   Let precio As Double = Convert.ToDouble(row("Precio"))
                                   Let precioM As Double = Convert.ToDouble(row("PrecioM"))
                                   Where precio <> precioM
                                   Select row

        dtResultados = RegistrosModificados.CopyToDataTable()


        CantActualizados = dtResultados.Rows.Count
        Try
            objConfirmacion.mensaje = "¿Desea Guardar el nuevo precio capturado para los materiales modificados?"
            If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then

                For Each dtRow As DataRow In dtResultados.Rows
                    IdNave = dtRow("Nave")
                    IdMaterialNave = dtRow("idMaterialNave")
                    IdMaterial = dtRow("ID")
                    PrecioNuevo = dtRow("PrecioM")
                    Material = dtRow("Material")
                    critico = dtRow("Crítico")
                    IdProveedor = dtRow("IdProveedor")

                    dtTipoNave = obj.SaberTipoNave(IdNave)
                    If dtTipoNave.Rows(0).Item(0) = True Then
                        'Nave que desarrolla
                        tipoNave = "D"
                    Else
                        'Nave que produce
                        tipoNave = "P"
                    End If

                    tablePreciosDeMaterial = obj.getPreciosMateriales(IdMaterialNave)

                    Dim resultadosFiltrados = From row In tablePreciosDeMaterial.AsEnumerable()
                                              Where row.Field(Of Integer)("IdProveedor") = IdProveedor
                                              Select row

                    Dim dtPrecioMaterial As DataTable = tablePreciosDeMaterial.Clone()

                    For Each row In resultadosFiltrados
                        dtPrecioMaterial.ImportRow(row)
                    Next
                    ActivoMaterial = dtPrecioMaterial.Rows(0).Item("Activo")

                    If ActivoMaterial Then
                        estatusAutorizado = obj.getEstatusAutorizado(IdMaterial)
                        ActulizarPrecioMaterial(dtPrecioMaterial, IdMaterialNave, IdNave, PrecioNuevo, Material, IdMaterial)

                        If estatusAutorizado = "P" Then
                            For Each FilaPrecio As DataRow In dtPrecioMaterial.Rows

                                If obj.ExisteInventarioMaterialProveedor(IdMaterialNave, FilaPrecio("idProveedor")) = False Then
                                    dtMaterialNaveID = New DataTable
                                    objMaterialInventario = New MaterialInventario
                                    objMaterialInventario.invn_cantidad = 0
                                    objMaterialInventario.invn_factorconversion = FilaPrecio("Factor de conversión")
                                    objMaterialInventario.invn_inventariototal = 0
                                    objMaterialInventario.invn_movimientoinventarioid = 1
                                    objMaterialInventario.invn_precio = PrecioNuevo
                                    objMaterialInventario.invn_proveedorid = FilaPrecio("idProveedor")
                                    objMaterialInventario.invn_umc = FilaPrecio("idumprov")
                                    objMaterialInventario.invn_ump = FilaPrecio("idumprod")
                                    objMaterialInventario.invn_monedaid = FilaPrecio("IdMoneda")
                                    dtMaterialNaveID = obj.getidMaterialNavesXidMaterial(IdMaterial)

                                    For Each FilaNaveMAterial As DataRow In dtMaterialNaveID.Rows
                                        dtDageProveedor = New DataTable
                                        'Si no existe el proveedor relaccionarlo con la nave
                                        dtDageProveedor = obj.getProveedorAsignado(FilaPrecio("dageproveedorid"), FilaNaveMAterial("mn_idNave").ToString())
                                        If dtDageProveedor.Rows.Count = 0 Then
                                            obj.insertProveedorNave(FilaPrecio("dageproveedorid"), FilaNaveMAterial("mn_idNave").ToString())
                                        End If

                                        objMaterialInventario.invn_naveid = FilaNaveMAterial("mn_idNave").ToString()
                                        objMaterialInventario.invn_materialnaveid = FilaNaveMAterial("mn_materialNaveid").ToString()
                                        obj.insertarInventarioNave(objMaterialInventario)

                                    Next

                                Else
                                    If obj.ExisteInventarioMaterialProveedorPrecio(IdMaterial, FilaPrecio("idProveedor"), FilaPrecio("Precio")) = False Then
                                        dtMaterialNaveID = New DataTable
                                        objMaterialInventario = New MaterialInventario
                                        objMaterialInventario.invn_cantidad = 0
                                        objMaterialInventario.invn_factorconversion = FilaPrecio("Factor de conversión")
                                        objMaterialInventario.invn_inventariototal = 0
                                        objMaterialInventario.invn_movimientoinventarioid = 1
                                        objMaterialInventario.invn_precio = PrecioNuevo
                                        objMaterialInventario.invn_proveedorid = FilaPrecio("idProveedor")
                                        objMaterialInventario.invn_umc = FilaPrecio("idumprov")
                                        objMaterialInventario.invn_ump = FilaPrecio("idumprod")
                                        objMaterialInventario.invn_monedaid = FilaPrecio("IdMoneda")
                                        dtMaterialNaveID = obj.getidMaterialNavesXidMaterial(IdMaterial)

                                        For Each FilaNaveMAterial As DataRow In dtMaterialNaveID.Rows
                                            dtDageProveedor = New DataTable
                                            'Si no existe el proveedor relaccionarlo con la nave
                                            dtDageProveedor = obj.getProveedorAsignado(FilaPrecio("dageproveedorid"), FilaNaveMAterial("mn_idNave").ToString())
                                            If dtDageProveedor.Rows.Count = 0 Then
                                                obj.insertProveedorNave(FilaPrecio("dageproveedorid"), FilaNaveMAterial("mn_idNave").ToString())
                                            End If

                                            objMaterialInventario.invn_naveid = FilaNaveMAterial("mn_idNave").ToString()
                                            objMaterialInventario.invn_materialnaveid = FilaNaveMAterial("mn_materialNaveid").ToString()
                                            obj.insertarInventarioNave(objMaterialInventario)

                                        Next

                                    Else
                                        objMaterialInventario = New MaterialInventario

                                        objMaterialInventario.invn_precio = PrecioNuevo
                                        objMaterialInventario.invn_proveedorid = FilaPrecio("idProveedor")
                                        objMaterialInventario.invn_materialnaveid = IdMaterialNave
                                        objMaterialInventario.invn_umc = FilaPrecio("idumprov")
                                        objMaterialInventario.invn_ump = FilaPrecio("idumprod")
                                        objMaterialInventario.invn_factorconversion = FilaPrecio("Factor de conversión")
                                        obj.ActualizarInventarioNave(objMaterialInventario)

                                    End If
                                End If
                            Next


                        End If
                        ObjMaterial.activo = 1

                        obj.updateMaterial2(ObjMaterial, IdMaterialNave) 'Actualiza material en say
                        ObjMaterial.materialId = IdMaterial
                        ObjMaterial.critico = critico
                        obj.ActualizaMaterialCritico(ObjMaterial)

                        ActualizadoExito += 1
                    Else
                        Tools.MostrarMensaje(Mensajes.Warning, "El siguiente ID: " + dtRow("ID").ToString() + " no tiene un precio activo, intenta con otro material")
                        Exit For
                    End If

                Next

                If ActualizadoExito = CantActualizados Then
                    Tools.MostrarMensaje(Mensajes.Success, "El nuevo precio de los materiales fue actualizado correctamente")
                    cPrecio.Caption = "Precio"
                    cPrecioM.Caption = "Precio Nuevo"
                    cPrecioM.Visible = False
                    lblGuardarMasivo.Visible = False
                    btnGuardarMasivo.Visible = False
                    cargarMateriales(cmbNave.SelectedValue, activo)
                End If


            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ocurrio un error al tratar de actualizar el precio del material")
        End Try


    End Sub



    Public Sub ActulizarPrecioMaterial(dtPrecioMaterial As DataTable, IdMatNave As Integer, IdNave As Integer, Precio As Double, Material As String, IdMaterial As Integer)
        Dim dtNaveDesarrolla As New DataTable
        Dim usuarioModificoId As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim usuarioModifico As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        Dim obj As New MaterialesBU
        Dim idNaveDesarrolla As Integer = 0
        Dim precioMaterial As New Entidades.PrecioMaterial
        Dim dtProveedor As New DataTable

        Try
            dtNaveDesarrolla = obj.getNaveDesarrolla(IdMatNave)
            For Each row As DataRow In dtNaveDesarrolla.Rows
                idNaveDesarrolla = row(0)
                Exit For
            Next

            If idNaveDesarrolla = IdNave Then 'Copiar precios a naves de producción
                For Each row As DataRow In dtPrecioMaterial.Rows
                    obj.asignarProveedor(IdNave, row("dageproveedorid"))
                    precioMaterial.idMaterialSICY = 0
                    precioMaterial.idMaterialNave = IdMatNave
                    precioMaterial.naveId = row("nave_naveid")
                    precioMaterial.proveedordgId = row("dageproveedorid")
                    precioMaterial.precioUnitario = Precio
                    precioMaterial.proveedorId = row("idProveedor")
                    precioMaterial.proveedor = row("Proveedor")
                    precioMaterial.existe = row("Existe")
                    precioMaterial.preciosmaterialid = row("PrecioMaterialId")
                    precioMaterial.equivalenciaUMP = row("Factor de conversión")
                    precioMaterial.umc = row("umc")
                    precioMaterial.ump = row("ump")
                    precioMaterial.idumc = row("idumprov")
                    precioMaterial.idump = row("idumprod")
                    precioMaterial.descripcion = Material.Trim
                    precioMaterial.descripcionProv = row("Descripción Material Proveedor")
                    precioMaterial.claveProveedor = If(IsDBNull(row("clave")), "", row("clave"))

                    precioMaterial.tiempodeEntrega = row("Días Entrega")
                    precioMaterial.monedaId = row("IdMoneda")
                    precioMaterial.navedesarrollaid = IdNave 'row("IdNaveAlta")
                    precioMaterial.naveDesarrolla = row("Nave Alta")
                    precioMaterial.fechaRegistro = row("Registro")
                    precioMaterial.origenpreciomaterial = If(IsDBNull(row("origenprecio")), "", row("origenprecio"))
                    Dim tablausuario As DataTable
                    Dim objj As New MaterialesBU
                    Dim usuario As String = row("Usuario Alta")
                    tablausuario = objj.GetIdUsuario(usuario)
                    If tablausuario.Rows.Count > 0 Then
                        precioMaterial.usuarioCreoid = tablausuario.Rows(0).Item(0)
                    Else
                        precioMaterial.usuarioCreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    End If
                    precioMaterial.usuarioModificoid = usuarioModificoId
                    precioMaterial.usuarioModifico = usuarioModifico

                    If precioMaterial.existe = 0 Then
                        obj.removerPreciosConMismoProveedorXnave(precioMaterial.proveedorId, precioMaterial.idMaterialNave) 'Remueve todos los precios del mismo proveedor asignados a ese material de la nave
                        obj.insertPrecioMaterial(precioMaterial, 2)        'Inserta el nuevo precio del material en say

                    ElseIf precioMaterial.existe = 1 Then
                        obj.removerPreciosConMismoProveedorXnave(precioMaterial.proveedorId, precioMaterial.idMaterialNave) 'Remueve todos los precios del mismo proveedor asignados a ese material de la nave
                        obj.insertPrecioMaterial(precioMaterial, 2)    'Inserta nuevo precio actualizado
                    End If


                Next

                dtNaveDesarrolla = obj.getidMaterialNavesXidMaterial(IdMaterial)
                For Each row As DataRow In dtPrecioMaterial.Rows
                    For Each row2 As DataRow In dtNaveDesarrolla.Rows
                        If row2(0) <> IdNave Then
                            dtProveedor = obj.getProveedorAsignado(row("dageproveedorid"), row2(0))
                            If dtProveedor.Rows.Count = 0 Then
                                obj.insertProveedorNave(row("dageproveedorid"), row2(0))
                            End If
                            precioMaterial.idMaterialSICY = 0
                            precioMaterial.idMaterialNave = row2(1)
                            precioMaterial.naveId = row2(0)
                            precioMaterial.precioUnitario = Precio
                            precioMaterial.proveedorId = row("idProveedor")
                            precioMaterial.proveedordgId = row("dageproveedorid")
                            precioMaterial.proveedor = row("Proveedor")
                            precioMaterial.preciosmaterialid = row("PrecioMaterialId")
                            precioMaterial.equivalenciaUMP = row("Factor de conversión")
                            precioMaterial.umc = row("umc")
                            precioMaterial.ump = row("ump")
                            precioMaterial.idumc = row("idumprov")
                            precioMaterial.idump = row("idumprod")
                            precioMaterial.descripcion = Material.Trim
                            precioMaterial.descripcionProv = row("Descripción Material Proveedor")
                            precioMaterial.claveProveedor = If(IsDBNull(row("clave")), "", row("clave"))
                            precioMaterial.origenpreciomaterial = If(IsDBNull(row("origenprecio")), "", row("origenprecio"))
                            precioMaterial.tiempodeEntrega = row("Días Entrega")
                            precioMaterial.monedaId = row("IdMoneda")
                            precioMaterial.existe = row("Existe")
                            precioMaterial.navedesarrollaid = row("IdNaveAlta")
                            precioMaterial.naveDesarrolla = row("Nave Alta")
                            Dim tablausuario As DataTable
                            Dim objj As New MaterialesBU
                            Dim usuario As String = row("Usuario Alta")
                            tablausuario = objj.GetIdUsuario(usuario)
                            If tablausuario.Rows.Count > 0 Then
                                precioMaterial.usuarioCreoid = tablausuario.Rows(0).Item(0)
                            Else
                                precioMaterial.usuarioCreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                            End If
                            If precioMaterial.existe = 0 Then
                                obj.removerPreciosConMismoProveedorXnave(precioMaterial.proveedorId, precioMaterial.idMaterialNave) 'Remueve todos los precios del mismo proveedor asignados a ese material de la nave
                                obj.insertPrecioMaterial(precioMaterial, 2)        'Inserta el nuevo precio del material en say

                            ElseIf precioMaterial.existe = 1 Then
                                obj.removerPreciosConMismoProveedorXnave(precioMaterial.proveedorId, precioMaterial.idMaterialNave) 'Remueve todos los precios del mismo proveedor asignados a ese material de la nave
                                obj.insertPrecioMaterial(precioMaterial, 2)        'Inserta nuevo precio actualizado

                            End If
                        End If
                    Next
                Next

            Else
                For Each row As DataRow In dtPrecioMaterial.Rows


                    obj.asignarProveedor(IdNave, row("dageproveedorid"))
                    precioMaterial.idMaterialSICY = 0
                    precioMaterial.idMaterialNave = IdMatNave
                    precioMaterial.naveId = row("nave_naveid") ' idNave
                    precioMaterial.precioUnitario = Precio
                    precioMaterial.proveedorId = row("idProveedor")
                    precioMaterial.proveedordgId = row("dageproveedorid")
                    precioMaterial.proveedor = row("Proveedor")
                    precioMaterial.existe = row("Existe")
                    precioMaterial.preciosmaterialid = row("PrecioMaterialId")
                    precioMaterial.equivalenciaUMP = row("Factor de conversión")
                    precioMaterial.umc = row("umc")
                    precioMaterial.ump = row("ump")
                    precioMaterial.idumc = row("idumprov")
                    precioMaterial.idump = row("idumprod")
                    precioMaterial.descripcion = Material
                    precioMaterial.descripcionProv = row("Descripción Material Proveedor")
                    precioMaterial.claveProveedor = If(IsDBNull(row("clave")), "", row("clave"))
                    precioMaterial.tiempodeEntrega = row("Días Entrega")
                    precioMaterial.monedaId = row("IdMoneda")
                    precioMaterial.existe = row("Existe")
                    precioMaterial.fechaRegistro = row("Registro")

                    If IsDBNull(row("origenprecio")) Then
                        precioMaterial.origenpreciomaterial = " "
                    Else
                        precioMaterial.origenpreciomaterial = row("origenprecio")
                    End If

                    Dim X = row("IdNaveAlta")
                    If row("IdNaveAlta") <> 0 Then
                        precioMaterial.navedesarrollaid = row("IdNaveAlta")
                    Else
                        precioMaterial.navedesarrollaid = IdNave
                    End If
                    Dim tablausuario As DataTable
                    Dim objj As New MaterialesBU
                    Dim usuario As String = row("Usuario Alta")
                    tablausuario = objj.GetIdUsuario(usuario)
                    If tablausuario.Rows.Count > 0 Then
                        precioMaterial.usuarioCreoid = tablausuario.Rows(0).Item(0)
                    Else
                        precioMaterial.usuarioCreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    End If

                    precioMaterial.usuarioModifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    precioMaterial.usuarioModificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

                    If precioMaterial.existe = 0 Then
                        obj.removerPreciosConMismoProveedorXnave(precioMaterial.proveedorId, precioMaterial.idMaterialNave) 'Remueve todos los precios del mismo proveedor asignados a ese material de la nave
                        obj.insertPrecioMaterial(precioMaterial, 2)        'Inserta el nuevo precio del material en say

                    ElseIf precioMaterial.existe = 1 Then
                        obj.removerPreciosConMismoProveedorXnave(precioMaterial.proveedorId, precioMaterial.idMaterialNave) 'Remueve todos los precios del mismo proveedor asignados a ese material de la nave
                        obj.insertPrecioMaterial(precioMaterial, 2)        'Inserta nuevo precio actualizado

                    End If

                Next
            End If

        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ocurrio un error al tratar de actualizar el precio del material")
        End Try

    End Sub


End Class