<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MotivoInactivacion
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblMensajeEstatico = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.txtNombreLista = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblComentarios = New System.Windows.Forms.Label()
        Me.lblMensajePregunta = New System.Windows.Forms.Label()
        Me.txtMotivosInactivacion = New System.Windows.Forms.TextBox()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.grdListaVentasClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlGrid.SuspendLayout()
        CType(Me.grdListaVentasClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(394, 60)
        Me.pnlHeader.TabIndex = 20
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.pnlTitulo.Location = New System.Drawing.Point(42, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(352, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Location = New System.Drawing.Point(25, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(261, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Autorizar Lista de Precios Base"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(292, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(60, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.pnlAcciones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 401)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(394, 60)
        Me.Panel2.TabIndex = 21
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(237, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(157, 60)
        Me.pnlAcciones.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(102, 7)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_321
        Me.btnGuardar.Location = New System.Drawing.Point(49, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(105, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(27, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Salir"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(43, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 2
        Me.lblGuardar.Text = "Guardar"
        '
        'lblMensajeEstatico
        '
        Me.lblMensajeEstatico.AutoSize = True
        Me.lblMensajeEstatico.BackColor = System.Drawing.Color.AliceBlue
        Me.lblMensajeEstatico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeEstatico.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblMensajeEstatico.Location = New System.Drawing.Point(47, 96)
        Me.lblMensajeEstatico.MaximumSize = New System.Drawing.Size(329, 0)
        Me.lblMensajeEstatico.Name = "lblMensajeEstatico"
        Me.lblMensajeEstatico.Size = New System.Drawing.Size(275, 46)
        Me.lblMensajeEstatico.TabIndex = 23
        Me.lblMensajeEstatico.Text = "Si la lista base se INACTIVA, no se podrá activar nuevamente y se autorizara la l" & _
    "ista base activa automáticamente"
        Me.lblMensajeEstatico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajeEstatico.UseCompatibleTextRendering = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblNombre)
        Me.GroupBox1.Controls.Add(Me.lblCodigo)
        Me.GroupBox1.Controls.Add(Me.lblUsuario)
        Me.GroupBox1.Controls.Add(Me.txtNombreLista)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.lblComentarios)
        Me.GroupBox1.Controls.Add(Me.lblMensajePregunta)
        Me.GroupBox1.Controls.Add(Me.txtMotivosInactivacion)
        Me.GroupBox1.Controls.Add(Me.lblMensajeEstatico)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(381, 146)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(33, 54)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 30
        Me.lblNombre.Text = "Nombre"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(33, 24)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 29
        Me.lblCodigo.Text = "Código"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.ForeColor = System.Drawing.Color.LightGray
        Me.lblUsuario.Location = New System.Drawing.Point(16, 240)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(43, 13)
        Me.lblUsuario.TabIndex = 28
        Me.lblUsuario.Text = "Usuario"
        '
        'txtNombreLista
        '
        Me.txtNombreLista.Enabled = False
        Me.txtNombreLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreLista.Location = New System.Drawing.Point(98, 49)
        Me.txtNombreLista.Name = "txtNombreLista"
        Me.txtNombreLista.Size = New System.Drawing.Size(244, 22)
        Me.txtNombreLista.TabIndex = 27
        '
        'txtCodigo
        '
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(98, 19)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(98, 22)
        Me.txtCodigo.TabIndex = 26
        '
        'lblComentarios
        '
        Me.lblComentarios.AutoSize = True
        Me.lblComentarios.Location = New System.Drawing.Point(3, 156)
        Me.lblComentarios.Name = "lblComentarios"
        Me.lblComentarios.Size = New System.Drawing.Size(65, 13)
        Me.lblComentarios.TabIndex = 25
        Me.lblComentarios.Text = "Comentarios"
        Me.lblComentarios.Visible = False
        '
        'lblMensajePregunta
        '
        Me.lblMensajePregunta.AutoSize = True
        Me.lblMensajePregunta.BackColor = System.Drawing.Color.AliceBlue
        Me.lblMensajePregunta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.lblMensajePregunta.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblMensajePregunta.Location = New System.Drawing.Point(31, 72)
        Me.lblMensajePregunta.MaximumSize = New System.Drawing.Size(329, 0)
        Me.lblMensajePregunta.Name = "lblMensajePregunta"
        Me.lblMensajePregunta.Size = New System.Drawing.Size(312, 21)
        Me.lblMensajePregunta.TabIndex = 24
        Me.lblMensajePregunta.Text = "¿Está seguro de AUTORIZAR la lista de precios?"
        Me.lblMensajePregunta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensajePregunta.UseCompatibleTextRendering = True
        '
        'txtMotivosInactivacion
        '
        Me.txtMotivosInactivacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMotivosInactivacion.Location = New System.Drawing.Point(19, 156)
        Me.txtMotivosInactivacion.Multiline = True
        Me.txtMotivosInactivacion.Name = "txtMotivosInactivacion"
        Me.txtMotivosInactivacion.Size = New System.Drawing.Size(355, 97)
        Me.txtMotivosInactivacion.TabIndex = 19
        Me.txtMotivosInactivacion.Visible = False
        '
        'pnlGrid
        '
        Me.pnlGrid.Controls.Add(Me.grdListaVentasClientes)
        Me.pnlGrid.Location = New System.Drawing.Point(6, 215)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(381, 179)
        Me.pnlGrid.TabIndex = 25
        '
        'grdListaVentasClientes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaVentasClientes.DisplayLayout.Appearance = Appearance1
        Me.grdListaVentasClientes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaVentasClientes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdListaVentasClientes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaVentasClientes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaVentasClientes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListaVentasClientes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListaVentasClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaVentasClientes.Location = New System.Drawing.Point(0, 0)
        Me.grdListaVentasClientes.Name = "grdListaVentasClientes"
        Me.grdListaVentasClientes.Size = New System.Drawing.Size(381, 179)
        Me.grdListaVentasClientes.TabIndex = 0
        '
        'MotivoInactivacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(394, 461)
        Me.Controls.Add(Me.pnlGrid)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "MotivoInactivacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Autorizar Lista de Precios Base"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlGrid.ResumeLayout(False)
        CType(Me.grdListaVentasClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblMensajeEstatico As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMensajePregunta As System.Windows.Forms.Label
    Friend WithEvents txtNombreLista As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents grdListaVentasClientes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblComentarios As System.Windows.Forms.Label
    Friend WithEvents txtMotivosInactivacion As System.Windows.Forms.TextBox
End Class
