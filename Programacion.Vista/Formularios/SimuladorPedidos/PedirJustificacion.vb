Imports Programacion.Negocios
Imports Tools

Public Class PedirJustificacion

    Dim justificacion As String
    Dim id As Integer
    Public Property pJustificacion As String
        Set(value As String)
            justificacion = value
        End Set
        Get
            Return justificacion
        End Get
    End Property

    Public Property pId As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property

    Public Function valida() As Boolean
        If txtNombreJustificacion.Text = "" Then
            Return False
        End If
        Return True
    End Function



    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If valida() = True Then
            Label1.ForeColor = Color.Black
            If guardarJustificacion() Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Else
            Me.DialogResult = Windows.Forms.DialogResult.None
            Dim vAdvertenciaForm As New AdvertenciaForm
            vAdvertenciaForm.Text = "Justificaciones"
            vAdvertenciaForm.mensaje = "Debe de capturar el nombre de la justificacion"
            vAdvertenciaForm.ShowDialog()
            txtNombreJustificacion.Focus()
            Label1.ForeColor = Color.Red

        End If

        'Me.Activate()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub PedirJustificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNombreJustificacion.Text = pJustificacion
    End Sub
    Public Function guardarJustificacion() As Boolean
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vConfirmarForm As New ConfirmarForm
        Dim vCatJus As New CatalogoJustificacionesBU
        Dim obj As New Entidades.ProgramacionCatalogoJustificaciones
        Dim bandera As Boolean
        If Not txtNombreJustificacion.Text = "" Then
            vConfirmarForm.Text = "Justificaciones"
            vConfirmarForm.mensaje = "¿ Desea guardar los cambios ?"
            Dim vDialogResult As New DialogResult
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                If pJustificacion = "" Then
                    vCatJus.Agregar(txtNombreJustificacion.Text)
                Else
                    obj.Id = pId
                    obj.Mensaje = txtNombreJustificacion.Text
                    vCatJus.Modificar(obj)
                End If
                Me.Close()
            Else
                bandera = False
                Me.DialogResult = Windows.Forms.DialogResult.None
            End If

        End If
        Return bandera
    End Function
End Class