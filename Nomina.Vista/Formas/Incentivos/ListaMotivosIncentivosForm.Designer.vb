<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaMotivosIncentivosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaMotivosIncentivosForm))
        Me.lblAltaCiudad = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.btnEditarIncentivo = New System.Windows.Forms.Button()
        Me.btnAltaIncentivo = New System.Windows.Forms.Button()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblNombreIncentivo = New System.Windows.Forms.Label()
        Me.txtBuscarNombreIncentivo = New System.Windows.Forms.TextBox()
        Me.lblActivoNave = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.Nave = New System.Windows.Forms.Label()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.gpbFiltroIncentivos = New System.Windows.Forms.GroupBox()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnLimpiarIncentivos = New System.Windows.Forms.Button()
        Me.btnFiltrarPais = New System.Windows.Forms.Button()
        Me.grdFiltroIncentivos = New System.Windows.Forms.DataGridView()
        Me.pnlListaPaises.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.gpbFiltroIncentivos.SuspendLayout()
        CType(Me.grdFiltroIncentivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblAltaCiudad
        '
        Me.lblAltaCiudad.AutoSize = True
        Me.lblAltaCiudad.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltaCiudad.Location = New System.Drawing.Point(14, 50)
        Me.lblAltaCiudad.Name = "lblAltaCiudad"
        Me.lblAltaCiudad.Size = New System.Drawing.Size(30, 13)
        Me.lblAltaCiudad.TabIndex = 3
        Me.lblAltaCiudad.Text = "Altas"
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(61, 50)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 4
        Me.lblEditar.Text = "Editar"
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(143, 50)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(251, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Lista de Motivos de Incentivos"
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Controls.Add(Me.lblEditar)
        Me.pnlListaPaises.Controls.Add(Me.lblAltaCiudad)
        Me.pnlListaPaises.Controls.Add(Me.btnEditarIncentivo)
        Me.pnlListaPaises.Controls.Add(Me.btnAltaIncentivo)
        Me.pnlListaPaises.Controls.Add(Me.pbYuyin)
        Me.pnlListaPaises.Location = New System.Drawing.Point(2, 4)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(394, 70)
        Me.pnlListaPaises.TabIndex = 6
        '
        'btnEditarIncentivo
        '
        Me.btnEditarIncentivo.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.editar_321
        Me.btnEditarIncentivo.Location = New System.Drawing.Point(64, 12)
        Me.btnEditarIncentivo.Name = "btnEditarIncentivo"
        Me.btnEditarIncentivo.Size = New System.Drawing.Size(32, 32)
        Me.btnEditarIncentivo.TabIndex = 2
        Me.btnEditarIncentivo.UseVisualStyleBackColor = True
        '
        'btnAltaIncentivo
        '
        Me.btnAltaIncentivo.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.altas_32
        Me.btnAltaIncentivo.Location = New System.Drawing.Point(14, 12)
        Me.btnAltaIncentivo.Name = "btnAltaIncentivo"
        Me.btnAltaIncentivo.Size = New System.Drawing.Size(31, 32)
        Me.btnAltaIncentivo.TabIndex = 1
        Me.btnAltaIncentivo.UseVisualStyleBackColor = True
        '
        'pbYuyin
        '
        Me.pbYuyin.Image = Global.Nomina.Vista.My.Resources.Resources.yuyin
        Me.pbYuyin.Location = New System.Drawing.Point(275, 3)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(119, 56)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 0
        Me.pbYuyin.TabStop = False
        '
        'lblNombreIncentivo
        '
        Me.lblNombreIncentivo.AutoSize = True
        Me.lblNombreIncentivo.Location = New System.Drawing.Point(10, 62)
        Me.lblNombreIncentivo.Name = "lblNombreIncentivo"
        Me.lblNombreIncentivo.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreIncentivo.TabIndex = 0
        Me.lblNombreIncentivo.Text = "Nombre"
        '
        'txtBuscarNombreIncentivo
        '
        Me.txtBuscarNombreIncentivo.Location = New System.Drawing.Point(60, 62)
        Me.txtBuscarNombreIncentivo.Name = "txtBuscarNombreIncentivo"
        Me.txtBuscarNombreIncentivo.Size = New System.Drawing.Size(118, 20)
        Me.txtBuscarNombreIncentivo.TabIndex = 1
        '
        'lblActivoNave
        '
        Me.lblActivoNave.AutoSize = True
        Me.lblActivoNave.Location = New System.Drawing.Point(14, 140)
        Me.lblActivoNave.Name = "lblActivoNave"
        Me.lblActivoNave.Size = New System.Drawing.Size(37, 13)
        Me.lblActivoNave.TabIndex = 2
        Me.lblActivoNave.Text = "Activo"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(277, 133)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(40, 13)
        Me.lblBuscar.TabIndex = 7
        Me.lblBuscar.Text = "Buscar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(340, 133)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 8
        Me.lblLimpiar.Text = "Limpiar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdoActivoNo)
        Me.Panel1.Controls.Add(Me.rdoActivoSi)
        Me.Panel1.Location = New System.Drawing.Point(60, 130)
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
        'Nave
        '
        Me.Nave.AutoSize = True
        Me.Nave.Location = New System.Drawing.Point(24, 100)
        Me.Nave.Name = "Nave"
        Me.Nave.Size = New System.Drawing.Size(38, 13)
        Me.Nave.TabIndex = 15
        Me.Nave.Text = "Naves"
        '
        'cmbNaves
        '
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.Location = New System.Drawing.Point(60, 100)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(121, 21)
        Me.cmbNaves.TabIndex = 17
        '
        'gpbFiltroIncentivos
        '
        Me.gpbFiltroIncentivos.Controls.Add(Me.cmbNaves)
        Me.gpbFiltroIncentivos.Controls.Add(Me.Nave)
        Me.gpbFiltroIncentivos.Controls.Add(Me.Panel1)
        Me.gpbFiltroIncentivos.Controls.Add(Me.btnAbajo)
        Me.gpbFiltroIncentivos.Controls.Add(Me.btnArriba)
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblLimpiar)
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblBuscar)
        Me.gpbFiltroIncentivos.Controls.Add(Me.btnLimpiarIncentivos)
        Me.gpbFiltroIncentivos.Controls.Add(Me.btnFiltrarPais)
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblActivoNave)
        Me.gpbFiltroIncentivos.Controls.Add(Me.txtBuscarNombreIncentivo)
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblNombreIncentivo)
        Me.gpbFiltroIncentivos.Location = New System.Drawing.Point(6, 74)
        Me.gpbFiltroIncentivos.Name = "gpbFiltroIncentivos"
        Me.gpbFiltroIncentivos.Size = New System.Drawing.Size(390, 176)
        Me.gpbFiltroIncentivos.TabIndex = 7
        Me.gpbFiltroIncentivos.TabStop = False
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(361, 8)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 13
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(333, 8)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 12
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnLimpiarIncentivos
        '
        Me.btnLimpiarIncentivos.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarIncentivos.Location = New System.Drawing.Point(343, 97)
        Me.btnLimpiarIncentivos.Name = "btnLimpiarIncentivos"
        Me.btnLimpiarIncentivos.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarIncentivos.TabIndex = 6
        Me.btnLimpiarIncentivos.UseVisualStyleBackColor = True
        '
        'btnFiltrarPais
        '
        Me.btnFiltrarPais.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnFiltrarPais.Location = New System.Drawing.Point(281, 97)
        Me.btnFiltrarPais.Name = "btnFiltrarPais"
        Me.btnFiltrarPais.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrarPais.TabIndex = 5
        Me.btnFiltrarPais.UseVisualStyleBackColor = True
        '
        'grdFiltroIncentivos
        '
        Me.grdFiltroIncentivos.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.grdFiltroIncentivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFiltroIncentivos.Location = New System.Drawing.Point(6, 257)
        Me.grdFiltroIncentivos.MultiSelect = False
        Me.grdFiltroIncentivos.Name = "grdFiltroIncentivos"
        Me.grdFiltroIncentivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdFiltroIncentivos.Size = New System.Drawing.Size(390, 212)
        Me.grdFiltroIncentivos.TabIndex = 8
        '
        'ListaMotivosIncentivosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(403, 487)
        Me.Controls.Add(Me.grdFiltroIncentivos)
        Me.Controls.Add(Me.gpbFiltroIncentivos)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ListaMotivosIncentivosForm"
        Me.Text = "Lista de Motivos de Incentivos"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gpbFiltroIncentivos.ResumeLayout(False)
        Me.gpbFiltroIncentivos.PerformLayout()
        CType(Me.grdFiltroIncentivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents btnAltaIncentivo As System.Windows.Forms.Button
    Friend WithEvents btnEditarIncentivo As System.Windows.Forms.Button
    Friend WithEvents lblAltaCiudad As System.Windows.Forms.Label
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblNombreIncentivo As System.Windows.Forms.Label
    Friend WithEvents txtBuscarNombreIncentivo As System.Windows.Forms.TextBox
    Friend WithEvents lblActivoNave As System.Windows.Forms.Label
    Friend WithEvents btnFiltrarPais As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarIncentivos As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents Nave As System.Windows.Forms.Label
    Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
    Friend WithEvents gpbFiltroIncentivos As System.Windows.Forms.GroupBox
    Friend WithEvents grdFiltroIncentivos As System.Windows.Forms.DataGridView
End Class
