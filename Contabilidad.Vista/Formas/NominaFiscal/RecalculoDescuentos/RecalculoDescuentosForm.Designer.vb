<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecalculoDescuentosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecalculoDescuentosForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.rdoReal = New System.Windows.Forms.RadioButton()
        Me.rdoFiscal = New System.Windows.Forms.RadioButton()
        Me.lblSalarioMinimo = New System.Windows.Forms.Label()
        Me.dtpFechaCalculo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.cmbAnio = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbPatron = New System.Windows.Forms.ComboBox()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAyuda = New System.Windows.Forms.Panel()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.pnlAutorizar = New System.Windows.Forms.Panel()
        Me.lblAutorizar = New System.Windows.Forms.Label()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.pnlCalcular = New System.Windows.Forms.Panel()
        Me.btnCalcular = New System.Windows.Forms.Button()
        Me.lblCalcular = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlImprimir = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.grdListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.menuAyuda = New System.Windows.Forms.ContextMenuStrip()
        Me.AyudaRecalculoDescuentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecalculoDescuentosArchivoWordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecalculoDescuentosPropuestaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlFiltros.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAyuda.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlAutorizar.SuspendLayout()
        Me.pnlCalcular.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlImprimir.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        CType(Me.grdListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuAyuda.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.Panel2)
        Me.pnlFiltros.Controls.Add(Me.grbFiltros)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 69)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1191, 103)
        Me.pnlFiltros.TabIndex = 22
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btnAbajo)
        Me.Panel2.Controls.Add(Me.btnArriba)
        Me.Panel2.Location = New System.Drawing.Point(1123, 3)
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
        Me.grbFiltros.Controls.Add(Me.Panel5)
        Me.grbFiltros.Controls.Add(Me.lblSalarioMinimo)
        Me.grbFiltros.Controls.Add(Me.dtpFechaCalculo)
        Me.grbFiltros.Controls.Add(Me.Label1)
        Me.grbFiltros.Controls.Add(Me.Panel4)
        Me.grbFiltros.Controls.Add(Me.cmbAnio)
        Me.grbFiltros.Controls.Add(Me.Label2)
        Me.grbFiltros.Controls.Add(Me.Label14)
        Me.grbFiltros.Controls.Add(Me.cmbPatron)
        Me.grbFiltros.Controls.Add(Me.lblEmpresa)
        Me.grbFiltros.Location = New System.Drawing.Point(3, 22)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1185, 75)
        Me.grbFiltros.TabIndex = 113
        Me.grbFiltros.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.rdoReal)
        Me.Panel5.Controls.Add(Me.rdoFiscal)
        Me.Panel5.Location = New System.Drawing.Point(757, 24)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(122, 37)
        Me.Panel5.TabIndex = 124
        '
        'rdoReal
        '
        Me.rdoReal.AutoSize = True
        Me.rdoReal.Location = New System.Drawing.Point(67, 9)
        Me.rdoReal.Name = "rdoReal"
        Me.rdoReal.Size = New System.Drawing.Size(47, 17)
        Me.rdoReal.TabIndex = 1
        Me.rdoReal.TabStop = True
        Me.rdoReal.Text = "Real"
        Me.rdoReal.UseVisualStyleBackColor = True
        '
        'rdoFiscal
        '
        Me.rdoFiscal.AutoSize = True
        Me.rdoFiscal.Checked = True
        Me.rdoFiscal.Location = New System.Drawing.Point(9, 9)
        Me.rdoFiscal.Name = "rdoFiscal"
        Me.rdoFiscal.Size = New System.Drawing.Size(52, 17)
        Me.rdoFiscal.TabIndex = 0
        Me.rdoFiscal.TabStop = True
        Me.rdoFiscal.Text = "Fiscal"
        Me.rdoFiscal.UseVisualStyleBackColor = True
        '
        'lblSalarioMinimo
        '
        Me.lblSalarioMinimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalarioMinimo.Location = New System.Drawing.Point(617, 44)
        Me.lblSalarioMinimo.Name = "lblSalarioMinimo"
        Me.lblSalarioMinimo.Size = New System.Drawing.Size(74, 13)
        Me.lblSalarioMinimo.TabIndex = 123
        Me.lblSalarioMinimo.Text = "0"
        Me.lblSalarioMinimo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpFechaCalculo
        '
        Me.dtpFechaCalculo.Enabled = False
        Me.dtpFechaCalculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaCalculo.Location = New System.Drawing.Point(310, 46)
        Me.dtpFechaCalculo.Name = "dtpFechaCalculo"
        Me.dtpFechaCalculo.Size = New System.Drawing.Size(268, 20)
        Me.dtpFechaCalculo.TabIndex = 120
        Me.dtpFechaCalculo.Value = New Date(2017, 12, 5, 13, 14, 49, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(617, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "UMA Utilizada"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnLimpiar)
        Me.Panel4.Controls.Add(Me.btnBuscar)
        Me.Panel4.Controls.Add(Me.lblLimpiar)
        Me.Panel4.Controls.Add(Me.lblBuscar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(1083, 16)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(99, 56)
        Me.Panel4.TabIndex = 119
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.Image = Global.Contabilidad.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(59, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 52
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = Global.Contabilidad.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(11, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 51
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(56, 40)
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
        Me.lblBuscar.Location = New System.Drawing.Point(8, 40)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 54
        Me.lblBuscar.Text = "Mostrar"
        '
        'cmbAnio
        '
        Me.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnio.ForeColor = System.Drawing.Color.Black
        Me.cmbAnio.FormattingEnabled = True
        Me.cmbAnio.Location = New System.Drawing.Point(93, 46)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(96, 21)
        Me.cmbAnio.TabIndex = 53
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(61, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Año"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(214, 49)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(90, 13)
        Me.Label14.TabIndex = 85
        Me.Label14.Text = "Fecha de Cálculo"
        '
        'cmbPatron
        '
        Me.cmbPatron.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPatron.ForeColor = System.Drawing.Color.Black
        Me.cmbPatron.FormattingEnabled = True
        Me.cmbPatron.Location = New System.Drawing.Point(93, 19)
        Me.cmbPatron.Name = "cmbPatron"
        Me.cmbPatron.Size = New System.Drawing.Size(485, 21)
        Me.cmbPatron.TabIndex = 44
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.lblEmpresa.Location = New System.Drawing.Point(49, 22)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(38, 13)
        Me.lblEmpresa.TabIndex = 43
        Me.lblEmpresa.Text = "Patrón"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAyuda)
        Me.pnlEncabezado.Controls.Add(Me.Panel3)
        Me.pnlEncabezado.Controls.Add(Me.pnlAutorizar)
        Me.pnlEncabezado.Controls.Add(Me.pnlCalcular)
        Me.pnlEncabezado.Controls.Add(Me.pnlExportar)
        Me.pnlEncabezado.Controls.Add(Me.pnlImprimir)
        Me.pnlEncabezado.Controls.Add(Me.Panel1)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1191, 69)
        Me.pnlEncabezado.TabIndex = 20
        '
        'pnlAyuda
        '
        Me.pnlAyuda.Controls.Add(Me.btnAyuda)
        Me.pnlAyuda.Controls.Add(Me.Label4)
        Me.pnlAyuda.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAyuda.Location = New System.Drawing.Point(300, 0)
        Me.pnlAyuda.Name = "pnlAyuda"
        Me.pnlAyuda.Size = New System.Drawing.Size(60, 69)
        Me.pnlAyuda.TabIndex = 113
        '
        'btnAyuda
        '
        Me.btnAyuda.Image = CType(resources.GetObject("btnAyuda.Image"), System.Drawing.Image)
        Me.btnAyuda.Location = New System.Drawing.Point(14, 10)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(32, 32)
        Me.btnAyuda.TabIndex = 10
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(12, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Ayuda"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.btnEnviar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(240, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(60, 69)
        Me.Panel3.TabIndex = 57
        Me.Panel3.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(12, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Enviar"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnEnviar
        '
        Me.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEnviar.Image = Global.Contabilidad.Vista.My.Resources.Resources.Email
        Me.btnEnviar.Location = New System.Drawing.Point(14, 10)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(32, 32)
        Me.btnEnviar.TabIndex = 22
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'pnlAutorizar
        '
        Me.pnlAutorizar.Controls.Add(Me.lblAutorizar)
        Me.pnlAutorizar.Controls.Add(Me.btnAutorizar)
        Me.pnlAutorizar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAutorizar.Location = New System.Drawing.Point(180, 0)
        Me.pnlAutorizar.Name = "pnlAutorizar"
        Me.pnlAutorizar.Size = New System.Drawing.Size(60, 69)
        Me.pnlAutorizar.TabIndex = 56
        '
        'lblAutorizar
        '
        Me.lblAutorizar.AutoSize = True
        Me.lblAutorizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAutorizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAutorizar.Location = New System.Drawing.Point(6, 45)
        Me.lblAutorizar.Name = "lblAutorizar"
        Me.lblAutorizar.Size = New System.Drawing.Size(48, 13)
        Me.lblAutorizar.TabIndex = 24
        Me.lblAutorizar.Text = "Autorizar"
        Me.lblAutorizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAutorizar
        '
        Me.btnAutorizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAutorizar.Image = Global.Contabilidad.Vista.My.Resources.Resources.aceptar_32
        Me.btnAutorizar.Location = New System.Drawing.Point(14, 10)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(32, 32)
        Me.btnAutorizar.TabIndex = 22
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'pnlCalcular
        '
        Me.pnlCalcular.Controls.Add(Me.btnCalcular)
        Me.pnlCalcular.Controls.Add(Me.lblCalcular)
        Me.pnlCalcular.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCalcular.Location = New System.Drawing.Point(120, 0)
        Me.pnlCalcular.Name = "pnlCalcular"
        Me.pnlCalcular.Size = New System.Drawing.Size(60, 69)
        Me.pnlCalcular.TabIndex = 55
        '
        'btnCalcular
        '
        Me.btnCalcular.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCalcular.Image = Global.Contabilidad.Vista.My.Resources.Resources.calculo_32
        Me.btnCalcular.Location = New System.Drawing.Point(14, 10)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(32, 32)
        Me.btnCalcular.TabIndex = 31
        Me.btnCalcular.UseVisualStyleBackColor = True
        '
        'lblCalcular
        '
        Me.lblCalcular.AutoSize = True
        Me.lblCalcular.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCalcular.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCalcular.Location = New System.Drawing.Point(8, 45)
        Me.lblCalcular.Name = "lblCalcular"
        Me.lblCalcular.Size = New System.Drawing.Size(45, 13)
        Me.lblCalcular.TabIndex = 32
        Me.lblCalcular.Text = "Calcular"
        Me.lblCalcular.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Controls.Add(Me.lblExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(60, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(60, 69)
        Me.pnlExportar.TabIndex = 52
        '
        'btnExportar
        '
        Me.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportar.Image = Global.Contabilidad.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(14, 10)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 22
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(8, 45)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 23
        Me.lblExportar.Text = "Exportar"
        Me.lblExportar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlImprimir
        '
        Me.pnlImprimir.Controls.Add(Me.btnImprimir)
        Me.pnlImprimir.Controls.Add(Me.lblImprimir)
        Me.pnlImprimir.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImprimir.Location = New System.Drawing.Point(0, 0)
        Me.pnlImprimir.Name = "pnlImprimir"
        Me.pnlImprimir.Size = New System.Drawing.Size(60, 69)
        Me.pnlImprimir.TabIndex = 51
        '
        'btnImprimir
        '
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.Image = Global.Contabilidad.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(14, 10)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 31
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(9, 45)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 32
        Me.lblImprimir.Text = "Imprimir"
        Me.lblImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.imgLogo)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(852, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(339, 69)
        Me.Panel1.TabIndex = 20
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(25, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(214, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Recálculo de Descuentos"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlOperaciones)
        Me.pnlPie.Controls.Add(Me.pnlEstado)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 451)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1191, 60)
        Me.pnlPie.TabIndex = 21
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.btnCerrar)
        Me.pnlOperaciones.Controls.Add(Me.lblCerrar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(1123, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(68, 60)
        Me.pnlOperaciones.TabIndex = 24
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(17, 6)
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
        Me.lblCerrar.Location = New System.Drawing.Point(16, 40)
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
        Me.pnlEstado.Size = New System.Drawing.Size(1180, 60)
        Me.pnlEstado.TabIndex = 22
        '
        'grdListado
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListado.DisplayLayout.Appearance = Appearance1
        Me.grdListado.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListado.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdListado.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListado.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListado.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListado.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdListado.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListado.Location = New System.Drawing.Point(0, 172)
        Me.grdListado.Name = "grdListado"
        Me.grdListado.Size = New System.Drawing.Size(1191, 279)
        Me.grdListado.TabIndex = 33
        '
        'menuAyuda
        '
        Me.menuAyuda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaRecalculoDescuentosToolStripMenuItem, Me.RecalculoDescuentosArchivoWordToolStripMenuItem, Me.RecalculoDescuentosPropuestaToolStripMenuItem})
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Size = New System.Drawing.Size(247, 70)
        '
        'AyudaRecalculoDescuentosToolStripMenuItem
        '
        Me.AyudaRecalculoDescuentosToolStripMenuItem.Name = "AyudaRecalculoDescuentosToolStripMenuItem"
        Me.AyudaRecalculoDescuentosToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.AyudaRecalculoDescuentosToolStripMenuItem.Text = "Ayuda RecálculoDescuentos"
        '
        'RecalculoDescuentosArchivoWordToolStripMenuItem
        '
        Me.RecalculoDescuentosArchivoWordToolStripMenuItem.Name = "RecalculoDescuentosArchivoWordToolStripMenuItem"
        Me.RecalculoDescuentosArchivoWordToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.RecalculoDescuentosArchivoWordToolStripMenuItem.Text = "Recálculo Descuentos Archivo Word"
        '
        'RecalculoDescuentosPropuestaToolStripMenuItem
        '
        Me.RecalculoDescuentosPropuestaToolStripMenuItem.Name = "RecalculoDescuentosPropuestaToolStripMenuItem"
        Me.RecalculoDescuentosPropuestaToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.RecalculoDescuentosPropuestaToolStripMenuItem.Text = "Recálculo Descuentos Propuesta"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(267, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 69)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 48
        Me.imgLogo.TabStop = False
        '
        'RecalculoDescuentosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1191, 511)
        Me.Controls.Add(Me.grdListado)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.pnlPie)
        Me.Name = "RecalculoDescuentosForm"
        Me.Text = "Recálculo de Descuentos"
        Me.pnlFiltros.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAyuda.ResumeLayout(False)
        Me.pnlAyuda.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlAutorizar.ResumeLayout(False)
        Me.pnlAutorizar.PerformLayout()
        Me.pnlCalcular.ResumeLayout(False)
        Me.pnlCalcular.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlImprimir.ResumeLayout(False)
        Me.pnlImprimir.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        CType(Me.grdListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuAyuda.ResumeLayout(False)
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlFiltros As Windows.Forms.Panel
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents btnAbajo As Windows.Forms.Button
    Friend WithEvents btnArriba As Windows.Forms.Button
    Friend WithEvents grbFiltros As Windows.Forms.GroupBox
    Friend WithEvents lblSalarioMinimo As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents dtpFechaCalculo As Windows.Forms.DateTimePicker
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents btnLimpiar As Windows.Forms.Button
    Friend WithEvents btnBuscar As Windows.Forms.Button
    Friend WithEvents lblLimpiar As Windows.Forms.Label
    Friend WithEvents lblBuscar As Windows.Forms.Label
    Friend WithEvents cmbAnio As Windows.Forms.ComboBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents cmbPatron As Windows.Forms.ComboBox
    Friend WithEvents lblEmpresa As Windows.Forms.Label
    Friend WithEvents pnlEncabezado As Windows.Forms.Panel
    Friend WithEvents pnlExportar As Windows.Forms.Panel
    Friend WithEvents btnExportar As Windows.Forms.Button
    Friend WithEvents lblExportar As Windows.Forms.Label
    Friend WithEvents pnlImprimir As Windows.Forms.Panel
    Friend WithEvents btnImprimir As Windows.Forms.Button
    Friend WithEvents lblImprimir As Windows.Forms.Label
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As Windows.Forms.Panel
    Friend WithEvents btnCerrar As Windows.Forms.Button
    Friend WithEvents lblCerrar As Windows.Forms.Label
    Friend WithEvents pnlEstado As Windows.Forms.Panel
    Friend WithEvents Panel3 As Windows.Forms.Panel
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents btnEnviar As Windows.Forms.Button
    Friend WithEvents pnlAutorizar As Windows.Forms.Panel
    Friend WithEvents lblAutorizar As Windows.Forms.Label
    Friend WithEvents btnAutorizar As Windows.Forms.Button
    Friend WithEvents pnlCalcular As Windows.Forms.Panel
    Friend WithEvents btnCalcular As Windows.Forms.Button
    Friend WithEvents lblCalcular As Windows.Forms.Label
    Friend WithEvents grdListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel5 As Windows.Forms.Panel
    Friend WithEvents rdoReal As Windows.Forms.RadioButton
    Friend WithEvents rdoFiscal As Windows.Forms.RadioButton
    Friend WithEvents pnlAyuda As Windows.Forms.Panel
    Friend WithEvents btnAyuda As Windows.Forms.Button
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents menuAyuda As Windows.Forms.ContextMenuStrip
    Friend WithEvents AyudaRecalculoDescuentosToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecalculoDescuentosArchivoWordToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecalculoDescuentosPropuestaToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
