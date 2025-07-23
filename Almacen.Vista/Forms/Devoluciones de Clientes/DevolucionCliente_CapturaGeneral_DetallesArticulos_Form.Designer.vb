<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DevolucionCliente_CapturaGeneral_DetallesArticulos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DevolucionCliente_CapturaGeneral_DetallesArticulos))
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.grdArticulosSeleccionados = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlSeleccionModelos = New System.Windows.Forms.Panel()
        Me.rdbModeloSICY = New System.Windows.Forms.RadioButton()
        Me.rdbModeloSAY = New System.Windows.Forms.RadioButton()
        Me.lblModeloEncontrado = New System.Windows.Forms.Label()
        Me.lblEtiquetaBtnAgregarArticulo = New System.Windows.Forms.Label()
        Me.btnAgregarArticulos = New System.Windows.Forms.Button()
        Me.cmbArticulos = New System.Windows.Forms.ComboBox()
        Me.txtModeloSAY = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.grdParesPorTalla = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblNumRenglonGrid = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblEtiquetaNumRenglonGrid = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblFolioDevolucion = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkSeleccionarTodos = New System.Windows.Forms.CheckBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblUnidadMedida = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblCajas = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.lblEtiquetaMonto = New System.Windows.Forms.Label()
        Me.lblParesCapturados = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pnlCancelar = New System.Windows.Forms.Panel()
        Me.btnCancelarDev_Partidas = New System.Windows.Forms.Button()
        Me.lblBtnCancelar_partida = New System.Windows.Forms.Label()
        Me.pnlEtiquetas = New System.Windows.Forms.Panel()
        Me.btnEtiquetas = New System.Windows.Forms.Button()
        Me.lblEtiquetas = New System.Windows.Forms.Label()
        Me.pnlBtnActualizar = New System.Windows.Forms.Panel()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlBtnEliminar = New System.Windows.Forms.Panel()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pnlBtnExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.pnlBtnCodigosCliente = New System.Windows.Forms.Panel()
        Me.btnCodigosCliente = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlBtnAgregarArticulo = New System.Windows.Forms.Panel()
        Me.btnAgregarArticulo = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pgrsPnlCargando = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.grdInfoEtiquetas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.cmbNave_UC = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.cmbProcede_UC = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.cmbClasificacion_UC = New Infragistics.Win.UltraWinGrid.UltraCombo()
        CType(Me.grdArticulosSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.pnlSeleccionModelos.SuspendLayout()
        CType(Me.grdParesPorTalla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlCancelar.SuspendLayout()
        Me.pnlEtiquetas.SuspendLayout()
        Me.pnlBtnActualizar.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlBtnEliminar.SuspendLayout()
        Me.pnlBtnExportar.SuspendLayout()
        Me.pnlBtnCodigosCliente.SuspendLayout()
        Me.pnlBtnAgregarArticulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdInfoEtiquetas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbNave_UC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbProcede_UC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbClasificacion_UC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdArticulosSeleccionados
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdArticulosSeleccionados.DisplayLayout.Appearance = Appearance1
        Me.grdArticulosSeleccionados.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdArticulosSeleccionados.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdArticulosSeleccionados.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdArticulosSeleccionados.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdArticulosSeleccionados.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdArticulosSeleccionados.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdArticulosSeleccionados.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdArticulosSeleccionados.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdArticulosSeleccionados.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdArticulosSeleccionados.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdArticulosSeleccionados.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.grdArticulosSeleccionados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdArticulosSeleccionados.Location = New System.Drawing.Point(0, 184)
        Me.grdArticulosSeleccionados.Name = "grdArticulosSeleccionados"
        Me.grdArticulosSeleccionados.Size = New System.Drawing.Size(1015, 297)
        Me.grdArticulosSeleccionados.TabIndex = 80
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel3.Controls.Add(Me.pnlSeleccionModelos)
        Me.Panel3.Controls.Add(Me.lblModeloEncontrado)
        Me.Panel3.Controls.Add(Me.lblEtiquetaBtnAgregarArticulo)
        Me.Panel3.Controls.Add(Me.btnAgregarArticulos)
        Me.Panel3.Controls.Add(Me.cmbArticulos)
        Me.Panel3.Controls.Add(Me.txtModeloSAY)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Controls.Add(Me.grdParesPorTalla)
        Me.Panel3.Controls.Add(Me.lblNumRenglonGrid)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.lblEtiquetaNumRenglonGrid)
        Me.Panel3.Controls.Add(Me.lblCliente)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.RadioButton1)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.lblFolioDevolucion)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.chkSeleccionarTodos)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 65)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1015, 119)
        Me.Panel3.TabIndex = 79
        '
        'pnlSeleccionModelos
        '
        Me.pnlSeleccionModelos.Controls.Add(Me.rdbModeloSICY)
        Me.pnlSeleccionModelos.Controls.Add(Me.rdbModeloSAY)
        Me.pnlSeleccionModelos.Location = New System.Drawing.Point(7, 49)
        Me.pnlSeleccionModelos.Name = "pnlSeleccionModelos"
        Me.pnlSeleccionModelos.Size = New System.Drawing.Size(199, 25)
        Me.pnlSeleccionModelos.TabIndex = 220
        '
        'rdbModeloSICY
        '
        Me.rdbModeloSICY.AutoSize = True
        Me.rdbModeloSICY.Location = New System.Drawing.Point(98, 4)
        Me.rdbModeloSICY.Name = "rdbModeloSICY"
        Me.rdbModeloSICY.Size = New System.Drawing.Size(87, 17)
        Me.rdbModeloSICY.TabIndex = 219
        Me.rdbModeloSICY.Text = "Modelo SICY"
        Me.rdbModeloSICY.UseVisualStyleBackColor = True
        '
        'rdbModeloSAY
        '
        Me.rdbModeloSAY.AutoSize = True
        Me.rdbModeloSAY.Checked = True
        Me.rdbModeloSAY.Location = New System.Drawing.Point(4, 4)
        Me.rdbModeloSAY.Name = "rdbModeloSAY"
        Me.rdbModeloSAY.Size = New System.Drawing.Size(84, 17)
        Me.rdbModeloSAY.TabIndex = 218
        Me.rdbModeloSAY.TabStop = True
        Me.rdbModeloSAY.Text = "Modelo SAY"
        Me.rdbModeloSAY.UseVisualStyleBackColor = True
        '
        'lblModeloEncontrado
        '
        Me.lblModeloEncontrado.AutoSize = True
        Me.lblModeloEncontrado.ForeColor = System.Drawing.Color.Red
        Me.lblModeloEncontrado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblModeloEncontrado.Location = New System.Drawing.Point(898, 82)
        Me.lblModeloEncontrado.Name = "lblModeloEncontrado"
        Me.lblModeloEncontrado.Size = New System.Drawing.Size(291, 13)
        Me.lblModeloEncontrado.TabIndex = 217
        Me.lblModeloEncontrado.Text = "ESTE MODELO NO HA SIDO VENDIDO A ESTE CLIENTE"
        Me.lblModeloEncontrado.Visible = False
        '
        'lblEtiquetaBtnAgregarArticulo
        '
        Me.lblEtiquetaBtnAgregarArticulo.AutoSize = True
        Me.lblEtiquetaBtnAgregarArticulo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEtiquetaBtnAgregarArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEtiquetaBtnAgregarArticulo.Location = New System.Drawing.Point(848, 72)
        Me.lblEtiquetaBtnAgregarArticulo.Name = "lblEtiquetaBtnAgregarArticulo"
        Me.lblEtiquetaBtnAgregarArticulo.Size = New System.Drawing.Size(44, 26)
        Me.lblEtiquetaBtnAgregarArticulo.TabIndex = 83
        Me.lblEtiquetaBtnAgregarArticulo.Text = "Agregar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Artículo"
        Me.lblEtiquetaBtnAgregarArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAgregarArticulos
        '
        Me.btnAgregarArticulos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAgregarArticulos.Image = Global.Almacen.Vista.My.Resources.Resources.agregar_32
        Me.btnAgregarArticulos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAgregarArticulos.Location = New System.Drawing.Point(810, 72)
        Me.btnAgregarArticulos.Name = "btnAgregarArticulos"
        Me.btnAgregarArticulos.Size = New System.Drawing.Size(32, 30)
        Me.btnAgregarArticulos.TabIndex = 216
        Me.btnAgregarArticulos.UseVisualStyleBackColor = True
        '
        'cmbArticulos
        '
        Me.cmbArticulos.FormattingEnabled = True
        Me.cmbArticulos.Location = New System.Drawing.Point(171, 77)
        Me.cmbArticulos.Name = "cmbArticulos"
        Me.cmbArticulos.Size = New System.Drawing.Size(634, 21)
        Me.cmbArticulos.TabIndex = 215
        '
        'txtModeloSAY
        '
        Me.txtModeloSAY.Location = New System.Drawing.Point(50, 77)
        Me.txtModeloSAY.MaxLength = 8
        Me.txtModeloSAY.Name = "txtModeloSAY"
        Me.txtModeloSAY.Size = New System.Drawing.Size(115, 20)
        Me.txtModeloSAY.TabIndex = 1
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(4, 80)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(45, 13)
        Me.Label20.TabIndex = 213
        Me.Label20.Text = "Modelo:"
        '
        'grdParesPorTalla
        '
        Me.grdParesPorTalla.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdParesPorTalla.Location = New System.Drawing.Point(487, 31)
        Me.grdParesPorTalla.Name = "grdParesPorTalla"
        Me.grdParesPorTalla.Size = New System.Drawing.Size(315, 40)
        Me.grdParesPorTalla.TabIndex = 212
        Me.grdParesPorTalla.Visible = False
        '
        'lblNumRenglonGrid
        '
        Me.lblNumRenglonGrid.AutoSize = True
        Me.lblNumRenglonGrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumRenglonGrid.ForeColor = System.Drawing.Color.Black
        Me.lblNumRenglonGrid.Location = New System.Drawing.Point(452, 31)
        Me.lblNumRenglonGrid.Name = "lblNumRenglonGrid"
        Me.lblNumRenglonGrid.Size = New System.Drawing.Size(13, 13)
        Me.lblNumRenglonGrid.TabIndex = 209
        Me.lblNumRenglonGrid.Text = "0"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(386, 52)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 13)
        Me.Label17.TabIndex = 208
        Me.Label17.Text = "Pares Por Talla"
        '
        'lblEtiquetaNumRenglonGrid
        '
        Me.lblEtiquetaNumRenglonGrid.AutoSize = True
        Me.lblEtiquetaNumRenglonGrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaNumRenglonGrid.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaNumRenglonGrid.Location = New System.Drawing.Point(386, 31)
        Me.lblEtiquetaNumRenglonGrid.Name = "lblEtiquetaNumRenglonGrid"
        Me.lblEtiquetaNumRenglonGrid.Size = New System.Drawing.Size(56, 13)
        Me.lblEtiquetaNumRenglonGrid.TabIndex = 207
        Me.lblEtiquetaNumRenglonGrid.Text = "Registro #"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.Black
        Me.lblCliente.Location = New System.Drawing.Point(237, 7)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(173, 16)
        Me.lblCliente.TabIndex = 206
        Me.lblCliente.Text = "NOMBRE DEL CLIENTE"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(847, 38)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 205
        Me.Label12.Text = "Actualizar"
        Me.Label12.Visible = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(848, 50)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(114, 17)
        Me.RadioButton1.TabIndex = 204
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Motivo Devolución"
        Me.RadioButton1.UseVisualStyleBackColor = True
        Me.RadioButton1.Visible = False
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Button2.Image = Global.Almacen.Vista.My.Resources.Resources.refresh_32
        Me.Button2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2.Location = New System.Drawing.Point(810, 37)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 203
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(807, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(150, 26)
        Me.Label11.TabIndex = 202
        Me.Label11.Text = "Primer renglón seleccionado " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a los siguientes seleccionados"
        Me.Label11.Visible = False
        '
        'lblFolioDevolucion
        '
        Me.lblFolioDevolucion.AutoSize = True
        Me.lblFolioDevolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioDevolucion.ForeColor = System.Drawing.Color.Black
        Me.lblFolioDevolucion.Location = New System.Drawing.Point(174, 3)
        Me.lblFolioDevolucion.Name = "lblFolioDevolucion"
        Me.lblFolioDevolucion.Size = New System.Drawing.Size(51, 25)
        Me.lblFolioDevolucion.TabIndex = 197
        Me.lblFolioDevolucion.Text = "589"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(21, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(147, 16)
        Me.Label8.TabIndex = 196
        Me.Label8.Text = "Folio de Devolución"
        '
        'chkSeleccionarTodos
        '
        Me.chkSeleccionarTodos.AutoSize = True
        Me.chkSeleccionarTodos.Location = New System.Drawing.Point(7, 99)
        Me.chkSeleccionarTodos.Name = "chkSeleccionarTodos"
        Me.chkSeleccionarTodos.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarTodos.TabIndex = 0
        Me.chkSeleccionarTodos.Text = "Seleccionar Todo"
        Me.chkSeleccionarTodos.UseVisualStyleBackColor = True
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Label6)
        Me.pnlPie.Controls.Add(Me.lblUnidadMedida)
        Me.pnlPie.Controls.Add(Me.Label14)
        Me.pnlPie.Controls.Add(Me.Label19)
        Me.pnlPie.Controls.Add(Me.lblCajas)
        Me.pnlPie.Controls.Add(Me.lblCantidad)
        Me.pnlPie.Controls.Add(Me.lblMonto)
        Me.pnlPie.Controls.Add(Me.Label83)
        Me.pnlPie.Controls.Add(Me.lblEtiquetaMonto)
        Me.pnlPie.Controls.Add(Me.lblParesCapturados)
        Me.pnlPie.Controls.Add(Me.Label64)
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.Label2)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 481)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1015, 71)
        Me.pnlPie.TabIndex = 78
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(416, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(223, 36)
        Me.Label6.TabIndex = 195
        Me.Label6.Text = "Capturar pares por talla, teclee ENTER en la" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "celda de la columna * Cantidad"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUnidadMedida
        '
        Me.lblUnidadMedida.AutoSize = True
        Me.lblUnidadMedida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidadMedida.ForeColor = System.Drawing.Color.Black
        Me.lblUnidadMedida.Location = New System.Drawing.Point(325, 26)
        Me.lblUnidadMedida.Name = "lblUnidadMedida"
        Me.lblUnidadMedida.Size = New System.Drawing.Size(69, 16)
        Me.lblUnidadMedida.TabIndex = 194
        Me.lblUnidadMedida.Text = "(PARES)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(209, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 16)
        Me.Label14.TabIndex = 193
        Me.Label14.Text = "Cantidad"
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(682, 46)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(149, 18)
        Me.Label19.TabIndex = 192
        Me.Label19.Text = "Modelo / Artículo inactivo"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCajas
        '
        Me.lblCajas.AutoSize = True
        Me.lblCajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCajas.ForeColor = System.Drawing.Color.Black
        Me.lblCajas.Location = New System.Drawing.Point(281, 44)
        Me.lblCajas.Name = "lblCajas"
        Me.lblCajas.Size = New System.Drawing.Size(16, 16)
        Me.lblCajas.TabIndex = 191
        Me.lblCajas.Text = "0"
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.ForeColor = System.Drawing.Color.Black
        Me.lblCantidad.Location = New System.Drawing.Point(281, 26)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(16, 16)
        Me.lblCantidad.TabIndex = 190
        Me.lblCantidad.Text = "0"
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.ForeColor = System.Drawing.Color.Black
        Me.lblMonto.Location = New System.Drawing.Point(819, 27)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(16, 16)
        Me.lblMonto.TabIndex = 186
        Me.lblMonto.Text = "0"
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label83.ForeColor = System.Drawing.Color.Black
        Me.Label83.Location = New System.Drawing.Point(661, 10)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(133, 16)
        Me.Label83.TabIndex = 183
        Me.Label83.Text = "Pares Capturados"
        '
        'lblEtiquetaMonto
        '
        Me.lblEtiquetaMonto.AutoSize = True
        Me.lblEtiquetaMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaMonto.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaMonto.Location = New System.Drawing.Point(661, 27)
        Me.lblEtiquetaMonto.Name = "lblEtiquetaMonto"
        Me.lblEtiquetaMonto.Size = New System.Drawing.Size(62, 16)
        Me.lblEtiquetaMonto.TabIndex = 184
        Me.lblEtiquetaMonto.Text = "Monto $"
        '
        'lblParesCapturados
        '
        Me.lblParesCapturados.AutoSize = True
        Me.lblParesCapturados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesCapturados.ForeColor = System.Drawing.Color.Black
        Me.lblParesCapturados.Location = New System.Drawing.Point(819, 10)
        Me.lblParesCapturados.Name = "lblParesCapturados"
        Me.lblParesCapturados.Size = New System.Drawing.Size(16, 16)
        Me.lblParesCapturados.TabIndex = 185
        Me.lblParesCapturados.Text = "0"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.ForeColor = System.Drawing.Color.Black
        Me.Label64.Location = New System.Drawing.Point(231, 42)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(48, 16)
        Me.Label64.TabIndex = 188
        Me.Label64.Text = "Cajas"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(211, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 16)
        Me.Label1.TabIndex = 189
        Me.Label1.Text = "Captura General"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(7, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 18)
        Me.Label5.TabIndex = 182
        Me.Label5.Text = "Seleccionados"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(25, 39)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 24)
        Me.lblNumFiltrados.TabIndex = 181
        Me.lblNumFiltrados.Text = "0"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(28, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 24)
        Me.Label2.TabIndex = 180
        Me.Label2.Text = "Registros"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(885, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(130, 71)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(79, 12)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(17, 46)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(45, 13)
        Me.lblAceptar.TabIndex = 4
        Me.lblAceptar.Text = "Guardar"
        Me.lblAceptar.Visible = False
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(78, 45)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Almacen.Vista.My.Resources.Resources.guardar2_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(20, 12)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.UseVisualStyleBackColor = True
        Me.btnAceptar.Visible = False
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1015, 65)
        Me.pnlEncabezado.TabIndex = 77
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pnlCancelar)
        Me.pnlTitulo.Controls.Add(Me.pnlEtiquetas)
        Me.pnlTitulo.Controls.Add(Me.pnlBtnActualizar)
        Me.pnlTitulo.Controls.Add(Me.Panel6)
        Me.pnlTitulo.Controls.Add(Me.pnlBtnEliminar)
        Me.pnlTitulo.Controls.Add(Me.pnlBtnExportar)
        Me.pnlTitulo.Controls.Add(Me.pnlBtnCodigosCliente)
        Me.pnlTitulo.Controls.Add(Me.pnlBtnAgregarArticulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1015, 65)
        Me.pnlTitulo.TabIndex = 20
        '
        'pnlCancelar
        '
        Me.pnlCancelar.Controls.Add(Me.btnCancelarDev_Partidas)
        Me.pnlCancelar.Controls.Add(Me.lblBtnCancelar_partida)
        Me.pnlCancelar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCancelar.Location = New System.Drawing.Point(429, 0)
        Me.pnlCancelar.Name = "pnlCancelar"
        Me.pnlCancelar.Size = New System.Drawing.Size(68, 65)
        Me.pnlCancelar.TabIndex = 89
        Me.pnlCancelar.Visible = False
        '
        'btnCancelarDev_Partidas
        '
        Me.btnCancelarDev_Partidas.Enabled = False
        Me.btnCancelarDev_Partidas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelarDev_Partidas.Image = Global.Almacen.Vista.My.Resources.Resources.cancelar321
        Me.btnCancelarDev_Partidas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelarDev_Partidas.Location = New System.Drawing.Point(17, 3)
        Me.btnCancelarDev_Partidas.Name = "btnCancelarDev_Partidas"
        Me.btnCancelarDev_Partidas.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarDev_Partidas.TabIndex = 58
        Me.btnCancelarDev_Partidas.UseVisualStyleBackColor = True
        '
        'lblBtnCancelar_partida
        '
        Me.lblBtnCancelar_partida.AutoSize = True
        Me.lblBtnCancelar_partida.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnCancelar_partida.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBtnCancelar_partida.Location = New System.Drawing.Point(9, 35)
        Me.lblBtnCancelar_partida.Name = "lblBtnCancelar_partida"
        Me.lblBtnCancelar_partida.Size = New System.Drawing.Size(49, 13)
        Me.lblBtnCancelar_partida.TabIndex = 57
        Me.lblBtnCancelar_partida.Text = "Cancelar"
        '
        'pnlEtiquetas
        '
        Me.pnlEtiquetas.Controls.Add(Me.btnEtiquetas)
        Me.pnlEtiquetas.Controls.Add(Me.lblEtiquetas)
        Me.pnlEtiquetas.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEtiquetas.Location = New System.Drawing.Point(342, 0)
        Me.pnlEtiquetas.Name = "pnlEtiquetas"
        Me.pnlEtiquetas.Size = New System.Drawing.Size(87, 65)
        Me.pnlEtiquetas.TabIndex = 88
        '
        'btnEtiquetas
        '
        Me.btnEtiquetas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnEtiquetas.Image = Global.Almacen.Vista.My.Resources.Resources.ImprimirEtiquetas
        Me.btnEtiquetas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEtiquetas.Location = New System.Drawing.Point(27, 3)
        Me.btnEtiquetas.Name = "btnEtiquetas"
        Me.btnEtiquetas.Size = New System.Drawing.Size(32, 32)
        Me.btnEtiquetas.TabIndex = 58
        Me.btnEtiquetas.UseVisualStyleBackColor = True
        '
        'lblEtiquetas
        '
        Me.lblEtiquetas.AutoSize = True
        Me.lblEtiquetas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEtiquetas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEtiquetas.Location = New System.Drawing.Point(5, 35)
        Me.lblEtiquetas.Name = "lblEtiquetas"
        Me.lblEtiquetas.Size = New System.Drawing.Size(76, 26)
        Me.lblEtiquetas.TabIndex = 57
        Me.lblEtiquetas.Text = "Exportar Excel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Para Etiquetas"
        Me.lblEtiquetas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlBtnActualizar
        '
        Me.pnlBtnActualizar.Controls.Add(Me.btnActualizar)
        Me.pnlBtnActualizar.Controls.Add(Me.Label3)
        Me.pnlBtnActualizar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtnActualizar.Location = New System.Drawing.Point(274, 0)
        Me.pnlBtnActualizar.Name = "pnlBtnActualizar"
        Me.pnlBtnActualizar.Size = New System.Drawing.Size(68, 65)
        Me.pnlBtnActualizar.TabIndex = 87
        '
        'btnActualizar
        '
        Me.btnActualizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnActualizar.Image = Global.Almacen.Vista.My.Resources.Resources.refresh_32
        Me.btnActualizar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnActualizar.Location = New System.Drawing.Point(18, 3)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(32, 32)
        Me.btnActualizar.TabIndex = 58
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(7, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Actualizar"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lblTitulo)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(531, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(416, 65)
        Me.Panel6.TabIndex = 86
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(132, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(278, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Devolución de Clientes - Artículos"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlBtnEliminar
        '
        Me.pnlBtnEliminar.Controls.Add(Me.btnEliminar)
        Me.pnlBtnEliminar.Controls.Add(Me.Label15)
        Me.pnlBtnEliminar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtnEliminar.Location = New System.Drawing.Point(206, 0)
        Me.pnlBtnEliminar.Name = "pnlBtnEliminar"
        Me.pnlBtnEliminar.Size = New System.Drawing.Size(68, 65)
        Me.pnlBtnEliminar.TabIndex = 85
        '
        'btnEliminar
        '
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnEliminar.Image = Global.Almacen.Vista.My.Resources.Resources.borrar_32
        Me.btnEliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEliminar.Location = New System.Drawing.Point(18, 3)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminar.TabIndex = 58
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(12, 35)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(43, 13)
        Me.Label15.TabIndex = 57
        Me.Label15.Text = "Eliminar"
        '
        'pnlBtnExportar
        '
        Me.pnlBtnExportar.Controls.Add(Me.btnExportar)
        Me.pnlBtnExportar.Controls.Add(Me.Label43)
        Me.pnlBtnExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtnExportar.Location = New System.Drawing.Point(138, 0)
        Me.pnlBtnExportar.Name = "pnlBtnExportar"
        Me.pnlBtnExportar.Size = New System.Drawing.Size(68, 65)
        Me.pnlBtnExportar.TabIndex = 84
        '
        'btnExportar
        '
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Almacen.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(18, 3)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 82
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label43.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label43.Location = New System.Drawing.Point(11, 35)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(46, 13)
        Me.Label43.TabIndex = 81
        Me.Label43.Text = "Exportar"
        '
        'pnlBtnCodigosCliente
        '
        Me.pnlBtnCodigosCliente.Controls.Add(Me.btnCodigosCliente)
        Me.pnlBtnCodigosCliente.Controls.Add(Me.Label13)
        Me.pnlBtnCodigosCliente.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtnCodigosCliente.Location = New System.Drawing.Point(70, 0)
        Me.pnlBtnCodigosCliente.Name = "pnlBtnCodigosCliente"
        Me.pnlBtnCodigosCliente.Size = New System.Drawing.Size(68, 65)
        Me.pnlBtnCodigosCliente.TabIndex = 83
        '
        'btnCodigosCliente
        '
        Me.btnCodigosCliente.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCodigosCliente.Image = CType(resources.GetObject("btnCodigosCliente.Image"), System.Drawing.Image)
        Me.btnCodigosCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCodigosCliente.Location = New System.Drawing.Point(18, 3)
        Me.btnCodigosCliente.Name = "btnCodigosCliente"
        Me.btnCodigosCliente.Size = New System.Drawing.Size(32, 32)
        Me.btnCodigosCliente.TabIndex = 56
        Me.btnCodigosCliente.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(4, 35)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 26)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "  Lectura" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de Códigos"
        '
        'pnlBtnAgregarArticulo
        '
        Me.pnlBtnAgregarArticulo.Controls.Add(Me.btnAgregarArticulo)
        Me.pnlBtnAgregarArticulo.Controls.Add(Me.Label10)
        Me.pnlBtnAgregarArticulo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtnAgregarArticulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlBtnAgregarArticulo.Name = "pnlBtnAgregarArticulo"
        Me.pnlBtnAgregarArticulo.Size = New System.Drawing.Size(70, 65)
        Me.pnlBtnAgregarArticulo.TabIndex = 47
        '
        'btnAgregarArticulo
        '
        Me.btnAgregarArticulo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAgregarArticulo.Image = Global.Almacen.Vista.My.Resources.Resources.altas_32
        Me.btnAgregarArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAgregarArticulo.Location = New System.Drawing.Point(20, 3)
        Me.btnAgregarArticulo.Name = "btnAgregarArticulo"
        Me.btnAgregarArticulo.Size = New System.Drawing.Size(32, 32)
        Me.btnAgregarArticulo.TabIndex = 54
        Me.btnAgregarArticulo.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(2, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 26)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "Artículos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Documentos"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(947, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pgrsPnlCargando
        '
        Me.pgrsPnlCargando.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgrsPnlCargando.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.pgrsPnlCargando.Appearance.Options.UseBackColor = True
        Me.pgrsPnlCargando.AppearanceDescription.Options.UseTextOptions = True
        Me.pgrsPnlCargando.AppearanceDescription.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.pgrsPnlCargando.Caption = "Espere Por Favor"
        Me.pgrsPnlCargando.Description = "Agregando Artículo..."
        Me.pgrsPnlCargando.Location = New System.Drawing.Point(384, 243)
        Me.pgrsPnlCargando.MaximumSize = New System.Drawing.Size(246, 66)
        Me.pgrsPnlCargando.MinimumSize = New System.Drawing.Size(246, 66)
        Me.pgrsPnlCargando.Name = "pgrsPnlCargando"
        Me.pgrsPnlCargando.Size = New System.Drawing.Size(246, 66)
        Me.pgrsPnlCargando.TabIndex = 269
        Me.pgrsPnlCargando.Text = "pgrsPnlCargando"
        Me.pgrsPnlCargando.Visible = False
        '
        'grdInfoEtiquetas
        '
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdInfoEtiquetas.DisplayLayout.Appearance = Appearance2
        Me.grdInfoEtiquetas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdInfoEtiquetas.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdInfoEtiquetas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdInfoEtiquetas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdInfoEtiquetas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdInfoEtiquetas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdInfoEtiquetas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdInfoEtiquetas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdInfoEtiquetas.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdInfoEtiquetas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdInfoEtiquetas.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.grdInfoEtiquetas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdInfoEtiquetas.Location = New System.Drawing.Point(0, 0)
        Me.grdInfoEtiquetas.Name = "grdInfoEtiquetas"
        Me.grdInfoEtiquetas.Size = New System.Drawing.Size(1015, 552)
        Me.grdInfoEtiquetas.TabIndex = 272
        Me.grdInfoEtiquetas.Visible = False
        '
        'cmbNave_UC
        '
        Me.cmbNave_UC.Location = New System.Drawing.Point(743, 190)
        Me.cmbNave_UC.Name = "cmbNave_UC"
        Me.cmbNave_UC.Size = New System.Drawing.Size(100, 22)
        Me.cmbNave_UC.TabIndex = 273
        '
        'cmbProcede_UC
        '
        Me.cmbProcede_UC.Location = New System.Drawing.Point(743, 243)
        Me.cmbProcede_UC.Name = "cmbProcede_UC"
        Me.cmbProcede_UC.Size = New System.Drawing.Size(100, 22)
        Me.cmbProcede_UC.TabIndex = 274
        '
        'cmbClasificacion_UC
        '
        Me.cmbClasificacion_UC.Location = New System.Drawing.Point(743, 218)
        Me.cmbClasificacion_UC.Name = "cmbClasificacion_UC"
        Me.cmbClasificacion_UC.Size = New System.Drawing.Size(100, 22)
        Me.cmbClasificacion_UC.TabIndex = 275
        '
        'DevolucionCliente_CapturaGeneral_DetallesArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1015, 552)
        Me.Controls.Add(Me.pgrsPnlCargando)
        Me.Controls.Add(Me.grdArticulosSeleccionados)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.grdInfoEtiquetas)
        Me.Controls.Add(Me.cmbClasificacion_UC)
        Me.Controls.Add(Me.cmbProcede_UC)
        Me.Controls.Add(Me.cmbNave_UC)
        Me.Name = "DevolucionCliente_CapturaGeneral_DetallesArticulos"
        Me.Text = "Devolución de Clientes - Artículos"
        CType(Me.grdArticulosSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlSeleccionModelos.ResumeLayout(False)
        Me.pnlSeleccionModelos.PerformLayout()
        CType(Me.grdParesPorTalla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlCancelar.ResumeLayout(False)
        Me.pnlCancelar.PerformLayout()
        Me.pnlEtiquetas.ResumeLayout(False)
        Me.pnlEtiquetas.PerformLayout()
        Me.pnlBtnActualizar.ResumeLayout(False)
        Me.pnlBtnActualizar.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.pnlBtnEliminar.ResumeLayout(False)
        Me.pnlBtnEliminar.PerformLayout()
        Me.pnlBtnExportar.ResumeLayout(False)
        Me.pnlBtnExportar.PerformLayout()
        Me.pnlBtnCodigosCliente.ResumeLayout(False)
        Me.pnlBtnCodigosCliente.PerformLayout()
        Me.pnlBtnAgregarArticulo.ResumeLayout(False)
        Me.pnlBtnAgregarArticulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdInfoEtiquetas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbNave_UC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbProcede_UC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbClasificacion_UC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grdArticulosSeleccionados As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel3 As Panel
    Friend WithEvents chkSeleccionarTodos As CheckBox
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents pnlBtnAgregarArticulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents lblCajas As Label
    Friend WithEvents lblCantidad As Label
    Friend WithEvents lblMonto As Label
    Friend WithEvents Label83 As Label
    Friend WithEvents lblEtiquetaMonto As Label
    Friend WithEvents lblParesCapturados As Label
    Friend WithEvents Label64 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblNumFiltrados As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblAceptar As Label
    Friend WithEvents lblCancelar As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnCodigosCliente As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnAgregarArticulo As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Button2 As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents lblFolioDevolucion As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblCliente As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents btnEliminar As Button
    Friend WithEvents lblEtiquetaNumRenglonGrid As Label
    Friend WithEvents lblNumRenglonGrid As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents grdParesPorTalla As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label19 As Label
    Friend WithEvents lblUnidadMedida As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents btnExportar As Button
    Friend WithEvents lblEtiquetaBtnAgregarArticulo As Label
    Friend WithEvents btnAgregarArticulos As Button
    Friend WithEvents cmbArticulos As ComboBox
    Friend WithEvents txtModeloSAY As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents lblModeloEncontrado As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents pnlBtnEliminar As Panel
    Friend WithEvents pnlBtnExportar As Panel
    Friend WithEvents pnlBtnCodigosCliente As Panel
    Friend WithEvents pgrsPnlCargando As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents pnlBtnActualizar As Panel
    Friend WithEvents btnCancelarDev_Partidas As Button
    Friend WithEvents lblBtnCancelar_partida As Label
    Friend WithEvents pnlEtiquetas As Panel
    Friend WithEvents btnActualizar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlCancelar As Panel
    Friend WithEvents btnEtiquetas As Button
    Friend WithEvents lblEtiquetas As Label
    Friend WithEvents grdInfoEtiquetas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmbNave_UC As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmbProcede_UC As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmbClasificacion_UC As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents pnlSeleccionModelos As Panel
    Friend WithEvents rdbModeloSICY As RadioButton
    Friend WithEvents rdbModeloSAY As RadioButton
End Class
