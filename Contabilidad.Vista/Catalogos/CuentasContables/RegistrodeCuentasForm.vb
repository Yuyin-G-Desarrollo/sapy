Imports Contabilidad.Negocios
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.Export
Imports System.Drawing
Imports Infragistics.Win.UltraWinGrid
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Repository

Public Class RegistrodeCuentasForm
    Dim objB As New CuentasContablesBU
    Dim tablaEmpresas As New DataTable
    Dim tablaTipoCuenta As New DataTable
    Dim tablaAlmacen As New DataTable

    Dim tablaConsEmp As New DataTable
    Dim mconid As Integer
    Dim mempcont As Integer
    Dim mempsicy As Integer
    Dim mconempresarelacionada As Integer
    Dim mconstatus As Integer
    Dim mconusuarioalta As String
    Dim mconfechaAlta As Date

    Dim tablaEmpresaCP As New DataTable
    Dim Id As Integer
    Dim RowVersion As String
    Dim nombre As String
    Dim RutaDatos As String
    Dim RutaResp As String
    Dim ArchivoUltimoResp As Date
    Dim AliasBDD As String
    Dim TimeStamp As String
    Dim HashSchema As Integer
    Dim ModulosIntegrados As String
    Dim VersionBDD As String

    'Var publicas
    Public idcuentaC As Integer
    Public idCodigCompac As String = String.Empty
    Public nombreCtaCompac As String = String.Empty

    'Var para insertar
    Dim IdCuenta As Integer
    Dim IdEmpresaSICY As Integer
    Dim IdEmpresaContpaq As Integer
    Dim IdTipoCuentas As Integer
    Dim ClaveSICY As Integer
    Dim ClaveCuenta As String
    Dim Cuenta As String
    Dim Descripcion As String
    Dim IdSegmentoNegocio As String
    Dim Estatus As String
    Dim UsuarioAlta As String
    Dim FechaAlta As DateTime
    Dim UsuarioActualizo As String
    Dim FechaActualizacion As DateTime
    Dim Concurrency As Integer
    Dim IdAlmacen As Integer
    Dim usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

    Private Sub RegistrodeCuentasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = Windows.Forms.FormWindowState.Maximized
        dtpFechaDel.Value = Now.ToShortDateString
        dtpFechaAl.Value = Today.ToShortDateString
        CargarEmpresas()
        CargarTipoCuenta()
        CargarAlmacen()
    End Sub

    Public Sub CargarEmpresas()
        tablaEmpresas = objB.EmpresasRegistrarCuentas
        tablaEmpresas.Rows.InsertAt(tablaEmpresas.NewRow, 0)
        cboEmpresa.DataSource = tablaEmpresas
        cboEmpresa.ValueMember = "IdDocumento"
        cboEmpresa.DisplayMember = "RazonSocialMarca"
    End Sub

    Private Sub cboEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEmpresa.SelectedIndexChanged
        Try
            If cboEmpresa.SelectedIndex > 0 Then
                ConsultarEmpresa()
            End If
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try

    End Sub

    Private Sub ConsultarEmpresa()
        Dim objB As New CuentasContablesBU
        tablaConsEmp = objB.ConsultaEmpresaSICY(cboEmpresa.SelectedValue)

        mconid = tablaConsEmp.Rows(0).Item("conid")
        mempcont = tablaConsEmp.Rows(0).Item("conid_empcont")
        mempsicy = tablaConsEmp.Rows(0).Item("conid_empsicy")
        mconempresarelacionada = tablaConsEmp.Rows(0).Item("conempresarelacionada")
        mconstatus = tablaConsEmp.Rows(0).Item("constatus")

        If mempcont > 0 Then
            tablaEmpresaCP = objB.ConsultarEmpresaCP(mempcont)

            Id = tablaEmpresaCP.Rows(0).Item("id")
            RowVersion = tablaEmpresaCP.Rows(0).Item("RowVersion")
            nombre = tablaEmpresaCP.Rows(0).Item("Nombre")
            RutaDatos = tablaEmpresaCP.Rows(0).Item("RutaDatos")
            RutaResp = tablaEmpresaCP.Rows(0).Item("RutaResp")
            'ArchivoUltimoResp = tablaEmpresaCP.Rows(0).Item("UltimoResp")
            AliasBDD = tablaEmpresaCP.Rows(0).Item("AliasBDD")
            'TimeStamp = tablaEmpresaCP.Rows(0).Item("TimeStamp")
            HashSchema = tablaEmpresaCP.Rows(0).Item("HashSchema")
            ModulosIntegrados = tablaEmpresaCP.Rows(0).Item("ModulosIntegrados")
            VersionBDD = tablaEmpresaCP.Rows(0).Item("VersionBDD")
        End If
    End Sub

    Public Sub CargarTipoCuenta()
        tablaTipoCuenta = objB.tiopoCuenta
        tablaTipoCuenta.Rows.InsertAt(tablaTipoCuenta.NewRow, 0)
        cboTipoCuenta.DataSource = tablaTipoCuenta
        cboTipoCuenta.ValueMember = "IdTipo"
        cboTipoCuenta.DisplayMember = "Descripcion"
    End Sub

    Public Sub CargarAlmacen()
        tablaAlmacen = objB.RegistrarCuentasAlmacen
        tablaAlmacen.Rows.InsertAt(tablaAlmacen.NewRow, 0)
        cboAlmacen.DataSource = tablaAlmacen
        cboAlmacen.ValueMember = "idcat"
        cboAlmacen.DisplayMember = "nomcat"
    End Sub

    Private Sub dtpFechaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDel.ValueChanged
        dtpFechaAl.MinDate = dtpFechaDel.Value
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New Tools.AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New Tools.AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New Tools.ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        'Dim tablaGenerales As New DataTable
        validar()
    End Sub

    Public Sub validar()
        Dim tabla As New DataTable
        Dim Estatus As Integer
        Dim Mostrar As Integer
        Dim Almacen As Integer
        Dim FechaDel As DateTime
        Dim FechaAl As DateTime
        Try
            grdDatos.DataSource = Nothing
            grdVDatos.Columns.Clear()
            If cboEmpresa.SelectedIndex > 0 Then
                If cboTipoCuenta.SelectedIndex > 0 Then

                    If rdoMTodos.Checked = True Then
                        Mostrar = 0
                    ElseIf rdoSinCuneta.Checked = True Then
                        Mostrar = 1
                    ElseIf rdoSoloconCuenta.Checked = True Then
                        Mostrar = 2
                    End If

                    If rdoETodos.Checked = True Then
                        Estatus = 0
                    ElseIf rdoActivos.Checked = True Then
                        Estatus = 1
                    ElseIf rdoInactivos.Checked = True Then
                        Estatus = 2
                    End If

                    If cboTipoCuenta.SelectedValue = 7 Then
                        FechaDel = dtpFechaDel.Value.ToShortDateString
                        FechaAl = dtpFechaAl.Value.ToShortDateString
                        If cboAlmacen.SelectedIndex > 0 Then
                            Almacen = cboAlmacen.SelectedValue
                            tabla = objB.ConsultaRegistrarCuentasMateriales(cboEmpresa.SelectedValue, cboTipoCuenta.SelectedValue, Mostrar, Estatus, Almacen) ', FechaDel, FechaAl
                            grdDatos.DataSource = tabla
                            diseñoGridMateriales()
                            AplicarReglasFormatoGrid(grdVDatos)

                        Else
                            show_message("Advertencia", "Seleccione el almacén")
                        End If
                    Else
                        tabla = objB.ConsultaRegistrarCuentas(cboEmpresa.SelectedValue, cboTipoCuenta.SelectedValue, Mostrar, Estatus)
                        grdDatos.DataSource = tabla
                        If cboTipoCuenta.SelectedValue = 6 Or cboTipoCuenta.SelectedValue = 8 Then
                            diseñoGridProvAcreed()
                            AplicarReglasFormatoGrid(grdVDatos)
                        Else
                            diseñoGrid()
                            AplicarReglasFormatoGrid(grdVDatos)
                        End If
                    End If


                Else
                    show_message("Advertencia", "Seleccione tipo de cuenta")
                End If
            Else
                show_message("Advertencia", "Seleccione la Empresa")
            End If
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try

    End Sub

    Private Sub cboTipoCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoCuenta.SelectedIndexChanged
        If cboTipoCuenta.Text = "Materiales" Then
            'panelFecha.Visible = True
            lblAlmacen.Visible = True
            cboAlmacen.Visible = True
        Else
            'panelFecha.Visible = False
            lblAlmacen.Visible = False
            cboAlmacen.Visible = False
        End If
    End Sub

    Public Sub diseñoGrid()
        grdVDatos.IndicatorWidth = 40

        grdVDatos.Columns("BOTON").Visible = False
        grdVDatos.Columns("MENSAJE").Visible = False

        grdVDatos.Columns("ST").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("CUENTA").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("DESCRIPCION").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("BOTON").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("IDSEGMENTONEGOCIO").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("IDCLIENTE").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("NOMBRE").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("RFC").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("ESTATUS").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("IDCADENA").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("CLAVECUENTA").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("CONCURRENCY").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("IDCUENTA").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("AFECTADO").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("MENSAJE").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("IdAlmacen").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("FechaAlta").OptionsColumn.AllowEdit = False

        grdVDatos.Columns("ST").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("CUENTA").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("DESCRIPCION").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("BOTON").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("IDSEGMENTONEGOCIO").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("IDCLIENTE").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("NOMBRE").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("RFC").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("ESTATUS").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("IDCADENA").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("CLAVECUENTA").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("CONCURRENCY").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("IDCUENTA").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("AFECTADO").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("MENSAJE").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("IdAlmacen").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("FechaAlta").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        grdVDatos.Columns("ST").Width = 5
        grdVDatos.Columns("CUENTA").Width = 50
        grdVDatos.Columns("DESCRIPCION").Width = 80
        grdVDatos.Columns("BOTON").Width = 5
        grdVDatos.Columns("IDSEGMENTONEGOCIO").Width = 20
        grdVDatos.Columns("IDCLIENTE").Width = 20
        grdVDatos.Columns("NOMBRE").Width = 80
        grdVDatos.Columns("RFC").Width = 30
        grdVDatos.Columns("ESTATUS").Width = 20
        grdVDatos.Columns("IDCADENA").Width = 30
        grdVDatos.Columns("CLAVECUENTA").Width = 30
        grdVDatos.Columns("CONCURRENCY").Width = 30
        grdVDatos.Columns("IDCUENTA").Width = 10
        grdVDatos.Columns("AFECTADO").Width = 10
        grdVDatos.Columns("MENSAJE").Width = 10
        grdVDatos.Columns("IdAlmacen").Width = 10
        grdVDatos.Columns("FechaAlta").Width = 10

        grdVDatos.Columns("ST").Caption = "NO."
        grdVDatos.Columns("CUENTA").Caption = "No.Cuenta"
        grdVDatos.Columns("DESCRIPCION").Caption = "Nombre"
        grdVDatos.Columns("BOTON").Caption = " "
        grdVDatos.Columns("IDSEGMENTONEGOCIO").Caption = "Segmento"
        grdVDatos.Columns("IDCLIENTE").Caption = "Código"
        grdVDatos.Columns("NOMBRE").Caption = "Nombre/Descipción"
        grdVDatos.Columns("RFC").Caption = "R.F.C."
        grdVDatos.Columns("ESTATUS").Caption = "Estatus"
        grdVDatos.Columns("IDCADENA").Caption = "IdCadena"
        grdVDatos.Columns("CLAVECUENTA").Caption = "IdCuentaContpaq"
        grdVDatos.Columns("CONCURRENCY").Caption = "Concurrencia"
        grdVDatos.Columns("IDCUENTA").Caption = "Id"
        grdVDatos.Columns("AFECTADO").Caption = "Modificado"
        grdVDatos.Columns("MENSAJE").Caption = " "
        grdVDatos.Columns("IdAlmacen").Caption = "IdAlmacen"
        grdVDatos.Columns("FechaAlta").Caption = "FechaAlta"

        grdVDatos.Columns.ColumnByFieldName("ST").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("CUENTA").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("DESCRIPCION").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("BOTON").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("IDSEGMENTONEGOCIO").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("IDCLIENTE").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("NOMBRE").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("RFC").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("ESTATUS").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("IDCADENA").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("CLAVECUENTA").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("CONCURRENCY").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("IDCUENTA").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("AFECTADO").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("MENSAJE").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("IdAlmacen").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("FechaAlta").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        grdVDatos.OptionsView.EnableAppearanceEvenRow = True
        grdVDatos.OptionsView.EnableAppearanceOddRow = True
        grdVDatos.OptionsSelection.EnableAppearanceFocusedCell = True
        grdVDatos.OptionsSelection.EnableAppearanceFocusedRow = True
        grdVDatos.Appearance.SelectedRow.Options.UseBackColor = True

        'grdVDatos.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

        grdVDatos.Appearance.EvenRow.BackColor = Color.White
        grdVDatos.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        grdVDatos.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 100, 200)
        grdVDatos.Appearance.FocusedRow.ForeColor = Color.White

    End Sub

    Public Sub diseñoGridProvAcreed()
        grdVDatos.IndicatorWidth = 40

        grdVDatos.Columns("BOTON").Visible = False
        grdVDatos.Columns("MENSAJE").Visible = False

        grdVDatos.Columns("ST").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("CUENTA").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("DESCRIPCION").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("BOTON").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("IDSEGMENTONEGOCIO").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("IDPROVEEDOR").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("NOMBRE").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("RFC").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("ESTATUS").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("IDCADENA").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("CLAVECUENTA").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("CONCURRENCY").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("IDCUENTA").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("AFECTADO").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("MENSAJE").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("IdAlmacen").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("FechaAlta").OptionsColumn.AllowEdit = False

        grdVDatos.Columns("ST").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("CUENTA").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("DESCRIPCION").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("BOTON").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("IDSEGMENTONEGOCIO").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("IDPROVEEDOR").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("NOMBRE").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("RFC").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("ESTATUS").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("IDCADENA").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("CLAVECUENTA").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("CONCURRENCY").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("IDCUENTA").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("AFECTADO").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("MENSAJE").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("IdAlmacen").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("FechaAlta").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        grdVDatos.Columns("ST").Width = 5
        grdVDatos.Columns("CUENTA").Width = 50
        grdVDatos.Columns("DESCRIPCION").Width = 80
        grdVDatos.Columns("BOTON").Width = 5
        grdVDatos.Columns("IDSEGMENTONEGOCIO").Width = 20
        grdVDatos.Columns("IDPROVEEDOR").Width = 20
        grdVDatos.Columns("NOMBRE").Width = 80
        grdVDatos.Columns("RFC").Width = 30
        grdVDatos.Columns("ESTATUS").Width = 20
        grdVDatos.Columns("IDCADENA").Width = 30
        grdVDatos.Columns("CLAVECUENTA").Width = 30
        grdVDatos.Columns("CONCURRENCY").Width = 30
        grdVDatos.Columns("IDCUENTA").Width = 10
        grdVDatos.Columns("AFECTADO").Width = 10
        grdVDatos.Columns("MENSAJE").Width = 10
        grdVDatos.Columns("IdAlmacen").Width = 10
        grdVDatos.Columns("FechaAlta").Width = 10

        grdVDatos.Columns("ST").Caption = "NO."
        grdVDatos.Columns("CUENTA").Caption = "No.Cuenta"
        grdVDatos.Columns("DESCRIPCION").Caption = "Nombre"
        grdVDatos.Columns("BOTON").Caption = " "
        grdVDatos.Columns("IDSEGMENTONEGOCIO").Caption = "Segmento"
        grdVDatos.Columns("IDPROVEEDOR").Caption = "Código"
        grdVDatos.Columns("NOMBRE").Caption = "Nombre/Descipción"
        grdVDatos.Columns("RFC").Caption = "R.F.C."
        grdVDatos.Columns("ESTATUS").Caption = "Estatus"
        grdVDatos.Columns("IDCADENA").Caption = "IdCadena"
        grdVDatos.Columns("CLAVECUENTA").Caption = "IdCuentaContpaq"
        grdVDatos.Columns("CONCURRENCY").Caption = "Concurrencia"
        grdVDatos.Columns("IDCUENTA").Caption = "Id"
        grdVDatos.Columns("AFECTADO").Caption = "Modificado"
        grdVDatos.Columns("MENSAJE").Caption = " "
        grdVDatos.Columns("IdAlmacen").Caption = "IdAlmacen"
        grdVDatos.Columns("FechaAlta").Caption = "FechaAlta"

        grdVDatos.Columns.ColumnByFieldName("ST").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("CUENTA").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("DESCRIPCION").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("BOTON").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("IDSEGMENTONEGOCIO").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("IDPROVEEDOR").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("NOMBRE").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("RFC").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("ESTATUS").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("IDCADENA").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("CLAVECUENTA").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("CONCURRENCY").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("IDCUENTA").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("AFECTADO").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("MENSAJE").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("IdAlmacen").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("FechaAlta").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        grdVDatos.OptionsView.EnableAppearanceEvenRow = True
        grdVDatos.OptionsView.EnableAppearanceOddRow = True
        grdVDatos.OptionsSelection.EnableAppearanceFocusedCell = True
        grdVDatos.OptionsSelection.EnableAppearanceFocusedRow = True
        grdVDatos.Appearance.SelectedRow.Options.UseBackColor = True

        'grdVDatos.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

        grdVDatos.Appearance.EvenRow.BackColor = Color.White
        grdVDatos.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        grdVDatos.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVDatos.Appearance.FocusedRow.ForeColor = Color.White

    End Sub

    Public Sub diseñoGridMateriales()
        grdVDatos.IndicatorWidth = 40

        grdVDatos.Columns("BOTON").Visible = False
        grdVDatos.Columns("MENSAJE").Visible = False

        grdVDatos.Columns("ST").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("CUENTA").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("DESCRIPCION").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("BOTON").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("IDSEGMENTONEGOCIO").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("IDMATERIAL").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("NOMBRE").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("RFC").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("ESTATUS").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("IDCADENA").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("CLAVECUENTA").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("CONCURRENCY").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("IDCUENTA").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("AFECTADO").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("MENSAJE").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("IdAlmacen").OptionsColumn.AllowEdit = False
        grdVDatos.Columns("FechaAlta").OptionsColumn.AllowEdit = False

        grdVDatos.Columns("ST").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("CUENTA").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("DESCRIPCION").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("BOTON").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("IDSEGMENTONEGOCIO").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("IDMATERIAL").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("NOMBRE").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("RFC").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("ESTATUS").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("IDCADENA").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("CLAVECUENTA").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("CONCURRENCY").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("IDCUENTA").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("AFECTADO").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("MENSAJE").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("IdAlmacen").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVDatos.Columns("FechaAlta").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        grdVDatos.Columns("ST").Width = 5
        grdVDatos.Columns("CUENTA").Width = 50
        grdVDatos.Columns("DESCRIPCION").Width = 80
        grdVDatos.Columns("BOTON").Width = 5
        grdVDatos.Columns("IDSEGMENTONEGOCIO").Width = 20
        grdVDatos.Columns("IDMATERIAL").Width = 20
        grdVDatos.Columns("NOMBRE").Width = 80
        grdVDatos.Columns("RFC").Width = 30
        grdVDatos.Columns("ESTATUS").Width = 20
        grdVDatos.Columns("IDCADENA").Width = 30
        grdVDatos.Columns("CLAVECUENTA").Width = 30
        grdVDatos.Columns("CONCURRENCY").Width = 30
        grdVDatos.Columns("IDCUENTA").Width = 10
        grdVDatos.Columns("AFECTADO").Width = 10
        grdVDatos.Columns("MENSAJE").Width = 10
        grdVDatos.Columns("IdAlmacen").Width = 10
        grdVDatos.Columns("FechaAlta").Width = 10

        grdVDatos.Columns("ST").Caption = "NO."
        grdVDatos.Columns("CUENTA").Caption = "No.Cuenta"
        grdVDatos.Columns("DESCRIPCION").Caption = "Nombre"
        grdVDatos.Columns("BOTON").Caption = " "
        grdVDatos.Columns("IDSEGMENTONEGOCIO").Caption = "Segmento"
        grdVDatos.Columns("IDMATERIAL").Caption = "Código"
        grdVDatos.Columns("NOMBRE").Caption = "Nombre/Descipción"
        grdVDatos.Columns("RFC").Caption = "R.F.C."
        grdVDatos.Columns("ESTATUS").Caption = "Estatus"
        grdVDatos.Columns("IDCADENA").Caption = "IdCadena"
        grdVDatos.Columns("CLAVECUENTA").Caption = "IdCuentaContpaq"
        grdVDatos.Columns("CONCURRENCY").Caption = "Concurrencia"
        grdVDatos.Columns("IDCUENTA").Caption = "Id"
        grdVDatos.Columns("AFECTADO").Caption = "Modificado"
        grdVDatos.Columns("MENSAJE").Caption = " "
        grdVDatos.Columns("IdAlmacen").Caption = "IdAlmacen"
        grdVDatos.Columns("FechaAlta").Caption = "FechaAlta"

        grdVDatos.Columns.ColumnByFieldName("ST").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("CUENTA").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("DESCRIPCION").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("BOTON").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("IDSEGMENTONEGOCIO").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("IDMATERIAL").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("NOMBRE").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("RFC").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("ESTATUS").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("IDCADENA").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("CLAVECUENTA").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("CONCURRENCY").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("IDCUENTA").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("AFECTADO").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("MENSAJE").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("IdAlmacen").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVDatos.Columns.ColumnByFieldName("FechaAlta").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        grdVDatos.OptionsView.EnableAppearanceEvenRow = True
        grdVDatos.OptionsView.EnableAppearanceOddRow = True
        grdVDatos.OptionsSelection.EnableAppearanceFocusedCell = True
        grdVDatos.OptionsSelection.EnableAppearanceFocusedRow = True
        grdVDatos.Appearance.SelectedRow.Options.UseBackColor = True

        'grdVDatos.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)
        'grdVDatos.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

        grdVDatos.Appearance.EvenRow.BackColor = Color.White
        grdVDatos.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        grdVDatos.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVDatos.Appearance.FocusedRow.ForeColor = Color.White
    End Sub



    Private Sub grdVDatos_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdVDatos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub



    Private Sub grdVDatos_RowClick(sender As Object, e As Views.Grid.RowClickEventArgs) Handles grdVDatos.RowClick
        Dim form As New CuentasContpaqForm
        If cboTipoCuenta.SelectedValue = 1 Or cboTipoCuenta.SelectedValue = 5 Then
            Exit Sub
        Else
            If e.Clicks = 2 Then
                form.BD = AliasBDD
                form.ShowDialog()

                If form.idCodigo Is Nothing Then
                    Exit Sub
                Else
                    Me.idcuentaC = form.idCuenta
                    Me.idCodigCompac = form.idCodigo
                    Me.nombreCtaCompac = form.nombreCuentas
                    grdVDatos.SetFocusedRowCellValue("CUENTA", form.idCodigo)
                    grdVDatos.SetFocusedRowCellValue("DESCRIPCION", form.nombreCuentas)
                    grdVDatos.SetFocusedRowCellValue("CLAVECUENTA", form.idCuenta)
                    grdVDatos.SetFocusedRowCellValue("AFECTADO", 1)
                    btnGuardar.Enabled = True
                    lblGuardar.Enabled = True
                End If
                formatosCuenta()
                AplicarReglasFormatoGrid(grdVDatos)
            End If
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim filename As String

        Try
            If grdVDatos.RowCount > 0 Then
                'Ask the user where to save the file to
                Dim SaveFileDialog As New SaveFileDialog()
                SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
                SaveFileDialog.FilterIndex = 2
                SaveFileDialog.RestoreDirectory = True
                If SaveFileDialog.ShowDialog() = DialogResult.OK Then

                    'This is required so that excel doesn't make all the grids very small. This will export all grids space out evenly
                    grdVDatos.OptionsPrint.AutoWidth = True
                    grdVDatos.OptionsPrint.EnableAppearanceEvenRow = True
                    grdVDatos.OptionsPrint.PrintPreview = True
                    'Set the selected file as the filename
                    filename = SaveFileDialog.FileName

                    Dim exportOptions = New XlsxExportOptionsEx()
                    'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                    'Export the file via inbuild function
                    DevExpress.Export.ExportSettings.DefaultExportType = ExportType.Default
                    grdVDatos.ExportToXlsx(filename, exportOptions)

                    'If the file exists (i.e. export worked), then open it
                    If System.IO.File.Exists(filename) Then
                        Dim DialogResult As DialogResult = MessageBox.Show("El archivo ha sido exportado a " & filename & vbNewLine & "¿Quieres abrirlo ahora?", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If DialogResult = Windows.Forms.DialogResult.Yes Then
                            System.Diagnostics.Process.Start(filename)
                        End If
                    End If
                End If
            Else
                show_message("Aviso", "No existen registros para exportar")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub formatosCuenta()
        Dim textEdit = New RepositoryItemTextEdit()
        textEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        textEdit.Mask.EditMask = "\w\w\w-\w\w\w\w-\w\w\w\w"
        textEdit.Mask.UseMaskAsDisplayFormat = True

        grdDatos.RepositoryItems.Add(textEdit)
        grdVDatos.Columns("CUENTA").ColumnEdit = textEdit
    End Sub

    Private Sub AplicarReglasFormatoGrid(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim gridFormatRule As DevExpress.XtraGrid.GridFormatRule
        Dim formatConditionRuleExpression As DevExpress.XtraEditors.FormatConditionRuleExpression

        'Con cuenta Color Violeta
        gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        gridFormatRule.Column = Grid.Columns.ColumnByFieldName("ST")
        gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("ST")

        formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        formatConditionRuleExpression.Expression = "IsNull([CUENTA]) = False"
        formatConditionRuleExpression.Appearance.BackColor = pnlColorSiExiste.BackColor

        gridFormatRule.Rule = formatConditionRuleExpression
        Grid.FormatRules.Add(gridFormatRule)

        'Con cuenta Color Coral
        gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        gridFormatRule.Column = Grid.Columns.ColumnByFieldName("ST")
        gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("ST")

        formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        formatConditionRuleExpression.Expression = "IsNull([CUENTA])"
        formatConditionRuleExpression.Appearance.BackColor = pnlColorNoExiste.BackColor

        gridFormatRule.Rule = formatConditionRuleExpression
        Grid.FormatRules.Add(gridFormatRule)

        'Con cuenta Color Verde
        gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        gridFormatRule.Column = Grid.Columns.ColumnByFieldName("ST")
        gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("ST")

        formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        formatConditionRuleExpression.Expression = "[AFECTADO] = 1"
        formatConditionRuleExpression.Appearance.BackColor = pnlColorCambios.BackColor

        gridFormatRule.Rule = formatConditionRuleExpression
        Grid.FormatRules.Add(gridFormatRule)

    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objN As New CuentasContablesBU
        Dim numeroFilas As Integer
        Dim Accion As Integer
        Dim idTabla As Integer
        Try
            If cboEmpresa.SelectedIndex > 0 Then
                If cboTipoCuenta.SelectedIndex > 0 Then
                    numeroFilas = grdVDatos.DataRowCount
                    For index As Integer = 0 To numeroFilas Step 1
                        If grdVDatos.GetRowCellValue(index, "AFECTADO") = 1 Then
                            If grdVDatos.GetRowCellValue(index, "CUENTA").ToString <> Nothing Then
                                IdEmpresaSICY = cboEmpresa.SelectedValue
                                IdEmpresaContpaq = mempcont
                                IdTipoCuentas = cboTipoCuenta.SelectedValue

                                If cboTipoCuenta.SelectedValue = 7 Then
                                    ClaveSICY = grdVDatos.GetRowCellValue(index, "IDMATERIAL")
                                ElseIf cboTipoCuenta.SelectedValue = 6 Or cboTipoCuenta.SelectedValue = 8 Then
                                    ClaveSICY = grdVDatos.GetRowCellValue(index, "IDPROVEEDOR")
                                Else
                                    ClaveSICY = grdVDatos.GetRowCellValue(index, "IDCLIENTE")
                                End If

                                ClaveCuenta = idcuentaC
                                Cuenta = grdVDatos.GetRowCellDisplayText(index, "CUENTA")
                                Descripcion = grdVDatos.GetRowCellValue(index, "DESCRIPCION")

                                If grdVDatos.GetRowCellValue(index, "IDSEGMENTONEGOCIO").ToString = Nothing Then
                                    IdSegmentoNegocio = ""
                                Else
                                    IdSegmentoNegocio = grdVDatos.GetRowCellValue(index, "IDSEGMENTONEGOCIO")
                                End If

                                Estatus = "A"
                                UsuarioAlta = usuario
                                UsuarioActualizo = usuario
                                Concurrency = grdVDatos.GetRowCellValue(index, "CONCURRENCY")
                                IdAlmacen = grdVDatos.GetRowCellValue(index, "IdAlmacen")

                                If grdVDatos.GetRowCellValue(index, "IDCUENTA") = 0 Then
                                    Accion = 1
                                    idTabla = grdVDatos.GetRowCellValue(index, "IDCUENTA")
                                    objN.InsertarRegistrarCuentas(IdEmpresaSICY, IdEmpresaContpaq, IdTipoCuentas, ClaveSICY, ClaveCuenta, Cuenta, Descripcion, IdSegmentoNegocio, Estatus, UsuarioAlta, UsuarioActualizo, Concurrency, IdAlmacen, Accion, idTabla)
                                Else
                                    Accion = 2
                                    idTabla = grdVDatos.GetRowCellValue(index, "IDCUENTA")
                                    objN.InsertarRegistrarCuentas(IdEmpresaSICY, IdEmpresaContpaq, IdTipoCuentas, ClaveSICY, ClaveCuenta, Cuenta, Descripcion, IdSegmentoNegocio, Estatus, UsuarioAlta, UsuarioActualizo, Concurrency, IdAlmacen, Accion, idTabla)
                                End If
                            Else
                                show_message("Advertencia", "Los Datos de la Cuenta se encuentra incompletos, por favor verifiquelo")
                            End If
                        End If
                    Next
                End If
            End If
            validar()
            formatosCuenta()
            AplicarReglasFormatoGrid(grdVDatos)
            show_message("Exito", "Se han guardado los cambios correctamente")
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cboEmpresa.SelectedValue = 0
        cboEmpresa.SelectedText = ""
        cboTipoCuenta.SelectedValue = 0
        cboTipoCuenta.SelectedText = ""
        rdoETodos.Checked = True
        rdoMTodos.Checked = True
        cboAlmacen.SelectedValue = 0
        cboAlmacen.SelectedText = ""
        grdDatos.DataSource = Nothing
        grdVDatos.Columns.Clear()

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()

    End Sub
End Class