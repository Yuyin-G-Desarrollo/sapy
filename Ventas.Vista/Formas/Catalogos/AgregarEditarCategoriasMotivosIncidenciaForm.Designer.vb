<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarEditarCategoriasMotivosIncidenciaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgregarEditarCategoriasMotivosIncidenciaForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblListaCatalogoRamos = New System.Windows.Forms.Label()
        Me.grbRamos = New System.Windows.Forms.GroupBox()
        Me.grpCategoriaIncidencia = New System.Windows.Forms.GroupBox()
        Me.txtNombreCategoria = New System.Windows.Forms.TextBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.lblNombreCategoria = New System.Windows.Forms.Label()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.rdoNo = New System.Windows.Forms.RadioButton()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.grbRamos.SuspendLayout()
        Me.grpCategoriaIncidencia.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Controls.Add(Me.lblListaCatalogoRamos)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(465, 53)
        Me.pnlEncabezado.TabIndex = 69
        '
        'lblListaCatalogoRamos
        '
        Me.lblListaCatalogoRamos.AutoSize = True
        Me.lblListaCatalogoRamos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaCatalogoRamos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaCatalogoRamos.Location = New System.Drawing.Point(304, 18)
        Me.lblListaCatalogoRamos.Name = "lblListaCatalogoRamos"
        Me.lblListaCatalogoRamos.Size = New System.Drawing.Size(87, 20)
        Me.lblListaCatalogoRamos.TabIndex = 21
        Me.lblListaCatalogoRamos.Text = "Categoría"
        '
        'grbRamos
        '
        Me.grbRamos.BackColor = System.Drawing.Color.AliceBlue
        Me.grbRamos.Controls.Add(Me.grpCategoriaIncidencia)
        Me.grbRamos.Controls.Add(Me.lblBúscar)
        Me.grbRamos.Controls.Add(Me.lblLimpiar)
        Me.grbRamos.Controls.Add(Me.btnCerrar)
        Me.grbRamos.Controls.Add(Me.btnGuardar)
        Me.grbRamos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbRamos.ForeColor = System.Drawing.Color.AliceBlue
        Me.grbRamos.Location = New System.Drawing.Point(0, 53)
        Me.grbRamos.Name = "grbRamos"
        Me.grbRamos.Size = New System.Drawing.Size(465, 182)
        Me.grbRamos.TabIndex = 70
        Me.grbRamos.TabStop = False
        '
        'grpCategoriaIncidencia
        '
        Me.grpCategoriaIncidencia.Controls.Add(Me.txtNombreCategoria)
        Me.grpCategoriaIncidencia.Controls.Add(Me.lblActivo)
        Me.grpCategoriaIncidencia.Controls.Add(Me.lblNombreCategoria)
        Me.grpCategoriaIncidencia.Controls.Add(Me.rdoSi)
        Me.grpCategoriaIncidencia.Controls.Add(Me.rdoNo)
        Me.grpCategoriaIncidencia.Location = New System.Drawing.Point(12, 34)
        Me.grpCategoriaIncidencia.Name = "grpCategoriaIncidencia"
        Me.grpCategoriaIncidencia.Size = New System.Drawing.Size(433, 81)
        Me.grpCategoriaIncidencia.TabIndex = 29
        Me.grpCategoriaIncidencia.TabStop = False
        Me.grpCategoriaIncidencia.Text = "Categoría Tipos de incidencia"
        '
        'txtNombreCategoria
        '
        Me.txtNombreCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreCategoria.Location = New System.Drawing.Point(106, 19)
        Me.txtNombreCategoria.MaxLength = 100
        Me.txtNombreCategoria.Name = "txtNombreCategoria"
        Me.txtNombreCategoria.Size = New System.Drawing.Size(279, 20)
        Me.txtNombreCategoria.TabIndex = 34
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblActivo.Location = New System.Drawing.Point(12, 47)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 35
        Me.lblActivo.Text = "Activo"
        '
        'lblNombreCategoria
        '
        Me.lblNombreCategoria.AutoSize = True
        Me.lblNombreCategoria.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblNombreCategoria.Location = New System.Drawing.Point(6, 22)
        Me.lblNombreCategoria.Name = "lblNombreCategoria"
        Me.lblNombreCategoria.Size = New System.Drawing.Size(94, 13)
        Me.lblNombreCategoria.TabIndex = 33
        Me.lblNombreCategoria.Text = "Nombre Categoría"
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Checked = True
        Me.rdoSi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdoSi.Location = New System.Drawing.Point(81, 43)
        Me.rdoSi.Name = "rdoSi"
        Me.rdoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoSi.TabIndex = 33
        Me.rdoSi.TabStop = True
        Me.rdoSi.Text = "Si"
        Me.rdoSi.UseVisualStyleBackColor = True
        '
        'rdoNo
        '
        Me.rdoNo.AutoSize = True
        Me.rdoNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdoNo.Location = New System.Drawing.Point(121, 45)
        Me.rdoNo.Name = "rdoNo"
        Me.rdoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoNo.TabIndex = 34
        Me.rdoNo.Text = "No"
        Me.rdoNo.UseVisualStyleBackColor = True
        '
        'lblBúscar
        '
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(363, 155)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(45, 13)
        Me.lblBúscar.TabIndex = 26
        Me.lblBúscar.Text = "Guardar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(411, 155)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(35, 13)
        Me.lblLimpiar.TabIndex = 25
        Me.lblLimpiar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(413, 121)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(364, 121)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 31)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(397, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AgregarEditarCategoriasMotivosIncidenciaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 234)
        Me.Controls.Add(Me.grbRamos)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(481, 273)
        Me.MinimizeBox = False
        Me.Name = "AgregarEditarCategoriasMotivosIncidenciaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Categoría"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.grbRamos.ResumeLayout(False)
        Me.grbRamos.PerformLayout()
        Me.grpCategoriaIncidencia.ResumeLayout(False)
        Me.grpCategoriaIncidencia.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblListaCatalogoRamos As System.Windows.Forms.Label
    Friend WithEvents grbRamos As System.Windows.Forms.GroupBox
    Friend WithEvents lblBúscar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents grpCategoriaIncidencia As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombreCategoria As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreCategoria As System.Windows.Forms.Label
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNo As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox1 As PictureBox
End Class
