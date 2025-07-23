<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListaClientesPosibleCopia
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListaClientesPosibleCopia))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.lblEstatusCont = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblContClientes = New System.Windows.Forms.Label()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.lblClientesCopiadosCont = New System.Windows.Forms.Label()
        Me.lblClientesCopiados = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnCambiarEstatus = New System.Windows.Forms.Button()
        Me.lblCambiarEstatus = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.tbtClientesPosibles = New System.Windows.Forms.TabControl()
        Me.tabClientes = New System.Windows.Forms.TabPage()
        Me.grdClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkSeleccionarFiltrados = New System.Windows.Forms.CheckBox()
        Me.tabClientesNoCopia = New System.Windows.Forms.TabPage()
        Me.grdClientesNoCopia = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.dttVigenciaInicio = New System.Windows.Forms.DateTimePicker()
        Me.dttVigenciaFin = New System.Windows.Forms.DateTimePicker()
        Me.txtNumArts = New System.Windows.Forms.TextBox()
        Me.txtUsuarioModifico = New System.Windows.Forms.TextBox()
        Me.txtListaVentasCliente = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtFechaModifico = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.tbtClientesPosibles.SuspendLayout()
        Me.tabClientes.SuspendLayout()
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.tabClientesNoCopia.SuspendLayout()
        CType(Me.grdClientesNoCopia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDatos.SuspendLayout()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(994, 60)
        Me.pnlHeader.TabIndex = 4
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pctTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(586, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(408, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(4, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(335, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Copiar Lista de Precios a Varios Clientes"
        '
        'pctTitulo
        '
        Me.pctTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pctTitulo.Location = New System.Drawing.Point(340, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pctTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pctTitulo.TabIndex = 0
        Me.pctTitulo.TabStop = False
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.lblEstatusCont)
        Me.pnlEstado.Controls.Add(Me.Label18)
        Me.pnlEstado.Controls.Add(Me.Label1)
        Me.pnlEstado.Controls.Add(Me.Label16)
        Me.pnlEstado.Controls.Add(Me.lblContClientes)
        Me.pnlEstado.Controls.Add(Me.lblClientes)
        Me.pnlEstado.Controls.Add(Me.lblClientesCopiadosCont)
        Me.pnlEstado.Controls.Add(Me.lblClientesCopiados)
        Me.pnlEstado.Controls.Add(Me.Label4)
        Me.pnlEstado.Controls.Add(Me.Label7)
        Me.pnlEstado.Controls.Add(Me.Label6)
        Me.pnlEstado.Controls.Add(Me.Label3)
        Me.pnlEstado.Controls.Add(Me.Label5)
        Me.pnlEstado.Controls.Add(Me.Label2)
        Me.pnlEstado.Controls.Add(Me.Label28)
        Me.pnlEstado.Controls.Add(Me.Label29)
        Me.pnlEstado.Controls.Add(Me.Label30)
        Me.pnlEstado.Controls.Add(Me.Label31)
        Me.pnlEstado.Controls.Add(Me.Label32)
        Me.pnlEstado.Controls.Add(Me.Label33)
        Me.pnlEstado.Controls.Add(Me.pnlBotones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 544)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(994, 60)
        Me.pnlEstado.TabIndex = 7
        '
        'lblEstatusCont
        '
        Me.lblEstatusCont.AutoSize = True
        Me.lblEstatusCont.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatusCont.ForeColor = System.Drawing.Color.Black
        Me.lblEstatusCont.Location = New System.Drawing.Point(130, 34)
        Me.lblEstatusCont.Name = "lblEstatusCont"
        Me.lblEstatusCont.Size = New System.Drawing.Size(25, 25)
        Me.lblEstatusCont.TabIndex = 78
        Me.lblEstatusCont.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(108, 1)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 32)
        Me.Label18.TabIndex = 79
        Me.Label18.Text = "Clientes " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Estatus"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(323, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Copia Anterior"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.RoyalBlue
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(306, 35)
        Me.Label16.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label16.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(15, 15)
        Me.Label16.TabIndex = 76
        '
        'lblContClientes
        '
        Me.lblContClientes.AutoSize = True
        Me.lblContClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContClientes.ForeColor = System.Drawing.Color.Black
        Me.lblContClientes.Location = New System.Drawing.Point(34, 34)
        Me.lblContClientes.Name = "lblContClientes"
        Me.lblContClientes.Size = New System.Drawing.Size(25, 25)
        Me.lblContClientes.TabIndex = 74
        Me.lblContClientes.Text = "0"
        '
        'lblClientes
        '
        Me.lblClientes.AutoSize = True
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.ForeColor = System.Drawing.Color.Black
        Me.lblClientes.Location = New System.Drawing.Point(12, 1)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(68, 32)
        Me.lblClientes.TabIndex = 75
        Me.lblClientes.Text = "Clientes " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Copiar"
        Me.lblClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblClientesCopiadosCont
        '
        Me.lblClientesCopiadosCont.AutoSize = True
        Me.lblClientesCopiadosCont.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientesCopiadosCont.Location = New System.Drawing.Point(711, 4)
        Me.lblClientesCopiadosCont.Name = "lblClientesCopiadosCont"
        Me.lblClientesCopiadosCont.Size = New System.Drawing.Size(26, 16)
        Me.lblClientesCopiadosCont.TabIndex = 73
        Me.lblClientesCopiadosCont.Text = "0/0"
        '
        'lblClientesCopiados
        '
        Me.lblClientesCopiados.AutoSize = True
        Me.lblClientesCopiados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientesCopiados.Location = New System.Drawing.Point(575, 4)
        Me.lblClientesCopiados.Name = "lblClientesCopiados"
        Me.lblClientesCopiados.Size = New System.Drawing.Size(118, 16)
        Me.lblClientesCopiados.TabIndex = 72
        Me.lblClientesCopiados.Text = "Clientes Copiados"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(407, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "DA?"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(448, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(249, 13)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "- Calcular Lista de Precios con Descuento Aplicado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(448, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "- % Descuento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(407, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "% D"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(448, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 13)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "- % Incremento Por Par"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(407, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "% IXP"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(323, 16)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(57, 13)
        Me.Label28.TabIndex = 67
        Me.Label28.Text = "Terminada"
        '
        'Label29
        '
        Me.Label29.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Gold
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(211, 35)
        Me.Label29.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label29.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(15, 15)
        Me.Label29.TabIndex = 66
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(228, 16)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(55, 13)
        Me.Label30.TabIndex = 64
        Me.Label30.Text = "Pendiente"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(228, 36)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(71, 13)
        Me.Label31.TabIndex = 65
        Me.Label31.Text = "En Proceso..."
        '
        'Label32
        '
        Me.Label32.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.LimeGreen
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(306, 15)
        Me.Label32.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label32.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(15, 15)
        Me.Label32.TabIndex = 62
        '
        'Label33
        '
        Me.Label33.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Red
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(211, 15)
        Me.Label33.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label33.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(15, 15)
        Me.Label33.TabIndex = 63
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnCambiarEstatus)
        Me.pnlBotones.Controls.Add(Me.lblCambiarEstatus)
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.btnGuardar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(811, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(183, 60)
        Me.pnlBotones.TabIndex = 4
        '
        'btnCambiarEstatus
        '
        Me.btnCambiarEstatus.Enabled = False
        Me.btnCambiarEstatus.Image = Global.Ventas.Vista.My.Resources.Resources.status
        Me.btnCambiarEstatus.Location = New System.Drawing.Point(76, 2)
        Me.btnCambiarEstatus.Name = "btnCambiarEstatus"
        Me.btnCambiarEstatus.Size = New System.Drawing.Size(32, 32)
        Me.btnCambiarEstatus.TabIndex = 20
        Me.btnCambiarEstatus.UseVisualStyleBackColor = True
        '
        'lblCambiarEstatus
        '
        Me.lblCambiarEstatus.AutoSize = True
        Me.lblCambiarEstatus.Enabled = False
        Me.lblCambiarEstatus.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCambiarEstatus.Location = New System.Drawing.Point(60, 33)
        Me.lblCambiarEstatus.Name = "lblCambiarEstatus"
        Me.lblCambiarEstatus.Size = New System.Drawing.Size(64, 26)
        Me.lblCambiarEstatus.TabIndex = 19
        Me.lblCambiarEstatus.Text = "Cambiar a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ACEPTADA"
        Me.lblCambiarEstatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(126, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(20, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 17
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(125, 35)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Enabled = False
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(14, 33)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 26)
        Me.lblGuardar.TabIndex = 1
        Me.lblGuardar.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Copias"
        Me.lblGuardar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tbtClientesPosibles
        '
        Me.tbtClientesPosibles.Controls.Add(Me.tabClientes)
        Me.tbtClientesPosibles.Controls.Add(Me.tabClientesNoCopia)
        Me.tbtClientesPosibles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbtClientesPosibles.Location = New System.Drawing.Point(0, 170)
        Me.tbtClientesPosibles.Name = "tbtClientesPosibles"
        Me.tbtClientesPosibles.SelectedIndex = 0
        Me.tbtClientesPosibles.Size = New System.Drawing.Size(994, 374)
        Me.tbtClientesPosibles.TabIndex = 8
        '
        'tabClientes
        '
        Me.tabClientes.BackColor = System.Drawing.Color.AliceBlue
        Me.tabClientes.Controls.Add(Me.grdClientes)
        Me.tabClientes.Controls.Add(Me.Panel1)
        Me.tabClientes.Location = New System.Drawing.Point(4, 22)
        Me.tabClientes.Name = "tabClientes"
        Me.tabClientes.Padding = New System.Windows.Forms.Padding(3)
        Me.tabClientes.Size = New System.Drawing.Size(986, 348)
        Me.tabClientes.TabIndex = 0
        Me.tabClientes.Text = "Clientes para copiar"
        '
        'grdClientes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientes.DisplayLayout.Appearance = Appearance1
        Me.grdClientes.DisplayLayout.GroupByBox.Hidden = True
        Me.grdClientes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClientes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdClientes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdClientes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClientes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientes.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdClientes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClientes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClientes.Location = New System.Drawing.Point(3, 33)
        Me.grdClientes.Name = "grdClientes"
        Me.grdClientes.Size = New System.Drawing.Size(980, 312)
        Me.grdClientes.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.chkSeleccionarFiltrados)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(980, 30)
        Me.Panel1.TabIndex = 10
        '
        'chkSeleccionarFiltrados
        '
        Me.chkSeleccionarFiltrados.AutoSize = True
        Me.chkSeleccionarFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSeleccionarFiltrados.Location = New System.Drawing.Point(6, 7)
        Me.chkSeleccionarFiltrados.Name = "chkSeleccionarFiltrados"
        Me.chkSeleccionarFiltrados.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarFiltrados.TabIndex = 87
        Me.chkSeleccionarFiltrados.Text = "Seleccionar Todo"
        Me.chkSeleccionarFiltrados.UseVisualStyleBackColor = True
        '
        'tabClientesNoCopia
        '
        Me.tabClientesNoCopia.BackColor = System.Drawing.Color.AliceBlue
        Me.tabClientesNoCopia.Controls.Add(Me.grdClientesNoCopia)
        Me.tabClientesNoCopia.Controls.Add(Me.Panel2)
        Me.tabClientesNoCopia.Location = New System.Drawing.Point(4, 22)
        Me.tabClientesNoCopia.Name = "tabClientesNoCopia"
        Me.tabClientesNoCopia.Padding = New System.Windows.Forms.Padding(3)
        Me.tabClientesNoCopia.Size = New System.Drawing.Size(976, 331)
        Me.tabClientesNoCopia.TabIndex = 1
        Me.tabClientesNoCopia.Text = "Clientes que NO se pueden copiar"
        '
        'grdClientesNoCopia
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientesNoCopia.DisplayLayout.Appearance = Appearance3
        Me.grdClientesNoCopia.DisplayLayout.GroupByBox.Hidden = True
        Me.grdClientesNoCopia.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClientesNoCopia.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdClientesNoCopia.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdClientesNoCopia.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClientesNoCopia.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientesNoCopia.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdClientesNoCopia.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClientesNoCopia.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdClientesNoCopia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClientesNoCopia.Location = New System.Drawing.Point(3, 33)
        Me.grdClientesNoCopia.Name = "grdClientesNoCopia"
        Me.grdClientesNoCopia.Size = New System.Drawing.Size(970, 295)
        Me.grdClientesNoCopia.TabIndex = 10
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(970, 30)
        Me.Panel2.TabIndex = 11
        '
        'grpDatos
        '
        Me.grpDatos.Controls.Add(Me.lblEstatus)
        Me.grpDatos.Controls.Add(Me.UltraPanel1)
        Me.grpDatos.Controls.Add(Me.dttVigenciaInicio)
        Me.grpDatos.Controls.Add(Me.dttVigenciaFin)
        Me.grpDatos.Controls.Add(Me.txtNumArts)
        Me.grpDatos.Controls.Add(Me.txtUsuarioModifico)
        Me.grpDatos.Controls.Add(Me.txtListaVentasCliente)
        Me.grpDatos.Controls.Add(Me.txtCliente)
        Me.grpDatos.Controls.Add(Me.txtFechaModifico)
        Me.grpDatos.Controls.Add(Me.Label14)
        Me.grpDatos.Controls.Add(Me.Label13)
        Me.grpDatos.Controls.Add(Me.Label12)
        Me.grpDatos.Controls.Add(Me.Label11)
        Me.grpDatos.Controls.Add(Me.Label10)
        Me.grpDatos.Controls.Add(Me.Label9)
        Me.grpDatos.Controls.Add(Me.Label15)
        Me.grpDatos.Controls.Add(Me.Label8)
        Me.grpDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpDatos.Location = New System.Drawing.Point(0, 60)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(994, 110)
        Me.grpDatos.TabIndex = 9
        Me.grpDatos.TabStop = False
        Me.grpDatos.Text = "Lista de Precios Original"
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Location = New System.Drawing.Point(811, 68)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(77, 13)
        Me.lblEstatus.TabIndex = 101
        Me.lblEstatus.Text = "AUTORIZADA"
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.btnArriba)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.btnAbajo)
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.UltraPanel1.Location = New System.Drawing.Point(937, 16)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(54, 91)
        Me.UltraPanel1.TabIndex = 100
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(3, 1)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 68
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(31, 1)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 69
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'dttVigenciaInicio
        '
        Me.dttVigenciaInicio.Enabled = False
        Me.dttVigenciaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dttVigenciaInicio.Location = New System.Drawing.Point(130, 86)
        Me.dttVigenciaInicio.Name = "dttVigenciaInicio"
        Me.dttVigenciaInicio.Size = New System.Drawing.Size(85, 20)
        Me.dttVigenciaInicio.TabIndex = 13
        '
        'dttVigenciaFin
        '
        Me.dttVigenciaFin.Enabled = False
        Me.dttVigenciaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dttVigenciaFin.Location = New System.Drawing.Point(284, 86)
        Me.dttVigenciaFin.Name = "dttVigenciaFin"
        Me.dttVigenciaFin.Size = New System.Drawing.Size(85, 20)
        Me.dttVigenciaFin.TabIndex = 12
        '
        'txtNumArts
        '
        Me.txtNumArts.Enabled = False
        Me.txtNumArts.Location = New System.Drawing.Point(706, 64)
        Me.txtNumArts.Name = "txtNumArts"
        Me.txtNumArts.Size = New System.Drawing.Size(100, 20)
        Me.txtNumArts.TabIndex = 11
        Me.txtNumArts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUsuarioModifico
        '
        Me.txtUsuarioModifico.Enabled = False
        Me.txtUsuarioModifico.Location = New System.Drawing.Point(706, 86)
        Me.txtUsuarioModifico.Name = "txtUsuarioModifico"
        Me.txtUsuarioModifico.Size = New System.Drawing.Size(100, 20)
        Me.txtUsuarioModifico.TabIndex = 10
        '
        'txtListaVentasCliente
        '
        Me.txtListaVentasCliente.Enabled = False
        Me.txtListaVentasCliente.Location = New System.Drawing.Point(86, 64)
        Me.txtListaVentasCliente.Name = "txtListaVentasCliente"
        Me.txtListaVentasCliente.Size = New System.Drawing.Size(541, 20)
        Me.txtListaVentasCliente.TabIndex = 9
        '
        'txtCliente
        '
        Me.txtCliente.Enabled = False
        Me.txtCliente.Location = New System.Drawing.Point(86, 42)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(406, 20)
        Me.txtCliente.TabIndex = 8
        '
        'txtFechaModifico
        '
        Me.txtFechaModifico.Enabled = False
        Me.txtFechaModifico.Location = New System.Drawing.Point(477, 86)
        Me.txtFechaModifico.Name = "txtFechaModifico"
        Me.txtFechaModifico.Size = New System.Drawing.Size(150, 20)
        Me.txtFechaModifico.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(18, 90)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Vigencia"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(641, 90)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Usuario"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(83, 90)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Inicio"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(18, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Cliente"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Lista"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(252, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(21, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Fin"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(414, 90)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Modificado"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(641, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "# Artículos"
        '
        'frmListaClientesPosibleCopia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(994, 604)
        Me.Controls.Add(Me.tbtClientesPosibles)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.grpDatos)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(1000, 626)
        Me.MinimumSize = New System.Drawing.Size(1000, 626)
        Me.Name = "frmListaClientesPosibleCopia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copiar Lista de Precios a Varios Clientes"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.tbtClientesPosibles.ResumeLayout(False)
        Me.tabClientes.ResumeLayout(False)
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tabClientesNoCopia.ResumeLayout(False)
        CType(Me.grdClientesNoCopia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pctTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbtClientesPosibles As System.Windows.Forms.TabControl
    Friend WithEvents tabClientesNoCopia As System.Windows.Forms.TabPage
    Friend WithEvents tabClientes As System.Windows.Forms.TabPage
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents grdClientes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblClientesCopiados As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dttVigenciaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dttVigenciaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNumArts As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuarioModifico As System.Windows.Forms.TextBox
    Friend WithEvents txtListaVentasCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaModifico As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents grdClientesNoCopia As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents chkSeleccionarFiltrados As System.Windows.Forms.CheckBox
    Friend WithEvents lblContClientes As System.Windows.Forms.Label
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents btnCambiarEstatus As System.Windows.Forms.Button
    Friend WithEvents lblCambiarEstatus As System.Windows.Forms.Label
    Friend WithEvents lblClientesCopiadosCont As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblEstatusCont As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
End Class
