<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CatalogoMotivosIncidenciaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CatalogoMotivosIncidenciaForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnEditarTipo = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnEditarCategoria = New System.Windows.Forms.Button()
        Me.lblListaCatalogoRamos = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.btnAltaTipo = New System.Windows.Forms.Button()
        Me.btnAltaCategoria = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.grbRamos = New System.Windows.Forms.GroupBox()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.btnNo = New System.Windows.Forms.RadioButton()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.gridCatalogoTiposIncidencia = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.grbRamos.SuspendLayout()
        CType(Me.gridCatalogoTiposIncidencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Controls.Add(Me.Label3)
        Me.pnlEncabezado.Controls.Add(Me.btnEditarTipo)
        Me.pnlEncabezado.Controls.Add(Me.Label2)
        Me.pnlEncabezado.Controls.Add(Me.btnEditarCategoria)
        Me.pnlEncabezado.Controls.Add(Me.lblListaCatalogoRamos)
        Me.pnlEncabezado.Controls.Add(Me.lblEditar)
        Me.pnlEncabezado.Controls.Add(Me.btnAltaTipo)
        Me.pnlEncabezado.Controls.Add(Me.btnAltaCategoria)
        Me.pnlEncabezado.Controls.Add(Me.lblAltas)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(584, 75)
        Me.pnlEncabezado.TabIndex = 68
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(173, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 26)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Editar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tipo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnEditarTipo
        '
        Me.btnEditarTipo.Image = CType(resources.GetObject("btnEditarTipo.Image"), System.Drawing.Image)
        Me.btnEditarTipo.Location = New System.Drawing.Point(173, 7)
        Me.btnEditarTipo.Name = "btnEditarTipo"
        Me.btnEditarTipo.Size = New System.Drawing.Size(32, 32)
        Me.btnEditarTipo.TabIndex = 48
        Me.btnEditarTipo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(112, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 26)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Editar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Categoría"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnEditarCategoria
        '
        Me.btnEditarCategoria.Image = CType(resources.GetObject("btnEditarCategoria.Image"), System.Drawing.Image)
        Me.btnEditarCategoria.Location = New System.Drawing.Point(121, 7)
        Me.btnEditarCategoria.Name = "btnEditarCategoria"
        Me.btnEditarCategoria.Size = New System.Drawing.Size(32, 32)
        Me.btnEditarCategoria.TabIndex = 46
        Me.btnEditarCategoria.UseVisualStyleBackColor = True
        '
        'lblListaCatalogoRamos
        '
        Me.lblListaCatalogoRamos.AutoSize = True
        Me.lblListaCatalogoRamos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaCatalogoRamos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaCatalogoRamos.Location = New System.Drawing.Point(257, 19)
        Me.lblListaCatalogoRamos.Name = "lblListaCatalogoRamos"
        Me.lblListaCatalogoRamos.Size = New System.Drawing.Size(241, 20)
        Me.lblListaCatalogoRamos.TabIndex = 21
        Me.lblListaCatalogoRamos.Text = "Catálogo Tipos de Incidencia"
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(72, 43)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(28, 26)
        Me.lblEditar.TabIndex = 19
        Me.lblEditar.Text = "Alta " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tipo"
        Me.lblEditar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAltaTipo
        '
        Me.btnAltaTipo.Image = Global.Ventas.Vista.My.Resources.Resources.altas_32
        Me.btnAltaTipo.Location = New System.Drawing.Point(69, 7)
        Me.btnAltaTipo.Name = "btnAltaTipo"
        Me.btnAltaTipo.Size = New System.Drawing.Size(32, 32)
        Me.btnAltaTipo.TabIndex = 11
        Me.btnAltaTipo.UseVisualStyleBackColor = True
        '
        'btnAltaCategoria
        '
        Me.btnAltaCategoria.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAltaCategoria.Image = CType(resources.GetObject("btnAltaCategoria.Image"), System.Drawing.Image)
        Me.btnAltaCategoria.Location = New System.Drawing.Point(17, 7)
        Me.btnAltaCategoria.Name = "btnAltaCategoria"
        Me.btnAltaCategoria.Size = New System.Drawing.Size(32, 32)
        Me.btnAltaCategoria.TabIndex = 10
        Me.btnAltaCategoria.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(10, 43)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(54, 26)
        Me.lblAltas.TabIndex = 16
        Me.lblAltas.Text = "Alta " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Categoría"
        Me.lblAltas.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grbRamos
        '
        Me.grbRamos.BackColor = System.Drawing.Color.AliceBlue
        Me.grbRamos.Controls.Add(Me.rdoSi)
        Me.grbRamos.Controls.Add(Me.btnNo)
        Me.grbRamos.Controls.Add(Me.btnAbajo)
        Me.grbRamos.Controls.Add(Me.btnArriba)
        Me.grbRamos.Controls.Add(Me.lblBúscar)
        Me.grbRamos.Controls.Add(Me.lblLimpiar)
        Me.grbRamos.Controls.Add(Me.btnCerrar)
        Me.grbRamos.Controls.Add(Me.btnBuscar)
        Me.grbRamos.Controls.Add(Me.lblActivo)
        Me.grbRamos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbRamos.ForeColor = System.Drawing.Color.AliceBlue
        Me.grbRamos.Location = New System.Drawing.Point(0, 75)
        Me.grbRamos.Name = "grbRamos"
        Me.grbRamos.Size = New System.Drawing.Size(584, 93)
        Me.grbRamos.TabIndex = 69
        Me.grbRamos.TabStop = False
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Checked = True
        Me.rdoSi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdoSi.Location = New System.Drawing.Point(59, 67)
        Me.rdoSi.Name = "rdoSi"
        Me.rdoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoSi.TabIndex = 3
        Me.rdoSi.TabStop = True
        Me.rdoSi.Text = "Si"
        Me.rdoSi.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.AutoSize = True
        Me.btnNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnNo.Location = New System.Drawing.Point(105, 67)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(39, 17)
        Me.btnNo.TabIndex = 4
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(541, 8)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 8
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(517, 8)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 7
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'lblBúscar
        '
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(451, 71)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBúscar.TabIndex = 26
        Me.lblBúscar.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(501, 71)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(35, 13)
        Me.lblLimpiar.TabIndex = 25
        Me.lblLimpiar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(502, 37)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(453, 37)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblActivo.Location = New System.Drawing.Point(12, 69)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 5
        Me.lblActivo.Text = "Activo"
        '
        'gridCatalogoTiposIncidencia
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridCatalogoTiposIncidencia.DisplayLayout.Appearance = Appearance1
        Me.gridCatalogoTiposIncidencia.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridCatalogoTiposIncidencia.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridCatalogoTiposIncidencia.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridCatalogoTiposIncidencia.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridCatalogoTiposIncidencia.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridCatalogoTiposIncidencia.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridCatalogoTiposIncidencia.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridCatalogoTiposIncidencia.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridCatalogoTiposIncidencia.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridCatalogoTiposIncidencia.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridCatalogoTiposIncidencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridCatalogoTiposIncidencia.Location = New System.Drawing.Point(0, 168)
        Me.gridCatalogoTiposIncidencia.Name = "gridCatalogoTiposIncidencia"
        Me.gridCatalogoTiposIncidencia.Size = New System.Drawing.Size(584, 293)
        Me.gridCatalogoTiposIncidencia.TabIndex = 70
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(516, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 75)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 50
        Me.PictureBox1.TabStop = False
        '
        'CatalogoMotivosIncidenciaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 461)
        Me.Controls.Add(Me.gridCatalogoTiposIncidencia)
        Me.Controls.Add(Me.grbRamos)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(600, 500)
        Me.MinimizeBox = False
        Me.Name = "CatalogoMotivosIncidenciaForm"
        Me.Text = "Catálogo Tipos de Incidencia"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.grbRamos.ResumeLayout(False)
        Me.grbRamos.PerformLayout()
        CType(Me.gridCatalogoTiposIncidencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblListaCatalogoRamos As System.Windows.Forms.Label
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents btnAltaTipo As System.Windows.Forms.Button
    Friend WithEvents btnAltaCategoria As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents grbRamos As System.Windows.Forms.GroupBox
    Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
    Friend WithEvents btnNo As System.Windows.Forms.RadioButton
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents lblBúscar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnEditarTipo As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnEditarCategoria As System.Windows.Forms.Button
    Friend WithEvents gridCatalogoTiposIncidencia As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents PictureBox1 As PictureBox
End Class
