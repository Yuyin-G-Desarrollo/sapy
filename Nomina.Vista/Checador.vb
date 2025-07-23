Public Class Checador

    Dim lector As New Tools.FirmaBiometrica
    Dim bandera As Boolean = False
    Dim mensaje As String = ""

    Private Sub Checador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer2.Enabled = True
        Dim objBu As New Framework.Negocios.HuellaBU
        Dim lista As List(Of Entidades.ColaboradorFirmaBiometrica)
        lista = objBu.empleadosNaves()
        MessageBox.Show("Lista cargada, Comienze la lectura")
        lector.validarHuella(lista)
        lector.IniciarValidacion()
        Label1.Text = mensaje
    End Sub

    Private Function ObtenerDedoChecador(ByVal dedo As Int32)
        Dim leyenda As String = ""
        Select Case dedo
            Case 0
                leyenda = "Dedo Meñique Mano Izquierda"
            Case 1
                leyenda = "Dedo Anular Mano Izquierda"
            Case 2
                leyenda = "Dedo Medio Mano Izquierda"
            Case 3
                leyenda = "Dedo Indice Mano Izquierda"
            Case 4
                leyenda = "Dedo Pulgar Mano Izquierda"
            Case 5
                leyenda = "Dedo Pulgar Mano Derecha"
            Case 6
                leyenda = "Dedo Indice Mano Derecha"
            Case 7
                leyenda = "Dedo Medio Mano Derecha"
            Case 8
                leyenda = "Dedo Anular Mano Derecha"
            Case 9
                leyenda = "Dedo Meñique Mano Derecha"
            Case Else

        End Select
        Return leyenda
    End Function

    Private Sub setLabelTxt(ByVal text As String, ByVal lbl As Label)
        If lbl.InvokeRequired Then
            lbl.Invoke(New setLabelTxtInvoker(AddressOf setLabelTxt), text, lbl)
        Else
            lbl.Text = text
        End If
    End Sub

    Private Delegate Sub setLabelTxtInvoker(ByVal text As String, ByVal lbl As Label)


    Delegate Sub SetTextCallback([text] As String)

    Private Sub SetText(ByVal [text] As String)
        If Me.lblID.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.lblID.Text = [text]
        End If

    End Sub

    Private Sub validarHuella()
        If lector.banderaValidar = 1 Then
            lector.banderaValidar = 0
            Dim ObjBU As New Negocios.ColaboradoresBU
            Dim Datos As New Entidades.Colaborador
            Datos = ObjBU.BuscarColaboradorGeneral(CInt(lector.empleado.PcolaboradorId.ToString))
            Me.setLabelTxt(lector.empleado.PcolaboradorId.ToString, lblID)
            Me.setLabelTxt(ObtenerDedoChecador(lector.empleado.Pdedo), lblHuella)
            Me.setLabelTxt(Now, lblHora)
            Me.setLabelTxt(Datos.PNombre + " " + Datos.PApaterno + " " + Datos.PAmaterno, lblColaborador)
            'Me.SetText(lector.empleado.PcolaboradorId.ToString)
        ElseIf lector.banderaValidar = 2 Then
            lector.banderaValidar = 0
            mensaje = "No existe conincidencia o No esta registrado "
        End If
        timerLimpieza.Enabled = True
    End Sub

    Private Sub BackgroundWorker2_Disposed(sender As Object, e As EventArgs) Handles BackgroundWorker2.Disposed
        BackgroundWorker2.CancelAsync()
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        validarHuella()
        BackgroundWorker2.Dispose()

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If BackgroundWorker2.IsBusy Then
            BackgroundWorker2.CancelAsync()
        Else
            BackgroundWorker2.RunWorkerAsync()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        lector.TerminarValidacion()
    End Sub

    Private Sub timerLimpieza_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerLimpieza.Tick
        lblID.Text = "0"
        lblColaborador.Text = ""
        lblHuella.Text = ""
        lblHora.Text = ""
    End Sub

    Private Sub lblID_TextChanged(sender As Object, e As EventArgs) Handles lblID.TextChanged
        If CInt(lblID.Text) > 0 Then
            Dim ObjBU As New Negocios.ColaboradoresBU
            Dim Datos As New Entidades.Colaborador
            Datos = ObjBU.BuscarColaboradorGeneral(CInt(lblID.Text))
            lblColaborador.Text = Datos.PNombre + " " + Datos.PApaterno + " " + Datos.PAmaterno
            lblHuella.Text = ObtenerDedoChecador(lector.empleado.Pdedo)
            lblHora.Text = Now
            'mensaje = "Colaborador encontrado " & lector.empleado.PcolaboradorId & ", " &  + " " & ObtenerDedoChecador(lector.empleado.Pdedo)
        Else
            timerLimpieza.Enabled = False
        End If
    End Sub
End Class