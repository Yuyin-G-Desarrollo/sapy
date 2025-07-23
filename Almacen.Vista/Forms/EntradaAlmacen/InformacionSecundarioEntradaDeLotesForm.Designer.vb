<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InformacionSecundarioEntradaDeLotesForm
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
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.grbDias = New System.Windows.Forms.GroupBox()
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.cboxNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.DateStart = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.lblFechaFin = New System.Windows.Forms.Label()
        Me.dateFin = New System.Windows.Forms.DateTimePicker()
        Me.pnlCampos = New System.Windows.Forms.Panel()
        Me.cmbComercializadora = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.grbDias.SuspendLayout()
        Me.pnlCampos.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(339, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(129, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(210, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(29, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(175, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Entrada de Producto"
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlTitulo)
        Me.pnlCabecera.Controls.Add(Me.imgLogo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(409, 60)
        Me.pnlCabecera.TabIndex = 34
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Almacen.Vista.My.Resources.Resources.aceptar_321
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(317, 3)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(313, 38)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(44, 13)
        Me.lblAceptar.TabIndex = 62
        Me.lblAceptar.Text = "Aceptar"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.BackColor = System.Drawing.Color.White
        Me.pnlAcciones.Controls.Add(Me.Label1)
        Me.pnlAcciones.Controls.Add(Me.Button1)
        Me.pnlAcciones.Controls.Add(Me.lblAceptar)
        Me.pnlAcciones.Controls.Add(Me.btnAceptar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 170)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(409, 60)
        Me.pnlAcciones.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(362, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Cerrar"
        '
        'Button1
        '
        Me.Button1.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.Button1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1.Location = New System.Drawing.Point(365, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 63
        Me.Button1.UseVisualStyleBackColor = True
        '
        'grbDias
        '
        Me.grbDias.Controls.Add(Me.cmbComercializadora)
        Me.grbDias.Controls.Add(Me.Label2)
        Me.grbDias.Controls.Add(Me.cmbAlmacen)
        Me.grbDias.Controls.Add(Me.lblAlmacen)
        Me.grbDias.Controls.Add(Me.cboxNave)
        Me.grbDias.Controls.Add(Me.lblNave)
        Me.grbDias.Controls.Add(Me.DateStart)
        Me.grbDias.Controls.Add(Me.lblFechaInicio)
        Me.grbDias.Controls.Add(Me.txtFolio)
        Me.grbDias.Controls.Add(Me.lblFolio)
        Me.grbDias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbDias.Location = New System.Drawing.Point(0, 0)
        Me.grbDias.Name = "grbDias"
        Me.grbDias.Size = New System.Drawing.Size(409, 95)
        Me.grbDias.TabIndex = 29
        Me.grbDias.TabStop = False
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.ItemHeight = 13
        Me.cmbAlmacen.Items.AddRange(New Object() {"1", "2"})
        Me.cmbAlmacen.Location = New System.Drawing.Point(333, 69)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(44, 21)
        Me.cmbAlmacen.TabIndex = 34
        '
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.ForeColor = System.Drawing.Color.Black
        Me.lblAlmacen.Location = New System.Drawing.Point(279, 73)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(48, 13)
        Me.lblAlmacen.TabIndex = 35
        Me.lblAlmacen.Text = "Almacén"
        '
        'cboxNave
        '
        Me.cboxNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxNave.FormattingEnabled = True
        Me.cboxNave.ItemHeight = 13
        Me.cboxNave.Location = New System.Drawing.Point(128, 16)
        Me.cboxNave.Name = "cboxNave"
        Me.cboxNave.Size = New System.Drawing.Size(249, 21)
        Me.cboxNave.TabIndex = 2
        Me.cboxNave.Visible = False
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(74, 19)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(37, 13)
        Me.lblNave.TabIndex = 33
        Me.lblNave.Text = "Nave*"
        Me.lblNave.Visible = False
        '
        'DateStart
        '
        Me.DateStart.CustomFormat = "yyyy/MM/dd"
        Me.DateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateStart.Location = New System.Drawing.Point(128, 43)
        Me.DateStart.Name = "DateStart"
        Me.DateStart.Size = New System.Drawing.Size(92, 20)
        Me.DateStart.TabIndex = 2
        Me.DateStart.Visible = False
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.ForeColor = System.Drawing.Color.Black
        Me.lblFechaInicio.Location = New System.Drawing.Point(42, 46)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(69, 13)
        Me.lblFechaInicio.TabIndex = 29
        Me.lblFechaInicio.Text = "Fecha Inicio*"
        Me.lblFechaInicio.Visible = False
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(162, 43)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(176, 20)
        Me.txtFolio.TabIndex = 3
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.ForeColor = System.Drawing.Color.Black
        Me.lblFolio.Location = New System.Drawing.Point(59, 46)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(101, 13)
        Me.lblFolio.TabIndex = 25
        Me.lblFolio.Text = "*Folio de embarque:"
        '
        'lblFechaFin
        '
        Me.lblFechaFin.AutoSize = True
        Me.lblFechaFin.ForeColor = System.Drawing.Color.Black
        Me.lblFechaFin.Location = New System.Drawing.Point(85, 136)
        Me.lblFechaFin.Name = "lblFechaFin"
        Me.lblFechaFin.Size = New System.Drawing.Size(58, 13)
        Me.lblFechaFin.TabIndex = 30
        Me.lblFechaFin.Text = "Fecha Fin*"
        Me.lblFechaFin.Visible = False
        '
        'dateFin
        '
        Me.dateFin.CustomFormat = "yyyy/MM/dd"
        Me.dateFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateFin.Location = New System.Drawing.Point(171, 133)
        Me.dateFin.Name = "dateFin"
        Me.dateFin.Size = New System.Drawing.Size(92, 20)
        Me.dateFin.TabIndex = 4
        Me.dateFin.Visible = False
        '
        'pnlCampos
        '
        Me.pnlCampos.Controls.Add(Me.grbDias)
        Me.pnlCampos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCampos.Location = New System.Drawing.Point(0, 60)
        Me.pnlCampos.Name = "pnlCampos"
        Me.pnlCampos.Size = New System.Drawing.Size(409, 95)
        Me.pnlCampos.TabIndex = 36
        '
        'cmbComercializadora
        '
        Me.cmbComercializadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComercializadora.FormattingEnabled = True
        Me.cmbComercializadora.ItemHeight = 13
        Me.cmbComercializadora.Items.AddRange(New Object() {"1", "2"})
        Me.cmbComercializadora.Location = New System.Drawing.Point(128, 71)
        Me.cmbComercializadora.Name = "cmbComercializadora"
        Me.cmbComercializadora.Size = New System.Drawing.Size(145, 21)
        Me.cmbComercializadora.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(35, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Comercializadora"
        '
        'InformacionSecundarioEntradaDeLotesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(409, 230)
        Me.Controls.Add(Me.pnlCampos)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.lblFechaFin)
        Me.Controls.Add(Me.dateFin)
        Me.Controls.Add(Me.pnlCabecera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InformacionSecundarioEntradaDeLotesForm"
        Me.Text = "Entrada de Producto"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.grbDias.ResumeLayout(False)
        Me.grbDias.PerformLayout()
        Me.pnlCampos.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents grbDias As System.Windows.Forms.GroupBox
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents pnlCampos As System.Windows.Forms.Panel
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents DateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaFin As System.Windows.Forms.Label
    Friend WithEvents dateFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents cboxNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacen As ComboBox
    Friend WithEvents lblAlmacen As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbComercializadora As ComboBox
    Friend WithEvents Label2 As Label
End Class
