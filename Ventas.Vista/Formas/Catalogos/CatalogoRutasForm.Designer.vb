<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CatalogoRutasForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CatalogoRutasForm))
        Me.gridListaRutas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbRutas = New System.Windows.Forms.GroupBox()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.btnNo = New System.Windows.Forms.RadioButton()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblNombreRuta = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.txtNombreRuta = New System.Windows.Forms.TextBox()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblListaCatalogoRutas = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.gridListaRutas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbRutas.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridListaRutas
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaRutas.DisplayLayout.Appearance = Appearance1
        Me.gridListaRutas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridListaRutas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaRutas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaRutas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaRutas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaRutas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaRutas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListaRutas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridListaRutas.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListaRutas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaRutas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaRutas.Location = New System.Drawing.Point(0, 155)
        Me.gridListaRutas.Name = "gridListaRutas"
        Me.gridListaRutas.Size = New System.Drawing.Size(584, 306)
        Me.gridListaRutas.TabIndex = 8
        '
        'grbRutas
        '
        Me.grbRutas.Controls.Add(Me.rdoSi)
        Me.grbRutas.Controls.Add(Me.btnNo)
        Me.grbRutas.Controls.Add(Me.btnAbajo)
        Me.grbRutas.Controls.Add(Me.btnArriba)
        Me.grbRutas.Controls.Add(Me.lblBúscar)
        Me.grbRutas.Controls.Add(Me.lblLimpiar)
        Me.grbRutas.Controls.Add(Me.btnLimpiar)
        Me.grbRutas.Controls.Add(Me.btnBuscar)
        Me.grbRutas.Controls.Add(Me.lblNombreRuta)
        Me.grbRutas.Controls.Add(Me.lblActivo)
        Me.grbRutas.Controls.Add(Me.txtNombreRuta)
        Me.grbRutas.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbRutas.Location = New System.Drawing.Point(0, 53)
        Me.grbRutas.Name = "grbRutas"
        Me.grbRutas.Size = New System.Drawing.Size(584, 102)
        Me.grbRutas.TabIndex = 71
        Me.grbRutas.TabStop = False
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Checked = True
        Me.rdoSi.Location = New System.Drawing.Point(92, 77)
        Me.rdoSi.Name = "rdoSi"
        Me.rdoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoSi.TabIndex = 2
        Me.rdoSi.TabStop = True
        Me.rdoSi.Text = "Si"
        Me.rdoSi.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.AutoSize = True
        Me.btnNo.Location = New System.Drawing.Point(146, 77)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(39, 17)
        Me.btnNo.TabIndex = 3
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(541, 8)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 7
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(517, 8)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 6
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'lblBúscar
        '
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(483, 77)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBúscar.TabIndex = 26
        Me.lblBúscar.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(533, 77)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 25
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(536, 43)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 5
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(486, 43)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblNombreRuta
        '
        Me.lblNombreRuta.AutoSize = True
        Me.lblNombreRuta.Location = New System.Drawing.Point(39, 43)
        Me.lblNombreRuta.Name = "lblNombreRuta"
        Me.lblNombreRuta.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreRuta.TabIndex = 7
        Me.lblNombreRuta.Text = "Nombre"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(39, 79)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 5
        Me.lblActivo.Text = "Activo"
        '
        'txtNombreRuta
        '
        Me.txtNombreRuta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreRuta.Location = New System.Drawing.Point(92, 40)
        Me.txtNombreRuta.MaxLength = 50
        Me.txtNombreRuta.Name = "txtNombreRuta"
        Me.txtNombreRuta.Size = New System.Drawing.Size(364, 20)
        Me.txtNombreRuta.TabIndex = 1
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Controls.Add(Me.lblListaCatalogoRutas)
        Me.pnlEncabezado.Controls.Add(Me.lblEditar)
        Me.pnlEncabezado.Controls.Add(Me.btnEditar)
        Me.pnlEncabezado.Controls.Add(Me.btnAltas)
        Me.pnlEncabezado.Controls.Add(Me.lblAltas)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(584, 53)
        Me.pnlEncabezado.TabIndex = 70
        '
        'lblListaCatalogoRutas
        '
        Me.lblListaCatalogoRutas.AutoSize = True
        Me.lblListaCatalogoRutas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaCatalogoRutas.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaCatalogoRutas.Location = New System.Drawing.Point(453, 16)
        Me.lblListaCatalogoRutas.Name = "lblListaCatalogoRutas"
        Me.lblListaCatalogoRutas.Size = New System.Drawing.Size(57, 20)
        Me.lblListaCatalogoRutas.TabIndex = 21
        Me.lblListaCatalogoRutas.Text = "Rutas"
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(64, 38)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 19
        Me.lblEditar.Text = "Editar"
        '
        'btnEditar
        '
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(64, 3)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 10
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAltas
        '
        Me.btnAltas.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
        Me.btnAltas.Location = New System.Drawing.Point(17, 3)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 9
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(18, 38)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 16
        Me.lblAltas.Text = "Altas"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(516, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'CatalogoRutasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(584, 461)
        Me.Controls.Add(Me.gridListaRutas)
        Me.Controls.Add(Me.grbRutas)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(600, 500)
        Me.MinimizeBox = False
        Me.Name = "CatalogoRutasForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Rutas"
        CType(Me.gridListaRutas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbRutas.ResumeLayout(False)
        Me.grbRutas.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridListaRutas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grbRutas As System.Windows.Forms.GroupBox
    Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
    Friend WithEvents btnNo As System.Windows.Forms.RadioButton
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents lblBúscar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblNombreRuta As System.Windows.Forms.Label
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents txtNombreRuta As System.Windows.Forms.TextBox
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblListaCatalogoRutas As System.Windows.Forms.Label
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
