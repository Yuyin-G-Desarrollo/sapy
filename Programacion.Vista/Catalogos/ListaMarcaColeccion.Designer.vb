<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaMarcaColeccion
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblAlta = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.picTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlParametros = New System.Windows.Forms.GroupBox()
        Me.lblVerDetalles = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.btnVerDetalles = New System.Windows.Forms.Button()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.grdListMarcaColeccion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.picTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        CType(Me.grdListMarcaColeccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlAcciones)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(739, 60)
        Me.pnlHeader.TabIndex = 1
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnAlta)
        Me.pnlAcciones.Controls.Add(Me.btnEditar)
        Me.pnlAcciones.Controls.Add(Me.lblAlta)
        Me.pnlAcciones.Controls.Add(Me.lblEditar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(258, 60)
        Me.pnlAcciones.TabIndex = 1
        '
        'btnAlta
        '
        Me.btnAlta.Image = Global.Programacion.Vista.My.Resources.Resources.agregar_32
        Me.btnAlta.Location = New System.Drawing.Point(11, 7)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(32, 32)
        Me.btnAlta.TabIndex = 1
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Programacion.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(53, 7)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 2
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblAlta
        '
        Me.lblAlta.AutoSize = True
        Me.lblAlta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAlta.Location = New System.Drawing.Point(14, 42)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(25, 13)
        Me.lblAlta.TabIndex = 4
        Me.lblAlta.Text = "Alta"
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(53, 42)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 2
        Me.lblEditar.Text = "Editar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.picTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(539, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(200, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(23, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(106, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Colecciones"
        '
        'picTitulo
        '
        Me.picTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.picTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.picTitulo.Location = New System.Drawing.Point(132, 0)
        Me.picTitulo.Name = "picTitulo"
        Me.picTitulo.Size = New System.Drawing.Size(68, 60)
        Me.picTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picTitulo.TabIndex = 0
        Me.picTitulo.TabStop = False
        '
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.lblVerDetalles)
        Me.pnlParametros.Controls.Add(Me.lblActivo)
        Me.pnlParametros.Controls.Add(Me.btnVerDetalles)
        Me.pnlParametros.Controls.Add(Me.rdoInactivo)
        Me.pnlParametros.Controls.Add(Me.rdoActivo)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 60)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(739, 55)
        Me.pnlParametros.TabIndex = 3
        Me.pnlParametros.TabStop = False
        '
        'lblVerDetalles
        '
        Me.lblVerDetalles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVerDetalles.AutoSize = True
        Me.lblVerDetalles.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblVerDetalles.Location = New System.Drawing.Point(690, 39)
        Me.lblVerDetalles.Name = "lblVerDetalles"
        Me.lblVerDetalles.Size = New System.Drawing.Size(46, 13)
        Me.lblVerDetalles.TabIndex = 5
        Me.lblVerDetalles.Text = "Ver Más"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(18, 27)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 15
        Me.lblActivo.Text = "Activo"
        '
        'btnVerDetalles
        '
        Me.btnVerDetalles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVerDetalles.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnVerDetalles.Location = New System.Drawing.Point(695, 7)
        Me.btnVerDetalles.Name = "btnVerDetalles"
        Me.btnVerDetalles.Size = New System.Drawing.Size(32, 32)
        Me.btnVerDetalles.TabIndex = 4
        Me.btnVerDetalles.UseVisualStyleBackColor = True
        '
        'rdoInactivo
        '
        Me.rdoInactivo.AutoSize = True
        Me.rdoInactivo.Location = New System.Drawing.Point(144, 25)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rdoInactivo.TabIndex = 4
        Me.rdoInactivo.TabStop = True
        Me.rdoInactivo.Text = "No"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Location = New System.Drawing.Point(91, 25)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivo.TabIndex = 3
        Me.rdoActivo.TabStop = True
        Me.rdoActivo.Text = "Si"
        Me.rdoActivo.UseVisualStyleBackColor = True
        '
        'grdListMarcaColeccion
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListMarcaColeccion.DisplayLayout.Appearance = Appearance1
        Appearance2.BackColor = System.Drawing.Color.SteelBlue
        Me.grdListMarcaColeccion.DisplayLayout.GroupByBox.Appearance = Appearance2
        Me.grdListMarcaColeccion.DisplayLayout.GroupByBox.Hidden = True
        Me.grdListMarcaColeccion.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
        Me.grdListMarcaColeccion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListMarcaColeccion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdListMarcaColeccion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListMarcaColeccion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListMarcaColeccion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListMarcaColeccion.DisplayLayout.Override.RowAlternateAppearance = Appearance3
        Appearance4.BorderColor = System.Drawing.Color.DarkGray
        Me.grdListMarcaColeccion.DisplayLayout.Override.RowAppearance = Appearance4
        Me.grdListMarcaColeccion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListMarcaColeccion.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdListMarcaColeccion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListMarcaColeccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListMarcaColeccion.Location = New System.Drawing.Point(0, 115)
        Me.grdListMarcaColeccion.Name = "grdListMarcaColeccion"
        Me.grdListMarcaColeccion.Size = New System.Drawing.Size(739, 356)
        Me.grdListMarcaColeccion.TabIndex = 5
        '
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 471)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(739, 60)
        Me.pnlEstado.TabIndex = 5
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(539, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(200, 60)
        Me.pnlOperaciones.TabIndex = 1
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
        'ListaMarcaColeccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(739, 531)
        Me.Controls.Add(Me.grdListMarcaColeccion)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(755, 570)
        Me.MinimumSize = New System.Drawing.Size(755, 570)
        Me.Name = "ListaMarcaColeccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Colecciones"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.picTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        CType(Me.grdListMarcaColeccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnAlta As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents lblAlta As System.Windows.Forms.Label
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents picTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlParametros As System.Windows.Forms.GroupBox
    Friend WithEvents grdListMarcaColeccion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblVerDetalles As System.Windows.Forms.Label
    Friend WithEvents btnVerDetalles As System.Windows.Forms.Button
End Class
