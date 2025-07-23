
Imports Entidades
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Produccion.Negocios
Imports Stimulsoft.Report
Imports Tools

Public Class ProductosporNaveForm

    Dim entidad As New Consumos

    Dim obj As New catalagosBU

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm
    Public NaveDesarrollaId As Integer = 0

    Dim TipodeNave As Integer = 0
    Dim nave As Integer
    Dim combo As Integer
    Dim marca As Integer
    Dim coleccion As Integer
    Dim idestilo As Integer
    Dim codigo As Integer
    Dim consumos As Integer = 0

    Dim estatus As String

    Dim listaNaves As New List(Of Integer)
    Dim listaEstilos As New List(Of Integer)

    Dim naveMaquila As Boolean = False
    Dim PermisoModificar As Boolean = False

    Dim tipoNave2 As New DataTable
    Dim lsta As New DataTable
    Public listaMaterialesDesarrollo As New DataTable

    Dim tblPermisosEspecialesPorUsuario As New DataTable
    Dim tblPermisosPantallaNave As DataTable
    Dim claveAccionModulo As String

    Public Structure EstatusProducto
        Public Shared ReadOnly DESARROLLO As String = "DESARROLLO"
        Public Shared ReadOnly AUTORIZADO_DESARROLLO As String = "AUTORIZADO DESARROLLO"
        Public Shared ReadOnly AUTORIZADO_PRODUCCION As String = "AUTORIZADO PRODUCCIÓN"
        Public Shared ReadOnly INACTIVO_NAVE As String = "INACTIVO NAVE"
        Public Shared ReadOnly DESCONTINUADO As String = "DESCONTINUADO"
    End Structure


    Private Sub ProductosporNaveForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        'Diseño tabla de permisos
        tblPermisosEspecialesPorUsuario.Columns.Add("ClaveModulo")
        tblPermisosEspecialesPorUsuario.Columns.Add("ClaveAccion")
        tblPermisosEspecialesPorUsuario.Columns.Add("Nave")
        tblPermisosEspecialesPorUsuario.Columns.Add("Usuario")
        'cmbEstatus.Items.Add("")
        'cmbEstatus.Items.Add("DESARROLLO")
        'cmbEstatus.Items.Add("AUTORIZADO DESARROLLO")
        'cmbEstatus.Items.Add("AUTORIZADO PRODUCCIÓN")
        'cmbEstatus.Items.Add("INACTIVO NAVE")
        'cmbEstatus.Items.Add("DESCONTINUADO")

        validarPerfiles()
        permisos()
        LlenarListasNaves()
        ' llenarTablaProductos()
        cmbNave.Focus()
        lsta.Columns.Add("idEstatus")
        lsta.Columns.Add("Estatus")
        crearTablaListaMaterialesDesarrollo()
        llenarComboEstatusGeneral()

        'Try
        '    tipoNave2 = obj.TipoNave(cmbNave.SelectedValue)
        '    If tipoNave2.Rows(0).Item(0) = True Then
        '        'llenarComboEstatusGeneral()
        '        llenarComoboMarcas(cmbNave.SelectedValue)
        '        TipodeNave = 1
        '        btnCambiosGlobales.Enabled = True
        '    Else
        '        llenarComboEstatusNaveProduccion()
        '        listaMarcasProduccion(cmbNave.SelectedValue)
        '        TipodeNave = 0
        '        btnCambiosGlobales.Enabled = False
        '    End If


        'If tipoNave2.Rows(0).Item(0) = True Then
        '    '''Nave de desarrollo
        '    ''' Perfil Coordinador de desarrollo
        '    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PCOORD") Then
        '        llenarComboEstatusCoordes()
        '        listaMarcasProduccion(cmbNave.SelectedValue)
        '        TipodeNave = 1
        '    Else
        '        llenarComboEstatusGeneral()
        '        llenarComoboMarcas(cmbNave.SelectedValue)
        '        TipodeNave = 1
        '    End If
        'Else
        '    '''Nave de producción
        '    ''' Perfil Gerente de producción
        '    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PPRODG") Then
        '        llenarComboEstatusCProduccionG()
        '        listaMarcasProduccion(cmbNave.SelectedValue)
        '        TipodeNave = 0
        '    Else
        '        '''Nave de producción
        '        llenarComboEstatusNaveProduccion()
        '        listaMarcasProduccion(cmbNave.SelectedValue)
        '        TipodeNave = 0
        '    End If

        'End If

        ' Catch ex As Exception
        ' End Try



    End Sub

    Public Sub llenarTablaPermisosPantalla()
        If cmbNave.SelectedIndex <> 0 Then

            Dim objBU As New ConsumosBU
            Dim vXmlRegistros As XElement = New XElement("Permisos")
            Dim var_ClaveModulo As String = String.Empty
            Dim var_ClaveAccion As String = String.Empty
            Dim cons_ClaveModulo As String = String.Empty
            Dim cons_ClaveAccion As String = String.Empty
            Dim var_Nave As Integer = cmbNave.SelectedValue
            Dim var_Usuario As Integer = 0

            'VERIFICAMOS QUE LA TABLA TENGA DATOS Y DE SER ASÍ LA BUSCAMOS EN BD SI ES QUE EL MODULO CON EL USUARIO PUEDEN ACCEDER A ACCIONES ADICIONALES.
            If tblPermisosEspecialesPorUsuario.Rows.Count > 0 Then
                For i As Integer = 0 To tblPermisosEspecialesPorUsuario.Rows.Count - 1
                    Dim vNodo As XElement = New XElement("Permiso")
                    If tblPermisosEspecialesPorUsuario.Rows(i).Item("ClaveAccion").ToString <> "" Then

                        var_ClaveModulo = tblPermisosEspecialesPorUsuario.Rows(i).Item("ClaveModulo").ToString
                        var_Usuario = tblPermisosEspecialesPorUsuario.Rows(i).Item("Usuario").ToString
                        vNodo.Add(New XAttribute("ClaveAccion", tblPermisosEspecialesPorUsuario.Rows(i).Item("ClaveAccion").ToString))

                    End If
                    vXmlRegistros.Add(vNodo)
                Next
                tblPermisosPantallaNave = objBU.listadoPermisosPorUsuario(vXmlRegistros.ToString(), var_ClaveModulo, var_Nave, var_Usuario)
            End If
        End If
    End Sub

    Public Sub llenarComboEstatus()
        tipoNave2 = obj.TipoNave(cmbNave.SelectedValue)
        If tipoNave2.Rows(0).Item(0) = True Then
            'Nave de desarrollo
            ' Perfil Coordinador de desarrollo
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PCOORD") Then
                llenarComboEstatusCoordes()
                listaMarcasProduccion(cmbNave.SelectedValue)
                TipodeNave = 1
            Else
                llenarComboEstatusGeneral()
                llenarComoboMarcas(cmbNave.SelectedValue)
                TipodeNave = 1
            End If
        Else
            'Nave de producción
            ' Perfil Gerente de producción
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PPRODG") Then
                llenarComboEstatusCProduccionG()
                listaMarcasProduccion(cmbNave.SelectedValue)
                TipodeNave = 0
            Else
                'Nave de producción
                llenarComboEstatusNaveProduccion()
                listaMarcasProduccion(cmbNave.SelectedValue)
                TipodeNave = 0
            End If
        End If
    End Sub

    ''' <summary>
    ''' Permisos por botones
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub permisos()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "ALTA_CONSUMO") Then
            pblAlta.Visible = True
            llenarTablaPermisos("ALTA_CONSUMO")
        Else
            pblAlta.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "EDITAR_CONSUMO") Then
            pnlEditar.Visible = True
            llenarTablaPermisos("EDITAR_CONSUMO")
        Else
            pnlEditar.Visible = False

        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "ASIGNAR_CONSUMO") Then
            pnlAsignar.Visible = True
            llenarTablaPermisos("ASIGNAR_CONSUMO")
        Else
            pnlAsignar.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "IMPRIMIRFICHA_CONSUMO") Then
            '    btnFichaTecnica.Visible = True
            '    lblFichaTecnica.Visible = True
            'Else
            '    btnFichaTecnica.Visible = False
            '    lblFichaTecnica.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "AUTORIZARDESARROLLO_CONSUMO") Then
            pnlAutorizarD.Visible = True
            llenarTablaPermisos("AUTORIZARDESARROLLO_CONSUMO")
        Else
            pnlAutorizarD.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "AUTORIZARPRODUCCION_CONSUMO") Then
            pnlautorizarP.Visible = True
            llenarTablaPermisos("AUTORIZARPRODUCCION_CONSUMO")
        Else
            pnlautorizarP.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "INACTIVARNAVE_CONSUMO") Then
            pnlInactivar.Visible = True
            llenarTablaPermisos("INACTIVARNAVE_CONSUMO")
        Else
            pnlInactivar.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "DESCONTINUAR_CONSUMO") Then
            pnlDescontinuar.Visible = True
            llenarTablaPermisos("DESCONTINUAR_CONSUMO")
        Else
            pnlDescontinuar.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "ESTATUSANTERIOR_CONSUMO") Then
            pnlEstatusAnterior.Visible = True
            llenarTablaPermisos("ESTATUSANTERIOR_CONSUMO")
        Else
            pnlEstatusAnterior.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "CAMBIOSGLOBALES_CONSUMO") Then
            pnlCambiosGlobales.Visible = True
            llenarTablaPermisos("CAMBIOSGLOBALES_CONSUMO")
        Else
            pnlCambiosGlobales.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "CATALOGOCOMPONENTES_CONSUMO") Then
            '    btnCatalogoComponentes.Visible = True
            '    lblCatalogoComponentes.Visible = True
            'Else
            '    btnCatalogoComponentes.Visible = False
            '    lblCatalogoComponentes.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "SOLO_REPORTES") Then
            pnlExportar.Visible = True
            Panel8.Visible = True
            pnlEditar.Visible = False
            pnlDescontinuar.Visible = False
            pnlAsignar.Visible = False
            pnlAutorizarD.Visible = False
            pnlautorizarP.Visible = False
            pnlCambiosGlobales.Visible = False
            pnlEstatusAnterior.Visible = False
            pnlInactivar.Visible = False
            Panel6.Visible = False
            Panel7.Visible = False



        End If
    End Sub

    Public Sub llenarTablaPermisos(ByVal PermisoPantalla As String)
        Dim ClaveModulo As String = "ConsumosCompleto"
        Dim Usuario As Integer = SesionUsuario.UsuarioSesion.PUserUsuarioid

        tblPermisosEspecialesPorUsuario.Rows.Add(New Object() {ClaveModulo, PermisoPantalla, 0, Usuario})
    End Sub

    Public Sub llenarTablaProductos()
        If cmbNave.Text <> "" Then
            Dim obj As New ConsumosBU
            Dim dtTablaProductos As DataTable
            dtTablaProductos = obj.VerListaProductos(cmbNave.SelectedValue)
            grdProductosRegistrados.DataSource = dtTablaProductos
            disenioGrid()
        End If
    End Sub

    Public Sub CargarComoEstatus()
        Dim objConsumos As New ConsumosBU
        Dim lista As New DataTable
        lista = objConsumos.ObtenerEstatusProductoEstiloConsumos_Estatus(47)
        'Dim R As DataRow = lista.NewRow
        'R("status") = "DESCONTINUADO"
        'R("ID") = 5
        'lista.Rows.Add(R)

        If lista.Rows.Count > 0 Then
            'lista.Rows.InsertAt(lista.NewRow, 0)
            cmbEstatus.DataSource = lista
            cmbEstatus.DisplayMember = "status"
            cmbEstatus.ValueMember = "ID"
        End If


    End Sub

    Public Sub llenarComboEstatusGeneral()
        lsta.Clear()
        lsta.Rows.Add(New Object() {"0", ""})
        lsta.Rows.Add(New Object() {"1", "DESARROLLO"})
        lsta.Rows.Add(New Object() {"2", "AUTORIZADO DESARROLLO"})
        lsta.Rows.Add(New Object() {"3", "AUTORIZADO PRODUCCIÓN"})
        lsta.Rows.Add(New Object() {"4", "INACTIVO NAVE"})
        lsta.Rows.Add(New Object() {"5", "DESCONTINUADO"})
        cmbEstatus.DataSource = lsta
        cmbEstatus.DisplayMember = "Estatus"
        cmbEstatus.ValueMember = "idEstatus"
    End Sub

    Public Sub llenarComboEstatusNaveDesarrollo()
        lsta.Clear()
        lsta.Rows.Add(New Object() {"0", ""})
        lsta.Rows.Add(New Object() {"2", "AUTORIZADO DESARROLLO"})
        lsta.Rows.Add(New Object() {"3", "AUTORIZADO PRODUCCIÓN"})
        lsta.Rows.Add(New Object() {"4", "INACTIVO NAVE"})
        lsta.Rows.Add(New Object() {"5", "DESCONTINUADO"})
        cmbEstatus.DataSource = lsta
        cmbEstatus.DisplayMember = "Estatus"
        cmbEstatus.ValueMember = "idEstatus"
    End Sub

    Public Sub llenarComboEstatusNaveProduccion()
        lsta.Clear()
        lsta.Rows.Add(New Object() {"0", ""})
        lsta.Rows.Add(New Object() {"2", "AUTORIZADO DESARROLLO"})
        lsta.Rows.Add(New Object() {"3", "AUTORIZADO PRODUCCIÓN"})
        lsta.Rows.Add(New Object() {"4", "INACTIVO NAVE"})
        cmbEstatus.DataSource = lsta
        cmbEstatus.DisplayMember = "Estatus"
        cmbEstatus.ValueMember = "idEstatus"
    End Sub

    Public Sub llenarComboEstatusCoordes()
        lsta.Clear()
        lsta.Rows.Add(New Object() {"0", ""})
        lsta.Rows.Add(New Object() {"2", "DESARROLLO"})
        lsta.Rows.Add(New Object() {"3", "AUTORIZADO DESARROLLO"})
        cmbEstatus.DataSource = lsta
        cmbEstatus.DisplayMember = "Estatus"
        cmbEstatus.ValueMember = "idEstatus"
    End Sub

    Public Sub llenarComboEstatusCProduccionG()
        lsta.Clear()
        lsta.Rows.Add(New Object() {"0", ""})
        lsta.Rows.Add(New Object() {"2", "AUTORIZADO DESARROLLO"})
        lsta.Rows.Add(New Object() {"3", "AUTORIZADO PRODUCCIÓN"})
        cmbEstatus.DataSource = lsta
        cmbEstatus.DisplayMember = "Estatus"
        cmbEstatus.ValueMember = "idEstatus"
    End Sub

    Public Sub LlenarListasNaves()
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        'cmbNave = Tools.Controles.ComboNavesSegunUsuarioMaquilas(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PNAVESMAQUILAS"))

    End Sub

    Public Sub llenarComoboMarcas(ByVal nave As Integer)
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.listaDeMarcas(nave)
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbMarca.DataSource = lista
            cmbMarca.DisplayMember = "Marca"
            cmbMarca.ValueMember = "ID"
        End If
    End Sub

    Public Sub listaMarcasProduccion(ByVal nave As Integer)
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.listaMarcasProduccion(nave)
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbMarca.DataSource = lista
            cmbMarca.DisplayMember = "Marca"
            cmbMarca.ValueMember = "ID"
        End If
    End Sub

    Public Sub llenarComboColeccion(ByVal nave As Integer, ByVal marca As Integer)
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.listaColecciones(nave, marca)
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbColeccion.DataSource = lista
            cmbColeccion.DisplayMember = "Coleccion"
            cmbColeccion.ValueMember = "ID"
        End If
    End Sub

    Public Sub llenarComboColeccionNaveDesarrolla(ByVal nave As Integer, ByVal marca As Integer)
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.listaColeccionesNaveDesarrolla(nave, marca)
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbColeccion.DataSource = lista
            cmbColeccion.DisplayMember = "Coleccion"
            cmbColeccion.ValueMember = "ID"
        End If
    End Sub

    Public Sub disenioGrid()
        Dim band As UltraGridBand = Me.grdProductosRegistrados.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        With grdProductosRegistrados.DisplayLayout.Bands(0)
            '.Columns("prod_productoid").Hidden = True
            '.Columns("prod_modelo").Header.Caption = "Modelo"
            .Columns("Código").CellActivation = Activation.NoEdit
            .Columns("Colección").CellActivation = Activation.NoEdit
            .Columns("Modelo").CellActivation = Activation.NoEdit
            .Columns("Piel").CellActivation = Activation.NoEdit
            .Columns("Color").CellActivation = Activation.NoEdit
            .Columns("Corrida").CellActivation = Activation.NoEdit
            .Columns("Total Materiales").CellActivation = Activation.NoEdit
            .Columns("Total Fracciones").CellActivation = Activation.NoEdit
            .Columns("Asignado a Producción").CellActivation = Activation.NoEdit
            .Columns("status").CellActivation = Activation.NoEdit
            .Columns("Cliente").CellActivation = Activation.NoEdit
            .Columns("Marca").CellActivation = Activation.NoEdit
            .Columns("Estatus").CellActivation = Activation.NoEdit
            .Columns("Piel Color").CellActivation = Activation.NoEdit

            .Columns("Color").Hidden = True
            .Columns("Piel").Hidden = True
            .Columns("EstiloID").Hidden = True
            .Columns("status").Hidden = True
            .Columns("Total Fracciones").Hidden = True

            .Columns("Código").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Modelo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total Materiales").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total Fracciones").CellAppearance.TextHAlign = HAlign.Right

            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns(" ").Width = 10
            .Columns("Código").Width = 50
            .Columns("Colección").Width = 100
            .Columns("Modelo").Width = 50
            .Columns("Piel").Width = 60
            .Columns("Color").Width = 60
            .Columns("Corrida").Width = 80
            .Columns("Total Materiales").Width = 90
            .Columns("Total Fracciones").Width = 90
            .Columns("Asignado a Producción").Width = 150
            .Columns("Estatus").Width = 20
            .Columns("Cliente").Width = 150
            .Columns("Piel Color").Width = 150

            .Columns("Estatus").Header.Caption = ""
            .Columns("Total Materiales").Header.Caption = "Total" & vbCrLf & "Materiales"
            .Columns("Total Fracciones").Header.Caption = "Total" & vbCrLf & "Fracciones"
            .Columns("Asignado a Producción").Header.Caption = "Asignación" & vbCrLf & " Producción"

            .Columns("Total Materiales").Format = "##,##0.00"
            .Columns("Total Fracciones").Format = "##,##0.00"

            For value = 0 To grdProductosRegistrados.Rows.Count - 1
                If grdProductosRegistrados.Rows(value).Cells("status").Text = "DESARROLLO" Then
                    grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF00")
                ElseIf grdProductosRegistrados.Rows(value).Cells("status").Text = "AUTORIZADO DESARROLLO" Then
                    grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#31B404")
                ElseIf grdProductosRegistrados.Rows(value).Cells("status").Text = "AUTORIZADO PRODUCCIÓN" Then
                    grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E9AFE")
                ElseIf grdProductosRegistrados.Rows(value).Cells("status").Text = "INACTIVO NAVE" Then
                    grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#424242")
                ElseIf grdProductosRegistrados.Rows(value).Cells("status").Text = "DESCONTINUADO" Then
                    grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#DF0101")
                End If
            Next

            For value = 0 To grdProductosRegistrados.Rows.Count - 1
                grdProductosRegistrados.Rows(value).Cells("Piel Color").Value = grdProductosRegistrados.Rows(value).Cells("Piel").Value & " " & grdProductosRegistrados.Rows(value).Cells("Color").Value
            Next

        End With

        grdProductosRegistrados.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdProductosRegistrados.DisplayLayout.Bands(0).Columns("Total Materiales").Width = 100
        grdProductosRegistrados.DisplayLayout.Bands(0).Columns("Asignado a Producción").Width = 100
    End Sub


    Public Sub disenioGridConsumos()
        Dim band As UltraGridBand = Me.grdBaseConsumos.DisplayLayout.Bands(0)
        With grdBaseConsumos.DisplayLayout.Bands(0)
            For value = 0 To grdBaseConsumos.Rows.Count - 1
                'If grdProductosRegistrados.Rows(value).Cells("status").Text = "DESARROLLO" Then
                'grdBaseConsumos.Rows(value).Cells("Marca").Appearance.ForeColor = System.Drawing.Color.Black
                grdBaseConsumos.Rows(value).Cells("Colección SAY").Appearance.ForeColor = System.Drawing.Color.Black
                grdBaseConsumos.Rows(value).Cells("Modelo SICY").Appearance.ForeColor = System.Drawing.Color.Black
                grdBaseConsumos.Rows(value).Cells("Piel Color").Appearance.ForeColor = System.Drawing.Color.Black
                grdBaseConsumos.Rows(value).Cells("Corrida").Appearance.ForeColor = System.Drawing.Color.Black
                grdBaseConsumos.Rows(value).Cells("Estatus").Appearance.ForeColor = System.Drawing.Color.Black
                grdBaseConsumos.Rows(value).Cells("Naves Asignadas").Appearance.ForeColor = System.Drawing.Color.Black
                grdBaseConsumos.Rows(value).Cells("Orden").Appearance.ForeColor = System.Drawing.Color.Black
                grdBaseConsumos.Rows(value).Cells("Componente").Appearance.ForeColor = System.Drawing.Color.Black
                grdBaseConsumos.Rows(value).Cells("Clasificación").Appearance.ForeColor = System.Drawing.Color.Black
                grdBaseConsumos.Rows(value).Cells("Material").Appearance.ForeColor = System.Drawing.Color.Black
                grdBaseConsumos.Rows(value).Cells("Consumo").Appearance.ForeColor = System.Drawing.Color.Black
                grdBaseConsumos.Rows(value).Cells("UMC").Appearance.ForeColor = System.Drawing.Color.Black
                grdBaseConsumos.Rows(value).Cells("Proveedor").Appearance.ForeColor = System.Drawing.Color.Black
                grdBaseConsumos.Rows(value).Cells("Precio Compra").Appearance.ForeColor = System.Drawing.Color.Black
                grdBaseConsumos.Rows(value).Cells("UMP").Appearance.ForeColor = System.Drawing.Color.Black
                grdBaseConsumos.Rows(value).Cells("Factor").Appearance.ForeColor = System.Drawing.Color.Black
                grdBaseConsumos.Rows(value).Cells("PrecioUM").Appearance.ForeColor = System.Drawing.Color.Black
                grdBaseConsumos.Rows(value).Cells("Costo X Par").Appearance.ForeColor = System.Drawing.Color.Black

                'grdBaseConsumos.Rows(value).Cells("Costo X Par").SelectedAppearance.ForeColor = Color.Black

                'End If
            Next

        End With
        'grdBaseConsumos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdBaseConsumos.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

    End Sub

    'Private Sub grdBaseConsumos_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles grdBaseConsumos.InitializeRow
    '    e.Row.Cells("Marca").Appearance.ForeColor = System.Drawing.Color.Black
    'End Sub

    Public Sub disenioGrid2()
        Dim band As UltraGridBand = Me.grdProductosRegistrados.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        With grdProductosRegistrados.DisplayLayout.Bands(0)

            .Columns("Código").CellActivation = Activation.NoEdit
            .Columns("Colección").CellActivation = Activation.NoEdit
            .Columns("Modelo").CellActivation = Activation.NoEdit
            .Columns("Piel").CellActivation = Activation.NoEdit
            .Columns("Color").CellActivation = Activation.NoEdit
            .Columns("Corrida").CellActivation = Activation.NoEdit
            .Columns("Total Materiales").CellActivation = Activation.NoEdit
            .Columns("Piel Color").CellActivation = Activation.NoEdit
            .Columns("Total Fracciones").CellActivation = Activation.NoEdit
            .Columns("Asignado a Producción").CellActivation = Activation.NoEdit
            .Columns("status").CellActivation = Activation.NoEdit
            .Columns("Cliente").CellActivation = Activation.NoEdit
            .Columns("Marca").CellActivation = Activation.NoEdit 'aqui
            .Columns("Estatus").CellActivation = Activation.NoEdit
            .Columns("Marca").CellActivation = Activation.NoEdit
            .Columns("Imagen").CellAppearance.Cursor = Windows.Forms.Cursors.Hand
            .Columns("Imagen").Width = 130
            .Columns("Ruta").Hidden = True
            If Not cbxVerimagen.Checked Then
                .Columns("Imagen").Hidden = True
            Else
                .Columns("Imagen").Hidden = False
            End If

            .Columns("Marca").Hidden = False 'True
            .Columns("Color").Hidden = True
            .Columns("Piel").Hidden = True
            .Columns("EstiloID").Hidden = True
            .Columns("status").Hidden = True
            '.Columns("Total Fracciones").Hidden = True
            '.Columns("OtroStatus").Hidden = True

            .Columns("Marca").CellAppearance.TextHAlign = HAlign.Center
            .Columns("Código").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Modelo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total Materiales").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total Fracciones").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Archivos Cargados").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Código").CellAppearance.TextHAlign = HAlign.Left

            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns(" ").Width = 10
            .Columns("Código").Width = 90
            .Columns("Código").Header.Caption = "SICY"
            '.Columns("Modelo").Header.Caption = "Código"
            .Columns("Modelo").Header.Caption = "Modelo" & vbCrLf & "SAY"
            .Columns("Colección").Width = 100
            .Columns("Modelo").Width = 60
            .Columns("Piel").Width = 60
            .Columns("Color").Width = 60
            .Columns("Corrida").Width = 80
            .Columns("Total Materiales").Width = 70
            .Columns("Total Fracciones").Width = 70
            .Columns("Asignado a Producción").Width = 150
            .Columns("Estatus").Width = 20
            .Columns("Cliente").Width = 150
            .Columns("Piel Color").Width = 150
            .Columns("Modelo SICY").Width = 50
            .Columns("Modelo SICY").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Estatus").Header.Caption = ""
            .Columns("Total Materiales").Header.Caption = "Total" & vbCrLf & "Materiales"
            .Columns("Total Fracciones").Header.Caption = "Total" & vbCrLf & "Fracciones"
            .Columns("Modelo SICY").Header.Caption = "Modelo" & vbCrLf & "SICY"
            .Columns("Asignado a Producción").Header.Caption = "Asignación" & vbCrLf & " Producción"

            .Columns("Total Materiales").Format = "##,##0.00"
            .Columns("Total Fracciones").Format = "##,##0.000"
            .Columns("Archivos Cargados").Format = "##,##0"

            .Columns("Total Materiales").Width = 50
            .Columns("Total Fracciones").Width = 50

            .Columns("Corrida").Width = 50
            .Columns("pres_navedesarrollaid").Hidden = True




            For value = 0 To grdProductosRegistrados.Rows.Count - 1
                If grdProductosRegistrados.Rows(value).Cells("status").Text = "DESARROLLO" Then
                    grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF00")
                ElseIf grdProductosRegistrados.Rows(value).Cells("status").Text = "AUTORIZADO DESARROLLO" Then
                    grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#31B404")
                ElseIf grdProductosRegistrados.Rows(value).Cells("status").Text = "AUTORIZADO PRODUCCIÓN" Then
                    grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E9AFE")
                ElseIf grdProductosRegistrados.Rows(value).Cells("status").Text = "INACTIVO NAVE" Then
                    grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#424242")
                ElseIf grdProductosRegistrados.Rows(value).Cells("status").Text = "DESCONTINUADO" Then
                    grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#DF0101")
                ElseIf grdProductosRegistrados.Rows(value).Cells("status").Text = "" Then
                    grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF00")
                End If
            Next

            'For value = 0 To grdProductosRegistrados.Rows.Count - 1
            '    grdProductosRegistrados.Rows(value).Cells("Piel Color").Value = grdProductosRegistrados.Rows(value).Cells("Piel").Value & " " & grdProductosRegistrados.Rows(value).Cells("Color").Value
            'Next



        End With

        grdProductosRegistrados.DisplayLayout.Bands(0).Summaries.Clear()

        Dim summary1 As New SummarySettings
        summary1 = grdProductosRegistrados.DisplayLayout.Bands(0).Summaries.Add("Total Archivos", SummaryType.Sum, grdProductosRegistrados.DisplayLayout.Bands(0).Columns("Archivos Cargados"))
        grdProductosRegistrados.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right


        grdProductosRegistrados.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdProductosRegistrados.DisplayLayout.Bands(0).Columns("Total Materiales").Width = 100
        grdProductosRegistrados.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdProductosRegistrados.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        grdProductosRegistrados.DisplayLayout.RowSelectorImages.DataChangedImage = Nothing
        grdProductosRegistrados.DisplayLayout.RowSelectorImages.ActiveAndDataChangedImage = Nothing

        'Dim cUltraGrid As UltraGrid = DirectCast(Me.grdProductosRegistrados.GetType().GetField("grid", Reflection.BindingFlags.CreateInstance Or Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(Me.grdProductosRegistrados), UltraGrid)
        'If Not (cUltraGrid Is Nothing) Then
        '    cUltraGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False
        'End If


        Try
            If cbxVerimagen.Checked Then
                With grdProductosRegistrados.DisplayLayout.Rows(0)
                    .Height = 70
                End With
            Else
                With grdProductosRegistrados.DisplayLayout.Rows(0)
                    .Height = 20
                End With
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub disenioGrid3()
        Dim band As UltraGridBand = Me.grdProductosRegistrados.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        With grdProductosRegistrados.DisplayLayout.Bands(0)

            .Columns("Código").CellActivation = Activation.NoEdit
            .Columns("Colección").CellActivation = Activation.NoEdit
            .Columns("Modelo").CellActivation = Activation.NoEdit
            .Columns("Piel").CellActivation = Activation.NoEdit
            .Columns("Color").CellActivation = Activation.NoEdit
            .Columns("Corrida").CellActivation = Activation.NoEdit
            .Columns("Piel Color").CellActivation = Activation.NoEdit
            .Columns("Total Materiales").CellActivation = Activation.NoEdit
            .Columns("Total Fracciones").CellActivation = Activation.NoEdit
            .Columns("Tiempo").CellActivation = Activation.NoEdit
            .Columns("Estatus").CellActivation = Activation.NoEdit
            .Columns("status").CellActivation = Activation.NoEdit
            .Columns("Cliente").CellActivation = Activation.NoEdit
            .Columns("Marca").CellActivation = Activation.NoEdit
            .Columns("Imagen").CellAppearance.Cursor = Windows.Forms.Cursors.Hand
            .Columns("Imagen").Width = 130



            .Columns("Ruta").Hidden = True
            If Not cbxVerimagen.Checked Then
                .Columns("Imagen").Hidden = True
            Else
                .Columns("Imagen").Hidden = False
            End If

            .Columns("Marca").Hidden = False 'True
            .Columns("Color").Hidden = True
            .Columns("Piel").Hidden = True
            .Columns("EstiloID").Hidden = True
            .Columns("status").Hidden = True
            '.Columns("Total Fracciones").Hidden = True
            .Columns("OtroStatus").Hidden = True

            .Columns("Código").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Marca").CellAppearance.TextHAlign = HAlign.Center
            .Columns("Modelo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total Materiales").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total Fracciones").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Tiempo").CellAppearance.TextHAlign = HAlign.Center
            .Columns("Archivos Cargados").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Código").CellAppearance.TextHAlign = HAlign.Left
            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns(" ").Width = 10
            '.Columns("EstiloID").Width = 50
            .Columns("Código").Width = 90
            .Columns("Colección").Width = 100
            .Columns("Modelo").Width = 50
            .Columns("Código").Header.Caption = "SICY"
            .Columns("Modelo").Header.Caption = "Modelo" & vbCrLf & "SAY"
            '.Columns("Modelo").Header.Caption = "Código"
            .Columns("Piel").Width = 60
            .Columns("Color").Width = 60
            .Columns("Corrida").Width = 50
            .Columns("Total Materiales").Width = 50
            .Columns("Total Fracciones").Width = 50
            .Columns("Tiempo").Width = 50
            '.Columns("Asignado a Producción").Width = 150
            .Columns("Estatus").Width = 20
            .Columns("Cliente").Width = 150
            .Columns("Piel Color").Width = 150

            .Columns("Estatus").Header.Caption = ""
            .Columns("Total Materiales").Header.Caption = "Total" & vbCrLf & "Materiales"
            .Columns("Total Fracciones").Header.Caption = "Total" & vbCrLf & "Fracciones"
            .Columns("Modelo SICY").Header.Caption = "Modelo" & vbCrLf & "SICY"
            ' .Columns("Asignado a Producción").Header.Caption = "Asignación" & vbCrLf & " Producción"

            .Columns("Total Materiales").Format = "$ ##,##0.00"
            .Columns("Total Fracciones").Format = "$ ##,##0.000"
            .Columns("Archivos Cargados").Format = "##,##0"
            .Columns("Modelo SICY").Width = 50
            .Columns("Modelo SICY").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total Materiales").Width = 50
            .Columns("Total Fracciones").Width = 50

            .Columns("pres_navedesarrollaid").Hidden = True

            If cmbEstatus.Text = "DESCONTINUADO" Then
                For value = 0 To grdProductosRegistrados.Rows.Count - 1
                    If grdProductosRegistrados.Rows(value).Cells("status").Text = "DESARROLLO" Then
                        grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF00")
                    ElseIf grdProductosRegistrados.Rows(value).Cells("status").Text = "AUTORIZADO DESARROLLO" Then
                        grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#31B404")
                    ElseIf grdProductosRegistrados.Rows(value).Cells("status").Text = "AUTORIZADO PRODUCCIÓN" Then
                        grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E9AFE")
                    ElseIf grdProductosRegistrados.Rows(value).Cells("status").Text = "INACTIVO NAVE" Then
                        grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#424242")
                    ElseIf grdProductosRegistrados.Rows(value).Cells("status").Text = "DESCONTINUADO" Then
                        grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#DF0101")
                    ElseIf grdProductosRegistrados.Rows(value).Cells("status").Text = "" Then
                        grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF00")
                    End If
                Next
            Else

                For value = 0 To grdProductosRegistrados.Rows.Count - 1
                    If grdProductosRegistrados.Rows(value).Cells("OtroStatus").Text = "D" Then
                        grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF00")
                    ElseIf grdProductosRegistrados.Rows(value).Cells("OtroStatus").Text = "AD" Then
                        grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#31B404")
                    ElseIf grdProductosRegistrados.Rows(value).Cells("OtroStatus").Text = "AP" Then
                        grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E9AFE")
                    ElseIf grdProductosRegistrados.Rows(value).Cells("OtroStatus").Text = "I" Then
                        grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#424242")
                    ElseIf grdProductosRegistrados.Rows(value).Cells("OtroStatus").Text = "DP" Then
                        grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#DF0101")
                    End If
                Next

            End If




            'For value = 0 To grdProductosRegistrados.Rows.Count - 1
            '    If grdProductosRegistrados.Rows(value).Cells("OtroStatus").Text = "I" Then
            '        grdProductosRegistrados.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8000")
            '    End If
            'Next

            'For value = 0 To grdProductosRegistrados.Rows.Count - 1
            'grdProductosRegistrados.Rows(value).Cells("Piel Color").Value = grdProductosRegistrados.Rows(value).Cells("Piel").Value & " " & grdProductosRegistrados.Rows(value).Cells("Color").Value
            'Next
            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With


        grdProductosRegistrados.DisplayLayout.Bands(0).Summaries.Clear()

        Dim summary1 As SummarySettings
        summary1 = grdProductosRegistrados.DisplayLayout.Bands(0).Summaries.Add("Total Archivos", SummaryType.Sum, grdProductosRegistrados.DisplayLayout.Bands(0).Columns("Archivos Cargados"))
        grdProductosRegistrados.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right

        grdProductosRegistrados.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdProductosRegistrados.DisplayLayout.Bands(0).Columns("Total Materiales").Width = 100
        grdProductosRegistrados.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdProductosRegistrados.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        ' grdProductosRegistrados.DisplayLayout.Bands(0).Columns("Asignado a Producción").Width = 100
        Try
            If cbxVerimagen.Checked Then
                With grdProductosRegistrados.DisplayLayout.Rows(0)
                    .Height = 70
                End With
            Else
                With grdProductosRegistrados.DisplayLayout.Rows(0)
                    .Height = 20
                End With
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor
        If cmbNave.Text <> "" Then
            cargartabla()
        Else
            lblNave.ForeColor = Drawing.Color.Red
            objAdvertencia.mensaje = "Seleccione una nave"
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub cargartabla()
        Dim tipoNave As DataTable

        Try
            If cmbNave.Text = "" Then
                nave = 0
            Else
                nave = cmbNave.SelectedValue
            End If
            If cmbEstatus.Text = "" Then
                combo = 0
            Else
                combo = cmbEstatus.SelectedValue
            End If
            If cmbMarca.Text = "" Then
                marca = 0
            Else
                marca = cmbMarca.SelectedValue
            End If
            If cmbColeccion.Text = "" Then
                coleccion = 0
            Else
                coleccion = cmbColeccion.SelectedValue
            End If

        Catch ex As Exception
        End Try
        Select Case combo
            Case 0
                estatus = ""
            Case 1
                estatus = "D"
            Case 2
                estatus = "AD"
            Case 3
                estatus = "AP"
            Case 4
                estatus = "I"
            Case 5
                estatus = "DP"
        End Select

        Dim obj As New ConsumosBU
        Dim obj2 As New catalagosBU
        Dim dtTablaProductos As DataTable

        Try
            tipoNave = obj2.TipoNave(cmbNave.SelectedValue)
            If tipoNave.Rows(0).Item(0) = True Then
                btnAlta.Enabled = True
                'llenarComboEstatus()
                'llenarComoboMarcas(cmbNave.SelectedValue)
                TipodeNave = 1
            Else
                btnAlta.Enabled = False
                'llenarComboEstatusNaveDesarrollo()
                'listaMarcasProduccion(cmbNave.SelectedValue)
                TipodeNave = 0
            End If
            Dim X = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "SOLOASIGNADOS")

        Catch ex As Exception
        End Try

        If cmbNave.Text <> "" Then
            If TipodeNave = 1 Then
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "NOENDESARROLLO") Then
                    ' Permiso para el perfil de planeacion solo materiales que no estan en estatus de desarrollo
                    dtTablaProductos = obj.ConsultarConsumosNoDesarrollo(nave, estatus, marca, coleccion, TipodeNave)
                ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "SOLOASIGNADOS") Then
                    ' Permiso para el perfil de gerente de nave de producción
                    dtTablaProductos = obj.ConsultarConsumosAsignados(nave, estatus, marca, coleccion, TipodeNave)
                Else
                    dtTablaProductos = obj.ConsultarConsumosNoDesarrollo(nave, estatus, marca, coleccion, TipodeNave)
                End If


                Dim PosicionScroll As Integer = grdProductosRegistrados.ActiveRowScrollRegion.ScrollPosition
                Dim OrigenScroll As Integer = grdProductosRegistrados.ActiveRowScrollRegion.Origin
                Dim FilaSeleccionada As Integer = ObtenerFilaSeleccionada()




                grdProductosRegistrados.DataSource = dtTablaProductos
                disenioGrid2()


                grdProductosRegistrados.ActiveRowScrollRegion.Scroll(RowScrollAction.Top)
                grdProductosRegistrados.ActiveRowScrollRegion.ScrollPosition = PosicionScroll
                grdProductosRegistrados.ActiveRowScrollRegion.Origin = OrigenScroll

                AsignarFilaSeleccionada(FilaSeleccionada)
            Else
                'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "SOLOASIGNADOS") Then
                '    dtTablaProductos = obj2.VerListaProductosImagenProduccion(nave, estatus, marca, coleccion, TipodeNave)
                'Else
                dtTablaProductos = obj.ConsultarConsumosProduccion(nave, marca, coleccion, estatus)
                'End If
                Dim PosicionScroll As Integer = grdProductosRegistrados.ActiveRowScrollRegion.ScrollPosition
                Dim OrigenScroll As Integer = grdProductosRegistrados.ActiveRowScrollRegion.Origin
                Dim FilaSeleccionada As Integer = ObtenerFilaSeleccionada()


                grdProductosRegistrados.DataSource = dtTablaProductos
                disenioGrid3()

                grdProductosRegistrados.ActiveRowScrollRegion.Scroll(RowScrollAction.Top)
                grdProductosRegistrados.ActiveRowScrollRegion.ScrollPosition = PosicionScroll
                grdProductosRegistrados.ActiveRowScrollRegion.Origin = OrigenScroll

                AsignarFilaSeleccionada(FilaSeleccionada)
            End If
        End If
    End Sub


    Public Function ObtenerFilaSeleccionada() As Integer
        Dim FilaSeleccionada As Integer = -1

        For Each Fila As UltraGridRow In grdProductosRegistrados.Rows

            If Fila.Selected = True Then
                FilaSeleccionada = Fila.Index
            End If
        Next

        Return FilaSeleccionada
    End Function

    Public Sub AsignarFilaSeleccionada(ByVal Index As Integer)

        For Each Fila As UltraGridRow In grdProductosRegistrados.Rows
            If Fila.Index = Index Then
                Fila.Selected = True
                Fila.Activated = True
            Else
                Fila.Activated = False
            End If
        Next


    End Sub


    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        If cmbNave.Text <> "" Then
            Dim form As New ListadoModelosForm
            form.idNave = cmbNave.SelectedValue
            form.nave = cmbNave.Text
            form.idNaveConsulta = cmbNave.SelectedValue
            form.IdNaveAlta = cmbNave.SelectedValue
            form.EsAltaProducto = True
            form.ShowDialog()
            lblNave.ForeColor = Drawing.Color.Black
            cargartabla()
        Else
            objAdvertencia.mensaje = "Seleccione una nave"
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
            lblNave.ForeColor = Drawing.Color.Red
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCambiosGlobales.Click
        Dim form As New CambiosGlobalesForm

        If cmbNave.SelectedValue <> 0 Then
            Try
                form.idnave = cmbNave.SelectedValue
                If grdProductosRegistrados.Rows.Count > 0 And grdProductosRegistrados.ActiveRow IsNot Nothing Then
                    form.idEstilo = grdProductosRegistrados.ActiveRow.Cells("EstiloID").Value
                    form.idmodelo = grdProductosRegistrados.ActiveRow.Cells("Modelo").Value
                    form.codigo = grdProductosRegistrados.ActiveRow.Cells("Código").Value
                    If cmbNave.SelectedValue = 99 Then
                        'form.idNaveConsulta = grdProductosRegistrados.ActiveRow.Cells("pres_navedesarrollaid").Text
                        form.idnave = grdProductosRegistrados.ActiveRow.Cells("pres_navedesarrollaid").Text
                    Else
                        'form.idNaveConsulta = cmbNave.SelectedValue
                        form.idnave = cmbNave.SelectedValue
                    End If

                End If
            Catch
            End Try
            form.Show()
            'cargartabla()

        Else
            objAdvertencia.mensaje = "Seleccione una nave"
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim form As New CatalogoComponentesForm
        form.ShowDialog()
    End Sub

    ''' <summary>
    ''' Crear tabla lista materiales en desarrollo
    ''' </summary>
    ''' <remarks></remarks> 
    ''' 
    Public Sub crearTablaListaMaterialesDesarrollo()
        listaMaterialesDesarrollo.Columns.Add(" ")
        listaMaterialesDesarrollo.Columns.Add("Id Producto Estilo")
        listaMaterialesDesarrollo.Columns.Add("ID")
        listaMaterialesDesarrollo.Columns.Add("Material")
        listaMaterialesDesarrollo.Columns.Add("SKU")
        listaMaterialesDesarrollo.Columns.Add("Proveedor")
        listaMaterialesDesarrollo.Columns.Add("Nave Desarrolla")
    End Sub

    ''' <summary>
    ''' Autorizar desarrollo
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAutorizarDesarrollo_Click(sender As Object, e As EventArgs) Handles btnAutorizarDesarrollo.Click
        Dim mensaje As Integer = 0
        Dim contador As Integer = 0
        Dim contadorseleccion As Integer = 0
        Dim autorizarmateriales As Boolean = False
        Dim SinConsumosFracciones As Integer = 0
        Dim ConSuela As DataTable


        If grdProductosRegistrados.Rows.Count > 0 Then
            'idestilo = grdProductosRegistrados.ActiveRow.Cells("EstiloID").Value
            'codigo = grdProductosRegistrados.ActiveRow.Cells("Código").Value

            For value = 0 To grdProductosRegistrados.Rows.Count - 1

                If grdProductosRegistrados.Rows(value).Cells(" ").Value = 1 Then
                    contadorseleccion = contadorseleccion + 1
                    If grdProductosRegistrados.Rows(value).Cells("Total Materiales").Text <> "" And
                            grdProductosRegistrados.Rows(value).Cells("status").Text = "DESARROLLO" Then
                        contador = contador + 1
                    End If

                    If grdProductosRegistrados.Rows(value).Cells("Total Materiales").Text = "" Or grdProductosRegistrados.Rows(value).Cells("Total Fracciones").Text = "" Then
                        SinConsumosFracciones = SinConsumosFracciones + 1

                    Else
                        If CDbl(grdProductosRegistrados.Rows(value).Cells("Total Materiales").Text) = 0.0 Or CDbl(grdProductosRegistrados.Rows(value).Cells("Total Fracciones").Text) = 0.0 Then
                            SinConsumosFracciones = SinConsumosFracciones + 1

                        End If

                    End If


                End If
            Next

            If contador > 0 And SinConsumosFracciones = 0 Then
                Try
                    objConfirmacion.mensaje = "¿Está seguro de Autorizar a Desarrollo los artículos seleccionados?"
                    If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                        For value = 0 To grdProductosRegistrados.Rows.Count - 1
                            If grdProductosRegistrados.Rows(value).Cells(" ").Value = 1 And
                                (grdProductosRegistrados.Rows(value).Cells("Total Materiales").Text <> "" And grdProductosRegistrados.Rows(value).Cells("Total Materiales").Text <> "0.00") And
                                grdProductosRegistrados.Rows(value).Cells("status").Text = "DESARROLLO" Then


                                listaMateriales(grdProductosRegistrados.Rows(value).Cells("EstiloID").Text)
                                Dim tablaMateriales = obj.ListaMaterialesConsumosProductoEstilo(grdProductosRegistrados.Rows(value).Cells("EstiloID").Text)
                                ConSuela = obj.ConSuelaProductoEstilo(grdProductosRegistrados.Rows(value).Cells("EstiloID").Text)

                                If ConSuela.Rows(0).Item(0) = 1 Then

                                    If listaMaterialesDesarrollo.Rows.Count = 0 Then
                                        obj.AutorizarDesarrollo(grdProductosRegistrados.Rows(value).Cells("EstiloID").Value, cmbNave.SelectedValue, SesionUsuario.UsuarioSesion.PUserUsuarioid)
                                        entidad.hipe_productoestid = grdProductosRegistrados.Rows(value).Cells("EstiloID").Value
                                        entidad.hipe_estatusde = "D"
                                        entidad.hipe_estatusa = "AD"
                                        entidad.hipe_usuarioid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                                        entidad.hipe_idnavehipe = cmbNave.SelectedValue
                                        entidad.hipe_naveasignadaid = cmbNave.SelectedValue
                                        obj.ActualizarHistorialProductoEstilo(entidad)
                                        mensaje = mensaje + 1

                                    End If
                                End If
                            End If
                        Next
                        cargartabla()
                        If listaMaterialesDesarrollo.Rows.Count > 0 Then
                            objAdvertencia.mensaje = "Existen materiales en DESARROLLO en uno o varios artículos, Favor de pasarlos a PRODUCCIÓN."
                            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                            objAdvertencia.ShowDialog()
                            'Dim form As New ListaMaterialesEstatusDesarrolloForm
                            'form.listaMaterialesEstatusDesarrollo = listaMaterialesDesarrollo
                            'form.nave = cmbNave.Text
                            'If form.ShowDialog = Windows.Forms.DialogResult.OK Then
                            '    objAdvertencia.mensaje = "Intenta autorizar de nuevo los articulos a los que autorizaste su material a producción"
                            '    objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                            '    objAdvertencia.ShowDialog()
                            '    autorizarmateriales = True

                            '    'Else
                            '    '    objAdvertencia.mensaje = "Autorización cancelada"
                            '    '    objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                            '    '    objAdvertencia.ShowDialog()
                            'End If
                            'listaMaterialesDesarrollo.Clear()
                            'cargartabla()
                        End If
                    End If
                    If autorizarmateriales = False Then
                        If mensaje = 0 Then
                            objAdvertencia.mensaje = "Autorización cancelada."
                            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                            objAdvertencia.ShowDialog()
                        Else
                            objExito.mensaje = mensaje & " Artículos" & vbCrLf & "autorizados a desarrollo de " & contadorseleccion & " artículos seleccionados"
                            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                            objExito.ShowDialog()
                        End If
                        If ConSuela.Rows(0).Item(0) = 0 Then
                            objAdvertencia.mensaje = "No se puede autorizar para Desarrollo un artículo que no tenga suela en los consumos."
                            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                            objAdvertencia.ShowDialog()
                        End If
                    End If

                Catch ex As Exception
                    objExito.mensaje = mensaje & " Artículos" & vbCrLf & "autorizados a desarrollo de " & contadorseleccion & " artículos seleccionados"
                    objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                    objExito.ShowDialog()
                End Try
            ElseIf contador = 0 And SinConsumosFracciones = 0 Then
                objAdvertencia.mensaje = "Seleccione un artículo en estatus de desarrollo para poderlo autorizar"
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
            Else

                objAdvertencia.mensaje = "Hay artículos sin consumos o fracciones"
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Estatus Anterior
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnEstatusAnterior_Click(sender As Object, e As EventArgs) Handles btnEstatusAnterior.Click

        Dim obj As New catalagosBU
        entidad = New Consumos
        Dim CountArticuloSeleccionado As Integer = 0


        If TipodeNave = 1 Then

            For Each Fila As UltraGridRow In grdProductosRegistrados.Rows
                If CBool(Fila.Cells(" ").Value) = True Then
                    CountArticuloSeleccionado = CountArticuloSeleccionado + 1
                End If
            Next

            If CountArticuloSeleccionado = 0 Then
                objAdvertencia.mensaje = "No se ha seleccionado un artículo."
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
                Return
            End If

            objConfirmacion.mensaje = "¿Está seguro de cambiar a desarrollo los artículos seleccionados?"
            If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim datosSelecionador As New DataTable
                datosSelecionador = grdProductosRegistrados.DataSource
                Dim contador As Integer = 0
                For Each row As DataRow In datosSelecionador.Rows
                    If row(" ") Then
                        Dim listaNaves = obj.listaNavesYaAsginadas(row("EstiloID"), "")
                        If listaNaves.Rows.Count = 0 Then
                            If row("status") = "AUTORIZADO DESARROLLO" Then

                                entidad = New Consumos
                                obj.EstatusAnterior(row("EstiloID"), "D", cmbNave.SelectedValue)
                                entidad.hipe_productoestid = row("EstiloID")
                                entidad.hipe_estatusde = "AD"
                                entidad.hipe_estatusa = "D"
                                entidad.hipe_usuarioid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                                entidad.hipe_idnavehipe = cmbNave.SelectedValue
                                entidad.hipe_naveasignadaid = cmbNave.SelectedValue
                                obj.ActualizarHistorialProductoEstilo(entidad)
                                contador += 1
                            End If
                        End If

                    End If
                Next
                If contador > 0 Then
                    objExito.mensaje = "Se actualizó el estatus de " & contador & " artículo(s) seleccionado(s)."
                    objExito.StartPosition = FormStartPosition.CenterScreen
                    objExito.ShowDialog()
                    cargartabla()
                Else
                    objAdvertencia.mensaje = "No se pueden cambiar a desarrollo los artículos seleccionados."
                    objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                    objAdvertencia.ShowDialog()
                End If
            End If
        Else
            objAdvertencia.mensaje = "Sólo la nave de desarrollo puede cambiar el estatus."
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
        End If



    End Sub

    ''' <summary>
    ''' Autorizar un producto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAutorizarProduccion_Click(sender As Object, e As EventArgs) Handles btnAutorizarProduccion.Click

        Dim obj As New catalagosBU
        Dim contador As Integer = 0
        Dim listaArticulos As New List(Of Integer)
        Dim aux As Integer = 0
        Dim contadorseleccion As Integer = 0
        Dim noAsignado As Integer = 0
        Dim TipoNave_aux As DataTable
        Dim estatusAP As Boolean = False
        Dim NaveDesarrollaProducto_aux As Integer = 0
        Dim vXmlAutorizarArticulos As XElement = New XElement("Articulos")
        Dim ConSuela As DataTable

        listaArticulos.Clear()

        If grdProductosRegistrados.Rows.Count > 0 Then

            For value = 0 To grdProductosRegistrados.Rows.Count - 1
                If grdProductosRegistrados.Rows(value).Cells(" ").Text = 1 Then
                    contadorseleccion = contadorseleccion + 1
                    listaArticulos.Add(grdProductosRegistrados.Rows(value).Cells("EstiloID").Text)
                    contador = contador + 1
                End If
            Next

            If contador > 0 Then
                'Consultar si ya está asignado a una nave, de lo contrario NO se puede Autorizar a Producción
                Dim valores = listaArticulos.LastOrDefault
                Dim listaNaves = obj.listaNavesYaAsginadas(valores, "")
                'Dim listaNaves = obj.listaNavesYaAsginadas(grdProductosRegistrados.ActiveRow.Cells("EstiloID").Value, "")
                Dim naveAsignada As Boolean = False


                For v = 0 To listaNaves.Rows.Count - 1
                    If listaNaves.Rows(v).Item(0) = cmbNave.SelectedValue Then
                        naveAsignada = True
                    End If
                Next

                If naveAsignada = True Then
                    objConfirmacion.mensaje = "¿Está seguro de Autorizar a Producción los artículos seleccionados?"

                    If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                        For value = 0 To grdProductosRegistrados.Rows.Count - 1
                            If grdProductosRegistrados.Rows(value).Cells(" ").Text = 1 And
                            grdProductosRegistrados.Rows(value).Cells("status").Text = "AUTORIZADO DESARROLLO" And
                             grdProductosRegistrados.Rows(value).Cells("Total Materiales").Text.ToString.Length > 0 Then
                                ConSuela = obj.ConSuelaProductoEstilo(grdProductosRegistrados.Rows(value).Cells("EstiloID").Text)
                                If ConSuela.Rows(0).Item(0) = 1 Then

                                    NaveDesarrollaProducto_aux = grdProductosRegistrados.Rows(value).Cells("pres_navedesarrollaid").Value

                                    Dim tabla As New DataTable
                                    'tabla = obj.ConsultarEstatusProductoEstilo(grdProductosRegistrados.ActiveRow.Cells("EstiloID").Value)
                                    tabla = obj.ConsultarEstatusProductoEstilo(grdProductosRegistrados.Rows(value).Cells("EstiloID").Value)
                                    For valor = 0 To tabla.Rows.Count - 1
                                        If tabla.Rows(valor).Item(0) = "AD" And tabla.Rows(valor).Item("nave_naveid") = cmbNave.SelectedValue Then
                                            '

                                            'obj.AutorizarProduccionNaveProduccion(grdProductosRegistrados.Rows(value).Cells("EstiloID").Text, cmbNave.SelectedValue)

                                            'If NaveDesarrollaProducto_aux = cmbNave.SelectedValue Then
                                            '    obj.AutorizarProduccion(grdProductosRegistrados.Rows(value).Cells("EstiloID").Text)
                                            'End If
                                            'entidad.hipe_productoestid = grdProductosRegistrados.Rows(value).Cells("EstiloID").Text
                                            'entidad.hipe_estatusde = "AD"
                                            'entidad.hipe_estatusa = "AP"
                                            'entidad.hipe_usuarioid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                                            'entidad.hipe_idnavehipe = cmbNave.SelectedValue
                                            'entidad.hipe_naveasignadaid = cmbNave.SelectedValue
                                            'obj.ActualizarHistorialProductoEstilo(entidad)

                                            Dim vNodo As XElement = New XElement("Articulo")
                                            vNodo.Add(New XAttribute("ProductoEstilo", grdProductosRegistrados.Rows(value).Cells("EstiloID").Text))
                                            vNodo.Add(New XAttribute("naveDesarrollaId", grdProductosRegistrados.Rows(value).Cells("pres_navedesarrollaid").Text))
                                            vNodo.Add(New XAttribute("NaveId", cmbNave.SelectedValue))
                                            vXmlAutorizarArticulos.Add(vNodo)

                                            aux = aux + 1
                                        Else
                                            noAsignado = noAsignado + 1
                                        End If
                                    Next
                                End If
                            End If
                        Next

                        Dim objAct As New catalagosBU
                        objAct.ActualizaProduccionNaveProduccion(vXmlAutorizarArticulos.ToString(), cmbNave.SelectedValue, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

                        If aux > 0 Then
                            objExito.mensaje = aux & " Artículo(s) autorizado(s) a producción de " & contadorseleccion.ToString & " artículo(s) seleccionado(s)"
                            objExito.StartPosition = FormStartPosition.CenterScreen
                            objExito.ShowDialog()
                            cargartabla()
                        ElseIf noAsignado = 0 Then
                            objAdvertencia.mensaje = "No se puede autorizar a producción"
                            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                            objAdvertencia.ShowDialog()
                        End If
                        If ConSuela.Rows(0).Item(0) = 0 Then
                            objAdvertencia.mensaje = "No se puede autorizar para Producción un artículo que no tenga suela en los consumos."
                            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                            objAdvertencia.ShowDialog()
                        End If
                    End If
                Else

                    TipoNave_aux = obj.TipoNave(cmbNave.SelectedValue)

                    If TipoNave_aux.Rows(0).Item(0) = True Then
                        objAdvertencia.mensaje = "No se puede Autorizar a Producción, debido a que la nave " + cmbNave.Text + " no se encuentra asignada para producción."
                        objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                        objAdvertencia.ShowDialog()
                    Else
                        objAdvertencia.mensaje = "No se puede Autorizar a Producción, Falta asignar la(s) Nave(s) de Producción."
                        objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                        objAdvertencia.ShowDialog()

                    End If


                End If
            Else
                objAdvertencia.mensaje = "No se ha seleccionado un artículo"
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()

            End If

        End If
    End Sub

    ''' <summary>
    ''' Descontinuar un producto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDescontinuar_Click(sender As Object, e As EventArgs) Handles btnDescontinuar.Click

        Dim obj As New catalagosBU
        Dim contador As Integer = 0
        Dim auxiliar As Integer = 0
        Dim selecciones As Integer = 0
        Dim auxiliar2 As Integer = 0
        Dim listaNavesAsignadas As DataTable
        Dim NAveDesarrollaEstilo_aux As Integer = 0
        Dim entidadConsumos As New Consumos
        Dim CountNavesSinInactivar As Integer = 0
        Dim ExisteEnNave As Boolean = False

        Dim Fila As UltraGridRow

        ''Permitir que solo un articulo a la vez se pueda descontinuar        

        If grdProductosRegistrados.Rows.Count > 0 Then


            If IsNothing(grdProductosRegistrados.ActiveRow) = True Then
                objAdvertencia.mensaje = "No se ha seleccionado un artículo."
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
                Return
            End If

            Fila = grdProductosRegistrados.ActiveRow
            idestilo = Fila.Cells("EstiloID").Value
            codigo = Fila.Cells("Modelo").Value
            NAveDesarrollaEstilo_aux = Fila.Cells("pres_navedesarrollaid").Value
            CountNavesSinInactivar = 0
            ExisteEnNave = False

            If NAveDesarrollaEstilo_aux = cmbNave.SelectedValue Then
                If Fila.Cells("status").Value <> "DESCONTINUADO" Then

                    listaNavesAsignadas = obj.listaNavesYaAsginadas(Fila.Cells("EstiloID").Value, "")

                    If listaNavesAsignadas.Rows.Count > 0 Then
                        For Each FilaNAveAsignada As DataRow In listaNavesAsignadas.Rows
                            If CInt(FilaNAveAsignada.Item("pena_naveid").ToString) = NAveDesarrollaEstilo_aux Then
                                ExisteEnNave = True
                            End If
                        Next
                    End If

                    If ExisteEnNave = True Then
                        CountNavesSinInactivar = listaNavesAsignadas.Rows.Count - 1
                    Else
                        CountNavesSinInactivar = listaNavesAsignadas.Rows.Count
                    End If

                    If CountNavesSinInactivar > 0 Then
                        objAdvertencia.mensaje = "No se puede descontinuar el artículo hasta que todas las naves asignadas hayan inactivado el artículo."
                        objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                        objAdvertencia.ShowDialog()
                    ElseIf CountNavesSinInactivar = 0 And ExisteEnNave = True Then
                        entidadConsumos = New Consumos
                        Dim estatusAnterior = Fila.Cells("status").Value
                        Dim EstatusAnt As String = String.Empty
                        Select Case estatusAnterior
                            Case "DESARROLLO"
                                EstatusAnt = "D"
                            Case "AUTORIZADO DESARROLLO"
                                EstatusAnt = "AD"
                            Case "AUTORIZADO PRODUCCIÓN"
                                EstatusAnt = "AP"
                            Case "INACTIVO NAVE"
                                EstatusAnt = "I"
                            Case "DESCONTINUADO"
                                EstatusAnt = "DP"
                            Case Else
                        End Select

                        entidadConsumos.hipe_productoestid = Fila.Cells("EstiloID").Value
                        entidadConsumos.hipe_estatusde = EstatusAnt
                        entidadConsumos.hipe_estatusa = "DP"
                        entidadConsumos.hipe_usuarioid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        entidadConsumos.hipe_idnavehipe = cmbNave.SelectedValue
                        entidadConsumos.hipe_naveasignadaid = cmbNave.SelectedValue
                        obj.ActualizarHistorialProductoEstilo(entidadConsumos)

                        obj.Descontinuar(Fila.Cells("EstiloID").Value, cmbNave.SelectedValue)
                        obj.Inactivar(Fila.Cells("EstiloID").Value, cmbNave.SelectedValue)
                        'obj.DescontinuarEnNAves(Fila.Cells("EstiloID").Value)

                        objExito.mensaje = "Articulo descontinuado."
                        objExito.StartPosition = FormStartPosition.CenterScreen
                        objExito.ShowDialog()
                        cargartabla()

                    Else
                        entidadConsumos = New Consumos
                        Dim estatusAnterior = Fila.Cells("status").Value
                        Dim EstatusAnt As String = String.Empty
                        Select Case estatusAnterior
                            Case "DESARROLLO"
                                EstatusAnt = "D"
                            Case "AUTORIZADO DESARROLLO"
                                EstatusAnt = "AD"
                            Case "AUTORIZADO PRODUCCIÓN"
                                EstatusAnt = "AP"
                            Case "INACTIVO NAVE"
                                EstatusAnt = "I"
                            Case "DESCONTINUADO"
                                EstatusAnt = "DP"
                            Case Else
                        End Select

                        entidadConsumos.hipe_productoestid = Fila.Cells("EstiloID").Value
                        entidadConsumos.hipe_estatusde = EstatusAnt
                        entidadConsumos.hipe_estatusa = "DP"
                        entidadConsumos.hipe_usuarioid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        entidadConsumos.hipe_idnavehipe = cmbNave.SelectedValue
                        entidadConsumos.hipe_naveasignadaid = cmbNave.SelectedValue
                        obj.ActualizarHistorialProductoEstilo(entidadConsumos)

                        obj.Descontinuar(Fila.Cells("EstiloID").Value, cmbNave.SelectedValue)
                        'obj.DescontinuarEnNAves(Fila.Cells("EstiloID").Value)

                        objExito.mensaje = "Articulo descontinuado."
                        objExito.StartPosition = FormStartPosition.CenterScreen
                        objExito.ShowDialog()
                        cargartabla()
                    End If


                Else

                    objAdvertencia.mensaje = "El artículo ya se encuentra descontinuado."
                    objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                    objAdvertencia.ShowDialog()
                End If

            Else

                'Naves Asignadas
                objAdvertencia.mensaje = "Solo la nave que desarrolla puede descontinuar el artículo."
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
            End If


        End If


        '===========================================================================================



        'For Each Fila As UltraGridRow In grdProductosRegistrados.Rows
        '    If Fila.Cells(" ").Value = 1 Then

        '        idestilo = Fila.Cells("EstiloID").Value
        '        codigo = Fila.Cells("Modelo").Value
        '        NAveDesarrollaEstilo_aux = Fila.Cells("pres_navedesarrollaid").Value
        '        CountNavesSinInactivar = 0
        '        ExisteEnNave = False

        '        If NAveDesarrollaEstilo_aux = cmbNave.SelectedValue Then
        '            If Fila.Cells("status").Value <> "DESCONTINUADO" Then

        '                listaNavesAsignadas = obj.listaNavesYaAsginadas(Fila.Cells("EstiloID").Value)

        '                If listaNavesAsignadas.Rows.Count > 0 Then
        '                    For Each FilaNAveAsignada As DataRow In listaNavesAsignadas.Rows
        '                        If CInt(FilaNAveAsignada.Item("pena_naveid").ToString) = NAveDesarrollaEstilo_aux Then
        '                            CountNavesSinInactivar = listaNavesAsignadas.Rows.Count - 1
        '                            ExisteEnNave = True
        '                        End If
        '                    Next
        '                End If

        '                If CountNavesSinInactivar > 0 Then
        '                    objAdvertencia.mensaje = "No se puede descontinuar un artículo hasta que todas las naves asignadas hayan inactivado el artículo."
        '                    objAdvertencia.StartPosition = FormStartPosition.CenterScreen
        '                    objAdvertencia.ShowDialog()
        '                ElseIf CountNavesSinInactivar = 0 And ExisteEnNave = True Then
        '                    entidadConsumos = New Consumos
        '                    Dim estatusAnterior = Fila.Cells("status").Value
        '                    Dim EstatusAnt As String = String.Empty
        '                    Select Case estatusAnterior
        '                        Case "DESARROLLO"
        '                            EstatusAnt = "D"
        '                        Case "AUTORIZADO DESARROLLO"
        '                            EstatusAnt = "AD"
        '                        Case "AUTORIZADO PRODUCCIÓN"
        '                            EstatusAnt = "AP"
        '                        Case "INACTIVO NAVE"
        '                            EstatusAnt = "I"
        '                        Case "DESCONTINUADO"
        '                            EstatusAnt = "DP"
        '                        Case Else
        '                    End Select

        '                    entidadConsumos.hipe_productoestid = Fila.Cells("EstiloID").Value
        '                    entidadConsumos.hipe_estatusde = EstatusAnt
        '                    entidadConsumos.hipe_estatusa = "DP"
        '                    entidadConsumos.hipe_usuarioid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        '                    entidadConsumos.hipe_idnavehipe = cmbNave.SelectedValue
        '                    entidadConsumos.hipe_naveasignadaid = cmbNave.SelectedValue
        '                    obj.ActualizarHistorialProductoEstilo(entidadConsumos)

        '                    obj.Descontinuar(Fila.Cells("EstiloID").Value)
        '                    obj.DescontinuarEnNAves(Fila.Cells("EstiloID").Value)

        '                Else
        '                    entidadConsumos = New Consumos
        '                    Dim estatusAnterior = Fila.Cells("status").Value
        '                    Dim EstatusAnt As String = String.Empty
        '                    Select Case estatusAnterior
        '                        Case "DESARROLLO"
        '                            EstatusAnt = "D"
        '                        Case "AUTORIZADO DESARROLLO"
        '                            EstatusAnt = "AD"
        '                        Case "AUTORIZADO PRODUCCIÓN"
        '                            EstatusAnt = "AP"
        '                        Case "INACTIVO NAVE"
        '                            EstatusAnt = "I"
        '                        Case "DESCONTINUADO"
        '                            EstatusAnt = "DP"
        '                        Case Else
        '                    End Select

        '                    entidadConsumos.hipe_productoestid = Fila.Cells("EstiloID").Value
        '                    entidadConsumos.hipe_estatusde = EstatusAnt
        '                    entidadConsumos.hipe_estatusa = "DP"
        '                    entidadConsumos.hipe_usuarioid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        '                    entidadConsumos.hipe_idnavehipe = cmbNave.SelectedValue
        '                    entidadConsumos.hipe_naveasignadaid = cmbNave.SelectedValue
        '                    obj.ActualizarHistorialProductoEstilo(entidadConsumos)

        '                    obj.Descontinuar(Fila.Cells("EstiloID").Value)
        '                    'obj.DescontinuarEnNAves(Fila.Cells("EstiloID").Value)
        '                End If


        '            Else

        '                objAdvertencia.mensaje = "El artículo ya se encuentra descontinuado."
        '                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
        '                objAdvertencia.ShowDialog()
        '            End If

        '        Else

        '            'Naves Asignadas
        '            objAdvertencia.mensaje = "Solo la nave que desarrolla puede descontinuar el artículo."
        '            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
        '            objAdvertencia.ShowDialog()
        '        End If

        '    End If
        'Next


        ' End If

        'If grdProductosRegistrados.Rows.Count > 0 Then
        '    idestilo = grdProductosRegistrados.ActiveRow.Cells("EstiloID").Value
        '    codigo = grdProductosRegistrados.ActiveRow.Cells("Modelo").Value

        '    For value = 0 To grdProductosRegistrados.Rows.Count - 1
        '        If grdProductosRegistrados.Rows(value).Cells(" ").Value = 1 Then
        '            If grdProductosRegistrados.Rows(value).Cells("status").Value <> "DESCONTINUADO" Then
        '                listaNavesAsignadas = obj.listaNavesYaAsginadas(grdProductosRegistrados.ActiveRow.Cells("EstiloID").Value)
        '                If listaNavesAsignadas.Rows.Count > 0 Then
        '                    contador = contador + 1
        '                End If
        '            End If
        '        End If
        '    Next

        '    If contador = 1 Then
        '        objConfirmacion.mensaje = "¿Está seguro de descontinuar el artículo seleccionado?"
        '        If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
        '            Try
        '                For value = 0 To grdProductosRegistrados.Rows.Count - 1
        '                    If grdProductosRegistrados.Rows(value).Cells(" ").Text = 1 Then
        '                        If grdProductosRegistrados.Rows(value).Cells("status").Value <> "DESCONTINUADO" Then
        '                            listaNavesAsignadas = obj.listaNavesYaAsginadas(grdProductosRegistrados.ActiveRow.Cells("EstiloID").Value)
        '                            If listaNavesAsignadas.Rows.Count <= 1 Then

        '                                '''obtener lista de naves asignadas y traer estatus
        '                                Dim form As New ConsultaEstadosArticuloPorNaveForm
        '                                Dim tabla As New DataTable
        '                                tabla = obj.ConsultarEstatusProductoEstiloConId(grdProductosRegistrados.ActiveRow.Cells("EstiloID").Value)

        '                                '''Guardar historial de la inactivacion del artículo en las naves asignadas
        '                                For x = 0 To tabla.Rows.Count - 1
        '                                    If tabla.Rows(x).Item(0) = "I" Then
        '                                    Else
        '                                        entidad.hipe_productoestid = grdProductosRegistrados.Rows(value).Cells("EstiloID").Value
        '                                        entidad.hipe_estatusde = tabla.Rows(x).Item(0)
        '                                        entidad.hipe_estatusa = "I"
        '                                        entidad.hipe_usuarioid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        '                                        entidad.hipe_idnavehipe = tabla.Rows(x).Item(1)
        '                                        entidad.hipe_naveasignadaid = tabla.Rows(x).Item(1)
        '                                        obj.ActualizarHistorialProductoEstilo(entidad)
        '                                    End If
        '                                Next

        '                                '''Guardar historial descontinuar material principal
        '                                Dim estatusAnterior = grdProductosRegistrados.Rows(value).Cells("status").Value
        '                                Dim EstatusAnt
        '                                Select Case estatusAnterior
        '                                    Case "DESARROLLO"
        '                                        EstatusAnt = "D"
        '                                    Case "AUTORIZADO DESARROLLO"
        '                                        EstatusAnt = "AD"
        '                                    Case "AUTORIZADO PRODUCCIÓN"
        '                                        EstatusAnt = "AP"
        '                                    Case "INACTIVO NAVE"
        '                                        EstatusAnt = "I"
        '                                    Case "DESCONTINUADO"
        '                                        EstatusAnt = "DP"
        '                                    Case Else
        '                                End Select

        '                                entidad.hipe_productoestid = grdProductosRegistrados.Rows(value).Cells("EstiloID").Value
        '                                entidad.hipe_estatusde = EstatusAnt
        '                                entidad.hipe_estatusa = "DP"
        '                                entidad.hipe_usuarioid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        '                                entidad.hipe_idnavehipe = cmbNave.SelectedValue
        '                                entidad.hipe_naveasignadaid = cmbNave.SelectedValue
        '                                obj.ActualizarHistorialProductoEstilo(entidad)

        '                                obj.Descontinuar(grdProductosRegistrados.Rows(value).Cells("EstiloID").Value)
        '                                obj.DescontinuarEnNAves(grdProductosRegistrados.Rows(value).Cells("EstiloID").Value)
        '                                auxiliar = auxiliar + 1
        '                            Else
        '                                auxiliar2 = 1
        '                            End If
        '                        End If
        '                    End If
        '                Next
        '                If auxiliar > 0 Then
        '                    objExito.mensaje = "Artículos descontinuados"
        '                    objExito.StartPosition = FormStartPosition.CenterScreen
        '                    objExito.ShowDialog()
        '                    cargartabla()
        '                ElseIf auxiliar2 = 1 Then
        '                    objAdvertencia.mensaje = "No se puede descontinuar un artículo con más de 1 nave asignada"
        '                    objAdvertencia.StartPosition = FormStartPosition.CenterScreen
        '                    objAdvertencia.ShowDialog()
        '                End If
        '            Catch ex As Exception
        '            End Try
        '        End If
        '    ElseIf contador = 0 Then
        '        objAdvertencia.mensaje = "Seleccione un artículo en estatus de Autorizado Producción para descontinuarlo"
        '        objAdvertencia.StartPosition = FormStartPosition.CenterScreen
        '        objAdvertencia.ShowDialog()
        '    Else
        '        objAdvertencia.mensaje = "Solo se permite descontinuar un artículo a la vez"
        '        objAdvertencia.StartPosition = FormStartPosition.CenterScreen
        '        objAdvertencia.ShowDialog()
        '    End If
        'End If

    End Sub

    ''' <summary>
    ''' Inactivar un producto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnInactivarEnNave_Click(sender As Object, e As EventArgs) Handles btnInactivarEnNave.Click

        Dim obj As New catalagosBU
        Dim obj2 As New ConsumosBU
        Dim contador As Integer = 0
        Dim listaNaves As DataTable
        Dim naveAsignada As Boolean = False
        Dim EsValido As Boolean = True

        entidad = New Consumos

        For Each Fila As UltraGridRow In grdProductosRegistrados.Rows
            If CBool(Fila.Cells(" ").Value) = True Then
                contador = contador + 1
            End If
        Next

        If contador = 0 Then
            objAdvertencia.mensaje = "No se ha seleccionado un articulo."
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
            EsValido = False
        ElseIf contador = 1 Then

            listaNaves = obj.listaNavesYaAsginadas(grdProductosRegistrados.ActiveRow.Cells("EstiloID").Value, "")

            For v = 0 To listaNaves.Rows.Count - 1
                If listaNaves.Rows(v).Item(0) = cmbNave.SelectedValue Then
                    naveAsignada = True
                End If
            Next

            If grdProductosRegistrados.ActiveRow.Cells("status").Value <> "AUTORIZADO PRODUCCIÓN" Then
                If grdProductosRegistrados.ActiveRow.Cells("status").Value = "INACTIVO NAVE" Then
                    objAdvertencia.mensaje = "El artículo ya se encuentra inactivo."
                    objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                    objAdvertencia.ShowDialog()
                    EsValido = False
                ElseIf grdProductosRegistrados.ActiveRow.Cells("status").Value = "DESCONTINUADO" Then
                    objAdvertencia.mensaje = "El artículo ya se encuentra descontinuado."
                    objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                    objAdvertencia.ShowDialog()
                    EsValido = False

                Else
                    objAdvertencia.mensaje = "No se puede inactivar debido a que el artículo no se encuentra en autorizado a producción."
                    objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                    objAdvertencia.ShowDialog()
                    EsValido = False
                End If


            Else
                If naveAsignada = False Then
                    objAdvertencia.mensaje = "No se puede inactivar debido a que la nave " + cmbNave.Text + " no se encuentra asignada para producción."
                    objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                    objAdvertencia.ShowDialog()
                    EsValido = False
                End If
            End If

            'If naveAsignada = False Then
            '    objAdvertencia.mensaje = "No se puede inactivar debido a que la nave " + cmbNave.Text + " no se encuentra asignada para producción."
            '    objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            '    objAdvertencia.ShowDialog()
            '    EsValido = False

            'Else
            '    If grdProductosRegistrados.ActiveRow.Cells("status").Value <> "AUTORIZADO PRODUCCIÓN" Then
            '        objAdvertencia.mensaje = "No se puede inactivar debido a que el artículo no se encuentra en autorizado a producción."
            '        objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            '        objAdvertencia.ShowDialog()
            '        EsValido = False
            '    End If

            'End If

        End If


        If EsValido = True Then
            objConfirmacion.mensaje = "¿Está seguro de inactivar los artículos seleccionados?"
            If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                ValidarNaveInactiva()

                'Dim datosSelecionador As New DataTable
                'datosSelecionador = grdProductosRegistrados.DataSource
                'Dim contador As Integer = 0
                'For Each row As DataRow In datosSelecionador.Rows
                '    If CBool(row(" ")) Then
                '        Dim listaNaves = obj2.articuloAsignadoANaveEstatusAP(row("EstiloID"), cmbNave.SelectedValue)
                '        If listaNaves.Rows.Count > 0 Then
                '            If row("status") = "AUTORIZADO PRODUCCIÓN" Then
                '                entidad = New Consumos
                '                obj.Inactivar(row("EstiloID"), cmbNave.SelectedValue)
                '                entidad.hipe_productoestid = row("EstiloID")
                '                entidad.hipe_estatusde = "AP"
                '                entidad.hipe_estatusa = "I"
                '                entidad.hipe_usuarioid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                '                entidad.hipe_idnavehipe = cmbNave.SelectedValue
                '                entidad.hipe_naveasignadaid = cmbNave.SelectedValue
                '                obj.ActualizarHistorialProductoEstilo(entidad)
                '                contador += 1
                '            End If
                '        End If

                '    End If
                'Next
                'If contador > 0 Then
                '    objExito.mensaje = "Se inactivaron " & contador & " artículo(s) seleccionado(s)."
                '    objExito.StartPosition = FormStartPosition.CenterScreen
                '    objExito.ShowDialog()
                '    cargartabla()
                'Else
                '    objAdvertencia.mensaje = "No se pueden inactivar los artículos seleccionados."
                '    objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                '    objAdvertencia.ShowDialog()
                'End If
            End If
        End If



    End Sub


    Public Sub ValidarNaveInactiva()
        Dim count As Integer = 0
        Dim NAveInactivar As Integer = 0
        Dim naveAsignada As Boolean = False
        Dim listaNaves As DataTable
        Dim NaveNoAsignada As Integer = 0
        Dim NAveDesarrollaEstilo_aux As Integer = 0
        Dim contador As Integer = 0


        For Each Fila As UltraGridRow In grdProductosRegistrados.Rows
            NAveDesarrollaEstilo_aux = Fila.Cells("pres_navedesarrollaid").Value

            If CBool(Fila.Cells(" ").Value) = True Then
                listaNaves = obj.listaNavesYaAsginadas(Fila.Cells("EstiloID").Value, "")

                For v = 0 To listaNaves.Rows.Count - 1
                    If listaNaves.Rows(v).Item(0) = cmbNave.SelectedValue Then
                        naveAsignada = True
                    End If
                Next

                If Fila.Cells("status").Value <> "INACTIVO" Then
                    If naveAsignada = True Then
                        If Fila.Cells("status").Value = "AUTORIZADO PRODUCCIÓN" Then
                            entidad = New Consumos
                            obj.InactivarEnNave(Fila.Cells("EstiloID").Value, cmbNave.SelectedValue, TipodeNave)

                            entidad.hipe_productoestid = Fila.Cells("EstiloID").Value
                            entidad.hipe_estatusde = "AP"
                            'If TipodeNave = 1 Then
                            '    entidad.hipe_estatusa = "AD"
                            'Else
                            entidad.hipe_estatusa = "I"
                            'End If
                            entidad.hipe_usuarioid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                            entidad.hipe_idnavehipe = cmbNave.SelectedValue
                            entidad.hipe_naveasignadaid = cmbNave.SelectedValue

                            obj.ActualizarHistorialProductoEstilo(entidad)
                            contador = contador + 1

                            If TipodeNave = 1 Then
                                obj.ActualizaEstatusProuctoEstilo(Fila.Cells("EstiloID").Value, cmbNave.SelectedValue)
                            End If

                            'If obj.TodasNavesInactivaEstilo(Fila.Cells("EstiloID").Value) = True Then
                            'obj.InactivarEnNavePrincipal(Fila.Cells("EstiloID").Value, cmbNave.SelectedValue)
                            'End If
                        End If
                    Else
                        NaveNoAsignada = NaveNoAsignada + 1
                    End If
                End If
                count = count + 1
            End If
        Next


        If contador > 0 Then
            objExito.mensaje = "Se inactivaron " & contador & " artículo(s) seleccionado(s)."
            objExito.StartPosition = FormStartPosition.CenterScreen
            objExito.ShowDialog()
            cargartabla()
        Else
            objAdvertencia.mensaje = "No se pueden inactivar los artículos seleccionados."
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
        End If


    End Sub


    ''' <summary>
    ''' Saber si los consumos del producto estilo todos estan en estatus de Producción
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub listaMateriales(ByVal porductoEstiloId As Integer)
        'listaMaterialesDesarrollo.Clear()
        Dim obj As New catalagosBU
        Dim tablaMateriales As New DataTable
        Dim campos(6) As Object
        Dim repetido As Boolean = False
        tablaMateriales = obj.ListaMaterialesConsumosProductoEstilo(porductoEstiloId)
        listaMaterialesDesarrollo.Rows.Clear()
        If listaMaterialesDesarrollo.Rows.Count > 0 Then
            For value = 0 To tablaMateriales.Rows.Count - 1
                For value2 = 0 To tablaMateriales.Rows.Count - 1
                    Dim x = tablaMateriales.Rows(value).Item(2)
                    Dim y = listaMaterialesDesarrollo.Rows(value2).Item(2)
                    If tablaMateriales.Rows(value).Item(2) = listaMaterialesDesarrollo.Rows(value2).Item(2) Then
                        repetido = True
                    Else
                        If repetido = False Then
                            For valuee = 0 To tablaMateriales.Rows.Count - 1
                                campos(0) = tablaMateriales.Rows(valuee).Item(0)
                                campos(1) = tablaMateriales.Rows(valuee).Item(1)
                                campos(2) = tablaMateriales.Rows(valuee).Item(2)
                                campos(3) = tablaMateriales.Rows(valuee).Item(3)
                                campos(4) = tablaMateriales.Rows(valuee).Item(4)
                                campos(5) = tablaMateriales.Rows(valuee).Item(5)
                                campos(6) = tablaMateriales.Rows(valuee).Item(6)
                                listaMaterialesDesarrollo.Rows.Add(campos)
                            Next
                        End If
                    End If
                Next
            Next
        Else
            If repetido = False Then
                For value = 0 To tablaMateriales.Rows.Count - 1
                    campos(0) = tablaMateriales.Rows(value).Item(0)
                    campos(1) = tablaMateriales.Rows(value).Item(1)
                    campos(2) = tablaMateriales.Rows(value).Item(2)
                    campos(3) = tablaMateriales.Rows(value).Item(3)
                    campos(4) = tablaMateriales.Rows(value).Item(4)
                    campos(5) = tablaMateriales.Rows(value).Item(5)
                    campos(6) = tablaMateriales.Rows(value).Item(6)
                    listaMaterialesDesarrollo.Rows.Add(campos)
                Next
            End If
        End If


    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Dim obj As New catalagosBU
        Dim obj2 As New ConsumosBU
        Dim entidad As New Consumos
        Dim contador = 0
        Dim actualizacion As Boolean = False
        Dim listaNavesYaSeleccionadas As New DataTable
        Dim listaNaves As New List(Of Integer)
        Dim repetido As Integer = 0
        Dim navedesarrollas As Boolean = False
        Dim tablaNaveDesarrolla As DataTable
        Dim NaveRepetida As Integer = 0
        Dim estilosId As String = ""
        Dim contadorCeldasActivas As Integer = 0
        Dim contadorCeldasEstatusCumplen As Integer = 0
        Dim listaModelos As New List(Of String)
        Dim tblModelos As New DataTable

        Dim tblmsf As New DataTable
        tblmsf.Columns.Add("Modelo")
        tblmsf.Columns.Add("PielColor")
        tblmsf.Columns.Add("Talla")

        If grdProductosRegistrados.Rows.Count > 0 Then
            If naveDesarrolla(cmbNave.SelectedValue) = True Then
                listaNavesYaSeleccionadas = Nothing
                listaEstilos.Clear()

                For value = 0 To grdProductosRegistrados.Rows.Count - 1
                    If grdProductosRegistrados.Rows(value).Cells("status").Text <> "DESARROLLO" Then
                        If grdProductosRegistrados.Rows(value).Cells(" ").Text = 1 Then
                            listaEstilos.Add(grdProductosRegistrados.Rows(value).Cells("EstiloID").Text)
                            estilosId = estilosId + "," + grdProductosRegistrados.Rows(value).Cells("EstiloID").Text
                        End If
                    End If
                    If (grdProductosRegistrados.Rows(value).Cells("status").Text = "AUTORIZADO DESARROLLO" Or grdProductosRegistrados.Rows(value).Cells("status").Text = "AUTORIZADO PRODUCCIÓN") And grdProductosRegistrados.Rows(value).Cells(" ").Text = 1 Then
                        contadorCeldasEstatusCumplen = contadorCeldasEstatusCumplen + 1
                        contadorCeldasActivas = contadorCeldasActivas + 1
                    End If
                Next
                If listaEstilos.Count > 0 Then
                    For i As Integer = 0 To listaEstilos.Count - 1
                        If obj2.ConsultaFraccionesDEsarrolloProductoEstilo(listaEstilos.Item(i), cmbNave.SelectedValue) = 0 Then
                            tblModelos = obj2.ConsultaModeloproductoEstiloId(listaEstilos.Item(i))
                            Dim renglon As DataRow = tblmsf.NewRow()
                            renglon("Modelo") = tblModelos.Rows(0).Item("ModeloSAY")
                            renglon("PielColor") = tblModelos.Rows(0).Item("PielColor")
                            renglon("Talla") = tblModelos.Rows(0).Item("Talla")
                            tblmsf.Rows.Add(renglon)
                        End If
                    Next
                    If tblmsf.Rows.Count > 0 Then
                        Dim form As New ListaModelosSinFraccionesActivasForm
                        objAdvertencia.mensaje = "Existen modelos con fracciones inactivas ."
                        objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                        objAdvertencia.ShowDialog()
                        form.tblModelos = tblmsf
                        form.ShowDialog()
                        Return
                    End If
                End If

                If listaEstilos.Count > 0 Then
                    If contadorCeldasActivas = contadorCeldasEstatusCumplen Then
                        Dim form As New ListaNavesForm
                        'listaNavesYaSeleccionadas = obj.listaNavesYaAsginadas(grdProductosRegistrados.ActiveRow.Cells("EstiloID").Value)
                        listaNavesYaSeleccionadas = obj.listaNavesYaAsginadas(estilosId.Substring(1), "Asignar")
                        For value = 0 To listaNavesYaSeleccionadas.Rows.Count - 1
                            listaNaves.Add(listaNavesYaSeleccionadas.Rows(value).Item(0))
                        Next
                        form.listaNavesYaAsginadas = listaNaves
                        'form.listaNavesYaAsginadas = listaNaves
                        If form.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            Me.Cursor = Cursors.WaitCursor

                            listaNaves = form.listaSelecciones
                            Try
                                For value1 = 0 To listaEstilos.Count - 1
                                    For value2 = 0 To listaNaves.Count - 1
                                        'For value3 = 0 To listaNavesYaSeleccionadas.Rows.Count - 1
                                        '    If listaNaves.Item(value2) = listaNavesYaSeleccionadas.Rows(value3).Item(0) Then
                                        '        repetido = 1
                                        '    Else
                                        '        repetido = 0
                                        '    End If
                                        'Next
                                        'For value = 0 To listaNaves.Count - 1
                                        ' ValidarNaveRepetida(listaNavesYaSeleccionadas, listaNaves)
                                        If ValidarNaveRepetida(listaNavesYaSeleccionadas, listaNaves.Item(value2)) = True Then

                                            tablaNaveDesarrolla = obj2.getNaveDesarrolla(listaEstilos.Item(value1))
                                            If cmbNave.Text = tablaNaveDesarrolla(0).Item(0) Then
                                                entidad.cons_productoestiloid = listaEstilos.Item(value1)
                                                entidad.cons_naveid = listaNaves.Item(value2)
                                                entidad.cons_asignoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                                                entidad.cons_naveasignaid = cmbNave.SelectedValue

                                                obj.InactivarMaterialConsumoProduccionNave(entidad.cons_productoestiloid, entidad.cons_naveid)

                                                obj.AsignarProductoNaveProduccion(entidad)


                                                entidad.hipe_productoestid = listaEstilos.Item(value1)
                                                entidad.hipe_estatusde = "AD"
                                                entidad.hipe_estatusa = "AN"
                                                entidad.hipe_usuarioid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                                                entidad.hipe_idnavehipe = cmbNave.SelectedValue
                                                entidad.hipe_asignado = 1
                                                entidad.hipe_naveasignadaid = listaNaves.Item(value2)
                                                obj.ActualizarHistorialProductoEstiloConNave(entidad)
                                                contador = contador + 1
                                                actualizacion = True

                                                InsertarInventarioNaveAsigna(entidad.cons_naveasignaid, entidad.cons_productoestiloid, entidad.cons_naveid)

                                            End If
                                        Else

                                            If listaEstilos.Count = 1 Then
                                                NaveRepetida = NaveRepetida + 1
                                            End If
                                        End If
                                        'Next

                                    Next
                                Next

                                Me.Cursor = Cursors.Default
                            Catch ex As Exception
                                repetido = 0
                                For value1 = 0 To listaEstilos.Count - 1
                                    For value = 0 To listaNaves.Count - 1
                                        entidad.cons_productoestiloid = listaEstilos.Item(value1)
                                        entidad.cons_naveid = listaNaves.Item(value)
                                        entidad.cons_asignoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                                        entidad.cons_naveasignaid = cmbNave.SelectedValue

                                        obj.InactivarMaterialConsumoProduccionNave(entidad.cons_productoestiloid, entidad.cons_naveid)
                                        obj.AsignarProductoNaveProduccion(entidad)

                                        entidad.hipe_productoestid = listaEstilos.Item(value1)
                                        entidad.hipe_estatusde = "AD"
                                        entidad.hipe_estatusa = "AP"
                                        entidad.hipe_usuarioid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                                        entidad.hipe_idnavehipe = cmbNave.SelectedValue
                                        entidad.hipe_asignado = 1
                                        entidad.hipe_naveasignadaid = listaNaves.Item(value)
                                        obj.ActualizarHistorialProductoEstiloConNave(entidad)
                                        contador = contador + 1
                                        actualizacion = True

                                        InsertarInventarioNaveAsigna(entidad.cons_naveasignaid, entidad.cons_productoestiloid, entidad.cons_naveid)
                                    Next
                                Next

                                Me.Cursor = Cursors.Default
                            End Try

                            'objExito.mensaje = "Se asigno el producto exitosamente a las naves"
                            'objExito.ShowDialog()
                        End If
                    Else
                        objAdvertencia.mensaje = "Sólo se pueden asignar artículos con estatus Autorizado Desarrollo."
                        objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                        objAdvertencia.ShowDialog()
                    End If
                Else
                    objAdvertencia.mensaje = "Seleccione artículos en estatus Autorizado Desarrollo."
                    objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                    objAdvertencia.ShowDialog()
                End If
                If actualizacion = True Then
                    If contador = 1 Then
                        objExito.mensaje = "Se asignaron " & listaEstilos.Count & " artículo(s) seleccionado(s) a " & (listaNaves.Count - NaveRepetida).ToString & " nave."
                        objExito.StartPosition = FormStartPosition.CenterScreen
                        objExito.ShowDialog()
                    ElseIf contador >= 2 Then
                        objExito.mensaje = "Se asignaron " & listaEstilos.Count & " artículo(s) seleccionado(s) a " & (listaNaves.Count - NaveRepetida).ToString & " naves."
                        'objExito.mensaje = "Se asignaron " & contador.ToString & " naves a " & listaEstilos.Count & " artículo(s) seleccionado(s)."
                        objExito.StartPosition = FormStartPosition.CenterScreen
                        objExito.ShowDialog()
                    Else : contador = 0
                        objAdvertencia.mensaje = "No se puede asignar este artículo."
                        objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                        objAdvertencia.ShowDialog()
                    End If
                End If

                cargartabla()
            Else
                objAdvertencia.mensaje = "No puede asignar este artículo. No es la nave que lo desarrolla"
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
            End If
        End If
    End Sub


    Public Sub InsertarInventarioNaveAsigna(ByVal NaveOrigenID As Integer, ByVal ProductoEstiloNaveAsginaID As Integer, ByVal NaveAsignaID As Integer)

        Dim obj As New ConsumosBU
        Dim objMaterial As New Proveedores.BU.MaterialesBU
        Dim DtMaterialesAutorizados As DataTable
        Dim DTMaterialPrecioProveedorNave As DataTable
        Dim objMaterialInventario As New MaterialInventario
        Dim MaterialNAveIDNuevo As Integer = 0

        DtMaterialesAutorizados = obj.getMaterialesAutorizadosProduccionArticulo(ProductoEstiloNaveAsginaID)


        For Each FilaMaterial As DataRow In DtMaterialesAutorizados.Rows

            MaterialNAveIDNuevo = obj.getMaterialNaveID(FilaMaterial("mn_materialid").ToString, NaveAsignaID)


            If objMaterial.ExisteInventarioMaterialProveedorPrecio(MaterialNAveIDNuevo, FilaMaterial("code_proveedorid").ToString, FilaMaterial("code_preciocompra").ToString) = False Then



                If obj.getExistePrecioMaterialNaveProveedor(MaterialNAveIDNuevo, FilaMaterial("code_proveedorid").ToString, FilaMaterial("code_preciocompra").ToString) = False Then
                    InsertarPrecioMaterialNaveID(NaveOrigenID, MaterialNAveIDNuevo, NaveAsignaID, FilaMaterial("mn_materialid").ToString, FilaMaterial("code_proveedorid").ToString, FilaMaterial("code_preciocompra").ToString, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                    'InsertarPrecioMaterialNaveID(ByVal MaterialNAveID As Integer, ByVal NaveId As Integer, ByVal MaterialID As Integer, ByVal ProveedorID As Integer, ByVal Precio As Double, ByVal UsuarioID As Integer)
                End If


                'Public Function getExistePrecioMaterialNaveProveedor(ByVal MAterialNAveID As Integer, ByVal ProveedorID As Integer, ByVal Precio As Double) As Boolean

                'DTMaterialPrecioProveedorNave = obj.getMaterialPrecioProveedorNave(FilaMaterial("mn_materialid").ToString, NaveAsignaID.ToString, FilaMaterial("code_proveedorid").ToString, FilaMaterial("code_preciocompra").ToString)

                'If DTMaterialPrecioProveedorNave.Rows.Count > 0 Then
                '    objMaterialInventario = New MaterialInventario
                '    objMaterialInventario.invn_cantidad = 0
                '    objMaterialInventario.invn_factorconversion = DTMaterialPrecioProveedorNave.Rows(0).Item("prma_equivalencia").ToString
                '    objMaterialInventario.invn_inventariototal = 0
                '    objMaterialInventario.invn_movimientoinventarioid = 1
                '    objMaterialInventario.invn_precio = FilaMaterial("code_preciocompra").ToString
                '    objMaterialInventario.invn_proveedorid = FilaMaterial("code_proveedorid").ToString
                '    objMaterialInventario.invn_umc = DTMaterialPrecioProveedorNave.Rows(0).Item("prma_idumproveedor").ToString
                '    objMaterialInventario.invn_ump = DTMaterialPrecioProveedorNave.Rows(0).Item("prma_idumproduccion").ToString
                '    objMaterialInventario.invn_monedaid = DTMaterialPrecioProveedorNave.Rows(0).Item("prma_monedaid").ToString
                '    objMaterialInventario.invn_naveid = NaveAsignaID
                '    objMaterialInventario.invn_materialnaveid = DTMaterialPrecioProveedorNave.Rows(0).Item("mn_materialNaveid").ToString
                '    objMaterial.insertarInventarioNave(objMaterialInventario)

                'End If


                DTMaterialPrecioProveedorNave = obj.getMaterialPrecio(MaterialNAveIDNuevo)

                For Each Fila As DataRow In DTMaterialPrecioProveedorNave.Rows

                    If objMaterial.ExisteInventarioMaterialProveedorPrecio(NaveAsignaID, Fila("prma_provedorid").ToString, Fila("prma_preciounitario").ToString) = False Then

                        objMaterialInventario = New MaterialInventario
                        objMaterialInventario.invn_cantidad = 0
                        objMaterialInventario.invn_factorconversion = Fila("prma_equivalencia").ToString
                        objMaterialInventario.invn_inventariototal = 0
                        objMaterialInventario.invn_movimientoinventarioid = 1
                        objMaterialInventario.invn_precio = Fila("prma_preciounitario").ToString
                        objMaterialInventario.invn_proveedorid = Fila("prma_provedorid").ToString 'FilaMaterial("code_proveedorid").ToString
                        objMaterialInventario.invn_umc = Fila("prma_idumproveedor").ToString ' DTMaterialPrecioProveedorNave.Rows(0).Item("prma_idumproveedor").ToString
                        objMaterialInventario.invn_ump = Fila("prma_idumproduccion").ToString ' DTMaterialPrecioProveedorNave.Rows(0).Item("prma_idumproduccion").ToString
                        objMaterialInventario.invn_monedaid = Fila("prma_monedaid").ToString 'DTMaterialPrecioProveedorNave.Rows(0).Item("prma_monedaid").ToString
                        objMaterialInventario.invn_naveid = NaveAsignaID
                        objMaterialInventario.invn_materialnaveid = MaterialNAveIDNuevo
                        objMaterial.insertarInventarioNave(objMaterialInventario)
                    End If


                Next

            End If

        Next


    End Sub


    Public Sub InsertarPrecioMaterialNaveID(ByVal NaveOrigenID As Integer, ByVal MaterialNAveID As Integer, ByVal NaveId As Integer, ByVal MaterialID As Integer, ByVal ProveedorID As Integer, ByVal Precio As Double, ByVal UsuarioID As Integer)
        Dim precioMaterial As New Entidades.PrecioMaterial
        Dim obj As New Proveedores.BU.MaterialesBU


        obj.InsertarMaterialPrecio(NaveOrigenID, MaterialNAveID, NaveId, MaterialID, ProveedorID, Precio, UsuarioID)


        'precioMaterial.idMaterialSICY = 0
        'precioMaterial.idMaterialNave = MaterialNAveID
        'precioMaterial.naveId = row("nave_naveid") 'idNave
        'precioMaterial.proveedordgId = row("dageproveedorid")
        'precioMaterial.precioUnitario = row("Precio")
        ''precioMaterial.tiempodeEntrega = row("Días Entrega")
        'precioMaterial.proveedorId = row("idProveedor")
        'precioMaterial.proveedor = row("Proveedor")    
        'precioMaterial.preciosmaterialid = row("PrecioMaterialId")
        'precioMaterial.equivalenciaUMP = row("Factor de conversión")
        'precioMaterial.umc = row("umc")
        'precioMaterial.ump = row("ump")
        'precioMaterial.idumc = row("idumprov")
        'precioMaterial.idump = row("idumprod")
        'precioMaterial.descripcion = txtDescripcion.Text.Trim
        'precioMaterial.descripcionProv = row("Descripción Material Proveedor")
        'precioMaterial.claveProveedor = row("Clave")
        'precioMaterial.tiempodeEntrega = row("Días Entrega")
        'precioMaterial.monedaId = row("IdMoneda")
        'precioMaterial.navedesarrollaid = idNave 'row("IdNaveAlta")
        'precioMaterial.naveDesarrolla = row("Nave Alta")
        'Dim tablausuario As DataTable
        'Dim objj As New MaterialesBU
        'Dim usuario As String = row("Usuario Alta")
        'tablausuario = objj.GetIdUsuario(usuario)
        'If tablausuario.Rows.Count > 0 Then
        '    precioMaterial.usuarioCreoid = tablausuario.Rows(0).Item(0)
        'Else
        '    precioMaterial.usuarioCreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        'End If


        'If precioMaterial.existe = 0 Then
        '    obj.removerPreciosConMismoProveedorXnave(precioMaterial.proveedorId, precioMaterial.idMaterialNave) 'Remueve todos los precios del mismo proveedor asignados a ese material de la nave
        '    obj.insertPrecioMaterial(precioMaterial)        'Inserta el nuevo precio del material en say
        '    'obj.addPrecioMaterialSICY(precioMaterial)       'Agrega el precio al sicy
        '    'obj.spUpdatePrecioMaterialSICY(precioMaterial)  'Actualiza el precio en el sicy si es necesario
        '    'obj.ActualizaPrecioFichaTecSICY(precioMaterial) 'Actualiza los consumos para ese proveedor y ese material asignado a la nave
        'ElseIf precioMaterial.existe = 2 Then
        '    obj.removerPreciosConMismoProveedorXnave(precioMaterial.proveedorId, precioMaterial.idMaterialNave) 'Remueve todos los precios del mismo proveedor asignados a ese material de la nave
        '    'obj.removePrecioMaterial(precioMaterial)       'remueve el precio anterior en say
        '    obj.insertPrecioMaterial(precioMaterial)        'Inserta nuevo precio actualizado
        '    'obj.spUpdatePrecioMaterialSICY(precioMaterial)  'Actualiza el precio en el sicy si es necesario
        '    'obj.ActualizaPrecioFichaTecSICY(precioMaterial) 'Actualiza los consumos para ese proveedor y ese material asignado a la nave
        'End If


    End Sub

    Public Function ValidarNaveRepetida(ByVal listaNavesYaSeleccionadas As DataTable, ByVal naveNueva As Integer) As Boolean

        For value3 = 0 To listaNavesYaSeleccionadas.Rows.Count - 1
            Dim x = naveNueva
            Dim y = listaNavesYaSeleccionadas.Rows(value3).Item(0)
            If naveNueva = listaNavesYaSeleccionadas.Rows(value3).Item(0) Then
                Return True
            End If
        Next

    End Function
    Public Function naveDesarrolla(ByVal nave As Integer) As Boolean
        Try
            Dim obj As New ConsumosBU
            Dim tabla As New DataTable
            tabla = obj.SaberTipoNave(nave)
            If tabla.Rows(0).Item(0) = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
        End Try
    End Function

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If grdProductosRegistrados.Rows.Count > 0 Then
            If IsNothing(grdProductosRegistrados.ActiveRow) = True Then
                objAdvertencia.mensaje = "Seleccione un artículo."
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
                Return
            End If

            If grdProductosRegistrados.ActiveRow.Selected Then
                Dim form As New AltaConsumosFracciones
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "MODIFICARCONSUMOS") Then
                    PermisoModificar = True
                Else
                    PermisoModificar = False
                End If

                form.productoEstiloId = grdProductosRegistrados.ActiveRow.Cells("EstiloID").Value
                If grdProductosRegistrados.ActiveRow.Cells("status").Value = "DESARROLLO" Or grdProductosRegistrados.ActiveRow.Cells("status").Value = "AUTORIZADO DESARROLLO" Then
                    Me.Cursor = Cursors.WaitCursor
                    form.accion = "Desarrollo"
                    form.permisoModificar = PermisoModificar
                    form.estatusArticulo = grdProductosRegistrados.ActiveRow.Cells("status").Text
                    Try
                        form.otroEstatus = grdProductosRegistrados.ActiveRow.Cells("OtroStatus").Text
                    Catch ex As Exception
                    End Try

                    If cmbNave.SelectedValue = 99 Then
                        form.idNaveConsulta = grdProductosRegistrados.ActiveRow.Cells("pres_navedesarrollaid").Text
                    Else
                        form.idNaveConsulta = cmbNave.SelectedValue
                    End If

                    '                   form.idNaveConsulta = cmbNave.SelectedValue
                    form.naveDesarrolla = cmbNave.Text
                    Try
                        form.naves = grdProductosRegistrados.ActiveRow.Cells("Asignación Producción").Text
                    Catch ex As Exception
                    End Try
                    form.modelo = grdProductosRegistrados.ActiveRow.Cells("Modelo").Text
                    form.NAveDesarrollaID = grdProductosRegistrados.ActiveRow.Cells("pres_navedesarrollaid").Text
                    form.ShowDialog()
                    ' cargartabla()
                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.WaitCursor
                    If cmbNave.SelectedValue = 99 Then
                        form.idNaveConsulta = grdProductosRegistrados.ActiveRow.Cells("pres_navedesarrollaid").Text
                    Else
                        form.idNaveConsulta = cmbNave.SelectedValue
                    End If
                    'form.idNaveConsulta = cmbNave.SelectedValue
                    form.estatusArticulo = grdProductosRegistrados.ActiveRow.Cells("status").Text
                    form.accion = "Produccion"
                    form.modelo = grdProductosRegistrados.ActiveRow.Cells("Modelo").Text
                    form.naveDesarrolla = cmbNave.Text
                    form.permisoModificar = PermisoModificar
                    form.NAveDesarrollaID = grdProductosRegistrados.ActiveRow.Cells("pres_navedesarrollaid").Text
                    form.ShowDialog()
                    'cargartabla()
                    Me.Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub btnFracciones_Click(sender As Object, e As EventArgs)
        Dim form As New CatalogoFraccionesForm
        form.ShowDialog()
    End Sub

    'Private Sub btnCatalogoMaquinaria_Click(sender As Object, e As EventArgs)
    '    Try
    '        If cmbNave.SelectedValue > 0 Then
    '            Dim form As New CatalogoMaquinariaForm
    '            form.nave = cmbNave.SelectedValue
    '            form.ShowDialog()
    '        Else
    '            objAdvertencia.mensaje = "Seleccione una nave"
    '            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
    '            objAdvertencia.ShowDialog()
    '        End If
    '    Catch
    '    End Try
    'End Sub

    Private Sub cbxTodo_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTodo.CheckedChanged
        Dim x = 0
        If cbxTodo.Text = "Seleccionar todo" And x = 0 Then
            For Each row In grdProductosRegistrados.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next
            cbxTodo.Text = "Deseleccionar todo"
            x = x + 1
        End If

        If cbxTodo.Text = "Deseleccionar todo" And x = 0 Then
            For Each row In grdProductosRegistrados.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
            cbxTodo.Text = "Seleccionar todo"
            x = x + 1
        End If

    End Sub

    Private Sub grdProductosRegistrados_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdProductosRegistrados.ClickCell
        Try
            If Not grdProductosRegistrados.ActiveCell.Column.ToString = " " Then
                grdProductosRegistrados.ActiveRow.Selected = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub validarPerfiles()
        pblAlta.Visible = False
        pnlEditar.Visible = False
        pnlAsignar.Visible = False
        pnlAutorizarD.Visible = False
        pnlautorizarP.Visible = False
        pnlDescontinuar.Visible = False
        pnlInactivar.Visible = False
        pnlEstatusAnterior.Visible = False
        pnlCambiosGlobales.Visible = False
        pnlEditar.Visible = True

        Try
            ' VALIDACION DE PERMISOS GENERALES CREADOR PARA CADA UNO DE LOS PERFILES
            If naveDesarrolla(cmbNave.SelectedValue) = True Then
                ' Todos los perfiles
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PNAVEP") And
                Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PADMONC") And
                Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PCOORD") And
                Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PPRODG") And
                Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PPRODP") And
                Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PADMONM") Then
                    pblAlta.Visible = True
                    pnlEditar.Visible = True
                    pnlAsignar.Visible = True
                    pnlAutorizarD.Visible = True
                    pnlautorizarP.Visible = True
                    pnlDescontinuar.Visible = True
                    pnlInactivar.Visible = True
                    pnlEstatusAnterior.Visible = True
                    pnlCambiosGlobales.Visible = True
                    'Perfil administrador de costos
                ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PADMONC") Then
                    pblAlta.Visible = True
                    pnlAsignar.Visible = False
                    pnlEditar.Visible = True
                    pnlAutorizarD.Visible = False
                    pnlautorizarP.Visible = False
                    pnlDescontinuar.Visible = False
                    pnlInactivar.Visible = False
                    pnlEstatusAnterior.Visible = False
                    pnlCambiosGlobales.Visible = True
                    'Perfil coordinador de desarrollo
                ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PCOORD") Then
                    pnlEditar.Visible = True
                    lblEditar.Text = "Consulta"
                    btnEditar.Image = Produccion.Vista.My.Resources.Resources.details
                    pnlAsignar.Visible = False
                    pnlAutorizarD.Visible = True
                    pnlautorizarP.Visible = False
                    pnlDescontinuar.Visible = False
                    pnlInactivar.Visible = False
                    pnlEstatusAnterior.Visible = True
                    pnlCambiosGlobales.Visible = False
                    ' '''Perfil ferente de produccion
                ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PPRODG") Then
                    pnlEditar.Visible = True
                    lblEditar.Text = "Consulta"
                    btnEditar.Image = Produccion.Vista.My.Resources.Resources.details
                    pnlAsignar.Visible = False
                    pnlAutorizarD.Visible = False
                    pnlautorizarP.Visible = True
                    pnlDescontinuar.Visible = False
                    pnlInactivar.Visible = False
                    pnlEstatusAnterior.Visible = False
                    pnlCambiosGlobales.Visible = False
                    ' '''Perfil planeador de produccion
                ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PPRODP") Then
                    pnlEditar.Visible = True
                    lblEditar.Text = "Consulta"
                    btnEditar.Image = Produccion.Vista.My.Resources.Resources.details
                    pnlAsignar.Visible = True
                    pnlAutorizarD.Visible = False
                    pnlautorizarP.Visible = False
                    pnlDescontinuar.Visible = True
                    pnlInactivar.Visible = True
                    pnlEstatusAnterior.Visible = True
                    lblEstatusAnterior.Text = "Reactivar a" & vbCrLf & "Desarrollo"
                    pnlCambiosGlobales.Visible = False
                    ' '''Perfil administrador de materiales
                ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PADMONM") Then
                    pblAlta.Visible = True
                    pnlAsignar.Visible = True
                    pnlEditar.Visible = True
                    pnlAutorizarD.Visible = True
                    If TipodeNave = 1 Then
                        pnlautorizarP.Visible = False
                    Else
                        ' '''validar si la nave es maquila
                        If naveMaquila = True Then
                            pnlautorizarP.Visible = True
                        Else
                            pnlautorizarP.Visible = False
                        End If
                    End If

                    pnlDescontinuar.Visible = False
                    pnlInactivar.Visible = False
                    pnlEstatusAnterior.Visible = True
                    pnlCambiosGlobales.Visible = True
                    ' '''Perfil nave de produccion
                ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PNAVEP") Then
                    pnlEditar.Visible = True
                    pnlAsignar.Visible = False
                    pnlAutorizarD.Visible = False
                    pnlautorizarP.Visible = True
                    pnlDescontinuar.Visible = False
                    pnlInactivar.Visible = False
                    pnlEstatusAnterior.Visible = False
                    pnlCambiosGlobales.Visible = False
                End If
            Else
                pblAlta.Visible = False
                pnlEditar.Visible = False
                pnlAsignar.Visible = False
                pnlAutorizarD.Visible = False
                pnlautorizarP.Visible = False
                pnlDescontinuar.Visible = False
                pnlInactivar.Visible = False
                pnlEditar.Visible = False
                pnlEstatusAnterior.Visible = False
                pnlCambiosGlobales.Visible = False
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PADMONM") Then
                    pnlEditar.Visible = True
                    If TipodeNave = 1 Then
                        pnlautorizarP.Visible = True
                    Else
                        ' '''validar si la nave es maquila
                        If naveMaquila = True Then
                            pnlautorizarP.Visible = True
                        Else
                            pnlautorizarP.Visible = False
                        End If
                    End If
                End If
            End If

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PNAVEP") = False And
                Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PADMONC") = False And
                Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PCOORD") = False And
                Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PPRODG") = False And
                Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PPRODP") = False And
                Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PADMONM") = False Then
                pnlAdministradorFichasTecnicas.Visible = False
            End If

            'Permiso nuevo para perfil Naves Desarrollo
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PCONSUMOESP") Then
                pblAlta.Visible = True
                pnlEditar.Visible = True
                pnlautorizarP.Visible = True
                pnlAutorizarD.Visible = True
                pnlCambiosGlobales.Visible = True
                pnlAsignar.Visible = False
                pnlInactivar.Visible = False
                pnlDescontinuar.Visible = False
                pnlEstatusAnterior.Visible = False

                lblEditar.Text = "Editar"
                btnEditar.Image = Produccion.Vista.My.Resources.Resources.editar_32
            End If

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PNAVEP") Then
                pnlEditar.Visible = True
            End If

        Catch ex As Exception
            pblAlta.Visible = False
            pnlEditar.Visible = True
            pnlAsignar.Visible = False
            pnlAutorizarD.Visible = False
            pnlautorizarP.Visible = False
            pnlDescontinuar.Visible = False
            pnlInactivar.Visible = False
            pnlEditar.Visible = False
            pnlEstatusAnterior.Visible = False
            pnlCambiosGlobales.Visible = False

        End Try
    End Sub

    Public Sub CargarMarcasNaveEstatus()
        Dim objConsumos As New ConsumosBU
        Dim lista As New DataTable
        lista = objConsumos.ObtenerMarcasEstilosConsumos(cmbNave.SelectedValue, cmbEstatus.Text)

        If lista.Rows.Count > 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbMarca.DataSource = lista
            cmbMarca.DisplayMember = "Marca"
            cmbMarca.ValueMember = "marc_marcaid"
        End If


    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        Dim obj As New catalagosBU
        Dim tipoNave As DataTable
        Dim objConsumos As New ConsumosBU
        Dim vNavesMaquilas As New DataTable

        cmbMarca.SelectedValue = 0
        cmbColeccion.SelectedValue = 0
        cmbEstatus.SelectedValue = 0
        grdProductosRegistrados.DataSource = Nothing
        cmbMarca.DataSource = Nothing
        cmbColeccion.DataSource = Nothing
        cbxVerimagen.Checked = False
        vNavesMaquilas = obj.ObtenerNavesMaquilas()


        Try

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PNAVESMAQUILAS") Then
                If cmbNave.Text <> "" Then
                    Dim query = From c In vNavesMaquilas.AsEnumerable() Where c.Field(Of Integer)("nave_naveid") = cmbNave.SelectedValue Select c
                    If query.ToList().Count > 0 Then
                        btnAutorizarProduccion.Enabled = True
                        pnlautorizarP.Enabled = True
                    Else
                        btnAutorizarProduccion.Enabled = False
                        pnlautorizarP.Enabled = False
                    End If
                End If
            End If

            tipoNave = obj.TipoNave(cmbNave.SelectedValue)
            If tipoNave.Rows(0).Item(0) = True Then
                '   CargarComoEstatus()
                CargarMarcasNaveEstatus()

                'llenarComboEstatusGeneral()
                'llenarComoboMarcas(cmbNave.SelectedValue)
                TipodeNave = 1
            Else
                'llenarComboEstatusNaveProduccion()
                ' CargarComoEstatus()
                'listaMarcasProduccion(cmbNave.SelectedValue)
                CargarMarcasNaveEstatus()
                TipodeNave = 0
            End If

        Catch ex As Exception
        End Try

        Try
            If cmbNave.Text = "" Then
                cmbEstatus.DataSource = Nothing
            End If
        Catch ex As Exception
        End Try

        Try
            Dim esNaveMaquila = obj.naveMaquila(cmbNave.SelectedValue)
            If esNaveMaquila.Rows(0).Item(0) = True Then
                naveMaquila = True
            Else
                naveMaquila = False
            End If
        Catch ex As Exception
        End Try

        Try
            llenarTablaPermisosPantalla()
            If cmbNave.SelectedIndex <> 0 Then
                Dim clave As String = ""
                Dim ActualizoPanel As Integer = 0
                Dim NoActualizaPanel As Integer = 0

                If tblPermisosEspecialesPorUsuario.Rows.Count > 0 Then
                    If tblPermisosPantallaNave.Rows.Count > 0 Then
                        For i As Integer = 0 To tblPermisosEspecialesPorUsuario.Rows.Count - 1
                            clave = tblPermisosEspecialesPorUsuario.Rows(i).Item("ClaveAccion").ToString()
                            ActualizoPanel = 0
                            For j As Integer = 0 To tblPermisosPantallaNave.Rows.Count - 1
                                If tblPermisosPantallaNave.Rows(j).Item("ClaveAccion") = clave Then
                                    buscarPanelNoHacerVisible(clave)
                                    ActualizoPanel = 1
                                End If
                            Next
                            If ActualizoPanel = 0 Then
                                buscarPanelHacerVisible(clave)
                            End If
                        Next
                    Else
                        For h As Integer = 0 To tblPermisosEspecialesPorUsuario.Rows.Count - 1
                            clave = tblPermisosEspecialesPorUsuario.Rows(h).Item("ClaveAccion").ToString()
                            buscarPanelHacerVisible(clave)
                        Next
                    End If
                End If

                'If tblPermisosPantallaNave.Rows.Count > 0 Then
                '    For Each row As DataRow In tblPermisosPantallaNave.Rows
                '        If row.Item("NaveID") = cmbNave.SelectedValue And row.Item("UsuarioID") = SesionUsuario.UsuarioSesion.PUserUsuarioid Then
                '            claveAccionModulo = row.Item("ClaveAccion")
                '            buscarPanelNoHacerVisible(claveAccionModulo)
                '        Else
                '            buscarPanelHacerVisible(claveAccionModulo)
                '        End If
                '    Next
                'Else
                '    If tblPermisosEspecialesPorUsuario.Rows.Count > 0 Then
                '        For Each row As DataRow In tblPermisosEspecialesPorUsuario.Rows
                '            If row.Item("ClaveAccion").ToString() <> "" Then 'And row.Item("UsuarioID") = SesionUsuario.UsuarioSesion.PUserUsuarioid Then
                '                claveAccionModulo = row.Item("ClaveAccion")
                '                buscarPanelHacerVisible(claveAccionModulo)
                '            End If
                '        Next
                '    End If
                'End If
            End If
        Catch ex As Exception

        End Try

        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PNAVEP") And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PADMONC") And
        '     Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PCOORD") And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PPRODG") And
        '     Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PPRODP") And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PADMONM") Then
        '    pblAlta.Visible = True
        '    pnlAsignar.Visible = True
        '    pnlAutorizarD.Visible = True
        '    pnlautorizarP.Visible = True
        '    pnlDescontinuar.Visible = True
        '    pnlInactivar.Visible = True
        '    pnlEstatusAnterior.Visible = True
        '    pnlEditar.Visible = True
        '    pnlCambiosGlobales.Visible = True
        'ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PPRODG") Then
        '    pblAlta.Visible = False
        '    pnlEditar.Visible = True
        '    lblEditar.Text = "Consulta"
        '    btnEditar.Image = Produccion.Vista.My.Resources.Resources.details
        '    pnlAsignar.Visible = False
        '    pnlAutorizarD.Visible = False
        '    pnlautorizarP.Visible = True
        '    pnlDescontinuar.Visible = False
        '    pnlInactivar.Visible = False
        '    pnlEstatusAnterior.Visible = False
        '    pnlCambiosGlobales.Visible = False
        'ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "PPRODP") Then
        '    pnlEditar.Visible = True
        '    lblEditar.Text = "Consulta"
        '    btnEditar.Image = Produccion.Vista.My.Resources.Resources.details
        '    pnlAsignar.Visible = True
        '    pnlAutorizarD.Visible = False
        '    pnlautorizarP.Visible = False
        '    pnlDescontinuar.Visible = True
        '    pnlInactivar.Visible = True
        '    pnlEstatusAnterior.Visible = True
        '    lblEstatusAnterior.Text = "Reactivar a" & vbCrLf & "Desarrollo"
        '    pnlCambiosGlobales.Visible = False
        'Else
        '    validarPerfiles()
        'End If


    End Sub

    Public Sub buscarPanelNoHacerVisible(ByVal cambiarClave As String)
        Select Case cambiarClave
            Case "ALTA_CONSUMO"
                pblAlta.Visible = False
            Case "EDITAR_CONSUMO"
                pnlEditar.Visible = False
            Case "ASIGNAR_CONSUMO"
                pnlAsignar.Visible = False
            Case "AUTORIZARDESARROLLO_CONSUMO"
                pnlAutorizarD.Visible = False
            Case "AUTORIZARPRODUCCION_CONSUMO"
                pnlautorizarP.Visible = False
            Case "INACTIVARNAVE_CONSUMO"
                pnlInactivar.Visible = False
            Case "DESCONTINUAR_CONSUMO"
                pnlDescontinuar.Visible = False
            Case "ESTATUSANTERIOR_CONSUMO"
                pnlEstatusAnterior.Visible = False
            Case "CAMBIOSGLOBALES_CONSUMO"
                pnlCambiosGlobales.Visible = False
        End Select
    End Sub

    Public Sub buscarPanelHacerVisible(ByVal cambiarClave As String)
        Select Case cambiarClave
            Case "ALTA_CONSUMO"
                pblAlta.Visible = True
            Case "EDITAR_CONSUMO"
                pnlEditar.Visible = True
            Case "ASIGNAR_CONSUMO"
                pnlAsignar.Visible = True
            Case "AUTORIZARDESARROLLO_CONSUMO"
                pnlAutorizarD.Visible = True
            Case "AUTORIZARPRODUCCION_CONSUMO"
                pnlautorizarP.Visible = True
            Case "INACTIVARNAVE_CONSUMO"
                pnlInactivar.Visible = True
            Case "DESCONTINUAR_CONSUMO"
                pnlDescontinuar.Visible = True
            Case "ESTATUSANTERIOR_CONSUMO"
                pnlEstatusAnterior.Visible = True
            Case "CAMBIOSGLOBALES_CONSUMO"
                pnlCambiosGlobales.Visible = True
        End Select
    End Sub

    Private Sub cmbEstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstatus.SelectedIndexChanged
        Try
            Dim x = cmbEstatus.SelectedValue
            If cmbNave.Text <> "" And cmbColeccion.Text <> "" And cmbMarca.Text <> "" Then
                cbxVerimagen.Visible = True
            Else
                cbxVerimagen.Visible = False
                cbxVerimagen.Checked = False
            End If
            CargarMarcasNaveEstatus()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarColeccionesArticulosNAve()
        Dim obj As New ConsumosBU
        Dim lista As New DataTable
        lista = obj.ObtenerColeccionesProductoEstiloConsumos(cmbNave.SelectedValue, cmbEstatus.Text, cmbMarca.SelectedValue)
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbColeccion.DataSource = lista
            cmbColeccion.DisplayMember = "cole_descripcion"
            cmbColeccion.ValueMember = "cole_coleccionid"
        End If


    End Sub

    Private Sub cmbMarca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarca.SelectedIndexChanged
        grdProductosRegistrados.DataSource = Nothing
        Try
            If cmbNave.Text <> "" And cmbColeccion.Text <> "" And cmbMarca.Text <> "" Then
                cbxVerimagen.Visible = True
            Else
                cbxVerimagen.Visible = False
                cbxVerimagen.Checked = False
            End If
            If TipodeNave = 1 Then
                'llenarComboColeccionNaveDesarrolla(cmbNave.SelectedValue, cmbMarca.SelectedValue)
                CargarColeccionesArticulosNAve()
            Else
                'llenarComboColeccion(cmbNave.SelectedValue, cmbMarca.SelectedValue)
                CargarColeccionesArticulosNAve()
            End If

        Catch ex As Exception

        End Try
        Try
            If cmbMarca.Text = "" Then
                cmbColeccion.DataSource = Nothing
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbColeccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColeccion.SelectedIndexChanged
        grdProductosRegistrados.DataSource = Nothing
        Try
            If cmbNave.Text <> "" And cmbColeccion.Text <> "" And cmbMarca.Text <> "" Then
                cbxVerimagen.Visible = True
            Else
                cbxVerimagen.Visible = False
                cbxVerimagen.Checked = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub grdProductosRegistrados_DoubleClick(sender As Object, e As EventArgs) Handles grdProductosRegistrados.DoubleClick
        Dim contador = 0
        Try
            If grdProductosRegistrados.ActiveCell.Column.ToString = "Imagen" Then
                contador = 1
            Else
                contador = 2
            End If
        Catch ex As Exception
        End Try

        If contador = 1 Then
            'If grdProductosRegistrados.ActiveRow.Index > -1 Then
            '    Try
            '        If grdProductosRegistrados.ActiveCell.Column.ToString = "Imagen" Then
            '            If grdProductosRegistrados.ActiveRow.Cells("Ruta").Text.Length > 0 Then
            '                'Process.Start(grdListado.ActiveRow.Cells("Ruta").Text)
            '                Dim form As New ImagenEstiloForm
            '                form.imagen = grdProductosRegistrados.ActiveRow.Cells("Ruta").Text
            '                form.ShowDialog()
            '            End If
            '        Else
            '            grdProductosRegistrados.ActiveRow.Selected = True
            '        End If
            '    Catch ex As Exception
            '        objAdvertencia.mensaje = "No se puede localizar el archivo."
            '        objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            '        objAdvertencia.ShowDialog()
            '    End Try
            'End If
        End If

        Try
            If grdProductosRegistrados.ActiveCell.Column.ToString = "Asignado a Producción" Then
                ' If grdProductosRegistrados.ActiveRow.Cells("Asignado a Producción").Text <> "" Then
                Dim form As New ConsultaEstadosArticuloPorNaveForm
                Dim obj As New catalagosBU
                Dim tabla As New DataTable
                tabla = obj.ConsultarEstatusProductoEstilo(grdProductosRegistrados.ActiveRow.Cells("EstiloID").Value)
                form.tabla = tabla
                form.ShowDialog()
                'End If
            End If
        Catch ex As Exception
        End Try


        'If contador = 2 Then
        '    If grdProductosRegistrados.Rows.Count > 0 Then
        '        'If grdProductosRegistrados.ActiveRow.Selected Then
        '        Dim form As New AltaConsumosFracciones
        '        form.productoEstiloId = grdProductosRegistrados.ActiveRow.Cells("EstiloID").Value
        '        If grdProductosRegistrados.ActiveRow.Cells("status").Value = "DESARROLLO" Or grdProductosRegistrados.ActiveRow.Cells("status").Value = "AUTORIZADO DESARROLLO" Then
        '            form.accion = "Desarrollo"
        '            form.estatusArticulo = grdProductosRegistrados.ActiveRow.Cells("status").Text
        '            form.idNaveConsulta = cmbNave.SelectedValue
        '            form.naveDesarrolla = cmbNave.Text
        '            form.ShowDialog()
        '            cargartabla()
        '        Else
        '            form.idNaveConsulta = cmbNave.SelectedValue
        '            form.accion = "Produccion"
        '            form.estatusArticulo = grdProductosRegistrados.ActiveRow.Cells("status").Text
        '            form.naveDesarrolla = cmbNave.Text
        '            form.ShowDialog()
        '            cargartabla()
        '        End If
        '        'End If
        '    End If
        'End If
    End Sub

    Private Sub grdProductosRegistrados_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdProductosRegistrados.InitializeRow
        If cbxVerimagen.Checked Then
            Dim imagen As System.Drawing.Image
            Dim StreamFoto As System.IO.Stream
            Dim objFTP As New Tools.TransferenciaFTP
            Dim Carpeta As String = "Programacion/Modelos/"

            Me.Cursor = Cursors.WaitCursor
            If e.Row.Cells.Exists("Imagen") Then
                e.Row.Cells("Imagen").Appearance.ImageBackground = Global.Produccion.Vista.My.Resources.Resources.imagen
            End If

            If e.Row.Cells.Exists("Imagen") Then
                e.Row.Cells("Imagen").Appearance.BackColor = Color.White
                Try
                    If IsDBNull(e.Row.Cells("Imagen")) = False Then
                        imagen = Nothing

                        If (e.Row.Cells("ruta").Value.ToString <> Nothing) Then
                            StreamFoto = objFTP.StreamFileThumbNail(Carpeta, e.Row.Cells("Ruta").Value.ToString)
                            imagen = System.Drawing.Image.FromStream(StreamFoto)
                            e.Row.Cells("Imagen").Appearance.ImageBackground = imagen
                        End If
                    End If

                Catch ex As Exception
                    Try
                        StreamFoto = objFTP.StreamFileThumbNail(Carpeta, e.Row.Cells("Ruta").Value.ToString)
                        imagen = System.Drawing.Image.FromStream(StreamFoto)

                        e.Row.Cells("Imagen").Appearance.ImageBackground = imagen
                    Catch exe As Exception

                    End Try
                End Try
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnExportarExcel_Click_1(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        consumos = 0
        If grdProductosRegistrados.Rows.Count > 0 Then
            ExportarGridAExcel()
        End If
    End Sub
    Private Sub ExportarGridAExcel(Optional nombreArchivo As String = "")

        'sfd.DefaultExt = "xlsx"
        'sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"

        Dim sfd As New SaveFileDialog With {
            .DefaultExt ="csv",
            .Filter = "Excel Files|*.csv",
            .FileName = IIf(nombreArchivo <> "", nombreArchivo, "")
        }

        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                If consumos = 1 Then
                    Dim dt As DataTable = grdBaseConsumos.DataSource

                    Dim line As New List(Of String)
                    Using csv As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(fileName, False)
                        If Not IsNothing(dt) Then
                            For Each columna As DataColumn In dt.Columns
                                line.Add(columna.ColumnName)
                            Next

                            If line.Count > 0 Then _
                                csv.WriteLine(String.Join(",", line))

                            For Each fila As DataRow In dt.Rows
                                line.Clear()
                                For Each columna In fila.ItemArray
                                    If IsNothing(columna) OrElse IsDBNull(columna) Then
                                        line.Add("NULL")
                                    Else
                                        line.Add($"""{Replace(columna.ToString, """", """""")}""")
                                    End If
                                Next
                                csv.WriteLine(String.Join(",", line))
                            Next
                        End If
                    End Using

                Else
                    ultExportGrid.Export(grdProductosRegistrados, fileName)
                End If


                Dim objMensajeExito As New Tools.ExitoForm
                objAdvertencia.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
                Process.Start(fileName)


            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objAdvertencia.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdProductosRegistrados.DataSource = Nothing
        'cmbNave.SelectedValue = 0
        cmbMarca.SelectedValue = 0
        cmbColeccion.SelectedValue = 0
        cmbEstatus.SelectedValue = 0
        cbxVerimagen.Checked = False
    End Sub

    Private Sub grdProductosRegistrados_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = Windows.Forms.Keys.Up Then
                grdProductosRegistrados.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdProductosRegistrados.DisplayLayout.Bands(0)
                If grdProductosRegistrados.ActiveRow.HasPrevSibling(True) Then
                    Dim nextRow As UltraGridRow = grdProductosRegistrados.ActiveRow.GetSibling(SiblingRow.Previous, True)
                    grdProductosRegistrados.ActiveCell = nextRow.Cells(grdProductosRegistrados.ActiveCell.Column)
                    e.Handled = True
                    'grdProductosRegistrados.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Down Then
                grdProductosRegistrados.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdProductosRegistrados.DisplayLayout.Bands(0)
                If grdProductosRegistrados.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdProductosRegistrados.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdProductosRegistrados.ActiveCell = nextRow.Cells(grdProductosRegistrados.ActiveCell.Column)
                    e.Handled = True
                    'grdProductosRegistrados.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub grdProductosRegistrados_KeyDown_1(sender As Object, e As KeyEventArgs) Handles grdProductosRegistrados.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Up Then
                grdProductosRegistrados.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdProductosRegistrados.DisplayLayout.Bands(0)
                If grdProductosRegistrados.ActiveRow.HasPrevSibling(True) Then
                    Dim nextRow As UltraGridRow = grdProductosRegistrados.ActiveRow.GetSibling(SiblingRow.Previous, True)
                    grdProductosRegistrados.ActiveCell = nextRow.Cells(grdProductosRegistrados.ActiveCell.Column)
                    e.Handled = True
                    'grdProductosRegistrados.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Down Then
                grdProductosRegistrados.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdProductosRegistrados.DisplayLayout.Bands(0)
                If grdProductosRegistrados.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdProductosRegistrados.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdProductosRegistrados.ActiveCell = nextRow.Cells(grdProductosRegistrados.ActiveCell.Column)
                    e.Handled = True
                    'grdProductosRegistrados.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdProductosRegistrados_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdProductosRegistrados.DoubleClickCell
        If grdProductosRegistrados.Rows.Count > 0 Then
            Try
                grdProductosRegistrados.ActiveRow.Selected = True
            Catch ex As Exception
            End Try
            If grdProductosRegistrados.ActiveRow.Selected Then
                Dim form As New AltaConsumosFracciones
                form.editar = True
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsumosCompleto", "MODIFICARCONSUMOS") Then
                    PermisoModificar = True
                Else
                    PermisoModificar = False
                End If

                form.productoEstiloId = grdProductosRegistrados.ActiveRow.Cells("EstiloID").Value
                If grdProductosRegistrados.ActiveRow.Cells("status").Value = "DESARROLLO" Or grdProductosRegistrados.ActiveRow.Cells("status").Value = "AUTORIZADO DESARROLLO" Then
                    Me.Cursor = Cursors.WaitCursor
                    form.accion = "Desarrollo"
                    form.permisoModificar = PermisoModificar
                    form.estatusArticulo = grdProductosRegistrados.ActiveRow.Cells("status").Text
                    Try
                        form.otroEstatus = grdProductosRegistrados.ActiveRow.Cells("OtroStatus").Text
                    Catch ex As Exception
                    End Try

                    If cmbNave.SelectedValue = 99 Then
                        form.idNaveConsulta = grdProductosRegistrados.ActiveRow.Cells("pres_navedesarrollaid").Text
                    Else
                        form.idNaveConsulta = cmbNave.SelectedValue
                    End If




                    form.naveDesarrolla = cmbNave.Text
                    Try
                        form.naves = grdProductosRegistrados.ActiveRow.Cells("Asignación Producción").Text
                    Catch ex As Exception
                    End Try
                    form.modelo = grdProductosRegistrados.ActiveRow.Cells("Modelo").Text
                    form.NAveDesarrollaID = grdProductosRegistrados.ActiveRow.Cells("pres_navedesarrollaid").Text
                    form.ShowDialog()
                    ' cargartabla()
                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.WaitCursor
                    If cmbNave.SelectedValue = 99 Then
                        form.idNaveConsulta = grdProductosRegistrados.ActiveRow.Cells("pres_navedesarrollaid").Text
                    Else
                        form.idNaveConsulta = cmbNave.SelectedValue
                    End If
                    'form.idNaveConsulta = cmbNave.SelectedValue
                    form.estatusArticulo = grdProductosRegistrados.ActiveRow.Cells("status").Text
                    form.accion = "Produccion"
                    form.modelo = grdProductosRegistrados.ActiveRow.Cells("Modelo").Text
                    form.naveDesarrolla = cmbNave.Text
                    form.permisoModificar = PermisoModificar
                    form.NAveDesarrollaID = grdProductosRegistrados.ActiveRow.Cells("pres_navedesarrollaid").Text
                    form.ShowDialog()
                    ' cargartabla()
                    Me.Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub btnImprimirPDF_Click(sender As Object, e As EventArgs) Handles btnImprimirPDF.Click
        Dim contador As Integer = 0
        Dim contadorseleccion As Integer = 0
        Dim vMarca As String
        Dim vColeccion As String
        Dim vModeloSicy As String
        Dim vModelo As String
        Dim vModeloFn As String
        Dim vPiel As String
        Dim vColor As String
        Dim vCorrida As String

        Dim form As New AdministradorArchivosProduccion
        If grdProductosRegistrados.Rows.Count > 0 Then
            If IsNothing(grdProductosRegistrados.ActiveRow) = True Then
                objAdvertencia.mensaje = "Seleccione un artículo."
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
                Return
            End If
            For value = 0 To grdProductosRegistrados.Rows.Count - 1
                If grdProductosRegistrados.Rows(value).Cells(" ").Value = 1 Then

                    Dim vEstilo As EstiloArchivosTecnicos = New EstiloArchivosTecnicos()
                    vMarca = grdProductosRegistrados.Rows(value).Cells("Marca").Text
                    vColeccion = grdProductosRegistrados.Rows(value).Cells("Colección").Text
                    vModeloSicy = grdProductosRegistrados.Rows(value).Cells("Modelo SICY").Text
                    vModelo = grdProductosRegistrados.Rows(value).Cells("Modelo").Text
                    vPiel = grdProductosRegistrados.Rows(value).Cells("Piel").Text
                    vColor = grdProductosRegistrados.Rows(value).Cells("Color").Text
                    vCorrida = grdProductosRegistrados.Rows(value).Cells("Corrida").Text

                    If vModelo = vModeloSicy Then
                        vModeloFn = vModelo
                    Else
                        vModeloFn = vModelo + " (" + vModeloSicy + ")"
                    End If

                    vEstilo.PIdEstilo = Integer.Parse(grdProductosRegistrados.Rows(value).Cells("EstiloID").Text)
                    vEstilo.PEstiloProducto = vMarca + " " + vColeccion + " " + vModeloFn + " " + vPiel + " " + vColor + " " + vCorrida
                    form.vLstIdEstilo.Add(vEstilo)

                End If
            Next

            form.vIdNave = cmbNave.SelectedValue
            form.vEsDepto = True
            form.MdiParent = MdiParent
            form.Show()

        End If
    End Sub

    Private Sub btnVistaPreviaTarjeta_Click(sender As Object, e As EventArgs) Handles btnVistaPreviaTarjeta.Click

        Cursor = Cursors.WaitCursor
        Dim vIdProductoEstilo As Integer = validaSeleccionRegistro()
        If vIdProductoEstilo = 0 Then
            If IsNothing(grdProductosRegistrados.ActiveRow) = True Then
                objAdvertencia.mensaje = "Seleccione un artículo."
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
            End If
        Else

            If cmbNave.SelectedValue = 99 Then
                'Form.idNaveConsulta = grdProductosRegistrados.ActiveRow.Cells("pres_navedesarrollaid").Text
                reporteTarjetaVistaPrevia(vIdProductoEstilo, grdProductosRegistrados.ActiveRow.Cells("pres_navedesarrollaid").Text)
            Else
                'Form.idNaveConsulta = cmbNave.SelectedValue
                reporteTarjetaVistaPrevia(vIdProductoEstilo, cmbNave.SelectedValue)
            End If




        End If
        Cursor = Cursors.Default
    End Sub


    Public Sub reporteTarjetaVistaPrevia(ByVal pProductoEstiloId As Integer, pIdNave As Integer)
        Dim obj As New ReportesBU
        Dim encabezado As New DataTable
        Dim numeracion As New DataTable
        Dim tabla As New DataTable
        Dim tablaPe As New DataTable

        Dim ds As New DataSet
        Dim nave As String = ""
        Dim año As String = ""

        Dim tiempo As Double = 0
        Dim costo As Double = 0
        Dim tabla1maquina As String = ""

        Dim tablaDcm As New DataTable
        Dim tablaPiel As New DataTable
        Dim dcm As Double = 0
        Dim dcmSint As Double = 0




        numeracion = obj.ObtenerNumeracion_VistaPreviaTarjetaProduccion(pProductoEstiloId)
        tabla = obj.ObtenerFracciones_VistaPreviaTarjetaProduccion(pProductoEstiloId, pIdNave)
        encabezado = obj.ObtenerEncabezado_VistaPreviaTarjetaProduccion(pProductoEstiloId, pIdNave)

        tablaDcm = obj.ReporteTarjetaProduccionTotalDCMComponentePiel(pProductoEstiloId, pIdNave)
        dcm = tablaDcm.Rows(0).Item(0)

        tablaPiel = obj.ReporteTarjetaProduccionTotalDCMPielSintetica(pProductoEstiloId, pIdNave)
        dcmSint = tablaPiel.Rows(0).Item(0)


        costo = encabezado.Rows(0).Item("Costo")
        tiempo = encabezado.Rows(0).Item("tiempo")
        tabla1maquina = tabla.Rows(0).Item("maquinaria")

        Dim tabla1 = New DataTable
        tabla1.Clear()
        tabla1.Columns.Add("costo")
        tabla1.Columns.Add("tiempo")
        tabla1.Columns.Add("fraccion")
        tabla1.Columns.Add("observacion")
        tabla1.Columns.Add("maquina")

        tabla1.Columns.Add("costo2")
        tabla1.Columns.Add("tiempo2")
        tabla1.Columns.Add("fraccion2")
        tabla1.Columns.Add("observacion2")
        tabla1.Columns.Add("maquina2")


        tabla1.Columns.Add("costo3")
        tabla1.Columns.Add("tiempo3")
        tabla1.Columns.Add("fraccion3")
        tabla1.Columns.Add("observacion3")
        tabla1.Columns.Add("maquina3")


        tabla1.Columns.Add("costo4")
        tabla1.Columns.Add("tiempo4")
        tabla1.Columns.Add("fraccion4")
        tabla1.Columns.Add("observacion4")
        tabla1.Columns.Add("maquina4")


        tabla1.Columns.Add("costo5")
        tabla1.Columns.Add("tiempo5")
        tabla1.Columns.Add("fraccion5")
        tabla1.Columns.Add("observacion5")
        tabla1.Columns.Add("maquina5")


        tabla1.Columns.Add("costo6")
        tabla1.Columns.Add("tiempo6")
        tabla1.Columns.Add("fraccion6")
        tabla1.Columns.Add("observacion6")
        tabla1.Columns.Add("maquina6")


        tabla1.Columns.Add("costo7")
        tabla1.Columns.Add("tiempo7")
        tabla1.Columns.Add("fraccion7")
        tabla1.Columns.Add("observacion7")
        tabla1.Columns.Add("maquina7")


        Try

            Dim naves As String = ""
            Try
            Catch ex As Exception
            End Try

            For value = 0 To 4
                Dim rowc1 As DataRow = tabla1.NewRow()
                Try
                    rowc1("costo") = Format(tabla.Rows(value).Item("precio"), "N2")
                    rowc1("tiempo") = tabla.Rows(value).Item("tiempo1").ToString
                    rowc1("fraccion") = tabla.Rows(value).Item("fraccion").ToString
                    rowc1("observacion") = tabla.Rows(value).Item("observaciones").ToString
                    rowc1("maquina") = tabla.Rows(value).Item("maquinaria").ToString

                    Dim idfraccion As String = ""
                    If tabla.Rows(value).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value).Item("id").ToString
                    ElseIf tabla.Rows(value).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value).Item("id").ToString
                    ElseIf tabla.Rows(value).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value).Item("id").ToString
                    ElseIf tabla.Rows(value).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value).Item("id").ToString
                    End If


                Catch ex As Exception
                End Try
                Try
                    rowc1("costo2") = Format(tabla.Rows(value + 5).Item("precio"), "N2")
                    rowc1("tiempo2") = tabla.Rows(value + 5).Item("tiempo1").ToString
                    rowc1("fraccion2") = tabla.Rows(value + 5).Item("fraccion").ToString
                    rowc1("observacion2") = tabla.Rows(value + 5).Item("observaciones").ToString
                    rowc1("maquina2") = tabla.Rows(value + 5).Item("maquinaria").ToString

                    Dim idfraccion As String = ""
                    If tabla.Rows(value + 5).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value + 5).Item("id").ToString
                    ElseIf tabla.Rows(value + 5).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value + 5).Item("id").ToString
                    ElseIf tabla.Rows(value + 5).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value + 5).Item("id").ToString
                    ElseIf tabla.Rows(value + 5).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value + 5).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value + 5).Item("id").ToString
                    End If

                Catch ex As Exception
                End Try
                Try
                    rowc1("costo3") = Format(tabla.Rows(value + 10).Item("precio"), "N2")
                    rowc1("tiempo3") = tabla.Rows(value + 10).Item("tiempo1").ToString
                    rowc1("fraccion3") = tabla.Rows(value + 10).Item("fraccion").ToString
                    rowc1("observacion3") = tabla.Rows(value + 10).Item("observaciones").ToString
                    rowc1("maquina3") = tabla.Rows(value + 10).Item("maquinaria").ToString

                    Dim idfraccion As String = ""
                    If tabla.Rows(value + 10).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value + 10).Item("id").ToString
                    ElseIf tabla.Rows(value + 10).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value + 10).Item("id").ToString
                    ElseIf tabla.Rows(value + 10).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value + 10).Item("id").ToString
                    ElseIf tabla.Rows(value + 10).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value + 10).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value + 10).Item("id").ToString
                    End If


                Catch ex As Exception
                End Try
                Try
                    rowc1("costo4") = Format(tabla.Rows(value + 15).Item("precio"), "N2")
                    rowc1("tiempo4") = tabla.Rows(value + 15).Item("tiempo1").ToString
                    rowc1("fraccion4") = tabla.Rows(value + 15).Item("fraccion").ToString
                    rowc1("observacion4") = tabla.Rows(value + 15).Item("observaciones").ToString
                    rowc1("maquina4") = tabla.Rows(value + 15).Item("maquinaria").ToString

                    Dim idfraccion As String = ""
                    If tabla.Rows(value + 15).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value + 15).Item("id").ToString
                    ElseIf tabla.Rows(value + 15).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value + 15).Item("id").ToString
                    ElseIf tabla.Rows(value + 15).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value + 15).Item("id").ToString
                    ElseIf tabla.Rows(value + 15).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value + 15).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value + 15).Item("id").ToString
                    End If


                Catch ex As Exception
                End Try
                Try
                    rowc1("costo5") = Format(tabla.Rows(value + 20).Item("precio"), "N2")
                    rowc1("tiempo5") = tabla.Rows(value + 20).Item("tiempo1").ToString
                    rowc1("fraccion5") = tabla.Rows(value + 20).Item("fraccion").ToString
                    rowc1("observacion5") = tabla.Rows(value + 20).Item("observaciones").ToString
                    rowc1("maquina5") = tabla.Rows(value + 20).Item("maquinaria").ToString

                    Dim idfraccion As String = ""
                    If tabla.Rows(value + 20).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value + 20).Item("id").ToString
                    ElseIf tabla.Rows(value + 20).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value + 20).Item("id").ToString
                    ElseIf tabla.Rows(value + 20).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value + 20).Item("id").ToString
                    ElseIf tabla.Rows(value + 20).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value + 20).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value + 20).Item("id").ToString
                    End If


                Catch ex As Exception
                End Try
                Try
                    rowc1("costo6") = Format(tabla.Rows(value + 25).Item("precio"), "N2")
                    rowc1("tiempo6") = tabla.Rows(value + 25).Item("tiempo1").ToString
                    rowc1("fraccion6") = tabla.Rows(value + 25).Item("fraccion").ToString
                    rowc1("observacion6") = tabla.Rows(value + 20).Item("observaciones").ToString
                    rowc1("maquina6") = tabla.Rows(value + 20).Item("maquinaria").ToString

                    Dim idfraccion As String = ""
                    If tabla.Rows(value + 25).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value + 25).Item("id").ToString
                    ElseIf tabla.Rows(value + 25).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value + 25).Item("id").ToString
                    ElseIf tabla.Rows(value + 25).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value + 25).Item("id").ToString
                    ElseIf tabla.Rows(value + 25).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value + 25).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value + 25).Item("id").ToString
                    End If

                Catch ex As Exception
                End Try
                Try
                    rowc1("costo7") = Format(tabla.Rows(value + 30).Item("precio"), "N2")
                    rowc1("tiempo7") = tabla.Rows(value + 30).Item("tiempo1").ToString
                    rowc1("fraccion7") = tabla.Rows(value + 30).Item("fraccion").ToString
                    rowc1("observacion7") = tabla.Rows(value + 20).Item("observaciones").ToString
                    rowc1("maquina7") = tabla.Rows(value + 20).Item("maquinaria").ToString

                    Dim idfraccion As String = ""
                    If tabla.Rows(value + 30).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value + 30).Item("id").ToString
                    ElseIf tabla.Rows(value + 30).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value + 30).Item("id").ToString
                    ElseIf tabla.Rows(value + 30).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value + 30).Item("id").ToString
                    ElseIf tabla.Rows(value + 30).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value + 30).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value + 30).Item("id").ToString
                    End If

                Catch ex As Exception
                End Try
                tabla1.Rows.Add(rowc1)
            Next


            ds.Tables.Add(encabezado)
            ds.Tables.Add(numeracion)
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim OBJReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes


                If tabla.Rows.Count() <= 30 Then
                    EntidadReporte = OBJReporte.LeerReporteporClave("PROD_TARJETA_PREVIA")
                Else
                    EntidadReporte = OBJReporte.LeerReporteporClave("PROD_TARJETA_PREVIA_MAS30")
                End If



                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                Dim vFecha As Date = Date.Now
                Dim DAY = vFecha.DayOfWeek()
                Dim NUMEROMES = vFecha.Month()
                Dim dia As String = ""
                Dim mes As String = ""
                Dim fechaDias As String = ""
                Select Case DAY
                    Case 1
                        dia = "Lunes"
                    Case 2
                        dia = "Martes"
                    Case 3
                        dia = "Miércoles"
                    Case 4
                        dia = "Jueves"
                    Case 5
                        dia = "Viernes"
                    Case 6
                        dia = "Sábado"
                End Select
                Select Case NUMEROMES
                    Case 1
                        mes = "Enero"
                    Case 2
                        mes = "Febrero"
                    Case 3
                        mes = "Marzo"
                    Case 4
                        mes = "Abril"
                    Case 5
                        mes = "Mayo"
                    Case 6
                        mes = "Junio"
                    Case 7
                        mes = "Julio"
                    Case 8
                        mes = "Agosto"
                    Case 9
                        mes = "Septiembre"
                    Case 10
                        mes = "Octubre"
                    Case 11
                        mes = "Noviembre"
                    Case 12
                        mes = "Diciembre"
                End Select
                fechaDias = dia & ",  " & vFecha.ToString("dd") & "  " & mes & " de " & vFecha.ToString("yyyy")

                reporte.Load(archivo)
                reporte.Compile()
                reporte("log") = Tools.Controles.ObtenerLogoNave(pIdNave)
                reporte("coleccion") = encabezado.Rows(0).Item("coleccion").ToString + " " + encabezado.Rows(0).Item("modelo").ToString
                reporte("programa") = fechaDias
                reporte("fecha") = vFecha.ToShortDateString
                reporte("corte") = encabezado.Rows(0).Item("corte").ToString
                reporte("horma") = encabezado.Rows(0).Item("horma").ToString
                reporte("suela") = encabezado.Rows(0).Item("suela").ToString
                reporte("corrida") = encabezado.Rows(0).Item("corrida").ToString
                reporte("dcmSint") = dcmSint.ToString
                reporte("dcm") = dcm.ToString
                reporte("tiempo") = tiempo.ToString()
                reporte("tabla1maquina") = tabla1maquina.ToString
                Dim y = Format(costo, " ##,##00.00")
                reporte("costo") = y.ToString
                Dim imagen As String = "http://192.168.2.158/yuyinerp/" + encabezado.Rows(0).Item("imagen").ToString
                reporte("imagen") = imagen
                reporte("modelo") = encabezado.Rows(0).Item("modelo").ToString
                reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte("n1") = numeracion.Rows(0).Item("1").ToString
                reporte("n2") = numeracion.Rows(0).Item("2").ToString
                reporte("n3") = numeracion.Rows(0).Item("3").ToString
                reporte("n4") = numeracion.Rows(0).Item("4").ToString
                reporte("n5") = numeracion.Rows(0).Item("5").ToString
                reporte("n6") = numeracion.Rows(0).Item("6").ToString
                reporte("n7") = numeracion.Rows(0).Item("7").ToString
                reporte("n8") = numeracion.Rows(0).Item("8").ToString
                reporte("n9") = numeracion.Rows(0).Item("9").ToString
                reporte("n10") = numeracion.Rows(0).Item("10").ToString
                reporte("n11") = numeracion.Rows(0).Item("11").ToString
                reporte("n12") = numeracion.Rows(0).Item("12").ToString
                reporte("n13") = numeracion.Rows(0).Item("13").ToString
                reporte("n14") = numeracion.Rows(0).Item("14").ToString
                reporte("n15") = numeracion.Rows(0).Item("15").ToString
                reporte("n16") = numeracion.Rows(0).Item("16").ToString
                reporte.RegData(tabla1)
                reporte.Dictionary.Clear()
                reporte.Dictionary.Synchronize()
                reporte.Render()
                reporte.Show()


                Me.Cursor = Cursors.Default
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Function validaSeleccionRegistro() As Integer
        Dim vProductoEstiloId As Integer = 0
        If grdProductosRegistrados.Rows.Count > 0 Then
            If IsNothing(grdProductosRegistrados.ActiveRow) = False Then
                vProductoEstiloId = grdProductosRegistrados.ActiveRow.Cells("EstiloID").Value
                Return vProductoEstiloId
            End If
        End If
        Return vProductoEstiloId
    End Function


    Private Sub btnFichaCosto_Click(sender As Object, e As EventArgs) Handles btnFichaCosto.Click

        Cursor = Cursors.WaitCursor
        Dim vIdProductoEstilo As Integer = validaSeleccionRegistro()
        If vIdProductoEstilo = 0 Then
            If IsNothing(grdProductosRegistrados.ActiveRow) = True Then
                objAdvertencia.mensaje = "Seleccione un artículo."
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
            End If
        Else
            reporteCostoConsumos(vIdProductoEstilo, cmbNave.SelectedValue)
        End If
        Cursor = Cursors.Default

    End Sub

    Private Sub reporteCostoConsumos(ByVal pProductoEstiloId As Integer, pIdNave As Integer)

        Dim objBU As New ReportesBU
        Dim dsCostos As New DataSet("dsCostos")
        Dim detalleCostos As New DataTable("dtCostos")
        Dim detalleEncabezado As New DataTable("dtEncabezado")

        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes

        detalleCostos = objBU.ObtenerFichaCostoConsumos(pProductoEstiloId, pIdNave)
        detalleEncabezado = objBU.ObtenerEncabezado_VistaPreviaTarjetaProduccion(pProductoEstiloId, pIdNave)

        detalleCostos.TableName = "dtCostos"

        dsCostos.Tables.Add(detalleCostos)


        EntidadReporte = objReporte.LeerReporteporClave("FICHA_COSTO_CONSUMOS")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

        Dim reporte As New StiReport

        reporte.Load(archivo)
        reporte.Compile()
        reporte("dsCostos") = "dsCostos"
        reporte.Dictionary.Clear()
        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        reporte("fecha") = DateTime.Now.ToString("dd/MM/yyyy")
        reporte("log") = Tools.Controles.ObtenerLogoNave(pIdNave)
        Dim imagen As String = "http://192.168.2.158/yuyinerp/" + detalleEncabezado.Rows(0).Item("imagen").ToString
        reporte("imagen") = imagen
        reporte("coleccion") = detalleEncabezado.Rows(0).Item("coleccion").ToString
        reporte("marca") = detalleEncabezado.Rows(0).Item("marca").ToString
        reporte("modelo") = detalleEncabezado.Rows(0).Item("modelo").ToString
        reporte("corrida") = detalleEncabezado.Rows(0).Item("corrida").ToString
        reporte("Color") = detalleEncabezado.Rows(0).Item("Color").ToString
        reporte("Temporada") = detalleEncabezado.Rows(0).Item("Temporada").ToString
        reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")

        reporte.RegData(dsCostos)
        reporte.Dictionary.Synchronize()
        reporte.Show()

    End Sub




    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim obj As New ConsumosBU
        Dim obj2 As New catalagosBU
        Dim tipoNave As DataTable
        Dim dt As DataTable
        consumos = 1
        If CInt(cmbNave.SelectedValue) <> 0 Then
            'Dim wb As New XLWorkbook
            Cursor = Cursors.WaitCursor
            tipoNave = obj2.TipoNave(cmbNave.SelectedValue)

            If cmbEstatus.Text = "" Then
                combo = 0
            Else
                combo = cmbEstatus.SelectedValue
            End If
            If cmbMarca.Text = "" Then
                marca = 0
            Else
                marca = cmbMarca.SelectedValue
            End If
            If cmbColeccion.Text = "" Then
                coleccion = 0
            Else
                coleccion = cmbColeccion.SelectedValue
            End If

            Select Case combo
                Case 0
                    estatus = ""
                Case 1
                    estatus = "D"
                Case 2
                    estatus = "AD"
                Case 3
                    estatus = "AP"
                Case 4
                    estatus = "I"
                Case 5
                    estatus = "DP"
            End Select

            If tipoNave.Rows(0).Item(0) = True Then
                'dt = obj.BaseDatosConsumosDesarrollo(cmbNave.SelectedValue)
                dt = obj.BaseDatosConsumosDesarrollo(cmbNave.SelectedValue, estatus, marca, coleccion)
            Else
                dt = obj.BaseDatosConsumos(cmbNave.SelectedValue)
            End If
            If dt.Rows.Count > 0 Then
                grdBaseConsumos.DataSource = dt
                disenioGridConsumos()
                Dim nombreArchivo = "ReporteConsumos_" + cmbNave.Text + "_" + Date.Now.ToShortDateString().Replace("/", "-")
                ExportarGridAExcel(nombreArchivo)
                grdBaseConsumos.DataSource = Nothing
                'wb.Worksheets.Add(dt, "Consumos")
                'wb.SaveAs(ruta)
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No existe información para exportar.")
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleccione una Nave.")
        End If
        Cursor = Cursors.Default
    End Sub
End Class