<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SeguimientoParesProyeccion_SoloConsultaForm
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
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SeguimientoParesProyeccion_SoloConsultaForm))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlListaCliente = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.grdApartado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.grdProduccion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.grdBloqueados = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.grdReproceso = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.grdClientesBloqueados = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.grdParesProgramadosProduccion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblAbreviaturas2 = New System.Windows.Forms.Label()
        Me.lblStEjecucion = New System.Windows.Forms.Label()
        Me.lblAbreviaturas1 = New System.Windows.Forms.Label()
        Me.pnlEstatusEnEjecucion = New System.Windows.Forms.Panel()
        Me.lblStParcialmenteConfirmado = New System.Windows.Forms.Label()
        Me.pnlEstatusParcialmenteConfirmado = New System.Windows.Forms.Panel()
        Me.lblStActivo = New System.Windows.Forms.Label()
        Me.pnlEstatusActivo = New System.Windows.Forms.Panel()
        Me.lblFechaUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblTextoUltimaDistribucion = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlMarcarTodo = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
        Me.cmsPriorizar = New System.Windows.Forms.ContextMenuStrip()
        Me.tsmiAsignarPrioridad = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlListaCliente.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.grdApartado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.grdBloqueados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.grdReproceso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.grdClientesBloqueados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        CType(Me.grdParesProgramadosProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlMarcarTodo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsPriorizar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlListaCliente)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(989, 445)
        Me.pnlContenedor.TabIndex = 7
        '
        'pnlListaCliente
        '
        Me.pnlListaCliente.Controls.Add(Me.TabControl1)
        Me.pnlListaCliente.Controls.Add(Me.pnlPie)
        Me.pnlListaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListaCliente.Location = New System.Drawing.Point(0, 59)
        Me.pnlListaCliente.Name = "pnlListaCliente"
        Me.pnlListaCliente.Size = New System.Drawing.Size(989, 386)
        Me.pnlListaCliente.TabIndex = 3
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(989, 315)
        Me.TabControl1.TabIndex = 65
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grdApartado)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(981, 289)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Apartados"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grdApartado
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdApartado.DisplayLayout.Appearance = Appearance1
        Me.grdApartado.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdApartado.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdApartado.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdApartado.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdApartado.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdApartado.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdApartado.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdApartado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdApartado.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdApartado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdApartado.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.grdApartado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdApartado.Location = New System.Drawing.Point(3, 3)
        Me.grdApartado.Name = "grdApartado"
        Me.grdApartado.Size = New System.Drawing.Size(975, 283)
        Me.grdApartado.TabIndex = 64
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grdProduccion)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(981, 289)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Producción"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grdProduccion
        '
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProduccion.DisplayLayout.Appearance = Appearance2
        Me.grdProduccion.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdProduccion.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdProduccion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdProduccion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdProduccion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdProduccion.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdProduccion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdProduccion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdProduccion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdProduccion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProduccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProduccion.Location = New System.Drawing.Point(3, 3)
        Me.grdProduccion.Name = "grdProduccion"
        Me.grdProduccion.Size = New System.Drawing.Size(975, 283)
        Me.grdProduccion.TabIndex = 65
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.grdBloqueados)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(981, 289)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Bloqueados"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'grdBloqueados
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdBloqueados.DisplayLayout.Appearance = Appearance3
        Me.grdBloqueados.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdBloqueados.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdBloqueados.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdBloqueados.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdBloqueados.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdBloqueados.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdBloqueados.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdBloqueados.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdBloqueados.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdBloqueados.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdBloqueados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBloqueados.Location = New System.Drawing.Point(0, 0)
        Me.grdBloqueados.Name = "grdBloqueados"
        Me.grdBloqueados.Size = New System.Drawing.Size(981, 289)
        Me.grdBloqueados.TabIndex = 65
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.grdReproceso)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(981, 289)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Reproceso"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'grdReproceso
        '
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdReproceso.DisplayLayout.Appearance = Appearance4
        Me.grdReproceso.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdReproceso.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdReproceso.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdReproceso.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdReproceso.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdReproceso.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdReproceso.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdReproceso.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdReproceso.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdReproceso.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdReproceso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdReproceso.Location = New System.Drawing.Point(0, 0)
        Me.grdReproceso.Name = "grdReproceso"
        Me.grdReproceso.Size = New System.Drawing.Size(981, 289)
        Me.grdReproceso.TabIndex = 65
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.grdClientesBloqueados)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(981, 289)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Clientes Bloqueados"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'grdClientesBloqueados
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientesBloqueados.DisplayLayout.Appearance = Appearance5
        Me.grdClientesBloqueados.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdClientesBloqueados.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdClientesBloqueados.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdClientesBloqueados.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdClientesBloqueados.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClientesBloqueados.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdClientesBloqueados.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdClientesBloqueados.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdClientesBloqueados.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClientesBloqueados.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClientesBloqueados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClientesBloqueados.Location = New System.Drawing.Point(3, 3)
        Me.grdClientesBloqueados.Name = "grdClientesBloqueados"
        Me.grdClientesBloqueados.Size = New System.Drawing.Size(975, 283)
        Me.grdClientesBloqueados.TabIndex = 66
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.grdParesProgramadosProduccion)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(981, 289)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Programación / Programado"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'grdParesProgramadosProduccion
        '
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdParesProgramadosProduccion.DisplayLayout.Appearance = Appearance6
        Me.grdParesProgramadosProduccion.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdParesProgramadosProduccion.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdParesProgramadosProduccion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdParesProgramadosProduccion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdParesProgramadosProduccion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdParesProgramadosProduccion.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdParesProgramadosProduccion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdParesProgramadosProduccion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdParesProgramadosProduccion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdParesProgramadosProduccion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdParesProgramadosProduccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdParesProgramadosProduccion.Location = New System.Drawing.Point(0, 0)
        Me.grdParesProgramadosProduccion.Name = "grdParesProgramadosProduccion"
        Me.grdParesProgramadosProduccion.Size = New System.Drawing.Size(981, 289)
        Me.grdParesProgramadosProduccion.TabIndex = 67
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.lblAbreviaturas2)
        Me.pnlPie.Controls.Add(Me.lblStEjecucion)
        Me.pnlPie.Controls.Add(Me.lblAbreviaturas1)
        Me.pnlPie.Controls.Add(Me.pnlEstatusEnEjecucion)
        Me.pnlPie.Controls.Add(Me.lblStParcialmenteConfirmado)
        Me.pnlPie.Controls.Add(Me.pnlEstatusParcialmenteConfirmado)
        Me.pnlPie.Controls.Add(Me.lblStActivo)
        Me.pnlPie.Controls.Add(Me.pnlEstatusActivo)
        Me.pnlPie.Controls.Add(Me.lblFechaUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.lblTextoUltimaDistribucion)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 315)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(989, 71)
        Me.pnlPie.TabIndex = 64
        '
        'lblAbreviaturas2
        '
        Me.lblAbreviaturas2.AutoSize = True
        Me.lblAbreviaturas2.Location = New System.Drawing.Point(342, 3)
        Me.lblAbreviaturas2.Name = "lblAbreviaturas2"
        Me.lblAbreviaturas2.Size = New System.Drawing.Size(245, 65)
        Me.lblAbreviaturas2.TabIndex = 8
        Me.lblAbreviaturas2.Text = "ID Tipo de Bloqueo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "5   NO SE PUEDE LOCALIZAR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "6   DESCUENTOS IMPROCEDENTES" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "7   " &
    "EXCEDIÓ SU LÍMITE DE CRÉDITO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "8   EXCEDIÓ SU LÍMITE DE CRÉDITO PEDIDOS"
        '
        'lblStEjecucion
        '
        Me.lblStEjecucion.AutoSize = True
        Me.lblStEjecucion.Location = New System.Drawing.Point(153, 30)
        Me.lblStEjecucion.Name = "lblStEjecucion"
        Me.lblStEjecucion.Size = New System.Drawing.Size(69, 13)
        Me.lblStEjecucion.TabIndex = 133
        Me.lblStEjecucion.Text = "En ejecución"
        '
        'lblAbreviaturas1
        '
        Me.lblAbreviaturas1.AutoSize = True
        Me.lblAbreviaturas1.Location = New System.Drawing.Point(132, 3)
        Me.lblAbreviaturas1.Name = "lblAbreviaturas1"
        Me.lblAbreviaturas1.Size = New System.Drawing.Size(194, 65)
        Me.lblAbreviaturas1.TabIndex = 7
        Me.lblAbreviaturas1.Text = "ID Tipo de Bloqueo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1   VENCIMIENTO DE DOCUMENTOS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2   PLAZO DE PAGO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3   CHEQUES" &
    " DEVUELTOS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4   SOLO CONTADO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'pnlEstatusEnEjecucion
        '
        Me.pnlEstatusEnEjecucion.BackColor = System.Drawing.Color.DodgerBlue
        Me.pnlEstatusEnEjecucion.ForeColor = System.Drawing.Color.Black
        Me.pnlEstatusEnEjecucion.Location = New System.Drawing.Point(135, 28)
        Me.pnlEstatusEnEjecucion.Name = "pnlEstatusEnEjecucion"
        Me.pnlEstatusEnEjecucion.Size = New System.Drawing.Size(15, 15)
        Me.pnlEstatusEnEjecucion.TabIndex = 134
        '
        'lblStParcialmenteConfirmado
        '
        Me.lblStParcialmenteConfirmado.AutoSize = True
        Me.lblStParcialmenteConfirmado.Location = New System.Drawing.Point(153, 51)
        Me.lblStParcialmenteConfirmado.Name = "lblStParcialmenteConfirmado"
        Me.lblStParcialmenteConfirmado.Size = New System.Drawing.Size(123, 13)
        Me.lblStParcialmenteConfirmado.TabIndex = 131
        Me.lblStParcialmenteConfirmado.Text = "Parcialmente confirmado"
        '
        'pnlEstatusParcialmenteConfirmado
        '
        Me.pnlEstatusParcialmenteConfirmado.BackColor = System.Drawing.Color.Indigo
        Me.pnlEstatusParcialmenteConfirmado.ForeColor = System.Drawing.Color.Black
        Me.pnlEstatusParcialmenteConfirmado.Location = New System.Drawing.Point(135, 49)
        Me.pnlEstatusParcialmenteConfirmado.Name = "pnlEstatusParcialmenteConfirmado"
        Me.pnlEstatusParcialmenteConfirmado.Size = New System.Drawing.Size(15, 15)
        Me.pnlEstatusParcialmenteConfirmado.TabIndex = 132
        '
        'lblStActivo
        '
        Me.lblStActivo.AutoSize = True
        Me.lblStActivo.Location = New System.Drawing.Point(154, 10)
        Me.lblStActivo.Name = "lblStActivo"
        Me.lblStActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblStActivo.TabIndex = 129
        Me.lblStActivo.Text = "Activo"
        '
        'pnlEstatusActivo
        '
        Me.pnlEstatusActivo.BackColor = System.Drawing.Color.Green
        Me.pnlEstatusActivo.ForeColor = System.Drawing.Color.Black
        Me.pnlEstatusActivo.Location = New System.Drawing.Point(136, 8)
        Me.pnlEstatusActivo.Name = "pnlEstatusActivo"
        Me.pnlEstatusActivo.Size = New System.Drawing.Size(15, 15)
        Me.pnlEstatusActivo.TabIndex = 130
        '
        'lblFechaUltimaActualizacion
        '
        Me.lblFechaUltimaActualizacion.AutoSize = True
        Me.lblFechaUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaActualizacion.ForeColor = System.Drawing.Color.Black
        Me.lblFechaUltimaActualizacion.Location = New System.Drawing.Point(695, 27)
        Me.lblFechaUltimaActualizacion.Name = "lblFechaUltimaActualizacion"
        Me.lblFechaUltimaActualizacion.Size = New System.Drawing.Size(114, 13)
        Me.lblFechaUltimaActualizacion.TabIndex = 121
        Me.lblFechaUltimaActualizacion.Text = "24/05/2016 01:54 PM"
        Me.lblFechaUltimaActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTextoUltimaDistribucion
        '
        Me.lblTextoUltimaDistribucion.AutoSize = True
        Me.lblTextoUltimaDistribucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoUltimaDistribucion.ForeColor = System.Drawing.Color.Black
        Me.lblTextoUltimaDistribucion.Location = New System.Drawing.Point(593, 27)
        Me.lblTextoUltimaDistribucion.Name = "lblTextoUltimaDistribucion"
        Me.lblTextoUltimaDistribucion.Size = New System.Drawing.Size(105, 13)
        Me.lblTextoUltimaDistribucion.TabIndex = 122
        Me.lblTextoUltimaDistribucion.Text = "Última Actualización:"
        Me.lblTextoUltimaDistribucion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(845, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(144, 71)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(86, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(85, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(24, 33)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 24)
        Me.lblNumFiltrados.TabIndex = 116
        Me.lblNumFiltrados.Text = "0"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(27, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 24)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Registros"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlEncabezado)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(989, 59)
        Me.pnlCabecera.TabIndex = 1
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(989, 59)
        Me.pnlEncabezado.TabIndex = 25
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(989, 59)
        Me.pnlTitulo.TabIndex = 20
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.pnlMarcarTodo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(921, 59)
        Me.Panel1.TabIndex = 47
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblTitulo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(481, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(440, 59)
        Me.Panel2.TabIndex = 48
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(210, 17)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(160, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Seguimiento Pares"
        '
        'pnlMarcarTodo
        '
        Me.pnlMarcarTodo.Controls.Add(Me.Label2)
        Me.pnlMarcarTodo.Controls.Add(Me.btnExportar)
        Me.pnlMarcarTodo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlMarcarTodo.Location = New System.Drawing.Point(0, 0)
        Me.pnlMarcarTodo.Name = "pnlMarcarTodo"
        Me.pnlMarcarTodo.Size = New System.Drawing.Size(113, 59)
        Me.pnlMarcarTodo.TabIndex = 47
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(25, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(32, 5)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 5
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(921, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'cmsPriorizar
        '
        Me.cmsPriorizar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAsignarPrioridad})
        Me.cmsPriorizar.Name = "cmsOpcionesAlmacen"
        Me.cmsPriorizar.Size = New System.Drawing.Size(156, 26)
        '
        'tsmiAsignarPrioridad
        '
        Me.tsmiAsignarPrioridad.Name = "tsmiAsignarPrioridad"
        Me.tsmiAsignarPrioridad.Size = New System.Drawing.Size(155, 22)
        Me.tsmiAsignarPrioridad.Text = "Asignar prioridad"
        '
        'SeguimientoParesProyeccion_SoloConsultaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 445)
        Me.Controls.Add(Me.pnlContenedor)
        Me.Name = "SeguimientoParesProyeccion_SoloConsultaForm"
        Me.Text = "SeguimientoParesProyeccion_SoloConsultaForm"
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlListaCliente.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.grdApartado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grdProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.grdBloqueados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.grdReproceso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.grdClientesBloqueados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        CType(Me.grdParesProgramadosProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlMarcarTodo.ResumeLayout(False)
        Me.pnlMarcarTodo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsPriorizar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents pnlListaCliente As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents grdApartado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents grdProduccion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents grdBloqueados As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents grdReproceso As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents grdClientesBloqueados As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents grdParesProgramadosProduccion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlPie As Panel
    Friend WithEvents lblAbreviaturas2 As Label
    Friend WithEvents lblStEjecucion As Label
    Friend WithEvents lblAbreviaturas1 As Label
    Friend WithEvents pnlEstatusEnEjecucion As Panel
    Friend WithEvents lblStParcialmenteConfirmado As Label
    Friend WithEvents pnlEstatusParcialmenteConfirmado As Panel
    Friend WithEvents lblStActivo As Label
    Friend WithEvents pnlEstatusActivo As Panel
    Friend WithEvents lblFechaUltimaActualizacion As Label
    Friend WithEvents lblTextoUltimaDistribucion As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents lblNumFiltrados As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlMarcarTodo As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents btnExportar As Button
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents cmsPriorizar As ContextMenuStrip
    Friend WithEvents tsmiAsignarPrioridad As ToolStripMenuItem
End Class
