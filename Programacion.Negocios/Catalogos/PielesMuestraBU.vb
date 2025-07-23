Public Class PielesMuestraBU

    Public Function VerPielesMuestra(ByVal descripcion As String, ByVal codigo As String, ByVal activo As Boolean) As DataTable
        Dim PielMuestraDatos As New Programacion.Datos.PielesMuestraDA
        Return PielMuestraDatos.VerPielesMuestra(descripcion, codigo, activo)
    End Function

    Public Function VerIdMaximoPielMuestra() As DataTable
        Dim PielMuestraDatos As New Programacion.Datos.PielesMuestraDA
        Return PielMuestraDatos.VerIdMaximoPielMuestra()
    End Function

    Public Function VerCantidadFilas() As DataTable
        Dim PielMuestraDatos As New Programacion.Datos.PielesMuestraDA
        Return PielMuestraDatos.VerCantidadFilas
    End Function

    Public Sub RegistraPielMuestra(ByVal entidadPielMuestra As Entidades.PielesMuestra, ByVal usuario As Int32)
        Dim pielMuestraDatos As New Programacion.Datos.PielesMuestraDA
        pielMuestraDatos.RegistrarPielMuestra(entidadPielMuestra, usuario)

    End Sub

    Public Sub EditarPielMuestra(ByVal entidadPielMuestra As Entidades.PielesMuestra, ByVal usuario As Int32)
        Dim pielMuestraDatos As New Programacion.Datos.PielesMuestraDA
        pielMuestraDatos.EditarPielMuestra(entidadPielMuestra, usuario)
    End Sub

    Public Function verComboCortes() As DataTable
        Dim objCortes As New Programacion.Datos.PielesMuestraDA
        Return objCortes.verComboCortes()
    End Function

    Public Function validaExistenModelos(ByVal idPielMuestra As String) As DataTable
        Dim objCortes As New Programacion.Datos.PielesMuestraDA
        Return objCortes.validaExistenModelos(idPielMuestra)
    End Function


    Public Function verCortesRegistroRapido(ByVal idsCortes As String) As DataTable
        Dim objPDA As New Programacion.Datos.PielesMuestraDA
        Return objPDA.verCortesRegistroRapido(idsCortes)
    End Function

End Class
