<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CambioPatronColaboradorForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CambioPatronColaboradorForm))
        Me.lblMensajePatron = New System.Windows.Forms.Label()
        Me.cmbPuestoFiscal = New System.Windows.Forms.ComboBox()
        Me.cmbDeptoFiscal = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbPatron = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblColaborador = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblAdvertencia = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.rdoInfonavitSI = New System.Windows.Forms.RadioButton()
        Me.rdoInfonavitNo = New System.Windows.Forms.RadioButton()
        Me.lblCuentaCredito = New System.Windows.Forms.Label()
        Me.dtpFechaBaja = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaAlta = New System.Windows.Forms.DateTimePicker()
        Me.txtSDI = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMensajePatron
        '
        Me.lblMensajePatron.Location = New System.Drawing.Point(29, 230)
        Me.lblMensajePatron.Name = "lblMensajePatron"
        Me.lblMensajePatron.Size = New System.Drawing.Size(481, 80)
        Me.lblMensajePatron.TabIndex = 164
        Me.lblMensajePatron.Text = resources.GetString("lblMensajePatron.Text")
        Me.lblMensajePatron.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbPuestoFiscal
        '
        Me.cmbPuestoFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPuestoFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPuestoFiscal.ForeColor = System.Drawing.Color.Black
        Me.cmbPuestoFiscal.FormattingEnabled = True
        Me.cmbPuestoFiscal.Location = New System.Drawing.Point(119, 162)
        Me.cmbPuestoFiscal.Name = "cmbPuestoFiscal"
        Me.cmbPuestoFiscal.Size = New System.Drawing.Size(215, 24)
        Me.cmbPuestoFiscal.TabIndex = 163
        '
        'cmbDeptoFiscal
        '
        Me.cmbDeptoFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDeptoFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDeptoFiscal.ForeColor = System.Drawing.Color.Black
        Me.cmbDeptoFiscal.FormattingEnabled = True
        Me.cmbDeptoFiscal.Location = New System.Drawing.Point(119, 132)
        Me.cmbDeptoFiscal.Name = "cmbDeptoFiscal"
        Me.cmbDeptoFiscal.Size = New System.Drawing.Size(215, 24)
        Me.cmbDeptoFiscal.TabIndex = 162
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(42, 169)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 13)
        Me.Label14.TabIndex = 161
        Me.Label14.Text = "Puesto fiscal"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 136)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 13)
        Me.Label13.TabIndex = 160
        Me.Label13.Text = "Departamento fiscal"
        '
        'cmbPatron
        '
        Me.cmbPatron.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPatron.FormattingEnabled = True
        Me.cmbPatron.Location = New System.Drawing.Point(119, 79)
        Me.cmbPatron.Name = "cmbPatron"
        Me.cmbPatron.Size = New System.Drawing.Size(390, 21)
        Me.cmbPatron.TabIndex = 157
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(36, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 156
        Me.Label7.Text = "Patrón Destino"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackgroundImage = Global.Contabilidad.Vista.My.Resources.Resources.menubk
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.Location = New System.Drawing.Point(311, 314)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 33)
        Me.btnCancelar.TabIndex = 155
        Me.btnCancelar.Text = "No"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImage = Global.Contabilidad.Vista.My.Resources.Resources.menubk
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.Transparent
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAceptar.Location = New System.Drawing.Point(159, 314)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 33)
        Me.btnAceptar.TabIndex = 154
        Me.btnAceptar.Text = "Si"
        Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'lblColaborador
        '
        Me.lblColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColaborador.Location = New System.Drawing.Point(28, 216)
        Me.lblColaborador.Name = "lblColaborador"
        Me.lblColaborador.Size = New System.Drawing.Size(481, 13)
        Me.lblColaborador.TabIndex = 153
        Me.lblColaborador.Text = "--"
        Me.lblColaborador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(28, 196)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(481, 13)
        Me.Label5.TabIndex = 152
        Me.Label5.Text = "Se realizará Baja del trabajador"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(343, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 149
        Me.Label4.Text = "Fecha alta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(343, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 148
        Me.Label3.Text = "Fecha baja"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(28, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(481, 31)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "Seleccione el patrón al que se cambiará el colaborador:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.Contabilidad.Vista.My.Resources.Resources.menubk
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.lblAdvertencia)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 363)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(538, 40)
        Me.Panel2.TabIndex = 146
        '
        'lblAdvertencia
        '
        Me.lblAdvertencia.BackColor = System.Drawing.Color.Transparent
        Me.lblAdvertencia.ForeColor = System.Drawing.Color.White
        Me.lblAdvertencia.Location = New System.Drawing.Point(29, 14)
        Me.lblAdvertencia.Name = "lblAdvertencia"
        Me.lblAdvertencia.Size = New System.Drawing.Size(481, 13)
        Me.lblAdvertencia.TabIndex = 153
        Me.lblAdvertencia.Text = "NOTA: No se podrá hacer cambio de colaboradores el día en que se cierre nómina."
        Me.lblAdvertencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAdvertencia.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.Contabilidad.Vista.My.Resources.Resources.menubk
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(538, 40)
        Me.Panel1.TabIndex = 145
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.rdoInfonavitSI)
        Me.Panel6.Controls.Add(Me.rdoInfonavitNo)
        Me.Panel6.Enabled = False
        Me.Panel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel6.Location = New System.Drawing.Point(409, 162)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(100, 24)
        Me.Panel6.TabIndex = 166
        '
        'rdoInfonavitSI
        '
        Me.rdoInfonavitSI.AutoSize = True
        Me.rdoInfonavitSI.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdoInfonavitSI.Location = New System.Drawing.Point(10, 3)
        Me.rdoInfonavitSI.Name = "rdoInfonavitSI"
        Me.rdoInfonavitSI.Size = New System.Drawing.Size(34, 17)
        Me.rdoInfonavitSI.TabIndex = 20
        Me.rdoInfonavitSI.Text = "Si"
        Me.rdoInfonavitSI.UseVisualStyleBackColor = True
        '
        'rdoInfonavitNo
        '
        Me.rdoInfonavitNo.AutoSize = True
        Me.rdoInfonavitNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdoInfonavitNo.Location = New System.Drawing.Point(50, 3)
        Me.rdoInfonavitNo.Name = "rdoInfonavitNo"
        Me.rdoInfonavitNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoInfonavitNo.TabIndex = 21
        Me.rdoInfonavitNo.Text = "No"
        Me.rdoInfonavitNo.UseVisualStyleBackColor = True
        '
        'lblCuentaCredito
        '
        Me.lblCuentaCredito.AutoSize = True
        Me.lblCuentaCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuentaCredito.Location = New System.Drawing.Point(343, 169)
        Me.lblCuentaCredito.Name = "lblCuentaCredito"
        Me.lblCuentaCredito.Size = New System.Drawing.Size(64, 13)
        Me.lblCuentaCredito.TabIndex = 165
        Me.lblCuentaCredito.Text = "INFONAVIT"
        '
        'dtpFechaBaja
        '
        Me.dtpFechaBaja.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaBaja.Location = New System.Drawing.Point(409, 106)
        Me.dtpFechaBaja.Name = "dtpFechaBaja"
        Me.dtpFechaBaja.Size = New System.Drawing.Size(101, 20)
        Me.dtpFechaBaja.TabIndex = 167
        '
        'dtpFechaAlta
        '
        Me.dtpFechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAlta.Location = New System.Drawing.Point(409, 134)
        Me.dtpFechaAlta.Name = "dtpFechaAlta"
        Me.dtpFechaAlta.Size = New System.Drawing.Size(101, 20)
        Me.dtpFechaAlta.TabIndex = 168
        '
        'txtSDI
        '
        Me.txtSDI.Location = New System.Drawing.Point(119, 106)
        Me.txtSDI.Name = "txtSDI"
        Me.txtSDI.Size = New System.Drawing.Size(76, 20)
        Me.txtSDI.TabIndex = 159
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(84, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 158
        Me.Label2.Text = "SDI"
        '
        'CambioPatronColaboradorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(538, 403)
        Me.Controls.Add(Me.dtpFechaAlta)
        Me.Controls.Add(Me.dtpFechaBaja)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.lblCuentaCredito)
        Me.Controls.Add(Me.lblMensajePatron)
        Me.Controls.Add(Me.cmbPuestoFiscal)
        Me.Controls.Add(Me.cmbDeptoFiscal)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtSDI)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbPatron)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.lblColaborador)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(554, 442)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(554, 442)
        Me.Name = "CambioPatronColaboradorForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Protected WithEvents lblMensajePatron As Windows.Forms.Label
    Friend WithEvents cmbPuestoFiscal As Windows.Forms.ComboBox
    Friend WithEvents cmbDeptoFiscal As Windows.Forms.ComboBox
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents cmbPatron As Windows.Forms.ComboBox
    Protected WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents btnAceptar As Windows.Forms.Button
    Protected WithEvents lblColaborador As Windows.Forms.Label
    Protected WithEvents Label5 As Windows.Forms.Label
    Protected WithEvents Label4 As Windows.Forms.Label
    Protected WithEvents Label3 As Windows.Forms.Label
    Protected WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Panel6 As Windows.Forms.Panel
    Friend WithEvents rdoInfonavitSI As Windows.Forms.RadioButton
    Friend WithEvents rdoInfonavitNo As Windows.Forms.RadioButton
    Friend WithEvents lblCuentaCredito As Windows.Forms.Label
    Friend WithEvents dtpFechaBaja As Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaAlta As Windows.Forms.DateTimePicker
    Friend WithEvents txtSDI As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Protected WithEvents lblAdvertencia As Windows.Forms.Label
End Class
