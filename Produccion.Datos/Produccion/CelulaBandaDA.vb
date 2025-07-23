Public Class CelulaBandaDA
    Public Function updateAvance(ByVal idLoteAvance As Integer, ByVal idCelula As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
            UPDATE [dbo].[LotesAvances]
            SET IdCelula=<%= idCelula %> where IdLoteAvance=<%= idLoteAvance %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function insertAvance(ByVal idNaveSICY As Integer, ByVal año As Integer, ByVal idDep As Integer, ByVal idCelula As Integer,
                                 ByVal pares As Integer, ByVal estado As String, ByVal lote As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
             INSERT INTO [dbo].[LotesAvances]([Año],[Nave],[Lote]
           ,[IdConfiguracion] ,[IdCelula] ,[Pares]
           ,[IdEmpleado]   ,[Estado]
           ,[Id_Empleado_Say])
            VALUES(<%= año %>,<%= idNaveSICY %>,<%= lote %>,<%= idDep %>,<%= idCelula %>,<%= pares %>,0,'<%= estado %>',0)
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getTotalCelulasyBandas(ByVal idNaveSICY As Integer, ByVal fecha As Date, ByVal idDep As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
             SELECT   la.IdCelula, c.Celula, Sum(la.Pares) 'Pares'
                FROM Lotes l INNER JOIN LotesAvances la ON l.Año=la.Año AND l.Nave=la.Nave 
                AND l.Lote=la.Lote inner JOIN LotesAvancesConfigNaveDepto cnd ON
                la.IdConfiguracion=cnd.IdConfiguracion 
                inner JOIN nmaCelulas c ON c.IdCelula=la.IdCelula and c.Nave=<%= idNaveSICY %>
                WHERE l.Nave=<%= idNaveSICY %> and l.Fecha='<%= fecha.ToString("dd/MM/yyyy") %>' and cnd.IdConfiguracion= <%= idDep %> 
                group by la.IdCelula,c.Celula order by c.Celula
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getFechasEmbarque(ByVal idNaveSICY As Integer, ByVal fecha As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
             SELECT DISTINCT l.Lote, l.Pares, l.Fecha_Salida, ISNULL((SELECT SUM(ld.No_Pares) FROM LotesDocenas ld
            WHERE NOT ld.Fecha_Salida IS NULL AND ld.Año = l.Año AND ld.Nave = l.Nave AND ld.Lote = l.Lote),0) as ParesEntregados
            FROM Lotes l WHERE l.Nave=<%= idNaveSICY %> and l.Fecha='<%= fecha.ToString("dd/MM/yyyy") %>' ORDER BY l.Lote
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getConfiguracion(ByVal idNaveSICY As Integer, ByVal fecha As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
             SELECT la.IdLoteAvance,la.Lote, la.IdConfiguracion, cnd.Color, IsNull(IdCelula,0) as IdCelula, la.Estado
            FROM Lotes l INNER JOIN LotesAvances la ON l.Año=la.Año AND l.Nave=la.Nave 
            AND l.Lote=la.Lote INNER JOIN LotesAvancesConfigNaveDepto cnd ON
            la.IdConfiguracion=cnd.IdConfiguracion 
            </cadena>
        consulta += " WHERE l.Nave=" & idNaveSICY & " and l.Fecha='" & fecha.ToString("dd/MM/yyyy") & "' ORDER BY l.Lote, la.IdConfiguracion"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getDatosLotes(ByVal idNaveSICY As Integer, ByVal fecha As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
             SELECT 0 Seleccion,l.año 'Año', l.nave 'Nave', l.lote 'Lote', ve.IdModelo 'Modelo', ve.Marca + SPACE(1) + ve.Coleccion AS Coleccion,
             t.talla 'Talla', l.color 'Color', l.pares 'Pares' ,'' 'Corte','' 'Pespunte','' 'Montado y Adorno','' 'Embarque' ,0 'IdLoteAvancePespunte' ,0 'IdLoteAvanceMontadoyAdorno',
            0 'idConfigPes',0 'idConfigMonAdo' ,'P' 'EstadoCorte','P' 'EstadoPespunte','P' 'EstadoMontadoYAdorno','' 'ColorCorte','' 'ColorPespunte','' 'ColorMontado'
            FROM lotes l INNER JOIN vEstilos ve ON l.IdCodigo = ve.IdCodigo 
            INNER JOIN Tallas t ON l.Idtalla=t.Idtalla             
            </cadena>
        consulta += " WHERE l.nave=" & idNaveSICY & "   AND l.Fecha = '" & fecha.ToString("dd/MM/yyyy") & "' ORDER BY l.lote "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getCelulasBandasDep(ByVal idDep As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>          
            SELECT c.IdCelula, c.Celula FROM LotesAvancesConfigNaveDepto cnd 
            INNER JOIN nmaDepartamentos d ON cnd.IdNave = d.Nave AND cnd.IdDepto = d.IdDepto
            INNER JOIN nmaCelulas c ON d.Nave=c.Nave AND d.IdDepto=c.IdDepto WHERE HabilitadaAvanProd= '1' 
            </cadena>
        consulta += " AND IdConfiguracion = " & idDep & ""
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getParesxEmbarque(ByVal idNaveSICY As Integer, ByVal fecha As Date, ByVal estado As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
            SELECT ISNULL(SUM(Pares),0) as Pares FROM Lotes    
            </cadena>
        If estado = "C" Then
            consulta += " WHERE  Fecha_Salida IS NOT NULL AND Nave = " & idNaveSICY & " AND Fecha = '" & fecha.ToString("dd/MM/yyyy") & "'"
        Else
            consulta += " WHERE  Fecha_Salida IS NULL AND Nave = " & idNaveSICY & " AND Fecha = '" & fecha.ToString("dd/MM/yyyy") & "'"
        End If

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getParesxDepartamento(ByVal idNaveSICY As Integer, ByVal fecha As Date, ByVal idDep As Integer, ByVal estado As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
            SELECT ISNULL(SUM(l.Pares),0) as Pares FROM Lotes l INNER JOIN LotesAvances la 
            ON l.Año = la.Año AND l.Nave = la.Nave AND l.Lote = la.Lote 

            </cadena>
        consulta += " WHERE la.Estado='" & estado & "' AND l.Nave = " & idNaveSICY & " AND l.Fecha='" & fecha.ToString("dd/MM/yyyy") & "' AND la.IdConfiguracion = " & idDep & ""
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getDepartamentosXNave(ByVal idNaveSICY As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
            SELECT cnd.IdConfiguracion as IdDepto, d.Departamento FROM LotesAvancesConfigNaveDepto cnd  INNER JOIN 
            nmaDepartamentos d ON cnd.IdNave = d.Nave AND cnd.IdDepto = d.IdDepto 
            </cadena>
        consulta += " WHERE cnd.IdNave = " & idNaveSICY & " ORDER BY cnd.Orden"
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function getLotesyPares(ByVal idNaveSICY As Integer, ByVal fecha As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
            SELECT ISNULL(COUNT(Lote),0) as Lotes,ISNULL(SUM(Pares),0) as Pares FROM Lotes 
            </cadena>
        consulta += " WHERE Nave = " & idNaveSICY & " and Fecha='" & fecha.ToString("dd/MM/yyyy") & "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getNaveSIcy(ByVal idNave As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
           select nave_navesicyid from Framework.Naves where nave_naveid=
            </cadena>
        consulta += " " & idNave & " "
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return Convert.ToInt32(datos.Rows(0).Item(0).ToString)
        End If
        Return 0
    End Function
End Class
