<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambioColaboradorNaveForm
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblNota = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.cmbPatron = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblColaborador = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlGeneral = New System.Windows.Forms.Panel()
        Me.pnlPatron = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        Me.pnlGeneral.SuspendLayout()
        Me.pnlPatron.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.menubk
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(533, 40)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.menubk
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.lblNota)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 354)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(533, 40)
        Me.Panel2.TabIndex = 2
        '
        'lblNota
        '
        Me.lblNota.BackColor = System.Drawing.Color.Transparent
        Me.lblNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNota.ForeColor = System.Drawing.Color.White
        Me.lblNota.Location = New System.Drawing.Point(20, 5)
        Me.lblNota.Name = "lblNota"
        Me.lblNota.Size = New System.Drawing.Size(497, 31)
        Me.lblNota.TabIndex = 26
        Me.lblNota.Text = "NOTA: No se podrá hacer cambio de colaboradores el día en que se cierre nómina ta" &
    "nto en la nave origen como en la de destino."
        Me.lblNota.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNota.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(583, 38)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Seleccione la nave a la que se le cambiará el colaborador"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(122, 89)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(350, 21)
        Me.cmbNave.TabIndex = 7
        '
        'cmbPatron
        '
        Me.cmbPatron.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPatron.FormattingEnabled = True
        Me.cmbPatron.Location = New System.Drawing.Point(99, 3)
        Me.cmbPatron.Name = "cmbPatron"
        Me.cmbPatron.Size = New System.Drawing.Size(350, 21)
        Me.cmbPatron.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(32, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(437, 25)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Se realizará el cambio de nave del colaborador."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblColaborador
        '
        Me.lblColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColaborador.Location = New System.Drawing.Point(24, 226)
        Me.lblColaborador.Name = "lblColaborador"
        Me.lblColaborador.Size = New System.Drawing.Size(445, 22)
        Me.lblColaborador.TabIndex = 23
        Me.lblColaborador.Text = "--"
        Me.lblColaborador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(448, 22)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "¿Está seguro de continuar?"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.menubk
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.Transparent
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAceptar.Location = New System.Drawing.Point(122, 295)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 33)
        Me.btnAceptar.TabIndex = 25
        Me.btnAceptar.Text = "Si"
        Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.menubk
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.Location = New System.Drawing.Point(290, 295)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 33)
        Me.btnCancelar.TabIndex = 26
        Me.btnCancelar.Text = "No"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Nave Destino"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Patrón Destino"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Observaciones"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.TextBox1.Location = New System.Drawing.Point(99, 6)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(350, 20)
        Me.TextBox1.TabIndex = 30
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(29, 248)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(452, 25)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Posterriormente no se podrán realizar cambios"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlGeneral
        '
        Me.pnlGeneral.Controls.Add(Me.Panel4)
        Me.pnlGeneral.Controls.Add(Me.pnlPatron)
        Me.pnlGeneral.Location = New System.Drawing.Point(23, 116)
        Me.pnlGeneral.Name = "pnlGeneral"
        Me.pnlGeneral.Size = New System.Drawing.Size(472, 66)
        Me.pnlGeneral.TabIndex = 32
        '
        'pnlPatron
        '
        Me.pnlPatron.Controls.Add(Me.Label3)
        Me.pnlPatron.Controls.Add(Me.cmbPatron)
        Me.pnlPatron.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPatron.Location = New System.Drawing.Point(0, 0)
        Me.pnlPatron.Name = "pnlPatron"
        Me.pnlPatron.Size = New System.Drawing.Size(472, 31)
        Me.pnlPatron.TabIndex = 29
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.TextBox1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 31)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(472, 31)
        Me.Panel4.TabIndex = 30
        '
        'CambioColaboradorNaveForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(533, 394)
        Me.Controls.Add(Me.pnlGeneral)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblColaborador)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbNave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CambioColaboradorNaveForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.pnlGeneral.ResumeLayout(False)
        Me.pnlPatron.ResumeLayout(False)
        Me.pnlPatron.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblNota As Label
    Protected WithEvents Label1 As Label
    Friend WithEvents cmbNave As ComboBox
    Friend WithEvents cmbPatron As ComboBox
    Protected WithEvents Label5 As Label
    Protected WithEvents lblColaborador As Label
    Protected WithEvents Label6 As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Protected WithEvents Label7 As Label
    Friend WithEvents pnlGeneral As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents pnlPatron As Panel
End Class
