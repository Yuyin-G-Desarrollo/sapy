<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AsignacionFraccionesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsignacionFraccionesForm))
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdFracciones = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdFracciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.pcbTitulo)
        Me.pnlListaPaises.Controls.Add(Me.btnEditar)
        Me.pnlListaPaises.Controls.Add(Me.lblEditar)
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(606, 59)
        Me.pnlListaPaises.TabIndex = 10
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Nomina.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(12, 9)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 45
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(12, 42)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 46
        Me.lblEditar.Text = "Editar"
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(319, 21)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(215, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Asignación de Fracciones"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbDepartamento)
        Me.GroupBox1.Controls.Add(Me.lblDepartamento)
        Me.GroupBox1.Controls.Add(Me.cmbNave)
        Me.GroupBox1.Controls.Add(Me.lblNave)
        Me.GroupBox1.Controls.Add(Me.lblBuscar)
        Me.GroupBox1.Controls.Add(Me.btnLimpiar)
        Me.GroupBox1.Controls.Add(Me.btnMostrar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(606, 92)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(108, 57)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(265, 21)
        Me.cmbDepartamento.TabIndex = 55
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.ForeColor = System.Drawing.Color.Black
        Me.lblDepartamento.Location = New System.Drawing.Point(28, 60)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(74, 13)
        Me.lblDepartamento.TabIndex = 56
        Me.lblDepartamento.Text = "Departamento"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(108, 30)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(265, 21)
        Me.cmbNave.TabIndex = 53
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(63, 33)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(40, 13)
        Me.lblNave.TabIndex = 54
        Me.lblNave.Text = "* Nave"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(508, 66)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 52
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnLimpiar.Location = New System.Drawing.Point(562, 33)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 4
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(511, 33)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 3
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(559, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Limpiar"
        '
        'grdFracciones
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFracciones.DisplayLayout.Appearance = Appearance1
        Me.grdFracciones.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grdFracciones.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFracciones.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFracciones.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFracciones.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFracciones.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFracciones.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdFracciones.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFracciones.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFracciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFracciones.Location = New System.Drawing.Point(0, 151)
        Me.grdFracciones.Name = "grdFracciones"
        Me.grdFracciones.Size = New System.Drawing.Size(606, 377)
        Me.grdFracciones.TabIndex = 55
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(538, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 47
        Me.pcbTitulo.TabStop = False
        '
        'AsignacionFraccionesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(606, 528)
        Me.Controls.Add(Me.grdFracciones)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AsignacionFraccionesForm"
        Me.Text = "Asignación de Fracciones"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdFracciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents grdFracciones As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As PictureBox
End Class
