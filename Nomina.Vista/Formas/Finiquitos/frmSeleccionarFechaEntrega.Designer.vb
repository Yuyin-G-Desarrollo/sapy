<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionarFechaEntrega
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeleccionarFechaEntrega))
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlAutorizar = New System.Windows.Forms.Panel()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnGuarda = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.dttFechaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.lblSeleccionarFecha = New System.Windows.Forms.Label()
        Me.lblNombreColaborador = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlAutorizar.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.Panel1)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(384, 59)
        Me.pnlListaPaises.TabIndex = 23
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pcbTitulo)
        Me.Panel1.Controls.Add(Me.lblEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(-37, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(421, 59)
        Me.Panel1.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(195, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(128, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Fecha Entrega"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.pnlAutorizar)
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 189)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(384, 60)
        Me.Panel2.TabIndex = 26
        '
        'pnlAutorizar
        '
        Me.pnlAutorizar.Controls.Add(Me.lblAceptar)
        Me.pnlAutorizar.Controls.Add(Me.btnGuarda)
        Me.pnlAutorizar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAutorizar.Location = New System.Drawing.Point(263, 0)
        Me.pnlAutorizar.Name = "pnlAutorizar"
        Me.pnlAutorizar.Size = New System.Drawing.Size(69, 60)
        Me.pnlAutorizar.TabIndex = 39
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.Location = New System.Drawing.Point(4, 39)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(63, 13)
        Me.lblAceptar.TabIndex = 15
        Me.lblAceptar.Text = "Seleccionar"
        '
        'btnGuarda
        '
        Me.btnGuarda.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.enviarcalculo_32
        Me.btnGuarda.Location = New System.Drawing.Point(20, 4)
        Me.btnGuarda.Name = "btnGuarda"
        Me.btnGuarda.Size = New System.Drawing.Size(31, 32)
        Me.btnGuarda.TabIndex = 6
        Me.btnGuarda.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnCerrar)
        Me.Panel7.Controls.Add(Me.lblCerrar)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(332, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(52, 60)
        Me.Panel7.TabIndex = 37
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(9, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 8
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(8, 39)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 19
        Me.lblCerrar.Text = "Cerrar"
        '
        'dttFechaEntrega
        '
        Me.dttFechaEntrega.Location = New System.Drawing.Point(118, 153)
        Me.dttFechaEntrega.Name = "dttFechaEntrega"
        Me.dttFechaEntrega.Size = New System.Drawing.Size(200, 20)
        Me.dttFechaEntrega.TabIndex = 27
        '
        'lblSeleccionarFecha
        '
        Me.lblSeleccionarFecha.AutoSize = True
        Me.lblSeleccionarFecha.Location = New System.Drawing.Point(35, 157)
        Me.lblSeleccionarFecha.Name = "lblSeleccionarFecha"
        Me.lblSeleccionarFecha.Size = New System.Drawing.Size(77, 13)
        Me.lblSeleccionarFecha.TabIndex = 28
        Me.lblSeleccionarFecha.Text = "Fecha Entrega"
        '
        'lblNombreColaborador
        '
        Me.lblNombreColaborador.AutoSize = True
        Me.lblNombreColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreColaborador.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNombreColaborador.Location = New System.Drawing.Point(114, 73)
        Me.lblNombreColaborador.MaximumSize = New System.Drawing.Size(250, 55)
        Me.lblNombreColaborador.MinimumSize = New System.Drawing.Size(250, 55)
        Me.lblNombreColaborador.Name = "lblNombreColaborador"
        Me.lblNombreColaborador.Size = New System.Drawing.Size(250, 55)
        Me.lblNombreColaborador.TabIndex = 29
        Me.lblNombreColaborador.Text = "."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Colaborador"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(353, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 46
        Me.pcbTitulo.TabStop = False
        '
        'frmSeleccionarFechaEntrega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(384, 249)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblNombreColaborador)
        Me.Controls.Add(Me.lblSeleccionarFecha)
        Me.Controls.Add(Me.dttFechaEntrega)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSeleccionarFechaEntrega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fecha Entrega"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pnlAutorizar.ResumeLayout(False)
        Me.pnlAutorizar.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents dttFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSeleccionarFecha As System.Windows.Forms.Label
    Friend WithEvents pnlAutorizar As System.Windows.Forms.Panel
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents btnGuarda As System.Windows.Forms.Button
    Friend WithEvents lblNombreColaborador As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As PictureBox
End Class
