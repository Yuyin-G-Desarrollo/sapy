<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstadosCuentaGeneracionManualForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstadosCuentaGeneracionManualForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CmbClientes = New System.Windows.Forms.ComboBox()
        Me.CmbRFC = New System.Windows.Forms.ComboBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoVencidosFechaAnalisis = New System.Windows.Forms.RadioButton()
        Me.rdoTodos = New System.Windows.Forms.RadioButton()
        Me.lblcliente = New System.Windows.Forms.Label()
        Me.lblrazonSocial = New System.Windows.Forms.Label()
        Me.dtfechaAnalisis = New System.Windows.Forms.DateTimePicker()
        Me.lblfechaAnalisis = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.cmbRazonSocial = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmbRazonSocial)
        Me.Panel1.Controls.Add(Me.CmbClientes)
        Me.Panel1.Controls.Add(Me.CmbRFC)
        Me.Panel1.Controls.Add(Me.cmbTipo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.lblcliente)
        Me.Panel1.Controls.Add(Me.lblrazonSocial)
        Me.Panel1.Controls.Add(Me.dtfechaAnalisis)
        Me.Panel1.Controls.Add(Me.lblfechaAnalisis)
        Me.Panel1.Location = New System.Drawing.Point(14, 14)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(482, 268)
        Me.Panel1.TabIndex = 1
        '
        'CmbClientes
        '
        Me.CmbClientes.FormattingEnabled = True
        Me.CmbClientes.Location = New System.Drawing.Point(96, 110)
        Me.CmbClientes.Name = "CmbClientes"
        Me.CmbClientes.Size = New System.Drawing.Size(362, 21)
        Me.CmbClientes.TabIndex = 16
        '
        'CmbRFC
        '
        Me.CmbRFC.FormattingEnabled = True
        Me.CmbRFC.Location = New System.Drawing.Point(96, 146)
        Me.CmbRFC.Name = "CmbRFC"
        Me.CmbRFC.Size = New System.Drawing.Size(362, 21)
        Me.CmbRFC.TabIndex = 15
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"TODOS", "FACTURAS", "REMISIONES"})
        Me.cmbTipo.Location = New System.Drawing.Point(298, 186)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(160, 21)
        Me.cmbTipo.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "RFC Cliente"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoVencidosFechaAnalisis)
        Me.GroupBox1.Controls.Add(Me.rdoTodos)
        Me.GroupBox1.Location = New System.Drawing.Point(96, 180)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(196, 69)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'rdoVencidosFechaAnalisis
        '
        Me.rdoVencidosFechaAnalisis.AutoSize = True
        Me.rdoVencidosFechaAnalisis.Location = New System.Drawing.Point(6, 40)
        Me.rdoVencidosFechaAnalisis.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdoVencidosFechaAnalisis.Name = "rdoVencidosFechaAnalisis"
        Me.rdoVencidosFechaAnalisis.Size = New System.Drawing.Size(175, 17)
        Me.rdoVencidosFechaAnalisis.TabIndex = 12
        Me.rdoVencidosFechaAnalisis.Text = "Vencidos a la Fecha de Análisis"
        Me.rdoVencidosFechaAnalisis.UseVisualStyleBackColor = True
        '
        'rdoTodos
        '
        Me.rdoTodos.AutoSize = True
        Me.rdoTodos.Checked = True
        Me.rdoTodos.Location = New System.Drawing.Point(6, 17)
        Me.rdoTodos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdoTodos.Name = "rdoTodos"
        Me.rdoTodos.Size = New System.Drawing.Size(55, 17)
        Me.rdoTodos.TabIndex = 11
        Me.rdoTodos.TabStop = True
        Me.rdoTodos.Text = "Todos"
        Me.rdoTodos.UseVisualStyleBackColor = True
        '
        'lblcliente
        '
        Me.lblcliente.AutoSize = True
        Me.lblcliente.Location = New System.Drawing.Point(38, 113)
        Me.lblcliente.Name = "lblcliente"
        Me.lblcliente.Size = New System.Drawing.Size(39, 13)
        Me.lblcliente.TabIndex = 6
        Me.lblcliente.Text = "Cliente"
        '
        'lblrazonSocial
        '
        Me.lblrazonSocial.AutoSize = True
        Me.lblrazonSocial.Location = New System.Drawing.Point(7, 77)
        Me.lblrazonSocial.Name = "lblrazonSocial"
        Me.lblrazonSocial.Size = New System.Drawing.Size(70, 13)
        Me.lblrazonSocial.TabIndex = 4
        Me.lblrazonSocial.Text = "Razón Social"
        '
        'dtfechaAnalisis
        '
        Me.dtfechaAnalisis.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtfechaAnalisis.Location = New System.Drawing.Point(96, 20)
        Me.dtfechaAnalisis.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtfechaAnalisis.Name = "dtfechaAnalisis"
        Me.dtfechaAnalisis.Size = New System.Drawing.Size(97, 20)
        Me.dtfechaAnalisis.TabIndex = 3
        '
        'lblfechaAnalisis
        '
        Me.lblfechaAnalisis.AutoSize = True
        Me.lblfechaAnalisis.Location = New System.Drawing.Point(20, 20)
        Me.lblfechaAnalisis.Name = "lblfechaAnalisis"
        Me.lblfechaAnalisis.Size = New System.Drawing.Size(57, 26)
        Me.lblfechaAnalisis.TabIndex = 2
        Me.lblfechaAnalisis.Text = "Fecha " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de Análisis"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(368, 325)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Imprimir"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(463, 326)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 19
        Me.lblCancelar.Text = "Cerrar"
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Image = Global.Cobranza.Vista.My.Resources.Resources.salir_32
        Me.BtnCerrar.Location = New System.Drawing.Point(465, 290)
        Me.BtnCerrar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(31, 34)
        Me.BtnCerrar.TabIndex = 18
        Me.BtnCerrar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(372, 290)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(33, 35)
        Me.btnImprimir.TabIndex = 14
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(417, 325)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 17
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Cobranza.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(418, 290)
        Me.btnLimpiar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(33, 35)
        Me.btnLimpiar.TabIndex = 16
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'cmbRazonSocial
        '
        Me.cmbRazonSocial.FormattingEnabled = True
        Me.cmbRazonSocial.Location = New System.Drawing.Point(96, 74)
        Me.cmbRazonSocial.Name = "cmbRazonSocial"
        Me.cmbRazonSocial.Size = New System.Drawing.Size(362, 21)
        Me.cmbRazonSocial.TabIndex = 17
        '
        'EstadosCuentaGeneracionManualForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(511, 344)
        Me.Controls.Add(Me.lblLimpiar)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblCancelar)
        Me.Controls.Add(Me.BtnCerrar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximumSize = New System.Drawing.Size(527, 383)
        Me.MinimumSize = New System.Drawing.Size(527, 383)
        Me.Name = "EstadosCuentaGeneracionManualForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estados de Cuenta Generacion Manual"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents rdoVencidosFechaAnalisis As Windows.Forms.RadioButton
    Friend WithEvents rdoTodos As Windows.Forms.RadioButton
    Friend WithEvents lblcliente As Windows.Forms.Label
    Friend WithEvents lblrazonSocial As Windows.Forms.Label
    Friend WithEvents dtfechaAnalisis As Windows.Forms.DateTimePicker
    Friend WithEvents lblfechaAnalisis As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents lblCancelar As Windows.Forms.Label
    Friend WithEvents BtnCerrar As Windows.Forms.Button
    Friend WithEvents btnImprimir As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents lblLimpiar As Windows.Forms.Label
    Friend WithEvents btnLimpiar As Windows.Forms.Button
    Friend WithEvents cmbTipo As Windows.Forms.ComboBox
    Friend WithEvents CmbRFC As Windows.Forms.ComboBox
    Friend WithEvents CmbClientes As Windows.Forms.ComboBox
    Friend WithEvents cmbRazonSocial As Windows.Forms.ComboBox
End Class
