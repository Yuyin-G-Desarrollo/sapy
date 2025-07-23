
Public Class NominaDestajosBU


    ''' <summary>
    ''' CONSULTA LA LISTA DE PERIODOS DE NOMINA OBTENIENDO EL ID DEL PERIODO Y EL CONCEPTO
    ''' </summary>
    ''' <returns>LISTA PERIODOS DE NOMINA</returns>
    ''' <remarks></remarks>
    Public Function ListaPeriodos() As List(Of Entidades.PeriodosNomina)
        Dim objPeriodosDA As New Datos.NominaDestajosDA
        Dim dtPeriodos As New DataTable
        ListaPeriodos = New List(Of Entidades.PeriodosNomina)
        dtPeriodos = objPeriodosDA.ListaPeriodos()
        For Each fila As DataRow In dtPeriodos.Rows
            Dim TodosLosPeriodos As New Entidades.PeriodosNomina
            TodosLosPeriodos.PPeriodoId = CInt(fila("Id"))
            TodosLosPeriodos.PConcepto = CStr(fila("Concepto")).ToUpper
            ListaPeriodos.Add(TodosLosPeriodos)
        Next
        Return ListaPeriodos
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListaPeriodosDesendentePeriodoActual(ByVal IdNave As Integer) As List(Of Entidades.PeriodosNomina)
        Dim objPeriodosDA As New Datos.NominaDestajosDA
        Dim dtPeriodos As New DataTable
        ListaPeriodosDesendentePeriodoActual = New List(Of Entidades.PeriodosNomina)
        dtPeriodos = objPeriodosDA.ListaPeriodosDescendentePeriodoActivo(IdNave)
        For Each fila As DataRow In dtPeriodos.Rows
            Dim TodosLosPeriodos As New Entidades.PeriodosNomina
            TodosLosPeriodos.PPeriodoId = CInt(fila("Id"))
            TodosLosPeriodos.PConcepto = CStr(fila("Concepto")).ToUpper
            ListaPeriodosDesendentePeriodoActual.Add(TodosLosPeriodos)
        Next
        Return ListaPeriodosDesendentePeriodoActual
    End Function

    ''' <summary>
    ''' CONECTA CON DA PARA ONTENER LOS DATOS PARA LLENAR LA TABLA DE PRODUCCION
    ''' </summary>
    ''' <param name="IdNave">ID NAVE</param>
    ''' <param name="IdPeriodo">ID PERIODO</param>
    ''' <returns>TABLA CON LOS DATOS PARA LLENAR EL GRID EN LA CAPA VISTA</returns>
    ''' <remarks></remarks>
    Public Function TablaProduccion(ByVal IdNave As Integer, ByVal IdPeriodo As Integer) As DataTable
        Dim objTablaProduccionDA As New Datos.NominaDestajosDA
        TablaProduccion = objTablaProduccionDA.listaDestajos(IdNave, IdPeriodo)
        Return TablaProduccion
    End Function

    ''' <summary>
    ''' RECUPERA LA LISTA DE LOS PERIODOS ACTIVOS POR NAVE
    ''' </summary>
    ''' <param name="IdNave">ID DE LA NAVE A RECUPERAR LOS PERIODOS</param>
    ''' <returns>LISTA DE LOS PERIODOS ACTIVOS</returns>
    ''' <remarks></remarks>
    Public Function ListaPeriodoActivoPorNave(ByVal IdNave As Integer) As List(Of Entidades.PeriodosNomina)
        Dim objPeriodosDA As New Datos.NominaDestajosDA
        Dim dtPeriodos As New DataTable
        ListaPeriodoActivoPorNave = New List(Of Entidades.PeriodosNomina)
        dtPeriodos = objPeriodosDA.ListaPeriodoPorNave(IdNave)
        For Each fila As DataRow In dtPeriodos.Rows
            Dim TodosLosPeriodos As New Entidades.PeriodosNomina
            TodosLosPeriodos.PPeriodoId = CInt(fila("Id"))
            TodosLosPeriodos.PConcepto = CStr(fila("Concepto")).ToUpper
            ListaPeriodoActivoPorNave.Add(TodosLosPeriodos)
        Next
        Return ListaPeriodoActivoPorNave
    End Function

    ''' <summary>
    ''' RECUPERA LA LISTA DE LAS CELULAS PERTENECIENTES A CIERTA NAVE
    ''' </summary>
    ''' <param name="IdNave">IDNAVE A LA CUAL PERTENECEN LAS CELULAS A RECUPERAR</param>
    ''' <returns>LISTA DE LAS CELULAS PERTENECIENTES A LA NAVE SELECCIONADA</returns>
    ''' <remarks></remarks>
    Public Function ListaCelulasporNave(ByVal IdNave As Integer, ByVal Modificar As Boolean) As List(Of Entidades.Celulas)
        Dim objCelulasDA As New Datos.NominaDestajosDA
        Dim dtCelulas As New DataTable
        ListaCelulasporNave = New List(Of Entidades.Celulas)
        dtCelulas = objCelulasDA.ListaCelulasPorNave(IdNave, Modificar)
        For Each fila As DataRow In dtCelulas.Rows
            Dim CelulasPorNave As New Entidades.Celulas
            CelulasPorNave.PCelulaid = CInt(fila("Id"))
            CelulasPorNave.PNombre = CStr(fila("Celula")).ToUpper
            ListaCelulasporNave.Add(CelulasPorNave)
        Next
        Return ListaCelulasporNave
    End Function

    Public Function ListaCelulasMasDepartamentoPorNave(ByVal IdNave As Integer, ByVal modificar As Boolean) As List(Of Entidades.Celulas)
        Dim objCelulasDA As New Datos.NominaDestajosDA
        Dim dtCelulas As New DataTable
        ListaCelulasMasDepartamentoPorNave = New List(Of Entidades.Celulas)
        dtCelulas = objCelulasDA.ListaCelulasPorNave(IdNave, modificar)
        For Each fila As DataRow In dtCelulas.Rows
            Dim CelulasPorNave As New Entidades.Celulas
            CelulasPorNave.PCelulaid = CInt(fila("Id"))
            CelulasPorNave.PNombre = CStr(fila("Celula")).ToUpper
            CelulasPorNave.PNombreD = CStr(fila("Celula")).ToUpper + ",  DEPTO.- " + CStr(fila("Grupo")).ToUpper
            ListaCelulasMasDepartamentoPorNave.Add(CelulasPorNave)
        Next
        Return ListaCelulasMasDepartamentoPorNave
    End Function


    ''' <summary>
    ''' CINECTA CON DATOS PARA EJECUTAR EL PROCEDIMIENTO ALMACENADO PARA DAR DE ALTA UN REGISTRO DE PRODUCCIONNOMINA
    ''' </summary>
    ''' <param name="NominaDestajos">CLASE DE LA CAPA ENTIDADES "NOMINADESTAJOS" CON LOS DATOS A REGISTRAR EN LA BASE DE DATOS</param>
    ''' <remarks></remarks>
    Public Sub AltaProduccion(ByVal NominaDestajos As Entidades.NominaDestajos)
        Dim objProduccionDA As New Datos.NominaDestajosDA
        objProduccionDA.AltaProduccion(NominaDestajos)
    End Sub

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA EJECUTAR EL PROCEDIMIENTO ALMACENADO PARA MODIFICAR UN REGISTR DE PRODICCIONCELULA
    ''' </summary>
    ''' <param name="NominaDestajos">CLASE DE LA CAPA ENTIDADES "NOMINADESTAJOS" CON LOS DATOS A ACTUALIZAR EN LA BASE DE DATOS</param>
    ''' <remarks></remarks>
    Public Sub ModificarProduccion(ByVal NominaDestajos As Entidades.NominaDestajos)
        Dim objProduccionDA As New Datos.NominaDestajosDA
        objProduccionDA.EditarProduccion(NominaDestajos)
    End Sub

    ''' <summary>
    ''' RECUPERA LA FECHA INICIAL Y LA FECHA FINAL DE UN PERIODO
    ''' </summary>
    ''' <param name="IdPeriodo">ID PERIODO DEL CUAL SE RECUPERARAN LAS FECHAS</param>
    ''' <returns>FECCHA INICIAL Y FECHA FINAL DEL PERIODO</returns>
    ''' <remarks></remarks>
    Public Function RecuperarFechas(ByVal IdPeriodo As Integer) As List(Of Entidades.NominaDestajos)
        Dim objRepuperarFechaDA As New Datos.NominaDestajosDA
        Dim tabla As New DataTable
        tabla = objRepuperarFechaDA.RecuperarPeriodo(IdPeriodo)
        RecuperarFechas = New List(Of Entidades.NominaDestajos)
        For Each fila As DataRow In tabla.Rows
            Dim RecuperarFecha As New Entidades.NominaDestajos
            RecuperarFecha.PFechaInicial = CDate(fila("FInicial"))
            RecuperarFecha.PFechaFinal = CDate(fila("FFinal"))
            RecuperarFechas.Add(RecuperarFecha)
        Next
        Return RecuperarFechas
    End Function

    ''' <summary>
    ''' RECUPERA EL ID DE LA NAVE EN LA BASE DE DATOS DEL SICY
    ''' </summary>
    ''' <param name="IdNAve">ID DE LA NAVE</param>
    ''' <returns>ID DE LA NAVE EN LA BASE DE DATOS DEL SICY</returns>
    ''' <remarks></remarks>
    Public Function RecuperarIdNavesSicy(ByVal IdNAve As Integer) As List(Of Entidades.NominaDestajos)
        Dim objRecuperarIdNaveSicyDA As New Datos.NominaDestajosDA
        Dim tabla As New DataTable
        tabla = objRecuperarIdNaveSicyDA.RecuperarIdNaveSicy(IdNAve)
        RecuperarIdNavesSicy = New List(Of Entidades.NominaDestajos)
        For Each fila As DataRow In tabla.Rows
            Dim recuperarId As New Entidades.NominaDestajos
            recuperarId.PIdNaveSicy = CInt(fila("nave_navesicyid"))
            RecuperarIdNavesSicy.Add(recuperarId)
        Next
        Return RecuperarIdNavesSicy
    End Function

    ''' <summary>
    ''' RECUPERA EL ID DE LA CELULA EN LA BASE DE DATOS DEL SICY
    ''' </summary>
    ''' <param name="IdCelula">ID CELULA EN LA BASE DE DATOS DE SAY</param>
    ''' <returns>ID CELULA SICY</returns>
    ''' <remarks></remarks>
    Public Function RecuperarIdCelulaSicy(ByVal IdCelula As Integer) As List(Of Entidades.NominaDestajos)
        Dim objRecuperarIdCelulaSicyDA As New Datos.NominaDestajosDA
        Dim tabla As New DataTable
        tabla = objRecuperarIdCelulaSicyDA.RecuperarIdCelulaSicy(IdCelula)
        RecuperarIdCelulaSicy = New List(Of Entidades.NominaDestajos)
        For Each fila As DataRow In tabla.Rows
            Dim recuperarId As New Entidades.NominaDestajos
            recuperarId.PIdCelulaSicy = CInt(fila("celu_idcelulasicy"))
            RecuperarIdCelulaSicy.Add(recuperarId)
        Next
        Return RecuperarIdCelulaSicy
    End Function

    ''' <summary>
    ''' RECUPERA EL ID DE LA NAVE DE CIERTA CELULA
    ''' </summary>
    ''' <param name="IdCelula">ID CELULA DE LA CUAL SE RECUPERARA EL ID DE LA NACE</param>
    ''' <returns>ID NAVE</returns>
    ''' <remarks></remarks>
    Public Function RecuperarIdNave(ByVal IdCelula As Integer) As List(Of Entidades.NominaDestajos)
        Dim objRecuperarIdNaveDA As New Datos.NominaDestajosDA
        Dim tabla As New DataTable
        tabla = objRecuperarIdNaveDA.RecuperarIdNave(IdCelula)
        RecuperarIdNave = New List(Of Entidades.NominaDestajos)
        For Each fila As DataRow In tabla.Rows
            Dim recuperarId As New Entidades.NominaDestajos
            recuperarId.PIdNave = CInt(fila("nave_naveid"))
            RecuperarIdNave.Add(recuperarId)
        Next
        Return RecuperarIdNave
    End Function

    ''' <summary>
    ''' RECUPERA LOS DATOS DE UN REGISTR DE PRODUCCION
    ''' </summary>
    ''' <param name="IdProduccion">ID DEL REGISTRO DE PRODUCCIONNOMINA DEL CUAL SE RECUPERARAN LOS DATOS</param>
    ''' <returns>DATOS DEL REGISTRO</returns>
    ''' <remarks></remarks>
    Public Function RecuperarProduccion(ByVal IdProduccion) As List(Of Entidades.NominaDestajos)
        Dim objRepuperarProduccionDA As New Datos.NominaDestajosDA
        Dim tabla As New DataTable
        tabla = objRepuperarProduccionDA.RecuperarProduccion(IdProduccion)
        RecuperarProduccion = New List(Of Entidades.NominaDestajos)
        For Each fila As DataRow In tabla.Rows
            Dim recuperar As New Entidades.NominaDestajos
            recuperar.PIdProdNom = CInt(fila("Id"))
            recuperar.PNSandalia = CInt(fila("NSandalia"))
            recuperar.PCSandalia = CDbl(fila("CSandalia"))
            recuperar.PNChoclo = CInt(fila("NChoclo"))
            recuperar.PCChoclo = CDbl(fila("CChoclo"))
            recuperar.PNBotin = CInt(fila("NBotin"))
            recuperar.PCBotin = CDbl(fila("CBotin"))
            recuperar.PNMediaBota = CInt(fila("NMediaBota"))
            recuperar.PCMediaBota = CDbl(fila("CMediaBota"))
            recuperar.PNBotaALta = CInt(fila("NBotaAlta"))
            recuperar.PCBotalAlta = CDbl(fila("CBotaALta"))
            recuperar.PParesEMbarcados = CInt(fila("ParesEmbarcados"))
            recuperar.PIdCelula = CInt(fila("IdCelula"))
            recuperar.PParesCapturados = CInt(fila("ParesCapturados"))
            recuperar.PIdPeriodo = CInt(fila("IdPeriodo"))
            RecuperarProduccion.Add(recuperar)
        Next
        Return RecuperarProduccion
    End Function

    ''' <summary>
    ''' RECUPERA EL TOTAL DE DATOS EMBARCADOS DE LA PRODUCCION DE UNA BANDA DE LA BASE DE DATOS DEL SICY
    ''' </summary>
    ''' <param name="idnave">ID NAVE</param>
    ''' <param name="idcelula">ID CELULA</param>
    ''' <param name="fechainicial">FECHA INICIAL DE PERIODO</param>
    ''' <param name="fechafinal">DECHA FINAL DEL PERIODO</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PorBantaTotalLotes(ByVal idnave As Integer, ByVal idcelula As Integer, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As List(Of Entidades.NominaDestajos)
        Dim objRecuperarTotal As New Datos.NominaDestajosDA
        Dim tabla As New DataTable
        tabla = objRecuperarTotal.PorBantaTotalLotes(idnave, idcelula, fechainicial, fechafinal)
        PorBantaTotalLotes = New List(Of Entidades.NominaDestajos)
        For Each fila As DataRow In tabla.Rows
            Dim RecuperarPares As New Entidades.NominaDestajos
            Try
                If (fila("pares").ToString) = "" Then
                    RecuperarPares.PParesEMbarcados = 0
                    PorBantaTotalLotes.Add(RecuperarPares)
                Else
                    RecuperarPares.PParesEMbarcados = Int(fila("pares"))
                    PorBantaTotalLotes.Add(RecuperarPares)
                End If
            Catch ex As Exception

            End Try

        Next
        Return PorBantaTotalLotes
    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA VERIFICAR SI EXISTE UNR EGISTRO DE PRODCUCCION PARA UNA CELULA, UNA NAVE Y UN PERIODO
    ''' EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdCelula"> ID DE LA CELULA A VERIFICAR</param>
    ''' <param name="IdPeriodo"> ID DE PERIODO A VERIFICAR</param>
    ''' <param name="IdNave"> ID DE LA ANVE A VEFICAR</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidarRegistroExistente(ByVal IdCelula As Integer, ByVal IdPeriodo As Integer, ByVal IdNave As Integer)
        Dim objValidarRegistroDA As New Datos.NominaDestajosDA
        Dim tabla As DataTable
        tabla = objValidarRegistroDA.ValidarRegistro(IdCelula, IdPeriodo, IdNave)
        ValidarRegistroExistente = New List(Of Entidades.NominaDestajos)
        For Each fila As DataRow In tabla.Rows
            Dim recuperar As New Entidades.NominaDestajos
            If fila("Id").ToString = "" Then
                recuperar.PIdProdNom = 0
                ValidarRegistroExistente.add(recuperar)
            Else
                recuperar.PIdProdNom = CInt(fila("Id"))
                ValidarRegistroExistente.add(recuperar)
            End If
            
        Next
        Return ValidarRegistroExistente
    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA CONSULTAR LOS IDS DE LAS CELULAS PERTENECIENTES A UNA NAVE
    ''' </summary>
    ''' <param name="IdNaveSay"> ID DE LA NAVE EN EL SAY A VERIFICAR</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarCelulasDeLaNave(ByVal IdNaveSay As Integer)
        Dim objDA As New Datos.NominaDestajosDA
        Dim dtIdDepartamentos As New DataTable

        dtIdDepartamentos = objDA.RecuperarCelulasDeLaNave(IdNaveSay)

        Return dtIdDepartamentos
    End Function


    Public Function RecuperarUltimaProduccion(ByVal IdPEriodo As Integer, ByVal IdsCelulas As String) As Entidades.NominaDestajos
        Dim Produccion As New Entidades.NominaDestajos
        Dim objDA As New Datos.NominaDestajosDA
        Dim dtPeriodoGuardado As New DataTable

        dtPeriodoGuardado = objDA.RecuperarUltimaProduccion(IdPEriodo, IdsCelulas)

        For Each row As DataRow In dtPeriodoGuardado.Rows
            Produccion.PNSandalia = dtPeriodoGuardado.Rows(0).Item("Sandalia")
            Produccion.PCSandalia = dtPeriodoGuardado.Rows(0).Item("Costo Sandalia")
            Produccion.PNChoclo = dtPeriodoGuardado.Rows(0).Item("Choclo")
            Produccion.PCChoclo = dtPeriodoGuardado.Rows(0).Item("Costo Choclo")
            Produccion.PNBotin = dtPeriodoGuardado.Rows(0).Item("Botin")
            Produccion.PCBotin = dtPeriodoGuardado.Rows(0).Item("Costo Botin")
            Produccion.PNMediaBota = dtPeriodoGuardado.Rows(0).Item("Media Bota")
            Produccion.PCMediaBota = dtPeriodoGuardado.Rows(0).Item("Costo Media Bota")
            Produccion.PNBotaALta = dtPeriodoGuardado.Rows(0).Item("Bota Alta")
            Produccion.PCBotalAlta = dtPeriodoGuardado.Rows(0).Item("Costo Bota Alta")
        Next

        Return Produccion
    End Function

End Class
