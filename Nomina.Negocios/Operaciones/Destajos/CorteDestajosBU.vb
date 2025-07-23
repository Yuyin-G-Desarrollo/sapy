Public Class CorteDestajosBU
    Public Function DepartamentosSegunPermiso(ByVal NaveID As Integer, ByVal Montado As Boolean, ByVal Adorno As Boolean, ByVal Pespunte As Boolean, ByVal corte As Boolean, ByVal plantilla As Boolean, ByVal Todo As Boolean) As DataTable

        Dim objDA As New Datos.CorteDestajosDA
        Return objDA.DepartamentosSegunPermiso(NaveID, Montado, Adorno, Pespunte, corte, plantilla, Todo)

    End Function


    'Public Function ListaColaboradoresDestajos(ByVal PeriodoNominaID As Integer, ByVal NaveID As Integer, ByVal DepartamentoID As Integer, ByVal CelulaID As Integer) As List(Of Entidades.CorteDestajos)
    '    Dim ObjDA As New Nomina.Datos.CorteDestajosDA
    '    Dim ObjENT As New Entidades.CorteDestajos
    '    Dim Tabla As DataTable
    '    ListaColaboradoresDestajos = New List(Of Entidades.CorteDestajos)
    '    Tabla = ObjDA.ListaColaboradoresDestajos(PeriodoNominaID, NaveID, DepartamentoID, CelulaID)

    '    For Each fila As DataRow In Tabla.Rows
    '        Dim CorteDestajos As New Entidades.CorteDestajos
    '        Dim Colaborador As New Entidades.Colaborador

    '        Colaborador.PNombre = fila("codr_nombre")
    '        Colaborador.PApaterno = fila("codr_apellidopaterno")
    '        Colaborador.PAmaterno = fila("codr_apellidomaterno")
    '        Colaborador.PColaboradorid = fila("codr_colaboradorid")
    '        '   CorteDestajos.pFaltas = fila("ccheck_inasistencia")
    '        CorteDestajos.PRealCantidad = fila("real_cantidad")
    '        ' CorteDestajos.PTotalDestajos = fila("Total")
    '        ' CorteDestajos.PFechaTicket = fila("dest_fecha")


    '        CorteDestajos.PColaborador = Colaborador
    '        ListaColaboradoresDestajos.Add(CorteDestajos)
    '    Next
    '    Return ListaColaboradoresDestajos
    'End Function

    Public Function consultarDestajoAbierto(ByVal periodoNominaID As Integer, ByVal NaveID As Integer, ByVal DepartamentoID As Integer, ByVal CelulaID As Integer) As DataTable
        Dim objDa As New Datos.CorteDestajosDA
        Return objDa.consultarDestajoAbierto(periodoNominaID, NaveID, DepartamentoID, CelulaID)
    End Function

    'Public Function totalDestajosPorColaborador(ByVal colaboradorID As Integer, ByVal periodoNominaID As Integer) As DataTable
    '    Dim objDA As New Datos.CorteDestajosDA
    '    Return objDA.totalDestajosPorColaborador(colaboradorID, periodoNominaID)
    'End Function

    'Public Function Inasistencias(ByVal colaboradorID As Integer, ByVal periodoNominaID As Integer) As Double
    '    Dim objDa As New Datos.CorteDestajosDA
    '    Dim inasistencia As Double = 0
    '    Dim tabla As DataTable

    '    tabla = objDa.Inasistencias(colaboradorID, periodoNominaID)
    '    For Each row As DataRow In tabla.Rows
    '        Dim corteDestajos As New Entidades.CorteDestajos
    '        inasistencia = row("ccheck_inasistencia")
    '    Next
    '    Return inasistencia
    'End Function

    'Public Function consultarCierre(ByVal PeriodoNominaID As Integer, ByVal NaveID As Integer, ByVal DepartamentoID As Integer, ByVal CelulaID As Integer) As List(Of Entidades.CorteDestajos)
    '    Dim objDA As New Datos.CorteDestajosDA
    '    Dim objEnt As New Entidades.CorteDestajos
    '    Dim tabla As DataTable
    '    tabla = objDA.consultarCierre(PeriodoNominaID, NaveID, DepartamentoID, CelulaID)
    '    consultarCierre = New List(Of Entidades.CorteDestajos)

    '    For Each row As DataRow In tabla.Rows
    '        Dim corteDestajos As New Entidades.CorteDestajos
    '        Dim colaborador As New Entidades.Colaborador
    '        colaborador.PNombre = row("codr_nombre")
    '        colaborador.PApaterno = row("codr_apellidopaterno")
    '        colaborador.PAmaterno = row("codr_apellidomaterno")
    '        colaborador.PColaboradorid = row("codr_colaboradorid")
    '        corteDestajos.PRealCantidad = row("dest_salariobase")
    '        corteDestajos.PajusteDestajo = row("dest_ajuste")
    '        corteDestajos.PTotalDestajos = row("dest_acumulado")
    '        corteDestajos.PTotalPagar = row("dest_totalpagar")
    '        corteDestajos.PColaborador = colaborador
    '        consultarCierre.Add(corteDestajos)
    '    Next

    '    Return consultarCierre
    'End Function

    Public Function consultarCierreDestajo(ByVal PeriodoNominaID As Integer, ByVal NaveID As Integer, ByVal DepartamentoID As Integer, ByVal CelulaID As Integer) As DataTable
        Dim objDA As New Datos.CorteDestajosDA
        Return objDA.consultarCierreDestajo(PeriodoNominaID, NaveID, DepartamentoID, CelulaID)
    End Function

    Public Sub cierreDestajos(ByVal destajos As Entidades.CorteDestajos)
        Dim objDA As New Datos.CorteDestajosDA
        objDA.cierreDestajos(destajos)
    End Sub

#Region "Asignación de fracciones"
    ''' <summary>
    ''' Busca los departamentos de una nave donde hay colaboradores que registran tickets
    ''' </summary>
    ''' <param name="naveId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DepartamentosConDestajos(ByVal naveId As Integer) As DataTable
        Dim obj As New Nomina.Datos.CorteDestajosDA
        Dim tabla As New DataTable
        tabla = obj.DepartamentosConDestajos(naveId)
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        Return tabla
    End Function

    ''' <summary>
    ''' Busca todas las fracciones de una nave
    ''' </summary>
    ''' <param name="naveId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FraccionesNave(ByVal naveId As Integer) As DataTable
        Dim obj As New Nomina.Datos.CorteDestajosDA
        Return obj.FraccionesNave(naveId)
    End Function

    ''' <summary>
    ''' Busca todas las fracciones de una nave
    ''' </summary>
    ''' <param name="naveId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FraccionesNaveAsignadas(ByVal naveId As Integer, ByVal departamentoid As Integer) As DataTable
        Dim obj As New Nomina.Datos.CorteDestajosDA
        Return obj.FraccionesNaveAsignadas(naveId, departamentoid)
    End Function

    ''' <summary>
    ''' Lista las fracciones de la nave que no han sido asignadas a ningun departamento
    ''' </summary>
    ''' <param name="naveId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FraccionesNaveSinAsignar(ByVal naveId As Integer) As DataTable
        Dim obj As New Nomina.Datos.CorteDestajosDA
        Return obj.FraccionesNaveSinAsignar(naveId)
    End Function

    ''' <summary>
    ''' Muestra las fracciones asignadas más las fracciones sin asignar
    ''' </summary>
    ''' <param name="naveId"></param>
    ''' <param name="departamentoid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FraccionesNaveEditar(ByVal naveId As Integer, ByVal departamentoid As Integer) As DataTable
        Dim obj As New Nomina.Datos.CorteDestajosDA
        Return obj.FraccionesNaveEditar(naveId, departamentoid)
    End Function


    ''' <summary>
    ''' Guarda las fracciones asignadas al departamento
    ''' </summary>
    ''' <param name="naveId"></param>
    ''' <param name="departamentoid"></param>
    ''' <param name="fracciones"></param>
    ''' <remarks></remarks>
    Public Sub guardarAsignacionFracciones(ByVal naveId As Integer, ByVal departamentoid As Integer, ByVal fracciones As String, ByVal restaurar As Integer)
        Dim obj As New Nomina.Datos.CorteDestajosDA
        obj.guardarAsignacionFracciones(naveId, departamentoid, fracciones, restaurar)
    End Sub

#End Region

End Class
