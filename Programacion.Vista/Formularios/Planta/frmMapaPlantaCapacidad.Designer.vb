<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMapaPlantaCapacidad
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.lblListaNaves = New System.Windows.Forms.Label()
        Me.grbNaves = New System.Windows.Forms.GroupBox()
        Me.lblSimulacionFolio = New System.Windows.Forms.Label()
        Me.cmbFoliosSimulacion = New System.Windows.Forms.ComboBox()
        Me.lblSimulacionMaestro = New System.Windows.Forms.Label()
        Me.chkMapaSimulacion = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkPedidos = New System.Windows.Forms.CheckBox()
        Me.chkBloqueo = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdoPersonalizado = New System.Windows.Forms.RadioButton()
        Me.rdoCreacion = New System.Windows.Forms.RadioButton()
        Me.rdoAlfabetico = New System.Windows.Forms.RadioButton()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.numAnioInicio = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numAnioFin = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grbSemanas = New System.Windows.Forms.GroupBox()
        Me.numSemanaInicio = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numSemanaFin = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUP = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdMapa = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlExtado = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEliminarSimulacion = New System.Windows.Forms.Label()
        Me.btnEliminarSimulacion = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbNaves.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numAnioInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAnioFin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbSemanas.SuspendLayout()
        CType(Me.numSemanaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSemanaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.grdMapa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExtado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1082, 59)
        Me.pnlEncabezado.TabIndex = 5
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.lblListaNaves)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(712, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(370, 59)
        Me.pnlTitulo.TabIndex = 33
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(302, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 22
        Me.pcbTitulo.TabStop = False
        '
        'imgLogo
        '
        Me.imgLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgLogo.Location = New System.Drawing.Point(309, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(61, 59)
        Me.imgLogo.TabIndex = 0
        Me.imgLogo.TabStop = False
        '
        'lblListaNaves
        '
        Me.lblListaNaves.AutoSize = True
        Me.lblListaNaves.BackColor = System.Drawing.Color.Transparent
        Me.lblListaNaves.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaNaves.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaNaves.Location = New System.Drawing.Point(2, 19)
        Me.lblListaNaves.Name = "lblListaNaves"
        Me.lblListaNaves.Size = New System.Drawing.Size(299, 20)
        Me.lblListaNaves.TabIndex = 21
        Me.lblListaNaves.Text = "Capacidad por Célula de Producción"
        '
        'grbNaves
        '
        Me.grbNaves.Controls.Add(Me.lblSimulacionFolio)
        Me.grbNaves.Controls.Add(Me.cmbFoliosSimulacion)
        Me.grbNaves.Controls.Add(Me.lblSimulacionMaestro)
        Me.grbNaves.Controls.Add(Me.chkMapaSimulacion)
        Me.grbNaves.Controls.Add(Me.GroupBox2)
        Me.grbNaves.Controls.Add(Me.GroupBox3)
        Me.grbNaves.Controls.Add(Me.lblNave)
        Me.grbNaves.Controls.Add(Me.cmbNaves)
        Me.grbNaves.Controls.Add(Me.GroupBox1)
        Me.grbNaves.Controls.Add(Me.grbSemanas)
        Me.grbNaves.Controls.Add(Me.Panel2)
        Me.grbNaves.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbNaves.Location = New System.Drawing.Point(0, 59)
        Me.grbNaves.Name = "grbNaves"
        Me.grbNaves.Size = New System.Drawing.Size(1082, 118)
        Me.grbNaves.TabIndex = 17
        Me.grbNaves.TabStop = False
        '
        'lblSimulacionFolio
        '
        Me.lblSimulacionFolio.AutoSize = True
        Me.lblSimulacionFolio.Location = New System.Drawing.Point(19, 86)
        Me.lblSimulacionFolio.Name = "lblSimulacionFolio"
        Me.lblSimulacionFolio.Size = New System.Drawing.Size(29, 13)
        Me.lblSimulacionFolio.TabIndex = 89
        Me.lblSimulacionFolio.Text = "Folio"
        '
        'cmbFoliosSimulacion
        '
        Me.cmbFoliosSimulacion.Enabled = False
        Me.cmbFoliosSimulacion.FormattingEnabled = True
        Me.cmbFoliosSimulacion.Location = New System.Drawing.Point(55, 82)
        Me.cmbFoliosSimulacion.Name = "cmbFoliosSimulacion"
        Me.cmbFoliosSimulacion.Size = New System.Drawing.Size(281, 21)
        Me.cmbFoliosSimulacion.TabIndex = 88
        '
        'lblSimulacionMaestro
        '
        Me.lblSimulacionMaestro.AutoSize = True
        Me.lblSimulacionMaestro.Location = New System.Drawing.Point(15, 26)
        Me.lblSimulacionMaestro.Name = "lblSimulacionMaestro"
        Me.lblSimulacionMaestro.Size = New System.Drawing.Size(13, 13)
        Me.lblSimulacionMaestro.TabIndex = 87
        Me.lblSimulacionMaestro.Text = "0"
        Me.lblSimulacionMaestro.Visible = False
        '
        'chkMapaSimulacion
        '
        Me.chkMapaSimulacion.AutoSize = True
        Me.chkMapaSimulacion.Location = New System.Drawing.Point(360, 84)
        Me.chkMapaSimulacion.Name = "chkMapaSimulacion"
        Me.chkMapaSimulacion.Size = New System.Drawing.Size(102, 17)
        Me.chkMapaSimulacion.TabIndex = 71
        Me.chkMapaSimulacion.Text = "Mapa Simulador"
        Me.chkMapaSimulacion.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkPedidos)
        Me.GroupBox2.Controls.Add(Me.chkBloqueo)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox2.Location = New System.Drawing.Point(474, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(103, 99)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtros"
        '
        'chkPedidos
        '
        Me.chkPedidos.AutoSize = True
        Me.chkPedidos.Checked = True
        Me.chkPedidos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPedidos.Location = New System.Drawing.Point(19, 30)
        Me.chkPedidos.Name = "chkPedidos"
        Me.chkPedidos.Size = New System.Drawing.Size(64, 17)
        Me.chkPedidos.TabIndex = 1
        Me.chkPedidos.Text = "Pedidos"
        Me.chkPedidos.UseVisualStyleBackColor = True
        '
        'chkBloqueo
        '
        Me.chkBloqueo.AutoSize = True
        Me.chkBloqueo.Checked = True
        Me.chkBloqueo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBloqueo.Location = New System.Drawing.Point(19, 65)
        Me.chkBloqueo.Name = "chkBloqueo"
        Me.chkBloqueo.Size = New System.Drawing.Size(65, 17)
        Me.chkBloqueo.TabIndex = 57
        Me.chkBloqueo.Text = "Bloqueo"
        Me.chkBloqueo.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdoPersonalizado)
        Me.GroupBox3.Controls.Add(Me.rdoCreacion)
        Me.GroupBox3.Controls.Add(Me.rdoAlfabetico)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox3.Location = New System.Drawing.Point(577, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(103, 99)
        Me.GroupBox3.TabIndex = 38
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ordenamiento"
        '
        'rdoPersonalizado
        '
        Me.rdoPersonalizado.AutoSize = True
        Me.rdoPersonalizado.Checked = True
        Me.rdoPersonalizado.Location = New System.Drawing.Point(11, 22)
        Me.rdoPersonalizado.Name = "rdoPersonalizado"
        Me.rdoPersonalizado.Size = New System.Drawing.Size(91, 17)
        Me.rdoPersonalizado.TabIndex = 2
        Me.rdoPersonalizado.TabStop = True
        Me.rdoPersonalizado.Text = "Personalizado"
        Me.rdoPersonalizado.UseVisualStyleBackColor = True
        '
        'rdoCreacion
        '
        Me.rdoCreacion.AutoSize = True
        Me.rdoCreacion.Location = New System.Drawing.Point(11, 72)
        Me.rdoCreacion.Name = "rdoCreacion"
        Me.rdoCreacion.Size = New System.Drawing.Size(67, 17)
        Me.rdoCreacion.TabIndex = 1
        Me.rdoCreacion.Text = "Creación"
        Me.rdoCreacion.UseVisualStyleBackColor = True
        '
        'rdoAlfabetico
        '
        Me.rdoAlfabetico.AutoSize = True
        Me.rdoAlfabetico.Location = New System.Drawing.Point(11, 47)
        Me.rdoAlfabetico.Name = "rdoAlfabetico"
        Me.rdoAlfabetico.Size = New System.Drawing.Size(72, 17)
        Me.rdoAlfabetico.TabIndex = 0
        Me.rdoAlfabetico.Text = "Alfabético"
        Me.rdoAlfabetico.UseVisualStyleBackColor = True
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave.Location = New System.Drawing.Point(15, 56)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 36
        Me.lblNave.Text = "Nave"
        '
        'cmbNaves
        '
        Me.cmbNaves.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.Location = New System.Drawing.Point(55, 52)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(281, 21)
        Me.cmbNaves.TabIndex = 37
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.numAnioInicio)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.numAnioFin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox1.Location = New System.Drawing.Point(680, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(192, 99)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rango Años"
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
        'grbSemanas
        '
        Me.grbSemanas.Controls.Add(Me.numSemanaInicio)
        Me.grbSemanas.Controls.Add(Me.Label4)
        Me.grbSemanas.Controls.Add(Me.numSemanaFin)
        Me.grbSemanas.Controls.Add(Me.Label5)
        Me.grbSemanas.Dock = System.Windows.Forms.DockStyle.Right
        Me.grbSemanas.Location = New System.Drawing.Point(872, 16)
        Me.grbSemanas.Name = "grbSemanas"
        Me.grbSemanas.Size = New System.Drawing.Size(140, 99)
        Me.grbSemanas.TabIndex = 34
        Me.grbSemanas.TabStop = False
        Me.grbSemanas.Text = "Rango Semanas"
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
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnDown)
        Me.Panel2.Controls.Add(Me.btnUP)
        Me.Panel2.Controls.Add(Me.btnMostrar)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1012, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(67, 99)
        Me.Panel2.TabIndex = 32
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
        'grdMapa
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMapa.DisplayLayout.Appearance = Appearance1
        Me.grdMapa.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdMapa.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdMapa.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdMapa.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdMapa.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdMapa.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdMapa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMapa.Location = New System.Drawing.Point(0, 177)
        Me.grdMapa.Name = "grdMapa"
        Me.grdMapa.Size = New System.Drawing.Size(1082, 332)
        Me.grdMapa.TabIndex = 21
        '
        'pnlExtado
        '
        Me.pnlExtado.BackColor = System.Drawing.Color.White
        Me.pnlExtado.Controls.Add(Me.Panel1)
        Me.pnlExtado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlExtado.Location = New System.Drawing.Point(0, 509)
        Me.pnlExtado.Name = "pnlExtado"
        Me.pnlExtado.Size = New System.Drawing.Size(1082, 60)
        Me.pnlExtado.TabIndex = 22
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblEliminarSimulacion)
        Me.Panel1.Controls.Add(Me.btnEliminarSimulacion)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(872, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(210, 60)
        Me.Panel1.TabIndex = 0
        '
        'lblEliminarSimulacion
        '
        Me.lblEliminarSimulacion.AutoSize = True
        Me.lblEliminarSimulacion.Enabled = False
        Me.lblEliminarSimulacion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEliminarSimulacion.Location = New System.Drawing.Point(32, 39)
        Me.lblEliminarSimulacion.Name = "lblEliminarSimulacion"
        Me.lblEliminarSimulacion.Size = New System.Drawing.Size(97, 13)
        Me.lblEliminarSimulacion.TabIndex = 7
        Me.lblEliminarSimulacion.Text = "Eliminar Simulación"
        Me.lblEliminarSimulacion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnEliminarSimulacion
        '
        Me.btnEliminarSimulacion.Enabled = False
        Me.btnEliminarSimulacion.Image = Global.Programacion.Vista.My.Resources.Resources.borrar_32
        Me.btnEliminarSimulacion.Location = New System.Drawing.Point(64, 8)
        Me.btnEliminarSimulacion.Name = "btnEliminarSimulacion"
        Me.btnEliminarSimulacion.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminarSimulacion.TabIndex = 6
        Me.btnEliminarSimulacion.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(157, 39)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(158, 8)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmMapaPlantaCapacidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1082, 569)
        Me.Controls.Add(Me.grdMapa)
        Me.Controls.Add(Me.pnlExtado)
        Me.Controls.Add(Me.grbNaves)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmMapaPlantaCapacidad"
        Me.Text = "Capacidad por Célula de Producción"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbNaves.ResumeLayout(False)
        Me.grbNaves.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numAnioInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAnioFin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbSemanas.ResumeLayout(False)
        Me.grbSemanas.PerformLayout()
        CType(Me.numSemanaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSemanaFin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.grdMapa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExtado.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblListaNaves As System.Windows.Forms.Label
    Friend WithEvents grbNaves As System.Windows.Forms.GroupBox
    Friend WithEvents grdMapa As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlExtado As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numAnioInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents numAnioFin As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grbSemanas As System.Windows.Forms.GroupBox
    Friend WithEvents numSemanaInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents numSemanaFin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnUP As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkPedidos As System.Windows.Forms.CheckBox
    Friend WithEvents chkBloqueo As System.Windows.Forms.CheckBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoPersonalizado As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCreacion As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAlfabetico As System.Windows.Forms.RadioButton
    Friend WithEvents chkMapaSimulacion As System.Windows.Forms.CheckBox
    Friend WithEvents lblSimulacionMaestro As System.Windows.Forms.Label
    Friend WithEvents lblSimulacionFolio As System.Windows.Forms.Label
    Friend WithEvents cmbFoliosSimulacion As System.Windows.Forms.ComboBox
    Friend WithEvents lblEliminarSimulacion As System.Windows.Forms.Label
    Friend WithEvents btnEliminarSimulacion As System.Windows.Forms.Button
End Class
