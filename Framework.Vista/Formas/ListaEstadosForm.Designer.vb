<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaEstadosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaEstadosForm))
        Me.grdFiltroEstado = New System.Windows.Forms.DataGridView()
        Me.gpbFiltroPaises = New System.Windows.Forms.GroupBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiarEstado = New System.Windows.Forms.Button()
        Me.btnFiltrarEstado = New System.Windows.Forms.Button()
        Me.lblActivoPais = New System.Windows.Forms.Label()
        Me.txtAltaEstado = New System.Windows.Forms.TextBox()
        Me.lblNombreEstado = New System.Windows.Forms.Label()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.lblAltaEstados = New System.Windows.Forms.Label()
        Me.btnEditarEstados = New System.Windows.Forms.Button()
        Me.btnAltaEstados = New System.Windows.Forms.Button()
        CType(Me.grdFiltroEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbFiltroPaises.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdFiltroEstado
        '
        Me.grdFiltroEstado.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.grdFiltroEstado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFiltroEstado.Location = New System.Drawing.Point(8, 207)
        Me.grdFiltroEstado.MultiSelect = False
        Me.grdFiltroEstado.Name = "grdFiltroEstado"
        Me.grdFiltroEstado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdFiltroEstado.Size = New System.Drawing.Size(434, 288)
        Me.grdFiltroEstado.TabIndex = 4
        '
        'gpbFiltroPaises
        '
        Me.gpbFiltroPaises.Controls.Add(Me.cmbEstado)
        Me.gpbFiltroPaises.Controls.Add(Me.Label1)
        Me.gpbFiltroPaises.Controls.Add(Me.Panel1)
        Me.gpbFiltroPaises.Controls.Add(Me.btnAbajo)
        Me.gpbFiltroPaises.Controls.Add(Me.btnArriba)
        Me.gpbFiltroPaises.Controls.Add(Me.lblLimpiar)
        Me.gpbFiltroPaises.Controls.Add(Me.lblBuscar)
        Me.gpbFiltroPaises.Controls.Add(Me.btnLimpiarEstado)
        Me.gpbFiltroPaises.Controls.Add(Me.btnFiltrarEstado)
        Me.gpbFiltroPaises.Controls.Add(Me.lblActivoPais)
        Me.gpbFiltroPaises.Controls.Add(Me.txtAltaEstado)
        Me.gpbFiltroPaises.Controls.Add(Me.lblNombreEstado)
        Me.gpbFiltroPaises.Location = New System.Drawing.Point(8, 66)
        Me.gpbFiltroPaises.Name = "gpbFiltroPaises"
        Me.gpbFiltroPaises.Size = New System.Drawing.Size(434, 135)
        Me.gpbFiltroPaises.TabIndex = 3
        Me.gpbFiltroPaises.TabStop = False
        '
        'cmbEstado
        '
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(64, 44)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(263, 21)
        Me.cmbEstado.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "País"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdoActivoNo)
        Me.Panel1.Controls.Add(Me.rdoActivoSi)
        Me.Panel1.Location = New System.Drawing.Point(62, 94)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(94, 30)
        Me.Panel1.TabIndex = 14
        '
        'rdoActivoNo
        '
        Me.rdoActivoNo.AutoSize = True
        Me.rdoActivoNo.Location = New System.Drawing.Point(52, 7)
        Me.rdoActivoNo.Name = "rdoActivoNo"
        Me.rdoActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoActivoNo.TabIndex = 6
        Me.rdoActivoNo.TabStop = True
        Me.rdoActivoNo.Text = "No"
        Me.rdoActivoNo.UseVisualStyleBackColor = True
        '
        'rdoActivoSi
        '
        Me.rdoActivoSi.AutoSize = True
        Me.rdoActivoSi.Checked = True
        Me.rdoActivoSi.Location = New System.Drawing.Point(3, 7)
        Me.rdoActivoSi.Name = "rdoActivoSi"
        Me.rdoActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivoSi.TabIndex = 5
        Me.rdoActivoSi.TabStop = True
        Me.rdoActivoSi.Text = "Si"
        Me.rdoActivoSi.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(402, 14)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 13
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(377, 14)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 12
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(387, 114)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 8
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(338, 114)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 7
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnLimpiarEstado
        '
        Me.btnLimpiarEstado.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.limpiar_32
        Me.btnLimpiarEstado.Location = New System.Drawing.Point(390, 80)
        Me.btnLimpiarEstado.Name = "btnLimpiarEstado"
        Me.btnLimpiarEstado.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarEstado.TabIndex = 6
        Me.btnLimpiarEstado.UseVisualStyleBackColor = True
        '
        'btnFiltrarEstado
        '
        Me.btnFiltrarEstado.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.buscar_32
        Me.btnFiltrarEstado.Location = New System.Drawing.Point(343, 80)
        Me.btnFiltrarEstado.Name = "btnFiltrarEstado"
        Me.btnFiltrarEstado.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrarEstado.TabIndex = 5
        Me.btnFiltrarEstado.UseVisualStyleBackColor = True
        '
        'lblActivoPais
        '
        Me.lblActivoPais.AutoSize = True
        Me.lblActivoPais.Location = New System.Drawing.Point(9, 103)
        Me.lblActivoPais.Name = "lblActivoPais"
        Me.lblActivoPais.Size = New System.Drawing.Size(37, 13)
        Me.lblActivoPais.TabIndex = 2
        Me.lblActivoPais.Text = "Activo"
        '
        'txtAltaEstado
        '
        Me.txtAltaEstado.Location = New System.Drawing.Point(64, 71)
        Me.txtAltaEstado.Name = "txtAltaEstado"
        Me.txtAltaEstado.Size = New System.Drawing.Size(263, 20)
        Me.txtAltaEstado.TabIndex = 1
        '
        'lblNombreEstado
        '
        Me.lblNombreEstado.AutoSize = True
        Me.lblNombreEstado.Location = New System.Drawing.Point(6, 74)
        Me.lblNombreEstado.Name = "lblNombreEstado"
        Me.lblNombreEstado.Size = New System.Drawing.Size(43, 13)
        Me.lblNombreEstado.TabIndex = 0
        Me.lblNombreEstado.Text = " Estado"
        Me.lblNombreEstado.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.imgLogo)
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Controls.Add(Me.lblEditar)
        Me.pnlListaPaises.Controls.Add(Me.lblAltaEstados)
        Me.pnlListaPaises.Controls.Add(Me.btnEditarEstados)
        Me.pnlListaPaises.Controls.Add(Me.btnAltaEstados)
        Me.pnlListaPaises.Location = New System.Drawing.Point(1, 2)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(448, 60)
        Me.pnlListaPaises.TabIndex = 5
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.logoYuyin2
        Me.imgLogo.Location = New System.Drawing.Point(378, 0)
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
        Me.lblEncabezado.Location = New System.Drawing.Point(305, 19)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(75, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Estados"
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
        'btnEditarEstados
        '
        Me.btnEditarEstados.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.editar_32
        Me.btnEditarEstados.Location = New System.Drawing.Point(64, 7)
        Me.btnEditarEstados.Name = "btnEditarEstados"
        Me.btnEditarEstados.Size = New System.Drawing.Size(32, 32)
        Me.btnEditarEstados.TabIndex = 2
        Me.btnEditarEstados.UseVisualStyleBackColor = True
        '
        'btnAltaEstados
        '
        Me.btnAltaEstados.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.altas_32
        Me.btnAltaEstados.Location = New System.Drawing.Point(14, 7)
        Me.btnAltaEstados.Name = "btnAltaEstados"
        Me.btnAltaEstados.Size = New System.Drawing.Size(31, 32)
        Me.btnAltaEstados.TabIndex = 1
        Me.btnAltaEstados.UseVisualStyleBackColor = True
        '
        'ListaEstadosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(450, 507)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Controls.Add(Me.grdFiltroEstado)
        Me.Controls.Add(Me.gpbFiltroPaises)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListaEstadosForm"
        Me.Text = "Estados"
        CType(Me.grdFiltroEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbFiltroPaises.ResumeLayout(False)
        Me.gpbFiltroPaises.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdFiltroEstado As System.Windows.Forms.DataGridView
    Friend WithEvents gpbFiltroPaises As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarEstado As System.Windows.Forms.Button
    Friend WithEvents btnFiltrarEstado As System.Windows.Forms.Button
    Friend WithEvents lblActivoPais As System.Windows.Forms.Label
    Friend WithEvents txtAltaEstado As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreEstado As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents lblAltaEstados As System.Windows.Forms.Label
    Friend WithEvents btnEditarEstados As System.Windows.Forms.Button
    Friend WithEvents btnAltaEstados As System.Windows.Forms.Button
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
End Class
