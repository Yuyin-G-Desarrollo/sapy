Public Class TallasBU
    Public Function VerPaisesTallas() As DataTable
        Dim TallaDatos As New Programacion.Datos.TallasDA
        Return TallaDatos.VerPaisesTalla
    End Function

    Public Function VerTallasPrincipales() As DataTable
        Dim TallaDatos As New Programacion.Datos.TallasDA
        Return TallaDatos.VerTallasPrincipales
    End Function

    Public Sub RegistrarTalla(ByVal EntidadTallas As Entidades.Tallas, ByVal usuario As Int32)
        Dim TallaDatos As New Programacion.Datos.TallasDA
        TallaDatos.RegistrarDatosTalla(EntidadTallas, usuario)
    End Sub

    Public Sub insertarTallas(ByVal Talla As String, ByVal tallaDescripcion As String, ByVal IdTalla As Int32)
        Dim TallaDatos As New Programacion.Datos.TallasDA
        TallaDatos.inretarTallas(Talla, tallaDescripcion, IdTalla)
    End Sub

    Public Function VerIdMaximoTalla() As DataTable
        Dim TallaDatos As New Programacion.Datos.TallasDA
        Return TallaDatos.maximaTallaId()
    End Function

    Public Function VerTablaTallas(ByVal descripcion As String, ByVal idTalla As String, ByVal activo As Boolean, ByVal grupo As String) As DataTable
        Dim TallaDatos As New Programacion.Datos.TallasDA
        Return TallaDatos.VerTallas(descripcion, idTalla, activo, grupo)
    End Function

    Public Function verDatosTallaEditar(ByVal idTalla As Int32) As DataTable
        Dim TallaDatos As New Programacion.Datos.TallasDA
        Return TallaDatos.VerDatosTallaEditar(idTalla)

    End Function

    Public Sub EditarTallas(ByVal EntidadTalla As Entidades.Tallas, ByVal usuario As Int32)
        Dim TallaDatos As New Programacion.Datos.TallasDA
        TallaDatos.EditaTalla(EntidadTalla, usuario)
    End Sub


    Public Function VerAmarreExisteTalla(ByVal idTalla As Int32) As DataTable
        Dim TallaDatos As New Programacion.Datos.TallasDA
        Return TallaDatos.VerAmarres(idTalla)
    End Function

    Public Sub AlterarAmarresBU(ByVal IdTalla As Int32)
        Dim TallaDatos As New Programacion.Datos.TallasDA
        TallaDatos.AlterarAmarres(IdTalla)
    End Sub

    Public Sub AltaAmarreBU(ByVal idTalla As Int32, ByVal descripcion As String, ByVal amarreUno As Int32, ByVal amarreDos As Int32, ByVal total As Int32)
        Dim TallaDatos As New Programacion.Datos.TallasDA
        TallaDatos.AltaAmarre(idTalla, descripcion, amarreUno, amarreDos, total)
    End Sub

    Public Sub AltaAmarreTotal(ByVal idTalla As Int32, ByVal descripcion As String, ByVal total As Int32)
        Dim TallaDatos As New Programacion.Datos.TallasDA
        TallaDatos.AltaAmarreTotal(idTalla, descripcion, total)
    End Sub

    Public Function verTallaInicialSeleccionada(ByVal idTallaInicial As String) As DataTable
        Dim objTDA As New Programacion.Datos.TallasDA
        Return objTDA.VerTallaInicialSeleccionada(idTallaInicial)
    End Function

    Public Function verComboTallas() As DataTable
        Dim objTDA As New Programacion.Datos.TallasDA
        Return objTDA.VerComboTallas
    End Function

    Public Function validaExistenModelos(ByVal idTalla As String) As DataTable
        Dim objTDA As New Programacion.Datos.TallasDA
        Return objTDA.validaExistenModelos(idTalla)
    End Function

    Public Function verTallasRegistroRapido(ByVal idsTallas As String) As DataTable
        Dim objTDA As New Programacion.Datos.TallasDA
        Return objTDA.verTallasRegistroRapido(idsTallas)
    End Function

    Public Function VerificarTallasInsertadasPorPais(ByVal Pais As String, ByVal TallaPrincipal As String) As DataTable
        Dim objTDA As New Programacion.Datos.TallasDA
        Return objTDA.VerificarTallasInsertadasPorPais(Pais, TallaPrincipal)
    End Function

    Public Sub AltaAmarreSicy(ByVal idTalla As Int32)
        Dim TallaDatos As New Programacion.Datos.TallasDA
        TallaDatos.AltaAmarreSicy(idTalla)
    End Sub
End Class
