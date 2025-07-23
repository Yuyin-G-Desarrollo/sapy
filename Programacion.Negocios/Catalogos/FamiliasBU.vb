Public Class FamiliasBU

    Public Function ListarFamilias(ByVal clave As String, ByVal descripcion As String, ByVal activo As Boolean) As DataTable
        Dim FamiliaDatos As New Programacion.Datos.FamiliasDA
        Return FamiliaDatos.ListarFamilias(clave, descripcion, activo)
    End Function

    Public Function VerIdfamiliaMasAlto()
        Dim FamiliaDatos As New Programacion.Datos.FamiliasDA
        Return FamiliaDatos.VerIdMaximo
    End Function

    Public Function VerCodigosDisponibles()
        Dim FamiliaDatos As New Programacion.Datos.FamiliasDA
        Dim CodigosDisponibles = FamiliaDatos.VerCodigosDisponibles
        Return CodigosDisponibles
    End Function

    Public Function ContadorFilas() As DataTable
        Dim FamiliaDatos As New Programacion.Datos.FamiliasDA
        Return FamiliaDatos.ContadorFilas
    End Function

    Public Sub RegistraFamilia(ByVal Familias As Entidades.Familias, ByVal usuario As Int32)
        Dim FamiliasDatos As New Programacion.Datos.FamiliasDA
        FamiliasDatos.RegistrarFamilia(Familias, usuario)
    End Sub


    Public Function ValidarRepetidos(ByVal codigo As String) As DataTable
        Dim FamiliaDatos As New Programacion.Datos.FamiliasDA
        Dim ValidacionActivar = FamiliaDatos.ValidarRepetidos(codigo)
        Return ValidacionActivar
    End Function


    Public Sub EditarFamilia(ByVal EnFamilia As Entidades.Familias, ByVal Usuario As Int32)
        Dim FamiliaDatos As New Programacion.Datos.FamiliasDA
        FamiliaDatos.ModificarFamilia(EnFamilia, Usuario)
    End Sub
    Public Function VerComboFamiliaVentas(ByVal idProducto As Integer) As DataTable
        Dim objFDA As New Programacion.Datos.FamiliasDA
        Return objFDA.VerComboFamiliaVentas(idProducto)
    End Function
    Public Function VerComboFamiliaVentas() As DataTable
        Dim objFDA As New Programacion.Datos.FamiliasDA
        Return objFDA.VerComboFamiliaVentas()
    End Function
    Public Function verComboFamilias(ByVal descripcion As String) As DataTable
        Dim objFDA As New Programacion.Datos.FamiliasDA
        Return objFDA.VerComboFamilia(descripcion)
    End Function

    Public Function VerCodigoFamiliaRapido(ByVal idFam As String) As DataTable
        Dim objFDA As New Programacion.Datos.FamiliasDA
        Return objFDA.VerCodigoFamiliaRapido(idFam)
    End Function

    Public Function validaExistenModelos(ByVal idFamilia As String) As DataTable
        Dim objFDA As New Programacion.Datos.FamiliasDA
        Return objFDA.validaExistenModelos(idFamilia)
    End Function

    Public Function seleccionarTallasEnFamilia(ByVal idFamilia As Int32) As DataTable
        Dim objFDA As New Programacion.Datos.FamiliasDA
        Return objFDA.seleccionarTallasEnFamilia(idFamilia)
    End Function

    Public Function ConsultaTallasEnFamilia(ByVal idFamilia As Int32) As DataTable
        Dim objFDA As New Programacion.Datos.FamiliasDA
        Return objFDA.ConsultaTallasEnFamilia(idFamilia)
    End Function

    Public Sub editarEstatusFamTallas(ByVal idFamilia As Int32)
        Dim objFDA As New Programacion.Datos.FamiliasDA
        objFDA.editarEstatusFamTallas(idFamilia)
    End Sub

    Public Sub editarFamiliaTallas(ByVal idFamilia As Int32, ByVal idTalla As Int32)
        Dim objFDA As New Programacion.Datos.FamiliasDA
        objFDA.editarFamiliaTallas(idFamilia, idTalla)
    End Sub

    'Public Function FamiliasTallasSeleccionarProd() As DataTable
    '    Dim objPDA As New Programacion.Datos.FamiliasDA
    '    Return objPDA.FamiliasTallasSeleccionarProd()
    ' '' Eliminar este metodo si no se llega a utilizar.
    'End Function

    Public Function familiasRegistroRapido(ByVal idsFamilias As String) As DataTable
        Dim objPDA As New Programacion.Datos.FamiliasDA
        Return objPDA.familiasRegistroRapido(idsFamilias)
    End Function

    Public Function verFamiliaRegistroRapido(ByVal idFam As String) As DataTable
        Dim objPDA As New Programacion.Datos.FamiliasDA
        Return objPDA.verFamiliaRegistroRapido(idFam)
    End Function

End Class
