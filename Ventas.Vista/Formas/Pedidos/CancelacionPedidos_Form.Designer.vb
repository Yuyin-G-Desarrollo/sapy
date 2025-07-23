<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CancelacionPedidos_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CancelacionPedidos_Form))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSolicita = New System.Windows.Forms.TextBox()
        Me.pnPBar = New System.Windows.Forms.Panel()
        Me.lblNumeroDocumentos = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblDocumentosFacturados = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.pBar = New System.Windows.Forms.ProgressBar()
        Me.lblSolicita = New System.Windows.Forms.Label()
        Me.txtParesEnProceso = New System.Windows.Forms.TextBox()
        Me.cmbMotivo = New System.Windows.Forms.ComboBox()
        Me.txtParesEnInventario = New System.Windows.Forms.TextBox()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.lblParesEnProceso = New System.Windows.Forms.Label()
        Me.lblParesEnInventario = New System.Windows.Forms.Label()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.txtParesACancelar = New System.Windows.Forms.TextBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblParesACancelar = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlContenido.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnPBar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(491, 65)
        Me.pnlEncabezado.TabIndex = 45
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(171, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(320, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(57, 24)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(189, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Motivo de Cancelación"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 414)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(491, 63)
        Me.pnlPie.TabIndex = 160
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(171, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(320, 63)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(228, 40)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(44, 13)
        Me.lblAceptar.TabIndex = 161
        Me.lblAceptar.Text = "Aceptar"
        '
        'btnAceptar
        '
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Ventas.Vista.My.Resources.Resources.enviarcalculo_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(232, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(276, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(275, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlContenido
        '
        Me.pnlContenido.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenido.Controls.Add(Me.GroupBox1)
        Me.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenido.Location = New System.Drawing.Point(0, 65)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(491, 349)
        Me.pnlContenido.TabIndex = 161
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSolicita)
        Me.GroupBox1.Controls.Add(Me.pnPBar)
        Me.GroupBox1.Controls.Add(Me.lblSolicita)
        Me.GroupBox1.Controls.Add(Me.txtParesEnProceso)
        Me.GroupBox1.Controls.Add(Me.cmbMotivo)
        Me.GroupBox1.Controls.Add(Me.txtParesEnInventario)
        Me.GroupBox1.Controls.Add(Me.lblMotivo)
        Me.GroupBox1.Controls.Add(Me.lblParesEnProceso)
        Me.GroupBox1.Controls.Add(Me.lblParesEnInventario)
        Me.GroupBox1.Controls.Add(Me.lblObservaciones)
        Me.GroupBox1.Controls.Add(Me.txtParesACancelar)
        Me.GroupBox1.Controls.Add(Me.txtObservaciones)
        Me.GroupBox1.Controls.Add(Me.lblParesACancelar)
        Me.GroupBox1.Location = New System.Drawing.Point(42, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(380, 278)
        Me.GroupBox1.TabIndex = 164
        Me.GroupBox1.TabStop = False
        '
        'txtSolicita
        '
        Me.txtSolicita.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSolicita.Location = New System.Drawing.Point(72, 19)
        Me.txtSolicita.Name = "txtSolicita"
        Me.txtSolicita.Size = New System.Drawing.Size(280, 20)
        Me.txtSolicita.TabIndex = 0
        '
        'pnPBar
        '
        Me.pnPBar.BackColor = System.Drawing.Color.White
        Me.pnPBar.Controls.Add(Me.lblNumeroDocumentos)
        Me.pnPBar.Controls.Add(Me.Label8)
        Me.pnPBar.Controls.Add(Me.lblDocumentosFacturados)
        Me.pnPBar.Controls.Add(Me.Label6)
        Me.pnPBar.Controls.Add(Me.lblInfo)
        Me.pnPBar.Controls.Add(Me.pBar)
        Me.pnPBar.Location = New System.Drawing.Point(18, 82)
        Me.pnPBar.Name = "pnPBar"
        Me.pnPBar.Size = New System.Drawing.Size(322, 126)
        Me.pnPBar.TabIndex = 163
        Me.pnPBar.Visible = False
        '
        'lblNumeroDocumentos
        '
        Me.lblNumeroDocumentos.AutoSize = True
        Me.lblNumeroDocumentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroDocumentos.Location = New System.Drawing.Point(223, 12)
        Me.lblNumeroDocumentos.Name = "lblNumeroDocumentos"
        Me.lblNumeroDocumentos.Size = New System.Drawing.Size(16, 16)
        Me.lblNumeroDocumentos.TabIndex = 112
        Me.lblNumeroDocumentos.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(187, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 16)
        Me.Label8.TabIndex = 111
        Me.Label8.Text = "de"
        '
        'lblDocumentosFacturados
        '
        Me.lblDocumentosFacturados.AutoSize = True
        Me.lblDocumentosFacturados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumentosFacturados.Location = New System.Drawing.Point(165, 12)
        Me.lblDocumentosFacturados.Name = "lblDocumentosFacturados"
        Me.lblDocumentosFacturados.Size = New System.Drawing.Size(16, 16)
        Me.lblDocumentosFacturados.TabIndex = 110
        Me.lblDocumentosFacturados.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(135, 16)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = "Pedidos Cancelados"
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.Location = New System.Drawing.Point(16, 33)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(43, 16)
        Me.lblInfo.TabIndex = 108
        Me.lblInfo.Text = "lblInfo"
        '
        'pBar
        '
        Me.pBar.Location = New System.Drawing.Point(17, 64)
        Me.pBar.Name = "pBar"
        Me.pBar.Size = New System.Drawing.Size(276, 23)
        Me.pBar.TabIndex = 107
        '
        'lblSolicita
        '
        Me.lblSolicita.AutoSize = True
        Me.lblSolicita.Location = New System.Drawing.Point(13, 23)
        Me.lblSolicita.Name = "lblSolicita"
        Me.lblSolicita.Size = New System.Drawing.Size(48, 13)
        Me.lblSolicita.TabIndex = 2
        Me.lblSolicita.Text = "*Solicita:"
        '
        'txtParesEnProceso
        '
        Me.txtParesEnProceso.Enabled = False
        Me.txtParesEnProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParesEnProceso.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtParesEnProceso.Location = New System.Drawing.Point(267, 226)
        Me.txtParesEnProceso.Name = "txtParesEnProceso"
        Me.txtParesEnProceso.Size = New System.Drawing.Size(67, 20)
        Me.txtParesEnProceso.TabIndex = 12
        Me.txtParesEnProceso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbMotivo
        '
        Me.cmbMotivo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMotivo.FormattingEnabled = True
        Me.cmbMotivo.ItemHeight = 13
        Me.cmbMotivo.Location = New System.Drawing.Point(72, 55)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.Size = New System.Drawing.Size(280, 21)
        Me.cmbMotivo.TabIndex = 2
        '
        'txtParesEnInventario
        '
        Me.txtParesEnInventario.Enabled = False
        Me.txtParesEnInventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParesEnInventario.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtParesEnInventario.Location = New System.Drawing.Point(157, 225)
        Me.txtParesEnInventario.Name = "txtParesEnInventario"
        Me.txtParesEnInventario.Size = New System.Drawing.Size(67, 20)
        Me.txtParesEnInventario.TabIndex = 11
        Me.txtParesEnInventario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.Location = New System.Drawing.Point(15, 59)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(46, 13)
        Me.lblMotivo.TabIndex = 3
        Me.lblMotivo.Text = "*Motivo:"
        '
        'lblParesEnProceso
        '
        Me.lblParesEnProceso.AutoSize = True
        Me.lblParesEnProceso.Location = New System.Drawing.Point(274, 196)
        Me.lblParesEnProceso.Name = "lblParesEnProceso"
        Me.lblParesEnProceso.Size = New System.Drawing.Size(52, 26)
        Me.lblParesEnProceso.TabIndex = 10
        Me.lblParesEnProceso.Text = "Pares en " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Proceso"
        Me.lblParesEnProceso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblParesEnInventario
        '
        Me.lblParesEnInventario.AutoSize = True
        Me.lblParesEnInventario.Location = New System.Drawing.Point(163, 196)
        Me.lblParesEnInventario.Name = "lblParesEnInventario"
        Me.lblParesEnInventario.Size = New System.Drawing.Size(54, 26)
        Me.lblParesEnInventario.TabIndex = 8
        Me.lblParesEnInventario.Text = "Pares en " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Inventario"
        Me.lblParesEnInventario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Location = New System.Drawing.Point(15, 93)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(85, 13)
        Me.lblObservaciones.TabIndex = 5
        Me.lblObservaciones.Text = "*Observaciones:"
        '
        'txtParesACancelar
        '
        Me.txtParesACancelar.Enabled = False
        Me.txtParesACancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParesACancelar.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtParesACancelar.Location = New System.Drawing.Point(41, 226)
        Me.txtParesACancelar.Name = "txtParesACancelar"
        Me.txtParesACancelar.Size = New System.Drawing.Size(67, 20)
        Me.txtParesACancelar.TabIndex = 7
        Me.txtParesACancelar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(18, 109)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(334, 68)
        Me.txtObservaciones.TabIndex = 3
        '
        'lblParesACancelar
        '
        Me.lblParesACancelar.AutoSize = True
        Me.lblParesACancelar.Location = New System.Drawing.Point(50, 196)
        Me.lblParesACancelar.Name = "lblParesACancelar"
        Me.lblParesACancelar.Size = New System.Drawing.Size(49, 26)
        Me.lblParesACancelar.TabIndex = 6
        Me.lblParesACancelar.Text = "Pares a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cancelar"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(252, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 65)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 91
        Me.PictureBox1.TabStop = False
        '
        'CancelacionPedidos_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(491, 477)
        Me.Controls.Add(Me.pnlContenido)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CancelacionPedidos_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Motivo de Cancelación"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlContenido.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnPBar.ResumeLayout(False)
        Me.pnPBar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents lblAceptar As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents cmbMotivo As ComboBox
    Friend WithEvents txtParesEnProceso As TextBox
    Friend WithEvents txtParesEnInventario As TextBox
    Friend WithEvents lblParesEnProceso As Label
    Friend WithEvents lblParesEnInventario As Label
    Friend WithEvents txtParesACancelar As TextBox
    Friend WithEvents lblParesACancelar As Label
    Friend WithEvents lblObservaciones As Label
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents lblMotivo As Label
    Friend WithEvents lblSolicita As Label
    Friend WithEvents txtSolicita As TextBox
    Friend WithEvents pnPBar As Panel
    Friend WithEvents lblNumeroDocumentos As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblDocumentosFacturados As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblInfo As Label
    Friend WithEvents pBar As ProgressBar
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
