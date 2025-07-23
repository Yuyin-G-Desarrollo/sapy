<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarDeduccionesExtraordinarias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarDeduccionesExtraordinarias))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlestado = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblcerrar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.grdDeducciones = New System.Windows.Forms.DataGridView()
        Me.clmNumeroPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmColaborador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmDepartamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSemanas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmMonto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAbono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSaldoNuevo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmIdColaborador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmIdDeduccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmIdPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmEstatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblSemanaNomina = New System.Windows.Forms.Label()
        Me.lblIdSemanaNomina = New System.Windows.Forms.Label()
        Me.lblSemanaNominaFIN = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlestado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        CType(Me.grdDeducciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlestado
        '
        Me.pnlestado.BackColor = System.Drawing.Color.White
        Me.pnlestado.Controls.Add(Me.pnlAcciones)
        Me.pnlestado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlestado.Location = New System.Drawing.Point(0, 369)
        Me.pnlestado.Name = "pnlestado"
        Me.pnlestado.Size = New System.Drawing.Size(864, 60)
        Me.pnlestado.TabIndex = 62
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblcerrar)
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(736, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(128, 60)
        Me.pnlAcciones.TabIndex = 17
        '
        'lblcerrar
        '
        Me.lblcerrar.AutoSize = True
        Me.lblcerrar.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblcerrar.Location = New System.Drawing.Point(79, 41)
        Me.lblcerrar.Name = "lblcerrar"
        Me.lblcerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblcerrar.TabIndex = 20
        Me.lblcerrar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Nomina.Vista.My.Resources.Resources.cancelar_32
        Me.btnCerrar.Location = New System.Drawing.Point(78, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 19
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(29, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 18
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(24, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 3
        Me.lblGuardar.Text = "Guardar"
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.Transparent
        Me.grbParametros.Controls.Add(Me.btnLimpiar)
        Me.grbParametros.Controls.Add(Me.lblLimpiar)
        Me.grbParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Controls.Add(Me.Label1)
        Me.grbParametros.Controls.Add(Me.lblBuscar)
        Me.grbParametros.Controls.Add(Me.btnBuscar)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grbParametros.Location = New System.Drawing.Point(0, 59)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(864, 115)
        Me.grbParametros.TabIndex = 61
        Me.grbParametros.TabStop = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(355, 55)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 59
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(353, 91)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 58
        Me.lblLimpiar.Text = "Limpiar"
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(811, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(50, 96)
        Me.pnlMinimizarParametros.TabIndex = 54
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnArriba.Location = New System.Drawing.Point(3, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAbajo.Location = New System.Drawing.Point(25, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(61, 55)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(217, 21)
        Me.cmbNave.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(22, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Nave"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBuscar.Location = New System.Drawing.Point(305, 91)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 37
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBuscar.Location = New System.Drawing.Point(308, 55)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 36
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'grdDeducciones
        '
        Me.grdDeducciones.AllowUserToAddRows = False
        Me.grdDeducciones.AllowUserToDeleteRows = False
        Me.grdDeducciones.AllowUserToResizeRows = False
        Me.grdDeducciones.BackgroundColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDeducciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDeducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDeducciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmNumeroPago, Me.clmColaborador, Me.clmDepartamento, Me.clmPuesto, Me.clmConcepto, Me.clmSemanas, Me.clmMonto, Me.clmSaldo, Me.clmAbono, Me.clmSaldoNuevo, Me.clmIdColaborador, Me.clmIdDeduccion, Me.clmIdPago, Me.clmEstatus})
        Me.grdDeducciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDeducciones.Location = New System.Drawing.Point(0, 174)
        Me.grdDeducciones.Name = "grdDeducciones"
        Me.grdDeducciones.Size = New System.Drawing.Size(864, 195)
        Me.grdDeducciones.TabIndex = 63
        '
        'clmNumeroPago
        '
        Me.clmNumeroPago.HeaderText = "Número de Pago"
        Me.clmNumeroPago.Name = "clmNumeroPago"
        Me.clmNumeroPago.ReadOnly = True
        Me.clmNumeroPago.Width = 55
        '
        'clmColaborador
        '
        Me.clmColaborador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmColaborador.DefaultCellStyle = DataGridViewCellStyle2
        Me.clmColaborador.HeaderText = "Colaborador"
        Me.clmColaborador.Name = "clmColaborador"
        Me.clmColaborador.ReadOnly = True
        Me.clmColaborador.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmColaborador.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clmDepartamento
        '
        Me.clmDepartamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmDepartamento.DefaultCellStyle = DataGridViewCellStyle3
        Me.clmDepartamento.HeaderText = "Departamento"
        Me.clmDepartamento.Name = "clmDepartamento"
        Me.clmDepartamento.ReadOnly = True
        Me.clmDepartamento.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmDepartamento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmDepartamento.Visible = False
        '
        'clmPuesto
        '
        Me.clmPuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.clmPuesto.HeaderText = "Puesto"
        Me.clmPuesto.Name = "clmPuesto"
        Me.clmPuesto.ReadOnly = True
        Me.clmPuesto.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmPuesto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmPuesto.Visible = False
        '
        'clmConcepto
        '
        Me.clmConcepto.HeaderText = "Concepto"
        Me.clmConcepto.Name = "clmConcepto"
        Me.clmConcepto.ReadOnly = True
        Me.clmConcepto.Width = 170
        '
        'clmSemanas
        '
        Me.clmSemanas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.clmSemanas.DefaultCellStyle = DataGridViewCellStyle4
        Me.clmSemanas.HeaderText = "Semanas"
        Me.clmSemanas.Name = "clmSemanas"
        Me.clmSemanas.ReadOnly = True
        Me.clmSemanas.Visible = False
        '
        'clmMonto
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.clmMonto.DefaultCellStyle = DataGridViewCellStyle5
        Me.clmMonto.HeaderText = "Monto"
        Me.clmMonto.Name = "clmMonto"
        Me.clmMonto.ReadOnly = True
        Me.clmMonto.Width = 70
        '
        'clmSaldo
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.clmSaldo.DefaultCellStyle = DataGridViewCellStyle6
        Me.clmSaldo.HeaderText = "Saldo"
        Me.clmSaldo.Name = "clmSaldo"
        Me.clmSaldo.ReadOnly = True
        Me.clmSaldo.Width = 70
        '
        'clmAbono
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "C2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.clmAbono.DefaultCellStyle = DataGridViewCellStyle7
        Me.clmAbono.HeaderText = "Abono"
        Me.clmAbono.Name = "clmAbono"
        Me.clmAbono.Width = 70
        '
        'clmSaldoNuevo
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "C2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.clmSaldoNuevo.DefaultCellStyle = DataGridViewCellStyle8
        Me.clmSaldoNuevo.HeaderText = "Saldo nuevo"
        Me.clmSaldoNuevo.Name = "clmSaldoNuevo"
        Me.clmSaldoNuevo.ReadOnly = True
        Me.clmSaldoNuevo.Width = 70
        '
        'clmIdColaborador
        '
        Me.clmIdColaborador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.clmIdColaborador.HeaderText = "IdColaborador"
        Me.clmIdColaborador.Name = "clmIdColaborador"
        Me.clmIdColaborador.ReadOnly = True
        Me.clmIdColaborador.Visible = False
        '
        'clmIdDeduccion
        '
        Me.clmIdDeduccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.clmIdDeduccion.HeaderText = "IdDeduccion"
        Me.clmIdDeduccion.Name = "clmIdDeduccion"
        Me.clmIdDeduccion.ReadOnly = True
        Me.clmIdDeduccion.Visible = False
        '
        'clmIdPago
        '
        Me.clmIdPago.HeaderText = "IdPAgo"
        Me.clmIdPago.Name = "clmIdPago"
        Me.clmIdPago.Visible = False
        '
        'clmEstatus
        '
        Me.clmEstatus.HeaderText = "Estatus"
        Me.clmEstatus.Name = "clmEstatus"
        Me.clmEstatus.ReadOnly = True
        Me.clmEstatus.Visible = False
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblSemanaNomina)
        Me.pnlHeader.Controls.Add(Me.lblIdSemanaNomina)
        Me.pnlHeader.Controls.Add(Me.lblSemanaNominaFIN)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(864, 59)
        Me.pnlHeader.TabIndex = 60
        '
        'lblSemanaNomina
        '
        Me.lblSemanaNomina.AutoSize = True
        Me.lblSemanaNomina.Location = New System.Drawing.Point(218, 29)
        Me.lblSemanaNomina.Name = "lblSemanaNomina"
        Me.lblSemanaNomina.Size = New System.Drawing.Size(42, 13)
        Me.lblSemanaNomina.TabIndex = 14
        Me.lblSemanaNomina.Text = "Estatus"
        '
        'lblIdSemanaNomina
        '
        Me.lblIdSemanaNomina.AutoSize = True
        Me.lblIdSemanaNomina.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIdSemanaNomina.Location = New System.Drawing.Point(11, 15)
        Me.lblIdSemanaNomina.Name = "lblIdSemanaNomina"
        Me.lblIdSemanaNomina.Size = New System.Drawing.Size(65, 26)
        Me.lblIdSemanaNomina.TabIndex = 6
        Me.lblIdSemanaNomina.Text = "lblIdSemana" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Nomina"
        '
        'lblSemanaNominaFIN
        '
        Me.lblSemanaNominaFIN.AutoSize = True
        Me.lblSemanaNominaFIN.Location = New System.Drawing.Point(82, 28)
        Me.lblSemanaNominaFIN.Name = "lblSemanaNominaFIN"
        Me.lblSemanaNominaFIN.Size = New System.Drawing.Size(109, 13)
        Me.lblSemanaNominaFIN.TabIndex = 13
        Me.lblSemanaNominaFIN.Text = "lblSemanaNominaFIN"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(369, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(495, 59)
        Me.pnlTitulo.TabIndex = 5
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitulo.Location = New System.Drawing.Point(75, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(357, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Editar pago de deducciones extraordinarias"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(427, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 3
        Me.pcbTitulo.TabStop = False
        '
        'EditarDeduccionesExtraordinarias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(864, 429)
        Me.Controls.Add(Me.grdDeducciones)
        Me.Controls.Add(Me.pnlestado)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "EditarDeduccionesExtraordinarias"
        Me.Text = "EditarDeduccionesExtraordinarias"
        Me.pnlestado.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        CType(Me.grdDeducciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlestado As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents grdDeducciones As System.Windows.Forms.DataGridView
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblSemanaNomina As System.Windows.Forms.Label
    Friend WithEvents lblIdSemanaNomina As System.Windows.Forms.Label
    Friend WithEvents lblSemanaNominaFIN As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblcerrar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents clmNumeroPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmColaborador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmDepartamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmPuesto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSemanas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmMonto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmAbono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSaldoNuevo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmIdColaborador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmIdDeduccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmIdPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmEstatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcbTitulo As PictureBox
End Class
