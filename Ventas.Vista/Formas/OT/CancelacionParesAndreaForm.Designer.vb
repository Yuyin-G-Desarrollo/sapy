<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CancelacionParesAndreaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CancelacionParesAndreaForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancelacionPares = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblColorEnRuta = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblColorParcialmenteConfirmada = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblColorEntregada = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblColorCancelada = New System.Windows.Forms.Panel()
        Me.lblColorRechazada = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblColorEjecucion = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblColorPorFacturar = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblColorFacturada = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblColorConfirmada = New System.Windows.Forms.Panel()
        Me.lblTiendaCompleta = New System.Windows.Forms.Label()
        Me.lblColorIncompleta = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkSeleccionarTodos = New System.Windows.Forms.CheckBox()
        Me.grdPartidas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdPartidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1240, 59)
        Me.pnlEncabezado.TabIndex = 69
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1240, 59)
        Me.pnlTitulo.TabIndex = 20
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCancelacionPares)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1172, 59)
        Me.Panel1.TabIndex = 47
        '
        'btnCancelacionPares
        '
        Me.btnCancelacionPares.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelacionPares.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar_32
        Me.btnCancelacionPares.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelacionPares.Location = New System.Drawing.Point(33, 5)
        Me.btnCancelacionPares.Name = "btnCancelacionPares"
        Me.btnCancelacionPares.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelacionPares.TabIndex = 48
        Me.btnCancelacionPares.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(9, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Cancelar Pares"
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(948, 17)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(221, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Cancelación Pares Andrea"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(1172, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Label10)
        Me.pnlPie.Controls.Add(Me.lblColorEnRuta)
        Me.pnlPie.Controls.Add(Me.Label11)
        Me.pnlPie.Controls.Add(Me.lblColorParcialmenteConfirmada)
        Me.pnlPie.Controls.Add(Me.Label14)
        Me.pnlPie.Controls.Add(Me.lblColorEntregada)
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.lblColorCancelada)
        Me.pnlPie.Controls.Add(Me.lblColorRechazada)
        Me.pnlPie.Controls.Add(Me.Label6)
        Me.pnlPie.Controls.Add(Me.Label25)
        Me.pnlPie.Controls.Add(Me.lblColorEjecucion)
        Me.pnlPie.Controls.Add(Me.Label9)
        Me.pnlPie.Controls.Add(Me.lblColorPorFacturar)
        Me.pnlPie.Controls.Add(Me.Label8)
        Me.pnlPie.Controls.Add(Me.lblColorFacturada)
        Me.pnlPie.Controls.Add(Me.Label7)
        Me.pnlPie.Controls.Add(Me.lblColorConfirmada)
        Me.pnlPie.Controls.Add(Me.lblTiendaCompleta)
        Me.pnlPie.Controls.Add(Me.lblColorIncompleta)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 415)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1240, 71)
        Me.pnlPie.TabIndex = 70
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(196, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 141
        Me.Label10.Text = "En Ruta"
        '
        'lblColorEnRuta
        '
        Me.lblColorEnRuta.BackColor = System.Drawing.Color.Coral
        Me.lblColorEnRuta.ForeColor = System.Drawing.Color.Black
        Me.lblColorEnRuta.Location = New System.Drawing.Point(178, 37)
        Me.lblColorEnRuta.Name = "lblColorEnRuta"
        Me.lblColorEnRuta.Size = New System.Drawing.Size(15, 15)
        Me.lblColorEnRuta.TabIndex = 142
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(285, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(123, 13)
        Me.Label11.TabIndex = 139
        Me.Label11.Text = "Parcialmente confirmada"
        '
        'lblColorParcialmenteConfirmada
        '
        Me.lblColorParcialmenteConfirmada.BackColor = System.Drawing.Color.Plum
        Me.lblColorParcialmenteConfirmada.ForeColor = System.Drawing.Color.Black
        Me.lblColorParcialmenteConfirmada.Location = New System.Drawing.Point(267, 16)
        Me.lblColorParcialmenteConfirmada.Name = "lblColorParcialmenteConfirmada"
        Me.lblColorParcialmenteConfirmada.Size = New System.Drawing.Size(15, 15)
        Me.lblColorParcialmenteConfirmada.TabIndex = 140
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(285, 39)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 13)
        Me.Label14.TabIndex = 137
        Me.Label14.Text = "Entregada"
        '
        'lblColorEntregada
        '
        Me.lblColorEntregada.BackColor = System.Drawing.Color.IndianRed
        Me.lblColorEntregada.ForeColor = System.Drawing.Color.Black
        Me.lblColorEntregada.Location = New System.Drawing.Point(267, 37)
        Me.lblColorEntregada.Name = "lblColorEntregada"
        Me.lblColorEntregada.Size = New System.Drawing.Size(15, 15)
        Me.lblColorEntregada.TabIndex = 138
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(428, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 131
        Me.Label5.Text = "Cancelada"
        '
        'lblColorCancelada
        '
        Me.lblColorCancelada.BackColor = System.Drawing.Color.LightCoral
        Me.lblColorCancelada.ForeColor = System.Drawing.Color.Black
        Me.lblColorCancelada.Location = New System.Drawing.Point(410, 39)
        Me.lblColorCancelada.Name = "lblColorCancelada"
        Me.lblColorCancelada.Size = New System.Drawing.Size(15, 15)
        Me.lblColorCancelada.TabIndex = 132
        '
        'lblColorRechazada
        '
        Me.lblColorRechazada.BackColor = System.Drawing.Color.DarkOrange
        Me.lblColorRechazada.ForeColor = System.Drawing.Color.Black
        Me.lblColorRechazada.Location = New System.Drawing.Point(493, 39)
        Me.lblColorRechazada.Name = "lblColorRechazada"
        Me.lblColorRechazada.Size = New System.Drawing.Size(15, 15)
        Me.lblColorRechazada.TabIndex = 136
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(511, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 135
        Me.Label6.Text = "Rechazada"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(196, 18)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(69, 13)
        Me.Label25.TabIndex = 133
        Me.Label25.Text = "En ejecución"
        '
        'lblColorEjecucion
        '
        Me.lblColorEjecucion.BackColor = System.Drawing.Color.DodgerBlue
        Me.lblColorEjecucion.ForeColor = System.Drawing.Color.Black
        Me.lblColorEjecucion.Location = New System.Drawing.Point(178, 16)
        Me.lblColorEjecucion.Name = "lblColorEjecucion"
        Me.lblColorEjecucion.Size = New System.Drawing.Size(15, 15)
        Me.lblColorEjecucion.TabIndex = 134
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(511, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 129
        Me.Label9.Text = "Por Facturar"
        '
        'lblColorPorFacturar
        '
        Me.lblColorPorFacturar.BackColor = System.Drawing.Color.RosyBrown
        Me.lblColorPorFacturar.ForeColor = System.Drawing.Color.Black
        Me.lblColorPorFacturar.Location = New System.Drawing.Point(493, 16)
        Me.lblColorPorFacturar.Name = "lblColorPorFacturar"
        Me.lblColorPorFacturar.Size = New System.Drawing.Size(15, 15)
        Me.lblColorPorFacturar.TabIndex = 130
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(121, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 127
        Me.Label8.Text = "Facturada"
        '
        'lblColorFacturada
        '
        Me.lblColorFacturada.BackColor = System.Drawing.Color.Pink
        Me.lblColorFacturada.ForeColor = System.Drawing.Color.Black
        Me.lblColorFacturada.Location = New System.Drawing.Point(103, 37)
        Me.lblColorFacturada.Name = "lblColorFacturada"
        Me.lblColorFacturada.Size = New System.Drawing.Size(15, 15)
        Me.lblColorFacturada.TabIndex = 128
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(429, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 125
        Me.Label7.Text = "Confirmada"
        '
        'lblColorConfirmada
        '
        Me.lblColorConfirmada.BackColor = System.Drawing.Color.HotPink
        Me.lblColorConfirmada.ForeColor = System.Drawing.Color.Black
        Me.lblColorConfirmada.Location = New System.Drawing.Point(411, 16)
        Me.lblColorConfirmada.Name = "lblColorConfirmada"
        Me.lblColorConfirmada.Size = New System.Drawing.Size(15, 15)
        Me.lblColorConfirmada.TabIndex = 126
        '
        'lblTiendaCompleta
        '
        Me.lblTiendaCompleta.AutoSize = True
        Me.lblTiendaCompleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiendaCompleta.Location = New System.Drawing.Point(121, 18)
        Me.lblTiendaCompleta.Name = "lblTiendaCompleta"
        Me.lblTiendaCompleta.Size = New System.Drawing.Size(59, 13)
        Me.lblTiendaCompleta.TabIndex = 118
        Me.lblTiendaCompleta.Text = "Incompleta"
        '
        'lblColorIncompleta
        '
        Me.lblColorIncompleta.BackColor = System.Drawing.Color.Gold
        Me.lblColorIncompleta.Location = New System.Drawing.Point(105, 16)
        Me.lblColorIncompleta.Name = "lblColorIncompleta"
        Me.lblColorIncompleta.Size = New System.Drawing.Size(13, 15)
        Me.lblColorIncompleta.TabIndex = 117
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1110, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(130, 71)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(62, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(61, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(9, 33)
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
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 24)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Registros"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel3.Controls.Add(Me.chkSeleccionarTodos)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 59)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1240, 43)
        Me.Panel3.TabIndex = 75
        '
        'chkSeleccionarTodos
        '
        Me.chkSeleccionarTodos.AutoSize = True
        Me.chkSeleccionarTodos.Location = New System.Drawing.Point(14, 13)
        Me.chkSeleccionarTodos.Name = "chkSeleccionarTodos"
        Me.chkSeleccionarTodos.Size = New System.Drawing.Size(115, 17)
        Me.chkSeleccionarTodos.TabIndex = 0
        Me.chkSeleccionarTodos.Text = "Seleccionar Todos"
        Me.chkSeleccionarTodos.UseVisualStyleBackColor = True
        '
        'grdPartidas
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPartidas.DisplayLayout.Appearance = Appearance1
        Me.grdPartidas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdPartidas.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdPartidas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdPartidas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdPartidas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPartidas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdPartidas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdPartidas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdPartidas.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdPartidas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPartidas.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.grdPartidas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPartidas.Location = New System.Drawing.Point(0, 102)
        Me.grdPartidas.Name = "grdPartidas"
        Me.grdPartidas.Size = New System.Drawing.Size(1240, 313)
        Me.grdPartidas.TabIndex = 76
        '
        'CancelacionParesAndreaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1240, 486)
        Me.Controls.Add(Me.grdPartidas)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "CancelacionParesAndreaForm"
        Me.Text = "Cancelación Pares Andrea"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.grdPartidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblColorEnRuta As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblColorParcialmenteConfirmada As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblColorEntregada As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblColorCancelada As System.Windows.Forms.Panel
    Friend WithEvents lblColorRechazada As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblColorEjecucion As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblColorPorFacturar As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblColorFacturada As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblColorConfirmada As System.Windows.Forms.Panel
    Friend WithEvents lblTiendaCompleta As System.Windows.Forms.Label
    Friend WithEvents lblColorIncompleta As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblNumFiltrados As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents chkSeleccionarTodos As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancelacionPares As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grdPartidas As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
