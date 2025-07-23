Imports System.Data.SqlClient

Public Class CorteDestajosDA

    Public Function DepartamentoSegunColaborador(ByVal ColaboradorID As Integer, ByVal NaveID As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim consulta As String = ""
        consulta += " SELECT * FROM Framework.Grupos as A"
        consulta += " JOIN Nomina.ColaboradorLaboral as B on A.grup_grupoid=B.labo_departamentoid"
        consulta += " where B.labo_colaboradorid=" + ColaboradorID.ToString
        consulta += " and grup_naveid=" + NaveID.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    'Public Function ListaColaboradoresDestajos(ByVal PeriodoNominaID As Integer, ByVal NaveID As Integer, ByVal DepartamentoID As Integer, ByVal CelulaID As Integer)

    '    Dim Operaciones As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String = ""
    '    consulta += " SELECT"
    '    consulta += "         A.codr_colaboradorid,"
    '    consulta += " A.codr_nombre,"
    '    consulta += " A.codr_apellidopaterno,"
    '    consulta += " A.codr_apellidomaterno,"
    '    consulta += " D.real_cantidad"
    '    'consulta += " E.ccheck_inasistencia"
    '    consulta += " FROM nomina.Colaborador AS A"
    '    consulta += " JOIN Nomina.ColaboradorLaboral AS B"
    '    consulta += " ON B.labo_colaboradorid = A.codr_colaboradorid"
    '    consulta += " JOIN Nomina.ColaboradorReal AS D"
    '    consulta += " ON D.real_colaboradorid = A.codr_colaboradorid"
    '    'consulta += " LEFT JOIN ControlAsistencia.CorteChecador as E on E.ccheck_colaborador=A.codr_colaboradorid"
    '    consulta += " WHERE B.labo_naveid =" + NaveID.ToString
    '    consulta += " AND A.codr_activo = 1"
    '    ''consulta += " AND E.ccheck_periodo_id=" + PeriodoNominaID.ToString
    '    If DepartamentoID > 0 Then
    '        consulta += " AND B.labo_departamentoid = " + DepartamentoID.ToString
    '    End If
    '    If CelulaID > 0 Then
    '        consulta += " AND B.labo_celulaid = " + CelulaID.ToString
    '    End If
    '    consulta += " and D.real_tipo='DESTAJO'"
    '    Return Operaciones.EjecutaConsulta(consulta)
    'End Function


    Public Function DepartamentosSegunPermiso(ByVal NaveID As Integer, ByVal Montado As Boolean, ByVal Adorno As Boolean, ByVal Pespunte As Boolean, ByVal corte As Boolean, ByVal plantilla As Boolean, ByVal Todo As Boolean)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta += "   SELECT * FROM Framework.Grupos as A"
        consulta += " where grup_naveid =" + NaveID.ToString
        consulta += " and A.grup_activo=1"
        If Todo = True Then
            consulta += " AND( A.grup_name LIKE 'MONTADO'"
            consulta += " OR A.grup_name LIKE 'ADORNO'"
            consulta += " OR A.grup_name LIKE 'PESPUNTE%'"
            consulta += " OR A.grup_name LIKE 'CORTE'"
            consulta += " OR A.grup_name LIKE 'PLANTILLA') ORDER BY A.grup_name"
        Else
            consulta += " AND("

            If Montado = True Then
                consulta += " A.grup_name LIKE 'MONTADO'"
            End If

            If Montado = True And Adorno = True Then
                consulta += " OR"
            End If

            If Adorno = True Then
                consulta += " A.grup_name LIKE 'ADORNO'"
            End If

            If (Montado = True Or Adorno = True) And Pespunte = True Then
                consulta += " OR"
            End If

            If Pespunte = True Then
                consulta += " A.grup_name LIKE 'PESPUNTE%'"
            End If

            If (Montado Or Adorno Or Pespunte) = True And corte = True Then
                consulta += "OR"
            End If

            If corte = True Then
                consulta += " A.grup_name LIKE 'CORTE'"
            End If

            If (Montado Or Adorno Or Pespunte Or corte) = True And plantilla = True Then
                consulta += "OR"
            End If

            If plantilla = True Then
                consulta += " A.grup_name LIKE 'PLANTILLA'"
            End If
            consulta += " ) ORDER BY A.grup_name"
        End If

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    'Public Function totalDestajosPorColaborador(ByVal colaboradorID As Integer, ByVal periodoNominaID As Integer) As DataTable
    '    Dim objPersistencia As New Persistencia.OperacionesProcedimientos
    '    Dim listaParametros As New List(Of SqlParameter)
    '    Dim parametro As New SqlParameter

    '    parametro.ParameterName = "@ColaboradorId"
    '    parametro.Value = colaboradorID
    '    listaParametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@PeriodoNominaId"
    '    parametro.Value = periodoNominaID
    '    listaParametros.Add(parametro)

    '    Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_TotalDestajosporColaborador]", listaParametros)

    '    'Dim consulta As String = ""

    '    'consulta += " SELECT DATEPART(dw,dest_fecha)  as Dia,sum(dest_montoticket) as MontoAcumulado FROM Nomina.Destajos"
    '    'consulta += " where dest_colaboradorid=" + colaboradorID.ToString
    '    'consulta += " and dest_periodonominaid=" + periodoNominaID.ToString
    '    'consulta += " group by dest_fecha"
    '    'Return objPersistencia.EjecutaConsulta(consulta)
    'End Function

    'Public Function Inasistencias(ByVal colaboradorID As Integer, ByVal periodoNominaID As Integer)
    '    Dim operaciones As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String = ""
    '    consulta += " SELECT ccheck_inasistencia FROM ControlAsistencia.CorteChecador"
    '    consulta += " where ccheck_periodo_id=" + periodoNominaID.ToString
    '    consulta += " and ccheck_colaborador=" + colaboradorID.ToString
    '    Return operaciones.EjecutaConsulta(consulta)
    'End Function

    'Public Function consultarCierre(ByVal PeriodoNominaID As Integer, ByVal NaveID As Integer, ByVal DepartamentoID As Integer, ByVal CelulaID As Integer)

    '    Dim Operaciones As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String = ""
    '    consulta += " SELECT * FROM Nomina.CierreDestajos as A"
    '    consulta += " JOIN Nomina.Colaborador as B ON B.codr_colaboradorid=A.dest_colaboradorid"
    '    consulta += " JOIN Nomina.ColaboradorLaboral as C on C.labo_colaboradorid=B.codr_colaboradorid"
    '    consulta += " JOIN Nomina.ColaboradorReal as D on D.real_colaboradorid=B.codr_colaboradorid"
    '    consulta += " WHERE C.labo_naveid=" + NaveID.ToString
    '    consulta += " AND B.codr_activo=1"
    '    If CelulaID > 0 Then
    '        consulta += " And C.labo_celulaid=" + CelulaID.ToString
    '    End If

    '    If DepartamentoID > 0 Then
    '        consulta += " and C.labo_departamentoid=" + DepartamentoID.ToString
    '    End If
    '    consulta += " and A.dest_periodonominaid=" + PeriodoNominaID.ToString
    '    consulta += " and D.real_tipo='DESTAJO'"
    '    Return Operaciones.EjecutaConsulta(consulta)
    'End Function

    Public Function consultarCierreDestajo(ByVal PeriodoNominaID As Integer, ByVal NaveID As Integer, ByVal DepartamentoID As Integer, ByVal CelulaID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@PeriodoNominaId"
        parametro.Value = PeriodoNominaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = NaveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DepartamentoID"
        parametro.Value = DepartamentoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CelulaID"
        parametro.Value = CelulaID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ObtieneColaboradoresDestajo_PeriodoCerrado]", listaParametros)
    End Function

    Public Function consultarDestajoAbierto(ByVal PeriodoNominaID As Integer, ByVal NaveID As Integer, ByVal DepartamentoID As Integer, ByVal CelulaID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@PeriodoNominaId"
        parametro.Value = PeriodoNominaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = NaveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DepartamentoID"
        parametro.Value = DepartamentoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CelulaID"
        parametro.Value = CelulaID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ObtieneColaboradoresDestajo_PeriodoAbierto]", listaParametros)

    End Function


    Public Sub cierreDestajos(ByVal Destajos As Entidades.CorteDestajos)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@dest_periodonominaid"
        parametro.Value = Destajos.PPeriodoNominaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@dest_colaboradorid"
        parametro.Value = Destajos.PColaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@dest_salariobase"
        parametro.Value = Destajos.PRealCantidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@dest_acumulado"
        parametro.Value = Destajos.PTotalDestajos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@dest_ajuste"
        parametro.Value = Destajos.PajusteDestajo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@dest_totalpagar"
        parametro.Value = Destajos.PTotalDestajos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@dest_usuariocreoid"
        parametro.Value = Destajos.PusuarioCreo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@dest_fechacreacion"
        parametro.Value = Destajos.PfechaCreacion
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Nomina.SP_Alta_Cierre_Destajos", listaParametros)
    End Sub


#Region "Asignación de fracciones"
    ''' <summary>
    ''' Busca los departamentos de una nave donde hay colaboradores que registran tickets
    ''' </summary>
    ''' <param name="naveId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DepartamentosConDestajos(ByVal naveId As Integer) As DataTable
        Dim obj As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select grup_grupoid,upper(grup_name)grup_name from Framework.Grupos where grup_activo='true' and grup_grupoid in( select distinct a.labo_departamentoid from nomina.ColaboradorLaboral a  join nomina.ColaboradorReal b on a.labo_colaboradorid=b.real_colaboradorid join nomina.Colaborador c on a.labo_colaboradorid=c.codr_colaboradorid where b.real_tipo='DESTAJO' and c.codr_activo='true' and a.labo_naveid=" + naveId.ToString + ") and grup_activo='true' order by grup_name"
        Return obj.EjecutaConsulta(consulta)
    End Function
    ''' <summary>
    ''' Busca todas las fracciones de una nave
    ''' </summary>
    ''' <param name="naveId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FraccionesNave(ByVal naveId As Integer) As DataTable
        Dim obj As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta = "select  DISTINCT ltrim(Fraccion) Fraccion from Fracciones where IdCatnave=" + naveId.ToString + " order by ltrim(Fraccion)"
        Return obj.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' Fracciones asignada en la nave. Opcional a un departamento
    ''' </summary>
    ''' <param name="naveId"></param>
    ''' <param name="departamentoid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FraccionesNaveAsignadas(ByVal naveId As Integer, ByVal departamentoid As Integer) As DataTable
        Dim objSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select grup_name 'Departamento', deaf_fraccion 'Fracción', deaf_fechacreacion 'Fecha Asignación' from Nomina.DestajosAsignacionFracciones a join Framework.Grupos on a.deaf_departamentoid=grup_grupoid where deaf_naveid=" + naveId.ToString

        If departamentoid > 0 Then
            consulta += " and deaf_departamentoid=" + departamentoid.ToString
        End If

        consulta += " order by grup_name, deaf_fraccion"
        Return objSAY.EjecutaConsulta(consulta)
    End Function


    Public Function FraccionesNaveSinAsignar(ByVal naveId As Integer) As DataTable
        Dim objsay As New Persistencia.OperacionesProcedimientos
        Dim obj As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty

        If obj.Servidor <> objsay.Servidor Then
            consulta = "select 'False' Asignar,f.Fraccion 'Fracción' from [" + obj.Servidor + "].[" + obj.NombreDB + "].dbo.Fracciones f where f.IdCatnave=(SELECT nave_navesicyid from Framework.Naves WHERE nave_naveid =" + naveId.ToString + ") and ltrim(rtrim(f.Fraccion)) not in (select dd.deaf_fraccion from "
            consulta += "[Nomina].[DestajosAsignacionFracciones] dd where deaf_naveid=" + naveId.ToString + ") "
        Else
            consulta = "select 'False' Asignar,f.Fraccion 'Fracción' from [" + obj.NombreDB + "].dbo.Fracciones f where f.IdCatnave=(SELECT nave_navesicyid from Framework.Naves WHERE nave_naveid =" + naveId.ToString + ") and ltrim(rtrim(f.Fraccion)) not in (select dd.deaf_fraccion from "
            consulta += "[Nomina].[DestajosAsignacionFracciones] dd where deaf_naveid=" + naveId.ToString + ") "
        End If
        consulta += " order by f.Fraccion asc"
        Return objsay.EjecutaConsulta(consulta)
    End Function

    Public Function FraccionesNaveEditar(ByVal naveId As Integer, ByVal departamentoid As Integer) As DataTable
        Dim obj As New Persistencia.OperacionesProcedimientosSICY
        Dim objSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select Asignar, Fracción from (SELECT 	distinct dbo.TRIM(f.Fraccion) 'Fracción', 	CASE WHEN d.deaf_departamentoid IS NULL THEN 'false' ELSE 'true' END as Asignar	  FROM Fracciones f LEFT JOIN "
        If obj.Servidor <> objSAY.Servidor Then
            consulta += "[" + objSAY.Servidor + "].[" + objSAY.NombreDB + "].Nomina.DestajosAsignacionFracciones d"
        Else
            consulta += "[" + objSAY.NombreDB + "].Nomina.DestajosAsignacionFracciones d"
        End If
        consulta += " ON LTRIM(RTRIM(f.Fraccion)) = LTRIM(RTRIM(d.deaf_fraccion)) AND f.IdCatnave = d.deaf_naveid WHERE f.IdCatnave =" + naveId.ToString + "  AND LTRIM(RTRIM(f.Fraccion)) NOT IN "
        If obj.Servidor <> objSAY.Servidor Then
            consulta += "(select dd.deaf_fraccion from [" + objSAY.Servidor + "].[" + objSAY.NombreDB + "].[Nomina].[DestajosAsignacionFracciones] dd where deaf_departamentoid<>" + departamentoid.ToString + ") "
        Else
            consulta += "(select dd.deaf_fraccion from [" + objSAY.NombreDB + "].[Nomina].[DestajosAsignacionFracciones] dd where deaf_departamentoid<>" + departamentoid.ToString + ") "
        End If
        consulta += " group by d.deaf_departamentoid, f.Fraccion) as tabla1 order by tabla1.Asignar desc, tabla1.Fracción asc"
        Return obj.EjecutaConsulta(consulta)
    End Function

    Public Sub guardarAsignacionFracciones(ByVal naveid As Integer, ByVal departamentoid As Integer, ByVal fracciones As String, ByVal restaurar As Integer)
        Dim obj As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@nave"
        parametro.Value = naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@departamento"
        parametro.Value = departamentoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fraccion"
        parametro.Value = fracciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@restaurar"
        parametro.Value = restaurar
        listaParametros.Add(parametro)

        obj.EjecutarConsultaSP("Nomina.sp_asignarfracciones", listaParametros)
    End Sub

#End Region
End Class
