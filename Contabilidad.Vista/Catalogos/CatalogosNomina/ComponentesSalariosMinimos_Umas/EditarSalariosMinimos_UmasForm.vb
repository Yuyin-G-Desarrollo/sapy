Imports System.Windows.Forms
Imports Tools

Public Class EditarSalariosMinimos_UmasForm
    Dim ObjBU As New Negocios.CatalogoSalariosMinimos_UmasBU
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        ModificarPrecios()
    End Sub

    Private Sub CatalogoSalariosMinimos_UmasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsultaPrecio_SalarioMIN_UMA()
    End Sub

    Public Sub ConsultaPrecio_SalarioMIN_UMA()
        Dim listaentidad = ObjBU.ConsultaPrecio_SalarioMIN_UMA()
        txtaño.Text = Date.Now.Year
        txtmontosalariominimo.Text = Replace(listaentidad(0).MontoSalarioMinimo, ",", ".")
        txtmontoUMA.Text = Replace(listaentidad(1).MontoSalarioMinimo, ",", ".")
        txtmontoUMI.Text = Replace(listaentidad(2).MontoSalarioMinimo, ",", ".")
    End Sub
    Public Sub ModificarPrecios()
        Try

            Dim salarioMinimo As String = txtmontosalariominimo.Text
            Dim salarioUMA As String = txtmontoUMA.Text
            Dim salarioUMI As String = txtmontoUMI.Text
            Dim anio As Integer = txtaño.Text

            If CDbl(salarioMinimo) <= 0 Or CDbl(salarioUMA) <= 0 Or CDbl(salarioUMI) <= 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Los precios deben ser mayores a 0")

            Else


                Dim Colaborador As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                Dim success = ObjBU.ModificarPrecio_SalarioMIN_UMA(salarioMinimo, salarioUMA, salarioUMI, Colaborador, Date.Now, anio)
                If success.Resp > 0 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, success.Mensage)
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, success.Mensage)
                End If
            End If
            Me.Close()
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Los precios contienen un caracter no valido")
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    'Private Sub txtmontosalariominimo_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs)
    '    If Not IsNumeric(e.KeyChar) _
    '                     AndAlso Not Char.IsControl(e.KeyChar) _
    '                      AndAlso Not Char.IsWhiteSpace(e.KeyChar) _
    '                      AndAlso Not Char.IsPunctuation(e.KeyChar) Then
    '        e.Handled = True
    '    End If
    '    e.Handled = numero(e, txtmontosalariominimo) 'txtTexto caja de texto a validar
    'End Sub

    'Private Sub txtmontoUMA_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs)
    '    If Not IsNumeric(e.KeyChar) _
    '                AndAlso Not Char.IsControl(e.KeyChar) _
    '                AndAlso Not Char.IsWhiteSpace(e.KeyChar) _
    '                 AndAlso Not Char.IsPunctuation(e.KeyChar) Then
    '        e.Handled = True
    '    End If
    '    e.Handled = numero(e, txtmontoUMA) 'txtTexto caja de texto a validar
    'End Sub


    Function numero(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByRef cajasTexto As TextBox) As Boolean
        If UCase(e.KeyChar) Like "[.]" Then
            If InStr(cajasTexto.Text, ".") > 0 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Sub txtmontosalariominimo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmontosalariominimo.KeyPress
        Dim arreglo(2) As String
        If Not IsNumeric(e.KeyChar) _
                    AndAlso Not Char.IsControl(e.KeyChar) _
                    AndAlso Not Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            If txtmontosalariominimo.Text.IndexOf(".") > 0 Then
                arreglo = Split(txtmontosalariominimo.Text, ".")

                If arreglo(1).Length >= 2 Then
                    e.Handled = True
                Else
                    e.Handled = False
                End If
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "." And txtmontosalariominimo.Text.IndexOf(".") > 0 Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtmontoUMA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmontoUMA.KeyPress
        Dim arreglo(2) As String
        If Not IsNumeric(e.KeyChar) _
                    AndAlso Not Char.IsControl(e.KeyChar) _
                    AndAlso Not Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            If txtmontoUMA.Text.IndexOf(".") > 0 Then
                arreglo = Split(txtmontoUMA.Text, ".")

                If arreglo(1).Length >= 2 Then
                    e.Handled = True
                Else
                    e.Handled = False
                End If
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "." And txtmontoUMA.Text.IndexOf(".") > 0 Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtmontoUMI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmontoUMI.KeyPress
        Dim arreglo(2) As String
        If Not IsNumeric(e.KeyChar) _
                    AndAlso Not Char.IsControl(e.KeyChar) _
                    AndAlso Not Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            If txtmontoUMI.Text.IndexOf(".") > 0 Then
                arreglo = Split(txtmontoUMI.Text, ".")

                If arreglo(1).Length >= 2 Then
                    e.Handled = True
                Else
                    e.Handled = False
                End If
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "." And txtmontoUMI.Text.IndexOf(".") > 0 Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class