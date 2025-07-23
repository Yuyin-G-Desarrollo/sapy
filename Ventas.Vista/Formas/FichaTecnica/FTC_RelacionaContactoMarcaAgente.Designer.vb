<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FTC_RelacionaContactoMarcaAgente
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
        Me.gpbContenedor = New System.Windows.Forms.GroupBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblContacto = New System.Windows.Forms.Label()
        Me.txtContacto = New System.Windows.Forms.TextBox()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.gpbAgentedeVentas = New System.Windows.Forms.GroupBox()
        Me.cmbAgentesVentas = New System.Windows.Forms.ComboBox()
        Me.gpbMarcas = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdContactoMarcaAgente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.chkMarcas = New System.Windows.Forms.CheckBox()
        Me.gpbContenedor.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbAgentedeVentas.SuspendLayout()
        Me.gpbMarcas.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdContactoMarcaAgente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpbContenedor
        '
        Me.gpbContenedor.Controls.Add(Me.txtEmail)
        Me.gpbContenedor.Controls.Add(Me.lblEmail)
        Me.gpbContenedor.Controls.Add(Me.lblContacto)
        Me.gpbContenedor.Controls.Add(Me.txtContacto)
        Me.gpbContenedor.Location = New System.Drawing.Point(11, 60)
        Me.gpbContenedor.Name = "gpbContenedor"
        Me.gpbContenedor.Size = New System.Drawing.Size(304, 75)
        Me.gpbContenedor.TabIndex = 11
        Me.gpbContenedor.TabStop = False
        '
        'txtEmail
        '
        Me.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmail.ForeColor = System.Drawing.Color.Black
        Me.txtEmail.Location = New System.Drawing.Point(76, 44)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(204, 20)
        Me.txtEmail.TabIndex = 14
        Me.txtEmail.Text = "SAMSAROQ@HOTMAIL.COM"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(21, 44)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(32, 13)
        Me.lblEmail.TabIndex = 13
        Me.lblEmail.Text = "Email"
        '
        'lblContacto
        '
        Me.lblContacto.AutoSize = True
        Me.lblContacto.Location = New System.Drawing.Point(20, 18)
        Me.lblContacto.Name = "lblContacto"
        Me.lblContacto.Size = New System.Drawing.Size(50, 13)
        Me.lblContacto.TabIndex = 3
        Me.lblContacto.Text = "Contacto"
        '
        'txtContacto
        '
        Me.txtContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContacto.ForeColor = System.Drawing.Color.Black
        Me.txtContacto.Location = New System.Drawing.Point(76, 15)
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.Size = New System.Drawing.Size(204, 20)
        Me.txtContacto.TabIndex = 5
        Me.txtContacto.Text = "CONTACTO GENERAL"
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 371)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(324, 60)
        Me.pnlEstado.TabIndex = 10
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Controls.Add(Me.lblGuardar)
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Controls.Add(Me.btnGuardar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(175, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(149, 60)
        Me.pnlOperaciones.TabIndex = 0
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(95, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(32, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 4
        Me.lblGuardar.Text = "Guardar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(96, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(38, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(324, 60)
        Me.pnlHeader.TabIndex = 9
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(-98, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(422, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(351, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 2
        Me.pcbTitulo.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(129, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(221, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Contacto - Marca - Agente"
        '
        'gpbAgentedeVentas
        '
        Me.gpbAgentedeVentas.Controls.Add(Me.cmbAgentesVentas)
        Me.gpbAgentedeVentas.Location = New System.Drawing.Point(11, 135)
        Me.gpbAgentedeVentas.Name = "gpbAgentedeVentas"
        Me.gpbAgentedeVentas.Size = New System.Drawing.Size(304, 45)
        Me.gpbAgentedeVentas.TabIndex = 12
        Me.gpbAgentedeVentas.TabStop = False
        Me.gpbAgentedeVentas.Text = "Seleccionar agente de ventas"
        '
        'cmbAgentesVentas
        '
        Me.cmbAgentesVentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAgentesVentas.FormattingEnabled = True
        Me.cmbAgentesVentas.Location = New System.Drawing.Point(21, 18)
        Me.cmbAgentesVentas.Name = "cmbAgentesVentas"
        Me.cmbAgentesVentas.Size = New System.Drawing.Size(257, 21)
        Me.cmbAgentesVentas.TabIndex = 13
        '
        'gpbMarcas
        '
        Me.gpbMarcas.Controls.Add(Me.Panel1)
        Me.gpbMarcas.Controls.Add(Me.chkMarcas)
        Me.gpbMarcas.Location = New System.Drawing.Point(13, 187)
        Me.gpbMarcas.Name = "gpbMarcas"
        Me.gpbMarcas.Size = New System.Drawing.Size(302, 176)
        Me.gpbMarcas.TabIndex = 13
        Me.gpbMarcas.TabStop = False
        Me.gpbMarcas.Text = "Marcas"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdContactoMarcaAgente)
        Me.Panel1.Location = New System.Drawing.Point(6, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(290, 128)
        Me.Panel1.TabIndex = 1
        '
        'grdContactoMarcaAgente
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdContactoMarcaAgente.DisplayLayout.Appearance = Appearance1
        Me.grdContactoMarcaAgente.DisplayLayout.GroupByBox.Hidden = True
        Me.grdContactoMarcaAgente.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.grdContactoMarcaAgente.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdContactoMarcaAgente.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdContactoMarcaAgente.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdContactoMarcaAgente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdContactoMarcaAgente.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdContactoMarcaAgente.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdContactoMarcaAgente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdContactoMarcaAgente.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdContactoMarcaAgente.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdContactoMarcaAgente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdContactoMarcaAgente.Location = New System.Drawing.Point(0, 0)
        Me.grdContactoMarcaAgente.Name = "grdContactoMarcaAgente"
        Me.grdContactoMarcaAgente.Size = New System.Drawing.Size(290, 128)
        Me.grdContactoMarcaAgente.TabIndex = 9
        '
        'chkMarcas
        '
        Me.chkMarcas.AutoSize = True
        Me.chkMarcas.Checked = True
        Me.chkMarcas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMarcas.Location = New System.Drawing.Point(6, 19)
        Me.chkMarcas.Name = "chkMarcas"
        Me.chkMarcas.Size = New System.Drawing.Size(106, 17)
        Me.chkMarcas.TabIndex = 0
        Me.chkMarcas.Text = "Seleccionar todo"
        Me.chkMarcas.UseVisualStyleBackColor = True
        '
        'FTC_RelacionaContactoMarcaAgente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(324, 431)
        Me.Controls.Add(Me.gpbMarcas)
        Me.Controls.Add(Me.gpbAgentedeVentas)
        Me.Controls.Add(Me.gpbContenedor)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(340, 470)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(340, 470)
        Me.Name = "FTC_RelacionaContactoMarcaAgente"
        Me.Text = "Contacto - Marca - Agente"
        Me.gpbContenedor.ResumeLayout(False)
        Me.gpbContenedor.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbAgentedeVentas.ResumeLayout(False)
        Me.gpbMarcas.ResumeLayout(False)
        Me.gpbMarcas.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdContactoMarcaAgente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpbContenedor As System.Windows.Forms.GroupBox
    Friend WithEvents lblContacto As System.Windows.Forms.Label
    Friend WithEvents txtContacto As System.Windows.Forms.TextBox
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents gpbAgentedeVentas As System.Windows.Forms.GroupBox
    Friend WithEvents cmbAgentesVentas As System.Windows.Forms.ComboBox
    Friend WithEvents gpbMarcas As System.Windows.Forms.GroupBox
    Friend WithEvents chkMarcas As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdContactoMarcaAgente As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
