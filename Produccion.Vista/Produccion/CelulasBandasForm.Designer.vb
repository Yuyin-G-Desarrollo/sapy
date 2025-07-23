<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CelulasBandasForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CelulasBandasForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblNoPares = New System.Windows.Forms.Label()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.lblNoLote = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbban = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbCel = New System.Windows.Forms.ComboBox()
        Me.chkval = New System.Windows.Forms.CheckBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lbl4Ppares = New System.Windows.Forms.Label()
        Me.lbl3Ppares = New System.Windows.Forms.Label()
        Me.lbl2Ppares = New System.Windows.Forms.Label()
        Me.lbl4Cpares = New System.Windows.Forms.Label()
        Me.lbl3Cpares = New System.Windows.Forms.Label()
        Me.lbl2Cpares = New System.Windows.Forms.Label()
        Me.lbl1Ppares = New System.Windows.Forms.Label()
        Me.lbl1Cpares = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblNoBanda2 = New System.Windows.Forms.Label()
        Me.lblNoBanda1 = New System.Windows.Forms.Label()
        Me.lblNoCelula3 = New System.Windows.Forms.Label()
        Me.lblNoCelula2 = New System.Windows.Forms.Label()
        Me.lblNoCelula1 = New System.Windows.Forms.Label()
        Me.lblNomban2 = New System.Windows.Forms.Label()
        Me.lblNomban1 = New System.Windows.Forms.Label()
        Me.lblNomcel3 = New System.Windows.Forms.Label()
        Me.lblNomcel2 = New System.Windows.Forms.Label()
        Me.lblNomcel1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnFiltrarSolicitud = New System.Windows.Forms.Button()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape6 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape5 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.grdLotes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ultExportGrid = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInferior.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        CType(Me.grdLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.Label4)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.Button2)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1130, 63)
        Me.pnlEncabezado.TabIndex = 158
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(4, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 102
        Me.Label4.Text = "Exportar" & Global.Microsoft.VisualBasic.ChrW(13)
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(791, 24)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(265, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Asignación de Células y Bandas"
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.Button2.Location = New System.Drawing.Point(9, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 101
        Me.Button2.UseVisualStyleBackColor = True
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(1062, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblGuardar)
        Me.pnlInferior.Controls.Add(Me.btnGuardar)
        Me.pnlInferior.Controls.Add(Me.lblNoPares)
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.lblNoLote)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Controls.Add(Me.Label27)
        Me.pnlInferior.Controls.Add(Me.Label26)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 315)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(1130, 54)
        Me.pnlInferior.TabIndex = 159
        '
        'lblGuardar
        '
        Me.lblGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(1039, 39)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 100
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Location = New System.Drawing.Point(1044, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 99
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblNoPares
        '
        Me.lblNoPares.AutoSize = True
        Me.lblNoPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoPares.Location = New System.Drawing.Point(185, 14)
        Me.lblNoPares.Name = "lblNoPares"
        Me.lblNoPares.Size = New System.Drawing.Size(14, 13)
        Me.lblNoPares.TabIndex = 117
        Me.lblNoPares.Text = "0"
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(1085, 39)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 98
        Me.lblSalir.Text = "Cerrar"
        '
        'lblNoLote
        '
        Me.lblNoLote.AutoSize = True
        Me.lblNoLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoLote.Location = New System.Drawing.Point(47, 14)
        Me.lblNoLote.Name = "lblNoLote"
        Me.lblNoLote.Size = New System.Drawing.Size(14, 13)
        Me.lblNoLote.TabIndex = 116
        Me.lblNoLote.Text = "0"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(1086, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 15
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(142, 14)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(37, 13)
        Me.Label27.TabIndex = 115
        Me.Label27.Text = "Pares:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(5, 14)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(36, 13)
        Me.Label26.TabIndex = 114
        Me.Label26.Text = "Lotes:"
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Controls.Add(Me.Label8)
        Me.grbParametros.Controls.Add(Me.Button3)
        Me.grbParametros.Controls.Add(Me.Label7)
        Me.grbParametros.Controls.Add(Me.Label6)
        Me.grbParametros.Controls.Add(Me.cmbban)
        Me.grbParametros.Controls.Add(Me.Label5)
        Me.grbParametros.Controls.Add(Me.cmbCel)
        Me.grbParametros.Controls.Add(Me.chkval)
        Me.grbParametros.Controls.Add(Me.Label31)
        Me.grbParametros.Controls.Add(Me.Label30)
        Me.grbParametros.Controls.Add(Me.lbl4Ppares)
        Me.grbParametros.Controls.Add(Me.lbl3Ppares)
        Me.grbParametros.Controls.Add(Me.lbl2Ppares)
        Me.grbParametros.Controls.Add(Me.lbl4Cpares)
        Me.grbParametros.Controls.Add(Me.lbl3Cpares)
        Me.grbParametros.Controls.Add(Me.lbl2Cpares)
        Me.grbParametros.Controls.Add(Me.lbl1Ppares)
        Me.grbParametros.Controls.Add(Me.lbl1Cpares)
        Me.grbParametros.Controls.Add(Me.Label17)
        Me.grbParametros.Controls.Add(Me.Label16)
        Me.grbParametros.Controls.Add(Me.Label15)
        Me.grbParametros.Controls.Add(Me.Label14)
        Me.grbParametros.Controls.Add(Me.lblNoBanda2)
        Me.grbParametros.Controls.Add(Me.lblNoBanda1)
        Me.grbParametros.Controls.Add(Me.lblNoCelula3)
        Me.grbParametros.Controls.Add(Me.lblNoCelula2)
        Me.grbParametros.Controls.Add(Me.lblNoCelula1)
        Me.grbParametros.Controls.Add(Me.lblNomban2)
        Me.grbParametros.Controls.Add(Me.lblNomban1)
        Me.grbParametros.Controls.Add(Me.lblNomcel3)
        Me.grbParametros.Controls.Add(Me.lblNomcel2)
        Me.grbParametros.Controls.Add(Me.lblNomcel1)
        Me.grbParametros.Controls.Add(Me.Label3)
        Me.grbParametros.Controls.Add(Me.Label2)
        Me.grbParametros.Controls.Add(Me.Label1)
        Me.grbParametros.Controls.Add(Me.btnAbajo)
        Me.grbParametros.Controls.Add(Me.btnArriba)
        Me.grbParametros.Controls.Add(Me.dtpFechaInicio)
        Me.grbParametros.Controls.Add(Me.lblBuscar)
        Me.grbParametros.Controls.Add(Me.btnFiltrarSolicitud)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Controls.Add(Me.lblNave)
        Me.grbParametros.Controls.Add(Me.ShapeContainer1)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 63)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1130, 150)
        Me.grbParametros.TabIndex = 162
        Me.grbParametros.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(505, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 204
        Me.Label8.Text = "Avance"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Image = Global.Produccion.Vista.My.Resources.Resources.limpiar_32
        Me.Button3.Location = New System.Drawing.Point(1091, 46)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(32, 32)
        Me.Button3.TabIndex = 202
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.Location = New System.Drawing.Point(1089, 81)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 203
        Me.Label7.Text = "Limpiar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(392, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 124
        Me.Label6.Text = "Bandas"
        '
        'cmbban
        '
        Me.cmbban.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbban.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbban.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbban.FormattingEnabled = True
        Me.cmbban.Location = New System.Drawing.Point(435, 122)
        Me.cmbban.Name = "cmbban"
        Me.cmbban.Size = New System.Drawing.Size(183, 21)
        Me.cmbban.TabIndex = 123
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(142, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 122
        Me.Label5.Text = "Células"
        '
        'cmbCel
        '
        Me.cmbCel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCel.FormattingEnabled = True
        Me.cmbCel.Location = New System.Drawing.Point(188, 122)
        Me.cmbCel.Name = "cmbCel"
        Me.cmbCel.Size = New System.Drawing.Size(183, 21)
        Me.cmbCel.TabIndex = 121
        '
        'chkval
        '
        Me.chkval.AutoSize = True
        Me.chkval.Location = New System.Drawing.Point(9, 121)
        Me.chkval.Name = "chkval"
        Me.chkval.Size = New System.Drawing.Size(106, 17)
        Me.chkval.TabIndex = 120
        Me.chkval.Text = "Seleccionar todo"
        Me.chkval.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(447, 15)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(55, 13)
        Me.Label31.TabIndex = 119
        Me.Label31.Text = "Programa "
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(12, 36)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(159, 13)
        Me.Label30.TabIndex = 118
        Me.Label30.Text = "Asignación de células y bandas:"
        '
        'lbl4Ppares
        '
        Me.lbl4Ppares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4Ppares.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbl4Ppares.Location = New System.Drawing.Point(911, 94)
        Me.lbl4Ppares.Name = "lbl4Ppares"
        Me.lbl4Ppares.Size = New System.Drawing.Size(68, 14)
        Me.lbl4Ppares.TabIndex = 113
        Me.lbl4Ppares.Text = "0"
        Me.lbl4Ppares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl3Ppares
        '
        Me.lbl3Ppares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3Ppares.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbl3Ppares.Location = New System.Drawing.Point(761, 96)
        Me.lbl3Ppares.Name = "lbl3Ppares"
        Me.lbl3Ppares.Size = New System.Drawing.Size(122, 13)
        Me.lbl3Ppares.TabIndex = 112
        Me.lbl3Ppares.Text = "0"
        Me.lbl3Ppares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl2Ppares
        '
        Me.lbl2Ppares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2Ppares.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbl2Ppares.Location = New System.Drawing.Point(659, 94)
        Me.lbl2Ppares.Name = "lbl2Ppares"
        Me.lbl2Ppares.Size = New System.Drawing.Size(64, 14)
        Me.lbl2Ppares.TabIndex = 111
        Me.lbl2Ppares.Text = "0"
        Me.lbl2Ppares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl4Cpares
        '
        Me.lbl4Cpares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4Cpares.ForeColor = System.Drawing.Color.Black
        Me.lbl4Cpares.Location = New System.Drawing.Point(911, 72)
        Me.lbl4Cpares.Name = "lbl4Cpares"
        Me.lbl4Cpares.Size = New System.Drawing.Size(68, 13)
        Me.lbl4Cpares.TabIndex = 110
        Me.lbl4Cpares.Text = "0"
        Me.lbl4Cpares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl3Cpares
        '
        Me.lbl3Cpares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3Cpares.ForeColor = System.Drawing.Color.Black
        Me.lbl3Cpares.Location = New System.Drawing.Point(761, 72)
        Me.lbl3Cpares.Name = "lbl3Cpares"
        Me.lbl3Cpares.Size = New System.Drawing.Size(122, 13)
        Me.lbl3Cpares.TabIndex = 109
        Me.lbl3Cpares.Text = "0"
        Me.lbl3Cpares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl2Cpares
        '
        Me.lbl2Cpares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2Cpares.ForeColor = System.Drawing.Color.Black
        Me.lbl2Cpares.Location = New System.Drawing.Point(659, 72)
        Me.lbl2Cpares.Name = "lbl2Cpares"
        Me.lbl2Cpares.Size = New System.Drawing.Size(64, 13)
        Me.lbl2Cpares.TabIndex = 108
        Me.lbl2Cpares.Text = "0"
        Me.lbl2Cpares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl1Ppares
        '
        Me.lbl1Ppares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Ppares.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbl1Ppares.Location = New System.Drawing.Point(561, 94)
        Me.lbl1Ppares.Name = "lbl1Ppares"
        Me.lbl1Ppares.Size = New System.Drawing.Size(50, 14)
        Me.lbl1Ppares.TabIndex = 107
        Me.lbl1Ppares.Text = "0"
        Me.lbl1Ppares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl1Cpares
        '
        Me.lbl1Cpares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Cpares.ForeColor = System.Drawing.Color.Black
        Me.lbl1Cpares.Location = New System.Drawing.Point(561, 72)
        Me.lbl1Cpares.Name = "lbl1Cpares"
        Me.lbl1Cpares.Size = New System.Drawing.Size(50, 13)
        Me.lbl1Cpares.TabIndex = 106
        Me.lbl1Cpares.Text = "0"
        Me.lbl1Cpares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(911, 55)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 13)
        Me.Label17.TabIndex = 105
        Me.Label17.Text = "EMBARQUE"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(761, 55)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(122, 13)
        Me.Label16.TabIndex = 104
        Me.Label16.Text = "MONTADO Y ADORNO"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(659, 55)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 13)
        Me.Label15.TabIndex = 103
        Me.Label15.Text = "PESPUNTE"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(497, 93)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 13)
        Me.Label14.TabIndex = 102
        Me.Label14.Text = "Pendientes"
        '
        'lblNoBanda2
        '
        Me.lblNoBanda2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoBanda2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblNoBanda2.Location = New System.Drawing.Point(392, 94)
        Me.lblNoBanda2.Name = "lblNoBanda2"
        Me.lblNoBanda2.Size = New System.Drawing.Size(60, 15)
        Me.lblNoBanda2.TabIndex = 101
        Me.lblNoBanda2.Text = "0"
        Me.lblNoBanda2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNoBanda1
        '
        Me.lblNoBanda1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoBanda1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblNoBanda1.Location = New System.Drawing.Point(282, 94)
        Me.lblNoBanda1.Name = "lblNoBanda1"
        Me.lblNoBanda1.Size = New System.Drawing.Size(60, 15)
        Me.lblNoBanda1.TabIndex = 100
        Me.lblNoBanda1.Text = "0"
        Me.lblNoBanda1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNoCelula3
        '
        Me.lblNoCelula3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCelula3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblNoCelula3.Location = New System.Drawing.Point(194, 94)
        Me.lblNoCelula3.Name = "lblNoCelula3"
        Me.lblNoCelula3.Size = New System.Drawing.Size(65, 15)
        Me.lblNoCelula3.TabIndex = 99
        Me.lblNoCelula3.Text = "0"
        Me.lblNoCelula3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNoCelula2
        '
        Me.lblNoCelula2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCelula2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblNoCelula2.Location = New System.Drawing.Point(106, 94)
        Me.lblNoCelula2.Name = "lblNoCelula2"
        Me.lblNoCelula2.Size = New System.Drawing.Size(65, 15)
        Me.lblNoCelula2.TabIndex = 98
        Me.lblNoCelula2.Text = "0"
        Me.lblNoCelula2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNoCelula1
        '
        Me.lblNoCelula1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCelula1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblNoCelula1.Location = New System.Drawing.Point(15, 93)
        Me.lblNoCelula1.Name = "lblNoCelula1"
        Me.lblNoCelula1.Size = New System.Drawing.Size(62, 16)
        Me.lblNoCelula1.TabIndex = 97
        Me.lblNoCelula1.Text = "0"
        Me.lblNoCelula1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNomban2
        '
        Me.lblNomban2.AutoSize = True
        Me.lblNomban2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomban2.ForeColor = System.Drawing.Color.Black
        Me.lblNomban2.Location = New System.Drawing.Point(392, 72)
        Me.lblNomban2.Name = "lblNomban2"
        Me.lblNomban2.Size = New System.Drawing.Size(60, 13)
        Me.lblNomban2.TabIndex = 95
        Me.lblNomban2.Text = "BANDA 2"
        '
        'lblNomban1
        '
        Me.lblNomban1.AutoSize = True
        Me.lblNomban1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomban1.ForeColor = System.Drawing.Color.Black
        Me.lblNomban1.Location = New System.Drawing.Point(282, 72)
        Me.lblNomban1.Name = "lblNomban1"
        Me.lblNomban1.Size = New System.Drawing.Size(60, 13)
        Me.lblNomban1.TabIndex = 94
        Me.lblNomban1.Text = "BANDA 1"
        '
        'lblNomcel3
        '
        Me.lblNomcel3.AutoSize = True
        Me.lblNomcel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomcel3.ForeColor = System.Drawing.Color.Black
        Me.lblNomcel3.Location = New System.Drawing.Point(194, 72)
        Me.lblNomcel3.Name = "lblNomcel3"
        Me.lblNomcel3.Size = New System.Drawing.Size(65, 13)
        Me.lblNomcel3.TabIndex = 93
        Me.lblNomcel3.Text = "CÉLULA 3"
        '
        'lblNomcel2
        '
        Me.lblNomcel2.AutoSize = True
        Me.lblNomcel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomcel2.ForeColor = System.Drawing.Color.Black
        Me.lblNomcel2.Location = New System.Drawing.Point(106, 72)
        Me.lblNomcel2.Name = "lblNomcel2"
        Me.lblNomcel2.Size = New System.Drawing.Size(65, 13)
        Me.lblNomcel2.TabIndex = 92
        Me.lblNomcel2.Text = "CÉLULA 2"
        '
        'lblNomcel1
        '
        Me.lblNomcel1.AutoSize = True
        Me.lblNomcel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomcel1.ForeColor = System.Drawing.Color.Black
        Me.lblNomcel1.Location = New System.Drawing.Point(12, 72)
        Me.lblNomcel1.Name = "lblNomcel1"
        Me.lblNomcel1.Size = New System.Drawing.Size(65, 13)
        Me.lblNomcel1.TabIndex = 91
        Me.lblNomcel1.Text = "CÉLULA 1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(567, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "CORTE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(282, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 13)
        Me.Label2.TabIndex = 89
        Me.Label2.Text = "MONTADO Y ADORNO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 88
        Me.Label1.Text = "PESPUNTE"
        '
        'btnAbajo
        '
        Me.btnAbajo.AccessibleName = "0"
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(1106, 7)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 36
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.AccessibleName = "0"
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(1083, 7)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 35
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Location = New System.Drawing.Point(508, 13)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(215, 20)
        Me.dtpFechaInicio.TabIndex = 87
        '
        'lblBuscar
        '
        Me.lblBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(1049, 80)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 7
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnFiltrarSolicitud
        '
        Me.btnFiltrarSolicitud.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFiltrarSolicitud.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_32
        Me.btnFiltrarSolicitud.Location = New System.Drawing.Point(1052, 46)
        Me.btnFiltrarSolicitud.Name = "btnFiltrarSolicitud"
        Me.btnFiltrarSolicitud.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrarSolicitud.TabIndex = 5
        Me.btnFiltrarSolicitud.UseVisualStyleBackColor = True
        '
        'cmbNave
        '
        Me.cmbNave.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbNave.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(50, 12)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(348, 21)
        Me.cmbNave.TabIndex = 4
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(11, 15)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(37, 13)
        Me.lblNave.TabIndex = 69
        Me.lblNave.Text = "*Nave"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(3, 16)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape6, Me.LineShape5, Me.LineShape3, Me.LineShape4, Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1124, 131)
        Me.ShapeContainer1.TabIndex = 96
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape6
        '
        Me.LineShape6.BorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.LineShape6.Name = "LineShape6"
        Me.LineShape6.X1 = 483
        Me.LineShape6.X2 = 483
        Me.LineShape6.Y1 = 98
        Me.LineShape6.Y2 = 28
        '
        'LineShape5
        '
        Me.LineShape5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape5.BorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.LineShape5.Name = "LineShape5"
        Me.LineShape5.X1 = -5
        Me.LineShape5.X2 = 1130
        Me.LineShape5.Y1 = 98
        Me.LineShape5.Y2 = 98
        '
        'LineShape3
        '
        Me.LineShape3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape3.BorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 0
        Me.LineShape3.X2 = 1131
        Me.LineShape3.Y1 = 28
        Me.LineShape3.Y2 = 28
        '
        'LineShape4
        '
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 551
        Me.LineShape4.X2 = 996
        Me.LineShape4.Y1 = 73
        Me.LineShape4.Y2 = 73
        '
        'LineShape2
        '
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 271
        Me.LineShape2.X2 = 271
        Me.LineShape2.Y1 = 38
        Me.LineShape2.Y2 = 91
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 6
        Me.LineShape1.X2 = 470
        Me.LineShape1.Y1 = 73
        Me.LineShape1.Y2 = 73
        '
        'grdLotes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdLotes.DisplayLayout.Appearance = Appearance1
        Me.grdLotes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdLotes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdLotes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdLotes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdLotes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdLotes.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdLotes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdLotes.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdLotes.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdLotes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdLotes.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdLotes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdLotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdLotes.Location = New System.Drawing.Point(0, 213)
        Me.grdLotes.Name = "grdLotes"
        Me.grdLotes.Size = New System.Drawing.Size(1130, 102)
        Me.grdLotes.TabIndex = 163
        '
        'CelulasBandasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1130, 369)
        Me.Controls.Add(Me.grdLotes)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "CelulasBandasForm"
        Me.Text = "Asignación de Células y Bandas"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        CType(Me.grdLotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnFiltrarSolicitud As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents lblNoPares As System.Windows.Forms.Label
    Friend WithEvents lblNoLote As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents grdLotes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ultExportGrid As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbCel As System.Windows.Forms.ComboBox
    Friend WithEvents chkval As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbban As System.Windows.Forms.ComboBox
    Friend WithEvents lbl4Ppares As System.Windows.Forms.Label
    Friend WithEvents lbl3Ppares As System.Windows.Forms.Label
    Friend WithEvents lbl2Ppares As System.Windows.Forms.Label
    Friend WithEvents lbl4Cpares As System.Windows.Forms.Label
    Friend WithEvents lbl3Cpares As System.Windows.Forms.Label
    Friend WithEvents lbl2Cpares As System.Windows.Forms.Label
    Friend WithEvents lbl1Ppares As System.Windows.Forms.Label
    Friend WithEvents lbl1Cpares As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblNoBanda2 As System.Windows.Forms.Label
    Friend WithEvents lblNoBanda1 As System.Windows.Forms.Label
    Friend WithEvents lblNoCelula3 As System.Windows.Forms.Label
    Friend WithEvents lblNoCelula2 As System.Windows.Forms.Label
    Friend WithEvents lblNoCelula1 As System.Windows.Forms.Label
    Friend WithEvents lblNomban2 As System.Windows.Forms.Label
    Friend WithEvents lblNomban1 As System.Windows.Forms.Label
    Friend WithEvents lblNomcel3 As System.Windows.Forms.Label
    Friend WithEvents lblNomcel2 As System.Windows.Forms.Label
    Friend WithEvents lblNomcel1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Private WithEvents LineShape4 As PowerPacks.LineShape
    Private WithEvents LineShape2 As PowerPacks.LineShape
    Private WithEvents LineShape1 As PowerPacks.LineShape
    Private WithEvents LineShape5 As PowerPacks.LineShape
    Private WithEvents LineShape3 As PowerPacks.LineShape
    Private WithEvents LineShape6 As PowerPacks.LineShape
End Class
