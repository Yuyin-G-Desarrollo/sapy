Imports System.Data.SqlClient

Public Class ConfiguracionCajaNaveDA

    Public Sub Altas(objConfiguracionCajaNave As Entidades.ConfiguracionCajaNave)

        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametros As New List(Of SqlParameter)

        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@CajaAhorroId"
        parametro.Value = objConfiguracionCajaNave.pCajaAhorro.pCajaAhorroId
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@SemanaInicial"
        parametro.Value = objConfiguracionCajaNave.pSemanaInicial
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@SemanaFinal"
        parametro.Value = objConfiguracionCajaNave.pSemanaFinal
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Interes"
        parametro.Value = objConfiguracionCajaNave.pInteres
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuariocreo"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        parametros.Add(parametro)

        Operaciones.EjecutarSentenciaSP("[CajaAhorro].[SP_altas_ConfiguracionCajaNave]", parametros)

    End Sub


    Public Sub Editar(objConfiguracionCajaNave As Entidades.ConfiguracionCajaNave)

        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametros As New List(Of SqlParameter)

        Dim parametro As SqlParameter


        parametro = New SqlParameter
        parametro.ParameterName = "@ccnId"
        parametro.Value = objConfiguracionCajaNave.pccnId
        parametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@CajaAhorroId"
        parametro.Value = objConfiguracionCajaNave.pCajaAhorro.pCajaAhorroId
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@SemanaInicial"
        parametro.Value = objConfiguracionCajaNave.pSemanaInicial
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@SemanaFinal"
        parametro.Value = objConfiguracionCajaNave.pSemanaFinal
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Interes"
        parametro.Value = objConfiguracionCajaNave.pInteres
        parametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@usuariomodifico"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        parametros.Add(parametro)


        Operaciones.EjecutarSentenciaSP("[CajaAhorro].[SP_editar_ConfiguracionCajaNave]", parametros)


    End Sub

    Public Sub Eliminar(objConfiguracionCajaNave As Entidades.ConfiguracionCajaNave)

        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametros As New List(Of SqlParameter)

        Dim parametro As SqlParameter



        parametro = New SqlParameter
        parametro.ParameterName = "@ccnId"
        parametro.Value = objConfiguracionCajaNave.pccnId
        parametros.Add(parametro)



        Operaciones.EjecutarSentenciaSP("[CajaAhorro].[SP_Eliminar_ConfiguracionCajaNave]", parametros)


    End Sub


    Public Function ObtenerConfiguracionCajaNave(ByVal IdConfiguracionCajaNave As Int32) As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        ObtenerConfiguracionCajaNave = New DataTable

        'consulta = "SELECT * FROM cajaahorro.ColaboradorPeriodoCaja where cocn_ccnId= " & IdConfiguracionCajaNave.ToString
        consulta = "SELECT * FROM cajaahorro.ConfiguracionCajaNave where cocn_ccnId= " & IdConfiguracionCajaNave.ToString

        ObtenerConfiguracionCajaNave = Operaciones.EjecutaConsulta(consulta)

    End Function


    Public Function Listar(idCajaAhorro As Int32) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = vbEmpty


        consulta = "SELECT ca.* from cajaahorro.ConfiguracionCajaNave CA where CA.cocn_CajaAhorroId= " & idCajaAhorro.ToString

        Listar = New DataTable
        Listar = operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListarConfiguracionAnterior(idCajaAhorro As Int32) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = vbEmpty

        consulta = "SELECT ca.* from cajaahorro.ConfiguracionCajaNave CA where CA.cocn_CajaAhorroId in ( "
        consulta += "SELECT TOP 1 caja_cajaahorroid "
        consulta += "FROM cajaahorro.cajaahorro "
        consulta += "where caja_naveid IN ( "
        consulta += "SELECT caja_naveid "
        consulta += "FROM cajaahorro.cajaahorro "
        consulta += "where caja_cajaahorroid=" + idCajaAhorro.ToString + ") AND caja_cajaahorroid<>" + idCajaAhorro.ToString + " AND caja_cajaahorroid IN (SELECT cocn_cajaahorroid FROM cajaahorro.configuracioncajanave group BY cocn_cajaahorroid) "
        consulta += "ORDER BY caja_cajaahorroid DESC )"

        ListarConfiguracionAnterior = New DataTable
        ListarConfiguracionAnterior = operaciones.EjecutaConsulta(consulta)

    End Function

End Class
