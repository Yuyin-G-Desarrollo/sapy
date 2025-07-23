<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaReportesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaReportesForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grbAgregarEditarReportes = New System.Windows.Forms.GroupBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.rdoNo = New System.Windows.Forms.RadioButton()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.btnBuscarArchivo = New System.Windows.Forms.Button()
        Me.lblArchivo = New System.Windows.Forms.Label()
        Me.txt_archivo = New System.Windows.Forms.TextBox()
        Me.lblEsquema = New System.Windows.Forms.Label()
        Me.txtEsquema = New System.Windows.Forms.TextBox()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnCancelarDia = New System.Windows.Forms.Button()
        Me.btnGuardarDia = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbAgregarEditarReportes.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.Panel1)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(473, 53)
        Me.pnlHeader.TabIndex = 15
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(307, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(166, 53)
        Me.Panel1.TabIndex = 47
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(9, 16)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(83, 20)
        Me.lblTitle.TabIndex = 21
        Me.lblTitle.Text = "Reportes"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Location = New System.Drawing.Point(822, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(419, 53)
        Me.pnlTitulo.TabIndex = 46
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(351, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 53)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(128, 16)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(217, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Configuración de Políticas"
        '
        'grbAgregarEditarReportes
        '
        Me.grbAgregarEditarReportes.Controls.Add(Me.lblActivo)
        Me.grbAgregarEditarReportes.Controls.Add(Me.rdoSi)
        Me.grbAgregarEditarReportes.Controls.Add(Me.rdoNo)
        Me.grbAgregarEditarReportes.Controls.Add(Me.lblClave)
        Me.grbAgregarEditarReportes.Controls.Add(Me.txtClave)
        Me.grbAgregarEditarReportes.Controls.Add(Me.lblNombre)
        Me.grbAgregarEditarReportes.Controls.Add(Me.txtNombre)
        Me.grbAgregarEditarReportes.Controls.Add(Me.btnBuscarArchivo)
        Me.grbAgregarEditarReportes.Controls.Add(Me.lblArchivo)
        Me.grbAgregarEditarReportes.Controls.Add(Me.txt_archivo)
        Me.grbAgregarEditarReportes.Controls.Add(Me.lblEsquema)
        Me.grbAgregarEditarReportes.Controls.Add(Me.txtEsquema)
        Me.grbAgregarEditarReportes.Location = New System.Drawing.Point(12, 59)
        Me.grbAgregarEditarReportes.Name = "grbAgregarEditarReportes"
        Me.grbAgregarEditarReportes.Size = New System.Drawing.Size(450, 157)
        Me.grbAgregarEditarReportes.TabIndex = 6
        Me.grbAgregarEditarReportes.TabStop = False
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(23, 135)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 64
        Me.lblActivo.Text = "Activo"
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Checked = True
        Me.rdoSi.Location = New System.Drawing.Point(66, 133)
        Me.rdoSi.Name = "rdoSi"
        Me.rdoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoSi.TabIndex = 62
        Me.rdoSi.TabStop = True
        Me.rdoSi.Text = "Si"
        Me.rdoSi.UseVisualStyleBackColor = True
        '
        'rdoNo
        '
        Me.rdoNo.AutoSize = True
        Me.rdoNo.Location = New System.Drawing.Point(120, 133)
        Me.rdoNo.Name = "rdoNo"
        Me.rdoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoNo.TabIndex = 7
        Me.rdoNo.Text = "No"
        Me.rdoNo.UseVisualStyleBackColor = True
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.Location = New System.Drawing.Point(23, 77)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(37, 13)
        Me.lblClave.TabIndex = 20
        Me.lblClave.Text = "Clave:"
        '
        'txtClave
        '
        Me.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClave.Location = New System.Drawing.Point(66, 74)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(367, 20)
        Me.txtClave.TabIndex = 3
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(13, 48)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(47, 13)
        Me.lblNombre.TabIndex = 19
        Me.lblNombre.Text = "Nombre:"
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(66, 45)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(367, 20)
        Me.txtNombre.TabIndex = 2
        '
        'btnBuscarArchivo
        '
        Me.btnBuscarArchivo.Location = New System.Drawing.Point(408, 102)
        Me.btnBuscarArchivo.Name = "btnBuscarArchivo"
        Me.btnBuscarArchivo.Size = New System.Drawing.Size(25, 23)
        Me.btnBuscarArchivo.TabIndex = 5
        Me.btnBuscarArchivo.Text = "..."
        Me.btnBuscarArchivo.UseVisualStyleBackColor = True
        '
        'lblArchivo
        '
        Me.lblArchivo.AutoSize = True
        Me.lblArchivo.Location = New System.Drawing.Point(14, 107)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(46, 13)
        Me.lblArchivo.TabIndex = 15
        Me.lblArchivo.Text = "Archivo:"
        '
        'txt_archivo
        '
        Me.txt_archivo.Location = New System.Drawing.Point(66, 104)
        Me.txt_archivo.Name = "txt_archivo"
        Me.txt_archivo.Size = New System.Drawing.Size(336, 20)
        Me.txt_archivo.TabIndex = 4
        '
        'lblEsquema
        '
        Me.lblEsquema.AutoSize = True
        Me.lblEsquema.Location = New System.Drawing.Point(6, 16)
        Me.lblEsquema.Name = "lblEsquema"
        Me.lblEsquema.Size = New System.Drawing.Size(54, 13)
        Me.lblEsquema.TabIndex = 11
        Me.lblEsquema.Text = "Esquema:"
        '
        'txtEsquema
        '
        Me.txtEsquema.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEsquema.Location = New System.Drawing.Point(66, 16)
        Me.txtEsquema.Name = "txtEsquema"
        Me.txtEsquema.Size = New System.Drawing.Size(367, 20)
        Me.txtEsquema.TabIndex = 1
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(406, 257)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(35, 13)
        Me.lblLimpiar.TabIndex = 20
        Me.lblLimpiar.Text = "Cerrar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(346, 257)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(45, 13)
        Me.lblBuscar.TabIndex = 19
        Me.lblBuscar.Text = "Guardar"
        '
        'btnCancelarDia
        '
        Me.btnCancelarDia.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.salir_32
        Me.btnCancelarDia.Location = New System.Drawing.Point(406, 222)
        Me.btnCancelarDia.Name = "btnCancelarDia"
        Me.btnCancelarDia.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarDia.TabIndex = 9
        Me.btnCancelarDia.UseVisualStyleBackColor = True
        '
        'btnGuardarDia
        '
        Me.btnGuardarDia.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_32
        Me.btnGuardarDia.Location = New System.Drawing.Point(351, 222)
        Me.btnGuardarDia.Name = "btnGuardarDia"
        Me.btnGuardarDia.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarDia.TabIndex = 8
        Me.btnGuardarDia.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(98, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(68, 53)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 47
        Me.PictureBox2.TabStop = False
        '
        'AltaReportesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(473, 277)
        Me.Controls.Add(Me.lblLimpiar)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.btnCancelarDia)
        Me.Controls.Add(Me.btnGuardarDia)
        Me.Controls.Add(Me.grbAgregarEditarReportes)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(489, 316)
        Me.Name = "AltaReportesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes"
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbAgregarEditarReportes.ResumeLayout(False)
        Me.grbAgregarEditarReportes.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents grbAgregarEditarReportes As System.Windows.Forms.GroupBox
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarArchivo As System.Windows.Forms.Button
    Friend WithEvents lblArchivo As System.Windows.Forms.Label
    Friend WithEvents txt_archivo As System.Windows.Forms.TextBox
    Friend WithEvents lblEsquema As System.Windows.Forms.Label
    Friend WithEvents txtEsquema As System.Windows.Forms.TextBox
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnCancelarDia As System.Windows.Forms.Button
    Friend WithEvents btnGuardarDia As System.Windows.Forms.Button
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNo As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox2 As PictureBox
End Class
