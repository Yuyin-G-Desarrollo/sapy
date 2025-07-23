<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AlertaParesSinProgramar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AlertaParesSinProgramar))
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.lblActualizar = New System.Windows.Forms.Label()
        Me.lblHoraEnvioAlerta = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grdParesTallaPedido = New DevExpress.XtraGrid.GridControl()
        Me.grdVParesTallaPedido = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdParesTallaPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVParesTallaPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.btnExportar)
        Me.pnlListaPaises.Controls.Add(Me.Label1)
        Me.pnlListaPaises.Controls.Add(Me.Panel1)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1268, 69)
        Me.pnlListaPaises.TabIndex = 27
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(24, 10)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 22
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(17, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Exportar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(707, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(561, 69)
        Me.Panel1.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(23, 22)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(459, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Alertas - Pares sin Programar en pedidos con Apartados"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.pnlBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 373)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1268, 60)
        Me.Panel2.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(278, 26)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Partidas en estatus PROGRAMADO y TERMINADO con " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "apartados y pares en producción " &
    "faltantes"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(3, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(448, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Solicite a TI la reactivación de las partidas para programar los pares faltantes"
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnActualizar)
        Me.pnlBotones.Controls.Add(Me.lblActualizar)
        Me.pnlBotones.Controls.Add(Me.lblHoraEnvioAlerta)
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.Label2)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(906, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(362, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'btnActualizar
        '
        Me.btnActualizar.Image = Global.Ventas.Vista.My.Resources.Resources.refresh_32
        Me.btnActualizar.Location = New System.Drawing.Point(258, 6)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(32, 32)
        Me.btnActualizar.TabIndex = 20
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'lblActualizar
        '
        Me.lblActualizar.AutoSize = True
        Me.lblActualizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizar.Location = New System.Drawing.Point(249, 39)
        Me.lblActualizar.Name = "lblActualizar"
        Me.lblActualizar.Size = New System.Drawing.Size(53, 13)
        Me.lblActualizar.TabIndex = 19
        Me.lblActualizar.Text = "Actualizar"
        '
        'lblHoraEnvioAlerta
        '
        Me.lblHoraEnvioAlerta.AutoSize = True
        Me.lblHoraEnvioAlerta.Location = New System.Drawing.Point(82, 25)
        Me.lblHoraEnvioAlerta.Name = "lblHoraEnvioAlerta"
        Me.lblHoraEnvioAlerta.Size = New System.Drawing.Size(28, 13)
        Me.lblHoraEnvioAlerta.TabIndex = 2
        Me.lblHoraEnvioAlerta.Text = "-------"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(309, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Alerta enviada:"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(308, 39)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox1.Controls.Add(Me.grdParesTallaPedido)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1268, 304)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        '
        'grdParesTallaPedido
        '
        Me.grdParesTallaPedido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdParesTallaPedido.Location = New System.Drawing.Point(3, 16)
        Me.grdParesTallaPedido.MainView = Me.grdVParesTallaPedido
        Me.grdParesTallaPedido.Name = "grdParesTallaPedido"
        Me.grdParesTallaPedido.Size = New System.Drawing.Size(1262, 285)
        Me.grdParesTallaPedido.TabIndex = 0
        Me.grdParesTallaPedido.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVParesTallaPedido})
        '
        'grdVParesTallaPedido
        '
        Me.grdVParesTallaPedido.GridControl = Me.grdParesTallaPedido
        Me.grdVParesTallaPedido.Name = "grdVParesTallaPedido"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(493, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 69)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AlertaParesSinProgramar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1268, 433)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AlertaParesSinProgramar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alertas - Pares sin Programar en pedidos con Apartados"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdParesTallaPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVParesTallaPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlListaPaises As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlBotones As Panel
    Friend WithEvents btnActualizar As Button
    Friend WithEvents lblActualizar As Label
    Friend WithEvents lblHoraEnvioAlerta As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents lblCancelar As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents grdParesTallaPedido As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVParesTallaPedido As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnExportar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
