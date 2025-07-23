Imports Produccion.Datos

Public Class ProduccionBU

    Public Sub AltaCortador(ByVal cortador As Entidades.CortadoresPielForro)
        Dim OBJDA As New ProduccionDA
        OBJDA.AltaCortador(cortador)
    End Sub

    Public Sub ModificaCortador(ByVal cortador As Entidades.CortadoresPielForro)
        Dim OBJDA As New ProduccionDA
        OBJDA.ModificaCortador(cortador)
    End Sub

    Public Sub AltaLotesAvancesEmpleadosDepto(ByVal LotesAvancesEmpleadosDepto As Entidades.LotesAvancesEmpleadosDepto)
        Dim OBJDA As New ProduccionDA
        OBJDA.altaLotesAvancesEmpleadosDepto(LotesAvancesEmpleadosDepto)
    End Sub

    Public Sub ModificaLotesAvancesEmpleadosDepto(ByVal LotesAvancesEmpleadosDepto As Entidades.LotesAvancesEmpleadosDepto)
        Dim OBJDA As New ProduccionDA
        OBJDA.ModificaLotesAvancesEmpleadosDepto(LotesAvancesEmpleadosDepto)
    End Sub

    Public Function listaColaboradores(ByVal nave As Integer) As DataTable
        Dim obj As New ProduccionDA
        Return obj.listaColaboradores(nave)
    End Function

    Public Function listaColaboradoresSicy(ByVal nave As Integer) As DataTable
        Dim obj As New ProduccionDA
        Return obj.listaColaboradoresSicy(nave)
    End Function

    Public Function listaColaboradoresSAY(ByVal nave As Integer, ByVal Estatus As Integer) As DataTable
        Dim obj As New ProduccionDA
        Return obj.listaColaboradoresSAY(nave, Estatus)
    End Function

    Public Function buscarIdSicy(ByVal colaborador As String) As DataTable
        Dim obj As New ProduccionDA
        Return obj.buscarIdSicy(colaborador)
    End Function

    Public Function ListadoParametroMarcas() As DataTable
        Dim objDA As New ProduccionDA
        Dim tabla As New DataTable
        tabla = objDA.listadoParametroMarcas()

        Return tabla

    End Function

    Public Function ListadoParametroNaves(tipo_Nave As Integer, IdUsuario As Integer) As DataTable
        Dim objDA As New ProduccionDA
        Dim tabla As New DataTable
        tabla = objDA.listadoParametroNaves(tipo_Nave, IdUsuario)

        Return tabla

    End Function

    Public Function listadoParametroColecciones() As DataTable
        Dim objDA As New ProduccionDA
        Dim tabla As New DataTable
        tabla = objDA.listadoParametroColecciones()

        Return tabla
    End Function
    Public Function listadoParametroEstatus() As DataTable
        Dim objDA As New ProduccionDA
        Dim tabla As New DataTable
        tabla = objDA.listadoParametroEstatus()

        Return tabla
    End Function


    Public Function listaDepartamentos(ByVal nave As Integer) As DataTable
        Dim obj As New ProduccionDA
        Return obj.listaDepartamentos(nave)
    End Function

    'Public Function listaDepartamentosAvance() As DataTable
    '    Dim obj As New ProduccionDA
    '    Return obj.listaDepartamentosAvance()
    'End Function

    Public Function ConsultaCortadores(ByVal nave As Integer, ByVal tipo As Integer, ByVal estatus As Integer) As DataTable
        Dim obj As New ProduccionDA
        Return obj.ConsultaCortadores(nave, tipo, estatus)
    End Function

    Public Function buscarCortadorRepetido(ByVal id As Integer, ByVal tipo As Integer) As DataTable
        Dim obj As New ProduccionDA
        Return obj.buscarCortadorRepetido(id, tipo)
    End Function

    Public Function idNaveSay(ByVal nave As String) As DataTable
        Dim obj As New ProduccionDA
        Return obj.idNaveSay(nave)
    End Function

    Public Function BuscarRegistrosRepetidosAvancesDeProduccion(ByVal empleado As Integer, ByVal idConfiguracion As Integer) As DataTable
        Dim obj As New ProduccionDA
        Return obj.BuscarRegistrosRepetidosAvancesDeProduccion(empleado, idConfiguracion)
    End Function

    Public Function listarFracciones()
        Dim obj As New ProduccionDA
        Return obj.listarFracciones()
    End Function

    Public Function DestajosFraccionesPuesto(ByVal FracXPuesto As Entidades.FraccionesPorPuesto) As DataTable
        Dim objD As New ProduccionDA
        Return objD.DestajosFraccionesPuesto(FracXPuesto)
    End Function

    Public Function DestajosFraccionesPorPuestoPorNave(ByVal NaveSay As Integer) As DataTable
        Dim objD As New ProduccionDA
        Return objD.DestajosFraccionesPorPuestoPorNave(NaveSay)
    End Function

    Public Function DepartamentosPorNave(ByVal IdNave As Integer) As DataTable
        Dim objD As New ProduccionDA
        Return objD.DepartamentosPorNave(IdNave)
    End Function

    Public Function FraccionesDeptoAvance(ByVal FracDeptoAvance As Entidades.FraccionesPorPuesto) As DataTable
        Dim objD As New ProduccionDA
        Return objD.FraccionesDeptoAvance(FracDeptoAvance)
    End Function

    Public Function Consulta_FraccionesDeptoAvanceXNave(ByVal IdNaveSICY As Integer, ByVal estatus As Boolean) As DataTable
        Dim objD As New ProduccionDA
        Return objD.Consulta_FraccionesDeptoAvanceXNave(IdNaveSICY, estatus)
    End Function

    Public Function Ediar_FraccionesDeptoAvanceXNave(ByVal FracDeptoAvance As Entidades.FraccionesPorPuesto) As DataTable
        Dim objD As New ProduccionDA
        Return objD.Ediar_FraccionesDeptoAvanceXNave(FracDeptoAvance)
    End Function

    Public Function listarFraccionesAvanceDepto(ByVal IdNave As Integer) As DataTable
        Dim objD As New ProduccionDA
        Return objD.listarFraccionesAvanceDepto(IdNave)
    End Function

    Public Function DestajosFraccionesPuesto_editar(ByVal FracXPuesto As Entidades.FraccionesPorPuesto, ByVal accion As Integer) As DataTable
        Dim objD As New ProduccionDA
        Return objD.DestajosFraccionesPuesto_Editar(FracXPuesto, accion)
    End Function

    Public Function listaFraccionesIncremento()
        Dim obj As New ProduccionDA
        Return obj.listaFraccionesIncremento()
    End Function

    Public Function GuardarIncrementofracciones(ByVal listaFracciones As String, ByVal idnave As Integer, ByVal usuario As String, ByVal porcentajeAplicado As Double)
        Dim obj As New ProduccionDA
        Return obj.GuardarIncrementofracciones(listaFracciones, idnave, usuario, porcentajeAplicado)
    End Function

    Public Function ConsultaHistorialIncrementoFracciones(ByVal naveid As Integer)
        Dim obj As New ProduccionDA
        Return obj.ConsultaHistorialIncrementoFracciones(naveid)
    End Function

End Class
