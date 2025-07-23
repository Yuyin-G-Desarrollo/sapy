<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgenteMarcaFamiliaVentasForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgenteMarcaFamiliaVentasForm))
        Me.gpbCampos = New System.Windows.Forms.GroupBox()
        Me.lblCoord = New System.Windows.Forms.Label()
        Me.cbxCoordinador = New System.Windows.Forms.ComboBox()
        Me.cmbMarcas = New System.Windows.Forms.ComboBox()
        Me.lblMarcaNombre = New System.Windows.Forms.Label()
        Me.lblAgenteSicy = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbAgente = New System.Windows.Forms.ComboBox()
        Me.lblCargo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTotalSeleccionados = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblEliminar = New System.Windows.Forms.Label()
        Me.btnMostrarTodo = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdMarcaFamilia = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.chkSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.gpbCampos.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdMarcaFamilia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpbCampos
        '
        Me.gpbCampos.Controls.Add(Me.lblCoord)
        Me.gpbCampos.Controls.Add(Me.cbxCoordinador)
        Me.gpbCampos.Controls.Add(Me.cmbMarcas)
        Me.gpbCampos.Controls.Add(Me.lblMarcaNombre)
        Me.gpbCampos.Controls.Add(Me.lblAgenteSicy)
        Me.gpbCampos.Controls.Add(Me.Label1)
        Me.gpbCampos.Controls.Add(Me.cmbAgente)
        Me.gpbCampos.Controls.Add(Me.lblCargo)
        Me.gpbCampos.Location = New System.Drawing.Point(15, 76)
        Me.gpbCampos.Name = "gpbCampos"
        Me.gpbCampos.Size = New System.Drawing.Size(624, 119)
        Me.gpbCampos.TabIndex = 26
        Me.gpbCampos.TabStop = False
        Me.gpbCampos.Text = "Seleccione las marcas, las familias de ventas y el agente al que desee asignarle"
        '
        'lblCoord
        '
        Me.lblCoord.AutoSize = True
        Me.lblCoord.Location = New System.Drawing.Point(9, 92)
        Me.lblCoord.Name = "lblCoord"
        Me.lblCoord.Size = New System.Drawing.Size(71, 13)
        Me.lblCoord.TabIndex = 127
        Me.lblCoord.Text = "* Coordinador"
        '
        'cbxCoordinador
        '
        Me.cbxCoordinador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbxCoordinador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxCoordinador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCoordinador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cbxCoordinador.FormattingEnabled = True
        Me.cbxCoordinador.Location = New System.Drawing.Point(86, 88)
        Me.cbxCoordinador.Name = "cbxCoordinador"
        Me.cbxCoordinador.Size = New System.Drawing.Size(336, 21)
        Me.cbxCoordinador.TabIndex = 126
        '
        'cmbMarcas
        '
        Me.cmbMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarcas.FormattingEnabled = True
        Me.cmbMarcas.Location = New System.Drawing.Point(86, 25)
        Me.cmbMarcas.Name = "cmbMarcas"
        Me.cmbMarcas.Size = New System.Drawing.Size(336, 21)
        Me.cmbMarcas.TabIndex = 7
        '
        'lblMarcaNombre
        '
        Me.lblMarcaNombre.AutoSize = True
        Me.lblMarcaNombre.Location = New System.Drawing.Point(32, 25)
        Me.lblMarcaNombre.Name = "lblMarcaNombre"
        Me.lblMarcaNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblMarcaNombre.TabIndex = 6
        Me.lblMarcaNombre.Text = "* Marca"
        '
        'lblAgenteSicy
        '
        Me.lblAgenteSicy.AutoSize = True
        Me.lblAgenteSicy.Location = New System.Drawing.Point(530, 28)
        Me.lblAgenteSicy.Name = "lblAgenteSicy"
        Me.lblAgenteSicy.Size = New System.Drawing.Size(0, 13)
        Me.lblAgenteSicy.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(453, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Agente SICY:"
        '
        'cmbAgente
        '
        Me.cmbAgente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAgente.FormattingEnabled = True
        Me.cmbAgente.Location = New System.Drawing.Point(86, 57)
        Me.cmbAgente.Name = "cmbAgente"
        Me.cmbAgente.Size = New System.Drawing.Size(336, 21)
        Me.cmbAgente.TabIndex = 2
        '
        'lblCargo
        '
        Me.lblCargo.AutoSize = True
        Me.lblCargo.Location = New System.Drawing.Point(32, 60)
        Me.lblCargo.Name = "lblCargo"
        Me.lblCargo.Size = New System.Drawing.Size(48, 13)
        Me.lblCargo.TabIndex = 3
        Me.lblCargo.Text = "* Agente"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.lblTotalSeleccionados)
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 515)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(645, 69)
        Me.pnlPie.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 32)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "   Familias " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccionadas"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalSeleccionados
        '
        Me.lblTotalSeleccionados.AutoSize = True
        Me.lblTotalSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSeleccionados.Location = New System.Drawing.Point(54, 39)
        Me.lblTotalSeleccionados.Name = "lblTotalSeleccionados"
        Me.lblTotalSeleccionados.Size = New System.Drawing.Size(17, 18)
        Me.lblTotalSeleccionados.TabIndex = 71
        Me.lblTotalSeleccionados.Text = "0"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnEliminar)
        Me.pnlAcciones.Controls.Add(Me.lblEliminar)
        Me.pnlAcciones.Controls.Add(Me.btnMostrarTodo)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.Label2)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(430, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(215, 69)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Ventas.Vista.My.Resources.Resources.borrar_32
        Me.btnEliminar.Location = New System.Drawing.Point(27, 8)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminar.TabIndex = 17
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'lblEliminar
        '
        Me.lblEliminar.AutoSize = True
        Me.lblEliminar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEliminar.Location = New System.Drawing.Point(22, 44)
        Me.lblEliminar.Name = "lblEliminar"
        Me.lblEliminar.Size = New System.Drawing.Size(43, 13)
        Me.lblEliminar.TabIndex = 18
        Me.lblEliminar.Text = "Eliminar"
        '
        'btnMostrarTodo
        '
        Me.btnMostrarTodo.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrarTodo.Location = New System.Drawing.Point(73, 7)
        Me.btnMostrarTodo.Name = "btnMostrarTodo"
        Me.btnMostrarTodo.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrarTodo.TabIndex = 16
        Me.btnMostrarTodo.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(119, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(70, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 26)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Mostrar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Todo"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(114, 43)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 15
        Me.lblGuardar.Text = "Guardar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(167, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(167, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(645, 60)
        Me.pnlEncabezado.TabIndex = 24
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(229, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(416, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(62, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(292, 20)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Agente - Marca - Familia de Ventas"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.chkSeleccionarTodo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 223)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(627, 286)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Marcas - Familia de Ventas"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdMarcaFamilia)
        Me.Panel2.Location = New System.Drawing.Point(6, 42)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(612, 238)
        Me.Panel2.TabIndex = 1
        '
        'grdMarcaFamilia
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMarcaFamilia.DisplayLayout.Appearance = Appearance1
        Me.grdMarcaFamilia.DisplayLayout.GroupByBox.Hidden = True
        Me.grdMarcaFamilia.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.grdMarcaFamilia.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdMarcaFamilia.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdMarcaFamilia.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdMarcaFamilia.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdMarcaFamilia.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdMarcaFamilia.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMarcaFamilia.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdMarcaFamilia.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdMarcaFamilia.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdMarcaFamilia.Location = New System.Drawing.Point(3, 3)
        Me.grdMarcaFamilia.Name = "grdMarcaFamilia"
        Me.grdMarcaFamilia.Size = New System.Drawing.Size(609, 232)
        Me.grdMarcaFamilia.TabIndex = 9
        '
        'chkSeleccionarTodo
        '
        Me.chkSeleccionarTodo.AutoSize = True
        Me.chkSeleccionarTodo.Location = New System.Drawing.Point(6, 19)
        Me.chkSeleccionarTodo.Name = "chkSeleccionarTodo"
        Me.chkSeleccionarTodo.Size = New System.Drawing.Size(106, 17)
        Me.chkSeleccionarTodo.TabIndex = 0
        Me.chkSeleccionarTodo.Text = "Seleccionar todo"
        Me.chkSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(348, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AgenteMarcaFamiliaVentasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(645, 584)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpbCampos)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AgenteMarcaFamiliaVentasForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agente - Marca - Familia de Ventas"
        Me.gpbCampos.ResumeLayout(False)
        Me.gpbCampos.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdMarcaFamilia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpbCampos As System.Windows.Forms.GroupBox
    Friend WithEvents cmbAgente As System.Windows.Forms.ComboBox
    Friend WithEvents lblCargo As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblAgenteSicy As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTotalSeleccionados As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grdMarcaFamilia As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents chkSeleccionarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents lblMarcaNombre As System.Windows.Forms.Label
    Friend WithEvents cmbMarcas As System.Windows.Forms.ComboBox
    Friend WithEvents btnMostrarTodo As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCoord As Label
    Friend WithEvents cbxCoordinador As ComboBox
    Friend WithEvents btnEliminar As Button
    Friend WithEvents lblEliminar As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
