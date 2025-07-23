<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CopiarListaPrecioForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CopiarListaPrecioForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.txtColeccion = New System.Windows.Forms.TextBox()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNombreLista = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblA = New System.Windows.Forms.Label()
        Me.lblDe = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtColeccion2 = New System.Windows.Forms.TextBox()
        Me.txtMarca2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombreLista2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpFechaFinal2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio2 = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbNave2 = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(743, 60)
        Me.pnlHeader.TabIndex = 66
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(533, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(210, 60)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(31, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(105, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Copiar Lista"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnlBotones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 337)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(743, 60)
        Me.Panel1.TabIndex = 67
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.Button1)
        Me.pnlBotones.Controls.Add(Me.Label4)
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(497, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(246, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.guardar2_32
        Me.Button1.Location = New System.Drawing.Point(157, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 70
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(154, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "Guardar"
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(196, 7)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 0
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(196, 42)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Controls.Add(Me.txtColeccion)
        Me.grbParametros.Controls.Add(Me.txtMarca)
        Me.grbParametros.Controls.Add(Me.Label12)
        Me.grbParametros.Controls.Add(Me.Label11)
        Me.grbParametros.Controls.Add(Me.txtNombreLista)
        Me.grbParametros.Controls.Add(Me.Label8)
        Me.grbParametros.Controls.Add(Me.lblEstatus)
        Me.grbParametros.Controls.Add(Me.Label6)
        Me.grbParametros.Controls.Add(Me.dtpFechaFinal)
        Me.grbParametros.Controls.Add(Me.dtpFechaInicio)
        Me.grbParametros.Controls.Add(Me.lblA)
        Me.grbParametros.Controls.Add(Me.lblDe)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Controls.Add(Me.Label7)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 60)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(743, 130)
        Me.grbParametros.TabIndex = 68
        Me.grbParametros.TabStop = False
        '
        'txtColeccion
        '
        Me.txtColeccion.Location = New System.Drawing.Point(445, 99)
        Me.txtColeccion.Name = "txtColeccion"
        Me.txtColeccion.ReadOnly = True
        Me.txtColeccion.Size = New System.Drawing.Size(233, 20)
        Me.txtColeccion.TabIndex = 93
        '
        'txtMarca
        '
        Me.txtMarca.Location = New System.Drawing.Point(445, 73)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(233, 20)
        Me.txtMarca.TabIndex = 92
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(385, 102)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 91
        Me.Label12.Text = "Colección"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(402, 76)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 89
        Me.Label11.Text = "Marca"
        '
        'txtNombreLista
        '
        Me.txtNombreLista.Location = New System.Drawing.Point(103, 77)
        Me.txtNombreLista.Name = "txtNombreLista"
        Me.txtNombreLista.ReadOnly = True
        Me.txtNombreLista.Size = New System.Drawing.Size(243, 20)
        Me.txtNombreLista.TabIndex = 88
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 13)
        Me.Label8.TabIndex = 87
        Me.Label8.Text = "Nombre de la lista"
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatus.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblEstatus.Location = New System.Drawing.Point(100, 22)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(82, 13)
        Me.lblEstatus.TabIndex = 86
        Me.lblEstatus.Text = "CAPTURADA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(55, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 85
        Me.Label6.Text = "Estatus"
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Enabled = False
        Me.dtpFechaFinal.Location = New System.Drawing.Point(445, 46)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(233, 20)
        Me.dtpFechaFinal.TabIndex = 84
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Enabled = False
        Me.dtpFechaInicio.Location = New System.Drawing.Point(445, 19)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(233, 20)
        Me.dtpFechaInicio.TabIndex = 83
        '
        'lblA
        '
        Me.lblA.AutoSize = True
        Me.lblA.Location = New System.Drawing.Point(380, 48)
        Me.lblA.Name = "lblA"
        Me.lblA.Size = New System.Drawing.Size(62, 13)
        Me.lblA.TabIndex = 82
        Me.lblA.Text = "Vigencia fin"
        '
        'lblDe
        '
        Me.lblDe.AutoSize = True
        Me.lblDe.Location = New System.Drawing.Point(368, 22)
        Me.lblDe.Name = "lblDe"
        Me.lblDe.Size = New System.Drawing.Size(75, 13)
        Me.lblDe.TabIndex = 81
        Me.lblDe.Text = "Vigencia inicio"
        '
        'cmbNave
        '
        Me.cmbNave.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbNave.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbNave.Enabled = False
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(103, 49)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(243, 21)
        Me.cmbNave.TabIndex = 73
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(56, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "Nave"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox1.Controls.Add(Me.txtColeccion2)
        Me.GroupBox1.Controls.Add(Me.txtMarca2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtNombreLista2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.dtpFechaFinal2)
        Me.GroupBox1.Controls.Add(Me.dtpFechaInicio2)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cmbNave2)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(0, 190)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(743, 130)
        Me.GroupBox1.TabIndex = 69
        Me.GroupBox1.TabStop = False
        '
        'txtColeccion2
        '
        Me.txtColeccion2.Location = New System.Drawing.Point(445, 99)
        Me.txtColeccion2.Name = "txtColeccion2"
        Me.txtColeccion2.ReadOnly = True
        Me.txtColeccion2.Size = New System.Drawing.Size(233, 20)
        Me.txtColeccion2.TabIndex = 93
        '
        'txtMarca2
        '
        Me.txtMarca2.Location = New System.Drawing.Point(445, 73)
        Me.txtMarca2.Name = "txtMarca2"
        Me.txtMarca2.ReadOnly = True
        Me.txtMarca2.Size = New System.Drawing.Size(233, 20)
        Me.txtMarca2.TabIndex = 92
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(385, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Colección"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(402, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 89
        Me.Label2.Text = "Marca"
        '
        'txtNombreLista2
        '
        Me.txtNombreLista2.Location = New System.Drawing.Point(103, 77)
        Me.txtNombreLista2.Name = "txtNombreLista2"
        Me.txtNombreLista2.Size = New System.Drawing.Size(243, 20)
        Me.txtNombreLista2.TabIndex = 88
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "Nombre de la lista"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label5.Location = New System.Drawing.Point(100, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "CAPTURADA"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(55, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 85
        Me.Label10.Text = "Estatus"
        '
        'dtpFechaFinal2
        '
        Me.dtpFechaFinal2.Location = New System.Drawing.Point(445, 46)
        Me.dtpFechaFinal2.Name = "dtpFechaFinal2"
        Me.dtpFechaFinal2.Size = New System.Drawing.Size(233, 20)
        Me.dtpFechaFinal2.TabIndex = 84
        '
        'dtpFechaInicio2
        '
        Me.dtpFechaInicio2.Location = New System.Drawing.Point(445, 19)
        Me.dtpFechaInicio2.Name = "dtpFechaInicio2"
        Me.dtpFechaInicio2.Size = New System.Drawing.Size(233, 20)
        Me.dtpFechaInicio2.TabIndex = 83
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(380, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 13)
        Me.Label13.TabIndex = 82
        Me.Label13.Text = "Vigencia fin"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(368, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 13)
        Me.Label14.TabIndex = 81
        Me.Label14.Text = "Vigencia inicio"
        '
        'cmbNave2
        '
        Me.cmbNave2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbNave2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbNave2.FormattingEnabled = True
        Me.cmbNave2.Location = New System.Drawing.Point(103, 49)
        Me.cmbNave2.Name = "cmbNave2"
        Me.cmbNave2.Size = New System.Drawing.Size(243, 21)
        Me.cmbNave2.TabIndex = 73
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(56, 52)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 13)
        Me.Label15.TabIndex = 72
        Me.Label15.Text = "Nave"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(142, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 60)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'CopiarListaPrecioForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(743, 397)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlHeader)
        Me.MaximumSize = New System.Drawing.Size(751, 424)
        Me.MinimumSize = New System.Drawing.Size(751, 424)
        Me.Name = "CopiarListaPrecioForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copiar Lista"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents bntSalir As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblA As System.Windows.Forms.Label
    Friend WithEvents lblDe As System.Windows.Forms.Label
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtColeccion As System.Windows.Forms.TextBox
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNombreLista As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtColeccion2 As System.Windows.Forms.TextBox
    Friend WithEvents txtMarca2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombreLista2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFinal2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicio2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbNave2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
