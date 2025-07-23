<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeduccionesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DeduccionesForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLista = New System.Windows.Forms.Label()
        Me.btnLista = New System.Windows.Forms.Button()
        Me.lblEliminar = New System.Windows.Forms.Label()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.lblCobro = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnCobro = New System.Windows.Forms.Button()
        Me.lblSemanaNomina = New System.Windows.Forms.Label()
        Me.lblIdSemanaNomina = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.lblconcepto = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.cmbArea = New System.Windows.Forms.ComboBox()
        Me.lblcolaborador = New System.Windows.Forms.Label()
        Me.lblarea = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.grdDeducciones = New System.Windows.Forms.DataGridView()
        Me.clmDeduccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmColaborador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmDepartamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmIdColaborador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdSemanaNomina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmDeduccionTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SeleccionarTodosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeseleccionarTodasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.chkPeriodo = New System.Windows.Forms.CheckBox()
        Me.rdbSemanas = New System.Windows.Forms.RadioButton()
        Me.rdbAbono = New System.Windows.Forms.RadioButton()
        Me.txtAbono = New System.Windows.Forms.TextBox()
        Me.lblAbono = New System.Windows.Forms.Label()
        Me.lblNumeroSemanas = New System.Windows.Forms.Label()
        Me.txtNumeroSemanas = New System.Windows.Forms.TextBox()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnOcultar = New System.Windows.Forms.Button()
        Me.lblOcultar = New System.Windows.Forms.Label()
        Me.btnCalcular = New System.Windows.Forms.Button()
        Me.lblCalcular = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.pnlestado = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.grdTablaAmortizacion = New System.Windows.Forms.DataGridView()
        Me.clmNumeroDePago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAbono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSaldoAnterior = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmNuevoSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.grdDeducciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.pnlestado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.grdTablaAmortizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.Label3)
        Me.pnlHeader.Controls.Add(Me.Label2)
        Me.pnlHeader.Controls.Add(Me.lblLista)
        Me.pnlHeader.Controls.Add(Me.btnLista)
        Me.pnlHeader.Controls.Add(Me.lblEliminar)
        Me.pnlHeader.Controls.Add(Me.btneliminar)
        Me.pnlHeader.Controls.Add(Me.lblCobro)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Controls.Add(Me.btnCobro)
        resources.ApplyResources(Me.pnlHeader, "pnlHeader")
        Me.pnlHeader.Name = "pnlHeader"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Name = "Label3"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Name = "Label2"
        '
        'lblLista
        '
        resources.ApplyResources(Me.lblLista, "lblLista")
        Me.lblLista.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLista.Name = "lblLista"
        '
        'btnLista
        '
        Me.btnLista.Image = Global.Nomina.Vista.My.Resources.Resources.catalogos_32
        resources.ApplyResources(Me.btnLista, "btnLista")
        Me.btnLista.Name = "btnLista"
        Me.btnLista.UseVisualStyleBackColor = True
        '
        'lblEliminar
        '
        resources.ApplyResources(Me.lblEliminar, "lblEliminar")
        Me.lblEliminar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEliminar.Name = "lblEliminar"
        '
        'btneliminar
        '
        Me.btneliminar.Image = Global.Nomina.Vista.My.Resources.Resources.cancelar_32
        resources.ApplyResources(Me.btneliminar, "btneliminar")
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'lblCobro
        '
        resources.ApplyResources(Me.lblCobro, "lblCobro")
        Me.lblCobro.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCobro.Name = "lblCobro"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        resources.ApplyResources(Me.pnlTitulo, "pnlTitulo")
        Me.pnlTitulo.Name = "pnlTitulo"
        '
        'lblTitulo
        '
        resources.ApplyResources(Me.lblTitulo, "lblTitulo")
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Name = "lblTitulo"
        '
        'btnCobro
        '
        resources.ApplyResources(Me.btnCobro, "btnCobro")
        Me.btnCobro.Name = "btnCobro"
        Me.btnCobro.UseVisualStyleBackColor = True
        '
        'lblSemanaNomina
        '
        resources.ApplyResources(Me.lblSemanaNomina, "lblSemanaNomina")
        Me.lblSemanaNomina.Name = "lblSemanaNomina"
        '
        'lblIdSemanaNomina
        '
        resources.ApplyResources(Me.lblIdSemanaNomina, "lblIdSemanaNomina")
        Me.lblIdSemanaNomina.Name = "lblIdSemanaNomina"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        resources.ApplyResources(Me.btnGuardar, "btnGuardar")
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        resources.ApplyResources(Me.lblGuardar, "lblGuardar")
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Name = "lblGuardar"
        '
        'txtColaborador
        '
        Me.txtColaborador.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.txtColaborador, "txtColaborador")
        Me.txtColaborador.Name = "txtColaborador"
        '
        'txtMonto
        '
        Me.txtMonto.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.txtMonto, "txtMonto")
        Me.txtMonto.Name = "txtMonto"
        '
        'txtConcepto
        '
        resources.ApplyResources(Me.txtConcepto, "txtConcepto")
        Me.txtConcepto.Name = "txtConcepto"
        '
        'lblMonto
        '
        resources.ApplyResources(Me.lblMonto, "lblMonto")
        Me.lblMonto.ForeColor = System.Drawing.Color.Black
        Me.lblMonto.Name = "lblMonto"
        '
        'lblconcepto
        '
        resources.ApplyResources(Me.lblconcepto, "lblconcepto")
        Me.lblconcepto.ForeColor = System.Drawing.Color.Black
        Me.lblconcepto.Name = "lblconcepto"
        '
        'lblBuscar
        '
        resources.ApplyResources(Me.lblBuscar, "lblBuscar")
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Name = "lblBuscar"
        '
        'btnBuscar
        '
        resources.ApplyResources(Me.btnBuscar, "btnBuscar")
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'cmbArea
        '
        Me.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArea.ForeColor = System.Drawing.Color.Black
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Items.AddRange(New Object() {resources.GetString("cmbArea.Items")})
        resources.ApplyResources(Me.cmbArea, "cmbArea")
        Me.cmbArea.Name = "cmbArea"
        '
        'lblcolaborador
        '
        resources.ApplyResources(Me.lblcolaborador, "lblcolaborador")
        Me.lblcolaborador.ForeColor = System.Drawing.Color.Black
        Me.lblcolaborador.Name = "lblcolaborador"
        '
        'lblarea
        '
        resources.ApplyResources(Me.lblarea, "lblarea")
        Me.lblarea.ForeColor = System.Drawing.Color.Black
        Me.lblarea.Name = "lblarea"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Name = "Label1"
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamento.ForeColor = System.Drawing.Color.Black
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Items.AddRange(New Object() {resources.GetString("cmbDepartamento.Items")})
        resources.ApplyResources(Me.cmbDepartamento, "cmbDepartamento")
        Me.cmbDepartamento.Name = "cmbDepartamento"
        '
        'lblNave
        '
        resources.ApplyResources(Me.lblNave, "lblNave")
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Name = "lblNave"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        resources.ApplyResources(Me.cmbNave, "cmbNave")
        Me.cmbNave.Name = "cmbNave"
        '
        'grdDeducciones
        '
        Me.grdDeducciones.AllowUserToAddRows = False
        Me.grdDeducciones.AllowUserToDeleteRows = False
        Me.grdDeducciones.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDeducciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDeducciones.BackgroundColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDeducciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdDeducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDeducciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmDeduccion, Me.clmColaborador, Me.clmDepartamento, Me.clmPuesto, Me.clmIdColaborador, Me.IdSemanaNomina, Me.clmDeduccionTipo})
        Me.grdDeducciones.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDeducciones.DefaultCellStyle = DataGridViewCellStyle3
        resources.ApplyResources(Me.grdDeducciones, "grdDeducciones")
        Me.grdDeducciones.Name = "grdDeducciones"
        '
        'clmDeduccion
        '
        resources.ApplyResources(Me.clmDeduccion, "clmDeduccion")
        Me.clmDeduccion.Name = "clmDeduccion"
        '
        'clmColaborador
        '
        Me.clmColaborador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.clmColaborador, "clmColaborador")
        Me.clmColaborador.Name = "clmColaborador"
        Me.clmColaborador.ReadOnly = True
        Me.clmColaborador.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmColaborador.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clmDepartamento
        '
        resources.ApplyResources(Me.clmDepartamento, "clmDepartamento")
        Me.clmDepartamento.Name = "clmDepartamento"
        Me.clmDepartamento.ReadOnly = True
        Me.clmDepartamento.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmDepartamento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clmPuesto
        '
        resources.ApplyResources(Me.clmPuesto, "clmPuesto")
        Me.clmPuesto.Name = "clmPuesto"
        Me.clmPuesto.ReadOnly = True
        Me.clmPuesto.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmPuesto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clmIdColaborador
        '
        resources.ApplyResources(Me.clmIdColaborador, "clmIdColaborador")
        Me.clmIdColaborador.Name = "clmIdColaborador"
        Me.clmIdColaborador.ReadOnly = True
        '
        'IdSemanaNomina
        '
        resources.ApplyResources(Me.IdSemanaNomina, "IdSemanaNomina")
        Me.IdSemanaNomina.Name = "IdSemanaNomina"
        Me.IdSemanaNomina.ReadOnly = True
        '
        'clmDeduccionTipo
        '
        resources.ApplyResources(Me.clmDeduccionTipo, "clmDeduccionTipo")
        Me.clmDeduccionTipo.Name = "clmDeduccionTipo"
        Me.clmDeduccionTipo.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeleccionarTodosToolStripMenuItem, Me.DeseleccionarTodasToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        '
        'SeleccionarTodosToolStripMenuItem
        '
        Me.SeleccionarTodosToolStripMenuItem.Name = "SeleccionarTodosToolStripMenuItem"
        resources.ApplyResources(Me.SeleccionarTodosToolStripMenuItem, "SeleccionarTodosToolStripMenuItem")
        '
        'DeseleccionarTodasToolStripMenuItem
        '
        Me.DeseleccionarTodasToolStripMenuItem.Name = "DeseleccionarTodasToolStripMenuItem"
        resources.ApplyResources(Me.DeseleccionarTodasToolStripMenuItem, "DeseleccionarTodasToolStripMenuItem")
        '
        'btnAbajo
        '
        resources.ApplyResources(Me.btnAbajo, "btnAbajo")
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        resources.ApplyResources(Me.btnArriba, "btnArriba")
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.Transparent
        Me.grbParametros.Controls.Add(Me.lblPeriodo)
        Me.grbParametros.Controls.Add(Me.chkPeriodo)
        Me.grbParametros.Controls.Add(Me.rdbSemanas)
        Me.grbParametros.Controls.Add(Me.lblSemanaNomina)
        Me.grbParametros.Controls.Add(Me.rdbAbono)
        Me.grbParametros.Controls.Add(Me.txtAbono)
        Me.grbParametros.Controls.Add(Me.lblIdSemanaNomina)
        Me.grbParametros.Controls.Add(Me.lblAbono)
        Me.grbParametros.Controls.Add(Me.lblNumeroSemanas)
        Me.grbParametros.Controls.Add(Me.txtNumeroSemanas)
        Me.grbParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.grbParametros.Controls.Add(Me.txtColaborador)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Controls.Add(Me.txtMonto)
        Me.grbParametros.Controls.Add(Me.lblNave)
        Me.grbParametros.Controls.Add(Me.txtConcepto)
        Me.grbParametros.Controls.Add(Me.cmbDepartamento)
        Me.grbParametros.Controls.Add(Me.lblMonto)
        Me.grbParametros.Controls.Add(Me.Label1)
        Me.grbParametros.Controls.Add(Me.lblconcepto)
        Me.grbParametros.Controls.Add(Me.lblarea)
        Me.grbParametros.Controls.Add(Me.lblcolaborador)
        Me.grbParametros.Controls.Add(Me.cmbArea)
        resources.ApplyResources(Me.grbParametros, "grbParametros")
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.TabStop = False
        '
        'lblPeriodo
        '
        resources.ApplyResources(Me.lblPeriodo, "lblPeriodo")
        Me.lblPeriodo.ForeColor = System.Drawing.Color.Black
        Me.lblPeriodo.Name = "lblPeriodo"
        '
        'chkPeriodo
        '
        resources.ApplyResources(Me.chkPeriodo, "chkPeriodo")
        Me.chkPeriodo.Name = "chkPeriodo"
        Me.chkPeriodo.UseVisualStyleBackColor = True
        '
        'rdbSemanas
        '
        resources.ApplyResources(Me.rdbSemanas, "rdbSemanas")
        Me.rdbSemanas.Name = "rdbSemanas"
        Me.rdbSemanas.TabStop = True
        Me.rdbSemanas.UseVisualStyleBackColor = True
        '
        'rdbAbono
        '
        resources.ApplyResources(Me.rdbAbono, "rdbAbono")
        Me.rdbAbono.Name = "rdbAbono"
        Me.rdbAbono.TabStop = True
        Me.rdbAbono.UseVisualStyleBackColor = True
        '
        'txtAbono
        '
        Me.txtAbono.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.txtAbono, "txtAbono")
        Me.txtAbono.Name = "txtAbono"
        '
        'lblAbono
        '
        resources.ApplyResources(Me.lblAbono, "lblAbono")
        Me.lblAbono.ForeColor = System.Drawing.Color.Black
        Me.lblAbono.Name = "lblAbono"
        '
        'lblNumeroSemanas
        '
        resources.ApplyResources(Me.lblNumeroSemanas, "lblNumeroSemanas")
        Me.lblNumeroSemanas.ForeColor = System.Drawing.Color.Black
        Me.lblNumeroSemanas.Name = "lblNumeroSemanas"
        '
        'txtNumeroSemanas
        '
        Me.txtNumeroSemanas.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.txtNumeroSemanas, "txtNumeroSemanas")
        Me.txtNumeroSemanas.Name = "txtNumeroSemanas"
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.btnOcultar)
        Me.pnlMinimizarParametros.Controls.Add(Me.lblOcultar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnCalcular)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Controls.Add(Me.lblCalcular)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnBuscar)
        Me.pnlMinimizarParametros.Controls.Add(Me.lblBuscar)
        Me.pnlMinimizarParametros.Controls.Add(Me.lblLimpiar)
        resources.ApplyResources(Me.pnlMinimizarParametros, "pnlMinimizarParametros")
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        '
        'btnOcultar
        '
        Me.btnOcultar.Image = Global.Nomina.Vista.My.Resources.Resources.finanzas_32
        resources.ApplyResources(Me.btnOcultar, "btnOcultar")
        Me.btnOcultar.Name = "btnOcultar"
        Me.btnOcultar.UseVisualStyleBackColor = True
        '
        'lblOcultar
        '
        resources.ApplyResources(Me.lblOcultar, "lblOcultar")
        Me.lblOcultar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblOcultar.Name = "lblOcultar"
        '
        'btnCalcular
        '
        Me.btnCalcular.Image = Global.Nomina.Vista.My.Resources.Resources.calculo_32
        resources.ApplyResources(Me.btnCalcular, "btnCalcular")
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.UseVisualStyleBackColor = True
        '
        'lblCalcular
        '
        resources.ApplyResources(Me.lblCalcular, "lblCalcular")
        Me.lblCalcular.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCalcular.Name = "lblCalcular"
        '
        'btnLimpiar
        '
        resources.ApplyResources(Me.btnLimpiar, "btnLimpiar")
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        resources.ApplyResources(Me.lblLimpiar, "lblLimpiar")
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Name = "lblLimpiar"
        '
        'pnlestado
        '
        Me.pnlestado.BackColor = System.Drawing.Color.White
        Me.pnlestado.Controls.Add(Me.pnlAcciones)
        resources.ApplyResources(Me.pnlestado, "pnlestado")
        Me.pnlestado.Name = "pnlestado"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnCncelar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        resources.ApplyResources(Me.pnlAcciones, "pnlAcciones")
        Me.pnlAcciones.Name = "pnlAcciones"
        '
        'lblCancelar
        '
        resources.ApplyResources(Me.lblCancelar, "lblCancelar")
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Name = "lblCancelar"
        '
        'btnCncelar
        '
        resources.ApplyResources(Me.btnCncelar, "btnCncelar")
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'grdTablaAmortizacion
        '
        Me.grdTablaAmortizacion.AllowUserToAddRows = False
        Me.grdTablaAmortizacion.AllowUserToDeleteRows = False
        Me.grdTablaAmortizacion.AllowUserToResizeColumns = False
        Me.grdTablaAmortizacion.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTablaAmortizacion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grdTablaAmortizacion.BackgroundColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdTablaAmortizacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grdTablaAmortizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTablaAmortizacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmNumeroDePago, Me.clmAbono, Me.clmSaldoAnterior, Me.clmNuevoSaldo})
        resources.ApplyResources(Me.grdTablaAmortizacion, "grdTablaAmortizacion")
        Me.grdTablaAmortizacion.Name = "grdTablaAmortizacion"
        '
        'clmNumeroDePago
        '
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.clmNumeroDePago.DefaultCellStyle = DataGridViewCellStyle6
        resources.ApplyResources(Me.clmNumeroDePago, "clmNumeroDePago")
        Me.clmNumeroDePago.Name = "clmNumeroDePago"
        Me.clmNumeroDePago.ReadOnly = True
        Me.clmNumeroDePago.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'clmAbono
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.clmAbono.DefaultCellStyle = DataGridViewCellStyle7
        resources.ApplyResources(Me.clmAbono, "clmAbono")
        Me.clmAbono.Name = "clmAbono"
        Me.clmAbono.ReadOnly = True
        '
        'clmSaldoAnterior
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.clmSaldoAnterior.DefaultCellStyle = DataGridViewCellStyle8
        resources.ApplyResources(Me.clmSaldoAnterior, "clmSaldoAnterior")
        Me.clmSaldoAnterior.Name = "clmSaldoAnterior"
        '
        'clmNuevoSaldo
        '
        Me.clmNuevoSaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.clmNuevoSaldo.DefaultCellStyle = DataGridViewCellStyle9
        resources.ApplyResources(Me.clmNuevoSaldo, "clmNuevoSaldo")
        Me.clmNuevoSaldo.Name = "clmNuevoSaldo"
        Me.clmNuevoSaldo.ReadOnly = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.DataGridViewTextBoxColumn1, "DataGridViewTextBoxColumn1")
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn2
        '
        resources.ApplyResources(Me.DataGridViewTextBoxColumn2, "DataGridViewTextBoxColumn2")
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn3
        '
        resources.ApplyResources(Me.DataGridViewTextBoxColumn3, "DataGridViewTextBoxColumn3")
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn4
        '
        resources.ApplyResources(Me.DataGridViewTextBoxColumn4, "DataGridViewTextBoxColumn4")
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        resources.ApplyResources(Me.DataGridViewTextBoxColumn5, "DataGridViewTextBoxColumn5")
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        resources.ApplyResources(Me.DataGridViewTextBoxColumn6, "DataGridViewTextBoxColumn6")
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        DataGridViewCellStyle10.Format = "N0"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle10
        resources.ApplyResources(Me.DataGridViewTextBoxColumn7, "DataGridViewTextBoxColumn7")
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DataGridViewTextBoxColumn8
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "C2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle11
        resources.ApplyResources(Me.DataGridViewTextBoxColumn8, "DataGridViewTextBoxColumn8")
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "C2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle12
        resources.ApplyResources(Me.DataGridViewTextBoxColumn9, "DataGridViewTextBoxColumn9")
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'pcbTitulo
        '
        resources.ApplyResources(Me.pcbTitulo, "pcbTitulo")
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.TabStop = False
        '
        'DeduccionesForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.Controls.Add(Me.grdTablaAmortizacion)
        Me.Controls.Add(Me.grdDeducciones)
        Me.Controls.Add(Me.pnlestado)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DeduccionesForm"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.grdDeducciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.PerformLayout()
        Me.pnlestado.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        CType(Me.grdTablaAmortizacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cmbArea As System.Windows.Forms.ComboBox
    Friend WithEvents lblcolaborador As System.Windows.Forms.Label
    Friend WithEvents lblarea As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents lblconcepto As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents grdDeducciones As System.Windows.Forms.DataGridView
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents txtColaborador As System.Windows.Forms.TextBox
    Friend WithEvents lblIdSemanaNomina As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SeleccionarTodosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeseleccionarTodasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblCobro As System.Windows.Forms.Label
    Friend WithEvents btnCobro As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents pnlestado As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblNumeroSemanas As System.Windows.Forms.Label
    Friend WithEvents txtNumeroSemanas As System.Windows.Forms.TextBox
    Friend WithEvents rdbSemanas As System.Windows.Forms.RadioButton
    Friend WithEvents rdbAbono As System.Windows.Forms.RadioButton
    Friend WithEvents txtAbono As System.Windows.Forms.TextBox
    Friend WithEvents lblAbono As System.Windows.Forms.Label
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents chkPeriodo As System.Windows.Forms.CheckBox
    Friend WithEvents btnCalcular As System.Windows.Forms.Button
    Friend WithEvents lblCalcular As System.Windows.Forms.Label
    Friend WithEvents grdTablaAmortizacion As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnOcultar As System.Windows.Forms.Button
    Friend WithEvents lblOcultar As System.Windows.Forms.Label
    Friend WithEvents lblEliminar As System.Windows.Forms.Label
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents lblSemanaNomina As System.Windows.Forms.Label
    Friend WithEvents lblLista As System.Windows.Forms.Label
    Friend WithEvents btnLista As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCncelar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents clmNumeroDePago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmAbono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSaldoAnterior As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmNuevoSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmDeduccion As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clmColaborador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmDepartamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmPuesto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmIdColaborador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdSemanaNomina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmDeduccionTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcbTitulo As PictureBox
End Class
