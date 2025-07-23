<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MotivosCancelacionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MotivosCancelacionForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.grbRamos = New System.Windows.Forms.GroupBox()
        Me.cmbMotivosCancelacion = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtObervacionesCancelacion = New System.Windows.Forms.TextBox()
        Me.lblNombreCategoria = New System.Windows.Forms.Label()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbRamos.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(378, 58)
        Me.pnlEncabezado.TabIndex = 77
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(122, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(169, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Motivo Cancelación "
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(310, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 58)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'grbRamos
        '
        Me.grbRamos.BackColor = System.Drawing.Color.AliceBlue
        Me.grbRamos.Controls.Add(Me.cmbMotivosCancelacion)
        Me.grbRamos.Controls.Add(Me.Label1)
        Me.grbRamos.Controls.Add(Me.txtObervacionesCancelacion)
        Me.grbRamos.Controls.Add(Me.lblNombreCategoria)
        Me.grbRamos.Controls.Add(Me.lblBúscar)
        Me.grbRamos.Controls.Add(Me.lblLimpiar)
        Me.grbRamos.Controls.Add(Me.btnCerrar)
        Me.grbRamos.Controls.Add(Me.btnGuardar)
        Me.grbRamos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbRamos.ForeColor = System.Drawing.Color.AliceBlue
        Me.grbRamos.Location = New System.Drawing.Point(0, 58)
        Me.grbRamos.Name = "grbRamos"
        Me.grbRamos.Size = New System.Drawing.Size(378, 243)
        Me.grbRamos.TabIndex = 78
        Me.grbRamos.TabStop = False
        '
        'cmbMotivosCancelacion
        '
        Me.cmbMotivosCancelacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMotivosCancelacion.FormattingEnabled = True
        Me.cmbMotivosCancelacion.Location = New System.Drawing.Point(51, 25)
        Me.cmbMotivosCancelacion.Name = "cmbMotivosCancelacion"
        Me.cmbMotivosCancelacion.Size = New System.Drawing.Size(309, 21)
        Me.cmbMotivosCancelacion.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Motivo"
        '
        'txtObervacionesCancelacion
        '
        Me.txtObervacionesCancelacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObervacionesCancelacion.Location = New System.Drawing.Point(6, 65)
        Me.txtObervacionesCancelacion.MaxLength = 100
        Me.txtObervacionesCancelacion.Multiline = True
        Me.txtObervacionesCancelacion.Name = "txtObervacionesCancelacion"
        Me.txtObervacionesCancelacion.Size = New System.Drawing.Size(354, 87)
        Me.txtObervacionesCancelacion.TabIndex = 34
        '
        'lblNombreCategoria
        '
        Me.lblNombreCategoria.AutoSize = True
        Me.lblNombreCategoria.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblNombreCategoria.Location = New System.Drawing.Point(6, 49)
        Me.lblNombreCategoria.Name = "lblNombreCategoria"
        Me.lblNombreCategoria.Size = New System.Drawing.Size(78, 13)
        Me.lblNombreCategoria.TabIndex = 33
        Me.lblNombreCategoria.Text = "Observaciones"
        '
        'lblBúscar
        '
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(264, 197)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(44, 13)
        Me.lblBúscar.TabIndex = 26
        Me.lblBúscar.Text = "Aceptar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(322, 197)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(35, 13)
        Me.lblLimpiar.TabIndex = 25
        Me.lblLimpiar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(322, 163)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.aceptar_32
        Me.btnGuardar.Location = New System.Drawing.Point(267, 163)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 31)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'MotivosCancelacionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 279)
        Me.Controls.Add(Me.grbRamos)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximumSize = New System.Drawing.Size(394, 318)
        Me.MinimumSize = New System.Drawing.Size(394, 318)
        Me.Name = "MotivosCancelacionForm"
        Me.Text = "Motivo Cancelación"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbRamos.ResumeLayout(False)
        Me.grbRamos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents grbRamos As System.Windows.Forms.GroupBox
    Friend WithEvents txtObervacionesCancelacion As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreCategoria As System.Windows.Forms.Label
    Friend WithEvents lblBúscar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbMotivosCancelacion As System.Windows.Forms.ComboBox
End Class
