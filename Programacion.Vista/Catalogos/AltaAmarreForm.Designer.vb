<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaAmarreForm
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pnlDatosTalla = New System.Windows.Forms.Panel()
        Me.ckbMedias = New System.Windows.Forms.CheckBox()
        Me.ckbEnteros = New System.Windows.Forms.CheckBox()
        Me.txtNumeracion = New System.Windows.Forms.TextBox()
        Me.txtTallaInicial = New System.Windows.Forms.TextBox()
        Me.txtTallaFinal = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtTallaCentral = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblNumeracion = New System.Windows.Forms.Label()
        Me.lblFinal = New System.Windows.Forms.Label()
        Me.lblTallaCentral = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdTablaAmarre = New System.Windows.Forms.DataGridView()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlDatosTalla.SuspendLayout()
        CType(Me.grdTablaAmarre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(887, 60)
        Me.pnlHeader.TabIndex = 0
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pctTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(670, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(217, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(67, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(76, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Amarres"
        '
        'pctTitulo
        '
        Me.pctTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pctTitulo.Location = New System.Drawing.Point(149, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pctTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctTitulo.TabIndex = 0
        Me.pctTitulo.TabStop = False
        '
        'pnlEstado
        '
        Me.pnlEstado.AutoScroll = True
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 294)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(887, 60)
        Me.pnlEstado.TabIndex = 1
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(687, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(200, 60)
        Me.pnlOperaciones.TabIndex = 0
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(155, 44)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 2
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(156, 10)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 0
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'pnlDatosTalla
        '
        Me.pnlDatosTalla.Controls.Add(Me.ckbMedias)
        Me.pnlDatosTalla.Controls.Add(Me.ckbEnteros)
        Me.pnlDatosTalla.Controls.Add(Me.txtNumeracion)
        Me.pnlDatosTalla.Controls.Add(Me.txtTallaInicial)
        Me.pnlDatosTalla.Controls.Add(Me.txtTallaFinal)
        Me.pnlDatosTalla.Controls.Add(Me.txtCodigo)
        Me.pnlDatosTalla.Controls.Add(Me.txtTallaCentral)
        Me.pnlDatosTalla.Controls.Add(Me.Label5)
        Me.pnlDatosTalla.Controls.Add(Me.lblNumeracion)
        Me.pnlDatosTalla.Controls.Add(Me.lblFinal)
        Me.pnlDatosTalla.Controls.Add(Me.lblTallaCentral)
        Me.pnlDatosTalla.Controls.Add(Me.Label1)
        Me.pnlDatosTalla.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatosTalla.Location = New System.Drawing.Point(0, 60)
        Me.pnlDatosTalla.Name = "pnlDatosTalla"
        Me.pnlDatosTalla.Size = New System.Drawing.Size(887, 85)
        Me.pnlDatosTalla.TabIndex = 2
        '
        'ckbMedias
        '
        Me.ckbMedias.AutoSize = True
        Me.ckbMedias.BackColor = System.Drawing.Color.Transparent
        Me.ckbMedias.Enabled = False
        Me.ckbMedias.Location = New System.Drawing.Point(694, 44)
        Me.ckbMedias.Name = "ckbMedias"
        Me.ckbMedias.Size = New System.Drawing.Size(114, 17)
        Me.ckbMedias.TabIndex = 12
        Me.ckbMedias.Text = "Medias registradas"
        Me.ckbMedias.UseVisualStyleBackColor = False
        '
        'ckbEnteros
        '
        Me.ckbEnteros.AutoSize = True
        Me.ckbEnteros.BackColor = System.Drawing.Color.Transparent
        Me.ckbEnteros.Enabled = False
        Me.ckbEnteros.Location = New System.Drawing.Point(694, 18)
        Me.ckbEnteros.Name = "ckbEnteros"
        Me.ckbEnteros.Size = New System.Drawing.Size(62, 17)
        Me.ckbEnteros.TabIndex = 11
        Me.ckbEnteros.Text = "Enteros"
        Me.ckbEnteros.UseVisualStyleBackColor = False
        '
        'txtNumeracion
        '
        Me.txtNumeracion.Location = New System.Drawing.Point(105, 42)
        Me.txtNumeracion.Name = "txtNumeracion"
        Me.txtNumeracion.ReadOnly = True
        Me.txtNumeracion.Size = New System.Drawing.Size(124, 20)
        Me.txtNumeracion.TabIndex = 10
        '
        'txtTallaInicial
        '
        Me.txtTallaInicial.Location = New System.Drawing.Point(346, 16)
        Me.txtTallaInicial.Name = "txtTallaInicial"
        Me.txtTallaInicial.ReadOnly = True
        Me.txtTallaInicial.Size = New System.Drawing.Size(76, 20)
        Me.txtTallaInicial.TabIndex = 9
        '
        'txtTallaFinal
        '
        Me.txtTallaFinal.Location = New System.Drawing.Point(346, 42)
        Me.txtTallaFinal.Name = "txtTallaFinal"
        Me.txtTallaFinal.ReadOnly = True
        Me.txtTallaFinal.Size = New System.Drawing.Size(76, 20)
        Me.txtTallaFinal.TabIndex = 8
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(105, 16)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(63, 20)
        Me.txtCodigo.TabIndex = 7
        '
        'txtTallaCentral
        '
        Me.txtTallaCentral.Location = New System.Drawing.Point(552, 16)
        Me.txtTallaCentral.Name = "txtTallaCentral"
        Me.txtTallaCentral.ReadOnly = True
        Me.txtTallaCentral.Size = New System.Drawing.Size(76, 20)
        Me.txtTallaCentral.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(57, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Código"
        '
        'lblNumeracion
        '
        Me.lblNumeracion.AutoSize = True
        Me.lblNumeracion.Location = New System.Drawing.Point(34, 46)
        Me.lblNumeracion.Name = "lblNumeracion"
        Me.lblNumeracion.Size = New System.Drawing.Size(63, 13)
        Me.lblNumeracion.TabIndex = 3
        Me.lblNumeracion.Text = "Descripción"
        '
        'lblFinal
        '
        Me.lblFinal.AutoSize = True
        Me.lblFinal.Location = New System.Drawing.Point(288, 46)
        Me.lblFinal.Name = "lblFinal"
        Me.lblFinal.Size = New System.Drawing.Size(52, 13)
        Me.lblFinal.TabIndex = 2
        Me.lblFinal.Text = "Talla final"
        '
        'lblTallaCentral
        '
        Me.lblTallaCentral.AutoSize = True
        Me.lblTallaCentral.Location = New System.Drawing.Point(481, 20)
        Me.lblTallaCentral.Name = "lblTallaCentral"
        Me.lblTallaCentral.Size = New System.Drawing.Size(65, 13)
        Me.lblTallaCentral.TabIndex = 1
        Me.lblTallaCentral.Text = "Talla central"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(281, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Talla inicial"
        '
        'grdTablaAmarre
        '
        Me.grdTablaAmarre.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grdTablaAmarre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTablaAmarre.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdTablaAmarre.Location = New System.Drawing.Point(0, 145)
        Me.grdTablaAmarre.Name = "grdTablaAmarre"
        Me.grdTablaAmarre.ReadOnly = True
        Me.grdTablaAmarre.RowHeadersWidth = 100
        Me.grdTablaAmarre.Size = New System.Drawing.Size(887, 111)
        Me.grdTablaAmarre.TabIndex = 4
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.Location = New System.Drawing.Point(22, 313)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(0, 13)
        Me.lblMensaje.TabIndex = 5
        '
        'AltaAmarreForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(887, 354)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.grdTablaAmarre)
        Me.Controls.Add(Me.pnlDatosTalla)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "AltaAmarreForm"
        Me.Text = "Amarres"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlDatosTalla.ResumeLayout(False)
        Me.pnlDatosTalla.PerformLayout()
        CType(Me.grdTablaAmarre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosTalla As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pctTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtTallaInicial As System.Windows.Forms.TextBox
    Friend WithEvents txtTallaFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtTallaCentral As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblNumeracion As System.Windows.Forms.Label
    Friend WithEvents lblFinal As System.Windows.Forms.Label
    Friend WithEvents lblTallaCentral As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumeracion As System.Windows.Forms.TextBox
    Friend WithEvents grdTablaAmarre As System.Windows.Forms.DataGridView
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents ckbMedias As System.Windows.Forms.CheckBox
    Friend WithEvents ckbEnteros As System.Windows.Forms.CheckBox
End Class
