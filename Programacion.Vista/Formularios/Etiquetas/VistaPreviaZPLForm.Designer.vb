<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VistaPreviaZPLForm
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
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.txtAncho = New System.Windows.Forms.TextBox()
        Me.txtAlto = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.pctb300dpi = New System.Windows.Forms.PictureBox()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.pcbt203dpi = New System.Windows.Forms.PictureBox()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.rdo300 = New System.Windows.Forms.RadioButton()
        Me.rdo203 = New System.Windows.Forms.RadioButton()
        Me.pctbVistaPrevia = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.pctb300dpi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.pcbt203dpi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.pctbVistaPrevia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(912, 47)
        Me.pnlListaPaises.TabIndex = 31
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(531, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(381, 47)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(191, 14)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(104, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Vista Previa"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 320)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(912, 66)
        Me.pnlPie.TabIndex = 68
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(747, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(165, 66)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(106, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 14
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(106, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.GroupControl3)
        Me.Panel1.Controls.Add(Me.GroupControl2)
        Me.Panel1.Controls.Add(Me.GroupControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(912, 273)
        Me.Panel1.TabIndex = 69
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtTipo)
        Me.Panel2.Controls.Add(Me.txtAncho)
        Me.Panel2.Controls.Add(Me.txtAlto)
        Me.Panel2.Controls.Add(Me.txtCliente)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(912, 36)
        Me.Panel2.TabIndex = 34
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(886, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "cm"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(754, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "cm"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(491, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Tipo;"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(788, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Ancho:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(672, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Alto:"
        '
        'txtTipo
        '
        Me.txtTipo.BackColor = System.Drawing.Color.AliceBlue
        Me.txtTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipo.Location = New System.Drawing.Point(528, 7)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.ReadOnly = True
        Me.txtTipo.Size = New System.Drawing.Size(138, 20)
        Me.txtTipo.TabIndex = 4
        '
        'txtAncho
        '
        Me.txtAncho.BackColor = System.Drawing.Color.AliceBlue
        Me.txtAncho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAncho.Location = New System.Drawing.Point(839, 8)
        Me.txtAncho.Name = "txtAncho"
        Me.txtAncho.ReadOnly = True
        Me.txtAncho.Size = New System.Drawing.Size(43, 20)
        Me.txtAncho.TabIndex = 3
        '
        'txtAlto
        '
        Me.txtAlto.BackColor = System.Drawing.Color.AliceBlue
        Me.txtAlto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAlto.Location = New System.Drawing.Point(706, 9)
        Me.txtAlto.Name = "txtAlto"
        Me.txtAlto.ReadOnly = True
        Me.txtAlto.Size = New System.Drawing.Size(46, 20)
        Me.txtAlto.TabIndex = 2
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente.Location = New System.Drawing.Point(62, 7)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(425, 20)
        Me.txtCliente.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente:"
        '
        'GroupControl3
        '
        Me.GroupControl3.AllowBorderColorBlending = True
        Me.GroupControl3.Controls.Add(Me.pctb300dpi)
        Me.GroupControl3.CustomHeaderButtons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Button", Global.Programacion.Vista.My.Resources.Resources.defaultprinter_16x16, -1, DevExpress.XtraEditors.ButtonPanel.ImageLocation.[Default], DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", True, -1, True, Nothing, True, False, False, Nothing, Nothing, -1)})
        Me.GroupControl3.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.GroupControl3.Location = New System.Drawing.Point(610, 42)
        Me.GroupControl3.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GroupControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(288, 219)
        Me.GroupControl3.TabIndex = 11
        Me.GroupControl3.Text = "300dpi"
        '
        'pctb300dpi
        '
        Me.pctb300dpi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pctb300dpi.Location = New System.Drawing.Point(2, 21)
        Me.pctb300dpi.Name = "pctb300dpi"
        Me.pctb300dpi.Size = New System.Drawing.Size(284, 196)
        Me.pctb300dpi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctb300dpi.TabIndex = 5
        Me.pctb300dpi.TabStop = False
        '
        'GroupControl2
        '
        Me.GroupControl2.AllowBorderColorBlending = True
        Me.GroupControl2.Controls.Add(Me.pcbt203dpi)
        Me.GroupControl2.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.GroupControl2.Location = New System.Drawing.Point(312, 42)
        Me.GroupControl2.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GroupControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(288, 219)
        Me.GroupControl2.TabIndex = 10
        Me.GroupControl2.Text = "203dpi"
        '
        'pcbt203dpi
        '
        Me.pcbt203dpi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pcbt203dpi.Location = New System.Drawing.Point(2, 21)
        Me.pcbt203dpi.Name = "pcbt203dpi"
        Me.pcbt203dpi.Size = New System.Drawing.Size(284, 196)
        Me.pcbt203dpi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbt203dpi.TabIndex = 4
        Me.pcbt203dpi.TabStop = False
        '
        'GroupControl1
        '
        Me.GroupControl1.AllowBorderColorBlending = True
        Me.GroupControl1.Controls.Add(Me.rdo300)
        Me.GroupControl1.Controls.Add(Me.rdo203)
        Me.GroupControl1.Controls.Add(Me.pctbVistaPrevia)
        Me.GroupControl1.CustomHeaderButtons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Imprimir", Global.Programacion.Vista.My.Resources.Resources.defaultprinter_16x16, True, True, "Imprime la etiqueta en la zebra configurada por default en el equipo")})
        Me.GroupControl1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.GroupControl1.Location = New System.Drawing.Point(12, 42)
        Me.GroupControl1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GroupControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(293, 219)
        Me.GroupControl1.TabIndex = 9
        Me.GroupControl1.Text = "Vista Previa"
        '
        'rdo300
        '
        Me.rdo300.AutoSize = True
        Me.rdo300.Location = New System.Drawing.Point(156, 4)
        Me.rdo300.Name = "rdo300"
        Me.rdo300.Size = New System.Drawing.Size(57, 17)
        Me.rdo300.TabIndex = 5
        Me.rdo300.Text = "300dpi"
        Me.rdo300.UseVisualStyleBackColor = True
        '
        'rdo203
        '
        Me.rdo203.AutoSize = True
        Me.rdo203.Checked = True
        Me.rdo203.Location = New System.Drawing.Point(93, 4)
        Me.rdo203.Name = "rdo203"
        Me.rdo203.Size = New System.Drawing.Size(57, 17)
        Me.rdo203.TabIndex = 4
        Me.rdo203.TabStop = True
        Me.rdo203.Text = "203dpi"
        Me.rdo203.UseVisualStyleBackColor = True
        '
        'pctbVistaPrevia
        '
        Me.pctbVistaPrevia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pctbVistaPrevia.Location = New System.Drawing.Point(2, 27)
        Me.pctbVistaPrevia.Name = "pctbVistaPrevia"
        Me.pctbVistaPrevia.Size = New System.Drawing.Size(289, 190)
        Me.pctbVistaPrevia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctbVistaPrevia.TabIndex = 3
        Me.pctbVistaPrevia.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(319, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 47)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'VistaPreviaZPLForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 386)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "VistaPreviaZPLForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vista Previa"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.pctb300dpi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.pcbt203dpi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.pctbVistaPrevia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pctb300dpi As System.Windows.Forms.PictureBox
    Friend WithEvents pctbVistaPrevia As System.Windows.Forms.PictureBox
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTipo As System.Windows.Forms.TextBox
    Friend WithEvents txtAncho As System.Windows.Forms.TextBox
    Friend WithEvents txtAlto As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents pcbt203dpi As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rdo300 As System.Windows.Forms.RadioButton
    Friend WithEvents rdo203 As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox1 As PictureBox
End Class
