Imports System.IO

Public Class FirmaBiometrica
    Dim WithEvents registro As FlexCodeSDK.FinFPReg
    Dim WithEvents version As FlexCodeSDK.FinFPVer
    'Dim objBU As New Framework.Negocios.HuellaBU
    Dim huella As String

    Public banderaInsertar As Boolean = False
    Public banderaValidar As Int32
    Public etiqueta As Label
    Public imagenP As PictureBox
    Public empleado As Entidades.ColaboradorFirmaBiometrica

    Public Sub leerHuella(ByVal colaborador As Entidades.ColaboradorFirmaBiometrica, imagen As PictureBox, label As Label)
        banderaInsertar = False
        registro = New FlexCodeSDK.FinFPReg
        empleado = colaborador
        ObtenerDedoChecador(colaborador.Pdedo, colaborador.Pmano)
        imagenP = imagen
        etiqueta = label
        registro.AddDeviceInfo("F600E002819", "4C6CB69586C3C61", "5SJ73E575F1CAEE1648D543J")
        registro.PictureSamplePath = My.Application.Info.DirectoryPath & "\FPTemp.BMP"
        registro.PictureSampleHeight = Microsoft.VisualBasic.Compatibility.VB6.PixelsToTwipsY(imagenP.Height)
        registro.PictureSampleWidth = Microsoft.VisualBasic.Compatibility.VB6.PixelsToTwipsY(imagenP.Width)
        registro.FPRegistrationStart("YourSecretKey" & colaborador.PcolaboradorId)
    End Sub


    Public Sub validarHuella(ByVal colaborador As List(Of Entidades.ColaboradorFirmaBiometrica))
        banderaValidar = 0
        version = New FlexCodeSDK.FinFPVer
        version.AddDeviceInfo("F600E002819", "4C6CB69586C3C61", "5SJ73E575F1CAEE1648D543J")
        If colaborador.Count = 1 Then
            empleado = colaborador.Item(0)
            version.FPLoad(empleado.PcolaboradorId, empleado.Pdedo, empleado.Phuella, "YourSecretKey" & empleado.PcolaboradorId)
        Else
            For Each emp As Entidades.ColaboradorFirmaBiometrica In colaborador
                version.FPLoad(emp.PcolaboradorId, emp.Pdedo, emp.Phuella, "YourSecretKey" & emp.PcolaboradorId)
            Next
        End If
        'version.FPVerificationStart()
    End Sub

    Public Sub IniciarValidacion()
        version.FPVerificationStart()
    End Sub

    Private Sub registro_FPRegistrationImage() Handles registro.FPRegistrationImage
        Dim imgFile As System.IO.FileStream = New System.IO.FileStream(My.Application.Info.DirectoryPath & "\FPTemp.BMP", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)
        Dim fileBytes(imgFile.Length) As Byte
        imgFile.Read(fileBytes, 0, fileBytes.Length)
        imgFile.Close()
        Dim ms As System.IO.MemoryStream = New MemoryStream(fileBytes)
        imagenP.Image = Image.FromStream(ms)
    End Sub

    Private Sub registro_FPRegistrationStatus(Status As FlexCodeSDK.RegistrationStatus) Handles registro.FPRegistrationStatus
        If Status = FlexCodeSDK.RegistrationStatus.r_OK Then
            Clipboard.SetText(huella)
            empleado.Phuella = huella
            'objBU.insertarHuella(empleado.PcolaboradorId, empleado.Pmano, empleado.Pdedo, empleado.PusuarioCreo, Clipboard.GetText())
            'MessageBox.Show("Registro correcto")
            banderaInsertar = True
        End If
    End Sub

    Private Sub registro_FPRegistrationTemplate(FPTemplate As String) Handles registro.FPRegistrationTemplate
        huella = FPTemplate
    End Sub

    Private Sub registro_FPSamplesNeeded(Samples As Short) Handles registro.FPSamplesNeeded
        etiqueta.Text = "Falta leer la huella " & Str(Samples) & " veces mas"
    End Sub

    Private Sub version_FPVerificationID(ID As String, FingerNr As FlexCodeSDK.FingerNumber) Handles version.FPVerificationID
        empleado = New Entidades.ColaboradorFirmaBiometrica
        empleado.PcolaboradorId = ID
        empleado.Pdedo = FingerNr
        banderaValidar = 1
        'MessageBox.Show("Colaborador " & ID)
        'Insertar registro de entreda, salida
        'objBU.insertarHuella(empleado.PcolaboradorId, empleado.Pmano, empleado.Pdedo, empleado.PusuarioCreo, Clipboard.GetText())
    End Sub

    Private Sub version_FPVerificationStatus(Status As FlexCodeSDK.VerificationStatus) Handles version.FPVerificationStatus
        If Status = FlexCodeSDK.VerificationStatus.v_OK Then
            'version.FPVerificationStop()
            banderaValidar = 1
        ElseIf Status = FlexCodeSDK.VerificationStatus.v_NotMatch Then
            banderaValidar = 2
            'version.FPVerificationStop()
        ElseIf Status = FlexCodeSDK.VerificationStatus.v_FPListEmpty Then
            banderaValidar = 2
            'version.FPVerificationStop()
        End If
    End Sub

    Public Sub CancelarLectura()
        If Not registro Is Nothing Then
            registro.FPRegistrationStop()
        End If
    End Sub

    Public Sub TerminarValidacion()
        version.FPVerificationStop()
    End Sub

    Private Sub ObtenerDedoChecador(ByVal dedo As Int32, ByVal mano As Int32)
        Dim DedoLibreria As Int32 = 10
        Select Case mano
            Case 1
                Select Case dedo
                    Case 1
                        DedoLibreria = 5
                    Case 2
                        DedoLibreria = 6
                    Case 3
                        DedoLibreria = 7
                    Case 4
                        DedoLibreria = 8
                    Case 5
                        DedoLibreria = 9
                    Case Else
                End Select
            Case 2
                Select Case dedo
                    Case 1
                        DedoLibreria = 4
                    Case 2
                        DedoLibreria = 3
                    Case 3
                        DedoLibreria = 2
                    Case 4
                        DedoLibreria = 1
                    Case 5
                        DedoLibreria = 0
                    Case Else
                End Select
            Case Else
        End Select

        empleado.PdedoLibreria = DedoLibreria
    End Sub

End Class
