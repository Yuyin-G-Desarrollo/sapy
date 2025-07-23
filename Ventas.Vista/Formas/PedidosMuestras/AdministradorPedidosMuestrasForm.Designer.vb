<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdministradorPedidosMuestrasForm
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnexportarpiezas = New System.Windows.Forms.Button()
        Me.lblEnviarPorAutorizar = New System.Windows.Forms.Label()
        Me.btnEnviarPorAutorizar = New System.Windows.Forms.Button()
        Me.lblApartarPiezas = New System.Windows.Forms.Label()
        Me.btnPorApartar = New System.Windows.Forms.Button()
        Me.chkMostrarPrecio = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExportarExcelDet = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnPdf = New System.Windows.Forms.Button()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblAutorizar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnConfirmarApartado = New System.Windows.Forms.Button()
        Me.btnRechazar = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlEtiquetas = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lbMostrar = New System.Windows.Forms.Label()
        Me.btnMotrar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdPedidosMuestras = New DevExpress.XtraGrid.GridControl()
        Me.grdVpedidosMuestras = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdPedidosMuestraDet = New DevExpress.XtraGrid.GridControl()
        Me.grdVPedidosMuestraDet = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboxNaveCedis = New System.Windows.Forms.ComboBox()
        Me.grpApartados = New System.Windows.Forms.GroupBox()
        Me.rdoSeguimiento = New System.Windows.Forms.RadioButton()
        Me.rdoFinalizado = New System.Windows.Forms.RadioButton()
        Me.rdoPorApartar = New System.Windows.Forms.RadioButton()
        Me.chboxSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaAl = New System.Windows.Forms.Label()
        Me.pnlBuscarSeg = New System.Windows.Forms.Panel()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnBuscarSeg = New System.Windows.Forms.Button()
        Me.txtBuscarSeg = New System.Windows.Forms.TextBox()
        Me.lblFechaDel = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rdoInventarioPiezasMuestras = New System.Windows.Forms.RadioButton()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlEtiquetas.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdPedidosMuestras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVpedidosMuestras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPedidosMuestraDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVPedidosMuestraDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.grpApartados.SuspendLayout()
        Me.pnlBuscarSeg.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1276, 84)
        Me.pnlEncabezado.TabIndex = 24
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(703, 84)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.Label15)
        Me.Panel14.Controls.Add(Me.btnexportarpiezas)
        Me.Panel14.Controls.Add(Me.lblEnviarPorAutorizar)
        Me.Panel14.Controls.Add(Me.btnEnviarPorAutorizar)
        Me.Panel14.Controls.Add(Me.lblApartarPiezas)
        Me.Panel14.Controls.Add(Me.btnPorApartar)
        Me.Panel14.Controls.Add(Me.chkMostrarPrecio)
        Me.Panel14.Controls.Add(Me.Label2)
        Me.Panel14.Controls.Add(Me.btnExportarExcelDet)
        Me.Panel14.Controls.Add(Me.Label1)
        Me.Panel14.Controls.Add(Me.Label17)
        Me.Panel14.Controls.Add(Me.btnPdf)
        Me.Panel14.Controls.Add(Me.btnExportarExcel)
        Me.Panel14.Controls.Add(Me.lblAutorizar)
        Me.Panel14.Controls.Add(Me.lblCancelar)
        Me.Panel14.Controls.Add(Me.btnConfirmarApartado)
        Me.Panel14.Controls.Add(Me.btnRechazar)
        Me.Panel14.Controls.Add(Me.lblEditar)
        Me.Panel14.Controls.Add(Me.btnEditar)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(703, 84)
        Me.Panel14.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label15.Location = New System.Drawing.Point(442, 44)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 26)
        Me.Label15.TabIndex = 101
        Me.Label15.Text = "     Exportar  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Inventario Piezas"
        '
        'btnexportarpiezas
        '
        Me.btnexportarpiezas.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnexportarpiezas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnexportarpiezas.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnexportarpiezas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnexportarpiezas.Location = New System.Drawing.Point(461, 9)
        Me.btnexportarpiezas.Name = "btnexportarpiezas"
        Me.btnexportarpiezas.Size = New System.Drawing.Size(32, 32)
        Me.btnexportarpiezas.TabIndex = 100
        Me.btnexportarpiezas.UseVisualStyleBackColor = True
        '
        'lblEnviarPorAutorizar
        '
        Me.lblEnviarPorAutorizar.AutoSize = True
        Me.lblEnviarPorAutorizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEnviarPorAutorizar.Location = New System.Drawing.Point(212, 44)
        Me.lblEnviarPorAutorizar.Name = "lblEnviarPorAutorizar"
        Me.lblEnviarPorAutorizar.Size = New System.Drawing.Size(67, 26)
        Me.lblEnviarPorAutorizar.TabIndex = 99
        Me.lblEnviarPorAutorizar.Text = "Enviar a " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Por Autorizar"
        Me.lblEnviarPorAutorizar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnEnviarPorAutorizar
        '
        Me.btnEnviarPorAutorizar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnEnviarPorAutorizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnEnviarPorAutorizar.Image = Global.Ventas.Vista.My.Resources.Resources.aceptar_32
        Me.btnEnviarPorAutorizar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEnviarPorAutorizar.Location = New System.Drawing.Point(228, 9)
        Me.btnEnviarPorAutorizar.Name = "btnEnviarPorAutorizar"
        Me.btnEnviarPorAutorizar.Size = New System.Drawing.Size(32, 32)
        Me.btnEnviarPorAutorizar.TabIndex = 98
        Me.btnEnviarPorAutorizar.UseVisualStyleBackColor = True
        '
        'lblApartarPiezas
        '
        Me.lblApartarPiezas.AutoSize = True
        Me.lblApartarPiezas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblApartarPiezas.Location = New System.Drawing.Point(170, 44)
        Me.lblApartarPiezas.Name = "lblApartarPiezas"
        Me.lblApartarPiezas.Size = New System.Drawing.Size(41, 26)
        Me.lblApartarPiezas.TabIndex = 97
        Me.lblApartarPiezas.Text = "Apartar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Piezas"
        Me.lblApartarPiezas.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnPorApartar
        '
        Me.btnPorApartar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnPorApartar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnPorApartar.Image = Global.Ventas.Vista.My.Resources.Resources.pares
        Me.btnPorApartar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPorApartar.Location = New System.Drawing.Point(174, 9)
        Me.btnPorApartar.Name = "btnPorApartar"
        Me.btnPorApartar.Size = New System.Drawing.Size(32, 32)
        Me.btnPorApartar.TabIndex = 96
        Me.btnPorApartar.UseVisualStyleBackColor = True
        '
        'chkMostrarPrecio
        '
        Me.chkMostrarPrecio.AutoSize = True
        Me.chkMostrarPrecio.Checked = True
        Me.chkMostrarPrecio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMostrarPrecio.Location = New System.Drawing.Point(536, 25)
        Me.chkMostrarPrecio.Name = "chkMostrarPrecio"
        Me.chkMostrarPrecio.Size = New System.Drawing.Size(133, 17)
        Me.chkMostrarPrecio.TabIndex = 92
        Me.chkMostrarPrecio.Text = "Mostrar Precio en PDF"
        Me.chkMostrarPrecio.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(388, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 26)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "Exportar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Detalle" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnExportarExcelDet
        '
        Me.btnExportarExcelDet.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcelDet.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcelDet.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcelDet.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcelDet.Location = New System.Drawing.Point(391, 9)
        Me.btnExportarExcelDet.Name = "btnExportarExcelDet"
        Me.btnExportarExcelDet.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcelDet.TabIndex = 90
        Me.btnExportarExcelDet.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(347, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "PDF"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label17.Location = New System.Drawing.Point(290, 44)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 87
        Me.Label17.Text = "Exportar"
        '
        'btnPdf
        '
        Me.btnPdf.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnPdf.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnPdf.Image = Global.Ventas.Vista.My.Resources.Resources.pdf_32
        Me.btnPdf.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPdf.Location = New System.Drawing.Point(343, 9)
        Me.btnPdf.Name = "btnPdf"
        Me.btnPdf.Size = New System.Drawing.Size(32, 32)
        Me.btnPdf.TabIndex = 88
        Me.btnPdf.UseVisualStyleBackColor = True
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcel.Location = New System.Drawing.Point(293, 9)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 86
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblAutorizar
        '
        Me.lblAutorizar.AutoSize = True
        Me.lblAutorizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAutorizar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAutorizar.Location = New System.Drawing.Point(60, 44)
        Me.lblAutorizar.Name = "lblAutorizar"
        Me.lblAutorizar.Size = New System.Drawing.Size(48, 13)
        Me.lblAutorizar.TabIndex = 84
        Me.lblAutorizar.Text = "Autorizar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(111, 44)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelar.TabIndex = 85
        Me.lblCancelar.Text = "Cancelar"
        '
        'btnConfirmarApartado
        '
        Me.btnConfirmarApartado.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnConfirmarApartado.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnConfirmarApartado.Image = Global.Ventas.Vista.My.Resources.Resources.autorizar_32
        Me.btnConfirmarApartado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnConfirmarApartado.Location = New System.Drawing.Point(66, 9)
        Me.btnConfirmarApartado.Name = "btnConfirmarApartado"
        Me.btnConfirmarApartado.Size = New System.Drawing.Size(32, 32)
        Me.btnConfirmarApartado.TabIndex = 82
        Me.btnConfirmarApartado.UseVisualStyleBackColor = True
        '
        'btnRechazar
        '
        Me.btnRechazar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnRechazar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnRechazar.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar321
        Me.btnRechazar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRechazar.Location = New System.Drawing.Point(114, 9)
        Me.btnRechazar.Name = "btnRechazar"
        Me.btnRechazar.Size = New System.Drawing.Size(32, 32)
        Me.btnRechazar.TabIndex = 83
        Me.btnRechazar.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(21, 44)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 7
        Me.lblEditar.Text = "Editar"
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Ventas.Vista.My.Resources.Resources.editar_321
        Me.btnEditar.Location = New System.Drawing.Point(22, 9)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 5
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(749, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(527, 84)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(120, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(318, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Administrador de Pedidos de Muestras"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(444, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 84)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.pnlEtiquetas)
        Me.Panel2.Controls.Add(Me.pnlDatosBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 531)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1276, 78)
        Me.Panel2.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "CAPT - Capturadas"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(4, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 13)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "AUTO - Autorizadas"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(321, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(161, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "DISP - Disponible para el Pedido"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(321, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "ECTE - Enviadas a Cliente"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(142, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "CONF - Confirmadas"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(142, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "ENAV - Enviadas por Nave"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(142, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "ENPR - En Producción"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Cantidad de Piezas"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(321, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "CANC - Canceladas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "APAR - Apartadas"
        '
        'pnlEtiquetas
        '
        Me.pnlEtiquetas.Controls.Add(Me.Label7)
        Me.pnlEtiquetas.Location = New System.Drawing.Point(606, 0)
        Me.pnlEtiquetas.Name = "pnlEtiquetas"
        Me.pnlEtiquetas.Size = New System.Drawing.Size(438, 75)
        Me.pnlEtiquetas.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(107, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(167, 26)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Una vez concluido el apartado," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "dar click en Enviar a Por Autorizar"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lbMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnMotrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1114, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 78)
        Me.pnlDatosBotones.TabIndex = 2
        '
        'lbMostrar
        '
        Me.lbMostrar.AutoSize = True
        Me.lbMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMostrar.Location = New System.Drawing.Point(47, 49)
        Me.lbMostrar.Name = "lbMostrar"
        Me.lbMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lbMostrar.TabIndex = 2
        Me.lbMostrar.Text = "Mostrar"
        '
        'btnMotrar
        '
        Me.btnMotrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMotrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMotrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMotrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMotrar.Location = New System.Drawing.Point(50, 17)
        Me.btnMotrar.Name = "btnMotrar"
        Me.btnMotrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMotrar.TabIndex = 3
        Me.btnMotrar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(95, 17)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(35, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(95, 49)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'grdPedidosMuestras
        '
        Me.grdPedidosMuestras.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdPedidosMuestras.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdPedidosMuestras.Location = New System.Drawing.Point(0, 0)
        Me.grdPedidosMuestras.MainView = Me.grdVpedidosMuestras
        Me.grdPedidosMuestras.Name = "grdPedidosMuestras"
        Me.grdPedidosMuestras.Size = New System.Drawing.Size(1276, 377)
        Me.grdPedidosMuestras.TabIndex = 27
        Me.grdPedidosMuestras.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVpedidosMuestras})
        '
        'grdVpedidosMuestras
        '
        Me.grdVpedidosMuestras.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.grdVpedidosMuestras.Appearance.EvenRow.Options.UseBackColor = True
        Me.grdVpedidosMuestras.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdVpedidosMuestras.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White
        Me.grdVpedidosMuestras.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grdVpedidosMuestras.Appearance.FocusedRow.Options.UseForeColor = True
        Me.grdVpedidosMuestras.Appearance.OddRow.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.grdVpedidosMuestras.Appearance.OddRow.Options.UseBackColor = True
        Me.grdVpedidosMuestras.GridControl = Me.grdPedidosMuestras
        Me.grdVpedidosMuestras.Name = "grdVpedidosMuestras"
        Me.grdVpedidosMuestras.OptionsView.ShowAutoFilterRow = True
        '
        'grdPedidosMuestraDet
        '
        Me.grdPedidosMuestraDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPedidosMuestraDet.Location = New System.Drawing.Point(0, 0)
        Me.grdPedidosMuestraDet.MainView = Me.grdVPedidosMuestraDet
        Me.grdPedidosMuestraDet.Name = "grdPedidosMuestraDet"
        Me.grdPedidosMuestraDet.Size = New System.Drawing.Size(1276, 377)
        Me.grdPedidosMuestraDet.TabIndex = 32
        Me.grdPedidosMuestraDet.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVPedidosMuestraDet})
        Me.grdPedidosMuestraDet.Visible = False
        '
        'grdVPedidosMuestraDet
        '
        Me.grdVPedidosMuestraDet.GridControl = Me.grdPedidosMuestraDet
        Me.grdVPedidosMuestraDet.Name = "grdVPedidosMuestraDet"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.cboxNaveCedis)
        Me.Panel1.Controls.Add(Me.grpApartados)
        Me.Panel1.Controls.Add(Me.chboxSeleccionarTodo)
        Me.Panel1.Controls.Add(Me.dtpFechaFin)
        Me.Panel1.Controls.Add(Me.dtpFechaInicio)
        Me.Panel1.Controls.Add(Me.lblFechaAl)
        Me.Panel1.Controls.Add(Me.pnlBuscarSeg)
        Me.Panel1.Controls.Add(Me.lblFechaDel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 84)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1276, 70)
        Me.Panel1.TabIndex = 33
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(4, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 13)
        Me.Label14.TabIndex = 169
        Me.Label14.Text = "*Cedis"
        '
        'cboxNaveCedis
        '
        Me.cboxNaveCedis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxNaveCedis.FormattingEnabled = True
        Me.cboxNaveCedis.Location = New System.Drawing.Point(10, 26)
        Me.cboxNaveCedis.Name = "cboxNaveCedis"
        Me.cboxNaveCedis.Size = New System.Drawing.Size(159, 21)
        Me.cboxNaveCedis.TabIndex = 168
        '
        'grpApartados
        '
        Me.grpApartados.Controls.Add(Me.rdoInventarioPiezasMuestras)
        Me.grpApartados.Controls.Add(Me.rdoSeguimiento)
        Me.grpApartados.Controls.Add(Me.rdoFinalizado)
        Me.grpApartados.Controls.Add(Me.rdoPorApartar)
        Me.grpApartados.Location = New System.Drawing.Point(175, 2)
        Me.grpApartados.Name = "grpApartados"
        Me.grpApartados.Size = New System.Drawing.Size(264, 63)
        Me.grpApartados.TabIndex = 167
        Me.grpApartados.TabStop = False
        Me.grpApartados.Text = "Filtro Busqueda"
        '
        'rdoSeguimiento
        '
        Me.rdoSeguimiento.AutoSize = True
        Me.rdoSeguimiento.Location = New System.Drawing.Point(21, 17)
        Me.rdoSeguimiento.Name = "rdoSeguimiento"
        Me.rdoSeguimiento.Size = New System.Drawing.Size(83, 17)
        Me.rdoSeguimiento.TabIndex = 115
        Me.rdoSeguimiento.TabStop = True
        Me.rdoSeguimiento.Text = "Seguimiento"
        Me.rdoSeguimiento.UseVisualStyleBackColor = True
        '
        'rdoFinalizado
        '
        Me.rdoFinalizado.AutoSize = True
        Me.rdoFinalizado.Location = New System.Drawing.Point(21, 39)
        Me.rdoFinalizado.Name = "rdoFinalizado"
        Me.rdoFinalizado.Size = New System.Drawing.Size(77, 17)
        Me.rdoFinalizado.TabIndex = 116
        Me.rdoFinalizado.TabStop = True
        Me.rdoFinalizado.Text = "Finalizados"
        Me.rdoFinalizado.UseVisualStyleBackColor = True
        '
        'rdoPorApartar
        '
        Me.rdoPorApartar.AutoSize = True
        Me.rdoPorApartar.Location = New System.Drawing.Point(149, 17)
        Me.rdoPorApartar.Name = "rdoPorApartar"
        Me.rdoPorApartar.Size = New System.Drawing.Size(78, 17)
        Me.rdoPorApartar.TabIndex = 121
        Me.rdoPorApartar.TabStop = True
        Me.rdoPorApartar.Text = "Por Apartar"
        Me.rdoPorApartar.UseVisualStyleBackColor = True
        '
        'chboxSeleccionarTodo
        '
        Me.chboxSeleccionarTodo.AutoSize = True
        Me.chboxSeleccionarTodo.Location = New System.Drawing.Point(445, 41)
        Me.chboxSeleccionarTodo.Name = "chboxSeleccionarTodo"
        Me.chboxSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chboxSeleccionarTodo.TabIndex = 120
        Me.chboxSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chboxSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = ""
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(633, 4)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(109, 20)
        Me.dtpFechaFin.TabIndex = 118
        Me.dtpFechaFin.Value = New Date(2016, 10, 20, 0, 0, 0, 0)
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CustomFormat = ""
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(502, 4)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(109, 20)
        Me.dtpFechaInicio.TabIndex = 117
        Me.dtpFechaInicio.Value = New Date(2016, 10, 20, 0, 0, 0, 0)
        '
        'lblFechaAl
        '
        Me.lblFechaAl.AutoSize = True
        Me.lblFechaAl.Location = New System.Drawing.Point(614, 8)
        Me.lblFechaAl.Name = "lblFechaAl"
        Me.lblFechaAl.Size = New System.Drawing.Size(16, 13)
        Me.lblFechaAl.TabIndex = 0
        Me.lblFechaAl.Text = "Al"
        '
        'pnlBuscarSeg
        '
        Me.pnlBuscarSeg.Controls.Add(Me.lblBuscar)
        Me.pnlBuscarSeg.Controls.Add(Me.btnBuscarSeg)
        Me.pnlBuscarSeg.Controls.Add(Me.txtBuscarSeg)
        Me.pnlBuscarSeg.Location = New System.Drawing.Point(749, 6)
        Me.pnlBuscarSeg.Name = "pnlBuscarSeg"
        Me.pnlBuscarSeg.Size = New System.Drawing.Size(279, 59)
        Me.pnlBuscarSeg.TabIndex = 114
        Me.pnlBuscarSeg.Visible = False
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Location = New System.Drawing.Point(3, 19)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(40, 13)
        Me.lblBuscar.TabIndex = 116
        Me.lblBuscar.Text = "Buscar"
        '
        'btnBuscarSeg
        '
        Me.btnBuscarSeg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarSeg.Location = New System.Drawing.Point(234, 19)
        Me.btnBuscarSeg.Name = "btnBuscarSeg"
        Me.btnBuscarSeg.Size = New System.Drawing.Size(34, 20)
        Me.btnBuscarSeg.TabIndex = 115
        Me.btnBuscarSeg.UseVisualStyleBackColor = True
        '
        'txtBuscarSeg
        '
        Me.txtBuscarSeg.Location = New System.Drawing.Point(60, 19)
        Me.txtBuscarSeg.Name = "txtBuscarSeg"
        Me.txtBuscarSeg.Size = New System.Drawing.Size(168, 20)
        Me.txtBuscarSeg.TabIndex = 114
        '
        'lblFechaDel
        '
        Me.lblFechaDel.AutoSize = True
        Me.lblFechaDel.Location = New System.Drawing.Point(442, 8)
        Me.lblFechaDel.Name = "lblFechaDel"
        Me.lblFechaDel.Size = New System.Drawing.Size(56, 13)
        Me.lblFechaDel.TabIndex = 114
        Me.lblFechaDel.Text = "Fecha Del"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grdPedidosMuestraDet)
        Me.Panel3.Controls.Add(Me.grdPedidosMuestras)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 154)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1276, 377)
        Me.Panel3.TabIndex = 34
        '
        'rdoInventarioPiezasMuestras
        '
        Me.rdoInventarioPiezasMuestras.AutoSize = True
        Me.rdoInventarioPiezasMuestras.Location = New System.Drawing.Point(149, 38)
        Me.rdoInventarioPiezasMuestras.Name = "rdoInventarioPiezasMuestras"
        Me.rdoInventarioPiezasMuestras.Size = New System.Drawing.Size(106, 17)
        Me.rdoInventarioPiezasMuestras.TabIndex = 122
        Me.rdoInventarioPiezasMuestras.TabStop = True
        Me.rdoInventarioPiezasMuestras.Text = "Inventario Piezas"
        Me.rdoInventarioPiezasMuestras.UseVisualStyleBackColor = True
        '
        'AdministradorPedidosMuestrasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1276, 609)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "AdministradorPedidosMuestrasForm"
        Me.Text = "Administrador de pedidos de muestras "
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlEtiquetas.ResumeLayout(False)
        Me.pnlEtiquetas.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdPedidosMuestras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVpedidosMuestras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPedidosMuestraDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVPedidosMuestraDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grpApartados.ResumeLayout(False)
        Me.grpApartados.PerformLayout()
        Me.pnlBuscarSeg.ResumeLayout(False)
        Me.pnlBuscarSeg.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents grdPedidosMuestras As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVpedidosMuestras As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnConfirmarApartado As System.Windows.Forms.Button
    Friend WithEvents btnRechazar As System.Windows.Forms.Button
    Friend WithEvents lblAutorizar As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnPdf As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnExportarExcelDet As System.Windows.Forms.Button
    Friend WithEvents grdPedidosMuestraDet As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVPedidosMuestraDet As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents chkMostrarPrecio As CheckBox
    Friend WithEvents pnlEtiquetas As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblEnviarPorAutorizar As Label
    Friend WithEvents btnEnviarPorAutorizar As Button
    Friend WithEvents lblApartarPiezas As Label
    Friend WithEvents btnPorApartar As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lbMostrar As Label
    Friend WithEvents btnMotrar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents cboxNaveCedis As ComboBox
    Friend WithEvents grpApartados As GroupBox
    Friend WithEvents rdoSeguimiento As RadioButton
    Friend WithEvents rdoFinalizado As RadioButton
    Friend WithEvents rdoPorApartar As RadioButton
    Friend WithEvents chboxSeleccionarTodo As CheckBox
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents lblFechaAl As Label
    Friend WithEvents pnlBuscarSeg As Panel
    Friend WithEvents lblBuscar As Label
    Friend WithEvents btnBuscarSeg As Button
    Friend WithEvents txtBuscarSeg As TextBox
    Friend WithEvents lblFechaDel As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents btnexportarpiezas As Button
    Friend WithEvents rdoInventarioPiezasMuestras As RadioButton
End Class
