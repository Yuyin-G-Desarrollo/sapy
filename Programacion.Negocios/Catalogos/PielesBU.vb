Public Class PielesBU

    Public Function VerListaPieles(ByVal codigo As String, ByVal descripcion As String, ByVal nombreCorto As String, ByVal activo As Boolean, ByVal codSicy As String) As DataTable
        Dim PielesDatos As New Programacion.Datos.PielesDA
        Return PielesDatos.VerListaPieles(codigo, descripcion, nombreCorto, activo, codSicy)

    End Function

    Public Function VerCodMax() As DataTable
        Dim PielDato As New Programacion.Datos.PielesDA
        Return PielDato.VerCodMax
    End Function

    Public Function VerIdPielMax() As DataTable
        Dim pielDato As New Programacion.Datos.PielesDA
        Return pielDato.VerIdPielMax
    End Function


    Public Sub RegistrarPiel(ByVal EntidadPiel As Entidades.Pieles, ByVal usuario As Int32)
        Dim PielDato As New Programacion.Datos.PielesDA
        PielDato.RegistrarPiel(EntidadPiel, usuario)
    End Sub

    Public Function VerDatosPielEditar(ByVal idPiel As Int32)
        Dim PielDatos As New Programacion.Datos.PielesDA
        Return PielDatos.VerCamposPielEditar(idPiel)
    End Function

    Public Sub EditarPiel(ByVal EntidadPiel As Entidades.Pieles, ByVal usuario As Int32)
        Dim pielDatos As New Programacion.Datos.PielesDA
        pielDatos.EditarPiel(EntidadPiel, usuario)
    End Sub

    Public Function verComboPieles() As DataTable
        Dim objPDa As New Programacion.Datos.PielesDA
        Return objPDa.VerComboPiel()
    End Function

    Public Function VerPielGridProducto() As DataTable
        Dim objPDa As New Programacion.Datos.PielesDA
        Return objPDa.VerPielGridProducto()
    End Function

    Public Sub registraPielColor(ByVal idPiel As Integer, ByVal idColor As Integer)
        Dim objPDa As New Programacion.Datos.PielesDA
        objPDa.registrarPielColor(idPiel, idColor)
    End Sub

    Public Function consultaDetallesColorPiel(ByVal idPiel As String) As DataTable
        Dim objPDa As New Programacion.Datos.PielesDA
        Return objPDa.consultaDetallesColorPiel(idPiel)
    End Function

    Public Sub desacrtivarPielCol(ByVal idPiel As String)
        Dim objPDa As New Programacion.Datos.PielesDA
        objPDa.desactivarPielColor(idPiel)
    End Sub

    Public Sub EditarPielColor(ByVal idPiel As Integer, ByVal idColor As Integer)
        Dim objPDa As New Programacion.Datos.PielesDA
        objPDa.EditarPielColor(idPiel, idColor)
    End Sub
    Public Function verColoresSeleccionadosPiel(ByVal idPiel As String) As DataTable
        Dim objPDa As New Programacion.Datos.PielesDA
        Return objPDa.verColoresSeleccionadosPiel(idPiel)
    End Function

    Public Function validaExistenModelos(ByVal idPiel As String) As DataTable
        Dim objPDa As New Programacion.Datos.PielesDA
        Return objPDa.validaExistenModelos(idPiel)
    End Function

    Public Function verPielesRegistroRapido(ByVal idsPieles As String) As DataTable
        Dim objPDa As New Programacion.Datos.PielesDA
        Return objPDa.verPielesRegistroRapido(idsPieles)
    End Function

End Class
