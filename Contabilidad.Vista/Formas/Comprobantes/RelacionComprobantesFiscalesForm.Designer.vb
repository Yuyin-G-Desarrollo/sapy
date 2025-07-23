<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RelacionComprobantesFiscalesForm
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
        Me.gridRelacionarComprobantesFiscales = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnPdf = New System.Windows.Forms.Button()
        Me.btnXml = New System.Windows.Forms.Button()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.ofdComprobantesFiscales = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlContenedor.SuspendLayout()
        Me.gboxContenido.SuspendLayout()
        CType(Me.gridRelacionarComprobantesFiscales, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlContenedor.Size = New System.Drawing.Size(1260, 507)
        Me.pnlContenedor.TabIndex = 4
        '
        'gboxContenido
        '
        Me.gboxContenido.Controls.Add(Me.gridRelacionarComprobantesFiscales)
        Me.gboxContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxContenido.Location = New System.Drawing.Point(0, 60)
        Me.gboxContenido.Name = "gboxContenido"
        Me.gboxContenido.Size = New System.Drawing.Size(1260, 447)
        Me.gboxContenido.TabIndex = 12
        Me.gboxContenido.TabStop = False
        '
        'gridRelacionarComprobantesFiscales
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridRelacionarComprobantesFiscales.DisplayLayout.Appearance = Appearance1
        Me.gridRelacionarComprobantesFiscales.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridRelacionarComprobantesFiscales.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridRelacionarComprobantesFiscales.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridRelacionarComprobantesFiscales.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridRelacionarComprobantesFiscales.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridRelacionarComprobantesFiscales.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridRelacionarComprobantesFiscales.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridRelacionarComprobantesFiscales.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridRelacionarComprobantesFiscales.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridRelacionarComprobantesFiscales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridRelacionarComprobantesFiscales.Location = New System.Drawing.Point(3, 16)
        Me.gridRelacionarComprobantesFiscales.Name = "gridRelacionarComprobantesFiscales"
        Me.gridRelacionarComprobantesFiscales.Size = New System.Drawing.Size(1254, 428)
        Me.gridRelacionarComprobantesFiscales.TabIndex = 1
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.PictureBox1)
        Me.pnlListaPaises.Controls.Add(Me.Label1)
        Me.pnlListaPaises.Controls.Add(Me.lblMostrar)
        Me.pnlListaPaises.Controls.Add(Me.btnPdf)
        Me.pnlListaPaises.Controls.Add(Me.btnXml)
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1260, 60)
        Me.pnlListaPaises.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(16, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "XML"
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(76, 42)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(28, 13)
        Me.lblMostrar.TabIndex = 19
        Me.lblMostrar.Text = "PDF"
        '
        'btnPdf
        '
        Me.btnPdf.Image = Global.Contabilidad.Vista.My.Resources.Resources.pdf_32
        Me.btnPdf.Location = New System.Drawing.Point(75, 7)
        Me.btnPdf.Name = "btnPdf"
        Me.btnPdf.Size = New System.Drawing.Size(32, 32)
        Me.btnPdf.TabIndex = 9
        Me.btnPdf.UseVisualStyleBackColor = True
        '
        'btnXml
        '
        Me.btnXml.Image = Global.Contabilidad.Vista.My.Resources.Resources.xml_32
        Me.btnXml.Location = New System.Drawing.Point(13, 9)
        Me.btnXml.Name = "btnXml"
        Me.btnXml.Size = New System.Drawing.Size(32, 32)
        Me.btnXml.TabIndex = 8
        Me.btnXml.UseVisualStyleBackColor = True
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(900, 21)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(288, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Relacionar Comprobantes Fiscales"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(1188, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 38
        Me.PictureBox1.TabStop = False
        '
        'RelacionComprobantesFiscalesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1260, 507)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "RelacionComprobantesFiscalesForm"
        Me.Text = "Relacionar Comprobantes Fiscales"
        Me.pnlContenedor.ResumeLayout(False)
        Me.gboxContenido.ResumeLayout(False)
        CType(Me.gridRelacionarComprobantesFiscales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents gboxContenido As System.Windows.Forms.GroupBox
    Friend WithEvents gridRelacionarComprobantesFiscales As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents ofdComprobantesFiscales As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnXml As System.Windows.Forms.Button
    Friend WithEvents btnPdf As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
End Class
