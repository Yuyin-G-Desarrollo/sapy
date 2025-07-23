<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlertaApartadosCancelados
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grpClientesListaTemp = New System.Windows.Forms.GroupBox()
        Me.grdPartidasCanceladas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grpVigenciasListas = New System.Windows.Forms.GroupBox()
        Me.grdApartadosCancelados = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblHoraEnvioAlerta = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.grpClientesListaTemp.SuspendLayout()
        CType(Me.grdPartidasCanceladas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpVigenciasListas.SuspendLayout()
        CType(Me.grdApartadosCancelados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotones.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 205)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(995, 48)
        Me.Panel1.TabIndex = 7
        '
        'grpClientesListaTemp
        '
        Me.grpClientesListaTemp.Controls.Add(Me.grdPartidasCanceladas)
        Me.grpClientesListaTemp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpClientesListaTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpClientesListaTemp.Location = New System.Drawing.Point(0, 316)
        Me.grpClientesListaTemp.Name = "grpClientesListaTemp"
        Me.grpClientesListaTemp.Size = New System.Drawing.Size(1001, 224)
        Me.grpClientesListaTemp.TabIndex = 11
        Me.grpClientesListaTemp.TabStop = False
        Me.grpClientesListaTemp.Text = "Partidas Canceladas"
        '
        'grdPartidasCanceladas
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPartidasCanceladas.DisplayLayout.Appearance = Appearance1
        Me.grdPartidasCanceladas.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdPartidasCanceladas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPartidasCanceladas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdPartidasCanceladas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdPartidasCanceladas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPartidasCanceladas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdPartidasCanceladas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPartidasCanceladas.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdPartidasCanceladas.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdPartidasCanceladas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPartidasCanceladas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPartidasCanceladas.Location = New System.Drawing.Point(3, 16)
        Me.grdPartidasCanceladas.Name = "grdPartidasCanceladas"
        Me.grdPartidasCanceladas.Size = New System.Drawing.Size(995, 205)
        Me.grdPartidasCanceladas.TabIndex = 1
        '
        'grpVigenciasListas
        '
        Me.grpVigenciasListas.Controls.Add(Me.grdApartadosCancelados)
        Me.grpVigenciasListas.Controls.Add(Me.Panel1)
        Me.grpVigenciasListas.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpVigenciasListas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpVigenciasListas.Location = New System.Drawing.Point(0, 60)
        Me.grpVigenciasListas.Name = "grpVigenciasListas"
        Me.grpVigenciasListas.Size = New System.Drawing.Size(1001, 256)
        Me.grpVigenciasListas.TabIndex = 12
        Me.grpVigenciasListas.TabStop = False
        Me.grpVigenciasListas.Text = "Apartados Cancelados"
        '
        'grdApartadosCancelados
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdApartadosCancelados.DisplayLayout.Appearance = Appearance3
        Me.grdApartadosCancelados.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdApartadosCancelados.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdApartadosCancelados.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdApartadosCancelados.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdApartadosCancelados.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdApartadosCancelados.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdApartadosCancelados.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdApartadosCancelados.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdApartadosCancelados.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdApartadosCancelados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdApartadosCancelados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdApartadosCancelados.Location = New System.Drawing.Point(3, 16)
        Me.grdApartadosCancelados.Name = "grdApartadosCancelados"
        Me.grdApartadosCancelados.Size = New System.Drawing.Size(995, 189)
        Me.grdApartadosCancelados.TabIndex = 2
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
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pnlBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 540)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1001, 60)
        Me.Panel2.TabIndex = 10
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(93, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(255, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Alerta - Apartados Cancelados"
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
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1001, 60)
        Me.pnlHeader.TabIndex = 9
        '
        'AlertaApartadosCancelados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1001, 600)
        Me.Controls.Add(Me.grpClientesListaTemp)
        Me.Controls.Add(Me.grpVigenciasListas)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(1017, 639)
        Me.MinimumSize = New System.Drawing.Size(1017, 639)
        Me.Name = "AlertaApartadosCancelados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alerta - Apartados Cancelados"
        Me.grpClientesListaTemp.ResumeLayout(False)
        CType(Me.grdPartidasCanceladas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpVigenciasListas.ResumeLayout(False)
        CType(Me.grdApartadosCancelados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grpClientesListaTemp As System.Windows.Forms.GroupBox
    Friend WithEvents grdPartidasCanceladas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grpVigenciasListas As System.Windows.Forms.GroupBox
    Friend WithEvents grdApartadosCancelados As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblHoraEnvioAlerta As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pctTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
End Class
