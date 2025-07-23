<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReporteCajaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteCajaForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblAccionCierreAnual = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblConceptoPeriodo = New System.Windows.Forms.Label()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.grbGroupCierreAnual = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.chkTotales = New System.Windows.Forms.CheckBox()
        Me.chkResumen = New System.Windows.Forms.CheckBox()
        Me.chkVerDetalleSemanas = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblAccionRegresar = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlGuardar = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlTotales = New System.Windows.Forms.Panel()
        Me.lblTotalEntregarT = New System.Windows.Forms.Label()
        Me.lblNuevoSaldoPrestamosT = New System.Windows.Forms.Label()
        Me.lblAbonoT = New System.Windows.Forms.Label()
        Me.lblSaldoPrestamosT = New System.Windows.Forms.Label()
        Me.lblInteresGanadoT = New System.Windows.Forms.Label()
        Me.lblMontoAcumuladoT = New System.Windows.Forms.Label()
        Me.lblTotalInteresesT = New System.Windows.Forms.Label()
        Me.lblTotalCajaT = New System.Windows.Forms.Label()
        Me.lblTotalEntregar = New System.Windows.Forms.Label()
        Me.lblNuevoSaldoPrestamos = New System.Windows.Forms.Label()
        Me.lblAbono = New System.Windows.Forms.Label()
        Me.lblSaldoPrestamos = New System.Windows.Forms.Label()
        Me.lblInteresGanado = New System.Windows.Forms.Label()
        Me.lblMontoAcumulado = New System.Windows.Forms.Label()
        Me.lblTotalIntereses = New System.Windows.Forms.Label()
        Me.lblTotalCaja = New System.Windows.Forms.Label()
        Me.grdCierre2 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Num = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Colaborador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menuImprimir = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ReporteAnualDeCajaDeAhorroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.grbGroupCierreAnual.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlGuardar.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlTotales.SuspendLayout()
        CType(Me.grdCierre2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuImprimir.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(24, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(258, 20)
        Me.lblTitulo.TabIndex = 9
        Me.lblTitulo.Text = "Cierre Anual de Caja de Ahorro"
        '
        'lblAccionCierreAnual
        '
        Me.lblAccionCierreAnual.AutoSize = True
        Me.lblAccionCierreAnual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccionCierreAnual.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAccionCierreAnual.Location = New System.Drawing.Point(87, 36)
        Me.lblAccionCierreAnual.Name = "lblAccionCierreAnual"
        Me.lblAccionCierreAnual.Size = New System.Drawing.Size(59, 13)
        Me.lblAccionCierreAnual.TabIndex = 21
        Me.lblAccionCierreAnual.Text = "Cerrar Caja"
        Me.lblAccionCierreAnual.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.AliceBlue
        Me.btnCerrar.Image = Global.Nomina.Vista.My.Resources.Resources.candado
        Me.btnCerrar.Location = New System.Drawing.Point(100, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 20
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'lblConceptoPeriodo
        '
        Me.lblConceptoPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblConceptoPeriodo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblConceptoPeriodo.Location = New System.Drawing.Point(103, 39)
        Me.lblConceptoPeriodo.Name = "lblConceptoPeriodo"
        Me.lblConceptoPeriodo.Size = New System.Drawing.Size(623, 15)
        Me.lblConceptoPeriodo.TabIndex = 11
        Me.lblConceptoPeriodo.Text = resources.GetString("lblConceptoPeriodo.Text")
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnRegresar.Location = New System.Drawing.Point(165, 6)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(32, 32)
        Me.btnRegresar.TabIndex = 36
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblPeriodo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPeriodo.Location = New System.Drawing.Point(47, 38)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(50, 15)
        Me.lblPeriodo.TabIndex = 10
        Me.lblPeriodo.Text = "Periodo"
        '
        'grbGroupCierreAnual
        '
        Me.grbGroupCierreAnual.BackColor = System.Drawing.Color.Transparent
        Me.grbGroupCierreAnual.Controls.Add(Me.Label2)
        Me.grbGroupCierreAnual.Controls.Add(Me.lblNave)
        Me.grbGroupCierreAnual.Controls.Add(Me.chkTotales)
        Me.grbGroupCierreAnual.Controls.Add(Me.chkResumen)
        Me.grbGroupCierreAnual.Controls.Add(Me.chkVerDetalleSemanas)
        Me.grbGroupCierreAnual.Controls.Add(Me.Panel1)
        Me.grbGroupCierreAnual.Controls.Add(Me.lblConceptoPeriodo)
        Me.grbGroupCierreAnual.Controls.Add(Me.lblPeriodo)
        Me.grbGroupCierreAnual.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbGroupCierreAnual.Location = New System.Drawing.Point(0, 60)
        Me.grbGroupCierreAnual.Name = "grbGroupCierreAnual"
        Me.grbGroupCierreAnual.Size = New System.Drawing.Size(1028, 92)
        Me.grbGroupCierreAnual.TabIndex = 35
        Me.grbGroupCierreAnual.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(47, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 15)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Nave"
        '
        'lblNave
        '
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblNave.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNave.Location = New System.Drawing.Point(103, 15)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(323, 20)
        Me.lblNave.TabIndex = 51
        '
        'chkTotales
        '
        Me.chkTotales.AutoSize = True
        Me.chkTotales.Checked = True
        Me.chkTotales.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTotales.Location = New System.Drawing.Point(336, 62)
        Me.chkTotales.Name = "chkTotales"
        Me.chkTotales.Size = New System.Drawing.Size(61, 17)
        Me.chkTotales.TabIndex = 50
        Me.chkTotales.Text = "Totales"
        Me.chkTotales.UseVisualStyleBackColor = True
        '
        'chkResumen
        '
        Me.chkResumen.AutoSize = True
        Me.chkResumen.Checked = True
        Me.chkResumen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkResumen.Location = New System.Drawing.Point(186, 62)
        Me.chkResumen.Name = "chkResumen"
        Me.chkResumen.Size = New System.Drawing.Size(131, 17)
        Me.chkResumen.TabIndex = 49
        Me.chkResumen.Text = "Resumen de semanas"
        Me.chkResumen.UseVisualStyleBackColor = True
        '
        'chkVerDetalleSemanas
        '
        Me.chkVerDetalleSemanas.AutoSize = True
        Me.chkVerDetalleSemanas.Checked = True
        Me.chkVerDetalleSemanas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVerDetalleSemanas.Location = New System.Drawing.Point(48, 62)
        Me.chkVerDetalleSemanas.Name = "chkVerDetalleSemanas"
        Me.chkVerDetalleSemanas.Size = New System.Drawing.Size(119, 17)
        Me.chkVerDetalleSemanas.TabIndex = 48
        Me.chkVerDetalleSemanas.Text = "Detalle de semanas"
        Me.chkVerDetalleSemanas.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnArriba)
        Me.Panel1.Controls.Add(Me.btnAbajo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(948, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(77, 73)
        Me.Panel1.TabIndex = 47
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(9, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 43
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(40, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 44
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Nomina.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(30, 6)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 49
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblAccionRegresar
        '
        Me.lblAccionRegresar.AutoSize = True
        Me.lblAccionRegresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccionRegresar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAccionRegresar.Location = New System.Drawing.Point(164, 40)
        Me.lblAccionRegresar.Name = "lblAccionRegresar"
        Me.lblAccionRegresar.Size = New System.Drawing.Size(35, 13)
        Me.lblAccionRegresar.TabIndex = 39
        Me.lblAccionRegresar.Text = "Cerrar"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pnlGuardar)
        Me.Panel2.Controls.Add(Me.btnRegresar)
        Me.Panel2.Controls.Add(Me.lblAccionRegresar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(823, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(205, 86)
        Me.Panel2.TabIndex = 41
        '
        'pnlGuardar
        '
        Me.pnlGuardar.Controls.Add(Me.lblGuardar)
        Me.pnlGuardar.Controls.Add(Me.btnCerrar)
        Me.pnlGuardar.Controls.Add(Me.btnGuardar)
        Me.pnlGuardar.Controls.Add(Me.lblAccionCierreAnual)
        Me.pnlGuardar.Location = New System.Drawing.Point(3, 3)
        Me.pnlGuardar.Name = "pnlGuardar"
        Me.pnlGuardar.Size = New System.Drawing.Size(148, 51)
        Me.pnlGuardar.TabIndex = 42
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(28, 37)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 41
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.AliceBlue
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(34, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 40
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.pnlTotales)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 475)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1028, 86)
        Me.Panel3.TabIndex = 42
        '
        'pnlTotales
        '
        Me.pnlTotales.Controls.Add(Me.lblTotalEntregarT)
        Me.pnlTotales.Controls.Add(Me.lblNuevoSaldoPrestamosT)
        Me.pnlTotales.Controls.Add(Me.lblAbonoT)
        Me.pnlTotales.Controls.Add(Me.lblSaldoPrestamosT)
        Me.pnlTotales.Controls.Add(Me.lblInteresGanadoT)
        Me.pnlTotales.Controls.Add(Me.lblMontoAcumuladoT)
        Me.pnlTotales.Controls.Add(Me.lblTotalInteresesT)
        Me.pnlTotales.Controls.Add(Me.lblTotalCajaT)
        Me.pnlTotales.Controls.Add(Me.lblTotalEntregar)
        Me.pnlTotales.Controls.Add(Me.lblNuevoSaldoPrestamos)
        Me.pnlTotales.Controls.Add(Me.lblAbono)
        Me.pnlTotales.Controls.Add(Me.lblSaldoPrestamos)
        Me.pnlTotales.Controls.Add(Me.lblInteresGanado)
        Me.pnlTotales.Controls.Add(Me.lblMontoAcumulado)
        Me.pnlTotales.Controls.Add(Me.lblTotalIntereses)
        Me.pnlTotales.Controls.Add(Me.lblTotalCaja)
        Me.pnlTotales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTotales.Location = New System.Drawing.Point(0, 0)
        Me.pnlTotales.Name = "pnlTotales"
        Me.pnlTotales.Size = New System.Drawing.Size(823, 86)
        Me.pnlTotales.TabIndex = 42
        '
        'lblTotalEntregarT
        '
        Me.lblTotalEntregarT.AutoSize = True
        Me.lblTotalEntregarT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalEntregarT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTotalEntregarT.Location = New System.Drawing.Point(675, 41)
        Me.lblTotalEntregarT.Name = "lblTotalEntregarT"
        Me.lblTotalEntregarT.Size = New System.Drawing.Size(12, 13)
        Me.lblTotalEntregarT.TabIndex = 18
        Me.lblTotalEntregarT.Text = "x"
        '
        'lblNuevoSaldoPrestamosT
        '
        Me.lblNuevoSaldoPrestamosT.AutoSize = True
        Me.lblNuevoSaldoPrestamosT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNuevoSaldoPrestamosT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNuevoSaldoPrestamosT.Location = New System.Drawing.Point(492, 41)
        Me.lblNuevoSaldoPrestamosT.Name = "lblNuevoSaldoPrestamosT"
        Me.lblNuevoSaldoPrestamosT.Size = New System.Drawing.Size(12, 13)
        Me.lblNuevoSaldoPrestamosT.TabIndex = 17
        Me.lblNuevoSaldoPrestamosT.Text = "x"
        '
        'lblAbonoT
        '
        Me.lblAbonoT.AutoSize = True
        Me.lblAbonoT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbonoT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblAbonoT.Location = New System.Drawing.Point(675, 13)
        Me.lblAbonoT.Name = "lblAbonoT"
        Me.lblAbonoT.Size = New System.Drawing.Size(12, 13)
        Me.lblAbonoT.TabIndex = 16
        Me.lblAbonoT.Text = "x"
        '
        'lblSaldoPrestamosT
        '
        Me.lblSaldoPrestamosT.AutoSize = True
        Me.lblSaldoPrestamosT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoPrestamosT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSaldoPrestamosT.Location = New System.Drawing.Point(492, 13)
        Me.lblSaldoPrestamosT.Name = "lblSaldoPrestamosT"
        Me.lblSaldoPrestamosT.Size = New System.Drawing.Size(12, 13)
        Me.lblSaldoPrestamosT.TabIndex = 15
        Me.lblSaldoPrestamosT.Text = "x"
        '
        'lblInteresGanadoT
        '
        Me.lblInteresGanadoT.AutoSize = True
        Me.lblInteresGanadoT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInteresGanadoT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblInteresGanadoT.Location = New System.Drawing.Point(128, 41)
        Me.lblInteresGanadoT.Name = "lblInteresGanadoT"
        Me.lblInteresGanadoT.Size = New System.Drawing.Size(12, 13)
        Me.lblInteresGanadoT.TabIndex = 14
        Me.lblInteresGanadoT.Text = "x"
        '
        'lblMontoAcumuladoT
        '
        Me.lblMontoAcumuladoT.AutoSize = True
        Me.lblMontoAcumuladoT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoAcumuladoT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMontoAcumuladoT.Location = New System.Drawing.Point(128, 16)
        Me.lblMontoAcumuladoT.Name = "lblMontoAcumuladoT"
        Me.lblMontoAcumuladoT.Size = New System.Drawing.Size(12, 13)
        Me.lblMontoAcumuladoT.TabIndex = 13
        Me.lblMontoAcumuladoT.Text = "x"
        '
        'lblTotalInteresesT
        '
        Me.lblTotalInteresesT.AutoSize = True
        Me.lblTotalInteresesT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalInteresesT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTotalInteresesT.Location = New System.Drawing.Point(281, 41)
        Me.lblTotalInteresesT.Name = "lblTotalInteresesT"
        Me.lblTotalInteresesT.Size = New System.Drawing.Size(12, 13)
        Me.lblTotalInteresesT.TabIndex = 12
        Me.lblTotalInteresesT.Text = "x"
        '
        'lblTotalCajaT
        '
        Me.lblTotalCajaT.AutoSize = True
        Me.lblTotalCajaT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCajaT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTotalCajaT.Location = New System.Drawing.Point(281, 16)
        Me.lblTotalCajaT.Name = "lblTotalCajaT"
        Me.lblTotalCajaT.Size = New System.Drawing.Size(12, 13)
        Me.lblTotalCajaT.TabIndex = 11
        Me.lblTotalCajaT.Text = "x"
        '
        'lblTotalEntregar
        '
        Me.lblTotalEntregar.AutoSize = True
        Me.lblTotalEntregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalEntregar.Location = New System.Drawing.Point(574, 41)
        Me.lblTotalEntregar.Name = "lblTotalEntregar"
        Me.lblTotalEntregar.Size = New System.Drawing.Size(88, 13)
        Me.lblTotalEntregar.TabIndex = 9
        Me.lblTotalEntregar.Text = "Total Entregar"
        '
        'lblNuevoSaldoPrestamos
        '
        Me.lblNuevoSaldoPrestamos.AutoSize = True
        Me.lblNuevoSaldoPrestamos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNuevoSaldoPrestamos.Location = New System.Drawing.Point(344, 41)
        Me.lblNuevoSaldoPrestamos.Name = "lblNuevoSaldoPrestamos"
        Me.lblNuevoSaldoPrestamos.Size = New System.Drawing.Size(142, 13)
        Me.lblNuevoSaldoPrestamos.TabIndex = 8
        Me.lblNuevoSaldoPrestamos.Text = "Nuevo Saldo Prestamos"
        '
        'lblAbono
        '
        Me.lblAbono.AutoSize = True
        Me.lblAbono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbono.Location = New System.Drawing.Point(574, 16)
        Me.lblAbono.Name = "lblAbono"
        Me.lblAbono.Size = New System.Drawing.Size(82, 13)
        Me.lblAbono.TabIndex = 7
        Me.lblAbono.Text = "Total Abonos"
        '
        'lblSaldoPrestamos
        '
        Me.lblSaldoPrestamos.AutoSize = True
        Me.lblSaldoPrestamos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoPrestamos.Location = New System.Drawing.Point(344, 16)
        Me.lblSaldoPrestamos.Name = "lblSaldoPrestamos"
        Me.lblSaldoPrestamos.Size = New System.Drawing.Size(101, 13)
        Me.lblSaldoPrestamos.TabIndex = 6
        Me.lblSaldoPrestamos.Text = "Saldo Prestamos"
        '
        'lblInteresGanado
        '
        Me.lblInteresGanado.AutoSize = True
        Me.lblInteresGanado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInteresGanado.Location = New System.Drawing.Point(11, 41)
        Me.lblInteresGanado.Name = "lblInteresGanado"
        Me.lblInteresGanado.Size = New System.Drawing.Size(94, 13)
        Me.lblInteresGanado.TabIndex = 5
        Me.lblInteresGanado.Text = "Interes Ganado"
        '
        'lblMontoAcumulado
        '
        Me.lblMontoAcumulado.AutoSize = True
        Me.lblMontoAcumulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoAcumulado.Location = New System.Drawing.Point(11, 16)
        Me.lblMontoAcumulado.Name = "lblMontoAcumulado"
        Me.lblMontoAcumulado.Size = New System.Drawing.Size(108, 13)
        Me.lblMontoAcumulado.TabIndex = 4
        Me.lblMontoAcumulado.Text = "Monto Acumulado"
        '
        'lblTotalIntereses
        '
        Me.lblTotalIntereses.AutoSize = True
        Me.lblTotalIntereses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalIntereses.Location = New System.Drawing.Point(177, 41)
        Me.lblTotalIntereses.Name = "lblTotalIntereses"
        Me.lblTotalIntereses.Size = New System.Drawing.Size(92, 13)
        Me.lblTotalIntereses.TabIndex = 3
        Me.lblTotalIntereses.Text = "Total Intereses"
        '
        'lblTotalCaja
        '
        Me.lblTotalCaja.AutoSize = True
        Me.lblTotalCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCaja.Location = New System.Drawing.Point(177, 16)
        Me.lblTotalCaja.Name = "lblTotalCaja"
        Me.lblTotalCaja.Size = New System.Drawing.Size(65, 13)
        Me.lblTotalCaja.TabIndex = 2
        Me.lblTotalCaja.Text = "Total Caja"
        '
        'grdCierre2
        '
        Me.grdCierre2.AllowUserToAddRows = False
        Me.grdCierre2.BackgroundColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCierre2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdCierre2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCierre2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Num, Me.Colaborador})
        Me.grdCierre2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCierre2.Location = New System.Drawing.Point(0, 152)
        Me.grdCierre2.Name = "grdCierre2"
        Me.grdCierre2.Size = New System.Drawing.Size(1028, 323)
        Me.grdCierre2.TabIndex = 43
        '
        'Id
        '
        Me.Id.Frozen = True
        Me.Id.HeaderText = ""
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        '
        'Num
        '
        Me.Num.Frozen = True
        Me.Num.HeaderText = "#"
        Me.Num.Name = "Num"
        Me.Num.ReadOnly = True
        Me.Num.Width = 30
        '
        'Colaborador
        '
        Me.Colaborador.Frozen = True
        Me.Colaborador.HeaderText = "Colaborador"
        Me.Colaborador.Name = "Colaborador"
        Me.Colaborador.ReadOnly = True
        Me.Colaborador.Width = 300
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = ""
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "#"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Colaborador"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'menuImprimir
        '
        Me.menuImprimir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReporteAnualDeCajaDeAhorroToolStripMenuItem})
        Me.menuImprimir.Name = "menuImprimir"
        Me.menuImprimir.Size = New System.Drawing.Size(235, 26)
        '
        'ReporteAnualDeCajaDeAhorroToolStripMenuItem
        '
        Me.ReporteAnualDeCajaDeAhorroToolStripMenuItem.Name = "ReporteAnualDeCajaDeAhorroToolStripMenuItem"
        Me.ReporteAnualDeCajaDeAhorroToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.ReporteAnualDeCajaDeAhorroToolStripMenuItem.Text = "Reporte Anual de Caja de Ahorro"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Controls.Add(Me.btnImprimir)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1028, 60)
        Me.pnlHeader.TabIndex = 44
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(25, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Imprimir"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(675, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(353, 60)
        Me.pnlTitulo.TabIndex = 26
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(285, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 26
        Me.pcbTitulo.TabStop = False
        '
        'ReporteCajaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1028, 561)
        Me.Controls.Add(Me.grdCierre2)
        Me.Controls.Add(Me.grbGroupCierreAnual)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "ReporteCajaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Caja de Ahorro"
        Me.grbGroupCierreAnual.ResumeLayout(False)
        Me.grbGroupCierreAnual.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlGuardar.ResumeLayout(False)
        Me.pnlGuardar.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.pnlTotales.ResumeLayout(False)
        Me.pnlTotales.PerformLayout()
        CType(Me.grdCierre2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuImprimir.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblConceptoPeriodo As System.Windows.Forms.Label
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents grbGroupCierreAnual As System.Windows.Forms.GroupBox
    Friend WithEvents lblAccionRegresar As System.Windows.Forms.Label
    Friend WithEvents lblAccionCierreAnual As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents grdCierre2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents menuImprimir As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ReporteAnualDeCajaDeAhorroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlGuardar As System.Windows.Forms.Panel
    Friend WithEvents chkTotales As System.Windows.Forms.CheckBox
    Friend WithEvents chkResumen As System.Windows.Forms.CheckBox
    Friend WithEvents chkVerDetalleSemanas As System.Windows.Forms.CheckBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlTotales As System.Windows.Forms.Panel
    Friend WithEvents lblTotalEntregar As System.Windows.Forms.Label
    Friend WithEvents lblNuevoSaldoPrestamos As System.Windows.Forms.Label
    Friend WithEvents lblAbono As System.Windows.Forms.Label
    Friend WithEvents lblSaldoPrestamos As System.Windows.Forms.Label
    Friend WithEvents lblInteresGanado As System.Windows.Forms.Label
    Friend WithEvents lblMontoAcumulado As System.Windows.Forms.Label
    Friend WithEvents lblTotalIntereses As System.Windows.Forms.Label
    Friend WithEvents lblTotalCaja As System.Windows.Forms.Label
    Friend WithEvents lblTotalEntregarT As System.Windows.Forms.Label
    Friend WithEvents lblNuevoSaldoPrestamosT As System.Windows.Forms.Label
    Friend WithEvents lblAbonoT As System.Windows.Forms.Label
    Friend WithEvents lblSaldoPrestamosT As System.Windows.Forms.Label
    Friend WithEvents lblInteresGanadoT As System.Windows.Forms.Label
    Friend WithEvents lblMontoAcumuladoT As System.Windows.Forms.Label
    Friend WithEvents lblTotalInteresesT As System.Windows.Forms.Label
    Friend WithEvents lblTotalCajaT As System.Windows.Forms.Label
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Colaborador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcbTitulo As PictureBox
End Class
