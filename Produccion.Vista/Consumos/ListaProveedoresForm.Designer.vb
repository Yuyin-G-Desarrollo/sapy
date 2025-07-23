<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaProveedoresForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaProveedoresForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdProveedores = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.grdProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInferior.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.grdProveedores)
        Me.Panel1.Location = New System.Drawing.Point(0, 69)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(534, 335)
        Me.Panel1.TabIndex = 2013
        '
        'grdProveedores
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProveedores.DisplayLayout.Appearance = Appearance1
        Me.grdProveedores.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProveedores.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdProveedores.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdProveedores.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdProveedores.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdProveedores.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProveedores.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdProveedores.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdProveedores.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdProveedores.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdProveedores.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProveedores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProveedores.Location = New System.Drawing.Point(0, 0)
        Me.grdProveedores.Name = "grdProveedores"
        Me.grdProveedores.Size = New System.Drawing.Size(534, 335)
        Me.grdProveedores.TabIndex = 2003
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.Button1)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 419)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(542, 54)
        Me.pnlInferior.TabIndex = 2012
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(493, 40)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 100
        Me.lblSalir.Text = "Cerrar"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.Button1.Location = New System.Drawing.Point(494, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 99
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.Label5)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(542, 63)
        Me.pnlEncabezado.TabIndex = 2011
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(-400, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(195, 16)
        Me.Label5.TabIndex = 232
        Me.Label5.Text = "VENTANA NO FUNCIONAL"
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(293, 25)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(178, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Lista de Proveedores"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(474, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'ListaProveedoresForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 473)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(550, 500)
        Me.MinimumSize = New System.Drawing.Size(550, 500)
        Me.Name = "ListaProveedoresForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Proveedores"
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdProveedores As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
End Class
