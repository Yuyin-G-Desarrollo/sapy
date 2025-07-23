<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarEditarRamosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgregarEditarRamosForm))
        Me.gpbRegistroDias = New System.Windows.Forms.GroupBox()
        Me.cboxEditarAgregarRamoIDSICY = New System.Windows.Forms.ComboBox()
        Me.lblAgregarEditarRamoIDSICY = New System.Windows.Forms.Label()
        Me.txtAgregarEditarRamoNombre = New System.Windows.Forms.TextBox()
        Me.lblAgregarEditarRamosNombre = New System.Windows.Forms.Label()
        Me.pnlrdoActivo = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.lblActivoAgregarEditarRamo = New System.Windows.Forms.Label()
        Me.txtAgregarEditarRamosNombreCorto = New System.Windows.Forms.TextBox()
        Me.lblAgregarEditarRamoNombreCorto = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.pnlAgregarEditarMateriales = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.btnCancelarRamo = New System.Windows.Forms.Button()
        Me.btnGuardarRamo = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.gpbRegistroDias.SuspendLayout()
        Me.pnlrdoActivo.SuspendLayout()
        Me.pnlAgregarEditarMateriales.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpbRegistroDias
        '
        Me.gpbRegistroDias.Controls.Add(Me.cboxEditarAgregarRamoIDSICY)
        Me.gpbRegistroDias.Controls.Add(Me.lblAgregarEditarRamoIDSICY)
        Me.gpbRegistroDias.Controls.Add(Me.txtAgregarEditarRamoNombre)
        Me.gpbRegistroDias.Controls.Add(Me.lblAgregarEditarRamosNombre)
        Me.gpbRegistroDias.Controls.Add(Me.pnlrdoActivo)
        Me.gpbRegistroDias.Controls.Add(Me.lblActivoAgregarEditarRamo)
        Me.gpbRegistroDias.Controls.Add(Me.txtAgregarEditarRamosNombreCorto)
        Me.gpbRegistroDias.Controls.Add(Me.lblAgregarEditarRamoNombreCorto)
        Me.gpbRegistroDias.Location = New System.Drawing.Point(12, 82)
        Me.gpbRegistroDias.Name = "gpbRegistroDias"
        Me.gpbRegistroDias.Size = New System.Drawing.Size(424, 161)
        Me.gpbRegistroDias.TabIndex = 21
        Me.gpbRegistroDias.TabStop = False
        '
        'cboxEditarAgregarRamoIDSICY
        '
        Me.cboxEditarAgregarRamoIDSICY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxEditarAgregarRamoIDSICY.FormattingEnabled = True
        Me.cboxEditarAgregarRamoIDSICY.Location = New System.Drawing.Point(95, 75)
        Me.cboxEditarAgregarRamoIDSICY.Name = "cboxEditarAgregarRamoIDSICY"
        Me.cboxEditarAgregarRamoIDSICY.Size = New System.Drawing.Size(303, 21)
        Me.cboxEditarAgregarRamoIDSICY.TabIndex = 12
        '
        'lblAgregarEditarRamoIDSICY
        '
        Me.lblAgregarEditarRamoIDSICY.AutoSize = True
        Me.lblAgregarEditarRamoIDSICY.Location = New System.Drawing.Point(18, 80)
        Me.lblAgregarEditarRamoIDSICY.Name = "lblAgregarEditarRamoIDSICY"
        Me.lblAgregarEditarRamoIDSICY.Size = New System.Drawing.Size(49, 13)
        Me.lblAgregarEditarRamoIDSICY.TabIndex = 11
        Me.lblAgregarEditarRamoIDSICY.Text = "*ID SICY"
        '
        'txtAgregarEditarRamoNombre
        '
        Me.txtAgregarEditarRamoNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAgregarEditarRamoNombre.Location = New System.Drawing.Point(95, 19)
        Me.txtAgregarEditarRamoNombre.Name = "txtAgregarEditarRamoNombre"
        Me.txtAgregarEditarRamoNombre.Size = New System.Drawing.Size(303, 20)
        Me.txtAgregarEditarRamoNombre.TabIndex = 1
        '
        'lblAgregarEditarRamosNombre
        '
        Me.lblAgregarEditarRamosNombre.AutoSize = True
        Me.lblAgregarEditarRamosNombre.Location = New System.Drawing.Point(18, 22)
        Me.lblAgregarEditarRamosNombre.Name = "lblAgregarEditarRamosNombre"
        Me.lblAgregarEditarRamosNombre.Size = New System.Drawing.Size(48, 13)
        Me.lblAgregarEditarRamosNombre.TabIndex = 10
        Me.lblAgregarEditarRamosNombre.Text = "*Nombre"
        '
        'pnlrdoActivo
        '
        Me.pnlrdoActivo.Controls.Add(Me.rdoActivoNo)
        Me.pnlrdoActivo.Controls.Add(Me.rdoActivoSi)
        Me.pnlrdoActivo.Location = New System.Drawing.Point(95, 110)
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
        Me.rdoActivoNo.TabIndex = 4
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
        Me.rdoActivoSi.TabIndex = 3
        Me.rdoActivoSi.TabStop = True
        Me.rdoActivoSi.Text = "Si"
        Me.rdoActivoSi.UseVisualStyleBackColor = True
        '
        'lblActivoAgregarEditarRamo
        '
        Me.lblActivoAgregarEditarRamo.AutoSize = True
        Me.lblActivoAgregarEditarRamo.Location = New System.Drawing.Point(18, 119)
        Me.lblActivoAgregarEditarRamo.Name = "lblActivoAgregarEditarRamo"
        Me.lblActivoAgregarEditarRamo.Size = New System.Drawing.Size(41, 13)
        Me.lblActivoAgregarEditarRamo.TabIndex = 2
        Me.lblActivoAgregarEditarRamo.Text = "*Activo"
        '
        'txtAgregarEditarRamosNombreCorto
        '
        Me.txtAgregarEditarRamosNombreCorto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAgregarEditarRamosNombreCorto.Location = New System.Drawing.Point(95, 48)
        Me.txtAgregarEditarRamosNombreCorto.Name = "txtAgregarEditarRamosNombreCorto"
        Me.txtAgregarEditarRamosNombreCorto.Size = New System.Drawing.Size(303, 20)
        Me.txtAgregarEditarRamosNombreCorto.TabIndex = 2
        '
        'lblAgregarEditarRamoNombreCorto
        '
        Me.lblAgregarEditarRamoNombreCorto.AutoSize = True
        Me.lblAgregarEditarRamoNombreCorto.Location = New System.Drawing.Point(18, 51)
        Me.lblAgregarEditarRamoNombreCorto.Name = "lblAgregarEditarRamoNombreCorto"
        Me.lblAgregarEditarRamoNombreCorto.Size = New System.Drawing.Size(75, 13)
        Me.lblAgregarEditarRamoNombreCorto.TabIndex = 0
        Me.lblAgregarEditarRamoNombreCorto.Text = "*Nombre corto"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(395, 284)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(35, 13)
        Me.lblLimpiar.TabIndex = 25
        Me.lblLimpiar.Text = "Cerrar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(335, 284)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(45, 13)
        Me.lblBuscar.TabIndex = 24
        Me.lblBuscar.Text = "Guardar"
        '
        'pnlAgregarEditarMateriales
        '
        Me.pnlAgregarEditarMateriales.BackColor = System.Drawing.Color.White
        Me.pnlAgregarEditarMateriales.Controls.Add(Me.PictureBox1)
        Me.pnlAgregarEditarMateriales.Controls.Add(Me.lblEncabezado)
        Me.pnlAgregarEditarMateriales.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAgregarEditarMateriales.Location = New System.Drawing.Point(0, 0)
        Me.pnlAgregarEditarMateriales.Name = "pnlAgregarEditarMateriales"
        Me.pnlAgregarEditarMateriales.Size = New System.Drawing.Size(452, 60)
        Me.pnlAgregarEditarMateriales.TabIndex = 20
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(313, 21)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(65, 20)
        Me.lblEncabezado.TabIndex = 6
        Me.lblEncabezado.Text = "Ramos"
        '
        'btnCancelarRamo
        '
        Me.btnCancelarRamo.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelarRamo.Location = New System.Drawing.Point(395, 249)
        Me.btnCancelarRamo.Name = "btnCancelarRamo"
        Me.btnCancelarRamo.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarRamo.TabIndex = 6
        Me.btnCancelarRamo.UseVisualStyleBackColor = True
        '
        'btnGuardarRamo
        '
        Me.btnGuardarRamo.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_3211
        Me.btnGuardarRamo.Location = New System.Drawing.Point(338, 249)
        Me.btnGuardarRamo.Name = "btnGuardarRamo"
        Me.btnGuardarRamo.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarRamo.TabIndex = 5
        Me.btnGuardarRamo.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(384, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AgregarEditarRamosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(452, 310)
        Me.Controls.Add(Me.gpbRegistroDias)
        Me.Controls.Add(Me.lblLimpiar)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.btnCancelarRamo)
        Me.Controls.Add(Me.btnGuardarRamo)
        Me.Controls.Add(Me.pnlAgregarEditarMateriales)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "AgregarEditarRamosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ramos"
        Me.gpbRegistroDias.ResumeLayout(False)
        Me.gpbRegistroDias.PerformLayout()
        Me.pnlrdoActivo.ResumeLayout(False)
        Me.pnlrdoActivo.PerformLayout()
        Me.pnlAgregarEditarMateriales.ResumeLayout(False)
        Me.pnlAgregarEditarMateriales.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpbRegistroDias As System.Windows.Forms.GroupBox
    Friend WithEvents lblAgregarEditarRamosNombre As System.Windows.Forms.Label
    Friend WithEvents pnlrdoActivo As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblActivoAgregarEditarRamo As System.Windows.Forms.Label
    Friend WithEvents txtAgregarEditarRamosNombreCorto As System.Windows.Forms.TextBox
    Friend WithEvents lblAgregarEditarRamoNombreCorto As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnCancelarRamo As System.Windows.Forms.Button
    Friend WithEvents btnGuardarRamo As System.Windows.Forms.Button
    Friend WithEvents pnlAgregarEditarMateriales As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents txtAgregarEditarRamoNombre As System.Windows.Forms.TextBox
    Friend WithEvents cboxEditarAgregarRamoIDSICY As System.Windows.Forms.ComboBox
    Friend WithEvents lblAgregarEditarRamoIDSICY As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
