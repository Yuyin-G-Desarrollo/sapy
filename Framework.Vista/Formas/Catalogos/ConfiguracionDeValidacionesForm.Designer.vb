<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfiguracionDeValidacionesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfiguracionDeValidacionesForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grpParametros = New System.Windows.Forms.GroupBox()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.grpValidacion = New System.Windows.Forms.GroupBox()
        Me.cboArea = New System.Windows.Forms.ComboBox()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.cboUsuarioAutorizado = New System.Windows.Forms.ComboBox()
        Me.cboDepartamento = New System.Windows.Forms.ComboBox()
        Me.cboNave = New System.Windows.Forms.ComboBox()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.lblUsuarioAutorizado = New System.Windows.Forms.Label()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblValidaNave = New System.Windows.Forms.Label()
        Me.lblValidaTipo = New System.Windows.Forms.Label()
        Me.pnlListaUsuarios = New System.Windows.Forms.Panel()
        Me.grdConfiguracionValidaciones = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.grpParametros.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.grpValidacion.SuspendLayout()
        Me.pnlListaUsuarios.SuspendLayout()
        CType(Me.grdConfiguracionValidaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(964, 53)
        Me.pnlHeader.TabIndex = 14
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(545, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(419, 53)
        Me.pnlTitulo.TabIndex = 46
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(93, 16)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(252, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Configuración de Validaciones"
        '
        'grpParametros
        '
        Me.grpParametros.BackColor = System.Drawing.Color.Transparent
        Me.grpParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.grpParametros.Controls.Add(Me.grpValidacion)
        Me.grpParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpParametros.Location = New System.Drawing.Point(0, 53)
        Me.grpParametros.Name = "grpParametros"
        Me.grpParametros.Size = New System.Drawing.Size(964, 299)
        Me.grpParametros.TabIndex = 15
        Me.grpParametros.TabStop = False
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(892, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(66, 280)
        Me.pnlMinimizarParametros.TabIndex = 48
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(9, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 1
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(35, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 2
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'grpValidacion
        '
        Me.grpValidacion.Controls.Add(Me.cboArea)
        Me.grpValidacion.Controls.Add(Me.lblArea)
        Me.grpValidacion.Controls.Add(Me.Label1)
        Me.grpValidacion.Controls.Add(Me.btnGuardar)
        Me.grpValidacion.Controls.Add(Me.cboUsuarioAutorizado)
        Me.grpValidacion.Controls.Add(Me.cboDepartamento)
        Me.grpValidacion.Controls.Add(Me.cboNave)
        Me.grpValidacion.Controls.Add(Me.cboTipo)
        Me.grpValidacion.Controls.Add(Me.lblUsuarioAutorizado)
        Me.grpValidacion.Controls.Add(Me.lblDepartamento)
        Me.grpValidacion.Controls.Add(Me.lblValidaNave)
        Me.grpValidacion.Controls.Add(Me.lblValidaTipo)
        Me.grpValidacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpValidacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpValidacion.Location = New System.Drawing.Point(213, 41)
        Me.grpValidacion.Name = "grpValidacion"
        Me.grpValidacion.Size = New System.Drawing.Size(589, 252)
        Me.grpValidacion.TabIndex = 54
        Me.grpValidacion.TabStop = False
        Me.grpValidacion.Text = "Validación"
        '
        'cboArea
        '
        Me.cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboArea.FormattingEnabled = True
        Me.cboArea.Location = New System.Drawing.Point(132, 100)
        Me.cboArea.Name = "cboArea"
        Me.cboArea.Size = New System.Drawing.Size(428, 21)
        Me.cboArea.TabIndex = 5
        '
        'lblArea
        '
        Me.lblArea.AutoSize = True
        Me.lblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArea.Location = New System.Drawing.Point(26, 103)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(33, 13)
        Me.lblArea.TabIndex = 22
        Me.lblArea.Text = "Área*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(525, 234)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(530, 198)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 33)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'cboUsuarioAutorizado
        '
        Me.cboUsuarioAutorizado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUsuarioAutorizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUsuarioAutorizado.FormattingEnabled = True
        Me.cboUsuarioAutorizado.Location = New System.Drawing.Point(132, 168)
        Me.cboUsuarioAutorizado.Name = "cboUsuarioAutorizado"
        Me.cboUsuarioAutorizado.Size = New System.Drawing.Size(428, 21)
        Me.cboUsuarioAutorizado.TabIndex = 7
        '
        'cboDepartamento
        '
        Me.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepartamento.FormattingEnabled = True
        Me.cboDepartamento.Location = New System.Drawing.Point(132, 134)
        Me.cboDepartamento.Name = "cboDepartamento"
        Me.cboDepartamento.Size = New System.Drawing.Size(428, 21)
        Me.cboDepartamento.TabIndex = 6
        '
        'cboNave
        '
        Me.cboNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNave.FormattingEnabled = True
        Me.cboNave.Location = New System.Drawing.Point(132, 66)
        Me.cboNave.Name = "cboNave"
        Me.cboNave.Size = New System.Drawing.Size(428, 21)
        Me.cboNave.TabIndex = 4
        '
        'cboTipo
        '
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Enabled = False
        Me.cboTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(132, 32)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(428, 21)
        Me.cboTipo.TabIndex = 3
        '
        'lblUsuarioAutorizado
        '
        Me.lblUsuarioAutorizado.AutoSize = True
        Me.lblUsuarioAutorizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuarioAutorizado.Location = New System.Drawing.Point(26, 171)
        Me.lblUsuarioAutorizado.Name = "lblUsuarioAutorizado"
        Me.lblUsuarioAutorizado.Size = New System.Drawing.Size(100, 13)
        Me.lblUsuarioAutorizado.TabIndex = 7
        Me.lblUsuarioAutorizado.Text = "Usuario Autorizado*"
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartamento.Location = New System.Drawing.Point(26, 137)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(78, 13)
        Me.lblDepartamento.TabIndex = 5
        Me.lblDepartamento.Text = "Departamento*"
        '
        'lblValidaNave
        '
        Me.lblValidaNave.AutoSize = True
        Me.lblValidaNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValidaNave.Location = New System.Drawing.Point(26, 69)
        Me.lblValidaNave.Name = "lblValidaNave"
        Me.lblValidaNave.Size = New System.Drawing.Size(37, 13)
        Me.lblValidaNave.TabIndex = 4
        Me.lblValidaNave.Text = "Nave*"
        '
        'lblValidaTipo
        '
        Me.lblValidaTipo.AutoSize = True
        Me.lblValidaTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValidaTipo.Location = New System.Drawing.Point(26, 35)
        Me.lblValidaTipo.Name = "lblValidaTipo"
        Me.lblValidaTipo.Size = New System.Drawing.Size(32, 13)
        Me.lblValidaTipo.TabIndex = 2
        Me.lblValidaTipo.Text = "Tipo*"
        '
        'pnlListaUsuarios
        '
        Me.pnlListaUsuarios.Controls.Add(Me.grdConfiguracionValidaciones)
        Me.pnlListaUsuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListaUsuarios.Location = New System.Drawing.Point(0, 352)
        Me.pnlListaUsuarios.Name = "pnlListaUsuarios"
        Me.pnlListaUsuarios.Size = New System.Drawing.Size(964, 126)
        Me.pnlListaUsuarios.TabIndex = 16
        '
        'grdConfiguracionValidaciones
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdConfiguracionValidaciones.DisplayLayout.Appearance = Appearance1
        Me.grdConfiguracionValidaciones.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdConfiguracionValidaciones.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdConfiguracionValidaciones.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdConfiguracionValidaciones.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdConfiguracionValidaciones.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdConfiguracionValidaciones.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdConfiguracionValidaciones.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdConfiguracionValidaciones.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdConfiguracionValidaciones.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdConfiguracionValidaciones.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdConfiguracionValidaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdConfiguracionValidaciones.Location = New System.Drawing.Point(0, 0)
        Me.grdConfiguracionValidaciones.Name = "grdConfiguracionValidaciones"
        Me.grdConfiguracionValidaciones.Size = New System.Drawing.Size(964, 126)
        Me.grdConfiguracionValidaciones.TabIndex = 9
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(351, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'ConfiguracionDeValidacionesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(964, 478)
        Me.Controls.Add(Me.pnlListaUsuarios)
        Me.Controls.Add(Me.grpParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(600, 500)
        Me.Name = "ConfiguracionDeValidacionesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Configuración de  Validaciones"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.grpParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.grpValidacion.ResumeLayout(False)
        Me.grpValidacion.PerformLayout()
        Me.pnlListaUsuarios.ResumeLayout(False)
        CType(Me.grdConfiguracionValidaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents grpParametros As System.Windows.Forms.GroupBox
    Friend WithEvents grpValidacion As System.Windows.Forms.GroupBox
    Friend WithEvents lblUsuarioAutorizado As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblValidaNave As System.Windows.Forms.Label
    Friend WithEvents lblValidaTipo As System.Windows.Forms.Label
    Friend WithEvents cboUsuarioAutorizado As System.Windows.Forms.ComboBox
    Friend WithEvents cboDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents cboNave As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cboArea As System.Windows.Forms.ComboBox
    Friend WithEvents lblArea As System.Windows.Forms.Label
    Friend WithEvents pnlListaUsuarios As System.Windows.Forms.Panel
    Friend WithEvents grdConfiguracionValidaciones As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
