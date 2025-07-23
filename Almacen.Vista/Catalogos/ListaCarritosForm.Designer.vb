<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaCarritosForm
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
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.gboxContenido = New System.Windows.Forms.GroupBox()
        Me.gridListaCarritos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gboxFiltros = New System.Windows.Forms.GroupBox()
        Me.chboxMarcarTodo = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnImprimirCodigo = New System.Windows.Forms.Button()
        Me.cboxAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboxNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbtnEstatusInactivo = New System.Windows.Forms.RadioButton()
        Me.rbtnEstatusActivo = New System.Windows.Forms.RadioButton()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblActivoPais = New System.Windows.Forms.Label()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.lblAltaEstados = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.pnlContenedor.SuspendLayout()
        Me.gboxContenido.SuspendLayout()
        CType(Me.gridListaCarritos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxFiltros.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.gboxContenido)
        Me.pnlContenedor.Controls.Add(Me.gboxFiltros)
        Me.pnlContenedor.Controls.Add(Me.pnlListaPaises)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(450, 507)
        Me.pnlContenedor.TabIndex = 0
        '
        'gboxContenido
        '
        Me.gboxContenido.Controls.Add(Me.gridListaCarritos)
        Me.gboxContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxContenido.Location = New System.Drawing.Point(0, 198)
        Me.gboxContenido.Name = "gboxContenido"
        Me.gboxContenido.Size = New System.Drawing.Size(450, 309)
        Me.gboxContenido.TabIndex = 12
        Me.gboxContenido.TabStop = False
        '
        'gridListaCarritos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaCarritos.DisplayLayout.Appearance = Appearance1
        Me.gridListaCarritos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridListaCarritos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCarritos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaCarritos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaCarritos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaCarritos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaCarritos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListaCarritos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridListaCarritos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListaCarritos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaCarritos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaCarritos.Location = New System.Drawing.Point(3, 16)
        Me.gridListaCarritos.Name = "gridListaCarritos"
        Me.gridListaCarritos.Size = New System.Drawing.Size(444, 290)
        Me.gridListaCarritos.TabIndex = 65
        '
        'gboxFiltros
        '
        Me.gboxFiltros.Controls.Add(Me.chboxMarcarTodo)
        Me.gboxFiltros.Controls.Add(Me.Label2)
        Me.gboxFiltros.Controls.Add(Me.btnImprimirCodigo)
        Me.gboxFiltros.Controls.Add(Me.cboxAlmacen)
        Me.gboxFiltros.Controls.Add(Me.Label1)
        Me.gboxFiltros.Controls.Add(Me.cboxNave)
        Me.gboxFiltros.Controls.Add(Me.lblNave)
        Me.gboxFiltros.Controls.Add(Me.Panel1)
        Me.gboxFiltros.Controls.Add(Me.lblLimpiar)
        Me.gboxFiltros.Controls.Add(Me.lblBuscar)
        Me.gboxFiltros.Controls.Add(Me.btnLimpiar)
        Me.gboxFiltros.Controls.Add(Me.btnMostrar)
        Me.gboxFiltros.Controls.Add(Me.lblActivoPais)
        Me.gboxFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.gboxFiltros.Location = New System.Drawing.Point(0, 60)
        Me.gboxFiltros.Name = "gboxFiltros"
        Me.gboxFiltros.Size = New System.Drawing.Size(450, 138)
        Me.gboxFiltros.TabIndex = 10
        Me.gboxFiltros.TabStop = False
        '
        'chboxMarcarTodo
        '
        Me.chboxMarcarTodo.AutoSize = True
        Me.chboxMarcarTodo.Location = New System.Drawing.Point(15, 115)
        Me.chboxMarcarTodo.Name = "chboxMarcarTodo"
        Me.chboxMarcarTodo.Size = New System.Drawing.Size(106, 17)
        Me.chboxMarcarTodo.TabIndex = 20
        Me.chboxMarcarTodo.Text = "Seleccionar todo"
        Me.chboxMarcarTodo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(397, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 26)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Imprimir" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Código"
        '
        'btnImprimirCodigo
        '
        Me.btnImprimirCodigo.BackgroundImage = Global.Almacen.Vista.My.Resources.imprimir_qr_32
        Me.btnImprimirCodigo.Location = New System.Drawing.Point(402, 71)
        Me.btnImprimirCodigo.Name = "btnImprimirCodigo"
        Me.btnImprimirCodigo.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimirCodigo.TabIndex = 18
        Me.btnImprimirCodigo.UseVisualStyleBackColor = True
        '
        'cboxAlmacen
        '
        Me.cboxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxAlmacen.FormattingEnabled = True
        Me.cboxAlmacen.Location = New System.Drawing.Point(72, 47)
        Me.cboxAlmacen.Name = "cboxAlmacen"
        Me.cboxAlmacen.Size = New System.Drawing.Size(172, 21)
        Me.cboxAlmacen.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Almacén"
        '
        'cboxNave
        '
        Me.cboxNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxNave.FormattingEnabled = True
        Me.cboxNave.Location = New System.Drawing.Point(72, 19)
        Me.cboxNave.Name = "cboxNave"
        Me.cboxNave.Size = New System.Drawing.Size(172, 21)
        Me.cboxNave.TabIndex = 1
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(12, 23)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 15
        Me.lblNave.Text = "Nave"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbtnEstatusInactivo)
        Me.Panel1.Controls.Add(Me.rbtnEstatusActivo)
        Me.Panel1.Location = New System.Drawing.Point(72, 73)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(94, 30)
        Me.Panel1.TabIndex = 14
        '
        'rbtnEstatusInactivo
        '
        Me.rbtnEstatusInactivo.AutoSize = True
        Me.rbtnEstatusInactivo.Location = New System.Drawing.Point(52, 7)
        Me.rbtnEstatusInactivo.Name = "rbtnEstatusInactivo"
        Me.rbtnEstatusInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rbtnEstatusInactivo.TabIndex = 4
        Me.rbtnEstatusInactivo.TabStop = True
        Me.rbtnEstatusInactivo.Text = "No"
        Me.rbtnEstatusInactivo.UseVisualStyleBackColor = True
        '
        'rbtnEstatusActivo
        '
        Me.rbtnEstatusActivo.AutoSize = True
        Me.rbtnEstatusActivo.Checked = True
        Me.rbtnEstatusActivo.Location = New System.Drawing.Point(3, 7)
        Me.rbtnEstatusActivo.Name = "rbtnEstatusActivo"
        Me.rbtnEstatusActivo.Size = New System.Drawing.Size(34, 17)
        Me.rbtnEstatusActivo.TabIndex = 3
        Me.rbtnEstatusActivo.TabStop = True
        Me.rbtnEstatusActivo.Text = "Si"
        Me.rbtnEstatusActivo.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(349, 105)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 8
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(300, 105)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 7
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.Almacen.Vista.My.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(352, 71)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 6
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.BackgroundImage = Global.Almacen.Vista.My.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(305, 71)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 5
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblActivoPais
        '
        Me.lblActivoPais.AutoSize = True
        Me.lblActivoPais.Location = New System.Drawing.Point(10, 82)
        Me.lblActivoPais.Name = "lblActivoPais"
        Me.lblActivoPais.Size = New System.Drawing.Size(37, 13)
        Me.lblActivoPais.TabIndex = 2
        Me.lblActivoPais.Text = "Activo"
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.imgLogo)
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Controls.Add(Me.lblEditar)
        Me.pnlListaPaises.Controls.Add(Me.lblAltaEstados)
        Me.pnlListaPaises.Controls.Add(Me.btnEditar)
        Me.pnlListaPaises.Controls.Add(Me.btnAlta)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(450, 60)
        Me.pnlListaPaises.TabIndex = 8
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Almacen.Vista.My.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(380, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 7
        Me.imgLogo.TabStop = False
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(189, 19)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(193, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Listado de plataformas"
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(63, 40)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 4
        Me.lblEditar.Text = "Editar"
        '
        'lblAltaEstados
        '
        Me.lblAltaEstados.AutoSize = True
        Me.lblAltaEstados.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltaEstados.Location = New System.Drawing.Point(16, 40)
        Me.lblAltaEstados.Name = "lblAltaEstados"
        Me.lblAltaEstados.Size = New System.Drawing.Size(30, 13)
        Me.lblAltaEstados.TabIndex = 3
        Me.lblAltaEstados.Text = "Altas"
        '
        'btnEditar
        '
        Me.btnEditar.BackgroundImage = Global.Almacen.Vista.My.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(64, 7)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 2
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAlta
        '
        Me.btnAlta.BackgroundImage = Global.Almacen.Vista.My.Resources.altas_32
        Me.btnAlta.Location = New System.Drawing.Point(14, 7)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(31, 32)
        Me.btnAlta.TabIndex = 1
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'ListaCarritosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 507)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(466, 546)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(466, 546)
        Me.Name = "ListaCarritosForm"
        Me.Text = "Listado de plataformas"
        Me.pnlContenedor.ResumeLayout(False)
        Me.gboxContenido.ResumeLayout(False)
        CType(Me.gridListaCarritos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxFiltros.ResumeLayout(False)
        Me.gboxFiltros.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents lblAltaEstados As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnAlta As System.Windows.Forms.Button
    Friend WithEvents gboxFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbtnEstatusInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnEstatusActivo As System.Windows.Forms.RadioButton
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblActivoPais As System.Windows.Forms.Label
    Friend WithEvents cboxNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cboxAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gboxContenido As System.Windows.Forms.GroupBox
    Friend WithEvents gridListaCarritos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnImprimirCodigo As System.Windows.Forms.Button
    Friend WithEvents chboxMarcarTodo As System.Windows.Forms.CheckBox
End Class
