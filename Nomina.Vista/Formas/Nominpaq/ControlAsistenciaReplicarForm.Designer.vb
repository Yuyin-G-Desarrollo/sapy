<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlAsistenciaReplicarForm
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlAsistenciaReplicarForm))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grdListaIncapacidades = New System.Windows.Forms.DataGridView()
        Me.clmNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmReplicar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmColaborador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmQuefue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmFechaIncidencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmIncidenciaNP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmDataSource = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmServidor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmidColaboradorNP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmidRegistroCheck = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmIDIncidenciaNP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTipoIncidencia = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SeleccionarTodosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeseleccionarTodosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbPeriodoTermina = New System.Windows.Forms.ComboBox()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.cmbPeriodoInicial = New System.Windows.Forms.ComboBox()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.clmbPeriodoFinal = New System.Windows.Forms.Panel()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        CType(Me.grdListaIncapacidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.clmbPeriodoFinal.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdListaIncapacidades
        '
        Me.grdListaIncapacidades.AllowUserToAddRows = False
        Me.grdListaIncapacidades.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaIncapacidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdListaIncapacidades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmNumero, Me.clmReplicar, Me.clmColaborador, Me.clmQuefue, Me.clmFechaIncidencia, Me.clmIncidenciaNP, Me.clmDataSource, Me.clmServidor, Me.clmidColaboradorNP, Me.clmidRegistroCheck, Me.clmIDIncidenciaNP, Me.clmTipoIncidencia})
        Me.grdListaIncapacidades.ContextMenuStrip = Me.ContextMenuStrip
        Me.grdListaIncapacidades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaIncapacidades.Location = New System.Drawing.Point(0, 172)
        Me.grdListaIncapacidades.Name = "grdListaIncapacidades"
        Me.grdListaIncapacidades.Size = New System.Drawing.Size(1145, 286)
        Me.grdListaIncapacidades.TabIndex = 62
        '
        'clmNumero
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.clmNumero.DefaultCellStyle = DataGridViewCellStyle1
        Me.clmNumero.Frozen = True
        Me.clmNumero.HeaderText = "#"
        Me.clmNumero.Name = "clmNumero"
        Me.clmNumero.ReadOnly = True
        Me.clmNumero.Width = 30
        '
        'clmReplicar
        '
        Me.clmReplicar.Frozen = True
        Me.clmReplicar.HeaderText = "R"
        Me.clmReplicar.Name = "clmReplicar"
        Me.clmReplicar.ToolTipText = "Replicar"
        Me.clmReplicar.Width = 30
        '
        'clmColaborador
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmColaborador.DefaultCellStyle = DataGridViewCellStyle2
        Me.clmColaborador.Frozen = True
        Me.clmColaborador.HeaderText = "Colaborador"
        Me.clmColaborador.Name = "clmColaborador"
        Me.clmColaborador.ReadOnly = True
        Me.clmColaborador.Width = 280
        '
        'clmQuefue
        '
        Me.clmQuefue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmQuefue.DefaultCellStyle = DataGridViewCellStyle3
        Me.clmQuefue.HeaderText = "Incidencia"
        Me.clmQuefue.Name = "clmQuefue"
        Me.clmQuefue.Width = 150
        '
        'clmFechaIncidencia
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.clmFechaIncidencia.DefaultCellStyle = DataGridViewCellStyle4
        Me.clmFechaIncidencia.HeaderText = "Fecha Incidencia"
        Me.clmFechaIncidencia.Name = "clmFechaIncidencia"
        Me.clmFechaIncidencia.Width = 150
        '
        'clmIncidenciaNP
        '
        Me.clmIncidenciaNP.HeaderText = "Incidencia NP"
        Me.clmIncidenciaNP.Name = "clmIncidenciaNP"
        Me.clmIncidenciaNP.Width = 180
        '
        'clmDataSource
        '
        Me.clmDataSource.HeaderText = "DataSource"
        Me.clmDataSource.Name = "clmDataSource"
        Me.clmDataSource.ReadOnly = True
        Me.clmDataSource.Visible = False
        '
        'clmServidor
        '
        Me.clmServidor.HeaderText = "Servidor"
        Me.clmServidor.Name = "clmServidor"
        Me.clmServidor.Visible = False
        '
        'clmidColaboradorNP
        '
        Me.clmidColaboradorNP.HeaderText = "IDColaborador NP"
        Me.clmidColaboradorNP.Name = "clmidColaboradorNP"
        Me.clmidColaboradorNP.ReadOnly = True
        Me.clmidColaboradorNP.Visible = False
        '
        'clmidRegistroCheck
        '
        Me.clmidRegistroCheck.HeaderText = "idRegistroCheck"
        Me.clmidRegistroCheck.Name = "clmidRegistroCheck"
        Me.clmidRegistroCheck.Visible = False
        '
        'clmIDIncidenciaNP
        '
        Me.clmIDIncidenciaNP.HeaderText = "IDIncidenciaNP"
        Me.clmIDIncidenciaNP.Name = "clmIDIncidenciaNP"
        Me.clmIDIncidenciaNP.Visible = False
        '
        'clmTipoIncidencia
        '
        Me.clmTipoIncidencia.HeaderText = "Tipo incidencia"
        Me.clmTipoIncidencia.Name = "clmTipoIncidencia"
        Me.clmTipoIncidencia.Width = 200
        '
        'ContextMenuStrip
        '
        Me.ContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeleccionarTodosToolStripMenuItem, Me.DeseleccionarTodosToolStripMenuItem})
        Me.ContextMenuStrip.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip.Size = New System.Drawing.Size(171, 48)
        '
        'SeleccionarTodosToolStripMenuItem
        '
        Me.SeleccionarTodosToolStripMenuItem.Name = "SeleccionarTodosToolStripMenuItem"
        Me.SeleccionarTodosToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.SeleccionarTodosToolStripMenuItem.Text = "Seleccionar todos"
        '
        'DeseleccionarTodosToolStripMenuItem
        '
        Me.DeseleccionarTodosToolStripMenuItem.Name = "DeseleccionarTodosToolStripMenuItem"
        Me.DeseleccionarTodosToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.DeseleccionarTodosToolStripMenuItem.Text = "Deseleccionar todos"
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Controls.Add(Me.Label2)
        Me.grbParametros.Controls.Add(Me.cmbPeriodoTermina)
        Me.grbParametros.Controls.Add(Me.lblPeriodo)
        Me.grbParametros.Controls.Add(Me.cmbPeriodoInicial)
        Me.grbParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Controls.Add(Me.lblNave)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 59)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1145, 113)
        Me.grbParametros.TabIndex = 63
        Me.grbParametros.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(432, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Periodo Final"
        Me.Label2.Visible = False
        '
        'cmbPeriodoTermina
        '
        Me.cmbPeriodoTermina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodoTermina.ForeColor = System.Drawing.Color.Black
        Me.cmbPeriodoTermina.FormattingEnabled = True
        Me.cmbPeriodoTermina.Location = New System.Drawing.Point(502, 73)
        Me.cmbPeriodoTermina.Name = "cmbPeriodoTermina"
        Me.cmbPeriodoTermina.Size = New System.Drawing.Size(318, 21)
        Me.cmbPeriodoTermina.TabIndex = 56
        Me.cmbPeriodoTermina.Visible = False
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriodo.ForeColor = System.Drawing.Color.Black
        Me.lblPeriodo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPeriodo.Location = New System.Drawing.Point(23, 81)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(73, 13)
        Me.lblPeriodo.TabIndex = 55
        Me.lblPeriodo.Text = "Periodo Inicial"
        '
        'cmbPeriodoInicial
        '
        Me.cmbPeriodoInicial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodoInicial.ForeColor = System.Drawing.Color.Black
        Me.cmbPeriodoInicial.FormattingEnabled = True
        Me.cmbPeriodoInicial.Location = New System.Drawing.Point(102, 73)
        Me.cmbPeriodoInicial.Name = "cmbPeriodoInicial"
        Me.cmbPeriodoInicial.Size = New System.Drawing.Size(318, 21)
        Me.cmbPeriodoInicial.TabIndex = 54
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.btnLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.Label1)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnBuscar)
        Me.pnlMinimizarParametros.Controls.Add(Me.lblBuscar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(1017, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(125, 94)
        Me.pnlMinimizarParametros.TabIndex = 53
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(83, 46)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 65
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(81, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Limpiar"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(32, 46)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 57
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(28, 78)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 56
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(72, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(95, 3)
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
        Me.cmbNave.Location = New System.Drawing.Point(102, 46)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(318, 21)
        Me.cmbNave.TabIndex = 14
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(63, 46)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 17
        Me.lblNave.Text = "Nave"
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.Label6)
        Me.pnlEstado.Controls.Add(Me.Label3)
        Me.pnlEstado.Controls.Add(Me.Label4)
        Me.pnlEstado.Controls.Add(Me.Label7)
        Me.pnlEstado.Controls.Add(Me.pnlAcciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 458)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1145, 60)
        Me.pnlEstado.TabIndex = 61
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(241, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Colaborador sin replicar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.LightSalmon
        Me.Label3.Location = New System.Drawing.Point(220, 35)
        Me.Label3.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label3.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 15)
        Me.Label3.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(158, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Patron sin relacion en nominpaq"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Salmon
        Me.Label7.Location = New System.Drawing.Point(5, 35)
        Me.Label7.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label7.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 15)
        Me.Label7.TabIndex = 27
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnCancelar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(934, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(211, 60)
        Me.pnlAcciones.TabIndex = 18
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(115, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 32
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(107, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(46, 13)
        Me.lblGuardar.TabIndex = 33
        Me.lblGuardar.Text = "Replicar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(166, 7)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 30
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(165, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 31
        Me.lblCancelar.Text = "Cerrar"
        '
        'clmbPeriodoFinal
        '
        Me.clmbPeriodoFinal.BackColor = System.Drawing.Color.White
        Me.clmbPeriodoFinal.Controls.Add(Me.lblFechaInicio)
        Me.clmbPeriodoFinal.Controls.Add(Me.pnlTitulo)
        Me.clmbPeriodoFinal.Dock = System.Windows.Forms.DockStyle.Top
        Me.clmbPeriodoFinal.Location = New System.Drawing.Point(0, 0)
        Me.clmbPeriodoFinal.Name = "clmbPeriodoFinal"
        Me.clmbPeriodoFinal.Size = New System.Drawing.Size(1145, 59)
        Me.clmbPeriodoFinal.TabIndex = 60
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicio.ForeColor = System.Drawing.Color.Black
        Me.lblFechaInicio.Location = New System.Drawing.Point(12, 9)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(51, 13)
        Me.lblFechaInicio.TabIndex = 18
        Me.lblFechaInicio.Text = "FechaFin"
        Me.lblFechaInicio.Visible = False
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(768, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(377, 59)
        Me.pnlTitulo.TabIndex = 5
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitulo.Location = New System.Drawing.Point(77, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(226, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Replicar Control Asistencia"
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "#"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 30
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "Colaborador"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn3.HeaderText = "Incidencia"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 150
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn4.HeaderText = "Fecha Incidencia"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "DataSource"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        Me.DataGridViewTextBoxColumn5.Width = 180
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "IDColaborador NP"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "idRegistroCheck"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "idRegistroCheck"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "IDIncidenciaNP"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(309, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 29
        Me.pcbTitulo.TabStop = False
        '
        'ControlAsistenciaReplicarForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 518)
        Me.Controls.Add(Me.grdListaIncapacidades)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.clmbPeriodoFinal)
        Me.Name = "ControlAsistenciaReplicarForm"
        Me.Text = "Replicar control asistencia"
        CType(Me.grdListaIncapacidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip.ResumeLayout(False)
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.clmbPeriodoFinal.ResumeLayout(False)
        Me.clmbPeriodoFinal.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdListaIncapacidades As System.Windows.Forms.DataGridView
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents clmbPeriodoFinal As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbPeriodoTermina As System.Windows.Forms.ComboBox
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents cmbPeriodoInicial As System.Windows.Forms.ComboBox
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SeleccionarTodosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeseleccionarTodosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents clmNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmReplicar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clmColaborador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQuefue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmFechaIncidencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmIncidenciaNP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmDataSource As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmServidor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmidColaboradorNP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmidRegistroCheck As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmIDIncidenciaNP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmTipoIncidencia As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents pcbTitulo As PictureBox
End Class
