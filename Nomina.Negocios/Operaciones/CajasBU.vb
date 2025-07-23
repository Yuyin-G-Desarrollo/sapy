Imports Nomina.Datos

Public Class CajasBU

    Public Function listaCajas(ByVal idNave As Int32) As DataTable
        Dim ObjDA As New Datos.CajasDa
        Return ObjDA.ConsultadeCajas(idNave)
    End Function

    Public Function EnviarSolicitudesCaja(ByVal IdCaja As Int32, ByVal FormaPago As String, ByVal Cantidad As Double, ByVal Beneficiacio As String, _
                                  ByVal Observaciones As String) As DataTable
        Dim ObjDA As New Datos.CajasDa
        Return ObjDA.SolicitudCajaChica(IdCaja, FormaPago, Cantidad, Beneficiacio, Observaciones)
    End Function

    Public Function obtenerIdCaja() As Integer
        Dim ObjDA As New CajasDa
        Dim idCaja As Int32 = 0
        Dim tabla As DataTable
        tabla = ObjDA.obtenerIdCaja
        For Each row As DataRow In tabla.Rows
            idCaja = CInt(row("usca_cajaid"))
        Next
        Return idCaja
    End Function
    Public Function EnviarSolicitudesCajaGratificaciones(ByVal IdCaja As Int32, ByVal FormaPago As String, ByVal Cantidad As Double, ByVal Beneficiacio As String, _
                              ByVal Observaciones As String) As Int32
        Dim ObjDA As New Datos.CajasDa
        Dim idSolicitud As Int32
        Dim tabla As DataTable
        tabla = ObjDA.SolicitudCajaChicaGratificaciones(IdCaja, FormaPago, Cantidad, Beneficiacio, Observaciones)
        For Each row As DataRow In tabla.Rows
            idSolicitud = CInt(row("Column1"))
        Next
        Return idSolicitud
    End Function

    Public Function EnviarSolicitudesPrestamoCaja(ByVal IdCaja As Int32, ByVal FormaPago As String, ByVal Cantidad As Double, ByVal Beneficiacio As String,
                                 ByVal Observaciones As String, ByVal PrestamoEspecial As String) As DataTable
        Dim ObjDA As New Datos.CajasDa
        Return ObjDA.SolicitudPrestamoCajaChica(IdCaja, FormaPago, Cantidad, Beneficiacio, Observaciones, PrestamoEspecial)
    End Function

    Public Function EnviarSolicitudesPrestamoCajaPruebas(ByVal IdCaja As Int32, ByVal FormaPago As String, ByVal Cantidad As Double, ByVal Beneficiacio As String, _
                             ByVal Observaciones As String) As DataTable
        Dim ObjDA As New Datos.CajasDa
        Return ObjDA.SolicitudPrestamoCajaChicaPruebas(IdCaja, FormaPago, Cantidad, Beneficiacio, Observaciones)
    End Function

    Public Function consultaCajaUsuarioSAY() As Int32
        Dim ObjDA As New Datos.CajasDa
        Return ObjDA.consultaCajaUsuarioSAY()
    End Function

    Public Function EnviarSolicitudesCajaNomina(ByVal IdCaja As Int32, ByVal FormaPago As String, ByVal Cantidad As Double, ByVal Beneficiacio As String, _
                                  ByVal Observaciones As String, ByVal concepto As Int32) As DataTable
        Dim ObjDA As New Datos.CajasDa
        Return ObjDA.SolicitudNominaCajaChica(IdCaja, FormaPago, Cantidad, Beneficiacio, Observaciones, concepto)
    End Function
End Class
