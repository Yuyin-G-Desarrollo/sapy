<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AltaImagenesModelosZebraForm
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
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gboxCoppel = New System.Windows.Forms.GroupBox()
        Me.btnExaminarCoppelA300 = New System.Windows.Forms.Button()
        Me.btnExaminarCoppelA203 = New System.Windows.Forms.Button()
        Me.txtArchivoCoppelAdulto300 = New System.Windows.Forms.TextBox()
        Me.txtArchivoCoppelAdulto203 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnExaminarCoppelN300 = New System.Windows.Forms.Button()
        Me.btnExaminarCoppelN203 = New System.Windows.Forms.Button()
        Me.txtArchivoCoppelNiño300 = New System.Windows.Forms.TextBox()
        Me.txtArchivoCoppelNiño203 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.pnlImagen = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtArchivo203 = New System.Windows.Forms.TextBox()
        Me.btnExaminarjpg = New System.Windows.Forms.Button()
        Me.lblImagen_203 = New System.Windows.Forms.Label()
        Me.lblImagen203 = New System.Windows.Forms.Label()
        Me.txtSiluetaJPG = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnExaminar203 = New System.Windows.Forms.Button()
        Me.lblImagen_300 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblImagen300 = New System.Windows.Forms.Label()
        Me.txtArchivo300 = New System.Windows.Forms.TextBox()
        Me.btnExaminar300 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkCoppel = New System.Windows.Forms.CheckBox()
        Me.rbtCoppel = New System.Windows.Forms.RadioButton()
        Me.txtModeloTallaCorrida = New System.Windows.Forms.TextBox()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.txtTalla = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtColeccion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ofdRutaArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gboxCoppel.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.pnlImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(682, 59)
        Me.pnlListaPaises.TabIndex = 32
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(301, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(381, 59)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(117, 21)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(212, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Modelos - Gráficos Zebra"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 338)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(682, 60)
        Me.pnlPie.TabIndex = 69
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.Label3)
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(517, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(165, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(46, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 16
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(43, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Guardar"
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(106, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 14
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(106, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.gboxCoppel)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 59)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(682, 279)
        Me.Panel1.TabIndex = 71
        '
        'gboxCoppel
        '
        Me.gboxCoppel.Controls.Add(Me.btnExaminarCoppelA300)
        Me.gboxCoppel.Controls.Add(Me.btnExaminarCoppelA203)
        Me.gboxCoppel.Controls.Add(Me.txtArchivoCoppelAdulto300)
        Me.gboxCoppel.Controls.Add(Me.txtArchivoCoppelAdulto203)
        Me.gboxCoppel.Controls.Add(Me.Label9)
        Me.gboxCoppel.Controls.Add(Me.Label10)
        Me.gboxCoppel.Controls.Add(Me.btnExaminarCoppelN300)
        Me.gboxCoppel.Controls.Add(Me.btnExaminarCoppelN203)
        Me.gboxCoppel.Controls.Add(Me.txtArchivoCoppelNiño300)
        Me.gboxCoppel.Controls.Add(Me.txtArchivoCoppelNiño203)
        Me.gboxCoppel.Controls.Add(Me.Label6)
        Me.gboxCoppel.Controls.Add(Me.Label8)
        Me.gboxCoppel.Location = New System.Drawing.Point(13, 268)
        Me.gboxCoppel.Name = "gboxCoppel"
        Me.gboxCoppel.Size = New System.Drawing.Size(648, 157)
        Me.gboxCoppel.TabIndex = 25
        Me.gboxCoppel.TabStop = False
        Me.gboxCoppel.Text = "Gráficos Coppel."
        '
        'btnExaminarCoppelA300
        '
        Me.btnExaminarCoppelA300.Location = New System.Drawing.Point(545, 117)
        Me.btnExaminarCoppelA300.Name = "btnExaminarCoppelA300"
        Me.btnExaminarCoppelA300.Size = New System.Drawing.Size(81, 23)
        Me.btnExaminarCoppelA300.TabIndex = 37
        Me.btnExaminarCoppelA300.Text = "Examinar"
        Me.btnExaminarCoppelA300.UseVisualStyleBackColor = True
        '
        'btnExaminarCoppelA203
        '
        Me.btnExaminarCoppelA203.Location = New System.Drawing.Point(545, 83)
        Me.btnExaminarCoppelA203.Name = "btnExaminarCoppelA203"
        Me.btnExaminarCoppelA203.Size = New System.Drawing.Size(81, 23)
        Me.btnExaminarCoppelA203.TabIndex = 36
        Me.btnExaminarCoppelA203.Text = "Examinar"
        Me.btnExaminarCoppelA203.UseVisualStyleBackColor = True
        '
        'txtArchivoCoppelAdulto300
        '
        Me.txtArchivoCoppelAdulto300.Location = New System.Drawing.Point(182, 120)
        Me.txtArchivoCoppelAdulto300.Name = "txtArchivoCoppelAdulto300"
        Me.txtArchivoCoppelAdulto300.ReadOnly = True
        Me.txtArchivoCoppelAdulto300.Size = New System.Drawing.Size(357, 20)
        Me.txtArchivoCoppelAdulto300.TabIndex = 32
        '
        'txtArchivoCoppelAdulto203
        '
        Me.txtArchivoCoppelAdulto203.Location = New System.Drawing.Point(182, 86)
        Me.txtArchivoCoppelAdulto203.Name = "txtArchivoCoppelAdulto203"
        Me.txtArchivoCoppelAdulto203.ReadOnly = True
        Me.txtArchivoCoppelAdulto203.Size = New System.Drawing.Size(357, 20)
        Me.txtArchivoCoppelAdulto203.TabIndex = 33
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(152, 13)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "* Gráfico Adulto Coppel 203dpi"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 123)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(152, 13)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "* Gráfico Adulto Coppel 300dpi"
        '
        'btnExaminarCoppelN300
        '
        Me.btnExaminarCoppelN300.Location = New System.Drawing.Point(545, 47)
        Me.btnExaminarCoppelN300.Name = "btnExaminarCoppelN300"
        Me.btnExaminarCoppelN300.Size = New System.Drawing.Size(81, 23)
        Me.btnExaminarCoppelN300.TabIndex = 31
        Me.btnExaminarCoppelN300.Text = "Examinar"
        Me.btnExaminarCoppelN300.UseVisualStyleBackColor = True
        '
        'btnExaminarCoppelN203
        '
        Me.btnExaminarCoppelN203.Location = New System.Drawing.Point(545, 13)
        Me.btnExaminarCoppelN203.Name = "btnExaminarCoppelN203"
        Me.btnExaminarCoppelN203.Size = New System.Drawing.Size(81, 23)
        Me.btnExaminarCoppelN203.TabIndex = 30
        Me.btnExaminarCoppelN203.Text = "Examinar"
        Me.btnExaminarCoppelN203.UseVisualStyleBackColor = True
        '
        'txtArchivoCoppelNiño300
        '
        Me.txtArchivoCoppelNiño300.Location = New System.Drawing.Point(182, 50)
        Me.txtArchivoCoppelNiño300.Name = "txtArchivoCoppelNiño300"
        Me.txtArchivoCoppelNiño300.ReadOnly = True
        Me.txtArchivoCoppelNiño300.Size = New System.Drawing.Size(357, 20)
        Me.txtArchivoCoppelNiño300.TabIndex = 28
        '
        'txtArchivoCoppelNiño203
        '
        Me.txtArchivoCoppelNiño203.Location = New System.Drawing.Point(182, 16)
        Me.txtArchivoCoppelNiño203.Name = "txtArchivoCoppelNiño203"
        Me.txtArchivoCoppelNiño203.ReadOnly = True
        Me.txtArchivoCoppelNiño203.Size = New System.Drawing.Size(357, 20)
        Me.txtArchivoCoppelNiño203.TabIndex = 28
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "* Gráfico Niño Coppel 203dpi"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "* Gráfico Niño Coppel 300dpi"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.pnlImagen)
        Me.GroupBox3.Location = New System.Drawing.Point(436, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(225, 136)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Silueta"
        '
        'pnlImagen
        '
        Me.pnlImagen.Location = New System.Drawing.Point(6, 19)
        Me.pnlImagen.Name = "pnlImagen"
        Me.pnlImagen.Size = New System.Drawing.Size(213, 109)
        Me.pnlImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pnlImagen.TabIndex = 23
        Me.pnlImagen.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtArchivo203)
        Me.GroupBox2.Controls.Add(Me.btnExaminarjpg)
        Me.GroupBox2.Controls.Add(Me.lblImagen_203)
        Me.GroupBox2.Controls.Add(Me.lblImagen203)
        Me.GroupBox2.Controls.Add(Me.txtSiluetaJPG)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.btnExaminar203)
        Me.GroupBox2.Controls.Add(Me.lblImagen_300)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.lblImagen300)
        Me.GroupBox2.Controls.Add(Me.txtArchivo300)
        Me.GroupBox2.Controls.Add(Me.btnExaminar300)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 146)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(649, 115)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        '
        'txtArchivo203
        '
        Me.txtArchivo203.Location = New System.Drawing.Point(99, 20)
        Me.txtArchivo203.Name = "txtArchivo203"
        Me.txtArchivo203.ReadOnly = True
        Me.txtArchivo203.Size = New System.Drawing.Size(440, 20)
        Me.txtArchivo203.TabIndex = 11
        '
        'btnExaminarjpg
        '
        Me.btnExaminarjpg.Location = New System.Drawing.Point(545, 82)
        Me.btnExaminarjpg.Name = "btnExaminarjpg"
        Me.btnExaminarjpg.Size = New System.Drawing.Size(81, 23)
        Me.btnExaminarjpg.TabIndex = 27
        Me.btnExaminarjpg.Text = "Examinar"
        Me.btnExaminarjpg.UseVisualStyleBackColor = True
        '
        'lblImagen_203
        '
        Me.lblImagen_203.AutoSize = True
        Me.lblImagen_203.Location = New System.Drawing.Point(10, 25)
        Me.lblImagen_203.Name = "lblImagen_203"
        Me.lblImagen_203.Size = New System.Drawing.Size(83, 13)
        Me.lblImagen_203.TabIndex = 1
        Me.lblImagen_203.Text = "* Gráfico 203dpi"
        '
        'lblImagen203
        '
        Me.lblImagen203.AutoSize = True
        Me.lblImagen203.Location = New System.Drawing.Point(6, 25)
        Me.lblImagen203.Name = "lblImagen203"
        Me.lblImagen203.Size = New System.Drawing.Size(83, 13)
        Me.lblImagen203.TabIndex = 1
        Me.lblImagen203.Text = "* Gráfico 203dpi"
        '
        'txtSiluetaJPG
        '
        Me.txtSiluetaJPG.Location = New System.Drawing.Point(99, 84)
        Me.txtSiluetaJPG.Name = "txtSiluetaJPG"
        Me.txtSiluetaJPG.ReadOnly = True
        Me.txtSiluetaJPG.Size = New System.Drawing.Size(440, 20)
        Me.txtSiluetaJPG.TabIndex = 26
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(47, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "* Silueta"
        '
        'btnExaminar203
        '
        Me.btnExaminar203.Location = New System.Drawing.Point(545, 18)
        Me.btnExaminar203.Name = "btnExaminar203"
        Me.btnExaminar203.Size = New System.Drawing.Size(81, 23)
        Me.btnExaminar203.TabIndex = 12
        Me.btnExaminar203.Text = "Examinar"
        Me.btnExaminar203.UseVisualStyleBackColor = True
        '
        'lblImagen_300
        '
        Me.lblImagen_300.AutoSize = True
        Me.lblImagen_300.Location = New System.Drawing.Point(10, 54)
        Me.lblImagen_300.Name = "lblImagen_300"
        Me.lblImagen_300.Size = New System.Drawing.Size(83, 13)
        Me.lblImagen_300.TabIndex = 13
        Me.lblImagen_300.Text = "* Gráfico 300dpi"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "* Silueta"
        '
        'lblImagen300
        '
        Me.lblImagen300.AutoSize = True
        Me.lblImagen300.Location = New System.Drawing.Point(6, 54)
        Me.lblImagen300.Name = "lblImagen300"
        Me.lblImagen300.Size = New System.Drawing.Size(83, 13)
        Me.lblImagen300.TabIndex = 13
        Me.lblImagen300.Text = "* Gráfico 300dpi"
        '
        'txtArchivo300
        '
        Me.txtArchivo300.Location = New System.Drawing.Point(99, 51)
        Me.txtArchivo300.Name = "txtArchivo300"
        Me.txtArchivo300.ReadOnly = True
        Me.txtArchivo300.Size = New System.Drawing.Size(440, 20)
        Me.txtArchivo300.TabIndex = 14
        '
        'btnExaminar300
        '
        Me.btnExaminar300.Location = New System.Drawing.Point(545, 49)
        Me.btnExaminar300.Name = "btnExaminar300"
        Me.btnExaminar300.Size = New System.Drawing.Size(81, 23)
        Me.btnExaminar300.TabIndex = 15
        Me.btnExaminar300.Text = "Examinar"
        Me.btnExaminar300.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkCoppel)
        Me.GroupBox1.Controls.Add(Me.rbtCoppel)
        Me.GroupBox1.Controls.Add(Me.txtModeloTallaCorrida)
        Me.GroupBox1.Controls.Add(Me.txtModelo)
        Me.GroupBox1.Controls.Add(Me.txtTalla)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtColeccion)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(418, 136)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Modelo"
        '
        'chkCoppel
        '
        Me.chkCoppel.AutoSize = True
        Me.chkCoppel.Location = New System.Drawing.Point(9, 111)
        Me.chkCoppel.Name = "chkCoppel"
        Me.chkCoppel.Size = New System.Drawing.Size(114, 17)
        Me.chkCoppel.TabIndex = 25
        Me.chkCoppel.Text = "Es modelo Coppel."
        Me.chkCoppel.UseVisualStyleBackColor = True
        '
        'rbtCoppel
        '
        Me.rbtCoppel.AutoSize = True
        Me.rbtCoppel.Location = New System.Drawing.Point(136, 110)
        Me.rbtCoppel.Name = "rbtCoppel"
        Me.rbtCoppel.Size = New System.Drawing.Size(113, 17)
        Me.rbtCoppel.TabIndex = 24
        Me.rbtCoppel.TabStop = True
        Me.rbtCoppel.Text = "Es modelo Coppel."
        Me.rbtCoppel.UseVisualStyleBackColor = True
        Me.rbtCoppel.Visible = False
        '
        'txtModeloTallaCorrida
        '
        Me.txtModeloTallaCorrida.Location = New System.Drawing.Point(9, 19)
        Me.txtModeloTallaCorrida.Name = "txtModeloTallaCorrida"
        Me.txtModeloTallaCorrida.ReadOnly = True
        Me.txtModeloTallaCorrida.Size = New System.Drawing.Size(403, 20)
        Me.txtModeloTallaCorrida.TabIndex = 23
        '
        'txtModelo
        '
        Me.txtModelo.Location = New System.Drawing.Point(147, 69)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.ReadOnly = True
        Me.txtModelo.Size = New System.Drawing.Size(110, 20)
        Me.txtModelo.TabIndex = 20
        '
        'txtTalla
        '
        Me.txtTalla.Location = New System.Drawing.Point(278, 69)
        Me.txtTalla.Name = "txtTalla"
        Me.txtTalla.ReadOnly = True
        Me.txtTalla.Size = New System.Drawing.Size(110, 20)
        Me.txtTalla.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Código Colleción SICY"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(144, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Modelo SICY"
        '
        'txtColeccion
        '
        Me.txtColeccion.Location = New System.Drawing.Point(9, 69)
        Me.txtColeccion.Name = "txtColeccion"
        Me.txtColeccion.ReadOnly = True
        Me.txtColeccion.Size = New System.Drawing.Size(110, 20)
        Me.txtColeccion.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(275, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Código Talla SICY"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(319, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AltaImagenesModelosZebraForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 398)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(690, 593)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(690, 425)
        Me.Name = "AltaImagenesModelosZebraForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Modelos - Gráficos Zebra"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.gboxCoppel.ResumeLayout(False)
        Me.gboxCoppel.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.pnlImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblImagen203 As System.Windows.Forms.Label
    Friend WithEvents txtArchivo203 As System.Windows.Forms.TextBox
    Friend WithEvents btnExaminar300 As System.Windows.Forms.Button
    Friend WithEvents txtArchivo300 As System.Windows.Forms.TextBox
    Friend WithEvents lblImagen300 As System.Windows.Forms.Label
    Friend WithEvents btnExaminar203 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtModelo As System.Windows.Forms.TextBox
    Friend WithEvents txtTalla As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtColeccion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlImagen As System.Windows.Forms.PictureBox
    Friend WithEvents ofdRutaArchivo As OpenFileDialog
    Friend WithEvents btnExaminarjpg As Button
    Friend WithEvents txtSiluetaJPG As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtModeloTallaCorrida As TextBox
    Friend WithEvents lblImagen_203 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblImagen_300 As Label
    Friend WithEvents gboxCoppel As GroupBox
    Friend WithEvents btnExaminarCoppelN300 As Button
    Friend WithEvents btnExaminarCoppelN203 As Button
    Friend WithEvents txtArchivoCoppelNiño300 As TextBox
    Friend WithEvents txtArchivoCoppelNiño203 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents chkCoppel As CheckBox
    Friend WithEvents rbtCoppel As RadioButton
    Friend WithEvents btnExaminarCoppelA300 As Button
    Friend WithEvents btnExaminarCoppelA203 As Button
    Friend WithEvents txtArchivoCoppelAdulto300 As TextBox
    Friend WithEvents txtArchivoCoppelAdulto203 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
