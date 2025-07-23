Imports System.Data.SqlClient

Public Class DeduccionesDA

    Public Function lstDeduccionesPorCobrar(idNave As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT codr_nombre,codr_apellidopaterno,codr_apellidomaterno,codr_colaboradorid,grup_name,pues_nombre,decx_deduccionid,decx_concepto,decx_monto,decx_numerosemanas,decx_abono,decx_saldo,"
        consulta += " (SELECT COUNT(*)+1 AS NumPago from nomina.DeduccionesExtraordinariasPago where pagodecx_deduccionid=A.decx_deduccionid) as numPago  "
        consulta += " from Nomina.DeduccionesExtraordinarias as A "
        consulta += " JOIN Nomina.ColaboradorLaboral as B on A.decx_colaboradorid=b.labo_colaboradorid  "
        consulta += " Join Nomina.Colaborador as C on c.codr_colaboradorid=b.labo_colaboradorid "
        consulta += " JOIN nomina.Puestos as D on d.pues_puestoid=B.labo_puestoid "
        consulta += " JOIN Framework.Grupos as E on E.grup_grupoid=B.labo_departamentoid "
        consulta += " where(labo_naveid = " + idNave.ToString + ") "
        consulta += " and  (decx_estatus='A' Or  decx_estatus='B') "

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function
    '' INICIA  FILTRO DE COLABORADORES
    Public Function ListaColaboradoresDeducciones(ByVal idNave As Int32, ByVal idArea As Int32, ByVal idDepartamento As Int32, ByVal colaborador As String) As DataTable
        'Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = "     select * from Nomina.ColaboradorLaboral as A "
        'consulta += " JOIN Nomina.Colaborador as B on A.labo_colaboradorid=b.codr_colaboradorid "
        'consulta += " JOIN nomina.Puestos as C on a.labo_puestoid=c.pues_puestoid "
        'consulta += " JOIN Framework.Grupos as D on D.grup_grupoid=c.pues_departamentoid "
        'consulta += "   where(labo_naveid = " + idNave.ToString + ") "
        'consulta += "   and B.codr_activo= 1 "
        'consulta += " and (codr_nombre+' '+codr_apellidopaterno+' '+codr_apellidomaterno) like '%" + colaborador.Replace(" ", "%") + "%'"

        'If idArea > 0 Then
        '    consulta += " and  labo_areaid= " + idArea.ToString
        'End If

        'If idDepartamento > 0 Then
        '    consulta += " and labo_departamentoid= " + idDepartamento.ToString
        'End If

        'Return objOperaciones.EjecutaConsulta(consulta)

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idnave"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idArea"
        parametro.Value = idArea
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idDepartamento"
        parametro.Value = idDepartamento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaborador"
        parametro.Value = colaborador
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("Nomina.SP_ListaColaboradoresDeducciones", listaParametros)

    End Function

    '' INICIA  FILTRO DE COLABORADORES
    Public Function ListaDeducciones(ByVal idNave As Int32, ByVal idArea As Int32, ByVal idDepartamento As Int32, ByVal colaborador As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        'Dim consulta As String = " SELECT *, (SELECT COUNT(*)+1 AS NumPago  from nomina.DeduccionesExtraordinariasPago where pagodecx_deduccionid=A.decx_deduccionid) as numPago "
        'consulta += " from Nomina.DeduccionesExtraordinarias as A "
        'consulta += " JOIN Nomina.ColaboradorLaboral as B on A.decx_colaboradorid=b.labo_colaboradorid  "
        'consulta += " Join Nomina.Colaborador as C on c.codr_colaboradorid=b.labo_colaboradorid "
        'consulta += " JOIN nomina.Puestos as D on d.pues_puestoid=B.labo_puestoid "
        'consulta += " JOIN Framework.Grupos as E on E.grup_grupoid=B.labo_departamentoid "
        'consulta += " where(labo_naveid = " + idNave.ToString + ") "
        ''consulta += " and  decx_estatus='A' "
        'consulta += " and (codr_nombre+' '+codr_apellidopaterno+' '+codr_apellidomaterno) like '%" + colaborador.Replace(" ", "%") + "%'"

        'If idArea > 0 Then
        '    consulta += " and  labo_areaid= " + idArea.ToString
        'End If

        'If idDepartamento > 0 Then
        '    consulta += " and labo_departamentoid= " + idDepartamento.ToString
        'End If


        'Return objOperaciones.EjecutaConsulta(consulta)
        parametro.ParameterName = "idNave"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idArea"
        parametro.Value = idArea
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idDepartamento"
        parametro.Value = idDepartamento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaborador"
        parametro.Value = colaborador
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Nomina].[ListaDeducciones]", listaParametros)


    End Function


    Public Function ListaDeduccionesCobradas(ByVal idNave As Int32, ByVal idSemanaNomina As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " select * from Nomina.DeduccionesExtraordinariasPago as A  "
        consulta += " JOIN Nomina.DeduccionesExtraordinarias as B on B.decx_deduccionid= A.pagodecx_deduccionid "
        consulta += " JOIN Nomina.ColaboradorLaboral as C on C.labo_colaboradorid=B.decx_colaboradorid "
        consulta += " JOIN Nomina.Colaborador as D on D.codr_colaboradorid=B.decx_colaboradorid "
        consulta += " JOIN nomina.Puestos as E on E.pues_puestoid= C.labo_puestoid "
        consulta += " JOIN Framework.Grupos as F on F.grup_grupoid=C.labo_departamentoid  "
        consulta += " WHERE a.pagodecx_semananominaid= " + idSemanaNomina.ToString
        consulta += " AND C.labo_naveid= " + idNave.ToString

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaDeduccionesCobradasNegativos(ByVal idNave As Int32, ByVal idSemanaNomina As Integer, ByVal idColaborador As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " select * from Nomina.DeduccionesExtraordinariasPago as A  "
        consulta += " JOIN Nomina.DeduccionesExtraordinarias as B on B.decx_deduccionid= A.pagodecx_deduccionid "
        consulta += " JOIN Nomina.ColaboradorLaboral as C on C.labo_colaboradorid=B.decx_colaboradorid "
        consulta += " JOIN Nomina.Colaborador as D on D.codr_colaboradorid=B.decx_colaboradorid "
        consulta += " JOIN nomina.Puestos as E on E.pues_puestoid= C.labo_puestoid "
        consulta += " JOIN Framework.Grupos as F on F.grup_grupoid=C.labo_departamentoid  "
        consulta += " WHERE a.pagodecx_semananominaid= " + idSemanaNomina.ToString
        consulta += " AND C.labo_naveid= " + idNave.ToString
        consulta += "and c.labo_colaboradorid= " + idColaborador.ToString

        Return objOperaciones.EjecutaConsulta(consulta)


    End Function


    Public Sub GuardarDeducciones(ByVal Deducciones As Entidades.Deducciones)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "dedu_concepto"
        parametro.Value = Deducciones.PConceptoDeduccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dedu_cantidad"
        parametro.Value = Deducciones.PMontoDeduccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dedu_colaboradorid"
        parametro.Value = Deducciones.PColaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dedu_periodonominaid"
        parametro.Value = Deducciones.PCobranza.PsemanaNominaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dedu_fechacreacion"
        parametro.Value = Deducciones.PCobranza.PfechaFinNomina
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dedu_usuariocreoid"
        parametro.Value = Deducciones.PidCreo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dedu_tipo"
        parametro.Value = Deducciones.PDeduccionTipo
        listaParametros.Add(parametro)


        operaciones.EjecutarSentenciaSP("Nomina.SP_Alta_Deduccion", listaParametros)
    End Sub

    Public Sub GuardarDeduccionesExtraordinarias(ByVal Deducciones As Entidades.Deducciones)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)



        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "decx_colaboradorid"
        parametro.Value = Deducciones.PColaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "decx_usuariocreo"
        parametro.Value = Deducciones.PidCreo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "decx_concepto"
        parametro.Value = Deducciones.PConceptoDeduccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "decx_monto"
        parametro.Value = Deducciones.PMontoDeduccion
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "decx_numerosemanas"
        parametro.Value = Deducciones.PnumeroSemanas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "decx_estatus"
        parametro.Value = Deducciones.PEstatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "decx_saldo"
        parametro.Value = Deducciones.PSaldo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "decx_abono"
        parametro.Value = Deducciones.Pabono
        listaParametros.Add(parametro)


        operaciones.EjecutarSentenciaSP("Nomina.SP_Alta_Deducciones_Extraordinarias", listaParametros)
    End Sub



    Public Sub GuardarEliminarDeducciones(ByVal Deducciones As Entidades.Deducciones)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "decx_deduccionid"
        parametro.Value = Deducciones.PidDeduccion
        listaParametros.Add(parametro)


        operaciones.EjecutarSentenciaSP("Nomina.SP_Eliminar_Deduccion_Extraordinaria", listaParametros)
    End Sub

    'Public Function ListaDeduccionesPorCobrar(ByVal idNave As Int32) As DataTable
    '    Dim objOperaciones As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String = " SELECT *, (SELECT COUNT(*)+1 AS NumPago from nomina.DeduccionesExtraordinariasPago where pagodecx_deduccionid=A.decx_deduccionid) as numPago  "
    '    consulta += " from Nomina.DeduccionesExtraordinarias as A "
    '    consulta += " JOIN Nomina.ColaboradorLaboral as B on A.decx_colaboradorid=b.labo_colaboradorid  "
    '    consulta += " Join Nomina.Colaborador as C on c.codr_colaboradorid=b.labo_colaboradorid "
    '    consulta += " JOIN nomina.Puestos as D on d.pues_puestoid=B.labo_puestoid "
    '    consulta += " JOIN Framework.Grupos as E on E.grup_grupoid=B.labo_departamentoid "
    '    consulta += " where(labo_naveid = " + idNave.ToString + ") "
    '    consulta += " and  (decx_estatus='A' Or  decx_estatus='B') "

    '    Return objOperaciones.EjecutaConsulta(consulta)
    'End Function

    Public Function ListaDeduccionesPorCobrar(ByVal idNave As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        'Dim consulta As String = String.Empty

        'consulta = "SELECT " & vbCrLf & _
        '    "0 CondonarTodo, C.codr_colaboradorid IdColaborador, A.decx_deduccionid IdDeduccion, A.decx_numerosemanas NumSemanas, " & vbCrLf & _
        '    "CAST((SELECT COUNT(*) + 1 FROM nomina.DeduccionesExtraordinariasPago WHERE pagodecx_deduccionid = A.decx_deduccionid) AS varchar(5)) NumPago," & vbCrLf & _
        '    "CAST((SELECT COUNT(*) + 1 FROM nomina.DeduccionesExtraordinariasPago WHERE pagodecx_deduccionid = A.decx_deduccionid) AS varchar(5)) + " & vbCrLf & _
        '     "'/' + CAST(decx_numerosemanas AS varchar(5)) NumeroPago," & vbCrLf & _
        '    "LTRIM(RTRIM(C.codr_nombre + ' ' + C.codr_apellidopaterno + ' ' + C.codr_apellidomaterno)) Colaborador," & vbCrLf & _
        '    "E.grup_name Departamento," & vbCrLf & _
        '    "D.pues_nombre Puesto, " & vbCrLf & _
        '    "A.decx_concepto Concepto," & vbCrLf & _
        '    "A.decx_monto Monto," & vbCrLf & _
        '    "A.decx_saldo Saldo," & vbCrLf & _
        '    "CASE WHEN A.decx_saldo <= A.decx_abono THEN A.decx_saldo ELSE A.decx_abono END Abono," & vbCrLf & _
        '    "CASE WHEN A.decx_saldo <= A.decx_abono THEN 0 ELSE A.decx_saldo - A.decx_abono END SaldoNuevo" & vbCrLf & _
        '    "FROM Nomina.DeduccionesExtraordinarias AS A " & vbCrLf & _
        '    "JOIN Nomina.ColaboradorLaboral AS B ON A.decx_colaboradorid=b.labo_colaboradorid  " & vbCrLf & _
        '    "JOIN Nomina.Colaborador AS C ON c.codr_colaboradorid=b.labo_colaboradorid " & vbCrLf & _
        '    "JOIN nomina.Puestos AS D ON d.pues_puestoid=B.labo_puestoid " & vbCrLf & _
        '    "JOIN Framework.Grupos AS E ON E.grup_grupoid=B.labo_departamentoid " & vbCrLf & _
        '    "WHERE(labo_naveid = " + idNave.ToString + ") " & vbCrLf & _
        '    "AND (decx_estatus='A' OR decx_estatus='B') "

        'Return objOperaciones.EjecutaConsulta(consulta)

        parametro = New SqlParameter
        parametro.ParameterName = "idNave"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Nomina].[ListaDeduccionesPorCobrar]", listaParametros)
    End Function

    Public Function NumSemanasGanadas(ByVal idColaborador As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT TOP 6 * from  ControlAsistencia.CorteChecador"
        consulta += " where ccheck_colaborador =" + idColaborador.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function NumCondonaciones(ByVal idColaborador As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT TOP 6 * from  Nomina.DeduccionesExtraordinariasPago as A "
        consulta += " Join nomina.DeduccionesExtraordinarias as B on B.decx_deduccionid=A.pagodecx_deduccionid "
        consulta += "JOIN nomina.Colaborador as C on c.codr_colaboradorid=B.decx_colaboradorid "
        consulta += "where C.codr_colaboradorid= " + idColaborador.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub GuardarPagoDeduccionesExtraordinarias(ByVal Deducciones As Entidades.Deducciones)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "pagodecx_semananominaid"
        parametro.Value = Deducciones.PSemanaNominaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagodecx_deduccionid"
        parametro.Value = Deducciones.PidDeduccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagodecx_numeropago"
        parametro.Value = Deducciones.PNumeroPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagodecx_abono"
        parametro.Value = Deducciones.Pabono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagodecx_saldoanterior"
        parametro.Value = Deducciones.PSaldoAnterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagodecx_saldonuevo"
        parametro.Value = Deducciones.PSaldo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagodecx_condonacion"
        parametro.Value = Deducciones.PCondonacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "decx_estatus"
        parametro.Value = Deducciones.PEstatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "decx_usuariomodifico"
        parametro.Value = Deducciones.PidCreo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "decx_fechaPago"
        parametro.Value = Deducciones.PFechaModificacion
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_Alta_Deducciones_ExtraordinariasPago", listaParametros)
    End Sub

    Public Sub GuardarEdicionDeduccion(ByVal Deducciones As Entidades.Deducciones)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "decx_deduccionid"
        parametro.Value = Deducciones.PidDeduccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "decx_usuariomodifico"
        parametro.Value = Deducciones.PidModifico
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "decx_estatus"
        parametro.Value = Deducciones.PEstatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagodecx_pagoid"
        parametro.Value = Deducciones.PPagoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagodecx_abono"
        parametro.Value = Deducciones.Pabono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagodecx_saldoanterior"
        parametro.Value = Deducciones.PSaldoAnterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagodecx_saldonuevo"
        parametro.Value = Deducciones.PSaldo
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_Editar_Deduccion_Extraordinaria", listaParametros)
    End Sub

    Public Function ListaDeduccionesFiltro(ByVal idNave As Int32, ByVal idSemanaNomina As Integer, ByVal colaborador As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " Select * from nomina.DeduccionesExtraordinarias AS A  "
        consulta += " JOIN Nomina.DeduccionesExtraordinariasPago as B on B.pagodecx_deduccionid=A.decx_deduccionid "
        consulta += " JOIN Nomina.Colaborador as C on C.codr_colaboradorid=A.decx_colaboradorid "
        consulta += " JOIN Nomina.ColaboradorLaboral as D on D.labo_colaboradorid=A.decx_colaboradorid "
        consulta += " JOIN nomina.Puestos as E on E.pues_puestoid=D.labo_puestoid "
        consulta += " JOIN Framework.Grupos as F on F.grup_grupoid=D.labo_departamentoid "
        consulta += " WHERE B.pagodecx_semananominaid= " + idSemanaNomina.ToString
        consulta += " AND D.labo_naveid= " + idNave.ToString

        consulta += " and (codr_nombre+' '+codr_apellidopaterno+' '+codr_apellidomaterno) like '%" + colaborador.Replace(" ", "%") + "%'"

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function lstDeduccionesFiltro(ByVal IdNave As Integer, ByVal idSemanaNomina As Integer, ByVal colaborador As String, semanaDel As String, semanaAl As String, conFechas As Boolean) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim operaciones As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "@idNave"
        parametro.Value = IdNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idSemanaNomina"
        parametro.Value = idSemanaNomina
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colaborador"
        parametro.Value = colaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@semanaDel"
        parametro.Value = semanaDel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@semanaAl"
        parametro.Value = semanaAl
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@conFechas"
        parametro.Value = conFechas
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[ConsultaDeduccionesExtraordinarias]", listaParametros)
    End Function

    Public Function DeduccionesExtraActivas(ByVal idNave As Int32, ByVal idSemanaNomina As Integer, ByVal colaborador As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " Select * from nomina.DeduccionesExtraordinarias AS A  "
        consulta += " JOIN Nomina.DeduccionesExtraordinariasPago as B on B.pagodecx_deduccionid=A.decx_deduccionid "
        consulta += " JOIN Nomina.Colaborador as C on C.codr_colaboradorid=A.decx_colaboradorid "
        consulta += " JOIN Nomina.ColaboradorLaboral as D on D.labo_colaboradorid=A.decx_colaboradorid "
        consulta += " JOIN nomina.Puestos as E on E.pues_puestoid=D.labo_puestoid "
        consulta += " JOIN Framework.Grupos as F on F.grup_grupoid=D.labo_departamentoid "
        consulta += " WHERE decx_estatus='B'"
        consulta += " AND D.labo_naveid= " + idNave.ToString
        consulta += " and (codr_nombre+' '+codr_apellidopaterno+' '+codr_apellidomaterno) like '%" + colaborador.Replace(" ", "%") + "%'"

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function


    Public Function ListaDeduccionesFiltroCorte(ByVal idNave As Int32, ByVal idSemanaNomina As Integer, ByVal colaborador As String, ByVal Colaboradorid As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " Select * from nomina.DeduccionesExtraordinarias AS A  "
        consulta += " JOIN Nomina.DeduccionesExtraordinariasPago as B on B.pagodecx_deduccionid=A.decx_deduccionid "
        consulta += " JOIN Nomina.Colaborador as C on C.codr_colaboradorid=A.decx_colaboradorid "
        consulta += " JOIN Nomina.ColaboradorLaboral as D on D.labo_colaboradorid=A.decx_colaboradorid "
        consulta += " JOIN nomina.Puestos as E on E.pues_puestoid=D.labo_puestoid "
        consulta += " JOIN Framework.Grupos as F on F.grup_grupoid=D.labo_departamentoid "
        consulta += " WHERE B.pagodecx_semananominaid= " + idSemanaNomina.ToString
        consulta += " AND D.labo_naveid= " + idNave.ToString
        consulta += " and A.decx_colaboradorid=" + Colaboradorid.ToString
        consulta += " and (codr_nombre+' '+codr_apellidopaterno+' '+codr_apellidomaterno) like '%" + colaborador.Replace(" ", "%") + "%'"

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    'consulta de deducciones extraordinarias, se descuente en liquidaciones
    Public Function ConsultaDeDeduccionesExtLiquidacion(ByVal colaboradorid As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = "SELECT sum(decx_saldo) as Deducciones from Nomina.DeduccionesExtraordinarias WHERE decx_estatus in ('A','B') AND decx_colaboradorid=" + colaboradorid.ToString
        'Return operacion.EjecutaConsulta(consulta)
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@ColaboradorId"
        parametro.Value = colaboradorid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Nomina].[SP_Deducciones_Extraordinarias_Liquidacion]", listaParametros)

    End Function


    Public Function consultaReporteDeducciones(ByVal idnave As Int32, ByVal inicioPeriodo As String,
                                               ByVal finPeriodo As String, ByVal idCaja As Int32, ByVal anioCaja As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        '    cadena = "SELECT MES,	SemanaNomina,	SemanaAhorro,	idPeriodo,	Periodo, Ahorro, Prestamo - InteresPrestamo as Prestamo, InteresPrestamo, DeduccionesExt, IMSS,	Otros + PrestamosRegresados as otros ," +
        '" (Ahorro + Prestamo + CONS.DeduccionesExt + IMSS + Otros + CONS.PrestamosRegresados ) as Deducciones," +
        '" Prestamos, InteresPrestamos,	Finiquitos,	((Ahorro + Prestamo + CONS.DeduccionesExt + IMSS + Otros + PrestamosRegresados )-(Prestamos + Finiquitos)) as Saldo, AÑO, cajaTotal" +
        '" FROM (SELECT DATEPART(MONTH, pn.pnom_FechaFinal) AS MES, pn.pnom_NoSemanaNomina SemanaNomina, pn.pnom_NoSemanaCajaAhorro SemanaAhorro, pn.pnom_PeriodoNomId idPeriodo,/* pn.pnom_Concepto Periodo, */" +
        '" ( cast(RIGHT('0' + RTRIM(DAY(pn.pnom_FechaInicial)), 2) as varchar(50)) + ' AL ' + cast (RIGHT('0' + RTRIM(DAY(pn.pnom_FechaFinal)), 2) as varchar(50)) + ' DE ' + UPPER( cast (DATENAME(month,pn.pnom_FechaFinal) as varchar(50)))+ ' ' + cast (DATEPART(YEAR,pn.pnom_FechaFinal) as varchar(50)) )as Periodo," +
        '" ISNULL((SELECT SUM(dedu_cantidad) FROM Nomina.Deducciones WHERE dedu_tipo = 1 AND dedu_periodonominaid = pn.pnom_PeriodoNomId), 0) AS Ahorro," +
        '" ISNULL((SELECT SUM(dedu_cantidad) FROM Nomina.Deducciones WHERE dedu_tipo = 2 AND dedu_periodonominaid = pn.pnom_PeriodoNomId), 0) AS Prestamo," +
        '" ISNULL( (SELECT SUM(pagop_interes) FROM Prestamos.PagoPrestamos WHERE pagop_semananominaid=pn.pnom_PeriodoNomId AND pagop_dentronomina='A'),0) as InteresPrestamo," +
        '" isnull ((SELECT SUM(round(pagodecx_abono,0)) FROM Nomina.DeduccionesExtraordinariasPago WHERE pagodecx_semananominaid=pn.pnom_PeriodoNomId),0) as DeduccionesExt, " +
        '" ISNULL((SELECT SUM(dedu_cantidad) FROM Nomina.Deducciones WHERE dedu_tipo = 3 AND dedu_periodonominaid = pn.pnom_PeriodoNomId) +" +
        '" (SELECT SUM(dedu_cantidad) FROM Nomina.Deducciones WHERE dedu_tipo = 4 AND dedu_periodonominaid = pn.pnom_PeriodoNomId) +" +
        '" (SELECT SUM(dedu_cantidad) FROM Nomina.Deducciones WHERE dedu_tipo = 5 AND dedu_periodonominaid = pn.pnom_PeriodoNomId and isnull (pn.pnom_imssvisible, 0)=1 ), 0) AS IMSS," +
        '" ISNULL((SELECT SUM(pagop_abonocapital) FROM (" +
        '" SELECT ppc.pagop_abonocapital, ppc.pagop_semananominaid, pcc.pres_prestamoid, clc.labo_colaboradorlaboralid, clc.labo_naveid FROM Prestamos.PagoPrestamos ppc " +
        '" JOIN Prestamos.Prestamos pcc ON ppc.pagop_prestamoid=pcc.pres_prestamoid" +
        '" JOIN Nomina.PeriodosNomina pnc on ppc.pagop_semananominaid = pn.pnom_PeriodoNomId" +
        '" JOIN Nomina.ColaboradorLaboral clc on pcc.pres_colaboradorid = clc.labo_colaboradorid" +
        '" WHERE ppc.pagop_dentronomina in ('B') AND clc.labo_naveid =" + idnave.ToString + " AND pnc.pnom_PeriodoNomId = pn.pnom_PeriodoNomId" +
        '" GROUP BY ppc.pagop_abonocapital, ppc.pagop_semananominaid, pcc.pres_prestamoid, clc.labo_colaboradorlaboralid, clc.labo_naveid) as consPres), 0) AS Otros," +
        '" ISNULL((SELECT SUM(p.pres_montoautorizado) FROM Prestamos.Prestamos p JOIN Nomina.ColaboradorLaboral cb ON p.pres_colaboradorid=cb.labo_colaboradorid WHERE pres_estatus NOT IN ('I', 'J') AND p.pres_naveid = " + idnave.ToString + " AND ISNULL(p.pres_fechaAplicacion, p.pres_fechaentrega) BETWEEN pn.pnom_FechaInicial AND pn.pnom_FechaFinal), 0) AS Prestamos," +
        '" ISNULL((SELECT SUM(p.pres_montoautorizado) FROM Prestamos.Prestamos p JOIN Nomina.ColaboradorLaboral cb	ON p.pres_colaboradorid = cb.labo_colaboradorid WHERE pres_estatus IN ('K')	AND p.pres_naveid = " + idnave.ToString + " AND DATEPART(YEAR, p.pres_fechaDevolucion) = DATEPART(YEAR, pn.pnom_FechaInicial) AND p.pres_fechaDevolucion BETWEEN pn.pnom_FechaInicial AND pn.pnom_FechaFinal )  , 0) AS PrestamosRegresados," +
        '" ISNULL((SELECT SUM(p.pres_totalinteresesReporte) FROM Prestamos.Prestamos p JOIN Nomina.ColaboradorLaboral cb ON p.pres_colaboradorid = cb.labo_colaboradorid	WHERE pres_estatus NOT IN ('I', 'J') " +
        '" AND p.pres_naveid = " + idnave.ToString + " 	AND DATEPART(YEAR, ISNULL(p.pres_fechaAplicacion, p.pres_fechaentrega) ) = DATEPART(YEAR, pn.pnom_FechaInicial)  AND ISNULL(p.pres_fechaAplicacion, p.pres_fechaentrega) BETWEEN pn.pnom_FechaInicial AND pn.pnom_FechaFinal ), 0) AS InteresPrestamos,  " +
        '" ISNULL((SELECT SUM(f.fini_totalentregar) FROM Nomina.Finiquitos f JOIN Nomina.ColaboradorLaboral cl ON f.fini_colaboradorid = cl.labo_colaboradorid WHERE f.fini_estado <> 'C' AND cl.labo_naveid = " + idnave.ToString + " AND ISNULL(f.fini_fechaaplicacionfinanzas, f.fini_fechaentregado) BETWEEN pn.pnom_FechaInicial AND pn.pnom_FechaFinal), 0) AS Finiquitos," +
        '" DATEPART(YEAR, pn.pnom_FechaFinal) AS AÑO" +
        '" , ISNULL((SELECT SUM(cca_totalentregar) from CajaAhorro.CierreAnual WHERE cca_cajaahorroid=" + idCaja.ToString + "),0) as cajaTotal" +
        '" FROM Nomina.PeriodosNomina pn WHERE pn.pnom_NaveId = " + idnave.ToString +
        '" AND pn.pnom_FechaInicial BETWEEN'" + inicioPeriodo + "' AND '" + finPeriodo + "') AS CONS ORDER BY CONS.AÑO, CONS.MES,  CONS.SemanaNomina"

        parametro.ParameterName = "idnave"
        parametro.Value = idnave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inicioPeriodo"
        parametro.Value = inicioPeriodo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "finPeriodo"
        parametro.Value = finPeriodo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCaja"
        parametro.Value = idCaja
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "anioCaja"
        parametro.Value = anioCaja
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[CajaAhorro].[SP_ObtieneReporteGeneralDeducciones]", listaParametros)

        'Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaReporteDeduccionesAnterior(ByVal idnave As Int32, ByVal inicioPeriodo As String,
                                               ByVal finPeriodo As String, ByVal idCaja As Int32, ByVal anioCaja As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro.ParameterName = "idnave"
        parametro.Value = idnave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inicioPeriodo"
        parametro.Value = inicioPeriodo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "finPeriodo"
        parametro.Value = finPeriodo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCaja"
        parametro.Value = idCaja
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "anioCaja"
        parametro.Value = anioCaja
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[CajaAhorro].[SP_ObtieneReporteGeneralDeducciones]", listaParametros)

    End Function

    Public Function consultaMesesPeriodoCaja(ByVal idnave As Int32, ByVal inicioPeriodo As String,
                                               ByVal finPeriodo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT" +
                " DATEPART(MONTH, pn.pnom_FechaFinal) AS MES," +
                " CASE" +
                " WHEN DATEPART(MONTH, pn.pnom_FechaFinal) = 1 THEN" +
                        " 'ENERO'" +
                " WHEN DATEPART(MONTH, pn.pnom_FechaFinal) = 2 THEN" +
                        " 'FEBRERO'" +
                " WHEN DATEPART(MONTH, pn.pnom_FechaFinal) = 3 THEN" +
                        " 'MARZO'" +
                " WHEN DATEPART(MONTH, pn.pnom_FechaFinal) = 4 THEN" +
                        " 'ABRIL'" +
                " WHEN DATEPART(MONTH, pn.pnom_FechaFinal) = 5 THEN" +
                        " 'MAYO'" +
                " WHEN DATEPART(MONTH, pn.pnom_FechaFinal) = 6 THEN" +
                        " 'JUNIO'" +
                " WHEN DATEPART(MONTH, pn.pnom_FechaFinal) = 7 THEN" +
                        " 'JULIO'" +
                " WHEN DATEPART(MONTH, pn.pnom_FechaFinal) = 8 THEN" +
                        " 'AGOSTO'" +
                " WHEN DATEPART(MONTH, pn.pnom_FechaFinal) = 9 THEN" +
                        " 'SEPTIEMBRE'" +
                " WHEN DATEPART(MONTH, pn.pnom_FechaFinal) = 10 THEN" +
                        " 'OCTUBRE'" +
                " WHEN DATEPART(MONTH, pn.pnom_FechaFinal) = 11 THEN" +
                        " 'NOVIEMBRE'" +
                " WHEN DATEPART(MONTH, pn.pnom_FechaFinal) = 12 THEN" +
                        " 'DICIEMBRE'" +
                    " END AS MESTEXTO, DATEPART(YEAR, pn.pnom_FechaFinal) AS ANIO" +
                    " FROM Nomina.PeriodosNomina pn WHERE pn.pnom_NaveId = " + idnave.ToString +
                    " AND pn.pnom_FechaInicial BETWEEN'" + inicioPeriodo + "' AND '" + finPeriodo + "'" +
                    " GROUP BY DATEPART(MONTH, pn.pnom_FechaFinal), DATEPART(YEAR, pn.pnom_FechaFinal)" +
                    " ORDER BY ANIO"

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function CambiaDeduccionesNegativos(ByVal colaboradorid As Integer, ByVal modificacaja As Boolean, ByVal modificaprestamo As Boolean, ByVal modificadeducciones As Boolean, ByVal periodoid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modificaCaja"
        parametro.Value = modificacaja
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modificaPrestamo"
        parametro.Value = modificaprestamo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modificaDeduccion"
        parametro.Value = modificadeducciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "periodoId"
        parametro.Value = periodoid
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_CambiaDeduccionesNegativos]", listaParametros)
    End Function

End Class
