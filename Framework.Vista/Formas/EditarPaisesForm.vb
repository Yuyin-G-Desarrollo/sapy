Imports Framework.Negocios

Public Class EditarPaisesForm
    Public paisid As Integer
    Public Property DPais As Integer
        Get
            Return paisid
        End Get
        Set(ByVal value As Integer)
            paisid = value
        End Set
    End Property


    Private Sub EditarPaisesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objPaisBU As New PaisesBU
        Dim pais As New Entidades.Paises
        txtEditarNombrePais.MaxLength = 50
        pais = objPaisBU.buscarPais(paisid)

        txtEditarNombrePais.Text = pais.PNombre

        If (pais.PActivo) Then
            rdoActivoSi.Checked = True
        Else
            rdoActivoNo.Checked = True
        End If
    End Sub

    Private Sub btnGuardarEdicionPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarEdicionPais.Click
        Dim falla As Boolean = False
        If txtEditarNombrePais.Text <> "" Then

            lblEditarNombrePais.ForeColor = Color.Black
        Else


            lblEditarNombrePais.ForeColor = Color.Red
            falla = True

        End If


        If falla Then
            Dim FormaError As New ErroresForm
            FormaError.mensaje = "Error al modificar el nombre"
            FormaError.Show()
        Else
            'TOdo OK para editar
            Dim pais As New Entidades.Paises
            pais.PNombre = txtEditarNombrePais.Text
            pais.PActivo = rdoActivoSi.Checked
            pais.PIDPais = paisid

            Dim objPaisesBU As New PaisesBU
            objPaisesBU.EditarPais(pais)
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Registro Guardado"
            FormaExito.ShowDialog()
        End If
        Me.Close()
    End Sub

    Private Sub btnCancelarEdicionPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarEdicionPais.Click
        Me.Close()

    End Sub

  
    Private Sub txtEditarNombrePais_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEditarNombrePais.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            txtEditarNombrePais.SelectedText = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub txtEditarNombrePais_TextChanged(sender As Object, e As EventArgs) Handles txtEditarNombrePais.TextChanged

    End Sub
End Class