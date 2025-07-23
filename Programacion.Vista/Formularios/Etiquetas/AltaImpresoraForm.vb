Imports System.Data.SqlClient
Imports Tools

Public Class AltaImpresoraForm
    Private _Accion As String
    Public Property Accion() As String
        Get
            Return _Accion
        End Get
        Set(ByVal value As String)
            _Accion = value
        End Set
    End Property

    Private _Entidad As Entidades.ImpresorasZebra
    Public Property Entidad() As Entidades.ImpresorasZebra
        Get
            Return _Entidad
        End Get
        Set(ByVal value As Entidades.ImpresorasZebra)
            _Entidad = value
        End Set
    End Property

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim msg_adv As New Tools.AdvertenciaForm

        If ValidarCampos() = True Then
            Dim objNeg As New Negocios.EtiquetasBU
            Dim msg As New Tools.ExitoForm
            Dim msg_error As New Tools.ErroresForm

            Dim EntidadImpresorasZebra As New Entidades.ImpresorasZebra
            EntidadImpresorasZebra.Nombre = txtNombre.Text.Trim
            'EntidadImpresorasZebra.Comando = txtComando.Text.Trim
            EntidadImpresorasZebra.Resolucion = cmbResolucion.Text

            If rdbNO.Checked Then
                EntidadImpresorasZebra.StImpresion = "0"
            ElseIf rdbSI.Checked Then
                EntidadImpresorasZebra.StImpresion = "1"
            End If

            'EntidadImpresorasZebra.StImpresion = IIf(chkActiva.Checked, 1, 0).ToString
            EntidadImpresorasZebra.Abreviatura = txtAbreviatura.Text.Trim
            EntidadImpresorasZebra.UsuarioCreoId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            Try
                If _Accion = "INSERTAR" Then
                    objNeg.ActualizarImpresorasZebra(1, EntidadImpresorasZebra)
                ElseIf _Accion = "ACTUALIZAR" Then
                    EntidadImpresorasZebra.idImpresora = Entidad.idImpresora
                    EntidadImpresorasZebra.UsuarioModificoId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    Dim objMensaje As New ConfirmarForm
                    objMensaje.mensaje = "¿Esta seguro de guardar cambios?"
                    If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                        objNeg.ActualizarImpresorasZebra(2, EntidadImpresorasZebra)
                    End If
                End If
                msg.mensaje = "La impresora se guardó correctamente"
                msg.ShowDialog()
                Me.Close()
            Catch ex As SqlClient.SqlException
                For Each err As SqlError In ex.Errors
                    If err.Number = 2601 Then
                        msg_adv.mensaje = "Ya existe una impresora con el mismo nombre o misma abreviatura"
                        msg_adv.ShowDialog()
                    End If
                Next
            End Try
        Else
            msg_adv.mensaje = "Los campos marcados en rojos deben ser completados."
            msg_adv.ShowDialog()
        End If

    End Sub

    Private Sub AltaImpresoraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtNombre.Select()

        If _Accion = "INSERTAR" Then
            cmbResolucion.SelectedIndex = 0

        ElseIf _Accion = "ACTUALIZAR" Then
            txtNombre.Text = _Entidad.Nombre
            'txtComando.Text = Entidad.Comando
            txtAbreviatura.Text = Entidad.Abreviatura
            cmbResolucion.Text = Entidad.Resolucion

            If _Entidad.StImpresion = "SI" Then
                rdbSI.Checked = True
            ElseIf _Entidad.StImpresion = "NO" Then
                rdbNO.Checked = True
            End If

            'chkActiva.Checked = validaActivo(Entidad.StImpresion)

        End If
    End Sub

    Private Function validaActivo(valida As String) As Integer
        If valida = "ACTIVO" Then
            Return 1
        ElseIf valida = "INACTIVO" Then
            Return 0
        End If
        Return 0
    End Function


    Private Function ValidarCampos()
        Dim valida As Boolean = True
        If txtNombre.Text = "" Then
            lblNombre.ForeColor = Color.Red
            valida = False
        Else
            lblNombre.ForeColor = Color.Black
        End If

        If cmbResolucion.Text = "" Then
            lblResolucion.ForeColor = Color.Red
            valida = False
        Else
            lblResolucion.ForeColor = Color.Black
        End If

        If txtAbreviatura.Text = "" Then
            lblAbreviatura.ForeColor = Color.Red
            valida = False
        Else
            lblAbreviatura.ForeColor = Color.Black
        End If

        Return valida

    End Function


End Class