<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNavesOrden
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNavesOrden))
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnOrdenar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.lblAccionRegresar = New System.Windows.Forms.Label()
        Me.tbtContenedor = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.grdOrdenNavesActual = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grpBotones = New System.Windows.Forms.GroupBox()
        Me.lblIdSimulacion = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblNombreSimulacion = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.grdOrdenNavesAnt = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grpSimulacionesAnt = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbSimulaciones = New System.Windows.Forms.ComboBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnUPSM = New System.Windows.Forms.Button()
        Me.btnDownSM = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.tbtContenedor.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.grdOrdenNavesActual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBotones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdOrdenNavesAnt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSimulacionesAnt.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.Panel4)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(472, 60)
        Me.pnlHeader.TabIndex = 39
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Controls.Add(Me.lblTitulo)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(173, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(299, 60)
        Me.Panel4.TabIndex = 48
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(115, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(112, 20)
        Me.lblTitulo.TabIndex = 9
        Me.lblTitulo.Text = "Naves Orden"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.pnlBotones)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 520)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(472, 60)
        Me.Panel3.TabIndex = 47
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnOrdenar)
        Me.pnlBotones.Controls.Add(Me.Label2)
        Me.pnlBotones.Controls.Add(Me.btnRegresar)
        Me.pnlBotones.Controls.Add(Me.lblAccionRegresar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(109, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(363, 60)
        Me.pnlBotones.TabIndex = 41
        '
        'btnOrdenar
        '
        Me.btnOrdenar.Image = Global.Programacion.Vista.My.Resources.Resources.ordenar
        Me.btnOrdenar.Location = New System.Drawing.Point(246, 6)
        Me.btnOrdenar.Name = "btnOrdenar"
        Me.btnOrdenar.Size = New System.Drawing.Size(32, 32)
        Me.btnOrdenar.TabIndex = 50
        Me.btnOrdenar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(240, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Ordenar"
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnRegresar.Location = New System.Drawing.Point(311, 6)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(32, 32)
        Me.btnRegresar.TabIndex = 7
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'lblAccionRegresar
        '
        Me.lblAccionRegresar.AutoSize = True
        Me.lblAccionRegresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccionRegresar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAccionRegresar.Location = New System.Drawing.Point(310, 40)
        Me.lblAccionRegresar.Name = "lblAccionRegresar"
        Me.lblAccionRegresar.Size = New System.Drawing.Size(35, 13)
        Me.lblAccionRegresar.TabIndex = 39
        Me.lblAccionRegresar.Text = "Cerrar"
        '
        'tbtContenedor
        '
        Me.tbtContenedor.Controls.Add(Me.TabPage1)
        Me.tbtContenedor.Controls.Add(Me.TabPage2)
        Me.tbtContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbtContenedor.Location = New System.Drawing.Point(0, 60)
        Me.tbtContenedor.Name = "tbtContenedor"
        Me.tbtContenedor.SelectedIndex = 0
        Me.tbtContenedor.Size = New System.Drawing.Size(472, 460)
        Me.tbtContenedor.TabIndex = 102
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grdOrdenNavesActual)
        Me.TabPage1.Controls.Add(Me.grpBotones)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(464, 434)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Configuración Actual"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grdOrdenNavesActual
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOrdenNavesActual.DisplayLayout.Appearance = Appearance1
        Me.grdOrdenNavesActual.DisplayLayout.GroupByBox.Hidden = True
        Me.grdOrdenNavesActual.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdOrdenNavesActual.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdOrdenNavesActual.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdOrdenNavesActual.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdOrdenNavesActual.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.grdOrdenNavesActual.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdOrdenNavesActual.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOrdenNavesActual.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdOrdenNavesActual.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdOrdenNavesActual.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdOrdenNavesActual.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None
        Me.grdOrdenNavesActual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdOrdenNavesActual.Location = New System.Drawing.Point(3, 81)
        Me.grdOrdenNavesActual.Name = "grdOrdenNavesActual"
        Me.grdOrdenNavesActual.Size = New System.Drawing.Size(458, 350)
        Me.grdOrdenNavesActual.TabIndex = 65
        '
        'grpBotones
        '
        Me.grpBotones.BackColor = System.Drawing.Color.AliceBlue
        Me.grpBotones.Controls.Add(Me.lblIdSimulacion)
        Me.grpBotones.Controls.Add(Me.Label10)
        Me.grpBotones.Controls.Add(Me.lblNombreSimulacion)
        Me.grpBotones.Controls.Add(Me.Panel1)
        Me.grpBotones.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBotones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grpBotones.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grpBotones.Location = New System.Drawing.Point(3, 3)
        Me.grpBotones.Name = "grpBotones"
        Me.grpBotones.Size = New System.Drawing.Size(458, 78)
        Me.grpBotones.TabIndex = 47
        Me.grpBotones.TabStop = False
        '
        'lblIdSimulacion
        '
        Me.lblIdSimulacion.AutoSize = True
        Me.lblIdSimulacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdSimulacion.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblIdSimulacion.Location = New System.Drawing.Point(120, 19)
        Me.lblIdSimulacion.Name = "lblIdSimulacion"
        Me.lblIdSimulacion.Size = New System.Drawing.Size(15, 15)
        Me.lblIdSimulacion.TabIndex = 99
        Me.lblIdSimulacion.Text = "0"
        Me.lblIdSimulacion.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label10.Location = New System.Drawing.Point(6, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 30)
        Me.Label10.TabIndex = 98
        Me.Label10.Text = "Simulación" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Actual:"
        '
        'lblNombreSimulacion
        '
        Me.lblNombreSimulacion.AutoSize = True
        Me.lblNombreSimulacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreSimulacion.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNombreSimulacion.Location = New System.Drawing.Point(104, 55)
        Me.lblNombreSimulacion.Name = "lblNombreSimulacion"
        Me.lblNombreSimulacion.Size = New System.Drawing.Size(22, 15)
        Me.lblNombreSimulacion.TabIndex = 97
        Me.lblNombreSimulacion.Text = "---"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnArriba)
        Me.Panel1.Controls.Add(Me.btnAbajo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(376, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(79, 59)
        Me.Panel1.TabIndex = 38
        '
        'btnArriba
        '
        Me.btnArriba.AccessibleName = "0"
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(15, 0)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 3
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.AccessibleName = "0"
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(45, 0)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 4
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.AliceBlue
        Me.TabPage2.Controls.Add(Me.grdOrdenNavesAnt)
        Me.TabPage2.Controls.Add(Me.grpSimulacionesAnt)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(464, 434)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Orden Naves Anteriores"
        '
        'grdOrdenNavesAnt
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOrdenNavesAnt.DisplayLayout.Appearance = Appearance3
        Me.grdOrdenNavesAnt.DisplayLayout.GroupByBox.Hidden = True
        Me.grdOrdenNavesAnt.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdOrdenNavesAnt.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdOrdenNavesAnt.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdOrdenNavesAnt.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdOrdenNavesAnt.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.grdOrdenNavesAnt.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdOrdenNavesAnt.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOrdenNavesAnt.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdOrdenNavesAnt.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdOrdenNavesAnt.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdOrdenNavesAnt.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None
        Me.grdOrdenNavesAnt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdOrdenNavesAnt.Location = New System.Drawing.Point(3, 81)
        Me.grdOrdenNavesAnt.Name = "grdOrdenNavesAnt"
        Me.grdOrdenNavesAnt.Size = New System.Drawing.Size(458, 350)
        Me.grdOrdenNavesAnt.TabIndex = 73
        '
        'grpSimulacionesAnt
        '
        Me.grpSimulacionesAnt.BackColor = System.Drawing.Color.Transparent
        Me.grpSimulacionesAnt.Controls.Add(Me.Label1)
        Me.grpSimulacionesAnt.Controls.Add(Me.cmbSimulaciones)
        Me.grpSimulacionesAnt.Controls.Add(Me.Panel6)
        Me.grpSimulacionesAnt.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpSimulacionesAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grpSimulacionesAnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grpSimulacionesAnt.Location = New System.Drawing.Point(3, 3)
        Me.grpSimulacionesAnt.Name = "grpSimulacionesAnt"
        Me.grpSimulacionesAnt.Size = New System.Drawing.Size(458, 78)
        Me.grpSimulacionesAnt.TabIndex = 72
        Me.grpSimulacionesAnt.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Simulación: "
        '
        'cmbSimulaciones
        '
        Me.cmbSimulaciones.FormattingEnabled = True
        Me.cmbSimulaciones.Location = New System.Drawing.Point(78, 44)
        Me.cmbSimulaciones.Name = "cmbSimulaciones"
        Me.cmbSimulaciones.Size = New System.Drawing.Size(292, 21)
        Me.cmbSimulaciones.TabIndex = 80
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnUPSM)
        Me.Panel6.Controls.Add(Me.btnDownSM)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(376, 16)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(79, 59)
        Me.Panel6.TabIndex = 38
        '
        'btnUPSM
        '
        Me.btnUPSM.AccessibleName = "0"
        Me.btnUPSM.Image = CType(resources.GetObject("btnUPSM.Image"), System.Drawing.Image)
        Me.btnUPSM.Location = New System.Drawing.Point(15, 1)
        Me.btnUPSM.Name = "btnUPSM"
        Me.btnUPSM.Size = New System.Drawing.Size(20, 20)
        Me.btnUPSM.TabIndex = 3
        Me.btnUPSM.UseVisualStyleBackColor = True
        '
        'btnDownSM
        '
        Me.btnDownSM.AccessibleName = "0"
        Me.btnDownSM.Image = CType(resources.GetObject("btnDownSM.Image"), System.Drawing.Image)
        Me.btnDownSM.Location = New System.Drawing.Point(45, 1)
        Me.btnDownSM.Name = "btnDownSM"
        Me.btnDownSM.Size = New System.Drawing.Size(20, 20)
        Me.btnDownSM.TabIndex = 4
        Me.btnDownSM.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(237, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'frmNavesOrden
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(472, 580)
        Me.Controls.Add(Me.tbtContenedor)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmNavesOrden"
        Me.Text = "Naves Orden"
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.tbtContenedor.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.grdOrdenNavesActual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBotones.ResumeLayout(False)
        Me.grpBotones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grdOrdenNavesAnt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSimulacionesAnt.ResumeLayout(False)
        Me.grpSimulacionesAnt.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents btnOrdenar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents lblAccionRegresar As System.Windows.Forms.Label
    Friend WithEvents tbtContenedor As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents grdOrdenNavesActual As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grpBotones As System.Windows.Forms.GroupBox
    Friend WithEvents lblIdSimulacion As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblNombreSimulacion As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents grdOrdenNavesAnt As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grpSimulacionesAnt As System.Windows.Forms.GroupBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents btnUPSM As System.Windows.Forms.Button
    Friend WithEvents btnDownSM As System.Windows.Forms.Button
    Friend WithEvents cmbSimulaciones As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
