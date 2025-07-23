<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfClientesEspecialesOrden
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfClientesEspecialesOrden))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlBotonera = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.grpBotones = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblIdSimulacion = New System.Windows.Forms.Label()
        Me.lblNombreSimulacion = New System.Windows.Forms.Label()
        Me.chkSeleccionarTodoConf = New System.Windows.Forms.CheckBox()
        Me.chkSeleccionarTodoOrigen = New System.Windows.Forms.CheckBox()
        Me.pnlOcultar = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.cmbSimulaciones = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlPasarRegistros = New System.Windows.Forms.Panel()
        Me.btnPasarVariosClientes = New System.Windows.Forms.Button()
        Me.btnRegresarVariosClientes = New System.Windows.Forms.Button()
        Me.grdClientesOrigen = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Splitter2 = New System.Windows.Forms.Splitter()
        Me.pnlAnteriores = New System.Windows.Forms.Panel()
        Me.grdAnteriores = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlComboAnteriores = New System.Windows.Forms.Panel()
        Me.grdConfiguracion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlBotonera.SuspendLayout()
        Me.grpBotones.SuspendLayout()
        Me.pnlOcultar.SuspendLayout()
        Me.pnlPasarRegistros.SuspendLayout()
        CType(Me.grdClientesOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAnteriores.SuspendLayout()
        CType(Me.grdAnteriores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlComboAnteriores.SuspendLayout()
        CType(Me.grdConfiguracion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1084, 60)
        Me.pnlHeader.TabIndex = 4
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(732, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(352, 60)
        Me.pnlTitulo.TabIndex = 49
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(3, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(282, 20)
        Me.lblTitulo.TabIndex = 9
        Me.lblTitulo.Text = "Configuración Clientes Especiales"
        '
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.pnlBotonera)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 496)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1084, 60)
        Me.pnlEstado.TabIndex = 5
        '
        'pnlBotonera
        '
        Me.pnlBotonera.Controls.Add(Me.Label3)
        Me.pnlBotonera.Controls.Add(Me.btnCancelar)
        Me.pnlBotonera.Controls.Add(Me.lblCancelar)
        Me.pnlBotonera.Controls.Add(Me.btnGuardar)
        Me.pnlBotonera.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonera.Location = New System.Drawing.Point(884, 0)
        Me.pnlBotonera.Name = "pnlBotonera"
        Me.pnlBotonera.Size = New System.Drawing.Size(200, 60)
        Me.pnlBotonera.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(82, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 26)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Guardar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Orden"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(144, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(143, 34)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.reasignar
        Me.btnGuardar.Location = New System.Drawing.Point(85, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'grpBotones
        '
        Me.grpBotones.BackColor = System.Drawing.Color.Transparent
        Me.grpBotones.Controls.Add(Me.Label10)
        Me.grpBotones.Controls.Add(Me.lblIdSimulacion)
        Me.grpBotones.Controls.Add(Me.lblNombreSimulacion)
        Me.grpBotones.Controls.Add(Me.chkSeleccionarTodoConf)
        Me.grpBotones.Controls.Add(Me.chkSeleccionarTodoOrigen)
        Me.grpBotones.Controls.Add(Me.pnlOcultar)
        Me.grpBotones.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBotones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grpBotones.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grpBotones.Location = New System.Drawing.Point(0, 60)
        Me.grpBotones.Name = "grpBotones"
        Me.grpBotones.Size = New System.Drawing.Size(1084, 35)
        Me.grpBotones.TabIndex = 47
        Me.grpBotones.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label10.Location = New System.Drawing.Point(171, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(126, 15)
        Me.Label10.TabIndex = 100
        Me.Label10.Text = "Simulación actual:"
        '
        'lblIdSimulacion
        '
        Me.lblIdSimulacion.AutoSize = True
        Me.lblIdSimulacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdSimulacion.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblIdSimulacion.Location = New System.Drawing.Point(155, 17)
        Me.lblIdSimulacion.Name = "lblIdSimulacion"
        Me.lblIdSimulacion.Size = New System.Drawing.Size(19, 15)
        Me.lblIdSimulacion.TabIndex = 99
        Me.lblIdSimulacion.Text = "---"
        Me.lblIdSimulacion.Visible = False
        '
        'lblNombreSimulacion
        '
        Me.lblNombreSimulacion.AutoSize = True
        Me.lblNombreSimulacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreSimulacion.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNombreSimulacion.Location = New System.Drawing.Point(299, 15)
        Me.lblNombreSimulacion.Name = "lblNombreSimulacion"
        Me.lblNombreSimulacion.Size = New System.Drawing.Size(22, 15)
        Me.lblNombreSimulacion.TabIndex = 99
        Me.lblNombreSimulacion.Text = "---"
        '
        'chkSeleccionarTodoConf
        '
        Me.chkSeleccionarTodoConf.AutoSize = True
        Me.chkSeleccionarTodoConf.Location = New System.Drawing.Point(574, 17)
        Me.chkSeleccionarTodoConf.Name = "chkSeleccionarTodoConf"
        Me.chkSeleccionarTodoConf.Size = New System.Drawing.Size(106, 17)
        Me.chkSeleccionarTodoConf.TabIndex = 82
        Me.chkSeleccionarTodoConf.Text = "Seleccionar todo"
        Me.chkSeleccionarTodoConf.UseVisualStyleBackColor = True
        '
        'chkSeleccionarTodoOrigen
        '
        Me.chkSeleccionarTodoOrigen.AutoSize = True
        Me.chkSeleccionarTodoOrigen.Location = New System.Drawing.Point(12, 17)
        Me.chkSeleccionarTodoOrigen.Name = "chkSeleccionarTodoOrigen"
        Me.chkSeleccionarTodoOrigen.Size = New System.Drawing.Size(106, 17)
        Me.chkSeleccionarTodoOrigen.TabIndex = 80
        Me.chkSeleccionarTodoOrigen.Text = "Seleccionar todo"
        Me.chkSeleccionarTodoOrigen.UseVisualStyleBackColor = True
        '
        'pnlOcultar
        '
        Me.pnlOcultar.Controls.Add(Me.btnArriba)
        Me.pnlOcultar.Controls.Add(Me.btnAbajo)
        Me.pnlOcultar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOcultar.Location = New System.Drawing.Point(1002, 16)
        Me.pnlOcultar.Name = "pnlOcultar"
        Me.pnlOcultar.Size = New System.Drawing.Size(79, 16)
        Me.pnlOcultar.TabIndex = 38
        Me.pnlOcultar.Visible = False
        '
        'btnArriba
        '
        Me.btnArriba.AccessibleName = "0"
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(15, 1)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 3
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.AccessibleName = "0"
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(45, 1)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 4
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'cmbSimulaciones
        '
        Me.cmbSimulaciones.FormattingEnabled = True
        Me.cmbSimulaciones.Location = New System.Drawing.Point(77, 5)
        Me.cmbSimulaciones.Name = "cmbSimulaciones"
        Me.cmbSimulaciones.Size = New System.Drawing.Size(305, 21)
        Me.cmbSimulaciones.TabIndex = 80
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Simulación: "
        '
        'pnlPasarRegistros
        '
        Me.pnlPasarRegistros.Controls.Add(Me.btnPasarVariosClientes)
        Me.pnlPasarRegistros.Controls.Add(Me.btnRegresarVariosClientes)
        Me.pnlPasarRegistros.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlPasarRegistros.Location = New System.Drawing.Point(525, 95)
        Me.pnlPasarRegistros.Name = "pnlPasarRegistros"
        Me.pnlPasarRegistros.Size = New System.Drawing.Size(40, 401)
        Me.pnlPasarRegistros.TabIndex = 80
        '
        'btnPasarVariosClientes
        '
        Me.btnPasarVariosClientes.AccessibleName = "0"
        Me.btnPasarVariosClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPasarVariosClientes.Location = New System.Drawing.Point(8, 124)
        Me.btnPasarVariosClientes.Name = "btnPasarVariosClientes"
        Me.btnPasarVariosClientes.Size = New System.Drawing.Size(25, 30)
        Me.btnPasarVariosClientes.TabIndex = 87
        Me.btnPasarVariosClientes.Text = ">>"
        Me.btnPasarVariosClientes.UseVisualStyleBackColor = True
        '
        'btnRegresarVariosClientes
        '
        Me.btnRegresarVariosClientes.AccessibleName = "0"
        Me.btnRegresarVariosClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegresarVariosClientes.Location = New System.Drawing.Point(8, 176)
        Me.btnRegresarVariosClientes.Name = "btnRegresarVariosClientes"
        Me.btnRegresarVariosClientes.Size = New System.Drawing.Size(25, 30)
        Me.btnRegresarVariosClientes.TabIndex = 86
        Me.btnRegresarVariosClientes.Text = "<<"
        Me.btnRegresarVariosClientes.UseVisualStyleBackColor = True
        '
        'grdClientesOrigen
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientesOrigen.DisplayLayout.Appearance = Appearance1
        Me.grdClientesOrigen.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdClientesOrigen.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClientesOrigen.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Row
        Me.grdClientesOrigen.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdClientesOrigen.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClientesOrigen.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientesOrigen.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdClientesOrigen.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClientesOrigen.Dock = System.Windows.Forms.DockStyle.Left
        Me.grdClientesOrigen.Location = New System.Drawing.Point(0, 95)
        Me.grdClientesOrigen.Name = "grdClientesOrigen"
        Me.grdClientesOrigen.Size = New System.Drawing.Size(522, 401)
        Me.grdClientesOrigen.TabIndex = 81
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.Silver
        Me.Splitter1.Location = New System.Drawing.Point(522, 95)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 401)
        Me.Splitter1.TabIndex = 89
        Me.Splitter1.TabStop = False
        '
        'Splitter2
        '
        Me.Splitter2.BackColor = System.Drawing.Color.Silver
        Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter2.Location = New System.Drawing.Point(565, 309)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(519, 3)
        Me.Splitter2.TabIndex = 90
        Me.Splitter2.TabStop = False
        '
        'pnlAnteriores
        '
        Me.pnlAnteriores.Controls.Add(Me.grdAnteriores)
        Me.pnlAnteriores.Controls.Add(Me.pnlComboAnteriores)
        Me.pnlAnteriores.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAnteriores.Location = New System.Drawing.Point(565, 312)
        Me.pnlAnteriores.Name = "pnlAnteriores"
        Me.pnlAnteriores.Size = New System.Drawing.Size(519, 184)
        Me.pnlAnteriores.TabIndex = 91
        '
        'grdAnteriores
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAnteriores.DisplayLayout.Appearance = Appearance3
        Me.grdAnteriores.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdAnteriores.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdAnteriores.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Row
        Me.grdAnteriores.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdAnteriores.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdAnteriores.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAnteriores.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdAnteriores.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdAnteriores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAnteriores.Location = New System.Drawing.Point(0, 31)
        Me.grdAnteriores.Name = "grdAnteriores"
        Me.grdAnteriores.Size = New System.Drawing.Size(519, 153)
        Me.grdAnteriores.TabIndex = 83
        Me.grdAnteriores.Text = "Ordenamiento Simulaciones Anterior"
        '
        'pnlComboAnteriores
        '
        Me.pnlComboAnteriores.Controls.Add(Me.cmbSimulaciones)
        Me.pnlComboAnteriores.Controls.Add(Me.Label1)
        Me.pnlComboAnteriores.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlComboAnteriores.Location = New System.Drawing.Point(0, 0)
        Me.pnlComboAnteriores.Name = "pnlComboAnteriores"
        Me.pnlComboAnteriores.Size = New System.Drawing.Size(519, 31)
        Me.pnlComboAnteriores.TabIndex = 84
        '
        'grdConfiguracion
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdConfiguracion.DisplayLayout.Appearance = Appearance5
        Me.grdConfiguracion.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdConfiguracion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdConfiguracion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Row
        Me.grdConfiguracion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdConfiguracion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdConfiguracion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdConfiguracion.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdConfiguracion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdConfiguracion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdConfiguracion.Location = New System.Drawing.Point(565, 95)
        Me.grdConfiguracion.Name = "grdConfiguracion"
        Me.grdConfiguracion.Size = New System.Drawing.Size(519, 214)
        Me.grdConfiguracion.TabIndex = 6
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(290, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'frmConfClientesEspecialesOrden
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1084, 556)
        Me.Controls.Add(Me.grdConfiguracion)
        Me.Controls.Add(Me.Splitter2)
        Me.Controls.Add(Me.pnlAnteriores)
        Me.Controls.Add(Me.pnlPasarRegistros)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.grdClientesOrigen)
        Me.Controls.Add(Me.grpBotones)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmConfClientesEspecialesOrden"
        Me.Text = "Configuración Clientes Especiales"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlBotonera.ResumeLayout(False)
        Me.pnlBotonera.PerformLayout()
        Me.grpBotones.ResumeLayout(False)
        Me.grpBotones.PerformLayout()
        Me.pnlOcultar.ResumeLayout(False)
        Me.pnlPasarRegistros.ResumeLayout(False)
        CType(Me.grdClientesOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAnteriores.ResumeLayout(False)
        CType(Me.grdAnteriores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlComboAnteriores.ResumeLayout(False)
        Me.pnlComboAnteriores.PerformLayout()
        CType(Me.grdConfiguracion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBotonera As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents grpBotones As System.Windows.Forms.GroupBox
    Friend WithEvents pnlOcultar As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents cmbSimulaciones As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlPasarRegistros As System.Windows.Forms.Panel
    Friend WithEvents btnPasarVariosClientes As System.Windows.Forms.Button
    Friend WithEvents btnRegresarVariosClientes As System.Windows.Forms.Button
    Friend WithEvents grdClientesOrigen As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents chkSeleccionarTodoOrigen As System.Windows.Forms.CheckBox
    Friend WithEvents chkSeleccionarTodoConf As System.Windows.Forms.CheckBox
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents pnlAnteriores As System.Windows.Forms.Panel
    Friend WithEvents grdAnteriores As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlComboAnteriores As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblNombreSimulacion As System.Windows.Forms.Label
    Friend WithEvents lblIdSimulacion As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grdConfiguracion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents PictureBox1 As PictureBox
End Class
