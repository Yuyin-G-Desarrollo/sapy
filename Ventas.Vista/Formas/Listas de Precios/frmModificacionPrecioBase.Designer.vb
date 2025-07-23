<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModificacionPrecioBase
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkSeleccionarFiltrados = New System.Windows.Forms.CheckBox()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.txtArticulo = New System.Windows.Forms.TextBox()
        Me.txtListaBase = New System.Windows.Forms.TextBox()
        Me.lblEtiquetaNuevoPrecio = New System.Windows.Forms.Label()
        Me.lblPrecioAnterior = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNuevoPrecio = New System.Windows.Forms.Label()
        Me.lblEtiquetaLB = New System.Windows.Forms.Label()
        Me.lblEtiquetaPrecioAnterior = New System.Windows.Forms.Label()
        Me.lblArticulo = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.picConfiguracion = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTotalSeleccionados = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnRecalcular = New System.Windows.Forms.Button()
        Me.lblRecalcular = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.grdDatosProductos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.picConfiguracion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdDatosProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlAcciones)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1208, 60)
        Me.pnlHeader.TabIndex = 3
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(164, 60)
        Me.pnlAcciones.TabIndex = 1
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(735, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(473, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(44, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(363, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Cambiar Precio a Modelo de Lista de Cliente"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(413, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(60, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.chkSeleccionarFiltrados)
        Me.Panel3.Controls.Add(Me.lblEstatus)
        Me.Panel3.Controls.Add(Me.txtArticulo)
        Me.Panel3.Controls.Add(Me.txtListaBase)
        Me.Panel3.Controls.Add(Me.lblEtiquetaNuevoPrecio)
        Me.Panel3.Controls.Add(Me.lblPrecioAnterior)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.lblNuevoPrecio)
        Me.Panel3.Controls.Add(Me.lblEtiquetaLB)
        Me.Panel3.Controls.Add(Me.lblEtiquetaPrecioAnterior)
        Me.Panel3.Controls.Add(Me.lblArticulo)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 60)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1208, 97)
        Me.Panel3.TabIndex = 10
        '
        'chkSeleccionarFiltrados
        '
        Me.chkSeleccionarFiltrados.AutoSize = True
        Me.chkSeleccionarFiltrados.Location = New System.Drawing.Point(15, 75)
        Me.chkSeleccionarFiltrados.Name = "chkSeleccionarFiltrados"
        Me.chkSeleccionarFiltrados.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarFiltrados.TabIndex = 49
        Me.chkSeleccionarFiltrados.Text = "Seleccionar Todo"
        Me.chkSeleccionarFiltrados.UseVisualStyleBackColor = True
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatus.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblEstatus.Location = New System.Drawing.Point(550, 15)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(62, 16)
        Me.lblEstatus.TabIndex = 48
        Me.lblEstatus.Text = "ACTIVA"
        '
        'txtArticulo
        '
        Me.txtArticulo.Enabled = False
        Me.txtArticulo.Location = New System.Drawing.Point(152, 37)
        Me.txtArticulo.Name = "txtArticulo"
        Me.txtArticulo.Size = New System.Drawing.Size(568, 20)
        Me.txtArticulo.TabIndex = 7
        '
        'txtListaBase
        '
        Me.txtListaBase.Enabled = False
        Me.txtListaBase.Location = New System.Drawing.Point(152, 13)
        Me.txtListaBase.Name = "txtListaBase"
        Me.txtListaBase.Size = New System.Drawing.Size(389, 20)
        Me.txtListaBase.TabIndex = 6
        '
        'lblEtiquetaNuevoPrecio
        '
        Me.lblEtiquetaNuevoPrecio.AutoSize = True
        Me.lblEtiquetaNuevoPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaNuevoPrecio.Location = New System.Drawing.Point(755, 39)
        Me.lblEtiquetaNuevoPrecio.Name = "lblEtiquetaNuevoPrecio"
        Me.lblEtiquetaNuevoPrecio.Size = New System.Drawing.Size(90, 16)
        Me.lblEtiquetaNuevoPrecio.TabIndex = 5
        Me.lblEtiquetaNuevoPrecio.Text = "Nuevo Precio"
        '
        'lblPrecioAnterior
        '
        Me.lblPrecioAnterior.AutoSize = True
        Me.lblPrecioAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblPrecioAnterior.Location = New System.Drawing.Point(893, 15)
        Me.lblPrecioAnterior.Name = "lblPrecioAnterior"
        Me.lblPrecioAnterior.Size = New System.Drawing.Size(28, 16)
        Me.lblPrecioAnterior.TabIndex = 4
        Me.lblPrecioAnterior.Text = "0.0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(868, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "$"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(868, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "$"
        '
        'lblNuevoPrecio
        '
        Me.lblNuevoPrecio.AutoSize = True
        Me.lblNuevoPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblNuevoPrecio.Location = New System.Drawing.Point(893, 39)
        Me.lblNuevoPrecio.Name = "lblNuevoPrecio"
        Me.lblNuevoPrecio.Size = New System.Drawing.Size(28, 16)
        Me.lblNuevoPrecio.TabIndex = 4
        Me.lblNuevoPrecio.Text = "0.0"
        '
        'lblEtiquetaLB
        '
        Me.lblEtiquetaLB.AutoSize = True
        Me.lblEtiquetaLB.Location = New System.Drawing.Point(75, 17)
        Me.lblEtiquetaLB.Name = "lblEtiquetaLB"
        Me.lblEtiquetaLB.Size = New System.Drawing.Size(56, 13)
        Me.lblEtiquetaLB.TabIndex = 2
        Me.lblEtiquetaLB.Text = "Lista Base"
        '
        'lblEtiquetaPrecioAnterior
        '
        Me.lblEtiquetaPrecioAnterior.AutoSize = True
        Me.lblEtiquetaPrecioAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaPrecioAnterior.Location = New System.Drawing.Point(755, 15)
        Me.lblEtiquetaPrecioAnterior.Name = "lblEtiquetaPrecioAnterior"
        Me.lblEtiquetaPrecioAnterior.Size = New System.Drawing.Size(96, 16)
        Me.lblEtiquetaPrecioAnterior.TabIndex = 1
        Me.lblEtiquetaPrecioAnterior.Text = "Precio Anterior"
        '
        'lblArticulo
        '
        Me.lblArticulo.AutoSize = True
        Me.lblArticulo.Location = New System.Drawing.Point(75, 41)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(44, 13)
        Me.lblArticulo.TabIndex = 0
        Me.lblArticulo.Text = "Artículo"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.picConfiguracion)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.lblTotalSeleccionados)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 485)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1208, 60)
        Me.Panel2.TabIndex = 11
        '
        'picConfiguracion
        '
        Me.picConfiguracion.Image = Global.Ventas.Vista.My.Resources.Resources.conflv
        Me.picConfiguracion.Location = New System.Drawing.Point(239, 39)
        Me.picConfiguracion.Name = "picConfiguracion"
        Me.picConfiguracion.Size = New System.Drawing.Size(16, 15)
        Me.picConfiguracion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picConfiguracion.TabIndex = 76
        Me.picConfiguracion.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(256, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(259, 13)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "- Lista de Precios con descuentos diferentes a la FTC"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(236, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 13)
        Me.Label6.TabIndex = 73
        Me.Label6.Text = "%D - % Descuentos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(236, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(288, 13)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "DA? - ¿ Calcular Lista de Precios con descuento aplicado ?"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(758, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(245, 60)
        Me.Panel4.TabIndex = 72
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(203, 26)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Clientes con el artículo seleccionado en " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "listas de precios en estatus CAPTURADA" & _
    ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 32)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Clientes " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccionados"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalSeleccionados
        '
        Me.lblTotalSeleccionados.AutoSize = True
        Me.lblTotalSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSeleccionados.Location = New System.Drawing.Point(60, 38)
        Me.lblTotalSeleccionados.Name = "lblTotalSeleccionados"
        Me.lblTotalSeleccionados.Size = New System.Drawing.Size(17, 18)
        Me.lblTotalSeleccionados.TabIndex = 69
        Me.lblTotalSeleccionados.Text = "0"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.btnRecalcular)
        Me.Panel1.Controls.Add(Me.lblRecalcular)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(1003, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(205, 60)
        Me.Panel1.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(152, 4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 75
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(151, 37)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 74
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnRecalcular
        '
        Me.btnRecalcular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecalcular.Image = Global.Ventas.Vista.My.Resources.Resources.finanzas_32
        Me.btnRecalcular.Location = New System.Drawing.Point(42, 4)
        Me.btnRecalcular.Name = "btnRecalcular"
        Me.btnRecalcular.Size = New System.Drawing.Size(32, 32)
        Me.btnRecalcular.TabIndex = 72
        Me.btnRecalcular.UseVisualStyleBackColor = True
        '
        'lblRecalcular
        '
        Me.lblRecalcular.AutoSize = True
        Me.lblRecalcular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecalcular.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRecalcular.Location = New System.Drawing.Point(29, 33)
        Me.lblRecalcular.Name = "lblRecalcular"
        Me.lblRecalcular.Size = New System.Drawing.Size(58, 26)
        Me.lblRecalcular.TabIndex = 73
        Me.lblRecalcular.Text = "Recalcular" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Todos"
        Me.lblRecalcular.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_321
        Me.btnGuardar.Location = New System.Drawing.Point(97, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Enabled = False
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(91, 37)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 2
        Me.lblGuardar.Text = "Guardar"
        '
        'grdDatosProductos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDatosProductos.DisplayLayout.Appearance = Appearance1
        Me.grdDatosProductos.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.AlignWithDataRows
        Me.grdDatosProductos.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinGroup
        Me.grdDatosProductos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDatosProductos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdDatosProductos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdDatosProductos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdDatosProductos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdDatosProductos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDatosProductos.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdDatosProductos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdDatosProductos.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree
        Me.grdDatosProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatosProductos.Location = New System.Drawing.Point(0, 157)
        Me.grdDatosProductos.Name = "grdDatosProductos"
        Me.grdDatosProductos.Size = New System.Drawing.Size(1208, 328)
        Me.grdDatosProductos.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(885, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 16)
        Me.Label8.TabIndex = 71
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(558, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(522, 26)
        Me.Label9.TabIndex = 71
        Me.Label9.Text = "* Precios por cliente antes de la modificación, para ver los precios después del " & _
    "cambio de clic en Recalcular, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Guardar para almacenar los cambios en la base de" & _
    " datos (siempre se recalcularán)"
        '
        'frmModificacionPrecioBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1208, 545)
        Me.Controls.Add(Me.grdDatosProductos)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "frmModificacionPrecioBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar Precio a Modelo de Lista de Cliente"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.picConfiguracion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdDatosProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents grdDatosProductos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtArticulo As System.Windows.Forms.TextBox
    Friend WithEvents txtListaBase As System.Windows.Forms.TextBox
    Friend WithEvents lblEtiquetaNuevoPrecio As System.Windows.Forms.Label
    Friend WithEvents lblNuevoPrecio As System.Windows.Forms.Label
    Friend WithEvents lblEtiquetaLB As System.Windows.Forms.Label
    Friend WithEvents lblEtiquetaPrecioAnterior As System.Windows.Forms.Label
    Friend WithEvents lblArticulo As System.Windows.Forms.Label
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents lblPrecioAnterior As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTotalSeleccionados As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkSeleccionarFiltrados As System.Windows.Forms.CheckBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnRecalcular As System.Windows.Forms.Button
    Friend WithEvents lblRecalcular As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents picConfiguracion As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
