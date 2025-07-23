<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerarEntregaAlmacenForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenerarEntregaAlmacenForm))
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.lblDetalles = New System.Windows.Forms.Label()
        Me.btnDetalles = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdListaSalidas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlCampos = New System.Windows.Forms.Panel()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbUnidad = New System.Windows.Forms.ComboBox()
        Me.cmbOperador = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbMensajeriaReal = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.pnlBotonArribaAbajo = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.pnlBotonesPantalla = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grdListaSalidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCampos.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.pnlBotonArribaAbajo.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlBotonesPantalla.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.lblDetalles)
        Me.pnlCabecera.Controls.Add(Me.btnDetalles)
        Me.pnlCabecera.Controls.Add(Me.pnlTitulo)
        Me.pnlCabecera.Controls.Add(Me.imgLogo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(916, 60)
        Me.pnlCabecera.TabIndex = 34
        '
        'lblDetalles
        '
        Me.lblDetalles.AutoSize = True
        Me.lblDetalles.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDetalles.Location = New System.Drawing.Point(10, 41)
        Me.lblDetalles.Name = "lblDetalles"
        Me.lblDetalles.Size = New System.Drawing.Size(53, 13)
        Me.lblDetalles.TabIndex = 41
        Me.lblDetalles.Text = "Ver Pares"
        '
        'btnDetalles
        '
        Me.btnDetalles.Image = Global.Almacen.Vista.My.Resources.Resources.pares
        Me.btnDetalles.Location = New System.Drawing.Point(20, 8)
        Me.btnDetalles.Name = "btnDetalles"
        Me.btnDetalles.Size = New System.Drawing.Size(32, 32)
        Me.btnDetalles.TabIndex = 42
        Me.btnDetalles.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(636, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(210, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(48, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(162, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Generar Embarque"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(846, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdListaSalidas)
        Me.Panel1.Controls.Add(Me.pnlCampos)
        Me.Panel1.Controls.Add(Me.pnlAcciones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(916, 435)
        Me.Panel1.TabIndex = 35
        '
        'grdListaSalidas
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaSalidas.DisplayLayout.Appearance = Appearance1
        Me.grdListaSalidas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdListaSalidas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdListaSalidas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdListaSalidas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaSalidas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaSalidas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdListaSalidas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListaSalidas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdListaSalidas.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListaSalidas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaSalidas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaSalidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdListaSalidas.Location = New System.Drawing.Point(0, 142)
        Me.grdListaSalidas.Name = "grdListaSalidas"
        Me.grdListaSalidas.Size = New System.Drawing.Size(916, 233)
        Me.grdListaSalidas.TabIndex = 37
        '
        'pnlCampos
        '
        Me.pnlCampos.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlCampos.Controls.Add(Me.grbFiltros)
        Me.pnlCampos.Controls.Add(Me.pnlBotonArribaAbajo)
        Me.pnlCampos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCampos.Location = New System.Drawing.Point(0, 0)
        Me.pnlCampos.Name = "pnlCampos"
        Me.pnlCampos.Size = New System.Drawing.Size(916, 142)
        Me.pnlCampos.TabIndex = 39
        '
        'grbFiltros
        '
        Me.grbFiltros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.Controls.Add(Me.cmbUnidad)
        Me.grbFiltros.Controls.Add(Me.cmbOperador)
        Me.grbFiltros.Controls.Add(Me.Label2)
        Me.grbFiltros.Controls.Add(Me.Label1)
        Me.grbFiltros.Controls.Add(Me.cmbMensajeriaReal)
        Me.grbFiltros.Controls.Add(Me.lblNave)
        Me.grbFiltros.Location = New System.Drawing.Point(12, 26)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(894, 108)
        Me.grbFiltros.TabIndex = 31
        Me.grbFiltros.TabStop = False
        '
        'cmbUnidad
        '
        Me.cmbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnidad.FormattingEnabled = True
        Me.cmbUnidad.ItemHeight = 13
        Me.cmbUnidad.Location = New System.Drawing.Point(296, 79)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.Size = New System.Drawing.Size(390, 21)
        Me.cmbUnidad.TabIndex = 88
        '
        'cmbOperador
        '
        Me.cmbOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperador.FormattingEnabled = True
        Me.cmbOperador.ItemHeight = 13
        Me.cmbOperador.Location = New System.Drawing.Point(296, 48)
        Me.cmbOperador.Name = "cmbOperador"
        Me.cmbOperador.Size = New System.Drawing.Size(390, 21)
        Me.cmbOperador.TabIndex = 87
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(195, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "Unidad"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(195, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Operador"
        '
        'cmbMensajeriaReal
        '
        Me.cmbMensajeriaReal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMensajeriaReal.FormattingEnabled = True
        Me.cmbMensajeriaReal.ItemHeight = 13
        Me.cmbMensajeriaReal.Location = New System.Drawing.Point(296, 19)
        Me.cmbMensajeriaReal.Name = "cmbMensajeriaReal"
        Me.cmbMensajeriaReal.Size = New System.Drawing.Size(390, 21)
        Me.cmbMensajeriaReal.TabIndex = 6
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(195, 22)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(92, 13)
        Me.lblNave.TabIndex = 84
        Me.lblNave.Text = "* Mensajería Real"
        '
        'pnlBotonArribaAbajo
        '
        Me.pnlBotonArribaAbajo.Controls.Add(Me.btnArriba)
        Me.pnlBotonArribaAbajo.Controls.Add(Me.btnAbajo)
        Me.pnlBotonArribaAbajo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonArribaAbajo.Location = New System.Drawing.Point(839, 0)
        Me.pnlBotonArribaAbajo.Name = "pnlBotonArribaAbajo"
        Me.pnlBotonArribaAbajo.Size = New System.Drawing.Size(77, 142)
        Me.pnlBotonArribaAbajo.TabIndex = 30
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(16, 2)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(22, 22)
        Me.btnArriba.TabIndex = 3
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(43, 2)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(22, 22)
        Me.btnAbajo.TabIndex = 4
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'pnlAcciones
        '
        Me.pnlAcciones.BackColor = System.Drawing.Color.White
        Me.pnlAcciones.Controls.Add(Me.pnlBotonesPantalla)
        Me.pnlAcciones.Controls.Add(Me.Label4)
        Me.pnlAcciones.Controls.Add(Me.Label5)
        Me.pnlAcciones.Controls.Add(Me.lblNumFiltrados)
        Me.pnlAcciones.Controls.Add(Me.Label3)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 375)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(916, 60)
        Me.pnlAcciones.TabIndex = 38
        '
        'pnlBotonesPantalla
        '
        Me.pnlBotonesPantalla.Controls.Add(Me.btnCancelar)
        Me.pnlBotonesPantalla.Controls.Add(Me.lblAceptar)
        Me.pnlBotonesPantalla.Controls.Add(Me.lblCancelar)
        Me.pnlBotonesPantalla.Controls.Add(Me.btnAceptar)
        Me.pnlBotonesPantalla.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonesPantalla.Location = New System.Drawing.Point(783, 0)
        Me.pnlBotonesPantalla.Name = "pnlBotonesPantalla"
        Me.pnlBotonesPantalla.Size = New System.Drawing.Size(133, 60)
        Me.pnlBotonesPantalla.TabIndex = 122
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(78, 7)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(21, 41)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(45, 13)
        Me.lblAceptar.TabIndex = 8
        Me.lblAceptar.Text = "Guardar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(77, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 9
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Almacen.Vista.My.Resources.Resources.guardar2_3211
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(28, 7)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 11
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(385, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(397, 13)
        Me.Label4.TabIndex = 121
        Me.Label4.Text = "y se considerará como embarque ENTREGADO, el resto se considerará EN RUTA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(320, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(463, 13)
        Me.Label5.TabIndex = 120
        Me.Label5.Text = "La mercancía embarcada en mensajerías externas será eliminada inmediatamente del " & _
    "inventario "
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(48, 27)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 22)
        Me.lblNumFiltrados.TabIndex = 119
        Me.lblNumFiltrados.Text = "60"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(17, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 22)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Pares por embarcar"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GenerarEntregaAlmacenForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(916, 495)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlCabecera)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(932, 534)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(932, 534)
        Me.Name = "GenerarEntregaAlmacenForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar Embarque"
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdListaSalidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCampos.ResumeLayout(False)
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.pnlBotonArribaAbajo.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlBotonesPantalla.ResumeLayout(False)
        Me.pnlBotonesPantalla.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblDetalles As System.Windows.Forms.Label
    Friend WithEvents btnDetalles As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdListaSalidas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlCampos As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblNumFiltrados As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlBotonesPantalla As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents pnlBotonArribaAbajo As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents cmbUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOperador As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbMensajeriaReal As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
End Class
