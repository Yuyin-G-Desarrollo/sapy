<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class grupoRapidoForm
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
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUP = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtNombreGrupo = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.grdGrupos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlHeader.SuspendLayout()
        CType(Me.grdGrupos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.lblGuardar)
        Me.pnlHeader.Controls.Add(Me.btnDown)
        Me.pnlHeader.Controls.Add(Me.btnUP)
        Me.pnlHeader.Controls.Add(Me.btnAgregar)
        Me.pnlHeader.Controls.Add(Me.txtNombreGrupo)
        Me.pnlHeader.Controls.Add(Me.lblNombre)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(241, 27)
        Me.pnlHeader.TabIndex = 1
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(191, 69)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 32
        Me.lblGuardar.Text = "Guardar"
        '
        'btnDown
        '
        Me.btnDown.Image = Global.Programacion.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnDown.Location = New System.Drawing.Point(214, 3)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(20, 20)
        Me.btnDown.TabIndex = 31
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnUP
        '
        Me.btnUP.Image = Global.Programacion.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnUP.Location = New System.Drawing.Point(185, 3)
        Me.btnUP.Name = "btnUP"
        Me.btnUP.Size = New System.Drawing.Size(20, 20)
        Me.btnUP.TabIndex = 30
        Me.btnUP.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnAgregar.Location = New System.Drawing.Point(197, 38)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(32, 32)
        Me.btnAgregar.TabIndex = 20
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtNombreGrupo
        '
        Me.txtNombreGrupo.Location = New System.Drawing.Point(15, 44)
        Me.txtNombreGrupo.Name = "txtNombreGrupo"
        Me.txtNombreGrupo.Size = New System.Drawing.Size(176, 20)
        Me.txtNombreGrupo.TabIndex = 19
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(12, 28)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 18
        Me.lblNombre.Text = "Nombre"
        '
        'grdGrupos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdGrupos.DisplayLayout.Appearance = Appearance1
        Me.grdGrupos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdGrupos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdGrupos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdGrupos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdGrupos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdGrupos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdGrupos.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdGrupos.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdGrupos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdGrupos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdGrupos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdGrupos.Location = New System.Drawing.Point(0, 27)
        Me.grdGrupos.Name = "grdGrupos"
        Me.grdGrupos.Size = New System.Drawing.Size(241, 231)
        Me.grdGrupos.TabIndex = 2
        '
        'grupoRapidoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(241, 258)
        Me.Controls.Add(Me.grdGrupos)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(257, 297)
        Me.MinimumSize = New System.Drawing.Size(257, 297)
        Me.Name = "grupoRapidoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Grupos"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.grdGrupos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtNombreGrupo As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnUP As System.Windows.Forms.Button
    Friend WithEvents grdGrupos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
End Class
