<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaZapateriasForm
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
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.gpbZapateria = New System.Windows.Forms.GroupBox()
        Me.chkClienteYuyin = New System.Windows.Forms.CheckBox()
        Me.txtNombreZapateria = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdZapaterias = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.gpbZapateria.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdZapaterias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.Color.White
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(582, 60)
        Me.pnlTitulo.TabIndex = 1
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(514, 0)
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
        Me.lblTitulo.Location = New System.Drawing.Point(192, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(318, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Catálogo de Zapaterías - Competencia"
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 428)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(582, 60)
        Me.pnlEstado.TabIndex = 11
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Controls.Add(Me.lblGuardar)
        Me.pnlOperaciones.Controls.Add(Me.btnCerrar)
        Me.pnlOperaciones.Controls.Add(Me.btnGuardar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(433, 0)
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
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(96, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.UseVisualStyleBackColor = True
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
        'pnlCabecera
        '
        Me.pnlCabecera.Controls.Add(Me.gpbZapateria)
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 59)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(582, 82)
        Me.pnlCabecera.TabIndex = 14
        '
        'gpbZapateria
        '
        Me.gpbZapateria.Controls.Add(Me.chkClienteYuyin)
        Me.gpbZapateria.Controls.Add(Me.txtNombreZapateria)
        Me.gpbZapateria.Location = New System.Drawing.Point(11, 27)
        Me.gpbZapateria.Name = "gpbZapateria"
        Me.gpbZapateria.Size = New System.Drawing.Size(564, 48)
        Me.gpbZapateria.TabIndex = 14
        Me.gpbZapateria.TabStop = False
        Me.gpbZapateria.Text = "Nueva Zapatería"
        '
        'chkClienteYuyin
        '
        Me.chkClienteYuyin.AutoSize = True
        Me.chkClienteYuyin.Location = New System.Drawing.Point(454, 21)
        Me.chkClienteYuyin.Name = "chkClienteYuyin"
        Me.chkClienteYuyin.Size = New System.Drawing.Size(107, 17)
        Me.chkClienteYuyin.TabIndex = 1
        Me.chkClienteYuyin.Text = "¿ Cliente Yuyín ?"
        Me.chkClienteYuyin.UseVisualStyleBackColor = True
        '
        'txtNombreZapateria
        '
        Me.txtNombreZapateria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreZapateria.Location = New System.Drawing.Point(12, 19)
        Me.txtNombreZapateria.Name = "txtNombreZapateria"
        Me.txtNombreZapateria.Size = New System.Drawing.Size(436, 20)
        Me.txtNombreZapateria.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdZapaterias)
        Me.Panel2.Location = New System.Drawing.Point(0, 140)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(582, 290)
        Me.Panel2.TabIndex = 15
        '
        'grdZapaterias
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdZapaterias.DisplayLayout.Appearance = Appearance1
        Me.grdZapaterias.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdZapaterias.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdZapaterias.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.grdZapaterias.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdZapaterias.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdZapaterias.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdZapaterias.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdZapaterias.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdZapaterias.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdZapaterias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdZapaterias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdZapaterias.Location = New System.Drawing.Point(0, 0)
        Me.grdZapaterias.Name = "grdZapaterias"
        Me.grdZapaterias.Size = New System.Drawing.Size(582, 290)
        Me.grdZapaterias.TabIndex = 7
        '
        'AltaZapateriasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(582, 488)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlCabecera)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlTitulo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AltaZapateriasForm"
        Me.Text = "Catálogo de Zapaterías - Competencia"
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.gpbZapateria.ResumeLayout(False)
        Me.gpbZapateria.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdZapaterias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents gpbZapateria As System.Windows.Forms.GroupBox
    Friend WithEvents chkClienteYuyin As System.Windows.Forms.CheckBox
    Friend WithEvents txtNombreZapateria As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grdZapaterias As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
