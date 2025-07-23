<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReportesProduccionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportesProduccionForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblDcmResultado = New System.Windows.Forms.Label()
        Me.lblDcm = New System.Windows.Forms.Label()
        Me.lblLotesResultado = New System.Windows.Forms.Label()
        Me.lblLotes = New System.Windows.Forms.Label()
        Me.lblParesResultado = New System.Windows.Forms.Label()
        Me.lblUltimaFechaReplica = New System.Windows.Forms.Label()
        Me.lblLotesSAY = New System.Windows.Forms.Label()
        Me.lblUltimaFechaLoteo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblLotesSICY = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPares = New System.Windows.Forms.Label()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblReporteGeneralSuelas = New System.Windows.Forms.Label()
        Me.btnReporteGeneralSuelas = New System.Windows.Forms.Button()
        Me.btnActualizarLotes = New System.Windows.Forms.Button()
        Me.lblTextoActualizarLotes = New System.Windows.Forms.Label()
        Me.btnArticulosPorAutorizar = New System.Windows.Forms.Button()
        Me.lblTextoArticulosNoAutorizados = New System.Windows.Forms.Label()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.pnlReportesGenerales = New System.Windows.Forms.Panel()
        Me.grdReportes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.cbxReporte = New System.Windows.Forms.ComboBox()
        Me.lblFechaDel = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cbxNave = New System.Windows.Forms.ComboBox()
        Me.dtpPrograma = New System.Windows.Forms.DateTimePicker()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.grdMateriales = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlReportesPieles = New System.Windows.Forms.Panel()
        Me.grdProgramaCorte = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlInferior.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlReportesGenerales.SuspendLayout()
        CType(Me.grdReportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.grdMateriales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlReportesPieles.SuspendLayout()
        CType(Me.grdProgramaCorte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblDcmResultado)
        Me.pnlInferior.Controls.Add(Me.lblDcm)
        Me.pnlInferior.Controls.Add(Me.lblLotesResultado)
        Me.pnlInferior.Controls.Add(Me.lblLotes)
        Me.pnlInferior.Controls.Add(Me.lblParesResultado)
        Me.pnlInferior.Controls.Add(Me.lblUltimaFechaReplica)
        Me.pnlInferior.Controls.Add(Me.lblLotesSAY)
        Me.pnlInferior.Controls.Add(Me.lblUltimaFechaLoteo)
        Me.pnlInferior.Controls.Add(Me.Label4)
        Me.pnlInferior.Controls.Add(Me.lblLotesSICY)
        Me.pnlInferior.Controls.Add(Me.Label3)
        Me.pnlInferior.Controls.Add(Me.Label2)
        Me.pnlInferior.Controls.Add(Me.Label1)
        Me.pnlInferior.Controls.Add(Me.lblPares)
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 527)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(1094, 54)
        Me.pnlInferior.TabIndex = 2022
        '
        'lblDcmResultado
        '
        Me.lblDcmResultado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDcmResultado.AutoSize = True
        Me.lblDcmResultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDcmResultado.Location = New System.Drawing.Point(316, 19)
        Me.lblDcmResultado.Name = "lblDcmResultado"
        Me.lblDcmResultado.Size = New System.Drawing.Size(17, 18)
        Me.lblDcmResultado.TabIndex = 117
        Me.lblDcmResultado.Text = "0"
        Me.lblDcmResultado.Visible = False
        '
        'lblDcm
        '
        Me.lblDcm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDcm.AutoSize = True
        Me.lblDcm.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDcm.Location = New System.Drawing.Point(268, 19)
        Me.lblDcm.Name = "lblDcm"
        Me.lblDcm.Size = New System.Drawing.Size(51, 18)
        Me.lblDcm.TabIndex = 116
        Me.lblDcm.Text = "DCM:"
        Me.lblDcm.Visible = False
        '
        'lblLotesResultado
        '
        Me.lblLotesResultado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLotesResultado.AutoSize = True
        Me.lblLotesResultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotesResultado.Location = New System.Drawing.Point(212, 19)
        Me.lblLotesResultado.Name = "lblLotesResultado"
        Me.lblLotesResultado.Size = New System.Drawing.Size(17, 18)
        Me.lblLotesResultado.TabIndex = 115
        Me.lblLotesResultado.Text = "0"
        '
        'lblLotes
        '
        Me.lblLotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLotes.AutoSize = True
        Me.lblLotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotes.Location = New System.Drawing.Point(160, 19)
        Me.lblLotes.Name = "lblLotes"
        Me.lblLotes.Size = New System.Drawing.Size(55, 18)
        Me.lblLotes.TabIndex = 114
        Me.lblLotes.Text = "Lotes:"
        '
        'lblParesResultado
        '
        Me.lblParesResultado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblParesResultado.AutoSize = True
        Me.lblParesResultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesResultado.Location = New System.Drawing.Point(99, 19)
        Me.lblParesResultado.Name = "lblParesResultado"
        Me.lblParesResultado.Size = New System.Drawing.Size(17, 18)
        Me.lblParesResultado.TabIndex = 113
        Me.lblParesResultado.Text = "0"
        '
        'lblUltimaFechaReplica
        '
        Me.lblUltimaFechaReplica.AutoSize = True
        Me.lblUltimaFechaReplica.Location = New System.Drawing.Point(779, 32)
        Me.lblUltimaFechaReplica.Name = "lblUltimaFechaReplica"
        Me.lblUltimaFechaReplica.Size = New System.Drawing.Size(10, 13)
        Me.lblUltimaFechaReplica.TabIndex = 108
        Me.lblUltimaFechaReplica.Text = "-"
        '
        'lblLotesSAY
        '
        Me.lblLotesSAY.AutoSize = True
        Me.lblLotesSAY.Location = New System.Drawing.Point(593, 32)
        Me.lblLotesSAY.Name = "lblLotesSAY"
        Me.lblLotesSAY.Size = New System.Drawing.Size(10, 13)
        Me.lblLotesSAY.TabIndex = 108
        Me.lblLotesSAY.Text = "-"
        '
        'lblUltimaFechaLoteo
        '
        Me.lblUltimaFechaLoteo.AutoSize = True
        Me.lblUltimaFechaLoteo.Location = New System.Drawing.Point(779, 10)
        Me.lblUltimaFechaLoteo.Name = "lblUltimaFechaLoteo"
        Me.lblUltimaFechaLoteo.Size = New System.Drawing.Size(10, 13)
        Me.lblUltimaFechaLoteo.TabIndex = 108
        Me.lblUltimaFechaLoteo.Text = "-"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(655, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 13)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "Última fecha de replica:"
        '
        'lblLotesSICY
        '
        Me.lblLotesSICY.AutoSize = True
        Me.lblLotesSICY.Location = New System.Drawing.Point(593, 10)
        Me.lblLotesSICY.Name = "lblLotesSICY"
        Me.lblLotesSICY.Size = New System.Drawing.Size(10, 13)
        Me.lblLotesSICY.TabIndex = 108
        Me.lblLotesSICY.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(655, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "Última fecha de loteo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(525, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "Lotes SAY:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(525, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "Lotes SICY:"
        '
        'lblPares
        '
        Me.lblPares.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPares.AutoSize = True
        Me.lblPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPares.Location = New System.Drawing.Point(45, 19)
        Me.lblPares.Name = "lblPares"
        Me.lblPares.Size = New System.Drawing.Size(57, 18)
        Me.lblPares.TabIndex = 112
        Me.lblPares.Text = "Pares:"
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(1041, 37)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 100
        Me.lblSalir.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(1042, 0)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblReporteGeneralSuelas)
        Me.pnlEncabezado.Controls.Add(Me.btnReporteGeneralSuelas)
        Me.pnlEncabezado.Controls.Add(Me.btnActualizarLotes)
        Me.pnlEncabezado.Controls.Add(Me.lblTextoActualizarLotes)
        Me.pnlEncabezado.Controls.Add(Me.btnArticulosPorAutorizar)
        Me.pnlEncabezado.Controls.Add(Me.lblTextoArticulosNoAutorizados)
        Me.pnlEncabezado.Controls.Add(Me.lblImprimir)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Controls.Add(Me.btnImprimir)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1094, 63)
        Me.pnlEncabezado.TabIndex = 2021
        '
        'lblReporteGeneralSuelas
        '
        Me.lblReporteGeneralSuelas.AutoSize = True
        Me.lblReporteGeneralSuelas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblReporteGeneralSuelas.Location = New System.Drawing.Point(193, 34)
        Me.lblReporteGeneralSuelas.Name = "lblReporteGeneralSuelas"
        Me.lblReporteGeneralSuelas.Size = New System.Drawing.Size(54, 26)
        Me.lblReporteGeneralSuelas.TabIndex = 112
        Me.lblReporteGeneralSuelas.Text = "Rep. Gral" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de Suelas"
        '
        'btnReporteGeneralSuelas
        '
        Me.btnReporteGeneralSuelas.Image = Global.Produccion.Vista.My.Resources.Resources.imprimir_32
        Me.btnReporteGeneralSuelas.Location = New System.Drawing.Point(201, 3)
        Me.btnReporteGeneralSuelas.Name = "btnReporteGeneralSuelas"
        Me.btnReporteGeneralSuelas.Size = New System.Drawing.Size(32, 32)
        Me.btnReporteGeneralSuelas.TabIndex = 111
        Me.btnReporteGeneralSuelas.UseVisualStyleBackColor = True
        '
        'btnActualizarLotes
        '
        Me.btnActualizarLotes.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnActualizarLotes.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnActualizarLotes.Image = Global.Produccion.Vista.My.Resources.Resources.refresh_32
        Me.btnActualizarLotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnActualizarLotes.Location = New System.Drawing.Point(70, 3)
        Me.btnActualizarLotes.Name = "btnActualizarLotes"
        Me.btnActualizarLotes.Size = New System.Drawing.Size(32, 32)
        Me.btnActualizarLotes.TabIndex = 110
        Me.btnActualizarLotes.UseVisualStyleBackColor = True
        '
        'lblTextoActualizarLotes
        '
        Me.lblTextoActualizarLotes.AutoSize = True
        Me.lblTextoActualizarLotes.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoActualizarLotes.Location = New System.Drawing.Point(60, 34)
        Me.lblTextoActualizarLotes.Name = "lblTextoActualizarLotes"
        Me.lblTextoActualizarLotes.Size = New System.Drawing.Size(53, 26)
        Me.lblTextoActualizarLotes.TabIndex = 109
        Me.lblTextoActualizarLotes.Text = "Actualizar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    Lotes"
        '
        'btnArticulosPorAutorizar
        '
        Me.btnArticulosPorAutorizar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnArticulosPorAutorizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnArticulosPorAutorizar.Image = Global.Produccion.Vista.My.Resources.Resources.rechazar_32
        Me.btnArticulosPorAutorizar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnArticulosPorAutorizar.Location = New System.Drawing.Point(135, 3)
        Me.btnArticulosPorAutorizar.Name = "btnArticulosPorAutorizar"
        Me.btnArticulosPorAutorizar.Size = New System.Drawing.Size(32, 32)
        Me.btnArticulosPorAutorizar.TabIndex = 110
        Me.btnArticulosPorAutorizar.UseVisualStyleBackColor = True
        Me.btnArticulosPorAutorizar.Visible = False
        '
        'lblTextoArticulosNoAutorizados
        '
        Me.lblTextoArticulosNoAutorizados.AutoSize = True
        Me.lblTextoArticulosNoAutorizados.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoArticulosNoAutorizados.Location = New System.Drawing.Point(120, 34)
        Me.lblTextoArticulosNoAutorizados.Name = "lblTextoArticulosNoAutorizados"
        Me.lblTextoArticulosNoAutorizados.Size = New System.Drawing.Size(62, 26)
        Me.lblTextoArticulosNoAutorizados.TabIndex = 109
        Me.lblTextoArticulosNoAutorizados.Text = "Verificar no" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Autorizados"
        Me.lblTextoArticulosNoAutorizados.Visible = False
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(14, 38)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 104
        Me.lblImprimir.Text = "Imprimir"
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(816, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(207, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = " Reportes de Producción"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(1026, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Produccion.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(17, 3)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 101
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'pnlReportesGenerales
        '
        Me.pnlReportesGenerales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlReportesGenerales.Controls.Add(Me.grdReportes)
        Me.pnlReportesGenerales.Location = New System.Drawing.Point(0, 125)
        Me.pnlReportesGenerales.Name = "pnlReportesGenerales"
        Me.pnlReportesGenerales.Size = New System.Drawing.Size(1086, 396)
        Me.pnlReportesGenerales.TabIndex = 2023
        '
        'grdReportes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdReportes.DisplayLayout.Appearance = Appearance1
        Me.grdReportes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdReportes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdReportes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdReportes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdReportes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdReportes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdReportes.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdReportes.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdReportes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdReportes.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdReportes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdReportes.Location = New System.Drawing.Point(0, 0)
        Me.grdReportes.Name = "grdReportes"
        Me.grdReportes.Size = New System.Drawing.Size(1086, 396)
        Me.grdReportes.TabIndex = 2021
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.lblLimpiar)
        Me.Panel2.Controls.Add(Me.btnMostrar)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.lblReporte)
        Me.Panel2.Controls.Add(Me.cbxReporte)
        Me.Panel2.Controls.Add(Me.lblFechaDel)
        Me.Panel2.Controls.Add(Me.lblNave)
        Me.Panel2.Controls.Add(Me.cbxNave)
        Me.Panel2.Controls.Add(Me.dtpPrograma)
        Me.Panel2.Controls.Add(Me.lblMostrar)
        Me.Panel2.Location = New System.Drawing.Point(0, 69)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1089, 56)
        Me.Panel2.TabIndex = 2024
        '
        'lblLimpiar
        '
        Me.lblLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(1030, 40)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 113
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(985, 3)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 103
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Image = Global.Produccion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(1034, 3)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 112
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblReporte
        '
        Me.lblReporte.AutoSize = True
        Me.lblReporte.Location = New System.Drawing.Point(229, 25)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(49, 13)
        Me.lblReporte.TabIndex = 111
        Me.lblReporte.Text = "*Reporte"
        '
        'cbxReporte
        '
        Me.cbxReporte.FormattingEnabled = True
        Me.cbxReporte.Location = New System.Drawing.Point(280, 21)
        Me.cbxReporte.Name = "cbxReporte"
        Me.cbxReporte.Size = New System.Drawing.Size(286, 21)
        Me.cbxReporte.TabIndex = 110
        '
        'lblFechaDel
        '
        Me.lblFechaDel.AutoSize = True
        Me.lblFechaDel.Location = New System.Drawing.Point(593, 26)
        Me.lblFechaDel.Name = "lblFechaDel"
        Me.lblFechaDel.Size = New System.Drawing.Size(106, 13)
        Me.lblFechaDel.TabIndex = 108
        Me.lblFechaDel.Text = "*Fecha del Programa"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(14, 25)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(37, 13)
        Me.lblNave.TabIndex = 107
        Me.lblNave.Text = "*Nave"
        '
        'cbxNave
        '
        Me.cbxNave.FormattingEnabled = True
        Me.cbxNave.Location = New System.Drawing.Point(53, 21)
        Me.cbxNave.Name = "cbxNave"
        Me.cbxNave.Size = New System.Drawing.Size(148, 21)
        Me.cbxNave.TabIndex = 106
        '
        'dtpPrograma
        '
        Me.dtpPrograma.Location = New System.Drawing.Point(701, 21)
        Me.dtpPrograma.Name = "dtpPrograma"
        Me.dtpPrograma.Size = New System.Drawing.Size(200, 20)
        Me.dtpPrograma.TabIndex = 104
        '
        'lblMostrar
        '
        Me.lblMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(982, 40)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 102
        Me.lblMostrar.Text = "Mostrar"
        '
        'grdMateriales
        '
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMateriales.DisplayLayout.Appearance = Appearance4
        Me.grdMateriales.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdMateriales.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdMateriales.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdMateriales.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdMateriales.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdMateriales.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMateriales.DisplayLayout.Override.RowAlternateAppearance = Appearance5
        Appearance6.BorderColor = System.Drawing.Color.DarkGray
        Me.grdMateriales.DisplayLayout.Override.RowAppearance = Appearance6
        Me.grdMateriales.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdMateriales.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdMateriales.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdMateriales.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdMateriales.Location = New System.Drawing.Point(0, 230)
        Me.grdMateriales.Name = "grdMateriales"
        Me.grdMateriales.Size = New System.Drawing.Size(1086, 160)
        Me.grdMateriales.TabIndex = 2021
        '
        'pnlReportesPieles
        '
        Me.pnlReportesPieles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlReportesPieles.Controls.Add(Me.grdMateriales)
        Me.pnlReportesPieles.Controls.Add(Me.grdProgramaCorte)
        Me.pnlReportesPieles.Location = New System.Drawing.Point(0, 131)
        Me.pnlReportesPieles.Name = "pnlReportesPieles"
        Me.pnlReportesPieles.Size = New System.Drawing.Size(1086, 390)
        Me.pnlReportesPieles.TabIndex = 2024
        Me.pnlReportesPieles.Visible = False
        '
        'grdProgramaCorte
        '
        Me.grdProgramaCorte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProgramaCorte.DisplayLayout.Appearance = Appearance7
        Me.grdProgramaCorte.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProgramaCorte.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdProgramaCorte.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdProgramaCorte.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdProgramaCorte.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdProgramaCorte.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProgramaCorte.DisplayLayout.Override.RowAlternateAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.DarkGray
        Me.grdProgramaCorte.DisplayLayout.Override.RowAppearance = Appearance9
        Me.grdProgramaCorte.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdProgramaCorte.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdProgramaCorte.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProgramaCorte.Location = New System.Drawing.Point(0, 3)
        Me.grdProgramaCorte.Name = "grdProgramaCorte"
        Me.grdProgramaCorte.Size = New System.Drawing.Size(1086, 221)
        Me.grdProgramaCorte.TabIndex = 2021
        '
        'ReportesProduccionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1094, 581)
        Me.Controls.Add(Me.pnlReportesPieles)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.pnlReportesGenerales)
        Me.MinimumSize = New System.Drawing.Size(1102, 509)
        Me.Name = "ReportesProduccionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Reportes de Producción"
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlReportesGenerales.ResumeLayout(False)
        CType(Me.grdReportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.grdMateriales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlReportesPieles.ResumeLayout(False)
        CType(Me.grdProgramaCorte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents pnlReportesGenerales As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cbxNave As System.Windows.Forms.ComboBox
    Friend WithEvents dtpPrograma As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents cbxReporte As System.Windows.Forms.ComboBox
    Friend WithEvents lblFechaDel As System.Windows.Forms.Label
    Friend WithEvents lblDcmResultado As System.Windows.Forms.Label
    Friend WithEvents lblDcm As System.Windows.Forms.Label
    Friend WithEvents lblLotesResultado As System.Windows.Forms.Label
    Friend WithEvents lblLotes As System.Windows.Forms.Label
    Friend WithEvents lblParesResultado As System.Windows.Forms.Label
    Friend WithEvents lblPares As System.Windows.Forms.Label
    Friend WithEvents grdReportes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdMateriales As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlReportesPieles As Panel
    Friend WithEvents grdProgramaCorte As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnArticulosPorAutorizar As Button
    Friend WithEvents lblTextoArticulosNoAutorizados As Label
    Friend WithEvents lblUltimaFechaReplica As Label
    Friend WithEvents lblLotesSAY As Label
    Friend WithEvents lblUltimaFechaLoteo As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblLotesSICY As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnActualizarLotes As Button
    Friend WithEvents lblTextoActualizarLotes As Label
    Friend WithEvents lblReporteGeneralSuelas As Label
    Friend WithEvents btnReporteGeneralSuelas As Button
End Class
