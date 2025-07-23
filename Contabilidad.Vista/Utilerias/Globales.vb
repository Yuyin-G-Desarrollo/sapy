Imports System.IO
Module Globales
    Public Const diasBimestre As Integer = 61
    Public Const seguroVivienda As Integer = 15
    Public Const mesesPeriodo As Integer = 2
    Public Const diasMes As Double = 30.4
    Public Const guia As String = "17400"
    Public Const rutaAcuses As String = "IMAGENES/"
    Public Const rutaTmpLocal As String = "C:\TmpRecibos\"
    Public Const rutaTmp As String = "C:\TmpCartas\"
    Public Const rutaFTPHttp As String = "http://192.168.2.158/Nomina/"
    Public Const rutaUtilerias As String = "\\192.168.2.2\bin\UtileriasNomina\"
    Public Const ServidorRest As String = "http://192.168.2.158:8040/"
    Public Const ServidorRestPruebasPruebas As String = "http://localhost:7639/"

    Public Function validarCurpRFC(ByVal idColaborador As Int32, ByVal valida As String) As Boolean
        Dim objBu As New Negocios.UtileriasBU

        Dim dtCurpRfc As New DataTable

        dtCurpRfc = objBu.validaCurpColaborador(idColaborador)

        If dtCurpRfc.Rows.Count > 0 Then

            If valida = "CURP" Then
                If dtCurpRfc.Rows(0).Item("CURP_Calculado").ToString = dtCurpRfc.Rows(0).Item("CURP_BD").ToString Then
                    validarCurpRFC = True
                Else
                    validarCurpRFC = False
                End If
            ElseIf valida = "RFC" Then
                If dtCurpRfc.Rows(0).Item("RFC_Calculado").ToString = dtCurpRfc.Rows(0).Item("RFC_BD").ToString Then
                    validarCurpRFC = True
                Else
                    validarCurpRFC = False
                End If
            End If
        Else
            validarCurpRFC = False
        End If

        Return validarCurpRFC
    End Function
    'Public Function validarCurpRFC(ByVal aPaterno As String, ByVal aMaterno As String, ByVal nombre As String,
    '                            ByVal fechaNacimiento As String, ByVal curpCapturada As String) As Boolean

    '    Dim vuelta1 As Int32 = 1
    '    Dim vocalApaterno As String = String.Empty
    '    Dim primeraLetraPaterno As String = String.Empty
    '    Dim primeraLetraMaterno As String = String.Empty
    '    Dim primeraLetraNombre As String = String.Empty
    '    Dim fecha() As String
    '    Dim diasAnio As String = String.Empty
    '    Dim digitosAnio As String = String.Empty
    '    Dim curp As String = String.Empty
    '    Dim curpDigitos As String = String.Empty
    '    Dim nombres() As String
    '    Dim nombre2 As String = String.Empty

    '    Dim palabraClave As String = String.Empty

    '    nombres = nombre.Split(" ")
    '    fecha = fechaNacimiento.Split("/")

    '    If aMaterno = "" Then
    '        primeraLetraMaterno = "X"
    '    Else
    '        primeraLetraMaterno = aMaterno(0)
    '    End If

    '    primeraLetraNombre = nombre(0)

    '    If nombres(0).Equals("MARIA") Or nombres(0).Equals("MARÍA") Or nombres(0).Equals("JOSE") Or nombres(0).Equals("JOSÉ") Then
    '        If nombres.Length > 2 Then
    '            nombre2 = nombres(nombres.Length - 1)
    '        Else
    '            nombre2 = nombres(1)
    '        End If

    '        If nombre2 = "" Then
    '            primeraLetraNombre = nombre(0)
    '        Else
    '            primeraLetraNombre = nombre2(0)
    '        End If

    '    End If

    '    diasAnio = fecha(2)
    '    digitosAnio = diasAnio(2) + diasAnio(3)


    '    For i = 0 To aPaterno.Length - 1
    '        primeraLetraPaterno = aPaterno(0)

    '        If Convert.ToChar(aPaterno(i)) = "A" Or Convert.ToChar(aPaterno(i)) = "E" Or Convert.ToChar(aPaterno(i)) = "I" Or Convert.ToChar(aPaterno(i)) = "O" Or Convert.ToChar(aPaterno(i)) = "U" Then
    '            If vuelta1 = 1 And i <> 0 Then
    '                vocalApaterno = aPaterno(i)
    '                vuelta1 += 1
    '            End If

    '        End If
    '    Next

    '    palabraClave = primeraLetraPaterno + vocalApaterno + primeraLetraMaterno + primeraLetraNombre
    '    If palabraClave.Equals("BACA") Or palabraClave.Equals("BAKA") Or palabraClave.Equals("BUEI") Or palabraClave.Equals("BUEY") Or
    '        palabraClave.Equals("CACA") Or palabraClave.Equals("CACO") Or palabraClave.Equals("CAGA") Or palabraClave.Equals("CAGO") Or
    '        palabraClave.Equals("CAKA") Or palabraClave.Equals("CAKO") Or palabraClave.Equals("COGE") Or palabraClave.Equals("COGI") Or
    '        palabraClave.Equals("COJA") Or palabraClave.Equals("COJE") Or palabraClave.Equals("COJI") Or palabraClave.Equals("COJO") Or
    '        palabraClave.Equals("CULO") Or palabraClave.Equals("FALO") Or palabraClave.Equals("FETO") Or palabraClave.Equals("GUEI") Or
    '        palabraClave.Equals("JOTO") Or palabraClave.Equals("JETA") Or palabraClave.Equals("KACA") Or palabraClave.Equals("KACO") Or
    '        palabraClave.Equals("KAGA") Or palabraClave.Equals("KAGO") Or palabraClave.Equals("KAKA") Or palabraClave.Equals("KAKO") Or
    '        palabraClave.Equals("KOGE") Or palabraClave.Equals("KOGI") Or palabraClave.Equals("KOJA") Or palabraClave.Equals("KOJE") Or
    '        palabraClave.Equals("KOJI") Or palabraClave.Equals("KOJO") Or palabraClave.Equals("KOLA") Or palabraClave.Equals("Kulo") Or
    '        palabraClave.Equals("LILO") Or palabraClave.Equals("LOCA") Or palabraClave.Equals("LOKA") Or palabraClave.Equals("MIAR") Or
    '        palabraClave.Equals("LOKO") Or palabraClave.Equals("MAME") Or palabraClave.Equals("MAMO") Or palabraClave.Equals("MION") Or
    '        palabraClave.Equals("MEAR") Or palabraClave.Equals("MEAS") Or palabraClave.Equals("MEON") Or palabraClave.Equals("MOCO") Or
    '        palabraClave.Equals("MOKO") Or palabraClave.Equals("MULA") Or palabraClave.Equals("MULO") Or palabraClave.Equals("NACA") Or
    '        palabraClave.Equals("NACO") Or palabraClave.Equals("PEDA") Or palabraClave.Equals("PEDO") Or palabraClave.Equals("PENE") Or
    '        palabraClave.Equals("PIPI") Or palabraClave.Equals("PITO") Or palabraClave.Equals("POPO") Or palabraClave.Equals("PUTA") Or
    '        palabraClave.Equals("PUTO") Or palabraClave.Equals("QULO") Or palabraClave.Equals("RATA") Or palabraClave.Equals("ROBA") Or
    '        palabraClave.Equals("ROBO") Or palabraClave.Equals("RUINA") Or palabraClave.Equals("SENO") Or palabraClave.Equals("TETA") Or
    '        palabraClave.Equals("VACA") Or palabraClave.Equals("VAGA") Or palabraClave.Equals("VAGO") Or palabraClave.Equals("VAKA") Or
    '        palabraClave.Equals("VUEI") Or palabraClave.Equals("VUEY") Or palabraClave.Equals("WUEI") Or palabraClave.Equals("WUEY") Then


    '        vocalApaterno = "X"

    '    End If
    '    curp = primeraLetraPaterno + vocalApaterno + primeraLetraMaterno + primeraLetraNombre + digitosAnio + fecha(1) + fecha(0)
    '    If curpCapturada.Length > 9 Then
    '        curpDigitos = curpCapturada(0) + curpCapturada(1) + curpCapturada(2) + curpCapturada(3) + curpCapturada(4) + curpCapturada(5) + curpCapturada(6) + curpCapturada(7) + curpCapturada(8) + curpCapturada(9)
    '    Else
    '        curpDigitos = curpCapturada
    '    End If



    '    If curpDigitos.Equals(curp) Then
    '        validarCurpRFC = True
    '    Else
    '        validarCurpRFC = False
    '    End If

    '    Return validarCurpRFC
    'End Function

    Public Function validaCURPRFCAlta(ByVal aPaterno As String, ByVal aMaterno As String, ByVal nombre As String,
                                      ByVal fechaNacimiento As String, ByVal curpCapturada As String, ByVal rfcCapturado As String, ByVal valida As String) As Boolean

        Dim objBu As New Negocios.UtileriasBU

        Dim dtCurpRfc As New DataTable

        dtCurpRfc = objBu.validaCurpRFCAlta(aPaterno, aMaterno, nombre, fechaNacimiento, curpCapturada, rfcCapturado)

        If dtCurpRfc.Rows.Count > 0 Then
            If valida = "CURP" Then
                If dtCurpRfc.Rows(0).Item("CURP_Calculado").ToString = dtCurpRfc.Rows(0).Item("CURP_BD").ToString Then
                    validaCURPRFCAlta = True
                Else
                    validaCURPRFCAlta = False
                End If
            ElseIf valida = "RFC" Then
                If dtCurpRfc.Rows(0).Item("RFC_Calculado").ToString = dtCurpRfc.Rows(0).Item("RFC_BD").ToString Then
                    validaCURPRFCAlta = True
                Else
                    validaCURPRFCAlta = False
                End If
            End If
        Else
            validaCURPRFCAlta = False
        End If
    End Function

    Public Function existeCarpeta(ByVal ruta As String) As Boolean
        Dim exists As Boolean
        exists = System.IO.Directory.Exists(ruta)
        Return exists
    End Function

    Public Sub crearCarpeta(ByVal ruta As String)
        System.IO.Directory.CreateDirectory(ruta)
    End Sub

    Public Function existeArchivo(ByVal archivo As String) As Boolean
        If Dir(archivo) = vbNullString Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub eliminaArchivo(ByVal archivo As String)
        Try
            File.Delete(archivo)
        Catch ex As Exception

        End Try
    End Sub
End Module

