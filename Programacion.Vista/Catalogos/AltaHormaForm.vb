Imports Tools

Public Class AltaHormaForm

    Public Sub generarCodigo()
        Dim objHormaBU As New Programacion.Negocios.HormasBU
        Dim dtIdMaximo As New DataTable
        dtIdMaximo = objHormaBU.idMaximohorma
        Dim cadenaIdMax As String = CStr(dtIdMaximo.Rows(0)(0).ToString)
        If (cadenaIdMax = Nothing) Then
            txtCodigo.Text = "1"
        Else
            txtCodigo.Text = CStr(CInt(cadenaIdMax) + 1)
        End If
    End Sub

    Public Sub guardarHorma()
        Dim objHormaBU As New Programacion.Negocios.HormasBU
        Dim entHorma As New Entidades.Hormas
        entHorma.PHorma = txtDescripcion.Text
        entHorma.PActivoHorma = CBool(rdoActivo.Checked)
        objHormaBU.guardarHorma(entHorma)
    End Sub

    Public Function ValidarExisteHorma() As Integer
        Dim objHormaBU As New Programacion.Negocios.HormasBU
        Dim tablaDatos As DataTable
        Dim validaInsert As Integer
        tablaDatos = objHormaBU.ValidarExisteHormaSAY(txtDescripcion.Text.Trim)

        For i As Integer = 0 To tablaDatos.Rows.Count - 1
            If tablaDatos.Rows(i).Item("Mensaje").ToString() <> "" Then
                validaInsert = Convert.ToInt32(tablaDatos.Rows(i).Item("Mensaje"))
            End If
        Next
        Return validaInsert
    End Function

    Public Function validaVacio() As Boolean
        If (txtDescripcion.Text = Nothing) Then
            lblDescripcion.ForeColor = Color.Red
            Return False
        Else
            lblDescripcion.ForeColor = Color.Black
        End If
        Return True
    End Function

    Private Sub AltaHormaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        generarCodigo()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (validaVacio() = True) Then
            If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                If ValidarExisteHorma() = 1 Then
                    guardarHorma()
                    Dim objExito As New ExitoForm
                    objExito.mensaje = "El registro se realizó con éxito."
                    objExito.ShowDialog()
                    Me.Close()
                Else
                    Dim Advertencia As New AdvertenciaForm
                    Advertencia.mensaje = "La Horma ya está registrada."
                    Advertencia.ShowDialog()
                    Me.Close()
                End If
            End If
        Else
            Dim objAdvertencia As New AdvertenciaForm
            objAdvertencia.mensaje = "Los campos marcados en rojo deben ser completados."
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 50) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = ("."))) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtDescripcion.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class