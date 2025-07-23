<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaCambiosMetasHoraForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaCambiosMetasHoraForm))
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.nud_Min = New System.Windows.Forms.NumericUpDown()
        Me.lblSeparador = New System.Windows.Forms.Label()
        Me.nud_Hora = New System.Windows.Forms.NumericUpDown()
        Me.txt_Pares = New System.Windows.Forms.TextBox()
        Me.lblPares = New System.Windows.Forms.Label()
        Me.lblHora = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlParametros.SuspendLayout()
        CType(Me.nud_Min, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nud_Hora, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.nud_Min)
        Me.pnlParametros.Controls.Add(Me.lblSeparador)
        Me.pnlParametros.Controls.Add(Me.nud_Hora)
        Me.pnlParametros.Controls.Add(Me.txt_Pares)
        Me.pnlParametros.Controls.Add(Me.lblPares)
        Me.pnlParametros.Controls.Add(Me.lblHora)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 63)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(248, 101)
        Me.pnlParametros.TabIndex = 2019
        '
        'nud_Min
        '
        Me.nud_Min.Location = New System.Drawing.Point(137, 24)
        Me.nud_Min.Name = "nud_Min"
        Me.nud_Min.Size = New System.Drawing.Size(41, 20)
        Me.nud_Min.TabIndex = 2018
        '
        'lblSeparador
        '
        Me.lblSeparador.AutoSize = True
        Me.lblSeparador.Font = New System.Drawing.Font("Broadway", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeparador.Location = New System.Drawing.Point(120, 25)
        Me.lblSeparador.Name = "lblSeparador"
        Me.lblSeparador.Size = New System.Drawing.Size(15, 19)
        Me.lblSeparador.TabIndex = 2017
        Me.lblSeparador.Text = ":"
        '
        'nud_Hora
        '
        Me.nud_Hora.Location = New System.Drawing.Point(77, 24)
        Me.nud_Hora.Name = "nud_Hora"
        Me.nud_Hora.Size = New System.Drawing.Size(41, 20)
        Me.nud_Hora.TabIndex = 2016
        '
        'txt_Pares
        '
        Me.txt_Pares.Location = New System.Drawing.Point(75, 60)
        Me.txt_Pares.Name = "txt_Pares"
        Me.txt_Pares.Size = New System.Drawing.Size(134, 20)
        Me.txt_Pares.TabIndex = 2015
        Me.txt_Pares.Text = "0"
        '
        'lblPares
        '
        Me.lblPares.AutoSize = True
        Me.lblPares.Location = New System.Drawing.Point(35, 60)
        Me.lblPares.Name = "lblPares"
        Me.lblPares.Size = New System.Drawing.Size(37, 13)
        Me.lblPares.TabIndex = 2012
        Me.lblPares.Text = "Pares:"
        '
        'lblHora
        '
        Me.lblHora.AutoSize = True
        Me.lblHora.Location = New System.Drawing.Point(37, 26)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(33, 13)
        Me.lblHora.TabIndex = 2010
        Me.lblHora.Text = "Hora:"
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(40, 17)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(130, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Alta Meta Hora"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(248, 63)
        Me.pnlEncabezado.TabIndex = 2018
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(180, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 162)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(248, 57)
        Me.Panel3.TabIndex = 2023
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btn_Aceptar)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.btn_Cancelar)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.btn_Cerrar)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(71, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(177, 57)
        Me.Panel4.TabIndex = 1
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.aceptar_32
        Me.btn_Aceptar.Location = New System.Drawing.Point(34, 2)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(32, 32)
        Me.btn_Aceptar.TabIndex = 190
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(29, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 191
        Me.Label1.Text = "Aceptar"
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.cancelar_32
        Me.btn_Cancelar.Location = New System.Drawing.Point(85, 3)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(32, 32)
        Me.btn_Cancelar.TabIndex = 192
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(78, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 193
        Me.Label2.Text = "Cancelar"
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btn_Cerrar.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btn_Cerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Cerrar.Location = New System.Drawing.Point(133, 3)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(32, 32)
        Me.btn_Cerrar.TabIndex = 1
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(132, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Cerrar"
        '
        'AltaCambiosMetasHoraForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(248, 219)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "AltaCambiosMetasHoraForm"
        Me.Text = "Alta Meta Hora"
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        CType(Me.nud_Min, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nud_Hora, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlParametros As Panel
    Friend WithEvents txt_Pares As TextBox
    Friend WithEvents lblPares As Label
    Friend WithEvents lblHora As Label
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents nud_Min As NumericUpDown
    Friend WithEvents lblSeparador As Label
    Friend WithEvents nud_Hora As NumericUpDown
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btn_Aceptar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_Cancelar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents btn_Cerrar As Button
    Friend WithEvents Label3 As Label
End Class
