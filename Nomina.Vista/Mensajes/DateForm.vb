Imports Tools

Public Class DateForm
    Public mensaje As String
    Public Dia As String

    Private Sub DateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMensaje.Text = mensaje
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If lstFechas.Items.Count > 1 Then
            For index = 0 To lstFechas.Items.Count - 1
                If Dia = "" Then
                    Dia += lstFechas.Items.Item(index).ToString().ToUpper()
                Else
                    Dia += " Y " + lstFechas.Items.Item(index).ToString().ToUpper()
                End If
            Next
        Else
            Dia = dtpFecha.Value.ToLongDateString().ToUpper()
        End If
        Close()
    End Sub

    Private Sub BtnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If Not lstFechas.Items.Contains(dtpFecha.Value.ToLongDateString().ToUpper()) Then
            lstFechas.Items.Add(dtpFecha.Value.ToLongDateString())
        End If

        ReacomodarVista()
    End Sub

    Private Sub BtnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        EliminarFecha()
        ReacomodarVista()
    End Sub

    Private Sub LstFechas_KeyUp(sender As Object, e As KeyEventArgs) Handles lstFechas.KeyUp
        If e.KeyCode = Keys.Delete Then
            EliminarFecha()
            ReacomodarVista()
        End If
    End Sub

    Private Sub EliminarFecha()
        If lstFechas.SelectedIndex <> -1 Then
            lstFechas.Items.RemoveAt(lstFechas.SelectedIndex)
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Seleccione una fecha de la lista.")
        End If
    End Sub

    Private Sub ReacomodarVista()
        If lstFechas.Items.Count > 1 Then
            lblMensaje.Location = New Point(120, 29)
            dtpFecha.Location = New Point(120, 60)
            btnAgregar.Location = New Point(326, 54)
            btnAceptar.Location = New Point(151, 158)

            lstFechas.Visible = True
            btnBorrar.Visible = True
        Else
            lblMensaje.Location = New Point(120, 62)
            dtpFecha.Location = New Point(120, 93)
            btnAgregar.Location = New Point(326, 87)
            btnAceptar.Location = New Point(151, 122)

            lstFechas.Visible = False
            btnBorrar.Visible = False
            lblSeleccionado.Visible = False
        End If

        If lstFechas.Items.Count >= 1 Then
            btnAceptar.Visible = True
            lblSeleccionado.Visible = True

            lblSeleccionado.Text = "Fechas seleccionadas (" + lstFechas.Items.Count.ToString() + ")"
        Else
            btnAceptar.Visible = False
            lblSeleccionado.Visible = False
        End If
    End Sub

End Class