<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FacturacionAnticipada_ImportarDistribucionTiendasCoppel_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FacturacionAnticipada_ImportarDistribucionTiendasCoppel_Form))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.lblParesArchivos = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblParesPendientes = New System.Windows.Forms.Label()
        Me.lblEtiquetasParesArchivo = New System.Windows.Forms.Label()
        Me.lblParesPedido = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblOrdenCompra = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblPedidoSICY = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblPedidoSAY = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grpEstatusRegistro = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTotalTiendas = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tbnpArchivo = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.grdImportacionDistribucion = New DevExpress.XtraGrid.GridControl()
        Me.grdDatosImportacionDistribucion = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tbpGrupos = New DevExpress.XtraBars.Navigation.TabPane()
        Me.tbpPares = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.grdInformacionPares = New DevExpress.XtraGrid.GridControl()
        Me.grdDatosInformacionPares = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpEstatusRegistro.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbnpArchivo.SuspendLayout()
        CType(Me.grdImportacionDistribucion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatosImportacionDistribucion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbpGrupos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpGrupos.SuspendLayout()
        Me.tbpPares.SuspendLayout()
        CType(Me.grdInformacionPares, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatosInformacionPares, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(834, 65)
        Me.pnlEncabezado.TabIndex = 36
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitle)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(281, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(553, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(61, 23)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(423, 20)
        Me.lblTitle.TabIndex = 91
        Me.lblTitle.Text = "Importación de Distribución de Pedidos Por Tiendas"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(177, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(0, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.lblParesArchivos)
        Me.pnlParametros.Controls.Add(Me.Label3)
        Me.pnlParametros.Controls.Add(Me.lblParesPendientes)
        Me.pnlParametros.Controls.Add(Me.lblEtiquetasParesArchivo)
        Me.pnlParametros.Controls.Add(Me.lblParesPedido)
        Me.pnlParametros.Controls.Add(Me.Label11)
        Me.pnlParametros.Controls.Add(Me.lblOrdenCompra)
        Me.pnlParametros.Controls.Add(Me.Label9)
        Me.pnlParametros.Controls.Add(Me.lblPedidoSICY)
        Me.pnlParametros.Controls.Add(Me.Label7)
        Me.pnlParametros.Controls.Add(Me.lblPedidoSAY)
        Me.pnlParametros.Controls.Add(Me.Label4)
        Me.pnlParametros.Controls.Add(Me.lblCliente)
        Me.pnlParametros.Controls.Add(Me.Label2)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 65)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(834, 45)
        Me.pnlParametros.TabIndex = 40
        '
        'lblParesArchivos
        '
        Me.lblParesArchivos.AutoSize = True
        Me.lblParesArchivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesArchivos.ForeColor = System.Drawing.Color.Green
        Me.lblParesArchivos.Location = New System.Drawing.Point(710, 23)
        Me.lblParesArchivos.Name = "lblParesArchivos"
        Me.lblParesArchivos.Size = New System.Drawing.Size(14, 15)
        Me.lblParesArchivos.TabIndex = 191
        Me.lblParesArchivos.Text = "0"
        Me.lblParesArchivos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(620, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 15)
        Me.Label3.TabIndex = 190
        Me.Label3.Text = "Pares Archivo:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblParesPendientes
        '
        Me.lblParesPendientes.AutoSize = True
        Me.lblParesPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesPendientes.ForeColor = System.Drawing.Color.Green
        Me.lblParesPendientes.Location = New System.Drawing.Point(563, 23)
        Me.lblParesPendientes.Name = "lblParesPendientes"
        Me.lblParesPendientes.Size = New System.Drawing.Size(14, 15)
        Me.lblParesPendientes.TabIndex = 189
        Me.lblParesPendientes.Text = "0"
        Me.lblParesPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEtiquetasParesArchivo
        '
        Me.lblEtiquetasParesArchivo.AutoSize = True
        Me.lblEtiquetasParesArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetasParesArchivo.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetasParesArchivo.Location = New System.Drawing.Point(450, 23)
        Me.lblEtiquetasParesArchivo.Name = "lblEtiquetasParesArchivo"
        Me.lblEtiquetasParesArchivo.Size = New System.Drawing.Size(107, 15)
        Me.lblEtiquetasParesArchivo.TabIndex = 188
        Me.lblEtiquetasParesArchivo.Text = "Pares Pendientes:"
        Me.lblEtiquetasParesArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblParesPedido
        '
        Me.lblParesPedido.AutoSize = True
        Me.lblParesPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesPedido.ForeColor = System.Drawing.Color.Black
        Me.lblParesPedido.Location = New System.Drawing.Point(385, 23)
        Me.lblParesPedido.Name = "lblParesPedido"
        Me.lblParesPedido.Size = New System.Drawing.Size(14, 15)
        Me.lblParesPedido.TabIndex = 187
        Me.lblParesPedido.Text = "0"
        Me.lblParesPedido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(295, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 15)
        Me.Label11.TabIndex = 186
        Me.Label11.Text = "Pares Pedido:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOrdenCompra
        '
        Me.lblOrdenCompra.AutoSize = True
        Me.lblOrdenCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrdenCompra.Location = New System.Drawing.Point(711, 6)
        Me.lblOrdenCompra.Name = "lblOrdenCompra"
        Me.lblOrdenCompra.Size = New System.Drawing.Size(14, 15)
        Me.lblOrdenCompra.TabIndex = 152
        Me.lblOrdenCompra.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(620, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 15)
        Me.Label9.TabIndex = 151
        Me.Label9.Text = "Orden Cliente:"
        '
        'lblPedidoSICY
        '
        Me.lblPedidoSICY.AutoSize = True
        Me.lblPedidoSICY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoSICY.Location = New System.Drawing.Point(563, 6)
        Me.lblPedidoSICY.Name = "lblPedidoSICY"
        Me.lblPedidoSICY.Size = New System.Drawing.Size(14, 15)
        Me.lblPedidoSICY.TabIndex = 150
        Me.lblPedidoSICY.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(479, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 15)
        Me.Label7.TabIndex = 149
        Me.Label7.Text = "Pedido SICY:"
        '
        'lblPedidoSAY
        '
        Me.lblPedidoSAY.AutoSize = True
        Me.lblPedidoSAY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoSAY.Location = New System.Drawing.Point(385, 6)
        Me.lblPedidoSAY.Name = "lblPedidoSAY"
        Me.lblPedidoSAY.Size = New System.Drawing.Size(14, 15)
        Me.lblPedidoSAY.TabIndex = 148
        Me.lblPedidoSAY.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(305, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 15)
        Me.Label4.TabIndex = 147
        Me.Label4.Text = "Pedido SAY:"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(65, 6)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(57, 15)
        Me.lblCliente.TabIndex = 146
        Me.lblCliente.Text = "CLIENTE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 15)
        Me.Label2.TabIndex = 145
        Me.Label2.Text = "Cliente:"
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.Panel1)
        Me.pnlPie.Controls.Add(Me.Panel3)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Controls.Add(Me.Label32)
        Me.pnlPie.Controls.Add(Me.Label31)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 402)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(834, 59)
        Me.pnlPie.TabIndex = 41
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grpEstatusRegistro)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(134, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(159, 59)
        Me.Panel1.TabIndex = 190
        '
        'grpEstatusRegistro
        '
        Me.grpEstatusRegistro.Controls.Add(Me.Panel2)
        Me.grpEstatusRegistro.Controls.Add(Me.Label13)
        Me.grpEstatusRegistro.Location = New System.Drawing.Point(6, 3)
        Me.grpEstatusRegistro.Name = "grpEstatusRegistro"
        Me.grpEstatusRegistro.Size = New System.Drawing.Size(147, 57)
        Me.grpEstatusRegistro.TabIndex = 185
        Me.grpEstatusRegistro.TabStop = False
        Me.grpEstatusRegistro.Text = "Estatus Registro"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Pink
        Me.Panel2.ForeColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(6, 28)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(15, 15)
        Me.Panel2.TabIndex = 43
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(27, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 28)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Artículo sin estándar de empaque"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.lblTotalTiendas)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(134, 59)
        Me.Panel3.TabIndex = 189
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 26)
        Me.Label5.TabIndex = 186
        Me.Label5.Text = "Total Tiendas"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalTiendas
        '
        Me.lblTotalTiendas.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalTiendas.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTotalTiendas.Location = New System.Drawing.Point(24, 29)
        Me.lblTotalTiendas.Name = "lblTotalTiendas"
        Me.lblTotalTiendas.Size = New System.Drawing.Size(86, 24)
        Me.lblTotalTiendas.TabIndex = 187
        Me.lblTotalTiendas.Text = "0"
        Me.lblTotalTiendas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.lblGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(694, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(140, 59)
        Me.pnlDatosBotones.TabIndex = 161
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(21, 9)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(18, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 4
        Me.lblGuardar.Text = "Guardar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(74, 9)
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
        Me.lblCerrar.Location = New System.Drawing.Point(73, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(919, 29)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(118, 13)
        Me.Label32.TabIndex = 160
        Me.Label32.Text = "13/02/2019 12:34 p.m."
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(925, 13)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(102, 13)
        Me.Label31.TabIndex = 159
        Me.Label31.Text = "Última Actualización"
        '
        'GridView1
        '
        Me.GridView1.Name = "GridView1"
        '
        'tbnpArchivo
        '
        Me.tbnpArchivo.BackgroundPadding = New System.Windows.Forms.Padding(1)
        Me.tbnpArchivo.Caption = "Archivo"
        Me.tbnpArchivo.Controls.Add(Me.grdImportacionDistribucion)
        Me.tbnpArchivo.Name = "tbnpArchivo"
        Me.tbnpArchivo.Size = New System.Drawing.Size(830, 261)
        '
        'grdImportacionDistribucion
        '
        Me.grdImportacionDistribucion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdImportacionDistribucion.Location = New System.Drawing.Point(0, 0)
        Me.grdImportacionDistribucion.MainView = Me.grdDatosImportacionDistribucion
        Me.grdImportacionDistribucion.Name = "grdImportacionDistribucion"
        Me.grdImportacionDistribucion.Size = New System.Drawing.Size(830, 261)
        Me.grdImportacionDistribucion.TabIndex = 162
        Me.grdImportacionDistribucion.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdDatosImportacionDistribucion, Me.GridView2})
        '
        'grdDatosImportacionDistribucion
        '
        Me.grdDatosImportacionDistribucion.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatosImportacionDistribucion.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grdDatosImportacionDistribucion.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grdDatosImportacionDistribucion.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.grdDatosImportacionDistribucion.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatosImportacionDistribucion.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.grdDatosImportacionDistribucion.Appearance.SelectedRow.Options.UseBackColor = True
        Me.grdDatosImportacionDistribucion.Appearance.SelectedRow.Options.UseForeColor = True
        Me.grdDatosImportacionDistribucion.GridControl = Me.grdImportacionDistribucion
        Me.grdDatosImportacionDistribucion.IndicatorWidth = 30
        Me.grdDatosImportacionDistribucion.Name = "grdDatosImportacionDistribucion"
        Me.grdDatosImportacionDistribucion.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatosImportacionDistribucion.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatosImportacionDistribucion.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdDatosImportacionDistribucion.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.grdDatosImportacionDistribucion.OptionsPrint.AllowMultilineHeaders = True
        Me.grdDatosImportacionDistribucion.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdDatosImportacionDistribucion.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.grdDatosImportacionDistribucion.OptionsView.ShowAutoFilterRow = True
        Me.grdDatosImportacionDistribucion.OptionsView.ShowFooter = True
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.grdImportacionDistribucion
        Me.GridView2.Name = "GridView2"
        '
        'tbpGrupos
        '
        Me.tbpGrupos.Appearance.BackColor = System.Drawing.Color.White
        Me.tbpGrupos.Appearance.Options.UseBackColor = True
        Me.tbpGrupos.Controls.Add(Me.tbnpArchivo)
        Me.tbpGrupos.Controls.Add(Me.tbpPares)
        Me.tbpGrupos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbpGrupos.Location = New System.Drawing.Point(0, 110)
        Me.tbpGrupos.Name = "tbpGrupos"
        Me.tbpGrupos.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.tbnpArchivo, Me.tbpPares})
        Me.tbpGrupos.RegularSize = New System.Drawing.Size(834, 292)
        Me.tbpGrupos.SelectedPage = Me.tbnpArchivo
        Me.tbpGrupos.Size = New System.Drawing.Size(834, 292)
        Me.tbpGrupos.TabIndex = 42
        '
        'tbpPares
        '
        Me.tbpPares.Caption = "OT a Generar"
        Me.tbpPares.Controls.Add(Me.grdInformacionPares)
        Me.tbpPares.Name = "tbpPares"
        Me.tbpPares.Size = New System.Drawing.Size(816, 247)
        '
        'grdInformacionPares
        '
        Me.grdInformacionPares.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdInformacionPares.Location = New System.Drawing.Point(0, 0)
        Me.grdInformacionPares.MainView = Me.grdDatosInformacionPares
        Me.grdInformacionPares.Name = "grdInformacionPares"
        Me.grdInformacionPares.Size = New System.Drawing.Size(816, 247)
        Me.grdInformacionPares.TabIndex = 163
        Me.grdInformacionPares.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdDatosInformacionPares, Me.GridView4})
        '
        'grdDatosInformacionPares
        '
        Me.grdDatosInformacionPares.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatosInformacionPares.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grdDatosInformacionPares.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grdDatosInformacionPares.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.grdDatosInformacionPares.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatosInformacionPares.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.grdDatosInformacionPares.Appearance.SelectedRow.Options.UseBackColor = True
        Me.grdDatosInformacionPares.Appearance.SelectedRow.Options.UseForeColor = True
        Me.grdDatosInformacionPares.GridControl = Me.grdInformacionPares
        Me.grdDatosInformacionPares.IndicatorWidth = 30
        Me.grdDatosInformacionPares.Name = "grdDatosInformacionPares"
        Me.grdDatosInformacionPares.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatosInformacionPares.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatosInformacionPares.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdDatosInformacionPares.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.grdDatosInformacionPares.OptionsPrint.AllowMultilineHeaders = True
        Me.grdDatosInformacionPares.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdDatosInformacionPares.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.grdDatosInformacionPares.OptionsView.ShowAutoFilterRow = True
        Me.grdDatosInformacionPares.OptionsView.ShowFooter = True
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.grdInformacionPares
        Me.GridView4.Name = "GridView4"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(485, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 65)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 92
        Me.PictureBox1.TabStop = False
        '
        'FacturacionAnticipada_ImportarDistribucionTiendasCoppel_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(834, 461)
        Me.Controls.Add(Me.tbpGrupos)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FacturacionAnticipada_ImportarDistribucionTiendasCoppel_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Importación de Distribución de Pedidos Por Tiendas"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.grpEstatusRegistro.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbnpArchivo.ResumeLayout(False)
        CType(Me.grdImportacionDistribucion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatosImportacionDistribucion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbpGrupos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpGrupos.ResumeLayout(False)
        Me.tbpPares.ResumeLayout(False)
        CType(Me.grdInformacionPares, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatosInformacionPares, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents lblParesPendientes As Label
    Friend WithEvents lblEtiquetasParesArchivo As Label
    Friend WithEvents lblParesPedido As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblOrdenCompra As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblPedidoSICY As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblPedidoSAY As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblCliente As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents lblTotalTiendas As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblGuardar As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents lblParesArchivos As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents tbnpArchivo As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents grdImportacionDistribucion As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdDatosImportacionDistribucion As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents tbpGrupos As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents tbpPares As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents grdInformacionPares As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdDatosInformacionPares As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grpEstatusRegistro As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
End Class
