<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MovimientosPolizaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MovimientosPolizaForm))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.gboxContenido = New System.Windows.Forms.GroupBox()
        Me.gridListaMovimientosPoliza = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlContenedor.SuspendLayout()
        Me.gboxContenido.SuspendLayout()
        CType(Me.gridListaMovimientosPoliza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlListaPaises.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlContenedor.Size = New System.Drawing.Size(856, 493)
        Me.pnlContenedor.TabIndex = 6
        '
        'gboxContenido
        '
        Me.gboxContenido.Controls.Add(Me.gridListaMovimientosPoliza)
        Me.gboxContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxContenido.Location = New System.Drawing.Point(0, 60)
        Me.gboxContenido.Name = "gboxContenido"
        Me.gboxContenido.Size = New System.Drawing.Size(856, 433)
        Me.gboxContenido.TabIndex = 12
        Me.gboxContenido.TabStop = False
        '
        'gridListaMovimientosPoliza
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaMovimientosPoliza.DisplayLayout.Appearance = Appearance1
        Me.gridListaMovimientosPoliza.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridListaMovimientosPoliza.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaMovimientosPoliza.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaMovimientosPoliza.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaMovimientosPoliza.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaMovimientosPoliza.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaMovimientosPoliza.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListaMovimientosPoliza.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListaMovimientosPoliza.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaMovimientosPoliza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaMovimientosPoliza.Location = New System.Drawing.Point(3, 16)
        Me.gridListaMovimientosPoliza.Name = "gridListaMovimientosPoliza"
        Me.gridListaMovimientosPoliza.Size = New System.Drawing.Size(850, 414)
        Me.gridListaMovimientosPoliza.TabIndex = 1
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.imgLogo)
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(856, 60)
        Me.pnlListaPaises.TabIndex = 8
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
        Me.imgLogo.Location = New System.Drawing.Point(786, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 7
        Me.imgLogo.TabStop = False
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(579, 21)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(205, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Movimientos de la Póliza"
        '
        'MovimientosPolizaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 493)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "MovimientosPolizaForm"
        Me.Text = "Movimientos de la Póliza"
        Me.pnlContenedor.ResumeLayout(False)
        Me.gboxContenido.ResumeLayout(False)
        CType(Me.gridListaMovimientosPoliza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents gboxContenido As System.Windows.Forms.GroupBox
    Friend WithEvents gridListaMovimientosPoliza As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
End Class
