<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AltaMotivoCancelacionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaMotivoCancelacionForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlBanner = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblguardarmotivo = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCerrarMotivos = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.rpActivoNo = New System.Windows.Forms.RadioButton()
        Me.rpActivoSi = New System.Windows.Forms.RadioButton()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.gbRazonSocialReceptor = New System.Windows.Forms.GroupBox()
        Me.grdRazSocReceptor = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnLImpiarRazSocReceptor = New System.Windows.Forms.Button()
        Me.btnAgregarRazSocReceptor = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.gbRazonSocialEmisor = New System.Windows.Forms.GroupBox()
        Me.grdRazSocEmisor = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnLimpiarRacZocEmisor = New System.Windows.Forms.Button()
        Me.btnAgregarRacSocEmisor = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.pnlBanner.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.gpFecha.SuspendLayout()
        Me.gbRazonSocialReceptor.SuspendLayout()
        CType(Me.grdRazSocReceptor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRazonSocialEmisor.SuspendLayout()
        CType(Me.grdRazSocEmisor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBanner
        '
        Me.pnlBanner.BackColor = System.Drawing.Color.White
        Me.pnlBanner.Controls.Add(Me.pnlTitulo)
        Me.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBanner.Location = New System.Drawing.Point(0, 0)
        Me.pnlBanner.Name = "pnlBanner"
        Me.pnlBanner.Size = New System.Drawing.Size(525, 65)
        Me.pnlBanner.TabIndex = 64
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(154, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(371, 65)
        Me.pnlTitulo.TabIndex = 5
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(303, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 43
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(83, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(201, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Alta Motivo Cancelación"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlAcciones.Controls.Add(Me.pnlPie)
        Me.pnlAcciones.Controls.Add(Me.gpFecha)
        Me.pnlAcciones.Controls.Add(Me.lblMotivo)
        Me.pnlAcciones.Controls.Add(Me.txtMotivo)
        Me.pnlAcciones.Controls.Add(Me.lblLimpiar)
        Me.pnlAcciones.Controls.Add(Me.gbRazonSocialReceptor)
        Me.pnlAcciones.Controls.Add(Me.btnLimpiar)
        Me.pnlAcciones.Controls.Add(Me.gbRazonSocialEmisor)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnMostrar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 65)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(525, 212)
        Me.pnlAcciones.TabIndex = 74
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 141)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(525, 71)
        Me.pnlPie.TabIndex = 135
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblguardarmotivo)
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrarMotivos)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(389, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(136, 71)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblguardarmotivo
        '
        Me.lblguardarmotivo.AutoSize = True
        Me.lblguardarmotivo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblguardarmotivo.Location = New System.Drawing.Point(24, 48)
        Me.lblguardarmotivo.Name = "lblguardarmotivo"
        Me.lblguardarmotivo.Size = New System.Drawing.Size(45, 13)
        Me.lblguardarmotivo.TabIndex = 24
        Me.lblguardarmotivo.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(28, 14)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 23
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCerrarMotivos
        '
        Me.btnCerrarMotivos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrarMotivos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrarMotivos.Image = Global.Cobranza.Vista.My.Resources.Resources.salir_32
        Me.btnCerrarMotivos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrarMotivos.Location = New System.Drawing.Point(88, 13)
        Me.btnCerrarMotivos.Name = "btnCerrarMotivos"
        Me.btnCerrarMotivos.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrarMotivos.TabIndex = 2
        Me.btnCerrarMotivos.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(87, 48)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'gpFecha
        '
        Me.gpFecha.Controls.Add(Me.rpActivoNo)
        Me.gpFecha.Controls.Add(Me.rpActivoSi)
        Me.gpFecha.Location = New System.Drawing.Point(82, 76)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(363, 49)
        Me.gpFecha.TabIndex = 134
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "Activo"
        '
        'rpActivoNo
        '
        Me.rpActivoNo.AutoSize = True
        Me.rpActivoNo.Location = New System.Drawing.Point(231, 21)
        Me.rpActivoNo.Name = "rpActivoNo"
        Me.rpActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rpActivoNo.TabIndex = 9
        Me.rpActivoNo.Text = "No"
        Me.rpActivoNo.UseVisualStyleBackColor = True
        '
        'rpActivoSi
        '
        Me.rpActivoSi.AutoSize = True
        Me.rpActivoSi.Location = New System.Drawing.Point(111, 21)
        Me.rpActivoSi.Name = "rpActivoSi"
        Me.rpActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rpActivoSi.TabIndex = 8
        Me.rpActivoSi.Text = "Si"
        Me.rpActivoSi.UseVisualStyleBackColor = True
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.Location = New System.Drawing.Point(79, 33)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(39, 13)
        Me.lblMotivo.TabIndex = 133
        Me.lblMotivo.Text = "Motivo"
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(124, 33)
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(321, 20)
        Me.txtMotivo.TabIndex = 132
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(1302, 76)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 24
        Me.lblLimpiar.Text = "Limpiar"
        '
        'gbRazonSocialReceptor
        '
        Me.gbRazonSocialReceptor.Controls.Add(Me.grdRazSocReceptor)
        Me.gbRazonSocialReceptor.Controls.Add(Me.btnLImpiarRazSocReceptor)
        Me.gbRazonSocialReceptor.Controls.Add(Me.btnAgregarRazSocReceptor)
        Me.gbRazonSocialReceptor.Location = New System.Drawing.Point(1065, 31)
        Me.gbRazonSocialReceptor.Name = "gbRazonSocialReceptor"
        Me.gbRazonSocialReceptor.Size = New System.Drawing.Size(181, 162)
        Me.gbRazonSocialReceptor.TabIndex = 84
        Me.gbRazonSocialReceptor.TabStop = False
        Me.gbRazonSocialReceptor.Text = "Razón Social Receptor"
        '
        'grdRazSocReceptor
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdRazSocReceptor.DisplayLayout.Appearance = Appearance1
        Me.grdRazSocReceptor.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdRazSocReceptor.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdRazSocReceptor.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdRazSocReceptor.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdRazSocReceptor.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdRazSocReceptor.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdRazSocReceptor.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdRazSocReceptor.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdRazSocReceptor.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdRazSocReceptor.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdRazSocReceptor.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdRazSocReceptor.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdRazSocReceptor.Location = New System.Drawing.Point(3, 33)
        Me.grdRazSocReceptor.Name = "grdRazSocReceptor"
        Me.grdRazSocReceptor.Size = New System.Drawing.Size(175, 126)
        Me.grdRazSocReceptor.TabIndex = 15
        '
        'btnLImpiarRazSocReceptor
        '
        Me.btnLImpiarRazSocReceptor.Image = Global.Cobranza.Vista.My.Resources.Resources.limpiar_32
        Me.btnLImpiarRazSocReceptor.Location = New System.Drawing.Point(126, 9)
        Me.btnLImpiarRazSocReceptor.Name = "btnLImpiarRazSocReceptor"
        Me.btnLImpiarRazSocReceptor.Size = New System.Drawing.Size(22, 22)
        Me.btnLImpiarRazSocReceptor.TabIndex = 13
        Me.btnLImpiarRazSocReceptor.UseVisualStyleBackColor = True
        '
        'btnAgregarRazSocReceptor
        '
        Me.btnAgregarRazSocReceptor.Image = Global.Cobranza.Vista.My.Resources.Resources.agregar_32
        Me.btnAgregarRazSocReceptor.Location = New System.Drawing.Point(154, 9)
        Me.btnAgregarRazSocReceptor.Name = "btnAgregarRazSocReceptor"
        Me.btnAgregarRazSocReceptor.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarRazSocReceptor.TabIndex = 14
        Me.btnAgregarRazSocReceptor.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Cobranza.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(1303, 41)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 23
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'gbRazonSocialEmisor
        '
        Me.gbRazonSocialEmisor.Controls.Add(Me.grdRazSocEmisor)
        Me.gbRazonSocialEmisor.Controls.Add(Me.btnLimpiarRacZocEmisor)
        Me.gbRazonSocialEmisor.Controls.Add(Me.btnAgregarRacSocEmisor)
        Me.gbRazonSocialEmisor.Location = New System.Drawing.Point(882, 31)
        Me.gbRazonSocialEmisor.Name = "gbRazonSocialEmisor"
        Me.gbRazonSocialEmisor.Size = New System.Drawing.Size(181, 162)
        Me.gbRazonSocialEmisor.TabIndex = 131
        Me.gbRazonSocialEmisor.TabStop = False
        Me.gbRazonSocialEmisor.Text = "Razón Social Emisor"
        '
        'grdRazSocEmisor
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdRazSocEmisor.DisplayLayout.Appearance = Appearance3
        Me.grdRazSocEmisor.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdRazSocEmisor.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdRazSocEmisor.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdRazSocEmisor.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdRazSocEmisor.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdRazSocEmisor.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdRazSocEmisor.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdRazSocEmisor.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdRazSocEmisor.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdRazSocEmisor.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdRazSocEmisor.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdRazSocEmisor.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdRazSocEmisor.Location = New System.Drawing.Point(3, 33)
        Me.grdRazSocEmisor.Name = "grdRazSocEmisor"
        Me.grdRazSocEmisor.Size = New System.Drawing.Size(175, 126)
        Me.grdRazSocEmisor.TabIndex = 15
        '
        'btnLimpiarRacZocEmisor
        '
        Me.btnLimpiarRacZocEmisor.Image = Global.Cobranza.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarRacZocEmisor.Location = New System.Drawing.Point(126, 9)
        Me.btnLimpiarRacZocEmisor.Name = "btnLimpiarRacZocEmisor"
        Me.btnLimpiarRacZocEmisor.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarRacZocEmisor.TabIndex = 13
        Me.btnLimpiarRacZocEmisor.UseVisualStyleBackColor = True
        '
        'btnAgregarRacSocEmisor
        '
        Me.btnAgregarRacSocEmisor.Image = Global.Cobranza.Vista.My.Resources.Resources.agregar_32
        Me.btnAgregarRacSocEmisor.Location = New System.Drawing.Point(154, 9)
        Me.btnAgregarRacSocEmisor.Name = "btnAgregarRacSocEmisor"
        Me.btnAgregarRacSocEmisor.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarRacSocEmisor.TabIndex = 14
        Me.btnAgregarRacSocEmisor.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(1254, 76)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(42, 13)
        Me.lblGuardar.TabIndex = 22
        Me.lblGuardar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Cobranza.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(1258, 42)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 21
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'AltaMotivoCancelacionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 277)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.pnlBanner)
        Me.Name = "AltaMotivoCancelacionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta Motivo Cancelacion"
        Me.pnlBanner.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.gpFecha.ResumeLayout(False)
        Me.gpFecha.PerformLayout()
        Me.gbRazonSocialReceptor.ResumeLayout(False)
        CType(Me.grdRazSocReceptor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRazonSocialEmisor.ResumeLayout(False)
        CType(Me.grdRazSocEmisor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlBanner As Windows.Forms.Panel
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents pnlAcciones As Windows.Forms.Panel
    Friend WithEvents lblLimpiar As Windows.Forms.Label
    Friend WithEvents gbRazonSocialReceptor As Windows.Forms.GroupBox
    Friend WithEvents grdRazSocReceptor As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnLImpiarRazSocReceptor As Windows.Forms.Button
    Friend WithEvents btnAgregarRazSocReceptor As Windows.Forms.Button
    Friend WithEvents btnLimpiar As Windows.Forms.Button
    Friend WithEvents gbRazonSocialEmisor As Windows.Forms.GroupBox
    Friend WithEvents grdRazSocEmisor As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnLimpiarRacZocEmisor As Windows.Forms.Button
    Friend WithEvents btnAgregarRacSocEmisor As Windows.Forms.Button
    Friend WithEvents lblGuardar As Windows.Forms.Label
    Friend WithEvents btnMostrar As Windows.Forms.Button
    Friend WithEvents txtMotivo As Windows.Forms.TextBox
    Friend WithEvents lblMotivo As Windows.Forms.Label
    Friend WithEvents gpFecha As Windows.Forms.GroupBox
    Friend WithEvents rpActivoNo As Windows.Forms.RadioButton
    Friend WithEvents rpActivoSi As Windows.Forms.RadioButton
    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As Windows.Forms.Panel
    Friend WithEvents lblguardarmotivo As Windows.Forms.Label
    Friend WithEvents btnGuardar As Windows.Forms.Button
    Friend WithEvents btnCerrarMotivos As Windows.Forms.Button
    Friend WithEvents lblCancelar As Windows.Forms.Label
End Class
