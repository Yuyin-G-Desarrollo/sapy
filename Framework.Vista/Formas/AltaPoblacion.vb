Public Class AltaPoblacion
    Dim Edicion As Boolean = False
    Public Property PEdicion() As Boolean
        Get
            Return Edicion
        End Get
        Set(value As Boolean)
            Edicion = value
        End Set
    End Property

    Dim idPoblacion As Int32
    Public Property PidPoblacion() As Int32
        Get
            Return idPoblacion
        End Get
        Set(value As Int32)
            idPoblacion = value
        End Set
    End Property

    Dim Pais As Int32
    Public Property PPais() As Int32
        Get
            Return Pais
        End Get
        Set(value As Int32)
            Pais = value
        End Set
    End Property


    Dim Estado As Int32
    Public Property PEstado() As Int32
        Get
            Return Estado
        End Get
        Set(value As Int32)
            Estado = value
        End Set
    End Property

    Dim Ciudad As Int32
    Public Property PCiudad() As Int32
        Get
            Return Ciudad
        End Get
        Set(value As Int32)
            Ciudad = value
        End Set
    End Property



    Private Sub AltaPoblacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

            cmbPais = Tools.Controles.ComboPaisesMayusculas(cmbPais)
        cmbPais.SelectedValue = Estado
        cmbEstado.SelectedValue = Pais
        cmbCiudad.SelectedValue = Ciudad


    End Sub

    Private Sub cmbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPais.SelectedIndexChanged
        Try
            cmbEstado = Tools.Controles.ComboEstadosAnidado(cmbEstado, CInt(cmbPais.SelectedValue))
            cmbEstado.SelectedValue = Estado
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged
        Try
            cmbCiudad = Tools.Controles.ComboCiudadesMayusculas(cmbCiudad, CInt(cmbEstado.SelectedValue))
            cmbCiudad.SelectedValue = Ciudad
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim validacion As Boolean = True

        If cmbPais.SelectedIndex <= 0 Then
            lblPais.ForeColor = Color.Red
            validacion = False
        Else
            lblPais.ForeColor = Color.Black
        End If

        If cmbEstado.SelectedIndex <= 0 Then
            lblEstado.ForeColor = Color.Red
            validacion = False
        Else
            lblEstado.ForeColor = Color.Black
        End If

        If cmbCiudad.SelectedIndex <= 0 Then
            lblCiudad.ForeColor = Color.Red
            validacion = False
        Else
            lblCiudad.ForeColor = Color.Black
        End If

        If txtNombrePoblacion.Text.Length <= 0 Then
            lblNombrePoblacion.ForeColor = Color.Red
            validacion = False
        Else
            lblNombrePoblacion.ForeColor = Color.Black
        End If

        Dim ACTIVO As New Boolean
        If btnSi.Checked = True Then
            ACTIVO = True
        Else
            ACTIVO = False
        End If


        If validacion = True Then
            If idPoblacion > 0 Then
                Dim OBJBU As New Negocios.PoblacionBU
                Dim Entidad As New Entidades.Mensajeria
                Entidad.PNombrePoblacion = txtNombrePoblacion.Text
                Entidad.PNombreCiudad = CStr(CInt(cmbCiudad.SelectedValue))
                Entidad.PActivo = ACTIVO
                Entidad.PIDCostoMensajeria = idPoblacion
                OBJBU.EditarPoblaciones(Entidad)
            Else
                Dim OBJBU As New Negocios.PoblacionBU
                Dim Entidad As New Entidades.Mensajeria
                Entidad.PNombrePoblacion = txtNombrePoblacion.Text
                Entidad.PNombreCiudad = CStr(CInt(cmbCiudad.SelectedValue))
                Entidad.PActivo = ACTIVO
                OBJBU.AltaPoblaciones(Entidad)
            End If
            
            Dim Exito As New ExitoForm
            Exito.mensaje = "Guardado Correctamente"
            Exito.Show()
            Me.Close()
        End If




    End Sub

    Private Sub pbYuyin_Click(sender As Object, e As EventArgs) 
    End Sub

    Private Sub btnCncelar_Click(sender As Object, e As EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub AltaPoblacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If Char.IsLetter(e.KeyChar) Then

            e.KeyChar = Char.ToUpper(e.KeyChar)

        End If

    End Sub
End Class