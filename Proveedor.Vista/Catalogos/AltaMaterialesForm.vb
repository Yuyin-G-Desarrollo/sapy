Imports System.Windows.Forms
Imports Proveedores.BU
Imports System.Drawing
Imports Infragistics.Win.UltraWinGrid
Imports Entidades
Imports System.Net.NetworkInformation
Imports Tools

Public Class AltaMaterialesForm
    Public idNaveDesarrolloMaterial As Integer = 0
    Public AccionMaterial As Integer = 0    ' Variable que indica al SP si se modificará o ingresará un material.   -- CAMBIO OAMB (10/08/2023)

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm
    Dim sep As Char
    Dim tablePreciosDeMaterial As New DataTable
    Dim tablaCaracterisiticas As New DataTable
    Public idMaterial As Integer = 0
    Public idMaterialSicy As Integer = 0
    Public idMaterialNave As Integer = 0
    Public idMaterialRemplazo As Integer = 0
    Public idNaveDesarrolla As Integer = 0
    Public idTam As Integer = 0
    Public idColor As Integer = 0
    Public estatus As Char
    Dim advertencia As New Tools.AdvertenciaForm
    Dim aviso As New Tools.AvisoForm
    Dim m As New Entidades.Material
    Public idNave As Integer = 0
    Public accion As String = ""    'Variable para saber si oprimió nuevo o editar (Sirve para aplicar los permisos correctamente)
    Public accion2 As String = ""    'Variable para saber si oprimió nuevo o editar (Sirve para aplicar los permisos correctamente)
    Dim cargada As Boolean = False  'variable para saber si ya acabo de cargar todos los componentes
    Dim listColores As New List(Of SKU)
    Dim listTamaños As New List(Of SKU)
    Dim listClasificaciones As New List(Of SKU)
    Dim listTipoMaterial As New List(Of SKU)
    Dim skuTipoMaterial As String = ""
    Dim skuClasificaciones As String = ""
    Dim skuTamaños As String = ""
    Dim skuColores As String = ""
    Dim sku As String = ""
    Dim renglon As Integer = 0
    Public nombre As String
    Public lista As New DataTable
    Public idcolor2, idtamano As Integer
    Dim bandera As Integer = 0
    Dim descripcion As String
    Public idMateriales As Integer
    Public EDITAR As Integer
    Public modificar As Integer = 0
    Public clasificacion As Integer
    Public categoria As Integer
    Public Material As String
    Public sku2 As String
    Public nave As Integer
    Dim precio As Integer = 0
    Dim proveedorid As Integer
    Dim preciosmaterialid As Integer
    Public activo As Integer = 0
    Public nuevo As Integer = 0
    Public NumeroPrecios As Integer = 0
    Public naveDesarrolla As Integer = 0
    Public exclusivo As Boolean
    Public TipoMaterial As String = ""
    Dim tipoNave As String = ""
    Dim naveDesarrollaMaterialTabla As DataTable
    Public naveDesarollaMaterial As String = ""
    Dim aux = 0
    Dim listaProveedoresEnPrecios As New List(Of Integer)
    Dim tipoMaterialSelecto As Integer = 0
    Dim estatusMaterial As Boolean
    Dim estatusmaterialnave As Boolean
    Public noPrecio As Boolean = False
    Public cerrar As Boolean
    Public copiado As Boolean = False
    Public precioSeleccionado As Integer = 0
    Public noGuardar As Boolean = False
    Public NombreNaveDesarrolla As String
    Dim exclusive As Boolean = False
    Public NombreNaveAlta As String = ""
    Dim ListaPrecioDesactivados As New List(Of Integer)
    Dim MaterialesEditados As New List(Of Entidades.MaterialInventario)

    Dim PMAterialesNaveDesarrollaIDMaterial As Integer = 0
    Dim ListaCaracteristicas As New List(Of String)

    Dim naveEsDesarrollo As String

    Private Sub AltaMaterialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Me.Text = System.Drawing.ContentAlignment.MiddleLeft
        inicial()
    End Sub
    Public Sub inicial()
        Dim obj As New MaterialesBU
        inicializarControles()
        crearTablaCaracteristicas()
        cargada = True
        txtNombre.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        cmbTipoMaterial.Focus()
        cmbTipoMaterial.Select()
        Dim p = cmbTipoMaterial.SelectedValue
        If estatus = "P" Or estatus = "p" Then
            If naveEsDesarrollo = "NO" Then
                lblEditar.Text = "   Material en producción, no editable"
                gbxCritico.Enabled = False
            ElseIf naveEsDesarrollo = "SI" Then
                lblEditar.Text = "   Material en producción, no editable, excepción campo 'Crítico'"
                gbxCritico.Enabled = True
            End If
            'lblEditar.Text = "   Material en producción, no editable"
            '15_ txtNombre.Enabled = False
            cmbCategoria.Enabled = False
            cmbClas.Enabled = False
            cmbTipoMaterial.Enabled = False
            'cmbColor.Enabled = False

            cmbDepartamento.Enabled = False
            cbxExclusivo.Enabled = False
            'gbxCritico.Enabled = False
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "ADMONPPCP") Then
                gbxActivo.Enabled = False
            Else
                gbxActivo.Enabled = True
            End If
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOEDITARTAMAÑO") Then
                cmbTam.Enabled = True
                cmbColor.Enabled = True
            Else
                cmbTam.Enabled = False
                cmbColor.Enabled = False
            End If
            gbxEstatus.Enabled = False
            '16_ grdCaracterisitcas.Enabled = False
            cmbMaterialRemplazo.Enabled = False
            'btnNuevoPrecio.Enabled = False
            'btnEditarPrecio.Enabled = False
            rdoProduccion.Checked = True
            rdoDesarrollo.Enabled = False
            cmbDepartamento.Enabled = False
            btnAgregarColor.Visible = False
            btnAgregarTamano.Visible = False
            btnAgregarDepartamento.Visible = False
            'objAdvertencia.mensaje = "Material en producción no editable, favor de notificar a diseño y/o desarrollo"
            'objAdvertencia.ShowDialog()
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "EDITARMATERIALPRODUCCION") Then
                Dim tbls As New DataTable
                tbls = obj.SaberTipoNave(idNave)
                If tbls.Rows(0).Item(0) = True Then
                    txtNombre.Enabled = True
                    grdCaracterisitcas.Enabled = True
                End If
            Else
                txtNombre.Enabled = False
                grdCaracterisitcas.Enabled = False
            End If
        Else
            rdoDesarrollo.Checked = True
        End If
        Try
            armarSKU()
            If modificar = 1 Then
                modificarSKU()
            End If
        Catch ex As Exception

        End Try
        If lista.Rows.Count = 0 Then
            cmbClas.SelectedValue = clasificacion
            cmbCategoria.SelectedValue = categoria
            cmbColor.SelectedValue = idcolor2
            cmbTam.SelectedValue = idtamano
            txtDescripcion.Text = nombre
            rdboActivo.Checked = True
            If exclusivo = True Then
                cbxExclusivo.Checked = True
            Else
                cbxExclusivo.Checked = False
            End If
        Else
            grdCaracterisitcas.DataSource = lista
            diseniogridCaracteristicasconsulta()
            cmbTipoMaterial.SelectedValue = tipoMaterialSelecto
            cmbClas.SelectedValue = clasificacion
            cmbCategoria.SelectedValue = categoria
            cmbColor.SelectedValue = idcolor2
            cmbTam.SelectedValue = idtamano
            txtDescripcion.Text = nombre
            If activo = 1 Then
                rdboActivo.Checked = True
            Else
                rdboInactivo.Checked = True
            End If
            If exclusivo = True Then
                cbxExclusivo.Checked = True
            Else
                cbxExclusivo.Checked = False
            End If
        End If
        If estatus = "P" Then
            rdoProduccion.Checked = True
            cbxExclusivo.Enabled = False
        Else
            rdoDesarrollo.Checked = True
        End If

        Dim X = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOCOMPRAS")
        Dim Y = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISODESARROLLO")

        Dim tablas As New DataTable
        tablas = obj.SaberTipoNave(idNave)
        If tablas.Rows(0).Item(0) = True Then
            'Nave que desarrolla
            tipoNave = "D"
        Else
            'Nave que produce
            tipoNave = "P"
            If accion = "NUEVO" Or accion2 = "NUEVO" Then
                cmbTipoMaterial.SelectedValue = 2
                rdboActivo.Checked = True
                cbxExclusivo.Enabled = False
                cmbTipoMaterial.Enabled = False
                'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "CAMBIOPRODUCCION") Then
                '    gbxEstatus.Enabled = True
                '    rdoDesarrollo.Enabled = True
                '    rdoProduccion.Enabled = True
                'Else
                gbxEstatus.Enabled = False
                rdoDesarrollo.Enabled = False
                rdoProduccion.Enabled = False
                'End If
            End If

        End If
        If activo = 1 Then
            rdboActivo.Checked = True
        Else
            rdboInactivo.Checked = True
        End If
        txtSKU.Text = sku2
        'If activo = 0 Then
        '    btnNuevoPrecio.Enabled = True
        '    btnEditarPrecio.Enabled = True
        'Else
        '    btnNuevoPrecio.Enabled = False
        '    btnEditarPrecio.Enabled = False
        'End If
        If nuevo = 1 Then
            rdoInactivoNave.Enabled = False
        End If
        Try
            If tipoMaterialSelecto = 1 Then
                cbxExclusivo.Enabled = True
            Else
                cbxExclusivo.Enabled = False
            End If
        Catch ex As Exception
        End Try
        'If Material = "DIRECTO" Or Material = " " Then
        '    cbxExclusivo.Enabled = True
        '    rdoDesarrollo.Enabled = True
        'Else
        '    cbxExclusivo.Enabled = False
        '    rdoDesarrollo.Enabled = False
        '    rdoProduccion.Checked = True
        'End If

        Dim tablass As New DataTable
        tablass = obj.SaberTipoNave(idNave)
        If tablass.Rows(0).Item(0) = True Then
            'Nave que desarrolla
            tipoNave = "D"
        Else
            'Nave que produce
            tipoNave = "P"
            If accion = "NUEVO" Or accion2 = "NUEVO" Then
                cmbTipoMaterial.SelectedValue = 2
                rdboActivo.Checked = True
                cmbTipoMaterial.Enabled = False
                cbxExclusivo.Enabled = False
                gbxActivoNave.Enabled = False
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "CAMBIOPRODUCCION") And cmbTipoMaterial.SelectedValue = 1 Then
                    gbxEstatus.Enabled = True
                    rdoDesarrollo.Enabled = True
                    rdoProduccion.Enabled = True
                Else
                    gbxEstatus.Enabled = False
                    rdoDesarrollo.Enabled = False
                    rdoProduccion.Enabled = False
                End If
            End If

        End If

        If accion = "NUEVO" Or accion2 = "NUEVO" Then
            Try
                If tablas.Rows(0).Item(0) = True Then
                    'Nave que desarrolla
                    tipoNave = "D"
                    rdoDesarrollo.Checked = True
                    rdoDesarrollo.Enabled = True
                    cbxExclusivo.Enabled = True
                    gbxActivoNave.Enabled = False
                    cmbTipoMaterial.SelectedValue = 1
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "CAMBIOPRODUCCION") And cmbTipoMaterial.SelectedValue = 1 Then
                        gbxEstatus.Enabled = True
                        rdoDesarrollo.Enabled = True
                        rdoProduccion.Enabled = True
                    Else
                        gbxEstatus.Enabled = False
                        rdoDesarrollo.Enabled = False
                        rdoProduccion.Enabled = False
                    End If
                Else
                    'Nave que produce
                    'cmbTipoMaterial.SelectedValue = 2
                    rdoProduccion.Checked = True
                    rdoDesarrollo.Enabled = False
                    tipoNave = "P"
                    cmbTipoMaterial.Enabled = False
                    cbxExclusivo.Enabled = False
                    rdboActivo.Checked = True
                    cmbTipoMaterial.SelectedValue = 2
                    cmbTipoMaterial.Enabled = False
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "CAMBIOPRODUCCION") And cmbTipoMaterial.SelectedValue = 1 Then
                        gbxEstatus.Enabled = True
                        rdoDesarrollo.Enabled = True
                        rdoProduccion.Enabled = True
                    Else
                        gbxEstatus.Enabled = False
                        rdoDesarrollo.Enabled = False
                        rdoProduccion.Enabled = False
                    End If
                End If
            Catch ex As Exception
            End Try
        End If

        Try
            If tipoNave = "P" Then
                If accion = "NUEVO" Or accion2 = "NUEVO" Then
                    cmbTipoMaterial.SelectedValue = 2
                    cmbTipoMaterial.Enabled = False
                    gbxActivoNave.Enabled = False
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ColoresMat", "AGREGAR") Then
                        btnAgregarColor.Enabled = True
                    Else
                        btnAgregarColor.Enabled = False
                    End If
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("tamanios", "AGREGAR") Then
                        btnAgregarTamano.Enabled = True
                    Else
                        btnAgregarTamano.Enabled = False
                    End If

                    cbxExclusivo.Enabled = False

                    btnAgregarDepartamento.Enabled = False
                    rdboActivo.Checked = True
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "CAMBIOPRODUCCION") And cmbTipoMaterial.SelectedValue = 1 Then
                        gbxEstatus.Enabled = True
                        rdoDesarrollo.Enabled = True
                        rdoProduccion.Enabled = True
                    Else
                        gbxEstatus.Enabled = False
                        rdoDesarrollo.Enabled = False
                        rdoProduccion.Enabled = False
                    End If
                End If

            End If
        Catch ex As Exception
        End Try

        Try
            NaveDesarrollaMAterial()
            If naveDesarrollaMaterialTabla.Rows(0).Item(0) = idNave Then
            Else
                rdoDesarrollo.Enabled = False
                rdoProduccion.Enabled = False
                cbxExclusivo.Enabled = False
                ' btnGuardar.Enabled = False
                cmbCategoria.Enabled = False
                cmbClas.Enabled = False
                cmbColor.Enabled = False
                cmbTam.Enabled = False
                '1_txtNombre.Enabled = False
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "EDITARMATERIALPRODUCCION") Then
                    Dim tbls As New DataTable
                    tbls = obj.SaberTipoNave(idNave)
                    If tbls.Rows(0).Item(0) = True Then
                        txtNombre.Enabled = True
                        grdCaracterisitcas.Enabled = True
                    End If
                Else
                    txtNombre.Enabled = False
                    grdCaracterisitcas.Enabled = False
                End If
                cmbDepartamento.Enabled = False
                gbxActivo.Enabled = False
                gbxEstatus.Enabled = False
                cbxExclusivo.Enabled = False
                'gbxCritico.Enabled = False
                If naveEsDesarrollo = "NO" Then
                    gbxCritico.Enabled = False
                ElseIf naveEsDesarrollo = "SI" Then
                    gbxCritico.Enabled = True
                End If
                cmbMaterialRemplazo.Enabled = False
                cmbTipoMaterial.Enabled = False

            End If
        Catch ex As Exception
            If accion = "NUEVO" Or accion2 = "NUEVO" Then
                gbxActivoNave.Enabled = False
                If cmbTipoMaterial.SelectedValue = 2 Then
                    rdoDesarrollo.Enabled = False
                    rdoProduccion.Enabled = False
                    rdboActivo.Checked = True
                    cbxExclusivo.Enabled = False
                Else
                    rdoDesarrollo.Enabled = True
                    rdoProduccion.Enabled = True
                    cbxExclusivo.Enabled = True
                End If
            Else
                rdoDesarrollo.Enabled = False
                rdoProduccion.Enabled = False
                cbxExclusivo.Enabled = True
            End If
        End Try

        If accion = "NUEVO" Then
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOCOMPRAS") And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISODESARROLLO") Then
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "CAMBIOPRODUCCION") And cmbTipoMaterial.SelectedValue = 1 Then
                    gbxEstatus.Enabled = True
                    rdoDesarrollo.Enabled = True
                    rdoProduccion.Enabled = True
                Else
                    gbxEstatus.Enabled = False
                    rdoDesarrollo.Enabled = False
                    rdoProduccion.Enabled = False
                End If

            ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISODESARROLLO") And tipoNave = "D" Then
                'cmbCategoria.Enabled = True
                'cmbClas.Enabled = True
                'btnAgregarColor.Enabled = True
                'btnAgregarTamano.Enabled = True
                'btnAgregarDepartamento.Enabled = True
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "CAMBIOPRODUCCION") And cmbTipoMaterial.SelectedValue = 1 Then
                    gbxEstatus.Enabled = True
                    rdoDesarrollo.Enabled = True
                    rdoProduccion.Enabled = True
                Else
                    gbxEstatus.Enabled = False
                    rdoDesarrollo.Enabled = False
                    rdoProduccion.Enabled = False
                End If

            ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOCOMPRAS") And tipoNave = "P" Then
                'cmbCategoria.Enabled = True
                'cmbClas.Enabled = True
                'btnAgregarColor.Enabled = True
                'btnAgregarTamano.Enabled = True
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "CAMBIOPRODUCCION") And cmbTipoMaterial.SelectedValue = 1 Then
                    gbxEstatus.Enabled = True
                    rdoDesarrollo.Enabled = True
                    rdoProduccion.Enabled = True
                Else
                    gbxEstatus.Enabled = False
                    rdoDesarrollo.Enabled = False
                    rdoProduccion.Enabled = False
                End If

            ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISODESARROLLO") And tipoNave = "P" Then
                objMensaje.mensaje = "No tiene permiso para dar de alta materiales indirectos"
                objMensaje.ShowDialog()
                cmbCategoria.Enabled = False
                cmbClas.Enabled = False
                cmbColor.Enabled = False
                cmbTam.Enabled = False
                txtNombre.Enabled = False
                gbxActivo.Enabled = False
                gbxEstatus.Enabled = False
                cbxExclusivo.Enabled = False
                cmbDepartamento.Enabled = False
                gbxCritico.Enabled = False
                cmbMaterialRemplazo.Enabled = False
                'btnGuardar.Enabled = False
                'btnNuevoPrecio.Enabled = False
                'btnEditarPrecio.Enabled = False
            ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOCOMPRAS") And tipoNave = "D" Then
                'objMensaje.mensaje = "No tiene permiso para dar de alta materiales indirectos"
                'objMensaje.ShowDialog()
                'cmbCategoria.Enabled = False
                'cmbClas.Enabled = False
                'cmbColor.Enabled = False
                'cmbTam.Enabled = False
                'txtNombre.Enabled = False
                'gbxActivo.Enabled = False
                'gbxEstatus.Enabled = False
                'cbxExclusivo.Enabled = False
                'btnGuardar.Enabled = False
                'btnNuevoPrecio.Enabled = False
                'btnEditarPrecio.Enabled = False
            Else
                'btnGuardar.Enabled = False
                btnNuevoPrecio.Enabled = False
                btnEditarPrecio.Enabled = False
                btnAgregarColor.Enabled = False
                btnAgregarTamano.Enabled = False
                btnAgregarDepartamento.Enabled = False
                cmbCategoria.Enabled = False
                cmbClas.Enabled = False
                cmbColor.Enabled = False
                cmbTam.Enabled = False
                txtNombre.Enabled = False
                gbxActivo.Enabled = False
                gbxEstatus.Enabled = False
                cmbDepartamento.Enabled = False
                cbxExclusivo.Enabled = False
                gbxCritico.Enabled = False
                cmbMaterialRemplazo.Enabled = False
                objMensaje.mensaje = "No tiene permisos para dar de alta materiales"
                objMensaje.ShowDialog()
            End If
        Else
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOCOMPRAS") And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISODESARROLLO") Then
                NaveDesarrollaMAterial()

                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "CAMBIOPRODUCCION") And naveDesarrollaMaterialTabla.Rows(0).Item(0) = idNave And
                    Material <> "INDIRECTO" And estatus <> "P" Then
                    gbxEstatus.Enabled = True
                    rdoDesarrollo.Enabled = True
                    rdoProduccion.Enabled = True
                Else
                    gbxEstatus.Enabled = False
                    rdoDesarrollo.Enabled = False
                    rdoProduccion.Enabled = False
                    cbxExclusivo.Enabled = False
                End If

            ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISODESARROLLO") And tipoNave = "D" Then
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "CAMBIOPRODUCCION") And naveDesarrollaMaterialTabla.Rows(0).Item(0) = idNave And
                    Material <> "INDIRECTO" And estatus <> "P" Then
                    gbxEstatus.Enabled = True
                    rdoDesarrollo.Enabled = True
                    rdoProduccion.Enabled = True
                Else
                    gbxEstatus.Enabled = False
                    rdoDesarrollo.Enabled = False
                    rdoProduccion.Enabled = False
                    cbxExclusivo.Enabled = False
                End If

            ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOCOMPRAS") And Material = "INDIRECTO" And tipoNave = "P" Or tipoNave = "D" Then
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "CAMBIOPRODUCCION") And naveDesarrollaMaterialTabla.Rows(0).Item(0) = idNave And
                    Material <> "INDIRECTO" And estatus <> "P" Then
                    gbxEstatus.Enabled = True
                    rdoDesarrollo.Enabled = True
                    rdoProduccion.Enabled = True
                Else
                    gbxEstatus.Enabled = False
                    rdoDesarrollo.Enabled = False
                    rdoProduccion.Enabled = False
                    cbxExclusivo.Enabled = False
                End If

            ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISODESARROLLO") And tipoNave = "P" Then
                objMensaje.mensaje = "No tiene permiso para modificar este tipo de materiales"
                objMensaje.ShowDialog()
                cmbCategoria.Enabled = False
                cmbClas.Enabled = False
                cmbColor.Enabled = False
                cmbTam.Enabled = False
                txtNombre.Enabled = False
                gbxActivo.Enabled = False
                gbxEstatus.Enabled = False
                cbxExclusivo.Enabled = False
                btnAgregarColor.Enabled = False
                btnAgregarTamano.Enabled = False
                btnAgregarDepartamento.Enabled = False
                gbxCritico.Enabled = False
                cmbMaterialRemplazo.Enabled = False
                cmbDepartamento.Enabled = False
            ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOCOMPRAS") And tipoNave = "D" Then
                objMensaje.mensaje = "No tiene permiso para modificar este tipo de materiales"
                objMensaje.ShowDialog()
                cmbCategoria.Enabled = False
                cmbClas.Enabled = False
                cmbColor.Enabled = False
                cmbTam.Enabled = False
                txtNombre.Enabled = False
                gbxActivo.Enabled = False
                gbxEstatus.Enabled = False
                gbxCritico.Enabled = False
                cmbDepartamento.Enabled = False
                cmbMaterialRemplazo.Enabled = False
                cbxExclusivo.Enabled = False
            Else
                'btnGuardar.Enabled = False
                btnNuevoPrecio.Enabled = False
                btnEditarPrecio.Enabled = False
                btnAgregarColor.Enabled = False
                btnAgregarTamano.Enabled = False
                btnAgregarDepartamento.Enabled = False
                cmbClas.Enabled = False
                cmbCategoria.Enabled = False
                txtNombre.Enabled = False
                cmbColor.Enabled = False
                cmbTam.Enabled = False
                cbxExclusivo.Enabled = False
                btnAgregarColor.Enabled = False
                btnAgregarTamano.Enabled = False
                btnAgregarDepartamento.Enabled = False
                cmbCategoria.Enabled = False
                cmbDepartamento.Enabled = False
                cmbClas.Enabled = False
                gbxCritico.Enabled = False
                cmbMaterialRemplazo.Enabled = False
                cmbColor.Enabled = False
                cmbTam.Enabled = False
                txtNombre.Enabled = False
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "ADMONPPCP") Then
                    gbxActivo.Enabled = False
                Else
                    gbxActivo.Enabled = True
                End If
                gbxEstatus.Enabled = False
                cbxExclusivo.Enabled = False
                cmbCategoria.Enabled = False
                cmbClas.Enabled = False
                objMensaje.mensaje = "No tiene permisos para modificar materiales " + Material + "S"
                objMensaje.ShowDialog()
            End If
        End If
        If accion = "NUEVO" Or accion2 = "NUEVO" Then
            Try
                If tablas.Rows(0).Item(0) = True Then
                    'Nave que desarrolla
                    tipoNave = "D"
                    gbxActivoNave.Enabled = False
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOCOMPRAS") Then
                        rdoDesarrollo.Checked = True
                        rdoDesarrollo.Enabled = True
                        cbxExclusivo.Enabled = False
                        rdboActivo.Checked = True
                        cmbTipoMaterial.SelectedValue = 2
                        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "CAMBIOPRODUCCION") And naveDesarrollaMaterialTabla.Rows(0).Item(0) = idNave And
                    Material <> "INDIRECTO" And estatus <> "P" Then
                            gbxEstatus.Enabled = True
                            rdoDesarrollo.Enabled = True
                            rdoProduccion.Enabled = True
                        Else
                            gbxEstatus.Enabled = False
                            rdoDesarrollo.Enabled = False
                            rdoProduccion.Enabled = False
                        End If

                    End If
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISODESARROLLO") Then
                        rdoDesarrollo.Checked = True
                        rdoDesarrollo.Enabled = True
                        cbxExclusivo.Enabled = True
                        rdboActivo.Checked = True
                        cmbTipoMaterial.SelectedValue = 1
                        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "CAMBIOPRODUCCION") And naveDesarrollaMaterialTabla.Rows(0).Item(0) = idNave And
                    Material <> "INDIRECTO" And estatus <> "P" Then
                            gbxEstatus.Enabled = True
                            rdoDesarrollo.Enabled = True
                            rdoProduccion.Enabled = True
                        Else
                            gbxEstatus.Enabled = False
                            rdoDesarrollo.Enabled = False
                            rdoProduccion.Enabled = False
                        End If

                    End If
                Else
                    'Nave que produce
                    'cmbTipoMaterial.SelectedValue = 2
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "CAMBIOPRODUCCION") And naveDesarrollaMaterialTabla.Rows(0).Item(0) = idNave And
                    Material <> "INDIRECTO" And estatus <> "P" Then
                        gbxEstatus.Enabled = True
                        rdoDesarrollo.Enabled = True
                        rdoProduccion.Enabled = True
                    Else
                        gbxEstatus.Enabled = False
                        rdoDesarrollo.Enabled = False
                        rdoProduccion.Enabled = False
                        cbxExclusivo.Enabled = False
                    End If

                    rdoProduccion.Checked = True
                    rdoDesarrollo.Enabled = False
                    tipoNave = "P"
                    cmbTipoMaterial.Enabled = False
                    cbxExclusivo.Enabled = False
                    rdboActivo.Checked = True
                    cmbTipoMaterial.SelectedValue = 2
                    cmbTipoMaterial.Enabled = False
                End If
            Catch ex As Exception
            End Try
        Else
            If activo = 0 Then
                txtNombre.Enabled = False
                cmbCategoria.Enabled = False
                cmbTipoMaterial.Enabled = False
                cmbClas.Enabled = False
                cmbColor.Enabled = False
                cmbTam.Enabled = False
                grdCaracterisitcas.Enabled = False
                cmbDepartamento.Enabled = False
                cmbMaterialRemplazo.Enabled = False
                btnGuardar.Visible = True
                btnNuevoPrecio.Visible = False
                gbxCritico.Enabled = False
                cmbDepartamento.Enabled = False
                cmbMaterialRemplazo.Enabled = False
                btnEditarPrecio.Visible = False
                lblGuardar.Visible = True
                lblAltaPrecio.Visible = False
                lblEditarPrecio.Visible = False
                cmbClas.Enabled = False
                cmbCategoria.Enabled = False
                txtNombre.Enabled = False
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "ADMONPPCP") Then
                    gbxActivo.Enabled = False
                Else
                    gbxActivo.Enabled = True
                End If
                gbxEstatus.Enabled = False
                rdboSiCritico.Enabled = False
                rdboNoCritico.Enabled = False
                rdoInactivoNave.Enabled = True
                rdoActivoNave.Enabled = True
                rdoInactivoNave.Checked = True
                cmbCategoria.Enabled = False
                cmbClas.Enabled = False
                noPrecio = True
                cmbClas.Enabled = False
                cmbCategoria.Enabled = False
                btnAgregarColor.Enabled = False
                btnAgregarDepartamento.Enabled = False
                btnAgregarTamano.Enabled = False
                cbxExclusivo.Enabled = False
                If estatusMaterial = True Then
                    rdboActivo.Checked = True
                Else
                    rdboInactivo.Checked = True
                End If
            Else
            End If
        End If

        'Try
        '    NaveDesarrollaMAterial()
        '    If naveDesarrollaMaterialTabla.Rows(0).Item(0) = idNave Then
        gbxActivoNave.Enabled = True
        rdoActivoNave.Enabled = True
        rdoInactivoNave.Enabled = True
        '    Else
        '        gbxActivoNave.Enabled = True
        '        rdoActivoNave.Enabled = True
        '        rdoInactivoNave.Enabled = False
        '    End If
        'Catch ex As Exception
        'End Try
        If cmbTipoMaterial.Text = "DIRECTO" Then
            cuentaPreciosActivos()
        End If


        For Each filaCaracteristica As UltraGridRow In grdCaracterisitcas.Rows
            ListaCaracteristicas.Add(filaCaracteristica.Cells("CARACTERISTICA").Value.ToString())
        Next

    End Sub



    Public Sub BloquearControlesMaterialProduccion(ByVal idNave As Integer)
        Dim obj = New MaterialesBU
        Dim dt As New DataTable


        dt = obj.ConsultaSiEsNaveDesarrollo(idNave)
        naveEsDesarrollo = dt.Rows(0).Item("NaveDesarrolla")

        If naveEsDesarrollo = "NO" Then
            lblEditar.Text = "   Material en producción, no editable"
            gbxCritico.Enabled = False
        ElseIf naveEsDesarrollo = "SI" Then
            lblEditar.Text = "   Material en producción, no editable, excepción campo 'Crítico'"
            gbxCritico.Enabled = True
        End If

        txtNombre.Enabled = False
        cmbCategoria.Enabled = False
        cmbClas.Enabled = False
        cmbTipoMaterial.Enabled = False
        cmbColor.Enabled = False
        cmbTam.Enabled = False
        cmbDepartamento.Enabled = False
        cbxExclusivo.Enabled = False
        'gbxCritico.Enabled = False
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "ADMONPPCP") Then
            gbxActivo.Enabled = False
        Else
            gbxActivo.Enabled = True
        End If
        gbxEstatus.Enabled = False
        grdCaracterisitcas.Enabled = False
        cmbMaterialRemplazo.Enabled = False
        'btnNuevoPrecio.Enabled = False
        'btnEditarPrecio.Enabled = False
        'rdoProduccion.Checked = True
        rdoProduccion.Enabled = False
        rdoDesarrollo.Enabled = False
        cmbDepartamento.Enabled = False
        btnAgregarColor.Visible = False
        btnAgregarTamano.Visible = False
        btnAgregarDepartamento.Visible = False
        'objAdvertencia.mensaje = "Material en producción no editable, favor de notificar a diseño y/o desarrollo"
        'objAdvertencia.ShowDialog()
    End Sub


    Private Sub inicializarControles()
        Try
            Me.Cursor = Cursors.WaitCursor
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy")
            If idMaterial = 0 Then
                txtIdMaterial.Text = ""
            Else
                txtIdMaterial.Text = idMaterial
            End If
            sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            llenarComboTipoMaterial()
            llenarComboCategorias(1)
            'llenarComboClasificaciones()
            llenarDepartamentos()
            'llenarColores()
            'llenarTamaños()
            getDatosDeMaterial()
            inicarTablaDePreciosDeMaterial()
            'llenarComboMaterialRemplazo(New Entidades.Material)
            aplicarPermisos()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            advertencia.mensaje = ex.Message
            advertencia.ShowDialog()
        End Try
        Dim x = cmbTipoMaterial.SelectedValue
        llenarComboMaterialRemplazo(m)
        txtSKU.Text = sku2
    End Sub
    Public Sub llenarColores(ByVal clasificacion As Integer)
        Dim obj As New MaterialesBU
        Dim lst As DataTable

        lst = obj.getColoresMateriales(clasificacion)
        lst.Rows.Add(New Object() {1, "NO APLICA", "00", 1, "00"})
        Dim lst2 As New DataTable

        lst2.Columns.Add("ID")
        lst2.Columns.Add("Color")
        lst2.Columns.Add("SKU")
        lst2.Columns.Add("Activo")
        lst2.Columns.Add("skuSistema")
        Dim nr As Integer = 0
        nr = lst.Rows.Count - 1
        For value = 0 To lst.Rows.Count - 1
            Dim a = lst.Rows(nr).Item("ID").ToString
            Dim b = lst.Rows(nr).Item("Color").ToString
            Dim c = lst.Rows(nr).Item("SKU").ToString
            Dim d = lst.Rows(nr).Item("Activo").ToString
            Dim e = lst.Rows(nr).Item("skuSistema").ToString
            lst2.Rows.Add(a, b, c, d, e)
            nr = nr - 1
        Next
        If Not lst.Rows.Count = 0 Then
            cmbColor.DataSource = lst2
            cmbColor.DisplayMember = "Color"
            cmbColor.ValueMember = "ID"
        Else
            lst.Rows.Add(New Object() {1, "NO APLICA", "00", 1, "00"})

            cmbColor.DataSource = lst2
            cmbColor.DisplayMember = "Tamaño"
            cmbColor.ValueMember = "ID"
        End If
        Dim skus As New SKU
        For Each row As DataRow In lst2.Rows
            skus = New SKU
            skus.id = row("ID").ToString
            skus.sku = row("SKU").ToString
            listColores.Add(skus)
        Next
    End Sub
    Public Sub llenarTamaños(ByVal clasificaciones As Integer)
        Dim obj As New MaterialesBU
        Dim lst As DataTable
        lst = obj.getTamañosMateriales(clasificaciones)
        lst.Rows.Add(New Object() {1, "NO APLICA", "00"})
        Dim lst3 As New DataTable

        lst3.Columns.Add("ID")
        lst3.Columns.Add("Tamaño")
        lst3.Columns.Add("SKU")
        Dim nr As Integer = 0
        nr = lst.Rows.Count - 1
        For value = 0 To lst.Rows.Count - 1
            Dim a = lst.Rows(nr).Item("ID").ToString
            Dim b = lst.Rows(nr).Item("Tamaño").ToString
            Dim c = lst.Rows(nr).Item("SKU").ToString
            lst3.Rows.Add(a, b, c)
            nr = nr - 1
        Next

        If Not lst.Rows.Count = 0 Then
            cmbTam.DataSource = lst3
            cmbTam.DisplayMember = "Tamaño"
            cmbTam.ValueMember = "ID"
        Else
            lst.Rows.Add(New Object() {1, "NO APLICA", "00"})
            cmbTam.DataSource = lst3
            cmbTam.DisplayMember = "Tamaño"
            cmbTam.ValueMember = "ID"
        End If
        Dim skus As New SKU
        For Each row As DataRow In lst3.Rows
            skus = New SKU
            skus.id = row("ID").ToString
            skus.sku = row("SKU").ToString
            listTamaños.Add(skus)
        Next
    End Sub
    Public Sub llenarDepartamentos()
        Dim obj As New MaterialesBU
        Dim lst As DataTable
        lst = obj.getDepartamentos(idNave)
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbDepartamento.DataSource = lst
            cmbDepartamento.DisplayMember = "dept_departamento"
            cmbDepartamento.ValueMember = "dept_idDepto"
        End If
    End Sub
    Public Sub llenarComboClasificaciones(ByVal categoria As Integer, ByVal directo As Integer)
        Dim obj As New MaterialesBU
        Dim lst As DataTable
        lst = obj.getClasificaciones(categoria, directo)
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbClas.DataSource = lst
            cmbClas.DisplayMember = "clas_nombreClas"
            cmbClas.ValueMember = "clas_idClasificacion"
        End If
        Dim skus As New SKU
        For Each row As DataRow In lst.Rows
            skus = New SKU
            skus.id = row("clas_idClasificacion").ToString
            skus.sku = row("clas_sku").ToString
            listClasificaciones.Add(skus)
        Next
    End Sub
    Public Sub llenarComboTipoMaterial()
        Dim obj As New MaterialesBU
        Dim lst As New DataTable
        lst = obj.getListaTipoMateriales()
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbTipoMaterial.DataSource = lst
            cmbTipoMaterial.DisplayMember = "tima_tipoMaterial"
            cmbTipoMaterial.ValueMember = "tima_idTipo"
        End If
        Dim skus As New SKU
        For Each row As DataRow In lst.Rows
            skus = New SKU
            skus.id = row("tima_idTipo").ToString
            skus.sku = row("tima_sku").ToString
            listTipoMaterial.Add(skus)
        Next
    End Sub
    Public Sub llenarComboMaterialRemplazo(ByVal ma As Entidades.Material)
        Dim obj As New MaterialesBU
        Dim lst As DataTable
        ma.materialId = idMaterial
        lst = obj.getListaMateriales(ma, idNave)
        cmbMaterialRemplazo.DataSource = lst
        cmbMaterialRemplazo.DisplayMember = "mate_descripcion"
        cmbMaterialRemplazo.ValueMember = "mate_materialid"
    End Sub
    Public Sub getDatosDeMaterial()
        Try
            If idMaterial > 0 Then
                Me.Cursor = Cursors.WaitCursor
                txtIdMaterial.Text = "" & idMaterial
                Dim obj As New MaterialesBU
                Dim datos As New DataTable


                datos = obj.getDatosMaterial(idMaterial, idNave, idMaterialNave)
                'grdCaracterisitcas.DataSource = caracteristicas
                For Each row As DataRow In datos.Rows
                    tipoMaterialSelecto = row("mate_tipodematerial")
                    cmbTipoMaterial.SelectedValue = tipoMaterialSelecto
                    cmbColor.SelectedValue = row("mate_idColor")
                    cmbTam.SelectedValue = row("mate_idTamaño")
                    txtDescripcion.Text = row("mate_descripcion")
                    estatusMaterial = row("mate_activo")
                    estatusmaterialnave = row("mn_activo")
                    If row("mate_autorizado") = "P" Then
                        rdoProduccion.Checked = True
                        gbxEstatus.Enabled = False
                        BloquearControlesMaterialProduccion(idNave)


                    Else
                        rdoDesarrollo.Checked = True
                    End If
                    Dim caracteristicas As New DataTable
                    caracteristicas = obj.consultaCaracteristicas(idMaterial)
                    grdCaracterisitcas.DataSource = obj.consultaCaracteristicas(idMaterial)
                    diseniogridCaracteristicasconsulta()
                    cmbCategoria.SelectedValue = row("mate_idCategoria")
                    cmbClas.SelectedValue = row("mate_idClasificacion")
                    cmbDepartamento.SelectedValue = row("mn_idDepartamento")
                    txtFecha.Text = row("mate_fechaderegistro")
                    If row("mn_critico") = True Then
                        rdboSiCritico.Checked = True
                        rdboNoCritico.Checked = False
                    Else
                        rdboSiCritico.Checked = False
                        rdboNoCritico.Checked = True
                    End If
                    If row("mn_activo") = True Then
                        rdoActivoNave.Checked = True
                        rdoInactivoNave.Checked = False
                    Else
                        rdoActivoNave.Checked = False
                        rdoInactivoNave.Checked = True
                    End If
                    If row("mate_exclusivo") = True Then
                        exclusive = True
                    Else
                        exclusive = False
                    End If
                    cmbMaterialRemplazo.SelectedValue = row("mn_idMaterialRemplazo")
                    txtSKU.Text = row("mate_sku")
                Next
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            advertencia.mensaje = "Surgió un error al cargar los datos. Error: " & ex.Message
            advertencia.ShowDialog()
        End Try
        Dim x = cmbTipoMaterial.SelectedValue
    End Sub

    Public Sub CargarCaracteristicas()
        Dim obj As New MaterialesBU
        Dim caracteristicas As New DataTable
        caracteristicas = obj.consultaCaracteristicas(idMaterial)
        grdCaracterisitcas.DataSource = obj.consultaCaracteristicas(idMaterial)
        diseniogridCaracteristicasconsulta()
    End Sub

    Public Sub llenarComboCategorias(tipo As Integer)
        Dim obj As New MaterialesBU
        Dim lstCateg As DataTable
        Dim NaveID As Integer = idNave

        If tipo = 1 Then
            lstCateg = obj.getCategorias(1, NaveID)
        Else
            lstCateg = obj.getCategorias(0, NaveID)
        End If

        If Not lstCateg.Rows.Count = 0 Then
            lstCateg.Rows.InsertAt(lstCateg.NewRow, 0)
            cmbCategoria.DataSource = lstCateg
            cmbCategoria.DisplayMember = "nombre"
            cmbCategoria.ValueMember = "idCat"
        End If
    End Sub
    Public Sub inicarTablaDePreciosDeMaterialDesarrollo()
        Dim obj As New MaterialesBU
        'tablePreciosDeMaterial = obj.getDatosPrecioXIdMaterialNAveDesarrollo2(idMaterial)
        tablePreciosDeMaterial = obj.ObtenerPrecioMaterialNaveDesarrollo(idMaterial, idNaveDesarrolloMaterial)
        grdAltaPrecio.DataSource = tablePreciosDeMaterial

        diseño()
        If tablePreciosDeMaterial.Rows.Count = 0 Then
            precio = 0
        Else
            precio = 1
        End If
        NumeroPrecios = grdAltaPrecio.Rows.Count
    End Sub
    Public Sub inicarTablaDePreciosDeMaterial()
        Dim obj As New MaterialesBU
        tablePreciosDeMaterial = obj.getPreciosMateriales(idMaterialNave)
        grdAltaPrecio.DataSource = tablePreciosDeMaterial
        diseño()
        If tablePreciosDeMaterial.Rows.Count = 0 Then
            precio = 0
        Else
            precio = 1
        End If
        NumeroPrecios = grdAltaPrecio.Rows.Count
        cuentaPreciosActivos()

    End Sub
    Public Sub cuentaPreciosActivos()
        Dim contador As Integer = 0
        For value = 0 To grdAltaPrecio.Rows.Count - 1
            If grdAltaPrecio.Rows(value).Cells("Activo").Value = True Then
                contador = contador + 1
            End If
        Next
        If contador > 1 Then
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "DESACTIVARPRECIOPROVEEDOR") Then
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISODESARROLLO") And tipoNave = "D" And
                    Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PRECIOS") And activo = 1 Then
                    If contador >= 1 And cbxExclusivo.Checked = True Then
                        cbxExclusivo.Enabled = False
                        btnNuevoPrecio.Enabled = False
                    End If
                    btnInactivar.Visible = True
                    lblInactivar.Visible = True
                ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISODESARROLLO") And tipoNave = "P" And
                    Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PRECIOS") And activo = 1 Then
                    If contador >= 1 And cbxExclusivo.Checked = True Then
                        cbxExclusivo.Enabled = False
                        btnNuevoPrecio.Enabled = False
                    End If
                    btnInactivar.Visible = False
                    lblInactivar.Visible = False
                    btnNuevoPrecio.Enabled = False
                ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOCOMPRAS") And tipoNave = "D" And
                    Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PRECIOS") And activo = 1 Then
                    If contador >= 1 And cbxExclusivo.Checked = True Then
                        cbxExclusivo.Enabled = False
                        btnNuevoPrecio.Enabled = False
                    End If
                    btnInactivar.Visible = True
                    lblInactivar.Visible = True
                    cbxExclusivo.Enabled = False
                    btnNuevoPrecio.Enabled = False
                ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOCOMPRAS") And tipoNave = "P" And
                    Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PRECIOS") And activo = 1 Then
                    If contador >= 1 And cbxExclusivo.Checked = True Then
                        cbxExclusivo.Enabled = False
                        btnNuevoPrecio.Enabled = False
                    End If
                    btnInactivar.Visible = True
                    lblInactivar.Visible = True
                    cbxExclusivo.Enabled = False
                    btnNuevoPrecio.Enabled = False
                End If
                'btnInactivar.Visible = True
                'lblInactivar.Visible = True
                'cbxExclusivo.Enabled = False
            Else
                cbxExclusivo.Enabled = True
                btnInactivar.Visible = False
                lblInactivar.Visible = False
                btnNuevoPrecio.Enabled = False
            End If
        ElseIf contador >= 1 And cbxExclusivo.Checked = True Then
            btnNuevoPrecio.Enabled = False
        Else
            btnInactivar.Visible = False
            lblInactivar.Visible = False
        End If
    End Sub
    Private Sub diseño()
        With grdAltaPrecio.DisplayLayout.Bands(0)
            .Columns("IdNaveAlta").Hidden = True
            .Columns("idProveedor").Hidden = True
            .Columns("Días Entrega").Hidden = False
            .Columns("idumprov").Hidden = True
            .Columns("idMoneda").Hidden = True
            .Columns("idumprod").Hidden = True
            .Columns("dageproveedorid").Hidden = True
            .Columns("idProveedor").Hidden = True
            .Columns("Existe").Hidden = True
            .Columns("precioMaterialId").Hidden = True
            .Columns("Usuario Modifico").Hidden = True
            .Columns("Precio").Format = "##,##0.00"
            .Columns("Factor de conversión").Format = "####0.00"
            .Columns("Precio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Factor de conversión").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            '.Columns("Días Entrega").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            '.Columns("Registro").Format = "dd/MM/yyyy  hh:mm"
            '.Columns("Fecha Modificacion").Format = "dd/MM/yyyy  hh:mm"
            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

            .Columns("seleccion").Width = 100
            .Columns("seleccion").Header.Caption = "Modificado"
            .Columns("Factor de conversión").Width = 70
            .Columns("Proveedor").Width = 150
            .Columns("Descripción Material Proveedor").Width = 200
            .Columns("Activo").Width = 50
            .Columns("Registro").Width = 70
            .Columns("Factor de conversión").Width = 70
            .Columns("Factor de conversión").Header.Caption = "Factor de" & vbCrLf & "Conversión"
            .Columns("Usuario Alta").Header.Caption = "Usuario" & vbCrLf & "Alta"
            .Columns("Modifico").Header.Caption = "Usuario" & vbCrLf & "Modifico"
            .Columns("Fecha Modificacion").Header.Caption = "Fecha" & vbCrLf & "Modificación"
            .Columns("Días Entrega").Header.Caption = "Días" & vbCrLf & "Entrega"
            .Columns("Nave Alta").Header.Caption = "Nave" & vbCrLf & "Alta"
            .Columns("umc").Header.Caption = "UMC"
            .Columns("ump").Header.Caption = "UMP"
            .Columns("nave_naveid").Hidden = True
            .Columns("origenprecio").Header.Caption = "Orígen" 'NACIONAL ó IMPORTADO

            .Columns("Registro").CellActivation = Activation.NoEdit
            .Columns("Fecha Modificacion").CellActivation = Activation.NoEdit
            .Columns("seleccion").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox



        End With
        grdAltaPrecio.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdAltaPrecio.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdAltaPrecio.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub
    Private Sub rdboActivo_CheckedChanged(sender As Object, e As EventArgs)
        If rdboActivo.Checked Then
            rdboInactivo.Checked = False
        End If
    End Sub
    Private Sub rdboInactivo_CheckedChanged(sender As Object, e As EventArgs)
        If rdboInactivo.Checked Then
            rdboActivo.Checked = False
        End If
    End Sub
    Private Sub rdboSiCritico_CheckedChanged(sender As Object, e As EventArgs) Handles rdboSiCritico.CheckedChanged
        If rdboSiCritico.Checked Then
            rdboNoCritico.Checked = False
        End If
        If rdboSiCritico.Checked = True Then
            cmbMaterialRemplazo.Enabled = True
            'Panel2.Enabled = True
        Else
            cmbMaterialRemplazo.Enabled = False
            'Panel2.Enabled = False
        End If
    End Sub
    Private Sub rdboNoCritico_CheckedChanged(sender As Object, e As EventArgs) Handles rdboNoCritico.CheckedChanged
        'If rdboNoCritico.Checked Then
        '    rdboSiCritico.Checked = False
        'End If
        'If rdboNoCritico.Checked = True Then
        '    cmbMaterialRemplazo.Enabled = False
        '    Panel2.Enabled = False
        'End If
        If rdboNoCritico.Checked = True Then
            cmbMaterialRemplazo.SelectedValue = 0
            cmbMaterialRemplazo.Enabled = False
        Else
            cmbMaterialRemplazo.Enabled = True
        End If
    End Sub
    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Try
            Dim obj As New MaterialesBU
            tablePreciosDeMaterial = obj.getPreciosMateriales(idMaterialNave)

            If grdAltaPrecio.Rows.Count > tablePreciosDeMaterial.Rows.Count Then
                objConfirmacion.mensaje = "Hay precios agregados que no se han guardado." & vbCrLf & "¿Desea salir sin guardar?"
                If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.Close()
                End If
            Else
                Me.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Dim nombreNAVEMAT As String = ""
    Public Sub nuevoPrecio()
        If Not txtDescripcion.Text.Trim = "" Then
            Dim form As New NuevoPrecioMaterialForm
            form.precioMaterial.descripcion = txtDescripcion.Text
            form.idMaterial = txtIdMaterial.Text
            form.idNave = idNave
            form.nuevo = 1
            form.NombreNaveDesarrolla = naveDesarollaMaterial
            form.lista = listaProveedoresEnPrecios
            form.ShowDialog()
            nombreNAVEMAT = form.NombreNaveDesarrolla
            Dim preciomaterial As Entidades.PrecioMaterial
            preciomaterial = form.precioMaterial
            Try
                If form.cerrado = False Then
                    If validarPrecioNuevo(preciomaterial.proveedorId) Then
                        Dim datarow As DataRow = tablePreciosDeMaterial.NewRow()
                        datarow(0) = 1
                        datarow(1) = preciomaterial.descripcionProv
                        datarow(2) = preciomaterial.proveedor
                        datarow(3) = preciomaterial.precioUnitario
                        datarow("idMoneda") = preciomaterial.monedaId
                        datarow("Moneda") = preciomaterial.moneda
                        datarow(6) = True
                        datarow(7) = preciomaterial.umc
                        datarow(8) = preciomaterial.equivalenciaUMP
                        datarow(9) = preciomaterial.ump
                        datarow(10) = preciomaterial.claveProveedor
                        'datarow(10) =  Date.Now
                        datarow(11) = preciomaterial.fechaRegistro
                        datarow(12) = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        datarow(16) = preciomaterial.proveedorId
                        datarow(17) = preciomaterial.existe
                        datarow(18) = preciomaterial.preciosmaterialid
                        datarow("idumprov") = preciomaterial.idumc
                        datarow("idumprod") = preciomaterial.idump
                        datarow("Días Entrega") = preciomaterial.tiempodeEntrega
                        datarow("IdNaveAlta") = idNaveDesarrolloMaterial ' nave NaveDesarrollaIDMaterial
                        datarow("Nave Alta") = NombreNaveAlta 'nombreNAVEMAT
                        datarow("dageproveedorid") = preciomaterial.proveedordgId
                        datarow("nave_naveid") = idNave
                        datarow("origenprecio") = preciomaterial.origenpreciomaterial

                        tablePreciosDeMaterial.Rows.Add(datarow)
                        grdAltaPrecio.DataSource = Nothing
                        grdAltaPrecio.DataSource = tablePreciosDeMaterial
                        diseño()
                    End If

                End If
            Catch ex As Exception
                advertencia.mensaje = "Información: " & ex.Message
                advertencia.ShowDialog()
            End Try
        Else
            advertencia.mensaje = "Antes de capturar un precio de material es obligatorio tener una descripción del material."
            advertencia.ShowDialog()
        End If
    End Sub
    Private Sub btnNuevoPrecio_Click(sender As Object, e As EventArgs) Handles btnNuevoPrecio.Click
        Try
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PRECIOS") Then
                If tipoNave = "P" And Material = "DIRECTO" Then
                    objMensaje.mensaje = "No puede Agregar precio." & vbCrLf & "No es nave de desarrollo"
                    objMensaje.ShowDialog()
                Else
                    If validarMaterialExclusivo() Then
                        NaveDesarrollaMAterial()
                        If naveDesarrollaMaterialTabla.Rows(0).Item(0) = idNave Then
                            nuevoPrecio()
                            AccionMaterial = 1
                        Else
                            For value = 0 To grdAltaPrecio.Rows.Count - 1
                                listaProveedoresEnPrecios.Add(grdAltaPrecio.Rows(value).Cells("idProveedor").Value)
                            Next
                            nuevoPrecio()
                            AccionMaterial = 1
                            'objMensaje.mensaje = "No puede Agregar precio." & vbCrLf & "No es nave de desarrollo"
                            'objMensaje.ShowDialog()
                            'btnNuevoPrecio.Enabled = False
                        End If
                    End If
                End If

                'ElseIf tipoNave = "D" And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PRECIOS") Then
                '    NaveDesarrollaMAterial()
                '    If naveDesarrollaMaterialTabla.Rows(0).Item(0) = idNave Then
                '        nuevoPrecio()
                '    Else
                '        For value = 0 To grdAltaPrecio.Rows.Count - 1
                '            listaProveedoresEnPrecios.Add(grdAltaPrecio.Rows(value).Cells("idProveedor").Value)
                '        Next
                '        nuevoPrecio()
                '        'objMensaje.mensaje = "No puede Agregar precio." & vbCrLf & "No es nave de desarrollo"
                '        'objMensaje.ShowDialog()
                '        'btnNuevoPrecio.Enabled = False
                '    End If
            Else
                objAdvertencia.mensaje = "No tiene permiso para agregar precios"
                objAdvertencia.ShowDialog()
            End If
        Catch ex As Exception
            If accion = "NUEVO" Then
                nuevoPrecio()
            End If
        End Try
    End Sub
    Public Sub agergarPrecioMaterial(precioMaterial As Entidades.PrecioMaterial)



    End Sub
    Private Sub txtEquivUMComp_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
    End Sub
    Private Sub txtEquivUMProv_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
    End Sub
    Public Sub editarPrecioShow()
        ' If estatus <> "P" Then
        Dim NombreNaveDesarrollaEdicion As String = String.Empty

        If txtDescripcion.Text.Length > 0 Then
            If grdAltaPrecio.Rows.Count > 0 Then
                If grdAltaPrecio.ActiveRow.Selected Then
                    If idNave = CInt(grdAltaPrecio.ActiveRow.Cells("nave_naveid").Text) Then

                        Dim form As New NuevoPrecioMaterialForm
                        form.idNave = idNave
                        form.naveDesarrolla = True
                        form.activo = activo
                        form.idMaterial = txtIdMaterial.Text
                        form.precioMaterial.descripcion = txtDescripcion.Text
                        form.precioMaterial.precioUnitario = grdAltaPrecio.ActiveRow.Cells("Precio").Text
                        'form.precioMaterial.tiempodeEntrega = grdAltaPrecio.ActiveRow.Cells("Días Entrega").Text
                        form.precioMaterial.proveedorId = grdAltaPrecio.ActiveRow.Cells("idProveedor").Text
                        form.precioMaterial.proveedor = grdAltaPrecio.ActiveRow.Cells("Proveedor").Text
                        form.precioMaterial.existe = grdAltaPrecio.ActiveRow.Cells("Existe").Text
                        form.precioMaterial.preciosmaterialid = grdAltaPrecio.ActiveRow.Cells("precioMaterialId").Text
                        form.precioMaterial.equivalenciaUMP = grdAltaPrecio.ActiveRow.Cells("Factor de conversión").Value
                        form.precioMaterial.umc = grdAltaPrecio.ActiveRow.Cells("umc").Text
                        form.precioMaterial.ump = grdAltaPrecio.ActiveRow.Cells("ump").Text
                        form.precioMaterial.naveDesarrolla = grdAltaPrecio.ActiveRow.Cells("Nave Alta").Text
                        form.precioMaterial.tiempodeEntrega = grdAltaPrecio.ActiveRow.Cells("Días Entrega").Text
                        form.cmbProveedorUM.Text = grdAltaPrecio.ActiveRow.Cells("umc").Text
                        form.cmbProduccionUM.Text = grdAltaPrecio.ActiveRow.Cells("ump").Text
                        form.txtTiempoEntrega.Text = grdAltaPrecio.ActiveRow.Cells("Días Entrega").Text
                        form.umpro = grdAltaPrecio.ActiveRow.Cells("umc").Text
                        form.umprod = grdAltaPrecio.ActiveRow.Cells("ump").Text
                        form.opmat = grdAltaPrecio.ActiveRow.Cells("origenprecio").Text
                        form.precioMaterial.descripcionProv = grdAltaPrecio.ActiveRow.Cells("Descripción Material Proveedor").Text
                        form.precioMaterial.claveProveedor = grdAltaPrecio.ActiveRow.Cells("Clave").Text
                        form.cmbProveedor.Enabled = False
                        NombreNaveDesarrollaEdicion = grdAltaPrecio.ActiveRow.Cells("Nave Alta").Text
                        form.cmbOrigen.Text = grdAltaPrecio.ActiveRow.Cells("origenprecio").Text

                        If cbxExclusivo.Checked = True Then
                            form.exclusivo = True
                        Else
                            form.exclusivo = False
                        End If
                        form.ShowDialog()

                        If Not form.cerrado Then
                            grdAltaPrecio.ActiveRow.Cells("Precio").Value = form.precioMaterial.precioUnitario
                            ' grdAltaPrecio.ActiveRow.Cells("Días Entrega").Value = form.precioMaterial.tiempodeEntrega
                            grdAltaPrecio.ActiveRow.Cells("idProveedor").Value = form.precioMaterial.proveedorId
                            grdAltaPrecio.ActiveRow.Cells("Proveedor").Value = form.precioMaterial.proveedor
                            grdAltaPrecio.ActiveRow.Cells("Existe").Value = form.precioMaterial.existe
                            grdAltaPrecio.ActiveRow.Cells("precioMaterialId").Value = form.precioMaterial.preciosmaterialid
                            grdAltaPrecio.ActiveRow.Cells("Factor de conversión").Value = form.precioMaterial.equivalenciaUMP
                            grdAltaPrecio.ActiveRow.Cells("umc").Value = form.precioMaterial.umc
                            grdAltaPrecio.ActiveRow.Cells("ump").Value = form.precioMaterial.ump
                            grdAltaPrecio.ActiveRow.Cells("Descripción Material Proveedor").Value = form.precioMaterial.descripcionProv
                            grdAltaPrecio.ActiveRow.Cells("Clave").Value = form.precioMaterial.claveProveedor
                            grdAltaPrecio.ActiveRow.Cells("idumprov").Value = form.precioMaterial.idumc
                            grdAltaPrecio.ActiveRow.Cells("idumprod").Value = form.precioMaterial.idump
                            grdAltaPrecio.ActiveRow.Cells("Días Entrega").Value = form.precioMaterial.tiempodeEntrega
                            grdAltaPrecio.ActiveRow.Cells("Moneda").Value = form.precioMaterial.moneda
                            grdAltaPrecio.ActiveRow.Cells("idMoneda").Value = form.precioMaterial.monedaId
                            grdAltaPrecio.ActiveRow.Cells("Nave Alta").Value = NombreNaveDesarrollaEdicion 'form.precioMaterial.naveDesarrolla
                            'grdAltaPrecio.ActiveRow.Cells("Usuario Alta").Value = form.precioMaterial.usuario
                            grdAltaPrecio.ActiveRow.Cells("Modifico").Value = form.precioMaterial.usuario

                            grdAltaPrecio.ActiveRow.Cells("Fecha Modificacion").Value = form.precioMaterial.fechaModificacion
                            grdAltaPrecio.ActiveRow.Cells("origenprecio").Value = form.cmbOrigen.SelectedValue
                            grdAltaPrecio.ActiveRow.Cells("seleccion").Value = 1

                            'MaterialesEditados As New List(Of Entidades.MaterialInventario)
                            Dim objInv As New Entidades.MaterialInventario
                            objInv.invn_proveedorid = grdAltaPrecio.ActiveRow.Cells("idProveedor").Value
                            objInv.invn_precio = grdAltaPrecio.ActiveRow.Cells("Precio").Value

                            MaterialesEditados.Add(objInv)
                            diseño()
                        End If

                    Else
                        advertencia.mensaje = "Da aviso a la nave que dió de alta el proveedor y precio para que haga la actualización del precio."
                        advertencia.ShowDialog()
                    End If
                End If
            End If
        Else
            advertencia.mensaje = "Antes de actualizar un precio de material es obligatorio tener una descripción del material."
            advertencia.ShowDialog()
        End If
        ' End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnEditarPrecio.Click
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISODESARROLLO") And tipoNave = "D" And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PRECIOS") Then
            editarPrecioShow()
            AccionMaterial = 2
        ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISODESARROLLO") And tipoNave = "P" And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PRECIOS") Then
            objMensaje.mensaje = "No puede modificar el precio" & vbCrLf & " no pertenece a su nave "
            objMensaje.ShowDialog()
        ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOCOMPRAS") And tipoNave = "D" And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PRECIOS") Then
            editarPrecioShow()
            AccionMaterial = 2
        ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOCOMPRAS") And tipoNave = "P" And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PRECIOS") Then
            editarPrecioShow()
            AccionMaterial = 2
        End If
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim EsActivo As Boolean = False

        If validarCampos() = False Then
            Return
        End If

        'If rdboActivo.Checked = True Then
        '    If grdAltaPrecio.Rows.Count = 0 Then
        '        'advertencia.mensaje = "Se debe de ingresar un precio."
        '        'advertencia.ShowDialog()
        '        'Return
        '    Else
        '        'For Each Fila As UltraGridRow In grdAltaPrecio.Rows
        '        '    If Fila.Cells("Activo").Value = True Then
        '        '        EsActivo = True
        '        '    End If
        '        'Next

        '        'If EsActivo = False Then
        '        '    advertencia.mensaje = "Se debe de ingresar un precio activo."
        '        '    advertencia.ShowDialog()
        '        '    Return
        '        'End If
        '    End If
        'End If

        If tipoNave = "D" Then
            If rdoProduccion.Checked = True Then
                If grdAltaPrecio.Rows.Count = 0 Then
                    advertencia.mensaje = "Se debe de ingresar un precio."
                    advertencia.ShowDialog()
                    Return
                Else
                    For Each Fila As UltraGridRow In grdAltaPrecio.Rows
                        If Fila.Cells("Activo").Value = True Then
                            EsActivo = True
                        End If
                    Next
                    If EsActivo = False Then
                        advertencia.mensaje = "Se debe de ingresar un precio activo."
                        advertencia.ShowDialog()
                        Return
                    End If
                End If
            End If
        End If



        If tipoNave = "D" Then
            If validarCampos() Then
                'If validarEstatusProduccion() Then
                validacion()

                If cerrar = True Then
                    Me.Close()
                Else
                    If noGuardar = True Then
                    Else
                        objConfirmacion.mensaje = "¿Desea Guardar el material capturado?"
                        If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                            If ValidarDesactivarMaterial() = False Then
                                Return
                            End If
                            DesactivarPrecioProveedor()
                            guardarDatosMaterial()
                            inicarTablaDePreciosDeMaterial()
                            accion = "EDITAR"
                            accion2 = "EDITAR"

                        End If
                        ' btnGuardar.Enabled = False
                        'End If
                        'guardarCaracterisiticas()
                    End If
                End If
            End If
        Else
            If validarCampos() Then
                validacion()
                If cerrar = True Then
                    Me.Close()
                Else
                    If noGuardar = True Then
                    Else
                        objConfirmacion.mensaje = "¿Desea Guardar el material capturado?"
                        If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                            If ValidarDesactivarMaterial() = False Then
                                Return
                            End If
                            DesactivarPrecioProveedor()
                            guardarDatosMaterial()
                            inicarTablaDePreciosDeMaterial()
                            accion = "EDITAR"
                            accion2 = "EDITAR"

                        End If
                        ' btnGuardar.Enabled = False
                        'End If
                        'guardarCaracterisiticas()
                    End If
                End If
            End If
        End If

        colorear()
    End Sub

    Public Function ValidarDesactivarMaterial() As Boolean
        Dim obj As New MaterialesBU
        Dim ExisteMAterialConsumo As Boolean = False

        If rdoInactivoNave.Checked = True Then

            If obj.ExisteMaterialActivoEnConsumo(idMaterial, idNave) = True Then
                advertencia.mensaje = "El Material no se puede inactivar debido a que es utilizado en los consumos."
                advertencia.ShowDialog()
                ExisteMAterialConsumo = False
            Else
                ExisteMAterialConsumo = True
            End If
        Else
            ExisteMAterialConsumo = True
        End If

        Return ExisteMAterialConsumo

    End Function

    Public Sub guardarCaracterisiticas()
        Dim Entidad As New Caracteristicas
        Dim objbu As New MaterialesBU

        If idMateriales = 0 Then
            idMateriales = CInt(objbu.idmaterial)
        End If
        Dim id As String = ""
        'ListaCaracteristicas


        Dim ExisteCaracteristica As Boolean = False
        Try


            For value = 0 To grdCaracterisitcas.Rows.Count - 1
                Try

                    id = grdCaracterisitcas.Rows(value).Cells("ID").Value.ToString.Trim

                    If String.IsNullOrEmpty(id) = False Then
                        objbu.ActualizarCaracteristica(id, grdCaracterisitcas.Rows(value).Cells("CARACTERISTICA").Value.ToString.Trim, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

                    Else
                        If grdCaracterisitcas.Rows(value).Cells("CARACTERISTICA").Value <> "" Then
                            Entidad.cara_descripcion = grdCaracterisitcas.Rows(value).Cells("CARACTERISTICA").Value
                        Else
                            Entidad.cara_descripcion = ""
                        End If

                        Entidad.cara_idmaterial = idMaterial
                        If grdCaracterisitcas.Rows(value).Cells(" ").Value = True Then
                            Entidad.cara_activo = "1"
                        Else
                            Entidad.cara_activo = "0"
                        End If
                        Entidad.cara_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        Entidad.cara_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
                        Entidad.cara_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        Entidad.cara_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
                        objbu.agregarCaracteristica(Entidad)

                    End If

                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
        End Try

    End Sub

    Public Sub guardarCaracterisiticasSimilitudes()
        Dim Entidad As New Caracteristicas
        Dim objbu As New MaterialesBU

        If idMateriales = 0 Then
            idMateriales = CInt(objbu.idmaterial)
        End If
        objbu.eliminarCaracteristica(idMaterial)
        For value = 0 To grdCaracterisitcas.Rows.Count - 1
            Try
                Dim ac As Integer = 0
                If grdCaracterisitcas.Rows(value).Cells(" ").Value.ToString = "True" Then
                    ac = 1
                Else
                    ac = 0
                End If
                objbu.insertarCaracteristica(grdCaracterisitcas.Rows(value).Cells("CARACTERISTICA").Value, idMaterial, ac, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            Catch ex As Exception
            End Try
        Next

    End Sub

    Function validarCampos() As Boolean
        Dim obj As New MaterialesBU
        Dim dato As New DataTable

        'If Not txtNombre.Text.Length > 0 Then
        '    advertencia.mensaje = "Campos obligatorios por capturar"
        '    advertencia.ShowDialog()
        '    txtDescripcion.Focus()
        '    lblNombre.ForeColor = Drawing.Color.Red
        '    Return False
        'End If
        If Not txtDescripcion.Text.Length > 0 Then
            advertencia.mensaje = "Campos obligatorios por capturar"
            advertencia.ShowDialog()
            txtDescripcion.Focus()
            Return False
        End If
        If Not cmbCategoria.SelectedIndex > 0 Then
            advertencia.mensaje = "Campos obligatorios por capturar"
            advertencia.ShowDialog()
            cmbCategoria.Focus()
            lblCategoria.ForeColor = Drawing.Color.Red
            Return False
        End If

        If Not cmbTipoMaterial.SelectedIndex > 0 Then
            advertencia.mensaje = "Campos obligatorios por capturar"
            advertencia.ShowDialog()
            cmbTipoMaterial.Focus()
            lblTipoMaterial.ForeColor = Drawing.Color.Red
            Return False
        End If
        If cmbMaterialRemplazo.SelectedIndex > 0 Then
            idMaterialRemplazo = cmbMaterialRemplazo.SelectedValue
        End If
        If Not cmbClas.SelectedIndex > 0 Then
            advertencia.mensaje = "Campos obligatorios por capturar"
            advertencia.ShowDialog()
            lblClas.ForeColor = Drawing.Color.Red
            cmbClas.Focus()
            Return False
        End If
        If rdboActivo.Checked Then
            'Nothing
        Else
            If txtIdMaterial.Text.Trim.Length > 0 Then
                Dim naves As Integer = 0
                naves = obj.getNavesUtilizandoMaterial(txtIdMaterial.Text)
                If naves > 0 Then
                    Dim objMensaje As New Tools.ConfirmarForm
                    objMensaje.mensaje = "Desactivaras el material en todas las naves. Actualmente hay " & naves & " naves utilizando el material. ¿Deseas continuar con la operación?"
                    If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
        End If
        Return True
    End Function

    Public Sub colorear()
        If txtNombre.Text = "" Then
            lblNombre.ForeColor = Drawing.Color.Red
        Else
            lblNombre.ForeColor = Drawing.Color.Black
        End If
        If cmbCategoria.Text = "" Then
            lblCategoria.ForeColor = Drawing.Color.Red
        Else
            lblCategoria.ForeColor = Drawing.Color.Black
        End If
        If cmbClas.Text = "" Then
            lblClas.ForeColor = Drawing.Color.Red
        Else
            lblClas.ForeColor = Drawing.Color.Black
        End If
        If cmbTipoMaterial.Text = "" Then
            lblTipoMaterial.ForeColor = Drawing.Color.Red
        Else
            lblTipoMaterial.ForeColor = Drawing.Color.Black
        End If

    End Sub
    Public Function getActivoNave() As String
        Dim activo As String = ""
        If rdoActivoNave.Checked Then
            If rdboInactivo.Checked Then
                activo = "0"
            Else
                activo = "1"
            End If
        Else
            activo = "0"
        End If
        Return activo
    End Function
    Public Function asignarCamposMaterial(ByVal material As Material) As Material
        If Not cmbMaterialRemplazo.Text.Length > 0 Then
            idMaterialRemplazo = 0
        End If
        material.materiaNombre = txtNombre.Text
        material.idMaterialRemplazo = idMaterialRemplazo
        material.descripcion = txtDescripcion.Text.Trim
        If cmbDepartamento.Text = "" Then
            material.departamento = 0
        Else
            material.departamento = cmbDepartamento.SelectedValue
        End If
        material.idNaveDesarrolla = idNave
        material.clasificacion = cmbClas.SelectedValue
        material.sku = txtSKU.Text
        material.idNave = idNave
        material.materialIdNave = idMaterialNave
        material.idColor = cmbColor.SelectedValue
        material.idTamaño = cmbTam.SelectedValue
        If rdoDesarrollo.Checked = True Then
            material.materialEstatus = "D"
        End If
        If rdoProduccion.Checked = True Then
            material.materialEstatus = "P"
        End If
        If rdboActivo.Checked Then
            material.activo = 1
        Else
            material.activo = 0
        End If
        material.categoria = cmbCategoria.SelectedValue
        material.tipoMaterial = cmbTipoMaterial.SelectedValue
        If rdboSiCritico.Checked Then
            material.critico = "1"
        Else
            material.critico = "0"
        End If
        material.idMaterialRemplazo = idMaterialRemplazo
        If cbxExclusivo.Checked = True Then
            material.exclusivo = 1
        Else
            material.exclusivo = 0
        End If
        'material.origenpreciomaterial = 
        'material.idNave = nave
        Return material
    End Function

    Public Sub ActualizarCaracterisiticas()
        Dim Entidad As New Caracteristicas
        Dim objbu As New MaterialesBU
        Try
            For value = 0 To grdCaracterisitcas.Rows.Count - 1
                'Entidad.cara_idcaracteristica = grdCaracterisitcas.Rows(value).Cells("ID").Value
                Entidad.cara_descripcion = grdCaracterisitcas.Rows(value).Cells("CARACTERISTICA").Value
                If grdCaracterisitcas.Rows(value).Cells(" ").Value = True Then
                    Entidad.cara_activo = "1"
                Else
                    Entidad.cara_activo = "0"
                End If
                Entidad.cara_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                Entidad.cara_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
                objbu.updateCaracteristicasMaterial(Entidad)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Public Sub InsertarInventarioInicial(ByVal MaterialNAveID As Integer)
        Dim v As New InventarioInicialForm
        v.lblMensaje.Text = "Inventario inicial del material"
        v.idMaterialNave = MaterialNAveID
        v.ShowDialog()
    End Sub

    Public Sub guardarDatosMaterial()
        Dim obj As New MaterialesBU
        Dim material As New Entidades.Material
        Dim datoMaterial As New DataTable
        Dim sku As String
        Dim idMatSicy As Integer = 0
        'Dim s As String = idNaveDesarrolloMaterial
        Dim objMaterialInventario As New MaterialInventario
        Dim dtDageProveedor As DataTable
        Dim NAveDEsarrolarMAterialSimilar As String = PMAterialesNaveDesarrollaIDMaterial
        Dim dtMaterialNaveID As DataTable

        Try
            material = asignarCamposMaterial(material) 'Asigna los campos al material primero para insertar el material principal
            Me.Cursor = Cursors.WaitCursor

            If txtIdMaterial.Text = "" Then 'INSERTA MATERIAL Y ASIGNA MATERIAL (si no hay id es una material nuevo)
                datoMaterial = obj.insertMaterial(material)

                If datoMaterial.Rows.Count > 0 Then
                    idMaterial = Convert.ToInt32(datoMaterial.Rows(0).Item(0).ToString) 'idMaterial insertado del say

                    txtIdMaterial.Text = idMaterial
                    material.idNaveDesarrolla = idNave
                    material.materiaNombre = txtNombre.Text
                    material.materialId = idMaterial
                    sku = obj.getSKUMaterial(material)  'Actualiza el sku del material dependiendo de sus caracteristicas
                    material.activo = getActivoNave()   'Trae el estatus segun la selección de los radios buttons del material de la nave
                    material.materialIdSICY = idMatSicy
                    datoMaterial = obj.asignarMaterialNave(material)    'Asigna el material a la nave en el SAY                    
                    guardarCaracterisiticas()

                    If datoMaterial.Rows.Count > 0 Then
                        idMaterialNave = Convert.ToInt32(datoMaterial.Rows(0).Item(0).ToString) 'Id del material asignado a la nave
                        material.materialIdNave = idMaterialNave
                        insertPreciosMaterial(material)
                    End If


                    Dim estatusAutorizado As String = ""
                    estatusAutorizado = obj.getEstatusAutorizado(material.materialId)
                    If material.materialEstatus = "P" Then
                        If obj.getMaterialNavesParaAgregarEnInventario(material.materialId).Rows.Count > 0 Then
                            InsertarInventarioInicial(idMaterialNave)
                            'obj.updateMaterial(material)
                        End If
                    End If

                    'If NAveDEsarrolarMAterialSimilar > 0 Then
                    '    If NAveDEsarrolarMAterialSimilar = idNave Then
                    '        Dim estatusAutorizado As String = ""
                    '        estatusAutorizado = obj.getEstatusAutorizado(material.materialId)
                    '        If material.materialEstatus = "P" Then
                    '            If obj.getMaterialNavesParaAgregarEnInventario(material.materialId).Rows.Count > 0 Then
                    '                InsertarInventarioInicial(idMaterialNave)
                    '                'obj.updateMaterial(material)
                    '            End If
                    '        End If
                    '    End If
                    'Else
                    '    Dim estatusAutorizado As String = ""
                    '    estatusAutorizado = obj.getEstatusAutorizado(material.materialId)
                    '    If material.materialEstatus = "P" Then
                    '        If obj.getMaterialNavesParaAgregarEnInventario(material.materialId).Rows.Count > 0 Then
                    '            InsertarInventarioInicial(idMaterialNave)
                    '            'obj.updateMaterial(material)
                    '        End If
                    '    End If
                    'End If

                End If
            Else

                Dim ExisteMAterial As Boolean = False
                Dim DtMAterialNAve As DataTable

                If rdboActivo.Checked = True Then
                    material.activo = 1
                Else
                    material.activo = 0
                End If
                material.materialId = idMaterial
                material.materialIdNave = idMaterialNave

                'obj.GetNaveDesarrollaMaterial(material.materialId)

                If NAveDEsarrolarMAterialSimilar > 0 Then
                    If idNaveDesarrolloMaterial = idNave Then
                        ExisteMAterial = True
                    Else
                        ExisteMAterial = False
                    End If

                End If


                If NAveDEsarrolarMAterialSimilar > 0 And ExisteMAterial = False Then

                    DtMAterialNAve = obj.ExisteNaveAsignadaMaterial(material.materialId, idNave)

                    If DtMAterialNAve.Rows.Count > 0 Then
                        idMaterialNave = DtMAterialNAve.Rows(0).Item("mn_materialNaveid").ToString
                        material.materialIdNave = idMaterialNave
                        insertPreciosMaterial(material)
                        Dim estatusAutorizado As String = ""
                        estatusAutorizado = obj.getEstatusAutorizado(material.materialId)
                        If material.materialEstatus = "P" Then

                            For Each FilaPrecio As UltraGridRow In grdAltaPrecio.Rows
                                If FilaPrecio.Cells("seleccion").Value = True Then

                                    If FilaPrecio.Cells("Activo").Value = True Then
                                        If obj.ExisteInventarioMaterialProveedor(material.materialIdNave, FilaPrecio.Cells("idProveedor").Value) = False Then
                                            dtMaterialNaveID = New DataTable
                                            objMaterialInventario = New MaterialInventario
                                            objMaterialInventario.invn_cantidad = 0
                                            objMaterialInventario.invn_factorconversion = FilaPrecio.Cells("Factor de conversión").Value
                                            objMaterialInventario.invn_inventariototal = 0
                                            objMaterialInventario.invn_movimientoinventarioid = 1
                                            objMaterialInventario.invn_precio = FilaPrecio.Cells("Precio").Value
                                            objMaterialInventario.invn_proveedorid = FilaPrecio.Cells("idProveedor").Value
                                            objMaterialInventario.invn_umc = FilaPrecio.Cells("idumprov").Value
                                            objMaterialInventario.invn_ump = FilaPrecio.Cells("idumprod").Value
                                            objMaterialInventario.invn_monedaid = FilaPrecio.Cells("IdMoneda").Value
                                            dtMaterialNaveID = obj.getidMaterialNavesXidMaterial(material.materialId)

                                            For Each FilaNaveMAterial As DataRow In dtMaterialNaveID.Rows
                                                dtDageProveedor = New DataTable
                                                'Si no existe el proveedor relaccionarlo con la nave
                                                dtDageProveedor = obj.getProveedorAsignado(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
                                                If dtDageProveedor.Rows.Count = 0 Then
                                                    obj.insertProveedorNave(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
                                                End If

                                                objMaterialInventario.invn_naveid = FilaNaveMAterial("mn_idNave").ToString()
                                                objMaterialInventario.invn_materialnaveid = FilaNaveMAterial("mn_materialNaveid").ToString()
                                                obj.insertarInventarioNave(objMaterialInventario)

                                            Next

                                        Else
                                            If obj.ExisteInventarioMaterialProveedorPrecio(material.materialIdNave, FilaPrecio.Cells("idProveedor").Value, FilaPrecio.Cells("Precio").Value) = False Then
                                                dtMaterialNaveID = New DataTable
                                                objMaterialInventario = New MaterialInventario
                                                objMaterialInventario.invn_cantidad = 0
                                                objMaterialInventario.invn_factorconversion = FilaPrecio.Cells("Factor de conversión").Value
                                                objMaterialInventario.invn_inventariototal = 0
                                                objMaterialInventario.invn_movimientoinventarioid = 1
                                                objMaterialInventario.invn_precio = FilaPrecio.Cells("Precio").Value
                                                objMaterialInventario.invn_proveedorid = FilaPrecio.Cells("idProveedor").Value
                                                objMaterialInventario.invn_umc = FilaPrecio.Cells("idumprov").Value
                                                objMaterialInventario.invn_ump = FilaPrecio.Cells("idumprod").Value
                                                objMaterialInventario.invn_monedaid = FilaPrecio.Cells("IdMoneda").Value
                                                dtMaterialNaveID = obj.getidMaterialNavesXidMaterial(material.materialId)

                                                For Each FilaNaveMAterial As DataRow In dtMaterialNaveID.Rows
                                                    dtDageProveedor = New DataTable
                                                    'Si no existe el proveedor relaccionarlo con la nave
                                                    dtDageProveedor = obj.getProveedorAsignado(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
                                                    If dtDageProveedor.Rows.Count = 0 Then
                                                        obj.insertProveedorNave(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
                                                    End If

                                                    objMaterialInventario.invn_naveid = FilaNaveMAterial("mn_idNave").ToString()
                                                    objMaterialInventario.invn_materialnaveid = FilaNaveMAterial("mn_materialNaveid").ToString()
                                                    obj.insertarInventarioNave(objMaterialInventario)

                                                Next

                                            Else

                                                objMaterialInventario = New MaterialInventario

                                                objMaterialInventario.invn_precio = FilaPrecio.Cells("Precio").Value
                                                objMaterialInventario.invn_proveedorid = FilaPrecio.Cells("idProveedor").Value
                                                objMaterialInventario.invn_materialnaveid = idMaterialNave
                                                objMaterialInventario.invn_umc = FilaPrecio.Cells("idumprov").Value
                                                objMaterialInventario.invn_ump = FilaPrecio.Cells("idumprod").Value
                                                objMaterialInventario.invn_factorconversion = FilaPrecio.Cells("Factor de conversión").Value

                                                obj.ActualizarInventarioNave(objMaterialInventario)

                                            End If
                                        End If
                                    End If
                                End If
                            Next

                        End If

                    Else

                        datoMaterial = obj.asignarMaterialNave(material)
                        If datoMaterial.Rows.Count > 0 Then
                            idMaterialNave = Convert.ToInt32(datoMaterial.Rows(0).Item(0).ToString) 'Trae el idMaterialNave sirve para ligarlos con los precios
                            material.materialIdNave = idMaterialNave
                            insertPreciosMaterial(material) 'Inserta lo precios al material asignado

                            Dim estatusAutorizado As String = ""
                            estatusAutorizado = obj.getEstatusAutorizado(material.materialId)

                            If material.materialEstatus = "P" Then
                                If obj.getMaterialNavesParaAgregarEnInventario(material.materialId).Rows.Count > 0 Then
                                    InsertarInventarioInicial(idMaterialNave)
                                    'obj.updateMaterial(material)
                                End If
                            End If

                        End If
                    End If



                Else

                    Dim estatusAutorizado As String = ""
                    estatusAutorizado = obj.getEstatusAutorizado(material.materialId)

                    insertPreciosMaterial(material) 'Inserta lo precios al material asignado


                    If estatusAutorizado = "P" Then

                        For Each FilaPrecio As UltraGridRow In grdAltaPrecio.Rows
                            If FilaPrecio.Cells("seleccion").Value = 1 Then
                                If FilaPrecio.Cells("Activo").Value = True Then
                                    If obj.ExisteInventarioMaterialProveedor(material.materialIdNave, FilaPrecio.Cells("idProveedor").Value) = False Then
                                        dtMaterialNaveID = New DataTable
                                        objMaterialInventario = New MaterialInventario
                                        objMaterialInventario.invn_cantidad = 0
                                        objMaterialInventario.invn_factorconversion = FilaPrecio.Cells("Factor de conversión").Value
                                        objMaterialInventario.invn_inventariototal = 0
                                        objMaterialInventario.invn_movimientoinventarioid = 1
                                        objMaterialInventario.invn_precio = FilaPrecio.Cells("Precio").Value
                                        objMaterialInventario.invn_proveedorid = FilaPrecio.Cells("idProveedor").Value
                                        objMaterialInventario.invn_umc = FilaPrecio.Cells("idumprov").Value
                                        objMaterialInventario.invn_ump = FilaPrecio.Cells("idumprod").Value
                                        objMaterialInventario.invn_monedaid = FilaPrecio.Cells("IdMoneda").Value
                                        dtMaterialNaveID = obj.getidMaterialNavesXidMaterial(material.materialId)

                                        For Each FilaNaveMAterial As DataRow In dtMaterialNaveID.Rows
                                            dtDageProveedor = New DataTable
                                            'Si no existe el proveedor relaccionarlo con la nave
                                            dtDageProveedor = obj.getProveedorAsignado(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
                                            If dtDageProveedor.Rows.Count = 0 Then
                                                obj.insertProveedorNave(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
                                            End If

                                            objMaterialInventario.invn_naveid = FilaNaveMAterial("mn_idNave").ToString()
                                            objMaterialInventario.invn_materialnaveid = FilaNaveMAterial("mn_materialNaveid").ToString()
                                            obj.insertarInventarioNave(objMaterialInventario)

                                        Next

                                    Else
                                        If obj.ExisteInventarioMaterialProveedorPrecio(material.materialIdNave, FilaPrecio.Cells("idProveedor").Value, FilaPrecio.Cells("Precio").Value) = False Then
                                            dtMaterialNaveID = New DataTable
                                            objMaterialInventario = New MaterialInventario
                                            objMaterialInventario.invn_cantidad = 0
                                            objMaterialInventario.invn_factorconversion = FilaPrecio.Cells("Factor de conversión").Value
                                            objMaterialInventario.invn_inventariototal = 0
                                            objMaterialInventario.invn_movimientoinventarioid = 1
                                            objMaterialInventario.invn_precio = FilaPrecio.Cells("Precio").Value
                                            objMaterialInventario.invn_proveedorid = FilaPrecio.Cells("idProveedor").Value
                                            objMaterialInventario.invn_umc = FilaPrecio.Cells("idumprov").Value
                                            objMaterialInventario.invn_ump = FilaPrecio.Cells("idumprod").Value
                                            objMaterialInventario.invn_monedaid = FilaPrecio.Cells("IdMoneda").Value
                                            dtMaterialNaveID = obj.getidMaterialNavesXidMaterial(material.materialId)

                                            For Each FilaNaveMAterial As DataRow In dtMaterialNaveID.Rows
                                                dtDageProveedor = New DataTable
                                                'Si no existe el proveedor relaccionarlo con la nave
                                                dtDageProveedor = obj.getProveedorAsignado(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
                                                If dtDageProveedor.Rows.Count = 0 Then
                                                    obj.insertProveedorNave(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
                                                End If

                                                objMaterialInventario.invn_naveid = FilaNaveMAterial("mn_idNave").ToString()
                                                objMaterialInventario.invn_materialnaveid = FilaNaveMAterial("mn_materialNaveid").ToString()
                                                obj.insertarInventarioNave(objMaterialInventario)

                                            Next

                                        Else
                                            objMaterialInventario = New MaterialInventario

                                            objMaterialInventario.invn_precio = FilaPrecio.Cells("Precio").Value
                                            objMaterialInventario.invn_proveedorid = FilaPrecio.Cells("idProveedor").Value
                                            objMaterialInventario.invn_materialnaveid = idMaterialNave
                                            objMaterialInventario.invn_umc = FilaPrecio.Cells("idumprov").Value
                                            objMaterialInventario.invn_ump = FilaPrecio.Cells("idumprod").Value
                                            objMaterialInventario.invn_factorconversion = FilaPrecio.Cells("Factor de conversión").Value
                                            obj.ActualizarInventarioNave(objMaterialInventario)

                                        End If
                                    End If
                                End If
                            End If
                        Next
                    Else
                        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "MODMATPRINCIPAL") Then

                            estatusAutorizado = obj.getEstatusAutorizado(material.materialId)
                            If estatusAutorizado = "D" Then
                                If material.materialEstatus = "P" Then
                                    If obj.getMaterialNavesParaAgregarEnInventario(material.materialId).Rows.Count > 0 Then
                                        Dim v As New InventarioInicialForm
                                        Dim Lista As New List(Of Integer)
                                        v.lblMensaje.Text = "Inventario inicial del material"
                                        v.idMaterialNave = idMaterialNave
                                        Lista.Add(material.materialId)
                                        v.list = Lista
                                        v.ShowDialog()
                                    End If
                                End If
                                obj.updateMaterial(material)
                            End If
                        End If
                    End If
                End If

            End If

            guardarCaracterisiticas()

            material.activo = getActivoNave()
            obj.updateMaterial2(material, idMaterialNave) 'Actualiza material en say
            obj.ActualizaMaterialCritico(material)

            obj.getSKUMaterial(material)
            If rdoProduccion.Checked = True Then
                BloquearControlesMaterialProduccion(idNave)
            End If

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "EDITARMATERIALPRODUCCION") Then
                Dim tbls As New DataTable
                tbls = obj.SaberTipoNave(idNave)
                If tbls.Rows(0).Item(0) = True Then
                    obj.ActualizaNombreMaterial(material)
                End If
            End If

            ' guardarCaracterisiticasSimilitudes()


            Me.Cursor = Cursors.Default
            objExito.mensaje = "Material guardado con éxito."
            objExito.ShowDialog()


        Catch ex As Exception
            Me.Cursor = Cursors.Default
            advertencia.mensaje = "Error al guardar. Error: " & ex.Message
            advertencia.ShowDialog()
        End Try




        '    Else

        '        If rdboActivo.Checked = True Then
        '            material.activo = 1
        '        Else
        '            material.activo = 0
        '        End If
        '        material.materialId = idMaterial


        '        '===============================================================

        '        ''''''''material.activo = getActivoNave()
        '        If idMaterialNave = 0 Then 'Asigna material a nave. 'Determina si ya tiene el material asignado
        '            datoMaterial = obj.asignarMaterialNave(material) 'Asigna el material a la nave en say
        '            'obj.insertMaterialAlmacenSICY(material) 'Asigna el material a la nave en sicy
        '            ' obj.updateMaterialSICYidDep(material.departamento, idMatSicy) 'Actualiza el departamento del material en sicy

        '            guardarCaracterisiticas()

        '            If datoMaterial.Rows.Count > 0 Then
        '                idMaterialNave = Convert.ToInt32(datoMaterial.Rows(0).Item(0).ToString) 'Trae el idMaterialNave sirve para ligarlos con los precios
        '                material.materialIdNave = idMaterialNave
        '                'Recupera e inserta todos los precios de materiales
        '                insertPreciosMaterial(material) 'Inserta lo precios al material asignado



        '                If rdoProduccion.Checked = True Then
        '                    If NAveDEsarrolarMAterialSimilar > 0 Then
        '                        If obj.getMaterialParaAgregarEnInventario(idMaterialNave).Rows.Count > 0 Then
        '                            Dim v As New InventarioInicialForm
        '                            v.lblMensaje.Text = "Inventario inicial del material"
        '                            v.idMaterialNave = idMaterialNave
        '                            v.ShowDialog()

        '                            'If NAveDEsarrolarMAterialSimilar = idNave Then

        '                            'End If
        '                        End If
        '                    End If

        '                End If



        '            End If
        '        Else 'Actualiza material de nave
        '            material.materialIdNave = idMaterialNave
        '            datoMaterial = obj.updateMaterialNave(material) 'Actualiza el material de la nave en say
        '            guardarCaracterisiticasSimilitudes()
        '            'obj.actualizarEstatusMaterialAlmSIcy(material)  'Actualiza el material de la nave en sicy
        '            material.materialIdNave = idMaterialNave
        '            'Recupera e inserta todos los precios de materiales
        '            insertPreciosMaterial(material) 'Inserta lo precios al material asignado
        '        End If

        '        '===============================================================




        '        ' Si tiene permisos modifica el material principal
        '        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "MODMATPRINCIPAL") Then
        '            Dim estatusAutorizado As String = ""
        '            estatusAutorizado = obj.getEstatusAutorizado(material.materialId)
        '            If estatusAutorizado = "D" Then
        '                If material.materialEstatus = "P" Then
        '                    If obj.getMaterialNavesParaAgregarEnInventario(material.materialId).Rows.Count > 0 Then
        '                        Dim v As New InventarioInicialForm
        '                        Dim Lista As New List(Of Integer)
        '                        v.lblMensaje.Text = "Inventario inicial del material"
        '                        v.idMaterialNave = idMaterialNave
        '                        Lista.Add(material.materialId)
        '                        v.list = Lista
        '                        v.ShowDialog()                                
        '                End If


        '                obj.updateMaterial(material)

        '            Else

        '                For Each FilaPrecio As UltraGridRow In grdAltaPrecio.Rows
        '                    If FilaPrecio.Cells("Activo").Value = True Then
        '                        If obj.ExisteInventarioMaterialProveedor(material.materialIdNave, FilaPrecio.Cells("idProveedor").Value) = False Then
        '                            dtMaterialNaveID = New DataTable
        '                            objMaterialInventario = New MaterialInventario
        '                            objMaterialInventario.invn_cantidad = 0
        '                            objMaterialInventario.invn_factorconversion = FilaPrecio.Cells("Factor de conversión").Value
        '                            objMaterialInventario.invn_inventariototal = 0
        '                            objMaterialInventario.invn_movimientoinventarioid = 1
        '                            objMaterialInventario.invn_precio = FilaPrecio.Cells("Precio").Value
        '                            objMaterialInventario.invn_proveedorid = FilaPrecio.Cells("idProveedor").Value
        '                            objMaterialInventario.invn_umc = FilaPrecio.Cells("idumprov").Value
        '                            objMaterialInventario.invn_ump = FilaPrecio.Cells("idumprod").Value
        '                            objMaterialInventario.invn_monedaid = FilaPrecio.Cells("IdMoneda").Value
        '                            dtMaterialNaveID = obj.getidMaterialNavesXidMaterial(material.materialId)

        '                            For Each FilaNaveMAterial As DataRow In dtMaterialNaveID.Rows
        '                                dtDageProveedor = New DataTable
        '                                'Si no existe el proveedor relaccionarlo con la nave
        '                                dtDageProveedor = obj.getProveedorAsignado(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
        '                                If dtDageProveedor.Rows.Count = 0 Then
        '                                    obj.insertProveedorNave(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
        '                                End If

        '                                objMaterialInventario.invn_naveid = FilaNaveMAterial("mn_idNave").ToString()
        '                                objMaterialInventario.invn_materialnaveid = FilaNaveMAterial("mn_materialNaveid").ToString()
        '                                obj.insertarInventarioNave(objMaterialInventario)

        '                            Next

        '                        Else
        '                            If obj.ExisteInventarioMaterialProveedorPrecio(material.materialIdNave, FilaPrecio.Cells("idProveedor").Value, FilaPrecio.Cells("Precio").Value) = False Then
        '                                dtMaterialNaveID = New DataTable
        '                                objMaterialInventario = New MaterialInventario
        '                                objMaterialInventario.invn_cantidad = 0
        '                                objMaterialInventario.invn_factorconversion = FilaPrecio.Cells("Factor de conversión").Value
        '                                objMaterialInventario.invn_inventariototal = 0
        '                                objMaterialInventario.invn_movimientoinventarioid = 1
        '                                objMaterialInventario.invn_precio = FilaPrecio.Cells("Precio").Value
        '                                objMaterialInventario.invn_proveedorid = FilaPrecio.Cells("idProveedor").Value
        '                                objMaterialInventario.invn_umc = FilaPrecio.Cells("idumprov").Value
        '                                objMaterialInventario.invn_ump = FilaPrecio.Cells("idumprod").Value
        '                                objMaterialInventario.invn_monedaid = FilaPrecio.Cells("IdMoneda").Value
        '                                dtMaterialNaveID = obj.getidMaterialNavesXidMaterial(material.materialId)

        '                                For Each FilaNaveMAterial As DataRow In dtMaterialNaveID.Rows
        '                                    dtDageProveedor = New DataTable
        '                                    'Si no existe el proveedor relaccionarlo con la nave
        '                                    dtDageProveedor = obj.getProveedorAsignado(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
        '                                    If dtDageProveedor.Rows.Count = 0 Then
        '                                        obj.insertProveedorNave(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
        '                                    End If

        '                                    objMaterialInventario.invn_naveid = FilaNaveMAterial("mn_idNave").ToString()
        '                                    objMaterialInventario.invn_materialnaveid = FilaNaveMAterial("mn_materialNaveid").ToString()
        '                                    obj.insertarInventarioNave(objMaterialInventario)

        '                                Next
        '                            End If

        '                        End If
        '                    End If


        '                Next


        '            End If
        '        End If






        '    End If





        'Catch ex As Exception

        'End Try






























        'Try
        '    material = asignarCamposMaterial(material) 'Asigna los campos al material primero para insertar el material principal
        '    Me.Cursor = Cursors.WaitCursor
        '    If txtIdMaterial.Text = "" Then 'INSERTA MATERIAL Y ASIGNA MATERIAL (si no hay id es una material nuevo)
        '        datoMaterial = obj.insertMaterial(material)
        '        If datoMaterial.Rows.Count > 0 Then
        '            idMaterial = Convert.ToInt32(datoMaterial.Rows(0).Item(0).ToString) 'idMaterial insertado del say
        '            ' idMatSicy = Convert.ToInt32(datoMaterial.Rows(0).Item(1).ToString)  'idMaterial del SICY 
        '        End If
        '        txtIdMaterial.Text = idMaterial
        '        material.idNaveDesarrolla = idNave
        '        material.materiaNombre = txtNombre.Text
        '        material.materialId = idMaterial
        '        sku = obj.getSKUMaterial(material)  'Actualiza el sku del material dependiendo de sus caracteristicas
        '        material.activo = getActivoNave()   'Trae el estatus segun la selección de los radios buttons del material de la nave
        '        material.materialIdSICY = idMatSicy
        '        datoMaterial = obj.asignarMaterialNave(material)    'Asigna el material a la nave en el SAY
        '        'obj.insertMaterialAlmacenSICY(material)             'Asinga el material a la nave en el SICY
        '        'obj.updateMaterialSICYidDep(material.departamento, idMatSicy)

        '        guardarCaracterisiticas()

        '        Try
        '            If datoMaterial.Rows.Count > 0 Then
        '                idMaterialNave = Convert.ToInt32(datoMaterial.Rows(0).Item(0).ToString) 'Id del material asignado a la nave
        '            End If
        '        Catch ex As Exception

        '        End Try
        '        material.materialIdNave = idMaterialNave
        '        insertPreciosMaterial(material)


        '        Try
        '            If NAveDEsarrolarMAterialSimilar > 0 Then
        '                If NAveDEsarrolarMAterialSimilar = idNave Then
        '                    Dim estatusAutorizado As String = ""
        '                    estatusAutorizado = obj.getEstatusAutorizado(material.materialId)
        '                    If material.materialEstatus = "P" Then
        '                        If obj.getMaterialNavesParaAgregarEnInventario(material.materialId).Rows.Count > 0 Then
        '                            Dim v As New InventarioInicialForm
        '                            v.lblMensaje.Text = "Inventario inicial del material"
        '                            v.idMaterialNave = idMaterialNave
        '                            v.ShowDialog()

        '                            obj.updateMaterial(material)

        '                        End If

        '                    End If
        '                End If

        '            Else
        '                Dim estatusAutorizado As String = ""
        '                estatusAutorizado = obj.getEstatusAutorizado(material.materialId)
        '                If material.materialEstatus = "P" Then
        '                    If obj.getMaterialNavesParaAgregarEnInventario(material.materialId).Rows.Count > 0 Then
        '                        Dim v As New InventarioInicialForm
        '                        v.lblMensaje.Text = "Inventario inicial del material"
        '                        v.idMaterialNave = idMaterialNave
        '                        v.ShowDialog()
        '                        obj.updateMaterial(material)

        '                    End If

        '                Else

        '                    For Each FilaPrecio As UltraGridRow In grdAltaPrecio.Rows
        '                        If FilaPrecio.Cells("Activo").Value = True Then
        '                            If obj.ExisteInventarioMaterialProveedor(material.materialIdNave, FilaPrecio.Cells("idProveedor").Value) = False Then
        '                                dtMaterialNaveID = New DataTable
        '                                objMaterialInventario = New MaterialInventario
        '                                objMaterialInventario.invn_cantidad = 0
        '                                objMaterialInventario.invn_factorconversion = FilaPrecio.Cells("Factor de conversión").Value
        '                                objMaterialInventario.invn_inventariototal = 0
        '                                objMaterialInventario.invn_movimientoinventarioid = 1
        '                                objMaterialInventario.invn_precio = FilaPrecio.Cells("Precio").Value
        '                                objMaterialInventario.invn_proveedorid = FilaPrecio.Cells("idProveedor").Value
        '                                objMaterialInventario.invn_umc = FilaPrecio.Cells("idumprov").Value
        '                                objMaterialInventario.invn_ump = FilaPrecio.Cells("idumprod").Value
        '                                objMaterialInventario.invn_monedaid = FilaPrecio.Cells("IdMoneda").Value
        '                                dtMaterialNaveID = obj.getidMaterialNavesXidMaterial(material.materialId)

        '                                For Each FilaNaveMAterial As DataRow In dtMaterialNaveID.Rows
        '                                    dtDageProveedor = New DataTable
        '                                    'Si no existe el proveedor relaccionarlo con la nave
        '                                    dtDageProveedor = obj.getProveedorAsignado(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
        '                                    If dtDageProveedor.Rows.Count = 0 Then
        '                                        obj.insertProveedorNave(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
        '                                    End If

        '                                    objMaterialInventario.invn_naveid = FilaNaveMAterial("mn_idNave").ToString()
        '                                    objMaterialInventario.invn_materialnaveid = FilaNaveMAterial("mn_materialNaveid").ToString()
        '                                    obj.insertarInventarioNave(objMaterialInventario)

        '                                Next

        '                            Else
        '                                If obj.ExisteInventarioMaterialProveedorPrecio(material.materialIdNave, FilaPrecio.Cells("idProveedor").Value, FilaPrecio.Cells("Precio").Value) = False Then
        '                                    dtMaterialNaveID = New DataTable
        '                                    objMaterialInventario = New MaterialInventario
        '                                    objMaterialInventario.invn_cantidad = 0
        '                                    objMaterialInventario.invn_factorconversion = FilaPrecio.Cells("Factor de conversión").Value
        '                                    objMaterialInventario.invn_inventariototal = 0
        '                                    objMaterialInventario.invn_movimientoinventarioid = 1
        '                                    objMaterialInventario.invn_precio = FilaPrecio.Cells("Precio").Value
        '                                    objMaterialInventario.invn_proveedorid = FilaPrecio.Cells("idProveedor").Value
        '                                    objMaterialInventario.invn_umc = FilaPrecio.Cells("idumprov").Value
        '                                    objMaterialInventario.invn_ump = FilaPrecio.Cells("idumprod").Value
        '                                    objMaterialInventario.invn_monedaid = FilaPrecio.Cells("IdMoneda").Value
        '                                    dtMaterialNaveID = obj.getidMaterialNavesXidMaterial(material.materialId)

        '                                    For Each FilaNaveMAterial As DataRow In dtMaterialNaveID.Rows
        '                                        dtDageProveedor = New DataTable
        '                                        'Si no existe el proveedor relaccionarlo con la nave
        '                                        dtDageProveedor = obj.getProveedorAsignado(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
        '                                        If dtDageProveedor.Rows.Count = 0 Then
        '                                            obj.insertProveedorNave(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
        '                                        End If

        '                                        objMaterialInventario.invn_naveid = FilaNaveMAterial("mn_idNave").ToString()
        '                                        objMaterialInventario.invn_materialnaveid = FilaNaveMAterial("mn_materialNaveid").ToString()
        '                                        obj.insertarInventarioNave(objMaterialInventario)

        '                                    Next
        '                                End If

        '                            End If
        '                        End If


        '                    Next

        '                    obj.updateMaterial(material)
        '                End If



        '                material.activo = getActivoNave()
        '                obj.updateMaterial2(material, idMaterialNave) 'Actualiza material en say
        '                'ActualizarCaracterisiticas()
        '                'guardarCaracterisiticasSimilitudes()
        '                obj.getSKUMaterial(material)
        '                If rdoProduccion.Checked = True Then
        '                    BloquearControlesMaterialProduccion()
        '                End If

        '            End If





        '        Catch ex As Exception

        '        End Try


        '    Else 'ACTUALIZA MATERIAL Y DEPENDIENDO DEL IDMATERIALNAVE INSERTA O ACTUALIZA 'El material ya existe
        '        'VERIFICAR SI TIENE PERMISOS PARA MODIFICAR MATERIAL PRINCIPAL
        '        'MATERIAL: sku,descripcion,categoria,clasificacion,tipoMaterial,activoActualizarCaracterisiticas
        '        'MATERIALNAVE: departamento,critico,material de remplazo
        '        If rdboActivo.Checked = True Then
        '            material.activo = 1
        '        Else
        '            material.activo = 0
        '        End If
        '        material.materialId = idMaterial
        '        ' material.materialIdSICY = idMaterialSicy
        '        ' Si tiene permisos modifica el material principal
        '        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "MODMATPRINCIPAL") Then

        '            Try
        '                Dim estatusAutorizado As String = ""
        '                estatusAutorizado = obj.getEstatusAutorizado(material.materialId)
        '                If estatusAutorizado = "D" Then
        '                    If material.materialEstatus = "P" Then
        '                        If obj.getMaterialNavesParaAgregarEnInventario(material.materialId).Rows.Count > 0 Then
        '                            Dim v As New InventarioInicialForm
        '                            Dim Lista As New List(Of Integer)
        '                            v.lblMensaje.Text = "Inventario inicial del material"
        '                            v.idMaterialNave = idMaterialNave
        '                            Lista.Add(material.materialId)
        '                            v.list = Lista
        '                            v.ShowDialog()
        '                            obj.updateMaterial(material)
        '                        Else
        '                            obj.updateMaterial(material)
        '                        End If
        '                    Else
        '                        obj.updateMaterial(material)
        '                    End If
        '                Else

        '                    For Each FilaPrecio As UltraGridRow In grdAltaPrecio.Rows
        '                        If FilaPrecio.Cells("Activo").Value = True Then
        '                            If obj.ExisteInventarioMaterialProveedor(material.materialIdNave, FilaPrecio.Cells("idProveedor").Value) = False Then
        '                                dtMaterialNaveID = New DataTable
        '                                objMaterialInventario = New MaterialInventario
        '                                objMaterialInventario.invn_cantidad = 0
        '                                objMaterialInventario.invn_factorconversion = FilaPrecio.Cells("Factor de conversión").Value
        '                                objMaterialInventario.invn_inventariototal = 0
        '                                objMaterialInventario.invn_movimientoinventarioid = 1
        '                                objMaterialInventario.invn_precio = FilaPrecio.Cells("Precio").Value
        '                                objMaterialInventario.invn_proveedorid = FilaPrecio.Cells("idProveedor").Value
        '                                objMaterialInventario.invn_umc = FilaPrecio.Cells("idumprov").Value
        '                                objMaterialInventario.invn_ump = FilaPrecio.Cells("idumprod").Value
        '                                objMaterialInventario.invn_monedaid = FilaPrecio.Cells("IdMoneda").Value
        '                                dtMaterialNaveID = obj.getidMaterialNavesXidMaterial(material.materialId)

        '                                For Each FilaNaveMAterial As DataRow In dtMaterialNaveID.Rows
        '                                    dtDageProveedor = New DataTable
        '                                    'Si no existe el proveedor relaccionarlo con la nave
        '                                    dtDageProveedor = obj.getProveedorAsignado(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
        '                                    If dtDageProveedor.Rows.Count = 0 Then
        '                                        obj.insertProveedorNave(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
        '                                    End If

        '                                    objMaterialInventario.invn_naveid = FilaNaveMAterial("mn_idNave").ToString()
        '                                    objMaterialInventario.invn_materialnaveid = FilaNaveMAterial("mn_materialNaveid").ToString()
        '                                    obj.insertarInventarioNave(objMaterialInventario)

        '                                Next

        '                            Else
        '                                If obj.ExisteInventarioMaterialProveedorPrecio(material.materialIdNave, FilaPrecio.Cells("idProveedor").Value, FilaPrecio.Cells("Precio").Value) = False Then
        '                                    dtMaterialNaveID = New DataTable
        '                                    objMaterialInventario = New MaterialInventario
        '                                    objMaterialInventario.invn_cantidad = 0
        '                                    objMaterialInventario.invn_factorconversion = FilaPrecio.Cells("Factor de conversión").Value
        '                                    objMaterialInventario.invn_inventariototal = 0
        '                                    objMaterialInventario.invn_movimientoinventarioid = 1
        '                                    objMaterialInventario.invn_precio = FilaPrecio.Cells("Precio").Value
        '                                    objMaterialInventario.invn_proveedorid = FilaPrecio.Cells("idProveedor").Value
        '                                    objMaterialInventario.invn_umc = FilaPrecio.Cells("idumprov").Value
        '                                    objMaterialInventario.invn_ump = FilaPrecio.Cells("idumprod").Value
        '                                    objMaterialInventario.invn_monedaid = FilaPrecio.Cells("IdMoneda").Value
        '                                    dtMaterialNaveID = obj.getidMaterialNavesXidMaterial(material.materialId)

        '                                    For Each FilaNaveMAterial As DataRow In dtMaterialNaveID.Rows
        '                                        dtDageProveedor = New DataTable
        '                                        'Si no existe el proveedor relaccionarlo con la nave
        '                                        dtDageProveedor = obj.getProveedorAsignado(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
        '                                        If dtDageProveedor.Rows.Count = 0 Then
        '                                            obj.insertProveedorNave(FilaPrecio.Cells("dageproveedorid").Value, FilaNaveMAterial("mn_idNave").ToString())
        '                                        End If

        '                                        objMaterialInventario.invn_naveid = FilaNaveMAterial("mn_idNave").ToString()
        '                                        objMaterialInventario.invn_materialnaveid = FilaNaveMAterial("mn_materialNaveid").ToString()
        '                                        obj.insertarInventarioNave(objMaterialInventario)

        '                                    Next
        '                                End If

        '                            End If
        '                        End If


        '                    Next

        '                    obj.updateMaterial(material)

        '                End If
        '            Catch ex As Exception

        '            End Try



        '            material.activo = getActivoNave()
        '            obj.updateMaterial2(material, idMaterialNave) 'Actualiza material en say
        '            'ActualizarCaracterisiticas()
        '            'guardarCaracterisiticasSimilitudes()
        '            obj.getSKUMaterial(material)
        '            If rdoProduccion.Checked = True Then
        '                BloquearControlesMaterialProduccion()
        '            End If

        '            'obj.UpdateMaterialesSICY(material) 'Actualiza material en sicy
        '        End If

        '        ''''''''material.activo = getActivoNave()
        '        If idMaterialNave = 0 Then 'Asigna material a nave. 'Determina si ya tiene el material asignado
        '            datoMaterial = obj.asignarMaterialNave(material) 'Asigna el material a la nave en say
        '            'obj.insertMaterialAlmacenSICY(material) 'Asigna el material a la nave en sicy
        '            ' obj.updateMaterialSICYidDep(material.departamento, idMatSicy) 'Actualiza el departamento del material en sicy

        '            guardarCaracterisiticas()

        '            If datoMaterial.Rows.Count > 0 Then
        '                idMaterialNave = Convert.ToInt32(datoMaterial.Rows(0).Item(0).ToString) 'Trae el idMaterialNave sirve para ligarlos con los precios
        '                material.materialIdNave = idMaterialNave
        '                'Recupera e inserta todos los precios de materiales
        '                insertPreciosMaterial(material) 'Inserta lo precios al material asignado



        '                If rdoProduccion.Checked = True Then
        '                    If NAveDEsarrolarMAterialSimilar > 0 Then
        '                        If obj.getMaterialParaAgregarEnInventario(idMaterialNave).Rows.Count > 0 Then
        '                            Dim v As New InventarioInicialForm
        '                            v.lblMensaje.Text = "Inventario inicial del material"
        '                            v.idMaterialNave = idMaterialNave
        '                            v.ShowDialog()

        '                            'If NAveDEsarrolarMAterialSimilar = idNave Then

        '                            'End If
        '                        End If
        '                    End If

        '                End If



        '            End If
        '        Else 'Actualiza material de nave
        '            material.materialIdNave = idMaterialNave
        '            datoMaterial = obj.updateMaterialNave(material) 'Actualiza el material de la nave en say
        '            guardarCaracterisiticasSimilitudes()
        '            'obj.actualizarEstatusMaterialAlmSIcy(material)  'Actualiza el material de la nave en sicy
        '            material.materialIdNave = idMaterialNave
        '            'Recupera e inserta todos los precios de materiales
        '            insertPreciosMaterial(material) 'Inserta lo precios al material asignado
        '        End If




        '    End If


        '    If copiado = False Then
        '        Me.Cursor = Cursors.Default
        '        objExito.mensaje = "Material guardado con éxito."
        '        objExito.ShowDialog()
        '    Else
        '        Me.Cursor = Cursors.Default
        '        objExito.mensaje = "Material habilitado con éxito."
        '        objExito.ShowDialog()
        '    End If

        '    'Me.Close()
        'Catch ex As Exception
        '    Me.Cursor = Cursors.Default
        '    advertencia.mensaje = "Error al guardar. Error: " & ex.Message
        '    advertencia.ShowDialog()
        'End Try
    End Sub
    Public Sub insertPreciosMaterial(ByVal material As Material)
        Try
            Dim precioMaterial As New Entidades.PrecioMaterial
            Dim tablePreciosMateriales As New DataTable
            Dim obj As New MaterialesBU
            Dim ban As Boolean = False
            tablePreciosMateriales = grdAltaPrecio.DataSource 'Recupera todos los datos del grid de precios

            Dim tmp As New DataTable
            Dim idNaveDesarrolla As Integer = 0
            tmp = obj.getNaveDesarrolla(idMaterialNave)
            For Each row As DataRow In tmp.Rows
                idNaveDesarrolla = row(0)
                Exit For
            Next
            If idNaveDesarrolla = idNave Then 'Copiar precios a naves de producción


                For Each row As DataRow In tablePreciosMateriales.Rows
                    If row("seleccion") = 1 Then
                        ban = True
                        obj.asignarProveedor(idNave, row("dageproveedorid"))
                        precioMaterial.idMaterialSICY = material.materialIdSICY
                        precioMaterial.idMaterialNave = material.materialIdNave
                        precioMaterial.naveId = row("nave_naveid") 'idNave
                        precioMaterial.proveedordgId = row("dageproveedorid")
                        precioMaterial.precioUnitario = row("Precio")
                        'precioMaterial.tiempodeEntrega = row("Días Entrega")
                        precioMaterial.proveedorId = row("idProveedor")
                        precioMaterial.proveedor = row("Proveedor")
                        precioMaterial.existe = row("Existe")
                        precioMaterial.preciosmaterialid = row("PrecioMaterialId")
                        precioMaterial.equivalenciaUMP = row("Factor de conversión")
                        precioMaterial.umc = row("umc")
                        precioMaterial.ump = row("ump")
                        precioMaterial.idumc = row("idumprov")
                        precioMaterial.idump = row("idumprod")
                        precioMaterial.descripcion = txtDescripcion.Text.Trim
                        precioMaterial.descripcionProv = row("Descripción Material Proveedor")
                        precioMaterial.claveProveedor = If(IsDBNull(row("clave")), "", row("clave"))
                        'row("Clave") '17/06/2020

                        precioMaterial.tiempodeEntrega = row("Días Entrega")
                        precioMaterial.monedaId = row("IdMoneda")
                        precioMaterial.navedesarrollaid = idNave 'row("IdNaveAlta")
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

                        Dim usuarioModificoId As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        Dim usuarioModifico As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

                        precioMaterial.usuarioModificoid = usuarioModificoId
                        precioMaterial.usuarioModifico = usuarioModifico

                        If precioMaterial.existe = 0 Then
                            obj.removerPreciosConMismoProveedorXnave(precioMaterial.proveedorId, precioMaterial.idMaterialNave) 'Remueve todos los precios del mismo proveedor asignados a ese material de la nave
                            obj.insertPrecioMaterial(precioMaterial, AccionMaterial)        'Inserta el nuevo precio del material en say
                            'obj.addPrecioMaterialSICY(precioMaterial)       'Agrega el precio al sicy
                            'obj.spUpdatePrecioMaterialSICY(precioMaterial)  'Actualiza el precio en el sicy si es necesario
                            'obj.ActualizaPrecioFichaTecSICY(precioMaterial) 'Actualiza los consumos para ese proveedor y ese material asignado a la nave
                        ElseIf precioMaterial.existe = 2 Then
                            obj.removerPreciosConMismoProveedorXnave(precioMaterial.proveedorId, precioMaterial.idMaterialNave) 'Remueve todos los precios del mismo proveedor asignados a ese material de la nave
                            'obj.removePrecioMaterial(precioMaterial)       'remueve el precio anterior en say
                            obj.insertPrecioMaterial(precioMaterial, AccionMaterial)        'Inserta nuevo precio actualizado
                            'obj.spUpdatePrecioMaterialSICY(precioMaterial)  'Actualiza el precio en el sicy si es necesario
                            'obj.ActualizaPrecioFichaTecSICY(precioMaterial) 'Actualiza los consumos para ese proveedor y ese material asignado a la nave
                        End If
                    End If
                Next





                tmp = obj.getidMaterialNavesXidMaterial(idMaterial)
                Dim tmp2 As New DataTable


                For Each row As DataRow In tablePreciosMateriales.Rows
                    If row("seleccion") = 1 Then
                        For Each row2 As DataRow In tmp.Rows
                            If row2(0) <> idNave Then
                                tmp2 = obj.getProveedorAsignado(row("dageproveedorid"), row2(0))
                                If tmp2.Rows.Count = 0 Then
                                    obj.insertProveedorNave(row("dageproveedorid"), row2(0))
                                End If
                                ban = True
                                precioMaterial.idMaterialSICY = 0
                                precioMaterial.idMaterialNave = row2(1)
                                precioMaterial.naveId = row2(0)
                                precioMaterial.precioUnitario = row("Precio")
                                precioMaterial.proveedorId = row("idProveedor")
                                precioMaterial.proveedordgId = row("dageproveedorid")
                                precioMaterial.proveedor = row("Proveedor")
                                precioMaterial.preciosmaterialid = row("PrecioMaterialId")
                                precioMaterial.equivalenciaUMP = row("Factor de conversión")
                                precioMaterial.umc = row("umc")
                                precioMaterial.ump = row("ump")
                                precioMaterial.idumc = row("idumprov")
                                precioMaterial.idump = row("idumprod")
                                precioMaterial.descripcion = txtDescripcion.Text.Trim
                                precioMaterial.descripcionProv = row("Descripción Material Proveedor")
                                precioMaterial.claveProveedor = If(IsDBNull(row("clave")), "", row("clave"))
                                'row("Clave") '17/06/2020
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
                                    obj.insertPrecioMaterial(precioMaterial, AccionMaterial)        'Inserta el nuevo precio del material en say
                                    'obj.addPrecioMaterialSICY(precioMaterial)       'Agrega el precio al sicy
                                    'obj.spUpdatePrecioMaterialSICY(precioMaterial)  'Actualiza el precio en el sicy si es necesario
                                    'obj.ActualizaPrecioFichaTecSICY(precioMaterial) 'Actualiza los consumos para ese proveedor y ese material asignado a la nave
                                ElseIf precioMaterial.existe = 2 Then
                                    obj.removerPreciosConMismoProveedorXnave(precioMaterial.proveedorId, precioMaterial.idMaterialNave) 'Remueve todos los precios del mismo proveedor asignados a ese material de la nave
                                    'obj.removePrecioMaterial(precioMaterial)       'remueve el precio anterior en say
                                    obj.insertPrecioMaterial(precioMaterial, AccionMaterial)        'Inserta nuevo precio actualizado
                                    'obj.spUpdatePrecioMaterialSICY(precioMaterial)  'Actualiza el precio en el sicy si es necesario
                                    'obj.ActualizaPrecioFichaTecSICY(precioMaterial) 'Actualiza los consumos para ese proveedor y ese material asignado a la nave
                                End If

                            End If
                        Next
                    End If
                Next



            Else


                For Each row As DataRow In tablePreciosMateriales.Rows
                    If row("seleccion") = 1 Then
                        ban = True
                        obj.asignarProveedor(idNave, row("dageproveedorid"))
                        precioMaterial.idMaterialSICY = material.materialIdSICY
                        precioMaterial.idMaterialNave = material.materialIdNave
                        precioMaterial.naveId = row("nave_naveid") ' idNave
                        precioMaterial.precioUnitario = row("Precio")
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
                        precioMaterial.descripcion = txtDescripcion.Text.Trim
                        precioMaterial.descripcionProv = row("Descripción Material Proveedor")
                        precioMaterial.claveProveedor = If(IsDBNull(row("clave")), "", row("clave"))
                        'row("Clave") '17/06/2020
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
                            precioMaterial.navedesarrollaid = idNave
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
                        'precioMaterial.naveDesarrolla = row("Nave Alta")
                        If precioMaterial.existe = 0 Then
                            obj.removerPreciosConMismoProveedorXnave(precioMaterial.proveedorId, precioMaterial.idMaterialNave) 'Remueve todos los precios del mismo proveedor asignados a ese material de la nave
                            obj.insertPrecioMaterial(precioMaterial, AccionMaterial)        'Inserta el nuevo precio del material en say
                            'obj.addPrecioMaterialSICY(precioMaterial)       'Agrega el precio al sicy
                            'obj.spUpdatePrecioMaterialSICY(precioMaterial)  'Actualiza el precio en el sicy si es necesario
                            'obj.ActualizaPrecioFichaTecSICY(precioMaterial) 'Actualiza los consumos para ese proveedor y ese material asignado a la nave
                        ElseIf precioMaterial.existe = 2 Then
                            obj.removerPreciosConMismoProveedorXnave(precioMaterial.proveedorId, precioMaterial.idMaterialNave) 'Remueve todos los precios del mismo proveedor asignados a ese material de la nave
                            'obj.removePrecioMaterial(precioMaterial)       'remueve el precio anterior en say
                            obj.insertPrecioMaterial(precioMaterial, AccionMaterial)        'Inserta nuevo precio actualizado
                            'obj.spUpdatePrecioMaterialSICY(precioMaterial)  'Actualiza el precio en el sicy si es necesario
                            'obj.ActualizaPrecioFichaTecSICY(precioMaterial) 'Actualiza los consumos para ese proveedor y ese material asignado a la nave
                        End If
                    End If
                Next


            End If
        Catch ex As Exception
            advertencia.mensaje = "Error al guardar los precios del material. Error: " & ex.Message
            advertencia.ShowDialog()
            'Me.Close()
        End Try
    End Sub
    Private Sub grdAltaPrecio_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdAltaPrecio.ClickCell
        Try
            grdAltaPrecio.ActiveRow.Selected = True
        Catch ex As Exception
        End Try
        Try
            precioSeleccionado = grdAltaPrecio.ActiveRow.Cells("precioMaterialId").Value
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim precioMaterial As New Entidades.PrecioMaterial
        Dim obj As New MaterialesBU
        If grdAltaPrecio.Rows.Count > 0 Then
            If grdAltaPrecio.ActiveRow.Selected Then
                For Each row As DataRow In tablePreciosDeMaterial.Rows
                    If row(13) = grdAltaPrecio.ActiveRow.Cells(13).Text Then
                        Dim objMensaje As New Tools.ConfirmarForm
                        objMensaje.mensaje = "¿Estás seguro de eliminar el precio del material seleccionado?"
                        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                            If row(12) > 0 Then
                                precioMaterial.preciosmaterialid = Convert.ToInt32(row(13))
                                obj.removePrecioMaterial(precioMaterial)
                            End If
                            row.Delete()
                            grdAltaPrecio.DataSource = Nothing
                            grdAltaPrecio.DataSource = tablePreciosDeMaterial
                        End If
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub cmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoria.SelectedIndexChanged
        If cargada = True Then
            If cmbCategoria.SelectedIndex > 0 Then
                m.categoria = cmbCategoria.SelectedValue
                llenarComboMaterialRemplazo(m)
                EDITAR = 0
                armarSKU()
                If modificar = 1 Then
                    modificarSKU()
                End If
            Else
                m.categoria = 0
                llenarComboMaterialRemplazo(m)
            End If
        Else
            If cmbCategoria.SelectedIndex > 0 Then
                m.categoria = cmbCategoria.SelectedValue
                llenarComboMaterialRemplazo(m)
            Else
                m.categoria = 0
                llenarComboMaterialRemplazo(m)
            End If

        End If
    End Sub
    Private Sub cmbTipoMaterial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoMaterial.SelectedIndexChanged
        If cargada Then
            If cmbTipoMaterial.SelectedIndex > 0 Then
                m.tipoMaterial = cmbTipoMaterial.SelectedValue
                llenarComboCategorias(m.tipoMaterial)
                llenarComboMaterialRemplazo(m)
            Else
                m.tipoMaterial = 0
                llenarComboMaterialRemplazo(m)
                cmbCategoria.DataSource = Nothing
            End If
        Else
            If cmbTipoMaterial.SelectedIndex > 0 Then
                m.tipoMaterial = cmbTipoMaterial.SelectedValue
                llenarComboCategorias(m.tipoMaterial)
            Else
                m.tipoMaterial = 0
            End If
        End If
        Try
            For Each s As SKU In listTipoMaterial
                If s.id = cmbTipoMaterial.SelectedValue.ToString Then
                    'EDITAR = 0
                    skuTipoMaterial = s.sku
                End If
            Next
            armarSKU()
            If modificar = 1 Then
                modificarSKU()
            End If
            generarNombre()
        Catch ex As Exception
        End Try
        'Try
        '    If accion = "NUEVO" Or accion2 = "NUEVO" Then
        '        If tipoMaterialSelecto = 1 Then
        '            cbxExclusivo.Enabled = True
        '            rdoDesarrollo.Enabled = True
        '            rdoDesarrollo.Checked = True
        '        Else
        '            cbxExclusivo.Enabled = False
        '            rdoDesarrollo.Enabled = False
        '            rdoProduccion.Checked = True
        '        End If
        '    End If
        'Catch ex As Exception
        'End Try
        Try
            If accion = "NUEVO" Or accion2 = "NUEVO" Then
                If cmbTipoMaterial.SelectedValue = 1 Then
                    cbxExclusivo.Enabled = True
                    rdoDesarrollo.Enabled = True
                    gbxActivoNave.Enabled = False
                    rdoDesarrollo.Checked = True
                Else
                    cbxExclusivo.Enabled = False
                    rdoDesarrollo.Enabled = False
                    rdoProduccion.Checked = True
                    cbxExclusivo.Checked = False
                    gbxActivoNave.Enabled = True
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub
    Private Sub aplicarPermisos()

        If accion = "NUEVO" Then
        ElseIf accion = "EDITAR" Then
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "MODMATPRINCIPAL") Then
                txtDescripcion.ReadOnly = True
                txtSKU.ReadOnly = False
                cmbTipoMaterial.Enabled = False
                cmbClas.Enabled = False
                cmbCategoria.Enabled = False
                rdboActivo.Enabled = True
                rdboInactivo.Enabled = True
            Else
                txtDescripcion.ReadOnly = True
                txtSKU.ReadOnly = True
                cmbTipoMaterial.Enabled = False
                cmbClas.Enabled = False
                cmbCategoria.Enabled = False
                cmbColor.Enabled = False
                cmbTam.Enabled = False
                rdboActivo.Enabled = False
                rdboInactivo.Enabled = False
            End If

        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOCOMPRAS") And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISODESARROLLO") Then
            If accion = "EDITAR" Then
                cmbTipoMaterial.Enabled = False
            Else
                cmbTipoMaterial.Enabled = True
            End If

        ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOCOMPRAS") Then
            If EDITAR = 1 Then
                cmbTipoMaterial.Enabled = False
            Else
                'cmbTipoMaterial.SelectedValue = 2
                cmbTipoMaterial.Enabled = False
            End If
        ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISODESARROLLO") Then
            If EDITAR = 1 Then
                cmbTipoMaterial.Enabled = False
            Else
                'cmbTipoMaterial.SelectedValue = 1
                rdoDesarrollo.Checked = True
                cbxExclusivo.Enabled = True
                cmbTipoMaterial.Enabled = False
            End If
        Else
            cmbTipoMaterial.Enabled = False
        End If

    End Sub

    Public Sub validacion()

        Dim obj As New MaterialesBU
        Dim datos As New DataTable
        Dim DTInformacionMAterial As DataTable

        Dim NaveDesarrollaIDMaterial As Integer = 0
        If txtDescripcion.Text.Trim.Length > 0 Then
            If txtIdMaterial.Text.Trim.Length = 0 Then
                datos = obj.getMaterialesConcidencias(txtNombre.Text, cmbCategoria.SelectedValue, cmbClas.SelectedValue, cmbColor.SelectedValue, cmbTam.SelectedValue, cmbTipoMaterial.SelectedValue)
                If datos.Rows.Count > 0 Then
                    Dim form As New PosibleMaterialesForm
                    form.datos = datos

                    If form.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                        noGuardar = form.noGuardar
                        copiado = form.copiado
                    Else
                        copiado = form.copiado
                        idMaterial = form.idMaterial
                        idMaterialSicy = form.idMaterialSicy
                        NaveDesarrollaIDMaterial = form.NAveDesarrollaIDMAterial
                        idNaveDesarrolloMaterial = NaveDesarrollaIDMaterial
                        PMAterialesNaveDesarrollaIDMaterial = NaveDesarrollaIDMaterial
                        DTInformacionMAterial = obj.getMaterial(idMaterial)

                        If DTInformacionMAterial.Rows.Count > 0 Then
                            'txtNombre.Text = form.NombreMaterial.Trim().ToString()
                            txtNombre.Text = DTInformacionMAterial.Rows(0).Item("mate_nombreMaterial").ToString
                        End If

                        CargarCaracteristicas()

                        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "MODMATPRINCIPAL") Then


                            If estatus = "P" Or estatus = "p" Then
                                txtNombre.Enabled = False
                            Else
                                If idNaveDesarrolloMaterial = idNave Then
                                    txtNombre.Enabled = True
                                Else
                                    txtNombre.Enabled = False
                                End If
                            End If
                        Else
                            txtNombre.Enabled = False
                        End If


                        If (idMaterial > 0) Then
                            'Verifica si existe el material en nave
                            Dim tmp As DataTable = obj.verificaridMaterialEnNave(idMaterial, idNave)
                            If tmp.Rows.Count > 0 Then
                                idMaterialNave = Convert.ToInt32(tmp.Rows(0).Item(0).ToString)
                            End If
                            getDatosDeMaterial()
                            accion = "EDITAR" 'Al momento de guardar indica que es una edición
                            aplicarPermisos()

                            If NaveDesarrollaIDMaterial <> idNave Then
                                rdoDesarrollo.Enabled = False
                                rdoProduccion.Enabled = False
                                cmbColor.Enabled = False
                                cmbTam.Enabled = False
                                btnAgregarColor.Enabled = False
                                btnAgregarTamano.Enabled = False
                            End If

                            If idMaterialNave > 0 Then
                                inicarTablaDePreciosDeMaterial()
                            ElseIf cmbTipoMaterial.Text = "DIRECTO" Then
                                inicarTablaDePreciosDeMaterialDesarrollo()
                                If exclusive = True Then
                                    cbxExclusivo.Checked = True
                                    cbxExclusivo.Enabled = False
                                Else
                                    cbxExclusivo.Checked = False
                                    cbxExclusivo.Enabled = False
                                End If
                            End If
                            ' grdCaracterisitcas.DataSource = obj.consultaCaracteristicas(idMaterial)
                        End If
                    End If
                End If
            End If
        End If


    End Sub


    Private Sub cmbClas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClas.SelectedIndexChanged
        If cargada = True Then
            If cmbClas.SelectedIndex > 0 Then
                m.clasificacion = cmbClas.SelectedValue
                llenarComboMaterialRemplazo(m)
                EDITAR = 0
                armarSKU()
                If modificar = 1 Then
                    modificarSKU()
                End If
            Else
                m.clasificacion = 0
                llenarComboMaterialRemplazo(m)
            End If
        Else
            If cmbClas.SelectedIndex > 0 Then
                m.clasificacion = cmbClas.SelectedValue
            Else
                m.clasificacion = 0
            End If
        End If
        Try
            For Each s As SKU In listClasificaciones
                If s.id = cmbClas.SelectedValue.ToString Then
                    'EDITAR = 0
                    skuClasificaciones = s.sku
                End If
            Next
            armarSKU()
            If modificar = 1 Then
                modificarSKU()
            End If
            generarNombre()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmbMaterialRemplazo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMaterialRemplazo.SelectedIndexChanged
        If cmbMaterialRemplazo.SelectedIndex > 0 Then
            idMaterialRemplazo = cmbMaterialRemplazo.SelectedValue
        End If
    End Sub

    Private Sub cmbColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColor.SelectedIndexChanged
        Try
            For Each s As SKU In listColores
                If s.id = cmbColor.SelectedValue.ToString Then
                    EDITAR = 0
                    skuColores = s.sku
                End If
            Next
            armarSKU()
            If modificar = 1 Then
                modificarSKU()
            End If
            generarNombre()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub armarSKU()
        If EDITAR = 0 Then
            If idMaterial > 0 Then
                txtSKU.Text = skuTipoMaterial + skuClasificaciones + skuTamaños + skuColores + idMaterial.ToString
            Else
                txtSKU.Text = skuTipoMaterial + skuClasificaciones + skuTamaños + skuColores
            End If
        End If
    End Sub

    Public Sub modificarSKU()

        txtSKU.Text = skuTipoMaterial + skuClasificaciones + skuTamaños + skuColores + idMaterial.ToString

    End Sub

    Private Sub cmbTam_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTam.SelectedIndexChanged
        Try
            For Each s As SKU In listTamaños
                If s.id = cmbTam.SelectedValue.ToString Then
                    EDITAR = 0
                    skuTamaños = s.sku

                End If
            Next
            armarSKU()
            If modificar = 1 Then
                modificarSKU()
            End If
            generarNombre()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdAltaPrecio_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdAltaPrecio.DoubleClickCell
        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISODESARROLLO") And tipoNave = "D" And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PRECIOS") Then
        '    editarPrecioShow()
        'ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISODESARROLLO") And tipoNave = "P" And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PRECIOS") Then

        'ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOCOMPRAS") And tipoNave = "D" And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PRECIOS") Then
        '    editarPrecioShow()
        'ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PERMISOCOMPRAS") And tipoNave = "P" And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PRECIOS") Then
        '    editarPrecioShow()
        'End If
    End Sub
    Private Sub rdboActivo_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyData = "9" Then
            cmbDepartamento.Focus()
        End If
    End Sub
    Private Sub rdboInactivo_KeyUp(sender As Object, e As KeyEventArgs) Handles rdboInactivo.KeyUp
        If e.KeyData = "9" Then
            cmbDepartamento.Focus()
        End If
    End Sub
    Private Sub rdoInactivoNave_KeyUp(sender As Object, e As KeyEventArgs) Handles rdoInactivoNave.KeyUp
        If e.KeyData = "9" Then
            btnGuardar.Focus()
        End If
    End Sub
    Private Sub bntSalir_KeyUp(sender As Object, e As KeyEventArgs) Handles bntSalir.KeyUp
        If e.KeyData = "9" Then
            cmbTipoMaterial.Focus()
        End If
    End Sub

    Public Sub crearTablaCaracteristicas()
        tablaCaracterisiticas.Columns.Add("ID")
        tablaCaracterisiticas.Columns.Add("CARACTERISTICA")
        tablaCaracterisiticas.Columns.Add(" ")

        grdCaracterisitcas.DataSource = tablaCaracterisiticas
        AgregarFilaCaracteristica()
    End Sub
    Public Sub AgregarFilaCaracteristica()
        grdCaracterisitcas.DisplayLayout.Bands(0).AddNew()
        With grdCaracterisitcas.DisplayLayout.Bands(0)
            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            grdCaracterisitcas.ActiveRow.Cells(" ").Value = False
            grdCaracterisitcas.ActiveRow.Cells("CARACTERISTICA").Activate()
            '.Columns("CARACTERISTICA").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Upper
        End With
        diseniogridCaracteristicas()
        renglon = renglon + 1
    End Sub

    Public Sub diseniogridCaracteristicas()
        With grdCaracterisitcas.DisplayLayout.Bands(0)
            .Columns(" ").Width = 10
            '.Columns("ID").Width = 40
            .Columns("CARACTERISTICA").Width = 170
            .Columns("CARACTERISTICA").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Lower
        End With
        grdCaracterisitcas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Public Sub diseniogridCaracteristicasconsulta()
        With grdCaracterisitcas.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .Columns("ID").Width = 40
            .Columns("CARACTERISTICA").Width = 170
            .Columns("CARACTERISTICA").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Lower

            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            For value = 0 To grdCaracterisitcas.Rows.Count - 1
                If grdCaracterisitcas.Rows(value).Cells(" ").Value = False Then
                    grdCaracterisitcas.Rows(value).Cells(" ").Value = False
                Else
                    grdCaracterisitcas.Rows(value).Cells(" ").Value = True
                End If
            Next
            'grdCaracterisitcas.ActiveRow.Cells(" ").Value = False

        End With
        grdCaracterisitcas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub grdCaracterisitcas_KeyUp(sender As Object, e As KeyEventArgs) Handles grdCaracterisitcas.KeyUp
        Dim VALUE As String
        VALUE = e.KeyData
        If grdCaracterisitcas.ActiveRow.Cells("CARACTERISTICA").Text <> "" And VALUE = 13 Then
            AgregarFilaCaracteristica()
        End If
    End Sub

    Public Sub leerCaracterisiticas()
        Dim caracteristicas As String = ""
        Try
            For value = 0 To grdCaracterisitcas.Rows.Count - 1
                If grdCaracterisitcas.Rows(value).Cells("CARACTERISTICA").Value <> "" And grdCaracterisitcas.Rows(value).Cells(" ").Value = True Then
                    If caracteristicas.Contains(grdCaracterisitcas.Rows(value).Cells("CARACTERISTICA").Value) = False Then
                        caracteristicas += grdCaracterisitcas.Rows(value).Cells("CARACTERISTICA").Value + " "
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
        txtCaracteristicas.Text = caracteristicas
    End Sub

    Private Sub generarNombre()
        leerCaracterisiticas()
        Dim color, tamano, carac As String
        If cmbColor.Text = "NO APLICA" Then
            color = ""
        Else
            color = " " + cmbColor.Text
        End If
        If cmbTam.Text = "NO APLICA" Then
            tamano = ""
        Else
            tamano = " " + cmbTam.Text
        End If
        If txtCaracteristicas.Text = "" Then
            carac = ""
        Else
            carac = " " + txtCaracteristicas.Text
        End If
        If cmbTipoMaterial.Text = "DIRECTO" Then
            If Len(txtNombre.Text) > 0 Then
                txtDescripcion.Text = cmbClas.Text + " " + txtNombre.Text + color + tamano + carac
            Else
                txtDescripcion.Text = cmbClas.Text + color + tamano + carac
            End If

        Else
            If Len(txtNombre.Text) > 0 Then
                txtDescripcion.Text = txtNombre.Text + color + tamano + carac
            Else
                txtDescripcion.Text = color + tamano + carac
            End If
        End If

    End Sub

    Private Sub grdCaracterisitcas_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdCaracterisitcas.ClickCell
        'generarNombre()
    End Sub

    Private Sub grdCaracterisitcas_Leave(sender As Object, e As EventArgs) Handles grdCaracterisitcas.Leave
        'generarNombre()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If EDITAR = 0 Then
                If grdCaracterisitcas.Rows.Count > 1 Then
                    grdCaracterisitcas.ActiveRow.Delete()
                End If
            End If

        Catch ex As Exception
        End Try
        generarNombre()
    End Sub

    Private Sub grdCaracterisitcas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdCaracterisitcas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub cmbCategoria_TextChanged(sender As Object, e As EventArgs) Handles cmbCategoria.TextChanged
        cmbClas.DataSource = Nothing
        Dim tipomat As Integer
        Try
            If cmbCategoria.SelectedValue <> 0 Then
                If cmbTipoMaterial.Text = "DIRECTO" Then
                    tipomat = 1
                End If
                If cmbTipoMaterial.Text = "INDIRECTO" Then
                    tipomat = 0
                End If
                llenarComboClasificaciones(cmbCategoria.SelectedValue, tipomat)
            End If
        Catch ex As Exception

        End Try
        cmbColor.SelectedValue = 0
        generarNombre()
        armarSKU()
        If modificar = 1 Then
            modificarSKU()
        End If

    End Sub

    Private Sub cmbClas_TextChanged(sender As Object, e As EventArgs) Handles cmbClas.TextChanged
        cmbColor.DataSource = Nothing
        cmbTam.DataSource = Nothing
        Try
            If cmbClas.SelectedValue <> 0 Then
                llenarColores(cmbClas.SelectedValue)
                cmbColor.SelectedValue = 1
                llenarTamaños(cmbClas.SelectedValue)
                cmbTam.SelectedValue = 1
            End If
        Catch ex As Exception
        End Try
        'EDITAR = 0
        armarSKU()
        If modificar = 1 Then
            modificarSKU()
        End If

        Try
            For Each s As SKU In listColores
                If s.id = cmbColor.SelectedValue.ToString Then
                    EDITAR = 0
                    skuColores = s.sku
                End If
            Next
            armarSKU()
            If modificar = 1 Then
                modificarSKU()
            End If
            generarNombre()
        Catch ex As Exception
        End Try
        Try

            For Each s As SKU In listTamaños
                If s.id = cmbTam.SelectedValue.ToString Then
                    EDITAR = 0
                    skuTamaños = s.sku

                End If

            Next
            armarSKU()
            If modificar = 1 Then
                modificarSKU()
            End If
            generarNombre()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdCaracterisitcas_Click(sender As Object, e As EventArgs) Handles grdCaracterisitcas.Click
        ' generarNombre()
    End Sub

    Private Sub grdCaracterisitcas_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdCaracterisitcas.AfterCellUpdate
        ' generarNombre()
    End Sub

    ''' <summary>
    ''' obtener valor false o true al seleccionar una celda con checkbox al momento de ultraGrid
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grdCaracterisitcas_CellChange(sender As Object, e As CellEventArgs) Handles grdCaracterisitcas.CellChange
        If e.Cell.Column.ToString = " " Then
            If CBool(e.Cell.Value) Then
                grdCaracterisitcas.ActiveRow.Cells(" ").Value = False
            Else
                grdCaracterisitcas.ActiveRow.Cells(" ").Value = True
            End If
        End If
        generarNombre()
    End Sub

    Private Sub pnlHeader_Click(sender As Object, e As EventArgs) Handles pnlHeader.Click
        ' generarNombre()
    End Sub


    Private Sub txtNombre_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyUp
        generarNombre()
    End Sub

    Private Sub cmbTam_TextChanged(sender As Object, e As EventArgs) Handles cmbTam.TextChanged
        'EDITAR = 0
        generarNombre()
        armarSKU()
        If modificar = 1 Then
            modificarSKU()
        End If
    End Sub

    Private Sub cmbColor_TextChanged(sender As Object, e As EventArgs) Handles cmbColor.TextChanged
        'EDITAR = 0
        generarNombre()
        armarSKU()
        If modificar = 1 Then
            modificarSKU()
        End If
    End Sub

     Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If noPrecio = False Then
            Try
                validacion()
            Catch ex As Exception
            End Try

            If tipoNave = "D" And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AltaMateriales", "PRECIOS") Then
                If EsMaterialExclusivo() Then
                    If precio = 0 And TabControl1.SelectedIndex = 1 Then
                        If Not txtDescripcion.Text.Trim = "" Then
                            Dim form As New NuevoPrecioMaterialForm
                            form.precioMaterial.descripcion = txtDescripcion.Text
                            form.idMaterial = txtIdMaterial.Text
                            form.idNave = idNave
                            form.nuevo = 1
                            AccionMaterial = 1 ' CAMBIO OAMB (10/07/2023)
                            form.NombreNaveDesarrolla = NombreNaveAlta ' naveDesarollaMaterial
                            form.ShowDialog()
                            Dim preciomaterial As Entidades.PrecioMaterial
                            preciomaterial = form.precioMaterial

                            Try
                                If form.cerrado = False Then
                                    If validarPrecioNuevo(preciomaterial.proveedorId) Then
                                        Dim datarow As DataRow = tablePreciosDeMaterial.NewRow()
                                        datarow(0) = 1
                                        datarow(1) = preciomaterial.descripcionProv
                                        datarow(2) = preciomaterial.proveedor
                                        datarow(3) = preciomaterial.precioUnitario
                                        datarow("idMoneda") = preciomaterial.monedaId
                                        datarow("Moneda") = preciomaterial.moneda
                                        datarow(6) = True
                                        datarow(7) = preciomaterial.umc
                                        datarow(8) = preciomaterial.equivalenciaUMP
                                        datarow(9) = preciomaterial.ump
                                        datarow(10) = preciomaterial.claveProveedor
                                        datarow(11) = preciomaterial.fechaRegistro
                                        datarow(12) = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                                        datarow(16) = preciomaterial.proveedorId
                                        datarow(17) = preciomaterial.existe
                                        datarow(18) = preciomaterial.preciosmaterialid
                                        'datarow(10) = Date.Now
                                        'datarow(11) = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                                        'datarow(12) = preciomaterial.proveedorId
                                        'datarow(13) = preciomaterial.existe
                                        'datarow(14) = preciomaterial.preciosmaterialid
                                        datarow("idumprov") = preciomaterial.idumc
                                        datarow("idumprod") = preciomaterial.idump
                                        datarow("Días Entrega") = preciomaterial.tiempodeEntrega
                                        datarow("IdNaveAlta") = idNave
                                        datarow("Nave Alta") = NombreNaveAlta 'naveDesarollaMaterial
                                        datarow("dageproveedorid") = preciomaterial.proveedordgId
                                        datarow("nave_naveid") = idNave
                                        datarow("origenprecio") = preciomaterial.origenpreciomaterial

                                        tablePreciosDeMaterial.Rows.Add(datarow)
                                        grdAltaPrecio.DataSource = Nothing
                                        grdAltaPrecio.DataSource = tablePreciosDeMaterial
                                        diseño()
                                    End If
                                End If
                            Catch ex As Exception
                                advertencia.mensaje = "Información: " & ex.Message
                                advertencia.ShowDialog()
                            End Try
                        Else
                            advertencia.mensaje = "Antes de capturar un precio de material es obligatorio tener una descripción del material."
                            advertencia.ShowDialog()
                        End If
                    End If
                End If

            Else
                'objMensaje.mensaje = "No puede Agregar precio." & vbCrLf & "No es nave de desarrollo"
                'objMensaje.ShowDialog()
                'btnNuevoPrecio.Enabled = False
            End If
        End If
    End Sub

    Private Sub cmbTipoMaterial_TextChanged(sender As Object, e As EventArgs) Handles cmbTipoMaterial.TextChanged
        'EDITAR = 0
        Dim tipomat As Integer
        Try
            armarSKU()
            If modificar = 1 Then
                modificarSKU()
            End If
            If cmbCategoria.SelectedValue <> 0 Then
                If cmbTipoMaterial.Text = "DIRECTO" Then
                    tipomat = 1
                End If
                If cmbTipoMaterial.Text = "INDIRECTO" Then
                    tipomat = 0
                End If
                llenarComboClasificaciones(cmbCategoria.SelectedValue, tipomat)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnAgregarTamano_Click(sender As Object, e As EventArgs) Handles btnAgregarTamano.Click
        Dim form As New TamaniosMateriales
        If form.ShowDialog() = Windows.Forms.DialogResult.Yes Then
            Try
                If cmbClas.SelectedValue <> 0 Then
                    llenarTamaños(cmbClas.SelectedValue)
                    'cmbColor.SelectedValue = 1
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnAgregarColor_Click(sender As Object, e As EventArgs) Handles btnAgregarColor.Click
        Dim form As New ColoresMateriales
        If form.ShowDialog() = Windows.Forms.DialogResult.Yes Then
            Try
                If cmbClas.SelectedValue <> 0 Then
                    llenarColores(cmbClas.SelectedValue)
                    'cmbTam.SelectedValue = 1
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnAgregarDepartamento_Click(sender As Object, e As EventArgs) Handles btnAgregarDepartamento.Click
        Dim form As New DepartamentosMaterialesForm
        form.ShowDialog()
        llenarDepartamentos()
    End Sub

    Public Sub NaveDesarrollaMAterial()
        Dim obj As New MaterialesBU
        naveDesarrollaMaterialTabla = obj.GetNaveDesarrollaMaterial(idMaterial)
    End Sub

    Dim x = 0
    Private Sub rdoProduccion_CheckedChanged(sender As Object, e As EventArgs) Handles rdoProduccion.CheckedChanged
        If x = 0 Then
            If accion2 = "EDITAR" Then
                'accion2 = ""
                Try
                    NaveDesarrollaMAterial()
                    If naveDesarrollaMaterialTabla.Rows(0).Item(0) = idNave Then

                        'validarEstatusProduccion()
                    Else
                        Dim auxiliar = 0
                        If auxiliar = 0 Then
                            x = 1
                            If accion2 = "EDITAR" Then
                                accion2 = ""
                            Else
                                objMensaje.mensaje = "No puede cambiar a producción." & vbCrLf & "No es la nave que lo desarrolla"
                                objMensaje.ShowDialog()
                                rdoDesarrollo.Checked = True
                                rdoProduccion.Checked = False
                                auxiliar = auxiliar + 1
                                x = 1
                            End If

                        End If
                    End If
                Catch ex As Exception
                    x = 1
                    objMensaje.mensaje = "No puede cambiar a producción." & vbCrLf & "No es la nave que lo desarrolla"
                    objMensaje.ShowDialog()
                    rdoDesarrollo.Checked = True
                    rdoProduccion.Checked = False
                    x = 1
                End Try
            ElseIf accion2 = "NUEVO" Then
                'If grdAltaPrecio.Rows.Count < 1 Then
                '    objMensaje.mensaje = "No puede cambiar a producción, falta capturar el precio."
                '    objMensaje.ShowDialog()
                '    rdoDesarrollo.Checked = True
                '    rdoProduccion.Checked = False
                'End If
            ElseIf rdoProduccion.Checked = True Then
                Dim auxiliar = 0
                If tipoNave = "D" Then
                    validarEstatusProduccion()
                End If
                Try
                    NaveDesarrollaMAterial()
                    If naveDesarrollaMaterialTabla.Rows(0).Item(0) = idNave Then
                        validarEstatusProduccion()
                    Else
                        If auxiliar = 0 Then
                            x = 1
                            objMensaje.mensaje = "No puede cambiar a producción." & vbCrLf & "No es la nave que lo desarrolla"
                            objMensaje.ShowDialog()
                            rdoDesarrollo.Checked = True
                            rdoProduccion.Checked = False
                            auxiliar = auxiliar + 1
                            x = 1
                        End If
                    End If
                Catch ex As Exception
                    x = 1
                    objMensaje.mensaje = "No puede cambiar a producción." & vbCrLf & "No es la nave que lo desarrolla"
                    objMensaje.ShowDialog()
                    rdoDesarrollo.Checked = True
                    rdoProduccion.Checked = False
                    x = 1
                End Try
            Else
                If rdoDesarrollo.Checked = True Then
                    Dim auxiliar = 0
                    If tipoNave = "D" Then
                        validarEstatusProduccion()
                    End If
                    Try
                        NaveDesarrollaMAterial()
                        If naveDesarrollaMaterialTabla.Rows(0).Item(0) = idNave Then
                            validarEstatusProduccion()
                        Else
                            If auxiliar = 0 Then
                                x = 1
                                objMensaje.mensaje = "No puede cambiar a desarrollo." & vbCrLf & "No es la nave que lo desarrolla"
                                objMensaje.ShowDialog()
                                rdoProduccion.Checked = True
                                rdoDesarrollo.Checked = False
                                auxiliar = auxiliar + 1
                                x = 1
                            End If
                        End If
                    Catch ex As Exception
                        x = 1
                        objMensaje.mensaje = "No puede cambiar a desarrollo." & vbCrLf & "No es la nave que lo desarrolla"
                        objMensaje.ShowDialog()
                        rdoProduccion.Checked = True
                        rdoDesarrollo.Checked = False
                        x = 1
                    End Try
                End If
            End If
        End If
        x = 0
    End Sub
    Function validarEstatusProduccion() As Boolean
        If rdoProduccion.Checked Then
            Dim obj As New MaterialesBU
            Dim d As New DataTable
            d = obj.validarPrecioActivoMaterialNave(idMaterialNave)
            If Not d.Rows.Count > 0 Then
                advertencia.mensaje = "Falta capturar un precio al material."
                advertencia.ShowDialog()
                rdoDesarrollo.Checked = True
                Return False
            End If
        End If
        Return True
    End Function
    Function validarPrecioNuevo(ByVal idProveedor As Integer) As Boolean
        Dim precios As New DataTable
        precios = grdAltaPrecio.DataSource

        For Each Fila As UltraGridRow In grdAltaPrecio.Rows
            If Fila.Cells("idProveedor").Value = idProveedor Then
                If CBool(Fila.Cells("Activo").Value) Then
                    If Not Fila.Cells("idNaveAlta").Value = idNave Then 'Cambiar por nave que lo desarrollo
                        advertencia.mensaje = "Ya existe un precio para el proveedor seleccionado, da aviso a la nave que dió de alta el proveedor y precio para que haga la actualización del precio."
                        advertencia.ShowDialog()
                        Return False
                    Else
                        If Fila.Cells("idNaveAlta").Value = idNave Then 'Cambiar por nave que lo desarrollo
                            advertencia.mensaje = "Ya existe un precio para el proveedor seleccionado."
                            advertencia.ShowDialog()
                            Return False
                        End If
                    End If
                End If

            End If
        Next

        Return True

        'For Each row As DataRow In precios.Rows
        '    If row("idProveedor") = idProveedor Then
        '        If CBool(row("Activo")) Then
        '            If Not row("idNaveAlta") = idNave Then 'Cambiar por nave que lo desarrollo
        '                advertencia.mensaje = "Ya existe un precio para el proveedor seleccionado, da aviso a la nave que dió de alta el proveedor y precio para que haga la actualización del precio."
        '                advertencia.ShowDialog()
        '                Return False
        '            End If
        '        End If
        '    End If
        'Next
        'Return True
    End Function
    Function validarMaterialExclusivo() As Boolean
        If cbxExclusivo.Checked Then
            If idNaveDesarrolloMaterial = idNave Then
                Return True
            Else
                Dim dt As New DataTable
                Dim obj As New MaterialesBU
                dt = obj.getNaveSAY(idNaveDesarrolloMaterial)
                If dt.Rows.Count > 0 Then
                    advertencia.mensaje = "El material es exclusivo de la nave " & dt.Rows(0).Item(1).ToString & ", da aviso a la nave que dió de alta el proveedor y precio para que haga la actualización del precio."
                    advertencia.ShowDialog()
                Else
                    advertencia.mensaje = "El material es exclusivo de la nave, da aviso a la nave que dió de alta el proveedor y precio para que haga la actualización del precio."
                    advertencia.ShowDialog()
                End If
                Return False
            End If
        Else
            Return True
        End If

    End Function

    Public Function EsMaterialExclusivo() As Boolean
        If cbxExclusivo.Checked Then
            If idNaveDesarrolloMaterial = idNave Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Private Sub cbxExclusivo_CheckedChanged(sender As Object, e As EventArgs) Handles cbxExclusivo.CheckedChanged
        Dim contador = 0
        Dim NaveDesarrollaMaterialID_aux As Integer = 0
        Dim obj As New MaterialesBU
        Dim EsNaveDesarrollaMAterial As Boolean = False
        Dim DTMAterialDesarrolla As DataTable
        DTMAterialDesarrolla = obj.GetNaveDesarrollaMaterial(idMaterial)

        If DTMAterialDesarrolla.Rows.Count > 0 Then
            NaveDesarrollaMaterialID_aux = DTMAterialDesarrolla.Rows(0).Item("mate_navedesarrollaid").ToString
        End If


        If aux = 0 Then
            Try
                NaveDesarrollaMAterial()
                If accion = "EDITAR" Then
                    ' accion = ""
                    'If naveDesarrollaMaterialTabla.Rows(0).Item(0) = idNave Then
                    'Else
                    '    objMensaje.mensaje = "No puede poner el material como exclusivo." & vbCrLf & "No es la nave que lo desarrolla"
                    '    objMensaje.ShowDialog()
                    '    aux = 1
                    '    If cbxExclusivo.Checked = True Then
                    '        cbxExclusivo.Checked = False
                    '    Else
                    '        cbxExclusivo.Checked = True
                    '    End If
                    '    cbxExclusivo.Enabled = False
                    '    accion = ""
                    'End If
                    For value = 0 To grdAltaPrecio.Rows.Count - 1
                        'nave_naveid

                        If grdAltaPrecio.Rows(value).Cells("Activo").Value = True Then
                            contador = contador + 1
                            If grdAltaPrecio.Rows(value).Cells("nave_naveid").Value = NaveDesarrollaMaterialID_aux Then
                                EsNaveDesarrollaMAterial = True
                            End If

                        End If
                    Next
                    ' aux = 1
                    If contador > 1 Then
                        If estatus = "P" Then
                            'objMensaje.mensaje = "No puede modificar campo exclusivo." & vbCrLf & "el material se encuentra en estatus de producción"
                            'objMensaje.ShowDialog()

                            If EsNaveDesarrollaMAterial = True Then
                                aux = 1
                                If exclusivo = True Then
                                    cbxExclusivo.Checked = True
                                Else
                                    cbxExclusivo.Checked = False
                                End If
                            Else
                                objMensaje.mensaje = "No puede modificar campo exclusivo." & vbCrLf & " el precio activo debe de pertenecer a la nave quien dio de alta el precio."
                                objMensaje.ShowDialog()
                                aux = 1
                                cbxExclusivo.Checked = False
                            End If

                        ElseIf estatus = "D" And contador > 1 Then
                            objMensaje.mensaje = "No puede modificar campo exclusivo." & vbCrLf & "el material ya tiene mas de un precio activo"
                            objMensaje.ShowDialog()
                            aux = 1
                            cbxExclusivo.Checked = False
                        End If
                    ElseIf estatus = "P" Then
                        'objMensaje.mensaje = "No puede modificar campo exclusivo." & vbCrLf & "el material se encuentra en estatus de producción"
                        'objMensaje.ShowDialog()

                        If EsNaveDesarrollaMAterial = True Then
                            aux = 1
                            If exclusivo = True Then
                                cbxExclusivo.Checked = True
                            Else
                                cbxExclusivo.Checked = False
                            End If
                        Else
                            objMensaje.mensaje = "No puede modificar campo exclusivo." & vbCrLf & " el precio activo debe de pertenecer a la nave quien dio de alta el precio."
                            objMensaje.ShowDialog()
                            aux = 1
                            cbxExclusivo.Checked = False
                        End If


                        'cbxExclusivo.Checked = False
                    ElseIf grdAltaPrecio.Rows.Count = 0 Then
                        objMensaje.mensaje = "No puede modificar campo exclusivo." & vbCrLf & "el material no tiene precios asignados"
                        objMensaje.ShowDialog()
                        aux = 1
                        cbxExclusivo.Checked = False
                    End If

                ElseIf accion = "NUEVO" Then
                    If grdAltaPrecio.Rows.Count = 0 Then
                        objMensaje.mensaje = "No puede modificar campo exclusivo." & vbCrLf & "el material no tiene precios asignados"
                        objMensaje.ShowDialog()
                        aux = 1
                        cbxExclusivo.Checked = False
                    End If
                Else
                    If naveDesarrollaMaterialTabla.Rows(0).Item(0) <> Nothing Then
                        If naveDesarrollaMaterialTabla.Rows(0).Item(0) = idNave Then
                        Else
                            objMensaje.mensaje = "No puede modificar campo exclusivo." & vbCrLf & "No es la nave que lo desarrolla"
                            objMensaje.ShowDialog()
                            aux = 1
                            If cbxExclusivo.Checked = True Then
                                cbxExclusivo.Checked = False
                            Else
                                cbxExclusivo.Checked = True
                            End If
                            cbxExclusivo.Enabled = False
                            accion = ""
                        End If
                    Else
                        objMensaje.mensaje = "No puede poner el material como exclusivo." & vbCrLf & "No es la nave que lo desarrolla"
                        objMensaje.ShowDialog()
                        aux = 1
                        If cbxExclusivo.Checked = True Then
                            cbxExclusivo.Checked = False
                        Else
                            cbxExclusivo.Checked = True
                        End If
                        cbxExclusivo.Enabled = False
                        accion = ""
                    End If
                End If
            Catch ex As Exception
                objMensaje.mensaje = "No puede poner el material como exclusivo." & vbCrLf & "No es la nave que lo desarrolla"
                objMensaje.ShowDialog()
                aux = 1
                If cbxExclusivo.Checked = True Then
                    cbxExclusivo.Checked = False
                Else
                    cbxExclusivo.Checked = True
                End If
                cbxExclusivo.Enabled = False
            End Try
        End If
        aux = 0
        'accion = "EDITAR"
    End Sub

    Private Sub rdoDesarrollo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoDesarrollo.CheckedChanged
        If accion2 = "EDITAR" Then
            'accion2 = ""
        End If
    End Sub

    Public Sub DesactivarPrecioProveedor()
        Dim obj As New MaterialesBU
        Dim MaterialPrecioID As Integer = 0

        For Each index As Integer In ListaPrecioDesactivados
            obj.DesactivarPrecioMaterialxId(index)
        Next
        'For Each Fila As UltraGridRow In grdAltaPrecio.Rows
        '    If Fila.Cells("Activo").Value = False Then
        '        MaterialPrecioID = Fila.Cells("precioMaterialId").Value
        '        obj.DesactivarPrecioMaterialxId(MaterialPrecioID)
        '    End If
        'Next

    End Sub

    Private Sub btnInactivar_Click(sender As Object, e As EventArgs) Handles btnInactivar.Click
        Dim obj As New MaterialesBU
        Dim ProveedorIDPRecio As Integer = 0
        Dim NaveIDAltaPrecio As Integer = 0
        Dim MaterialPrecioIDSeleccionado As Integer = 0
        Dim contadorPreciosActivos As Integer = 0
        ProveedorIDPRecio = grdAltaPrecio.ActiveRow.Cells("idProveedor").Value
        NaveIDAltaPrecio = grdAltaPrecio.ActiveRow.Cells("nave_naveid").Value

        For Each Fila As UltraGridRow In grdAltaPrecio.Rows
            If Fila.Cells("Activo").Value = True Then
                contadorPreciosActivos = contadorPreciosActivos + 1
            End If
        Next

        If contadorPreciosActivos = 1 Then
            advertencia.mensaje = "Se debe de tener al menos un precio activo."
            advertencia.ShowDialog()
            Return
        End If

        If grdAltaPrecio.ActiveRow.Cells("precioMaterialId").Value = 0 Then
            MaterialPrecioIDSeleccionado = -1
        Else
            MaterialPrecioIDSeleccionado = grdAltaPrecio.ActiveRow.Cells("precioMaterialId").Value
        End If

        If idNave <> NaveIDAltaPrecio Then
            advertencia.mensaje = "Sola la nave que dio de alta el precio puede desactivarlo."
            advertencia.ShowDialog()

        Else

            If MaterialPrecioIDSeleccionado = -1 Then
                advertencia.mensaje = "No se puede desactivar un precio que se acaba de dar de alta."
                advertencia.ShowDialog()
            Else
                If obj.ExisteMaterialEnConsumo(idMaterial, ProveedorIDPRecio) = True Then
                    advertencia.mensaje = "El precio del material con ese proveedor no se puede desactivar debido a que es utilizado en los consumos."
                    advertencia.ShowDialog()
                Else


                    objConfirmacion.mensaje = "¿Está seguro de desactivar" & vbCrLf & "el precio del proveedor seleccionado?"
                    If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                        grdAltaPrecio.ActiveRow.Cells("Activo").Value = False
                        ListaPrecioDesactivados.Add(grdAltaPrecio.ActiveRow.Cells("precioMaterialId").Value)
                    End If
                End If
            End If


        End If

        'If precioSeleccionado <> 0 Then
        '    objConfirmacion.mensaje = "¿Está seguro de desactivar" & vbCrLf & "el precio del proveedor seleccionado?"
        '    If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
        '        obj.DesactivarPrecioMaterial(precioSeleccionado)
        '        objExito.mensaje = "Precio desactivado con éxito"
        '        objExito.ShowDialog()
        '        inicarTablaDePreciosDeMaterial()
        '    End If
        'End If
    End Sub

    Private Sub grdCaracterisitcas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCaracterisitcas.InitializeLayout

    End Sub


End Class