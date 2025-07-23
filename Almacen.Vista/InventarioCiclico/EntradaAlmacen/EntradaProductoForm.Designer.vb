<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EntradaProductoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EntradaProductoForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.grdIncorrecto = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grdLectura = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblTotalIngresados = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lblLotesDescartados = New System.Windows.Forms.Label()
        Me.lblAtadosDescartados = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblLotesCorrectos = New System.Windows.Forms.Label()
        Me.lblAtadosCorrectos = New System.Windows.Forms.Label()
        Me.lblParesCorrectos = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblLotesLeidos = New System.Windows.Forms.Label()
        Me.lblAtadosLeidos = New System.Windows.Forms.Label()
        Me.lblParesLeidos = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdIncorrecto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdLectura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.btnMostrar)
        Me.pnlEncabezado.Controls.Add(Me.lblBuscar)
        Me.pnlEncabezado.Controls.Add(Me.Label6)
        Me.pnlEncabezado.Controls.Add(Me.Button2)
        Me.pnlEncabezado.Controls.Add(Me.Panel3)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(914, 70)
        Me.pnlEncabezado.TabIndex = 46
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(8, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "Terminal"
        '
        'Button2
        '
        Me.Button2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2.Location = New System.Drawing.Point(15, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 61
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(528, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(386, 70)
        Me.Panel3.TabIndex = 45
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label10.Location = New System.Drawing.Point(48, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(264, 20)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Entrada de Producto Terminado"
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(318, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(68, 70)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 45
        Me.PictureBox2.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(237, 95)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(99, 13)
        Me.Label28.TabIndex = 89
        Me.Label28.Text = "Captura de códigos"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(342, 92)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(162, 20)
        Me.TextBox1.TabIndex = 88
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(43, 91)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(164, 21)
        Me.ComboBox1.TabIndex = 86
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 92)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 13)
        Me.Label13.TabIndex = 84
        Me.Label13.Text = "Nave"
        '
        'grdIncorrecto
        '
        Me.grdIncorrecto.Location = New System.Drawing.Point(453, 131)
        Me.grdIncorrecto.Name = "grdIncorrecto"
        Me.grdIncorrecto.Size = New System.Drawing.Size(458, 391)
        Me.grdIncorrecto.TabIndex = 83
        '
        'grdLectura
        '
        Me.grdLectura.Location = New System.Drawing.Point(4, 131)
        Me.grdLectura.Name = "grdLectura"
        Me.grdLectura.Size = New System.Drawing.Size(443, 391)
        Me.grdLectura.TabIndex = 82
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(490, 565)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(14, 13)
        Me.Label15.TabIndex = 116
        Me.Label15.Text = "1"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(490, 545)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(14, 13)
        Me.Label16.TabIndex = 115
        Me.Label16.Text = "4"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(490, 525)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(14, 13)
        Me.Label17.TabIndex = 114
        Me.Label17.Text = "4"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(380, 564)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 13)
        Me.Label18.TabIndex = 113
        Me.Label18.Text = "Lotes incorrectos"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(380, 545)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(95, 13)
        Me.Label22.TabIndex = 112
        Me.Label22.Text = "Atados incorrectos"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(380, 525)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(89, 13)
        Me.Label23.TabIndex = 111
        Me.Label23.Text = "Pares incorrectos"
        '
        'lblTotalIngresados
        '
        Me.lblTotalIngresados.AutoSize = True
        Me.lblTotalIngresados.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalIngresados.ForeColor = System.Drawing.Color.Red
        Me.lblTotalIngresados.Location = New System.Drawing.Point(138, 534)
        Me.lblTotalIngresados.Name = "lblTotalIngresados"
        Me.lblTotalIngresados.Size = New System.Drawing.Size(76, 29)
        Me.lblTotalIngresados.TabIndex = 110
        Me.lblTotalIngresados.Text = "1,538"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(4, 543)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(134, 17)
        Me.Label29.TabIndex = 109
        Me.Label29.Text = "Pares  a Ingresar"
        '
        'lblLotesDescartados
        '
        Me.lblLotesDescartados.AutoSize = True
        Me.lblLotesDescartados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotesDescartados.Location = New System.Drawing.Point(655, 565)
        Me.lblLotesDescartados.Name = "lblLotesDescartados"
        Me.lblLotesDescartados.Size = New System.Drawing.Size(14, 13)
        Me.lblLotesDescartados.TabIndex = 108
        Me.lblLotesDescartados.Text = "1"
        '
        'lblAtadosDescartados
        '
        Me.lblAtadosDescartados.AutoSize = True
        Me.lblAtadosDescartados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtadosDescartados.Location = New System.Drawing.Point(655, 546)
        Me.lblAtadosDescartados.Name = "lblAtadosDescartados"
        Me.lblAtadosDescartados.Size = New System.Drawing.Size(14, 13)
        Me.lblAtadosDescartados.TabIndex = 107
        Me.lblAtadosDescartados.Text = "8"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(648, 526)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(21, 13)
        Me.Label24.TabIndex = 106
        Me.Label24.Text = "48"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(543, 565)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(96, 13)
        Me.Label25.TabIndex = 105
        Me.Label25.Text = "Lotes Descartados"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(543, 546)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(103, 13)
        Me.Label26.TabIndex = 104
        Me.Label26.Text = "Atados Descartados"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(543, 526)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(97, 13)
        Me.Label27.TabIndex = 103
        Me.Label27.Text = "Pares Descartados"
        '
        'lblLotesCorrectos
        '
        Me.lblLotesCorrectos.AutoSize = True
        Me.lblLotesCorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotesCorrectos.Location = New System.Drawing.Point(856, 564)
        Me.lblLotesCorrectos.Name = "lblLotesCorrectos"
        Me.lblLotesCorrectos.Size = New System.Drawing.Size(21, 13)
        Me.lblLotesCorrectos.TabIndex = 102
        Me.lblLotesCorrectos.Text = "32"
        '
        'lblAtadosCorrectos
        '
        Me.lblAtadosCorrectos.AutoSize = True
        Me.lblAtadosCorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtadosCorrectos.Location = New System.Drawing.Point(850, 545)
        Me.lblAtadosCorrectos.Name = "lblAtadosCorrectos"
        Me.lblAtadosCorrectos.Size = New System.Drawing.Size(28, 13)
        Me.lblAtadosCorrectos.TabIndex = 101
        Me.lblAtadosCorrectos.Text = "250"
        '
        'lblParesCorrectos
        '
        Me.lblParesCorrectos.AutoSize = True
        Me.lblParesCorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesCorrectos.Location = New System.Drawing.Point(839, 525)
        Me.lblParesCorrectos.Name = "lblParesCorrectos"
        Me.lblParesCorrectos.Size = New System.Drawing.Size(39, 13)
        Me.lblParesCorrectos.TabIndex = 100
        Me.lblParesCorrectos.Text = "1,538"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(718, 564)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(81, 13)
        Me.Label19.TabIndex = 99
        Me.Label19.Text = "Lotes Correctos"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(718, 545)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(88, 13)
        Me.Label20.TabIndex = 98
        Me.Label20.Text = "Atados Correctos"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(718, 525)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(82, 13)
        Me.Label21.TabIndex = 97
        Me.Label21.Text = "Pares Correctos"
        '
        'lblLotesLeidos
        '
        Me.lblLotesLeidos.AutoSize = True
        Me.lblLotesLeidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotesLeidos.Location = New System.Drawing.Point(324, 565)
        Me.lblLotesLeidos.Name = "lblLotesLeidos"
        Me.lblLotesLeidos.Size = New System.Drawing.Size(21, 13)
        Me.lblLotesLeidos.TabIndex = 96
        Me.lblLotesLeidos.Text = "33"
        '
        'lblAtadosLeidos
        '
        Me.lblAtadosLeidos.AutoSize = True
        Me.lblAtadosLeidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtadosLeidos.Location = New System.Drawing.Point(317, 546)
        Me.lblAtadosLeidos.Name = "lblAtadosLeidos"
        Me.lblAtadosLeidos.Size = New System.Drawing.Size(28, 13)
        Me.lblAtadosLeidos.TabIndex = 95
        Me.lblAtadosLeidos.Text = "251"
        '
        'lblParesLeidos
        '
        Me.lblParesLeidos.AutoSize = True
        Me.lblParesLeidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesLeidos.Location = New System.Drawing.Point(306, 526)
        Me.lblParesLeidos.Name = "lblParesLeidos"
        Me.lblParesLeidos.Size = New System.Drawing.Size(39, 13)
        Me.lblParesLeidos.TabIndex = 94
        Me.lblParesLeidos.Text = "1,586"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(226, 565)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 13)
        Me.Label12.TabIndex = 93
        Me.Label12.Text = "Lotes Leidos"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(226, 546)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 13)
        Me.Label11.TabIndex = 92
        Me.Label11.Text = "Atados Leidos"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(226, 526)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 91
        Me.Label9.Text = "Pares Leidos"
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.Label7)
        Me.pnlEstado.Controls.Add(Me.Label8)
        Me.pnlEstado.Controls.Add(Me.Label4)
        Me.pnlEstado.Controls.Add(Me.Label5)
        Me.pnlEstado.Controls.Add(Me.Label2)
        Me.pnlEstado.Controls.Add(Me.Label3)
        Me.pnlEstado.Controls.Add(Me.pnlAcciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 583)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(914, 60)
        Me.pnlEstado.TabIndex = 90
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Orange
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.ForeColor = System.Drawing.Color.Orange
        Me.Label7.Location = New System.Drawing.Point(295, 26)
        Me.Label7.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 15)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "___"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(318, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Lote sin terminar"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Yellow
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label4.Location = New System.Drawing.Point(159, 26)
        Me.Label4.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 15)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "___"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(182, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Atado incompleto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Salmon
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.ForeColor = System.Drawing.Color.Salmon
        Me.Label2.Location = New System.Drawing.Point(18, 26)
        Me.Label2.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "___"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(40, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Atado mal formado"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.Label1)
        Me.pnlAcciones.Controls.Add(Me.Button1)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnCncelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(732, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(182, 60)
        Me.pnlAcciones.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(79, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Salir"
        '
        'Button1
        '
        Me.Button1.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.Button1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1.Location = New System.Drawing.Point(75, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 61
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(133, 38)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(45, 13)
        Me.lblCancelar.TabIndex = 60
        Me.lblCancelar.Text = "Guardar"
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = Global.Almacen.Vista.My.Resources.Resources.guardar2_32
        Me.btnCncelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCncelar.Location = New System.Drawing.Point(138, 7)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 59
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.BackgroundImage = Global.Almacen.Vista.My.Resources.Resources.imprimir_32
        Me.btnMostrar.Location = New System.Drawing.Point(68, 12)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 63
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(64, 46)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 64
        Me.lblBuscar.Text = "Imprimir"
        '
        'EntradaProductoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(914, 643)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.lblTotalIngresados)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.lblLotesDescartados)
        Me.Controls.Add(Me.lblAtadosDescartados)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.lblLotesCorrectos)
        Me.Controls.Add(Me.lblAtadosCorrectos)
        Me.Controls.Add(Me.lblParesCorrectos)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.lblLotesLeidos)
        Me.Controls.Add(Me.lblAtadosLeidos)
        Me.Controls.Add(Me.lblParesLeidos)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.grdIncorrecto)
        Me.Controls.Add(Me.grdLectura)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "EntradaProductoForm"
        Me.Text = "Entrada de Producto Terminado"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdIncorrecto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdLectura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents grdIncorrecto As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdLectura As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblTotalIngresados As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lblLotesDescartados As System.Windows.Forms.Label
    Friend WithEvents lblAtadosDescartados As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblLotesCorrectos As System.Windows.Forms.Label
    Friend WithEvents lblAtadosCorrectos As System.Windows.Forms.Label
    Friend WithEvents lblParesCorrectos As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblLotesLeidos As System.Windows.Forms.Label
    Friend WithEvents lblAtadosLeidos As System.Windows.Forms.Label
    Friend WithEvents lblParesLeidos As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCncelar As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
End Class
