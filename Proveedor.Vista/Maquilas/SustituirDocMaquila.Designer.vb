<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SustituirDocMaquila
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SustituirDocMaquila))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtFolioNuevo = New System.Windows.Forms.TextBox()
        Me.lblImporteNuevo = New System.Windows.Forms.Label()
        Me.lblTipoNuevo = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblRazSocNueva = New System.Windows.Forms.Label()
        Me.lblFechaNueva = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblProvNuevo = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnPDF = New System.Windows.Forms.Button()
        Me.txtPDF = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnXML = New System.Windows.Forms.Button()
        Me.txtXML = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblImporteOri = New System.Windows.Forms.Label()
        Me.lblTipoOri = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblRazSocOri = New System.Windows.Forms.Label()
        Me.lblFechaOri = New System.Windows.Forms.Label()
        Me.lblFolioOri = New System.Windows.Forms.Label()
        Me.lblProvOri = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(530, 60)
        Me.pnlHeader.TabIndex = 76
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(41, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(489, 60)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(131, 25)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(284, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Remplazar Documento de Maquila"
        '
        'grbParametros
        '
        Me.grbParametros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Controls.Add(Me.GroupBox2)
        Me.grbParametros.Controls.Add(Me.GroupBox1)
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 59)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(530, 400)
        Me.grbParametros.TabIndex = 77
        Me.grbParametros.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txtFolioNuevo)
        Me.GroupBox2.Controls.Add(Me.lblImporteNuevo)
        Me.GroupBox2.Controls.Add(Me.lblTipoNuevo)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.lblRazSocNueva)
        Me.GroupBox2.Controls.Add(Me.lblFechaNueva)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.lblProvNuevo)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtMotivo)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.btnPDF)
        Me.GroupBox2.Controls.Add(Me.txtPDF)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.btnXML)
        Me.GroupBox2.Controls.Add(Me.txtXML)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 149)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(530, 244)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Documento Original"
        '
        'txtFolioNuevo
        '
        Me.txtFolioNuevo.Location = New System.Drawing.Point(90, 174)
        Me.txtFolioNuevo.Name = "txtFolioNuevo"
        Me.txtFolioNuevo.Size = New System.Drawing.Size(100, 20)
        Me.txtFolioNuevo.TabIndex = 30
        '
        'lblImporteNuevo
        '
        Me.lblImporteNuevo.AutoSize = True
        Me.lblImporteNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteNuevo.Location = New System.Drawing.Point(325, 198)
        Me.lblImporteNuevo.Name = "lblImporteNuevo"
        Me.lblImporteNuevo.Size = New System.Drawing.Size(47, 15)
        Me.lblImporteNuevo.TabIndex = 29
        Me.lblImporteNuevo.Text = "$ 0.00"
        '
        'lblTipoNuevo
        '
        Me.lblTipoNuevo.AutoSize = True
        Me.lblTipoNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoNuevo.Location = New System.Drawing.Point(325, 176)
        Me.lblTipoNuevo.Name = "lblTipoNuevo"
        Me.lblTipoNuevo.Size = New System.Drawing.Size(12, 15)
        Me.lblTipoNuevo.TabIndex = 28
        Me.lblTipoNuevo.Text = "-"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(277, 200)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(42, 13)
        Me.Label26.TabIndex = 27
        Me.Label26.Text = "Importe"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(291, 178)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(28, 13)
        Me.Label27.TabIndex = 26
        Me.Label27.Text = "Tipo"
        '
        'lblRazSocNueva
        '
        Me.lblRazSocNueva.AutoSize = True
        Me.lblRazSocNueva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazSocNueva.ForeColor = System.Drawing.Color.Teal
        Me.lblRazSocNueva.Location = New System.Drawing.Point(87, 220)
        Me.lblRazSocNueva.Name = "lblRazSocNueva"
        Me.lblRazSocNueva.Size = New System.Drawing.Size(12, 15)
        Me.lblRazSocNueva.TabIndex = 25
        Me.lblRazSocNueva.Text = "-"
        '
        'lblFechaNueva
        '
        Me.lblFechaNueva.AutoSize = True
        Me.lblFechaNueva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaNueva.ForeColor = System.Drawing.Color.Teal
        Me.lblFechaNueva.Location = New System.Drawing.Point(87, 198)
        Me.lblFechaNueva.Name = "lblFechaNueva"
        Me.lblFechaNueva.Size = New System.Drawing.Size(12, 15)
        Me.lblFechaNueva.TabIndex = 24
        Me.lblFechaNueva.Text = "-"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(14, 222)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 13)
        Me.Label18.TabIndex = 22
        Me.Label18.Text = "Razón Social"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(47, 200)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(37, 13)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "Fecha"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(55, 178)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(29, 13)
        Me.Label20.TabIndex = 20
        Me.Label20.Text = "Folio"
        '
        'lblProvNuevo
        '
        Me.lblProvNuevo.AutoSize = True
        Me.lblProvNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvNuevo.Location = New System.Drawing.Point(87, 152)
        Me.lblProvNuevo.Name = "lblProvNuevo"
        Me.lblProvNuevo.Size = New System.Drawing.Size(12, 15)
        Me.lblProvNuevo.TabIndex = 12
        Me.lblProvNuevo.Text = "-"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(28, 154)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 13)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Proveedor"
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(90, 81)
        Me.txtMotivo.MaxLength = 200
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(325, 68)
        Me.txtMotivo.TabIndex = 19
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(45, 84)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 13)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Motivo"
        '
        'btnPDF
        '
        Me.btnPDF.Location = New System.Drawing.Point(422, 50)
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Size = New System.Drawing.Size(34, 23)
        Me.btnPDF.TabIndex = 17
        Me.btnPDF.Text = "..."
        Me.btnPDF.UseVisualStyleBackColor = True
        '
        'txtPDF
        '
        Me.txtPDF.Location = New System.Drawing.Point(91, 52)
        Me.txtPDF.Name = "txtPDF"
        Me.txtPDF.ReadOnly = True
        Me.txtPDF.Size = New System.Drawing.Size(325, 20)
        Me.txtPDF.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(56, 55)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 13)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "PDF"
        '
        'btnXML
        '
        Me.btnXML.Location = New System.Drawing.Point(422, 21)
        Me.btnXML.Name = "btnXML"
        Me.btnXML.Size = New System.Drawing.Size(34, 23)
        Me.btnXML.TabIndex = 14
        Me.btnXML.Text = "..."
        Me.btnXML.UseVisualStyleBackColor = True
        '
        'txtXML
        '
        Me.txtXML.Location = New System.Drawing.Point(91, 23)
        Me.txtXML.Name = "txtXML"
        Me.txtXML.ReadOnly = True
        Me.txtXML.Size = New System.Drawing.Size(325, 20)
        Me.txtXML.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(55, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "XML"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblImporteOri)
        Me.GroupBox1.Controls.Add(Me.lblTipoOri)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblRazSocOri)
        Me.GroupBox1.Controls.Add(Me.lblFechaOri)
        Me.GroupBox1.Controls.Add(Me.lblFolioOri)
        Me.GroupBox1.Controls.Add(Me.lblProvOri)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(530, 124)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Documento Original"
        '
        'lblImporteOri
        '
        Me.lblImporteOri.AutoSize = True
        Me.lblImporteOri.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteOri.Location = New System.Drawing.Point(296, 75)
        Me.lblImporteOri.Name = "lblImporteOri"
        Me.lblImporteOri.Size = New System.Drawing.Size(12, 15)
        Me.lblImporteOri.TabIndex = 11
        Me.lblImporteOri.Text = "-"
        '
        'lblTipoOri
        '
        Me.lblTipoOri.AutoSize = True
        Me.lblTipoOri.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoOri.Location = New System.Drawing.Point(297, 46)
        Me.lblTipoOri.Name = "lblTipoOri"
        Me.lblTipoOri.Size = New System.Drawing.Size(12, 15)
        Me.lblTipoOri.TabIndex = 10
        Me.lblTipoOri.Text = "-"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(248, 77)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Importe"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(262, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Tipo"
        '
        'lblRazSocOri
        '
        Me.lblRazSocOri.AutoSize = True
        Me.lblRazSocOri.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazSocOri.Location = New System.Drawing.Point(108, 100)
        Me.lblRazSocOri.Name = "lblRazSocOri"
        Me.lblRazSocOri.Size = New System.Drawing.Size(12, 15)
        Me.lblRazSocOri.TabIndex = 7
        Me.lblRazSocOri.Text = "-"
        '
        'lblFechaOri
        '
        Me.lblFechaOri.AutoSize = True
        Me.lblFechaOri.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaOri.Location = New System.Drawing.Point(108, 75)
        Me.lblFechaOri.Name = "lblFechaOri"
        Me.lblFechaOri.Size = New System.Drawing.Size(12, 15)
        Me.lblFechaOri.TabIndex = 6
        Me.lblFechaOri.Text = "-"
        '
        'lblFolioOri
        '
        Me.lblFolioOri.AutoSize = True
        Me.lblFolioOri.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioOri.Location = New System.Drawing.Point(108, 48)
        Me.lblFolioOri.Name = "lblFolioOri"
        Me.lblFolioOri.Size = New System.Drawing.Size(12, 15)
        Me.lblFolioOri.TabIndex = 5
        Me.lblFolioOri.Text = "-"
        '
        'lblProvOri
        '
        Me.lblProvOri.AutoSize = True
        Me.lblProvOri.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvOri.Location = New System.Drawing.Point(108, 24)
        Me.lblProvOri.Name = "lblProvOri"
        Me.lblProvOri.Size = New System.Drawing.Size(12, 15)
        Me.lblProvOri.TabIndex = 4
        Me.lblProvOri.Text = "-"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Razón Social"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Folio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Proveedor"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnlBotones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 458)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(530, 60)
        Me.Panel1.TabIndex = 78
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.Button1)
        Me.pnlBotones.Controls.Add(Me.Label5)
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(319, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(211, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Image = Global.Proveedor.Vista.My.Resources.Resources.guardar2_32
        Me.Button1.Location = New System.Drawing.Point(131, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 4
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(126, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Guardar"
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(169, 7)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 0
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(170, 42)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(421, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 60)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'SustituirDocMaquila
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 518)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "SustituirDocMaquila"
        Me.Text = "Documento Maquila"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.grbParametros.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents bntSalir As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblImporteNuevo As System.Windows.Forms.Label
    Friend WithEvents lblTipoNuevo As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblRazSocNueva As System.Windows.Forms.Label
    Friend WithEvents lblFechaNueva As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblProvNuevo As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnPDF As System.Windows.Forms.Button
    Friend WithEvents txtPDF As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnXML As System.Windows.Forms.Button
    Friend WithEvents txtXML As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblImporteOri As System.Windows.Forms.Label
    Friend WithEvents lblTipoOri As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblRazSocOri As System.Windows.Forms.Label
    Friend WithEvents lblFechaOri As System.Windows.Forms.Label
    Friend WithEvents lblFolioOri As System.Windows.Forms.Label
    Friend WithEvents lblProvOri As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFolioNuevo As System.Windows.Forms.TextBox
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
