<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenamientoRankingSimulacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdenamientoRankingSimulacion))
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdClientesMovimiento = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnPasar = New System.Windows.Forms.Button()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.grdClientesTodos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnReordenar = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGuardarOrden = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblAccionRegresar = New System.Windows.Forms.Label()
        Me.grpBotones = New System.Windows.Forms.GroupBox()
        Me.cmbClasificacion = New System.Windows.Forms.ComboBox()
        Me.lblClasificación = New System.Windows.Forms.Label()
        Me.lblIdSimulacion = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblNombreSimulacion = New System.Windows.Forms.Label()
        Me.chkTodoClientesTodos = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.grdOrdenClasificacion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmbSimulaciones = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnCerrarDos = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdClientesMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.grdClientesTodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.grpBotones.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdOrdenClasificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1184, 59)
        Me.pnlEncabezado.TabIndex = 1
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(582, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(602, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(222, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(312, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Ordenamiento Clasificación y Ranking"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 59)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1184, 527)
        Me.TabControl1.TabIndex = 84
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.pnlPie)
        Me.TabPage1.Controls.Add(Me.grpBotones)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1176, 501)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Configuración Actual"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdClientesMovimiento)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Splitter1)
        Me.Panel1.Controls.Add(Me.grdClientesTodos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1170, 373)
        Me.Panel1.TabIndex = 68
        '
        'grdClientesMovimiento
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientesMovimiento.DisplayLayout.Appearance = Appearance1
        Me.grdClientesMovimiento.DisplayLayout.GroupByBox.Hidden = True
        Me.grdClientesMovimiento.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdClientesMovimiento.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdClientesMovimiento.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClientesMovimiento.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdClientesMovimiento.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.grdClientesMovimiento.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClientesMovimiento.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdClientesMovimiento.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientesMovimiento.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdClientesMovimiento.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClientesMovimiento.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClientesMovimiento.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None
        Me.grdClientesMovimiento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClientesMovimiento.Location = New System.Drawing.Point(602, 0)
        Me.grdClientesMovimiento.Name = "grdClientesMovimiento"
        Me.grdClientesMovimiento.Size = New System.Drawing.Size(568, 373)
        Me.grdClientesMovimiento.TabIndex = 64
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnPasar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(572, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(30, 373)
        Me.Panel4.TabIndex = 61
        '
        'btnPasar
        '
        Me.btnPasar.AccessibleName = "0"
        Me.btnPasar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPasar.Location = New System.Drawing.Point(4, 162)
        Me.btnPasar.Name = "btnPasar"
        Me.btnPasar.Size = New System.Drawing.Size(23, 30)
        Me.btnPasar.TabIndex = 91
        Me.btnPasar.Text = ">>"
        Me.btnPasar.UseVisualStyleBackColor = True
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.Silver
        Me.Splitter1.Location = New System.Drawing.Point(568, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(4, 373)
        Me.Splitter1.TabIndex = 69
        Me.Splitter1.TabStop = False
        '
        'grdClientesTodos
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientesTodos.DisplayLayout.Appearance = Appearance3
        Me.grdClientesTodos.DisplayLayout.GroupByBox.Hidden = True
        Me.grdClientesTodos.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdClientesTodos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdClientesTodos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClientesTodos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdClientesTodos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.grdClientesTodos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClientesTodos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdClientesTodos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientesTodos.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdClientesTodos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClientesTodos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClientesTodos.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None
        Me.grdClientesTodos.Dock = System.Windows.Forms.DockStyle.Left
        Me.grdClientesTodos.Location = New System.Drawing.Point(0, 0)
        Me.grdClientesTodos.Name = "grdClientesTodos"
        Me.grdClientesTodos.Size = New System.Drawing.Size(568, 373)
        Me.grdClientesTodos.TabIndex = 63
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.btnReordenar)
        Me.pnlPie.Controls.Add(Me.Label9)
        Me.pnlPie.Controls.Add(Me.pnlBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(3, 438)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1170, 60)
        Me.pnlPie.TabIndex = 69
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(74, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 39)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Reordena la clasificación" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " y el ranking de todos " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "los clientes."
        '
        'btnReordenar
        '
        Me.btnReordenar.Image = Global.Programacion.Vista.My.Resources.Resources.reasignar
        Me.btnReordenar.Location = New System.Drawing.Point(23, 6)
        Me.btnReordenar.Name = "btnReordenar"
        Me.btnReordenar.Size = New System.Drawing.Size(32, 32)
        Me.btnReordenar.TabIndex = 44
        Me.btnReordenar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label9.Location = New System.Drawing.Point(11, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "Reordenar"
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.Label6)
        Me.pnlBotones.Controls.Add(Me.Label3)
        Me.pnlBotones.Controls.Add(Me.btnGuardarOrden)
        Me.pnlBotones.Controls.Add(Me.btnCerrar)
        Me.pnlBotones.Controls.Add(Me.lblAccionRegresar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(807, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(363, 60)
        Me.pnlBotones.TabIndex = 42
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(117, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 39)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "Guarda el ordenamiento " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "que se configure en" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "la tabla de la derecha."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(246, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 26)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Guardar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Orden"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnGuardarOrden
        '
        Me.btnGuardarOrden.Image = Global.Programacion.Vista.My.Resources.Resources.reasignar
        Me.btnGuardarOrden.Location = New System.Drawing.Point(252, 3)
        Me.btnGuardarOrden.Name = "btnGuardarOrden"
        Me.btnGuardarOrden.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarOrden.TabIndex = 46
        Me.btnGuardarOrden.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(311, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 7
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblAccionRegresar
        '
        Me.lblAccionRegresar.AutoSize = True
        Me.lblAccionRegresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccionRegresar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAccionRegresar.Location = New System.Drawing.Point(310, 38)
        Me.lblAccionRegresar.Name = "lblAccionRegresar"
        Me.lblAccionRegresar.Size = New System.Drawing.Size(35, 13)
        Me.lblAccionRegresar.TabIndex = 39
        Me.lblAccionRegresar.Text = "Cerrar"
        '
        'grpBotones
        '
        Me.grpBotones.BackColor = System.Drawing.Color.Transparent
        Me.grpBotones.Controls.Add(Me.cmbClasificacion)
        Me.grpBotones.Controls.Add(Me.lblClasificación)
        Me.grpBotones.Controls.Add(Me.lblIdSimulacion)
        Me.grpBotones.Controls.Add(Me.Label10)
        Me.grpBotones.Controls.Add(Me.lblNombreSimulacion)
        Me.grpBotones.Controls.Add(Me.chkTodoClientesTodos)
        Me.grpBotones.Controls.Add(Me.Panel3)
        Me.grpBotones.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBotones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grpBotones.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grpBotones.Location = New System.Drawing.Point(3, 3)
        Me.grpBotones.Name = "grpBotones"
        Me.grpBotones.Size = New System.Drawing.Size(1170, 62)
        Me.grpBotones.TabIndex = 65
        Me.grpBotones.TabStop = False
        '
        'cmbClasificacion
        '
        Me.cmbClasificacion.FormattingEnabled = True
        Me.cmbClasificacion.Location = New System.Drawing.Point(82, 11)
        Me.cmbClasificacion.Name = "cmbClasificacion"
        Me.cmbClasificacion.Size = New System.Drawing.Size(82, 21)
        Me.cmbClasificacion.TabIndex = 98
        '
        'lblClasificación
        '
        Me.lblClasificación.AutoSize = True
        Me.lblClasificación.Location = New System.Drawing.Point(6, 15)
        Me.lblClasificación.Name = "lblClasificación"
        Me.lblClasificación.Size = New System.Drawing.Size(72, 13)
        Me.lblClasificación.TabIndex = 99
        Me.lblClasificación.Text = "Clasificación: "
        '
        'lblIdSimulacion
        '
        Me.lblIdSimulacion.AutoSize = True
        Me.lblIdSimulacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdSimulacion.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblIdSimulacion.Location = New System.Drawing.Point(604, 37)
        Me.lblIdSimulacion.Name = "lblIdSimulacion"
        Me.lblIdSimulacion.Size = New System.Drawing.Size(15, 15)
        Me.lblIdSimulacion.TabIndex = 97
        Me.lblIdSimulacion.Text = "0"
        Me.lblIdSimulacion.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label10.Location = New System.Drawing.Point(197, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 15)
        Me.Label10.TabIndex = 96
        Me.Label10.Text = "Simulación:"
        '
        'lblNombreSimulacion
        '
        Me.lblNombreSimulacion.AutoSize = True
        Me.lblNombreSimulacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreSimulacion.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNombreSimulacion.Location = New System.Drawing.Point(298, 39)
        Me.lblNombreSimulacion.Name = "lblNombreSimulacion"
        Me.lblNombreSimulacion.Size = New System.Drawing.Size(22, 15)
        Me.lblNombreSimulacion.TabIndex = 95
        Me.lblNombreSimulacion.Text = "---"
        '
        'chkTodoClientesTodos
        '
        Me.chkTodoClientesTodos.AutoSize = True
        Me.chkTodoClientesTodos.Location = New System.Drawing.Point(9, 38)
        Me.chkTodoClientesTodos.Name = "chkTodoClientesTodos"
        Me.chkTodoClientesTodos.Size = New System.Drawing.Size(106, 17)
        Me.chkTodoClientesTodos.TabIndex = 83
        Me.chkTodoClientesTodos.Text = "Seleccionar todo"
        Me.chkTodoClientesTodos.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnArriba)
        Me.Panel3.Controls.Add(Me.btnAbajo)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(1088, 16)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(79, 43)
        Me.Panel3.TabIndex = 38
        Me.Panel3.Visible = False
        '
        'btnArriba
        '
        Me.btnArriba.AccessibleName = "0"
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(15, 1)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 3
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.AccessibleName = "0"
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(45, 1)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 4
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grdOrdenClasificacion)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1176, 501)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Ordenamiento Simulaciones Anteriores"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grdOrdenClasificacion
        '
        Me.grdOrdenClasificacion.AllowDrop = True
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOrdenClasificacion.DisplayLayout.Appearance = Appearance5
        Me.grdOrdenClasificacion.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdOrdenClasificacion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdOrdenClasificacion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdOrdenClasificacion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdOrdenClasificacion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdOrdenClasificacion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdOrdenClasificacion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOrdenClasificacion.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdOrdenClasificacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdOrdenClasificacion.Location = New System.Drawing.Point(3, 50)
        Me.grdOrdenClasificacion.Name = "grdOrdenClasificacion"
        Me.grdOrdenClasificacion.Size = New System.Drawing.Size(1170, 388)
        Me.grdOrdenClasificacion.TabIndex = 12
        Me.grdOrdenClasificacion.Tag = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel6)
        Me.GroupBox1.Controls.Add(Me.cmbSimulaciones)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1170, 47)
        Me.GroupBox1.TabIndex = 71
        Me.GroupBox1.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Button1)
        Me.Panel6.Controls.Add(Me.Button2)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(1088, 16)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(79, 28)
        Me.Panel6.TabIndex = 38
        Me.Panel6.Visible = False
        '
        'Button1
        '
        Me.Button1.AccessibleName = "0"
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(15, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 3
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.AccessibleName = "0"
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(45, 1)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(20, 20)
        Me.Button2.TabIndex = 4
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cmbSimulaciones
        '
        Me.cmbSimulaciones.FormattingEnabled = True
        Me.cmbSimulaciones.Location = New System.Drawing.Point(80, 16)
        Me.cmbSimulaciones.Name = "cmbSimulaciones"
        Me.cmbSimulaciones.Size = New System.Drawing.Size(305, 21)
        Me.cmbSimulaciones.TabIndex = 80
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Simulación: "
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 438)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1170, 60)
        Me.Panel2.TabIndex = 70
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnCerrarDos)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(807, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(363, 60)
        Me.Panel5.TabIndex = 42
        '
        'btnCerrarDos
        '
        Me.btnCerrarDos.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrarDos.Location = New System.Drawing.Point(308, 6)
        Me.btnCerrarDos.Name = "btnCerrarDos"
        Me.btnCerrarDos.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrarDos.TabIndex = 7
        Me.btnCerrarDos.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.Location = New System.Drawing.Point(307, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Cerrar"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(540, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'frmOrdenamientoRankingSimulacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1184, 586)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmOrdenamientoRankingSimulacion"
        Me.Text = "Ordenamiento Clasificación y Ranking"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdClientesMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdClientesTodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.grpBotones.ResumeLayout(False)
        Me.grpBotones.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grdOrdenClasificacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnPasar As System.Windows.Forms.Button
    Friend WithEvents grpBotones As System.Windows.Forms.GroupBox
    Friend WithEvents chkTodoClientesTodos As System.Windows.Forms.CheckBox
    Friend WithEvents cmbSimulaciones As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents grdClientesMovimiento As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdOrdenClasificacion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents btnReordenar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnGuardarOrden As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblAccionRegresar As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnCerrarDos As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblNombreSimulacion As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lblIdSimulacion As System.Windows.Forms.Label
    Friend WithEvents grdClientesTodos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmbClasificacion As System.Windows.Forms.ComboBox
    Friend WithEvents lblClasificación As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
