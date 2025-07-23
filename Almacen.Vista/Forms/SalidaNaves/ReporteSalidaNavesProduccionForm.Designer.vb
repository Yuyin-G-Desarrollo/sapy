<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReporteSalidaNavesProduccionForm
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
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleExpression1 As DevExpress.XtraEditors.FormatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblSubtititulo = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlConsultaPorCedis = New System.Windows.Forms.Panel()
        Me.grid = New DevExpress.XtraGrid.GridControl()
        Me.gridV = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.pnlConsultaDetallada = New System.Windows.Forms.Panel()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.pnlColorReproceso = New System.Windows.Forms.Panel()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.pnlColorBloqueado = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.pnlColorProyectado = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.pnlColorAsignado = New System.Windows.Forms.Panel()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.pnlColorDisponible = New System.Windows.Forms.Panel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblError = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlColorError = New System.Windows.Forms.Panel()
        Me.lblAtado = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlColorAtado = New System.Windows.Forms.Panel()
        Me.lblPar = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlColorPar = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.pnlColorEmbarcado = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblColorSI = New System.Windows.Forms.Label()
        Me.lblColorNO = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdSalidaNaves = New DevExpress.XtraGrid.GridControl()
        Me.grdVSalidaNaves = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlConsultaPorCedis.SuspendLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConsultaDetallada.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdSalidaNaves, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVSalidaNaves, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlTitulo)
        Me.pnlCabecera.Controls.Add(Me.imgLogo)
        Me.pnlCabecera.Controls.Add(Me.btnExportar)
        Me.pnlCabecera.Controls.Add(Me.lblExportar)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(1184, 60)
        Me.pnlCabecera.TabIndex = 29
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblSubtititulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(756, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(358, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'lblSubtititulo
        '
        Me.lblSubtititulo.AutoSize = True
        Me.lblSubtititulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtititulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblSubtititulo.Location = New System.Drawing.Point(191, 33)
        Me.lblSubtititulo.Name = "lblSubtititulo"
        Me.lblSubtititulo.Size = New System.Drawing.Size(86, 18)
        Me.lblSubtititulo.TabIndex = 22
        Me.lblSubtititulo.Text = "lblSubtititulo"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(79, 13)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(273, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Auditoría de Entradas a Almacén"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(1114, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'btnExportar
        '
        Me.btnExportar.BackgroundImage = Global.Almacen.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(24, 8)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 1
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(17, 42)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 32
        Me.lblExportar.Text = "Exportar"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.pnlConsultaPorCedis)
        Me.Panel2.Controls.Add(Me.pnlConsultaDetallada)
        Me.Panel2.Controls.Add(Me.lblUltimaActualizacion)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.lblTotal)
        Me.Panel2.Controls.Add(Me.pnlDatosBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 426)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1184, 114)
        Me.Panel2.TabIndex = 34
        '
        'pnlConsultaPorCedis
        '
        Me.pnlConsultaPorCedis.Controls.Add(Me.grid)
        Me.pnlConsultaPorCedis.Controls.Add(Me.Label33)
        Me.pnlConsultaPorCedis.Controls.Add(Me.Panel13)
        Me.pnlConsultaPorCedis.Controls.Add(Me.Label34)
        Me.pnlConsultaPorCedis.Controls.Add(Me.Label35)
        Me.pnlConsultaPorCedis.Controls.Add(Me.Label36)
        Me.pnlConsultaPorCedis.Controls.Add(Me.Label37)
        Me.pnlConsultaPorCedis.Location = New System.Drawing.Point(3, 3)
        Me.pnlConsultaPorCedis.Name = "pnlConsultaPorCedis"
        Me.pnlConsultaPorCedis.Size = New System.Drawing.Size(750, 111)
        Me.pnlConsultaPorCedis.TabIndex = 187
        Me.pnlConsultaPorCedis.Visible = False
        '
        'grid
        '
        Me.grid.Location = New System.Drawing.Point(266, 7)
        Me.grid.MainView = Me.gridV
        Me.grid.Name = "grid"
        Me.grid.Size = New System.Drawing.Size(481, 98)
        Me.grid.TabIndex = 151
        Me.grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridV})
        '
        'gridV
        '
        Me.gridV.GridControl = Me.grid
        Me.gridV.Name = "gridV"
        Me.gridV.OptionsView.ShowGroupPanel = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(82, 34)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(133, 13)
        Me.Label33.TabIndex = 146
        Me.Label33.Text = "Embarcado (no entregado)"
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.Panel13.ForeColor = System.Drawing.Color.Black
        Me.Panel13.Location = New System.Drawing.Point(67, 34)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(12, 13)
        Me.Panel13.TabIndex = 144
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(64, 55)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(143, 13)
        Me.Label34.TabIndex = 147
        Me.Label34.Text = "EMD - Entregado mismo día "
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Label35.Location = New System.Drawing.Point(202, 55)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(19, 13)
        Me.Label35.TabIndex = 148
        Me.Label35.Text = "SI"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Label36.Location = New System.Drawing.Point(227, 55)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(25, 13)
        Me.Label36.TabIndex = 149
        Me.Label36.Text = "NO"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(218, 55)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(12, 13)
        Me.Label37.TabIndex = 150
        Me.Label37.Text = "/"
        '
        'pnlConsultaDetallada
        '
        Me.pnlConsultaDetallada.Controls.Add(Me.Label29)
        Me.pnlConsultaDetallada.Controls.Add(Me.pnlColorReproceso)
        Me.pnlConsultaDetallada.Controls.Add(Me.Label31)
        Me.pnlConsultaDetallada.Controls.Add(Me.pnlColorBloqueado)
        Me.pnlConsultaDetallada.Controls.Add(Me.Label20)
        Me.pnlConsultaDetallada.Controls.Add(Me.pnlColorProyectado)
        Me.pnlConsultaDetallada.Controls.Add(Me.Label22)
        Me.pnlConsultaDetallada.Controls.Add(Me.pnlColorAsignado)
        Me.pnlConsultaDetallada.Controls.Add(Me.Label24)
        Me.pnlConsultaDetallada.Controls.Add(Me.pnlColorDisponible)
        Me.pnlConsultaDetallada.Controls.Add(Me.Label25)
        Me.pnlConsultaDetallada.Controls.Add(Me.lblError)
        Me.pnlConsultaDetallada.Controls.Add(Me.Label13)
        Me.pnlConsultaDetallada.Controls.Add(Me.pnlColorError)
        Me.pnlConsultaDetallada.Controls.Add(Me.lblAtado)
        Me.pnlConsultaDetallada.Controls.Add(Me.Label9)
        Me.pnlConsultaDetallada.Controls.Add(Me.pnlColorAtado)
        Me.pnlConsultaDetallada.Controls.Add(Me.lblPar)
        Me.pnlConsultaDetallada.Controls.Add(Me.Label10)
        Me.pnlConsultaDetallada.Controls.Add(Me.pnlColorPar)
        Me.pnlConsultaDetallada.Controls.Add(Me.Label6)
        Me.pnlConsultaDetallada.Controls.Add(Me.Label14)
        Me.pnlConsultaDetallada.Controls.Add(Me.pnlColorEmbarcado)
        Me.pnlConsultaDetallada.Controls.Add(Me.Label15)
        Me.pnlConsultaDetallada.Controls.Add(Me.lblColorSI)
        Me.pnlConsultaDetallada.Controls.Add(Me.lblColorNO)
        Me.pnlConsultaDetallada.Controls.Add(Me.Label18)
        Me.pnlConsultaDetallada.Location = New System.Drawing.Point(3, 3)
        Me.pnlConsultaDetallada.Name = "pnlConsultaDetallada"
        Me.pnlConsultaDetallada.Size = New System.Drawing.Size(750, 108)
        Me.pnlConsultaDetallada.TabIndex = 166
        Me.pnlConsultaDetallada.Visible = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(123, 78)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(59, 13)
        Me.Label29.TabIndex = 186
        Me.Label29.Text = "Reproceso"
        '
        'pnlColorReproceso
        '
        Me.pnlColorReproceso.BackColor = System.Drawing.Color.Indigo
        Me.pnlColorReproceso.ForeColor = System.Drawing.Color.Black
        Me.pnlColorReproceso.Location = New System.Drawing.Point(109, 78)
        Me.pnlColorReproceso.Name = "pnlColorReproceso"
        Me.pnlColorReproceso.Size = New System.Drawing.Size(12, 13)
        Me.pnlColorReproceso.TabIndex = 185
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(35, 78)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(58, 13)
        Me.Label31.TabIndex = 184
        Me.Label31.Text = "Bloqueado"
        '
        'pnlColorBloqueado
        '
        Me.pnlColorBloqueado.BackColor = System.Drawing.Color.Red
        Me.pnlColorBloqueado.ForeColor = System.Drawing.Color.Black
        Me.pnlColorBloqueado.Location = New System.Drawing.Point(20, 78)
        Me.pnlColorBloqueado.Name = "pnlColorBloqueado"
        Me.pnlColorBloqueado.Size = New System.Drawing.Size(12, 13)
        Me.pnlColorBloqueado.TabIndex = 183
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(225, 78)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(61, 13)
        Me.Label20.TabIndex = 182
        Me.Label20.Text = "Proyectado"
        '
        'pnlColorProyectado
        '
        Me.pnlColorProyectado.BackColor = System.Drawing.Color.DeepPink
        Me.pnlColorProyectado.ForeColor = System.Drawing.Color.Black
        Me.pnlColorProyectado.Location = New System.Drawing.Point(210, 78)
        Me.pnlColorProyectado.Name = "pnlColorProyectado"
        Me.pnlColorProyectado.Size = New System.Drawing.Size(12, 13)
        Me.pnlColorProyectado.TabIndex = 181
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(123, 59)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(51, 13)
        Me.Label22.TabIndex = 180
        Me.Label22.Text = "Asignado"
        '
        'pnlColorAsignado
        '
        Me.pnlColorAsignado.BackColor = System.Drawing.Color.RoyalBlue
        Me.pnlColorAsignado.ForeColor = System.Drawing.Color.Black
        Me.pnlColorAsignado.Location = New System.Drawing.Point(109, 59)
        Me.pnlColorAsignado.Name = "pnlColorAsignado"
        Me.pnlColorAsignado.Size = New System.Drawing.Size(12, 13)
        Me.pnlColorAsignado.TabIndex = 179
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(35, 59)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(56, 13)
        Me.Label24.TabIndex = 178
        Me.Label24.Text = "Disponible"
        '
        'pnlColorDisponible
        '
        Me.pnlColorDisponible.BackColor = System.Drawing.Color.SeaGreen
        Me.pnlColorDisponible.ForeColor = System.Drawing.Color.Black
        Me.pnlColorDisponible.Location = New System.Drawing.Point(20, 59)
        Me.pnlColorDisponible.Name = "pnlColorDisponible"
        Me.pnlColorDisponible.Size = New System.Drawing.Size(12, 13)
        Me.pnlColorDisponible.TabIndex = 177
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(4, 41)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(42, 13)
        Me.Label25.TabIndex = 176
        Me.Label25.Text = "Estatus"
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.Location = New System.Drawing.Point(263, 23)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(31, 13)
        Me.lblError.TabIndex = 175
        Me.lblError.Text = "9999"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(225, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 174
        Me.Label13.Text = "Error :"
        '
        'pnlColorError
        '
        Me.pnlColorError.BackColor = System.Drawing.Color.Orange
        Me.pnlColorError.ForeColor = System.Drawing.Color.Black
        Me.pnlColorError.Location = New System.Drawing.Point(210, 23)
        Me.pnlColorError.Name = "pnlColorError"
        Me.pnlColorError.Size = New System.Drawing.Size(12, 13)
        Me.pnlColorError.TabIndex = 173
        '
        'lblAtado
        '
        Me.lblAtado.AutoSize = True
        Me.lblAtado.Location = New System.Drawing.Point(161, 23)
        Me.lblAtado.Name = "lblAtado"
        Me.lblAtado.Size = New System.Drawing.Size(31, 13)
        Me.lblAtado.TabIndex = 172
        Me.lblAtado.Text = "9999"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(123, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 171
        Me.Label9.Text = "Atado :"
        '
        'pnlColorAtado
        '
        Me.pnlColorAtado.BackColor = System.Drawing.Color.Aquamarine
        Me.pnlColorAtado.ForeColor = System.Drawing.Color.Black
        Me.pnlColorAtado.Location = New System.Drawing.Point(109, 23)
        Me.pnlColorAtado.Name = "pnlColorAtado"
        Me.pnlColorAtado.Size = New System.Drawing.Size(12, 13)
        Me.pnlColorAtado.TabIndex = 170
        '
        'lblPar
        '
        Me.lblPar.AutoSize = True
        Me.lblPar.Location = New System.Drawing.Point(62, 23)
        Me.lblPar.Name = "lblPar"
        Me.lblPar.Size = New System.Drawing.Size(31, 13)
        Me.lblPar.TabIndex = 169
        Me.lblPar.Text = "9999"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(35, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 13)
        Me.Label10.TabIndex = 168
        Me.Label10.Text = "Par :"
        '
        'pnlColorPar
        '
        Me.pnlColorPar.BackColor = System.Drawing.Color.Khaki
        Me.pnlColorPar.ForeColor = System.Drawing.Color.Black
        Me.pnlColorPar.Location = New System.Drawing.Point(20, 23)
        Me.pnlColorPar.Name = "pnlColorPar"
        Me.pnlColorPar.Size = New System.Drawing.Size(12, 13)
        Me.pnlColorPar.TabIndex = 167
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 166
        Me.Label6.Text = "Localizado como"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(564, 29)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(133, 13)
        Me.Label14.TabIndex = 146
        Me.Label14.Text = "Embarcado (no entregado)"
        '
        'pnlColorEmbarcado
        '
        Me.pnlColorEmbarcado.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.pnlColorEmbarcado.ForeColor = System.Drawing.Color.Black
        Me.pnlColorEmbarcado.Location = New System.Drawing.Point(549, 29)
        Me.pnlColorEmbarcado.Name = "pnlColorEmbarcado"
        Me.pnlColorEmbarcado.Size = New System.Drawing.Size(12, 13)
        Me.pnlColorEmbarcado.TabIndex = 144
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(546, 50)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(143, 13)
        Me.Label15.TabIndex = 147
        Me.Label15.Text = "EMD - Entregado mismo día "
        '
        'lblColorSI
        '
        Me.lblColorSI.AutoSize = True
        Me.lblColorSI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColorSI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.lblColorSI.Location = New System.Drawing.Point(684, 50)
        Me.lblColorSI.Name = "lblColorSI"
        Me.lblColorSI.Size = New System.Drawing.Size(19, 13)
        Me.lblColorSI.TabIndex = 148
        Me.lblColorSI.Text = "SI"
        '
        'lblColorNO
        '
        Me.lblColorNO.AutoSize = True
        Me.lblColorNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColorNO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.lblColorNO.Location = New System.Drawing.Point(709, 50)
        Me.lblColorNO.Name = "lblColorNO"
        Me.lblColorNO.Size = New System.Drawing.Size(25, 13)
        Me.lblColorNO.TabIndex = 149
        Me.lblColorNO.Text = "NO"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(700, 50)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(12, 13)
        Me.Label18.TabIndex = 150
        Me.Label18.Text = "/"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.Label12)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1018, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(166, 114)
        Me.pnlDatosBotones.TabIndex = 3
        '
        'btnMostrar
        '
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Almacen.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(36, 25)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 5
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(31, 57)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Mostrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(109, 25)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(108, 57)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'grdSalidaNaves
        '
        Me.grdSalidaNaves.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSalidaNaves.Location = New System.Drawing.Point(0, 60)
        Me.grdSalidaNaves.MainView = Me.grdVSalidaNaves
        Me.grdSalidaNaves.Name = "grdSalidaNaves"
        Me.grdSalidaNaves.Size = New System.Drawing.Size(1184, 366)
        Me.grdSalidaNaves.TabIndex = 35
        Me.grdSalidaNaves.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVSalidaNaves})
        '
        'grdVSalidaNaves
        '
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Name = "Format0"
        GridFormatRule1.Rule = FormatConditionRuleExpression1
        Me.grdVSalidaNaves.FormatRules.Add(GridFormatRule1)
        Me.grdVSalidaNaves.GridControl = Me.grdSalidaNaves
        Me.grdVSalidaNaves.Name = "grdVSalidaNaves"
        Me.grdVSalidaNaves.OptionsView.ShowAutoFilterRow = True
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(836, 31)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(100, 18)
        Me.lblTotal.TabIndex = 9
        Me.lblTotal.Text = "Total Pares:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(836, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Última Actualización:"
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(934, 58)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(65, 13)
        Me.lblUltimaActualizacion.TabIndex = 20
        Me.lblUltimaActualizacion.Text = "dd/mm/yyyy"
        '
        'ReporteSalidaNavesProduccionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 540)
        Me.Controls.Add(Me.grdSalidaNaves)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlCabecera)
        Me.Name = "ReporteSalidaNavesProduccionForm"
        Me.Text = "ReporteSalidaNavesProduccionForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlConsultaPorCedis.ResumeLayout(False)
        Me.pnlConsultaPorCedis.PerformLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConsultaDetallada.ResumeLayout(False)
        Me.pnlConsultaDetallada.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdSalidaNaves, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVSalidaNaves, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents imgLogo As PictureBox
    Friend WithEvents btnExportar As Button
    Friend WithEvents lblExportar As Label
    Friend WithEvents lblSubtititulo As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnMostrar As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents grdSalidaNaves As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVSalidaNaves As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label18 As Label
    Friend WithEvents lblColorNO As Label
    Friend WithEvents lblColorSI As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents pnlColorEmbarcado As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents pnlConsultaDetallada As Panel
    Friend WithEvents Label29 As Label
    Friend WithEvents pnlColorReproceso As Panel
    Friend WithEvents Label31 As Label
    Friend WithEvents pnlColorBloqueado As Panel
    Friend WithEvents Label20 As Label
    Friend WithEvents pnlColorProyectado As Panel
    Friend WithEvents Label22 As Label
    Friend WithEvents pnlColorAsignado As Panel
    Friend WithEvents Label24 As Label
    Friend WithEvents pnlColorDisponible As Panel
    Friend WithEvents Label25 As Label
    Friend WithEvents lblError As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents pnlColorError As Panel
    Friend WithEvents lblAtado As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents pnlColorAtado As Panel
    Friend WithEvents lblPar As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents pnlColorPar As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents pnlConsultaPorCedis As Panel
    Friend WithEvents Label33 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridV As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblUltimaActualizacion As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblTotal As Label
End Class
