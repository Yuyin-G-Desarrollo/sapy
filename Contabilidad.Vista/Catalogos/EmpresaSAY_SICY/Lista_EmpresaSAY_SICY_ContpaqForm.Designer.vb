<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Lista_EmpresaSAY_SICY_ContpaqForm
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
        Me.gridListaEmpresa = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.lblAltaEstados = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlContenedor.SuspendLayout()
        Me.gboxContenido.SuspendLayout()
        CType(Me.gridListaEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlListaPaises.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.gboxContenido)
        Me.pnlContenedor.Controls.Add(Me.pnlListaPaises)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1260, 507)
        Me.pnlContenedor.TabIndex = 2
        '
        'gboxContenido
        '
        Me.gboxContenido.Controls.Add(Me.gridListaEmpresa)
        Me.gboxContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxContenido.Location = New System.Drawing.Point(0, 60)
        Me.gboxContenido.Name = "gboxContenido"
        Me.gboxContenido.Size = New System.Drawing.Size(1260, 447)
        Me.gboxContenido.TabIndex = 12
        Me.gboxContenido.TabStop = False
        '
        'gridListaEmpresa
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaEmpresa.DisplayLayout.Appearance = Appearance1
        Me.gridListaEmpresa.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridListaEmpresa.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaEmpresa.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaEmpresa.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaEmpresa.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaEmpresa.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaEmpresa.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListaEmpresa.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListaEmpresa.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaEmpresa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaEmpresa.Location = New System.Drawing.Point(3, 16)
        Me.gridListaEmpresa.Name = "gridListaEmpresa"
        Me.gridListaEmpresa.Size = New System.Drawing.Size(1254, 428)
        Me.gridListaEmpresa.TabIndex = 3
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.PictureBox1)
        Me.pnlListaPaises.Controls.Add(Me.lblEditar)
        Me.pnlListaPaises.Controls.Add(Me.lblAltaEstados)
        Me.pnlListaPaises.Controls.Add(Me.btnEditar)
        Me.pnlListaPaises.Controls.Add(Me.btnAlta)
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1260, 60)
        Me.pnlListaPaises.TabIndex = 8
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(62, 42)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 13
        Me.lblEditar.Text = "Editar"
        '
        'lblAltaEstados
        '
        Me.lblAltaEstados.AutoSize = True
        Me.lblAltaEstados.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltaEstados.Location = New System.Drawing.Point(15, 42)
        Me.lblAltaEstados.Name = "lblAltaEstados"
        Me.lblAltaEstados.Size = New System.Drawing.Size(30, 13)
        Me.lblAltaEstados.TabIndex = 12
        Me.lblAltaEstados.Text = "Altas"
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Contabilidad.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(64, 7)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 2
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAlta
        '
        Me.btnAlta.Image = Global.Contabilidad.Vista.My.Resources.Resources.altas_32
        Me.btnAlta.Location = New System.Drawing.Point(14, 7)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(31, 32)
        Me.btnAlta.TabIndex = 1
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(911, 21)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(277, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Listado de Empresas SAY - SICY"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(1188, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 38
        Me.PictureBox1.TabStop = False
        '
        'Lista_EmpresaSAY_SICY_ContpaqForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1260, 507)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Lista_EmpresaSAY_SICY_ContpaqForm"
        Me.pnlContenedor.ResumeLayout(False)
        Me.gboxContenido.ResumeLayout(False)
        CType(Me.gridListaEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents gboxContenido As System.Windows.Forms.GroupBox
    Friend WithEvents gridListaEmpresa As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnAlta As System.Windows.Forms.Button
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents lblAltaEstados As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
End Class
