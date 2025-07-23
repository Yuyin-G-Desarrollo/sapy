<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaSucursal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaSucursal))
        Me.pnlBanner = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.tbcSucursal = New System.Windows.Forms.TabControl()
        Me.tbpDatosSucursal = New System.Windows.Forms.TabPage()
        Me.ddlReporteRemision = New System.Windows.Forms.ComboBox()
        Me.lblReporteRemision = New System.Windows.Forms.Label()
        Me.chkRemisiona = New System.Windows.Forms.CheckBox()
        Me.txtColonia = New System.Windows.Forms.TextBox()
        Me.lblColonia = New System.Windows.Forms.Label()
        Me.chkFacturaProductos = New System.Windows.Forms.CheckBox()
        Me.rdbActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdbActivoSi = New System.Windows.Forms.RadioButton()
        Me.cmbCiudad = New System.Windows.Forms.ComboBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.txtCp = New System.Windows.Forms.TextBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.lblCiudad = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.lblCp = New System.Windows.Forms.Label()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.lblCalle = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.btnExaminarImagen = New System.Windows.Forms.Button()
        Me.lblLogo = New System.Windows.Forms.Label()
        Me.ptbLogo = New System.Windows.Forms.PictureBox()
        Me.tbpFacturacion = New System.Windows.Forms.TabPage()
        Me.cmbReporteCancelacion = New System.Windows.Forms.ComboBox()
        Me.lblReporteCancelacion = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdEmpresas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgregarEmpresa = New System.Windows.Forms.Button()
        Me.lblAgregar = New System.Windows.Forms.Label()
        Me.chkImprimeDomicilio = New System.Windows.Forms.CheckBox()
        Me.txtFolioFin = New System.Windows.Forms.TextBox()
        Me.txtFolioActual = New System.Windows.Forms.TextBox()
        Me.rdbFActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdbFActivoSi = New System.Windows.Forms.RadioButton()
        Me.cmbReporteFacturacion = New System.Windows.Forms.ComboBox()
        Me.txtFolioInicio = New System.Windows.Forms.TextBox()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.cmbEmpresas = New System.Windows.Forms.ComboBox()
        Me.lblFolioFin = New System.Windows.Forms.Label()
        Me.lblFolioActual = New System.Windows.Forms.Label()
        Me.lblFActivo = New System.Windows.Forms.Label()
        Me.lblReporteFactura = New System.Windows.Forms.Label()
        Me.lblFolioInicio = New System.Windows.Forms.Label()
        Me.lblSerie = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.tbpUsuarios = New System.Windows.Forms.TabPage()
        Me.btnQuitaAsignado = New System.Windows.Forms.Button()
        Me.btnPasaAsignado = New System.Windows.Forms.Button()
        Me.grdUsuariosAsignados = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grdUsuariosNoAsignados = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.opfArchivoImg = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlBanner.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tbcSucursal.SuspendLayout()
        Me.tbpDatosSucursal.SuspendLayout()
        CType(Me.ptbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpFacturacion.SuspendLayout()
        CType(Me.grdEmpresas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpUsuarios.SuspendLayout()
        CType(Me.grdUsuariosAsignados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdUsuariosNoAsignados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBanner
        '
        Me.pnlBanner.BackColor = System.Drawing.Color.White
        Me.pnlBanner.Controls.Add(Me.pnlTitulo)
        Me.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBanner.Location = New System.Drawing.Point(0, 0)
        Me.pnlBanner.Name = "pnlBanner"
        Me.pnlBanner.Size = New System.Drawing.Size(729, 68)
        Me.pnlBanner.TabIndex = 59
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(388, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(341, 68)
        Me.pnlTitulo.TabIndex = 5
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(169, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(98, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Sucursales"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 455)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(729, 62)
        Me.Panel1.TabIndex = 60
        '
        'lblGuardar
        '
        Me.lblGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(617, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 47
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Image = Global.Facturacion.Vista.My.Resources.Resources.guardar2_321
        Me.btnGuardar.Location = New System.Drawing.Point(623, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 46
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(684, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 45
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Image = Global.Facturacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(685, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 44
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'tbcSucursal
        '
        Me.tbcSucursal.Controls.Add(Me.tbpDatosSucursal)
        Me.tbcSucursal.Controls.Add(Me.tbpFacturacion)
        Me.tbcSucursal.Controls.Add(Me.tbpUsuarios)
        Me.tbcSucursal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcSucursal.Location = New System.Drawing.Point(0, 68)
        Me.tbcSucursal.Name = "tbcSucursal"
        Me.tbcSucursal.SelectedIndex = 0
        Me.tbcSucursal.Size = New System.Drawing.Size(729, 387)
        Me.tbcSucursal.TabIndex = 61
        '
        'tbpDatosSucursal
        '
        Me.tbpDatosSucursal.BackColor = System.Drawing.Color.AliceBlue
        Me.tbpDatosSucursal.Controls.Add(Me.ddlReporteRemision)
        Me.tbpDatosSucursal.Controls.Add(Me.lblReporteRemision)
        Me.tbpDatosSucursal.Controls.Add(Me.chkRemisiona)
        Me.tbpDatosSucursal.Controls.Add(Me.txtColonia)
        Me.tbpDatosSucursal.Controls.Add(Me.lblColonia)
        Me.tbpDatosSucursal.Controls.Add(Me.chkFacturaProductos)
        Me.tbpDatosSucursal.Controls.Add(Me.rdbActivoNo)
        Me.tbpDatosSucursal.Controls.Add(Me.rdbActivoSi)
        Me.tbpDatosSucursal.Controls.Add(Me.cmbCiudad)
        Me.tbpDatosSucursal.Controls.Add(Me.cmbEstado)
        Me.tbpDatosSucursal.Controls.Add(Me.txtCp)
        Me.tbpDatosSucursal.Controls.Add(Me.txtNumero)
        Me.tbpDatosSucursal.Controls.Add(Me.txtCalle)
        Me.tbpDatosSucursal.Controls.Add(Me.txtNombre)
        Me.tbpDatosSucursal.Controls.Add(Me.lblActivo)
        Me.tbpDatosSucursal.Controls.Add(Me.lblCiudad)
        Me.tbpDatosSucursal.Controls.Add(Me.lblEstado)
        Me.tbpDatosSucursal.Controls.Add(Me.lblCp)
        Me.tbpDatosSucursal.Controls.Add(Me.lblNumero)
        Me.tbpDatosSucursal.Controls.Add(Me.lblCalle)
        Me.tbpDatosSucursal.Controls.Add(Me.lblNombre)
        Me.tbpDatosSucursal.Controls.Add(Me.btnExaminarImagen)
        Me.tbpDatosSucursal.Controls.Add(Me.lblLogo)
        Me.tbpDatosSucursal.Controls.Add(Me.ptbLogo)
        Me.tbpDatosSucursal.Location = New System.Drawing.Point(4, 22)
        Me.tbpDatosSucursal.Name = "tbpDatosSucursal"
        Me.tbpDatosSucursal.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDatosSucursal.Size = New System.Drawing.Size(721, 361)
        Me.tbpDatosSucursal.TabIndex = 0
        Me.tbpDatosSucursal.Text = "Datos Sucursal"
        '
        'ddlReporteRemision
        '
        Me.ddlReporteRemision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlReporteRemision.Enabled = False
        Me.ddlReporteRemision.FormattingEnabled = True
        Me.ddlReporteRemision.Location = New System.Drawing.Point(274, 285)
        Me.ddlReporteRemision.Name = "ddlReporteRemision"
        Me.ddlReporteRemision.Size = New System.Drawing.Size(243, 21)
        Me.ddlReporteRemision.TabIndex = 44
        '
        'lblReporteRemision
        '
        Me.lblReporteRemision.Location = New System.Drawing.Point(174, 285)
        Me.lblReporteRemision.Name = "lblReporteRemision"
        Me.lblReporteRemision.Size = New System.Drawing.Size(94, 18)
        Me.lblReporteRemision.TabIndex = 43
        Me.lblReporteRemision.Text = "Reporte Remisón"
        Me.lblReporteRemision.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkRemisiona
        '
        Me.chkRemisiona.AutoSize = True
        Me.chkRemisiona.Location = New System.Drawing.Point(405, 262)
        Me.chkRemisiona.Name = "chkRemisiona"
        Me.chkRemisiona.Size = New System.Drawing.Size(75, 17)
        Me.chkRemisiona.TabIndex = 42
        Me.chkRemisiona.Text = "Remisiona"
        Me.chkRemisiona.UseVisualStyleBackColor = True
        '
        'txtColonia
        '
        Me.txtColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColonia.Location = New System.Drawing.Point(274, 126)
        Me.txtColonia.Name = "txtColonia"
        Me.txtColonia.Size = New System.Drawing.Size(377, 20)
        Me.txtColonia.TabIndex = 28
        '
        'lblColonia
        '
        Me.lblColonia.Location = New System.Drawing.Point(213, 129)
        Me.lblColonia.Name = "lblColonia"
        Me.lblColonia.Size = New System.Drawing.Size(55, 13)
        Me.lblColonia.TabIndex = 41
        Me.lblColonia.Text = "* Colonia"
        Me.lblColonia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkFacturaProductos
        '
        Me.chkFacturaProductos.AutoSize = True
        Me.chkFacturaProductos.Location = New System.Drawing.Point(274, 262)
        Me.chkFacturaProductos.Name = "chkFacturaProductos"
        Me.chkFacturaProductos.Size = New System.Drawing.Size(112, 17)
        Me.chkFacturaProductos.TabIndex = 32
        Me.chkFacturaProductos.Text = "Factura productos"
        Me.chkFacturaProductos.UseVisualStyleBackColor = True
        '
        'rdbActivoNo
        '
        Me.rdbActivoNo.AutoSize = True
        Me.rdbActivoNo.Location = New System.Drawing.Point(332, 322)
        Me.rdbActivoNo.Name = "rdbActivoNo"
        Me.rdbActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdbActivoNo.TabIndex = 33
        Me.rdbActivoNo.Text = "No"
        Me.rdbActivoNo.UseVisualStyleBackColor = True
        '
        'rdbActivoSi
        '
        Me.rdbActivoSi.AutoSize = True
        Me.rdbActivoSi.Checked = True
        Me.rdbActivoSi.Location = New System.Drawing.Point(273, 322)
        Me.rdbActivoSi.Name = "rdbActivoSi"
        Me.rdbActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdbActivoSi.TabIndex = 32
        Me.rdbActivoSi.TabStop = True
        Me.rdbActivoSi.Text = "Si"
        Me.rdbActivoSi.UseVisualStyleBackColor = True
        '
        'cmbCiudad
        '
        Me.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCiudad.Enabled = False
        Me.cmbCiudad.FormattingEnabled = True
        Me.cmbCiudad.Location = New System.Drawing.Point(274, 227)
        Me.cmbCiudad.Name = "cmbCiudad"
        Me.cmbCiudad.Size = New System.Drawing.Size(243, 21)
        Me.cmbCiudad.TabIndex = 31
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(274, 192)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(243, 21)
        Me.cmbEstado.TabIndex = 30
        '
        'txtCp
        '
        Me.txtCp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCp.Location = New System.Drawing.Point(274, 158)
        Me.txtCp.Name = "txtCp"
        Me.txtCp.Size = New System.Drawing.Size(158, 20)
        Me.txtCp.TabIndex = 29
        '
        'txtNumero
        '
        Me.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumero.Location = New System.Drawing.Point(274, 94)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(158, 20)
        Me.txtNumero.TabIndex = 27
        '
        'txtCalle
        '
        Me.txtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCalle.Location = New System.Drawing.Point(274, 59)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(377, 20)
        Me.txtCalle.TabIndex = 26
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(274, 25)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(377, 20)
        Me.txtNombre.TabIndex = 25
        '
        'lblActivo
        '
        Me.lblActivo.Location = New System.Drawing.Point(212, 324)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(55, 13)
        Me.lblActivo.TabIndex = 24
        Me.lblActivo.Text = "Activo"
        Me.lblActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCiudad
        '
        Me.lblCiudad.Location = New System.Drawing.Point(213, 230)
        Me.lblCiudad.Name = "lblCiudad"
        Me.lblCiudad.Size = New System.Drawing.Size(55, 13)
        Me.lblCiudad.TabIndex = 23
        Me.lblCiudad.Text = "* Ciudad"
        Me.lblCiudad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEstado
        '
        Me.lblEstado.Location = New System.Drawing.Point(213, 195)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(55, 13)
        Me.lblEstado.TabIndex = 22
        Me.lblEstado.Text = "* Estado"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCp
        '
        Me.lblCp.Location = New System.Drawing.Point(213, 161)
        Me.lblCp.Name = "lblCp"
        Me.lblCp.Size = New System.Drawing.Size(55, 13)
        Me.lblCp.TabIndex = 21
        Me.lblCp.Text = "* CP"
        Me.lblCp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumero
        '
        Me.lblNumero.Location = New System.Drawing.Point(213, 97)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(55, 13)
        Me.lblNumero.TabIndex = 20
        Me.lblNumero.Text = "* Número"
        Me.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCalle
        '
        Me.lblCalle.Location = New System.Drawing.Point(213, 62)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(55, 13)
        Me.lblCalle.TabIndex = 19
        Me.lblCalle.Text = "* Calle"
        Me.lblCalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNombre
        '
        Me.lblNombre.Location = New System.Drawing.Point(213, 28)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(55, 13)
        Me.lblNombre.TabIndex = 18
        Me.lblNombre.Text = "* Nombre"
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnExaminarImagen
        '
        Me.btnExaminarImagen.Location = New System.Drawing.Point(80, 113)
        Me.btnExaminarImagen.Name = "btnExaminarImagen"
        Me.btnExaminarImagen.Size = New System.Drawing.Size(75, 23)
        Me.btnExaminarImagen.TabIndex = 34
        Me.btnExaminarImagen.Text = "Examinar..."
        Me.btnExaminarImagen.UseVisualStyleBackColor = True
        '
        'lblLogo
        '
        Me.lblLogo.AutoSize = True
        Me.lblLogo.Location = New System.Drawing.Point(36, 118)
        Me.lblLogo.Name = "lblLogo"
        Me.lblLogo.Size = New System.Drawing.Size(31, 13)
        Me.lblLogo.TabIndex = 16
        Me.lblLogo.Text = "Logo"
        '
        'ptbLogo
        '
        Me.ptbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ptbLogo.ErrorImage = Global.Facturacion.Vista.My.Resources.Resources.Cabecera_Credencial
        Me.ptbLogo.InitialImage = Global.Facturacion.Vista.My.Resources.Resources.Cabecera_Credencial
        Me.ptbLogo.Location = New System.Drawing.Point(39, 25)
        Me.ptbLogo.Name = "ptbLogo"
        Me.ptbLogo.Size = New System.Drawing.Size(140, 80)
        Me.ptbLogo.TabIndex = 15
        Me.ptbLogo.TabStop = False
        '
        'tbpFacturacion
        '
        Me.tbpFacturacion.BackColor = System.Drawing.Color.AliceBlue
        Me.tbpFacturacion.Controls.Add(Me.cmbReporteCancelacion)
        Me.tbpFacturacion.Controls.Add(Me.lblReporteCancelacion)
        Me.tbpFacturacion.Controls.Add(Me.btnLimpiar)
        Me.tbpFacturacion.Controls.Add(Me.Label1)
        Me.tbpFacturacion.Controls.Add(Me.grdEmpresas)
        Me.tbpFacturacion.Controls.Add(Me.btnAgregarEmpresa)
        Me.tbpFacturacion.Controls.Add(Me.lblAgregar)
        Me.tbpFacturacion.Controls.Add(Me.chkImprimeDomicilio)
        Me.tbpFacturacion.Controls.Add(Me.txtFolioFin)
        Me.tbpFacturacion.Controls.Add(Me.txtFolioActual)
        Me.tbpFacturacion.Controls.Add(Me.rdbFActivoNo)
        Me.tbpFacturacion.Controls.Add(Me.rdbFActivoSi)
        Me.tbpFacturacion.Controls.Add(Me.cmbReporteFacturacion)
        Me.tbpFacturacion.Controls.Add(Me.txtFolioInicio)
        Me.tbpFacturacion.Controls.Add(Me.txtSerie)
        Me.tbpFacturacion.Controls.Add(Me.cmbEmpresas)
        Me.tbpFacturacion.Controls.Add(Me.lblFolioFin)
        Me.tbpFacturacion.Controls.Add(Me.lblFolioActual)
        Me.tbpFacturacion.Controls.Add(Me.lblFActivo)
        Me.tbpFacturacion.Controls.Add(Me.lblReporteFactura)
        Me.tbpFacturacion.Controls.Add(Me.lblFolioInicio)
        Me.tbpFacturacion.Controls.Add(Me.lblSerie)
        Me.tbpFacturacion.Controls.Add(Me.lblEmpresa)
        Me.tbpFacturacion.Location = New System.Drawing.Point(4, 22)
        Me.tbpFacturacion.Name = "tbpFacturacion"
        Me.tbpFacturacion.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpFacturacion.Size = New System.Drawing.Size(721, 361)
        Me.tbpFacturacion.TabIndex = 1
        Me.tbpFacturacion.Text = "Facturación"
        '
        'cmbReporteCancelacion
        '
        Me.cmbReporteCancelacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReporteCancelacion.Enabled = False
        Me.cmbReporteCancelacion.FormattingEnabled = True
        Me.cmbReporteCancelacion.Location = New System.Drawing.Point(146, 130)
        Me.cmbReporteCancelacion.Name = "cmbReporteCancelacion"
        Me.cmbReporteCancelacion.Size = New System.Drawing.Size(238, 21)
        Me.cmbReporteCancelacion.TabIndex = 70
        '
        'lblReporteCancelacion
        '
        Me.lblReporteCancelacion.Location = New System.Drawing.Point(30, 133)
        Me.lblReporteCancelacion.Name = "lblReporteCancelacion"
        Me.lblReporteCancelacion.Size = New System.Drawing.Size(110, 13)
        Me.lblReporteCancelacion.TabIndex = 69
        Me.lblReporteCancelacion.Text = "Reporte Cancelacion"
        Me.lblReporteCancelacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Facturacion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(650, 87)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 67
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(647, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Limpiar"
        '
        'grdEmpresas
        '
        Me.grdEmpresas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance1.FontData.Name = "Microsoft Sans Serif"
        Appearance1.FontData.SizeInPoints = 7.0!
        Appearance1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grdEmpresas.DisplayLayout.Appearance = Appearance1
        Me.grdEmpresas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.grdEmpresas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdEmpresas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdEmpresas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.grdEmpresas.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.grdEmpresas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdEmpresas.Location = New System.Drawing.Point(33, 169)
        Me.grdEmpresas.Name = "grdEmpresas"
        Me.grdEmpresas.Size = New System.Drawing.Size(656, 171)
        Me.grdEmpresas.TabIndex = 66
        '
        'btnAgregarEmpresa
        '
        Me.btnAgregarEmpresa.Image = Global.Facturacion.Vista.My.Resources.Resources.nuevo_32
        Me.btnAgregarEmpresa.Location = New System.Drawing.Point(650, 24)
        Me.btnAgregarEmpresa.Name = "btnAgregarEmpresa"
        Me.btnAgregarEmpresa.Size = New System.Drawing.Size(32, 32)
        Me.btnAgregarEmpresa.TabIndex = 62
        Me.btnAgregarEmpresa.UseVisualStyleBackColor = True
        '
        'lblAgregar
        '
        Me.lblAgregar.AutoSize = True
        Me.lblAgregar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAgregar.Location = New System.Drawing.Point(645, 58)
        Me.lblAgregar.Name = "lblAgregar"
        Me.lblAgregar.Size = New System.Drawing.Size(44, 13)
        Me.lblAgregar.TabIndex = 63
        Me.lblAgregar.Text = "Agregar"
        '
        'chkImprimeDomicilio
        '
        Me.chkImprimeDomicilio.AutoSize = True
        Me.chkImprimeDomicilio.Location = New System.Drawing.Point(400, 132)
        Me.chkImprimeDomicilio.Name = "chkImprimeDomicilio"
        Me.chkImprimeDomicilio.Size = New System.Drawing.Size(234, 17)
        Me.chkImprimeDomicilio.TabIndex = 38
        Me.chkImprimeDomicilio.Text = "Imprimir domicilio de la sucursal en la factura"
        Me.chkImprimeDomicilio.UseVisualStyleBackColor = True
        '
        'txtFolioFin
        '
        Me.txtFolioFin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFolioFin.Location = New System.Drawing.Point(491, 77)
        Me.txtFolioFin.Name = "txtFolioFin"
        Me.txtFolioFin.Size = New System.Drawing.Size(143, 20)
        Me.txtFolioFin.TabIndex = 37
        '
        'txtFolioActual
        '
        Me.txtFolioActual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFolioActual.Enabled = False
        Me.txtFolioActual.Location = New System.Drawing.Point(491, 51)
        Me.txtFolioActual.Name = "txtFolioActual"
        Me.txtFolioActual.Size = New System.Drawing.Size(143, 20)
        Me.txtFolioActual.TabIndex = 36
        '
        'rdbFActivoNo
        '
        Me.rdbFActivoNo.AutoSize = True
        Me.rdbFActivoNo.Location = New System.Drawing.Point(541, 104)
        Me.rdbFActivoNo.Name = "rdbFActivoNo"
        Me.rdbFActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdbFActivoNo.TabIndex = 35
        Me.rdbFActivoNo.TabStop = True
        Me.rdbFActivoNo.Text = "No"
        Me.rdbFActivoNo.UseVisualStyleBackColor = True
        '
        'rdbFActivoSi
        '
        Me.rdbFActivoSi.AutoSize = True
        Me.rdbFActivoSi.Checked = True
        Me.rdbFActivoSi.Location = New System.Drawing.Point(491, 104)
        Me.rdbFActivoSi.Name = "rdbFActivoSi"
        Me.rdbFActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdbFActivoSi.TabIndex = 34
        Me.rdbFActivoSi.TabStop = True
        Me.rdbFActivoSi.Text = "Si"
        Me.rdbFActivoSi.UseVisualStyleBackColor = True
        '
        'cmbReporteFacturacion
        '
        Me.cmbReporteFacturacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReporteFacturacion.FormattingEnabled = True
        Me.cmbReporteFacturacion.Location = New System.Drawing.Point(146, 103)
        Me.cmbReporteFacturacion.Name = "cmbReporteFacturacion"
        Me.cmbReporteFacturacion.Size = New System.Drawing.Size(238, 21)
        Me.cmbReporteFacturacion.TabIndex = 33
        '
        'txtFolioInicio
        '
        Me.txtFolioInicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFolioInicio.Location = New System.Drawing.Point(146, 77)
        Me.txtFolioInicio.Name = "txtFolioInicio"
        Me.txtFolioInicio.Size = New System.Drawing.Size(144, 20)
        Me.txtFolioInicio.TabIndex = 32
        '
        'txtSerie
        '
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Location = New System.Drawing.Point(146, 51)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(143, 20)
        Me.txtSerie.TabIndex = 31
        '
        'cmbEmpresas
        '
        Me.cmbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresas.FormattingEnabled = True
        Me.cmbEmpresas.Location = New System.Drawing.Point(146, 24)
        Me.cmbEmpresas.Name = "cmbEmpresas"
        Me.cmbEmpresas.Size = New System.Drawing.Size(488, 21)
        Me.cmbEmpresas.TabIndex = 30
        '
        'lblFolioFin
        '
        Me.lblFolioFin.Location = New System.Drawing.Point(395, 80)
        Me.lblFolioFin.Name = "lblFolioFin"
        Me.lblFolioFin.Size = New System.Drawing.Size(90, 13)
        Me.lblFolioFin.TabIndex = 25
        Me.lblFolioFin.Text = "* Folio fin"
        Me.lblFolioFin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFolioActual
        '
        Me.lblFolioActual.Location = New System.Drawing.Point(395, 54)
        Me.lblFolioActual.Name = "lblFolioActual"
        Me.lblFolioActual.Size = New System.Drawing.Size(90, 13)
        Me.lblFolioActual.TabIndex = 24
        Me.lblFolioActual.Text = "* Folio actual"
        Me.lblFolioActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFActivo
        '
        Me.lblFActivo.Location = New System.Drawing.Point(395, 106)
        Me.lblFActivo.Name = "lblFActivo"
        Me.lblFActivo.Size = New System.Drawing.Size(90, 13)
        Me.lblFActivo.TabIndex = 23
        Me.lblFActivo.Text = "Activo"
        Me.lblFActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblReporteFactura
        '
        Me.lblReporteFactura.Location = New System.Drawing.Point(30, 106)
        Me.lblReporteFactura.Name = "lblReporteFactura"
        Me.lblReporteFactura.Size = New System.Drawing.Size(110, 13)
        Me.lblReporteFactura.TabIndex = 22
        Me.lblReporteFactura.Text = "Reporte Factura"
        Me.lblReporteFactura.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFolioInicio
        '
        Me.lblFolioInicio.Location = New System.Drawing.Point(30, 80)
        Me.lblFolioInicio.Name = "lblFolioInicio"
        Me.lblFolioInicio.Size = New System.Drawing.Size(110, 13)
        Me.lblFolioInicio.TabIndex = 21
        Me.lblFolioInicio.Text = "* Folio inicio"
        Me.lblFolioInicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSerie
        '
        Me.lblSerie.Location = New System.Drawing.Point(30, 54)
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Size = New System.Drawing.Size(110, 13)
        Me.lblSerie.TabIndex = 20
        Me.lblSerie.Text = "* Serie"
        Me.lblSerie.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Location = New System.Drawing.Point(30, 27)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(110, 13)
        Me.lblEmpresa.TabIndex = 19
        Me.lblEmpresa.Text = "* Empresa"
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbpUsuarios
        '
        Me.tbpUsuarios.BackColor = System.Drawing.Color.AliceBlue
        Me.tbpUsuarios.Controls.Add(Me.btnQuitaAsignado)
        Me.tbpUsuarios.Controls.Add(Me.btnPasaAsignado)
        Me.tbpUsuarios.Controls.Add(Me.grdUsuariosAsignados)
        Me.tbpUsuarios.Controls.Add(Me.grdUsuariosNoAsignados)
        Me.tbpUsuarios.Controls.Add(Me.Label3)
        Me.tbpUsuarios.Controls.Add(Me.Label2)
        Me.tbpUsuarios.Location = New System.Drawing.Point(4, 22)
        Me.tbpUsuarios.Name = "tbpUsuarios"
        Me.tbpUsuarios.Size = New System.Drawing.Size(721, 361)
        Me.tbpUsuarios.TabIndex = 2
        Me.tbpUsuarios.Text = "Usuarios"
        '
        'btnQuitaAsignado
        '
        Me.btnQuitaAsignado.Location = New System.Drawing.Point(327, 169)
        Me.btnQuitaAsignado.Name = "btnQuitaAsignado"
        Me.btnQuitaAsignado.Size = New System.Drawing.Size(67, 23)
        Me.btnQuitaAsignado.TabIndex = 70
        Me.btnQuitaAsignado.Text = "<"
        Me.btnQuitaAsignado.UseVisualStyleBackColor = True
        '
        'btnPasaAsignado
        '
        Me.btnPasaAsignado.Location = New System.Drawing.Point(328, 120)
        Me.btnPasaAsignado.Name = "btnPasaAsignado"
        Me.btnPasaAsignado.Size = New System.Drawing.Size(67, 23)
        Me.btnPasaAsignado.TabIndex = 69
        Me.btnPasaAsignado.Text = ">"
        Me.btnPasaAsignado.UseVisualStyleBackColor = True
        '
        'grdUsuariosAsignados
        '
        Me.grdUsuariosAsignados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance2.FontData.Name = "Microsoft Sans Serif"
        Appearance2.FontData.SizeInPoints = 7.0!
        Appearance2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grdUsuariosAsignados.DisplayLayout.Appearance = Appearance2
        Me.grdUsuariosAsignados.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.grdUsuariosAsignados.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdUsuariosAsignados.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdUsuariosAsignados.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.grdUsuariosAsignados.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.grdUsuariosAsignados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdUsuariosAsignados.Location = New System.Drawing.Point(414, 47)
        Me.grdUsuariosAsignados.Name = "grdUsuariosAsignados"
        Me.grdUsuariosAsignados.Size = New System.Drawing.Size(280, 296)
        Me.grdUsuariosAsignados.TabIndex = 68
        '
        'grdUsuariosNoAsignados
        '
        Me.grdUsuariosNoAsignados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance3.FontData.Name = "Microsoft Sans Serif"
        Appearance3.FontData.SizeInPoints = 7.0!
        Appearance3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grdUsuariosNoAsignados.DisplayLayout.Appearance = Appearance3
        Me.grdUsuariosNoAsignados.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grdUsuariosNoAsignados.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.grdUsuariosNoAsignados.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdUsuariosNoAsignados.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdUsuariosNoAsignados.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.grdUsuariosNoAsignados.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdUsuariosNoAsignados.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdUsuariosNoAsignados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdUsuariosNoAsignados.Location = New System.Drawing.Point(29, 47)
        Me.grdUsuariosNoAsignados.Name = "grdUsuariosNoAsignados"
        Me.grdUsuariosNoAsignados.Size = New System.Drawing.Size(280, 296)
        Me.grdUsuariosNoAsignados.TabIndex = 67
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(501, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Usuarios asignados"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(96, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Usuarios no asignados"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(273, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 68)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 44
        Me.PictureBox1.TabStop = False
        '
        'AltaSucursal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(729, 517)
        Me.Controls.Add(Me.tbcSucursal)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlBanner)
        Me.Name = "AltaSucursal"
        Me.Text = "Sucursales"
        Me.pnlBanner.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tbcSucursal.ResumeLayout(False)
        Me.tbpDatosSucursal.ResumeLayout(False)
        Me.tbpDatosSucursal.PerformLayout()
        CType(Me.ptbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpFacturacion.ResumeLayout(False)
        Me.tbpFacturacion.PerformLayout()
        CType(Me.grdEmpresas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpUsuarios.ResumeLayout(False)
        Me.tbpUsuarios.PerformLayout()
        CType(Me.grdUsuariosAsignados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdUsuariosNoAsignados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBanner As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents tbcSucursal As System.Windows.Forms.TabControl
    Friend WithEvents tbpDatosSucursal As System.Windows.Forms.TabPage
    Friend WithEvents tbpFacturacion As System.Windows.Forms.TabPage
    Friend WithEvents tbpUsuarios As System.Windows.Forms.TabPage
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnExaminarImagen As System.Windows.Forms.Button
    Friend WithEvents lblLogo As System.Windows.Forms.Label
    Friend WithEvents ptbLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents lblCiudad As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents lblCp As System.Windows.Forms.Label
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents opfArchivoImg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents rdbActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents cmbCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents txtCp As System.Windows.Forms.TextBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblFolioFin As System.Windows.Forms.Label
    Friend WithEvents lblFolioActual As System.Windows.Forms.Label
    Friend WithEvents lblFActivo As System.Windows.Forms.Label
    Friend WithEvents lblReporteFactura As System.Windows.Forms.Label
    Friend WithEvents lblFolioInicio As System.Windows.Forms.Label
    Friend WithEvents lblSerie As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents chkImprimeDomicilio As System.Windows.Forms.CheckBox
    Friend WithEvents txtFolioFin As System.Windows.Forms.TextBox
    Friend WithEvents txtFolioActual As System.Windows.Forms.TextBox
    Friend WithEvents rdbFActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbFActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents cmbReporteFacturacion As System.Windows.Forms.ComboBox
    Friend WithEvents txtFolioInicio As System.Windows.Forms.TextBox
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents cmbEmpresas As System.Windows.Forms.ComboBox
    Friend WithEvents btnAgregarEmpresa As System.Windows.Forms.Button
    Friend WithEvents lblAgregar As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnQuitaAsignado As System.Windows.Forms.Button
    Friend WithEvents btnPasaAsignado As System.Windows.Forms.Button
    Friend WithEvents grdUsuariosAsignados As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdUsuariosNoAsignados As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdEmpresas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents chkFacturaProductos As System.Windows.Forms.CheckBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtColonia As System.Windows.Forms.TextBox
    Friend WithEvents lblColonia As System.Windows.Forms.Label
    Friend WithEvents cmbReporteCancelacion As System.Windows.Forms.ComboBox
    Friend WithEvents lblReporteCancelacion As System.Windows.Forms.Label
    Friend WithEvents ddlReporteRemision As System.Windows.Forms.ComboBox
    Friend WithEvents lblReporteRemision As System.Windows.Forms.Label
    Friend WithEvents chkRemisiona As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
