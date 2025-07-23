<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportarAExcelForm
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pnlBanner = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.grdCatalogo = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbDias = New System.Windows.Forms.GroupBox()
        Me.gboxDescuentos = New System.Windows.Forms.GroupBox()
        Me.grdDescuentos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtVigencia = New System.Windows.Forms.TextBox()
        Me.txtTemporada = New System.Windows.Forms.TextBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblTemporada = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.txtNombreCliente = New System.Windows.Forms.TextBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlBanner.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.grdCatalogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbDias.SuspendLayout()
        Me.gboxDescuentos.SuspendLayout()
        CType(Me.grdDescuentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(799, 60)
        Me.pnlHeader.TabIndex = 22
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pnlBanner)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.pnlTitulo.Location = New System.Drawing.Point(184, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(615, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'pnlBanner
        '
        Me.pnlBanner.Controls.Add(Me.lblTitulo)
        Me.pnlBanner.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlBanner.ForeColor = System.Drawing.Color.SteelBlue
        Me.pnlBanner.Location = New System.Drawing.Point(3, 24)
        Me.pnlBanner.Name = "pnlBanner"
        Me.pnlBanner.Size = New System.Drawing.Size(546, 36)
        Me.pnlBanner.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Location = New System.Drawing.Point(410, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(136, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Lista de precios"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(555, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(60, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.pnlAcciones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 401)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(799, 60)
        Me.Panel2.TabIndex = 23
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(642, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(157, 60)
        Me.pnlAcciones.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(102, 7)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_321
        Me.btnGuardar.Location = New System.Drawing.Point(49, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(105, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(27, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Salir"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(43, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 2
        Me.lblGuardar.Text = "Guardar"
        '
        'grdCatalogo
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCatalogo.DisplayLayout.Appearance = Appearance1
        Me.grdCatalogo.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdCatalogo.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdCatalogo.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdCatalogo.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCatalogo.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCatalogo.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdCatalogo.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCatalogo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdCatalogo.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdCatalogo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCatalogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCatalogo.Location = New System.Drawing.Point(0, 182)
        Me.grdCatalogo.Name = "grdCatalogo"
        Me.grdCatalogo.Size = New System.Drawing.Size(799, 219)
        Me.grdCatalogo.TabIndex = 24
        '
        'grbDias
        '
        Me.grbDias.Controls.Add(Me.gboxDescuentos)
        Me.grbDias.Controls.Add(Me.txtVigencia)
        Me.grbDias.Controls.Add(Me.txtTemporada)
        Me.grbDias.Controls.Add(Me.lblCliente)
        Me.grbDias.Controls.Add(Me.lblTemporada)
        Me.grbDias.Controls.Add(Me.lblActivo)
        Me.grbDias.Controls.Add(Me.txtNombreCliente)
        Me.grbDias.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbDias.Location = New System.Drawing.Point(0, 60)
        Me.grbDias.Name = "grbDias"
        Me.grbDias.Size = New System.Drawing.Size(799, 122)
        Me.grbDias.TabIndex = 25
        Me.grbDias.TabStop = False
        '
        'gboxDescuentos
        '
        Me.gboxDescuentos.Controls.Add(Me.grdDescuentos)
        Me.gboxDescuentos.Location = New System.Drawing.Point(415, 13)
        Me.gboxDescuentos.Name = "gboxDescuentos"
        Me.gboxDescuentos.Size = New System.Drawing.Size(378, 103)
        Me.gboxDescuentos.TabIndex = 29
        Me.gboxDescuentos.TabStop = False
        '
        'grdDescuentos
        '
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDescuentos.DisplayLayout.Appearance = Appearance2
        Me.grdDescuentos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdDescuentos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdDescuentos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdDescuentos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdDescuentos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdDescuentos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdDescuentos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdDescuentos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdDescuentos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdDescuentos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDescuentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDescuentos.Location = New System.Drawing.Point(3, 16)
        Me.grdDescuentos.Name = "grdDescuentos"
        Me.grdDescuentos.Size = New System.Drawing.Size(372, 84)
        Me.grdDescuentos.TabIndex = 25
        '
        'txtVigencia
        '
        Me.txtVigencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVigencia.Location = New System.Drawing.Point(112, 79)
        Me.txtVigencia.MaxLength = 50
        Me.txtVigencia.Name = "txtVigencia"
        Me.txtVigencia.Size = New System.Drawing.Size(296, 20)
        Me.txtVigencia.TabIndex = 28
        '
        'txtTemporada
        '
        Me.txtTemporada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTemporada.Location = New System.Drawing.Point(112, 53)
        Me.txtTemporada.MaxLength = 50
        Me.txtTemporada.Name = "txtTemporada"
        Me.txtTemporada.Size = New System.Drawing.Size(296, 20)
        Me.txtTemporada.TabIndex = 27
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(6, 30)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(42, 13)
        Me.lblCliente.TabIndex = 7
        Me.lblCliente.Text = "Cliente:"
        '
        'lblTemporada
        '
        Me.lblTemporada.AutoSize = True
        Me.lblTemporada.Location = New System.Drawing.Point(6, 56)
        Me.lblTemporada.Name = "lblTemporada"
        Me.lblTemporada.Size = New System.Drawing.Size(64, 13)
        Me.lblTemporada.TabIndex = 7
        Me.lblTemporada.Text = "Temporada:"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(6, 82)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(100, 13)
        Me.lblActivo.TabIndex = 5
        Me.lblActivo.Text = "Vigencia de costos:"
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreCliente.Location = New System.Drawing.Point(112, 27)
        Me.txtNombreCliente.MaxLength = 50
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.Size = New System.Drawing.Size(296, 20)
        Me.txtNombreCliente.TabIndex = 1
        '
        'ExportarAExcelForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(799, 461)
        Me.Controls.Add(Me.grdCatalogo)
        Me.Controls.Add(Me.grbDias)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.Panel2)
        Me.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ExportarAExcelForm"
        Me.Text = "ExportarAExcelForm"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlBanner.ResumeLayout(False)
        Me.pnlBanner.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        CType(Me.grdCatalogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbDias.ResumeLayout(False)
        Me.grbDias.PerformLayout()
        Me.gboxDescuentos.ResumeLayout(False)
        CType(Me.grdDescuentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents pnlBanner As System.Windows.Forms.Panel
    Friend WithEvents grdCatalogo As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grbDias As System.Windows.Forms.GroupBox
    Friend WithEvents gboxDescuentos As System.Windows.Forms.GroupBox
    Friend WithEvents grdDescuentos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtVigencia As System.Windows.Forms.TextBox
    Friend WithEvents txtTemporada As System.Windows.Forms.TextBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblTemporada As System.Windows.Forms.Label
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents txtNombreCliente As System.Windows.Forms.TextBox
End Class
