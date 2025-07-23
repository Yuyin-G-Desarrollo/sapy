<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistroExcepcionesAltaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegistroExcepcionesAltaForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlAreaTrabajo = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.grpBloque = New System.Windows.Forms.GroupBox()
        Me.chkRegreso = New System.Windows.Forms.CheckBox()
        Me.chkEntrada = New System.Windows.Forms.CheckBox()
        Me.picboxColaborador = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaTermino = New System.Windows.Forms.DateTimePicker()
        Me.dtpHoraInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpHoraFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.txtboxNota = New System.Windows.Forms.TextBox()
        Me.lblNota = New System.Windows.Forms.Label()
        Me.cboxMotivoPermiso = New System.Windows.Forms.ComboBox()
        Me.lblMotivoPermiso = New System.Windows.Forms.Label()
        Me.cboxTipoPermiso = New System.Windows.Forms.ComboBox()
        Me.lblTipoPermiso = New System.Windows.Forms.Label()
        Me.cboxNave = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chboxCajaAhorro = New System.Windows.Forms.CheckBox()
        Me.chboxPyA = New System.Windows.Forms.CheckBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.cboxColaborador = New System.Windows.Forms.ComboBox()
        Me.cboxDepartamento = New System.Windows.Forms.ComboBox()
        Me.lblColaborador = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlContenido.SuspendLayout()
        Me.pnlAreaTrabajo.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpBloque.SuspendLayout()
        CType(Me.picboxColaborador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(802, 60)
        Me.pnlHeader.TabIndex = 6
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(153, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(649, 60)
        Me.pnlTitulo.TabIndex = 2
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(310, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(274, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Solicitud de Permiso o Excepción"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlOperaciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 425)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(802, 60)
        Me.pnlPie.TabIndex = 7
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.btnCerrar)
        Me.pnlOperaciones.Controls.Add(Me.lblCerrar)
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Controls.Add(Me.btnGuardar)
        Me.pnlOperaciones.Controls.Add(Me.lblGuardar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(540, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(262, 60)
        Me.pnlOperaciones.TabIndex = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCerrar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(220, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 32
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(219, 39)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 33
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancelar.Image = Global.Nomina.Vista.My.Resources.Resources.cancelar32
        Me.btnCancelar.Location = New System.Drawing.Point(168, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 26
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(160, 39)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelar.TabIndex = 27
        Me.lblCancelar.Text = "Cancelar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(111, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 24
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(105, 39)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 25
        Me.lblGuardar.Text = "Guardar"
        '
        'pnlContenido
        '
        Me.pnlContenido.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenido.Controls.Add(Me.pnlAreaTrabajo)
        Me.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenido.Location = New System.Drawing.Point(0, 60)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(802, 365)
        Me.pnlContenido.TabIndex = 8
        '
        'pnlAreaTrabajo
        '
        Me.pnlAreaTrabajo.AutoSize = True
        Me.pnlAreaTrabajo.Controls.Add(Me.GroupBox2)
        Me.pnlAreaTrabajo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAreaTrabajo.Location = New System.Drawing.Point(0, 0)
        Me.pnlAreaTrabajo.Name = "pnlAreaTrabajo"
        Me.pnlAreaTrabajo.Size = New System.Drawing.Size(802, 365)
        Me.pnlAreaTrabajo.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grpBloque)
        Me.GroupBox2.Controls.Add(Me.picboxColaborador)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtpFechaTermino)
        Me.GroupBox2.Controls.Add(Me.dtpHoraInicio)
        Me.GroupBox2.Controls.Add(Me.dtpHoraFin)
        Me.GroupBox2.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox2.Controls.Add(Me.txtboxNota)
        Me.GroupBox2.Controls.Add(Me.lblNota)
        Me.GroupBox2.Controls.Add(Me.cboxMotivoPermiso)
        Me.GroupBox2.Controls.Add(Me.lblMotivoPermiso)
        Me.GroupBox2.Controls.Add(Me.cboxTipoPermiso)
        Me.GroupBox2.Controls.Add(Me.lblTipoPermiso)
        Me.GroupBox2.Controls.Add(Me.cboxNave)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.lblNave)
        Me.GroupBox2.Controls.Add(Me.lblDepartamento)
        Me.GroupBox2.Controls.Add(Me.cboxColaborador)
        Me.GroupBox2.Controls.Add(Me.cboxDepartamento)
        Me.GroupBox2.Controls.Add(Me.lblColaborador)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 23)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox2.Size = New System.Drawing.Size(768, 298)
        Me.GroupBox2.TabIndex = 44
        Me.GroupBox2.TabStop = False
        '
        'grpBloque
        '
        Me.grpBloque.Controls.Add(Me.chkRegreso)
        Me.grpBloque.Controls.Add(Me.chkEntrada)
        Me.grpBloque.Location = New System.Drawing.Point(533, 214)
        Me.grpBloque.Name = "grpBloque"
        Me.grpBloque.Size = New System.Drawing.Size(143, 62)
        Me.grpBloque.TabIndex = 44
        Me.grpBloque.TabStop = False
        Me.grpBloque.Text = "Bloque"
        '
        'chkRegreso
        '
        Me.chkRegreso.AutoSize = True
        Me.chkRegreso.Location = New System.Drawing.Point(11, 39)
        Me.chkRegreso.Name = "chkRegreso"
        Me.chkRegreso.Size = New System.Drawing.Size(66, 17)
        Me.chkRegreso.TabIndex = 1
        Me.chkRegreso.Text = "Regreso"
        Me.chkRegreso.UseVisualStyleBackColor = True
        '
        'chkEntrada
        '
        Me.chkEntrada.AutoSize = True
        Me.chkEntrada.Location = New System.Drawing.Point(11, 19)
        Me.chkEntrada.Name = "chkEntrada"
        Me.chkEntrada.Size = New System.Drawing.Size(63, 17)
        Me.chkEntrada.TabIndex = 0
        Me.chkEntrada.Text = "Entrada"
        Me.chkEntrada.UseVisualStyleBackColor = True
        '
        'picboxColaborador
        '
        Me.picboxColaborador.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picboxColaborador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picboxColaborador.Location = New System.Drawing.Point(27, 35)
        Me.picboxColaborador.Name = "picboxColaborador"
        Me.picboxColaborador.Size = New System.Drawing.Size(128, 147)
        Me.picboxColaborador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picboxColaborador.TabIndex = 43
        Me.picboxColaborador.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(179, 256)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "* Fin excepción"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(179, 220)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "* Inicio excepción"
        '
        'dtpFechaTermino
        '
        Me.dtpFechaTermino.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFechaTermino.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaTermino.Location = New System.Drawing.Point(278, 256)
        Me.dtpFechaTermino.Name = "dtpFechaTermino"
        Me.dtpFechaTermino.Size = New System.Drawing.Size(105, 20)
        Me.dtpFechaTermino.TabIndex = 40
        '
        'dtpHoraInicio
        '
        Me.dtpHoraInicio.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpHoraInicio.Enabled = False
        Me.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraInicio.Location = New System.Drawing.Point(394, 220)
        Me.dtpHoraInicio.Name = "dtpHoraInicio"
        Me.dtpHoraInicio.ShowUpDown = True
        Me.dtpHoraInicio.Size = New System.Drawing.Size(105, 20)
        Me.dtpHoraInicio.TabIndex = 39
        '
        'dtpHoraFin
        '
        Me.dtpHoraFin.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpHoraFin.Enabled = False
        Me.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraFin.Location = New System.Drawing.Point(394, 256)
        Me.dtpHoraFin.Name = "dtpHoraFin"
        Me.dtpHoraFin.ShowUpDown = True
        Me.dtpHoraFin.Size = New System.Drawing.Size(105, 20)
        Me.dtpHoraFin.TabIndex = 38
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(278, 220)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(105, 20)
        Me.dtpFechaInicio.TabIndex = 37
        '
        'txtboxNota
        '
        Me.txtboxNota.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtboxNota.Location = New System.Drawing.Point(533, 128)
        Me.txtboxNota.Multiline = True
        Me.txtboxNota.Name = "txtboxNota"
        Me.txtboxNota.Size = New System.Drawing.Size(163, 76)
        Me.txtboxNota.TabIndex = 36
        '
        'lblNota
        '
        Me.lblNota.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblNota.AutoSize = True
        Me.lblNota.Location = New System.Drawing.Point(533, 112)
        Me.lblNota.Name = "lblNota"
        Me.lblNota.Size = New System.Drawing.Size(65, 13)
        Me.lblNota.TabIndex = 35
        Me.lblNota.Text = "Comentarios"
        '
        'cboxMotivoPermiso
        '
        Me.cboxMotivoPermiso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cboxMotivoPermiso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxMotivoPermiso.FormattingEnabled = True
        Me.cboxMotivoPermiso.Location = New System.Drawing.Point(278, 183)
        Me.cboxMotivoPermiso.Name = "cboxMotivoPermiso"
        Me.cboxMotivoPermiso.Size = New System.Drawing.Size(221, 21)
        Me.cboxMotivoPermiso.TabIndex = 34
        '
        'lblMotivoPermiso
        '
        Me.lblMotivoPermiso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblMotivoPermiso.AutoSize = True
        Me.lblMotivoPermiso.Location = New System.Drawing.Point(179, 183)
        Me.lblMotivoPermiso.Name = "lblMotivoPermiso"
        Me.lblMotivoPermiso.Size = New System.Drawing.Size(100, 13)
        Me.lblMotivoPermiso.TabIndex = 33
        Me.lblMotivoPermiso.Text = "* Motivo de permiso"
        '
        'cboxTipoPermiso
        '
        Me.cboxTipoPermiso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cboxTipoPermiso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxTipoPermiso.FormattingEnabled = True
        Me.cboxTipoPermiso.Items.AddRange(New Object() {"ENTRADA TARDE", "SALIDA ANTICIPADA", "INASISTENCIA"})
        Me.cboxTipoPermiso.Location = New System.Drawing.Point(278, 146)
        Me.cboxTipoPermiso.Name = "cboxTipoPermiso"
        Me.cboxTipoPermiso.Size = New System.Drawing.Size(221, 21)
        Me.cboxTipoPermiso.TabIndex = 32
        '
        'lblTipoPermiso
        '
        Me.lblTipoPermiso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTipoPermiso.AutoSize = True
        Me.lblTipoPermiso.Location = New System.Drawing.Point(179, 146)
        Me.lblTipoPermiso.Name = "lblTipoPermiso"
        Me.lblTipoPermiso.Size = New System.Drawing.Size(89, 13)
        Me.lblTipoPermiso.TabIndex = 31
        Me.lblTipoPermiso.Text = "* Tipo de permiso"
        '
        'cboxNave
        '
        Me.cboxNave.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cboxNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxNave.FormattingEnabled = True
        Me.cboxNave.Location = New System.Drawing.Point(278, 35)
        Me.cboxNave.Name = "cboxNave"
        Me.cboxNave.Size = New System.Drawing.Size(221, 21)
        Me.cboxNave.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.Controls.Add(Me.chboxCajaAhorro)
        Me.GroupBox1.Controls.Add(Me.chboxPyA)
        Me.GroupBox1.Location = New System.Drawing.Point(533, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(163, 66)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Incentivos"
        '
        'chboxCajaAhorro
        '
        Me.chboxCajaAhorro.AutoSize = True
        Me.chboxCajaAhorro.Location = New System.Drawing.Point(6, 42)
        Me.chboxCajaAhorro.Name = "chboxCajaAhorro"
        Me.chboxCajaAhorro.Size = New System.Drawing.Size(95, 17)
        Me.chboxCajaAhorro.TabIndex = 29
        Me.chboxCajaAhorro.Text = "Caja de ahorro"
        Me.ToolTip1.SetToolTip(Me.chboxCajaAhorro, "Gana si esta marcado. Pierde si no esta marcado")
        Me.chboxCajaAhorro.UseVisualStyleBackColor = True
        '
        'chboxPyA
        '
        Me.chboxPyA.AutoSize = True
        Me.chboxPyA.Location = New System.Drawing.Point(6, 19)
        Me.chboxPyA.Name = "chboxPyA"
        Me.chboxPyA.Size = New System.Drawing.Size(140, 17)
        Me.chboxPyA.TabIndex = 28
        Me.chboxPyA.Text = "Puntualidad y asistencia"
        Me.ToolTip1.SetToolTip(Me.chboxPyA, "Gana si esta marcado. Pierde si no esta marcado")
        Me.chboxPyA.UseVisualStyleBackColor = True
        '
        'lblNave
        '
        Me.lblNave.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(179, 35)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(40, 13)
        Me.lblNave.TabIndex = 0
        Me.lblNave.Text = "* Nave"
        '
        'lblDepartamento
        '
        Me.lblDepartamento.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(179, 72)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(81, 13)
        Me.lblDepartamento.TabIndex = 1
        Me.lblDepartamento.Text = "* Departamento"
        '
        'cboxColaborador
        '
        Me.cboxColaborador.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cboxColaborador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxColaborador.FormattingEnabled = True
        Me.cboxColaborador.Location = New System.Drawing.Point(278, 109)
        Me.cboxColaborador.Name = "cboxColaborador"
        Me.cboxColaborador.Size = New System.Drawing.Size(221, 21)
        Me.cboxColaborador.TabIndex = 25
        '
        'cboxDepartamento
        '
        Me.cboxDepartamento.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cboxDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxDepartamento.FormattingEnabled = True
        Me.cboxDepartamento.Location = New System.Drawing.Point(278, 72)
        Me.cboxDepartamento.Name = "cboxDepartamento"
        Me.cboxDepartamento.Size = New System.Drawing.Size(221, 21)
        Me.cboxDepartamento.TabIndex = 20
        '
        'lblColaborador
        '
        Me.lblColaborador.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblColaborador.AutoSize = True
        Me.lblColaborador.Location = New System.Drawing.Point(186, 109)
        Me.lblColaborador.Name = "lblColaborador"
        Me.lblColaborador.Size = New System.Drawing.Size(64, 13)
        Me.lblColaborador.TabIndex = 23
        Me.lblColaborador.Text = "Colaborador"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(581, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 31
        Me.pcbTitulo.TabStop = False
        '
        'RegistroExcepcionesAltaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(802, 485)
        Me.Controls.Add(Me.pnlContenido)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlPie)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(808, 507)
        Me.MinimumSize = New System.Drawing.Size(808, 507)
        Me.Name = "RegistroExcepcionesAltaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud de Permiso o Excepción"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlContenido.PerformLayout()
        Me.pnlAreaTrabajo.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpBloque.ResumeLayout(False)
        Me.grpBloque.PerformLayout()
        CType(Me.picboxColaborador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlContenido As System.Windows.Forms.Panel
    Friend WithEvents pnlAreaTrabajo As System.Windows.Forms.Panel
    Friend WithEvents cboxMotivoPermiso As System.Windows.Forms.ComboBox
    Friend WithEvents lblMotivoPermiso As System.Windows.Forms.Label
    Friend WithEvents cboxTipoPermiso As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoPermiso As System.Windows.Forms.Label
    Friend WithEvents cboxNave As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chboxCajaAhorro As System.Windows.Forms.CheckBox
    Friend WithEvents chboxPyA As System.Windows.Forms.CheckBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents cboxColaborador As System.Windows.Forms.ComboBox
    Friend WithEvents cboxDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents lblColaborador As System.Windows.Forms.Label
    Friend WithEvents txtboxNota As System.Windows.Forms.TextBox
    Friend WithEvents lblNota As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaTermino As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHoraInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHoraFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents picboxColaborador As System.Windows.Forms.PictureBox
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grpBloque As System.Windows.Forms.GroupBox
    Friend WithEvents chkRegreso As System.Windows.Forms.CheckBox
    Friend WithEvents chkEntrada As System.Windows.Forms.CheckBox
    Friend WithEvents pcbTitulo As PictureBox
End Class
