Imports System.Data.SqlClient

Public Class ConfiguracionPrestamosDA

    Public Function ListaNaves(ByVal idUsuario As Int32, ByVal Naves As Boolean) As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        If Naves = True Then
            consulta += " select nave_naveid, cpre_configuracionprestamoid, nave_nombre, cpre_interessobresaldo, cpre_interesfijo, cpre_sininteres, cpre_autorizaciongerente, cpre_autorizaciondirector, cpre_interes, cpre_montomaximonave, cpre_montomaximocolaborador, cpre_semanasmaximo "
            consulta += " from Framework.Naves"
            consulta += " left join Prestamos.ConfiguracionPrestamos on cpre_naveid=nave_naveid "
            consulta += " where  nave_activo='True'"
        Else
            consulta += " select nave_naveid, cpre_configuracionprestamoid, nave_nombre, cpre_interessobresaldo, cpre_interesfijo, cpre_sininteres, cpre_autorizaciongerente, cpre_autorizaciondirector, cpre_interes, cpre_montomaximonave, cpre_montomaximocolaborador, cpre_semanasmaximo from Framework.Naves "
            consulta += " left join Prestamos.ConfiguracionPrestamos on cpre_naveid=nave_naveid "
            consulta += " where nave_naveid in (select naus_naveid from Framework.NavesUsuario where naus_usuarioid=" + idUsuario.ToString + ") AND nave_activo='True' "
        End If

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub ConfiguracionPrestamoGuardar(ByVal SolicitudPrestamos As Entidades.ConfiguracionPrestamos)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "cpre_naveid"
        parametro.Value = SolicitudPrestamos.PNaves.PNaveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cpre_interessobresaldo"
        parametro.Value = SolicitudPrestamos.PInteresSobreSaldo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cpre_interesfijo"
        parametro.Value = SolicitudPrestamos.PInteresFijo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cpre_sininteres"
        parametro.Value = SolicitudPrestamos.PSinInteres
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cpre_autorizaciongerente"
        parametro.Value = SolicitudPrestamos.PAutorizacionGerente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cpre_autorizaciondirector"
        parametro.Value = SolicitudPrestamos.PAutorizacionDirector
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cpre_interes"
        parametro.Value = SolicitudPrestamos.PInteres
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cpre_montomaximonave"
        parametro.Value = SolicitudPrestamos.PMontoMaximoPorNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cpre_montomaximocolaborador"
        parametro.Value = SolicitudPrestamos.PMontoMaximoPorColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cpre_semanasmaximo"
        parametro.Value = SolicitudPrestamos.PSemanasMaximo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cpre_usuariocreoid"
        parametro.Value = SolicitudPrestamos.PUsuarioCreo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cpre_configuracionprestamoid"
        parametro.Value = SolicitudPrestamos.PConfiguracionPrestamoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cpre_usuariomodificoid"
        parametro.Value = SolicitudPrestamos.PUsuarioModifico
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Prestamos.SP_Guardar_ConfiguracionPrestamo", listaParametros)
    End Sub
End Class
