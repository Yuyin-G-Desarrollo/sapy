<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Nomina_TablaCalculoPrestacionesSAY
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grdTablaAmortizacion = New System.Windows.Forms.DataGridView()
        Me.clmNumeroDePago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAbonoACapital = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmNuevoSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grdTablaAmortizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdTablaAmortizacion
        '
        Me.grdTablaAmortizacion.AllowUserToAddRows = False
        Me.grdTablaAmortizacion.AllowUserToDeleteRows = False
        Me.grdTablaAmortizacion.AllowUserToResizeColumns = False
        Me.grdTablaAmortizacion.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTablaAmortizacion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.grdTablaAmortizacion.BackgroundColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdTablaAmortizacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.grdTablaAmortizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTablaAmortizacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmNumeroDePago, Me.clmAbonoACapital, Me.clmTotal, Me.clmNuevoSaldo})
        Me.grdTablaAmortizacion.Location = New System.Drawing.Point(0, -1)
        Me.grdTablaAmortizacion.Name = "grdTablaAmortizacion"
        Me.grdTablaAmortizacion.Size = New System.Drawing.Size(408, 391)
        Me.grdTablaAmortizacion.TabIndex = 5
        '
        'clmNumeroDePago
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.clmNumeroDePago.DefaultCellStyle = DataGridViewCellStyle9
        Me.clmNumeroDePago.HeaderText = "#"
        Me.clmNumeroDePago.Name = "clmNumeroDePago"
        Me.clmNumeroDePago.ReadOnly = True
        Me.clmNumeroDePago.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.clmNumeroDePago.Width = 40
        '
        'clmAbonoACapital
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N0"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.clmAbonoACapital.DefaultCellStyle = DataGridViewCellStyle10
        Me.clmAbonoACapital.HeaderText = "Abono a Capital"
        Me.clmAbonoACapital.Name = "clmAbonoACapital"
        Me.clmAbonoACapital.ReadOnly = True
        Me.clmAbonoACapital.Width = 95
        '
        'clmTotal
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N0"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.clmTotal.DefaultCellStyle = DataGridViewCellStyle11
        Me.clmTotal.HeaderText = "Total"
        Me.clmTotal.Name = "clmTotal"
        Me.clmTotal.ReadOnly = True
        Me.clmTotal.Width = 60
        '
        'clmNuevoSaldo
        '
        Me.clmNuevoSaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N0"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.clmNuevoSaldo.DefaultCellStyle = DataGridViewCellStyle12
        Me.clmNuevoSaldo.FillWeight = 115.0!
        Me.clmNuevoSaldo.HeaderText = "Nuevo Saldo"
        Me.clmNuevoSaldo.Name = "clmNuevoSaldo"
        Me.clmNuevoSaldo.ReadOnly = True
        '
        'Nomina_TablaCalculoPrestacionesSAY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 390)
        Me.Controls.Add(Me.grdTablaAmortizacion)
        Me.MaximumSize = New System.Drawing.Size(426, 429)
        Me.MinimumSize = New System.Drawing.Size(426, 429)
        Me.Name = "Nomina_TablaCalculoPrestacionesSAY"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cálculo Prestación"
        CType(Me.grdTablaAmortizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grdTablaAmortizacion As DataGridView
    Friend WithEvents clmNumeroDePago As DataGridViewTextBoxColumn
    Friend WithEvents clmAbonoACapital As DataGridViewTextBoxColumn
    Friend WithEvents clmTotal As DataGridViewTextBoxColumn
    Friend WithEvents clmNuevoSaldo As DataGridViewTextBoxColumn
End Class
