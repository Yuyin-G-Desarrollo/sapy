Imports Programacion.Datos
Public Class LicenciasBU

    Public Function validarClaveLicencia(ByVal clave As String)
        Dim obj As New LicenciasDA
        Return obj.validarClaveLicencia(clave)
    End Function

    Public Function validarNombreLicencia(ByVal Licencia As String)
        Dim obj As New LicenciasDA
        Return obj.validarNombreLicencia(Licencia)

    End Function

    Public Function validarCodigoSICYLicencia(ByVal codSICY As String)
        Dim obj As New LicenciasDA
        Return obj.validarCodigoSICYLicencia(codSICY)
    End Function

    Public Function GuardarAltaLicencia(ByVal nombreLicencia As String, ByVal codigo As String, ByVal activo As Integer, ByVal idUsuario As Integer, ByVal clave As String, ByVal comercializadora As Integer)
        Dim obj As New LicenciasDA
        Return obj.GuardarAltaLicencia(nombreLicencia, codigo, activo, idUsuario, clave, comercializadora)
    End Function

    Public Function ConsultarMarcaLicenciaReedition(ByVal activo As Integer)
        Dim obj As New LicenciasDA
        Return obj.ConsultarMarcaLicenciaReedition(activo)
    End Function

    Public Function validarNombreLicenciaEditar(ByVal Licencia As String, ByVal idmarca As Integer)
        Dim obj As New LicenciasDA
        Return obj.validarNombreLicenciaEditar(Licencia, idmarca)
    End Function

    Public Function validarCodigoLicenciaEditar(ByVal codSICY As String, ByVal idmarca As Integer)
        Dim obj As New LicenciasDA
        Return obj.validarCodigoLicenciaEditar(codSICY, idmarca)
    End Function
    Public Function GuardarEditarLicencia(ByVal marcaid As Integer, ByVal nombreLicencia As String, ByVal codigo As String, ByVal activo As Integer, ByVal idUsuaro As Integer)
        Dim obj As New LicenciasDA
        Return obj.GuardarEditarLicencia(marcaid, nombreLicencia, codigo, activo, idUsuaro)
    End Function

    Public Function ObtenerIdCodigo() As Integer
        Dim obj As New LicenciasDA
        Dim tbl As New DataTable
        Dim idCodigoSICY As Integer
        tbl = obj.ObtenerIdCodigo()
        If tbl.Rows.Count > 0 Then
            idCodigoSICY = tbl.Rows(0).Item("marc_codigo")
        End If
        Return idCodigoSICY
    End Function
End Class
