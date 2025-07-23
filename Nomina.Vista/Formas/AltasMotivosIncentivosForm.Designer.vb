<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasMotivosIncentivosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltasMotivosIncentivosForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlPagoExtra = New System.Windows.Forms.Panel()
        Me.rdoPagoExtraNo = New System.Windows.Forms.RadioButton()
        Me.rdoPagoExtraSi = New System.Windows.Forms.RadioButton()
        Me.lblPagoDiaExtra = New System.Windows.Forms.Label()
        Me.pnlActivo = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.txtMontoMaximo = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtNombreMotivo = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnCancelarMotivo = New System.Windows.Forms.Button()
        Me.btnGuardarMotivo = New System.Windows.Forms.Button()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.pnlPagoExtra.SuspendLayout()
        Me.pnlActivo.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlPagoExtra)
        Me.Panel1.Controls.Add(Me.lblPagoDiaExtra)
        Me.Panel1.Controls.Add(Me.pnlActivo)
        Me.Panel1.Controls.Add(Me.cmbNaves)
        Me.Panel1.Controls.Add(Me.txtMontoMaximo)
        Me.Panel1.Controls.Add(Me.txtDescripcion)
        Me.Panel1.Controls.Add(Me.txtNombreMotivo)
        Me.Panel1.Controls.Add(Me.lblDescripcion)
        Me.Panel1.Controls.Add(Me.lblMonto)
        Me.Panel1.Controls.Add(Me.lblNave)
        Me.Panel1.Controls.Add(Me.lblActivo)
        Me.Panel1.Controls.Add(Me.lblNombre)
        Me.Panel1.Location = New System.Drawing.Point(15, 78)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(415, 236)
        Me.Panel1.TabIndex = 10
        '
        'pnlPagoExtra
        '
        Me.pnlPagoExtra.Controls.Add(Me.rdoPagoExtraNo)
        Me.pnlPagoExtra.Controls.Add(Me.rdoPagoExtraSi)
        Me.pnlPagoExtra.Location = New System.Drawing.Point(107, 199)
        Me.pnlPagoExtra.Name = "pnlPagoExtra"
        Me.pnlPagoExtra.Size = New System.Drawing.Size(94, 30)
        Me.pnlPagoExtra.TabIndex = 17
        '
        'rdoPagoExtraNo
        '
        Me.rdoPagoExtraNo.AutoSize = True
        Me.rdoPagoExtraNo.Checked = True
        Me.rdoPagoExtraNo.Location = New System.Drawing.Point(52, 6)
        Me.rdoPagoExtraNo.Name = "rdoPagoExtraNo"
        Me.rdoPagoExtraNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoPagoExtraNo.TabIndex = 8
        Me.rdoPagoExtraNo.TabStop = True
        Me.rdoPagoExtraNo.Text = "No"
        Me.rdoPagoExtraNo.UseVisualStyleBackColor = True
        '
        'rdoPagoExtraSi
        '
        Me.rdoPagoExtraSi.AutoSize = True
        Me.rdoPagoExtraSi.Location = New System.Drawing.Point(3, 6)
        Me.rdoPagoExtraSi.Name = "rdoPagoExtraSi"
        Me.rdoPagoExtraSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoPagoExtraSi.TabIndex = 7
        Me.rdoPagoExtraSi.Text = "Si"
        Me.rdoPagoExtraSi.UseVisualStyleBackColor = True
        '
        'lblPagoDiaExtra
        '
        Me.lblPagoDiaExtra.AutoSize = True
        Me.lblPagoDiaExtra.Location = New System.Drawing.Point(7, 199)
        Me.lblPagoDiaExtra.Name = "lblPagoDiaExtra"
        Me.lblPagoDiaExtra.Size = New System.Drawing.Size(80, 13)
        Me.lblPagoDiaExtra.TabIndex = 16
        Me.lblPagoDiaExtra.Text = "Pago Día Extra"
        '
        'pnlActivo
        '
        Me.pnlActivo.Controls.Add(Me.rdoActivoNo)
        Me.pnlActivo.Controls.Add(Me.rdoActivoSi)
        Me.pnlActivo.Location = New System.Drawing.Point(107, 157)
        Me.pnlActivo.Name = "pnlActivo"
        Me.pnlActivo.Size = New System.Drawing.Size(94, 30)
        Me.pnlActivo.TabIndex = 15
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
        'cmbNaves
        '
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.Location = New System.Drawing.Point(107, 115)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(121, 21)
        Me.cmbNaves.TabIndex = 8
        '
        'txtMontoMaximo
        '
        Me.txtMontoMaximo.Location = New System.Drawing.Point(107, 78)
        Me.txtMontoMaximo.Name = "txtMontoMaximo"
        Me.txtMontoMaximo.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoMaximo.TabIndex = 7
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(107, 45)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(100, 20)
        Me.txtDescripcion.TabIndex = 6
        '
        'txtNombreMotivo
        '
        Me.txtNombreMotivo.Location = New System.Drawing.Point(107, 14)
        Me.txtNombreMotivo.Name = "txtNombreMotivo"
        Me.txtNombreMotivo.Size = New System.Drawing.Size(100, 20)
        Me.txtNombreMotivo.TabIndex = 5
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(24, 52)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 4
        Me.lblDescripcion.Text = "Descripcion"
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Location = New System.Drawing.Point(11, 85)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(76, 13)
        Me.lblMonto.TabIndex = 3
        Me.lblMonto.Text = "Monto Maximo"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(51, 123)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 2
        Me.lblNave.Text = "Nave"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(47, 157)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 1
        Me.lblActivo.Text = "Activo"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(41, 21)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = "Nombre"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(382, 43)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(49, 13)
        Me.lblLimpiar.TabIndex = 19
        Me.lblLimpiar.Text = "Cancelar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(319, 43)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(45, 13)
        Me.lblBuscar.TabIndex = 18
        Me.lblBuscar.Text = "Guardar"
        '
        'btnCancelarMotivo
        '
        Me.btnCancelarMotivo.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.cancelar_32
        Me.btnCancelarMotivo.Location = New System.Drawing.Point(385, 7)
        Me.btnCancelarMotivo.Name = "btnCancelarMotivo"
        Me.btnCancelarMotivo.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarMotivo.TabIndex = 17
        Me.btnCancelarMotivo.UseVisualStyleBackColor = True
        '
        'btnGuardarMotivo
        '
        Me.btnGuardarMotivo.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.guardar_32
        Me.btnGuardarMotivo.Location = New System.Drawing.Point(323, 7)
        Me.btnGuardarMotivo.Name = "btnGuardarMotivo"
        Me.btnGuardarMotivo.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarMotivo.TabIndex = 16
        Me.btnGuardarMotivo.UseVisualStyleBackColor = True
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.pcbTitulo)
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(439, 59)
        Me.pnlListaPaises.TabIndex = 9
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(105, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(264, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Alta de Motivos de Gratificación"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.btnGuardarMotivo)
        Me.Panel2.Controls.Add(Me.lblLimpiar)
        Me.Panel2.Controls.Add(Me.btnCancelarMotivo)
        Me.Panel2.Controls.Add(Me.lblBuscar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 332)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(439, 64)
        Me.Panel2.TabIndex = 20
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(371, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 45
        Me.pcbTitulo.TabStop = False
        '
        'AltasMotivosIncentivosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(439, 396)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AltasMotivosIncentivosForm"
        Me.Text = "Altas de Motivos de Incentivos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlPagoExtra.ResumeLayout(False)
        Me.pnlPagoExtra.PerformLayout()
        Me.pnlActivo.ResumeLayout(False)
        Me.pnlActivo.PerformLayout()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnCancelarMotivo As System.Windows.Forms.Button
    Friend WithEvents btnGuardarMotivo As System.Windows.Forms.Button
    Friend WithEvents pnlActivo As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
    Friend WithEvents txtMontoMaximo As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreMotivo As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlPagoExtra As System.Windows.Forms.Panel
    Friend WithEvents rdoPagoExtraNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPagoExtraSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblPagoDiaExtra As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As PictureBox
End Class
