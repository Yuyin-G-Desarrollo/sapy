<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalidaNavesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalidaNavesForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnLeerArchivo = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
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
        Me.lblparesleidotitulo = New System.Windows.Forms.Label()
        Me.lblatadosleidostitulos = New System.Windows.Forms.Label()
        Me.lbllotesleidostitulo = New System.Windows.Forms.Label()
        Me.lblLotesLeidos = New System.Windows.Forms.Label()
        Me.lblAtadosLeidos = New System.Windows.Forms.Label()
        Me.lblParesLeidos = New System.Windows.Forms.Label()
        Me.lblLotesCorrectos = New System.Windows.Forms.Label()
        Me.lblAtadosCorrectos = New System.Windows.Forms.Label()
        Me.lblParesCorrectos = New System.Windows.Forms.Label()
        Me.lblLotesCorrectosTitulo = New System.Windows.Forms.Label()
        Me.lblAtadosCorrectosTitulo = New System.Windows.Forms.Label()
        Me.lblParesCorrectosTitulo = New System.Windows.Forms.Label()
        Me.lblLotesDescardatos = New System.Windows.Forms.Label()
        Me.lblAtadosDescartados = New System.Windows.Forms.Label()
        Me.lblParesDescartados = New System.Windows.Forms.Label()
        Me.lblLotesDescartadosTitulo = New System.Windows.Forms.Label()
        Me.lblAtadosDescartadosTitulo = New System.Windows.Forms.Label()
        Me.lblParesDescartadostitulo = New System.Windows.Forms.Label()
        Me.lblparesembarcar = New System.Windows.Forms.Label()
        Me.lblTotalIngresados = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblOperador = New System.Windows.Forms.Label()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.cmbOperador = New System.Windows.Forms.ComboBox()
        Me.lblLotesIncorrectos = New System.Windows.Forms.Label()
        Me.lblAtadosIncorrectos = New System.Windows.Forms.Label()
        Me.lblParesIncorrectos = New System.Windows.Forms.Label()
        Me.lblLotesIncorrectosTitulo = New System.Windows.Forms.Label()
        Me.lblAtadosIncorrectoTitulo = New System.Windows.Forms.Label()
        Me.lblParesIncorrectosTitilo = New System.Windows.Forms.Label()
        Me.txtcapturacodigos = New System.Windows.Forms.TextBox()
        Me.lblCodigos = New System.Windows.Forms.Label()
        Me.opnArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.grdLectura = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grdIncorrecto = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.grdLectura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdIncorrecto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.Label6)
        Me.pnlEncabezado.Controls.Add(Me.btnLeerArchivo)
        Me.pnlEncabezado.Controls.Add(Me.Panel3)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1354, 70)
        Me.pnlEncabezado.TabIndex = 45
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
        'btnLeerArchivo
        '
        Me.btnLeerArchivo.Enabled = False
        Me.btnLeerArchivo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLeerArchivo.Location = New System.Drawing.Point(15, 12)
        Me.btnLeerArchivo.Name = "btnLeerArchivo"
        Me.btnLeerArchivo.Size = New System.Drawing.Size(32, 32)
        Me.btnLeerArchivo.TabIndex = 61
        Me.btnLeerArchivo.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(968, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(386, 70)
        Me.Panel3.TabIndex = 45
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label10.Location = New System.Drawing.Point(178, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(134, 20)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Salida de Lotes"
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
        Me.pnlEstado.Location = New System.Drawing.Point(0, 584)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1354, 52)
        Me.pnlEstado.TabIndex = 46
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
        Me.Label4.Location = New System.Drawing.Point(165, 26)
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
        Me.Label5.Location = New System.Drawing.Point(188, 27)
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
        Me.pnlAcciones.Location = New System.Drawing.Point(1172, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(182, 52)
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
        'lblparesleidotitulo
        '
        Me.lblparesleidotitulo.AutoSize = True
        Me.lblparesleidotitulo.Location = New System.Drawing.Point(247, 529)
        Me.lblparesleidotitulo.Name = "lblparesleidotitulo"
        Me.lblparesleidotitulo.Size = New System.Drawing.Size(68, 13)
        Me.lblparesleidotitulo.TabIndex = 50
        Me.lblparesleidotitulo.Text = "Pares Leidos"
        '
        'lblatadosleidostitulos
        '
        Me.lblatadosleidostitulos.AutoSize = True
        Me.lblatadosleidostitulos.Location = New System.Drawing.Point(247, 549)
        Me.lblatadosleidostitulos.Name = "lblatadosleidostitulos"
        Me.lblatadosleidostitulos.Size = New System.Drawing.Size(74, 13)
        Me.lblatadosleidostitulos.TabIndex = 51
        Me.lblatadosleidostitulos.Text = "Atados Leidos"
        '
        'lbllotesleidostitulo
        '
        Me.lbllotesleidostitulo.AutoSize = True
        Me.lbllotesleidostitulo.Location = New System.Drawing.Point(247, 568)
        Me.lbllotesleidostitulo.Name = "lbllotesleidostitulo"
        Me.lbllotesleidostitulo.Size = New System.Drawing.Size(67, 13)
        Me.lbllotesleidostitulo.TabIndex = 52
        Me.lbllotesleidostitulo.Text = "Lotes Leidos"
        '
        'lblLotesLeidos
        '
        Me.lblLotesLeidos.AutoSize = True
        Me.lblLotesLeidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotesLeidos.Location = New System.Drawing.Point(345, 568)
        Me.lblLotesLeidos.Name = "lblLotesLeidos"
        Me.lblLotesLeidos.Size = New System.Drawing.Size(14, 13)
        Me.lblLotesLeidos.TabIndex = 55
        Me.lblLotesLeidos.Text = "0"
        '
        'lblAtadosLeidos
        '
        Me.lblAtadosLeidos.AutoSize = True
        Me.lblAtadosLeidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtadosLeidos.Location = New System.Drawing.Point(338, 549)
        Me.lblAtadosLeidos.Name = "lblAtadosLeidos"
        Me.lblAtadosLeidos.Size = New System.Drawing.Size(14, 13)
        Me.lblAtadosLeidos.TabIndex = 54
        Me.lblAtadosLeidos.Text = "0"
        '
        'lblParesLeidos
        '
        Me.lblParesLeidos.AutoSize = True
        Me.lblParesLeidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesLeidos.Location = New System.Drawing.Point(327, 529)
        Me.lblParesLeidos.Name = "lblParesLeidos"
        Me.lblParesLeidos.Size = New System.Drawing.Size(14, 13)
        Me.lblParesLeidos.TabIndex = 53
        Me.lblParesLeidos.Text = "0"
        '
        'lblLotesCorrectos
        '
        Me.lblLotesCorrectos.AutoSize = True
        Me.lblLotesCorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotesCorrectos.Location = New System.Drawing.Point(877, 567)
        Me.lblLotesCorrectos.Name = "lblLotesCorrectos"
        Me.lblLotesCorrectos.Size = New System.Drawing.Size(14, 13)
        Me.lblLotesCorrectos.TabIndex = 61
        Me.lblLotesCorrectos.Text = "0"
        '
        'lblAtadosCorrectos
        '
        Me.lblAtadosCorrectos.AutoSize = True
        Me.lblAtadosCorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtadosCorrectos.Location = New System.Drawing.Point(871, 548)
        Me.lblAtadosCorrectos.Name = "lblAtadosCorrectos"
        Me.lblAtadosCorrectos.Size = New System.Drawing.Size(14, 13)
        Me.lblAtadosCorrectos.TabIndex = 60
        Me.lblAtadosCorrectos.Text = "0"
        '
        'lblParesCorrectos
        '
        Me.lblParesCorrectos.AutoSize = True
        Me.lblParesCorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesCorrectos.Location = New System.Drawing.Point(860, 528)
        Me.lblParesCorrectos.Name = "lblParesCorrectos"
        Me.lblParesCorrectos.Size = New System.Drawing.Size(14, 13)
        Me.lblParesCorrectos.TabIndex = 59
        Me.lblParesCorrectos.Text = "0"
        '
        'lblLotesCorrectosTitulo
        '
        Me.lblLotesCorrectosTitulo.AutoSize = True
        Me.lblLotesCorrectosTitulo.Location = New System.Drawing.Point(739, 567)
        Me.lblLotesCorrectosTitulo.Name = "lblLotesCorrectosTitulo"
        Me.lblLotesCorrectosTitulo.Size = New System.Drawing.Size(81, 13)
        Me.lblLotesCorrectosTitulo.TabIndex = 58
        Me.lblLotesCorrectosTitulo.Text = "Lotes Correctos"
        '
        'lblAtadosCorrectosTitulo
        '
        Me.lblAtadosCorrectosTitulo.AutoSize = True
        Me.lblAtadosCorrectosTitulo.Location = New System.Drawing.Point(739, 548)
        Me.lblAtadosCorrectosTitulo.Name = "lblAtadosCorrectosTitulo"
        Me.lblAtadosCorrectosTitulo.Size = New System.Drawing.Size(88, 13)
        Me.lblAtadosCorrectosTitulo.TabIndex = 57
        Me.lblAtadosCorrectosTitulo.Text = "Atados Correctos"
        '
        'lblParesCorrectosTitulo
        '
        Me.lblParesCorrectosTitulo.AutoSize = True
        Me.lblParesCorrectosTitulo.Location = New System.Drawing.Point(739, 528)
        Me.lblParesCorrectosTitulo.Name = "lblParesCorrectosTitulo"
        Me.lblParesCorrectosTitulo.Size = New System.Drawing.Size(82, 13)
        Me.lblParesCorrectosTitulo.TabIndex = 56
        Me.lblParesCorrectosTitulo.Text = "Pares Correctos"
        '
        'lblLotesDescardatos
        '
        Me.lblLotesDescardatos.AutoSize = True
        Me.lblLotesDescardatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotesDescardatos.Location = New System.Drawing.Point(676, 568)
        Me.lblLotesDescardatos.Name = "lblLotesDescardatos"
        Me.lblLotesDescardatos.Size = New System.Drawing.Size(14, 13)
        Me.lblLotesDescardatos.TabIndex = 67
        Me.lblLotesDescardatos.Text = "0"
        '
        'lblAtadosDescartados
        '
        Me.lblAtadosDescartados.AutoSize = True
        Me.lblAtadosDescartados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtadosDescartados.Location = New System.Drawing.Point(676, 549)
        Me.lblAtadosDescartados.Name = "lblAtadosDescartados"
        Me.lblAtadosDescartados.Size = New System.Drawing.Size(14, 13)
        Me.lblAtadosDescartados.TabIndex = 66
        Me.lblAtadosDescartados.Text = "0"
        '
        'lblParesDescartados
        '
        Me.lblParesDescartados.AutoSize = True
        Me.lblParesDescartados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesDescartados.Location = New System.Drawing.Point(669, 529)
        Me.lblParesDescartados.Name = "lblParesDescartados"
        Me.lblParesDescartados.Size = New System.Drawing.Size(14, 13)
        Me.lblParesDescartados.TabIndex = 65
        Me.lblParesDescartados.Text = "0"
        '
        'lblLotesDescartadosTitulo
        '
        Me.lblLotesDescartadosTitulo.AutoSize = True
        Me.lblLotesDescartadosTitulo.Location = New System.Drawing.Point(564, 568)
        Me.lblLotesDescartadosTitulo.Name = "lblLotesDescartadosTitulo"
        Me.lblLotesDescartadosTitulo.Size = New System.Drawing.Size(96, 13)
        Me.lblLotesDescartadosTitulo.TabIndex = 64
        Me.lblLotesDescartadosTitulo.Text = "Lotes Descartados"
        '
        'lblAtadosDescartadosTitulo
        '
        Me.lblAtadosDescartadosTitulo.AutoSize = True
        Me.lblAtadosDescartadosTitulo.Location = New System.Drawing.Point(564, 549)
        Me.lblAtadosDescartadosTitulo.Name = "lblAtadosDescartadosTitulo"
        Me.lblAtadosDescartadosTitulo.Size = New System.Drawing.Size(103, 13)
        Me.lblAtadosDescartadosTitulo.TabIndex = 63
        Me.lblAtadosDescartadosTitulo.Text = "Atados Descartados"
        '
        'lblParesDescartadostitulo
        '
        Me.lblParesDescartadostitulo.AutoSize = True
        Me.lblParesDescartadostitulo.Location = New System.Drawing.Point(564, 529)
        Me.lblParesDescartadostitulo.Name = "lblParesDescartadostitulo"
        Me.lblParesDescartadostitulo.Size = New System.Drawing.Size(97, 13)
        Me.lblParesDescartadostitulo.TabIndex = 62
        Me.lblParesDescartadostitulo.Text = "Pares Descartados"
        '
        'lblparesembarcar
        '
        Me.lblparesembarcar.AutoSize = True
        Me.lblparesembarcar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblparesembarcar.Location = New System.Drawing.Point(10, 545)
        Me.lblparesembarcar.Name = "lblparesembarcar"
        Me.lblparesembarcar.Size = New System.Drawing.Size(142, 17)
        Me.lblparesembarcar.TabIndex = 68
        Me.lblparesembarcar.Text = "Pares  a embarcar"
        '
        'lblTotalIngresados
        '
        Me.lblTotalIngresados.AutoSize = True
        Me.lblTotalIngresados.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalIngresados.ForeColor = System.Drawing.Color.Red
        Me.lblTotalIngresados.Location = New System.Drawing.Point(159, 537)
        Me.lblTotalIngresados.Name = "lblTotalIngresados"
        Me.lblTotalIngresados.Size = New System.Drawing.Size(76, 29)
        Me.lblTotalIngresados.TabIndex = 69
        Me.lblTotalIngresados.Text = "1,538"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(4, 84)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 70
        Me.lblNave.Text = "Nave"
        '
        'lblOperador
        '
        Me.lblOperador.AutoSize = True
        Me.lblOperador.Location = New System.Drawing.Point(238, 86)
        Me.lblOperador.Name = "lblOperador"
        Me.lblOperador.Size = New System.Drawing.Size(51, 13)
        Me.lblOperador.TabIndex = 71
        Me.lblOperador.Text = "Operador"
        '
        'cmbNaves
        '
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.Location = New System.Drawing.Point(43, 83)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(164, 21)
        Me.cmbNaves.TabIndex = 72
        '
        'cmbOperador
        '
        Me.cmbOperador.FormattingEnabled = True
        Me.cmbOperador.Location = New System.Drawing.Point(297, 83)
        Me.cmbOperador.Name = "cmbOperador"
        Me.cmbOperador.Size = New System.Drawing.Size(164, 21)
        Me.cmbOperador.TabIndex = 73
        '
        'lblLotesIncorrectos
        '
        Me.lblLotesIncorrectos.AutoSize = True
        Me.lblLotesIncorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotesIncorrectos.Location = New System.Drawing.Point(511, 568)
        Me.lblLotesIncorrectos.Name = "lblLotesIncorrectos"
        Me.lblLotesIncorrectos.Size = New System.Drawing.Size(14, 13)
        Me.lblLotesIncorrectos.TabIndex = 79
        Me.lblLotesIncorrectos.Text = "0"
        '
        'lblAtadosIncorrectos
        '
        Me.lblAtadosIncorrectos.AutoSize = True
        Me.lblAtadosIncorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtadosIncorrectos.Location = New System.Drawing.Point(511, 548)
        Me.lblAtadosIncorrectos.Name = "lblAtadosIncorrectos"
        Me.lblAtadosIncorrectos.Size = New System.Drawing.Size(14, 13)
        Me.lblAtadosIncorrectos.TabIndex = 78
        Me.lblAtadosIncorrectos.Text = "0"
        '
        'lblParesIncorrectos
        '
        Me.lblParesIncorrectos.AutoSize = True
        Me.lblParesIncorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesIncorrectos.Location = New System.Drawing.Point(511, 528)
        Me.lblParesIncorrectos.Name = "lblParesIncorrectos"
        Me.lblParesIncorrectos.Size = New System.Drawing.Size(14, 13)
        Me.lblParesIncorrectos.TabIndex = 77
        Me.lblParesIncorrectos.Text = "0"
        '
        'lblLotesIncorrectosTitulo
        '
        Me.lblLotesIncorrectosTitulo.AutoSize = True
        Me.lblLotesIncorrectosTitulo.Location = New System.Drawing.Point(401, 567)
        Me.lblLotesIncorrectosTitulo.Name = "lblLotesIncorrectosTitulo"
        Me.lblLotesIncorrectosTitulo.Size = New System.Drawing.Size(88, 13)
        Me.lblLotesIncorrectosTitulo.TabIndex = 76
        Me.lblLotesIncorrectosTitulo.Text = "Lotes incorrectos"
        '
        'lblAtadosIncorrectoTitulo
        '
        Me.lblAtadosIncorrectoTitulo.AutoSize = True
        Me.lblAtadosIncorrectoTitulo.Location = New System.Drawing.Point(401, 548)
        Me.lblAtadosIncorrectoTitulo.Name = "lblAtadosIncorrectoTitulo"
        Me.lblAtadosIncorrectoTitulo.Size = New System.Drawing.Size(95, 13)
        Me.lblAtadosIncorrectoTitulo.TabIndex = 75
        Me.lblAtadosIncorrectoTitulo.Text = "Atados incorrectos"
        '
        'lblParesIncorrectosTitilo
        '
        Me.lblParesIncorrectosTitilo.AutoSize = True
        Me.lblParesIncorrectosTitilo.Location = New System.Drawing.Point(401, 528)
        Me.lblParesIncorrectosTitilo.Name = "lblParesIncorrectosTitilo"
        Me.lblParesIncorrectosTitilo.Size = New System.Drawing.Size(89, 13)
        Me.lblParesIncorrectosTitilo.TabIndex = 74
        Me.lblParesIncorrectosTitilo.Text = "Pares incorrectos"
        '
        'txtcapturacodigos
        '
        Me.txtcapturacodigos.Enabled = False
        Me.txtcapturacodigos.Location = New System.Drawing.Point(638, 84)
        Me.txtcapturacodigos.Name = "txtcapturacodigos"
        Me.txtcapturacodigos.Size = New System.Drawing.Size(162, 20)
        Me.txtcapturacodigos.TabIndex = 80
        '
        'lblCodigos
        '
        Me.lblCodigos.AutoSize = True
        Me.lblCodigos.Location = New System.Drawing.Point(533, 87)
        Me.lblCodigos.Name = "lblCodigos"
        Me.lblCodigos.Size = New System.Drawing.Size(99, 13)
        Me.lblCodigos.TabIndex = 81
        Me.lblCodigos.Text = "Captura de códigos"
        '
        'opnArchivo
        '
        Me.opnArchivo.FileName = "OpenFileDialog1"
        '
        'grdLectura
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdLectura.DisplayLayout.Appearance = Appearance1
        Me.grdLectura.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdLectura.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdLectura.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdLectura.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdLectura.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdLectura.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.White
        Me.grdLectura.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdLectura.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdLectura.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdLectura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.grdLectura.Location = New System.Drawing.Point(3, 114)
        Me.grdLectura.Name = "grdLectura"
        Me.grdLectura.Size = New System.Drawing.Size(670, 411)
        Me.grdLectura.TabIndex = 82
        '
        'grdIncorrecto
        '
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdIncorrecto.DisplayLayout.Appearance = Appearance4
        Me.grdIncorrecto.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdIncorrecto.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdIncorrecto.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdIncorrecto.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdIncorrecto.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdIncorrecto.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance5.BackColor = System.Drawing.Color.White
        Me.grdIncorrecto.DisplayLayout.Override.RowAlternateAppearance = Appearance5
        Appearance6.BorderColor = System.Drawing.Color.DarkGray
        Me.grdIncorrecto.DisplayLayout.Override.RowAppearance = Appearance6
        Me.grdIncorrecto.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdIncorrecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.grdIncorrecto.Location = New System.Drawing.Point(679, 114)
        Me.grdIncorrecto.Name = "grdIncorrecto"
        Me.grdIncorrecto.Size = New System.Drawing.Size(675, 411)
        Me.grdIncorrecto.TabIndex = 83
        '
        'SalidaNavesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1354, 636)
        Me.Controls.Add(Me.grdIncorrecto)
        Me.Controls.Add(Me.grdLectura)
        Me.Controls.Add(Me.lblCodigos)
        Me.Controls.Add(Me.txtcapturacodigos)
        Me.Controls.Add(Me.lblLotesIncorrectos)
        Me.Controls.Add(Me.lblAtadosIncorrectos)
        Me.Controls.Add(Me.lblParesIncorrectos)
        Me.Controls.Add(Me.lblLotesIncorrectosTitulo)
        Me.Controls.Add(Me.lblAtadosIncorrectoTitulo)
        Me.Controls.Add(Me.lblParesIncorrectosTitilo)
        Me.Controls.Add(Me.cmbOperador)
        Me.Controls.Add(Me.cmbNaves)
        Me.Controls.Add(Me.lblOperador)
        Me.Controls.Add(Me.lblNave)
        Me.Controls.Add(Me.lblTotalIngresados)
        Me.Controls.Add(Me.lblparesembarcar)
        Me.Controls.Add(Me.lblLotesDescardatos)
        Me.Controls.Add(Me.lblAtadosDescartados)
        Me.Controls.Add(Me.lblParesDescartados)
        Me.Controls.Add(Me.lblLotesDescartadosTitulo)
        Me.Controls.Add(Me.lblAtadosDescartadosTitulo)
        Me.Controls.Add(Me.lblParesDescartadostitulo)
        Me.Controls.Add(Me.lblLotesCorrectos)
        Me.Controls.Add(Me.lblAtadosCorrectos)
        Me.Controls.Add(Me.lblParesCorrectos)
        Me.Controls.Add(Me.lblLotesCorrectosTitulo)
        Me.Controls.Add(Me.lblAtadosCorrectosTitulo)
        Me.Controls.Add(Me.lblParesCorrectosTitulo)
        Me.Controls.Add(Me.lblLotesLeidos)
        Me.Controls.Add(Me.lblAtadosLeidos)
        Me.Controls.Add(Me.lblParesLeidos)
        Me.Controls.Add(Me.lbllotesleidostitulo)
        Me.Controls.Add(Me.lblatadosleidostitulos)
        Me.Controls.Add(Me.lblparesleidotitulo)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "SalidaNavesForm"
        Me.Text = "Salida de Lotes"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        CType(Me.grdLectura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdIncorrecto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCncelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblparesleidotitulo As System.Windows.Forms.Label
    Friend WithEvents lblatadosleidostitulos As System.Windows.Forms.Label
    Friend WithEvents lbllotesleidostitulo As System.Windows.Forms.Label
    Friend WithEvents lblLotesLeidos As System.Windows.Forms.Label
    Friend WithEvents lblAtadosLeidos As System.Windows.Forms.Label
    Friend WithEvents lblParesLeidos As System.Windows.Forms.Label
    Friend WithEvents lblLotesCorrectos As System.Windows.Forms.Label
    Friend WithEvents lblAtadosCorrectos As System.Windows.Forms.Label
    Friend WithEvents lblParesCorrectos As System.Windows.Forms.Label
    Friend WithEvents lblLotesCorrectosTitulo As System.Windows.Forms.Label
    Friend WithEvents lblAtadosCorrectosTitulo As System.Windows.Forms.Label
    Friend WithEvents lblParesCorrectosTitulo As System.Windows.Forms.Label
    Friend WithEvents lblLotesDescardatos As System.Windows.Forms.Label
    Friend WithEvents lblAtadosDescartados As System.Windows.Forms.Label
    Friend WithEvents lblParesDescartados As System.Windows.Forms.Label
    Friend WithEvents lblLotesDescartadosTitulo As System.Windows.Forms.Label
    Friend WithEvents lblAtadosDescartadosTitulo As System.Windows.Forms.Label
    Friend WithEvents lblParesDescartadostitulo As System.Windows.Forms.Label
    Friend WithEvents lblparesembarcar As System.Windows.Forms.Label
    Friend WithEvents lblTotalIngresados As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblOperador As System.Windows.Forms.Label
    Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOperador As System.Windows.Forms.ComboBox
    Friend WithEvents lblLotesIncorrectos As System.Windows.Forms.Label
    Friend WithEvents lblAtadosIncorrectos As System.Windows.Forms.Label
    Friend WithEvents lblParesIncorrectos As System.Windows.Forms.Label
    Friend WithEvents lblLotesIncorrectosTitulo As System.Windows.Forms.Label
    Friend WithEvents lblAtadosIncorrectoTitulo As System.Windows.Forms.Label
    Friend WithEvents lblParesIncorrectosTitilo As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnLeerArchivo As System.Windows.Forms.Button
    Friend WithEvents txtcapturacodigos As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigos As System.Windows.Forms.Label
    Friend WithEvents opnArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents grdLectura As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdIncorrecto As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
