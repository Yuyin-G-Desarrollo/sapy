<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaCitaEntregaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaCitaEntregaForm))
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlListaCliente = New System.Windows.Forms.Panel()
        Me.cmbHorarioFechaEntrega = New System.Windows.Forms.ComboBox()
        Me.cmbMinutoFechaEntrega = New System.Windows.Forms.ComboBox()
        Me.cmbHoraFechaEntrega = New System.Windows.Forms.ComboBox()
        Me.nudPersonasDescarga = New System.Windows.Forms.NumericUpDown()
        Me.dtpFechaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.txtCantidadPares = New System.Windows.Forms.TextBox()
        Me.txtClienteNombre = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFechaEntrega = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPares = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblTextoGuardar = New System.Windows.Forms.Label()
        Me.lblTextoCerrar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlMarcarTodo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlListaCliente.SuspendLayout()
        CType(Me.nudPersonasDescarga, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlContenedor.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(330, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlListaCliente
        '
        Me.pnlListaCliente.Controls.Add(Me.cmbHorarioFechaEntrega)
        Me.pnlListaCliente.Controls.Add(Me.cmbMinutoFechaEntrega)
        Me.pnlListaCliente.Controls.Add(Me.cmbHoraFechaEntrega)
        Me.pnlListaCliente.Controls.Add(Me.nudPersonasDescarga)
        Me.pnlListaCliente.Controls.Add(Me.dtpFechaEntrega)
        Me.pnlListaCliente.Controls.Add(Me.txtObservaciones)
        Me.pnlListaCliente.Controls.Add(Me.txtClave)
        Me.pnlListaCliente.Controls.Add(Me.txtCantidadPares)
        Me.pnlListaCliente.Controls.Add(Me.txtClienteNombre)
        Me.pnlListaCliente.Controls.Add(Me.Label3)
        Me.pnlListaCliente.Controls.Add(Me.lblFechaEntrega)
        Me.pnlListaCliente.Controls.Add(Me.Label2)
        Me.pnlListaCliente.Controls.Add(Me.lblClave)
        Me.pnlListaCliente.Controls.Add(Me.Label1)
        Me.pnlListaCliente.Controls.Add(Me.lblPares)
        Me.pnlListaCliente.Controls.Add(Me.lblCliente)
        Me.pnlListaCliente.Controls.Add(Me.pnlPie)
        Me.pnlListaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListaCliente.Location = New System.Drawing.Point(0, 59)
        Me.pnlListaCliente.Name = "pnlListaCliente"
        Me.pnlListaCliente.Size = New System.Drawing.Size(398, 365)
        Me.pnlListaCliente.TabIndex = 3
        '
        'cmbHorarioFechaEntrega
        '
        Me.cmbHorarioFechaEntrega.FormattingEnabled = True
        Me.cmbHorarioFechaEntrega.Items.AddRange(New Object() {"a.m.", "p.m."})
        Me.cmbHorarioFechaEntrega.Location = New System.Drawing.Point(336, 92)
        Me.cmbHorarioFechaEntrega.Name = "cmbHorarioFechaEntrega"
        Me.cmbHorarioFechaEntrega.Size = New System.Drawing.Size(44, 21)
        Me.cmbHorarioFechaEntrega.TabIndex = 6
        Me.cmbHorarioFechaEntrega.Text = "p.m."
        '
        'cmbMinutoFechaEntrega
        '
        Me.cmbMinutoFechaEntrega.FormattingEnabled = True
        Me.cmbMinutoFechaEntrega.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59"})
        Me.cmbMinutoFechaEntrega.Location = New System.Drawing.Point(293, 92)
        Me.cmbMinutoFechaEntrega.Name = "cmbMinutoFechaEntrega"
        Me.cmbMinutoFechaEntrega.Size = New System.Drawing.Size(39, 21)
        Me.cmbMinutoFechaEntrega.TabIndex = 5
        Me.cmbMinutoFechaEntrega.Text = "00"
        '
        'cmbHoraFechaEntrega
        '
        Me.cmbHoraFechaEntrega.FormattingEnabled = True
        Me.cmbHoraFechaEntrega.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cmbHoraFechaEntrega.Location = New System.Drawing.Point(245, 92)
        Me.cmbHoraFechaEntrega.Name = "cmbHoraFechaEntrega"
        Me.cmbHoraFechaEntrega.Size = New System.Drawing.Size(39, 21)
        Me.cmbHoraFechaEntrega.TabIndex = 4
        Me.cmbHoraFechaEntrega.Text = "12"
        '
        'nudPersonasDescarga
        '
        Me.nudPersonasDescarga.Location = New System.Drawing.Point(145, 154)
        Me.nudPersonasDescarga.Name = "nudPersonasDescarga"
        Me.nudPersonasDescarga.Size = New System.Drawing.Size(77, 20)
        Me.nudPersonasDescarga.TabIndex = 8
        Me.nudPersonasDescarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.CustomFormat = ""
        Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(123, 92)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(108, 20)
        Me.dtpFechaEntrega.TabIndex = 3
        Me.dtpFechaEntrega.Value = New Date(2017, 4, 25, 15, 16, 0, 0)
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(101, 188)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(283, 100)
        Me.txtObservaciones.TabIndex = 9
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(83, 122)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(97, 20)
        Me.txtClave.TabIndex = 7
        Me.txtClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCantidadPares
        '
        Me.txtCantidadPares.Enabled = False
        Me.txtCantidadPares.Location = New System.Drawing.Point(83, 62)
        Me.txtCantidadPares.Name = "txtCantidadPares"
        Me.txtCantidadPares.ReadOnly = True
        Me.txtCantidadPares.Size = New System.Drawing.Size(97, 20)
        Me.txtCantidadPares.TabIndex = 2
        Me.txtCantidadPares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtClienteNombre
        '
        Me.txtClienteNombre.Enabled = False
        Me.txtClienteNombre.Location = New System.Drawing.Point(83, 31)
        Me.txtClienteNombre.Name = "txtClienteNombre"
        Me.txtClienteNombre.ReadOnly = True
        Me.txtClienteNombre.Size = New System.Drawing.Size(301, 20)
        Me.txtClienteNombre.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(284, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = ":"
        '
        'lblFechaEntrega
        '
        Me.lblFechaEntrega.AutoSize = True
        Me.lblFechaEntrega.Location = New System.Drawing.Point(17, 95)
        Me.lblFechaEntrega.Name = "lblFechaEntrega"
        Me.lblFechaEntrega.Size = New System.Drawing.Size(95, 13)
        Me.lblFechaEntrega.TabIndex = 65
        Me.lblFechaEntrega.Text = "*Fecha de entrega"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 191)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Observaciones"
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.Location = New System.Drawing.Point(17, 126)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(34, 13)
        Me.lblClave.TabIndex = 65
        Me.lblClave.Text = "Clave"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 13)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "Personas para descarga"
        '
        'lblPares
        '
        Me.lblPares.AutoSize = True
        Me.lblPares.Location = New System.Drawing.Point(17, 66)
        Me.lblPares.Name = "lblPares"
        Me.lblPares.Size = New System.Drawing.Size(34, 13)
        Me.lblPares.TabIndex = 65
        Me.lblPares.Text = "Pares"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(17, 34)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblCliente.TabIndex = 65
        Me.lblCliente.Text = "Cliente"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 294)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(398, 71)
        Me.pnlPie.TabIndex = 64
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblTextoGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.lblTextoCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(254, 0)
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
        Me.btnCerrar.TabIndex = 11
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
        'btnGuardar
        '
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(31, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'pnlMarcarTodo
        '
        Me.pnlMarcarTodo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlMarcarTodo.Location = New System.Drawing.Point(0, 0)
        Me.pnlMarcarTodo.Name = "pnlMarcarTodo"
        Me.pnlMarcarTodo.Size = New System.Drawing.Size(88, 41)
        Me.pnlMarcarTodo.TabIndex = 47
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlMarcarTodo)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(330, 41)
        Me.Panel1.TabIndex = 47
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(181, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(149, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Cita para entrega"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(398, 59)
        Me.pnlTitulo.TabIndex = 20
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(398, 59)
        Me.pnlEncabezado.TabIndex = 25
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlEncabezado)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(398, 59)
        Me.pnlCabecera.TabIndex = 1
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlListaCliente)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(398, 424)
        Me.pnlContenedor.TabIndex = 5
        '
        'AltaCitaEntregaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 424)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AltaCitaEntregaForm"
        Me.Text = "Cita para entrega"
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlListaCliente.ResumeLayout(False)
        Me.pnlListaCliente.PerformLayout()
        CType(Me.nudPersonasDescarga, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlContenedor.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents pnlListaCliente As System.Windows.Forms.Panel
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblTextoGuardar As System.Windows.Forms.Label
    Friend WithEvents lblTextoCerrar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents pnlMarcarTodo As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents nudPersonasDescarga As System.Windows.Forms.NumericUpDown
    Friend WithEvents dtpFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidadPares As System.Windows.Forms.TextBox
    Friend WithEvents txtClienteNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaEntrega As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPares As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents cmbHorarioFechaEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbMinutoFechaEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents cmbHoraFechaEntrega As System.Windows.Forms.ComboBox
End Class
