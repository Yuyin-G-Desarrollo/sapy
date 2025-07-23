<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopiarSemana
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
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.lblListaNaves = New System.Windows.Forms.Label()
        Me.grpCopiar = New System.Windows.Forms.GroupBox()
        Me.numAnioSeleccionado = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkCapacidadCatalogo = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.numAnio = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numSemanaInicio = New System.Windows.Forms.NumericUpDown()
        Me.numSemanaFinal = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSemana = New System.Windows.Forms.NumericUpDown()
        Me.lblDatoSeleccionado = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlExtado = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCopiar.SuspendLayout()
        CType(Me.numAnioSeleccionado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSemanaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSemanaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSemana, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExtado.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblCelula)
        Me.pnlEncabezado.Controls.Add(Me.imgLogo)
        Me.pnlEncabezado.Controls.Add(Me.lblListaNaves)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(320, 60)
        Me.pnlEncabezado.TabIndex = 5
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.BackColor = System.Drawing.Color.Transparent
        Me.lblCelula.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelula.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblCelula.Location = New System.Drawing.Point(119, 28)
        Me.lblCelula.MaximumSize = New System.Drawing.Size(100, 20)
        Me.lblCelula.MinimumSize = New System.Drawing.Size(130, 20)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(130, 20)
        Me.lblCelula.TabIndex = 22
        Me.lblCelula.Text = "Célula"
        Me.lblCelula.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(252, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(68, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgLogo.TabIndex = 0
        Me.imgLogo.TabStop = False
        '
        'lblListaNaves
        '
        Me.lblListaNaves.AutoSize = True
        Me.lblListaNaves.BackColor = System.Drawing.Color.Transparent
        Me.lblListaNaves.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaNaves.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaNaves.Location = New System.Drawing.Point(117, 8)
        Me.lblListaNaves.Name = "lblListaNaves"
        Me.lblListaNaves.Size = New System.Drawing.Size(132, 20)
        Me.lblListaNaves.TabIndex = 21
        Me.lblListaNaves.Text = "Copiar Semana"
        '
        'grpCopiar
        '
        Me.grpCopiar.Controls.Add(Me.numAnioSeleccionado)
        Me.grpCopiar.Controls.Add(Me.Label4)
        Me.grpCopiar.Controls.Add(Me.chkCapacidadCatalogo)
        Me.grpCopiar.Controls.Add(Me.GroupBox1)
        Me.grpCopiar.Controls.Add(Me.txtSemana)
        Me.grpCopiar.Controls.Add(Me.lblDatoSeleccionado)
        Me.grpCopiar.Location = New System.Drawing.Point(7, 65)
        Me.grpCopiar.Name = "grpCopiar"
        Me.grpCopiar.Size = New System.Drawing.Size(306, 168)
        Me.grpCopiar.TabIndex = 27
        Me.grpCopiar.TabStop = False
        '
        'numAnioSeleccionado
        '
        Me.numAnioSeleccionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numAnioSeleccionado.Location = New System.Drawing.Point(211, 23)
        Me.numAnioSeleccionado.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.numAnioSeleccionado.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numAnioSeleccionado.Name = "numAnioSeleccionado"
        Me.numAnioSeleccionado.Size = New System.Drawing.Size(47, 20)
        Me.numAnioSeleccionado.TabIndex = 58
        Me.numAnioSeleccionado.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(171, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Año"
        '
        'chkCapacidadCatalogo
        '
        Me.chkCapacidadCatalogo.AutoSize = True
        Me.chkCapacidadCatalogo.Location = New System.Drawing.Point(66, 52)
        Me.chkCapacidadCatalogo.Name = "chkCapacidadCatalogo"
        Me.chkCapacidadCatalogo.Size = New System.Drawing.Size(185, 17)
        Me.chkCapacidadCatalogo.TabIndex = 56
        Me.chkCapacidadCatalogo.Text = "Copiar capacidad desde catálogo"
        Me.chkCapacidadCatalogo.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.numAnio)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.numSemanaInicio)
        Me.GroupBox1.Controls.Add(Me.numSemanaFinal)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 79)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(290, 77)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Copiar a"
        '
        'numAnio
        '
        Me.numAnio.Enabled = False
        Me.numAnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numAnio.Location = New System.Drawing.Point(115, 46)
        Me.numAnio.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.numAnio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numAnio.Name = "numAnio"
        Me.numAnio.Size = New System.Drawing.Size(47, 20)
        Me.numAnio.TabIndex = 60
        Me.numAnio.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(58, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Año"
        '
        'numSemanaInicio
        '
        Me.numSemanaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numSemanaInicio.Location = New System.Drawing.Point(115, 19)
        Me.numSemanaInicio.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.numSemanaInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSemanaInicio.Name = "numSemanaInicio"
        Me.numSemanaInicio.Size = New System.Drawing.Size(47, 20)
        Me.numSemanaInicio.TabIndex = 45
        Me.numSemanaInicio.Value = New Decimal(New Integer() {22, 0, 0, 0})
        '
        'numSemanaFinal
        '
        Me.numSemanaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numSemanaFinal.Location = New System.Drawing.Point(197, 19)
        Me.numSemanaFinal.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.numSemanaFinal.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSemanaFinal.Name = "numSemanaFinal"
        Me.numSemanaFinal.Size = New System.Drawing.Size(47, 20)
        Me.numSemanaFinal.TabIndex = 46
        Me.numSemanaFinal.Value = New Decimal(New Integer() {28, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(58, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Semana"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(176, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "a"
        '
        'txtSemana
        '
        Me.txtSemana.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSemana.Location = New System.Drawing.Point(110, 23)
        Me.txtSemana.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.txtSemana.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtSemana.Name = "txtSemana"
        Me.txtSemana.Size = New System.Drawing.Size(47, 20)
        Me.txtSemana.TabIndex = 53
        Me.txtSemana.Value = New Decimal(New Integer() {22, 0, 0, 0})
        '
        'lblDatoSeleccionado
        '
        Me.lblDatoSeleccionado.AutoSize = True
        Me.lblDatoSeleccionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatoSeleccionado.Location = New System.Drawing.Point(26, 25)
        Me.lblDatoSeleccionado.Name = "lblDatoSeleccionado"
        Me.lblDatoSeleccionado.Size = New System.Drawing.Size(80, 13)
        Me.lblDatoSeleccionado.TabIndex = 52
        Me.lblDatoSeleccionado.Text = "Semana Origen"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(217, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 18
        Me.lblGuardar.Text = "Guardar" & Global.Microsoft.VisualBasic.ChrW(13)
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(223, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 19
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'pnlExtado
        '
        Me.pnlExtado.BackColor = System.Drawing.Color.White
        Me.pnlExtado.Controls.Add(Me.Label3)
        Me.pnlExtado.Controls.Add(Me.lblCancelar)
        Me.pnlExtado.Controls.Add(Me.btnSalir)
        Me.pnlExtado.Controls.Add(Me.btnGuardar)
        Me.pnlExtado.Controls.Add(Me.lblGuardar)
        Me.pnlExtado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlExtado.Location = New System.Drawing.Point(0, 239)
        Me.pnlExtado.Name = "pnlExtado"
        Me.pnlExtado.Size = New System.Drawing.Size(320, 60)
        Me.pnlExtado.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 52)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "La copia de información aplicará " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a los registros seleccionados. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "No puede copi" & _
    "ar capacidades " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a semanas ya transcurridas."
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(272, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 21
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(273, 7)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 20
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmCopiarSemana
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(320, 299)
        Me.Controls.Add(Me.grpCopiar)
        Me.Controls.Add(Me.pnlExtado)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "frmCopiarSemana"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copiar Semana"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCopiar.ResumeLayout(False)
        Me.grpCopiar.PerformLayout()
        CType(Me.numAnioSeleccionado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSemanaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSemanaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSemana, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExtado.ResumeLayout(False)
        Me.pnlExtado.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblListaNaves As System.Windows.Forms.Label
    Friend WithEvents grpCopiar As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents numSemanaFinal As System.Windows.Forms.NumericUpDown
    Friend WithEvents numSemanaInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents pnlExtado As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblDatoSeleccionado As System.Windows.Forms.Label
    Friend WithEvents txtSemana As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkCapacidadCatalogo As System.Windows.Forms.CheckBox
    Friend WithEvents numAnioSeleccionado As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents numAnio As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
