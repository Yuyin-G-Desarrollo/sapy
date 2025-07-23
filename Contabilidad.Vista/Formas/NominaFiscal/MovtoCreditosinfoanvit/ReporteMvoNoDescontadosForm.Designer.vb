<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteMvoNoDescontadosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteMvoNoDescontadosForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlImprimir = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.chkPeriodo = New System.Windows.Forms.CheckBox()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.lblFechaFinal = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.grdListadoMovimientos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.fbdUbicacionArchivo = New System.Windows.Forms.FolderBrowserDialog()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlImprimir.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.grdListadoMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlExportar)
        Me.pnlEncabezado.Controls.Add(Me.pnlImprimir)
        Me.pnlEncabezado.Controls.Add(Me.Panel1)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(988, 69)
        Me.pnlEncabezado.TabIndex = 7
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Controls.Add(Me.lblExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(59, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(59, 69)
        Me.pnlExportar.TabIndex = 40
        '
        'btnExportar
        '
        Me.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportar.Image = Global.Contabilidad.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(13, 11)
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
        Me.lblExportar.Location = New System.Drawing.Point(7, 45)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 23
        Me.lblExportar.Text = "Exportar"
        '
        'pnlImprimir
        '
        Me.pnlImprimir.Controls.Add(Me.btnImprimir)
        Me.pnlImprimir.Controls.Add(Me.lblImprimir)
        Me.pnlImprimir.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImprimir.Location = New System.Drawing.Point(0, 0)
        Me.pnlImprimir.Name = "pnlImprimir"
        Me.pnlImprimir.Size = New System.Drawing.Size(59, 69)
        Me.pnlImprimir.TabIndex = 39
        '
        'btnImprimir
        '
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.Image = Global.Contabilidad.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(14, 11)
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
        Me.lblImprimir.Location = New System.Drawing.Point(10, 45)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 32
        Me.lblImprimir.Text = "Imprimir"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.imgLogo)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(513, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(475, 69)
        Me.Panel1.TabIndex = 20
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(60, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(341, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Reporte de Movimientos No Descontados"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.cmbEmpresa)
        Me.grbFiltros.Controls.Add(Me.lblEmpresa)
        Me.grbFiltros.Controls.Add(Me.GroupBox1)
        Me.grbFiltros.Controls.Add(Me.Panel6)
        Me.grbFiltros.Controls.Add(Me.txtNombre)
        Me.grbFiltros.Controls.Add(Me.lblNombre)
        Me.grbFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbFiltros.ForeColor = System.Drawing.Color.Black
        Me.grbFiltros.Location = New System.Drawing.Point(0, 69)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(988, 114)
        Me.grbFiltros.TabIndex = 8
        Me.grbFiltros.TabStop = False
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.ForeColor = System.Drawing.Color.Black
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(75, 47)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(380, 21)
        Me.cmbEmpresa.TabIndex = 46
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.lblEmpresa.Location = New System.Drawing.Point(21, 50)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(48, 13)
        Me.lblEmpresa.TabIndex = 45
        Me.lblEmpresa.Text = "Empresa"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox1.Controls.Add(Me.chkPeriodo)
        Me.GroupBox1.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox1.Controls.Add(Me.lblFechaInicio)
        Me.GroupBox1.Controls.Add(Me.lblFechaFinal)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(500, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(223, 67)
        Me.GroupBox1.TabIndex = 52
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periodo"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Enabled = False
        Me.dtpFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(111, 44)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaFin.TabIndex = 30
        '
        'chkPeriodo
        '
        Me.chkPeriodo.AutoSize = True
        Me.chkPeriodo.Location = New System.Drawing.Point(15, 21)
        Me.chkPeriodo.Name = "chkPeriodo"
        Me.chkPeriodo.Size = New System.Drawing.Size(15, 14)
        Me.chkPeriodo.TabIndex = 24
        Me.chkPeriodo.UseVisualStyleBackColor = True
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Enabled = False
        Me.dtpFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(111, 18)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaInicio.TabIndex = 29
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicio.ForeColor = System.Drawing.Color.Black
        Me.lblFechaInicio.Location = New System.Drawing.Point(36, 21)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(66, 13)
        Me.lblFechaInicio.TabIndex = 20
        Me.lblFechaInicio.Text = "Fecha inicial"
        '
        'lblFechaFinal
        '
        Me.lblFechaFinal.AutoSize = True
        Me.lblFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaFinal.ForeColor = System.Drawing.Color.Black
        Me.lblFechaFinal.Location = New System.Drawing.Point(43, 49)
        Me.lblFechaFinal.Name = "lblFechaFinal"
        Me.lblFechaFinal.Size = New System.Drawing.Size(59, 13)
        Me.lblFechaFinal.TabIndex = 21
        Me.lblFechaFinal.Text = "Fecha final"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lblMostrar)
        Me.Panel6.Controls.Add(Me.lblLimpiar)
        Me.Panel6.Controls.Add(Me.btnLimpiar)
        Me.Panel6.Controls.Add(Me.btnBuscar)
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(876, 16)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(109, 95)
        Me.Panel6.TabIndex = 51
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(12, 70)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 54
        Me.lblMostrar.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(64, 70)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 53
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(67, 38)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 52
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(15, 38)
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
        'txtNombre
        '
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(75, 79)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(261, 20)
        Me.txtNombre.TabIndex = 36
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.ForeColor = System.Drawing.Color.Black
        Me.lblNombre.Location = New System.Drawing.Point(25, 82)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 35
        Me.lblNombre.Text = "Nombre"
        '
        'grdListadoMovimientos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListadoMovimientos.DisplayLayout.Appearance = Appearance1
        Me.grdListadoMovimientos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListadoMovimientos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdListadoMovimientos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListadoMovimientos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListadoMovimientos.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdListadoMovimientos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListadoMovimientos.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdListadoMovimientos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListadoMovimientos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListadoMovimientos.Location = New System.Drawing.Point(0, 183)
        Me.grdListadoMovimientos.Name = "grdListadoMovimientos"
        Me.grdListadoMovimientos.Size = New System.Drawing.Size(988, 328)
        Me.grdListadoMovimientos.TabIndex = 29
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(403, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 69)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 47
        Me.imgLogo.TabStop = False
        '
        'ReporteMvoNoDescontadosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(988, 511)
        Me.Controls.Add(Me.grdListadoMovimientos)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "ReporteMvoNoDescontadosForm"
        Me.Text = "Reporte de Movimientos No Descontados"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlImprimir.ResumeLayout(False)
        Me.pnlImprimir.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.grdListadoMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlImprimir As System.Windows.Forms.Panel
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlExportar As System.Windows.Forms.Panel
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkPeriodo As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents lblFechaFinal As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents grdListadoMovimientos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents fbdUbicacionArchivo As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
