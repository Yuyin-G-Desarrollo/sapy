<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PreciosdeVentaaComercializadorasForm
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
        Me.components = New System.ComponentModel.Container()
        Me.chkDescontinuados = New System.Windows.Forms.CheckBox()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.lblSinPrecio = New System.Windows.Forms.Label()
        Me.lblConPrecio = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblPrecioModificado = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTotalSeleccionados = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlContenedorDerecho = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.txtPrecioMultiple = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblArticulosConPrecio = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotalArticulos = New System.Windows.Forms.Label()
        Me.chkCargarModelosSinPrecio = New System.Windows.Forms.CheckBox()
        Me.chkEstatusActivo = New System.Windows.Forms.CheckBox()
        Me.chkModelosConPrecio = New System.Windows.Forms.CheckBox()
        Me.pnlGrups = New System.Windows.Forms.Panel()
        Me.grupParametrosbusqueda = New System.Windows.Forms.GroupBox()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.chkSeleccionarFiltrados = New System.Windows.Forms.CheckBox()
        Me.lblNombreLista = New System.Windows.Forms.Label()
        Me.txtNombreLista = New System.Windows.Forms.TextBox()
        Me.lblFechaFin = New System.Windows.Forms.Label()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.dttFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.dttFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblCargarPrecios = New System.Windows.Forms.Label()
        Me.btnCargarPrecioMultiple = New System.Windows.Forms.Button()
        Me.exportExcelDetalle = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblExportarExcel = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdDatosProductos = New DevExpress.XtraGrid.GridControl()
        Me.vwReporte = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlCerrar = New System.Windows.Forms.Panel()
        Me.pnlCancelar = New System.Windows.Forms.Panel()
        Me.pnlGuardar = New System.Windows.Forms.Panel()
        Me.pnlEditar = New System.Windows.Forms.Panel()
        Me.pnlExportarExcel = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlContenedorDerecho.SuspendLayout()
        CType(Me.txtPrecioMultiple, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGrups.SuspendLayout()
        Me.grupParametrosbusqueda.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grdDatosProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCerrar.SuspendLayout()
        Me.pnlCancelar.SuspendLayout()
        Me.pnlGuardar.SuspendLayout()
        Me.pnlEditar.SuspendLayout()
        Me.pnlExportarExcel.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkDescontinuados
        '
        Me.chkDescontinuados.AutoSize = True
        Me.chkDescontinuados.Location = New System.Drawing.Point(12, 61)
        Me.chkDescontinuados.Name = "chkDescontinuados"
        Me.chkDescontinuados.Size = New System.Drawing.Size(277, 17)
        Me.chkDescontinuados.TabIndex = 2
        Me.chkDescontinuados.Text = "Ver modelos con estatus Descontinuado para Ventas"
        Me.chkDescontinuados.UseVisualStyleBackColor = True
        '
        'lblClientes
        '
        Me.lblClientes.AutoSize = True
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.ForeColor = System.Drawing.Color.Black
        Me.lblClientes.Location = New System.Drawing.Point(38, 3)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(112, 32)
        Me.lblClientes.TabIndex = 59
        Me.lblClientes.Text = "Artículos " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccionados"
        Me.lblClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSinPrecio
        '
        Me.lblSinPrecio.AutoSize = True
        Me.lblSinPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSinPrecio.Location = New System.Drawing.Point(390, 21)
        Me.lblSinPrecio.Name = "lblSinPrecio"
        Me.lblSinPrecio.Size = New System.Drawing.Size(17, 18)
        Me.lblSinPrecio.TabIndex = 58
        Me.lblSinPrecio.Text = "0"
        '
        'lblConPrecio
        '
        Me.lblConPrecio.AutoSize = True
        Me.lblConPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConPrecio.Location = New System.Drawing.Point(390, 3)
        Me.lblConPrecio.Name = "lblConPrecio"
        Me.lblConPrecio.Size = New System.Drawing.Size(17, 18)
        Me.lblConPrecio.TabIndex = 57
        Me.lblConPrecio.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(7, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(199, 13)
        Me.Label13.TabIndex = 61
        Me.Label13.Text = "Precio capturado menor al precio original"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(3, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(225, 26)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Los precios se actualizan en la base de datos " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "hasta dar click en el botón GUARD" &
    "AR"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Chocolate
        Me.Label10.Location = New System.Drawing.Point(478, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(277, 39)
        Me.Label10.TabIndex = 70
        Me.Label10.Text = "En caso de no visualizar algún artículo, comunicarse con" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "el área de Diseño y Des" &
    "arrollo para validar que le hayan" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "asignado la clave SAT."
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(760, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(235, 60)
        Me.Panel2.TabIndex = 69
        '
        'lblPrecioModificado
        '
        Me.lblPrecioModificado.AutoSize = True
        Me.lblPrecioModificado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioModificado.Location = New System.Drawing.Point(390, 39)
        Me.lblPrecioModificado.Name = "lblPrecioModificado"
        Me.lblPrecioModificado.Size = New System.Drawing.Size(17, 18)
        Me.lblPrecioModificado.TabIndex = 50
        Me.lblPrecioModificado.Text = "0"
        '
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.Label8)
        Me.pnlEstado.Controls.Add(Me.Label10)
        Me.pnlEstado.Controls.Add(Me.Panel2)
        Me.pnlEstado.Controls.Add(Me.lblClientes)
        Me.pnlEstado.Controls.Add(Me.lblSinPrecio)
        Me.pnlEstado.Controls.Add(Me.lblConPrecio)
        Me.pnlEstado.Controls.Add(Me.lblPrecioModificado)
        Me.pnlEstado.Controls.Add(Me.Label7)
        Me.pnlEstado.Controls.Add(Me.lblTotalSeleccionados)
        Me.pnlEstado.Controls.Add(Me.Label6)
        Me.pnlEstado.Controls.Add(Me.Label4)
        Me.pnlEstado.Controls.Add(Me.Label11)
        Me.pnlEstado.Controls.Add(Me.pnlContenedorDerecho)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 500)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1236, 60)
        Me.pnlEstado.TabIndex = 54
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(255, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 13)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Precios Modificados"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(255, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Sin Precio"
        '
        'lblTotalSeleccionados
        '
        Me.lblTotalSeleccionados.AutoSize = True
        Me.lblTotalSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSeleccionados.Location = New System.Drawing.Point(86, 36)
        Me.lblTotalSeleccionados.Name = "lblTotalSeleccionados"
        Me.lblTotalSeleccionados.Size = New System.Drawing.Size(17, 18)
        Me.lblTotalSeleccionados.TabIndex = 43
        Me.lblTotalSeleccionados.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(255, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Con Precio"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Red
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(234, 23)
        Me.Label4.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label4.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 15)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "N"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(234, 5)
        Me.Label11.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label11.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(15, 15)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "P"
        '
        'pnlContenedorDerecho
        '
        Me.pnlContenedorDerecho.Controls.Add(Me.pnlEditar)
        Me.pnlContenedorDerecho.Controls.Add(Me.pnlGuardar)
        Me.pnlContenedorDerecho.Controls.Add(Me.pnlCancelar)
        Me.pnlContenedorDerecho.Controls.Add(Me.pnlCerrar)
        Me.pnlContenedorDerecho.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlContenedorDerecho.Location = New System.Drawing.Point(995, 0)
        Me.pnlContenedorDerecho.Name = "pnlContenedorDerecho"
        Me.pnlContenedorDerecho.Size = New System.Drawing.Size(241, 60)
        Me.pnlContenedorDerecho.TabIndex = 2
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Enabled = False
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(6, 43)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 11
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(13, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.Enabled = False
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(4, 42)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelar.TabIndex = 9
        Me.lblCancelar.Text = "Cancelar"
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.Enabled = False
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(11, 42)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 8
        Me.lblEditar.Text = "Editar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar321
        Me.btnCancelar.Location = New System.Drawing.Point(12, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Enabled = False
        Me.btnEditar.Image = Global.Ventas.Vista.My.Resources.Resources.editar_321
        Me.btnEditar.Location = New System.Drawing.Point(12, 8)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 6
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(11, 7)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblSalir
        '
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(10, 41)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 3
        Me.lblSalir.Text = "Cerrar"
        '
        'txtPrecioMultiple
        '
        Me.txtPrecioMultiple.DecimalPlaces = 2
        Me.txtPrecioMultiple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioMultiple.Location = New System.Drawing.Point(228, 52)
        Me.txtPrecioMultiple.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.txtPrecioMultiple.Name = "txtPrecioMultiple"
        Me.txtPrecioMultiple.Size = New System.Drawing.Size(85, 20)
        Me.txtPrecioMultiple.TabIndex = 49
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Artículos con Precio"
        '
        'lblArticulosConPrecio
        '
        Me.lblArticulosConPrecio.AutoSize = True
        Me.lblArticulosConPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArticulosConPrecio.Location = New System.Drawing.Point(106, 54)
        Me.lblArticulosConPrecio.Name = "lblArticulosConPrecio"
        Me.lblArticulosConPrecio.Size = New System.Drawing.Size(17, 18)
        Me.lblArticulosConPrecio.TabIndex = 45
        Me.lblArticulosConPrecio.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(186, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(164, 13)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Actualizar precios de la selección"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Total de Artículos"
        '
        'lblTotalArticulos
        '
        Me.lblTotalArticulos.AutoSize = True
        Me.lblTotalArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalArticulos.Location = New System.Drawing.Point(106, 28)
        Me.lblTotalArticulos.Name = "lblTotalArticulos"
        Me.lblTotalArticulos.Size = New System.Drawing.Size(17, 18)
        Me.lblTotalArticulos.TabIndex = 43
        Me.lblTotalArticulos.Text = "0"
        '
        'chkCargarModelosSinPrecio
        '
        Me.chkCargarModelosSinPrecio.AutoSize = True
        Me.chkCargarModelosSinPrecio.Location = New System.Drawing.Point(12, 27)
        Me.chkCargarModelosSinPrecio.Name = "chkCargarModelosSinPrecio"
        Me.chkCargarModelosSinPrecio.Size = New System.Drawing.Size(176, 17)
        Me.chkCargarModelosSinPrecio.TabIndex = 3
        Me.chkCargarModelosSinPrecio.Text = "Ver modelos con precio en cero"
        Me.chkCargarModelosSinPrecio.UseVisualStyleBackColor = True
        '
        'chkEstatusActivo
        '
        Me.chkEstatusActivo.AutoSize = True
        Me.chkEstatusActivo.Location = New System.Drawing.Point(12, 44)
        Me.chkEstatusActivo.Name = "chkEstatusActivo"
        Me.chkEstatusActivo.Size = New System.Drawing.Size(250, 17)
        Me.chkEstatusActivo.TabIndex = 1
        Me.chkEstatusActivo.Text = "Ver modelos con estatus activo (M/AP/AV/DP)"
        Me.chkEstatusActivo.UseVisualStyleBackColor = True
        '
        'chkModelosConPrecio
        '
        Me.chkModelosConPrecio.AutoSize = True
        Me.chkModelosConPrecio.Location = New System.Drawing.Point(12, 10)
        Me.chkModelosConPrecio.Name = "chkModelosConPrecio"
        Me.chkModelosConPrecio.Size = New System.Drawing.Size(137, 17)
        Me.chkModelosConPrecio.TabIndex = 0
        Me.chkModelosConPrecio.Text = "Ver modelos con precio"
        Me.chkModelosConPrecio.UseVisualStyleBackColor = True
        '
        'pnlGrups
        '
        Me.pnlGrups.Controls.Add(Me.grupParametrosbusqueda)
        Me.pnlGrups.Controls.Add(Me.GroupBox1)
        Me.pnlGrups.Controls.Add(Me.GroupBox2)
        Me.pnlGrups.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlGrups.Location = New System.Drawing.Point(0, 60)
        Me.pnlGrups.Name = "pnlGrups"
        Me.pnlGrups.Size = New System.Drawing.Size(1236, 84)
        Me.pnlGrups.TabIndex = 56
        '
        'grupParametrosbusqueda
        '
        Me.grupParametrosbusqueda.BackColor = System.Drawing.Color.AliceBlue
        Me.grupParametrosbusqueda.Controls.Add(Me.lblEstatus)
        Me.grupParametrosbusqueda.Controls.Add(Me.lblCodigo)
        Me.grupParametrosbusqueda.Controls.Add(Me.txtCodigo)
        Me.grupParametrosbusqueda.Controls.Add(Me.chkSeleccionarFiltrados)
        Me.grupParametrosbusqueda.Controls.Add(Me.lblNombreLista)
        Me.grupParametrosbusqueda.Controls.Add(Me.txtNombreLista)
        Me.grupParametrosbusqueda.Controls.Add(Me.lblFechaFin)
        Me.grupParametrosbusqueda.Controls.Add(Me.lblFechaInicio)
        Me.grupParametrosbusqueda.Controls.Add(Me.dttFechaInicio)
        Me.grupParametrosbusqueda.Controls.Add(Me.dttFechaFin)
        Me.grupParametrosbusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grupParametrosbusqueda.Location = New System.Drawing.Point(0, 0)
        Me.grupParametrosbusqueda.Name = "grupParametrosbusqueda"
        Me.grupParametrosbusqueda.Size = New System.Drawing.Size(539, 84)
        Me.grupParametrosbusqueda.TabIndex = 10
        Me.grupParametrosbusqueda.TabStop = False
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatus.ForeColor = System.Drawing.Color.Green
        Me.lblEstatus.Location = New System.Drawing.Point(494, 9)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(51, 13)
        Me.lblEstatus.TabIndex = 46
        Me.lblEstatus.Text = "ACTIVA"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(48, 13)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 45
        Me.lblCodigo.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(91, 9)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(94, 20)
        Me.txtCodigo.TabIndex = 44
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkSeleccionarFiltrados
        '
        Me.chkSeleccionarFiltrados.AutoSize = True
        Me.chkSeleccionarFiltrados.Enabled = False
        Me.chkSeleccionarFiltrados.Location = New System.Drawing.Point(13, 63)
        Me.chkSeleccionarFiltrados.Name = "chkSeleccionarFiltrados"
        Me.chkSeleccionarFiltrados.Size = New System.Drawing.Size(51, 17)
        Me.chkSeleccionarFiltrados.TabIndex = 38
        Me.chkSeleccionarFiltrados.Text = "Todo"
        Me.chkSeleccionarFiltrados.UseVisualStyleBackColor = True
        '
        'lblNombreLista
        '
        Me.lblNombreLista.AutoSize = True
        Me.lblNombreLista.Location = New System.Drawing.Point(211, 13)
        Me.lblNombreLista.Name = "lblNombreLista"
        Me.lblNombreLista.Size = New System.Drawing.Size(36, 13)
        Me.lblNombreLista.TabIndex = 35
        Me.lblNombreLista.Text = "* Lista"
        '
        'txtNombreLista
        '
        Me.txtNombreLista.Enabled = False
        Me.txtNombreLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreLista.Location = New System.Drawing.Point(253, 8)
        Me.txtNombreLista.Name = "txtNombreLista"
        Me.txtNombreLista.Size = New System.Drawing.Size(226, 22)
        Me.txtNombreLista.TabIndex = 2
        '
        'lblFechaFin
        '
        Me.lblFechaFin.AutoSize = True
        Me.lblFechaFin.Location = New System.Drawing.Point(211, 64)
        Me.lblFechaFin.Name = "lblFechaFin"
        Me.lblFechaFin.Size = New System.Drawing.Size(28, 13)
        Me.lblFechaFin.TabIndex = 29
        Me.lblFechaFin.Text = "* Fin"
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Location = New System.Drawing.Point(211, 39)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(39, 13)
        Me.lblFechaInicio.TabIndex = 28
        Me.lblFechaInicio.Text = "* Inicio"
        '
        'dttFechaInicio
        '
        Me.dttFechaInicio.Enabled = False
        Me.dttFechaInicio.Location = New System.Drawing.Point(253, 35)
        Me.dttFechaInicio.Name = "dttFechaInicio"
        Me.dttFechaInicio.Size = New System.Drawing.Size(226, 20)
        Me.dttFechaInicio.TabIndex = 26
        '
        'dttFechaFin
        '
        Me.dttFechaFin.Enabled = False
        Me.dttFechaFin.Location = New System.Drawing.Point(253, 60)
        Me.dttFechaFin.Name = "dttFechaFin"
        Me.dttFechaFin.Size = New System.Drawing.Size(226, 20)
        Me.dttFechaFin.TabIndex = 25
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox1.Controls.Add(Me.chkCargarModelosSinPrecio)
        Me.GroupBox1.Controls.Add(Me.chkDescontinuados)
        Me.GroupBox1.Controls.Add(Me.chkEstatusActivo)
        Me.GroupBox1.Controls.Add(Me.chkModelosConPrecio)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox1.Location = New System.Drawing.Point(539, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(339, 84)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox2.Controls.Add(Me.txtPrecioMultiple)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblArticulosConPrecio)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.lblTotalArticulos)
        Me.GroupBox2.Controls.Add(Me.lblCargarPrecios)
        Me.GroupBox2.Controls.Add(Me.btnCargarPrecioMultiple)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(878, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(358, 84)
        Me.GroupBox2.TabIndex = 42
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Acciones"
        '
        'lblCargarPrecios
        '
        Me.lblCargarPrecios.AutoSize = True
        Me.lblCargarPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCargarPrecios.Location = New System.Drawing.Point(186, 56)
        Me.lblCargarPrecios.Name = "lblCargarPrecios"
        Me.lblCargarPrecios.Size = New System.Drawing.Size(40, 13)
        Me.lblCargarPrecios.TabIndex = 31
        Me.lblCargarPrecios.Text = "Precio:"
        '
        'btnCargarPrecioMultiple
        '
        Me.btnCargarPrecioMultiple.Enabled = False
        Me.btnCargarPrecioMultiple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargarPrecioMultiple.Image = Global.Ventas.Vista.My.Resources.Resources.refresh_32
        Me.btnCargarPrecioMultiple.Location = New System.Drawing.Point(315, 47)
        Me.btnCargarPrecioMultiple.Name = "btnCargarPrecioMultiple"
        Me.btnCargarPrecioMultiple.Size = New System.Drawing.Size(32, 32)
        Me.btnCargarPrecioMultiple.TabIndex = 33
        Me.btnCargarPrecioMultiple.UseVisualStyleBackColor = True
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.Panel3)
        Me.pnlHeader.Controls.Add(Me.pnlAcciones)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1236, 60)
        Me.pnlHeader.TabIndex = 52
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblTitulo)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(792, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(380, 60)
        Me.Panel3.TabIndex = 2
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(61, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(313, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Precios de Venta a Comercializadoras"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.pnlExportarExcel)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(623, 60)
        Me.pnlAcciones.TabIndex = 1
        '
        'lblExportarExcel
        '
        Me.lblExportarExcel.AutoSize = True
        Me.lblExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarExcel.Location = New System.Drawing.Point(13, 38)
        Me.lblExportarExcel.Name = "lblExportarExcel"
        Me.lblExportarExcel.Size = New System.Drawing.Size(75, 13)
        Me.lblExportarExcel.TabIndex = 24
        Me.lblExportarExcel.Text = "Exportar Excel"
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.Location = New System.Drawing.Point(32, 3)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 2
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(1172, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(64, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(4, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(60, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdDatosProductos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 144)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1236, 356)
        Me.Panel1.TabIndex = 57
        '
        'grdDatosProductos
        '
        Me.grdDatosProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatosProductos.Location = New System.Drawing.Point(0, 0)
        Me.grdDatosProductos.MainView = Me.vwReporte
        Me.grdDatosProductos.Name = "grdDatosProductos"
        Me.grdDatosProductos.Size = New System.Drawing.Size(1236, 356)
        Me.grdDatosProductos.TabIndex = 14
        Me.grdDatosProductos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwReporte})
        '
        'vwReporte
        '
        Me.vwReporte.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.vwReporte.Appearance.EvenRow.Options.UseBackColor = True
        Me.vwReporte.GridControl = Me.grdDatosProductos
        Me.vwReporte.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, "")})
        Me.vwReporte.IndicatorWidth = 25
        Me.vwReporte.Name = "vwReporte"
        Me.vwReporte.OptionsCustomization.AllowColumnMoving = False
        Me.vwReporte.OptionsCustomization.AllowGroup = False
        Me.vwReporte.OptionsMenu.EnableColumnMenu = False
        Me.vwReporte.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporte.OptionsView.ColumnAutoWidth = False
        Me.vwReporte.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporte.OptionsView.EnableAppearanceEvenRow = True
        Me.vwReporte.OptionsView.EnableAppearanceOddRow = True
        Me.vwReporte.OptionsView.ShowAutoFilterRow = True
        Me.vwReporte.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.vwReporte.OptionsView.ShowDetailButtons = False
        Me.vwReporte.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.vwReporte.OptionsView.ShowFooter = True
        Me.vwReporte.OptionsView.ShowGroupPanel = False
        '
        'pnlCerrar
        '
        Me.pnlCerrar.Controls.Add(Me.btnSalir)
        Me.pnlCerrar.Controls.Add(Me.lblSalir)
        Me.pnlCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCerrar.Location = New System.Drawing.Point(187, 0)
        Me.pnlCerrar.Name = "pnlCerrar"
        Me.pnlCerrar.Size = New System.Drawing.Size(54, 60)
        Me.pnlCerrar.TabIndex = 12
        '
        'pnlCancelar
        '
        Me.pnlCancelar.Controls.Add(Me.btnCancelar)
        Me.pnlCancelar.Controls.Add(Me.lblCancelar)
        Me.pnlCancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCancelar.Location = New System.Drawing.Point(133, 0)
        Me.pnlCancelar.Name = "pnlCancelar"
        Me.pnlCancelar.Size = New System.Drawing.Size(54, 60)
        Me.pnlCancelar.TabIndex = 13
        Me.pnlCancelar.Visible = False
        '
        'pnlGuardar
        '
        Me.pnlGuardar.Controls.Add(Me.lblGuardar)
        Me.pnlGuardar.Controls.Add(Me.btnGuardar)
        Me.pnlGuardar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlGuardar.Location = New System.Drawing.Point(79, 0)
        Me.pnlGuardar.Name = "pnlGuardar"
        Me.pnlGuardar.Size = New System.Drawing.Size(54, 60)
        Me.pnlGuardar.TabIndex = 14
        '
        'pnlEditar
        '
        Me.pnlEditar.Controls.Add(Me.btnEditar)
        Me.pnlEditar.Controls.Add(Me.lblEditar)
        Me.pnlEditar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlEditar.Location = New System.Drawing.Point(25, 0)
        Me.pnlEditar.Name = "pnlEditar"
        Me.pnlEditar.Size = New System.Drawing.Size(54, 60)
        Me.pnlEditar.TabIndex = 15
        '
        'pnlExportarExcel
        '
        Me.pnlExportarExcel.Controls.Add(Me.btnExportarExcel)
        Me.pnlExportarExcel.Controls.Add(Me.lblExportarExcel)
        Me.pnlExportarExcel.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportarExcel.Location = New System.Drawing.Point(0, 0)
        Me.pnlExportarExcel.Name = "pnlExportarExcel"
        Me.pnlExportarExcel.Size = New System.Drawing.Size(103, 60)
        Me.pnlExportarExcel.TabIndex = 25
        '
        'PreciosdeVentaaComercializadorasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1236, 560)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlGrups)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "PreciosdeVentaaComercializadorasForm"
        Me.Text = "Precios de Venta a Comercializadoras"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlContenedorDerecho.ResumeLayout(False)
        CType(Me.txtPrecioMultiple, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGrups.ResumeLayout(False)
        Me.grupParametrosbusqueda.ResumeLayout(False)
        Me.grupParametrosbusqueda.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdDatosProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCerrar.ResumeLayout(False)
        Me.pnlCerrar.PerformLayout()
        Me.pnlCancelar.ResumeLayout(False)
        Me.pnlCancelar.PerformLayout()
        Me.pnlGuardar.ResumeLayout(False)
        Me.pnlGuardar.PerformLayout()
        Me.pnlEditar.ResumeLayout(False)
        Me.pnlEditar.PerformLayout()
        Me.pnlExportarExcel.ResumeLayout(False)
        Me.pnlExportarExcel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents chkDescontinuados As CheckBox
    Friend WithEvents lblClientes As Label
    Friend WithEvents lblSinPrecio As Label
    Friend WithEvents lblConPrecio As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblPrecioModificado As Label
    Friend WithEvents pnlEstado As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents lblTotalSeleccionados As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents pnlContenedorDerecho As Panel
    Friend WithEvents lblGuardar As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents lblEditar As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents lblSalir As Label
    Friend WithEvents txtPrecioMultiple As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents lblArticulosConPrecio As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotalArticulos As Label
    Friend WithEvents chkCargarModelosSinPrecio As CheckBox
    Friend WithEvents chkEstatusActivo As CheckBox
    Friend WithEvents chkModelosConPrecio As CheckBox
    Friend WithEvents pnlGrups As Panel
    Friend WithEvents grupParametrosbusqueda As GroupBox
    Friend WithEvents lblCodigo As Label
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents chkSeleccionarFiltrados As CheckBox
    Friend WithEvents lblNombreLista As Label
    Friend WithEvents txtNombreLista As TextBox
    Friend WithEvents lblFechaFin As Label
    Friend WithEvents lblFechaInicio As Label
    Friend WithEvents dttFechaInicio As DateTimePicker
    Friend WithEvents dttFechaFin As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblCargarPrecios As Label
    Friend WithEvents btnCargarPrecioMultiple As Button
    Friend WithEvents exportExcelDetalle As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents lblExportarExcel As Label
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pcbTitulo As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblEstatus As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents grdDatosProductos As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwReporte As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlEditar As Panel
    Friend WithEvents pnlGuardar As Panel
    Friend WithEvents pnlCancelar As Panel
    Friend WithEvents pnlCerrar As Panel
    Friend WithEvents pnlExportarExcel As Panel
End Class
