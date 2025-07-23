Public Class Combinaciones
    ''' <summary>
    ''' 01-ZZ
    ''' By charly
    ''' </summary>
    ''' <param name="A"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getNextNumeroAlfaNumerico(ByVal A As String) As String
        Dim cadena As String = ""
        Dim numero As Integer = 0
        Dim numero2 As Integer = 0
        Try
            If A = "9Z" Then
                Return "A0"
            End If
            Dim l1 As String
            Dim l2 As String
            l1 = A.Substring(0, 1)
            l2 = A.Substring(1, 1)
            numero = Convert.ToInt32(l1)
            Try
                'Solo Números
                numero2 = Convert.ToInt32(l2)
                numero2 += 1
                If numero2 > 9 Then
                    Dim cad As String = ""
                    cad = numero.ToString + "" + "A"
                    Return cad
                Else
                    Dim cad As String = ""
                    cad = numero.ToString + "" + numero2.ToString
                    Return cad
                End If
            Catch ex As Exception
                'Número y letra el segundo caracter es letra
                If l2 <> "Z" Then
                    If numero > 9 Then
                        Return "A0"
                    Else
                        For i = 65 To 90
                            If l2 = Chr(i) Then
                                l2 = Chr(i + 1)
                                i = 100
                            End If
                        Next i
                        A = numero.ToString + "" & l2
                        Return A
                    End If
                Else
                    numero += 1
                    If numero > 9 Then
                        Return "A0"
                    Else
                        A = numero.ToString + "0"
                        Return A
                    End If
                End If
            End Try
        Catch ex As Exception
            Dim l1 As String
            Dim l2 As String
            l1 = A.Substring(0, 1)
            l2 = A.Substring(1, 1)
            Try
                If Convert.ToInt32(l2) + 1 > 9 Then
                    If Convert.ToInt32(l2) + 1 = 10 Then ' \(@_@)/
                        A = l1 & "A"
                        Return A
                    Else
                        For i = 65 To 90
                            If l2 = Chr(i) Then
                                l2 = Chr(i + 1)
                                i = 100
                            End If
                        Next i
                        A = l1 & l2
                        Return A
                    End If
                Else
                    A = l1 & "" & Convert.ToInt32(l2) + 1
                    Return A
                End If

            Catch ex2 As Exception
                If l2 = "Z" Then
                    For i = 65 To 90
                        If l1 = Chr(i) Then
                            l1 = Chr(i + 1)
                            i = 100
                        End If
                    Next i
                    A = l1 & "0"
                    Return A
                Else
                    For i = 65 To 90
                        If l2 = Chr(i) Then
                            l2 = Chr(i + 1)
                            i = 100
                        End If
                    Next i
                    A = l1 & l2
                    Return A
                End If

            End Try
        End Try
        Return "[" 'Nunca llegará a este punto, bueno si pero no a esta línea
    End Function
End Class
