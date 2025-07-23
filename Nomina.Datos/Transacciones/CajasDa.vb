Public Class CajasDa
    Public Function ConsultadeCajas(ByVal idNave As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim servidorSay As New Persistencia.OperacionesProcedimientos

        Dim Consulta As String
        If Entidades.SesionUsuario.UsuarioSesion.PUsuariosSicy = "OALMA" Then
            Consulta = "SELECT Id_Caja,Nombre FROM CAJCatCajas WHERE Activa = 1 "
        Else
            If servidorSay.Servidor = operaciones.Servidor Then
                Consulta = "SELECT c.Id_Caja,c.Nombre FROM cajcatcajas c INNER JOIN " + servidorSay.NombreDB + ".nomina.usuariocaja uc on c.Id_Caja=uc.usca_cajaid WHERE uc.usca_activo=1 and uc.usca_usuarioid= " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
            Else
                Consulta = "SELECT c.Id_Caja,c.Nombre FROM cajcatcajas c INNER JOIN [" + servidorSay.Servidor + "]." + servidorSay.NombreDB + ".nomina.usuariocaja uc on c.Id_Caja=uc.usca_cajaid WHERE uc.usca_activo=1 and uc.usca_usuarioid= " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
            End If
            Consulta += " AND usca_naveid= " + idNave.ToString
        End If

        Return operaciones.EjecutaConsulta(Consulta)
    End Function

    Public Function SolicitudCajaChica(ByVal IdCaja As Int32, ByVal FormaPago As String, ByVal Cantidad As Double, ByVal Beneficiario As String, _
                                  ByVal Observaciones As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "DECLARE @Mensaje int "
        consulta += "EXEC usp_AltaLiquidacionCajaChica @Mensaje OUTPUT," + IdCaja.ToString + ",'" + FormaPago + "'," + Cantidad.ToString + ",'" + Beneficiario + "','" + Observaciones + "' SELECT @Mensaje"

        SolicitudCajaChica = operaciones.EjecutaConsulta(consulta)


        Return SolicitudCajaChica
    End Function
    Public Function obtenerIdCaja() As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim consulta As String = "SELECT * FROM Nomina.UsuarioCaja WHERE usca_usuarioid = " + idUsuario.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function
    Public Function SolicitudCajaChicaGratificaciones(ByVal IdCaja As Int32, ByVal FormaPago As String, ByVal Cantidad As Double, ByVal Beneficiacio As String, _
                               ByVal Observaciones As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "DECLARE @Mensaje int "
        consulta += "EXEC usp_AltaGratificacionesCajaChica @Mensaje OUTPUT," + IdCaja.ToString + ",'" + FormaPago + "'," + Cantidad.ToString + ",'" + Beneficiacio + "','" + Observaciones + "' SELECT @Mensaje"

        SolicitudCajaChicaGratificaciones = operaciones.EjecutaConsulta(consulta)


        Return SolicitudCajaChicaGratificaciones
    End Function

    Public Function SolicitudPrestamoCajaChica(ByVal IdCaja As Int32, ByVal FormaPago As String, ByVal Cantidad As Double, ByVal Beneficiacio As String,
                                 ByVal Observaciones As String, ByVal PrestamoEspecial As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "DECLARE @Mensaje int "
        consulta += "EXEC usp_AltaPrestamoCajaChica @Mensaje OUTPUT," + IdCaja.ToString + ",'" + FormaPago + "'," + Cantidad.ToString + ",'" + Beneficiacio + "','" + Observaciones + "','" + PrestamoEspecial + "' SELECT @Mensaje"


        SolicitudPrestamoCajaChica = operaciones.EjecutaConsulta(consulta)
        Return SolicitudPrestamoCajaChica
    End Function

    Public Function SolicitudPrestamoCajaChicaPruebas(ByVal IdCaja As Int32, ByVal FormaPago As String, ByVal Cantidad As Double, ByVal Beneficiacio As String, _
                                 ByVal Observaciones As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosPruebas
        Dim consulta As String = "DECLARE @Mensaje int "
        consulta += "EXEC usp_AltaPrestamoCajaChica @Mensaje OUTPUT," + IdCaja.ToString + ",'" + FormaPago + "'," + Cantidad.ToString + ",'" + Beneficiacio + "','" + Observaciones + "' SELECT @Mensaje"

        SolicitudPrestamoCajaChicaPruebas = operaciones.EjecutaConsulta(consulta)
        Return SolicitudPrestamoCajaChicaPruebas
    End Function

    Public Function consultaCajaUsuarioSAY() As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim idCaja As Int32 = 0
        Dim dt As New DataTable
        Dim cadena As String = ""
        If Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString <> "" Then
            cadena = "SELECT usca_cajaid FROM Nomina.UsuarioCaja WHERE usca_activo = 1 AND usca_usuarioid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
            dt = operacion.EjecutaConsulta(cadena)
            If dt.Rows.Count > 0 Then
                idCaja = dt.Rows(0).Item(0)
            End If
        Else
            idCaja = 0
        End If
        Return idCaja
    End Function

    Public Function SolicitudNominaCajaChica(ByVal IdCaja As Int32, ByVal FormaPago As String, ByVal Cantidad As Double, ByVal Beneficiario As String, _
                                 ByVal Observaciones As String, ByVal concepto As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "DECLARE @Mensaje int "
        consulta += "EXEC usp_AltaNominaCajaChica @Mensaje OUTPUT," + IdCaja.ToString + ",'" + FormaPago + "'," + Cantidad.ToString + ",'" + Beneficiario + "','" + Observaciones + "', " + concepto.ToString + " SELECT @Mensaje"

        SolicitudNominaCajaChica = operaciones.EjecutaConsulta(consulta)


        Return SolicitudNominaCajaChica
    End Function
End Class
