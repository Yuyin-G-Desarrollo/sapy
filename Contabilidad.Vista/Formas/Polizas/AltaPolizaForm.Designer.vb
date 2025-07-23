<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaPolizaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaPolizaForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.gpbCodigoDeColores = New Infragistics.Win.Misc.UltraGroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSinCuentaGral = New System.Windows.Forms.Label()
        Me.lblNoCuenta = New System.Windows.Forms.Label()
        Me.lblNoCuenta2 = New System.Windows.Forms.Label()
        Me.lblExiste2 = New System.Windows.Forms.Label()
        Me.lblExiste = New System.Windows.Forms.Label()
        Me.lblTotalCargos2 = New System.Windows.Forms.Label()
        Me.lblTotalAbonos2 = New System.Windows.Forms.Label()
        Me.lblTotalCargos = New System.Windows.Forms.Label()
        Me.lblTotalAbonos = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnEnvioContp = New System.Windows.Forms.Button()
        Me.pnlMax = New System.Windows.Forms.Panel()
        Me.lbllimpiar = New System.Windows.Forms.Label()
        Me.btnlimpiar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.lblDe = New System.Windows.Forms.Label()
        Me.lblAl = New System.Windows.Forms.Label()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.pnlBotonesAlto = New System.Windows.Forms.Panel()
        Me.dtpAl = New System.Windows.Forms.DateTimePicker()
        Me.dtpDe = New System.Windows.Forms.DateTimePicker()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblHeader = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblPolizasContables = New System.Windows.Forms.Label()
        Me.grdCompras = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlEstado.SuspendLayout()
        CType(Me.gpbCodigoDeColores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbCodigoDeColores.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlMax.SuspendLayout()
        Me.pnlBotonesAlto.SuspendLayout()
        Me.lblHeader.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.gpbCodigoDeColores)
        Me.pnlEstado.Controls.Add(Me.lblTotalCargos2)
        Me.pnlEstado.Controls.Add(Me.lblTotalAbonos2)
        Me.pnlEstado.Controls.Add(Me.lblTotalCargos)
        Me.pnlEstado.Controls.Add(Me.lblTotalAbonos)
        Me.pnlEstado.Controls.Add(Me.pnlBotones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 456)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1020, 69)
        Me.pnlEstado.TabIndex = 6
        '
        'gpbCodigoDeColores
        '
        Me.gpbCodigoDeColores.Controls.Add(Me.Label1)
        Me.gpbCodigoDeColores.Controls.Add(Me.lblSinCuentaGral)
        Me.gpbCodigoDeColores.Controls.Add(Me.lblNoCuenta)
        Me.gpbCodigoDeColores.Controls.Add(Me.lblNoCuenta2)
        Me.gpbCodigoDeColores.Controls.Add(Me.lblExiste2)
        Me.gpbCodigoDeColores.Controls.Add(Me.lblExiste)
        Me.gpbCodigoDeColores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbCodigoDeColores.Location = New System.Drawing.Point(15, 5)
        Me.gpbCodigoDeColores.Name = "gpbCodigoDeColores"
        Me.gpbCodigoDeColores.Size = New System.Drawing.Size(375, 61)
        Me.gpbCodigoDeColores.TabIndex = 16
        Me.gpbCodigoDeColores.Text = "Código de Colores"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.MediumPurple
        Me.Label1.ForeColor = System.Drawing.Color.MediumPurple
        Me.Label1.Location = New System.Drawing.Point(239, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "__"
        '
        'lblSinCuentaGral
        '
        Me.lblSinCuentaGral.AutoSize = True
        Me.lblSinCuentaGral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSinCuentaGral.Location = New System.Drawing.Point(264, 20)
        Me.lblSinCuentaGral.Name = "lblSinCuentaGral"
        Me.lblSinCuentaGral.Size = New System.Drawing.Size(99, 13)
        Me.lblSinCuentaGral.TabIndex = 12
        Me.lblSinCuentaGral.Text = "Sin cuenta general."
        '
        'lblNoCuenta
        '
        Me.lblNoCuenta.AutoSize = True
        Me.lblNoCuenta.BackColor = System.Drawing.Color.Salmon
        Me.lblNoCuenta.ForeColor = System.Drawing.Color.Salmon
        Me.lblNoCuenta.Location = New System.Drawing.Point(11, 20)
        Me.lblNoCuenta.Name = "lblNoCuenta"
        Me.lblNoCuenta.Size = New System.Drawing.Size(21, 13)
        Me.lblNoCuenta.TabIndex = 9
        Me.lblNoCuenta.Text = "__"
        '
        'lblNoCuenta2
        '
        Me.lblNoCuenta2.AutoSize = True
        Me.lblNoCuenta2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCuenta2.Location = New System.Drawing.Point(36, 20)
        Me.lblNoCuenta2.Name = "lblNoCuenta2"
        Me.lblNoCuenta2.Size = New System.Drawing.Size(105, 13)
        Me.lblNoCuenta2.TabIndex = 8
        Me.lblNoCuenta2.Text = "Sin cuenta contable."
        '
        'lblExiste2
        '
        Me.lblExiste2.AutoSize = True
        Me.lblExiste2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExiste2.Location = New System.Drawing.Point(36, 40)
        Me.lblExiste2.Name = "lblExiste2"
        Me.lblExiste2.Size = New System.Drawing.Size(155, 13)
        Me.lblExiste2.TabIndex = 10
        Me.lblExiste2.Text = "No existe cliente y/o proveedor"
        '
        'lblExiste
        '
        Me.lblExiste.AutoSize = True
        Me.lblExiste.BackColor = System.Drawing.Color.SandyBrown
        Me.lblExiste.ForeColor = System.Drawing.Color.SandyBrown
        Me.lblExiste.Location = New System.Drawing.Point(11, 40)
        Me.lblExiste.Name = "lblExiste"
        Me.lblExiste.Size = New System.Drawing.Size(21, 13)
        Me.lblExiste.TabIndex = 11
        Me.lblExiste.Text = "__"
        '
        'lblTotalCargos2
        '
        Me.lblTotalCargos2.AutoSize = True
        Me.lblTotalCargos2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCargos2.Location = New System.Drawing.Point(686, 35)
        Me.lblTotalCargos2.Name = "lblTotalCargos2"
        Me.lblTotalCargos2.Size = New System.Drawing.Size(16, 18)
        Me.lblTotalCargos2.TabIndex = 15
        Me.lblTotalCargos2.Text = "0"
        '
        'lblTotalAbonos2
        '
        Me.lblTotalAbonos2.AutoSize = True
        Me.lblTotalAbonos2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAbonos2.Location = New System.Drawing.Point(686, 10)
        Me.lblTotalAbonos2.Name = "lblTotalAbonos2"
        Me.lblTotalAbonos2.Size = New System.Drawing.Size(16, 18)
        Me.lblTotalAbonos2.TabIndex = 14
        Me.lblTotalAbonos2.Text = "0"
        '
        'lblTotalCargos
        '
        Me.lblTotalCargos.AutoSize = True
        Me.lblTotalCargos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCargos.Location = New System.Drawing.Point(591, 35)
        Me.lblTotalCargos.Name = "lblTotalCargos"
        Me.lblTotalCargos.Size = New System.Drawing.Size(95, 18)
        Me.lblTotalCargos.TabIndex = 13
        Me.lblTotalCargos.Text = "Total cargos:"
        '
        'lblTotalAbonos
        '
        Me.lblTotalAbonos.AutoSize = True
        Me.lblTotalAbonos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAbonos.Location = New System.Drawing.Point(591, 10)
        Me.lblTotalAbonos.Name = "lblTotalAbonos"
        Me.lblTotalAbonos.Size = New System.Drawing.Size(99, 18)
        Me.lblTotalAbonos.TabIndex = 12
        Me.lblTotalAbonos.Text = "Total abonos:"
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.Label2)
        Me.pnlBotones.Controls.Add(Me.btnsalir)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Controls.Add(Me.btnEnvioContp)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(832, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(188, 69)
        Me.pnlBotones.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(138, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Salir"
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnsalir.Location = New System.Drawing.Point(133, 9)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(34, 35)
        Me.btnsalir.TabIndex = 8
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(39, 45)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(89, 13)
        Me.lblGuardar.TabIndex = 7
        Me.lblGuardar.Text = "Enviar a Contpaq"
        '
        'btnEnvioContp
        '
        Me.btnEnvioContp.Image = Global.Contabilidad.Vista.My.Resources.Resources.CONTPAQ_i
        Me.btnEnvioContp.Location = New System.Drawing.Point(62, 7)
        Me.btnEnvioContp.Name = "btnEnvioContp"
        Me.btnEnvioContp.Size = New System.Drawing.Size(34, 35)
        Me.btnEnvioContp.TabIndex = 5
        Me.btnEnvioContp.UseVisualStyleBackColor = True
        '
        'pnlMax
        '
        Me.pnlMax.Controls.Add(Me.lbllimpiar)
        Me.pnlMax.Controls.Add(Me.btnlimpiar)
        Me.pnlMax.Controls.Add(Me.lblMostrar)
        Me.pnlMax.Controls.Add(Me.btnMostrar)
        Me.pnlMax.Controls.Add(Me.btnArriba)
        Me.pnlMax.Controls.Add(Me.btnAbajo)
        Me.pnlMax.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMax.Location = New System.Drawing.Point(919, 0)
        Me.pnlMax.Name = "pnlMax"
        Me.pnlMax.Size = New System.Drawing.Size(101, 120)
        Me.pnlMax.TabIndex = 18
        '
        'lbllimpiar
        '
        Me.lbllimpiar.AutoSize = True
        Me.lbllimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbllimpiar.Location = New System.Drawing.Point(53, 102)
        Me.lbllimpiar.Name = "lbllimpiar"
        Me.lbllimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lbllimpiar.TabIndex = 23
        Me.lbllimpiar.Text = "Limpiar"
        '
        'btnlimpiar
        '
        Me.btnlimpiar.Image = Global.Contabilidad.Vista.My.Resources.Resources.limpiar_32
        Me.btnlimpiar.Location = New System.Drawing.Point(56, 67)
        Me.btnlimpiar.Name = "btnlimpiar"
        Me.btnlimpiar.Size = New System.Drawing.Size(31, 32)
        Me.btnlimpiar.TabIndex = 22
        Me.btnlimpiar.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(7, 102)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 18
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(10, 67)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(31, 32)
        Me.btnMostrar.TabIndex = 21
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(42, 4)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 19
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(69, 4)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 20
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'lblDe
        '
        Me.lblDe.AutoSize = True
        Me.lblDe.Location = New System.Drawing.Point(671, 40)
        Me.lblDe.Name = "lblDe"
        Me.lblDe.Size = New System.Drawing.Size(26, 13)
        Me.lblDe.TabIndex = 11
        Me.lblDe.Text = "Del:"
        '
        'lblAl
        '
        Me.lblAl.AutoSize = True
        Me.lblAl.Location = New System.Drawing.Point(671, 80)
        Me.lblAl.Name = "lblAl"
        Me.lblAl.Size = New System.Drawing.Size(19, 13)
        Me.lblAl.TabIndex = 12
        Me.lblAl.Text = "Al:"
        '
        'cmbEstatus
        '
        Me.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Items.AddRange(New Object() {"", "NUEVAS", "GENERADAS"})
        Me.cmbEstatus.Location = New System.Drawing.Point(90, 72)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(300, 21)
        Me.cmbEstatus.TabIndex = 10
        Me.cmbEstatus.Visible = False
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Location = New System.Drawing.Point(30, 72)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(45, 13)
        Me.lblEstatus.TabIndex = 8
        Me.lblEstatus.Text = "Estatus:"
        Me.lblEstatus.Visible = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Location = New System.Drawing.Point(424, 40)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(31, 13)
        Me.lblTipo.TabIndex = 15
        Me.lblTipo.Text = "Tipo:"
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(26, 40)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(51, 13)
        Me.lblEmpresa.TabIndex = 7
        Me.lblEmpresa.Text = "Empresa:"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(461, 40)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(191, 21)
        Me.cmbTipo.TabIndex = 16
        '
        'pnlBotonesAlto
        '
        Me.pnlBotonesAlto.Controls.Add(Me.dtpAl)
        Me.pnlBotonesAlto.Controls.Add(Me.dtpDe)
        Me.pnlBotonesAlto.Controls.Add(Me.cmbTipo)
        Me.pnlBotonesAlto.Controls.Add(Me.lblTipo)
        Me.pnlBotonesAlto.Controls.Add(Me.lblEstatus)
        Me.pnlBotonesAlto.Controls.Add(Me.cmbEstatus)
        Me.pnlBotonesAlto.Controls.Add(Me.pnlMax)
        Me.pnlBotonesAlto.Controls.Add(Me.lblEmpresa)
        Me.pnlBotonesAlto.Controls.Add(Me.cmbEmpresa)
        Me.pnlBotonesAlto.Controls.Add(Me.lblAl)
        Me.pnlBotonesAlto.Controls.Add(Me.lblDe)
        Me.pnlBotonesAlto.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBotonesAlto.Location = New System.Drawing.Point(0, 60)
        Me.pnlBotonesAlto.Name = "pnlBotonesAlto"
        Me.pnlBotonesAlto.Size = New System.Drawing.Size(1020, 120)
        Me.pnlBotonesAlto.TabIndex = 17
        '
        'dtpAl
        '
        Me.dtpAl.Location = New System.Drawing.Point(706, 79)
        Me.dtpAl.Name = "dtpAl"
        Me.dtpAl.Size = New System.Drawing.Size(202, 20)
        Me.dtpAl.TabIndex = 20
        '
        'dtpDe
        '
        Me.dtpDe.Location = New System.Drawing.Point(706, 40)
        Me.dtpDe.Name = "dtpDe"
        Me.dtpDe.Size = New System.Drawing.Size(200, 20)
        Me.dtpDe.TabIndex = 19
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(90, 40)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(300, 21)
        Me.cmbEmpresa.TabIndex = 9
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.White
        Me.lblHeader.Controls.Add(Me.Panel1)
        Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(1020, 60)
        Me.lblHeader.TabIndex = 18
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.imgLogo)
        Me.Panel1.Controls.Add(Me.lblPolizasContables)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(770, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(250, 60)
        Me.Panel1.TabIndex = 46
        '
        'lblPolizasContables
        '
        Me.lblPolizasContables.AutoSize = True
        Me.lblPolizasContables.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPolizasContables.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPolizasContables.Location = New System.Drawing.Point(28, 20)
        Me.lblPolizasContables.Name = "lblPolizasContables"
        Me.lblPolizasContables.Size = New System.Drawing.Size(152, 20)
        Me.lblPolizasContables.TabIndex = 21
        Me.lblPolizasContables.Text = "Pólizas Contables"
        '
        'grdCompras
        '
        Me.grdCompras.CausesValidation = False
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCompras.DisplayLayout.Appearance = Appearance1
        Me.grdCompras.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders
        Me.grdCompras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCompras.Location = New System.Drawing.Point(0, 180)
        Me.grdCompras.Name = "grdCompras"
        Me.grdCompras.Size = New System.Drawing.Size(1020, 276)
        Me.grdCompras.TabIndex = 19
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(178, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 47
        Me.imgLogo.TabStop = False
        '
        'AltaPolizaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1020, 525)
        Me.Controls.Add(Me.grdCompras)
        Me.Controls.Add(Me.pnlBotonesAlto)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.pnlEstado)
        Me.Name = "AltaPolizaForm"
        Me.Text = "Pólizas Contables"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        CType(Me.gpbCodigoDeColores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbCodigoDeColores.ResumeLayout(False)
        Me.gpbCodigoDeColores.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlMax.ResumeLayout(False)
        Me.pnlMax.PerformLayout()
        Me.pnlBotonesAlto.ResumeLayout(False)
        Me.pnlBotonesAlto.PerformLayout()
        Me.lblHeader.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdCompras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnEnvioContp As System.Windows.Forms.Button
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents pnlMax As System.Windows.Forms.Panel
    Friend WithEvents lblDe As System.Windows.Forms.Label
    Friend WithEvents lblAl As System.Windows.Forms.Label
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents pnlBotonesAlto As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents dtpAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDe As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents btnlimpiar As System.Windows.Forms.Button
    Friend WithEvents lbllimpiar As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents lblHeader As System.Windows.Forms.Panel
    Friend WithEvents lblPolizasContables As System.Windows.Forms.Label
    Friend WithEvents grdCompras As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblExiste As System.Windows.Forms.Label
    Friend WithEvents lblExiste2 As System.Windows.Forms.Label
    Friend WithEvents lblNoCuenta As System.Windows.Forms.Label
    Friend WithEvents lblNoCuenta2 As System.Windows.Forms.Label
    Friend WithEvents lblTotalCargos As System.Windows.Forms.Label
    Friend WithEvents lblTotalAbonos As System.Windows.Forms.Label
    Friend WithEvents lblTotalCargos2 As System.Windows.Forms.Label
    Friend WithEvents lblTotalAbonos2 As System.Windows.Forms.Label
    Friend WithEvents gpbCodigoDeColores As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSinCuentaGral As System.Windows.Forms.Label
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
