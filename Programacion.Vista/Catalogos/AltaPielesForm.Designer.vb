<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaPielesForm
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTItulo = New System.Windows.Forms.Label()
        Me.ptbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblNombreCorto = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.lblCodSicy = New System.Windows.Forms.Label()
        Me.txtCodSicy = New System.Windows.Forms.TextBox()
        Me.gprDatos = New System.Windows.Forms.GroupBox()
        Me.lblColores = New System.Windows.Forms.Label()
        Me.btnColores = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdColores = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.ptbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.gprDatos.SuspendLayout()
        CType(Me.grdColores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(384, 60)
        Me.pnlHeader.TabIndex = 0
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTItulo)
        Me.pnlTitulo.Controls.Add(Me.ptbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(159, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(225, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTItulo
        '
        Me.lblTItulo.AutoSize = True
        Me.lblTItulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTItulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTItulo.Location = New System.Drawing.Point(19, 19)
        Me.lblTItulo.Name = "lblTItulo"
        Me.lblTItulo.Size = New System.Drawing.Size(136, 20)
        Me.lblTItulo.TabIndex = 1
        Me.lblTItulo.Text = "Pieles y Colores"
        '
        'ptbTitulo
        '
        Me.ptbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.ptbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.ptbTitulo.Location = New System.Drawing.Point(157, 0)
        Me.ptbTitulo.Name = "ptbTitulo"
        Me.ptbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.ptbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ptbTitulo.TabIndex = 0
        Me.ptbTitulo.TabStop = False
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 432)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(384, 50)
        Me.pnlEstado.TabIndex = 1
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Controls.Add(Me.lblGuardar)
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Controls.Add(Me.btnGuardar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(184, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(200, 50)
        Me.pnlOperaciones.TabIndex = 2
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(154, 35)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(99, 35)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 2
        Me.lblGuardar.Text = "Guardar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(155, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 0
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(104, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(59, 24)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 2
        Me.lblCodigo.Text = "Código"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(29, 72)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(70, 13)
        Me.lblDescripcion.TabIndex = 3
        Me.lblDescripcion.Text = "* Descripción"
        '
        'lblNombreCorto
        '
        Me.lblNombreCorto.AutoSize = True
        Me.lblNombreCorto.Location = New System.Drawing.Point(20, 96)
        Me.lblNombreCorto.Name = "lblNombreCorto"
        Me.lblNombreCorto.Size = New System.Drawing.Size(79, 13)
        Me.lblNombreCorto.TabIndex = 4
        Me.lblNombreCorto.Text = "* Nombre Corto"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(115, 20)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(194, 20)
        Me.txtCodigo.TabIndex = 6
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(115, 68)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(194, 20)
        Me.txtDescripcion.TabIndex = 7
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(115, 92)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(194, 20)
        Me.txtNombre.TabIndex = 8
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Location = New System.Drawing.Point(115, 118)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivo.TabIndex = 9
        Me.rdoActivo.TabStop = True
        Me.rdoActivo.Text = "Si"
        Me.rdoActivo.UseVisualStyleBackColor = True
        '
        'rdoInactivo
        '
        Me.rdoInactivo.AutoSize = True
        Me.rdoInactivo.Location = New System.Drawing.Point(159, 118)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rdoInactivo.TabIndex = 10
        Me.rdoInactivo.TabStop = True
        Me.rdoInactivo.Text = "No"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'lblCodSicy
        '
        Me.lblCodSicy.AutoSize = True
        Me.lblCodSicy.Location = New System.Drawing.Point(32, 48)
        Me.lblCodSicy.Name = "lblCodSicy"
        Me.lblCodSicy.Size = New System.Drawing.Size(67, 13)
        Me.lblCodSicy.TabIndex = 11
        Me.lblCodSicy.Text = "Código SICY"
        '
        'txtCodSicy
        '
        Me.txtCodSicy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodSicy.Enabled = False
        Me.txtCodSicy.Location = New System.Drawing.Point(115, 44)
        Me.txtCodSicy.Name = "txtCodSicy"
        Me.txtCodSicy.Size = New System.Drawing.Size(194, 20)
        Me.txtCodSicy.TabIndex = 12
        '
        'gprDatos
        '
        Me.gprDatos.Controls.Add(Me.lblColores)
        Me.gprDatos.Controls.Add(Me.btnColores)
        Me.gprDatos.Controls.Add(Me.Label1)
        Me.gprDatos.Controls.Add(Me.txtCodSicy)
        Me.gprDatos.Controls.Add(Me.lblCodSicy)
        Me.gprDatos.Controls.Add(Me.txtCodigo)
        Me.gprDatos.Controls.Add(Me.lblCodigo)
        Me.gprDatos.Controls.Add(Me.lblDescripcion)
        Me.gprDatos.Controls.Add(Me.lblNombreCorto)
        Me.gprDatos.Controls.Add(Me.rdoInactivo)
        Me.gprDatos.Controls.Add(Me.txtDescripcion)
        Me.gprDatos.Controls.Add(Me.rdoActivo)
        Me.gprDatos.Controls.Add(Me.txtNombre)
        Me.gprDatos.Location = New System.Drawing.Point(22, 59)
        Me.gprDatos.Name = "gprDatos"
        Me.gprDatos.Size = New System.Drawing.Size(340, 184)
        Me.gprDatos.TabIndex = 14
        Me.gprDatos.TabStop = False
        '
        'lblColores
        '
        Me.lblColores.AutoSize = True
        Me.lblColores.Location = New System.Drawing.Point(219, 152)
        Me.lblColores.Name = "lblColores"
        Me.lblColores.Size = New System.Drawing.Size(52, 13)
        Me.lblColores.TabIndex = 15
        Me.lblColores.Text = "Alta Color"
        '
        'btnColores
        '
        Me.btnColores.Image = Global.Programacion.Vista.My.Resources.Resources.altas_32
        Me.btnColores.Location = New System.Drawing.Point(277, 142)
        Me.btnColores.Name = "btnColores"
        Me.btnColores.Size = New System.Drawing.Size(32, 32)
        Me.btnColores.TabIndex = 14
        Me.btnColores.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(62, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Activo"
        '
        'grdColores
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColores.DisplayLayout.Appearance = Appearance1
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColores.DisplayLayout.EmptyRowSettings.EmptyAreaAppearance = Appearance2
        Me.grdColores.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdColores.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdColores.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdColores.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdColores.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdColores.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColores.DisplayLayout.Override.RowAlternateAppearance = Appearance3
        Me.grdColores.Location = New System.Drawing.Point(2, 249)
        Me.grdColores.Name = "grdColores"
        Me.grdColores.Size = New System.Drawing.Size(381, 180)
        Me.grdColores.TabIndex = 15
        Me.grdColores.Text = "Colores"
        '
        'AltaPielesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(384, 482)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.grdColores)
        Me.Controls.Add(Me.gprDatos)
        Me.Controls.Add(Me.pnlEstado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AltaPielesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pieles y Colores"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.ptbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.gprDatos.ResumeLayout(False)
        Me.gprDatos.PerformLayout()
        CType(Me.grdColores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents ptbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTItulo As System.Windows.Forms.Label
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblNombreCorto As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblCodSicy As System.Windows.Forms.Label
    Friend WithEvents txtCodSicy As System.Windows.Forms.TextBox
    Friend WithEvents gprDatos As System.Windows.Forms.GroupBox
    Friend WithEvents grdColores As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblColores As System.Windows.Forms.Label
    Friend WithEvents btnColores As System.Windows.Forms.Button
End Class
