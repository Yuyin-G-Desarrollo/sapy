<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportePolizasPeriodo
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
        Me.pnlInformacionAlta = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbAnios = New System.Windows.Forms.ComboBox()
        Me.cmbMeses = New System.Windows.Forms.ComboBox()
        Me.txtNoOrden = New System.Windows.Forms.TextBox()
        Me.lblNoOrden = New System.Windows.Forms.Label()
        Me.lblTipoSolicitud = New System.Windows.Forms.Label()
        Me.cmbTipoSolicitud = New System.Windows.Forms.ComboBox()
        Me.btnExaminar = New System.Windows.Forms.Button()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.lblEjercicio = New System.Windows.Forms.Label()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.svfRuta = New System.Windows.Forms.SaveFileDialog()
        Me.pnlInformacionAlta.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlInformacionAlta
        '
        Me.pnlInformacionAlta.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlInformacionAlta.Controls.Add(Me.GroupBox1)
        Me.pnlInformacionAlta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInformacionAlta.Location = New System.Drawing.Point(0, 60)
        Me.pnlInformacionAlta.Name = "pnlInformacionAlta"
        Me.pnlInformacionAlta.Size = New System.Drawing.Size(583, 302)
        Me.pnlInformacionAlta.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbAnios)
        Me.GroupBox1.Controls.Add(Me.cmbMeses)
        Me.GroupBox1.Controls.Add(Me.txtNoOrden)
        Me.GroupBox1.Controls.Add(Me.lblNoOrden)
        Me.GroupBox1.Controls.Add(Me.lblTipoSolicitud)
        Me.GroupBox1.Controls.Add(Me.cmbTipoSolicitud)
        Me.GroupBox1.Controls.Add(Me.btnExaminar)
        Me.GroupBox1.Controls.Add(Me.txtRuta)
        Me.GroupBox1.Controls.Add(Me.lblRuta)
        Me.GroupBox1.Controls.Add(Me.lblEjercicio)
        Me.GroupBox1.Controls.Add(Me.lblPeriodo)
        Me.GroupBox1.Controls.Add(Me.lblEmpresa)
        Me.GroupBox1.Controls.Add(Me.cmbEmpresa)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 274)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'cmbAnios
        '
        Me.cmbAnios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnios.FormattingEnabled = True
        Me.cmbAnios.Items.AddRange(New Object() {"", "2015", "2016"})
        Me.cmbAnios.Location = New System.Drawing.Point(151, 100)
        Me.cmbAnios.Name = "cmbAnios"
        Me.cmbAnios.Size = New System.Drawing.Size(100, 21)
        Me.cmbAnios.TabIndex = 27
        '
        'cmbMeses
        '
        Me.cmbMeses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMeses.FormattingEnabled = True
        Me.cmbMeses.Items.AddRange(New Object() {"", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cmbMeses.Location = New System.Drawing.Point(151, 66)
        Me.cmbMeses.Name = "cmbMeses"
        Me.cmbMeses.Size = New System.Drawing.Size(100, 21)
        Me.cmbMeses.TabIndex = 26
        '
        'txtNoOrden
        '
        Me.txtNoOrden.Location = New System.Drawing.Point(151, 211)
        Me.txtNoOrden.MaxLength = 20
        Me.txtNoOrden.Name = "txtNoOrden"
        Me.txtNoOrden.Size = New System.Drawing.Size(100, 20)
        Me.txtNoOrden.TabIndex = 23
        '
        'lblNoOrden
        '
        Me.lblNoOrden.AutoSize = True
        Me.lblNoOrden.Location = New System.Drawing.Point(33, 214)
        Me.lblNoOrden.Name = "lblNoOrden"
        Me.lblNoOrden.Size = New System.Drawing.Size(112, 13)
        Me.lblNoOrden.TabIndex = 22
        Me.lblNoOrden.Text = "* Número de Solicitud:"
        '
        'lblTipoSolicitud
        '
        Me.lblTipoSolicitud.AutoSize = True
        Me.lblTipoSolicitud.Location = New System.Drawing.Point(64, 176)
        Me.lblTipoSolicitud.Name = "lblTipoSolicitud"
        Me.lblTipoSolicitud.Size = New System.Drawing.Size(81, 13)
        Me.lblTipoSolicitud.TabIndex = 20
        Me.lblTipoSolicitud.Text = "* Tipo Solicitud:"
        '
        'cmbTipoSolicitud
        '
        Me.cmbTipoSolicitud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoSolicitud.FormattingEnabled = True
        Me.cmbTipoSolicitud.Items.AddRange(New Object() {"", "AF", "FC", "DE", "CO"})
        Me.cmbTipoSolicitud.Location = New System.Drawing.Point(151, 173)
        Me.cmbTipoSolicitud.Name = "cmbTipoSolicitud"
        Me.cmbTipoSolicitud.Size = New System.Drawing.Size(100, 21)
        Me.cmbTipoSolicitud.TabIndex = 19
        '
        'btnExaminar
        '
        Me.btnExaminar.Location = New System.Drawing.Point(454, 136)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(75, 23)
        Me.btnExaminar.TabIndex = 18
        Me.btnExaminar.Text = "Examinar..."
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'txtRuta
        '
        Me.txtRuta.Location = New System.Drawing.Point(151, 138)
        Me.txtRuta.MaxLength = 4
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.Size = New System.Drawing.Size(300, 20)
        Me.txtRuta.TabIndex = 17
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Location = New System.Drawing.Point(75, 141)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(70, 13)
        Me.lblRuta.TabIndex = 16
        Me.lblRuta.Text = "* Guardar en:"
        '
        'lblEjercicio
        '
        Me.lblEjercicio.AutoSize = True
        Me.lblEjercicio.Location = New System.Drawing.Point(88, 103)
        Me.lblEjercicio.Name = "lblEjercicio"
        Me.lblEjercicio.Size = New System.Drawing.Size(57, 13)
        Me.lblEjercicio.TabIndex = 13
        Me.lblEjercicio.Text = "* Ejercicio:"
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Location = New System.Drawing.Point(92, 69)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(53, 13)
        Me.lblPeriodo.TabIndex = 12
        Me.lblPeriodo.Text = "* Periodo:"
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(87, 35)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(58, 13)
        Me.lblEmpresa.TabIndex = 11
        Me.lblEmpresa.Text = "* Empresa:"
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(151, 32)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(300, 21)
        Me.cmbEmpresa.TabIndex = 10
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.Button1)
        Me.pnlPie.Controls.Add(Me.pnlBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 362)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(583, 65)
        Me.pnlPie.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(188, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'pnlBotones
        '
        Me.pnlBotones.BackColor = System.Drawing.Color.White
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Controls.Add(Me.btnAceptar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(466, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(117, 65)
        Me.pnlBotones.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(67, 9)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(67, 44)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 4
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(13, 44)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 0
        Me.lblGuardar.Text = "Guardar"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Contabilidad.Vista.My.Resources.Resources.guardar2_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(18, 9)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlTitulo)
        Me.pnlCabecera.Controls.Add(Me.imgLogo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(583, 60)
        Me.pnlCabecera.TabIndex = 6
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(232, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(281, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Location = New System.Drawing.Point(3, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(272, 36)
        Me.Panel1.TabIndex = 22
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(111, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(161, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Reporte de Pólizas"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(513, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'ReportePolizasPeriodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(583, 427)
        Me.Controls.Add(Me.pnlInformacionAlta)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlCabecera)
        Me.Name = "ReportePolizasPeriodo"
        Me.Text = "Reporte de Pólizas"
        Me.pnlInformacionAlta.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlInformacionAlta As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents btnExaminar As System.Windows.Forms.Button
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lblEjercicio As System.Windows.Forms.Label
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents svfRuta As System.Windows.Forms.SaveFileDialog
    Friend WithEvents txtNoOrden As System.Windows.Forms.TextBox
    Friend WithEvents lblNoOrden As System.Windows.Forms.Label
    Friend WithEvents lblTipoSolicitud As System.Windows.Forms.Label
    Friend WithEvents cmbTipoSolicitud As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAnios As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMeses As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
