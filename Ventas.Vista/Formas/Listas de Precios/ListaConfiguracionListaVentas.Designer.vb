<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaConfiguracionListaVentas
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
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.grupParametrosOrdenamiento = New System.Windows.Forms.GroupBox()
        Me.txtFlete = New System.Windows.Forms.TextBox()
        Me.txtTipoIva = New System.Windows.Forms.TextBox()
        Me.grdDescuentos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNombreCLiente = New System.Windows.Forms.TextBox()
        Me.txtFacturacion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblIdSIcy = New System.Windows.Forms.Label()
        Me.lblIdSay = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTipoiva = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlContenedorEstado = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grupParametrosOrdenamiento.SuspendLayout()
        CType(Me.grdDescuentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlContenedorEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(555, 60)
        Me.pnlHeader.TabIndex = 6
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(205, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(350, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(6, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(281, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Configuración temporal de Cliente"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(290, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(60, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'grupParametrosOrdenamiento
        '
        Me.grupParametrosOrdenamiento.Controls.Add(Me.Label2)
        Me.grupParametrosOrdenamiento.Controls.Add(Me.txtFlete)
        Me.grupParametrosOrdenamiento.Controls.Add(Me.txtTipoIva)
        Me.grupParametrosOrdenamiento.Controls.Add(Me.grdDescuentos)
        Me.grupParametrosOrdenamiento.Controls.Add(Me.Label7)
        Me.grupParametrosOrdenamiento.Controls.Add(Me.txtNombreCLiente)
        Me.grupParametrosOrdenamiento.Controls.Add(Me.txtFacturacion)
        Me.grupParametrosOrdenamiento.Controls.Add(Me.Label4)
        Me.grupParametrosOrdenamiento.Controls.Add(Me.lblIdSIcy)
        Me.grupParametrosOrdenamiento.Controls.Add(Me.lblIdSay)
        Me.grupParametrosOrdenamiento.Controls.Add(Me.Label10)
        Me.grupParametrosOrdenamiento.Controls.Add(Me.Label9)
        Me.grupParametrosOrdenamiento.Controls.Add(Me.lblTipoiva)
        Me.grupParametrosOrdenamiento.Controls.Add(Me.Label1)
        Me.grupParametrosOrdenamiento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grupParametrosOrdenamiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grupParametrosOrdenamiento.Location = New System.Drawing.Point(0, 60)
        Me.grupParametrosOrdenamiento.Name = "grupParametrosOrdenamiento"
        Me.grupParametrosOrdenamiento.Size = New System.Drawing.Size(555, 256)
        Me.grupParametrosOrdenamiento.TabIndex = 7
        Me.grupParametrosOrdenamiento.TabStop = False
        Me.grupParametrosOrdenamiento.Text = "Datos Configurados"
        '
        'txtFlete
        '
        Me.txtFlete.Enabled = False
        Me.txtFlete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFlete.Location = New System.Drawing.Point(113, 85)
        Me.txtFlete.Name = "txtFlete"
        Me.txtFlete.Size = New System.Drawing.Size(140, 20)
        Me.txtFlete.TabIndex = 18
        '
        'txtTipoIva
        '
        Me.txtTipoIva.Enabled = False
        Me.txtTipoIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoIva.Location = New System.Drawing.Point(113, 63)
        Me.txtTipoIva.Name = "txtTipoIva"
        Me.txtTipoIva.Size = New System.Drawing.Size(140, 20)
        Me.txtTipoIva.TabIndex = 8
        '
        'grdDescuentos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDescuentos.DisplayLayout.Appearance = Appearance1
        Me.grdDescuentos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDescuentos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdDescuentos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdDescuentos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdDescuentos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDescuentos.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdDescuentos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdDescuentos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdDescuentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDescuentos.Location = New System.Drawing.Point(3, 110)
        Me.grdDescuentos.Name = "grdDescuentos"
        Me.grdDescuentos.Size = New System.Drawing.Size(549, 143)
        Me.grdDescuentos.TabIndex = 15
        Me.grdDescuentos.Text = "Tipo Descuento"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(41, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Flete"
        '
        'txtNombreCLiente
        '
        Me.txtNombreCLiente.Enabled = False
        Me.txtNombreCLiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreCLiente.Location = New System.Drawing.Point(113, 41)
        Me.txtNombreCLiente.Name = "txtNombreCLiente"
        Me.txtNombreCLiente.Size = New System.Drawing.Size(402, 20)
        Me.txtNombreCLiente.TabIndex = 7
        '
        'txtFacturacion
        '
        Me.txtFacturacion.Enabled = False
        Me.txtFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFacturacion.Location = New System.Drawing.Point(375, 63)
        Me.txtFacturacion.Name = "txtFacturacion"
        Me.txtFacturacion.Size = New System.Drawing.Size(117, 20)
        Me.txtFacturacion.TabIndex = 5
        Me.txtFacturacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(41, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Cliente"
        '
        'lblIdSIcy
        '
        Me.lblIdSIcy.AutoSize = True
        Me.lblIdSIcy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdSIcy.Location = New System.Drawing.Point(250, 23)
        Me.lblIdSIcy.Name = "lblIdSIcy"
        Me.lblIdSIcy.Size = New System.Drawing.Size(13, 13)
        Me.lblIdSIcy.TabIndex = 1
        Me.lblIdSIcy.Text = "0"
        '
        'lblIdSay
        '
        Me.lblIdSay.AutoSize = True
        Me.lblIdSay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdSay.Location = New System.Drawing.Point(113, 23)
        Me.lblIdSay.Name = "lblIdSay"
        Me.lblIdSay.Size = New System.Drawing.Size(13, 13)
        Me.lblIdSay.TabIndex = 1
        Me.lblIdSay.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(179, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "ID SICY"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(41, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "ID SAY"
        '
        'lblTipoiva
        '
        Me.lblTipoiva.AutoSize = True
        Me.lblTipoiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoiva.Location = New System.Drawing.Point(41, 67)
        Me.lblTipoiva.Name = "lblTipoiva"
        Me.lblTipoiva.Size = New System.Drawing.Size(24, 13)
        Me.lblTipoiva.TabIndex = 1
        Me.lblTipoiva.Text = "IVA"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(282, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Facturación"
        '
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.pnlContenedorEstado)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 316)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(555, 60)
        Me.pnlEstado.TabIndex = 9
        '
        'pnlContenedorEstado
        '
        Me.pnlContenedorEstado.Controls.Add(Me.btnCancelar)
        Me.pnlContenedorEstado.Controls.Add(Me.lblCancelar)
        Me.pnlContenedorEstado.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlContenedorEstado.Location = New System.Drawing.Point(398, 0)
        Me.pnlContenedorEstado.Name = "pnlContenedorEstado"
        Me.pnlContenedorEstado.Size = New System.Drawing.Size(157, 60)
        Me.pnlContenedorEstado.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(102, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(101, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(497, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "%"
        '
        'ListaConfiguracionListaVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(555, 376)
        Me.Controls.Add(Me.grupParametrosOrdenamiento)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ListaConfiguracionListaVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración temporal de Cliente"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grupParametrosOrdenamiento.ResumeLayout(False)
        Me.grupParametrosOrdenamiento.PerformLayout()
        CType(Me.grdDescuentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlContenedorEstado.ResumeLayout(False)
        Me.pnlContenedorEstado.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents grupParametrosOrdenamiento As System.Windows.Forms.GroupBox
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlContenedorEstado As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents txtTipoIva As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreCLiente As System.Windows.Forms.TextBox
    Friend WithEvents txtFacturacion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTipoiva As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdDescuentos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblIdSIcy As System.Windows.Forms.Label
    Friend WithEvents lblIdSay As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFlete As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
