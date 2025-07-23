Public Class FormatoCtrls


    Public Shared Sub formato(ByRef ctrControl As Control)

        'If Not (TryCast(ctrControl, System.Windows.Forms.Form) Is Nothing) Then
        '    DirectCast(ctrControl, System.Windows.Forms.Form).BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.ftpUser)
        'End If

        'For Each Ctrl In ctrControl.Controls
        '    'Debug.Print(Control.GetType.ToString)
        '    Select Case Ctrl.GetType.ToString
        '        Case "C1.Win.C1FlexGrid.C1FlexGrid"





        '        Case "System.Windows.Forms.Button"


        '        Case "System.Windows.Forms.GroupBox"
        '            If DirectCast(Ctrl, System.Windows.Forms.GroupBox).Name.ToUpper.Contains("GROUP") Then
        '                If My.Settings.ftpUser <> "" Then
        '                    DirectCast(Ctrl, System.Windows.Forms.GroupBox).BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.ftpUser)
        '                End If
        '            End If

        '            formato(DirectCast(Ctrl, System.Windows.Forms.GroupBox))

        '        Case "System.Windows.Forms.Panel"
        '            If DirectCast(Ctrl, System.Windows.Forms.Panel).Name.ToUpper.Contains("HEADER") Then
        '                If My.Settings.ftpURL <> "" Then
        '                    DirectCast(Ctrl, System.Windows.Forms.Panel).BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.ftpURL)
        '                End If
        '            End If

        '            If DirectCast(Ctrl, System.Windows.Forms.Panel).Name.ToUpper.Contains("PANEL") Then
        '                If My.Settings.ftpURL <> "" Then
        '                    DirectCast(Ctrl, System.Windows.Forms.Panel).BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.ftpUser)
        '                End If
        '            End If

        '            formato(DirectCast(Ctrl, System.Windows.Forms.Panel))


        '        Case "System.Windows.Forms.Label"
        '            If DirectCast(Ctrl, System.Windows.Forms.Label).Name.ToUpper.Contains("TITULO") Then


        '            End If

        '            If DirectCast(Ctrl, System.Windows.Forms.Label).Name.ToUpper.Contains("ACCION") Then
        '                If My.Settings.ftpPassword <> "" Then
        '                    DirectCast(Ctrl, System.Windows.Forms.Label).ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.ftpPassword)
        '                End If
        '            End If

        '    End Select
        'Next


    End Sub


End Class
