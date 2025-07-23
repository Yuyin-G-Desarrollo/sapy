<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PedidosMuestras_SalidasEntradas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PedidosMuestras_SalidasEntradas))
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleExpression1 As DevExpress.XtraEditors.FormatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        Me.grdPiezasEnviadas = New DevExpress.XtraGrid.GridControl()
        Me.grdVPiezasEnviadas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblIncorrectas = New System.Windows.Forms.Label()
        Me.lblCorrectas = New System.Windows.Forms.Label()
        Me.lblLeidas = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblparesleidotitulo = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblDescartadas = New System.Windows.Forms.Label()
        Me.lblRegistrosSelecionados = New System.Windows.Forms.Label()
        Me.lblEntrega = New System.Windows.Forms.Label()
        Me.lblTRegistros = New System.Windows.Forms.Label()
        Me.lblTEntrega = New System.Windows.Forms.Label()
        Me.lblTDescartadas = New System.Windows.Forms.Label()
        Me.lblPendientes = New System.Windows.Forms.Label()
        Me.lblTPendientes = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblTTotal = New System.Windows.Forms.Label()
        Me.lblFolioEnvio = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboxNaveCedis = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.chkSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.txtcapturacodigos = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.cmbProceso = New System.Windows.Forms.ComboBox()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.lblCodigosConErrores = New System.Windows.Forms.Label()
        Me.btnCodigosConErrores = New System.Windows.Forms.Button()
        Me.lblDescartarLotes = New System.Windows.Forms.Label()
        Me.btnDescartarLotes = New System.Windows.Forms.Button()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.btnImprimirReporte = New System.Windows.Forms.Button()
        Me.btnDetener = New System.Windows.Forms.Button()
        Me.btnIniciar = New System.Windows.Forms.Button()
        Me.lblDetener = New System.Windows.Forms.Label()
        Me.lblIniciar = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.grdPiezasRecibidas = New DevExpress.XtraGrid.GridControl()
        Me.grdVPiezasRecibidas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        CType(Me.grdPiezasEnviadas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVPiezasEnviadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPiezasRecibidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVPiezasRecibidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdPiezasEnviadas
        '
        Me.grdPiezasEnviadas.Dock = System.Windows.Forms.DockStyle.Left
        Me.grdPiezasEnviadas.Location = New System.Drawing.Point(0, 0)
        Me.grdPiezasEnviadas.MainView = Me.grdVPiezasEnviadas
        Me.grdPiezasEnviadas.Name = "grdPiezasEnviadas"
        Me.grdPiezasEnviadas.Size = New System.Drawing.Size(612, 392)
        Me.grdPiezasEnviadas.TabIndex = 34
        Me.grdPiezasEnviadas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVPiezasEnviadas})
        '
        'grdVPiezasEnviadas
        '
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Name = "Format0"
        GridFormatRule1.Rule = Nothing
        GridFormatRule1.StopIfTrue = True
        Me.grdVPiezasEnviadas.FormatRules.Add(GridFormatRule1)
        Me.grdVPiezasEnviadas.GridControl = Me.grdPiezasEnviadas
        Me.grdVPiezasEnviadas.Name = "grdVPiezasEnviadas"
        Me.grdVPiezasEnviadas.OptionsNavigation.AutoFocusNewRow = True
        Me.grdVPiezasEnviadas.OptionsView.ShowGroupPanel = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.lblIncorrectas)
        Me.Panel2.Controls.Add(Me.lblCorrectas)
        Me.Panel2.Controls.Add(Me.lblLeidas)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.lblparesleidotitulo)
        Me.Panel2.Controls.Add(Me.pnlDatosBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 522)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1320, 60)
        Me.Panel2.TabIndex = 33
        '
        'lblIncorrectas
        '
        Me.lblIncorrectas.AutoSize = True
        Me.lblIncorrectas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncorrectas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblIncorrectas.Location = New System.Drawing.Point(165, 39)
        Me.lblIncorrectas.Name = "lblIncorrectas"
        Me.lblIncorrectas.Size = New System.Drawing.Size(13, 16)
        Me.lblIncorrectas.TabIndex = 150
        Me.lblIncorrectas.Text = "-"
        '
        'lblCorrectas
        '
        Me.lblCorrectas.AutoSize = True
        Me.lblCorrectas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorrectas.ForeColor = System.Drawing.Color.Green
        Me.lblCorrectas.Location = New System.Drawing.Point(165, 22)
        Me.lblCorrectas.Name = "lblCorrectas"
        Me.lblCorrectas.Size = New System.Drawing.Size(13, 16)
        Me.lblCorrectas.TabIndex = 149
        Me.lblCorrectas.Text = "-"
        '
        'lblLeidas
        '
        Me.lblLeidas.AutoSize = True
        Me.lblLeidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeidas.Location = New System.Drawing.Point(165, 5)
        Me.lblLeidas.Name = "lblLeidas"
        Me.lblLeidas.Size = New System.Drawing.Size(13, 16)
        Me.lblLeidas.TabIndex = 148
        Me.lblLeidas.Text = "-"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(73, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 16)
        Me.Label6.TabIndex = 146
        Me.Label6.Text = "Incorrectas:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(73, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 145
        Me.Label5.Text = "Correctas:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(73, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 16)
        Me.Label4.TabIndex = 144
        Me.Label4.Text = "Leídas:"
        '
        'lblparesleidotitulo
        '
        Me.lblparesleidotitulo.AutoSize = True
        Me.lblparesleidotitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblparesleidotitulo.Location = New System.Drawing.Point(16, 5)
        Me.lblparesleidotitulo.Name = "lblparesleidotitulo"
        Me.lblparesleidotitulo.Size = New System.Drawing.Size(55, 16)
        Me.lblparesleidotitulo.TabIndex = 140
        Me.lblparesleidotitulo.Text = "Piezas"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblDescartadas)
        Me.pnlDatosBotones.Controls.Add(Me.lblRegistrosSelecionados)
        Me.pnlDatosBotones.Controls.Add(Me.lblEntrega)
        Me.pnlDatosBotones.Controls.Add(Me.lblTRegistros)
        Me.pnlDatosBotones.Controls.Add(Me.lblTEntrega)
        Me.pnlDatosBotones.Controls.Add(Me.lblTDescartadas)
        Me.pnlDatosBotones.Controls.Add(Me.lblPendientes)
        Me.pnlDatosBotones.Controls.Add(Me.lblTPendientes)
        Me.pnlDatosBotones.Controls.Add(Me.lblTotal)
        Me.pnlDatosBotones.Controls.Add(Me.lblTTotal)
        Me.pnlDatosBotones.Controls.Add(Me.lblFolioEnvio)
        Me.pnlDatosBotones.Controls.Add(Me.Label12)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(635, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(685, 60)
        Me.pnlDatosBotones.TabIndex = 3
        '
        'lblDescartadas
        '
        Me.lblDescartadas.AutoSize = True
        Me.lblDescartadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescartadas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblDescartadas.Location = New System.Drawing.Point(497, 39)
        Me.lblDescartadas.Name = "lblDescartadas"
        Me.lblDescartadas.Size = New System.Drawing.Size(13, 16)
        Me.lblDescartadas.TabIndex = 151
        Me.lblDescartadas.Text = "-"
        '
        'lblRegistrosSelecionados
        '
        Me.lblRegistrosSelecionados.AutoSize = True
        Me.lblRegistrosSelecionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistrosSelecionados.Location = New System.Drawing.Point(115, 38)
        Me.lblRegistrosSelecionados.Name = "lblRegistrosSelecionados"
        Me.lblRegistrosSelecionados.Size = New System.Drawing.Size(13, 16)
        Me.lblRegistrosSelecionados.TabIndex = 153
        Me.lblRegistrosSelecionados.Text = "-"
        '
        'lblEntrega
        '
        Me.lblEntrega.AutoSize = True
        Me.lblEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEntrega.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblEntrega.Location = New System.Drawing.Point(271, 35)
        Me.lblEntrega.Name = "lblEntrega"
        Me.lblEntrega.Size = New System.Drawing.Size(13, 16)
        Me.lblEntrega.TabIndex = 154
        Me.lblEntrega.Text = "-"
        '
        'lblTRegistros
        '
        Me.lblTRegistros.AutoSize = True
        Me.lblTRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTRegistros.Location = New System.Drawing.Point(78, 8)
        Me.lblTRegistros.Name = "lblTRegistros"
        Me.lblTRegistros.Size = New System.Drawing.Size(86, 30)
        Me.lblTRegistros.TabIndex = 152
        Me.lblTRegistros.Text = "    Registros " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "seleccionados"
        '
        'lblTEntrega
        '
        Me.lblTEntrega.AutoSize = True
        Me.lblTEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTEntrega.Location = New System.Drawing.Point(207, 35)
        Me.lblTEntrega.Name = "lblTEntrega"
        Me.lblTEntrega.Size = New System.Drawing.Size(70, 16)
        Me.lblTEntrega.TabIndex = 153
        Me.lblTEntrega.Text = "Entrega: "
        '
        'lblTDescartadas
        '
        Me.lblTDescartadas.AutoSize = True
        Me.lblTDescartadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTDescartadas.Location = New System.Drawing.Point(393, 39)
        Me.lblTDescartadas.Name = "lblTDescartadas"
        Me.lblTDescartadas.Size = New System.Drawing.Size(101, 16)
        Me.lblTDescartadas.TabIndex = 147
        Me.lblTDescartadas.Text = "Descartadas:"
        '
        'lblPendientes
        '
        Me.lblPendientes.AutoSize = True
        Me.lblPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendientes.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblPendientes.Location = New System.Drawing.Point(497, 22)
        Me.lblPendientes.Name = "lblPendientes"
        Me.lblPendientes.Size = New System.Drawing.Size(13, 16)
        Me.lblPendientes.TabIndex = 152
        Me.lblPendientes.Text = "-"
        '
        'lblTPendientes
        '
        Me.lblTPendientes.AutoSize = True
        Me.lblTPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTPendientes.Location = New System.Drawing.Point(393, 22)
        Me.lblTPendientes.Name = "lblTPendientes"
        Me.lblTPendientes.Size = New System.Drawing.Size(90, 16)
        Me.lblTPendientes.TabIndex = 151
        Me.lblTPendientes.Text = "Pendientes:"
        Me.lblTPendientes.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(497, 5)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(13, 16)
        Me.lblTotal.TabIndex = 150
        Me.lblTotal.Text = "-"
        '
        'lblTTotal
        '
        Me.lblTTotal.AutoSize = True
        Me.lblTTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTTotal.Location = New System.Drawing.Point(393, 5)
        Me.lblTTotal.Name = "lblTTotal"
        Me.lblTTotal.Size = New System.Drawing.Size(48, 16)
        Me.lblTTotal.TabIndex = 149
        Me.lblTTotal.Text = "Total:"
        Me.lblTTotal.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFolioEnvio
        '
        Me.lblFolioEnvio.AutoSize = True
        Me.lblFolioEnvio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioEnvio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblFolioEnvio.Location = New System.Drawing.Point(315, 10)
        Me.lblFolioEnvio.Name = "lblFolioEnvio"
        Me.lblFolioEnvio.Size = New System.Drawing.Size(13, 16)
        Me.lblFolioEnvio.TabIndex = 148
        Me.lblFolioEnvio.Text = "-"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(207, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 16)
        Me.Label12.TabIndex = 147
        Me.Label12.Text = "Folio de Envío:"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(578, 39)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(45, 13)
        Me.lblCancelar.TabIndex = 62
        Me.lblCancelar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(583, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 61
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(638, 8)
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
        Me.lblCerrar.Location = New System.Drawing.Point(637, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.cboxNaveCedis)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.chkSeleccionarTodo)
        Me.Panel1.Controls.Add(Me.txtcapturacodigos)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmbNave)
        Me.Panel1.Controls.Add(Me.cmbProceso)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 67)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1320, 51)
        Me.Panel1.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(324, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 131
        Me.Label7.Text = "*Cedis"
        '
        'cboxNaveCedis
        '
        Me.cboxNaveCedis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxNaveCedis.FormattingEnabled = True
        Me.cboxNaveCedis.Items.AddRange(New Object() {"COMERCIALIZADORA", "REEDITION"})
        Me.cboxNaveCedis.Location = New System.Drawing.Point(363, 6)
        Me.cboxNaveCedis.Name = "cboxNaveCedis"
        Me.cboxNaveCedis.Size = New System.Drawing.Size(159, 21)
        Me.cboxNaveCedis.TabIndex = 130
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(870, 35)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(121, 13)
        Me.Label23.TabIndex = 129
        Me.Label23.Text = "PIEZAS RECIBIDAS"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(161, 35)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(117, 13)
        Me.Label22.TabIndex = 128
        Me.Label22.Text = "PIEZAS ENVIADAS"
        '
        'chkSeleccionarTodo
        '
        Me.chkSeleccionarTodo.AutoSize = True
        Me.chkSeleccionarTodo.Location = New System.Drawing.Point(625, 34)
        Me.chkSeleccionarTodo.Name = "chkSeleccionarTodo"
        Me.chkSeleccionarTodo.Size = New System.Drawing.Size(106, 17)
        Me.chkSeleccionarTodo.TabIndex = 127
        Me.chkSeleccionarTodo.Text = "Seleccionar todo"
        Me.chkSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'txtcapturacodigos
        '
        Me.txtcapturacodigos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcapturacodigos.Location = New System.Drawing.Point(1046, 8)
        Me.txtcapturacodigos.MaxLength = 50
        Me.txtcapturacodigos.Name = "txtcapturacodigos"
        Me.txtcapturacodigos.Size = New System.Drawing.Size(145, 20)
        Me.txtcapturacodigos.TabIndex = 126
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(938, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 13)
        Me.Label3.TabIndex = 125
        Me.Label3.Text = "*Captura de códigos:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(534, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "*Nave"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "*Proceso"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(577, 7)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(250, 21)
        Me.cmbNave.TabIndex = 123
        '
        'cmbProceso
        '
        Me.cmbProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProceso.FormattingEnabled = True
        Me.cmbProceso.Location = New System.Drawing.Point(63, 6)
        Me.cmbProceso.Name = "cmbProceso"
        Me.cmbProceso.Size = New System.Drawing.Size(249, 21)
        Me.cmbProceso.TabIndex = 121
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1320, 67)
        Me.pnlEncabezado.TabIndex = 31
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(523, 67)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.lblCodigosConErrores)
        Me.Panel14.Controls.Add(Me.btnCodigosConErrores)
        Me.Panel14.Controls.Add(Me.lblDescartarLotes)
        Me.Panel14.Controls.Add(Me.btnDescartarLotes)
        Me.Panel14.Controls.Add(Me.lblReporte)
        Me.Panel14.Controls.Add(Me.btnImprimirReporte)
        Me.Panel14.Controls.Add(Me.btnDetener)
        Me.Panel14.Controls.Add(Me.btnIniciar)
        Me.Panel14.Controls.Add(Me.lblDetener)
        Me.Panel14.Controls.Add(Me.lblIniciar)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(522, 67)
        Me.Panel14.TabIndex = 3
        '
        'lblCodigosConErrores
        '
        Me.lblCodigosConErrores.AutoSize = True
        Me.lblCodigosConErrores.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCodigosConErrores.Location = New System.Drawing.Point(200, 45)
        Me.lblCodigosConErrores.Name = "lblCodigosConErrores"
        Me.lblCodigosConErrores.Size = New System.Drawing.Size(90, 13)
        Me.lblCodigosConErrores.TabIndex = 106
        Me.lblCodigosConErrores.Text = "Códigos con error"
        '
        'btnCodigosConErrores
        '
        Me.btnCodigosConErrores.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCodigosConErrores.BackgroundImage = CType(resources.GetObject("btnCodigosConErrores.BackgroundImage"), System.Drawing.Image)
        Me.btnCodigosConErrores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCodigosConErrores.Image = CType(resources.GetObject("btnCodigosConErrores.Image"), System.Drawing.Image)
        Me.btnCodigosConErrores.Location = New System.Drawing.Point(226, 9)
        Me.btnCodigosConErrores.Name = "btnCodigosConErrores"
        Me.btnCodigosConErrores.Size = New System.Drawing.Size(32, 32)
        Me.btnCodigosConErrores.TabIndex = 105
        Me.btnCodigosConErrores.UseVisualStyleBackColor = False
        '
        'lblDescartarLotes
        '
        Me.lblDescartarLotes.AutoSize = True
        Me.lblDescartarLotes.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDescartarLotes.Location = New System.Drawing.Point(111, 45)
        Me.lblDescartarLotes.Name = "lblDescartarLotes"
        Me.lblDescartarLotes.Size = New System.Drawing.Size(86, 13)
        Me.lblDescartarLotes.TabIndex = 104
        Me.lblDescartarLotes.Text = "Descartar piezas"
        '
        'btnDescartarLotes
        '
        Me.btnDescartarLotes.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnDescartarLotes.BackgroundImage = CType(resources.GetObject("btnDescartarLotes.BackgroundImage"), System.Drawing.Image)
        Me.btnDescartarLotes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDescartarLotes.Image = Global.Programacion.Vista.My.Resources.Resources.borrar_32
        Me.btnDescartarLotes.Location = New System.Drawing.Point(136, 9)
        Me.btnDescartarLotes.Name = "btnDescartarLotes"
        Me.btnDescartarLotes.Size = New System.Drawing.Size(32, 32)
        Me.btnDescartarLotes.TabIndex = 96
        Me.btnDescartarLotes.UseVisualStyleBackColor = False
        '
        'lblReporte
        '
        Me.lblReporte.AutoSize = True
        Me.lblReporte.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblReporte.Location = New System.Drawing.Point(300, 45)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(45, 13)
        Me.lblReporte.TabIndex = 103
        Me.lblReporte.Text = "Reporte"
        '
        'btnImprimirReporte
        '
        Me.btnImprimirReporte.Image = Global.Programacion.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimirReporte.Location = New System.Drawing.Point(306, 9)
        Me.btnImprimirReporte.Name = "btnImprimirReporte"
        Me.btnImprimirReporte.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimirReporte.TabIndex = 97
        Me.btnImprimirReporte.UseVisualStyleBackColor = True
        '
        'btnDetener
        '
        Me.btnDetener.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnDetener.Image = Global.Programacion.Vista.My.Resources.Resources.cancelar321
        Me.btnDetener.Location = New System.Drawing.Point(68, 9)
        Me.btnDetener.Name = "btnDetener"
        Me.btnDetener.Size = New System.Drawing.Size(32, 32)
        Me.btnDetener.TabIndex = 94
        Me.btnDetener.UseVisualStyleBackColor = False
        '
        'btnIniciar
        '
        Me.btnIniciar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnIniciar.Image = CType(resources.GetObject("btnIniciar.Image"), System.Drawing.Image)
        Me.btnIniciar.Location = New System.Drawing.Point(17, 9)
        Me.btnIniciar.Name = "btnIniciar"
        Me.btnIniciar.Size = New System.Drawing.Size(32, 32)
        Me.btnIniciar.TabIndex = 93
        Me.btnIniciar.UseVisualStyleBackColor = False
        '
        'lblDetener
        '
        Me.lblDetener.AutoSize = True
        Me.lblDetener.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDetener.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDetener.Location = New System.Drawing.Point(62, 45)
        Me.lblDetener.Name = "lblDetener"
        Me.lblDetener.Size = New System.Drawing.Size(45, 13)
        Me.lblDetener.TabIndex = 101
        Me.lblDetener.Text = "Detener"
        '
        'lblIniciar
        '
        Me.lblIniciar.AutoSize = True
        Me.lblIniciar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblIniciar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIniciar.Location = New System.Drawing.Point(16, 45)
        Me.lblIniciar.Name = "lblIniciar"
        Me.lblIniciar.Size = New System.Drawing.Size(35, 13)
        Me.lblIniciar.TabIndex = 100
        Me.lblIniciar.Text = "Iniciar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(652, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(668, 67)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(324, 24)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(260, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Envío y Recepción de Muestras"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(585, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 67)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'grdPiezasRecibidas
        '
        Me.grdPiezasRecibidas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdPiezasRecibidas.Location = New System.Drawing.Point(625, 4)
        Me.grdPiezasRecibidas.MainView = Me.grdVPiezasRecibidas
        Me.grdPiezasRecibidas.Name = "grdPiezasRecibidas"
        Me.grdPiezasRecibidas.Size = New System.Drawing.Size(692, 385)
        Me.grdPiezasRecibidas.TabIndex = 35
        Me.grdPiezasRecibidas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVPiezasRecibidas})
        '
        'grdVPiezasRecibidas
        '
        GridFormatRule2.ApplyToRow = True
        GridFormatRule2.Name = "Format0"
        GridFormatRule2.Rule = FormatConditionRuleExpression1
        Me.grdVPiezasRecibidas.FormatRules.Add(GridFormatRule2)
        Me.grdVPiezasRecibidas.GridControl = Me.grdPiezasRecibidas
        Me.grdVPiezasRecibidas.Name = "grdVPiezasRecibidas"
        Me.grdVPiezasRecibidas.OptionsView.ShowGroupPanel = False
        '
        'UltraPanel1
        '
        Me.UltraPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.grdPiezasEnviadas)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.grdPiezasRecibidas)
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 124)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(1320, 392)
        Me.UltraPanel1.TabIndex = 36
        '
        'PedidosMuestras_SalidasEntradas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1320, 582)
        Me.Controls.Add(Me.UltraPanel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "PedidosMuestras_SalidasEntradas"
        Me.Text = "Envío y Recepción de Muestras"
        CType(Me.grdPiezasEnviadas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVPiezasEnviadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPiezasRecibidas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVPiezasRecibidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grdPiezasEnviadas As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVPiezasEnviadas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbNave As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbProceso As ComboBox
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlAccionesCabecera As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents lblCancelar As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtcapturacodigos As TextBox
    Friend WithEvents grdPiezasRecibidas As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVPiezasRecibidas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblDescartarLotes As Label
    Friend WithEvents btnDescartarLotes As Button
    Friend WithEvents lblReporte As Label
    Friend WithEvents btnImprimirReporte As Button
    Friend WithEvents btnDetener As Button
    Friend WithEvents btnIniciar As Button
    Friend WithEvents lblDetener As Label
    Friend WithEvents lblIniciar As Label
    Friend WithEvents lblDescartadas As Label
    Friend WithEvents lblIncorrectas As Label
    Friend WithEvents lblCorrectas As Label
    Friend WithEvents lblLeidas As Label
    Friend WithEvents lblTDescartadas As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblparesleidotitulo As Label
    Friend WithEvents lblFolioEnvio As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblCodigosConErrores As Label
    Friend WithEvents btnCodigosConErrores As Button
    Friend WithEvents lblRegistrosSelecionados As Label
    Friend WithEvents lblTRegistros As Label
    Friend WithEvents chkSeleccionarTodo As CheckBox
    Friend WithEvents lblPendientes As Label
    Friend WithEvents lblTPendientes As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblTTotal As Label
    Friend WithEvents lblEntrega As Label
    Friend WithEvents lblTEntrega As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents Label7 As Label
    Friend WithEvents cboxNaveCedis As ComboBox
End Class
