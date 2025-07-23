<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaIncentivoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaIncentivoForm))
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblClear = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.lblJustificacion = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.lblDepartamento2 = New System.Windows.Forms.Label()
        Me.lblNave2 = New System.Windows.Forms.Label()
        Me.pnlPropiedades = New System.Windows.Forms.Panel()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.lblEtiquetaCelula = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtMotivoTres = New System.Windows.Forms.TextBox()
        Me.lblGratificacion3 = New System.Windows.Forms.Label()
        Me.lblMonto3 = New System.Windows.Forms.Label()
        Me.lblMotivo3 = New System.Windows.Forms.Label()
        Me.cmbMotivos3 = New System.Windows.Forms.ComboBox()
        Me.txtMonto3 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtMotivoDos = New System.Windows.Forms.TextBox()
        Me.lblGratificacion2 = New System.Windows.Forms.Label()
        Me.lblMonto2 = New System.Windows.Forms.Label()
        Me.lblMotivo2 = New System.Windows.Forms.Label()
        Me.txtMonto2 = New System.Windows.Forms.TextBox()
        Me.cmbMotivos2 = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtMotivoUno = New System.Windows.Forms.TextBox()
        Me.lblGratificacion1 = New System.Windows.Forms.Label()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.cmbMotivos = New System.Windows.Forms.ComboBox()
        Me.txtJustificacion = New System.Windows.Forms.TextBox()
        Me.lblPuesto2 = New System.Windows.Forms.Label()
        Me.lblAntiguedad2 = New System.Windows.Forms.Label()
        Me.lblEdad2 = New System.Windows.Forms.Label()
        Me.lblColaborador2 = New System.Windows.Forms.Label()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblPuesto = New System.Windows.Forms.Label()
        Me.lblAntiguedad = New System.Windows.Forms.Label()
        Me.lblEdad = New System.Windows.Forms.Label()
        Me.lblColaborador = New System.Windows.Forms.Label()
        Me.picBoxColaborador = New System.Windows.Forms.PictureBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.pnlColores = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnLimpiarSolicitudes = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlPropiedades.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picBoxColaborador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlColores.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.pcbTitulo)
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(696, 59)
        Me.pnlListaPaises.TabIndex = 11
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(411, 19)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(206, 20)
        Me.lblEncabezado.TabIndex = 43
        Me.lblEncabezado.Text = "Solicitud de gratificación"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(155, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 41
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(101, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 40
        Me.lblGuardar.Text = "Guardar"
        '
        'lblClear
        '
        Me.lblClear.AutoSize = True
        Me.lblClear.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblClear.Location = New System.Drawing.Point(528, 38)
        Me.lblClear.Name = "lblClear"
        Me.lblClear.Size = New System.Drawing.Size(40, 13)
        Me.lblClear.TabIndex = 36
        Me.lblClear.Text = "Limpiar"
        Me.lblClear.Visible = False
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(116, 42)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(130, 20)
        Me.txtMonto.TabIndex = 26
        '
        'lblJustificacion
        '
        Me.lblJustificacion.AutoSize = True
        Me.lblJustificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJustificacion.ForeColor = System.Drawing.Color.Black
        Me.lblJustificacion.Location = New System.Drawing.Point(447, 339)
        Me.lblJustificacion.Name = "lblJustificacion"
        Me.lblJustificacion.Size = New System.Drawing.Size(100, 16)
        Me.lblJustificacion.TabIndex = 25
        Me.lblJustificacion.Text = "Observaciones"
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.ForeColor = System.Drawing.Color.Black
        Me.lblMonto.Location = New System.Drawing.Point(14, 42)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(45, 16)
        Me.lblMonto.TabIndex = 19
        Me.lblMonto.Text = "Monto"
        '
        'lblDepartamento2
        '
        Me.lblDepartamento2.AutoSize = True
        Me.lblDepartamento2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartamento2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblDepartamento2.Location = New System.Drawing.Point(233, 65)
        Me.lblDepartamento2.Name = "lblDepartamento2"
        Me.lblDepartamento2.Size = New System.Drawing.Size(106, 16)
        Me.lblDepartamento2.TabIndex = 17
        Me.lblDepartamento2.Text = "Departamento"
        '
        'lblNave2
        '
        Me.lblNave2.AutoSize = True
        Me.lblNave2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNave2.Location = New System.Drawing.Point(233, 39)
        Me.lblNave2.Name = "lblNave2"
        Me.lblNave2.Size = New System.Drawing.Size(45, 16)
        Me.lblNave2.TabIndex = 16
        Me.lblNave2.Text = "Nave"
        '
        'pnlPropiedades
        '
        Me.pnlPropiedades.Controls.Add(Me.lblCelula)
        Me.pnlPropiedades.Controls.Add(Me.lblEtiquetaCelula)
        Me.pnlPropiedades.Controls.Add(Me.GroupBox3)
        Me.pnlPropiedades.Controls.Add(Me.GroupBox2)
        Me.pnlPropiedades.Controls.Add(Me.GroupBox1)
        Me.pnlPropiedades.Controls.Add(Me.txtJustificacion)
        Me.pnlPropiedades.Controls.Add(Me.lblJustificacion)
        Me.pnlPropiedades.Controls.Add(Me.lblDepartamento2)
        Me.pnlPropiedades.Controls.Add(Me.lblNave2)
        Me.pnlPropiedades.Controls.Add(Me.lblPuesto2)
        Me.pnlPropiedades.Controls.Add(Me.lblAntiguedad2)
        Me.pnlPropiedades.Controls.Add(Me.lblEdad2)
        Me.pnlPropiedades.Controls.Add(Me.lblColaborador2)
        Me.pnlPropiedades.Controls.Add(Me.lblDepartamento)
        Me.pnlPropiedades.Controls.Add(Me.lblNave)
        Me.pnlPropiedades.Controls.Add(Me.lblPuesto)
        Me.pnlPropiedades.Controls.Add(Me.lblAntiguedad)
        Me.pnlPropiedades.Controls.Add(Me.lblEdad)
        Me.pnlPropiedades.Controls.Add(Me.lblColaborador)
        Me.pnlPropiedades.Controls.Add(Me.picBoxColaborador)
        Me.pnlPropiedades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPropiedades.Location = New System.Drawing.Point(0, 59)
        Me.pnlPropiedades.Name = "pnlPropiedades"
        Me.pnlPropiedades.Size = New System.Drawing.Size(696, 526)
        Me.pnlPropiedades.TabIndex = 12
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelula.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblCelula.Location = New System.Drawing.Point(558, 65)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(52, 16)
        Me.lblCelula.TabIndex = 59
        Me.lblCelula.Text = "Celula"
        '
        'lblEtiquetaCelula
        '
        Me.lblEtiquetaCelula.AutoSize = True
        Me.lblEtiquetaCelula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaCelula.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaCelula.Location = New System.Drawing.Point(507, 65)
        Me.lblEtiquetaCelula.Name = "lblEtiquetaCelula"
        Me.lblEtiquetaCelula.Size = New System.Drawing.Size(46, 16)
        Me.lblEtiquetaCelula.TabIndex = 58
        Me.lblEtiquetaCelula.Text = "Celula"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtMotivoTres)
        Me.GroupBox3.Controls.Add(Me.lblGratificacion3)
        Me.GroupBox3.Controls.Add(Me.lblMonto3)
        Me.GroupBox3.Controls.Add(Me.lblMotivo3)
        Me.GroupBox3.Controls.Add(Me.cmbMotivos3)
        Me.GroupBox3.Controls.Add(Me.txtMonto3)
        Me.GroupBox3.Location = New System.Drawing.Point(22, 339)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(422, 100)
        Me.GroupBox3.TabIndex = 57
        Me.GroupBox3.TabStop = False
        '
        'txtMotivoTres
        '
        Me.txtMotivoTres.Enabled = False
        Me.txtMotivoTres.Location = New System.Drawing.Point(108, 71)
        Me.txtMotivoTres.Name = "txtMotivoTres"
        Me.txtMotivoTres.Size = New System.Drawing.Size(290, 20)
        Me.txtMotivoTres.TabIndex = 50
        Me.txtMotivoTres.Visible = False
        '
        'lblGratificacion3
        '
        Me.lblGratificacion3.AutoSize = True
        Me.lblGratificacion3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGratificacion3.Location = New System.Drawing.Point(6, 16)
        Me.lblGratificacion3.Name = "lblGratificacion3"
        Me.lblGratificacion3.Size = New System.Drawing.Size(107, 16)
        Me.lblGratificacion3.TabIndex = 52
        Me.lblGratificacion3.Text = "Gratificación 3"
        '
        'lblMonto3
        '
        Me.lblMonto3.AutoSize = True
        Me.lblMonto3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto3.Location = New System.Drawing.Point(6, 42)
        Me.lblMonto3.Name = "lblMonto3"
        Me.lblMonto3.Size = New System.Drawing.Size(45, 16)
        Me.lblMonto3.TabIndex = 53
        Me.lblMonto3.Text = "Monto"
        '
        'lblMotivo3
        '
        Me.lblMotivo3.AutoSize = True
        Me.lblMotivo3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMotivo3.Location = New System.Drawing.Point(6, 70)
        Me.lblMotivo3.Name = "lblMotivo3"
        Me.lblMotivo3.Size = New System.Drawing.Size(48, 16)
        Me.lblMotivo3.TabIndex = 54
        Me.lblMotivo3.Text = "Motivo"
        '
        'cmbMotivos3
        '
        Me.cmbMotivos3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMotivos3.FormattingEnabled = True
        Me.cmbMotivos3.Location = New System.Drawing.Point(108, 70)
        Me.cmbMotivos3.Name = "cmbMotivos3"
        Me.cmbMotivos3.Size = New System.Drawing.Size(290, 21)
        Me.cmbMotivos3.TabIndex = 31
        '
        'txtMonto3
        '
        Me.txtMonto3.Location = New System.Drawing.Point(108, 38)
        Me.txtMonto3.Name = "txtMonto3"
        Me.txtMonto3.Size = New System.Drawing.Size(130, 20)
        Me.txtMonto3.TabIndex = 30
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtMotivoDos)
        Me.GroupBox2.Controls.Add(Me.lblGratificacion2)
        Me.GroupBox2.Controls.Add(Me.lblMonto2)
        Me.GroupBox2.Controls.Add(Me.lblMotivo2)
        Me.GroupBox2.Controls.Add(Me.txtMonto2)
        Me.GroupBox2.Controls.Add(Me.cmbMotivos2)
        Me.GroupBox2.Location = New System.Drawing.Point(22, 239)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(652, 100)
        Me.GroupBox2.TabIndex = 56
        Me.GroupBox2.TabStop = False
        '
        'txtMotivoDos
        '
        Me.txtMotivoDos.Enabled = False
        Me.txtMotivoDos.Location = New System.Drawing.Point(110, 74)
        Me.txtMotivoDos.Name = "txtMotivoDos"
        Me.txtMotivoDos.Size = New System.Drawing.Size(290, 20)
        Me.txtMotivoDos.TabIndex = 48
        Me.txtMotivoDos.Visible = False
        '
        'lblGratificacion2
        '
        Me.lblGratificacion2.AutoSize = True
        Me.lblGratificacion2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGratificacion2.Location = New System.Drawing.Point(6, 15)
        Me.lblGratificacion2.Name = "lblGratificacion2"
        Me.lblGratificacion2.Size = New System.Drawing.Size(107, 16)
        Me.lblGratificacion2.TabIndex = 47
        Me.lblGratificacion2.Text = "Gratificación 2"
        '
        'lblMonto2
        '
        Me.lblMonto2.AutoSize = True
        Me.lblMonto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto2.Location = New System.Drawing.Point(8, 43)
        Me.lblMonto2.Name = "lblMonto2"
        Me.lblMonto2.Size = New System.Drawing.Size(45, 16)
        Me.lblMonto2.TabIndex = 48
        Me.lblMonto2.Text = "Monto"
        '
        'lblMotivo2
        '
        Me.lblMotivo2.AutoSize = True
        Me.lblMotivo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMotivo2.Location = New System.Drawing.Point(8, 73)
        Me.lblMotivo2.Name = "lblMotivo2"
        Me.lblMotivo2.Size = New System.Drawing.Size(48, 16)
        Me.lblMotivo2.TabIndex = 49
        Me.lblMotivo2.Text = "Motivo"
        '
        'txtMonto2
        '
        Me.txtMonto2.Location = New System.Drawing.Point(110, 39)
        Me.txtMonto2.Name = "txtMonto2"
        Me.txtMonto2.Size = New System.Drawing.Size(130, 20)
        Me.txtMonto2.TabIndex = 28
        '
        'cmbMotivos2
        '
        Me.cmbMotivos2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMotivos2.FormattingEnabled = True
        Me.cmbMotivos2.Location = New System.Drawing.Point(110, 73)
        Me.cmbMotivos2.Name = "cmbMotivos2"
        Me.cmbMotivos2.Size = New System.Drawing.Size(290, 21)
        Me.cmbMotivos2.TabIndex = 29
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMotivoUno)
        Me.GroupBox1.Controls.Add(Me.lblGratificacion1)
        Me.GroupBox1.Controls.Add(Me.lblMonto)
        Me.GroupBox1.Controls.Add(Me.txtMonto)
        Me.GroupBox1.Controls.Add(Me.lblMotivo)
        Me.GroupBox1.Controls.Add(Me.cmbMotivos)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 139)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(652, 100)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        '
        'txtMotivoUno
        '
        Me.txtMotivoUno.Enabled = False
        Me.txtMotivoUno.Location = New System.Drawing.Point(116, 73)
        Me.txtMotivoUno.Name = "txtMotivoUno"
        Me.txtMotivoUno.Size = New System.Drawing.Size(290, 20)
        Me.txtMotivoUno.TabIndex = 47
        Me.txtMotivoUno.Visible = False
        '
        'lblGratificacion1
        '
        Me.lblGratificacion1.AutoSize = True
        Me.lblGratificacion1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGratificacion1.Location = New System.Drawing.Point(12, 18)
        Me.lblGratificacion1.Name = "lblGratificacion1"
        Me.lblGratificacion1.Size = New System.Drawing.Size(107, 16)
        Me.lblGratificacion1.TabIndex = 46
        Me.lblGratificacion1.Text = "Gratificación 1"
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMotivo.ForeColor = System.Drawing.Color.Black
        Me.lblMotivo.Location = New System.Drawing.Point(14, 71)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(48, 16)
        Me.lblMotivo.TabIndex = 43
        Me.lblMotivo.Text = "Motivo"
        '
        'cmbMotivos
        '
        Me.cmbMotivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMotivos.FormattingEnabled = True
        Me.cmbMotivos.Location = New System.Drawing.Point(116, 72)
        Me.cmbMotivos.Name = "cmbMotivos"
        Me.cmbMotivos.Size = New System.Drawing.Size(290, 21)
        Me.cmbMotivos.TabIndex = 27
        '
        'txtJustificacion
        '
        Me.txtJustificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJustificacion.Location = New System.Drawing.Point(450, 355)
        Me.txtJustificacion.MaxLength = 50
        Me.txtJustificacion.Multiline = True
        Me.txtJustificacion.Name = "txtJustificacion"
        Me.txtJustificacion.Size = New System.Drawing.Size(228, 84)
        Me.txtJustificacion.TabIndex = 32
        '
        'lblPuesto2
        '
        Me.lblPuesto2.AutoSize = True
        Me.lblPuesto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPuesto2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPuesto2.Location = New System.Drawing.Point(233, 91)
        Me.lblPuesto2.Name = "lblPuesto2"
        Me.lblPuesto2.Size = New System.Drawing.Size(56, 16)
        Me.lblPuesto2.TabIndex = 15
        Me.lblPuesto2.Text = "Puesto"
        '
        'lblAntiguedad2
        '
        Me.lblAntiguedad2.AutoSize = True
        Me.lblAntiguedad2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAntiguedad2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAntiguedad2.Location = New System.Drawing.Point(233, 117)
        Me.lblAntiguedad2.Name = "lblAntiguedad2"
        Me.lblAntiguedad2.Size = New System.Drawing.Size(87, 16)
        Me.lblAntiguedad2.TabIndex = 12
        Me.lblAntiguedad2.Text = "Antiguedad"
        '
        'lblEdad2
        '
        Me.lblEdad2.AutoSize = True
        Me.lblEdad2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdad2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEdad2.Location = New System.Drawing.Point(602, 13)
        Me.lblEdad2.Name = "lblEdad2"
        Me.lblEdad2.Size = New System.Drawing.Size(45, 16)
        Me.lblEdad2.TabIndex = 11
        Me.lblEdad2.Text = "Edad"
        '
        'lblColaborador2
        '
        Me.lblColaborador2.AutoSize = True
        Me.lblColaborador2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColaborador2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblColaborador2.Location = New System.Drawing.Point(233, 13)
        Me.lblColaborador2.Name = "lblColaborador2"
        Me.lblColaborador2.Size = New System.Drawing.Size(95, 16)
        Me.lblColaborador2.TabIndex = 10
        Me.lblColaborador2.Text = "Colaborador"
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartamento.ForeColor = System.Drawing.Color.Black
        Me.lblDepartamento.Location = New System.Drawing.Point(137, 65)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(94, 16)
        Me.lblDepartamento.TabIndex = 8
        Me.lblDepartamento.Text = "Departamento"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(137, 39)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(41, 16)
        Me.lblNave.TabIndex = 7
        Me.lblNave.Text = "Nave"
        '
        'lblPuesto
        '
        Me.lblPuesto.AutoSize = True
        Me.lblPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPuesto.ForeColor = System.Drawing.Color.Black
        Me.lblPuesto.Location = New System.Drawing.Point(137, 91)
        Me.lblPuesto.Name = "lblPuesto"
        Me.lblPuesto.Size = New System.Drawing.Size(50, 16)
        Me.lblPuesto.TabIndex = 6
        Me.lblPuesto.Text = "Puesto"
        '
        'lblAntiguedad
        '
        Me.lblAntiguedad.AutoSize = True
        Me.lblAntiguedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAntiguedad.ForeColor = System.Drawing.Color.Black
        Me.lblAntiguedad.Location = New System.Drawing.Point(137, 117)
        Me.lblAntiguedad.Name = "lblAntiguedad"
        Me.lblAntiguedad.Size = New System.Drawing.Size(77, 16)
        Me.lblAntiguedad.TabIndex = 3
        Me.lblAntiguedad.Text = "Antigüedad"
        '
        'lblEdad
        '
        Me.lblEdad.AutoSize = True
        Me.lblEdad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdad.ForeColor = System.Drawing.Color.Black
        Me.lblEdad.Location = New System.Drawing.Point(555, 13)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(41, 16)
        Me.lblEdad.TabIndex = 2
        Me.lblEdad.Text = "Edad"
        '
        'lblColaborador
        '
        Me.lblColaborador.AutoSize = True
        Me.lblColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColaborador.ForeColor = System.Drawing.Color.Black
        Me.lblColaborador.Location = New System.Drawing.Point(137, 13)
        Me.lblColaborador.Name = "lblColaborador"
        Me.lblColaborador.Size = New System.Drawing.Size(84, 16)
        Me.lblColaborador.TabIndex = 1
        Me.lblColaborador.Text = "Colaborador"
        '
        'picBoxColaborador
        '
        Me.picBoxColaborador.Image = Global.Nomina.Vista.My.Resources.Resources.YUMPER_BUSTO1
        Me.picBoxColaborador.Location = New System.Drawing.Point(24, 13)
        Me.picBoxColaborador.Name = "picBoxColaborador"
        Me.picBoxColaborador.Size = New System.Drawing.Size(102, 120)
        Me.picBoxColaborador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBoxColaborador.TabIndex = 0
        Me.picBoxColaborador.TabStop = False
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(474, 38)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 45
        Me.lblBuscar.Text = "Mostrar"
        Me.lblBuscar.Visible = False
        '
        'pnlColores
        '
        Me.pnlColores.BackColor = System.Drawing.Color.White
        Me.pnlColores.Controls.Add(Me.Panel4)
        Me.pnlColores.Controls.Add(Me.btnLimpiar)
        Me.pnlColores.Controls.Add(Me.btnBuscar)
        Me.pnlColores.Controls.Add(Me.lblClear)
        Me.pnlColores.Controls.Add(Me.lblBuscar)
        Me.pnlColores.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlColores.Location = New System.Drawing.Point(0, 525)
        Me.pnlColores.Name = "pnlColores"
        Me.pnlColores.Size = New System.Drawing.Size(696, 60)
        Me.pnlColores.TabIndex = 16
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnLimpiarSolicitudes)
        Me.Panel4.Controls.Add(Me.btnGuardar)
        Me.Panel4.Controls.Add(Me.lblCancelar)
        Me.Panel4.Controls.Add(Me.lblGuardar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(496, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(200, 60)
        Me.Panel4.TabIndex = 17
        '
        'btnLimpiarSolicitudes
        '
        Me.btnLimpiarSolicitudes.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnLimpiarSolicitudes.Location = New System.Drawing.Point(156, 3)
        Me.btnLimpiarSolicitudes.Name = "btnLimpiarSolicitudes"
        Me.btnLimpiarSolicitudes.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarSolicitudes.TabIndex = 39
        Me.btnLimpiarSolicitudes.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(106, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 38
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(531, 3)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 34
        Me.btnLimpiar.UseVisualStyleBackColor = True
        Me.btnLimpiar.Visible = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(477, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 33
        Me.btnBuscar.UseVisualStyleBackColor = True
        Me.btnBuscar.Visible = False
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(628, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 44
        Me.pcbTitulo.TabStop = False
        '
        'AltaIncentivoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(696, 585)
        Me.Controls.Add(Me.pnlColores)
        Me.Controls.Add(Me.pnlPropiedades)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(702, 607)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(702, 607)
        Me.Name = "AltaIncentivoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud de gratificación"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.pnlPropiedades.ResumeLayout(False)
        Me.pnlPropiedades.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picBoxColaborador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlColores.ResumeLayout(False)
        Me.pnlColores.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarSolicitudes As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblClear As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents lblJustificacion As System.Windows.Forms.Label
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento2 As System.Windows.Forms.Label
    Friend WithEvents lblNave2 As System.Windows.Forms.Label
    Friend WithEvents pnlPropiedades As System.Windows.Forms.Panel
    Friend WithEvents txtJustificacion As System.Windows.Forms.TextBox
    Friend WithEvents lblAntiguedad2 As System.Windows.Forms.Label
    Friend WithEvents lblEdad2 As System.Windows.Forms.Label
    Friend WithEvents lblColaborador2 As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblAntiguedad As System.Windows.Forms.Label
    Friend WithEvents lblEdad As System.Windows.Forms.Label
    Friend WithEvents lblColaborador As System.Windows.Forms.Label
    Friend WithEvents picBoxColaborador As System.Windows.Forms.PictureBox
    Friend WithEvents cmbMotivos As System.Windows.Forms.ComboBox
    Friend WithEvents lblMotivo As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents pnlColores As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents cmbMotivos3 As System.Windows.Forms.ComboBox
    Friend WithEvents txtMonto3 As System.Windows.Forms.TextBox
    Friend WithEvents lblMotivo3 As System.Windows.Forms.Label
    Friend WithEvents lblMonto3 As System.Windows.Forms.Label
    Friend WithEvents cmbMotivos2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtMonto2 As System.Windows.Forms.TextBox
    Friend WithEvents lblMotivo2 As System.Windows.Forms.Label
    Friend WithEvents lblMonto2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblGratificacion3 As System.Windows.Forms.Label
    Friend WithEvents lblGratificacion2 As System.Windows.Forms.Label
    Friend WithEvents lblGratificacion1 As System.Windows.Forms.Label
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents lblEtiquetaCelula As System.Windows.Forms.Label
    Friend WithEvents lblPuesto2 As System.Windows.Forms.Label
    Friend WithEvents lblPuesto As System.Windows.Forms.Label
    Friend WithEvents txtMotivoTres As System.Windows.Forms.TextBox
    Friend WithEvents txtMotivoDos As System.Windows.Forms.TextBox
    Friend WithEvents txtMotivoUno As System.Windows.Forms.TextBox
    Friend WithEvents pcbTitulo As PictureBox
End Class
