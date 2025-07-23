<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaPreOrdenCompraExplosionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaPreOrdenCompraExplosionForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblAutorizar = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdOrdenCompra = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblPreordenidText = New System.Windows.Forms.Label()
        Me.lblPreordenId = New System.Windows.Forms.Label()
        Me.lblEstatusText = New System.Windows.Forms.Label()
        Me.lblParesText = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblObservacionesText = New System.Windows.Forms.Label()
        Me.lblNaveText = New System.Windows.Forms.Label()
        Me.lblProveedorText = New System.Windows.Forms.Label()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.lblPrioridadText = New System.Windows.Forms.Label()
        Me.lblFechaText = New System.Windows.Forms.Label()
        Me.lblNumeroText = New System.Windows.Forms.Label()
        Me.lblPrioridad = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblPreorden = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pnlInferior.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grdOrdenCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblMensaje)
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 409)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(981, 59)
        Me.pnlInferior.TabIndex = 2030
        '
        'lblMensaje
        '
        Me.lblMensaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.ForeColor = System.Drawing.Color.Red
        Me.lblMensaje.Location = New System.Drawing.Point(82, 16)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(752, 24)
        Me.lblMensaje.TabIndex = 101
        Me.lblMensaje.Text = "No hay pre ordenes registradas para la nave , fecha y proveedor seleccionados"
        Me.lblMensaje.Visible = False
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(928, 42)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 100
        Me.lblSalir.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(929, 5)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblCancelar)
        Me.pnlEncabezado.Controls.Add(Me.btnCancelar)
        Me.pnlEncabezado.Controls.Add(Me.lblAutorizar)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.btnAutorizar)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(981, 63)
        Me.pnlEncabezado.TabIndex = 2029
        '
        'lblAutorizar
        '
        Me.lblAutorizar.AutoSize = True
        Me.lblAutorizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAutorizar.Location = New System.Drawing.Point(17, 46)
        Me.lblAutorizar.Name = "lblAutorizar"
        Me.lblAutorizar.Size = New System.Drawing.Size(48, 13)
        Me.lblAutorizar.TabIndex = 2030
        Me.lblAutorizar.Text = "Autorizar"
        Me.lblAutorizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(653, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(258, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Consulta Pre Orden de Compra"
        '
        'btnAutorizar
        '
        Me.btnAutorizar.Image = Global.Produccion.Vista.My.Resources.Resources.aceptar_32
        Me.btnAutorizar.Location = New System.Drawing.Point(24, 9)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(32, 32)
        Me.btnAutorizar.TabIndex = 2029
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(913, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.grdOrdenCompra)
        Me.Panel1.Location = New System.Drawing.Point(0, 162)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(981, 246)
        Me.Panel1.TabIndex = 2031
        '
        'grdOrdenCompra
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOrdenCompra.DisplayLayout.Appearance = Appearance1
        Me.grdOrdenCompra.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdOrdenCompra.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdOrdenCompra.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdOrdenCompra.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdOrdenCompra.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdOrdenCompra.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOrdenCompra.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdOrdenCompra.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdOrdenCompra.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdOrdenCompra.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdOrdenCompra.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdOrdenCompra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdOrdenCompra.Location = New System.Drawing.Point(0, 0)
        Me.grdOrdenCompra.Name = "grdOrdenCompra"
        Me.grdOrdenCompra.Size = New System.Drawing.Size(981, 246)
        Me.grdOrdenCompra.TabIndex = 2022
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.lblPreordenidText)
        Me.Panel2.Controls.Add(Me.lblPreordenId)
        Me.Panel2.Controls.Add(Me.lblEstatusText)
        Me.Panel2.Controls.Add(Me.lblParesText)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.lblObservacionesText)
        Me.Panel2.Controls.Add(Me.lblNaveText)
        Me.Panel2.Controls.Add(Me.lblProveedorText)
        Me.Panel2.Controls.Add(Me.lblObservaciones)
        Me.Panel2.Controls.Add(Me.lblNave)
        Me.Panel2.Controls.Add(Me.lblProveedor)
        Me.Panel2.Controls.Add(Me.lblPrioridadText)
        Me.Panel2.Controls.Add(Me.lblFechaText)
        Me.Panel2.Controls.Add(Me.lblNumeroText)
        Me.Panel2.Controls.Add(Me.lblPrioridad)
        Me.Panel2.Controls.Add(Me.lblFecha)
        Me.Panel2.Controls.Add(Me.lblPreorden)
        Me.Panel2.Location = New System.Drawing.Point(0, 69)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(981, 87)
        Me.Panel2.TabIndex = 2032
        '
        'lblPreordenidText
        '
        Me.lblPreordenidText.AutoSize = True
        Me.lblPreordenidText.Location = New System.Drawing.Point(944, 60)
        Me.lblPreordenidText.Name = "lblPreordenidText"
        Me.lblPreordenidText.Size = New System.Drawing.Size(10, 13)
        Me.lblPreordenidText.TabIndex = 18
        Me.lblPreordenidText.Text = "-"
        Me.lblPreordenidText.Visible = False
        '
        'lblPreordenId
        '
        Me.lblPreordenId.AutoSize = True
        Me.lblPreordenId.Location = New System.Drawing.Point(861, 60)
        Me.lblPreordenId.Name = "lblPreordenId"
        Me.lblPreordenId.Size = New System.Drawing.Size(59, 13)
        Me.lblPreordenId.TabIndex = 17
        Me.lblPreordenId.Text = "PreordenId"
        Me.lblPreordenId.Visible = False
        '
        'lblEstatusText
        '
        Me.lblEstatusText.AutoSize = True
        Me.lblEstatusText.Location = New System.Drawing.Point(476, 37)
        Me.lblEstatusText.Name = "lblEstatusText"
        Me.lblEstatusText.Size = New System.Drawing.Size(10, 13)
        Me.lblEstatusText.TabIndex = 16
        Me.lblEstatusText.Text = "-"
        '
        'lblParesText
        '
        Me.lblParesText.AutoSize = True
        Me.lblParesText.Location = New System.Drawing.Point(944, 47)
        Me.lblParesText.Name = "lblParesText"
        Me.lblParesText.Size = New System.Drawing.Size(10, 13)
        Me.lblParesText.TabIndex = 15
        Me.lblParesText.Text = "-"
        Me.lblParesText.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(393, 37)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(42, 13)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "Estatus"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(861, 47)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(34, 13)
        Me.Label18.TabIndex = 12
        Me.Label18.Text = "Pares"
        Me.Label18.Visible = False
        '
        'lblObservacionesText
        '
        Me.lblObservacionesText.AutoSize = True
        Me.lblObservacionesText.Location = New System.Drawing.Point(476, 60)
        Me.lblObservacionesText.Name = "lblObservacionesText"
        Me.lblObservacionesText.Size = New System.Drawing.Size(10, 13)
        Me.lblObservacionesText.TabIndex = 11
        Me.lblObservacionesText.Text = "-"
        '
        'lblNaveText
        '
        Me.lblNaveText.AutoSize = True
        Me.lblNaveText.Location = New System.Drawing.Point(800, 14)
        Me.lblNaveText.Name = "lblNaveText"
        Me.lblNaveText.Size = New System.Drawing.Size(10, 13)
        Me.lblNaveText.TabIndex = 10
        Me.lblNaveText.Text = "-"
        '
        'lblProveedorText
        '
        Me.lblProveedorText.AutoSize = True
        Me.lblProveedorText.Location = New System.Drawing.Point(476, 14)
        Me.lblProveedorText.Name = "lblProveedorText"
        Me.lblProveedorText.Size = New System.Drawing.Size(10, 13)
        Me.lblProveedorText.TabIndex = 9
        Me.lblProveedorText.Text = "-"
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Location = New System.Drawing.Point(393, 60)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(78, 13)
        Me.lblObservaciones.TabIndex = 8
        Me.lblObservaciones.Text = "Observaciones"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(717, 14)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 7
        Me.lblNave.Text = "Nave"
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(393, 14)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(56, 13)
        Me.lblProveedor.TabIndex = 6
        Me.lblProveedor.Text = "Proveedor"
        '
        'lblPrioridadText
        '
        Me.lblPrioridadText.AutoSize = True
        Me.lblPrioridadText.Location = New System.Drawing.Point(172, 60)
        Me.lblPrioridadText.Name = "lblPrioridadText"
        Me.lblPrioridadText.Size = New System.Drawing.Size(10, 13)
        Me.lblPrioridadText.TabIndex = 5
        Me.lblPrioridadText.Text = "-"
        '
        'lblFechaText
        '
        Me.lblFechaText.AutoSize = True
        Me.lblFechaText.Location = New System.Drawing.Point(172, 37)
        Me.lblFechaText.Name = "lblFechaText"
        Me.lblFechaText.Size = New System.Drawing.Size(10, 13)
        Me.lblFechaText.TabIndex = 4
        Me.lblFechaText.Text = "-"
        '
        'lblNumeroText
        '
        Me.lblNumeroText.AutoSize = True
        Me.lblNumeroText.Location = New System.Drawing.Point(172, 14)
        Me.lblNumeroText.Name = "lblNumeroText"
        Me.lblNumeroText.Size = New System.Drawing.Size(10, 13)
        Me.lblNumeroText.TabIndex = 3
        Me.lblNumeroText.Text = "-"
        '
        'lblPrioridad
        '
        Me.lblPrioridad.AutoSize = True
        Me.lblPrioridad.Location = New System.Drawing.Point(57, 60)
        Me.lblPrioridad.Name = "lblPrioridad"
        Me.lblPrioridad.Size = New System.Drawing.Size(48, 13)
        Me.lblPrioridad.TabIndex = 2
        Me.lblPrioridad.Text = "Prioridad"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(57, 37)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(100, 13)
        Me.lblFecha.TabIndex = 1
        Me.lblFecha.Text = "Fecha de Programa"
        '
        'lblPreorden
        '
        Me.lblPreorden.AutoSize = True
        Me.lblPreorden.Location = New System.Drawing.Point(57, 14)
        Me.lblPreorden.Name = "lblPreorden"
        Me.lblPreorden.Size = New System.Drawing.Size(109, 13)
        Me.lblPreorden.TabIndex = 0
        Me.lblPreorden.Text = "Pre Orden de Compra"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(66, 46)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelar.TabIndex = 2032
        Me.lblCancelar.Text = "Cancelar"
        Me.lblCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Produccion.Vista.My.Resources.Resources.cancelar_32
        Me.btnCancelar.Location = New System.Drawing.Point(73, 9)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 2031
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'ConsultaPreOrdenCompraExplosionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(981, 468)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "ConsultaPreOrdenCompraExplosionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Pre Orden de Compra"
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdOrdenCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblAutorizar As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdOrdenCompra As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblPreordenidText As System.Windows.Forms.Label
    Friend WithEvents lblPreordenId As System.Windows.Forms.Label
    Friend WithEvents lblEstatusText As System.Windows.Forms.Label
    Friend WithEvents lblParesText As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblObservacionesText As System.Windows.Forms.Label
    Friend WithEvents lblNaveText As System.Windows.Forms.Label
    Friend WithEvents lblProveedorText As System.Windows.Forms.Label
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents lblPrioridadText As System.Windows.Forms.Label
    Friend WithEvents lblFechaText As System.Windows.Forms.Label
    Friend WithEvents lblNumeroText As System.Windows.Forms.Label
    Friend WithEvents lblPrioridad As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblPreorden As System.Windows.Forms.Label
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
