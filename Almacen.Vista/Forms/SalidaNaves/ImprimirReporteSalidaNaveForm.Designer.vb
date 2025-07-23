<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImprimirReporteSalidaNaveForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImprimirReporteSalidaNaveForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.grbDias = New System.Windows.Forms.GroupBox()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.DateStart = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaFin = New System.Windows.Forms.Label()
        Me.dateFin = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.pnlCampos = New System.Windows.Forms.Panel()
        Me.grdListaSalidas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbDias.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlCampos.SuspendLayout()
        CType(Me.grdListaSalidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbDias
        '
        Me.grbDias.Controls.Add(Me.cmbNaves)
        Me.grbDias.Controls.Add(Me.lblNave)
        Me.grbDias.Controls.Add(Me.Label1)
        Me.grbDias.Controls.Add(Me.lblLimpiar)
        Me.grbDias.Controls.Add(Me.btnLimpiar)
        Me.grbDias.Controls.Add(Me.btnBuscar)
        Me.grbDias.Controls.Add(Me.DateStart)
        Me.grbDias.Controls.Add(Me.lblFechaFin)
        Me.grbDias.Controls.Add(Me.dateFin)
        Me.grbDias.Controls.Add(Me.lblFechaInicio)
        Me.grbDias.Location = New System.Drawing.Point(6, 24)
        Me.grbDias.Name = "grbDias"
        Me.grbDias.Size = New System.Drawing.Size(641, 80)
        Me.grbDias.TabIndex = 29
        Me.grbDias.TabStop = False
        '
        'cmbNaves
        '
        Me.cmbNaves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.ItemHeight = 13
        Me.cmbNaves.Location = New System.Drawing.Point(96, 47)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(164, 21)
        Me.cmbNaves.TabIndex = 6
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(25, 50)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(37, 13)
        Me.lblNave.TabIndex = 84
        Me.lblNave.Text = "Nave*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(545, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(595, 52)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 32
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(598, 18)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 34)
        Me.btnLimpiar.TabIndex = 7
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(548, 18)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 34)
        Me.btnBuscar.TabIndex = 6
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'DateStart
        '
        Me.DateStart.CustomFormat = "yyyy/MM/dd"
        Me.DateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateStart.Location = New System.Drawing.Point(96, 18)
        Me.DateStart.Name = "DateStart"
        Me.DateStart.Size = New System.Drawing.Size(92, 20)
        Me.DateStart.TabIndex = 3
        '
        'lblFechaFin
        '
        Me.lblFechaFin.AutoSize = True
        Me.lblFechaFin.ForeColor = System.Drawing.Color.Black
        Me.lblFechaFin.Location = New System.Drawing.Point(235, 21)
        Me.lblFechaFin.Name = "lblFechaFin"
        Me.lblFechaFin.Size = New System.Drawing.Size(58, 13)
        Me.lblFechaFin.TabIndex = 26
        Me.lblFechaFin.Text = "Fecha Fin*"
        '
        'dateFin
        '
        Me.dateFin.CustomFormat = "yyyy/MM/dd"
        Me.dateFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateFin.Location = New System.Drawing.Point(295, 18)
        Me.dateFin.Name = "dateFin"
        Me.dateFin.Size = New System.Drawing.Size(92, 20)
        Me.dateFin.TabIndex = 4
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.ForeColor = System.Drawing.Color.Black
        Me.lblFechaInicio.Location = New System.Drawing.Point(25, 21)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(69, 13)
        Me.lblFechaInicio.TabIndex = 25
        Me.lblFechaInicio.Text = "Fecha Inicio*"
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlTitulo)
        Me.pnlCabecera.Controls.Add(Me.imgLogo)
        Me.pnlCabecera.Controls.Add(Me.btnMostrar)
        Me.pnlCabecera.Controls.Add(Me.lblBuscar)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(650, 60)
        Me.pnlCabecera.TabIndex = 28
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(370, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(210, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(70, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(134, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Salida de Lotes"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(580, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'btnMostrar
        '
        Me.btnMostrar.BackgroundImage = Global.Almacen.Vista.My.Resources.Resources.imprimir_32
        Me.btnMostrar.Location = New System.Drawing.Point(21, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 1
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(17, 42)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 32
        Me.lblBuscar.Text = "Imprimir"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.BackColor = System.Drawing.Color.White
        Me.pnlAcciones.Controls.Add(Me.lblAceptar)
        Me.pnlAcciones.Controls.Add(Me.btnAceptar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 401)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(650, 60)
        Me.pnlAcciones.TabIndex = 30
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(595, 41)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(44, 13)
        Me.lblAceptar.TabIndex = 64
        Me.lblAceptar.Text = "Aceptar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Almacen.Vista.My.Resources.Resources.aceptar_321
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(602, 6)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(620, 4)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(22, 22)
        Me.btnAbajo.TabIndex = 2
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(593, 4)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(22, 22)
        Me.btnArriba.TabIndex = 1
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'pnlCampos
        '
        Me.pnlCampos.Controls.Add(Me.btnArriba)
        Me.pnlCampos.Controls.Add(Me.btnAbajo)
        Me.pnlCampos.Controls.Add(Me.grbDias)
        Me.pnlCampos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCampos.Location = New System.Drawing.Point(0, 60)
        Me.pnlCampos.Name = "pnlCampos"
        Me.pnlCampos.Size = New System.Drawing.Size(650, 111)
        Me.pnlCampos.TabIndex = 32
        '
        'grdListaSalidas
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaSalidas.DisplayLayout.Appearance = Appearance1
        Me.grdListaSalidas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdListaSalidas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdListaSalidas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdListaSalidas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaSalidas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaSalidas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdListaSalidas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListaSalidas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdListaSalidas.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListaSalidas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaSalidas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaSalidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdListaSalidas.Location = New System.Drawing.Point(0, 171)
        Me.grdListaSalidas.Name = "grdListaSalidas"
        Me.grdListaSalidas.Size = New System.Drawing.Size(650, 230)
        Me.grdListaSalidas.TabIndex = 8
        '
        'ImprimirReporteSalidaNaveForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(650, 461)
        Me.Controls.Add(Me.grdListaSalidas)
        Me.Controls.Add(Me.pnlCampos)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.pnlCabecera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "ImprimirReporteSalidaNaveForm"
        Me.Text = "Salida de Lotes"
        Me.grbDias.ResumeLayout(False)
        Me.grbDias.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlCampos.ResumeLayout(False)
        CType(Me.grdListaSalidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbDias As System.Windows.Forms.GroupBox
    Friend WithEvents DateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaFin As System.Windows.Forms.Label
    Friend WithEvents dateFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents pnlCampos As System.Windows.Forms.Panel
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents grdListaSalidas As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
