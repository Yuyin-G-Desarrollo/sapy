<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventarioMuestrasForm
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
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.lbl_EscaneoMultiple = New System.Windows.Forms.Label()
        Me.btn_EscaneoMultiple = New System.Windows.Forms.Button()
        Me.lblImprimirEtiquetas = New System.Windows.Forms.Label()
        Me.btnImprimirEtiquetas = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.groupContenedor = New System.Windows.Forms.GroupBox()
        Me.cmbImpresion = New System.Windows.Forms.ComboBox()
        Me.chkCaja = New System.Windows.Forms.CheckBox()
        Me.chkSuela = New System.Windows.Forms.CheckBox()
        Me.lblImpresora = New System.Windows.Forms.Label()
        Me.chkColgante = New System.Windows.Forms.CheckBox()
        Me.chboxSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.rdoConfirmados = New System.Windows.Forms.RadioButton()
        Me.pnlEntregados = New System.Windows.Forms.Panel()
        Me.btnBuscarEntregados = New System.Windows.Forms.Button()
        Me.cmbAsunto = New System.Windows.Forms.ComboBox()
        Me.cmbAgente = New System.Windows.Forms.ComboBox()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.pnlDisponibles = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rdoDisponibles = New System.Windows.Forms.RadioButton()
        Me.rdoEntregados = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdInventario = New DevExpress.XtraGrid.GridControl()
        Me.grdVinventario = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel14.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.groupContenedor.SuspendLayout()
        Me.pnlEntregados.SuspendLayout()
        Me.pnlDisponibles.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVinventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.lbl_EscaneoMultiple)
        Me.Panel14.Controls.Add(Me.btn_EscaneoMultiple)
        Me.Panel14.Controls.Add(Me.lblImprimirEtiquetas)
        Me.Panel14.Controls.Add(Me.btnImprimirEtiquetas)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(703, 83)
        Me.Panel14.TabIndex = 3
        '
        'lbl_EscaneoMultiple
        '
        Me.lbl_EscaneoMultiple.AutoSize = True
        Me.lbl_EscaneoMultiple.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbl_EscaneoMultiple.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_EscaneoMultiple.Location = New System.Drawing.Point(108, 44)
        Me.lbl_EscaneoMultiple.Name = "lbl_EscaneoMultiple"
        Me.lbl_EscaneoMultiple.Size = New System.Drawing.Size(88, 13)
        Me.lbl_EscaneoMultiple.TabIndex = 86
        Me.lbl_EscaneoMultiple.Text = "Escaneo Multiple"
        '
        'btn_EscaneoMultiple
        '
        Me.btn_EscaneoMultiple.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btn_EscaneoMultiple.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btn_EscaneoMultiple.Image = Global.Programacion.Vista.My.Resources.Resources.codigos
        Me.btn_EscaneoMultiple.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_EscaneoMultiple.Location = New System.Drawing.Point(134, 9)
        Me.btn_EscaneoMultiple.Name = "btn_EscaneoMultiple"
        Me.btn_EscaneoMultiple.Size = New System.Drawing.Size(32, 32)
        Me.btn_EscaneoMultiple.TabIndex = 85
        Me.btn_EscaneoMultiple.UseVisualStyleBackColor = True
        '
        'lblImprimirEtiquetas
        '
        Me.lblImprimirEtiquetas.AutoSize = True
        Me.lblImprimirEtiquetas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimirEtiquetas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblImprimirEtiquetas.Location = New System.Drawing.Point(13, 44)
        Me.lblImprimirEtiquetas.Name = "lblImprimirEtiquetas"
        Me.lblImprimirEtiquetas.Size = New System.Drawing.Size(89, 13)
        Me.lblImprimirEtiquetas.TabIndex = 84
        Me.lblImprimirEtiquetas.Text = "Imprimir Etiquetas"
        '
        'btnImprimirEtiquetas
        '
        Me.btnImprimirEtiquetas.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnImprimirEtiquetas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImprimirEtiquetas.Image = Global.Programacion.Vista.My.Resources.Resources.ImprimirEtiquetas
        Me.btnImprimirEtiquetas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImprimirEtiquetas.Location = New System.Drawing.Point(41, 9)
        Me.btnImprimirEtiquetas.Name = "btnImprimirEtiquetas"
        Me.btnImprimirEtiquetas.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimirEtiquetas.TabIndex = 82
        Me.btnImprimirEtiquetas.UseVisualStyleBackColor = True
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1276, 83)
        Me.pnlEncabezado.TabIndex = 28
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(703, 83)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(749, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(527, 83)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(239, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(168, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Inventario Muestras"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(444, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 83)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.groupContenedor)
        Me.Panel1.Controls.Add(Me.chboxSeleccionarTodo)
        Me.Panel1.Controls.Add(Me.rdoConfirmados)
        Me.Panel1.Controls.Add(Me.pnlEntregados)
        Me.Panel1.Controls.Add(Me.pnlDisponibles)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.rdoDisponibles)
        Me.Panel1.Controls.Add(Me.rdoEntregados)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 83)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1276, 143)
        Me.Panel1.TabIndex = 29
        '
        'groupContenedor
        '
        Me.groupContenedor.Controls.Add(Me.cmbImpresion)
        Me.groupContenedor.Controls.Add(Me.chkCaja)
        Me.groupContenedor.Controls.Add(Me.chkSuela)
        Me.groupContenedor.Controls.Add(Me.lblImpresora)
        Me.groupContenedor.Controls.Add(Me.chkColgante)
        Me.groupContenedor.Location = New System.Drawing.Point(432, 19)
        Me.groupContenedor.Name = "groupContenedor"
        Me.groupContenedor.Size = New System.Drawing.Size(592, 53)
        Me.groupContenedor.TabIndex = 128
        Me.groupContenedor.TabStop = False
        '
        'cmbImpresion
        '
        Me.cmbImpresion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbImpresion.FormattingEnabled = True
        Me.cmbImpresion.Items.AddRange(New Object() {"IMPRESIÓN 200", "IMPRESIÓN 300"})
        Me.cmbImpresion.Location = New System.Drawing.Point(141, 18)
        Me.cmbImpresion.Name = "cmbImpresion"
        Me.cmbImpresion.Size = New System.Drawing.Size(153, 21)
        Me.cmbImpresion.TabIndex = 4
        '
        'chkCaja
        '
        Me.chkCaja.AutoSize = True
        Me.chkCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCaja.Location = New System.Drawing.Point(433, 19)
        Me.chkCaja.Name = "chkCaja"
        Me.chkCaja.Size = New System.Drawing.Size(60, 24)
        Me.chkCaja.TabIndex = 2
        Me.chkCaja.Text = "Caja"
        Me.chkCaja.UseVisualStyleBackColor = True
        '
        'chkSuela
        '
        Me.chkSuela.AutoSize = True
        Me.chkSuela.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSuela.Location = New System.Drawing.Point(512, 19)
        Me.chkSuela.Name = "chkSuela"
        Me.chkSuela.Size = New System.Drawing.Size(69, 24)
        Me.chkSuela.TabIndex = 1
        Me.chkSuela.Text = "Suela"
        Me.chkSuela.UseVisualStyleBackColor = True
        '
        'lblImpresora
        '
        Me.lblImpresora.AutoSize = True
        Me.lblImpresora.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpresora.Location = New System.Drawing.Point(7, 16)
        Me.lblImpresora.Name = "lblImpresora"
        Me.lblImpresora.Size = New System.Drawing.Size(117, 20)
        Me.lblImpresora.TabIndex = 3
        Me.lblImpresora.Text = "Tipo Impresión:"
        '
        'chkColgante
        '
        Me.chkColgante.AutoSize = True
        Me.chkColgante.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkColgante.Location = New System.Drawing.Point(307, 18)
        Me.chkColgante.Name = "chkColgante"
        Me.chkColgante.Size = New System.Drawing.Size(92, 24)
        Me.chkColgante.TabIndex = 0
        Me.chkColgante.Text = "Colgante"
        Me.chkColgante.UseVisualStyleBackColor = True
        '
        'chboxSeleccionarTodo
        '
        Me.chboxSeleccionarTodo.AutoSize = True
        Me.chboxSeleccionarTodo.Location = New System.Drawing.Point(21, 15)
        Me.chboxSeleccionarTodo.Name = "chboxSeleccionarTodo"
        Me.chboxSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chboxSeleccionarTodo.TabIndex = 127
        Me.chboxSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chboxSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'rdoConfirmados
        '
        Me.rdoConfirmados.AutoSize = True
        Me.rdoConfirmados.Location = New System.Drawing.Point(137, 42)
        Me.rdoConfirmados.Name = "rdoConfirmados"
        Me.rdoConfirmados.Size = New System.Drawing.Size(83, 17)
        Me.rdoConfirmados.TabIndex = 126
        Me.rdoConfirmados.TabStop = True
        Me.rdoConfirmados.Text = "Confirmados"
        Me.rdoConfirmados.UseVisualStyleBackColor = True
        '
        'pnlEntregados
        '
        Me.pnlEntregados.Controls.Add(Me.btnBuscarEntregados)
        Me.pnlEntregados.Controls.Add(Me.cmbAsunto)
        Me.pnlEntregados.Controls.Add(Me.cmbAgente)
        Me.pnlEntregados.Controls.Add(Me.cmbCliente)
        Me.pnlEntregados.Controls.Add(Me.Label3)
        Me.pnlEntregados.Controls.Add(Me.Label2)
        Me.pnlEntregados.Controls.Add(Me.lblBuscar)
        Me.pnlEntregados.Location = New System.Drawing.Point(317, 78)
        Me.pnlEntregados.Name = "pnlEntregados"
        Me.pnlEntregados.Size = New System.Drawing.Size(759, 59)
        Me.pnlEntregados.TabIndex = 124
        Me.pnlEntregados.Visible = False
        '
        'btnBuscarEntregados
        '
        Me.btnBuscarEntregados.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscarEntregados.Location = New System.Drawing.Point(714, 14)
        Me.btnBuscarEntregados.Name = "btnBuscarEntregados"
        Me.btnBuscarEntregados.Size = New System.Drawing.Size(30, 21)
        Me.btnBuscarEntregados.TabIndex = 126
        Me.btnBuscarEntregados.UseVisualStyleBackColor = True
        '
        'cmbAsunto
        '
        Me.cmbAsunto.FormattingEnabled = True
        Me.cmbAsunto.Location = New System.Drawing.Point(517, 14)
        Me.cmbAsunto.Name = "cmbAsunto"
        Me.cmbAsunto.Size = New System.Drawing.Size(177, 21)
        Me.cmbAsunto.TabIndex = 123
        '
        'cmbAgente
        '
        Me.cmbAgente.FormattingEnabled = True
        Me.cmbAgente.Location = New System.Drawing.Point(288, 14)
        Me.cmbAgente.Name = "cmbAgente"
        Me.cmbAgente.Size = New System.Drawing.Size(177, 21)
        Me.cmbAgente.TabIndex = 122
        '
        'cmbCliente
        '
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(51, 14)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(177, 21)
        Me.cmbCliente.TabIndex = 121
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(471, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "Asunto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(234, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 118
        Me.Label2.Text = "Agente"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Location = New System.Drawing.Point(3, 17)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(39, 13)
        Me.lblBuscar.TabIndex = 116
        Me.lblBuscar.Text = "Cliente"
        '
        'pnlDisponibles
        '
        Me.pnlDisponibles.Controls.Add(Me.Label6)
        Me.pnlDisponibles.Controls.Add(Me.txtModelo)
        Me.pnlDisponibles.Controls.Add(Me.btnBuscar)
        Me.pnlDisponibles.Location = New System.Drawing.Point(12, 78)
        Me.pnlDisponibles.Name = "pnlDisponibles"
        Me.pnlDisponibles.Size = New System.Drawing.Size(296, 59)
        Me.pnlDisponibles.TabIndex = 125
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 116
        Me.Label6.Text = "Modelo"
        '
        'txtModelo
        '
        Me.txtModelo.Location = New System.Drawing.Point(51, 19)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Size = New System.Drawing.Size(168, 20)
        Me.txtModelo.TabIndex = 114
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(234, 19)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(30, 21)
        Me.btnBuscar.TabIndex = 122
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 17)
        Me.Label1.TabIndex = 123
        Me.Label1.Text = "Inventario por"
        '
        'rdoDisponibles
        '
        Me.rdoDisponibles.AutoSize = True
        Me.rdoDisponibles.Location = New System.Drawing.Point(317, 42)
        Me.rdoDisponibles.Name = "rdoDisponibles"
        Me.rdoDisponibles.Size = New System.Drawing.Size(90, 17)
        Me.rdoDisponibles.TabIndex = 120
        Me.rdoDisponibles.TabStop = True
        Me.rdoDisponibles.Text = "Disponibilidad"
        Me.rdoDisponibles.UseVisualStyleBackColor = True
        '
        'rdoEntregados
        '
        Me.rdoEntregados.AutoSize = True
        Me.rdoEntregados.Location = New System.Drawing.Point(232, 42)
        Me.rdoEntregados.Name = "rdoEntregados"
        Me.rdoEntregados.Size = New System.Drawing.Size(79, 17)
        Me.rdoEntregados.TabIndex = 121
        Me.rdoEntregados.TabStop = True
        Me.rdoEntregados.Text = "Entregados"
        Me.rdoEntregados.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.pnlDatosBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 549)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1276, 60)
        Me.Panel2.TabIndex = 30
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1114, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 60)
        Me.pnlDatosBotones.TabIndex = 3
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(116, 8)
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
        Me.lblCerrar.Location = New System.Drawing.Point(119, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(27, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Salir"
        '
        'grdInventario
        '
        Me.grdInventario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdInventario.Location = New System.Drawing.Point(0, 226)
        Me.grdInventario.MainView = Me.grdVinventario
        Me.grdInventario.Name = "grdInventario"
        Me.grdInventario.Size = New System.Drawing.Size(1276, 323)
        Me.grdInventario.TabIndex = 31
        Me.grdInventario.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVinventario})
        '
        'grdVinventario
        '
        Me.grdVinventario.GridControl = Me.grdInventario
        Me.grdVinventario.Name = "grdVinventario"
        Me.grdVinventario.OptionsView.ShowAutoFilterRow = True
        '
        'InventarioMuestrasForm
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1276, 609)
        Me.Controls.Add(Me.grdInventario)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "InventarioMuestrasForm"
        Me.Text = "Inventario Muestras "
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.groupContenedor.ResumeLayout(False)
        Me.groupContenedor.PerformLayout()
        Me.pnlEntregados.ResumeLayout(False)
        Me.pnlEntregados.PerformLayout()
        Me.pnlDisponibles.ResumeLayout(False)
        Me.pnlDisponibles.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdInventario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVinventario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents lblImprimirEtiquetas As System.Windows.Forms.Label
    Friend WithEvents btnImprimirEtiquetas As System.Windows.Forms.Button
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents grdInventario As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVinventario As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents rdoDisponibles As System.Windows.Forms.RadioButton
    Friend WithEvents rdoEntregados As System.Windows.Forms.RadioButton
    Friend WithEvents pnlDisponibles As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtModelo As System.Windows.Forms.TextBox
    Friend WithEvents pnlEntregados As System.Windows.Forms.Panel
    Friend WithEvents cmbAsunto As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAgente As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnBuscarEntregados As System.Windows.Forms.Button
    Friend WithEvents rdoConfirmados As System.Windows.Forms.RadioButton
    Friend WithEvents chboxSeleccionarTodo As CheckBox
    Friend WithEvents groupContenedor As GroupBox
    Friend WithEvents cmbImpresion As ComboBox
    Friend WithEvents chkCaja As CheckBox
    Friend WithEvents chkSuela As CheckBox
    Friend WithEvents lblImpresora As Label
    Friend WithEvents chkColgante As CheckBox
    Friend WithEvents lbl_EscaneoMultiple As Label
    Friend WithEvents btn_EscaneoMultiple As Button
End Class
