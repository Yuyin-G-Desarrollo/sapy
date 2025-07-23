<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaOrdenamientoForm
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
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grupParametrosOrdenamiento = New System.Windows.Forms.GroupBox()
        Me.rdoSinOrden = New System.Windows.Forms.RadioButton()
        Me.lblFormularioReporte = New System.Windows.Forms.Label()
        Me.rdoColeccion = New System.Windows.Forms.RadioButton()
        Me.rdoFamilia = New System.Windows.Forms.RadioButton()
        Me.rdoMarca = New System.Windows.Forms.RadioButton()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlContenedorEstado = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.grdDatosCargados = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGenerarReporte = New System.Windows.Forms.Button()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.grupParametrosOrdenamiento.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlContenedorEstado.SuspendLayout()
        CType(Me.grdDatosCargados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlHeader.Size = New System.Drawing.Size(534, 60)
        Me.pnlHeader.TabIndex = 5
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(164, 60)
        Me.pnlAcciones.TabIndex = 1
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(326, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(208, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(9, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(136, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Lista de precios"
        '
        'grupParametrosOrdenamiento
        '
        Me.grupParametrosOrdenamiento.Controls.Add(Me.rdoSinOrden)
        Me.grupParametrosOrdenamiento.Controls.Add(Me.lblFormularioReporte)
        Me.grupParametrosOrdenamiento.Controls.Add(Me.btnGenerarReporte)
        Me.grupParametrosOrdenamiento.Controls.Add(Me.rdoColeccion)
        Me.grupParametrosOrdenamiento.Controls.Add(Me.rdoFamilia)
        Me.grupParametrosOrdenamiento.Controls.Add(Me.rdoMarca)
        Me.grupParametrosOrdenamiento.Dock = System.Windows.Forms.DockStyle.Top
        Me.grupParametrosOrdenamiento.Location = New System.Drawing.Point(0, 60)
        Me.grupParametrosOrdenamiento.Name = "grupParametrosOrdenamiento"
        Me.grupParametrosOrdenamiento.Size = New System.Drawing.Size(534, 68)
        Me.grupParametrosOrdenamiento.TabIndex = 6
        Me.grupParametrosOrdenamiento.TabStop = False
        Me.grupParametrosOrdenamiento.Text = "Parámetros de Ordenamiento"
        '
        'rdoSinOrden
        '
        Me.rdoSinOrden.AutoSize = True
        Me.rdoSinOrden.Checked = True
        Me.rdoSinOrden.Location = New System.Drawing.Point(30, 30)
        Me.rdoSinOrden.Name = "rdoSinOrden"
        Me.rdoSinOrden.Size = New System.Drawing.Size(80, 17)
        Me.rdoSinOrden.TabIndex = 5
        Me.rdoSinOrden.TabStop = True
        Me.rdoSinOrden.Text = "No Ordenar"
        Me.rdoSinOrden.UseVisualStyleBackColor = True
        '
        'lblFormularioReporte
        '
        Me.lblFormularioReporte.AutoSize = True
        Me.lblFormularioReporte.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblFormularioReporte.Location = New System.Drawing.Point(473, 49)
        Me.lblFormularioReporte.Name = "lblFormularioReporte"
        Me.lblFormularioReporte.Size = New System.Drawing.Size(45, 13)
        Me.lblFormularioReporte.TabIndex = 4
        Me.lblFormularioReporte.Text = "Generar"
        '
        'rdoColeccion
        '
        Me.rdoColeccion.AutoSize = True
        Me.rdoColeccion.Location = New System.Drawing.Point(213, 30)
        Me.rdoColeccion.Name = "rdoColeccion"
        Me.rdoColeccion.Size = New System.Drawing.Size(72, 17)
        Me.rdoColeccion.TabIndex = 2
        Me.rdoColeccion.Text = "Colección"
        Me.rdoColeccion.UseVisualStyleBackColor = True
        '
        'rdoFamilia
        '
        Me.rdoFamilia.AutoSize = True
        Me.rdoFamilia.Location = New System.Drawing.Point(310, 30)
        Me.rdoFamilia.Name = "rdoFamilia"
        Me.rdoFamilia.Size = New System.Drawing.Size(57, 17)
        Me.rdoFamilia.TabIndex = 1
        Me.rdoFamilia.Text = "Familia"
        Me.rdoFamilia.UseVisualStyleBackColor = True
        '
        'rdoMarca
        '
        Me.rdoMarca.AutoSize = True
        Me.rdoMarca.Location = New System.Drawing.Point(134, 30)
        Me.rdoMarca.Name = "rdoMarca"
        Me.rdoMarca.Size = New System.Drawing.Size(55, 17)
        Me.rdoMarca.TabIndex = 0
        Me.rdoMarca.Text = "Marca"
        Me.rdoMarca.UseVisualStyleBackColor = True
        '
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.pnlContenedorEstado)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 466)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(534, 60)
        Me.pnlEstado.TabIndex = 8
        '
        'pnlContenedorEstado
        '
        Me.pnlContenedorEstado.Controls.Add(Me.btnCancelar)
        Me.pnlContenedorEstado.Controls.Add(Me.lblCancelar)
        Me.pnlContenedorEstado.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlContenedorEstado.Location = New System.Drawing.Point(377, 0)
        Me.pnlContenedorEstado.Name = "pnlContenedorEstado"
        Me.pnlContenedorEstado.Size = New System.Drawing.Size(157, 60)
        Me.pnlContenedorEstado.TabIndex = 2
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(94, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cancelar"
        '
        'grdDatosCargados
        '
        Me.grdDatosCargados.AllowDrop = True
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDatosCargados.DisplayLayout.Appearance = Appearance1
        Me.grdDatosCargados.DisplayLayout.Override.FixedRowStyle = Infragistics.Win.UltraWinGrid.FixedRowStyle.Bottom
        Me.grdDatosCargados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatosCargados.Location = New System.Drawing.Point(0, 128)
        Me.grdDatosCargados.Name = "grdDatosCargados"
        Me.grdDatosCargados.Size = New System.Drawing.Size(534, 338)
        Me.grdDatosCargados.TabIndex = 9
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar_32
        Me.btnCancelar.Location = New System.Drawing.Point(102, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGenerarReporte
        '
        Me.btnGenerarReporte.Image = Global.Ventas.Vista.My.Resources.Resources.aceptar_32
        Me.btnGenerarReporte.Location = New System.Drawing.Point(479, 15)
        Me.btnGenerarReporte.Name = "btnGenerarReporte"
        Me.btnGenerarReporte.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarReporte.TabIndex = 3
        Me.btnGenerarReporte.UseVisualStyleBackColor = True
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(148, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(60, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'ListaOrdenamientoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(534, 526)
        Me.Controls.Add(Me.grdDatosCargados)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.grupParametrosOrdenamiento)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ListaOrdenamientoForm"
        Me.Text = "ListaOrdenamientoForm"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.grupParametrosOrdenamiento.ResumeLayout(False)
        Me.grupParametrosOrdenamiento.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlContenedorEstado.ResumeLayout(False)
        Me.pnlContenedorEstado.PerformLayout()
        CType(Me.grdDatosCargados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents grupParametrosOrdenamiento As System.Windows.Forms.GroupBox
    Friend WithEvents rdoColeccion As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFamilia As System.Windows.Forms.RadioButton
    Friend WithEvents rdoMarca As System.Windows.Forms.RadioButton
    Friend WithEvents lblFormularioReporte As System.Windows.Forms.Label
    Friend WithEvents btnGenerarReporte As System.Windows.Forms.Button
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlContenedorEstado As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents rdoSinOrden As System.Windows.Forms.RadioButton
    Friend WithEvents grdDatosCargados As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
