<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FraccionArancelariaAsignacionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FraccionArancelariaAsignacionForm))
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotalSeleccionados = New System.Windows.Forms.Label()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.btnEliminarImagen = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGuardarRanking = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pnlAgregarEditarMateriales = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.pnlrdoActivo = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.lblActivoAgregarEditarRutas = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlAgregarEditarMateriales.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pnlrdoActivo.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(1162, 66)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 74
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(1138, 66)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 73
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.Label3)
        Me.pnlEstado.Controls.Add(Me.lblTotalSeleccionados)
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 549)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1194, 60)
        Me.pnlEstado.TabIndex = 76
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(11, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 30)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Registros" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccionados"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalSeleccionados
        '
        Me.lblTotalSeleccionados.AutoSize = True
        Me.lblTotalSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSeleccionados.Location = New System.Drawing.Point(47, 36)
        Me.lblTotalSeleccionados.Name = "lblTotalSeleccionados"
        Me.lblTotalSeleccionados.Size = New System.Drawing.Size(17, 18)
        Me.lblTotalSeleccionados.TabIndex = 48
        Me.lblTotalSeleccionados.Text = "0"
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.btnEliminarImagen)
        Me.pnlOperaciones.Controls.Add(Me.Label2)
        Me.pnlOperaciones.Controls.Add(Me.Label1)
        Me.pnlOperaciones.Controls.Add(Me.btnGuardarRanking)
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(965, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(229, 60)
        Me.pnlOperaciones.TabIndex = 0
        '
        'btnEliminarImagen
        '
        Me.btnEliminarImagen.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnEliminarImagen.Image = Global.Ventas.Vista.My.Resources.Resources.borrar_32
        Me.btnEliminarImagen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEliminarImagen.Location = New System.Drawing.Point(63, 8)
        Me.btnEliminarImagen.Name = "btnEliminarImagen"
        Me.btnEliminarImagen.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminarImagen.TabIndex = 29
        Me.btnEliminarImagen.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(60, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Eliminar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(115, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Guardar"
        '
        'btnGuardarRanking
        '
        Me.btnGuardarRanking.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_3211
        Me.btnGuardarRanking.Location = New System.Drawing.Point(119, 8)
        Me.btnGuardarRanking.Name = "btnGuardarRanking"
        Me.btnGuardarRanking.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarRanking.TabIndex = 4
        Me.btnGuardarRanking.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(173, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(173, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'pnlAgregarEditarMateriales
        '
        Me.pnlAgregarEditarMateriales.BackColor = System.Drawing.Color.White
        Me.pnlAgregarEditarMateriales.Controls.Add(Me.pbYuyin)
        Me.pnlAgregarEditarMateriales.Controls.Add(Me.lblEncabezado)
        Me.pnlAgregarEditarMateriales.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAgregarEditarMateriales.Location = New System.Drawing.Point(0, 0)
        Me.pnlAgregarEditarMateriales.Name = "pnlAgregarEditarMateriales"
        Me.pnlAgregarEditarMateriales.Size = New System.Drawing.Size(1194, 60)
        Me.pnlAgregarEditarMateriales.TabIndex = 75
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(1126, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 60)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(806, 19)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(320, 20)
        Me.lblEncabezado.TabIndex = 6
        Me.lblEncabezado.Text = "Asignación de Fracciones Arancelarias"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pnlrdoActivo)
        Me.GroupBox1.Controls.Add(Me.lblActivoAgregarEditarRutas)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 85)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(657, 190)
        Me.GroupBox1.TabIndex = 77
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Catálogo de Fracciones Arancelarias"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBox2)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(675, 85)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(507, 190)
        Me.GroupBox2.TabIndex = 78
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Asignación"
        '
        'GroupBox3
        '
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 279)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1170, 264)
        Me.GroupBox3.TabIndex = 79
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Artículos"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(583, 13)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(70, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Ver Todo"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(6, 13)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(106, 17)
        Me.CheckBox2.TabIndex = 1
        Me.CheckBox2.Text = "Seleccionar todo"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'pnlrdoActivo
        '
        Me.pnlrdoActivo.Controls.Add(Me.rdoActivoNo)
        Me.pnlrdoActivo.Controls.Add(Me.rdoActivoSi)
        Me.pnlrdoActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlrdoActivo.Location = New System.Drawing.Point(55, 12)
        Me.pnlrdoActivo.Name = "pnlrdoActivo"
        Me.pnlrdoActivo.Size = New System.Drawing.Size(84, 21)
        Me.pnlrdoActivo.TabIndex = 11
        '
        'rdoActivoNo
        '
        Me.rdoActivoNo.AutoSize = True
        Me.rdoActivoNo.Location = New System.Drawing.Point(42, 2)
        Me.rdoActivoNo.Name = "rdoActivoNo"
        Me.rdoActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoActivoNo.TabIndex = 4
        Me.rdoActivoNo.Text = "No"
        Me.rdoActivoNo.UseVisualStyleBackColor = True
        '
        'rdoActivoSi
        '
        Me.rdoActivoSi.AutoSize = True
        Me.rdoActivoSi.Checked = True
        Me.rdoActivoSi.Location = New System.Drawing.Point(5, 2)
        Me.rdoActivoSi.Name = "rdoActivoSi"
        Me.rdoActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivoSi.TabIndex = 3
        Me.rdoActivoSi.TabStop = True
        Me.rdoActivoSi.Text = "Si"
        Me.rdoActivoSi.UseVisualStyleBackColor = True
        '
        'lblActivoAgregarEditarRutas
        '
        Me.lblActivoAgregarEditarRutas.AutoSize = True
        Me.lblActivoAgregarEditarRutas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivoAgregarEditarRutas.Location = New System.Drawing.Point(10, 15)
        Me.lblActivoAgregarEditarRutas.Name = "lblActivoAgregarEditarRutas"
        Me.lblActivoAgregarEditarRutas.Size = New System.Drawing.Size(42, 13)
        Me.lblActivoAgregarEditarRutas.TabIndex = 10
        Me.lblActivoAgregarEditarRutas.Text = "Activos"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(290, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(842, 15)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Fracción Arancelaria Seleccionada"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'FraccionArancelariaAsignacionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1194, 609)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnAbajo)
        Me.Controls.Add(Me.btnArriba)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlAgregarEditarMateriales)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FraccionArancelariaAsignacionForm"
        Me.Text = "Asignación de Fracciones Arancelarias"
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlAgregarEditarMateriales.ResumeLayout(False)
        Me.pnlAgregarEditarMateriales.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.pnlrdoActivo.ResumeLayout(False)
        Me.pnlrdoActivo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGuardarRanking As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents pnlAgregarEditarMateriales As System.Windows.Forms.Panel
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnEliminarImagen As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTotalSeleccionados As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents pnlrdoActivo As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblActivoAgregarEditarRutas As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
