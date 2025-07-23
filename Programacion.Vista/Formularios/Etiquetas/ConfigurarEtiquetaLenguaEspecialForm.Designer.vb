<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConfigurarEtiquetaLenguaEspecialForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbClientes = New System.Windows.Forms.ComboBox()
        Me.cmbColeccion = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtArchivolbl = New System.Windows.Forms.TextBox()
        Me.btnExaminar200 = New System.Windows.Forms.Button()
        Me.btnExaminarlbl = New System.Windows.Forms.Button()
        Me.cmbTipoEtiqueta = New System.Windows.Forms.ComboBox()
        Me.lblArchivolbl = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAncho = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblTextoImpresion203 = New System.Windows.Forms.Label()
        Me.cmbImpresionAlPaso = New System.Windows.Forms.ComboBox()
        Me.lblTextoImpresion300 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnExaminar300 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt200dpi = New System.Windows.Forms.TextBox()
        Me.rdoNo = New System.Windows.Forms.RadioButton()
        Me.txt300dpi = New System.Windows.Forms.TextBox()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.lblAncho = New System.Windows.Forms.Label()
        Me.txtAlto = New System.Windows.Forms.TextBox()
        Me.lblAlto = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.ofdRutaArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.lblCliente)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 59)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(640, 342)
        Me.Panel1.TabIndex = 72
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(95, 32)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(43, 13)
        Me.lblCliente.TabIndex = 26
        Me.lblCliente.Text = "*Cliente"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbClientes)
        Me.GroupBox1.Controls.Add(Me.cmbColeccion)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtArchivolbl)
        Me.GroupBox1.Controls.Add(Me.btnExaminar200)
        Me.GroupBox1.Controls.Add(Me.btnExaminarlbl)
        Me.GroupBox1.Controls.Add(Me.cmbTipoEtiqueta)
        Me.GroupBox1.Controls.Add(Me.lblArchivolbl)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtAncho)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.lblTextoImpresion203)
        Me.GroupBox1.Controls.Add(Me.cmbImpresionAlPaso)
        Me.GroupBox1.Controls.Add(Me.lblTextoImpresion300)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnExaminar300)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txt200dpi)
        Me.GroupBox1.Controls.Add(Me.rdoNo)
        Me.GroupBox1.Controls.Add(Me.txt300dpi)
        Me.GroupBox1.Controls.Add(Me.rdoSi)
        Me.GroupBox1.Controls.Add(Me.lblAncho)
        Me.GroupBox1.Controls.Add(Me.txtAlto)
        Me.GroupBox1.Controls.Add(Me.lblAlto)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(616, 316)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Etiqueta"
        '
        'cmbClientes
        '
        Me.cmbClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbClientes.FormattingEnabled = True
        Me.cmbClientes.Location = New System.Drawing.Point(129, 22)
        Me.cmbClientes.Name = "cmbClientes"
        Me.cmbClientes.Size = New System.Drawing.Size(386, 21)
        Me.cmbClientes.TabIndex = 33
        '
        'cmbColeccion
        '
        Me.cmbColeccion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbColeccion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbColeccion.FormattingEnabled = True
        Me.cmbColeccion.Location = New System.Drawing.Point(129, 49)
        Me.cmbColeccion.Name = "cmbColeccion"
        Me.cmbColeccion.Size = New System.Drawing.Size(386, 21)
        Me.cmbColeccion.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(68, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "*Colección"
        '
        'txtArchivolbl
        '
        Me.txtArchivolbl.Location = New System.Drawing.Point(129, 240)
        Me.txtArchivolbl.Name = "txtArchivolbl"
        Me.txtArchivolbl.ReadOnly = True
        Me.txtArchivolbl.Size = New System.Drawing.Size(386, 20)
        Me.txtArchivolbl.TabIndex = 11
        '
        'btnExaminar200
        '
        Me.btnExaminar200.Location = New System.Drawing.Point(521, 179)
        Me.btnExaminar200.Name = "btnExaminar200"
        Me.btnExaminar200.Size = New System.Drawing.Size(75, 23)
        Me.btnExaminar200.TabIndex = 8
        Me.btnExaminar200.Text = "Examinar"
        Me.btnExaminar200.UseVisualStyleBackColor = True
        '
        'btnExaminarlbl
        '
        Me.btnExaminarlbl.Location = New System.Drawing.Point(521, 239)
        Me.btnExaminarlbl.Name = "btnExaminarlbl"
        Me.btnExaminarlbl.Size = New System.Drawing.Size(75, 23)
        Me.btnExaminarlbl.TabIndex = 12
        Me.btnExaminarlbl.Text = "Examinar"
        Me.btnExaminarlbl.UseVisualStyleBackColor = True
        '
        'cmbTipoEtiqueta
        '
        Me.cmbTipoEtiqueta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoEtiqueta.Location = New System.Drawing.Point(129, 76)
        Me.cmbTipoEtiqueta.Name = "cmbTipoEtiqueta"
        Me.cmbTipoEtiqueta.Size = New System.Drawing.Size(232, 21)
        Me.cmbTipoEtiqueta.TabIndex = 2
        '
        'lblArchivolbl
        '
        Me.lblArchivolbl.AutoSize = True
        Me.lblArchivolbl.Location = New System.Drawing.Point(57, 244)
        Me.lblArchivolbl.Name = "lblArchivolbl"
        Me.lblArchivolbl.Size = New System.Drawing.Size(65, 13)
        Me.lblArchivolbl.TabIndex = 26
        Me.lblArchivolbl.Text = "Archivo LBL"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(48, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "*Tipo Etiqueta"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(191, 132)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(21, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "cm"
        '
        'txtAncho
        '
        Me.txtAncho.Location = New System.Drawing.Point(129, 103)
        Me.txtAncho.Name = "txtAncho"
        Me.txtAncho.Size = New System.Drawing.Size(56, 20)
        Me.txtAncho.TabIndex = 3
        Me.txtAncho.Text = "7.7"
        Me.txtAncho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(191, 107)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(21, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "cm"
        '
        'lblTextoImpresion203
        '
        Me.lblTextoImpresion203.AutoSize = True
        Me.lblTextoImpresion203.Location = New System.Drawing.Point(35, 185)
        Me.lblTextoImpresion203.Name = "lblTextoImpresion203"
        Me.lblTextoImpresion203.Size = New System.Drawing.Size(87, 13)
        Me.lblTextoImpresion203.TabIndex = 2
        Me.lblTextoImpresion203.Text = "Impresión 203dpi"
        '
        'cmbImpresionAlPaso
        '
        Me.cmbImpresionAlPaso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbImpresionAlPaso.FormattingEnabled = True
        Me.cmbImpresionAlPaso.Location = New System.Drawing.Point(129, 155)
        Me.cmbImpresionAlPaso.Name = "cmbImpresionAlPaso"
        Me.cmbImpresionAlPaso.Size = New System.Drawing.Size(117, 21)
        Me.cmbImpresionAlPaso.TabIndex = 6
        '
        'lblTextoImpresion300
        '
        Me.lblTextoImpresion300.AutoSize = True
        Me.lblTextoImpresion300.Location = New System.Drawing.Point(20, 215)
        Me.lblTextoImpresion300.Name = "lblTextoImpresion300"
        Me.lblTextoImpresion300.Size = New System.Drawing.Size(102, 13)
        Me.lblTextoImpresion300.TabIndex = 3
        Me.lblTextoImpresion300.Text = "Impresión en 300dpi"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 158)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "*No. Impresion al paso"
        '
        'btnExaminar300
        '
        Me.btnExaminar300.Location = New System.Drawing.Point(521, 210)
        Me.btnExaminar300.Name = "btnExaminar300"
        Me.btnExaminar300.Size = New System.Drawing.Size(75, 23)
        Me.btnExaminar300.TabIndex = 10
        Me.btnExaminar300.Text = "Examinar"
        Me.btnExaminar300.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(81, 272)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "*Activa"
        '
        'txt200dpi
        '
        Me.txt200dpi.Location = New System.Drawing.Point(129, 182)
        Me.txt200dpi.Name = "txt200dpi"
        Me.txt200dpi.ReadOnly = True
        Me.txt200dpi.Size = New System.Drawing.Size(386, 20)
        Me.txt200dpi.TabIndex = 7
        '
        'rdoNo
        '
        Me.rdoNo.AutoSize = True
        Me.rdoNo.Location = New System.Drawing.Point(167, 270)
        Me.rdoNo.Name = "rdoNo"
        Me.rdoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoNo.TabIndex = 14
        Me.rdoNo.Text = "No"
        Me.rdoNo.UseVisualStyleBackColor = True
        '
        'txt300dpi
        '
        Me.txt300dpi.Location = New System.Drawing.Point(129, 211)
        Me.txt300dpi.Name = "txt300dpi"
        Me.txt300dpi.ReadOnly = True
        Me.txt300dpi.Size = New System.Drawing.Size(386, 20)
        Me.txt300dpi.TabIndex = 9
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Checked = True
        Me.rdoSi.Location = New System.Drawing.Point(127, 270)
        Me.rdoSi.Name = "rdoSi"
        Me.rdoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoSi.TabIndex = 13
        Me.rdoSi.TabStop = True
        Me.rdoSi.Text = "Si"
        Me.rdoSi.UseVisualStyleBackColor = True
        '
        'lblAncho
        '
        Me.lblAncho.AutoSize = True
        Me.lblAncho.Location = New System.Drawing.Point(84, 107)
        Me.lblAncho.Name = "lblAncho"
        Me.lblAncho.Size = New System.Drawing.Size(38, 13)
        Me.lblAncho.TabIndex = 15
        Me.lblAncho.Text = "Ancho"
        '
        'txtAlto
        '
        Me.txtAlto.Location = New System.Drawing.Point(129, 129)
        Me.txtAlto.Name = "txtAlto"
        Me.txtAlto.Size = New System.Drawing.Size(56, 20)
        Me.txtAlto.TabIndex = 4
        Me.txtAlto.Text = "5.1"
        Me.txtAlto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAlto
        '
        Me.lblAlto.AutoSize = True
        Me.lblAlto.Location = New System.Drawing.Point(97, 133)
        Me.lblAlto.Name = "lblAlto"
        Me.lblAlto.Size = New System.Drawing.Size(25, 13)
        Me.lblAlto.TabIndex = 16
        Me.lblAlto.Text = "Alto"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 401)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(640, 60)
        Me.pnlPie.TabIndex = 71
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.Label3)
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(475, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(165, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(46, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 15
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(43, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Guardar"
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(106, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 16
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
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(640, 59)
        Me.pnlListaPaises.TabIndex = 70
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(24, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(616, 59)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(77, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(480, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Configurar Etiqueta Especial Lengua - Cliente - Coleección"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(554, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'ConfigurarEtiquetaLenguaEspecialForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 461)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Name = "ConfigurarEtiquetaLenguaEspecialForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configurar Etiqueta Especial Lengua - Cliente - Coleección"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblCliente As Label
    Friend WithEvents txtArchivolbl As TextBox
    Friend WithEvents btnExaminarlbl As Button
    Friend WithEvents lblArchivolbl As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbImpresionAlPaso As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents rdoNo As RadioButton
    Friend WithEvents rdoSi As RadioButton
    Friend WithEvents txtAlto As TextBox
    Friend WithEvents txtAncho As TextBox
    Friend WithEvents lblAlto As Label
    Friend WithEvents lblAncho As Label
    Friend WithEvents cmbTipoEtiqueta As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt300dpi As TextBox
    Friend WithEvents txt200dpi As TextBox
    Friend WithEvents btnExaminar300 As Button
    Friend WithEvents lblTextoImpresion300 As Label
    Friend WithEvents lblTextoImpresion203 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnExaminar200 As Button
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents pnlListaPaises As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents cmbClientes As ComboBox
    Friend WithEvents cmbColeccion As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ofdRutaArchivo As OpenFileDialog
    Friend WithEvents PictureBox1 As PictureBox
End Class
