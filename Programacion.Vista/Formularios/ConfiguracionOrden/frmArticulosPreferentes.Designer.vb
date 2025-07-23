<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArticulosPreferentes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArticulosPreferentes))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnOrdenar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.lblAccionRegresar = New System.Windows.Forms.Label()
        Me.grpBotones = New System.Windows.Forms.GroupBox()
        Me.chkSeleccionarTodoPreferentes = New System.Windows.Forms.CheckBox()
        Me.chkSeleccionaTodo = New System.Windows.Forms.CheckBox()
        Me.lblIdSimulacion = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblNombreSimulacion = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.grdProductosPreferentes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnPasar = New System.Windows.Forms.Button()
        Me.grdProductosTodos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grdArticulosPreferentesSimulaciones = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grpSimulacionesAnt = New System.Windows.Forms.GroupBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnUPSM = New System.Windows.Forms.Button()
        Me.btnDownSM = New System.Windows.Forms.Button()
        Me.cmbSimulaciones = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlAnteriores = New System.Windows.Forms.Panel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Splitter2 = New System.Windows.Forms.Splitter()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.grpBotones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdProductosPreferentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.grdProductosTodos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdArticulosPreferentesSimulaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSimulacionesAnt.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlAnteriores.SuspendLayout()
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
        Me.pnlHeader.Size = New System.Drawing.Size(1184, 60)
        Me.pnlHeader.TabIndex = 38
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Controls.Add(Me.lblTitulo)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(885, 0)
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
        Me.lblTitulo.Location = New System.Drawing.Point(52, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(178, 20)
        Me.lblTitulo.TabIndex = 9
        Me.lblTitulo.Text = "Artículos Preferentes"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.pnlBotones)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 520)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1184, 60)
        Me.Panel3.TabIndex = 46
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnOrdenar)
        Me.pnlBotones.Controls.Add(Me.Label2)
        Me.pnlBotones.Controls.Add(Me.btnRegresar)
        Me.pnlBotones.Controls.Add(Me.lblAccionRegresar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(821, 0)
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
        'grpBotones
        '
        Me.grpBotones.BackColor = System.Drawing.Color.AliceBlue
        Me.grpBotones.Controls.Add(Me.chkSeleccionarTodoPreferentes)
        Me.grpBotones.Controls.Add(Me.chkSeleccionaTodo)
        Me.grpBotones.Controls.Add(Me.lblIdSimulacion)
        Me.grpBotones.Controls.Add(Me.Label10)
        Me.grpBotones.Controls.Add(Me.lblNombreSimulacion)
        Me.grpBotones.Controls.Add(Me.Panel1)
        Me.grpBotones.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBotones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grpBotones.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grpBotones.Location = New System.Drawing.Point(0, 60)
        Me.grpBotones.Name = "grpBotones"
        Me.grpBotones.Size = New System.Drawing.Size(1184, 41)
        Me.grpBotones.TabIndex = 47
        Me.grpBotones.TabStop = False
        '
        'chkSeleccionarTodoPreferentes
        '
        Me.chkSeleccionarTodoPreferentes.AutoSize = True
        Me.chkSeleccionarTodoPreferentes.Location = New System.Drawing.Point(613, 18)
        Me.chkSeleccionarTodoPreferentes.Name = "chkSeleccionarTodoPreferentes"
        Me.chkSeleccionarTodoPreferentes.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarTodoPreferentes.TabIndex = 101
        Me.chkSeleccionarTodoPreferentes.Text = "Seleccionar Todo"
        Me.chkSeleccionarTodoPreferentes.UseVisualStyleBackColor = True
        '
        'chkSeleccionaTodo
        '
        Me.chkSeleccionaTodo.AutoSize = True
        Me.chkSeleccionaTodo.Location = New System.Drawing.Point(6, 18)
        Me.chkSeleccionaTodo.Name = "chkSeleccionaTodo"
        Me.chkSeleccionaTodo.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionaTodo.TabIndex = 100
        Me.chkSeleccionaTodo.Text = "Seleccionar Todo"
        Me.chkSeleccionaTodo.UseVisualStyleBackColor = True
        '
        'lblIdSimulacion
        '
        Me.lblIdSimulacion.AutoSize = True
        Me.lblIdSimulacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdSimulacion.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblIdSimulacion.Location = New System.Drawing.Point(131, 19)
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
        Me.Label10.Location = New System.Drawing.Point(147, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(126, 15)
        Me.Label10.TabIndex = 98
        Me.Label10.Text = "Simulación Actual:"
        '
        'lblNombreSimulacion
        '
        Me.lblNombreSimulacion.AutoSize = True
        Me.lblNombreSimulacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreSimulacion.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNombreSimulacion.Location = New System.Drawing.Point(280, 19)
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
        Me.Panel1.Location = New System.Drawing.Point(1102, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(79, 22)
        Me.Panel1.TabIndex = 38
        Me.Panel1.Visible = False
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
        'grdProductosPreferentes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProductosPreferentes.DisplayLayout.Appearance = Appearance1
        Me.grdProductosPreferentes.DisplayLayout.GroupByBox.Hidden = True
        Me.grdProductosPreferentes.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdProductosPreferentes.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdProductosPreferentes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProductosPreferentes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdProductosPreferentes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.grdProductosPreferentes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdProductosPreferentes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProductosPreferentes.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdProductosPreferentes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdProductosPreferentes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProductosPreferentes.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None
        Me.grdProductosPreferentes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProductosPreferentes.Location = New System.Drawing.Point(610, 101)
        Me.grdProductosPreferentes.Name = "grdProductosPreferentes"
        Me.grdProductosPreferentes.Size = New System.Drawing.Size(574, 239)
        Me.grdProductosPreferentes.TabIndex = 67
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnQuitar)
        Me.Panel2.Controls.Add(Me.btnPasar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(580, 101)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(30, 419)
        Me.Panel2.TabIndex = 66
        '
        'btnQuitar
        '
        Me.btnQuitar.AccessibleName = "0"
        Me.btnQuitar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitar.Location = New System.Drawing.Point(4, 184)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(23, 30)
        Me.btnQuitar.TabIndex = 92
        Me.btnQuitar.Text = "<<"
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'btnPasar
        '
        Me.btnPasar.AccessibleName = "0"
        Me.btnPasar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPasar.Location = New System.Drawing.Point(4, 138)
        Me.btnPasar.Name = "btnPasar"
        Me.btnPasar.Size = New System.Drawing.Size(23, 30)
        Me.btnPasar.TabIndex = 91
        Me.btnPasar.Text = ">>"
        Me.btnPasar.UseVisualStyleBackColor = True
        '
        'grdProductosTodos
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProductosTodos.DisplayLayout.Appearance = Appearance3
        Me.grdProductosTodos.DisplayLayout.GroupByBox.Hidden = True
        Me.grdProductosTodos.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdProductosTodos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdProductosTodos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProductosTodos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdProductosTodos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.grdProductosTodos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdProductosTodos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProductosTodos.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdProductosTodos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdProductosTodos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProductosTodos.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None
        Me.grdProductosTodos.Dock = System.Windows.Forms.DockStyle.Left
        Me.grdProductosTodos.Location = New System.Drawing.Point(0, 101)
        Me.grdProductosTodos.Name = "grdProductosTodos"
        Me.grdProductosTodos.Size = New System.Drawing.Size(577, 419)
        Me.grdProductosTodos.TabIndex = 65
        '
        'grdArticulosPreferentesSimulaciones
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdArticulosPreferentesSimulaciones.DisplayLayout.Appearance = Appearance5
        Me.grdArticulosPreferentesSimulaciones.DisplayLayout.GroupByBox.Hidden = True
        Me.grdArticulosPreferentesSimulaciones.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdArticulosPreferentesSimulaciones.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdArticulosPreferentesSimulaciones.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdArticulosPreferentesSimulaciones.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdArticulosPreferentesSimulaciones.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.grdArticulosPreferentesSimulaciones.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdArticulosPreferentesSimulaciones.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdArticulosPreferentesSimulaciones.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdArticulosPreferentesSimulaciones.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdArticulosPreferentesSimulaciones.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdArticulosPreferentesSimulaciones.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None
        Me.grdArticulosPreferentesSimulaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdArticulosPreferentesSimulaciones.Location = New System.Drawing.Point(0, 41)
        Me.grdArticulosPreferentesSimulaciones.Name = "grdArticulosPreferentesSimulaciones"
        Me.grdArticulosPreferentesSimulaciones.Size = New System.Drawing.Size(574, 136)
        Me.grdArticulosPreferentesSimulaciones.TabIndex = 73
        Me.grdArticulosPreferentesSimulaciones.Text = "Ordenamiento Simulaciones Anteriore"
        '
        'grpSimulacionesAnt
        '
        Me.grpSimulacionesAnt.BackColor = System.Drawing.Color.Transparent
        Me.grpSimulacionesAnt.Controls.Add(Me.Panel6)
        Me.grpSimulacionesAnt.Controls.Add(Me.cmbSimulaciones)
        Me.grpSimulacionesAnt.Controls.Add(Me.Label1)
        Me.grpSimulacionesAnt.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpSimulacionesAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grpSimulacionesAnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grpSimulacionesAnt.Location = New System.Drawing.Point(0, 0)
        Me.grpSimulacionesAnt.Name = "grpSimulacionesAnt"
        Me.grpSimulacionesAnt.Size = New System.Drawing.Size(574, 41)
        Me.grpSimulacionesAnt.TabIndex = 72
        Me.grpSimulacionesAnt.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnUPSM)
        Me.Panel6.Controls.Add(Me.btnDownSM)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(492, 16)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(79, 22)
        Me.Panel6.TabIndex = 38
        Me.Panel6.Visible = False
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
        'cmbSimulaciones
        '
        Me.cmbSimulaciones.FormattingEnabled = True
        Me.cmbSimulaciones.Location = New System.Drawing.Point(81, 13)
        Me.cmbSimulaciones.Name = "cmbSimulaciones"
        Me.cmbSimulaciones.Size = New System.Drawing.Size(305, 21)
        Me.cmbSimulaciones.TabIndex = 80
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Simulación: "
        '
        'pnlAnteriores
        '
        Me.pnlAnteriores.Controls.Add(Me.grdArticulosPreferentesSimulaciones)
        Me.pnlAnteriores.Controls.Add(Me.grpSimulacionesAnt)
        Me.pnlAnteriores.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAnteriores.Location = New System.Drawing.Point(610, 343)
        Me.pnlAnteriores.Name = "pnlAnteriores"
        Me.pnlAnteriores.Size = New System.Drawing.Size(574, 177)
        Me.pnlAnteriores.TabIndex = 74
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.Silver
        Me.Splitter1.Location = New System.Drawing.Point(577, 101)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 419)
        Me.Splitter1.TabIndex = 75
        Me.Splitter1.TabStop = False
        '
        'Splitter2
        '
        Me.Splitter2.BackColor = System.Drawing.Color.Silver
        Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter2.Location = New System.Drawing.Point(610, 340)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(574, 3)
        Me.Splitter2.TabIndex = 76
        Me.Splitter2.TabStop = False
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
        'frmArticulosPreferentes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1184, 580)
        Me.Controls.Add(Me.grdProductosPreferentes)
        Me.Controls.Add(Me.Splitter2)
        Me.Controls.Add(Me.pnlAnteriores)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.grdProductosTodos)
        Me.Controls.Add(Me.grpBotones)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmArticulosPreferentes"
        Me.Text = "Artículos Preferentes"
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.grpBotones.ResumeLayout(False)
        Me.grpBotones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdProductosPreferentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdProductosTodos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdArticulosPreferentesSimulaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSimulacionesAnt.ResumeLayout(False)
        Me.grpSimulacionesAnt.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.pnlAnteriores.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents lblAccionRegresar As System.Windows.Forms.Label
    Friend WithEvents grpBotones As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblNombreSimulacion As System.Windows.Forms.Label
    Friend WithEvents lblIdSimulacion As System.Windows.Forms.Label
    Friend WithEvents grdProductosPreferentes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents btnPasar As System.Windows.Forms.Button
    Friend WithEvents grdProductosTodos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grpSimulacionesAnt As System.Windows.Forms.GroupBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents btnUPSM As System.Windows.Forms.Button
    Friend WithEvents btnDownSM As System.Windows.Forms.Button
    Friend WithEvents cmbSimulaciones As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdArticulosPreferentesSimulaciones As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnOrdenar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkSeleccionaTodo As System.Windows.Forms.CheckBox
    Friend WithEvents chkSeleccionarTodoPreferentes As System.Windows.Forms.CheckBox
    Friend WithEvents pnlAnteriores As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents PictureBox1 As PictureBox
End Class
