<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoParametrosReportesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListadoParametrosReportesForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.chboxMarcarTodo = New System.Windows.Forms.CheckBox()
        Me.pnlMarcarTodo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.pnlListaCliente = New System.Windows.Forms.Panel()
        Me.gridListadoParametros = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlTipoFiltroCliente = New System.Windows.Forms.Panel()
        Me.rdbTodos = New System.Windows.Forms.RadioButton()
        Me.rdbInactivos = New System.Windows.Forms.RadioButton()
        Me.rdbActivos = New System.Windows.Forms.RadioButton()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMarcarTodo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlListaCliente.SuspendLayout()
        CType(Me.gridListadoParametros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTipoFiltroCliente.SuspendLayout()
        Me.pnlContenedor.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(491, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'chboxMarcarTodo
        '
        Me.chboxMarcarTodo.AutoSize = True
        Me.chboxMarcarTodo.Location = New System.Drawing.Point(7, 11)
        Me.chboxMarcarTodo.Name = "chboxMarcarTodo"
        Me.chboxMarcarTodo.Size = New System.Drawing.Size(106, 17)
        Me.chboxMarcarTodo.TabIndex = 0
        Me.chboxMarcarTodo.Text = "Seleccionar todo"
        Me.chboxMarcarTodo.UseVisualStyleBackColor = True
        '
        'pnlMarcarTodo
        '
        Me.pnlMarcarTodo.Controls.Add(Me.chboxMarcarTodo)
        Me.pnlMarcarTodo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlMarcarTodo.Location = New System.Drawing.Point(0, 0)
        Me.pnlMarcarTodo.Name = "pnlMarcarTodo"
        Me.pnlMarcarTodo.Size = New System.Drawing.Size(183, 41)
        Me.pnlMarcarTodo.TabIndex = 47
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlMarcarTodo)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(491, 41)
        Me.Panel1.TabIndex = 47
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(302, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(189, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Listado de parámetros"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(559, 59)
        Me.pnlTitulo.TabIndex = 20
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(559, 59)
        Me.pnlEncabezado.TabIndex = 25
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
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(14, 43)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(63, 13)
        Me.lblAceptar.TabIndex = 0
        Me.lblAceptar.Text = "Seleccionar"
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
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlEncabezado)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(559, 59)
        Me.pnlCabecera.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(27, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 24)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Registros"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Ventas.Vista.My.Resources.Resources.aceptar_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(29, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 18)
        Me.Label5.TabIndex = 117
        Me.Label5.Text = "Seleccionados"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(415, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(144, 71)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 337)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(559, 71)
        Me.pnlPie.TabIndex = 64
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(24, 42)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 24)
        Me.lblNumFiltrados.TabIndex = 116
        Me.lblNumFiltrados.Text = "0"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlListaCliente
        '
        Me.pnlListaCliente.Controls.Add(Me.gridListadoParametros)
        Me.pnlListaCliente.Controls.Add(Me.pnlTipoFiltroCliente)
        Me.pnlListaCliente.Controls.Add(Me.pnlPie)
        Me.pnlListaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListaCliente.Location = New System.Drawing.Point(0, 59)
        Me.pnlListaCliente.Name = "pnlListaCliente"
        Me.pnlListaCliente.Size = New System.Drawing.Size(559, 408)
        Me.pnlListaCliente.TabIndex = 3
        '
        'gridListadoParametros
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListadoParametros.DisplayLayout.Appearance = Appearance1
        Me.gridListadoParametros.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridListadoParametros.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListadoParametros.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListadoParametros.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.gridListadoParametros.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListadoParametros.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListadoParametros.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListadoParametros.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridListadoParametros.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListadoParametros.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListadoParametros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListadoParametros.Location = New System.Drawing.Point(0, 25)
        Me.gridListadoParametros.Name = "gridListadoParametros"
        Me.gridListadoParametros.Size = New System.Drawing.Size(559, 312)
        Me.gridListadoParametros.TabIndex = 66
        '
        'pnlTipoFiltroCliente
        '
        Me.pnlTipoFiltroCliente.Controls.Add(Me.rdbTodos)
        Me.pnlTipoFiltroCliente.Controls.Add(Me.rdbInactivos)
        Me.pnlTipoFiltroCliente.Controls.Add(Me.rdbActivos)
        Me.pnlTipoFiltroCliente.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTipoFiltroCliente.Location = New System.Drawing.Point(0, 0)
        Me.pnlTipoFiltroCliente.Name = "pnlTipoFiltroCliente"
        Me.pnlTipoFiltroCliente.Size = New System.Drawing.Size(559, 25)
        Me.pnlTipoFiltroCliente.TabIndex = 65
        Me.pnlTipoFiltroCliente.Visible = False
        '
        'rdbTodos
        '
        Me.rdbTodos.AutoSize = True
        Me.rdbTodos.Location = New System.Drawing.Point(492, 3)
        Me.rdbTodos.Name = "rdbTodos"
        Me.rdbTodos.Size = New System.Drawing.Size(55, 17)
        Me.rdbTodos.TabIndex = 0
        Me.rdbTodos.Text = "Todos"
        Me.rdbTodos.UseVisualStyleBackColor = True
        '
        'rdbInactivos
        '
        Me.rdbInactivos.AutoSize = True
        Me.rdbInactivos.Location = New System.Drawing.Point(418, 3)
        Me.rdbInactivos.Name = "rdbInactivos"
        Me.rdbInactivos.Size = New System.Drawing.Size(68, 17)
        Me.rdbInactivos.TabIndex = 0
        Me.rdbInactivos.Text = "Inactivos"
        Me.rdbInactivos.UseVisualStyleBackColor = True
        '
        'rdbActivos
        '
        Me.rdbActivos.AutoSize = True
        Me.rdbActivos.Location = New System.Drawing.Point(352, 3)
        Me.rdbActivos.Name = "rdbActivos"
        Me.rdbActivos.Size = New System.Drawing.Size(60, 17)
        Me.rdbActivos.TabIndex = 0
        Me.rdbActivos.Text = "Activos"
        Me.rdbActivos.UseVisualStyleBackColor = True
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlListaCliente)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(559, 467)
        Me.pnlContenedor.TabIndex = 5
        '
        'ListadoParametrosReportesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 467)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ListadoParametrosReportesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMarcarTodo.ResumeLayout(False)
        Me.pnlMarcarTodo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlListaCliente.ResumeLayout(False)
        CType(Me.gridListadoParametros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTipoFiltroCliente.ResumeLayout(False)
        Me.pnlTipoFiltroCliente.PerformLayout()
        Me.pnlContenedor.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents chboxMarcarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents pnlMarcarTodo As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents lblNumFiltrados As System.Windows.Forms.Label
    Friend WithEvents pnlListaCliente As System.Windows.Forms.Panel
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents pnlTipoFiltroCliente As System.Windows.Forms.Panel
    Friend WithEvents rdbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rdbInactivos As System.Windows.Forms.RadioButton
    Friend WithEvents rdbActivos As System.Windows.Forms.RadioButton
    Friend WithEvents gridListadoParametros As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
