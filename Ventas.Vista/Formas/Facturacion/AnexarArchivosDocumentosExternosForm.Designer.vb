<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AnexarArchivosDocumentosExternosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AnexarArchivosDocumentosExternosForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblIdDocumento = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblClienteNombre = New System.Windows.Forms.Label()
        Me.btnExaminarXML = New System.Windows.Forms.Button()
        Me.txtArchivoXML = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExaminarPDF = New System.Windows.Forms.Button()
        Me.txtArchivoPDF = New System.Windows.Forms.TextBox()
        Me.lblNave = New System.Windows.Forms.Label()
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
        Me.Panel1.Controls.Add(Me.lblIdDocumento)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblClienteNombre)
        Me.Panel1.Controls.Add(Me.btnExaminarXML)
        Me.Panel1.Controls.Add(Me.txtArchivoXML)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnExaminarPDF)
        Me.Panel1.Controls.Add(Me.txtArchivoPDF)
        Me.Panel1.Controls.Add(Me.lblNave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 59)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(500, 153)
        Me.Panel1.TabIndex = 74
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.AutoSize = True
        Me.lblIdDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdDocumento.Location = New System.Drawing.Point(396, 16)
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(42, 13)
        Me.lblIdDocumento.TabIndex = 18
        Me.lblIdDocumento.Text = "99999"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(304, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "DOCUMENTO"
        '
        'lblClienteNombre
        '
        Me.lblClienteNombre.AutoSize = True
        Me.lblClienteNombre.Location = New System.Drawing.Point(66, 16)
        Me.lblClienteNombre.Name = "lblClienteNombre"
        Me.lblClienteNombre.Size = New System.Drawing.Size(52, 13)
        Me.lblClienteNombre.TabIndex = 16
        Me.lblClienteNombre.Text = "CLIENTE"
        '
        'btnExaminarXML
        '
        Me.btnExaminarXML.Location = New System.Drawing.Point(363, 102)
        Me.btnExaminarXML.Name = "btnExaminarXML"
        Me.btnExaminarXML.Size = New System.Drawing.Size(75, 23)
        Me.btnExaminarXML.TabIndex = 15
        Me.btnExaminarXML.Text = "Examinar"
        Me.btnExaminarXML.UseVisualStyleBackColor = True
        '
        'txtArchivoXML
        '
        Me.txtArchivoXML.Location = New System.Drawing.Point(91, 102)
        Me.txtArchivoXML.Name = "txtArchivoXML"
        Me.txtArchivoXML.ReadOnly = True
        Me.txtArchivoXML.Size = New System.Drawing.Size(266, 20)
        Me.txtArchivoXML.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "* XML"
        '
        'btnExaminarPDF
        '
        Me.btnExaminarPDF.Location = New System.Drawing.Point(363, 64)
        Me.btnExaminarPDF.Name = "btnExaminarPDF"
        Me.btnExaminarPDF.Size = New System.Drawing.Size(75, 23)
        Me.btnExaminarPDF.TabIndex = 12
        Me.btnExaminarPDF.Text = "Examinar"
        Me.btnExaminarPDF.UseVisualStyleBackColor = True
        '
        'txtArchivoPDF
        '
        Me.txtArchivoPDF.Location = New System.Drawing.Point(91, 67)
        Me.txtArchivoPDF.Name = "txtArchivoPDF"
        Me.txtArchivoPDF.ReadOnly = True
        Me.txtArchivoPDF.Size = New System.Drawing.Size(266, 20)
        Me.txtArchivoPDF.TabIndex = 11
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(50, 71)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(35, 13)
        Me.lblNave.TabIndex = 1
        Me.lblNave.Text = "* PDF"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 212)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(500, 60)
        Me.pnlPie.TabIndex = 73
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.Label3)
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(335, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(165, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(46, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 16
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(40, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Guardar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
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
        Me.lblCancelar.Location = New System.Drawing.Point(105, 41)
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
        Me.pnlListaPaises.Size = New System.Drawing.Size(500, 59)
        Me.pnlListaPaises.TabIndex = 72
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(119, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(381, 59)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(158, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(136, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Anexar archivos"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(313, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AnexarArchivosDocumentosExternosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(500, 272)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Name = "AnexarArchivosDocumentosExternosForm"
        Me.Text = "Anexar Archivos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    Friend WithEvents btnExaminarXML As Button
    Friend WithEvents txtArchivoXML As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExaminarPDF As Button
    Friend WithEvents txtArchivoPDF As TextBox
    Friend WithEvents lblNave As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents pnlListaPaises As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents lblIdDocumento As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblClienteNombre As Label
    Friend WithEvents ofdRutaArchivo As OpenFileDialog
    Friend WithEvents PictureBox1 As PictureBox
End Class
