<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductosNuevos
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
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.lblListaNaves = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblExportarExcel = New System.Windows.Forms.Label()
        Me.pnlExtado = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.grbNaves = New System.Windows.Forms.GroupBox()
        Me.chkSeleccionarProdsNvs = New System.Windows.Forms.CheckBox()
        Me.chkSeleccionarArts = New System.Windows.Forms.CheckBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.dttFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdProductosDisponibles = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlPasarArticulos = New System.Windows.Forms.Panel()
        Me.btnAgregarColeccion = New System.Windows.Forms.Button()
        Me.btnQuitarColeccion = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.grdProductosNuevos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.exportExcelDetalle = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExtado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grbNaves.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdProductosDisponibles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPasarArticulos.SuspendLayout()
        CType(Me.grdProductosNuevos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Controls.Add(Me.btnExportarExcel)
        Me.pnlEncabezado.Controls.Add(Me.lblExportarExcel)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1194, 59)
        Me.pnlEncabezado.TabIndex = 4
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.lblListaNaves)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(866, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(328, 59)
        Me.pnlTitulo.TabIndex = 33
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(260, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 22
        Me.pcbTitulo.TabStop = False
        '
        'imgLogo
        '
        Me.imgLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgLogo.Location = New System.Drawing.Point(267, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(61, 59)
        Me.imgLogo.TabIndex = 0
        Me.imgLogo.TabStop = False
        '
        'lblListaNaves
        '
        Me.lblListaNaves.AutoSize = True
        Me.lblListaNaves.BackColor = System.Drawing.Color.Transparent
        Me.lblListaNaves.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaNaves.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaNaves.Location = New System.Drawing.Point(103, 19)
        Me.lblListaNaves.Name = "lblListaNaves"
        Me.lblListaNaves.Size = New System.Drawing.Size(154, 20)
        Me.lblListaNaves.TabIndex = 21
        Me.lblListaNaves.Text = "Productos Nuevos"
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.Location = New System.Drawing.Point(20, 7)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 24
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblExportarExcel
        '
        Me.lblExportarExcel.AutoSize = True
        Me.lblExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarExcel.Location = New System.Drawing.Point(20, 39)
        Me.lblExportarExcel.Name = "lblExportarExcel"
        Me.lblExportarExcel.Size = New System.Drawing.Size(33, 13)
        Me.lblExportarExcel.TabIndex = 25
        Me.lblExportarExcel.Text = "Excel"
        '
        'pnlExtado
        '
        Me.pnlExtado.BackColor = System.Drawing.Color.White
        Me.pnlExtado.Controls.Add(Me.Panel1)
        Me.pnlExtado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlExtado.Location = New System.Drawing.Point(0, 549)
        Me.pnlExtado.Name = "pnlExtado"
        Me.pnlExtado.Size = New System.Drawing.Size(1194, 60)
        Me.pnlExtado.TabIndex = 15
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(1060, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(134, 60)
        Me.Panel1.TabIndex = 0
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(75, 39)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(76, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'grbNaves
        '
        Me.grbNaves.Controls.Add(Me.btnGuardar)
        Me.grbNaves.Controls.Add(Me.lblGuardar)
        Me.grbNaves.Controls.Add(Me.chkSeleccionarProdsNvs)
        Me.grbNaves.Controls.Add(Me.chkSeleccionarArts)
        Me.grbNaves.Controls.Add(Me.lblFecha)
        Me.grbNaves.Controls.Add(Me.dttFecha)
        Me.grbNaves.Controls.Add(Me.lblNave)
        Me.grbNaves.Controls.Add(Me.cmbNaves)
        Me.grbNaves.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbNaves.Location = New System.Drawing.Point(0, 59)
        Me.grbNaves.Name = "grbNaves"
        Me.grbNaves.Size = New System.Drawing.Size(1194, 57)
        Me.grbNaves.TabIndex = 16
        Me.grbNaves.TabStop = False
        '
        'chkSeleccionarProdsNvs
        '
        Me.chkSeleccionarProdsNvs.AutoSize = True
        Me.chkSeleccionarProdsNvs.Location = New System.Drawing.Point(600, 37)
        Me.chkSeleccionarProdsNvs.Name = "chkSeleccionarProdsNvs"
        Me.chkSeleccionarProdsNvs.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarProdsNvs.TabIndex = 12
        Me.chkSeleccionarProdsNvs.Text = "Seleccionar Todo"
        Me.chkSeleccionarProdsNvs.UseVisualStyleBackColor = True
        '
        'chkSeleccionarArts
        '
        Me.chkSeleccionarArts.AutoSize = True
        Me.chkSeleccionarArts.Location = New System.Drawing.Point(3, 37)
        Me.chkSeleccionarArts.Name = "chkSeleccionarArts"
        Me.chkSeleccionarArts.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarArts.TabIndex = 11
        Me.chkSeleccionarArts.Text = "Seleccionar Todo"
        Me.chkSeleccionarArts.UseVisualStyleBackColor = True
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(547, 18)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(40, 13)
        Me.lblFecha.TabIndex = 10
        Me.lblFecha.Text = "Fecha:"
        '
        'dttFecha
        '
        Me.dttFecha.Location = New System.Drawing.Point(597, 14)
        Me.dttFecha.Name = "dttFecha"
        Me.dttFecha.Size = New System.Drawing.Size(200, 20)
        Me.dttFecha.TabIndex = 9
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(12, 18)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(36, 13)
        Me.lblNave.TabIndex = 7
        Me.lblNave.Text = "Nave:"
        '
        'cmbNaves
        '
        Me.cmbNaves.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbNaves.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbNaves.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.Location = New System.Drawing.Point(61, 14)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(288, 21)
        Me.cmbNaves.TabIndex = 8
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdProductosDisponibles)
        Me.Panel2.Controls.Add(Me.pnlPasarArticulos)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 116)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(597, 433)
        Me.Panel2.TabIndex = 17
        '
        'grdProductosDisponibles
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProductosDisponibles.DisplayLayout.Appearance = Appearance1
        Me.grdProductosDisponibles.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdProductosDisponibles.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdProductosDisponibles.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProductosDisponibles.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdProductosDisponibles.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProductosDisponibles.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdProductosDisponibles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProductosDisponibles.Location = New System.Drawing.Point(0, 0)
        Me.grdProductosDisponibles.Name = "grdProductosDisponibles"
        Me.grdProductosDisponibles.Size = New System.Drawing.Size(571, 433)
        Me.grdProductosDisponibles.TabIndex = 21
        '
        'pnlPasarArticulos
        '
        Me.pnlPasarArticulos.Controls.Add(Me.btnAgregarColeccion)
        Me.pnlPasarArticulos.Controls.Add(Me.btnQuitarColeccion)
        Me.pnlPasarArticulos.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlPasarArticulos.Location = New System.Drawing.Point(571, 0)
        Me.pnlPasarArticulos.Name = "pnlPasarArticulos"
        Me.pnlPasarArticulos.Size = New System.Drawing.Size(26, 433)
        Me.pnlPasarArticulos.TabIndex = 30
        '
        'btnAgregarColeccion
        '
        Me.btnAgregarColeccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregarColeccion.Location = New System.Drawing.Point(2, 8)
        Me.btnAgregarColeccion.Name = "btnAgregarColeccion"
        Me.btnAgregarColeccion.Size = New System.Drawing.Size(21, 23)
        Me.btnAgregarColeccion.TabIndex = 21
        Me.btnAgregarColeccion.Text = ">"
        Me.btnAgregarColeccion.UseVisualStyleBackColor = True
        '
        'btnQuitarColeccion
        '
        Me.btnQuitarColeccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuitarColeccion.Location = New System.Drawing.Point(2, 41)
        Me.btnQuitarColeccion.Name = "btnQuitarColeccion"
        Me.btnQuitarColeccion.Size = New System.Drawing.Size(21, 23)
        Me.btnQuitarColeccion.TabIndex = 22
        Me.btnQuitarColeccion.Text = "<"
        Me.btnQuitarColeccion.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(817, 10)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 21
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(811, 43)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 20
        Me.lblGuardar.Text = "Guardar" & Global.Microsoft.VisualBasic.ChrW(13)
        '
        'grdProductosNuevos
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProductosNuevos.DisplayLayout.Appearance = Appearance3
        Me.grdProductosNuevos.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdProductosNuevos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdProductosNuevos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProductosNuevos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdProductosNuevos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProductosNuevos.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdProductosNuevos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProductosNuevos.Location = New System.Drawing.Point(597, 116)
        Me.grdProductosNuevos.Name = "grdProductosNuevos"
        Me.grdProductosNuevos.Size = New System.Drawing.Size(597, 433)
        Me.grdProductosNuevos.TabIndex = 22
        '
        'frmProductosNuevos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1194, 609)
        Me.Controls.Add(Me.grdProductosNuevos)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.grbNaves)
        Me.Controls.Add(Me.pnlExtado)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmProductosNuevos"
        Me.Text = "Productos Nuevos"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExtado.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbNaves.ResumeLayout(False)
        Me.grbNaves.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdProductosDisponibles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPasarArticulos.ResumeLayout(False)
        CType(Me.grdProductosNuevos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblListaNaves As System.Windows.Forms.Label
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents lblExportarExcel As System.Windows.Forms.Label
    Friend WithEvents pnlExtado As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents grbNaves As System.Windows.Forms.GroupBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grdProductosDisponibles As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlPasarArticulos As System.Windows.Forms.Panel
    Friend WithEvents btnAgregarColeccion As System.Windows.Forms.Button
    Friend WithEvents btnQuitarColeccion As System.Windows.Forms.Button
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents dttFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkSeleccionarProdsNvs As System.Windows.Forms.CheckBox
    Friend WithEvents chkSeleccionarArts As System.Windows.Forms.CheckBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents grdProductosNuevos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents exportExcelDetalle As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
End Class
