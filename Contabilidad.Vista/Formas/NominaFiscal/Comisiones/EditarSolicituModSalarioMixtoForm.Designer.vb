<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditarSolicituModSalarioMixtoForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblFechaMovimiento = New System.Windows.Forms.Label()
        Me.dtpFechaMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtSueldoNuevo = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblSDIFijo = New System.Windows.Forms.Label()
        Me.lblNSS = New System.Windows.Forms.Label()
        Me.lblAntiguedad = New System.Windows.Forms.Label()
        Me.lblFechaIngreso = New System.Windows.Forms.Label()
        Me.lblPuesto = New System.Windows.Forms.Label()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblColaborador = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.grpSalarioMixto = New System.Windows.Forms.GroupBox()
        Me.lblBimestre = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblSDIVariable = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblDiasPagados = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblComisiones = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.grpSalarioMixto.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblFechaMovimiento
        '
        Me.lblFechaMovimiento.AutoSize = True
        Me.lblFechaMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaMovimiento.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblFechaMovimiento.Location = New System.Drawing.Point(171, 318)
        Me.lblFechaMovimiento.Name = "lblFechaMovimiento"
        Me.lblFechaMovimiento.Size = New System.Drawing.Size(56, 13)
        Me.lblFechaMovimiento.TabIndex = 85
        Me.lblFechaMovimiento.Text = "- -/- -/- - - -"
        '
        'dtpFechaMovimiento
        '
        Me.dtpFechaMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaMovimiento.Location = New System.Drawing.Point(174, 314)
        Me.dtpFechaMovimiento.MaxDate = New Date(2099, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaMovimiento.MinDate = New Date(1991, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaMovimiento.Name = "dtpFechaMovimiento"
        Me.dtpFechaMovimiento.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpFechaMovimiento.RightToLeftLayout = True
        Me.dtpFechaMovimiento.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaMovimiento.TabIndex = 92
        Me.dtpFechaMovimiento.Value = New Date(2016, 11, 3, 9, 42, 29, 0)
        Me.dtpFechaMovimiento.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.lblCerrar)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 395)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(693, 62)
        Me.Panel1.TabIndex = 90
        '
        'lblGuardar
        '
        Me.lblGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(581, 40)
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
        Me.btnGuardar.Location = New System.Drawing.Point(587, 6)
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
        Me.lblCerrar.Location = New System.Drawing.Point(648, 40)
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
        Me.btnCerrar.Location = New System.Drawing.Point(649, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 44
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(152, 288)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(13, 13)
        Me.Label22.TabIndex = 87
        Me.Label22.Text = "$"
        '
        'txtSueldoNuevo
        '
        Me.txtSueldoNuevo.Location = New System.Drawing.Point(174, 285)
        Me.txtSueldoNuevo.Name = "txtSueldoNuevo"
        Me.txtSueldoNuevo.Size = New System.Drawing.Size(98, 20)
        Me.txtSueldoNuevo.TabIndex = 86
        Me.txtSueldoNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(145, 256)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(13, 13)
        Me.Label20.TabIndex = 84
        Me.Label20.Text = "$"
        '
        'lblSDIFijo
        '
        Me.lblSDIFijo.AutoSize = True
        Me.lblSDIFijo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSDIFijo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblSDIFijo.Location = New System.Drawing.Point(164, 256)
        Me.lblSDIFijo.Name = "lblSDIFijo"
        Me.lblSDIFijo.Size = New System.Drawing.Size(13, 13)
        Me.lblSDIFijo.TabIndex = 83
        Me.lblSDIFijo.Text = "--"
        '
        'lblNSS
        '
        Me.lblNSS.AutoSize = True
        Me.lblNSS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNSS.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNSS.Location = New System.Drawing.Point(164, 229)
        Me.lblNSS.Name = "lblNSS"
        Me.lblNSS.Size = New System.Drawing.Size(13, 13)
        Me.lblNSS.TabIndex = 82
        Me.lblNSS.Text = "--"
        '
        'lblAntiguedad
        '
        Me.lblAntiguedad.AutoSize = True
        Me.lblAntiguedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAntiguedad.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAntiguedad.Location = New System.Drawing.Point(164, 200)
        Me.lblAntiguedad.Name = "lblAntiguedad"
        Me.lblAntiguedad.Size = New System.Drawing.Size(13, 13)
        Me.lblAntiguedad.TabIndex = 81
        Me.lblAntiguedad.Text = "--"
        '
        'lblFechaIngreso
        '
        Me.lblFechaIngreso.AutoSize = True
        Me.lblFechaIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaIngreso.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblFechaIngreso.Location = New System.Drawing.Point(164, 173)
        Me.lblFechaIngreso.Name = "lblFechaIngreso"
        Me.lblFechaIngreso.Size = New System.Drawing.Size(56, 13)
        Me.lblFechaIngreso.TabIndex = 80
        Me.lblFechaIngreso.Text = "- -/- -/- - - -"
        '
        'lblPuesto
        '
        Me.lblPuesto.AutoSize = True
        Me.lblPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPuesto.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPuesto.Location = New System.Drawing.Point(164, 145)
        Me.lblPuesto.Name = "lblPuesto"
        Me.lblPuesto.Size = New System.Drawing.Size(13, 13)
        Me.lblPuesto.TabIndex = 79
        Me.lblPuesto.Text = "--"
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartamento.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblDepartamento.Location = New System.Drawing.Point(164, 116)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(13, 13)
        Me.lblDepartamento.TabIndex = 78
        Me.lblDepartamento.Text = "--"
        '
        'lblColaborador
        '
        Me.lblColaborador.AutoSize = True
        Me.lblColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColaborador.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblColaborador.Location = New System.Drawing.Point(164, 89)
        Me.lblColaborador.Name = "lblColaborador"
        Me.lblColaborador.Size = New System.Drawing.Size(13, 13)
        Me.lblColaborador.TabIndex = 77
        Me.lblColaborador.Text = "--"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(37, 318)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 13)
        Me.Label9.TabIndex = 75
        Me.Label9.Text = "Fecha Movimiento"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(30, 288)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 13)
        Me.Label8.TabIndex = 74
        Me.Label8.Text = "* Sueldo Diario Nuevo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 256)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "Sueldo Diario Fijo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 229)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 72
        Me.Label6.Text = "NSS"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "Antigüedad"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "Fecha Ingreso"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Puesto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Departamento"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Colaborador"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(693, 72)
        Me.pnlHeader.TabIndex = 66
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(153, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(540, 72)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(112, 24)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(341, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Solicitud de Modificación de Salario Mixto"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 13)
        Me.Label16.TabIndex = 100
        Me.Label16.Text = "Bimestre"
        '
        'grpSalarioMixto
        '
        Me.grpSalarioMixto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSalarioMixto.Controls.Add(Me.lblBimestre)
        Me.grpSalarioMixto.Controls.Add(Me.Label21)
        Me.grpSalarioMixto.Controls.Add(Me.lblSDIVariable)
        Me.grpSalarioMixto.Controls.Add(Me.Label24)
        Me.grpSalarioMixto.Controls.Add(Me.lblDiasPagados)
        Me.grpSalarioMixto.Controls.Add(Me.Label19)
        Me.grpSalarioMixto.Controls.Add(Me.Label13)
        Me.grpSalarioMixto.Controls.Add(Me.lblComisiones)
        Me.grpSalarioMixto.Controls.Add(Me.Label16)
        Me.grpSalarioMixto.Controls.Add(Me.Label15)
        Me.grpSalarioMixto.Location = New System.Drawing.Point(472, 78)
        Me.grpSalarioMixto.Name = "grpSalarioMixto"
        Me.grpSalarioMixto.Size = New System.Drawing.Size(211, 135)
        Me.grpSalarioMixto.TabIndex = 101
        Me.grpSalarioMixto.TabStop = False
        Me.grpSalarioMixto.Text = "Salario Mixto"
        '
        'lblBimestre
        '
        Me.lblBimestre.AutoSize = True
        Me.lblBimestre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBimestre.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblBimestre.Location = New System.Drawing.Point(144, 22)
        Me.lblBimestre.Name = "lblBimestre"
        Me.lblBimestre.Size = New System.Drawing.Size(13, 13)
        Me.lblBimestre.TabIndex = 111
        Me.lblBimestre.Text = "--"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(125, 106)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(13, 13)
        Me.Label21.TabIndex = 110
        Me.Label21.Text = "$"
        '
        'lblSDIVariable
        '
        Me.lblSDIVariable.AutoSize = True
        Me.lblSDIVariable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSDIVariable.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblSDIVariable.Location = New System.Drawing.Point(144, 106)
        Me.lblSDIVariable.Name = "lblSDIVariable"
        Me.lblSDIVariable.Size = New System.Drawing.Size(13, 13)
        Me.lblSDIVariable.TabIndex = 109
        Me.lblSDIVariable.Text = "--"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 106)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(111, 13)
        Me.Label24.TabIndex = 108
        Me.Label24.Text = "Sueldo Diario Variable"
        '
        'lblDiasPagados
        '
        Me.lblDiasPagados.AutoSize = True
        Me.lblDiasPagados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiasPagados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblDiasPagados.Location = New System.Drawing.Point(144, 79)
        Me.lblDiasPagados.Name = "lblDiasPagados"
        Me.lblDiasPagados.Size = New System.Drawing.Size(13, 13)
        Me.lblDiasPagados.TabIndex = 106
        Me.lblDiasPagados.Text = "--"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 79)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(75, 13)
        Me.Label19.TabIndex = 105
        Me.Label19.Text = "Días Pagados"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(125, 51)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(13, 13)
        Me.Label13.TabIndex = 104
        Me.Label13.Text = "$"
        '
        'lblComisiones
        '
        Me.lblComisiones.AutoSize = True
        Me.lblComisiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComisiones.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblComisiones.Location = New System.Drawing.Point(144, 51)
        Me.lblComisiones.Name = "lblComisiones"
        Me.lblComisiones.Size = New System.Drawing.Size(13, 13)
        Me.lblComisiones.TabIndex = 103
        Me.lblComisiones.Text = "--"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 51)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 13)
        Me.Label15.TabIndex = 102
        Me.Label15.Text = "Comisiones"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(468, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 72)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 38
        Me.imgLogo.TabStop = False
        '
        'EditarSolicituModSalarioMixtoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(693, 457)
        Me.Controls.Add(Me.grpSalarioMixto)
        Me.Controls.Add(Me.lblFechaMovimiento)
        Me.Controls.Add(Me.dtpFechaMovimiento)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtSueldoNuevo)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.lblSDIFijo)
        Me.Controls.Add(Me.lblNSS)
        Me.Controls.Add(Me.lblAntiguedad)
        Me.Controls.Add(Me.lblFechaIngreso)
        Me.Controls.Add(Me.lblPuesto)
        Me.Controls.Add(Me.lblDepartamento)
        Me.Controls.Add(Me.lblColaborador)
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
        Me.Name = "EditarSolicituModSalarioMixtoForm"
        Me.Text = "Solicitud de Modificación de Salario Mixto"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.grpSalarioMixto.ResumeLayout(False)
        Me.grpSalarioMixto.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFechaMovimiento As Windows.Forms.Label
    Friend WithEvents dtpFechaMovimiento As Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents lblGuardar As Windows.Forms.Label
    Friend WithEvents btnGuardar As Windows.Forms.Button
    Friend WithEvents lblCerrar As Windows.Forms.Label
    Friend WithEvents btnCerrar As Windows.Forms.Button
    Friend WithEvents Label22 As Windows.Forms.Label
    Friend WithEvents txtSueldoNuevo As Windows.Forms.TextBox
    Friend WithEvents Label20 As Windows.Forms.Label
    Friend WithEvents lblSDIFijo As Windows.Forms.Label
    Friend WithEvents lblNSS As Windows.Forms.Label
    Friend WithEvents lblAntiguedad As Windows.Forms.Label
    Friend WithEvents lblFechaIngreso As Windows.Forms.Label
    Friend WithEvents lblPuesto As Windows.Forms.Label
    Friend WithEvents lblDepartamento As Windows.Forms.Label
    Friend WithEvents lblColaborador As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents pnlHeader As Windows.Forms.Panel
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents grpSalarioMixto As Windows.Forms.GroupBox
    Friend WithEvents Label21 As Windows.Forms.Label
    Friend WithEvents lblSDIVariable As Windows.Forms.Label
    Friend WithEvents Label24 As Windows.Forms.Label
    Friend WithEvents lblDiasPagados As Windows.Forms.Label
    Friend WithEvents Label19 As Windows.Forms.Label
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents lblComisiones As Windows.Forms.Label
    Friend WithEvents Label15 As Windows.Forms.Label
    Friend WithEvents lblBimestre As Windows.Forms.Label
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
