<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AsignarNumeroGuiaEmbarqueForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsignarNumeroGuiaEmbarqueForm))
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.paqueteria = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.embarqueid = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtcostoEnvio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcartaporder = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtnumero = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.errnumeroGuia = New System.Windows.Forms.ErrorProvider()
        Me.errcartapoder = New System.Windows.Forms.ErrorProvider()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.errnumeroGuia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errcartapoder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(402, 59)
        Me.pnlTitulo.TabIndex = 24
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel3.Controls.Add(Me.pnlDatosBotones)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 299)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(402, 57)
        Me.Panel3.TabIndex = 116
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.Button3)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(240, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 57)
        Me.pnlDatosBotones.TabIndex = 141
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(94, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(32, 38)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(44, 13)
        Me.lblAceptar.TabIndex = 0
        Me.lblAceptar.Text = "Aceptar"
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(93, 38)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Button3.Image = Global.Almacen.Vista.My.Resources.Resources.aceptar_321
        Me.Button3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button3.Location = New System.Drawing.Point(37, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(32, 32)
        Me.Button3.TabIndex = 0
        Me.Button3.UseVisualStyleBackColor = True
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlParametros.Controls.Add(Me.paqueteria)
        Me.pnlParametros.Controls.Add(Me.Label4)
        Me.pnlParametros.Controls.Add(Me.embarqueid)
        Me.pnlParametros.Controls.Add(Me.Label3)
        Me.pnlParametros.Controls.Add(Me.GroupBox1)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlParametros.Location = New System.Drawing.Point(0, 59)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(402, 240)
        Me.pnlParametros.TabIndex = 117
        '
        'paqueteria
        '
        Me.paqueteria.AutoSize = True
        Me.paqueteria.Location = New System.Drawing.Point(124, 41)
        Me.paqueteria.Name = "paqueteria"
        Me.paqueteria.Size = New System.Drawing.Size(57, 13)
        Me.paqueteria.TabIndex = 120
        Me.paqueteria.Text = "paqueteria"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 120
        Me.Label4.Text = "Paqueteria:"
        '
        'embarqueid
        '
        Me.embarqueid.AutoSize = True
        Me.embarqueid.Location = New System.Drawing.Point(124, 11)
        Me.embarqueid.Name = "embarqueid"
        Me.embarqueid.Size = New System.Drawing.Size(62, 13)
        Me.embarqueid.TabIndex = 119
        Me.embarqueid.Text = "embarqueid"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 119
        Me.Label3.Text = "Folio Embarque:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtcostoEnvio)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtcartaporder)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtnumero)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(360, 149)
        Me.GroupBox1.TabIndex = 96
        Me.GroupBox1.TabStop = False
        '
        'txtcostoEnvio
        '
        Me.txtcostoEnvio.BackColor = System.Drawing.Color.White
        Me.txtcostoEnvio.Location = New System.Drawing.Point(89, 111)
        Me.txtcostoEnvio.Name = "txtcostoEnvio"
        Me.txtcostoEnvio.Size = New System.Drawing.Size(248, 20)
        Me.txtcostoEnvio.TabIndex = 120
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 119
        Me.Label5.Text = "Costo Envio"
        '
        'txtcartaporder
        '
        Me.txtcartaporder.BackColor = System.Drawing.Color.White
        Me.txtcartaporder.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcartaporder.Location = New System.Drawing.Point(89, 73)
        Me.txtcartaporder.Name = "txtcartaporder"
        Me.txtcartaporder.Size = New System.Drawing.Size(248, 20)
        Me.txtcartaporder.TabIndex = 118
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "Carta Porter"
        '
        'txtnumero
        '
        Me.txtnumero.BackColor = System.Drawing.Color.White
        Me.txtnumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnumero.Location = New System.Drawing.Point(89, 36)
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(248, 20)
        Me.txtnumero.TabIndex = 115
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "Numero Guía"
        '
        'errnumeroGuia
        '
        Me.errnumeroGuia.ContainerControl = Me
        '
        'errcartapoder
        '
        Me.errcartapoder.ContainerControl = Me
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(154, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(180, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Asignar Numero Guía"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(334, 41)
        Me.Panel1.TabIndex = 47
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(334, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'AsignarNumeroGuiaEmbarqueForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 356)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlTitulo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AsignarNumeroGuiaEmbarqueForm"
        Me.Text = "Asignar Numero Guía"
        Me.pnlTitulo.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.errnumeroGuia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errcartapoder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblAceptar As Label
    Friend WithEvents lblCerrar As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents paqueteria As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents embarqueid As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtcartaporder As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtnumero As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents errnumeroGuia As ErrorProvider
    Friend WithEvents errcartapoder As ErrorProvider
    Friend WithEvents txtcostoEnvio As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
End Class
