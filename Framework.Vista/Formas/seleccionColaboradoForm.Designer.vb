<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class seleccionColaboradoForm
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
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.ptbTitulo = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdDatosColaborador = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.ptbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatosColaborador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(449, 60)
        Me.pnlHeader.TabIndex = 1
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.ptbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(254, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(195, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(9, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(126, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Colaboradores"
        '
        'ptbTitulo
        '
        Me.ptbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.ptbTitulo.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.logoYuyin2
        Me.ptbTitulo.Location = New System.Drawing.Point(135, 0)
        Me.ptbTitulo.Name = "ptbTitulo"
        Me.ptbTitulo.Size = New System.Drawing.Size(60, 60)
        Me.ptbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ptbTitulo.TabIndex = 0
        Me.ptbTitulo.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 394)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(449, 60)
        Me.Panel1.TabIndex = 4
        '
        'grdDatosColaborador
        '
        Me.grdDatosColaborador.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdDatosColaborador.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdDatosColaborador.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdDatosColaborador.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdDatosColaborador.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdDatosColaborador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatosColaborador.Location = New System.Drawing.Point(0, 60)
        Me.grdDatosColaborador.Name = "grdDatosColaborador"
        Me.grdDatosColaborador.Size = New System.Drawing.Size(449, 334)
        Me.grdDatosColaborador.TabIndex = 6
        Me.grdDatosColaborador.Text = "Colaboradores"
        '
        'seleccionColaboradoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(449, 454)
        Me.Controls.Add(Me.grdDatosColaborador)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Name = "seleccionColaboradoForm"
        Me.Text = "Colaboradores"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.ptbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatosColaborador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents ptbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdDatosColaborador As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
