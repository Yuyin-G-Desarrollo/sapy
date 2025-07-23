<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarMotivosForm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnCancelarPais = New System.Windows.Forms.Button()
        Me.btnGuardarPais = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.txtMontoMaximo = New System.Windows.Forms.TextBox()
        Me.txtDescripcionMotivo = New System.Windows.Forms.TextBox()
        Me.txtNombreMotivo = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblLimpiar)
        Me.Panel1.Controls.Add(Me.lblBuscar)
        Me.Panel1.Controls.Add(Me.btnCancelarPais)
        Me.Panel1.Controls.Add(Me.btnGuardarPais)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.cmbNave)
        Me.Panel1.Controls.Add(Me.txtMontoMaximo)
        Me.Panel1.Controls.Add(Me.txtDescripcionMotivo)
        Me.Panel1.Controls.Add(Me.txtNombreMotivo)
        Me.Panel1.Controls.Add(Me.lblDescripcion)
        Me.Panel1.Controls.Add(Me.lblMonto)
        Me.Panel1.Controls.Add(Me.lblNave)
        Me.Panel1.Controls.Add(Me.lblActivo)
        Me.Panel1.Controls.Add(Me.lblNombre)
        Me.Panel1.Location = New System.Drawing.Point(14, 78)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(415, 253)
        Me.Panel1.TabIndex = 10
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(352, 207)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(49, 13)
        Me.lblLimpiar.TabIndex = 19
        Me.lblLimpiar.Text = "Cancelar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(289, 207)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(45, 13)
        Me.lblBuscar.TabIndex = 18
        Me.lblBuscar.Text = "Guardar"
        '
        'btnCancelarPais
        '
        Me.btnCancelarPais.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.cancelar_32
        Me.btnCancelarPais.Location = New System.Drawing.Point(355, 171)
        Me.btnCancelarPais.Name = "btnCancelarPais"
        Me.btnCancelarPais.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarPais.TabIndex = 17
        Me.btnCancelarPais.UseVisualStyleBackColor = True
        '
        'btnGuardarPais
        '
        Me.btnGuardarPais.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.guardar_32
        Me.btnGuardarPais.Location = New System.Drawing.Point(293, 171)
        Me.btnGuardarPais.Name = "btnGuardarPais"
        Me.btnGuardarPais.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarPais.TabIndex = 16
        Me.btnGuardarPais.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdoActivoNo)
        Me.Panel2.Controls.Add(Me.rdoActivoSi)
        Me.Panel2.Location = New System.Drawing.Point(107, 164)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(94, 30)
        Me.Panel2.TabIndex = 15
        '
        'rdoActivoNo
        '
        Me.rdoActivoNo.AutoSize = True
        Me.rdoActivoNo.Location = New System.Drawing.Point(52, 7)
        Me.rdoActivoNo.Name = "rdoActivoNo"
        Me.rdoActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoActivoNo.TabIndex = 6
        Me.rdoActivoNo.TabStop = True
        Me.rdoActivoNo.Text = "No"
        Me.rdoActivoNo.UseVisualStyleBackColor = True
        '
        'rdoActivoSi
        '
        Me.rdoActivoSi.AutoSize = True
        Me.rdoActivoSi.Checked = True
        Me.rdoActivoSi.Location = New System.Drawing.Point(3, 7)
        Me.rdoActivoSi.Name = "rdoActivoSi"
        Me.rdoActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivoSi.TabIndex = 5
        Me.rdoActivoSi.TabStop = True
        Me.rdoActivoSi.Text = "Si"
        Me.rdoActivoSi.UseVisualStyleBackColor = True
        '
        'cmbNave
        '
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(107, 122)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(121, 21)
        Me.cmbNave.TabIndex = 8
        '
        'txtMontoMaximo
        '
        Me.txtMontoMaximo.Location = New System.Drawing.Point(107, 85)
        Me.txtMontoMaximo.Name = "txtMontoMaximo"
        Me.txtMontoMaximo.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoMaximo.TabIndex = 7
        '
        'txtDescripcionMotivo
        '
        Me.txtDescripcionMotivo.Location = New System.Drawing.Point(107, 52)
        Me.txtDescripcionMotivo.Name = "txtDescripcionMotivo"
        Me.txtDescripcionMotivo.Size = New System.Drawing.Size(100, 20)
        Me.txtDescripcionMotivo.TabIndex = 6
        '
        'txtNombreMotivo
        '
        Me.txtNombreMotivo.Location = New System.Drawing.Point(107, 21)
        Me.txtNombreMotivo.Name = "txtNombreMotivo"
        Me.txtNombreMotivo.Size = New System.Drawing.Size(100, 20)
        Me.txtNombreMotivo.TabIndex = 5
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(24, 59)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 4
        Me.lblDescripcion.Text = "Descripcion"
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Location = New System.Drawing.Point(11, 92)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(76, 13)
        Me.lblMonto.TabIndex = 3
        Me.lblMonto.Text = "Monto Maximo"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(51, 130)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 2
        Me.lblNave.Text = "Nave"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(47, 164)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 1
        Me.lblActivo.Text = "Activo"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(41, 28)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = "Nombre"
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Controls.Add(Me.pbYuyin)
        Me.pnlListaPaises.Location = New System.Drawing.Point(3, 1)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(438, 70)
        Me.pnlListaPaises.TabIndex = 9
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(192, 49)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(235, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Editar Motivos de Incentivos"
        '
        'pbYuyin
        '
        Me.pbYuyin.Image = Global.Nomina.Vista.My.Resources.Resources.yuyin
        Me.pbYuyin.Location = New System.Drawing.Point(319, 3)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(119, 56)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 0
        Me.pbYuyin.TabStop = False
        '
        'EditarMotivosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(435, 339)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EditarMotivosForm"
        Me.Text = "Editar Motivos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnCancelarPais As System.Windows.Forms.Button
    Friend WithEvents btnGuardarPais As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents txtMontoMaximo As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcionMotivo As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreMotivo As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
End Class
