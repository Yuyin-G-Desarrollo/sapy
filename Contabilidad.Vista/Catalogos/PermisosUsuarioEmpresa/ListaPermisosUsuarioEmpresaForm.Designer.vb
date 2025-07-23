<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaPermisosUsuarioEmpresaForm
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
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.gboxContenido = New System.Windows.Forms.GroupBox()
        Me.gridListaUsuarios = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlContenedor.SuspendLayout()
        Me.gboxContenido.SuspendLayout()
        CType(Me.gridListaUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlListaPaises.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.gboxContenido)
        Me.pnlContenedor.Controls.Add(Me.pnlListaPaises)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(570, 507)
        Me.pnlContenedor.TabIndex = 3
        '
        'gboxContenido
        '
        Me.gboxContenido.Controls.Add(Me.gridListaUsuarios)
        Me.gboxContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxContenido.Location = New System.Drawing.Point(0, 60)
        Me.gboxContenido.Name = "gboxContenido"
        Me.gboxContenido.Size = New System.Drawing.Size(570, 447)
        Me.gboxContenido.TabIndex = 12
        Me.gboxContenido.TabStop = False
        '
        'gridListaUsuarios
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaUsuarios.DisplayLayout.Appearance = Appearance1
        Me.gridListaUsuarios.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridListaUsuarios.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaUsuarios.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaUsuarios.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaUsuarios.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaUsuarios.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaUsuarios.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListaUsuarios.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListaUsuarios.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaUsuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaUsuarios.Location = New System.Drawing.Point(3, 16)
        Me.gridListaUsuarios.Name = "gridListaUsuarios"
        Me.gridListaUsuarios.Size = New System.Drawing.Size(564, 428)
        Me.gridListaUsuarios.TabIndex = 1
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.PictureBox1)
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(570, 60)
        Me.pnlListaPaises.TabIndex = 8
        '
        'lblEncabezado
        '
        Me.lblEncabezado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(262, 21)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(236, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Permisos Usuario - Empresa"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(498, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 38
        Me.PictureBox1.TabStop = False
        '
        'ListaPermisosUsuarioEmpresaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 507)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ListaPermisosUsuarioEmpresaForm"
        Me.pnlContenedor.ResumeLayout(False)
        Me.gboxContenido.ResumeLayout(False)
        CType(Me.gridListaUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents gboxContenido As System.Windows.Forms.GroupBox
    Friend WithEvents gridListaUsuarios As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
End Class
