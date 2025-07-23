<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DevolucionInformativaSalidaAlmacenForm
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
        Me.grdParesDevueltos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlCampos = New System.Windows.Forms.Panel()
        Me.lblParesEmbarque = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblFechaEmbarque = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblIdEmbarque = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblParesNoRecibidos = New System.Windows.Forms.Label()
        Me.lblParesEntregadosEmbarque = New System.Windows.Forms.Label()
        Me.lblTotalParesEmbarque = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblMensajeEditarPrsNoRecibidos = New System.Windows.Forms.Label()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.chkSeleccionarTodo = New System.Windows.Forms.CheckBox()
        CType(Me.grdParesDevueltos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCampos.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdParesDevueltos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdParesDevueltos.DisplayLayout.Appearance = Appearance1
        Me.grdParesDevueltos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdParesDevueltos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdParesDevueltos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdParesDevueltos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdParesDevueltos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdParesDevueltos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdParesDevueltos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdParesDevueltos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdParesDevueltos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdParesDevueltos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdParesDevueltos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdParesDevueltos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdParesDevueltos.Location = New System.Drawing.Point(0, 108)
        Me.grdParesDevueltos.Name = "grdParesDevueltos"
        Me.grdParesDevueltos.Size = New System.Drawing.Size(1048, 355)
        Me.grdParesDevueltos.TabIndex = 41
        '
        'pnlCampos
        '
        Me.pnlCampos.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlCampos.Controls.Add(Me.chkSeleccionarTodo)
        Me.pnlCampos.Controls.Add(Me.lblParesEmbarque)
        Me.pnlCampos.Controls.Add(Me.Label14)
        Me.pnlCampos.Controls.Add(Me.lblFechaEmbarque)
        Me.pnlCampos.Controls.Add(Me.Label10)
        Me.pnlCampos.Controls.Add(Me.lblCliente)
        Me.pnlCampos.Controls.Add(Me.Label8)
        Me.pnlCampos.Controls.Add(Me.lblIdEmbarque)
        Me.pnlCampos.Controls.Add(Me.Label11)
        Me.pnlCampos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCampos.Location = New System.Drawing.Point(0, 60)
        Me.pnlCampos.Name = "pnlCampos"
        Me.pnlCampos.Size = New System.Drawing.Size(1048, 48)
        Me.pnlCampos.TabIndex = 44
        '
        'lblParesEmbarque
        '
        Me.lblParesEmbarque.AutoSize = True
        Me.lblParesEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesEmbarque.Location = New System.Drawing.Point(947, 7)
        Me.lblParesEmbarque.Name = "lblParesEmbarque"
        Me.lblParesEmbarque.Size = New System.Drawing.Size(21, 15)
        Me.lblParesEmbarque.TabIndex = 94
        Me.lblParesEmbarque.Text = "75"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(826, 7)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(115, 15)
        Me.Label14.TabIndex = 93
        Me.Label14.Text = "Pares Embarcados:"
        '
        'lblFechaEmbarque
        '
        Me.lblFechaEmbarque.AutoSize = True
        Me.lblFechaEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaEmbarque.Location = New System.Drawing.Point(661, 7)
        Me.lblFechaEmbarque.Name = "lblFechaEmbarque"
        Me.lblFechaEmbarque.Size = New System.Drawing.Size(125, 15)
        Me.lblFechaEmbarque.TabIndex = 92
        Me.lblFechaEmbarque.Text = "30/11/2015 04:35 PM"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(550, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 15)
        Me.Label10.TabIndex = 91
        Me.Label10.Text = "Fecha Embarque:"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(221, 7)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(279, 15)
        Me.lblCliente.TabIndex = 90
        Me.lblCliente.Text = "ZAPATERÍAS MÉXICO ENCADENADAS SA DE CV "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(170, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 15)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "Cliente"
        '
        'lblIdEmbarque
        '
        Me.lblIdEmbarque.AutoSize = True
        Me.lblIdEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdEmbarque.Location = New System.Drawing.Point(99, 6)
        Me.lblIdEmbarque.Name = "lblIdEmbarque"
        Me.lblIdEmbarque.Size = New System.Drawing.Size(14, 15)
        Me.lblIdEmbarque.TabIndex = 88
        Me.lblIdEmbarque.Text = "8"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 15)
        Me.Label11.TabIndex = 86
        Me.Label11.Text = "Id Embarque:"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.BackColor = System.Drawing.Color.White
        Me.pnlAcciones.Controls.Add(Me.Panel1)
        Me.pnlAcciones.Controls.Add(Me.lblMensajeEditarPrsNoRecibidos)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 463)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(1048, 60)
        Me.pnlAcciones.TabIndex = 43
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblParesNoRecibidos)
        Me.Panel1.Controls.Add(Me.lblParesEntregadosEmbarque)
        Me.Panel1.Controls.Add(Me.lblTotalParesEmbarque)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.lblAceptar)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(622, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(426, 60)
        Me.Panel1.TabIndex = 131
        '
        'lblParesNoRecibidos
        '
        Me.lblParesNoRecibidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesNoRecibidos.ForeColor = System.Drawing.Color.Black
        Me.lblParesNoRecibidos.Location = New System.Drawing.Point(193, 39)
        Me.lblParesNoRecibidos.Name = "lblParesNoRecibidos"
        Me.lblParesNoRecibidos.Size = New System.Drawing.Size(80, 20)
        Me.lblParesNoRecibidos.TabIndex = 141
        Me.lblParesNoRecibidos.Text = "52"
        Me.lblParesNoRecibidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblParesEntregadosEmbarque
        '
        Me.lblParesEntregadosEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesEntregadosEmbarque.ForeColor = System.Drawing.Color.Black
        Me.lblParesEntregadosEmbarque.Location = New System.Drawing.Point(193, 21)
        Me.lblParesEntregadosEmbarque.Name = "lblParesEntregadosEmbarque"
        Me.lblParesEntregadosEmbarque.Size = New System.Drawing.Size(80, 20)
        Me.lblParesEntregadosEmbarque.TabIndex = 140
        Me.lblParesEntregadosEmbarque.Text = "23"
        Me.lblParesEntregadosEmbarque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalParesEmbarque
        '
        Me.lblTotalParesEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalParesEmbarque.ForeColor = System.Drawing.Color.Black
        Me.lblTotalParesEmbarque.Location = New System.Drawing.Point(188, 3)
        Me.lblTotalParesEmbarque.Name = "lblTotalParesEmbarque"
        Me.lblTotalParesEmbarque.Size = New System.Drawing.Size(88, 20)
        Me.lblTotalParesEmbarque.TabIndex = 139
        Me.lblTotalParesEmbarque.Text = "75"
        Me.lblTotalParesEmbarque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(115, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 20)
        Me.Label5.TabIndex = 138
        Me.Label5.Text = "No Recibidos: "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(113, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 20)
        Me.Label15.TabIndex = 137
        Me.Label15.Text = "Entregados :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(114, 3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 20)
        Me.Label16.TabIndex = 136
        Me.Label16.Text = "Total :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(-2, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 42)
        Me.Label3.TabIndex = 135
        Me.Label3.Text = "Resumen de pares " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "del embarque"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(371, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 133
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(314, 40)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(45, 13)
        Me.lblAceptar.TabIndex = 131
        Me.lblAceptar.Text = "Guardar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(372, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 132
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Almacen.Vista.My.Resources.Resources.guardar2_3211
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(321, 6)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 134
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'lblMensajeEditarPrsNoRecibidos
        '
        Me.lblMensajeEditarPrsNoRecibidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeEditarPrsNoRecibidos.ForeColor = System.Drawing.Color.Black
        Me.lblMensajeEditarPrsNoRecibidos.Location = New System.Drawing.Point(3, 6)
        Me.lblMensajeEditarPrsNoRecibidos.Name = "lblMensajeEditarPrsNoRecibidos"
        Me.lblMensajeEditarPrsNoRecibidos.Size = New System.Drawing.Size(407, 42)
        Me.lblMensajeEditarPrsNoRecibidos.TabIndex = 122
        Me.lblMensajeEditarPrsNoRecibidos.Text = "Al seleccionar la casilla la cantidad de *Prs NoRecibidos será igual a la de los " & _
    "PrsEmbarque (la cantidad de *Prs NoRecibidos se puede modificar)"
        Me.lblMensajeEditarPrsNoRecibidos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.lblExportar)
        Me.pnlCabecera.Controls.Add(Me.btnExportar)
        Me.pnlCabecera.Controls.Add(Me.pnlTitulo)
        Me.pnlCabecera.Controls.Add(Me.imgLogo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(1048, 60)
        Me.pnlCabecera.TabIndex = 42
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(17, 39)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 38
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Almacen.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(22, 5)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 37
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(427, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(551, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(286, 17)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(265, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Pares no recibidos por el cliente"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(978, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'chkSeleccionarTodo
        '
        Me.chkSeleccionarTodo.AutoSize = True
        Me.chkSeleccionarTodo.Location = New System.Drawing.Point(6, 26)
        Me.chkSeleccionarTodo.Name = "chkSeleccionarTodo"
        Me.chkSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarTodo.TabIndex = 95
        Me.chkSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chkSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'DevolucionInformativaSalidaAlmacenForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1048, 523)
        Me.ControlBox = False
        Me.Controls.Add(Me.grdParesDevueltos)
        Me.Controls.Add(Me.pnlCampos)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.pnlCabecera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimumSize = New System.Drawing.Size(1054, 529)
        Me.Name = "DevolucionInformativaSalidaAlmacenForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pares no recibidos por el cliente"
        CType(Me.grdParesDevueltos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCampos.ResumeLayout(False)
        Me.pnlCampos.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdParesDevueltos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlCampos As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblMensajeEditarPrsNoRecibidos As System.Windows.Forms.Label
    Friend WithEvents lblParesEmbarque As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblFechaEmbarque As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblIdEmbarque As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblParesNoRecibidos As System.Windows.Forms.Label
    Friend WithEvents lblParesEntregadosEmbarque As System.Windows.Forms.Label
    Friend WithEvents lblTotalParesEmbarque As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents chkSeleccionarTodo As System.Windows.Forms.CheckBox
End Class
