<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarEditarEventosForm
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
        Me.gpbRegistroDias = New System.Windows.Forms.GroupBox()
        Me.txtAbreviatura = New System.Windows.Forms.TextBox()
        Me.lblAbreviaturaEvento = New System.Windows.Forms.Label()
        Me.txtNumeroSemanaVigente = New System.Windows.Forms.TextBox()
        Me.lblFechaEntregaColVigente = New System.Windows.Forms.Label()
        Me.txtNumeroSemanaNueva = New System.Windows.Forms.TextBox()
        Me.dtpFechaColNueva = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaEntregaColNuevas = New System.Windows.Forms.Label()
        Me.dtpFechaVigencia = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicioEvento = New System.Windows.Forms.DateTimePicker()
        Me.lblInicioEvento = New System.Windows.Forms.Label()
        Me.dtpFechaFinEvento = New System.Windows.Forms.DateTimePicker()
        Me.lblFinEvento = New System.Windows.Forms.Label()
        Me.txtEventoNombre = New System.Windows.Forms.TextBox()
        Me.lblNombreEvento = New System.Windows.Forms.Label()
        Me.pnlrdoActivo = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.txtLugarEvento = New System.Windows.Forms.TextBox()
        Me.lblLugarEvento = New System.Windows.Forms.Label()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.pnlAgregarEditarMateriales = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.btnCerrarEvento = New System.Windows.Forms.Button()
        Me.btnGuardarEvento = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.gpbRegistroDias.SuspendLayout()
        Me.pnlrdoActivo.SuspendLayout()
        Me.pnlAgregarEditarMateriales.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpbRegistroDias
        '
        Me.gpbRegistroDias.Controls.Add(Me.txtAbreviatura)
        Me.gpbRegistroDias.Controls.Add(Me.lblAbreviaturaEvento)
        Me.gpbRegistroDias.Controls.Add(Me.txtNumeroSemanaVigente)
        Me.gpbRegistroDias.Controls.Add(Me.lblFechaEntregaColVigente)
        Me.gpbRegistroDias.Controls.Add(Me.txtNumeroSemanaNueva)
        Me.gpbRegistroDias.Controls.Add(Me.dtpFechaColNueva)
        Me.gpbRegistroDias.Controls.Add(Me.lblFechaEntregaColNuevas)
        Me.gpbRegistroDias.Controls.Add(Me.dtpFechaVigencia)
        Me.gpbRegistroDias.Controls.Add(Me.dtpFechaInicioEvento)
        Me.gpbRegistroDias.Controls.Add(Me.lblInicioEvento)
        Me.gpbRegistroDias.Controls.Add(Me.dtpFechaFinEvento)
        Me.gpbRegistroDias.Controls.Add(Me.lblFinEvento)
        Me.gpbRegistroDias.Controls.Add(Me.txtEventoNombre)
        Me.gpbRegistroDias.Controls.Add(Me.lblNombreEvento)
        Me.gpbRegistroDias.Controls.Add(Me.pnlrdoActivo)
        Me.gpbRegistroDias.Controls.Add(Me.lblActivo)
        Me.gpbRegistroDias.Controls.Add(Me.txtLugarEvento)
        Me.gpbRegistroDias.Controls.Add(Me.lblLugarEvento)
        Me.gpbRegistroDias.Location = New System.Drawing.Point(12, 83)
        Me.gpbRegistroDias.Name = "gpbRegistroDias"
        Me.gpbRegistroDias.Size = New System.Drawing.Size(542, 249)
        Me.gpbRegistroDias.TabIndex = 29
        Me.gpbRegistroDias.TabStop = False
        '
        'txtAbreviatura
        '
        Me.txtAbreviatura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAbreviatura.Location = New System.Drawing.Point(85, 47)
        Me.txtAbreviatura.MaxLength = 30
        Me.txtAbreviatura.Name = "txtAbreviatura"
        Me.txtAbreviatura.Size = New System.Drawing.Size(443, 20)
        Me.txtAbreviatura.TabIndex = 1
        Me.txtAbreviatura.Text = "ABREVIATURA"
        '
        'lblAbreviaturaEvento
        '
        Me.lblAbreviaturaEvento.AutoSize = True
        Me.lblAbreviaturaEvento.Location = New System.Drawing.Point(18, 50)
        Me.lblAbreviaturaEvento.Name = "lblAbreviaturaEvento"
        Me.lblAbreviaturaEvento.Size = New System.Drawing.Size(65, 13)
        Me.lblAbreviaturaEvento.TabIndex = 88
        Me.lblAbreviaturaEvento.Text = "*Abreviatura"
        '
        'txtNumeroSemanaVigente
        '
        Me.txtNumeroSemanaVigente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroSemanaVigente.Enabled = False
        Me.txtNumeroSemanaVigente.Location = New System.Drawing.Point(371, 138)
        Me.txtNumeroSemanaVigente.Name = "txtNumeroSemanaVigente"
        Me.txtNumeroSemanaVigente.Size = New System.Drawing.Size(106, 20)
        Me.txtNumeroSemanaVigente.TabIndex = 86
        Me.txtNumeroSemanaVigente.Text = "SEMANA 42-2016"
        '
        'lblFechaEntregaColVigente
        '
        Me.lblFechaEntregaColVigente.AutoSize = True
        Me.lblFechaEntregaColVigente.ForeColor = System.Drawing.Color.Black
        Me.lblFechaEntregaColVigente.Location = New System.Drawing.Point(18, 141)
        Me.lblFechaEntregaColVigente.Name = "lblFechaEntregaColVigente"
        Me.lblFechaEntregaColVigente.Size = New System.Drawing.Size(232, 13)
        Me.lblFechaEntregaColVigente.TabIndex = 85
        Me.lblFechaEntregaColVigente.Text = "* Fecha de Entrega de Colecciones VIGENTES"
        '
        'txtNumeroSemanaNueva
        '
        Me.txtNumeroSemanaNueva.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroSemanaNueva.Enabled = False
        Me.txtNumeroSemanaNueva.Location = New System.Drawing.Point(371, 167)
        Me.txtNumeroSemanaNueva.Name = "txtNumeroSemanaNueva"
        Me.txtNumeroSemanaNueva.Size = New System.Drawing.Size(106, 20)
        Me.txtNumeroSemanaNueva.TabIndex = 84
        Me.txtNumeroSemanaNueva.Text = "SEMANA 9-2017"
        '
        'dtpFechaColNueva
        '
        Me.dtpFechaColNueva.CustomFormat = ""
        Me.dtpFechaColNueva.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaColNueva.Location = New System.Drawing.Point(259, 167)
        Me.dtpFechaColNueva.Name = "dtpFechaColNueva"
        Me.dtpFechaColNueva.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaColNueva.TabIndex = 6
        Me.dtpFechaColNueva.Value = New Date(2017, 3, 1, 0, 0, 0, 0)
        '
        'lblFechaEntregaColNuevas
        '
        Me.lblFechaEntregaColNuevas.AutoSize = True
        Me.lblFechaEntregaColNuevas.ForeColor = System.Drawing.Color.Black
        Me.lblFechaEntregaColNuevas.Location = New System.Drawing.Point(18, 173)
        Me.lblFechaEntregaColNuevas.Name = "lblFechaEntregaColNuevas"
        Me.lblFechaEntregaColNuevas.Size = New System.Drawing.Size(222, 13)
        Me.lblFechaEntregaColNuevas.TabIndex = 76
        Me.lblFechaEntregaColNuevas.Text = "* Fecha de Entrega de Colecciones NUEVAS"
        '
        'dtpFechaVigencia
        '
        Me.dtpFechaVigencia.CustomFormat = ""
        Me.dtpFechaVigencia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaVigencia.Location = New System.Drawing.Point(259, 138)
        Me.dtpFechaVigencia.Name = "dtpFechaVigencia"
        Me.dtpFechaVigencia.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaVigencia.TabIndex = 5
        Me.dtpFechaVigencia.Value = New Date(2016, 10, 15, 0, 0, 0, 0)
        '
        'dtpFechaInicioEvento
        '
        Me.dtpFechaInicioEvento.CustomFormat = ""
        Me.dtpFechaInicioEvento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicioEvento.Location = New System.Drawing.Point(85, 107)
        Me.dtpFechaInicioEvento.Name = "dtpFechaInicioEvento"
        Me.dtpFechaInicioEvento.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaInicioEvento.TabIndex = 3
        Me.dtpFechaInicioEvento.Value = New Date(2016, 8, 16, 0, 0, 0, 0)
        '
        'lblInicioEvento
        '
        Me.lblInicioEvento.AutoSize = True
        Me.lblInicioEvento.ForeColor = System.Drawing.Color.Black
        Me.lblInicioEvento.Location = New System.Drawing.Point(18, 107)
        Me.lblInicioEvento.Name = "lblInicioEvento"
        Me.lblInicioEvento.Size = New System.Drawing.Size(39, 13)
        Me.lblInicioEvento.TabIndex = 72
        Me.lblInicioEvento.Text = "* Inicio"
        '
        'dtpFechaFinEvento
        '
        Me.dtpFechaFinEvento.CustomFormat = ""
        Me.dtpFechaFinEvento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinEvento.Location = New System.Drawing.Point(249, 107)
        Me.dtpFechaFinEvento.Name = "dtpFechaFinEvento"
        Me.dtpFechaFinEvento.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaFinEvento.TabIndex = 4
        Me.dtpFechaFinEvento.Value = New Date(2016, 8, 19, 0, 0, 0, 0)
        '
        'lblFinEvento
        '
        Me.lblFinEvento.AutoSize = True
        Me.lblFinEvento.ForeColor = System.Drawing.Color.Black
        Me.lblFinEvento.Location = New System.Drawing.Point(200, 107)
        Me.lblFinEvento.Name = "lblFinEvento"
        Me.lblFinEvento.Size = New System.Drawing.Size(25, 13)
        Me.lblFinEvento.TabIndex = 74
        Me.lblFinEvento.Text = "*Fin"
        '
        'txtEventoNombre
        '
        Me.txtEventoNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEventoNombre.Location = New System.Drawing.Point(85, 19)
        Me.txtEventoNombre.MaxLength = 150
        Me.txtEventoNombre.Name = "txtEventoNombre"
        Me.txtEventoNombre.Size = New System.Drawing.Size(443, 20)
        Me.txtEventoNombre.TabIndex = 0
        Me.txtEventoNombre.Text = "SAPICA PRIMAVERA-VERANO 2017"
        '
        'lblNombreEvento
        '
        Me.lblNombreEvento.AutoSize = True
        Me.lblNombreEvento.Location = New System.Drawing.Point(18, 22)
        Me.lblNombreEvento.Name = "lblNombreEvento"
        Me.lblNombreEvento.Size = New System.Drawing.Size(45, 13)
        Me.lblNombreEvento.TabIndex = 10
        Me.lblNombreEvento.Text = "*Evento"
        '
        'pnlrdoActivo
        '
        Me.pnlrdoActivo.Controls.Add(Me.rdoActivoNo)
        Me.pnlrdoActivo.Controls.Add(Me.rdoActivoSi)
        Me.pnlrdoActivo.Location = New System.Drawing.Point(95, 199)
        Me.pnlrdoActivo.Name = "pnlrdoActivo"
        Me.pnlrdoActivo.Size = New System.Drawing.Size(84, 30)
        Me.pnlrdoActivo.TabIndex = 9
        '
        'rdoActivoNo
        '
        Me.rdoActivoNo.AutoSize = True
        Me.rdoActivoNo.Location = New System.Drawing.Point(42, 7)
        Me.rdoActivoNo.Name = "rdoActivoNo"
        Me.rdoActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoActivoNo.TabIndex = 8
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
        Me.rdoActivoSi.TabIndex = 7
        Me.rdoActivoSi.TabStop = True
        Me.rdoActivoSi.Text = "Si"
        Me.rdoActivoSi.UseVisualStyleBackColor = True
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(18, 208)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(41, 13)
        Me.lblActivo.TabIndex = 2
        Me.lblActivo.Text = "*Activo"
        '
        'txtLugarEvento
        '
        Me.txtLugarEvento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLugarEvento.Location = New System.Drawing.Point(85, 75)
        Me.txtLugarEvento.Name = "txtLugarEvento"
        Me.txtLugarEvento.Size = New System.Drawing.Size(443, 20)
        Me.txtLugarEvento.TabIndex = 2
        Me.txtLugarEvento.Text = "POLIFORUM LEÓN"
        '
        'lblLugarEvento
        '
        Me.lblLugarEvento.AutoSize = True
        Me.lblLugarEvento.Location = New System.Drawing.Point(18, 78)
        Me.lblLugarEvento.Name = "lblLugarEvento"
        Me.lblLugarEvento.Size = New System.Drawing.Size(38, 13)
        Me.lblLugarEvento.TabIndex = 0
        Me.lblLugarEvento.Text = "*Lugar"
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(516, 381)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 31
        Me.lblCerrar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(456, 381)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 30
        Me.lblGuardar.Text = "Guardar"
        '
        'pnlAgregarEditarMateriales
        '
        Me.pnlAgregarEditarMateriales.BackColor = System.Drawing.Color.White
        Me.pnlAgregarEditarMateriales.Controls.Add(Me.imgLogo)
        Me.pnlAgregarEditarMateriales.Controls.Add(Me.lblEncabezado)
        Me.pnlAgregarEditarMateriales.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAgregarEditarMateriales.Location = New System.Drawing.Point(0, 0)
        Me.pnlAgregarEditarMateriales.Name = "pnlAgregarEditarMateriales"
        Me.pnlAgregarEditarMateriales.Size = New System.Drawing.Size(574, 60)
        Me.pnlAgregarEditarMateriales.TabIndex = 28
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(423, 21)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(74, 20)
        Me.lblEncabezado.TabIndex = 6
        Me.lblEncabezado.Text = "Eventos"
        '
        'btnCerrarEvento
        '
        Me.btnCerrarEvento.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrarEvento.Location = New System.Drawing.Point(516, 346)
        Me.btnCerrarEvento.Name = "btnCerrarEvento"
        Me.btnCerrarEvento.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrarEvento.TabIndex = 10
        Me.btnCerrarEvento.UseVisualStyleBackColor = True
        '
        'btnGuardarEvento
        '
        Me.btnGuardarEvento.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_3211
        Me.btnGuardarEvento.Location = New System.Drawing.Point(459, 346)
        Me.btnGuardarEvento.Name = "btnGuardarEvento"
        Me.btnGuardarEvento.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarEvento.TabIndex = 9
        Me.btnGuardarEvento.UseVisualStyleBackColor = True
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(504, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 47
        Me.imgLogo.TabStop = False
        '
        'AgregarEditarEventosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(574, 433)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnGuardarEvento)
        Me.Controls.Add(Me.gpbRegistroDias)
        Me.Controls.Add(Me.lblCerrar)
        Me.Controls.Add(Me.lblGuardar)
        Me.Controls.Add(Me.btnCerrarEvento)
        Me.Controls.Add(Me.pnlAgregarEditarMateriales)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(582, 460)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(582, 460)
        Me.Name = "AgregarEditarEventosForm"
        Me.Text = "Eventos"
        Me.gpbRegistroDias.ResumeLayout(False)
        Me.gpbRegistroDias.PerformLayout()
        Me.pnlrdoActivo.ResumeLayout(False)
        Me.pnlrdoActivo.PerformLayout()
        Me.pnlAgregarEditarMateriales.ResumeLayout(False)
        Me.pnlAgregarEditarMateriales.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpbRegistroDias As System.Windows.Forms.GroupBox
    Friend WithEvents txtEventoNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreEvento As System.Windows.Forms.Label
    Friend WithEvents pnlrdoActivo As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents txtLugarEvento As System.Windows.Forms.TextBox
    Friend WithEvents lblLugarEvento As System.Windows.Forms.Label
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnCerrarEvento As System.Windows.Forms.Button
    Friend WithEvents btnGuardarEvento As System.Windows.Forms.Button
    Friend WithEvents pnlAgregarEditarMateriales As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents dtpFechaColNueva As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaEntregaColNuevas As System.Windows.Forms.Label
    Friend WithEvents dtpFechaVigencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicioEvento As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblInicioEvento As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFinEvento As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFinEvento As System.Windows.Forms.Label
    Friend WithEvents txtNumeroSemanaVigente As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaEntregaColVigente As System.Windows.Forms.Label
    Friend WithEvents txtNumeroSemanaNueva As System.Windows.Forms.TextBox
    Friend WithEvents txtAbreviatura As System.Windows.Forms.TextBox
    Friend WithEvents lblAbreviaturaEvento As System.Windows.Forms.Label
    Friend WithEvents imgLogo As PictureBox
End Class
