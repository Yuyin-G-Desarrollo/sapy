<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Cobranza_Reporte_EstadosdeCuentaporAgente
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdDetallado = New System.Windows.Forms.RadioButton()
        Me.rdGeneral = New System.Windows.Forms.RadioButton()
        Me.cbtipo = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdFAFA = New System.Windows.Forms.RadioButton()
        Me.rdEFA = New System.Windows.Forms.RadioButton()
        Me.rdTodos = New System.Windows.Forms.RadioButton()
        Me.cmbClientes = New System.Windows.Forms.ComboBox()
        Me.cmbAgente = New System.Windows.Forms.ComboBox()
        Me.cmbRazonSocial = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtfechaAnalisis = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.cbtipo)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.cmbClientes)
        Me.Panel1.Controls.Add(Me.cmbAgente)
        Me.Panel1.Controls.Add(Me.cmbRazonSocial)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dtfechaAnalisis)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(28, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(482, 343)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdGeneral)
        Me.GroupBox2.Controls.Add(Me.rdDetallado)
        Me.GroupBox2.Location = New System.Drawing.Point(96, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(349, 58)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo Reporte"
        '
        'rdDetallado
        '
        Me.rdDetallado.AutoSize = True
        Me.rdDetallado.Location = New System.Drawing.Point(224, 19)
        Me.rdDetallado.Name = "rdDetallado"
        Me.rdDetallado.Size = New System.Drawing.Size(70, 17)
        Me.rdDetallado.TabIndex = 11
        Me.rdDetallado.Text = "Detallado"
        Me.rdDetallado.UseVisualStyleBackColor = True
        '
        'rdGeneral
        '
        Me.rdGeneral.AutoSize = True
        Me.rdGeneral.Checked = True
        Me.rdGeneral.Location = New System.Drawing.Point(58, 19)
        Me.rdGeneral.Name = "rdGeneral"
        Me.rdGeneral.Size = New System.Drawing.Size(62, 17)
        Me.rdGeneral.TabIndex = 10
        Me.rdGeneral.TabStop = True
        Me.rdGeneral.Text = "General"
        Me.rdGeneral.UseVisualStyleBackColor = True
        Me.rdGeneral.Visible = False
        '
        'cbtipo
        '
        Me.cbtipo.FormattingEnabled = True
        Me.cbtipo.Items.AddRange(New Object() {"TODOS", "FACTURAS", "REMISIONES"})
        Me.cbtipo.Location = New System.Drawing.Point(298, 273)
        Me.cbtipo.Name = "cbtipo"
        Me.cbtipo.Size = New System.Drawing.Size(161, 21)
        Me.cbtipo.TabIndex = 14
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdFAFA)
        Me.GroupBox1.Controls.Add(Me.rdEFA)
        Me.GroupBox1.Controls.Add(Me.rdTodos)
        Me.GroupBox1.Location = New System.Drawing.Point(96, 237)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(196, 92)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'rdFAFA
        '
        Me.rdFAFA.AutoSize = True
        Me.rdFAFA.Location = New System.Drawing.Point(6, 40)
        Me.rdFAFA.Name = "rdFAFA"
        Me.rdFAFA.Size = New System.Drawing.Size(175, 17)
        Me.rdFAFA.TabIndex = 11
        Me.rdFAFA.Text = "Vencidos a la Fecha de Análisis"
        Me.rdFAFA.UseVisualStyleBackColor = True
        '
        'rdEFA
        '
        Me.rdEFA.AutoSize = True
        Me.rdEFA.Location = New System.Drawing.Point(6, 63)
        Me.rdEFA.Name = "rdEFA"
        Me.rdEFA.Size = New System.Drawing.Size(181, 17)
        Me.rdEFA.TabIndex = 12
        Me.rdEFA.Text = "Vencidos en la Fecha de Análisis"
        Me.rdEFA.UseVisualStyleBackColor = True
        '
        'rdTodos
        '
        Me.rdTodos.AutoSize = True
        Me.rdTodos.Checked = True
        Me.rdTodos.Location = New System.Drawing.Point(6, 17)
        Me.rdTodos.Name = "rdTodos"
        Me.rdTodos.Size = New System.Drawing.Size(55, 17)
        Me.rdTodos.TabIndex = 10
        Me.rdTodos.TabStop = True
        Me.rdTodos.Text = "Todos"
        Me.rdTodos.UseVisualStyleBackColor = True
        '
        'cmbClientes
        '
        Me.cmbClientes.FormattingEnabled = True
        Me.cmbClientes.Location = New System.Drawing.Point(96, 210)
        Me.cmbClientes.Name = "cmbClientes"
        Me.cmbClientes.Size = New System.Drawing.Size(349, 21)
        Me.cmbClientes.TabIndex = 9
        '
        'cmbAgente
        '
        Me.cmbAgente.FormattingEnabled = True
        Me.cmbAgente.Location = New System.Drawing.Point(96, 173)
        Me.cmbAgente.Name = "cmbAgente"
        Me.cmbAgente.Size = New System.Drawing.Size(349, 21)
        Me.cmbAgente.TabIndex = 8
        '
        'cmbRazonSocial
        '
        Me.cmbRazonSocial.FormattingEnabled = True
        Me.cmbRazonSocial.Location = New System.Drawing.Point(96, 134)
        Me.cmbRazonSocial.Name = "cmbRazonSocial"
        Me.cmbRazonSocial.Size = New System.Drawing.Size(349, 21)
        Me.cmbRazonSocial.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 213)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 181)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Agente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Razón Social"
        '
        'dtfechaAnalisis
        '
        Me.dtfechaAnalisis.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtfechaAnalisis.Location = New System.Drawing.Point(96, 91)
        Me.dtfechaAnalisis.Name = "dtfechaAnalisis"
        Me.dtfechaAnalisis.Size = New System.Drawing.Size(97, 20)
        Me.dtfechaAnalisis.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de Análisis"
        '
        'Button1
        '
        Me.Button1.Image = Global.Cobranza.Vista.My.Resources.Resources.reporteDeducciones_
        Me.Button1.Location = New System.Drawing.Point(411, 388)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(33, 35)
        Me.Button1.TabIndex = 1
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.Cobranza.Vista.My.Resources.Resources.salir_32
        Me.Button2.Location = New System.Drawing.Point(468, 389)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(31, 32)
        Me.Button2.TabIndex = 2
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(465, 424)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(409, 423)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Imprimir"
        '
        'Cobranza_Reporte_EstadosdeCuentaporAgente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(527, 445)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblCancelar)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Cobranza_Reporte_EstadosdeCuentaporAgente"
        Me.Text = "Estados de Cuenta General (CXC) "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents rdEFA As Windows.Forms.RadioButton
    Friend WithEvents rdFAFA As Windows.Forms.RadioButton
    Friend WithEvents rdTodos As Windows.Forms.RadioButton
    Friend WithEvents cmbClientes As Windows.Forms.ComboBox
    Friend WithEvents cmbAgente As Windows.Forms.ComboBox
    Friend WithEvents cmbRazonSocial As Windows.Forms.ComboBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents dtfechaAnalisis As Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents cbtipo As Windows.Forms.ComboBox
    Friend WithEvents lblCancelar As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents rdDetallado As Windows.Forms.RadioButton
    Friend WithEvents rdGeneral As Windows.Forms.RadioButton
End Class
