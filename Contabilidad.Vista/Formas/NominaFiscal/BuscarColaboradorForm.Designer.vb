<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuscarColaboradorForm
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblEmpleado = New System.Windows.Forms.Label()
        Me.lblSeleccionar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdbExternoNo = New System.Windows.Forms.RadioButton()
        Me.rdbExternoSi = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.btnSeleccionar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.grdColaboradores = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdColaboradores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(79, 80)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(414, 20)
        Me.txtNombre.TabIndex = 2
        '
        'lblEmpleado
        '
        Me.lblEmpleado.AutoSize = True
        Me.lblEmpleado.ForeColor = System.Drawing.Color.Black
        Me.lblEmpleado.Location = New System.Drawing.Point(22, 83)
        Me.lblEmpleado.Name = "lblEmpleado"
        Me.lblEmpleado.Size = New System.Drawing.Size(44, 13)
        Me.lblEmpleado.TabIndex = 31
        Me.lblEmpleado.Text = "Nombre"
        '
        'lblSeleccionar
        '
        Me.lblSeleccionar.AutoSize = True
        Me.lblSeleccionar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSeleccionar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSeleccionar.Location = New System.Drawing.Point(805, 84)
        Me.lblSeleccionar.Name = "lblSeleccionar"
        Me.lblSeleccionar.Size = New System.Drawing.Size(63, 13)
        Me.lblSeleccionar.TabIndex = 41
        Me.lblSeleccionar.Text = "Seleccionar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(825, 47)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 49
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(22, 50)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 50
        Me.lblNave.Text = "Nave"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(79, 47)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(414, 21)
        Me.cmbNave.TabIndex = 1
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(760, 84)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 52
        Me.lblBuscar.Text = "Mostrar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.cmbEmpresa)
        Me.GroupBox1.Controls.Add(Me.lblEmpresa)
        Me.GroupBox1.Controls.Add(Me.cmbNave)
        Me.GroupBox1.Controls.Add(Me.lblBuscar)
        Me.GroupBox1.Controls.Add(Me.lblNave)
        Me.GroupBox1.Controls.Add(Me.btnSeleccionar)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.lblSeleccionar)
        Me.GroupBox1.Controls.Add(Me.lblEmpleado)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(894, 109)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdbExternoNo)
        Me.GroupBox2.Controls.Add(Me.rdbExternoSi)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(515, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(127, 60)
        Me.GroupBox2.TabIndex = 55
        Me.GroupBox2.TabStop = False
        '
        'rdbExternoNo
        '
        Me.rdbExternoNo.AutoSize = True
        Me.rdbExternoNo.Checked = True
        Me.rdbExternoNo.Location = New System.Drawing.Point(79, 37)
        Me.rdbExternoNo.Name = "rdbExternoNo"
        Me.rdbExternoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdbExternoNo.TabIndex = 2
        Me.rdbExternoNo.TabStop = True
        Me.rdbExternoNo.Text = "No"
        Me.rdbExternoNo.UseVisualStyleBackColor = True
        '
        'rdbExternoSi
        '
        Me.rdbExternoSi.AutoSize = True
        Me.rdbExternoSi.Location = New System.Drawing.Point(16, 37)
        Me.rdbExternoSi.Name = "rdbExternoSi"
        Me.rdbExternoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdbExternoSi.TabIndex = 1
        Me.rdbExternoSi.Text = "Si"
        Me.rdbExternoSi.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Externo"
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.ForeColor = System.Drawing.Color.Black
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(79, 14)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(414, 21)
        Me.cmbEmpresa.TabIndex = 54
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.lblEmpresa.Location = New System.Drawing.Point(22, 17)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(48, 13)
        Me.lblEmpresa.TabIndex = 53
        Me.lblEmpresa.Text = "Empresa"
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.BackgroundImage = Global.Contabilidad.Vista.My.Resources.Resources.nuevo_32
        Me.btnSeleccionar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSeleccionar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSeleccionar.Location = New System.Drawing.Point(823, 51)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(32, 32)
        Me.btnSeleccionar.TabIndex = 4
        Me.btnSeleccionar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.BackgroundImage = Global.Contabilidad.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Location = New System.Drawing.Point(763, 51)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 461)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(894, 67)
        Me.Panel1.TabIndex = 55
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(827, 12)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 48
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'grdColaboradores
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColaboradores.DisplayLayout.Appearance = Appearance1
        Me.grdColaboradores.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdColaboradores.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdColaboradores.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdColaboradores.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdColaboradores.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdColaboradores.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColaboradores.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdColaboradores.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdColaboradores.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.grdColaboradores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdColaboradores.Location = New System.Drawing.Point(0, 168)
        Me.grdColaboradores.Name = "grdColaboradores"
        Me.grdColaboradores.Size = New System.Drawing.Size(894, 293)
        Me.grdColaboradores.TabIndex = 56
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(647, 21)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(168, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Buscar Colaborador"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.imgLogo)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezado)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(894, 59)
        Me.pnlEncabezado.TabIndex = 36
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(822, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 59)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 38
        Me.imgLogo.TabStop = False
        '
        'BuscarColaboradorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(894, 528)
        Me.ControlBox = False
        Me.Controls.Add(Me.grdColaboradores)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(900, 550)
        Me.MinimumSize = New System.Drawing.Size(900, 550)
        Me.Name = "BuscarColaboradorForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Colaborador"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdColaboradores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSeleccionar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblEmpleado As System.Windows.Forms.Label
    Friend WithEvents lblSeleccionar As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rdbExternoSi As System.Windows.Forms.RadioButton
    Friend WithEvents rdbExternoNo As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdColaboradores As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
