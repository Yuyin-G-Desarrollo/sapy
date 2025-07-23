Imports Framework.Datos
Imports Entidades

Public Class CFDIBU
    'Public Function getDatosSemana(ByVal semana As Integer) As DataTable
    '    Dim obj As New CFDIDA
    '    Return obj.getDatosSemana(semana)
    'End Function
    'Public Function getSemanaActual() As DataTable
    '    Dim obj As New CFDIDA
    '    Return obj.getSemanaActual()
    'End Function
    Public Function getFacturasEliminadas(ByVal idNaveSay As Integer, ByVal f1 As Date, ByVal f2 As Date) As DataTable
        Dim obj As New CFDIDA
        Return obj.getFacturasEliminadas(idNaveSay, f1, f2)
    End Function
    'Public Function getFacturasAutorizadas(ByVal idNaveSay As Integer, ByVal f1 As Date, ByVal f2 As Date) As DataTable
    '    Dim obj As New CFDIDA
    '    Return obj.getFacturasAutorizadas(idNaveSay, f1, f2)
    'End Function
    Public Function getConfiguracionNave(ByVal idNaveSay As Integer) As DataTable
        Dim obj As New CFDIDA
        Return obj.getConfiguracionNave(idNaveSay)
    End Function
    Public Function getNaveSIcy(ByVal idNaveSay As Integer) As Integer
        Dim obj As New CFDIDA
        Return obj.getNaveSIcy(idNaveSay)
    End Function
    Public Function getCFDISinRecibir(ByVal idNave As Integer) As DataTable
        Dim obj As New CFDIDA
        Return obj.getCFDISinRecibir(idNave)
    End Function
    Public Function getCFDIRecibidas(ByVal idNave As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim obj As New CFDIDA
        Return obj.getCFDIRecibidas(idNave, FechaInicio, FechaFin)
    End Function
    Public Function insertarFactura(ByVal xml As xml) As Integer
        Dim obj As New CFDIDA
        Return obj.insertarFactura(xml)
    End Function
    Public Function eliminarFactura(ByVal idCFDI As Integer, ByVal ruta As String) As DataTable
        Dim obj As New CFDIDA
        Return obj.eliminarFactura(idCFDI, ruta)
    End Function
    Public Function recibirFacturaEstatusValidador(ByVal idCFDI As Integer) As DataTable
        Dim obj As New CFDIDA
        Return obj.recibirFacturaEstatusValidador(idCFDI)
    End Function
    Public Function recibirFacturaInsertarCFDS(ByVal idCFDI As Integer) As String
        Dim obj As New CFDIDA
        Return obj.recibirFacturaInsertarCFDS(idCFDI)
    End Function
    Public Function actualizarRutadeFactura(ByVal idCFDI As Integer, ByVal rutaxml As String, ByVal rutapdf As String) As DataTable
        Dim obj As New CFDIDA
        Return obj.actualizarRutadeFactura(idCFDI, rutaxml, rutapdf)
    End Function
    'Public Function insertarFacturaEnSAY(ByVal xml As xml) As Integer
    '    Dim obj As New CFDIDA
    '    Return obj.insertarFacturaEnSAY(xml)
    'End Function
    'Public Function getDatosFacturaValidada(ByVal idFactura As Integer) As Entidades.xml
    '    Dim obj As New CFDIDA
    '    Return obj.getDatosFacturaValidada(idFactura)
    'End Function
    Public Function validarReceptor(ByVal rfc As String) As Boolean
        Dim obj As New CFDIDA
        If obj.validarReceptor(rfc) Then
            Return True
        End If
        Return False
    End Function
    Public Function validarExistenciaFactura(ByVal uuid As String) As String
        Dim obj As New CFDIDA
        Return obj.validarExistenciaFactura(uuid)

    End Function

    Public Function llenarComboProveedorNuevo() As DataTable
        Dim objDa As New CFDIDA
        Dim tablaProveedor As New DataTable
        Return objDa.llenarComboProveedorNuevo()
    End Function

    Public Function llenarComboNaveSICY() As DataTable
        Dim objDa As New CFDIDA
        Dim tablaNaveSICY As New DataTable
        Return objDa.llenarComboNaveSICY()
    End Function

    Public Function actualizarDatosFactura(ByVal NaveID As Integer, ByVal FolioNuevo As String, ByVal FolioAnterior As String, ByVal NaveAnteriorID As Integer, ByVal ProveedorAnteriorID As Integer, ByVal SerieP As String) As DataTable
        Dim objDa As New CFDIDA
        Return objDa.actualizarDatosFactura(NaveID, FolioNuevo, FolioAnterior, NaveAnteriorID, ProveedorAnteriorID, SerieP)
    End Function

    Public Function actualizarProveedorFactura(ByVal FolioNuevo As String, ByVal ProveedorAnteriorID As Integer, ByVal ProveedorID As Integer, ByVal SerieP As String, ByVal NaveID As Integer) As DataTable
        Dim objDA As New CFDIDA
        Return objDA.actualizarProveedorFactura(FolioNuevo, ProveedorAnteriorID, ProveedorID, SerieP, NaveID)
    End Function


End Class
