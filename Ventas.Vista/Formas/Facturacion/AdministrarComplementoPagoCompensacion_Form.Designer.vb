<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdministrarComplementoPagoCompensacion_Form
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdministrarComplementoPagoCompensacion_Form))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTimbrar = New System.Windows.Forms.Panel()
        Me.btnTimbrar = New System.Windows.Forms.Button()
        Me.lblTimbrar = New System.Windows.Forms.Label()
        Me.pnlRelacionarPDF = New System.Windows.Forms.Panel()
        Me.btnRelacionarPDF = New System.Windows.Forms.Button()
        Me.lblRelacionarPDF = New System.Windows.Forms.Label()
        Me.pnlRelacionarXml = New System.Windows.Forms.Panel()
        Me.btnRelacionarXml = New System.Windows.Forms.Button()
        Me.lblRelacionarXml = New System.Windows.Forms.Label()
        Me.pnlSeleccionarCFDI = New System.Windows.Forms.Panel()
        Me.btnSeleccionarCfdi = New System.Windows.Forms.Button()
        Me.lblSeleccionarCfdi = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.lblGenerado = New System.Windows.Forms.Label()
        Me.dtpFechaCfdi = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotalCfdi = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSerieFolioCrp = New System.Windows.Forms.TextBox()
        Me.txtSerieFolioCfdi = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCrpCompensacion = New System.Windows.Forms.TextBox()
        Me.txtCfdiCliente = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaCrp = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.pnlGuardar = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.pnlCerrar = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.grdListado = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ofdRelacionarXml = New System.Windows.Forms.OpenFileDialog()
        Me.ofdRelacionarPdf = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTimbrar.SuspendLayout()
        Me.pnlRelacionarPDF.SuspendLayout()
        Me.pnlRelacionarXml.SuspendLayout()
        Me.pnlSeleccionarCFDI.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlGuardar.SuspendLayout()
        Me.pnlCerrar.SuspendLayout()
        CType(Me.grdListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1145, 548)
        Me.Panel3.TabIndex = 27
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1145, 548)
        Me.Panel1.TabIndex = 3
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTimbrar)
        Me.pnlEncabezado.Controls.Add(Me.pnlRelacionarPDF)
        Me.pnlEncabezado.Controls.Add(Me.pnlRelacionarXml)
        Me.pnlEncabezado.Controls.Add(Me.pnlSeleccionarCFDI)
        Me.pnlEncabezado.Controls.Add(Me.Panel8)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1145, 69)
        Me.pnlEncabezado.TabIndex = 8
        '
        'pnlTimbrar
        '
        Me.pnlTimbrar.Controls.Add(Me.btnTimbrar)
        Me.pnlTimbrar.Controls.Add(Me.lblTimbrar)
        Me.pnlTimbrar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTimbrar.Location = New System.Drawing.Point(203, 0)
        Me.pnlTimbrar.Name = "pnlTimbrar"
        Me.pnlTimbrar.Size = New System.Drawing.Size(51, 69)
        Me.pnlTimbrar.TabIndex = 51
        '
        'btnTimbrar
        '
        Me.btnTimbrar.BackgroundImage = CType(resources.GetObject("btnTimbrar.BackgroundImage"), System.Drawing.Image)
        Me.btnTimbrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnTimbrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnTimbrar.Location = New System.Drawing.Point(10, 8)
        Me.btnTimbrar.Name = "btnTimbrar"
        Me.btnTimbrar.Size = New System.Drawing.Size(32, 32)
        Me.btnTimbrar.TabIndex = 108
        Me.btnTimbrar.UseVisualStyleBackColor = True
        '
        'lblTimbrar
        '
        Me.lblTimbrar.AutoSize = True
        Me.lblTimbrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTimbrar.Location = New System.Drawing.Point(5, 41)
        Me.lblTimbrar.Name = "lblTimbrar"
        Me.lblTimbrar.Size = New System.Drawing.Size(42, 13)
        Me.lblTimbrar.TabIndex = 107
        Me.lblTimbrar.Text = "Timbrar"
        '
        'pnlRelacionarPDF
        '
        Me.pnlRelacionarPDF.Controls.Add(Me.btnRelacionarPDF)
        Me.pnlRelacionarPDF.Controls.Add(Me.lblRelacionarPDF)
        Me.pnlRelacionarPDF.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlRelacionarPDF.Location = New System.Drawing.Point(138, 0)
        Me.pnlRelacionarPDF.Name = "pnlRelacionarPDF"
        Me.pnlRelacionarPDF.Size = New System.Drawing.Size(65, 69)
        Me.pnlRelacionarPDF.TabIndex = 50
        '
        'btnRelacionarPDF
        '
        Me.btnRelacionarPDF.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRelacionarPDF.Image = Global.Ventas.Vista.My.Resources.Resources.agregar_pdf
        Me.btnRelacionarPDF.Location = New System.Drawing.Point(15, 7)
        Me.btnRelacionarPDF.Name = "btnRelacionarPDF"
        Me.btnRelacionarPDF.Size = New System.Drawing.Size(32, 32)
        Me.btnRelacionarPDF.TabIndex = 22
        Me.btnRelacionarPDF.UseVisualStyleBackColor = True
        '
        'lblRelacionarPDF
        '
        Me.lblRelacionarPDF.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblRelacionarPDF.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRelacionarPDF.Location = New System.Drawing.Point(3, 41)
        Me.lblRelacionarPDF.Name = "lblRelacionarPDF"
        Me.lblRelacionarPDF.Size = New System.Drawing.Size(59, 27)
        Me.lblRelacionarPDF.TabIndex = 23
        Me.lblRelacionarPDF.Text = "Relacionar PDF"
        Me.lblRelacionarPDF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlRelacionarXml
        '
        Me.pnlRelacionarXml.Controls.Add(Me.btnRelacionarXml)
        Me.pnlRelacionarXml.Controls.Add(Me.lblRelacionarXml)
        Me.pnlRelacionarXml.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlRelacionarXml.Location = New System.Drawing.Point(71, 0)
        Me.pnlRelacionarXml.Name = "pnlRelacionarXml"
        Me.pnlRelacionarXml.Size = New System.Drawing.Size(67, 69)
        Me.pnlRelacionarXml.TabIndex = 49
        '
        'btnRelacionarXml
        '
        Me.btnRelacionarXml.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRelacionarXml.Image = CType(resources.GetObject("btnRelacionarXml.Image"), System.Drawing.Image)
        Me.btnRelacionarXml.Location = New System.Drawing.Point(18, 7)
        Me.btnRelacionarXml.Name = "btnRelacionarXml"
        Me.btnRelacionarXml.Size = New System.Drawing.Size(32, 32)
        Me.btnRelacionarXml.TabIndex = 31
        Me.btnRelacionarXml.UseVisualStyleBackColor = True
        '
        'lblRelacionarXml
        '
        Me.lblRelacionarXml.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblRelacionarXml.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRelacionarXml.Location = New System.Drawing.Point(4, 40)
        Me.lblRelacionarXml.Name = "lblRelacionarXml"
        Me.lblRelacionarXml.Size = New System.Drawing.Size(60, 27)
        Me.lblRelacionarXml.TabIndex = 32
        Me.lblRelacionarXml.Text = "Relacionar XML"
        Me.lblRelacionarXml.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlSeleccionarCFDI
        '
        Me.pnlSeleccionarCFDI.Controls.Add(Me.btnSeleccionarCfdi)
        Me.pnlSeleccionarCFDI.Controls.Add(Me.lblSeleccionarCfdi)
        Me.pnlSeleccionarCFDI.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSeleccionarCFDI.Location = New System.Drawing.Point(0, 0)
        Me.pnlSeleccionarCFDI.Name = "pnlSeleccionarCFDI"
        Me.pnlSeleccionarCFDI.Size = New System.Drawing.Size(71, 69)
        Me.pnlSeleccionarCFDI.TabIndex = 48
        '
        'btnSeleccionarCfdi
        '
        Me.btnSeleccionarCfdi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSeleccionarCfdi.Image = Global.Ventas.Vista.My.Resources.Resources.prioridad
        Me.btnSeleccionarCfdi.Location = New System.Drawing.Point(20, 7)
        Me.btnSeleccionarCfdi.Name = "btnSeleccionarCfdi"
        Me.btnSeleccionarCfdi.Size = New System.Drawing.Size(32, 32)
        Me.btnSeleccionarCfdi.TabIndex = 22
        Me.btnSeleccionarCfdi.UseVisualStyleBackColor = True
        '
        'lblSeleccionarCfdi
        '
        Me.lblSeleccionarCfdi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSeleccionarCfdi.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSeleccionarCfdi.Location = New System.Drawing.Point(3, 41)
        Me.lblSeleccionarCfdi.Name = "lblSeleccionarCfdi"
        Me.lblSeleccionarCfdi.Size = New System.Drawing.Size(68, 27)
        Me.lblSeleccionarCfdi.TabIndex = 23
        Me.lblSeleccionarCfdi.Text = "Seleccionar CFDI"
        Me.lblSeleccionarCfdi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.PictureBox2)
        Me.Panel8.Controls.Add(Me.lblTitulo)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel8.Location = New System.Drawing.Point(566, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(579, 69)
        Me.Panel8.TabIndex = 20
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(0, 9)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(513, 48)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Administrador de CFDI de Complemento de Recepción de Pagos Compensaciones"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.Panel2)
        Me.pnlFiltros.Controls.Add(Me.grbFiltros)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 69)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1145, 99)
        Me.pnlFiltros.TabIndex = 14
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btnAbajo)
        Me.Panel2.Controls.Add(Me.btnArriba)
        Me.Panel2.Location = New System.Drawing.Point(1077, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(59, 22)
        Me.Panel2.TabIndex = 118
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(32, 0)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 119
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(6, 0)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 118
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'grbFiltros
        '
        Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbFiltros.Controls.Add(Me.lblGenerado)
        Me.grbFiltros.Controls.Add(Me.dtpFechaCfdi)
        Me.grbFiltros.Controls.Add(Me.Label5)
        Me.grbFiltros.Controls.Add(Me.txtTotalCfdi)
        Me.grbFiltros.Controls.Add(Me.Label4)
        Me.grbFiltros.Controls.Add(Me.txtSerieFolioCrp)
        Me.grbFiltros.Controls.Add(Me.txtSerieFolioCfdi)
        Me.grbFiltros.Controls.Add(Me.Label1)
        Me.grbFiltros.Controls.Add(Me.Label3)
        Me.grbFiltros.Controls.Add(Me.txtCrpCompensacion)
        Me.grbFiltros.Controls.Add(Me.txtCfdiCliente)
        Me.grbFiltros.Controls.Add(Me.Panel4)
        Me.grbFiltros.Controls.Add(Me.Label10)
        Me.grbFiltros.Controls.Add(Me.Label2)
        Me.grbFiltros.Controls.Add(Me.dtpFechaCrp)
        Me.grbFiltros.Controls.Add(Me.Label14)
        Me.grbFiltros.Controls.Add(Me.cmbCliente)
        Me.grbFiltros.Controls.Add(Me.lblCliente)
        Me.grbFiltros.Location = New System.Drawing.Point(3, 22)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1139, 71)
        Me.grbFiltros.TabIndex = 113
        Me.grbFiltros.TabStop = False
        '
        'lblGenerado
        '
        Me.lblGenerado.AutoSize = True
        Me.lblGenerado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGenerado.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblGenerado.Location = New System.Drawing.Point(866, 75)
        Me.lblGenerado.Name = "lblGenerado"
        Me.lblGenerado.Size = New System.Drawing.Size(112, 16)
        Me.lblGenerado.TabIndex = 130
        Me.lblGenerado.Text = "POR TIMBRAR"
        Me.lblGenerado.Visible = False
        '
        'dtpFechaCfdi
        '
        Me.dtpFechaCfdi.Enabled = False
        Me.dtpFechaCfdi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaCfdi.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaCfdi.Location = New System.Drawing.Point(727, 42)
        Me.dtpFechaCfdi.Name = "dtpFechaCfdi"
        Me.dtpFechaCfdi.Size = New System.Drawing.Size(115, 20)
        Me.dtpFechaCfdi.TabIndex = 129
        Me.dtpFechaCfdi.Value = New Date(2018, 12, 1, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(684, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 128
        Me.Label5.Text = "Fecha"
        '
        'txtTotalCfdi
        '
        Me.txtTotalCfdi.Location = New System.Drawing.Point(904, 42)
        Me.txtTotalCfdi.Name = "txtTotalCfdi"
        Me.txtTotalCfdi.ReadOnly = True
        Me.txtTotalCfdi.Size = New System.Drawing.Size(115, 20)
        Me.txtTotalCfdi.TabIndex = 127
        Me.txtTotalCfdi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(866, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 126
        Me.Label4.Text = "Total"
        '
        'txtSerieFolioCrp
        '
        Me.txtSerieFolioCrp.Location = New System.Drawing.Point(543, 71)
        Me.txtSerieFolioCrp.Name = "txtSerieFolioCrp"
        Me.txtSerieFolioCrp.ReadOnly = True
        Me.txtSerieFolioCrp.Size = New System.Drawing.Size(115, 20)
        Me.txtSerieFolioCrp.TabIndex = 125
        Me.txtSerieFolioCrp.Visible = False
        '
        'txtSerieFolioCfdi
        '
        Me.txtSerieFolioCfdi.Location = New System.Drawing.Point(543, 42)
        Me.txtSerieFolioCfdi.Name = "txtSerieFolioCfdi"
        Me.txtSerieFolioCfdi.ReadOnly = True
        Me.txtSerieFolioCfdi.Size = New System.Drawing.Size(115, 20)
        Me.txtSerieFolioCfdi.TabIndex = 124
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(473, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 123
        Me.Label1.Text = "Serie y Folio"
        Me.Label1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(473, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 122
        Me.Label3.Text = "Serie y Folio"
        '
        'txtCrpCompensacion
        '
        Me.txtCrpCompensacion.Location = New System.Drawing.Point(135, 71)
        Me.txtCrpCompensacion.Name = "txtCrpCompensacion"
        Me.txtCrpCompensacion.ReadOnly = True
        Me.txtCrpCompensacion.Size = New System.Drawing.Size(313, 20)
        Me.txtCrpCompensacion.TabIndex = 121
        Me.txtCrpCompensacion.Visible = False
        '
        'txtCfdiCliente
        '
        Me.txtCfdiCliente.Location = New System.Drawing.Point(135, 42)
        Me.txtCfdiCliente.Name = "txtCfdiCliente"
        Me.txtCfdiCliente.ReadOnly = True
        Me.txtCfdiCliente.Size = New System.Drawing.Size(313, 20)
        Me.txtCfdiCliente.TabIndex = 120
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnLimpiar)
        Me.Panel4.Controls.Add(Me.btnBuscar)
        Me.Panel4.Controls.Add(Me.lblLimpiar)
        Me.Panel4.Controls.Add(Me.lblBuscar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(1037, 16)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(99, 52)
        Me.Panel4.TabIndex = 119
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(59, 4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 52
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(11, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 51
        Me.btnBuscar.UseVisualStyleBackColor = True
        Me.btnBuscar.Visible = False
        '
        'lblLimpiar
        '
        Me.lblLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(56, 36)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 53
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblBuscar
        '
        Me.lblBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(8, 36)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 54
        Me.lblBuscar.Text = "Mostrar"
        Me.lblBuscar.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(9, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 13)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "CRP de compensación"
        Me.Label10.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(9, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 13)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "CFDI Ingreso del cliente"
        '
        'dtpFechaCrp
        '
        Me.dtpFechaCrp.Enabled = False
        Me.dtpFechaCrp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaCrp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaCrp.Location = New System.Drawing.Point(727, 71)
        Me.dtpFechaCrp.Name = "dtpFechaCrp"
        Me.dtpFechaCrp.Size = New System.Drawing.Size(115, 20)
        Me.dtpFechaCrp.TabIndex = 86
        Me.dtpFechaCrp.Value = New Date(2018, 12, 1, 0, 0, 0, 0)
        Me.dtpFechaCrp.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(684, 74)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 13)
        Me.Label14.TabIndex = 85
        Me.Label14.Text = "Fecha"
        Me.Label14.Visible = False
        '
        'cmbCliente
        '
        Me.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCliente.ForeColor = System.Drawing.Color.Black
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(54, 15)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(394, 21)
        Me.cmbCliente.TabIndex = 44
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.ForeColor = System.Drawing.Color.Black
        Me.lblCliente.Location = New System.Drawing.Point(9, 18)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblCliente.TabIndex = 43
        Me.lblCliente.Text = "Cliente"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlOperaciones)
        Me.pnlPie.Controls.Add(Me.pnlEstado)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 488)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1145, 60)
        Me.pnlPie.TabIndex = 17
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.pnlGuardar)
        Me.pnlOperaciones.Controls.Add(Me.pnlCerrar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(1004, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(141, 60)
        Me.pnlOperaciones.TabIndex = 24
        '
        'pnlGuardar
        '
        Me.pnlGuardar.Controls.Add(Me.btnGuardar)
        Me.pnlGuardar.Controls.Add(Me.lblGuardar)
        Me.pnlGuardar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlGuardar.Location = New System.Drawing.Point(27, 0)
        Me.pnlGuardar.Name = "pnlGuardar"
        Me.pnlGuardar.Size = New System.Drawing.Size(57, 60)
        Me.pnlGuardar.TabIndex = 49
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(13, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 31
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(7, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 32
        Me.lblGuardar.Text = "Guardar"
        Me.lblGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlCerrar
        '
        Me.pnlCerrar.Controls.Add(Me.btnCerrar)
        Me.pnlCerrar.Controls.Add(Me.lblCerrar)
        Me.pnlCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCerrar.Location = New System.Drawing.Point(84, 0)
        Me.pnlCerrar.Name = "pnlCerrar"
        Me.pnlCerrar.Size = New System.Drawing.Size(57, 60)
        Me.pnlCerrar.TabIndex = 48
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(13, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 28
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(13, 41)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 29
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlEstado
        '
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEstado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1145, 60)
        Me.pnlEstado.TabIndex = 22
        '
        'grdListado
        '
        Me.grdListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListado.Location = New System.Drawing.Point(0, 168)
        Me.grdListado.MainView = Me.GridView1
        Me.grdListado.Name = "grdListado"
        Me.grdListado.Size = New System.Drawing.Size(1145, 320)
        Me.grdListado.TabIndex = 19
        Me.grdListado.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.White
        Me.GridView1.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView1.Appearance.OddRow.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GridView1.Appearance.OddRow.BackColor2 = System.Drawing.Color.LightSteelBlue
        Me.GridView1.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView1.GridControl = Me.grdListado
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(511, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(68, 69)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 48
        Me.PictureBox2.TabStop = False
        '
        'AdministrarComplementoPagoCompensacion_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 548)
        Me.Controls.Add(Me.grdListado)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "AdministrarComplementoPagoCompensacion_Form"
        Me.Text = "Administrador de CFDI de Complemento de Recepción de Pagos Compensación"
        Me.Panel1.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTimbrar.ResumeLayout(False)
        Me.pnlTimbrar.PerformLayout()
        Me.pnlRelacionarPDF.ResumeLayout(False)
        Me.pnlRelacionarXml.ResumeLayout(False)
        Me.pnlSeleccionarCFDI.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.pnlFiltros.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlGuardar.ResumeLayout(False)
        Me.pnlGuardar.PerformLayout()
        Me.pnlCerrar.ResumeLayout(False)
        Me.pnlCerrar.PerformLayout()
        CType(Me.grdListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlFiltros As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnArriba As Button
    Friend WithEvents grbFiltros As GroupBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents lblLimpiar As Label
    Friend WithEvents lblBuscar As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFechaCrp As DateTimePicker
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbCliente As ComboBox
    Friend WithEvents lblCliente As Label
    Friend WithEvents txtTotalCfdi As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSerieFolioCrp As TextBox
    Friend WithEvents txtSerieFolioCfdi As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCrpCompensacion As TextBox
    Friend WithEvents txtCfdiCliente As TextBox
    Friend WithEvents dtpFechaCfdi As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlOperaciones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlEstado As Panel
    Friend WithEvents pnlGuardar As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblGuardar As Label
    Friend WithEvents pnlCerrar As Panel
    Friend WithEvents pnlRelacionarPDF As Panel
    Friend WithEvents btnRelacionarPDF As Button
    Friend WithEvents lblRelacionarPDF As Label
    Friend WithEvents pnlRelacionarXml As Panel
    Friend WithEvents btnRelacionarXml As Button
    Friend WithEvents lblRelacionarXml As Label
    Friend WithEvents pnlSeleccionarCFDI As Panel
    Friend WithEvents btnSeleccionarCfdi As Button
    Friend WithEvents lblSeleccionarCfdi As Label
    Friend WithEvents grdListado As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ofdRelacionarXml As OpenFileDialog
    Friend WithEvents ofdRelacionarPdf As OpenFileDialog
    Friend WithEvents lblGenerado As Label
    Friend WithEvents pnlTimbrar As Panel
    Friend WithEvents btnTimbrar As Button
    Friend WithEvents lblTimbrar As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
