<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaDeduccionesExtraordinariasForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaDeduccionesExtraordinariasForm))
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCobro = New System.Windows.Forms.Label()
        Me.btnCobro = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblAlta = New System.Windows.Forms.Label()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.lblcolaborador = New System.Windows.Forms.Label()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.cmbPeriodoNomina = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grpCheckBox = New System.Windows.Forms.GroupBox()
        Me.rdoFechas = New System.Windows.Forms.RadioButton()
        Me.dtpFechaDel = New System.Windows.Forms.DateTimePicker()
        Me.lblDel = New System.Windows.Forms.Label()
        Me.rdoPeriodoNomina = New System.Windows.Forms.RadioButton()
        Me.dtpFechaAl = New System.Windows.Forms.DateTimePicker()
        Me.lblAl = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdCtrolDeducciones = New DevExpress.XtraGrid.GridControl()
        Me.grdDeducciones = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpCheckBox.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdCtrolDeducciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDeducciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInferior.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(607, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(457, 70)
        Me.pnlTitulo.TabIndex = 5
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(146, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(239, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Deducciones Extraordinarias"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.Label4)
        Me.pnlHeader.Controls.Add(Me.lblReporte)
        Me.pnlHeader.Controls.Add(Me.btnReporte)
        Me.pnlHeader.Controls.Add(Me.Label3)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Controls.Add(Me.lblCobro)
        Me.pnlHeader.Controls.Add(Me.btnCobro)
        Me.pnlHeader.Controls.Add(Me.Label2)
        Me.pnlHeader.Controls.Add(Me.btnEliminar)
        Me.pnlHeader.Controls.Add(Me.lblAlta)
        Me.pnlHeader.Controls.Add(Me.btnAlta)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1064, 70)
        Me.pnlHeader.TabIndex = 54
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(22, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Imprimir "
        '
        'lblReporte
        '
        Me.lblReporte.AutoSize = True
        Me.lblReporte.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblReporte.Location = New System.Drawing.Point(8, 53)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(68, 13)
        Me.lblReporte.TabIndex = 39
        Me.lblReporte.Text = "Concentrado"
        '
        'btnReporte
        '
        Me.btnReporte.Image = Global.Nomina.Vista.My.Resources.Resources.imprimir_32
        Me.btnReporte.Location = New System.Drawing.Point(25, 5)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(35, 32)
        Me.btnReporte.TabIndex = 21
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(189, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Deducciones"
        Me.Label3.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(130, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Semanal"
        Me.Label1.Visible = False
        '
        'lblCobro
        '
        Me.lblCobro.AutoSize = True
        Me.lblCobro.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCobro.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCobro.Location = New System.Drawing.Point(138, 41)
        Me.lblCobro.Name = "lblCobro"
        Me.lblCobro.Size = New System.Drawing.Size(34, 13)
        Me.lblCobro.TabIndex = 18
        Me.lblCobro.Text = "Cierre"
        Me.lblCobro.Visible = False
        '
        'btnCobro
        '
        Me.btnCobro.Image = Global.Nomina.Vista.My.Resources.Resources.candado
        Me.btnCobro.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCobro.Location = New System.Drawing.Point(141, 6)
        Me.btnCobro.Name = "btnCobro"
        Me.btnCobro.Size = New System.Drawing.Size(32, 32)
        Me.btnCobro.TabIndex = 17
        Me.btnCobro.UseVisualStyleBackColor = True
        Me.btnCobro.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(201, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Eliminar"
        Me.Label2.Visible = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Nomina.Vista.My.Resources.Resources.borrar_321
        Me.btnEliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEliminar.Location = New System.Drawing.Point(209, 6)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminar.TabIndex = 15
        Me.btnEliminar.UseVisualStyleBackColor = True
        Me.btnEliminar.Visible = False
        '
        'lblAlta
        '
        Me.lblAlta.AutoSize = True
        Me.lblAlta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAlta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAlta.Location = New System.Drawing.Point(81, 40)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(30, 13)
        Me.lblAlta.TabIndex = 14
        Me.lblAlta.Text = "Altas"
        Me.lblAlta.Visible = False
        '
        'btnAlta
        '
        Me.btnAlta.Image = Global.Nomina.Vista.My.Resources.Resources.altas_32
        Me.btnAlta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAlta.Location = New System.Drawing.Point(81, 5)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(32, 32)
        Me.btnAlta.TabIndex = 13
        Me.btnAlta.UseVisualStyleBackColor = True
        Me.btnAlta.Visible = False
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(963, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(98, 117)
        Me.pnlMinimizarParametros.TabIndex = 54
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(47, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(69, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Image = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(960, 3)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 73
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(958, 38)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 72
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Image = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBuscar.Location = New System.Drawing.Point(906, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 67
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBuscar.Location = New System.Drawing.Point(902, 38)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 68
        Me.lblBuscar.Text = "Mostrar"
        '
        'lblcolaborador
        '
        Me.lblcolaborador.AutoSize = True
        Me.lblcolaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcolaborador.ForeColor = System.Drawing.Color.Black
        Me.lblcolaborador.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblcolaborador.Location = New System.Drawing.Point(6, 81)
        Me.lblcolaborador.Name = "lblcolaborador"
        Me.lblcolaborador.Size = New System.Drawing.Size(64, 13)
        Me.lblcolaborador.TabIndex = 66
        Me.lblcolaborador.Text = "Colaborador"
        '
        'txtColaborador
        '
        Me.txtColaborador.ForeColor = System.Drawing.Color.Black
        Me.txtColaborador.Location = New System.Drawing.Point(92, 77)
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.Size = New System.Drawing.Size(329, 20)
        Me.txtColaborador.TabIndex = 69
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(92, 34)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(329, 21)
        Me.cmbNave.TabIndex = 64
        '
        'cmbPeriodoNomina
        '
        Me.cmbPeriodoNomina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodoNomina.ForeColor = System.Drawing.Color.Black
        Me.cmbPeriodoNomina.FormattingEnabled = True
        Me.cmbPeriodoNomina.Location = New System.Drawing.Point(123, 18)
        Me.cmbPeriodoNomina.Name = "cmbPeriodoNomina"
        Me.cmbPeriodoNomina.Size = New System.Drawing.Size(329, 21)
        Me.cmbPeriodoNomina.TabIndex = 70
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNave.Location = New System.Drawing.Point(6, 40)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 65
        Me.lblNave.Text = "Nave"
        '
        'grbParametros
        '
        Me.grbParametros.Controls.Add(Me.GroupBox1)
        Me.grbParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 70)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1064, 136)
        Me.grbParametros.TabIndex = 56
        Me.grbParametros.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grpCheckBox)
        Me.GroupBox1.Controls.Add(Me.lblNave)
        Me.GroupBox1.Controls.Add(Me.cmbNave)
        Me.GroupBox1.Controls.Add(Me.txtColaborador)
        Me.GroupBox1.Controls.Add(Me.lblcolaborador)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(911, 114)
        Me.GroupBox1.TabIndex = 102
        Me.GroupBox1.TabStop = False
        '
        'grpCheckBox
        '
        Me.grpCheckBox.Controls.Add(Me.rdoFechas)
        Me.grpCheckBox.Controls.Add(Me.dtpFechaDel)
        Me.grpCheckBox.Controls.Add(Me.lblDel)
        Me.grpCheckBox.Controls.Add(Me.rdoPeriodoNomina)
        Me.grpCheckBox.Controls.Add(Me.cmbPeriodoNomina)
        Me.grpCheckBox.Controls.Add(Me.dtpFechaAl)
        Me.grpCheckBox.Controls.Add(Me.lblAl)
        Me.grpCheckBox.Location = New System.Drawing.Point(447, 19)
        Me.grpCheckBox.Name = "grpCheckBox"
        Me.grpCheckBox.Size = New System.Drawing.Size(458, 89)
        Me.grpCheckBox.TabIndex = 102
        Me.grpCheckBox.TabStop = False
        '
        'rdoFechas
        '
        Me.rdoFechas.AutoSize = True
        Me.rdoFechas.Location = New System.Drawing.Point(6, 60)
        Me.rdoFechas.Name = "rdoFechas"
        Me.rdoFechas.Size = New System.Drawing.Size(55, 17)
        Me.rdoFechas.TabIndex = 1
        Me.rdoFechas.Text = "Fecha"
        Me.rdoFechas.UseVisualStyleBackColor = True
        '
        'dtpFechaDel
        '
        Me.dtpFechaDel.CustomFormat = ""
        Me.dtpFechaDel.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDel.Location = New System.Drawing.Point(156, 59)
        Me.dtpFechaDel.Name = "dtpFechaDel"
        Me.dtpFechaDel.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaDel.TabIndex = 66
        Me.dtpFechaDel.Value = New Date(2017, 7, 26, 0, 0, 0, 0)
        '
        'lblDel
        '
        Me.lblDel.AutoSize = True
        Me.lblDel.ForeColor = System.Drawing.Color.Black
        Me.lblDel.Location = New System.Drawing.Point(123, 61)
        Me.lblDel.Name = "lblDel"
        Me.lblDel.Size = New System.Drawing.Size(23, 13)
        Me.lblDel.TabIndex = 67
        Me.lblDel.Text = "Del"
        '
        'rdoPeriodoNomina
        '
        Me.rdoPeriodoNomina.AutoSize = True
        Me.rdoPeriodoNomina.Checked = True
        Me.rdoPeriodoNomina.Location = New System.Drawing.Point(6, 19)
        Me.rdoPeriodoNomina.Name = "rdoPeriodoNomina"
        Me.rdoPeriodoNomina.Size = New System.Drawing.Size(100, 17)
        Me.rdoPeriodoNomina.TabIndex = 0
        Me.rdoPeriodoNomina.TabStop = True
        Me.rdoPeriodoNomina.Text = "Periodo Nómina"
        Me.rdoPeriodoNomina.UseVisualStyleBackColor = True
        '
        'dtpFechaAl
        '
        Me.dtpFechaAl.CustomFormat = ""
        Me.dtpFechaAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAl.Location = New System.Drawing.Point(270, 60)
        Me.dtpFechaAl.Name = "dtpFechaAl"
        Me.dtpFechaAl.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaAl.TabIndex = 69
        Me.dtpFechaAl.Value = New Date(2017, 7, 26, 0, 0, 0, 0)
        '
        'lblAl
        '
        Me.lblAl.AutoSize = True
        Me.lblAl.ForeColor = System.Drawing.Color.Black
        Me.lblAl.Location = New System.Drawing.Point(248, 61)
        Me.lblAl.Name = "lblAl"
        Me.lblAl.Size = New System.Drawing.Size(16, 13)
        Me.lblAl.TabIndex = 70
        Me.lblAl.Text = "Al"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.grdCtrolDeducciones)
        Me.Panel1.Location = New System.Drawing.Point(0, 207)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1061, 199)
        Me.Panel1.TabIndex = 62
        '
        'grdCtrolDeducciones
        '
        Me.grdCtrolDeducciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdCtrolDeducciones.Location = New System.Drawing.Point(3, 0)
        Me.grdCtrolDeducciones.MainView = Me.grdDeducciones
        Me.grdCtrolDeducciones.Name = "grdCtrolDeducciones"
        Me.grdCtrolDeducciones.Size = New System.Drawing.Size(1058, 196)
        Me.grdCtrolDeducciones.TabIndex = 61
        Me.grdCtrolDeducciones.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdDeducciones})
        '
        'grdDeducciones
        '
        Me.grdDeducciones.GridControl = Me.grdCtrolDeducciones
        Me.grdDeducciones.Name = "grdDeducciones"
        Me.grdDeducciones.OptionsBehavior.Editable = False
        Me.grdDeducciones.OptionsView.ShowAutoFilterRow = True
        Me.grdDeducciones.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.grdDeducciones.OptionsView.ShowGroupPanel = False
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.btnLimpiar)
        Me.pnlInferior.Controls.Add(Me.lblLimpiar)
        Me.pnlInferior.Controls.Add(Me.lblCerrar)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Controls.Add(Me.btnBuscar)
        Me.pnlInferior.Controls.Add(Me.lblBuscar)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 403)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(1064, 54)
        Me.pnlInferior.TabIndex = 2024
        '
        'lblCerrar
        '
        Me.lblCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(1011, 37)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 100
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(1014, 3)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(389, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 70)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 44
        Me.pcbTitulo.TabStop = False
        '
        'ListaDeduccionesExtraordinariasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1064, 457)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "ListaDeduccionesExtraordinariasForm"
        Me.Text = "Deducciones Extraordinarias"
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.grbParametros.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpCheckBox.ResumeLayout(False)
        Me.grpCheckBox.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdCtrolDeducciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDeducciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents lblcolaborador As System.Windows.Forms.Label
    Friend WithEvents txtColaborador As System.Windows.Forms.TextBox
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPeriodoNomina As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents lblAlta As System.Windows.Forms.Label
    Friend WithEvents btnAlta As System.Windows.Forms.Button
    Friend WithEvents lblCobro As System.Windows.Forms.Label
    Friend WithEvents btnCobro As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaDel As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDel As System.Windows.Forms.Label
    Friend WithEvents dtpFechaAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAl As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents grpCheckBox As System.Windows.Forms.GroupBox
    Friend WithEvents rdoFechas As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPeriodoNomina As System.Windows.Forms.RadioButton
    Friend WithEvents grdCtrolDeducciones As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdDeducciones As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pcbTitulo As PictureBox
End Class
