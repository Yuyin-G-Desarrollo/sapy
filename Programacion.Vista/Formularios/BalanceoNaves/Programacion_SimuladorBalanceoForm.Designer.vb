<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Programacion_SimuladorBalanceoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Programacion_SimuladorBalanceoForm))
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSemanaNave = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lblParesTotales = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblSabado = New System.Windows.Forms.Label()
        Me.lblViernes = New System.Windows.Forms.Label()
        Me.lblJueves = New System.Windows.Forms.Label()
        Me.lblMiercoles = New System.Windows.Forms.Label()
        Me.lblMartes = New System.Windows.Forms.Label()
        Me.lblLunes = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PrioridadBaja = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PrioridadMedia = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PrioridadAlta = New System.Windows.Forms.Panel()
        Me.lblRegistrosTitulo = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblLabelUltimaActualizacion = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.dgSimuladorBlanceo = New DevExpress.XtraGrid.GridControl()
        Me.dgVSimuladorBalanceo = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlFiltros.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgSimuladorBlanceo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgVSimuladorBalanceo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.Panel6)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 107)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1173, 10)
        Me.pnlFiltros.TabIndex = 9
        '
        'Panel6
        '
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(1053, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(120, 10)
        Me.Panel6.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.Location = New System.Drawing.Point(248, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 13)
        Me.Label7.TabIndex = 91
        Me.Label7.Text = "Nuevo Formulario S"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label7.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(22, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 90
        Me.Label6.Text = "Exportar"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lblSemanaNave)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 78)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1173, 29)
        Me.Panel2.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(856, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 23)
        Me.Label1.TabIndex = 187
        Me.Label1.Text = "Pares Totales"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSemanaNave
        '
        Me.lblSemanaNave.AutoSize = True
        Me.lblSemanaNave.Location = New System.Drawing.Point(18, 7)
        Me.lblSemanaNave.Name = "lblSemanaNave"
        Me.lblSemanaNave.Size = New System.Drawing.Size(16, 13)
        Me.lblSemanaNave.TabIndex = 91
        Me.lblSemanaNave.Text = "..."
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.lblParesTotales)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(1053, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(120, 29)
        Me.Panel7.TabIndex = 0
        '
        'lblParesTotales
        '
        Me.lblParesTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesTotales.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblParesTotales.Location = New System.Drawing.Point(18, 3)
        Me.lblParesTotales.Name = "lblParesTotales"
        Me.lblParesTotales.Size = New System.Drawing.Size(86, 22)
        Me.lblParesTotales.TabIndex = 188
        Me.lblParesTotales.Text = "0"
        Me.lblParesTotales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnlTitulo)
        Me.Panel1.Controls.Add(Me.btnExportar)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1173, 78)
        Me.Panel1.TabIndex = 7
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(857, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(316, 78)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(18, 27)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(194, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Simulador de Balanceo"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExportar
        '
        Me.btnExportar.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(25, 15)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 89
        Me.btnExportar.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.btnActualizar)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Controls.Add(Me.GroupBox12)
        Me.Panel3.Controls.Add(Me.lblRegistrosTitulo)
        Me.Panel3.Controls.Add(Me.lblRegistros)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 478)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1173, 65)
        Me.Panel3.TabIndex = 10
        '
        'btnActualizar
        '
        Me.btnActualizar.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnActualizar.Image = Global.Programacion.Vista.My.Resources.Resources.refresh_32
        Me.btnActualizar.Location = New System.Drawing.Point(809, 11)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(32, 32)
        Me.btnActualizar.TabIndex = 91
        Me.btnActualizar.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label15.Location = New System.Drawing.Point(802, 46)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 13)
        Me.Label15.TabIndex = 92
        Me.Label15.Text = "Actualizar"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSabado)
        Me.GroupBox1.Controls.Add(Me.lblViernes)
        Me.GroupBox1.Controls.Add(Me.lblJueves)
        Me.GroupBox1.Controls.Add(Me.lblMiercoles)
        Me.GroupBox1.Controls.Add(Me.lblMartes)
        Me.GroupBox1.Controls.Add(Me.lblLunes)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(467, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(325, 55)
        Me.GroupBox1.TabIndex = 188
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Totales por Día"
        '
        'lblSabado
        '
        Me.lblSabado.AutoSize = True
        Me.lblSabado.Location = New System.Drawing.Point(280, 37)
        Me.lblSabado.Name = "lblSabado"
        Me.lblSabado.Size = New System.Drawing.Size(10, 13)
        Me.lblSabado.TabIndex = 33
        Me.lblSabado.Text = "-"
        '
        'lblViernes
        '
        Me.lblViernes.AutoSize = True
        Me.lblViernes.Location = New System.Drawing.Point(280, 18)
        Me.lblViernes.Name = "lblViernes"
        Me.lblViernes.Size = New System.Drawing.Size(10, 13)
        Me.lblViernes.TabIndex = 32
        Me.lblViernes.Text = "-"
        '
        'lblJueves
        '
        Me.lblJueves.AutoSize = True
        Me.lblJueves.Location = New System.Drawing.Point(160, 37)
        Me.lblJueves.Name = "lblJueves"
        Me.lblJueves.Size = New System.Drawing.Size(10, 13)
        Me.lblJueves.TabIndex = 31
        Me.lblJueves.Text = "-"
        '
        'lblMiercoles
        '
        Me.lblMiercoles.AutoSize = True
        Me.lblMiercoles.Location = New System.Drawing.Point(160, 18)
        Me.lblMiercoles.Name = "lblMiercoles"
        Me.lblMiercoles.Size = New System.Drawing.Size(10, 13)
        Me.lblMiercoles.TabIndex = 30
        Me.lblMiercoles.Text = "-"
        '
        'lblMartes
        '
        Me.lblMartes.AutoSize = True
        Me.lblMartes.Location = New System.Drawing.Point(48, 37)
        Me.lblMartes.Name = "lblMartes"
        Me.lblMartes.Size = New System.Drawing.Size(10, 13)
        Me.lblMartes.TabIndex = 29
        Me.lblMartes.Text = "-"
        '
        'lblLunes
        '
        Me.lblLunes.AutoSize = True
        Me.lblLunes.Location = New System.Drawing.Point(48, 18)
        Me.lblLunes.Name = "lblLunes"
        Me.lblLunes.Size = New System.Drawing.Size(10, 13)
        Me.lblLunes.TabIndex = 28
        Me.lblLunes.Text = "-"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(216, 36)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 13)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Sábado"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(216, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Viernes"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(100, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 13)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Jueves"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(100, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Miércoles "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Martes"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Lunes"
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Label3)
        Me.GroupBox12.Controls.Add(Me.PrioridadBaja)
        Me.GroupBox12.Controls.Add(Me.Label2)
        Me.GroupBox12.Controls.Add(Me.PrioridadMedia)
        Me.GroupBox12.Controls.Add(Me.Label12)
        Me.GroupBox12.Controls.Add(Me.PrioridadAlta)
        Me.GroupBox12.Location = New System.Drawing.Point(129, 5)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(325, 55)
        Me.GroupBox12.TabIndex = 187
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Prioridad ( P )"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(220, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Prioridad Baja"
        '
        'PrioridadBaja
        '
        Me.PrioridadBaja.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.PrioridadBaja.ForeColor = System.Drawing.Color.Black
        Me.PrioridadBaja.Location = New System.Drawing.Point(202, 16)
        Me.PrioridadBaja.Name = "PrioridadBaja"
        Me.PrioridadBaja.Size = New System.Drawing.Size(15, 15)
        Me.PrioridadBaja.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Prioridad Media"
        '
        'PrioridadMedia
        '
        Me.PrioridadMedia.BackColor = System.Drawing.Color.Khaki
        Me.PrioridadMedia.ForeColor = System.Drawing.Color.Black
        Me.PrioridadMedia.Location = New System.Drawing.Point(6, 37)
        Me.PrioridadMedia.Name = "PrioridadMedia"
        Me.PrioridadMedia.Size = New System.Drawing.Size(15, 15)
        Me.PrioridadMedia.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(24, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Prioridad Alta"
        '
        'PrioridadAlta
        '
        Me.PrioridadAlta.BackColor = System.Drawing.Color.IndianRed
        Me.PrioridadAlta.ForeColor = System.Drawing.Color.Black
        Me.PrioridadAlta.Location = New System.Drawing.Point(6, 16)
        Me.PrioridadAlta.Name = "PrioridadAlta"
        Me.PrioridadAlta.Size = New System.Drawing.Size(15, 15)
        Me.PrioridadAlta.TabIndex = 23
        '
        'lblRegistrosTitulo
        '
        Me.lblRegistrosTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistrosTitulo.ForeColor = System.Drawing.Color.Black
        Me.lblRegistrosTitulo.Location = New System.Drawing.Point(30, 11)
        Me.lblRegistrosTitulo.Name = "lblRegistrosTitulo"
        Me.lblRegistrosTitulo.Size = New System.Drawing.Size(86, 23)
        Me.lblRegistrosTitulo.TabIndex = 185
        Me.lblRegistrosTitulo.Text = "Registros"
        Me.lblRegistrosTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRegistros
        '
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRegistros.Location = New System.Drawing.Point(30, 36)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(86, 22)
        Me.lblRegistros.TabIndex = 186
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblUltimaActualizacion)
        Me.Panel5.Controls.Add(Me.lblLabelUltimaActualizacion)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.btnGuardar)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.btnCerrar)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(857, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(316, 65)
        Me.Panel5.TabIndex = 0
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(70, 34)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(118, 13)
        Me.lblUltimaActualizacion.TabIndex = 162
        Me.lblUltimaActualizacion.Text = "13/02/2019 12:34 p.m."
        '
        'lblLabelUltimaActualizacion
        '
        Me.lblLabelUltimaActualizacion.AutoSize = True
        Me.lblLabelUltimaActualizacion.Location = New System.Drawing.Point(78, 16)
        Me.lblLabelUltimaActualizacion.Name = "lblLabelUltimaActualizacion"
        Me.lblLabelUltimaActualizacion.Size = New System.Drawing.Size(102, 13)
        Me.lblLabelUltimaActualizacion.TabIndex = 161
        Me.lblLabelUltimaActualizacion.Text = "Última Actualización"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(215, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Guardar"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(221, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 91
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(269, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Cerrar"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.Location = New System.Drawing.Point(270, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 89
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.dgSimuladorBlanceo)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 117)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1173, 361)
        Me.Panel4.TabIndex = 11
        '
        'dgSimuladorBlanceo
        '
        Me.dgSimuladorBlanceo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSimuladorBlanceo.Location = New System.Drawing.Point(0, 0)
        Me.dgSimuladorBlanceo.MainView = Me.dgVSimuladorBalanceo
        Me.dgSimuladorBlanceo.Name = "dgSimuladorBlanceo"
        Me.dgSimuladorBlanceo.Size = New System.Drawing.Size(1173, 361)
        Me.dgSimuladorBlanceo.TabIndex = 34
        Me.dgSimuladorBlanceo.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgVSimuladorBalanceo})
        '
        'dgVSimuladorBalanceo
        '
        Me.dgVSimuladorBalanceo.GridControl = Me.dgSimuladorBlanceo
        Me.dgVSimuladorBalanceo.Name = "dgVSimuladorBalanceo"
        Me.dgVSimuladorBalanceo.OptionsMenu.EnableColumnMenu = False
        Me.dgVSimuladorBalanceo.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.dgVSimuladorBalanceo.OptionsSelection.InvertSelection = True
        Me.dgVSimuladorBalanceo.OptionsSelection.MultiSelect = True
        Me.dgVSimuladorBalanceo.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.dgVSimuladorBalanceo.OptionsView.ShowAutoFilterRow = True
        Me.dgVSimuladorBalanceo.OptionsView.ShowFooter = True
        Me.dgVSimuladorBalanceo.OptionsView.ShowGroupPanel = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(233, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(83, 78)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'Programacion_SimuladorBalanceoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1173, 543)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Programacion_SimuladorBalanceoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Simulador Balanceo"
        Me.pnlFiltros.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.dgSimuladorBlanceo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgVSimuladorBalanceo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlFiltros As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents btnExportar As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblRegistrosTitulo As Label
    Friend WithEvents lblRegistros As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblUltimaActualizacion As Label
    Friend WithEvents lblLabelUltimaActualizacion As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents dgSimuladorBlanceo As DevExpress.XtraGrid.GridControl
    Friend WithEvents lblSemanaNave As Label
    Friend WithEvents dgVSimuladorBalanceo As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As Label
    Friend WithEvents lblParesTotales As Label
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PrioridadBaja As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents PrioridadMedia As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents PrioridadAlta As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblLunes As Label
    Friend WithEvents lblSabado As Label
    Friend WithEvents lblViernes As Label
    Friend WithEvents lblJueves As Label
    Friend WithEvents lblMiercoles As Label
    Friend WithEvents lblMartes As Label
    Friend WithEvents btnActualizar As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
