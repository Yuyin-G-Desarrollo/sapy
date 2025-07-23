<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DateForm
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lstFechas = New System.Windows.Forms.ListBox()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.lblSeleccionado = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Nomina.Vista.My.Resources.Resources.aviso
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(405, 219)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.BackColor = System.Drawing.Color.AliceBlue
        Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblMensaje.Location = New System.Drawing.Point(120, 62)
        Me.lblMensaje.MaximumSize = New System.Drawing.Size(329, 0)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(210, 22)
        Me.lblMensaje.TabIndex = 11
        Me.lblMensaje.Text = "Seleccione la fecha deseada"
        Me.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensaje.UseCompatibleTextRendering = True
        '
        'dtpFecha
        '
        Me.dtpFecha.Location = New System.Drawing.Point(120, 93)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(200, 20)
        Me.dtpFecha.TabIndex = 12
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.advertencia
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.Transparent
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAceptar.Location = New System.Drawing.Point(151, 122)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(131, 33)
        Me.btnAceptar.TabIndex = 13
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAceptar.UseVisualStyleBackColor = False
        Me.btnAceptar.Visible = False
        '
        'lstFechas
        '
        Me.lstFechas.FormattingEnabled = True
        Me.lstFechas.Location = New System.Drawing.Point(120, 86)
        Me.lstFechas.Name = "lstFechas"
        Me.lstFechas.Size = New System.Drawing.Size(162, 69)
        Me.lstFechas.TabIndex = 14
        Me.lstFechas.Visible = False
        '
        'btnBorrar
        '
        Me.btnBorrar.Image = Global.Nomina.Vista.My.Resources.Resources.borrar_32
        Me.btnBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBorrar.Location = New System.Drawing.Point(288, 86)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(32, 32)
        Me.btnBorrar.TabIndex = 38
        Me.btnBorrar.UseVisualStyleBackColor = True
        Me.btnBorrar.Visible = False
        '
        'lblSeleccionado
        '
        Me.lblSeleccionado.AutoSize = True
        Me.lblSeleccionado.BackColor = System.Drawing.Color.Transparent
        Me.lblSeleccionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeleccionado.ForeColor = System.Drawing.Color.Red
        Me.lblSeleccionado.Location = New System.Drawing.Point(150, 195)
        Me.lblSeleccionado.MaximumSize = New System.Drawing.Size(329, 0)
        Me.lblSeleccionado.Name = "lblSeleccionado"
        Me.lblSeleccionado.Size = New System.Drawing.Size(132, 17)
        Me.lblSeleccionado.TabIndex = 39
        Me.lblSeleccionado.Text = "Fechas seleccionadas ()"
        Me.lblSeleccionado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSeleccionado.UseCompatibleTextRendering = True
        Me.lblSeleccionado.Visible = False
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.Nomina.Vista.My.Resources.Resources.altas_32
        Me.btnAgregar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAgregar.Location = New System.Drawing.Point(326, 86)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(32, 32)
        Me.btnAgregar.TabIndex = 40
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'DateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 215)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.lblSeleccionado)
        Me.Controls.Add(Me.btnBorrar)
        Me.Controls.Add(Me.lstFechas)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "DateForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lstFechas As ListBox
    Friend WithEvents btnBorrar As Button
    Friend WithEvents lblSeleccionado As Label
    Friend WithEvents btnAgregar As Button
End Class
