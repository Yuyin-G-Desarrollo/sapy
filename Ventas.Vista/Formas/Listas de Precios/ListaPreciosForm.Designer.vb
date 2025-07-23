<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaPreciosForm
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblResumenListaBase1 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.grpBotonesListaVentas = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAltaListaVentas = New System.Windows.Forms.Button()
        Me.grpBotonesListaBase = New System.Windows.Forms.GroupBox()
        Me.btnHistorico = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblHistorico = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.alertaVigencia = New Infragistics.Win.Misc.UltraDesktopAlert(Me.components)
        Me.timerAlertaVigencia = New System.Windows.Forms.Timer(Me.components)
        Me.grdListadePrecios = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grdListasVentas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnl_ResumenLB = New System.Windows.Forms.Panel()
        Me.pnl_HistoricoLB = New System.Windows.Forms.Panel()
        Me.pnl_AltaLB = New System.Windows.Forms.Panel()
        Me.pnlHeader.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.grpBotonesListaVentas.SuspendLayout()
        Me.grpBotonesListaBase.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        CType(Me.alertaVigencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdListadePrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdListasVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_ResumenLB.SuspendLayout()
        Me.pnl_HistoricoLB.SuspendLayout()
        Me.pnl_AltaLB.SuspendLayout()
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
        Me.pnlHeader.Size = New System.Drawing.Size(1016, 60)
        Me.pnlHeader.TabIndex = 1
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.pnl_ResumenLB)
        Me.pnlAcciones.Controls.Add(Me.grpBotonesListaVentas)
        Me.pnlAcciones.Controls.Add(Me.grpBotonesListaBase)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(376, 60)
        Me.pnlAcciones.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(6, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Lista Base"
        '
        'lblResumenListaBase1
        '
        Me.lblResumenListaBase1.AutoSize = True
        Me.lblResumenListaBase1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblResumenListaBase1.Location = New System.Drawing.Point(8, 33)
        Me.lblResumenListaBase1.Name = "lblResumenListaBase1"
        Me.lblResumenListaBase1.Size = New System.Drawing.Size(52, 13)
        Me.lblResumenListaBase1.TabIndex = 5
        Me.lblResumenListaBase1.Text = "Resumen"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(18, 0)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 28
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'grpBotonesListaVentas
        '
        Me.grpBotonesListaVentas.Controls.Add(Me.Label1)
        Me.grpBotonesListaVentas.Controls.Add(Me.btnAltaListaVentas)
        Me.grpBotonesListaVentas.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpBotonesListaVentas.ForeColor = System.Drawing.Color.Gray
        Me.grpBotonesListaVentas.Location = New System.Drawing.Point(148, 0)
        Me.grpBotonesListaVentas.Name = "grpBotonesListaVentas"
        Me.grpBotonesListaVentas.Size = New System.Drawing.Size(101, 60)
        Me.grpBotonesListaVentas.TabIndex = 26
        Me.grpBotonesListaVentas.TabStop = False
        Me.grpBotonesListaVentas.Text = "Lista de Ventas"
        Me.grpBotonesListaVentas.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(33, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Altas"
        '
        'btnAltaListaVentas
        '
        Me.btnAltaListaVentas.Image = Global.Ventas.Vista.My.Resources.Resources.altas_32
        Me.btnAltaListaVentas.Location = New System.Drawing.Point(32, 14)
        Me.btnAltaListaVentas.Name = "btnAltaListaVentas"
        Me.btnAltaListaVentas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltaListaVentas.TabIndex = 4
        Me.btnAltaListaVentas.UseVisualStyleBackColor = True
        '
        'grpBotonesListaBase
        '
        Me.grpBotonesListaBase.Controls.Add(Me.pnl_AltaLB)
        Me.grpBotonesListaBase.Controls.Add(Me.pnl_HistoricoLB)
        Me.grpBotonesListaBase.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpBotonesListaBase.ForeColor = System.Drawing.Color.Gray
        Me.grpBotonesListaBase.Location = New System.Drawing.Point(0, 0)
        Me.grpBotonesListaBase.Name = "grpBotonesListaBase"
        Me.grpBotonesListaBase.Size = New System.Drawing.Size(148, 60)
        Me.grpBotonesListaBase.TabIndex = 27
        Me.grpBotonesListaBase.TabStop = False
        Me.grpBotonesListaBase.Text = "Lista Base"
        Me.grpBotonesListaBase.Visible = False
        '
        'btnHistorico
        '
        Me.btnHistorico.Image = Global.Ventas.Vista.My.Resources.Resources.historico
        Me.btnHistorico.Location = New System.Drawing.Point(12, 2)
        Me.btnHistorico.Name = "btnHistorico"
        Me.btnHistorico.Size = New System.Drawing.Size(32, 32)
        Me.btnHistorico.TabIndex = 25
        Me.btnHistorico.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(10, 34)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 0
        Me.lblAltas.Text = "Altas"
        '
        'btnAltas
        '
        Me.btnAltas.Image = Global.Ventas.Vista.My.Resources.Resources.altas_32
        Me.btnAltas.Location = New System.Drawing.Point(9, 3)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 2
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblHistorico
        '
        Me.lblHistorico.AutoSize = True
        Me.lblHistorico.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblHistorico.Location = New System.Drawing.Point(4, 33)
        Me.lblHistorico.Name = "lblHistorico"
        Me.lblHistorico.Size = New System.Drawing.Size(48, 13)
        Me.lblHistorico.TabIndex = 24
        Me.lblHistorico.Text = "Histórico"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(660, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(356, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(9, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(285, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Catálogo de Listas de Precio Base"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(296, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(60, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pnlBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 569)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1016, 60)
        Me.Panel2.TabIndex = 4
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(785, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(231, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(171, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(170, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'alertaVigencia
        '
        Me.alertaVigencia.AnimationSpeed = Infragistics.Win.Misc.AnimationSpeed.Medium
        Me.alertaVigencia.AnimationStyleAutoClose = Infragistics.Win.Misc.AnimationStyle.Fade
        Me.alertaVigencia.AnimationStyleShow = Infragistics.Win.Misc.AnimationStyle.Fade
        Me.alertaVigencia.MultipleWindowDisplayStyle = Infragistics.Win.Misc.MultipleWindowDisplayStyle.None
        Me.alertaVigencia.Style = Infragistics.Win.Misc.DesktopAlertStyle.Office2007
        '
        'grdListadePrecios
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListadePrecios.DisplayLayout.Appearance = Appearance1
        Me.grdListadePrecios.DisplayLayout.GroupByBox.Hidden = True
        Me.grdListadePrecios.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListadePrecios.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdListadePrecios.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.grdListadePrecios.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListadePrecios.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdListadePrecios.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListadePrecios.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdListadePrecios.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListadePrecios.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None
        Me.grdListadePrecios.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdListadePrecios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListadePrecios.Location = New System.Drawing.Point(0, 60)
        Me.grdListadePrecios.Name = "grdListadePrecios"
        Me.grdListadePrecios.Size = New System.Drawing.Size(1016, 155)
        Me.grdListadePrecios.TabIndex = 0
        Me.grdListadePrecios.Text = "Listas Base"
        '
        'grdListasVentas
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListasVentas.DisplayLayout.Appearance = Appearance3
        Me.grdListasVentas.DisplayLayout.GroupByBox.Hidden = True
        Me.grdListasVentas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListasVentas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdListasVentas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.grdListasVentas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListasVentas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdListasVentas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListasVentas.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdListasVentas.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListasVentas.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None
        Me.grdListasVentas.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdListasVentas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdListasVentas.Location = New System.Drawing.Point(0, 215)
        Me.grdListasVentas.Name = "grdListasVentas"
        Me.grdListasVentas.Size = New System.Drawing.Size(1016, 354)
        Me.grdListasVentas.TabIndex = 1
        Me.grdListasVentas.Text = "Listas de Venta"
        '
        'pnl_ResumenLB
        '
        Me.pnl_ResumenLB.Controls.Add(Me.Label2)
        Me.pnl_ResumenLB.Controls.Add(Me.btnMostrar)
        Me.pnl_ResumenLB.Controls.Add(Me.lblResumenListaBase1)
        Me.pnl_ResumenLB.Location = New System.Drawing.Point(255, 3)
        Me.pnl_ResumenLB.Name = "pnl_ResumenLB"
        Me.pnl_ResumenLB.Size = New System.Drawing.Size(68, 57)
        Me.pnl_ResumenLB.TabIndex = 2
        Me.pnl_ResumenLB.Visible = False
        '
        'pnl_HistoricoLB
        '
        Me.pnl_HistoricoLB.Controls.Add(Me.btnHistorico)
        Me.pnl_HistoricoLB.Controls.Add(Me.lblHistorico)
        Me.pnl_HistoricoLB.Location = New System.Drawing.Point(80, 13)
        Me.pnl_HistoricoLB.Name = "pnl_HistoricoLB"
        Me.pnl_HistoricoLB.Size = New System.Drawing.Size(53, 47)
        Me.pnl_HistoricoLB.TabIndex = 5
        Me.pnl_HistoricoLB.Visible = False
        '
        'pnl_AltaLB
        '
        Me.pnl_AltaLB.Controls.Add(Me.btnAltas)
        Me.pnl_AltaLB.Controls.Add(Me.lblAltas)
        Me.pnl_AltaLB.Location = New System.Drawing.Point(22, 12)
        Me.pnl_AltaLB.Name = "pnl_AltaLB"
        Me.pnl_AltaLB.Size = New System.Drawing.Size(53, 48)
        Me.pnl_AltaLB.TabIndex = 2
        Me.pnl_AltaLB.Visible = False
        '
        'ListaPreciosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1016, 629)
        Me.Controls.Add(Me.grdListadePrecios)
        Me.Controls.Add(Me.grdListasVentas)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ListaPreciosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de Listas de Precio Base"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.grpBotonesListaVentas.ResumeLayout(False)
        Me.grpBotonesListaVentas.PerformLayout()
        Me.grpBotonesListaBase.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        CType(Me.alertaVigencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdListadePrecios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdListasVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_ResumenLB.ResumeLayout(False)
        Me.pnl_ResumenLB.PerformLayout()
        Me.pnl_HistoricoLB.ResumeLayout(False)
        Me.pnl_HistoricoLB.PerformLayout()
        Me.pnl_AltaLB.ResumeLayout(False)
        Me.pnl_AltaLB.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnHistorico As System.Windows.Forms.Button
    Friend WithEvents lblHistorico As System.Windows.Forms.Label
    Friend WithEvents alertaVigencia As Infragistics.Win.Misc.UltraDesktopAlert
    Friend WithEvents timerAlertaVigencia As System.Windows.Forms.Timer
    Friend WithEvents grdListadePrecios As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdListasVentas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grpBotonesListaVentas As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAltaListaVentas As System.Windows.Forms.Button
    Friend WithEvents grpBotonesListaBase As System.Windows.Forms.GroupBox
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblResumenListaBase1 As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents pnl_ResumenLB As Panel
    Friend WithEvents pnl_AltaLB As Panel
    Friend WithEvents pnl_HistoricoLB As Panel
End Class
