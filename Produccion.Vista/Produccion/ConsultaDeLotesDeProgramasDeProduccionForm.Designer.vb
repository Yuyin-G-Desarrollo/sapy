<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaDeLotesDeProgramasDeProduccionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaDeLotesDeProgramasDeProduccionForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblParesText = New System.Windows.Forms.Label()
        Me.lblLotes = New System.Windows.Forms.Label()
        Me.lblLotesText = New System.Windows.Forms.Label()
        Me.lblPares = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pblAlta = New System.Windows.Forms.Panel()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.lblOrdenProduccion = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblTarjetaProduccion = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblExportarExcel = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpProgramaal = New System.Windows.Forms.DateTimePicker()
        Me.lblProgramaAl = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.dtpProgramadel = New System.Windows.Forms.DateTimePicker()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblPrograma = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdLotesProduccion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ultExportGrid = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.lblFechaal = New System.Windows.Forms.Label()
        Me.lblFechadel = New System.Windows.Forms.Label()
        Me.pnlInferior.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pblAlta.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.grdLotesProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbParametros.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Controls.Add(Me.lblParesText)
        Me.pnlInferior.Controls.Add(Me.lblLotes)
        Me.pnlInferior.Controls.Add(Me.lblLotesText)
        Me.pnlInferior.Controls.Add(Me.lblPares)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 539)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(1118, 56)
        Me.pnlInferior.TabIndex = 158
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(1065, 41)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 98
        Me.lblSalir.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(1065, 6)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 13
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblParesText
        '
        Me.lblParesText.AutoSize = True
        Me.lblParesText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesText.Location = New System.Drawing.Point(228, 23)
        Me.lblParesText.Name = "lblParesText"
        Me.lblParesText.Size = New System.Drawing.Size(16, 16)
        Me.lblParesText.TabIndex = 196
        Me.lblParesText.Text = "0"
        Me.lblParesText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLotes
        '
        Me.lblLotes.AutoSize = True
        Me.lblLotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotes.Location = New System.Drawing.Point(44, 23)
        Me.lblLotes.Name = "lblLotes"
        Me.lblLotes.Size = New System.Drawing.Size(50, 16)
        Me.lblLotes.TabIndex = 2
        Me.lblLotes.Text = "Lotes:"
        '
        'lblLotesText
        '
        Me.lblLotesText.AutoSize = True
        Me.lblLotesText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotesText.Location = New System.Drawing.Point(91, 23)
        Me.lblLotesText.Name = "lblLotesText"
        Me.lblLotesText.Size = New System.Drawing.Size(16, 16)
        Me.lblLotesText.TabIndex = 195
        Me.lblLotesText.Text = "0"
        '
        'lblPares
        '
        Me.lblPares.AutoSize = True
        Me.lblPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPares.Location = New System.Drawing.Point(178, 23)
        Me.lblPares.Name = "lblPares"
        Me.lblPares.Size = New System.Drawing.Size(53, 16)
        Me.lblPares.TabIndex = 3
        Me.lblPares.Text = "Pares:"
        Me.lblPares.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.FlowLayoutPanel1)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1118, 63)
        Me.pnlEncabezado.TabIndex = 157
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.pblAlta)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel4)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel3)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(6, 1)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(234, 60)
        Me.FlowLayoutPanel1.TabIndex = 2020
        '
        'pblAlta
        '
        Me.pblAlta.Controls.Add(Me.btnAlta)
        Me.pblAlta.Controls.Add(Me.lblOrdenProduccion)
        Me.pblAlta.Location = New System.Drawing.Point(3, 3)
        Me.pblAlta.Name = "pblAlta"
        Me.pblAlta.Size = New System.Drawing.Size(60, 54)
        Me.pblAlta.TabIndex = 191
        Me.pblAlta.Visible = False
        '
        'btnAlta
        '
        Me.btnAlta.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.imprimir_321
        Me.btnAlta.Location = New System.Drawing.Point(14, 0)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(32, 32)
        Me.btnAlta.TabIndex = 1
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'lblOrdenProduccion
        '
        Me.lblOrdenProduccion.AutoSize = True
        Me.lblOrdenProduccion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblOrdenProduccion.Location = New System.Drawing.Point(1, 30)
        Me.lblOrdenProduccion.Name = "lblOrdenProduccion"
        Me.lblOrdenProduccion.Size = New System.Drawing.Size(61, 26)
        Me.lblOrdenProduccion.TabIndex = 189
        Me.lblOrdenProduccion.Text = "Orden de" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Producción"
        Me.lblOrdenProduccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Button2)
        Me.Panel4.Controls.Add(Me.lblTarjetaProduccion)
        Me.Panel4.Location = New System.Drawing.Point(69, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(60, 54)
        Me.Panel4.TabIndex = 192
        Me.Panel4.Visible = False
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.imprimir_321
        Me.Button2.Location = New System.Drawing.Point(14, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 1
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblTarjetaProduccion
        '
        Me.lblTarjetaProduccion.AutoSize = True
        Me.lblTarjetaProduccion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTarjetaProduccion.Location = New System.Drawing.Point(1, 30)
        Me.lblTarjetaProduccion.Name = "lblTarjetaProduccion"
        Me.lblTarjetaProduccion.Size = New System.Drawing.Size(61, 26)
        Me.lblTarjetaProduccion.TabIndex = 189
        Me.lblTarjetaProduccion.Text = "Tarjeta de" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Producción"
        Me.lblTarjetaProduccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.lblExportarExcel)
        Me.Panel3.Location = New System.Drawing.Point(135, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(60, 54)
        Me.Panel3.TabIndex = 196
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.Button1.Location = New System.Drawing.Point(14, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblExportarExcel
        '
        Me.lblExportarExcel.AutoSize = True
        Me.lblExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarExcel.Location = New System.Drawing.Point(7, 30)
        Me.lblExportarExcel.Name = "lblExportarExcel"
        Me.lblExportarExcel.Size = New System.Drawing.Size(46, 13)
        Me.lblExportarExcel.TabIndex = 189
        Me.lblExportarExcel.Text = "Exportar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblExportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(835, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(214, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Programas de Producción"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(1050, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Image = Global.Produccion.Vista.My.Resources.Resources.limpiar_32
        Me.Button3.Location = New System.Drawing.Point(1079, 10)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(32, 32)
        Me.Button3.TabIndex = 200
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(1076, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 201
        Me.Label1.Text = "Limpiar"
        '
        'dtpProgramaal
        '
        Me.dtpProgramaal.Location = New System.Drawing.Point(637, 25)
        Me.dtpProgramaal.Name = "dtpProgramaal"
        Me.dtpProgramaal.Size = New System.Drawing.Size(200, 20)
        Me.dtpProgramaal.TabIndex = 198
        '
        'lblProgramaAl
        '
        Me.lblProgramaAl.AutoSize = True
        Me.lblProgramaAl.Location = New System.Drawing.Point(571, 29)
        Me.lblProgramaAl.Name = "lblProgramaAl"
        Me.lblProgramaAl.Size = New System.Drawing.Size(63, 13)
        Me.lblProgramaAl.TabIndex = 197
        Me.lblProgramaAl.Text = "Programa al"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(1038, 10)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 192
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(1035, 43)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 193
        Me.lblMostrar.Text = "Mostrar"
        '
        'dtpProgramadel
        '
        Me.dtpProgramadel.Location = New System.Drawing.Point(347, 25)
        Me.dtpProgramadel.Name = "dtpProgramadel"
        Me.dtpProgramadel.Size = New System.Drawing.Size(200, 20)
        Me.dtpProgramadel.TabIndex = 5
        '
        'cmbNave
        '
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(55, 24)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(202, 21)
        Me.cmbNave.TabIndex = 4
        '
        'lblPrograma
        '
        Me.lblPrograma.AutoSize = True
        Me.lblPrograma.Location = New System.Drawing.Point(276, 29)
        Me.lblPrograma.Name = "lblPrograma"
        Me.lblPrograma.Size = New System.Drawing.Size(69, 13)
        Me.lblPrograma.TabIndex = 1
        Me.lblPrograma.Text = "Programa del"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(18, 28)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(37, 13)
        Me.lblNave.TabIndex = 0
        Me.lblNave.Text = "*Nave"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.grdLotesProduccion)
        Me.Panel2.Location = New System.Drawing.Point(0, 128)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1118, 411)
        Me.Panel2.TabIndex = 160
        '
        'grdLotesProduccion
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdLotesProduccion.DisplayLayout.Appearance = Appearance1
        Me.grdLotesProduccion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdLotesProduccion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdLotesProduccion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdLotesProduccion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdLotesProduccion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdLotesProduccion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdLotesProduccion.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdLotesProduccion.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdLotesProduccion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdLotesProduccion.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdLotesProduccion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdLotesProduccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdLotesProduccion.Location = New System.Drawing.Point(0, 0)
        Me.grdLotesProduccion.Name = "grdLotesProduccion"
        Me.grdLotesProduccion.Size = New System.Drawing.Size(1118, 411)
        Me.grdLotesProduccion.TabIndex = 2003
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Controls.Add(Me.lblFechaal)
        Me.grbParametros.Controls.Add(Me.Button3)
        Me.grbParametros.Controls.Add(Me.lblFechadel)
        Me.grbParametros.Controls.Add(Me.lblNave)
        Me.grbParametros.Controls.Add(Me.Label1)
        Me.grbParametros.Controls.Add(Me.lblPrograma)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Controls.Add(Me.dtpProgramaal)
        Me.grbParametros.Controls.Add(Me.dtpProgramadel)
        Me.grbParametros.Controls.Add(Me.lblProgramaAl)
        Me.grbParametros.Controls.Add(Me.lblMostrar)
        Me.grbParametros.Controls.Add(Me.btnMostrar)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 63)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1118, 61)
        Me.grbParametros.TabIndex = 2007
        Me.grbParametros.TabStop = False
        '
        'lblFechaal
        '
        Me.lblFechaal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblFechaal.AutoSize = True
        Me.lblFechaal.Location = New System.Drawing.Point(643, 47)
        Me.lblFechaal.Name = "lblFechaal"
        Me.lblFechaal.Size = New System.Drawing.Size(10, 13)
        Me.lblFechaal.TabIndex = 199
        Me.lblFechaal.Text = " "
        Me.lblFechaal.Visible = False
        '
        'lblFechadel
        '
        Me.lblFechadel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblFechadel.AutoSize = True
        Me.lblFechadel.Location = New System.Drawing.Point(308, 47)
        Me.lblFechadel.Name = "lblFechadel"
        Me.lblFechadel.Size = New System.Drawing.Size(10, 13)
        Me.lblFechadel.TabIndex = 194
        Me.lblFechadel.Text = " "
        Me.lblFechadel.Visible = False
        '
        'ConsultaDeLotesDeProgramasDeProduccionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1118, 595)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "ConsultaDeLotesDeProgramasDeProduccionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Programas de Producción"
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.pblAlta.ResumeLayout(False)
        Me.pblAlta.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdLotesProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dtpProgramadel As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblPares As System.Windows.Forms.Label
    Friend WithEvents lblLotes As System.Windows.Forms.Label
    Friend WithEvents lblPrograma As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents grdLotesProduccion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents lblParesText As System.Windows.Forms.Label
    Friend WithEvents lblLotesText As System.Windows.Forms.Label
    Friend WithEvents pblAlta As System.Windows.Forms.Panel
    Friend WithEvents btnAlta As System.Windows.Forms.Button
    Friend WithEvents lblOrdenProduccion As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lblTarjetaProduccion As System.Windows.Forms.Label
    Friend WithEvents dtpProgramaal As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblProgramaAl As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblExportarExcel As System.Windows.Forms.Label
    Friend WithEvents ultExportGrid As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents lblFechaal As System.Windows.Forms.Label
    Friend WithEvents lblFechadel As System.Windows.Forms.Label
End Class
