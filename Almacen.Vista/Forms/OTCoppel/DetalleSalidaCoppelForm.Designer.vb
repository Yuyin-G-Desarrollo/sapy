<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetalleSalidaCoppelForm
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
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.grpDatosDetalles = New System.Windows.Forms.GroupBox()
        Me.pnlFooter = New System.Windows.Forms.Panel()
        Me.pnlTotales = New System.Windows.Forms.Panel()
        Me.lblTotalParesMostrar = New System.Windows.Forms.Label()
        Me.lblTotalPares = New System.Windows.Forms.Label()
        Me.pnlSalir = New System.Windows.Forms.Panel()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.grdDetallesSalida = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblCorrectos = New System.Windows.Forms.Label()
        Me.pnlCorrectos = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblExternos = New System.Windows.Forms.Label()
        Me.pnlExternos = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTotalExternos = New System.Windows.Forms.Label()
        Me.lblTotalCorrectos = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitle.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFooter.SuspendLayout()
        Me.pnlTotales.SuspendLayout()
        Me.pnlSalir.SuspendLayout()
        CType(Me.grdDetallesSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCorrectos.SuspendLayout()
        Me.pnlExternos.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblExportar)
        Me.pnlHeader.Controls.Add(Me.btnExportar)
        Me.pnlHeader.Controls.Add(Me.pnlTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(859, 65)
        Me.pnlHeader.TabIndex = 0
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(29, 41)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 1
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Almacen.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(35, 7)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 1
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'pnlTitle
        '
        Me.pnlTitle.Controls.Add(Me.lblTitle)
        Me.pnlTitle.Controls.Add(Me.imgLogo)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitle.Location = New System.Drawing.Point(625, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(234, 65)
        Me.pnlTitle.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(3, 24)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(146, 20)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Detalle de Salida"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(156, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(78, 65)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 0
        Me.imgLogo.TabStop = False
        '
        'grpDatosDetalles
        '
        Me.grpDatosDetalles.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpDatosDetalles.Location = New System.Drawing.Point(0, 65)
        Me.grpDatosDetalles.Name = "grpDatosDetalles"
        Me.grpDatosDetalles.Size = New System.Drawing.Size(859, 10)
        Me.grpDatosDetalles.TabIndex = 2
        Me.grpDatosDetalles.TabStop = False
        '
        'pnlFooter
        '
        Me.pnlFooter.BackColor = System.Drawing.Color.White
        Me.pnlFooter.Controls.Add(Me.lblCorrectos)
        Me.pnlFooter.Controls.Add(Me.pnlCorrectos)
        Me.pnlFooter.Controls.Add(Me.lblExternos)
        Me.pnlFooter.Controls.Add(Me.pnlExternos)
        Me.pnlFooter.Controls.Add(Me.lblTotalExternos)
        Me.pnlFooter.Controls.Add(Me.lblTotalCorrectos)
        Me.pnlFooter.Controls.Add(Me.pnlTotales)
        Me.pnlFooter.Controls.Add(Me.pnlSalir)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Location = New System.Drawing.Point(0, 558)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(859, 69)
        Me.pnlFooter.TabIndex = 3
        '
        'pnlTotales
        '
        Me.pnlTotales.Controls.Add(Me.lblTotalParesMostrar)
        Me.pnlTotales.Controls.Add(Me.lblTotalPares)
        Me.pnlTotales.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTotales.Location = New System.Drawing.Point(654, 0)
        Me.pnlTotales.Name = "pnlTotales"
        Me.pnlTotales.Size = New System.Drawing.Size(141, 69)
        Me.pnlTotales.TabIndex = 5
        '
        'lblTotalParesMostrar
        '
        Me.lblTotalParesMostrar.AutoSize = True
        Me.lblTotalParesMostrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalParesMostrar.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblTotalParesMostrar.Location = New System.Drawing.Point(94, 22)
        Me.lblTotalParesMostrar.Name = "lblTotalParesMostrar"
        Me.lblTotalParesMostrar.Size = New System.Drawing.Size(32, 13)
        Me.lblTotalParesMostrar.TabIndex = 4
        Me.lblTotalParesMostrar.Text = "total"
        '
        'lblTotalPares
        '
        Me.lblTotalPares.AutoSize = True
        Me.lblTotalPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPares.Location = New System.Drawing.Point(12, 22)
        Me.lblTotalPares.Name = "lblTotalPares"
        Me.lblTotalPares.Size = New System.Drawing.Size(76, 13)
        Me.lblTotalPares.TabIndex = 4
        Me.lblTotalPares.Text = "Total Pares:"
        '
        'pnlSalir
        '
        Me.pnlSalir.Controls.Add(Me.lblSalir)
        Me.pnlSalir.Controls.Add(Me.btnSalir)
        Me.pnlSalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSalir.Location = New System.Drawing.Point(795, 0)
        Me.pnlSalir.Name = "pnlSalir"
        Me.pnlSalir.Size = New System.Drawing.Size(64, 69)
        Me.pnlSalir.TabIndex = 0
        '
        'lblSalir
        '
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(14, 47)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 4
        Me.lblSalir.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(12, 12)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'grdDetallesSalida
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDetallesSalida.DisplayLayout.Appearance = Appearance1
        Me.grdDetallesSalida.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDetallesSalida.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdDetallesSalida.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdDetallesSalida.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdDetallesSalida.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDetallesSalida.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdDetallesSalida.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.AppearancesOnly
        Me.grdDetallesSalida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDetallesSalida.Location = New System.Drawing.Point(0, 75)
        Me.grdDetallesSalida.Name = "grdDetallesSalida"
        Me.grdDetallesSalida.Size = New System.Drawing.Size(859, 483)
        Me.grdDetallesSalida.TabIndex = 4
        '
        'lblCorrectos
        '
        Me.lblCorrectos.AutoSize = True
        Me.lblCorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorrectos.Location = New System.Drawing.Point(40, 41)
        Me.lblCorrectos.Name = "lblCorrectos"
        Me.lblCorrectos.Size = New System.Drawing.Size(52, 13)
        Me.lblCorrectos.TabIndex = 23
        Me.lblCorrectos.Text = "Correctos"
        '
        'pnlCorrectos
        '
        Me.pnlCorrectos.BackColor = System.Drawing.Color.Green
        Me.pnlCorrectos.Controls.Add(Me.Label8)
        Me.pnlCorrectos.Location = New System.Drawing.Point(19, 39)
        Me.pnlCorrectos.Name = "pnlCorrectos"
        Me.pnlCorrectos.Size = New System.Drawing.Size(13, 15)
        Me.pnlCorrectos.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "C"
        '
        'lblExternos
        '
        Me.lblExternos.AutoSize = True
        Me.lblExternos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExternos.Location = New System.Drawing.Point(40, 14)
        Me.lblExternos.Name = "lblExternos"
        Me.lblExternos.Size = New System.Drawing.Size(48, 13)
        Me.lblExternos.TabIndex = 21
        Me.lblExternos.Text = "Externos"
        '
        'pnlExternos
        '
        Me.pnlExternos.BackColor = System.Drawing.Color.Red
        Me.pnlExternos.Controls.Add(Me.Label7)
        Me.pnlExternos.Location = New System.Drawing.Point(19, 12)
        Me.pnlExternos.Name = "pnlExternos"
        Me.pnlExternos.Size = New System.Drawing.Size(13, 15)
        Me.pnlExternos.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(1, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "E"
        '
        'lblTotalExternos
        '
        Me.lblTotalExternos.AutoSize = True
        Me.lblTotalExternos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalExternos.ForeColor = System.Drawing.Color.Red
        Me.lblTotalExternos.Location = New System.Drawing.Point(98, 15)
        Me.lblTotalExternos.Name = "lblTotalExternos"
        Me.lblTotalExternos.Size = New System.Drawing.Size(14, 13)
        Me.lblTotalExternos.TabIndex = 19
        Me.lblTotalExternos.Text = "0"
        '
        'lblTotalCorrectos
        '
        Me.lblTotalCorrectos.AutoSize = True
        Me.lblTotalCorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCorrectos.ForeColor = System.Drawing.Color.Green
        Me.lblTotalCorrectos.Location = New System.Drawing.Point(98, 42)
        Me.lblTotalCorrectos.Name = "lblTotalCorrectos"
        Me.lblTotalCorrectos.Size = New System.Drawing.Size(14, 13)
        Me.lblTotalCorrectos.TabIndex = 18
        Me.lblTotalCorrectos.Text = "0"
        '
        'DetalleSalidaCoppelForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(859, 627)
        Me.Controls.Add(Me.grdDetallesSalida)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.grpDatosDetalles)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "DetalleSalidaCoppelForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFooter.ResumeLayout(False)
        Me.pnlFooter.PerformLayout()
        Me.pnlTotales.ResumeLayout(False)
        Me.pnlTotales.PerformLayout()
        Me.pnlSalir.ResumeLayout(False)
        Me.pnlSalir.PerformLayout()
        CType(Me.grdDetallesSalida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCorrectos.ResumeLayout(False)
        Me.pnlCorrectos.PerformLayout()
        Me.pnlExternos.ResumeLayout(False)
        Me.pnlExternos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents grpDatosDetalles As System.Windows.Forms.GroupBox
    Friend WithEvents pnlFooter As System.Windows.Forms.Panel
    Friend WithEvents lblTotalParesMostrar As System.Windows.Forms.Label
    Friend WithEvents lblTotalPares As System.Windows.Forms.Label
    Friend WithEvents pnlSalir As System.Windows.Forms.Panel
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents grdDetallesSalida As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlTotales As System.Windows.Forms.Panel
    Friend WithEvents lblCorrectos As System.Windows.Forms.Label
    Friend WithEvents pnlCorrectos As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents lblExternos As System.Windows.Forms.Label
    Friend WithEvents pnlExternos As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTotalExternos As System.Windows.Forms.Label
    Friend WithEvents lblTotalCorrectos As System.Windows.Forms.Label
End Class
