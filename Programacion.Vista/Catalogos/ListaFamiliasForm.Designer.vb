<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaFamiliasForm
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pctLogo = New System.Windows.Forms.PictureBox()
        Me.pnlParametrosBusqueda = New System.Windows.Forms.GroupBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.btnOcultar = New System.Windows.Forms.Button()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.btnlimpiar = New System.Windows.Forms.Button()
        Me.btnRestaurar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.lblFiltrar = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.grdListaFamilias = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pctLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametrosBusqueda.SuspendLayout()
        CType(Me.grdListaFamilias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlOperaciones)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(402, 60)
        Me.pnlHeader.TabIndex = 0
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.lblAltas)
        Me.pnlOperaciones.Controls.Add(Me.btnEditar)
        Me.pnlOperaciones.Controls.Add(Me.btnAltas)
        Me.pnlOperaciones.Controls.Add(Me.lblEditar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlOperaciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(154, 60)
        Me.pnlOperaciones.TabIndex = 1
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(13, 42)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 8
        Me.lblAltas.Text = "Altas"
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Programacion.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(65, 7)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 2
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAltas
        '
        Me.btnAltas.Image = Global.Programacion.Vista.My.Resources.Resources.altas_32
        Me.btnAltas.Location = New System.Drawing.Point(12, 7)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 1
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(65, 42)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 3
        Me.lblEditar.Text = "Editar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pctLogo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(202, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(200, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(54, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(75, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Familias"
        '
        'pctLogo
        '
        Me.pctLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctLogo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pctLogo.Location = New System.Drawing.Point(132, 0)
        Me.pctLogo.Name = "pctLogo"
        Me.pctLogo.Size = New System.Drawing.Size(68, 60)
        Me.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctLogo.TabIndex = 0
        Me.pctLogo.TabStop = False
        '
        'pnlParametrosBusqueda
        '
        Me.pnlParametrosBusqueda.Controls.Add(Me.lblActivo)
        Me.pnlParametrosBusqueda.Controls.Add(Me.rdoActivo)
        Me.pnlParametrosBusqueda.Controls.Add(Me.btnOcultar)
        Me.pnlParametrosBusqueda.Controls.Add(Me.rdoInactivo)
        Me.pnlParametrosBusqueda.Controls.Add(Me.btnlimpiar)
        Me.pnlParametrosBusqueda.Controls.Add(Me.btnRestaurar)
        Me.pnlParametrosBusqueda.Controls.Add(Me.lblLimpiar)
        Me.pnlParametrosBusqueda.Controls.Add(Me.btnFiltrar)
        Me.pnlParametrosBusqueda.Controls.Add(Me.lblFiltrar)
        Me.pnlParametrosBusqueda.Controls.Add(Me.txtDescripcion)
        Me.pnlParametrosBusqueda.Controls.Add(Me.txtCodigo)
        Me.pnlParametrosBusqueda.Controls.Add(Me.lblDescripcion)
        Me.pnlParametrosBusqueda.Controls.Add(Me.lblCodigo)
        Me.pnlParametrosBusqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametrosBusqueda.Location = New System.Drawing.Point(0, 60)
        Me.pnlParametrosBusqueda.Name = "pnlParametrosBusqueda"
        Me.pnlParametrosBusqueda.Size = New System.Drawing.Size(402, 55)
        Me.pnlParametrosBusqueda.TabIndex = 3
        Me.pnlParametrosBusqueda.TabStop = False
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(12, 27)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 18
        Me.lblActivo.Text = "Activo"
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Location = New System.Drawing.Point(75, 25)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivo.TabIndex = 3
        Me.rdoActivo.TabStop = True
        Me.rdoActivo.Text = "Si"
        Me.rdoActivo.UseVisualStyleBackColor = False
        '
        'btnOcultar
        '
        Me.btnOcultar.Image = Global.Programacion.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnOcultar.Location = New System.Drawing.Point(334, 19)
        Me.btnOcultar.Name = "btnOcultar"
        Me.btnOcultar.Size = New System.Drawing.Size(20, 20)
        Me.btnOcultar.TabIndex = 15
        Me.btnOcultar.UseVisualStyleBackColor = True
        Me.btnOcultar.Visible = False
        '
        'rdoInactivo
        '
        Me.rdoInactivo.AutoSize = True
        Me.rdoInactivo.Location = New System.Drawing.Point(130, 25)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rdoInactivo.TabIndex = 4
        Me.rdoInactivo.TabStop = True
        Me.rdoInactivo.Text = "No"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'btnlimpiar
        '
        Me.btnlimpiar.Image = Global.Programacion.Vista.My.Resources.Resources.limpiar_32
        Me.btnlimpiar.Location = New System.Drawing.Point(332, 13)
        Me.btnlimpiar.Name = "btnlimpiar"
        Me.btnlimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnlimpiar.TabIndex = 10
        Me.btnlimpiar.UseVisualStyleBackColor = True
        Me.btnlimpiar.Visible = False
        '
        'btnRestaurar
        '
        Me.btnRestaurar.Image = Global.Programacion.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnRestaurar.Location = New System.Drawing.Point(332, 23)
        Me.btnRestaurar.Name = "btnRestaurar"
        Me.btnRestaurar.Size = New System.Drawing.Size(20, 20)
        Me.btnRestaurar.TabIndex = 16
        Me.btnRestaurar.UseVisualStyleBackColor = True
        Me.btnRestaurar.Visible = False
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(18, 50)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 11
        Me.lblLimpiar.Text = "Limpiar"
        Me.lblLimpiar.Visible = False
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnFiltrar.Location = New System.Drawing.Point(332, 14)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrar.TabIndex = 1
        Me.btnFiltrar.UseVisualStyleBackColor = True
        Me.btnFiltrar.Visible = False
        '
        'lblFiltrar
        '
        Me.lblFiltrar.AutoSize = True
        Me.lblFiltrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblFiltrar.Location = New System.Drawing.Point(18, 48)
        Me.lblFiltrar.Name = "lblFiltrar"
        Me.lblFiltrar.Size = New System.Drawing.Size(42, 13)
        Me.lblFiltrar.TabIndex = 5
        Me.lblFiltrar.Text = "Mostrar"
        Me.lblFiltrar.Visible = False
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(339, 20)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(54, 20)
        Me.txtDescripcion.TabIndex = 7
        Me.txtDescripcion.Visible = False
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(339, 21)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(54, 20)
        Me.txtCodigo.TabIndex = 6
        Me.txtCodigo.Visible = False
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(324, 21)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 4
        Me.lblDescripcion.Text = "Descripción"
        Me.lblDescripcion.Visible = False
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(324, 22)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 2
        Me.lblCodigo.Text = "Código"
        Me.lblCodigo.Visible = False
        '
        'grdListaFamilias
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaFamilias.DisplayLayout.Appearance = Appearance1
        Me.grdListaFamilias.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaFamilias.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdListaFamilias.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaFamilias.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaFamilias.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaFamilias.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdListaFamilias.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListaFamilias.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdListaFamilias.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaFamilias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaFamilias.Location = New System.Drawing.Point(0, 115)
        Me.grdListaFamilias.Name = "grdListaFamilias"
        Me.grdListaFamilias.Size = New System.Drawing.Size(402, 293)
        Me.grdListaFamilias.TabIndex = 5
        '
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.Panel1)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 408)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(402, 60)
        Me.pnlEstado.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(202, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 60)
        Me.Panel1.TabIndex = 1
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(148, 42)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(149, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'ListaFamiliasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(402, 468)
        Me.Controls.Add(Me.grdListaFamilias)
        Me.Controls.Add(Me.pnlParametrosBusqueda)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlEstado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(418, 507)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(418, 507)
        Me.Name = "ListaFamiliasForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Familias"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pctLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametrosBusqueda.ResumeLayout(False)
        Me.pnlParametrosBusqueda.PerformLayout()
        CType(Me.grdListaFamilias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents pnlParametrosBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pctLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblFiltrar As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnlimpiar As System.Windows.Forms.Button
    Friend WithEvents btnRestaurar As System.Windows.Forms.Button
    Friend WithEvents btnOcultar As System.Windows.Forms.Button
    Friend WithEvents grdListaFamilias As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
