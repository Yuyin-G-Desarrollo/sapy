<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaEmbarqueAgendaEntregaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaEmbarqueAgendaEntregaForm))
        Me.lblTextoCerrar = New System.Windows.Forms.Label()
        Me.pnlMarcarTodo = New System.Windows.Forms.Panel()
        Me.cmbHorarioFechaEntrega = New System.Windows.Forms.ComboBox()
        Me.cmbMinutoFechaEntrega = New System.Windows.Forms.ComboBox()
        Me.cmbHoraFechaEntrega = New System.Windows.Forms.ComboBox()
        Me.dtpFechaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFechaEntrega = New System.Windows.Forms.Label()
        Me.lblUnidad = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlListaCliente = New System.Windows.Forms.Panel()
        Me.cmbHorarioFechaRegreso = New System.Windows.Forms.ComboBox()
        Me.cmbMinutoFechaRegreso = New System.Windows.Forms.ComboBox()
        Me.cmbHoraFechaRegreso = New System.Windows.Forms.ComboBox()
        Me.dtpfechaRegreso = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbOperador = New System.Windows.Forms.ComboBox()
        Me.cmbPaqueteria = New System.Windows.Forms.ComboBox()
        Me.cmbUnidad = New System.Windows.Forms.ComboBox()
        Me.lblOperador = New System.Windows.Forms.Label()
        Me.lblPaqueteria = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblTextoGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlListaCliente.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTextoCerrar
        '
        Me.lblTextoCerrar.AutoSize = True
        Me.lblTextoCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextoCerrar.Location = New System.Drawing.Point(85, 43)
        Me.lblTextoCerrar.Name = "lblTextoCerrar"
        Me.lblTextoCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblTextoCerrar.TabIndex = 0
        Me.lblTextoCerrar.Text = "Cerrar"
        '
        'pnlMarcarTodo
        '
        Me.pnlMarcarTodo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlMarcarTodo.Location = New System.Drawing.Point(0, 0)
        Me.pnlMarcarTodo.Name = "pnlMarcarTodo"
        Me.pnlMarcarTodo.Size = New System.Drawing.Size(88, 41)
        Me.pnlMarcarTodo.TabIndex = 47
        '
        'cmbHorarioFechaEntrega
        '
        Me.cmbHorarioFechaEntrega.FormattingEnabled = True
        Me.cmbHorarioFechaEntrega.Items.AddRange(New Object() {"a.m.", "p.m."})
        Me.cmbHorarioFechaEntrega.Location = New System.Drawing.Point(356, 23)
        Me.cmbHorarioFechaEntrega.Name = "cmbHorarioFechaEntrega"
        Me.cmbHorarioFechaEntrega.Size = New System.Drawing.Size(44, 21)
        Me.cmbHorarioFechaEntrega.TabIndex = 70
        Me.cmbHorarioFechaEntrega.Text = "p.m."
        '
        'cmbMinutoFechaEntrega
        '
        Me.cmbMinutoFechaEntrega.FormattingEnabled = True
        Me.cmbMinutoFechaEntrega.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59"})
        Me.cmbMinutoFechaEntrega.Location = New System.Drawing.Point(313, 23)
        Me.cmbMinutoFechaEntrega.Name = "cmbMinutoFechaEntrega"
        Me.cmbMinutoFechaEntrega.Size = New System.Drawing.Size(39, 21)
        Me.cmbMinutoFechaEntrega.TabIndex = 69
        Me.cmbMinutoFechaEntrega.Text = "00"
        '
        'cmbHoraFechaEntrega
        '
        Me.cmbHoraFechaEntrega.FormattingEnabled = True
        Me.cmbHoraFechaEntrega.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cmbHoraFechaEntrega.Location = New System.Drawing.Point(265, 23)
        Me.cmbHoraFechaEntrega.Name = "cmbHoraFechaEntrega"
        Me.cmbHoraFechaEntrega.Size = New System.Drawing.Size(39, 21)
        Me.cmbHoraFechaEntrega.TabIndex = 69
        Me.cmbHoraFechaEntrega.Text = "12"
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.CustomFormat = ""
        Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(143, 23)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(108, 20)
        Me.dtpFechaEntrega.TabIndex = 67
        Me.dtpFechaEntrega.Value = New Date(2017, 5, 8, 0, 0, 0, 0)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlMarcarTodo)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(379, 41)
        Me.Panel1.TabIndex = 47
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(182, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(197, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Agenda para embarque"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(447, 59)
        Me.pnlTitulo.TabIndex = 20
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(379, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(304, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = ":"
        '
        'lblFechaEntrega
        '
        Me.lblFechaEntrega.AutoSize = True
        Me.lblFechaEntrega.Location = New System.Drawing.Point(37, 26)
        Me.lblFechaEntrega.Name = "lblFechaEntrega"
        Me.lblFechaEntrega.Size = New System.Drawing.Size(95, 13)
        Me.lblFechaEntrega.TabIndex = 65
        Me.lblFechaEntrega.Text = "*Fecha de entrega"
        '
        'lblUnidad
        '
        Me.lblUnidad.AutoSize = True
        Me.lblUnidad.Location = New System.Drawing.Point(37, 134)
        Me.lblUnidad.Name = "lblUnidad"
        Me.lblUnidad.Size = New System.Drawing.Size(41, 13)
        Me.lblUnidad.TabIndex = 65
        Me.lblUnidad.Text = "Unidad"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(447, 59)
        Me.pnlEncabezado.TabIndex = 25
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlListaCliente)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(447, 355)
        Me.pnlContenedor.TabIndex = 6
        '
        'pnlListaCliente
        '
        Me.pnlListaCliente.Controls.Add(Me.cmbHorarioFechaRegreso)
        Me.pnlListaCliente.Controls.Add(Me.cmbMinutoFechaRegreso)
        Me.pnlListaCliente.Controls.Add(Me.cmbHoraFechaRegreso)
        Me.pnlListaCliente.Controls.Add(Me.dtpfechaRegreso)
        Me.pnlListaCliente.Controls.Add(Me.Label1)
        Me.pnlListaCliente.Controls.Add(Me.cmbOperador)
        Me.pnlListaCliente.Controls.Add(Me.cmbPaqueteria)
        Me.pnlListaCliente.Controls.Add(Me.cmbUnidad)
        Me.pnlListaCliente.Controls.Add(Me.cmbHorarioFechaEntrega)
        Me.pnlListaCliente.Controls.Add(Me.cmbMinutoFechaEntrega)
        Me.pnlListaCliente.Controls.Add(Me.cmbHoraFechaEntrega)
        Me.pnlListaCliente.Controls.Add(Me.dtpFechaEntrega)
        Me.pnlListaCliente.Controls.Add(Me.lblOperador)
        Me.pnlListaCliente.Controls.Add(Me.Label3)
        Me.pnlListaCliente.Controls.Add(Me.lblPaqueteria)
        Me.pnlListaCliente.Controls.Add(Me.lblFechaEntrega)
        Me.pnlListaCliente.Controls.Add(Me.lblUnidad)
        Me.pnlListaCliente.Controls.Add(Me.pnlPie)
        Me.pnlListaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListaCliente.Location = New System.Drawing.Point(0, 59)
        Me.pnlListaCliente.Name = "pnlListaCliente"
        Me.pnlListaCliente.Size = New System.Drawing.Size(447, 296)
        Me.pnlListaCliente.TabIndex = 3
        '
        'cmbHorarioFechaRegreso
        '
        Me.cmbHorarioFechaRegreso.FormattingEnabled = True
        Me.cmbHorarioFechaRegreso.Items.AddRange(New Object() {"a.m.", "p.m."})
        Me.cmbHorarioFechaRegreso.Location = New System.Drawing.Point(234, 56)
        Me.cmbHorarioFechaRegreso.Name = "cmbHorarioFechaRegreso"
        Me.cmbHorarioFechaRegreso.Size = New System.Drawing.Size(44, 21)
        Me.cmbHorarioFechaRegreso.TabIndex = 76
        Me.cmbHorarioFechaRegreso.Text = "p.m."
        '
        'cmbMinutoFechaRegreso
        '
        Me.cmbMinutoFechaRegreso.FormattingEnabled = True
        Me.cmbMinutoFechaRegreso.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59"})
        Me.cmbMinutoFechaRegreso.Location = New System.Drawing.Point(191, 56)
        Me.cmbMinutoFechaRegreso.Name = "cmbMinutoFechaRegreso"
        Me.cmbMinutoFechaRegreso.Size = New System.Drawing.Size(39, 21)
        Me.cmbMinutoFechaRegreso.TabIndex = 74
        Me.cmbMinutoFechaRegreso.Text = "00"
        '
        'cmbHoraFechaRegreso
        '
        Me.cmbHoraFechaRegreso.FormattingEnabled = True
        Me.cmbHoraFechaRegreso.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cmbHoraFechaRegreso.Location = New System.Drawing.Point(143, 56)
        Me.cmbHoraFechaRegreso.Name = "cmbHoraFechaRegreso"
        Me.cmbHoraFechaRegreso.Size = New System.Drawing.Size(39, 21)
        Me.cmbHoraFechaRegreso.TabIndex = 75
        Me.cmbHoraFechaRegreso.Text = "12"
        '
        'dtpfechaRegreso
        '
        Me.dtpfechaRegreso.CustomFormat = ""
        Me.dtpfechaRegreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechaRegreso.Location = New System.Drawing.Point(292, 57)
        Me.dtpfechaRegreso.Name = "dtpfechaRegreso"
        Me.dtpfechaRegreso.Size = New System.Drawing.Size(108, 20)
        Me.dtpfechaRegreso.TabIndex = 73
        Me.dtpfechaRegreso.Value = New Date(2017, 5, 8, 0, 0, 0, 0)
        Me.dtpfechaRegreso.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "*Hora estimada regreso"
        '
        'cmbOperador
        '
        Me.cmbOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperador.Enabled = False
        Me.cmbOperador.FormattingEnabled = True
        Me.cmbOperador.Location = New System.Drawing.Point(103, 166)
        Me.cmbOperador.Name = "cmbOperador"
        Me.cmbOperador.Size = New System.Drawing.Size(297, 21)
        Me.cmbOperador.TabIndex = 71
        '
        'cmbPaqueteria
        '
        Me.cmbPaqueteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaqueteria.FormattingEnabled = True
        Me.cmbPaqueteria.Location = New System.Drawing.Point(103, 98)
        Me.cmbPaqueteria.Name = "cmbPaqueteria"
        Me.cmbPaqueteria.Size = New System.Drawing.Size(297, 21)
        Me.cmbPaqueteria.TabIndex = 71
        '
        'cmbUnidad
        '
        Me.cmbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnidad.Enabled = False
        Me.cmbUnidad.FormattingEnabled = True
        Me.cmbUnidad.Location = New System.Drawing.Point(103, 131)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.Size = New System.Drawing.Size(297, 21)
        Me.cmbUnidad.TabIndex = 71
        '
        'lblOperador
        '
        Me.lblOperador.AutoSize = True
        Me.lblOperador.Location = New System.Drawing.Point(37, 169)
        Me.lblOperador.Name = "lblOperador"
        Me.lblOperador.Size = New System.Drawing.Size(51, 13)
        Me.lblOperador.TabIndex = 65
        Me.lblOperador.Text = "Operador"
        '
        'lblPaqueteria
        '
        Me.lblPaqueteria.AutoSize = True
        Me.lblPaqueteria.Location = New System.Drawing.Point(37, 101)
        Me.lblPaqueteria.Name = "lblPaqueteria"
        Me.lblPaqueteria.Size = New System.Drawing.Size(60, 13)
        Me.lblPaqueteria.TabIndex = 65
        Me.lblPaqueteria.Text = "Paquetería"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 225)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(447, 71)
        Me.pnlPie.TabIndex = 64
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblTextoGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.lblTextoCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(303, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(144, 71)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(86, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblTextoGuardar
        '
        Me.lblTextoGuardar.AutoSize = True
        Me.lblTextoGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextoGuardar.Location = New System.Drawing.Point(26, 43)
        Me.lblTextoGuardar.Name = "lblTextoGuardar"
        Me.lblTextoGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblTextoGuardar.TabIndex = 0
        Me.lblTextoGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(31, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlEncabezado)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(447, 59)
        Me.pnlCabecera.TabIndex = 1
        '
        'AltaEmbarqueAgendaEntregaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 355)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AltaEmbarqueAgendaEntregaForm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlListaCliente.ResumeLayout(False)
        Me.pnlListaCliente.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTextoCerrar As System.Windows.Forms.Label
    Friend WithEvents pnlMarcarTodo As System.Windows.Forms.Panel
    Friend WithEvents cmbHorarioFechaEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMinutoFechaEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents cmbHoraFechaEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFechaEntrega As System.Windows.Forms.Label
    Friend WithEvents lblUnidad As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents pnlListaCliente As System.Windows.Forms.Panel
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblTextoGuardar As System.Windows.Forms.Label
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents cmbOperador As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPaqueteria As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents lblOperador As System.Windows.Forms.Label
    Friend WithEvents lblPaqueteria As System.Windows.Forms.Label
    Friend WithEvents cmbHorarioFechaRegreso As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMinutoFechaRegreso As System.Windows.Forms.ComboBox
    Friend WithEvents cmbHoraFechaRegreso As System.Windows.Forms.ComboBox
    Friend WithEvents dtpfechaRegreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
