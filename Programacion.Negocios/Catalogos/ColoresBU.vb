Public Class ColoresBU

    Public Function VerListaColores(ByVal idColor As String, ByVal descripcion As String, ByVal activo As Boolean, ByVal codSicy As String) As DataTable
        Dim ColoresDatos As New Programacion.Datos.ColoresDA
        Return ColoresDatos.VerListaColores(idColor, descripcion, activo, codSicy)
    End Function
    Public Function VerFilasColores() As DataTable
        Dim ColoresDatos As New Programacion.Datos.ColoresDA
        Return ColoresDatos.VerFilasColores
    End Function
    Public Function verIdMaximoColores() As DataTable
        Dim ColoresDatos As New Programacion.Datos.ColoresDA
        Return ColoresDatos.VerIdMaximoColores
    End Function

    Public Sub registrarColor(ByVal entidadColor As Entidades.Colores, ByVal usuario As Int32)
        Dim ColoresDatos As New Programacion.Datos.ColoresDA
        ColoresDatos.RegistrarColor(entidadColor, usuario)
    End Sub

    Public Sub editarColor(ByVal entidadColor As Entidades.Colores, ByVal usuario As Int32)
        Dim ColoresDatos As New Programacion.Datos.ColoresDA
        ColoresDatos.Editarcolor(entidadColor, usuario)
    End Sub

    Public Function verComboColores() As DataTable
        Dim objCOLDA As New Programacion.Datos.ColoresDA
        Return objCOLDA.VerComboColor()
    End Function

    Public Function VerColoresGridProducto() As DataTable
        Dim objCOLDA As New Programacion.Datos.ColoresDA
        Return objCOLDA.VerColoresGridProducto
    End Function

    Public Function VerColoresModelosExisten(ByVal idColor As String) As DataTable
        Dim objCOLDA As New Programacion.Datos.ColoresDA
        Return objCOLDA.validaExistenModelos(idColor)
    End Function

End Class
