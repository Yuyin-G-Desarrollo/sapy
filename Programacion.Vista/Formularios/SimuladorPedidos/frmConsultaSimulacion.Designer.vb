<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaSimulacion
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnGenerarReporte = New System.Windows.Forms.Button()
        Me.lblExportarPDF = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.lblAccionRegresar = New System.Windows.Forms.Label()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.grpBotones = New System.Windows.Forms.GroupBox()
        Me.chkSimulador = New System.Windows.Forms.CheckBox()
        Me.grpAnios = New System.Windows.Forms.GroupBox()
        Me.numAnioInicio = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numAnioFin = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grpSemanas = New System.Windows.Forms.GroupBox()
        Me.numSemanaInicio = New System.Windows.Forms.NumericUpDown()
        Me.chkConCantidad = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numSemanaFin = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbNavesLineas = New System.Windows.Forms.ComboBox()
        Me.lblSimulacionFolio = New System.Windows.Forms.Label()
        Me.cmbFoliosSimulacion = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUP = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdPedidos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.exportExcelDetalle = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.grpBotones.SuspendLayout()
        Me.grpAnios.SuspendLayout()
        CType(Me.numAnioInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAnioFin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSemanas.SuspendLayout()
        CType(Me.numSemanaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSemanaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.grdPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.btnGenerarReporte)
        Me.pnlHeader.Controls.Add(Me.lblExportarPDF)
        Me.pnlHeader.Controls.Add(Me.Panel4)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(984, 60)
        Me.pnlHeader.TabIndex = 38
        '
        'btnGenerarReporte
        '
        Me.btnGenerarReporte.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnGenerarReporte.Location = New System.Drawing.Point(31, 8)
        Me.btnGenerarReporte.Name = "btnGenerarReporte"
        Me.btnGenerarReporte.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarReporte.TabIndex = 49
        Me.btnGenerarReporte.UseVisualStyleBackColor = True
        '
        'lblExportarPDF
        '
        Me.lblExportarPDF.AutoSize = True
        Me.lblExportarPDF.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarPDF.Location = New System.Drawing.Point(24, 42)
        Me.lblExportarPDF.Name = "lblExportarPDF"
        Me.lblExportarPDF.Size = New System.Drawing.Size(46, 13)
        Me.lblExportarPDF.TabIndex = 50
        Me.lblExportarPDF.Text = "Exportar"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Controls.Add(Me.lblTitulo)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(685, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(299, 60)
        Me.Panel4.TabIndex = 48
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(65, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(162, 20)
        Me.lblTitulo.TabIndex = 9
        Me.lblTitulo.Text = "Pedidos Colocados"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.pnlBotones)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 532)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(984, 60)
        Me.Panel3.TabIndex = 46
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.lblAccionRegresar)
        Me.pnlBotones.Controls.Add(Me.btnRegresar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(748, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(236, 60)
        Me.pnlBotones.TabIndex = 41
        '
        'lblAccionRegresar
        '
        Me.lblAccionRegresar.AutoSize = True
        Me.lblAccionRegresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccionRegresar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAccionRegresar.Location = New System.Drawing.Point(183, 41)
        Me.lblAccionRegresar.Name = "lblAccionRegresar"
        Me.lblAccionRegresar.Size = New System.Drawing.Size(35, 13)
        Me.lblAccionRegresar.TabIndex = 39
        Me.lblAccionRegresar.Text = "Cerrar"
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnRegresar.Location = New System.Drawing.Point(184, 8)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(32, 32)
        Me.btnRegresar.TabIndex = 7
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'grpBotones
        '
        Me.grpBotones.BackColor = System.Drawing.Color.Transparent
        Me.grpBotones.Controls.Add(Me.chkSimulador)
        Me.grpBotones.Controls.Add(Me.grpAnios)
        Me.grpBotones.Controls.Add(Me.grpSemanas)
        Me.grpBotones.Controls.Add(Me.lblNave)
        Me.grpBotones.Controls.Add(Me.cmbNavesLineas)
        Me.grpBotones.Controls.Add(Me.lblSimulacionFolio)
        Me.grpBotones.Controls.Add(Me.cmbFoliosSimulacion)
        Me.grpBotones.Controls.Add(Me.Panel2)
        Me.grpBotones.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBotones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grpBotones.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grpBotones.Location = New System.Drawing.Point(0, 60)
        Me.grpBotones.Name = "grpBotones"
        Me.grpBotones.Size = New System.Drawing.Size(984, 112)
        Me.grpBotones.TabIndex = 47
        Me.grpBotones.TabStop = False
        '
        'chkSimulador
        '
        Me.chkSimulador.AutoSize = True
        Me.chkSimulador.Location = New System.Drawing.Point(15, 58)
        Me.chkSimulador.Name = "chkSimulador"
        Me.chkSimulador.Size = New System.Drawing.Size(77, 17)
        Me.chkSimulador.TabIndex = 98
        Me.chkSimulador.Text = "Simulación"
        Me.chkSimulador.UseVisualStyleBackColor = True
        '
        'grpAnios
        '
        Me.grpAnios.Controls.Add(Me.numAnioInicio)
        Me.grpAnios.Controls.Add(Me.Label2)
        Me.grpAnios.Controls.Add(Me.numAnioFin)
        Me.grpAnios.Controls.Add(Me.Label3)
        Me.grpAnios.Dock = System.Windows.Forms.DockStyle.Right
        Me.grpAnios.Location = New System.Drawing.Point(475, 16)
        Me.grpAnios.Name = "grpAnios"
        Me.grpAnios.Size = New System.Drawing.Size(192, 93)
        Me.grpAnios.TabIndex = 94
        Me.grpAnios.TabStop = False
        Me.grpAnios.Text = "Rango Años"
        '
        'numAnioInicio
        '
        Me.numAnioInicio.Location = New System.Drawing.Point(59, 40)
        Me.numAnioInicio.Maximum = New Decimal(New Integer() {2100, 0, 0, 0})
        Me.numAnioInicio.Minimum = New Decimal(New Integer() {2015, 0, 0, 0})
        Me.numAnioInicio.Name = "numAnioInicio"
        Me.numAnioInicio.Size = New System.Drawing.Size(120, 20)
        Me.numAnioInicio.TabIndex = 34
        Me.numAnioInicio.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Inicio"
        '
        'numAnioFin
        '
        Me.numAnioFin.Location = New System.Drawing.Point(59, 66)
        Me.numAnioFin.Maximum = New Decimal(New Integer() {2100, 0, 0, 0})
        Me.numAnioFin.Minimum = New Decimal(New Integer() {2015, 0, 0, 0})
        Me.numAnioFin.Name = "numAnioFin"
        Me.numAnioFin.Size = New System.Drawing.Size(120, 20)
        Me.numAnioFin.TabIndex = 33
        Me.numAnioFin.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Fin"
        '
        'grpSemanas
        '
        Me.grpSemanas.Controls.Add(Me.numSemanaInicio)
        Me.grpSemanas.Controls.Add(Me.chkConCantidad)
        Me.grpSemanas.Controls.Add(Me.Label4)
        Me.grpSemanas.Controls.Add(Me.numSemanaFin)
        Me.grpSemanas.Controls.Add(Me.Label5)
        Me.grpSemanas.Dock = System.Windows.Forms.DockStyle.Right
        Me.grpSemanas.Location = New System.Drawing.Point(667, 16)
        Me.grpSemanas.Name = "grpSemanas"
        Me.grpSemanas.Size = New System.Drawing.Size(247, 93)
        Me.grpSemanas.TabIndex = 95
        Me.grpSemanas.TabStop = False
        Me.grpSemanas.Text = "Rango Semanas"
        '
        'numSemanaInicio
        '
        Me.numSemanaInicio.Location = New System.Drawing.Point(60, 40)
        Me.numSemanaInicio.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.numSemanaInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSemanaInicio.Name = "numSemanaInicio"
        Me.numSemanaInicio.Size = New System.Drawing.Size(59, 20)
        Me.numSemanaInicio.TabIndex = 38
        Me.numSemanaInicio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkConCantidad
        '
        Me.chkConCantidad.AutoSize = True
        Me.chkConCantidad.Checked = True
        Me.chkConCantidad.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkConCantidad.Location = New System.Drawing.Point(132, 69)
        Me.chkConCantidad.Name = "chkConCantidad"
        Me.chkConCantidad.Size = New System.Drawing.Size(112, 17)
        Me.chkConCantidad.TabIndex = 97
        Me.chkConCantidad.Text = "Solo con cantidad"
        Me.chkConCantidad.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Inicio"
        '
        'numSemanaFin
        '
        Me.numSemanaFin.Location = New System.Drawing.Point(60, 66)
        Me.numSemanaFin.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.numSemanaFin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSemanaFin.Name = "numSemanaFin"
        Me.numSemanaFin.Size = New System.Drawing.Size(59, 20)
        Me.numSemanaFin.TabIndex = 37
        Me.numSemanaFin.Value = New Decimal(New Integer() {52, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Fin"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave.Location = New System.Drawing.Point(12, 86)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 92
        Me.lblNave.Text = "Nave"
        '
        'cmbNavesLineas
        '
        Me.cmbNavesLineas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNavesLineas.FormattingEnabled = True
        Me.cmbNavesLineas.Location = New System.Drawing.Point(48, 82)
        Me.cmbNavesLineas.Name = "cmbNavesLineas"
        Me.cmbNavesLineas.Size = New System.Drawing.Size(311, 21)
        Me.cmbNavesLineas.TabIndex = 93
        '
        'lblSimulacionFolio
        '
        Me.lblSimulacionFolio.AutoSize = True
        Me.lblSimulacionFolio.Location = New System.Drawing.Point(117, 60)
        Me.lblSimulacionFolio.Name = "lblSimulacionFolio"
        Me.lblSimulacionFolio.Size = New System.Drawing.Size(29, 13)
        Me.lblSimulacionFolio.TabIndex = 91
        Me.lblSimulacionFolio.Text = "Folio"
        '
        'cmbFoliosSimulacion
        '
        Me.cmbFoliosSimulacion.Enabled = False
        Me.cmbFoliosSimulacion.FormattingEnabled = True
        Me.cmbFoliosSimulacion.Location = New System.Drawing.Point(152, 56)
        Me.cmbFoliosSimulacion.Name = "cmbFoliosSimulacion"
        Me.cmbFoliosSimulacion.Size = New System.Drawing.Size(207, 21)
        Me.cmbFoliosSimulacion.TabIndex = 90
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnDown)
        Me.Panel2.Controls.Add(Me.btnUP)
        Me.Panel2.Controls.Add(Me.btnMostrar)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(914, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(67, 93)
        Me.Panel2.TabIndex = 96
        '
        'btnDown
        '
        Me.btnDown.Image = Global.Programacion.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnDown.Location = New System.Drawing.Point(38, 3)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(20, 20)
        Me.btnDown.TabIndex = 33
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnUP
        '
        Me.btnUP.Image = Global.Programacion.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnUP.Location = New System.Drawing.Point(9, 3)
        Me.btnUP.Name = "btnUP"
        Me.btnUP.Size = New System.Drawing.Size(20, 20)
        Me.btnUP.TabIndex = 32
        Me.btnUP.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(19, 44)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 26
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(14, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Mostrar"
        '
        'grdPedidos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidos.DisplayLayout.Appearance = Appearance1
        Me.grdPedidos.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdPedidos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdPedidos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPedidos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidos.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdPedidos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPedidos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPedidos.Location = New System.Drawing.Point(0, 172)
        Me.grdPedidos.Name = "grdPedidos"
        Me.grdPedidos.Size = New System.Drawing.Size(984, 360)
        Me.grdPedidos.TabIndex = 48
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(237, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'frmConsultaSimulacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(984, 592)
        Me.Controls.Add(Me.grdPedidos)
        Me.Controls.Add(Me.grpBotones)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmConsultaSimulacion"
        Me.Text = "Pedidos Colocados"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.grpBotones.ResumeLayout(False)
        Me.grpBotones.PerformLayout()
        Me.grpAnios.ResumeLayout(False)
        Me.grpAnios.PerformLayout()
        CType(Me.numAnioInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAnioFin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSemanas.ResumeLayout(False)
        Me.grpSemanas.PerformLayout()
        CType(Me.numSemanaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSemanaFin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.grdPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents lblAccionRegresar As System.Windows.Forms.Label
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents grpBotones As System.Windows.Forms.GroupBox
    Friend WithEvents grdPedidos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblSimulacionFolio As System.Windows.Forms.Label
    Friend WithEvents cmbFoliosSimulacion As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbNavesLineas As System.Windows.Forms.ComboBox
    Friend WithEvents grpAnios As System.Windows.Forms.GroupBox
    Friend WithEvents numAnioInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numAnioFin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpSemanas As System.Windows.Forms.GroupBox
    Friend WithEvents numSemanaInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents numSemanaFin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnUP As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkConCantidad As System.Windows.Forms.CheckBox
    Friend WithEvents chkSimulador As System.Windows.Forms.CheckBox
    Friend WithEvents btnGenerarReporte As System.Windows.Forms.Button
    Friend WithEvents lblExportarPDF As System.Windows.Forms.Label
    Friend WithEvents exportExcelDetalle As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents PictureBox1 As PictureBox
End Class
