<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReemplazarXMLDañadosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReemplazarXMLDañadosForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnXml = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.gboxContenido = New System.Windows.Forms.GroupBox()
        Me.grdComprobantesFiscales = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.ofdComprobantesFiscales = New System.Windows.Forms.OpenFileDialog()
        Me.pnlListaPaises.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxContenido.SuspendLayout()
        CType(Me.grdComprobantesFiscales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAcciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.Panel2)
        Me.pnlListaPaises.Controls.Add(Me.Label1)
        Me.pnlListaPaises.Controls.Add(Me.btnXml)
        Me.pnlListaPaises.Controls.Add(Me.imgLogo)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(776, 60)
        Me.pnlListaPaises.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(401, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(305, 60)
        Me.Panel2.TabIndex = 22
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblEncabezado)
        Me.Panel1.Location = New System.Drawing.Point(51, 21)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(254, 34)
        Me.Panel1.TabIndex = 21
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(28, 0)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(223, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Reemplazar XML Dañados"
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
        'btnXml
        '
        Me.btnXml.Image = Global.Contabilidad.Vista.My.Resources.Resources.xml_32
        Me.btnXml.Location = New System.Drawing.Point(13, 9)
        Me.btnXml.Name = "btnXml"
        Me.btnXml.Size = New System.Drawing.Size(32, 32)
        Me.btnXml.TabIndex = 8
        Me.btnXml.UseVisualStyleBackColor = True
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
        Me.imgLogo.Location = New System.Drawing.Point(706, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 7
        Me.imgLogo.TabStop = False
        '
        'gboxContenido
        '
        Me.gboxContenido.Controls.Add(Me.grdComprobantesFiscales)
        Me.gboxContenido.Controls.Add(Me.pnlAcciones)
        Me.gboxContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxContenido.Location = New System.Drawing.Point(0, 60)
        Me.gboxContenido.Name = "gboxContenido"
        Me.gboxContenido.Size = New System.Drawing.Size(776, 401)
        Me.gboxContenido.TabIndex = 13
        Me.gboxContenido.TabStop = False
        '
        'grdComprobantesFiscales
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdComprobantesFiscales.DisplayLayout.Appearance = Appearance1
        Me.grdComprobantesFiscales.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdComprobantesFiscales.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdComprobantesFiscales.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdComprobantesFiscales.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdComprobantesFiscales.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdComprobantesFiscales.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdComprobantesFiscales.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdComprobantesFiscales.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdComprobantesFiscales.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdComprobantesFiscales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdComprobantesFiscales.Location = New System.Drawing.Point(3, 16)
        Me.grdComprobantesFiscales.Name = "grdComprobantesFiscales"
        Me.grdComprobantesFiscales.Size = New System.Drawing.Size(770, 321)
        Me.grdComprobantesFiscales.TabIndex = 1
        '
        'pnlAcciones
        '
        Me.pnlAcciones.BackColor = System.Drawing.Color.White
        Me.pnlAcciones.Controls.Add(Me.lblLimpiar)
        Me.pnlAcciones.Controls.Add(Me.btnSalir)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAcciones.Location = New System.Drawing.Point(3, 337)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(770, 61)
        Me.pnlAcciones.TabIndex = 26
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(719, 41)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(35, 13)
        Me.lblLimpiar.TabIndex = 24
        Me.lblLimpiar.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(720, 6)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'ReemplazarXMLDañadosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(776, 461)
        Me.Controls.Add(Me.gboxContenido)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ReemplazarXMLDañadosForm"
        Me.Text = "Reemplazar XML Dañados"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxContenido.ResumeLayout(False)
        CType(Me.grdComprobantesFiscales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnXml As System.Windows.Forms.Button
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gboxContenido As System.Windows.Forms.GroupBox
    Friend WithEvents grdComprobantesFiscales As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ofdComprobantesFiscales As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
End Class
