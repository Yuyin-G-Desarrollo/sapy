<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EtiquetasProveedoresForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EtiquetasProveedoresForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkRangoFechas = New System.Windows.Forms.CheckBox()
        Me.dtpFechaAl = New System.Windows.Forms.DateTimePicker()
        Me.lblFecha2 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblFecha1 = New System.Windows.Forms.Label()
        Me.pb = New System.Windows.Forms.PictureBox()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.gpoConfiguracion = New System.Windows.Forms.GroupBox()
        Me.cboNave2 = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.rbtPorGrupo = New System.Windows.Forms.RadioButton()
        Me.rbtPorNave = New System.Windows.Forms.RadioButton()
        Me.gpoImpresoras = New System.Windows.Forms.GroupBox()
        Me.cboImpresora = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gpodetalles = New System.Windows.Forms.GroupBox()
        Me.cboProveedor = New System.Windows.Forms.ComboBox()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkTodasNaves = New System.Windows.Forms.CheckBox()
        Me.chkTodosProveedores = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gpoTipoImpresion = New System.Windows.Forms.GroupBox()
        Me.rbtEtiquetasConsumos = New System.Windows.Forms.RadioButton()
        Me.rbtEtiquetasPlanta = New System.Windows.Forms.RadioButton()
        Me.rbtEtiquetasSuela = New System.Windows.Forms.RadioButton()
        Me.rbtEtiquetasPlantilla = New System.Windows.Forms.RadioButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlListaPaises.SuspendLayout()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.gpoConfiguracion.SuspendLayout()
        CType(Me.cboNave2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpoImpresoras.SuspendLayout()
        Me.gpodetalles.SuspendLayout()
        Me.gpoTipoImpresion.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.chkRangoFechas)
        Me.Panel1.Controls.Add(Me.dtpFechaAl)
        Me.Panel1.Controls.Add(Me.lblFecha2)
        Me.Panel1.Controls.Add(Me.dtpFecha)
        Me.Panel1.Controls.Add(Me.lblFecha1)
        Me.Panel1.Controls.Add(Me.pb)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(403, 86)
        Me.Panel1.TabIndex = 39
        '
        'chkRangoFechas
        '
        Me.chkRangoFechas.AutoSize = True
        Me.chkRangoFechas.Location = New System.Drawing.Point(13, 10)
        Me.chkRangoFechas.Name = "chkRangoFechas"
        Me.chkRangoFechas.Size = New System.Drawing.Size(61, 30)
        Me.chkRangoFechas.TabIndex = 149
        Me.chkRangoFechas.Text = "Rango" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Fechas"
        Me.chkRangoFechas.UseVisualStyleBackColor = True
        '
        'dtpFechaAl
        '
        Me.dtpFechaAl.CalendarForeColor = System.Drawing.SystemColors.GrayText
        Me.dtpFechaAl.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText
        Me.dtpFechaAl.CalendarTitleForeColor = System.Drawing.Color.AliceBlue
        Me.dtpFechaAl.Enabled = False
        Me.dtpFechaAl.Location = New System.Drawing.Point(143, 49)
        Me.dtpFechaAl.Name = "dtpFechaAl"
        Me.dtpFechaAl.Size = New System.Drawing.Size(193, 20)
        Me.dtpFechaAl.TabIndex = 148
        Me.dtpFechaAl.Value = New Date(2018, 2, 20, 16, 34, 0, 0)
        '
        'lblFecha2
        '
        Me.lblFecha2.AutoSize = True
        Me.lblFecha2.Enabled = False
        Me.lblFecha2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.lblFecha2.Location = New System.Drawing.Point(78, 52)
        Me.lblFecha2.Name = "lblFecha2"
        Me.lblFecha2.Size = New System.Drawing.Size(51, 13)
        Me.lblFecha2.TabIndex = 147
        Me.lblFecha2.Text = "Fecha al:"
        '
        'dtpFecha
        '
        Me.dtpFecha.CalendarForeColor = System.Drawing.SystemColors.GrayText
        Me.dtpFecha.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText
        Me.dtpFecha.CalendarTitleForeColor = System.Drawing.Color.AliceBlue
        Me.dtpFecha.Location = New System.Drawing.Point(143, 12)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(193, 20)
        Me.dtpFecha.TabIndex = 107
        Me.dtpFecha.Value = New Date(2018, 2, 20, 16, 34, 0, 0)
        '
        'lblFecha1
        '
        Me.lblFecha1.AutoSize = True
        Me.lblFecha1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.lblFecha1.Location = New System.Drawing.Point(78, 15)
        Me.lblFecha1.Name = "lblFecha1"
        Me.lblFecha1.Size = New System.Drawing.Size(64, 13)
        Me.lblFecha1.TabIndex = 65
        Me.lblFecha1.Text = "F.Programa:"
        '
        'pb
        '
        Me.pb.Image = CType(resources.GetObject("pb.Image"), System.Drawing.Image)
        Me.pb.Location = New System.Drawing.Point(341, 10)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(10, 10)
        Me.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb.TabIndex = 146
        Me.pb.TabStop = False
        Me.pb.Visible = False
        '
        'cboGrupo
        '
        Me.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrupo.Enabled = False
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(176, 14)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(160, 21)
        Me.cboGrupo.TabIndex = 147
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(131, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 146
        Me.Label2.Text = "Grupo:"
        '
        'cboNave
        '
        Me.cboNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNave.FormattingEnabled = True
        Me.cboNave.Location = New System.Drawing.Point(176, 44)
        Me.cboNave.Name = "cboNave"
        Me.cboNave.Size = New System.Drawing.Size(160, 21)
        Me.cboNave.TabIndex = 145
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.lblNave.Location = New System.Drawing.Point(134, 47)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(36, 13)
        Me.lblNave.TabIndex = 63
        Me.lblNave.Text = "Nave:"
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.UltraPanel1)
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(403, 65)
        Me.pnlListaPaises.TabIndex = 38
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.btnReporte)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label1)
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(89, 65)
        Me.UltraPanel1.TabIndex = 7
        '
        'btnReporte
        '
        Me.btnReporte.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnReporte.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnReporte.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnReporte.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnReporte.Location = New System.Drawing.Point(29, 3)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(32, 32)
        Me.btnReporte.TabIndex = 14
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(21, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 26)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Rep. Etiq." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  Suelas"
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(136, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(267, 65)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(11, 19)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(191, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Etiquetas Proveedores"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.pnlDatosBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 482)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(403, 59)
        Me.Panel2.TabIndex = 40
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnImprimir)
        Me.pnlDatosBotones.Controls.Add(Me.lblImprimir)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(241, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 59)
        Me.pnlDatosBotones.TabIndex = 3
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(103, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImprimir.Location = New System.Drawing.Point(61, 6)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 7
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblImprimir.Location = New System.Drawing.Point(57, 41)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 6
        Me.lblImprimir.Text = "Imprimir"
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(104, 41)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.gpoConfiguracion)
        Me.Panel3.Controls.Add(Me.gpoImpresoras)
        Me.Panel3.Controls.Add(Me.gpodetalles)
        Me.Panel3.Controls.Add(Me.gpoTipoImpresion)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 151)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(403, 331)
        Me.Panel3.TabIndex = 41
        '
        'gpoConfiguracion
        '
        Me.gpoConfiguracion.Controls.Add(Me.cboNave2)
        Me.gpoConfiguracion.Controls.Add(Me.rbtPorGrupo)
        Me.gpoConfiguracion.Controls.Add(Me.rbtPorNave)
        Me.gpoConfiguracion.Controls.Add(Me.cboGrupo)
        Me.gpoConfiguracion.Controls.Add(Me.lblNave)
        Me.gpoConfiguracion.Controls.Add(Me.Label2)
        Me.gpoConfiguracion.Controls.Add(Me.cboNave)
        Me.gpoConfiguracion.Location = New System.Drawing.Point(13, 8)
        Me.gpoConfiguracion.Name = "gpoConfiguracion"
        Me.gpoConfiguracion.Size = New System.Drawing.Size(370, 83)
        Me.gpoConfiguracion.TabIndex = 11
        Me.gpoConfiguracion.TabStop = False
        Me.gpoConfiguracion.Text = "Configuracion"
        '
        'cboNave2
        '
        Me.cboNave2.CheckedListSettings.CheckBoxAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cboNave2.CheckedListSettings.CheckBoxStyle = Infragistics.Win.CheckStyle.CheckBox
        Me.cboNave2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cboNave2.Location = New System.Drawing.Point(176, 44)
        Me.cboNave2.Name = "cboNave2"
        Me.cboNave2.Size = New System.Drawing.Size(160, 21)
        Me.cboNave2.TabIndex = 150
        '
        'rbtPorGrupo
        '
        Me.rbtPorGrupo.AutoSize = True
        Me.rbtPorGrupo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.rbtPorGrupo.Location = New System.Drawing.Point(31, 17)
        Me.rbtPorGrupo.Name = "rbtPorGrupo"
        Me.rbtPorGrupo.Size = New System.Drawing.Size(73, 17)
        Me.rbtPorGrupo.TabIndex = 149
        Me.rbtPorGrupo.Text = "Por Grupo"
        Me.rbtPorGrupo.UseVisualStyleBackColor = True
        '
        'rbtPorNave
        '
        Me.rbtPorNave.AutoSize = True
        Me.rbtPorNave.Checked = True
        Me.rbtPorNave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.rbtPorNave.Location = New System.Drawing.Point(31, 45)
        Me.rbtPorNave.Name = "rbtPorNave"
        Me.rbtPorNave.Size = New System.Drawing.Size(70, 17)
        Me.rbtPorNave.TabIndex = 148
        Me.rbtPorNave.TabStop = True
        Me.rbtPorNave.Text = "Por Nave"
        Me.rbtPorNave.UseVisualStyleBackColor = True
        '
        'gpoImpresoras
        '
        Me.gpoImpresoras.Controls.Add(Me.cboImpresora)
        Me.gpoImpresoras.Controls.Add(Me.Label5)
        Me.gpoImpresoras.Location = New System.Drawing.Point(13, 271)
        Me.gpoImpresoras.Name = "gpoImpresoras"
        Me.gpoImpresoras.Size = New System.Drawing.Size(370, 52)
        Me.gpoImpresoras.TabIndex = 10
        Me.gpoImpresoras.TabStop = False
        Me.gpoImpresoras.Text = "Impresoras"
        '
        'cboImpresora
        '
        Me.cboImpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboImpresora.FormattingEnabled = True
        Me.cboImpresora.Location = New System.Drawing.Point(140, 19)
        Me.cboImpresora.Name = "cboImpresora"
        Me.cboImpresora.Size = New System.Drawing.Size(152, 21)
        Me.cboImpresora.TabIndex = 148
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(73, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 147
        Me.Label5.Text = "Impresora:"
        '
        'gpodetalles
        '
        Me.gpodetalles.Controls.Add(Me.cboProveedor)
        Me.gpodetalles.Controls.Add(Me.txtLote)
        Me.gpodetalles.Controls.Add(Me.Label4)
        Me.gpodetalles.Controls.Add(Me.chkTodasNaves)
        Me.gpodetalles.Controls.Add(Me.chkTodosProveedores)
        Me.gpodetalles.Controls.Add(Me.Label3)
        Me.gpodetalles.Location = New System.Drawing.Point(13, 172)
        Me.gpodetalles.Name = "gpodetalles"
        Me.gpodetalles.Size = New System.Drawing.Size(370, 96)
        Me.gpodetalles.TabIndex = 9
        Me.gpodetalles.TabStop = False
        Me.gpodetalles.Text = "Detalles"
        '
        'cboProveedor
        '
        Me.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProveedor.Enabled = False
        Me.cboProveedor.FormattingEnabled = True
        Me.cboProveedor.Location = New System.Drawing.Point(82, 20)
        Me.cboProveedor.Name = "cboProveedor"
        Me.cboProveedor.Size = New System.Drawing.Size(270, 21)
        Me.cboProveedor.TabIndex = 145
        '
        'txtLote
        '
        Me.txtLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLote.Location = New System.Drawing.Point(82, 55)
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(88, 21)
        Me.txtLote.TabIndex = 5
        Me.txtLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(18, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Lote:"
        '
        'chkTodasNaves
        '
        Me.chkTodasNaves.AutoSize = True
        Me.chkTodasNaves.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.chkTodasNaves.Location = New System.Drawing.Point(214, 74)
        Me.chkTodasNaves.Name = "chkTodasNaves"
        Me.chkTodasNaves.Size = New System.Drawing.Size(109, 17)
        Me.chkTodasNaves.TabIndex = 3
        Me.chkTodasNaves.Text = "Todas las Naves."
        Me.chkTodasNaves.UseVisualStyleBackColor = True
        '
        'chkTodosProveedores
        '
        Me.chkTodosProveedores.AutoSize = True
        Me.chkTodosProveedores.Checked = True
        Me.chkTodosProveedores.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodosProveedores.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.chkTodosProveedores.Location = New System.Drawing.Point(214, 49)
        Me.chkTodosProveedores.Name = "chkTodosProveedores"
        Me.chkTodosProveedores.Size = New System.Drawing.Size(138, 17)
        Me.chkTodosProveedores.TabIndex = 2
        Me.chkTodosProveedores.Text = "Todos los Proveedores."
        Me.chkTodosProveedores.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(17, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Proveedor:"
        '
        'gpoTipoImpresion
        '
        Me.gpoTipoImpresion.Controls.Add(Me.rbtEtiquetasConsumos)
        Me.gpoTipoImpresion.Controls.Add(Me.rbtEtiquetasPlanta)
        Me.gpoTipoImpresion.Controls.Add(Me.rbtEtiquetasSuela)
        Me.gpoTipoImpresion.Controls.Add(Me.rbtEtiquetasPlantilla)
        Me.gpoTipoImpresion.Location = New System.Drawing.Point(13, 92)
        Me.gpoTipoImpresion.Name = "gpoTipoImpresion"
        Me.gpoTipoImpresion.Size = New System.Drawing.Size(370, 76)
        Me.gpoTipoImpresion.TabIndex = 8
        Me.gpoTipoImpresion.TabStop = False
        Me.gpoTipoImpresion.Text = "Tipo de Impresión"
        '
        'rbtEtiquetasConsumos
        '
        Me.rbtEtiquetasConsumos.AutoSize = True
        Me.rbtEtiquetasConsumos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.rbtEtiquetasConsumos.Location = New System.Drawing.Point(21, 19)
        Me.rbtEtiquetasConsumos.Name = "rbtEtiquetasConsumos"
        Me.rbtEtiquetasConsumos.Size = New System.Drawing.Size(124, 17)
        Me.rbtEtiquetasConsumos.TabIndex = 0
        Me.rbtEtiquetasConsumos.TabStop = True
        Me.rbtEtiquetasConsumos.Text = "Etiquetas Consumos."
        Me.rbtEtiquetasConsumos.UseVisualStyleBackColor = True
        '
        'rbtEtiquetasPlanta
        '
        Me.rbtEtiquetasPlanta.AutoSize = True
        Me.rbtEtiquetasPlanta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.rbtEtiquetasPlanta.Location = New System.Drawing.Point(21, 45)
        Me.rbtEtiquetasPlanta.Name = "rbtEtiquetasPlanta"
        Me.rbtEtiquetasPlanta.Size = New System.Drawing.Size(156, 17)
        Me.rbtEtiquetasPlanta.TabIndex = 1
        Me.rbtEtiquetasPlanta.TabStop = True
        Me.rbtEtiquetasPlanta.Text = "Etiquetas Pedido de Planta."
        Me.rbtEtiquetasPlanta.UseVisualStyleBackColor = True
        '
        'rbtEtiquetasSuela
        '
        Me.rbtEtiquetasSuela.AutoSize = True
        Me.rbtEtiquetasSuela.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.rbtEtiquetasSuela.Location = New System.Drawing.Point(199, 19)
        Me.rbtEtiquetasSuela.Name = "rbtEtiquetasSuela"
        Me.rbtEtiquetasSuela.Size = New System.Drawing.Size(153, 17)
        Me.rbtEtiquetasSuela.TabIndex = 2
        Me.rbtEtiquetasSuela.TabStop = True
        Me.rbtEtiquetasSuela.Text = "Etiquetas Pedido de Suela."
        Me.rbtEtiquetasSuela.UseVisualStyleBackColor = True
        '
        'rbtEtiquetasPlantilla
        '
        Me.rbtEtiquetasPlantilla.AutoSize = True
        Me.rbtEtiquetasPlantilla.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.rbtEtiquetasPlantilla.Location = New System.Drawing.Point(199, 45)
        Me.rbtEtiquetasPlantilla.Name = "rbtEtiquetasPlantilla"
        Me.rbtEtiquetasPlantilla.Size = New System.Drawing.Size(126, 17)
        Me.rbtEtiquetasPlantilla.TabIndex = 3
        Me.rbtEtiquetasPlantilla.TabStop = True
        Me.rbtEtiquetasPlantilla.Text = "Etiquetas de Plantilla."
        Me.rbtEtiquetasPlantilla.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(198, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(69, 65)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'EtiquetasProveedoresForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 541)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(411, 580)
        Me.MinimumSize = New System.Drawing.Size(411, 499)
        Me.Name = "EtiquetasProveedoresForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Etiquetas de Proveedores"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.PerformLayout()
        Me.UltraPanel1.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.gpoConfiguracion.ResumeLayout(False)
        Me.gpoConfiguracion.PerformLayout()
        CType(Me.cboNave2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpoImpresoras.ResumeLayout(False)
        Me.gpoImpresoras.PerformLayout()
        Me.gpodetalles.ResumeLayout(False)
        Me.gpodetalles.PerformLayout()
        Me.gpoTipoImpresion.ResumeLayout(False)
        Me.gpoTipoImpresion.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents lblFecha1 As Label
    Friend WithEvents lblNave As Label
    Friend WithEvents pnlListaPaises As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents rbtEtiquetasPlantilla As RadioButton
    Friend WithEvents rbtEtiquetasSuela As RadioButton
    Friend WithEvents rbtEtiquetasPlanta As RadioButton
    Friend WithEvents rbtEtiquetasConsumos As RadioButton
    Friend WithEvents btnImprimir As Button
    Friend WithEvents lblImprimir As Label
    Friend WithEvents gpodetalles As GroupBox
    Friend WithEvents txtLote As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkTodasNaves As CheckBox
    Friend WithEvents chkTodosProveedores As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents gpoTipoImpresion As GroupBox
    Friend WithEvents cboNave As ComboBox
    Friend WithEvents cboProveedor As ComboBox
    Friend WithEvents gpoImpresoras As GroupBox
    Friend WithEvents cboImpresora As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents pb As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label2 As Label
    Friend WithEvents cboGrupo As ComboBox
    Friend WithEvents gpoConfiguracion As GroupBox
    Friend WithEvents rbtPorGrupo As RadioButton
    Friend WithEvents rbtPorNave As RadioButton
    Friend WithEvents cboNave2 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents chkRangoFechas As CheckBox
    Friend WithEvents dtpFechaAl As DateTimePicker
    Friend WithEvents lblFecha2 As Label
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnReporte As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
