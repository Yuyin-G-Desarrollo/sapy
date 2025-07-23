Imports System.Data.SqlClient

Public Class NominaDestajosDA

    ''' <summary>
    ''' EJECUTA CONSULTA SQL PARA TRAER TODOS LOS TRGISTROS DE ID Y COMCEPTO DE LA TABLA NOMMINA.PERIODOSDENOMINA
    ''' </summary>
    ''' <returns>EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function ListaPeriodos() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "SELECT pnom_PeriodoNomId as Id, ltrim(rtrim(upper(pnom_Concepto))) AS Concepto" +
            ", pnom_FechaInicial as FInicial" +
            ", pnom_FechaFinal as FFinal " +
            " from Nomina.PeriodosNomina  as pnom ORDER BY pnom.pnom_FechaInicial "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaPeriodosDescendentePeriodoActivo(ByVal IdNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "SELECT pnom_PeriodoNomId as Id, ltrim(rtrim(upper(pnom_Concepto))) AS Concepto, pnom_FechaInicial as FInicial," +
            " pnom_FechaFinal as FFinal from Nomina.PeriodosNomina  WHERE pnom_FechaInicial <= (SELECT pnom_FechaInicial FROM Nomina.PeriodosNomina" +
            " WHERE pnom_stPeriodoNomina = 'A' and pnom_NaveId = " + IdNave.ToString + ") and pnom_NaveId = " + IdNave.ToString + " ORDER BY pnom_FechaInicial DESC"
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    ''' <summary>
    ''' TRAE PERIODO, CELULA Y CANTIDAD DE PARES REALIZADOS FILTRADOS POR EL PERIODO Y LA ANVE
    ''' </summary>
    ''' <param name="IdNave">ID NAVE A CONSULTAR</param>
    ''' <param name="IdPeriodos">ID PERIODO A CONSULTAR</param>
    ''' <returns>EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function listaDestajos(ByVal IdNave As Integer, ByVal IdPeriodos As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "select pr.prnom_produccionid as IdProdNom, Pr.prnom_periodonominaid as IdPeriodo" +
            ", ltrim(rtrim(upper(pn.pnom_Concepto))) as Periodo, pn.pnom_FechaInicial as FInicial, pn.pnom_FechaFinal as FFinal " +
            ", ltrim(rtrim(upper(pn.pnom_stPeriodoNomina))) as Activo, pr.prnom_celulaid as IdCelula " +
            ", ltrim(rtrim(upper(ce.celu_nombre ))) as Celula,ltrim(rtrim (upper(gp.grup_name))) as Departamento,LTRIM(RTRIM(UPPER(gp.grup_grupoid))) AS DepartamentoID, pr.prnom_totalparesCapturados as Pares " +
            "from Nomina.ProduccionNomina as pr " +
            "join Nomina.PeriodosNomina pn on pn.pnom_PeriodoNomId = pr.prnom_periodonominaid " +
            "join Nomina.Celulas as ce on pr.prnom_celulaid = ce.celu_celulaid join Framework.Grupos gp on gp.grup_grupoid = ce.celu_grupoid"
        'If IdNave > 0 Then
        consulta = consulta + "  and gp.grup_naveid =" + IdNave.ToString
        'End If
        If IdPeriodos > 0 Then
            consulta = consulta + " and pr.prnom_periodonominaid=" + IdPeriodos.ToString
        End If

        Return operaciones.EjecutaConsulta(consulta)


    End Function


    ''' <summary>
    ''' RECUPERA LOS DATOS DE UN REGISTRO DE NOMINA.PRODUCCIONNOMINA POR ID
    ''' </summary>
    ''' <param name="IdProduccion"></param>
    ''' <returns>DATOS DEL REGISTRO SELECCIONADO</returns>
    ''' <remarks></remarks>
    Public Function RecuperarProduccion(ByVal IdProduccion As Integer)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "SELECT prnom_periodonominaid as Id" +
            ", prnom_sandalia as NSandalia" +
            ", prnom_costosandalia as CSandalia" +
            ", prnom_choclo as NChoclo" +
            ",  prnom_costochoclo as CChoclo" +
            ", prnom_botin as NBotin" +
            ", prnom_costobotin as CBotin, prnom_mediabota as NMediaBota, prnom_costomediabota as CMediaBota" +
            ", prnom_botaalta as NBotaAlta, prnom_costobotaalta as CBotaALta, prnom_totalparesEmbarcados as ParesEmbarcados" +
            ", prnom_celulaid as IdCelula, prnom_periodonominaid as IdPeriodo, prnom_totalparesCapturados as ParesCapturados " +
            " FROM Nomina.ProduccionNomina where prnom_produccionid = " + IdProduccion.ToString + ""
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function RecuperarPeriodo(ByVal IdPeriodo As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "SELECT  ltrim(rtrim(upper(pnom_Concepto))) AS Concepto" +
            ", pnom_FechaInicial as FInicial" +
            ", pnom_FechaFinal as FFinal " +
            " from Nomina.PeriodosNomina where pnom_PeriodoNomId =" + IdPeriodo.ToString + " ORDER BY pnom_FechaInicial "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' CONSULTA EL PERIODO ACTIVO DE UNA NAVE DETERMINADA
    ''' </summary>
    ''' <param name="IdNave">ID DE LA NAVE A RECUPERAR EL PERIODO</param>
    ''' <returns>PERIODO DE LA NAVE SELECCIONADA</returns>
    ''' <remarks></remarks>
    Public Function ListaPeriodoPorNave(ByVal IdNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "SELECT pnom_PeriodoNomId as Id,  ltrim(rtrim(upper(pnom_Concepto))) AS Concepto, pnom_FechaInicial AS Inicial, pnom_FechaFinal as Finial from nomina.PeriodosNomina" +
            " where pnom_NaveId=" + IdNave.ToString + " and pnom_stPeriodoNomina='A' "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LOS REGISTROS DE LAS CELULAS QUE CONTIENE CADA NAVE
    ''' </summary>
    ''' <param name="IdNave">ID DE LA NAVE A RECUPERAR LOS DATOS</param>
    ''' <returns>LISTA DE CELULAS</returns>
    ''' <remarks></remarks>
    Public Function ListaCelulasPorNave(ByVal IdNave As Integer, ByVal Modificar As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "select a.celu_celulaid as Id, a.celu_nombre as Celula, b.grup_name as Grupo  from Nomina.Celulas as a join Framework.Grupos as b on a.celu_grupoid=b.grup_grupoid join Nomina.Areas as c on c.area_areaid=b.grup_areaid" +
            " join Framework.Naves as d on d.nave_naveid=c.area_naveid where d.nave_naveid=" + IdNave.ToString + " and a.celu_activo = 1 "
        If Modificar = True Then
            consulta = consulta + " and b.grup_activo = 1"
        End If
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' EJECUTA EL PROCEDIMIENTO ALMACENADO PARA DAR DE ALTA EL REGISTRO DE PRODUCCION DE UNA CELULA
    ''' </summary>
    ''' <param name="Produccion">VARIABLES DE LA CLASE Entidades.NominaDestajos QUE CONTIENEN LOS DATOS A REGISTRAR</param>
    ''' <remarks></remarks>
    Public Sub AltaProduccion(ByVal Produccion As Entidades.NominaDestajos)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdPeriodoNomina"
        parametro.Value = Produccion.PIdPeriodo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NSandalia"
        parametro.Value = Produccion.PNSandalia
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CSandalia"
        parametro.Value = Produccion.PCSandalia
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NChoclo"
        parametro.Value = Produccion.PNChoclo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CChoclo"
        parametro.Value = Produccion.PCChoclo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NBotin"
        parametro.Value = Produccion.PNBotin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CBotin"
        parametro.Value = Produccion.PCBotin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NMediaBota"
        parametro.Value = Produccion.PNMediaBota
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CMediaBota"
        parametro.Value = Produccion.PCMediaBota
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NBotaAlata"
        parametro.Value = Produccion.PNBotaALta
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CBotalAlta"
        parametro.Value = Produccion.PCBotalAlta
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ParesEmbarcados"
        parametro.Value = Produccion.PParesEMbarcados
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@paresCapturados"
        parametro.Value = Produccion.PParesCapturados
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdCelula"
        parametro.Value = Produccion.PIdCelula
        listaparametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@dias_usuariocreoid"
        'parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        'listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_Alta_Produccion_Nomina_Destajo", listaparametros)
    End Sub

    ''' <summary>
    ''' EJECUTA EL PROCEDIMIENTO ALMACENADO PARA ACTUALIZAR UN REGISTRO DE LA PRODUCCION DE UNA NAVE
    ''' </summary>
    ''' <param name="Produccion">VARIABLES DE LA CALSE Entidades.NominaDestajos QUE CONTIENE LOS DATOS QUE SE ACTUALIZARAN</param>
    ''' <remarks></remarks>
    Public Sub EditarProduccion(ByVal Produccion As Entidades.NominaDestajos)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdPeriodoNomina"
        parametro.Value = Produccion.PIdPeriodo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdProduccionNomina"
        parametro.Value = Produccion.PIdProdNom
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NSandalia"
        parametro.Value = Produccion.PNSandalia
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CSandalia"
        parametro.Value = Produccion.PCSandalia
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NChoclo"
        parametro.Value = Produccion.PNChoclo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CChoclo"
        parametro.Value = Produccion.PCChoclo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NBotin"
        parametro.Value = Produccion.PNBotin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CBotin"
        parametro.Value = Produccion.PCBotin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NMediaBota"
        parametro.Value = Produccion.PNMediaBota
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CMediaBota"
        parametro.Value = Produccion.PCMediaBota
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NBotaAlata"
        parametro.Value = Produccion.PNBotaALta
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CBotalAlta"
        parametro.Value = Produccion.PCBotalAlta
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ParesEmbarcados"
        parametro.Value = Produccion.PParesEMbarcados
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@paresCapturados"
        parametro.Value = Produccion.PParesCapturados
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdCelula"
        parametro.Value = Produccion.PIdCelula
        listaparametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@dias_usuariocreoid"
        'parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        'listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_Editar_Produccion_Nomina_Destajo", listaparametros)

    End Sub

    ''' <summary>
    ''' RECUPERA EL TOTAL REGISTRADO DE PARES ENBARCADOS EN UNA NAVE
    ''' </summary>
    ''' <param name="idnave">ID NAVE SICY</param>
    ''' <param name="idcelula">IDCELULA SICY</param>
    ''' <param name="fechainicial">FECHA INICIAL DEL PERIODO</param>
    ''' <param name="fechafinal">FECHA FINAL DEL PERIODO</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PorBantaTotalLotes(ByVal idnave As Integer, ByVal idcelula As Integer, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        'Select SUM(pares) as pares from lotesAvances as a where IdCelula=" + idcelula.ToString + " and Estado='C'"
        '       consulta += " and a.FechaAvance between '" + fechainicial + "' and '" + fechafinal + "'"
        '       consulta += "and Nave=" + idnave.ToString
        consulta += " Select SUM(a.pares) as pares from lotesAvances as a"
        consulta += " join lotes as b on a.Lote=b.Lote and a.Año=b.Año and a.Nave=b.Nave"
        consulta += " where IdCelula=" + idcelula.ToString
        consulta += " and Estado='C'"
        consulta += " and b.Fecha_Salida between '" + fechainicial.ToShortDateString + " 00:01' and '" + fechafinal.ToShortDateString + " 23:59'"
        consulta += " and a.Nave=" + idnave.ToString
        ''+ " and Año=" + anio.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA EL ID DE LA NAVE DE LA BASE DE DATOS DEL SICY
    ''' </summary>
    ''' <param name="IdnaveSay">ID NAVE EN LA BASE DEL DATOS SAY</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RecuperarIdNaveSicy(ByVal IdnaveSay As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "select nave_navesicyid  from Framework.naves where nave_naveid =" + IdnaveSay.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA EL ID DE LA CELULA EN LA BASE DE DATOS DEL SICY
    ''' </summary>
    ''' <param name="IdCelulaSay">IDCELULA DE LA BASE DE DATOS DEL SAY</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RecuperarIdCelulaSicy(ByVal IdCelulaSay As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "select celu_idcelulasicy from nomina.Celulas where celu_celulaid =" + IdCelulaSay.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA EL ID DE LA NAVE EN LA BASE DE DATOS DEL SAY
    ''' </summary>
    ''' <param name="IdCelula">IDCELULA SAY</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RecuperarIdNave(ByVal IdCelula As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "select a.nave_naveid from Framework.Naves as a" +
            " where a.nave_naveid in (select b.grup_naveid from Framework.Grupos b where b.grup_grupoid in " +
            " (select c.celu_grupoid from nomina.Celulas c where c.celu_celulaid =" + IdCelula.ToString + "))"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' CONSULTA SI EXISTE UN REGISTRO DE PRODUCCION PARA UNA CELULA, UN PERIORO Y UNA NAVE EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdCelula"> ID DE LA CELULA A VERIFICAR</param>
    ''' <param name="IdPeriodo"> ID DEL PERIODO A VERIFICAR</param>
    ''' <param name="IdNave"> ID DE LA NAVE A VERIFICAR</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function ValidarRegistro(ByVal IdCelula As Integer, ByVal IdPeriodo As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "SELECT prnom_produccionid as id from Nomina.ProduccionNomina where prnom_periodonominaid = " + IdPeriodo.ToString +
            " and prnom_celulaid =" + IdCelula.ToString + ""
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function


    ''' <summary>
    ''' FUNCION QUE EJECUTA LA CONSULTA PARA RECUPERAR TODOS LOS ID'S DE LAS CELULAS PERTENECIENTES A UNA NAVE 
    ''' </summary>
    ''' <param name="IdNaveSay">ID DE LA NAVE EN LA BASE DE DATOS DEL SAY</param>
    ''' <returns>RECULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarCelulasDeLaNave(ByVal IdNaveSay As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "SELECT a.celu_celulaid FROM Nomina.Celulas AS a" +
            " JOIN Framework.Grupos AS b ON a.celu_grupoid = b.grup_grupoid" +
            " JOIN Nomina.Areas AS c ON c.area_areaid = b.grup_areaid" +
            " JOIN Framework.Naves AS d ON d.nave_naveid = c.area_naveid" +
            " WHERE d.nave_naveid = " + IdNaveSay.ToString +
            " AND a.celu_activo = 1"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' EJECUTA LA CONSULTA PARA RECUPERAR EL ULTIMO REGISTRO DE PRODUCCION PARA UN PERIODO DETERMINADO Y UNA NAVE DETERMINADA
    ''' </summary>
    ''' <param name="IdPeriodo">ID DEL PERIODO DEL CUAL SE RECUPERARA LA INFORMACION</param>
    ''' <param name="IdsCelulas">IDENTIFICADORES DE LAS CELULAS PERTENECIENTES A LA NAVE DE LA QUE SE QUIERE RECUPERAR LA INFORMACION</param>
    ''' <returns>DATATABLE CON EL RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarUltimaProduccion(ByVal IdPeriodo As Integer, ByVal IdsCelulas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "select top 1 prnom_sandalia as 'Sandalia',prnom_costosandalia as 'Costo Sandalia',prnom_choclo as 'Choclo',prnom_costochoclo as 'Costo Choclo'," +
            " prnom_botin as 'Botin', prnom_costobotin as 'Costo Botin', prnom_mediabota as 'Media Bota', prnom_costomediabota as 'Costo Media Bota'," +
            " prnom_botaalta as 'Bota Alta', prnom_costobotaalta as 'Costo Bota Alta'" +
            " From nomina.ProduccionNomina where prnom_periodonominaid = " + IdPeriodo.ToString + " and prnom_celulaid in (" + IdsCelulas + ") order by prnom_produccionid desc"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

End Class
