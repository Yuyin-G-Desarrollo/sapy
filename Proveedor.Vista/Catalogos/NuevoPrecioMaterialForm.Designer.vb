<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NuevoPrecioMaterialForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NuevoPrecioMaterialForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlDatosTalla = New System.Windows.Forms.Panel()
        Me.cmbOrigen = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbMoneda = New System.Windows.Forms.ComboBox()
        Me.txtClaveProv = New System.Windows.Forms.TextBox()
        Me.lblClaveProveedor = New System.Windows.Forms.Label()
        Me.txtDesProv = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.picump = New System.Windows.Forms.PictureBox()
        Me.cmbProveedorUM = New System.Windows.Forms.ComboBox()
        Me.picumc = New System.Windows.Forms.PictureBox()
        Me.PicRend = New System.Windows.Forms.PictureBox()
        Me.lblR = New System.Windows.Forms.Label()
        Me.txtEquivUMProv = New System.Windows.Forms.TextBox()
        Me.cmbProduccionUM = New System.Windows.Forms.ComboBox()
        Me.lblUMP = New System.Windows.Forms.Label()
        Me.lblUM = New System.Windows.Forms.Label()
        Me.txtIdMaterial = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pic7 = New System.Windows.Forms.PictureBox()
        Me.Pic6 = New System.Windows.Forms.PictureBox()
        Me.Pic4 = New System.Windows.Forms.PictureBox()
        Me.txtPrecioUnitario = New System.Windows.Forms.TextBox()
        Me.lblPrecioUnitario = New System.Windows.Forms.Label()
        Me.txtTiempoEntrega = New System.Windows.Forms.TextBox()
        Me.lblTiempoEntrega = New System.Windows.Forms.Label()
        Me.lblProv = New System.Windows.Forms.Label()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.lblFechaDeCreacion = New System.Windows.Forms.Label()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlDatosTalla.SuspendLayout()
        CType(Me.picump, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picumc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicRend, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbParametros.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(594, 60)
        Me.pnlHeader.TabIndex = 4
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(298, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(296, 60)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(50, 24)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(172, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Precio de Materiales"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnlBotones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 388)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(594, 60)
        Me.Panel1.TabIndex = 5
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.btnGuardar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(348, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(246, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'bntSalir
        '
        Me.bntSalir.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(196, 7)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 12
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(156, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 11
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(150, 42)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 2
        Me.lblGuardar.Text = "Guardar"
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(195, 42)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlDatosTalla
        '
        Me.pnlDatosTalla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDatosTalla.BackColor = System.Drawing.Color.Transparent
        Me.pnlDatosTalla.Controls.Add(Me.cmbOrigen)
        Me.pnlDatosTalla.Controls.Add(Me.Label3)
        Me.pnlDatosTalla.Controls.Add(Me.Label4)
        Me.pnlDatosTalla.Controls.Add(Me.cmbMoneda)
        Me.pnlDatosTalla.Controls.Add(Me.txtClaveProv)
        Me.pnlDatosTalla.Controls.Add(Me.lblClaveProveedor)
        Me.pnlDatosTalla.Controls.Add(Me.txtDesProv)
        Me.pnlDatosTalla.Controls.Add(Me.Label2)
        Me.pnlDatosTalla.Controls.Add(Me.picump)
        Me.pnlDatosTalla.Controls.Add(Me.cmbProveedorUM)
        Me.pnlDatosTalla.Controls.Add(Me.picumc)
        Me.pnlDatosTalla.Controls.Add(Me.PicRend)
        Me.pnlDatosTalla.Controls.Add(Me.lblR)
        Me.pnlDatosTalla.Controls.Add(Me.txtEquivUMProv)
        Me.pnlDatosTalla.Controls.Add(Me.cmbProduccionUM)
        Me.pnlDatosTalla.Controls.Add(Me.lblUMP)
        Me.pnlDatosTalla.Controls.Add(Me.lblUM)
        Me.pnlDatosTalla.Controls.Add(Me.txtIdMaterial)
        Me.pnlDatosTalla.Controls.Add(Me.Label1)
        Me.pnlDatosTalla.Controls.Add(Me.Pic7)
        Me.pnlDatosTalla.Controls.Add(Me.Pic6)
        Me.pnlDatosTalla.Controls.Add(Me.Pic4)
        Me.pnlDatosTalla.Controls.Add(Me.txtPrecioUnitario)
        Me.pnlDatosTalla.Controls.Add(Me.lblPrecioUnitario)
        Me.pnlDatosTalla.Controls.Add(Me.txtTiempoEntrega)
        Me.pnlDatosTalla.Controls.Add(Me.lblTiempoEntrega)
        Me.pnlDatosTalla.Controls.Add(Me.lblProv)
        Me.pnlDatosTalla.Controls.Add(Me.cmbProveedor)
        Me.pnlDatosTalla.Controls.Add(Me.txtFecha)
        Me.pnlDatosTalla.Controls.Add(Me.lblFechaDeCreacion)
        Me.pnlDatosTalla.Location = New System.Drawing.Point(0, 6)
        Me.pnlDatosTalla.Name = "pnlDatosTalla"
        Me.pnlDatosTalla.Size = New System.Drawing.Size(594, 316)
        Me.pnlDatosTalla.TabIndex = 6
        '
        'cmbOrigen
        '
        Me.cmbOrigen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbOrigen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOrigen.FormattingEnabled = True
        Me.cmbOrigen.ItemHeight = 13
        Me.cmbOrigen.Items.AddRange(New Object() {"", "NACIONAL", "IMPORTADO"})
        Me.cmbOrigen.Location = New System.Drawing.Point(193, 211)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(146, 21)
        Me.cmbOrigen.TabIndex = 63
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(140, 214)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "*Origen"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(340, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Moneda"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMoneda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.ItemHeight = 13
        Me.cmbMoneda.Items.AddRange(New Object() {"", "BOLSA", "BOTE", "BULTO", "CAJA", "CAMION", "CIENTO", "CM", "CUBETA", "DCM2", "GALON", "HORA", "JUEGO", "KG", "LAMINAS", "LATA", "LITROS", "M2", "M3", "METROS", "MILLAR", "ML", "PAQUETE", "PARES", "PIEZAS", "PLIEGO", "ROLLOS", "SERVICIO", "TONELADA", "UNIDAD"})
        Me.cmbMoneda.Location = New System.Drawing.Point(395, 103)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(146, 21)
        Me.cmbMoneda.TabIndex = 60
        '
        'txtClaveProv
        '
        Me.txtClaveProv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClaveProv.Location = New System.Drawing.Point(193, 264)
        Me.txtClaveProv.MaxLength = 100
        Me.txtClaveProv.Name = "txtClaveProv"
        Me.txtClaveProv.Size = New System.Drawing.Size(348, 20)
        Me.txtClaveProv.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.txtClaveProv, "Clave del material asiganada " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "por el proveedor")
        '
        'lblClaveProveedor
        '
        Me.lblClaveProveedor.AutoSize = True
        Me.lblClaveProveedor.Location = New System.Drawing.Point(24, 270)
        Me.lblClaveProveedor.Name = "lblClaveProveedor"
        Me.lblClaveProveedor.Size = New System.Drawing.Size(158, 13)
        Me.lblClaveProveedor.TabIndex = 59
        Me.lblClaveProveedor.Text = "Clave del material del proveedor"
        '
        'txtDesProv
        '
        Me.txtDesProv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesProv.Location = New System.Drawing.Point(193, 238)
        Me.txtDesProv.MaxLength = 100
        Me.txtDesProv.Name = "txtDesProv"
        Me.txtDesProv.Size = New System.Drawing.Size(348, 20)
        Me.txtDesProv.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.txtDesProv, "Descripción del material " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "asignada por el proveedor")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 243)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 13)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Descripción del proveedor"
        '
        'picump
        '
        Me.picump.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.seleccionar
        Me.picump.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picump.Location = New System.Drawing.Point(542, 157)
        Me.picump.Name = "picump"
        Me.picump.Size = New System.Drawing.Size(18, 20)
        Me.picump.TabIndex = 56
        Me.picump.TabStop = False
        Me.picump.Visible = False
        '
        'cmbProveedorUM
        '
        Me.cmbProveedorUM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbProveedorUM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProveedorUM.FormattingEnabled = True
        Me.cmbProveedorUM.ItemHeight = 13
        Me.cmbProveedorUM.Location = New System.Drawing.Point(193, 157)
        Me.cmbProveedorUM.Name = "cmbProveedorUM"
        Me.cmbProveedorUM.Size = New System.Drawing.Size(348, 21)
        Me.cmbProveedorUM.TabIndex = 7
        '
        'picumc
        '
        Me.picumc.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.seleccionar
        Me.picumc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picumc.Location = New System.Drawing.Point(542, 130)
        Me.picumc.Name = "picumc"
        Me.picumc.Size = New System.Drawing.Size(18, 20)
        Me.picumc.TabIndex = 54
        Me.picumc.TabStop = False
        Me.picumc.Visible = False
        '
        'PicRend
        '
        Me.PicRend.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.seleccionar
        Me.PicRend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PicRend.Location = New System.Drawing.Point(335, 184)
        Me.PicRend.Name = "PicRend"
        Me.PicRend.Size = New System.Drawing.Size(18, 20)
        Me.PicRend.TabIndex = 52
        Me.PicRend.TabStop = False
        Me.PicRend.Visible = False
        '
        'lblR
        '
        Me.lblR.AutoSize = True
        Me.lblR.Location = New System.Drawing.Point(70, 188)
        Me.lblR.Name = "lblR"
        Me.lblR.Size = New System.Drawing.Size(112, 13)
        Me.lblR.TabIndex = 50
        Me.lblR.Text = "*Factor de Conversión"
        '
        'txtEquivUMProv
        '
        Me.txtEquivUMProv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEquivUMProv.Location = New System.Drawing.Point(193, 184)
        Me.txtEquivUMProv.MaxLength = 7
        Me.txtEquivUMProv.Name = "txtEquivUMProv"
        Me.txtEquivUMProv.Size = New System.Drawing.Size(141, 20)
        Me.txtEquivUMProv.TabIndex = 8
        '
        'cmbProduccionUM
        '
        Me.cmbProduccionUM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbProduccionUM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProduccionUM.FormattingEnabled = True
        Me.cmbProduccionUM.ItemHeight = 13
        Me.cmbProduccionUM.Location = New System.Drawing.Point(193, 129)
        Me.cmbProduccionUM.Name = "cmbProduccionUM"
        Me.cmbProduccionUM.Size = New System.Drawing.Size(348, 21)
        Me.cmbProduccionUM.TabIndex = 6
        '
        'lblUMP
        '
        Me.lblUMP.AutoSize = True
        Me.lblUMP.Location = New System.Drawing.Point(147, 161)
        Me.lblUMP.Name = "lblUMP"
        Me.lblUMP.Size = New System.Drawing.Size(35, 13)
        Me.lblUMP.TabIndex = 48
        Me.lblUMP.Text = "*UMC"
        '
        'lblUM
        '
        Me.lblUM.AutoSize = True
        Me.lblUM.Location = New System.Drawing.Point(147, 134)
        Me.lblUM.Name = "lblUM"
        Me.lblUM.Size = New System.Drawing.Size(35, 13)
        Me.lblUM.TabIndex = 47
        Me.lblUM.Text = "*UMP"
        '
        'txtIdMaterial
        '
        Me.txtIdMaterial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIdMaterial.Location = New System.Drawing.Point(203, 15)
        Me.txtIdMaterial.Name = "txtIdMaterial"
        Me.txtIdMaterial.ReadOnly = True
        Me.txtIdMaterial.Size = New System.Drawing.Size(107, 20)
        Me.txtIdMaterial.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(174, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "ID"
        '
        'Pic7
        '
        Me.Pic7.BackColor = System.Drawing.Color.Transparent
        Me.Pic7.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.seleccionar
        Me.Pic7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Pic7.Location = New System.Drawing.Point(542, 104)
        Me.Pic7.Name = "Pic7"
        Me.Pic7.Size = New System.Drawing.Size(18, 20)
        Me.Pic7.TabIndex = 39
        Me.Pic7.TabStop = False
        Me.Pic7.Visible = False
        '
        'Pic6
        '
        Me.Pic6.BackColor = System.Drawing.Color.Transparent
        Me.Pic6.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.seleccionar
        Me.Pic6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Pic6.Location = New System.Drawing.Point(542, 78)
        Me.Pic6.Name = "Pic6"
        Me.Pic6.Size = New System.Drawing.Size(18, 20)
        Me.Pic6.TabIndex = 38
        Me.Pic6.TabStop = False
        Me.Pic6.Visible = False
        '
        'Pic4
        '
        Me.Pic4.BackColor = System.Drawing.Color.Transparent
        Me.Pic4.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.seleccionar
        Me.Pic4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Pic4.Location = New System.Drawing.Point(542, 51)
        Me.Pic4.Name = "Pic4"
        Me.Pic4.Size = New System.Drawing.Size(18, 20)
        Me.Pic4.TabIndex = 36
        Me.Pic4.TabStop = False
        Me.Pic4.Visible = False
        '
        'txtPrecioUnitario
        '
        Me.txtPrecioUnitario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecioUnitario.Location = New System.Drawing.Point(193, 104)
        Me.txtPrecioUnitario.Name = "txtPrecioUnitario"
        Me.txtPrecioUnitario.Size = New System.Drawing.Size(141, 20)
        Me.txtPrecioUnitario.TabIndex = 5
        '
        'lblPrecioUnitario
        '
        Me.lblPrecioUnitario.AutoSize = True
        Me.lblPrecioUnitario.Location = New System.Drawing.Point(104, 107)
        Me.lblPrecioUnitario.Name = "lblPrecioUnitario"
        Me.lblPrecioUnitario.Size = New System.Drawing.Size(78, 13)
        Me.lblPrecioUnitario.TabIndex = 29
        Me.lblPrecioUnitario.Text = "*Precio unitario"
        '
        'txtTiempoEntrega
        '
        Me.txtTiempoEntrega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTiempoEntrega.Location = New System.Drawing.Point(193, 78)
        Me.txtTiempoEntrega.MaxLength = 30
        Me.txtTiempoEntrega.Name = "txtTiempoEntrega"
        Me.txtTiempoEntrega.Size = New System.Drawing.Size(348, 20)
        Me.txtTiempoEntrega.TabIndex = 4
        '
        'lblTiempoEntrega
        '
        Me.lblTiempoEntrega.AutoSize = True
        Me.lblTiempoEntrega.Location = New System.Drawing.Point(94, 80)
        Me.lblTiempoEntrega.Name = "lblTiempoEntrega"
        Me.lblTiempoEntrega.Size = New System.Drawing.Size(88, 13)
        Me.lblTiempoEntrega.TabIndex = 27
        Me.lblTiempoEntrega.Text = "*Días de entrega"
        '
        'lblProv
        '
        Me.lblProv.AutoSize = True
        Me.lblProv.Location = New System.Drawing.Point(122, 53)
        Me.lblProv.Name = "lblProv"
        Me.lblProv.Size = New System.Drawing.Size(60, 13)
        Me.lblProv.TabIndex = 24
        Me.lblProv.Text = "*Proveedor"
        '
        'cmbProveedor
        '
        Me.cmbProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(193, 51)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(348, 21)
        Me.cmbProveedor.TabIndex = 3
        '
        'txtFecha
        '
        Me.txtFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFecha.Location = New System.Drawing.Point(444, 15)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(107, 20)
        Me.txtFecha.TabIndex = 2
        '
        'lblFechaDeCreacion
        '
        Me.lblFechaDeCreacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFechaDeCreacion.AutoSize = True
        Me.lblFechaDeCreacion.Location = New System.Drawing.Point(394, 18)
        Me.lblFechaDeCreacion.Name = "lblFechaDeCreacion"
        Me.lblFechaDeCreacion.Size = New System.Drawing.Size(37, 13)
        Me.lblFechaDeCreacion.TabIndex = 2
        Me.lblFechaDeCreacion.Text = "Fecha"
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Controls.Add(Me.pnlDatosTalla)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 60)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(594, 328)
        Me.grbParametros.TabIndex = 59
        Me.grbParametros.TabStop = False
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(228, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 60)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'NuevoPrecioMaterialForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(594, 448)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(600, 470)
        Me.MinimumSize = New System.Drawing.Size(600, 470)
        Me.Name = "NuevoPrecioMaterialForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Precio de Material"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlDatosTalla.ResumeLayout(False)
        Me.pnlDatosTalla.PerformLayout()
        CType(Me.picump, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picumc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicRend, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbParametros.ResumeLayout(False)
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents bntSalir As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents pnlDatosTalla As System.Windows.Forms.Panel
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaDeCreacion As System.Windows.Forms.Label
    Friend WithEvents cmbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents txtPrecioUnitario As System.Windows.Forms.TextBox
    Friend WithEvents lblPrecioUnitario As System.Windows.Forms.Label
    Friend WithEvents txtTiempoEntrega As System.Windows.Forms.TextBox
    Friend WithEvents lblTiempoEntrega As System.Windows.Forms.Label
    Friend WithEvents lblProv As System.Windows.Forms.Label
    Friend WithEvents Pic7 As System.Windows.Forms.PictureBox
    Friend WithEvents Pic6 As System.Windows.Forms.PictureBox
    Friend WithEvents Pic4 As System.Windows.Forms.PictureBox
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents txtIdMaterial As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PicRend As System.Windows.Forms.PictureBox
    Friend WithEvents lblR As System.Windows.Forms.Label
    Friend WithEvents txtEquivUMProv As System.Windows.Forms.TextBox
    Friend WithEvents cmbProduccionUM As System.Windows.Forms.ComboBox
    Friend WithEvents lblUM As System.Windows.Forms.Label
    Friend WithEvents lblUMP As System.Windows.Forms.Label
    Friend WithEvents cmbProveedorUM As System.Windows.Forms.ComboBox
    Friend WithEvents picumc As System.Windows.Forms.PictureBox
    Friend WithEvents picump As System.Windows.Forms.PictureBox
    Friend WithEvents txtClaveProv As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblClaveProveedor As System.Windows.Forms.Label
    Friend WithEvents txtDesProv As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOrigen As Windows.Forms.ComboBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
