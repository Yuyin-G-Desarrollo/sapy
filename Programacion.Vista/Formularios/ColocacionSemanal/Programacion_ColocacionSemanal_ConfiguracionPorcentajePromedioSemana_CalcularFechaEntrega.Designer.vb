<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Programacion_ColocacionSemanal_ConfiguracionPorcentajePromedioSemana_CalcularFechaEntrega
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
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlVentas = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblPromedioActual = New System.Windows.Forms.Label()
        Me.lblTextoActual = New System.Windows.Forms.Label()
        Me.lblTextoPromedio = New System.Windows.Forms.Label()
        Me.txtPromedioOcupacion = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlVentas.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridView2
        '
        Me.GridView2.Name = "GridView2"
        '
        'GridView1
        '
        Me.GridView1.Name = "GridView1"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(500, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(73, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(-316, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(573, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(-11, 6)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(195, 40)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Promedio Ocupación " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "                        Semana"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlVentas
        '
        Me.pnlVentas.Controls.Add(Me.lblTitulo)
        Me.pnlVentas.Location = New System.Drawing.Point(3, 3)
        Me.pnlVentas.Name = "pnlVentas"
        Me.pnlVentas.Size = New System.Drawing.Size(183, 62)
        Me.pnlVentas.TabIndex = 108
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.pnlVentas)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(186, 65)
        Me.Panel14.TabIndex = 3
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(187, 65)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(74, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(68, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 2
        Me.lblGuardar.Text = "Guardar"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(257, 65)
        Me.pnlEncabezado.TabIndex = 24
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(116, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'GridView5
        '
        Me.GridView5.Name = "GridView5"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.lblGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(95, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(115, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlPie.Location = New System.Drawing.Point(0, 160)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(257, 60)
        Me.pnlPie.TabIndex = 26
        '
        'lblPromedioActual
        '
        Me.lblPromedioActual.AutoSize = True
        Me.lblPromedioActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPromedioActual.ForeColor = System.Drawing.Color.Black
        Me.lblPromedioActual.Location = New System.Drawing.Point(127, 61)
        Me.lblPromedioActual.Name = "lblPromedioActual"
        Me.lblPromedioActual.Size = New System.Drawing.Size(30, 13)
        Me.lblPromedioActual.TabIndex = 2
        Me.lblPromedioActual.Text = "80%"
        '
        'lblTextoActual
        '
        Me.lblTextoActual.AutoSize = True
        Me.lblTextoActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoActual.ForeColor = System.Drawing.Color.Black
        Me.lblTextoActual.Location = New System.Drawing.Point(81, 61)
        Me.lblTextoActual.Name = "lblTextoActual"
        Me.lblTextoActual.Size = New System.Drawing.Size(40, 13)
        Me.lblTextoActual.TabIndex = 2
        Me.lblTextoActual.Text = "Actual:"
        '
        'lblTextoPromedio
        '
        Me.lblTextoPromedio.AutoSize = True
        Me.lblTextoPromedio.Location = New System.Drawing.Point(12, 23)
        Me.lblTextoPromedio.Name = "lblTextoPromedio"
        Me.lblTextoPromedio.Size = New System.Drawing.Size(109, 26)
        Me.lblTextoPromedio.TabIndex = 1
        Me.lblTextoPromedio.Text = "% Máximo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ocupación Promedio:"
        '
        'txtPromedioOcupacion
        '
        Me.txtPromedioOcupacion.Location = New System.Drawing.Point(130, 29)
        Me.txtPromedioOcupacion.Name = "txtPromedioOcupacion"
        Me.txtPromedioOcupacion.Size = New System.Drawing.Size(102, 20)
        Me.txtPromedioOcupacion.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel3.Controls.Add(Me.lblPromedioActual)
        Me.Panel3.Controls.Add(Me.lblTextoActual)
        Me.Panel3.Controls.Add(Me.lblTextoPromedio)
        Me.Panel3.Controls.Add(Me.txtPromedioOcupacion)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 65)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(257, 95)
        Me.Panel3.TabIndex = 27
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.pnlPie)
        Me.Panel1.Controls.Add(Me.pnlEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(257, 220)
        Me.Panel1.TabIndex = 8
        '
        'Programacion_ColocacionSemanal_ConfiguracionPorcentajePromedioSemana_CalcularFechaEntrega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(257, 220)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(273, 259)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(273, 259)
        Me.Name = "Programacion_ColocacionSemanal_ConfiguracionPorcentajePromedioSemana_CalcularFech" &
    "aEntrega"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlVentas.ResumeLayout(False)
        Me.pnlVentas.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlVentas As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents pnlAccionesCabecera As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblGuardar As Label
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents lblPromedioActual As Label
    Friend WithEvents lblTextoActual As Label
    Friend WithEvents lblTextoPromedio As Label
    Friend WithEvents txtPromedioOcupacion As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel1 As Panel
End Class
