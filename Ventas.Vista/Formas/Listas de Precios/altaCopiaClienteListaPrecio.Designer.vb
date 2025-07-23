<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class altaCopiaClienteListaPrecio
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
        Me.grdClientesCopia = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtListaVentas = New System.Windows.Forms.TextBox()
        Me.txtClienteOriginal = New System.Windows.Forms.TextBox()
        Me.chkSeleccionarFiltrados = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblContClientes = New System.Windows.Forms.Label()
        Me.lblClientes = New System.Windows.Forms.Label()
        CType(Me.grdClientesCopia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdClientesCopia
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientesCopia.DisplayLayout.Appearance = Appearance1
        Me.grdClientesCopia.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClientesCopia.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdClientesCopia.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdClientesCopia.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClientesCopia.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientesCopia.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdClientesCopia.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClientesCopia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClientesCopia.Location = New System.Drawing.Point(0, 139)
        Me.grdClientesCopia.Name = "grdClientesCopia"
        Me.grdClientesCopia.Size = New System.Drawing.Size(719, 256)
        Me.grdClientesCopia.TabIndex = 57
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(719, 60)
        Me.pnlHeader.TabIndex = 58
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pctTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(321, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(398, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(4, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(322, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Copiar Lista de Precios a otros clientes"
        '
        'pctTitulo
        '
        Me.pctTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pctTitulo.Location = New System.Drawing.Point(330, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pctTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pctTitulo.TabIndex = 0
        Me.pctTitulo.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.lblContClientes)
        Me.Panel2.Controls.Add(Me.lblClientes)
        Me.Panel2.Controls.Add(Me.pnlAcciones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 395)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(719, 60)
        Me.Panel2.TabIndex = 59
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(562, 0)
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
        Me.lblCancelar.Location = New System.Drawing.Point(101, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtListaVentas)
        Me.Panel1.Controls.Add(Me.txtClienteOriginal)
        Me.Panel1.Controls.Add(Me.chkSeleccionarFiltrados)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(719, 79)
        Me.Panel1.TabIndex = 60
        '
        'txtListaVentas
        '
        Me.txtListaVentas.Enabled = False
        Me.txtListaVentas.Location = New System.Drawing.Point(146, 31)
        Me.txtListaVentas.Name = "txtListaVentas"
        Me.txtListaVentas.Size = New System.Drawing.Size(281, 20)
        Me.txtListaVentas.TabIndex = 0
        '
        'txtClienteOriginal
        '
        Me.txtClienteOriginal.Enabled = False
        Me.txtClienteOriginal.Location = New System.Drawing.Point(146, 8)
        Me.txtClienteOriginal.Name = "txtClienteOriginal"
        Me.txtClienteOriginal.Size = New System.Drawing.Size(281, 20)
        Me.txtClienteOriginal.TabIndex = 0
        '
        'chkSeleccionarFiltrados
        '
        Me.chkSeleccionarFiltrados.AutoSize = True
        Me.chkSeleccionarFiltrados.Location = New System.Drawing.Point(36, 58)
        Me.chkSeleccionarFiltrados.Name = "chkSeleccionarFiltrados"
        Me.chkSeleccionarFiltrados.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarFiltrados.TabIndex = 46
        Me.chkSeleccionarFiltrados.Text = "Seleccionar Todo"
        Me.chkSeleccionarFiltrados.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Lista de Ventas"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(33, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 13)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "Cliente Original "
        '
        'lblContClientes
        '
        Me.lblContClientes.AutoSize = True
        Me.lblContClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContClientes.ForeColor = System.Drawing.Color.Black
        Me.lblContClientes.Location = New System.Drawing.Point(67, 33)
        Me.lblContClientes.Name = "lblContClientes"
        Me.lblContClientes.Size = New System.Drawing.Size(25, 25)
        Me.lblContClientes.TabIndex = 45
        Me.lblContClientes.Text = "0"
        '
        'lblClientes
        '
        Me.lblClientes.AutoSize = True
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.ForeColor = System.Drawing.Color.Black
        Me.lblClientes.Location = New System.Drawing.Point(23, 3)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(112, 32)
        Me.lblClientes.TabIndex = 46
        Me.lblClientes.Text = "Clientes " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccionados"
        Me.lblClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'altaCopiaClienteListaPrecio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(719, 455)
        Me.Controls.Add(Me.grdClientesCopia)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "altaCopiaClienteListaPrecio"
        Me.Text = "Copiar Lista de Precios a otros clientes"
        CType(Me.grdClientesCopia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdClientesCopia As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pctTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkSeleccionarFiltrados As System.Windows.Forms.CheckBox
    Friend WithEvents txtListaVentas As System.Windows.Forms.TextBox
    Friend WithEvents txtClienteOriginal As System.Windows.Forms.TextBox
    Friend WithEvents lblContClientes As System.Windows.Forms.Label
    Friend WithEvents lblClientes As System.Windows.Forms.Label
End Class
