<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AntiguedadInventarioForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AntiguedadInventarioForm))
        Me.gridInventarioAntiguedad = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblListaPuestos = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnActualizarListadoInventario = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlResumen = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblHoraReporteProductividad = New System.Windows.Forms.Label()
        Me.lblFechaReporteProductividad = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblDiasAntig = New System.Windows.Forms.Label()
        Me.lblExistencia = New System.Windows.Forms.Label()
        Me.pnlConsulta = New System.Windows.Forms.Panel()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.rdoInventarioStock = New System.Windows.Forms.RadioButton()
        Me.rdoInventarioPrevendido = New System.Windows.Forms.RadioButton()
        Me.gbox_CEDIS = New System.Windows.Forms.GroupBox()
        Me.cboxNaveAlmacen = New System.Windows.Forms.ComboBox()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        CType(Me.gridInventarioAntiguedad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlResumen.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlConsulta.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.gbox_CEDIS.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridInventarioAntiguedad
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridInventarioAntiguedad.DisplayLayout.Appearance = Appearance1
        Me.gridInventarioAntiguedad.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.gridInventarioAntiguedad.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridInventarioAntiguedad.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridInventarioAntiguedad.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridInventarioAntiguedad.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridInventarioAntiguedad.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridInventarioAntiguedad.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridInventarioAntiguedad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridInventarioAntiguedad.Location = New System.Drawing.Point(0, 78)
        Me.gridInventarioAntiguedad.Name = "gridInventarioAntiguedad"
        Me.gridInventarioAntiguedad.Size = New System.Drawing.Size(1233, 300)
        Me.gridInventarioAntiguedad.TabIndex = 4
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1233, 59)
        Me.pnlEncabezado.TabIndex = 5
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.lblExportar)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnExportar)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(301, 59)
        Me.pnlAccionesCabecera.TabIndex = 1
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(11, 40)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 24
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Almacen.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(18, 5)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 23
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.lblListaPuestos)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(740, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(493, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblListaPuestos
        '
        Me.lblListaPuestos.AutoSize = True
        Me.lblListaPuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaPuestos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaPuestos.Location = New System.Drawing.Point(118, 19)
        Me.lblListaPuestos.Name = "lblListaPuestos"
        Me.lblListaPuestos.Size = New System.Drawing.Size(304, 20)
        Me.lblListaPuestos.TabIndex = 46
        Me.lblListaPuestos.Text = "Antigϋedad del Inventario Disponible"
        Me.lblListaPuestos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.btnActualizarListadoInventario)
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1132, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(101, 89)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(11, 48)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 2
        Me.lblAceptar.Text = "Mostrar"
        '
        'btnActualizarListadoInventario
        '
        Me.btnActualizarListadoInventario.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnActualizarListadoInventario.Image = Global.Almacen.Vista.My.Resources.Resources.buscar_32
        Me.btnActualizarListadoInventario.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnActualizarListadoInventario.Location = New System.Drawing.Point(16, 13)
        Me.btnActualizarListadoInventario.Name = "btnActualizarListadoInventario"
        Me.btnActualizarListadoInventario.Size = New System.Drawing.Size(32, 32)
        Me.btnActualizarListadoInventario.TabIndex = 3
        Me.btnActualizarListadoInventario.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(58, 13)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(57, 48)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlResumen
        '
        Me.pnlResumen.Controls.Add(Me.Label8)
        Me.pnlResumen.Controls.Add(Me.lblHoraReporteProductividad)
        Me.pnlResumen.Controls.Add(Me.lblFechaReporteProductividad)
        Me.pnlResumen.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlResumen.Location = New System.Drawing.Point(199, 0)
        Me.pnlResumen.Name = "pnlResumen"
        Me.pnlResumen.Size = New System.Drawing.Size(933, 89)
        Me.pnlResumen.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(680, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 13)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Última Actualización:"
        '
        'lblHoraReporteProductividad
        '
        Me.lblHoraReporteProductividad.AutoSize = True
        Me.lblHoraReporteProductividad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoraReporteProductividad.ForeColor = System.Drawing.Color.Black
        Me.lblHoraReporteProductividad.Location = New System.Drawing.Point(853, 16)
        Me.lblHoraReporteProductividad.Name = "lblHoraReporteProductividad"
        Me.lblHoraReporteProductividad.Size = New System.Drawing.Size(63, 13)
        Me.lblHoraReporteProductividad.TabIndex = 62
        Me.lblHoraReporteProductividad.Text = "88:88:88XX"
        '
        'lblFechaReporteProductividad
        '
        Me.lblFechaReporteProductividad.AutoSize = True
        Me.lblFechaReporteProductividad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaReporteProductividad.ForeColor = System.Drawing.Color.Black
        Me.lblFechaReporteProductividad.Location = New System.Drawing.Point(785, 16)
        Me.lblFechaReporteProductividad.Name = "lblFechaReporteProductividad"
        Me.lblFechaReporteProductividad.Size = New System.Drawing.Size(65, 13)
        Me.lblFechaReporteProductividad.TabIndex = 61
        Me.lblFechaReporteProductividad.Text = "8888/88/88"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.lblDiasAntig)
        Me.pnlPie.Controls.Add(Me.lblExistencia)
        Me.pnlPie.Controls.Add(Me.pnlResumen)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 437)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1233, 89)
        Me.pnlPie.TabIndex = 6
        '
        'lblDiasAntig
        '
        Me.lblDiasAntig.AutoSize = True
        Me.lblDiasAntig.Location = New System.Drawing.Point(3, 47)
        Me.lblDiasAntig.Name = "lblDiasAntig"
        Me.lblDiasAntig.Size = New System.Drawing.Size(583, 13)
        Me.lblDiasAntig.TabIndex = 4
        Me.lblDiasAntig.Text = "*DiasAntig: Cantidad de días transcurridos desde el ingreso del producto al almac" &
    "én (FEntrada) al momento de la consulta."
        '
        'lblExistencia
        '
        Me.lblExistencia.AutoSize = True
        Me.lblExistencia.Location = New System.Drawing.Point(3, 13)
        Me.lblExistencia.Name = "lblExistencia"
        Me.lblExistencia.Size = New System.Drawing.Size(409, 13)
        Me.lblExistencia.TabIndex = 3
        Me.lblExistencia.Text = "*Existencia: Inventario físico disponible en almacén, contiene los pares en apart" &
    "ados "
        '
        'pnlConsulta
        '
        Me.pnlConsulta.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlConsulta.Controls.Add(Me.gridInventarioAntiguedad)
        Me.pnlConsulta.Controls.Add(Me.pnlParametros)
        Me.pnlConsulta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlConsulta.Location = New System.Drawing.Point(0, 59)
        Me.pnlConsulta.Name = "pnlConsulta"
        Me.pnlConsulta.Size = New System.Drawing.Size(1233, 378)
        Me.pnlConsulta.TabIndex = 6
        '
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.rdoInventarioStock)
        Me.pnlParametros.Controls.Add(Me.rdoInventarioPrevendido)
        Me.pnlParametros.Controls.Add(Me.gbox_CEDIS)
        Me.pnlParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 0)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1233, 78)
        Me.pnlParametros.TabIndex = 0
        '
        'rdoInventarioStock
        '
        Me.rdoInventarioStock.AutoSize = True
        Me.rdoInventarioStock.Location = New System.Drawing.Point(428, 44)
        Me.rdoInventarioStock.Name = "rdoInventarioStock"
        Me.rdoInventarioStock.Size = New System.Drawing.Size(148, 17)
        Me.rdoInventarioStock.TabIndex = 7
        Me.rdoInventarioStock.TabStop = True
        Me.rdoInventarioStock.Text = "INVENTARIO EN STOCK"
        Me.rdoInventarioStock.UseVisualStyleBackColor = True
        '
        'rdoInventarioPrevendido
        '
        Me.rdoInventarioPrevendido.AutoSize = True
        Me.rdoInventarioPrevendido.Location = New System.Drawing.Point(245, 44)
        Me.rdoInventarioPrevendido.Name = "rdoInventarioPrevendido"
        Me.rdoInventarioPrevendido.Size = New System.Drawing.Size(165, 17)
        Me.rdoInventarioPrevendido.TabIndex = 6
        Me.rdoInventarioPrevendido.TabStop = True
        Me.rdoInventarioPrevendido.Text = "INVENTARIO PREVENDIDO"
        Me.rdoInventarioPrevendido.UseVisualStyleBackColor = True
        '
        'gbox_CEDIS
        '
        Me.gbox_CEDIS.Controls.Add(Me.cboxNaveAlmacen)
        Me.gbox_CEDIS.Location = New System.Drawing.Point(14, 27)
        Me.gbox_CEDIS.Name = "gbox_CEDIS"
        Me.gbox_CEDIS.Size = New System.Drawing.Size(199, 40)
        Me.gbox_CEDIS.TabIndex = 5
        Me.gbox_CEDIS.TabStop = False
        Me.gbox_CEDIS.Text = "CEDIS:"
        '
        'cboxNaveAlmacen
        '
        Me.cboxNaveAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxNaveAlmacen.FormattingEnabled = True
        Me.cboxNaveAlmacen.Location = New System.Drawing.Point(6, 13)
        Me.cboxNaveAlmacen.Name = "cboxNaveAlmacen"
        Me.cboxNaveAlmacen.Size = New System.Drawing.Size(187, 21)
        Me.cboxNaveAlmacen.TabIndex = 0
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.lblBuscar)
        Me.pnlMinimizarParametros.Controls.Add(Me.lblLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnBuscar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(1124, 0)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(109, 78)
        Me.pnlMinimizarParametros.TabIndex = 2
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(9, 59)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 54
        Me.lblBuscar.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(59, 59)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 53
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(62, 27)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 1
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(13, 27)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 0
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(79, 2)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 3
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(55, 2)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 2
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(423, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 59)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 47
        Me.imgLogo.TabStop = False
        '
        'AntiguedadInventarioForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1233, 526)
        Me.Controls.Add(Me.pnlConsulta)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "AntiguedadInventarioForm"
        Me.Text = "Antigϋedad del Inventario Disponible"
        CType(Me.gridInventarioAntiguedad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlAccionesCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlResumen.ResumeLayout(False)
        Me.pnlResumen.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlConsulta.ResumeLayout(False)
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.gbox_CEDIS.ResumeLayout(False)
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridInventarioAntiguedad As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblListaPuestos As System.Windows.Forms.Label
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents btnActualizarListadoInventario As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents pnlResumen As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblHoraReporteProductividad As System.Windows.Forms.Label
    Friend WithEvents lblFechaReporteProductividad As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlConsulta As System.Windows.Forms.Panel
    Friend WithEvents lblDiasAntig As System.Windows.Forms.Label
    Friend WithEvents lblExistencia As System.Windows.Forms.Label
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents gbox_CEDIS As GroupBox
    Friend WithEvents cboxNaveAlmacen As ComboBox
    Friend WithEvents pnlMinimizarParametros As Panel
    Friend WithEvents lblBuscar As Label
    Friend WithEvents lblLimpiar As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnArriba As Button
    Friend WithEvents rdoInventarioPrevendido As RadioButton
    Friend WithEvents rdoInventarioStock As RadioButton
    Friend WithEvents imgLogo As PictureBox
End Class
