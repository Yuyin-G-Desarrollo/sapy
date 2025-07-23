Imports System.Data.SqlClient
Imports Persistencia
''' <summary>
''' Charly was here
''' </summary>
''' <remarks></remarks>
Public Class LotesAvancesDA
    Public Function ListaLotesAvances(ByVal vNave As Int32, ByVal vBuscaFechaLote As Byte, ByVal vFechaLoteIni As DateTime, ByVal vFechaLoteFin As DateTime,
                                     ByVal vEstatus As String, ByVal vNoLote As Int32, ByVal vDepto As Int32, ByVal vCelula As Int32, ByVal vBuscaFechaAva As Byte,
                                     ByVal vFechaAvaIni As DateTime, ByVal vFechaAvaFin As DateTime) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter("@gNave", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@gBuscaFechaLote", SqlDbType.Bit)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vBuscaFechaLote
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@gFechaLoteIni", SqlDbType.DateTime)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = FormatDateTime(vFechaLoteIni, DateFormat.ShortDate)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@gFechaLoteFin", SqlDbType.DateTime)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = FormatDateTime(vFechaLoteFin, DateFormat.ShortDate)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@gEstatus", SqlDbType.VarChar)
        parametro.Size = 15
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vEstatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@gNoLote", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vNoLote
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@gDepto", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vDepto
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@gCelula", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vCelula
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@gBuscaFechaAva", SqlDbType.Bit)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vBuscaFechaAva
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@gFechaAvaIni", SqlDbType.DateTime)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = FormatDateTime(vFechaAvaIni, DateFormat.ShortDate)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@gFechaAvaFin", SqlDbType.DateTime)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = FormatDateTime(vFechaAvaFin, DateFormat.ShortDate)
        listaParametros.Add(parametro)

        'Return operaciones.EjecutaConsulta("Exec SP_lista_AvancesProduccionV2 " & vNave & ",'" & FormatDateTime(vFechaLoteIni, DateFormat.ShortDate) & "','" & FormatDateTime(vFechaLoteFin, DateFormat.ShortDate) & "','" & vEstatus & "'," & vNoLote & "," & vDepto & "," & vCelula & "," & vBuscaFechaAva & ",'" & FormatDateTime(vFechaAvaIni, DateFormat.ShortDate) & "','" & FormatDateTime(vFechaAvaFin, DateFormat.ShortDate) & "'")
        Return operaciones.EjecutarConsultaSP("SP_lista_AvancesProduccionV2", listaParametros)

    End Function

    Public Sub GuardarObsLoteAvence(ByVal Lote As Entidades.Lote)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY

        Dim consulta As String = ""

        consulta = "UPDATE LOTES SET Observacion = '" + Lote.PLoteObservacion.ToString + "' WHERE Año = " + Lote.PLoteAño.ToString + " AND Nave = " + Lote.PLoteNave.ToString + " AND Lote = " + Lote.PLoteNumero.ToString

        operaciones.EjecutaSentencia(consulta)
    End Sub

    Public Function OtenerInfoLote(ByVal vAño As Int32, ByVal vNave As Int32, ByVal vLote As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String

        consulta = "SELECT l.Lote, l.Fecha, ISNULL(l.Fecha_Salida,'01/01/1900 00:00:00') as FechaEmbarque, e.Descripcion, t.Talla, " &
                   "CASE  " &
                   "WHEN la.IdCelula>0 THEN d.Departamento + ' (' + c.Celula + ')' " &
                   "ELSE d.Departamento END as Departamento,  " &
                   "la.FechaAvance, (emp.Nombre + ' ' + emp.ApellidoPaterno + ' ' + emp.ApellidoMaterno) as Empleado " &
                   "FROM  " &
                   "Lotes l INNER JOIN vEstilos e ON l.IdCodigo=e.IdCodigo INNER JOIN Tallas t ON l.IdTalla=t.IdTalla  " &
                   "LEFT JOIN LotesAvances la ON l.Año=la.Año AND l.Nave=la.Nave AND l.Lote=la.Lote  " &
                   "LEFT JOIN LotesAvancesConfigNaveDepto cnd ON la.IdConfiguracion=cnd.IdConfiguracion " &
                   "LEFT JOIN nmaDepartamentos d ON cnd.IdNave=d.Nave AND cnd.IdDepto=d.IdDepto " &
                   "LEFT JOIN nmaEmpleados emp ON la.IdEmpleado=emp.IdEmpleado " &
                   "LEFT JOIN nmaCelulas c ON d.Nave=c.Nave AND d.IdDepto=c.IdDepto AND la.IdCelula=c.IdCelula " &
                   "WHERE " &
                   "la.Estado='C' AND l.Año=" & vAño & " AND l.Nave=" & vNave & " AND l.Lote=" & vLote & " ORDER BY cnd.Orden"

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaAvancesProduccion(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Naveid As Int32, ByVal Departamentos As List(Of Entidades.DepartamentosProduccion)) As DataTable
        Dim opereciones As New Persistencia.OperacionesProcedimientosSICY
        Dim ultimoDepartamento As Integer = 0 'l.Color
        Dim consulta As String = "select L.Fecha, l.Lote,l.Año,vpet.PielColor 'Color', l.Pares, e.Marca,f.Coleccion,d.IdModelo,t.Talla, l.Observacion, "
        For Each dep As Entidades.DepartamentosProduccion In Departamentos
            consulta += " la" + dep.PIDConfiguracion.ToString + ".FechaAvance avanceDepartamento" + dep.PIDConfiguracion.ToString + ", map" + dep.PIDConfiguracion.ToString + ".Motivo motivoDepartamento" + dep.PIDConfiguracion.ToString + ",la" + dep.PIDConfiguracion.ToString + ".diasAtraso diasAtrasos" + dep.PIDConfiguracion.ToString + ", c" + dep.PIDConfiguracion.ToString + ".Celula Celula" + dep.PIDConfiguracion.ToString + ","
            'ultimoDepartamento = dep.PIDConfiguracion
        Next
        'If Departamentos.Count > 1 Then
        '    consulta += " la" + ultimoDepartamento.ToString + ".FechaAvance ProductoTerminado, "
        'End If
        consulta += " l.Fecha_Salida, l.Cliente_Texto from lotes AS l"
        For Each dep As Entidades.DepartamentosProduccion In Departamentos
            consulta += " left join LotesAvances la" + dep.PIDConfiguracion.ToString + " on l.Lote=la" + dep.PIDConfiguracion.ToString + ".Lote and l.Año=la" + dep.PIDConfiguracion.ToString + ".Año and l.Nave=la" + dep.PIDConfiguracion.ToString + ".Nave and la" + dep.PIDConfiguracion.ToString + ".IdConfiguracion=" + dep.PIDConfiguracion.ToString + ""
        Next
        For Each dep As Entidades.DepartamentosProduccion In Departamentos
            consulta += " left join MotivoAtrasosProduccion as map" + dep.PIDConfiguracion.ToString + " on map" + dep.PIDConfiguracion.ToString + ".idMotivo=la" + dep.PIDConfiguracion.ToString + ".idMotivo"
        Next
        For Each dep As Entidades.DepartamentosProduccion In Departamentos
            consulta += " left join nmaCelulas as c" + dep.PIDConfiguracion.ToString + " on c" + dep.PIDConfiguracion.ToString + ".IdCelula=la" + dep.PIDConfiguracion.ToString + ".IdCelula and c" + dep.PIDConfiguracion.ToString + ".Nave=la" + dep.PIDConfiguracion.ToString + ".Nave"
        Next
        consulta += " left JOIN Tallas AS t      ON (t.IdTalla = l.IdTalla)" +
        " left JOIN catProductos AS d       ON (d.IdProducto = l.IdCatProducto)" +
        " left JOIN Marcas AS e      ON (e.IdMarca = d.IdMarca)" +
        " left JOIN Colecciones AS f ON (f.IdColeccion = d.IdColeccion)" +
        "LEFT JOIN Programacion.vProductoEstilos_Completo vpet 	ON vpet.CodigoSicy = d.IdCodigo AND vpet.IdTallaSicy = d.IdCorrida 	AND vpet.CodigoPielColorSICY = LTRIM(RTRIM(d.IdPiel)) + LTRIM(RTRIM(d.IdColor))"

        consulta += " where l.nave=" + Naveid.ToString + "  and l.Fecha BETWEEN '" + FechaInicio + "'   and '" + FechaFin + "' and l.Pares IS NOT NULL /*AND vpet.EstatusDesarrollo <> 'I'*/  and vpet.pres_activo = 1 and vpet.StatusId not in (1,2,7) /*and la1.FechaAvance is not null and la2.FechaAvance is not null and la3.FechaAvance is not null*/  order by l.Lote"
        'Dim Consulta As String = " select a.Fecha, a.Lote, a.Año, a.Color, a.Pares, e.Marca, f.Coleccion, d.IdModelo, c.Talla, a.Observacion"
        'For Each dep As Entidades.DepartamentosProduccion In Departamentos
        '    Consulta += ",(select top (1) FechaAvance from LotesAvances as av where av.Lote=a.Lote and IdConfiguracion=" + dep.PIDConfiguracion.ToString + " and av.Estado='C'and av.Año=a.año ) as avanceDepartamento" + dep.PIDConfiguracion.ToString
        '    Consulta += ",	(ISnull((SELECT TOP (1) map.Motivo FROM LotesAvances AS av INNER JOIN MotivoAtrasosProduccion AS map ON map.idMotivo=av.idMotivo WHERE av.Lote = a.Lote	AND IdConfiguracion = " + dep.PIDConfiguracion.ToString + "	AND av.Estado = 'C'	AND av.Año = a.año),''))	AS motivoDepartamento" + dep.PIDConfiguracion.ToString
        '    Consulta += ",	(ISnull((SELECT TOP (1) diasAtraso FROM LotesAvances AS av  WHERE av.Lote = a.Lote	AND IdConfiguracion = " + dep.PIDConfiguracion.ToString + "	AND av.Estado = 'C'	AND av.Año = a.año),0))	AS diasAtrasos" + dep.PIDConfiguracion.ToString
        '    Consulta += " , (select top (1) Celula from nmaCelulas where Nave =" + Naveid.ToString + " and IdCelula= (select top (1) IdCelula from LotesAvances as av where av.Lote=a.Lote and IdConfiguracion=" + dep.PIDConfiguracion.ToString + " and (av.Estado='C' or av.Estado='P')and av.Año=a.Año)) as Celula" + dep.PIDConfiguracion.ToString
        'Next

        'Consulta += ",a.Fecha_Salida,a.Cliente_Texto from Lotes as a JOIN Tallas as c ON (c.IdTalla=a.IdTalla)"
        'Consulta += " JOIN catProductos as d ON (d.IdProducto=a.IdCatProducto) join Marcas as e on (e.IdMarca=d.IdMarca) join Colecciones as f on (f.IdColeccion=d.IdColeccion)"

        'Consulta += "where a.Nave=" + Naveid.ToString + " and (Año=" + FechaFin.Year.ToString + " or Año=" + FechaInicio.Year.ToString + ") and (a.Fecha between '" + FechaInicio + "'   and '" + FechaFin + "') and a.Pares is not null order by a.Lote"
        Return opereciones.EjecutaConsulta(consulta)
    End Function
    Public Function ListaAvancesProduccionDetallado(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Naveid As Int32, ByVal Departamentos As List(Of Entidades.DepartamentosProduccion)) As DataTable
        Dim opereciones As New Persistencia.OperacionesProcedimientosSICY
        'l.Color
        Dim consulta As String = "select L.Fecha, l.Lote,l.Año,vpet.PielColor 'Color', la.Cantidad Pares, e.Marca,f.Coleccion,d.IdModelo,t.Talla, l.Observacion, "
        For Each dep As Entidades.DepartamentosProduccion In Departamentos
            consulta += " la" + dep.PIDConfiguracion.ToString + ".FechaAvance avanceDepartamento" + dep.PIDConfiguracion.ToString + ", map" + dep.PIDConfiguracion.ToString + ".Motivo motivoDepartamento" + dep.PIDConfiguracion.ToString + ",la" + dep.PIDConfiguracion.ToString + ".diasAtraso diasAtrasos" + dep.PIDConfiguracion.ToString + ", c" + dep.PIDConfiguracion.ToString + ".Celula Celula" + dep.PIDConfiguracion.ToString + ","
        Next
        consulta += " l.Fecha_Salida, la.IdPedido,ca.nombre from lotes AS l"
        For Each dep As Entidades.DepartamentosProduccion In Departamentos
            consulta += " left join LotesAvances la" + dep.PIDConfiguracion.ToString + " on l.Lote=la" + dep.PIDConfiguracion.ToString + ".Lote and l.Año=la" + dep.PIDConfiguracion.ToString + ".Año and l.Nave=la" + dep.PIDConfiguracion.ToString + ".Nave and la" + dep.PIDConfiguracion.ToString + ".IdConfiguracion=" + dep.PIDConfiguracion.ToString + ""
        Next
        For Each dep As Entidades.DepartamentosProduccion In Departamentos
            consulta += " left join MotivoAtrasosProduccion as map" + dep.PIDConfiguracion.ToString + " on map" + dep.PIDConfiguracion.ToString + ".idMotivo=la" + dep.PIDConfiguracion.ToString + ".idMotivo"
        Next
        For Each dep As Entidades.DepartamentosProduccion In Departamentos
            consulta += " left join nmaCelulas as c" + dep.PIDConfiguracion.ToString + " on c" + dep.PIDConfiguracion.ToString + ".IdCelula=la" + dep.PIDConfiguracion.ToString + ".IdCelula and c" + dep.PIDConfiguracion.ToString + ".Nave=la" + dep.PIDConfiguracion.ToString + ".Nave"
        Next
        consulta += " left JOIN Tallas AS t      ON (t.IdTalla = l.IdTalla)" +
        " left JOIN catProductos AS d       ON (d.IdProducto = l.IdCatProducto)" +
        " left JOIN Marcas AS e      ON (e.IdMarca = d.IdMarca)" +
        " left JOIN Colecciones AS f ON (f.IdColeccion = d.IdColeccion)" +
         "LEFT JOIN Programacion.vProductoEstilos_Completo vpet 	ON vpet.CodigoSicy = d.IdCodigo AND vpet.IdTallaSicy = d.IdCorrida 	AND vpet.CodigoPielColorSICY = LTRIM(RTRIM(d.IdPiel)) + LTRIM(RTRIM(d.IdColor))"
        consulta += " LEFT JOIN LotesA la ON (la.NoLote=l.Lote) LEFT JOIN Pedidos p ON (p.IdPedido=la.IdPedido) LEFT JOIN Cadenas ca on (ca.IdCadena=p.IdCadena)"
        consulta += " where l.nave=" + Naveid.ToString + "  and l.Fecha BETWEEN '" + FechaInicio + "'   and '" + FechaFin + "' and l.Pares IS NOT NULL /*AND vpet.EstatusDesarrollo <> 'I'*/ and vpet.pres_activo = 1 and vpet.StatusId not in (1,2,7) "
        consulta += " AND (la.[Año   ]=" + FechaInicio.Year.ToString + " OR la.[Año   ]= " + FechaFin.Year.ToString + ") AND la.IdNave=" + Naveid.ToString + " order by l.Lote"

        'Dim Consulta As String = " select a.Fecha, a.Lote, a.Año, a.Color, la.Cantidad 'Pares', e.Marca, f.Coleccion, d.IdModelo, c.Talla, a.Observacion"
        'Construye la consulta dependiendo de los elementos en la lista de departamentos
        'For Each dep As Entidades.DepartamentosProduccion In Departamentos
        '    Consulta += ",(select top (1) FechaAvance from LotesAvances as av where av.Lote=a.Lote and IdConfiguracion=" + dep.PIDConfiguracion.ToString + " and av.Estado='C'and av.Año=a.año ) as avanceDepartamento" + dep.PIDConfiguracion.ToString
        '    Consulta += ",	(ISnull((SELECT TOP (1) map.Motivo FROM LotesAvances AS av INNER JOIN MotivoAtrasosProduccion AS map ON map.idMotivo=av.idMotivo WHERE av.Lote = a.Lote	AND IdConfiguracion = " + dep.PIDConfiguracion.ToString + "	AND av.Estado = 'C'	AND av.Año = a.año),''))	AS motivoDepartamento" + dep.PIDConfiguracion.ToString
        '    Consulta += ",	(ISnull((SELECT TOP (1) diasAtraso FROM LotesAvances AS av  WHERE av.Lote = a.Lote	AND IdConfiguracion = " + dep.PIDConfiguracion.ToString + "	AND av.Estado = 'C'	AND av.Año = a.año),0))	AS diasAtrasos" + dep.PIDConfiguracion.ToString
        '    Consulta += " , (select top (1) Celula from nmaCelulas where Nave =" + Naveid.ToString + " and IdCelula= (select top (1) IdCelula from LotesAvances as av where av.Lote=a.Lote and IdConfiguracion=" + dep.PIDConfiguracion.ToString + " and (av.Estado='C' or av.Estado='P')and av.Año=a.Año)) as Celula" + dep.PIDConfiguracion.ToString
        'Next

        'Consulta += ",a.Fecha_Salida,la.IdPedido,ca.nombre from Lotes as a JOIN Tallas as c ON (c.IdTalla=a.IdTalla)"
        'Consulta += " JOIN catProductos as d ON (d.IdProducto=a.IdCatProducto) join Marcas as e on (e.IdMarca=d.IdMarca) join Colecciones as f on (f.IdColeccion=d.IdColeccion)"
        'Consulta += " JOIN LotesA la ON (la.NoLote=a.Lote) JOIN Pedidos p ON (p.IdPedido=la.IdPedido) JOIN Cadenas ca on (ca.IdCadena=p.IdCadena)"
        ''Consulta += " where a.Nave=" + Naveid.ToString + " and (Año=" + FechaFin.Year.ToString + " or Año=" + FechaInicio.Year.ToString + ") and (a.Fecha between '" + FechaInicio + "'   and '" + FechaFin + "') and a.Pares is not null order by a.Lote"
        'Consulta += " WHERE a.Nave = " + Naveid.ToString + "" +
        '            " AND (a.Año = " + FechaFin.Year.ToString + "" +
        '            " OR a.Año = " + FechaInicio.Year.ToString + ")" +
        '            " AND (la.[Año   ]=" + FechaInicio.Year.ToString + "" +
        '            " OR la.[Año   ]= " + FechaFin.Year.ToString + ")" +
        '            " AND la.IdNave=" + Naveid.ToString + "" +
        '            " AND (a.Fecha BETWEEN '" + FechaInicio + "' AND '" + FechaFin + "')" +
        '            " AND a.Pares IS NOT NULL" +
        '            " ORDER BY a.Lote"
        Return opereciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaAvancesProduccionAvances(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Naveid As Int32, ByVal Departamentos As List(Of Entidades.DepartamentosProduccion), ByVal DepartamentoAnterior As Int32, ByVal Orden As Int32) As DataTable
        Dim opereciones As New Persistencia.OperacionesProcedimientosSICY

        For Each row As Entidades.DepartamentosProduccion In Departamentos

            Try
                Dim FechaConsulta = "select top(1) a.Fecha from lotes as a where a.Fecha_Salida is null and a.Nave=" + Naveid.ToString + " and a.Pares is not null and a.Lote NOT IN (select b.Lote from LotesAvances as b where b.Estado='C' and b.Nave=a.Nave and b.Año=a.Año and b.IdConfiguracion=" + row.PIDConfiguracion.ToString + ") order by Fecha "
                FechaInicio = opereciones.EjecutaConsultaEscalar(FechaConsulta)
                FechaInicio = FechaInicio.AddDays(-1)
            Catch ex As Exception

            End Try

        Next

        If FechaInicio > FechaFin Then
            Dim fechaTemporal As DateTime = FechaInicio
            FechaInicio = FechaFin
            FechaFin = fechaTemporal
        End If

        Dim tablaTemporal As String
        Dim IdDepartamentos As String = String.Empty

        For i As Integer = 0 To Departamentos.Count() - 1
            If i = 0 Then
                IdDepartamentos = Departamentos(i).PIDConfiguracion.ToString
            Else
                IdDepartamentos += "," + Departamentos(i).PIDConfiguracion.ToString
            End If
        Next

        tablaTemporal = " create table #FechaAvances(lote int,IdConfiguracion int,FechaAvance datetime,año int,celula varchar(200),nave int)
                            insert into #FechaAvances
                        select l.Lote,la.IdConfiguracion,la.FechaAvance,la.Año,c.Celula,la.Nave from LotesAvances la inner join Lotes l on la.Lote = l.Lote and la.Año = l.Año
                        inner join nmaCelulas c on la.IdCelula = c.IdCelula and la.Nave = c.Nave
                        WHERE l.Nave = " + Naveid.ToString + "
                        and la.IdConfiguracion in(20,21,22,34)
                        AND la.Estado = 'C'
                        AND (l.Año =" + FechaInicio.Year.ToString + "
                        OR l.Año =" + FechaInicio.Year.ToString + ")
                        AND (l.Fecha BETWEEN '" + FechaInicio + "'   and '" + FechaFin + "')
                        AND l.Pares IS NOT NULL   
                        GROUP BY 
                             l.Lote
                            ,la.IdConfiguracion
                            ,la.FechaAvance
                            ,la.Año
                            ,C.Celula
                            ,la.Nave"
        Dim Consulta As String
        Consulta = tablaTemporal + vbNewLine
        ' a.Color
        Consulta += " select a.Fecha, a.Lote, a.Año, vpet.PielColor 'Color', a.Pares, e.Marca, f.Coleccion, d.IdModelo, c.Talla, a.Observacion"
        For Each dep As Entidades.DepartamentosProduccion In Departamentos
            Consulta += ",(select FechaAvance from #FechaAvances as av where av.Lote=a.Lote and IdConfiguracion=" + dep.PIDConfiguracion.ToString + " AND a.Año=AV.Año) as avanceDepartamento" + dep.PIDConfiguracion.ToString
            Consulta += " , (select celula from #FechaAvances as av where av.Lote=a.Lote and av.Nave=a.Nave and IdConfiguracion=" + dep.PIDConfiguracion.ToString + " AND a.Año=AV.Año) as Celula" + dep.PIDConfiguracion.ToString
        Next

        Consulta += ",a.Fecha_Salida from Lotes as a JOIN Tallas as c ON (c.IdTalla=a.IdTalla)"
        Consulta += " JOIN catProductos as d ON (d.IdProducto=a.IdCatProducto) join Marcas as e on (e.IdMarca=d.IdMarca) join Colecciones as f on (f.IdColeccion=d.IdColeccion)"
        Consulta += "LEFT JOIN Programacion.vProductoEstilos_Completo vpet 	ON vpet.CodigoSicy = d.IdCodigo AND vpet.IdTallaSicy = d.IdCorrida 	AND vpet.CodigoPielColorSICY = LTRIM(RTRIM(d.IdPiel)) + LTRIM(RTRIM(d.IdColor))"

        Consulta += "where a.Nave=" + Naveid.ToString + " and (Año=" + FechaFin.Year.ToString + " or Año=" + FechaInicio.Year.ToString + ") and (a.Fecha between '" + FechaInicio + "'   and '" + FechaFin + "') and a.Pares is not null /*AND vpet.EstatusDesarrollo <> 'I'*/ and vpet.pres_activo = 1 and vpet.StatusId not in (1,2,7)"

        If DepartamentoAnterior > 0 Then
            If Orden = 3 Then
                Consulta += " and a.Lote  in(select b.Lote from LotesAvances b where (b.Año= " + FechaInicio.Year.ToString + " or b.Año=" + FechaFin.Year.ToString + ") and b.Nave=" + Naveid.ToString + " and IdConfiguracion=" + DepartamentoAnterior.ToString + " and FechaAvance is not null)"

            Else
                Consulta += " and a.Lote  in(select b.Lote from LotesAvances b where (b.Año= " + FechaInicio.Year.ToString + " or b.Año=" + FechaFin.Year.ToString + ") and b.Nave=" + Naveid.ToString + " and IdConfiguracion=" + DepartamentoAnterior.ToString + ")"
            End If
        End If
        Consulta += " order by a.Lote"
        Return opereciones.EjecutaConsulta(Consulta)
    End Function

    Public Function VerificarAvancesProduccion(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Naveid As Int32, ByVal Departamentos As List(Of Entidades.DepartamentosProduccion)) As DataTable
        Dim opereciones As New Persistencia.OperacionesProcedimientosSICY
        Dim configuracion As String = "and a.IdConfiguracion="
        Dim embarque As Boolean = True
        'b.Color
        Dim Consulta As String = " select distinct(a.lote),b.fecha,a.Año,vpet.PielColor 'Color',a.Pares,vpet.MarcaSAY AS Marca,f.coleccion,d.IdModelo,c.Talla,b.Observacion"
        For Each dep As Entidades.DepartamentosProduccion In Departamentos
            embarque = False
            configuracion += dep.PIDConfiguracion.ToString
            Consulta += ",(select top 1 FechaAvance from LotesAvances as b1 where  b1.FechaAvance between  '" + FechaInicio.ToShortDateString + " 00:00:00' and '" + FechaFin.ToShortDateString + " 23:59:00' and b1.Estado=a.Estado and b1.Nave=a.Nave and b1.Año=a.Año and b1.Lote=a.Lote and b1.IdConfiguracion=" + dep.PIDConfiguracion.ToString + ") as avanceDepartamento" + dep.PIDConfiguracion.ToString
            Consulta += " , (select Celula from nmaCelulas where Nave =" + Naveid.ToString + " and IdCelula= (select top 1 IdCelula from LotesAvances as av where av.Lote=a.Lote AND av.año=a.Año AND av.nave=a.nave  and IdConfiguracion=" + dep.PIDConfiguracion.ToString + " and av.Estado='C')) as Celula" + dep.PIDConfiguracion.ToString
        Next

        Consulta += ",b.Fecha_Salida  from LotesAvances as a join Lotes as b on a.Lote=b.Lote and a.Año=b.Año"
        Consulta += "  left join catProductos as d on (d.IdProducto= b.IdCatProducto) left join Tallas as c on (d.IdCorrida=c.IdTalla) left join Marcas as e on (e.IdMarca=d.IdMarca) left join Colecciones as f on (f.IdColeccion=d.IdColeccion)"
        Consulta += "LEFT JOIN Programacion.vProductoEstilos_Completo vpet 	ON vpet.CodigoSicy = d.IdCodigo AND vpet.IdTallaSicy = d.IdCorrida 	AND vpet.CodigoPielColorSICY = LTRIM(RTRIM(d.IdPiel)) + LTRIM(RTRIM(d.IdColor)) "

        Consulta += "where a.Nave=" + Naveid.ToString + " /*and   vpet.EstatusDesarrollo <> 'I'*/ and vpet.pres_activo = 1 and vpet.StatusId not in (1,2,7) AND"
        If FechaInicio.Year <> FechaFin.Year Then
            Consulta += " (a.Año=" + FechaInicio.Year.ToString + " or a.Año=" + FechaFin.Year.ToString + ") and FechaAvance between '" + FechaInicio + " 00:00:00'   and '" + FechaFin + " 23:59:00' and Estado='C' "
        Else
            'Consulta += " a.Año=" + FechaFin.Year.ToString + " and FechaAvance between '" + FechaInicio + " 00:00:00'   and '" + FechaFin + " 23:59:00' and Estado='C' "
            Consulta += " FechaAvance between '" + FechaInicio + " 00:00:00'   and '" + FechaFin + " 23:59:00' and Estado='C' "
        End If

        If embarque = True Then
        Else

            Consulta += " " + configuracion + " "
        End If

        Consulta += " and b.Nave=" + Naveid.ToString + " order by a.Lote"
        Return opereciones.EjecutaConsulta(Consulta)
    End Function

    Public Function VerificarAvancesProduccionembarque(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Naveid As Int32, ByVal Departamentos As List(Of Entidades.DepartamentosProduccion)) As DataTable
        Dim opereciones As New Persistencia.OperacionesProcedimientosSICY
        Dim configuracion As String = "and a.IdConfiguracion="
        Dim embarque As Boolean = True
        'b.Color
        Dim Consulta As String = " select distinct(a.lote),b.fecha,a.Año,vpet.PielColor 'Color',a.Pares,e.Marca,f.coleccion,d.IdModelo,c.Talla,b.Observacion"
        For Each dep As Entidades.DepartamentosProduccion In Departamentos
            embarque = False

            configuracion += dep.PIDConfiguracion.ToString
            Consulta += ",(select FechaAvance from LotesAvances as b1 where  b1.FechaAvance between  '" + FechaInicio.ToShortDateString + " 00:00:00' and '" + FechaFin.ToShortDateString + " 23:59:00' and b1.Estado=a.Estado and b1.Nave=a.Nave and b1.Año=a.Año and b1.Lote=a.Lote and b1.IdConfiguracion=" + dep.PIDConfiguracion.ToString + ") as avanceDepartamento" + dep.PIDConfiguracion.ToString
            Consulta += " , (select Celula from nmaCelulas where Nave =" + Naveid.ToString + " and IdCelula= (select IdCelula from LotesAvances as av where av.Lote=a.Lote and IdConfiguracion=" + dep.PIDConfiguracion.ToString + " and av.Estado='C')) as Celula" + dep.PIDConfiguracion.ToString
        Next

        Consulta += ",b.Fecha_Salida  from LotesAvances as a join Lotes as b on a.Lote=b.Lote and a.Año=b.Año"
        Consulta += "  left join catProductos as d on (d.IdProducto= b.IdCatProducto) left join Tallas as c on (d.IdCorrida=c.IdTalla) left join Marcas as e on (e.IdMarca=d.IdMarca) left join Colecciones as f on (f.IdColeccion=d.IdColeccion)"
        Consulta += "LEFT JOIN Programacion.vProductoEstilos_Completo vpet 	ON vpet.CodigoSicy = d.IdCodigo AND vpet.IdTallaSicy = d.IdCorrida 	AND vpet.CodigoPielColorSICY = LTRIM(RTRIM(d.IdPiel)) + LTRIM(RTRIM(d.IdColor)) "

        Consulta += "where a.Nave=" + Naveid.ToString + "  /*AND vpet.EstatusDesarrollo <> 'I'*/ and vpet.pres_activo = 1 and vpet.StatusId not in (1,2,7)  and "
        If FechaInicio.Year <> FechaFin.Year Then
            Consulta += "  Fecha_Salida between '" + FechaInicio + " 00:00:00'   and '" + FechaFin + " 23:59:00' and Estado='C' "
        Else
            Consulta += " Fecha_Salida between '" + FechaInicio + " 00:00:00'   and '" + FechaFin + " 23:59:00'  "

        End If

        If embarque = True Then
        Else

            Consulta += " " + configuracion + " "
        End If

        Consulta += " and b.Nave=" + Naveid.ToString + " order by a.Lote"

        'PARCHE JUANA 09-05-2015

        If embarque Then
            'Consulta = "SELECT DISTINCT 	(b.lote), 	b.fecha,	b.Año,	b.Color,	b.Pares,	e.Marca,	f.coleccion,	d.IdModelo,	c.Talla,	b.Observacion,	b.Fecha_Salida from Lotes AS b 	LEFT JOIN catProductos AS d 	ON (d.IdProducto = b.IdCatProducto)LEFT JOIN Tallas AS c 	ON (d.IdCorrida = c.IdTalla) LEFT JOIN Marcas AS e 	ON (e.IdMarca = d.IdMarca) LEFT JOIN Colecciones AS f 	ON (f.IdColeccion = d.IdColeccion) WHERE Fecha_Salida BETWEEN '" + FechaInicio.ToShortDateString + " 00:00:00' and '" + FechaFin.ToShortDateString + " 23:59:00' AND b.Nave = " + Naveid.ToString + " ORDER BY b.Lote"
            Consulta = "SELECT DISTINCT 	(b.lote), 	b.fecha,	b.Año ,vpet.PielColor 'color',	b.Pares,	vpet.MarcaSAY AS Marca,	f.coleccion,	d.IdModelo,	c.Talla,	b.Observacion,	b.Fecha_Salida from Lotes AS b 	LEFT JOIN catProductos AS d 	ON (d.IdProducto = b.IdCatProducto)LEFT JOIN Tallas AS c 	ON (d.IdCorrida = c.IdTalla) LEFT JOIN Marcas AS e 	ON (e.IdMarca = d.IdMarca) LEFT JOIN Colecciones AS f 	ON (f.IdColeccion = d.IdColeccion) left join Programacion.vProductoEstilos_Completo vpet on vpet.CodigoSicy = d.IdCodigo and vpet.IdTallaSicy = d.IdCorrida and vpet.CodigoPielColorSICY = ltrim(rtrim(d.IdPiel))+ltrim(rtrim(d.IdColor)) WHERE /* vpet.EstatusDesarrollo <> 'I' and */ vpet.pres_activo = 1 and vpet.StatusId not in (1,2,7) and  Fecha_Salida BETWEEN  '" + FechaInicio.ToShortDateString + " 00:00:00' and '" + FechaFin.ToShortDateString + " 23:59:00' AND b.Nave = " + Naveid.ToString + " ORDER BY b.Lote"
        End If

        Return opereciones.EjecutaConsulta(Consulta)
    End Function

    Public Function InventarioLotesAvances(ByVal vNave As Int32, ByVal idDepartamento As Int32, ByVal vFechaLoteIni As Date, ByVal vFechaLoteFin As Date) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        Try
            Dim Consulta = "select top(1) a.Fecha from lotes as a where a.Fecha_Salida is null and a.Nave=" + vNave.ToString + " and a.Pares is not null and a.Lote NOT IN (select b.Lote from LotesAvances as b where b.Estado='C' and b.Nave=a.Nave and b.Año=a.Año and b.IdConfiguracion=" + idDepartamento.ToString + ") order by Fecha "
            'Dim Consulta = "select top(1) a.Fecha from lotes as a where a.Fecha_Salida is null and a.Nave=" + vNave.ToString + " and a.Año=" + vFechaLoteIni.Year.ToString + " and a.Pares is not null and a.Lote NOT IN (select b.Lote from LotesAvances as b where b.Estado='C' and b.Nave=a.Nave and b.Año=a.Año and b.IdConfiguracion=" + idDepartamento.ToString + ") order by Fecha "
            ' Dim Consulta = "select top(1) a.Fecha from lotes as a where a.Fecha_Salida is null and a.Nave=" + vNave.ToString + " and a.Año=" + vFechaLoteIni.Year.ToString + " order by Fecha" '+ " and a.Pares is not null and a.Lote NOT IN (select b.Lote from LotesAvances as b where b.Estado='C' and b.Nave=a.Nave and b.Año=a.Año and b.IdConfiguracion=" + idDepartamento.ToString + ") order by Fecha "

            If operaciones.EjecutaConsultaEscalar(Consulta) <> "12:00:00 AM" Then
                vFechaLoteIni = operaciones.EjecutaConsultaEscalar(Consulta)
            End If

        Catch ex As Exception

        End Try

        If vFechaLoteIni > vFechaLoteFin Then
            Dim fechaTemporal As DateTime = vFechaLoteIni
            vFechaLoteIni = vFechaLoteFin
            vFechaLoteFin = fechaTemporal
        End If

        parametro = New SqlParameter("@nave", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@id_departamento", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = idDepartamento
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vFechaLoteIni.Year
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaInicio", SqlDbType.DateTime)
        parametro.Direction = ParameterDirection.Input
        Dim FechaInicio As New DateTime
        FechaInicio = vFechaLoteIni.Day.ToString + "/" + vFechaLoteIni.Month.ToString + "/" + vFechaLoteIni.Year.ToString
        parametro.Value = FormatDateTime(FechaInicio, DateFormat.ShortDate)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", SqlDbType.VarChar)
        parametro.Size = 15
        parametro.Direction = ParameterDirection.Input

        Dim FechaFin As New DateTime
        vFechaLoteFin = vFechaLoteFin.Day.ToString + "/" + vFechaLoteFin.Month.ToString + "/" + vFechaLoteFin.Year.ToString


        parametro.Value = FormatDateTime(vFechaLoteFin, DateFormat.ShortDate)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@AñoFin", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vFechaLoteFin.Year
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("SP_inventario_departamento", listaParametros)
    End Function

    Public Function InventarioLotesAvancesV2(ByVal vNave As Int32, ByVal idDepartamento As Int32, ByVal vFechaLoteIni As Date,
                                             ByVal vFechaLoteFin As Date, ByVal DepartamentoAnterior As Int32) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        Try
            Dim Consulta = "select top(1) a.Fecha from lotes as a where a.Fecha_Salida is null and a.Nave=" + vNave.ToString + " and a.Pares is not null and a.Lote NOT IN (select b.Lote from LotesAvances as b where b.Estado='C' and b.Nave=a.Nave and b.Año=a.Año and b.IdConfiguracion=" + idDepartamento.ToString + ") order by Fecha "
            'Dim Consulta = "select top(1) a.Fecha from lotes as a where a.Fecha_Salida is null and a.Nave=" + vNave.ToString + " and a.Año=" + vFechaLoteIni.Year.ToString + " and a.Pares is not null and a.Lote NOT IN (select b.Lote from LotesAvances as b where b.Estado='C' and b.Nave=a.Nave and b.Año=a.Año and b.IdConfiguracion=" + idDepartamento.ToString + ") order by Fecha "
            'Dim Consulta = "select top(1) a.Fecha from lotes as a where a.Fecha_Salida is null and a.Nave=" + vNave.ToString + " and a.Año=" + vFechaLoteIni.Year.ToString + " order by Fecha" '+ " and a.Pares is not null and a.Lote NOT IN (select b.Lote from LotesAvances as b where b.Estado='C' and b.Nave=a.Nave and b.Año=a.Año and b.IdConfiguracion=" + idDepartamento.ToString + ") order by Fecha "

            If operaciones.EjecutaConsultaEscalar(Consulta) <> "12:00:00 AM" Then
                vFechaLoteIni = operaciones.EjecutaConsultaEscalar(Consulta)
            End If
        Catch ex As Exception
        End Try

        parametro = New SqlParameter("@nave", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@id_departamento", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = idDepartamento
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vFechaLoteIni.Year
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaInicio", SqlDbType.DateTime)
        parametro.Direction = ParameterDirection.Input
        Dim FechaInicio As New DateTime
        FechaInicio = vFechaLoteIni.Day.ToString + "/" + vFechaLoteIni.Month.ToString + "/" + vFechaLoteIni.Year.ToString
        parametro.Value = FormatDateTime(FechaInicio, DateFormat.ShortDate)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", SqlDbType.VarChar)
        parametro.Size = 15
        parametro.Direction = ParameterDirection.Input

        Dim FechaFin As New DateTime
        vFechaLoteFin = vFechaLoteFin.Day.ToString + "/" + vFechaLoteFin.Month.ToString + "/" + vFechaLoteFin.Year.ToString

        parametro.Value = FormatDateTime(vFechaLoteFin, DateFormat.ShortDate)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@AñoFin", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vFechaLoteFin.Year
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@DepartamentoAnterior", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = DepartamentoAnterior
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("SP_inventario_departamentoV2", listaParametros)
        'Return operaciones.EjecutarConsultaSP("SP_inventario_departamentoMontado", listaParametros)
    End Function

    Public Function InventarioLotesAvancesMontado(ByVal vNave As Int32, ByVal idDepartamento As Int32,
                                   ByVal vFechaLoteIni As Date, ByVal vFechaLoteFin As Date,
                                   ByVal DepartamentoAnterior As Int32) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        Try
            Dim Consulta = "select top(1) a.Fecha from lotes as a where a.Fecha_Salida is null and a.Nave=" + vNave.ToString + " and a.Pares is not null and a.Lote NOT IN (select b.Lote from LotesAvances as b where b.Estado='C' and b.Nave=a.Nave and b.Año=a.Año and b.IdConfiguracion=" + idDepartamento.ToString + " and b.FechaAvance IS NULL) order by Fecha "
            'Dim Consulta = "select top(1) a.Fecha from lotes as a where a.Fecha_Salida is null and a.Nave=" + vNave.ToString + " and a.Año=" + vFechaLoteIni.Year.ToString + " and a.Pares is not null and a.Lote NOT IN (select b.Lote from LotesAvances as b where b.Estado='C' and b.Nave=a.Nave and b.Año=a.Año and b.IdConfiguracion=" + idDepartamento.ToString + " and b.FechaAvance IS NULL) order by Fecha "
            ' Dim Consulta = "select top(1) a.Fecha from lotes as a where a.Fecha_Salida is null and a.Nave=" + vNave.ToString + " and a.Año=" + vFechaLoteIni.Year.ToString + " order by Fecha" '+ " and a.Pares is not null and a.Lote NOT IN (select b.Lote from LotesAvances as b where b.Estado='C' and b.Nave=a.Nave and b.Año=a.Año and b.IdConfiguracion=" + idDepartamento.ToString + ") order by Fecha "

            If operaciones.EjecutaConsultaEscalar(Consulta) <> "12:00:00 AM" Then
                vFechaLoteIni = operaciones.EjecutaConsultaEscalar(Consulta)
            End If
        Catch ex As Exception
        End Try

        parametro = New SqlParameter("@nave", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@id_departamento", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = idDepartamento
        listaParametros.Add(parametro)

        'si el mes es enero toma el año anterior
        parametro = New SqlParameter("@Año", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        'If vFechaLoteIni.Month = 1 Then
        'parametro.Value = vFechaLoteIni.Year - 1
        'Else
        parametro.Value = vFechaLoteIni.Year
        'End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaInicio", SqlDbType.DateTime)
        parametro.Direction = ParameterDirection.Input
        Dim FechaInicio As New DateTime
        FechaInicio = vFechaLoteIni.Day.ToString + "/" + vFechaLoteIni.Month.ToString + "/" + vFechaLoteIni.Year.ToString
        parametro.Value = FormatDateTime(FechaInicio, DateFormat.ShortDate)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", SqlDbType.VarChar)
        parametro.Size = 15
        parametro.Direction = ParameterDirection.Input

        Dim FechaFin As New DateTime
        vFechaLoteFin = vFechaLoteFin.Day.ToString + "/" + vFechaLoteFin.Month.ToString + "/" + vFechaLoteFin.Year.ToString


        parametro.Value = FormatDateTime(vFechaLoteFin, DateFormat.ShortDate)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@AñoFin", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vFechaLoteFin.Year
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@DepartamentoAnterior", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = DepartamentoAnterior
        listaParametros.Add(parametro)
        Return operaciones.EjecutarConsultaSP("SP_inventario_departamentoMontado", listaParametros)
    End Function

    Public Function InventarioDepartamentos_NavesProd(ByVal vNave As Int32, ByVal vFechaLoteIni As Date, ByVal vFechaLoteFin As Date, ByVal vOrden As Integer, ByVal vDepartamentoId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter("@Nave", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaInicio", SqlDbType.Date)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vFechaLoteIni
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", SqlDbType.Date)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vFechaLoteFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Orden", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vOrden
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@DepId", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vDepartamentoId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_InventarioDepartamentos_NavesProduccion]", listaParametros)

    End Function


    Public Function InventarioNaves(ByVal vNave As Int32, ByVal vFechaLoteIni As DateTime, ByVal vFechaLoteFin As DateTime) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        Try
            Dim Consulta = "select top(1) Fecha from lotes where fecha_salida is null and pares is not null and Nave=" + vNave.ToString + " and Año=" + vFechaLoteIni.Year.ToString + " and Fecha<'" + vFechaLoteIni.ToShortDateString + "' "
            Dim fecha As String = operaciones.EjecutaConsultaEscalar(Consulta)
            If fecha <> Nothing Then
                vFechaLoteIni = operaciones.EjecutaConsultaEscalar(Consulta)
            End If

        Catch ex As Exception

        End Try

        vFechaLoteIni = vFechaLoteIni.ToShortDateString

        parametro = New SqlParameter("@nave", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vFechaLoteIni.Year
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaInicio", SqlDbType.DateTime)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = FormatDateTime(vFechaLoteIni, DateFormat.ShortDate)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@AñoFin", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vFechaLoteFin.Year
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("SP_Inventario_nave", listaParametros)
    End Function

    Public Function InventarioNavesV2(ByVal vNave As Int32, ByVal vFechaLoteIni As DateTime, ByVal vFechaLoteFin As DateTime) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        Try
            Dim Consulta = "select top(1) Fecha from lotes where fecha_salida is null and pares is not null and Nave=" + vNave.ToString + " and Fecha<'" + vFechaLoteIni.ToShortDateString + "' order by Fecha asc "
            Dim fecha As String = operaciones.EjecutaConsultaEscalar(Consulta)
            If fecha <> Nothing Then
                vFechaLoteIni = operaciones.EjecutaConsultaEscalar(Consulta)
            End If

        Catch ex As Exception
        End Try

        vFechaLoteIni = vFechaLoteIni.ToShortDateString

        parametro = New SqlParameter("@nave", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vFechaLoteIni.Year
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaInicio", SqlDbType.DateTime)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = FormatDateTime(vFechaLoteIni, DateFormat.ShortDate)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@AñoFin", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = vFechaLoteFin.Year
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("SP_Inventario_nave", listaParametros)
    End Function

    Public Function DepartamentosAnteriores(ByVal idNave As Int32, ByVal idConfiguracion As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = String.Empty
        Consulta += "select Orden, ((select Orden from LotesAvancesConfigNaveDepto where IdConfiguracion=" + idConfiguracion.ToString + ")-1) as DptoAnterior,"
        Consulta += " (SELECT IdConfiguracion from LotesAvancesConfigNaveDepto WHERE Orden=(select Orden from LotesAvancesConfigNaveDepto where IdConfiguracion=" + idConfiguracion.ToString + ")-1 and IdNave=" + idNave.ToString + ") as idConfiguracionDptoAnterior"
        Consulta += "  from LotesAvancesConfigNaveDepto where IdConfiguracion=" + idConfiguracion.ToString
        Return operaciones.EjecutaConsulta(Consulta)
    End Function
    Public Function getdiasAtrasosDepartamento(ByVal lote As Integer, ByVal idNave As Integer, ByVal año As Integer, ByVal departamento As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        parametro = New SqlParameter("@lote", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = lote
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@año", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = año
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@nave", SqlDbType.Int)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = idNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@operacion", SqlDbType.VarChar)
        parametro.Direction = ParameterDirection.Input
        parametro.Value = departamento
        listaParametros.Add(parametro)
        Return operaciones.EjecutarConsultaSP("DiasAtrasoLotes", listaParametros)
    End Function

    Public Function RegistrosReporte(ByVal FechaInicial As DateTime, ByVal FechaFinal As Date, ByVal Naveid As Integer, ByVal Departamentoid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaInicio"
        parametro.Value = FechaInicial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = FechaFinal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Naveid"
        parametro.Value = Naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Departamentos"
        parametro.Value = Departamentoid
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@DepartamentoAnterior"
        'parametro.Value = DepAnterior
        'listaParametros.Add(parametro)
        '
        'parametro = New SqlParameter
        'parametro.ParameterName = "@Orden"
        'parametro.Value = Orden
        'listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("ListaProduccionDeAvances", listaParametros)

    End Function
    Public Function RegistrosResumen(ByVal FechaInicial As DateTime, ByVal FechaFinal As Date, ByVal Naveid As Integer, ByVal Departamentoid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaInicio"
        parametro.Value = FechaInicial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = FechaFinal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Naveid"
        parametro.Value = Naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Departamentos"
        parametro.Value = Departamentoid
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[ResumenProduccionAvance]", listaParametros)

    End Function
    Public Function RegistrosCelulaNave(ByVal nombreDepartamento As String, ByVal naveId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@Departamento"
        parametro.Value = nombreDepartamento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = naveId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_CelulasPorNavesSAY]", listaParametros)

    End Function
    Public Function RegistrosReporteCelula(ByVal FechaInicial As DateTime, ByVal FechaFinal As Date, ByVal Naveid As Integer, ByVal Departamentoid As Integer, ByVal celula As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaInicio"
        parametro.Value = FechaInicial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = FechaFinal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Naveid"
        parametro.Value = Naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Departamentos"
        parametro.Value = Departamentoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Celula"
        parametro.Value = celula
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_ConsultaInventarioPorCelula]", listaParametros)

    End Function
    Public Function RegistrosResumenCelula(ByVal FechaInicial As DateTime, ByVal FechaFinal As Date, ByVal Naveid As Integer, ByVal Departamentoid As Integer, ByVal celula As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaInicio"
        parametro.Value = FechaInicial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = FechaFinal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Naveid"
        parametro.Value = Naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Departamentos"
        parametro.Value = Departamentoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Celula"
        parametro.Value = celula
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[PRODUCCION].[SP_ResumenProduccionAvanceCelulas]", listaParametros)

    End Function
    Public Function RegistrosProduccionDeAvancesMA(ByVal Naveid As Integer, ByVal FechaInicial As DateTime, ByVal FechaFinal As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Nave"
        parametro.Value = Naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = FechaInicial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = FechaFinal
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_InventarioEnPorceso_MontadoAdorno]", listaParametros)

    End Function
    Public Function RegistrosResumenProduccionDeAvancesMA(ByVal Naveid As Integer, ByVal FechaInicial As DateTime, ByVal FechaFinal As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Nave"
        parametro.Value = Naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = FechaInicial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = FechaFinal
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_ResumenInventarioEnPorceso_MontadoAdorno]", listaParametros)

    End Function
    Public Function RegistrosProduccionDeAvancesPT(ByVal Naveid As Integer, ByVal FechaInicial As DateTime, ByVal FechaFinal As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Nave"
        parametro.Value = Naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = FechaInicial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = FechaFinal
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_InventarioProductoTerminado_AntesDeEmbarque]", listaParametros)

    End Function
    Public Function RegistrosResumenProduccionDeAvancesPT(ByVal Naveid As Integer, ByVal FechaInicial As DateTime, ByVal FechaFinal As Date, ByVal tipoReporte As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Nave"
        parametro.Value = Naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = FechaInicial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = FechaFinal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoReporte"
        parametro.Value = tipoReporte
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_ResumenInventarioProductoTerminado_AntesDeEmbarque]", listaParametros)

    End Function
End Class
