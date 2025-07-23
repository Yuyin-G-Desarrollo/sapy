<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VerFotosInspeccionForm
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
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblDevuelto = New System.Windows.Forms.TextBox()
        Me.lblTalla = New System.Windows.Forms.TextBox()
        Me.lblCorrida = New System.Windows.Forms.TextBox()
        Me.lblColor = New System.Windows.Forms.TextBox()
        Me.lblPiel = New System.Windows.Forms.TextBox()
        Me.lblColeccion = New System.Windows.Forms.TextBox()
        Me.lblModelo = New System.Windows.Forms.TextBox()
        Me.lblLote = New System.Windows.Forms.TextBox()
        Me.lblCodigoPar = New System.Windows.Forms.TextBox()
        Me.lblAtado = New System.Windows.Forms.TextBox()
        Me.lblClasificacion = New System.Windows.Forms.TextBox()
        Me.lblDepartamento = New System.Windows.Forms.TextBox()
        Me.lblIncidencia = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.imgFoto1 = New System.Windows.Forms.PictureBox()
        Me.imgFoto2 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.imgFoto1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgFoto2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1039, 65)
        Me.pnlEncabezado.TabIndex = 26
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(486, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(553, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(291, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(172, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Resumen Incidencia"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(482, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(71, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 390)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1039, 60)
        Me.pnlPie.TabIndex = 29
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(877, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(116, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(115, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1039, 325)
        Me.Panel1.TabIndex = 30
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.imgFoto1)
        Me.GroupBox1.Controls.Add(Me.imgFoto2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1015, 296)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblDevuelto)
        Me.Panel2.Controls.Add(Me.lblTalla)
        Me.Panel2.Controls.Add(Me.lblCorrida)
        Me.Panel2.Controls.Add(Me.lblColor)
        Me.Panel2.Controls.Add(Me.lblPiel)
        Me.Panel2.Controls.Add(Me.lblColeccion)
        Me.Panel2.Controls.Add(Me.lblModelo)
        Me.Panel2.Controls.Add(Me.lblLote)
        Me.Panel2.Controls.Add(Me.lblCodigoPar)
        Me.Panel2.Controls.Add(Me.lblAtado)
        Me.Panel2.Controls.Add(Me.lblClasificacion)
        Me.Panel2.Controls.Add(Me.lblDepartamento)
        Me.Panel2.Controls.Add(Me.lblIncidencia)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Location = New System.Drawing.Point(2, 9)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(351, 285)
        Me.Panel2.TabIndex = 16
        '
        'lblDevuelto
        '
        Me.lblDevuelto.BackColor = System.Drawing.Color.White
        Me.lblDevuelto.Location = New System.Drawing.Point(96, 256)
        Me.lblDevuelto.Name = "lblDevuelto"
        Me.lblDevuelto.ReadOnly = True
        Me.lblDevuelto.Size = New System.Drawing.Size(252, 20)
        Me.lblDevuelto.TabIndex = 41
        '
        'lblTalla
        '
        Me.lblTalla.BackColor = System.Drawing.Color.White
        Me.lblTalla.Location = New System.Drawing.Point(96, 235)
        Me.lblTalla.Name = "lblTalla"
        Me.lblTalla.ReadOnly = True
        Me.lblTalla.Size = New System.Drawing.Size(252, 20)
        Me.lblTalla.TabIndex = 40
        '
        'lblCorrida
        '
        Me.lblCorrida.BackColor = System.Drawing.Color.White
        Me.lblCorrida.Location = New System.Drawing.Point(96, 214)
        Me.lblCorrida.Name = "lblCorrida"
        Me.lblCorrida.ReadOnly = True
        Me.lblCorrida.Size = New System.Drawing.Size(252, 20)
        Me.lblCorrida.TabIndex = 39
        '
        'lblColor
        '
        Me.lblColor.BackColor = System.Drawing.Color.White
        Me.lblColor.Location = New System.Drawing.Point(96, 193)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.ReadOnly = True
        Me.lblColor.Size = New System.Drawing.Size(252, 20)
        Me.lblColor.TabIndex = 38
        '
        'lblPiel
        '
        Me.lblPiel.BackColor = System.Drawing.Color.White
        Me.lblPiel.Location = New System.Drawing.Point(96, 172)
        Me.lblPiel.Name = "lblPiel"
        Me.lblPiel.ReadOnly = True
        Me.lblPiel.Size = New System.Drawing.Size(252, 20)
        Me.lblPiel.TabIndex = 37
        '
        'lblColeccion
        '
        Me.lblColeccion.BackColor = System.Drawing.Color.White
        Me.lblColeccion.Location = New System.Drawing.Point(96, 151)
        Me.lblColeccion.Name = "lblColeccion"
        Me.lblColeccion.ReadOnly = True
        Me.lblColeccion.Size = New System.Drawing.Size(252, 20)
        Me.lblColeccion.TabIndex = 36
        '
        'lblModelo
        '
        Me.lblModelo.BackColor = System.Drawing.Color.White
        Me.lblModelo.Location = New System.Drawing.Point(96, 130)
        Me.lblModelo.Name = "lblModelo"
        Me.lblModelo.ReadOnly = True
        Me.lblModelo.Size = New System.Drawing.Size(252, 20)
        Me.lblModelo.TabIndex = 35
        '
        'lblLote
        '
        Me.lblLote.BackColor = System.Drawing.Color.White
        Me.lblLote.Location = New System.Drawing.Point(96, 110)
        Me.lblLote.Name = "lblLote"
        Me.lblLote.ReadOnly = True
        Me.lblLote.Size = New System.Drawing.Size(252, 20)
        Me.lblLote.TabIndex = 34
        '
        'lblCodigoPar
        '
        Me.lblCodigoPar.BackColor = System.Drawing.Color.White
        Me.lblCodigoPar.Location = New System.Drawing.Point(96, 91)
        Me.lblCodigoPar.Name = "lblCodigoPar"
        Me.lblCodigoPar.ReadOnly = True
        Me.lblCodigoPar.Size = New System.Drawing.Size(252, 20)
        Me.lblCodigoPar.TabIndex = 33
        '
        'lblAtado
        '
        Me.lblAtado.BackColor = System.Drawing.Color.White
        Me.lblAtado.Location = New System.Drawing.Point(96, 70)
        Me.lblAtado.Name = "lblAtado"
        Me.lblAtado.ReadOnly = True
        Me.lblAtado.Size = New System.Drawing.Size(252, 20)
        Me.lblAtado.TabIndex = 32
        '
        'lblClasificacion
        '
        Me.lblClasificacion.BackColor = System.Drawing.Color.White
        Me.lblClasificacion.Location = New System.Drawing.Point(96, 49)
        Me.lblClasificacion.Name = "lblClasificacion"
        Me.lblClasificacion.ReadOnly = True
        Me.lblClasificacion.Size = New System.Drawing.Size(252, 20)
        Me.lblClasificacion.TabIndex = 31
        '
        'lblDepartamento
        '
        Me.lblDepartamento.BackColor = System.Drawing.Color.White
        Me.lblDepartamento.Location = New System.Drawing.Point(96, 28)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.ReadOnly = True
        Me.lblDepartamento.Size = New System.Drawing.Size(252, 20)
        Me.lblDepartamento.TabIndex = 30
        '
        'lblIncidencia
        '
        Me.lblIncidencia.BackColor = System.Drawing.Color.White
        Me.lblIncidencia.Location = New System.Drawing.Point(96, 7)
        Me.lblIncidencia.Name = "lblIncidencia"
        Me.lblIncidencia.ReadOnly = True
        Me.lblIncidencia.Size = New System.Drawing.Size(252, 20)
        Me.lblIncidencia.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(58, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Lote"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(27, 155)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Colección"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(32, 260)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 13)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Devuelto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(50, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Atado"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(11, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Clasificación"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Código Par"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Departamento"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(24, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Incidencia"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(42, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Modelo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(43, 218)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Corrida"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(62, 176)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Piel"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(55, 239)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Talla"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(54, 197)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Color"
        '
        'imgFoto1
        '
        Me.imgFoto1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgFoto1.Location = New System.Drawing.Point(359, 7)
        Me.imgFoto1.Name = "imgFoto1"
        Me.imgFoto1.Size = New System.Drawing.Size(324, 287)
        Me.imgFoto1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgFoto1.TabIndex = 0
        Me.imgFoto1.TabStop = False
        '
        'imgFoto2
        '
        Me.imgFoto2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgFoto2.Location = New System.Drawing.Point(689, 7)
        Me.imgFoto2.Name = "imgFoto2"
        Me.imgFoto2.Size = New System.Drawing.Size(324, 285)
        Me.imgFoto2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgFoto2.TabIndex = 1
        Me.imgFoto2.TabStop = False
        '
        'VerFotosInspeccionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximumSize = New System.Drawing.Size(1055, 489)
        Me.MinimumSize = New System.Drawing.Size(1055, 489)
        Me.Name = "VerFotosInspeccionForm"
        Me.Text = "Resumen Incidencia"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.imgFoto1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgFoto2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents imgFoto2 As PictureBox
    Friend WithEvents imgFoto1 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblDevuelto As TextBox
    Friend WithEvents lblTalla As TextBox
    Friend WithEvents lblCorrida As TextBox
    Friend WithEvents lblColor As TextBox
    Friend WithEvents lblPiel As TextBox
    Friend WithEvents lblColeccion As TextBox
    Friend WithEvents lblModelo As TextBox
    Friend WithEvents lblLote As TextBox
    Friend WithEvents lblCodigoPar As TextBox
    Friend WithEvents lblAtado As TextBox
    Friend WithEvents lblClasificacion As TextBox
    Friend WithEvents lblDepartamento As TextBox
    Friend WithEvents lblIncidencia As TextBox
End Class
