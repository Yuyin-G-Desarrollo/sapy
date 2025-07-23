<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfirmBorradoresForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfirmBorradoresForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.btnActualizarLotes = New System.Windows.Forms.Button()
        Me.lblTextoActualizarLotes = New System.Windows.Forms.Label()
        Me.btnImprimirPDF = New System.Windows.Forms.Button()
        Me.lblTextoImprimirPDF = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnRechazar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblFechaloteo = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblFechaConfirmacion = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblParesText = New System.Windows.Forms.Label()
        Me.lblLotes = New System.Windows.Forms.Label()
        Me.lblLotesText = New System.Windows.Forms.Label()
        Me.lblPares = New System.Windows.Forms.Label()
        Me.lblClientesParesIncompletos = New System.Windows.Forms.Label()
        Me.lblLotesRechazados = New System.Windows.Forms.Label()
        Me.lblLotesCorrectos = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlLiquidado = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.cmbForroS = New System.Windows.Forms.ComboBox()
        Me.cmbPielS = New System.Windows.Forms.ComboBox()
        Me.cmbForro = New System.Windows.Forms.ComboBox()
        Me.cmbPiel = New System.Windows.Forms.ComboBox()
        Me.chkval = New System.Windows.Forms.CheckBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFiltrarSolicitud = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblA = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grdBorrador = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ultExportGrid = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInferior.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        CType(Me.grdBorrador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.btnActualizarLotes)
        Me.pnlEncabezado.Controls.Add(Me.lblTextoActualizarLotes)
        Me.pnlEncabezado.Controls.Add(Me.btnImprimirPDF)
        Me.pnlEncabezado.Controls.Add(Me.lblTextoImprimirPDF)
        Me.pnlEncabezado.Controls.Add(Me.Label7)
        Me.pnlEncabezado.Controls.Add(Me.btnRechazar)
        Me.pnlEncabezado.Controls.Add(Me.Label4)
        Me.pnlEncabezado.Controls.Add(Me.Button1)
        Me.pnlEncabezado.Controls.Add(Me.Label3)
        Me.pnlEncabezado.Controls.Add(Me.Button2)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1178, 63)
        Me.pnlEncabezado.TabIndex = 159
        '
        'btnActualizarLotes
        '
        Me.btnActualizarLotes.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnActualizarLotes.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnActualizarLotes.Image = Global.Produccion.Vista.My.Resources.Resources.refresh_32
        Me.btnActualizarLotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnActualizarLotes.Location = New System.Drawing.Point(245, 3)
        Me.btnActualizarLotes.Name = "btnActualizarLotes"
        Me.btnActualizarLotes.Size = New System.Drawing.Size(32, 32)
        Me.btnActualizarLotes.TabIndex = 112
        Me.btnActualizarLotes.UseVisualStyleBackColor = True
        '
        'lblTextoActualizarLotes
        '
        Me.lblTextoActualizarLotes.AutoSize = True
        Me.lblTextoActualizarLotes.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoActualizarLotes.Location = New System.Drawing.Point(224, 34)
        Me.lblTextoActualizarLotes.Name = "lblTextoActualizarLotes"
        Me.lblTextoActualizarLotes.Size = New System.Drawing.Size(75, 26)
        Me.lblTextoActualizarLotes.TabIndex = 111
        Me.lblTextoActualizarLotes.Text = "Replicar Lotes" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  SICY a SAY"
        '
        'btnImprimirPDF
        '
        Me.btnImprimirPDF.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnImprimirPDF.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImprimirPDF.Image = CType(resources.GetObject("btnImprimirPDF.Image"), System.Drawing.Image)
        Me.btnImprimirPDF.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImprimirPDF.Location = New System.Drawing.Point(179, 3)
        Me.btnImprimirPDF.Name = "btnImprimirPDF"
        Me.btnImprimirPDF.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimirPDF.TabIndex = 108
        Me.btnImprimirPDF.UseVisualStyleBackColor = True
        '
        'lblTextoImprimirPDF
        '
        Me.lblTextoImprimirPDF.AutoSize = True
        Me.lblTextoImprimirPDF.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoImprimirPDF.Location = New System.Drawing.Point(176, 34)
        Me.lblTextoImprimirPDF.Name = "lblTextoImprimirPDF"
        Me.lblTextoImprimirPDF.Size = New System.Drawing.Size(45, 26)
        Me.lblTextoImprimirPDF.TabIndex = 107
        Me.lblTextoImprimirPDF.Text = "Imprimir " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  PDF"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.Location = New System.Drawing.Point(65, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 26)
        Me.Label7.TabIndex = 106
        Me.Label7.Text = "Rechazar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Borrador"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRechazar
        '
        Me.btnRechazar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.cancelar_32
        Me.btnRechazar.Location = New System.Drawing.Point(78, 2)
        Me.btnRechazar.Name = "btnRechazar"
        Me.btnRechazar.Size = New System.Drawing.Size(32, 32)
        Me.btnRechazar.TabIndex = 105
        Me.btnRechazar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(124, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "Exportar" & Global.Microsoft.VisualBasic.ChrW(13)
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.Button1.Location = New System.Drawing.Point(127, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 103
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(8, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 26)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Confirmar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Borrador"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.enviarcalculo_32
        Me.Button2.Location = New System.Drawing.Point(15, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 101
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(871, 26)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(233, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Confirmación de Borradores"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(1110, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblFechaloteo)
        Me.pnlInferior.Controls.Add(Me.Label13)
        Me.pnlInferior.Controls.Add(Me.lblFechaConfirmacion)
        Me.pnlInferior.Controls.Add(Me.Label11)
        Me.pnlInferior.Controls.Add(Me.Label10)
        Me.pnlInferior.Controls.Add(Me.Panel3)
        Me.pnlInferior.Controls.Add(Me.lblParesText)
        Me.pnlInferior.Controls.Add(Me.lblLotes)
        Me.pnlInferior.Controls.Add(Me.lblLotesText)
        Me.pnlInferior.Controls.Add(Me.lblPares)
        Me.pnlInferior.Controls.Add(Me.lblClientesParesIncompletos)
        Me.pnlInferior.Controls.Add(Me.lblLotesRechazados)
        Me.pnlInferior.Controls.Add(Me.lblLotesCorrectos)
        Me.pnlInferior.Controls.Add(Me.Panel2)
        Me.pnlInferior.Controls.Add(Me.Panel1)
        Me.pnlInferior.Controls.Add(Me.pnlLiquidado)
        Me.pnlInferior.Controls.Add(Me.lblGuardar)
        Me.pnlInferior.Controls.Add(Me.btnGuardar)
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 460)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(1178, 54)
        Me.pnlInferior.TabIndex = 160
        '
        'lblFechaloteo
        '
        Me.lblFechaloteo.AutoSize = True
        Me.lblFechaloteo.Location = New System.Drawing.Point(758, 8)
        Me.lblFechaloteo.Name = "lblFechaloteo"
        Me.lblFechaloteo.Size = New System.Drawing.Size(10, 13)
        Me.lblFechaloteo.TabIndex = 205
        Me.lblFechaloteo.Text = "-"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(634, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(118, 13)
        Me.Label13.TabIndex = 206
        Me.Label13.Text = "Fecha de confirmacion:"
        '
        'lblFechaConfirmacion
        '
        Me.lblFechaConfirmacion.AutoSize = True
        Me.lblFechaConfirmacion.Location = New System.Drawing.Point(758, 30)
        Me.lblFechaConfirmacion.Name = "lblFechaConfirmacion"
        Me.lblFechaConfirmacion.Size = New System.Drawing.Size(10, 13)
        Me.lblFechaConfirmacion.TabIndex = 203
        Me.lblFechaConfirmacion.Text = "-"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(671, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 204
        Me.Label11.Text = "Fecha de loteo:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(485, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 202
        Me.Label10.Text = "Sin cortador"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkGray
        Me.Panel3.Location = New System.Drawing.Point(470, 28)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(15, 15)
        Me.Panel3.TabIndex = 201
        '
        'lblParesText
        '
        Me.lblParesText.AutoSize = True
        Me.lblParesText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesText.Location = New System.Drawing.Point(194, 6)
        Me.lblParesText.Name = "lblParesText"
        Me.lblParesText.Size = New System.Drawing.Size(16, 16)
        Me.lblParesText.TabIndex = 200
        Me.lblParesText.Text = "0"
        Me.lblParesText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLotes
        '
        Me.lblLotes.AutoSize = True
        Me.lblLotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotes.Location = New System.Drawing.Point(10, 6)
        Me.lblLotes.Name = "lblLotes"
        Me.lblLotes.Size = New System.Drawing.Size(50, 16)
        Me.lblLotes.TabIndex = 197
        Me.lblLotes.Text = "Lotes:"
        '
        'lblLotesText
        '
        Me.lblLotesText.AutoSize = True
        Me.lblLotesText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotesText.Location = New System.Drawing.Point(57, 6)
        Me.lblLotesText.Name = "lblLotesText"
        Me.lblLotesText.Size = New System.Drawing.Size(16, 16)
        Me.lblLotesText.TabIndex = 199
        Me.lblLotesText.Text = "0"
        '
        'lblPares
        '
        Me.lblPares.AutoSize = True
        Me.lblPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPares.Location = New System.Drawing.Point(144, 6)
        Me.lblPares.Name = "lblPares"
        Me.lblPares.Size = New System.Drawing.Size(53, 16)
        Me.lblPares.TabIndex = 198
        Me.lblPares.Text = "Pares:"
        Me.lblPares.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblClientesParesIncompletos
        '
        Me.lblClientesParesIncompletos.AutoSize = True
        Me.lblClientesParesIncompletos.Location = New System.Drawing.Point(250, 30)
        Me.lblClientesParesIncompletos.Name = "lblClientesParesIncompletos"
        Me.lblClientesParesIncompletos.Size = New System.Drawing.Size(210, 13)
        Me.lblClientesParesIncompletos.TabIndex = 170
        Me.lblClientesParesIncompletos.Text = "Clientes a los que no se les completa pares"
        '
        'lblLotesRechazados
        '
        Me.lblLotesRechazados.AutoSize = True
        Me.lblLotesRechazados.Location = New System.Drawing.Point(133, 30)
        Me.lblLotesRechazados.Name = "lblLotesRechazados"
        Me.lblLotesRechazados.Size = New System.Drawing.Size(96, 13)
        Me.lblLotesRechazados.TabIndex = 169
        Me.lblLotesRechazados.Text = "Lotes Rechazados"
        '
        'lblLotesCorrectos
        '
        Me.lblLotesCorrectos.AutoSize = True
        Me.lblLotesCorrectos.Location = New System.Drawing.Point(29, 30)
        Me.lblLotesCorrectos.Name = "lblLotesCorrectos"
        Me.lblLotesCorrectos.Size = New System.Drawing.Size(81, 13)
        Me.lblLotesCorrectos.TabIndex = 92
        Me.lblLotesCorrectos.Text = "Lotes Correctos"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Salmon
        Me.Panel2.Location = New System.Drawing.Point(235, 28)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(15, 15)
        Me.Panel2.TabIndex = 168
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkOrange
        Me.Panel1.Location = New System.Drawing.Point(116, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(15, 15)
        Me.Panel1.TabIndex = 167
        '
        'pnlLiquidado
        '
        Me.pnlLiquidado.BackColor = System.Drawing.Color.YellowGreen
        Me.pnlLiquidado.Location = New System.Drawing.Point(12, 28)
        Me.pnlLiquidado.Name = "pnlLiquidado"
        Me.pnlLiquidado.Size = New System.Drawing.Size(15, 15)
        Me.pnlLiquidado.TabIndex = 166
        '
        'lblGuardar
        '
        Me.lblGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(1087, 39)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 100
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(1092, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 99
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(1133, 39)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 98
        Me.lblSalir.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(1134, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 15
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Controls.Add(Me.cmbForroS)
        Me.grbParametros.Controls.Add(Me.cmbPielS)
        Me.grbParametros.Controls.Add(Me.cmbForro)
        Me.grbParametros.Controls.Add(Me.cmbPiel)
        Me.grbParametros.Controls.Add(Me.chkval)
        Me.grbParametros.Controls.Add(Me.btnLimpiar)
        Me.grbParametros.Controls.Add(Me.Label2)
        Me.grbParametros.Controls.Add(Me.btnFiltrarSolicitud)
        Me.grbParametros.Controls.Add(Me.lblBuscar)
        Me.grbParametros.Controls.Add(Me.lblEstatus)
        Me.grbParametros.Controls.Add(Me.Label1)
        Me.grbParametros.Controls.Add(Me.dtpFechaInicio)
        Me.grbParametros.Controls.Add(Me.lblA)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Controls.Add(Me.lblNave)
        Me.grbParametros.Controls.Add(Me.Label5)
        Me.grbParametros.Controls.Add(Me.Label8)
        Me.grbParametros.Controls.Add(Me.Label6)
        Me.grbParametros.Controls.Add(Me.Label9)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 63)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1178, 79)
        Me.grbParametros.TabIndex = 161
        Me.grbParametros.TabStop = False
        '
        'cmbForroS
        '
        Me.cmbForroS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbForroS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbForroS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbForroS.FormattingEnabled = True
        Me.cmbForroS.Location = New System.Drawing.Point(925, 49)
        Me.cmbForroS.Name = "cmbForroS"
        Me.cmbForroS.Size = New System.Drawing.Size(134, 21)
        Me.cmbForroS.TabIndex = 132
        '
        'cmbPielS
        '
        Me.cmbPielS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPielS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPielS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPielS.FormattingEnabled = True
        Me.cmbPielS.Location = New System.Drawing.Point(438, 49)
        Me.cmbPielS.Name = "cmbPielS"
        Me.cmbPielS.Size = New System.Drawing.Size(134, 21)
        Me.cmbPielS.TabIndex = 130
        '
        'cmbForro
        '
        Me.cmbForro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbForro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbForro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbForro.FormattingEnabled = True
        Me.cmbForro.Location = New System.Drawing.Point(671, 49)
        Me.cmbForro.Name = "cmbForro"
        Me.cmbForro.Size = New System.Drawing.Size(134, 21)
        Me.cmbForro.TabIndex = 128
        '
        'cmbPiel
        '
        Me.cmbPiel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPiel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPiel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPiel.FormattingEnabled = True
        Me.cmbPiel.Location = New System.Drawing.Point(196, 49)
        Me.cmbPiel.Name = "cmbPiel"
        Me.cmbPiel.Size = New System.Drawing.Size(134, 21)
        Me.cmbPiel.TabIndex = 126
        '
        'chkval
        '
        Me.chkval.AutoSize = True
        Me.chkval.Location = New System.Drawing.Point(5, 51)
        Me.chkval.Name = "chkval"
        Me.chkval.Size = New System.Drawing.Size(106, 17)
        Me.chkval.TabIndex = 125
        Me.chkval.Text = "Seleccionar todo"
        Me.chkval.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Image = Global.Produccion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(1140, 9)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 92
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(1135, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Limpiar"
        '
        'btnFiltrarSolicitud
        '
        Me.btnFiltrarSolicitud.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFiltrarSolicitud.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_32
        Me.btnFiltrarSolicitud.Location = New System.Drawing.Point(1092, 9)
        Me.btnFiltrarSolicitud.Name = "btnFiltrarSolicitud"
        Me.btnFiltrarSolicitud.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrarSolicitud.TabIndex = 90
        Me.btnFiltrarSolicitud.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(1087, 41)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 91
        Me.lblBuscar.Text = "Mostrar"
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatus.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblEstatus.Location = New System.Drawing.Point(756, 19)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(13, 16)
        Me.lblEstatus.TabIndex = 89
        Me.lblEstatus.Text = "-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(705, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 88
        Me.Label1.Text = "Estatus:"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Location = New System.Drawing.Point(451, 19)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(215, 20)
        Me.dtpFechaInicio.TabIndex = 87
        '
        'lblA
        '
        Me.lblA.AutoSize = True
        Me.lblA.Location = New System.Drawing.Point(422, 22)
        Me.lblA.Name = "lblA"
        Me.lblA.Size = New System.Drawing.Size(23, 13)
        Me.lblA.TabIndex = 86
        Me.lblA.Text = "Del"
        '
        'cmbNave
        '
        Me.cmbNave.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbNave.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(51, 19)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(348, 21)
        Me.cmbNave.TabIndex = 4
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(12, 22)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(37, 13)
        Me.lblNave.TabIndex = 69
        Me.lblNave.Text = "*Nave"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(130, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 127
        Me.Label5.Text = "Cortador Piel"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(350, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 13)
        Me.Label8.TabIndex = 131
        Me.Label8.Text = "Cortador Piel Sint."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(600, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 129
        Me.Label6.Text = "Cortador Forro"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(830, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 133
        Me.Label9.Text = "Cortador Forro Sint."
        '
        'grdBorrador
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdBorrador.DisplayLayout.Appearance = Appearance1
        Me.grdBorrador.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdBorrador.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdBorrador.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdBorrador.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdBorrador.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdBorrador.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdBorrador.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdBorrador.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdBorrador.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdBorrador.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdBorrador.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdBorrador.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdBorrador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBorrador.Location = New System.Drawing.Point(0, 142)
        Me.grdBorrador.Name = "grdBorrador"
        Me.grdBorrador.Size = New System.Drawing.Size(1178, 318)
        Me.grdBorrador.TabIndex = 162
        '
        'ConfirmBorradoresForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1178, 514)
        Me.Controls.Add(Me.grdBorrador)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "ConfirmBorradoresForm"
        Me.Text = "Confirmación de Borradores"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        CType(Me.grdBorrador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblA As System.Windows.Forms.Label
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdBorrador As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnFiltrarSolicitud As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents lblClientesParesIncompletos As System.Windows.Forms.Label
    Friend WithEvents lblLotesRechazados As System.Windows.Forms.Label
    Friend WithEvents lblLotesCorrectos As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlLiquidado As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ultExportGrid As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbForro As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbPiel As System.Windows.Forms.ComboBox
    Friend WithEvents chkval As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnRechazar As System.Windows.Forms.Button
    Friend WithEvents lblParesText As System.Windows.Forms.Label
    Friend WithEvents lblLotes As System.Windows.Forms.Label
    Friend WithEvents lblLotesText As System.Windows.Forms.Label
    Friend WithEvents lblPares As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbForroS As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbPielS As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnImprimirPDF As Button
    Friend WithEvents lblTextoImprimirPDF As Label
    Friend WithEvents btnActualizarLotes As Button
    Friend WithEvents lblTextoActualizarLotes As Label
    Friend WithEvents lblFechaloteo As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblFechaConfirmacion As Label
    Friend WithEvents Label11 As Label
End Class
