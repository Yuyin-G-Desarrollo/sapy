<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetallesOcupacionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DetallesOcupacionForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.grbDetalles = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbldesverde = New System.Windows.Forms.Label()
        Me.pnlRojo = New System.Windows.Forms.Panel()
        Me.pnlNaranja = New System.Windows.Forms.Panel()
        Me.pnlAzul = New System.Windows.Forms.Panel()
        Me.pnlVerde = New System.Windows.Forms.Panel()
        Me.lblParesTotal = New System.Windows.Forms.Label()
        Me.lblParesRojo = New System.Windows.Forms.Label()
        Me.lblParesNaranja = New System.Windows.Forms.Label()
        Me.lblParesAzul = New System.Windows.Forms.Label()
        Me.lblParesVerde = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblBahiasTotal = New System.Windows.Forms.Label()
        Me.lblBahiasRojo = New System.Windows.Forms.Label()
        Me.lblBahiasNaranja = New System.Windows.Forms.Label()
        Me.lblBahiasAzul = New System.Windows.Forms.Label()
        Me.lblBahiasVerde = New System.Windows.Forms.Label()
        Me.lblPares = New System.Windows.Forms.Label()
        Me.lblBahias = New System.Windows.Forms.Label()
        Me.lblpordisponibilidad = New System.Windows.Forms.Label()
        Me.lblOcupacion = New System.Windows.Forms.Label()
        Me.lblDisponibilidad = New System.Windows.Forms.Label()
        Me.lblTotalCapacidad = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.pnlOcupacion = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbDetalles.SuspendLayout()
        Me.pnlOcupacion.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(609, 59)
        Me.pnlEncabezado.TabIndex = 1
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(207, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(402, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(42, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(299, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Resumen de Ocupación de Almacén"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(334, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'grbDetalles
        '
        Me.grbDetalles.Controls.Add(Me.Label1)
        Me.grbDetalles.Controls.Add(Me.Label12)
        Me.grbDetalles.Controls.Add(Me.Label13)
        Me.grbDetalles.Controls.Add(Me.Label14)
        Me.grbDetalles.Controls.Add(Me.lbldesverde)
        Me.grbDetalles.Controls.Add(Me.pnlRojo)
        Me.grbDetalles.Controls.Add(Me.pnlNaranja)
        Me.grbDetalles.Controls.Add(Me.pnlAzul)
        Me.grbDetalles.Controls.Add(Me.pnlVerde)
        Me.grbDetalles.Controls.Add(Me.lblParesTotal)
        Me.grbDetalles.Controls.Add(Me.lblParesRojo)
        Me.grbDetalles.Controls.Add(Me.lblParesNaranja)
        Me.grbDetalles.Controls.Add(Me.lblParesAzul)
        Me.grbDetalles.Controls.Add(Me.lblParesVerde)
        Me.grbDetalles.Controls.Add(Me.lblTotal)
        Me.grbDetalles.Controls.Add(Me.lblBahiasTotal)
        Me.grbDetalles.Controls.Add(Me.lblBahiasRojo)
        Me.grbDetalles.Controls.Add(Me.lblBahiasNaranja)
        Me.grbDetalles.Controls.Add(Me.lblBahiasAzul)
        Me.grbDetalles.Controls.Add(Me.lblBahiasVerde)
        Me.grbDetalles.Controls.Add(Me.lblPares)
        Me.grbDetalles.Controls.Add(Me.lblBahias)
        Me.grbDetalles.Location = New System.Drawing.Point(8, 61)
        Me.grbDetalles.Name = "grbDetalles"
        Me.grbDetalles.Size = New System.Drawing.Size(353, 200)
        Me.grbDetalles.TabIndex = 2
        Me.grbDetalles.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(267, 150)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "> 100.0% "
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Orange
        Me.Label13.Location = New System.Drawing.Point(267, 120)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "80 % - 100%"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(267, 90)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 13)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "50 % - 79.9%"
        '
        'lbldesverde
        '
        Me.lbldesverde.AutoSize = True
        Me.lbldesverde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldesverde.ForeColor = System.Drawing.Color.Green
        Me.lbldesverde.Location = New System.Drawing.Point(267, 60)
        Me.lbldesverde.Name = "lbldesverde"
        Me.lbldesverde.Size = New System.Drawing.Size(73, 13)
        Me.lbldesverde.TabIndex = 17
        Me.lbldesverde.Text = "0 % - 49.9%"
        '
        'pnlRojo
        '
        Me.pnlRojo.BackColor = System.Drawing.Color.Red
        Me.pnlRojo.Location = New System.Drawing.Point(206, 146)
        Me.pnlRojo.Name = "pnlRojo"
        Me.pnlRojo.Size = New System.Drawing.Size(59, 24)
        Me.pnlRojo.TabIndex = 16
        '
        'pnlNaranja
        '
        Me.pnlNaranja.BackColor = System.Drawing.Color.Orange
        Me.pnlNaranja.Location = New System.Drawing.Point(206, 116)
        Me.pnlNaranja.Name = "pnlNaranja"
        Me.pnlNaranja.Size = New System.Drawing.Size(59, 24)
        Me.pnlNaranja.TabIndex = 15
        '
        'pnlAzul
        '
        Me.pnlAzul.BackColor = System.Drawing.Color.Blue
        Me.pnlAzul.Location = New System.Drawing.Point(206, 86)
        Me.pnlAzul.Name = "pnlAzul"
        Me.pnlAzul.Size = New System.Drawing.Size(59, 24)
        Me.pnlAzul.TabIndex = 14
        '
        'pnlVerde
        '
        Me.pnlVerde.BackColor = System.Drawing.Color.Green
        Me.pnlVerde.Location = New System.Drawing.Point(206, 56)
        Me.pnlVerde.Name = "pnlVerde"
        Me.pnlVerde.Size = New System.Drawing.Size(59, 24)
        Me.pnlVerde.TabIndex = 13
        '
        'lblParesTotal
        '
        Me.lblParesTotal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesTotal.Location = New System.Drawing.Point(140, 174)
        Me.lblParesTotal.Name = "lblParesTotal"
        Me.lblParesTotal.Size = New System.Drawing.Size(52, 13)
        Me.lblParesTotal.TabIndex = 12
        Me.lblParesTotal.Text = "Pares"
        Me.lblParesTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblParesRojo
        '
        Me.lblParesRojo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesRojo.Location = New System.Drawing.Point(145, 150)
        Me.lblParesRojo.Name = "lblParesRojo"
        Me.lblParesRojo.Size = New System.Drawing.Size(47, 13)
        Me.lblParesRojo.TabIndex = 11
        Me.lblParesRojo.Text = "Pares"
        Me.lblParesRojo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblParesNaranja
        '
        Me.lblParesNaranja.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesNaranja.Location = New System.Drawing.Point(145, 120)
        Me.lblParesNaranja.Name = "lblParesNaranja"
        Me.lblParesNaranja.Size = New System.Drawing.Size(47, 13)
        Me.lblParesNaranja.TabIndex = 10
        Me.lblParesNaranja.Text = "Pares"
        Me.lblParesNaranja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblParesAzul
        '
        Me.lblParesAzul.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesAzul.Location = New System.Drawing.Point(145, 90)
        Me.lblParesAzul.Name = "lblParesAzul"
        Me.lblParesAzul.Size = New System.Drawing.Size(47, 13)
        Me.lblParesAzul.TabIndex = 9
        Me.lblParesAzul.Text = "Pares"
        Me.lblParesAzul.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblParesVerde
        '
        Me.lblParesVerde.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesVerde.Location = New System.Drawing.Point(145, 60)
        Me.lblParesVerde.Name = "lblParesVerde"
        Me.lblParesVerde.Size = New System.Drawing.Size(47, 13)
        Me.lblParesVerde.TabIndex = 8
        Me.lblParesVerde.Text = "Pares"
        Me.lblParesVerde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(6, 174)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(44, 16)
        Me.lblTotal.TabIndex = 7
        Me.lblTotal.Text = "Total"
        '
        'lblBahiasTotal
        '
        Me.lblBahiasTotal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBahiasTotal.Location = New System.Drawing.Point(57, 174)
        Me.lblBahiasTotal.Name = "lblBahiasTotal"
        Me.lblBahiasTotal.Size = New System.Drawing.Size(58, 13)
        Me.lblBahiasTotal.TabIndex = 6
        Me.lblBahiasTotal.Text = "Bahias"
        Me.lblBahiasTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBahiasRojo
        '
        Me.lblBahiasRojo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBahiasRojo.Location = New System.Drawing.Point(63, 150)
        Me.lblBahiasRojo.Name = "lblBahiasRojo"
        Me.lblBahiasRojo.Size = New System.Drawing.Size(52, 13)
        Me.lblBahiasRojo.TabIndex = 5
        Me.lblBahiasRojo.Text = "Bahias"
        Me.lblBahiasRojo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBahiasNaranja
        '
        Me.lblBahiasNaranja.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBahiasNaranja.Location = New System.Drawing.Point(63, 120)
        Me.lblBahiasNaranja.Name = "lblBahiasNaranja"
        Me.lblBahiasNaranja.Size = New System.Drawing.Size(52, 13)
        Me.lblBahiasNaranja.TabIndex = 4
        Me.lblBahiasNaranja.Text = "Bahias"
        Me.lblBahiasNaranja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBahiasAzul
        '
        Me.lblBahiasAzul.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBahiasAzul.Location = New System.Drawing.Point(63, 90)
        Me.lblBahiasAzul.Name = "lblBahiasAzul"
        Me.lblBahiasAzul.Size = New System.Drawing.Size(52, 13)
        Me.lblBahiasAzul.TabIndex = 3
        Me.lblBahiasAzul.Text = "Bahias"
        Me.lblBahiasAzul.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBahiasVerde
        '
        Me.lblBahiasVerde.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBahiasVerde.Location = New System.Drawing.Point(63, 60)
        Me.lblBahiasVerde.Name = "lblBahiasVerde"
        Me.lblBahiasVerde.Size = New System.Drawing.Size(52, 13)
        Me.lblBahiasVerde.TabIndex = 2
        Me.lblBahiasVerde.Text = "Bahias"
        Me.lblBahiasVerde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPares
        '
        Me.lblPares.AutoSize = True
        Me.lblPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPares.Location = New System.Drawing.Point(140, 18)
        Me.lblPares.Name = "lblPares"
        Me.lblPares.Size = New System.Drawing.Size(102, 32)
        Me.lblPares.TabIndex = 1
        Me.lblPares.Text = "Ocupación     " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    Pares"
        '
        'lblBahias
        '
        Me.lblBahias.AutoSize = True
        Me.lblBahias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBahias.Location = New System.Drawing.Point(65, 17)
        Me.lblBahias.Name = "lblBahias"
        Me.lblBahias.Size = New System.Drawing.Size(60, 32)
        Me.lblBahias.TabIndex = 0
        Me.lblBahias.Text = "Bahías " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Activas"
        '
        'lblpordisponibilidad
        '
        Me.lblpordisponibilidad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpordisponibilidad.Location = New System.Drawing.Point(165, 150)
        Me.lblpordisponibilidad.Name = "lblpordisponibilidad"
        Me.lblpordisponibilidad.Size = New System.Drawing.Size(62, 13)
        Me.lblpordisponibilidad.TabIndex = 28
        Me.lblpordisponibilidad.Text = "Pares"
        Me.lblpordisponibilidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOcupacion
        '
        Me.lblOcupacion.AutoSize = True
        Me.lblOcupacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOcupacion.Location = New System.Drawing.Point(20, 4)
        Me.lblOcupacion.Name = "lblOcupacion"
        Me.lblOcupacion.Size = New System.Drawing.Size(39, 13)
        Me.lblOcupacion.TabIndex = 27
        Me.lblOcupacion.Text = "Pares"
        '
        'lblDisponibilidad
        '
        Me.lblDisponibilidad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisponibilidad.Location = New System.Drawing.Point(165, 90)
        Me.lblDisponibilidad.Name = "lblDisponibilidad"
        Me.lblDisponibilidad.Size = New System.Drawing.Size(60, 13)
        Me.lblDisponibilidad.TabIndex = 26
        Me.lblDisponibilidad.Text = "Pares"
        Me.lblDisponibilidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalCapacidad
        '
        Me.lblTotalCapacidad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCapacidad.Location = New System.Drawing.Point(165, 60)
        Me.lblTotalCapacidad.Name = "lblTotalCapacidad"
        Me.lblTotalCapacidad.Size = New System.Drawing.Size(60, 13)
        Me.lblTotalCapacidad.TabIndex = 25
        Me.lblTotalCapacidad.Text = "Pares"
        Me.lblTotalCapacidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(22, 151)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(126, 16)
        Me.Label19.TabIndex = 24
        Me.Label19.Text = "% Disponibilidad"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(22, 120)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(99, 16)
        Me.Label20.TabIndex = 23
        Me.Label20.Text = "% Ocupación"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(22, 87)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(109, 16)
        Me.Label21.TabIndex = 22
        Me.Label21.Text = "Disponibilidad"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(22, 48)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(124, 32)
        Me.Label22.TabIndex = 21
        Me.Label22.Text = "Capacidad Total" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " del Almacén" & Global.Microsoft.VisualBasic.ChrW(9) & " " & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'pnlOcupacion
        '
        Me.pnlOcupacion.Controls.Add(Me.lblOcupacion)
        Me.pnlOcupacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlOcupacion.Location = New System.Drawing.Point(163, 115)
        Me.pnlOcupacion.Name = "pnlOcupacion"
        Me.pnlOcupacion.Size = New System.Drawing.Size(67, 24)
        Me.pnlOcupacion.TabIndex = 16
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.pnlOcupacion)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.lblpordisponibilidad)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.lblDisponibilidad)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.lblTotalCapacidad)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Location = New System.Drawing.Point(367, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(238, 200)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(257, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Escala"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(67, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 16)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "R E S U M E N"
        '
        'DetallesOcupacionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(609, 267)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grbDetalles)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(625, 306)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(625, 306)
        Me.Name = "DetallesOcupacionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalles de Ocupacion de Almacen"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbDetalles.ResumeLayout(False)
        Me.grbDetalles.PerformLayout()
        Me.pnlOcupacion.ResumeLayout(False)
        Me.pnlOcupacion.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents grbDetalles As System.Windows.Forms.GroupBox
    Friend WithEvents pnlOcupacion As System.Windows.Forms.Panel
    Friend WithEvents lblOcupacion As System.Windows.Forms.Label
    Friend WithEvents lblpordisponibilidad As System.Windows.Forms.Label
    Friend WithEvents lblDisponibilidad As System.Windows.Forms.Label
    Friend WithEvents lblTotalCapacidad As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbldesverde As System.Windows.Forms.Label
    Friend WithEvents pnlRojo As System.Windows.Forms.Panel
    Friend WithEvents pnlNaranja As System.Windows.Forms.Panel
    Friend WithEvents pnlAzul As System.Windows.Forms.Panel
    Friend WithEvents pnlVerde As System.Windows.Forms.Panel
    Friend WithEvents lblParesTotal As System.Windows.Forms.Label
    Friend WithEvents lblParesRojo As System.Windows.Forms.Label
    Friend WithEvents lblParesNaranja As System.Windows.Forms.Label
    Friend WithEvents lblParesAzul As System.Windows.Forms.Label
    Friend WithEvents lblParesVerde As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblBahiasTotal As System.Windows.Forms.Label
    Friend WithEvents lblBahiasRojo As System.Windows.Forms.Label
    Friend WithEvents lblBahiasNaranja As System.Windows.Forms.Label
    Friend WithEvents lblBahiasAzul As System.Windows.Forms.Label
    Friend WithEvents lblBahiasVerde As System.Windows.Forms.Label
    Friend WithEvents lblPares As System.Windows.Forms.Label
    Friend WithEvents lblBahias As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
