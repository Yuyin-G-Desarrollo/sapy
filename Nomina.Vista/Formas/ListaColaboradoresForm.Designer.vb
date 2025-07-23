<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ListaColaboradoresForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaColaboradoresForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlImprimirReporte = New System.Windows.Forms.Panel()
        Me.btnImprimirReporte = New System.Windows.Forms.Button()
        Me.lblImprimirReporte = New System.Windows.Forms.Label()
        Me.pnlInhabilitar = New System.Windows.Forms.Panel()
        Me.btnDesactivarColaborador = New System.Windows.Forms.Button()
        Me.lblDesactivarColaborador = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlImprimir = New System.Windows.Forms.Panel()
        Me.btnImprimirCredencial = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlEditar = New System.Windows.Forms.Panel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.Editar = New System.Windows.Forms.Label()
        Me.pnlAltas = New System.Windows.Forms.Panel()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblListaPuestos = New System.Windows.Forms.Label()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.pnlFechaReporte = New System.Windows.Forms.Panel()
        Me.grbFecha = New System.Windows.Forms.GroupBox()
        Me.dttFecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoExternoNo = New System.Windows.Forms.RadioButton()
        Me.rdoExternoSI = New System.Windows.Forms.RadioButton()
        Me.lblExterno = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.cmbPuesto = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbDepto = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.txtRFC = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCurp = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grdColaboradores = New DevExpress.XtraGrid.GridControl()
        Me.vwColaboradores = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ImprimirCartaRenunciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlImprimirReporte.SuspendLayout()
        Me.pnlInhabilitar.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlImprimir.SuspendLayout()
        Me.pnlEditar.SuspendLayout()
        Me.pnlAltas.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.pnlFechaReporte.SuspendLayout()
        Me.grbFecha.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdColaboradores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwColaboradores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlImprimirReporte)
        Me.pnlEncabezado.Controls.Add(Me.pnlInhabilitar)
        Me.pnlEncabezado.Controls.Add(Me.pnlExportar)
        Me.pnlEncabezado.Controls.Add(Me.pnlImprimir)
        Me.pnlEncabezado.Controls.Add(Me.pnlEditar)
        Me.pnlEncabezado.Controls.Add(Me.pnlAltas)
        Me.pnlEncabezado.Controls.Add(Me.Panel1)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1340, 69)
        Me.pnlEncabezado.TabIndex = 4
        '
        'pnlImprimirReporte
        '
        Me.pnlImprimirReporte.Controls.Add(Me.btnImprimirReporte)
        Me.pnlImprimirReporte.Controls.Add(Me.lblImprimirReporte)
        Me.pnlImprimirReporte.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImprimirReporte.Location = New System.Drawing.Point(360, 0)
        Me.pnlImprimirReporte.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlImprimirReporte.Name = "pnlImprimirReporte"
        Me.pnlImprimirReporte.Size = New System.Drawing.Size(72, 69)
        Me.pnlImprimirReporte.TabIndex = 31
        '
        'btnImprimirReporte
        '
        Me.btnImprimirReporte.Image = Global.Nomina.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimirReporte.Location = New System.Drawing.Point(19, 7)
        Me.btnImprimirReporte.Name = "btnImprimirReporte"
        Me.btnImprimirReporte.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimirReporte.TabIndex = 23
        Me.btnImprimirReporte.UseVisualStyleBackColor = True
        '
        'lblImprimirReporte
        '
        Me.lblImprimirReporte.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimirReporte.Location = New System.Drawing.Point(4, 38)
        Me.lblImprimirReporte.Name = "lblImprimirReporte"
        Me.lblImprimirReporte.Size = New System.Drawing.Size(64, 28)
        Me.lblImprimirReporte.TabIndex = 24
        Me.lblImprimirReporte.Text = "Imprimir"
        Me.lblImprimirReporte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlInhabilitar
        '
        Me.pnlInhabilitar.Controls.Add(Me.btnDesactivarColaborador)
        Me.pnlInhabilitar.Controls.Add(Me.lblDesactivarColaborador)
        Me.pnlInhabilitar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlInhabilitar.Location = New System.Drawing.Point(288, 0)
        Me.pnlInhabilitar.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlInhabilitar.Name = "pnlInhabilitar"
        Me.pnlInhabilitar.Size = New System.Drawing.Size(72, 69)
        Me.pnlInhabilitar.TabIndex = 30
        '
        'btnDesactivarColaborador
        '
        Me.btnDesactivarColaborador.Image = Global.Nomina.Vista.My.Resources.Resources.cancelar_321
        Me.btnDesactivarColaborador.Location = New System.Drawing.Point(19, 7)
        Me.btnDesactivarColaborador.Name = "btnDesactivarColaborador"
        Me.btnDesactivarColaborador.Size = New System.Drawing.Size(32, 32)
        Me.btnDesactivarColaborador.TabIndex = 23
        Me.btnDesactivarColaborador.UseVisualStyleBackColor = True
        '
        'lblDesactivarColaborador
        '
        Me.lblDesactivarColaborador.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDesactivarColaborador.Location = New System.Drawing.Point(4, 38)
        Me.lblDesactivarColaborador.Name = "lblDesactivarColaborador"
        Me.lblDesactivarColaborador.Size = New System.Drawing.Size(64, 28)
        Me.lblDesactivarColaborador.TabIndex = 24
        Me.lblDesactivarColaborador.Text = "Inhabilitar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Colaborador"
        Me.lblDesactivarColaborador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Controls.Add(Me.lblExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(216, 0)
        Me.pnlExportar.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(72, 69)
        Me.pnlExportar.TabIndex = 29
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Nomina.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(19, 7)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(31, 32)
        Me.btnExportar.TabIndex = 12
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(14, 44)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 11
        Me.lblExportar.Text = "Exportar"
        '
        'pnlImprimir
        '
        Me.pnlImprimir.Controls.Add(Me.btnImprimirCredencial)
        Me.pnlImprimir.Controls.Add(Me.Label4)
        Me.pnlImprimir.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImprimir.Location = New System.Drawing.Point(144, 0)
        Me.pnlImprimir.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlImprimir.Name = "pnlImprimir"
        Me.pnlImprimir.Size = New System.Drawing.Size(72, 69)
        Me.pnlImprimir.TabIndex = 28
        '
        'btnImprimirCredencial
        '
        Me.btnImprimirCredencial.Image = Global.Nomina.Vista.My.Resources.Resources.fichaColaborador_32
        Me.btnImprimirCredencial.Location = New System.Drawing.Point(19, 7)
        Me.btnImprimirCredencial.Name = "btnImprimirCredencial"
        Me.btnImprimirCredencial.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimirCredencial.TabIndex = 21
        Me.btnImprimirCredencial.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(7, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 26)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Imprimir" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Credencial" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlEditar
        '
        Me.pnlEditar.Controls.Add(Me.btnEditar)
        Me.pnlEditar.Controls.Add(Me.Editar)
        Me.pnlEditar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEditar.Location = New System.Drawing.Point(72, 0)
        Me.pnlEditar.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlEditar.Name = "pnlEditar"
        Me.pnlEditar.Size = New System.Drawing.Size(72, 69)
        Me.pnlEditar.TabIndex = 27
        '
        'btnEditar
        '
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(19, 7)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 2
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'Editar
        '
        Me.Editar.AutoSize = True
        Me.Editar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Editar.Location = New System.Drawing.Point(19, 44)
        Me.Editar.Name = "Editar"
        Me.Editar.Size = New System.Drawing.Size(34, 13)
        Me.Editar.TabIndex = 19
        Me.Editar.Text = "Editar"
        '
        'pnlAltas
        '
        Me.pnlAltas.Controls.Add(Me.btnAltas)
        Me.pnlAltas.Controls.Add(Me.lblAltas)
        Me.pnlAltas.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAltas.Location = New System.Drawing.Point(0, 0)
        Me.pnlAltas.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlAltas.Name = "pnlAltas"
        Me.pnlAltas.Size = New System.Drawing.Size(72, 69)
        Me.pnlAltas.TabIndex = 26
        '
        'btnAltas
        '
        Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
        Me.btnAltas.Location = New System.Drawing.Point(19, 7)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 1
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(20, 44)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 16
        Me.lblAltas.Text = "Altas"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pcbTitulo)
        Me.Panel1.Controls.Add(Me.lblListaPuestos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(954, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(386, 69)
        Me.Panel1.TabIndex = 20
        '
        'lblListaPuestos
        '
        Me.lblListaPuestos.AutoSize = True
        Me.lblListaPuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaPuestos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaPuestos.Location = New System.Drawing.Point(90, 18)
        Me.lblListaPuestos.Name = "lblListaPuestos"
        Me.lblListaPuestos.Size = New System.Drawing.Size(227, 20)
        Me.lblListaPuestos.TabIndex = 46
        Me.lblListaPuestos.Text = "Consulta de Colaboradores"
        Me.lblListaPuestos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.pnlFechaReporte)
        Me.grbFiltros.Controls.Add(Me.GroupBox1)
        Me.grbFiltros.Controls.Add(Me.lblExterno)
        Me.grbFiltros.Controls.Add(Me.Panel6)
        Me.grbFiltros.Controls.Add(Me.lblActivo)
        Me.grbFiltros.Controls.Add(Me.GroupBox2)
        Me.grbFiltros.Controls.Add(Me.cmbPuesto)
        Me.grbFiltros.Controls.Add(Me.Label6)
        Me.grbFiltros.Controls.Add(Me.cmbDepto)
        Me.grbFiltros.Controls.Add(Me.Label5)
        Me.grbFiltros.Controls.Add(Me.cmbNave)
        Me.grbFiltros.Controls.Add(Me.lblNave)
        Me.grbFiltros.Controls.Add(Me.txtRFC)
        Me.grbFiltros.Controls.Add(Me.Label3)
        Me.grbFiltros.Controls.Add(Me.txtCurp)
        Me.grbFiltros.Controls.Add(Me.Label2)
        Me.grbFiltros.Controls.Add(Me.txtNombre)
        Me.grbFiltros.Controls.Add(Me.Label1)
        Me.grbFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbFiltros.ForeColor = System.Drawing.Color.Black
        Me.grbFiltros.Location = New System.Drawing.Point(0, 69)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1340, 138)
        Me.grbFiltros.TabIndex = 5
        Me.grbFiltros.TabStop = False
        '
        'pnlFechaReporte
        '
        Me.pnlFechaReporte.Controls.Add(Me.grbFecha)
        Me.pnlFechaReporte.Location = New System.Drawing.Point(989, 19)
        Me.pnlFechaReporte.Name = "pnlFechaReporte"
        Me.pnlFechaReporte.Size = New System.Drawing.Size(233, 116)
        Me.pnlFechaReporte.TabIndex = 55
        '
        'grbFecha
        '
        Me.grbFecha.Controls.Add(Me.dttFecha)
        Me.grbFecha.Location = New System.Drawing.Point(6, 33)
        Me.grbFecha.Name = "grbFecha"
        Me.grbFecha.Size = New System.Drawing.Size(214, 61)
        Me.grbFecha.TabIndex = 54
        Me.grbFecha.TabStop = False
        Me.grbFecha.Text = "Fecha Carta Renuncia"
        '
        'dttFecha
        '
        Me.dttFecha.Location = New System.Drawing.Point(6, 31)
        Me.dttFecha.Name = "dttFecha"
        Me.dttFecha.Size = New System.Drawing.Size(192, 20)
        Me.dttFecha.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoExternoNo)
        Me.GroupBox1.Controls.Add(Me.rdoExternoSI)
        Me.GroupBox1.Location = New System.Drawing.Point(878, 79)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(105, 34)
        Me.GroupBox1.TabIndex = 53
        Me.GroupBox1.TabStop = False
        '
        'rdoExternoNo
        '
        Me.rdoExternoNo.AutoSize = True
        Me.rdoExternoNo.Checked = True
        Me.rdoExternoNo.Location = New System.Drawing.Point(54, 12)
        Me.rdoExternoNo.Name = "rdoExternoNo"
        Me.rdoExternoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoExternoNo.TabIndex = 1
        Me.rdoExternoNo.TabStop = True
        Me.rdoExternoNo.Text = "No"
        Me.rdoExternoNo.UseVisualStyleBackColor = True
        '
        'rdoExternoSI
        '
        Me.rdoExternoSI.AutoSize = True
        Me.rdoExternoSI.Location = New System.Drawing.Point(13, 12)
        Me.rdoExternoSI.Name = "rdoExternoSI"
        Me.rdoExternoSI.Size = New System.Drawing.Size(35, 17)
        Me.rdoExternoSI.TabIndex = 0
        Me.rdoExternoSI.Text = "SI"
        Me.rdoExternoSI.UseVisualStyleBackColor = True
        '
        'lblExterno
        '
        Me.lblExterno.AutoSize = True
        Me.lblExterno.Location = New System.Drawing.Point(906, 55)
        Me.lblExterno.Name = "lblExterno"
        Me.lblExterno.Size = New System.Drawing.Size(43, 13)
        Me.lblExterno.TabIndex = 52
        Me.lblExterno.Text = "Externo"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lblBuscar)
        Me.Panel6.Controls.Add(Me.lblLimpiar)
        Me.Panel6.Controls.Add(Me.btnLimpiar)
        Me.Panel6.Controls.Add(Me.btnBuscar)
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(1228, 16)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(109, 119)
        Me.Panel6.TabIndex = 51
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(14, 102)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 54
        Me.lblBuscar.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(64, 102)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 53
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(67, 70)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 52
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(17, 70)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 51
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(79, 0)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 34
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(55, 0)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 33
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.ForeColor = System.Drawing.Color.Black
        Me.lblActivo.Location = New System.Drawing.Point(769, 55)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 49
        Me.lblActivo.Text = "Activo"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdoActivoSi)
        Me.GroupBox2.Controls.Add(Me.rdoActivoNo)
        Me.GroupBox2.Location = New System.Drawing.Point(735, 79)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(105, 34)
        Me.GroupBox2.TabIndex = 48
        Me.GroupBox2.TabStop = False
        '
        'rdoActivoSi
        '
        Me.rdoActivoSi.AutoSize = True
        Me.rdoActivoSi.Checked = True
        Me.rdoActivoSi.ForeColor = System.Drawing.Color.Black
        Me.rdoActivoSi.Location = New System.Drawing.Point(14, 12)
        Me.rdoActivoSi.Name = "rdoActivoSi"
        Me.rdoActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivoSi.TabIndex = 12
        Me.rdoActivoSi.TabStop = True
        Me.rdoActivoSi.Text = "Si"
        Me.rdoActivoSi.UseVisualStyleBackColor = True
        '
        'rdoActivoNo
        '
        Me.rdoActivoNo.AutoSize = True
        Me.rdoActivoNo.ForeColor = System.Drawing.Color.Black
        Me.rdoActivoNo.Location = New System.Drawing.Point(56, 12)
        Me.rdoActivoNo.Name = "rdoActivoNo"
        Me.rdoActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoActivoNo.TabIndex = 13
        Me.rdoActivoNo.Text = "No"
        Me.rdoActivoNo.UseVisualStyleBackColor = True
        '
        'cmbPuesto
        '
        Me.cmbPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPuesto.ForeColor = System.Drawing.Color.Black
        Me.cmbPuesto.FormattingEnabled = True
        Me.cmbPuesto.Location = New System.Drawing.Point(504, 106)
        Me.cmbPuesto.Name = "cmbPuesto"
        Me.cmbPuesto.Size = New System.Drawing.Size(195, 21)
        Me.cmbPuesto.TabIndex = 46
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(414, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Puesto"
        '
        'cmbDepto
        '
        Me.cmbDepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepto.ForeColor = System.Drawing.Color.Black
        Me.cmbDepto.FormattingEnabled = True
        Me.cmbDepto.Location = New System.Drawing.Point(504, 79)
        Me.cmbDepto.Name = "cmbDepto"
        Me.cmbDepto.Size = New System.Drawing.Size(195, 21)
        Me.cmbDepto.TabIndex = 44
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(414, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Departamento"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(504, 52)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(195, 21)
        Me.cmbNave.TabIndex = 42
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(414, 55)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 41
        Me.lblNave.Text = "Nave"
        '
        'txtRFC
        '
        Me.txtRFC.ForeColor = System.Drawing.Color.Black
        Me.txtRFC.Location = New System.Drawing.Point(88, 107)
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(293, 20)
        Me.txtRFC.TabIndex = 40
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(38, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "RFC"
        '
        'txtCurp
        '
        Me.txtCurp.ForeColor = System.Drawing.Color.Black
        Me.txtCurp.Location = New System.Drawing.Point(88, 80)
        Me.txtCurp.Name = "txtCurp"
        Me.txtCurp.Size = New System.Drawing.Size(293, 20)
        Me.txtCurp.TabIndex = 38
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(38, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "CURP"
        '
        'txtNombre
        '
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(88, 53)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(293, 20)
        Me.txtNombre.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(38, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Nombre"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn3.FillWeight = 505.0633!
        Me.DataGridViewTextBoxColumn3.HeaderText = "CURP"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 300
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn4.FillWeight = 18.98734!
        Me.DataGridViewTextBoxColumn4.HeaderText = "RFC"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn5.FillWeight = 18.98734!
        Me.DataGridViewTextBoxColumn5.HeaderText = "Nave"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn6.FillWeight = 18.98734!
        Me.DataGridViewTextBoxColumn6.HeaderText = "Departamento"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn7.FillWeight = 200.0!
        Me.DataGridViewTextBoxColumn7.HeaderText = "Puesto"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 200
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn8.FillWeight = 200.0!
        Me.DataGridViewTextBoxColumn8.HeaderText = "Puesto"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 200
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "NaveID"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'grdColaboradores
        '
        Me.grdColaboradores.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdColaboradores.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdColaboradores.Location = New System.Drawing.Point(0, 207)
        Me.grdColaboradores.MainView = Me.vwColaboradores
        Me.grdColaboradores.Name = "grdColaboradores"
        Me.grdColaboradores.Size = New System.Drawing.Size(1340, 349)
        Me.grdColaboradores.TabIndex = 79
        Me.grdColaboradores.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwColaboradores})
        '
        'vwColaboradores
        '
        Me.vwColaboradores.GridControl = Me.grdColaboradores
        Me.vwColaboradores.Name = "vwColaboradores"
        Me.vwColaboradores.OptionsBehavior.Editable = False
        Me.vwColaboradores.OptionsSelection.MultiSelect = True
        Me.vwColaboradores.OptionsView.ShowAutoFilterRow = True
        Me.vwColaboradores.OptionsView.ShowGroupPanel = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirCartaRenunciaToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(190, 26)
        '
        'ImprimirCartaRenunciaToolStripMenuItem
        '
        Me.ImprimirCartaRenunciaToolStripMenuItem.Name = "ImprimirCartaRenunciaToolStripMenuItem"
        Me.ImprimirCartaRenunciaToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ImprimirCartaRenunciaToolStripMenuItem.Text = "Imprimir Carta Renuncia"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(318, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 69)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 47
        Me.pcbTitulo.TabStop = False
        '
        'ListaColaboradoresForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1340, 556)
        Me.Controls.Add(Me.grdColaboradores)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ListaColaboradoresForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Colaboradores"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlImprimirReporte.ResumeLayout(False)
        Me.pnlInhabilitar.ResumeLayout(False)
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlImprimir.ResumeLayout(False)
        Me.pnlImprimir.PerformLayout()
        Me.pnlEditar.ResumeLayout(False)
        Me.pnlEditar.PerformLayout()
        Me.pnlAltas.ResumeLayout(False)
        Me.pnlAltas.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.pnlFechaReporte.ResumeLayout(False)
        Me.grbFecha.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grdColaboradores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwColaboradores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents Editar As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents cmbPuesto As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbDepto As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents txtRFC As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCurp As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnImprimirCredencial As System.Windows.Forms.Button
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblListaPuestos As System.Windows.Forms.Label
    Friend WithEvents lblDesactivarColaborador As System.Windows.Forms.Label
    Friend WithEvents btnDesactivarColaborador As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoExternoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoExternoSI As System.Windows.Forms.RadioButton
    Friend WithEvents lblExterno As System.Windows.Forms.Label
    Friend WithEvents grdColaboradores As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwColaboradores As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pnlAltas As Panel
    Friend WithEvents pnlExportar As Panel
    Friend WithEvents pnlImprimir As Panel
    Friend WithEvents pnlEditar As Panel
    Friend WithEvents pnlInhabilitar As Panel
    Friend WithEvents btnExportar As Button
    Friend WithEvents lblExportar As Label
    Friend WithEvents pnlImprimirReporte As Panel
    Friend WithEvents btnImprimirReporte As Button
    Friend WithEvents lblImprimirReporte As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ImprimirCartaRenunciaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents grbFecha As GroupBox
    Friend WithEvents dttFecha As DateTimePicker
    Friend WithEvents pnlFechaReporte As Panel
    Friend WithEvents pcbTitulo As PictureBox
End Class
