<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaEmpresa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaEmpresa))
        Me.pnlBanner = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.txtCurp = New System.Windows.Forms.TextBox()
        Me.lblCurp = New System.Windows.Forms.Label()
        Me.txtCP = New System.Windows.Forms.TextBox()
        Me.lblCp = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.txtRegimen = New System.Windows.Forms.TextBox()
        Me.lblRegimen = New System.Windows.Forms.Label()
        Me.chkActiva = New System.Windows.Forms.CheckBox()
        Me.btnExaminarImagen = New System.Windows.Forms.Button()
        Me.cmbCiudad = New System.Windows.Forms.ComboBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.txtRFC = New System.Windows.Forms.TextBox()
        Me.txtColonia = New System.Windows.Forms.TextBox()
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.lblCiudad = New System.Windows.Forms.Label()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.lblColonia = New System.Windows.Forms.Label()
        Me.lblCalle = New System.Windows.Forms.Label()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.lblLogo = New System.Windows.Forms.Label()
        Me.ptbLogo = New System.Windows.Forms.PictureBox()
        Me.dtpVigenciaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpVigenciaInicio = New System.Windows.Forms.DateTimePicker()
        Me.txtContrasenaCertificado = New System.Windows.Forms.TextBox()
        Me.txtUsuarioWS = New System.Windows.Forms.TextBox()
        Me.txtNoCertificado = New System.Windows.Forms.TextBox()
        Me.lblContrasenaCertificado = New System.Windows.Forms.Label()
        Me.lblUsuarioWS = New System.Windows.Forms.Label()
        Me.lblVigenciaFin = New System.Windows.Forms.Label()
        Me.lblVigenciaInicio = New System.Windows.Forms.Label()
        Me.lblNoCertificado = New System.Windows.Forms.Label()
        Me.btnExaminarKey = New System.Windows.Forms.Button()
        Me.btnExaminarCer = New System.Windows.Forms.Button()
        Me.txtFolioFinal = New System.Windows.Forms.TextBox()
        Me.txtFolioActual = New System.Windows.Forms.TextBox()
        Me.txtFolioInicio = New System.Windows.Forms.TextBox()
        Me.txtRutaWS = New System.Windows.Forms.TextBox()
        Me.txtRutaKey = New System.Windows.Forms.TextBox()
        Me.txtRutaCertificado = New System.Windows.Forms.TextBox()
        Me.lblFolioFinal = New System.Windows.Forms.Label()
        Me.lblFolioActual = New System.Windows.Forms.Label()
        Me.lblFolioInicio = New System.Windows.Forms.Label()
        Me.lblRutaWS = New System.Windows.Forms.Label()
        Me.lblRutaKey = New System.Windows.Forms.Label()
        Me.lblRutaCertificado = New System.Windows.Forms.Label()
        Me.cmbFCReporteCancelacion = New System.Windows.Forms.ComboBox()
        Me.lblFCReporteCancelacion = New System.Windows.Forms.Label()
        Me.cmbFCReporteFactura = New System.Windows.Forms.ComboBox()
        Me.txtFCFolioActual = New System.Windows.Forms.TextBox()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.txtMaxRenglones = New System.Windows.Forms.TextBox()
        Me.txtFCRutaXML = New System.Windows.Forms.TextBox()
        Me.txtFCRutaPDF = New System.Windows.Forms.TextBox()
        Me.lblFCReporteFactura = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblSerie = New System.Windows.Forms.Label()
        Me.lblMaxRenglones = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbFPReporteCancelacion = New System.Windows.Forms.ComboBox()
        Me.lblFPReporteCancelacion = New System.Windows.Forms.Label()
        Me.cmbFPReporteFactura = New System.Windows.Forms.ComboBox()
        Me.txtFPRutaXML = New System.Windows.Forms.TextBox()
        Me.txtFPRutaPDF = New System.Windows.Forms.TextBox()
        Me.lblFPReporteFactura = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.opfArchivoImg = New System.Windows.Forms.OpenFileDialog()
        Me.opfArchivoCer = New System.Windows.Forms.OpenFileDialog()
        Me.opfArchivoKey = New System.Windows.Forms.OpenFileDialog()
        Me.tbcEmpresas = New System.Windows.Forms.TabControl()
        Me.tbpGeneral = New System.Windows.Forms.TabPage()
        Me.pnlGeneral = New System.Windows.Forms.Panel()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.chkArrendamiento = New System.Windows.Forms.CheckBox()
        Me.txtClaveRegimen = New System.Windows.Forms.TextBox()
        Me.lblClaveRegimen = New System.Windows.Forms.Label()
        Me.tbpFacturaGeneral = New System.Windows.Forms.TabPage()
        Me.pnlFacturaGeneral = New System.Windows.Forms.Panel()
        Me.txtIdentificadorWS = New System.Windows.Forms.TextBox()
        Me.lblIdentificadorWS = New System.Windows.Forms.Label()
        Me.txtContrasenaWS = New System.Windows.Forms.TextBox()
        Me.lblContrasenaWS = New System.Windows.Forms.Label()
        Me.tbpFacturacionCalzado = New System.Windows.Forms.TabPage()
        Me.pnlFacturacionCalzado = New System.Windows.Forms.Panel()
        Me.tbpFacturacionProductos = New System.Windows.Forms.TabPage()
        Me.pnlFacturacionProductos = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlBanner.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.ptbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcEmpresas.SuspendLayout()
        Me.tbpGeneral.SuspendLayout()
        Me.pnlGeneral.SuspendLayout()
        Me.tbpFacturaGeneral.SuspendLayout()
        Me.pnlFacturaGeneral.SuspendLayout()
        Me.tbpFacturacionCalzado.SuspendLayout()
        Me.pnlFacturacionCalzado.SuspendLayout()
        Me.tbpFacturacionProductos.SuspendLayout()
        Me.pnlFacturacionProductos.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        Me.pnlBanner.Size = New System.Drawing.Size(1037, 60)
        Me.pnlBanner.TabIndex = 58
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(758, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(279, 60)
        Me.pnlTitulo.TabIndex = 5
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(3, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(196, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Configuración Empresa"
        '
        'txtCurp
        '
        Me.txtCurp.AccessibleName = ""
        Me.txtCurp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCurp.Location = New System.Drawing.Point(781, 115)
        Me.txtCurp.Name = "txtCurp"
        Me.txtCurp.Size = New System.Drawing.Size(217, 20)
        Me.txtCurp.TabIndex = 10
        '
        'lblCurp
        '
        Me.lblCurp.AutoSize = True
        Me.lblCurp.Location = New System.Drawing.Point(731, 118)
        Me.lblCurp.Name = "lblCurp"
        Me.lblCurp.Size = New System.Drawing.Size(44, 13)
        Me.lblCurp.TabIndex = 21
        Me.lblCurp.Text = "* CURP"
        '
        'txtCP
        '
        Me.txtCP.AccessibleName = ""
        Me.txtCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCP.Location = New System.Drawing.Point(215, 110)
        Me.txtCP.Name = "txtCP"
        Me.txtCP.Size = New System.Drawing.Size(390, 20)
        Me.txtCP.TabIndex = 4
        '
        'lblCp
        '
        Me.lblCp.Location = New System.Drawing.Point(132, 113)
        Me.lblCp.Name = "lblCp"
        Me.lblCp.Size = New System.Drawing.Size(77, 13)
        Me.lblCp.TabIndex = 20
        Me.lblCp.Text = "* CP"
        Me.lblCp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbEstado
        '
        Me.cmbEstado.AccessibleName = ""
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(781, 64)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(217, 21)
        Me.cmbEstado.TabIndex = 8
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(728, 67)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(47, 13)
        Me.lblEstado.TabIndex = 18
        Me.lblEstado.Text = "* Estado"
        '
        'txtRegimen
        '
        Me.txtRegimen.AccessibleName = ""
        Me.txtRegimen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRegimen.Location = New System.Drawing.Point(215, 135)
        Me.txtRegimen.Name = "txtRegimen"
        Me.txtRegimen.Size = New System.Drawing.Size(390, 20)
        Me.txtRegimen.TabIndex = 5
        '
        'lblRegimen
        '
        Me.lblRegimen.Location = New System.Drawing.Point(132, 138)
        Me.lblRegimen.Name = "lblRegimen"
        Me.lblRegimen.Size = New System.Drawing.Size(77, 13)
        Me.lblRegimen.TabIndex = 16
        Me.lblRegimen.Text = "* Regimen"
        Me.lblRegimen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkActiva
        '
        Me.chkActiva.AutoSize = True
        Me.chkActiva.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActiva.Checked = True
        Me.chkActiva.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActiva.Location = New System.Drawing.Point(343, 163)
        Me.chkActiva.Name = "chkActiva"
        Me.chkActiva.Size = New System.Drawing.Size(56, 17)
        Me.chkActiva.TabIndex = 11
        Me.chkActiva.Text = "Activa"
        Me.chkActiva.UseVisualStyleBackColor = True
        '
        'btnExaminarImagen
        '
        Me.btnExaminarImagen.Location = New System.Drawing.Point(51, 71)
        Me.btnExaminarImagen.Name = "btnExaminarImagen"
        Me.btnExaminarImagen.Size = New System.Drawing.Size(75, 23)
        Me.btnExaminarImagen.TabIndex = 12
        Me.btnExaminarImagen.Text = "Examinar..."
        Me.btnExaminarImagen.UseVisualStyleBackColor = True
        '
        'cmbCiudad
        '
        Me.cmbCiudad.AccessibleName = ""
        Me.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCiudad.Enabled = False
        Me.cmbCiudad.FormattingEnabled = True
        Me.cmbCiudad.ItemHeight = 13
        Me.cmbCiudad.Location = New System.Drawing.Point(781, 91)
        Me.cmbCiudad.Name = "cmbCiudad"
        Me.cmbCiudad.Size = New System.Drawing.Size(217, 21)
        Me.cmbCiudad.TabIndex = 9
        '
        'txtNumero
        '
        Me.txtNumero.AccessibleName = ""
        Me.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumero.Location = New System.Drawing.Point(781, 38)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(217, 20)
        Me.txtNumero.TabIndex = 7
        '
        'txtRFC
        '
        Me.txtRFC.AccessibleName = ""
        Me.txtRFC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRFC.Location = New System.Drawing.Point(781, 12)
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(217, 20)
        Me.txtRFC.TabIndex = 6
        '
        'txtColonia
        '
        Me.txtColonia.AccessibleName = ""
        Me.txtColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColonia.Location = New System.Drawing.Point(215, 84)
        Me.txtColonia.Name = "txtColonia"
        Me.txtColonia.Size = New System.Drawing.Size(390, 20)
        Me.txtColonia.TabIndex = 3
        '
        'txtCalle
        '
        Me.txtCalle.AccessibleName = ""
        Me.txtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCalle.Location = New System.Drawing.Point(215, 58)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(390, 20)
        Me.txtCalle.TabIndex = 2
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.AccessibleName = ""
        Me.txtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazonSocial.Location = New System.Drawing.Point(215, 7)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(476, 20)
        Me.txtRazonSocial.TabIndex = 1
        '
        'lblCiudad
        '
        Me.lblCiudad.AutoSize = True
        Me.lblCiudad.Location = New System.Drawing.Point(728, 94)
        Me.lblCiudad.Name = "lblCiudad"
        Me.lblCiudad.Size = New System.Drawing.Size(47, 13)
        Me.lblCiudad.TabIndex = 7
        Me.lblCiudad.Text = "* Ciudad"
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.Location = New System.Drawing.Point(724, 41)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(51, 13)
        Me.lblNumero.TabIndex = 6
        Me.lblNumero.Text = "* Número"
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.Location = New System.Drawing.Point(740, 15)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(35, 13)
        Me.lblRFC.TabIndex = 5
        Me.lblRFC.Text = "* RFC"
        '
        'lblColonia
        '
        Me.lblColonia.Location = New System.Drawing.Point(132, 87)
        Me.lblColonia.Name = "lblColonia"
        Me.lblColonia.Size = New System.Drawing.Size(77, 13)
        Me.lblColonia.TabIndex = 4
        Me.lblColonia.Text = "* Colonia"
        Me.lblColonia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCalle
        '
        Me.lblCalle.Location = New System.Drawing.Point(132, 61)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(77, 13)
        Me.lblCalle.TabIndex = 3
        Me.lblCalle.Text = "* Calle"
        Me.lblCalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Location = New System.Drawing.Point(132, 10)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(77, 13)
        Me.lblRazonSocial.TabIndex = 2
        Me.lblRazonSocial.Text = "* Razón Social"
        Me.lblRazonSocial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLogo
        '
        Me.lblLogo.AutoSize = True
        Me.lblLogo.Location = New System.Drawing.Point(7, 76)
        Me.lblLogo.Name = "lblLogo"
        Me.lblLogo.Size = New System.Drawing.Size(31, 13)
        Me.lblLogo.TabIndex = 1
        Me.lblLogo.Text = "Logo"
        '
        'ptbLogo
        '
        Me.ptbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ptbLogo.ErrorImage = Global.Facturacion.Vista.My.Resources.Resources.Cabecera_Credencial
        Me.ptbLogo.InitialImage = Global.Facturacion.Vista.My.Resources.Resources.Cabecera_Credencial
        Me.ptbLogo.Location = New System.Drawing.Point(7, 15)
        Me.ptbLogo.Name = "ptbLogo"
        Me.ptbLogo.Size = New System.Drawing.Size(119, 51)
        Me.ptbLogo.TabIndex = 0
        Me.ptbLogo.TabStop = False
        '
        'dtpVigenciaFin
        '
        Me.dtpVigenciaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVigenciaFin.Location = New System.Drawing.Point(777, 56)
        Me.dtpVigenciaFin.Name = "dtpVigenciaFin"
        Me.dtpVigenciaFin.Size = New System.Drawing.Size(170, 20)
        Me.dtpVigenciaFin.TabIndex = 21
        '
        'dtpVigenciaInicio
        '
        Me.dtpVigenciaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVigenciaInicio.Location = New System.Drawing.Point(777, 30)
        Me.dtpVigenciaInicio.Name = "dtpVigenciaInicio"
        Me.dtpVigenciaInicio.Size = New System.Drawing.Size(170, 20)
        Me.dtpVigenciaInicio.TabIndex = 20
        '
        'txtContrasenaCertificado
        '
        Me.txtContrasenaCertificado.Location = New System.Drawing.Point(142, 83)
        Me.txtContrasenaCertificado.Name = "txtContrasenaCertificado"
        Me.txtContrasenaCertificado.Size = New System.Drawing.Size(217, 20)
        Me.txtContrasenaCertificado.TabIndex = 16
        '
        'txtUsuarioWS
        '
        Me.txtUsuarioWS.Location = New System.Drawing.Point(142, 109)
        Me.txtUsuarioWS.Name = "txtUsuarioWS"
        Me.txtUsuarioWS.Size = New System.Drawing.Size(217, 20)
        Me.txtUsuarioWS.TabIndex = 17
        '
        'txtNoCertificado
        '
        Me.txtNoCertificado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoCertificado.Location = New System.Drawing.Point(777, 5)
        Me.txtNoCertificado.Name = "txtNoCertificado"
        Me.txtNoCertificado.Size = New System.Drawing.Size(217, 20)
        Me.txtNoCertificado.TabIndex = 19
        '
        'lblContrasenaCertificado
        '
        Me.lblContrasenaCertificado.Location = New System.Drawing.Point(6, 86)
        Me.lblContrasenaCertificado.Name = "lblContrasenaCertificado"
        Me.lblContrasenaCertificado.Size = New System.Drawing.Size(130, 13)
        Me.lblContrasenaCertificado.TabIndex = 21
        Me.lblContrasenaCertificado.Text = "* Contraseña Certificado"
        Me.lblContrasenaCertificado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUsuarioWS
        '
        Me.lblUsuarioWS.Location = New System.Drawing.Point(6, 112)
        Me.lblUsuarioWS.Name = "lblUsuarioWS"
        Me.lblUsuarioWS.Size = New System.Drawing.Size(130, 13)
        Me.lblUsuarioWS.TabIndex = 20
        Me.lblUsuarioWS.Text = "* Usuario WS"
        Me.lblUsuarioWS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVigenciaFin
        '
        Me.lblVigenciaFin.Location = New System.Drawing.Point(671, 62)
        Me.lblVigenciaFin.Name = "lblVigenciaFin"
        Me.lblVigenciaFin.Size = New System.Drawing.Size(100, 13)
        Me.lblVigenciaFin.TabIndex = 19
        Me.lblVigenciaFin.Text = "Vigencia Fin"
        Me.lblVigenciaFin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVigenciaInicio
        '
        Me.lblVigenciaInicio.Location = New System.Drawing.Point(671, 36)
        Me.lblVigenciaInicio.Name = "lblVigenciaInicio"
        Me.lblVigenciaInicio.Size = New System.Drawing.Size(100, 13)
        Me.lblVigenciaInicio.TabIndex = 18
        Me.lblVigenciaInicio.Text = "Vigencia Inicio"
        Me.lblVigenciaInicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNoCertificado
        '
        Me.lblNoCertificado.Location = New System.Drawing.Point(671, 8)
        Me.lblNoCertificado.Name = "lblNoCertificado"
        Me.lblNoCertificado.Size = New System.Drawing.Size(100, 13)
        Me.lblNoCertificado.TabIndex = 17
        Me.lblNoCertificado.Text = "* No. de Certificado"
        Me.lblNoCertificado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnExaminarKey
        '
        Me.btnExaminarKey.Location = New System.Drawing.Point(574, 29)
        Me.btnExaminarKey.Name = "btnExaminarKey"
        Me.btnExaminarKey.Size = New System.Drawing.Size(75, 23)
        Me.btnExaminarKey.TabIndex = 14
        Me.btnExaminarKey.Text = "Examinar..."
        Me.btnExaminarKey.UseVisualStyleBackColor = True
        '
        'btnExaminarCer
        '
        Me.btnExaminarCer.Location = New System.Drawing.Point(574, 3)
        Me.btnExaminarCer.Name = "btnExaminarCer"
        Me.btnExaminarCer.Size = New System.Drawing.Size(75, 23)
        Me.btnExaminarCer.TabIndex = 13
        Me.btnExaminarCer.Text = "Examinar..."
        Me.btnExaminarCer.UseVisualStyleBackColor = True
        '
        'txtFolioFinal
        '
        Me.txtFolioFinal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFolioFinal.Location = New System.Drawing.Point(777, 137)
        Me.txtFolioFinal.Name = "txtFolioFinal"
        Me.txtFolioFinal.Size = New System.Drawing.Size(170, 20)
        Me.txtFolioFinal.TabIndex = 24
        '
        'txtFolioActual
        '
        Me.txtFolioActual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFolioActual.Enabled = False
        Me.txtFolioActual.Location = New System.Drawing.Point(777, 111)
        Me.txtFolioActual.Name = "txtFolioActual"
        Me.txtFolioActual.Size = New System.Drawing.Size(170, 20)
        Me.txtFolioActual.TabIndex = 23
        '
        'txtFolioInicio
        '
        Me.txtFolioInicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFolioInicio.Location = New System.Drawing.Point(777, 85)
        Me.txtFolioInicio.Name = "txtFolioInicio"
        Me.txtFolioInicio.Size = New System.Drawing.Size(170, 20)
        Me.txtFolioInicio.TabIndex = 22
        '
        'txtRutaWS
        '
        Me.txtRutaWS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRutaWS.Location = New System.Drawing.Point(142, 57)
        Me.txtRutaWS.Name = "txtRutaWS"
        Me.txtRutaWS.Size = New System.Drawing.Size(507, 20)
        Me.txtRutaWS.TabIndex = 15
        '
        'txtRutaKey
        '
        Me.txtRutaKey.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRutaKey.Enabled = False
        Me.txtRutaKey.Location = New System.Drawing.Point(142, 31)
        Me.txtRutaKey.Name = "txtRutaKey"
        Me.txtRutaKey.Size = New System.Drawing.Size(426, 20)
        Me.txtRutaKey.TabIndex = 8
        '
        'txtRutaCertificado
        '
        Me.txtRutaCertificado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRutaCertificado.Enabled = False
        Me.txtRutaCertificado.Location = New System.Drawing.Point(142, 5)
        Me.txtRutaCertificado.Name = "txtRutaCertificado"
        Me.txtRutaCertificado.Size = New System.Drawing.Size(426, 20)
        Me.txtRutaCertificado.TabIndex = 7
        '
        'lblFolioFinal
        '
        Me.lblFolioFinal.Location = New System.Drawing.Point(671, 140)
        Me.lblFolioFinal.Name = "lblFolioFinal"
        Me.lblFolioFinal.Size = New System.Drawing.Size(100, 13)
        Me.lblFolioFinal.TabIndex = 6
        Me.lblFolioFinal.Text = "Folio final"
        Me.lblFolioFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFolioActual
        '
        Me.lblFolioActual.Location = New System.Drawing.Point(671, 114)
        Me.lblFolioActual.Name = "lblFolioActual"
        Me.lblFolioActual.Size = New System.Drawing.Size(100, 13)
        Me.lblFolioActual.TabIndex = 5
        Me.lblFolioActual.Text = "Folio actual"
        Me.lblFolioActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFolioInicio
        '
        Me.lblFolioInicio.Location = New System.Drawing.Point(671, 88)
        Me.lblFolioInicio.Name = "lblFolioInicio"
        Me.lblFolioInicio.Size = New System.Drawing.Size(100, 13)
        Me.lblFolioInicio.TabIndex = 4
        Me.lblFolioInicio.Text = "Folio inicio"
        Me.lblFolioInicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRutaWS
        '
        Me.lblRutaWS.Location = New System.Drawing.Point(36, 60)
        Me.lblRutaWS.Name = "lblRutaWS"
        Me.lblRutaWS.Size = New System.Drawing.Size(100, 13)
        Me.lblRutaWS.TabIndex = 2
        Me.lblRutaWS.Text = "* Ruta WS"
        Me.lblRutaWS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRutaKey
        '
        Me.lblRutaKey.Location = New System.Drawing.Point(36, 34)
        Me.lblRutaKey.Name = "lblRutaKey"
        Me.lblRutaKey.Size = New System.Drawing.Size(100, 13)
        Me.lblRutaKey.TabIndex = 1
        Me.lblRutaKey.Text = "* Ruta Key"
        Me.lblRutaKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRutaCertificado
        '
        Me.lblRutaCertificado.Location = New System.Drawing.Point(36, 8)
        Me.lblRutaCertificado.Name = "lblRutaCertificado"
        Me.lblRutaCertificado.Size = New System.Drawing.Size(100, 13)
        Me.lblRutaCertificado.TabIndex = 0
        Me.lblRutaCertificado.Text = "* Ruta Certificado"
        Me.lblRutaCertificado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbFCReporteCancelacion
        '
        Me.cmbFCReporteCancelacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFCReporteCancelacion.Enabled = False
        Me.cmbFCReporteCancelacion.FormattingEnabled = True
        Me.cmbFCReporteCancelacion.Location = New System.Drawing.Point(766, 67)
        Me.cmbFCReporteCancelacion.Name = "cmbFCReporteCancelacion"
        Me.cmbFCReporteCancelacion.Size = New System.Drawing.Size(217, 21)
        Me.cmbFCReporteCancelacion.TabIndex = 27
        '
        'lblFCReporteCancelacion
        '
        Me.lblFCReporteCancelacion.Location = New System.Drawing.Point(640, 70)
        Me.lblFCReporteCancelacion.Name = "lblFCReporteCancelacion"
        Me.lblFCReporteCancelacion.Size = New System.Drawing.Size(120, 13)
        Me.lblFCReporteCancelacion.TabIndex = 27
        Me.lblFCReporteCancelacion.Text = "Reporte Cancelacion"
        Me.lblFCReporteCancelacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbFCReporteFactura
        '
        Me.cmbFCReporteFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFCReporteFactura.FormattingEnabled = True
        Me.cmbFCReporteFactura.Location = New System.Drawing.Point(766, 40)
        Me.cmbFCReporteFactura.Name = "cmbFCReporteFactura"
        Me.cmbFCReporteFactura.Size = New System.Drawing.Size(217, 21)
        Me.cmbFCReporteFactura.TabIndex = 26
        '
        'txtFCFolioActual
        '
        Me.txtFCFolioActual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFCFolioActual.Enabled = False
        Me.txtFCFolioActual.Location = New System.Drawing.Point(766, 14)
        Me.txtFCFolioActual.Name = "txtFCFolioActual"
        Me.txtFCFolioActual.Size = New System.Drawing.Size(217, 20)
        Me.txtFCFolioActual.TabIndex = 10
        '
        'txtSerie
        '
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Location = New System.Drawing.Point(120, 92)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(217, 20)
        Me.txtSerie.TabIndex = 25
        '
        'txtMaxRenglones
        '
        Me.txtMaxRenglones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMaxRenglones.Location = New System.Drawing.Point(120, 66)
        Me.txtMaxRenglones.Name = "txtMaxRenglones"
        Me.txtMaxRenglones.Size = New System.Drawing.Size(170, 20)
        Me.txtMaxRenglones.TabIndex = 24
        '
        'txtFCRutaXML
        '
        Me.txtFCRutaXML.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFCRutaXML.Enabled = False
        Me.txtFCRutaXML.Location = New System.Drawing.Point(120, 40)
        Me.txtFCRutaXML.Name = "txtFCRutaXML"
        Me.txtFCRutaXML.Size = New System.Drawing.Size(507, 20)
        Me.txtFCRutaXML.TabIndex = 7
        '
        'txtFCRutaPDF
        '
        Me.txtFCRutaPDF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFCRutaPDF.Enabled = False
        Me.txtFCRutaPDF.Location = New System.Drawing.Point(120, 14)
        Me.txtFCRutaPDF.Name = "txtFCRutaPDF"
        Me.txtFCRutaPDF.Size = New System.Drawing.Size(507, 20)
        Me.txtFCRutaPDF.TabIndex = 23
        '
        'lblFCReporteFactura
        '
        Me.lblFCReporteFactura.Location = New System.Drawing.Point(640, 43)
        Me.lblFCReporteFactura.Name = "lblFCReporteFactura"
        Me.lblFCReporteFactura.Size = New System.Drawing.Size(120, 13)
        Me.lblFCReporteFactura.TabIndex = 5
        Me.lblFCReporteFactura.Text = "Reporte Factura"
        Me.lblFCReporteFactura.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(640, 17)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(120, 13)
        Me.Label24.TabIndex = 4
        Me.Label24.Text = "Folio actual"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSerie
        '
        Me.lblSerie.Location = New System.Drawing.Point(14, 96)
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Size = New System.Drawing.Size(100, 13)
        Me.lblSerie.TabIndex = 3
        Me.lblSerie.Text = "Serie"
        Me.lblSerie.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMaxRenglones
        '
        Me.lblMaxRenglones.Location = New System.Drawing.Point(14, 69)
        Me.lblMaxRenglones.Name = "lblMaxRenglones"
        Me.lblMaxRenglones.Size = New System.Drawing.Size(100, 13)
        Me.lblMaxRenglones.TabIndex = 2
        Me.lblMaxRenglones.Text = "Máximo renglones"
        Me.lblMaxRenglones.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(14, 43)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(100, 13)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "Ruta XML"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(14, 17)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 13)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Ruta PDF"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbFPReporteCancelacion
        '
        Me.cmbFPReporteCancelacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFPReporteCancelacion.Enabled = False
        Me.cmbFPReporteCancelacion.FormattingEnabled = True
        Me.cmbFPReporteCancelacion.Location = New System.Drawing.Point(763, 48)
        Me.cmbFPReporteCancelacion.Name = "cmbFPReporteCancelacion"
        Me.cmbFPReporteCancelacion.Size = New System.Drawing.Size(217, 21)
        Me.cmbFPReporteCancelacion.TabIndex = 29
        '
        'lblFPReporteCancelacion
        '
        Me.lblFPReporteCancelacion.Location = New System.Drawing.Point(637, 51)
        Me.lblFPReporteCancelacion.Name = "lblFPReporteCancelacion"
        Me.lblFPReporteCancelacion.Size = New System.Drawing.Size(120, 13)
        Me.lblFPReporteCancelacion.TabIndex = 28
        Me.lblFPReporteCancelacion.Text = "Reporte Cancelacion"
        Me.lblFPReporteCancelacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbFPReporteFactura
        '
        Me.cmbFPReporteFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFPReporteFactura.FormattingEnabled = True
        Me.cmbFPReporteFactura.Location = New System.Drawing.Point(763, 22)
        Me.cmbFPReporteFactura.Name = "cmbFPReporteFactura"
        Me.cmbFPReporteFactura.Size = New System.Drawing.Size(217, 21)
        Me.cmbFPReporteFactura.TabIndex = 28
        '
        'txtFPRutaXML
        '
        Me.txtFPRutaXML.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFPRutaXML.Enabled = False
        Me.txtFPRutaXML.Location = New System.Drawing.Point(114, 48)
        Me.txtFPRutaXML.Name = "txtFPRutaXML"
        Me.txtFPRutaXML.Size = New System.Drawing.Size(507, 20)
        Me.txtFPRutaXML.TabIndex = 4
        '
        'txtFPRutaPDF
        '
        Me.txtFPRutaPDF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFPRutaPDF.Enabled = False
        Me.txtFPRutaPDF.Location = New System.Drawing.Point(114, 22)
        Me.txtFPRutaPDF.Name = "txtFPRutaPDF"
        Me.txtFPRutaPDF.Size = New System.Drawing.Size(507, 20)
        Me.txtFPRutaPDF.TabIndex = 3
        '
        'lblFPReporteFactura
        '
        Me.lblFPReporteFactura.Location = New System.Drawing.Point(637, 25)
        Me.lblFPReporteFactura.Name = "lblFPReporteFactura"
        Me.lblFPReporteFactura.Size = New System.Drawing.Size(120, 13)
        Me.lblFPReporteFactura.TabIndex = 2
        Me.lblFPReporteFactura.Text = "Reporte Factura"
        Me.lblFPReporteFactura.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(8, 51)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(100, 13)
        Me.Label27.TabIndex = 1
        Me.Label27.Text = "Ruta XML"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(8, 25)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(100, 13)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "Ruta PDF"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(80, 42)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 64
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Facturacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(80, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 29
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(16, 42)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 66
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Facturacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(22, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 28
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'tbcEmpresas
        '
        Me.tbcEmpresas.Controls.Add(Me.tbpGeneral)
        Me.tbcEmpresas.Controls.Add(Me.tbpFacturaGeneral)
        Me.tbcEmpresas.Controls.Add(Me.tbpFacturacionCalzado)
        Me.tbcEmpresas.Controls.Add(Me.tbpFacturacionProductos)
        Me.tbcEmpresas.Location = New System.Drawing.Point(3, 66)
        Me.tbcEmpresas.Name = "tbcEmpresas"
        Me.tbcEmpresas.SelectedIndex = 0
        Me.tbcEmpresas.Size = New System.Drawing.Size(1026, 216)
        Me.tbcEmpresas.TabIndex = 25
        '
        'tbpGeneral
        '
        Me.tbpGeneral.BackColor = System.Drawing.Color.AliceBlue
        Me.tbpGeneral.Controls.Add(Me.pnlGeneral)
        Me.tbpGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tbpGeneral.Name = "tbpGeneral"
        Me.tbpGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpGeneral.Size = New System.Drawing.Size(1018, 190)
        Me.tbpGeneral.TabIndex = 0
        Me.tbpGeneral.Text = "General"
        '
        'pnlGeneral
        '
        Me.pnlGeneral.Controls.Add(Me.txtNombre)
        Me.pnlGeneral.Controls.Add(Me.lblNombre)
        Me.pnlGeneral.Controls.Add(Me.chkArrendamiento)
        Me.pnlGeneral.Controls.Add(Me.txtClaveRegimen)
        Me.pnlGeneral.Controls.Add(Me.lblClaveRegimen)
        Me.pnlGeneral.Controls.Add(Me.txtCurp)
        Me.pnlGeneral.Controls.Add(Me.txtRazonSocial)
        Me.pnlGeneral.Controls.Add(Me.txtColonia)
        Me.pnlGeneral.Controls.Add(Me.txtRFC)
        Me.pnlGeneral.Controls.Add(Me.lblCurp)
        Me.pnlGeneral.Controls.Add(Me.txtNumero)
        Me.pnlGeneral.Controls.Add(Me.ptbLogo)
        Me.pnlGeneral.Controls.Add(Me.txtCalle)
        Me.pnlGeneral.Controls.Add(Me.txtCP)
        Me.pnlGeneral.Controls.Add(Me.cmbCiudad)
        Me.pnlGeneral.Controls.Add(Me.lblLogo)
        Me.pnlGeneral.Controls.Add(Me.btnExaminarImagen)
        Me.pnlGeneral.Controls.Add(Me.lblCp)
        Me.pnlGeneral.Controls.Add(Me.lblCiudad)
        Me.pnlGeneral.Controls.Add(Me.lblRazonSocial)
        Me.pnlGeneral.Controls.Add(Me.chkActiva)
        Me.pnlGeneral.Controls.Add(Me.cmbEstado)
        Me.pnlGeneral.Controls.Add(Me.lblNumero)
        Me.pnlGeneral.Controls.Add(Me.lblCalle)
        Me.pnlGeneral.Controls.Add(Me.lblRegimen)
        Me.pnlGeneral.Controls.Add(Me.lblEstado)
        Me.pnlGeneral.Controls.Add(Me.lblRFC)
        Me.pnlGeneral.Controls.Add(Me.lblColonia)
        Me.pnlGeneral.Controls.Add(Me.txtRegimen)
        Me.pnlGeneral.Location = New System.Drawing.Point(5, 3)
        Me.pnlGeneral.Name = "pnlGeneral"
        Me.pnlGeneral.Size = New System.Drawing.Size(1006, 184)
        Me.pnlGeneral.TabIndex = 68
        '
        'txtNombre
        '
        Me.txtNombre.AccessibleName = ""
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(215, 32)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(476, 20)
        Me.txtNombre.TabIndex = 25
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(158, 35)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(51, 13)
        Me.lblNombre.TabIndex = 26
        Me.lblNombre.Text = "* Nombre"
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkArrendamiento
        '
        Me.chkArrendamiento.AutoSize = True
        Me.chkArrendamiento.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkArrendamiento.Location = New System.Drawing.Point(438, 163)
        Me.chkArrendamiento.Name = "chkArrendamiento"
        Me.chkArrendamiento.Size = New System.Drawing.Size(94, 17)
        Me.chkArrendamiento.TabIndex = 24
        Me.chkArrendamiento.Text = "Arrendamiento"
        Me.chkArrendamiento.UseVisualStyleBackColor = True
        '
        'txtClaveRegimen
        '
        Me.txtClaveRegimen.AccessibleName = ""
        Me.txtClaveRegimen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClaveRegimen.Location = New System.Drawing.Point(215, 161)
        Me.txtClaveRegimen.Name = "txtClaveRegimen"
        Me.txtClaveRegimen.Size = New System.Drawing.Size(102, 20)
        Me.txtClaveRegimen.TabIndex = 23
        '
        'lblClaveRegimen
        '
        Me.lblClaveRegimen.Location = New System.Drawing.Point(111, 164)
        Me.lblClaveRegimen.Name = "lblClaveRegimen"
        Me.lblClaveRegimen.Size = New System.Drawing.Size(98, 13)
        Me.lblClaveRegimen.TabIndex = 22
        Me.lblClaveRegimen.Text = "* Clave Regimen"
        Me.lblClaveRegimen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbpFacturaGeneral
        '
        Me.tbpFacturaGeneral.BackColor = System.Drawing.Color.AliceBlue
        Me.tbpFacturaGeneral.Controls.Add(Me.pnlFacturaGeneral)
        Me.tbpFacturaGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tbpFacturaGeneral.Name = "tbpFacturaGeneral"
        Me.tbpFacturaGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpFacturaGeneral.Size = New System.Drawing.Size(1018, 190)
        Me.tbpFacturaGeneral.TabIndex = 1
        Me.tbpFacturaGeneral.Text = "Facturación General"
        '
        'pnlFacturaGeneral
        '
        Me.pnlFacturaGeneral.Controls.Add(Me.txtIdentificadorWS)
        Me.pnlFacturaGeneral.Controls.Add(Me.lblIdentificadorWS)
        Me.pnlFacturaGeneral.Controls.Add(Me.dtpVigenciaFin)
        Me.pnlFacturaGeneral.Controls.Add(Me.txtRutaCertificado)
        Me.pnlFacturaGeneral.Controls.Add(Me.dtpVigenciaInicio)
        Me.pnlFacturaGeneral.Controls.Add(Me.txtFolioActual)
        Me.pnlFacturaGeneral.Controls.Add(Me.txtFolioInicio)
        Me.pnlFacturaGeneral.Controls.Add(Me.txtContrasenaCertificado)
        Me.pnlFacturaGeneral.Controls.Add(Me.txtFolioFinal)
        Me.pnlFacturaGeneral.Controls.Add(Me.lblRutaCertificado)
        Me.pnlFacturaGeneral.Controls.Add(Me.txtContrasenaWS)
        Me.pnlFacturaGeneral.Controls.Add(Me.txtUsuarioWS)
        Me.pnlFacturaGeneral.Controls.Add(Me.btnExaminarCer)
        Me.pnlFacturaGeneral.Controls.Add(Me.lblRutaKey)
        Me.pnlFacturaGeneral.Controls.Add(Me.txtRutaWS)
        Me.pnlFacturaGeneral.Controls.Add(Me.txtNoCertificado)
        Me.pnlFacturaGeneral.Controls.Add(Me.btnExaminarKey)
        Me.pnlFacturaGeneral.Controls.Add(Me.lblRutaWS)
        Me.pnlFacturaGeneral.Controls.Add(Me.txtRutaKey)
        Me.pnlFacturaGeneral.Controls.Add(Me.lblContrasenaCertificado)
        Me.pnlFacturaGeneral.Controls.Add(Me.lblNoCertificado)
        Me.pnlFacturaGeneral.Controls.Add(Me.lblContrasenaWS)
        Me.pnlFacturaGeneral.Controls.Add(Me.lblFolioFinal)
        Me.pnlFacturaGeneral.Controls.Add(Me.lblUsuarioWS)
        Me.pnlFacturaGeneral.Controls.Add(Me.lblVigenciaInicio)
        Me.pnlFacturaGeneral.Controls.Add(Me.lblFolioInicio)
        Me.pnlFacturaGeneral.Controls.Add(Me.lblFolioActual)
        Me.pnlFacturaGeneral.Controls.Add(Me.lblVigenciaFin)
        Me.pnlFacturaGeneral.Location = New System.Drawing.Point(7, 3)
        Me.pnlFacturaGeneral.Name = "pnlFacturaGeneral"
        Me.pnlFacturaGeneral.Size = New System.Drawing.Size(1006, 184)
        Me.pnlFacturaGeneral.TabIndex = 68
        '
        'txtIdentificadorWS
        '
        Me.txtIdentificadorWS.Location = New System.Drawing.Point(142, 161)
        Me.txtIdentificadorWS.Name = "txtIdentificadorWS"
        Me.txtIdentificadorWS.Size = New System.Drawing.Size(507, 20)
        Me.txtIdentificadorWS.TabIndex = 26
        '
        'lblIdentificadorWS
        '
        Me.lblIdentificadorWS.Location = New System.Drawing.Point(6, 164)
        Me.lblIdentificadorWS.Name = "lblIdentificadorWS"
        Me.lblIdentificadorWS.Size = New System.Drawing.Size(130, 13)
        Me.lblIdentificadorWS.TabIndex = 25
        Me.lblIdentificadorWS.Text = "Identificador WS"
        Me.lblIdentificadorWS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtContrasenaWS
        '
        Me.txtContrasenaWS.Location = New System.Drawing.Point(142, 135)
        Me.txtContrasenaWS.Name = "txtContrasenaWS"
        Me.txtContrasenaWS.Size = New System.Drawing.Size(507, 20)
        Me.txtContrasenaWS.TabIndex = 18
        '
        'lblContrasenaWS
        '
        Me.lblContrasenaWS.Location = New System.Drawing.Point(6, 138)
        Me.lblContrasenaWS.Name = "lblContrasenaWS"
        Me.lblContrasenaWS.Size = New System.Drawing.Size(130, 13)
        Me.lblContrasenaWS.TabIndex = 3
        Me.lblContrasenaWS.Text = "* Contraseña WS"
        Me.lblContrasenaWS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbpFacturacionCalzado
        '
        Me.tbpFacturacionCalzado.BackColor = System.Drawing.Color.AliceBlue
        Me.tbpFacturacionCalzado.Controls.Add(Me.pnlFacturacionCalzado)
        Me.tbpFacturacionCalzado.Location = New System.Drawing.Point(4, 22)
        Me.tbpFacturacionCalzado.Name = "tbpFacturacionCalzado"
        Me.tbpFacturacionCalzado.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpFacturacionCalzado.Size = New System.Drawing.Size(1018, 190)
        Me.tbpFacturacionCalzado.TabIndex = 2
        Me.tbpFacturacionCalzado.Text = "Facturación Calzado"
        '
        'pnlFacturacionCalzado
        '
        Me.pnlFacturacionCalzado.Controls.Add(Me.cmbFCReporteCancelacion)
        Me.pnlFacturacionCalzado.Controls.Add(Me.txtFCRutaPDF)
        Me.pnlFacturacionCalzado.Controls.Add(Me.lblFCReporteFactura)
        Me.pnlFacturacionCalzado.Controls.Add(Me.lblFCReporteCancelacion)
        Me.pnlFacturacionCalzado.Controls.Add(Me.txtFCRutaXML)
        Me.pnlFacturacionCalzado.Controls.Add(Me.Label20)
        Me.pnlFacturacionCalzado.Controls.Add(Me.Label24)
        Me.pnlFacturacionCalzado.Controls.Add(Me.cmbFCReporteFactura)
        Me.pnlFacturacionCalzado.Controls.Add(Me.txtMaxRenglones)
        Me.pnlFacturacionCalzado.Controls.Add(Me.Label21)
        Me.pnlFacturacionCalzado.Controls.Add(Me.lblSerie)
        Me.pnlFacturacionCalzado.Controls.Add(Me.txtFCFolioActual)
        Me.pnlFacturacionCalzado.Controls.Add(Me.txtSerie)
        Me.pnlFacturacionCalzado.Controls.Add(Me.lblMaxRenglones)
        Me.pnlFacturacionCalzado.Location = New System.Drawing.Point(6, 5)
        Me.pnlFacturacionCalzado.Name = "pnlFacturacionCalzado"
        Me.pnlFacturacionCalzado.Size = New System.Drawing.Size(1006, 184)
        Me.pnlFacturacionCalzado.TabIndex = 68
        '
        'tbpFacturacionProductos
        '
        Me.tbpFacturacionProductos.BackColor = System.Drawing.Color.AliceBlue
        Me.tbpFacturacionProductos.Controls.Add(Me.pnlFacturacionProductos)
        Me.tbpFacturacionProductos.Location = New System.Drawing.Point(4, 22)
        Me.tbpFacturacionProductos.Name = "tbpFacturacionProductos"
        Me.tbpFacturacionProductos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpFacturacionProductos.Size = New System.Drawing.Size(1018, 190)
        Me.tbpFacturacionProductos.TabIndex = 3
        Me.tbpFacturacionProductos.Text = "Facturación Productos"
        '
        'pnlFacturacionProductos
        '
        Me.pnlFacturacionProductos.Controls.Add(Me.cmbFPReporteCancelacion)
        Me.pnlFacturacionProductos.Controls.Add(Me.txtFPRutaPDF)
        Me.pnlFacturacionProductos.Controls.Add(Me.lblFPReporteFactura)
        Me.pnlFacturacionProductos.Controls.Add(Me.lblFPReporteCancelacion)
        Me.pnlFacturacionProductos.Controls.Add(Me.txtFPRutaXML)
        Me.pnlFacturacionProductos.Controls.Add(Me.Label26)
        Me.pnlFacturacionProductos.Controls.Add(Me.Label27)
        Me.pnlFacturacionProductos.Controls.Add(Me.cmbFPReporteFactura)
        Me.pnlFacturacionProductos.Location = New System.Drawing.Point(6, 3)
        Me.pnlFacturacionProductos.Name = "pnlFacturacionProductos"
        Me.pnlFacturacionProductos.Size = New System.Drawing.Size(1006, 184)
        Me.pnlFacturacionProductos.TabIndex = 68
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 294)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1037, 60)
        Me.Panel1.TabIndex = 67
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCerrar)
        Me.Panel2.Controls.Add(Me.lblCancelar)
        Me.Panel2.Controls.Add(Me.lblGuardar)
        Me.Panel2.Controls.Add(Me.btnGuardar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(904, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(133, 60)
        Me.Panel2.TabIndex = 6
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(211, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 44
        Me.PictureBox1.TabStop = False
        '
        'AltaEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1037, 354)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tbcEmpresas)
        Me.Controls.Add(Me.pnlBanner)
        Me.MaximumSize = New System.Drawing.Size(1045, 381)
        Me.MinimumSize = New System.Drawing.Size(1045, 381)
        Me.Name = "AltaEmpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración Empresa"
        Me.pnlBanner.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.ptbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcEmpresas.ResumeLayout(False)
        Me.tbpGeneral.ResumeLayout(False)
        Me.pnlGeneral.ResumeLayout(False)
        Me.pnlGeneral.PerformLayout()
        Me.tbpFacturaGeneral.ResumeLayout(False)
        Me.pnlFacturaGeneral.ResumeLayout(False)
        Me.pnlFacturaGeneral.PerformLayout()
        Me.tbpFacturacionCalzado.ResumeLayout(False)
        Me.pnlFacturacionCalzado.ResumeLayout(False)
        Me.pnlFacturacionCalzado.PerformLayout()
        Me.tbpFacturacionProductos.ResumeLayout(False)
        Me.pnlFacturacionProductos.ResumeLayout(False)
        Me.pnlFacturacionProductos.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBanner As System.Windows.Forms.Panel
    Friend WithEvents cmbCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtRFC As System.Windows.Forms.TextBox
    Friend WithEvents txtColonia As System.Windows.Forms.TextBox
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents lblCiudad As System.Windows.Forms.Label
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents lblColonia As System.Windows.Forms.Label
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents lblLogo As System.Windows.Forms.Label
    Friend WithEvents ptbLogo As System.Windows.Forms.PictureBox
    Friend WithEvents btnExaminarImagen As System.Windows.Forms.Button
    Friend WithEvents txtFolioFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtFolioActual As System.Windows.Forms.TextBox
    Friend WithEvents txtFolioInicio As System.Windows.Forms.TextBox
    Friend WithEvents txtRutaWS As System.Windows.Forms.TextBox
    Friend WithEvents txtRutaKey As System.Windows.Forms.TextBox
    Friend WithEvents txtRutaCertificado As System.Windows.Forms.TextBox
    Friend WithEvents lblFolioFinal As System.Windows.Forms.Label
    Friend WithEvents lblFolioActual As System.Windows.Forms.Label
    Friend WithEvents lblFolioInicio As System.Windows.Forms.Label
    Friend WithEvents lblRutaWS As System.Windows.Forms.Label
    Friend WithEvents lblRutaKey As System.Windows.Forms.Label
    Friend WithEvents lblRutaCertificado As System.Windows.Forms.Label
    Friend WithEvents dtpVigenciaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpVigenciaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtContrasenaCertificado As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuarioWS As System.Windows.Forms.TextBox
    Friend WithEvents txtNoCertificado As System.Windows.Forms.TextBox
    Friend WithEvents lblContrasenaCertificado As System.Windows.Forms.Label
    Friend WithEvents lblUsuarioWS As System.Windows.Forms.Label
    Friend WithEvents lblVigenciaFin As System.Windows.Forms.Label
    Friend WithEvents lblVigenciaInicio As System.Windows.Forms.Label
    Friend WithEvents lblNoCertificado As System.Windows.Forms.Label
    Friend WithEvents btnExaminarKey As System.Windows.Forms.Button
    Friend WithEvents btnExaminarCer As System.Windows.Forms.Button
    Friend WithEvents lblFCReporteFactura As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblSerie As System.Windows.Forms.Label
    Friend WithEvents lblMaxRenglones As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtFCFolioActual As System.Windows.Forms.TextBox
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxRenglones As System.Windows.Forms.TextBox
    Friend WithEvents txtFCRutaXML As System.Windows.Forms.TextBox
    Friend WithEvents txtFCRutaPDF As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtFPRutaXML As System.Windows.Forms.TextBox
    Friend WithEvents txtFPRutaPDF As System.Windows.Forms.TextBox
    Friend WithEvents lblFPReporteFactura As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents chkActiva As System.Windows.Forms.CheckBox
    Friend WithEvents opfArchivoImg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents opfArchivoCer As System.Windows.Forms.OpenFileDialog
    Friend WithEvents opfArchivoKey As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmbFCReporteFactura As System.Windows.Forms.ComboBox
    Friend WithEvents cmbFPReporteFactura As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents txtRegimen As System.Windows.Forms.TextBox
    Friend WithEvents lblRegimen As System.Windows.Forms.Label
    Friend WithEvents txtCP As System.Windows.Forms.TextBox
    Friend WithEvents lblCp As System.Windows.Forms.Label
    Friend WithEvents txtCurp As System.Windows.Forms.TextBox
    Friend WithEvents lblCurp As System.Windows.Forms.Label
    Friend WithEvents cmbFPReporteCancelacion As System.Windows.Forms.ComboBox
    Friend WithEvents lblFPReporteCancelacion As System.Windows.Forms.Label
    Friend WithEvents cmbFCReporteCancelacion As System.Windows.Forms.ComboBox
    Friend WithEvents lblFCReporteCancelacion As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents tbcEmpresas As System.Windows.Forms.TabControl
    Friend WithEvents tbpGeneral As System.Windows.Forms.TabPage
    Friend WithEvents tbpFacturaGeneral As System.Windows.Forms.TabPage
    Friend WithEvents tbpFacturacionCalzado As System.Windows.Forms.TabPage
    Friend WithEvents tbpFacturacionProductos As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlGeneral As System.Windows.Forms.Panel
    Friend WithEvents pnlFacturaGeneral As System.Windows.Forms.Panel
    Friend WithEvents pnlFacturacionCalzado As System.Windows.Forms.Panel
    Friend WithEvents pnlFacturacionProductos As System.Windows.Forms.Panel
    Friend WithEvents txtClaveRegimen As System.Windows.Forms.TextBox
    Friend WithEvents lblClaveRegimen As System.Windows.Forms.Label
    Friend WithEvents txtIdentificadorWS As System.Windows.Forms.TextBox
    Friend WithEvents lblIdentificadorWS As System.Windows.Forms.Label
    Friend WithEvents txtContrasenaWS As System.Windows.Forms.TextBox
    Friend WithEvents lblContrasenaWS As System.Windows.Forms.Label
    Friend WithEvents chkArrendamiento As System.Windows.Forms.CheckBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
