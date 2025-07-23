<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaEventosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaEventosForm))
        Me.grdListaClasificacionClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grpTiposDeTienda = New System.Windows.Forms.GroupBox()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.btnNo = New System.Windows.Forms.RadioButton()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblNombreClasificacionCliente = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.txtNombreClasificacionCliente = New System.Windows.Forms.TextBox()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblEncabezadoCatalogoClasificacionCliente = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        CType(Me.grdListaClasificacionClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTiposDeTienda.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdListaClasificacionClientes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaClasificacionClientes.DisplayLayout.Appearance = Appearance1
        Me.grdListaClasificacionClientes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdListaClasificacionClientes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdListaClasificacionClientes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdListaClasificacionClientes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaClasificacionClientes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaClasificacionClientes.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdListaClasificacionClientes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListaClasificacionClientes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdListaClasificacionClientes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListaClasificacionClientes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaClasificacionClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaClasificacionClientes.Location = New System.Drawing.Point(0, 156)
        Me.grdListaClasificacionClientes.Name = "grdListaClasificacionClientes"
        Me.grdListaClasificacionClientes.Size = New System.Drawing.Size(892, 417)
        Me.grdListaClasificacionClientes.TabIndex = 78
        '
        'grpTiposDeTienda
        '
        Me.grpTiposDeTienda.Controls.Add(Me.rdoSi)
        Me.grpTiposDeTienda.Controls.Add(Me.btnNo)
        Me.grpTiposDeTienda.Controls.Add(Me.btnAbajo)
        Me.grpTiposDeTienda.Controls.Add(Me.btnArriba)
        Me.grpTiposDeTienda.Controls.Add(Me.lblBúscar)
        Me.grpTiposDeTienda.Controls.Add(Me.lblLimpiar)
        Me.grpTiposDeTienda.Controls.Add(Me.btnLimpiar)
        Me.grpTiposDeTienda.Controls.Add(Me.btnBuscar)
        Me.grpTiposDeTienda.Controls.Add(Me.lblNombreClasificacionCliente)
        Me.grpTiposDeTienda.Controls.Add(Me.lblActivo)
        Me.grpTiposDeTienda.Controls.Add(Me.txtNombreClasificacionCliente)
        Me.grpTiposDeTienda.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpTiposDeTienda.Location = New System.Drawing.Point(0, 55)
        Me.grpTiposDeTienda.Name = "grpTiposDeTienda"
        Me.grpTiposDeTienda.Size = New System.Drawing.Size(892, 101)
        Me.grpTiposDeTienda.TabIndex = 80
        Me.grpTiposDeTienda.TabStop = False
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Checked = True
        Me.rdoSi.Location = New System.Drawing.Point(92, 72)
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
        Me.btnNo.Location = New System.Drawing.Point(146, 72)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(39, 17)
        Me.btnNo.TabIndex = 3
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(835, 8)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 7
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(811, 8)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 6
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'lblBúscar
        '
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(777, 77)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBúscar.TabIndex = 26
        Me.lblBúscar.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(827, 77)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 25
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(830, 43)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 5
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(780, 43)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblNombreClasificacionCliente
        '
        Me.lblNombreClasificacionCliente.AutoSize = True
        Me.lblNombreClasificacionCliente.Location = New System.Drawing.Point(39, 46)
        Me.lblNombreClasificacionCliente.Name = "lblNombreClasificacionCliente"
        Me.lblNombreClasificacionCliente.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreClasificacionCliente.TabIndex = 7
        Me.lblNombreClasificacionCliente.Text = "Nombre"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(39, 72)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 5
        Me.lblActivo.Text = "Activo"
        '
        'txtNombreClasificacionCliente
        '
        Me.txtNombreClasificacionCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreClasificacionCliente.Location = New System.Drawing.Point(92, 43)
        Me.txtNombreClasificacionCliente.MaxLength = 50
        Me.txtNombreClasificacionCliente.Name = "txtNombreClasificacionCliente"
        Me.txtNombreClasificacionCliente.Size = New System.Drawing.Size(364, 20)
        Me.txtNombreClasificacionCliente.TabIndex = 1
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.imgLogo)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoCatalogoClasificacionCliente)
        Me.pnlEncabezado.Controls.Add(Me.lblEditar)
        Me.pnlEncabezado.Controls.Add(Me.btnEditar)
        Me.pnlEncabezado.Controls.Add(Me.btnAltas)
        Me.pnlEncabezado.Controls.Add(Me.lblAltas)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(892, 55)
        Me.pnlEncabezado.TabIndex = 79
        '
        'lblEncabezadoCatalogoClasificacionCliente
        '
        Me.lblEncabezadoCatalogoClasificacionCliente.AutoSize = True
        Me.lblEncabezadoCatalogoClasificacionCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezadoCatalogoClasificacionCliente.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezadoCatalogoClasificacionCliente.Location = New System.Drawing.Point(736, 15)
        Me.lblEncabezadoCatalogoClasificacionCliente.Name = "lblEncabezadoCatalogoClasificacionCliente"
        Me.lblEncabezadoCatalogoClasificacionCliente.Size = New System.Drawing.Size(74, 20)
        Me.lblEncabezadoCatalogoClasificacionCliente.TabIndex = 21
        Me.lblEncabezadoCatalogoClasificacionCliente.Text = "Eventos"
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
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(822, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 55)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 46
        Me.imgLogo.TabStop = False
        '
        'ListaEventosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(892, 573)
        Me.Controls.Add(Me.grdListaClasificacionClientes)
        Me.Controls.Add(Me.grpTiposDeTienda)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(900, 600)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(900, 600)
        Me.Name = "ListaEventosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Eventos"
        CType(Me.grdListaClasificacionClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTiposDeTienda.ResumeLayout(False)
        Me.grpTiposDeTienda.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdListaClasificacionClientes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grpTiposDeTienda As System.Windows.Forms.GroupBox
    Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
    Friend WithEvents btnNo As System.Windows.Forms.RadioButton
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents lblBúscar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblNombreClasificacionCliente As System.Windows.Forms.Label
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents txtNombreClasificacionCliente As System.Windows.Forms.TextBox
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezadoCatalogoClasificacionCliente As System.Windows.Forms.Label
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents imgLogo As PictureBox
End Class
