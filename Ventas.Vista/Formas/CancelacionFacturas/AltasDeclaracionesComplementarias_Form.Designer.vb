<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasDeclaracionesComplementarias_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltasDeclaracionesComplementarias_Form))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblAreas = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.grbArea = New System.Windows.Forms.GroupBox()
        Me.cmbEmpresa2 = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.DtpFechaDeclaracion = New System.Windows.Forms.DateTimePicker()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMes = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.grbArea.SuspendLayout()
        CType(Me.cmbEmpresa2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblAreas)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(404, 56)
        Me.pnlEncabezado.TabIndex = 8
        '
        'lblAreas
        '
        Me.lblAreas.AutoSize = True
        Me.lblAreas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAreas.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAreas.Location = New System.Drawing.Point(131, 19)
        Me.lblAreas.Name = "lblAreas"
        Me.lblAreas.Size = New System.Drawing.Size(198, 20)
        Me.lblAreas.TabIndex = 21
        Me.lblAreas.Text = "Alta de complementaria"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(336, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 56)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 47
        Me.pbYuyin.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 264)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(404, 64)
        Me.Panel1.TabIndex = 41
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCncelar)
        Me.Panel2.Controls.Add(Me.btnGuardar)
        Me.Panel2.Controls.Add(Me.lblGuardar)
        Me.Panel2.Controls.Add(Me.lblCancelar)
        Me.Panel2.Location = New System.Drawing.Point(281, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(122, 64)
        Me.Panel2.TabIndex = 39
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCncelar.Location = New System.Drawing.Point(59, 3)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 36
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(15, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 35
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(9, 35)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 37
        Me.lblGuardar.Text = "Guardar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(58, 35)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 38
        Me.lblCancelar.Text = "Cerrar"
        '
        'grbArea
        '
        Me.grbArea.Controls.Add(Me.cmbEmpresa2)
        Me.grbArea.Controls.Add(Me.DtpFechaDeclaracion)
        Me.grbArea.Controls.Add(Me.cmbMes)
        Me.grbArea.Controls.Add(Me.Label1)
        Me.grbArea.Controls.Add(Me.lblMes)
        Me.grbArea.Controls.Add(Me.lblEmpresa)
        Me.grbArea.Location = New System.Drawing.Point(36, 87)
        Me.grbArea.Name = "grbArea"
        Me.grbArea.Size = New System.Drawing.Size(331, 160)
        Me.grbArea.TabIndex = 42
        Me.grbArea.TabStop = False
        Me.grbArea.Text = "Declaración Complementaria"
        '
        'cmbEmpresa2
        '
        Me.cmbEmpresa2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Me.cmbEmpresa2.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains
        Me.cmbEmpresa2.CheckedListSettings.CheckBoxAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmbEmpresa2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbEmpresa2.Location = New System.Drawing.Point(107, 37)
        Me.cmbEmpresa2.Name = "cmbEmpresa2"
        Me.cmbEmpresa2.Size = New System.Drawing.Size(197, 21)
        Me.cmbEmpresa2.TabIndex = 46
        '
        'DtpFechaDeclaracion
        '
        Me.DtpFechaDeclaracion.Location = New System.Drawing.Point(107, 114)
        Me.DtpFechaDeclaracion.Name = "DtpFechaDeclaracion"
        Me.DtpFechaDeclaracion.Size = New System.Drawing.Size(197, 20)
        Me.DtpFechaDeclaracion.TabIndex = 45
        '
        'cmbMes
        '
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Location = New System.Drawing.Point(107, 73)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(121, 21)
        Me.cmbMes.TabIndex = 44
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Fecha declaración"
        '
        'lblMes
        '
        Me.lblMes.AutoSize = True
        Me.lblMes.ForeColor = System.Drawing.Color.Black
        Me.lblMes.Location = New System.Drawing.Point(15, 76)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(86, 13)
        Me.lblMes.TabIndex = 41
        Me.lblMes.Text = "Mes del ejercicio"
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.lblEmpresa.Location = New System.Drawing.Point(53, 37)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(48, 13)
        Me.lblEmpresa.TabIndex = 37
        Me.lblEmpresa.Text = "Empresa"
        '
        'AltasDeclaracionesComplementarias_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(404, 328)
        Me.Controls.Add(Me.grbArea)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(420, 367)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(420, 367)
        Me.Name = "AltasDeclaracionesComplementarias_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta de complementaria"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.grbArea.ResumeLayout(False)
        Me.grbArea.PerformLayout()
        CType(Me.cmbEmpresa2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblAreas As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCncelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblGuardar As Label
    Friend WithEvents lblCancelar As Label
    Friend WithEvents grbArea As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblMes As Label
    Friend WithEvents lblEmpresa As Label
    Friend WithEvents cmbMes As ComboBox
    Friend WithEvents DtpFechaDeclaracion As DateTimePicker
    Friend WithEvents cmbEmpresa2 As Infragistics.Win.UltraWinEditors.UltraComboEditor
End Class
