<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaProspectaAlmacenForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaProspectaAlmacenForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlBtn = New System.Windows.Forms.Panel()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.btnComentarioRevision = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblFechaUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblTextoUltimaDistribucion = New System.Windows.Forms.Label()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlSalir = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdTotal = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nudAño = New System.Windows.Forms.NumericUpDown()
        Me.nudNumSemana = New System.Windows.Forms.NumericUpDown()
        Me.txtStatusProspecta = New System.Windows.Forms.TextBox()
        Me.dtmFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtmFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdConsulta = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitle.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBtn.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlSalir.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudNumSemana, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grdConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitle)
        Me.pnlHeader.Controls.Add(Me.pnlBtn)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1137, 59)
        Me.pnlHeader.TabIndex = 14
        '
        'pnlTitle
        '
        Me.pnlTitle.Controls.Add(Me.lblTitulo)
        Me.pnlTitle.Controls.Add(Me.imgLogo)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitle.Location = New System.Drawing.Point(690, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(447, 59)
        Me.pnlTitle.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(286, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(90, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Prospecta"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(377, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 59)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 0
        Me.imgLogo.TabStop = False
        '
        'pnlBtn
        '
        Me.pnlBtn.Controls.Add(Me.Label28)
        Me.pnlBtn.Controls.Add(Me.btnComentarioRevision)
        Me.pnlBtn.Controls.Add(Me.lblExportar)
        Me.pnlBtn.Controls.Add(Me.btnExportar)
        Me.pnlBtn.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtn.Location = New System.Drawing.Point(0, 0)
        Me.pnlBtn.Name = "pnlBtn"
        Me.pnlBtn.Size = New System.Drawing.Size(774, 59)
        Me.pnlBtn.TabIndex = 1
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label28.Location = New System.Drawing.Point(66, 36)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(63, 26)
        Me.Label28.TabIndex = 71
        Me.Label28.Text = "Comentario " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Revisión"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnComentarioRevision
        '
        Me.btnComentarioRevision.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources.editar_3211
        Me.btnComentarioRevision.Location = New System.Drawing.Point(77, 6)
        Me.btnComentarioRevision.Name = "btnComentarioRevision"
        Me.btnComentarioRevision.Size = New System.Drawing.Size(32, 32)
        Me.btnComentarioRevision.TabIndex = 70
        Me.btnComentarioRevision.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(10, 39)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 56
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(15, 6)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 55
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.lblFechaUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.lblTextoUltimaDistribucion)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.pnlSalir)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 443)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1137, 61)
        Me.pnlPie.TabIndex = 15
        '
        'lblFechaUltimaActualizacion
        '
        Me.lblFechaUltimaActualizacion.AutoSize = True
        Me.lblFechaUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaActualizacion.ForeColor = System.Drawing.Color.Black
        Me.lblFechaUltimaActualizacion.Location = New System.Drawing.Point(265, 29)
        Me.lblFechaUltimaActualizacion.Name = "lblFechaUltimaActualizacion"
        Me.lblFechaUltimaActualizacion.Size = New System.Drawing.Size(114, 13)
        Me.lblFechaUltimaActualizacion.TabIndex = 127
        Me.lblFechaUltimaActualizacion.Text = "24/05/2016 01:54 PM"
        Me.lblFechaUltimaActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTextoUltimaDistribucion
        '
        Me.lblTextoUltimaDistribucion.AutoSize = True
        Me.lblTextoUltimaDistribucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoUltimaDistribucion.ForeColor = System.Drawing.Color.Black
        Me.lblTextoUltimaDistribucion.Location = New System.Drawing.Point(153, 29)
        Me.lblTextoUltimaDistribucion.Name = "lblTextoUltimaDistribucion"
        Me.lblTextoUltimaDistribucion.Size = New System.Drawing.Size(105, 13)
        Me.lblTextoUltimaDistribucion.TabIndex = 128
        Me.lblTextoUltimaDistribucion.Text = "Última Actualización:"
        Me.lblTextoUltimaDistribucion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(7, 29)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 24)
        Me.lblNumFiltrados.TabIndex = 126
        Me.lblNumFiltrados.Text = "0"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(10, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 24)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "Registros"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlSalir
        '
        Me.pnlSalir.Controls.Add(Me.Label3)
        Me.pnlSalir.Controls.Add(Me.btnCerrar)
        Me.pnlSalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSalir.Location = New System.Drawing.Point(927, 0)
        Me.pnlSalir.Name = "pnlSalir"
        Me.pnlSalir.Size = New System.Drawing.Size(210, 61)
        Me.pnlSalir.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(161, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(163, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 52
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.Panel2)
        Me.pnlFiltros.Controls.Add(Me.GroupBox1)
        Me.pnlFiltros.Controls.Add(Me.btnArriba)
        Me.pnlFiltros.Controls.Add(Me.btnAbajo)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 59)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1137, 119)
        Me.pnlFiltros.TabIndex = 16
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdTotal)
        Me.Panel2.Location = New System.Drawing.Point(441, 30)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(684, 63)
        Me.Panel2.TabIndex = 18
        '
        'grdTotal
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTotal.DisplayLayout.Appearance = Appearance1
        Me.grdTotal.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdTotal.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTotal.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdTotal.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdTotal.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdTotal.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdTotal.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdTotal.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTotal.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdTotal.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdTotal.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTotal.Location = New System.Drawing.Point(0, 0)
        Me.grdTotal.Name = "grdTotal"
        Me.grdTotal.Size = New System.Drawing.Size(684, 63)
        Me.grdTotal.TabIndex = 88
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.nudAño)
        Me.GroupBox1.Controls.Add(Me.nudNumSemana)
        Me.GroupBox1.Controls.Add(Me.txtStatusProspecta)
        Me.GroupBox1.Controls.Add(Me.dtmFechaFin)
        Me.GroupBox1.Controls.Add(Me.dtmFechaInicio)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(429, 91)
        Me.GroupBox1.TabIndex = 105
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información de la Prospecta"
        '
        'nudAño
        '
        Me.nudAño.Location = New System.Drawing.Point(119, 29)
        Me.nudAño.Maximum = New Decimal(New Integer() {2099, 0, 0, 0})
        Me.nudAño.Minimum = New Decimal(New Integer() {2017, 0, 0, 0})
        Me.nudAño.Name = "nudAño"
        Me.nudAño.Size = New System.Drawing.Size(54, 20)
        Me.nudAño.TabIndex = 77
        Me.nudAño.Value = New Decimal(New Integer() {2017, 0, 0, 0})
        '
        'nudNumSemana
        '
        Me.nudNumSemana.Location = New System.Drawing.Point(58, 29)
        Me.nudNumSemana.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNumSemana.Name = "nudNumSemana"
        Me.nudNumSemana.Size = New System.Drawing.Size(45, 20)
        Me.nudNumSemana.TabIndex = 77
        Me.nudNumSemana.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtStatusProspecta
        '
        Me.txtStatusProspecta.Enabled = False
        Me.txtStatusProspecta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatusProspecta.ForeColor = System.Drawing.Color.Black
        Me.txtStatusProspecta.Location = New System.Drawing.Point(58, 55)
        Me.txtStatusProspecta.Name = "txtStatusProspecta"
        Me.txtStatusProspecta.Size = New System.Drawing.Size(96, 20)
        Me.txtStatusProspecta.TabIndex = 76
        Me.txtStatusProspecta.Text = "PRÓXIMA"
        '
        'dtmFechaFin
        '
        Me.dtmFechaFin.Enabled = False
        Me.dtmFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtmFechaFin.Location = New System.Drawing.Point(331, 28)
        Me.dtmFechaFin.Name = "dtmFechaFin"
        Me.dtmFechaFin.Size = New System.Drawing.Size(88, 20)
        Me.dtmFechaFin.TabIndex = 40
        Me.dtmFechaFin.Value = New Date(2016, 11, 19, 0, 0, 0, 0)
        '
        'dtmFechaInicio
        '
        Me.dtmFechaInicio.Enabled = False
        Me.dtmFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtmFechaInicio.Location = New System.Drawing.Point(217, 28)
        Me.dtmFechaInicio.Name = "dtmFechaInicio"
        Me.dtmFechaInicio.Size = New System.Drawing.Size(82, 20)
        Me.dtmFechaInicio.TabIndex = 39
        Me.dtmFechaInicio.Value = New Date(2016, 11, 14, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(187, 31)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 13)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Del"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "Semana"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(311, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 13)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Al"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(11, 58)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(37, 13)
        Me.Label27.TabIndex = 54
        Me.Label27.Text = "Status"
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Location = New System.Drawing.Point(1082, 1)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 93
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbajo.Location = New System.Drawing.Point(1108, 1)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 92
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdConsulta)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 178)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1137, 265)
        Me.Panel1.TabIndex = 17
        '
        'grdConsulta
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdConsulta.DisplayLayout.Appearance = Appearance3
        Me.grdConsulta.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdConsulta.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdConsulta.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdConsulta.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdConsulta.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdConsulta.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdConsulta.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdConsulta.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdConsulta.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdConsulta.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdConsulta.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdConsulta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdConsulta.Location = New System.Drawing.Point(0, 0)
        Me.grdConsulta.Name = "grdConsulta"
        Me.grdConsulta.Size = New System.Drawing.Size(1137, 265)
        Me.grdConsulta.TabIndex = 87
        '
        'ConsultaProspectaAlmacenForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1137, 504)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ConsultaProspectaAlmacenForm"
        Me.Text = "Prospecta"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBtn.ResumeLayout(False)
        Me.pnlBtn.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlSalir.ResumeLayout(False)
        Me.pnlSalir.PerformLayout()
        Me.pnlFiltros.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdTotal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudNumSemana, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlBtn As System.Windows.Forms.Panel
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents btnComentarioRevision As System.Windows.Forms.Button
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlSalir As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents nudAño As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudNumSemana As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtStatusProspecta As System.Windows.Forms.TextBox
    Friend WithEvents dtmFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtmFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdConsulta As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grdTotal As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblFechaUltimaActualizacion As System.Windows.Forms.Label
    Friend WithEvents lblTextoUltimaDistribucion As System.Windows.Forms.Label
    Friend WithEvents lblNumFiltrados As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
