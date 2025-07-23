<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DevolucionCliente_Filtro_PedidosDocumentos_PorCliente_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DevolucionCliente_Filtro_PedidosDocumentos_PorCliente_Form))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlListaCliente = New System.Windows.Forms.Panel()
        Me.gridListadoParametros = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbRamos = New System.Windows.Forms.GroupBox()
        Me.chboxMarcarTodo = New System.Windows.Forms.CheckBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblNombreRamo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlMarcarTodo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlListaCliente.SuspendLayout()
        CType(Me.gridListadoParametros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbRamos.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlListaCliente)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(812, 489)
        Me.pnlContenedor.TabIndex = 3
        '
        'pnlListaCliente
        '
        Me.pnlListaCliente.Controls.Add(Me.gridListadoParametros)
        Me.pnlListaCliente.Controls.Add(Me.grbRamos)
        Me.pnlListaCliente.Controls.Add(Me.pnlPie)
        Me.pnlListaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListaCliente.Location = New System.Drawing.Point(0, 59)
        Me.pnlListaCliente.Name = "pnlListaCliente"
        Me.pnlListaCliente.Size = New System.Drawing.Size(812, 430)
        Me.pnlListaCliente.TabIndex = 3
        '
        'gridListadoParametros
        '
        Me.gridListadoParametros.AllowDrop = True
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListadoParametros.DisplayLayout.Appearance = Appearance1
        Me.gridListadoParametros.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridListadoParametros.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListadoParametros.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListadoParametros.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListadoParametros.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListadoParametros.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListadoParametros.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListadoParametros.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListadoParametros.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridListadoParametros.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListadoParametros.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListadoParametros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListadoParametros.Location = New System.Drawing.Point(0, 83)
        Me.gridListadoParametros.Name = "gridListadoParametros"
        Me.gridListadoParametros.Size = New System.Drawing.Size(812, 276)
        Me.gridListadoParametros.TabIndex = 73
        '
        'grbRamos
        '
        Me.grbRamos.Controls.Add(Me.chboxMarcarTodo)
        Me.grbRamos.Controls.Add(Me.dtpFechaFin)
        Me.grbRamos.Controls.Add(Me.Label2)
        Me.grbRamos.Controls.Add(Me.dtpFechaInicio)
        Me.grbRamos.Controls.Add(Me.Label28)
        Me.grbRamos.Controls.Add(Me.lblNombreCliente)
        Me.grbRamos.Controls.Add(Me.lblBúscar)
        Me.grbRamos.Controls.Add(Me.btnBuscar)
        Me.grbRamos.Controls.Add(Me.lblNombreRamo)
        Me.grbRamos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbRamos.Location = New System.Drawing.Point(0, 0)
        Me.grbRamos.Name = "grbRamos"
        Me.grbRamos.Size = New System.Drawing.Size(812, 83)
        Me.grbRamos.TabIndex = 69
        Me.grbRamos.TabStop = False
        '
        'chboxMarcarTodo
        '
        Me.chboxMarcarTodo.AutoSize = True
        Me.chboxMarcarTodo.Enabled = False
        Me.chboxMarcarTodo.Location = New System.Drawing.Point(9, 60)
        Me.chboxMarcarTodo.Name = "chboxMarcarTodo"
        Me.chboxMarcarTodo.Size = New System.Drawing.Size(106, 17)
        Me.chboxMarcarTodo.TabIndex = 0
        Me.chboxMarcarTodo.Text = "Seleccionar todo"
        Me.chboxMarcarTodo.UseVisualStyleBackColor = True
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CalendarForeColor = System.Drawing.SystemColors.ControlDark
        Me.dtpFechaFin.CalendarTitleForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.dtpFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(381, 36)
        Me.dtpFechaFin.MinDate = New Date(2016, 2, 8, 0, 0, 0, 0)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(116, 20)
        Me.dtpFechaFin.TabIndex = 160
        Me.dtpFechaFin.Value = New Date(2019, 1, 3, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(359, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "Al"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CalendarForeColor = System.Drawing.SystemColors.ControlDark
        Me.dtpFechaInicio.CalendarTitleForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.dtpFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(212, 36)
        Me.dtpFechaInicio.MinDate = New Date(2016, 2, 8, 0, 0, 0, 0)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(116, 20)
        Me.dtpFechaInicio.TabIndex = 158
        Me.dtpFechaInicio.Value = New Date(2018, 1, 1, 0, 0, 0, 0)
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(85, 39)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(126, 13)
        Me.Label28.TabIndex = 157
        Me.Label28.Text = "Fecha de Captura      Del"
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Location = New System.Drawing.Point(131, 15)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(126, 13)
        Me.lblNombreCliente.TabIndex = 37
        Me.lblNombreCliente.Text = "NOMBRE DEL CLIENTE"
        '
        'lblBúscar
        '
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(750, 58)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBúscar.TabIndex = 26
        Me.lblBúscar.Text = "Mostrar"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(756, 24)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblNombreRamo
        '
        Me.lblNombreRamo.AutoSize = True
        Me.lblNombreRamo.Location = New System.Drawing.Point(87, 15)
        Me.lblNombreRamo.Name = "lblNombreRamo"
        Me.lblNombreRamo.Size = New System.Drawing.Size(42, 13)
        Me.lblNombreRamo.TabIndex = 7
        Me.lblNombreRamo.Text = "Cliente:"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 359)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(812, 71)
        Me.pnlPie.TabIndex = 64
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 18)
        Me.Label5.TabIndex = 117
        Me.Label5.Text = "Seleccionados"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(668, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(144, 71)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(88, 10)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(14, 43)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(63, 13)
        Me.lblAceptar.TabIndex = 0
        Me.lblAceptar.Text = "Seleccionar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(85, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Almacen.Vista.My.Resources.Resources.aceptar_321
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(29, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(24, 42)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 24)
        Me.lblNumFiltrados.TabIndex = 116
        Me.lblNumFiltrados.Text = "0"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(27, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 24)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Registros"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlEncabezado)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(812, 59)
        Me.pnlCabecera.TabIndex = 1
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(812, 59)
        Me.pnlEncabezado.TabIndex = 25
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(812, 59)
        Me.pnlTitulo.TabIndex = 20
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlMarcarTodo)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(744, 41)
        Me.Panel1.TabIndex = 47
        '
        'pnlMarcarTodo
        '
        Me.pnlMarcarTodo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlMarcarTodo.Location = New System.Drawing.Point(0, 0)
        Me.pnlMarcarTodo.Name = "pnlMarcarTodo"
        Me.pnlMarcarTodo.Size = New System.Drawing.Size(183, 41)
        Me.pnlMarcarTodo.TabIndex = 47
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(462, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(282, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Pedidos / Documentos Por Cliente"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(744, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'DevolucionCliente_Filtro_PedidosDocumentos_PorCliente_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(812, 489)
        Me.Controls.Add(Me.pnlContenedor)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(828, 528)
        Me.MinimizeBox = False
        Me.Name = "DevolucionCliente_Filtro_PedidosDocumentos_PorCliente_Form"
        Me.Text = "Pedidos / Documentos Por Cliente"
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlListaCliente.ResumeLayout(False)
        CType(Me.gridListadoParametros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbRamos.ResumeLayout(False)
        Me.grbRamos.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents pnlListaCliente As Panel
    Friend WithEvents pnlPie As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblAceptar As Label
    Friend WithEvents lblCancelar As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents lblNumFiltrados As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlMarcarTodo As Panel
    Friend WithEvents chboxMarcarTodo As CheckBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents lblNombreCliente As Label
    Friend WithEvents lblBúscar As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents lblNombreRamo As Label
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents Label28 As Label
    Protected WithEvents grbRamos As GroupBox
    Friend WithEvents gridListadoParametros As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
