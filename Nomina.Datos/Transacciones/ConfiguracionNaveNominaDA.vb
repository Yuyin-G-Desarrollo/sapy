Imports System.Data.SqlClient

Public Class ConfiguracionNaveNominaDA


    Public Function buscarConfiguraciondeNave(ByVal NaveId As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "select * from Nomina.ConfiguracionNaveNomina where conf_naveid=" + NaveId.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function ListaConfiguracionNaves() As DataTable
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Consulta = "select * from Framework.Naves  as b join Framework.NavesUsuario as c on (b.nave_naveid = naus_naveid)"
        Consulta += " left join Nomina.ConfiguracionNaveNomina on"
        Consulta += " (nave_naveid = conf_naveid)  where naus_usuarioid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        Return ObjPersistencia.EjecutaConsulta(Consulta)
    End Function

    Public Function ListaConfiguracionNavesFiniquito(ByVal Naveid As Int32) As DataTable
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Consulta = "select * from Framework.Naves  as b join Framework.NavesUsuario as c on (b.nave_naveid = naus_naveid)"
        Consulta += " left join Nomina.ConfiguracionNaveNomina on"
        Consulta += " (nave_naveid = conf_naveid)  where naus_usuarioid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + " and conf_naveid=" + Naveid.ToString
        Return ObjPersistencia.EjecutaConsulta(Consulta)
    End Function


    Public Sub InsertarConfiguracionNave(ByVal DiasGratificacion As Int32, ByVal AutorizaGerente As Boolean, _
                                              ByVal AutorizaDirector As Boolean, ByVal DiasAguinaldo As Int32, ByVal NaveId As Int32, ByVal Vacaciones As Int32)
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Dim Director, Gerente As Int32
        If AutorizaDirector = True Then
            Director = 1
        Else
            Director = 0
        End If
        If AutorizaGerente = True Then
            Gerente = 1
        Else
            Gerente = 0
        End If
        Consulta = "insert into Nomina.ConfiguracionNaveNomina(conf_naveid, conf_diasaguinaldo,conf_diasvacaciones, conf_finiquitodiasgratificacion, conf_usuariocreoid, conf_fechacreacion, "
        Consulta += "conf_autorizagerente, conf_autorizadirector) values ("
        Consulta += NaveId.ToString + "," + DiasAguinaldo.ToString + "," + Vacaciones.ToString + "," + DiasGratificacion.ToString + "," + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ", (select getdate())," + Gerente.ToString + "," + Director.ToString + ")"
        ObjPersistencia.EjecutaConsulta(Consulta)
    End Sub

    Public Sub UpdateConfiguracionNave(ByVal DiasGratificacion As Int32, ByVal AutorizaGerente As Boolean, _
                                              ByVal AutorizaDirector As Boolean, ByVal DiasAguinaldo As Int32, ByVal IDConfiguracion As Int32, ByVal Vacaciones As Int32)
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Dim Director, Gerente As Int32
        If AutorizaDirector = True Then
            Director = 1
        Else
            Director = 0
        End If
        If AutorizaGerente = True Then
            Gerente = 1
        Else
            Gerente = 0
        End If
        Consulta = "update Nomina.ConfiguracionNaveNomina set conf_diasaguinaldo=" + DiasAguinaldo.ToString + ", conf_finiquitodiasgratificacion=" + DiasGratificacion.ToString + ", conf_usuariomodificoid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ", conf_fechamodificacion= (select getdate()), "
        Consulta += "conf_autorizagerente=" + Gerente.ToString + ", conf_autorizadirector=" + Director.ToString + ", conf_diasvacaciones=" + Vacaciones.ToString + " where conf_nominanave=" + IDConfiguracion.ToString
        ObjPersistencia.EjecutaConsulta(Consulta)
    End Sub

    ''Metodos para formulario configuracion de solicitudes nomina
    Public Function ConfiguracionSolicitudFinanzasNomina() As DataTable
        'Dim consulta As String = ""
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        'consulta = "SELECT * FROM"
        'consulta += " (SELECT pnom_NaveId, n.nave_nombre,p.pnom_FechaInicial, pnom_FechaInicial as inicial, pnom_FechaFinal, isnull(p.pnom_TipoSolicitud, '') tipoPago , 0 efectivo,0 cheque, YEAR( pnom_FechaInicial) anioNomina, YEAR(GETDATE()) anioActual,pnom_PeriodoNomId, pnom_beneficiario as beneficiario,ISNULL( cast( pnom_fechaConfNomina as varchar(50)), '') as fecha"
        'consulta += "  FROM Nomina.PeriodosNomina p INNER JOIN Framework.Naves n on	p.pnom_NaveId=n.nave_naveid"
        'consulta += " WHERE pnom_NoSemanaNomina= " + Semana.ToString + ")  cons WHERE cons.anioNomina = cons.anioActual ORDER BY cons.nave_nombre ASC, pnom_FechaInicial DESC"
        'Return objPersistencia.EjecutaConsulta(consulta)

        'Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        'parametro.ParameterName = "semana"
        'parametro.Value = Semana
        'listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Nomina.SP_ConsultaPeriodosConfNomina", listaParametros)

    End Function

    Public Function ActualizaConfiguracionSolicitudes(ByVal idperiodo As Int32, ByVal tipoSolicitud As String, ByVal idNave As Int32, ByVal beneficiario As String, ByVal usuarioModifica As Integer) As DataTable
        ''Dim Consulta As String = ""
        'Consulta = "UPDATE Nomina.PeriodosNomina SET pnom_TipoSolicitud='" + tipoSolicitud.ToString + "' , pnom_beneficiario='" + beneficiario.ToString + "' , pnom_fechaConfNomina= getdate() WHERE pnom_PeriodoNomId >= " + idperiodo.ToString + " and pnom_NaveId =" + idNave.ToString
        'objPeristencia.EjecutaConsulta(Consulta)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@PeriodoID"
        parametro.Value = idperiodo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoSolicitud"
        parametro.Value = tipoSolicitud
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveID"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Beneficiario"
        parametro.Value = beneficiario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioModifica"
        parametro.Value = usuarioModifica
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_ActualizaConfiguracionSolicitudes_Nomina]", listaParametros)

    End Function

    Public Function obtenerConfiguracionNomina(ByVal idPeriodo As Int32) As DataTable
        Dim consulta As String = ""
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        consulta = "SELECT  pnom_TipoSolicitud,pnom_beneficiario as beneficiario FROM Nomina.PeriodosNomina WHERE pnom_PeriodoNomId= " + idPeriodo.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerIdBeneficiario(ByVal idCaja As Int32, ByVal beneficiario As String) As DataTable
        Dim consulta As String = ""
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        consulta = "SELECT Id_Persona, Nombre From CAJPersonas WHERE  (Activo = 1) AND (Id_Persona IN (SELECT DISTINCT Id_Persona From CAJRelacionP_TP WHERE (Id_TipoP IN "
        consulta += " (SELECT Id_TipoP From CAJTipoPersonas WHERE (Tipo = 'Beneficiario'))) AND (Id_Caja = " + idCaja.ToString + ") AND (Movimiento = 'S') AND (Activo = 1)) and Nombre LIKE '% " + beneficiario.ToString + "%') ORDER BY Nombre "
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function comboRazonSocialCajaChica(ByVal idCaja As Int32) As DataTable
        Dim consulta As String = ""
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        consulta = " SELECT DISTINCT	dv.IdDocumento,	dv.RazonSocial FROM cuentasbancarias cb"
        consulta += " INNER JOIN bancos b	ON cb.idbanco = b.idbanco LEFT JOIN doctosventas dv	ON dv.iddocumento = cb.iddocumento"
        consulta += " INNER JOIN CajCuentas c	ON c.Cuenta = cb.IdCuenta WHERE (CB.Estatus = 'S')"
        consulta += " AND (CB.cxp = 1) AND (cb.Tipo = 1) AND gEscritorio LIKE '%" + idCaja.ToString + "%' ORDER BY dv.IdDocumento"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Sub actualizarIdSolicitudesCajaChica(ByVal idPeriodo As Int32, ByVal idEfectivo As Int32, ByVal idCheque As Int32, ByVal idDeduccion As Int32)
        Dim consulta As String = ""
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        consulta = " UPDATE Nomina.PeriodosNomina SET pnom_EfectivoCajaid= " + idEfectivo.ToString + " , pnom_ChequeCajaId= " + idCheque.ToString + " "
        consulta += "  ,pnom_DeduccionesCajaId= " + idDeduccion.ToString + " where pnom_PeriodoNomId=" + idPeriodo.ToString
        objPersistencia.EjecutaConsulta(consulta)
    End Sub

    Public Function obtenerSemanaActualConfiguracionNomina() As DataTable
        'Dim consulta As String = ""
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        'consulta = " select pnom_NoSemanaNomina, count(pnom_NoSemanaNomina) maximo, ISNULL( cast( pnom_fechaConfNomina as varchar(50)), '') as fecha from Nomina.PeriodosNomina WHERE pnom_stPeriodoNomina='A'"
        'consulta += " group by pnom_NoSemanaNomina,pnom_fechaConfNomina"
        ''consulta += " having count(pnom_NoSemanaNomina) = "
        ''consulta += " (select max(cons.total) from (select count(pnom_NoSemanaNomina) as total from Nomina.PeriodosNomina  WHERE pnom_stPeriodoNomina='A'"
        ''consulta += " group by pnom_NoSemanaNomina) cons  )"
        'Return objPersistencia.EjecutaConsulta(consulta)
        '23052019 Se cambia consulta a SP

        Return objPersistencia.EjecutaConsulta("EXEC Nomina.SP_ObtieneSemanaActualConfNomina")

    End Function

    Public Function ValidaUtilidadesNave(ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveID"
        parametro.Value = NaveID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_Finiquitos_ValidaUtilidadNave]", listaParametros)

    End Function

End Class
