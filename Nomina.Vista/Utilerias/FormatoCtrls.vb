Public Class FormatoCtrls

    Public Shared Sub formato(ByRef ctrControl As Control)

        If Not (TryCast(ctrControl, System.Windows.Forms.Form) Is Nothing) Then
            DirectCast(ctrControl, System.Windows.Forms.Form).BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)
        End If

        For Each Ctrl In ctrControl.Controls
            'Debug.Print(Control.GetType.ToString)
            Select Case Ctrl.GetType.ToString
                Case "C1.Win.C1FlexGrid.C1FlexGrid"
                    DirectCast(Ctrl, C1.Win.C1FlexGrid.C1FlexGrid).BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.grid)
                Case "System.Windows.Forms.Button"
                Case "System.Windows.Forms.GroupBox"
                    formato(DirectCast(Ctrl, System.Windows.Forms.GroupBox))
                Case "System.Windows.Forms.Panel"
                    DirectCast(Ctrl, System.Windows.Forms.Panel).BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)
                    formato(DirectCast(Ctrl, System.Windows.Forms.Panel))
                Case "System.Windows.Forms.Label"
                    If DirectCast(Ctrl, System.Windows.Forms.Label).Name.ToUpper.Contains("TITULO") Then
                        DirectCast(Ctrl, System.Windows.Forms.Label).ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
                    Else
                        DirectCast(Ctrl, System.Windows.Forms.Label).ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
                    End If
            End Select
        Next
    End Sub

End Class
