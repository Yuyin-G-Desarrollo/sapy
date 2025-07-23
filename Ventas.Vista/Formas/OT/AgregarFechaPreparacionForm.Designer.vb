<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarFechaPreparacionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgregarFechaPreparacionForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblEncabezadoCatalogoClasificacionCliente = New System.Windows.Forms.Label()
        Me.grpTiposDeTienda = New System.Windows.Forms.GroupBox()
        Me.dtmpFechaPreparacion = New System.Windows.Forms.DateTimePicker()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblNombreClasificacionCliente = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.grpTiposDeTienda.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoCatalogoClasificacionCliente)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(348, 55)
        Me.pnlEncabezado.TabIndex = 77
        '
        'lblEncabezadoCatalogoClasificacionCliente
        '
        Me.lblEncabezadoCatalogoClasificacionCliente.AutoSize = True
        Me.lblEncabezadoCatalogoClasificacionCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezadoCatalogoClasificacionCliente.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezadoCatalogoClasificacionCliente.Location = New System.Drawing.Point(37, 23)
        Me.lblEncabezadoCatalogoClasificacionCliente.Name = "lblEncabezadoCatalogoClasificacionCliente"
        Me.lblEncabezadoCatalogoClasificacionCliente.Size = New System.Drawing.Size(229, 20)
        Me.lblEncabezadoCatalogoClasificacionCliente.TabIndex = 21
        Me.lblEncabezadoCatalogoClasificacionCliente.Text = "Agregar Fecha Preparación"
        '
        'grpTiposDeTienda
        '
        Me.grpTiposDeTienda.BackColor = System.Drawing.Color.AliceBlue
        Me.grpTiposDeTienda.Controls.Add(Me.dtmpFechaPreparacion)
        Me.grpTiposDeTienda.Controls.Add(Me.lblGuardar)
        Me.grpTiposDeTienda.Controls.Add(Me.lblLimpiar)
        Me.grpTiposDeTienda.Controls.Add(Me.btnCerrar)
        Me.grpTiposDeTienda.Controls.Add(Me.btnGuardar)
        Me.grpTiposDeTienda.Controls.Add(Me.lblNombreClasificacionCliente)
        Me.grpTiposDeTienda.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpTiposDeTienda.Location = New System.Drawing.Point(0, 55)
        Me.grpTiposDeTienda.Name = "grpTiposDeTienda"
        Me.grpTiposDeTienda.Size = New System.Drawing.Size(348, 128)
        Me.grpTiposDeTienda.TabIndex = 78
        Me.grpTiposDeTienda.TabStop = False
        '
        'dtmpFechaPreparacion
        '
        Me.dtmpFechaPreparacion.Location = New System.Drawing.Point(125, 25)
        Me.dtmpFechaPreparacion.Name = "dtmpFechaPreparacion"
        Me.dtmpFechaPreparacion.Size = New System.Drawing.Size(200, 20)
        Me.dtmpFechaPreparacion.TabIndex = 27
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(240, 101)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 26
        Me.lblGuardar.Text = "Guardar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(292, 101)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(35, 13)
        Me.lblLimpiar.TabIndex = 25
        Me.lblLimpiar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(293, 67)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(243, 67)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblNombreClasificacionCliente
        '
        Me.lblNombreClasificacionCliente.AutoSize = True
        Me.lblNombreClasificacionCliente.Location = New System.Drawing.Point(22, 28)
        Me.lblNombreClasificacionCliente.Name = "lblNombreClasificacionCliente"
        Me.lblNombreClasificacionCliente.Size = New System.Drawing.Size(100, 13)
        Me.lblNombreClasificacionCliente.TabIndex = 7
        Me.lblNombreClasificacionCliente.Text = "Fecha Preparación:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(280, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 55)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AgregarFechaPreparacionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 194)
        Me.Controls.Add(Me.grpTiposDeTienda)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(356, 221)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(356, 221)
        Me.Name = "AgregarFechaPreparacionForm"
        Me.Text = "Agregar Fecha Preparación"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.grpTiposDeTienda.ResumeLayout(False)
        Me.grpTiposDeTienda.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezadoCatalogoClasificacionCliente As System.Windows.Forms.Label
    Friend WithEvents grpTiposDeTienda As System.Windows.Forms.GroupBox
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblNombreClasificacionCliente As System.Windows.Forms.Label
    Friend WithEvents dtmpFechaPreparacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox1 As PictureBox
End Class
