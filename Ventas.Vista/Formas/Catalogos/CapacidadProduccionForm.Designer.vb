<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CapacidadProduccionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CapacidadProduccionForm))
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnExpImp = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnImpCod = New System.Windows.Forms.Button()
        Me.lblAltaEstados = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlEstatusPedido = New System.Windows.Forms.Panel()
        Me.pnlConteo = New System.Windows.Forms.Panel()
        Me.lblRegistrosTitulo = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblFechaUltimaActualización = New System.Windows.Forms.Label()
        Me.lblLabelUltimaActualizacion = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbAnios = New System.Windows.Forms.ComboBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdCapacidadProduccion = New DevExpress.XtraGrid.GridControl()
        Me.grdDatosCapacidadProduccion = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.pnlListaPaises.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlConteo.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdCapacidadProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatosCapacidadProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.Panel2)
        Me.pnlListaPaises.Controls.Add(Me.Panel1)
        Me.pnlListaPaises.Controls.Add(Me.imgLogo)
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(800, 60)
        Me.pnlListaPaises.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnExpImp)
        Me.Panel2.Controls.Add(Me.lblEditar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(63, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(63, 60)
        Me.Panel2.TabIndex = 35
        '
        'btnExpImp
        '
        Me.btnExpImp.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnExpImp.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExpImp.Location = New System.Drawing.Point(15, 9)
        Me.btnExpImp.Name = "btnExpImp"
        Me.btnExpImp.Size = New System.Drawing.Size(32, 32)
        Me.btnExpImp.TabIndex = 29
        Me.btnExpImp.UseVisualStyleBackColor = False
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(13, 42)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(46, 13)
        Me.lblEditar.TabIndex = 11
        Me.lblEditar.Text = "Exportar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnImpCod)
        Me.Panel1.Controls.Add(Me.lblAltaEstados)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(63, 60)
        Me.Panel1.TabIndex = 34
        '
        'btnImpCod
        '
        Me.btnImpCod.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnImpCod.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnImpCod.Location = New System.Drawing.Point(14, 9)
        Me.btnImpCod.Name = "btnImpCod"
        Me.btnImpCod.Size = New System.Drawing.Size(32, 32)
        Me.btnImpCod.TabIndex = 28
        Me.btnImpCod.UseVisualStyleBackColor = False
        '
        'lblAltaEstados
        '
        Me.lblAltaEstados.AutoSize = True
        Me.lblAltaEstados.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltaEstados.Location = New System.Drawing.Point(15, 42)
        Me.lblAltaEstados.Name = "lblAltaEstados"
        Me.lblAltaEstados.Size = New System.Drawing.Size(45, 13)
        Me.lblAltaEstados.TabIndex = 10
        Me.lblAltaEstados.Text = "Importar"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
        Me.imgLogo.Location = New System.Drawing.Point(730, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 7
        Me.imgLogo.TabStop = False
        '
        'lblEncabezado
        '
        Me.lblEncabezado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(506, 21)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(213, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Capacidad de Producciòn"
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.pnlEstatusPedido)
        Me.pnlPie.Controls.Add(Me.pnlConteo)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 387)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(800, 63)
        Me.pnlPie.TabIndex = 162
        '
        'pnlEstatusPedido
        '
        Me.pnlEstatusPedido.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEstatusPedido.Location = New System.Drawing.Point(107, 0)
        Me.pnlEstatusPedido.Name = "pnlEstatusPedido"
        Me.pnlEstatusPedido.Size = New System.Drawing.Size(121, 63)
        Me.pnlEstatusPedido.TabIndex = 187
        '
        'pnlConteo
        '
        Me.pnlConteo.Controls.Add(Me.lblRegistrosTitulo)
        Me.pnlConteo.Controls.Add(Me.lblRegistros)
        Me.pnlConteo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlConteo.Location = New System.Drawing.Point(0, 0)
        Me.pnlConteo.Name = "pnlConteo"
        Me.pnlConteo.Size = New System.Drawing.Size(107, 63)
        Me.pnlConteo.TabIndex = 186
        '
        'lblRegistrosTitulo
        '
        Me.lblRegistrosTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistrosTitulo.ForeColor = System.Drawing.Color.Black
        Me.lblRegistrosTitulo.Location = New System.Drawing.Point(11, 8)
        Me.lblRegistrosTitulo.Name = "lblRegistrosTitulo"
        Me.lblRegistrosTitulo.Size = New System.Drawing.Size(86, 23)
        Me.lblRegistrosTitulo.TabIndex = 183
        Me.lblRegistrosTitulo.Text = "Registros"
        Me.lblRegistrosTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRegistros
        '
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRegistros.Location = New System.Drawing.Point(11, 34)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(86, 22)
        Me.lblRegistros.TabIndex = 184
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.lblFechaUltimaActualización)
        Me.pnlDatosBotones.Controls.Add(Me.lblLabelUltimaActualizacion)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(567, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(233, 63)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnAceptar
        '
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Ventas.Vista.My.Resources.Resources.enviarcalculo_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(141, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 163
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(135, 40)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(44, 13)
        Me.lblAceptar.TabIndex = 162
        Me.lblAceptar.Text = "Aceptar"
        '
        'lblFechaUltimaActualización
        '
        Me.lblFechaUltimaActualización.AutoSize = True
        Me.lblFechaUltimaActualización.Location = New System.Drawing.Point(8, 31)
        Me.lblFechaUltimaActualización.Name = "lblFechaUltimaActualización"
        Me.lblFechaUltimaActualización.Size = New System.Drawing.Size(68, 13)
        Me.lblFechaUltimaActualización.TabIndex = 160
        Me.lblFechaUltimaActualización.Text = "--/--/---- --:--:--"
        '
        'lblLabelUltimaActualizacion
        '
        Me.lblLabelUltimaActualizacion.AutoSize = True
        Me.lblLabelUltimaActualizacion.Location = New System.Drawing.Point(16, 13)
        Me.lblLabelUltimaActualizacion.Name = "lblLabelUltimaActualizacion"
        Me.lblLabelUltimaActualizacion.Size = New System.Drawing.Size(102, 13)
        Me.lblLabelUltimaActualizacion.TabIndex = 159
        Me.lblLabelUltimaActualizacion.Text = "Última Actualización"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(189, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(188, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel4.Controls.Add(Me.btnAbajo)
        Me.Panel4.Controls.Add(Me.btnArriba)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 60)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(800, 31)
        Me.Panel4.TabIndex = 163
        '
        'btnAbajo
        '
        Me.btnAbajo.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(768, 6)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 9
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(729, 6)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 8
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.GroupBox1)
        Me.pnlParametros.Controls.Add(Me.Label1)
        Me.pnlParametros.Controls.Add(Me.btnLimpiar)
        Me.pnlParametros.Controls.Add(Me.lblBúscar)
        Me.pnlParametros.Controls.Add(Me.btnBuscar)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 91)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(800, 49)
        Me.pnlParametros.TabIndex = 164
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbAnios)
        Me.GroupBox1.Controls.Add(Me.lblCliente)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(162, 43)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Año"
        '
        'cmbAnios
        '
        Me.cmbAnios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnios.FormattingEnabled = True
        Me.cmbAnios.Location = New System.Drawing.Point(63, 16)
        Me.cmbAnios.Name = "cmbAnios"
        Me.cmbAnios.Size = New System.Drawing.Size(82, 21)
        Me.cmbAnios.TabIndex = 39
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(31, 19)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(26, 13)
        Me.lblCliente.TabIndex = 38
        Me.lblCliente.Text = "Año"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(755, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(758, 2)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 40
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblBúscar
        '
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(709, 34)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBúscar.TabIndex = 32
        Me.lblBúscar.Text = "Mostrar"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(717, 2)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 29
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grdCapacidadProduccion)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 140)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(800, 247)
        Me.Panel3.TabIndex = 165
        '
        'grdCapacidadProduccion
        '
        Me.grdCapacidadProduccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCapacidadProduccion.Location = New System.Drawing.Point(0, 0)
        Me.grdCapacidadProduccion.MainView = Me.grdDatosCapacidadProduccion
        Me.grdCapacidadProduccion.Name = "grdCapacidadProduccion"
        Me.grdCapacidadProduccion.Size = New System.Drawing.Size(800, 247)
        Me.grdCapacidadProduccion.TabIndex = 164
        Me.grdCapacidadProduccion.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdDatosCapacidadProduccion})
        '
        'grdDatosCapacidadProduccion
        '
        Me.grdDatosCapacidadProduccion.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatosCapacidadProduccion.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grdDatosCapacidadProduccion.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grdDatosCapacidadProduccion.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.grdDatosCapacidadProduccion.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatosCapacidadProduccion.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.grdDatosCapacidadProduccion.Appearance.SelectedRow.Options.UseBackColor = True
        Me.grdDatosCapacidadProduccion.Appearance.SelectedRow.Options.UseForeColor = True
        Me.grdDatosCapacidadProduccion.GridControl = Me.grdCapacidadProduccion
        Me.grdDatosCapacidadProduccion.IndicatorWidth = 30
        Me.grdDatosCapacidadProduccion.Name = "grdDatosCapacidadProduccion"
        Me.grdDatosCapacidadProduccion.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatosCapacidadProduccion.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatosCapacidadProduccion.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdDatosCapacidadProduccion.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.grdDatosCapacidadProduccion.OptionsPrint.AllowMultilineHeaders = True
        Me.grdDatosCapacidadProduccion.OptionsSelection.MultiSelect = True
        Me.grdDatosCapacidadProduccion.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdDatosCapacidadProduccion.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.grdDatosCapacidadProduccion.OptionsView.ShowAutoFilterRow = True
        Me.grdDatosCapacidadProduccion.OptionsView.ShowFooter = True
        '
        'CapacidadProduccionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CapacidadProduccionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Capacidad de Producciòn"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlConteo.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdCapacidadProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatosCapacidadProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlListaPaises As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblEditar As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblAltaEstados As Label
    Friend WithEvents imgLogo As PictureBox
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlEstatusPedido As Panel
    Friend WithEvents pnlConteo As Panel
    Friend WithEvents lblRegistrosTitulo As Label
    Friend WithEvents lblRegistros As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnAceptar As Button
    Friend WithEvents lblAceptar As Label
    Friend WithEvents lblFechaUltimaActualización As Label
    Friend WithEvents lblLabelUltimaActualizacion As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnArriba As Button
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents lblBúscar As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents cmbAnios As ComboBox
    Friend WithEvents btnImpCod As Button
    Friend WithEvents btnExpImp As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents grdCapacidadProduccion As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdDatosCapacidadProduccion As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblCliente As Label
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
End Class
