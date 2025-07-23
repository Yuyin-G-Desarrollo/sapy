<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasPatronesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltasPatronesForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblListaPatrones = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.grbPatrones = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rdoComisionNO = New System.Windows.Forms.RadioButton()
        Me.rdoComisionSI = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSi = New System.Windows.Forms.RadioButton()
        Me.btnNo = New System.Windows.Forms.RadioButton()
        Me.pnlPorcentaje = New System.Windows.Forms.Panel()
        Me.numPorcentajeComision = New System.Windows.Forms.NumericUpDown()
        Me.lblPorcentaje = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCP = New System.Windows.Forms.TextBox()
        Me.txtColonia = New System.Windows.Forms.TextBox()
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.txtRFC = New System.Windows.Forms.TextBox()
        Me.txtNumeroDeRegistro = New System.Windows.Forms.TextBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.lblCalle = New System.Windows.Forms.Label()
        Me.lblNúmero = New System.Windows.Forms.Label()
        Me.lblColonia = New System.Windows.Forms.Label()
        Me.lblCiudad = New System.Windows.Forms.Label()
        Me.lblCP = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.lblNombreDelPatron = New System.Windows.Forms.Label()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.cmbCiudad = New System.Windows.Forms.ComboBox()
        Me.lblNumeroDeRegistroPatronal = New System.Windows.Forms.Label()
        Me.txtNombreDelPatron = New System.Windows.Forms.TextBox()
        Me.CalculoAguinaldosDS1 = New Nomina.Vista.CalculoAguinaldosDS()
        Me.CalculoAguinaldosDS2 = New Nomina.Vista.CalculoAguinaldosDS()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.grbPatrones.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlPorcentaje.SuspendLayout()
        CType(Me.numPorcentajeComision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CalculoAguinaldosDS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CalculoAguinaldosDS2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pcbTitulo)
        Me.pnlEncabezado.Controls.Add(Me.lblListaPatrones)
        Me.pnlEncabezado.Location = New System.Drawing.Point(-1, 4)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(617, 59)
        Me.pnlEncabezado.TabIndex = 6
        '
        'lblListaPatrones
        '
        Me.lblListaPatrones.AutoSize = True
        Me.lblListaPatrones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaPatrones.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaPatrones.Location = New System.Drawing.Point(283, 19)
        Me.lblListaPatrones.Name = "lblListaPatrones"
        Me.lblListaPatrones.Size = New System.Drawing.Size(239, 20)
        Me.lblListaPatrones.TabIndex = 23
        Me.lblListaPatrones.Text = "Alta de Registros Patronales"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(555, 457)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 47
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(496, 457)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 46
        Me.lblGuardar.Text = "Guardar"
        '
        'grbPatrones
        '
        Me.grbPatrones.Controls.Add(Me.Panel3)
        Me.grbPatrones.Controls.Add(Me.Panel2)
        Me.grbPatrones.Controls.Add(Me.pnlPorcentaje)
        Me.grbPatrones.Controls.Add(Me.Label1)
        Me.grbPatrones.Controls.Add(Me.txtCP)
        Me.grbPatrones.Controls.Add(Me.txtColonia)
        Me.grbPatrones.Controls.Add(Me.txtCalle)
        Me.grbPatrones.Controls.Add(Me.txtRFC)
        Me.grbPatrones.Controls.Add(Me.txtNumeroDeRegistro)
        Me.grbPatrones.Controls.Add(Me.txtNumero)
        Me.grbPatrones.Controls.Add(Me.lblCalle)
        Me.grbPatrones.Controls.Add(Me.lblNúmero)
        Me.grbPatrones.Controls.Add(Me.lblColonia)
        Me.grbPatrones.Controls.Add(Me.lblCiudad)
        Me.grbPatrones.Controls.Add(Me.lblCP)
        Me.grbPatrones.Controls.Add(Me.lblActivo)
        Me.grbPatrones.Controls.Add(Me.lblNombreDelPatron)
        Me.grbPatrones.Controls.Add(Me.lblRFC)
        Me.grbPatrones.Controls.Add(Me.cmbCiudad)
        Me.grbPatrones.Controls.Add(Me.lblNumeroDeRegistroPatronal)
        Me.grbPatrones.Controls.Add(Me.txtNombreDelPatron)
        Me.grbPatrones.Location = New System.Drawing.Point(19, 77)
        Me.grbPatrones.Name = "grbPatrones"
        Me.grbPatrones.Size = New System.Drawing.Size(576, 339)
        Me.grbPatrones.TabIndex = 48
        Me.grbPatrones.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rdoComisionNO)
        Me.Panel3.Controls.Add(Me.rdoComisionSI)
        Me.Panel3.Location = New System.Drawing.Point(182, 295)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(111, 29)
        Me.Panel3.TabIndex = 67
        '
        'rdoComisionNO
        '
        Me.rdoComisionNO.AutoSize = True
        Me.rdoComisionNO.Location = New System.Drawing.Point(59, 6)
        Me.rdoComisionNO.Name = "rdoComisionNO"
        Me.rdoComisionNO.Size = New System.Drawing.Size(39, 17)
        Me.rdoComisionNO.TabIndex = 61
        Me.rdoComisionNO.Text = "No"
        Me.rdoComisionNO.UseVisualStyleBackColor = True
        '
        'rdoComisionSI
        '
        Me.rdoComisionSI.AutoSize = True
        Me.rdoComisionSI.Checked = True
        Me.rdoComisionSI.Location = New System.Drawing.Point(8, 6)
        Me.rdoComisionSI.Name = "rdoComisionSI"
        Me.rdoComisionSI.Size = New System.Drawing.Size(34, 17)
        Me.rdoComisionSI.TabIndex = 60
        Me.rdoComisionSI.TabStop = True
        Me.rdoComisionSI.Text = "Si"
        Me.rdoComisionSI.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnSi)
        Me.Panel2.Controls.Add(Me.btnNo)
        Me.Panel2.Location = New System.Drawing.Point(182, 256)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(111, 29)
        Me.Panel2.TabIndex = 66
        '
        'btnSi
        '
        Me.btnSi.AutoSize = True
        Me.btnSi.Checked = True
        Me.btnSi.Location = New System.Drawing.Point(8, 6)
        Me.btnSi.Name = "btnSi"
        Me.btnSi.Size = New System.Drawing.Size(34, 17)
        Me.btnSi.TabIndex = 9
        Me.btnSi.TabStop = True
        Me.btnSi.Text = "Si"
        Me.btnSi.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.AutoSize = True
        Me.btnNo.Location = New System.Drawing.Point(59, 6)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(39, 17)
        Me.btnNo.TabIndex = 10
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'pnlPorcentaje
        '
        Me.pnlPorcentaje.Controls.Add(Me.numPorcentajeComision)
        Me.pnlPorcentaje.Controls.Add(Me.lblPorcentaje)
        Me.pnlPorcentaje.Location = New System.Drawing.Point(313, 295)
        Me.pnlPorcentaje.Name = "pnlPorcentaje"
        Me.pnlPorcentaje.Size = New System.Drawing.Size(165, 29)
        Me.pnlPorcentaje.TabIndex = 65
        '
        'numPorcentajeComision
        '
        Me.numPorcentajeComision.DecimalPlaces = 2
        Me.numPorcentajeComision.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numPorcentajeComision.Location = New System.Drawing.Point(70, 5)
        Me.numPorcentajeComision.Name = "numPorcentajeComision"
        Me.numPorcentajeComision.Size = New System.Drawing.Size(81, 20)
        Me.numPorcentajeComision.TabIndex = 63
        Me.numPorcentajeComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPorcentaje
        '
        Me.lblPorcentaje.AutoSize = True
        Me.lblPorcentaje.Location = New System.Drawing.Point(6, 7)
        Me.lblPorcentaje.Name = "lblPorcentaje"
        Me.lblPorcentaje.Size = New System.Drawing.Size(58, 13)
        Me.lblPorcentaje.TabIndex = 64
        Me.lblPorcentaje.Text = "Porcentaje"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 300)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Maneja Comisiones"
        '
        'txtCP
        '
        Me.txtCP.Location = New System.Drawing.Point(182, 230)
        Me.txtCP.MaxLength = 50
        Me.txtCP.Name = "txtCP"
        Me.txtCP.Size = New System.Drawing.Size(109, 20)
        Me.txtCP.TabIndex = 8
        '
        'txtColonia
        '
        Me.txtColonia.Location = New System.Drawing.Point(182, 170)
        Me.txtColonia.MaxLength = 50
        Me.txtColonia.Name = "txtColonia"
        Me.txtColonia.Size = New System.Drawing.Size(360, 20)
        Me.txtColonia.TabIndex = 6
        '
        'txtCalle
        '
        Me.txtCalle.Location = New System.Drawing.Point(182, 110)
        Me.txtCalle.MaxLength = 50
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(360, 20)
        Me.txtCalle.TabIndex = 4
        '
        'txtRFC
        '
        Me.txtRFC.Location = New System.Drawing.Point(182, 50)
        Me.txtRFC.MaxLength = 13
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(109, 20)
        Me.txtRFC.TabIndex = 2
        '
        'txtNumeroDeRegistro
        '
        Me.txtNumeroDeRegistro.Location = New System.Drawing.Point(182, 80)
        Me.txtNumeroDeRegistro.MaxLength = 50
        Me.txtNumeroDeRegistro.Name = "txtNumeroDeRegistro"
        Me.txtNumeroDeRegistro.Size = New System.Drawing.Size(360, 20)
        Me.txtNumeroDeRegistro.TabIndex = 3
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(182, 140)
        Me.txtNumero.MaxLength = 50
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(109, 20)
        Me.txtNumero.TabIndex = 5
        '
        'lblCalle
        '
        Me.lblCalle.AutoSize = True
        Me.lblCalle.Location = New System.Drawing.Point(26, 112)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(34, 13)
        Me.lblCalle.TabIndex = 59
        Me.lblCalle.Text = "*Calle"
        '
        'lblNúmero
        '
        Me.lblNúmero.AutoSize = True
        Me.lblNúmero.Location = New System.Drawing.Point(26, 142)
        Me.lblNúmero.Name = "lblNúmero"
        Me.lblNúmero.Size = New System.Drawing.Size(48, 13)
        Me.lblNúmero.TabIndex = 58
        Me.lblNúmero.Text = "*Número"
        '
        'lblColonia
        '
        Me.lblColonia.AutoSize = True
        Me.lblColonia.Location = New System.Drawing.Point(26, 172)
        Me.lblColonia.Name = "lblColonia"
        Me.lblColonia.Size = New System.Drawing.Size(46, 13)
        Me.lblColonia.TabIndex = 57
        Me.lblColonia.Text = "*Colonia"
        '
        'lblCiudad
        '
        Me.lblCiudad.AutoSize = True
        Me.lblCiudad.Location = New System.Drawing.Point(26, 202)
        Me.lblCiudad.Name = "lblCiudad"
        Me.lblCiudad.Size = New System.Drawing.Size(44, 13)
        Me.lblCiudad.TabIndex = 56
        Me.lblCiudad.Text = "*Ciudad"
        '
        'lblCP
        '
        Me.lblCP.AutoSize = True
        Me.lblCP.Location = New System.Drawing.Point(26, 232)
        Me.lblCP.Name = "lblCP"
        Me.lblCP.Size = New System.Drawing.Size(31, 13)
        Me.lblCP.TabIndex = 55
        Me.lblCP.Text = "*C.P."
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(26, 266)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 54
        Me.lblActivo.Text = "Activo"
        '
        'lblNombreDelPatron
        '
        Me.lblNombreDelPatron.AutoSize = True
        Me.lblNombreDelPatron.Location = New System.Drawing.Point(26, 22)
        Me.lblNombreDelPatron.Name = "lblNombreDelPatron"
        Me.lblNombreDelPatron.Size = New System.Drawing.Size(51, 13)
        Me.lblNombreDelPatron.TabIndex = 43
        Me.lblNombreDelPatron.Text = "*Nombre "
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.Location = New System.Drawing.Point(26, 52)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(32, 13)
        Me.lblRFC.TabIndex = 40
        Me.lblRFC.Text = "*RFC"
        '
        'cmbCiudad
        '
        Me.cmbCiudad.Location = New System.Drawing.Point(182, 200)
        Me.cmbCiudad.Name = "cmbCiudad"
        Me.cmbCiudad.Size = New System.Drawing.Size(360, 21)
        Me.cmbCiudad.TabIndex = 7
        '
        'lblNumeroDeRegistroPatronal
        '
        Me.lblNumeroDeRegistroPatronal.AutoSize = True
        Me.lblNumeroDeRegistroPatronal.Location = New System.Drawing.Point(26, 82)
        Me.lblNumeroDeRegistroPatronal.Name = "lblNumeroDeRegistroPatronal"
        Me.lblNumeroDeRegistroPatronal.Size = New System.Drawing.Size(147, 13)
        Me.lblNumeroDeRegistroPatronal.TabIndex = 39
        Me.lblNumeroDeRegistroPatronal.Text = "*Número de Registro Patronal"
        '
        'txtNombreDelPatron
        '
        Me.txtNombreDelPatron.Location = New System.Drawing.Point(182, 20)
        Me.txtNombreDelPatron.MaxLength = 50
        Me.txtNombreDelPatron.Name = "txtNombreDelPatron"
        Me.txtNombreDelPatron.Size = New System.Drawing.Size(360, 20)
        Me.txtNombreDelPatron.TabIndex = 1
        '
        'CalculoAguinaldosDS1
        '
        Me.CalculoAguinaldosDS1.DataSetName = "CalculoAguinaldosDS"
        Me.CalculoAguinaldosDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CalculoAguinaldosDS2
        '
        Me.CalculoAguinaldosDS2.DataSetName = "CalculoAguinaldosDS"
        Me.CalculoAguinaldosDS2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btnGuardar
        '
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(503, 422)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 11
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCncelar.Location = New System.Drawing.Point(555, 422)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 12
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(549, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 30
        Me.pcbTitulo.TabStop = False
        '
        'AltasPatronesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(626, 492)
        Me.Controls.Add(Me.grbPatrones)
        Me.Controls.Add(Me.lblCancelar)
        Me.Controls.Add(Me.lblGuardar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCncelar)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(632, 514)
        Me.MinimumSize = New System.Drawing.Size(632, 514)
        Me.Name = "AltasPatronesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registros Patronales"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.grbPatrones.ResumeLayout(False)
        Me.grbPatrones.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlPorcentaje.ResumeLayout(False)
        Me.pnlPorcentaje.PerformLayout()
        CType(Me.numPorcentajeComision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CalculoAguinaldosDS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CalculoAguinaldosDS2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
	Friend WithEvents grbPatrones As System.Windows.Forms.GroupBox
	Friend WithEvents txtCP As System.Windows.Forms.TextBox
	Friend WithEvents txtColonia As System.Windows.Forms.TextBox
	Friend WithEvents txtCalle As System.Windows.Forms.TextBox
	Friend WithEvents txtRFC As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroDeRegistro As System.Windows.Forms.TextBox
	Friend WithEvents txtNumero As System.Windows.Forms.TextBox
	Friend WithEvents lblCalle As System.Windows.Forms.Label
	Friend WithEvents lblNúmero As System.Windows.Forms.Label
	Friend WithEvents lblColonia As System.Windows.Forms.Label
	Friend WithEvents lblCiudad As System.Windows.Forms.Label
	Friend WithEvents lblCP As System.Windows.Forms.Label
	Friend WithEvents lblActivo As System.Windows.Forms.Label
	Friend WithEvents lblNombreDelPatron As System.Windows.Forms.Label
	Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents cmbCiudad As System.Windows.Forms.ComboBox
	Friend WithEvents lblNumeroDeRegistroPatronal As System.Windows.Forms.Label
    Friend WithEvents txtNombreDelPatron As System.Windows.Forms.TextBox
    Friend WithEvents lblListaPatrones As System.Windows.Forms.Label
    Friend WithEvents CalculoAguinaldosDS1 As Nomina.Vista.CalculoAguinaldosDS
    Friend WithEvents CalculoAguinaldosDS2 As Nomina.Vista.CalculoAguinaldosDS
    Friend WithEvents btnSi As System.Windows.Forms.RadioButton
    Friend WithEvents btnNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoComisionSI As RadioButton
    Friend WithEvents rdoComisionNO As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents numPorcentajeComision As NumericUpDown
    Friend WithEvents lblPorcentaje As Label
    Friend WithEvents pnlPorcentaje As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pcbTitulo As PictureBox
End Class
