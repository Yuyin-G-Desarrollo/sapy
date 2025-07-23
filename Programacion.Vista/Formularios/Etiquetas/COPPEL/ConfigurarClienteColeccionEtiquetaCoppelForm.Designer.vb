<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigurarClienteColeccionEtiquetaCoppelForm
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
        Me.vwEtiquetas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdEtiquetas = New DevExpress.XtraGrid.GridControl()
        Me.grdVConsultaDeLotes = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdConsultaDeLotes = New DevExpress.XtraGrid.GridControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.chkSeleccionar = New System.Windows.Forms.CheckBox()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblFechaUltimaActualizacion = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnEliminarColeccion = New System.Windows.Forms.Button()
        Me.lblConsultaInventarioNaves = New System.Windows.Forms.Label()
        Me.btnAsignar = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.vwEtiquetas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdEtiquetas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVConsultaDeLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdConsultaDeLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'vwEtiquetas
        '
        Me.vwEtiquetas.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.vwEtiquetas.Appearance.EvenRow.Options.UseBackColor = True
        Me.vwEtiquetas.Appearance.OddRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.vwEtiquetas.Appearance.OddRow.Options.UseBackColor = True
        Me.vwEtiquetas.GridControl = Me.grdEtiquetas
        Me.vwEtiquetas.Name = "vwEtiquetas"
        Me.vwEtiquetas.OptionsView.ShowAutoFilterRow = True
        '
        'grdEtiquetas
        '
        Me.grdEtiquetas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdEtiquetas.Location = New System.Drawing.Point(0, 0)
        Me.grdEtiquetas.MainView = Me.vwEtiquetas
        Me.grdEtiquetas.Name = "grdEtiquetas"
        Me.grdEtiquetas.Size = New System.Drawing.Size(849, 278)
        Me.grdEtiquetas.TabIndex = 50
        Me.grdEtiquetas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwEtiquetas})
        '
        'grdVConsultaDeLotes
        '
        Me.grdVConsultaDeLotes.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.grdVConsultaDeLotes.Appearance.EvenRow.Options.UseBackColor = True
        Me.grdVConsultaDeLotes.Appearance.OddRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.grdVConsultaDeLotes.Appearance.OddRow.Options.UseBackColor = True
        Me.grdVConsultaDeLotes.GridControl = Me.grdConsultaDeLotes
        Me.grdVConsultaDeLotes.Name = "grdVConsultaDeLotes"
        Me.grdVConsultaDeLotes.OptionsView.ShowAutoFilterRow = True
        '
        'grdConsultaDeLotes
        '
        Me.grdConsultaDeLotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdConsultaDeLotes.Location = New System.Drawing.Point(0, 0)
        Me.grdConsultaDeLotes.MainView = Me.grdVConsultaDeLotes
        Me.grdConsultaDeLotes.Name = "grdConsultaDeLotes"
        Me.grdConsultaDeLotes.Size = New System.Drawing.Size(849, 278)
        Me.grdConsultaDeLotes.TabIndex = 33
        Me.grdConsultaDeLotes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVConsultaDeLotes})
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdEtiquetas)
        Me.Panel1.Controls.Add(Me.grdConsultaDeLotes)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 135)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(849, 278)
        Me.Panel1.TabIndex = 73
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(62, 17)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(49, 13)
        Me.lblNave.TabIndex = 0
        Me.lblNave.Text = "Etiqueta:"
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFiltros.Controls.Add(Me.chkSeleccionar)
        Me.pnlFiltros.Controls.Add(Me.cmbNave)
        Me.pnlFiltros.Controls.Add(Me.Label2)
        Me.pnlFiltros.Controls.Add(Me.lblNave)
        Me.pnlFiltros.Controls.Add(Me.btnMostrar)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 67)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(849, 68)
        Me.pnlFiltros.TabIndex = 72
        '
        'chkSeleccionar
        '
        Me.chkSeleccionar.AutoSize = True
        Me.chkSeleccionar.Location = New System.Drawing.Point(3, 45)
        Me.chkSeleccionar.Name = "chkSeleccionar"
        Me.chkSeleccionar.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionar.TabIndex = 4
        Me.chkSeleccionar.Text = "Seleccionar Todo"
        Me.chkSeleccionar.UseVisualStyleBackColor = True
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(117, 14)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(397, 21)
        Me.cmbNave.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(786, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(789, 7)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 41
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(114, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 14
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(114, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblFechaUltimaActualizacion
        '
        Me.lblFechaUltimaActualizacion.AutoSize = True
        Me.lblFechaUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaActualizacion.ForeColor = System.Drawing.Color.Black
        Me.lblFechaUltimaActualizacion.Location = New System.Drawing.Point(339, 26)
        Me.lblFechaUltimaActualizacion.Name = "lblFechaUltimaActualizacion"
        Me.lblFechaUltimaActualizacion.Size = New System.Drawing.Size(0, 13)
        Me.lblFechaUltimaActualizacion.TabIndex = 123
        Me.lblFechaUltimaActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.lblFechaUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 413)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(849, 60)
        Me.pnlPie.TabIndex = 71
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(676, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(173, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(100, 15)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(431, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Configuración Etiquetas - Cliente Colección COPPEL"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(74, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 26)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Eliminar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Colecciones"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnEliminarColeccion
        '
        Me.btnEliminarColeccion.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnEliminarColeccion.Image = Global.Programacion.Vista.My.Resources.Resources.borrar_32
        Me.btnEliminarColeccion.Location = New System.Drawing.Point(89, 4)
        Me.btnEliminarColeccion.Name = "btnEliminarColeccion"
        Me.btnEliminarColeccion.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminarColeccion.TabIndex = 48
        Me.btnEliminarColeccion.UseVisualStyleBackColor = False
        '
        'lblConsultaInventarioNaves
        '
        Me.lblConsultaInventarioNaves.AutoSize = True
        Me.lblConsultaInventarioNaves.BackColor = System.Drawing.Color.Transparent
        Me.lblConsultaInventarioNaves.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblConsultaInventarioNaves.Location = New System.Drawing.Point(10, 37)
        Me.lblConsultaInventarioNaves.Name = "lblConsultaInventarioNaves"
        Me.lblConsultaInventarioNaves.Size = New System.Drawing.Size(65, 26)
        Me.lblConsultaInventarioNaves.TabIndex = 47
        Me.lblConsultaInventarioNaves.Text = "Asignar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Colecciones"
        Me.lblConsultaInventarioNaves.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAsignar
        '
        Me.btnAsignar.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAsignar.Image = Global.Programacion.Vista.My.Resources.Resources.autorizar_32
        Me.btnAsignar.Location = New System.Drawing.Point(25, 4)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(32, 32)
        Me.btnAsignar.TabIndex = 46
        Me.btnAsignar.UseVisualStyleBackColor = False
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(241, 0)
        Me.pnlHeader.MinimumSize = New System.Drawing.Size(400, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(608, 67)
        Me.pnlHeader.TabIndex = 6
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.Label3)
        Me.pnlListaPaises.Controls.Add(Me.btnEliminarColeccion)
        Me.pnlListaPaises.Controls.Add(Me.lblConsultaInventarioNaves)
        Me.pnlListaPaises.Controls.Add(Me.btnAsignar)
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(849, 67)
        Me.pnlListaPaises.TabIndex = 70
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(525, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(83, 67)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'ConfigurarClienteColeccionEtiquetaCoppelForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(849, 473)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.MinimumSize = New System.Drawing.Size(700, 500)
        Me.Name = "ConfigurarClienteColeccionEtiquetaCoppelForm"
        Me.Text = "ConfigurarClienteColeccionEtiquetaCoppelForm"
        CType(Me.vwEtiquetas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdEtiquetas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVConsultaDeLotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdConsultaDeLotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents vwEtiquetas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdEtiquetas As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVConsultaDeLotes As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdConsultaDeLotes As DevExpress.XtraGrid.GridControl
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblNave As Label
    Friend WithEvents pnlFiltros As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents lblFechaUltimaActualizacion As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnEliminarColeccion As Button
    Friend WithEvents lblConsultaInventarioNaves As Label
    Friend WithEvents btnAsignar As Button
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlListaPaises As Panel
    Friend WithEvents cmbNave As ComboBox
    Friend WithEvents chkSeleccionar As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
