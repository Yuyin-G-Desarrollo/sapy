Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports Persistencia

Public Class BahiasDA
    ''' <summary>
    ''' Alta de bahias
    ''' </summary>
    ''' <param name="Bahia"></param>
    ''' <remarks></remarks>
    Public Sub AltaBahias(ByVal Bahia As Entidades.Bahia)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaValores As New List(Of SqlParameter)


        Dim valores As New SqlParameter
        valores.ParameterName = "bahi_bahiaid"
        valores.Value = Bahia.bahiaid
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "bahi_nave"
        valores.Value = Bahia.bahia_nave
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "bahi_almacen"
        valores.Value = Bahia.bahi_almacen
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "bahi_bloque"
        valores.Value = Bahia.bahi_bloque
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "bahi_fila"
        valores.Value = Bahia.bahi_fila
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "bahi_segmento"
        valores.Value = CChar(ChrW(Bahia.bahi_segmento))
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "bahi_nivel"
        valores.Value = Bahia.bahi_nivel
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "bahi_descripcion"
        valores.Value = Bahia.bahi_descripcion
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "bahi_posicion"
        valores.Value = Bahia.bahi_posicion
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "bahi_color"
        valores.Value = Bahia.bahi_color
        listaValores.Add(valores)




        valores = New SqlParameter
        valores.ParameterName = "bahi_activo"
        valores.Value = Bahia.bahi_activo
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "bahi_usuariocreoid"
        valores.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "capacidadenpares"
        valores.Value = Bahia.capacidadenpares
        listaValores.Add(valores)


        operaciones.EjecutarSentenciaSP("Almacen.SP_AltaBahias", listaValores)

        AddEstivas(Bahia)

    End Sub
    ''' <summary>
    ''' Buscar la configuracion de un almacen
    ''' </summary>
    ''' <param name="Naveid"></param>
    ''' <param name="Almacenid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BuscarConfiracionAlmacen(ByVal Naveid As Int32, ByVal Almacenid As Int32, ByVal Bloque As String, ByVal nivel As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta = "select * from Almacen.ConfiguracionBloque where cobl_bloque='" + Bloque + "' and cobl_nivel='" + nivel + "' and cobl_almacen= " + Almacenid.ToString + " and cobl_nave=" + Naveid.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    ''' <summary>
    ''' Carga el tamaño del mapa para dibujarlo
    ''' </summary>
    ''' <param name="Naveid"></param>
    ''' <param name="Almacenid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CargarMapaBahias(ByVal Naveid As Int32, ByVal Almacenid As Int32, ByVal Bloque As String, ByVal Nivel As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta = "select * from Almacen.Bahia where  bahi_almacen= " + Almacenid.ToString + " and bahi_nave= " + Naveid.ToString + " and bahi_bloque='" + Bloque + "' and bahi_nivel='" + Nivel + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    ''' <summary>
    ''' Alta de Configuracion de un bloque
    ''' </summary>
    ''' <param name="conf"></param>
    ''' <remarks></remarks>
    Public Sub AltaConfiguracionBloques(ByVal conf As Entidades.ConfiguracionBahia)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaValores As New List(Of SqlParameter)


        Dim valores As New SqlParameter
        valores.ParameterName = "Naveid"
        valores.Value = conf.pcobo_nave
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "Almacen"
        valores.Value = conf.pcobo_almacen
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "Nivel"
        valores.Value = conf.pcobl_nivel
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "Bloque"
        valores.Value = conf.pcobl_bloque
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "Renglones"
        valores.Value = conf.pcobl_renglones
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "columnas"
        valores.Value = conf.pcobl_columnas
        listaValores.Add(valores)



        valores = New SqlParameter
        valores.ParameterName = "@usuariocreo"
        valores.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaValores.Add(valores)


        operaciones.EjecutarSentenciaSP("Almacen.SP_AltaConfiguracionBloque", listaValores)
    End Sub
    ''' <summary>
    ''' Pone en inactivo las bahias que seran parte de una mayor
    ''' </summary>
    ''' <param name="bahia"></param>
    ''' <remarks></remarks>
    Public Sub EstablecerBahiaMenores(ByVal bahia As Entidades.Bahia)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "update Almacen.Bahia set bahi_bahiaprincipalid='" + bahia.bahi_bahiaprincipalid + "', bahi_activo='False', bahi_color='" + bahia.bahi_color + "' where bahi_bahiaid='" + bahia.bahiaid + "'"
        operaciones.EjecutaConsulta(consulta)
    End Sub
    ''' <summary>
    ''' Edicion de las bahias de forma masiva
    ''' Se realiza para realizar actualizaciones de forma masiva en caso de no contar con descripcion y que su numero de capacidad sea 0 de lo contrario
    ''' no se puede realizar ningun cambio y se ejecutara la actualizacion de forma individual 
    ''' </summary>
    ''' <param name="Bahia"></param>
    ''' <remarks></remarks>
    Public Sub EdicionBahiasMasiva(ByVal Bahia As Entidades.Bahia)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaValores As New List(Of SqlParameter)

        Dim valores As New SqlParameter
        valores.ParameterName = "bahi_bahiaid"
        valores.Value = Bahia.bahiaid
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "bahi_nave"
        valores.Value = Bahia.bahia_nave
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "bahi_almacen"
        valores.Value = Bahia.bahi_almacen
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "bahi_descripcion"
        valores.Value = Bahia.bahi_descripcion
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "bahi_posicion"
        valores.Value = Bahia.bahi_posicion
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "bahi_color"
        valores.Value = Bahia.bahi_color
        listaValores.Add(valores)




        valores = New SqlParameter
        valores.ParameterName = "bahi_activo"
        valores.Value = Bahia.bahi_activo
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "bahi_usuariomodificoid"
        valores.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "bahi_capacidadenpares"
        valores.Value = Bahia.capacidadenpares
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "bahi_referenciaubicacionid"
        If Bahia.bahi_referenciaubicacionid <= 0 Then
            valores.Value = DBNull.Value
        Else
            valores.Value = Bahia.bahi_referenciaubicacionid
        End If

        listaValores.Add(valores)

        operaciones.EjecutarSentenciaSP("Almacen.SP_EditarBahiaMasiva", listaValores)
    End Sub
    Public Sub AddEstivas(ByVal Bahia As Entidades.Bahia)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaValores As New List(Of SqlParameter)


        Dim valores As New SqlParameter
        valores.ParameterName = "@BAHIAID"
        valores.Value = Bahia.bahiaid
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "@BAHIACLEAN"
        Dim bahiaclean As String()
        bahiaclean = Bahia.bahiaid.Split("-")
        valores.Value = bahiaclean(0)
        listaValores.Add(valores)




        valores = New SqlParameter
        valores.ParameterName = "@NAVE"
        valores.Value = Bahia.bahia_nave
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "@ALMACEN"
        valores.Value = Bahia.bahi_almacen
        listaValores.Add(valores)



        valores = New SqlParameter
        valores.ParameterName = "@USUARIOCREO"
        valores.Value = 1
        listaValores.Add(valores)


        operaciones.EjecutarSentenciaSP("Almacen.SP_AltaESTIBA", listaValores)
    End Sub
    Public Function CargarBloques(ByVal Naveid As Int32, ByVal Almacen As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta = "select DISTINCT bahi_bloque from Almacen.Bahia where bahi_nave=" + Naveid.ToString + " and bahi_almacen='" + Almacen.ToString + "'  order by bahi_bloque desc"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function CargarBloquesCombo(ByVal Naveid As Int32, ByVal Almacen As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta = "select DISTINCT bahi_bloque from Almacen.Bahia where bahi_nave=" + Naveid.ToString + " and bahi_almacen='" + Almacen.ToString + "'  order by bahi_bloque"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function CargarNiveles(ByVal Naveid As Int32, ByVal Almacen As String, ByVal Bloque As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta = "select DISTINCT bahi_nivel from Almacen.Bahia where bahi_nave=" + Naveid.ToString + " and bahi_almacen='" + Almacen.ToString + "' and bahi_bloque='" + Bloque + "' ORDER	BY bahi_nivel asc"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function ObtenerColoBahia(ByVal BahiaID As String) As String

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta = "select bahi_color FROM Almacen.Bahia where bahi_bahiaid = '" + BahiaID + "'"
        Dim tabla As DataTable = operaciones.EjecutaConsulta(consulta)
        Dim color As String = String.Empty
        For Each row As DataRow In tabla.Rows
            color = CStr(row("bahi_color"))
        Next
        Return color

    End Function
    Public Function AgregarColumna(ByVal Nave As Int32, ByVal Almacen As String, ByVal Bloque As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select TOP 1 bahi_fila from Almacen.Bahia WHERE bahi_nave=" + Nave.ToString + " AND bahi_bloque='" + Bloque + "' and bahi_almacen='" + Almacen + "' ORDER by bahi_fila  desc"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function ValidadEstibasVacias(ByVal bahia As Entidades.Bahia) As Boolean
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim vacio As Boolean = True
        Dim consulta As String = " select * FROM Almacen.UbicacionAtados as a join	 Almacen.Estiba as b on a.ubat_estibaid=b.esti_estibaid  where b.esti_bahiaid = '" + bahia.bahiaid + "' "
        Dim tabla As New DataTable
        tabla = operaciones.EjecutaConsulta(consulta)
        If tabla.Rows.Count > 0 Then
            vacio = False
        End If
        consulta = " select * from Almacen.UbicacionPares as a join	 Almacen.Estiba as b on a.ubpa_estibaid=b.esti_estibaid  where b.esti_bahiaid = '" + bahia.bahiaid + "' "
        tabla = operaciones.EjecutaConsulta(consulta)
        If tabla.Rows.Count > 0 Then
            vacio = False
        End If
        Return vacio

    End Function
    Public Sub ActivarDesactivarEstibas(ByVal bahia As Entidades.Bahia, ByVal estado As Boolean)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        If estado = False Then

            consulta = "update Almacen.Estiba set esti_activo=0, esti_fechamodificacion= (GETDATE()),esti_usuariomodificaid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + " where esti_bahiaid='" + bahia.bahiaid + "'"
        Else
            consulta = "update Almacen.Estiba set esti_activo=1, esti_fechamodificacion= (GETDATE()),esti_usuariomodificaid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + " where esti_bahiaid='" + bahia.bahiaid + "'"

        End If
        operaciones.EjecutaConsulta(consulta)
    End Sub
    Public Function BuscarRutaImagen(ByVal idimagen As Int32) As String
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "select reub_urlimagen from Almacen.ReferenciaUbicacion where reub_referenciaubicacionid =" + idimagen.ToString
        Dim tabla As New DataTable
        tabla = operaciones.EjecutaConsulta(consulta)
        Dim Ruta As String = ""
        For Each row As DataRow In tabla.Rows
            Ruta = CStr(row("reub_urlimagen"))
        Next
        Return Ruta
    End Function
    Public Function ObtenerCantidadParesEnBahia(ByVal idBahia As String) As Int32
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String
        Dim Cantidad As Int32 = 0
        Dim tablatemporal As DataTable
        Consulta = "select sum(ubat_pares) as paresatado from Almacen.UbicacionAtados where ubat_estibaid in (select esti_estibaid from Almacen.Estiba where esti_bahiaid='" + idBahia + "') AND ubat_activo = 1"
        tablatemporal = operaciones.EjecutaConsulta(Consulta)
        For Each row As DataRow In tablatemporal.Rows

            If Not IsDBNull(row("paresatado")) Then
                Cantidad += CInt(row("paresatado"))
            End If

        Next

        Consulta = "select COUNT(ersp_codigopar) as pareserror from Almacen.ErroresStatusPar where ersp_estibaid in (select esti_estibaid from Almacen.Estiba where esti_bahiaid='" + idBahia + "') AND ersp_activo = 1"
        tablatemporal = operaciones.EjecutaConsulta(Consulta)
        For Each row As DataRow In tablatemporal.Rows

            If Not IsDBNull(row("pareserror")) Then
                Cantidad += CInt(row("pareserror"))
            End If

        Next

        Consulta = "select COUNT(*) parespares from Almacen.UbicacionPares where ubpa_estibaid in (select esti_estibaid from Almacen.Estiba where esti_bahiaid='" + idBahia + "') AND ubpa_activo = 1"
        tablatemporal = operaciones.EjecutaConsulta(Consulta)
        For Each row As DataRow In tablatemporal.Rows
            If Not IsDBNull(row("parespares")) Then
                Cantidad += CInt(row("parespares"))
            End If

        Next
        Return Cantidad
    End Function
    Public Function ObtenerPorcentajeUbicacion(ByVal Nave As Int32, ByVal Almacen As String, ByVal Bloque As String, ByVal Nivel As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaValores As New List(Of SqlParameter)


        Dim valores As New SqlParameter
        valores.ParameterName = "@Nave"
        valores.Value = Nave
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "@Almacen"
        valores.Value = Almacen
        listaValores.Add(valores)



        valores = New SqlParameter
        valores.ParameterName = "@Bloque"
        valores.Value = Bloque
        listaValores.Add(valores)


        valores = New SqlParameter
        valores.ParameterName = "@Nivel"
        valores.Value = Nivel
        listaValores.Add(valores)

        Return operaciones.EjecutarConsultaSP("Almacen.OcupacionActual", listaValores)


    End Function
    Public Function ImprimirEstibas(ByVal ListaBahias As HashSet(Of Entidades.Bahia)) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        Dim segundo As Boolean = False
        For Each bahia As Entidades.Bahia In ListaBahias
            If segundo = False Then
                consulta = "select esti_estibaid, esti_bahiaid from Almacen.Estiba where esti_bahiaid='" + bahia.bahiaid + "' "
                segundo = True
            Else
                consulta += "or esti_bahiaid = '" + bahia.bahiaid + "' "
            End If
        Next
        If ListaBahias.Count > 0 Then
            Return operaciones.EjecutaConsulta(consulta)
        End If

    End Function




    Public Function ObtenerContenidoBahia(ByVal lista_bahias As String) As DataTable
        'Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        'Dim consulta As String = String.Empty
        'Dim segundo As Boolean = False
        'For Each bahia As Entidades.Bahia In ListaBahias
        '    If segundo = False Then
        '        consulta = "select a.bahi_bahiaid, (select COUNT(*) parespares from Almacen.UbicacionPares where ubpa_estibaid in (select esti_estibaid from Almacen.Estiba where esti_bahiaid=a.bahi_bahiaid)) as parespares, + (SELECT COUNT(*) pareserror FROM Almacen.ErroresStatusPar WHERE ersp_estibaid IN (SELECT esti_estibaid FROM Almacen.Estiba WHERE esti_bahiaid = a.bahi_bahiaid)) as pareserror,(CASE WHEN (SELECT SUM(ubat_pares) AS paresatado FROM Almacen.UbicacionAtados WHERE ubat_estibaid IN (SELECT esti_estibaid FROM Almacen.Estiba WHERE esti_bahiaid = a.bahi_bahiaid)) IS NULL THEN 0  ELSE (SELECT SUM(ubat_pares) AS paresatado FROM Almacen.UbicacionAtados WHERE ubat_estibaid IN (SELECT esti_estibaid FROM Almacen.Estiba WHERE esti_bahiaid = a.bahi_bahiaid)) END) AS paresatado, (select count(ubat_pares) as atados from Almacen.UbicacionAtados where ubat_estibaid in (select esti_estibaid from Almacen.Estiba where esti_bahiaid=a.bahi_bahiaid)) as atados, a.bahi_nave, a.bahi_bloque, (cast (a.bahi_fila as int)) as bahi_fila, a.bahi_nivel, a.bahi_segmento, ((select COUNT(*) parespares from Almacen.UbicacionPares where ubpa_estibaid in (select esti_estibaid from Almacen.Estiba where esti_bahiaid=a.bahi_bahiaid)) + (CASE WHEN (SELECT SUM(ubat_pares) AS paresatado FROM Almacen.UbicacionAtados WHERE ubat_estibaid IN (SELECT esti_estibaid FROM Almacen.Estiba WHERE esti_bahiaid = a.bahi_bahiaid)) IS NULL THEN 0  ELSE (SELECT SUM(ubat_pares) AS paresatado FROM Almacen.UbicacionAtados WHERE ubat_estibaid IN (SELECT esti_estibaid FROM Almacen.Estiba WHERE esti_bahiaid = a.bahi_bahiaid)) END) AS paresatado,+ (SELECT COUNT(*) pareserror FROM Almacen.ErroresStatusPar WHERE ersp_estibaid IN (SELECT esti_estibaid FROM Almacen.Estiba WHERE esti_bahiaid = a.bahi_bahiaid))) as suma from Almacen.Bahia as a join Almacen.Estiba as b on (a.bahi_bahiaid=b.esti_bahiaid) JOIN Almacen.UbicacionAtados as c on (b.esti_estibaid = c.ubat_estibaid) join Almacen.UbicacionPares as d on (b.esti_estibaid=d.ubpa_estibaid) "

        '        consulta += " where a.bahi_bahiaid='" + bahia.bahiaid + "' "
        '        segundo = True
        '    Else
        '        consulta += "or a.bahi_bahiaid = '" + bahia.bahiaid + "' "
        '    End If
        'Next

        'consulta += " GROUP BY a.bahi_bahiaid, a.bahi_nave,a.bahi_bloque, a.bahi_fila, a.bahi_nivel, a.bahi_segmento"
        'If ListaBahias.Count > 0 Then
        '    Return operaciones.EjecutaConsulta(consulta)
        'End If

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        ',@lista_bahias AS VARCHAR(MAX)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "lista_bahias"
        parametro.Value = lista_bahias
        listaParametros.Add(parametro)
        Return operaciones.EjecutarConsultaSP("Almacen.SP_Obtener_Contenido_Bahia", listaParametros)

        'Console.WriteLine("Mando la sentencia")

    End Function

    Public Sub LimpiarParesBahia(ByVal Bahia As String)
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        ',@lista_bahias AS VARCHAR(MAX)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@BahiaId"
        parametro.Value = Bahia
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("[Almacen].[SP_Ubicaciones_LimpiarParesBahia]", listaParametros)


    End Sub




End Class
