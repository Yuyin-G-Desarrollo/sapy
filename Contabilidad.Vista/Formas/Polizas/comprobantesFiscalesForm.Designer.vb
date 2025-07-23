<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class comprobantesFiscalesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(comprobantesFiscalesForm))
        Me.grdComprobantesFiscales = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlBotonesAlto = New System.Windows.Forms.Panel()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.dtpAl = New System.Windows.Forms.DateTimePicker()
        Me.dtpDe = New System.Windows.Forms.DateTimePicker()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.pnlBotonesVisibles = New System.Windows.Forms.Panel()
        Me.lbllimpiar = New System.Windows.Forms.Label()
        Me.btnlimpiar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblAl = New System.Windows.Forms.Label()
        Me.lblDe = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblCopiarA = New System.Windows.Forms.Label()
        Me.btnCopiarA = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblVisor = New System.Windows.Forms.Label()
        Me.btnVisor = New System.Windows.Forms.Button()
        Me.lblPDF = New System.Windows.Forms.Label()
        Me.btnPDF = New System.Windows.Forms.Button()
        Me.lblVerXml = New System.Windows.Forms.Label()
        Me.pnlImg = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnsalir = New System.Windows.Forms.Button()
        CType(Me.grdComprobantesFiscales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotonesAlto.SuspendLayout()
        Me.pnlBotonesVisibles.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlImg.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdComprobantesFiscales
        '
        Me.grdComprobantesFiscales.CausesValidation = False
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdComprobantesFiscales.DisplayLayout.Appearance = Appearance1
        Me.grdComprobantesFiscales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdComprobantesFiscales.Location = New System.Drawing.Point(0, 197)
        Me.grdComprobantesFiscales.Name = "grdComprobantesFiscales"
        Me.grdComprobantesFiscales.Size = New System.Drawing.Size(1020, 268)
        Me.grdComprobantesFiscales.TabIndex = 23
        '
        'pnlBotonesAlto
        '
        Me.pnlBotonesAlto.Controls.Add(Me.txtFolio)
        Me.pnlBotonesAlto.Controls.Add(Me.lblFolio)
        Me.pnlBotonesAlto.Controls.Add(Me.cmbTipo)
        Me.pnlBotonesAlto.Controls.Add(Me.lblTipo)
        Me.pnlBotonesAlto.Controls.Add(Me.lblCliente)
        Me.pnlBotonesAlto.Controls.Add(Me.cmbCliente)
        Me.pnlBotonesAlto.Controls.Add(Me.dtpAl)
        Me.pnlBotonesAlto.Controls.Add(Me.dtpDe)
        Me.pnlBotonesAlto.Controls.Add(Me.cmbNave)
        Me.pnlBotonesAlto.Controls.Add(Me.lblNave)
        Me.pnlBotonesAlto.Controls.Add(Me.lblProveedor)
        Me.pnlBotonesAlto.Controls.Add(Me.cmbProveedor)
        Me.pnlBotonesAlto.Controls.Add(Me.pnlBotonesVisibles)
        Me.pnlBotonesAlto.Controls.Add(Me.lblEmpresa)
        Me.pnlBotonesAlto.Controls.Add(Me.cmbEmpresa)
        Me.pnlBotonesAlto.Controls.Add(Me.lblAl)
        Me.pnlBotonesAlto.Controls.Add(Me.lblDe)
        Me.pnlBotonesAlto.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBotonesAlto.Location = New System.Drawing.Point(0, 60)
        Me.pnlBotonesAlto.Name = "pnlBotonesAlto"
        Me.pnlBotonesAlto.Size = New System.Drawing.Size(1020, 137)
        Me.pnlBotonesAlto.TabIndex = 21
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(710, 78)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(203, 20)
        Me.txtFolio.TabIndex = 26
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Location = New System.Drawing.Point(671, 78)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(32, 13)
        Me.lblFolio.TabIndex = 25
        Me.lblFolio.Text = "Folio:"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(711, 40)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(202, 21)
        Me.cmbTipo.TabIndex = 24
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Location = New System.Drawing.Point(671, 46)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(31, 13)
        Me.lblTipo.TabIndex = 23
        Me.lblTipo.Text = "Tipo:"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(35, 106)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(42, 13)
        Me.lblCliente.TabIndex = 21
        Me.lblCliente.Text = "Cliente:"
        '
        'cmbCliente
        '
        Me.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCliente.Enabled = False
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Items.AddRange(New Object() {"", "NUEVAS", "GENERADAS"})
        Me.cmbCliente.Location = New System.Drawing.Point(90, 106)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(310, 21)
        Me.cmbCliente.TabIndex = 22
        '
        'dtpAl
        '
        Me.dtpAl.Location = New System.Drawing.Point(456, 73)
        Me.dtpAl.Name = "dtpAl"
        Me.dtpAl.Size = New System.Drawing.Size(202, 20)
        Me.dtpAl.TabIndex = 20
        '
        'dtpDe
        '
        Me.dtpDe.Location = New System.Drawing.Point(456, 40)
        Me.dtpDe.Name = "dtpDe"
        Me.dtpDe.Size = New System.Drawing.Size(202, 20)
        Me.dtpDe.TabIndex = 19
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(456, 103)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(202, 21)
        Me.cmbNave.TabIndex = 16
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(416, 109)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(36, 13)
        Me.lblNave.TabIndex = 15
        Me.lblNave.Text = "Nave:"
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(25, 72)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(59, 13)
        Me.lblProveedor.TabIndex = 8
        Me.lblProveedor.Text = "Proveedor:"
        '
        'cmbProveedor
        '
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Items.AddRange(New Object() {"", "NUEVAS", "GENERADAS"})
        Me.cmbProveedor.Location = New System.Drawing.Point(90, 72)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(310, 21)
        Me.cmbProveedor.TabIndex = 10
        '
        'pnlBotonesVisibles
        '
        Me.pnlBotonesVisibles.Controls.Add(Me.lbllimpiar)
        Me.pnlBotonesVisibles.Controls.Add(Me.btnlimpiar)
        Me.pnlBotonesVisibles.Controls.Add(Me.lblMostrar)
        Me.pnlBotonesVisibles.Controls.Add(Me.btnMostrar)
        Me.pnlBotonesVisibles.Controls.Add(Me.btnArriba)
        Me.pnlBotonesVisibles.Controls.Add(Me.btnAbajo)
        Me.pnlBotonesVisibles.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonesVisibles.Location = New System.Drawing.Point(919, 0)
        Me.pnlBotonesVisibles.Name = "pnlBotonesVisibles"
        Me.pnlBotonesVisibles.Size = New System.Drawing.Size(101, 137)
        Me.pnlBotonesVisibles.TabIndex = 18
        '
        'lbllimpiar
        '
        Me.lbllimpiar.AutoSize = True
        Me.lbllimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbllimpiar.Location = New System.Drawing.Point(57, 78)
        Me.lbllimpiar.Name = "lbllimpiar"
        Me.lbllimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lbllimpiar.TabIndex = 23
        Me.lbllimpiar.Text = "Limpiar"
        '
        'btnlimpiar
        '
        Me.btnlimpiar.Image = Global.Contabilidad.Vista.My.Resources.Resources.limpiar_32
        Me.btnlimpiar.Location = New System.Drawing.Point(61, 40)
        Me.btnlimpiar.Name = "btnlimpiar"
        Me.btnlimpiar.Size = New System.Drawing.Size(31, 32)
        Me.btnlimpiar.TabIndex = 22
        Me.btnlimpiar.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(11, 78)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 18
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(20, 43)
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
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(26, 40)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(51, 13)
        Me.lblEmpresa.TabIndex = 7
        Me.lblEmpresa.Text = "Empresa:"
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(90, 40)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(310, 21)
        Me.cmbEmpresa.TabIndex = 9
        '
        'lblAl
        '
        Me.lblAl.AutoSize = True
        Me.lblAl.Location = New System.Drawing.Point(421, 75)
        Me.lblAl.Name = "lblAl"
        Me.lblAl.Size = New System.Drawing.Size(19, 13)
        Me.lblAl.TabIndex = 12
        Me.lblAl.Text = "Al:"
        '
        'lblDe
        '
        Me.lblDe.AutoSize = True
        Me.lblDe.Location = New System.Drawing.Point(421, 43)
        Me.lblDe.Name = "lblDe"
        Me.lblDe.Size = New System.Drawing.Size(26, 13)
        Me.lblDe.TabIndex = 11
        Me.lblDe.Text = "Del:"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.Button1)
        Me.pnlHeader.Controls.Add(Me.lblCopiarA)
        Me.pnlHeader.Controls.Add(Me.btnCopiarA)
        Me.pnlHeader.Controls.Add(Me.lblExportar)
        Me.pnlHeader.Controls.Add(Me.btnExportar)
        Me.pnlHeader.Controls.Add(Me.lblVisor)
        Me.pnlHeader.Controls.Add(Me.btnVisor)
        Me.pnlHeader.Controls.Add(Me.lblPDF)
        Me.pnlHeader.Controls.Add(Me.btnPDF)
        Me.pnlHeader.Controls.Add(Me.lblVerXml)
        Me.pnlHeader.Controls.Add(Me.pnlImg)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1020, 60)
        Me.pnlHeader.TabIndex = 22
        '
        'Button1
        '
        Me.Button1.Image = Global.Contabilidad.Vista.My.Resources.Resources.xml_32
        Me.Button1.Location = New System.Drawing.Point(12, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(34, 35)
        Me.Button1.TabIndex = 57
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblCopiarA
        '
        Me.lblCopiarA.AutoSize = True
        Me.lblCopiarA.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCopiarA.Location = New System.Drawing.Point(176, 39)
        Me.lblCopiarA.Name = "lblCopiarA"
        Me.lblCopiarA.Size = New System.Drawing.Size(46, 13)
        Me.lblCopiarA.TabIndex = 56
        Me.lblCopiarA.Text = "Copiar a"
        '
        'btnCopiarA
        '
        Me.btnCopiarA.Image = Global.Contabilidad.Vista.My.Resources.Resources.copiar_32
        Me.btnCopiarA.Location = New System.Drawing.Point(179, 3)
        Me.btnCopiarA.Name = "btnCopiarA"
        Me.btnCopiarA.Size = New System.Drawing.Size(34, 35)
        Me.btnCopiarA.TabIndex = 55
        Me.btnCopiarA.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(129, 39)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 54
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Contabilidad.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(132, 3)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(34, 35)
        Me.btnExportar.TabIndex = 53
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblVisor
        '
        Me.lblVisor.AutoSize = True
        Me.lblVisor.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblVisor.Location = New System.Drawing.Point(96, 39)
        Me.lblVisor.Name = "lblVisor"
        Me.lblVisor.Size = New System.Drawing.Size(30, 13)
        Me.lblVisor.TabIndex = 52
        Me.lblVisor.Text = "Visor"
        '
        'btnVisor
        '
        Me.btnVisor.Image = Global.Contabilidad.Vista.My.Resources.Resources.imprimir_32
        Me.btnVisor.Location = New System.Drawing.Point(92, 3)
        Me.btnVisor.Name = "btnVisor"
        Me.btnVisor.Size = New System.Drawing.Size(34, 35)
        Me.btnVisor.TabIndex = 51
        Me.btnVisor.UseVisualStyleBackColor = True
        '
        'lblPDF
        '
        Me.lblPDF.AutoSize = True
        Me.lblPDF.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblPDF.Location = New System.Drawing.Point(56, 39)
        Me.lblPDF.Name = "lblPDF"
        Me.lblPDF.Size = New System.Drawing.Size(28, 13)
        Me.lblPDF.TabIndex = 50
        Me.lblPDF.Text = "PDF"
        '
        'btnPDF
        '
        Me.btnPDF.Image = Global.Contabilidad.Vista.My.Resources.Resources.pdf_32
        Me.btnPDF.Location = New System.Drawing.Point(52, 3)
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Size = New System.Drawing.Size(34, 35)
        Me.btnPDF.TabIndex = 49
        Me.btnPDF.UseVisualStyleBackColor = True
        '
        'lblVerXml
        '
        Me.lblVerXml.AutoSize = True
        Me.lblVerXml.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblVerXml.Location = New System.Drawing.Point(16, 39)
        Me.lblVerXml.Name = "lblVerXml"
        Me.lblVerXml.Size = New System.Drawing.Size(24, 13)
        Me.lblVerXml.TabIndex = 48
        Me.lblVerXml.Text = "Xml"
        '
        'pnlImg
        '
        Me.pnlImg.Controls.Add(Me.PictureBox1)
        Me.pnlImg.Controls.Add(Me.lblTitulo)
        Me.pnlImg.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlImg.Location = New System.Drawing.Point(740, 0)
        Me.pnlImg.Name = "pnlImg"
        Me.pnlImg.Size = New System.Drawing.Size(280, 60)
        Me.pnlImg.TabIndex = 46
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(212, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(9, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(197, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Comprobantes Fiscales"
        '
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.pnlBotones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 465)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1020, 60)
        Me.pnlEstado.TabIndex = 20
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.lblSalir)
        Me.pnlBotones.Controls.Add(Me.btnsalir)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(832, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(188, 60)
        Me.pnlBotones.TabIndex = 7
        '
        'lblSalir
        '
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(138, 41)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(27, 13)
        Me.lblSalir.TabIndex = 9
        Me.lblSalir.Text = "Salir"
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnsalir.Location = New System.Drawing.Point(134, 5)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(34, 35)
        Me.btnsalir.TabIndex = 8
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'comprobantesFiscalesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1020, 525)
        Me.Controls.Add(Me.grdComprobantesFiscales)
        Me.Controls.Add(Me.pnlBotonesAlto)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlEstado)
        Me.Name = "comprobantesFiscalesForm"
        Me.Text = "Comprobantes Fiscales"
        CType(Me.grdComprobantesFiscales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotonesAlto.ResumeLayout(False)
        Me.pnlBotonesAlto.PerformLayout()
        Me.pnlBotonesVisibles.ResumeLayout(False)
        Me.pnlBotonesVisibles.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlImg.ResumeLayout(False)
        Me.pnlImg.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdComprobantesFiscales As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlBotonesAlto As System.Windows.Forms.Panel
    Friend WithEvents dtpAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDe As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents cmbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents pnlBotonesVisibles As System.Windows.Forms.Panel
    Friend WithEvents lbllimpiar As System.Windows.Forms.Label
    Friend WithEvents btnlimpiar As System.Windows.Forms.Button
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents lblAl As System.Windows.Forms.Label
    Friend WithEvents lblDe As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlImg As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents lblCopiarA As System.Windows.Forms.Label
    Friend WithEvents btnCopiarA As System.Windows.Forms.Button
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents lblVisor As System.Windows.Forms.Label
    Friend WithEvents btnVisor As System.Windows.Forms.Button
    Friend WithEvents lblPDF As System.Windows.Forms.Label
    Friend WithEvents btnPDF As System.Windows.Forms.Button
    Friend WithEvents lblVerXml As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
