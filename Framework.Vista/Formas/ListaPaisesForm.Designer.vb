<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaPaisesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaPaisesForm))
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.lblAltaPais = New System.Windows.Forms.Label()
        Me.btnEditarPaises = New System.Windows.Forms.Button()
        Me.btnAltaPaises = New System.Windows.Forms.Button()
        Me.gpbFiltroPaises = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiarPais = New System.Windows.Forms.Button()
        Me.btnFiltrarPais = New System.Windows.Forms.Button()
        Me.lblActivoPais = New System.Windows.Forms.Label()
        Me.txtBuscarNombrePais = New System.Windows.Forms.TextBox()
        Me.lblNombrePais = New System.Windows.Forms.Label()
        Me.grdFiltroPaises = New System.Windows.Forms.DataGridView()
        Me.pnlListaPaises.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbFiltroPaises.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdFiltroPaises, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.imgLogo)
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Controls.Add(Me.lblEditar)
        Me.pnlListaPaises.Controls.Add(Me.lblAltaPais)
        Me.pnlListaPaises.Controls.Add(Me.btnEditarPaises)
        Me.pnlListaPaises.Controls.Add(Me.btnAltaPaises)
        Me.pnlListaPaises.Location = New System.Drawing.Point(-1, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(457, 60)
        Me.pnlListaPaises.TabIndex = 0
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.logoYuyin2
        Me.imgLogo.Location = New System.Drawing.Point(387, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 6
        Me.imgLogo.TabStop = False
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(327, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(62, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Países"
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(64, 38)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 4
        Me.lblEditar.Text = "Editar"
        '
        'lblAltaPais
        '
        Me.lblAltaPais.AutoSize = True
        Me.lblAltaPais.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltaPais.Location = New System.Drawing.Point(14, 38)
        Me.lblAltaPais.Name = "lblAltaPais"
        Me.lblAltaPais.Size = New System.Drawing.Size(30, 13)
        Me.lblAltaPais.TabIndex = 3
        Me.lblAltaPais.Text = "Altas"
        '
        'btnEditarPaises
        '
        Me.btnEditarPaises.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.editar_32
        Me.btnEditarPaises.Location = New System.Drawing.Point(64, 7)
        Me.btnEditarPaises.Name = "btnEditarPaises"
        Me.btnEditarPaises.Size = New System.Drawing.Size(32, 32)
        Me.btnEditarPaises.TabIndex = 2
        Me.btnEditarPaises.UseVisualStyleBackColor = True
        '
        'btnAltaPaises
        '
        Me.btnAltaPaises.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.altas_32
        Me.btnAltaPaises.Location = New System.Drawing.Point(14, 7)
        Me.btnAltaPaises.Name = "btnAltaPaises"
        Me.btnAltaPaises.Size = New System.Drawing.Size(31, 32)
        Me.btnAltaPaises.TabIndex = 1
        Me.btnAltaPaises.UseVisualStyleBackColor = True
        '
        'gpbFiltroPaises
        '
        Me.gpbFiltroPaises.Controls.Add(Me.Panel1)
        Me.gpbFiltroPaises.Controls.Add(Me.btnAbajo)
        Me.gpbFiltroPaises.Controls.Add(Me.btnArriba)
        Me.gpbFiltroPaises.Controls.Add(Me.lblLimpiar)
        Me.gpbFiltroPaises.Controls.Add(Me.lblBuscar)
        Me.gpbFiltroPaises.Controls.Add(Me.btnLimpiarPais)
        Me.gpbFiltroPaises.Controls.Add(Me.btnFiltrarPais)
        Me.gpbFiltroPaises.Controls.Add(Me.lblActivoPais)
        Me.gpbFiltroPaises.Controls.Add(Me.txtBuscarNombrePais)
        Me.gpbFiltroPaises.Controls.Add(Me.lblNombrePais)
        Me.gpbFiltroPaises.Location = New System.Drawing.Point(8, 66)
        Me.gpbFiltroPaises.Name = "gpbFiltroPaises"
        Me.gpbFiltroPaises.Size = New System.Drawing.Size(434, 135)
        Me.gpbFiltroPaises.TabIndex = 1
        Me.gpbFiltroPaises.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdoActivoNo)
        Me.Panel1.Controls.Add(Me.rdoActivoSi)
        Me.Panel1.Location = New System.Drawing.Point(63, 95)
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
        Me.lblLimpiar.Location = New System.Drawing.Point(387, 113)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 8
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(339, 113)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 7
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnLimpiarPais
        '
        Me.btnLimpiarPais.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.limpiar_32
        Me.btnLimpiarPais.Location = New System.Drawing.Point(390, 80)
        Me.btnLimpiarPais.Name = "btnLimpiarPais"
        Me.btnLimpiarPais.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarPais.TabIndex = 6
        Me.btnLimpiarPais.UseVisualStyleBackColor = True
        '
        'btnFiltrarPais
        '
        Me.btnFiltrarPais.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.buscar_32
        Me.btnFiltrarPais.Location = New System.Drawing.Point(343, 80)
        Me.btnFiltrarPais.Name = "btnFiltrarPais"
        Me.btnFiltrarPais.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrarPais.TabIndex = 5
        Me.btnFiltrarPais.UseVisualStyleBackColor = True
        '
        'lblActivoPais
        '
        Me.lblActivoPais.AutoSize = True
        Me.lblActivoPais.Location = New System.Drawing.Point(13, 102)
        Me.lblActivoPais.Name = "lblActivoPais"
        Me.lblActivoPais.Size = New System.Drawing.Size(37, 13)
        Me.lblActivoPais.TabIndex = 2
        Me.lblActivoPais.Text = "Activo"
        '
        'txtBuscarNombrePais
        '
        Me.txtBuscarNombrePais.Location = New System.Drawing.Point(63, 54)
        Me.txtBuscarNombrePais.Name = "txtBuscarNombrePais"
        Me.txtBuscarNombrePais.Size = New System.Drawing.Size(263, 20)
        Me.txtBuscarNombrePais.TabIndex = 1
        '
        'lblNombrePais
        '
        Me.lblNombrePais.AutoSize = True
        Me.lblNombrePais.Location = New System.Drawing.Point(13, 57)
        Me.lblNombrePais.Name = "lblNombrePais"
        Me.lblNombrePais.Size = New System.Drawing.Size(29, 13)
        Me.lblNombrePais.TabIndex = 0
        Me.lblNombrePais.Text = "País"
        '
        'grdFiltroPaises
        '
        Me.grdFiltroPaises.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.grdFiltroPaises.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFiltroPaises.Location = New System.Drawing.Point(8, 207)
        Me.grdFiltroPaises.MultiSelect = False
        Me.grdFiltroPaises.Name = "grdFiltroPaises"
        Me.grdFiltroPaises.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdFiltroPaises.Size = New System.Drawing.Size(434, 288)
        Me.grdFiltroPaises.TabIndex = 2
        '
        'ListaPaisesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(450, 507)
        Me.Controls.Add(Me.grdFiltroPaises)
        Me.Controls.Add(Me.gpbFiltroPaises)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListaPaisesForm"
        Me.Text = "Países"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbFiltroPaises.ResumeLayout(False)
        Me.gpbFiltroPaises.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdFiltroPaises, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents btnAltaPaises As System.Windows.Forms.Button
    Friend WithEvents btnEditarPaises As System.Windows.Forms.Button
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents lblAltaPais As System.Windows.Forms.Label
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents gpbFiltroPaises As System.Windows.Forms.GroupBox
    Friend WithEvents lblActivoPais As System.Windows.Forms.Label
    Friend WithEvents txtBuscarNombrePais As System.Windows.Forms.TextBox
    Friend WithEvents lblNombrePais As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarPais As System.Windows.Forms.Button
    Friend WithEvents btnFiltrarPais As System.Windows.Forms.Button
    Friend WithEvents grdFiltroPaises As System.Windows.Forms.DataGridView
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
End Class
