<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DevolucionCliente_MovimientosInventario_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DevolucionCliente_MovimientosInventario_Form))
        Me.grdConsultaLotes = New DevExpress.XtraGrid.GridControl()
        Me.bgvConsultaLotes = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCantidadCorrectos = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblCantidadConError = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblCantidadPares = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCantidadAtados = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCantidadLotes = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.pnlBtnGuardar = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlBtnCerrar = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblPares = New System.Windows.Forms.Label()
        Me.lblEtiquetaPares = New System.Windows.Forms.Label()
        Me.lblDestino = New System.Windows.Forms.Label()
        Me.lblEtiquetaDestino = New System.Windows.Forms.Label()
        Me.lblFolioDev = New System.Windows.Forms.Label()
        Me.lblEtiquetaFolioDev = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbMovimiento = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRestricciones = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlBtnMostrarDocumentos = New System.Windows.Forms.Panel()
        Me.btnMostrarOcultarErroneos = New System.Windows.Forms.Button()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.pnlBtnLimpiar = New System.Windows.Forms.Panel()
        Me.btnLimpiarCodigos = New System.Windows.Forms.Button()
        Me.lblBtnLimpiar = New System.Windows.Forms.Label()
        Me.pnlBtnExportarErroneos = New System.Windows.Forms.Panel()
        Me.btnExportarErroneos = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnPnlExportarCorrectos = New System.Windows.Forms.Panel()
        Me.btnExportarCorrectos = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.pnlBtnLeerArchivo = New System.Windows.Forms.Panel()
        Me.btnLeerArchivo = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.pnlBtnDetener = New System.Windows.Forms.Panel()
        Me.btnDetenerLectura = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlBtnIniciar = New System.Windows.Forms.Panel()
        Me.btnIniciarLectura = New System.Windows.Forms.Button()
        Me.lblCargarArchivo = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.spltContenedorGridCodigos = New System.Windows.Forms.SplitContainer()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.pnlTituloGridCorrectos = New System.Windows.Forms.Panel()
        Me.lblTituloCorrectos = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.grdCodigosErroneos = New DevExpress.XtraGrid.GridControl()
        Me.bgvCodigosErroneos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlTituloGridIncorrectos = New System.Windows.Forms.Panel()
        Me.chkMostrarColumnas = New System.Windows.Forms.CheckBox()
        Me.lblTituloConError = New System.Windows.Forms.Label()
        Me.ofdAbrirDat = New System.Windows.Forms.OpenFileDialog()
        Me.pgrsPnlCargando = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.pnlRestricciones = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        CType(Me.grdConsultaLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvConsultaLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlBtnGuardar.SuspendLayout()
        Me.pnlBtnCerrar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlBtnMostrarDocumentos.SuspendLayout()
        Me.pnlBtnLimpiar.SuspendLayout()
        Me.pnlBtnExportarErroneos.SuspendLayout()
        Me.btnPnlExportarCorrectos.SuspendLayout()
        Me.pnlBtnLeerArchivo.SuspendLayout()
        Me.pnlBtnDetener.SuspendLayout()
        Me.pnlBtnIniciar.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spltContenedorGridCodigos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spltContenedorGridCodigos.Panel1.SuspendLayout()
        Me.spltContenedorGridCodigos.Panel2.SuspendLayout()
        Me.spltContenedorGridCodigos.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.pnlTituloGridCorrectos.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.grdCodigosErroneos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvCodigosErroneos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTituloGridIncorrectos.SuspendLayout()
        Me.pnlRestricciones.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdConsultaLotes
        '
        Me.grdConsultaLotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdConsultaLotes.Location = New System.Drawing.Point(0, 0)
        Me.grdConsultaLotes.MainView = Me.bgvConsultaLotes
        Me.grdConsultaLotes.Name = "grdConsultaLotes"
        Me.grdConsultaLotes.Size = New System.Drawing.Size(849, 319)
        Me.grdConsultaLotes.TabIndex = 39
        Me.grdConsultaLotes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvConsultaLotes})
        '
        'bgvConsultaLotes
        '
        Me.bgvConsultaLotes.GridControl = Me.grdConsultaLotes
        Me.bgvConsultaLotes.Name = "bgvConsultaLotes"
        Me.bgvConsultaLotes.OptionsView.ShowAutoFilterRow = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.pnlDatosBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 474)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1284, 60)
        Me.Panel2.TabIndex = 38
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Label8)
        Me.Panel7.Controls.Add(Me.lblCantidadCorrectos)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(803, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(184, 60)
        Me.Panel7.TabIndex = 222
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(184, 37)
        Me.Label8.TabIndex = 213
        Me.Label8.Text = "Pares" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "correctos"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCantidadCorrectos
        '
        Me.lblCantidadCorrectos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblCantidadCorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadCorrectos.ForeColor = System.Drawing.Color.Green
        Me.lblCantidadCorrectos.Location = New System.Drawing.Point(0, 42)
        Me.lblCantidadCorrectos.Name = "lblCantidadCorrectos"
        Me.lblCantidadCorrectos.Size = New System.Drawing.Size(184, 18)
        Me.lblCantidadCorrectos.TabIndex = 212
        Me.lblCantidadCorrectos.Text = "0"
        Me.lblCantidadCorrectos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label14)
        Me.Panel6.Controls.Add(Me.lblCantidadConError)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(987, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(168, 60)
        Me.Panel6.TabIndex = 221
        '
        'Label14
        '
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(0, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(168, 38)
        Me.Label14.TabIndex = 216
        Me.Label14.Text = "Pares" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "con error"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCantidadConError
        '
        Me.lblCantidadConError.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblCantidadConError.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadConError.ForeColor = System.Drawing.Color.Red
        Me.lblCantidadConError.Location = New System.Drawing.Point(0, 42)
        Me.lblCantidadConError.Name = "lblCantidadConError"
        Me.lblCantidadConError.Size = New System.Drawing.Size(168, 18)
        Me.lblCantidadConError.TabIndex = 215
        Me.lblCantidadConError.Text = "0"
        Me.lblCantidadConError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.lblCantidadPares)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(150, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(73, 60)
        Me.Panel5.TabIndex = 220
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(3, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 18)
        Me.Label6.TabIndex = 211
        Me.Label6.Text = "Pares"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCantidadPares
        '
        Me.lblCantidadPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadPares.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblCantidadPares.Location = New System.Drawing.Point(4, 32)
        Me.lblCantidadPares.Name = "lblCantidadPares"
        Me.lblCantidadPares.Size = New System.Drawing.Size(66, 18)
        Me.lblCantidadPares.TabIndex = 210
        Me.lblCantidadPares.Text = "0"
        Me.lblCantidadPares.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.lblCantidadAtados)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(72, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(78, 60)
        Me.Panel4.TabIndex = 219
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 18)
        Me.Label4.TabIndex = 209
        Me.Label4.Text = "Atados"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCantidadAtados
        '
        Me.lblCantidadAtados.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadAtados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblCantidadAtados.Location = New System.Drawing.Point(7, 32)
        Me.lblCantidadAtados.Name = "lblCantidadAtados"
        Me.lblCantidadAtados.Size = New System.Drawing.Size(66, 18)
        Me.lblCantidadAtados.TabIndex = 208
        Me.lblCantidadAtados.Text = "0"
        Me.lblCantidadAtados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.lblCantidadLotes)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(72, 60)
        Me.Panel3.TabIndex = 218
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 18)
        Me.Label1.TabIndex = 207
        Me.Label1.Text = "Lotes"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCantidadLotes
        '
        Me.lblCantidadLotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadLotes.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblCantidadLotes.Location = New System.Drawing.Point(4, 32)
        Me.lblCantidadLotes.Name = "lblCantidadLotes"
        Me.lblCantidadLotes.Size = New System.Drawing.Size(66, 18)
        Me.lblCantidadLotes.TabIndex = 206
        Me.lblCantidadLotes.Text = "0"
        Me.lblCantidadLotes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.pnlBtnGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.pnlBtnCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1155, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(129, 60)
        Me.pnlDatosBotones.TabIndex = 3
        '
        'pnlBtnGuardar
        '
        Me.pnlBtnGuardar.Controls.Add(Me.btnGuardar)
        Me.pnlBtnGuardar.Controls.Add(Me.Label2)
        Me.pnlBtnGuardar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBtnGuardar.Location = New System.Drawing.Point(1, 0)
        Me.pnlBtnGuardar.Name = "pnlBtnGuardar"
        Me.pnlBtnGuardar.Size = New System.Drawing.Size(64, 60)
        Me.pnlBtnGuardar.TabIndex = 56
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Image = Global.Almacen.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(18, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 50
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(13, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Guardar"
        '
        'pnlBtnCerrar
        '
        Me.pnlBtnCerrar.Controls.Add(Me.btnCerrar)
        Me.pnlBtnCerrar.Controls.Add(Me.lblCerrar)
        Me.pnlBtnCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBtnCerrar.Location = New System.Drawing.Point(65, 0)
        Me.pnlBtnCerrar.Name = "pnlBtnCerrar"
        Me.pnlBtnCerrar.Size = New System.Drawing.Size(64, 60)
        Me.pnlBtnCerrar.TabIndex = 55
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(18, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(17, 41)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.lblPares)
        Me.Panel1.Controls.Add(Me.lblEtiquetaPares)
        Me.Panel1.Controls.Add(Me.lblDestino)
        Me.Panel1.Controls.Add(Me.lblEtiquetaDestino)
        Me.Panel1.Controls.Add(Me.lblFolioDev)
        Me.Panel1.Controls.Add(Me.lblEtiquetaFolioDev)
        Me.Panel1.Controls.Add(Me.txtCodigo)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.cmbMovimiento)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1284, 32)
        Me.Panel1.TabIndex = 37
        '
        'lblPares
        '
        Me.lblPares.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPares.AutoSize = True
        Me.lblPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPares.Location = New System.Drawing.Point(1238, 8)
        Me.lblPares.Name = "lblPares"
        Me.lblPares.Size = New System.Drawing.Size(40, 16)
        Me.lblPares.TabIndex = 60
        Me.lblPares.Text = "9999"
        '
        'lblEtiquetaPares
        '
        Me.lblEtiquetaPares.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEtiquetaPares.AutoSize = True
        Me.lblEtiquetaPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaPares.Location = New System.Drawing.Point(1181, 8)
        Me.lblEtiquetaPares.Name = "lblEtiquetaPares"
        Me.lblEtiquetaPares.Size = New System.Drawing.Size(53, 16)
        Me.lblEtiquetaPares.TabIndex = 59
        Me.lblEtiquetaPares.Text = "Pares:"
        '
        'lblDestino
        '
        Me.lblDestino.AutoSize = True
        Me.lblDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDestino.Location = New System.Drawing.Point(974, 8)
        Me.lblDestino.Name = "lblDestino"
        Me.lblDestino.Size = New System.Drawing.Size(12, 15)
        Me.lblDestino.TabIndex = 58
        Me.lblDestino.Text = "-"
        '
        'lblEtiquetaDestino
        '
        Me.lblEtiquetaDestino.AutoSize = True
        Me.lblEtiquetaDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaDestino.Location = New System.Drawing.Point(905, 8)
        Me.lblEtiquetaDestino.Name = "lblEtiquetaDestino"
        Me.lblEtiquetaDestino.Size = New System.Drawing.Size(65, 16)
        Me.lblEtiquetaDestino.TabIndex = 57
        Me.lblEtiquetaDestino.Text = "Destino:"
        '
        'lblFolioDev
        '
        Me.lblFolioDev.AutoSize = True
        Me.lblFolioDev.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioDev.Location = New System.Drawing.Point(819, 8)
        Me.lblFolioDev.Name = "lblFolioDev"
        Me.lblFolioDev.Size = New System.Drawing.Size(13, 16)
        Me.lblFolioDev.TabIndex = 56
        Me.lblFolioDev.Text = "-"
        '
        'lblEtiquetaFolioDev
        '
        Me.lblEtiquetaFolioDev.AutoSize = True
        Me.lblEtiquetaFolioDev.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaFolioDev.Location = New System.Drawing.Point(662, 8)
        Me.lblEtiquetaFolioDev.Name = "lblEtiquetaFolioDev"
        Me.lblEtiquetaFolioDev.Size = New System.Drawing.Size(151, 16)
        Me.lblEtiquetaFolioDev.TabIndex = 55
        Me.lblEtiquetaFolioDev.Text = "Folio de Devolución:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(111, 6)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(196, 20)
        Me.txtCodigo.TabIndex = 52
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(7, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 13)
        Me.Label18.TabIndex = 51
        Me.Label18.Text = "Código Par / Atado"
        '
        'cmbMovimiento
        '
        Me.cmbMovimiento.FormattingEnabled = True
        Me.cmbMovimiento.Items.AddRange(New Object() {"Pasar de Producción a Disponible", "Pasar de Producción a Bloqueado", "Pasar de Bloqueado a Disponible", "Pasar de Disponible a Bloqueado"})
        Me.cmbMovimiento.Location = New System.Drawing.Point(400, 5)
        Me.cmbMovimiento.Name = "cmbMovimiento"
        Me.cmbMovimiento.Size = New System.Drawing.Size(247, 21)
        Me.cmbMovimiento.TabIndex = 50
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(330, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "*Movimiento"
        '
        'txtRestricciones
        '
        Me.txtRestricciones.Enabled = False
        Me.txtRestricciones.Location = New System.Drawing.Point(111, 5)
        Me.txtRestricciones.Name = "txtRestricciones"
        Me.txtRestricciones.ReadOnly = True
        Me.txtRestricciones.Size = New System.Drawing.Size(1113, 20)
        Me.txtRestricciones.TabIndex = 54
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Restricciones"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlBtnMostrarDocumentos)
        Me.pnlEncabezado.Controls.Add(Me.pnlBtnLimpiar)
        Me.pnlEncabezado.Controls.Add(Me.pnlBtnExportarErroneos)
        Me.pnlEncabezado.Controls.Add(Me.btnPnlExportarCorrectos)
        Me.pnlEncabezado.Controls.Add(Me.pnlBtnLeerArchivo)
        Me.pnlEncabezado.Controls.Add(Me.pnlBtnDetener)
        Me.pnlEncabezado.Controls.Add(Me.pnlBtnIniciar)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1284, 65)
        Me.pnlEncabezado.TabIndex = 36
        '
        'pnlBtnMostrarDocumentos
        '
        Me.pnlBtnMostrarDocumentos.Controls.Add(Me.btnMostrarOcultarErroneos)
        Me.pnlBtnMostrarDocumentos.Controls.Add(Me.Label72)
        Me.pnlBtnMostrarDocumentos.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtnMostrarDocumentos.Location = New System.Drawing.Point(342, 0)
        Me.pnlBtnMostrarDocumentos.Name = "pnlBtnMostrarDocumentos"
        Me.pnlBtnMostrarDocumentos.Size = New System.Drawing.Size(98, 65)
        Me.pnlBtnMostrarDocumentos.TabIndex = 261
        '
        'btnMostrarOcultarErroneos
        '
        Me.btnMostrarOcultarErroneos.Image = CType(resources.GetObject("btnMostrarOcultarErroneos.Image"), System.Drawing.Image)
        Me.btnMostrarOcultarErroneos.Location = New System.Drawing.Point(34, 3)
        Me.btnMostrarOcultarErroneos.Name = "btnMostrarOcultarErroneos"
        Me.btnMostrarOcultarErroneos.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrarOcultarErroneos.TabIndex = 251
        Me.btnMostrarOcultarErroneos.UseVisualStyleBackColor = True
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label72.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label72.Location = New System.Drawing.Point(4, 35)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(90, 26)
        Me.Label72.TabIndex = 252
        Me.Label72.Text = "Mostrar/Ocultar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Códigos Erróneos"
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlBtnLimpiar
        '
        Me.pnlBtnLimpiar.Controls.Add(Me.btnLimpiarCodigos)
        Me.pnlBtnLimpiar.Controls.Add(Me.lblBtnLimpiar)
        Me.pnlBtnLimpiar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtnLimpiar.Location = New System.Drawing.Point(282, 0)
        Me.pnlBtnLimpiar.Name = "pnlBtnLimpiar"
        Me.pnlBtnLimpiar.Size = New System.Drawing.Size(60, 65)
        Me.pnlBtnLimpiar.TabIndex = 260
        '
        'btnLimpiarCodigos
        '
        Me.btnLimpiarCodigos.Image = Global.Almacen.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarCodigos.Location = New System.Drawing.Point(14, 4)
        Me.btnLimpiarCodigos.Name = "btnLimpiarCodigos"
        Me.btnLimpiarCodigos.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarCodigos.TabIndex = 253
        Me.btnLimpiarCodigos.UseVisualStyleBackColor = True
        '
        'lblBtnLimpiar
        '
        Me.lblBtnLimpiar.AutoSize = True
        Me.lblBtnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBtnLimpiar.Location = New System.Drawing.Point(8, 36)
        Me.lblBtnLimpiar.Name = "lblBtnLimpiar"
        Me.lblBtnLimpiar.Size = New System.Drawing.Size(45, 26)
        Me.lblBtnLimpiar.TabIndex = 254
        Me.lblBtnLimpiar.Text = "Limpiar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Códigos"
        Me.lblBtnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlBtnExportarErroneos
        '
        Me.pnlBtnExportarErroneos.Controls.Add(Me.btnExportarErroneos)
        Me.pnlBtnExportarErroneos.Controls.Add(Me.Label19)
        Me.pnlBtnExportarErroneos.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtnExportarErroneos.Location = New System.Drawing.Point(223, 0)
        Me.pnlBtnExportarErroneos.Name = "pnlBtnExportarErroneos"
        Me.pnlBtnExportarErroneos.Size = New System.Drawing.Size(59, 65)
        Me.pnlBtnExportarErroneos.TabIndex = 193
        '
        'btnExportarErroneos
        '
        Me.btnExportarErroneos.Image = Global.Almacen.Vista.My.Resources.Resources.excel_32
        Me.btnExportarErroneos.Location = New System.Drawing.Point(13, 4)
        Me.btnExportarErroneos.Name = "btnExportarErroneos"
        Me.btnExportarErroneos.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarErroneos.TabIndex = 186
        Me.btnExportarErroneos.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label19.Location = New System.Drawing.Point(5, 36)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 26)
        Me.Label19.TabIndex = 185
        Me.Label19.Text = "Exportar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Erróneos"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnPnlExportarCorrectos
        '
        Me.btnPnlExportarCorrectos.Controls.Add(Me.btnExportarCorrectos)
        Me.btnPnlExportarCorrectos.Controls.Add(Me.Label17)
        Me.btnPnlExportarCorrectos.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPnlExportarCorrectos.Location = New System.Drawing.Point(164, 0)
        Me.btnPnlExportarCorrectos.Name = "btnPnlExportarCorrectos"
        Me.btnPnlExportarCorrectos.Size = New System.Drawing.Size(59, 65)
        Me.btnPnlExportarCorrectos.TabIndex = 192
        '
        'btnExportarCorrectos
        '
        Me.btnExportarCorrectos.Image = Global.Almacen.Vista.My.Resources.Resources.excel_32
        Me.btnExportarCorrectos.Location = New System.Drawing.Point(13, 4)
        Me.btnExportarCorrectos.Name = "btnExportarCorrectos"
        Me.btnExportarCorrectos.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarCorrectos.TabIndex = 186
        Me.btnExportarCorrectos.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label17.Location = New System.Drawing.Point(3, 36)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 26)
        Me.Label17.TabIndex = 185
        Me.Label17.Text = "Exportar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Correctos"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlBtnLeerArchivo
        '
        Me.pnlBtnLeerArchivo.Controls.Add(Me.btnLeerArchivo)
        Me.pnlBtnLeerArchivo.Controls.Add(Me.Label16)
        Me.pnlBtnLeerArchivo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtnLeerArchivo.Location = New System.Drawing.Point(105, 0)
        Me.pnlBtnLeerArchivo.Name = "pnlBtnLeerArchivo"
        Me.pnlBtnLeerArchivo.Size = New System.Drawing.Size(59, 65)
        Me.pnlBtnLeerArchivo.TabIndex = 191
        '
        'btnLeerArchivo
        '
        Me.btnLeerArchivo.Image = Global.Almacen.Vista.My.Resources.Resources.cargar_archivo_dat
        Me.btnLeerArchivo.Location = New System.Drawing.Point(13, 4)
        Me.btnLeerArchivo.Name = "btnLeerArchivo"
        Me.btnLeerArchivo.Size = New System.Drawing.Size(32, 32)
        Me.btnLeerArchivo.TabIndex = 187
        Me.btnLeerArchivo.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label16.Location = New System.Drawing.Point(8, 36)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 26)
        Me.Label16.TabIndex = 188
        Me.Label16.Text = "Leer " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Archivo"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlBtnDetener
        '
        Me.pnlBtnDetener.Controls.Add(Me.btnDetenerLectura)
        Me.pnlBtnDetener.Controls.Add(Me.Label10)
        Me.pnlBtnDetener.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtnDetener.Location = New System.Drawing.Point(54, 0)
        Me.pnlBtnDetener.Name = "pnlBtnDetener"
        Me.pnlBtnDetener.Size = New System.Drawing.Size(51, 65)
        Me.pnlBtnDetener.TabIndex = 190
        '
        'btnDetenerLectura
        '
        Me.btnDetenerLectura.Enabled = False
        Me.btnDetenerLectura.Image = Global.Almacen.Vista.My.Resources.Resources.cancelar321
        Me.btnDetenerLectura.Location = New System.Drawing.Point(10, 11)
        Me.btnDetenerLectura.Name = "btnDetenerLectura"
        Me.btnDetenerLectura.Size = New System.Drawing.Size(32, 32)
        Me.btnDetenerLectura.TabIndex = 176
        Me.btnDetenerLectura.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label10.Location = New System.Drawing.Point(4, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 175
        Me.Label10.Text = "Detener"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlBtnIniciar
        '
        Me.pnlBtnIniciar.Controls.Add(Me.btnIniciarLectura)
        Me.pnlBtnIniciar.Controls.Add(Me.lblCargarArchivo)
        Me.pnlBtnIniciar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtnIniciar.Location = New System.Drawing.Point(0, 0)
        Me.pnlBtnIniciar.Name = "pnlBtnIniciar"
        Me.pnlBtnIniciar.Size = New System.Drawing.Size(54, 65)
        Me.pnlBtnIniciar.TabIndex = 189
        '
        'btnIniciarLectura
        '
        Me.btnIniciarLectura.Image = Global.Almacen.Vista.My.Resources.Resources.btnIniciar_Image
        Me.btnIniciarLectura.Location = New System.Drawing.Point(12, 11)
        Me.btnIniciarLectura.Name = "btnIniciarLectura"
        Me.btnIniciarLectura.Size = New System.Drawing.Size(32, 32)
        Me.btnIniciarLectura.TabIndex = 183
        Me.btnIniciarLectura.UseVisualStyleBackColor = True
        '
        'lblCargarArchivo
        '
        Me.lblCargarArchivo.AutoSize = True
        Me.lblCargarArchivo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCargarArchivo.Location = New System.Drawing.Point(11, 43)
        Me.lblCargarArchivo.Name = "lblCargarArchivo"
        Me.lblCargarArchivo.Size = New System.Drawing.Size(35, 13)
        Me.lblCargarArchivo.TabIndex = 184
        Me.lblCargarArchivo.Text = "Iniciar"
        Me.lblCargarArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(962, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(322, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(21, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(218, 20)
        Me.lblTitulo.TabIndex = 48
        Me.lblTitulo.Text = "Movimientos de Inventario"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.InitialImage = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(239, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(83, 65)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'spltContenedorGridCodigos
        '
        Me.spltContenedorGridCodigos.BackColor = System.Drawing.Color.AliceBlue
        Me.spltContenedorGridCodigos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spltContenedorGridCodigos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spltContenedorGridCodigos.Location = New System.Drawing.Point(0, 0)
        Me.spltContenedorGridCodigos.Name = "spltContenedorGridCodigos"
        '
        'spltContenedorGridCodigos.Panel1
        '
        Me.spltContenedorGridCodigos.Panel1.Controls.Add(Me.Panel9)
        Me.spltContenedorGridCodigos.Panel1.Controls.Add(Me.pnlTituloGridCorrectos)
        '
        'spltContenedorGridCodigos.Panel2
        '
        Me.spltContenedorGridCodigos.Panel2.Controls.Add(Me.Panel8)
        Me.spltContenedorGridCodigos.Panel2.Controls.Add(Me.pnlTituloGridIncorrectos)
        Me.spltContenedorGridCodigos.Size = New System.Drawing.Size(1284, 347)
        Me.spltContenedorGridCodigos.SplitterDistance = 851
        Me.spltContenedorGridCodigos.TabIndex = 40
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.grdConsultaLotes)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(0, 26)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(849, 319)
        Me.Panel9.TabIndex = 41
        '
        'pnlTituloGridCorrectos
        '
        Me.pnlTituloGridCorrectos.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlTituloGridCorrectos.Controls.Add(Me.lblTituloCorrectos)
        Me.pnlTituloGridCorrectos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTituloGridCorrectos.Location = New System.Drawing.Point(0, 0)
        Me.pnlTituloGridCorrectos.Name = "pnlTituloGridCorrectos"
        Me.pnlTituloGridCorrectos.Size = New System.Drawing.Size(849, 26)
        Me.pnlTituloGridCorrectos.TabIndex = 40
        '
        'lblTituloCorrectos
        '
        Me.lblTituloCorrectos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTituloCorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloCorrectos.ForeColor = System.Drawing.Color.Green
        Me.lblTituloCorrectos.Location = New System.Drawing.Point(0, 0)
        Me.lblTituloCorrectos.Name = "lblTituloCorrectos"
        Me.lblTituloCorrectos.Size = New System.Drawing.Size(849, 26)
        Me.lblTituloCorrectos.TabIndex = 213
        Me.lblTituloCorrectos.Text = "CORRECTOS"
        Me.lblTituloCorrectos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.grdCodigosErroneos)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(0, 26)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(427, 319)
        Me.Panel8.TabIndex = 42
        '
        'grdCodigosErroneos
        '
        Me.grdCodigosErroneos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCodigosErroneos.Location = New System.Drawing.Point(0, 0)
        Me.grdCodigosErroneos.MainView = Me.bgvCodigosErroneos
        Me.grdCodigosErroneos.Name = "grdCodigosErroneos"
        Me.grdCodigosErroneos.Size = New System.Drawing.Size(427, 319)
        Me.grdCodigosErroneos.TabIndex = 40
        Me.grdCodigosErroneos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvCodigosErroneos})
        '
        'bgvCodigosErroneos
        '
        Me.bgvCodigosErroneos.GridControl = Me.grdCodigosErroneos
        Me.bgvCodigosErroneos.Name = "bgvCodigosErroneos"
        Me.bgvCodigosErroneos.OptionsView.ShowAutoFilterRow = True
        '
        'pnlTituloGridIncorrectos
        '
        Me.pnlTituloGridIncorrectos.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlTituloGridIncorrectos.Controls.Add(Me.chkMostrarColumnas)
        Me.pnlTituloGridIncorrectos.Controls.Add(Me.lblTituloConError)
        Me.pnlTituloGridIncorrectos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTituloGridIncorrectos.Location = New System.Drawing.Point(0, 0)
        Me.pnlTituloGridIncorrectos.Name = "pnlTituloGridIncorrectos"
        Me.pnlTituloGridIncorrectos.Size = New System.Drawing.Size(427, 26)
        Me.pnlTituloGridIncorrectos.TabIndex = 41
        Me.pnlTituloGridIncorrectos.TabStop = True
        '
        'chkMostrarColumnas
        '
        Me.chkMostrarColumnas.AutoSize = True
        Me.chkMostrarColumnas.Location = New System.Drawing.Point(4, 4)
        Me.chkMostrarColumnas.Name = "chkMostrarColumnas"
        Me.chkMostrarColumnas.Size = New System.Drawing.Size(110, 17)
        Me.chkMostrarColumnas.TabIndex = 217
        Me.chkMostrarColumnas.Text = "Mostrar Columnas"
        Me.chkMostrarColumnas.UseVisualStyleBackColor = True
        '
        'lblTituloConError
        '
        Me.lblTituloConError.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloConError.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloConError.ForeColor = System.Drawing.Color.Red
        Me.lblTituloConError.Location = New System.Drawing.Point(0, 0)
        Me.lblTituloConError.Name = "lblTituloConError"
        Me.lblTituloConError.Size = New System.Drawing.Size(427, 26)
        Me.lblTituloConError.TabIndex = 216
        Me.lblTituloConError.Text = "CON ERROR"
        Me.lblTituloConError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ofdAbrirDat
        '
        Me.ofdAbrirDat.FileName = "OpenFileDialog1"
        '
        'pgrsPnlCargando
        '
        Me.pgrsPnlCargando.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgrsPnlCargando.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.pgrsPnlCargando.Appearance.Options.UseBackColor = True
        Me.pgrsPnlCargando.AppearanceDescription.Options.UseTextOptions = True
        Me.pgrsPnlCargando.AppearanceDescription.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.pgrsPnlCargando.Caption = "Espere Por Favor"
        Me.pgrsPnlCargando.Description = "Leyendo archivo..."
        Me.pgrsPnlCargando.Location = New System.Drawing.Point(495, 234)
        Me.pgrsPnlCargando.MaximumSize = New System.Drawing.Size(246, 66)
        Me.pgrsPnlCargando.MinimumSize = New System.Drawing.Size(246, 66)
        Me.pgrsPnlCargando.Name = "pgrsPnlCargando"
        Me.pgrsPnlCargando.Size = New System.Drawing.Size(246, 66)
        Me.pgrsPnlCargando.TabIndex = 269
        Me.pgrsPnlCargando.Text = "ProgressPanel2"
        Me.pgrsPnlCargando.Visible = False
        '
        'pnlRestricciones
        '
        Me.pnlRestricciones.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlRestricciones.Controls.Add(Me.txtRestricciones)
        Me.pnlRestricciones.Controls.Add(Me.Label3)
        Me.pnlRestricciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRestricciones.Location = New System.Drawing.Point(0, 97)
        Me.pnlRestricciones.Name = "pnlRestricciones"
        Me.pnlRestricciones.Size = New System.Drawing.Size(1284, 30)
        Me.pnlRestricciones.TabIndex = 270
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.spltContenedorGridCodigos)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(0, 127)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(1284, 347)
        Me.Panel11.TabIndex = 271
        '
        'DevolucionCliente_MovimientosInventario_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 534)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.pnlRestricciones)
        Me.Controls.Add(Me.pgrsPnlCargando)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "DevolucionCliente_MovimientosInventario_Form"
        Me.Text = "Movimientos de Inventario"
        CType(Me.grdConsultaLotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvConsultaLotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlBtnGuardar.ResumeLayout(False)
        Me.pnlBtnGuardar.PerformLayout()
        Me.pnlBtnCerrar.ResumeLayout(False)
        Me.pnlBtnCerrar.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlBtnMostrarDocumentos.ResumeLayout(False)
        Me.pnlBtnMostrarDocumentos.PerformLayout()
        Me.pnlBtnLimpiar.ResumeLayout(False)
        Me.pnlBtnLimpiar.PerformLayout()
        Me.pnlBtnExportarErroneos.ResumeLayout(False)
        Me.pnlBtnExportarErroneos.PerformLayout()
        Me.btnPnlExportarCorrectos.ResumeLayout(False)
        Me.btnPnlExportarCorrectos.PerformLayout()
        Me.pnlBtnLeerArchivo.ResumeLayout(False)
        Me.pnlBtnLeerArchivo.PerformLayout()
        Me.pnlBtnDetener.ResumeLayout(False)
        Me.pnlBtnDetener.PerformLayout()
        Me.pnlBtnIniciar.ResumeLayout(False)
        Me.pnlBtnIniciar.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spltContenedorGridCodigos.Panel1.ResumeLayout(False)
        Me.spltContenedorGridCodigos.Panel2.ResumeLayout(False)
        CType(Me.spltContenedorGridCodigos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spltContenedorGridCodigos.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.pnlTituloGridCorrectos.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.grdCodigosErroneos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvCodigosErroneos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTituloGridIncorrectos.ResumeLayout(False)
        Me.pnlTituloGridIncorrectos.PerformLayout()
        Me.pnlRestricciones.ResumeLayout(False)
        Me.pnlRestricciones.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grdConsultaLotes As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvConsultaLotes As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents btnDetenerLectura As Button
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lblCantidadPares As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblCantidadAtados As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCantidadLotes As Label
    Friend WithEvents lblCargarArchivo As Label
    Friend WithEvents btnIniciarLectura As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents lblCantidadConError As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblCantidadCorrectos As Label
    Friend WithEvents cmbMovimiento As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents btnLeerArchivo As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents btnExportarCorrectos As Button
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents pnlBtnDetener As Panel
    Friend WithEvents pnlBtnIniciar As Panel
    Friend WithEvents btnPnlExportarCorrectos As Panel
    Friend WithEvents pnlBtnLeerArchivo As Panel
    Friend WithEvents spltContenedorGridCodigos As SplitContainer
    Friend WithEvents pnlTituloGridCorrectos As Panel
    Friend WithEvents lblTituloCorrectos As Label
    Friend WithEvents pnlTituloGridIncorrectos As Panel
    Friend WithEvents lblTituloConError As Label
    Friend WithEvents grdCodigosErroneos As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvCodigosErroneos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pnlBtnExportarErroneos As Panel
    Friend WithEvents btnExportarErroneos As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ofdAbrirDat As OpenFileDialog
    Friend WithEvents pgrsPnlCargando As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents pnlBtnLimpiar As Panel
    Friend WithEvents btnMostrarOcultarErroneos As Button
    Friend WithEvents Label72 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents txtRestricciones As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblPares As Label
    Friend WithEvents lblEtiquetaPares As Label
    Friend WithEvents lblDestino As Label
    Friend WithEvents lblEtiquetaDestino As Label
    Friend WithEvents lblFolioDev As Label
    Friend WithEvents lblEtiquetaFolioDev As Label
    Friend WithEvents chkMostrarColumnas As CheckBox
    Friend WithEvents pnlRestricciones As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents pnlBtnGuardar As Panel
    Friend WithEvents pnlBtnCerrar As Panel
    Friend WithEvents pnlBtnMostrarDocumentos As Panel
    Friend WithEvents btnLimpiarCodigos As Button
    Friend WithEvents lblBtnLimpiar As Label
End Class
