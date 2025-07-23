<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaLineasForm
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlParametros = New System.Windows.Forms.GroupBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.grdListaLineas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlHeader.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        CType(Me.grdListaLineas, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlHeader.Size = New System.Drawing.Size(402, 60)
        Me.pnlHeader.TabIndex = 4
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnEditar)
        Me.pnlAcciones.Controls.Add(Me.btnAltas)
        Me.pnlAcciones.Controls.Add(Me.lblEditar)
        Me.pnlAcciones.Controls.Add(Me.lblAltas)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(132, 60)
        Me.pnlAcciones.TabIndex = 1
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Programacion.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(62, 8)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 3
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAltas
        '
        Me.btnAltas.Image = Global.Programacion.Vista.My.Resources.Resources.altas_32
        Me.btnAltas.Location = New System.Drawing.Point(12, 8)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 2
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(61, 42)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 1
        Me.lblEditar.Text = "Editar"
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(13, 42)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 0
        Me.lblAltas.Text = "Altas"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
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
        Me.lblTitulo.Location = New System.Drawing.Point(67, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(62, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Lineas"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(132, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.lblActivo)
        Me.pnlParametros.Controls.Add(Me.rdoInactivo)
        Me.pnlParametros.Controls.Add(Me.rdoActivo)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 60)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(402, 55)
        Me.pnlParametros.TabIndex = 6
        Me.pnlParametros.TabStop = False
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(13, 30)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 17
        Me.lblActivo.Text = "Activo"
        '
        'rdoInactivo
        '
        Me.rdoInactivo.AutoSize = True
        Me.rdoInactivo.Location = New System.Drawing.Point(136, 28)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rdoInactivo.TabIndex = 9
        Me.rdoInactivo.Text = "No"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Location = New System.Drawing.Point(79, 28)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivo.TabIndex = 8
        Me.rdoActivo.Text = "Si"
        Me.rdoActivo.UseVisualStyleBackColor = True
        '
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 408)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(402, 60)
        Me.pnlEstado.TabIndex = 7
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(202, 0)
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
        'grdListaLineas
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaLineas.DisplayLayout.Appearance = Appearance1
        Me.grdListaLineas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaLineas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdListaLineas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaLineas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaLineas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaLineas.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdListaLineas.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdListaLineas.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdListaLineas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaLineas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaLineas.Location = New System.Drawing.Point(0, 115)
        Me.grdListaLineas.Name = "grdListaLineas"
        Me.grdListaLineas.Size = New System.Drawing.Size(402, 293)
        Me.grdListaLineas.TabIndex = 8
        '
        'ListaLineasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(402, 468)
        Me.Controls.Add(Me.grdListaLineas)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(418, 507)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(418, 507)
        Me.Name = "ListaLineasForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lineas"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        CType(Me.grdListaLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlParametros As System.Windows.Forms.GroupBox
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents grdListaLineas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
