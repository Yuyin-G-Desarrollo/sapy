<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarSaldoPrestamos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarSaldoPrestamos))
        Me.pnlTotal = New System.Windows.Forms.Panel()
        Me.txtActualizacion = New System.Windows.Forms.TextBox()
        Me.txtColaboradorId = New System.Windows.Forms.TextBox()
        Me.txtPrestamoId = New System.Windows.Forms.TextBox()
        Me.txtTotalInteres = New System.Windows.Forms.TextBox()
        Me.pnlSolicitado = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlAGerente = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblRechazar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblPuesto = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblDetalleLote = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlSuperior = New System.Windows.Forms.Panel()
        Me.grdDatosAbono = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grdListaPagos = New Tools.GridTransparent()
        Me.Saldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Interes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AbonoCapital = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NuevoSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Boleano = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlTotal.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlSuperior.SuspendLayout()
        CType(Me.grdDatosAbono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdListaPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTotal
        '
        Me.pnlTotal.BackColor = System.Drawing.Color.White
        Me.pnlTotal.Controls.Add(Me.txtActualizacion)
        Me.pnlTotal.Controls.Add(Me.txtColaboradorId)
        Me.pnlTotal.Controls.Add(Me.txtPrestamoId)
        Me.pnlTotal.Controls.Add(Me.txtTotalInteres)
        Me.pnlTotal.Controls.Add(Me.pnlSolicitado)
        Me.pnlTotal.Controls.Add(Me.Label6)
        Me.pnlTotal.Controls.Add(Me.Label9)
        Me.pnlTotal.Controls.Add(Me.pnlAGerente)
        Me.pnlTotal.Controls.Add(Me.pnlAcciones)
        Me.pnlTotal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlTotal.Location = New System.Drawing.Point(0, 469)
        Me.pnlTotal.Name = "pnlTotal"
        Me.pnlTotal.Size = New System.Drawing.Size(708, 61)
        Me.pnlTotal.TabIndex = 12
        '
        'txtActualizacion
        '
        Me.txtActualizacion.Location = New System.Drawing.Point(554, 74)
        Me.txtActualizacion.Name = "txtActualizacion"
        Me.txtActualizacion.Size = New System.Drawing.Size(84, 20)
        Me.txtActualizacion.TabIndex = 30
        Me.txtActualizacion.Visible = False
        '
        'txtColaboradorId
        '
        Me.txtColaboradorId.Location = New System.Drawing.Point(427, 97)
        Me.txtColaboradorId.Name = "txtColaboradorId"
        Me.txtColaboradorId.Size = New System.Drawing.Size(100, 20)
        Me.txtColaboradorId.TabIndex = 29
        Me.txtColaboradorId.Visible = False
        '
        'txtPrestamoId
        '
        Me.txtPrestamoId.Location = New System.Drawing.Point(427, 74)
        Me.txtPrestamoId.Name = "txtPrestamoId"
        Me.txtPrestamoId.Size = New System.Drawing.Size(100, 20)
        Me.txtPrestamoId.TabIndex = 29
        Me.txtPrestamoId.Visible = False
        '
        'txtTotalInteres
        '
        Me.txtTotalInteres.Location = New System.Drawing.Point(324, 74)
        Me.txtTotalInteres.Name = "txtTotalInteres"
        Me.txtTotalInteres.Size = New System.Drawing.Size(84, 20)
        Me.txtTotalInteres.TabIndex = 28
        Me.txtTotalInteres.Visible = False
        '
        'pnlSolicitado
        '
        Me.pnlSolicitado.BackColor = System.Drawing.Color.Yellow
        Me.pnlSolicitado.Location = New System.Drawing.Point(12, 23)
        Me.pnlSolicitado.Name = "pnlSolicitado"
        Me.pnlSolicitado.Size = New System.Drawing.Size(15, 15)
        Me.pnlSolicitado.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(30, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Por pagar"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(126, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Pagado"
        '
        'pnlAGerente
        '
        Me.pnlAGerente.BackColor = System.Drawing.Color.Green
        Me.pnlAGerente.Location = New System.Drawing.Point(105, 23)
        Me.pnlAGerente.Name = "pnlAGerente"
        Me.pnlAGerente.Size = New System.Drawing.Size(15, 15)
        Me.pnlAGerente.TabIndex = 24
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblRechazar)
        Me.pnlAcciones.Controls.Add(Me.btnCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(640, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(68, 61)
        Me.pnlAcciones.TabIndex = 8
        '
        'lblRechazar
        '
        Me.lblRechazar.AutoSize = True
        Me.lblRechazar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRechazar.Location = New System.Drawing.Point(17, 41)
        Me.lblRechazar.Name = "lblRechazar"
        Me.lblRechazar.Size = New System.Drawing.Size(35, 13)
        Me.lblRechazar.TabIndex = 18
        Me.lblRechazar.Text = "Cerrar"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.cancelar_32
        Me.btnCancelar.Location = New System.Drawing.Point(18, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 0
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(23, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Imprimir"
        '
        'btnImprimir
        '
        Me.btnImprimir.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(28, 5)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 19
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(42, 72)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(107, 126)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lblNombre.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNombre.Location = New System.Drawing.Point(112, 28)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(57, 16)
        Me.lblNombre.TabIndex = 1
        Me.lblNombre.Text = "Nombre"
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lblDepartamento.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblDepartamento.Location = New System.Drawing.Point(112, 59)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(94, 16)
        Me.lblDepartamento.TabIndex = 2
        Me.lblDepartamento.Text = "Departamento"
        '
        'lblPuesto
        '
        Me.lblPuesto.AutoSize = True
        Me.lblPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lblPuesto.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPuesto.Location = New System.Drawing.Point(112, 90)
        Me.lblPuesto.Name = "lblPuesto"
        Me.lblPuesto.Size = New System.Drawing.Size(50, 16)
        Me.lblPuesto.TabIndex = 3
        Me.lblPuesto.Text = "Puesto"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.Label1)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Controls.Add(Me.btnImprimir)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(708, 59)
        Me.pnlEncabezado.TabIndex = 4
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblDetalleLote)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(356, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(352, 59)
        Me.pnlTitulo.TabIndex = 22
        '
        'lblDetalleLote
        '
        Me.lblDetalleLote.AutoSize = True
        Me.lblDetalleLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetalleLote.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblDetalleLote.Location = New System.Drawing.Point(13, 19)
        Me.lblDetalleLote.Name = "lblDetalleLote"
        Me.lblDetalleLote.Size = New System.Drawing.Size(252, 20)
        Me.lblDetalleLote.TabIndex = 21
        Me.lblDetalleLote.Text = "Consultar Saldo de Préstamos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(10, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 16)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Puesto"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(10, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 16)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Colaborador"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblNombre)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblDepartamento)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblPuesto)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(155, 67)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(512, 137)
        Me.Panel1.TabIndex = 59
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(10, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 16)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Departamento"
        '
        'pnlSuperior
        '
        Me.pnlSuperior.BackColor = System.Drawing.Color.Transparent
        Me.pnlSuperior.Controls.Add(Me.Panel1)
        Me.pnlSuperior.Controls.Add(Me.pnlEncabezado)
        Me.pnlSuperior.Controls.Add(Me.PictureBox1)
        Me.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSuperior.Location = New System.Drawing.Point(0, 0)
        Me.pnlSuperior.Name = "pnlSuperior"
        Me.pnlSuperior.Size = New System.Drawing.Size(708, 213)
        Me.pnlSuperior.TabIndex = 9
        '
        'grdDatosAbono
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDatosAbono.DisplayLayout.Appearance = Appearance1
        Me.grdDatosAbono.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDatosAbono.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDatosAbono.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdDatosAbono.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.AppearancesOnly
        Me.grdDatosAbono.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Me.grdDatosAbono.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatosAbono.Location = New System.Drawing.Point(0, 213)
        Me.grdDatosAbono.Name = "grdDatosAbono"
        Me.grdDatosAbono.Size = New System.Drawing.Size(708, 256)
        Me.grdDatosAbono.TabIndex = 14
        '
        'grdListaPagos
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdListaPagos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdListaPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdListaPagos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Saldo, Me.Interes, Me.AbonoCapital, Me.Total, Me.NuevoSaldo, Me.Boleano})
        Me.grdListaPagos.DGVHasTransparentBackground = True
        Me.grdListaPagos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaPagos.EnableHeadersVisualStyles = False
        Me.grdListaPagos.Location = New System.Drawing.Point(0, 0)
        Me.grdListaPagos.Name = "grdListaPagos"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdListaPagos.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.grdListaPagos.Size = New System.Drawing.Size(708, 530)
        Me.grdListaPagos.TabIndex = 10
        '
        'Saldo
        '
        Me.Saldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent
        Me.Saldo.DefaultCellStyle = DataGridViewCellStyle2
        Me.Saldo.HeaderText = "Saldo "
        Me.Saldo.Name = "Saldo"
        '
        'Interes
        '
        Me.Interes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle3.Format = "c2"
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent
        Me.Interes.DefaultCellStyle = DataGridViewCellStyle3
        Me.Interes.HeaderText = "Interes"
        Me.Interes.Name = "Interes"
        '
        'AbonoCapital
        '
        Me.AbonoCapital.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle4.Format = "c2"
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent
        Me.AbonoCapital.DefaultCellStyle = DataGridViewCellStyle4
        Me.AbonoCapital.HeaderText = "Abono a Capital"
        Me.AbonoCapital.Name = "AbonoCapital"
        '
        'Total
        '
        Me.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle5.Format = "c2"
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Transparent
        Me.Total.DefaultCellStyle = DataGridViewCellStyle5
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        '
        'NuevoSaldo
        '
        Me.NuevoSaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle6.Format = "c2"
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Transparent
        Me.NuevoSaldo.DefaultCellStyle = DataGridViewCellStyle6
        Me.NuevoSaldo.HeaderText = "Nuevo Saldo"
        Me.NuevoSaldo.Name = "NuevoSaldo"
        '
        'Boleano
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Transparent
        Me.Boleano.DefaultCellStyle = DataGridViewCellStyle7
        Me.Boleano.HeaderText = "Boleano"
        Me.Boleano.Name = "Boleano"
        Me.Boleano.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.HeaderText = "Saldo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "##,##0.##"
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn2.HeaderText = "Interes"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        DataGridViewCellStyle10.Format = "##,##0.##"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn3.HeaderText = "Abono a Capital"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        DataGridViewCellStyle11.Format = "##,##0.##"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn4.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        DataGridViewCellStyle12.Format = "##,##0.##"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn5.HeaderText = "Nuevo Saldo"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        DataGridViewCellStyle13.Format = "##,##0.##"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn6.HeaderText = "Boleano"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Boleano"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(284, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 47
        Me.pcbTitulo.TabStop = False
        '
        'ConsultarSaldoPrestamos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(708, 530)
        Me.Controls.Add(Me.grdDatosAbono)
        Me.Controls.Add(Me.pnlTotal)
        Me.Controls.Add(Me.pnlSuperior)
        Me.Controls.Add(Me.grdListaPagos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConsultarSaldoPrestamos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consulta de Abonos"
        Me.pnlTotal.ResumeLayout(False)
        Me.pnlTotal.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlSuperior.ResumeLayout(False)
        CType(Me.grdDatosAbono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdListaPagos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Boleano As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NuevoSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AbonoCapital As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Interes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Saldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grdListaPagos As Tools.GridTransparent
    Friend WithEvents pnlTotal As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblRechazar As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblPuesto As System.Windows.Forms.Label
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblDetalleLote As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlSuperior As System.Windows.Forms.Panel
    Friend WithEvents grdDatosAbono As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents pnlSolicitado As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlAGerente As System.Windows.Forms.Panel
    Friend WithEvents txtTotalInteres As System.Windows.Forms.TextBox
    Friend WithEvents txtColaboradorId As System.Windows.Forms.TextBox
    Friend WithEvents txtPrestamoId As System.Windows.Forms.TextBox
    Friend WithEvents txtActualizacion As System.Windows.Forms.TextBox
    Friend WithEvents pcbTitulo As PictureBox
End Class
