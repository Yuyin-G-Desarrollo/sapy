<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaConfigProduccionBandaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaConfigProduccionBandaForm))
        Me.grbPatrones = New System.Windows.Forms.GroupBox()
        Me.cmbDepartamentos = New System.Windows.Forms.ComboBox()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.txtParChoclo1 = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtParMediaBota1 = New System.Windows.Forms.TextBox()
        Me.txtParBotin1 = New System.Windows.Forms.TextBox()
        Me.txtParBotaAlta1 = New System.Windows.Forms.TextBox()
        Me.txtparsandalia1 = New System.Windows.Forms.TextBox()
        Me.cmbCelula = New System.Windows.Forms.ComboBox()
        Me.cmbPeriodo = New System.Windows.Forms.ComboBox()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblTotalSAY = New System.Windows.Forms.Label()
        Me.txtTotalSAY = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.txtCostoBotaAlta = New System.Windows.Forms.TextBox()
        Me.lblCostoBotaAlta = New System.Windows.Forms.Label()
        Me.lblParBotaAlta = New System.Windows.Forms.Label()
        Me.txtCostoBotin = New System.Windows.Forms.TextBox()
        Me.lblCostoBotin = New System.Windows.Forms.Label()
        Me.lblParBotin = New System.Windows.Forms.Label()
        Me.txtCostoMediaBota = New System.Windows.Forms.TextBox()
        Me.lblCostoMediaBota = New System.Windows.Forms.Label()
        Me.lblParMediaBota = New System.Windows.Forms.Label()
        Me.txtCostoChoclo = New System.Windows.Forms.TextBox()
        Me.lblCostoChoclo = New System.Windows.Forms.Label()
        Me.lblParChoclo = New System.Windows.Forms.Label()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.txtCostoSandalia = New System.Windows.Forms.TextBox()
        Me.lblCostoSandalia = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.lblParSandalia = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblListaPatrones = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.grbPatrones.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbPatrones
        '
        Me.grbPatrones.Controls.Add(Me.cmbDepartamentos)
        Me.grbPatrones.Controls.Add(Me.lblDepartamento)
        Me.grbPatrones.Controls.Add(Me.txtParChoclo1)
        Me.grbPatrones.Controls.Add(Me.txtTotal)
        Me.grbPatrones.Controls.Add(Me.txtParMediaBota1)
        Me.grbPatrones.Controls.Add(Me.txtParBotin1)
        Me.grbPatrones.Controls.Add(Me.txtParBotaAlta1)
        Me.grbPatrones.Controls.Add(Me.txtparsandalia1)
        Me.grbPatrones.Controls.Add(Me.cmbCelula)
        Me.grbPatrones.Controls.Add(Me.cmbPeriodo)
        Me.grbPatrones.Controls.Add(Me.cmbNave)
        Me.grbPatrones.Controls.Add(Me.lblTotalSAY)
        Me.grbPatrones.Controls.Add(Me.txtTotalSAY)
        Me.grbPatrones.Controls.Add(Me.lblTotal)
        Me.grbPatrones.Controls.Add(Me.txtCostoBotaAlta)
        Me.grbPatrones.Controls.Add(Me.lblCostoBotaAlta)
        Me.grbPatrones.Controls.Add(Me.lblParBotaAlta)
        Me.grbPatrones.Controls.Add(Me.txtCostoBotin)
        Me.grbPatrones.Controls.Add(Me.lblCostoBotin)
        Me.grbPatrones.Controls.Add(Me.lblParBotin)
        Me.grbPatrones.Controls.Add(Me.txtCostoMediaBota)
        Me.grbPatrones.Controls.Add(Me.lblCostoMediaBota)
        Me.grbPatrones.Controls.Add(Me.lblParMediaBota)
        Me.grbPatrones.Controls.Add(Me.txtCostoChoclo)
        Me.grbPatrones.Controls.Add(Me.lblCostoChoclo)
        Me.grbPatrones.Controls.Add(Me.lblParChoclo)
        Me.grbPatrones.Controls.Add(Me.lblCelula)
        Me.grbPatrones.Controls.Add(Me.txtCostoSandalia)
        Me.grbPatrones.Controls.Add(Me.lblCostoSandalia)
        Me.grbPatrones.Controls.Add(Me.lblNave)
        Me.grbPatrones.Controls.Add(Me.lblPeriodo)
        Me.grbPatrones.Controls.Add(Me.lblParSandalia)
        Me.grbPatrones.Location = New System.Drawing.Point(12, 65)
        Me.grbPatrones.Name = "grbPatrones"
        Me.grbPatrones.Size = New System.Drawing.Size(527, 373)
        Me.grbPatrones.TabIndex = 49
        Me.grbPatrones.TabStop = False
        '
        'cmbDepartamentos
        '
        Me.cmbDepartamentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamentos.ForeColor = System.Drawing.Color.Black
        Me.cmbDepartamentos.FormattingEnabled = True
        Me.cmbDepartamentos.Location = New System.Drawing.Point(116, 73)
        Me.cmbDepartamentos.Name = "cmbDepartamentos"
        Me.cmbDepartamentos.Size = New System.Drawing.Size(374, 21)
        Me.cmbDepartamentos.TabIndex = 84
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(14, 76)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(78, 13)
        Me.lblDepartamento.TabIndex = 85
        Me.lblDepartamento.Text = "*Departamento"
        '
        'txtParChoclo1
        '
        Me.txtParChoclo1.Location = New System.Drawing.Point(115, 168)
        Me.txtParChoclo1.MaxLength = 5
        Me.txtParChoclo1.Name = "txtParChoclo1"
        Me.txtParChoclo1.Size = New System.Drawing.Size(154, 20)
        Me.txtParChoclo1.TabIndex = 6
        Me.txtParChoclo1.Text = "0"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(116, 296)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(129, 20)
        Me.txtTotal.TabIndex = 14
        Me.txtTotal.Text = "0"
        '
        'txtParMediaBota1
        '
        Me.txtParMediaBota1.Location = New System.Drawing.Point(115, 194)
        Me.txtParMediaBota1.MaxLength = 5
        Me.txtParMediaBota1.Name = "txtParMediaBota1"
        Me.txtParMediaBota1.Size = New System.Drawing.Size(154, 20)
        Me.txtParMediaBota1.TabIndex = 8
        Me.txtParMediaBota1.Text = "0"
        '
        'txtParBotin1
        '
        Me.txtParBotin1.Location = New System.Drawing.Point(115, 221)
        Me.txtParBotin1.MaxLength = 5
        Me.txtParBotin1.Name = "txtParBotin1"
        Me.txtParBotin1.Size = New System.Drawing.Size(154, 20)
        Me.txtParBotin1.TabIndex = 10
        Me.txtParBotin1.Text = "0"
        '
        'txtParBotaAlta1
        '
        Me.txtParBotaAlta1.Location = New System.Drawing.Point(115, 246)
        Me.txtParBotaAlta1.MaxLength = 5
        Me.txtParBotaAlta1.Name = "txtParBotaAlta1"
        Me.txtParBotaAlta1.Size = New System.Drawing.Size(154, 20)
        Me.txtParBotaAlta1.TabIndex = 12
        Me.txtParBotaAlta1.Text = "0"
        '
        'txtparsandalia1
        '
        Me.txtparsandalia1.Location = New System.Drawing.Point(115, 142)
        Me.txtparsandalia1.MaxLength = 5
        Me.txtparsandalia1.Name = "txtparsandalia1"
        Me.txtparsandalia1.Size = New System.Drawing.Size(154, 20)
        Me.txtparsandalia1.TabIndex = 4
        Me.txtparsandalia1.Text = "0"
        '
        'cmbCelula
        '
        Me.cmbCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCelula.ForeColor = System.Drawing.Color.Black
        Me.cmbCelula.FormattingEnabled = True
        Me.cmbCelula.Location = New System.Drawing.Point(117, 100)
        Me.cmbCelula.Name = "cmbCelula"
        Me.cmbCelula.Size = New System.Drawing.Size(373, 21)
        Me.cmbCelula.TabIndex = 3
        '
        'cmbPeriodo
        '
        Me.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodo.ForeColor = System.Drawing.Color.Black
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.Location = New System.Drawing.Point(115, 46)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(374, 21)
        Me.cmbPeriodo.TabIndex = 2
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(115, 19)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(374, 21)
        Me.cmbNave.TabIndex = 1
        '
        'lblTotalSAY
        '
        Me.lblTotalSAY.AutoSize = True
        Me.lblTotalSAY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSAY.Location = New System.Drawing.Point(46, 325)
        Me.lblTotalSAY.Name = "lblTotalSAY"
        Me.lblTotalSAY.Size = New System.Drawing.Size(64, 13)
        Me.lblTotalSAY.TabIndex = 83
        Me.lblTotalSAY.Text = "Total SAY"
        '
        'txtTotalSAY
        '
        Me.txtTotalSAY.CausesValidation = False
        Me.txtTotalSAY.Location = New System.Drawing.Point(116, 322)
        Me.txtTotalSAY.MaxLength = 50
        Me.txtTotalSAY.Name = "txtTotalSAY"
        Me.txtTotalSAY.ReadOnly = True
        Me.txtTotalSAY.ShortcutsEnabled = False
        Me.txtTotalSAY.Size = New System.Drawing.Size(129, 20)
        Me.txtTotalSAY.TabIndex = 15
        Me.txtTotalSAY.Text = "0"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(46, 299)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(36, 13)
        Me.lblTotal.TabIndex = 81
        Me.lblTotal.Text = "Total"
        '
        'txtCostoBotaAlta
        '
        Me.txtCostoBotaAlta.Location = New System.Drawing.Point(370, 247)
        Me.txtCostoBotaAlta.MaxLength = 50
        Me.txtCostoBotaAlta.Name = "txtCostoBotaAlta"
        Me.txtCostoBotaAlta.ShortcutsEnabled = False
        Me.txtCostoBotaAlta.Size = New System.Drawing.Size(119, 20)
        Me.txtCostoBotaAlta.TabIndex = 13
        Me.txtCostoBotaAlta.Text = "00.00"
        '
        'lblCostoBotaAlta
        '
        Me.lblCostoBotaAlta.AutoSize = True
        Me.lblCostoBotaAlta.Location = New System.Drawing.Point(286, 250)
        Me.lblCostoBotaAlta.Name = "lblCostoBotaAlta"
        Me.lblCostoBotaAlta.Size = New System.Drawing.Size(76, 13)
        Me.lblCostoBotaAlta.TabIndex = 78
        Me.lblCostoBotaAlta.Text = "*Costo Por Par"
        '
        'lblParBotaAlta
        '
        Me.lblParBotaAlta.AutoSize = True
        Me.lblParBotaAlta.Location = New System.Drawing.Point(13, 250)
        Me.lblParBotaAlta.Name = "lblParBotaAlta"
        Me.lblParBotaAlta.Size = New System.Drawing.Size(84, 13)
        Me.lblParBotaAlta.TabIndex = 77
        Me.lblParBotaAlta.Text = "*Pares Bota Alta"
        '
        'txtCostoBotin
        '
        Me.txtCostoBotin.Location = New System.Drawing.Point(370, 221)
        Me.txtCostoBotin.MaxLength = 50
        Me.txtCostoBotin.Name = "txtCostoBotin"
        Me.txtCostoBotin.ShortcutsEnabled = False
        Me.txtCostoBotin.Size = New System.Drawing.Size(119, 20)
        Me.txtCostoBotin.TabIndex = 11
        Me.txtCostoBotin.Text = "00.00"
        '
        'lblCostoBotin
        '
        Me.lblCostoBotin.AutoSize = True
        Me.lblCostoBotin.Location = New System.Drawing.Point(286, 224)
        Me.lblCostoBotin.Name = "lblCostoBotin"
        Me.lblCostoBotin.Size = New System.Drawing.Size(76, 13)
        Me.lblCostoBotin.TabIndex = 74
        Me.lblCostoBotin.Text = "*Costo Por Par"
        '
        'lblParBotin
        '
        Me.lblParBotin.AutoSize = True
        Me.lblParBotin.Location = New System.Drawing.Point(13, 228)
        Me.lblParBotin.Name = "lblParBotin"
        Me.lblParBotin.Size = New System.Drawing.Size(65, 13)
        Me.lblParBotin.TabIndex = 73
        Me.lblParBotin.Text = "*Pares Botin"
        '
        'txtCostoMediaBota
        '
        Me.txtCostoMediaBota.Location = New System.Drawing.Point(370, 195)
        Me.txtCostoMediaBota.MaxLength = 50
        Me.txtCostoMediaBota.Name = "txtCostoMediaBota"
        Me.txtCostoMediaBota.ShortcutsEnabled = False
        Me.txtCostoMediaBota.Size = New System.Drawing.Size(119, 20)
        Me.txtCostoMediaBota.TabIndex = 9
        Me.txtCostoMediaBota.Text = "00.00"
        '
        'lblCostoMediaBota
        '
        Me.lblCostoMediaBota.AutoSize = True
        Me.lblCostoMediaBota.Location = New System.Drawing.Point(286, 198)
        Me.lblCostoMediaBota.Name = "lblCostoMediaBota"
        Me.lblCostoMediaBota.Size = New System.Drawing.Size(76, 13)
        Me.lblCostoMediaBota.TabIndex = 70
        Me.lblCostoMediaBota.Text = "*Costo Por Par"
        '
        'lblParMediaBota
        '
        Me.lblParMediaBota.AutoSize = True
        Me.lblParMediaBota.Location = New System.Drawing.Point(13, 198)
        Me.lblParMediaBota.Name = "lblParMediaBota"
        Me.lblParMediaBota.Size = New System.Drawing.Size(94, 13)
        Me.lblParMediaBota.TabIndex = 69
        Me.lblParMediaBota.Text = "*Pares Media bota"
        '
        'txtCostoChoclo
        '
        Me.txtCostoChoclo.Location = New System.Drawing.Point(370, 169)
        Me.txtCostoChoclo.MaxLength = 50
        Me.txtCostoChoclo.Name = "txtCostoChoclo"
        Me.txtCostoChoclo.ShortcutsEnabled = False
        Me.txtCostoChoclo.Size = New System.Drawing.Size(119, 20)
        Me.txtCostoChoclo.TabIndex = 7
        Me.txtCostoChoclo.Text = "00.00"
        '
        'lblCostoChoclo
        '
        Me.lblCostoChoclo.AutoSize = True
        Me.lblCostoChoclo.Location = New System.Drawing.Point(286, 172)
        Me.lblCostoChoclo.Name = "lblCostoChoclo"
        Me.lblCostoChoclo.Size = New System.Drawing.Size(76, 13)
        Me.lblCostoChoclo.TabIndex = 66
        Me.lblCostoChoclo.Text = "*Costo Por Par"
        '
        'lblParChoclo
        '
        Me.lblParChoclo.AutoSize = True
        Me.lblParChoclo.Location = New System.Drawing.Point(13, 172)
        Me.lblParChoclo.Name = "lblParChoclo"
        Me.lblParChoclo.Size = New System.Drawing.Size(74, 13)
        Me.lblParChoclo.TabIndex = 65
        Me.lblParChoclo.Text = "*Pares Choclo"
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Location = New System.Drawing.Point(14, 103)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(40, 13)
        Me.lblCelula.TabIndex = 63
        Me.lblCelula.Text = "*Célula"
        '
        'txtCostoSandalia
        '
        Me.txtCostoSandalia.Location = New System.Drawing.Point(370, 143)
        Me.txtCostoSandalia.MaxLength = 50
        Me.txtCostoSandalia.Name = "txtCostoSandalia"
        Me.txtCostoSandalia.ShortcutsEnabled = False
        Me.txtCostoSandalia.Size = New System.Drawing.Size(119, 20)
        Me.txtCostoSandalia.TabIndex = 5
        Me.txtCostoSandalia.Text = "00.00"
        '
        'lblCostoSandalia
        '
        Me.lblCostoSandalia.AutoSize = True
        Me.lblCostoSandalia.Location = New System.Drawing.Point(286, 146)
        Me.lblCostoSandalia.Name = "lblCostoSandalia"
        Me.lblCostoSandalia.Size = New System.Drawing.Size(76, 13)
        Me.lblCostoSandalia.TabIndex = 60
        Me.lblCostoSandalia.Text = "*Costo Por Par"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(13, 22)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(37, 13)
        Me.lblNave.TabIndex = 43
        Me.lblNave.Text = "*Nave"
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Location = New System.Drawing.Point(13, 49)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(47, 13)
        Me.lblPeriodo.TabIndex = 40
        Me.lblPeriodo.Text = "*Periodo"
        '
        'lblParSandalia
        '
        Me.lblParSandalia.AutoSize = True
        Me.lblParSandalia.Location = New System.Drawing.Point(13, 146)
        Me.lblParSandalia.Name = "lblParSandalia"
        Me.lblParSandalia.Size = New System.Drawing.Size(82, 13)
        Me.lblParSandalia.TabIndex = 39
        Me.lblParSandalia.Text = "*Pares Sandalia"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pcbTitulo)
        Me.pnlEncabezado.Controls.Add(Me.lblListaPatrones)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(559, 59)
        Me.pnlEncabezado.TabIndex = 50
        '
        'lblListaPatrones
        '
        Me.lblListaPatrones.AutoSize = True
        Me.lblListaPatrones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaPatrones.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaPatrones.Location = New System.Drawing.Point(289, 20)
        Me.lblListaPatrones.Name = "lblListaPatrones"
        Me.lblListaPatrones.Size = New System.Drawing.Size(186, 20)
        Me.lblListaPatrones.TabIndex = 23
        Me.lblListaPatrones.Text = "Producción por Banda"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(507, 479)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 54
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(448, 479)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 53
        Me.lblGuardar.Text = "Guardar"
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCncelar.Location = New System.Drawing.Point(507, 444)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 17
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(453, 444)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 55
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(491, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 30
        Me.pcbTitulo.TabStop = False
        '
        'AltaConfigProduccionBandaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(559, 520)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.lblCancelar)
        Me.Controls.Add(Me.lblGuardar)
        Me.Controls.Add(Me.btnCncelar)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.grbPatrones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(565, 542)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(565, 542)
        Me.Name = "AltaConfigProduccionBandaForm"
        Me.Text = "Producción por Banda"
        Me.grbPatrones.ResumeLayout(False)
        Me.grbPatrones.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbPatrones As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotalSAY As System.Windows.Forms.Label
    Friend WithEvents txtTotalSAY As System.Windows.Forms.TextBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents txtCostoBotaAlta As System.Windows.Forms.TextBox
    Friend WithEvents lblCostoBotaAlta As System.Windows.Forms.Label
    Friend WithEvents lblParBotaAlta As System.Windows.Forms.Label
    Friend WithEvents txtCostoBotin As System.Windows.Forms.TextBox
    Friend WithEvents lblCostoBotin As System.Windows.Forms.Label
    Friend WithEvents lblParBotin As System.Windows.Forms.Label
    Friend WithEvents txtCostoMediaBota As System.Windows.Forms.TextBox
    Friend WithEvents lblCostoMediaBota As System.Windows.Forms.Label
    Friend WithEvents lblParMediaBota As System.Windows.Forms.Label
    Friend WithEvents txtCostoChoclo As System.Windows.Forms.TextBox
    Friend WithEvents lblCostoChoclo As System.Windows.Forms.Label
    Friend WithEvents lblParChoclo As System.Windows.Forms.Label
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents txtCostoSandalia As System.Windows.Forms.TextBox
    Friend WithEvents lblCostoSandalia As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents lblParSandalia As System.Windows.Forms.Label
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblListaPatrones As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnCncelar As System.Windows.Forms.Button
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCelula As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents txtParChoclo1 As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtParMediaBota1 As System.Windows.Forms.TextBox
    Friend WithEvents txtParBotin1 As System.Windows.Forms.TextBox
    Friend WithEvents txtParBotaAlta1 As System.Windows.Forms.TextBox
    Friend WithEvents txtparsandalia1 As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cmbDepartamentos As System.Windows.Forms.ComboBox
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As PictureBox
End Class
