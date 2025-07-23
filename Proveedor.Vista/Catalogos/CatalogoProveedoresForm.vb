Imports Proveedores.BU
Imports Tools
Imports Entidades
Imports Infragistics.Win.UltraWinGrid
Imports System.Windows.Forms
Imports Infragistics.Win

Public Class CatalogoProveedoresForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objConfirmacionGde As New Tools.confirmarFormGrande
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Public id As Integer
    Public proveedorid As Integer
    Public nombreComercial As String
    Public categoria As String
    Public catego As String
    Public pais As String
    Public giro As String
    Public paginaweb As String
    Public tipodecompra As String
    Public limitedecredito As Double
    Public tiempodeentrega As String
    Public tiempoderespuesta As String
    Public usuariomodifico As Integer
    Public fechamodifico As DateTime
    Public act As String
    Public nave As Integer

    Public BuscarRFC As Boolean
    Public BuscarCuenta As Boolean
    Public BuscarUsuario As Boolean
    Public BuscarContacto As Boolean
    Public BuscarPlazo As Boolean
    Public BuscarNave As Boolean
    Dim editar As Boolean
    Dim activ As String

    Dim permisoAltas As Boolean
    Dim permisoEditar As Boolean
    Dim permisoConsultarTodo As Boolean
    Dim tabla As New DataTable

    Dim consulta = 0

    Dim form3 As New ModificarProveedoresForm

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        If cmbNave.SelectedValue <> 0 Then

            nombreComercial = ""
            categoria = ""
            giro = ""
            paginaweb = ""
            tipodecompra = ""
            limitedecredito = 0
            tiempodeentrega = ""
            tiempoderespuesta = ""
            usuariomodifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            fechamodifico = DateTime.Now.ToString("dd/MM/yyyy")

            Dim form1 As New AltaProveedoresForm()

            form1.nave = cmbNave.SelectedValue
            form1.navNombre = cmbNave.Text()
            'form1.Show()
            form1.Size = New Drawing.Size(1060, 260)
            form1.MaximumSize = New Drawing.Size(1060, 260)
            form1.MinimumSize = New Drawing.Size(1060, 260)
            'If form1.ShowDialog = Windows.Forms.DialogResult.Yes Then
            '    actualizar()
            'End If
            form1.cmbTipoRazonSocial.SelectedValue = 2
            Me.Cursor = Windows.Forms.Cursors.Default
            If form1.ShowDialog = Windows.Forms.DialogResult.None Then
                If form1.accion = 1 Then
                    actualizar()
                End If
                If form1.actualizar = 1 Then
                    actualizar()
                End If
                If form1.actualizar = 0 Then
                    actualizar()
                End If
            End If

        Else
            objAdvertencia.mensaje = "Debe seleccionar una nave"
            objAdvertencia.ShowDialog()
            lblNave.ForeColor = Drawing.Color.Red
        End If
        actualizar()
    End Sub

    Public Sub actualizar()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Try

            If rdoActivos.Checked = True Then
                If cmbNave.SelectedValue = 0 Then
                    LlenarTabla()
                    disenioGrid()
                Else
                    activ = "SI"
                    LlenarTablaFiltradaNave(cmbNave.SelectedValue, activ)
                    disenioGrid()
                End If

            ElseIf rdoNoActivos.Checked = True Then
                If cmbNave.SelectedValue = 0 Then
                    LlenarTabla2()
                    disenioGrid2()
                Else
                    activ = "NO"
                    LlenarTablaFiltradaNave(cmbNave.SelectedValue, activ)
                    disenioGrid()
                End If

            ElseIf rdoTodos.Checked = True Then
                If cmbNave.SelectedValue = 0 Then
                    LlenarTabla3()
                    disenioGrid3()
                Else
                    LlenarTablaTodosFiltradaNaveNo(cmbNave.SelectedValue)
                    disenioGrid()
                End If
            End If

        Catch ex As Exception

        End Try
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub
    Private Sub ExportarGridAExcel()

        Dim sfd As New SaveFileDialog
        'sfd.DefaultExt = "xlsx"
        'sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"

        sfd.DefaultExt = "xls"
        sfd.Filter = "Excel Files|*.xls"

        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor

                ultExportGrid.Export(grdListaProveedores, fileName)

                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                Process.Start(fileName)

                grdListaProveedores.DataSource = Nothing
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub ListaProveedoresForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LlenarPermisos()
        LlenarListas()

        Me.WindowState = FormWindowState.Maximized

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "ALTADEPROVEEDORES") Then
            'LlenarTabla()
            'disenioGrid()
            pnl1.Visible = True
        Else
            'pnl1.Visible = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "MODIFICARPROVEEDORES") Then
            pnl2.Visible = True
        Else
            'btnEditar.Visible = False
            'lblEditar.Visible = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "MODIFICARENCABEZADO") Then
            pnl3.Visible = True
        Else
            'btnEditar.Visible = False
            'lblEditar.Visible = False
        End If

        If permisoConsultarTodo And cmbNave.SelectedValue = 0 Then
            'LlenarTabla()
            'disenioGrid()

        ElseIf permisoConsultarTodo = False Then

            ''no llenar la tabla
            If cmbNave.SelectedValue <> 0 Then
                'LlenarTablaFiltradaNave(cmbNave.SelectedValue, activ)
                'disenioGrid()
                'gbxActivoCompras.Visible = False
            End If

        End If

        Dim objConfirmacion As New Tools.ConfirmarForm
        Dim objMensajes As New AdvertenciaForm

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "DATOSDERFC") Then

            Dim form As New AltaProveedoresForm()
            form.proveedorid = proveedorid
            form.nombreComercial = nombreComercial
            form.pais = pais
            form.catego = categoria
            form.giro = giro
            form.paginaweb = paginaweb
            form.limitedecredito = limitedecredito
            form.tiempoderespuesta = tiempoderespuesta
            form.tiempodeentrega = tiempodeentrega
            form.usuariomodifico = usuariomodifico
            form.fechamodifico = fechamodifico
            btnEditar.Visible = True
            lblEditar.Visible = True
        Else
            btnEditar.Visible = False
            lblEditar.Visible = False
        End If

        Dim form2 As New CatalogoCoincidenciasProveedoresForm
        If form2.respuesta = True Then
            LlenarTabla()
            disenioGrid()
        End If

    End Sub

    Public Sub LlenarTabla()

        Dim objBU As New ProveedorBU
        Dim dtListaProveedores As New DataTable
        grdListaProveedores.DataSource = Nothing
        dtListaProveedores = objBU.ListaDatosGeneralesProveedor()
        grdListaProveedores.DataSource = dtListaProveedores

    End Sub

    Public Sub LlenarTablaFiltradaNave(ByVal nave As Integer, ByVal activa As String)

        Dim objBU As New ProveedorBU
        Dim dtListaProveedoresFiltrados As New DataTable
        grdListaProveedores.DataSource = Nothing
        nave = cmbNave.SelectedValue
        dtListaProveedoresFiltrados = objBU.ListaDatosGeneralesProveedorFiltradaNave(nave, activa)
        grdListaProveedores.DataSource = dtListaProveedoresFiltrados

    End Sub

    Public Sub LlenarTablaFiltradaNaveNo(ByVal nave As Integer, ByVal activa As String)

        Dim objBU As New ProveedorBU
        Dim dtListaProveedoresFiltrados As New DataTable
        grdListaProveedores.DataSource = Nothing
        nave = cmbNave.SelectedValue
        If rdoNoActivo.Checked = True Then
            activa = "NO"
        Else
            activa = "SI"
        End If
        activ = activa
        dtListaProveedoresFiltrados = objBU.ListaDatosGeneralesProveedorFiltradaNaveNo(nave, activa)
        grdListaProveedores.DataSource = dtListaProveedoresFiltrados

    End Sub

    Public Sub LlenarTablaTodosFiltradaNaveNo(ByVal nave As Integer)

        Dim objBU As New ProveedorBU
        Dim dtListaProveedoresFiltrados As New DataTable
        grdListaProveedores.DataSource = Nothing
        nave = cmbNave.SelectedValue
        dtListaProveedoresFiltrados = objBU.ListaDatosGeneralesTodosProveedorFiltradaNaveNo(nave)
        grdListaProveedores.DataSource = dtListaProveedoresFiltrados

    End Sub

    Public Sub LlenarListas()
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Public Sub LlenarPermisos()
        permisoConsultarTodo = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "TODOS")
        permisoAltas = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "ALTAS")
        permisoEditar = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "EDITAR")
    End Sub

    Public Sub LlenarTabla2()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaProveedores2 As New DataTable
        grdListaProveedores.DataSource = Nothing
        dtListaProveedores2 = objBU.ListaDatosGeneralesProveedor2()
        grdListaProveedores.DataSource = dtListaProveedores2
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub LlenarTabla3()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaProveedores3 As New DataTable
        grdListaProveedores.DataSource = Nothing
        dtListaProveedores3 = objBU.ListaDatosGeneralesProveedor3()
        grdListaProveedores.DataSource = dtListaProveedores3
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub LimpiarTabla()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaProveedores As New DataTable
        grdListaProveedores.DataSource = Nothing
        dtListaProveedores = objBU.ListaDatosGeneralesProveedor()
        grdListaProveedores.DataSource = ""
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub disenioGrid()

        editar = False

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        With grdListaProveedores.DisplayLayout.Bands(0)

            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOMBRE COMERCIAL").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("PAIS").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("CLASIFICACION").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOMBRE GIRO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("PAGINA WEB").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("LIMITE DE CREDITO").Format = "##,##0"
            .Columns("LIMITE DE CREDITO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("RESPUESTA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ENTREGA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ACTIVO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("CATEGORIA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("GIRO").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("LIMITE DE CREDITO").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("RESPUESTA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ENTREGA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ID").Width = 40
            .Columns("PAIS").Width = 70
            .Columns("CATEGORIA").Width = 40
            .Columns(" ").Width = 3
            .Columns("GIRO").Width = 30
            .Columns("LIMITE DE CREDITO").Width = 50
            .Columns("RESPUESTA").Width = 50
            .Columns("ENTREGA").Width = 40
            .Columns("ACTIVO").Width = 30
            .Columns("GIRO").Hidden = True
            .Columns("CATEGORIA").Hidden = True
            '.PerformAutoResizeColumns(True, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

            Dim id As Integer = 0
            'Dim resp As Boolean
            Dim tamano As Integer = 0
            Dim objBU As New ProveedorBU
            Dim dtListaProveedores As New DataTable
            If rdoNoActivo.Checked = True Then
                activ = "NO"
            Else
                activ = "SI"
            End If
            dtListaProveedores = objBU.ListaDatosGeneralesProveedorFiltradaNave(cmbNave.SelectedValue, activ)
            Dim dtListaProveedores2 As New DataTable
            dtListaProveedores2 = objBU.ListaDatosGeneralesProveedor()

            If permisoConsultarTodo Then

                If grdListaProveedores.Rows.Count > 0 Then
                    Do
                        id = grdListaProveedores.Rows(tamano).Cells(1).Value
                        Dim busca As Boolean
                        'Dim rfc, cuenta, nave, contacto, plazo, usuario As Boolean
                        'rfc = BuscarAlgunRFC(id)
                        'cuenta = BuscarAlgunaCuenta(id)
                        'nave = BuscarAlgunaNave(id)
                        'contacto = BuscarAlgunContacto(id)
                        'plazo = BuscarAlgunPlazo(id)
                        'usuario = BuscarAlgunUsuario(id)
                        busca = BusquedaGrande(id)
                        If busca = True Then
                            grdListaProveedores.Rows(tamano).Cells(" ").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#088A08")
                        Else
                            grdListaProveedores.Rows(tamano).Cells(" ").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF4000")
                        End If
                        tamano = tamano + 1
                    Loop While tamano < grdListaProveedores.Rows.Count
                End If

            ElseIf permisoConsultarTodo = False Then

                If grdListaProveedores.Rows.Count > 0 Then
                    Do
                        id = grdListaProveedores.Rows(tamano).Cells("ID").Value
                        Dim busca As Boolean
                        'Dim rfc, cuenta, nave, contacto, plazo, usuario As Boolean
                        'rfc = BuscarAlgunRFC(id)
                        'cuenta = BuscarAlgunaCuenta(id)
                        'nave = BuscarAlgunaNave(id)
                        'contacto = BuscarAlgunContacto(id)
                        'plazo = BuscarAlgunPlazo(id)
                        'usuario = BuscarAlgunUsuario(id)
                        busca = BusquedaGrande(id)
                        If busca = True Then
                            grdListaProveedores.Rows(tamano).Cells(" ").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#088A08")
                        Else
                            grdListaProveedores.Rows(tamano).Cells(" ").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF4000")
                        End If
                        tamano = tamano + 1
                    Loop While tamano < grdListaProveedores.Rows.Count
                End If
            End If

        End With
        grdListaProveedores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        ' grdListaProveedores.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub disenioGrid2()
        editar = False
        With grdListaProveedores.DisplayLayout.Bands(0)

            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOMBRE COMERCIAL").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("PAIS").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("CLASIFICACION").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOMBRE GIRO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("PAGINA WEB").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("LIMITE DE CREDITO").Format = "##,##0"
            .Columns("LIMITE DE CREDITO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("RESPUESTA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ENTREGA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ACTIVO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("CATEGORIA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("GIRO").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("LIMITE DE CREDITO").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("RESPUESTA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ENTREGA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ID").Width = 40
            .Columns("PAIS").Width = 70
            .Columns("CATEGORIA").Width = 40
            .Columns(" ").Width = 3
            .Columns("GIRO").Width = 30
            .Columns("LIMITE DE CREDITO").Width = 50
            .Columns("RESPUESTA").Width = 50
            .Columns("ENTREGA").Width = 40
            .Columns("ACTIVO").Width = 30
            .Columns("GIRO").Hidden = True
            .Columns("CATEGORIA").Hidden = True
            '.PerformAutoResizeColumns(True, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

            Dim id As Integer = 0
            'Dim resp As Boolean
            Dim tamano As Integer = 0
            Dim objBU As New ProveedorBU
            Dim dtListaProveedores2 As New DataTable
            dtListaProveedores2 = objBU.ListaDatosGeneralesProveedor2()

            If grdListaProveedores.Rows.Count > 0 Then

                Do
                    id = grdListaProveedores.Rows(tamano).Cells(0).Value
                    BuscarAlgunRFC(id)
                    BuscarAlgunaCuenta(id)
                    BuscarAlgunaNave(id)
                    BuscarAlgunContacto(id)
                    BuscarAlgunPlazo(id)
                    BuscarAlgunUsuario(id)

                    If BuscarAlgunRFC(id) = True And BuscarAlgunaCuenta(id) = True And BuscarAlgunaCuenta(id) = True And BuscarAlgunContacto(id) = True And BuscarAlgunPlazo(id) = True And BuscarAlgunUsuario(id) = True And BuscarAlgunaNave(id) = True Then
                        grdListaProveedores.Rows(tamano).Cells(" ").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#088A08")
                    Else
                        grdListaProveedores.Rows(tamano).Cells(" ").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF4000")
                    End If

                    tamano = tamano + 1
                Loop While tamano < dtListaProveedores2.Rows.Count

            End If

        End With
        grdListaProveedores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'grdListaProveedores.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub disenioGrid3()
        editar = False
        With grdListaProveedores.DisplayLayout.Bands(0)
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOMBRE COMERCIAL").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("PAIS").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("CLASIFICACION").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOMBRE GIRO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("PAGINA WEB").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("LIMITE DE CREDITO").Format = "##,##0"
            .Columns("LIMITE DE CREDITO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("RESPUESTA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ENTREGA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ACTIVO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("CATEGORIA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("GIRO").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("LIMITE DE CREDITO").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("RESPUESTA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ENTREGA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ID").Width = 40
            .Columns("PAIS").Width = 70
            .Columns("CATEGORIA").Width = 40
            .Columns(" ").Width = 3
            .Columns("GIRO").Width = 30
            .Columns("LIMITE DE CREDITO").Width = 50
            .Columns("RESPUESTA").Width = 50
            .Columns("ENTREGA").Width = 40
            .Columns("ACTIVO").Width = 30
            .Columns("GIRO").Hidden = True
            .Columns("CATEGORIA").Hidden = True
            '.PerformAutoResizeColumns(True, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

            Dim id As Integer = 0
            'Dim resp As Boolean
            Dim tamano As Integer = 0
            Dim objBU As New ProveedorBU
            Dim dtListaProveedores3 As New DataTable
            dtListaProveedores3 = objBU.ListaDatosGeneralesProveedor3()

            Do
                id = grdListaProveedores.Rows(tamano).Cells("ID").Value
                BuscarAlgunRFC(id)
                BuscarAlgunaCuenta(id)
                BuscarAlgunaNave(id)
                BuscarAlgunContacto(id)
                BuscarAlgunPlazo(id)
                BuscarAlgunUsuario(id)

                If BuscarAlgunRFC(id) = True And BuscarAlgunaCuenta(id) = True And BuscarAlgunaCuenta(id) = True And BuscarAlgunContacto(id) = True And BuscarAlgunPlazo(id) = True And BuscarAlgunUsuario(id) = True And BuscarAlgunaNave(id) = True Then
                    grdListaProveedores.Rows(tamano).Cells(" ").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#088A08")
                Else
                    grdListaProveedores.Rows(tamano).Cells(" ").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF4000")
                End If

                tamano = tamano + 1
            Loop While tamano < dtListaProveedores3.Rows.Count

        End With
        grdListaProveedores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'grdListaProveedores.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    '************************************************Buscar algun registro 
    Public Function BusquedaGrande(ByVal id As Integer) As Boolean
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable

        dtLista = objBU.BusquedaGrande(id)
        If dtLista.Rows.Count > 0 Then
            'si hay
            Return True
        Else
            'no hay
            Return False
        End If
    End Function

    Public Function BuscarAlgunRFC(ByVal id As Integer) As Boolean
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable

        dtLista = objBU.BuscaAlgunRfc(id)
        If dtLista.Rows.Count > 0 Then
            'si hay
            Return True
        Else
            'no hay
            Return False
        End If
    End Function

    Public Function BuscarAlgunaCuenta(ByVal id As Integer) As Boolean
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable

        dtLista = objBU.BuscaAlgunaCuenta(id)
        If dtLista.Rows.Count > 0 Then
            'si hay
            Return True
        Else
            'no hay
            Return False
        End If
    End Function

    Public Function BuscarAlgunUsuario(ByVal id As Integer) As Boolean
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable

        dtLista = objBU.BuscaAlgunUsuario(id)
        If dtLista.Rows.Count > 0 Then
            'si hay
            Return True
        Else
            'no hay
            Return False
        End If
    End Function

    Public Function BuscarAlgunContacto(ByVal id As Integer) As Boolean
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable

        dtLista = objBU.BuscaAlgunContacto(id)
        If dtLista.Rows.Count > 0 Then
            'si hay
            Return True
        Else
            'no hay
            Return False
        End If
    End Function

    Public Function BuscarAlgunPlazo(ByVal id As Integer) As Boolean
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable

        dtLista = objBU.BuscaAlgunPlazo(id)
        If dtLista.Rows.Count > 0 Then
            'si hay
            Return True
        Else
            'no hay
            Return False
        End If
    End Function

    Public Function BuscarAlgunaNave(ByVal id As Integer) As Boolean
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable

        dtLista = objBU.BuscaAlguaNave(id)
        If dtLista.Rows.Count > 0 Then
            'si hay
            Return True
        Else
            'no hay
            Return False
        End If
    End Function

    '************************************************
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        If txtId.TextLength > 0 Then
            buscarRegistros()
            Dim form As New ModificarProveedoresForm()
            form.id = id
            form.proveedorid = proveedorid
            form.nombreComercial = nombreComercial
            form.pais = pais
            form.categoria = catego
            form.giro = giro
            form.paginaweb = paginaweb
            form.limitedecredito = limitedecredito
            form.tiempoderespuesta = tiempoderespuesta
            form.tiempodeentrega = tiempodeentrega
            form.usuariomodifico = usuariomodifico
            form.fechamodifico = fechamodifico
            form.activo = act

            form.txtNombreComercial.Enabled = False
            form.cmbTipoRazonSocial.Enabled = False
            form.cmbPaisProveedor.Enabled = False
            form.txtPaginaWeb.Enabled = False
            form.cmbGiro.Enabled = False
            form.cmbCategoria.Enabled = False
            form.txtTiempoDeEntrega.Enabled = False
            form.txtTiempoDeRespuesta.Enabled = False
            form.txtLimiteCredito.Enabled = False
            form.gbxActivoProveedor.Enabled = False


            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "MODIFICARPROVEEDORES") Then
            Else
                form.pnlDatosGenerales.Enabled = False
                form.btnGuardar.Enabled = False
                form.lblGuardarModificacion.Enabled = False
            End If

            If form.ShowDialog() = Windows.Forms.DialogResult.OK Then
                actualizar()
                form.Show()
            End If

        Else
            objAdvertencia.mensaje = " Seleccione una nave para poder editarla"
            objAdvertencia.ShowDialog()

        End If



    End Sub

    Public Sub buscarRegistros()

        Dim ACTIVO As String
        ACTIVO = grdListaProveedores.ActiveRow.Cells("ACTIVO").Text
        act = ACTIVO

        If ACTIVO = "SI" Then
            BRFC(proveedorid)
            BNave(proveedorid)
            BContacto(proveedorid)
            BCuenta(proveedorid)
            BUsuario(proveedorid)
            BPlazo(proveedorid)

            Dim mensaje1 As String
            Dim mensaje2 As String
            Dim mensaje3 As String
            Dim mensaje4 As String
            Dim mensaje5 As String
            Dim mensaje6 As String
            Dim numeroRegistros = 0

            If BRFC(proveedorid) = True And BCuenta(proveedorid) = True And BUsuario(proveedorid) = True And BContacto(proveedorid) = True And BPlazo(proveedorid) = True And BNave(proveedorid) = True Then

            Else
                If BRFC(proveedorid) = True Then
                    mensaje1 = ""
                Else
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "DATOSDERFC") Then
                        mensaje1 = "registrar un RFC,"
                        numeroRegistros = numeroRegistros + 1
                    End If
                End If

                If BNave(proveedorid) = True Then
                    mensaje2 = ""
                Else
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "ASOCIAR NAVE") Then
                        mensaje2 = " asignar una nave,"
                        numeroRegistros = numeroRegistros + 1
                    End If

                End If

                If BContacto(proveedorid) = True Then
                    mensaje3 = ""
                Else
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "DATOSDECONTACTO") Then
                        mensaje3 = " registrar un contacto,"
                        numeroRegistros = numeroRegistros + 1
                    End If
                End If

                If BCuenta(proveedorid) = True Then
                    mensaje4 = ""
                Else
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "DATOSDECUENTABANCARIA") Then
                        mensaje4 = " registrar una cuenta,"
                        numeroRegistros = numeroRegistros + 1
                    End If
                End If

                If BPlazo(proveedorid) = True Then
                    mensaje5 = ""
                Else
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "PLAZO DE PAGO") Then
                        mensaje5 = " asignar un plazo de pago,"
                        numeroRegistros = numeroRegistros + 1
                    End If
                End If

                If BUsuario(proveedorid) = True Then
                    mensaje6 = ""
                Else
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "SITIOPROVEEDORES") Then
                        mensaje6 = " registrar un usuario"
                        numeroRegistros = numeroRegistros + 1
                    End If
                End If
                If numeroRegistros > 0 Then
                    objAdvertencia.mensaje = "Informacion pendiente de este proveedor" + vbLf + vbLf + mensaje1 + mensaje2 + mensaje3 + mensaje4 + mensaje5 + mensaje6
                    objAdvertencia.ShowDialog()
                End If

            End If
        End If
    End Sub

    Private Sub btnGuardarTodo_Click(sender As Object, e As EventArgs) Handles btnGuardarTodo.Click
        Me.Close()
    End Sub
    '/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/
    Public Sub abrirModificar()
        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "DATOSDERFC") Then
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        proveedorid = CInt(grdListaProveedores.ActiveRow.Cells("ID").Text)
        nombreComercial = grdListaProveedores.ActiveRow.Cells("NOMBRE COMERCIAL").Text
        pais = grdListaProveedores.ActiveRow.Cells("PAIS").Text
        catego = grdListaProveedores.ActiveRow.Cells("CLASIFICACION").Text
        giro = grdListaProveedores.ActiveRow.Cells("GIRO").Text
        paginaweb = grdListaProveedores.ActiveRow.Cells("PAGINA WEB").Text
        limitedecredito = CDbl(grdListaProveedores.ActiveRow.Cells("LIMITE DE CREDITO").Text)
        tiempoderespuesta = grdListaProveedores.ActiveRow.Cells("RESPUESTA").Text
        tiempodeentrega = grdListaProveedores.ActiveRow.Cells("ENTREGA").Text
        usuariomodifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        fechamodifico = DateTime.Now.ToString("dd/MM/yyyy")

        Dim ACTIVO As String
        ACTIVO = grdListaProveedores.ActiveRow.Cells("ACTIVO").Text
        act = ACTIVO

        If ACTIVO = "SI" Then
            BRFC(proveedorid)
            BNave(proveedorid)
            BContacto(proveedorid)
            BCuenta(proveedorid)
            BUsuario(proveedorid)
            BPlazo(proveedorid)

            Dim mensaje1 As String
            Dim mensaje2 As String
            Dim mensaje3 As String
            Dim mensaje4 As String
            Dim mensaje5 As String
            Dim mensaje6 As String
            Dim numeroRegistros = 0

            If BRFC(proveedorid) = True And BCuenta(proveedorid) = True And BUsuario(proveedorid) = True And BContacto(proveedorid) = True And BPlazo(proveedorid) = True And BNave(proveedorid) = True Then

            Else
                If BRFC(proveedorid) = True Then
                    mensaje1 = ""
                Else
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "DATOSDERFC") Then
                        mensaje1 = "registrar un RFC,"
                        numeroRegistros = numeroRegistros + 1
                    End If
                End If

                If BNave(proveedorid) = True Then
                    mensaje2 = ""
                Else
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "ASOCIAR NAVE") Then
                        mensaje2 = " asignar una nave,"
                        numeroRegistros = numeroRegistros + 1
                    End If

                End If

                If BContacto(proveedorid) = True Then
                    mensaje3 = ""
                Else
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "DATOSDECONTACTO") Then
                        mensaje3 = " registrar un contacto,"
                        numeroRegistros = numeroRegistros + 1
                    End If
                End If

                If BCuenta(proveedorid) = True Then
                    mensaje4 = ""
                Else
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "DATOSDECUENTABANCARIA") Then
                        mensaje4 = " registrar una cuenta,"
                        numeroRegistros = numeroRegistros + 1
                    End If
                End If

                If BPlazo(proveedorid) = True Then
                    mensaje5 = ""
                Else
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "PLAZO DE PAGO") Then
                        mensaje5 = " asignar un plazo de pago,"
                        numeroRegistros = numeroRegistros + 1
                    End If
                End If

                If BUsuario(proveedorid) = True Then
                    mensaje6 = ""
                Else
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "SITIOPROVEEDORES") Then
                        mensaje6 = " registrar un usuario"
                        numeroRegistros = numeroRegistros + 1
                    End If
                End If
                If numeroRegistros > 0 Then
                    objAdvertencia.mensaje = "Informacion pendiente de este proveedor" + vbLf + vbLf + mensaje1 + mensaje2 + mensaje3 + mensaje4 + mensaje5 + mensaje6
                    objAdvertencia.ShowDialog()
                End If
            End If

            'Dim form2 As New ModificarProveedoresForm()
            'form2.categoria = catego
            Dim form As New AltaProveedoresForm()
            form.proveedorid = proveedorid
            form.llenarComboTipoRazonSocial()
            nombreComercial.Trim.Replace("  ", "")
            If nombreComercial.Contains("S.A. DE C.V.") Then
                form.nombreComercial = nombreComercial.Trim.Replace("S.A. DE C.V.", "")
                form.tipoRazon = 1
            ElseIf nombreComercial.Contains("S. DE R.L. DE C.V.") Then
                form.nombreComercial = nombreComercial.Trim.Replace("S. DE R.L. DE C.V.", "")
                form.tipoRazon = 2
            Else
                form.nombreComercial = nombreComercial
                form.tipoRazon = 0
            End If
            form.pais = pais
            form.catego = catego
            form.giro = giro
            form.paginaweb = paginaweb
            form.limitedecredito = limitedecredito
            form.tiempoderespuesta = tiempoderespuesta
            form.tiempodeentrega = tiempodeentrega
            form.usuariomodifico = usuariomodifico
            form.fechamodifico = fechamodifico
            form.activo = ACTIVO
            form.consulta = consulta
            'form.Show()
            Me.Cursor = Windows.Forms.Cursors.Default
            If form.ShowDialog() = Windows.Forms.DialogResult.OK Then
                actualizar()
            End If

        End If

        If ACTIVO = "NO" Then
            objAdvertencia.mensaje = "El proveedor tiene que estar activo para poder agregar mas información"
            objAdvertencia.ShowDialog()
        End If
    End Sub

    'Private Sub grdListaProveedores_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles grdListaProveedores.DoubleClickCell
    '    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "MODIFICARPROVEEDORES") Then
    '        If txtId.Text <> "" Then
    '            consulta = 1
    '            abrirModificar()
    '        End If
    '    End If
    'End Sub

    '*********************************************************
    Public Function BNave(ByVal id As Integer) As Boolean
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable
        dtLista = objBU.BuscaAlguaNave(id)
        If dtLista.Rows.Count > 0 Then
            'si hay
            Return True
            BuscarNave = True
        Else
            'no hay
            Return False
            BuscarNave = False
        End If
        Dim form As New AltaProveedoresForm()
        form.BuscarNave = BuscarNave
    End Function

    Public Function BPlazo(ByVal id As Integer) As Boolean
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable
        dtLista = objBU.BuscaAlgunPlazo(id)
        If dtLista.Rows.Count > 0 Then
            'si hay
            Return True
            BuscarNave = True
        Else
            'no hay
            Return False
            BuscarNave = False
        End If
        Dim form As New AltaProveedoresForm()
        form.BuscarNave = BuscarNave
    End Function

    Public Function BContacto(ByVal id As Integer) As Boolean
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable
        dtLista = objBU.BuscaAlgunContacto(id)
        If dtLista.Rows.Count > 0 Then
            'si hay
            Return True
            BuscarNave = True
        Else
            'no hay
            Return False
            BuscarNave = False
        End If
        Dim form As New AltaProveedoresForm()
        form.BuscarNave = BuscarNave
    End Function

    Public Function BUsuario(ByVal id As Integer) As Boolean
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable
        dtLista = objBU.BuscaAlgunUsuario(id)
        If dtLista.Rows.Count > 0 Then
            'si hay
            Return True
            BuscarNave = True
        Else
            'no hay
            Return False
            BuscarNave = False
        End If
        Dim form As New AltaProveedoresForm()
        form.BuscarNave = BuscarNave
    End Function

    Public Function BCuenta(ByVal id As Integer) As Boolean
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable
        dtLista = objBU.BuscaAlgunaCuenta(id)
        If dtLista.Rows.Count > 0 Then
            'si hay
            Return True
            BuscarNave = True
        Else
            'no hay
            Return False
            BuscarNave = False
        End If
        Dim form As New AltaProveedoresForm()
        form.BuscarNave = BuscarNave
    End Function

    Public Function BRFC(ByVal id As Integer) As Boolean
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable
        dtLista = objBU.BuscaAlgunRfc(id)
        If dtLista.Rows.Count > 0 Then
            'si hay
            Return True
            BuscarNave = True
        Else
            'no hay
            Return False
            BuscarNave = False
        End If
        Dim form As New AltaProveedoresForm()
        form.BuscarNave = BuscarNave
    End Function
    '*********************************************************

    Private Sub rdoNoActivos_CheckedChanged(sender As Object, e As EventArgs)
        LimpiarTabla()
        LlenarTablaFiltradaNaveNo(cmbNave.SelectedValue, activ)
        disenioGrid()

        'btnDesactivar.Visible = False
        'lblDesactivar.Visible = False
        'btnActivar.Visible = True
        'lblActivar.Visible = True
    End Sub

    Private Sub rdoActivos_CheckedChanged(sender As Object, e As EventArgs)
        LimpiarTabla()
        LlenarTablaFiltradaNave(cmbNave.SelectedValue, activ)
        disenioGrid()


        'btnDesactivar.Visible = True
        'lblDesactivar.Visible = True
        'btnActivar.Visible = False
        'lblActivar.Visible = False
    End Sub

    Private Sub rdoTodos_CheckedChanged(sender As Object, e As EventArgs)
        LimpiarTabla()
        LlenarTabla3()
        disenioGrid3()

        'btnDesactivar.Visible = False
        'lblDesactivar.Visible = False
        'btnActivar.Visible = False
        'lblActivar.Visible = False
    End Sub

    Public Sub DesactivarContacto()
        Dim EntidadContacto As New DatosGenerales
        Dim objbu As New ProveedorBU
        EntidadContacto.dage_proveedorid = txtId.Text
        EntidadContacto.dage_activo = "NO"
        EntidadContacto.dage_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadContacto.dage_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        objbu.DesactivarContacto(EntidadContacto)
    End Sub

    Public Sub ActivarProveedor()
        Dim EntidadContacto As New DatosGenerales
        Dim objbu As New ProveedorBU
        EntidadContacto.dage_proveedorid = txtId.Text
        EntidadContacto.dage_activo = "SI"
        EntidadContacto.dage_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadContacto.dage_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        objbu.ActivarContacto(EntidadContacto)
    End Sub

    Private Sub grdListaProveedores_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles grdListaProveedores.ClickCell
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "MODIFICARPROVEEDORES") Then
            Dim id As Integer
            txtId.Text = grdListaProveedores.ActiveRow.Cells("ID").Text()
            Dim activo As String
            If txtId.Text <> "" Then
                id = grdListaProveedores.ActiveRow.Cells("ID").Text()
                activo = grdListaProveedores.ActiveRow.Cells("ACTIVO").Text()
                If activo = "SI" Then
                    rdoActivo.Checked = True
                    rdoNoActivo.Checked = False
                ElseIf activo = "NO" Then
                    rdoNoActivo.Checked = True
                    rdoActivo.Checked = False
                End If
                proveedorid = CInt(grdListaProveedores.ActiveRow.Cells("ID").Text)
                txtId.Text = id
                nombreComercial = grdListaProveedores.ActiveRow.Cells("NOMBRE COMERCIAL").Text
                pais = grdListaProveedores.ActiveRow.Cells("PAIS").Text
                catego = grdListaProveedores.ActiveRow.Cells("CLASIFICACION").Text
                txtCat.Text = catego
                giro = grdListaProveedores.ActiveRow.Cells("GIRO").Text
                paginaweb = grdListaProveedores.ActiveRow.Cells("PAGINA WEB").Text
                limitedecredito = CDbl(grdListaProveedores.ActiveRow.Cells("LIMITE DE CREDITO").Text)
                tiempoderespuesta = grdListaProveedores.ActiveRow.Cells("RESPUESTA").Text
                tiempodeentrega = grdListaProveedores.ActiveRow.Cells("ENTREGA").Text
                usuariomodifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                fechamodifico = DateTime.Now.ToString("dd/MM/yyyy")

                Dim ACTIVOO As String
                ACTIVOO = grdListaProveedores.ActiveRow.Cells("ACTIVO").Text
                act = ACTIVOO

                Dim form As New ModificarProveedoresForm()
                form.id = id
                form.proveedorid = proveedorid
                form.nombreComercial = nombreComercial
                form.pais = pais
                form.categoria = txtCat.Text
                form.giro = giro
                form.paginaweb = paginaweb
                form.limitedecredito = limitedecredito
                form.tiempoderespuesta = tiempoderespuesta
                form.tiempodeentrega = tiempodeentrega
                form.usuariomodifico = usuariomodifico
                form.fechamodifico = fechamodifico
            End If
        End If

    End Sub

    Private Sub rdoActivo_Click(sender As Object, e As EventArgs) Handles rdoActivo.Click
        If txtId.TextLength > 0 Then

            objConfirmacion.mensaje = "¿Está seguro de activar al proveedor?"
            If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ActivarProveedor()
                objExito.mensaje = "Proveedor activado con éxito"
                objExito.ShowDialog()
                LlenarTabla()
                disenioGrid()
            End If
        End If

    End Sub

    Private Sub rdoNoActivo_Click(sender As Object, e As EventArgs) Handles rdoNoActivo.Click
        If txtId.TextLength > 0 Then

            objConfirmacion.mensaje = "¿Está seguro de desactivar al proveedor?"
            If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                DesactivarContacto()
                objExito.mensaje = "Proveedor desactivado con éxito"
                objExito.ShowDialog()
                LlenarTabla()
                disenioGrid()
            End If

        End If
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs)

        'If cmbNave.Text<>"" Then
        '    LlenarTablaFiltradaNave(cmbNave.SelectedValue)
        '    disenioGrid()
        'End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        LlenarTablaFiltradaNave(cmbNave.SelectedValue, activ)
        disenioGrid()
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "TODOS") Then
            If rdoActivos.Checked = True Then
                If cmbNave.SelectedValue = 0 Then
                    LlenarTabla()
                    disenioGrid()
                Else
                    activ = "SI"
                    LlenarTablaFiltradaNave(cmbNave.SelectedValue, activ)
                    disenioGrid()
                End If

            ElseIf rdoNoActivos.Checked = True Then
                If cmbNave.SelectedValue = 0 Then
                    LlenarTabla2()
                    disenioGrid2()
                Else
                    activ = "NO"
                    LlenarTablaFiltradaNave(cmbNave.SelectedValue, activ)
                    disenioGrid()
                End If

            ElseIf rdoTodos.Checked = True Then
                If cmbNave.SelectedValue = 0 Then
                    LlenarTabla3()
                    disenioGrid3()
                Else
                    LlenarTablaTodosFiltradaNaveNo(cmbNave.SelectedValue)
                    disenioGrid()
                End If
            End If
        Else
            If cmbNave.Text = "" Then
                objAdvertencia.mensaje = "Seleccione una nave."
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
            Else
                If rdoActivos.Checked = True Then
                    If cmbNave.SelectedValue = 0 Then
                        LlenarTabla()
                        disenioGrid()
                    Else
                        activ = "SI"
                        LlenarTablaFiltradaNave(cmbNave.SelectedValue, activ)
                        disenioGrid()
                    End If

                ElseIf rdoNoActivos.Checked = True Then
                    If cmbNave.SelectedValue = 0 Then
                        LlenarTabla2()
                        disenioGrid2()
                    Else
                        activ = "NO"
                        LlenarTablaFiltradaNave(cmbNave.SelectedValue, activ)
                        disenioGrid()
                    End If

                ElseIf rdoTodos.Checked = True Then
                    If cmbNave.SelectedValue = 0 Then
                        LlenarTabla3()
                        disenioGrid3()
                    Else
                        LlenarTablaTodosFiltradaNaveNo(cmbNave.SelectedValue)
                        disenioGrid()
                    End If
                End If
            End If
        End If

        'If rdoActivos.Checked = True Then
        '    If cmbNave.SelectedValue = 0 Then
        '        LlenarTabla()
        '        disenioGrid()
        '    Else
        '        activ = "SI"
        '        LlenarTablaFiltradaNave(cmbNave.SelectedValue, activ)
        '        disenioGrid()
        '    End If

        'ElseIf rdoNoActivos.Checked = True Then
        '    If cmbNave.SelectedValue = 0 Then
        '        LlenarTabla2()
        '        disenioGrid2()
        '    Else
        '        activ = "NO"
        '        LlenarTablaFiltradaNave(cmbNave.SelectedValue, activ)
        '        disenioGrid()
        '    End If

        'ElseIf rdoTodos.Checked = True Then
        '    If cmbNave.SelectedValue = 0 Then
        '        LlenarTabla3()
        '        disenioGrid3()
        '    Else
        '        LlenarTablaTodosFiltradaNaveNo(cmbNave.SelectedValue)
        '        disenioGrid()
        '    End If
        'End If
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cmbNave.SelectedValue = 0
        rdoActivos.Checked = True
        grdListaProveedores.DataSource = Nothing
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim id As Integer

    '    id = grdListaProveedores.ActiveRow.Cells("ID").Text
    '    If id.ToString = "" Then

    '    Else
    '        Dim form As New AsociarProveedorConNave
    '        form.proveedorid = grdListaProveedores.ActiveRow.Cells("ID").Text
    '        form.ShowDialog()
    '    End If

    'End Sub

    'Private Sub cmbNave_TextChanged(sender As Object, e As EventArgs) Handles cmbNave.TextChanged
    '    actualizar()
    'End Sub

    Private Sub grbParametros_Enter(sender As Object, e As EventArgs) Handles grbParametros.Enter

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If grdListaProveedores.Rows.Count > 0 Then
            'tabla = grdListaProveedores.DataSource
            ExportarGridAExcel()
            actualizar()
            'grdListaProveedores.DataSource = tabla
            'disenioGrid3()
        End If
    End Sub

    Private Sub cmbNave_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        grdListaProveedores.DataSource = Nothing
    End Sub

    Private Sub btnEditarEncabezado_Click(sender As Object, e As EventArgs) Handles btnEditarEncabezado.Click
        If txtId.TextLength > 0 Then
            buscarRegistros()
            Dim form As New ModificarProveedoresForm()
            form.id = id
            form.proveedorid = proveedorid
            nombreComercial.Trim.Replace("  ", "")
            If nombreComercial.Contains("S.A. DE C.V.") Then
                form.nombreComercial = nombreComercial.Trim.Replace("S.A. DE C.V.", "")
                form.tipoRazon = 0
            ElseIf nombreComercial.Contains("S. DE R.L. DE C.V.") Then
                form.nombreComercial = nombreComercial.Trim.Replace("S. DE R.L. DE C.V.", "")
                form.tipoRazon = 1
            Else
                form.nombreComercial = nombreComercial
                form.tipoRazon = 2
            End If
            form.pais = pais
            form.categoria = catego
            form.giro = giro
            form.paginaweb = paginaweb
            form.limitedecredito = limitedecredito
            form.tiempoderespuesta = tiempoderespuesta
            form.tiempodeentrega = tiempodeentrega
            form.usuariomodifico = usuariomodifico
            form.fechamodifico = fechamodifico
            form.activo = act

            form.Size = New Drawing.Size(1060, 260)
            form.MaximumSize = New Drawing.Size(1060, 260)
            form.MinimumSize = New Drawing.Size(1060, 260)

            form.pnlDatosGenerales.Enabled = True
            form.btnGuardar.Enabled = True
            form.lblGuardarModificacion.Enabled = True

            If form.ShowDialog() = Windows.Forms.DialogResult.OK Then
            End If
        Else
            objAdvertencia.mensaje = " Seleccione un proveedor para poder editarlo"
            objAdvertencia.ShowDialog()
        End If
        actualizar()
    End Sub

    'Private Sub Button3_Click_2(sender As Object, e As EventArgs) Handles Button3.Click
    '    Dim form As New FechasDePAgoForm
    '    form.ShowDialog()
    'End Sub

    Private Sub grdListaProveedores_KeyDown(sender As Object, e As KeyEventArgs) Handles grdListaProveedores.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Enter Then
                grdListaProveedores.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdListaProveedores.DisplayLayout.Bands(0)
                If grdListaProveedores.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdListaProveedores.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdListaProveedores.ActiveCell = nextRow.Cells(grdListaProveedores.ActiveCell.Column)
                    e.Handled = True
                    'grdListaProveedores.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Up Then
                grdListaProveedores.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdListaProveedores.DisplayLayout.Bands(0)
                If grdListaProveedores.ActiveRow.HasPrevSibling(True) Then
                    Dim nextRow As UltraGridRow = grdListaProveedores.ActiveRow.GetSibling(SiblingRow.Previous, True)
                    grdListaProveedores.ActiveCell = nextRow.Cells(grdListaProveedores.ActiveCell.Column)
                    e.Handled = True
                    'grdListaProveedores.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Down Then
                grdListaProveedores.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdListaProveedores.DisplayLayout.Bands(0)
                If grdListaProveedores.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdListaProveedores.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdListaProveedores.ActiveCell = nextRow.Cells(grdListaProveedores.ActiveCell.Column)
                    e.Handled = True
                    'grdListaProveedores.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class