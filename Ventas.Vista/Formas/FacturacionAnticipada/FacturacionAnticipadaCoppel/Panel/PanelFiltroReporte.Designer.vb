<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PanelFiltroReporte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PanelFiltroReporte))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grpFiltro = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grpPedidos = New System.Windows.Forms.GroupBox()
        Me.rdbEntregados = New System.Windows.Forms.RadioButton()
        Me.rdbPendientesEntregar = New System.Windows.Forms.RadioButton()
        Me.rdbPedientesFacturar = New System.Windows.Forms.RadioButton()
        Me.rdbTodos = New System.Windows.Forms.RadioButton()
        Me.cmbTipoReporte = New System.Windows.Forms.ComboBox()
        Me.tbcPanelFiltro = New System.Windows.Forms.TabControl()
        Me.tbpSemana = New System.Windows.Forms.TabPage()
        Me.txtSemanaFin = New System.Windows.Forms.NumericUpDown()
        Me.txtSemanaInicio = New System.Windows.Forms.NumericUpDown()
        Me.txtAnio = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbpFecha = New System.Windows.Forms.TabPage()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.lblAl = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblDel = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpFiltro.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.grpPedidos.SuspendLayout()
        Me.tbcPanelFiltro.SuspendLayout()
        Me.tbpSemana.SuspendLayout()
        CType(Me.txtSemanaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSemanaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpFecha.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(269, 65)
        Me.pnlEncabezado.TabIndex = 44
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(269, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(3, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(200, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Planeación de Entregas"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.lblCerrar)
        Me.pnlPie.Controls.Add(Me.lblImprimir)
        Me.pnlPie.Controls.Add(Me.btnImprimir)
        Me.pnlPie.Controls.Add(Me.btnCerrar)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 369)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(269, 63)
        Me.pnlPie.TabIndex = 50
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(229, 41)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblImprimir.Location = New System.Drawing.Point(176, 41)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 162
        Me.lblImprimir.Text = "Imprimir"
        '
        'btnImprimir
        '
        Me.btnImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImprimir.Image = Global.Ventas.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImprimir.Location = New System.Drawing.Point(181, 6)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 161
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(230, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grpFiltro)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(269, 304)
        Me.Panel1.TabIndex = 51
        '
        'grpFiltro
        '
        Me.grpFiltro.BackColor = System.Drawing.Color.AliceBlue
        Me.grpFiltro.Controls.Add(Me.Panel2)
        Me.grpFiltro.Controls.Add(Me.tbcPanelFiltro)
        Me.grpFiltro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpFiltro.Location = New System.Drawing.Point(0, 0)
        Me.grpFiltro.Name = "grpFiltro"
        Me.grpFiltro.Padding = New System.Windows.Forms.Padding(0)
        Me.grpFiltro.Size = New System.Drawing.Size(269, 304)
        Me.grpFiltro.TabIndex = 0
        Me.grpFiltro.TabStop = False
        Me.grpFiltro.Text = "Buscar por:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.grpPedidos)
        Me.Panel2.Controls.Add(Me.cmbTipoReporte)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 135)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(269, 169)
        Me.Panel2.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Tipo Reporte:"
        '
        'grpPedidos
        '
        Me.grpPedidos.Controls.Add(Me.rdbEntregados)
        Me.grpPedidos.Controls.Add(Me.rdbPendientesEntregar)
        Me.grpPedidos.Controls.Add(Me.rdbPedientesFacturar)
        Me.grpPedidos.Controls.Add(Me.rdbTodos)
        Me.grpPedidos.Location = New System.Drawing.Point(23, 39)
        Me.grpPedidos.Name = "grpPedidos"
        Me.grpPedidos.Size = New System.Drawing.Size(214, 121)
        Me.grpPedidos.TabIndex = 14
        Me.grpPedidos.TabStop = False
        Me.grpPedidos.Text = "Pedidos"
        '
        'rdbEntregados
        '
        Me.rdbEntregados.AutoSize = True
        Me.rdbEntregados.Location = New System.Drawing.Point(37, 91)
        Me.rdbEntregados.Name = "rdbEntregados"
        Me.rdbEntregados.Size = New System.Drawing.Size(79, 17)
        Me.rdbEntregados.TabIndex = 3
        Me.rdbEntregados.TabStop = True
        Me.rdbEntregados.Text = "Entregados"
        Me.rdbEntregados.UseVisualStyleBackColor = True
        '
        'rdbPendientesEntregar
        '
        Me.rdbPendientesEntregar.AutoSize = True
        Me.rdbPendientesEntregar.Location = New System.Drawing.Point(37, 67)
        Me.rdbPendientesEntregar.Name = "rdbPendientesEntregar"
        Me.rdbPendientesEntregar.Size = New System.Drawing.Size(136, 17)
        Me.rdbPendientesEntregar.TabIndex = 2
        Me.rdbPendientesEntregar.TabStop = True
        Me.rdbPendientesEntregar.Text = "Pendientes de Entregar"
        Me.rdbPendientesEntregar.UseVisualStyleBackColor = True
        '
        'rdbPedientesFacturar
        '
        Me.rdbPedientesFacturar.AutoSize = True
        Me.rdbPedientesFacturar.Location = New System.Drawing.Point(37, 43)
        Me.rdbPedientesFacturar.Name = "rdbPedientesFacturar"
        Me.rdbPedientesFacturar.Size = New System.Drawing.Size(135, 17)
        Me.rdbPedientesFacturar.TabIndex = 1
        Me.rdbPedientesFacturar.TabStop = True
        Me.rdbPedientesFacturar.Text = "Pendientes de Facturar"
        Me.rdbPedientesFacturar.UseVisualStyleBackColor = True
        '
        'rdbTodos
        '
        Me.rdbTodos.AutoSize = True
        Me.rdbTodos.Location = New System.Drawing.Point(37, 19)
        Me.rdbTodos.Name = "rdbTodos"
        Me.rdbTodos.Size = New System.Drawing.Size(55, 17)
        Me.rdbTodos.TabIndex = 0
        Me.rdbTodos.TabStop = True
        Me.rdbTodos.Text = "Todos"
        Me.rdbTodos.UseVisualStyleBackColor = True
        '
        'cmbTipoReporte
        '
        Me.cmbTipoReporte.FormattingEnabled = True
        Me.cmbTipoReporte.Location = New System.Drawing.Point(119, 10)
        Me.cmbTipoReporte.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.cmbTipoReporte.Name = "cmbTipoReporte"
        Me.cmbTipoReporte.Size = New System.Drawing.Size(118, 21)
        Me.cmbTipoReporte.TabIndex = 13
        '
        'tbcPanelFiltro
        '
        Me.tbcPanelFiltro.Controls.Add(Me.tbpSemana)
        Me.tbcPanelFiltro.Controls.Add(Me.tbpFecha)
        Me.tbcPanelFiltro.Dock = System.Windows.Forms.DockStyle.Top
        Me.tbcPanelFiltro.Location = New System.Drawing.Point(0, 13)
        Me.tbcPanelFiltro.Margin = New System.Windows.Forms.Padding(0)
        Me.tbcPanelFiltro.Name = "tbcPanelFiltro"
        Me.tbcPanelFiltro.SelectedIndex = 0
        Me.tbcPanelFiltro.Size = New System.Drawing.Size(269, 122)
        Me.tbcPanelFiltro.TabIndex = 0
        '
        'tbpSemana
        '
        Me.tbpSemana.Controls.Add(Me.txtSemanaFin)
        Me.tbpSemana.Controls.Add(Me.txtSemanaInicio)
        Me.tbpSemana.Controls.Add(Me.txtAnio)
        Me.tbpSemana.Controls.Add(Me.Label3)
        Me.tbpSemana.Controls.Add(Me.Label2)
        Me.tbpSemana.Controls.Add(Me.Label1)
        Me.tbpSemana.Location = New System.Drawing.Point(4, 22)
        Me.tbpSemana.Name = "tbpSemana"
        Me.tbpSemana.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpSemana.Size = New System.Drawing.Size(261, 96)
        Me.tbpSemana.TabIndex = 1
        Me.tbpSemana.Text = "Semana"
        Me.tbpSemana.UseVisualStyleBackColor = True
        '
        'txtSemanaFin
        '
        Me.txtSemanaFin.Location = New System.Drawing.Point(115, 68)
        Me.txtSemanaFin.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.txtSemanaFin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtSemanaFin.Name = "txtSemanaFin"
        Me.txtSemanaFin.Size = New System.Drawing.Size(100, 20)
        Me.txtSemanaFin.TabIndex = 9
        Me.txtSemanaFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSemanaFin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtSemanaInicio
        '
        Me.txtSemanaInicio.Location = New System.Drawing.Point(115, 42)
        Me.txtSemanaInicio.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.txtSemanaInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtSemanaInicio.Name = "txtSemanaInicio"
        Me.txtSemanaInicio.Size = New System.Drawing.Size(100, 20)
        Me.txtSemanaInicio.TabIndex = 8
        Me.txtSemanaInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSemanaInicio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtAnio
        '
        Me.txtAnio.Location = New System.Drawing.Point(115, 16)
        Me.txtAnio.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtAnio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.Size = New System.Drawing.Size(100, 20)
        Me.txtAnio.TabIndex = 7
        Me.txtAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAnio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Semana Fin:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Semana Inicio:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(64, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Año:"
        '
        'tbpFecha
        '
        Me.tbpFecha.Controls.Add(Me.dtpFechaFin)
        Me.tbpFecha.Controls.Add(Me.lblAl)
        Me.tbpFecha.Controls.Add(Me.dtpFechaInicio)
        Me.tbpFecha.Controls.Add(Me.lblDel)
        Me.tbpFecha.Location = New System.Drawing.Point(4, 22)
        Me.tbpFecha.Name = "tbpFecha"
        Me.tbpFecha.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.tbpFecha.Size = New System.Drawing.Size(261, 96)
        Me.tbpFecha.TabIndex = 0
        Me.tbpFecha.Text = "Fecha"
        Me.tbpFecha.UseVisualStyleBackColor = True
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(115, 56)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(104, 20)
        Me.dtpFechaFin.TabIndex = 7
        Me.dtpFechaFin.Value = New Date(2020, 1, 20, 9, 55, 14, 0)
        '
        'lblAl
        '
        Me.lblAl.AutoSize = True
        Me.lblAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblAl.Location = New System.Drawing.Point(61, 56)
        Me.lblAl.Name = "lblAl"
        Me.lblAl.Size = New System.Drawing.Size(19, 13)
        Me.lblAl.TabIndex = 6
        Me.lblAl.Text = "Al:"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(115, 16)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(104, 20)
        Me.dtpFechaInicio.TabIndex = 5
        Me.dtpFechaInicio.Value = New Date(2020, 1, 20, 0, 0, 0, 0)
        '
        'lblDel
        '
        Me.lblDel.AutoSize = True
        Me.lblDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDel.Location = New System.Drawing.Point(61, 20)
        Me.lblDel.Name = "lblDel"
        Me.lblDel.Size = New System.Drawing.Size(26, 13)
        Me.lblDel.TabIndex = 4
        Me.lblDel.Text = "Del:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(201, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 65)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 91
        Me.PictureBox1.TabStop = False
        '
        'PanelFiltroReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(269, 432)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PanelFiltroReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planeación de Entregas"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.grpFiltro.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.grpPedidos.ResumeLayout(False)
        Me.grpPedidos.PerformLayout()
        Me.tbcPanelFiltro.ResumeLayout(False)
        Me.tbpSemana.ResumeLayout(False)
        Me.tbpSemana.PerformLayout()
        CType(Me.txtSemanaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSemanaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAnio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpFecha.ResumeLayout(False)
        Me.tbpFecha.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents lblCerrar As Label
    Friend WithEvents lblImprimir As Label
    Friend WithEvents btnImprimir As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grpFiltro As GroupBox
    Friend WithEvents tbcPanelFiltro As TabControl
    Friend WithEvents tbpFecha As TabPage
    Friend WithEvents tbpSemana As TabPage
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents lblAl As Label
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents lblDel As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSemanaFin As NumericUpDown
    Friend WithEvents txtSemanaInicio As NumericUpDown
    Friend WithEvents txtAnio As NumericUpDown
    Friend WithEvents grpPedidos As GroupBox
    Friend WithEvents rdbEntregados As RadioButton
    Friend WithEvents rdbPendientesEntregar As RadioButton
    Friend WithEvents rdbPedientesFacturar As RadioButton
    Friend WithEvents rdbTodos As RadioButton
    Friend WithEvents cmbTipoReporte As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
End Class
