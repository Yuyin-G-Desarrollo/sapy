Imports System.Data.SqlClient
Public Class AutorizacionPrestamoDA

    Public Function NavesColaborador(ByVal idColaborador As Int32) As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " select nave_naveid, nave_nombre  "
        consulta += " from Framework.Naves "
        consulta += " left join Prestamos.ConfiguracionPrestamos on cpre_naveid=nave_naveid "
        consulta += " where nave_naveid in (select naus_naveid from Framework.NavesUsuario where naus_usuarioid=" + idColaborador.ToString + ") AND nave_activo=1"

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function


    Public Function ListaNaves(ByVal idNave As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " nave_naveid, cpre_configuracionprestamoid, nave_nombre,  cpre_autorizaciongerente, cpre_autorizaciondirector, cpre_interes, cpre_montomaximonave, cpre_montomaximocolaborador, cpre_semanasmaximo  "
        consulta += " from Framework.Naves "
        consulta += " left join Prestamos.ConfiguracionPrestamos on cpre_naveid=nave_naveid "
        consulta += " where nave_naveid in (select naus_naveid from Framework.NavesUsuario where naus_usuarioid=" + idNave.ToString + ") AND nave_activo=1"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function


    Public Function ListaPrestamos(ByVal idNave As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "    SELECT * FROM Prestamos.Prestamos AS A"
        consulta += " JOIN Nomina.Colaborador as B on A.pres_colaboradorid=codr_colaboradorid "
        consulta += " JOIN Nomina.ColaboradorLaboral as C on B.codr_colaboradorid=C.labo_colaboradorid"
        consulta += " where labo_naveid=" + idNave.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function



    Public Sub AutorizacionDirectorGuardar(ByVal AutorizacionPrestamos As Entidades.AutorizacionPrestamo)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "pres_prestamoid"
        parametro.Value = AutorizacionPrestamos.PprestamoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_gerenteid"
        parametro.Value = AutorizacionPrestamos.PgerenteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_estatus"
        parametro.Value = AutorizacionPrestamos.Pestatus
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Prestamos.SP_Actualizar_PrestamoAutorizacionGerente", listaParametros)
    End Sub










End Class
