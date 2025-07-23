Imports System.Data.SqlClient
Imports Entidades

Public Class ConfirmacionBorradorDA
    'Public Sub guardarCortadores(ByVal tipo As Integer, ByVal nave As Integer, ByVal idPrograma As Integer, ByVal pedido As Integer,
    '                                  ByVal partida As Integer, ByVal idlote As Integer, ByVal cortadorPiel As Integer,
    '                                  ByVal cortadorForro As Integer, ByVal idCN As Integer, ByVal cortadorPielSint As Integer,
    '                                  ByVal cortadorForroSint As Integer, ByVal cortadorPielNombre As String,
    '                                  ByVal cortadorForroNombre As String, ByVal cortadorPielSintNombre As String,
    '                                  ByVal cortadorForroSintNombre As String)


    '    Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
    '    Dim operaciones2 As New Persistencia.OperacionesProcedimientosSICY
    '    Dim consulta As String = ""
    '    If tipo = 1 Then 'No es concentrado
    '        consulta = "update lotesA set  IdCortadorForroSay=" & cortadorForro & ",NomCortoCortadorForroSay='" & cortadorForroNombre & "',IdCortadorPielSay=" & cortadorPiel & ",NomCortoCortadorPielSay='" & cortadorPielNombre & "'," +
    '        "idcortadorpielsintsay=" & cortadorPielSint & ",nomcortocortadorpielsint='" & cortadorPielSintNombre & "',idcortadorforrosintsay=" & cortadorForroSint & ",nomcortocortadorforrosint='" & cortadorForroSintNombre & "'" +
    '  " where IdNave=" & nave & " and IdPrograma=" & idPrograma & " and IdPedido=" & pedido & " and IdPartida=" & partida & " and IdLote=" & idlote & ""
    '        operaciones.EjecutaConsulta(consulta)
    '    Else
    '        consulta = "update lotesA set  IdCortadorForroSay=" & cortadorForro & ",NomCortoCortadorForroSay='" & cortadorForroNombre & "',IdCortadorPielSay=" & cortadorPiel & ",NomCortoCortadorPielSay='" & cortadorPielNombre & "'," +
    '    "idcortadorpielsintsay=" & cortadorPielSint & ",nomcortocortadorpielsint='" & cortadorPielSintNombre & "',idcortadorforrosintsay=" & cortadorForroSint & ",nomcortocortadorforrosint='" & cortadorForroSintNombre & "' " +
    '    "where IdNave=" & nave & " And idPrograma = " & idPrograma & " And CN = " & idCN & ""
    '        operaciones.EjecutaConsulta(consulta)

    '    End If
    'End Sub

    Public Sub guardarCortadoresSICY(ByVal esConcentrado As Boolean, ByVal idNaveSicy As Integer, ByVal idPrograma As Integer, ByVal idPedido As Integer,
                                      ByVal idPartida As Integer, ByVal idLote As Integer, ByVal idCortadorPiel As Integer,
                                      ByVal idCortadorForro As Integer, ByVal idCN As Integer, ByVal idCortadorPielSint As Integer,
                                      ByVal idCortadorForroSint As Integer, ByVal nombreCortadorPiel As String,
                                      ByVal nombreCortadorForro As String, ByVal nombreCortadorPielSint As String,
                                      ByVal nombreCortadorForroSint As String)


        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pEsConcentrado"
        parametro.Value = esConcentrado
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdNaveSicy"
        parametro.Value = idNaveSicy
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdPrograma"
        parametro.Value = idPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdPedido"
        parametro.Value = idPedido
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdPartida"
        parametro.Value = idPartida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdLote"
        parametro.Value = idLote
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdCN"
        parametro.Value = idCN
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdCortadorPiel"
        parametro.Value = idCortadorPiel
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pNombreCortadorPiel"
        parametro.Value = nombreCortadorPiel
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdCortadorForro"
        parametro.Value = idCortadorForro
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pNombreCortadorForro"
        parametro.Value = nombreCortadorForro
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdCortadorPielSintetico"
        parametro.Value = idCortadorPielSint
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pNombreCortadorPielSintetico"
        parametro.Value = nombreCortadorPielSint
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdCortadorForroSintetico"
        parametro.Value = idCortadorForroSint
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pNombreCortadorForroSintetico"
        parametro.Value = nombreCortadorForroSint
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Produccion.SP_Produccion_AsignarCortadoresLotesSICY", listaparametros)
    End Sub

    Public Sub guardarCortadoresSAY(ByVal esConcentrado As Boolean, ByVal idNaveSicy As Integer, ByVal idPrograma As Integer, ByVal idPedido As Integer,
                                      ByVal idPartida As Integer, ByVal idLote As Integer, ByVal idCortadorPiel As Integer,
                                      ByVal idCortadorForro As Integer, ByVal idCN As Integer, ByVal idCortadorPielSint As Integer,
                                      ByVal idCortadorForroSint As Integer, ByVal nombreCortadorPiel As String,
                                      ByVal nombreCortadorForro As String, ByVal nombreCortadorPielSint As String,
                                      ByVal nombreCortadorForroSint As String)


        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pEsConcentrado"
        parametro.Value = esConcentrado
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdNaveSicy"
        parametro.Value = idNaveSicy
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdPrograma"
        parametro.Value = idPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdPedido"
        parametro.Value = idPedido
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdPartida"
        parametro.Value = idPartida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdLote"
        parametro.Value = idLote
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdCN"
        parametro.Value = idCN
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdCortadorPiel"
        parametro.Value = idCortadorPiel
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pNombreCortadorPiel"
        parametro.Value = nombreCortadorPiel
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdCortadorForro"
        parametro.Value = idCortadorForro
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pNombreCortadorForro"
        parametro.Value = nombreCortadorForro
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdCortadorPielSintetico"
        parametro.Value = idCortadorPielSint
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pNombreCortadorPielSintetico"
        parametro.Value = nombreCortadorPielSint
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdCortadorForroSintetico"
        parametro.Value = idCortadorForroSint
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pNombreCortadorForroSintetico"
        parametro.Value = nombreCortadorForroSint
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Produccion.SP_Produccion_AsignarCortadoresLotesSAY", listaparametros)
    End Sub

    Public Function getDatosNave(ByVal idNaveSicy As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pIdNaveSicy"
        parametro.Value = idNaveSicy
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Produccion.SP_Produccion_ObtenerNave", listaparametros)
    End Function

    'Public Function confirmarBorrador(ByVal idPrograma As Integer, ByVal idNave As Integer) As DataTable
    '    Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
    '    Dim consulta As String =
    '        <cadena>
    '            update prgProgramasNave set StatusBorr='Confirmado' where IdcatPrograma=<%= idPrograma %>  and IdcatNave=<%= idNave %>
    '        </cadena>
    '    Return operaciones.EjecutaConsulta(consulta)
    'End Function

    Public Sub confirmarBorrador(ByVal idPrograma As Integer, ByVal idNaveSicy As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pIdNaveSicy"
        parametro.Value = idNaveSicy
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdPrograma"
        parametro.Value = idPrograma
        listaparametros.Add(parametro)
        operaciones.EjecutarSentenciaSP("Produccion.SP_Produccion_ConfirmarBorrador", listaparametros)
    End Sub

    Public Function verificarNoCompletarLotesCliente(ByVal idCadena As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
                 SELECT * FROM pdClientesNoCompletarLotes WHERE IdCadena=<%= idCadena %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    'Public Function getDatosCliente(ByVal idPrograma As Integer, ByVal nave As Integer, ByVal pedido As Integer, ByVal partida As Integer) As DataTable
    '    Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
    '    Dim consulta As String =
    '        <cadena>
    '            SELECT DISTINCT l.pltIdCliente, l.IdCodigo, l.pltIdTalla, l.IdNave, e.Descripcion, t.Talla, c.Nombre, e.IdModelo 
    '            FROM LotesA l INNER JOIN vEstilos e ON l.IdCodigo=e.IdCodigo INNER JOIN Tallas t ON
    '            l.pltIdTalla=t.IdTalla INNER JOIN Cadenas c ON l.pltIdCliente=c.IdCadena  
    '            WHERE l.IdPrograma=<%= idPrograma %> AND l.IdNave=<%= nave %> AND l.IdPedido=<%= pedido %> AND l.IdPartida=<%= partida %>
    '        </cadena>
    '    Return operaciones.EjecutaConsulta(consulta)
    'End Function

    Public Function getDatosCliente(ByVal idPrograma As Integer, ByVal idNaveSicy As Integer, ByVal idPedido As Integer, ByVal idPartida As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pIdNaveSicy"
        parametro.Value = idNaveSicy
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdPrograma"
        parametro.Value = idPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdPedido"
        parametro.Value = idPedido
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdPartida"
        parametro.Value = idPartida
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Produccion.SP_Produccion_ObtenerClientesProgramaNave", listaparametros)
    End Function

    'Public Function getDatosConcentrado(ByVal idPrograma As Integer, ByVal nave As Integer, ByVal idConcentrado As Integer) As DataTable
    '    Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
    '    Dim consulta As String =
    '        <cadena>
    '            SELECT l.pltIdCliente, l.IdCodigo, l.pltIdTalla, l.IdNave, e.Descripcion, t.Talla, c.Nombre, e.IdModelo 
    '            FROM LotesA l INNER JOIN vEstilos e ON l.IdCodigo=e.IdCodigo INNER JOIN Tallas t 
    '            ON l.pltIdTalla=t.IdTalla INNER JOIN Cadenas c ON l.pltIdCliente=c.IdCadena 
    '            WHERE l.IdPrograma=<%= idPrograma %> AND l.IdNave=<%= nave %> AND l.CN=<%= idConcentrado %>
    '            GROUP BY l.pltIdCliente, l.IdCodigo, l.pltIdTalla, l.IdNave, e.Descripcion, t.Talla, c.Nombre, e.IdModelo
    '        </cadena>
    '    Return operaciones.EjecutaConsulta(consulta)
    'End Function

    Public Function getDatosConcentrado(ByVal idPrograma As Integer, ByVal idNaveSicy As Integer, ByVal idConcentrado As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pIdNaveSicy"
        parametro.Value = idNaveSicy
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdPrograma"
        parametro.Value = idPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdConcentrado"
        parametro.Value = idConcentrado
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Produccion.SP_Produccion_ObtenerBorradorConcentradoNave", listaparametros)
    End Function

    ' ''' <summary>
    ' ''' 
    ' ''' </summary>
    ' ''' <param name="nave">IdNave Say</param>
    ' ''' <param name="tipo"> 1 piel, 2 forro</param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function getCortadores(ByVal nave As Integer, ByVal tipo As Integer) As DataTable
    '    Dim operaciones As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String =
    '        <cadena>
    '            SELECT 0 'copf_cortadorpielforroid','-' 'codr_nombrecorto',' ' 'tcor_descripcion'
    '            UNION
    '           	select  copf_cortadorpielforroid,
    '            case when LEN(c.codr_nombrecorto) = <%= 0 %>
    '            end codr_nombrecorto
    '            tc.tcor_descripcion
    'from Nomina.Colaborador c
    '            inner join Produccion.CortadorPielForro cpf
    'inner join Framework.Naves n on n.nave_naveid=copf_naveid
    'left join Produccion.TipoCortador tc on tc.tcor_tipocortadorid=cpf.copf_tipocortador
    '            on codr_colaboradorid=copf_colaboradorid where copf_estatus=1 and codr_activo=1 
    '            and n.nave_navesicyid = <%= nave %>
    '        </cadena>
    '    If tipo = 1 Then
    '        consulta += " and tc.tcor_descripcion='CORTADOR PIEL'"
    '    ElseIf tipo = 2 Then
    '        consulta += " and tc.tcor_descripcion='CORTADOR FORRO'"
    '    ElseIf tipo = 3 Then
    '        consulta += " and tc.tcor_descripcion='CORTADOR PIEL SINTETICO'"
    '    ElseIf tipo = 4 Then
    '        consulta += " and tc.tcor_descripcion='CORTADOR FORRO SINTETICO'"
    '    End If
    '    Return operaciones.EjecutaConsulta(consulta)
    'End Function

    Public Function getCortadores(ByVal idNaveSay As Integer, ByVal tipo As Enumerados.TipoCortador) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pIdNaveSay"
        parametro.Value = idNaveSay
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pTipo"
        parametro.Value = tipo
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Produccion.SP_Produccion_ObtenerCatalogoCortadores", listaparametros)
    End Function

    'Public Function GetIdPrograma(ByVal nave As Integer, ByVal fecha As String) As DataTable
    '    Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
    '    Dim consulta As String =
    '        <cadena>
    '            select p.idprograma, p.estatus, pn.St,pn.StatusBorr,pn.IdcatNave from programas p 
    '            INNER JOIN prgProgramasNave pn ON p.IdPrograma = pn.IdcatPrograma 
    '        </cadena>
    '    consulta += " where p.fechaprograma='" + fecha + "' and pn.IdCatNave=" + nave.ToString
    '    Return operaciones.EjecutaConsulta(consulta)
    'End Function

    Public Function GetIdPrograma(ByVal idNaveSicy As Integer, ByVal fechaPrograma As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY

        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pIdNaveSicy"
        parametro.Value = idNaveSicy
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pFechaPrograma"
        parametro.Value = fechaPrograma
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Produccion.SP_Produccion_ObtenerProgramaNave", listaparametros)
    End Function

    'Public Function getBorrador(ByVal nave As Integer, ByVal idPrograma As Integer) As DataTable
    '    Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
    '    Dim consulta As String =
    '        <cadena>
    '            SELECT 0 seleccion,'' 'No','' ' ',
    '             '' AS Imagen,ISNULL(l.NoLote, '') AS NoLote,e.IdModelo, l.IdCodigo, e.Coleccion,t.Talla,  e.Color,  l.Cantidad AS Pares, '' AS Compl, '' AS Total,
    '              isnull(l.IdCortadorPielSay,0) AS Cortador_Piel,isnull(l.idcortadorpielsintsay,0) AS Cortador_PielSint, isnull(l.IdCortadorForroSay,0) AS Cortador_Forro, 
    '             isnull(l.idcortadorforrosintsay,0) AS Cortador_ForroSint, ISNULL(l.CN, 0) AS Concentrado,
    '             pd.IdTalla, (c.Nombre + ' (' + ISNULL(d.Nombre, '') + ')') AS Cliente, l.IdPrograma, l.IdNave, l.IdPedido,
    '             l.IdPartida, l.IdLote, l.MotivoRechazo,'' 'NoCompletar' 
    '             FROM LotesA l
    '             INNER JOIN PedidosDetalles pd ON l.IdPedido = pd.IdPedido
    '             AND l.IdPartida = pd.IdPartida INNER JOIN Pedidos p ON pd.IdPedido = p.IdPedido 
    '             INNER JOIN vEstilos e ON l.IdCodigo = e.IdCodigo 
    '             INNER JOIN Tallas t ON pd.IdTalla = t.IdTalla 
    '             LEFT JOIN Distribuciones d ON pd.IdDistribucion = d.IdDistribucion 
    '             INNER JOIN Cadenas c ON p.IdCadena = c.idCadena
    '             WHERE l.CN IS NULL AND l.IdNave = <%= nave %> AND l.IdPrograma =<%= idPrograma %>
    '             AND l.estatus NOT IN ('Cancelado') 
    '             UNION ALL SELECT 0 seleccion,'' 'No','' ' ',
    '             '' AS Imagen, ISNULL(l.NoLote, '') AS NoLote,e.IdModelo,l.IdCodigo, e.Coleccion, t.Talla, e.Color,  SUM(l.Cantidad) AS Pares, '' AS Compl,
    '             '' AS Total, isnull(l.IdCortadorPielSay,0) AS Cortador_Piel,isnull(l.idcortadorpielsintsay,0) AS Cortador_PielSint, isnull(l.IdCortadorForroSay,0) AS Cortador_Forro, 
    '             isnull(l.idcortadorforrosintsay,0) AS Cortador_ForroSint,  l.CN AS Concentrado,
    '             pd.IdTalla, ('CONCENTRADO ' + CAST(l.CN AS varchar(2))) AS Clientes, l.IdPrograma, l.IdNave, 0 AS IdPedido,
    '             0 AS IdPartida, 0 AS IdLote, l.MotivoRechazo,'' 'NoCompletar' 
    '             FROM LotesA l 
    '             INNER JOIN PedidosDetalles pd ON l.IdPedido = pd.IdPedido AND l.IdPartida = pd.IdPartida
    '             INNER JOIN vEstilos e ON l.IdCodigo = e.IdCodigo
    '             INNER JOIN Tallas t ON pd.IdTalla = t.IdTalla
    '             WHERE l.CN IS NOT NULL AND l.IdNave = <%= nave %>
    '             AND l.IdPrograma = <%= idPrograma %>
    '             AND l.estatus NOT IN ('Cancelado')
    '             GROUP BY l.IdCodigo, e.Coleccion, e.IdModelo, e.Color, t.Talla, l.CN, pd.IdTalla, l.IdPrograma,
    '             l.IdNave, l.IdCortadorForroSay, l.IdCortadorPielSay, l.MotivoRechazo, l.NoLote,l.idcortadorpielsintsay , l.idcortadorforrosintsay
    '             ORDER BY Concentrado, l.IdCodigo, pd.IdTalla
    '        </cadena>
    '    Return operaciones.EjecutaConsulta(consulta)
    'End Function

    Public Function getBorrador(ByVal idNaveSicy As Integer, ByVal idPrograma As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY

        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pIdNaveSicy"
        parametro.Value = idNaveSicy
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdPrograma"
        parametro.Value = idPrograma
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Produccion.SP_Produccion_ObtenerBorradorNave", listaparametros)
    End Function

    'Public Function GetPrograma(ByVal nave As Integer, ByVal idPrograma As Integer) As DataTable
    '    Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
    '    Dim consulta As String =
    '        <cadena>              
    '            select * from programas p 
    '            INNER JOIN prgProgramasNave pn ON p.IdPrograma = pn.IdcatPrograma 
    '             Where IdcatNave=<%= nave %> and IdcatPrograma=<%= idPrograma %>
    '        </cadena>
    '    Return operaciones.EjecutaConsulta(consulta)
    'End Function

    Public Function GetEstatusRechazoPrograma(ByVal idNaveSicy As Integer, ByVal idPrograma As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pIdNaveSicy"
        parametro.Value = idNaveSicy
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdPrograma"
        parametro.Value = idPrograma
        listaparametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Produccion.SP_Produccion_ObtenerEstatusRechazoProgramaNave", listaparametros)
    End Function

    'Public Function RechazarBorrador(ByVal nave As Integer, ByVal idPrograma As Integer, ByVal motivoRechazo As String) As DataTable
    '    Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
    '    Dim consulta As String =
    '        <cadena>
    '            UPDATE prgProgramasNave SET StatusBorr='Abierto [Rechazado]', 
    '            MotivoRechazoBorrador='<%= motivoRechazo %>'
    '            WHERE IdCatNave=<%= nave %> and IdCatPrograma=<%= idPrograma %>
    '        </cadena>
    '    Return operaciones.EjecutaConsulta(consulta)
    'End Function

    Public Sub RechazarBorrador(ByVal idNaveSicy As Integer, ByVal idPrograma As Integer, ByVal motivoRechazo As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pIdNaveSicy"
        parametro.Value = idNaveSicy
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pIdPrograma"
        parametro.Value = idPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pMotivoRechazo"
        parametro.Value = motivoRechazo
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Produccion.SP_Produccion_RechazarBorrador", listaparametros)
    End Sub

    Public Function ConsultarNaveSicy(ByVal idNaveSay As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select nave_navesicyid from Framework.Naves where nave_naveid=<%= idNaveSay %>
            </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function

End Class
