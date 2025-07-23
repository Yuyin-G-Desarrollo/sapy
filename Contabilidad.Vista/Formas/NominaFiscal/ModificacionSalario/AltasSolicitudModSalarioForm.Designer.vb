<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasSolicitudModSalarioForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltasSolicitudModSalarioForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblBuscarColaborador = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblPorcentajeDescuento = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblNumCredito = New System.Windows.Forms.Label()
        Me.lblTipoDescuento = New System.Windows.Forms.Label()
        Me.lblValorDescAnterior = New System.Windows.Forms.Label()
        Me.lblValorDescNuevo = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblColaborador = New System.Windows.Forms.Label()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblPuesto = New System.Windows.Forms.Label()
        Me.lblFechaIngreso = New System.Windows.Forms.Label()
        Me.lblAntiguedad = New System.Windows.Forms.Label()
        Me.lblNSS = New System.Windows.Forms.Label()
        Me.lblSueldoAnterior = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblFechaMovimiento = New System.Windows.Forms.Label()
        Me.txtSueldoNuevo = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblModificacionSalarioId = New System.Windows.Forms.Label()
        Me.lblColaboradorId = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblSueldoNuevo = New System.Windows.Forms.Label()
        Me.dtpFechaMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.lblPatronId = New System.Windows.Forms.Label()
        Me.lblFactorIntegracion = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlHeader.Size = New System.Drawing.Size(540, 72)
        Me.pnlHeader.TabIndex = 6
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblBuscarColaborador)
        Me.pnlAcciones.Controls.Add(Me.btnBuscar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(116, 72)
        Me.pnlAcciones.TabIndex = 1
        '
        'lblBuscarColaborador
        '
        Me.lblBuscarColaborador.AutoSize = True
        Me.lblBuscarColaborador.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBuscarColaborador.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscarColaborador.Location = New System.Drawing.Point(7, 46)
        Me.lblBuscarColaborador.Name = "lblBuscarColaborador"
        Me.lblBuscarColaborador.Size = New System.Drawing.Size(100, 13)
        Me.lblBuscarColaborador.TabIndex = 56
        Me.lblBuscarColaborador.Text = "Buscar Colaborador"
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(41, 11)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 55
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(122, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(418, 72)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(49, 24)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(294, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Solicitud de Modificación de Salario"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Colaborador"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Departamento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Puesto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Fecha Ingreso"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Antigüedad"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 229)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "NSS"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 256)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Sueldo Diario Anterior"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 284)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "* Sueldo Diario Nuevo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(30, 314)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Fecha Movimiento"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.lblPorcentajeDescuento)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.lblNumCredito)
        Me.GroupBox1.Controls.Add(Me.lblTipoDescuento)
        Me.GroupBox1.Controls.Add(Me.lblValorDescAnterior)
        Me.GroupBox1.Controls.Add(Me.lblValorDescNuevo)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 343)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(518, 132)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Infonavit"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(195, 65)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(15, 13)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "%"
        '
        'lblPorcentajeDescuento
        '
        Me.lblPorcentajeDescuento.AutoSize = True
        Me.lblPorcentajeDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcentajeDescuento.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPorcentajeDescuento.Location = New System.Drawing.Point(216, 65)
        Me.lblPorcentajeDescuento.Name = "lblPorcentajeDescuento"
        Me.lblPorcentajeDescuento.Size = New System.Drawing.Size(13, 13)
        Me.lblPorcentajeDescuento.TabIndex = 44
        Me.lblPorcentajeDescuento.Text = "--"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(18, 65)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(58, 13)
        Me.Label17.TabIndex = 43
        Me.Label17.Text = "Porcentaje"
        '
        'lblNumCredito
        '
        Me.lblNumCredito.AutoSize = True
        Me.lblNumCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumCredito.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumCredito.Location = New System.Drawing.Point(216, 23)
        Me.lblNumCredito.Name = "lblNumCredito"
        Me.lblNumCredito.Size = New System.Drawing.Size(13, 13)
        Me.lblNumCredito.TabIndex = 42
        Me.lblNumCredito.Text = "--"
        '
        'lblTipoDescuento
        '
        Me.lblTipoDescuento.AutoSize = True
        Me.lblTipoDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoDescuento.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTipoDescuento.Location = New System.Drawing.Point(216, 44)
        Me.lblTipoDescuento.Name = "lblTipoDescuento"
        Me.lblTipoDescuento.Size = New System.Drawing.Size(13, 13)
        Me.lblTipoDescuento.TabIndex = 41
        Me.lblTipoDescuento.Text = "--"
        '
        'lblValorDescAnterior
        '
        Me.lblValorDescAnterior.AutoSize = True
        Me.lblValorDescAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorDescAnterior.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblValorDescAnterior.Location = New System.Drawing.Point(216, 86)
        Me.lblValorDescAnterior.Name = "lblValorDescAnterior"
        Me.lblValorDescAnterior.Size = New System.Drawing.Size(13, 13)
        Me.lblValorDescAnterior.TabIndex = 40
        Me.lblValorDescAnterior.Text = "--"
        '
        'lblValorDescNuevo
        '
        Me.lblValorDescNuevo.AutoSize = True
        Me.lblValorDescNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorDescNuevo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblValorDescNuevo.Location = New System.Drawing.Point(216, 107)
        Me.lblValorDescNuevo.Name = "lblValorDescNuevo"
        Me.lblValorDescNuevo.Size = New System.Drawing.Size(17, 15)
        Me.lblValorDescNuevo.TabIndex = 40
        Me.lblValorDescNuevo.Text = "--"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(195, 107)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 15)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "$"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(195, 86)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(13, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "$"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(18, 107)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(119, 15)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Descuento Nuevo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(18, 86)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Descuento Anterior"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(18, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Tipo de descuento"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(18, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Núm Crédito"
        '
        'lblColaborador
        '
        Me.lblColaborador.AutoSize = True
        Me.lblColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColaborador.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblColaborador.Location = New System.Drawing.Point(164, 89)
        Me.lblColaborador.Name = "lblColaborador"
        Me.lblColaborador.Size = New System.Drawing.Size(13, 13)
        Me.lblColaborador.TabIndex = 29
        Me.lblColaborador.Text = "--"
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartamento.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblDepartamento.Location = New System.Drawing.Point(164, 116)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(13, 13)
        Me.lblDepartamento.TabIndex = 30
        Me.lblDepartamento.Text = "--"
        '
        'lblPuesto
        '
        Me.lblPuesto.AutoSize = True
        Me.lblPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPuesto.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPuesto.Location = New System.Drawing.Point(164, 145)
        Me.lblPuesto.Name = "lblPuesto"
        Me.lblPuesto.Size = New System.Drawing.Size(13, 13)
        Me.lblPuesto.TabIndex = 31
        Me.lblPuesto.Text = "--"
        '
        'lblFechaIngreso
        '
        Me.lblFechaIngreso.AutoSize = True
        Me.lblFechaIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaIngreso.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblFechaIngreso.Location = New System.Drawing.Point(164, 173)
        Me.lblFechaIngreso.Name = "lblFechaIngreso"
        Me.lblFechaIngreso.Size = New System.Drawing.Size(56, 13)
        Me.lblFechaIngreso.TabIndex = 32
        Me.lblFechaIngreso.Text = "- -/- -/- - - -"
        '
        'lblAntiguedad
        '
        Me.lblAntiguedad.AutoSize = True
        Me.lblAntiguedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAntiguedad.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAntiguedad.Location = New System.Drawing.Point(164, 200)
        Me.lblAntiguedad.Name = "lblAntiguedad"
        Me.lblAntiguedad.Size = New System.Drawing.Size(13, 13)
        Me.lblAntiguedad.TabIndex = 33
        Me.lblAntiguedad.Text = "--"
        '
        'lblNSS
        '
        Me.lblNSS.AutoSize = True
        Me.lblNSS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNSS.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNSS.Location = New System.Drawing.Point(164, 229)
        Me.lblNSS.Name = "lblNSS"
        Me.lblNSS.Size = New System.Drawing.Size(13, 13)
        Me.lblNSS.TabIndex = 34
        Me.lblNSS.Text = "--"
        '
        'lblSueldoAnterior
        '
        Me.lblSueldoAnterior.AutoSize = True
        Me.lblSueldoAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSueldoAnterior.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblSueldoAnterior.Location = New System.Drawing.Point(164, 256)
        Me.lblSueldoAnterior.Name = "lblSueldoAnterior"
        Me.lblSueldoAnterior.Size = New System.Drawing.Size(13, 13)
        Me.lblSueldoAnterior.TabIndex = 35
        Me.lblSueldoAnterior.Text = "--"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(145, 256)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(13, 13)
        Me.Label20.TabIndex = 36
        Me.Label20.Text = "$"
        '
        'lblFechaMovimiento
        '
        Me.lblFechaMovimiento.AutoSize = True
        Me.lblFechaMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaMovimiento.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblFechaMovimiento.Location = New System.Drawing.Point(164, 314)
        Me.lblFechaMovimiento.Name = "lblFechaMovimiento"
        Me.lblFechaMovimiento.Size = New System.Drawing.Size(56, 13)
        Me.lblFechaMovimiento.TabIndex = 37
        Me.lblFechaMovimiento.Text = "- -/- -/- - - -"
        '
        'txtSueldoNuevo
        '
        Me.txtSueldoNuevo.Location = New System.Drawing.Point(167, 281)
        Me.txtSueldoNuevo.Name = "txtSueldoNuevo"
        Me.txtSueldoNuevo.Size = New System.Drawing.Size(98, 20)
        Me.txtSueldoNuevo.TabIndex = 38
        Me.txtSueldoNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(145, 284)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(13, 13)
        Me.Label22.TabIndex = 39
        Me.Label22.Text = "$"
        '
        'lblModificacionSalarioId
        '
        Me.lblModificacionSalarioId.AutoSize = True
        Me.lblModificacionSalarioId.Location = New System.Drawing.Point(517, 75)
        Me.lblModificacionSalarioId.Name = "lblModificacionSalarioId"
        Me.lblModificacionSalarioId.Size = New System.Drawing.Size(13, 13)
        Me.lblModificacionSalarioId.TabIndex = 40
        Me.lblModificacionSalarioId.Text = "0"
        Me.lblModificacionSalarioId.Visible = False
        '
        'lblColaboradorId
        '
        Me.lblColaboradorId.AutoSize = True
        Me.lblColaboradorId.Location = New System.Drawing.Point(517, 98)
        Me.lblColaboradorId.Name = "lblColaboradorId"
        Me.lblColaboradorId.Size = New System.Drawing.Size(13, 13)
        Me.lblColaboradorId.TabIndex = 41
        Me.lblColaboradorId.Text = "0"
        Me.lblColaboradorId.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.lblCerrar)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 481)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(540, 62)
        Me.Panel1.TabIndex = 61
        '
        'lblGuardar
        '
        Me.lblGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(428, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 47
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = Global.Contabilidad.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(434, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 46
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(495, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 45
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(496, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 44
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblSueldoNuevo
        '
        Me.lblSueldoNuevo.AutoSize = True
        Me.lblSueldoNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSueldoNuevo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblSueldoNuevo.Location = New System.Drawing.Point(164, 284)
        Me.lblSueldoNuevo.Name = "lblSueldoNuevo"
        Me.lblSueldoNuevo.Size = New System.Drawing.Size(13, 13)
        Me.lblSueldoNuevo.TabIndex = 62
        Me.lblSueldoNuevo.Text = "--"
        Me.lblSueldoNuevo.Visible = False
        '
        'dtpFechaMovimiento
        '
        Me.dtpFechaMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaMovimiento.Location = New System.Drawing.Point(167, 310)
        Me.dtpFechaMovimiento.MaxDate = New Date(2099, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaMovimiento.MinDate = New Date(1991, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaMovimiento.Name = "dtpFechaMovimiento"
        Me.dtpFechaMovimiento.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpFechaMovimiento.RightToLeftLayout = True
        Me.dtpFechaMovimiento.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaMovimiento.TabIndex = 63
        Me.dtpFechaMovimiento.Value = New Date(2016, 11, 3, 9, 42, 29, 0)
        Me.dtpFechaMovimiento.Visible = False
        '
        'lblPatronId
        '
        Me.lblPatronId.AutoSize = True
        Me.lblPatronId.Location = New System.Drawing.Point(517, 120)
        Me.lblPatronId.Name = "lblPatronId"
        Me.lblPatronId.Size = New System.Drawing.Size(13, 13)
        Me.lblPatronId.TabIndex = 64
        Me.lblPatronId.Text = "0"
        Me.lblPatronId.Visible = False
        '
        'lblFactorIntegracion
        '
        Me.lblFactorIntegracion.AutoSize = True
        Me.lblFactorIntegracion.Location = New System.Drawing.Point(517, 145)
        Me.lblFactorIntegracion.Name = "lblFactorIntegracion"
        Me.lblFactorIntegracion.Size = New System.Drawing.Size(13, 13)
        Me.lblFactorIntegracion.TabIndex = 65
        Me.lblFactorIntegracion.Text = "0"
        Me.lblFactorIntegracion.Visible = False
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(346, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 72)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 38
        Me.imgLogo.TabStop = False
        '
        'AltasSolicitudModSalarioForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(540, 543)
        Me.Controls.Add(Me.lblFactorIntegracion)
        Me.Controls.Add(Me.lblPatronId)
        Me.Controls.Add(Me.lblFechaMovimiento)
        Me.Controls.Add(Me.dtpFechaMovimiento)
        Me.Controls.Add(Me.lblSueldoNuevo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblColaboradorId)
        Me.Controls.Add(Me.lblModificacionSalarioId)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtSueldoNuevo)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.lblSueldoAnterior)
        Me.Controls.Add(Me.lblNSS)
        Me.Controls.Add(Me.lblAntiguedad)
        Me.Controls.Add(Me.lblFechaIngreso)
        Me.Controls.Add(Me.lblPuesto)
        Me.Controls.Add(Me.lblDepartamento)
        Me.Controls.Add(Me.lblColaborador)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlHeader)
        Me.MaximizeBox = False
        Me.Name = "AltasSolicitudModSalarioForm"
        Me.Text = "Solicitud de Modificación de Salario"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblBuscarColaborador As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblNumCredito As System.Windows.Forms.Label
    Friend WithEvents lblTipoDescuento As System.Windows.Forms.Label
    Friend WithEvents lblValorDescAnterior As System.Windows.Forms.Label
    Friend WithEvents lblValorDescNuevo As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblColaborador As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblPuesto As System.Windows.Forms.Label
    Friend WithEvents lblFechaIngreso As System.Windows.Forms.Label
    Friend WithEvents lblAntiguedad As System.Windows.Forms.Label
    Friend WithEvents lblNSS As System.Windows.Forms.Label
    Friend WithEvents lblSueldoAnterior As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblFechaMovimiento As System.Windows.Forms.Label
    Friend WithEvents txtSueldoNuevo As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblModificacionSalarioId As System.Windows.Forms.Label
    Friend WithEvents lblColaboradorId As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblSueldoNuevo As System.Windows.Forms.Label
    Friend WithEvents dtpFechaMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPatronId As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblPorcentajeDescuento As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblFactorIntegracion As System.Windows.Forms.Label
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
