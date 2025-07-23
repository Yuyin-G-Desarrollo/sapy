<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResumenInventarioProcesoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResumenInventarioProcesoForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblAdministracionAvances = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.lblExpExcel = New System.Windows.Forms.Label()
        Me.btnExpExcel = New System.Windows.Forms.Button()
        Me.btnExpPDF = New System.Windows.Forms.Button()
        Me.lblExpPDF = New System.Windows.Forms.Label()
        Me.grbLotesAvances = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.dtpFechaProgramacionA = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaProgramacionDe = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbLotesAvances.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.Panel1)
        Me.pnlEncabezado.Controls.Add(Me.btnImprimir)
        Me.pnlEncabezado.Controls.Add(Me.lblImprimir)
        Me.pnlEncabezado.Controls.Add(Me.lblExpExcel)
        Me.pnlEncabezado.Controls.Add(Me.btnExpExcel)
        Me.pnlEncabezado.Controls.Add(Me.btnExpPDF)
        Me.pnlEncabezado.Controls.Add(Me.lblExpPDF)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(530, 81)
        Me.pnlEncabezado.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblAdministracionAvances)
        Me.Panel1.Controls.Add(Me.imgLogo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(325, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(205, 81)
        Me.Panel1.TabIndex = 24
        '
        'lblAdministracionAvances
        '
        Me.lblAdministracionAvances.AutoSize = True
        Me.lblAdministracionAvances.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdministracionAvances.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAdministracionAvances.Location = New System.Drawing.Point(20, 58)
        Me.lblAdministracionAvances.Name = "lblAdministracionAvances"
        Me.lblAdministracionAvances.Size = New System.Drawing.Size(184, 20)
        Me.lblAdministracionAvances.TabIndex = 21
        Me.lblAdministracionAvances.Text = "Inventario en Proceso"
        '
        'imgLogo
        '
        Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
        Me.imgLogo.Location = New System.Drawing.Point(68, 3)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(129, 59)
        Me.imgLogo.TabIndex = 0
        Me.imgLogo.TabStop = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Produccion.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(21, 12)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 0
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(16, 47)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 23
        Me.lblImprimir.Text = "Imprimir"
        '
        'lblExpExcel
        '
        Me.lblExpExcel.AutoSize = True
        Me.lblExpExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExpExcel.Location = New System.Drawing.Point(153, 47)
        Me.lblExpExcel.Name = "lblExpExcel"
        Me.lblExpExcel.Size = New System.Drawing.Size(84, 13)
        Me.lblExpExcel.TabIndex = 19
        Me.lblExpExcel.Text = "Exportar a Excel"
        '
        'btnExpExcel
        '
        Me.btnExpExcel.Image = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnExpExcel.Location = New System.Drawing.Point(179, 12)
        Me.btnExpExcel.Name = "btnExpExcel"
        Me.btnExpExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExpExcel.TabIndex = 2
        Me.btnExpExcel.UseVisualStyleBackColor = True
        '
        'btnExpPDF
        '
        Me.btnExpPDF.Image = Global.Produccion.Vista.My.Resources.Resources.pdf_32
        Me.btnExpPDF.Location = New System.Drawing.Point(98, 12)
        Me.btnExpPDF.Name = "btnExpPDF"
        Me.btnExpPDF.Size = New System.Drawing.Size(32, 32)
        Me.btnExpPDF.TabIndex = 1
        Me.btnExpPDF.UseVisualStyleBackColor = True
        '
        'lblExpPDF
        '
        Me.lblExpPDF.AutoSize = True
        Me.lblExpPDF.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExpPDF.Location = New System.Drawing.Point(72, 47)
        Me.lblExpPDF.Name = "lblExpPDF"
        Me.lblExpPDF.Size = New System.Drawing.Size(79, 13)
        Me.lblExpPDF.TabIndex = 16
        Me.lblExpPDF.Text = "Exportar a PDF"
        '
        'grbLotesAvances
        '
        Me.grbLotesAvances.Controls.Add(Me.Label1)
        Me.grbLotesAvances.Controls.Add(Me.cmbNave)
        Me.grbLotesAvances.Controls.Add(Me.dtpFechaProgramacionA)
        Me.grbLotesAvances.Controls.Add(Me.dtpFechaProgramacionDe)
        Me.grbLotesAvances.Controls.Add(Me.Label4)
        Me.grbLotesAvances.Controls.Add(Me.Label3)
        Me.grbLotesAvances.Controls.Add(Me.lblDepartamento)
        Me.grbLotesAvances.Controls.Add(Me.cmbDepartamento)
        Me.grbLotesAvances.Controls.Add(Me.btnAbajo)
        Me.grbLotesAvances.Controls.Add(Me.btnArriba)
        Me.grbLotesAvances.Controls.Add(Me.lblLimpiar)
        Me.grbLotesAvances.Controls.Add(Me.btnLimpiar)
        Me.grbLotesAvances.Controls.Add(Me.lblNave)
        Me.grbLotesAvances.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grbLotesAvances.Location = New System.Drawing.Point(0, 84)
        Me.grbLotesAvances.Name = "grbLotesAvances"
        Me.grbLotesAvances.Size = New System.Drawing.Size(530, 228)
        Me.grbLotesAvances.TabIndex = 5
        Me.grbLotesAvances.TabStop = False
        Me.grbLotesAvances.Text = "Busqueda"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Fecha Programa"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(69, 57)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(160, 21)
        Me.cmbNave.TabIndex = 3
        '
        'dtpFechaProgramacionA
        '
        Me.dtpFechaProgramacionA.Location = New System.Drawing.Point(49, 152)
        Me.dtpFechaProgramacionA.Name = "dtpFechaProgramacionA"
        Me.dtpFechaProgramacionA.Size = New System.Drawing.Size(210, 20)
        Me.dtpFechaProgramacionA.TabIndex = 12
        '
        'dtpFechaProgramacionDe
        '
        Me.dtpFechaProgramacionDe.Location = New System.Drawing.Point(49, 122)
        Me.dtpFechaProgramacionDe.Name = "dtpFechaProgramacionDe"
        Me.dtpFechaProgramacionDe.Size = New System.Drawing.Size(210, 20)
        Me.dtpFechaProgramacionDe.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "A"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "De"
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(271, 61)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(74, 13)
        Me.lblDepartamento.TabIndex = 4
        Me.lblDepartamento.Text = "Departamento"
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(349, 57)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(159, 21)
        Me.cmbDepartamento.TabIndex = 5
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(504, 14)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 17
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(473, 14)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 16
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(478, 202)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 25
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(481, 168)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 23
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(25, 61)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 2
        Me.lblNave.Text = "Nave"
        '
        'ResumenInventarioProcesoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 312)
        Me.Controls.Add(Me.grbLotesAvances)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ResumenInventarioProcesoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario en Proceso"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbLotesAvances.ResumeLayout(False)
        Me.grbLotesAvances.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblAdministracionAvances As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents lblExpExcel As System.Windows.Forms.Label
    Friend WithEvents btnExpExcel As System.Windows.Forms.Button
    Friend WithEvents btnExpPDF As System.Windows.Forms.Button
    Friend WithEvents lblExpPDF As System.Windows.Forms.Label
    Friend WithEvents grbLotesAvances As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFechaProgramacionA As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaProgramacionDe As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblNave As System.Windows.Forms.Label
End Class
