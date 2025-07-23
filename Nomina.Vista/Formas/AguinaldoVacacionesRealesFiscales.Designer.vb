<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AguinaldoVacacionesRealesFiscales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AguinaldoVacacionesRealesFiscales))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbPeriodo = New System.Windows.Forms.ComboBox()
        Me.lblcolaborador = New System.Windows.Forms.Label()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.cmbAño = New System.Windows.Forms.ComboBox()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlBanner = New System.Windows.Forms.Panel()
        Me.lblExterno = New System.Windows.Forms.Label()
        Me.btnExterno = New System.Windows.Forms.Button()
        Me.btnExcluidos2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnExcluidos = New System.Windows.Forms.Button()
        Me.btnImpCod = New System.Windows.Forms.Button()
        Me.lblImportar = New System.Windows.Forms.Label()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblTotEfectivo = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblExternos = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblInternos = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblAV = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblSeleccion = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.menuImprimir = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AguinaldosYVacacionesRealesYFiscalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirCartasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirSobresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AguinaldoYVacacionesPorNaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdRealesFiscales = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbParametros.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.pnlBanner.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.menuImprimir.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdRealesFiscales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbParametros
        '
        Me.grbParametros.Controls.Add(Me.Label9)
        Me.grbParametros.Controls.Add(Me.cmbPeriodo)
        Me.grbParametros.Controls.Add(Me.lblcolaborador)
        Me.grbParametros.Controls.Add(Me.txtColaborador)
        Me.grbParametros.Controls.Add(Me.cmbAño)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Controls.Add(Me.Label2)
        Me.grbParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.grbParametros.Controls.Add(Me.lblNave)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 60)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1117, 106)
        Me.grbParametros.TabIndex = 58
        Me.grbParametros.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(536, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "Periodo"
        '
        'cmbPeriodo
        '
        Me.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodo.ForeColor = System.Drawing.Color.Black
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.Items.AddRange(New Object() {"SEMANA SANTA", "NAVIDAD"})
        Me.cmbPeriodo.Location = New System.Drawing.Point(585, 28)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(123, 21)
        Me.cmbPeriodo.TabIndex = 68
        '
        'lblcolaborador
        '
        Me.lblcolaborador.AutoSize = True
        Me.lblcolaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcolaborador.ForeColor = System.Drawing.Color.Black
        Me.lblcolaborador.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblcolaborador.Location = New System.Drawing.Point(14, 69)
        Me.lblcolaborador.Name = "lblcolaborador"
        Me.lblcolaborador.Size = New System.Drawing.Size(64, 13)
        Me.lblcolaborador.TabIndex = 62
        Me.lblcolaborador.Text = "Colaborador"
        '
        'txtColaborador
        '
        Me.txtColaborador.ForeColor = System.Drawing.Color.Black
        Me.txtColaborador.Location = New System.Drawing.Point(83, 66)
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.Size = New System.Drawing.Size(405, 20)
        Me.txtColaborador.TabIndex = 63
        '
        'cmbAño
        '
        Me.cmbAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAño.ForeColor = System.Drawing.Color.Black
        Me.cmbAño.FormattingEnabled = True
        Me.cmbAño.Location = New System.Drawing.Point(379, 28)
        Me.cmbAño.Name = "cmbAño"
        Me.cmbAño.Size = New System.Drawing.Size(137, 21)
        Me.cmbAño.TabIndex = 61
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(83, 28)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(227, 21)
        Me.cmbNave.TabIndex = 60
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(328, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Año"
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.btnBuscar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.lblLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.Label1)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(975, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(139, 87)
        Me.pnlMinimizarParametros.TabIndex = 56
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBuscar.Location = New System.Drawing.Point(56, 27)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 46
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(97, 27)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 61
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(95, 57)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 60
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(82, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(52, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Mostrar"
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(105, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNave.Location = New System.Drawing.Point(44, 31)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 45
        Me.lblNave.Text = "Nave"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(171, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Guardar"
        '
        'pnlBanner
        '
        Me.pnlBanner.BackColor = System.Drawing.Color.White
        Me.pnlBanner.Controls.Add(Me.lblExterno)
        Me.pnlBanner.Controls.Add(Me.btnExterno)
        Me.pnlBanner.Controls.Add(Me.btnExcluidos2)
        Me.pnlBanner.Controls.Add(Me.Label4)
        Me.pnlBanner.Controls.Add(Me.btnExcluidos)
        Me.pnlBanner.Controls.Add(Me.btnImpCod)
        Me.pnlBanner.Controls.Add(Me.lblImportar)
        Me.pnlBanner.Controls.Add(Me.lblImprimir)
        Me.pnlBanner.Controls.Add(Me.btnImprimir)
        Me.pnlBanner.Controls.Add(Me.pnlTitulo)
        Me.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBanner.Location = New System.Drawing.Point(0, 0)
        Me.pnlBanner.Name = "pnlBanner"
        Me.pnlBanner.Size = New System.Drawing.Size(1117, 60)
        Me.pnlBanner.TabIndex = 56
        '
        'lblExterno
        '
        Me.lblExterno.AutoSize = True
        Me.lblExterno.BackColor = System.Drawing.Color.Transparent
        Me.lblExterno.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExterno.Location = New System.Drawing.Point(61, 38)
        Me.lblExterno.Name = "lblExterno"
        Me.lblExterno.Size = New System.Drawing.Size(43, 13)
        Me.lblExterno.TabIndex = 34
        Me.lblExterno.Text = "Externo"
        Me.lblExterno.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnExterno
        '
        Me.btnExterno.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnExterno.Image = Global.Nomina.Vista.My.Resources.Resources.finiquito_32
        Me.btnExterno.Location = New System.Drawing.Point(64, 3)
        Me.btnExterno.Name = "btnExterno"
        Me.btnExterno.Size = New System.Drawing.Size(32, 32)
        Me.btnExterno.TabIndex = 33
        Me.btnExterno.UseVisualStyleBackColor = False
        '
        'btnExcluidos2
        '
        Me.btnExcluidos2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnExcluidos2.Image = Global.Nomina.Vista.My.Resources.Resources.finiquito_32
        Me.btnExcluidos2.Location = New System.Drawing.Point(728, 22)
        Me.btnExcluidos2.Name = "btnExcluidos2"
        Me.btnExcluidos2.Size = New System.Drawing.Size(32, 32)
        Me.btnExcluidos2.TabIndex = 32
        Me.btnExcluidos2.UseVisualStyleBackColor = False
        Me.btnExcluidos2.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(696, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "No encontrados"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label4.Visible = False
        '
        'btnExcluidos
        '
        Me.btnExcluidos.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnExcluidos.Enabled = False
        Me.btnExcluidos.Image = Global.Nomina.Vista.My.Resources.Resources.finiquito_32
        Me.btnExcluidos.Location = New System.Drawing.Point(676, 22)
        Me.btnExcluidos.Name = "btnExcluidos"
        Me.btnExcluidos.Size = New System.Drawing.Size(32, 32)
        Me.btnExcluidos.TabIndex = 30
        Me.btnExcluidos.UseVisualStyleBackColor = False
        Me.btnExcluidos.Visible = False
        '
        'btnImpCod
        '
        Me.btnImpCod.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnImpCod.Image = Global.Nomina.Vista.My.Resources.Resources.excel_32
        Me.btnImpCod.Location = New System.Drawing.Point(623, 22)
        Me.btnImpCod.Name = "btnImpCod"
        Me.btnImpCod.Size = New System.Drawing.Size(32, 32)
        Me.btnImpCod.TabIndex = 29
        Me.btnImpCod.UseVisualStyleBackColor = False
        Me.btnImpCod.Visible = False
        '
        'lblImportar
        '
        Me.lblImportar.AutoSize = True
        Me.lblImportar.BackColor = System.Drawing.Color.Transparent
        Me.lblImportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImportar.Location = New System.Drawing.Point(620, 3)
        Me.lblImportar.Name = "lblImportar"
        Me.lblImportar.Size = New System.Drawing.Size(45, 13)
        Me.lblImportar.TabIndex = 28
        Me.lblImportar.Text = "Importar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblImportar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblImportar.Visible = False
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(9, 38)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 9
        Me.lblImprimir.Text = "Imprimir"
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Nomina.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(12, 3)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 8
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(782, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(335, 60)
        Me.pnlTitulo.TabIndex = 5
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(267, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 44
        Me.pcbTitulo.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(3, 15)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(256, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Aguinaldos y Vacaciones R y F"
        '
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.Panel6)
        Me.pnlEstado.Controls.Add(Me.Panel5)
        Me.pnlEstado.Controls.Add(Me.Panel4)
        Me.pnlEstado.Controls.Add(Me.Panel3)
        Me.pnlEstado.Controls.Add(Me.Label8)
        Me.pnlEstado.Controls.Add(Me.Label7)
        Me.pnlEstado.Controls.Add(Me.Label6)
        Me.pnlEstado.Controls.Add(Me.Label5)
        Me.pnlEstado.Controls.Add(Me.lblSeleccion)
        Me.pnlEstado.Controls.Add(Me.Panel1)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 454)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1117, 79)
        Me.pnlEstado.TabIndex = 59
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lblTotEfectivo)
        Me.Panel6.Location = New System.Drawing.Point(623, 55)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(85, 17)
        Me.Panel6.TabIndex = 29
        '
        'lblTotEfectivo
        '
        Me.lblTotEfectivo.AutoSize = True
        Me.lblTotEfectivo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTotEfectivo.Location = New System.Drawing.Point(57, 0)
        Me.lblTotEfectivo.Name = "lblTotEfectivo"
        Me.lblTotEfectivo.Size = New System.Drawing.Size(28, 13)
        Me.lblTotEfectivo.TabIndex = 28
        Me.lblTotEfectivo.Text = "0.00"
        Me.lblTotEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblExternos)
        Me.Panel5.Location = New System.Drawing.Point(623, 40)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(85, 15)
        Me.Panel5.TabIndex = 29
        '
        'lblExternos
        '
        Me.lblExternos.AutoSize = True
        Me.lblExternos.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblExternos.Location = New System.Drawing.Point(57, 0)
        Me.lblExternos.Name = "lblExternos"
        Me.lblExternos.Size = New System.Drawing.Size(28, 13)
        Me.lblExternos.TabIndex = 22
        Me.lblExternos.Text = "0.00"
        Me.lblExternos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblInternos)
        Me.Panel4.Location = New System.Drawing.Point(623, 24)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(85, 16)
        Me.Panel4.TabIndex = 29
        '
        'lblInternos
        '
        Me.lblInternos.AutoSize = True
        Me.lblInternos.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblInternos.Location = New System.Drawing.Point(57, 0)
        Me.lblInternos.Name = "lblInternos"
        Me.lblInternos.Size = New System.Drawing.Size(28, 13)
        Me.lblInternos.TabIndex = 26
        Me.lblInternos.Text = "0.00"
        Me.lblInternos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblAV)
        Me.Panel3.Location = New System.Drawing.Point(623, 6)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(85, 18)
        Me.Panel3.TabIndex = 29
        '
        'lblAV
        '
        Me.lblAV.AutoSize = True
        Me.lblAV.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblAV.Location = New System.Drawing.Point(57, 0)
        Me.lblAV.Name = "lblAV"
        Me.lblAV.Size = New System.Drawing.Size(28, 13)
        Me.lblAV.TabIndex = 27
        Me.lblAV.Text = "0.00"
        Me.lblAV.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(502, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Total efectivo:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(501, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Total cheques externos:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(501, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Total cheques internos:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(501, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Total A y V: "
        '
        'lblSeleccion
        '
        Me.lblSeleccion.AutoSize = True
        Me.lblSeleccion.Location = New System.Drawing.Point(12, 8)
        Me.lblSeleccion.Name = "lblSeleccion"
        Me.lblSeleccion.Size = New System.Drawing.Size(10, 13)
        Me.lblSeleccion.TabIndex = 20
        Me.lblSeleccion.Text = "-"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(853, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(264, 79)
        Me.Panel1.TabIndex = 1
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(177, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 62
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(221, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(220, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'menuImprimir
        '
        Me.menuImprimir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AguinaldosYVacacionesRealesYFiscalesToolStripMenuItem, Me.ImprimirCartasToolStripMenuItem, Me.ImprimirSobresToolStripMenuItem, Me.AguinaldoYVacacionesPorNaveToolStripMenuItem})
        Me.menuImprimir.Name = "menuImprimir"
        Me.menuImprimir.Size = New System.Drawing.Size(237, 92)
        '
        'AguinaldosYVacacionesRealesYFiscalesToolStripMenuItem
        '
        Me.AguinaldosYVacacionesRealesYFiscalesToolStripMenuItem.Name = "AguinaldosYVacacionesRealesYFiscalesToolStripMenuItem"
        Me.AguinaldosYVacacionesRealesYFiscalesToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.AguinaldosYVacacionesRealesYFiscalesToolStripMenuItem.Text = "Aguinaldos y Vacaciones R y F"
        '
        'ImprimirCartasToolStripMenuItem
        '
        Me.ImprimirCartasToolStripMenuItem.Name = "ImprimirCartasToolStripMenuItem"
        Me.ImprimirCartasToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.ImprimirCartasToolStripMenuItem.Text = "Imprimir Cartas"
        '
        'ImprimirSobresToolStripMenuItem
        '
        Me.ImprimirSobresToolStripMenuItem.Name = "ImprimirSobresToolStripMenuItem"
        Me.ImprimirSobresToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.ImprimirSobresToolStripMenuItem.Text = "Imprimir Sobres Por Efectivo"
        '
        'AguinaldoYVacacionesPorNaveToolStripMenuItem
        '
        Me.AguinaldoYVacacionesPorNaveToolStripMenuItem.Name = "AguinaldoYVacacionesPorNaveToolStripMenuItem"
        Me.AguinaldoYVacacionesPorNaveToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.AguinaldoYVacacionesPorNaveToolStripMenuItem.Text = "Resumen Aguinaldo y Vacaciones "
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdRealesFiscales)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 166)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1117, 288)
        Me.Panel2.TabIndex = 61
        '
        'grdRealesFiscales
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdRealesFiscales.DisplayLayout.Appearance = Appearance1
        Me.grdRealesFiscales.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdRealesFiscales.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdRealesFiscales.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdRealesFiscales.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdRealesFiscales.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdRealesFiscales.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdRealesFiscales.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdRealesFiscales.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdRealesFiscales.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdRealesFiscales.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdRealesFiscales.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdRealesFiscales.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdRealesFiscales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdRealesFiscales.Location = New System.Drawing.Point(0, 0)
        Me.grdRealesFiscales.Name = "grdRealesFiscales"
        Me.grdRealesFiscales.Size = New System.Drawing.Size(1117, 288)
        Me.grdRealesFiscales.TabIndex = 61
        '
        'AguinaldoVacacionesRealesFiscales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1117, 533)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlBanner)
        Me.Name = "AguinaldoVacacionesRealesFiscales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aguinaldos y Vacaciones R y F"
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.PerformLayout()
        Me.pnlBanner.ResumeLayout(False)
        Me.pnlBanner.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.menuImprimir.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdRealesFiscales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents pnlBanner As System.Windows.Forms.Panel
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents lblSeleccion As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnImpCod As System.Windows.Forms.Button
    Friend WithEvents lblImportar As System.Windows.Forms.Label
    Friend WithEvents menuImprimir As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AguinaldosYVacacionesRealesYFiscalesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirCartasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirSobresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnExcluidos As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grdRealesFiscales As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblExternos As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTotEfectivo As System.Windows.Forms.Label
    Friend WithEvents lblAV As System.Windows.Forms.Label
    Friend WithEvents lblInternos As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnExcluidos2 As Button
    Friend WithEvents AguinaldoYVacacionesPorNaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblExterno As Label
    Friend WithEvents btnExterno As Button
    Friend WithEvents cmbNave As ComboBox
    Friend WithEvents cmbAño As ComboBox
    Friend WithEvents lblcolaborador As Label
    Friend WithEvents txtColaborador As TextBox
    Friend WithEvents pcbTitulo As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbPeriodo As ComboBox
End Class
