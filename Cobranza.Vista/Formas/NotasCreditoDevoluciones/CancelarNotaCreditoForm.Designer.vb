<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CancelarNotaCreditoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CancelarNotaCreditoForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlBanner = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.cmbTipoMotivosCancelacion = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
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
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.gbRazonSocialReceptor.SuspendLayout()
        CType(Me.grdRazSocReceptor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRazonSocialEmisor.SuspendLayout()
        CType(Me.grdRazSocEmisor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBanner
        '
        Me.pnlBanner.BackColor = System.Drawing.Color.White
        Me.pnlBanner.Controls.Add(Me.pbYuyin)
        Me.pnlBanner.Controls.Add(Me.lblTitulo)
        Me.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBanner.Location = New System.Drawing.Point(0, 0)
        Me.pnlBanner.Name = "pnlBanner"
        Me.pnlBanner.Size = New System.Drawing.Size(513, 65)
        Me.pnlBanner.TabIndex = 63
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(445, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 44
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(233, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(211, 20)
        Me.lblTitulo.TabIndex = 3
        Me.lblTitulo.Text = "Cancelar Nota de Credito"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 278)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(513, 62)
        Me.pnlPie.TabIndex = 74
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.Label1)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(367, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(146, 62)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnAceptar
        '
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Cobranza.Vista.My.Resources.Resources.aceptar_321
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(35, 7)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(30, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Aceptar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Cobranza.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(94, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(93, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlAcciones.Controls.Add(Me.cmbTipoMotivosCancelacion)
        Me.pnlAcciones.Controls.Add(Me.Label3)
        Me.pnlAcciones.Controls.Add(Me.txtObservaciones)
        Me.pnlAcciones.Controls.Add(Me.Label2)
        Me.pnlAcciones.Controls.Add(Me.lblLimpiar)
        Me.pnlAcciones.Controls.Add(Me.gbRazonSocialReceptor)
        Me.pnlAcciones.Controls.Add(Me.btnLimpiar)
        Me.pnlAcciones.Controls.Add(Me.gbRazonSocialEmisor)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnMostrar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 65)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(513, 213)
        Me.pnlAcciones.TabIndex = 75
        '
        'cmbTipoMotivosCancelacion
        '
        Me.cmbTipoMotivosCancelacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMotivosCancelacion.FormattingEnabled = True
        Me.cmbTipoMotivosCancelacion.Location = New System.Drawing.Point(139, 23)
        Me.cmbTipoMotivosCancelacion.Name = "cmbTipoMotivosCancelacion"
        Me.cmbTipoMotivosCancelacion.Size = New System.Drawing.Size(280, 21)
        Me.cmbTipoMotivosCancelacion.TabIndex = 153
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(85, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 152
        Me.Label3.Text = "Observaciones"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(88, 81)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(331, 112)
        Me.txtObservaciones.TabIndex = 151
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(85, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 150
        Me.Label2.Text = "Motivo"
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
        'CancelarNotaCreditoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 340)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlBanner)
        Me.MaximumSize = New System.Drawing.Size(529, 379)
        Me.MinimumSize = New System.Drawing.Size(529, 379)
        Me.Name = "CancelarNotaCreditoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelar Nota de Credito"
        Me.pnlBanner.ResumeLayout(False)
        Me.pnlBanner.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.gbRazonSocialReceptor.ResumeLayout(False)
        CType(Me.grdRazSocReceptor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRazonSocialEmisor.ResumeLayout(False)
        CType(Me.grdRazSocEmisor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlBanner As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As Windows.Forms.Panel
    Friend WithEvents btnCerrar As Windows.Forms.Button
    Friend WithEvents lblCancelar As Windows.Forms.Label
    Friend WithEvents btnAceptar As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
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
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtObservaciones As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents cmbTipoMotivosCancelacion As Windows.Forms.ComboBox
End Class
