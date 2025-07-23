<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaMovCreditoInfonavitNaveForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaMovCreditoInfonavitNaveForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblBuscarColaborador = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblPatronId = New System.Windows.Forms.Label()
        Me.lblColaboradorId = New System.Windows.Forms.Label()
        Me.lblCreditoId = New System.Windows.Forms.Label()
        Me.lblColaborador = New System.Windows.Forms.Label()
        Me.lblEtqColaborador = New System.Windows.Forms.Label()
        Me.lblEtqEmpresa = New System.Windows.Forms.Label()
        Me.lblEtqNSS = New System.Windows.Forms.Label()
        Me.lblEtqRFC = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.lblNSS = New System.Windows.Forms.Label()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.opfArchivoRetencion = New System.Windows.Forms.OpenFileDialog()
        Me.pnlEditables = New System.Windows.Forms.Panel()
        Me.pnlArchivoCargado = New System.Windows.Forms.Panel()
        Me.btnPDFAcuse = New System.Windows.Forms.Button()
        Me.txtValorDescuento = New System.Windows.Forms.TextBox()
        Me.cmbTipoDescuento = New System.Windows.Forms.ComboBox()
        Me.txtNumCredito = New System.Windows.Forms.TextBox()
        Me.dtpFechaRecepcion = New System.Windows.Forms.DateTimePicker()
        Me.cmbTipoMovimientos = New System.Windows.Forms.ComboBox()
        Me.lblFechaMovimiento = New System.Windows.Forms.Label()
        Me.rdbAplicaDisminucionNo = New System.Windows.Forms.RadioButton()
        Me.rdbAplicaDisminucionSI = New System.Windows.Forms.RadioButton()
        Me.lblEtqArchivoRetDescuentos = New System.Windows.Forms.Label()
        Me.lblEtqAplicaDisminucion = New System.Windows.Forms.Label()
        Me.lblEtqValorDescuento = New System.Windows.Forms.Label()
        Me.lblEtqTipoDescuento = New System.Windows.Forms.Label()
        Me.lblEtqNumCredito = New System.Windows.Forms.Label()
        Me.lblEtqFechaMovimiento = New System.Windows.Forms.Label()
        Me.lblEtqFechaRecepcion = New System.Windows.Forms.Label()
        Me.lblEtqMovimiento = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlEditables.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlAcciones)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(478, 72)
        Me.pnlHeader.TabIndex = 7
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblBuscarColaborador)
        Me.pnlAcciones.Controls.Add(Me.btnBuscar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(116, 72)
        Me.pnlAcciones.TabIndex = 1
        '
        'lblBuscarColaborador
        '
        Me.lblBuscarColaborador.AutoSize = True
        Me.lblBuscarColaborador.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBuscarColaborador.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscarColaborador.Location = New System.Drawing.Point(7, 46)
        Me.lblBuscarColaborador.Name = "lblBuscarColaborador"
        Me.lblBuscarColaborador.Size = New System.Drawing.Size(100, 13)
        Me.lblBuscarColaborador.TabIndex = 56
        Me.lblBuscarColaborador.Text = "Buscar Colaborador"
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(41, 11)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 55
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(60, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(418, 72)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(82, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(262, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Movimiento de Crédito Infonavit"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.lblGuardar)
        Me.pnlPie.Controls.Add(Me.btnGuardar)
        Me.pnlPie.Controls.Add(Me.lblCerrar)
        Me.pnlPie.Controls.Add(Me.btnCerrar)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 420)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(478, 62)
        Me.pnlPie.TabIndex = 62
        '
        'lblGuardar
        '
        Me.lblGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(366, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 47
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = Global.Contabilidad.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(372, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 46
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(433, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 45
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(434, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 44
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblPatronId
        '
        Me.lblPatronId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPatronId.AutoSize = True
        Me.lblPatronId.Location = New System.Drawing.Point(448, 120)
        Me.lblPatronId.Name = "lblPatronId"
        Me.lblPatronId.Size = New System.Drawing.Size(13, 13)
        Me.lblPatronId.TabIndex = 66
        Me.lblPatronId.Text = "0"
        Me.lblPatronId.Visible = False
        '
        'lblColaboradorId
        '
        Me.lblColaboradorId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblColaboradorId.AutoSize = True
        Me.lblColaboradorId.Location = New System.Drawing.Point(448, 97)
        Me.lblColaboradorId.Name = "lblColaboradorId"
        Me.lblColaboradorId.Size = New System.Drawing.Size(13, 13)
        Me.lblColaboradorId.TabIndex = 65
        Me.lblColaboradorId.Text = "0"
        Me.lblColaboradorId.Visible = False
        '
        'lblCreditoId
        '
        Me.lblCreditoId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCreditoId.AutoSize = True
        Me.lblCreditoId.Location = New System.Drawing.Point(448, 75)
        Me.lblCreditoId.Name = "lblCreditoId"
        Me.lblCreditoId.Size = New System.Drawing.Size(13, 13)
        Me.lblCreditoId.TabIndex = 67
        Me.lblCreditoId.Text = "0"
        Me.lblCreditoId.Visible = False
        '
        'lblColaborador
        '
        Me.lblColaborador.AutoSize = True
        Me.lblColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColaborador.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblColaborador.Location = New System.Drawing.Point(155, 89)
        Me.lblColaborador.Name = "lblColaborador"
        Me.lblColaborador.Size = New System.Drawing.Size(13, 13)
        Me.lblColaborador.TabIndex = 69
        Me.lblColaborador.Text = "--"
        '
        'lblEtqColaborador
        '
        Me.lblEtqColaborador.AutoSize = True
        Me.lblEtqColaborador.Location = New System.Drawing.Point(38, 89)
        Me.lblEtqColaborador.Name = "lblEtqColaborador"
        Me.lblEtqColaborador.Size = New System.Drawing.Size(64, 13)
        Me.lblEtqColaborador.TabIndex = 68
        Me.lblEtqColaborador.Text = "Colaborador"
        '
        'lblEtqEmpresa
        '
        Me.lblEtqEmpresa.AutoSize = True
        Me.lblEtqEmpresa.Location = New System.Drawing.Point(38, 114)
        Me.lblEtqEmpresa.Name = "lblEtqEmpresa"
        Me.lblEtqEmpresa.Size = New System.Drawing.Size(48, 13)
        Me.lblEtqEmpresa.TabIndex = 70
        Me.lblEtqEmpresa.Text = "Empresa"
        '
        'lblEtqNSS
        '
        Me.lblEtqNSS.AutoSize = True
        Me.lblEtqNSS.Location = New System.Drawing.Point(38, 142)
        Me.lblEtqNSS.Name = "lblEtqNSS"
        Me.lblEtqNSS.Size = New System.Drawing.Size(29, 13)
        Me.lblEtqNSS.TabIndex = 71
        Me.lblEtqNSS.Text = "NSS"
        '
        'lblEtqRFC
        '
        Me.lblEtqRFC.AutoSize = True
        Me.lblEtqRFC.Location = New System.Drawing.Point(38, 168)
        Me.lblEtqRFC.Name = "lblEtqRFC"
        Me.lblEtqRFC.Size = New System.Drawing.Size(28, 13)
        Me.lblEtqRFC.TabIndex = 72
        Me.lblEtqRFC.Text = "RFC"
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEmpresa.Location = New System.Drawing.Point(155, 114)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(13, 13)
        Me.lblEmpresa.TabIndex = 81
        Me.lblEmpresa.Text = "--"
        '
        'lblNSS
        '
        Me.lblNSS.AutoSize = True
        Me.lblNSS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNSS.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNSS.Location = New System.Drawing.Point(155, 142)
        Me.lblNSS.Name = "lblNSS"
        Me.lblNSS.Size = New System.Drawing.Size(13, 13)
        Me.lblNSS.TabIndex = 82
        Me.lblNSS.Text = "--"
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFC.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRFC.Location = New System.Drawing.Point(155, 168)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(13, 13)
        Me.lblRFC.TabIndex = 83
        Me.lblRFC.Text = "--"
        '
        'pnlEditables
        '
        Me.pnlEditables.Controls.Add(Me.pnlArchivoCargado)
        Me.pnlEditables.Controls.Add(Me.btnPDFAcuse)
        Me.pnlEditables.Controls.Add(Me.txtValorDescuento)
        Me.pnlEditables.Controls.Add(Me.cmbTipoDescuento)
        Me.pnlEditables.Controls.Add(Me.txtNumCredito)
        Me.pnlEditables.Controls.Add(Me.dtpFechaRecepcion)
        Me.pnlEditables.Controls.Add(Me.cmbTipoMovimientos)
        Me.pnlEditables.Controls.Add(Me.lblFechaMovimiento)
        Me.pnlEditables.Enabled = False
        Me.pnlEditables.Location = New System.Drawing.Point(142, 184)
        Me.pnlEditables.Name = "pnlEditables"
        Me.pnlEditables.Size = New System.Drawing.Size(326, 213)
        Me.pnlEditables.TabIndex = 94
        '
        'pnlArchivoCargado
        '
        Me.pnlArchivoCargado.BackgroundImage = Global.Contabilidad.Vista.My.Resources.Resources.seleccionar
        Me.pnlArchivoCargado.Location = New System.Drawing.Point(108, 182)
        Me.pnlArchivoCargado.Name = "pnlArchivoCargado"
        Me.pnlArchivoCargado.Size = New System.Drawing.Size(16, 16)
        Me.pnlArchivoCargado.TabIndex = 111
        Me.pnlArchivoCargado.Visible = False
        '
        'btnPDFAcuse
        '
        Me.btnPDFAcuse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPDFAcuse.Image = Global.Contabilidad.Vista.My.Resources.Resources.agregar_pdf
        Me.btnPDFAcuse.Location = New System.Drawing.Point(70, 174)
        Me.btnPDFAcuse.Name = "btnPDFAcuse"
        Me.btnPDFAcuse.Size = New System.Drawing.Size(32, 32)
        Me.btnPDFAcuse.TabIndex = 110
        Me.btnPDFAcuse.UseVisualStyleBackColor = True
        '
        'txtValorDescuento
        '
        Me.txtValorDescuento.Location = New System.Drawing.Point(14, 145)
        Me.txtValorDescuento.MaxLength = 10
        Me.txtValorDescuento.Name = "txtValorDescuento"
        Me.txtValorDescuento.Size = New System.Drawing.Size(121, 20)
        Me.txtValorDescuento.TabIndex = 107
        Me.txtValorDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTipoDescuento
        '
        Me.cmbTipoDescuento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDescuento.FormattingEnabled = True
        Me.cmbTipoDescuento.Location = New System.Drawing.Point(14, 117)
        Me.cmbTipoDescuento.Name = "cmbTipoDescuento"
        Me.cmbTipoDescuento.Size = New System.Drawing.Size(228, 21)
        Me.cmbTipoDescuento.TabIndex = 106
        '
        'txtNumCredito
        '
        Me.txtNumCredito.Location = New System.Drawing.Point(14, 89)
        Me.txtNumCredito.MaxLength = 10
        Me.txtNumCredito.Name = "txtNumCredito"
        Me.txtNumCredito.Size = New System.Drawing.Size(121, 20)
        Me.txtNumCredito.TabIndex = 105
        Me.txtNumCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpFechaRecepcion
        '
        Me.dtpFechaRecepcion.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaRecepcion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaRecepcion.Location = New System.Drawing.Point(14, 32)
        Me.dtpFechaRecepcion.Name = "dtpFechaRecepcion"
        Me.dtpFechaRecepcion.Size = New System.Drawing.Size(121, 20)
        Me.dtpFechaRecepcion.TabIndex = 104
        Me.dtpFechaRecepcion.Value = New Date(2016, 11, 11, 0, 0, 0, 0)
        '
        'cmbTipoMovimientos
        '
        Me.cmbTipoMovimientos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMovimientos.FormattingEnabled = True
        Me.cmbTipoMovimientos.Location = New System.Drawing.Point(14, 6)
        Me.cmbTipoMovimientos.Name = "cmbTipoMovimientos"
        Me.cmbTipoMovimientos.Size = New System.Drawing.Size(300, 21)
        Me.cmbTipoMovimientos.TabIndex = 103
        '
        'lblFechaMovimiento
        '
        Me.lblFechaMovimiento.AutoSize = True
        Me.lblFechaMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaMovimiento.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblFechaMovimiento.Location = New System.Drawing.Point(11, 64)
        Me.lblFechaMovimiento.Name = "lblFechaMovimiento"
        Me.lblFechaMovimiento.Size = New System.Drawing.Size(56, 13)
        Me.lblFechaMovimiento.TabIndex = 102
        Me.lblFechaMovimiento.Text = "- -/- -/- - - -"
        '
        'rdbAplicaDisminucionNo
        '
        Me.rdbAplicaDisminucionNo.AutoSize = True
        Me.rdbAplicaDisminucionNo.Checked = True
        Me.rdbAplicaDisminucionNo.Location = New System.Drawing.Point(261, 399)
        Me.rdbAplicaDisminucionNo.Name = "rdbAplicaDisminucionNo"
        Me.rdbAplicaDisminucionNo.Size = New System.Drawing.Size(39, 17)
        Me.rdbAplicaDisminucionNo.TabIndex = 109
        Me.rdbAplicaDisminucionNo.TabStop = True
        Me.rdbAplicaDisminucionNo.Text = "No"
        Me.rdbAplicaDisminucionNo.UseVisualStyleBackColor = True
        Me.rdbAplicaDisminucionNo.Visible = False
        '
        'rdbAplicaDisminucionSI
        '
        Me.rdbAplicaDisminucionSI.AutoSize = True
        Me.rdbAplicaDisminucionSI.Location = New System.Drawing.Point(210, 399)
        Me.rdbAplicaDisminucionSI.Name = "rdbAplicaDisminucionSI"
        Me.rdbAplicaDisminucionSI.Size = New System.Drawing.Size(34, 17)
        Me.rdbAplicaDisminucionSI.TabIndex = 108
        Me.rdbAplicaDisminucionSI.Text = "Si"
        Me.rdbAplicaDisminucionSI.UseVisualStyleBackColor = True
        Me.rdbAplicaDisminucionSI.Visible = False
        '
        'lblEtqArchivoRetDescuentos
        '
        Me.lblEtqArchivoRetDescuentos.AutoSize = True
        Me.lblEtqArchivoRetDescuentos.Location = New System.Drawing.Point(30, 368)
        Me.lblEtqArchivoRetDescuentos.Name = "lblEtqArchivoRetDescuentos"
        Me.lblEtqArchivoRetDescuentos.Size = New System.Drawing.Size(177, 13)
        Me.lblEtqArchivoRetDescuentos.TabIndex = 109
        Me.lblEtqArchivoRetDescuentos.Text = "* Archivo Retención de Descuentos"
        '
        'lblEtqAplicaDisminucion
        '
        Me.lblEtqAplicaDisminucion.AutoSize = True
        Me.lblEtqAplicaDisminucion.Location = New System.Drawing.Point(30, 400)
        Me.lblEtqAplicaDisminucion.Name = "lblEtqAplicaDisminucion"
        Me.lblEtqAplicaDisminucion.Size = New System.Drawing.Size(154, 13)
        Me.lblEtqAplicaDisminucion.TabIndex = 108
        Me.lblEtqAplicaDisminucion.Text = "* ¿Aplica tabla de disminución?"
        Me.lblEtqAplicaDisminucion.Visible = False
        '
        'lblEtqValorDescuento
        '
        Me.lblEtqValorDescuento.AutoSize = True
        Me.lblEtqValorDescuento.Location = New System.Drawing.Point(30, 332)
        Me.lblEtqValorDescuento.Name = "lblEtqValorDescuento"
        Me.lblEtqValorDescuento.Size = New System.Drawing.Size(106, 13)
        Me.lblEtqValorDescuento.TabIndex = 107
        Me.lblEtqValorDescuento.Text = "* Valor de descuento"
        '
        'lblEtqTipoDescuento
        '
        Me.lblEtqTipoDescuento.AutoSize = True
        Me.lblEtqTipoDescuento.Location = New System.Drawing.Point(30, 304)
        Me.lblEtqTipoDescuento.Name = "lblEtqTipoDescuento"
        Me.lblEtqTipoDescuento.Size = New System.Drawing.Size(103, 13)
        Me.lblEtqTipoDescuento.TabIndex = 106
        Me.lblEtqTipoDescuento.Text = "* Tipo de descuento"
        '
        'lblEtqNumCredito
        '
        Me.lblEtqNumCredito.AutoSize = True
        Me.lblEtqNumCredito.Location = New System.Drawing.Point(30, 276)
        Me.lblEtqNumCredito.Name = "lblEtqNumCredito"
        Me.lblEtqNumCredito.Size = New System.Drawing.Size(87, 13)
        Me.lblEtqNumCredito.TabIndex = 105
        Me.lblEtqNumCredito.Text = "* Número Crédito"
        '
        'lblEtqFechaMovimiento
        '
        Me.lblEtqFechaMovimiento.AutoSize = True
        Me.lblEtqFechaMovimiento.Location = New System.Drawing.Point(37, 248)
        Me.lblEtqFechaMovimiento.Name = "lblEtqFechaMovimiento"
        Me.lblEtqFechaMovimiento.Size = New System.Drawing.Size(94, 13)
        Me.lblEtqFechaMovimiento.TabIndex = 104
        Me.lblEtqFechaMovimiento.Text = "Fecha Movimiento"
        '
        'lblEtqFechaRecepcion
        '
        Me.lblEtqFechaRecepcion.AutoSize = True
        Me.lblEtqFechaRecepcion.Location = New System.Drawing.Point(30, 219)
        Me.lblEtqFechaRecepcion.Name = "lblEtqFechaRecepcion"
        Me.lblEtqFechaRecepcion.Size = New System.Drawing.Size(99, 13)
        Me.lblEtqFechaRecepcion.TabIndex = 103
        Me.lblEtqFechaRecepcion.Text = "* Fecha Recepción"
        '
        'lblEtqMovimiento
        '
        Me.lblEtqMovimiento.AutoSize = True
        Me.lblEtqMovimiento.Location = New System.Drawing.Point(30, 193)
        Me.lblEtqMovimiento.Name = "lblEtqMovimiento"
        Me.lblEtqMovimiento.Size = New System.Drawing.Size(68, 13)
        Me.lblEtqMovimiento.TabIndex = 102
        Me.lblEtqMovimiento.Text = "* Movimiento"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(346, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 72)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 38
        Me.imgLogo.TabStop = False
        '
        'AltaMovCreditoInfonavitNaveForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(478, 482)
        Me.Controls.Add(Me.lblEtqArchivoRetDescuentos)
        Me.Controls.Add(Me.lblEtqAplicaDisminucion)
        Me.Controls.Add(Me.rdbAplicaDisminucionNo)
        Me.Controls.Add(Me.lblEtqValorDescuento)
        Me.Controls.Add(Me.rdbAplicaDisminucionSI)
        Me.Controls.Add(Me.lblEtqTipoDescuento)
        Me.Controls.Add(Me.lblEtqNumCredito)
        Me.Controls.Add(Me.lblEtqFechaMovimiento)
        Me.Controls.Add(Me.lblEtqFechaRecepcion)
        Me.Controls.Add(Me.lblEtqMovimiento)
        Me.Controls.Add(Me.pnlEditables)
        Me.Controls.Add(Me.lblRFC)
        Me.Controls.Add(Me.lblNSS)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.lblEtqRFC)
        Me.Controls.Add(Me.lblEtqNSS)
        Me.Controls.Add(Me.lblEtqEmpresa)
        Me.Controls.Add(Me.lblColaborador)
        Me.Controls.Add(Me.lblEtqColaborador)
        Me.Controls.Add(Me.lblCreditoId)
        Me.Controls.Add(Me.lblPatronId)
        Me.Controls.Add(Me.lblColaboradorId)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlHeader)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AltaMovCreditoInfonavitNaveForm"
        Me.Text = "Movimiento de Crédito Infonavit"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlEditables.ResumeLayout(False)
        Me.pnlEditables.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents lblBuscarColaborador As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblPatronId As System.Windows.Forms.Label
    Friend WithEvents lblColaboradorId As System.Windows.Forms.Label
    Friend WithEvents lblCreditoId As System.Windows.Forms.Label
    Friend WithEvents lblColaborador As System.Windows.Forms.Label
    Friend WithEvents lblEtqColaborador As System.Windows.Forms.Label
    Friend WithEvents lblEtqEmpresa As System.Windows.Forms.Label
    Friend WithEvents lblEtqNSS As System.Windows.Forms.Label
    Friend WithEvents lblEtqRFC As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents lblNSS As System.Windows.Forms.Label
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents opfArchivoRetencion As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pnlEditables As System.Windows.Forms.Panel
    Friend WithEvents pnlArchivoCargado As System.Windows.Forms.Panel
    Friend WithEvents btnPDFAcuse As System.Windows.Forms.Button
    Friend WithEvents rdbAplicaDisminucionNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbAplicaDisminucionSI As System.Windows.Forms.RadioButton
    Friend WithEvents txtValorDescuento As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipoDescuento As System.Windows.Forms.ComboBox
    Friend WithEvents txtNumCredito As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaRecepcion As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbTipoMovimientos As System.Windows.Forms.ComboBox
    Friend WithEvents lblFechaMovimiento As System.Windows.Forms.Label
    Friend WithEvents lblEtqArchivoRetDescuentos As System.Windows.Forms.Label
    Friend WithEvents lblEtqAplicaDisminucion As System.Windows.Forms.Label
    Friend WithEvents lblEtqValorDescuento As System.Windows.Forms.Label
    Friend WithEvents lblEtqTipoDescuento As System.Windows.Forms.Label
    Friend WithEvents lblEtqNumCredito As System.Windows.Forms.Label
    Friend WithEvents lblEtqFechaMovimiento As System.Windows.Forms.Label
    Friend WithEvents lblEtqFechaRecepcion As System.Windows.Forms.Label
    Friend WithEvents lblEtqMovimiento As System.Windows.Forms.Label
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
