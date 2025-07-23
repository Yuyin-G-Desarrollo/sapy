<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambioNaveColaboradorForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CambioNaveColaboradorForm))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblNota = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.txtFechaCorteNaveOrigen = New System.Windows.Forms.TextBox()
        Me.txtFechaCorteNaveDestino = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblColaborador = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.cmbPatron = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.Contabilidad.Vista.My.Resources.Resources.menubk
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.lblNota)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 363)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(538, 40)
        Me.Panel2.TabIndex = 1
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
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.Contabilidad.Vista.My.Resources.Resources.menubk
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(538, 40)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(28, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(481, 38)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Seleccione la nave a la que se cambiará el colaborador" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Nota: Si no se encuentra" &
    " la nave destino favor de notificar a contabilidad.)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nave Destino"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fecha corte nave"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(274, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Fecha corte nave destino"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(159, 84)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(350, 21)
        Me.cmbNave.TabIndex = 6
        '
        'txtFechaCorteNaveOrigen
        '
        Me.txtFechaCorteNaveOrigen.Location = New System.Drawing.Point(159, 138)
        Me.txtFechaCorteNaveOrigen.Name = "txtFechaCorteNaveOrigen"
        Me.txtFechaCorteNaveOrigen.ReadOnly = True
        Me.txtFechaCorteNaveOrigen.Size = New System.Drawing.Size(100, 20)
        Me.txtFechaCorteNaveOrigen.TabIndex = 7
        '
        'txtFechaCorteNaveDestino
        '
        Me.txtFechaCorteNaveDestino.Location = New System.Drawing.Point(408, 138)
        Me.txtFechaCorteNaveDestino.Name = "txtFechaCorteNaveDestino"
        Me.txtFechaCorteNaveDestino.ReadOnly = True
        Me.txtFechaCorteNaveDestino.Size = New System.Drawing.Size(100, 20)
        Me.txtFechaCorteNaveDestino.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(28, 183)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(481, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Se realizará Baja del trabajador"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblColaborador
        '
        Me.lblColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColaborador.Location = New System.Drawing.Point(28, 203)
        Me.lblColaborador.Name = "lblColaborador"
        Me.lblColaborador.Size = New System.Drawing.Size(481, 13)
        Me.lblColaborador.TabIndex = 10
        Me.lblColaborador.Text = "--"
        Me.lblColaborador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(29, 230)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(481, 80)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = resources.GetString("Label6.Text")
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.btnCancelar.TabIndex = 16
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
        Me.btnAceptar.TabIndex = 15
        Me.btnAceptar.Text = "Si"
        Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'cmbPatron
        '
        Me.cmbPatron.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPatron.FormattingEnabled = True
        Me.cmbPatron.Location = New System.Drawing.Point(159, 110)
        Me.cmbPatron.Name = "cmbPatron"
        Me.cmbPatron.Size = New System.Drawing.Size(350, 21)
        Me.cmbPatron.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(25, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Patrón Destino"
        '
        'CambioNaveColaboradorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(538, 403)
        Me.Controls.Add(Me.cmbPatron)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblColaborador)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtFechaCorteNaveDestino)
        Me.Controls.Add(Me.txtFechaCorteNaveOrigen)
        Me.Controls.Add(Me.cmbNave)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CambioNaveColaboradorForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Protected WithEvents Label1 As Windows.Forms.Label
    Protected WithEvents Label2 As Windows.Forms.Label
    Protected WithEvents Label3 As Windows.Forms.Label
    Protected WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents cmbNave As Windows.Forms.ComboBox
    Friend WithEvents txtFechaCorteNaveOrigen As Windows.Forms.TextBox
    Friend WithEvents txtFechaCorteNaveDestino As Windows.Forms.TextBox
    Protected WithEvents Label5 As Windows.Forms.Label
    Protected WithEvents lblColaborador As Windows.Forms.Label
    Protected WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents btnAceptar As Windows.Forms.Button
    Friend WithEvents lblNota As System.Windows.Forms.Label
    Friend WithEvents cmbPatron As Windows.Forms.ComboBox
    Protected WithEvents Label7 As Windows.Forms.Label
End Class
