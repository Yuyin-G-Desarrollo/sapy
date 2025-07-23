<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FamiliaFormRapido
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtNombreFamilia = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.grdListaFamilias = New System.Windows.Forms.DataGridView()
        Me.btnFamilia = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.pnlHeader.SuspendLayout()
        CType(Me.grdListaFamilias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.btnFiltrar)
        Me.pnlHeader.Controls.Add(Me.txtDescripcion)
        Me.pnlHeader.Controls.Add(Me.btnNuevo)
        Me.pnlHeader.Controls.Add(Me.btnAgregar)
        Me.pnlHeader.Controls.Add(Me.txtNombreFamilia)
        Me.pnlHeader.Controls.Add(Me.lblNombre)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(351, 61)
        Me.pnlHeader.TabIndex = 2
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnFiltrar.Location = New System.Drawing.Point(267, 16)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrar.TabIndex = 21
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(94, 23)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(167, 20)
        Me.txtDescripcion.TabIndex = 20
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Programacion.Vista.My.Resources.Resources.altas_32
        Me.btnNuevo.Location = New System.Drawing.Point(3, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(32, 32)
        Me.btnNuevo.TabIndex = 18
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.Programacion.Vista.My.Resources.Resources.altas_32
        Me.btnAgregar.Location = New System.Drawing.Point(267, 16)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(32, 32)
        Me.btnAgregar.TabIndex = 17
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtNombreFamilia
        '
        Me.txtNombreFamilia.Location = New System.Drawing.Point(94, 24)
        Me.txtNombreFamilia.Name = "txtNombreFamilia"
        Me.txtNombreFamilia.Size = New System.Drawing.Size(167, 20)
        Me.txtNombreFamilia.TabIndex = 1
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(46, 26)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = "Nombre"
        '
        'grdListaFamilias
        '
        Me.grdListaFamilias.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaFamilias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdListaFamilias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnFamilia})
        Me.grdListaFamilias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaFamilias.Location = New System.Drawing.Point(0, 61)
        Me.grdListaFamilias.Name = "grdListaFamilias"
        Me.grdListaFamilias.Size = New System.Drawing.Size(351, 287)
        Me.grdListaFamilias.TabIndex = 3
        '
        'btnFamilia
        '
        Me.btnFamilia.HeaderText = ""
        Me.btnFamilia.Name = "btnFamilia"
        Me.btnFamilia.Width = 30
        '
        'FamiliaFormRapido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(351, 348)
        Me.Controls.Add(Me.grdListaFamilias)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(367, 387)
        Me.MinimumSize = New System.Drawing.Size(367, 387)
        Me.Name = "FamiliaFormRapido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Familias"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.grdListaFamilias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtNombreFamilia As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents grdListaFamilias As System.Windows.Forms.DataGridView
    Friend WithEvents btnFamilia As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
End Class
