<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdministradorTallasExtranjeras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdministradorTallasExtranjeras))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GrdTallasExtranjerasFamilias = New DevExpress.XtraGrid.GridControl()
        Me.GrdVTallasExtranjerasFamilias = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbClientes = New System.Windows.Forms.ComboBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblRegistrosSeleccionados = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTexto = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.btnConfiguracionLicencia = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnConfiguracionGeneral = New System.Windows.Forms.Button()
        Me.lblConfiguracionGeneral = New System.Windows.Forms.Label()
        Me.lblCopiarCliente = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnCopiarCliente = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GrdTallasExtranjerasFamilias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrdVTallasExtranjerasFamilias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cbxSeleccionarTodo)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 72)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(616, 378)
        Me.Panel1.TabIndex = 72
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 349)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(331, 26)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Las familias y corridas mostradas corresponden a las de los artículos " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de las li" &
    "stas de precios ACEPTADA o CAPTURADA"
        '
        'cbxSeleccionarTodo
        '
        Me.cbxSeleccionarTodo.AutoSize = True
        Me.cbxSeleccionarTodo.Location = New System.Drawing.Point(13, 75)
        Me.cbxSeleccionarTodo.Name = "cbxSeleccionarTodo"
        Me.cbxSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.cbxSeleccionarTodo.TabIndex = 28
        Me.cbxSeleccionarTodo.Text = "Seleccionar Todo"
        Me.cbxSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox1.Controls.Add(Me.GrdTallasExtranjerasFamilias)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 88)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(592, 258)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'GrdTallasExtranjerasFamilias
        '
        Me.GrdTallasExtranjerasFamilias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdTallasExtranjerasFamilias.Location = New System.Drawing.Point(3, 16)
        Me.GrdTallasExtranjerasFamilias.MainView = Me.GrdVTallasExtranjerasFamilias
        Me.GrdTallasExtranjerasFamilias.Name = "GrdTallasExtranjerasFamilias"
        Me.GrdTallasExtranjerasFamilias.Size = New System.Drawing.Size(586, 239)
        Me.GrdTallasExtranjerasFamilias.TabIndex = 0
        Me.GrdTallasExtranjerasFamilias.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GrdVTallasExtranjerasFamilias})
        '
        'GrdVTallasExtranjerasFamilias
        '
        Me.GrdVTallasExtranjerasFamilias.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.GrdVTallasExtranjerasFamilias.GridControl = Me.GrdTallasExtranjerasFamilias
        Me.GrdVTallasExtranjerasFamilias.Name = "GrdVTallasExtranjerasFamilias"
        Me.GrdVTallasExtranjerasFamilias.OptionsView.ShowAutoFilterRow = True
        '
        'GridBand1
        '
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.cmbClientes)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(596, 64)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(100, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(268, 13)
        Me.Label6.TabIndex = 127
        Me.Label6.Text = "Clientes con corridas extranjeras en la FTC (Etiquetado)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(54, 20)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 13)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "Cliente"
        '
        'cmbClientes
        '
        Me.cmbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClientes.Location = New System.Drawing.Point(103, 17)
        Me.cmbClientes.Name = "cmbClientes"
        Me.cmbClientes.Size = New System.Drawing.Size(420, 21)
        Me.cmbClientes.TabIndex = 27
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.lblRegistrosSeleccionados)
        Me.pnlPie.Controls.Add(Me.Label8)
        Me.pnlPie.Controls.Add(Me.lblTexto)
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 450)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(616, 65)
        Me.pnlPie.TabIndex = 71
        '
        'lblRegistrosSeleccionados
        '
        Me.lblRegistrosSeleccionados.AutoSize = True
        Me.lblRegistrosSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistrosSeleccionados.Location = New System.Drawing.Point(49, 40)
        Me.lblRegistrosSeleccionados.Name = "lblRegistrosSeleccionados"
        Me.lblRegistrosSeleccionados.Size = New System.Drawing.Size(16, 16)
        Me.lblRegistrosSeleccionados.TabIndex = 129
        Me.lblRegistrosSeleccionados.Text = "0"
        Me.lblRegistrosSeleccionados.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 32)
        Me.Label8.TabIndex = 128
        Me.Label8.Text = "Registros" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccionados" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTexto
        '
        Me.lblTexto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTexto.AutoSize = True
        Me.lblTexto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTexto.ForeColor = System.Drawing.Color.BlueViolet
        Me.lblTexto.Location = New System.Drawing.Point(182, 16)
        Me.lblTexto.Name = "lblTexto"
        Me.lblTexto.Size = New System.Drawing.Size(241, 26)
        Me.lblTexto.TabIndex = 126
        Me.lblTexto.Text = "Cambios en el listado aún no han sido guardados " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "en la base de datos (dar click " &
    "en Guardar)"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnMostrar)
        Me.pnlAcciones.Controls.Add(Me.lblMostrar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(463, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(153, 65)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnMostrar
        '
        Me.btnMostrar.BackgroundImage = CType(resources.GetObject("btnMostrar.BackgroundImage"), System.Drawing.Image)
        Me.btnMostrar.Image = CType(resources.GetObject("btnMostrar.Image"), System.Drawing.Image)
        Me.btnMostrar.Location = New System.Drawing.Point(13, 6)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 20
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(9, 41)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 19
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = CType(resources.GetObject("btnGuardar.BackgroundImage"), System.Drawing.Image)
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(64, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 16
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(60, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 15
        Me.lblGuardar.Text = "Guardar"
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = CType(resources.GetObject("btnCerrar.BackgroundImage"), System.Drawing.Image)
        Me.btnCerrar.Location = New System.Drawing.Point(113, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 14
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(113, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.btnConfiguracionLicencia)
        Me.pnlListaPaises.Controls.Add(Me.Label1)
        Me.pnlListaPaises.Controls.Add(Me.btnConfiguracionGeneral)
        Me.pnlListaPaises.Controls.Add(Me.lblConfiguracionGeneral)
        Me.pnlListaPaises.Controls.Add(Me.lblCopiarCliente)
        Me.pnlListaPaises.Controls.Add(Me.btnExportar)
        Me.pnlListaPaises.Controls.Add(Me.lblExportar)
        Me.pnlListaPaises.Controls.Add(Me.btnCopiarCliente)
        Me.pnlListaPaises.Controls.Add(Me.btnEditar)
        Me.pnlListaPaises.Controls.Add(Me.lblEditar)
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(616, 72)
        Me.pnlListaPaises.TabIndex = 70
        '
        'btnConfiguracionLicencia
        '
        Me.btnConfiguracionLicencia.Image = Global.Programacion.Vista.My.Resources.Resources.OProduccion
        Me.btnConfiguracionLicencia.Location = New System.Drawing.Point(252, 7)
        Me.btnConfiguracionLicencia.Name = "btnConfiguracionLicencia"
        Me.btnConfiguracionLicencia.Size = New System.Drawing.Size(32, 32)
        Me.btnConfiguracionLicencia.TabIndex = 28
        Me.btnConfiguracionLicencia.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(235, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 26)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Configuración" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    Licencia"
        '
        'btnConfiguracionGeneral
        '
        Me.btnConfiguracionGeneral.BackgroundImage = CType(resources.GetObject("btnConfiguracionGeneral.BackgroundImage"), System.Drawing.Image)
        Me.btnConfiguracionGeneral.Location = New System.Drawing.Point(126, 7)
        Me.btnConfiguracionGeneral.Name = "btnConfiguracionGeneral"
        Me.btnConfiguracionGeneral.Size = New System.Drawing.Size(32, 32)
        Me.btnConfiguracionGeneral.TabIndex = 26
        Me.btnConfiguracionGeneral.UseVisualStyleBackColor = True
        '
        'lblConfiguracionGeneral
        '
        Me.lblConfiguracionGeneral.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblConfiguracionGeneral.Location = New System.Drawing.Point(107, 40)
        Me.lblConfiguracionGeneral.Name = "lblConfiguracionGeneral"
        Me.lblConfiguracionGeneral.Size = New System.Drawing.Size(73, 31)
        Me.lblConfiguracionGeneral.TabIndex = 25
        Me.lblConfiguracionGeneral.Text = "Configuración general"
        Me.lblConfiguracionGeneral.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCopiarCliente
        '
        Me.lblCopiarCliente.AutoSize = True
        Me.lblCopiarCliente.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCopiarCliente.Location = New System.Drawing.Point(52, 42)
        Me.lblCopiarCliente.Name = "lblCopiarCliente"
        Me.lblCopiarCliente.Size = New System.Drawing.Size(59, 26)
        Me.lblCopiarCliente.TabIndex = 24
        Me.lblCopiarCliente.Text = "Copiar a " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "otro cliente"
        Me.lblCopiarCliente.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnExportar
        '
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(189, 7)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 23
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(182, 42)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 22
        Me.lblExportar.Text = "Exportar"
        '
        'btnCopiarCliente
        '
        Me.btnCopiarCliente.BackgroundImage = CType(resources.GetObject("btnCopiarCliente.BackgroundImage"), System.Drawing.Image)
        Me.btnCopiarCliente.Image = CType(resources.GetObject("btnCopiarCliente.Image"), System.Drawing.Image)
        Me.btnCopiarCliente.Location = New System.Drawing.Point(65, 7)
        Me.btnCopiarCliente.Name = "btnCopiarCliente"
        Me.btnCopiarCliente.Size = New System.Drawing.Size(32, 32)
        Me.btnCopiarCliente.TabIndex = 20
        Me.btnCopiarCliente.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.BackgroundImage = CType(resources.GetObject("btnEditar.BackgroundImage"), System.Drawing.Image)
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(12, 7)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 18
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(10, 42)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 17
        Me.lblEditar.Text = "Editar"
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(391, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(225, 72)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(13, 15)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(152, 40)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Administrador de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tallas Extranjeras"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(163, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AdministradorTallasExtranjeras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 515)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(624, 542)
        Me.Name = "AdministradorTallasExtranjeras"
        Me.Text = "Administrador de Tallas Extranjeras"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GrdTallasExtranjerasFamilias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrdVTallasExtranjerasFamilias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cmbClientes As ComboBox
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblGuardar As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents pnlListaPaises As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents btnCopiarCliente As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents lblEditar As Label
    Friend WithEvents lblTexto As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnExportar As Button
    Friend WithEvents lblExportar As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblRegistrosSeleccionados As Label
    Friend WithEvents lblCopiarCliente As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents lblMostrar As Label
    Friend WithEvents btnConfiguracionGeneral As Button
    Friend WithEvents lblConfiguracionGeneral As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GrdTallasExtranjerasFamilias As DevExpress.XtraGrid.GridControl
    Friend WithEvents GrdVTallasExtranjerasFamilias As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents cbxSeleccionarTodo As CheckBox
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents Label2 As Label
    Friend WithEvents btnConfiguracionLicencia As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
