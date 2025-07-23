Imports Persistencia
Imports System.Data.SqlClient

Public Class CorteChecadorDA


    Public Sub guardarCorteChecador(ByVal corteChecador As Entidades.CorteChecador, ByVal faltasNuevoIngreso As Double)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@periodo_id AS INTEGER,
        '@colaborador_id AS INTEGER,
        '@puntualidad_asistencia AS BIT,
        '@caja_ahorro AS BIT,
        '@retardo_menor AS INTEGER,
        '@retardo_mayor AS INTEGER,
        '@inasistencia AS INTEGER,
        '@usuario as INTEGER

        Dim parametro As New SqlParameter
        parametro.ParameterName = "periodo_id"
        parametro.Value = corteChecador.PPeriodo.PeriodoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaborador_id"
        parametro.Value = corteChecador.PColaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "puntualidad_asistencia"
        parametro.Value = corteChecador.PPpuntualidad_asistencia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "caja_ahorro"
        parametro.Value = corteChecador.PCaja_Ahorro
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "asistencia"
        parametro.Value = corteChecador.PAsistencia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "retardo_menor"
        parametro.Value = corteChecador.PRetardo_menor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "retardo_mayor"
        parametro.Value = corteChecador.PRetardo_mayor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inasistencia"
        parametro.Value = corteChecador.PInasistencia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "faltasNuevoIngreso"
        parametro.Value = faltasNuevoIngreso
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("ControlAsistencia.SP_Alta_Corte_Checador", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub
    

    Public Function consultar_ResumenCorteChecador(ByVal PeriodoNomID As Integer, ByVal colaboradorID As Integer, ByVal resultado As Integer, ByVal bandera As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@PeriodoNomID AS INTEGER,
        '@departamentoID AS INTEGER,
        '@colaboradorID AS INTEGER,
        '@resultado AS INTEGER

        Dim parametro As New SqlParameter
        parametro.ParameterName = "PeriodoNomID"
        parametro.Value = PeriodoNomID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorID"
        parametro.Value = colaboradorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "resultado"
        parametro.Value = resultado
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("ControlAsistencia.SP_Consulta_Resumen_Corte_Checador", listaParametros)

    End Function

    Public Function Consultar_Incentivos_Registro_Excepcion(ByVal PeriodoNomID As Integer, ByVal colaboradorID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@PeriodoNomID AS INTEGER,
        '@departamentoID AS INTEGER,
        '@colaboradorID AS INTEGER,
        '@resultado AS INTEGER

        Dim parametro As New SqlParameter
        parametro.ParameterName = "PeriodoNomID"
        parametro.Value = PeriodoNomID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorID"
        parametro.Value = colaboradorID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("ControlAsistencia.SP_Consultar_Incentivos_Registro_Excepcion", listaParametros)

    End Function

End Class
