<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SolicitudPrestamos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SolicitudPrestamos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlBanner = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgBanner = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlPropiedades = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.lblCalcular = New System.Windows.Forms.Label()
        Me.btnCalcular = New System.Windows.Forms.Button()
        Me.rbtnAbono = New System.Windows.Forms.RadioButton()
        Me.rbtnSemanas = New System.Windows.Forms.RadioButton()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtJustificacion = New System.Windows.Forms.TextBox()
        Me.cmbMotivo = New System.Windows.Forms.ComboBox()
        Me.cmbTipoInteres = New System.Windows.Forms.ComboBox()
        Me.txtAbono = New System.Windows.Forms.TextBox()
        Me.txtInteres = New System.Windows.Forms.TextBox()
        Me.txtSemanas = New System.Windows.Forms.TextBox()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.lblJustificacion = New System.Windows.Forms.Label()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.lblTipoDeInteres = New System.Windows.Forms.Label()
        Me.lblAbono = New System.Windows.Forms.Label()
        Me.lblInteres = New System.Windows.Forms.Label()
        Me.lblSemanas = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.lblSalario2 = New System.Windows.Forms.Label()
        Me.lblDepartamento2 = New System.Windows.Forms.Label()
        Me.lblNave2 = New System.Windows.Forms.Label()
        Me.lblPuesto2 = New System.Windows.Forms.Label()
        Me.lblFaltas2 = New System.Windows.Forms.Label()
        Me.lblCajaDeAhorro2 = New System.Windows.Forms.Label()
        Me.lblAntiguedad2 = New System.Windows.Forms.Label()
        Me.lblEdad2 = New System.Windows.Forms.Label()
        Me.lblColaborador2 = New System.Windows.Forms.Label()
        Me.lblSalario = New System.Windows.Forms.Label()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblPuesto = New System.Windows.Forms.Label()
        Me.lblFaltas = New System.Windows.Forms.Label()
        Me.lblCajaDeAhorro = New System.Windows.Forms.Label()
        Me.lblAntiguedad = New System.Windows.Forms.Label()
        Me.lblEdad = New System.Windows.Forms.Label()
        Me.lblColaborador = New System.Windows.Forms.Label()
        Me.picBoxColaborador = New System.Windows.Forms.PictureBox()
        Me.lblPagoTotal2 = New System.Windows.Forms.Label()
        Me.lblInteresTotal2 = New System.Windows.Forms.Label()
        Me.lblPagoTotal = New System.Windows.Forms.Label()
        Me.lblInteresTotal = New System.Windows.Forms.Label()
        Me.grdTablaAmortizacion = New System.Windows.Forms.DataGridView()
        Me.NumeroDePago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AbonoACapital = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Interes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NuevoSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlBanner.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.imgBanner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPropiedades.SuspendLayout()
        CType(Me.picBoxColaborador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTablaAmortizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBanner
        '
        Me.pnlBanner.Controls.Add(Me.Panel1)
        Me.pnlBanner.Controls.Add(Me.lblImprimir)
        Me.pnlBanner.Controls.Add(Me.btnImprimir)
        Me.pnlBanner.Controls.Add(Me.lblGuardar)
        Me.pnlBanner.Controls.Add(Me.btnGuardar)
        Me.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBanner.Location = New System.Drawing.Point(0, 0)
        Me.pnlBanner.Name = "pnlBanner"
        Me.pnlBanner.Size = New System.Drawing.Size(878, 82)
        Me.pnlBanner.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.imgBanner)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(623, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(255, 82)
        Me.Panel1.TabIndex = 7
        '
        'imgBanner
        '
        Me.imgBanner.Image = Global.Nomina.Vista.My.Resources.Resources.yuyin1
        Me.imgBanner.Location = New System.Drawing.Point(114, 1)
        Me.imgBanner.Name = "imgBanner"
        Me.imgBanner.Size = New System.Drawing.Size(125, 55)
        Me.imgBanner.TabIndex = 1
        Me.imgBanner.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(45, 53)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(192, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Solicitud de préstamos"
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblImprimir.Location = New System.Drawing.Point(66, 47)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 6
        Me.lblImprimir.Text = "Imprimir"
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Nomina.Vista.My.Resources.Resources._1377984708_print
        Me.btnImprimir.Location = New System.Drawing.Point(69, 12)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 5
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblGuardar.Location = New System.Drawing.Point(8, 47)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 4
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar_32
        Me.btnGuardar.Location = New System.Drawing.Point(11, 12)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'pnlPropiedades
        '
        Me.pnlPropiedades.Controls.Add(Me.btnAbajo)
        Me.pnlPropiedades.Controls.Add(Me.btnArriba)
        Me.pnlPropiedades.Controls.Add(Me.lblCalcular)
        Me.pnlPropiedades.Controls.Add(Me.btnCalcular)
        Me.pnlPropiedades.Controls.Add(Me.rbtnAbono)
        Me.pnlPropiedades.Controls.Add(Me.rbtnSemanas)
        Me.pnlPropiedades.Controls.Add(Me.lblLimpiar)
        Me.pnlPropiedades.Controls.Add(Me.lblBuscar)
        Me.pnlPropiedades.Controls.Add(Me.btnLimpiar)
        Me.pnlPropiedades.Controls.Add(Me.btnBuscar)
        Me.pnlPropiedades.Controls.Add(Me.txtJustificacion)
        Me.pnlPropiedades.Controls.Add(Me.cmbMotivo)
        Me.pnlPropiedades.Controls.Add(Me.cmbTipoInteres)
        Me.pnlPropiedades.Controls.Add(Me.txtAbono)
        Me.pnlPropiedades.Controls.Add(Me.txtInteres)
        Me.pnlPropiedades.Controls.Add(Me.txtSemanas)
        Me.pnlPropiedades.Controls.Add(Me.txtMonto)
        Me.pnlPropiedades.Controls.Add(Me.lblJustificacion)
        Me.pnlPropiedades.Controls.Add(Me.lblMotivo)
        Me.pnlPropiedades.Controls.Add(Me.lblTipoDeInteres)
        Me.pnlPropiedades.Controls.Add(Me.lblAbono)
        Me.pnlPropiedades.Controls.Add(Me.lblInteres)
        Me.pnlPropiedades.Controls.Add(Me.lblSemanas)
        Me.pnlPropiedades.Controls.Add(Me.lblMonto)
        Me.pnlPropiedades.Controls.Add(Me.lblSalario2)
        Me.pnlPropiedades.Controls.Add(Me.lblDepartamento2)
        Me.pnlPropiedades.Controls.Add(Me.lblNave2)
        Me.pnlPropiedades.Controls.Add(Me.lblPuesto2)
        Me.pnlPropiedades.Controls.Add(Me.lblFaltas2)
        Me.pnlPropiedades.Controls.Add(Me.lblCajaDeAhorro2)
        Me.pnlPropiedades.Controls.Add(Me.lblAntiguedad2)
        Me.pnlPropiedades.Controls.Add(Me.lblEdad2)
        Me.pnlPropiedades.Controls.Add(Me.lblColaborador2)
        Me.pnlPropiedades.Controls.Add(Me.lblSalario)
        Me.pnlPropiedades.Controls.Add(Me.lblDepartamento)
        Me.pnlPropiedades.Controls.Add(Me.lblNave)
        Me.pnlPropiedades.Controls.Add(Me.lblPuesto)
        Me.pnlPropiedades.Controls.Add(Me.lblFaltas)
        Me.pnlPropiedades.Controls.Add(Me.lblCajaDeAhorro)
        Me.pnlPropiedades.Controls.Add(Me.lblAntiguedad)
        Me.pnlPropiedades.Controls.Add(Me.lblEdad)
        Me.pnlPropiedades.Controls.Add(Me.lblColaborador)
        Me.pnlPropiedades.Controls.Add(Me.picBoxColaborador)
        Me.pnlPropiedades.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPropiedades.Location = New System.Drawing.Point(0, 82)
        Me.pnlPropiedades.Name = "pnlPropiedades"
        Me.pnlPropiedades.Size = New System.Drawing.Size(878, 292)
        Me.pnlPropiedades.TabIndex = 3
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(834, 6)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(806, 6)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'lblCalcular
        '
        Me.lblCalcular.AutoSize = True
        Me.lblCalcular.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblCalcular.Location = New System.Drawing.Point(823, 252)
        Me.lblCalcular.Name = "lblCalcular"
        Me.lblCalcular.Size = New System.Drawing.Size(45, 13)
        Me.lblCalcular.TabIndex = 40
        Me.lblCalcular.Text = "Calcular"
        '
        'btnCalcular
        '
        Me.btnCalcular.Image = Global.Nomina.Vista.My.Resources.Resources.calculo_32
        Me.btnCalcular.Location = New System.Drawing.Point(826, 217)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(32, 32)
        Me.btnCalcular.TabIndex = 39
        Me.btnCalcular.UseVisualStyleBackColor = True
        '
        'rbtnAbono
        '
        Me.rbtnAbono.AutoSize = True
        Me.rbtnAbono.Location = New System.Drawing.Point(763, 92)
        Me.rbtnAbono.Name = "rbtnAbono"
        Me.rbtnAbono.Size = New System.Drawing.Size(14, 13)
        Me.rbtnAbono.TabIndex = 38
        Me.rbtnAbono.TabStop = True
        Me.rbtnAbono.UseVisualStyleBackColor = True
        '
        'rbtnSemanas
        '
        Me.rbtnSemanas.AutoSize = True
        Me.rbtnSemanas.Location = New System.Drawing.Point(763, 68)
        Me.rbtnSemanas.Name = "rbtnSemanas"
        Me.rbtnSemanas.Size = New System.Drawing.Size(14, 13)
        Me.rbtnSemanas.TabIndex = 37
        Me.rbtnSemanas.TabStop = True
        Me.rbtnSemanas.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(88, 242)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 36
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblBuscar.Location = New System.Drawing.Point(36, 242)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(40, 13)
        Me.lblBuscar.TabIndex = 35
        Me.lblBuscar.Text = "Buscar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(91, 206)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 34
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(39, 206)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 33
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtJustificacion
        '
        Me.txtJustificacion.Location = New System.Drawing.Point(622, 210)
        Me.txtJustificacion.Multiline = True
        Me.txtJustificacion.Name = "txtJustificacion"
        Me.txtJustificacion.Size = New System.Drawing.Size(192, 66)
        Me.txtJustificacion.TabIndex = 32
        '
        'cmbMotivo
        '
        Me.cmbMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMotivo.FormattingEnabled = True
        Me.cmbMotivo.Location = New System.Drawing.Point(627, 179)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.Size = New System.Drawing.Size(130, 21)
        Me.cmbMotivo.TabIndex = 31
        '
        'cmbTipoInteres
        '
        Me.cmbTipoInteres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoInteres.FormattingEnabled = True
        Me.cmbTipoInteres.Location = New System.Drawing.Point(627, 150)
        Me.cmbTipoInteres.Name = "cmbTipoInteres"
        Me.cmbTipoInteres.Size = New System.Drawing.Size(130, 21)
        Me.cmbTipoInteres.TabIndex = 30
        '
        'txtAbono
        '
        Me.txtAbono.Location = New System.Drawing.Point(627, 93)
        Me.txtAbono.Name = "txtAbono"
        Me.txtAbono.Size = New System.Drawing.Size(130, 20)
        Me.txtAbono.TabIndex = 29
        '
        'txtInteres
        '
        Me.txtInteres.Location = New System.Drawing.Point(627, 122)
        Me.txtInteres.Name = "txtInteres"
        Me.txtInteres.Size = New System.Drawing.Size(130, 20)
        Me.txtInteres.TabIndex = 28
        '
        'txtSemanas
        '
        Me.txtSemanas.Location = New System.Drawing.Point(627, 64)
        Me.txtSemanas.Name = "txtSemanas"
        Me.txtSemanas.Size = New System.Drawing.Size(130, 20)
        Me.txtSemanas.TabIndex = 27
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(627, 32)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(130, 20)
        Me.txtMonto.TabIndex = 26
        '
        'lblJustificacion
        '
        Me.lblJustificacion.AutoSize = True
        Me.lblJustificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJustificacion.Location = New System.Drawing.Point(523, 214)
        Me.lblJustificacion.Name = "lblJustificacion"
        Me.lblJustificacion.Size = New System.Drawing.Size(81, 16)
        Me.lblJustificacion.TabIndex = 25
        Me.lblJustificacion.Text = "Justificacion"
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMotivo.Location = New System.Drawing.Point(523, 179)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(48, 16)
        Me.lblMotivo.TabIndex = 24
        Me.lblMotivo.Text = "Motivo"
        '
        'lblTipoDeInteres
        '
        Me.lblTipoDeInteres.AutoSize = True
        Me.lblTipoDeInteres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoDeInteres.Location = New System.Drawing.Point(523, 151)
        Me.lblTipoDeInteres.Name = "lblTipoDeInteres"
        Me.lblTipoDeInteres.Size = New System.Drawing.Size(98, 16)
        Me.lblTipoDeInteres.TabIndex = 23
        Me.lblTipoDeInteres.Text = "Tipo de Interés"
        '
        'lblAbono
        '
        Me.lblAbono.AutoSize = True
        Me.lblAbono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbono.Location = New System.Drawing.Point(523, 94)
        Me.lblAbono.Name = "lblAbono"
        Me.lblAbono.Size = New System.Drawing.Size(48, 16)
        Me.lblAbono.TabIndex = 22
        Me.lblAbono.Text = "Abono"
        '
        'lblInteres
        '
        Me.lblInteres.AutoSize = True
        Me.lblInteres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInteres.Location = New System.Drawing.Point(523, 123)
        Me.lblInteres.Name = "lblInteres"
        Me.lblInteres.Size = New System.Drawing.Size(102, 16)
        Me.lblInteres.TabIndex = 21
        Me.lblInteres.Text = "Interés mensual"
        '
        'lblSemanas
        '
        Me.lblSemanas.AutoSize = True
        Me.lblSemanas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSemanas.Location = New System.Drawing.Point(523, 66)
        Me.lblSemanas.Name = "lblSemanas"
        Me.lblSemanas.Size = New System.Drawing.Size(66, 16)
        Me.lblSemanas.TabIndex = 20
        Me.lblSemanas.Text = "Semanas"
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.Location = New System.Drawing.Point(523, 36)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(45, 16)
        Me.lblMonto.TabIndex = 19
        Me.lblMonto.Text = "Monto"
        '
        'lblSalario2
        '
        Me.lblSalario2.AutoSize = True
        Me.lblSalario2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalario2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblSalario2.Location = New System.Drawing.Point(252, 206)
        Me.lblSalario2.Name = "lblSalario2"
        Me.lblSalario2.Size = New System.Drawing.Size(58, 16)
        Me.lblSalario2.TabIndex = 18
        Me.lblSalario2.Text = "Salario"
        '
        'lblDepartamento2
        '
        Me.lblDepartamento2.AutoSize = True
        Me.lblDepartamento2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartamento2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblDepartamento2.Location = New System.Drawing.Point(252, 151)
        Me.lblDepartamento2.Name = "lblDepartamento2"
        Me.lblDepartamento2.Size = New System.Drawing.Size(106, 16)
        Me.lblDepartamento2.TabIndex = 17
        Me.lblDepartamento2.Text = "Departamento"
        '
        'lblNave2
        '
        Me.lblNave2.AutoSize = True
        Me.lblNave2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNave2.Location = New System.Drawing.Point(252, 123)
        Me.lblNave2.Name = "lblNave2"
        Me.lblNave2.Size = New System.Drawing.Size(45, 16)
        Me.lblNave2.TabIndex = 16
        Me.lblNave2.Text = "Nave"
        '
        'lblPuesto2
        '
        Me.lblPuesto2.AutoSize = True
        Me.lblPuesto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPuesto2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPuesto2.Location = New System.Drawing.Point(252, 181)
        Me.lblPuesto2.Name = "lblPuesto2"
        Me.lblPuesto2.Size = New System.Drawing.Size(56, 16)
        Me.lblPuesto2.TabIndex = 15
        Me.lblPuesto2.Text = "Puesto"
        '
        'lblFaltas2
        '
        Me.lblFaltas2.AutoSize = True
        Me.lblFaltas2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFaltas2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblFaltas2.Location = New System.Drawing.Point(252, 231)
        Me.lblFaltas2.Name = "lblFaltas2"
        Me.lblFaltas2.Size = New System.Drawing.Size(51, 16)
        Me.lblFaltas2.TabIndex = 14
        Me.lblFaltas2.Text = "Faltas"
        '
        'lblCajaDeAhorro2
        '
        Me.lblCajaDeAhorro2.AutoSize = True
        Me.lblCajaDeAhorro2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCajaDeAhorro2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblCajaDeAhorro2.Location = New System.Drawing.Point(252, 258)
        Me.lblCajaDeAhorro2.Name = "lblCajaDeAhorro2"
        Me.lblCajaDeAhorro2.Size = New System.Drawing.Size(106, 16)
        Me.lblCajaDeAhorro2.TabIndex = 13
        Me.lblCajaDeAhorro2.Text = "CajaDeAhorro"
        '
        'lblAntiguedad2
        '
        Me.lblAntiguedad2.AutoSize = True
        Me.lblAntiguedad2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAntiguedad2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAntiguedad2.Location = New System.Drawing.Point(252, 94)
        Me.lblAntiguedad2.Name = "lblAntiguedad2"
        Me.lblAntiguedad2.Size = New System.Drawing.Size(87, 16)
        Me.lblAntiguedad2.TabIndex = 12
        Me.lblAntiguedad2.Text = "Antiguedad"
        '
        'lblEdad2
        '
        Me.lblEdad2.AutoSize = True
        Me.lblEdad2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdad2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEdad2.Location = New System.Drawing.Point(252, 65)
        Me.lblEdad2.Name = "lblEdad2"
        Me.lblEdad2.Size = New System.Drawing.Size(45, 16)
        Me.lblEdad2.TabIndex = 11
        Me.lblEdad2.Text = "Edad"
        '
        'lblColaborador2
        '
        Me.lblColaborador2.AutoSize = True
        Me.lblColaborador2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColaborador2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblColaborador2.Location = New System.Drawing.Point(252, 36)
        Me.lblColaborador2.Name = "lblColaborador2"
        Me.lblColaborador2.Size = New System.Drawing.Size(95, 16)
        Me.lblColaborador2.TabIndex = 10
        Me.lblColaborador2.Text = "Colaborador"
        '
        'lblSalario
        '
        Me.lblSalario.AutoSize = True
        Me.lblSalario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalario.Location = New System.Drawing.Point(159, 206)
        Me.lblSalario.Name = "lblSalario"
        Me.lblSalario.Size = New System.Drawing.Size(51, 16)
        Me.lblSalario.TabIndex = 9
        Me.lblSalario.Text = "Salario"
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartamento.Location = New System.Drawing.Point(159, 151)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(94, 16)
        Me.lblDepartamento.TabIndex = 8
        Me.lblDepartamento.Text = "Departamento"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave.Location = New System.Drawing.Point(159, 123)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(41, 16)
        Me.lblNave.TabIndex = 7
        Me.lblNave.Text = "Nave"
        '
        'lblPuesto
        '
        Me.lblPuesto.AutoSize = True
        Me.lblPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPuesto.Location = New System.Drawing.Point(159, 181)
        Me.lblPuesto.Name = "lblPuesto"
        Me.lblPuesto.Size = New System.Drawing.Size(50, 16)
        Me.lblPuesto.TabIndex = 6
        Me.lblPuesto.Text = "Puesto"
        '
        'lblFaltas
        '
        Me.lblFaltas.AutoSize = True
        Me.lblFaltas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFaltas.Location = New System.Drawing.Point(159, 231)
        Me.lblFaltas.Name = "lblFaltas"
        Me.lblFaltas.Size = New System.Drawing.Size(45, 16)
        Me.lblFaltas.TabIndex = 5
        Me.lblFaltas.Text = "Faltas"
        '
        'lblCajaDeAhorro
        '
        Me.lblCajaDeAhorro.AutoSize = True
        Me.lblCajaDeAhorro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCajaDeAhorro.Location = New System.Drawing.Point(159, 258)
        Me.lblCajaDeAhorro.Name = "lblCajaDeAhorro"
        Me.lblCajaDeAhorro.Size = New System.Drawing.Size(97, 16)
        Me.lblCajaDeAhorro.TabIndex = 4
        Me.lblCajaDeAhorro.Text = "Caja de ahorro"
        '
        'lblAntiguedad
        '
        Me.lblAntiguedad.AutoSize = True
        Me.lblAntiguedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAntiguedad.Location = New System.Drawing.Point(159, 94)
        Me.lblAntiguedad.Name = "lblAntiguedad"
        Me.lblAntiguedad.Size = New System.Drawing.Size(77, 16)
        Me.lblAntiguedad.TabIndex = 3
        Me.lblAntiguedad.Text = "Antigüedad"
        '
        'lblEdad
        '
        Me.lblEdad.AutoSize = True
        Me.lblEdad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdad.Location = New System.Drawing.Point(159, 65)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(41, 16)
        Me.lblEdad.TabIndex = 2
        Me.lblEdad.Text = "Edad"
        '
        'lblColaborador
        '
        Me.lblColaborador.AutoSize = True
        Me.lblColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColaborador.Location = New System.Drawing.Point(159, 36)
        Me.lblColaborador.Name = "lblColaborador"
        Me.lblColaborador.Size = New System.Drawing.Size(84, 16)
        Me.lblColaborador.TabIndex = 1
        Me.lblColaborador.Text = "Colaborador"
        '
        'picBoxColaborador
        '
        Me.picBoxColaborador.Location = New System.Drawing.Point(11, 35)
        Me.picBoxColaborador.Name = "picBoxColaborador"
        Me.picBoxColaborador.Size = New System.Drawing.Size(141, 161)
        Me.picBoxColaborador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBoxColaborador.TabIndex = 0
        Me.picBoxColaborador.TabStop = False
        '
        'lblPagoTotal2
        '
        Me.lblPagoTotal2.AutoSize = True
        Me.lblPagoTotal2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagoTotal2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPagoTotal2.Location = New System.Drawing.Point(518, 4)
        Me.lblPagoTotal2.Name = "lblPagoTotal2"
        Me.lblPagoTotal2.Size = New System.Drawing.Size(44, 16)
        Me.lblPagoTotal2.TabIndex = 46
        Me.lblPagoTotal2.Text = "Total"
        '
        'lblInteresTotal2
        '
        Me.lblInteresTotal2.AutoSize = True
        Me.lblInteresTotal2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInteresTotal2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblInteresTotal2.Location = New System.Drawing.Point(349, 4)
        Me.lblInteresTotal2.Name = "lblInteresTotal2"
        Me.lblInteresTotal2.Size = New System.Drawing.Size(44, 16)
        Me.lblInteresTotal2.TabIndex = 45
        Me.lblInteresTotal2.Text = "Total"
        '
        'lblPagoTotal
        '
        Me.lblPagoTotal.AutoSize = True
        Me.lblPagoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagoTotal.Location = New System.Drawing.Point(439, 4)
        Me.lblPagoTotal.Name = "lblPagoTotal"
        Me.lblPagoTotal.Size = New System.Drawing.Size(72, 16)
        Me.lblPagoTotal.TabIndex = 44
        Me.lblPagoTotal.Text = "Pago total "
        '
        'lblInteresTotal
        '
        Me.lblInteresTotal.AutoSize = True
        Me.lblInteresTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInteresTotal.Location = New System.Drawing.Point(260, 4)
        Me.lblInteresTotal.Name = "lblInteresTotal"
        Me.lblInteresTotal.Size = New System.Drawing.Size(79, 16)
        Me.lblInteresTotal.TabIndex = 43
        Me.lblInteresTotal.Text = "Interés total "
        '
        'grdTablaAmortizacion
        '
        Me.grdTablaAmortizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTablaAmortizacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NumeroDePago, Me.AbonoACapital, Me.Interes, Me.Total, Me.NuevoSaldo})
        Me.grdTablaAmortizacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTablaAmortizacion.Location = New System.Drawing.Point(0, 374)
        Me.grdTablaAmortizacion.Name = "grdTablaAmortizacion"
        Me.grdTablaAmortizacion.Size = New System.Drawing.Size(878, 240)
        Me.grdTablaAmortizacion.TabIndex = 4
        '
        'NumeroDePago
        '
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.NumeroDePago.DefaultCellStyle = DataGridViewCellStyle1
        Me.NumeroDePago.HeaderText = "Numero de pago"
        Me.NumeroDePago.Name = "NumeroDePago"
        Me.NumeroDePago.ReadOnly = True
        Me.NumeroDePago.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.NumeroDePago.Width = 150
        '
        'AbonoACapital
        '
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.AbonoACapital.DefaultCellStyle = DataGridViewCellStyle2
        Me.AbonoACapital.HeaderText = "Abono a capital"
        Me.AbonoACapital.Name = "AbonoACapital"
        Me.AbonoACapital.ReadOnly = True
        Me.AbonoACapital.Width = 164
        '
        'Interes
        '
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Interes.DefaultCellStyle = DataGridViewCellStyle3
        Me.Interes.HeaderText = "Interés"
        Me.Interes.Name = "Interes"
        Me.Interes.ReadOnly = True
        Me.Interes.Width = 164
        '
        'Total
        '
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Total.DefaultCellStyle = DataGridViewCellStyle4
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Width = 165
        '
        'NuevoSaldo
        '
        Me.NuevoSaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.NuevoSaldo.DefaultCellStyle = DataGridViewCellStyle5
        Me.NuevoSaldo.HeaderText = "Nuevo saldo"
        Me.NuevoSaldo.Name = "NuevoSaldo"
        Me.NuevoSaldo.ReadOnly = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblPagoTotal2)
        Me.Panel2.Controls.Add(Me.lblInteresTotal)
        Me.Panel2.Controls.Add(Me.lblInteresTotal2)
        Me.Panel2.Controls.Add(Me.lblPagoTotal)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 589)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(878, 25)
        Me.Panel2.TabIndex = 5
        '
        'SolicitudPrestamos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 614)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.grdTablaAmortizacion)
        Me.Controls.Add(Me.pnlPropiedades)
        Me.Controls.Add(Me.pnlBanner)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SolicitudPrestamos"
        Me.Text = "SolicitudPrestamos"
        Me.pnlBanner.ResumeLayout(False)
        Me.pnlBanner.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.imgBanner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPropiedades.ResumeLayout(False)
        Me.pnlPropiedades.PerformLayout()
        CType(Me.picBoxColaborador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTablaAmortizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBanner As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgBanner As System.Windows.Forms.PictureBox
    Friend WithEvents pnlPropiedades As System.Windows.Forms.Panel
    Friend WithEvents lblSalario As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblPuesto As System.Windows.Forms.Label
    Friend WithEvents lblFaltas As System.Windows.Forms.Label
    Friend WithEvents lblCajaDeAhorro As System.Windows.Forms.Label
    Friend WithEvents lblAntiguedad As System.Windows.Forms.Label
    Friend WithEvents lblEdad As System.Windows.Forms.Label
    Friend WithEvents lblColaborador As System.Windows.Forms.Label
    Friend WithEvents picBoxColaborador As System.Windows.Forms.PictureBox
    Friend WithEvents lblSalario2 As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento2 As System.Windows.Forms.Label
    Friend WithEvents lblNave2 As System.Windows.Forms.Label
    Friend WithEvents lblPuesto2 As System.Windows.Forms.Label
    Friend WithEvents lblFaltas2 As System.Windows.Forms.Label
    Friend WithEvents lblCajaDeAhorro2 As System.Windows.Forms.Label
    Friend WithEvents lblAntiguedad2 As System.Windows.Forms.Label
    Friend WithEvents lblEdad2 As System.Windows.Forms.Label
    Friend WithEvents lblColaborador2 As System.Windows.Forms.Label
    Friend WithEvents lblJustificacion As System.Windows.Forms.Label
    Friend WithEvents lblMotivo As System.Windows.Forms.Label
    Friend WithEvents lblTipoDeInteres As System.Windows.Forms.Label
    Friend WithEvents lblAbono As System.Windows.Forms.Label
    Friend WithEvents lblInteres As System.Windows.Forms.Label
    Friend WithEvents lblSemanas As System.Windows.Forms.Label
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents txtJustificacion As System.Windows.Forms.TextBox
    Friend WithEvents cmbMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipoInteres As System.Windows.Forms.ComboBox
    Friend WithEvents txtAbono As System.Windows.Forms.TextBox
    Friend WithEvents txtInteres As System.Windows.Forms.TextBox
    Friend WithEvents txtSemanas As System.Windows.Forms.TextBox
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents grdTablaAmortizacion As System.Windows.Forms.DataGridView
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents rbtnAbono As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnSemanas As System.Windows.Forms.RadioButton
    Friend WithEvents lblCalcular As System.Windows.Forms.Label
    Friend WithEvents btnCalcular As System.Windows.Forms.Button
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents lblPagoTotal2 As System.Windows.Forms.Label
    Friend WithEvents lblInteresTotal2 As System.Windows.Forms.Label
    Friend WithEvents lblPagoTotal As System.Windows.Forms.Label
    Friend WithEvents lblInteresTotal As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents NumeroDePago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AbonoACapital As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Interes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NuevoSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
