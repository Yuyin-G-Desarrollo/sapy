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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarMotivosForm))
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
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnCancelarPais = New System.Windows.Forms.Button()
        Me.btnGuardarPais = New System.Windows.Forms.Button()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlGuardarCancelar = New System.Windows.Forms.Panel()
        Me.pnlBotonera = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdoPagoExtraSi = New System.Windows.Forms.RadioButton()
        Me.rdoPagoExtraNo = New System.Windows.Forms.RadioButton()
        Me.pnlActivo = New System.Windows.Forms.Panel()
        Me.lblPagoDiaExtra = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlGuardarCancelar.SuspendLayout()
        Me.pnlBotonera.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlActivo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rdoActivoNo
        '
        Me.rdoActivoNo.AutoSize = True
        Me.rdoActivoNo.Location = New System.Drawing.Point(43, 9)
        Me.rdoActivoNo.Name = "rdoActivoNo"
        Me.rdoActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoActivoNo.TabIndex = 6
        Me.rdoActivoNo.Text = "No"
        Me.rdoActivoNo.UseVisualStyleBackColor = True
        '
        'rdoActivoSi
        '
        Me.rdoActivoSi.AutoSize = True
        Me.rdoActivoSi.Checked = True
        Me.rdoActivoSi.Location = New System.Drawing.Point(3, 9)
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
        Me.cmbNave.Location = New System.Drawing.Point(95, 25)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(229, 21)
        Me.cmbNave.TabIndex = 1
        '
        'txtMontoMaximo
        '
        Me.txtMontoMaximo.Location = New System.Drawing.Point(95, 164)
        Me.txtMontoMaximo.Name = "txtMontoMaximo"
        Me.txtMontoMaximo.Size = New System.Drawing.Size(89, 20)
        Me.txtMontoMaximo.TabIndex = 4
        '
        'txtDescripcionMotivo
        '
        Me.txtDescripcionMotivo.Location = New System.Drawing.Point(95, 113)
        Me.txtDescripcionMotivo.Multiline = True
        Me.txtDescripcionMotivo.Name = "txtDescripcionMotivo"
        Me.txtDescripcionMotivo.Size = New System.Drawing.Size(229, 35)
        Me.txtDescripcionMotivo.TabIndex = 3
        '
        'txtNombreMotivo
        '
        Me.txtNombreMotivo.Location = New System.Drawing.Point(95, 62)
        Me.txtNombreMotivo.Multiline = True
        Me.txtNombreMotivo.Name = "txtNombreMotivo"
        Me.txtNombreMotivo.Size = New System.Drawing.Size(229, 35)
        Me.txtNombreMotivo.TabIndex = 2
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(10, 116)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(70, 13)
        Me.lblDescripcion.TabIndex = 4
        Me.lblDescripcion.Text = "* Descripción"
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Location = New System.Drawing.Point(10, 167)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(83, 13)
        Me.lblMonto.TabIndex = 3
        Me.lblMonto.Text = "* Monto Máximo"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(10, 28)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(40, 13)
        Me.lblNave.TabIndex = 2
        Me.lblNave.Text = "* Nave"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(10, 202)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 1
        Me.lblActivo.Text = "Activo"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(10, 65)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(54, 13)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = "*  Nombre"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(146, 43)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(35, 13)
        Me.lblLimpiar.TabIndex = 19
        Me.lblLimpiar.Text = "Cerrar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(78, 43)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(45, 13)
        Me.lblBuscar.TabIndex = 18
        Me.lblBuscar.Text = "Guardar"
        '
        'btnCancelarPais
        '
        Me.btnCancelarPais.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCancelarPais.Location = New System.Drawing.Point(146, 9)
        Me.btnCancelarPais.Name = "btnCancelarPais"
        Me.btnCancelarPais.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarPais.TabIndex = 8
        Me.btnCancelarPais.UseVisualStyleBackColor = True
        '
        'btnGuardarPais
        '
        Me.btnGuardarPais.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.guardar2_321
        Me.btnGuardarPais.Location = New System.Drawing.Point(84, 9)
        Me.btnGuardarPais.Name = "btnGuardarPais"
        Me.btnGuardarPais.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarPais.TabIndex = 7
        Me.btnGuardarPais.UseVisualStyleBackColor = True
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.pcbTitulo)
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(394, 59)
        Me.pnlListaPaises.TabIndex = 9
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(59, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(255, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Editar Motivos de Gratificación"
        '
        'pnlGuardarCancelar
        '
        Me.pnlGuardarCancelar.Controls.Add(Me.pnlBotonera)
        Me.pnlGuardarCancelar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlGuardarCancelar.Location = New System.Drawing.Point(0, 366)
        Me.pnlGuardarCancelar.Name = "pnlGuardarCancelar"
        Me.pnlGuardarCancelar.Size = New System.Drawing.Size(394, 62)
        Me.pnlGuardarCancelar.TabIndex = 37
        '
        'pnlBotonera
        '
        Me.pnlBotonera.Controls.Add(Me.btnCancelarPais)
        Me.pnlBotonera.Controls.Add(Me.lblLimpiar)
        Me.pnlBotonera.Controls.Add(Me.lblBuscar)
        Me.pnlBotonera.Controls.Add(Me.btnGuardarPais)
        Me.pnlBotonera.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonera.Location = New System.Drawing.Point(194, 0)
        Me.pnlBotonera.Name = "pnlBotonera"
        Me.pnlBotonera.Size = New System.Drawing.Size(200, 62)
        Me.pnlBotonera.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.pnlActivo)
        Me.GroupBox1.Controls.Add(Me.lblPagoDiaExtra)
        Me.GroupBox1.Controls.Add(Me.cmbNave)
        Me.GroupBox1.Controls.Add(Me.txtMontoMaximo)
        Me.GroupBox1.Controls.Add(Me.lblActivo)
        Me.GroupBox1.Controls.Add(Me.lblNave)
        Me.GroupBox1.Controls.Add(Me.txtDescripcionMotivo)
        Me.GroupBox1.Controls.Add(Me.txtNombreMotivo)
        Me.GroupBox1.Controls.Add(Me.lblNombre)
        Me.GroupBox1.Controls.Add(Me.lblMonto)
        Me.GroupBox1.Controls.Add(Me.lblDescripcion)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 266)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdoPagoExtraSi)
        Me.Panel1.Controls.Add(Me.rdoPagoExtraNo)
        Me.Panel1.Location = New System.Drawing.Point(95, 233)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(89, 33)
        Me.Panel1.TabIndex = 10
        '
        'rdoPagoExtraSi
        '
        Me.rdoPagoExtraSi.AutoSize = True
        Me.rdoPagoExtraSi.Location = New System.Drawing.Point(3, 10)
        Me.rdoPagoExtraSi.Name = "rdoPagoExtraSi"
        Me.rdoPagoExtraSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoPagoExtraSi.TabIndex = 7
        Me.rdoPagoExtraSi.Text = "Si"
        Me.rdoPagoExtraSi.UseVisualStyleBackColor = True
        '
        'rdoPagoExtraNo
        '
        Me.rdoPagoExtraNo.AutoSize = True
        Me.rdoPagoExtraNo.Checked = True
        Me.rdoPagoExtraNo.Location = New System.Drawing.Point(43, 10)
        Me.rdoPagoExtraNo.Name = "rdoPagoExtraNo"
        Me.rdoPagoExtraNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoPagoExtraNo.TabIndex = 8
        Me.rdoPagoExtraNo.TabStop = True
        Me.rdoPagoExtraNo.Text = "No"
        Me.rdoPagoExtraNo.UseVisualStyleBackColor = True
        '
        'pnlActivo
        '
        Me.pnlActivo.Controls.Add(Me.rdoActivoSi)
        Me.pnlActivo.Controls.Add(Me.rdoActivoNo)
        Me.pnlActivo.Location = New System.Drawing.Point(95, 190)
        Me.pnlActivo.Name = "pnlActivo"
        Me.pnlActivo.Size = New System.Drawing.Size(88, 37)
        Me.pnlActivo.TabIndex = 9
        '
        'lblPagoDiaExtra
        '
        Me.lblPagoDiaExtra.AutoSize = True
        Me.lblPagoDiaExtra.Location = New System.Drawing.Point(9, 243)
        Me.lblPagoDiaExtra.Name = "lblPagoDiaExtra"
        Me.lblPagoDiaExtra.Size = New System.Drawing.Size(80, 13)
        Me.lblPagoDiaExtra.TabIndex = 7
        Me.lblPagoDiaExtra.Text = "Pago Día Extra"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(326, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 46
        Me.pcbTitulo.TabStop = False
        '
        'EditarMotivosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(394, 428)
        Me.Controls.Add(Me.pnlGuardarCancelar)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(400, 450)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(400, 450)
        Me.Name = "EditarMotivosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Motivos de Gratificación"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.pnlGuardarCancelar.ResumeLayout(False)
        Me.pnlBotonera.ResumeLayout(False)
        Me.pnlBotonera.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlActivo.ResumeLayout(False)
        Me.pnlActivo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnCancelarPais As System.Windows.Forms.Button
    Friend WithEvents btnGuardarPais As System.Windows.Forms.Button
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
    Friend WithEvents pnlGuardarCancelar As System.Windows.Forms.Panel
    Friend WithEvents pnlBotonera As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoPagoExtraNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPagoExtraSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblPagoDiaExtra As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlActivo As System.Windows.Forms.Panel
    Friend WithEvents pcbTitulo As PictureBox
End Class
