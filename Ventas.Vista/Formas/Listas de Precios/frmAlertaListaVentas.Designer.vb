<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlertaListaVentas
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblContListasVigencia = New System.Windows.Forms.Label()
        Me.lblContClientesTemporal = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.lblHoraEnvioAlerta = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grdClientesLVTemp = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grdListaVigenciasProx = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grpClientesListaTemp = New System.Windows.Forms.GroupBox()
        Me.grpVigenciasListas = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblNotas = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        CType(Me.grdClientesLVTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdListaVigenciasProx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpClientesListaTemp.SuspendLayout()
        Me.grpVigenciasListas.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1001, 60)
        Me.pnlHeader.TabIndex = 6
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pctTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(579, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(422, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(142, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(210, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Alertas - Lista de Precios"
        '
        'pctTitulo
        '
        Me.pctTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pctTitulo.Location = New System.Drawing.Point(354, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pctTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pctTitulo.TabIndex = 0
        Me.pctTitulo.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblContListasVigencia)
        Me.Panel2.Controls.Add(Me.lblContClientesTemporal)
        Me.Panel2.Controls.Add(Me.pnlBotones)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 540)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1001, 60)
        Me.Panel2.TabIndex = 7
        '
        'lblContListasVigencia
        '
        Me.lblContListasVigencia.AutoSize = True
        Me.lblContListasVigencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContListasVigencia.Location = New System.Drawing.Point(52, 36)
        Me.lblContListasVigencia.Name = "lblContListasVigencia"
        Me.lblContListasVigencia.Size = New System.Drawing.Size(19, 20)
        Me.lblContListasVigencia.TabIndex = 3
        Me.lblContListasVigencia.Text = "0"
        '
        'lblContClientesTemporal
        '
        Me.lblContClientesTemporal.AutoSize = True
        Me.lblContClientesTemporal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblContClientesTemporal.Location = New System.Drawing.Point(245, 36)
        Me.lblContClientesTemporal.Name = "lblContClientesTemporal"
        Me.lblContClientesTemporal.Size = New System.Drawing.Size(19, 20)
        Me.lblContClientesTemporal.TabIndex = 4
        Me.lblContClientesTemporal.Text = "0"
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.lblHoraEnvioAlerta)
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.Label2)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(694, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(307, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'lblHoraEnvioAlerta
        '
        Me.lblHoraEnvioAlerta.AutoSize = True
        Me.lblHoraEnvioAlerta.Location = New System.Drawing.Point(82, 25)
        Me.lblHoraEnvioAlerta.Name = "lblHoraEnvioAlerta"
        Me.lblHoraEnvioAlerta.Size = New System.Drawing.Size(28, 13)
        Me.lblHoraEnvioAlerta.TabIndex = 2
        Me.lblHoraEnvioAlerta.Text = "-------"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(252, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Alerta enviada:"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(251, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Listas por Vencer"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(182, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 30)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Clientes Lista de Ventas " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Temporal"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdClientesLVTemp
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientesLVTemp.DisplayLayout.Appearance = Appearance1
        Me.grdClientesLVTemp.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClientesLVTemp.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdClientesLVTemp.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdClientesLVTemp.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClientesLVTemp.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdClientesLVTemp.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientesLVTemp.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdClientesLVTemp.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClientesLVTemp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClientesLVTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdClientesLVTemp.Location = New System.Drawing.Point(3, 16)
        Me.grdClientesLVTemp.Name = "grdClientesLVTemp"
        Me.grdClientesLVTemp.Size = New System.Drawing.Size(995, 205)
        Me.grdClientesLVTemp.TabIndex = 1
        '
        'grdListaVigenciasProx
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaVigenciasProx.DisplayLayout.Appearance = Appearance3
        Me.grdListaVigenciasProx.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaVigenciasProx.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdListaVigenciasProx.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaVigenciasProx.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaVigenciasProx.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListaVigenciasProx.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaVigenciasProx.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdListaVigenciasProx.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListaVigenciasProx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaVigenciasProx.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdListaVigenciasProx.Location = New System.Drawing.Point(3, 16)
        Me.grdListaVigenciasProx.Name = "grdListaVigenciasProx"
        Me.grdListaVigenciasProx.Size = New System.Drawing.Size(995, 189)
        Me.grdListaVigenciasProx.TabIndex = 2
        '
        'grpClientesListaTemp
        '
        Me.grpClientesListaTemp.Controls.Add(Me.grdClientesLVTemp)
        Me.grpClientesListaTemp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpClientesListaTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpClientesListaTemp.Location = New System.Drawing.Point(0, 316)
        Me.grpClientesListaTemp.Name = "grpClientesListaTemp"
        Me.grpClientesListaTemp.Size = New System.Drawing.Size(1001, 224)
        Me.grpClientesListaTemp.TabIndex = 8
        Me.grpClientesListaTemp.TabStop = False
        Me.grpClientesListaTemp.Text = "Clientes sin Lista de Precios (Lista de Ventas Temporal)"
        '
        'grpVigenciasListas
        '
        Me.grpVigenciasListas.Controls.Add(Me.grdListaVigenciasProx)
        Me.grpVigenciasListas.Controls.Add(Me.Panel1)
        Me.grpVigenciasListas.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpVigenciasListas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpVigenciasListas.Location = New System.Drawing.Point(0, 60)
        Me.grpVigenciasListas.Name = "grpVigenciasListas"
        Me.grpVigenciasListas.Size = New System.Drawing.Size(1001, 256)
        Me.grpVigenciasListas.TabIndex = 8
        Me.grpVigenciasListas.TabStop = False
        Me.grpVigenciasListas.Text = "Vigencias - Listas de Precios"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblNotas)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 205)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(995, 48)
        Me.Panel1.TabIndex = 7
        '
        'lblNotas
        '
        Me.lblNotas.AutoSize = True
        Me.lblNotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotas.Location = New System.Drawing.Point(431, 3)
        Me.lblNotas.Name = "lblNotas"
        Me.lblNotas.Size = New System.Drawing.Size(472, 39)
        Me.lblNotas.TabIndex = 7
        Me.lblNotas.Text = "Datos modificables desde esta ventana:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "* Fin: Fecha de fin de vigencia de la lis" & _
    "ta" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "* Estatus LPC: Puede modificar a estatus CERRADA/DESCARTADA la Lista de Prec" & _
    "ios de Cliente"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_321
        Me.btnGuardar.Location = New System.Drawing.Point(942, 1)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(936, 33)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 5
        Me.lblGuardar.Text = "Guardar"
        '
        'frmAlertaListaVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1001, 600)
        Me.Controls.Add(Me.grpClientesListaTemp)
        Me.Controls.Add(Me.grpVigenciasListas)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(1017, 639)
        Me.MinimumSize = New System.Drawing.Size(1017, 639)
        Me.Name = "frmAlertaListaVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alertas - Lista de Precios"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        CType(Me.grdClientesLVTemp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdListaVigenciasProx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpClientesListaTemp.ResumeLayout(False)
        Me.grpVigenciasListas.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pctTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents grdClientesLVTemp As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdListaVigenciasProx As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblContListasVigencia As System.Windows.Forms.Label
    Friend WithEvents lblContClientesTemporal As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grpClientesListaTemp As System.Windows.Forms.GroupBox
    Friend WithEvents grpVigenciasListas As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblHoraEnvioAlerta As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblNotas As System.Windows.Forms.Label
End Class
